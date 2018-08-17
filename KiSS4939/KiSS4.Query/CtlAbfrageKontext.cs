using System;
using DevExpress.XtraTreeList.Nodes;
using KiSS4.DB;

/// TODO: Obsolete? --> remove?
namespace KiSS4.Query
{
	/// <summary>
	/// Summary description for CtlAbfrageKontext.
	/// </summary>
	public class CtlAbfrageKontext : KiSS4.Gui.KissUserControl
	{
		private System.ComponentModel.IContainer components;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private KiSS4.Gui.KissTextEdit editFolderName;
		private KiSS4.Gui.KissLabel kissLabel1;
		private KiSS4.Gui.KissCheckEdit editInsertAtSameLevel;
		private KiSS4.DB.SqlQuery qryZugeteilt;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private KiSS4.Gui.KissGrid gridVerfuegbar;
		private DevExpress.XtraTreeList.Columns.TreeListColumn ZugeteilteReports;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private KiSS4.Gui.KissTree treeZugeteilt;
		private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
		private System.Windows.Forms.ImageList imageList1;
		private KiSS4.DB.SqlQuery qryVerfuegbar;
		private KiSS4.Gui.KissButton btnAddFolder;
		private KiSS4.Gui.KissButton btnRemoveAll;
		private KiSS4.Gui.KissButton btnAdd;
		private KiSS4.Gui.KissButton btnRemove;
		private KiSS4.Gui.KissButton btnUp;
		private KiSS4.Gui.KissButton btnDown;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colUserText;
		private DevExpress.XtraGrid.Columns.GridColumn colVerfügbarUserText;
	
		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAbfrageKontext));
			this.qryVerfuegbar = new KiSS4.DB.SqlQuery(this.components);
			this.gridVerfuegbar = new KiSS4.Gui.KissGrid();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colVerfügbarUserText = new DevExpress.XtraGrid.Columns.GridColumn();
			this.editFolderName = new KiSS4.Gui.KissTextEdit();
			this.kissLabel1 = new KiSS4.Gui.KissLabel();
			this.editInsertAtSameLevel = new KiSS4.Gui.KissCheckEdit();
			this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
			this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.ZugeteilteReports = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.treeZugeteilt = new KiSS4.Gui.KissTree();
			this.colUserText = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.btnAddFolder = new KiSS4.Gui.KissButton();
			this.btnRemoveAll = new KiSS4.Gui.KissButton();
			this.btnAdd = new KiSS4.Gui.KissButton();
			this.btnRemove = new KiSS4.Gui.KissButton();
			this.btnUp = new KiSS4.Gui.KissButton();
			this.btnDown = new KiSS4.Gui.KissButton();
			((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridVerfuegbar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.editFolderName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.editInsertAtSameLevel.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.treeZugeteilt)).BeginInit();
			this.SuspendLayout();
			// 
			// qryVerfuegbar
			// 
			this.qryVerfuegbar.HostControl = this;
			this.qryVerfuegbar.TableName = "XQuery";
			// 
			// gridVerfuegbar
			// 
			this.gridVerfuegbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.gridVerfuegbar.DataSource = this.qryVerfuegbar;
			this.gridVerfuegbar.EmbeddedNavigator.Name = "";
			this.gridVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
			this.gridVerfuegbar.Location = new System.Drawing.Point(8, 16);
			this.gridVerfuegbar.MainView = this.gridView2;
			this.gridVerfuegbar.Name = "gridVerfuegbar";
			this.gridVerfuegbar.Size = new System.Drawing.Size(312, 432);
			this.gridVerfuegbar.TabIndex = 1;
			this.gridVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
			this.gridVerfuegbar.DoubleClick += new System.EventHandler(this.gridVerfuegbar_DoubleClick);
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
            this.colVerfügbarUserText});
			this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
			this.gridView2.GridControl = this.gridVerfuegbar;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsBehavior.Editable = false;
			this.gridView2.OptionsCustomization.AllowFilter = false;
			this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
			this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
			this.gridView2.OptionsNavigation.UseTabKey = false;
			this.gridView2.OptionsSelection.MultiSelect = true;
			this.gridView2.OptionsView.ColumnAutoWidth = false;
			this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			this.gridView2.OptionsView.ShowIndicator = false;
			// 
			// colVerfügbarUserText
			// 
			this.colVerfügbarUserText.Caption = "Verfügbare Abfragen";
			this.colVerfügbarUserText.FieldName = "UserText";
			this.colVerfügbarUserText.Name = "colVerfügbarUserText";
			this.colVerfügbarUserText.Visible = true;
			this.colVerfügbarUserText.VisibleIndex = 0;
			this.colVerfügbarUserText.Width = 300;
			// 
			// editFolderName
			// 
			this.editFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.editFolderName.Location = new System.Drawing.Point(72, 456);
			this.editFolderName.Name = "editFolderName";
			this.editFolderName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
			this.editFolderName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.editFolderName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.editFolderName.Properties.Appearance.Options.UseBackColor = true;
			this.editFolderName.Properties.Appearance.Options.UseBorderColor = true;
			this.editFolderName.Properties.Appearance.Options.UseFont = true;
			this.editFolderName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.editFolderName.Size = new System.Drawing.Size(248, 24);
			this.editFolderName.TabIndex = 5;
			// 
			// kissLabel1
			// 
			this.kissLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.kissLabel1.Location = new System.Drawing.Point(8, 456);
			this.kissLabel1.Name = "kissLabel1";
			this.kissLabel1.Size = new System.Drawing.Size(65, 24);
			this.kissLabel1.TabIndex = 77;
			this.kissLabel1.Text = "Ordnername";
			// 
			// editInsertAtSameLevel
			// 
			this.editInsertAtSameLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.editInsertAtSameLevel.EditValue = false;
			this.editInsertAtSameLevel.Location = new System.Drawing.Point(384, 464);
			this.editInsertAtSameLevel.Name = "editInsertAtSameLevel";
			this.editInsertAtSameLevel.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.editInsertAtSameLevel.Properties.Appearance.Options.UseBackColor = true;
			this.editInsertAtSameLevel.Properties.Caption = "Einfügen auf derselben Ebene";
			this.editInsertAtSameLevel.Size = new System.Drawing.Size(312, 19);
			this.editInsertAtSameLevel.TabIndex = 7;
			// 
			// qryZugeteilt
			// 
			this.qryZugeteilt.CanDelete = true;
			this.qryZugeteilt.CanInsert = true;
			this.qryZugeteilt.CanUpdate = true;
			this.qryZugeteilt.DeleteQuestion = null;
			this.qryZugeteilt.HostControl = this;
			this.qryZugeteilt.TableName = "XQueryContext";
			// 
			// gridView3
			// 
			this.gridView3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3});
			this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
			this.gridView3.Name = "gridView3";
			this.gridView3.OptionsBehavior.Editable = false;
			this.gridView3.OptionsCustomization.AllowFilter = false;
			this.gridView3.OptionsFilter.UseNewCustomFilterDialog = true;
			this.gridView3.OptionsNavigation.AutoFocusNewRow = true;
			this.gridView3.OptionsNavigation.UseTabKey = false;
			this.gridView3.OptionsView.ColumnAutoWidth = false;
			this.gridView3.OptionsView.ShowGroupPanel = false;
			this.gridView3.OptionsView.ShowIndicator = false;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Verfügbare Gruppen";
			this.gridColumn3.FieldName = "UserGroupName";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 0;
			this.gridColumn3.Width = 685;
			// 
			// ZugeteilteReports
			// 
			this.ZugeteilteReports.Caption = "Zugeteilte Reports";
			this.ZugeteilteReports.FieldName = "QueryName";
			this.ZugeteilteReports.Name = "ZugeteilteReports";
			this.ZugeteilteReports.VisibleIndex = 0;
			// 
			// gridView1
			// 
			this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn1});
			this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
			this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
			this.gridView1.OptionsNavigation.UseTabKey = false;
			this.gridView1.OptionsSelection.MultiSelect = true;
			this.gridView1.OptionsView.ColumnAutoWidth = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.OptionsView.ShowIndicator = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Name = "gridColumn1";
			// 
			// treeZugeteilt
			// 
			this.treeZugeteilt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.treeZugeteilt.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
			this.treeZugeteilt.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.treeZugeteilt.Appearance.Empty.Options.UseBackColor = true;
			this.treeZugeteilt.Appearance.Empty.Options.UseForeColor = true;
			this.treeZugeteilt.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
			this.treeZugeteilt.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.treeZugeteilt.Appearance.EvenRow.Options.UseBackColor = true;
			this.treeZugeteilt.Appearance.EvenRow.Options.UseForeColor = true;
			this.treeZugeteilt.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
			this.treeZugeteilt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
			this.treeZugeteilt.Appearance.FocusedCell.Options.UseBackColor = true;
			this.treeZugeteilt.Appearance.FocusedCell.Options.UseForeColor = true;
			this.treeZugeteilt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
			this.treeZugeteilt.Appearance.FocusedRow.Options.UseForeColor = true;
			this.treeZugeteilt.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
			this.treeZugeteilt.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.treeZugeteilt.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.treeZugeteilt.Appearance.FooterPanel.Options.UseBackColor = true;
			this.treeZugeteilt.Appearance.FooterPanel.Options.UseFont = true;
			this.treeZugeteilt.Appearance.FooterPanel.Options.UseForeColor = true;
			this.treeZugeteilt.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
			this.treeZugeteilt.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
			this.treeZugeteilt.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.treeZugeteilt.Appearance.GroupButton.Options.UseBackColor = true;
			this.treeZugeteilt.Appearance.GroupButton.Options.UseFont = true;
			this.treeZugeteilt.Appearance.GroupButton.Options.UseForeColor = true;
			this.treeZugeteilt.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
			this.treeZugeteilt.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.treeZugeteilt.Appearance.GroupFooter.Options.UseBackColor = true;
			this.treeZugeteilt.Appearance.GroupFooter.Options.UseForeColor = true;
			this.treeZugeteilt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
			this.treeZugeteilt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.treeZugeteilt.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.treeZugeteilt.Appearance.HeaderPanel.Options.UseBackColor = true;
			this.treeZugeteilt.Appearance.HeaderPanel.Options.UseFont = true;
			this.treeZugeteilt.Appearance.HeaderPanel.Options.UseForeColor = true;
			this.treeZugeteilt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
			this.treeZugeteilt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.treeZugeteilt.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
			this.treeZugeteilt.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.treeZugeteilt.Appearance.HideSelectionRow.Options.UseFont = true;
			this.treeZugeteilt.Appearance.HideSelectionRow.Options.UseForeColor = true;
			this.treeZugeteilt.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
			this.treeZugeteilt.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
			this.treeZugeteilt.Appearance.HorzLine.Options.UseBackColor = true;
			this.treeZugeteilt.Appearance.HorzLine.Options.UseForeColor = true;
			this.treeZugeteilt.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
			this.treeZugeteilt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.treeZugeteilt.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.treeZugeteilt.Appearance.OddRow.Options.UseBackColor = true;
			this.treeZugeteilt.Appearance.OddRow.Options.UseFont = true;
			this.treeZugeteilt.Appearance.OddRow.Options.UseForeColor = true;
			this.treeZugeteilt.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.treeZugeteilt.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.treeZugeteilt.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.treeZugeteilt.Appearance.Preview.Options.UseBackColor = true;
			this.treeZugeteilt.Appearance.Preview.Options.UseFont = true;
			this.treeZugeteilt.Appearance.Preview.Options.UseForeColor = true;
			this.treeZugeteilt.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
			this.treeZugeteilt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.treeZugeteilt.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.treeZugeteilt.Appearance.Row.Options.UseBackColor = true;
			this.treeZugeteilt.Appearance.Row.Options.UseFont = true;
			this.treeZugeteilt.Appearance.Row.Options.UseForeColor = true;
			this.treeZugeteilt.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
			this.treeZugeteilt.Appearance.SelectedRow.Options.UseForeColor = true;
			this.treeZugeteilt.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
			this.treeZugeteilt.Appearance.TreeLine.Options.UseBackColor = true;
			this.treeZugeteilt.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
			this.treeZugeteilt.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
			this.treeZugeteilt.Appearance.VertLine.Options.UseBackColor = true;
			this.treeZugeteilt.Appearance.VertLine.Options.UseForeColor = true;
			this.treeZugeteilt.Appearance.VertLine.Options.UseTextOptions = true;
			this.treeZugeteilt.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.treeZugeteilt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.treeZugeteilt.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colUserText});
			this.treeZugeteilt.DataSource = this.qryZugeteilt;
			this.treeZugeteilt.ImageIndexFieldName = "IconID";
			this.treeZugeteilt.KeyFieldName = "QueryContextID";
			this.treeZugeteilt.Location = new System.Drawing.Point(384, 16);
			this.treeZugeteilt.Name = "treeZugeteilt";
			this.treeZugeteilt.OptionsBehavior.AutoSelectAllInEditor = false;
			this.treeZugeteilt.OptionsBehavior.CloseEditorOnLostFocus = false;
			this.treeZugeteilt.OptionsBehavior.Editable = false;
			this.treeZugeteilt.OptionsBehavior.KeepSelectedOnClick = false;
			this.treeZugeteilt.OptionsBehavior.MoveOnEdit = false;
			this.treeZugeteilt.OptionsBehavior.ShowToolTips = false;
			this.treeZugeteilt.OptionsBehavior.SmartMouseHover = false;
			this.treeZugeteilt.OptionsMenu.EnableColumnMenu = false;
			this.treeZugeteilt.OptionsMenu.EnableFooterMenu = false;
			this.treeZugeteilt.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.treeZugeteilt.OptionsView.AutoWidth = false;
			this.treeZugeteilt.OptionsView.EnableAppearanceEvenRow = true;
			this.treeZugeteilt.OptionsView.EnableAppearanceOddRow = true;
			this.treeZugeteilt.OptionsView.ShowIndicator = false;
			this.treeZugeteilt.OptionsView.ShowVertLines = false;
			this.treeZugeteilt.SelectImageList = this.imageList1;
			this.treeZugeteilt.Size = new System.Drawing.Size(312, 432);
			this.treeZugeteilt.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
								| DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
			this.treeZugeteilt.TabIndex = 8;
			// 
			// colUserText
			// 
			this.colUserText.Caption = "Zugeteilte Abfragen";
			this.colUserText.FieldName = "TreeText";
			this.colUserText.MinWidth = 27;
			this.colUserText.Name = "colUserText";
			this.colUserText.VisibleIndex = 0;
			this.colUserText.Width = 290;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			this.imageList1.Images.SetKeyName(1, "");
			// 
			// treeListColumn1
			// 
			this.treeListColumn1.Caption = "Report Name";
			this.treeListColumn1.FieldName = "ReportName";
			this.treeListColumn1.Name = "treeListColumn1";
			this.treeListColumn1.VisibleIndex = 0;
			// 
			// btnAddFolder
			// 
			this.btnAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAddFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddFolder.IconID = 13;
			this.btnAddFolder.Location = new System.Drawing.Point(338, 456);
			this.btnAddFolder.Name = "btnAddFolder";
			this.btnAddFolder.Size = new System.Drawing.Size(28, 24);
			this.btnAddFolder.TabIndex = 6;
			this.btnAddFolder.UseVisualStyleBackColor = false;
			this.btnAddFolder.Click += new System.EventHandler(this.BtnAddFolder_Click);
			// 
			// btnRemoveAll
			// 
			this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemoveAll.IconID = 12;
			this.btnRemoveAll.Location = new System.Drawing.Point(338, 264);
			this.btnRemoveAll.Name = "btnRemoveAll";
			this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
			this.btnRemoveAll.TabIndex = 4;
			this.btnRemoveAll.UseVisualStyleBackColor = false;
			this.btnRemoveAll.Click += new System.EventHandler(this.BtnRemoveAll_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.IconID = 13;
			this.btnAdd.Location = new System.Drawing.Point(338, 184);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(28, 24);
			this.btnAdd.TabIndex = 2;
			this.btnAdd.UseVisualStyleBackColor = false;
			this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemove.IconID = 11;
			this.btnRemove.Location = new System.Drawing.Point(338, 224);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(28, 24);
			this.btnRemove.TabIndex = 3;
			this.btnRemove.UseVisualStyleBackColor = false;
			this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
			// 
			// btnUp
			// 
			this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUp.IconID = 16;
			this.btnUp.Location = new System.Drawing.Point(712, 208);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(28, 24);
			this.btnUp.TabIndex = 9;
			this.btnUp.UseVisualStyleBackColor = false;
			this.btnUp.Click += new System.EventHandler(this.BtnUpDown_Click);
			// 
			// btnDown
			// 
			this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDown.IconID = 17;
			this.btnDown.Location = new System.Drawing.Point(712, 240);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(28, 24);
			this.btnDown.TabIndex = 10;
			this.btnDown.UseVisualStyleBackColor = false;
			this.btnDown.Click += new System.EventHandler(this.BtnUpDown_Click);
			// 
			// CtlAbfrageKontext
			// 
			this.Controls.Add(this.treeZugeteilt);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnAddFolder);
			this.Controls.Add(this.btnRemoveAll);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.editInsertAtSameLevel);
			this.Controls.Add(this.editFolderName);
			this.Controls.Add(this.kissLabel1);
			this.Controls.Add(this.gridVerfuegbar);
			this.Name = "CtlAbfrageKontext";
			this.Size = new System.Drawing.Size(760, 496);
			this.Load += new System.EventHandler(this.CtlReportKontext_Load);
			((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridVerfuegbar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.editFolderName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.editInsertAtSameLevel.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.treeZugeteilt)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	
		public CtlAbfrageKontext()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

		private void CtlReportKontext_Load(object sender, System.EventArgs e)
		{
			DisplayAssignedQueries();
		}

		private void DisplayAssignedQueries()
		{
			string FocusedNodeText = null;
			if (treeZugeteilt.FocusedNode != null)
				FocusedNodeText = treeZugeteilt.FocusedNode.GetValue("TreeText").ToString();

			qryZugeteilt.Fill(@"
				SELECT	QCT.*, 
						QRY.*,
						IconID   =	CASE WHEN QCT.FolderName IS NULL THEN 1 ELSE 0 END,
						TreeText =	CASE WHEN QCT.FolderName IS NULL THEN QRY.UserText
									ELSE QCT.FolderName
									END
				FROM	XQueryContext QCT 
						LEFT JOIN XQuery QRY ON QRY.QueryName = QCT.QueryName
				WHERE	QCT.QueryCode=2 
				ORDER BY ParentID, ParentPosition ");

			qryVerfuegbar.Fill(@"
				SELECT	QRY.* 
				FROM	XQuery QRY
						LEFT JOIN XQueryContext CON on CON.QueryName = QRY.QueryName
				WHERE	QRY.QueryCode = 2 AND
						ParentReportName IS NULL AND
						CON.QueryName is NULL
				ORDER BY UserText");

			treeZugeteilt.ExpandAll();

			if (FocusedNodeText != null)
			{
				//relocate to ID
				TreeListNode node = DBUtil.FindNodeByValue(treeZugeteilt.Nodes,FocusedNodeText,"TreeText");
				if (node != null)
					treeZugeteilt.FocusedNode = node;
			}

		}

		private void BtnAdd_Click(object sender, System.EventArgs e)
		{
			if (qryVerfuegbar.Count == 0) return;
			object ParentID = DBNull.Value;
			int Position = 1;
			string QueryID = qryVerfuegbar["QueryName"] as string;
			if (qryZugeteilt.Count > 0)
			{
				ParentID = this.GetParentID();
				Position = this.GetPosition(ParentID);
			}
			this.InsertInQueryContext(null, QueryID, ParentID, Position);
			int NewRowHandle = gridVerfuegbar.View.GetNextVisibleRow(gridVerfuegbar.View.FocusedRowHandle);
			this.DisplayAssignedQueries();
		}

		private void BtnRemove_Click(object sender, System.EventArgs e)
		{
			if (qryZugeteilt.Count > 0)
				qryZugeteilt.Delete();

			this.DisplayAssignedQueries();
		}

		private void BtnRemoveAll_Click(object sender, System.EventArgs e)
		{
			DBUtil.ExecSQL("DELETE FROM XQueryContext WHERE QueryCode = 2");
		
			this.DisplayAssignedQueries();
		}

		private void BtnAddFolder_Click(object sender, System.EventArgs e)
		{
			string FolderName = editFolderName.Text;
			if (DBUtil.IsEmpty(editFolderName.Text))
			{
				KissMsg.ShowInfo("CtlAbfrageKontext", "ErstNameEingeben", "Der Name des neuen Ordners muss zuerst im Feld 'Ordnername' eingeben werden!");
				return;
			}
			
			object ParentID = DBNull.Value;
			int Position = 1;

			if (qryZugeteilt.Count > 0)
			{
				ParentID = this.GetParentID();
				Position = this.GetPosition(ParentID);
			}
			this.InsertInQueryContext(FolderName, null, ParentID, Position );
			int NewRowHandle = gridVerfuegbar.View.GetNextVisibleRow(gridVerfuegbar.View.FocusedRowHandle);
			this.DisplayAssignedQueries();

			this.editFolderName.Text = "";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		private object GetParentID()
		{
			if (editInsertAtSameLevel.Checked || DBUtil.IsEmpty(qryZugeteilt["FolderName"]))
				return qryZugeteilt["ParentID"];
			else
				return qryZugeteilt["QueryContextID"];
		}

		private int GetPosition(object parentID)
		{
			return (int) DBUtil.ExecuteScalarSQL(@"
				SELECT	ISNULL(MAX(ParentPosition) + 1,1) 
				FROM	XQueryContext
				WHERE	IsNull(ParentID, 0) = IsNull({0}, 0)",
				parentID);
		}

		private void InsertInQueryContext(string FolderName, string QueryName, object ParentID, int ParentPosition)
		{
			DBUtil.ExecSQL(@"
                INSERT XQueryContext (QueryCode, FolderName, QueryName, ParentID, ParentPosition )
				VALUES ({0},{1},{2},{3},{4})",
				2, //Abfrage
				FolderName,
				QueryName,
				ParentID,
				ParentPosition);
		}

		private void BtnUpDown_Click(object sender, System.EventArgs e)
		{
			btnUp.Enabled = false;
			btnDown.Enabled = false;

			if (qryZugeteilt.Count <= 1) return;
			if (!qryZugeteilt.Post()) return;

			SqlQuery qry;
			if (sender == btnUp)
				//Vorgänger bestimmen
				qry = DBUtil.OpenSQL(@"
				SELECT	TOP 1 * 
				FROM	XQueryContext 
				WHERE	IsNull(ParentID, 0) = IsNull({0}, 0) and
						ParentPosition < {1}
				ORDER BY ParentPosition DESC",
					qryZugeteilt["ParentID"],
					qryZugeteilt["ParentPosition"]);
			else
				//Nachfolger bestimmen
				qry = DBUtil.OpenSQL(@"
					SELECT	TOP 1 * 
					FROM	XQueryContext 
					WHERE	IsNull(ParentID, 0) = IsNull({0}, 0) and
							ParentPosition > {1}
					ORDER BY ParentPosition",
					qryZugeteilt["ParentID"],
					qryZugeteilt["ParentPosition"]);

			if (qry.Count == 0) 
			{
				btnUp.Enabled = true;
				btnDown.Enabled = true;
				return;
			}

			//Position tauschen
			DBUtil.ExecSQL(
				"update XQueryContext set ParentPosition = {0} where QueryContextID = {1}",
				qry["ParentPosition"],
				qryZugeteilt["QueryContextID"]);

			DBUtil.ExecSQL(
				"update XQueryContext set ParentPosition = {0} where QueryContextID = {1}",
				qryZugeteilt["ParentPosition"],
				qry["QueryContextID"]);

			btnUp.Enabled = true;
			btnDown.Enabled = true;
			DisplayAssignedQueries();
		}

		private void gridVerfuegbar_DoubleClick(object sender, System.EventArgs e)
		{
			if (this.btnAdd.Enabled) this.btnAdd.PerformClick();
		}
	}
}
