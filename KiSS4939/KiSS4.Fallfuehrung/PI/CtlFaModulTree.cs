using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList.Nodes;
using Kiss.Interfaces.UI;
using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Fallfuehrung.PI
{
    /// <summary>
    /// Control, used for displaying tree of AKV
    /// </summary>
    public class CtlFaModulTree : KiSS4.Common.KissModulTree
    {
        #region Fields

        #region Private Static Fields

        /// The Log4Net logger.
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private string _cancelDlgBtn = KissMsg.GetMLMessage("CtlFaModulTree", "CancelDlgBtn", "Abbrechen");
        private string _closeFVDlgBtn = KissMsg.GetMLMessage("CtlFaModulTree", "CloseFVDlgBtn", "FV schliessen");
        private bool _doRefocusNodeAfterFocusNode = false; // flag for hack where in detailcontrol a refreshtree-call is and user clicks without saving another node
        private bool _isLoading = false;
        private string _newABDlgBtn = KissMsg.GetMLMessage("CtlFaModulTree", "NewABDlgBtn", "Neu: AB");
        private string _newBWDlgBtn = KissMsg.GetMLMessage("CtlFaModulTree", "NewBWDlgBtn", "Neu: BW");
        private string _newCMDlgBtn = KissMsg.GetMLMessage("CtlFaModulTree", "NewCMDlgBtn", "Neu: CM");
        private string _newEDDlgBtn = KissMsg.GetMLMessage("CtlFaModulTree", "NewEDDlgBtn", "Neu: ED");
        private string _newIntakeDlgBtn = KissMsg.GetMLMessage("CtlFaModulTree", "NewIntakeDlgBtn", "Neu: Intake");
        private string _newSBDlgBtn = KissMsg.GetMLMessage("CtlFaModulTree", "NewSBDlgBtn", "Neu: SB");
        private string _newWDDlgBtn = KissMsg.GetMLMessage("CtlFaModulTree", "NewWDDlgBtn", "Neu: WD");
        private string _noMoreOpenDLsIntakeQuestion = KissMsg.GetMLMessage("CtlFaModulTree", "NoMoreOpenDLsIntakeQuestion", "Es wurden alle Dienstleistungen und Intakes abgeschlossen.\r\nWollen Sie den offenen Fallverlauf nun schliessen oder eine neue Dienstleistung/ein neues Intake eröffnen?");
        private int _userLang = Session.User.LanguageCode;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnFallInfoBD;
        private DevExpress.XtraBars.BarButtonItem btnNewAB;
        private DevExpress.XtraBars.BarButtonItem btnNewBW;
        private DevExpress.XtraBars.BarButtonItem btnNewCM;
        private DevExpress.XtraBars.BarButtonItem btnNewED;
        private DevExpress.XtraBars.BarButtonItem btnNewIntake;
        private DevExpress.XtraBars.BarButtonItem btnNewSB;
        private DevExpress.XtraBars.BarButtonItem btnNewWD;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAbschluss;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAppCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAufnahme;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFaLeistungID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaskName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colModulID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSAR;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTitel;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFaModulTree"/> class.
        /// </summary>
        /// <param name="baPersonID">The id of the person to use for tree</param>
        /// <param name="panelDetail">The detail panel to use for further controls</param>
        public CtlFaModulTree(int baPersonID, System.Windows.Forms.Panel panelDetail)
            : base(baPersonID, -1, panelDetail, 2)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // init popupmenu
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).BeginInit();
            this.SuspendLayout();
            this.popup_Tree.LinksPersistInfo.Clear();
            this.popup_Tree.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewIntake),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewSB, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewCM),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewBW),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewED),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewAB),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewWD),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFallInfoBD, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete, true)});
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).EndInit();
            this.ResumeLayout(false);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFaModulTree"/> class. (no public usage)
        /// </summary>
        private CtlFaModulTree()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnFallInfoBD = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewBW = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewCM = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewED = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewIntake = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewSB = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewAB = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewWD = new DevExpress.XtraBars.BarButtonItem();
            this.colAbschluss = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAppCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAufnahme = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFaLeistungID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMaskName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colModulID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSAR = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTitel = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).BeginInit();
            this.SuspendLayout();
            //
            // kissTree
            //
            this.kissTree.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.kissTree.Appearance.Empty.ForeColor = System.Drawing.Color.White;
            this.kissTree.Appearance.Empty.Options.UseBackColor = true;
            this.kissTree.Appearance.Empty.Options.UseForeColor = true;
            this.kissTree.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.kissTree.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.kissTree.Appearance.EvenRow.Options.UseBackColor = true;
            this.kissTree.Appearance.EvenRow.Options.UseForeColor = true;
            this.kissTree.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.kissTree.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.kissTree.Appearance.FocusedCell.Options.UseBackColor = true;
            this.kissTree.Appearance.FocusedCell.Options.UseForeColor = true;
            this.kissTree.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.kissTree.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.kissTree.Appearance.FocusedRow.Options.UseFont = true;
            this.kissTree.Appearance.FocusedRow.Options.UseForeColor = true;
            this.kissTree.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.kissTree.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.kissTree.Appearance.FooterPanel.Options.UseBackColor = true;
            this.kissTree.Appearance.FooterPanel.Options.UseFont = true;
            this.kissTree.Appearance.FooterPanel.Options.UseForeColor = true;
            this.kissTree.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.kissTree.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.kissTree.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.kissTree.Appearance.GroupButton.Options.UseBackColor = true;
            this.kissTree.Appearance.GroupButton.Options.UseFont = true;
            this.kissTree.Appearance.GroupButton.Options.UseForeColor = true;
            this.kissTree.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.kissTree.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.kissTree.Appearance.GroupFooter.Options.UseBackColor = true;
            this.kissTree.Appearance.GroupFooter.Options.UseForeColor = true;
            this.kissTree.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.kissTree.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.kissTree.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.kissTree.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.kissTree.Appearance.HeaderPanel.Options.UseFont = true;
            this.kissTree.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.kissTree.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.kissTree.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.kissTree.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.kissTree.Appearance.HideSelectionRow.Options.UseFont = true;
            this.kissTree.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.kissTree.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.kissTree.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.kissTree.Appearance.HorzLine.Options.UseBackColor = true;
            this.kissTree.Appearance.HorzLine.Options.UseForeColor = true;
            this.kissTree.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.kissTree.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.kissTree.Appearance.OddRow.Options.UseBackColor = true;
            this.kissTree.Appearance.OddRow.Options.UseFont = true;
            this.kissTree.Appearance.OddRow.Options.UseForeColor = true;
            this.kissTree.Appearance.Preview.BackColor = System.Drawing.Color.White;
            this.kissTree.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree.Appearance.Preview.ForeColor = System.Drawing.Color.Maroon;
            this.kissTree.Appearance.Preview.Options.UseBackColor = true;
            this.kissTree.Appearance.Preview.Options.UseFont = true;
            this.kissTree.Appearance.Preview.Options.UseForeColor = true;
            this.kissTree.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.kissTree.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.kissTree.Appearance.Row.Options.UseBackColor = true;
            this.kissTree.Appearance.Row.Options.UseFont = true;
            this.kissTree.Appearance.Row.Options.UseForeColor = true;
            this.kissTree.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.kissTree.Appearance.SelectedRow.Options.UseForeColor = true;
            this.kissTree.Appearance.TreeLine.BackColor = System.Drawing.Color.White;
            this.kissTree.Appearance.TreeLine.ForeColor = System.Drawing.Color.Gray;
            this.kissTree.Appearance.TreeLine.Options.UseBackColor = true;
            this.kissTree.Appearance.TreeLine.Options.UseForeColor = true;
            this.kissTree.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.kissTree.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.kissTree.Appearance.VertLine.Options.UseBackColor = true;
            this.kissTree.Appearance.VertLine.Options.UseForeColor = true;
            this.kissTree.Appearance.VertLine.Options.UseTextOptions = true;
            this.kissTree.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.kissTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
                        this.colTitel,
                        this.colAufnahme,
                        this.colSAR,
                        this.colAbschluss,
                        this.colFaLeistungID,
                        this.colModulID,
                        this.colMaskName,
                        this.colAppCode});
            this.kissTree.OptionsBehavior.AutoSelectAllInEditor = false;
            this.kissTree.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.kissTree.OptionsBehavior.Editable = false;
            this.kissTree.OptionsBehavior.KeepSelectedOnClick = false;
            this.kissTree.OptionsBehavior.MoveOnEdit = false;
            this.kissTree.OptionsBehavior.ShowToolTips = false;
            this.kissTree.OptionsBehavior.SmartMouseHover = false;
            this.kissTree.OptionsMenu.EnableColumnMenu = false;
            this.kissTree.OptionsMenu.EnableFooterMenu = false;
            this.kissTree.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.kissTree.OptionsView.AutoWidth = false;
            this.kissTree.OptionsView.EnableAppearanceEvenRow = true;
            this.kissTree.OptionsView.EnableAppearanceOddRow = true;
            this.kissTree.OptionsView.ShowIndicator = false;
            this.kissTree.OptionsView.ShowVertLines = false;
            this.kissTree.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowOnlyInEditor;
            this.kissTree.Size = new System.Drawing.Size(265, 500);
            this.kissTree.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            this.kissTree.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.kissTree_FocusedNodeChanged);
            //
            // popup_Tree
            //
            this.popup_Tree.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnNewIntake, true),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnNewSB, true),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnNewCM),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnNewBW),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnNewED),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnNewAB),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnNewWD),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnFallInfo, true),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnFallZugriff),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete, true),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnFallInfo, true),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnFallZugriff),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnFallZugriff),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnFallInfo)});
            //
            // barManager_Tree
            //
            this.barManager_Tree.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                        this.btnNewIntake,
                        this.btnNewSB,
                        this.btnNewBW,
                        this.btnNewCM,
                        this.btnNewED,
                        this.btnNewAB,
                        this.btnNewWD,
                        this.btnFallInfoBD,
                        this.btnDelete});
            this.barManager_Tree.MaxItemId = 13;
            this.barManager_Tree.QueryShowPopupMenu += new DevExpress.XtraBars.QueryShowPopupMenuEventHandler(this.barManager_Tree_QueryShowPopupMenu);
            //
            // btnFallZugriff
            //
            this.btnFallZugriff.CategoryGuid = new System.Guid("f96a77cc-41a0-4295-8f5a-5c2410a21ef7");
            this.btnFallZugriff.Enabled = false;
            this.btnFallZugriff.ImageIndex = -1;
            //
            // btnFallInfo
            //
            this.btnFallInfo.CategoryGuid = new System.Guid("f96a77cc-41a0-4295-8f5a-5c2410a21ef7");
            this.btnFallInfo.Enabled = false;
            this.btnFallInfo.ImageIndex = -1;
            //
            // btnDelete
            //
            this.btnDelete.Caption = "Löschen";
            this.btnDelete.Id = 11;
            this.btnDelete.ImageIndex = 4;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            //
            // btnFallInfoBD
            //
            this.btnFallInfoBD.Caption = "Fallinfo";
            this.btnFallInfoBD.Id = 13;
            this.btnFallInfoBD.Name = "btnFallInfoBD";
            this.btnFallInfoBD.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFallInfoBD_ItemClick);
            //
            // btnNewBW
            //
            this.btnNewBW.Caption = "Neu: Begleitetes Wohnen";
            this.btnNewBW.Id = 4;
            this.btnNewBW.ImageIndex = 1501;
            this.btnNewBW.Name = "btnNewBW";
            this.btnNewBW.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewBW_ItemClick);
            //
            // btnNewCM
            //
            this.btnNewCM.Caption = "Neu: Case Management";
            this.btnNewCM.Id = 5;
            this.btnNewCM.ImageIndex = 1401;
            this.btnNewCM.Name = "btnNewCM";
            this.btnNewCM.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewCM_ItemClick);
            //
            // btnNewED
            //
            this.btnNewED.Caption = "Neu: Entlastungsdienst";
            this.btnNewED.Id = 6;
            this.btnNewED.ImageIndex = 1601;
            this.btnNewED.Name = "btnNewED";
            this.btnNewED.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewED_ItemClick);
            //
            // btnNewIntake
            //
            this.btnNewIntake.Caption = "Neu: Intake";
            this.btnNewIntake.Id = 10;
            this.btnNewIntake.ImageIndex = 1701;
            this.btnNewIntake.Name = "btnNewIntake";
            this.btnNewIntake.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewIntake_ItemClick);
            //
            // btnNewSB
            //
            this.btnNewSB.Caption = "Neu: Sozialberatung";
            this.btnNewSB.Id = 7;
            this.btnNewSB.ImageIndex = 1301;
            this.btnNewSB.Name = "btnNewSB";
            this.btnNewSB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewSB_ItemClick);
            //
            // btnNewAB
            //
            this.btnNewAB.Caption = "Neu: Assistenzberatung";
            this.btnNewAB.Id = 8;
            this.btnNewAB.ImageIndex = 1801;
            this.btnNewAB.Name = "btnNewAB";
            this.btnNewAB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewAB_ItemClick);
            //
            // btnWD
            //
            this.btnNewWD.Caption = "Neu: Weitere Dienstleistungen";
            this.btnNewWD.Id = 9;
            this.btnNewWD.ImageIndex = 4101;
            this.btnNewWD.Name = "btnNewWD";
            this.btnNewWD.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewWD_ItemClick);
            //
            // colAbschluss
            //
            this.colAbschluss.Caption = "bis";
            this.colAbschluss.FieldName = "Abschluss";
            this.colAbschluss.Name = "colAbschluss";
            this.colAbschluss.OptionsColumn.AllowSort = false;
            this.colAbschluss.VisibleIndex = 3;
            this.colAbschluss.Width = 85;
            //
            // colAppCode
            //
            this.colAppCode.Caption = "AppCode";
            this.colAppCode.FieldName = "AppCode";
            this.colAppCode.Name = "colAppCode";
            this.colAppCode.OptionsColumn.AllowSort = false;
            //
            // colAufnahme
            //
            this.colAufnahme.Caption = "ab";
            this.colAufnahme.FieldName = "Aufnahme";
            this.colAufnahme.Name = "colAufnahme";
            this.colAufnahme.OptionsColumn.AllowSort = false;
            this.colAufnahme.VisibleIndex = 1;
            this.colAufnahme.Width = 85;
            //
            // colFaLeistungID
            //
            this.colFaLeistungID.Caption = "FaLeistungID";
            this.colFaLeistungID.FieldName = "FaFallID";
            this.colFaLeistungID.Name = "colFaLeistungID";
            this.colFaLeistungID.OptionsColumn.AllowSort = false;
            //
            // colMaskName
            //
            this.colMaskName.Caption = "MaskName";
            this.colMaskName.FieldName = "MaskName";
            this.colMaskName.Name = "colMaskName";
            this.colMaskName.OptionsColumn.AllowSort = false;
            //
            // colModulID
            //
            this.colModulID.Caption = "ModulID";
            this.colModulID.FieldName = "ModulCode";
            this.colModulID.Name = "colModulID";
            this.colModulID.OptionsColumn.AllowSort = false;
            //
            // colSAR
            //
            this.colSAR.Caption = "SAR";
            this.colSAR.FieldName = "SARName";
            this.colSAR.Name = "colSAR";
            this.colSAR.OptionsColumn.AllowSort = false;
            this.colSAR.VisibleIndex = 2;
            this.colSAR.Width = 200;
            //
            // colTitel
            //
            this.colTitel.Caption = "Aktenführung";
            this.colTitel.FieldName = "Name";
            this.colTitel.Name = "colTitel";
            this.colTitel.OptionsColumn.AllowSort = false;
            this.colTitel.VisibleIndex = 0;
            this.colTitel.Width = 200;
            //
            // CtlFaModulTree
            //
            this.Name = "CtlFaModulTree";
            this.Size = new System.Drawing.Size(265, 500);
            this.Load += new System.EventHandler(this.CtlFaModulTree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region EventHandlers

        protected override void kissTree_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // cancel update if loading
            if (this._isLoading)
            {
                // logging
                _logger.Debug("cancel: isLoading=true");

                // remove control and show nothing
                this.ShowDetail(null);

                // do not continue
                return;
            }

            // get current cursor to reset after execution of this part
            Cursor current = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // handle empty node
                if (e == null || e.Node == null)
                {
                    // logging
                    _logger.Debug("cancel: empty node");

                    // cancel
                    return;
                }

                // HACK: SELECTION PROBLEM WHEN REFRESHING TREE AND NODE CHANGEING
                // check if focused node does really exist
                DevExpress.XtraTreeList.Nodes.TreeListNode currentNode = kissTree.FindNodeByKeyID(e.Node.GetValue(kissTree.KeyFieldName));

                // check if same with current node
                if (currentNode != null && e.Node != currentNode)
                {
                    // logging
                    _logger.Debug("cancel: because of new node after refreshing tree!");

                    // set flag
                    this._doRefocusNodeAfterFocusNode = true;

                    // cancel
                    return;
                }

                // reset flag
                this._doRefocusNodeAfterFocusNode = false;

                // GO ON:
                // check rights (CHANGE: to not hide data anymore, make it locked only)
                bool userMayReadFall = !DBUtil.IsEmpty(e.Node.GetValue("UserMayReadFall")) && Convert.ToBoolean(e.Node.GetValue("UserMayReadFall"));
                bool hasNoFaLeistungID = DBUtil.IsEmpty(e.Node.GetValue("FaLeistungID"));

                // if no FaLeistungID given, then rights for fall are ok
                if (hasNoFaLeistungID)
                {
                    // may read fall (it's not a fall and can be accessed)
                    userMayReadFall = true;
                }

                // get classname of current node
                string classname = Convert.ToString(e.Node.GetValue("ClassName"));

                // validate first
                if (classname != null)
                {
                    IKissView ctrl = null;
                    bool forceDispose = false;

                    // get current values
                    string id = e.Node.GetValue("ID") as String;
                    object faLeistungID = e.Node.GetValue("FaLeistungID");
                    object modulID = e.Node.GetValue("ModulID");
                    string name = e.Node.GetValue("Name") as String;
                    object personID = e.Node.GetValue("BaPersonID");
                    bool isLeistungClosed = !DBUtil.IsEmpty(e.Node.GetValue("DatumBis"));

                    // logging
                    _logger.DebugFormat("id='{0}', faLeistungID='{1}', name='{2}', personID='{3}', isLeistungClosed='{4}', hasNoFaLeistungID='{5}'", id, faLeistungID, name, personID, isLeistungClosed, hasNoFaLeistungID);

                    // load control depending on classname and type
                    System.Type type = AssemblyLoader.GetType(classname);

                    if (type != null)
                    {
                        ctrl = _showDetail.GetDetailControl(type, true);
                        ctrl.Name = classname;  // apply classname, not the name!
                    }
                    if (ctrl == null || id != null && id.StartsWith("X"))
                    {
                        this.ShowDetail(ctrl);
                        return;
                    }

                    #region Invoke depending on classname

                    // invoke methods depending on classname (sorted by tree order)
                    switch (classname)
                    {
                        case "CtlEmpty":
                            // do nothing if it is this control
                            break;

                        case "CtlFaUebersichtsgrafik":
                            // TODO: item is not yet defined...
                            AssemblyLoader.InvokeMethode(ctrl, "Init");
                            forceDispose = true;
                            break;

                        // general per person
                        case "CtlFaSozialsystemContainer":
                        case "CtlFaJournal":
                        case "CtlFaLeistungKlient":
                        case "CtlFaSituationsbeschreibung":
                        case "CtlFaAktennotizen":
                        case "CtlFaAbmachungen":
                        case "CtlFaDokumente":
                        case "CtlFaFinanzgesuche":
                        case "CtlGvGesuchverwaltung":
                        case "CtlFaBetreuungsinfo":
                            if (personID is Int32)
                            {
                                AssemblyLoader.InvokeMethode(ctrl, "Init", name, this.GetIcon(e), Convert.ToInt32(personID));
                            }

                            // check if need to force dispose
                            if (classname == "CtlFaSozialsystemContainer")
                            {
                                // every new focusNode reloads item
                                forceDispose = true;
                            }
                            break;

                        // beratungsperiode
                        case "CtlFaBeratungsperiode":
                            if (faLeistungID is Int32 && personID is Int32)
                            {
                                AssemblyLoader.InvokeMethode(ctrl, "Init", name, this.GetIcon(e), Convert.ToInt32(faLeistungID), Convert.ToInt32(personID));
                            }

                            // every new focusNode reloads item
                            forceDispose = true;
                            break;

                        // intake
                        case "CtlFaIntake":
                            if (faLeistungID is Int32)
                            {
                                AssemblyLoader.InvokeMethode(ctrl, "Init", name, this.GetIcon(e), Convert.ToInt32(faLeistungID));
                            }
                            break;

                        // dienstleistungen
                        case "CtlSbZielvereinbarung":
                        case "CtlSbEvaluation":

                        case "CtlCmZielvereinbarung":
                        case "CtlCmEvaluation":

                        ////case "CtlBwZielvereinbarung":
                        ////case "CtlBwEvaluation":
                        case "CtlBwEinsatzvereinbarung":
                        case "CtlBwAuswertungOrganisation":

                        case "CtlEdEinsatzvereinbarung":
                        case "CtlEdAuswertungsdaten":
                            if (faLeistungID is int)
                            {
                                // call init
                                AssemblyLoader.InvokeMethode(ctrl, "Init", name, this.GetIcon(e), Convert.ToInt32(faLeistungID), isLeistungClosed);
                            }
                            break;

                        case "CtlEinsatz":
                            if (faLeistungID is int && modulID is int)
                            {
                                // call init
                                AssemblyLoader.InvokeMethode(ctrl, "Init", name, this.GetIcon(e), Convert.ToInt32(faLeistungID), isLeistungClosed, Convert.ToInt32(modulID));

                                // every new focusNode reloads item
                                forceDispose = true;
                            }
                            break;

                        // unknown/other
                        default:
                            // if nothing is defined, try to call a default init method
                            try
                            {
                                AssemblyLoader.InvokeMethode(ctrl, "Init", name, this.GetIcon(e));
                            }
                            catch { }
                            break;
                    }

                    #endregion

                    #region Rights

                    // apply rights
                    KissUserControl kissUserCtrl = ctrl as KissUserControl;
                    if (kissUserCtrl != null && kissUserCtrl.ActiveSQLQuery != null)
                    {
                        if (hasNoFaLeistungID)
                        {
                            #region Without FaLeistungID

                            // logging
                            _logger.Debug("mode <without faleistungid>");

                            // init vars
                            bool isAdmin = Session.User.IsUserAdmin;
                            bool canReadData = false;
                            bool canUserInsert = false;
                            bool canUserUpdate = false;
                            bool canUserDelete = false;

                            // set values
                            Session.GetUserRight(kissUserCtrl.Name, out canReadData, out canUserInsert, out canUserUpdate, out canUserDelete);

                            // logging
                            _logger.DebugFormat("ctrl.Name='{0}', isAdmin='{1}', canReadData='{2}', canUserInsert='{3}', canUserUpdate='{4}', canUserDelete='{5}'", kissUserCtrl.Name, isAdmin, canReadData, canUserInsert, canUserUpdate, canUserDelete);

                            // setup ActiveSQLQuery depending on current state and rights
                            kissUserCtrl.ActiveSQLQuery.CanInsert = kissUserCtrl.ActiveSQLQuery.CanInsert && (isAdmin || (canReadData && canUserInsert));
                            kissUserCtrl.ActiveSQLQuery.CanUpdate = kissUserCtrl.ActiveSQLQuery.CanUpdate && (isAdmin || (canReadData && canUserUpdate));
                            kissUserCtrl.ActiveSQLQuery.CanDelete = kissUserCtrl.ActiveSQLQuery.CanDelete && (isAdmin || (canReadData && canUserDelete));

                            #endregion
                        }
                        else
                        {
                            #region With FaLeistungID

                            // logging
                            _logger.Debug("mode <with faleistungid>");

                            // Rechte setzen
                            SqlQuery qryLeistungZugriff = DBUtil.OpenSQL(@"
                                SELECT TOP 1
                                       OwnerID      = LEI.UserID,
                                       DarfMutieren = LEZ.DarfMutieren,
                                       Ins          = B.MayInsert,
                                       Upd          = B.MayUpdate,
                                       Del          = B.MayDelete
                                FROM dbo.FaLeistung               LEI WITH (READUNCOMMITTED)
                                  LEFT JOIN dbo.FaLeistungZugriff LEZ WITH (READUNCOMMITTED) ON LEZ.FaLeistungID = LEI.FaLeistungID
                                                                                            AND LEZ.UserID = {0}
                                  LEFT JOIN dbo.XOrgUnit_User     A   WITH (READUNCOMMITTED) ON A.UserID = LEI.UserID       -- OrgUnit of owner
                                                                                            AND A.OrgUnitMemberCode = 2
                                  LEFT JOIN dbo.XOrgUnit_User     B   WITH (READUNCOMMITTED) ON B.OrgUnitID = A.OrgUnitID   -- OrgUnit of user
                                                                                            AND B.UserID = {0}
                                WHERE LEI.FaLeistungID = {1}", Session.User.UserID, faLeistungID);

                            // check rights
                            if (Session.User.IsUserAdmin || (!DBUtil.IsEmpty(qryLeistungZugriff["OwnerID"]) && Session.User.UserID == Convert.ToInt32(qryLeistungZugriff["OwnerID"])))
                            {
                                // no restrictions (let control setup the flags)
                            }
                            else
                            {
                                // is insert restricted?
                                if (!DBUtil.IsEmpty(qryLeistungZugriff["Ins"]) && !Convert.ToBoolean(qryLeistungZugriff["Ins"]))
                                {
                                    kissUserCtrl.ActiveSQLQuery.CanInsert = false;
                                }

                                // is update restricted?
                                if (!DBUtil.IsEmpty(qryLeistungZugriff["Upd"]) && !Convert.ToBoolean(qryLeistungZugriff["Upd"]))
                                {
                                    kissUserCtrl.ActiveSQLQuery.CanUpdate = false;
                                }

                                // is delete restricted?
                                if (!DBUtil.IsEmpty(qryLeistungZugriff["Del"]) && !Convert.ToBoolean(qryLeistungZugriff["Del"]))
                                {
                                    kissUserCtrl.ActiveSQLQuery.CanDelete = false;
                                }

                                // darf mutieren flag
                                if (!DBUtil.IsEmpty(qryLeistungZugriff["DarfMutieren"]) && !Convert.ToBoolean(qryLeistungZugriff["DarfMutieren"]))
                                {
                                    kissUserCtrl.ActiveSQLQuery.CanInsert = false;
                                    kissUserCtrl.ActiveSQLQuery.CanUpdate = false;
                                    kissUserCtrl.ActiveSQLQuery.CanDelete = false;
                                }

                                // if reading is restricted: show it but lock changes
                                if (!userMayReadFall)
                                {
                                    kissUserCtrl.ActiveSQLQuery.CanInsert = false;
                                    kissUserCtrl.ActiveSQLQuery.CanUpdate = false;
                                    kissUserCtrl.ActiveSQLQuery.CanDelete = false;
                                }
                            }

                            #endregion
                        }
                    }

                    #endregion

                    // logging
                    _logger.DebugFormat("ShowDetail='{0}', ForceDispose='{1}'", ctrl, forceDispose);

                    // show control with dispose flag
                    this.ShowDetail(ctrl, forceDispose);

                    // update controls
                    if (ctrl is KissUserControl && ((KissUserControl)ctrl).ActiveSQLQuery != null)
                    {
                        // update fields
                        ((KissUserControl)ctrl).ActiveSQLQuery.EnableBoundFields();
                    }

                    // SPECIAL CONTROL CALLS:
                    switch (classname)
                    {
                        case "CtlGvGesuchverwaltung":
                            AssemblyLoader.InvokeMethode(ctrl, "SetEditMode");
                            break;

                        case "CtlFaIntake":                 // setup required fields for CtlFaIntake
                        case "CtlEdAuswertungsdaten":       // setup required fields for CtlEdAuswertungsdaten
                            // colorize required fields
                            AssemblyLoader.InvokeMethode(ctrl, "SetupColorRequiredFields");
                            AssemblyLoader.InvokeMethode(ctrl, "SetupColorRequiredFields");
                            break;

                        case "CtlFaDokumente":      // reset changed flags due to problem after Init() call
                        case "CtlEdEinsatzvereinbarung":
                        case "CtlBwEinsatzvereinbarung":
                            AssemblyLoader.InvokeMethode(ctrl, "ResetChangedFlags");
                            break;
                    }
                }
                else
                {
                    // remove control and show nothing
                    this.ShowDetail(null);
                }
            }
            catch (Exception ex)
            {
                // logging
                _logger.WarnFormat("Error in AfterFocusNode: '{0}'", ex.Message);

                // error occured, show message
                KissMsg.ShowError("CtlFaModulTree", "ErrorAfterFocusNode", "Fehler bei der Verarbeitung.", "Error in Event: AfterFocusNode - kissTree", ex);

                // remove control and show nothing
                this.ShowDetail(null);

                // logging in table
                XLog.Create(this.GetType().FullName, LogLevel.ERROR, "Error in AfterFocusNode occured.", ex.Message);
            }
            finally
            {
                // reset cursor
                Cursor.Current = current;

                // logging
                _logger.Debug("done");
            }
        }

        private void barManager_Tree_QueryShowPopupMenu(object sender, DevExpress.XtraBars.QueryShowPopupMenuEventArgs e)
        {
            // validate first (can only show menu on valid node and header)
            if (!this.IsValidNode() || !this.IsHeaderNode())
            {
                // do not show popup menu
                e.Cancel = true;
                return;
            }

            // check if user may read fall
            object userMayReadFall = kissTree.FocusedNode.GetValue("UserMayReadFall");

            if (DBUtil.IsEmpty(userMayReadFall) || !Convert.ToBoolean(userMayReadFall))
            {
                // no access or invalid value
                e.Cancel = true;
                return;
            }

            // need to save data before showing menu (due to delete and new entry --> cannot leave node until saved)
            if (this.DetailControl != null)
            {
                try
                {
                    if (!((IKissDataNavigator)DetailControl).SaveData())
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                catch
                {
                    e.Cancel = true;
                    return;
                }
            }

            // hide all items (inherited, too)
            foreach (DevExpress.XtraBars.BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                barItemLink.Item.Visibility = BarItemVisibility.Never;
            }

            // show the items we want
            btnNewIntake.Visibility = BarItemVisibility.Always;
            btnNewSB.Visibility = BarItemVisibility.Always;
            btnNewCM.Visibility = BarItemVisibility.Always;
            btnNewBW.Visibility = BarItemVisibility.Always;
            btnNewED.Visibility = BarItemVisibility.Always;
            btnNewAB.Visibility = BarItemVisibility.Always;
            btnNewWD.Visibility = BarItemVisibility.Always;
            btnDelete.Visibility = BarItemVisibility.Always;

            // no FallZugriff in ALPI
            btnFallZugriff.Visibility = BarItemVisibility.Never;

            // check if user has rights to show FallInfo
            if (DBUtil.UserHasRight("DlgFallInfo"))
            {
                // rights are ok
                btnFallInfoBD.Visibility = BarItemVisibility.Always;
            }

            // check if we have any item visible, otherwise ignore call
            foreach (DevExpress.XtraBars.BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                // if any item is visible, do show popup menu
                if (barItemLink.Item.Visibility != BarItemVisibility.Never)
                {
                    // at least one item is visible
                    return;
                }
            }

            // do not show popup menu
            e.Cancel = true;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // check if we have a valid node
            if (!IsValidNode())
            {
                return;
            }

            // check if node is header node
            if (IsHeaderNode())
            {
                SqlQuery qry;

                // get values
                int faLeistungID = Convert.ToInt32(kissTree.FocusedNode.GetValue("FaLeistungID"));
                string name = kissTree.FocusedNode.GetDisplayText("Name");
                string aufnahme = "??.??.????";
                string AppCode = kissTree.FocusedNode.GetValue("AppCode").ToString();
                int modulID = DBUtil.IsEmpty(kissTree.FocusedNode.GetValue("ModulID")) ? -1 : Convert.ToInt32(kissTree.FocusedNode.GetValue("ModulID"));

                try
                {
                    aufnahme = Convert.ToDateTime(kissTree.FocusedNode.GetValue("Aufnahme")).ToString("dd.MM.yyyy");
                }
                catch
                { }

                // Leistung cannot be closed
                qry = DBUtil.OpenSQL(@"
                    SELECT LEI.DatumBis
                    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                    WHERE LEI.FaLeistungID = {0}", faLeistungID);

                // validate, if we do not find Leistung, we cannot delete values from
                if (qry.Count == 0)
                {
                    return;
                }

                // validate DatumBis
                if (!DBUtil.IsEmpty(qry["DatumBis"]))
                {
                    KissMsg.ShowInfo("CtlFaModulTree", "CannotDeleteAlreadyClosed", "Dieser Eintrag kann nicht gelöscht werden, da er bereits geschlossen ist!");
                    return;
                }

                // check if is Fallverlauf has subitems (use tree, not database)
                if (modulID == 2 && kissTree.FocusedNode.HasChildren)
                {
                    KissMsg.ShowInfo("CtlFaModulTree", "CannotDeleteContainingData", "Dieser Eintrag kann nicht gelöscht werden, da noch Elemente davon abhängig sind!");
                    return;
                }

                // confirm delete
                if (KissMsg.ShowQuestion("CtlFaModulTree", "ConfirmDeleteData", "Sollen alle Daten von '{0} {1}' gelöscht werden?", 0, 0, false, name, aufnahme))
                {
                    // remove data and node
                    DBUtil.ExecSQL(@"
                        DELETE FROM dbo.FaLeistung
                        WHERE FaLeistungID = {0}", faLeistungID);

                    kissTree.DeleteNode(kissTree.FocusedNode);

                    // refresh tree
                    FormController.OpenForm("FrmFall", @"Action", "RefreshTree");
                }
            }
        }

        private void btnFallInfoBD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // open dialog if possible
            FormController.ShowDialogOnMain("DlgFallInfo", this.BaPersonID);
        }

        private void btnNewAB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // new AB
            NeuesModul(BaUtils.ModulID.Assistenzberatung);
        }

        private void btnNewBW_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // new BW
            NeuesModul(BaUtils.ModulID.BegleitetesWohnen);
        }

        private void btnNewCM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // new CM
            NeuesModul(BaUtils.ModulID.CaseManagement);
        }

        private void btnNewED_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // new ED
            NeuesModul(BaUtils.ModulID.EntlastungsDienst);
        }

        private void btnNewIntake_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // new Intake
            NeuesModul(BaUtils.ModulID.Intake);
        }

        private void btnNewSB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // new SB
            NeuesModul(BaUtils.ModulID.SozialBeratung);
        }

        private void btnNewWD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FaUtils.CheckDuplicateEmptyWdExists(BaPersonID))
            {
                // Duplicate empty Wd exists, cancel
                KissMsg.ShowInfo(
                    Name,
                    "DuplicateEmptyWdExists_v01",
                    "Es gibt bereits eine aktive weitere Dienstleistung ohne Angabe der Dienstleistung, daher kann nicht gespeichert werden.");
            }
            else
            {
                //new WD
                NeuesModul(BaUtils.ModulID.WeitereDL);
            }
        }

        private void CtlFaModulTree_Load(object sender, System.EventArgs e)
        {
            // setup icon
            this.btnFallInfoBD.ImageIndex = KissImageList.GetImageIndex(162); // set here the KiSS-IconID

            // show tree but do not select any detail-control
            _isLoading = true;

            // do show tree
            this.DisplayTree(-1);

            _isLoading = false;
        }

        private void kissTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("doRefocusNodeAfterFocusNode='{0}', this.FocusedNode='{1}'", this._doRefocusNodeAfterFocusNode, this.FocusedNode);

            // cancel update if loading
            if (this._isLoading)
            {
                // logging
                _logger.Debug("cancel: isLoading=true");

                // do not continue
                return;
            }

            // check if we have to reselect node
            if (this._doRefocusNodeAfterFocusNode)
            {
                // reset flag (for security)
                this._doRefocusNodeAfterFocusNode = false;

                // check if we have a focusednode
                if (this.FocusedNode != null)
                {
                    try
                    {
                        // logging
                        _logger.Debug("this.FocusedNode != null");

                        // get current value of focused node
                        object currentValue = this.FocusedNode.GetValue(kissTree.KeyFieldName);

                        // check if new node does really exist
                        if (kissTree.FindNodeByKeyID(currentValue) != null)
                        {
                            // set loading flag
                            this._isLoading = true;

                            // logging
                            _logger.Debug("do refresh");

                            // refresh again
                            this.Refresh();

                            // reset flag
                            this._isLoading = false;

                            // logging
                            _logger.Debug("do load current selected node");

                            // load node
                            this.kissTree_AfterFocusNode(sender, new DevExpress.XtraTreeList.NodeEventArgs(kissTree.FocusedNode));
                        }
                    }
                    catch (Exception ex)
                    {
                        // logging
                        _logger.WarnFormat("Error in FocusedNodeChanged: '{0}'", ex.Message);

                        // error occured, show message
                        KissMsg.ShowError("CtlFaModulTree", "ErrorFocusedNodeChanged", "Fehler bei der Verarbeitung.", "Error in Event: FocusedNodeChanged - kissTree", ex);

                        // logging into table
                        XLog.Create(this.GetType().FullName, LogLevel.ERROR, "Error in FocusedNodeChanged.", ex.Message);
                    }
                    finally
                    {
                        // reset loading flag
                        this._isLoading = false;
                    }
                }
            }

            // reset flag anyway
            this._doRefocusNodeAfterFocusNode = false;

            // logging
            _logger.Debug("done");
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Handle messages from FormController
        /// </summary>
        /// <param name="param">Containing all necessary parameters as key/value pairs</param>
        /// <returns>True, if successfully handles message or nothing done, false if something went wrong</returns>
        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "ValidateClosedItems":
                    // check if all items are closed and ask user what to do
                    this.CheckNeedCloseFV();
                    return true;

                case "UpdateFVUserID":
                    // update userid on Fallverlauf depending on open modules
                    Common.PI.FaUtils.UpdateFVResponsibility(this.BaPersonID);
                    return true;
            }

            // did not understand message
            return base.ReceiveMessage(param);
        }

        /// <summary>
        /// Translates this control
        /// </summary>
        public override void Translate()
        {
            // apply translation
            base.Translate();

            // refresh tree if language changed
            if (this._userLang != Session.User.LanguageCode)
            {
                // apply new language
                this._userLang = Session.User.LanguageCode;

                // refresh data
                this.DisplayTree(-1);
            }
        }

        #endregion

        #region Private Methods

        private void CheckNeedCloseFV()
        {
            // need to save data before showing menu (due to delete and new entry --> cannot leave node until saved)
            if (this.DetailControl != null)
            {
                try
                {
                    if (!((IKissDataNavigator)DetailControl).SaveData())
                    {
                        return;
                    }
                }
                catch
                {
                    return;
                }
            }

            // get open Intake / Dienstleistungen and Fallverlauf
            SqlQuery qryOpenItems = DBUtil.OpenSQL(@"
                SELECT CountOpenDLsIntake  = (SELECT COUNT(1)
                                              FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                              WHERE BaPersonID = {0}
                                                AND ModulID IN (3,4,5,6,7,8,31)
                                                AND DatumBis IS NULL),
                       CountOpenFV         = (SELECT COUNT(1)
                                              FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                              WHERE BaPersonID = {0}
                                                AND ModulID = 2
                                                AND DatumBis IS NULL),
                       FaLeistungID        = ISNULL((SELECT TOP 1 FaLeistungID
                                                     FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                                     WHERE BaPersonID = {0}
                                                       AND ModulID = 2
                                                       AND DatumBis IS NULL
                                                     ORDER BY DatumVon DESC, FaLeistungID DESC), -1),
                       FaLeistungDatumVon  = ISNULL((SELECT TOP 1 DatumVon
                                                     FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                                     WHERE BaPersonID = {0}
                                                       AND ModulID = 2
                                                       AND DatumBis IS NULL
                                                     ORDER BY DatumVon DESC, FaLeistungID DESC), GETDATE())", this.BaPersonID);

            int countOpenDLsIntake = Convert.ToInt32(qryOpenItems["CountOpenDLsIntake"]);
            int countOpenFV = Convert.ToInt32(qryOpenItems["CountOpenFV"]);
            int faLeistungIDFVOpen = Convert.ToInt32(qryOpenItems["FaLeistungID"]);
            DateTime faLeistungDatumVonIDFVOpen = Convert.ToDateTime(qryOpenItems["FaLeistungDatumVon"]);

            // TODO: Do user rights as in "Methode: barManager_Tree_QueryShowPopupMenu" for buttons (visible/enabled)

            // check if we have closed all DLs and Intakes without having closed the Fallverlauf
            if (countOpenFV > 0 && countOpenDLsIntake < 1)
            {
                // check if the user wants to close Fallverlauf now
                switch (DlgButtons.ShowButtonDlg(_noMoreOpenDLsIntakeQuestion, new String[] { _newIntakeDlgBtn, _newSBDlgBtn, _newCMDlgBtn, _newBWDlgBtn, _newEDDlgBtn, _newABDlgBtn, _newWDDlgBtn, _closeFVDlgBtn, _cancelDlgBtn }, 7))
                {
                    case 0: // new IN
                        NeuesModul(BaUtils.ModulID.Intake);
                        break;

                    case 1: // new SB
                        NeuesModul(BaUtils.ModulID.SozialBeratung);
                        break;

                    case 2: // new CM
                        NeuesModul(BaUtils.ModulID.CaseManagement);
                        break;

                    case 3: // new BW
                        NeuesModul(BaUtils.ModulID.BegleitetesWohnen);
                        break;

                    case 4: // new ED
                        NeuesModul(BaUtils.ModulID.EntlastungsDienst);
                        break;

                    case 5: // new AB
                        NeuesModul(BaUtils.ModulID.Assistenzberatung);
                        break;

                    case 6: // new WD
                        NeuesModul(BaUtils.ModulID.WeitereDL);
                        break;

                    case 7: // close FV
                        // validate
                        if (faLeistungIDFVOpen < 1)
                        {
                            // invalid id
                            KissMsg.ShowError("CtlFaModulTree", "InvalidLeistungIDToClose", "Die ID des Fallverlaufes konnte nicht richtig ermittelt werden. Bitte schliessen Sie den Fallverlauf manuell.");
                        }
                        else if (faLeistungDatumVonIDFVOpen > DateTime.Now)
                        {
                            // invalid date
                            KissMsg.ShowError("CtlFaModulTree", "InvalidLeistungDateFromToClose", "Das Eröffungsdatum des Fallverlaufes ist grösser als das aktuelle Datum. Bitte schliessen Sie den Fallverlauf manuell.");
                        }
                        else if (!FaUtils.IsFVDateBeforeAfterProcesses(faLeistungIDFVOpen, this.BaPersonID, false, DateTime.Today))
                        {
                            // FV cannot be closed for today's date
                            KissMsg.ShowError("CtlFaModulTree", "InvalidTodaysDateCloseFV", "Der Fallverlauf kann nicht per heutiges Datum geschlossen werden. Bitte schliessen Sie den Fallverlauf manuell.");
                        }
                        else
                        {
                            // confirm close FV
                            if (KissMsg.ShowQuestion("CtlFaModulTree", "ConfirmCloseFV", "Wollen Sie den Fallverlauf wirklich per '{0}' schliessen?", 0, 0, false, DateTime.Now.ToShortDateString()))
                            {
                                // close FV with date today
                                FaUtils.CloseFaLeistungByNow(faLeistungIDFVOpen);

                                // refresh tree
                                FormController.SendMessage("FrmFall", "Action", "RefreshTree");
                            }
                        }

                        // jump to current Fallverlauf (in every case)
                        FormController.SendMessage("FrmFall",
                                                   "Action", "DisplayModul",
                                                   "ModulID", 2);
                        break;
                }
            }
        }

        private void DisplayTree(int newFaLeistungID)
        {
            kissTree.DataSource = null; //sonst Exception: open DataReader!
            FillTree();

            try
            {
                // expand open Leistung and non-Leistung depending items
                foreach (TreeListNode node in kissTree.Nodes)
                {
                    if (DBUtil.IsEmpty(node.GetValue("FaLeistungID")))
                    {
                        // no Leistung, expand anyway
                        node.Expanded = true;
                    }
                    else
                    {
                        // has Leistung, depending on closed state
                        if (DBUtil.IsEmpty(node.GetValue("DatumBis")))
                        {
                            // open, do expand
                            node.Expanded = true;

                            // check if has sub nodes
                            if (node.HasChildren)
                            {
                                // expand child nodes for one level
                                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode nodeChild in node.Nodes)
                                {
                                    // depending on closed state
                                    if (DBUtil.IsEmpty(nodeChild.GetValue("DatumBis")))
                                    {
                                        // open, do expand sub node
                                        nodeChild.Expanded = true;
                                    }
                                    else
                                    {
                                        // closed, do not expand sub node
                                        nodeChild.Expanded = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // closed, do not expand
                            node.Expanded = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // logging
                _logger.Error("Error occured in DisplayTree.", ex);
            }

            // do not expand Sozialsystem
            if (this.kissTree.Nodes.Count > 0)
            {
                this.kissTree.Nodes[0].Expanded = false;
            }

            // Neupositionierung auf neuen Eintrag
            if (newFaLeistungID > 0)
            {
                TreeListNode node = kissTree.FindNodeByKeyID(string.Format("LEI{0}", newFaLeistungID));

                if (node != null)
                {
                    kissTree.FocusedNode = node;
                    node.Expanded = true;
                }
            }
        }

        private bool IsHeaderNode()
        {
            // validate first
            if (!IsValidNode())
            {
                return false;
            }

            //  static programmed modultreeid's from database (also used in CtlFall)
            int modulTreeID = Convert.ToInt32(kissTree.FocusedNode.GetValue("ModulTreeID"));

            return (modulTreeID == 20011 ||     // Fallverlauf
                    modulTreeID == 30000 ||     // SB
                    modulTreeID == 40000 ||     // CM
                    modulTreeID == 50000 ||     // BW
                    modulTreeID == 60000 ||     // ED
                    modulTreeID == 70000 ||     // Intake
                    modulTreeID == 80000 ||     // AB
                    modulTreeID == 310000       // WD
                    );
        }

        private bool IsValidNode()
        {
            return !(kissTree == null || kissTree.FocusedNode == null);
        }

        private void NeuesModul(BaUtils.ModulID modul)
        {
            int modulID = (int)modul;
            // get new id
            var newID = FaUtils.CreateNewProcess(BaPersonID, modulID);

            // check if id is valid
            if (newID < 1)
            {
                // invalid id, do nothing more (message was already shown)
                return;
            }

            // REFRESH TREE
            _isLoading = true;
            FormController.OpenForm("FrmFall", "Action", "RefreshTree");

            // select new item
            DisplayTree(newID);

            // allow loading again
            _isLoading = false;

            // reload item (required to apply new DetailControl)
            kissTree_AfterFocusNode(this, new DevExpress.XtraTreeList.NodeEventArgs(kissTree.FocusedNode));
        }

        #endregion

        #endregion
    }
}