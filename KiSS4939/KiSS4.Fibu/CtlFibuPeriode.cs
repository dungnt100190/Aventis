using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SharpLibrary.WinControls;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Summary description for CtlFibuPeriode.
    /// </summary>
    public partial class CtlFibuPeriode : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASS_NAME = "CtlFibuPeriode";

        #endregion

        #region Private Fields

        private DataRowState _saveRowState;
        private bool _userHasRightPeriodenUebertragen;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFibuPeriode"/> class.
        /// </summary>
        public CtlFibuPeriode()
        {
            InitializeComponent();
            colStatus.ColumnEdit = gridPeriode.GetLOVLookUpEdit("FbPeriodeStatus");
        }

        #endregion

        #region EventHandlers

        private void CtlFibuPeriode_Load(object sender, EventArgs e)
        {
            editPeriodeVon.EditValue = DBNull.Value;
            editPeriodeBis.EditValue = DBNull.Value;

            tabControlSearch.SelectedTabIndex = 0;
            tabControlSearch.SelectedTabIndex = 1;

            SqlQuery qry = DBUtil.OpenSQL("SELECT FbTeamID, Name FROM FbTeam ORDER BY Name");

            DataRow newRow = qry.DataTable.NewRow();
            newRow["FbTeamID"] = DBNull.Value;
            newRow["Name"] = string.Empty;
            qry.DataTable.Rows.InsertAt(newRow, 0);
            newRow.AcceptChanges();

            editTeam.Properties.DataSource = qry;
            editTeam.Properties.DropDownRows = Math.Min(qry.Count, 7);

            edtSucheTeam.LoadQuery(qry, "FbTeamID", "Name");

            grideditTeam.DataSource = qry;

            // start with search mode
            tabControlSearch.SelectedTabIndex = 1;
            edtSucheMandant.Focus();

            _userHasRightPeriodenUebertragen = DBUtil.UserHasRight("CtlFibuPeriode_PeriodenUebertragen");
            btnUebertragen.Enabled = _userHasRightPeriodenUebertragen;
        }

        private void CtlFibuPeriode_Search(object sender, EventArgs e)
        {
            if (tabControlSearch.SelectedTabIndex == 0)
            {
                if (qryPeriode.Post())
                {
                    tabControlSearch.SelectedTabIndex = 1;
                    NeueSuche();
                }
            }
            else
            {
                FillMandant();
            }
        }

        private void btnAbschluss_Click(object sender, EventArgs e)
        {
            var periodeStatusCode = qryPeriode["PeriodeStatusCode"] as int?;
            if (periodeStatusCode.HasValue && periodeStatusCode.Value == 3)
            {
                return;
            }

            //gibt es überhaupt Buchungen in dieser Periode
            var qry = DBUtil.OpenSQL("SELECT COUNT(*) Count FROM FbBuchung WHERE FbPeriodeID = {0}", qryPeriode["FbPeriodeID"]);

            if (((int)qry["Count"]) == 0)
            {
                KissMsg.ShowInfo(
                    CLASS_NAME,
                    "PeriodeNichtAbgeschlossen",
                    "Periode kann nicht abgeschlossen werden, da noch keine Buchungen vorhanden sind");
                return;
            }

            //Ist BilanzSaldo ausgeglichen ?
            qry = DBUtil.OpenSQL(@"
                SELECT SUM(CASE WHEN KTOS.KontoNr IS NULL THEN 0 ELSE BUC.Betrag END -
                           CASE WHEN KTOH.KontoNr IS NULL THEN 0 ELSE BUC.Betrag END) Saldo
                FROM   dbo.FbBuchung BUC
                    LEFT JOIN dbo.FbKonto KTOS ON KTOS.FbPeriodeID = BUC.FbPeriodeID AND KTOS.KontoNr = BUC.SollKtoNr AND KTOS.KontoKlasseCode IN (1,2)
                    LEFT JOIN dbo.FbKonto KTOH ON KTOH.FbPeriodeID = BUC.FbPeriodeID AND KTOH.KontoNr = BUC.HabenKtoNr AND KTOH.KontoKlasseCode in (1,2)
                WHERE  BUC.FbPeriodeID = {0}",
                qryPeriode["FbPeriodeID"]);

            //an dieser Stelle: prüfen, ob noch offene Zahlungen etc..

            if (((decimal)qry["Saldo"]) != 0)
            {
                int sollKtoNr;
                int habenKtoNr;
                string buchungstext;

                int passivKtoNr = GetKapitalKonto(2, "Passiv");
                if (passivKtoNr == 0)
                {
                    return;
                }

                if (((decimal)qry["Saldo"]) > 0)
                {
                    buchungstext = "Vermögenszunahme";
                    habenKtoNr = passivKtoNr;
                    sollKtoNr = GetKapitalKonto(3, "Aufwand");
                    if (sollKtoNr == 0)
                    {
                        return;
                    }
                }
                else
                {
                    buchungstext = "Vermögensabnahme";
                    sollKtoNr = passivKtoNr;
                    habenKtoNr = GetKapitalKonto(4, "Ertrags");
                    if (habenKtoNr == 0)
                    {
                        return;
                    }
                }

                //Fragen, ob Saldo auf Klienten-Kapital verbucht werden soll
                if (!KissMsg.ShowQuestion(
                        CLASS_NAME,
                        "PeriodeAbschliessen",
                        "Soll diese Periode abgeschlossen werden mit der automatischen Verbuchung des Bilanzsaldos von CHF {0}?",
                        0,
                        0,
                        true,
                        ((decimal)qry["Saldo"]).ToString("N2")))
                {
                    return;
                }

                //Verbuchen des Bilanzsaldos
                if (DBUtil.ExecSQL(@"
                    INSERT INTO dbo.FbBuchung(FbPeriodeID,BuchungTypCode,BelegNr,BelegNrPos,BuchungsDatum,SollKtoNr,HabenKtoNr,Betrag,Text,Creator,Modifier)
                    VALUES                   ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{9})",
                    qryPeriode["FbPeriodeID"],
                    1,
                    "Abschluss",
                    0,
                    qryPeriode["PeriodeBis"],
                    sollKtoNr,
                    habenKtoNr,
                    Math.Abs((decimal)qry["Saldo"]),
                    buchungstext,
                    DBUtil.GetDBRowCreatorModifier()) == 0)
                {
                    return;
                }
            }
            else if (!KissMsg.ShowQuestion(
                CLASS_NAME,
                "SaldoLeerAbschliessen",
                "Der Bilanzsaldo dieser Periode beträgt 0.00. Soll diese Periode wirklich abgeschlossen werden ?"))
            {
                return;
            }

            //Periode abschliessen
            qryPeriode["PeriodeStatusCode"] = 3;
            qryPeriode.Post();

            //Saldi automatisch vortragen
            DBUtil.ExecSQL("spFbSaldiVortragen " + DBUtil.SqlLiteral(qryMandant["BaPersonID"]));
        }

        private void btnAktiv_Click(object sender, EventArgs e)
        {
            var periodeStatusCode = qryPeriode["PeriodeStatusCode"] as int?;
            if (!periodeStatusCode.HasValue)
            {
                return;
            }
            switch (periodeStatusCode.Value)
            {
                case 1:
                    qryPeriode["PeriodeStatusCode"] = 2;
                    if (qryPeriode.Post())
                    {
                        qryPeriode.EnableBoundFields(false);
                        //Saldi automatisch vortragen
                        DBUtil.ExecSQL("spFbSaldiVortragen " + DBUtil.SqlLiteral(qryMandant["BaPersonID"]));
                    }
                    break;
                case 2:
                    qryPeriode["PeriodeStatusCode"] = 1;
                    if (qryPeriode.Post())
                    {
                        qryPeriode.EnableBoundFields(true);
                        //Saldi automatisch vortragen
                        DBUtil.ExecSQL("spFbSaldiVortragen " + DBUtil.SqlLiteral(qryMandant["BaPersonID"]));
                    }
                    break;
                case 3:
                    KissMsg.ShowInfo(CLASS_NAME, "PeriodeBereitsAbgeschlossen", "Periode ist bereits abgeschlossen");
                    break;
            }
        }

        private void btnSaldiVortragen_Click(object sender, EventArgs e)
        {
            if (qryMandant.Count == 0)
            {
                return;
            }

            if (qryPeriode.Count <= 1)
            {
                return;
            }

            if (KissMsg.ShowQuestion(
                CLASS_NAME,
                "EroeffungssaldiNeuBerechnen",
                "Sollen die Eröffnungssaldi aller aktiven Perioden aufgrund der Vorperiode neu berechnet werden ?"))
            {
                if (DBUtil.ExecSQL("dbo.spFbSaldiVortragen " + DBUtil.SqlLiteral(qryMandant["BaPersonID"])) != -99)
                {
                    KissMsg.ShowInfo(CLASS_NAME, "SaldiVorgetragen", "Alle Saldi wurden vorgetragen.");
                }
            }
        }

        private void btnUebertragen_Click(object sender, EventArgs e)
        {
            int countPerioden;
            int countBarauszahlungen;

            Session.BeginTransaction();

            try
            {
                CheckPeriodenUebertragenErlaubt();

                // Perioden übertragen
                countPerioden = DBUtil.ExecuteScalarSQLThrowingException(@"
                    UPDATE dbo.FbPeriode
                      SET BaPersonID = {1}
                    WHERE BaPersonID = {0};

                    SELECT @@ROWCOUNT;",
                    qryMandant["BaPersonID"],
                    edtPersonID.EditValue) as int? ?? 0;

                // Barauszahlungen terminieren
                countBarauszahlungen = DBUtil.ExecuteScalarSQLThrowingException(@"
                    UPDATE BAA
                      SET BAA.DatumBis = dbo.fnDateOf(GETDATE())
                    FROM dbo.FbBarauszahlungAuftrag BAA
                      INNER JOIN dbo.FaLeistung     LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = BAA.FaLeistungID
                                                                              AND LEI.ModulID IN (5, 29)
                                                                              AND LEI.BaPersonID = {0}
                    WHERE BAA.DatumBis IS NULL
                       OR BAA.DatumBis > GETDATE();

                    SELECT @@ROWCOUNT;",
                    qryMandant["BaPersonID"]) as int? ?? 0;

                Session.Commit();
            }
            catch (KissCancelException ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                return;
            }
            catch (Exception)
            {
                Session.Rollback();
                throw;
            }

            // Benutzer informieren
            KissMsg.ShowInfo(
                CLASS_NAME,
                "AnzahlPeriodenUebertragenUndBarauszahlungenGeschlossen",
                "Es wurde {0} Perioden von {1} zu {2} übertragen." + Environment.NewLine +
                "{3} Barauszahlungen wurden terminiert.",
                countPerioden,
                string.Format("{0} ({1})", qryMandant["Mandant"], qryMandant["BaPersonID"]),
                GetPersonNameVornameID(Convert.ToInt32(edtPersonID.EditValue)),
                countBarauszahlungen);

            ClearBaPersonIDUebertragen();

            // Perioden neu laden
            qryPeriode.Refresh();
        }

        private void btnUebertragen_Enter(object sender, EventArgs e)
        {
            SetEditModePersonIdFeld(EditModeType.Required);
        }

        private void btnUebertragen_Leave(object sender, EventArgs e)
        {
            SetEditModePersonIdFeld(EditModeType.Normal);
        }

        private void btnUebertragen_MouseEnter(object sender, EventArgs e)
        {
            SetEditModePersonIdFeld(EditModeType.Required);
        }

        private void btnUebertragen_MouseLeave(object sender, EventArgs e)
        {
            SetEditModePersonIdFeld(EditModeType.Normal);
        }

        private void gridView1_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            e.Allow = qryPeriode.Post();
        }

        private void qryMandant_PositionChanged(object sender, EventArgs e)
        {
            var baPersonId = qryMandant["BaPersonID"] as int?;

            if (baPersonId.HasValue)
            {
                qryPeriode.Fill(@"
                    SELECT *
                    FROM dbo.FbPeriode WITH (READUNCOMMITTED)
                    WHERE BaPersonID = {0};", baPersonId.Value);
            }

            ClearBaPersonIDUebertragen();
        }

        private void qryPeriode_AfterFill(object sender, EventArgs e)
        {
            if (qryPeriode.IsEmpty)
            {
                SetEditModePersonIdFeld(EditModeType.ReadOnly);
                btnUebertragen.Enabled = false;
            }
            else
            {
                SetEditModePersonIdFeld(EditModeType.Normal);
                btnUebertragen.Enabled = _userHasRightPeriodenUebertragen;
            }
        }

        private void qryPeriode_AfterInsert(object sender, EventArgs e)
        {
            qryPeriode["BaPersonID"] = qryMandant["BaPersonID"];
            qryPeriode["PeriodeStatusCode"] = 1; // aktiv

            // nächste 2-jährige Periode vorschlagen
            var qry = DBUtil.OpenSQL(@"
                SELECT MaxDate = MAX(PeriodeBis)
                FROM dbo.FbPeriode WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0}",
                qryMandant["BaPersonID"]);

            if (!DBUtil.IsEmpty(qry["MaxDate"]))
            {
                DateTime d = ((DateTime)qry["MaxDate"]).Date;
                qryPeriode["PeriodeVon"] = d.AddDays(1);
                qryPeriode["PeriodeBis"] = d.AddDays(1).AddYears(2);
            }

            qryPeriode.EnableBoundFields(true);

            editPeriodeVon.Focus();
        }

        /// <summary>
        /// Copy the default Kontenplan i.e. the Kontenplan of the previous period to this period!
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryPeriode_AfterPost(object sender, EventArgs e)
        {
            //Wenn neue Periode: Kopiere StandardKontenplan bzw. Kontenplan der letzten Periode auf neue Periode
            if (_saveRowState == DataRowState.Added)
            {
                var qry = DBUtil.OpenSQL(@"
                    SELECT TOP 1 FbPeriodeID
                    FROM dbo.FbPeriode
                    WHERE BaPersonID = {0}
                      AND FbPeriodeID <> {1}
                    ORDER BY PeriodeBis DESC",
                    qryPeriode["BaPersonID"],
                    qryPeriode["FbPeriodeID"]);

                var sql = string.Format(@"
                    INSERT INTO FbKonto (FbPeriodeID, KontoKlasseCode, KontoTypCode, KontoNr, KontoName, EroeffnungsSaldo, SaldoGruppeName, FbDTAZugangID, FbDepotNr)
                      SELECT {0}, KontoKlasseCode, KontoTypCode, KontoNr, KontoName, 0, SaldoGruppeName, FbDTAZugangID, FbDepotNr
                      FROM dbo.FbKonto ",
                    qryPeriode["FbPeriodeID"]);

                if (qry.Count == 0)
                {
                    sql += " WHERE  FbPeriodeID IS NULL";
                }
                else
                {
                    sql += " WHERE  FbPeriodeID = " + DBUtil.SqlLiteral(qry["FbPeriodeID"]);
                }

                DBUtil.ExecSQL(sql);
            }
        }

        private void qryPeriode_BeforeDelete(object sender, EventArgs e)
        {
            if (((int)qryPeriode["PeriodeStatusCode"]) == 3)
            {
                KissMsg.ShowInfo(CLASS_NAME, "LoeschenNichtMoeglich", "Abgeschlossene Perioden können nicht gelöscht werden !");
                throw new Exception();
            }

            //gibt es noch Buchungen in dieser Periode ?
            var qry = DBUtil.OpenSQL(@"SELECT COUNT(*) Count FROM dbo.FbBuchung WHERE FbPeriodeID = {0}", qryPeriode["FbPeriodeID"]);

            if (((int)qry["Count"]) > 0)
            {
                KissMsg.ShowInfo(CLASS_NAME, "NochKeineBuchung", "Periode kann nicht gelöscht werden, da noch Buchungen vorhanden sind");
                throw new KissCancelException();
            }

            //Kontenplan löschen
            DBUtil.ExecSQL(@"DELETE FROM FbKonto WHERE FbPeriodeID = {0}", qryPeriode["FbPeriodeID"]);
        }

        private void qryPeriode_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(editPeriodeVon, lblPeriodeVon.Text);
            DBUtil.CheckNotNullField(editPeriodeBis, lblPeriodeBis.Text);

            //check Periodenüberschneidung
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT TOP 1 1
                FROM dbo.FbPeriode WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0}
                  AND FbPeriodeID <> {1}
                  AND ({2} BETWEEN PeriodeVon AND PeriodeBis
                    OR {3} BETWEEN PeriodeVon AND PeriodeBis)",
                qryPeriode["BaPersonID"],
                qryPeriode["FbPeriodeID"],
                qryPeriode["PeriodeVon"],
                qryPeriode["PeriodeBis"]);

            if (qry.Count > 0)
            {
                KissMsg.ShowInfo(
                    CLASS_NAME,
                    "SpeichernNichtMoeglich",
                    "Periode kann nicht gespeichert werden, da sie sich mit bestehenden überschneidet");
                throw new KissCancelException();
            }

            //check bestehende Buchungen
            if (qryPeriode.Row.RowState == DataRowState.Modified
                && (qryPeriode.ColumnModified(DBO.FbPeriode.PeriodeVon)
                    || qryPeriode.ColumnModified(DBO.FbPeriode.PeriodeBis)))
            {
                qry = DBUtil.OpenSQL(@"
                    SELECT TOP 1 1
                    FROM dbo.FbBuchung
                    WHERE FbPeriodeID = {0}
                      AND (BuchungsDatum < {1} OR BuchungsDatum > {2})",
                    qryPeriode["FbPeriodeID"],
                    qryPeriode["PeriodeVon"],
                    qryPeriode["PeriodeBis"]);

                if (qry.Count > 0)
                {
                    KissMsg.ShowInfo(
                        CLASS_NAME,
                        "BuchungAusserhalbDatum",
                        "Periode kann nicht gespeichert werden, da bereits Buchungen ausserhalb des Datumbereichs existieren");
                    throw new KissCancelException();
                }
            }

            _saveRowState = qryPeriode.Row.RowState;
        }

        private void qryPeriode_PositionChanged(object sender, EventArgs e)
        {
            var allowEdit = (qryPeriode["PeriodeStatusCode"] as int? ?? 0) == 1;
            qryPeriode.EnableBoundFields(allowEdit);
        }

        private void tabControlSearch_SelectedTabChanged(TabPageEx page)
        {
            panDetail.Enabled = tabControlSearch.SelectedTab == tpgListe;
            btnUebertragen.Enabled = _userHasRightPeriodenUebertragen;
            ClearBaPersonIDUebertragen();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override string GetContextName()
        {
            return "VmFibu";
        }

        #endregion

        #region Private Static Methods

        private static bool BaPersonImKlientensystem(int personId1, int personId2)
        {
            return DBUtil.ExecuteScalarSQLThrowingException(@"
                DECLARE @BaPersonID INT;
                SET @BaPersonID = {0}

                IF EXISTS(SELECT TOP 1 1
                          FROM dbo.BaPerson_Relation REL  WITH (READUNCOMMITTED)
                            INNER JOIN dbo.BaPerson  PRS1 WITH (READUNCOMMITTED) ON PRS1.BaPersonID = REL.BaPersonID_1
                            INNER JOIN dbo.BaPerson  PRS2 WITH (READUNCOMMITTED) ON PRS2.BaPersonID = REL.BaPersonID_2
                          WHERE (BaPersonID_1 = @BaPersonID OR BaPersonID_2 = @BaPersonID)
                            AND CASE WHEN BaPersonID_1 = @BaPersonID
                                  THEN BaPersonID_2
                                  ELSE BaPersonID_1
                                END = {1})
                BEGIN
                  SELECT CONVERT(BIT, 1);
                END
                ELSE
                BEGIN
                  SELECT CONVERT(BIT, 0);
                END;",
                personId1,
                personId2) as bool? ?? false;
        }

        private static string GetPersonNameVornameID(int personId)
        {
            return DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT NameVorname + ' (' + CONVERT(VARCHAR, BaPersonID) + ')'
                FROM dbo.vwPersonSimple
                WHERE BaPersonID = {0}",
                personId) as string;
        }

        private static bool HasPeriodenUeberschneidung(int personIdFrom, int personIdTo)
        {
            return DBUtil.ExecuteScalarSQLThrowingException(@"
                IF EXISTS(SELECT TOP 1 1
                          FROM dbo.FbPeriode FPR WITH (READUNCOMMITTED)
                          WHERE FPR.BaPersonID = {0}
                            AND EXISTS(SELECT TOP 1 1
                                       FROM dbo.FbPeriode FPR1 WITH (READUNCOMMITTED)
                                       WHERE FPR1.BaPersonID = {1}
                                         AND (FPR.PeriodeVon BETWEEN FPR1.PeriodeVon AND FPR1.PeriodeBis
                                           OR FPR.PeriodeBis BETWEEN FPR1.PeriodeVon AND FPR1.PeriodeBis)))
                BEGIN
                  SELECT CONVERT(BIT, 1);
                END
                ELSE
                BEGIN
                  SELECT CONVERT(BIT, 0);
                END;",
                personIdFrom,
                personIdTo) as bool? ?? false;
        }

        #endregion

        #region Private Methods

        private void CheckPeriodenUebertragenErlaubt()
        {
            // PersonID muss eingegeben sein
            DBUtil.CheckNotNullField(edtPersonID, lblPersonNr.Text);

            // Person im Klientensystem
            var personIdMandant = Convert.ToInt32(qryMandant["BaPersonID"]);
            var personIdNeu = Convert.ToInt32(edtPersonID.EditValue);

            if (!BaPersonImKlientensystem(personIdMandant, personIdNeu))
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASS_NAME,
                        "PersonIstNichtImKlientensystem",
                        "{1} ist nicht im Klientensystem von {0}.",
                        string.Format("{0} ({1})", qryMandant["Mandant"], qryMandant["BaPersonID"]),
                        GetPersonNameVornameID(personIdNeu)));
            }

            // Periodenüberschneidung überprüfen
            if (HasPeriodenUeberschneidung(personIdMandant, personIdNeu))
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASS_NAME,
                        "PeriodenUeberschneidung",
                        "Die Perioden können nicht übertragen werden weil es Periodenüberschneidungen gibt."));
            }
        }

        private void ClearBaPersonIDUebertragen()
        {
            edtPersonID.EditValue = null;
        }

        private void FillMandant()
        {
            var currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            string sql;

            if (chkSuchePersonMitBuchhaltung.Checked)
            {
                sql = @"
                    SELECT
                      PRS.BaPersonID,
                      Mandant = PRS.NameVorname,
                      Strasse = PRS.WohnsitzStrasseHausNr,
                      PLZOrt  = PRS.WohnsitzPLZOrt,
                      MTLogon = '',
                      MTName  = ''
                    FROM dbo.vwPerson PRS
                    WHERE EXISTS (SELECT TOP 1 1
                                  FROM dbo.FbPeriode FPR
                                  WHERE FPR.BaPersonID = PRS.BaPersonID) ";
            }
            else if (chkSuchePersStamm.Checked)
            {
                sql = @"
                    SELECT
                      PRS.BaPersonID,
                      Mandant = PRS.NameVorname,
                      Strasse = PRS.WohnsitzStrasseHausNr,
                      PLZOrt  = PRS.WohnsitzPLZOrt,
                      MTLogon = '',
                      MTName  = ''
                    FROM dbo.vwPerson PRS
                    WHERE 1 = 1 ";
            }
            else
            {
                sql = @"
                    SELECT
                      PRS.BaPersonID,
                      Mandant = PRS.NameVorname,
                      Strasse = PRS.WohnsitzStrasseHausNr,
                      PLZOrt  = PRS.WohnsitzPLZOrt,
                      MTLogon = USR.LogonName,
                      MTName  = USR.NameVorname
                    FROM (SELECT BaPersonID, UserID
                          FROM dbo.FaLeistung F WITH (READUNCOMMITTED)
                          WHERE ModulID IN (5, 29)
                            AND FaLeistungID = dbo.fnVmGetLeistungID(F.BaPersonID)) FAL
                      INNER JOIN dbo.vwPerson PRS ON PRS.BaPersonID = FAL.BaPersonID
                      LEFT  JOIN dbo.vwUser   USR ON USR.UserID = FAL.UserID
                    WHERE 1 = 1 ";
            }

            var whereClause = new StringBuilder();

            // Mandant
            if (edtSucheMandant.Text != "")
            {
                var suchbegriff = edtSucheMandant.Text;

                suchbegriff = suchbegriff.Replace(",", "%");
                suchbegriff = suchbegriff.Replace(" ", "%");

                whereClause.AppendLine(string.Format("AND PRS.NameVorname LIKE {0}", DBUtil.SqlLiteralLike(suchbegriff + "%")));
            }

            // Mandatsträger
            if (edtSucheMaTraeger.Text != "" && !chkSuchePersStamm.Checked)
            {
                var suchbegriff = edtSucheMaTraeger.Text;

                suchbegriff = suchbegriff.Replace(",", "%");
                suchbegriff = suchbegriff.Replace(" ", "%");

                whereClause.AppendLine(string.Format("AND USR.NameVorname LIKE {0}", DBUtil.SqlLiteralLike(suchbegriff + "%")));
            }

            // PeriodeVon
            if (!DBUtil.IsEmpty(edtSuchePeriodeVon.EditValue))
            {
                whereClause.AppendLine(
                    string.Format(
                        "AND EXISTS (SELECT 1 FROM FbPeriode WHERE BaPersonID = PRS.BaPersonID AND PeriodeVon = {0})",
                        DBUtil.SqlLiteral(edtSuchePeriodeVon.DateTime)));
            }

            // PeriodeBis
            if (!DBUtil.IsEmpty(edtSuchePeriodeBis.EditValue))
            {
                whereClause.AppendLine(
                    string.Format(
                        "AND EXISTS (SELECT 1 FROM FbPeriode WHERE BaPersonID = PRS.BaPersonID AND PeriodeBis = {0})",
                        DBUtil.SqlLiteral(edtSuchePeriodeBis.DateTime)));
            }

            // Team
            if (!DBUtil.IsEmpty(edtSucheTeam.EditValue))
            {
                whereClause.AppendLine(
                    string.Format(
                        "AND EXISTS (SELECT TOP 1 1 FROM FbPeriode WHERE BaPersonID = PRS.BaPersonID AND FbTeamID = {0})",
                        DBUtil.SqlLiteral(edtSucheTeam.EditValue)));
            }

            // Journalablage
            if (!DBUtil.IsEmpty(edtSucheJournAblOrt.EditValue))
            {
                whereClause.AppendLine(
                    string.Format(
                        "AND EXISTS (SELECT TOP 1 1 FROM FbPeriode WHERE BaPersonID = PRS.BaPersonID AND JournalablageortCode = {0})",
                        DBUtil.SqlLiteral(edtSucheJournAblOrt.EditValue)));
            }

            sql += whereClause.AppendLine(" ORDER BY Mandant").ToString();

            qryMandant.Fill(sql);
            tabControlSearch.SelectedTabIndex = 0;
            Cursor.Current = currentCursor;
        }

        private int GetKapitalKonto(int kontoKlasseCode, string kontoKlasseName)
        {
            var qry = DBUtil.OpenSQL(@"
                SELECT KontoNr
                FROM   FbKonto
                WHERE  FbPeriodeID = {0} AND
                    KontoTypCode = 6 AND
                    KontoKlasseCode = {1}",
                qryPeriode["FbPeriodeID"],
                kontoKlasseCode);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(
                    CLASS_NAME,
                    "KeinKontoInPeriode",
                    "Der Kontenplan dieser Periode weist kein {0}konto mit dem Typ 'Kapital Klient' auf!",
                    0,
                    0,
                    kontoKlasseName);
                return 0;
            }

            if (qry.Count > 1)
            {
                KissMsg.ShowInfo(
                    CLASS_NAME,
                    "MehrAlsEinKontoInPeriode",
                    "Der Kontenplan dieser Periode weist mehr als ein {0}konto mit dem Typ 'Kapital Klient' auf!",
                    0,
                    0,
                    kontoKlasseName);
                return 0;
            }

            return (int)qry["KontoNr"];
        }

        private void NeueSuche()
        {
            foreach (var ctl in tpgSuchen.Controls.OfType<BaseEdit>())
            {
                (ctl).EditValue = null;
            }

            edtSucheMandant.Focus();
        }

        private void SetEditModePersonIdFeld(EditModeType editMode)
        {
            edtPersonID.EditMode = editMode;
        }

        #endregion

        #endregion
    }
}