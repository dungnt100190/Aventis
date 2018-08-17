using System.Data;
using KiSS4.DB;

namespace KiSS4.DesignerHost
{
	/// <summary>
	/// Summary description for CtlTableForeignKeysEditor.
	/// </summary>
	public class CtlTableForeignKeysEditor : KiSS4.Gui.KissUserControl
	{
		#region Variables

		private System.ComponentModel.IContainer components;
		private KiSS4.DB.SqlQuery qryXForeignKeys;
		private KiSS4.Gui.KissGrid gridTableIndices;
		private DevExpress.XtraGrid.Views.Grid.GridView gvViewList;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
		private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit1;
		private DevExpress.XtraGrid.Columns.GridColumn colForeignKeyName;
		private DevExpress.XtraGrid.Columns.GridColumn colPrimaryKeyTable;
		private DevExpress.XtraGrid.Columns.GridColumn colPrimaryKeyColumnList;
		private DevExpress.XtraEditors.PopupContainerControl edtContainerFKColumns;
		private KiSS4.Gui.KissCheckedLookupEdit edtSelectFKColumns;
		private DevExpress.XtraEditors.PopupContainerControl edtContainerPKColumns;
		private KiSS4.Gui.KissCheckedLookupEdit edtSelectPKColumns;
		private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit2;
		private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit3;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
		private DevExpress.XtraGrid.Columns.GridColumn colForeignKeyColumnList;

		#endregion

		#region Constructor / Dispose

		public CtlTableForeignKeysEditor()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			SqlQuery qryTables = DBUtil.OpenSQL( @"
				  SELECT Text = name, Code = name
				  FROM sysobjects
				  WHERE xtype = 'U' 
			       AND name not like 'x%' 
              ORDER BY name" );
			this.repositoryItemLookUpEdit1.DataSource = qryTables;
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
			this.qryXForeignKeys = new KiSS4.DB.SqlQuery(this.components);
			this.gridTableIndices = new KiSS4.Gui.KissGrid();
			this.gvViewList = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colForeignKeyName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPrimaryKeyTable = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			this.colPrimaryKeyColumnList = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemPopupContainerEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
			this.edtContainerPKColumns = new DevExpress.XtraEditors.PopupContainerControl();
			this.edtSelectPKColumns = new KiSS4.Gui.KissCheckedLookupEdit();
			this.colForeignKeyColumnList = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemPopupContainerEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
			this.edtContainerFKColumns = new DevExpress.XtraEditors.PopupContainerControl();
			this.edtSelectFKColumns = new KiSS4.Gui.KissCheckedLookupEdit();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.repositoryItemPopupContainerEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
			((System.ComponentModel.ISupportInitialize)(this.qryXForeignKeys)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridTableIndices)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvViewList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.edtContainerPKColumns)).BeginInit();
			this.edtContainerPKColumns.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.edtSelectPKColumns)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.edtContainerFKColumns)).BeginInit();
			this.edtContainerFKColumns.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.edtSelectFKColumns)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit3)).BeginInit();
			this.SuspendLayout();
			// 
			// qryXForeignKeys
			// 
			this.qryXForeignKeys.CanDelete = true;
			this.qryXForeignKeys.CanInsert = true;
			this.qryXForeignKeys.CanUpdate = true;
			this.qryXForeignKeys.HostControl = this;
			this.qryXForeignKeys.BeforeDelete += new System.EventHandler(this.qryXForeignKeys_BeforeDelete);
			this.qryXForeignKeys.BeforeDeleteQuestion += new System.EventHandler(this.qryXForeignKeys_BeforeDeleteQuestion);
			this.qryXForeignKeys.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryXForeignKeys_ColumnChanged);
			this.qryXForeignKeys.BeforePost += new System.EventHandler(this.qryXForeignKeys_BeforePost);
			this.qryXForeignKeys.AfterInsert += new System.EventHandler(this.qryXForeignKeys_AfterInsert);
			// 
			// gridTableIndices
			// 
			this.gridTableIndices.DataSource = this.qryXForeignKeys;
			this.gridTableIndices.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// gridTableIndices.EmbeddedNavigator
			// 
			this.gridTableIndices.EmbeddedNavigator.Name = "";
			this.gridTableIndices.GridStyle = KiSS4.Gui.GridStyleType.Editable;
			this.gridTableIndices.Location = new System.Drawing.Point(0, 0);
			this.gridTableIndices.MainView = this.gvViewList;
			this.gridTableIndices.Name = "gridTableIndices";
			this.gridTableIndices.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																																						this.repositoryItemCheckEdit1,
																																						this.repositoryItemCheckEdit2,
																																						this.repositoryItemCheckEdit3,
																																						this.repositoryItemPopupContainerEdit1,
																																						this.repositoryItemPopupContainerEdit2,
																																						this.repositoryItemPopupContainerEdit3,
																																						this.repositoryItemLookUpEdit1});
			this.gridTableIndices.Size = new System.Drawing.Size(744, 520);
			this.gridTableIndices.TabIndex = 3;
			this.gridTableIndices.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
																																		  this.gvViewList});
			// 
			// gvViewList
			// 
			this.gvViewList.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
			this.gvViewList.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gvViewList.Appearance.Empty.Options.UseBackColor = true;
			this.gvViewList.Appearance.Empty.Options.UseFont = true;
			this.gvViewList.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(236)), ((System.Byte)(227)), ((System.Byte)(215)));
			this.gvViewList.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gvViewList.Appearance.EvenRow.Options.UseBackColor = true;
			this.gvViewList.Appearance.EvenRow.Options.UseFont = true;
			this.gvViewList.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
			this.gvViewList.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gvViewList.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
			this.gvViewList.Appearance.FocusedCell.Options.UseBackColor = true;
			this.gvViewList.Appearance.FocusedCell.Options.UseFont = true;
			this.gvViewList.Appearance.FocusedCell.Options.UseForeColor = true;
			this.gvViewList.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
			this.gvViewList.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gvViewList.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
			this.gvViewList.Appearance.FocusedRow.Options.UseBackColor = true;
			this.gvViewList.Appearance.FocusedRow.Options.UseFont = true;
			this.gvViewList.Appearance.FocusedRow.Options.UseForeColor = true;
			this.gvViewList.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
			this.gvViewList.Appearance.GroupPanel.Options.UseBackColor = true;
			this.gvViewList.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
			this.gvViewList.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.gvViewList.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.gvViewList.Appearance.GroupRow.Options.UseBackColor = true;
			this.gvViewList.Appearance.GroupRow.Options.UseFont = true;
			this.gvViewList.Appearance.GroupRow.Options.UseForeColor = true;
			this.gvViewList.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
			this.gvViewList.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
			this.gvViewList.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0)));
			this.gvViewList.Appearance.HeaderPanel.Options.UseBackColor = true;
			this.gvViewList.Appearance.HeaderPanel.Options.UseBorderColor = true;
			this.gvViewList.Appearance.HeaderPanel.Options.UseFont = true;
			this.gvViewList.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
			this.gvViewList.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gvViewList.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.gvViewList.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.gvViewList.Appearance.HideSelectionRow.Options.UseFont = true;
			this.gvViewList.Appearance.HideSelectionRow.Options.UseForeColor = true;
			this.gvViewList.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gvViewList.Appearance.OddRow.Options.UseFont = true;
			this.gvViewList.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
			this.gvViewList.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gvViewList.Appearance.Row.Options.UseBackColor = true;
			this.gvViewList.Appearance.Row.Options.UseFont = true;
			this.gvViewList.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
			this.gvViewList.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.gvViewList.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
			this.gvViewList.Appearance.SelectedRow.Options.UseBackColor = true;
			this.gvViewList.Appearance.SelectedRow.Options.UseFont = true;
			this.gvViewList.Appearance.SelectedRow.Options.UseForeColor = true;
			this.gvViewList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.gvViewList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																														this.colForeignKeyName,
																														this.colPrimaryKeyTable,
																														this.colPrimaryKeyColumnList,
																														this.colForeignKeyColumnList});
			this.gvViewList.GridControl = this.gridTableIndices;
			this.gvViewList.Name = "gvViewList";
			this.gvViewList.OptionsCustomization.AllowFilter = false;
			this.gvViewList.OptionsFilter.UseNewCustomFilterDialog = true;
			this.gvViewList.OptionsNavigation.AutoFocusNewRow = true;
			this.gvViewList.OptionsView.ColumnAutoWidth = false;
			this.gvViewList.OptionsView.ShowGroupPanel = false;
			// 
			// colForeignKeyName
			// 
			this.colForeignKeyName.Caption = "Name Fremdschlüssel";
			this.colForeignKeyName.FieldName = "ForeignKeyName";
			this.colForeignKeyName.Name = "colForeignKeyName";
			this.colForeignKeyName.Visible = true;
			this.colForeignKeyName.VisibleIndex = 0;
			this.colForeignKeyName.Width = 143;
			// 
			// colPrimaryKeyTable
			// 
			this.colPrimaryKeyTable.Caption = "PK Tabelle";
			this.colPrimaryKeyTable.ColumnEdit = this.repositoryItemLookUpEdit1;
			this.colPrimaryKeyTable.FieldName = "PKTable";
			this.colPrimaryKeyTable.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
			this.colPrimaryKeyTable.Name = "colPrimaryKeyTable";
			this.colPrimaryKeyTable.Visible = true;
			this.colPrimaryKeyTable.VisibleIndex = 1;
			this.colPrimaryKeyTable.Width = 110;
			// 
			// repositoryItemLookUpEdit1
			// 
			this.repositoryItemLookUpEdit1.AutoHeight = false;
			this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																					new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
																																						 new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
			this.repositoryItemLookUpEdit1.DisplayMember = "Text";
			this.repositoryItemLookUpEdit1.DropDownRows = 12;
			this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
			this.repositoryItemLookUpEdit1.PopupWidth = 200;
			this.repositoryItemLookUpEdit1.ValueMember = "Code";
			// 
			// colPrimaryKeyColumnList
			// 
			this.colPrimaryKeyColumnList.Caption = "PK Kolonnenliste";
			this.colPrimaryKeyColumnList.ColumnEdit = this.repositoryItemPopupContainerEdit1;
			this.colPrimaryKeyColumnList.FieldName = "PKColumns";
			this.colPrimaryKeyColumnList.Name = "colPrimaryKeyColumnList";
			this.colPrimaryKeyColumnList.Visible = true;
			this.colPrimaryKeyColumnList.VisibleIndex = 2;
			this.colPrimaryKeyColumnList.Width = 157;
			// 
			// repositoryItemPopupContainerEdit1
			// 
			this.repositoryItemPopupContainerEdit1.AutoHeight = false;
			this.repositoryItemPopupContainerEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																							  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemPopupContainerEdit1.Name = "repositoryItemPopupContainerEdit1";
			this.repositoryItemPopupContainerEdit1.PopupControl = this.edtContainerPKColumns;
			this.repositoryItemPopupContainerEdit1.Popup += new System.EventHandler(this.repositoryItemPopupContainerEdit1_Popup);
			this.repositoryItemPopupContainerEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.repositoryItemPopupContainerEdit1_Closed);
			// 
			// edtContainerPKColumns
			// 
			this.edtContainerPKColumns.Controls.Add(this.edtSelectPKColumns);
			this.edtContainerPKColumns.DockPadding.All = 2;
			this.edtContainerPKColumns.Location = new System.Drawing.Point(328, 192);
			this.edtContainerPKColumns.Name = "edtContainerPKColumns";
			this.edtContainerPKColumns.Size = new System.Drawing.Size(152, 168);
			this.edtContainerPKColumns.TabIndex = 5;
			this.edtContainerPKColumns.Text = "popupContainerControl2";
			// 
			// edtSelectPKColumns
			// 
			this.edtSelectPKColumns.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(245)), ((System.Byte)(241)));
			this.edtSelectPKColumns.Appearance.Options.UseBackColor = true;
			this.edtSelectPKColumns.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.edtSelectPKColumns.CheckOnClick = true;
			this.edtSelectPKColumns.DisplayMember = "Text";
			this.edtSelectPKColumns.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edtSelectPKColumns.Location = new System.Drawing.Point(2, 2);
			this.edtSelectPKColumns.Name = "edtSelectPKColumns";
			this.edtSelectPKColumns.Size = new System.Drawing.Size(148, 164);
			this.edtSelectPKColumns.TabIndex = 2;
			this.edtSelectPKColumns.ValueMember = "Text";
			// 
			// colForeignKeyColumnList
			// 
			this.colForeignKeyColumnList.Caption = "FK Spaltenliste";
			this.colForeignKeyColumnList.ColumnEdit = this.repositoryItemPopupContainerEdit2;
			this.colForeignKeyColumnList.FieldName = "FKColumns";
			this.colForeignKeyColumnList.Name = "colForeignKeyColumnList";
			this.colForeignKeyColumnList.Visible = true;
			this.colForeignKeyColumnList.VisibleIndex = 3;
			this.colForeignKeyColumnList.Width = 176;
			// 
			// repositoryItemPopupContainerEdit2
			// 
			this.repositoryItemPopupContainerEdit2.AutoHeight = false;
			this.repositoryItemPopupContainerEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																							  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemPopupContainerEdit2.Name = "repositoryItemPopupContainerEdit2";
			this.repositoryItemPopupContainerEdit2.PopupControl = this.edtContainerFKColumns;
			this.repositoryItemPopupContainerEdit2.Popup += new System.EventHandler(this.repositoryItemPopupContainerEdit2_Popup);
			this.repositoryItemPopupContainerEdit2.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.repositoryItemPopupContainerEdit2_Closed);
			// 
			// edtContainerFKColumns
			// 
			this.edtContainerFKColumns.Controls.Add(this.edtSelectFKColumns);
			this.edtContainerFKColumns.DockPadding.All = 2;
			this.edtContainerFKColumns.Location = new System.Drawing.Point(488, 192);
			this.edtContainerFKColumns.Name = "edtContainerFKColumns";
			this.edtContainerFKColumns.Size = new System.Drawing.Size(152, 168);
			this.edtContainerFKColumns.TabIndex = 4;
			this.edtContainerFKColumns.Text = "popupContainerControl1";
			// 
			// edtSelectFKColumns
			// 
			this.edtSelectFKColumns.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(245)), ((System.Byte)(241)));
			this.edtSelectFKColumns.Appearance.Options.UseBackColor = true;
			this.edtSelectFKColumns.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.edtSelectFKColumns.CheckOnClick = true;
			this.edtSelectFKColumns.DisplayMember = "Text";
			this.edtSelectFKColumns.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edtSelectFKColumns.Location = new System.Drawing.Point(2, 2);
			this.edtSelectFKColumns.Name = "edtSelectFKColumns";
			this.edtSelectFKColumns.Size = new System.Drawing.Size(148, 164);
			this.edtSelectFKColumns.TabIndex = 2;
			this.edtSelectFKColumns.ValueMember = "Text";
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
			// 
			// repositoryItemCheckEdit2
			// 
			this.repositoryItemCheckEdit2.AutoHeight = false;
			this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
			// 
			// repositoryItemCheckEdit3
			// 
			this.repositoryItemCheckEdit3.AutoHeight = false;
			this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
			// 
			// repositoryItemPopupContainerEdit3
			// 
			this.repositoryItemPopupContainerEdit3.AutoHeight = false;
			this.repositoryItemPopupContainerEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																							  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemPopupContainerEdit3.Name = "repositoryItemPopupContainerEdit3";
			// 
			// CtlTableForeignKeysEditor
			// 
			this.ActiveSQLQuery = this.qryXForeignKeys;
			this.Controls.Add(this.edtContainerPKColumns);
			this.Controls.Add(this.edtContainerFKColumns);
			this.Controls.Add(this.gridTableIndices);
			this.Name = "CtlTableForeignKeysEditor";
			this.Size = new System.Drawing.Size(744, 520);
			((System.ComponentModel.ISupportInitialize)(this.qryXForeignKeys)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridTableIndices)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvViewList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.edtContainerPKColumns)).EndInit();
			this.edtContainerPKColumns.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.edtSelectPKColumns)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.edtContainerFKColumns)).EndInit();
			this.edtContainerFKColumns.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.edtSelectFKColumns)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit3)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties

		private string _currentTableName;

		public string CurrentTableName
		{
			get
			{
				return _currentTableName;
			}
			set
			{
				_currentTableName = value;
				FillSqlQuery();
				edtSelectFKColumns.LookupSQL = string.Format( @"
				  SELECT Text = name, Code = name
				  FROM syscolumns
				  WHERE id = object_id('{0}')
				  ORDER BY colorder", value );
			}
		}

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

		#endregion

		#region Methods

		private void FillSqlQuery()
		{
			qryXForeignKeys.Fill( @"
			  SELECT *
			  FROM XViewForeignKeys
			  WHERE FKTable = {0}", this.CurrentTableName );
			gridTableIndices.Focus();
		}

		private void updateForeignKeyName()
		{
			qryXForeignKeys["ForeignKeyName"] = string.Format( "FK_{0}_{1}", this.CurrentTableName, qryXForeignKeys["PKTable"] is string ? qryXForeignKeys["PKTable"] as string : "" );
		}


		#endregion

		#region Eventhandler
		
		#region Insert

		private void qryXForeignKeys_AfterInsert( object sender, System.EventArgs e )
		{
			// setup default values and editmodes
			this.qryXForeignKeys["ForeignKeyName"] = string.Format( "PK_{0}", CurrentTableName );

			// try to set the first column as default used column
			string firstColumn = XTableColumnDBHandler.GetFirstColumnOfTable( CurrentTableName );
			this.qryXForeignKeys["FKColumns"] = firstColumn != null ? firstColumn : "";
			qryXForeignKeys.RowModified = true;		
		}

		#endregion

		#region Post

		private void qryXForeignKeys_BeforePost(object sender, System.EventArgs e)
		{
			if( qryXForeignKeys.Row.RowState == DataRowState.Added )
			{
				XTableColumnDBHandler.CreateForeignKey( (string)qryXForeignKeys["ForeignKeyName"],
				                                        (string)qryXForeignKeys["PKTable"],
				                                        (string)qryXForeignKeys["PKColumns"],
				                                        this.CurrentTableName,
				                                        (string)qryXForeignKeys["FKColumns"] );
			} 
			else if( qryXForeignKeys.Row.RowState == DataRowState.Modified )
			{
				XTableColumnDBHandler.ModifyForeignKey( (string)qryXForeignKeys["ForeignKeyName",DataRowVersion.Original],
				                                        (string)qryXForeignKeys["PKTable",DataRowVersion.Original],
				                                        (string)qryXForeignKeys["PKColumns",DataRowVersion.Original],
				                                        this.CurrentTableName,
				                                        (string)qryXForeignKeys["FKColumns",DataRowVersion.Original],
				                                        (string)qryXForeignKeys["ForeignKeyName"],
				                                        (string)qryXForeignKeys["PKTable"],
				                                        (string)qryXForeignKeys["PKColumns"],
				                                        (string)qryXForeignKeys["FKColumns"] );
			}
			FillSqlQuery();
			// Prevent SQLQuery from trying to post the row to the View (what would result in an error)
			throw new KissCancelException();
		}

		#endregion

		#region Delete

		private void qryXForeignKeys_BeforeDeleteQuestion(object sender, System.EventArgs e)
		{
			// set last datarowstate of current row
			LastDataRowState = qryXForeignKeys.Row.RowState;
		}

		private void qryXForeignKeys_BeforeDelete(object sender, System.EventArgs e)
		{
			// check if not a new column
			if( LastDataRowState != DataRowState.Added )
			{
				XTableColumnDBHandler.DeleteForeignKey( this.CurrentTableName,
				                                       (string)qryXForeignKeys["ForeignKeyName"] );
			}
			FillSqlQuery();
			// Prevent SQLQuery from trying to delete the row from the View (what would result in an error)
			throw new KissCancelException();
		}

		#endregion

		#region 'Select Columns' Popup

		private void repositoryItemPopupContainerEdit1_Popup(object sender, System.EventArgs e)
		{
			string foreignTableName = qryXForeignKeys["PKTable"] as string;
			if( foreignTableName != null )
			{
				edtSelectPKColumns.LookupSQL = string.Format( @"
				  SELECT Text = name, Code = name
				  FROM syscolumns
				  WHERE id = object_id('{0}')
				  ORDER BY colorder", foreignTableName );

				edtSelectPKColumns.EditValue = qryXForeignKeys["PKColumns"] is string ? ((string)qryXForeignKeys["PKColumns"]).Replace(", ", "," ) : "";
			}
		}

		private void repositoryItemPopupContainerEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
		{
			qryXForeignKeys["PKColumns"] = edtSelectPKColumns.EditValue as string;
		}


		private void repositoryItemPopupContainerEdit2_Popup(object sender, System.EventArgs e)
		{
			edtSelectFKColumns.EditValue = qryXForeignKeys["FKColumns"] is string ? ((string)qryXForeignKeys["FKColumns"]).Replace(", ", "," ) : "";
		}

		private void repositoryItemPopupContainerEdit2_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
		{
			qryXForeignKeys["FKColumns"] = edtSelectFKColumns.EditValue as string;
		}

		#endregion

		
		/// <summary>
		/// Eventhandler: the content of the cell has been changed
		/// If the primary key table has changed, we reassemble the foreign key name
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void qryXForeignKeys_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
		{
			if( e.Column.ColumnName == "PKTable" )
			{
				updateForeignKeyName();
			}
		}

		#endregion

	}
}
