using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KiSS4.Dokument;
using KiSS4.DB;
using KiSS4.Common;
using KiSS4.Messages;

namespace KiSS4.Administration.ZH
{
    public partial class CtlAlimDokumenteExport : KissQueryControl
    {
        decimal? fafallID = null;
        string path;

        public CtlAlimDokumenteExport()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            fafallID = edtFallNr.EditValue as decimal?;
            path = edtPfad.Text;
            if (string.IsNullOrEmpty(path) || !System.IO.Path.IsPathRooted(path))
            {
                KissMsg.ShowError("Ungültiger Pfad");
                return;
            }

            if (!fafallID.HasValue && KissMsg.ShowQuestion("Sollen wirklich alle Alim-Dokumente exportiert werden? Dies wird eine Zeit lang dauern...") == false)
            {
                return;
            }

            DlgProgressLog.Show("Alim-Dokumente exportieren", false, 800, 500, new ProgressEventHandler(ProgressStart), () => { }, Session.MainForm);
        }


        private void ProgressStart()
        {
            if (fafallID.HasValue)
            {
                DlgProgressLog.AddLine(string.Format("Bestimmen der zu exportierenden Dokumente für Fall {0}...", fafallID.Value));
            }
            else
            {
                DlgProgressLog.AddLine("Bestimmen der zu exportierenden Dokumente aller Alim-Fälle...");
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                SqlQuery qry = DBUtil.OpenSQLWithTimeout(@"
               SELECT DISTINCT DocumentID FROM 
               (
                 SELECT DocumentID = Verfuegung_DocumentID
                 FROM dbo.FaLeistung                    LEI
                   INNER JOIN dbo.AmAnspruchsberechnung ABR ON ABR.FaLeistungID = LEI.FaLeistungID
                 WHERE LEI.FaFallID = ISNULL({0},LEI.FaFallID) AND Verfuegung_DocumentID IS NOT NULL

                 UNION ALL

                 SELECT DocumentID = Berechnung_DocumentID
                 FROM dbo.FaLeistung                    LEI
                   INNER JOIN dbo.AmAnspruchsberechnung ABR ON ABR.FaLeistungID = LEI.FaLeistungID
                 WHERE LEI.FaFallID = ISNULL({0},LEI.FaFallID) AND Berechnung_DocumentID IS NOT NULL

                 UNION ALL

                 SELECT DocumentID = DokumentID
                 FROM dbo.FaLeistung           LEI
                   INNER JOIN dbo.AmVerfuegung VFG ON VFG.FaLeistungID = LEI.FaLeistungID
                 WHERE LEI.FaFallID = ISNULL({0},LEI.FaFallID) AND DokumentID IS NOT NULL

                 UNION ALL

                 SELECT DocumentID = Forderung_DocumentID
                 FROM dbo.FaLeistung          LEI
                   INNER JOIN dbo.IkForderung FRD ON FRD.FaLeistungID = LEI.FaLeistungID
                 WHERE LEI.FaFallID = ISNULL({0},LEI.FaFallID) AND Forderung_DocumentID IS NOT NULL

                 UNION ALL

                 SELECT DocumentID = Forderung_DocumentID
                 FROM dbo.FaLeistung         LEI
                   INNER JOIN dbo.IkPosition POS ON POS.FaLeistungID = LEI.FaLeistungID
                 WHERE LEI.FaFallID = ISNULL({0},LEI.FaFallID) AND Forderung_DocumentID IS NOT NULL

                 UNION ALL

                 SELECT DocumentID = DocumentID
                 FROM dbo.FaLeistung          LEI
                   INNER JOIN dbo.FaDokumente DOK ON DOK.FaLeistungID = LEI.FaLeistungID
                 WHERE LEI.FaFallID = ISNULL({0},LEI.FaFallID) AND FaProzessCode = 201 AND DocumentID IS NOT NULL
               ) DOC", 600, fafallID);

                int totalCount = qry.DataTable.Rows.Count;
                int errorCount = 0;
                int successCount = 0;
                DlgProgressLog.AddLine(string.Format("{0} Dokumente gefunden", totalCount));

                foreach (DataRow row in qry.DataTable.Rows)
                {
                    int documentID = -1;
                    try
                    {
                        documentID = (int)row["DocumentID"];
                        XDocFileHandler.ExportFromDBToFile(documentID, path, true);
                        DlgProgressLog.UpdateLastLine(string.Format("{0} Dokumente exportiert", ++successCount));
                    }
                    catch (Exception ex)
                    {
                        errorCount++;
                        string error = string.Format("Fehler beim Export von Dokument mit ID {0}: '{1}'", documentID, ex.Message);
                        XLog.Create("CtlAlimDokumenteExport", LogLevel.ERROR, error, Session.User.UserID);
                        DlgProgressLog.UpdateLastLine(error);
                        DlgProgressLog.AddLine(string.Format("{0} Dokumente exportiert", successCount));
                    }
                }
                DlgProgressLog.AddLine(string.Format("Export abgeschlossen, {0} von {1} Dokumenten konnten nicht exportiert werden", errorCount, totalCount));
            }
            catch (Exception ex)
            {
                string error = string.Format("Fehler: '{0}'", ex.Message);
                XLog.Create("CtlAlimDokumenteExport", LogLevel.ERROR, error, Session.User.UserID);
                DlgProgressLog.AddError(error);
            }
            finally
            {
                Cursor = Cursors.Default;
                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
            }
        }
    }
}
