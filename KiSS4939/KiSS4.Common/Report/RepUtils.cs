using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using KiSS4.DB;

namespace KiSS4.Common.Report
{
    #region Enumerations

    public enum KissReportDestination
    {
        Printer,
        PrinterDialog,
        Viewer,
        Export,
        Mail,
        ExportToExcel,
        OpenFile
    }

    #endregion

    public static class RepUtil
    {
        #region Fields

        #region Private Static Fields

        private static FontFamily _fontFamily;

        #endregion

        #endregion

        #region Properties

        public static FontFamily Barcode39FontFamily
        {
            get
            {
                if (_fontFamily == null)
                {
                    var pfc = new System.Drawing.Text.PrivateFontCollection();
                    pfc.AddFontFile(@"Fonts\c39hrp36dltt.ttf");

                    _fontFamily = pfc.Families[0];
                }

                return _fontFamily;
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Print a report
        /// </summary>
        /// <param name="queryName">The name of the report</param>
        /// <param name="dest">The destination, e.g. printer, viewer or export to excel</param>
        /// <param name="namedPrms">The parameters needed to create the report</param>
        /// <returns>Returns the exported document as a stream if the report is exported to excel as destination,
        /// otherwise returns null</returns>
        public static Stream ExecuteReport(string queryName, KissReportDestination dest, params NamedPrm[] namedPrms)
        {
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT *
                FROM  XQuery
                WHERE  (QueryName = {0} OR ParentReportName = {0}) AND
                       LayoutXML IS NOT NULL " + //Wegen SqlSyntaxcheck.
                "ORDER BY CASE WHEN QueryName = {0} THEN 0 ELSE 1 END",
                queryName);

            if (qry.Count == 0)
            {
                return null;
            }

            return ExecuteXtraReport(qry, dest, namedPrms);
        }

        #endregion

        #region Private Static Methods

        private static Stream ExecuteXtraReport(SqlQuery qry, KissReportDestination dest, params NamedPrm[] namedPrms)
        {
            Cursor.Current = Cursors.WaitCursor;

            XtraReport mainreport = null;

            foreach (DataRow row in qry.DataTable.Rows)
            {
                //prepare layout: transfer from DataField into a memory stream
                string layout = row["LayoutXML"].ToString();
                MemoryStream stream = new MemoryStream();
                StreamWriter sw = new StreamWriter(stream);
                sw.Write(layout);
                sw.Flush(); // required
                stream.Position = 0; // required

                // create new report and load layout
                XtraReport report = new XtraReport();
                report.LoadLayout(stream);

                if (Session.IsKiss5Mode)
                {
                    string[] newScriptReferences = new string[report.ScriptReferences.Length];
                    for (int i = 0; i < report.ScriptReferences.Length; i++)
                    {
                        newScriptReferences[i] = @"KiSS4\" + report.ScriptReferences[i];
                    }

                    report.ScriptReferences = newScriptReferences;
                }

                bool mainrep = DBUtil.IsEmpty(row["ParentReportName"]);  //Main Report or Subreport

                if (mainrep)
                {
                    mainreport = report;
                    mainreport.Name = "Report";
                }
                else
                {
                    //locate subreport control in MainReport and assign actual subreport
                    if (mainreport == null)
                    {
                        continue;
                    }

                    XRControl control = mainreport.FindControl(row["QueryName"].ToString(), true);

                    if (control == null || !(control is Subreport))
                    {
                        continue;
                    }
                    ((Subreport)control).ReportSource = report;
                }

                //prepare sql statement, replace {prm} by actual value
                string sql = row["SqlQuery"].ToString();
                foreach (NamedPrm p in namedPrms.Where(x => x != null))
                {
                    string token = "{" + p.Name.ToUpper() + "}";
                    int idx = sql.ToUpper().IndexOf(token);

                    while (idx != -1)
                    {
                        if (p.Value is String)
                            p.Value = ((string)p.Value).Replace("*", "%").Replace("?", "_").Replace(" ", "%");

                        sql = sql.Replace(sql.Substring(idx, token.Length), DBUtil.SqlLiteral(p.Value));
                        idx = sql.ToUpper().IndexOf(token);
                    }
                }
                SqlQuery qryData = DBUtil.OpenSQLWithTimeout(sql, 120);
                if (qryData.Count == 0)
                {
                    if (mainrep)
                    {
                        KissMsg.ShowInfo("RepUtils", "KeineDatenGefunden", "Es konnten keine Daten für diesen Report gefunden werden!");
                        return null;
                    }
                    else //hide subreport
                    {
                        report.Visible = false;
                    }
                }
                // A relation can be usefull in a Detailreport
                if (row.Table.Columns.Contains("RelationColumnName") && !DBUtil.IsEmpty(row["RelationColumnName"]))
                {
                    DataSet ds = qryData.DataSet;
                    if (ds.Tables.Count == 2)
                    {
                        string relationColumnName = (string)row["RelationColumnName"];
                        ds.EnforceConstraints = false;
                        ds.Relations.Add("Relation1",
                            new DataColumn[] { ds.Tables[0].Columns[relationColumnName] },
                            new DataColumn[] { ds.Tables[1].Columns[relationColumnName] });
                    }
                }
                report.DataSource = qryData;
            }

            Stream exportStream = null;

            //Run Report
            switch (dest)
            {
                case KissReportDestination.Printer:
                    mainreport.Print();
                    break;

                case KissReportDestination.PrinterDialog:
                    mainreport.PrintDialog();
                    break;

                case KissReportDestination.Viewer:
                    FrmReportViewer viewer = new FrmReportViewer(mainreport);
                    viewer.ShowDialog();
                    break;

                case KissReportDestination.ExportToExcel:
                    exportStream = new MemoryStream();
                    mainreport.CreateXlsDocument(exportStream, true /* true: exports numbers as numbers; false: exports numbers as text */ );
                    exportStream.Position = 0;
                    break;

                case KissReportDestination.OpenFile:
                    string outputDirectory = Path.Combine(Path.GetTempPath(), @"KiSSInkassoESR\");
                    string outputPath = Path.Combine(outputDirectory, Guid.NewGuid().ToString() + ".pdf");
                    if (!Directory.Exists(outputDirectory))
                    {
                        Directory.CreateDirectory(outputDirectory);
                    }
                    mainreport.CreatePdfDocument(outputPath);
                    System.Diagnostics.Process.Start(outputPath);
                    break;
            }

            Cursor.Current = Cursors.Default;
            return exportStream;
        }

        #endregion

        #endregion
    }

    public class NamedPrm
    {
        #region Fields

        #region Public Fields

        public string Name;
        public object Value;

        #endregion

        #endregion

        #region Constructors

        public NamedPrm()
        {
        }

        public NamedPrm(string name, object value)
        {
            Name = name;
            Value = value;
        }

        #endregion
    }
}