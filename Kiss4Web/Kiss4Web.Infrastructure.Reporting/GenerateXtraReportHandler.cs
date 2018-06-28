using Dapper;
using DevExpress.XtraReports.UI;
using Kiss4Web.Infrastructure.I18N;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiss4Web.Infrastructure.Reporting
{
    public class GenerateXtraReportHandler : TypedMessageHandler<GenerateXtraReportCommand, XtraReport>
    {
        private readonly IQueryable<Xquery> _xquery;
        private readonly SqlConnection _sqlConnection;
        private readonly IKiss4TranslationProvider _translationProvider;

        public GenerateXtraReportHandler(IQueryable<Xquery> xquery,
            SqlConnection sqlConnection,
            IKiss4TranslationProvider translationProvider)
        {
            _xquery = xquery;
            _sqlConnection = sqlConnection;
            _translationProvider = translationProvider;
        }
        public override async Task<XtraReport> Handle(GenerateXtraReportCommand message)
        {
            var report = _xquery.FirstOrDefault(x => (x.QueryName == message.QueryName || x.ParentReportName == message.QueryName) && !string.IsNullOrEmpty(x.LayoutXml));
            if (report == null)
            {
                return null;
            }
            return await ExecuteXtraReport(report, message.KissReportDestination, message.ContextValues, message.XtraReportFullPath);
        }

        private async Task<XtraReport> ExecuteXtraReport(Xquery qry, Kiss4ReportDestination dest, IEnumerable<ContextValue> namedPrms, string xtraReportFullPath)
        {
            XtraReport mainreport = null;

            // create new report and load layout
            XtraReport report = new XtraReport();
            report.LoadLayout(xtraReportFullPath);
            bool mainrep = string.IsNullOrEmpty(qry.ParentReportName);
            if (mainrep)
            {
                mainreport = report;
                mainreport.Name = "Report";
            }
            else
            {
                return null;

                //TODO: support including subreport                
                //locate subreport control in MainReport and assign actual subreport
                //if (mainreport == null)
                //{
                //    return null;
                //}
                //XRControl control = mainreport.FindControl(qry.QueryName, true);

                //if (control == null || !(control is Subreport))
                //{
                //    return null;
                //}
                //((Subreport)control).ReportSource = report;
            }

            //prepare sql statement, replace {prm} by actual value
            string sql = qry.Sqlquery;
            foreach (ContextValue p in namedPrms.Where(x => x != null))
            {
                string token = "{" + p.Name.ToUpper() + "}";
                int idx = sql.ToUpper().IndexOf(token);

                while (idx != -1)
                {
                    if (p.Value is String)
                        p.Value = ((string)p.Value).Replace("*", "%").Replace("?", "_").Replace(" ", "%");

                    sql = sql.Replace(sql.Substring(idx, token.Length), SqlLiteral(p.Value));
                    idx = sql.ToUpper().IndexOf(token);
                }
            }

            var qryData = _sqlConnection.QueryAsync(sql);
            if (qryData.Result.Count() == 0)
            {
                if (mainrep)
                {
                    var text = await _translationProvider.GetText("RepUtils", "KeineDatenGefunden") ?? "Es konnten keine Daten für diesen Report gefunden werden!";
                    throw new InvalidOperationException(text);
                }
                else //hide subreport
                {
                    report.Visible = false;
                }
            }

            // A relation can be usefull in a Detailreport
            //if (row.Table.Columns.Contains("RelationColumnName") && !DBUtil.IsEmpty(row["RelationColumnName"]))
            //{
            //    DataSet ds = qryData.DataSet;
            //    if (ds.Tables.Count == 2)
            //    {
            //        string relationColumnName = (string)row["RelationColumnName"];
            //        ds.EnforceConstraints = false;
            //        ds.Relations.Add("Relation1",
            //            new DataColumn[] { ds.Tables[0].Columns[relationColumnName] },
            //            new DataColumn[] { ds.Tables[1].Columns[relationColumnName] });
            //    }
            //}

            report.DataSource = qryData;
            
            //Stream exportStream = null;

            ////Run Report
            //switch (dest)
            //{
            //    case ReportType.Printer:
            //        mainreport.Print();
            //        break;

            //    case ReportType.PrinterDialog:
            //        mainreport.PrintDialog();
            //        break;

            //    case ReportType.Viewer:
            //        //FrmReportViewer viewer = new FrmReportViewer(mainreport);
            //        //viewer.ShowDialog();
            //        break;

            //    case ReportType.ExportToExcel:
            //        exportStream = new MemoryStream();
            //        mainreport.CreateXlsDocument(exportStream, true /* true: exports numbers as numbers; false: exports numbers as text */ );
            //        exportStream.Position = 0;
            //        break;

            //    case ReportType.OpenFile:
            //        string outputDirectory = Path.Combine(Path.GetTempPath(), @"KiSSInkassoESR\");
            //        string outputPath = Path.Combine(outputDirectory, Guid.NewGuid().ToString() + ".pdf");
            //        if (!Directory.Exists(outputDirectory))
            //        {
            //            Directory.CreateDirectory(outputDirectory);
            //        }
            //        mainreport.CreatePdfDocument(outputPath);
            //        System.Diagnostics.Process.Start(outputPath);
            //        break;
            //}

            return mainreport;
        }

        
        private string SqlLiteral(object value)
        {
            return SqlLiteral(value, false);
        }

        /// <summary>
        /// convert a value to an sql literal.
        /// </summary>
        private string SqlLiteral(object value, bool useInSP)
        {
            string ret;

            if (value == null)
            {
                ret = " null ";
            }
            else if (value == DBNull.Value)
            {
                ret = " null ";
            }
            else if (value is string)
            {
                ret = " N'" + Convert.ToString(value).Replace("'", "''") + "' ";
            }
            else if (value is bool)
            {
                ret = Convert.ToBoolean(value) ? " 1 " : " 0 ";
            }
            else if (value is DateTime)
            {
                DateTime dt = Convert.ToDateTime(value);

                if (useInSP)
                {
                    if (dt == dt.Date)
                    {
                        ret = "'" + dt.ToString("yyyyMMdd") + "'";
                    }
                    else
                    {
                        ret = "'" + dt.ToString("yyyyMMdd HH:mm:ss") + "'";
                    }
                }
                else
                {
                    if (dt == dt.Date)
                    {
                        ret = " CONVERT(DATETIME, '" + dt.ToString("dd.MM.yyyy") + "', 104) ";
                    }
                    else
                    {
                        ret = " CONVERT(DATETIME, '" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "', 120) ";
                    }
                }
            }
            else if (value is byte ||
                     value is short ||
                     value is int ||
                     value is long ||
                     value is float ||
                     value is double ||
                     value is decimal)
            {
                ret = ((IFormattable)value).ToString(null, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (value is byte[])
            {
                byte[] ba = (byte[])value;
                char[] charArray = new string(' ', ba.Length * 2).ToCharArray();

                for (int i = 0; i < ba.Length; i++)
                {
                    ba[i].ToString("x2").CopyTo(0, charArray, i * 2, 2);
                }

                ret = " 0x" + new string(charArray) + " ";
            }
            else if (value is Guid)
            {
                ret = " '" + ((Guid)value).ToString() + "' ";
            }
            else if (value is Enum)
            {
                int intval = (int)value;
                ret = ((IFormattable)intval).ToString(null, System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                //#7224 Fehlermeldung verbessert, dass man den Typ kennt.
                string typeName = value.GetType().FullName;
                throw new ArgumentException(string.Format("Unsupported data type: {0}", typeName));
            }

            return ret;
        }
    }
}
