using System.Data;

namespace KiSS4.DB.Designer
{
    partial class DlgSqlStatementEditorForm
    {
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_connection != null && _connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgSqlStatementEditorForm));
            this.edtStatement = new System.Windows.Forms.RichTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbParameters = new System.Windows.Forms.GroupBox();
            this.pnBottom = new System.Windows.Forms.Panel();
            this.btnQuery = new System.Windows.Forms.Button();
            this.gridPreview = new System.Windows.Forms.DataGrid();
            this.edtSyntaxError = new System.Windows.Forms.TextBox();
            this.pnControls = new System.Windows.Forms.Panel();
            this.pnCenter = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tmrValidateSQL = new System.Windows.Forms.Timer(this.components);
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.chbSuppressContinuousChecks = new System.Windows.Forms.CheckBox();
            this.edtConnection = new System.Windows.Forms.ComboBox();
            this.pnBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPreview)).BeginInit();
            this.pnControls.SuspendLayout();
            this.pnCenter.SuspendLayout();
            this.gbConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // edtStatement
            // 
            this.edtStatement.AcceptsTab = true;
            this.edtStatement.BackColor = System.Drawing.SystemColors.Window;
            this.edtStatement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtStatement.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtStatement.Location = new System.Drawing.Point(5, 56);
            this.edtStatement.Name = "edtStatement";
            this.edtStatement.Size = new System.Drawing.Size(790, 195);
            this.edtStatement.TabIndex = 0;
            this.edtStatement.TabStop = false;
            this.edtStatement.Text = "";
            this.edtStatement.WordWrap = false;
            this.edtStatement.TextChanged += new System.EventHandler(this.edtStatement_TextChanged);
            this.edtStatement.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtStatement_KeyDown);
            this.edtStatement.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtStatement_KeyPress);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(614, 8);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Accept";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(112, 8);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(88, 23);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Show Error";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(702, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            // 
            // gbParameters
            // 
            this.gbParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbParameters.Location = new System.Drawing.Point(0, 0);
            this.gbParameters.Name = "gbParameters";
            this.gbParameters.Size = new System.Drawing.Size(790, 96);
            this.gbParameters.TabIndex = 0;
            this.gbParameters.TabStop = false;
            this.gbParameters.Text = "Parameters";
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.btnCancel);
            this.pnBottom.Controls.Add(this.btnAccept);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(5, 513);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(790, 40);
            this.pnBottom.TabIndex = 4;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(8, 8);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(96, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "Execute Query";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // gridPreview
            // 
            this.gridPreview.DataMember = "";
            this.gridPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPreview.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridPreview.Location = new System.Drawing.Point(0, 136);
            this.gridPreview.Name = "gridPreview";
            this.gridPreview.ReadOnly = true;
            this.gridPreview.Size = new System.Drawing.Size(790, 122);
            this.gridPreview.TabIndex = 4;
            this.gridPreview.Visible = false;
            // 
            // edtSyntaxError
            // 
            this.edtSyntaxError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSyntaxError.Location = new System.Drawing.Point(208, 8);
            this.edtSyntaxError.Name = "edtSyntaxError";
            this.edtSyntaxError.ReadOnly = true;
            this.edtSyntaxError.Size = new System.Drawing.Size(574, 20);
            this.edtSyntaxError.TabIndex = 6;
            // 
            // pnControls
            // 
            this.pnControls.Controls.Add(this.btnQuery);
            this.pnControls.Controls.Add(this.btnCheck);
            this.pnControls.Controls.Add(this.edtSyntaxError);
            this.pnControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnControls.Location = new System.Drawing.Point(0, 96);
            this.pnControls.Name = "pnControls";
            this.pnControls.Size = new System.Drawing.Size(790, 40);
            this.pnControls.TabIndex = 7;
            // 
            // pnCenter
            // 
            this.pnCenter.Controls.Add(this.gridPreview);
            this.pnCenter.Controls.Add(this.pnControls);
            this.pnCenter.Controls.Add(this.gbParameters);
            this.pnCenter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnCenter.Location = new System.Drawing.Point(5, 255);
            this.pnCenter.Name = "pnCenter";
            this.pnCenter.Size = new System.Drawing.Size(790, 258);
            this.pnCenter.TabIndex = 8;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(5, 251);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(790, 4);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // tmrValidateSQL
            // 
            this.tmrValidateSQL.Interval = 500;
            this.tmrValidateSQL.Tick += new System.EventHandler(this.tmrValidateSQL_Tick);
            // 
            // gbConnection
            // 
            this.gbConnection.Controls.Add(this.chbSuppressContinuousChecks);
            this.gbConnection.Controls.Add(this.edtConnection);
            this.gbConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbConnection.Location = new System.Drawing.Point(5, 5);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(790, 51);
            this.gbConnection.TabIndex = 10;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "Connection";
            // 
            // chbSuppressContinuousChecks
            // 
            this.chbSuppressContinuousChecks.AutoSize = true;
            this.chbSuppressContinuousChecks.Location = new System.Drawing.Point(405, 21);
            this.chbSuppressContinuousChecks.Name = "chbSuppressContinuousChecks";
            this.chbSuppressContinuousChecks.Size = new System.Drawing.Size(163, 17);
            this.chbSuppressContinuousChecks.TabIndex = 1;
            this.chbSuppressContinuousChecks.Text = "Suppress continuous checks";
            this.chbSuppressContinuousChecks.UseVisualStyleBackColor = true;
            this.chbSuppressContinuousChecks.CheckedChanged += new System.EventHandler(this.chbSuppressContinuousChecks_CheckedChanged);
            // 
            // edtConnection
            // 
            this.edtConnection.DisplayMember = "Key";
            this.edtConnection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edtConnection.FormattingEnabled = true;
            this.edtConnection.IntegralHeight = false;
            this.edtConnection.Location = new System.Drawing.Point(8, 19);
            this.edtConnection.MaxDropDownItems = 14;
            this.edtConnection.Name = "edtConnection";
            this.edtConnection.Size = new System.Drawing.Size(372, 21);
            this.edtConnection.TabIndex = 0;
            this.edtConnection.ValueMember = "Value";
            this.edtConnection.SelectedIndexChanged += new System.EventHandler(this.edtConnection_SelectedIndexChanged);
            // 
            // DlgSqlStatementEditorForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(800, 558);
            this.Controls.Add(this.edtStatement);
            this.Controls.Add(this.gbConnection);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnCenter);
            this.Controls.Add(this.pnBottom);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DlgSqlStatementEditorForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Edit SQL Statement";
            this.pnBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPreview)).EndInit();
            this.pnControls.ResumeLayout(false);
            this.pnControls.PerformLayout();
            this.pnCenter.ResumeLayout(false);
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.CheckBox chbSuppressContinuousChecks;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ComboBox edtConnection;
        private System.Windows.Forms.RichTextBox edtStatement;
        private System.Windows.Forms.TextBox edtSyntaxError;
        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.GroupBox gbParameters;
        private System.Windows.Forms.DataGrid gridPreview;
        private System.Windows.Forms.Panel pnBottom;
        private System.Windows.Forms.Panel pnCenter;
        private System.Windows.Forms.Panel pnControls;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Timer tmrValidateSQL;
    }
}
