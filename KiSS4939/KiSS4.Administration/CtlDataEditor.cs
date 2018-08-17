using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration
{
    /// <summary>
    /// Form, used for BIAGAdmins to view and edit data
    /// </summary>
    public sealed class CtlDataEditor : KissUserControl
    {
        #region Fields

        #region Private Fields

        private bool _isLoadingControl = true; // flag used to prevent loading data when opening dataeditor
        private string _selectedRowAsString = "";
        private string _tableName;
        private bool _updating;
        private KiSS4.Gui.KissButton btnExecSQL;
        private KiSS4.Gui.KissButton btnExport;
        private KiSS4.Gui.KissButton btnExportDiagram;
        private KiSS4.Gui.KissButton btnExportDynaMask;
        private KiSS4.Gui.KissButton btnImport;
        private KiSS4.Gui.KissButton btnMigrationPersonRTF;
        private KiSS4.Gui.KissButton btnRunQuery;
        private KiSS4.Gui.KissCheckEdit chkGoEachRow;
        private KiSS4.Gui.KissCheckEdit chkIncludeIdentity;
        private KiSS4.Gui.KissCheckEdit chkReadOnly;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissLookUpEdit edtExportDiagrams;
        private KissTextEdit edtGrund;
        private KiSS4.Gui.KissMemoEdit edtSQLStatement;
        private KiSS4.Gui.KissComboBox edtTableName;
        private KiSS4.Gui.KissGrid grdData;
        private KiSS4.Gui.KissGroupBox grpExportData;
        private KiSS4.Gui.KissGroupBox grpExportDiagram;
        private KiSS4.Gui.KissGroupBox grpExportFF;
        private KiSS4.Gui.KissGroupBox grpImportData;
        private KiSS4.Gui.KissGroupBox grpImportMigrationRTF;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private KissLabel lblAnzahlDatensaetze;
        private KiSS4.Gui.KissLabel lblExportDiagram;
        private KissLabel lblExportFFData;
        private KissLabel lblGrund;
        private System.Windows.Forms.Label lblMigrationStatus1;
        private System.Windows.Forms.Label lblMigrationStatus2;
        private System.Windows.Forms.Label lblRowCount;
        private KiSS4.Gui.KissLabel lblSQLStatement;
        private KiSS4.Gui.KissLabel lblTableName;
        private Panel panDataControl;
        private Panel panTopGrid;
        private KiSS4.DB.SqlQuery qry;
        private System.Windows.Forms.RadioButton radExportBcp;
        private System.Windows.Forms.RadioButton radExportSQLScript;
        private System.Windows.Forms.RadioButton radExportXml;
        private System.Windows.Forms.RadioButton radImportBcp;
        private System.Windows.Forms.RadioButton radImportSQLScript;
        private System.Windows.Forms.RadioButton radImportXml;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private KissSplitterCollapsible splitter;
        private KiSS4.Gui.KissTabControlEx tabDatenEditor;
        private SharpLibrary.WinControls.TabPageEx tpgExport;
        private SharpLibrary.WinControls.TabPageEx tpgImport;
        private SharpLibrary.WinControls.TabPageEx tpgListe;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlDataEditor"/> class.
        /// </summary>
        public CtlDataEditor()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // check if user has rights to see control
            if (!HasUserAccessToForm())
            {
                // lock stuff due to security
                tabDatenEditor.Enabled = false;
                panDataControl.Enabled = false;
                ActiveSQLQuery = null;

                // show message
                KissMsg.ShowInfo(Name, "AccessDenied", "Sie besitzen keine Rechte für die Benutzung des Dateneditors!");
            }
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qry = new KiSS4.DB.SqlQuery(this.components);
            this.edtTableName = new KiSS4.Gui.KissComboBox();
            this.lblTableName = new KiSS4.Gui.KissLabel();
            this.edtSQLStatement = new KiSS4.Gui.KissMemoEdit();
            this.lblSQLStatement = new KiSS4.Gui.KissLabel();
            this.chkReadOnly = new KiSS4.Gui.KissCheckEdit();
            this.btnExecSQL = new KiSS4.Gui.KissButton();
            this.btnRunQuery = new KiSS4.Gui.KissButton();
            this.tabDatenEditor = new KiSS4.Gui.KissTabControlEx();
            this.tpgExport = new SharpLibrary.WinControls.TabPageEx();
            this.grpExportFF = new KiSS4.Gui.KissGroupBox();
            this.lblExportFFData = new KiSS4.Gui.KissLabel();
            this.btnExportDynaMask = new KiSS4.Gui.KissButton();
            this.grpExportDiagram = new KiSS4.Gui.KissGroupBox();
            this.lblExportDiagram = new KiSS4.Gui.KissLabel();
            this.btnExportDiagram = new KiSS4.Gui.KissButton();
            this.edtExportDiagrams = new KiSS4.Gui.KissLookUpEdit();
            this.grpExportData = new KiSS4.Gui.KissGroupBox();
            this.chkGoEachRow = new KiSS4.Gui.KissCheckEdit();
            this.radExportXml = new System.Windows.Forms.RadioButton();
            this.btnExport = new KiSS4.Gui.KissButton();
            this.radExportBcp = new System.Windows.Forms.RadioButton();
            this.chkIncludeIdentity = new KiSS4.Gui.KissCheckEdit();
            this.radExportSQLScript = new System.Windows.Forms.RadioButton();
            this.tpgListe = new SharpLibrary.WinControls.TabPageEx();
            this.grdData = new KiSS4.Gui.KissGrid();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panTopGrid = new System.Windows.Forms.Panel();
            this.lblAnzahlDatensaetze = new KiSS4.Gui.KissLabel();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.tpgImport = new SharpLibrary.WinControls.TabPageEx();
            this.grpImportMigrationRTF = new KiSS4.Gui.KissGroupBox();
            this.btnMigrationPersonRTF = new KiSS4.Gui.KissButton();
            this.lblMigrationStatus2 = new System.Windows.Forms.Label();
            this.lblMigrationStatus1 = new System.Windows.Forms.Label();
            this.grpImportData = new KiSS4.Gui.KissGroupBox();
            this.radImportXml = new System.Windows.Forms.RadioButton();
            this.radImportBcp = new System.Windows.Forms.RadioButton();
            this.radImportSQLScript = new System.Windows.Forms.RadioButton();
            this.btnImport = new KiSS4.Gui.KissButton();
            this.panDataControl = new System.Windows.Forms.Panel();
            this.lblGrund = new KiSS4.Gui.KissLabel();
            this.edtGrund = new KiSS4.Gui.KissTextEdit();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTableName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTableName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSQLStatement.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSQLStatement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReadOnly.Properties)).BeginInit();
            this.tabDatenEditor.SuspendLayout();
            this.tpgExport.SuspendLayout();
            this.grpExportFF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblExportFFData)).BeginInit();
            this.grpExportDiagram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblExportDiagram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExportDiagrams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExportDiagrams.Properties)).BeginInit();
            this.grpExportData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkGoEachRow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeIdentity.Properties)).BeginInit();
            this.tpgListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.panTopGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlDatensaetze)).BeginInit();
            this.tpgImport.SuspendLayout();
            this.grpImportMigrationRTF.SuspendLayout();
            this.grpImportData.SuspendLayout();
            this.panDataControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrund.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // qry
            //
            this.qry.HostControl = this;
            this.qry.BeforePost += new System.EventHandler(this.qry_BeforePost);
            this.qry.PositionChanged += new System.EventHandler(this.qry_PositionChanged);
            this.qry.AfterInsert += new System.EventHandler(this.qry_AfterInsert);
            this.qry.BeforeInsert += new System.EventHandler(this.qry_BeforeInsert);
            this.qry.BeforeDeleteQuestion += new System.EventHandler(this.qry_BeforeDeleteQuestion);
            this.qry.AfterPost += new System.EventHandler(this.qry_AfterPost);
            this.qry.AfterDelete += new System.EventHandler(this.qry_AfterDelete);
            //
            // edtTableName
            //
            this.edtTableName.EditValue = "";
            this.edtTableName.Location = new System.Drawing.Point(68, 12);
            this.edtTableName.Name = "edtTableName";
            this.edtTableName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTableName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTableName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTableName.Properties.Appearance.Options.UseBackColor = true;
            this.edtTableName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTableName.Properties.Appearance.Options.UseFont = true;
            this.edtTableName.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTableName.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTableName.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTableName.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTableName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtTableName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtTableName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTableName.Size = new System.Drawing.Size(297, 24);
            this.edtTableName.TabIndex = 1;
            this.edtTableName.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.edtTableName_CloseUp);
            this.edtTableName.Leave += new System.EventHandler(this.edtTableName_Leave);
            //
            // lblTableName
            //
            this.lblTableName.Location = new System.Drawing.Point(12, 12);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(50, 24);
            this.lblTableName.TabIndex = 0;
            this.lblTableName.Text = "Tabelle";
            //
            // edtSQLStatement
            //
            this.edtSQLStatement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSQLStatement.Location = new System.Drawing.Point(68, 42);
            this.edtSQLStatement.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtSQLStatement.Name = "edtSQLStatement";
            this.edtSQLStatement.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSQLStatement.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSQLStatement.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSQLStatement.Properties.Appearance.Options.UseBackColor = true;
            this.edtSQLStatement.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSQLStatement.Properties.Appearance.Options.UseFont = true;
            this.edtSQLStatement.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSQLStatement.Size = new System.Drawing.Size(594, 86);
            this.edtSQLStatement.TabIndex = 3;
            //
            // lblSQLStatement
            //
            this.lblSQLStatement.Location = new System.Drawing.Point(12, 42);
            this.lblSQLStatement.Name = "lblSQLStatement";
            this.lblSQLStatement.Size = new System.Drawing.Size(50, 24);
            this.lblSQLStatement.TabIndex = 2;
            this.lblSQLStatement.Text = "SQL";
            //
            // chkReadOnly
            //
            this.chkReadOnly.EditValue = true;
            this.chkReadOnly.Location = new System.Drawing.Point(6, 13);
            this.chkReadOnly.Name = "chkReadOnly";
            this.chkReadOnly.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkReadOnly.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkReadOnly.Properties.Appearance.Options.UseBackColor = true;
            this.chkReadOnly.Properties.Appearance.Options.UseFont = true;
            this.chkReadOnly.Properties.Caption = "Schreibschutz";
            this.chkReadOnly.Size = new System.Drawing.Size(106, 19);
            this.chkReadOnly.TabIndex = 0;
            this.chkReadOnly.CheckedChanged += new System.EventHandler(this.chkReadOnly_CheckedChanged);
            //
            // btnExecSQL
            //
            this.btnExecSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecSQL.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExecSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecSQL.Location = new System.Drawing.Point(674, 72);
            this.btnExecSQL.Name = "btnExecSQL";
            this.btnExecSQL.Size = new System.Drawing.Size(106, 24);
            this.btnExecSQL.TabIndex = 7;
            this.btnExecSQL.Text = "Ausführen";
            this.btnExecSQL.UseVisualStyleBackColor = false;
            this.btnExecSQL.Click += new System.EventHandler(this.btnExecSQL_Click);
            //
            // btnRunQuery
            //
            this.btnRunQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunQuery.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRunQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunQuery.Location = new System.Drawing.Point(674, 42);
            this.btnRunQuery.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.btnRunQuery.Name = "btnRunQuery";
            this.btnRunQuery.Size = new System.Drawing.Size(106, 24);
            this.btnRunQuery.TabIndex = 6;
            this.btnRunQuery.Text = "Abfragen";
            this.btnRunQuery.UseVisualStyleBackColor = false;
            this.btnRunQuery.Click += new System.EventHandler(this.btnRunQuery_Click);
            //
            // tabDatenEditor
            //
            this.tabDatenEditor.Controls.Add(this.tpgExport);
            this.tabDatenEditor.Controls.Add(this.tpgListe);
            this.tabDatenEditor.Controls.Add(this.tpgImport);
            this.tabDatenEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDatenEditor.Location = new System.Drawing.Point(0, 164);
            this.tabDatenEditor.Name = "tabDatenEditor";
            this.tabDatenEditor.ShowFixedWidthTooltip = true;
            this.tabDatenEditor.Size = new System.Drawing.Size(792, 391);
            this.tabDatenEditor.TabIndex = 1;
            this.tabDatenEditor.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe,
            this.tpgExport,
            this.tpgImport});
            this.tabDatenEditor.TabsLineColor = System.Drawing.Color.Black;
            this.tabDatenEditor.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabDatenEditor.TabStop = false;
            this.tabDatenEditor.Text = "xTabControl2";
            this.tabDatenEditor.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabDatenEditor_SelectedTabChanged);
            //
            // tpgExport
            //
            this.tpgExport.Controls.Add(this.grpExportFF);
            this.tpgExport.Controls.Add(this.grpExportDiagram);
            this.tpgExport.Controls.Add(this.grpExportData);
            this.tpgExport.Location = new System.Drawing.Point(6, 6);
            this.tpgExport.Name = "tpgExport";
            this.tpgExport.Size = new System.Drawing.Size(780, 353);
            this.tpgExport.TabIndex = 0;
            this.tpgExport.Title = "Export";
            this.tpgExport.Visible = false;
            //
            // grpExportFF
            //
            this.grpExportFF.Controls.Add(this.lblExportFFData);
            this.grpExportFF.Controls.Add(this.btnExportDynaMask);
            this.grpExportFF.Location = new System.Drawing.Point(512, 12);
            this.grpExportFF.Name = "grpExportFF";
            this.grpExportFF.Size = new System.Drawing.Size(200, 120);
            this.grpExportFF.TabIndex = 2;
            this.grpExportFF.TabStop = false;
            this.grpExportFF.Text = "Fallführungsdaten";
            //
            // lblExportFFData
            //
            this.lblExportFFData.Location = new System.Drawing.Point(9, 51);
            this.lblExportFFData.Name = "lblExportFFData";
            this.lblExportFFData.Size = new System.Drawing.Size(179, 24);
            this.lblExportFFData.TabIndex = 0;
            this.lblExportFFData.Text = "DynaMask-Daten exportieren:";
            //
            // btnExportDynaMask
            //
            this.btnExportDynaMask.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExportDynaMask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportDynaMask.Location = new System.Drawing.Point(12, 84);
            this.btnExportDynaMask.Margin = new System.Windows.Forms.Padding(9);
            this.btnExportDynaMask.Name = "btnExportDynaMask";
            this.btnExportDynaMask.Size = new System.Drawing.Size(176, 24);
            this.btnExportDynaMask.TabIndex = 1;
            this.btnExportDynaMask.Text = "Export Fallführung";
            this.btnExportDynaMask.UseVisualStyleBackColor = false;
            this.btnExportDynaMask.Click += new System.EventHandler(this.btnExportFF_Click);
            //
            // grpExportDiagram
            //
            this.grpExportDiagram.Controls.Add(this.lblExportDiagram);
            this.grpExportDiagram.Controls.Add(this.btnExportDiagram);
            this.grpExportDiagram.Controls.Add(this.edtExportDiagrams);
            this.grpExportDiagram.Location = new System.Drawing.Point(252, 12);
            this.grpExportDiagram.Name = "grpExportDiagram";
            this.grpExportDiagram.Size = new System.Drawing.Size(254, 120);
            this.grpExportDiagram.TabIndex = 1;
            this.grpExportDiagram.TabStop = false;
            this.grpExportDiagram.Text = "Diagramm";
            //
            // lblExportDiagram
            //
            this.lblExportDiagram.Location = new System.Drawing.Point(9, 21);
            this.lblExportDiagram.Name = "lblExportDiagram";
            this.lblExportDiagram.Size = new System.Drawing.Size(233, 24);
            this.lblExportDiagram.TabIndex = 0;
            this.lblExportDiagram.Text = "Diagramm wählen:";
            //
            // btnExportDiagram
            //
            this.btnExportDiagram.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExportDiagram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportDiagram.Location = new System.Drawing.Point(12, 84);
            this.btnExportDiagram.Margin = new System.Windows.Forms.Padding(9);
            this.btnExportDiagram.Name = "btnExportDiagram";
            this.btnExportDiagram.Size = new System.Drawing.Size(230, 24);
            this.btnExportDiagram.TabIndex = 2;
            this.btnExportDiagram.Text = "Export Diagramm";
            this.btnExportDiagram.UseVisualStyleBackColor = false;
            this.btnExportDiagram.Click += new System.EventHandler(this.btnExportDiagram_Click);
            //
            // edtExportDiagrams
            //
            this.edtExportDiagrams.Location = new System.Drawing.Point(12, 48);
            this.edtExportDiagrams.Name = "edtExportDiagrams";
            this.edtExportDiagrams.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtExportDiagrams.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExportDiagrams.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExportDiagrams.Properties.Appearance.Options.UseBackColor = true;
            this.edtExportDiagrams.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExportDiagrams.Properties.Appearance.Options.UseFont = true;
            this.edtExportDiagrams.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtExportDiagrams.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtExportDiagrams.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtExportDiagrams.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtExportDiagrams.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtExportDiagrams.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtExportDiagrams.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtExportDiagrams.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("value")});
            this.edtExportDiagrams.Properties.DisplayMember = "value";
            this.edtExportDiagrams.Properties.NullText = "";
            this.edtExportDiagrams.Properties.ShowFooter = false;
            this.edtExportDiagrams.Properties.ShowHeader = false;
            this.edtExportDiagrams.Properties.ValueMember = "objectid";
            this.edtExportDiagrams.Size = new System.Drawing.Size(230, 24);
            this.edtExportDiagrams.TabIndex = 1;
            //
            // grpExportData
            //
            this.grpExportData.Controls.Add(this.chkGoEachRow);
            this.grpExportData.Controls.Add(this.radExportXml);
            this.grpExportData.Controls.Add(this.btnExport);
            this.grpExportData.Controls.Add(this.radExportBcp);
            this.grpExportData.Controls.Add(this.chkIncludeIdentity);
            this.grpExportData.Controls.Add(this.radExportSQLScript);
            this.grpExportData.Location = new System.Drawing.Point(12, 12);
            this.grpExportData.Name = "grpExportData";
            this.grpExportData.Size = new System.Drawing.Size(234, 185);
            this.grpExportData.TabIndex = 0;
            this.grpExportData.TabStop = false;
            this.grpExportData.Text = "Daten";
            //
            // chkGoEachRow
            //
            this.chkGoEachRow.EditValue = false;
            this.chkGoEachRow.Location = new System.Drawing.Point(115, 21);
            this.chkGoEachRow.Name = "chkGoEachRow";
            this.chkGoEachRow.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkGoEachRow.Properties.Appearance.Options.UseBackColor = true;
            this.chkGoEachRow.Properties.Caption = "GO for each row";
            this.chkGoEachRow.Size = new System.Drawing.Size(107, 19);
            this.chkGoEachRow.TabIndex = 1;
            //
            // radExportXml
            //
            this.radExportXml.Enabled = false;
            this.radExportXml.Location = new System.Drawing.Point(12, 80);
            this.radExportXml.Name = "radExportXml";
            this.radExportXml.Size = new System.Drawing.Size(97, 24);
            this.radExportXml.TabIndex = 3;
            this.radExportXml.Text = "Xml";
            //
            // btnExport
            //
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Location = new System.Drawing.Point(12, 149);
            this.btnExport.Margin = new System.Windows.Forms.Padding(9);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(210, 24);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Data Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            //
            // radExportBcp
            //
            this.radExportBcp.Enabled = false;
            this.radExportBcp.Location = new System.Drawing.Point(12, 50);
            this.radExportBcp.Name = "radExportBcp";
            this.radExportBcp.Size = new System.Drawing.Size(97, 24);
            this.radExportBcp.TabIndex = 2;
            this.radExportBcp.Text = "Bcp";
            //
            // chkIncludeIdentity
            //
            this.chkIncludeIdentity.EditValue = false;
            this.chkIncludeIdentity.Location = new System.Drawing.Point(12, 118);
            this.chkIncludeIdentity.Name = "chkIncludeIdentity";
            this.chkIncludeIdentity.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkIncludeIdentity.Properties.Appearance.Options.UseBackColor = true;
            this.chkIncludeIdentity.Properties.Caption = "Include identity values";
            this.chkIncludeIdentity.Size = new System.Drawing.Size(210, 19);
            this.chkIncludeIdentity.TabIndex = 4;
            //
            // radExportSQLScript
            //
            this.radExportSQLScript.Checked = true;
            this.radExportSQLScript.Location = new System.Drawing.Point(12, 20);
            this.radExportSQLScript.Name = "radExportSQLScript";
            this.radExportSQLScript.Size = new System.Drawing.Size(97, 24);
            this.radExportSQLScript.TabIndex = 0;
            this.radExportSQLScript.TabStop = true;
            this.radExportSQLScript.Text = "SQL-Script";
            //
            // tpgListe
            //
            this.tpgListe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tpgListe.Controls.Add(this.grdData);
            this.tpgListe.Controls.Add(this.panTopGrid);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Name = "tpgListe";
            this.tpgListe.Size = new System.Drawing.Size(780, 353);
            this.tpgListe.TabIndex = 1;
            this.tpgListe.Title = "Liste";
            //
            // grdData
            //
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.EmbeddedNavigator.Name = "";
            this.grdData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdData.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdData.Location = new System.Drawing.Point(0, 36);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoExEdit1,
            this.repositoryItemButtonEdit1});
            this.grdData.Size = new System.Drawing.Size(780, 317);
            this.grdData.TabIndex = 1;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            //
            // grvData
            //
            this.grvData.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvData.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvData.Appearance.Empty.Options.UseBackColor = true;
            this.grvData.Appearance.Empty.Options.UseFont = true;
            this.grvData.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvData.Appearance.EvenRow.Options.UseFont = true;
            this.grvData.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvData.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvData.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvData.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvData.Appearance.FocusedCell.Options.UseFont = true;
            this.grvData.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvData.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvData.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvData.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvData.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvData.Appearance.FocusedRow.Options.UseFont = true;
            this.grvData.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvData.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvData.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvData.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvData.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvData.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvData.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvData.Appearance.GroupRow.Options.UseFont = true;
            this.grvData.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvData.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvData.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvData.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvData.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvData.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvData.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvData.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvData.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvData.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvData.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvData.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvData.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvData.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvData.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvData.Appearance.OddRow.Options.UseFont = true;
            this.grvData.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvData.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvData.Appearance.Row.Options.UseBackColor = true;
            this.grvData.Appearance.Row.Options.UseFont = true;
            this.grvData.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvData.Appearance.SelectedRow.Options.UseFont = true;
            this.grvData.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvData.Appearance.VertLine.Options.UseBackColor = true;
            this.grvData.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvData.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.Editable = false;
            this.grvData.OptionsCustomization.AllowFilter = false;
            this.grvData.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvData.OptionsNavigation.AutoFocusNewRow = true;
            this.grvData.OptionsNavigation.UseTabKey = false;
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.OptionsView.ShowIndicator = false;
            this.grvData.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.grvData_CustomRowCellEdit);
            //
            // repositoryItemMemoEdit1
            //
            this.repositoryItemMemoEdit1.Appearance.BackColor = System.Drawing.Color.LightCoral;
            this.repositoryItemMemoEdit1.Appearance.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemMemoEdit1.Appearance.Options.UseBackColor = true;
            this.repositoryItemMemoEdit1.Appearance.Options.UseFont = true;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            //
            // repositoryItemMemoExEdit1
            //
            this.repositoryItemMemoExEdit1.Appearance.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.repositoryItemMemoExEdit1.Appearance.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemMemoExEdit1.Appearance.Options.UseBackColor = true;
            this.repositoryItemMemoExEdit1.Appearance.Options.UseFont = true;
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            this.repositoryItemMemoExEdit1.ShowIcon = false;
            //
            // repositoryItemButtonEdit1
            //
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            //
            // panTopGrid
            //
            this.panTopGrid.Controls.Add(this.lblAnzahlDatensaetze);
            this.panTopGrid.Controls.Add(this.lblRowCount);
            this.panTopGrid.Controls.Add(this.chkReadOnly);
            this.panTopGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTopGrid.Location = new System.Drawing.Point(0, 0);
            this.panTopGrid.Name = "panTopGrid";
            this.panTopGrid.Size = new System.Drawing.Size(780, 36);
            this.panTopGrid.TabIndex = 0;
            //
            // lblAnzahlDatensaetze
            //
            this.lblAnzahlDatensaetze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnzahlDatensaetze.Location = new System.Drawing.Point(586, 9);
            this.lblAnzahlDatensaetze.Margin = new System.Windows.Forms.Padding(6);
            this.lblAnzahlDatensaetze.Name = "lblAnzahlDatensaetze";
            this.lblAnzahlDatensaetze.Size = new System.Drawing.Size(112, 24);
            this.lblAnzahlDatensaetze.TabIndex = 1;
            this.lblAnzahlDatensaetze.Text = "Anzahl Datensätze:";
            //
            // lblRowCount
            //
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowCount.Location = new System.Drawing.Point(707, 15);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(14, 13);
            this.lblRowCount.TabIndex = 2;
            this.lblRowCount.Text = "0";
            //
            // tpgImport
            //
            this.tpgImport.Controls.Add(this.grpImportMigrationRTF);
            this.tpgImport.Controls.Add(this.grpImportData);
            this.tpgImport.Location = new System.Drawing.Point(6, 6);
            this.tpgImport.Name = "tpgImport";
            this.tpgImport.Size = new System.Drawing.Size(780, 353);
            this.tpgImport.TabIndex = 2;
            this.tpgImport.Title = "Import";
            //
            // grpImportMigrationRTF
            //
            this.grpImportMigrationRTF.Controls.Add(this.btnMigrationPersonRTF);
            this.grpImportMigrationRTF.Controls.Add(this.lblMigrationStatus2);
            this.grpImportMigrationRTF.Controls.Add(this.lblMigrationStatus1);
            this.grpImportMigrationRTF.Location = new System.Drawing.Point(151, 12);
            this.grpImportMigrationRTF.Name = "grpImportMigrationRTF";
            this.grpImportMigrationRTF.Size = new System.Drawing.Size(460, 152);
            this.grpImportMigrationRTF.TabIndex = 1;
            this.grpImportMigrationRTF.TabStop = false;
            this.grpImportMigrationRTF.Text = "Migration";
            //
            // btnMigrationPersonRTF
            //
            this.btnMigrationPersonRTF.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMigrationPersonRTF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMigrationPersonRTF.Location = new System.Drawing.Point(12, 20);
            this.btnMigrationPersonRTF.Name = "btnMigrationPersonRTF";
            this.btnMigrationPersonRTF.Size = new System.Drawing.Size(233, 24);
            this.btnMigrationPersonRTF.TabIndex = 0;
            this.btnMigrationPersonRTF.Text = "Migration PersonenRTF";
            this.btnMigrationPersonRTF.UseVisualStyleBackColor = false;
            this.btnMigrationPersonRTF.Click += new System.EventHandler(this.btnMigrationPersonRTF_Click);
            //
            // lblMigrationStatus2
            //
            this.lblMigrationStatus2.AutoSize = true;
            this.lblMigrationStatus2.Location = new System.Drawing.Point(9, 102);
            this.lblMigrationStatus2.Name = "lblMigrationStatus2";
            this.lblMigrationStatus2.Size = new System.Drawing.Size(110, 15);
            this.lblMigrationStatus2.TabIndex = 2;
            this.lblMigrationStatus2.Text = "Migrations-Status2";
            this.lblMigrationStatus2.Visible = false;
            //
            // lblMigrationStatus1
            //
            this.lblMigrationStatus1.AutoSize = true;
            this.lblMigrationStatus1.Location = new System.Drawing.Point(9, 68);
            this.lblMigrationStatus1.Name = "lblMigrationStatus1";
            this.lblMigrationStatus1.Size = new System.Drawing.Size(110, 15);
            this.lblMigrationStatus1.TabIndex = 1;
            this.lblMigrationStatus1.Text = "Migrations-Status1";
            this.lblMigrationStatus1.Visible = false;
            //
            // grpImportData
            //
            this.grpImportData.Controls.Add(this.radImportXml);
            this.grpImportData.Controls.Add(this.radImportBcp);
            this.grpImportData.Controls.Add(this.radImportSQLScript);
            this.grpImportData.Controls.Add(this.btnImport);
            this.grpImportData.Location = new System.Drawing.Point(12, 12);
            this.grpImportData.Name = "grpImportData";
            this.grpImportData.Size = new System.Drawing.Size(133, 152);
            this.grpImportData.TabIndex = 0;
            this.grpImportData.TabStop = false;
            this.grpImportData.Text = "Daten";
            //
            // radImportXml
            //
            this.radImportXml.Enabled = false;
            this.radImportXml.Location = new System.Drawing.Point(12, 80);
            this.radImportXml.Name = "radImportXml";
            this.radImportXml.Size = new System.Drawing.Size(107, 24);
            this.radImportXml.TabIndex = 2;
            this.radImportXml.Text = "Xml";
            //
            // radImportBcp
            //
            this.radImportBcp.Enabled = false;
            this.radImportBcp.Location = new System.Drawing.Point(12, 50);
            this.radImportBcp.Name = "radImportBcp";
            this.radImportBcp.Size = new System.Drawing.Size(109, 24);
            this.radImportBcp.TabIndex = 1;
            this.radImportBcp.Text = "Bcp";
            //
            // radImportSQLScript
            //
            this.radImportSQLScript.Checked = true;
            this.radImportSQLScript.Location = new System.Drawing.Point(12, 20);
            this.radImportSQLScript.Name = "radImportSQLScript";
            this.radImportSQLScript.Size = new System.Drawing.Size(107, 24);
            this.radImportSQLScript.TabIndex = 0;
            this.radImportSQLScript.TabStop = true;
            this.radImportSQLScript.Text = "SQL-Script";
            //
            // btnImport
            //
            this.btnImport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(12, 116);
            this.btnImport.Margin = new System.Windows.Forms.Padding(9);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(109, 24);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            //
            // panDataControl
            //
            this.panDataControl.Controls.Add(this.lblGrund);
            this.panDataControl.Controls.Add(this.edtGrund);
            this.panDataControl.Controls.Add(this.lblTableName);
            this.panDataControl.Controls.Add(this.edtTableName);
            this.panDataControl.Controls.Add(this.edtSQLStatement);
            this.panDataControl.Controls.Add(this.btnRunQuery);
            this.panDataControl.Controls.Add(this.lblSQLStatement);
            this.panDataControl.Controls.Add(this.btnExecSQL);
            this.panDataControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panDataControl.Location = new System.Drawing.Point(0, 0);
            this.panDataControl.Name = "panDataControl";
            this.panDataControl.Size = new System.Drawing.Size(792, 164);
            this.panDataControl.TabIndex = 0;
            //
            // lblGrund
            //
            this.lblGrund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGrund.Location = new System.Drawing.Point(12, 134);
            this.lblGrund.Name = "lblGrund";
            this.lblGrund.Size = new System.Drawing.Size(50, 24);
            this.lblGrund.TabIndex = 4;
            this.lblGrund.Text = "Grund";
            //
            // edtGrund
            //
            this.edtGrund.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGrund.EditValue = "";
            this.edtGrund.Location = new System.Drawing.Point(68, 134);
            this.edtGrund.Name = "edtGrund";
            this.edtGrund.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrund.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrund.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrund.Properties.Appearance.Options.UseFont = true;
            this.edtGrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrund.Properties.Name = "editSAR.Properties";
            this.edtGrund.Size = new System.Drawing.Size(712, 24);
            this.edtGrund.TabIndex = 5;
            //
            // splitter
            //
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.panDataControl;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 164);
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 5;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            //
            // CtlDataEditor
            //
            this.ActiveSQLQuery = this.qry;
            this.ClientSize = new System.Drawing.Size(792, 555);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.tabDatenEditor);
            this.Controls.Add(this.panDataControl);
            this.Name = "CtlDataEditor";
            this.Text = "Dateneditor";
            this.Load += new System.EventHandler(this.CtlDataEditor_Load);
            this.VisibleChanged += new System.EventHandler(this.CtlDataEditor_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.qry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTableName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTableName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSQLStatement.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSQLStatement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReadOnly.Properties)).EndInit();
            this.tabDatenEditor.ResumeLayout(false);
            this.tpgExport.ResumeLayout(false);
            this.grpExportFF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblExportFFData)).EndInit();
            this.grpExportDiagram.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblExportDiagram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExportDiagrams.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExportDiagrams)).EndInit();
            this.grpExportData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkGoEachRow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeIdentity.Properties)).EndInit();
            this.tpgListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.panTopGrid.ResumeLayout(false);
            this.panTopGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlDatensaetze)).EndInit();
            this.tpgImport.ResumeLayout(false);
            this.grpImportMigrationRTF.ResumeLayout(false);
            this.grpImportMigrationRTF.PerformLayout();
            this.grpImportData.ResumeLayout(false);
            this.panDataControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrund.Properties)).EndInit();
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

        private void CtlDataEditor_Load(object sender, EventArgs e)
        {
            // check if user has rights to see control
            if (!HasUserAccessToForm())
            {
                // small to prevent showing too much
                Size = new Size(2, 2);
                Location = new Point(1, 1);

                // do not load anything
                return;
            }

            Size = new Size(1000, 650);
            Location = new Point(5, 5);

            tabDatenEditor.SelectedTabIndex = 0;

            grdData.View.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            grdData.View.OptionsCustomization.AllowRowSizing = true;

            // load all available tables (including XDocument if not a table)
            foreach (DataRow row in DBUtil.OpenSQL(@"
                SELECT Name
                FROM sys.tables

                UNION

                SELECT 'XDocument'
                ORDER BY Name").DataTable.Rows)
            {
                edtTableName.Properties.Items.Add(row["Name"]);
            }

            if (edtTableName.Properties.Items.Count > 0)
            {
                edtTableName.SelectedIndex = 0;
            }

            // load all diagrams
            edtExportDiagrams.Properties.DataSource = DBUtil.OpenSQL(@"
                IF (OBJECT_ID('dtproperties') IS NOT NULL)
                BEGIN
                  SELECT objectid,
                         value
                  FROM dtproperties
                  WHERE property = 'DtgSchemaNAME'
                END");

            grdData.View.OptionsCustomization.AllowRowSizing = true;
        }

        private void CtlDataEditor_VisibleChanged(object sender, EventArgs e)
        {
            // check if user has rights to see control
            if (!HasUserAccessToForm())
            {
                // disable everything if user has no rights
                Enabled = false;
            }
        }

        private void btnExecSQL_Click(object sender, EventArgs e)
        {
            // validate
            if (DBUtil.IsEmpty(edtSQLStatement.Text))
            {
                return;
            }

            if (string.IsNullOrEmpty(edtGrund.Text))
            {
                KissMsg.ShowInfo(Name, "KeinGrund", "Kein Grund angegeben!\r\nBitte geben Sie einen Grund für die DB-Änderung an,\r\nmöglichst mit einem Verweis auf ein Incident-Ticket\r\nim Format #5646 oder INC000000329288.");
                return;
            }

            // set cursor
            Cursor.Current = Cursors.WaitCursor;

            int rowCount = 0;

            try
            {
                grdData.DataSource = null;
                rowCount = DBUtil.ExecSQL(edtSQLStatement.Text);
            }
            finally
            {
                // Änderungen via Dateneditor müssen geloggt werden, und zwar so dass diese Einträge nicht gelöscht werden (nonpurgable)
                XLog.Create(GetType().FullName, 1, LogLevel.INFO, "ExecSQL ausgeführt, " + rowCount.ToString() + " Zeilen waren betroffen", edtGrund.Text + ": " + edtSQLStatement.Text, "", 0, true, Session.User.UserID);
                Cursor.Current = Cursors.Default;

                lblRowCount.Text = rowCount.ToString();
            }
        }

        private void btnExportDiagram_Click(object sender, EventArgs e)
        {
            try
            {
                if (DBUtil.IsEmpty(edtExportDiagrams.EditValue))
                {
                    KissMsg.ShowInfo(Name, "KeinDiagramm", "Kein Diagramm ausgewählt!");
                    return;
                }

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = "sql";

                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                // set cursor
                Cursor.Current = Cursors.WaitCursor;

                StreamWriter sw = new StreamWriter(dlg.FileName, false, System.Text.Encoding.Default);

                sw.WriteLine("/*");
                sw.WriteLine("KISS SQL Server Diagramm Export");
                sw.WriteLine("date: " + DateTime.Now.ToString("dd.MM.yyyy hh:mm"));
                sw.WriteLine("*/");
                sw.WriteLine();

                sw.WriteLine("DELETE FROM dtproperties");
                sw.WriteLine("WHERE objectid = ");
                sw.WriteLine("  (SELECT objectid ");
                sw.WriteLine("   FROM dtproperties ");
                sw.WriteLine("   WHERE property = 'DtgSchemaNAME' AND ");
                sw.WriteLine("         value = " + DBUtil.SqlLiteral(edtExportDiagrams.Text) + ")");
                sw.WriteLine();

                sw.WriteLine(@"
                        DECLARE @objectid INT
                        INSERT dtproperties (property) VALUES ('DtgSchemaOBJECT')
                        SET @objectid = @@IDENTITY
                        UPDATE dtproperties SET objectid = @objectid WHERE id = @objectid ");
                sw.WriteLine();

                SqlQuery qryDiagram = DBUtil.OpenSQL(@"
                    SELECT *
                    FROM dtproperties
                    WHERE objectid = {0} AND
                          property <> 'DtgSchemaOBJECT'", edtExportDiagrams.EditValue);

                foreach (DataRow row in qryDiagram.DataTable.Rows)
                {
                    sw.WriteLine(string.Format(@"
                        --SQLCHECK_IGNORE--
                        INSERT dtproperties (objectid, property, value, lvalue, version, uvalue)
                        VALUES (@objectid, {0}, {1}, {2}, {3}, {4})",
                            DBUtil.SqlLiteral(row["property"]),
                            DBUtil.SqlLiteral(row["value"]),
                            DBUtil.SqlLiteral(row["lvalue"]),
                            DBUtil.SqlLiteral(row["version"]),
                            DBUtil.SqlLiteral(row["uvalue"])));
                }

                sw.WriteLine();
                sw.Flush();
                sw.Close();

                // show success message
                KissMsg.ShowInfo(Name, "ExportDiagrammAbgeschlossen_v01", "Der Export des Diagramms '{0}' ist abgeschlossen!", 0, 0, edtExportDiagrams.Text);
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError(Name, "FehlerDiagrammExport_v01", "Es ist ein Fehler beim Export des Diagramms aufgetreten!", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnExportFF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = "sql";

                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                StreamWriter sw = new StreamWriter(dlg.FileName, false, System.Text.Encoding.Default);

                sw.WriteLine("/*");
                sw.WriteLine("KISS Fallführung Meta Data Export");
                sw.WriteLine("date: " + DateTime.Now.ToString("dd.MM.yyyy hh:mm"));
                sw.WriteLine("*/");
                sw.WriteLine();

                //sw.WriteLine("delete from DynaValue"); zu gefährlich!
                sw.WriteLine("-- Delete existing Fallführung Meta Data (except System LOV's)");
                sw.WriteLine();
                sw.WriteLine("DELETE LOC");
                sw.WriteLine("FROM   dbo.XLOVCode LOC");
                sw.WriteLine("  INNER JOIN dbo.XLOV LOV ON LOV.LOVName = LOC.LOVName");
                sw.WriteLine("WHERE LOV.System = 0 AND LOV.LOVName IN ");
                sw.WriteLine("      (SELECT DISTINCT LOVName FROM dbo.DynaField WHERE LOVName IS NOT NULL)");
                sw.WriteLine();
                sw.WriteLine("DELETE");
                sw.WriteLine("FROM dbo.XLOV");
                sw.WriteLine("WHERE System = 0 AND LOVName IN ");
                sw.WriteLine("      (SELECT DISTINCT LOVName FROM dbo.DynaField WHERE LOVName IS NOT NULL)");
                sw.WriteLine();
                sw.WriteLine("DELETE FROM dbo.DynaField");
                sw.WriteLine("DELETE FROM dbo.DynaMask");
                sw.WriteLine();
                sw.WriteLine();

                SqlQuery qryFf;

                // DynaMask
                qryFf = DBUtil.OpenSQL(@"
                    SELECT *
                    FROM dbo.DynaMask");

                qryFf.TableName = "DynaMask";
                qryFf.ExportDataToSqlScript(sw, "-- Table DynaMask", false, false);

                // DynaField
                qryFf = DBUtil.OpenSQL(@"
                    SELECT *
                    FROM dbo.DynaField");

                qryFf.TableName = "DynaField";
                qryFf.ExportDataToSqlScript(sw, "-- Table DynaField", false, true);

                // XLOV
                sw.WriteLine("-- Delete FF-LOV's again (including System LOV's)");
                sw.WriteLine();
                sw.WriteLine("DELETE FROM dbo.XLOVCode WHERE LOVName IN (SELECT DISTINCT LOVName FROM dbo.DynaField WHERE LOVName IS NOT NULL) ");
                sw.WriteLine("DELETE FROM dbo.XLOV WHERE LOVName IN (SELECT DISTINCT LOVName FROM dbo.DynaField WHERE LOVName IS NOT NULL) ");
                sw.WriteLine();

                qryFf = DBUtil.OpenSQL(@"
                    SELECT *
                    FROM dbo.XLOV
                    WHERE LOVName IN (SELECT DISTINCT
                                             LOVName
                                      FROM dbo.DynaField
                                      WHERE LOVName IS NOT NULL) ");

                qryFf.TableName = "XLOV";
                qryFf.ExportDataToSqlScript(sw, "-- Table XLOV", false, false);
                sw.WriteLine();

                // XLOVCode
                qryFf = DBUtil.OpenSQL(@"
                    SELECT *
                    FROM dbo.XLOVCode
                    WHERE LOVName IN (SELECT DISTINCT
                                             LOVName
                                      FROM dbo.DynaField
                                      WHERE LOVName IS NOT NULL) ");

                qryFf.TableName = "XLOVCode";
                qryFf.ExportDataToSqlScript(sw, "-- Table XLOVCode", false, false);

                sw.WriteLine();
                sw.Flush();
                sw.Close();

                // show success message
                KissMsg.ShowInfo(Name, "ExportFallAbgeschlossen_v01", "Der Export der Fallführung ist abgeschlossen!");
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError(Name, "FehlerFallfuehrungExport_v01", "Es ist ein Fehler beim Export der Fallführung aufgetreten!", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(Name, "KeineDatenZuExport_v01", "Keine Datensätze zum Exportieren!");
                return;
            }
            if (DBUtil.IsEmpty(qry.TableName))
            {
                KissMsg.ShowInfo(Name, "KeineBasistabelle_v01", "Es ist keine Basistabelle angegeben!");
                return;
            }

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "sql";
            dlg.FileName = qry.TableName + ".sql";

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            qry.ExportDataToSqlScript(dlg.FileName, null, chkGoEachRow.Checked, chkIncludeIdentity.Checked);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog { DefaultExt = "sql" };

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            string sql = new StreamReader(dlg.FileName, System.Text.Encoding.Default).ReadToEnd();

            int rows = DBUtil.ExecSQL(sql);

            Cursor.Current = Cursors.Default;

            if (rows >= 0)
            {
                KissMsg.ShowInfo(Name, "ImportAbgeschlossen_v01", "Der Datenimport ist abgeschlossen.");
            }
        }

        private void btnMigrationPersonRTF_Click(object sender, EventArgs e)
        {
            // TODO: this will not work as table BaDossiermember does no more exist...
            string sql = @"
                SELECT PRS.BaPersonID,
                       Remark = BDM.Bemerkung,
                       PRS.Bemerkung
                FROM dbo.BaDossiermember BDM
                  INNER JOIN dbo.BaPerson PRS ON PRS.BaPersonID = BDM.BaPersonID
                WHERE LEN(BDM.Bemerkung) > 2";

            MigratePersonRTF(sql, lblMigrationStatus1, "alte Dossiermitglied-Bemerkungen", "migrierte Dossiermitglied-Bemerkung");

            sql = @"
                SELECT PRS.BaPersonID,
                       DOS.Remark,
                       PRS.Bemerkung
                FROM tdfkissdossier DOS
                  INNER JOIN dbo.BaPerson PRS ON PRS.BaPersonID = DOS.IdClient
                WHERE LEN(DOS.Remark) > 2";

            MigratePersonRTF(sql, lblMigrationStatus2, "alte Dossier-Bemerkungen", "migrierte Dossier-Bemerkung");
        }

        private void btnRunQuery_Click(object sender, EventArgs e)
        {
            grdData.DataSource = null;

            if (edtSQLStatement.Text.Length == 0)
            {
                lblRowCount.Text = "0";
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;

                int rowCount = 0;

                try
                {
                    qry.DataTable.Columns.Clear();
                    qry.Fill(edtSQLStatement.Text);

                    grdData.View.Columns.Clear();
                    grdData.DataSource = qry;
                    grdData.View.BestFitColumns();

                    rowCount = qry.Count;

                    //set memoedit
                    foreach (DataColumn col in qry.DataTable.Columns)
                    {
                        if (col.DataType == typeof(string))
                        {
                            grdData.View.Columns[col.ColumnName].ColumnEdit = repositoryItemMemoExEdit1;
                            grdData.View.Columns[col.ColumnName].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
                        }
                    }
                }
                finally
                {
                    // reset cursor
                    Cursor.Current = Cursors.Default;

                    lblRowCount.Text = rowCount.ToString();
                    // Abfragen via Dateneditor müssen geloggt werden
                    XLog.Create(GetType().FullName, 2, LogLevel.INFO, "SQL Query ausgeführt (" + rowCount.ToString() + " Zeilen wurden zurückgegeben)", edtSQLStatement.Text, "", 0, false, Session.User.UserID);

                    Cursor.Current = Cursors.Default;

                    if (qry.Count > 0)
                    {
                        grdData.Focus();

                        if (grdData.View != null && grdData.View.Columns.Count > 0)
                        {
                            // ensure first column is visible (sometimes you need to scroll first otherwise)
                            grdData.View.MakeColumnVisible(grdData.View.Columns[0]);
                        }
                    }
                }
            }
        }

        private void chkReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            grdData.GridStyle = (chkReadOnly.Checked ? GridStyleType.ReadOnly : GridStyleType.Editable);

            qry.CanInsert = !chkReadOnly.Checked;
            qry.CanUpdate = !chkReadOnly.Checked;
            qry.CanDelete = !chkReadOnly.Checked;
        }

        private void edtTableName_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            // do nothing if not finished loading
            if (_isLoadingControl)
            {
                return;
            }

            _updating = true;

            SetTableName(e.Value.ToString());

            _updating = false;
        }

        private void edtTableName_Leave(object sender, EventArgs e)
        {
            // check if already loading data
            if (_updating)
            {
                return;
            }

            SetTableName(edtTableName.EditValue.ToString());
        }

        private void grvData_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                if (qry.DataTable.Columns[e.Column.FieldName].DataType == typeof(string))
                {
                    e.RepositoryItem = repositoryItemButtonEdit1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in grvData_CustomRowCellEdit: {0}", ex.Message);
            }
        }

        private void qry_AfterDelete(object sender, EventArgs e)
        {
            // Änderungen via Dateneditor müssen geloggt werden, nicht löschbar
            XLog.Create(GetType().FullName, 5, LogLevel.INFO, "Tabellen-Row wurde gelöscht: " + _selectedRowAsString, edtGrund.Text + ": " + edtSQLStatement.Text, "", 0, true, Session.User.UserID);
        }

        private void qry_AfterInsert(object sender, EventArgs e)
        {
            // Änderungen via Dateneditor müssen geloggt werden
            XLog.Create(GetType().FullName, 4, LogLevel.INFO, "Tabellen-Row wurde eingefügt", edtGrund.Text + ": " + edtSQLStatement.Text, "", 0, false, Session.User.UserID);
        }

        private void qry_AfterPost(object sender, EventArgs e)
        {
            // Änderungen via Dateneditor müssen geloggt werden, nicht löschbar
            XLog.Create(GetType().FullName, 3, LogLevel.INFO, "Tabellen-Row wurde geändert von : " + _selectedRowAsString, edtGrund.Text + ": " + edtSQLStatement.Text, "", 0, true, Session.User.UserID);
            XLog.Create(GetType().FullName, 3, LogLevel.INFO, "Tabellen-Row wurde geändert nach: " + RowToString(qry.Row), edtGrund.Text + ": " + edtSQLStatement.Text, "", 0, true, Session.User.UserID);
        }

        private void qry_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edtGrund.Text))
            {
                KissMsg.ShowInfo(Name, "KeinGrund", "Kein Grund angegeben!\r\nBitte geben Sie einen Grund für die DB-Änderung an,\r\nmöglichst mit einem Verweis auf ein Incident-Ticket\r\nim Format #5646 oder INC000000329288.");

                throw new KissCancelException("Kein Grund angegeben!\r\nBitte geben Sie einen Grund für die DB-Änderung an,\r\nmöglichst mit einem Verweis auf ein Incident-Ticket\r\nim Format #5646 oder INC000000329288.", this);
            }
        }

        private void qry_BeforeInsert(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edtGrund.Text))
            {
                KissMsg.ShowInfo(Name, "KeinGrund", "Kein Grund angegeben!\r\nBitte geben Sie einen Grund für die DB-Änderung an,\r\nmöglichst mit einem Verweis auf ein Incident-Ticket\r\nim Format #5646 oder INC000000329288.");

                throw new KissCancelException("Kein Grund angegeben!\r\nBitte geben Sie einen Grund für die DB-Änderung an,\r\nmöglichst mit einem Verweis auf ein Incident-Ticket\r\nim Format #5646 oder INC000000329288.", this);
            }
        }

        private void qry_BeforePost(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edtGrund.Text))
            {
                KissMsg.ShowInfo(Name, "KeinGrund", "Kein Grund angegeben!\r\nBitte geben Sie einen Grund für die DB-Änderung an,\r\nmöglichst mit einem Verweis auf ein Incident-Ticket\r\nim Format #5646 oder INC000000329288.");

                throw new KissCancelException("Kein Grund angegeben!\r\nBitte geben Sie einen Grund für die DB-Änderung an,\r\nmöglichst mit einem Verweis auf ein Incident-Ticket\r\nim Format #5646 oder INC000000329288.", this);
            }
        }

        private void qry_PositionChanged(object sender, EventArgs e)
        {
            _selectedRowAsString = RowToString(qry.Row);
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Font font = new Font(GuiConfig.MemoNonPropFontName, GuiConfig.MemoNonPropFontSize,
                                        GuiConfig.MemoNonPropFontStyle, GuiConfig.MemoNonPropFontGraphicUnit);

            DlgMemoEdit dlg = new DlgMemoEdit(false, font);
            dlg.MemoEditor.EditValue = grdData.View.GetRowCellValue(grdData.View.FocusedRowHandle,
                                                                                             grdData.View.FocusedColumn);

            dlg.RestoreLayout();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                grdData.View.SetRowCellValue(grdData.View.FocusedRowHandle,
                                                             grdData.View.FocusedColumn,
                                                             dlg.MemoEditor.EditValue);
            }
        }

        private void tabDatenEditor_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            switch (tabDatenEditor.SelectedTabIndex)
            {
                case 2: // Export
                    chkIncludeIdentity.Enabled = (qry.IdentityColumnName != null);
                    chkIncludeIdentity.Checked = chkIncludeIdentity.Enabled;
                    btnExport.Enabled = (qry.Count > 0 && grdData.DataSource != null);
                    break;
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// Check if user is allowed to access form with all functionality
        /// </summary>
        /// <returns><c>True</c> if user is allowed, <c>False</c> if user has no access</returns>
        public static bool HasUserAccessToForm()
        {
            bool rechtDatenEditor = DBUtil.UserHasRight("FrmDataEditor_AllowAccess");

            return Session.User.IsUserBIAGAdmin || rechtDatenEditor;
        }

        private void MigratePersonRTF(string sql, Label lbl, string labelText, string introText)
        {
            lbl.Visible = true;
            lbl.Text = labelText + ": laden";

            var rtfBox = new RichTextBox();
            var qry = DBUtil.OpenSQL(sql);
            int count = 0;
            int countUpdated = 0;

            foreach (DataRow row in qry.DataTable.Rows)
            {
                count++;
                lbl.Text = labelText + ": " + count.ToString() + "/" + qry.Count.ToString();

                ApplicationFacade.DoEvents();

                string bemerkung = "";

                if (!DBUtil.IsEmpty(row["Bemerkung"]))
                {
                    bemerkung = row["Bemerkung"].ToString();
                }

                if (bemerkung.IndexOf(introText) != -1)
                {
                    continue;
                }

                try
                {
                    rtfBox.Rtf = bemerkung;
                }
                catch
                {
                    rtfBox.Text = bemerkung;
                }

                var remark = row["Remark"].ToString();

                if (remark.IndexOf("rtf") == -1)
                {
                    rtfBox.SelectedText = introText + ":\r\n" + remark + "\r\n----\r\n\r\n";
                }
                else
                {
                    rtfBox.SelectedText = introText + ":\r\n";

                    // must be passed in a DataObject to get correct RTF format
                    var myDataObject = new DataObject(DataFormats.Rtf, remark);
                    Clipboard.SetDataObject(myDataObject);
                    rtfBox.Paste();
                    rtfBox.SelectedText = "\r\n----\r\n\r\n";
                }

                DBUtil.ExecSQL(@"
                    UPDATE dbo.BaPerson
                    SET Bemerkung = {0}, Modifier = {1}, Modified = GetDate()
                    WHERE BaPersonID = {2}", rtfBox.Rtf, DBUtil.GetDBRowCreatorModifier(), row["BaPersonID"]);

                countUpdated++;
            }

            lbl.Text = labelText + ": Total: " + qry.Count.ToString() + ", davon migriert: " + countUpdated.ToString();
        }

        private string RowToString(DataRow row)
        {
            string text = "";

            try
            {
                foreach (var cell in row.ItemArray)
                {
                    text = text + "|" + cell;
                }
            }
            catch (Exception ex)
            {
                // Ignore Problems here
                Console.WriteLine("Error in RowToString(...): {0}", ex.Message);
            }

            return text;
        }

        private void SetTableName(string tableName)
        {
            if (tableName == _tableName)
            {
                return;
            }

            _tableName = tableName;

            if (edtTableName.Properties.Items.IndexOf(_tableName) != -1)
            {
                // set top x value
                int showAmount = 100;

                // check if special top x value required
                if (_tableName == "XDocument")
                {
                    showAmount = 1;
                }

                // apply sql-text (template to execute for SQL-TextControl)
                edtSQLStatement.Text = string.Format(@"--SQLCHECK_IGNORE--
SELECT TOP {0} *{2}FROM dbo.{1} WITH (READUNCOMMITTED){2}WHERE 1 = 1;", showAmount, _tableName, Environment.NewLine);

                // apply table to query
                qry.TableName = _tableName;

                // do not load data when controls is loading
                if (_isLoadingControl)
                {
                    // finally, reset flag (prevent loading data only first time of call)
                    _isLoadingControl = false;

                    // do not load data the first time
                    return;
                }

                // execute sql
                ApplicationFacade.DoEvents();
                btnRunQuery.PerformClick();
            }
        }

        #endregion

        #endregion
    }
}