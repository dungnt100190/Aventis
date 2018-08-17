using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.DB;
using KiSS4.Messages;

namespace KiSS4.Vormundschaft.ZH
{
    internal class KgMassenverarbeitungsHelper
    {
        #region Fields

        #region Internal Fields

        private verarbeitungsDelegate verarbeitungsFunktion;

        #endregion

        #region Private Fields

        private string idColumnName;
        private Control mainControl;
        private string msgBeginnVerarbeitung;
        private string msgEineAuswahl;
        private string msgEndeVerarbeitung;
        private string msgFehlerVerarbeitung;
        private string msgKeineAuswahl;
        private string msgMehrereAuswahl;
        private string msgTitle;
        private string msgVerarbeiten;
        private SqlQuery qry;
        private int selectedCount = 0;

        #endregion

        #endregion

        #region Constructors

        internal KgMassenverarbeitungsHelper(SqlQuery qry, string idColumnName, verarbeitungsDelegate verarbeitungsFunktion)
        {
            this.qry = qry;
            this.mainControl = Session.MainForm;
            this.idColumnName = idColumnName;
            this.verarbeitungsFunktion = verarbeitungsFunktion;
        }

        #endregion

        #region Delegates

        internal delegate void verarbeitungsDelegate(DataRow row);

        #endregion

        #region Properties

        public string MsgBeginnVerarbeitung
        {
            get { return msgBeginnVerarbeitung; }
            set { msgBeginnVerarbeitung = value; }
        }

        public string MsgEineAuswahl
        {
            get { return msgEineAuswahl; }
            set { msgEineAuswahl = value; }
        }

        public string MsgEndeVerarbeitung
        {
            get { return msgEndeVerarbeitung; }
            set { msgEndeVerarbeitung = value; }
        }

        public string MsgFehlerVerarbeitung
        {
            get { return msgFehlerVerarbeitung; }
            set { msgFehlerVerarbeitung = value; }
        }

        public string MsgKeineAuswahl
        {
            get { return msgKeineAuswahl; }
            set { msgKeineAuswahl = value; }
        }

        public string MsgMehrereAuswahl
        {
            get { return msgMehrereAuswahl; }
            set { msgMehrereAuswahl = value; }
        }

        public string MsgTitle
        {
            get { return msgTitle; }
            set { msgTitle = value; }
        }

        public string MsgVerarbeiten
        {
            get { return msgVerarbeiten; }
            set { msgVerarbeiten = value; }
        }

        #endregion

        #region Methods

        #region Internal Methods

        internal static void DeleteKgPositionen(DataRow row)
        {
            if (Session.Transaction == null)
            {
                throw new Exception("Keine Transaktion offen.");
            }
            object kgBuchung = DBUtil.ExecuteScalarSQLThrowingException(@"SELECT TOP 1 KgBuchungID FROM KgBuchung BUC WHERE BUC.KgPositionID = {0}", row["KgPositionID"]);
            if (!DBUtil.IsEmpty(kgBuchung))
            {
                throw new Exception("Nur Positionen ohne Belege können gelöscht werden.");
            }
            DBUtil.ExecSQLThrowingException(@"
                            DELETE KgPositionValuta
                            WHERE KgPositionID = {0}
                                AND NOT EXISTS (SELECT KgBuchungID FROM KgBuchung BUC WHERE BUC.KgPositionID = {0})
                            DELETE KgBewilligung
                            WHERE KgPositionID = {0}
                                AND NOT EXISTS (SELECT KgBuchungID FROM KgBuchung BUC WHERE BUC.KgPositionID = {0})
                            DELETE KgPosition
                            WHERE KgPositionID = {0}
                                AND NOT EXISTS (SELECT KgBuchungID FROM KgBuchung BUC WHERE BUC.KgPositionID = {0})

                            ",
                row["KgPositionID"]);
        }

        internal void starteVerarbeitung()
        {
            if (!qry.Post())
            {
                return;
            }

            this.selectedCount = this.countSelected();

            if (this.selectedCount == 0)
            {
                KissMsg.ShowInfo(msgKeineAuswahl);
                return;
            }
            string msg = string.Empty;
            if (this.selectedCount == 1)
            {
                msg = msgEineAuswahl;
            }
            else
            {
                msg = string.Format(msgMehrereAuswahl, this.selectedCount);
            }
            if (KissMsg.ShowQuestion(msg))
            {
                mainControl.Cursor = Cursors.WaitCursor;
                DlgProgressLog.Show(msgTitle, 700, 500, new ProgressEventHandler(start), new ProgressEventHandler(end), Session.MainForm);
                mainControl.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region Private Methods

        private int countSelected()
        {
            int count = 0;
            foreach (DataRow R in qry.DataTable.Rows)
            {
                if (R.RowState != DataRowState.Detached && !DBUtil.IsEmpty(R["Sel"]) && (bool)R["Sel"])
                {
                    count++;
                }
            }
            return count;
        }

        private void end()
        {
        }

        private void start()
        {
            int count = 0;
            int countSuccessful = 0;
            DlgProgressLog.AddLine(msgBeginnVerarbeitung);
            DlgProgressLog.AddLine(string.Empty);

            //DataTable tableCopy = qryKgBuchung.DataTable.Clone();
            HashSet<int> failedKgPositionID = new HashSet<int>();
            foreach (DataRow row in qry.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Sel"]) && (bool)row["Sel"])
                {
                    count++;

                    DlgProgressLog.UpdateLastLine(String.Format(msgVerarbeiten, count, this.selectedCount));
                    ApplicationFacade.DoEvents();
                    try
                    {
                        DBUtil.ThrowExceptionOnOpenTransaction(); // Vorsichtsmassnahme : Es darf keine Umgebende Transaktion offen sein.
                        Session.BeginTransaction();
                        this.verarbeitungsFunktion(row);

                        row["Sel"] = false;
                        row.AcceptChanges();
                        qry.RowModified = false;
                        Session.Commit();
                        countSuccessful += 1;
                    }
                    catch (Exception ex)
                    {
                        if (Session.Transaction != null)
                        {
                            Session.Rollback();
                        }
                        failedKgPositionID.Add((int)row[idColumnName]);
                        DlgProgressLog.AddLine(msgFehlerVerarbeitung + ex.Message);
                        DlgProgressLog.AddLine("");
                    }

                    ApplicationFacade.DoEvents();
                }
            }
            DlgProgressLog.AddLine(String.Format(msgEndeVerarbeitung, countSuccessful, count));
            DlgProgressLog.AddLine("Ansicht aktualisieren...");
            qry.Refresh();
            // Die fehlerhaften Positionen erneut markieren
            foreach (DataRow row in qry.DataTable.Rows)
            {
                if (failedKgPositionID.Count <= 0)
                {
                    break;
                }
                else if (failedKgPositionID.Contains((int)row[idColumnName]))
                {
                    row["Sel"] = true;
                    row.AcceptChanges();
                    failedKgPositionID.Remove((int)row[idColumnName]);
                }
            }
            DlgProgressLog.UpdateLastLine("Ansicht aktualisiert.");
            DlgProgressLog.EndProgress();
            DlgProgressLog.ShowTopMost();
            if (count.Equals(countSuccessful))
            {
                DlgProgressLog.CloseDialog();
            }
            mainControl.Cursor = Cursors.Default;
        }

        #endregion

        #endregion
    }
}