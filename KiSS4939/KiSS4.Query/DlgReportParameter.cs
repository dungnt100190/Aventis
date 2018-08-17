using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.Common.Report;
using KiSS4.DB;
using KiSS4.Gui;

using Kiss.Interfaces.UI;

namespace KiSS4.Query
{
    /// <summary>
    /// Summary description for DlgReportParameter.
    /// </summary>
    public class DlgReportParameter : KissDialog
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly IKissContext _cp;
        private readonly string _queryName;

        #endregion

        #region Private Fields

        private System.ComponentModel.IContainer components;
        private PictureBox pictureBox1;
        private SqlQuery qryReport;
        private KissButton _btnCancel;
        private KissButton _btnPrint;
        private Panel _panBottom;
        private Panel _panParameter;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DlgReportParameter"/> class.
        /// </summary>
        /// <param name="cp">The context to use for report</param>
        /// <param name="queryName">The name of the query to use for the report</param>
        public DlgReportParameter(IKissContext cp, string queryName)
        {
            InitializeComponent();

            // apply members
            _cp = cp;
            _queryName = queryName;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgReportParameter));
            this._panBottom = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._btnCancel = new KiSS4.Gui.KissButton();
            this._btnPrint = new KiSS4.Gui.KissButton();
            this._panParameter = new System.Windows.Forms.Panel();
            this.qryReport = new KiSS4.DB.SqlQuery(this.components);
            this._panBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryReport)).BeginInit();
            this.SuspendLayout();
            //
            // panBottom
            //
            this._panBottom.Controls.Add(this.pictureBox1);
            this._panBottom.Controls.Add(this._btnCancel);
            this._panBottom.Controls.Add(this._btnPrint);
            this._panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._panBottom.Location = new System.Drawing.Point(0, 208);
            this._panBottom.Name = "_panBottom";
            this._panBottom.Size = new System.Drawing.Size(482, 40);
            this._panBottom.TabIndex = 1;
            //
            // pictureBox1
            //
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            //
            // btnCancel
            //
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnCancel.Location = new System.Drawing.Point(288, 8);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(88, 24);
            this._btnCancel.TabIndex = 1;
            this._btnCancel.Text = "Abbruch";
            this._btnCancel.UseVisualStyleBackColor = false;
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnPrint
            //
            this._btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnPrint.Location = new System.Drawing.Point(384, 8);
            this._btnPrint.Name = "_btnPrint";
            this._btnPrint.Size = new System.Drawing.Size(88, 24);
            this._btnPrint.TabIndex = 0;
            this._btnPrint.Text = "Drucken";
            this._btnPrint.UseVisualStyleBackColor = false;
            this._btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            //
            // panParameter
            //
            this._panParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panParameter.Location = new System.Drawing.Point(0, 0);
            this._panParameter.Name = "_panParameter";
            this._panParameter.Size = new System.Drawing.Size(482, 208);
            this._panParameter.TabIndex = 0;
            //
            // qryReport
            //
            this.qryReport.HostControl = this;
            //
            // DlgReportParameter
            //
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(482, 248);
            this.Controls.Add(this._panParameter);
            this.Controls.Add(this._panBottom);
            this.Name = "DlgReportParameter";
            this.Text = "Report Parameter";
            this.Print += new System.EventHandler(this.DlgReportParameter_Print);
            this._panBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryReport)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ExecuteReport();
        }

        private void DlgReportParameter_Print(object sender, EventArgs e)
        {
            ExecuteReport();
        }

        #endregion

        #region Methods

        #region Public Methods

        public void ShowParameter()
        {
            if (BuildParameterMask())
            {
                //extend size of dialog to display all parameter fields
                int maxX = 0;
                int maxY = 0;

                foreach (Control ctl in _panParameter.Controls)
                {
                    maxX = Math.Max(maxX, ctl.Left + ctl.Width);
                    maxY = Math.Max(maxY, ctl.Top + ctl.Height);
                }

                if (maxX + 5 > _panParameter.Width)
                {
                    Width = Width + maxX + 5 - _panParameter.Width;
                }

                if (maxY + 5 > _panParameter.Height)
                {
                    Height = Height + maxY + 5 - _panParameter.Height;
                }

                ShowDialog();
            }
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Makes a DataSet of the parameters specified in XReports.ParameterXML. Returns "null" if ParameterXML
        /// is DBNull.
        /// </summary>
        /// <param name="sqlQuery">SqlQuery of XReports from where DB field ParameterXML will be retrieved</param>
        /// <param name="xmlSchemaMemoryStream">MemoryStream containing the XML schema for the parameters</param>
        /// <returns>DataSet representing ParameterXML or "null" if no parameters specified in DB</returns>
        private static DataSet MakeDataSetParameterXML(SqlQuery sqlQuery, System.IO.Stream xmlSchemaMemoryStream)
        {
            // Put the datafield in a stream
            System.IO.MemoryStream parameterMemoryStream = new System.IO.MemoryStream();
            System.IO.StreamWriter parameterStreamWriter = new System.IO.StreamWriter(parameterMemoryStream, System.Text.Encoding.Unicode);
            string parameterXML = sqlQuery["ParameterXML"].ToString().Trim();

            if (0 >= parameterXML.Length)
            {
                return null;
            }

            parameterStreamWriter.Write(parameterXML);
            parameterStreamWriter.Flush(); // required!

            // Read the stream using DataSet.ReadXml
            DataSet ds = new DataSet();

            xmlSchemaMemoryStream.Position = 0;
            ds.ReadXmlSchema(xmlSchemaMemoryStream); // get schema

            parameterMemoryStream.Position = 0;
            ds.ReadXml(parameterMemoryStream);

            return ds;
        }

        #endregion

        #region Private Methods

        private bool BuildParameterMask()
        {
            Cursor curCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            Enabled = false;

            try
            {
                _panParameter.Controls.Clear();

                qryReport.Fill(@"
                    SELECT UserText,
                           ParameterXML
                    FROM dbo.XQuery WITH (READUNCOMMITTED)
                    WHERE QueryName = {0}", _queryName);

                if (qryReport.Count == 0)
                {
                    KissMsg.ShowError("DlgReportParameter", "ReportNichtInDB", "Datenfehler: Report '{0}' in DB nicht gefunden", null, null, 0, 0, _queryName);
                    return false;
                }

                // Display fields for parameters stored in ParameterXML.
                try
                {
                    DataSet ds = MakeDataSetParameterXML(qryReport, DynaFactory.DynaFieldSchema);

                    if (null == ds)
                    {
                        return false; // no parameters
                    }

                    // Use the DataSet to call BuildMask
                    DynaFactory dynaFactory = new DynaFactory();
                    dynaFactory.BuildMask(_cp, ds.Tables[0], _panParameter, qryReport["UserText"].ToString(), pictureBox1.Image);
                }
                catch (Exception ex)
                {
                    string techMsg = "Check XQuery.ParameterXML for QueryName '" + _queryName + "'";
                    KissMsg.ShowError(Name, "ReportFalschKonfiguriert", "Report ist nicht richtig konfiguriert", techMsg, ex);
                    return false;
                }

                // fill values into dynamic input fields if provided by context.
                if (_cp != null)
                {
                    // get input value from all dynamic input fields and set corresponding ActiveReport SQL parameters.
                    bool unknowVal = false;

                    foreach (Control ctl in _panParameter.Controls)
                    {
                        string fieldName;

                        if (null != (fieldName = DynaFactory.GetFieldNameOfInputFieldControl(ctl)))
                        {
                            object inputValue = _cp.GetContextValue(fieldName);

                            if (!DBUtil.IsEmpty(inputValue))
                            {
                                DynaFactory.SetValueInputFieldControl(ctl, inputValue);
                            }
                            else
                            {
                                unknowVal = true;
                            }
                        }
                    }

                    // Open Report if all Parameter are know
                    if (!unknowVal)
                    {
                        ExecuteReport();
                        return false;
                    }
                }
            }
            finally
            {
                Enabled = true;
                Cursor.Current = curCursor;
            }

            return true;
        }

        private void ExecuteReport()
        {
            Cursor.Current = Cursors.WaitCursor;
            Enabled = false;

            try
            {
                // Get input value from all input fields and build NamedPrms array
                ArrayList prmArray = new ArrayList();

                foreach (Control ctl in _panParameter.Controls)
                {
                    if (ctl is KissLabel || ctl.Tag == null)
                    {
                        continue;
                    }

                    NamedPrm prm = new NamedPrm();

                    prm.Value = DynaFactory.GetInputValueFromControl(ctl);
                    prm.Name = (string)((DataRow)ctl.Tag)["FieldName"];
                    prmArray.Add(prm);
                }

                NamedPrm[] prms = new NamedPrm[prmArray.Count];

                for (int i = 0; i < prmArray.Count; i++)
                {
                    prms[i] = (NamedPrm)prmArray[i];
                }

                RepUtil.ExecuteReport(_queryName, KissReportDestination.Viewer, prms);
            }
            catch (Exception ex)
            {
                string techMsg = "Report '" + _queryName + "'";
                KissMsg.ShowError(Name, "FehlerReportAusfuehren", "Beim Ausführen des Reports ist ein Fehler aufgetreten", techMsg, ex);
            }
            finally
            {
                Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #endregion
    }
}