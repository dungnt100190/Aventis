using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiSS4.Sozialhilfe.ZH
{
    partial class DlgWhWeitereKOA : KissDialog
    {
        private const KiSSKunde KISS_KUNDE = KiSSKunde.FAMOZ;

        private readonly int _bgPositionID;

        private readonly int _klientID;

        private readonly string _originalMaskName;

        private readonly bool _readOnly = true;

        private readonly Decimal _totalbetrag;

        private readonly object _valutaDatum;

        private ShBuchungstext _buchungstext;

        private bool _dataModified;

        private int _newBgKategorieCode;

        public DlgWhWeitereKOA(int bgPositionID, string originalMaskName, Decimal totalBetrag, bool allowEdit)
            : this()
        {
            _bgPositionID = bgPositionID;
            _totalbetrag = totalBetrag;
            _originalMaskName = originalMaskName;

            // Tooltips setzen
            toolTip1 = new ToolTip();
            toolTip1.SetToolTip(btnZusatzleistung, "neue zusätzliche Leistung");

            edtTotalbetragAlt.EditValue = totalBetrag;

            colKat.ColumnEdit = kissGrid1.GetLOVLookUpEdit(DBUtil.OpenSQL("select Code, Text = substring(Text,1,1) from XLOVCode where LOVName = 'BgKategorie'"));

            SqlQuery qry = DBUtil.OpenSQL(@"
                select Code = FPP.BaPersonID,
                       Text = PRS.NameVorname +
                              ' (' + isNull(convert(varchar,PRS.AlterMortal),'-') +
                              isNull(',' + GES.ShortText,'') + ')',
                              NameVorname = PRS.NameVorname
                from   BgPosition BPO
                       inner join BgBudget              BDG on BDG.BgBudgetID = BPO.BgBudgetID
                       inner join BgFinanzPlan_BaPerson FPP on FPP.BgFinanzplanID = BDG.BgFinanzplanID
                       inner join vwPerson              PRS on PRS.BaPersonID = FPP.BaPersoNID
                       left  join XLOVCode GES on GES.LOVName = 'BaGeschlecht' AND GES.Code = PRS.GeschlechtCode

                where  BPO.BgPositionID = {0} and
                       IstUnterstuetzt = 1
                order by PRS.NameVorname",
                _bgPositionID);

            edtBaPersonID.LoadQuery(qry);
            colPerson.ColumnEdit = kissGrid1.GetLOVLookUpEdit(qry);

            edtBgSplittingCode.LoadQuery(DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'BgSplittingart'"), "Code", "ShortText");

            qryBgBudget.Fill(bgPositionID);
            qryBgPosition.Fill(bgPositionID);
            UpdateSum();

            if (qryBgPosition.Count > 0)
            {
                int status = ShUtil.GetCode(qryBgPosition["Status"]);
                _readOnly = !(status <= 1 || status == 12 || status == 14 || status == 15) || !allowEdit;
                _valutaDatum = qryBgPosition["ValutaDatum"];
                _klientID = Convert.ToInt32(qryBgPosition["KlientID"]);
            }

            qryBgPosition.CanInsert = !_readOnly;
            qryBgPosition.CanUpdate = !_readOnly;
            qryBgPosition.CanDelete = !_readOnly;

            edtTotalbetragAlt.Visible = allowEdit;
            lblTotalbetragAlt.Visible = allowEdit;
            edtTotalbetragNeu.Visible = allowEdit;
            lblTotalbetragNeu.Visible = allowEdit;
            edtDifferenz.Visible = allowEdit;
            lblDifferenz.Visible = allowEdit;
            btnZusatzleistung.Visible = allowEdit;

            qryBgPosition.EnableBoundFields(!_readOnly);
            SetEditMode();
        }

        public DlgWhWeitereKOA(int bgPositionID, string originalMaskName, Decimal totalBetrag)
            : this(bgPositionID, originalMaskName, totalBetrag, true)
        {
        }

        public DlgWhWeitereKOA()
        {
            InitializeComponent();
        }

        public enum KiSSKunde
        {
            BSS = 1,  //BSS ist Standard
            FAMOZ = 2 //ZH
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            userCancel = true;
        }

        private void btnEinzelzahlung_Click(object sender, EventArgs e)
        {
            NeuePosition(101);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post())
            {
                return;
            }

            if (!_dataModified)
            {
                userCancel = true;
                DialogResult = DialogResult.Cancel;
                return;
            }

            UpdateSum();

            if ((Decimal)edtDifferenz.EditValue != 0m)
            {
                if (!KissMsg.ShowQuestion("Das neue Total ist nicht gleich dem alten Total. Soll trotzdem gespeichert werden?"))
                {
                    return;
                }
            }

            //Speichern aller Position en bloc
            //- Detailpositionen neu anlegen
            //- Auszahlinfo für Detailposition kopieren von der Hauptposition

            try
            {
                DBUtil.ThrowExceptionOnOpenTransaction();

                Session.BeginTransaction();
                // Plausibilitätstest: Es dürfen keine Buchungen zu den Positionen bestehen.
                var buchungExistiert = DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT TOP 1 x = 1
                    FROM KbBuchungKostenart
                    WHERE BgPositionID = {0}
                    UNION
                    SELECT TOP 1 1
                    FROM KbBuchungKostenart
                    WHERE BgPositionID IN (SELECT BgPositionID FROM BgPosition WHERE BgPositionID_Parent = {0})
                    UNION
                    SELECT TOP 1 1
                    FROM KbBuchungBruttoPerson
                    WHERE BgPositionID = {0}
                    UNION
                    SELECT TOP 1 1
                    FROM KbBuchungBruttoPerson
                    WHERE BgPositionID IN (SELECT BgPositionID FROM BgPosition WHERE BgPositionID_Parent = {0})
                    ",
                    _bgPositionID);

                if (!DBUtil.IsEmpty(buchungExistiert))
                {
                    throw new Exception(string.Format("Die Änderungen konnten nicht gespeichert werden, da es bereits Buchungen zur Position gibt. (ID: {0})", _bgPositionID));
                }

                //Detailposten löschen, inkl. Auszahlinfo (cascading delete) (ausser die Verrechnungsposition der Hauptposition)
                DBUtil.ExecSQLThrowingException(@"
                    -- Verrechnungspositionen von Detailposten löschen
                    DELETE POSV
                    FROM dbo.BgPosition POS
                      INNER JOIN dbo.BgPosition POSV ON POSV.BgPositionID_Parent = POS.BgPositionID
                    WHERE POS.BgPositionID_Parent = {0}
                      AND POSV.BgKategorieCode = 3;

                    -- Detailposten löschen
                    DELETE POS
                    FROM dbo.BgPosition POS
                    WHERE POS.BgPositionID_Parent = {0}
                      AND POS.BgKategorieCode <> 3;",
                    _bgPositionID);

                //Falls ZL und EZ gemischt und Hauptpos eine Einzelzahlung,
                //dann wird erste ZL die neue Hauptpos
                DataRow hauptPos = null;
                DataRow ersteZlPos = null;
                foreach (DataRow row in qryBgPosition.DataTable.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        if (row["Typ"].ToString() == "*")
                        {
                            hauptPos = row;
                        }
                        else if ((ersteZlPos == null) && ((int)row["BgKategorieCode"] == 100))
                        {
                            ersteZlPos = row;
                        }
                    }
                }

                if ((int)hauptPos["BgKategorieCode"] == 101 && (ersteZlPos != null))
                {
                    hauptPos["Typ"] = "+";
                    ersteZlPos["Typ"] = "*";
                }

                foreach (DataRow row in qryBgPosition.DataTable.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        object newBgPositionID;
                        if (row["Typ"].ToString() == "+")
                        {
                            //Detailposition als Kopie der Hauptposition anlegen, inkl. Auszahlinfo
                            //Auszahltermin immer "Valuta"
                            SqlQuery qry = DBUtil.OpenSQL(@"
                                  declare @BgPositionID int
                                  declare @BgAuszahlungPersonID int
                                  declare @NewBgPositionID int
                                  declare @WhereClause varchar(200)

                                  set @BgPositionID = {0}

                                  -- BgPosition
                                  set @WhereClause = 'BgPositionID = ' + convert(varchar,@BgPositionID)
                                  exec spDuplicateRows 'BgPosition',@WhereClause,
                                                       'BgPositionID_Parent', @BgPositionID

                                  set @NewBgPositionID = @@identity

                                  -- BgAuszahlungPerson
                                  set @WhereClause = 'BgPositionID = ' + convert(varchar,@BgPositionID)
                                  exec spDuplicateRows 'BgAuszahlungPerson',@WhereClause,
                                                       'BgPositionID', @NewBgPositionID

                                  -- BgAuszahlungPersonTermin
                                  select @WhereClause = 'BgAuszahlungPersonID = '  + convert(varchar,BgAuszahlungPersonID)
                                  from   BgAuszahlungPerson
                                  where  BgPositionID = @BgPositionID

                                  exec spDuplicateRows 'BgAuszahlungPersonTermin',@WhereClause,
                                                       'BgAuszahlungPersonID',@@identity

                                  select NewBgPositionID = @NewBgPositionID",
                                  _bgPositionID);

                            newBgPositionID = qry["NewBgPositionID"];

                            //Eine neue Detailposition wurde angelegt
                            //Wir müssen einen Verlauf-Eintrag
                            WhUtil.InsertPositionVerlaufEintrag((int)newBgPositionID, Session.User.UserID, _originalMaskName, 10);
                        }
                        else
                        {
                            newBgPositionID = _bgPositionID;
                        }

                        //Position updaten mit erfassten Daten
                        DBUtil.ExecSQLThrowingException(@"
                            update BgPosition
                            set    BgKategorieCode  = {0},
                                   BgPositionsartID = {1},
                                   Buchungstext     = {2},
                                   BaPersonID       = {3},
                                   Betrag           = {4},
                                   BgSpezkontoID    = {5},
                                   VerwPeriodeVon   = {6},
                                   VerwPeriodeBis   = {7},
                                   ErstelltUserID   = {8},
                                   ErstelltDatum    = {9},
                                   MutiertUserID    = {10},
                                   MutiertDatum     = {11}
                            where BgPositionID = {12}",
                            row["BgKategorieCode"],
                            row["BgPositionsartID"],
                            row["Buchungstext"],
                            row["BaPersonID"],
                            row["Betrag"],
                            row["BgSpezkontoID"],
                            row["VerwPeriodeVon"],
                            row["VerwPeriodeBis"],
                            row["ErstelltUserID"],
                            row["ErstelltDatum"],
                            row["MutiertUserID"],
                            row["MutiertDatum"],
                            newBgPositionID);

                        WhUtil.InsertOrUpdateVerrechnungsposition((int)newBgPositionID);
                    }
                }

                //Insert Verlauf-Eintrag

                Session.Commit();
            }
            catch (KissInfoException ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                KissMsg.ShowInfo(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                KissMsg.ShowError("Fehler beim Speichern der Positionen:\r\n\r\n" + ex.Message);
                return;
            }

            userCancel = false;
            DialogResult = DialogResult.OK;
        }

        private void btnZusatzleistung_Click(object sender, EventArgs e)
        {
            NeuePosition(100);
        }

        private void edtBgSpezkontoID_EditValueChanged(object sender, EventArgs e)
        {
            if (qryBgPosition.IsFilling) return;
            if (!edtBgSpezkontoID.Focused) return;

            qryBgPosition["BgSpezKontoID"] = edtBgSpezkontoID.EditValue;
            qryBgPosition["SpezKonto"] = GetFieldFromSpezkonto(qryBgPosition["BgSpezkontoID"], "Text").ToString();

            SetSpezialkonto();
            SetEditMode();
            _buchungstext.SelectAllText();
        }

        private void edtBuchungstext_TextChanged(object sender, EventArgs e)
        {
            if (edtBuchungstext.UserModified)
            {
                _buchungstext.FilterBuchungstext(edtBuchungstext.EditValue.ToString());
            }
        }

        private void edtKategorie_EditValueChanged(object sender, EventArgs e)
        {
            if (!edtKategorie.UserModified)
            {
                return;
            }

            qryBgPosition["BgKategorieCode"] = edtKategorie.EditValue;
            var kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);

            if (kategorie == 100)
            {
                //Zusatzleistung
                qryBgPosition["BgSpezKontoID"] = null;
                edtBgSpezkontoID.EditValue = null; //#7960: Doppelt moppeln ist notwendig, da sonst beim Post() der noch vorhandene EditValue ins SqlQuery übertragen wird
                qryBgPosition["SpezKonto"] = null;

                //ZL mit gleicher Leistungsart suchen
                var qry = DBUtil.OpenSQL(@"
                    select BPA.BgPositionsartID,
                           Kostenart = BKA.KontoNr + ' '+ BPA.Name
                    from   BgPositionsart BPA
                           inner join BgKostenart BKA on BKA.BgKostenartID = BPA.BgKostenartID
                           left join  XLOVCode CIN ON CIN.LOVName = 'BgKategorie' AND CIN.Code >= 10000 AND CIN.Code = BPA.BgKategorieCode
                    where  BPA.BgKategorieCode = 100
                      and  BKA.KontoNr = {0}
                      and  CIN.Code IS NULL",
                    qryBgPosition["KOA"]);

                if (qry.Count == 1)
                {
                    qryBgPosition["BgPositionsartID"] = qry["BgPositionsartID"];
                    qryBgPosition["Kostenart"] = qry["Kostenart"];
                }
                else
                {
                    qryBgPosition["Kostenart"] = null;
                    qryBgPosition["KOA"] = null;
                    qryBgPosition["ProPerson"] = false;
                    qryBgPosition["ProUE"] = true;
                }
            }
            else
            {
                //Einzelzahlung
                qryBgPosition["BgPositionsartID"] = null;
                qryBgPosition["Kostenart"] = null;
                qryBgPosition["KOA"] = null;
                qryBgPosition["ProPerson"] = false;
                qryBgPosition["ProUE"] = true;
                LoadSpezialkonto(null, qryBgPosition["BaPersonID"]);
            }

            SetEditMode();
        }

        private void edtKostenart_TextChanged(object sender, EventArgs e)
        {
            if (edtKostenart.Text.Equals(string.Empty))
            {
                qryBgPosition["KOA"] = null;
                qryBgPosition["Kostenart"] = null;
                UpdateLetzte10Buchungen();
            }
        }

        private void edtKostenart_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtKostenart.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgPosition["BgPositionsArtID"] = DBNull.Value;
                    qryBgPosition["Kostenart"] = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            const string koaText = "LA";
            string sql =
                "select " + koaText + @"    = BKA.KontoNr,
                       Positionsart        = BPA.Name,
                       Gruppe              = GRP.Text,
                       BgPositionsartID$   = BPA.BgPositionsartID,
                       BgKostenartID$      = BPA.BgKostenartID,
                       ProPerson$          = BPA.ProPerson,
                       ProUE$              = BPA.ProUE,
                       KOAPositionsart$    = BKA.KontoNr + ' '+ BPA.Name,
                       Name$               = BPA.Name,
                       BgSplittingArtCode$ = BKA.BgSplittingArtCode,
                       sqlRichtlinie$      = BPA.sqlRichtlinie,
                       GruppeFilter$       = convert(varchar(50),GRP.Value3),
                       Quoting             = BKA.Quoting
                from   WhPositionsart BPA
                       inner join BgKostenart BKA on BKA.BgKostenartID = BPA.BgKostenartID
                       left  join XLOVCode    GRP on GRP.LOVName = 'BgGruppe' AND GRP.Code = BPA.BgGruppeCode
                where  BgKategorieCode = 100 and
                       (BPA.Name like '%' + {0} + '%' or
                        BKA.KontoNr like {0} + '%') ";

            sql += " order by 1,2";

            e.Cancel = !dlg.SearchData(sql, searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                var kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);
                try
                {
                    WhUtil.CheckIfInsertVerrechnungspositionIsAllowed(kategorie, (int)qryBgBudget["BgBewilligungStatusCode"], dlg["BgPositionsartID$"] as int?);
                }
                catch (KissInfoException ex)
                {
                    qryBgPosition["BgPositionsArtID"] = DBNull.Value;
                    qryBgPosition["Kostenart"] = DBNull.Value;
                    KissMsg.ShowInfo(ex.Message);
                    e.Cancel = true;
                    return;
                }

                qryBgPosition["BgPositionsArtID"] = dlg["BgPositionsartID$"];
                qryBgPosition["KOA"] = dlg[koaText];
                qryBgPosition["Kostenart"] = dlg["KOAPositionsart$"];
                qryBgPosition["Buchungstext"] = dlg["Name$"];
                qryBgPosition["BgSplittingArtCode"] = dlg["BgSplittingArtCode$"];
                qryBgPosition["ProPerson"] = dlg["ProPerson$"];
                qryBgPosition["ProUE"] = dlg["ProUE$"];
                qryBgPosition["Quoting"] = dlg["Quoting"];

                if (!DBUtil.IsEmpty(qryBgPosition["Quoting"]) && (bool)qryBgPosition["Quoting"])
                    qryBgPosition["BaPersonID"] = null;

                SetVerwendungsPeriode();
                _buchungstext.LoadBuchungstext(qryBgPosition["BgPositionsartID"] as int?, true);
                SetEditMode();
            }

            UpdateLetzte10Buchungen();
        }

        private object GetFieldFromSpezkonto(object bgSpezkontoID, string fieldName)
        {
            var qry = (SqlQuery)edtBgSpezkontoID.Properties.DataSource;
            var rows = qry.DataTable.Select(DBUtil.IsEmpty(bgSpezkontoID) ? "Code is null" : string.Format("Code = {0}", bgSpezkontoID));

            return rows.Length == 1 ? rows[0][fieldName] : null;
        }

        private void LoadSpezialkonto(object bgKostenartID, object baPersonID)
        {
            edtBgSpezkontoID.Properties.ShowHeader = true;
            edtBgSpezkontoID.Properties.DropDownRows = 7;
            edtBgSpezkontoID.Properties.DataSource = DBUtil.OpenSQL(@"
            SELECT Code                = SPK.BgSpezkontoID,
                   Typ                 = TYP.ShortText,
                   KOA                 = BKA.KontoNr,
                   Text                = SPK.NameSpezkonto,
                   Saldo               = dbo.fnBgSpezkonto(SPK.BgSpezkontoID, 3, {2}, {4}),
                   SortKey             = TYP.Sortkey,
                   KOAName             = BKA.KontoNr + ' ' + BKA.Name,
                   BaPersonID          = SPK.BaPersonID,
                   BgPositionsartID    = SPK.BgPositionsartID,
                   BgKostenartID       = BKA.BgKostenartID,
                   KOAPositionsart     = BKA.KontoNr + ' ' + ISNULL(BPA.Name, BKA.Name),
                   BgSplittingArtCode  = BKA.BgSplittingArtCode,
                   ProPerson           = BPA.ProPerson,
                   ProUE               = BPA.ProUE,
                   BaInstitutionID     = SPK.BaInstitutionID,
                   Quoting             = BKA.Quoting
            FROM BgSpezkonto             SPK
                   INNER JOIN XLOVCode        TYP ON TYP.LOVName = 'BgSpezkontoTyp' and TYP.Code = SPK.BgSpezkontoTypCode
                   LEFT  JOIN BgPositionsart  BPA ON BPA.BgPositionsartID = SPK.BgPositionsartID
                   LEFT  JOIN BgPositionsart  GBL ON GBL.BgPositionsartID = {1}
                   LEFT  JOIN BgKostenart     BKA ON BKA.BgKostenartID = ISNULL(SPK.BgKostenartID, GBL.BgKostenartID)
            WHERE SPK.FaLeistungID = {0}
                  AND (    ({3} IN (2, 100) AND (SPK.BgSpezkontoTypCode = 1 AND SPK.BgKostenartID = {5} AND COALESCE(SPK.BaPersonID, {6}, 0) = IsNull({6}, 0) ))
                        OR ({3} IN (6)      AND (SPK.BgSpezkontoTypCode = 2))
                        OR ({3} IN (3)      AND (SPK.BgSpezkontoTypCode = 3))
                        OR ({3} IN (101)    AND (SPK.BgSpezkontoTypCode <> 3 OR SPK.OhneEinzelzahlung = 0)))
                  AND (SPK.BgSpezkontoTypCode <> 2 OR {7} = 1)  -- Vorabzug nur KiSSKunde.BSS

            UNION ALL

            SELECT Code                = NULL,
                   Typ                 = NULL,
                   KOA                 = NULL,
                   Text                = NULL,
                   Saldo               = NULL,
                   SortKey             = 0,
                   KOAName             = BKA.KontoNr + ' ' + BKA.Name,
                   BaPersonID          = NULL,
                   BgPositionsartID    = BPA.BgPositionsartID,
                   BgKostenartID       = BKA.BgKostenartID,
                   KOAPositionsart     = BKA.KontoNr + ' ' + BPA.Name,
                   BgSplittingArtCode  = BKA.BgSplittingArtCode,
                   ProPerson           = BPA.ProPerson,
                   ProUE               = BPA.ProUE,
                   BaInstitutionID     = NULL,
                   Quoting             = BKA.Quoting
            FROM BgKostenart             BKA
                   INNER JOIN BgPositionsart  BPA ON BPA.BgKostenartID = BKA.BgKostenartID
            WHERE BPA.BgPositionsartID = {1}
            ORDER BY SortKey, Text",
            qryBgBudget["FaLeistungID"],
            qryBgBudget["WhGrundbedarfTypCode"],
            qryBgPosition["BgBudgetID"],
            qryBgPosition["BgKategorieCode"],
            qryBgPosition["BgPositionID"],
            bgKostenartID,
            baPersonID,
            (KISS_KUNDE == KiSSKunde.BSS) ? 1 : 0);
        }

        private void NeuePosition(int bgKategorieCode)
        {
            if (!qryBgPosition.Post()) return;
            if (!qryBgPosition.CanInsert) return;

            _newBgKategorieCode = bgKategorieCode;
            qryBgPosition.Insert();
        }

        private void qryBgPosition_AfterDelete(object sender, EventArgs e)
        {
            UpdateSum();
        }

        private void qryBgPosition_AfterFill(object sender, EventArgs e)
        {
            _buchungstext = new ShBuchungstext(edtBuchungstext, qryBgPosition);
        }

        private void qryBgPosition_AfterInsert(object sender, EventArgs e)
        {
            qryBgPosition["BgKategorieCode"] = _newBgKategorieCode;
            qryBgPosition["ProPerson"] = false;
            qryBgPosition["ProUE"] = true;
            qryBgPosition["Typ"] = "+";

            _buchungstext.LoadBuchungstext(qryBgPosition["BgPositionsartID"] as int?, false);
            _buchungstext.FilterBuchungstext(edtBuchungstext.EditValue.ToString());

            _newBgKategorieCode = 0;
            SetEditMode();
            ctlErfassungMutation1.ShowInfo();

            if ((int)qryBgPosition["BgKategorieCode"] == 100)
            {
                edtKostenart.Focus();
            }
            else
            {
                LoadSpezialkonto(null, qryBgPosition["BaPersonID"]);
                edtBetrag.Focus();
            }
        }

        private void qryBgPosition_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            if (qryBgPosition["Typ"].ToString() == "*")
            {
                throw new KissInfoException("Die Hauptposition kann nicht gelöscht werden!");
            }

            if (KissMsg.ShowQuestion("Soll die aktuelle Position gelöscht werden ?"))
            {
                qryBgPosition.DataTable.Rows.Remove(qryBgPosition.Row);
                qryBgPosition.RowModified = false;
                _dataModified = true;
                UpdateSum();
            }

            throw new KissCancelException();
        }

        private void qryBgPosition_BeforeInsert(object sender, EventArgs e)
        {
            if (_newBgKategorieCode != 0) return;

            //Einzelzahlungen (101) sind nicht mehr unterstützt
            _newBgKategorieCode = 100;
        }

        private void qryBgPosition_BeforePost(object sender, EventArgs e)
        {
            var kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);

            DBUtil.CheckNotNullField(edtBuchungstext, lblBuchungstext.Text);

            //LA/Positionsart bei Zusätlichen Leistungen
            if (kategorie == 100) DBUtil.CheckNotNullField(edtKostenart, lblKostenart.Text);

            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);

            if (Convert.ToDecimal(qryBgPosition["Betrag"]) <= Decimal.Zero)
            {
                edtBetrag.Focus();
                throw new KissInfoException("Der Betrag darf nicht 0.00 oder negativ sein!");
            }

            //Betrifft Person
            if (!DBUtil.IsEmpty(qryBgPosition["Quoting"]) && !(bool)qryBgPosition["Quoting"])
            {
                DBUtil.CheckNotNullField(edtBaPersonID, lblBaPersonID.Text);
            }

            //Verwendungsperiode
            int bgSplittingArtCode = ShUtil.GetCode(qryBgPosition["BgSplittingArtCode"]);
            switch (bgSplittingArtCode)
            {
                case 1: //Taggenau
                case 2: //Monat
                    DBUtil.CheckNotNullField(edtVerwPeriodeVon, "Verwendungsperiode von");
                    DBUtil.CheckNotNullField(edtVerwPeriodeBis, "Verwendungsperiode bis");
                    if ((DateTime)edtVerwPeriodeBis.EditValue < (DateTime)edtVerwPeriodeVon.EditValue)
                    {
                        throw new KissInfoException("'Verwendungsperiode von' muss kleiner sein als 'Verwendungsperiode bis'.");
                    }
                    break;

                case 3: //Valuta
                    qryBgPosition["VerwPeriodeVon"] = _valutaDatum;  //ValutaDatum von HauptPos
                    qryBgPosition["VerwPeriodeBis"] = _valutaDatum;  //ValutaDatum von HauptPos
                    break;

                case 4: //Entscheid
                    DBUtil.CheckNotNullField(edtVerwPeriodeVon, "Verwendungsperiode von");
                    break;
            }

            //check Deckung Spezialkonto
            if (kategorie == 101) //Einzelzahlung
            {
                decimal total = 0;
                int anzahl = 0;

                //Total aller Positionen, die von diesem SpezKonto beziehen
                foreach (DataRow row in qryBgPosition.DataTable.Rows)
                {
                    if (!DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]) &&
                        !DBUtil.IsEmpty(row["BgSpezkontoID"]) &&
                        (int)qryBgPosition["BgSpezkontoID"] == (int)row["BgSpezkontoID"])
                    {
                        if (DBUtil.IsEmpty(row["BgPositionID"]) || (qryBgPosition.Row == row))
                        {
                            //neu erfasste Position oder aktuelle Position
                            total += Convert.ToDecimal(row["Betrag"]);
                            anzahl++;
                        }
                        else if (Convert.ToDecimal(row["Betrag"]) != Convert.ToDecimal(row["BetragOld"]))
                        {
                            //Position mit Betragsmutation
                            total += Convert.ToDecimal(row["Betrag"]) - Convert.ToDecimal(row["BetragOld"]);
                            anzahl++;
                        }
                    }
                }

                //reicht Saldo?
                var saldo = Convert.ToDecimal(GetFieldFromSpezkonto(qryBgPosition["BgSpezkontoID"], "Saldo"));
                if (total > saldo)
                {
                    edtBetrag.Focus();
                    if (anzahl > 1)
                    {
                        throw new KissInfoException(string.Format("Die Summe der neu erfassten oder mutierten Beträge (CHF {0:0.00}) mit diesem Spezialkonto übersteigt den verfügbaren Saldo (CHF {1:0.00}).", total, saldo));
                    }

                    throw new KissInfoException(string.Format("Die Einzelzahlung kann nicht von diesem Spezialkonto abgebucht werden, da die Deckung des Spezialkontos (CHF {0:0.00}) nicht ausreicht.", saldo));
                }
            }

            //Zusätzliche Leistung: Gibt es ein Ausgabekonto mit genügend Deckung?
            //Nur Prüfen, wenn Neuerfassung oder Leistungsart mutiert
            if (kategorie == 100 && (qryBgPosition.Row.RowState == DataRowState.Added || qryBgPosition.ColumnModified("BgPositionsArtID")))
            {
                var qry = DBUtil.OpenSQL(@"
                    SELECT SPK.*,
                           Saldo = dbo.fnBgSpezkonto(SPK.BgSpezkontoID, 3, {5}, null)
                    FROM   BgSpezkonto SPK
                           INNER JOIN XLOVCode        TYP ON TYP.LOVName = 'BgSpezkontoTyp' and TYP.Code = SPK.BgSpezkontoTypCode
                           LEFT  JOIN BgPositionsart  BPA ON BPA.BgPositionsartID = SPK.BgPositionsartID
                           LEFT  JOIN BgPositionsart  GBL ON GBL.BgPositionsartID = {4}
                           LEFT  JOIN BgKostenart     BKA ON BKA.BgKostenartID = ISNULL(SPK.BgKostenartID, GBL.BgKostenartID)
                    WHERE  SPK.FaLeistungID = {0} AND
                           SPK.BgSpezkontoTypCode = 1 AND
                           BKA.KontoNr = {1} AND
                           (BKA.Quoting = 1 OR SPK.BaPersonID = {2} OR SPK.BaPersonID IS NULL) AND
                           dbo.fnBgSpezkonto(SPK.BgSpezkontoID, 3, {5}, null) >= {3}",
                qryBgBudget["FaLeistungID"],
                qryBgPosition["KOA"],
                qryBgPosition["BaPersonID"],
                qryBgPosition["Betrag"],
                qryBgBudget["WhGrundbedarfTypCode"],
                qryBgPosition["BgBudgetID"]);

                if (qry.Count > 0 && KissMsg.ShowQuestion(
                                    "Es gibt mindestens ein Ausgabekonto mit genügend Deckung für diese Zusätzliche Leistung: " +
                                    "Soll diese Position zu einer Einzelzahlung umgewandelt werden?"))
                {
                    qryBgPosition["BgKategorieCode"] = 101;
                    qryBgPosition["BgPositionsartID"] = null;
                    qryBgPosition["Kostenart"] = null;
                    qryBgPosition["KOA"] = null;
                    qryBgPosition["ProPerson"] = false;
                    qryBgPosition["ProUE"] = true;
                    LoadSpezialkonto(null, qryBgPosition["BaPersonID"]);
                    if (qry.Count == 1)
                    {
                        qryBgPosition["BgSpezKontoID"] = qry["BgSpezKontoID"];
                        qryBgPosition["SpezKonto"] = GetFieldFromSpezkonto(qryBgPosition["BgSpezkontoID"], "Text").ToString();
                        SetSpezialkonto();
                    }
                    SetEditMode();
                    throw new KissCancelException();
                }
            }

            ctlErfassungMutation1.SetFields();

            UpdateSum();
            _dataModified = true;

            qryBgPosition.RowModified = false;
            qryBgPosition.Row.AcceptChanges();
        }

        private void qryBgPosition_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (qryBgPosition.IsFilling)
            {
                return;
            }

            if (e.Column.ColumnName == "Betrag")
            {
                UpdateSum();
            }

            if (e.Column.ColumnName == "KOA")
            {
                UpdateLetzte10Buchungen();
            }
        }

        private void qryBgPosition_PositionChanged(object sender, EventArgs e)
        {
            if ((int)qryBgPosition["BgKategorieCode"] == 101)
            {
                LoadSpezialkonto(null, qryBgPosition["BaPersonID"]);
            }

            _buchungstext.LoadBuchungstext(qryBgPosition["BgPositionsartID"] as int?, false);
            UpdateLetzte10Buchungen();
            SetEditMode();
            ctlErfassungMutation1.ShowInfo();
        }

        private void SetEditMode()
        {
            if (_readOnly) return;

            var kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);
            var bgSplittingArtCode = ShUtil.GetCode(qryBgPosition["BgSplittingArtCode"]);

            //Verwendungsperiode + Splitting
            switch (bgSplittingArtCode)
            {
                case 1: //Taggenau
                case 2: //monat
                    edtVerwPeriodeVon.EditMode = EditModeType.Normal;
                    edtVerwPeriodeBis.EditMode = EditModeType.Normal;
                    break;

                case 4: //Entscheid
                    edtVerwPeriodeVon.EditMode = EditModeType.Normal;
                    edtVerwPeriodeBis.EditMode = EditModeType.ReadOnly;
                    break;

                default:
                    edtVerwPeriodeVon.EditMode = EditModeType.ReadOnly;
                    edtVerwPeriodeBis.EditMode = EditModeType.ReadOnly;
                    break;
            }

            edtKostenart.EditMode = (kategorie == 100) ? EditModeType.Normal : EditModeType.ReadOnly;

            if (!DBUtil.IsEmpty(qryBgPosition["Quoting"]))
            {
                if ((bool)qryBgPosition["Quoting"])
                {
                    edtBaPersonID.EditValue = null;
                    edtBaPersonID.EditMode = EditModeType.ReadOnly;
                }
                else
                {
                    edtBaPersonID.EditMode = EditModeType.Normal;
                }
            }
            else
            {
                edtBaPersonID.EditValue = null;
                edtBaPersonID.EditMode = EditModeType.ReadOnly;
            }
        }

        private void SetSpezialkonto()
        {
            object bgSpezKontoID = qryBgPosition["BgSpezKontoID"];

            var kategorie = (int)qryBgPosition["BgKategorieCode"];
            if (kategorie == 101)  //Einzelzahlung
            {
                qryBgPosition["BgPositionsartID"] = GetFieldFromSpezkonto(bgSpezKontoID, "BgPositionsartID");
                qryBgPosition["KOA"] = GetFieldFromSpezkonto(bgSpezKontoID, "KOA");
                qryBgPosition["Kostenart"] = GetFieldFromSpezkonto(bgSpezKontoID, "KOAPositionsart");
                qryBgPosition["Buchungstext"] = GetFieldFromSpezkonto(bgSpezKontoID, "Text");
                qryBgPosition["BgSplittingArtCode"] = GetFieldFromSpezkonto(bgSpezKontoID, "BgSplittingArtCode");
                qryBgPosition["ProPerson"] = GetFieldFromSpezkonto(bgSpezKontoID, "ProPerson");
                qryBgPosition["ProUE"] = GetFieldFromSpezkonto(bgSpezKontoID, "ProUE");
                qryBgPosition["Quoting"] = GetFieldFromSpezkonto(bgSpezKontoID, "Quoting");
                SetVerwendungsPeriode();

                object baPersonID = GetFieldFromSpezkonto(bgSpezKontoID, "BaPersonID");
                if (!DBUtil.IsEmpty(baPersonID))
                {
                    qryBgPosition["BaPersonID"] = baPersonID;
                }

                var bgPositionsartID = qryBgPosition["BgPositionsartID"] as int?;
                var kostenartID = GetFieldFromSpezkonto(bgSpezKontoID, "BgKostenartID") as int?;
                _buchungstext.LoadBuchungstextForSpezkonto(bgPositionsartID, kostenartID);
            }

            qryBgPosition.RefreshDisplay();
        }

        private void SetVerwendungsPeriode()
        {
            try
            {
                var bgSplittingArtCode = ShUtil.GetCode(qryBgPosition["BgSplittingArtCode"]);
                switch (bgSplittingArtCode)
                {
                    case 1: //Taggenau
                    case 2: //Monat
                        var firstDate = new DateTime((int)qryBgBudget["Jahr"], (int)qryBgBudget["Monat"], 1);
                        qryBgPosition["VerwPeriodeVon"] = firstDate;
                        qryBgPosition["VerwPeriodeBis"] = firstDate.AddMonths(1).AddDays(-1);
                        break;

                    case 3: //Valuta
                    case 4: //Entscheid
                        qryBgPosition["VerwPeriodeVon"] = DBNull.Value;
                        qryBgPosition["VerwPeriodeBis"] = DBNull.Value;
                        break;
                }
            }
            catch { }
        }

        private void UpdateLetzte10Buchungen()
        {
            Task.Factory.StartNew(
                () =>
                {
                    var kostenart = DBUtil.IsEmpty(qryBgPosition["KOA"]) ? 0 : Convert.ToInt32(qryBgPosition["KOA"]);
                    var klientId = _klientID == 0 ? Utils.ConvertToInt(qryBgPosition["KlientID"]) : _klientID;
                    qryLetzte10Buchungen.Fill(kostenart, klientId);
                });
        }

        private void UpdateSum()
        {
            var summe = decimal.Zero;
            foreach (DataRow row in qryBgPosition.DataTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    var einzelBetrag = row["Betrag"] as decimal?;
                    if (einzelBetrag.HasValue)
                    {
                        if (einzelBetrag.Value < 0m)
                        {
                            row["Betrag"] = 0m;
                            einzelBetrag = 0m;
                        }
                        summe += einzelBetrag.Value;
                    }
                }
            }
            edtTotalbetragNeu.EditValue = summe;
            edtDifferenz.EditValue = _totalbetrag - summe;

            edtDifferenz.BackColor = _totalbetrag == summe ? Color.DarkSeaGreen : Color.Salmon;
        }
    }
}