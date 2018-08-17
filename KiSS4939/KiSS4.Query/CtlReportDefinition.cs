using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraTreeList;

namespace KiSS4.Query
{
    public partial class CtlReportDefinition : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string REPORT_FILE_EXTENSION = ".krp";
        private const string SQL_SCRIPT_FILE_EXTENSION = ".sql";

        #endregion

        #region Private Fields

        private bool _posting;

        #endregion

        #endregion

        #region Constructors

        public CtlReportDefinition()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlReportDefinition_Load(object sender, EventArgs e)
        {
            qryXQuery.Fill(@"
                SELECT
                  QueryName,
                  UserText,
                  QueryCode,
                  LayoutXML,
                  ParameterXML,
                  SQLquery,
                  ContextForms,
                  ParentReportName,
                  ReportSortKey,
                  RelationColumnName,
                  System,
                  XQueryTS,
                  IconID   = CASE WHEN ParentReportName IS NULL THEN 0 ELSE 1 END,
                  HashCode = dbo.fnQryGetHashCode(QueryName)
                FROM dbo.XQuery WITH (READUNCOMMITTED)
                WHERE QueryCode = 1
                ORDER BY QueryName;");
            tabXQuery.SelectedTabIndex = 0;
            DisplayGroups();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (qryXQuery.Count == 0)
            {
                return;
            }

            if (qryXQuery.Row.RowState == DataRowState.Added && !qryXQuery.Post())
            {
                return;
            }

            if (sender == btnAdd && qryVerfuegbar.Count > 0)
            {
                qryZugeteilt.Insert();
                qryZugeteilt[DBO.XUserGroup_Right.UserGroupID] = qryVerfuegbar[DBO.XUserGroup.UserGroupID];
                qryZugeteilt[DBO.XUserGroup_Right.QueryName] = qryXQuery[DBO.XQuery.QueryName];
                qryZugeteilt[DBO.XUserGroup_Right.MayInsert] = false;
                qryZugeteilt[DBO.XUserGroup_Right.MayUpdate] = false;
                qryZugeteilt[DBO.XUserGroup_Right.MayDelete] = false;
                qryZugeteilt.Post();
            }

            if (sender == btnRemove && qryZugeteilt.Count > 0)
            {
                qryZugeteilt.DeleteQuestion = null;
                qryZugeteilt.Delete();
            }

            if (sender == btnAddAll)
            {
                DBUtil.ExecSQL("DELETE FROM dbo.XUserGroup_Right WHERE QueryName = {0}", qryXQuery[DBO.XQuery.QueryName]);
                DBUtil.ExecSQL(@"
                    INSERT dbo.XUserGroup_Right (UserGroupID, QueryName, MayInsert, MayUpdate, MayDelete)
                      SELECT UserGroupID, {0}, 0, 0, 0 FROM dbo.XUserGroup WITH (READUNCOMMITTED)",
                    qryXQuery[DBO.XQuery.QueryName]);
            }

            if (sender == btnRemoveAll)
            {
                DBUtil.ExecSQL("DELETE FROM dbo.XUserGroup_Right WHERE QueryName = {0}", qryXQuery[DBO.XQuery.QueryName]);
            }

            DisplayGroups();
        }

        /// <summary>
        /// Call designer with report definition stored in DB field LayoutXML.
        /// </summary>
        /// <param name="sender">unused</param>
        /// <param name="e">unused</param>
        private void btnDesign_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            XtraReport report = new XtraReport();

            string layout = qryXQuery[DBO.XQuery.LayoutXML].ToString();
            if (!DBUtil.IsEmpty(layout))
            {
                MemoryStream stream = new MemoryStream();
                StreamWriter sw = new StreamWriter(stream);
                sw.Write(layout);
                sw.Flush(); // required
                stream.Position = 0; // required
                report.LoadLayout(stream);
            }

            string sql = Regex.Replace(qryXQuery[DBO.XQuery.SQLquery].ToString(), @"\{\w+\}", "null"); // eg: where fieldA = {BudgetID} => where fieldA = null
            report.Name = "Report";
            var qryData = DBUtil.OpenSQL(sql);
            if (qryXQuery.DataTable.Columns.Contains(DBO.XQuery.RelationColumnName) && !DBUtil.IsEmpty(qryXQuery[DBO.XQuery.RelationColumnName]))
            {
                DataSet ds = qryData.DataSet;
                if (ds.Tables.Count == 2)
                {
                    string relationColumnName = (string)qryXQuery[DBO.XQuery.RelationColumnName];
                    ds.EnforceConstraints = false;
                    ds.Relations.Add(
                        "Relation1",
                        new[] { ds.Tables[0].Columns[relationColumnName] },
                        new[] { ds.Tables[1].Columns[relationColumnName] });
                }
            }

            report.DataSource = qryData;
            //report.DataSource = DBUtil.OpenSQL(sql);
            var designForm = new FrmXtraReportDesigner();
            designForm.OpenReport(report);
            Cursor.Current = Cursors.Default;
            designForm.ShowDialog(this);

            if ((designForm.ReportState == ReportState.Changed || designForm.ReportState == ReportState.Saved)
                && KissMsg.ShowQuestion("CtlReportDefinition", "AenderungenSpeichern", "Änderungen abspeichern?"))
            {
                MemoryStream newStream = new MemoryStream();
                designForm.Report.SaveLayout(newStream);
                newStream.Position = 0; //required!
                StreamReader sr = new StreamReader(newStream);
                qryXQuery[DBO.XQuery.LayoutXML] = sr.ReadToEnd();
                qryXQuery.Post();
            }
        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            if (qryXQuery.Count == 0)
            {
                return;
            }

            if (DialogResult.Cancel == folderBrowserDialog1.ShowDialog(this))
            {
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                foreach (DataRow row in qryXQuery.DataTable.Rows)
                {
                    if (DBUtil.IsEmpty(row[DBO.XQuery.ParentReportName])) //main reports only
                    {
                        string fileName = row[DBO.XQuery.QueryName] + REPORT_FILE_EXTENSION;
                        fileName = Regex.Replace(fileName, "[\\\\/:*?\"<>|\r\n]", "-");

                        DataSet ds = DBUtil.getTreeBranch(row[DBO.XQuery.QueryName], DBO.XQuery.DBOName, DBO.XQuery.QueryName, DBO.XQuery.ParentReportName);

                        try
                        {
                            ExportSoap(ds, folderBrowserDialog1.SelectedPath + @"\" + fileName);
                        }
                        catch (Exception ex)
                        {
                            KissMsg.ShowError("CtlReportDefinition", "FehlerExportReport", "Fehler beim Exportieren des Reports '{0}'", null, ex, 0, 0, row[DBO.XQuery.QueryName].ToString());
                        }
                    }
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //If a subreport is selected we just focus on the parent node of it.
            //This works only 'cause there are only mainreports containing 1..n subreports without sub-subreports!
            if (qryXQuery[DBO.XQuery.ParentReportName] != DBNull.Value)
            {
                kissTree1.SetFocusedNode(kissTree1.FocusedNode.ParentNode);
            }

            string fileName = qryXQuery[DBO.XQuery.QueryName] + REPORT_FILE_EXTENSION;
            fileName = Regex.Replace(fileName, "[\\\\/:*?\"<>|\r\n]", "-");
            dlgFileSave.Filter = string.Format("Report (*{0})|*{0}|SQL Script (*{1})|*{1}", REPORT_FILE_EXTENSION, SQL_SCRIPT_FILE_EXTENSION);
            dlgFileSave.FilterIndex = 1;
            dlgFileSave.AddExtension = true;
            dlgFileSave.AutoUpgradeEnabled = true;
            dlgFileSave.FileName = fileName;

            if (DialogResult.Cancel == dlgFileSave.ShowDialog(this))
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            DataSet ds = DBUtil.getTreeBranch(qryXQuery[DBO.XQuery.QueryName], DBO.XQuery.DBOName, DBO.XQuery.QueryName, DBO.XQuery.ParentReportName);

            try
            {
                if (dlgFileSave.FilterIndex == 1)
                {
                    ExportSoap(ds, dlgFileSave.FileName);
                }
                else if (dlgFileSave.FilterIndex == 2)
                {
                    ExportToSqlScript(ds, qryXQuery[DBO.XQuery.QueryName].ToString(), dlgFileSave.FileName);
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlReportDefinition", "FehlerExport", "Fehler beim Exportieren", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            dlgFileOpen.Filter = "KiSS Reports (*" + REPORT_FILE_EXTENSION + ")|*" + REPORT_FILE_EXTENSION + "|Alle Dateien (*.*)|*.*";
            if (DialogResult.Cancel == dlgFileOpen.ShowDialog(this))
            {
                return;
            }

            string lastMainKey = "";
            foreach (string fileName in dlgFileOpen.FileNames)
            {
                DataSet ds;
                try
                {
                    ds = ImportSoap(fileName);
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError("CtlReportDefinition", "FehlerImportDatei", "Fehler beim Importieren der Datei {0}", null, ex, 0, 0, fileName);
                    continue;
                }

                Session.BeginTransaction();
                try
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        SqlQuery qry = DBUtil.OpenSQL(@"
                            SELECT
                              QueryName,
                              UserText,
                              QueryCode,
                              LayoutXML,
                              ParameterXML,
                              SQLquery,
                              ContextForms,
                              ParentReportName,
                              ReportSortKey,
                              RelationColumnName,
                              System,
                              XQueryTS
                            FROM dbo.XQuery WITH (READUNCOMMITTED)
                            WHERE QueryName = {0}",
                            row[DBO.XQuery.QueryName]);

                        if (qry.Count == 0)
                        {
                            qry.Insert(DBO.XQuery.DBOName);
                            qry[DBO.XQuery.LayoutXML] = row[DBO.XQuery.LayoutXML];
                        }

                        foreach (DataColumn col in ds.Tables[0].Columns)
                        {
                            switch (col.ColumnName)
                            {
                                case DBO.XQuery.LayoutXML:
                                    if (edtImportLayout.Checked)
                                    {
                                        qry[col.ColumnName] = row[col.ColumnName];
                                    }

                                    break;

                                default:
                                    qry[col.ColumnName] = row[col.ColumnName];
                                    break;
                            }
                        }

                        if (!qry.Post(DBO.XQuery.DBOName))
                        {
                            throw new Exception(
                                KissMsg.GetMLMessage(
                                    "CtlReportDefinition", "AffectedRowsForQueryName", "affectedRows != 1 for QueryName={0}", KissMsgCode.MsgError, row[DBO.XQuery.QueryName]));
                        }

                        if (DBNull.Value == row[DBO.XQuery.ParentReportName])
                        {
                            lastMainKey = (string)row[DBO.XQuery.QueryName];
                        }
                    }

                    Session.Commit();
                }
                catch (Exception ex)
                {
                    Session.Rollback();
                    KissMsg.ShowError("CtlReportDefinition", "FehlerImport", "Fehler beim Importieren", ex);
                }
            }

            OnRefreshData();
            kissTree1.SetFocusedNode(kissTree1.FindNodeByKeyID(lastMainKey));
        }

        private void edtReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            btnDesign.Enabled = !edtReadOnly.Checked;
            btnImport.Enabled = !edtReadOnly.Checked;

            qryXQuery.CanDelete = !edtReadOnly.Checked;
            qryXQuery.CanInsert = !edtReadOnly.Checked;
            qryXQuery.CanUpdate = !edtReadOnly.Checked;
            qryXQuery.Refresh();

            edtSqlQuery.EditMode = qryXQuery.CanUpdate && Session.User.IsUserBIAGAdmin ? EditModeType.Normal : EditModeType.ReadOnly;
            edtParameterXml.EditMode = qryXQuery.CanUpdate && Session.User.IsUserBIAGAdmin ? EditModeType.Normal : EditModeType.ReadOnly;
        }

        private void kissTree1_AfterFocusNode(object sender, NodeEventArgs e)
        {
            tabPageZugriffsrechte.HideTab = qryXQuery[DBO.XQuery.ParentReportName] != DBNull.Value;
            DisplayGroups();
        }

        private void kissTree1_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e)
        {
            if (_posting || qryXQuery.IsInserting)
            {
                return;
            }

            _posting = true;
            if (!qryXQuery.Post())
            {
                e.CanFocus = false;
                return;
            }

            _posting = false;
        }

        private void qryXQuery_AfterInsert(object sender, EventArgs e)
        {
            qryXQuery[DBO.XQuery.QueryName] = "Neuer Report";
            qryXQuery[DBO.XQuery.QueryCode] = "1"; // Report
            qryXQuery[DBO.XQuery.UserText] = "Neuer Report";
            qryXQuery[DBO.XQuery.System] = false;
        }

        private void qryXQuery_PositionChanged(object sender, EventArgs e)
        {
            SetEditMode();
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static void ExportToSqlScript(DataSet ds, string queryName, string fullFilename)
        {
            SqlQuery qry = DBUtil.OpenSQL(@"SELECT * FROM XQuery WHERE QueryName LIKE {0} OR ParentReportName LIKE {0}", queryName);

            string hashCode = DBUtil.ExecuteScalarSQLThrowingException("SELECT HashCode = dbo.fnQryGetHashCode(QueryName) FROM XQuery WHERE QueryName LIKE {0}", queryName) as string;

            StringBuilder script = new StringBuilder();
            script.AppendFormat("-- Insert Script for {0}", queryName);
            script.AppendLine();
            script.AppendFormat("-- MD5:{0}", hashCode);
            script.AppendLine();
            script.AppendFormat("IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE '{0}') BEGIN", queryName);
            script.AppendLine();
            script.AppendFormat("INSERT INTO XQuery(QueryName, QueryCode) VALUES('{0}', 1)", queryName);
            script.AppendLine();
            script.AppendFormat("END;");
            script.AppendLine();
            script.AppendLine();
            script.AppendFormat("DELETE FROM XQuery WHERE ParentReportName LIKE '{0}';", queryName);
            script.AppendLine();

            // TODO evtl kann anstelle von qry das übergebene ds verwendet werden.
            foreach (DataRow row in qry.DataSet.Tables[0].Rows)
            {
                if (row[DBO.XQuery.ParentReportName] == null || row[DBO.XQuery.ParentReportName] == DBNull.Value)
                {
                    script.AppendLine("--SQLCHECK_IGNORE--\r\nUPDATE QRY");
                    script.Append("SET ");
                    script.AppendFormat("{0} = ", DBO.XQuery.QueryName);
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.QueryName]));
                    script.AppendFormat(", {0} = ", DBO.XQuery.UserText);
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.UserText]));
                    script.AppendFormat(", {0} = ", DBO.XQuery.QueryCode);
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.QueryCode]));
                    script.AppendFormat(", {0} = ", DBO.XQuery.LayoutXML);
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.LayoutXML]));
                    script.AppendFormat(", {0} = ", DBO.XQuery.ParameterXML);
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.ParameterXML]));
                    script.AppendFormat(", {0} = ", DBO.XQuery.SQLquery);
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.SQLquery]));
                    script.AppendFormat(", {0} = ", DBO.XQuery.ContextForms);
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.ContextForms]));
                    script.AppendFormat(", {0} = ", DBO.XQuery.ParentReportName);
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.ParentReportName]));
                    script.AppendFormat(", {0} = ", DBO.XQuery.ReportSortKey);
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.ReportSortKey]));
                    script.AppendFormat(", {0} = ", DBO.XQuery.System);
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.System]));
                    script.AppendLine();
                    script.AppendLine("FROM XQuery QRY");
                    script.AppendFormat("WHERE QRY.{0} LIKE {1};", DBO.XQuery.QueryName, DBUtil.SqlLiteral(row[DBO.XQuery.QueryName]));
                    script.AppendLine();
                }
                else
                {
                    script.AppendLine(
                        "--SQLCHECK_IGNORE--\r\nINSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)");
                    script.Append("VALUES (");
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.QueryName]));
                    script.Append(", ");
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.UserText]));
                    script.Append(", ");
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.QueryCode]));
                    script.Append(", ");
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.LayoutXML]));
                    script.Append(", ");
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.ParameterXML]));
                    script.Append(", ");
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.SQLquery]));
                    script.Append(", ");
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.ContextForms]));
                    script.Append(", ");
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.ParentReportName]));
                    script.Append(", ");
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.ReportSortKey]));
                    script.Append(", ");
                    script.Append(DBUtil.SqlLiteral(row[DBO.XQuery.System]));
                    script.AppendLine(");");
                }

                script.AppendLine();
                script.AppendLine();
            }

            string scriptFileContent = script.ToString();
            // Löschen der NUL characters welche sich möglicherweise im String befinden
            if (scriptFileContent.Contains(Convert.ToString(Convert.ToChar(0))))
            {
                scriptFileContent = scriptFileContent.Replace(Convert.ToString(Convert.ToChar(0)), "");
            }

            StreamWriter writer = new StreamWriter(fullFilename, false, Encoding.UTF8);
            writer.Write(scriptFileContent);
            writer.Close();
        }

        private static DataSet ImportSoap(string fileName)
        {
            SoapFormatter formatter = new SoapFormatter();
            StreamReader reader = new StreamReader(fileName);
            DataSet dsImportedReport = (DataSet)formatter.Deserialize(reader.BaseStream);
            reader.Close();
            return dsImportedReport;
        }

        #endregion

        #region Private Methods

        private void DisplayGroups()
        {
            if (tabPageZugriffsrechte.HideTab || qryXQuery.IsFilling)
            {
                return;
            }

            qryZugeteilt.Fill(@"
                SELECT
                  URI.UserGroup_RightID,
                  URI.UserGroupID,
                  URI.RightID,
                  URI.MaskName,
                  URI.MayInsert,
                  URI.MayUpdate,
                  URI.MayDelete,
                  URI.QueryName,
                  URI.ClassName,
                  URI.XUserGroup_RightTS,
                  UGR.UserGroupName
                FROM dbo.XUserGroup_Right   URI WITH (READUNCOMMITTED)
                  INNER JOIN dbo.XUserGroup UGR WITH (READUNCOMMITTED) ON UGR.UserGroupID = URI.UserGroupID
                WHERE URI.QueryName = {0}
                ORDER BY UserGroupName;",
                qryXQuery[DBO.XQuery.QueryName]);

            qryVerfuegbar.Fill(@"
                SELECT UGR.UserGroupID, UGR.UserGroupName
                FROM dbo.XUserGroup              UGR WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.XUserGroup_Right URI WITH (READUNCOMMITTED) ON URI.UserGroupID = UGR.UserGroupID
                                                                           AND URI.QueryName = {0}
                WHERE URI.UserGroupID IS NULL
                ORDER BY UserGroupName;",
                qryXQuery[DBO.XQuery.QueryName]);
        }

        private void ExportSoap(DataSet ds, string fullFilename)
        {
            SoapFormatter formatter = new SoapFormatter();
            StreamWriter writer = new StreamWriter(fullFilename);

            //determine HashCode
            string hashCode = DBUtil.ExecuteScalarSQLThrowingException("SELECT dbo.fnQryGetHashCode({0})", qryXQuery[DBO.XQuery.QueryName]) as string;
            writer.WriteLine("<!-- MD5:{0} -->", hashCode);
            writer.Flush();

            // Serialize the object
            formatter.Serialize(writer.BaseStream, ds);

            writer.Close();
        }

        private void SetEditMode()
        {
            if (Session.User.IsUserBIAGAdmin)
            {
                edtReadOnly.EditMode = EditModeType.Normal;
            }
            else
            {
                if ((qryXQuery[DBO.XQuery.System] as bool? ?? false))
                {
                    edtReadOnly.EditMode = EditModeType.ReadOnly;
                    edtSystem.EditMode = EditModeType.ReadOnly;
                }
                else
                {
                    edtReadOnly.EditMode = EditModeType.Normal;
                }
            }
        }

        #endregion

        #endregion
    }
}