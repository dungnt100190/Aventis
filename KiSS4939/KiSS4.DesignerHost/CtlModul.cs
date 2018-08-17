using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.DesignerHost
{
    /// <summary>
    /// Summary description for CtlModul.
    /// </summary>
    public class CtlModul : KissUserControl
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnLoadImage;
        private KissCheckEdit chkLicensed;
        private KiSS4.Gui.KissCheckEdit chkModulTree;
        private KissCheckEdit chkSystem;
        private DevExpress.XtraGrid.Columns.GridColumn colIconImage;
        private DevExpress.XtraGrid.Columns.GridColumn colIconName;
        private DevExpress.XtraGrid.Columns.GridColumn colModulID;
        private DevExpress.XtraGrid.Columns.GridColumn colModulIcon;
        private DevExpress.XtraGrid.Columns.GridColumn colModulLicensed;
        private DevExpress.XtraGrid.Columns.GridColumn colModulModulTree;
        private DevExpress.XtraGrid.Columns.GridColumn colModulSystem;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNameSpace;
        private DevExpress.XtraGrid.Columns.GridColumn colShortName;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private KiSS4.Gui.KissMemoEdit edtDescription;
        private KiSS4.Gui.KissTextEdit edtModulID;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissTextEdit edtNameSpace;
        private KiSS4.Gui.KissTextEdit edtShortName;
        private KiSS4.Gui.KissGrid grdXIcon;
        private KiSS4.Gui.KissGrid grdXModul;
        private KiSS4.Gui.KissGroupBox grpIcon;
        private DevExpress.XtraGrid.Views.Grid.GridView gvXIcon;
        private DevExpress.XtraGrid.Views.Grid.GridView gvXModul;
        private KiSS4.Gui.KissLabel lblDescription;
        private KiSS4.Gui.KissLabel lblIco32x32;
        private KiSS4.Gui.KissLabel lblIcon;
        private KiSS4.Gui.KissLabel lblIcon16x16;
        private KiSS4.Gui.KissLabel lblModulID;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblNameSpace;
        private KiSS4.Gui.KissLabel lblShortName;
        private Panel panDetails;
        private System.Windows.Forms.PictureBox picIconLarge;
        private System.Windows.Forms.PictureBox picIconSmall;
        private KiSS4.DB.SqlQuery qryIcon;
        private KiSS4.DB.SqlQuery qryXModul;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repIconImage;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repModulIconImageCbo;
        private KissSplitterCollapsible splitter;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlModul"/> class.
        /// </summary>
        public CtlModul()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // setup rights
            SetupRights();

            // setup repository items
            repModulIconImageCbo.NullText = " ";
            repIconImage.NullText = " ";

            // set images
            KissImageList.FillIconsIntoComboBox(repModulIconImageCbo, true);

            // fill modules
            this.qryXModul.Fill();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlModul));
            this.grdXModul = new KiSS4.Gui.KissGrid();
            this.qryXModul = new KiSS4.DB.SqlQuery(this.components);
            this.gvXModul = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colModulIcon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repModulIconImageCbo = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colModulID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameSpace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModulModulTree = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModulSystem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModulLicensed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.lblShortName = new KiSS4.Gui.KissLabel();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.edtShortName = new KiSS4.Gui.KissTextEdit();
            this.edtNameSpace = new KiSS4.Gui.KissTextEdit();
            this.lblNameSpace = new KiSS4.Gui.KissLabel();
            this.chkModulTree = new KiSS4.Gui.KissCheckEdit();
            this.qryIcon = new KiSS4.DB.SqlQuery(this.components);
            this.grdXIcon = new KiSS4.Gui.KissGrid();
            this.gvXIcon = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIconImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repIconImage = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colIconName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.picIconSmall = new System.Windows.Forms.PictureBox();
            this.picIconLarge = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new KiSS4.Gui.KissButton();
            this.lblIcon = new KiSS4.Gui.KissLabel();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.lblIcon16x16 = new KiSS4.Gui.KissLabel();
            this.lblIco32x32 = new KiSS4.Gui.KissLabel();
            this.edtModulID = new KiSS4.Gui.KissTextEdit();
            this.lblModulID = new KiSS4.Gui.KissLabel();
            this.grpIcon = new KiSS4.Gui.KissGroupBox();
            this.edtDescription = new KiSS4.Gui.KissMemoEdit();
            this.lblDescription = new KiSS4.Gui.KissLabel();
            this.panDetails = new System.Windows.Forms.Panel();
            this.chkLicensed = new KiSS4.Gui.KissCheckEdit();
            this.chkSystem = new KiSS4.Gui.KissCheckEdit();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            ((System.ComponentModel.ISupportInitialize)(this.grdXModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvXModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repModulIconImageCbo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSpace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkModulTree.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvXIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repIconImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIcon16x16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIco32x32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulID)).BeginInit();
            this.grpIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).BeginInit();
            this.panDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLicensed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSystem.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // grdXModul
            //
            this.grdXModul.DataSource = this.qryXModul;
            this.grdXModul.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdXModul.EmbeddedNavigator.Name = "";
            this.grdXModul.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdXModul.Location = new System.Drawing.Point(0, 0);
            this.grdXModul.MainView = this.gvXModul;
            this.grdXModul.Name = "grdXModul";
            this.grdXModul.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repModulIconImageCbo});
            this.grdXModul.Size = new System.Drawing.Size(800, 232);
            this.grdXModul.TabIndex = 0;
            this.grdXModul.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvXModul});
            //
            // qryXModul
            //
            this.qryXModul.CanDelete = true;
            this.qryXModul.CanInsert = true;
            this.qryXModul.CanUpdate = true;
            this.qryXModul.HostControl = this;
            this.qryXModul.SelectStatement = resources.GetString("qryXModul.SelectStatement");
            this.qryXModul.TableName = "XModul";
            this.qryXModul.BeforePost += new System.EventHandler(this.qryXModul_BeforePost);
            this.qryXModul.PositionChanged += new System.EventHandler(this.qryXModul_PositionChanged);
            this.qryXModul.AfterInsert += new System.EventHandler(this.qryXModul_AfterInsert);
            this.qryXModul.BeforeDeleteQuestion += new System.EventHandler(this.qryXModul_BeforeDeleteQuestion);
            this.qryXModul.AfterPost += new System.EventHandler(this.qryXModul_AfterPost);
            this.qryXModul.AfterDelete += new System.EventHandler(this.qryXModul_AfterDelete);
            //
            // gvXModul
            //
            this.gvXModul.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvXModul.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvXModul.Appearance.Empty.Options.UseBackColor = true;
            this.gvXModul.Appearance.Empty.Options.UseFont = true;
            this.gvXModul.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvXModul.Appearance.EvenRow.Options.UseFont = true;
            this.gvXModul.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvXModul.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvXModul.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvXModul.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvXModul.Appearance.FocusedCell.Options.UseFont = true;
            this.gvXModul.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvXModul.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvXModul.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvXModul.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvXModul.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvXModul.Appearance.FocusedRow.Options.UseFont = true;
            this.gvXModul.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvXModul.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvXModul.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvXModul.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvXModul.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvXModul.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvXModul.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvXModul.Appearance.GroupRow.Options.UseFont = true;
            this.gvXModul.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvXModul.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvXModul.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvXModul.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvXModul.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvXModul.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvXModul.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvXModul.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvXModul.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvXModul.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvXModul.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvXModul.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvXModul.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvXModul.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvXModul.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvXModul.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvXModul.Appearance.OddRow.Options.UseFont = true;
            this.gvXModul.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvXModul.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvXModul.Appearance.Row.Options.UseBackColor = true;
            this.gvXModul.Appearance.Row.Options.UseFont = true;
            this.gvXModul.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvXModul.Appearance.SelectedRow.Options.UseFont = true;
            this.gvXModul.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvXModul.Appearance.VertLine.Options.UseBackColor = true;
            this.gvXModul.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvXModul.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colModulIcon,
            this.colModulID,
            this.colName,
            this.colShortName,
            this.colNameSpace,
            this.colModulModulTree,
            this.colModulSystem,
            this.colModulLicensed});
            this.gvXModul.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvXModul.GridControl = this.grdXModul;
            this.gvXModul.Name = "gvXModul";
            this.gvXModul.OptionsBehavior.Editable = false;
            this.gvXModul.OptionsCustomization.AllowFilter = false;
            this.gvXModul.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvXModul.OptionsNavigation.AutoFocusNewRow = true;
            this.gvXModul.OptionsNavigation.UseTabKey = false;
            this.gvXModul.OptionsView.ColumnAutoWidth = false;
            this.gvXModul.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvXModul.OptionsView.ShowGroupPanel = false;
            this.gvXModul.OptionsView.ShowIndicator = false;
            //
            // colModulIcon
            //
            this.colModulIcon.ColumnEdit = this.repModulIconImageCbo;
            this.colModulIcon.FieldName = "XIconID";
            this.colModulIcon.Name = "colModulIcon";
            this.colModulIcon.Visible = true;
            this.colModulIcon.VisibleIndex = 0;
            this.colModulIcon.Width = 22;
            //
            // repModulIconImageCbo
            //
            this.repModulIconImageCbo.AutoHeight = false;
            this.repModulIconImageCbo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repModulIconImageCbo.Name = "repModulIconImageCbo";
            //
            // colModulID
            //
            this.colModulID.Caption = "ID";
            this.colModulID.FieldName = "ModulID";
            this.colModulID.Name = "colModulID";
            this.colModulID.Visible = true;
            this.colModulID.VisibleIndex = 1;
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 300;
            //
            // colShortName
            //
            this.colShortName.Caption = "Kurzname";
            this.colShortName.FieldName = "ShortName";
            this.colShortName.Name = "colShortName";
            this.colShortName.Visible = true;
            this.colShortName.VisibleIndex = 3;
            //
            // colNameSpace
            //
            this.colNameSpace.Caption = "Namespace";
            this.colNameSpace.FieldName = "NameSpace";
            this.colNameSpace.Name = "colNameSpace";
            this.colNameSpace.Visible = true;
            this.colNameSpace.VisibleIndex = 4;
            this.colNameSpace.Width = 180;
            //
            // colModulModulTree
            //
            this.colModulModulTree.Caption = "Modul-Tree";
            this.colModulModulTree.FieldName = "ModulTree";
            this.colModulModulTree.Name = "colModulModulTree";
            this.colModulModulTree.Visible = true;
            this.colModulModulTree.VisibleIndex = 5;
            //
            // colModulSystem
            //
            this.colModulSystem.Caption = "System";
            this.colModulSystem.FieldName = "System";
            this.colModulSystem.Name = "colModulSystem";
            this.colModulSystem.Visible = true;
            this.colModulSystem.VisibleIndex = 6;
            //
            // colModulLicensed
            //
            this.colModulLicensed.Caption = "Lizenziert";
            this.colModulLicensed.FieldName = "Licensed";
            this.colModulLicensed.Name = "colModulLicensed";
            this.colModulLicensed.Visible = true;
            this.colModulLicensed.VisibleIndex = 7;
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(9, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name";
            //
            // lblShortName
            //
            this.lblShortName.Location = new System.Drawing.Point(9, 62);
            this.lblShortName.Name = "lblShortName";
            this.lblShortName.Size = new System.Drawing.Size(100, 23);
            this.lblShortName.TabIndex = 8;
            this.lblShortName.Text = "Kurzname";
            //
            // edtName
            //
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryXModul;
            this.edtName.Location = new System.Drawing.Point(115, 39);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(676, 24);
            this.edtName.TabIndex = 7;
            //
            // edtShortName
            //
            this.edtShortName.DataMember = "ShortName";
            this.edtShortName.DataSource = this.qryXModul;
            this.edtShortName.Location = new System.Drawing.Point(115, 62);
            this.edtShortName.Name = "edtShortName";
            this.edtShortName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtShortName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtShortName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtShortName.Properties.Appearance.Options.UseBackColor = true;
            this.edtShortName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtShortName.Properties.Appearance.Options.UseFont = true;
            this.edtShortName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtShortName.Size = new System.Drawing.Size(64, 24);
            this.edtShortName.TabIndex = 9;
            //
            // edtNameSpace
            //
            this.edtNameSpace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNameSpace.DataMember = "NameSpace";
            this.edtNameSpace.DataSource = this.qryXModul;
            this.edtNameSpace.Location = new System.Drawing.Point(115, 85);
            this.edtNameSpace.Name = "edtNameSpace";
            this.edtNameSpace.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameSpace.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameSpace.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameSpace.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameSpace.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameSpace.Properties.Appearance.Options.UseFont = true;
            this.edtNameSpace.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameSpace.Size = new System.Drawing.Size(676, 24);
            this.edtNameSpace.TabIndex = 11;
            //
            // lblNameSpace
            //
            this.lblNameSpace.Location = new System.Drawing.Point(9, 85);
            this.lblNameSpace.Name = "lblNameSpace";
            this.lblNameSpace.Size = new System.Drawing.Size(100, 23);
            this.lblNameSpace.TabIndex = 10;
            this.lblNameSpace.Text = "Namespace";
            //
            // chkModulTree
            //
            this.chkModulTree.DataMember = "ModulTree";
            this.chkModulTree.DataSource = this.qryXModul;
            this.chkModulTree.Location = new System.Drawing.Point(191, 11);
            this.chkModulTree.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.chkModulTree.Name = "chkModulTree";
            this.chkModulTree.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkModulTree.Properties.Appearance.Options.UseBackColor = true;
            this.chkModulTree.Properties.Caption = "Modul-Tree";
            this.chkModulTree.Size = new System.Drawing.Size(100, 19);
            this.chkModulTree.TabIndex = 3;
            //
            // qryIcon
            //
            this.qryIcon.CanUpdate = true;
            this.qryIcon.HostControl = this;
            this.qryIcon.TableName = "XIcon";
            this.qryIcon.PositionChanged += new System.EventHandler(this.qryIcon_PositionChanged);
            this.qryIcon.AfterFill += new System.EventHandler(this.qryIcon_AfterFill);
            //
            // grdXIcon
            //
            this.grdXIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grdXIcon.DataSource = this.qryIcon;
            this.grdXIcon.EmbeddedNavigator.Name = "";
            this.grdXIcon.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdXIcon.Location = new System.Drawing.Point(115, 171);
            this.grdXIcon.MainView = this.gvXIcon;
            this.grdXIcon.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.grdXIcon.Name = "grdXIcon";
            this.grdXIcon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repIconImage});
            this.grdXIcon.Size = new System.Drawing.Size(288, 120);
            this.grdXIcon.TabIndex = 15;
            this.grdXIcon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvXIcon});
            //
            // gvXIcon
            //
            this.gvXIcon.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvXIcon.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvXIcon.Appearance.Empty.Options.UseBackColor = true;
            this.gvXIcon.Appearance.Empty.Options.UseFont = true;
            this.gvXIcon.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvXIcon.Appearance.EvenRow.Options.UseFont = true;
            this.gvXIcon.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvXIcon.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvXIcon.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvXIcon.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvXIcon.Appearance.FocusedCell.Options.UseFont = true;
            this.gvXIcon.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvXIcon.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvXIcon.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvXIcon.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvXIcon.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvXIcon.Appearance.FocusedRow.Options.UseFont = true;
            this.gvXIcon.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvXIcon.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvXIcon.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvXIcon.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvXIcon.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvXIcon.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvXIcon.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvXIcon.Appearance.GroupRow.Options.UseFont = true;
            this.gvXIcon.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvXIcon.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvXIcon.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvXIcon.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvXIcon.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvXIcon.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvXIcon.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvXIcon.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvXIcon.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvXIcon.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvXIcon.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvXIcon.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvXIcon.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvXIcon.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvXIcon.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvXIcon.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvXIcon.Appearance.OddRow.Options.UseFont = true;
            this.gvXIcon.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvXIcon.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvXIcon.Appearance.Row.Options.UseBackColor = true;
            this.gvXIcon.Appearance.Row.Options.UseFont = true;
            this.gvXIcon.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvXIcon.Appearance.SelectedRow.Options.UseFont = true;
            this.gvXIcon.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvXIcon.Appearance.VertLine.Options.UseBackColor = true;
            this.gvXIcon.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvXIcon.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIconImage,
            this.colIconName});
            this.gvXIcon.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvXIcon.GridControl = this.grdXIcon;
            this.gvXIcon.Name = "gvXIcon";
            this.gvXIcon.OptionsBehavior.Editable = false;
            this.gvXIcon.OptionsCustomization.AllowFilter = false;
            this.gvXIcon.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvXIcon.OptionsNavigation.AutoFocusNewRow = true;
            this.gvXIcon.OptionsNavigation.UseTabKey = false;
            this.gvXIcon.OptionsView.ColumnAutoWidth = false;
            this.gvXIcon.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvXIcon.OptionsView.ShowGroupPanel = false;
            this.gvXIcon.OptionsView.ShowIndicator = false;
            //
            // colIconImage
            //
            this.colIconImage.ColumnEdit = this.repIconImage;
            this.colIconImage.FieldName = "Icon";
            this.colIconImage.Name = "colIconImage";
            this.colIconImage.Visible = true;
            this.colIconImage.VisibleIndex = 0;
            this.colIconImage.Width = 22;
            //
            // repIconImage
            //
            this.repIconImage.Name = "repIconImage";
            //
            // colIconName
            //
            this.colIconName.Caption = "Name";
            this.colIconName.FieldName = "Name";
            this.colIconName.Name = "colIconName";
            this.colIconName.Visible = true;
            this.colIconName.VisibleIndex = 1;
            this.colIconName.Width = 220;
            //
            // picIconSmall
            //
            this.picIconSmall.BackColor = System.Drawing.Color.White;
            this.picIconSmall.Location = new System.Drawing.Point(101, 32);
            this.picIconSmall.Name = "picIconSmall";
            this.picIconSmall.Size = new System.Drawing.Size(16, 16);
            this.picIconSmall.TabIndex = 12;
            this.picIconSmall.TabStop = false;
            //
            // picIconLarge
            //
            this.picIconLarge.BackColor = System.Drawing.Color.White;
            this.picIconLarge.Location = new System.Drawing.Point(94, 56);
            this.picIconLarge.Name = "picIconLarge";
            this.picIconLarge.Size = new System.Drawing.Size(32, 32);
            this.picIconLarge.TabIndex = 11;
            this.picIconLarge.TabStop = false;
            //
            // btnLoadImage
            //
            this.btnLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadImage.Image = global::KiSS4.DesignerHost.Properties.Resources.OpenFile;
            this.btnLoadImage.Location = new System.Drawing.Point(138, 60);
            this.btnLoadImage.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.btnLoadImage.Size = new System.Drawing.Size(24, 24);
            this.btnLoadImage.TabIndex = 2;
            this.btnLoadImage.UseVisualStyleBackColor = false;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            //
            // lblIcon
            //
            this.lblIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIcon.Location = new System.Drawing.Point(9, 171);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(100, 23);
            this.lblIcon.TabIndex = 14;
            this.lblIcon.Text = "Icon";
            //
            // dlgOpenFile
            //
            this.dlgOpenFile.Filter = "Icon (*.ico)|*.ico|Alle Dateien|*.*";
            //
            // lblIcon16x16
            //
            this.lblIcon16x16.Location = new System.Drawing.Point(16, 27);
            this.lblIcon16x16.Name = "lblIcon16x16";
            this.lblIcon16x16.Size = new System.Drawing.Size(72, 24);
            this.lblIcon16x16.TabIndex = 0;
            this.lblIcon16x16.Text = "Icon 16x16";
            //
            // lblIco32x32
            //
            this.lblIco32x32.Location = new System.Drawing.Point(16, 60);
            this.lblIco32x32.Name = "lblIco32x32";
            this.lblIco32x32.Size = new System.Drawing.Size(72, 24);
            this.lblIco32x32.TabIndex = 1;
            this.lblIco32x32.Text = "Icon 32x32";
            //
            // edtModulID
            //
            this.edtModulID.DataMember = "ModulID";
            this.edtModulID.DataSource = this.qryXModul;
            this.edtModulID.Location = new System.Drawing.Point(115, 9);
            this.edtModulID.Name = "edtModulID";
            this.edtModulID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtModulID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModulID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulID.Properties.Appearance.Options.UseBackColor = true;
            this.edtModulID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModulID.Properties.Appearance.Options.UseFont = true;
            this.edtModulID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtModulID.Size = new System.Drawing.Size(64, 24);
            this.edtModulID.TabIndex = 2;
            //
            // lblModulID
            //
            this.lblModulID.Location = new System.Drawing.Point(9, 9);
            this.lblModulID.Name = "lblModulID";
            this.lblModulID.Size = new System.Drawing.Size(100, 23);
            this.lblModulID.TabIndex = 1;
            this.lblModulID.Text = "ID";
            //
            // grpIcon
            //
            this.grpIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpIcon.Controls.Add(this.picIconSmall);
            this.grpIcon.Controls.Add(this.lblIcon16x16);
            this.grpIcon.Controls.Add(this.lblIco32x32);
            this.grpIcon.Controls.Add(this.picIconLarge);
            this.grpIcon.Controls.Add(this.btnLoadImage);
            this.grpIcon.Location = new System.Drawing.Point(415, 171);
            this.grpIcon.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.grpIcon.Name = "grpIcon";
            this.grpIcon.Size = new System.Drawing.Size(190, 104);
            this.grpIcon.TabIndex = 1;
            this.grpIcon.TabStop = false;
            this.grpIcon.Text = "Icon anzeigen und importieren";
            //
            // edtDescription
            //
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.DataMember = "Description";
            this.edtDescription.DataSource = this.qryXModul;
            this.edtDescription.Location = new System.Drawing.Point(115, 115);
            this.edtDescription.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDescription.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDescription.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDescription.Properties.Appearance.Options.UseBackColor = true;
            this.edtDescription.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDescription.Properties.Appearance.Options.UseFont = true;
            this.edtDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDescription.Size = new System.Drawing.Size(676, 50);
            this.edtDescription.TabIndex = 13;
            //
            // lblDescription
            //
            this.lblDescription.Location = new System.Drawing.Point(9, 115);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 23);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Beschreibung";
            //
            // panDetails
            //
            this.panDetails.Controls.Add(this.lblModulID);
            this.panDetails.Controls.Add(this.grdXIcon);
            this.panDetails.Controls.Add(this.lblName);
            this.panDetails.Controls.Add(this.lblDescription);
            this.panDetails.Controls.Add(this.lblShortName);
            this.panDetails.Controls.Add(this.edtDescription);
            this.panDetails.Controls.Add(this.edtName);
            this.panDetails.Controls.Add(this.grpIcon);
            this.panDetails.Controls.Add(this.edtShortName);
            this.panDetails.Controls.Add(this.edtModulID);
            this.panDetails.Controls.Add(this.edtNameSpace);
            this.panDetails.Controls.Add(this.lblNameSpace);
            this.panDetails.Controls.Add(this.lblIcon);
            this.panDetails.Controls.Add(this.chkLicensed);
            this.panDetails.Controls.Add(this.chkSystem);
            this.panDetails.Controls.Add(this.chkModulTree);
            this.panDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetails.Location = new System.Drawing.Point(0, 240);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(800, 300);
            this.panDetails.TabIndex = 2;
            //
            // chkLicensed
            //
            this.chkLicensed.DataMember = "Licensed";
            this.chkLicensed.DataSource = this.qryXModul;
            this.chkLicensed.Location = new System.Drawing.Point(415, 11);
            this.chkLicensed.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.chkLicensed.Name = "chkLicensed";
            this.chkLicensed.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkLicensed.Properties.Appearance.Options.UseBackColor = true;
            this.chkLicensed.Properties.Caption = "Lizenziert";
            this.chkLicensed.Size = new System.Drawing.Size(100, 19);
            this.chkLicensed.TabIndex = 5;
            //
            // chkSystem
            //
            this.chkSystem.DataMember = "System";
            this.chkSystem.DataSource = this.qryXModul;
            this.chkSystem.Location = new System.Drawing.Point(303, 11);
            this.chkSystem.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.chkSystem.Name = "chkSystem";
            this.chkSystem.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSystem.Properties.Appearance.Options.UseBackColor = true;
            this.chkSystem.Properties.Caption = "System";
            this.chkSystem.Size = new System.Drawing.Size(100, 19);
            this.chkSystem.TabIndex = 4;
            //
            // splitter
            //
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.panDetails;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 232);
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            //
            // CtlModul
            //
            this.ActiveSQLQuery = this.qryXModul;
            this.Controls.Add(this.grdXModul);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.panDetails);
            this.Name = "CtlModul";
            this.Size = new System.Drawing.Size(800, 540);
            this.Load += new System.EventHandler(this.CtlModul_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdXModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvXModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repModulIconImageCbo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSpace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkModulTree.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvXIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repIconImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIcon16x16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIco32x32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulID)).EndInit();
            this.grpIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).EndInit();
            this.panDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkLicensed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSystem.Properties)).EndInit();
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

        private void CtlModul_Load(object sender, EventArgs e)
        {
            // setup title of dialog
            dlgOpenFile.Title = KissMsg.GetMLMessage("CtlModul", "ImportIconDialogTitle_v01", "Zu importierendes Icon auswählen");
        }

        private void btnLoadImage_Click(object sender, System.EventArgs e)
        {
            if (this.dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                BinaryReader br = new BinaryReader(dlgOpenFile.OpenFile());
                this.qryIcon["Icon"] = br.ReadBytes(0xFFFF);
                br.Close();

                if (DBUtil.IsEmpty(this.edtName.EditValue))
                {
                    this.edtName.EditValue = new FileInfo(dlgOpenFile.FileName).Name;
                }

                this.qryXModul.RowModified = true;
                this.DisplayImage();
            }
        }

        private void qryIcon_AfterFill(object sender, System.EventArgs e)
        {
            this.picIconSmall.Image = null;
            this.picIconLarge.Image = null;

            this.btnLoadImage.Enabled = this.qryXModul.CanUpdate && this.qryIcon.Count > 0;
        }

        private void qryIcon_PositionChanged(object sender, System.EventArgs e)
        {
            this.DisplayImage();
        }

        private void qryXModul_AfterDelete(object sender, System.EventArgs e)
        {
            FormController.SendMessage("FrmDesigner", "Action", "RefreshTree");
        }

        private void qryXModul_AfterInsert(object sender, System.EventArgs e)
        {
            this.qryXModul["NameSpace"] = "KiSS4.";

            this.edtName.Focus();
        }

        private void qryXModul_AfterPost(object sender, System.EventArgs e)
        {
            if (Convert.ToBoolean(this.qryXModul["ModulTree"]))
            {
                DBUtil.ExecSQL(@"
                    INSERT INTO dbo.XIcon (XIconID, Name)
                      SELECT TMP.IconID + (100 * {0}),
                             TMP.Name
                      FROM (SELECT IconID = 1000,
                                   Name   = 'leer'
                            UNION

                            SELECT IconID = 1001,
                                   Name   = 'offen'
                            UNION

                            SELECT IconID = 1002,
                                   Name   = 'geschlossen'

                            UNION

                            SELECT IconID = 1003,
                                   Name   = 'archiviert') TMP
                      WHERE NOT EXISTS (SELECT TOP 1 1
                                        FROM dbo.XIcon WITH (READUNCOMMITTED)
                                        WHERE XIconID = TMP.IconID + (100 * {0}))", this.qryXModul["ModulID"]);

                this.qryXModul_PositionChanged(sender, e);
            }

            FormController.SendMessage("FrmDesigner", "Action", "RefreshTree");
        }

        private void qryXModul_BeforeDeleteQuestion(object sender, System.EventArgs e)
        {
            if (Convert.ToBoolean(this.qryXModul["System"]))
            {
                throw new KissCancelException();
            }
        }

        private void qryXModul_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtModulID, lblModulID.Text);
            DBUtil.CheckNotNullField(edtName, lblName.Text);

            if (Convert.ToBoolean(this.qryXModul["ModulTree"]))
            {
                DBUtil.CheckNotNullField(this.edtShortName, this.lblShortName.Text);
            }
        }

        private void qryXModul_PositionChanged(object sender, System.EventArgs e)
        {
            this.qryIcon.Post();

            if (DBUtil.IsEmpty(qryXModul["ModulID"]) || Convert.ToInt32(qryXModul["ModulID"]) < 1)
            {
                this.qryIcon.Fill(@"
                    SELECT *
                    FROM dbo.XIcon WITH (READUNCOMMITTED)
                    WHERE XIconID < 0");
            }
            else
            {
                this.qryIcon.Fill(@"
                    SELECT *
                    FROM dbo.XIcon WITH (READUNCOMMITTED)
                    WHERE XIconID BETWEEN (1000 + 100 * {0}) AND
                          (1009 + 100 * {0})", qryXModul["ModulID"]);
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void DisplayImage()
        {
            this.picIconLarge.Image = null;
            this.picIconSmall.Image = null;

            if (this.qryIcon["Icon"] == DBNull.Value)
            {
                return;
            }

            try
            {
                Icon ico = new Icon(new MemoryStream((byte[])this.qryIcon["Icon"], false));

                this.picIconLarge.Image = KissImageList.ResizeIcon(ico, 32, 32);
                this.picIconSmall.Image = KissImageList.ResizeIcon(ico, 16, 16);
            }
            catch
            {
                this.picIconLarge.Image = new System.Drawing.Bitmap(new MemoryStream((byte[])this.qryIcon["Icon"], false));
            }
        }

        private void SetupRights()
        {
            // only BIAGAdmin can use this control
            if (!Session.User.IsUserBIAGAdmin)
            {
                // no rights to view this control
                throw new Exception("No rights to view details of this control.");
            }
        }

        #endregion

        #endregion
    }
}