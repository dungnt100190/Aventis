using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using log4net;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using DevExpress.XtraGrid.Views.Base;

namespace KiSS4.Klientenbuchhaltung
{
    public partial class CtlKbTransfer : KissSearchUserControl
    {
        #region Fields

        #region Private Static Fields

        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private int _kbPeriodeID;

        #endregion

        #endregion

        #region Constructors

        public CtlKbTransfer()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnBezahlt_Click(object sender, EventArgs e)
        {
            // validate BelegDatum and BelegNr using db-functions
            bool isBelegDatumValid = DBUtil.ExecuteScalarSQLThrowingException(@"SELECT dbo.fnKbCheckBelegDatum({0}, {1})", _kbPeriodeID, edtBelegdatum.EditValue) as bool? ?? false;

            if (DBUtil.IsEmpty(edtBelegdatum.EditValue) || edtBelegdatum.EditValue.ToString() == "")
            {
                KissMsg.ShowInfo("Das Feld 'Bezahlt am' darf nicht leer bleiben.");
                edtBelegdatum.Focus();
                return;
            }

            // check if BelegDatum and BelegNr are valid
            if (!isBelegDatumValid)
            {
                // invalid BelegDatum
                KissMsg.ShowInfo(string.Format("Das eingegebene 'Bezahlt am'-Datum ist ungültig für das aktuelle Budget und die zugehörige Periode (ID={0}).", _kbPeriodeID));
                edtBelegdatum.Focus();
                return;
            }

            Int32 kbZahlungskontoID = Utils.ConvertToInt(qryZahlungslauf["KbZahlungskontoID"]);

            Debug.WriteLine("qryAktivKonto.Fill: Periode = " + _kbPeriodeID.ToString() + "ZahlungskontoId = " + kbZahlungskontoID.ToString());

            qryAktivKonto.Fill(_kbPeriodeID, kbZahlungskontoID);

            String aktivKonto = Utils.ConvertToString(qryAktivKonto["KontoNr"]);
            Debug.WriteLine("aktivKonto = " + aktivKonto);

            Cursor = Cursors.WaitCursor;
            StringBuilder sqlErrorMsg = new StringBuilder();
            try
            {
                foreach (DataRow buchung in qryBuchung.DataTable.Rows)
                {
                    try
                    {
                        Boolean isSelected = Utils.ConvertToBool(buchung["Auswaehlen"]);
                        Boolean isErstellt = Utils.ConvertToInt(buchung["KbBuchungStatusCode"]) == 3;

                        if (isSelected && isErstellt)
                        {
                            Session.BeginTransaction();
                            Int32 buchungId = Utils.ConvertToInt(buchung["KbBuchungId"]);
                            Int32 zahlungslaufId = Utils.ConvertToInt(buchung["KbZahlungslaufID"]);

                            Decimal betrag = Utils.ConvertToDecimal(buchung["Betrag"]);
                            String habenKtoNr = Utils.ConvertToString(buchung["HabenKtoNr"]);

                            Int32 ausgleichBuchungId = Balance.ErstelleAusgleichsBuchung(
                                betrag,
                                habenKtoNr,
                                aktivKonto,
                                _kbPeriodeID,
                                (DateTime)edtBelegdatum.EditValue);

                            Int32 ausgleichId = Balance.ErstelleAusgleichEintrag(
                                buchungId,
                                ausgleichBuchungId,
                                betrag);

                            // --- markiere Buchung als 'Ausgeglichen'.
                            Balance.AktualisiereBuchungsStatus(
                                buchungId,
                                6);

                            // --- markiere Transfer als Bezahlt
                            Balance.AktualisiereTransferStatus(
                                buchungId,
                                zahlungslaufId,
                                3);

                            // --- falls arzt buchung, dann fordere geld zurück
                            Debug.WriteLine("EXEC dbo.spKbErstelle_Rueckforderung_Krankenkasse für Buchung " + buchungId.ToString());
                            DBUtil.ExecSQLThrowingException(@"EXEC dbo.spKbErstelle_Rueckforderung_Krankenkasse {0}", buchungId);

                            Session.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        Session.Rollback();
                        //Fehlermeldung merken
                        sqlErrorMsg.AppendLine(
                            "Belegnummer: " + buchung["BelegNr"] + " Budget-Nr: " + buchung["BgBudgetID"] + " Monat.Jahr: " + buchung["BudgetMonatJahr"] + " Finanzplan: FP" +
                            buchung["BgFinanzplanID"] + " Grund: " + ex.Message);
                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;
                if (sqlErrorMsg.Length > 0)
                {
                    //endgültige Fehlermeldung erstellen und ausgeben
                    var finalMsg = new StringBuilder();
                    finalMsg.AppendLine("Folgende Zahlungen können nicht ausgeglichen werden: ");
                    finalMsg.Append(sqlErrorMsg.ToString());
                    finalMsg.AppendLine("Entsperren Sie zum Ausgleichen diese(s) Budget(s) und versuchen Sie es bitte erneut.");
                    KissMsg.ShowInfo(finalMsg.ToString());
                }
            }

            Refresh();
        }

        private void btnFehlerhaft_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in qryBuchung.DataTable.Rows)
            {
                Boolean isSelected = Utils.ConvertToBool(row["Auswaehlen"]);
                Boolean isErstellt = Utils.ConvertToInt(row["KbBuchungStatusCode"]) == 3;

                if (isSelected && isErstellt)
                {
                    Int32 buchungId = Utils.ConvertToInt(row["KbBuchungId"]);
                    Int32 zahlungslaufId = Utils.ConvertToInt(row["KbZahlungslaufID"]);

                    // --- markiere Buchung als ZahlauftragFehlerhaft
                    Balance.AktualisiereBuchungsStatus(
                        buchungId,
                        5);

                    Balance.AktualisiereTransferStatus(
                        buchungId,
                        zahlungslaufId,
                        4);
                }
                else
                {
                    Debug.WriteLine("row ignored");
                }
            }

            Refresh();
        }

        private void btnUebermittelteAuswaehlen_Click(object sender, EventArgs e)
        {
            SelectAllUebermitteltRows(true);
            CalculateTotal();
        }

        private void btnUebermittelteEntfernen_Click(object sender, EventArgs e)
        {
            SelectAllUebermitteltRows(false);
            CalculateTotal();
        }

        private void CtlKbTransfer_Load(object sender, EventArgs e)
        {
            colBuchungStatus.ColumnEdit = grdKbBuchung.GetLOVLookUpEdit("KbTransferStatus");
            try
            {
                _kbPeriodeID = (int)FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbPeriodeID");
            }
            catch
            {
                Debug.WriteLine("CtlKbTransfer.DEBUG: SET KbPeriodeID");
                _kbPeriodeID = 36;
            }

            kissSearch.SelectParameters = new object[] { _kbPeriodeID };

            qryZahlungskonto.Fill();
            editEZugangX.LoadQuery(qryZahlungskonto);

            //hack zweimal wechseln, damit Suchliste angezeigt wird. weiss nicht warum
            tabControlSearch.SelectTab(tpgSuchen);
            tabControlSearch.SelectTab(tpgListe);

            RunSearch();
        }
        private void edtErfasserX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (String.IsNullOrEmpty(edtErfasserX.Text))
            {
                edtErfasserX.EditValue = null;
                edtErfasserX.LookupID = null;
                return;
            }

            var dlg = new DlgAuswahl();

            e.Cancel = !dlg.MitarbeiterSuchen(edtErfasserX.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                edtErfasserX.EditValue = Utils.ConvertToString(dlg["Name"]);
                edtErfasserX.LookupID = Utils.ConvertToInt(dlg["UserID"]);
            }
        }

        private void grdZahllauf_Click(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void grvKbBuchung_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column != colBuchungAuswahl)
            {
                return;
            }

            grvKbBuchung.SetRowCellValue(e.RowHandle, colBuchungAuswahl, e.Value);
            CalculateTotal();
        }

        private void grvKbBuchung_CustomDrawCell(Object sender, RowCellCustomDrawEventArgs e)
        {
            try
            {
                int transferStatusCode = (int)grvKbBuchung.GetRowCellValue(e.RowHandle, grvKbBuchung.Columns["KbTransferStatusCode"]);
                e.Appearance.BackColor = Color.LightYellow;

                if (transferStatusCode == 3) // bezahlt
                {
                    e.Appearance.BackColor = Color.LightGreen;
                }
                else if (transferStatusCode == 4) //fehlerhaft
                {
                    e.Appearance.BackColor = Color.LightSalmon;
                }
            }
            catch (Exception ex)
            {
                // Eintrag ins Log.
                _log.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);
                XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);
            }
        }

        private void grvKbBuchung_ShowingEditor(object sender, CancelEventArgs e)
        {
            //editor nur zeigen für übermittelte Buchungen
            e.Cancel = Convert.ToInt32(qryBuchung["KbTransferStatusCode"]) != 2;
        }

        private void qryBuchung_PositionChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void qryZahlungslauf_PositionChanged(object sender, EventArgs e)
        {
            qryBuchung.Fill(qryZahlungslauf["KbZahlungslaufId"]);
            EnableButtons();
            CalculateTotal();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override String GetContextName()
        {
            return "CtlKbTransfer";
        }

        public override object GetContextValue(string fieldName)
        {
            object context;

            switch (fieldName.ToUpper())
            {
                case "ZAHLUNGSLAUFID":
                    context = qryZahlungslauf["KbZahlungslaufID"];
                    break;

                default:
                    context = base.GetContextValue(fieldName);
                    break;
            }

            return context;
        }

        #endregion

        #region Private Methods

        private void CalculateTotal()
        {
            int count = 0;
            decimal total = 0;

            foreach (DataRow row in qryBuchung.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Auswaehlen"]) && (bool)row["Auswaehlen"])
                {
                    count++;
                    total += Utils.ConvertToDecimal(row["Betrag"]);
                }
            }

            edtTotal.EditValue = total;
            edtAnzahl.EditValue = count;
        }

        ///<summary>
        ///
        ///</summary>
        private void EnableButtons()
        {
            Boolean enabled = true;

            String journalStatus = Utils.ConvertToString(qryZahlungslauf["JournalStatus"]);
            Boolean istAbgeschlossen = journalStatus.Contains("abgeschlossen");

            if (istAbgeschlossen)
            {
                enabled = false;
            }

            btnBezahlt.Enabled = enabled;
            btnFehlerhaft.Enabled = enabled;
        }

        private new void Refresh()
        {
            qryZahlungslauf.Refresh();
            qryBuchung.Fill(qryZahlungslauf["KbZahlungslaufId"]);

            grdKbBuchung.Refresh();
            CalculateTotal();
        }

        private void SelectAllUebermitteltRows(bool select)
        {
            Cursor = Cursors.WaitCursor;

            foreach (DataRow row in qryBuchung.DataTable.Rows)
            {
                bool isUebermittelt = Utils.ConvertToInt(row["KbTransferStatusCode"]) == 2;

                if (isUebermittelt)
                {
                    row["Auswaehlen"] = select;
                }
            }

            Cursor = Cursors.Default;
        }

        #endregion

        #endregion
    }
}