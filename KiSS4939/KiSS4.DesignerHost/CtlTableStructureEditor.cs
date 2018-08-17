using System;
using System.Windows.Forms;
using KiSS4.Gui;
using Kiss.Interfaces.UI;

namespace KiSS4.DesignerHost
{
	/// <summary>
	/// Summary description for CtlTableStructureEditor.
	/// </summary>
	public class CtlTableStructureEditor : KiSS4.Gui.KissUserControl, IKissDataNavigator
	{
		#region Variables

		private KiSS4.Gui.KissTabControlEx tcTableStructure;
		private SharpLibrary.WinControls.TabPageEx tabColumns;
		private SharpLibrary.WinControls.TabPageEx tabIndices;
		private SharpLibrary.WinControls.TabPageEx tabForeignKeys;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		CtlTableColumnEditor columnEditor;
		CtlTableIndicesEditor indicesEditor;
		CtlTableForeignKeysEditor foreignKeysEditor;
		private KiSS4.Gui.KissButton btnBackToTables;
		IKissDataNavigator activeNavigator;

		#endregion

		#region Constructor / Dispose

		public CtlTableStructureEditor()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			
			columnEditor = new CtlTableColumnEditor();
			columnEditor.Parent = tabColumns;
			columnEditor.Dock = DockStyle.Fill;

			indicesEditor = new CtlTableIndicesEditor();
			indicesEditor.Parent = tabIndices;
			indicesEditor.Dock = DockStyle.Fill;

			foreignKeysEditor = new CtlTableForeignKeysEditor();
			foreignKeysEditor.Parent = tabForeignKeys;
			foreignKeysEditor.Dock = DockStyle.Fill;

			activeNavigator = columnEditor;

			// show tabColumns per default
			this.tcTableStructure.SelectedTabIndex = 0;
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
			this.tcTableStructure = new KiSS4.Gui.KissTabControlEx();
			this.tabColumns = new SharpLibrary.WinControls.TabPageEx();
			this.tabIndices = new SharpLibrary.WinControls.TabPageEx();
			this.tabForeignKeys = new SharpLibrary.WinControls.TabPageEx();
			this.btnBackToTables = new KiSS4.Gui.KissButton();
			this.tcTableStructure.SuspendLayout();
			this.SuspendLayout();
			// 
			// tcTableStructure
			// 
			this.tcTableStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tcTableStructure.Controls.Add(this.tabColumns);
			this.tcTableStructure.Controls.Add(this.tabIndices);
			this.tcTableStructure.Controls.Add(this.tabForeignKeys);
			this.tcTableStructure.Location = new System.Drawing.Point(0, 0);
			this.tcTableStructure.Name = "tcTableStructure";
			this.tcTableStructure.ShowFixedWidthTooltip = true;
			this.tcTableStructure.Size = new System.Drawing.Size(984, 472);
			this.tcTableStructure.TabIndex = 0;
			this.tcTableStructure.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
																								 this.tabColumns,
																								 this.tabIndices,
																								 this.tabForeignKeys});
			this.tcTableStructure.TabsLineColor = System.Drawing.Color.Black;
			this.tcTableStructure.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
			this.tcTableStructure.Text = "kissTabControlEx1";
			this.tcTableStructure.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tcTableStructure_SelectedTabChanged);
			// 
			// tabColumns
			// 
			this.tabColumns.Location = new System.Drawing.Point(6, 6);
			this.tabColumns.Name = "tabColumns";
			this.tabColumns.Size = new System.Drawing.Size(972, 434);
			this.tabColumns.TabIndex = 0;
			this.tabColumns.Title = "Spalten";
			// 
			// tabIndices
			// 
			this.tabIndices.Location = new System.Drawing.Point(6, 6);
			this.tabIndices.Name = "tabIndices";
			this.tabIndices.Size = new System.Drawing.Size(972, 434);
			this.tabIndices.TabIndex = 1;
			this.tabIndices.Title = "Primary Key, Indizes";
			// 
			// tabForeignKeys
			// 
			this.tabForeignKeys.Location = new System.Drawing.Point(6, 6);
			this.tabForeignKeys.Name = "tabForeignKeys";
			this.tabForeignKeys.Size = new System.Drawing.Size(972, 434);
			this.tabForeignKeys.TabIndex = 2;
			this.tabForeignKeys.Title = "Fremdschlüssel";
			// 
			// btnBackToTables
			// 
			this.btnBackToTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBackToTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBackToTables.Location = new System.Drawing.Point(776, 480);
			this.btnBackToTables.Name = "btnBackToTables";
			this.btnBackToTables.Size = new System.Drawing.Size(200, 24);
			this.btnBackToTables.TabIndex = 26;
			this.btnBackToTables.Text = "Zurück zur Tabellenübersicht";
			this.btnBackToTables.Click += new System.EventHandler(this.btnBackToTables_Click);
			// 
			// CtlTableStructureEditor
			// 
			this.Controls.Add(this.btnBackToTables);
			this.Controls.Add(this.tcTableStructure);
			this.Name = "CtlTableStructureEditor";
			this.Size = new System.Drawing.Size(984, 512);
			this.tcTableStructure.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventhandler

		/// <summary>
		/// The user wants to return to the 'table'-table
		/// </summary>
		/// <param name="sender">The source of the event</param>
		/// <param name="e"></param>
		private void btnBackToTables_Click(object sender, System.EventArgs e)
		{
			if( OpenTableEditor != null )
			{
				OpenTableEditor( this, EventArgs.Empty );
			}
		}

		/// <summary>
		/// A TabPage has been selected
		/// set the control located in the selected TabPage as the activeNavigator
		/// </summary>
		/// <param name="page">Selected page</param>
		private void tcTableStructure_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
		{
			if( page == this.tabColumns )
			{
				columnEditor.Focus();
				activeNavigator = columnEditor;
			}
			else if( page == this.tabIndices )
			{
				indicesEditor.Focus();
				activeNavigator = indicesEditor;
			}
			else if( page == this.tabForeignKeys )
			{
				foreignKeysEditor.Focus();
				activeNavigator = foreignKeysEditor;
			}
		}

		#endregion

		#region Properties
				
		/// <summary>
		/// Property for name of current table to show
		/// </summary>
		internal string CurrentTableName
		{
			get
			{
				return columnEditor.CurrentTableName;
			}
			set
			{
				columnEditor.CurrentTableName = value;
				indicesEditor.CurrentTableName = value;
				foreignKeysEditor.CurrentTableName = value;
			}
		}

		#endregion

		#region public events
		
		/// <summary>
		/// The user wants to open the table editor
		/// </summary>
		public event EventHandler OpenTableEditor;

		#endregion

		#region IKissDataNavigator

		bool IKissDataNavigator.AddData()         {return activeNavigator.AddData(); }
		bool IKissDataNavigator.SaveData()        {return activeNavigator.SaveData(); }
		bool IKissDataNavigator.DeleteData()      {return activeNavigator.DeleteData(); }
		void IKissDataNavigator.UndoDataChanges() {activeNavigator.UndoDataChanges(); }
		void IKissDataNavigator.RefreshData()     {activeNavigator.RefreshData(); }

		void IKissDataNavigator.MoveFirst()       {activeNavigator.MoveFirst(); }
		void IKissDataNavigator.MovePrevious()    {activeNavigator.MovePrevious(); }
		void IKissDataNavigator.MoveNext()        {activeNavigator.MoveNext(); }
		void IKissDataNavigator.MoveLast()        {activeNavigator.MoveLast(); }

		void IKissDataNavigator.Search()          {activeNavigator.Search(); }
		
		#endregion
	}
}
