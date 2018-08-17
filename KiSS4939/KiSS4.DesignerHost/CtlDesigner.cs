using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;
using Kiss.Interfaces.UI;

namespace KiSS4.DesignerHost
{
	public class CtlDesigner : KiSS4.Gui.KissUserControl
	{
		#region Variables

		private System.ComponentModel.IContainer components = null;
		private KiSS4.Gui.KissTabControlEx tabControl;
		private SharpLibrary.WinControls.TabPageEx tpgCodeCS;
		private KiSS4.DB.SqlQuery qryXClass;
		private KiSS4.DB.SqlQuery qryXClassControl;
		private KiSS4.DB.SqlQuery qryXClassComponent;
		private SharpLibrary.WinControls.TabPageEx tpgLayout;
		private SharpLibrary.WinControls.TabPageEx tpgRule;
		private SharpLibrary.WinControls.TabPageEx tpgReference;
		private KiSS4.DB.SqlQuery qryXClassReference;
		private KiSS4.DB.SqlQuery qryXClassReferenceOUT;
		private KiSS4.Gui.KissButton btnAdd;
		private KiSS4.Gui.KissButton btnRemove;
		private KiSS4.Gui.KissButton btnAddAll;
		private KiSS4.Gui.KissButton btnRemoveAll;
		private KiSS4.Gui.KissGrid grdXClassReferenceOUT;
		private KiSS4.Gui.KissGrid grdXClassReferenceIN;
		private DevExpress.XtraGrid.Views.Grid.GridView grdViewReferenceOUT;
		private DevExpress.XtraGrid.Columns.GridColumn colClassNameOUT;
		private DevExpress.XtraGrid.Views.Grid.GridView grdViewReference;
		private DevExpress.XtraGrid.Columns.GridColumn colClassNameIN;
		private DevExpress.XtraGrid.Columns.GridColumn colModulIN;
		private DevExpress.XtraGrid.Columns.GridColumn colModulOUT;
		private TextEditorControl edtCodeGenerated;
		private System.Windows.Forms.Panel pnlContainer;
		private System.Windows.Forms.Panel pnlBottom;
		private KiSS4.Gui.KissLabel lblStatusBar;
		private KiSS4.Gui.KissCalcEdit edtGotoLine;
		private KiSS4.Gui.KissButton btnGotoLine;
		private KiSS4.Gui.KissButton btnSearch;
		private KiSS4.Gui.KissTextEdit edtSearchFor;
		private SharpLibrary.WinControls.TabPageEx tpgXRight;

		private CtlDesignerLayout ctlDesignerLayout = null;
		private CtlDesignerRule ctlDesignerRule = null;
		private CtlXRight ctlXRight;

		#endregion

		#region Constructor / Dispose

		public CtlDesigner(string className) : this()
		{
			this.kissDataNavigator.PrefereDetailControl = true;

			if (!Session.User.UserID.Equals(DBUtil.ExecuteScalarSQL("SELECT CheckOut_UserID FROM XClass WHERE ClassName = {0}", className)))
				this.qryXClass.CanUpdate = false;

			this.qryXClass.Fill(this.qryXClass.SelectStatement, className);
		}

		public CtlDesigner()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			this.edtCodeGenerated.ActiveTextAreaControl.TextArea.KeyDown += new KeyEventHandler(edtCodeGenerated_KeyDown);

			this.ctlDesignerRule = new CtlDesignerRule(this.qryXClass, this.qryXClassControl, this.qryXClassComponent);
			this.ctlDesignerRule.Dock = DockStyle.Fill;
			this.tpgRule.Controls.Add(ctlDesignerRule);
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

		#endregion

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlDesigner));
			ICSharpCode.TextEditor.Document.DefaultTextEditorProperties defaultTextEditorProperties1 = new ICSharpCode.TextEditor.Document.DefaultTextEditorProperties();
			this.tabControl = new KiSS4.Gui.KissTabControlEx();
			this.tpgReference = new SharpLibrary.WinControls.TabPageEx();
			this.btnRemoveAll = new KiSS4.Gui.KissButton();
			this.btnAddAll = new KiSS4.Gui.KissButton();
			this.btnRemove = new KiSS4.Gui.KissButton();
			this.btnAdd = new KiSS4.Gui.KissButton();
			this.grdXClassReferenceIN = new KiSS4.Gui.KissGrid();
			this.qryXClassReference = new KiSS4.DB.SqlQuery(this.components);
			this.grdViewReference = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colModulIN = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colClassNameIN = new DevExpress.XtraGrid.Columns.GridColumn();
			this.grdXClassReferenceOUT = new KiSS4.Gui.KissGrid();
			this.qryXClassReferenceOUT = new KiSS4.DB.SqlQuery(this.components);
			this.grdViewReferenceOUT = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colModulOUT = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colClassNameOUT = new DevExpress.XtraGrid.Columns.GridColumn();
			this.tpgLayout = new SharpLibrary.WinControls.TabPageEx();
			this.tpgCodeCS = new SharpLibrary.WinControls.TabPageEx();
			this.pnlContainer = new System.Windows.Forms.Panel();
			this.edtCodeGenerated = new KiSS4.DesignerHost.TextEditorControl();
			this.qryXClass = new KiSS4.DB.SqlQuery(this.components);
			this.pnlBottom = new System.Windows.Forms.Panel();
			this.edtSearchFor = new KiSS4.Gui.KissTextEdit();
			this.btnSearch = new KiSS4.Gui.KissButton();
			this.btnGotoLine = new KiSS4.Gui.KissButton();
			this.edtGotoLine = new KiSS4.Gui.KissCalcEdit();
			this.lblStatusBar = new KiSS4.Gui.KissLabel();
			this.tpgXRight = new SharpLibrary.WinControls.TabPageEx();
			this.ctlXRight = new KiSS4.DesignerHost.CtlXRight();
			this.tpgRule = new SharpLibrary.WinControls.TabPageEx();
			this.qryXClassControl = new KiSS4.DB.SqlQuery(this.components);
			this.qryXClassComponent = new KiSS4.DB.SqlQuery(this.components);
			this.tabControl.SuspendLayout();
			this.tpgReference.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdXClassReferenceIN)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.qryXClassReference)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdViewReference)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdXClassReferenceOUT)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.qryXClassReferenceOUT)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdViewReferenceOUT)).BeginInit();
			this.tpgCodeCS.SuspendLayout();
			this.pnlContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.qryXClass)).BeginInit();
			this.pnlBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.edtSearchFor.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.edtGotoLine.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblStatusBar)).BeginInit();
			this.tpgXRight.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.qryXClassControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.qryXClassComponent)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tpgReference);
			this.tabControl.Controls.Add(this.tpgLayout);
			this.tabControl.Controls.Add(this.tpgCodeCS);
			this.tabControl.Controls.Add(this.tpgXRight);
			this.tabControl.Controls.Add(this.tpgRule);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.ShowFixedWidthTooltip = true;
			this.tabControl.Size = new System.Drawing.Size(824, 486);
			this.tabControl.TabIndex = 0;
			this.tabControl.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgLayout,
            this.tpgRule,
            this.tpgReference,
            this.tpgCodeCS,
            this.tpgXRight});
			this.tabControl.TabsLineColor = System.Drawing.Color.Black;
			this.tabControl.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
			this.tabControl.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
			this.tabControl.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabControl_SelectedTabChanging);
			this.tabControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseUp);
			this.tabControl.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControl_SelectedTabChanged);
			// 
			// tpgReference
			// 
			this.tpgReference.Controls.Add(this.btnRemoveAll);
			this.tpgReference.Controls.Add(this.btnAddAll);
			this.tpgReference.Controls.Add(this.btnRemove);
			this.tpgReference.Controls.Add(this.btnAdd);
			this.tpgReference.Controls.Add(this.grdXClassReferenceIN);
			this.tpgReference.Controls.Add(this.grdXClassReferenceOUT);
			this.tpgReference.Location = new System.Drawing.Point(6, 32);
			this.tpgReference.Name = "tpgReference";
			this.tpgReference.Size = new System.Drawing.Size(812, 448);
			this.tpgReference.TabIndex = 2;
			this.tpgReference.Title = "Referenzen";
			// 
			// btnRemoveAll
			// 
			this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemoveAll.IconID = 12;
			this.btnRemoveAll.Location = new System.Drawing.Point(368, 200);
			this.btnRemoveAll.Name = "btnRemoveAll";
			this.btnRemoveAll.Size = new System.Drawing.Size(34, 24);
			this.btnRemoveAll.TabIndex = 4;
			this.btnRemoveAll.UseVisualStyleBackColor = false;
			this.btnRemoveAll.Click += new System.EventHandler(this.btnAddRemove_Click);
			// 
			// btnAddAll
			// 
			this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddAll.IconID = 14;
			this.btnAddAll.Location = new System.Drawing.Point(368, 168);
			this.btnAddAll.Name = "btnAddAll";
			this.btnAddAll.Size = new System.Drawing.Size(34, 24);
			this.btnAddAll.TabIndex = 3;
			this.btnAddAll.UseVisualStyleBackColor = false;
			this.btnAddAll.Click += new System.EventHandler(this.btnAddRemove_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemove.IconID = 11;
			this.btnRemove.Location = new System.Drawing.Point(368, 136);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(34, 24);
			this.btnRemove.TabIndex = 2;
			this.btnRemove.UseVisualStyleBackColor = false;
			this.btnRemove.Click += new System.EventHandler(this.btnAddRemove_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.IconID = 13;
			this.btnAdd.Location = new System.Drawing.Point(368, 104);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(34, 24);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.UseVisualStyleBackColor = false;
			this.btnAdd.Click += new System.EventHandler(this.btnAddRemove_Click);
			// 
			// grdXClassReferenceIN
			// 
			this.grdXClassReferenceIN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.grdXClassReferenceIN.DataSource = this.qryXClassReference;
			this.grdXClassReferenceIN.EmbeddedNavigator.Name = "";
			this.grdXClassReferenceIN.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
			this.grdXClassReferenceIN.Location = new System.Drawing.Point(408, 8);
			this.grdXClassReferenceIN.MainView = this.grdViewReference;
			this.grdXClassReferenceIN.Name = "grdXClassReferenceIN";
			this.grdXClassReferenceIN.Size = new System.Drawing.Size(352, 432);
			this.grdXClassReferenceIN.TabIndex = 5;
			this.grdXClassReferenceIN.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewReference});
			this.grdXClassReferenceIN.DoubleClick += new System.EventHandler(this.grdXClassReferenceIN_DoubleClick);
			// 
			// qryXClassReference
			// 
			this.qryXClassReference.CanDelete = true;
			this.qryXClassReference.CanInsert = true;
			this.qryXClassReference.HostControl = this;
			this.qryXClassReference.SelectStatement = resources.GetString("qryXClassReference.SelectStatement");
			this.qryXClassReference.TableName = "XClassReference";
			// 
			// grdViewReference
			// 
			this.grdViewReference.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.grdViewReference.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grdViewReference.Appearance.Empty.Options.UseBackColor = true;
			this.grdViewReference.Appearance.Empty.Options.UseFont = true;
			this.grdViewReference.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grdViewReference.Appearance.EvenRow.Options.UseFont = true;
			this.grdViewReference.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
			this.grdViewReference.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grdViewReference.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
			this.grdViewReference.Appearance.FocusedCell.Options.UseBackColor = true;
			this.grdViewReference.Appearance.FocusedCell.Options.UseFont = true;
			this.grdViewReference.Appearance.FocusedCell.Options.UseForeColor = true;
			this.grdViewReference.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
			this.grdViewReference.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grdViewReference.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
			this.grdViewReference.Appearance.FocusedRow.Options.UseBackColor = true;
			this.grdViewReference.Appearance.FocusedRow.Options.UseFont = true;
			this.grdViewReference.Appearance.FocusedRow.Options.UseForeColor = true;
			this.grdViewReference.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
			this.grdViewReference.Appearance.GroupPanel.Options.UseBackColor = true;
			this.grdViewReference.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
			this.grdViewReference.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.grdViewReference.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdViewReference.Appearance.GroupRow.Options.UseBackColor = true;
			this.grdViewReference.Appearance.GroupRow.Options.UseFont = true;
			this.grdViewReference.Appearance.GroupRow.Options.UseForeColor = true;
			this.grdViewReference.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
			this.grdViewReference.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
			this.grdViewReference.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.grdViewReference.Appearance.HeaderPanel.Options.UseBackColor = true;
			this.grdViewReference.Appearance.HeaderPanel.Options.UseBorderColor = true;
			this.grdViewReference.Appearance.HeaderPanel.Options.UseFont = true;
			this.grdViewReference.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
			this.grdViewReference.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grdViewReference.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdViewReference.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.grdViewReference.Appearance.HideSelectionRow.Options.UseFont = true;
			this.grdViewReference.Appearance.HideSelectionRow.Options.UseForeColor = true;
			this.grdViewReference.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
			this.grdViewReference.Appearance.HorzLine.Options.UseBackColor = true;
			this.grdViewReference.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grdViewReference.Appearance.OddRow.Options.UseFont = true;
			this.grdViewReference.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
			this.grdViewReference.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grdViewReference.Appearance.Row.Options.UseBackColor = true;
			this.grdViewReference.Appearance.Row.Options.UseFont = true;
			this.grdViewReference.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grdViewReference.Appearance.SelectedRow.Options.UseFont = true;
			this.grdViewReference.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
			this.grdViewReference.Appearance.VertLine.Options.UseBackColor = true;
			this.grdViewReference.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.grdViewReference.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colModulIN,
            this.colClassNameIN});
			this.grdViewReference.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
			this.grdViewReference.GridControl = this.grdXClassReferenceIN;
			this.grdViewReference.Name = "grdViewReference";
			this.grdViewReference.OptionsBehavior.Editable = false;
			this.grdViewReference.OptionsCustomization.AllowFilter = false;
			this.grdViewReference.OptionsFilter.AllowFilterEditor = false;
			this.grdViewReference.OptionsFilter.UseNewCustomFilterDialog = true;
			this.grdViewReference.OptionsNavigation.AutoFocusNewRow = true;
			this.grdViewReference.OptionsNavigation.UseTabKey = false;
			this.grdViewReference.OptionsView.ColumnAutoWidth = false;
			this.grdViewReference.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.grdViewReference.OptionsView.ShowGroupPanel = false;
			this.grdViewReference.OptionsView.ShowIndicator = false;
			// 
			// colModulIN
			// 
			this.colModulIN.Caption = "Modul";
			this.colModulIN.FieldName = "Name";
			this.colModulIN.Name = "colModulIN";
			this.colModulIN.Visible = true;
			this.colModulIN.VisibleIndex = 0;
			this.colModulIN.Width = 144;
			// 
			// colClassNameIN
			// 
			this.colClassNameIN.Caption = "Klasse";
			this.colClassNameIN.FieldName = "ClassName_Ref";
			this.colClassNameIN.Name = "colClassNameIN";
			this.colClassNameIN.Visible = true;
			this.colClassNameIN.VisibleIndex = 1;
			this.colClassNameIN.Width = 179;
			// 
			// grdXClassReferenceOUT
			// 
			this.grdXClassReferenceOUT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.grdXClassReferenceOUT.DataSource = this.qryXClassReferenceOUT;
			this.grdXClassReferenceOUT.EmbeddedNavigator.Name = "";
			this.grdXClassReferenceOUT.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
			this.grdXClassReferenceOUT.Location = new System.Drawing.Point(8, 8);
			this.grdXClassReferenceOUT.MainView = this.grdViewReferenceOUT;
			this.grdXClassReferenceOUT.Name = "grdXClassReferenceOUT";
			this.grdXClassReferenceOUT.Size = new System.Drawing.Size(352, 432);
			this.grdXClassReferenceOUT.TabIndex = 0;
			this.grdXClassReferenceOUT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewReferenceOUT});
			this.grdXClassReferenceOUT.DoubleClick += new System.EventHandler(this.grdXClassReferenceOUT_DoubleClick);
			// 
			// qryXClassReferenceOUT
			// 
			this.qryXClassReferenceOUT.HostControl = this;
			this.qryXClassReferenceOUT.SelectStatement = resources.GetString("qryXClassReferenceOUT.SelectStatement");
			// 
			// grdViewReferenceOUT
			// 
			this.grdViewReferenceOUT.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.grdViewReferenceOUT.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grdViewReferenceOUT.Appearance.Empty.Options.UseBackColor = true;
			this.grdViewReferenceOUT.Appearance.Empty.Options.UseFont = true;
			this.grdViewReferenceOUT.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grdViewReferenceOUT.Appearance.EvenRow.Options.UseFont = true;
			this.grdViewReferenceOUT.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
			this.grdViewReferenceOUT.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grdViewReferenceOUT.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
			this.grdViewReferenceOUT.Appearance.FocusedCell.Options.UseBackColor = true;
			this.grdViewReferenceOUT.Appearance.FocusedCell.Options.UseFont = true;
			this.grdViewReferenceOUT.Appearance.FocusedCell.Options.UseForeColor = true;
			this.grdViewReferenceOUT.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
			this.grdViewReferenceOUT.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grdViewReferenceOUT.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
			this.grdViewReferenceOUT.Appearance.FocusedRow.Options.UseBackColor = true;
			this.grdViewReferenceOUT.Appearance.FocusedRow.Options.UseFont = true;
			this.grdViewReferenceOUT.Appearance.FocusedRow.Options.UseForeColor = true;
			this.grdViewReferenceOUT.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
			this.grdViewReferenceOUT.Appearance.GroupPanel.Options.UseBackColor = true;
			this.grdViewReferenceOUT.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
			this.grdViewReferenceOUT.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.grdViewReferenceOUT.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdViewReferenceOUT.Appearance.GroupRow.Options.UseBackColor = true;
			this.grdViewReferenceOUT.Appearance.GroupRow.Options.UseFont = true;
			this.grdViewReferenceOUT.Appearance.GroupRow.Options.UseForeColor = true;
			this.grdViewReferenceOUT.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
			this.grdViewReferenceOUT.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
			this.grdViewReferenceOUT.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.grdViewReferenceOUT.Appearance.HeaderPanel.Options.UseBackColor = true;
			this.grdViewReferenceOUT.Appearance.HeaderPanel.Options.UseBorderColor = true;
			this.grdViewReferenceOUT.Appearance.HeaderPanel.Options.UseFont = true;
			this.grdViewReferenceOUT.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
			this.grdViewReferenceOUT.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grdViewReferenceOUT.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grdViewReferenceOUT.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.grdViewReferenceOUT.Appearance.HideSelectionRow.Options.UseFont = true;
			this.grdViewReferenceOUT.Appearance.HideSelectionRow.Options.UseForeColor = true;
			this.grdViewReferenceOUT.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
			this.grdViewReferenceOUT.Appearance.HorzLine.Options.UseBackColor = true;
			this.grdViewReferenceOUT.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grdViewReferenceOUT.Appearance.OddRow.Options.UseFont = true;
			this.grdViewReferenceOUT.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
			this.grdViewReferenceOUT.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grdViewReferenceOUT.Appearance.Row.Options.UseBackColor = true;
			this.grdViewReferenceOUT.Appearance.Row.Options.UseFont = true;
			this.grdViewReferenceOUT.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grdViewReferenceOUT.Appearance.SelectedRow.Options.UseFont = true;
			this.grdViewReferenceOUT.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
			this.grdViewReferenceOUT.Appearance.VertLine.Options.UseBackColor = true;
			this.grdViewReferenceOUT.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.grdViewReferenceOUT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colModulOUT,
            this.colClassNameOUT});
			this.grdViewReferenceOUT.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
			this.grdViewReferenceOUT.GridControl = this.grdXClassReferenceOUT;
			this.grdViewReferenceOUT.Name = "grdViewReferenceOUT";
			this.grdViewReferenceOUT.OptionsBehavior.Editable = false;
			this.grdViewReferenceOUT.OptionsCustomization.AllowFilter = false;
			this.grdViewReferenceOUT.OptionsFilter.AllowFilterEditor = false;
			this.grdViewReferenceOUT.OptionsFilter.UseNewCustomFilterDialog = true;
			this.grdViewReferenceOUT.OptionsNavigation.AutoFocusNewRow = true;
			this.grdViewReferenceOUT.OptionsNavigation.UseTabKey = false;
			this.grdViewReferenceOUT.OptionsView.ColumnAutoWidth = false;
			this.grdViewReferenceOUT.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.grdViewReferenceOUT.OptionsView.ShowGroupPanel = false;
			this.grdViewReferenceOUT.OptionsView.ShowIndicator = false;
			// 
			// colModulOUT
			// 
			this.colModulOUT.Caption = "Modul";
			this.colModulOUT.FieldName = "Name";
			this.colModulOUT.Name = "colModulOUT";
			this.colModulOUT.Visible = true;
			this.colModulOUT.VisibleIndex = 0;
			this.colModulOUT.Width = 144;
			// 
			// colClassNameOUT
			// 
			this.colClassNameOUT.Caption = "Klasse";
			this.colClassNameOUT.FieldName = "ClassName";
			this.colClassNameOUT.Name = "colClassNameOUT";
			this.colClassNameOUT.Visible = true;
			this.colClassNameOUT.VisibleIndex = 1;
			this.colClassNameOUT.Width = 179;
			// 
			// tpgLayout
			// 
			this.tpgLayout.Location = new System.Drawing.Point(6, 32);
			this.tpgLayout.Name = "tpgLayout";
			this.tpgLayout.Size = new System.Drawing.Size(812, 448);
			this.tpgLayout.TabIndex = 0;
			this.tpgLayout.Title = "Layout";
			// 
			// tpgCodeCS
			// 
			this.tpgCodeCS.Controls.Add(this.pnlContainer);
			this.tpgCodeCS.Controls.Add(this.pnlBottom);
			this.tpgCodeCS.Location = new System.Drawing.Point(6, 32);
			this.tpgCodeCS.Name = "tpgCodeCS";
			this.tpgCodeCS.Size = new System.Drawing.Size(812, 448);
			this.tpgCodeCS.TabIndex = 3;
			this.tpgCodeCS.Title = "C# Code";
			// 
			// pnlContainer
			// 
			this.pnlContainer.Controls.Add(this.edtCodeGenerated);
			this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlContainer.Location = new System.Drawing.Point(0, 0);
			this.pnlContainer.Name = "pnlContainer";
			this.pnlContainer.Size = new System.Drawing.Size(812, 424);
			this.pnlContainer.TabIndex = 12;
			// 
			// edtCodeGenerated
			// 
			this.edtCodeGenerated.DataMember = "CodeGenerated";
			this.edtCodeGenerated.DataSource = this.qryXClass;
			this.edtCodeGenerated.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edtCodeGenerated.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
			this.edtCodeGenerated.Encoding = null;
			this.edtCodeGenerated.IsIconBarVisible = false;
			this.edtCodeGenerated.Location = new System.Drawing.Point(0, 0);
			this.edtCodeGenerated.Name = "edtCodeGenerated";
			this.edtCodeGenerated.ShowEOLMarkers = true;
			this.edtCodeGenerated.ShowSpaces = true;
			this.edtCodeGenerated.ShowTabs = true;
			this.edtCodeGenerated.Size = new System.Drawing.Size(812, 424);
			this.edtCodeGenerated.TabIndex = 0;
			defaultTextEditorProperties1.AllowCaretBeyondEOL = false;
			defaultTextEditorProperties1.AutoInsertCurlyBracket = true;
			defaultTextEditorProperties1.BracketMatchingStyle = ICSharpCode.TextEditor.Document.BracketMatchingStyle.After;
			defaultTextEditorProperties1.ConvertTabsToSpaces = false;
			defaultTextEditorProperties1.CreateBackupCopy = false;
			defaultTextEditorProperties1.DocumentSelectionMode = ICSharpCode.TextEditor.Document.DocumentSelectionMode.Normal;
			defaultTextEditorProperties1.EnableFolding = true;
			defaultTextEditorProperties1.Encoding = null;
			defaultTextEditorProperties1.Font = new System.Drawing.Font("Courier New", 10F);
			defaultTextEditorProperties1.HideMouseCursor = false;
			defaultTextEditorProperties1.IndentStyle = ICSharpCode.TextEditor.Document.IndentStyle.Smart;
			defaultTextEditorProperties1.IsIconBarVisible = false;
			defaultTextEditorProperties1.LineTerminator = "\r\n";
			defaultTextEditorProperties1.LineViewerStyle = ICSharpCode.TextEditor.Document.LineViewerStyle.None;
			defaultTextEditorProperties1.MouseWheelScrollDown = true;
			defaultTextEditorProperties1.MouseWheelTextZoom = true;
			defaultTextEditorProperties1.ShowEOLMarker = true;
			defaultTextEditorProperties1.ShowHorizontalRuler = false;
			defaultTextEditorProperties1.ShowInvalidLines = true;
			defaultTextEditorProperties1.ShowLineNumbers = true;
			defaultTextEditorProperties1.ShowMatchingBracket = true;
			defaultTextEditorProperties1.ShowSpaces = true;
			defaultTextEditorProperties1.ShowTabs = true;
			defaultTextEditorProperties1.ShowVerticalRuler = false;
			defaultTextEditorProperties1.TabIndent = 4;
			defaultTextEditorProperties1.UseAntiAliasedFont = false;
			defaultTextEditorProperties1.UseCustomLine = false;
			defaultTextEditorProperties1.VerticalRulerRow = 80;
			this.edtCodeGenerated.TextEditorProperties = defaultTextEditorProperties1;
			// 
			// qryXClass
			// 
			this.qryXClass.CanUpdate = true;
			this.qryXClass.HostControl = this;
			this.qryXClass.SelectStatement = "SELECT CLS.*, DesignerCode = CONVERT(int, CLS.Designer), MOD.NameSpace\r\nFROM XCla" +
				"ss          CLS\r\n  INNER JOIN XModul  MOD ON MOD.ModulID = CLS.ModulID\r\nWHERE CL" +
				"S.ClassName = {0}";
			this.qryXClass.TableName = "XClass";
			this.qryXClass.AfterFill += new System.EventHandler(this.qryXClass_AfterFill);
			// 
			// pnlBottom
			// 
			this.pnlBottom.Controls.Add(this.edtSearchFor);
			this.pnlBottom.Controls.Add(this.btnSearch);
			this.pnlBottom.Controls.Add(this.btnGotoLine);
			this.pnlBottom.Controls.Add(this.edtGotoLine);
			this.pnlBottom.Controls.Add(this.lblStatusBar);
			this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlBottom.Location = new System.Drawing.Point(0, 424);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Size = new System.Drawing.Size(812, 24);
			this.pnlBottom.TabIndex = 12;
			// 
			// edtSearchFor
			// 
			this.edtSearchFor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.edtSearchFor.Location = new System.Drawing.Point(396, 0);
			this.edtSearchFor.Name = "edtSearchFor";
			this.edtSearchFor.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
			this.edtSearchFor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.edtSearchFor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.edtSearchFor.Properties.Appearance.Options.UseBackColor = true;
			this.edtSearchFor.Properties.Appearance.Options.UseBorderColor = true;
			this.edtSearchFor.Properties.Appearance.Options.UseFont = true;
			this.edtSearchFor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.edtSearchFor.Size = new System.Drawing.Size(228, 24);
			this.edtSearchFor.TabIndex = 1;
			this.edtSearchFor.EnterKey += new System.Windows.Forms.KeyEventHandler(this.edtSearchFor_EnterKey);
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearch.Location = new System.Drawing.Point(624, 0);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(52, 24);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "Suche";
			this.btnSearch.UseVisualStyleBackColor = false;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// btnGotoLine
			// 
			this.btnGotoLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGotoLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGotoLine.Location = new System.Drawing.Point(748, 0);
			this.btnGotoLine.Name = "btnGotoLine";
			this.btnGotoLine.Size = new System.Drawing.Size(64, 24);
			this.btnGotoLine.TabIndex = 4;
			this.btnGotoLine.Text = "Gehe zu";
			this.btnGotoLine.UseVisualStyleBackColor = false;
			this.btnGotoLine.Click += new System.EventHandler(this.btnGotoLine_Click);
			// 
			// edtGotoLine
			// 
			this.edtGotoLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.edtGotoLine.Location = new System.Drawing.Point(684, 0);
			this.edtGotoLine.Name = "edtGotoLine";
			this.edtGotoLine.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
			this.edtGotoLine.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
			this.edtGotoLine.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.edtGotoLine.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.edtGotoLine.Properties.Appearance.Options.UseBackColor = true;
			this.edtGotoLine.Properties.Appearance.Options.UseBorderColor = true;
			this.edtGotoLine.Properties.Appearance.Options.UseFont = true;
			this.edtGotoLine.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.edtGotoLine.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.edtGotoLine.Size = new System.Drawing.Size(64, 24);
			this.edtGotoLine.TabIndex = 3;
			this.edtGotoLine.EnterKey += new System.Windows.Forms.KeyEventHandler(this.edtGotoLine_EnterKey);
			// 
			// lblStatusBar
			// 
			this.lblStatusBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblStatusBar.Location = new System.Drawing.Point(0, 0);
			this.lblStatusBar.Name = "lblStatusBar";
			this.lblStatusBar.Size = new System.Drawing.Size(396, 24);
			this.lblStatusBar.TabIndex = 0;
			this.lblStatusBar.Text = "";
			// 
			// tpgXRight
			// 
			this.tpgXRight.Controls.Add(this.ctlXRight);
			this.tpgXRight.Location = new System.Drawing.Point(6, 32);
			this.tpgXRight.Name = "tpgXRight";
			this.tpgXRight.Size = new System.Drawing.Size(812, 448);
			this.tpgXRight.TabIndex = 4;
			this.tpgXRight.Title = "Zugriffsrechte";
			// 
			// ctlXRight
			// 
			this.ctlXRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.ctlXRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctlXRight.Location = new System.Drawing.Point(0, 0);
			this.ctlXRight.Name = "ctlXRight";
			this.ctlXRight.Size = new System.Drawing.Size(812, 448);
			this.ctlXRight.TabIndex = 0;
			// 
			// tpgRule
			// 
			this.tpgRule.Location = new System.Drawing.Point(6, 32);
			this.tpgRule.Name = "tpgRule";
			this.tpgRule.Size = new System.Drawing.Size(812, 448);
			this.tpgRule.TabIndex = 1;
			this.tpgRule.Title = "Regel";
			// 
			// qryXClassControl
			// 
			this.qryXClassControl.HostControl = this;
			this.qryXClassControl.SelectStatement = "SELECT * FROM XClassControl WHERE ClassName = {0}";
			this.qryXClassControl.TableName = "XClassControl";
			// 
			// qryXClassComponent
			// 
			this.qryXClassComponent.HostControl = this;
			this.qryXClassComponent.SelectStatement = "SELECT * FROM XClassComponent WHERE ClassName = {0}";
			this.qryXClassComponent.TableName = "XClassComponent";
			// 
			// CtlDesigner
			// 
			this.ActiveSQLQuery = this.qryXClass;
			this.Controls.Add(this.tabControl);
			this.Name = "CtlDesigner";
			this.Size = new System.Drawing.Size(824, 486);
			this.Load += new System.EventHandler(this.CtlDesigner_Load);
			this.tabControl.ResumeLayout(false);
			this.tpgReference.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdXClassReferenceIN)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.qryXClassReference)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdViewReference)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdXClassReferenceOUT)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.qryXClassReferenceOUT)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdViewReferenceOUT)).EndInit();
			this.tpgCodeCS.ResumeLayout(false);
			this.pnlContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.qryXClass)).EndInit();
			this.pnlBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.edtSearchFor.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.edtGotoLine.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblStatusBar)).EndInit();
			this.tpgXRight.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.qryXClassControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.qryXClassComponent)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Events

		private void CtlDesigner_Load(object sender, System.EventArgs e)
		{
			// select tabLayout by default
			this.tabControl.SelectTab(this.tpgLayout);
		}

		private void tabControl_SelectedTabChanging(object sender, CancelEventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				if (tabControl.SelectedTab == tpgLayout && this.ctlDesignerLayout != null)
				{
					((IKissDataNavigator)ctlDesignerLayout).SaveData();
				}
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void tabControl_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				if (page == tpgLayout && this.ctlDesignerLayout == null)
				{
					this.qryXClass.Post();

					LoadDesignerLayout();
				}

				page.Focus();
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void LoadDesignerLayout()
		{
			if (this.ctlDesignerLayout != null) return;

			this.tpgLayout.Controls.Clear();

			ctlDesignerLayout = new CtlDesignerLayout(this.qryXClass, this.qryXClassControl, this.qryXClassComponent, this.ctlDesignerRule.qryXClassRule);
			ctlDesignerLayout.Dock = DockStyle.Fill;
			this.tpgLayout.Controls.Add(ctlDesignerLayout);
		}

		private void tabControl_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (tabControl.SelectedTab == this.tpgReference)
			{
				this.grdXClassReferenceOUT.Focus();
			}
			else if (tabControl.SelectedTab == this.tpgCodeCS)
			{
				this.edtCodeGenerated.Focus();
			}
			else if (tabControl.SelectedTab.Controls.Count > 0)
			{
				tabControl.SelectedTab.Controls[0].Focus();
			}
		}

		private void qryXClass_AfterFill(object sender, System.EventArgs e)
		{
			ctlDesignerLayout = null;

			this.ctlXRight.ClassName = Convert.ToString(this.qryXClass["ClassName"]);

			this.qryXClassControl.Fill(this.qryXClass["ClassName"]);
			this.qryXClassComponent.Fill(this.qryXClass["ClassName"]);

			this.qryXClassReference.Fill(this.qryXClass["ClassName"]);
			this.qryXClassReferenceOUT.Fill(this.qryXClass["ModulID"], this.qryXClass["ClassName"]);

			if (tabControl.SelectedTab == tpgLayout)
				tabControl_SelectedTabChanged(tpgLayout);
		}

		public override KissUserControl DetailControl
		{
			get
			{
				if (tabControl.SelectedTab.Controls.Count == 1 && tabControl.SelectedTab.Controls[0] is KissUserControl)
					return (KissUserControl)tabControl.SelectedTab.Controls[0];
				else
					return base.DetailControl;
			}
		}

		public override void OnUndoDataChanges()
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				if (this.tabControl.SelectedTab == this.tpgLayout)
				{
					if (KiSS4.Messages.DlgQuestion.Show("Alle Änderungen seit dem Speichern verwerfen?", 0, 0, false))
					{
						this.qryXClass.Cancel();
						this.qryXClass.Refresh();
					}
				}
				else
					base.OnUndoDataChanges();
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void btnAddRemove_Click(object sender, System.EventArgs e)
		{
			if (qryXClass.Count == 0 || !qryXClass.Post()) return;

			if (sender == btnAdd && qryXClassReferenceOUT.Count > 0)
			{
				qryXClassReference.Insert();
				qryXClassReference["ClassName"] = qryXClass["ClassName"];
				qryXClassReference["Name"] = qryXClassReferenceOUT["Name"];
				qryXClassReference["ClassName_Ref"] = qryXClassReferenceOUT["ClassName"];
				qryXClassReference.Post();
			}
			else if (sender == btnRemove && qryXClassReference.Count > 0)
			{
				qryXClassReference.DeleteQuestion = null;
				qryXClassReference.Delete();
			}
			else if (sender == btnAddAll || sender == btnRemoveAll)
			{
				DBUtil.ExecSQL("DELETE FROM XClassReference WHERE ClassName = {0}", qryXClass["ClassName"]);

				if (sender == btnAddAll)
					DBUtil.ExecSQL(@"
						INSERT INTO XClassReference (ClassName, ClassName_Ref)
						  SELECT {0}, ClassName FROM XClass", qryXClass["ClassName"]);

				qryXClassReference.Refresh();
			}

			qryXClassReferenceOUT.Refresh();
		}

		private void grdXClassReferenceOUT_DoubleClick(object sender, System.EventArgs e)
		{
			this.btnAddRemove_Click(btnAdd, e);
		}

		private void grdXClassReferenceIN_DoubleClick(object sender, System.EventArgs e)
		{
			this.btnAddRemove_Click(btnRemove, e);
		}

		#endregion

		#region Search, goto, lineNumbers and position

		private void edtCodeGenerated_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F)
			{
				// CTRL+F
				this.edtSearchFor.Focus();
				e.Handled = true;
			}
			else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.G)
			{
				// CTRL+G
				this.edtGotoLine.Focus();
				e.Handled = true;
			}
		}

		private void edtSearchFor_EnterKey(object sender, KeyEventArgs e)
		{
			btnSearch.PerformClick();
			edtSearchFor.Focus();
		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!DBUtil.IsEmpty(edtSearchFor.EditValue))
				{
					edtSearchFor.Focus();

					ICSharpCode.TextEditor.TextAreaControl activeTextAreaControl = edtCodeGenerated.ActiveTextAreaControl;
					ICSharpCode.TextEditor.Document.IDocument document = activeTextAreaControl.Document;

					int offSet = activeTextAreaControl.Caret.Offset;

					offSet = edtCodeGenerated.Text.IndexOf(edtSearchFor.Text, ++offSet, StringComparison.InvariantCultureIgnoreCase);
					if (offSet == -1)
					{
						offSet = edtCodeGenerated.Text.IndexOf(edtSearchFor.Text, 0, StringComparison.InvariantCultureIgnoreCase);

						if (offSet == -1)
						{
							KissMsg.ShowInfo("CtlDesigner", "SearchTextNotFound", "Der gesuchte Text '{0}' konnte nicht gefunden werden.", 0, 0, this.edtSearchFor.Text);
							return;
						}
					}

					Point startSelection = document.OffsetToPosition(offSet);

					activeTextAreaControl.JumpTo(startSelection.Y, startSelection.X);
					activeTextAreaControl.SelectionManager.SetSelection(
						startSelection,
						document.OffsetToPosition(offSet + edtSearchFor.Text.Length));
				}
			}
			catch (Exception ex)
			{
				KissMsg.ShowError("CtlDesigner", "ExeptionWhileSearching", "Fehler beim Ausführen der Suche.", ex);
			}
		}

		private void edtGotoLine_EnterKey(object sender, KeyEventArgs e)
		{
			btnGotoLine.PerformClick();
		}

		private void btnGotoLine_Click(object sender, System.EventArgs e)
		{
			edtCodeGenerated.ActiveTextAreaControl.JumpTo(Convert.ToInt32(edtGotoLine.Text) - 1, 0);
		}

		#endregion

		internal void ShowPreview()
		{
			LoadDesignerLayout();
			ctlDesignerLayout.ShowPreview();
		}
	}
}
