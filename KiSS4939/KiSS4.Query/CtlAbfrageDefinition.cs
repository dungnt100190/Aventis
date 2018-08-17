using System;
using System.Data;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.Query
{
	/// <summary>
	/// Summary description for CtlAbfrageDefinition.
	/// </summary>
	public class CtlAbfrageDefinition : KiSS4.Gui.KissUserControl
	{
		private const string QUERY_FILE_EXTENSION = ".kaf";

		private System.Windows.Forms.OpenFileDialog dlgFileOpen;
		private KiSS4.Gui.KissMemoEdit memoEditParameterXML;
		private KiSS4.Gui.KissMemoEdit memoEditSQL;
		private KiSS4.Gui.KissCheckEdit editReadOnly;
		private KiSS4.Gui.KissButton btnImport;
		private KiSS4.Gui.KissTree kissTree1;
		private DevExpress.XtraTreeList.Columns.TreeListColumn UserText;
		private KiSS4.Gui.KissButton btnExport;
		private System.Windows.Forms.SaveFileDialog dlgFileSave;
		private KiSS4.Gui.KissTextEdit kissTextEdit1;
		private KiSS4.Gui.KissLabel kissLabel1;
		private KiSS4.Gui.KissLabel kissLabel2;
		private KiSS4.Gui.KissTextEdit kissTextEdit2;
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;

		private KiSS4.Gui.KissTabControlEx tabXQuery;
		private SharpLibrary.WinControls.TabPageEx tabPageVerwaltung;
		private SharpLibrary.WinControls.TabPageEx tabPageZugriffsrechte;
		private KiSS4.Gui.KissGrid gridVerfuegbar;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
		private KiSS4.Gui.KissGrid gridZugeteilt;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn colUser;
		private KiSS4.DB.SqlQuery qryVerfuegbar;
		private DevExpress.XtraGrid.Columns.GridColumn colGruppen;
		private KiSS4.DB.SqlQuery qryZugeteilt;
		private KiSS4.DB.SqlQuery qryXQuery;
		private KiSS4.Gui.KissButton btnAddAll;
		private KiSS4.Gui.KissButton btnRemoveAll;
		private KiSS4.Gui.KissButton btnAdd;
		private KiSS4.Gui.KissButton btnRemove;
		private KiSS4.Gui.KissButton btnExportAll;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private KiSS4.Gui.KissSplitter splitter;

		private bool posting = false;

		public CtlAbfrageDefinition()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.qryXQuery = new KiSS4.DB.SqlQuery(this.components);
			this.dlgFileOpen = new System.Windows.Forms.OpenFileDialog();
			this.memoEditParameterXML = new KiSS4.Gui.KissMemoEdit();
			this.memoEditSQL = new KiSS4.Gui.KissMemoEdit();
			this.editReadOnly = new KiSS4.Gui.KissCheckEdit();
			this.btnImport = new KiSS4.Gui.KissButton();
			this.kissTree1 = new KiSS4.Gui.KissTree();
			this.UserText = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.btnExport = new KiSS4.Gui.KissButton();
			this.dlgFileSave = new System.Windows.Forms.SaveFileDialog();
			this.kissTextEdit1 = new KiSS4.Gui.KissTextEdit();
			this.kissLabel1 = new KiSS4.Gui.KissLabel();
			this.kissLabel2 = new KiSS4.Gui.KissLabel();
			this.kissTextEdit2 = new KiSS4.Gui.KissTextEdit();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitter = new KiSS4.Gui.KissSplitter();
			this.panel3 = new System.Windows.Forms.Panel();
			this.tabXQuery = new KiSS4.Gui.KissTabControlEx();
			this.tabPageVerwaltung = new SharpLibrary.WinControls.TabPageEx();
			this.btnExportAll = new KiSS4.Gui.KissButton();
			this.tabPageZugriffsrechte = new SharpLibrary.WinControls.TabPageEx();
			this.btnAddAll = new KiSS4.Gui.KissButton();
			this.btnRemoveAll = new KiSS4.Gui.KissButton();
			this.btnAdd = new KiSS4.Gui.KissButton();
			this.btnRemove = new KiSS4.Gui.KissButton();
			this.gridVerfuegbar = new KiSS4.Gui.KissGrid();
			this.qryVerfuegbar = new KiSS4.DB.SqlQuery(this.components);
			this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colGruppen = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridZugeteilt = new KiSS4.Gui.KissGrid();
			this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
			this.panel2 = new System.Windows.Forms.Panel();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.qryXQuery)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEditParameterXML.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEditSQL.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.editReadOnly.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kissTree1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tabXQuery.SuspendLayout();
			this.tabPageVerwaltung.SuspendLayout();
			this.tabPageZugriffsrechte.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridVerfuegbar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridZugeteilt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// qryXQuery
			// 
			this.qryXQuery.DeleteQuestion = "Soll die Abfrage \'[Usertext]\' gelöscht werden?";
			this.qryXQuery.HostControl = this;
			this.qryXQuery.TableName = "XQuery";
			this.qryXQuery.AfterInsert += new System.EventHandler(this.qryReports_AfterInsert);
			// 
			// dlgFileOpen
			// 
			this.dlgFileOpen.Multiselect = true;
			// 
			// memoEditParameterXML
			// 
			this.memoEditParameterXML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.memoEditParameterXML.DataMember = "ParameterXML";
			this.memoEditParameterXML.DataSource = this.qryXQuery;
			this.memoEditParameterXML.Location = new System.Drawing.Point(8, 333);
			this.memoEditParameterXML.Name = "memoEditParameterXML";
			this.memoEditParameterXML.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
			this.memoEditParameterXML.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.memoEditParameterXML.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.memoEditParameterXML.Properties.Appearance.Options.UseBackColor = true;
			this.memoEditParameterXML.Properties.Appearance.Options.UseBorderColor = true;
			this.memoEditParameterXML.Properties.Appearance.Options.UseFont = true;
			this.memoEditParameterXML.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.memoEditParameterXML.ProportionalFont = false;
			this.memoEditParameterXML.Size = new System.Drawing.Size(709, 200);
			this.memoEditParameterXML.TabIndex = 5;
			// 
			// memoEditSQL
			// 
			this.memoEditSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.memoEditSQL.DataMember = "SQLquery";
			this.memoEditSQL.DataSource = this.qryXQuery;
			this.memoEditSQL.Location = new System.Drawing.Point(8, 88);
			this.memoEditSQL.Name = "memoEditSQL";
			this.memoEditSQL.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
			this.memoEditSQL.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.memoEditSQL.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.memoEditSQL.Properties.Appearance.Options.UseBackColor = true;
			this.memoEditSQL.Properties.Appearance.Options.UseBorderColor = true;
			this.memoEditSQL.Properties.Appearance.Options.UseFont = true;
			this.memoEditSQL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.memoEditSQL.ProportionalFont = false;
			this.memoEditSQL.Size = new System.Drawing.Size(709, 229);
			this.memoEditSQL.TabIndex = 4;
			// 
			// editReadOnly
			// 
			this.editReadOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.editReadOnly.EditValue = true;
			this.editReadOnly.Location = new System.Drawing.Point(12, 549);
			this.editReadOnly.Name = "editReadOnly";
			this.editReadOnly.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.editReadOnly.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.editReadOnly.Properties.Appearance.Options.UseBackColor = true;
			this.editReadOnly.Properties.Appearance.Options.UseFont = true;
			this.editReadOnly.Properties.Caption = "Schreibschutz";
			this.editReadOnly.Size = new System.Drawing.Size(125, 19);
			this.editReadOnly.TabIndex = 6;
			this.editReadOnly.CheckedChanged += new System.EventHandler(this.editReadOnly_CheckedChanged);
			// 
			// btnImport
			// 
			this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnImport.Enabled = false;
			this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnImport.Location = new System.Drawing.Point(405, 549);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(95, 24);
			this.btnImport.TabIndex = 7;
			this.btnImport.Text = "Import";
			this.btnImport.UseVisualStyleBackColor = false;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// kissTree1
			// 
			this.kissTree1.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
			this.kissTree1.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.kissTree1.Appearance.Empty.Options.UseBackColor = true;
			this.kissTree1.Appearance.Empty.Options.UseForeColor = true;
			this.kissTree1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
			this.kissTree1.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.kissTree1.Appearance.EvenRow.Options.UseBackColor = true;
			this.kissTree1.Appearance.EvenRow.Options.UseForeColor = true;
			this.kissTree1.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
			this.kissTree1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
			this.kissTree1.Appearance.FocusedCell.Options.UseBackColor = true;
			this.kissTree1.Appearance.FocusedCell.Options.UseForeColor = true;
			this.kissTree1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
			this.kissTree1.Appearance.FocusedRow.Options.UseForeColor = true;
			this.kissTree1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
			this.kissTree1.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.kissTree1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.kissTree1.Appearance.FooterPanel.Options.UseBackColor = true;
			this.kissTree1.Appearance.FooterPanel.Options.UseFont = true;
			this.kissTree1.Appearance.FooterPanel.Options.UseForeColor = true;
			this.kissTree1.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
			this.kissTree1.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
			this.kissTree1.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.kissTree1.Appearance.GroupButton.Options.UseBackColor = true;
			this.kissTree1.Appearance.GroupButton.Options.UseFont = true;
			this.kissTree1.Appearance.GroupButton.Options.UseForeColor = true;
			this.kissTree1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
			this.kissTree1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.kissTree1.Appearance.GroupFooter.Options.UseBackColor = true;
			this.kissTree1.Appearance.GroupFooter.Options.UseForeColor = true;
			this.kissTree1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
			this.kissTree1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.kissTree1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.kissTree1.Appearance.HeaderPanel.Options.UseBackColor = true;
			this.kissTree1.Appearance.HeaderPanel.Options.UseFont = true;
			this.kissTree1.Appearance.HeaderPanel.Options.UseForeColor = true;
			this.kissTree1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
			this.kissTree1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.kissTree1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
			this.kissTree1.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.kissTree1.Appearance.HideSelectionRow.Options.UseFont = true;
			this.kissTree1.Appearance.HideSelectionRow.Options.UseForeColor = true;
			this.kissTree1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
			this.kissTree1.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
			this.kissTree1.Appearance.HorzLine.Options.UseBackColor = true;
			this.kissTree1.Appearance.HorzLine.Options.UseForeColor = true;
			this.kissTree1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
			this.kissTree1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.kissTree1.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.kissTree1.Appearance.OddRow.Options.UseBackColor = true;
			this.kissTree1.Appearance.OddRow.Options.UseFont = true;
			this.kissTree1.Appearance.OddRow.Options.UseForeColor = true;
			this.kissTree1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.kissTree1.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.kissTree1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.kissTree1.Appearance.Preview.Options.UseBackColor = true;
			this.kissTree1.Appearance.Preview.Options.UseFont = true;
			this.kissTree1.Appearance.Preview.Options.UseForeColor = true;
			this.kissTree1.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
			this.kissTree1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.kissTree1.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.kissTree1.Appearance.Row.Options.UseBackColor = true;
			this.kissTree1.Appearance.Row.Options.UseFont = true;
			this.kissTree1.Appearance.Row.Options.UseForeColor = true;
			this.kissTree1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
			this.kissTree1.Appearance.SelectedRow.Options.UseForeColor = true;
			this.kissTree1.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
			this.kissTree1.Appearance.TreeLine.Options.UseBackColor = true;
			this.kissTree1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
			this.kissTree1.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
			this.kissTree1.Appearance.VertLine.Options.UseBackColor = true;
			this.kissTree1.Appearance.VertLine.Options.UseForeColor = true;
			this.kissTree1.Appearance.VertLine.Options.UseTextOptions = true;
			this.kissTree1.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.kissTree1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.UserText});
			this.kissTree1.DataSource = this.qryXQuery;
			this.kissTree1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kissTree1.ImageIndexFieldName = "IconID";
			this.kissTree1.KeyFieldName = "QueryName";
			this.kissTree1.Location = new System.Drawing.Point(0, 0);
			this.kissTree1.Name = "kissTree1";
			this.kissTree1.OptionsBehavior.AutoSelectAllInEditor = false;
			this.kissTree1.OptionsBehavior.CloseEditorOnLostFocus = false;
			this.kissTree1.OptionsBehavior.Editable = false;
			this.kissTree1.OptionsBehavior.KeepSelectedOnClick = false;
			this.kissTree1.OptionsBehavior.MoveOnEdit = false;
			this.kissTree1.OptionsBehavior.ShowToolTips = false;
			this.kissTree1.OptionsBehavior.SmartMouseHover = false;
			this.kissTree1.OptionsMenu.EnableColumnMenu = false;
			this.kissTree1.OptionsMenu.EnableFooterMenu = false;
			this.kissTree1.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.kissTree1.OptionsView.AutoWidth = false;
			this.kissTree1.OptionsView.EnableAppearanceEvenRow = true;
			this.kissTree1.OptionsView.EnableAppearanceOddRow = true;
			this.kissTree1.OptionsView.ShowIndicator = false;
			this.kissTree1.OptionsView.ShowVertLines = false;
			this.kissTree1.ParentFieldName = "";
			this.kissTree1.Size = new System.Drawing.Size(288, 608);
			this.kissTree1.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
								| DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
			this.kissTree1.TabIndex = 0;
			this.kissTree1.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.kissTree1_AfterFocusNode);
			this.kissTree1.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.kissTree1_BeforeFocusNode);
			// 
			// UserText
			// 
			this.UserText.Caption = "Beschreibung";
			this.UserText.FieldName = "UserText";
			this.UserText.Name = "UserText";
			this.UserText.VisibleIndex = 0;
			this.UserText.Width = 257;
			// 
			// btnExport
			// 
			this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExport.Location = new System.Drawing.Point(509, 549);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(95, 24);
			this.btnExport.TabIndex = 9;
			this.btnExport.Text = "Export";
			this.btnExport.UseVisualStyleBackColor = false;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// dlgFileSave
			// 
			this.dlgFileSave.FileName = "KiSS4_Report";
			// 
			// kissTextEdit1
			// 
			this.kissTextEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.kissTextEdit1.DataMember = "QueryName";
			this.kissTextEdit1.DataSource = this.qryXQuery;
			this.kissTextEdit1.Location = new System.Drawing.Point(108, 8);
			this.kissTextEdit1.Name = "kissTextEdit1";
			this.kissTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
			this.kissTextEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.kissTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.kissTextEdit1.Properties.Appearance.Options.UseBackColor = true;
			this.kissTextEdit1.Properties.Appearance.Options.UseBorderColor = true;
			this.kissTextEdit1.Properties.Appearance.Options.UseFont = true;
			this.kissTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.kissTextEdit1.Size = new System.Drawing.Size(609, 24);
			this.kissTextEdit1.TabIndex = 0;
			// 
			// kissLabel1
			// 
			this.kissLabel1.Location = new System.Drawing.Point(8, 8);
			this.kissLabel1.Name = "kissLabel1";
			this.kissLabel1.Size = new System.Drawing.Size(32, 24);
			this.kissLabel1.TabIndex = 17;
			this.kissLabel1.Text = "Name";
			// 
			// kissLabel2
			// 
			this.kissLabel2.Location = new System.Drawing.Point(8, 40);
			this.kissLabel2.Name = "kissLabel2";
			this.kissLabel2.Size = new System.Drawing.Size(72, 24);
			this.kissLabel2.TabIndex = 19;
			this.kissLabel2.Text = "Beschreibung";
			// 
			// kissTextEdit2
			// 
			this.kissTextEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.kissTextEdit2.DataMember = "UserText";
			this.kissTextEdit2.DataSource = this.qryXQuery;
			this.kissTextEdit2.Location = new System.Drawing.Point(108, 40);
			this.kissTextEdit2.Name = "kissTextEdit2";
			this.kissTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
			this.kissTextEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.kissTextEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.kissTextEdit2.Properties.Appearance.Options.UseBackColor = true;
			this.kissTextEdit2.Properties.Appearance.Options.UseBorderColor = true;
			this.kissTextEdit2.Properties.Appearance.Options.UseFont = true;
			this.kissTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.kissTextEdit2.Size = new System.Drawing.Size(609, 24);
			this.kissTextEdit2.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.splitter);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1040, 608);
			this.panel1.TabIndex = 22;
			// 
			// splitter
			// 
			this.splitter.Location = new System.Drawing.Point(288, 0);
			this.splitter.Name = "splitter";
			this.splitter.Size = new System.Drawing.Size(3, 608);
			this.splitter.TabIndex = 2;
			this.splitter.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.panel3.Controls.Add(this.tabXQuery);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(288, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(752, 608);
			this.panel3.TabIndex = 1;
			// 
			// tabXQuery
			// 
			this.tabXQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabXQuery.Controls.Add(this.tabPageVerwaltung);
			this.tabXQuery.Controls.Add(this.tabPageZugriffsrechte);
			this.tabXQuery.Location = new System.Drawing.Point(3, -5);
			this.tabXQuery.Name = "tabXQuery";
			this.tabXQuery.ShowFixedWidthTooltip = true;
			this.tabXQuery.Size = new System.Drawing.Size(733, 613);
			this.tabXQuery.TabIndex = 22;
			this.tabXQuery.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabPageVerwaltung,
            this.tabPageZugriffsrechte});
			this.tabXQuery.TabsLineColor = System.Drawing.Color.Black;
			this.tabXQuery.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
			this.tabXQuery.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
			this.tabXQuery.Text = "kissTabControlEx1";
			// 
			// tabPageVerwaltung
			// 
			this.tabPageVerwaltung.Controls.Add(this.btnExportAll);
			this.tabPageVerwaltung.Controls.Add(this.kissTextEdit1);
			this.tabPageVerwaltung.Controls.Add(this.kissLabel1);
			this.tabPageVerwaltung.Controls.Add(this.kissLabel2);
			this.tabPageVerwaltung.Controls.Add(this.kissTextEdit2);
			this.tabPageVerwaltung.Controls.Add(this.memoEditSQL);
			this.tabPageVerwaltung.Controls.Add(this.memoEditParameterXML);
			this.tabPageVerwaltung.Controls.Add(this.btnExport);
			this.tabPageVerwaltung.Controls.Add(this.editReadOnly);
			this.tabPageVerwaltung.Controls.Add(this.btnImport);
			this.tabPageVerwaltung.Location = new System.Drawing.Point(6, 32);
			this.tabPageVerwaltung.Name = "tabPageVerwaltung";
			this.tabPageVerwaltung.Size = new System.Drawing.Size(721, 575);
			this.tabPageVerwaltung.TabIndex = 0;
			this.tabPageVerwaltung.Title = "Verwaltung";
			// 
			// btnExportAll
			// 
			this.btnExportAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExportAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExportAll.Location = new System.Drawing.Point(613, 549);
			this.btnExportAll.Name = "btnExportAll";
			this.btnExportAll.Size = new System.Drawing.Size(104, 24);
			this.btnExportAll.TabIndex = 20;
			this.btnExportAll.Text = "alle exportieren";
			this.btnExportAll.UseVisualStyleBackColor = false;
			this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
			// 
			// tabPageZugriffsrechte
			// 
			this.tabPageZugriffsrechte.Controls.Add(this.btnAddAll);
			this.tabPageZugriffsrechte.Controls.Add(this.btnRemoveAll);
			this.tabPageZugriffsrechte.Controls.Add(this.btnAdd);
			this.tabPageZugriffsrechte.Controls.Add(this.btnRemove);
			this.tabPageZugriffsrechte.Controls.Add(this.gridVerfuegbar);
			this.tabPageZugriffsrechte.Controls.Add(this.gridZugeteilt);
			this.tabPageZugriffsrechte.Location = new System.Drawing.Point(6, 32);
			this.tabPageZugriffsrechte.Name = "tabPageZugriffsrechte";
			this.tabPageZugriffsrechte.Size = new System.Drawing.Size(721, 575);
			this.tabPageZugriffsrechte.TabIndex = 1;
			this.tabPageZugriffsrechte.Title = "Zugriffsrechte";
			// 
			// btnAddAll
			// 
			this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddAll.IconID = 14;
			this.btnAddAll.Location = new System.Drawing.Point(288, 293);
			this.btnAddAll.Name = "btnAddAll";
			this.btnAddAll.Size = new System.Drawing.Size(34, 24);
			this.btnAddAll.TabIndex = 8;
			this.btnAddAll.UseVisualStyleBackColor = false;
			this.btnAddAll.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnRemoveAll
			// 
			this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemoveAll.IconID = 12;
			this.btnRemoveAll.Location = new System.Drawing.Point(288, 325);
			this.btnRemoveAll.Name = "btnRemoveAll";
			this.btnRemoveAll.Size = new System.Drawing.Size(34, 24);
			this.btnRemoveAll.TabIndex = 9;
			this.btnRemoveAll.UseVisualStyleBackColor = false;
			this.btnRemoveAll.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.IconID = 13;
			this.btnAdd.Location = new System.Drawing.Point(288, 221);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(34, 24);
			this.btnAdd.TabIndex = 6;
			this.btnAdd.UseVisualStyleBackColor = false;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemove.IconID = 11;
			this.btnRemove.Location = new System.Drawing.Point(288, 257);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(34, 24);
			this.btnRemove.TabIndex = 7;
			this.btnRemove.UseVisualStyleBackColor = false;
			this.btnRemove.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// gridVerfuegbar
			// 
			this.gridVerfuegbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.gridVerfuegbar.DataSource = this.qryVerfuegbar;
			this.gridVerfuegbar.EmbeddedNavigator.Name = "";
			this.gridVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
			this.gridVerfuegbar.Location = new System.Drawing.Point(8, 16);
			this.gridVerfuegbar.MainView = this.gridView3;
			this.gridVerfuegbar.Name = "gridVerfuegbar";
			this.gridVerfuegbar.Size = new System.Drawing.Size(260, 549);
			this.gridVerfuegbar.TabIndex = 0;
			this.gridVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
			// 
			// qryVerfuegbar
			// 
			this.qryVerfuegbar.HostControl = this;
			// 
			// gridView3
			// 
			this.gridView3.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.gridView3.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gridView3.Appearance.Empty.Options.UseBackColor = true;
			this.gridView3.Appearance.Empty.Options.UseFont = true;
			this.gridView3.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
			this.gridView3.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gridView3.Appearance.EvenRow.Options.UseBackColor = true;
			this.gridView3.Appearance.EvenRow.Options.UseFont = true;
			this.gridView3.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
			this.gridView3.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gridView3.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
			this.gridView3.Appearance.FocusedCell.Options.UseBackColor = true;
			this.gridView3.Appearance.FocusedCell.Options.UseFont = true;
			this.gridView3.Appearance.FocusedCell.Options.UseForeColor = true;
			this.gridView3.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
			this.gridView3.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
			this.gridView3.Appearance.FocusedRow.Options.UseBackColor = true;
			this.gridView3.Appearance.FocusedRow.Options.UseFont = true;
			this.gridView3.Appearance.FocusedRow.Options.UseForeColor = true;
			this.gridView3.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
			this.gridView3.Appearance.GroupPanel.Options.UseBackColor = true;
			this.gridView3.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
			this.gridView3.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.gridView3.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.gridView3.Appearance.GroupRow.Options.UseBackColor = true;
			this.gridView3.Appearance.GroupRow.Options.UseFont = true;
			this.gridView3.Appearance.GroupRow.Options.UseForeColor = true;
			this.gridView3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
			this.gridView3.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
			this.gridView3.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.gridView3.Appearance.HeaderPanel.Options.UseBackColor = true;
			this.gridView3.Appearance.HeaderPanel.Options.UseBorderColor = true;
			this.gridView3.Appearance.HeaderPanel.Options.UseFont = true;
			this.gridView3.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
			this.gridView3.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gridView3.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.gridView3.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.gridView3.Appearance.HideSelectionRow.Options.UseFont = true;
			this.gridView3.Appearance.HideSelectionRow.Options.UseForeColor = true;
			this.gridView3.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
			this.gridView3.Appearance.HorzLine.Options.UseBackColor = true;
			this.gridView3.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
			this.gridView3.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gridView3.Appearance.OddRow.Options.UseBackColor = true;
			this.gridView3.Appearance.OddRow.Options.UseFont = true;
			this.gridView3.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
			this.gridView3.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gridView3.Appearance.Row.Options.UseBackColor = true;
			this.gridView3.Appearance.Row.Options.UseFont = true;
			this.gridView3.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
			this.gridView3.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gridView3.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
			this.gridView3.Appearance.SelectedRow.Options.UseBackColor = true;
			this.gridView3.Appearance.SelectedRow.Options.UseFont = true;
			this.gridView3.Appearance.SelectedRow.Options.UseForeColor = true;
			this.gridView3.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
			this.gridView3.Appearance.VertLine.Options.UseBackColor = true;
			this.gridView3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGruppen});
			this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
			this.gridView3.GridControl = this.gridVerfuegbar;
			this.gridView3.Name = "gridView3";
			this.gridView3.OptionsBehavior.Editable = false;
			this.gridView3.OptionsCustomization.AllowFilter = false;
			this.gridView3.OptionsFilter.UseNewCustomFilterDialog = true;
			this.gridView3.OptionsNavigation.AutoFocusNewRow = true;
			this.gridView3.OptionsNavigation.UseTabKey = false;
			this.gridView3.OptionsView.ColumnAutoWidth = false;
			this.gridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.gridView3.OptionsView.ShowGroupPanel = false;
			this.gridView3.OptionsView.ShowIndicator = false;
			// 
			// colGruppen
			// 
			this.colGruppen.Caption = "Verfügbare Gruppen";
			this.colGruppen.FieldName = "UserGroupName";
			this.colGruppen.Name = "colGruppen";
			this.colGruppen.Visible = true;
			this.colGruppen.VisibleIndex = 0;
			this.colGruppen.Width = 240;
			// 
			// gridZugeteilt
			// 
			this.gridZugeteilt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.gridZugeteilt.DataSource = this.qryZugeteilt;
			this.gridZugeteilt.EmbeddedNavigator.Name = "";
			this.gridZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
			this.gridZugeteilt.Location = new System.Drawing.Point(344, 16);
			this.gridZugeteilt.MainView = this.gridView2;
			this.gridZugeteilt.Name = "gridZugeteilt";
			this.gridZugeteilt.Size = new System.Drawing.Size(260, 549);
			this.gridZugeteilt.TabIndex = 5;
			this.gridZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
			// 
			// qryZugeteilt
			// 
			this.qryZugeteilt.CanDelete = true;
			this.qryZugeteilt.CanInsert = true;
			this.qryZugeteilt.CanUpdate = true;
			this.qryZugeteilt.HostControl = this;
			this.qryZugeteilt.TableName = "XUserGroup_Right";
			// 
			// gridView2
			// 
			this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gridView2.Appearance.Empty.Options.UseBackColor = true;
			this.gridView2.Appearance.Empty.Options.UseFont = true;
			this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
			this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
			this.gridView2.Appearance.EvenRow.Options.UseFont = true;
			this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
			this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
			this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
			this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
			this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
			this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
			this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
			this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
			this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
			this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
			this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
			this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
			this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
			this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
			this.gridView2.Appearance.GroupRow.Options.UseFont = true;
			this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
			this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
			this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
			this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
			this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
			this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
			this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
			this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
			this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
			this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
			this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
			this.gridView2.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
			this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gridView2.Appearance.OddRow.Options.UseBackColor = true;
			this.gridView2.Appearance.OddRow.Options.UseFont = true;
			this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
			this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gridView2.Appearance.Row.Options.UseBackColor = true;
			this.gridView2.Appearance.Row.Options.UseFont = true;
			this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
			this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
			this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
			this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
			this.gridView2.Appearance.SelectedRow.Options.UseForeColor = true;
			this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
			this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
			this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUser});
			this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
			this.gridView2.GridControl = this.gridZugeteilt;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsBehavior.Editable = false;
			this.gridView2.OptionsCustomization.AllowFilter = false;
			this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
			this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
			this.gridView2.OptionsNavigation.UseTabKey = false;
			this.gridView2.OptionsView.ColumnAutoWidth = false;
			this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			this.gridView2.OptionsView.ShowIndicator = false;
			// 
			// colUser
			// 
			this.colUser.Caption = "Zugeteilte Gruppen";
			this.colUser.FieldName = "UserGroupName";
			this.colUser.Name = "colUser";
			this.colUser.Visible = true;
			this.colUser.VisibleIndex = 0;
			this.colUser.Width = 238;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.panel2.Controls.Add(this.kissTree1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(288, 608);
			this.panel2.TabIndex = 0;
			// 
			// CtlAbfrageDefinition
			// 
			this.ActiveSQLQuery = this.qryXQuery;
			this.Controls.Add(this.panel1);
			this.Name = "CtlAbfrageDefinition";
			this.Size = new System.Drawing.Size(1032, 624);
			this.Load += new System.EventHandler(this.CtlUser_Load);
			((System.ComponentModel.ISupportInitialize)(this.qryXQuery)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEditParameterXML.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEditSQL.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.editReadOnly.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kissTree1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.tabXQuery.ResumeLayout(false);
			this.tabPageVerwaltung.ResumeLayout(false);
			this.tabPageZugriffsrechte.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridVerfuegbar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridZugeteilt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void CtlUser_Load(object sender, System.EventArgs e)
		{
			qryXQuery.Fill(@"SELECT QueryName, UserText, QueryCode, LayoutXML, 
                                    ParameterXML, SQLquery, ContextForms, 
                                    ParentReportName, ReportSortKey, XQueryTS 
                             FROM dbo.XQuery WITH (READUNCOMMITTED) 
                             WHERE QueryCode=2 
                             ORDER BY QueryName");
			this.tabXQuery.SelectedTabIndex = 0;
		}

		private void qryCurrentItem_AfterDelete(object sender, System.EventArgs e)
		{
			qryXQuery.Refresh();
		}

		private void editReadOnly_CheckedChanged(object sender, System.EventArgs e)
		{
			btnImport.Enabled = !editReadOnly.Checked;

			qryXQuery.CanDelete = !editReadOnly.Checked;
			qryXQuery.CanInsert = !editReadOnly.Checked;
			qryXQuery.CanUpdate = !editReadOnly.Checked;
			qryXQuery.Refresh();
		}

		private void btnImport_Click(object sender, System.EventArgs e)
		{
			dlgFileOpen.Filter = "KiSS Abfragen (*" + QUERY_FILE_EXTENSION + ")|*" + QUERY_FILE_EXTENSION
				+ "|Alle Dateien (*.*)|*.*";
			if (DialogResult.Cancel == dlgFileOpen.ShowDialog(this))
				return;

			string lastMainKey = "";
			foreach (string fileName in dlgFileOpen.FileNames)
			{
				DataSet ds;
				try
				{
					ds = importSOAP(fileName);
				}
				catch (Exception ex)
				{
					KissMsg.ShowError("CtlAbfrageDefinition", "FehlerImportDatei", "Fehler beim Importieren der Datei {0}", null, ex, 0, 0, fileName);
					continue;
				}

                Session.BeginTransaction();
				try
				{					
					foreach (DataRow row in ds.Tables[0].Rows)
					{
						SqlQuery qryXQuery = DBUtil.OpenSQL(@"SELECT QueryName, UserText, QueryCode, LayoutXML, 
                                                                     ParameterXML, SQLquery, ContextForms, 
                                                                     ParentReportName, ReportSortKey, XQueryTS 
                                                              FROM dbo.XQuery WITH (READUNCOMMITTED) 
                                                              WHERE QueryName = {0}", row["QueryName"]);

						if (qryXQuery.Count == 0)
							qryXQuery.Insert("XQuery");

						foreach (DataColumn col in ds.Tables[0].Columns)
							qryXQuery[col.ColumnName] = row[col.ColumnName];

						if (!qryXQuery.Post("XQuery"))
							throw new Exception(KissMsg.GetMLMessage("CtlAbfrageDefinition", "AffectedRowsForQueryName", "affectedRows != 1 for QueryName=", KissMsgCode.MsgError, row["QueryName"]));

						if (DBNull.Value == row["ParentReportName"])
							lastMainKey = (string)row["QueryName"];
					}
					Session.Commit();
				}
				catch (Exception ex)
				{
					Session.Rollback();
					KissMsg.ShowError("CtlAbfrageDefinition", "FehlerImportieren", "Fehler beim Importieren", ex);
				}
			}
			OnRefreshData();
			kissTree1.SetFocusedNode(kissTree1.FindNodeByKeyID(lastMainKey));
		}

		private void btnExport_Click(object sender, System.EventArgs e)
		{
			//If a subreport is selected we just focus on the parent node of it. 
			//This works only 'cause there are only mainreports containing 1..n subreports without sub-subreports! 
			if (qryXQuery["ParentReportName"] != DBNull.Value)
				this.kissTree1.SetFocusedNode(this.kissTree1.FocusedNode.ParentNode);

			string fileName = qryXQuery["QueryName"] + QUERY_FILE_EXTENSION;
			fileName = System.Text.RegularExpressions.Regex.Replace(fileName, "[\\\\/:*?\"<>|\r\n]", "-");
			dlgFileSave.FileName = fileName;

			if (DialogResult.Cancel == dlgFileSave.ShowDialog(this))
				return;

			DataSet ds = DBUtil.getTreeBranch(qryXQuery["QueryName"], "XQuery", "QueryName", "ParentReportName");

			try
			{
				exportSOAP(ds, dlgFileSave.FileName);
			}
			catch (Exception ex)
			{
				KissMsg.ShowError("CtlAbfrageDefinition", "FehlerExportieren", "Fehler beim Exportieren", ex);
			}
		}

		private void btnExportAll_Click(object sender, System.EventArgs e)
		{
			if (qryXQuery.Count == 0) return;

			if (DialogResult.Cancel == folderBrowserDialog1.ShowDialog(this))
				return;

			string path = folderBrowserDialog1.SelectedPath;

			try
			{
				Cursor.Current = Cursors.WaitCursor;
				foreach (DataRow row in qryXQuery.DataTable.Rows)
				{
					string fileName = row["QueryName"] + QUERY_FILE_EXTENSION;
					fileName = System.Text.RegularExpressions.Regex.Replace(fileName, "[\\\\/:*?\"<>|\r\n]", "-");

					DataSet ds = DBUtil.getTreeBranch(row["QueryName"], "XQuery", "QueryName", "ParentReportName");

					try
					{
						exportSOAP(ds, folderBrowserDialog1.SelectedPath + @"\" + fileName);
					}
					catch (Exception ex)
					{
						KissMsg.ShowError("CtlAbfrageDefinition", "FehlerExportAbfrage", "Fehler beim Exportieren der Abfrage '{0}'", null, ex, 0, 0, row["QueryName"].ToString());
					}
				}
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		private static DataSet importSOAP(string fileName)
		{
			DataSet dsImportedReport = new DataSet();
			System.Runtime.Serialization.Formatters.Soap.SoapFormatter formatter = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
			System.IO.StreamReader reader = new System.IO.StreamReader(fileName);
			dsImportedReport = (DataSet)formatter.Deserialize(reader.BaseStream);
			reader.Close();
			return dsImportedReport;
		}

		private void exportSOAP(DataSet ds, string FullFilename)
		{
			System.Runtime.Serialization.Formatters.Soap.SoapFormatter formatter = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
			System.IO.StreamWriter writer = new System.IO.StreamWriter(FullFilename);
			// Serialize the object
			formatter.Serialize(writer.BaseStream, ds);
			writer.Close();
		}

		private void qryReports_AfterInsert(object sender, System.EventArgs e)
		{
			qryXQuery["QueryName"] = "Neue Abfrage";
			qryXQuery["QueryCode"] = "2"; // Abfrage
			qryXQuery["UserText"] = "Neue Abfrage";
		}

		private void kissTree1_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
		{
			if (posting || qryXQuery.IsInserting) return;
			posting = true;
			if (!qryXQuery.Post())
			{
				e.CanFocus = false;
				return;
			}
			posting = false;
		}

		private void DisplayGroups()
		{
			if (tabPageZugriffsrechte.HideTab || qryXQuery.IsFilling) return;

			qryZugeteilt.Fill(@"
				SELECT	URI.UserGroup_RightID, URI.UserGroupID, URI.RightID, URI.MaskName,
                        URI.MayInsert, URI.MayUpdate, URI.MayDelete, URI.QueryName,
                        URI.ClassName, URI.XUserGroup_RightTS, UGR.UserGroupName
				FROM	dbo.XUserGroup_Right      URI WITH (READUNCOMMITTED)
						INNER JOIN dbo.XUserGroup UGR WITH (READUNCOMMITTED) ON UGR.UserGroupID = URI.UserGroupID
				WHERE	URI.QueryName = {0}
				ORDER BY UserGroupName",
				qryXQuery["QueryName"]);

			qryVerfuegbar.Fill(@"
				SELECT UGR.UserGroupID, UGR.UserGroupName
				FROM   dbo.XUserGroup UGR WITH (READUNCOMMITTED)
				       LEFT JOIN dbo.XUserGroup_Right URI WITH (READUNCOMMITTED) ON URI.UserGroupID = UGR.UserGroupID and
				                                         URI.QueryName = {0}
				WHERE  URI.UserGroupID IS NULL
				ORDER BY UserGroupName", qryXQuery["QueryName"]);
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			if (qryXQuery.Count == 0) return;

			if (qryXQuery.Row.RowState == DataRowState.Added && !qryXQuery.Post()) return;

			if (sender == btnAdd && qryVerfuegbar.Count > 0)
			{
				qryZugeteilt.Insert();
				qryZugeteilt["UserGroupID"] = qryVerfuegbar["UserGroupID"];
				qryZugeteilt["QueryName"] = qryXQuery["QueryName"];
				qryZugeteilt["MayInsert"] = false;
				qryZugeteilt["MayUpdate"] = false;
				qryZugeteilt["MayDelete"] = false;
				qryZugeteilt.Post();
			}

			if (sender == btnRemove && qryZugeteilt.Count > 0)
			{
				qryZugeteilt.DeleteQuestion = null;
				qryZugeteilt.Delete();
			}

			if (sender == btnAddAll)
			{
				DBUtil.ExecSQL("DELETE FROM dbo.XUserGroup_Right WHERE QueryName = {0}", qryXQuery["QueryName"]);
				DBUtil.ExecSQL(@"
                  INSERT dbo.XUserGroup_Right (UserGroupID, QueryName, MayInsert, MayUpdate, MayDelete)
                  SELECT UserGroupID, {0}, 0, 0, 0 FROM dbo.XUserGroup WITH (READUNCOMMITTED)", qryXQuery["QueryName"]);
			}

			if (sender == btnRemoveAll)
			{
				DBUtil.ExecSQL("DELETE FROM dbo.XUserGroup_Right WHERE QueryName = {0}", qryXQuery["QueryName"]);
			}

			DisplayGroups();
		}

		private void kissTree1_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
		{
			DisplayGroups();
		}

	}
}


