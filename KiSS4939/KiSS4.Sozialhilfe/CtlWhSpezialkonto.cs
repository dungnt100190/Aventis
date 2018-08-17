using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors.Controls;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe
{
    public partial class CtlWhSpezialkonto : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string SPK_DATUM_BIS_JAHR = "DatumBisJahr";
        private const string SPK_DATUM_BIS_MONAT = "DatumBisMonat";
        private const string SPK_DATUM_VON_JAHR = "DatumVonJahr";
        private const string SPK_DATUM_VON_MONAT = "DatumVonMonat";
        private const string SPK_INSTITUTION_NAME = "InstitutionName";
        private const string SPK_SALDO = "Saldo";
        private readonly BgSpezkontoTyp _bgSpezkontoTypCode = 0;
        private readonly bool _canUpdate;
        private readonly bool _dialogMode;
        private readonly int _faLeistungID;
        private readonly object _initBelastung;
        private readonly object _initName;
        private readonly object _initStartSaldo;

        #endregion

        #region Private Fields

        private readonly decimal _maxSanktion = DBUtil.GetConfigDecimal(@"System\Sozialhilfe\KuerzungMaxProzentsatz", 30);

        private decimal _saldo;

        #endregion

        #endregion

        #region Constructors

        // Used in CtlShEinzelzahlung to display in a DlgKissUsercontrol
        public CtlWhSpezialkonto(BgSpezkontoTyp bgSpezkontoTypCode, int faLeistung, object initName, object initStartSaldo, object initBelastung)
            : this(null, string.Empty, bgSpezkontoTypCode, faLeistung)
        {
            _dialogMode = true;
            _initName = initName;
            _initStartSaldo = initStartSaldo;
            _initBelastung = initBelastung;

            if (bgSpezkontoTypCode != BgSpezkontoTyp.Kuerzungen)
            {
                edtAktiv.Checked = true;
            }
        }

        public CtlWhSpezialkonto(Image titelImage, string titelText, BgSpezkontoTyp bgSpezkontoTypCode, int faLeistung)
            : this()
        {
            picTitel.Image = titelImage;
            _bgSpezkontoTypCode = bgSpezkontoTypCode;
            _faLeistungID = faLeistung;

            // Kostenarten
            qryBgKostenart.Fill(faLeistung, (int)bgSpezkontoTypCode);
            edtBgKostenartID.LoadQuery(qryBgKostenart, DBO.BgKostenart.BgKostenartID, "NrName");

            lblTitel.Text = titelText;

            if (bgSpezkontoTypCode != BgSpezkontoTyp.Kuerzungen)
            {
                edtAktiv.Checked = true;
            }

            SqlQuery qryBewilligungstatus = DBUtil.OpenSQL(@"
                SELECT Code = 1, Text = 'In Vorbereitung'
                UNION
                SELECT Code = 5, Text = 'freigegeben'
                UNION
                SELECT Code = 9, Text = 'aufgehoben'");

            colKuerzungStatus.ColumnEdit = grdBgSpezkonto.GetLOVLookUpEdit(qryBewilligungstatus);

            colAbschlussgrund.ColumnEdit = grdBgSpezkonto.GetLOVLookUpEdit("AbzahlungskontoAbschlussgrund");
        }

        public CtlWhSpezialkonto()
        {
            InitializeComponent();

            // save user right
            _canUpdate = qryBgSpezkonto.CanUpdate;
        }

        #endregion

        #region EventHandlers

        private void btnAbschliessen_Click(object sender, EventArgs e)
        {
            try
            {
                CheckNotNullFieldsAbschliessen();
                AbzahlungskontoAbschliessen((decimal)qryBgSpezkonto[SPK_SALDO]);
                qryBgSpezkonto.Refresh();
            }
            catch (KissInfoException ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message, ex);
            }
        }

        private void btnAbschliessen_Enter(object sender, EventArgs e)
        {
            SetEditModeAbschliessenFeld(EditModeType.Required);
        }

        private void btnAbschliessen_Leave(object sender, EventArgs e)
        {
            SetEditModeAbschliessenFeld(EditModeType.Normal);
        }

        private void btnAbschliessen_MouseEnter(object sender, EventArgs e)
        {
            SetEditModeAbschliessenFeld(EditModeType.Required);
        }

        private void btnAbschliessen_MouseLeave(object sender, EventArgs e)
        {
            SetEditModeAbschliessenFeld(EditModeType.Normal);
        }

        private void btnAbschliessenUndo_Click(object sender, EventArgs e)
        {
            Session.BeginTransaction();
            try
            {
                qryBgSpezkonto.CanUpdate = _canUpdate;
                if ((int)qryBgSpezkonto[DBO.BgSpezkonto.AbschlussgrundCode] == (int)LOV.AbzahlungskontoAbschlussgrund.UebergabeAnInkasso)
                {
                    // Position für Übergabe an Inkasso löschen
                    DBUtil.ExecSQLThrowingException(
                        @"DELETE dbo.BgSpezkontoAbschluss WHERE BgSpezkontoID = {0}",
                        qryBgSpezkonto[DBO.BgSpezkonto.BgSpezkontoID]);
                }

                qryBgSpezkonto[DBO.BgSpezkonto.AbschlussgrundCode] = DBNull.Value;
                qryBgSpezkonto[DBO.BgSpezkonto.AbschlussBegruendung] = DBNull.Value;
                qryBgSpezkonto[DBO.BgSpezkonto.AbzahlungskontoRueckerstattungCode] = DBNull.Value;

                qryBgSpezkonto.Post();

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                throw new KissCancelException();
            }
            finally
            {
                qryBgSpezkonto.Refresh();
            }
        }

        private void btnKuerzungAufheben_Click(object sender, EventArgs e)
        {
            qryBgSpezkonto[DBO.BgSpezkonto.Inaktiv] = 1;
            qryBgSpezkonto.Post();
        }

        private void btnKuerzungFreigeben_Click(object sender, EventArgs e)
        {
            qryBgSpezkonto[DBO.BgSpezkonto.Inaktiv] = 0;
            qryBgSpezkonto.Post();
        }

        private void btnKuerzungGrau_Click(object sender, EventArgs e)
        {
            qryBgSpezkonto[DBO.BgSpezkonto.Inaktiv] = 1;
            qryBgSpezkonto.Post();
        }

        private void CtlWhSpezialkonto_Load(object sender, EventArgs e)
        {
            //rename/resize/enable Fields,GridColumns,Labels
            switch (_bgSpezkontoTypCode)
            {
                case BgSpezkontoTyp.Ausgabekonto:
                    lblStartSaldo.Visible = false;
                    edtStartSaldo.Visible = false;
                    lblBetragProMonat.Visible = false;
                    edtBetragProMonat.Visible = false;
                    lblCHF2.Visible = false;
                    lblCHF1.Visible = false;

                    panBgPositionsartID.Visible = false;
                    panBgKostenartID.Visible = true;
                    panBaInstitutionID.Visible = true;
                    panAbschliessen.Visible = false;

                    edtOhneEinzelzahlung.Visible = false;
                    colNameSpezkonto.Width += 50;
                    colStartSaldo.Visible = false;
                    colKuerzungAnteilGBL.Visible = false;
                    colKuerzungLaufzeit.Visible = false;
                    colKuerzungStatus.Visible = false;

                    colGesperrt.Visible = false;
                    break;

                case BgSpezkontoTyp.Vorabzugkonto:
                    lblStartSaldo.Visible = true;
                    edtStartSaldo.Visible = true;
                    lblCHF1.Visible = true;

                    panBgPositionsartID.Visible = false;
                    panBgKostenartID.Visible = false;
                    panBaInstitutionID.Visible = false;
                    panAbschliessen.Visible = false;

                    edtOhneEinzelzahlung.Visible = false;
                    colStartSaldo.Visible = false;
                    colKuerzungAnteilGBL.Visible = false;
                    colKuerzungLaufzeit.Visible = false;
                    colKuerzungStatus.Visible = false;

                    colGesperrt.Visible = false;
                    break;

                case BgSpezkontoTyp.Abzahlungskonto:
                    panBgPositionsartID.Visible = true;
                    panBgKostenartID.Visible = true;
                    panBaInstitutionID.Visible = false;
                    panAbschliessen.Visible = DBUtil.GetConfigBool(@"System\Sozialhilfe\AbschliessenMitUebergabeAnInkasso", false);

                    lblStartSaldo.Text = "Abzuzahlender Betrag";
                    colStartSaldo.Caption = "Abzahlbetrag";
                    colKuerzungAnteilGBL.Visible = false;
                    colKuerzungLaufzeit.Visible = false;
                    colKuerzungStatus.Visible = false;

                    colGesperrt.Visible = false;
                    break;

                case BgSpezkontoTyp.Kuerzungen:
                    panBgPositionsartID.Visible = false;
                    panBgKostenartID.Visible = false;
                    panBaInstitutionID.Visible = false;
                    edtOhneEinzelzahlung.Visible = false;
                    panAbschliessen.Visible = false;
                    lblCHF1.Text = "%";
                    lblCHF2.Text = "Monat(e)";

                    edtKuerzungLaufzeit.Left = edtBetragProMonat.Left;
                    edtKuerzungLaufzeit.Top = edtBetragProMonat.Top;
                    edtKuerzungLaufzeit.Visible = true;
                    edtBetragProMonat.Visible = false;

                    edtKuerzungAnteilGBL.Left = edtStartSaldo.Left;
                    edtKuerzungAnteilGBL.Top = edtStartSaldo.Top;
                    edtKuerzungAnteilGBL.Visible = true;
                    edtStartSaldo.Visible = false;

                    lblStartSaldo.Text = "Anteil vom GB";
                    lblBetragProMonat.Text = "Laufzeit";

                    edtDatumBisMonat.EditMode = EditModeType.ReadOnly;
                    edtDatumBisJahr.EditMode = EditModeType.ReadOnly;

                    colStartSaldo.Visible = false;
                    colBetragProMonat.Visible = false;
                    colSaldo.Visible = false;
                    SetEditModeKuerzungen();

                    colGesperrt.VisibleIndex = 6;
                    break;
            }

            // Positionsarten
            edtBgPositionsartID.LoadQuery(
                DBUtil.OpenSQL(@"
                    SELECT POA.BgPositionsartID,
                           Text = IsNull(KOA.KontoNr, '') + ' ' + POA.Name
                    FROM dbo.WhPositionsart POA
                    LEFT JOIN dbo.WhKostenart KOA ON KOA.BgKostenartID = POA.BgKostenartID
                    WHERE BgKategorieCode = 3
                    ORDER BY SortKey"),
                DBO.WhPositionsart.BgPositionsartID,
                "Text");

            // Monate
            SqlQuery qry = DBUtil.GetLOVQuery("Monat", true);

            edtDatumVonMonat.LoadQuery(qry, "Code", "ShortText");
            edtDatumBisMonat.LoadQuery(qry, "Code", "ShortText");

            RefreshDisplay();

            if (_dialogMode)
            {
                qryBgSpezkonto.Insert();
                qryBgSpezkonto[DBO.BgSpezkonto.NameSpezkonto] = _initName;
                qryBgSpezkonto[DBO.BgSpezkonto.StartSaldo] = _initStartSaldo;
                qryBgSpezkonto[DBO.BgSpezkonto.BetragProMonat] = _initBelastung;
                qryBgSpezkonto[DBO.BgSpezkonto.OhneEinzelzahlung] = false;
            }

            qryBaPerson.Fill(_faLeistungID);
            edtBaPersonID.LoadQuery(qryBaPerson, "BaPersonID", "NameVorname");
        }

        private void editAktiv_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDisplay();
            DisplayBewegungen();
            SetEditModeKuerzungen();
        }

        private void editAktiv_EditValueChanging(object sender, ChangingEventArgs e)
        {
            e.Cancel = !qryBgSpezkonto.Post();
        }

        private void edtInstitution_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtInstitution.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgSpezkonto[DBO.BgSpezkonto.BaInstitutionID] = DBNull.Value;
                    qryBgSpezkonto[SPK_INSTITUTION_NAME] = DBNull.Value;
                    return;
                }
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.InstitutionSuchenWh(searchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryBgPosition[DBO.BgPosition.BaInstitutionID] = dlg["ID$"];
                qryBgPosition[SPK_INSTITUTION_NAME] = dlg["Institution"];
            }
        }

        private void grvBgPosition_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            if (e.Item == colSaldo2.SummaryItem && e.SummaryProcess == CustomSummaryProcess.Finalize)
            {
                e.TotalValue = _saldo;
            }
        }

        private void qryBgPosition_BeforePost(object sender, EventArgs e)
        {
            qryBgPosition.Row.AcceptChanges();
            qryBgPosition.RowModified = false;
        }

        private void qryBgSpezkonto_AfterDelete(object sender, EventArgs e)
        {
            try
            {
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }

            if (qryBgSpezkonto.Count == 0)
            {
                DisplayBewegungen();
            }
        }

        private void qryBgSpezkonto_AfterInsert(object sender, EventArgs e)
        {
            qryBgSpezkonto[DBO.BgSpezkonto.FaLeistungID] = _faLeistungID;
            qryBgSpezkonto[DBO.BgSpezkonto.BgSpezkontoTypCode] = (int)_bgSpezkontoTypCode;

            switch (_bgSpezkontoTypCode)
            {
                case BgSpezkontoTyp.Ausgabekonto:
                    //		qryBgSpezkonto["BgKostenartID"] = 1;
                    break;

                case BgSpezkontoTyp.Vorabzugkonto:
                    qryBgSpezkonto[DBO.BgSpezkonto.StartSaldo] = 0;
                    qryBgSpezkonto[DBO.BgSpezkonto.BetragProMonat] = 100;
                    break;

                case BgSpezkontoTyp.Abzahlungskonto:
                    qryBgSpezkonto[DBO.BgSpezkonto.OhneEinzelzahlung] = true;
                    qryBgSpezkonto[DBO.BgSpezkonto.StartSaldo] = 100;
                    qryBgSpezkonto[DBO.BgSpezkonto.BetragProMonat] = 100;
                    break;

                case BgSpezkontoTyp.Kuerzungen:
                    qryBgSpezkonto[DBO.BgSpezkonto.KuerzungAnteilGBL] = _maxSanktion;
                    qryBgSpezkonto[DBO.BgSpezkonto.KuerzungLaufzeitMonate] = 6;
                    break;
            }

            SqlQuery qryDatumVon = DBUtil.OpenSQL(@"
                SELECT DatumVon = MAX(DATEADD(m, 1, dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)))
                FROM dbo.BgFinanzplan     SFP
                  INNER JOIN dbo.BgBudget BBG ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
                WHERE SFP.FaLeistungID = {0}
                  AND SFP.BgBewilligungStatusCode = 5
                  AND BBG.MasterBudget = 0
                  AND BBG.BgBewilligungStatusCode >= 5",
                qryBgSpezkonto[DBO.BgSpezkonto.FaLeistungID]); //{0}: FaLeistungID

            if (qryDatumVon["DatumVon"] != DBNull.Value)
            {
                qryBgSpezkonto[SPK_DATUM_VON_JAHR] = ((DateTime)qryDatumVon["DatumVon"]).Year;
                qryBgSpezkonto[SPK_DATUM_VON_MONAT] = ((DateTime)qryDatumVon["DatumVon"]).Month;
                qryBgSpezkonto[DBO.BgSpezkonto.DatumVon] = null;
            }

            qryBgSpezkonto[SPK_SALDO] = qryBgSpezkonto[DBO.BgSpezkonto.StartSaldo];

            edtNameSpezkonto.Focus();
        }

        private void qryBgSpezkonto_AfterPost(object sender, EventArgs e)
        {
            switch (_bgSpezkontoTypCode)
            {
                case BgSpezkontoTyp.Vorabzugkonto:
                case BgSpezkontoTyp.Abzahlungskonto:
                case BgSpezkontoTyp.Kuerzungen:
                    DBUtil.ExecSQL(@"
                        EXECUTE dbo.spWhSpezkonto_UpdateBudget {0}",
                        qryBgSpezkonto[DBO.BgSpezkonto.BgSpezkontoID]);

                    qryBgSpezkonto_PositionChanged(this, EventArgs.Empty);
                    break;
            }

            // Gültig von/bis im Grid updaten
            qryBgSpezkonto.Row.AcceptChanges();
            qryBgSpezkonto.RowModified = false;
            qryBgSpezkonto.Refresh();
        }

        private void qryBgSpezkonto_BeforeDelete(object sender, EventArgs e)
        {
            Session.BeginTransaction();

            try
            {
                DBUtil.ExecSQLThrowingException(@"
                    DELETE BPO
                    FROM dbo.BgPosition       BPO
                      INNER JOIN dbo.BgBudget BBG ON BBG.BgBudgetID = BPO.BgBudgetID
                    WHERE BPO.BgSpezkontoID = {0}
                      AND BPO.BgKategorieCode IN (3, 6)
                      AND (BBG.MasterBudget = 1 OR BBG.BgBewilligungStatusCode < 5)",
                    qryBgSpezkonto[DBO.BgSpezkonto.BgSpezkontoID]);
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                throw new KissCancelException();
            }
        }

        private void qryBgSpezkonto_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            if (qryBgPosition.Count == 0)
            {
                return;
            }

            if (qryBgPosition.Count == 1)
            {
                Text = qryBgPosition.DataTable.Rows[0]["Buchungstext"].ToString();

                if (Text.ToUpper() == "STARTSALDO")
                {
                    return;
                }
            }

            throw new KissInfoException(
                KissMsg.GetMLMessage(
                    Name,
                    "BereitsGebucht",
                    "Auf dieses Konto wurde bereits gebucht, deshalb kann es nicht mehr gelöscht werden",
                    KissMsgCode.MsgInfo));
        }

        private void qryBgSpezkonto_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtDatumVonMonat, lblDatumVonMonat.Text);
            DBUtil.CheckNotNullField(edtDatumVonJahr, lblDatumVonMonat.Text);

            int datumVonJahr = (int)qryBgSpezkonto[SPK_DATUM_VON_JAHR];

            if (datumVonJahr < 2000 || datumVonJahr > 3000)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        Name,
                        "DatumVonJahrUngueltig",
                        "Bitte sinnvolles Jahr bei 'gültig von' eingeben",
                        KissMsgCode.MsgInfo),
                    edtDatumVonJahr);
            }

            qryBgSpezkonto[DBO.BgSpezkonto.DatumVon] = new DateTime(datumVonJahr, (int)qryBgSpezkonto[SPK_DATUM_VON_MONAT], 1);

            if (!DBUtil.IsEmpty(qryBgSpezkonto[SPK_DATUM_BIS_JAHR]) && !DBUtil.IsEmpty(qryBgSpezkonto[SPK_DATUM_BIS_MONAT]))
            {
                int datumBisJahr = (int)qryBgSpezkonto[SPK_DATUM_BIS_JAHR];

                if (datumBisJahr < 2000 || datumBisJahr > 3000)
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            Name,
                            "DatumBisJahrUngueltig",
                            "Bitte sinnvolles Jahr bei 'gültig bis' eingeben",
                            KissMsgCode.MsgInfo),
                        edtDatumVonJahr);
                }

                DateTime d = new DateTime(datumBisJahr, (int)qryBgSpezkonto[SPK_DATUM_BIS_MONAT], 1);
                qryBgSpezkonto[DBO.BgSpezkonto.DatumBis] = d.AddMonths(1).AddDays(-1);
                // Wenn bereits Buchungen vorhanden sind, darf das Datum-bis nicht früher als die letzte Buchung sein.
                if (qryBgPosition.DataTable.Select("Verbucht = 1 OR Gesperrt = 1").Length > 0)
                {
                    DateTime datumLetzteBuchung = (DateTime)qryBgPosition.DataTable.Select("Verbucht = 1 OR Gesperrt = 1", "Datum DESC").First()["Datum"];

                    if ((DateTime)qryBgSpezkonto[DBO.BgSpezkonto.DatumBis] < datumLetzteBuchung)
                    {
                        throw new KissInfoException(
                            KissMsg.GetMLMessage(
                                Name,
                                "DatumBisJahrZuKlein",
                                "Das Datum 'gültig bis' ist zu klein. Es gibt bereits Monate die später verbucht sind.",
                                KissMsgCode.MsgInfo),
                            edtDatumBisMonat);
                    }
                }
            }
            else
            {
                qryBgSpezkonto[DBO.BgSpezkonto.DatumBis] = DBNull.Value;
            }

            //Ticket 552: Begrenzung von höchstens 12 monaten für die abzahlung
            //Ticket 2598: Begrenzung doch wieder weg!
            /*
            if((int)qryBgSpezkonto["BgSpezKontoTypCode"] == 3)
            {
                DateTime von = (DateTime)qryBgSpezkonto["DatumVon"];
                DateTime bis = (DateTime)qryBgSpezkonto["DatumBis"];
                TimeSpan diff = bis.Subtract(von);
                if(diff.Days > 365)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name, "ZeitspanneUeberschritten", "Die Begrenzung des Abzahlungskonto darf 12 Monate nicht überschreiten. Bitte korrigieren Sie den monatlichen Betrag.", KissMsgCode.MsgInfo), edtBetragProMonat);
                }
            }
            */

            //Betrifft Person
            SqlQuery qryBgPosArt = DBUtil.OpenSQL(@"
                SELECT ProPerson, ProUE
                FROM dbo.BgPositionsart
                WHERE BgPositionsartID = {0}",
                qryBgSpezkonto[DBO.BgSpezkonto.BgPositionsartID]);

            if (!DBUtil.IsEmpty(qryBgPosArt[DBO.BgPositionsart.ProPerson]) && !DBUtil.IsEmpty(qryBgPosArt[DBO.BgPositionsart.ProUE]))
            {
                var proPerson = (bool)qryBgPosArt[DBO.BgPositionsart.ProPerson];
                var proUe = (bool)qryBgPosArt[DBO.BgPositionsart.ProUE];

                if (proPerson && !proUe && DBUtil.IsEmpty(qryBgSpezkonto[DBO.BgSpezkonto.BaPersonID]))
                {
                    throw new KissInfoException("Das Feld 'Person' darf nicht leer bleiben für diese Kostenart/Positionsart!", edtBaPersonID);
                }
            }

            if (!DBUtil.IsEmpty(qryBgSpezkonto[DBO.BgSpezkonto.DatumBis]) &&
                ((DateTime)qryBgSpezkonto[DBO.BgSpezkonto.DatumVon]) > ((DateTime)qryBgSpezkonto[DBO.BgSpezkonto.DatumBis]))
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        Name,
                        "DatBisVorDatVon",
                        "'gültig bis' darf nicht vor 'gültig von' sein.",
                        KissMsgCode.MsgInfo),
                    edtDatumVonMonat);
            }

            if (qryBgSpezkonto.Row.RowState != DataRowState.Added && qryBgSpezkonto.ColumnModified(DBO.BgSpezkonto.StartSaldo))
            {
                decimal saldo = (decimal)qryBgSpezkonto[SPK_SALDO, DataRowVersion.Original]
                                - (decimal)qryBgSpezkonto[DBO.BgSpezkonto.StartSaldo, DataRowVersion.Original]
                                + (decimal)qryBgSpezkonto[DBO.BgSpezkonto.StartSaldo];

                if (saldo < 0)
                {
                    saldo = (decimal)qryBgSpezkonto[DBO.BgSpezkonto.StartSaldo] - saldo;
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            Name,
                            "MinStartsaldo",
                            "Der Startsaldo muss mindestens Fr. {0:n2} betragen",
                            KissMsgCode.MsgInfo,
                            saldo),
                        edtStartSaldo);
                }

                qryBgSpezkonto[SPK_SALDO] = saldo;
            }

            object o;

            switch (_bgSpezkontoTypCode)
            {
                case BgSpezkontoTyp.Vorabzugkonto:
                    DBUtil.CheckNotNullField(edtBetragProMonat, lblBetragProMonat.Text);

                    if (qryBgSpezkonto.ColumnModified(DBO.BgSpezkonto.StartSaldo))
                    {
                        o = DBUtil.GetUserPermission(Permission.Sh_StartsaldoVorabzugskonto, _faLeistungID, null);

                        if (null == o)
                        {
                            throw new KissInfoException(
                                KissMsg.GetMLMessage(
                                    Name,
                                    "KompetenzNichtEingerichtet",
                                    "Die Kompetenz 'Sozialhilfe: Monatsbudget - max. Startsaldo eines Vorabzugskontos' muss zuerst für Sie eingerichtet werden.",
                                    KissMsgCode.MsgInfo));
                        }

                        decimal maxStartSaldo = Convert.ToDecimal(o);

                        if (edtStartSaldo.Value > maxStartSaldo)
                        {
                            throw new KissInfoException(
                                KissMsg.GetMLMessage(
                                    Name,
                                    "KeineKompetenzStartsaldo",
                                    "Sie haben nicht die Kompetenz, einen Startsaldo von {0:n2} einzugeben.\r\nIhre Kompetenz liegt bei {1:n2}",
                                    KissMsgCode.MsgInfo,
                                    edtStartSaldo.Value,
                                    maxStartSaldo));
                        }
                    }

                    break;

                case BgSpezkontoTyp.Abzahlungskonto:
                    if (qryBgSpezkonto.ColumnModified(DBO.BgSpezkonto.OhneEinzelzahlung) &&
                        DBUtil.OpenSQL(@"SELECT TOP 1 1
                                         FROM dbo.BgPosition
                                         WHERE BgSpezkontoID = {0}
                                           AND BgKategorieCode = 101",
                            qryBgSpezkonto[DBO.BgSpezkonto.BgSpezkontoID]).Count > 0)
                    {
                        throw new KissInfoException(
                            KissMsg.GetMLMessage(
                                Name,
                                "EinzelzahlungExistiertBereits",
                                "Rückerstattung ohne Einzelzahlung darf nicht mehr verändert werden.\r\nEs existiert bereits eine Einzelzahlung auf diesem Konto",
                                KissMsgCode.MsgInfo));
                    }

                    DBUtil.CheckNotNullField(edtBetragProMonat, lblBetragProMonat.Text);

                    if (qryBgSpezkonto.Row.RowState == DataRowState.Added)
                    {
                        o = DBUtil.ExecuteScalarSQL(@"
                                SELECT MAX(DATEADD(m, 1, dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)))
                                FROM dbo.BgFinanzplan     SFP
                                  INNER JOIN dbo.BgBudget BBG ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
                                WHERE SFP.FaLeistungID = {0}
                                  AND SFP.BgBewilligungStatusCode = 5
                                  AND BBG.MasterBudget = 0
                                  AND BBG.BgBewilligungStatusCode >= 5
                                  AND dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1) >= dbo.fnFirstDayOf({1})",
                                _faLeistungID,
                                qryBgSpezkonto[DBO.BgSpezkonto.DatumVon]);

                        if (!DBUtil.IsEmpty(o))
                        {
                            throw new KissInfoException(
                                KissMsg.GetMLMessage(
                                    Name,
                                    "MonatsbudgetGesperrt",
                                    "'gültig von' ist nicht zulässig, da freigegebene oder gesperrte Monatsbudgets in diesem oder späteren Monat vorhanden sind.",
                                    KissMsgCode.MsgInfo),
                                edtDatumVonMonat);
                        }

                        o = DBUtil.ExecuteScalarSQL(@"
                                SELECT Count(1)
                                FROM dbo.BgFinanzplan       SFP
                                  INNER JOIN dbo.BgBudget   BBG ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
                                  INNER JOIN dbo.BgPosition BPO ON BPO.BgBudgetID = BBG.BgBudgetID
                                                               AND BPO.BgSpezkontoID = {2}
                                WHERE SFP.FaLeistungID = {0}
                                  AND SFP.BgBewilligungStatusCode = 5
                                  AND BBG.MasterBudget = 0
                                  AND BBG.BgBewilligungStatusCode >= 5
                                  AND dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1) < dbo.fnFirstDayOf({1})",
                                _faLeistungID,
                                qryBgSpezkonto[DBO.BgSpezkonto.DatumVon],
                                qryBgSpezkonto[DBO.BgSpezkonto.BgSpezkontoID]);

                        if ((int)o > 0)
                        {
                            throw new KissInfoException(
                                KissMsg.GetMLMessage(
                                    Name,
                                    "AbzahlungGemacht",
                                    "'gültig von' ist nicht zulässig. Es sind {0} Abzahlungen vor diesem Monat gemacht worden",
                                    KissMsgCode.MsgInfo,
                                    o),
                                edtDatumVonMonat);
                        }
                    }

                    if (Convert.ToDecimal(colBetragBelastung.SummaryItem.SummaryValue) > Convert.ToDecimal(qryBgSpezkonto[DBO.BgSpezkonto.StartSaldo]))
                    {
                        throw new KissInfoException(
                            KissMsg.GetMLMessage(
                                Name,
                                "SummeEinzUebersteigtAbzahlungsziel",
                                "Die Summe aller Einzelzahlungen ({0:n2}) übersteigt das Abzahlungsziel ({1:n2}))",
                                KissMsgCode.MsgInfo,
                                colBetragBelastung.SummaryItem.SummaryValue,
                                qryBgSpezkonto[DBO.BgSpezkonto.StartSaldo]),
                            edtStartSaldo);
                    }

                    if (Convert.ToDecimal(colBetragGutschrift.SummaryItem.SummaryValue) >
                        Convert.ToDecimal(qryBgSpezkonto[DBO.BgSpezkonto.StartSaldo]))
                    {
                        throw new KissInfoException(
                            KissMsg.GetMLMessage(
                                Name,
                                "SummeAbzUebersteigtAbzahlungsziel",
                                "Die Summe aller Abzahlungen ({0:n2}) übersteigt das Abzahlungsziel ({1:n2}))",
                                KissMsgCode.MsgInfo,
                                colBetragGutschrift.SummaryItem.SummaryValue,
                                qryBgSpezkonto[DBO.BgSpezkonto.StartSaldo]),
                            edtStartSaldo);
                    }

                    if (DBUtil.IsEmpty(qryBgSpezkonto[DBO.BgSpezkonto.BetragProMonat]) ||
                        Convert.ToDecimal(qryBgSpezkonto[DBO.BgSpezkonto.BetragProMonat]) <= 0)
                    {
                        throw new KissInfoException(
                            KissMsg.GetMLMessage(
                                Name,
                                "BetragMonatGroesserNull",
                                "Der monatliche Betrag muss > 0.00 sein.",
                                KissMsgCode.MsgInfo),
                            edtBetragProMonat);
                    }

                    break;

                case BgSpezkontoTyp.Kuerzungen:
                    DBUtil.CheckNotNullField(edtBaPersonID, lblBaPersonID.Text);
                    DBUtil.CheckNotNullField(edtKuerzungAnteilGBL);
                    DBUtil.CheckNotNullField(edtKuerzungLaufzeit);

                    decimal anteilGBL = (decimal)qryBgSpezkonto[DBO.BgSpezkonto.KuerzungAnteilGBL];
                    int laufzeitMonate = (int)qryBgSpezkonto[DBO.BgSpezkonto.KuerzungLaufzeitMonate];

                    if (anteilGBL <= 0m || anteilGBL > _maxSanktion)
                    {
                        throw new KissInfoException(
                            KissMsg.GetMLMessage(
                                Name,
                                "KuerzungAnteilBereichFalsch",
                                "Der Anteil am GB muss zwischen 0% und {0:G29}% liegen", //das Format muss mit G29 angegeben werden, damit nicht standardmässig 4-Kommastellen angezeigt werden
                                KissMsgCode.MsgInfo, _maxSanktion));
                    }

                    if (laufzeitMonate < 1)
                    {
                        throw new KissInfoException(
                            KissMsg.GetMLMessage(
                                Name,
                                "KuerzungLaufzeitBereichFalsch",
                                "Die Laufzeit einer Kürzung muss länger als 0 Monate dauern",
                                KissMsgCode.MsgInfo));
                    }

                    IDictionary<int, IDictionary<DateTime, decimal>> monateMitZuvielKuerzungen = CheckKuerzungenTotal();

                    if (monateMitZuvielKuerzungen.Count > 0)
                    {
                        // Benutzerfreundlichen Text zusammenstellen
                        List<string> monate = new List<string>();

                        foreach (KeyValuePair<int, IDictionary<DateTime, decimal>> personMonate in monateMitZuvielKuerzungen)
                        {
                            int baPersonID = personMonate.Key;
                            string personName = baPersonID.ToString();
                            DataRow[] rows = qryBaPerson.DataTable.Select(string.Format("BaPersonID = {0}", baPersonID));

                            if (rows.Length > 0)
                            {
                                personName = rows[0]["NameVorname"] as string;
                            }

                            monate.AddRange(personMonate.Value.ToList().ConvertAll<string>(new Converter<KeyValuePair<DateTime, decimal>, string>(monat => string.Format("- {0}: {1:y}, {2:n0}%", personName, monat.Key, monat.Value))));
                        }

                        string monateString = string.Join(Environment.NewLine, monate.ToArray());
                        throw new KissInfoException(
                            KissMsg.GetMLMessage(
                                Name,
                                "ZuvielKuerzungen_V2",
                                "In folgenden Monaten wird mehr als die maximal erlaubten {2:G29}% vom GB gekürzt:{0}{1}", //das Format muss mit G29 angegeben werden, damit nicht standardmässig 4-Kommastellen angezeigt werden
                                KissMsgCode.MsgInfo,
                                Environment.NewLine,
                                monateString,
                                _maxSanktion));
                    }

                    break;
            }

            DBUtil.CheckNotNullField(edtNameSpezkonto, lblNameSpezkonto.Text);
            DBUtil.CheckNotNullField(edtStartSaldo, lblStartSaldo.Text);
        }

        private void qryBgSpezkonto_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (qryBgSpezkonto.IsFilling || qryBgSpezkonto.IsInserting)
            {
                return;
            }

            if (e.Column.ColumnName == DBO.BgSpezkonto.StartSaldo ||
                e.Column.ColumnName == DBO.BgSpezkonto.BetragProMonat ||
                e.Column.ColumnName == SPK_DATUM_VON_JAHR ||
                e.Column.ColumnName == SPK_DATUM_VON_MONAT ||
                e.Column.ColumnName == DBO.BgSpezkonto.KuerzungLaufzeitMonate)
            {
                CalcDatumBis();
            }
        }

        private void qryBgSpezkonto_PositionChanged(object sender, EventArgs e)
        {
            DisplayBewegungen();
            SetEditMode();

            if (qryBgSpezkonto.Row == null)
            {
                return;
            }

            if (!DBUtil.IsEmpty(qryBgSpezkonto[DBO.BgSpezkonto.DatumVon]))
            {
                qryBgSpezkonto[SPK_DATUM_VON_MONAT] = ((DateTime)qryBgSpezkonto[DBO.BgSpezkonto.DatumVon]).Month;
                qryBgSpezkonto[SPK_DATUM_VON_JAHR] = ((DateTime)qryBgSpezkonto[DBO.BgSpezkonto.DatumVon]).Year;
            }

            if (!DBUtil.IsEmpty(qryBgSpezkonto[DBO.BgSpezkonto.DatumBis]))
            {
                qryBgSpezkonto[SPK_DATUM_BIS_MONAT] = ((DateTime)qryBgSpezkonto[DBO.BgSpezkonto.DatumBis]).Month;
                qryBgSpezkonto[SPK_DATUM_BIS_JAHR] = ((DateTime)qryBgSpezkonto[DBO.BgSpezkonto.DatumBis]).Year;
            }

            if (qryBgSpezkonto.Row.RowState != DataRowState.Added)
            {
                qryBgSpezkonto.RowModified = false;
                qryBgSpezkonto.Row.AcceptChanges();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "NURAKTIVE":
                    return edtAktiv.Checked;
            }

            return base.GetContextValue(fieldName);
        }

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            bool baseResult = base.ReceiveMessage(parameters);

            // Checkbox nur Aktive deaktivieren wenn das Spezialkonto nicht aktiv ist
            if (parameters["BgSpezkontoID"] != null)
            {
                string idFilter = string.Format("{0} = {1}", DBO.BgSpezkonto.BgSpezkontoID, parameters["BgSpezkontoID"]);
                DataRow spezkonto = qryBgSpezkonto.DataTable.Select(idFilter).SingleOrDefault();

                // das Spezkonto ist inaktiv
                if (spezkonto == null)
                {
                    edtAktiv.Checked = !edtAktiv.Checked;
                    qryBgSpezkonto.Find(parameters["ActiveSQLQuery.Find"].ToString());
                }
            }

            return baseResult;
        }

        #endregion

        #region Private Methods

        private void AbzahlungskontoAbschliessen(decimal abschlussSaldo)
        {
            // show dialog
            DlgAbzahlungskontoAbschliessen dlg = new DlgAbzahlungskontoAbschliessen(abschlussSaldo);

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Session.BeginTransaction();
                try
                {
                    // Abschlussgrund vom Dialog übernehmen
                    qryBgSpezkonto[DBO.BgSpezkonto.AbschlussgrundCode] = (int)dlg.Abschlussgrund;

                    // Übergabe an Inkasso
                    if (dlg.Abschlussgrund == LOV.AbzahlungskontoAbschlussgrund.UebergabeAnInkasso)
                    {
                        UebergabeAnInkasso((int)qryBgSpezkonto[DBO.BgSpezkonto.BgSpezkontoID], dlg.Betrag);
                    }

                    qryBgSpezkonto.Post();

                    Session.Commit();
                }
                catch (Exception)
                {
                    Session.Rollback();
                    throw;
                }
            }
        }

        private void CalcDatumBis()
        {
            if (_bgSpezkontoTypCode != BgSpezkontoTyp.Abzahlungskonto && _bgSpezkontoTypCode != BgSpezkontoTyp.Kuerzungen)
            {
                return;
            }

            if (DBUtil.IsEmpty(qryBgSpezkonto[SPK_DATUM_VON_JAHR]) ||
                DBUtil.IsEmpty(qryBgSpezkonto[SPK_DATUM_VON_MONAT]) ||
                DBUtil.IsEmpty(qryBgSpezkonto[DBO.BgSpezkonto.StartSaldo]))
            {
                return;
            }

            if (_bgSpezkontoTypCode == BgSpezkontoTyp.Abzahlungskonto)
            {
                if (DBUtil.IsEmpty(qryBgSpezkonto[DBO.BgSpezkonto.BetragProMonat]) ||
                    Convert.ToDecimal(qryBgSpezkonto[DBO.BgSpezkonto.BetragProMonat]) <= 0m)
                {
                    return;
                }
            }
            else if (_bgSpezkontoTypCode != BgSpezkontoTyp.Kuerzungen)
            {
                if (DBUtil.IsEmpty(qryBgSpezkonto[DBO.BgSpezkonto.KuerzungLaufzeitMonate]))
                {
                    return;
                }
            }

            if (!(qryBgSpezkonto[DBO.BgSpezkonto.StartSaldo] is decimal) ||
                !(qryBgSpezkonto[DBO.BgSpezkonto.BetragProMonat] is decimal) && _bgSpezkontoTypCode == BgSpezkontoTyp.Abzahlungskonto ||
                !(qryBgSpezkonto[DBO.BgSpezkonto.KuerzungLaufzeitMonate] is int) && _bgSpezkontoTypCode == BgSpezkontoTyp.Kuerzungen ||
                !(qryBgSpezkonto[DBO.BgSpezkonto.BgSpezkontoID] is int))
            {
                qryBgSpezkonto[SPK_DATUM_BIS_MONAT] = DBNull.Value;
                qryBgSpezkonto[SPK_DATUM_BIS_JAHR] = DBNull.Value;
                qryBgSpezkonto[DBO.BgSpezkonto.DatumBis] = DBNull.Value;
            }
            else
            {
                object datumBis = DBUtil.ExecuteScalarSQL(@"
                    SELECT dbo.fnShGetSpezkontoEnddatum({0}, {1}, {2}, {3}, {4}, {5})",
                    qryBgSpezkonto[DBO.BgSpezkonto.BgSpezkontoID],
                    new DateTime((int)qryBgSpezkonto[SPK_DATUM_VON_JAHR], (int)qryBgSpezkonto[SPK_DATUM_VON_MONAT], 1),
                    qryBgSpezkonto[DBO.BgSpezkonto.StartSaldo],
                    qryBgSpezkonto[DBO.BgSpezkonto.BetragProMonat],
                    qryBgSpezkonto[DBO.BgSpezkonto.Inaktiv],
                    qryBgSpezkonto[DBO.BgSpezkonto.KuerzungLaufzeitMonate]);

                if (datumBis is DateTime)
                {
                    qryBgSpezkonto[SPK_DATUM_BIS_MONAT] = ((DateTime)datumBis).Month;
                    qryBgSpezkonto[SPK_DATUM_BIS_JAHR] = ((DateTime)datumBis).Year;
                }
                else
                {
                    qryBgSpezkonto[SPK_DATUM_BIS_MONAT] = DBNull.Value;
                    qryBgSpezkonto[SPK_DATUM_BIS_JAHR] = DBNull.Value;
                    qryBgSpezkonto[DBO.BgSpezkonto.DatumBis] = DBNull.Value;
                }
            }

            qryBgSpezkonto.RefreshDisplay();
        }

        private IDictionary<int, IDictionary<DateTime, decimal>> CheckKuerzungenTotal()
        {
            IDictionary<int, IDictionary<DateTime, decimal>> kuerzungenProMonatProPerson = new Dictionary<int, IDictionary<DateTime, decimal>>();
            IDictionary<DateTime, decimal> kuerzungenProMonat;

            foreach (DataRow spezkonto in qryBgSpezkonto.DataTable.Rows)
            {
                DateTime datumVon = (DateTime)spezkonto[DBO.BgSpezkonto.DatumVon];
                DateTime datumBis = spezkonto[DBO.BgSpezkonto.DatumBis] as DateTime? ?? datumVon.AddMonths((int)spezkonto[DBO.BgSpezkonto.KuerzungLaufzeitMonate]);
                DateTime monat = datumVon;
                int baPersonID = (int)spezkonto[DBO.BgSpezkonto.BaPersonID];
                bool inaktiv = (bool)spezkonto[DBO.BgSpezkonto.Inaktiv];
                SqlQuery qryPositionenVonInaktivemKonto = null;

                if (kuerzungenProMonatProPerson.ContainsKey(baPersonID))
                {
                    kuerzungenProMonat = kuerzungenProMonatProPerson[baPersonID];
                }
                else
                {
                    kuerzungenProMonat = new Dictionary<DateTime, decimal>();
                    kuerzungenProMonatProPerson[baPersonID] = kuerzungenProMonat;
                }

                if (inaktiv)
                {
                    qryPositionenVonInaktivemKonto =
                        DBUtil.OpenSQL(@"
                            SELECT Monat = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)
                            FROM dbo.vwBgPosition     BPO
                              INNER JOIN dbo.BgBudget BBG ON BBG.BgBudgetID = BPO.BgBudgetID
                                                         AND BBG.MasterBudget = 0
                            WHERE BPO.BgSpezkontoID = {0}
                              AND BBG.BgBewilligungStatusCode >= 5 -- grün oder gesperrt",
                            spezkonto[DBO.BgSpezkonto.BgSpezkontoID]);
                }

                while (monat <= datumBis)
                {
                    if (!inaktiv || qryPositionenVonInaktivemKonto.DataTable.Select(string.Format("Monat = '{0}'", monat)).Length > 0)
                    {
                        decimal anteilGBL = (decimal)spezkonto[DBO.BgSpezkonto.KuerzungAnteilGBL];

                        if (!kuerzungenProMonat.ContainsKey(monat))
                        {
                            kuerzungenProMonat[monat] = anteilGBL;
                        }
                        else
                        {
                            kuerzungenProMonat[monat] += anteilGBL;
                        }
                    }

                    monat = monat.AddMonths(1);
                }
            }

            // Bestimmen der Monate mit zu viel Kürzung
            IDictionary<int, IDictionary<DateTime, decimal>> personenMonateMitZuvielKuerzungen = new Dictionary<int, IDictionary<DateTime, decimal>>();

            foreach (KeyValuePair<int, IDictionary<DateTime, decimal>> personMonate in kuerzungenProMonatProPerson)
            {
                IDictionary<DateTime, decimal> tmp = personMonate.Value.Where(a => a.Value > _maxSanktion).ToDictionary(pair => pair.Key, pair => pair.Value);

                if (tmp.Count > 1)
                {
                    personenMonateMitZuvielKuerzungen.Add(personMonate.Key, tmp);
                }
            }

            return personenMonateMitZuvielKuerzungen;
        }

        private void CheckNotNullFieldsAbschliessen()
        {
            DBUtil.CheckNotNullField(edtRueckerstattung, lblRueckerstattung.Text);
            DBUtil.CheckNotNullField(edtBemerkungAbschluss, lblBegruendungAbschluss.Text);
        }

        private void DisplayBewegungen()
        {
            _saldo = 0;

            //Sortierung:
            // 1. Jahr
            // 2. Monat
            // 3. Ausgabe   (Typ 1): Budget vor EZ
            //    Vorabzug  (Typ 2): Budget vor EZ
            //    Abzahlung (Typ 3): EZ vor Budget

            grdBgPosition.DataSource = null;
            qryBgPosition.Fill(qryBgSpezkonto[DBO.BgSpezkonto.BgSpezkontoID], qryBgSpezkonto[DBO.BgSpezkonto.BgSpezkontoTypCode]);
            grdBgPosition.DataSource = qryBgPosition;
            int? bgSpezKontoTyp = qryBgSpezkonto[DBO.BgSpezkonto.BgSpezkontoTypCode] as int?;

            if (bgSpezKontoTyp.HasValue)
            {
                //Calculate Saldo column
                for (int i = qryBgPosition.DataTable.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow row = qryBgPosition.DataTable.Rows[i];

                    //freigegebene Positionen oder Start-Saldo-Zeile
                    if (Utils.ConvertToBool(row["Freigegeben"]) || (int)row["SortKey"] == 0) //Sortkey 0 = Startsaldo
                    {
                        if (!DBUtil.IsEmpty(row["Gutschrift"]))
                        {
                            if (bgSpezKontoTyp == 1 || bgSpezKontoTyp == 2) //Ausgabe oder Vorabzug
                            {
                                _saldo += (Decimal)row["Gutschrift"];
                            }
                            else // Abzahlung oder Kürzung
                            {
                                _saldo -= (Decimal)row["Gutschrift"];
                            }
                        }

                        if (!DBUtil.IsEmpty(row["Belastung"]))
                        {
                            if (bgSpezKontoTyp == 1 || bgSpezKontoTyp == 2) //Ausgabe oder Vorabzug
                            {
                                if ((int)row["SortKey"] == 0) // Startsaldo
                                {
                                    _saldo += (Decimal)row["Belastung"];
                                }
                                else
                                {
                                    _saldo -= (Decimal)row["Belastung"];
                                }
                            }
                            else // Abzahlung oder Kürzung
                            {
                                _saldo += (Decimal)row["Belastung"];
                            }
                        }
                    }

                    row["Saldo"] = _saldo;
                }
            }
        }

        private void PendenzErstellen(int bgSpezkontoId, decimal betrag)
        {
            int pendenzgruppeID = DBUtil.GetConfigInt(@"System\Inkasso\PendenzgruppeID", -1);
            string subject = KissMsg.GetMLMessage(Name, "InkassoPendenzAbschliessenBetreff", "Rückerstattung – Abzahlungskonto abgeschlossen (Betrag = {0})");
            subject = subject.Replace("{0}", betrag.ToString("N2"));

            // Inkasso der Person anzeigen
            const string jumpToPath = "BaPersonID=<0>;ModulID=4;TreeNodeID=CtlIkRechtlicheMassnahmenSchuldner;FaFallID=<0>;ClassName=FrmFall";

            // Pendenz erstellen
            DBUtil.ExecSQLThrowingException(@"
                DECLARE @Subject      VARCHAR(100),
                        @SenderID     INT,
                        @ReceiverID   INT,
                        @SpezkontoID  INT,
                        @LanguageCode INT,
                        @JumpToPath   VARCHAR(1500),
                        @FaLeistungID INT,
                        @BaPersonID   INT;

                SELECT @SenderID     = {0},
                       @ReceiverID   = {1},
                       @SpezkontoID  = {2},
                       @Subject      = {3},
                       @LanguageCode = {4},
                       @FaLeistungID = {5};

                SELECT @JumpToPath = REPLACE({6}, '<0>', BaPersonID),
                       @BaPersonID = BaPersonID
                FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                WHERE FaLeistungID = @FaLeistungID;

                INSERT INTO dbo.XTask(TaskTypeCode, TaskStatusCode, CreateDate, ExpirationDate, [Subject], SenderID, TaskSenderCode, ReceiverID, TaskReceiverCode, JumpToPath, FaLeistungID, BaPersonID)
                VALUES (7, 1, GETDATE(), GETDATE(), @Subject, @SenderID, 1, @ReceiverID, 2, @JumpToPath, @FaLeistungID, @BaPersonID);",
                Session.User.UserID,
                pendenzgruppeID,
                bgSpezkontoId,
                subject,
                Session.User.LanguageCode,
                _faLeistungID,
                jumpToPath);
        }

        private void RefreshDisplay()
        {
            qryBgSpezkonto.Fill(_faLeistungID, (int)_bgSpezkontoTypCode, edtAktiv.Checked ? 1 : 0);
        }

        private void SetEditMode()
        {
            SetEditModeAbschliessen(!DBUtil.IsEmpty(qryBgSpezkonto[DBO.BgSpezkonto.AbschlussgrundCode]));

            if (qryBgSpezkonto.CanUpdate)
            {
                bool verbuchteBuchungenVorhanden = qryBgPosition.DataTable.Select("Verbucht = 1 OR Gesperrt = 1").Length > 0;
                bool verrechnungBeglichen = verbuchteBuchungenVorhanden && (decimal)qryBgSpezkonto[SPK_SALDO] == 0m;

                //bool quoting;
                //if (this.bgSpezkontoTypCode == BgSpezkontoTyp.Abzahlungskonto && !DBUtil.IsEmpty(edtBgPositionsartID.EditValue))
                //{
                //    SqlQuery posQuery = ((KiSS4.DB.SqlQuery)edtBgPositionsartID.Properties.DataSource);
                //    DataRow[] currentRow = posQuery.DataTable.Select(string.Format("Code = {0}", edtBgPositionsartID.EditValue));
                //    if (currentRow.Length > 0 && !DBUtil.IsEmpty(currentRow[0]["Quoting"]))
                //    {
                //        quoting = (bool)currentRow[0]["Quoting"];
                //    }
                //    else
                //    {
                //        quoting = DBUtil.IsEmpty(qryBgSpezkonto["Quoting"]) || (bool)qryBgSpezkonto["Quoting"];
                //    }
                //}
                //else
                //{
                //    quoting = DBUtil.IsEmpty(qryBgSpezkonto["Quoting"]) || (bool)qryBgSpezkonto["Quoting"];
                //}

                edtBgKostenartID.EditMode = verbuchteBuchungenVorhanden ? EditModeType.ReadOnly : EditModeType.Normal;
                edtBgPositionsartID.EditMode = verbuchteBuchungenVorhanden ? EditModeType.ReadOnly : EditModeType.Normal; // && !DBUtil.IsEmpty(qryBgSpezkonto["BgPositionsartID"])
                edtBaPersonID.EditMode = verbuchteBuchungenVorhanden /*|| quoting*/ ? EditModeType.ReadOnly : EditModeType.Normal;

                edtDatumVonMonat.EditMode = verbuchteBuchungenVorhanden ? EditModeType.ReadOnly : EditModeType.Normal;
                edtDatumVonJahr.EditMode = edtDatumVonMonat.EditMode;

                edtDatumBisMonat.EditMode = _bgSpezkontoTypCode == BgSpezkontoTyp.Abzahlungskonto || _bgSpezkontoTypCode == BgSpezkontoTyp.Kuerzungen ? EditModeType.ReadOnly : EditModeType.Normal;
                edtDatumBisJahr.EditMode = edtDatumBisMonat.EditMode;

                //edtInaktiv.EditMode = verrechnungBeglichen ? EditModeType.ReadOnly : EditModeType.Normal;
                edtStartSaldo.EditMode = verrechnungBeglichen && _bgSpezkontoTypCode == BgSpezkontoTyp.Abzahlungskonto ? EditModeType.ReadOnly : EditModeType.Normal;
                edtBetragProMonat.EditMode = verrechnungBeglichen && _bgSpezkontoTypCode == BgSpezkontoTyp.Abzahlungskonto ? EditModeType.ReadOnly : EditModeType.Normal;
                edtNameSpezkonto.EditMode = verrechnungBeglichen ? EditModeType.ReadOnly : EditModeType.Normal;

                edtKuerzungAnteilGBL.EditMode = verrechnungBeglichen ? EditModeType.ReadOnly : EditModeType.Normal;
                edtKuerzungLaufzeit.EditMode = verrechnungBeglichen ? EditModeType.ReadOnly : EditModeType.Normal;
            }

            SetEditModeKuerzungen();
        }

        private void SetEditModeAbschliessen(bool abgeschlossen)
        {
            // Knopf nicht anzeigen wenn das Abschliessen nicht möglich ist
            if (qryBgSpezkonto.IsEmpty || !panAbschliessen.Visible)
            {
                btnAbschliessen.Visible = false;
                btnAbschliessenUndo.Visible = false;
                return;
            }

            // Knopf nicht anzeigen und Feld nicht editierbar wenn es ein neues Spezialkonto ist oder wenn
            if (qryBgSpezkonto.Row.RowState == DataRowState.Added || ((decimal)qryBgSpezkonto[SPK_SALDO] == 0 && DBUtil.IsEmpty(qryBgSpezkonto[DBO.BgSpezkonto.AbschlussgrundCode])))
            {
                SetEditModeAbschliessenFeld(EditModeType.ReadOnly);
                btnAbschliessen.Visible = false;
                btnAbschliessenUndo.Visible = false;
                return;
            }

            // Knopf und Felder jenach Recht anzeigen und editierbar machen
            btnAbschliessen.Visible = !abgeschlossen;
            btnAbschliessenUndo.Visible = abgeschlossen && DBUtil.UserHasRight(Rights.CtlWhSpezialkonto_AbschliessenRueckgaengig);

            if (btnAbschliessen.Visible)
            {
                SetEditModeAbschliessenFeld(EditModeType.Normal);
                qryBgSpezkonto.CanUpdate = _canUpdate;
            }
            else
            {
                qryBgSpezkonto.CanUpdate = false;
            }

            qryBgSpezkonto.EnableBoundFields(qryBgSpezkonto.CanUpdate);
        }

        private void SetEditModeAbschliessenFeld(EditModeType editMode)
        {
            edtBemerkungAbschluss.EditMode = editMode;
            edtRueckerstattung.EditMode = editMode;
        }

        private void SetEditModeKuerzungen()
        {
            if (_bgSpezkontoTypCode != BgSpezkontoTyp.Kuerzungen || qryBgSpezkonto.IsEmpty || qryBgSpezkonto.Row.RowState == DataRowState.Added)
            {
                btnKuerzungGrau.Visible = false;
                btnKuerzungFreigeben.Visible = false;
                btnKuerzungAufheben.Visible = false;
                return;
            }

            bool positionenVerbucht = (qryBgPosition.DataTable.Select("Freigegeben = 1 OR Gesperrt = 1").Length > 0);
            bool inaktiv = Convert.ToBoolean(qryBgSpezkonto[DBO.BgSpezkonto.Inaktiv]);
            btnKuerzungGrau.Visible = !inaktiv && !positionenVerbucht;
            btnKuerzungFreigeben.Visible = inaktiv && !positionenVerbucht;
            btnKuerzungAufheben.Visible = !inaktiv && positionenVerbucht;
        }

        private void SpezialkontoAbschliessen(int bgSpezkontoId, decimal betrag)
        {
            DBUtil.ExecSQLThrowingException(@"-- Insert into BgSpezialkontoAbschluss
                DECLARE @Creator VARCHAR(50);
                SELECT @Creator = dbo.fnGetDBRowCreatorModifier({2});

                INSERT INTO dbo.BgSpezkontoAbschluss(BgSpezkontoID, Betrag, Text, Creator, Modifier)
                SELECT
                  BgSpezkontoID = {0},
                  Betrag        = {1},
                  Text          = dbo.fnGetLOVMLText('AbzahlungskontoAbschlussgrund', 2, 0),
                  Creator       = @Creator,
                  Modifier      = @Creator;",
                bgSpezkontoId,
                betrag,
                Session.User.UserID);
        }

        private void UebergabeAnInkasso(int bgSpezkontoId, decimal betrag)
        {
            PendenzErstellen(bgSpezkontoId, betrag);
            SpezialkontoAbschliessen(bgSpezkontoId, betrag);
        }

        #endregion

        #endregion
    }
}