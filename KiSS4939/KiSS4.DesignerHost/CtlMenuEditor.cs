using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.DesignerHost
{
    /// <summary>
    /// Summary description for CtlMenuEditor.
    /// </summary>
    public class CtlMenuEditor : KiSS4.Gui.KissUserControl
    {
        #region Enumerations

        /// <summary>
        /// Enumeration of the access mode
        /// </summary>
        private enum AccessMode
        {
            /// <summary>
            /// Access to normal administrator
            /// </summary>
            Admin,

            /// <summary>
            /// Access to BIAG administrator
            /// </summary>
            BIAGAdmin
        }

        #endregion

        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly AccessMode _accessMode;

        #endregion

        #region Private Fields

        private bool _isRefreshingTree = false; // Refresh tree after changes made to data
        private int _lastSelectedPosition = -1;
        private KissMainForm _mainForm = null;
        private bool _menuItemChanged = false;
        private int _parentMenuItemID = -1;
        private int _sortKey = -1;
        private KissButton btnCollapseAll;
        private KiSS4.Gui.KissButton btnDown;
        private KissButton btnExpandAll;
        private KiSS4.Gui.KissButton btnLeft;
        private KiSS4.Gui.KissButton btnRefresh;
        private KiSS4.Gui.KissButton btnRefreshToolbar;
        private KiSS4.Gui.KissButton btnRight;
        private KiSS4.Gui.KissButton btnToolbarDown;
        private KiSS4.Gui.KissButton btnToolbarUp;
        private KissButton btnTranslateRefresh;
        private KiSS4.Gui.KissButton btnUp;
        private KiSS4.Gui.KissLookUpEdit cboClassName;
        private KiSS4.Gui.KissImageComboBoxEdit cboImageIndex;
        private KiSS4.Gui.KissImageComboBoxEdit cboImageIndexDisabled;
        private KiSS4.Gui.KissComboBox cboItemShortcutKey;
        private KiSS4.Gui.KissCheckEdit chkBeginMenuGroup;
        private KiSS4.Gui.KissCheckEdit chkBeginToolbarGroup;
        private KiSS4.Gui.KissCheckEdit chkBeginToolbarGroup2;
        private KiSS4.Gui.KissCheckEdit chkEnabled;
        private KiSS4.Gui.KissCheckEdit chkEnabled2;
        private KiSS4.Gui.KissCheckEdit chkHideLockedItems;
        private KiSS4.Gui.KissCheckEdit chkItemShortcutAlt;
        private KiSS4.Gui.KissCheckEdit chkItemShortcutCtrl;
        private KiSS4.Gui.KissCheckEdit chkItemShortcutShift;
        private KissCheckEdit chkMenuOnlyBIAGAdmin;
        private KiSS4.Gui.KissCheckEdit chkNavBarGroup;
        private KiSS4.Gui.KissCheckEdit chkNavBarItem;
        private KissCheckEdit chkQuery;
        private KiSS4.Gui.KissCheckEdit chkShowInToolbar;
        private KiSS4.Gui.KissCheckEdit chkShowInToolbar2;
        private KiSS4.Gui.KissCheckEdit chkStaticItem;
        private KiSS4.Gui.KissCheckEdit chkStaticItem2;
        private KiSS4.Gui.KissCheckEdit chkSystem;
        private KiSS4.Gui.KissCheckEdit chkSystem2;
        private KiSS4.Gui.KissCheckEdit chkVisible;
        private KiSS4.Gui.KissCheckEdit chkVisible2;
        private DevExpress.XtraGrid.Columns.GridColumn colBeginToolbarGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colCaption;
        private DevExpress.XtraGrid.Columns.GridColumn colEnabled;
        private DevExpress.XtraGrid.Columns.GridColumn colIcon;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMenuItems;
        private DevExpress.XtraGrid.Columns.GridColumn colShowInToolbar;
        private DevExpress.XtraGrid.Columns.GridColumn colSystem;
        private DevExpress.XtraGrid.Columns.GridColumn colToolbarSortKey;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTranslateMenuItems;
        private DevExpress.XtraGrid.Columns.GridColumn colVisible;
        private System.ComponentModel.IContainer components;
        private CtlXRight ctlXRight;
        private KiSS4.Gui.KissTextEditML edtCaptionML;
        private KiSS4.Gui.KissTextEdit edtControlID;
        private KiSS4.Gui.KissMemoEdit edtDescription;
        private KissTextEditML edtTranslationCaptionML;
        private KiSS4.Gui.KissGroupBox gbFlags;
        private KiSS4.Gui.KissGroupBox gbNavBarFlags;
        private KiSS4.Gui.KissGroupBox gbToolbar;
        private KiSS4.Gui.KissGrid grdToolbar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvToolbar;
        private KiSS4.Gui.KissLabel lblBeginToolbarGroup;
        private KiSS4.Gui.KissLabel lblBeginToolbarGroup2;
        private KiSS4.Gui.KissLabel lblCaption;
        private KiSS4.Gui.KissLabel lblClassName;
        private KiSS4.Gui.KissLabel lblControlID;
        private KiSS4.Gui.KissLabel lblDescription;
        private KiSS4.Gui.KissLabel lblEnabled;
        private KiSS4.Gui.KissLabel lblEnabled2;
        private KiSS4.Gui.KissLabel lblHideLockedItems;
        private KiSS4.Gui.KissLabel lblImageIndex;
        private KiSS4.Gui.KissLabel lblImageIndexDisabled;
        private KiSS4.Gui.KissLabel lblItemShortcut;
        private KissLabel lblMenuOnlyBIAGAdmin;
        private KiSS4.Gui.KissLabel lblNavBarGroup;
        private KiSS4.Gui.KissLabel lblNavBarItem;
        private KiSS4.Gui.KissLabel lblNewGroup;
        private KissLabel lblQuery;
        private KiSS4.Gui.KissLabel lblShowInToolbar;
        private KiSS4.Gui.KissLabel lblShowInToolbar2;
        private KiSS4.Gui.KissLabel lblStaticItem;
        private KiSS4.Gui.KissLabel lblStaticItem2;
        private KiSS4.Gui.KissLabel lblSystem;
        private KiSS4.Gui.KissLabel lblSystem2;
        private KiSS4.Gui.KissLabel lblToolbarSortKey;
        private KiSS4.Gui.KissLabel lblToolbarSortKey2;
        private KissLabel lblTranslationCaptionML;
        private KiSS4.Gui.KissLabel lblVisible;
        private KiSS4.Gui.KissLabel lblVisible2;
        private System.Windows.Forms.Panel panBottomOfTree;
        private System.Windows.Forms.Panel panMenuDetail;
        private Panel panTranslateDetails;
        private System.Windows.Forms.Panel pnlToolbarButtons;
        private System.Windows.Forms.Panel pnlTree;
        private KiSS4.DB.SqlQuery qryToolbar;
        private KiSS4.DB.SqlQuery qryTreeItems;
        private KiSS4.DB.SqlQuery qryXMenuItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemIcon;
        private KiSS4.Gui.KissSplitter splitter;
        private KiSS4.Gui.KissTabControlEx tabMenuToolbar;
        private SharpLibrary.WinControls.TabPageEx tpgMenu;
        private SharpLibrary.WinControls.TabPageEx tpgToolbar;
        private SharpLibrary.WinControls.TabPageEx tpgTranslateMenu;
        private SharpLibrary.WinControls.TabPageEx tpgXRight;
        private KiSS4.Gui.KissTree treMenuItems;
        private KissTree treTranslateMenuItems;
        private KiSS4.Gui.KissCalcEdit txtToolbarSortKey;
        private KiSS4.Gui.KissCalcEdit txtToolbarSortKey2;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlMenuEditor"/> class.
        /// </summary>
        public CtlMenuEditor()
        {
            // set accessmode depending on current rights
            this._accessMode = SetupRights();

            // this call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // set mainform
            this.MainForm = (KissMainForm)Session.MainForm;

            // init control depending on rights
            InitControlWithRights();
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlMenuEditor));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryXMenuItem = new KiSS4.DB.SqlQuery(this.components);
            this.lblImageIndex = new KiSS4.Gui.KissLabel();
            this.lblNewGroup = new KiSS4.Gui.KissLabel();
            this.lblSystem = new KiSS4.Gui.KissLabel();
            this.lblClassName = new KiSS4.Gui.KissLabel();
            this.edtDescription = new KiSS4.Gui.KissMemoEdit();
            this.lblDescription = new KiSS4.Gui.KissLabel();
            this.treMenuItems = new KiSS4.Gui.KissTree();
            this.colMenuItems = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.qryTreeItems = new KiSS4.DB.SqlQuery(this.components);
            this.panMenuDetail = new System.Windows.Forms.Panel();
            this.gbNavBarFlags = new KiSS4.Gui.KissGroupBox();
            this.edtControlID = new KiSS4.Gui.KissTextEdit();
            this.lblNavBarItem = new KiSS4.Gui.KissLabel();
            this.chkNavBarItem = new KiSS4.Gui.KissCheckEdit();
            this.chkNavBarGroup = new KiSS4.Gui.KissCheckEdit();
            this.lblNavBarGroup = new KiSS4.Gui.KissLabel();
            this.lblControlID = new KiSS4.Gui.KissLabel();
            this.gbFlags = new KiSS4.Gui.KissGroupBox();
            this.lblQuery = new KiSS4.Gui.KissLabel();
            this.chkQuery = new KiSS4.Gui.KissCheckEdit();
            this.lblStaticItem = new KiSS4.Gui.KissLabel();
            this.chkStaticItem = new KiSS4.Gui.KissCheckEdit();
            this.chkSystem = new KiSS4.Gui.KissCheckEdit();
            this.lblHideLockedItems = new KiSS4.Gui.KissLabel();
            this.chkHideLockedItems = new KiSS4.Gui.KissCheckEdit();
            this.gbToolbar = new KiSS4.Gui.KissGroupBox();
            this.txtToolbarSortKey = new KiSS4.Gui.KissCalcEdit();
            this.lblToolbarSortKey = new KiSS4.Gui.KissLabel();
            this.chkBeginToolbarGroup = new KiSS4.Gui.KissCheckEdit();
            this.chkShowInToolbar = new KiSS4.Gui.KissCheckEdit();
            this.lblBeginToolbarGroup = new KiSS4.Gui.KissLabel();
            this.lblShowInToolbar = new KiSS4.Gui.KissLabel();
            this.edtCaptionML = new KiSS4.Gui.KissTextEditML();
            this.cboItemShortcutKey = new KiSS4.Gui.KissComboBox();
            this.cboImageIndex = new KiSS4.Gui.KissImageComboBoxEdit();
            this.chkBeginMenuGroup = new KiSS4.Gui.KissCheckEdit();
            this.chkMenuOnlyBIAGAdmin = new KiSS4.Gui.KissCheckEdit();
            this.chkVisible = new KiSS4.Gui.KissCheckEdit();
            this.chkEnabled = new KiSS4.Gui.KissCheckEdit();
            this.lblImageIndexDisabled = new KiSS4.Gui.KissLabel();
            this.lblItemShortcut = new KiSS4.Gui.KissLabel();
            this.lblCaption = new KiSS4.Gui.KissLabel();
            this.lblEnabled = new KiSS4.Gui.KissLabel();
            this.lblMenuOnlyBIAGAdmin = new KiSS4.Gui.KissLabel();
            this.lblVisible = new KiSS4.Gui.KissLabel();
            this.cboImageIndexDisabled = new KiSS4.Gui.KissImageComboBoxEdit();
            this.cboClassName = new KiSS4.Gui.KissLookUpEdit();
            this.chkItemShortcutCtrl = new KiSS4.Gui.KissCheckEdit();
            this.chkItemShortcutShift = new KiSS4.Gui.KissCheckEdit();
            this.chkItemShortcutAlt = new KiSS4.Gui.KissCheckEdit();
            this.pnlTree = new System.Windows.Forms.Panel();
            this.panBottomOfTree = new System.Windows.Forms.Panel();
            this.btnRefresh = new KiSS4.Gui.KissButton();
            this.btnLeft = new KiSS4.Gui.KissButton();
            this.btnDown = new KiSS4.Gui.KissButton();
            this.btnUp = new KiSS4.Gui.KissButton();
            this.btnRight = new KiSS4.Gui.KissButton();
            this.tabMenuToolbar = new KiSS4.Gui.KissTabControlEx();
            this.tpgTranslateMenu = new SharpLibrary.WinControls.TabPageEx();
            this.treTranslateMenuItems = new KiSS4.Gui.KissTree();
            this.colTranslateMenuItems = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panTranslateDetails = new System.Windows.Forms.Panel();
            this.btnCollapseAll = new KiSS4.Gui.KissButton();
            this.btnExpandAll = new KiSS4.Gui.KissButton();
            this.btnTranslateRefresh = new KiSS4.Gui.KissButton();
            this.edtTranslationCaptionML = new KiSS4.Gui.KissTextEditML();
            this.lblTranslationCaptionML = new KiSS4.Gui.KissLabel();
            this.tpgMenu = new SharpLibrary.WinControls.TabPageEx();
            this.splitter = new KiSS4.Gui.KissSplitter();
            this.tpgToolbar = new SharpLibrary.WinControls.TabPageEx();
            this.grdToolbar = new KiSS4.Gui.KissGrid();
            this.qryToolbar = new KiSS4.DB.SqlQuery(this.components);
            this.grvToolbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnabled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colVisible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colBeginToolbarGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colToolbarSortKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colShowInToolbar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colIcon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemIcon = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.pnlToolbarButtons = new System.Windows.Forms.Panel();
            this.btnRefreshToolbar = new KiSS4.Gui.KissButton();
            this.chkBeginToolbarGroup2 = new KiSS4.Gui.KissCheckEdit();
            this.txtToolbarSortKey2 = new KiSS4.Gui.KissCalcEdit();
            this.lblToolbarSortKey2 = new KiSS4.Gui.KissLabel();
            this.chkStaticItem2 = new KiSS4.Gui.KissCheckEdit();
            this.btnToolbarDown = new KiSS4.Gui.KissButton();
            this.btnToolbarUp = new KiSS4.Gui.KissButton();
            this.chkEnabled2 = new KiSS4.Gui.KissCheckEdit();
            this.chkVisible2 = new KiSS4.Gui.KissCheckEdit();
            this.chkSystem2 = new KiSS4.Gui.KissCheckEdit();
            this.chkShowInToolbar2 = new KiSS4.Gui.KissCheckEdit();
            this.lblSystem2 = new KiSS4.Gui.KissLabel();
            this.lblStaticItem2 = new KiSS4.Gui.KissLabel();
            this.lblEnabled2 = new KiSS4.Gui.KissLabel();
            this.lblVisible2 = new KiSS4.Gui.KissLabel();
            this.lblShowInToolbar2 = new KiSS4.Gui.KissLabel();
            this.lblBeginToolbarGroup2 = new KiSS4.Gui.KissLabel();
            this.tpgXRight = new SharpLibrary.WinControls.TabPageEx();
            this.ctlXRight = new KiSS4.DesignerHost.CtlXRight();
            ((System.ComponentModel.ISupportInitialize)(this.qryXMenuItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblImageIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNewGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClassName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treMenuItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTreeItems)).BeginInit();
            this.panMenuDetail.SuspendLayout();
            this.gbNavBarFlags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtControlID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNavBarItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNavBarItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNavBarGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNavBarGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblControlID)).BeginInit();
            this.gbFlags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStaticItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStaticItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSystem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHideLockedItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHideLockedItems.Properties)).BeginInit();
            this.gbToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtToolbarSortKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToolbarSortKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBeginToolbarGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowInToolbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeginToolbarGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblShowInToolbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCaptionML.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemShortcutKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboImageIndex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBeginMenuGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMenuOnlyBIAGAdmin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVisible.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnabled.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblImageIndexDisabled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemShortcut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEnabled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMenuOnlyBIAGAdmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVisible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboImageIndexDisabled.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClassName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClassName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkItemShortcutCtrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkItemShortcutShift.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkItemShortcutAlt.Properties)).BeginInit();
            this.pnlTree.SuspendLayout();
            this.panBottomOfTree.SuspendLayout();
            this.tabMenuToolbar.SuspendLayout();
            this.tpgTranslateMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treTranslateMenuItems)).BeginInit();
            this.panTranslateDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTranslationCaptionML.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTranslationCaptionML)).BeginInit();
            this.tpgMenu.SuspendLayout();
            this.tpgToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdToolbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryToolbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvToolbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemIcon)).BeginInit();
            this.pnlToolbarButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkBeginToolbarGroup2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToolbarSortKey2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToolbarSortKey2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStaticItem2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnabled2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVisible2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSystem2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowInToolbar2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSystem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStaticItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEnabled2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVisible2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblShowInToolbar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeginToolbarGroup2)).BeginInit();
            this.tpgXRight.SuspendLayout();
            this.SuspendLayout();
            //
            // qryXMenuItem
            //
            this.qryXMenuItem.CanUpdate = true;
            this.qryXMenuItem.HostControl = this;
            this.qryXMenuItem.TableName = "XMenuItem";
            this.qryXMenuItem.PostCompleted += new System.EventHandler(this.qryXMenuItem_PostCompleted);
            this.qryXMenuItem.BeforePost += new System.EventHandler(this.qryXMenuItem_BeforePost);
            this.qryXMenuItem.PositionChanged += new System.EventHandler(this.qryXMenuItem_PositionChanged);
            this.qryXMenuItem.AfterInsert += new System.EventHandler(this.qryXMenuItem_AfterInsert);
            this.qryXMenuItem.BeforeInsert += new System.EventHandler(this.qryXMenuItem_BeforeInsert);
            //
            // lblImageIndex
            //
            this.lblImageIndex.Location = new System.Drawing.Point(11, 112);
            this.lblImageIndex.Name = "lblImageIndex";
            this.lblImageIndex.Size = new System.Drawing.Size(128, 24);
            this.lblImageIndex.TabIndex = 7;
            this.lblImageIndex.Text = "Icon";
            //
            // lblNewGroup
            //
            this.lblNewGroup.Location = new System.Drawing.Point(11, 223);
            this.lblNewGroup.Name = "lblNewGroup";
            this.lblNewGroup.Size = new System.Drawing.Size(128, 24);
            this.lblNewGroup.TabIndex = 13;
            this.lblNewGroup.Text = "Neue Gruppe im Menu";
            //
            // lblSystem
            //
            this.lblSystem.Location = new System.Drawing.Point(16, 16);
            this.lblSystem.Name = "lblSystem";
            this.lblSystem.Size = new System.Drawing.Size(144, 24);
            this.lblSystem.TabIndex = 0;
            this.lblSystem.Text = "System";
            //
            // lblClassName
            //
            this.lblClassName.Location = new System.Drawing.Point(11, 184);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(128, 24);
            this.lblClassName.TabIndex = 11;
            this.lblClassName.Text = "Klassenname";
            //
            // edtDescription
            //
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.DataMember = "Description";
            this.edtDescription.DataSource = this.qryXMenuItem;
            this.edtDescription.Location = new System.Drawing.Point(144, 339);
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDescription.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDescription.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDescription.Properties.Appearance.Options.UseBackColor = true;
            this.edtDescription.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDescription.Properties.Appearance.Options.UseFont = true;
            this.edtDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDescription.Size = new System.Drawing.Size(200, 72);
            this.edtDescription.TabIndex = 22;
            //
            // lblDescription
            //
            this.lblDescription.Location = new System.Drawing.Point(11, 339);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(128, 24);
            this.lblDescription.TabIndex = 21;
            this.lblDescription.Text = "Beschreibung";
            //
            // treMenuItems
            //
            this.treMenuItems.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treMenuItems.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treMenuItems.Appearance.Empty.Options.UseBackColor = true;
            this.treMenuItems.Appearance.Empty.Options.UseForeColor = true;
            this.treMenuItems.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treMenuItems.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treMenuItems.Appearance.EvenRow.Options.UseBackColor = true;
            this.treMenuItems.Appearance.EvenRow.Options.UseForeColor = true;
            this.treMenuItems.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treMenuItems.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treMenuItems.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treMenuItems.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treMenuItems.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treMenuItems.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treMenuItems.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treMenuItems.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treMenuItems.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treMenuItems.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treMenuItems.Appearance.FooterPanel.Options.UseFont = true;
            this.treMenuItems.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treMenuItems.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treMenuItems.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treMenuItems.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treMenuItems.Appearance.GroupButton.Options.UseBackColor = true;
            this.treMenuItems.Appearance.GroupButton.Options.UseFont = true;
            this.treMenuItems.Appearance.GroupButton.Options.UseForeColor = true;
            this.treMenuItems.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treMenuItems.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treMenuItems.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treMenuItems.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treMenuItems.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treMenuItems.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treMenuItems.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treMenuItems.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treMenuItems.Appearance.HeaderPanel.Options.UseFont = true;
            this.treMenuItems.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treMenuItems.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treMenuItems.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treMenuItems.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treMenuItems.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treMenuItems.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treMenuItems.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treMenuItems.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treMenuItems.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treMenuItems.Appearance.HorzLine.Options.UseBackColor = true;
            this.treMenuItems.Appearance.HorzLine.Options.UseForeColor = true;
            this.treMenuItems.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treMenuItems.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treMenuItems.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treMenuItems.Appearance.OddRow.Options.UseBackColor = true;
            this.treMenuItems.Appearance.OddRow.Options.UseFont = true;
            this.treMenuItems.Appearance.OddRow.Options.UseForeColor = true;
            this.treMenuItems.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treMenuItems.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treMenuItems.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treMenuItems.Appearance.Preview.Options.UseBackColor = true;
            this.treMenuItems.Appearance.Preview.Options.UseFont = true;
            this.treMenuItems.Appearance.Preview.Options.UseForeColor = true;
            this.treMenuItems.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treMenuItems.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treMenuItems.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treMenuItems.Appearance.Row.Options.UseBackColor = true;
            this.treMenuItems.Appearance.Row.Options.UseFont = true;
            this.treMenuItems.Appearance.Row.Options.UseForeColor = true;
            this.treMenuItems.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treMenuItems.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treMenuItems.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treMenuItems.Appearance.TreeLine.Options.UseBackColor = true;
            this.treMenuItems.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treMenuItems.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treMenuItems.Appearance.VertLine.Options.UseBackColor = true;
            this.treMenuItems.Appearance.VertLine.Options.UseForeColor = true;
            this.treMenuItems.Appearance.VertLine.Options.UseTextOptions = true;
            this.treMenuItems.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treMenuItems.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colMenuItems});
            this.treMenuItems.DataSource = this.qryTreeItems;
            this.treMenuItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treMenuItems.ImageIndexFieldName = "ImageIndexCompact";
            this.treMenuItems.KeyFieldName = "MenuItemID";
            this.treMenuItems.Location = new System.Drawing.Point(0, 0);
            this.treMenuItems.Name = "treMenuItems";
            this.treMenuItems.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treMenuItems.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treMenuItems.OptionsBehavior.Editable = false;
            this.treMenuItems.OptionsBehavior.KeepSelectedOnClick = false;
            this.treMenuItems.OptionsBehavior.MoveOnEdit = false;
            this.treMenuItems.OptionsBehavior.PopulateServiceColumns = true;
            this.treMenuItems.OptionsMenu.EnableColumnMenu = false;
            this.treMenuItems.OptionsMenu.EnableFooterMenu = false;
            this.treMenuItems.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treMenuItems.OptionsView.AutoWidth = false;
            this.treMenuItems.OptionsView.EnableAppearanceEvenRow = true;
            this.treMenuItems.OptionsView.EnableAppearanceOddRow = true;
            this.treMenuItems.OptionsView.ShowIndicator = false;
            this.treMenuItems.ParentFieldName = "ParentMenuItemID";
            this.treMenuItems.Size = new System.Drawing.Size(272, 419);
            this.treMenuItems.TabIndex = 0;
            this.treMenuItems.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.MenuTree_FocusedNodeChanged);
            //
            // colMenuItems
            //
            this.colMenuItems.Caption = "Text";
            this.colMenuItems.FieldName = "Text";
            this.colMenuItems.Name = "colMenuItems";
            this.colMenuItems.OptionsColumn.AllowSort = false;
            this.colMenuItems.VisibleIndex = 0;
            this.colMenuItems.Width = 248;
            //
            // qryTreeItems
            //
            this.qryTreeItems.HostControl = this;
            this.qryTreeItems.TableName = "XMenuItem";
            this.qryTreeItems.AfterFill += new System.EventHandler(this.qryTreeItems_AfterFill);
            //
            // panMenuDetail
            //
            this.panMenuDetail.Controls.Add(this.gbNavBarFlags);
            this.panMenuDetail.Controls.Add(this.gbFlags);
            this.panMenuDetail.Controls.Add(this.gbToolbar);
            this.panMenuDetail.Controls.Add(this.edtCaptionML);
            this.panMenuDetail.Controls.Add(this.cboItemShortcutKey);
            this.panMenuDetail.Controls.Add(this.cboImageIndex);
            this.panMenuDetail.Controls.Add(this.chkBeginMenuGroup);
            this.panMenuDetail.Controls.Add(this.chkMenuOnlyBIAGAdmin);
            this.panMenuDetail.Controls.Add(this.chkVisible);
            this.panMenuDetail.Controls.Add(this.chkEnabled);
            this.panMenuDetail.Controls.Add(this.lblImageIndexDisabled);
            this.panMenuDetail.Controls.Add(this.lblItemShortcut);
            this.panMenuDetail.Controls.Add(this.lblImageIndex);
            this.panMenuDetail.Controls.Add(this.lblNewGroup);
            this.panMenuDetail.Controls.Add(this.lblClassName);
            this.panMenuDetail.Controls.Add(this.lblDescription);
            this.panMenuDetail.Controls.Add(this.edtDescription);
            this.panMenuDetail.Controls.Add(this.lblCaption);
            this.panMenuDetail.Controls.Add(this.lblEnabled);
            this.panMenuDetail.Controls.Add(this.lblMenuOnlyBIAGAdmin);
            this.panMenuDetail.Controls.Add(this.lblVisible);
            this.panMenuDetail.Controls.Add(this.cboImageIndexDisabled);
            this.panMenuDetail.Controls.Add(this.cboClassName);
            this.panMenuDetail.Controls.Add(this.chkItemShortcutCtrl);
            this.panMenuDetail.Controls.Add(this.chkItemShortcutShift);
            this.panMenuDetail.Controls.Add(this.chkItemShortcutAlt);
            this.panMenuDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMenuDetail.Location = new System.Drawing.Point(272, 0);
            this.panMenuDetail.Name = "panMenuDetail";
            this.panMenuDetail.Size = new System.Drawing.Size(716, 459);
            this.panMenuDetail.TabIndex = 1;
            //
            // gbNavBarFlags
            //
            this.gbNavBarFlags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNavBarFlags.Controls.Add(this.edtControlID);
            this.gbNavBarFlags.Controls.Add(this.lblNavBarItem);
            this.gbNavBarFlags.Controls.Add(this.chkNavBarItem);
            this.gbNavBarFlags.Controls.Add(this.chkNavBarGroup);
            this.gbNavBarFlags.Controls.Add(this.lblNavBarGroup);
            this.gbNavBarFlags.Controls.Add(this.lblControlID);
            this.gbNavBarFlags.Location = new System.Drawing.Point(370, 136);
            this.gbNavBarFlags.Name = "gbNavBarFlags";
            this.gbNavBarFlags.Size = new System.Drawing.Size(326, 116);
            this.gbNavBarFlags.TabIndex = 24;
            this.gbNavBarFlags.TabStop = false;
            this.gbNavBarFlags.Text = "Fensternavigation";
            //
            // edtControlID
            //
            this.edtControlID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtControlID.Location = new System.Drawing.Point(168, 80);
            this.edtControlID.Name = "edtControlID";
            this.edtControlID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtControlID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtControlID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtControlID.Properties.Appearance.Options.UseBackColor = true;
            this.edtControlID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtControlID.Properties.Appearance.Options.UseFont = true;
            this.edtControlID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtControlID.Properties.ReadOnly = true;
            this.edtControlID.Size = new System.Drawing.Size(148, 24);
            this.edtControlID.TabIndex = 5;
            this.edtControlID.Leave += new System.EventHandler(this.edtControlID_Leave);
            //
            // lblNavBarItem
            //
            this.lblNavBarItem.Location = new System.Drawing.Point(16, 48);
            this.lblNavBarItem.Name = "lblNavBarItem";
            this.lblNavBarItem.Size = new System.Drawing.Size(144, 24);
            this.lblNavBarItem.TabIndex = 2;
            this.lblNavBarItem.Text = "Navigationselement";
            //
            // chkNavBarItem
            //
            this.chkNavBarItem.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkNavBarItem.EditValue = false;
            this.chkNavBarItem.Location = new System.Drawing.Point(168, 50);
            this.chkNavBarItem.Name = "chkNavBarItem";
            this.chkNavBarItem.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkNavBarItem.Properties.Appearance.Options.UseBackColor = true;
            this.chkNavBarItem.Properties.Caption = "";
            this.chkNavBarItem.Properties.ReadOnly = true;
            this.chkNavBarItem.Size = new System.Drawing.Size(24, 19);
            this.chkNavBarItem.TabIndex = 3;
            //
            // chkNavBarGroup
            //
            this.chkNavBarGroup.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkNavBarGroup.EditValue = false;
            this.chkNavBarGroup.Location = new System.Drawing.Point(168, 18);
            this.chkNavBarGroup.Name = "chkNavBarGroup";
            this.chkNavBarGroup.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkNavBarGroup.Properties.Appearance.Options.UseBackColor = true;
            this.chkNavBarGroup.Properties.Caption = "";
            this.chkNavBarGroup.Properties.ReadOnly = true;
            this.chkNavBarGroup.Size = new System.Drawing.Size(24, 19);
            this.chkNavBarGroup.TabIndex = 1;
            //
            // lblNavBarGroup
            //
            this.lblNavBarGroup.Location = new System.Drawing.Point(16, 16);
            this.lblNavBarGroup.Name = "lblNavBarGroup";
            this.lblNavBarGroup.Size = new System.Drawing.Size(144, 24);
            this.lblNavBarGroup.TabIndex = 0;
            this.lblNavBarGroup.Text = "Navigationsgruppe";
            //
            // lblControlID
            //
            this.lblControlID.Location = new System.Drawing.Point(16, 80);
            this.lblControlID.Name = "lblControlID";
            this.lblControlID.Size = new System.Drawing.Size(144, 24);
            this.lblControlID.TabIndex = 4;
            this.lblControlID.Text = "Name von statischem Link";
            //
            // gbFlags
            //
            this.gbFlags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFlags.Controls.Add(this.lblQuery);
            this.gbFlags.Controls.Add(this.chkQuery);
            this.gbFlags.Controls.Add(this.lblStaticItem);
            this.gbFlags.Controls.Add(this.chkStaticItem);
            this.gbFlags.Controls.Add(this.lblSystem);
            this.gbFlags.Controls.Add(this.chkSystem);
            this.gbFlags.Controls.Add(this.lblHideLockedItems);
            this.gbFlags.Controls.Add(this.chkHideLockedItems);
            this.gbFlags.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gbFlags.Location = new System.Drawing.Point(370, 269);
            this.gbFlags.Name = "gbFlags";
            this.gbFlags.Size = new System.Drawing.Size(326, 142);
            this.gbFlags.TabIndex = 25;
            this.gbFlags.TabStop = false;
            this.gbFlags.Text = "Flags";
            //
            // lblQuery
            //
            this.lblQuery.Location = new System.Drawing.Point(16, 80);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(144, 24);
            this.lblQuery.TabIndex = 4;
            this.lblQuery.Text = "Abfrage / Abfragegruppe";
            //
            // chkQuery
            //
            this.chkQuery.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkQuery.EditValue = false;
            this.chkQuery.Location = new System.Drawing.Point(168, 82);
            this.chkQuery.Name = "chkQuery";
            this.chkQuery.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkQuery.Properties.Appearance.Options.UseBackColor = true;
            this.chkQuery.Properties.Caption = "";
            this.chkQuery.Properties.ReadOnly = true;
            this.chkQuery.Size = new System.Drawing.Size(24, 19);
            this.chkQuery.TabIndex = 5;
            //
            // lblStaticItem
            //
            this.lblStaticItem.Location = new System.Drawing.Point(16, 48);
            this.lblStaticItem.Name = "lblStaticItem";
            this.lblStaticItem.Size = new System.Drawing.Size(144, 24);
            this.lblStaticItem.TabIndex = 2;
            this.lblStaticItem.Text = "Statisch";
            //
            // chkStaticItem
            //
            this.chkStaticItem.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkStaticItem.EditValue = false;
            this.chkStaticItem.Location = new System.Drawing.Point(168, 50);
            this.chkStaticItem.Name = "chkStaticItem";
            this.chkStaticItem.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkStaticItem.Properties.Appearance.Options.UseBackColor = true;
            this.chkStaticItem.Properties.Caption = "";
            this.chkStaticItem.Properties.ReadOnly = true;
            this.chkStaticItem.Size = new System.Drawing.Size(24, 19);
            this.chkStaticItem.TabIndex = 3;
            //
            // chkSystem
            //
            this.chkSystem.DataMember = "System";
            this.chkSystem.DataSource = this.qryXMenuItem;
            this.chkSystem.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkSystem.Location = new System.Drawing.Point(168, 18);
            this.chkSystem.Name = "chkSystem";
            this.chkSystem.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSystem.Properties.Appearance.Options.UseBackColor = true;
            this.chkSystem.Properties.Caption = "";
            this.chkSystem.Properties.ReadOnly = true;
            this.chkSystem.Size = new System.Drawing.Size(24, 19);
            this.chkSystem.TabIndex = 1;
            //
            // lblHideLockedItems
            //
            this.lblHideLockedItems.Location = new System.Drawing.Point(16, 112);
            this.lblHideLockedItems.Name = "lblHideLockedItems";
            this.lblHideLockedItems.Size = new System.Drawing.Size(216, 24);
            this.lblHideLockedItems.TabIndex = 6;
            this.lblHideLockedItems.Text = "Unberechtigte Elemente verstecken";
            //
            // chkHideLockedItems
            //
            this.chkHideLockedItems.DataMember = "HideLockedItemsRoot";
            this.chkHideLockedItems.DataSource = this.qryXMenuItem;
            this.chkHideLockedItems.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkHideLockedItems.Location = new System.Drawing.Point(238, 114);
            this.chkHideLockedItems.Name = "chkHideLockedItems";
            this.chkHideLockedItems.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkHideLockedItems.Properties.Appearance.Options.UseBackColor = true;
            this.chkHideLockedItems.Properties.Caption = "";
            this.chkHideLockedItems.Properties.ReadOnly = true;
            this.chkHideLockedItems.Size = new System.Drawing.Size(16, 19);
            this.chkHideLockedItems.TabIndex = 7;
            this.chkHideLockedItems.CheckedChanged += new System.EventHandler(this.chkHideLockedItems_CheckedChanged);
            //
            // gbToolbar
            //
            this.gbToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbToolbar.Controls.Add(this.txtToolbarSortKey);
            this.gbToolbar.Controls.Add(this.lblToolbarSortKey);
            this.gbToolbar.Controls.Add(this.chkBeginToolbarGroup);
            this.gbToolbar.Controls.Add(this.chkShowInToolbar);
            this.gbToolbar.Controls.Add(this.lblBeginToolbarGroup);
            this.gbToolbar.Controls.Add(this.lblShowInToolbar);
            this.gbToolbar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gbToolbar.Location = new System.Drawing.Point(370, 8);
            this.gbToolbar.Name = "gbToolbar";
            this.gbToolbar.Size = new System.Drawing.Size(326, 116);
            this.gbToolbar.TabIndex = 23;
            this.gbToolbar.TabStop = false;
            this.gbToolbar.Text = "Toolbar";
            //
            // txtToolbarSortKey
            //
            this.txtToolbarSortKey.DataMember = "ToolbarSortKey";
            this.txtToolbarSortKey.DataSource = this.qryXMenuItem;
            this.txtToolbarSortKey.Location = new System.Drawing.Point(168, 80);
            this.txtToolbarSortKey.Name = "txtToolbarSortKey";
            this.txtToolbarSortKey.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtToolbarSortKey.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtToolbarSortKey.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtToolbarSortKey.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtToolbarSortKey.Properties.Appearance.Options.UseBackColor = true;
            this.txtToolbarSortKey.Properties.Appearance.Options.UseBorderColor = true;
            this.txtToolbarSortKey.Properties.Appearance.Options.UseFont = true;
            this.txtToolbarSortKey.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtToolbarSortKey.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.txtToolbarSortKey.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtToolbarSortKey.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtToolbarSortKey.Properties.Precision = 0;
            this.txtToolbarSortKey.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.txtToolbarSortKey.Size = new System.Drawing.Size(148, 24);
            this.txtToolbarSortKey.TabIndex = 5;
            //
            // lblToolbarSortKey
            //
            this.lblToolbarSortKey.Location = new System.Drawing.Point(16, 80);
            this.lblToolbarSortKey.Name = "lblToolbarSortKey";
            this.lblToolbarSortKey.Size = new System.Drawing.Size(144, 24);
            this.lblToolbarSortKey.TabIndex = 4;
            this.lblToolbarSortKey.Text = "Sortierung in Toolbar";
            //
            // chkBeginToolbarGroup
            //
            this.chkBeginToolbarGroup.DataMember = "BeginToolbarGroup";
            this.chkBeginToolbarGroup.DataSource = this.qryXMenuItem;
            this.chkBeginToolbarGroup.Location = new System.Drawing.Point(168, 50);
            this.chkBeginToolbarGroup.Name = "chkBeginToolbarGroup";
            this.chkBeginToolbarGroup.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkBeginToolbarGroup.Properties.Appearance.Options.UseBackColor = true;
            this.chkBeginToolbarGroup.Properties.Caption = "";
            this.chkBeginToolbarGroup.Size = new System.Drawing.Size(24, 19);
            this.chkBeginToolbarGroup.TabIndex = 3;
            //
            // chkShowInToolbar
            //
            this.chkShowInToolbar.DataMember = "ShowInToolbar";
            this.chkShowInToolbar.DataSource = this.qryXMenuItem;
            this.chkShowInToolbar.Location = new System.Drawing.Point(168, 18);
            this.chkShowInToolbar.Name = "chkShowInToolbar";
            this.chkShowInToolbar.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkShowInToolbar.Properties.Appearance.Options.UseBackColor = true;
            this.chkShowInToolbar.Properties.Caption = "";
            this.chkShowInToolbar.Size = new System.Drawing.Size(24, 19);
            this.chkShowInToolbar.TabIndex = 1;
            //
            // lblBeginToolbarGroup
            //
            this.lblBeginToolbarGroup.Location = new System.Drawing.Point(16, 48);
            this.lblBeginToolbarGroup.Name = "lblBeginToolbarGroup";
            this.lblBeginToolbarGroup.Size = new System.Drawing.Size(144, 24);
            this.lblBeginToolbarGroup.TabIndex = 2;
            this.lblBeginToolbarGroup.Text = "Neue Gruppe in Toolbar";
            //
            // lblShowInToolbar
            //
            this.lblShowInToolbar.Location = new System.Drawing.Point(16, 16);
            this.lblShowInToolbar.Name = "lblShowInToolbar";
            this.lblShowInToolbar.Size = new System.Drawing.Size(144, 24);
            this.lblShowInToolbar.TabIndex = 0;
            this.lblShowInToolbar.Text = "In Toolbar zeigen";
            //
            // edtCaptionML
            //
            this.edtCaptionML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtCaptionML.DataMemberDefaultText = "Caption";
            this.edtCaptionML.DataMemberTID = "MenuTID";
            this.edtCaptionML.DataSource = this.qryXMenuItem;
            this.edtCaptionML.Location = new System.Drawing.Point(144, 16);
            this.edtCaptionML.MaximumSize = new System.Drawing.Size(300, 24);
            this.edtCaptionML.Name = "edtCaptionML";
            this.edtCaptionML.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtCaptionML.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtCaptionML.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtCaptionML.Properties.Appearance.Options.UseBackColor = true;
            this.edtCaptionML.Properties.Appearance.Options.UseBorderColor = true;
            this.edtCaptionML.Properties.Appearance.Options.UseFont = true;
            this.edtCaptionML.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtCaptionML.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtCaptionML.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtCaptionML.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtCaptionML.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtCaptionML.Size = new System.Drawing.Size(200, 24);
            this.edtCaptionML.TabIndex = 1;
            //
            // cboItemShortcutKey
            //
            this.cboItemShortcutKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboItemShortcutKey.DataMember = "ItemShortcutKey";
            this.cboItemShortcutKey.DataSource = this.qryXMenuItem;
            this.cboItemShortcutKey.Location = new System.Drawing.Point(144, 72);
            this.cboItemShortcutKey.MaximumSize = new System.Drawing.Size(300, 24);
            this.cboItemShortcutKey.Name = "cboItemShortcutKey";
            this.cboItemShortcutKey.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboItemShortcutKey.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboItemShortcutKey.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboItemShortcutKey.Properties.Appearance.Options.UseBackColor = true;
            this.cboItemShortcutKey.Properties.Appearance.Options.UseBorderColor = true;
            this.cboItemShortcutKey.Properties.Appearance.Options.UseFont = true;
            this.cboItemShortcutKey.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboItemShortcutKey.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboItemShortcutKey.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboItemShortcutKey.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboItemShortcutKey.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.cboItemShortcutKey.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.cboItemShortcutKey.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboItemShortcutKey.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboItemShortcutKey.Size = new System.Drawing.Size(200, 24);
            this.cboItemShortcutKey.TabIndex = 6;
            //
            // cboImageIndex
            //
            this.cboImageIndex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboImageIndex.DataMember = "ImageIndex";
            this.cboImageIndex.DataSource = this.qryXMenuItem;
            this.cboImageIndex.Location = new System.Drawing.Point(144, 112);
            this.cboImageIndex.MaximumSize = new System.Drawing.Size(300, 24);
            this.cboImageIndex.Name = "cboImageIndex";
            this.cboImageIndex.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboImageIndex.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboImageIndex.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboImageIndex.Properties.Appearance.Options.UseBackColor = true;
            this.cboImageIndex.Properties.Appearance.Options.UseBorderColor = true;
            this.cboImageIndex.Properties.Appearance.Options.UseFont = true;
            this.cboImageIndex.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboImageIndex.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboImageIndex.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboImageIndex.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.cboImageIndex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.cboImageIndex.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboImageIndex.Properties.DropDownRows = 14;
            this.cboImageIndex.Size = new System.Drawing.Size(200, 24);
            this.cboImageIndex.TabIndex = 8;
            //
            // chkBeginMenuGroup
            //
            this.chkBeginMenuGroup.DataMember = "BeginMenuGroup";
            this.chkBeginMenuGroup.DataSource = this.qryXMenuItem;
            this.chkBeginMenuGroup.Location = new System.Drawing.Point(144, 226);
            this.chkBeginMenuGroup.Name = "chkBeginMenuGroup";
            this.chkBeginMenuGroup.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkBeginMenuGroup.Properties.Appearance.Options.UseBackColor = true;
            this.chkBeginMenuGroup.Properties.Caption = "";
            this.chkBeginMenuGroup.Size = new System.Drawing.Size(24, 19);
            this.chkBeginMenuGroup.TabIndex = 14;
            //
            // chkMenuOnlyBIAGAdmin
            //
            this.chkMenuOnlyBIAGAdmin.DataMember = "OnlyBIAGAdminVisible";
            this.chkMenuOnlyBIAGAdmin.DataSource = this.qryXMenuItem;
            this.chkMenuOnlyBIAGAdmin.Location = new System.Drawing.Point(144, 301);
            this.chkMenuOnlyBIAGAdmin.Name = "chkMenuOnlyBIAGAdmin";
            this.chkMenuOnlyBIAGAdmin.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkMenuOnlyBIAGAdmin.Properties.Appearance.Options.UseBackColor = true;
            this.chkMenuOnlyBIAGAdmin.Properties.Caption = "";
            this.chkMenuOnlyBIAGAdmin.Size = new System.Drawing.Size(24, 19);
            this.chkMenuOnlyBIAGAdmin.TabIndex = 20;
            //
            // chkVisible
            //
            this.chkVisible.DataMember = "Visible";
            this.chkVisible.DataSource = this.qryXMenuItem;
            this.chkVisible.Location = new System.Drawing.Point(144, 276);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkVisible.Properties.Appearance.Options.UseBackColor = true;
            this.chkVisible.Properties.Caption = "";
            this.chkVisible.Size = new System.Drawing.Size(24, 19);
            this.chkVisible.TabIndex = 18;
            //
            // chkEnabled
            //
            this.chkEnabled.DataMember = "Enabled";
            this.chkEnabled.DataSource = this.qryXMenuItem;
            this.chkEnabled.Location = new System.Drawing.Point(144, 251);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkEnabled.Properties.Appearance.Options.UseBackColor = true;
            this.chkEnabled.Properties.Caption = "";
            this.chkEnabled.Size = new System.Drawing.Size(24, 19);
            this.chkEnabled.TabIndex = 16;
            //
            // lblImageIndexDisabled
            //
            this.lblImageIndexDisabled.Location = new System.Drawing.Point(11, 144);
            this.lblImageIndexDisabled.Name = "lblImageIndexDisabled";
            this.lblImageIndexDisabled.Size = new System.Drawing.Size(128, 24);
            this.lblImageIndexDisabled.TabIndex = 9;
            this.lblImageIndexDisabled.Text = "Icon (deaktiviert)";
            //
            // lblItemShortcut
            //
            this.lblItemShortcut.Location = new System.Drawing.Point(11, 48);
            this.lblItemShortcut.Name = "lblItemShortcut";
            this.lblItemShortcut.Size = new System.Drawing.Size(128, 24);
            this.lblItemShortcut.TabIndex = 2;
            this.lblItemShortcut.Text = "Shortcut";
            //
            // lblCaption
            //
            this.lblCaption.Location = new System.Drawing.Point(11, 16);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(128, 24);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Text";
            //
            // lblEnabled
            //
            this.lblEnabled.Location = new System.Drawing.Point(11, 248);
            this.lblEnabled.Name = "lblEnabled";
            this.lblEnabled.Size = new System.Drawing.Size(128, 24);
            this.lblEnabled.TabIndex = 15;
            this.lblEnabled.Text = "Aktiviert";
            //
            // lblMenuOnlyBIAGAdmin
            //
            this.lblMenuOnlyBIAGAdmin.Location = new System.Drawing.Point(11, 298);
            this.lblMenuOnlyBIAGAdmin.Name = "lblMenuOnlyBIAGAdmin";
            this.lblMenuOnlyBIAGAdmin.Size = new System.Drawing.Size(128, 24);
            this.lblMenuOnlyBIAGAdmin.TabIndex = 19;
            this.lblMenuOnlyBIAGAdmin.Text = "Nur für BIAGAdmin";
            //
            // lblVisible
            //
            this.lblVisible.Location = new System.Drawing.Point(11, 273);
            this.lblVisible.Name = "lblVisible";
            this.lblVisible.Size = new System.Drawing.Size(128, 24);
            this.lblVisible.TabIndex = 17;
            this.lblVisible.Text = "Sichtbar";
            //
            // cboImageIndexDisabled
            //
            this.cboImageIndexDisabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboImageIndexDisabled.DataMember = "ImageIndexDisabled";
            this.cboImageIndexDisabled.DataSource = this.qryXMenuItem;
            this.cboImageIndexDisabled.Location = new System.Drawing.Point(144, 144);
            this.cboImageIndexDisabled.MaximumSize = new System.Drawing.Size(300, 24);
            this.cboImageIndexDisabled.Name = "cboImageIndexDisabled";
            this.cboImageIndexDisabled.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboImageIndexDisabled.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboImageIndexDisabled.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboImageIndexDisabled.Properties.Appearance.Options.UseBackColor = true;
            this.cboImageIndexDisabled.Properties.Appearance.Options.UseBorderColor = true;
            this.cboImageIndexDisabled.Properties.Appearance.Options.UseFont = true;
            this.cboImageIndexDisabled.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboImageIndexDisabled.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboImageIndexDisabled.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboImageIndexDisabled.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.cboImageIndexDisabled.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.cboImageIndexDisabled.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboImageIndexDisabled.Properties.DropDownRows = 14;
            this.cboImageIndexDisabled.Size = new System.Drawing.Size(200, 24);
            this.cboImageIndexDisabled.TabIndex = 10;
            //
            // cboClassName
            //
            this.cboClassName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboClassName.DataMember = "ClassName";
            this.cboClassName.DataSource = this.qryXMenuItem;
            this.cboClassName.Location = new System.Drawing.Point(144, 184);
            this.cboClassName.Name = "cboClassName";
            this.cboClassName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboClassName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboClassName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboClassName.Properties.Appearance.Options.UseBackColor = true;
            this.cboClassName.Properties.Appearance.Options.UseBorderColor = true;
            this.cboClassName.Properties.Appearance.Options.UseFont = true;
            this.cboClassName.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboClassName.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboClassName.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboClassName.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboClassName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.cboClassName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.cboClassName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboClassName.Properties.DropDownRows = 14;
            this.cboClassName.Properties.NullText = "";
            this.cboClassName.Properties.ShowFooter = false;
            this.cboClassName.Properties.ShowHeader = false;
            this.cboClassName.Size = new System.Drawing.Size(200, 24);
            this.cboClassName.TabIndex = 12;
            this.cboClassName.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.cboClassName_EditValueChanging);
            //
            // chkItemShortcutCtrl
            //
            this.chkItemShortcutCtrl.DataMember = "ItemShortcutCtrl";
            this.chkItemShortcutCtrl.DataSource = this.qryXMenuItem;
            this.chkItemShortcutCtrl.Location = new System.Drawing.Point(144, 50);
            this.chkItemShortcutCtrl.Name = "chkItemShortcutCtrl";
            this.chkItemShortcutCtrl.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkItemShortcutCtrl.Properties.Appearance.Options.UseBackColor = true;
            this.chkItemShortcutCtrl.Properties.Caption = "Ctrl";
            this.chkItemShortcutCtrl.Size = new System.Drawing.Size(48, 19);
            this.chkItemShortcutCtrl.TabIndex = 3;
            //
            // chkItemShortcutShift
            //
            this.chkItemShortcutShift.DataMember = "ItemShortcutShift";
            this.chkItemShortcutShift.DataSource = this.qryXMenuItem;
            this.chkItemShortcutShift.Location = new System.Drawing.Point(192, 50);
            this.chkItemShortcutShift.Name = "chkItemShortcutShift";
            this.chkItemShortcutShift.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkItemShortcutShift.Properties.Appearance.Options.UseBackColor = true;
            this.chkItemShortcutShift.Properties.Caption = "Shift";
            this.chkItemShortcutShift.Size = new System.Drawing.Size(48, 19);
            this.chkItemShortcutShift.TabIndex = 4;
            //
            // chkItemShortcutAlt
            //
            this.chkItemShortcutAlt.DataMember = "ItemShortcutAlt";
            this.chkItemShortcutAlt.DataSource = this.qryXMenuItem;
            this.chkItemShortcutAlt.Location = new System.Drawing.Point(248, 50);
            this.chkItemShortcutAlt.Name = "chkItemShortcutAlt";
            this.chkItemShortcutAlt.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkItemShortcutAlt.Properties.Appearance.Options.UseBackColor = true;
            this.chkItemShortcutAlt.Properties.Caption = "Alt";
            this.chkItemShortcutAlt.Size = new System.Drawing.Size(48, 19);
            this.chkItemShortcutAlt.TabIndex = 5;
            //
            // pnlTree
            //
            this.pnlTree.Controls.Add(this.treMenuItems);
            this.pnlTree.Controls.Add(this.panBottomOfTree);
            this.pnlTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTree.Location = new System.Drawing.Point(0, 0);
            this.pnlTree.Name = "pnlTree";
            this.pnlTree.Size = new System.Drawing.Size(272, 459);
            this.pnlTree.TabIndex = 14;
            //
            // panBottomOfTree
            //
            this.panBottomOfTree.Controls.Add(this.btnRefresh);
            this.panBottomOfTree.Controls.Add(this.btnLeft);
            this.panBottomOfTree.Controls.Add(this.btnDown);
            this.panBottomOfTree.Controls.Add(this.btnUp);
            this.panBottomOfTree.Controls.Add(this.btnRight);
            this.panBottomOfTree.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottomOfTree.Location = new System.Drawing.Point(0, 419);
            this.panBottomOfTree.Name = "panBottomOfTree";
            this.panBottomOfTree.Size = new System.Drawing.Size(272, 40);
            this.panBottomOfTree.TabIndex = 0;
            //
            // btnRefresh
            //
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(8, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(96, 24);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Anwenden";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            //
            // btnLeft
            //
            this.btnLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.IconID = 11;
            this.btnLeft.Location = new System.Drawing.Point(112, 8);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(32, 24);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeftRight_Click);
            //
            // btnDown
            //
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.IconID = 17;
            this.btnDown.Location = new System.Drawing.Point(232, 8);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(32, 24);
            this.btnDown.TabIndex = 4;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnUpDown_Click);
            //
            // btnUp
            //
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.IconID = 16;
            this.btnUp.Location = new System.Drawing.Point(192, 8);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(32, 24);
            this.btnUp.TabIndex = 3;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUpDown_Click);
            //
            // btnRight
            //
            this.btnRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.IconID = 13;
            this.btnRight.Location = new System.Drawing.Point(152, 8);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(32, 24);
            this.btnRight.TabIndex = 2;
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnLeftRight_Click);
            //
            // tabMenuToolbar
            //
            this.tabMenuToolbar.Controls.Add(this.tpgTranslateMenu);
            this.tabMenuToolbar.Controls.Add(this.tpgMenu);
            this.tabMenuToolbar.Controls.Add(this.tpgToolbar);
            this.tabMenuToolbar.Controls.Add(this.tpgXRight);
            this.tabMenuToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMenuToolbar.Location = new System.Drawing.Point(0, 0);
            this.tabMenuToolbar.Name = "tabMenuToolbar";
            this.tabMenuToolbar.SelectedTabIndex = 1;
            this.tabMenuToolbar.ShowFixedWidthTooltip = true;
            this.tabMenuToolbar.Size = new System.Drawing.Size(1000, 497);
            this.tabMenuToolbar.TabIndex = 0;
            this.tabMenuToolbar.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgTranslateMenu,
            this.tpgMenu,
            this.tpgToolbar,
            this.tpgXRight});
            this.tabMenuToolbar.TabsLineColor = System.Drawing.Color.Black;
            this.tabMenuToolbar.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabMenuToolbar.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabMenuToolbar.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabMenuToolbar_SelectedTabChanging);
            this.tabMenuToolbar.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabMenuToolbar_SelectedTabChanged);
            //
            // tpgTranslateMenu
            //
            this.tpgTranslateMenu.Controls.Add(this.treTranslateMenuItems);
            this.tpgTranslateMenu.Controls.Add(this.panTranslateDetails);
            this.tpgTranslateMenu.Location = new System.Drawing.Point(6, 32);
            this.tpgTranslateMenu.Name = "tpgTranslateMenu";
            this.tpgTranslateMenu.Size = new System.Drawing.Size(988, 459);
            this.tpgTranslateMenu.TabIndex = 0;
            this.tpgTranslateMenu.Title = "Übersetzung";
            //
            // treTranslateMenuItems
            //
            this.treTranslateMenuItems.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treTranslateMenuItems.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treTranslateMenuItems.Appearance.Empty.Options.UseBackColor = true;
            this.treTranslateMenuItems.Appearance.Empty.Options.UseForeColor = true;
            this.treTranslateMenuItems.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treTranslateMenuItems.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treTranslateMenuItems.Appearance.EvenRow.Options.UseBackColor = true;
            this.treTranslateMenuItems.Appearance.EvenRow.Options.UseForeColor = true;
            this.treTranslateMenuItems.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treTranslateMenuItems.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treTranslateMenuItems.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treTranslateMenuItems.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treTranslateMenuItems.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treTranslateMenuItems.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treTranslateMenuItems.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treTranslateMenuItems.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treTranslateMenuItems.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treTranslateMenuItems.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treTranslateMenuItems.Appearance.FooterPanel.Options.UseFont = true;
            this.treTranslateMenuItems.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treTranslateMenuItems.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treTranslateMenuItems.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treTranslateMenuItems.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treTranslateMenuItems.Appearance.GroupButton.Options.UseBackColor = true;
            this.treTranslateMenuItems.Appearance.GroupButton.Options.UseFont = true;
            this.treTranslateMenuItems.Appearance.GroupButton.Options.UseForeColor = true;
            this.treTranslateMenuItems.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treTranslateMenuItems.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treTranslateMenuItems.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treTranslateMenuItems.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treTranslateMenuItems.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treTranslateMenuItems.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treTranslateMenuItems.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treTranslateMenuItems.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treTranslateMenuItems.Appearance.HeaderPanel.Options.UseFont = true;
            this.treTranslateMenuItems.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treTranslateMenuItems.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treTranslateMenuItems.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treTranslateMenuItems.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treTranslateMenuItems.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treTranslateMenuItems.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treTranslateMenuItems.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treTranslateMenuItems.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treTranslateMenuItems.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treTranslateMenuItems.Appearance.HorzLine.Options.UseBackColor = true;
            this.treTranslateMenuItems.Appearance.HorzLine.Options.UseForeColor = true;
            this.treTranslateMenuItems.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treTranslateMenuItems.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treTranslateMenuItems.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treTranslateMenuItems.Appearance.OddRow.Options.UseBackColor = true;
            this.treTranslateMenuItems.Appearance.OddRow.Options.UseFont = true;
            this.treTranslateMenuItems.Appearance.OddRow.Options.UseForeColor = true;
            this.treTranslateMenuItems.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treTranslateMenuItems.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treTranslateMenuItems.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treTranslateMenuItems.Appearance.Preview.Options.UseBackColor = true;
            this.treTranslateMenuItems.Appearance.Preview.Options.UseFont = true;
            this.treTranslateMenuItems.Appearance.Preview.Options.UseForeColor = true;
            this.treTranslateMenuItems.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treTranslateMenuItems.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treTranslateMenuItems.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treTranslateMenuItems.Appearance.Row.Options.UseBackColor = true;
            this.treTranslateMenuItems.Appearance.Row.Options.UseFont = true;
            this.treTranslateMenuItems.Appearance.Row.Options.UseForeColor = true;
            this.treTranslateMenuItems.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treTranslateMenuItems.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treTranslateMenuItems.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treTranslateMenuItems.Appearance.TreeLine.Options.UseBackColor = true;
            this.treTranslateMenuItems.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treTranslateMenuItems.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treTranslateMenuItems.Appearance.VertLine.Options.UseBackColor = true;
            this.treTranslateMenuItems.Appearance.VertLine.Options.UseForeColor = true;
            this.treTranslateMenuItems.Appearance.VertLine.Options.UseTextOptions = true;
            this.treTranslateMenuItems.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treTranslateMenuItems.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colTranslateMenuItems});
            this.treTranslateMenuItems.DataSource = this.qryTreeItems;
            this.treTranslateMenuItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treTranslateMenuItems.ImageIndexFieldName = "ImageIndexCompact";
            this.treTranslateMenuItems.KeyFieldName = "MenuItemID";
            this.treTranslateMenuItems.Location = new System.Drawing.Point(0, 0);
            this.treTranslateMenuItems.Name = "treTranslateMenuItems";
            this.treTranslateMenuItems.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treTranslateMenuItems.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treTranslateMenuItems.OptionsBehavior.Editable = false;
            this.treTranslateMenuItems.OptionsBehavior.KeepSelectedOnClick = false;
            this.treTranslateMenuItems.OptionsBehavior.MoveOnEdit = false;
            this.treTranslateMenuItems.OptionsBehavior.PopulateServiceColumns = true;
            this.treTranslateMenuItems.OptionsMenu.EnableColumnMenu = false;
            this.treTranslateMenuItems.OptionsMenu.EnableFooterMenu = false;
            this.treTranslateMenuItems.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treTranslateMenuItems.OptionsView.AutoWidth = false;
            this.treTranslateMenuItems.OptionsView.EnableAppearanceEvenRow = true;
            this.treTranslateMenuItems.OptionsView.EnableAppearanceOddRow = true;
            this.treTranslateMenuItems.OptionsView.ShowIndicator = false;
            this.treTranslateMenuItems.ParentFieldName = "ParentMenuItemID";
            this.treTranslateMenuItems.Size = new System.Drawing.Size(988, 409);
            this.treTranslateMenuItems.TabIndex = 0;
            this.treTranslateMenuItems.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.MenuTree_FocusedNodeChanged);
            //
            // colTranslateMenuItems
            //
            this.colTranslateMenuItems.Caption = "Text";
            this.colTranslateMenuItems.FieldName = "Text";
            this.colTranslateMenuItems.Name = "colTranslateMenuItems";
            this.colTranslateMenuItems.OptionsColumn.AllowSort = false;
            this.colTranslateMenuItems.VisibleIndex = 0;
            this.colTranslateMenuItems.Width = 444;
            //
            // panTranslateDetails
            //
            this.panTranslateDetails.Controls.Add(this.btnCollapseAll);
            this.panTranslateDetails.Controls.Add(this.btnExpandAll);
            this.panTranslateDetails.Controls.Add(this.btnTranslateRefresh);
            this.panTranslateDetails.Controls.Add(this.edtTranslationCaptionML);
            this.panTranslateDetails.Controls.Add(this.lblTranslationCaptionML);
            this.panTranslateDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panTranslateDetails.Location = new System.Drawing.Point(0, 409);
            this.panTranslateDetails.Name = "panTranslateDetails";
            this.panTranslateDetails.Padding = new System.Windows.Forms.Padding(9);
            this.panTranslateDetails.Size = new System.Drawing.Size(988, 50);
            this.panTranslateDetails.TabIndex = 0;
            //
            // btnCollapseAll
            //
            this.btnCollapseAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollapseAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapseAll.Image")));
            this.btnCollapseAll.Location = new System.Drawing.Point(847, 12);
            this.btnCollapseAll.Margin = new System.Windows.Forms.Padding(3, 3, 6, 0);
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.Size = new System.Drawing.Size(24, 24);
            this.btnCollapseAll.TabIndex = 3;
            this.btnCollapseAll.UseVisualStyleBackColor = false;
            this.btnCollapseAll.Click += new System.EventHandler(this.btnCollapseAll_Click);
            //
            // btnExpandAll
            //
            this.btnExpandAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpandAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("btnExpandAll.Image")));
            this.btnExpandAll.Location = new System.Drawing.Point(817, 12);
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(24, 24);
            this.btnExpandAll.TabIndex = 2;
            this.btnExpandAll.UseVisualStyleBackColor = false;
            this.btnExpandAll.Click += new System.EventHandler(this.btnExpandAll_Click);
            //
            // btnTranslateRefresh
            //
            this.btnTranslateRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTranslateRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTranslateRefresh.Location = new System.Drawing.Point(880, 12);
            this.btnTranslateRefresh.Name = "btnTranslateRefresh";
            this.btnTranslateRefresh.Size = new System.Drawing.Size(96, 24);
            this.btnTranslateRefresh.TabIndex = 4;
            this.btnTranslateRefresh.Text = "Anwenden";
            this.btnTranslateRefresh.UseVisualStyleBackColor = false;
            this.btnTranslateRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            //
            // edtTranslationCaptionML
            //
            this.edtTranslationCaptionML.DataMemberDefaultText = "Caption";
            this.edtTranslationCaptionML.DataMemberTID = "MenuTID";
            this.edtTranslationCaptionML.DataSource = this.qryXMenuItem;
            this.edtTranslationCaptionML.Location = new System.Drawing.Point(85, 12);
            this.edtTranslationCaptionML.Name = "edtTranslationCaptionML";
            this.edtTranslationCaptionML.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTranslationCaptionML.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTranslationCaptionML.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTranslationCaptionML.Properties.Appearance.Options.UseBackColor = true;
            this.edtTranslationCaptionML.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTranslationCaptionML.Properties.Appearance.Options.UseFont = true;
            this.edtTranslationCaptionML.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtTranslationCaptionML.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtTranslationCaptionML.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtTranslationCaptionML.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTranslationCaptionML.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtTranslationCaptionML.Size = new System.Drawing.Size(300, 24);
            this.edtTranslationCaptionML.TabIndex = 1;
            //
            // lblTranslationCaptionML
            //
            this.lblTranslationCaptionML.Location = new System.Drawing.Point(12, 12);
            this.lblTranslationCaptionML.Name = "lblTranslationCaptionML";
            this.lblTranslationCaptionML.Size = new System.Drawing.Size(67, 24);
            this.lblTranslationCaptionML.TabIndex = 0;
            this.lblTranslationCaptionML.Text = "Text";
            //
            // tpgMenu
            //
            this.tpgMenu.Controls.Add(this.splitter);
            this.tpgMenu.Controls.Add(this.panMenuDetail);
            this.tpgMenu.Controls.Add(this.pnlTree);
            this.tpgMenu.Location = new System.Drawing.Point(6, 32);
            this.tpgMenu.Name = "tpgMenu";
            this.tpgMenu.Size = new System.Drawing.Size(988, 459);
            this.tpgMenu.TabIndex = 1;
            this.tpgMenu.Title = "Menu";
            //
            // splitter
            //
            this.splitter.Location = new System.Drawing.Point(272, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 459);
            this.splitter.TabIndex = 0;
            this.splitter.TabStop = false;
            this.splitter.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter_SplitterMoved);
            //
            // tpgToolbar
            //
            this.tpgToolbar.Controls.Add(this.grdToolbar);
            this.tpgToolbar.Controls.Add(this.pnlToolbarButtons);
            this.tpgToolbar.Location = new System.Drawing.Point(6, 32);
            this.tpgToolbar.Name = "tpgToolbar";
            this.tpgToolbar.Size = new System.Drawing.Size(988, 459);
            this.tpgToolbar.TabIndex = 2;
            this.tpgToolbar.Title = "Toolbar";
            //
            // grdToolbar
            //
            this.grdToolbar.DataSource = this.qryToolbar;
            this.grdToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdToolbar.EmbeddedNavigator.Name = "";
            this.grdToolbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdToolbar.Location = new System.Drawing.Point(128, 0);
            this.grdToolbar.MainView = this.grvToolbar;
            this.grdToolbar.Name = "grdToolbar";
            this.grdToolbar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3,
            this.repositoryItemCheckEdit4,
            this.repositoryItemCheckEdit5,
            this.repositoryItemIcon});
            this.grdToolbar.Size = new System.Drawing.Size(860, 459);
            this.grdToolbar.TabIndex = 1;
            this.grdToolbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvToolbar});
            //
            // qryToolbar
            //
            this.qryToolbar.CanUpdate = true;
            this.qryToolbar.HostControl = this;
            this.qryToolbar.TableName = "XMenuItem";
            this.qryToolbar.PostCompleted += new System.EventHandler(this.qryToolbar_PostCompleted);
            this.qryToolbar.BeforePost += new System.EventHandler(this.qryToolbar_BeforePost);
            this.qryToolbar.PositionChanged += new System.EventHandler(this.qryToolbar_PositionChanged);
            //
            // grvToolbar
            //
            this.grvToolbar.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvToolbar.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvToolbar.Appearance.Empty.Options.UseBackColor = true;
            this.grvToolbar.Appearance.Empty.Options.UseFont = true;
            this.grvToolbar.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvToolbar.Appearance.EvenRow.Options.UseFont = true;
            this.grvToolbar.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvToolbar.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvToolbar.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvToolbar.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvToolbar.Appearance.FocusedCell.Options.UseFont = true;
            this.grvToolbar.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvToolbar.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvToolbar.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvToolbar.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvToolbar.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvToolbar.Appearance.FocusedRow.Options.UseFont = true;
            this.grvToolbar.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvToolbar.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvToolbar.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvToolbar.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvToolbar.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvToolbar.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvToolbar.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvToolbar.Appearance.GroupRow.Options.UseFont = true;
            this.grvToolbar.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvToolbar.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvToolbar.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvToolbar.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvToolbar.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvToolbar.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvToolbar.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvToolbar.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvToolbar.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvToolbar.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvToolbar.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvToolbar.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvToolbar.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvToolbar.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvToolbar.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvToolbar.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvToolbar.Appearance.OddRow.Options.UseFont = true;
            this.grvToolbar.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvToolbar.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvToolbar.Appearance.Row.Options.UseBackColor = true;
            this.grvToolbar.Appearance.Row.Options.UseFont = true;
            this.grvToolbar.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvToolbar.Appearance.SelectedRow.Options.UseFont = true;
            this.grvToolbar.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvToolbar.Appearance.VertLine.Options.UseBackColor = true;
            this.grvToolbar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvToolbar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCaption,
            this.colEnabled,
            this.colVisible,
            this.colBeginToolbarGroup,
            this.colToolbarSortKey,
            this.colSystem,
            this.colShowInToolbar,
            this.colIcon});
            this.grvToolbar.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvToolbar.GridControl = this.grdToolbar;
            this.grvToolbar.Name = "grvToolbar";
            this.grvToolbar.OptionsBehavior.Editable = false;
            this.grvToolbar.OptionsCustomization.AllowFilter = false;
            this.grvToolbar.OptionsFilter.AllowFilterEditor = false;
            this.grvToolbar.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvToolbar.OptionsNavigation.AutoFocusNewRow = true;
            this.grvToolbar.OptionsNavigation.UseTabKey = false;
            this.grvToolbar.OptionsView.ColumnAutoWidth = false;
            this.grvToolbar.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvToolbar.OptionsView.ShowGroupPanel = false;
            this.grvToolbar.OptionsView.ShowIndicator = false;
            //
            // colCaption
            //
            this.colCaption.Caption = "Text";
            this.colCaption.FieldName = "Text";
            this.colCaption.Name = "colCaption";
            this.colCaption.Visible = true;
            this.colCaption.VisibleIndex = 1;
            this.colCaption.Width = 283;
            //
            // colEnabled
            //
            this.colEnabled.Caption = "Aktiviert";
            this.colEnabled.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colEnabled.FieldName = "Enabled";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.Visible = true;
            this.colEnabled.VisibleIndex = 2;
            this.colEnabled.Width = 59;
            //
            // repositoryItemCheckEdit1
            //
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            //
            // colVisible
            //
            this.colVisible.Caption = "Sichtbar";
            this.colVisible.ColumnEdit = this.repositoryItemCheckEdit2;
            this.colVisible.FieldName = "Visible";
            this.colVisible.Name = "colVisible";
            this.colVisible.Visible = true;
            this.colVisible.VisibleIndex = 3;
            this.colVisible.Width = 57;
            //
            // repositoryItemCheckEdit2
            //
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            //
            // colBeginToolbarGroup
            //
            this.colBeginToolbarGroup.Caption = "Neue Gruppe";
            this.colBeginToolbarGroup.ColumnEdit = this.repositoryItemCheckEdit3;
            this.colBeginToolbarGroup.FieldName = "BeginToolbarGroup";
            this.colBeginToolbarGroup.Name = "colBeginToolbarGroup";
            this.colBeginToolbarGroup.Visible = true;
            this.colBeginToolbarGroup.VisibleIndex = 5;
            this.colBeginToolbarGroup.Width = 84;
            //
            // repositoryItemCheckEdit3
            //
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            //
            // colToolbarSortKey
            //
            this.colToolbarSortKey.AppearanceCell.Options.UseTextOptions = true;
            this.colToolbarSortKey.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colToolbarSortKey.Caption = "Sortierung";
            this.colToolbarSortKey.FieldName = "ToolbarSortKey";
            this.colToolbarSortKey.Name = "colToolbarSortKey";
            this.colToolbarSortKey.Visible = true;
            this.colToolbarSortKey.VisibleIndex = 6;
            this.colToolbarSortKey.Width = 71;
            //
            // colSystem
            //
            this.colSystem.Caption = "System";
            this.colSystem.ColumnEdit = this.repositoryItemCheckEdit4;
            this.colSystem.FieldName = "System";
            this.colSystem.Name = "colSystem";
            this.colSystem.Visible = true;
            this.colSystem.VisibleIndex = 7;
            this.colSystem.Width = 54;
            //
            // repositoryItemCheckEdit4
            //
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            //
            // colShowInToolbar
            //
            this.colShowInToolbar.Caption = "Toolbar";
            this.colShowInToolbar.ColumnEdit = this.repositoryItemCheckEdit5;
            this.colShowInToolbar.FieldName = "ShowInToolbar";
            this.colShowInToolbar.Name = "colShowInToolbar";
            this.colShowInToolbar.Visible = true;
            this.colShowInToolbar.VisibleIndex = 4;
            this.colShowInToolbar.Width = 54;
            //
            // repositoryItemCheckEdit5
            //
            this.repositoryItemCheckEdit5.AutoHeight = false;
            this.repositoryItemCheckEdit5.Name = "repositoryItemCheckEdit5";
            //
            // colIcon
            //
            this.colIcon.ColumnEdit = this.repositoryItemIcon;
            this.colIcon.FieldName = "Icon";
            this.colIcon.Name = "colIcon";
            this.colIcon.Visible = true;
            this.colIcon.VisibleIndex = 0;
            this.colIcon.Width = 22;
            //
            // repositoryItemIcon
            //
            this.repositoryItemIcon.CustomHeight = 16;
            this.repositoryItemIcon.Name = "repositoryItemIcon";
            this.repositoryItemIcon.ReadOnly = true;
            //
            // pnlToolbarButtons
            //
            this.pnlToolbarButtons.Controls.Add(this.btnRefreshToolbar);
            this.pnlToolbarButtons.Controls.Add(this.chkBeginToolbarGroup2);
            this.pnlToolbarButtons.Controls.Add(this.txtToolbarSortKey2);
            this.pnlToolbarButtons.Controls.Add(this.lblToolbarSortKey2);
            this.pnlToolbarButtons.Controls.Add(this.chkStaticItem2);
            this.pnlToolbarButtons.Controls.Add(this.btnToolbarDown);
            this.pnlToolbarButtons.Controls.Add(this.btnToolbarUp);
            this.pnlToolbarButtons.Controls.Add(this.chkEnabled2);
            this.pnlToolbarButtons.Controls.Add(this.chkVisible2);
            this.pnlToolbarButtons.Controls.Add(this.chkSystem2);
            this.pnlToolbarButtons.Controls.Add(this.chkShowInToolbar2);
            this.pnlToolbarButtons.Controls.Add(this.lblSystem2);
            this.pnlToolbarButtons.Controls.Add(this.lblStaticItem2);
            this.pnlToolbarButtons.Controls.Add(this.lblEnabled2);
            this.pnlToolbarButtons.Controls.Add(this.lblVisible2);
            this.pnlToolbarButtons.Controls.Add(this.lblShowInToolbar2);
            this.pnlToolbarButtons.Controls.Add(this.lblBeginToolbarGroup2);
            this.pnlToolbarButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlToolbarButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbarButtons.Name = "pnlToolbarButtons";
            this.pnlToolbarButtons.Size = new System.Drawing.Size(128, 459);
            this.pnlToolbarButtons.TabIndex = 0;
            //
            // btnRefreshToolbar
            //
            this.btnRefreshToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshToolbar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshToolbar.Location = new System.Drawing.Point(12, 427);
            this.btnRefreshToolbar.Name = "btnRefreshToolbar";
            this.btnRefreshToolbar.Size = new System.Drawing.Size(104, 24);
            this.btnRefreshToolbar.TabIndex = 10;
            this.btnRefreshToolbar.Text = "Anwenden";
            this.btnRefreshToolbar.UseVisualStyleBackColor = false;
            this.btnRefreshToolbar.Click += new System.EventHandler(this.ButtonRefresh_Click);
            //
            // chkBeginToolbarGroup2
            //
            this.chkBeginToolbarGroup2.DataMember = "BeginToolbarGroup";
            this.chkBeginToolbarGroup2.DataSource = this.qryToolbar;
            this.chkBeginToolbarGroup2.Location = new System.Drawing.Point(96, 170);
            this.chkBeginToolbarGroup2.Name = "chkBeginToolbarGroup2";
            this.chkBeginToolbarGroup2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkBeginToolbarGroup2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkBeginToolbarGroup2.Properties.Appearance.Options.UseBackColor = true;
            this.chkBeginToolbarGroup2.Properties.Appearance.Options.UseFont = true;
            this.chkBeginToolbarGroup2.Properties.Caption = "";
            this.chkBeginToolbarGroup2.Size = new System.Drawing.Size(20, 19);
            this.chkBeginToolbarGroup2.TabIndex = 5;
            //
            // txtToolbarSortKey2
            //
            this.txtToolbarSortKey2.DataMember = "ToolbarSortKey";
            this.txtToolbarSortKey2.DataSource = this.qryToolbar;
            this.txtToolbarSortKey2.Location = new System.Drawing.Point(16, 222);
            this.txtToolbarSortKey2.Name = "txtToolbarSortKey2";
            this.txtToolbarSortKey2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtToolbarSortKey2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtToolbarSortKey2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtToolbarSortKey2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtToolbarSortKey2.Properties.Appearance.Options.UseBackColor = true;
            this.txtToolbarSortKey2.Properties.Appearance.Options.UseBorderColor = true;
            this.txtToolbarSortKey2.Properties.Appearance.Options.UseFont = true;
            this.txtToolbarSortKey2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtToolbarSortKey2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.txtToolbarSortKey2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtToolbarSortKey2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtToolbarSortKey2.Properties.Precision = 0;
            this.txtToolbarSortKey2.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.txtToolbarSortKey2.Size = new System.Drawing.Size(96, 24);
            this.txtToolbarSortKey2.TabIndex = 7;
            //
            // lblToolbarSortKey2
            //
            this.lblToolbarSortKey2.Location = new System.Drawing.Point(16, 196);
            this.lblToolbarSortKey2.Name = "lblToolbarSortKey2";
            this.lblToolbarSortKey2.Size = new System.Drawing.Size(96, 24);
            this.lblToolbarSortKey2.TabIndex = 6;
            this.lblToolbarSortKey2.Text = "Sortierung";
            //
            // chkStaticItem2
            //
            this.chkStaticItem2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkStaticItem2.EditValue = false;
            this.chkStaticItem2.Location = new System.Drawing.Point(96, 294);
            this.chkStaticItem2.Name = "chkStaticItem2";
            this.chkStaticItem2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkStaticItem2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkStaticItem2.Properties.Appearance.Options.UseBackColor = true;
            this.chkStaticItem2.Properties.Appearance.Options.UseFont = true;
            this.chkStaticItem2.Properties.Caption = "";
            this.chkStaticItem2.Properties.ReadOnly = true;
            this.chkStaticItem2.Size = new System.Drawing.Size(20, 19);
            this.chkStaticItem2.TabIndex = 9;
            //
            // btnToolbarDown
            //
            this.btnToolbarDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolbarDown.IconID = 17;
            this.btnToolbarDown.Location = new System.Drawing.Point(48, 48);
            this.btnToolbarDown.Name = "btnToolbarDown";
            this.btnToolbarDown.Size = new System.Drawing.Size(32, 24);
            this.btnToolbarDown.TabIndex = 1;
            this.btnToolbarDown.UseVisualStyleBackColor = false;
            this.btnToolbarDown.Click += new System.EventHandler(this.btnToolbarUpDown_Click);
            //
            // btnToolbarUp
            //
            this.btnToolbarUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToolbarUp.IconID = 16;
            this.btnToolbarUp.Location = new System.Drawing.Point(48, 16);
            this.btnToolbarUp.Name = "btnToolbarUp";
            this.btnToolbarUp.Size = new System.Drawing.Size(32, 24);
            this.btnToolbarUp.TabIndex = 0;
            this.btnToolbarUp.UseVisualStyleBackColor = false;
            this.btnToolbarUp.Click += new System.EventHandler(this.btnToolbarUpDown_Click);
            //
            // chkEnabled2
            //
            this.chkEnabled2.DataMember = "Enabled";
            this.chkEnabled2.DataSource = this.qryToolbar;
            this.chkEnabled2.Location = new System.Drawing.Point(96, 86);
            this.chkEnabled2.Name = "chkEnabled2";
            this.chkEnabled2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkEnabled2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkEnabled2.Properties.Appearance.Options.UseBackColor = true;
            this.chkEnabled2.Properties.Appearance.Options.UseFont = true;
            this.chkEnabled2.Properties.Caption = "";
            this.chkEnabled2.Size = new System.Drawing.Size(20, 19);
            this.chkEnabled2.TabIndex = 2;
            //
            // chkVisible2
            //
            this.chkVisible2.DataMember = "Visible";
            this.chkVisible2.DataSource = this.qryToolbar;
            this.chkVisible2.Location = new System.Drawing.Point(96, 114);
            this.chkVisible2.Name = "chkVisible2";
            this.chkVisible2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkVisible2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkVisible2.Properties.Appearance.Options.UseBackColor = true;
            this.chkVisible2.Properties.Appearance.Options.UseFont = true;
            this.chkVisible2.Properties.Caption = "";
            this.chkVisible2.Size = new System.Drawing.Size(20, 19);
            this.chkVisible2.TabIndex = 3;
            //
            // chkSystem2
            //
            this.chkSystem2.DataMember = "System";
            this.chkSystem2.DataSource = this.qryToolbar;
            this.chkSystem2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkSystem2.Location = new System.Drawing.Point(96, 266);
            this.chkSystem2.Name = "chkSystem2";
            this.chkSystem2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSystem2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkSystem2.Properties.Appearance.Options.UseBackColor = true;
            this.chkSystem2.Properties.Appearance.Options.UseFont = true;
            this.chkSystem2.Properties.Caption = "";
            this.chkSystem2.Properties.ReadOnly = true;
            this.chkSystem2.Size = new System.Drawing.Size(20, 19);
            this.chkSystem2.TabIndex = 8;
            //
            // chkShowInToolbar2
            //
            this.chkShowInToolbar2.DataMember = "ShowInToolbar";
            this.chkShowInToolbar2.DataSource = this.qryToolbar;
            this.chkShowInToolbar2.Location = new System.Drawing.Point(96, 142);
            this.chkShowInToolbar2.Name = "chkShowInToolbar2";
            this.chkShowInToolbar2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkShowInToolbar2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkShowInToolbar2.Properties.Appearance.Options.UseBackColor = true;
            this.chkShowInToolbar2.Properties.Appearance.Options.UseFont = true;
            this.chkShowInToolbar2.Properties.Caption = "";
            this.chkShowInToolbar2.Size = new System.Drawing.Size(20, 19);
            this.chkShowInToolbar2.TabIndex = 4;
            //
            // lblSystem2
            //
            this.lblSystem2.Location = new System.Drawing.Point(16, 264);
            this.lblSystem2.Name = "lblSystem2";
            this.lblSystem2.Size = new System.Drawing.Size(72, 24);
            this.lblSystem2.TabIndex = 6;
            this.lblSystem2.Text = "System";
            //
            // lblStaticItem2
            //
            this.lblStaticItem2.Location = new System.Drawing.Point(16, 292);
            this.lblStaticItem2.Name = "lblStaticItem2";
            this.lblStaticItem2.Size = new System.Drawing.Size(72, 24);
            this.lblStaticItem2.TabIndex = 6;
            this.lblStaticItem2.Text = "Statisch";
            //
            // lblEnabled2
            //
            this.lblEnabled2.Location = new System.Drawing.Point(16, 84);
            this.lblEnabled2.Name = "lblEnabled2";
            this.lblEnabled2.Size = new System.Drawing.Size(80, 24);
            this.lblEnabled2.TabIndex = 6;
            this.lblEnabled2.Text = "Aktiviert";
            //
            // lblVisible2
            //
            this.lblVisible2.Location = new System.Drawing.Point(16, 112);
            this.lblVisible2.Name = "lblVisible2";
            this.lblVisible2.Size = new System.Drawing.Size(80, 24);
            this.lblVisible2.TabIndex = 6;
            this.lblVisible2.Text = "Sichtbar";
            //
            // lblShowInToolbar2
            //
            this.lblShowInToolbar2.Location = new System.Drawing.Point(16, 140);
            this.lblShowInToolbar2.Name = "lblShowInToolbar2";
            this.lblShowInToolbar2.Size = new System.Drawing.Size(80, 24);
            this.lblShowInToolbar2.TabIndex = 6;
            this.lblShowInToolbar2.Text = "Toolbar";
            //
            // lblBeginToolbarGroup2
            //
            this.lblBeginToolbarGroup2.Location = new System.Drawing.Point(16, 168);
            this.lblBeginToolbarGroup2.Name = "lblBeginToolbarGroup2";
            this.lblBeginToolbarGroup2.Size = new System.Drawing.Size(80, 24);
            this.lblBeginToolbarGroup2.TabIndex = 6;
            this.lblBeginToolbarGroup2.Text = "Neue Gruppe";
            //
            // tpgXRight
            //
            this.tpgXRight.Controls.Add(this.ctlXRight);
            this.tpgXRight.Location = new System.Drawing.Point(6, 32);
            this.tpgXRight.Name = "tpgXRight";
            this.tpgXRight.Size = new System.Drawing.Size(988, 459);
            this.tpgXRight.TabIndex = 3;
            this.tpgXRight.Title = "Zugriffsrechte";
            //
            // ctlXRight
            //
            this.ctlXRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlXRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlXRight.Location = new System.Drawing.Point(0, 0);
            this.ctlXRight.Name = "ctlXRight";
            this.ctlXRight.Size = new System.Drawing.Size(988, 459);
            this.ctlXRight.TabIndex = 0;
            //
            // CtlMenuEditor
            //
            this.ActiveSQLQuery = this.qryXMenuItem;
            this.Controls.Add(this.tabMenuToolbar);
            this.Name = "CtlMenuEditor";
            this.Size = new System.Drawing.Size(1000, 497);
            this.Load += new System.EventHandler(this.CtlMenuEditor_Load);
            this.Leave += new System.EventHandler(this.CtlMenuEditor_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.qryXMenuItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblImageIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNewGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClassName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treMenuItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTreeItems)).EndInit();
            this.panMenuDetail.ResumeLayout(false);
            this.gbNavBarFlags.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtControlID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNavBarItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNavBarItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNavBarGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNavBarGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblControlID)).EndInit();
            this.gbFlags.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkQuery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStaticItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStaticItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSystem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHideLockedItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHideLockedItems.Properties)).EndInit();
            this.gbToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtToolbarSortKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToolbarSortKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBeginToolbarGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowInToolbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeginToolbarGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblShowInToolbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCaptionML.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemShortcutKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboImageIndex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBeginMenuGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMenuOnlyBIAGAdmin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVisible.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnabled.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblImageIndexDisabled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemShortcut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEnabled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMenuOnlyBIAGAdmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVisible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboImageIndexDisabled.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClassName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClassName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkItemShortcutCtrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkItemShortcutShift.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkItemShortcutAlt.Properties)).EndInit();
            this.pnlTree.ResumeLayout(false);
            this.panBottomOfTree.ResumeLayout(false);
            this.tabMenuToolbar.ResumeLayout(false);
            this.tpgTranslateMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treTranslateMenuItems)).EndInit();
            this.panTranslateDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtTranslationCaptionML.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTranslationCaptionML)).EndInit();
            this.tpgMenu.ResumeLayout(false);
            this.tpgToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdToolbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryToolbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvToolbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemIcon)).EndInit();
            this.pnlToolbarButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkBeginToolbarGroup2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToolbarSortKey2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToolbarSortKey2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStaticItem2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnabled2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVisible2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSystem2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowInToolbar2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSystem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStaticItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEnabled2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVisible2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblShowInToolbar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeginToolbarGroup2)).EndInit();
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
            //default dispose
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

        #region Properties

        private int LastSelectedPosition
        {
            get { return this._lastSelectedPosition; }
            set { this._lastSelectedPosition = value; }
        }

        private KissMainForm MainForm
        {
            get { return this._mainForm; }
            set { this._mainForm = value; }
        }

        private bool MenuItemChanged
        {
            get { return this._menuItemChanged; }
            set { this._menuItemChanged = value; }
        }

        private int ParentMenuItemID
        {
            get { return this._parentMenuItemID; }
            set { this._parentMenuItemID = value; }
        }

        private int SortKey
        {
            get { return this._sortKey; }
            set { this._sortKey = value; }
        }

        #endregion

        #region EventHandlers

        private void btnCollapseAll_Click(object sender, EventArgs e)
        {
            treTranslateMenuItems.CollapseAll();
            ExpandFirstNode();

            treTranslateMenuItems.Focus();
        }

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            treTranslateMenuItems.ExpandAll();
            treTranslateMenuItems.Focus();
        }

        /// <summary>
        /// Move current menu item one level up or down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeftRight_Click(object sender, System.EventArgs e)
        {
            // validate first
            if (qryXMenuItem.Count <= 1)
            {
                return;
            }

            if (!qryXMenuItem.Post())
            {
                return;
            }

            // init var
            int newParentMenuItemID = -1;

            // do action depending on sender
            if (sender == this.btnLeft)
            {
                // left-button
                object res = DBUtil.ExecuteScalarSQL(@"
                    SELECT ParentMenuItemID
                    FROM dbo.XMenuItem MNU
                    WHERE MNU.MenuItemID = {0}", this.qryXMenuItem.Row["ParentMenuItemID"]);

                // check if parent is root, we cannot move higher than one level below root
                if (DBUtil.IsEmpty(res))
                {
                    return;
                }

                newParentMenuItemID = Convert.ToInt32(res);
            }
            else if (sender == this.btnRight)
            {
                // right button
                int previousMenuItemID = this.GetMenuItemIDOfPreviousNode((int)this.qryXMenuItem.Row["MenuItemID"], this.qryXMenuItem.Row["ParentMenuItemID"]);

                // check if item can be child of previous node (above current node)
                if (!(previousMenuItemID > 0 &&
                    this.qryXMenuItem.Row["ParentMenuItemID"] != System.DBNull.Value &&
                    previousMenuItemID != (int)this.qryXMenuItem.Row["ParentMenuItemID"]))
                {
                    return;
                }

                newParentMenuItemID = previousMenuItemID;
            }
            else
            {
                return;
            }

            // validate
            if (newParentMenuItemID < 1)
            {
                return;
            }

            // request max SortKey for new parent
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT NextSortKey = (ISNULL(MAX(SortKey), -1) + 1)
                FROM dbo.XMenuItem
                WHERE ParentMenuItemID={0}", newParentMenuItemID);

            // update current dataset
            DBUtil.ExecSQL(@"
                UPDATE dbo.XMenuItem
                SET ParentMenuItemID = {0},
                    SortKey = {1}
                WHERE MenuItemID={2}", newParentMenuItemID, qry.Row["NextSortKey"], this.qryXMenuItem.Row["MenuItemID"]);

            this.FillDataSource(this.qryXMenuItem);
            this.RefreshTree();
        }

        private void btnToolbarUpDown_Click(object sender, System.EventArgs e)
        {
            if (sender != this.btnToolbarUp && sender != this.btnToolbarDown)
            {
                return;
            }

            if (this.qryToolbar.Count <= 1 || !this.qryToolbar.Post())
            {
                return;
            }

            btnToolbarUp.Enabled = false;
            btnToolbarDown.Enabled = false;

            SqlQuery qry;

            if (sender == btnToolbarUp)
            {
                // Vorgänger bestimmen
                qry = DBUtil.OpenSQL(@"
                    SELECT TOP 1 *
                    FROM dbo.XMenuItem
                    WHERE ToolbarSortKey < {0} AND
                          ShowInToolbar = 1
                    ORDER BY ToolbarSortKey DESC", this.qryToolbar["ToolbarSortKey"]);
            }
            else
            {
                // Nachfolger bestimmen
                qry = DBUtil.OpenSQL(@"
                    SELECT TOP 1 *
                    FROM dbo.XMenuItem
                    WHERE ToolbarSortKey > {0} AND
                          ShowInToolbar = 1
                    ORDER BY ToolbarSortKey ASC", this.qryToolbar["ToolbarSortKey"]);
            }

            if (qry.Count == 0)
            {
                btnToolbarUp.Enabled = true;
                btnToolbarDown.Enabled = true;
                return;
            }

            // handle in transaction
            Session.BeginTransaction();

            try
            {
                // swap positions
                DBUtil.ExecSQLThrowingException(@"
                    UPDATE dbo.XMenuItem
                    SET ToolbarSortKey = {0}
                    WHERE MenuItemID = {1}", qry["ToolbarSortKey"], qryToolbar["MenuItemID"]);

                DBUtil.ExecSQLThrowingException(@"
                    UPDATE dbo.XMenuItem
                    SET ToolbarSortKey = {0}
                    WHERE MenuItemID = {1}", qryToolbar["ToolbarSortKey"], qry["MenuItemID"]);

                // save changes
                Session.Commit();
            }
            catch (Exception ex)
            {
                // undo
                Session.Rollback();

                // show message
                KissMsg.ShowError("CtlMenuEditor", "ErrorToolbarUpDownSave", "Es ist ein Fehler beim Speichern der Änderungen aufgetreten.", ex);
            }

            this.qryToolbar.Refresh();

            btnToolbarUp.Enabled = true;
            btnToolbarDown.Enabled = true;
        }

        /// <summary>
        /// Move current menuitem one position up or down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpDown_Click(object sender, System.EventArgs e)
        {
            if (sender != this.btnUp && sender != this.btnDown)
            {
                return;
            }

            this.treMenuItems.SaveState();

            btnUp.Enabled = false;
            btnDown.Enabled = false;

            if (qryXMenuItem.Count <= 1 || !qryXMenuItem.Post())
            {
                return;
            }

            SqlQuery qry;

            if (sender == btnUp)
            {
                // Vorgänger bestimmen
                qry = DBUtil.OpenSQL(@"
                    SELECT TOP 1 *
                    FROM dbo.XMenuItem
                    WHERE ISNULL(ParentMenuItemID, 0) = ISNULL({0}, 0) AND
                          SortKey < {1}
                    ORDER BY SortKey DESC", qryXMenuItem["ParentMenuItemID"], qryXMenuItem["SortKey"]);
            }
            else
            {
                // Nachfolger bestimmen
                qry = DBUtil.OpenSQL(@"
                    SELECT TOP 1 *
                    FROM dbo.XMenuItem
                    WHERE ISNULL(ParentMenuItemID, 0) = ISNULL({0}, 0) AND
                          SortKey > {1}
                    ORDER BY SortKey ASC", qryXMenuItem["ParentMenuItemID"], qryXMenuItem["SortKey"]);
            }

            if (qry.Count == 0)
            {
                this.RefreshEnabledStates();
                return;
            }

            // handle in transaction
            Session.BeginTransaction();

            try
            {
                // swap positions
                DBUtil.ExecSQLThrowingException(@"
                    UPDATE dbo.XMenuItem
                    SET SortKey = {0}
                    WHERE MenuItemID = {1}", qry["SortKey"], qryXMenuItem["MenuItemID"]);

                DBUtil.ExecSQLThrowingException(@"
                    UPDATE XMenuItem
                    SET SortKey = {0}
                    WHERE MenuItemID = {1}", qryXMenuItem["SortKey"], qry["MenuItemID"]);

                // save changes
                Session.Commit();
            }
            catch (Exception ex)
            {
                // undo
                Session.Rollback();

                // show message
                KissMsg.ShowError("CtlMenuEditor", "ErrorButtonUpDownSave", "Es ist ein Fehler beim Speichern der Änderungen aufgetreten.", ex);
            }

            this.FillDataSource(this.qryXMenuItem);
            this.RefreshTree();
        }

        /// <summary>
        /// Refresh menu items on frmMain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRefresh_Click(object sender, System.EventArgs e)
        {
            if (sender == this.btnRefresh || sender == this.btnTranslateRefresh)
            {
                if (this.qryXMenuItem.Count <= 1 || !this.qryXMenuItem.Post())
                {
                    return;
                }
            }
            else if (sender == this.btnRefreshToolbar)
            {
                if (this.qryToolbar.Count <= 1 || !this.qryToolbar.Post())
                {
                    return;
                }
            }

            CtlMenuEditor_Leave(sender, null);
        }

        private void cboClassName_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            // check if query is changing row
            if (IsChangingPosition())
            {
                // is currently changing position in query, do nothing more
                return;
            }

            // check if any child nodes
            if (this.treMenuItems.FocusedNode.HasChildren)
            {
                // warn on changes to and from NavBarForm / FrmDataExplorer
                if (this.MainForm.IsClassTypeOfNavBarForm(e.OldValue as string) && !this.MainForm.IsClassTypeOfNavBarForm(e.NewValue as string))
                {
                    // confirm change from KissNavBarForm to other type of class
                    e.Cancel = !KissMsg.ShowQuestion("CtlMenuEditor", "ChangedFromKissNavBarForm", "Die definierte Fensternavigation der Klasse '{0}' wird durch diese Veränderung automatisch zu Untermenus.{1}{1}Wollen Sie den Klassennamen trotzdem verändern?", 600, 0, true, e.OldValue, Environment.NewLine);
                }
                else if (!this.MainForm.IsClassTypeOfNavBarForm(e.OldValue as string) && this.MainForm.IsClassTypeOfNavBarForm(e.NewValue as string))
                {
                    // confirm change from other type of class to KissNavBarForm
                    e.Cancel = !KissMsg.ShowQuestion("CtlMenuEditor", "ChangedToKissNavBarForm", "Die definierten Untermenus werden durch diese Veränderung automatisch zur Fensternavigation der Klasse '{0}'.{1}{1}Wollen Sie den Klassennamen trotzdem verändern?", 600, 0, true, e.NewValue, Environment.NewLine);
                }
                else if (this.MainForm.IsClassTypeOfFrmDataExplorer(e.OldValue as string) && !this.MainForm.IsClassTypeOfFrmDataExplorer(e.NewValue as string))
                {
                    // confirm change from FrmDataExplorer to other type of class
                    e.Cancel = !KissMsg.ShowQuestion("CtlMenuEditor", "ChangedFromFrmDataExplorer", "Die definierten Abfragen des Daten-Explorers werden durch diese Veränderung automatisch zu Untermenus.{0}{0}Wollen Sie den Klassennamen trotzdem verändern?", 600, 0, true, Environment.NewLine);
                }
                else if (!this.MainForm.IsClassTypeOfFrmDataExplorer(e.OldValue as string) && this.MainForm.IsClassTypeOfFrmDataExplorer(e.NewValue as string))
                {
                    // confirm change from other type of class to FrmDataExplorer
                    e.Cancel = !KissMsg.ShowQuestion("CtlMenuEditor", "ChangedToFrmDataExplorer", "Die definierten Untermenus werden durch diese Veränderung automatisch zu Abfragen im Daten-Explorer.{0}{0}Wollen Sie den Klassennamen trotzdem verändern?", 600, 0, true, Environment.NewLine);
                }
                else if (this.MainForm.IsClassTypeOfIContainerForm(e.OldValue as string) && !this.MainForm.IsClassTypeOfIContainerForm(e.NewValue as string))
                {
                    // confirm change from IContainerForm to other type of class
                    e.Cancel = !KissMsg.ShowQuestion("CtlMenuEditor", "ChangedFromIContainerForm", "Die definierte Fensternavigation der Klasse '{0}' wird durch diese Veränderung automatisch zu Untermenus.{1}{1}Wollen Sie den Klassennamen trotzdem verändern?", 600, 0, true, e.OldValue, Environment.NewLine);
                }
                else if (!this.MainForm.IsClassTypeOfIContainerForm(e.OldValue as string) && this.MainForm.IsClassTypeOfIContainerForm(e.NewValue as string))
                {
                    // confirm change from other type of class to IContainerForm
                    e.Cancel = !KissMsg.ShowQuestion("CtlMenuEditor", "ChangedToIContainerForm", "Die definierten Untermenus werden durch diese Veränderung automatisch zur Fensternavigation der Klasse '{0}'.{1}{1}Wollen Sie den Klassennamen trotzdem verändern?", 600, 0, true, e.NewValue, Environment.NewLine);
                }
            }

            // check if current node is query and not yet canceled
            if (!e.Cancel && this.chkQuery.Checked && !IsClassTypeOfQueryControl(e.NewValue as string))
            {
                // confirm change for DataExplorer to non-query-class
                e.Cancel = !KissMsg.ShowQuestion("CtlMenuEditor", "QueryClassIsNonQueryClass", "Die gewählte Klasse ist keine Abfrage und wird im Daten-Explorer nicht dargestellt.{0}{0}Wollen Sie den Klassennamen trotzdem verändern?{0}{0}Hinweis: Eine Abfrage muss zuerst kompiliert werden!", 600, 0, true, Environment.NewLine);
            }
        }

        private void chkHideLockedItems_CheckedChanged(object sender, System.EventArgs e)
        {
            this.chkHideLockedItems.DoValidate();

            // do save data and refresh content of query
            if (this.qryXMenuItem.RowModified && this.qryXMenuItem.Post())
            {
                this.qryXMenuItem.Refresh();
            }
        }

        /// <summary>
        /// Leaving focus of this control will cause the menu to refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtlMenuEditor_Leave(object sender, System.EventArgs e)
        {
            // refresh menu
            if (Session.Active)
            {
                if (this.MenuItemChanged ||
                    sender == this.btnRefresh ||
                    sender == this.btnTranslateRefresh ||
                    sender == this.btnRefreshToolbar)
                {
                    ((KiSS4.Gui.KissMainForm)Session.MainForm).LoadMenuItems();
                    this.MenuItemChanged = false;
                }
            }
        }

        private void CtlMenuEditor_Load(object sender, System.EventArgs e)
        {
            ExpandFirstNode();
        }

        private void edtControlID_Leave(object sender, System.EventArgs e)
        {
            this.edtControlID.DoValidate();

            // do save data and refresh enabled state
            if (this.qryXMenuItem.RowModified && this.qryXMenuItem.Post())
            {
                this.RefreshEnabledStates();
            }
        }

        private void MenuTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null && !_isRefreshingTree)
            {
                if (this.qryXMenuItem.Post())
                {
                    // apply new selected node in query
                    this.qryXMenuItem.Find(string.Format("MenuItemID = {0}", e.Node.GetValue("MenuItemID")));
                }
                else
                {
                    if (e.OldNode != null)
                    {
                        // post failed, go back to old selected node
                        _isRefreshingTree = true;
                        this.treMenuItems.FocusedNode = e.OldNode;
                        _isRefreshingTree = false;
                    }
                }
            }
        }

        private void qryToolbar_BeforePost(object sender, System.EventArgs e)
        {
            // check if valid toolbarsortkey
            this.ValidateToolbarSortKey(this.txtToolbarSortKey2, this.qryToolbar);
        }

        private void qryToolbar_PositionChanged(object sender, System.EventArgs e)
        {
            this.RefreshEnabledStates();
        }

        private void qryToolbar_PostCompleted(object sender, System.EventArgs e)
        {
            this.MenuItemChanged = true;
            this.qryToolbar.Refresh();
        }

        private void qryTreeItems_AfterFill(object sender, System.EventArgs e)
        {
            if (!this.qryTreeItems.DataTable.Columns.Contains("ImageIndexCompact"))
            {
                this.qryTreeItems.DataTable.Columns.Add("ImageIndexCompact", typeof(int));
            }

            foreach (DataRow row in qryTreeItems.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["ImageIndex"]))
                {
                    row["ImageIndexCompact"] = KissImageList.GetImageIndex(Convert.ToInt32(row["ImageIndex"]));
                }
            }

            // set datasource depending on current accessmode
            if (_accessMode == AccessMode.BIAGAdmin)
            {
                this.treMenuItems.DataSource = sender;
            }
            else
            {
                this.treTranslateMenuItems.DataSource = sender;
            }
        }

        private void qryXMenuItem_AfterInsert(object sender, System.EventArgs e)
        {
            // apply values to new row
            this.qryXMenuItem.Row["ParentMenuItemID"] = this.ParentMenuItemID;
            this.qryXMenuItem.Row["SortKey"] = this.SortKey;
            this.qryXMenuItem.Row["Text"] = KissMsg.GetMLMessage("CtlMenuEditor", "NewMenuItem", "Neuer Menueintrag");
            this.qryXMenuItem.Row["Caption"] = this.qryXMenuItem.Row["Text"];
            this.qryXMenuItem.RowModified = true;

            // reset properties
            this.ParentMenuItemID = -1;
            this.SortKey = -1;

            // handle controls
            this.RefreshEnabledStates();
        }

        private void qryXMenuItem_BeforeInsert(object sender, System.EventArgs e)
        {
            // get parent id from tree and calc next sortkey
            if (this.treMenuItems.FocusedNode != null)
            {
                this.treMenuItems.SaveState();

                this.ParentMenuItemID = Convert.ToInt32(this.treMenuItems.FocusedNode.GetValue("MenuItemID"));
                this.SortKey = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT ISNULL(MAX(SortKey) + 1, 0)
                    FROM dbo.XMenuItem
                    WHERE ParentMenuItemID = {0}", this.ParentMenuItemID));
            }

            if (this.ParentMenuItemID < 0 || this.SortKey < 0)
            {
                throw new KissErrorException(KissMsg.GetMLMessage("CtlMenuEditor", "InvalidParentIDOrSortKeyInsert", "Ungültiger Wert für ParentMenuItemID='{0}' oder SortKey='{1}', Datensatz kann nicht erstellt werden.", KissMsgCode.MsgError, this.ParentMenuItemID, this.SortKey));
            }
        }

        private void qryXMenuItem_BeforePost(object sender, System.EventArgs e)
        {
            this.ValidateInputControls();

            // validate input values for must-fields
            if (_accessMode == AccessMode.BIAGAdmin)
            {
                DBUtil.CheckNotNullField(edtCaptionML, lblCaption.Text);
            }
            else
            {
                DBUtil.CheckNotNullField(edtTranslationCaptionML, lblTranslationCaptionML.Text);
            }

            // check if user selected a key on checked ctrl, shift or alt (cannot only be ctrl, shift or alt)
            if (this.chkItemShortcutCtrl.Checked || this.chkItemShortcutShift.Checked || this.chkItemShortcutAlt.Checked)
            {
                DBUtil.CheckNotNullField(cboItemShortcutKey, lblItemShortcut.Text);
            }

            // check if valid toolbarsortkey
            this.ValidateToolbarSortKey(this.txtToolbarSortKey, this.qryXMenuItem);
        }

        private void qryXMenuItem_PositionChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.qryXMenuItem.EnableBoundFields();
                this.RefreshEnabledStates();
            }
            catch (Exception ex)
            {
                // logging
                LOG.Warn("Exception occured in PositionChanged.", ex);
            }
            finally
            {
                // store new last selected position in order to check if currently position changing
                this.LastSelectedPosition = this.qryXMenuItem.Position;
            }
        }

        private void qryXMenuItem_PostCompleted(object sender, System.EventArgs e)
        {
            this.MenuItemChanged = true;
            this.RefreshEnabledStates();
            this.RefreshTree();
        }

        /// <summary>
        /// Resize column of tree when moving splitter
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments of the splitter</param>
        private void splitter_SplitterMoved(object sender, System.Windows.Forms.SplitterEventArgs e)
        {
            this.colMenuItems.Width = this.treMenuItems.Size.Width - 24;
        }

        private void tabMenuToolbar_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // handle selection of tpg changed
            if (this.tabMenuToolbar.IsTabSelected(this.tpgTranslateMenu))
            {
                // Translation
                this.FillDataSource(this.qryXMenuItem);
                this.RefreshTree();
                this.ActiveSQLQuery = this.qryXMenuItem;
            }
            else if (this.tabMenuToolbar.IsTabSelected(this.tpgMenu) && this.ActiveSQLQuery != this.qryXMenuItem)
            {
                // Menu
                this.FillDataSource(this.qryXMenuItem);
                this.RefreshTree();
                this.ActiveSQLQuery = this.qryXMenuItem;
            }
            else if (this.tabMenuToolbar.IsTabSelected(this.tpgToolbar) && this.ActiveSQLQuery != this.qryToolbar)
            {
                // Toolbar
                this.FillToolbarDataSource();
                this.ActiveSQLQuery = this.qryToolbar;
            }
            else if (this.tabMenuToolbar.IsTabSelected(this.tpgXRight))
            {
                // Rights
                this.ctlXRight.ClassName = Convert.ToString(this.ActiveSQLQuery["ClassName"]);
            }
        }

        private void tabMenuToolbar_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // handle selection of tpg changed
            if (this.tabMenuToolbar.IsTabSelected(this.tpgTranslateMenu))
            {
                e.Cancel = !this.qryXMenuItem.Post();
            }
            else if (this.tabMenuToolbar.IsTabSelected(this.tpgMenu))
            {
                e.Cancel = !this.qryXMenuItem.Post();
            }
            else if (this.tabMenuToolbar.IsTabSelected(this.tpgToolbar))
            {
                e.Cancel = !this.qryToolbar.Post();
            }
            else if (this.tabMenuToolbar.IsTabSelected(this.tpgXRight))
            {
                e.Cancel = !((IKissDataNavigator)this.ctlXRight).SaveData();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool OnAddData()
        {
            // check selected tab
            if (!this.tabMenuToolbar.IsTabSelected(this.tpgMenu))
            {
                // not tpgMenu
                return base.OnAddData();
            }

            // TPGMENU:
            // avoid crash in case of too fast user
            if (this.treMenuItems.DataSource == null)
            {
                throw new KissCancelException();
            }

            // create a new row and imediately save it to database because of problems with tree
            bool result = base.OnAddData() && this.qryXMenuItem.Post(true);

            // refresh controls and select last inserted row in tree
            if (result)
            {
                this.qryXMenuItem_PositionChanged(null, null);
                this.RefreshTree();
                this.treMenuItems.FocusedNode = this.treMenuItems.FindNodeByKeyID(Convert.ToInt32(DBUtil.ExecuteScalarSQL("SELECT MAX(MenuItemID) FROM dbo.XMenuItem")));
            }

            this.RefreshEnabledStates();

            return result;
        }

        public override bool OnDeleteData()
        {
            // check selected tab
            if (!this.tabMenuToolbar.IsTabSelected(this.tpgMenu))
            {
                // not tpgMenu
                return base.OnDeleteData();
            }

            // TPGMENU:
            if (!this.qryXMenuItem.CanDelete)
            {
                KissMsg.ShowError("CtlMenuEditor", "CannotDeleteSystemOrRootMenu", "System- und Hauptmenupunkte können nicht gelöscht werden.");
                return false;
            }

            bool result = false;

            if (this.HasChildren(Convert.ToInt32(qryXMenuItem["MenuItemID"])))
            {
                if (KissMsg.ShowQuestion("CtlMenuEditor", "DeleteSubTreeItems", "Soll der Menupunkt samt Untermenupunkten gelöscht werden?"))
                {
                    // do the following code in a transaction
                    Session.BeginTransaction();

                    try
                    {
                        // delete menu including all submenus
                        DeleteMenuItem(Convert.ToInt32(qryXMenuItem["MenuItemID"]));

                        // set result
                        result = true;

                        // save changes
                        Session.Commit();
                    }
                    catch (Exception ex)
                    {
                        // undo changes
                        Session.Rollback();

                        // set result
                        result = false;

                        // show message
                        KissMsg.ShowError("CtlMenuEditor", "ErrorDeletingMenuItems", "Es ist ein Fehler beim Löschen des Menueintrages aufgetreten.", ex);
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                result = base.OnDeleteData();
            }

            this.MenuItemChanged = true;
            this.treMenuItems.SaveState();
            this.RefreshTree();

            if (this.treMenuItems.Nodes.Count > 0)
            {
                this.treMenuItems.FocusedNode = this.treMenuItems.Nodes[0];
            }

            return result;
        }

        public override void OnMoveFirst()
        {
            if (!this.tabMenuToolbar.IsTabSelected(this.tpgMenu))
            {
                base.OnMoveFirst();
            }
        }

        public override void OnMoveLast()
        {
            if (!this.tabMenuToolbar.IsTabSelected(this.tpgMenu))
            {
                base.OnMoveLast();
            }
        }

        public override void OnMoveNext()
        {
            if (!this.tabMenuToolbar.IsTabSelected(this.tpgMenu))
            {
                base.OnMoveNext();
            }
        }

        public override void OnMovePrevious()
        {
            if (!this.tabMenuToolbar.IsTabSelected(this.tpgMenu))
            {
                base.OnMovePrevious();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Delete menuitems recursively
        /// </summary>
        /// <param name="menuItemID">ID of menuitem to delete (root)</param>
        private void DeleteMenuItem(int menuItemID)
        {
            // check if this menu item has any children
            int countChildren = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(1)
                FROM dbo.XMenuItem
                WHERE ParentMenuItemID = {0}", menuItemID));

            if (countChildren > 0)
            {
                // has children, get all children
                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT MenuItemID
                    FROM dbo.XMenuItem
                    WHERE ParentMenuItemID = {0}", menuItemID);

                // loop through rows and do recursion
                foreach (DataRow row in qry.DataTable.Rows)
                {
                    DeleteMenuItem(Convert.ToInt32(row["MenuItemID"]));
                }
            }

            // delete current menuitem
            DBUtil.ExecSQLThrowingException(@"
                DELETE FROM dbo.XMenuItem
                WHERE MenuItemID = {0}", menuItemID);
        }

        /// <summary>
        /// Expand first node depending on given rights and data
        /// </summary>
        private void ExpandFirstNode()
        {
            // depending on current access mode
            if (_accessMode == AccessMode.Admin)
            {
                // check if we have a first node to expand
                if (this.treTranslateMenuItems.Nodes.Count != 0)
                {
                    this.treTranslateMenuItems.Nodes[0].Expanded = true; // RootNode
                }
            }
            else if (_accessMode == AccessMode.BIAGAdmin)
            {
                // check if we have a first node to expand
                if (this.treMenuItems.Nodes.Count != 0)
                {
                    this.treMenuItems.Nodes[0].Expanded = true; // RootNode
                }
            }
        }

        /// <summary>
        /// Fill datasource with values from database
        /// </summary>
        private void FillDataSource(SqlQuery qry)
        {
            // validate
            if (qry == null)
            {
                throw new ArgumentNullException("qry", "Cannot fill query without valid instance.");
            }

            // fill query
            qry.Fill(@"
                SELECT MNU.*,
                       Text = ISNULL(TXT.Text, MNU.Caption),
                       HideLockedItemsRoot = (SELECT HideLockedItems
                                              FROM dbo.XMenuItem
                                              WHERE MenuItemID = 1)
                FROM dbo.XMenuItem MNU
                  LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = MNU.MenuTID AND
                                                                        LanguageCode = {0}
                ORDER BY ParentMenuItemID, SortKey, MenuItemID", Session.User.LanguageCode);
        }

        /// <summary>
        /// Fill datasource for toolbar with values from database
        /// </summary>
        private void FillToolbarDataSource()
        {
            qryToolbar.Fill(@"
                SELECT MNU.*,
                       Text = ISNULL(TXT.Text, MNU.Caption),
                       Icon
                FROM dbo.XMenuItem MNU
                  LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = MNU.MenuTID AND
                                                                        LanguageCode = {0}
                  LEFT JOIN XIcon         ICO WITH (READUNCOMMITTED) ON ICO.XIconID = MNU.ImageIndex
                ORDER BY ShowInToolbar DESC, ToolbarSortKey, ParentMenuItemID, SortKey, MenuItemID", Session.User.LanguageCode);
        }

        /// <summary>
        /// Get classname of given menuItemID
        /// </summary>
        /// <param name="menuItemID">The id of the menuitem to get classname from</param>
        /// <returns>The classname of the given menuitem</returns>
        private string GetClassNameOfMenuItem(int menuItemID)
        {
            return Convert.ToString(DBUtil.ExecuteScalarSQL(@"
                SELECT ISNULL(MNU.ClassName, '')
                FROM dbo.XMenuItem MNU
                WHERE MNU.MenuItemID = {0}", menuItemID));
        }

        /// <summary>
        /// Get id of previous node (the one above current node)
        /// </summary>
        /// <param name="menuItemID">MenuItemID of current node</param>
        /// <param name="parentItemID">ParentMenuItemID of current node</param>
        /// <returns>MenuItemID of previous node if we have any; ParentMenuItemID if we are the first node of parent; -1 if node has no previous node</returns>
        private int GetMenuItemIDOfPreviousNode(int menuItemID, object parentItemID)
        {
            if (menuItemID < 1 || DBUtil.IsEmpty(parentItemID))
            {
                // invalid or no previous node
                return -1;
            }

            // init vars
            SqlQuery qry = new SqlQuery();
            this.FillDataSource(qry);

            // validate
            if (!qry.Find(string.Format("MenuItemID = {0}", menuItemID)))
            {
                // node not found
                return -1;
            }

            // goto previous node
            qry.Previous();

            // init int-vars
            int rowMenuItemID = Convert.ToInt32(qry.Row["MenuItemID"]);
            int parentItemIDInt32 = Convert.ToInt32(parentItemID);

            // validate
            if (rowMenuItemID == menuItemID || Convert.ToBoolean(qry.Row["System"]))
            {
                // current node is the first --> root or is system menu item (cannot have children due to its functionality)
                return -1;
            }

            if (qry.Row["ParentMenuItemID"] == System.DBNull.Value ||
                Convert.ToInt32(qry.Row["ParentMenuItemID"]) != parentItemIDInt32 ||
                rowMenuItemID == parentItemIDInt32)
            {
                // current node is the first of its parent node
                return parentItemIDInt32;
            }

            // parent of current node is on same level
            return rowMenuItemID;
        }

        /// <summary>
        /// Check if menu item has children
        /// </summary>
        /// <param name="menuItemID">MenuItemID in XMenuItem</param>
        /// <returns>True if item has children, false if no sub items</returns>
        private new bool HasChildren(int menuItemID)
        {
            return !DBUtil.IsEmpty(DBUtil.ExecuteScalarSQL(@"
                SELECT MenuItemID
                FROM dbo.XMenuItem MNU
                WHERE MNU.ParentMenuItemID = {0}", menuItemID));
        }

        /// <summary>
        /// Init control and handle rights
        /// </summary>
        private void InitControlWithRights()
        {
            // handle tabpages
            ShowHideTabPagesDependingOnRights();

            // setup datasources depending on access mode
            if (_accessMode == AccessMode.BIAGAdmin)
            {
                edtTranslationCaptionML.DataSource = null;
            }
            else
            {
                edtCaptionML.DataSource = null;
            }

            // set no datasource due to init (will be done in afterfill)
            this.treMenuItems.DataSource = null;
            this.treTranslateMenuItems.DataSource = null;

            // init icons in tree and dropdowns
            this.treMenuItems.SelectImageList = KissImageList.SmallImageList;
            this.treMenuItems.ImageIndexFieldName = "ImageIndexCompact";
            this.treTranslateMenuItems.SelectImageList = KissImageList.SmallImageList;
            this.treTranslateMenuItems.ImageIndexFieldName = "ImageIndexCompact";

            this.cboImageIndex.Properties.SmallImages = KissImageList.SmallImageList;
            this.cboImageIndexDisabled.Properties.SmallImages = this.cboImageIndex.Properties.SmallImages;

            // fill cboImageIndex and cboImageIndexDisabled with entries
            ImageComboBoxItem item = new ImageComboBoxItem();
            item.ImageIndex = 0;
            item.Description = "";
            item.Value = -1;
            this.cboImageIndex.Properties.Items.Add(item);
            this.cboImageIndexDisabled.Properties.Items.Add(item);

            if (this.cboImageIndex.Properties.SmallImages != null)
            {
                KiSS4.Gui.KissImageList.FillIconsIntoComboBox(this.cboImageIndex, false);
                KiSS4.Gui.KissImageList.FillIconsIntoComboBox(this.cboImageIndexDisabled, false);
            }

            // fill enum of keys and shortcuts to cboItemShortcut
            item = new DevExpress.XtraEditors.Controls.ImageComboBoxItem();
            item.Description = "";
            item.Value = System.DBNull.Value;
            this.cboItemShortcutKey.Properties.Items.Add(item);

            foreach (string key in System.Enum.GetNames(typeof(System.Windows.Forms.Keys)))
            {
                item = new DevExpress.XtraEditors.Controls.ImageComboBoxItem();
                item.Description = key;
                item.Value = key;
                this.cboItemShortcutKey.Properties.Items.Add(item);
            }

            this.cboItemShortcutKey.Properties.Sorted = true;

            // get classnames from table XClass (cannot use all class-types for all functionality, but show all to user)
            SqlQuery qryXClass = DBUtil.OpenSQL(@"
                SELECT ClassName = NULL
                UNION ALL

                SELECT ClassName
                FROM dbo.XClass WITH (READUNCOMMITTED)
                ORDER BY ClassName");

            this.cboClassName.Properties.DataSource = qryXClass;
            this.cboClassName.Properties.DisplayMember = "ClassName";
            this.cboClassName.Properties.ValueMember = "ClassName";

            // fill datasources
            this.FillDataSource(this.qryXMenuItem);
            this.FillDataSource(this.qryTreeItems);

            // setup other controls
            this.repositoryItemIcon.NullText = " ";     // do not display "No Image"

            // select first tpg
            if (_accessMode == AccessMode.BIAGAdmin)
            {
                // select menu tpg
                this.tabMenuToolbar.SelectTab(tpgMenu);
            }
            else
            {
                // select translation tpg
                this.tabMenuToolbar.SelectTab(tpgTranslateMenu);

                // due to security reason, prevent insert/delete
                qryXMenuItem.CanInsert = false;
                qryXMenuItem.CanDelete = false;
            }
        }

        /// <summary>
        /// Check if any parent of current menu item is type of FrmDataExplorer
        /// </summary>
        /// <param name="menuItemID">MenuItemID in XMenuItem</param>
        /// <returns>True if any parent is type of FrmDataExplorer</returns>
        private bool IsAnyParentFrmDataExplorerClass(int menuItemID)
        {
            // apply current menuitemid to use for loop
            int parentOfParentMenuItemID = menuItemID;

            // loop through parents of current item
            while (parentOfParentMenuItemID > 0)
            {
                // get parent of current item
                parentOfParentMenuItemID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT ISNULL(MNU.ParentMenuItemID, -1)
                    FROM dbo.XMenuItem MNU
                    WHERE MNU.MenuItemID = {0}", parentOfParentMenuItemID));

                // check if item is type of FrmDataExplorer
                if (this.IsMenuItemFrmDataExplorerClass(parentOfParentMenuItemID))
                {
                    return true;
                }
            }

            //if we are here, none of the parents are type of FrmDataExplorerClass
            return false;
        }

        /// <summary>
        /// Check if actually changing position in query
        /// </summary>
        /// <returns>True if is currently changing position in query, false if not changing position</returns>
        private bool IsChangingPosition()
        {
            // check if query is changing row
            return (this.LastSelectedPosition != this.qryXMenuItem.Position || this.treMenuItems.FocusedNode == null);
        }

        /// <summary>
        /// Check if className is type of KissQueryControl (inherited)
        /// </summary>
        /// <param name="className">The name of the class to check</param>
        /// <returns>True if baseclass or inherited from KissQueryControl, otherwise false</returns>
        private bool IsClassTypeOfQueryControl(string className)
        {
            // validate first
            if (DBUtil.IsEmpty(className))
            {
                return false;
            }

            try
            {
                // check if classname is baseclass or inherited from KissQueryControl
                return typeof(KissQueryControl).IsAssignableFrom(AssemblyLoader.GetType(className));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check if menu item is type of FrmDataExplorer
        /// </summary>
        /// <param name="menuItemID">MenuItemID in XMenuItem</param>
        /// <returns>True if item is typeof FrmDataExplorer</returns>
        private bool IsMenuItemFrmDataExplorerClass(int menuItemID)
        {
            // get classname of item
            string className = GetClassNameOfMenuItem(menuItemID);

            // validate
            if (DBUtil.IsEmpty(className))
            {
                return false;
            }

            //  check if class is inherited from FrmDataExplorer
            return this.MainForm.IsClassTypeOfFrmDataExplorer(className);
        }

        /// <summary>
        /// Check if menu item is type of NavBarForm
        /// </summary>
        /// <param name="menuItemID">MenuItemID in XMenuItem</param>
        /// <returns>True if item is typeof NavBarForm</returns>
        private bool IsMenuItemNavBarFormClass(int menuItemID)
        {
            // get classname of item
            string className = GetClassNameOfMenuItem(menuItemID);

            // validate
            if (DBUtil.IsEmpty(className))
            {
                return false;
            }

            //  check if class is inherited from NavBarForm
            return this.MainForm.IsClassTypeOfNavBarForm(className);
        }

        /// <summary>
        /// Determine if a menu item is static (ControlName is not null)
        /// </summary>
        /// <param name="menuItemID">MenuItemID in XMenuItem</param>
        /// <returns>True if item is static, else false</returns>
        private bool IsMenuItemStatic(int menuItemID)
        {
            return !DBUtil.IsEmpty(DBUtil.ExecuteScalarSQL(@"
                SELECT ControlName
                FROM dbo.XMenuItem MNU
                WHERE MNU.MenuItemID = {0}", menuItemID));
        }

        /// <summary>
        /// Check if menuitem has max or min sortkey
        /// </summary>
        /// <param name="compareMinimum">True if comparing for minimum, false if compareing for maximum</param>
        /// <param name="parentItemID">Current ParentMenuItemID of menuitem</param>
        /// <param name="currentSortKey">Current SortKey of menuitem</param>
        /// <returns>True if menuitem is min/max, false if menuitem is not min/max</returns>
        private bool IsMinMaxSortKey(bool compareMinimum, int parentItemID, object currentSortKey)
        {
            // validate
            if (parentItemID < 1 || DBUtil.IsEmpty(currentSortKey) || !Utils.IsNatural(currentSortKey.ToString()))
            {
                return false;
            }

            // get min/max id
            int minMaxSortKey = Convert.ToInt32(DBUtil.ExecuteScalarSQL(string.Format(@"--SQLCHECK_IGNORE--
                SELECT ISNULL({0}(SortKey), -1)
                FROM dbo.XMenuItem
                WHERE ISNULL(ParentMenuItemID, 0) = ISNULL({1}, 0)", compareMinimum ? "MIN" : "MAX", parentItemID)));

            // compare
            return Convert.ToInt32(currentSortKey) == minMaxSortKey;
        }

        /// <summary>
        /// Check if current menu item can be a nav bar group in form
        /// </summary>
        /// <param name="menuItemID">MenuItemID in XMenuItem</param>
        /// <returns>True if item can be a navbar group, else false</returns>
        private bool IsNavBarGroupAllowed(int menuItemID)
        {
            // allowed if subItem [of subItem]* of subItem of topLevelMenuItem
            return !DBUtil.IsEmpty(DBUtil.ExecuteScalarSQL(@"
                SELECT MNU.ParentMenuItemID
                FROM dbo.XMenuItem SUBSUB
                  LEFT JOIN dbo.XMenuItem SUB ON SUB.MenuItemID = SUBSUB.ParentMenuItemID
                  LEFT JOIN dbo.XMenuItem MNU ON MNU.MenuItemID = SUB.ParentMenuItemID
                WHERE SUBSUB.MenuItemID = {0}", menuItemID));
        }

        /// <summary>
        /// Check if parent of current menu item is a nav bar group in form
        /// </summary>
        /// <param name="parentItemID">ParentMenuItemID in XMenuItem</param>
        /// <returns>True if parent is nav bar group item</returns>
        private bool IsParentNavBarGroupItem(int parentItemID)
        {
            int parentOfParentMenuItemID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT ISNULL(MNU.ParentMenuItemID, -1)
                FROM dbo.XMenuItem MNU
                WHERE MNU.MenuItemID = {0}", parentItemID));

            if (parentOfParentMenuItemID < 1)
            {
                return false;
            }
            else
            {
                return this.IsMenuItemNavBarFormClass(parentOfParentMenuItemID);
            }
        }

        /// <summary>
        /// Handle editmode property for controls depending on data-state
        /// Handle CanDelete on query to ensure system and root items cannot be removed
        /// </summary>
        private void RefreshEnabledStates()
        {
            if (this.qryXMenuItem.Row.RowState == DataRowState.Added)
            {
                this.btnUp.Enabled = false;
                this.btnDown.Enabled = false;
                this.btnLeft.Enabled = false;
                this.btnRight.Enabled = false;
            }
            else
            {
                // get current active row
                DataRow row = this.qryXMenuItem.Row;

                // init flags
                bool isToolbar = false;
                bool isBIAGAdmin = _accessMode == AccessMode.BIAGAdmin;

                if (this.tabMenuToolbar.IsTabSelected(this.tpgToolbar))
                {
                    isToolbar = true;
                    row = this.qryToolbar.Row;
                }

                // check if we have an id
                if (DBUtil.IsEmpty(row["MenuItemID"]))
                {
                    return;
                }

                // get values
                int menuItemID = Convert.ToInt32(row["MenuItemID"]);
                int parentItemID = row["ParentMenuItemID"] == System.DBNull.Value ? -1 : Convert.ToInt32(row["ParentMenuItemID"]);

                // handle root-items, static-items, system-flag and navbar flags
                bool isRoot = row["ParentMenuItemID"] == System.DBNull.Value;
                bool isTopLevelMenu = !isRoot && parentItemID == 1;
                bool isStatic = (!isRoot && !DBUtil.IsEmpty(row["ControlName"]));
                bool isSystem = Convert.ToBoolean(row["System"]);

                bool isNavBarGroup = this.IsMenuItemNavBarFormClass(parentItemID);
                bool isParentNavBarGroupItem = !isRoot && this.IsParentNavBarGroupItem(parentItemID);
                bool isNavBarGroupAllowed = !isSystem && !isParentNavBarGroupItem && this.IsNavBarGroupAllowed(menuItemID);

                bool isParentFrmDataExplorer = this.IsAnyParentFrmDataExplorerClass(menuItemID);

                // edit modes
                EditModeType editModeClassName = (isRoot || isTopLevelMenu || isSystem || isStatic) ? EditModeType.ReadOnly : EditModeType.Normal;

                EditModeType editModeEnabled = (isSystem || isRoot || isParentFrmDataExplorer) ? EditModeType.ReadOnly : EditModeType.Normal;
                EditModeType editModeVisible = (isSystem || isRoot) ? EditModeType.ReadOnly : EditModeType.Normal;
                EditModeType editModeOnlyBIAGAdmin = (isRoot) ? EditModeType.ReadOnly : EditModeType.Normal;

                EditModeType editModeRoot = (isRoot || isTopLevelMenu || isParentFrmDataExplorer) ? EditModeType.ReadOnly : EditModeType.Normal;
                EditModeType editModeImageIndex = editModeRoot;

                if (isNavBarGroup || isParentNavBarGroupItem)
                {
                    // disable some items if navbargroup or navbaritem
                    editModeRoot = EditModeType.ReadOnly;

                    if (!isParentNavBarGroupItem)
                    {
                        // should even have a classname if is item in group
                        editModeClassName = EditModeType.ReadOnly;
                    }
                }

                // check selected tab
                if (isToolbar)
                {
                    // TabTOOLBAR
                    this.chkShowInToolbar2.EditMode = editModeRoot;
                    this.chkBeginToolbarGroup2.EditMode = editModeRoot;
                    this.txtToolbarSortKey2.EditMode = editModeRoot;

                    this.chkEnabled2.EditMode = editModeEnabled;
                    this.chkVisible2.EditMode = editModeVisible;
                    this.chkStaticItem2.Checked = (isStatic || isRoot);
                }
                else
                {
                    // TabMENU
                    // query
                    this.qryXMenuItem.CanInsert = isBIAGAdmin && (!isParentNavBarGroupItem && (isRoot || (isTopLevelMenu || (!isSystem && !isStatic))));
                    this.qryXMenuItem.CanDelete = isBIAGAdmin && (!isRoot && !isSystem && !isStatic);

                    // buttons (<,>,^,v)
                    object res = DBUtil.ExecuteScalarSQL(@"
                        SELECT ParentMenuItemID
                        FROM dbo.XMenuItem MNU
                        WHERE MNU.MenuItemID = {0}", row["ParentMenuItemID"]);

                    bool isParentRoot = (res == null || res == System.DBNull.Value);
                    bool isParentTopLevelMenu = (!isParentRoot && Convert.ToInt32(res) == 1);
                    int previousMenuItemID = this.GetMenuItemIDOfPreviousNode(menuItemID, parentItemID);
                    bool canBeSubOfPrevious = (previousMenuItemID > 0 && parentItemID > 0 && previousMenuItemID != parentItemID && !this.IsMenuItemStatic(previousMenuItemID));

                    this.btnLeft.Enabled = !(isRoot || isTopLevelMenu || isParentRoot || isParentTopLevelMenu || isSystem || isNavBarGroup);
                    this.btnRight.Enabled = !(isRoot || isTopLevelMenu || isSystem || !canBeSubOfPrevious || isParentNavBarGroupItem);
                    this.btnUp.Enabled = !(isRoot || qryXMenuItem.Count <= 1 || this.IsMinMaxSortKey(true, parentItemID, row["SortKey"]));
                    this.btnDown.Enabled = !(isRoot || qryXMenuItem.Count <= 1 || this.IsMinMaxSortKey(false, parentItemID, row["SortKey"]));

                    // other controls
                    if (isRoot)
                    {
                        this.edtCaptionML.EditMode = EditModeType.ReadOnly;
                        this.edtTranslationCaptionML.EditMode = EditModeType.ReadOnly;
                        this.chkHideLockedItems.EditMode = EditModeType.Normal;

                        if (this.chkHideLockedItems.DataMember != "HideLockedItems")
                        {
                            this.chkHideLockedItems.DataMember = "HideLockedItems";
                        }
                    }
                    else
                    {
                        this.edtCaptionML.EditMode = EditModeType.Normal;
                        this.edtTranslationCaptionML.EditMode = EditModeType.Normal;
                        this.chkHideLockedItems.EditMode = EditModeType.ReadOnly;

                        if (this.chkHideLockedItems.DataMember != "HideLockedItemsRoot")
                        {
                            this.chkHideLockedItems.DataMember = "HideLockedItemsRoot";
                        }
                    }

                    this.chkItemShortcutCtrl.EditMode = editModeRoot;
                    this.chkItemShortcutShift.EditMode = editModeRoot;
                    this.chkItemShortcutAlt.EditMode = editModeRoot;
                    this.cboItemShortcutKey.EditMode = editModeRoot;
                    this.cboImageIndex.EditMode = editModeImageIndex;
                    this.cboImageIndexDisabled.EditMode = editModeRoot;
                    this.chkBeginMenuGroup.EditMode = editModeRoot;
                    this.chkShowInToolbar.EditMode = editModeRoot;
                    this.chkBeginToolbarGroup.EditMode = editModeRoot;
                    this.txtToolbarSortKey.EditMode = editModeRoot;

                    this.cboClassName.EditMode = editModeClassName;
                    this.chkEnabled.EditMode = editModeEnabled;
                    this.chkVisible.EditMode = editModeVisible;
                    this.chkMenuOnlyBIAGAdmin.EditMode = editModeOnlyBIAGAdmin;

                    this.chkStaticItem.Checked = (isStatic || isRoot);
                    this.chkQuery.Checked = isParentFrmDataExplorer;

                    // navbar
                    this.chkNavBarGroup.Checked = isNavBarGroup;
                    this.chkNavBarItem.Checked = isParentNavBarGroupItem;

                    if (isParentNavBarGroupItem)
                    {
                        this.edtControlID.DataSource = this.qryXMenuItem;
                        this.edtControlID.DataMember = "ControlName";
                        this.edtControlID.EditMode = isSystem ? EditModeType.ReadOnly : EditModeType.Normal;
                    }
                    else
                    {
                        this.edtControlID.EditMode = EditModeType.ReadOnly;
                        this.edtControlID.DataSource = null;
                        this.edtControlID.DataMember = "";

                        this.edtControlID.DataBindings.Clear();
                        this.edtControlID.EditValue = null;
                    }

                    // refresh databinding in order to apply changes made to datasources
                    this.qryXMenuItem.BindControls();
                    this.qryXMenuItem.RefreshDisplay();

                    // dataexplorer
                    if (isParentFrmDataExplorer)
                    {
                        // icon depending on children of current item
                        if (this.HasChildren(menuItemID))
                        {
                            // icon of subfolder
                            //this.qryXMenuItem.Row["ImageIndex"] = 166;
                            this.cboImageIndex.EditValue = 166;
                        }
                        else
                        {
                            // icon of item
                            //this.qryXMenuItem.Row["ImageIndex"] = 210;
                            this.cboImageIndex.EditValue = 210;
                        }
                    }
                }
            }
        }

        private void RefreshTree()
        {
            try
            {
                // check if already refreshing
                if (_isRefreshingTree)
                {
                    return;
                }

                // set flag
                _isRefreshingTree = true;

                // depending on access mode
                if (_accessMode == AccessMode.BIAGAdmin)
                {
                    // BIAGAdmin
                    this.treMenuItems.SaveState();
                    this.treMenuItems.DataSource = null;
                    this.FillDataSource(this.qryTreeItems);
                    this.treMenuItems.RefreshDataSource();

                    _isRefreshingTree = false;

                    this.treMenuItems.LoadState();
                }
                else
                {
                    // normal admin
                    this.treTranslateMenuItems.SaveState();
                    this.treTranslateMenuItems.DataSource = null;
                    this.FillDataSource(this.qryTreeItems);
                    this.treTranslateMenuItems.RefreshDataSource();

                    _isRefreshingTree = false;

                    this.treTranslateMenuItems.LoadState();
                }
            }
            catch (Exception ex)
            {
                LOG.Warn("Exception occured in refreshing tree.", ex);
            }
            finally
            {
                _isRefreshingTree = false;
            }
        }

        private AccessMode SetupRights()
        {
            // return access mode depending on current user's rights
            if (Session.User.IsUserBIAGAdmin)
            {
                // BIAG admin
                return AccessMode.BIAGAdmin;
            }

            if (Session.User.IsUserAdmin || DBUtil.UserHasRight("DSGBusinessDesignerAdmin"))
            {
                // normal admin or user has special right
                return AccessMode.Admin;
            }

            // no access to this control without admin privileges
            throw new Exception("Access to this control is denied. User has no administration privileges.");
        }

        /// <summary>
        /// Show and hide tabpages depending on user's rights
        /// </summary>
        private void ShowHideTabPagesDependingOnRights()
        {
            // check current mode
            if (_accessMode == AccessMode.BIAGAdmin)
            {
                // remove translation tpg
                tabMenuToolbar.TabPages.Remove(tpgTranslateMenu);
            }
            else
            {
                // remove all tabs except the translation and rights tpg
                tabMenuToolbar.TabPages.Clear();
                tabMenuToolbar.TabPages.Add(tpgTranslateMenu);
                tabMenuToolbar.TabPages.Add(tpgXRight);
            }
        }

        /// <summary>
        /// Validate input controls and apply current (changed) value
        /// </summary>
        private void ValidateInputControls()
        {
            // depending on current access mode
            if (_accessMode == AccessMode.BIAGAdmin)
            {
                // BIAGAdmin
                this.edtCaptionML.DoValidate();
                this.chkItemShortcutCtrl.DoValidate();
                this.chkItemShortcutShift.DoValidate();
                this.chkItemShortcutAlt.DoValidate();
                this.cboItemShortcutKey.DoValidate();
                this.cboImageIndex.DoValidate();
                this.cboImageIndexDisabled.DoValidate();
                this.cboClassName.DoValidate();
                this.chkEnabled.DoValidate();
                this.chkVisible.DoValidate();
                this.chkBeginMenuGroup.DoValidate();
                this.chkShowInToolbar.DoValidate();
                this.txtToolbarSortKey.DoValidate();
                this.chkBeginToolbarGroup.DoValidate();
                this.chkSystem.DoValidate();
                this.chkMenuOnlyBIAGAdmin.DoValidate();
                this.edtDescription.DoValidate();
                this.edtControlID.DoValidate();
            }
            else
            {
                // normal admin
                this.edtTranslationCaptionML.DoValidate();
            }
        }

        /// <summary>
        /// Validates sortkey for toolbar. In case of invalid value, sets next possible value and throws an exception.
        /// </summary>
        /// <param name="edt">Editfield to check</param>
        /// <param name="qry">Query to check</param>
        private void ValidateToolbarSortKey(TextEdit edt, SqlQuery qry)
        {
            // validate required value
            if (Convert.ToBoolean(qry.Row["ShowInToolbar"]))
            {
                // requires a valid number for toolbarsortkey
                DBUtil.CheckNotNullField((IKissBindableEdit)edt, lblToolbarSortKey.Text);
            }

            // check entered a toolbarsortkey --> validate
            if (!DBUtil.IsEmpty(edt.EditValue))
            {
                // validate value
                if (!Utils.IsNatural(edt.EditValue.ToString()) || Convert.ToInt32(edt.EditValue) < 0)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlMenuEditor", "InvalidToolbarSortKeyValue", "Die eingegebene Nummer der Toolbarsortierung ist ungültig. Es wird eine positive Zahl verlangt.", KissMsgCode.MsgError), edt);
                }

                // check if number is not yet used
                if (Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(1)
                    FROM dbo.XMenuItem
                    WHERE ToolbarSortKey = {0} AND
                          MenuItemID! = {1}", qry.Row["ToolbarSortKey"], qry.Row["MenuItemID"])) > 0)
                {
                    // get current toolbarsortkey
                    int currentToolbarSortKey = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                        SELECT ISNULL(ToolbarSortKey, -1)
                        FROM dbo.XMenuItem
                        WHERE MenuItemID = {0}", qry.Row["MenuItemID"]));

                    if (currentToolbarSortKey > -1)
                    {
                        // take old value
                        qry.Row["ToolbarSortKey"] = currentToolbarSortKey;
                        throw new KissInfoException(KissMsg.GetMLMessage("CtlMenuEditor", "InvalidToolbarSortKeyTakeOld", "Die eingegebene Nummer der Toolbarsortierung wurde bereits verwendet.{0}Es wird die alte Nummer eingesetzt.", KissMsgCode.MsgInfo, Environment.NewLine), edt);
                    }
                    else
                    {
                        // get next possible toobarsortkey
                        int nextToolbarSortKey = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                            SELECT ISNULL(MAX(ToolbarSortKey), 0)
                            FROM dbo.XMenuItem"));

                        qry.Row["ToolbarSortKey"] = nextToolbarSortKey + 1;

                        throw new KissInfoException(KissMsg.GetMLMessage("CtlMenuEditor", "InvalidToolbarSortKeyTakeNext", "Die eingegebene Nummer der Toolbarsortierung wurde bereits verwendet.{0}Es wird die nächstmögliche Nummer eingesetzt.", KissMsgCode.MsgInfo, Environment.NewLine), edt);
                    }
                }
            }
        }

        #endregion

        #endregion
    }
}