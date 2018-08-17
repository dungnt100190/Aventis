using System.Data;
using KiSS4.DB;

namespace KiSS4.DesignerHost
{
	/// <summary>
	/// Summary description for CtlTableIndicesEditor.
	/// </summary>
	public class CtlTableIndicesEditor : KiSS4.Gui.KissUserControl
	{
		#region Variables

		private KiSS4.DB.SqlQuery qryXIndex;
		private DevExpress.XtraGrid.Views.Grid.GridView gvViewList;
		private DevExpress.XtraGrid.Columns.GridColumn colName;
		private DevExpress.XtraGrid.Columns.GridColumn colPrimaryKey;
		private DevExpress.XtraGrid.Columns.GridColumn colUnique;
		private DevExpress.XtraGrid.Columns.GridColumn colClustered;
		private DevExpress.XtraGrid.Columns.GridColumn colTableColumns;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
		private KiSS4.Gui.KissGrid gridTableIndices;
		private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit1;
		private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
		private KiSS4.Gui.KissCheckedLookupEdit edtSelectColumns;
		private System.ComponentModel.IContainer components;

		#endregion

		#region Constructor / Dispose
		
		public CtlTableIndicesEditor()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
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
			this.qryXIndex = new KiSS4.DB.SqlQuery(this.components);
			this.gridTableIndices = new KiSS4.Gui.KissGrid();
			this.gvViewList = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPrimaryKey = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.colUnique = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.colClustered = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.colTableColumns = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemPopupContainerEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
			this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
			this.edtSelectColumns = new KiSS4.Gui.KissCheckedLookupEdit();
			((System.ComponentModel.ISupportInitialize)(this.qryXIndex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridTableIndices)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvViewList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
			this.popupContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.edtSelectColumns)).BeginInit();
			this.SuspendLayout();
			// 
			// qryXIndex
			// 
			this.qryXIndex.CanDelete = true;
			this.qryXIndex.CanInsert = true;
			this.qryXIndex.CanUpdate = true;
			this.qryXIndex.HostControl = this;
			this.qryXIndex.BeforeDelete += new System.EventHandler(this.qryXIndex_BeforeDelete);
			this.qryXIndex.BeforeDeleteQuestion += new System.EventHandler(this.qryXIndex_BeforeDeleteQuestion);
			this.qryXIndex.BeforePost += new System.EventHandler(this.qryXIndex_BeforePost);
			this.qryXIndex.AfterInsert += new System.EventHandler(this.qryXIndex_AfterInsert);
			// 
			// gridTableIndices
			// 
			this.gridTableIndices.DataSource = this.qryXIndex;
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
																																						this.repositoryItemPopupContainerEdit1});
			this.gridTableIndices.Size = new System.Drawing.Size(928, 504);
			this.gridTableIndices.TabIndex = 0;
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
																														this.colName,
																														this.colPrimaryKey,
																														this.colUnique,
																														this.colClustered,
																														this.colTableColumns});
			this.gvViewList.GridControl = this.gridTableIndices;
			this.gvViewList.Name = "gvViewList";
			this.gvViewList.OptionsCustomization.AllowFilter = false;
			this.gvViewList.OptionsFilter.UseNewCustomFilterDialog = true;
			this.gvViewList.OptionsNavigation.AutoFocusNewRow = true;
			this.gvViewList.OptionsView.ColumnAutoWidth = false;
			this.gvViewList.OptionsView.ShowGroupPanel = false;
			// 
			// colName
			// 
			this.colName.Caption = "Indexname";
			this.colName.FieldName = "IndexName";
			this.colName.Name = "colName";
			this.colName.Visible = true;
			this.colName.VisibleIndex = 0;
			this.colName.Width = 143;
			// 
			// colPrimaryKey
			// 
			this.colPrimaryKey.Caption = "Primary Key";
			this.colPrimaryKey.ColumnEdit = this.repositoryItemCheckEdit1;
			this.colPrimaryKey.FieldName = "PrimaryKey";
			this.colPrimaryKey.Name = "colPrimaryKey";
			this.colPrimaryKey.Visible = true;
			this.colPrimaryKey.VisibleIndex = 1;
			this.colPrimaryKey.Width = 78;
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
			// 
			// colUnique
			// 
			this.colUnique.Caption = "Unique";
			this.colUnique.ColumnEdit = this.repositoryItemCheckEdit2;
			this.colUnique.FieldName = "Unique";
			this.colUnique.Name = "colUnique";
			this.colUnique.Visible = true;
			this.colUnique.VisibleIndex = 2;
			this.colUnique.Width = 50;
			// 
			// repositoryItemCheckEdit2
			// 
			this.repositoryItemCheckEdit2.AutoHeight = false;
			this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
			// 
			// colClustered
			// 
			this.colClustered.Caption = "Clustered";
			this.colClustered.ColumnEdit = this.repositoryItemCheckEdit3;
			this.colClustered.FieldName = "Clustered";
			this.colClustered.Name = "colClustered";
			this.colClustered.Visible = true;
			this.colClustered.VisibleIndex = 3;
			this.colClustered.Width = 67;
			// 
			// repositoryItemCheckEdit3
			// 
			this.repositoryItemCheckEdit3.AutoHeight = false;
			this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
			// 
			// colTableColumns
			// 
			this.colTableColumns.Caption = "Spaltenliste";
			this.colTableColumns.ColumnEdit = this.repositoryItemPopupContainerEdit1;
			this.colTableColumns.FieldName = "Keys";
			this.colTableColumns.Name = "colTableColumns";
			this.colTableColumns.Visible = true;
			this.colTableColumns.VisibleIndex = 4;
			this.colTableColumns.Width = 175;
			// 
			// repositoryItemPopupContainerEdit1
			// 
			this.repositoryItemPopupContainerEdit1.AutoHeight = false;
			this.repositoryItemPopupContainerEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
																																							  new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemPopupContainerEdit1.Name = "repositoryItemPopupContainerEdit1";
			this.repositoryItemPopupContainerEdit1.PopupControl = this.popupContainerControl1;
			this.repositoryItemPopupContainerEdit1.Popup += new System.EventHandler(this.repositoryItemPopupContainerEdit1_Popup);
			this.repositoryItemPopupContainerEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.repositoryItemPopupContainerEdit1_Closed);
			// 
			// popupContainerControl1
			// 
			this.popupContainerControl1.Controls.Add(this.edtSelectColumns);
			this.popupContainerControl1.DockPadding.All = 5;
			this.popupContainerControl1.Location = new System.Drawing.Point(552, 56);
			this.popupContainerControl1.Name = "popupContainerControl1";
			this.popupContainerControl1.Size = new System.Drawing.Size(152, 120);
			this.popupContainerControl1.TabIndex = 2;
			this.popupContainerControl1.Text = "popupContainerControl1";
			// 
			// edtSelectColumns
			// 
			this.edtSelectColumns.Appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(245)), ((System.Byte)(241)));
			this.edtSelectColumns.Appearance.Options.UseBackColor = true;
			this.edtSelectColumns.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.edtSelectColumns.CheckOnClick = true;
			this.edtSelectColumns.DisplayMember = "Text";
			this.edtSelectColumns.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edtSelectColumns.Location = new System.Drawing.Point(5, 5);
			this.edtSelectColumns.Name = "edtSelectColumns";
			this.edtSelectColumns.Size = new System.Drawing.Size(142, 110);
			this.edtSelectColumns.TabIndex = 2;
			this.edtSelectColumns.ValueMember = "Text";
			// 
			// CtlTableIndicesEditor
			// 
			this.ActiveSQLQuery = this.qryXIndex;
			this.Controls.Add(this.popupContainerControl1);
			this.Controls.Add(this.gridTableIndices);
			this.Name = "CtlTableIndicesEditor";
			this.Size = new System.Drawing.Size(928, 504);
			((System.ComponentModel.ISupportInitialize)(this.qryXIndex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridTableIndices)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvViewList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
			this.popupContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.edtSelectColumns)).EndInit();
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
				edtSelectColumns.LookupSQL = string.Format( @"
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
			qryXIndex.Fill( "SELECT * FROM XViewIndex WHERE TableName = {0}", CurrentTableName );
			gridTableIndices.Focus();
		}

		#endregion

		#region Eventhandler
		
		#region Insert

		private void qryXIndex_AfterInsert( object sender, System.EventArgs e )
		{
			// setup default values and editmodes
			this.qryXIndex["IndexName"] = string.Format( "PK_{0}", this.CurrentTableName );
			this.qryXIndex["TableName"] = this.CurrentTableName;
			this.qryXIndex["PrimaryKey"] = false;
			this.qryXIndex["Unique"] = false;
			this.qryXIndex["Clustered"] = false;
			// try to set the first column as default used column
			object obj = DBUtil.ExecuteScalarSQL(  @"
				  SELECT TOP 1 [name]
              FROM syscolumns
              WHERE [id] = OBJECT_ID( {0} )
              ORDER BY colorder", this.CurrentTableName  );
			if( obj is string )
			{
				this.qryXIndex["Keys"] = obj as string;
			}
			else
			{
				this.qryXIndex["Keys"] = string.Format( "{0}ID", this.CurrentTableName );
			}
			qryXIndex.RowModified = true;		
		}

		#endregion

		#region Post

		private void qryXIndex_BeforePost(object sender, System.EventArgs e)
		{
			if( qryXIndex.Row.RowState == DataRowState.Added )
			{
				XTableColumnDBHandler.CreateIndex( (string)qryXIndex["TableName"], (string)qryXIndex["IndexName"], (bool)qryXIndex["PrimaryKey"], (bool)qryXIndex["Unique"], (bool)qryXIndex["Clustered"], (string)qryXIndex["Keys"] );
			} 
			else if( qryXIndex.Row.RowState == DataRowState.Modified )
			{
				XTableColumnDBHandler.ModifyIndex( (string)qryXIndex["TableName"], (string)qryXIndex["IndexName",DataRowVersion.Original], (bool)qryXIndex["PrimaryKey",DataRowVersion.Original], (bool)qryXIndex["Unique",DataRowVersion.Original], (bool)qryXIndex["Clustered",DataRowVersion.Original], (string)qryXIndex["Keys",DataRowVersion.Original], (string)qryXIndex["IndexName"], (bool)qryXIndex["PrimaryKey"], (bool)qryXIndex["Unique"], (bool)qryXIndex["Clustered"], (string)qryXIndex["Keys"] );
			}
			FillSqlQuery();
			// Prevent SQLQuery from trying to post the row to the View (what would result in an error)
			throw new KissCancelException();
		}

		#endregion

		#region Delete

		private void qryXIndex_BeforeDeleteQuestion(object sender, System.EventArgs e)
		{
			// set last datarowstate of current row
			LastDataRowState = qryXIndex.Row.RowState;
		}

		private void qryXIndex_BeforeDelete(object sender, System.EventArgs e)
		{
			// check if not a new column
			if( LastDataRowState != DataRowState.Added )
			{
				XTableColumnDBHandler.DeleteIndex( this.CurrentTableName, (string)qryXIndex["IndexName"], (bool)qryXIndex["PrimaryKey"] );
			}
			FillSqlQuery();
			// Prevent SQLQuery from trying to delete the row from the View (what would result in an error)
			throw new KissCancelException();
		}

		#endregion

		#region 'Select Columns' Popup
		
		private void repositoryItemPopupContainerEdit1_Popup(object sender, System.EventArgs e)
		{
			edtSelectColumns.EditValue =  ((string)qryXIndex["Keys"]).Replace(", ", "," );
		}

		private void repositoryItemPopupContainerEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
		{
			qryXIndex["Keys"] = edtSelectColumns.EditValue as string;
		}

		#endregion

		#endregion

	}
}
