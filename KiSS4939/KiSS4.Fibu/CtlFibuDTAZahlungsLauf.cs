using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Schnittstellen.DTA_EZAG;

namespace KiSS4.Fibu
{
    //public enum mode
    //{
    //   TCPIP,
    //   Yellownet
    //}
    // TODO 3 GF ZahlungsFrist einbauen. Wird jetzt nur gespeichert aber nicht in die Buchungen gebraucht.
    /// <summary>
    /// Summary description for CtlFibuDTAZahlungsLauf.
    /// </summary>
    public partial class CtlFibuDTAZahlungsLauf : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly SqlQuery _qryEZugang;

        #endregion

        #region Private Fields

        private bool _select = true;

        private string sqlBuchungInErwartung = @"
            SELECT
              VDB.*,
              DTAClearingNr  = BNK.ClearingNr,
              Uebermitteln   = convert(bit,1),
              AuftragsNummer = 0
            FROM dbo.viewDTAFbBuchungen VDB
              LEFT JOIN dbo.BaBank BNK on BNK.BaBankID = VDB.DTABankID
            WHERE (VDB.FbDTAJournalId = (SELECT MAX(FbDTAJournalID)
                                         FROM dbo.FbDTABuchung
                                         WHERE FbDTABuchung.FbBuchungID = VDB.FbBuchungID)
                                            OR (VDB.FbDTAJournalId IS NULL AND
                                                (SELECT MAX(FbDTAJournalID)
                                                 FROM dbo.FbDTABuchung
                                                 WHERE FbDTABuchung.FbBuchungID = VDB.FbBuchungID) IS NULL))
              AND (VDB.Status = 4 OR VDB.Status IS NULL) ";

        #endregion

        #endregion

        #region Constructors

        public CtlFibuDTAZahlungsLauf()
        {
            InitializeComponent();

            grdErwartung.View.Columns["KontoNr"].DisplayFormat.Format = new GridColumnPCKontoFormatter();

            _qryEZugang = DBUtil.OpenSQL(@"
                select	FbDTAZugangID, Name, KontoNr, '' AS Text
                from	FbDTAZugang ZUG
                        left join FbTeamMitglied MIT on MIT.FbTeamID = ZUG.FbTeamID and
                                                        MIT.UserID = {0}
                where   ZUG.FbTeamID is null OR MIT.UserID is not null
                union all
                select null,'','',''
                order by Name",
                Session.User.UserID);

            foreach (DataRow dr in _qryEZugang.DataTable.Rows)
            {
                if (dr["Name"] != DBNull.Value)
                {
                    dr["Text"] = dr["Name"] + " - " + Utils.FormatPCKontoNummerToUserFormat(dr["KontoNr"].ToString());
                    dr.AcceptChanges();
                }
            }

            cboEZugang.Properties.DataSource = _qryEZugang;
            cboEZugang.Properties.DisplayMember = "Text";
            cboEZugang.Properties.ValueMember = "FbDTAZugangID";

            if (_qryEZugang.Count > 1 && _qryEZugang.Count < 10)
            {
                cboEZugang.EditValue = _qryEZugang.DataTable.Rows[1]["FbDTAZugangID"];
            }

            ValutaDatumBis.DateTime = DateTime.Today;

            DisplayData();
        }

        #endregion

        #region EventHandlers

        private void btnAlleEntfernen_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            qryDTABuchungErwartung.First();
            do
            {
                qryDTABuchungErwartung["Uebermitteln"] = _select;
                //qryDTABuchungErwartung.Row.AcceptChanges() ;
            }
            while (qryDTABuchungErwartung.Next());

            qryDTABuchungErwartung.RefreshDisplay();

            _select = !_select;

            btnAlleEntfernen.Text = _select ? KissMsg.GetMLMessage("CtlFibuDTAZahlungsLauf", "btnAlleEntfernen1", "Alle auswählen") : KissMsg.GetMLMessage("CtlFibuDTAZahlungsLauf", "btnAlleEntfernen", "Alle entfernen");

            Cursor = Cursors.Default;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool generiert = false;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                qryDTABuchungErwartung.First();

                bool valid = false;
                bool anyEZAG = false;

                //Haben wir mind. einen EZAG-Auftrag?
                foreach (DataRow dr in qryDTABuchungErwartung.DataTable.Rows)
                {
                    if (Convert.ToBoolean(dr["Uebermitteln"]))
                    {
                        valid = true;
                    }

                    if (Convert.ToInt32(dr["KbFinanzInstitutCode"]) == (int)Utilities.KbFinanzInstitutCode.Ezag)
                    {
                        anyEZAG = true;
                    }
                }

                //EZAG-Aufträge haben offenbar ein eigenes Valuta-Datum, welches vom Benutzer eingegeben wird.
                //Offene Frage: woher kommt das Valuta-Datum bei einer DTA-Zahlung?
                DateTime ausfuehrungsDatumEZAG = ValutaDatumBis.DateTime;
                if (anyEZAG)
                {
                    using (var dlg = new DlgYellownetValutaDatum(ValutaDatumBis.DateTime))
                    {
                        if (valid && dlg.ShowDialog() == DialogResult.OK && dlg.AusfuehrungsDatum > DateTime.MinValue)
                        {
                            ausfuehrungsDatumEZAG = dlg.AusfuehrungsDatum;
                        }
                        else
                        {
                            grdErwartung.Focus();
                            return;
                        }
                    }
                }

                if (!KissMsg.ShowQuestion("CtlFibuDTAZahlungsLauf", "ZahlungsauftragErzeugen", "Zahlungsauftrag erzeugen?"))
                {
                    grdErwartung.Focus();
                    return;
                }

                Session.BeginTransaction();

                FibuPaymentManager paymentManager = new FibuPaymentManager(qryDTABuchungErwartung, ausfuehrungsDatumEZAG);
                string fehler;

                try
                {
                    fehler = paymentManager.CreateOrders();

                    generiert = paymentManager.CreateFiles(ValutaDatumBis.DateTime);

                    Session.Commit();
                }
                catch (Exception)
                {
                    generiert = false;

                    if (Session.Transaction != null)
                    {
                        Session.Rollback();
                    }

                    throw;
                }

                qryDTABuchungErwartung.Fill(
                    sqlBuchungInErwartung +
                    " AND ValutaDatum <= " +
                    DBUtil.SqlLiteral(ValutaDatumBis.DateTime) +
                    " AND FbDTAZugangId = " + DBUtil.SqlLiteral(cboEZugang.EditValue) +
                    " ORDER BY DTABankID,FbDTAZugangId, ValutaDatum ");

                Cursor.Current = Cursors.Default;

                IList<DtaOrder> dtaOrders = paymentManager.DtaOrders;
                IList<EzagOrder> ezagOrders = paymentManager.EzagOrders;
                IList<Iso20022Order> isoOrders = paymentManager.Iso20022Orders;

                if (dtaOrders.Count > 0 && ezagOrders.Count > 0)
                {
                    KissMsg.ShowInfo("CtlFibuDTAZahlungsLauf", "AuftraegeErfolgreichGeneriert", "Zahlungsaufträge erfolgreich generiert :\r\nPost Aufträge : {0}\r\nBank Aufträge : {1}", 0, 0, ezagOrders.Count.ToString(), dtaOrders.Count.ToString());
                }
                else if (dtaOrders.Count > 0)
                {
                    if (dtaOrders.Count == 1)
                    {
                        DlgEzagInfo.Show(string.Format("Zahlungsauftrag erfolgreich generiert:\r\nBuchungen: {0}\r\nTotal Betrag: {1:C}", dtaOrders[0].Count, dtaOrders[0].TotalBetrag), fehler);
                    }
                    else
                    {
                        DlgEzagInfo.Show(string.Format("Zahlungsaufträge erfolgreich generiert:\r\nBank Aufträge: {0}", dtaOrders.Count), fehler);
                    }
                }
                else if (ezagOrders.Count > 0)
                {
                    if (ezagOrders.Count == 1)
                    {
                        DlgEzagInfo.Show(string.Format("Zahlungsauftrag erfolgreich generiert:\r\nBuchungen: {0}\r\nTotal Betrag: {1:C}", ezagOrders[0].Count, ezagOrders[0].TotalBetrag), fehler);
                    }
                    else
                    {
                        DlgEzagInfo.Show(string.Format("Zahlungsaufträge erfolgreich generiert:\r\nPost Aufträge: {0}", ezagOrders.Count), fehler);
                    }
                }
                else if (isoOrders.Count > 0)
                {
                    if (isoOrders.Count == 1)
                    {
                        DlgEzagInfo.Show(string.Format("Zahlungsauftrag erfolgreich generiert:\r\nBuchungen: {0}\r\nTotal Betrag: {1:C}", isoOrders[0].RecordCount, isoOrders[0].TotalBetrag), fehler);
                    }
                    else
                    {
                        DlgEzagInfo.Show(string.Format("Zahlungsaufträge erfolgreich generiert:\r\nISO 20022 Aufträge: {0}", isoOrders.Count), fehler);
                    }
                }
            }
            catch (PaymentFatalException ex)
            {
                if (!generiert)
                    KissMsg.ShowError("CtlFibuDTAZahlungsLauf", "ZahlungsauftragNichtGeneriert", "Fehler bei der Bearbeitung des Zahlungsauftrags. Der Zahlungsauftrag konnte nicht generiert werden\r\n{0}", ex.Message, ex, 0, 0, ex.Message);
                else
                    KissMsg.ShowError("CtlFibuDTAZahlungsLauf", "ZahlungsauftragTrotzFehlerGeneriert", "Fehler bei der Bearbeitung des Zahlungsauftrags. Der Zahlungsauftrag wurde trotzdem generiert\r\n{0}", ex.Message, ex, 0, 0, ex.Message);
            }
            catch (Exception ex)
            {
                if (!generiert)
                    KissMsg.ShowError("CtlFibuDTAZahlungsLauf", "ZahlungsauftragNichtGeneriert", "Fehler bei der Bearbeitung des Zahlungsauftrags. Der Zahlungsauftrag konnte nicht generiert werden\r\n{0}", ex.Message, ex, 0, 0, ex.Message);
                else
                    KissMsg.ShowError("CtlFibuDTAZahlungsLauf", "ZahlungsauftragTrotzFehlerGeneriert", "Fehler bei der Bearbeitung des Zahlungsauftrags. Der Zahlungsauftrag wurde trotzdem generiert", ex.Message, ex, 0, 0, ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnSuchen_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void CtlFibuDTAZahlungsLauf_RefreshData(object sender, EventArgs e)
        {
            _qryEZugang.Refresh();
        }

        private void SetupGrid()
        {
            grdErwartung.SetColumnEditable(colBeguenstigter, false);
            grdErwartung.SetColumnEditable(colBelegNr, false);
            grdErwartung.SetColumnEditable(colBetrag, false);
            grdErwartung.SetColumnEditable(colDTAZugang, false);
            grdErwartung.SetColumnEditable(colKonto, false);
            grdErwartung.SetColumnEditable(colKontoName, false);
            grdErwartung.SetColumnEditable(colMandant, false);
            grdErwartung.SetColumnEditable(colStatus, false);
            grdErwartung.SetColumnEditable(colUebermitteln, true);
            grdErwartung.SetColumnEditable(colValuta, false);
            grdErwartung.SetColumnEditable(colZahlungsgrund, false);
            grdErwartung.SetSelectionColor(false);
        }

        #endregion

        #region Methods

        #region Public Methods

        public override string GetContextName()
        {
            return "VmFibu";
        }

        /// <summary>
        /// Sends files trough Swox
        /// </summary>
        /// <param name="jobCode">Ezag or DTA</param>
        /// <param name="fileName">Path to the local file to send</param>
        /// <param name="swoxId">Swox Security ID to allow batch call, Set Under Swox->Options</param>
        public void SwoxSend(string jobCode, string fileName, string swoxId)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("Swox.exe");

                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;

                startInfo.Arguments = "/JOB=" + jobCode + " " + fileName + " " + swoxId;

                Process test = Process.Start(startInfo);

                int exitCode = test.ExitCode;

                if (exitCode != 0)
                {
                    KissMsg.ShowInfo("CtlFibuDTAZahlungsLauf", "FehlerUebermittlung", "Fehler bei der Übermittlung des Zahlungsauftrags. => Swox starten und die Fehlerliste anschauen");
                }
            }
            catch (Exception e)
            {
                KissMsg.ShowError("CtlFibuDTAZahlungsLauf", "FehlerUebermittlungAuftrag", "Fehler bei der Übermittlung des Zahlungsauftrags", e.Message, e);
            }
        }

        #endregion

        #region Private Methods

        private void DisplayData()
        {
            Cursor = Cursors.WaitCursor;
            string sql = sqlBuchungInErwartung + " AND ValutaDatum <= " + DBUtil.SqlLiteral(ValutaDatumBis.DateTime);

            if (!DBUtil.IsEmpty(cboEZugang.EditValue))
            {
                sql += " and FbDTAZugangId = " + DBUtil.SqlLiteral(cboEZugang.EditValue) + " ";
            }

            sql += " ORDER BY DTABankID, FbDTAZugangId, ValutaDatum ";
            qryDTABuchungErwartung.Fill(sql);

            _select = false;
            btnAlleEntfernen.Text = KissMsg.GetMLMessage("CtlFibuDTAZahlungsLauf", "btnAlleEntfernen", "Alle entfernen"); ;

            Cursor = Cursors.Default;
        }

        #endregion

        private void grdErwartung_Click(object sender, EventArgs e)
        {
        }

        #endregion

        private void grdErwartung_Load(object sender, EventArgs e)
        {
            SetupGrid();
        }
    }
}