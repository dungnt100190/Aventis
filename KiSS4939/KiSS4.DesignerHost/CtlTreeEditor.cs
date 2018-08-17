using System;
using System.Data;
using System.Windows.Forms;

using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.DesignerHost
{
    /// <summary>
    /// Summary description for CtlTreeEditor.
    /// </summary>
    public class CtlTreeEditor : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _currentModulID;
        private object _currentNodeID;
        private object _currentParent;
        private int _currentSortKey;
        private bool _isRefreshingTree = false;
        private int _preventRefreshCount = 0;
        private KissButton btnCollapseAll;
        private KiSS4.Gui.KissButton btnDown;
        private KissButton btnExpandAll;
        private KiSS4.Gui.KissButton btnLeft;
        private KiSS4.Gui.KissButton btnRight;
        private KiSS4.Gui.KissButton btnUp;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSortKey;
        private System.ComponentModel.IContainer components;
        private CtlXRight ctlXRight;
        private KiSS4.Gui.KissCheckEdit edtActive;
        private KiSS4.Gui.KissLookUpEdit edtClassName;
        private KiSS4.Gui.KissMemoEdit edtInsert;
        private KissLookUpEdit edtMaskName;
        private KiSS4.Gui.KissLookUpEdit edtModulID;
        private KiSS4.Gui.KissLookUpEdit edtModulTreeCode;
        private KiSS4.Gui.KissCalcEdit edtModulTreeID;
        private KiSS4.Gui.KissMemoEdit edtModulTree_Value1;
        private KiSS4.Gui.KissTextEditML edtNameML;
        private KiSS4.Gui.KissMemoEdit edtSQLPreExecute;
        private KiSS4.Gui.KissImageComboBoxEdit edtXIconID;
        private KiSS4.Gui.KissLabel lblActive;
        private KiSS4.Gui.KissLabel lblClassName;
        private KiSS4.Gui.KissLabel lblModulID;
        private KiSS4.Gui.KissLabel lblModulTreeCode;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblSQLPreExecute;
        private KiSS4.Gui.KissLabel lblXIconID;
        private System.Windows.Forms.Panel panDetailsSQL;
        private System.Windows.Forms.Panel panTree;
        private System.Windows.Forms.Panel panTreeBottom;
        private System.Windows.Forms.Panel panTreeTop;
        private KiSS4.DB.SqlQuery qryXModulTree;
        private KiSS4.DB.SqlQuery qryXModulTree_TreeSource;
        private KiSS4.Gui.KissSplitter splitterSQL;
        private KiSS4.Gui.KissSplitterCollapsible splitterTree;
        private KissTabControlEx tabTreeEditor;
        private SharpLibrary.WinControls.TabPageEx tpgTreeDetails;
        private SharpLibrary.WinControls.TabPageEx tpgXRight;
        private KiSS4.Gui.KissTree treModulTree;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a treeeditor which can only edit the tree of the given module
        /// </summary>
        /// <param name="modulID"></param>
        public CtlTreeEditor(int modulID)
            : this()
        {
            SetModul(modulID);
        }

        /// <summary>
        /// Creates a treeeditor which can edit all trees
        /// </summary>
        public CtlTreeEditor()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // setup control depending on rights
            SetupRights();

            this.treModulTree.SelectImageList = KissImageList.SmallImageList;
            this.treModulTree.ImageIndexFieldName = "ImageIndex";

            LookUpModules();
            LookUpClasses();

            // do some control handling
            this.tabTreeEditor.Resize -= new EventHandler(tabTreeEditor_Resize);

            if (Session.SupportDynaMask)
            {
                LookUpMaskName();

                tabTreeEditor_Resize(this, EventArgs.Empty);
                this.tabTreeEditor.Resize += new EventHandler(tabTreeEditor_Resize);
            }
            else
            {
                this.edtMaskName.Visible = false;
                this.edtClassName.Width = this.edtXIconID.Width;
            }

            this.edtModulID.EditValue = 1;
            KissImageList.FillIconsIntoComboBox(edtXIconID);
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlTreeEditor));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtXIconID = new KiSS4.Gui.KissImageComboBoxEdit();
            this.qryXModulTree = new KiSS4.DB.SqlQuery(this.components);
            this.lblName = new KiSS4.Gui.KissLabel();
            this.lblXIconID = new KiSS4.Gui.KissLabel();
            this.lblClassName = new KiSS4.Gui.KissLabel();
            this.lblSQLPreExecute = new KiSS4.Gui.KissLabel();
            this.lblModulTreeCode = new KiSS4.Gui.KissLabel();
            this.edtClassName = new KiSS4.Gui.KissLookUpEdit();
            this.edtSQLPreExecute = new KiSS4.Gui.KissMemoEdit();
            this.edtInsert = new KiSS4.Gui.KissMemoEdit();
            this.panTree = new System.Windows.Forms.Panel();
            this.treModulTree = new KiSS4.Gui.KissTree();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSortKey = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.qryXModulTree_TreeSource = new KiSS4.DB.SqlQuery(this.components);
            this.panTreeTop = new System.Windows.Forms.Panel();
            this.edtModulID = new KiSS4.Gui.KissLookUpEdit();
            this.lblModulID = new KiSS4.Gui.KissLabel();
            this.panTreeBottom = new System.Windows.Forms.Panel();
            this.btnCollapseAll = new KiSS4.Gui.KissButton();
            this.btnExpandAll = new KiSS4.Gui.KissButton();
            this.btnUp = new KiSS4.Gui.KissButton();
            this.btnLeft = new KiSS4.Gui.KissButton();
            this.btnDown = new KiSS4.Gui.KissButton();
            this.btnRight = new KiSS4.Gui.KissButton();
            this.tabTreeEditor = new KiSS4.Gui.KissTabControlEx();
            this.tpgTreeDetails = new SharpLibrary.WinControls.TabPageEx();
            this.edtMaskName = new KiSS4.Gui.KissLookUpEdit();
            this.edtModulTreeCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtNameML = new KiSS4.Gui.KissTextEditML();
            this.edtModulTreeID = new KiSS4.Gui.KissCalcEdit();
            this.edtActive = new KiSS4.Gui.KissCheckEdit();
            this.lblActive = new KiSS4.Gui.KissLabel();
            this.panDetailsSQL = new System.Windows.Forms.Panel();
            this.splitterSQL = new KiSS4.Gui.KissSplitter();
            this.edtModulTree_Value1 = new KiSS4.Gui.KissMemoEdit();
            this.tpgXRight = new SharpLibrary.WinControls.TabPageEx();
            this.ctlXRight = new KiSS4.DesignerHost.CtlXRight();
            this.splitterTree = new KiSS4.Gui.KissSplitterCollapsible();
            ((System.ComponentModel.ISupportInitialize)(this.edtXIconID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXModulTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblXIconID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClassName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSQLPreExecute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulTreeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClassName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClassName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSQLPreExecute.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInsert.Properties)).BeginInit();
            this.panTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treModulTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXModulTree_TreeSource)).BeginInit();
            this.panTreeTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulID)).BeginInit();
            this.panTreeBottom.SuspendLayout();
            this.tabTreeEditor.SuspendLayout();
            this.tpgTreeDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaskName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaskName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulTreeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulTreeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameML.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulTreeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblActive)).BeginInit();
            this.panDetailsSQL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulTree_Value1.Properties)).BeginInit();
            this.tpgXRight.SuspendLayout();
            this.SuspendLayout();
            //
            // edtXIconID
            //
            this.edtXIconID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtXIconID.DataMember = "XIconID";
            this.edtXIconID.DataSource = this.qryXModulTree;
            this.edtXIconID.Location = new System.Drawing.Point(148, 41);
            this.edtXIconID.Name = "edtXIconID";
            this.edtXIconID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtXIconID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtXIconID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtXIconID.Properties.Appearance.Options.UseBackColor = true;
            this.edtXIconID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtXIconID.Properties.Appearance.Options.UseFont = true;
            this.edtXIconID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtXIconID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtXIconID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtXIconID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtXIconID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtXIconID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtXIconID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtXIconID.Size = new System.Drawing.Size(316, 24);
            this.edtXIconID.TabIndex = 4;
            //
            // qryXModulTree
            //
            this.qryXModulTree.HostControl = this;
            this.qryXModulTree.TableName = "XModulTree";
            this.qryXModulTree.PostCompleted += new System.EventHandler(this.qryXModulTree_PostCompleted);
            this.qryXModulTree.PositionChanged += new System.EventHandler(this.qryXModulTree_PositionChanged);
            this.qryXModulTree.AfterInsert += new System.EventHandler(this.qryXModulTree_AfterInsert);
            this.qryXModulTree.BeforeInsert += new System.EventHandler(this.qryXModulTree_BeforeInsert);
            this.qryXModulTree.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryXModulTree_ColumnChanged);
            this.qryXModulTree.AfterDelete += new System.EventHandler(this.qryXModulTree_AfterDelete);
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(6, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(136, 24);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            //
            // lblXIconID
            //
            this.lblXIconID.Location = new System.Drawing.Point(6, 41);
            this.lblXIconID.Name = "lblXIconID";
            this.lblXIconID.Size = new System.Drawing.Size(136, 24);
            this.lblXIconID.TabIndex = 3;
            this.lblXIconID.Text = "Icon";
            //
            // lblClassName
            //
            this.lblClassName.Location = new System.Drawing.Point(6, 71);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(136, 24);
            this.lblClassName.TabIndex = 5;
            this.lblClassName.Text = "Klassenname";
            //
            // lblSQLPreExecute
            //
            this.lblSQLPreExecute.Location = new System.Drawing.Point(6, 126);
            this.lblSQLPreExecute.Name = "lblSQLPreExecute";
            this.lblSQLPreExecute.Size = new System.Drawing.Size(136, 24);
            this.lblSQLPreExecute.TabIndex = 10;
            this.lblSQLPreExecute.Text = "SQL vor Ausführen";
            //
            // lblModulTreeCode
            //
            this.lblModulTreeCode.Location = new System.Drawing.Point(6, 190);
            this.lblModulTreeCode.Name = "lblModulTreeCode";
            this.lblModulTreeCode.Size = new System.Drawing.Size(136, 24);
            this.lblModulTreeCode.TabIndex = 12;
            this.lblModulTreeCode.Text = "SQL Insert";
            //
            // edtClassName
            //
            this.edtClassName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtClassName.DataMember = "ClassName";
            this.edtClassName.DataSource = this.qryXModulTree;
            this.edtClassName.Location = new System.Drawing.Point(148, 71);
            this.edtClassName.Name = "edtClassName";
            this.edtClassName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtClassName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtClassName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtClassName.Properties.Appearance.Options.UseBackColor = true;
            this.edtClassName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtClassName.Properties.Appearance.Options.UseFont = true;
            this.edtClassName.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtClassName.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtClassName.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtClassName.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtClassName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtClassName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtClassName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtClassName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtClassName.Properties.DisplayMember = "Text";
            this.edtClassName.Properties.NullText = "";
            this.edtClassName.Properties.ShowFooter = false;
            this.edtClassName.Properties.ShowHeader = false;
            this.edtClassName.Properties.ValueMember = "Code";
            this.edtClassName.Size = new System.Drawing.Size(84, 24);
            this.edtClassName.TabIndex = 6;
            //
            // edtSQLPreExecute
            //
            this.edtSQLPreExecute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSQLPreExecute.DataMember = "sqlPreExecute";
            this.edtSQLPreExecute.DataSource = this.qryXModulTree;
            this.edtSQLPreExecute.Location = new System.Drawing.Point(148, 126);
            this.edtSQLPreExecute.Name = "edtSQLPreExecute";
            this.edtSQLPreExecute.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSQLPreExecute.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSQLPreExecute.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSQLPreExecute.Properties.Appearance.Options.UseBackColor = true;
            this.edtSQLPreExecute.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSQLPreExecute.Properties.Appearance.Options.UseFont = true;
            this.edtSQLPreExecute.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSQLPreExecute.ProportionalFont = false;
            this.edtSQLPreExecute.Size = new System.Drawing.Size(316, 58);
            this.edtSQLPreExecute.TabIndex = 11;
            //
            // edtInsert
            //
            this.edtInsert.DataMember = "sqlInsertTreeItem";
            this.edtInsert.DataSource = this.qryXModulTree;
            this.edtInsert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtInsert.Location = new System.Drawing.Point(0, 115);
            this.edtInsert.Name = "edtInsert";
            this.edtInsert.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInsert.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInsert.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtInsert.Properties.Appearance.Options.UseBackColor = true;
            this.edtInsert.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInsert.Properties.Appearance.Options.UseFont = true;
            this.edtInsert.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtInsert.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.edtInsert.Properties.WordWrap = false;
            this.edtInsert.ProportionalFont = false;
            this.edtInsert.Size = new System.Drawing.Size(455, 168);
            this.edtInsert.TabIndex = 2;
            //
            // panTree
            //
            this.panTree.Controls.Add(this.treModulTree);
            this.panTree.Controls.Add(this.panTreeTop);
            this.panTree.Controls.Add(this.panTreeBottom);
            this.panTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.panTree.Location = new System.Drawing.Point(0, 0);
            this.panTree.Name = "panTree";
            this.panTree.Size = new System.Drawing.Size(304, 550);
            this.panTree.TabIndex = 0;
            this.panTree.SizeChanged += new System.EventHandler(this.panTree_SizeChanged);
            //
            // treModulTree
            //
            this.treModulTree.AllowDrop = true;
            this.treModulTree.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treModulTree.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treModulTree.Appearance.Empty.Options.UseBackColor = true;
            this.treModulTree.Appearance.Empty.Options.UseForeColor = true;
            this.treModulTree.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treModulTree.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treModulTree.Appearance.EvenRow.Options.UseBackColor = true;
            this.treModulTree.Appearance.EvenRow.Options.UseForeColor = true;
            this.treModulTree.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treModulTree.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treModulTree.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treModulTree.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treModulTree.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treModulTree.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treModulTree.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treModulTree.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treModulTree.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treModulTree.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treModulTree.Appearance.FooterPanel.Options.UseFont = true;
            this.treModulTree.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treModulTree.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treModulTree.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treModulTree.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treModulTree.Appearance.GroupButton.Options.UseBackColor = true;
            this.treModulTree.Appearance.GroupButton.Options.UseFont = true;
            this.treModulTree.Appearance.GroupButton.Options.UseForeColor = true;
            this.treModulTree.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treModulTree.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treModulTree.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treModulTree.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treModulTree.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treModulTree.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treModulTree.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treModulTree.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treModulTree.Appearance.HeaderPanel.Options.UseFont = true;
            this.treModulTree.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treModulTree.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treModulTree.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treModulTree.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treModulTree.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treModulTree.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treModulTree.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treModulTree.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treModulTree.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treModulTree.Appearance.HorzLine.Options.UseBackColor = true;
            this.treModulTree.Appearance.HorzLine.Options.UseForeColor = true;
            this.treModulTree.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treModulTree.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treModulTree.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treModulTree.Appearance.OddRow.Options.UseBackColor = true;
            this.treModulTree.Appearance.OddRow.Options.UseFont = true;
            this.treModulTree.Appearance.OddRow.Options.UseForeColor = true;
            this.treModulTree.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treModulTree.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treModulTree.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treModulTree.Appearance.Preview.Options.UseBackColor = true;
            this.treModulTree.Appearance.Preview.Options.UseFont = true;
            this.treModulTree.Appearance.Preview.Options.UseForeColor = true;
            this.treModulTree.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treModulTree.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treModulTree.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treModulTree.Appearance.Row.Options.UseBackColor = true;
            this.treModulTree.Appearance.Row.Options.UseFont = true;
            this.treModulTree.Appearance.Row.Options.UseForeColor = true;
            this.treModulTree.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treModulTree.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treModulTree.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treModulTree.Appearance.TreeLine.Options.UseBackColor = true;
            this.treModulTree.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treModulTree.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treModulTree.Appearance.VertLine.Options.UseBackColor = true;
            this.treModulTree.Appearance.VertLine.Options.UseForeColor = true;
            this.treModulTree.Appearance.VertLine.Options.UseTextOptions = true;
            this.treModulTree.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treModulTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName,
            this.colSortKey});
            this.treModulTree.DataSource = this.qryXModulTree_TreeSource;
            this.treModulTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treModulTree.ImageIndexFieldName = "XIconID";
            this.treModulTree.KeyFieldName = "ModulTreeID";
            this.treModulTree.Location = new System.Drawing.Point(0, 56);
            this.treModulTree.Name = "treModulTree";
            this.treModulTree.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treModulTree.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treModulTree.OptionsBehavior.DragNodes = true;
            this.treModulTree.OptionsBehavior.Editable = false;
            this.treModulTree.OptionsBehavior.KeepSelectedOnClick = false;
            this.treModulTree.OptionsBehavior.MoveOnEdit = false;
            this.treModulTree.OptionsMenu.EnableColumnMenu = false;
            this.treModulTree.OptionsMenu.EnableFooterMenu = false;
            this.treModulTree.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treModulTree.OptionsView.AutoWidth = false;
            this.treModulTree.OptionsView.EnableAppearanceEvenRow = true;
            this.treModulTree.OptionsView.EnableAppearanceOddRow = true;
            this.treModulTree.OptionsView.ShowIndicator = false;
            this.treModulTree.ParentFieldName = "ModulTreeID_Parent";
            this.treModulTree.RootValue = null;
            this.treModulTree.Size = new System.Drawing.Size(304, 454);
            this.treModulTree.TabIndex = 1;
            this.treModulTree.AfterDragNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeEditor_AfterDragNode);
            this.treModulTree.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treModulTree_FocusedNodeChanged);
            this.treModulTree.BeforeDragNode += new DevExpress.XtraTreeList.BeforeDragNodeEventHandler(this.treModulTree_BeforeDragNode);
            this.treModulTree.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.treModulTree_BeforeFocusNode);
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "TranslatedName";
            this.colName.MinWidth = 64;
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowSort = false;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 257;
            //
            // colSortKey
            //
            this.colSortKey.Caption = "SortKey";
            this.colSortKey.FieldName = "SortKey";
            this.colSortKey.Name = "colSortKey";
            this.colSortKey.OptionsColumn.AllowSort = false;
            //
            // qryXModulTree_TreeSource
            //
            this.qryXModulTree_TreeSource.HostControl = this;
            this.qryXModulTree_TreeSource.TableName = "XModulTree";
            this.qryXModulTree_TreeSource.AfterFill += new System.EventHandler(this.qryXModulTree_TreeSource_AfterFill);
            //
            // panTreeTop
            //
            this.panTreeTop.Controls.Add(this.edtModulID);
            this.panTreeTop.Controls.Add(this.lblModulID);
            this.panTreeTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTreeTop.Location = new System.Drawing.Point(0, 0);
            this.panTreeTop.Name = "panTreeTop";
            this.panTreeTop.Size = new System.Drawing.Size(304, 56);
            this.panTreeTop.TabIndex = 0;
            //
            // edtModulID
            //
            this.edtModulID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtModulID.Location = new System.Drawing.Point(72, 16);
            this.edtModulID.Name = "edtModulID";
            this.edtModulID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtModulID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModulID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulID.Properties.Appearance.Options.UseBackColor = true;
            this.edtModulID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModulID.Properties.Appearance.Options.UseFont = true;
            this.edtModulID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtModulID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtModulID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtModulID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtModulID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtModulID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtModulID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtModulID.Properties.DisplayMember = "Text";
            this.edtModulID.Properties.NullText = "";
            this.edtModulID.Properties.ShowFooter = false;
            this.edtModulID.Properties.ShowHeader = false;
            this.edtModulID.Properties.ValueMember = "Code";
            this.edtModulID.Size = new System.Drawing.Size(219, 24);
            this.edtModulID.TabIndex = 1;
            this.edtModulID.EditValueChanged += new System.EventHandler(this.edtModulID_EditValueChanged);
            this.edtModulID.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.edtModulID_EditValueChanging);
            //
            // lblModulID
            //
            this.lblModulID.Location = new System.Drawing.Point(12, 16);
            this.lblModulID.Name = "lblModulID";
            this.lblModulID.Size = new System.Drawing.Size(54, 24);
            this.lblModulID.TabIndex = 0;
            this.lblModulID.Text = "Modul";
            //
            // panTreeBottom
            //
            this.panTreeBottom.Controls.Add(this.btnCollapseAll);
            this.panTreeBottom.Controls.Add(this.btnExpandAll);
            this.panTreeBottom.Controls.Add(this.btnUp);
            this.panTreeBottom.Controls.Add(this.btnLeft);
            this.panTreeBottom.Controls.Add(this.btnDown);
            this.panTreeBottom.Controls.Add(this.btnRight);
            this.panTreeBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panTreeBottom.Location = new System.Drawing.Point(0, 510);
            this.panTreeBottom.Name = "panTreeBottom";
            this.panTreeBottom.Size = new System.Drawing.Size(304, 40);
            this.panTreeBottom.TabIndex = 2;
            //
            // btnCollapseAll
            //
            this.btnCollapseAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapseAll.Image")));
            this.btnCollapseAll.Location = new System.Drawing.Point(42, 8);
            this.btnCollapseAll.Margin = new System.Windows.Forms.Padding(3, 3, 6, 0);
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.Size = new System.Drawing.Size(24, 24);
            this.btnCollapseAll.TabIndex = 1;
            this.btnCollapseAll.UseVisualStyleBackColor = false;
            this.btnCollapseAll.Click += new System.EventHandler(this.btnCollapseAll_Click);
            //
            // btnExpandAll
            //
            this.btnExpandAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("btnExpandAll.Image")));
            this.btnExpandAll.Location = new System.Drawing.Point(12, 8);
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(24, 24);
            this.btnExpandAll.TabIndex = 0;
            this.btnExpandAll.UseVisualStyleBackColor = false;
            this.btnExpandAll.Click += new System.EventHandler(this.btnExpandAll_Click);
            //
            // btnUp
            //
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.IconID = 16;
            this.btnUp.Location = new System.Drawing.Point(237, 8);
            this.btnUp.Name = "btnUp";
            this.btnUp.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.btnUp.Size = new System.Drawing.Size(24, 24);
            this.btnUp.TabIndex = 4;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            //
            // btnLeft
            //
            this.btnLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.IconID = 11;
            this.btnLeft.Location = new System.Drawing.Point(177, 8);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.btnLeft.Size = new System.Drawing.Size(24, 24);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            //
            // btnDown
            //
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.IconID = 17;
            this.btnDown.Location = new System.Drawing.Point(267, 8);
            this.btnDown.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.btnDown.Name = "btnDown";
            this.btnDown.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.btnDown.Size = new System.Drawing.Size(24, 24);
            this.btnDown.TabIndex = 5;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            //
            // btnRight
            //
            this.btnRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.IconID = 13;
            this.btnRight.Location = new System.Drawing.Point(207, 8);
            this.btnRight.Name = "btnRight";
            this.btnRight.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.btnRight.Size = new System.Drawing.Size(24, 24);
            this.btnRight.TabIndex = 3;
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            //
            // tabTreeEditor
            //
            this.tabTreeEditor.Controls.Add(this.tpgTreeDetails);
            this.tabTreeEditor.Controls.Add(this.tpgXRight);
            this.tabTreeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTreeEditor.Location = new System.Drawing.Point(312, 0);
            this.tabTreeEditor.Name = "tabTreeEditor";
            this.tabTreeEditor.ShowFixedWidthTooltip = true;
            this.tabTreeEditor.Size = new System.Drawing.Size(488, 550);
            this.tabTreeEditor.TabIndex = 2;
            this.tabTreeEditor.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgTreeDetails,
            this.tpgXRight});
            this.tabTreeEditor.TabsLineColor = System.Drawing.Color.Black;
            this.tabTreeEditor.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabTreeEditor.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabTreeEditor.Text = "kissTabControlEx1";
            this.tabTreeEditor.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabTreeEditor_SelectedTabChanged);
            //
            // tpgTreeDetails
            //
            this.tpgTreeDetails.Controls.Add(this.lblModulTreeCode);
            this.tpgTreeDetails.Controls.Add(this.edtMaskName);
            this.tpgTreeDetails.Controls.Add(this.edtModulTreeCode);
            this.tpgTreeDetails.Controls.Add(this.edtNameML);
            this.tpgTreeDetails.Controls.Add(this.lblName);
            this.tpgTreeDetails.Controls.Add(this.lblXIconID);
            this.tpgTreeDetails.Controls.Add(this.edtModulTreeID);
            this.tpgTreeDetails.Controls.Add(this.edtActive);
            this.tpgTreeDetails.Controls.Add(this.lblActive);
            this.tpgTreeDetails.Controls.Add(this.panDetailsSQL);
            this.tpgTreeDetails.Controls.Add(this.edtXIconID);
            this.tpgTreeDetails.Controls.Add(this.lblSQLPreExecute);
            this.tpgTreeDetails.Controls.Add(this.lblClassName);
            this.tpgTreeDetails.Controls.Add(this.edtClassName);
            this.tpgTreeDetails.Controls.Add(this.edtSQLPreExecute);
            this.tpgTreeDetails.Location = new System.Drawing.Point(6, 32);
            this.tpgTreeDetails.Name = "tpgTreeDetails";
            this.tpgTreeDetails.Padding = new System.Windows.Forms.Padding(9);
            this.tpgTreeDetails.Size = new System.Drawing.Size(476, 512);
            this.tpgTreeDetails.TabIndex = 0;
            this.tpgTreeDetails.Title = "Modul-Tree";
            //
            // edtMaskName
            //
            this.edtMaskName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMaskName.DataMember = "MaskName";
            this.edtMaskName.DataSource = this.qryXModulTree;
            this.edtMaskName.Location = new System.Drawing.Point(238, 71);
            this.edtMaskName.Name = "edtMaskName";
            this.edtMaskName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMaskName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMaskName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMaskName.Properties.Appearance.Options.UseBackColor = true;
            this.edtMaskName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMaskName.Properties.Appearance.Options.UseFont = true;
            this.edtMaskName.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtMaskName.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtMaskName.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtMaskName.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtMaskName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtMaskName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtMaskName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMaskName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtMaskName.Properties.DisplayMember = "Text";
            this.edtMaskName.Properties.NullText = "";
            this.edtMaskName.Properties.ShowFooter = false;
            this.edtMaskName.Properties.ShowHeader = false;
            this.edtMaskName.Properties.ValueMember = "Code";
            this.edtMaskName.Size = new System.Drawing.Size(226, 24);
            this.edtMaskName.TabIndex = 7;
            //
            // edtModulTreeCode
            //
            this.edtModulTreeCode.AllowNull = false;
            this.edtModulTreeCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtModulTreeCode.DataMember = "ModulTreeCode";
            this.edtModulTreeCode.DataSource = this.qryXModulTree;
            this.edtModulTreeCode.Location = new System.Drawing.Point(148, 190);
            this.edtModulTreeCode.LOVName = "ModulTree";
            this.edtModulTreeCode.Name = "edtModulTreeCode";
            this.edtModulTreeCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtModulTreeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModulTreeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulTreeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtModulTreeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModulTreeCode.Properties.Appearance.Options.UseFont = true;
            this.edtModulTreeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtModulTreeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulTreeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtModulTreeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtModulTreeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtModulTreeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtModulTreeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtModulTreeCode.Properties.NullText = "";
            this.edtModulTreeCode.Properties.ShowFooter = false;
            this.edtModulTreeCode.Properties.ShowHeader = false;
            this.edtModulTreeCode.Size = new System.Drawing.Size(316, 24);
            this.edtModulTreeCode.TabIndex = 13;
            //
            // edtNameML
            //
            this.edtNameML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNameML.DataMemberDefaultText = "Name";
            this.edtNameML.DataMemberTID = "NameTID";
            this.edtNameML.DataSource = this.qryXModulTree;
            this.edtNameML.Location = new System.Drawing.Point(148, 11);
            this.edtNameML.Name = "edtNameML";
            this.edtNameML.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameML.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameML.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameML.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameML.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameML.Properties.Appearance.Options.UseFont = true;
            this.edtNameML.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtNameML.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtNameML.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtNameML.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameML.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtNameML.Size = new System.Drawing.Size(219, 24);
            this.edtNameML.TabIndex = 1;
            //
            // edtModulTreeID
            //
            this.edtModulTreeID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtModulTreeID.DataMember = "ModulTreeID";
            this.edtModulTreeID.DataSource = this.qryXModulTree;
            this.edtModulTreeID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtModulTreeID.Location = new System.Drawing.Point(373, 11);
            this.edtModulTreeID.Name = "edtModulTreeID";
            this.edtModulTreeID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtModulTreeID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtModulTreeID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModulTreeID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulTreeID.Properties.Appearance.Options.UseBackColor = true;
            this.edtModulTreeID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModulTreeID.Properties.Appearance.Options.UseFont = true;
            this.edtModulTreeID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtModulTreeID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtModulTreeID.Properties.ReadOnly = true;
            this.edtModulTreeID.Size = new System.Drawing.Size(91, 24);
            this.edtModulTreeID.TabIndex = 2;
            //
            // edtActive
            //
            this.edtActive.DataMember = "Active";
            this.edtActive.DataSource = this.qryXModulTree;
            this.edtActive.Location = new System.Drawing.Point(148, 101);
            this.edtActive.Name = "edtActive";
            this.edtActive.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtActive.Properties.Appearance.Options.UseBackColor = true;
            this.edtActive.Properties.Caption = "";
            this.edtActive.Size = new System.Drawing.Size(24, 19);
            this.edtActive.TabIndex = 9;
            //
            // lblActive
            //
            this.lblActive.Location = new System.Drawing.Point(6, 99);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(136, 24);
            this.lblActive.TabIndex = 8;
            this.lblActive.Text = "Aktiv";
            //
            // panDetailsSQL
            //
            this.panDetailsSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panDetailsSQL.Controls.Add(this.edtInsert);
            this.panDetailsSQL.Controls.Add(this.splitterSQL);
            this.panDetailsSQL.Controls.Add(this.edtModulTree_Value1);
            this.panDetailsSQL.Location = new System.Drawing.Point(9, 220);
            this.panDetailsSQL.Name = "panDetailsSQL";
            this.panDetailsSQL.Size = new System.Drawing.Size(455, 283);
            this.panDetailsSQL.TabIndex = 14;
            //
            // splitterSQL
            //
            this.splitterSQL.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterSQL.Location = new System.Drawing.Point(0, 111);
            this.splitterSQL.MinExtra = 75;
            this.splitterSQL.MinSize = 100;
            this.splitterSQL.Name = "splitterSQL";
            this.splitterSQL.Size = new System.Drawing.Size(455, 4);
            this.splitterSQL.TabIndex = 1;
            this.splitterSQL.TabStop = false;
            //
            // edtModulTree_Value1
            //
            this.edtModulTree_Value1.DataMember = "ModulTree_Value1";
            this.edtModulTree_Value1.DataSource = this.qryXModulTree;
            this.edtModulTree_Value1.Dock = System.Windows.Forms.DockStyle.Top;
            this.edtModulTree_Value1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtModulTree_Value1.Location = new System.Drawing.Point(0, 0);
            this.edtModulTree_Value1.Name = "edtModulTree_Value1";
            this.edtModulTree_Value1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtModulTree_Value1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModulTree_Value1.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulTree_Value1.Properties.Appearance.Options.UseBackColor = true;
            this.edtModulTree_Value1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModulTree_Value1.Properties.Appearance.Options.UseFont = true;
            this.edtModulTree_Value1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtModulTree_Value1.Properties.ReadOnly = true;
            this.edtModulTree_Value1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.edtModulTree_Value1.Properties.WordWrap = false;
            this.edtModulTree_Value1.ProportionalFont = false;
            this.edtModulTree_Value1.Size = new System.Drawing.Size(455, 111);
            this.edtModulTree_Value1.TabIndex = 0;
            //
            // tpgXRight
            //
            this.tpgXRight.Controls.Add(this.ctlXRight);
            this.tpgXRight.Location = new System.Drawing.Point(6, 32);
            this.tpgXRight.Name = "tpgXRight";
            this.tpgXRight.Size = new System.Drawing.Size(476, 512);
            this.tpgXRight.TabIndex = 1;
            this.tpgXRight.Title = "Zugriffsrechte";
            //
            // ctlXRight
            //
            this.ctlXRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlXRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlXRight.Location = new System.Drawing.Point(0, 0);
            this.ctlXRight.Name = "ctlXRight";
            this.ctlXRight.Size = new System.Drawing.Size(476, 512);
            this.ctlXRight.TabIndex = 0;
            //
            // splitterTree
            //
            this.splitterTree.AnimationDelay = 20;
            this.splitterTree.AnimationStep = 20;
            this.splitterTree.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.splitterTree.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitterTree.ControlToHide = this.panTree;
            this.splitterTree.ExpandParentForm = false;
            this.splitterTree.Location = new System.Drawing.Point(304, 0);
            this.splitterTree.Name = "kissSplitterCollapsible1";
            this.splitterTree.TabIndex = 1;
            this.splitterTree.TabStop = false;
            this.splitterTree.UseAnimations = false;
            this.splitterTree.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            //
            // CtlTreeEditor
            //
            this.ActiveSQLQuery = this.qryXModulTree;
            this.Controls.Add(this.tabTreeEditor);
            this.Controls.Add(this.splitterTree);
            this.Controls.Add(this.panTree);
            this.Name = "CtlTreeEditor";
            this.Size = new System.Drawing.Size(800, 550);
            this.Load += new System.EventHandler(this.CtlTreeEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edtXIconID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXModulTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblXIconID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClassName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSQLPreExecute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulTreeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClassName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClassName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSQLPreExecute.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInsert.Properties)).EndInit();
            this.panTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treModulTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXModulTree_TreeSource)).EndInit();
            this.panTreeTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulID)).EndInit();
            this.panTreeBottom.ResumeLayout(false);
            this.tabTreeEditor.ResumeLayout(false);
            this.tpgTreeDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtMaskName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaskName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulTreeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulTreeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameML.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulTreeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblActive)).EndInit();
            this.panDetailsSQL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtModulTree_Value1.Properties)).EndInit();
            this.tpgXRight.ResumeLayout(false);
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

        /// <summary>
        /// Eventhandler: the control is being loaded
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event arguments</param>
        private void CtlTreeEditor_Load(object sender, System.EventArgs e)
        {
            // select first tpg
            tabTreeEditor.SelectTab(tpgTreeDetails);

            // load data
            LookUpModulTreeDetails();
            RefreshTree();

            // expand tree items
            TreeExpandAll();
        }

        private void btnCollapseAll_Click(object sender, EventArgs e)
        {
            treModulTree.CollapseAll();
            treModulTree.Focus();
        }

        /// <summary>
        /// Eventhandler: the user wants to move a tree node down (inside its level )
        /// swap sortkey with next node
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event arguments</param>
        private void btnDown_Click(object sender, System.EventArgs e)
        {
            if (qryXModulTree.Count == 0 || !this.DoPost())
            {
                return;
            }

            object nodeID = qryXModulTree["ModulTreeID"];

            try
            {
                _preventRefreshCount++;

                object parentID = qryXModulTree["ModulTreeID_Parent"]; // can be System.DBNull
                int currentSortKey = (int)qryXModulTree["SortKey"];
                int tempSortKey = 9998;
                int modulID = (int)qryXModulTree["ModulID"];

                // NachPosition bestimmen
                string sql = @"
                    SELECT MIN(SortKey)
                    FROM dbo.XModulTree
                    WHERE SortKey > {0} 
                      AND ModulID = {1}";
                sql += "  AND ModulTreeID_Parent " + GetSqlOperatorForNullableObject(parentID) + " {2}";

                object nachPosition = DBUtil.ExecuteScalarSQL(sql, currentSortKey, modulID, parentID);

                if (DBUtil.IsEmpty(nachPosition))
                {
                    return;
                }

                // swap row with next one, move the active row to temp position
                qryXModulTree["SortKey"] = tempSortKey;
                this.DoPost();

                // move next row to the just freed position
                sql =@"
                    UPDATE dbo.XModulTree
                    SET SortKey = {0}
                    WHERE SortKey = {1} 
                      AND ModulID = {2}";
                sql += "  AND ModulTreeID_Parent " + GetSqlOperatorForNullableObject(parentID) + " {3}";
                DBUtil.ExecSQL(sql, currentSortKey, nachPosition, modulID, parentID);

                // now move the active row from the temp position to the next
                qryXModulTree["SortKey"] = nachPosition;

                this.DoPost();
            }
            finally
            {
                _preventRefreshCount--;
            }

            // refresh
            LookUpModulTreeDetails();
            RefreshTree();
            qryXModulTree.Find(string.Format("ModulTreeID = {0}", nodeID));
        }

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            // expand all of tree
            TreeExpandAll();
        }

        /// <summary>
        /// Eventhandler: the user wants to move a tree node one level up
        /// swap sortkey with previous node
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event arguments</param>
        private void btnLeft_Click(object sender, System.EventArgs e)
        {
            // do nothing if the selected node already is a root node
            if (DBUtil.IsEmpty(qryXModulTree["ModulTreeID_Parent"]))
            {
                return;
            }

            object nodeID = qryXModulTree["ModulTreeID"];

            try
            {
                _preventRefreshCount++;
                // park the dragged row on a temp position
                _currentSortKey = (int)qryXModulTree["SortKey"];
                qryXModulTree["SortKey"] = 0;

                this.DoPost();

                // fill the sort key gap where the node left
                string sql = @"
                    UPDATE dbo.XModulTree
                    SET SortKey = SortKey - 1
                    WHERE SortKey > {0} 
                      AND ModulID = {1}";
                sql += "  AND ModulTreeID_Parent " + GetSqlOperatorForNullableObject(qryXModulTree["ModulTreeID_Parent"]) + " {2}";
                DBUtil.ExecuteScalarSQL(sql, _currentSortKey, _currentModulID, qryXModulTree["ModulTreeID_Parent"]);

                // find parent of parent (grandparent ;-))
                object newParentID = DBUtil.ExecuteScalarSQL(@"
                    SELECT ModulTreeID_Parent
                    FROM dbo.XModulTree
                    WHERE ModulTreeID = {0}", qryXModulTree["ModulTreeID_Parent"]);

                int newParentSortKey = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT SortKey
                    FROM dbo.XModulTree
                    WHERE ModulTreeID = {0}",
                    qryXModulTree["ModulTreeID_Parent"]);

                // create a sort key gap to place the moved node in
                sql =
                    @"
                    UPDATE dbo.XModulTree
                    SET SortKey = SortKey + 1
                    WHERE SortKey > {0} 
                      AND ModulID = {1}";
                sql += "  AND ModulTreeID_Parent " + GetSqlOperatorForNullableObject(newParentID) + " {2}";
                DBUtil.ExecuteScalarSQL(sql, newParentSortKey, _currentModulID, newParentID);

                // insert the dragged row at the end of the list
                qryXModulTree["SortKey"] = newParentSortKey + 1;
                qryXModulTree["ModulTreeID_Parent"] = newParentID;

                this.DoPost();
            }
            finally
            {
                _preventRefreshCount--;
            }

            // without a refresh the sort keys would not be consistent anymore
            LookUpModulTreeDetails();
            RefreshTree();
            qryXModulTree.Find(string.Format("ModulTreeID = {0}", nodeID));
        }

        /// <summary>
        /// The user wants to move the selected Node as a child of the one below
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event parameters</param>
        private void btnRight_Click(object sender, System.EventArgs e)
        {
            try
            {
                _preventRefreshCount++;
                _currentSortKey = (int)qryXModulTree["SortKey"];

                // find new parent
                object previous = GetPreviousSortKeyObject(_currentSortKey, qryXModulTree["ModulTreeID_Parent"]);
                if (DBUtil.IsEmpty(previous))
                {
                    return;
                }
                string sql = @"
                    SELECT ModulTreeID
                    FROM dbo.XModulTree
                    WHERE ModulID = {0} 
                      AND SortKey = {1}";
                sql += "  AND ModulTreeID_Parent " + this.GetSqlOperatorForNullableObject(qryXModulTree["ModulTreeID_Parent"]) + " {2}";
                object newParentID = DBUtil.ExecuteScalarSQL(sql, _currentModulID, previous, qryXModulTree["ModulTreeID_Parent"]);

                // the new parent cannot be null
                if (DBUtil.IsEmpty(newParentID))
                {
                    return;
                }

                // park the dragged row on a temp position
                qryXModulTree["SortKey"] = 0;
                this.DoPost();

                // fill the sortkey gap where the node left
                sql = @"
                    UPDATE dbo.XModulTree
                    SET SortKey = SortKey - 1
                    WHERE SortKey > {0} 
                      AND ModulID = {1}";
                sql += "  AND ModulTreeID_Parent " + GetSqlOperatorForNullableObject(qryXModulTree["ModulTreeID_Parent"]) + " {2}";
                DBUtil.ExecuteScalarSQL(sql, _currentSortKey, _currentModulID, qryXModulTree["ModulTreeID_Parent"]);

                // find highest sort key in new group
                sql = @"
                    SELECT MAX(SortKey)
                    FROM dbo.XModulTree
                    WHERE ModulID = {0}";
                sql += "  AND ModulTreeID_Parent " + GetSqlOperatorForNullableObject(newParentID) + " {1}";
                object highestSortKey = DBUtil.ExecuteScalarSQL(sql, _currentModulID, newParentID);

                // insert the dragged row at the end of the list
                qryXModulTree["SortKey"] = DBUtil.IsEmpty(highestSortKey) ? 1 : (int)highestSortKey + 1;
                qryXModulTree["ModulTreeID_Parent"] = newParentID;
                this.DoPost();
            }
            finally
            {
                _preventRefreshCount--;
            }

            // without a refresh the sort keys would not be consistent anymore
            LookUpModulTreeDetails();
            RefreshTree();
        }

        /// <summary>
        /// Eventhandler: the user wants to move a tree node up (inside its level )
        /// swap sortkey with previous node
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event arguments</param>
        private void btnUp_Click(object sender, System.EventArgs e)
        {
            if (qryXModulTree.Count == 0 || (int)qryXModulTree["SortKey"] == 1 || !this.DoPost())
            {
                return;
            }

            try
            {
                _preventRefreshCount++;
                object parentID = qryXModulTree["ModulTreeID_Parent"]; // can be System.DBNull
                int currentSortKey = (int)qryXModulTree["SortKey"];
                int tempSortKey = 9998;
                int modulID = (int)qryXModulTree["ModulID"];

                //VorPosition bestimmen
                string sql = @"
                    SELECT MAX(SortKey)
                    FROM dbo.XModulTree
                    WHERE SortKey < {0} 
                      AND ModulID = {1}";
                sql += "  AND ModulTreeID_Parent " + GetSqlOperatorForNullableObject(parentID) + " {2}";
                object VorPosition = DBUtil.ExecuteScalarSQL(sql, currentSortKey, modulID, parentID);

                if (DBUtil.IsEmpty(VorPosition))
                {
                    return;
                }

                //swap row with previous one
                // move the active row to temp position
                qryXModulTree["SortKey"] = tempSortKey;
                this.DoPost();

                // move previous row to the just freed position
                sql = @"
                    UPDATE dbo.XModulTree
                    SET SortKey = {0}
                    WHERE SortKey = {1} 
                      AND ModulID = {2}";
                sql += "  AND ModulTreeID_Parent " + GetSqlOperatorForNullableObject(parentID) + " {3}";
                DBUtil.ExecSQL(sql, currentSortKey, VorPosition, modulID, parentID);

                // now move the active row from the temp position to the previous
                qryXModulTree["SortKey"] = VorPosition;
                this.DoPost();
            }
            finally
            {
                _preventRefreshCount--;
            }

            // refresh
            LookUpModulTreeDetails();
            RefreshTree();
        }

        /// <summary>
        /// Eventhandler: the user has changed the module
        /// fill the tree, fill the detail controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void edtModulID_EditValueChanged(object sender, System.EventArgs e)
        {
            // load and refresh data
            LookUpModulTreeDetails();
            RefreshTree();

            LookUpClasses();
            LookUpMaskName();

            // expand tree
            TreeExpandAll();

            // focus first node
            treModulTree.MoveFirst();
        }

        /// <summary>
        /// Eventhandler: the user wants to select an other module
        /// post the current row
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event arguments</param>
        private void edtModulID_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            e.Cancel = !this.DoPost();
        }

        /// <summary>
        /// Eventhandler: the width of the form was changed
        /// resize the column width accordingly
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event arguments</param>
        private void panTree_SizeChanged(object sender, System.EventArgs e)
        {
            colName.Width = treModulTree.Size.Width - 38;
        }

        /// <summary>
        /// Eventhandler: a row was deleted
        /// update the corresponding sortkeys 
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event argument</param>
        private void qryXModulTree_AfterDelete(object sender, System.EventArgs e)
        {
            // fill the sort key gap where the node left
            string sql = @"
                UPDATE dbo.XModulTree
                SET SortKey = SortKey - 1
                WHERE ModulID = {0}
                  AND SortKey > {1}";
            sql += "  AND ModulTreeID_Parent " + GetSqlOperatorForNullableObject(qryXModulTree["ModulTreeID_Parent"]) + " {2}";
            DBUtil.ExecuteScalarSQL(sql, qryXModulTree["ModulID"], qryXModulTree["SortKey"], qryXModulTree["ModulTreeID_Parent"]);

            LookUpModulTreeDetails();
            RefreshTree();
        }

        /// <summary>
        /// Eventhandler: a new row was inserted
        /// fill the new row with known / default values
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event arguments</param>
        private void qryXModulTree_AfterInsert(object sender, System.EventArgs e)
        {
            qryXModulTree["ModulTreeID_Parent"] = _currentNodeID;
            qryXModulTree["ModulID"] = _currentModulID;
            qryXModulTree["XIconID"] = 0;
            qryXModulTree["ModulTreeID"] = GetNextFreeModulTreeIDInModul(_currentModulID);

            // find SortKey
            string sql = @"
                SELECT MAX(SortKey)
                FROM dbo.XModulTree
                WHERE ModulID = {0}";
            sql += "  AND ModulTreeID_Parent " + GetSqlOperatorForNullableObject(_currentNodeID) + " {1}";
            object highestSortKey = DBUtil.ExecuteScalarSQL(sql, _currentModulID, _currentNodeID);

            qryXModulTree["SortKey"] = DBUtil.IsEmpty(highestSortKey) ? 1 : (int)highestSortKey + 1;
        }

        /// <summary>
        /// Eventhandler: a new row is to be inserted
        /// stores infos about the currently selected node
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event arguments</param>
        private void qryXModulTree_BeforeInsert(object sender, System.EventArgs e)
        {
            if (qryXModulTree.Row == null)
            {
                // no selected row, probably empty table
                _currentParent = null;
                _currentNodeID = null;
            }
            else
            {
                _currentParent = qryXModulTree["ModulTreeID_Parent"];
                _currentNodeID = qryXModulTree["ModulTreeID"];
            }
        }

        /// <summary>
        /// Eventhandler: a value in a row has changed
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event argument</param>
        private void qryXModulTree_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == "ModulTreeCode")
            {
                e.Row["ModulTree_Value1"] = DBUtil.ExecuteScalarSQL("SELECT Value1 FROM XLOVCode WHERE LOVName = 'ModulTree' AND Code = {0}", e.ProposedValue);
                this.qryXModulTree.RefreshDisplay();
            }
        }

        /// <summary>
        /// Eventhandler: the active record has changed
        /// refreshes the enabled states of the buttons used to move the node around (in the tree)
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event arguments</param>
        private void qryXModulTree_PositionChanged(object sender, System.EventArgs e)
        {
            // load data of rights
            SetupCtlXRight();

            // refresh controls
            this.RefreshEnabledStates();
        }

        /// <summary>
        /// Eventhandler: a row has been modified
        /// Synchronize with the tree-query
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event arguments</param>
        private void qryXModulTree_PostCompleted(object sender, System.EventArgs e)
        {
            RefreshTree();
        }

        private void qryXModulTree_TreeSource_AfterFill(object sender, System.EventArgs e)
        {
            if (!this.qryXModulTree_TreeSource.DataTable.Columns.Contains("ImageIndex"))
            {
                this.qryXModulTree_TreeSource.DataTable.Columns.Add("ImageIndex", typeof(int));
            }

            foreach (DataRow row in qryXModulTree_TreeSource.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["XIconID"]))
                {
                    row["ImageIndex"] = KissImageList.GetImageIndex(Convert.ToInt32(row["XIconID"]));
                }
            }

            this.treModulTree.DataSource = sender;
        }

        private void tabTreeEditor_Resize(object sender, EventArgs e)
        {
            this.edtClassName.Width = (this.edtXIconID.Width / 2) - 3;
            this.edtMaskName.Width = edtClassName.Width;
            this.edtMaskName.Left = this.edtClassName.Left + this.edtXIconID.Width - this.edtMaskName.Width;
        }

        private void tabTreeEditor_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // load data of rights
            SetupCtlXRight();
        }

        private void treModulTree_BeforeDragNode(object sender, DevExpress.XtraTreeList.BeforeDragNodeEventArgs e)
        {
            if (qryXModulTree.Row == null)
            {
                // no selected row, probably empty table
                _currentParent = null;
                _currentNodeID = null;
                _currentSortKey = 0;
            }
            else
            {
                _currentParent = qryXModulTree["ModulTreeID_Parent"];
                _currentNodeID = qryXModulTree["ModulTreeID"];
                _currentSortKey = DBUtil.IsEmpty(qryXModulTree["SortKey"]) ? 1 : Convert.ToInt32(qryXModulTree["SortKey"]);
            }
        }

        /// <summary>
        /// Eventhandler: the user wants to select a new treenode
        /// post the current row if something has changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treModulTree_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            // luckily, there are no must-fields that the user must fill
            if (qryXModulTree.RowModified && !qryXModulTree.IsInserting && qryXModulTree.Row != null)
            {
                this.DoPost();
            }
        }

        /// <summary>
        /// Eventhandler: a node has been selected in the tree
        /// Synchronize with the detail-query
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event arguments</param>
        private void treModulTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null && !_isRefreshingTree)
            {
                this.qryXModulTree.Find(string.Format("ModulTreeID = {0}", e.Node.GetValue("ModulTreeID")));
            }
        }

        private void treeEditor_AfterDragNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            try
            {
                _preventRefreshCount++;

                object newParentID = qryXModulTree_TreeSource["ModulTreeID_Parent"];

                // park the dragged row on a temp position
                qryXModulTree["SortKey"] = 9998;
                this.DoPost();

                // fill the sort key gap where the node left
                string sql = @"
                    UPDATE dbo.XModulTree
                    SET SortKey = Sortkey - 1
                    WHERE SortKey > {0} 
                      AND ModulID = {1} 
                      AND SortKey < 9998";
                sql += "  AND ModulTreeID_Parent " + GetSqlOperatorForNullableObject(_currentParent) + " {2}";
                DBUtil.ExecuteScalarSQL(sql, _currentSortKey, _currentModulID, _currentParent);

                // find highest sort key in new group
                sql = @"
                 SELECT MAX(SortKey)
                 FROM dbo.XModulTree
                 WHERE SortKey < 9998 
                   AND ModulID = {0}";
                sql += "  AND ModulTreeID_Parent " + GetSqlOperatorForNullableObject(newParentID) + " {1}";
                object highestSortKey = DBUtil.ExecuteScalarSQL(sql, _currentModulID, newParentID);

                // insert the dragged row at the end of the list
                qryXModulTree["ModulTreeID_Parent"] = newParentID;
                qryXModulTree["SortKey"] = DBUtil.IsEmpty(highestSortKey) ? 1 : Convert.ToInt32(highestSortKey) + 1;

                this.DoPost();
            }
            finally
            {
                _preventRefreshCount--;
            }

            // without a refresh the sort keys would not be consistent anymore
            LookUpModulTreeDetails();
            RefreshTree();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Eventhandler: the user wants to insert a new record
        /// Because there are 2 DataSources we have to ensure, that the new record is being shown in the tree
        /// </summary>
        /// <returns></returns>
        public override bool OnAddData()
        {
            // check if user has rights to add new items
            if (!HasUserAdvancedEditRights())
            {
                // let base do stuff as we set CanInsert=false in SetupRights()
                return base.OnAddData();
            }

            // avoid crash in case of too fast user
            if (this.treModulTree.DataSource == null)
            {
                throw new KissCancelException();
            }

            // create a new row and imediately save it to database because of problems with tree
            bool result = base.OnAddData();
            qryXModulTree.RowModified = true;
            object newID = qryXModulTree["ModulTreeID"];
            result &= this.qryXModulTree.Post(true);

            // select last inserted row in tree
            this.RefreshTree();
            this.treModulTree.FocusedNode = this.treModulTree.FindNodeByKeyID(newID);
            this.RefreshEnabledStates();

            return result;
        }

        /// <summary>
        /// Lets the user edit only the tree of one module
        /// </summary>
        /// <param name="modulID"></param>
        public void SetModul(int modulID)
        {
            this.edtModulID.EditValue = modulID;
            this.edtModulID.EditMode = EditModeType.ReadOnly;
            this.panTreeTop.Visible = false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Post the current row
        /// </summary>
        /// <returns></returns>
        private bool DoPost()
        {
            try
            {
                return qryXModulTree.Post();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Finds a new ModulTreeID in the range of the specified module
        /// </summary>
        /// <param name="modulID">Modul to generate an ID for</param>
        /// <returns>valid ID</returns>
        private int GetNextFreeModulTreeIDInModul(int modulID)
        {
            SqlQuery qryIDs = DBUtil.OpenSQL(@"
               SELECT ModulTreeID
               FROM dbo.XModulTree
               WHERE (ModulTreeID / 10000 ) = {0}
               ORDER BY 1", modulID);

            int nextID = modulID * 10000;

            if (qryIDs.Count > 0)
            {
                qryIDs.First();

                // row = qryIDs.DataTable.Rows.Find( ++nextID ); // error: no primary key
                while ((int)qryIDs["ModulTreeID"] == nextID)
                {
                    nextID++;
                    qryIDs.Next();

                    if (nextID >= (modulID + 1) * 10000)
                    {
                        throw new KissErrorException("Error in method GetNextFreeModulTreeIDInModul(): ModulTreeID range is full");
                    }
                }
            }

            return nextID;
        }

        /// <summary>
        /// Gets the next higher SortKey to a specified number
        /// </summary>
        /// <param name="currentSortKey">sortkey to start search from</param>
        /// <param name="parent">parent of the sortkey group</param>
        /// <returns>next higher SortKey</returns>
        private int GetNextSortKey(int currentSortKey, object parent)
        {
            object newSortKey = GetNextSortKeyObject(currentSortKey, parent);

            if (DBUtil.IsEmpty(newSortKey))
            {
                return currentSortKey + 1;
            }

            return Convert.ToInt32(newSortKey);
        }

        /// <summary>
        /// Gets the next higher SortKey to a specified number
        /// </summary>
        /// <param name="currentSortKey">sortkey to start search from</param>
        /// <param name="parent">parent of the sortkey group</param>
        /// <returns>next higher SortKey or null if none</returns>
        private object GetNextSortKeyObject(int currentSortKey, object parent)
        {
            string sql = @"
                SELECT MIN(SortKey)
                FROM dbo.XModulTree
                WHERE ModulID = {0} 
                  AND SortKey > {1}";
            sql += "  AND ModulTreeID_Parent " + GetSqlOperatorForNullableObject(parent) + " {2}";
            return DBUtil.ExecuteScalarSQL(sql, _currentModulID, currentSortKey, parent);
        }

        /// <summary>
        /// Gets the next lower SortKey to a specified number
        /// </summary>
        /// <param name="currentSortKey">sortkey to start search from</param>
        /// <param name="parent">parent of the sortkey group</param>
        /// <returns>next lower SortKey or null if none</returns>
        private object GetPreviousSortKeyObject(int currentSortKey, object parent)
        {
            string sql = @"
                SELECT MAX(SortKey)
                FROM dbo.XModulTree
                WHERE ModulID = {0} 
                  AND SortKey < {1}";
            sql += "  AND ModulTreeID_Parent " + GetSqlOperatorForNullableObject(parent) + " {2}";
            return DBUtil.ExecuteScalarSQL(sql, _currentModulID, currentSortKey, parent);
        }

        /// <summary>
        /// Yields a compare operator as a string: For System.DBNull "IS", else "="
        /// </summary>
        /// <param name="toCompareWith">object to generate an operator for</param>
        /// <returns>operator as string</returns>
        private string GetSqlOperatorForNullableObject(object toCompareWith)
        {
            return DBUtil.IsEmpty(toCompareWith) ? "IS" : "=";
        }

        /// <summary>
        /// Check if user has more rights than just translate caption
        /// </summary>
        /// <returns><c>True</c> if user has more rights thant just changing minor settings</returns>
        private bool HasUserAdvancedEditRights()
        {
            return Session.User.IsUserBIAGAdmin;
        }

        /// <summary>
        /// Fills the classes available for the current module into the classes-dropdownbox
        /// </summary>
        private void LookUpClasses()
        {
            SqlQuery qryClasses = DBUtil.OpenSQL(@"
                SELECT ClassName,
                       SortKey = CASE WHEN ModulID = {0} THEN 1
                                      ELSE 2
                                 END
                FROM dbo.XClass CLS
                ORDER BY SortKey, ClassName", qryXModulTree["ModulID"]);

            edtClassName.LoadQuery(qryClasses, "ClassName", "ClassName");
        }

        /// <summary>
        /// Fills the classes available for the current module into the classes-dropdownbox
        /// </summary>
        private void LookUpMaskName()
        {
            if (!Session.SupportDynaMask)
            {
                return;
            }

            SqlQuery qryDynaMask = DBUtil.OpenSQL(@"
                SELECT MSK.MaskName,
                       SortKey = CASE WHEN MSK.ModulID = {0} THEN 1
                                      ELSE 2
                                 END
                FROM dbo.DynaMask MSK
                WHERE EXISTS (SELECT TOP 1 1
                              FROM dbo.DynaField DYN
                              WHERE DYN.MaskName = MSK.MaskName)

                UNION

                SELECT MaskName = NULL,
                       SortKey  = 0
                ORDER BY SortKey, MaskName", qryXModulTree["ModulID"]);

            edtMaskName.LoadQuery(qryDynaMask, "MaskName", "MaskName");
        }

        /// <summary>
        /// Fills the SqlQuery which is the DataSource for the detail view
        /// </summary>
        private void LookUpModulTreeDetails()
        {
            _currentModulID = edtModulID.EditValue is int ? Convert.ToInt32(edtModulID.EditValue) : 0;

            qryXModulTree.Fill(@"
                SELECT MTE.*,
                       ModulTree_Value1 = XLC.Value1,
                       TranslatedName   = CASE WHEN MTE.NameTID IS NULL OR LAN.Text IS NULL THEN MTE.[name]
                                               ELSE LAN.Text
                                          END
                FROM dbo.XModulTree MTE
                  INNER JOIN dbo.XLOVCode XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'ModulTree' AND
                                                                        XLC.Code = MTE.ModulTreeCode
                  LEFT  JOIN XLangText    LAN WITH (READUNCOMMITTED) ON MTE.NameTID = LAN.TID AND
                                                                        LAN.LanguageCode = {0}
                WHERE MTE.ModulID = {1}", Session.User.LanguageCode, _currentModulID);
        }

        /// <summary>
        /// Fills the SqlQuery which is the DataSource for the tree
        /// </summary>
        private void LookUpModulTreeOnly()
        {
            this.treModulTree.DataSource = null;
            _currentModulID = edtModulID.EditValue is int ? Convert.ToInt32(edtModulID.EditValue) : 0;

            qryXModulTree_TreeSource.Fill(@"
                SELECT MTE.*,
                       TranslatedName = CASE WHEN MTE.NameTID IS NULL OR LAN.Text IS NULL THEN MTE.[name]
                                             ELSE LAN.Text
                                        END
                FROM dbo.XModulTree MTE
                  LEFT JOIN dbo.XLangText LAN WITH (READUNCOMMITTED) ON MTE.NameTID IS NOT NULL AND
                                                                        MTE.NameTID = LAN.TID AND
                                                                        LAN.LanguageCode = {0}
                WHERE MTE.ModulID = {1}", Session.User.LanguageCode, _currentModulID);
        }

        /// <summary>
        /// Fills the classes available for the current module into the classes-dropdownbox
        /// </summary>
        private void LookUpModules()
        {
            edtModulID.LoadQuery(DesignerHostUtils.GetNonSystemModuls());
        }

        /// <summary>
        /// Handle editmode property for controls depending on data-state
        /// </summary>
        private void RefreshEnabledStates()
        {
            // check if user has rights to move or added a new row
            if (!HasUserAdvancedEditRights() || this.qryXModulTree.Row == null || this.qryXModulTree.Row.RowState == DataRowState.Added)
            {
                // no rights or new row
                this.btnUp.Enabled = false;
                this.btnDown.Enabled = false;
                this.btnLeft.Enabled = false;
                this.btnRight.Enabled = false;
            }
            else
            {
                int currentSortKey = DBUtil.IsEmpty(qryXModulTree["SortKey"]) ? -1 : Convert.ToInt32(qryXModulTree["SortKey"]);

                this.btnUp.Enabled = !DBUtil.IsEmpty(GetPreviousSortKeyObject(currentSortKey, qryXModulTree["ModulTreeID_Parent"]));
                this.btnDown.Enabled = !DBUtil.IsEmpty(GetNextSortKeyObject(currentSortKey, qryXModulTree["ModulTreeID_Parent"]));
                this.btnLeft.Enabled = !DBUtil.IsEmpty(this.qryXModulTree["ModulTreeID_Parent"]);
                this.btnRight.Enabled = this.btnUp.Enabled;
            }

            // setup edtNameML
            this.edtNameML.EditMode = qryXModulTree.Count < 1 ? EditModeType.ReadOnly : EditModeType.Normal;

            // setup collapse/expand buttons
            this.btnCollapseAll.Enabled = qryXModulTree.Count > 0;
            this.btnExpandAll.Enabled = qryXModulTree.Count > 0;
        }

        /// <summary>
        /// Refresh tree after changes made to data
        /// </summary>
        private void RefreshTree()
        {
            try
            {
                if (_isRefreshingTree || _preventRefreshCount > 0)
                {
                    return;
                }

                _isRefreshingTree = true;

                this.treModulTree.SaveState();
                this.LookUpModulTreeOnly();
                this.treModulTree.RefreshDataSource();

                _isRefreshingTree = false;

                this.treModulTree.LoadState();
            }
            finally
            {
                _isRefreshingTree = false;

                // refresh states
                RefreshEnabledStates();
            }
        }

        private void SetupCtlXRight()
        {
            // check selected tpg > load data only if showing tpg of control
            if (tabTreeEditor.IsTabSelected(tpgXRight))
            {
                // setup rights (deny insert and delete here)
                this.ctlXRight.ActiveSQLQuery.CanInsert = false;
                this.ctlXRight.ActiveSQLQuery.CanDelete = false;

                // get current class/mask
                string className = Convert.ToString(this.qryXModulTree["ClassName"]);
                string maskName = Convert.ToString(this.qryXModulTree["MaskName"]);

                // set null values if empty
                className = className == "" ? null : className;
                maskName = maskName == "" ? null : maskName;

                // check if already loaded
                if (this.ctlXRight.ClassName != className || this.ctlXRight.MaskName != maskName)
                {
                    // load data of class/mask
                    this.ctlXRight.ClassName = className;
                    this.ctlXRight.MaskName = maskName;
                }
            }
        }

        private void SetupRights()
        {
            // return access mode depending on current user's rights
            if (!Session.User.IsUserBIAGAdmin && !Session.User.IsUserAdmin && !DBUtil.UserHasRight("DSGBusinessDesignerAdmin"))
            {
                // no access to this control without admin privileges
                throw new Exception("Access to this control is denied. User has no administration privileges.");
            }

            // get current rights
            bool hasUserAdvancedEditRights = HasUserAdvancedEditRights();
            EditModeType editMode = hasUserAdvancedEditRights ? EditModeType.Normal : EditModeType.ReadOnly;

            // setup queries
            qryXModulTree_TreeSource.CanInsert = false;     // always readonly
            qryXModulTree_TreeSource.CanUpdate = false;     // always readonly
            qryXModulTree_TreeSource.CanDelete = false;     // always readonly

            qryXModulTree.CanInsert = hasUserAdvancedEditRights;    // depends on rights
            qryXModulTree.CanUpdate = true;                         // update is always allowed (due to translation)
            qryXModulTree.CanDelete = hasUserAdvancedEditRights;    // depends on rights

            // setup controls
            ShowHideLabelAndControl(lblXIconID, edtXIconID, hasUserAdvancedEditRights, editMode);
            ShowHideLabelAndControl(lblClassName, edtClassName, hasUserAdvancedEditRights, editMode);
            ShowHideLabelAndControl(null, edtMaskName, hasUserAdvancedEditRights, editMode);
            ShowHideLabelAndControl(lblActive, edtActive, hasUserAdvancedEditRights, editMode);
            ShowHideLabelAndControl(lblSQLPreExecute, edtSQLPreExecute, hasUserAdvancedEditRights, editMode);
            ShowHideLabelAndControl(lblModulTreeCode, edtModulTreeCode, hasUserAdvancedEditRights, editMode);
            ShowHideLabelAndControl(null, edtModulTree_Value1, hasUserAdvancedEditRights, editMode);
            ShowHideLabelAndControl(null, edtInsert, hasUserAdvancedEditRights, editMode);
            ShowHideLabelAndControl(null, panDetailsSQL, hasUserAdvancedEditRights, editMode);
        }

        private void ShowHideLabelAndControl(Label lbl, Control edt, bool visible, EditModeType editMode)
        {
            // check if we have a label
            if (lbl != null)
            {
                // show or hide label
                lbl.Visible = visible;
            }

            // check if we have an editcontrol
            if (edt != null)
            {
                // show or hide control
                edt.Visible = visible;

                // check if IKissEditable
                if (edt is IKissEditable)
                {
                    // set editmode
                    ((IKissEditable)edt).EditMode = editMode;
                }
                else
                {
                    // lock or unlock control depending on given editmode (just to ensure everything is secured)
                    edt.Enabled = editMode == EditModeType.Normal;
                }
            }
        }

        private void TreeExpandAll()
        {
            treModulTree.ExpandAll();
            treModulTree.Focus();
        }

        #endregion

        #endregion
    }
}