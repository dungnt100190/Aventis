using System;
using System.Data;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.DesignerHost
{
	/// <summary>
	/// Summary description for CtlTableEditor.
	/// </summary>
	public class CtlTableEditor : KiSS4.Common.KissSearchUserControl
	{
		#region Variables

		private KiSS4.DB.SqlQuery qryXTable;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn colModulID;
		private KiSS4.Gui.KissGrid grdXTable;
		private DevExpress.XtraGrid.Columns.GridColumn colTable;
		private DevExpress.XtraGrid.Columns.GridColumn colSystem;
		private DevExpress.XtraGrid.Columns.GridColumn colAlias;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
		private KiSS4.Gui.KissLookUpEdit cboSearchModulID;
		private KiSS4.Gui.KissLabel lblSearchModulID;
		private KiSS4.Gui.KissLabel lblSearchAlias;
		private KiSS4.Gui.KissTextEdit txtSearchAlias;
		private KiSS4.Gui.KissCheckEdit chkSearchSystem;
		private KiSS4.Gui.KissTextEdit txtSearchTable;
		private KiSS4.Gui.KissLabel lblSearchTable;
		private System.ComponentModel.IContainer components;
		private KiSS4.Gui.KissLabel lblSearchSystem;
		private KiSS4.Gui.KissLookUpEdit cboModulID;
		private KiSS4.Gui.KissLabel lblModulID;
		private KiSS4.Gui.KissLabel lblAlias;
		private KiSS4.Gui.KissTextEdit txtAlias;
		private KiSS4.Gui.KissCheckEdit chkSystem;
		private KiSS4.Gui.KissTextEdit txtTableName;
		private KiSS4.Gui.KissLabel lblTableName;
		private KiSS4.Gui.KissCheckEdit chkHistory;
		private KiSS4.Gui.KissLabel lblSystem;
		private KiSS4.Gui.KissLabel lblHistory;
		private DevExpress.XtraGrid.Views.Grid.GridView grvXTable;
		private KiSS4.Gui.KissContainerControl kccContainer;
		private KiSS4.Gui.KissContainerControl kccSubContainer;
		private KiSS4.Gui.KissMemoEdit editComment;
		private DevExpress.XtraGrid.Columns.GridColumn colDataWareHouse;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
		private KiSS4.Gui.KissCheckEdit chkDataWareHouse;
		private KiSS4.Gui.KissLabel lblDataWareHouse;
		private DevExpress.XtraGrid.Columns.GridColumn colComment;
        private KiSS4.Gui.KissLabel lblComment;

		#endregion

		#region Contructor / Dispose

		private object ModulID = DBNull.Value;

		public CtlTableEditor(int ModulID) : this()
		{
			this.ModulID = ModulID;
			this.cboModulID.EditMode = EditModeType.ReadOnly;

			this.cboSearchModulID.EditValue = ModulID;
			this.RunSearch();
		}

		public CtlTableEditor()
		{
			// this call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			this.ActiveSQLQuery = qryXTable;
			
			// init new search in order to clear EditValue of controls
			NewSearch();

			// show tabList per default
			this.tabControlSearch.SelectedTabIndex = 0;

			// init controls and fill lists
			SqlQuery qryModuls = DesignerHostUtils.GetNonSystemModuls();
			this.colModulID.ColumnEdit = grdXTable.GetLOVLookUpEdit( qryModuls );
			this.cboSearchModulID.Properties.DataSource = qryModuls;
			this.cboModulID.Properties.DataSource = qryModuls;			

			this.qryXTable.Fill("SELECT * FROM XTable");
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			this.qryXTable = new KiSS4.DB.SqlQuery(this.components);
			this.grdXTable = new KiSS4.Gui.KissGrid();
			this.grvXTable = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colTable = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSystem = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.colDataWareHouse = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.colAlias = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colModulID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.cboSearchModulID = new KiSS4.Gui.KissLookUpEdit();
			this.lblSearchModulID = new KiSS4.Gui.KissLabel();
			this.lblSearchAlias = new KiSS4.Gui.KissLabel();
			this.txtSearchAlias = new KiSS4.Gui.KissTextEdit();
			this.chkSearchSystem = new KiSS4.Gui.KissCheckEdit();
			this.txtSearchTable = new KiSS4.Gui.KissTextEdit();
			this.lblSearchTable = new KiSS4.Gui.KissLabel();
			this.lblSearchSystem = new KiSS4.Gui.KissLabel();
			this.cboModulID = new KiSS4.Gui.KissLookUpEdit();
			this.lblModulID = new KiSS4.Gui.KissLabel();
			this.lblAlias = new KiSS4.Gui.KissLabel();
			this.txtAlias = new KiSS4.Gui.KissTextEdit();
			this.chkSystem = new KiSS4.Gui.KissCheckEdit();
			this.txtTableName = new KiSS4.Gui.KissTextEdit();
			this.lblTableName = new KiSS4.Gui.KissLabel();
			this.chkHistory = new KiSS4.Gui.KissCheckEdit();
			this.lblSystem = new KiSS4.Gui.KissLabel();
			this.lblHistory = new KiSS4.Gui.KissLabel();
			this.kccContainer = new KiSS4.Gui.KissContainerControl();
			this.kccSubContainer = new KiSS4.Gui.KissContainerControl();
			this.editComment = new KiSS4.Gui.KissMemoEdit();
			this.lblComment = new KiSS4.Gui.KissLabel();
			this.chkDataWareHouse = new KiSS4.Gui.KissCheckEdit();
			this.lblDataWareHouse = new KiSS4.Gui.KissLabel();
			this.tabControlSearch.SuspendLayout();
			this.tpgListe.SuspendLayout();
			this.tpgSuchen.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.qryXTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdXTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grvXTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cboSearchModulID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cboSearchModulID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSearchModulID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSearchAlias)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSearchAlias.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSearchSystem.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSearchTable.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSearchTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSearchSystem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cboModulID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cboModulID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblModulID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblAlias)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAlias.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSystem.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTableName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblTableName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkHistory.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSystem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblHistory)).BeginInit();
			this.kccContainer.SuspendLayout();
			this.kccSubContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.editComment.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblComment)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkDataWareHouse.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblDataWareHouse)).BeginInit();
			this.SuspendLayout();
			// 
			// searchTitle
			// 
			this.searchTitle.Size = new System.Drawing.Size(824, 24);
			// 
			// tabControlSearch
			// 
			this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
			this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
			this.tabControlSearch.Size = new System.Drawing.Size(888, 344);
			this.tabControlSearch.TabIndex = 1;
			this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tcTables_SelectedTabChanged);
			// 
			// tpgListe
			// 
			this.tpgListe.Controls.Add(this.grdXTable);
			this.tpgListe.Size = new System.Drawing.Size(876, 306);
			this.tpgListe.Title = "Liste";
			// 
			// tpgSuchen
			// 
			this.tpgSuchen.Controls.Add(this.cboSearchModulID);
			this.tpgSuchen.Controls.Add(this.lblSearchModulID);
			this.tpgSuchen.Controls.Add(this.lblSearchAlias);
			this.tpgSuchen.Controls.Add(this.txtSearchAlias);
			this.tpgSuchen.Controls.Add(this.chkSearchSystem);
			this.tpgSuchen.Controls.Add(this.txtSearchTable);
			this.tpgSuchen.Controls.Add(this.lblSearchTable);
			this.tpgSuchen.Controls.Add(this.lblSearchSystem);
			this.tpgSuchen.Size = new System.Drawing.Size(876, 306);
			this.tpgSuchen.Title = "Suche";
			this.tpgSuchen.Controls.SetChildIndex(this.lblSearchSystem, 0);
			this.tpgSuchen.Controls.SetChildIndex(this.lblSearchTable, 0);
			this.tpgSuchen.Controls.SetChildIndex(this.txtSearchTable, 0);
			this.tpgSuchen.Controls.SetChildIndex(this.chkSearchSystem, 0);
			this.tpgSuchen.Controls.SetChildIndex(this.txtSearchAlias, 0);
			this.tpgSuchen.Controls.SetChildIndex(this.lblSearchAlias, 0);
			this.tpgSuchen.Controls.SetChildIndex(this.lblSearchModulID, 0);
			this.tpgSuchen.Controls.SetChildIndex(this.cboSearchModulID, 0);
			this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
			// 
			// qryXTable
			// 
			this.qryXTable.CanDelete = true;
			this.qryXTable.CanInsert = true;
			this.qryXTable.CanUpdate = true;
			this.qryXTable.HostControl = this;
			this.qryXTable.TableName = "XTable";
			this.qryXTable.AfterDelete += new System.EventHandler(this.qryXTable_AfterDelete);
			this.qryXTable.AfterInsert += new System.EventHandler(this.qryXTable_AfterInsert);
			this.qryXTable.PositionChanged += new System.EventHandler(this.qryXTable_PositionChanged);
			this.qryXTable.BeforePost += new System.EventHandler(this.qryXTable_BeforePost);
			this.qryXTable.AfterPost += new System.EventHandler(this.qryXTable_AfterPost);
			this.qryXTable.BeforeDeleteQuestion += new System.EventHandler(this.qryXTable_BeforeDeleteQuestion);
			this.qryXTable.BeforeDelete += new System.EventHandler(this.qryXTable_BeforeDelete);
			// 
			// grdXTable
			// 
			this.grdXTable.DataSource = this.qryXTable;
			this.grdXTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdXTable.EmbeddedNavigator.Name = "";
			this.grdXTable.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
			this.grdXTable.Location = new System.Drawing.Point(0, 0);
			this.grdXTable.MainView = this.grvXTable;
			this.grdXTable.Name = "grdXTable";
			this.grdXTable.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3});
			this.grdXTable.Size = new System.Drawing.Size(876, 306);
			this.grdXTable.TabIndex = 0;
			this.grdXTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvXTable,
            this.gridView2});
			// 
			// grvXTable
			// 
			this.grvXTable.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.grvXTable.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvXTable.Appearance.Empty.Options.UseBackColor = true;
			this.grvXTable.Appearance.Empty.Options.UseFont = true;
			this.grvXTable.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvXTable.Appearance.EvenRow.Options.UseFont = true;
			this.grvXTable.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
			this.grvXTable.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvXTable.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
			this.grvXTable.Appearance.FocusedCell.Options.UseBackColor = true;
			this.grvXTable.Appearance.FocusedCell.Options.UseFont = true;
			this.grvXTable.Appearance.FocusedCell.Options.UseForeColor = true;
			this.grvXTable.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
			this.grvXTable.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvXTable.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
			this.grvXTable.Appearance.FocusedRow.Options.UseBackColor = true;
			this.grvXTable.Appearance.FocusedRow.Options.UseFont = true;
			this.grvXTable.Appearance.FocusedRow.Options.UseForeColor = true;
			this.grvXTable.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
			this.grvXTable.Appearance.GroupPanel.Options.UseBackColor = true;
			this.grvXTable.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
			this.grvXTable.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.grvXTable.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grvXTable.Appearance.GroupRow.Options.UseBackColor = true;
			this.grvXTable.Appearance.GroupRow.Options.UseFont = true;
			this.grvXTable.Appearance.GroupRow.Options.UseForeColor = true;
			this.grvXTable.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
			this.grvXTable.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
			this.grvXTable.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.grvXTable.Appearance.HeaderPanel.Options.UseBackColor = true;
			this.grvXTable.Appearance.HeaderPanel.Options.UseBorderColor = true;
			this.grvXTable.Appearance.HeaderPanel.Options.UseFont = true;
			this.grvXTable.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
			this.grvXTable.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvXTable.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grvXTable.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.grvXTable.Appearance.HideSelectionRow.Options.UseFont = true;
			this.grvXTable.Appearance.HideSelectionRow.Options.UseForeColor = true;
			this.grvXTable.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
			this.grvXTable.Appearance.HorzLine.Options.UseBackColor = true;
			this.grvXTable.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvXTable.Appearance.OddRow.Options.UseFont = true;
			this.grvXTable.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
			this.grvXTable.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvXTable.Appearance.Row.Options.UseBackColor = true;
			this.grvXTable.Appearance.Row.Options.UseFont = true;
			this.grvXTable.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvXTable.Appearance.SelectedRow.Options.UseFont = true;
			this.grvXTable.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
			this.grvXTable.Appearance.VertLine.Options.UseBackColor = true;
			this.grvXTable.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.grvXTable.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTable,
            this.colSystem,
            this.colDataWareHouse,
            this.colAlias,
            this.colModulID,
            this.colComment});
			this.grvXTable.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
			this.grvXTable.GridControl = this.grdXTable;
			this.grvXTable.Name = "grvXTable";
			this.grvXTable.OptionsBehavior.Editable = false;
			this.grvXTable.OptionsCustomization.AllowFilter = false;
			this.grvXTable.OptionsFilter.AllowFilterEditor = false;
			this.grvXTable.OptionsFilter.UseNewCustomFilterDialog = true;
			this.grvXTable.OptionsMenu.EnableColumnMenu = false;
			this.grvXTable.OptionsNavigation.AutoFocusNewRow = true;
			this.grvXTable.OptionsNavigation.UseTabKey = false;
			this.grvXTable.OptionsView.ColumnAutoWidth = false;
			this.grvXTable.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.grvXTable.OptionsView.ShowGroupPanel = false;
			this.grvXTable.OptionsView.ShowIndicator = false;
			// 
			// colTable
			// 
			this.colTable.Caption = "Tabelle";
			this.colTable.FieldName = "TableName";
			this.colTable.Name = "colTable";
			this.colTable.Visible = true;
			this.colTable.VisibleIndex = 0;
			this.colTable.Width = 207;
			// 
			// colSystem
			// 
			this.colSystem.Caption = "System";
			this.colSystem.ColumnEdit = this.repositoryItemCheckEdit1;
			this.colSystem.FieldName = "System";
			this.colSystem.Name = "colSystem";
			this.colSystem.Visible = true;
			this.colSystem.VisibleIndex = 1;
			this.colSystem.Width = 54;
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
			// 
			// colDataWareHouse
			// 
			this.colDataWareHouse.Caption = "DWH";
			this.colDataWareHouse.ColumnEdit = this.repositoryItemCheckEdit3;
			this.colDataWareHouse.FieldName = "DataWareHouse";
			this.colDataWareHouse.Name = "colDataWareHouse";
			this.colDataWareHouse.Visible = true;
			this.colDataWareHouse.VisibleIndex = 2;
			this.colDataWareHouse.Width = 39;
			// 
			// repositoryItemCheckEdit3
			// 
			this.repositoryItemCheckEdit3.AutoHeight = false;
			this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
			// 
			// colAlias
			// 
			this.colAlias.Caption = "Alias";
			this.colAlias.FieldName = "Alias";
			this.colAlias.Name = "colAlias";
			this.colAlias.Visible = true;
			this.colAlias.VisibleIndex = 3;
			this.colAlias.Width = 42;
			// 
			// colModulID
			// 
			this.colModulID.Caption = "Modul";
			this.colModulID.FieldName = "ModulID";
			this.colModulID.Name = "colModulID";
			this.colModulID.Visible = true;
			this.colModulID.VisibleIndex = 4;
			this.colModulID.Width = 134;
			// 
			// colComment
			// 
			this.colComment.Caption = "Kommentar";
			this.colComment.FieldName = "Comment";
			this.colComment.Name = "colComment";
			this.colComment.Visible = true;
			this.colComment.VisibleIndex = 5;
			this.colComment.Width = 339;
			// 
			// repositoryItemCheckEdit2
			// 
			this.repositoryItemCheckEdit2.AutoHeight = false;
			this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
			// 
			// gridView2
			// 
			this.gridView2.GridControl = this.grdXTable;
			this.gridView2.Name = "gridView2";
			// 
			// cboSearchModulID
			// 
			this.cboSearchModulID.Location = new System.Drawing.Point(120, 144);
			this.cboSearchModulID.Name = "cboSearchModulID";
			this.cboSearchModulID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
			this.cboSearchModulID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.cboSearchModulID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.cboSearchModulID.Properties.Appearance.Options.UseBackColor = true;
			this.cboSearchModulID.Properties.Appearance.Options.UseBorderColor = true;
			this.cboSearchModulID.Properties.Appearance.Options.UseFont = true;
			this.cboSearchModulID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
			this.cboSearchModulID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.cboSearchModulID.Properties.AppearanceDropDown.Options.UseBackColor = true;
			this.cboSearchModulID.Properties.AppearanceDropDown.Options.UseFont = true;
			this.cboSearchModulID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
			serializableAppearanceObject2.Options.UseBackColor = true;
			this.cboSearchModulID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
			this.cboSearchModulID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.cboSearchModulID.Properties.DisplayMember = "Text";
			this.cboSearchModulID.Properties.NullText = "";
			this.cboSearchModulID.Properties.ShowFooter = false;
			this.cboSearchModulID.Properties.ShowHeader = false;
			this.cboSearchModulID.Properties.ValueMember = "Code";
			this.cboSearchModulID.Size = new System.Drawing.Size(200, 24);
			this.cboSearchModulID.TabIndex = 8;
			// 
			// lblSearchModulID
			// 
			this.lblSearchModulID.Location = new System.Drawing.Point(16, 144);
			this.lblSearchModulID.Name = "lblSearchModulID";
			this.lblSearchModulID.Size = new System.Drawing.Size(100, 23);
			this.lblSearchModulID.TabIndex = 4;
			this.lblSearchModulID.Text = "Modul";
			// 
			// lblSearchAlias
			// 
			this.lblSearchAlias.Location = new System.Drawing.Point(16, 112);
			this.lblSearchAlias.Name = "lblSearchAlias";
			this.lblSearchAlias.Size = new System.Drawing.Size(100, 23);
			this.lblSearchAlias.TabIndex = 3;
			this.lblSearchAlias.Text = "Alias";
			// 
			// txtSearchAlias
			// 
			this.txtSearchAlias.Location = new System.Drawing.Point(120, 112);
			this.txtSearchAlias.Name = "txtSearchAlias";
			this.txtSearchAlias.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
			this.txtSearchAlias.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.txtSearchAlias.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.txtSearchAlias.Properties.Appearance.Options.UseBackColor = true;
			this.txtSearchAlias.Properties.Appearance.Options.UseBorderColor = true;
			this.txtSearchAlias.Properties.Appearance.Options.UseFont = true;
			this.txtSearchAlias.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.txtSearchAlias.Size = new System.Drawing.Size(200, 24);
			this.txtSearchAlias.TabIndex = 7;
			// 
			// chkSearchSystem
			// 
			this.chkSearchSystem.EditValue = false;
			this.chkSearchSystem.Location = new System.Drawing.Point(120, 84);
			this.chkSearchSystem.Name = "chkSearchSystem";
			this.chkSearchSystem.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.chkSearchSystem.Properties.Appearance.Options.UseBackColor = true;
			this.chkSearchSystem.Properties.Caption = "";
			this.chkSearchSystem.Size = new System.Drawing.Size(20, 19);
			this.chkSearchSystem.TabIndex = 6;
			// 
			// txtSearchTable
			// 
			this.txtSearchTable.Location = new System.Drawing.Point(120, 48);
			this.txtSearchTable.Name = "txtSearchTable";
			this.txtSearchTable.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
			this.txtSearchTable.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.txtSearchTable.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.txtSearchTable.Properties.Appearance.Options.UseBackColor = true;
			this.txtSearchTable.Properties.Appearance.Options.UseBorderColor = true;
			this.txtSearchTable.Properties.Appearance.Options.UseFont = true;
			this.txtSearchTable.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.txtSearchTable.Size = new System.Drawing.Size(200, 24);
			this.txtSearchTable.TabIndex = 5;
			// 
			// lblSearchTable
			// 
			this.lblSearchTable.Location = new System.Drawing.Point(16, 48);
			this.lblSearchTable.Name = "lblSearchTable";
			this.lblSearchTable.Size = new System.Drawing.Size(100, 24);
			this.lblSearchTable.TabIndex = 2;
			this.lblSearchTable.Text = "Tabelle";
			// 
			// lblSearchSystem
			// 
			this.lblSearchSystem.Location = new System.Drawing.Point(16, 80);
			this.lblSearchSystem.Name = "lblSearchSystem";
			this.lblSearchSystem.Size = new System.Drawing.Size(100, 24);
			this.lblSearchSystem.TabIndex = 2;
			this.lblSearchSystem.Text = "System";
			// 
			// cboModulID
			// 
			this.cboModulID.DataMember = "ModulID";
			this.cboModulID.DataSource = this.qryXTable;
			this.cboModulID.Location = new System.Drawing.Point(112, 112);
			this.cboModulID.Name = "cboModulID";
			this.cboModulID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
			this.cboModulID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.cboModulID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.cboModulID.Properties.Appearance.Options.UseBackColor = true;
			this.cboModulID.Properties.Appearance.Options.UseBorderColor = true;
			this.cboModulID.Properties.Appearance.Options.UseFont = true;
			this.cboModulID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
			this.cboModulID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.cboModulID.Properties.AppearanceDropDown.Options.UseBackColor = true;
			this.cboModulID.Properties.AppearanceDropDown.Options.UseFont = true;
			this.cboModulID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
			serializableAppearanceObject1.Options.UseBackColor = true;
			this.cboModulID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
			this.cboModulID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.cboModulID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
			this.cboModulID.Properties.DisplayMember = "Text";
			this.cboModulID.Properties.NullText = "";
			this.cboModulID.Properties.ShowFooter = false;
			this.cboModulID.Properties.ShowHeader = false;
			this.cboModulID.Properties.ValueMember = "Code";
			this.cboModulID.Size = new System.Drawing.Size(200, 24);
			this.cboModulID.TabIndex = 8;
			// 
			// lblModulID
			// 
			this.lblModulID.Location = new System.Drawing.Point(16, 112);
			this.lblModulID.Name = "lblModulID";
			this.lblModulID.Size = new System.Drawing.Size(100, 23);
			this.lblModulID.TabIndex = 4;
			this.lblModulID.Text = "Modul";
			// 
			// lblAlias
			// 
			this.lblAlias.Location = new System.Drawing.Point(16, 80);
			this.lblAlias.Name = "lblAlias";
			this.lblAlias.Size = new System.Drawing.Size(100, 23);
			this.lblAlias.TabIndex = 3;
			this.lblAlias.Text = "Alias";
			// 
			// txtAlias
			// 
			this.txtAlias.DataMember = "Alias";
			this.txtAlias.DataSource = this.qryXTable;
			this.txtAlias.Location = new System.Drawing.Point(112, 80);
			this.txtAlias.Name = "txtAlias";
			this.txtAlias.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
			this.txtAlias.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.txtAlias.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.txtAlias.Properties.Appearance.Options.UseBackColor = true;
			this.txtAlias.Properties.Appearance.Options.UseBorderColor = true;
			this.txtAlias.Properties.Appearance.Options.UseFont = true;
			this.txtAlias.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.txtAlias.Properties.MaxLength = 3;
			this.txtAlias.Size = new System.Drawing.Size(200, 24);
			this.txtAlias.TabIndex = 7;
			// 
			// chkSystem
			// 
			this.chkSystem.DataMember = "System";
			this.chkSystem.DataSource = this.qryXTable;
			this.chkSystem.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
			this.chkSystem.Location = new System.Drawing.Point(112, 50);
			this.chkSystem.Name = "chkSystem";
			this.chkSystem.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.chkSystem.Properties.Appearance.Options.UseBackColor = true;
			this.chkSystem.Properties.Caption = "";
			this.chkSystem.Properties.ReadOnly = true;
			this.chkSystem.Size = new System.Drawing.Size(24, 19);
			this.chkSystem.TabIndex = 6;
			// 
			// txtTableName
			// 
			this.txtTableName.DataMember = "TableName";
			this.txtTableName.DataSource = this.qryXTable;
			this.txtTableName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
			this.txtTableName.Location = new System.Drawing.Point(112, 16);
			this.txtTableName.Name = "txtTableName";
			this.txtTableName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.txtTableName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.txtTableName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.txtTableName.Properties.Appearance.Options.UseBackColor = true;
			this.txtTableName.Properties.Appearance.Options.UseBorderColor = true;
			this.txtTableName.Properties.Appearance.Options.UseFont = true;
			this.txtTableName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.txtTableName.Properties.ReadOnly = true;
			this.txtTableName.Size = new System.Drawing.Size(200, 24);
			this.txtTableName.TabIndex = 5;
			// 
			// lblTableName
			// 
			this.lblTableName.Location = new System.Drawing.Point(16, 16);
			this.lblTableName.Name = "lblTableName";
			this.lblTableName.Size = new System.Drawing.Size(100, 24);
			this.lblTableName.TabIndex = 2;
			this.lblTableName.Text = "Tabelle";
			// 
			// chkHistory
			// 
			this.chkHistory.EditValue = false;
			this.chkHistory.Location = new System.Drawing.Point(112, 146);
			this.chkHistory.Name = "chkHistory";
			this.chkHistory.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.chkHistory.Properties.Appearance.Options.UseBackColor = true;
			this.chkHistory.Properties.Caption = "";
			this.chkHistory.Size = new System.Drawing.Size(24, 19);
			this.chkHistory.TabIndex = 9;
			this.chkHistory.CheckedChanged += new System.EventHandler(this.chkHistory_CheckedChanged);
			// 
			// lblSystem
			// 
			this.lblSystem.Location = new System.Drawing.Point(16, 48);
			this.lblSystem.Name = "lblSystem";
			this.lblSystem.Size = new System.Drawing.Size(100, 24);
			this.lblSystem.TabIndex = 2;
			this.lblSystem.Text = "System";
			// 
			// lblHistory
			// 
			this.lblHistory.Location = new System.Drawing.Point(16, 144);
			this.lblHistory.Name = "lblHistory";
			this.lblHistory.Size = new System.Drawing.Size(100, 24);
			this.lblHistory.TabIndex = 2;
			this.lblHistory.Text = "Verlauf";
			// 
			// kccContainer
			// 
			this.kccContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.kccContainer.Controls.Add(this.kccSubContainer);
			this.kccContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.kccContainer.Location = new System.Drawing.Point(0, 344);
			this.kccContainer.Name = "kccContainer";
			this.kccContainer.Size = new System.Drawing.Size(888, 216);
			this.kccContainer.TabIndex = 11;
			// 
			// kccSubContainer
			// 
			this.kccSubContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.kccSubContainer.Controls.Add(this.editComment);
			this.kccSubContainer.Controls.Add(this.cboModulID);
			this.kccSubContainer.Controls.Add(this.txtTableName);
			this.kccSubContainer.Controls.Add(this.chkHistory);
			this.kccSubContainer.Controls.Add(this.txtAlias);
			this.kccSubContainer.Controls.Add(this.chkSystem);
			this.kccSubContainer.Controls.Add(this.lblTableName);
			this.kccSubContainer.Controls.Add(this.lblSystem);
			this.kccSubContainer.Controls.Add(this.lblModulID);
			this.kccSubContainer.Controls.Add(this.lblAlias);
			this.kccSubContainer.Controls.Add(this.lblHistory);
			this.kccSubContainer.Controls.Add(this.lblComment);
			this.kccSubContainer.Controls.Add(this.chkDataWareHouse);
			this.kccSubContainer.Controls.Add(this.lblDataWareHouse);
			this.kccSubContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kccSubContainer.Location = new System.Drawing.Point(0, 0);
			this.kccSubContainer.Name = "kccSubContainer";
			this.kccSubContainer.Size = new System.Drawing.Size(888, 216);
			this.kccSubContainer.TabIndex = 12;
			// 
			// editComment
			// 
			this.editComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.editComment.DataMember = "Comment";
			this.editComment.DataSource = this.qryXTable;
			this.editComment.Location = new System.Drawing.Point(360, 80);
			this.editComment.Name = "editComment";
			this.editComment.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
			this.editComment.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.editComment.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.editComment.Properties.Appearance.Options.UseBackColor = true;
			this.editComment.Properties.Appearance.Options.UseBorderColor = true;
			this.editComment.Properties.Appearance.Options.UseFont = true;
			this.editComment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.editComment.Size = new System.Drawing.Size(504, 120);
			this.editComment.TabIndex = 12;
			// 
			// lblComment
			// 
			this.lblComment.Location = new System.Drawing.Point(360, 48);
			this.lblComment.Name = "lblComment";
			this.lblComment.Size = new System.Drawing.Size(120, 24);
			this.lblComment.TabIndex = 2;
			this.lblComment.Text = "Beschreibung";
			// 
			// chkDataWareHouse
			// 
			this.chkDataWareHouse.DataMember = "DataWareHouse";
			this.chkDataWareHouse.DataSource = this.qryXTable;
			this.chkDataWareHouse.Location = new System.Drawing.Point(456, 19);
			this.chkDataWareHouse.Name = "chkDataWareHouse";
			this.chkDataWareHouse.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.chkDataWareHouse.Properties.Appearance.Options.UseBackColor = true;
			this.chkDataWareHouse.Properties.Caption = "";
			this.chkDataWareHouse.Size = new System.Drawing.Size(24, 19);
			this.chkDataWareHouse.TabIndex = 9;
			// 
			// lblDataWareHouse
			// 
			this.lblDataWareHouse.Location = new System.Drawing.Point(360, 16);
			this.lblDataWareHouse.Name = "lblDataWareHouse";
			this.lblDataWareHouse.Size = new System.Drawing.Size(100, 24);
			this.lblDataWareHouse.TabIndex = 2;
			this.lblDataWareHouse.Text = "DataWareHouse";
			// 
			// CtlTableEditor
			// 
			this.Controls.Add(this.kccContainer);
			this.Name = "CtlTableEditor";
			this.Size = new System.Drawing.Size(888, 560);
			this.Controls.SetChildIndex(this.kccContainer, 0);
			this.Controls.SetChildIndex(this.tabControlSearch, 0);
			this.tabControlSearch.ResumeLayout(false);
			this.tpgListe.ResumeLayout(false);
			this.tpgSuchen.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.qryXTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdXTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grvXTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cboSearchModulID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cboSearchModulID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSearchModulID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSearchAlias)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSearchAlias.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSearchSystem.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSearchTable.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSearchTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSearchSystem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cboModulID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cboModulID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblModulID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblAlias)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAlias.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkSystem.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTableName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblTableName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkHistory.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblSystem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblHistory)).EndInit();
			this.kccContainer.ResumeLayout(false);
			this.kccSubContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.editComment.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblComment)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkDataWareHouse.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblDataWareHouse)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region public events
		
		/// <summary>
		/// The user wants to open the column editor for the selected table
		/// </summary>
		public event EventHandler OpenColumnEditor;

		#endregion

		#region Properties

		/// <summary>
		/// Last RowState of the current row
		/// </summary>
		private DataRowState _lastDataRowState = DataRowState.Unchanged;
		private DataRowState LastDataRowState 
		{
			get
			{
				return _lastDataRowState;
			}
			set
			{
				_lastDataRowState = value;
			}
		}

		private string _tableName;
		/// <summary>
		/// The currently selected table or null if none is selected
		/// </summary>
		public string SelectedTableName
		{
			get
			{
				return _tableName;
			}
			set
			{
				_tableName = value;
			}
		}

		#endregion

		#region Events

		private void tcTables_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
		{
			if (tabControlSearch.SelectedTabIndex == 0) 
			{
				// list
				RunSearch();
				this.kccSubContainer.Visible = ( this.qryXTable.Count > 0 );
			} 
			else 
			{
				// search
				this.kccSubContainer.Visible = false;
			}
		}

		private void qryXTable_BeforeDeleteQuestion(object sender, System.EventArgs e)
		{
			ValidateInputControls();

			// set last datarowstate of current row
			this.LastDataRowState = qryXTable.Row.RowState;
			
			if( (bool)qryXTable.Row["System"] )
			{
				throw new KissErrorException( "Systemtabellen dürfen nicht gelöscht werden." );
			}
		}
		
		private void qryXTable_BeforeDelete(object sender, System.EventArgs e)
		{			
			// check if not a new column
			if( !LastDataRowState.Equals( DataRowState.Added ) ) 
			{
				// delete the columns of this table in XTableColumns, because their ForeignKey links prevent the deletion
				DeleteColumnEntriesOfTable( qryXTable["TableName"].ToString() );
			}
		}

		private void qryXTable_AfterDelete(object sender, System.EventArgs e)
		{
			// check if not a new column
			if( !LastDataRowState.Equals( DataRowState.Added ) ) 
			{
				// delete tables on database (first history because of trigger)
				DeleteTableWithHistory( qryXTable.Row["TableName"].ToString() );
		
				// refresh tree due to deleted table
				RefreshParentFormTree();
			}
		}

		private void qryXTable_BeforePost(object sender, System.EventArgs e)
		{
			ValidateInputControls();
			
			DBUtil.CheckNotNullField(this.txtTableName, this.lblTableName.Text);

			// set last datarowstate of current row
			this.LastDataRowState = qryXTable.Row.RowState;
		}

		private void qryXTable_AfterPost(object sender, System.EventArgs e)
		{
			// check if row was added or modified by user
			if( this.LastDataRowState.Equals( DataRowState.Added ) )
			{
				// new table, create it physically
				string sqlStatement = string.Format( @"CREATE TABLE [{0}] ([{0}ID] [int] IDENTITY (1, 1) NOT NULL, 
														CONSTRAINT [PK_{0}] PRIMARY KEY
														(
															[{0}ID]
														) ON [PRIMARY]) ON [PRIMARY]", qryXTable.Row["TableName"] );
				DBUtil.ExecSQL( sqlStatement );

				// insert its primary key row to XTableColumn as system-col (fieldcode is 3 == int)
				sqlStatement = string.Format( @"INSERT INTO XTableColumn 
												(TableName, ColumnName, FieldCode, DisplayText, LOVName, System) 
												VALUES ('{0}', '{0}ID', 3, NULL, NULL, 1)", qryXTable.Row["TableName"] );
				DBUtil.ExecSQL( sqlStatement );

				// refresh tree due to new table
				RefreshParentFormTree();
			} 
			else if( this.LastDataRowState.Equals( DataRowState.Modified ) )
			{		
				// modified table
				if( !chkHistory.Checked )
				{
					string historyTableName = string.Format( "Hist_{0}", qryXTable.Row["TableName"].ToString() );
					if ( ExistsTable( historyTableName ) )
					{
						// ask user if he really wants to delete the history table
						bool deleteHistoryTable = true;
						try
						{
							if( XTableColumnDBHandler.GetRowCount( historyTableName ) > 0 )
							{
								deleteHistoryTable = KissMsg.ShowQuestion( "CtlTableEditor", "ConfirmDeleteHistoryTable", string.Format( "Wollen Sie wirklich die gesammte Verlaufs-Tabelle '{0}' und die darin enthaltenen Daten löschen?", historyTableName ), false );
							}
							if( deleteHistoryTable )
							{
								DeleteHistoryTable( qryXTable.Row["TableName"].ToString() );
							}
							else
							{
								this.chkHistory.Checked = true;
							}
						}
						catch( KissErrorException ex )
						{
							KissMsg.ShowError( "CtlTableEditor", "AfterPostRowCountFailed", string.Format( "Beim Zählen der Anzahl Datensätze der Tabelle '{0}' ist ein Fehler aufgetreten", historyTableName ), ex );
						}
					}
				}				
			}

			if ( chkHistory.Checked ) 
			{
				// create history table and triggers
				DBUtil.ExecSQL( @"EXECUTE dbo.spXHistoryVersion {0}, 1", qryXTable.Row["TableName"] );
			}
			
			// set new table name to property
			SelectedTableName = qryXTable["TableName"] as string;

			// reset controls
			this.txtTableName.EditMode = EditModeType.ReadOnly;
			this.qryXTable.EnableBoundFields();
		}

		private void qryXTable_AfterInsert(object sender, System.EventArgs e)
		{			
			this.qryXTable["ModulID"] = this.ModulID;
			
			this.kccSubContainer.Visible = true;

			this.txtTableName.EditMode = EditModeType.Normal;
			this.qryXTable.EnableBoundFields();

			this.txtTableName.Focus();
		}

		private void qryXTable_PositionChanged(object sender, System.EventArgs e)
		{
			// set new table name to parent form
			SelectedTableName = qryXTable["TableName"] as string;

			this.chkHistory.Checked = HasTableHistoryTable( qryXTable["TableName"] as string );
			if (qryXTable.Row != null && qryXTable.Row.RowState != DataRowState.Added)
			{
				this.txtTableName.EditMode = EditModeType.ReadOnly;
				this.qryXTable.EnableBoundFields();

				// RowModified is set to true if the selected data row has a different history state than the last row, so reset the state
				qryXTable.RowModified = false;
			}
		}

		private void chkHistory_CheckedChanged(object sender, System.EventArgs e)
		{
			qryXTable.RowModified = true;
		}

		private void btnEditColumns_Click(object sender, System.EventArgs e)
		{
			if( OpenColumnEditor != null )
			{
				OpenColumnEditor( this, null );
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Refresh tree of parentform FrmDesigner
		/// </summary>
		private void RefreshParentFormTree()
		{
			FormController.SendMessage("FrmDesigner", "Action", "RefreshTree");
		}
		
		/// <summary>
		/// Try to reselect table in query and datagrid
		/// </summary>
		/// <param name="tableName"></param>
		public void SelectTable( string tableName )
		{
			// if a table has been selected before, try to reselect it
			if( qryXTable.Count > 0  && tableName != string.Empty )
			{
				bool foundTable = false;	
				qryXTable.First();
				do
				{					
					if( qryXTable["TableName"].ToString() == tableName )
					{
						// iterator points to the row of the table 'tableName', break
						foundTable = true;
						break;
					}
				}
				while( qryXTable.Next() );

				// if the table could not be found, select the first
				if( !foundTable )
				{
					qryXTable.First();
				}
			}

			// init default first row
			qryXTable_PositionChanged(null, null);
		}

		/// <summary>
		/// Check if a history table exists for current table
		/// </summary>
		/// <returns></returns>
		internal static bool HasTableHistoryTable( string tableName )
		{
			return ExistsTable( string.Format( "Hist_{0}", tableName ) );
		}

		/// <summary>
		/// Check if table exists physically on database
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		internal static bool ExistsTable( string tableName )
		{
			//check if table exists
			string strSqlCheckIfTableExists = string.Format( @"SELECT Name
															   FROM   sysobjects
															   WHERE  (xtype = 'u') AND (name = '{0}')", tableName );
			SqlQuery qryTableExists = new SqlQuery();
			qryTableExists.Fill(strSqlCheckIfTableExists);

			return qryTableExists.Count > 0;
		}

		/// <summary>
		/// Fill grid table depending on search criterias
		/// </summary>
		protected override void RunSearch()
		{
			string sqlStatement = @"SELECT *
									FROM   XTable
									WHERE  1 = 1 ";

			// TableName
			if ( txtSearchTable.Text != "" )
				sqlStatement += " AND TableName like " + DBUtil.SqlLiteralLike( "%" + txtSearchTable.Text + "%" );

			// System
			if ( !DBUtil.IsEmpty( chkSearchSystem.EditValue ) )
				sqlStatement += " and System = " + DBUtil.SqlLiteralLike( chkSearchSystem.EditValue );

			// Alias
			if ( txtSearchAlias.Text != "" )
				sqlStatement += " and Alias like " + DBUtil.SqlLiteralLike( txtSearchAlias.Text + "%" );

			// Modul
			if ( !DBUtil.IsEmpty( cboSearchModulID.EditValue ) )
				sqlStatement += " and ModulID = " + DBUtil.SqlLiteralLike( cboSearchModulID.EditValue );

			this.qryXTable.Fill( sqlStatement );

			tabControlSearch.SelectedTabIndex = 0;
			grdXTable.Focus(); 
			Cursor.Current = Cursors.Default;
		}

		/// <summary>
		/// Initialize a new search
		/// </summary>
		protected override void NewSearch()
		{
			base.NewSearch ();

			txtSearchTable.Focus();
		}

		/// <summary>
		/// Delete history table and trigger if history table exists
		/// </summary>
		/// <param name="tableName"></param>
		private void DeleteHistoryTable(string tableName)
		{
			if ( ExistsTable( string.Format( "Hist_{0}", tableName ) ) )
			{
				DeleteTable( string.Format( @"Hist_{0}", tableName ) );
				DBUtil.ExecSQL( string.Format( @"DROP TRIGGER [trHist_{0}]", tableName ) );
			}
		}

		/// <summary>
		/// Delete history table and trigger if history table exists
		/// </summary>
		/// <param name="tableName"></param>
		private void DeleteTableWithHistory(string tableName)
		{
			DeleteHistoryTable( tableName );
			DeleteTable( tableName );
		}

		/// <summary>
		/// Delete a table
		/// </summary>
		/// <param name="tableName"></param>
		private void DeleteTable( string tableName )
		{
			DBUtil.ExecSQL( string.Format( "DROP TABLE [{0}]", tableName ) );
		}

		/// <summary>
		/// Delete the rows in XTableColumn that belong to the specified table
		/// </summary>
		/// <param name="tableName"></param>
		private void DeleteColumnEntriesOfTable( string tableName )
		{
			DBUtil.ExecSQL( @"DELETE FROM XTableColumn WHERE TableName={0}", tableName );
		}

		/// <summary>
		/// Delete the rows in XTableColumn and XTable that belong to the specified table
		/// </summary>
		/// <param name="tableName"></param>
		private void DeleteTableEntries( string tableName )
		{
			DeleteColumnEntriesOfTable( tableName );
			DBUtil.ExecSQL( @"DELETE FROM XTable WHERE TableName={0}", tableName );
		}

		/// <summary>
		/// Validate input controls and apply current (changed) value
		/// </summary>
		private void ValidateInputControls()
		{
			this.txtTableName.DoValidate();
			this.chkSystem.DoValidate();
			this.txtAlias.DoValidate();
			this.cboModulID.DoValidate();
			this.chkHistory.DoValidate();
			this.chkDataWareHouse.DoValidate();
			this.editComment.DoValidate();
		}

		#endregion
	}
}
