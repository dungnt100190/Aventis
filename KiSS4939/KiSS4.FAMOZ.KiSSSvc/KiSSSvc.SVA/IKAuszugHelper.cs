using System;
using System.IO;
using System.Text;

using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;
using KiSSSvc.Logging;

namespace KiSSSvc.SVA
{
    public class IKAuszugHelper
    {
        public static void GenerateAndSaveReport(System.Data.DataRow row, bool savePdfOnDisk = false)
        {
            using (IKAuszug report = new IKAuszug())
            {
                int ikAuszugID = (int)row["SstIKAuszugID"];

                MemoryStream pdfStream = new MemoryStream();
                SstIKAuszugTableAdapter sstIKAuszugTableAdapter = new SstIKAuszugTableAdapter();
                sstIKAuszugTableAdapter.InitializeKiSSAdapter(null);
                sstIKAuszugTableAdapter.Fill(report.IKAuszugDataTable, ikAuszugID);

                SstIKAuszugDetailTableAdapter sstIKAuszugDetailsTableAdapter = new SstIKAuszugDetailTableAdapter();
                sstIKAuszugDetailsTableAdapter.InitializeKiSSAdapter(null);
                sstIKAuszugDetailsTableAdapter.Fill(report.IKAuszugDetailsDataTable, ikAuszugID);

                // Test: Schreibe das PDF auf die Disk
                if (savePdfOnDisk)
                {
                    FileStream f = new FileStream($@"C:\temp\test_IKAuszug_{ikAuszugID}.pdf", FileMode.Create, FileAccess.Write);
                    report.CreatePdfDocument(f);
                    f.Close();
                }

                // Erstelle den Report im Memory
                report.CreatePdfDocument(pdfStream);

                // Und speichere das Dokument ab und verlinke es zugleich mit dem IKAuszugs-Eintrag
                sstIKAuszugTableAdapter.spSstIKAuszugSavePDF(ikAuszugID, Zip.CompressData(pdfStream));
            }
        }

        public static string GenerateIKAuszuege()
        {
            SstIKAuszugTableAdapter sstIKAuszugTableAdapter = new SstIKAuszugTableAdapter();
            sstIKAuszugTableAdapter.InitializeKiSSAdapter(null);

            KiSSDB.SstIKAuszugDataTable sstIKAuszugDataTable = sstIKAuszugTableAdapter.GetPendenteIKAuszuege();

            var result = new StringBuilder();

            foreach (System.Data.DataRow row in sstIKAuszugDataTable.Rows)
            {
                int ikAuszugID = (int)row["SstIKAuszugID"];
                int baPersonID = (int)row["BaPersonID"];

                try
                {
                    GenerateAndSaveReport(row);
                    Log.Info(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, string.Format("IKAuszugHelper.GenerateIKAuszuege: PDF für IKAuszugID {0} / BaPersonID {1} wurde erfolgreich generiert.", ikAuszugID, baPersonID));
                }
                catch (Exception ex)
                {
                    var error = string.Format("IKAuszugHelper.GenerateIKAuszuege: Fehler beim Erstellen des PDFs für IKAuszugID {0} : {1}", ikAuszugID, ex);
                    Log.Error(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, error);
                    sstIKAuszugTableAdapter.SetImportFehlermeldung(ikAuszugID, string.Format("Fehler beim Erstellen des PDFs: {0}", ex));
                    result.AppendLine(error);
                }
            }

            var resultString = result.ToString();
            return string.IsNullOrWhiteSpace(resultString) ? null : resultString;
        }
    }
}