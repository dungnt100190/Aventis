using System;
using System.Data;
using System.Linq;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace KiSS4.Query
{
    public partial class CtlQueryKbControlling : KissQueryControl
    {
        #region Enumerations

        private enum ControllingType
        {
            BelegDatumOhnePeriode = 1,
            BetragDifferenz = 2,
            KostenartKontoNrImSollHaben = 3,
            KostenartFehlt = 4,
            KostenstelleUngueltig = 5,
            VergleichBilanzErSozialhilferechnung = 6,
            VergleichBilanzErKostenarten = 7
        }

        #endregion

        #region Constructors

        public CtlQueryKbControlling()
        {
            InitializeComponent();

            InitializeControllingType();
            InitializeKbPeriode();
        }

        #endregion

        #region EventHandlers

        private void edtKostenart_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.BgKostenartSuchen(edtKostenart.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtKostenart.EditValue = dlg[DBO.BgKostenart.Name];
                edtKostenart.LookupID = dlg[DBO.BgKostenart.BgKostenartID];
                edtKostenartKontoNr.EditValue = dlg[DBO.BgKostenart.KontoNr];
            }
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            switch ((ControllingType)((int)edtControllingType.EditValue))
            {
                case ControllingType.BelegDatumOhnePeriode:
                case ControllingType.BetragDifferenz:
                case ControllingType.KostenartKontoNrImSollHaben:
                case ControllingType.KostenartFehlt:
                    AddRelationKbBuchungKbBuchungKostenart();
                    break;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnSearch()
        {
            grdQuery1.DataSource = null;
            SetSelectStatement();
            base.OnSearch();
            grdQuery1.DataSource = qryQuery;
        }

        #endregion

        #region Private Static Methods

        private static string GetSelectBelegDatumOhnePeriode()
        {
            return GetSelectKbBuchungAndKbBuchungKostenart(false, false, false);
        }

        private static string GetSelectBetragDifferenz()
        {
            return GetSelectKbBuchungAndKbBuchungKostenart(true, false, false);
        }

        private static string GetSelectKbBuchungAndKbBuchungKostenart(bool mitBetragDifferenz, bool mitKostenartImSollHaben, bool ohneKbBuchungKostenart)
        {
            return @"
                DECLARE @KbBuchung TABLE(
                  KbBuchungID INT
                );

                INSERT INTO @KbBuchung(KbBuchungID)
                  SELECT KbBuchungID
                  FROM dbo.KbBuchung BUC WITH (READUNCOMMITTED)
                  WHERE 1 = 1
                    -- mit Betrag Differenz
                    AND ({0} = 0 OR BUC.Betrag <> (SELECT SUM(BKO.Betrag)
                                                   FROM dbo.KbBuchungKostenart BKO WITH (READUNCOMMITTED)
                                                   WHERE BKO.KbBuchungID = BUC.KbBuchungID))
                    -- mit Kostenart im Soll- order Haben-Konto
                    AND ({1} = 0 OR BUC.SollKtoNr IN (SELECT KontoNr
                                                      FROM dbo.BgKostenart WITH (READUNCOMMITTED))
                                 OR BUC.HabenKtoNr IN (SELECT KontoNr
                                                       FROM dbo.BgKostenart WITH (READUNCOMMITTED)))
                    -- KbBuchungKostenart fehlt
                    AND ({2} = 0 OR ((BUC.SollKtoNr IS NULL OR BUC.HabenKtoNr IS NULL)
                                    AND NOT EXISTS(SELECT TOP 1 1
                                                   FROM dbo.KbBuchungKostenart BKO WITH (READUNCOMMITTED)
                                                   WHERE BKO.KbBuchungID = BUC.KbBuchungID)))
                  ---  AND BUC.BelegDatum >= {edtBelegDatumVon}
                  ---  AND BUC.BelegDatum <= {edtBelegDatumBis}
                  ---  AND BUC.BelegNr = {edtBelegNr}
                  ---  AND BUC.KbBuchungID = {edtKbBuchungID}
                  ---  AND BUC.KbPeriodeID = {edtKbPeriodeID}

                SELECT
                  BUC.KbBuchungID,
                  BUC.BelegNr,
                  BUC.BelegDatum,
                  BUC.ValutaDatum,
                  BUC.Betrag,
                  BUC.Text,
                  BUC.SollKtoNr,
                  BUC.HabenKtoNr,
                  BUC.KbPeriodeID,
                  Buchungstyp    = dbo.fnLOVText('KbBuchungTyp', BUC.KbBuchungTypCode),
                  Buchungsstatus = dbo.fnLOVText('KbBuchungsStatus', BUC.KbBuchungStatusCode),
                  BUC.KbZahlungseingangID,
                  BUC.StorniertKbBuchungID,
                  BUC.NeubuchungVonKbBuchungID,
                  BUC.FaLeistungID,
                  BUC.BgBudgetID,
                  BUC.IkPositionID,
                  BUC.ErstelltDatum,
                  ErstelltUser = dbo.fnGetDBRowCreatorModifier(BUC.ErstelltUserID),
                  BUC.MutiertDatum,
                  MutiertUser = dbo.fnGetDBRowCreatorModifier(BUC.MutiertUserID)
                FROM dbo.KbBuchung      BUC WITH (READUNCOMMITTED)
                  INNER JOIN @KbBuchung BUCT ON BUCT.KbBuchungID = BUC.KbBuchungID

                SELECT
                  BKO.KontoNr,
                  BKO.BgKostenartID,
                  BKO.Betrag,
                  BKO.Buchungstext,
                  BKO.KbKostenstelleID,
                  BKO.BaPersonID,
                  BKO.VerwPeriodeVon,
                  BKO.VerwPeriodeBis,
                  BKO.BgPositionID,
                  BKO.KbForderungArtCode,
                  BKO.BgSplittingArtCode,
                  BKO.Weiterverrechenbar,
                  BKO.Quoting,
                  BKO.NrmKontoCode,
                  BKO.PositionImBeleg,
                  BKO.KbBuchungID
                FROM dbo.KbBuchungKostenart BKO WITH (READUNCOMMITTED)
                  INNER JOIN @KbBuchung BUCT ON BUCT.KbBuchungID = BKO.KbBuchungID;"
                    .Replace("{0}", mitBetragDifferenz ? "1" : "0")
                    .Replace("{1}", mitKostenartImSollHaben ? "1" : "0")
                    .Replace("{2}", ohneKbBuchungKostenart ? "1" : "0");
        }

        private static string GetSelectKostenartFehlt()
        {
            return GetSelectKbBuchungAndKbBuchungKostenart(false, false, true);
        }

        private static string GetSelectKostenartKontoNrImSollHaben()
        {
            return GetSelectKbBuchungAndKbBuchungKostenart(false, true, false);
        }

        private static string GetSelectKostenstelleUngueltig()
        {
            return @"
                SELECT 
                  BUC.KbBuchungID,
                  BUC.BelegNr,
                  BUC.BelegDatum,
                  KSP1.KbKostenstelleID,
                  KSP1.BaPersonID,
                  [Kostenstelle Nr] = KST1.Nr,
                  [Kostenstelle Name] = KST1.Name,
                  KSP1.DatumVon,
                  KSP1.DatumBis,
                  [KbKostenstelleID gültig] = KSP2.KbKostenstelleID,
                  [Kostenstelle Nr gültig] = KST2.Nr,
                  [Kostenstelle Name gültig] = KST2.Name,
                  [DatumVon gültig] = KSP2.DatumVon,
                  [DatumBis gültig] = KSP2.DatumBis
                FROM dbo.KbBuchungKostenart              BKO  WITH (READUNCOMMITTED)
                  INNER JOIN dbo.KbBuchung               BUC  WITH (READUNCOMMITTED)
                                                              ON BUC.KbBuchungID = BKO.KbBuchungID
                  INNER JOIN dbo.KbKostenstelle_BaPerson KSP1 WITH (READUNCOMMITTED)
                                                              ON KSP1.KbKostenstelleID = BKO.KbKostenstelleID
                                                              AND KSP1.BaPersonID = BKO.BaPersonID
                                                              AND (ISNULL(KSP1.DatumVon, '17530101') > BUC.BelegDatum
                                                                OR ISNULL(KSP1.DatumBis, '99991231') < BUC.BelegDatum)
                  INNER JOIN dbo.KbKostenstelle          KST1 WITH (READUNCOMMITTED)
                                                              ON KST1.KbKostenstelleID = KSP1.KbKostenstelleID
                  LEFT  JOIN dbo.KbKostenstelle_BaPerson KSP2 WITH (READUNCOMMITTED)
                                                              ON KSP2.BaPersonID = BKO.BaPersonID
                                                              AND KSP2.KbKostenstelleBaPersonID <> KSP1.KbKostenstelleBaPersonID
                                                              AND ISNULL(KSP2.DatumVon, '17530101') <= BUC.BelegDatum
                                                              AND ISNULL(KSP2.DatumBis, '99991231') >= BUC.BelegDatum
                  LEFT  JOIN dbo.KbKostenstelle          KST2 WITH (READUNCOMMITTED)
                                                              ON KST2.KbKostenstelleID = KSP2.KbKostenstelleID
                WHERE 1=1
                  ---  AND BUC.BelegDatum >= {edtBelegDatumVon}
                  ---  AND BUC.BelegDatum <= {edtBelegDatumBis}
                  ---  AND BUC.BelegNr = {edtBelegNr}
                  ---  AND BUC.KbBuchungID = {edtKbBuchungID}
                  ---  AND BUC.KbPeriodeID = {edtKbPeriodeID}
                ;";
        }

        private static void InitializeLov(KissLookUpEdit edt, SqlQuery qry)
        {
            const string colText = "Text";

            if (edt.AllowNull)
            {
                var newRow = qry.DataTable.NewRow();
                newRow[colText] = "";
                qry.DataTable.Rows.InsertAt(newRow, 0);
                newRow.AcceptChanges();
            }

            edt.Properties.Columns.Clear();
            edt.Properties.Columns.AddRange(
                new[]
                {
                    new LookUpColumnInfo(colText, "", 75, FormatType.None, "", true, HorzAlignment.Default)
                });
            edt.Properties.ShowFooter = false;
            edt.Properties.ShowHeader = false;
            edt.Properties.DisplayMember = colText;
            edt.Properties.ValueMember = "Code";
            edt.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edt.Properties.DataSource = qry;
        }

        #endregion

        #region Private Methods

        private void AddRelationKbBuchungKbBuchungKostenart()
        {
            grdQuery1.DataSource = null;

            var dataSet = qryQuery.DataSet;
            dataSet.EnforceConstraints = false;
            dataSet.Relations.Add(
                "Detail",
                dataSet.Tables[0].Columns[DBO.KbBuchung.KbBuchungID],
                dataSet.Tables[1].Columns[DBO.KbBuchungKostenart.KbBuchungID]);

            grdQuery1.DataSource = qryQuery;
        }

        private string GetSelectVergleichBilanzErKostenarten()
        {
            string returnSelect = "";

            // BilanzEr für die gewünschten Kostenarten-KontoNr suchen
            var qryBilanzEr = DBUtil.OpenSQL(@"
                DECLARE @BilanzEr TABLE
                (
                  InstName       VARCHAR(200),
                  InstStrasse    VARCHAR(200),
                  InstPLZOrt     VARCHAR(200),
                  Parameter      VARCHAR(200),
                  DruckDatum     VARCHAR(200),
                  DatumVon       DATETIME,
                  DatumBis       DATETIME,

                  KbKontoID      INT,
                  GruppeKontoID  INT,
                  Kontogruppe    BIT,
                  KbKontoklasseCode INT,
                  KbKontoklasseCodeSub INT,
                  BilanzErCode   INT,
                  Konto          VARCHAR(100),
                  KontoNr        VARCHAR(10),
                  KontoName      VARCHAR(120),
                  Aufwand        MONEY,
                  Ertrag         MONEY,

                  Anfangsbestand MONEY,
                  Endbestand     MONEY,
                  Zuwachs        MONEY,
                  Abgang         MONEY,

                  Umsatz         MONEY,
                  Saldo          MONEY,
                  Vorsaldo       MONEY,
                  Total          MONEY,
                  IconIndex      INT,
                  BilanzER       VARCHAR(50)
                );

                INSERT INTO @BilanzEr
                exec spKbGetBilanzErfolg {0},{1},{2},1,1

                SELECT
                  KontoNr,
                  Umsatz,
                  Saldo
                FROM @BilanzEr
                WHERE KontoNr IN (SELECT KontoNr
                                  FROM dbo.BgKostenart)
                  AND ({3} IS NULL OR KontoNr = {3})",
                edtKbPeriodeID.EditValue,
                edtBelegDatumVon.EditValue,
                edtBelegDatumBis.EditValue,
                edtKostenartKontoNr.EditValue);

            // Kostenarten-Statement vorbereiten
            string selectKostenarten = KliBuUtil.SELECT_KOSTENARTEN;

            if (!DBUtil.IsEmpty(edtBelegDatumVon.EditValue))
            {
                selectKostenarten = selectKostenarten.Replace("{edtDatumVonX}", DBUtil.SqlLiteral(edtBelegDatumVon.EditValue));
            }

            if(!DBUtil.IsEmpty(edtBelegDatumBis.EditValue))
            {
                selectKostenarten = selectKostenarten.Replace("{edtDatumBisX}", DBUtil.SqlLiteral(edtBelegDatumBis.EditValue));
            }

            foreach (DataRow row in qryBilanzEr.DataTable.Rows)
            {
                string kontoNr = DBUtil.SqlLiteral(row["KontoNr"].ToString());
                string selectKostenartMitKontoNr = selectKostenarten
                    .Replace("{edtKostenartNrVon}", kontoNr)
                    .Replace("{edtKostenartNrBis}", kontoNr);

                var qryKostenart = new SqlQuery();
                qryKostenart.FillTimeOut = 300;
                qryKostenart.Fill(
                    KissSearch.ActivateLinesWithParameter(selectKostenartMitKontoNr),
                    edtKbPeriodeID.EditValue);

                decimal betrag = qryKostenart.DataTable.Rows.Cast<DataRow>().Sum(rowKostenart => (decimal)rowKostenart["Betrag"]);

                if (!string.IsNullOrEmpty(returnSelect))
                {
                    returnSelect += " UNION ALL " + Environment.NewLine;
                }

                returnSelect += string.Format(
                    @"SELECT
                        DatumVon        = {0},
                        DatumBis        = {1},
                        KontoNr         = {2},
                        BilanzErUmsatz  = {3},
                        KostenartBetrag = {4},
                        IstDifferent    = CASE WHEN {3} = {4} THEN CONVERT(BIT, 0) ELSE CONVERT(BIT, 1) END,
                        Differenz       = {3} - {4}",
                    DBUtil.SqlLiteral(edtBelegDatumVon.EditValue),
                    DBUtil.SqlLiteral(edtBelegDatumBis.EditValue),
                    kontoNr,
                    row["Umsatz"] as decimal? ?? 0,
                    betrag);
            }

            return returnSelect;
        }

        private string GetSelectVergleichBilanzErSozialhilferechnung()
        {
            // Aufwand und Ertrag der Sozialhilferechnung berechnen
            string selectSozialhilferechnung = KliBuUtil.SELECT_SOZIALHILFERECHNUNG;
            if(!DBUtil.IsEmpty(edtBelegDatumVon.EditValue))
            {
                selectSozialhilferechnung.Replace("{edtDatumVonX}", DBUtil.SqlLiteral(edtBelegDatumVon.EditValue));
            }

            if (!DBUtil.IsEmpty(edtBelegDatumBis.EditValue))
            {
                selectSozialhilferechnung.Replace("{edtDatumBisX}", DBUtil.SqlLiteral(edtBelegDatumBis.EditValue));
            }

            selectSozialhilferechnung = KissSearch.ActivateLinesWithParameter(selectSozialhilferechnung);

            var qrySozialhilferechnung = new SqlQuery();
            qrySozialhilferechnung.FillTimeOut = 300;
            qrySozialhilferechnung.Fill(
                selectSozialhilferechnung,
                edtKbPeriodeID.EditValue,
                Session.User.LanguageCode);

            decimal aufwand = 0;
            decimal ertrag = 0;

            foreach (DataRow row in qrySozialhilferechnung.DataTable.Rows)
            {
                aufwand += (decimal)row["Aufwand"];
                ertrag += (decimal)row["Ertrag"];
            }

            // Total des Ausgabe- und Einnahme-Konti berechnen
            var qryBilanzEr = DBUtil.OpenSQL(@"
                DECLARE @BilanzEr TABLE
                (
                  InstName       VARCHAR(200),
                  InstStrasse    VARCHAR(200),
                  InstPLZOrt     VARCHAR(200),
                  Parameter      VARCHAR(200),
                  DruckDatum     VARCHAR(200),
                  DatumVon       DATETIME,
                  DatumBis       DATETIME,

                  KbKontoID      INT,
                  GruppeKontoID  INT,
                  Kontogruppe    BIT,
                  KbKontoklasseCode INT,
                  KbKontoklasseCodeSub INT,
                  BilanzErCode   INT,
                  Konto          VARCHAR(100),
                  KontoNr        VARCHAR(10),
                  KontoName      VARCHAR(120),
                  Aufwand        MONEY,
                  Ertrag         MONEY,

                  Anfangsbestand MONEY,
                  Endbestand     MONEY,
                  Zuwachs        MONEY,
                  Abgang         MONEY,

                  Umsatz         MONEY,
                  Saldo          MONEY,
                  Vorsaldo       MONEY,
                  Total          MONEY,
                  IconIndex      INT,
                  BilanzER       VARCHAR(50)
                );

                INSERT INTO @BilanzEr
                EXEC spKbGetBilanzErfolg {0},{1},{2},1,1

                SELECT
                  Ausgaben  = SUM(CASE WHEN KontoNr = '3' THEN ISNULL(Total, 0) ELSE 0 END),
                  Einnahmen = SUM(CASE WHEN KontoNr = '4' THEN ISNULL(Total, 0) ELSE 0 END)
                FROM @BilanzEr",
                edtKbPeriodeID.EditValue,
                edtBelegDatumVon.EditValue,
                edtBelegDatumBis.EditValue);

            return string.Format(@"
                SELECT
                  DatumVon            = {0},
                  DatumBis            = {1},
                  Ausgaben            = {2},
                  Aufwand             = {3},
                  IstDifferentAufwand = CASE WHEN {2} = {3} THEN CONVERT(BIT, 0) ELSE CONVERT(BIT, 1) END,
                  DiffAusgabenAufwand = {2} - {3},
                  Einnahmen           = {4},
                  Ertrag              = {5},
                  IstDifferentErtrag  = CASE WHEN {4} = {5} THEN CONVERT(BIT, 0) ELSE CONVERT(BIT, 1) END,
                  DiffEinnamenErtrag  = {4} - {5}",
                DBUtil.SqlLiteral(edtBelegDatumVon.EditValue),
                DBUtil.SqlLiteral(edtBelegDatumBis.EditValue),
                Convert.ToDecimal(DBUtil.IsEmpty(qryBilanzEr["Ausgaben"]) ? 0 : qryBilanzEr["Ausgaben"]),
                aufwand,
                -Convert.ToDecimal(DBUtil.IsEmpty(qryBilanzEr["Einnahmen"]) ? 0 : qryBilanzEr["Einnahmen"]),
                ertrag);
        }

        private void InitializeControllingType()
        {
            var qry = DBUtil.OpenSQL(@"
                SELECT Code = 1, Text = 'Belegdatum (Periode unabhängig)' UNION ALL
                SELECT Code = 2, Text = 'BUC.Betrag != SUM(BKO.Betrag)' UNION ALL
                SELECT Code = 3, Text = 'Kostenart-KontoNr im Soll/Haben' UNION ALL
                SELECT Code = 4, Text = 'KbBuchungKostenart fehlt' UNION ALL
                SELECT Code = 5, Text = 'Kostenstelle ist nicht mehr gültig' UNION ALL
                SELECT Code = 6, Text = 'Vergleich BilanzER und Sozialhilferechnung' UNION ALL
                SELECT Code = 7, Text = 'Vergleich BilanzER und Kostenarten';");

            InitializeLov(edtControllingType, qry);
        }

        private void InitializeKbPeriode()
        {
            var qry = DBUtil.OpenSQL(@"
                SELECT
                  Code = KbPeriodeID,
                  Text = CONVERT(VARCHAR, PeriodeVon, 104) + ' - ' + CONVERT(VARCHAR, PeriodeBis, 104) + ' (' + CONVERT(VARCHAR, KbPeriodeID) + ')'
                FROM dbo.KbPeriode WITH (READUNCOMMITTED)
                WHERE KbMandantID = 1
                  AND KbPeriodeID >= dbo.fnXConfig('System\KliBu\KliBuIntegriertSeitPeriode', GETDATE());");

            InitializeLov(edtKbPeriodeID, qry);
        }

        private void SetSelectStatement()
        {
            ControllingType type;

            if (Enum.IsDefined(typeof(ControllingType), edtControllingType.EditValue as int? ?? 0))
            {
                type = (ControllingType)((int)edtControllingType.EditValue);
            }
            else
            {
                type = ControllingType.BelegDatumOhnePeriode;
            }

            switch (type)
            {
                case ControllingType.BelegDatumOhnePeriode:
                    kissSearch.SelectStatement = GetSelectBelegDatumOhnePeriode();
                    break;

                case ControllingType.BetragDifferenz:
                    kissSearch.SelectStatement = GetSelectBetragDifferenz();
                    break;

                case ControllingType.KostenartKontoNrImSollHaben:
                    kissSearch.SelectStatement = GetSelectKostenartKontoNrImSollHaben();
                    break;

                case ControllingType.KostenartFehlt:
                    kissSearch.SelectStatement = GetSelectKostenartFehlt();
                    break;

                case ControllingType.KostenstelleUngueltig:
                    kissSearch.SelectStatement = GetSelectKostenstelleUngueltig();
                    break;

                case ControllingType.VergleichBilanzErSozialhilferechnung:
                    kissSearch.SelectStatement = GetSelectVergleichBilanzErSozialhilferechnung();
                    break;

                case ControllingType.VergleichBilanzErKostenarten:
                    kissSearch.SelectStatement = GetSelectVergleichBilanzErKostenarten();
                    break;
            }

            grdQuery1.DataSource = null;
            grvQuery1.Columns.Clear();
            qryQuery.DataSet.Relations.Clear();

            foreach (DataTable table in qryQuery.DataSet.Tables)
            {
                table.Constraints.Clear();
            }

            qryQuery.DataTable.Columns.Clear();
        }

        #endregion

        #endregion
    }
}