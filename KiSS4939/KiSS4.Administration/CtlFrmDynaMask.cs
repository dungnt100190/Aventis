using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using xRay.Toolkit.Utilities;

namespace KiSS4.Administration
{
    /// <summary>
    /// Summary description for CtlFrmDynaMask.
    /// </summary>
    public class CtlFrmDynaMask : KissUserControl
    {
        private bool AddingField = false;
        private KiSS4.Gui.KissButton btnDown;
        private KiSS4.Gui.KissButton btnUp;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraGrid.Columns.GridColumn colAppCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayText;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDisplayText2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colGridHeight;
        private DevExpress.XtraGrid.Columns.GridColumn colMaskName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaskName2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colParentPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colSystem;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSystem2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTabName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTabNames;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTabPosition;
        private System.ComponentModel.IContainer components;
        private char CurrMode = ' ';

        // M = Masks, F = Fields
        private int CurrPosition = 0;

        private KiSS4.Gui.KissCheckEdit edtActive;
        private KiSS4.Gui.KissTextEdit edtAppCode;
        private KiSS4.Gui.KissTextEdit edtAppCode1;
        private KiSS4.Gui.KissTextEdit edtDefaultValue;
        private KiSS4.Gui.KissTextEdit edtDisplayText;
        private KiSS4.Gui.KissTextEdit edtDisplayText1;
        private KiSS4.Gui.KissLookUpEdit edtFaPhaseCode;
        private KiSS4.Gui.KissLookUpEdit edtFieldCode;
        private KiSS4.Gui.KissTextEdit edtFieldName;
        private KiSS4.Gui.KissCalcEdit edtGridColPosition;
        private KiSS4.Gui.KissComboBox edtGridColTitle;
        private KiSS4.Gui.KissCalcEdit edtGridColWidth;
        private KiSS4.Gui.KissCalcEdit edtHeight;
        private KiSS4.Gui.KissImageComboBoxEdit edtIconID;
        private KiSS4.Gui.KissCalcEdit edtLength;
        private KiSS4.Gui.KissComboBox edtLOVName;
        private KiSS4.Gui.KissCheckEdit edtMandatory;
        private KiSS4.Gui.KissTextEdit edtMaskName;
        private KiSS4.Gui.KissLookUpEdit edtModulID;
        private KiSS4.Gui.KissTextEdit edtParentMaskName;
        private KiSS4.Gui.KissCalcEdit edtParentPosition;
        private KiSS4.Gui.KissMemoEdit edtSQL;
        private KiSS4.Gui.KissCheckEdit edtSystem;
        private KiSS4.Gui.KissComboBox edtTabName;
        private KiSS4.Gui.KissTextEdit edtTabNames;
        private KissCalcEdit edtTabPosition;
        private KiSS4.Gui.KissLookUpEdit edtVmProzessCode;
        private KiSS4.Gui.KissCalcEdit edtWidth;
        private KiSS4.Gui.KissCalcEdit edtX;
        private KiSS4.Gui.KissCalcEdit edtY;
        private bool FillingFieldsTree = false;
        private KissGrid grdControl = null;
        private KiSS4.Gui.KissGrid grdDynaMask;
        private KiSS4.Gui.KissCalcEdit grdGridHeight;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDynaMask;
        private System.Windows.Forms.ImageList imageList;
        private bool InBeforePost = false;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KissLabel lblAppCode;
        private KissLabel lblAppCode1;
        private KissLabel lblDefaultValue;
        private KissLabel lblDisplayText;
        private KissLabel lblDisplayText1;
        private KiSS4.Gui.KissLabel lblFaPhaseCode;
        private KissLabel lblFieldCode;
        private KissLabel lblFieldName;
        private KiSS4.Gui.KissLabel lblGridColPosition;
        private KissLabel lblGridColTitle;
        private KissLabel lblGridColWidth;
        private KiSS4.Gui.KissLabel lblGridHeight;
        private KissLabel lblHeight;
        private KissLabel lblIconID;
        private KissLabel lblLength;
        private KissLabel lblLOVName;
        private KissLabel lblMaskName;
        private KiSS4.Gui.KissLabel lblModulID;
        private KiSS4.Gui.KissLabel lblParentMaskName;
        private KissLabel lblParentPosition;
        private KiSS4.Gui.KissLabel lblSQL;
        private KissLabel lblTabName;
        private KissLabel lblTabNames;
        private KissLabel lblTabPosition;
        private KiSS4.Gui.KissLabel lblVmProzessCode;
        private KissLabel lblWidth;
        private KissLabel lblX;
        private KissLabel lblY;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelControlEdit;
        private System.Windows.Forms.Panel panelFields;
        private System.Windows.Forms.Panel panelMasks;
        private DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository1;
        private KiSS4.DB.SqlQuery qryDynaField;
        private KiSS4.DB.SqlQuery qryDynaMask;
        private KiSS4.DB.SqlQuery qryNewField;
        private KiSS4.DB.SqlQuery qryTree;
        private bool refreshing = false;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private bool Saving = false;
        private KiSS4.Gui.KissSplitter splitterFields;
        private bool TabChanging = false;

        //manually defined private variables
        private KissTabControlEx tabControl = null;

        private bool TabNameChanging = false;
        private bool TabPositionChanged = false;
        private KiSS4.Gui.KissTabControlEx tabTree;
        private SharpLibrary.WinControls.TabPageEx tpgDynaField;
        private SharpLibrary.WinControls.TabPageEx tpgDynaMask;
        private RectTracker Tracker;
        private bool TrackerUpdate = false;
        private KiSS4.Gui.KissTree treDynaField;
        private KiSS4.Gui.KissTree treDynaMask;

        public CtlFrmDynaMask()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>

        public override bool OnAddData()
        {
            SqlQuery qryMaxPos;
            int NewPosition;
            string NewTabname;

            if (DBUtil.IsEmpty(qryTree["MaskName"]))
            {
                return false;
            }

            if (CurrMode == 'M')
            {
                return (qryDynaMask.Insert() != null);
            }

            if (!qryDynaField.Post()) return false;

            qryMaxPos = DBUtil.OpenSQL(string.Format(@"
                SELECT ISNULL(MAX(TabPosition) + 1,1) NewPos
                FROM dbo.DynaField WITH(READUNCOMMITTED)
                WHERE MaskName = {0};", DBUtil.SqlLiteral(qryTree["MaskName"])));

            NewPosition = (int)qryMaxPos["NewPos"];

            NewTabname = "";
            if (tabControl != null) NewTabname = tabControl.SelectedTab.Title;

            qryNewField.Fill("SELECT * FROM dbo.DynaField WITH(READUNCOMMITTED) WHERE 1 = 2;");
            qryNewField.Insert();

            qryNewField["MaskName"] = qryTree["MaskName"];
            qryNewField["TabPosition"] = NewPosition;
            qryNewField["FieldCode"] = 2;
            qryNewField["FieldName"] = "Neu" + NewPosition.ToString();
            qryNewField["X"] = panelFields.Width - 120;
            qryNewField["Y"] = 10;
            qryNewField["Width"] = 80;
            qryNewField["Height"] = 25;
            qryNewField["TabName"] = NewTabname;

            qryNewField.Post();

            AddingField = true;
            DisplayFieldsTree(NewPosition);
            AddingField = false;

            return true;
        }

        public override bool OnDeleteData()
        {
            if (CurrMode == 'M')
            {
                return qryDynaMask.Delete();
            }
            else
            {
                if (!qryDynaField.Delete()) return false;
                if (qryDynaField.Count > 0 && !DBUtil.IsEmpty(qryDynaField["TabPosition"]))
                    DisplayFieldsTree((int)qryDynaField["TabPosition"]);
                else
                    DisplayFieldsTree(-1);
                return true;
            }
        }

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFrmDynaMask));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.persistentRepository1 = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabTree = new KiSS4.Gui.KissTabControlEx();
            this.tpgDynaMask = new SharpLibrary.WinControls.TabPageEx();
            this.treDynaMask = new KiSS4.Gui.KissTree();
            this.colDisplayText2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTabNames = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSystem2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tpgDynaField = new SharpLibrary.WinControls.TabPageEx();
            this.btnUp = new KiSS4.Gui.KissButton();
            this.btnDown = new KiSS4.Gui.KissButton();
            this.treDynaField = new KiSS4.Gui.KissTree();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMaskName2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTabPosition = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTabName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colGridHeight = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.qryDynaField = new KiSS4.DB.SqlQuery(this.components);
            this.splitterFields = new KiSS4.Gui.KissSplitter();
            this.panelMasks = new System.Windows.Forms.Panel();
            this.edtModulID = new KiSS4.Gui.KissLookUpEdit();
            this.qryDynaMask = new KiSS4.DB.SqlQuery(this.components);
            this.lblModulID = new KiSS4.Gui.KissLabel();
            this.edtSystem = new KiSS4.Gui.KissCheckEdit();
            this.edtVmProzessCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtFaPhaseCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblVmProzessCode = new KiSS4.Gui.KissLabel();
            this.lblFaPhaseCode = new KiSS4.Gui.KissLabel();
            this.edtParentMaskName = new KiSS4.Gui.KissTextEdit();
            this.lblParentMaskName = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.grdGridHeight = new KiSS4.Gui.KissCalcEdit();
            this.lblGridHeight = new KiSS4.Gui.KissLabel();
            this.edtIconID = new KiSS4.Gui.KissImageComboBoxEdit();
            this.edtParentPosition = new KiSS4.Gui.KissCalcEdit();
            this.edtActive = new KiSS4.Gui.KissCheckEdit();
            this.lblParentPosition = new KiSS4.Gui.KissLabel();
            this.lblIconID = new KiSS4.Gui.KissLabel();
            this.lblAppCode = new KiSS4.Gui.KissLabel();
            this.lblMaskName = new KiSS4.Gui.KissLabel();
            this.lblDisplayText = new KiSS4.Gui.KissLabel();
            this.lblTabNames = new KiSS4.Gui.KissLabel();
            this.edtMaskName = new KiSS4.Gui.KissTextEdit();
            this.edtAppCode = new KiSS4.Gui.KissTextEdit();
            this.edtDisplayText = new KiSS4.Gui.KissTextEdit();
            this.edtTabNames = new KiSS4.Gui.KissTextEdit();
            this.grdDynaMask = new KiSS4.Gui.KissGrid();
            this.grvDynaMask = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaskName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParentPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSystem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControlEdit = new System.Windows.Forms.Panel();
            this.edtTabPosition = new KiSS4.Gui.KissCalcEdit();
            this.lblTabPosition = new KiSS4.Gui.KissLabel();
            this.edtMandatory = new KiSS4.Gui.KissCheckEdit();
            this.edtSQL = new KiSS4.Gui.KissMemoEdit();
            this.lblSQL = new KiSS4.Gui.KissLabel();
            this.edtGridColPosition = new KiSS4.Gui.KissCalcEdit();
            this.lblGridColPosition = new KiSS4.Gui.KissLabel();
            this.edtGridColWidth = new KiSS4.Gui.KissCalcEdit();
            this.lblGridColWidth = new KiSS4.Gui.KissLabel();
            this.lblDefaultValue = new KiSS4.Gui.KissLabel();
            this.edtDefaultValue = new KiSS4.Gui.KissTextEdit();
            this.edtLength = new KiSS4.Gui.KissCalcEdit();
            this.lblLength = new KiSS4.Gui.KissLabel();
            this.lblLOVName = new KiSS4.Gui.KissLabel();
            this.edtLOVName = new KiSS4.Gui.KissComboBox();
            this.lblGridColTitle = new KiSS4.Gui.KissLabel();
            this.edtGridColTitle = new KiSS4.Gui.KissComboBox();
            this.edtDisplayText1 = new KiSS4.Gui.KissTextEdit();
            this.lblDisplayText1 = new KiSS4.Gui.KissLabel();
            this.lblTabName = new KiSS4.Gui.KissLabel();
            this.lblAppCode1 = new KiSS4.Gui.KissLabel();
            this.edtFieldCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtAppCode1 = new KiSS4.Gui.KissTextEdit();
            this.edtFieldName = new KiSS4.Gui.KissTextEdit();
            this.edtX = new KiSS4.Gui.KissCalcEdit();
            this.edtY = new KiSS4.Gui.KissCalcEdit();
            this.edtHeight = new KiSS4.Gui.KissCalcEdit();
            this.edtWidth = new KiSS4.Gui.KissCalcEdit();
            this.edtTabName = new KiSS4.Gui.KissComboBox();
            this.lblFieldCode = new KiSS4.Gui.KissLabel();
            this.lblY = new KiSS4.Gui.KissLabel();
            this.lblFieldName = new KiSS4.Gui.KissLabel();
            this.lblHeight = new KiSS4.Gui.KissLabel();
            this.lblWidth = new KiSS4.Gui.KissLabel();
            this.lblX = new KiSS4.Gui.KissLabel();
            this.panelFields = new System.Windows.Forms.Panel();
            this.qryNewField = new KiSS4.DB.SqlQuery(this.components);
            this.qryTree = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabTree.SuspendLayout();
            this.tpgDynaMask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treDynaMask)).BeginInit();
            this.tpgDynaField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treDynaField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDynaField)).BeginInit();
            this.panelMasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDynaMask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSystem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmProzessCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmProzessCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaPhaseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaPhaseCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVmProzessCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaPhaseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtParentMaskName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblParentMaskName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGridHeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGridHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIconID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtParentPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblParentPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIconID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAppCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaskName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDisplayText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTabNames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaskName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAppCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDisplayText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTabNames.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDynaMask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDynaMask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.panelControlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTabPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTabPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandatory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSQL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSQL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGridColPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGridColPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGridColWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGridColWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDefaultValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDefaultValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLength.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLOVName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLOVName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGridColTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGridColTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDisplayText1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDisplayText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTabName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAppCode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFieldCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFieldCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAppCode1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFieldName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTabName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFieldCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFieldName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryNewField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTree)).BeginInit();
            this.SuspendLayout();
            //
            // persistentRepository1
            //
            this.persistentRepository1.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemSpinEdit1});
            //
            // repositoryItemTextEdit1
            //
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            //
            // repositoryItemSpinEdit1
            //
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            //
            // panel3
            //
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tabTree);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(270, 626);
            this.panel3.TabIndex = 5;
            //
            // tabTree
            //
            this.tabTree.Controls.Add(this.tpgDynaMask);
            this.tabTree.Controls.Add(this.tpgDynaField);
            this.tabTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTree.Location = new System.Drawing.Point(0, 0);
            this.tabTree.Name = "tabTree";
            this.tabTree.SelectedTabIndex = 1;
            this.tabTree.ShowFixedWidthTooltip = true;
            this.tabTree.Size = new System.Drawing.Size(268, 624);
            this.tabTree.TabIndex = 3;
            this.tabTree.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgDynaMask,
            this.tpgDynaField});
            this.tabTree.TabsLineColor = System.Drawing.Color.Black;
            this.tabTree.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabTree.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabTree_SelectedTabChanging);
            this.tabTree.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabTree_SelectedTabChanged);
            //
            // tpgDynaMask
            //
            this.tpgDynaMask.Controls.Add(this.treDynaMask);
            this.tpgDynaMask.Location = new System.Drawing.Point(6, 6);
            this.tpgDynaMask.Name = "tpgDynaMask";
            this.tpgDynaMask.Size = new System.Drawing.Size(256, 586);
            this.tpgDynaMask.TabIndex = 0;
            this.tpgDynaMask.Title = "Masken";
            //
            // treDynaMask
            //
            this.treDynaMask.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treDynaMask.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treDynaMask.Appearance.Empty.Options.UseBackColor = true;
            this.treDynaMask.Appearance.Empty.Options.UseForeColor = true;
            this.treDynaMask.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treDynaMask.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDynaMask.Appearance.EvenRow.Options.UseBackColor = true;
            this.treDynaMask.Appearance.EvenRow.Options.UseForeColor = true;
            this.treDynaMask.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treDynaMask.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treDynaMask.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treDynaMask.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treDynaMask.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treDynaMask.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treDynaMask.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treDynaMask.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treDynaMask.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDynaMask.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treDynaMask.Appearance.FooterPanel.Options.UseFont = true;
            this.treDynaMask.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treDynaMask.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treDynaMask.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treDynaMask.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDynaMask.Appearance.GroupButton.Options.UseBackColor = true;
            this.treDynaMask.Appearance.GroupButton.Options.UseFont = true;
            this.treDynaMask.Appearance.GroupButton.Options.UseForeColor = true;
            this.treDynaMask.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treDynaMask.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDynaMask.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treDynaMask.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treDynaMask.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treDynaMask.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treDynaMask.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDynaMask.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treDynaMask.Appearance.HeaderPanel.Options.UseFont = true;
            this.treDynaMask.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treDynaMask.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treDynaMask.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treDynaMask.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treDynaMask.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treDynaMask.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treDynaMask.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treDynaMask.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treDynaMask.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treDynaMask.Appearance.HorzLine.Options.UseBackColor = true;
            this.treDynaMask.Appearance.HorzLine.Options.UseForeColor = true;
            this.treDynaMask.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treDynaMask.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treDynaMask.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDynaMask.Appearance.OddRow.Options.UseBackColor = true;
            this.treDynaMask.Appearance.OddRow.Options.UseFont = true;
            this.treDynaMask.Appearance.OddRow.Options.UseForeColor = true;
            this.treDynaMask.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treDynaMask.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treDynaMask.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDynaMask.Appearance.Preview.Options.UseBackColor = true;
            this.treDynaMask.Appearance.Preview.Options.UseFont = true;
            this.treDynaMask.Appearance.Preview.Options.UseForeColor = true;
            this.treDynaMask.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treDynaMask.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treDynaMask.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDynaMask.Appearance.Row.Options.UseBackColor = true;
            this.treDynaMask.Appearance.Row.Options.UseFont = true;
            this.treDynaMask.Appearance.Row.Options.UseForeColor = true;
            this.treDynaMask.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treDynaMask.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treDynaMask.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treDynaMask.Appearance.TreeLine.Options.UseBackColor = true;
            this.treDynaMask.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treDynaMask.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treDynaMask.Appearance.VertLine.Options.UseBackColor = true;
            this.treDynaMask.Appearance.VertLine.Options.UseForeColor = true;
            this.treDynaMask.Appearance.VertLine.Options.UseTextOptions = true;
            this.treDynaMask.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treDynaMask.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDisplayText2,
            this.colTabNames,
            this.colSystem2});
            this.treDynaMask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treDynaMask.ExternalRepository = this.persistentRepository1;
            this.treDynaMask.ImageIndexFieldName = "IconID";
            this.treDynaMask.Location = new System.Drawing.Point(0, 0);
            this.treDynaMask.Name = "treDynaMask";
            this.treDynaMask.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treDynaMask.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treDynaMask.OptionsBehavior.Editable = false;
            this.treDynaMask.OptionsBehavior.KeepSelectedOnClick = false;
            this.treDynaMask.OptionsBehavior.MoveOnEdit = false;
            this.treDynaMask.OptionsBehavior.ShowToolTips = false;
            this.treDynaMask.OptionsBehavior.SmartMouseHover = false;
            this.treDynaMask.OptionsMenu.EnableColumnMenu = false;
            this.treDynaMask.OptionsMenu.EnableFooterMenu = false;
            this.treDynaMask.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treDynaMask.OptionsView.AutoWidth = false;
            this.treDynaMask.OptionsView.EnableAppearanceEvenRow = true;
            this.treDynaMask.OptionsView.EnableAppearanceOddRow = true;
            this.treDynaMask.OptionsView.ShowIndicator = false;
            this.treDynaMask.OptionsView.ShowVertLines = false;
            this.treDynaMask.RootValue = "0";
            this.treDynaMask.SelectImageList = this.imageList;
            this.treDynaMask.Size = new System.Drawing.Size(256, 586);
            this.treDynaMask.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            this.treDynaMask.TabIndex = 3;
            this.treDynaMask.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeMasks_FocusedNodeChanged);
            this.treDynaMask.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.treeMasks_BeforeFocusNode);
            //
            // colDisplayText2
            //
            this.colDisplayText2.Caption = "Maskenbaum";
            this.colDisplayText2.FieldName = "DisplayText";
            this.colDisplayText2.MinWidth = 27;
            this.colDisplayText2.Name = "colDisplayText2";
            this.colDisplayText2.OptionsColumn.AllowMove = false;
            this.colDisplayText2.OptionsColumn.AllowSort = false;
            this.colDisplayText2.OptionsColumn.ShowInCustomizationForm = false;
            this.colDisplayText2.VisibleIndex = 0;
            this.colDisplayText2.Width = 200;
            //
            // colTabNames
            //
            this.colTabNames.Caption = "treeListColumn2";
            this.colTabNames.FieldName = "TabNames";
            this.colTabNames.Name = "colTabNames";
            this.colTabNames.Width = 91;
            //
            // colSystem2
            //
            this.colSystem2.Caption = "treeListColumn1";
            this.colSystem2.FieldName = "System";
            this.colSystem2.Name = "colSystem2";
            this.colSystem2.Width = 91;
            //
            // imageList
            //
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "");
            this.imageList.Images.SetKeyName(4, "");
            this.imageList.Images.SetKeyName(5, "");
            this.imageList.Images.SetKeyName(6, "");
            this.imageList.Images.SetKeyName(7, "");
            this.imageList.Images.SetKeyName(8, "");
            this.imageList.Images.SetKeyName(9, "");
            this.imageList.Images.SetKeyName(10, "");
            this.imageList.Images.SetKeyName(11, "");
            this.imageList.Images.SetKeyName(12, "");
            this.imageList.Images.SetKeyName(13, "");
            this.imageList.Images.SetKeyName(14, "");
            this.imageList.Images.SetKeyName(15, "");
            this.imageList.Images.SetKeyName(16, "");
            this.imageList.Images.SetKeyName(17, "");
            this.imageList.Images.SetKeyName(18, "");
            this.imageList.Images.SetKeyName(19, "");
            this.imageList.Images.SetKeyName(20, "");
            this.imageList.Images.SetKeyName(21, "");
            this.imageList.Images.SetKeyName(22, "");
            this.imageList.Images.SetKeyName(23, "");
            this.imageList.Images.SetKeyName(24, "");
            this.imageList.Images.SetKeyName(25, "");
            this.imageList.Images.SetKeyName(26, "");
            this.imageList.Images.SetKeyName(27, "");
            this.imageList.Images.SetKeyName(28, "");
            this.imageList.Images.SetKeyName(29, "");
            this.imageList.Images.SetKeyName(30, "");
            this.imageList.Images.SetKeyName(31, "");
            this.imageList.Images.SetKeyName(32, "");
            this.imageList.Images.SetKeyName(33, "");
            this.imageList.Images.SetKeyName(34, "");
            this.imageList.Images.SetKeyName(35, "");
            this.imageList.Images.SetKeyName(36, "");
            this.imageList.Images.SetKeyName(37, "");
            this.imageList.Images.SetKeyName(38, "");
            this.imageList.Images.SetKeyName(39, "");
            this.imageList.Images.SetKeyName(40, "");
            this.imageList.Images.SetKeyName(41, "");
            this.imageList.Images.SetKeyName(42, "");
            this.imageList.Images.SetKeyName(43, "");
            this.imageList.Images.SetKeyName(44, "");
            this.imageList.Images.SetKeyName(45, "");
            this.imageList.Images.SetKeyName(46, "");
            this.imageList.Images.SetKeyName(47, "");
            this.imageList.Images.SetKeyName(48, "");
            this.imageList.Images.SetKeyName(49, "");
            this.imageList.Images.SetKeyName(50, "");
            this.imageList.Images.SetKeyName(51, "");
            this.imageList.Images.SetKeyName(52, "");
            this.imageList.Images.SetKeyName(53, "");
            this.imageList.Images.SetKeyName(54, "");
            this.imageList.Images.SetKeyName(55, "");
            this.imageList.Images.SetKeyName(56, "");
            this.imageList.Images.SetKeyName(57, "");
            this.imageList.Images.SetKeyName(58, "");
            this.imageList.Images.SetKeyName(59, "");
            this.imageList.Images.SetKeyName(60, "");
            this.imageList.Images.SetKeyName(61, "");
            this.imageList.Images.SetKeyName(62, "");
            this.imageList.Images.SetKeyName(63, "");
            this.imageList.Images.SetKeyName(64, "");
            this.imageList.Images.SetKeyName(65, "");
            this.imageList.Images.SetKeyName(66, "");
            this.imageList.Images.SetKeyName(67, "");
            this.imageList.Images.SetKeyName(68, "");
            this.imageList.Images.SetKeyName(69, "");
            this.imageList.Images.SetKeyName(70, "");
            this.imageList.Images.SetKeyName(71, "");
            this.imageList.Images.SetKeyName(72, "");
            this.imageList.Images.SetKeyName(73, "");
            this.imageList.Images.SetKeyName(74, "");
            this.imageList.Images.SetKeyName(75, "");
            this.imageList.Images.SetKeyName(76, "");
            this.imageList.Images.SetKeyName(77, "");
            this.imageList.Images.SetKeyName(78, "");
            this.imageList.Images.SetKeyName(79, "");
            this.imageList.Images.SetKeyName(80, "");
            this.imageList.Images.SetKeyName(81, "");
            this.imageList.Images.SetKeyName(82, "");
            this.imageList.Images.SetKeyName(83, "");
            this.imageList.Images.SetKeyName(84, "");
            this.imageList.Images.SetKeyName(85, "");
            this.imageList.Images.SetKeyName(86, "");
            this.imageList.Images.SetKeyName(87, "");
            this.imageList.Images.SetKeyName(88, "");
            this.imageList.Images.SetKeyName(89, "");
            this.imageList.Images.SetKeyName(90, "");
            this.imageList.Images.SetKeyName(91, "");
            this.imageList.Images.SetKeyName(92, "");
            this.imageList.Images.SetKeyName(93, "");
            this.imageList.Images.SetKeyName(94, "");
            this.imageList.Images.SetKeyName(95, "");
            this.imageList.Images.SetKeyName(96, "");
            this.imageList.Images.SetKeyName(97, "");
            this.imageList.Images.SetKeyName(98, "");
            this.imageList.Images.SetKeyName(99, "");
            this.imageList.Images.SetKeyName(100, "");
            this.imageList.Images.SetKeyName(101, "");
            this.imageList.Images.SetKeyName(102, "");
            this.imageList.Images.SetKeyName(103, "");
            this.imageList.Images.SetKeyName(104, "");
            this.imageList.Images.SetKeyName(105, "");
            this.imageList.Images.SetKeyName(106, "");
            this.imageList.Images.SetKeyName(107, "");
            this.imageList.Images.SetKeyName(108, "");
            this.imageList.Images.SetKeyName(109, "");
            this.imageList.Images.SetKeyName(110, "");
            this.imageList.Images.SetKeyName(111, "");
            this.imageList.Images.SetKeyName(112, "");
            this.imageList.Images.SetKeyName(113, "");
            this.imageList.Images.SetKeyName(114, "");
            this.imageList.Images.SetKeyName(115, "");
            this.imageList.Images.SetKeyName(116, "");
            this.imageList.Images.SetKeyName(117, "");
            this.imageList.Images.SetKeyName(118, "");
            this.imageList.Images.SetKeyName(119, "");
            this.imageList.Images.SetKeyName(120, "");
            this.imageList.Images.SetKeyName(121, "");
            this.imageList.Images.SetKeyName(122, "");
            this.imageList.Images.SetKeyName(123, "");
            this.imageList.Images.SetKeyName(124, "");
            this.imageList.Images.SetKeyName(125, "");
            this.imageList.Images.SetKeyName(126, "");
            //
            // tpgDynaField
            //
            this.tpgDynaField.Controls.Add(this.btnUp);
            this.tpgDynaField.Controls.Add(this.btnDown);
            this.tpgDynaField.Controls.Add(this.treDynaField);
            this.tpgDynaField.Location = new System.Drawing.Point(6, 6);
            this.tpgDynaField.Name = "tpgDynaField";
            this.tpgDynaField.Size = new System.Drawing.Size(256, 586);
            this.tpgDynaField.TabIndex = 1;
            this.tpgDynaField.Title = "Felder";
            //
            // btnUp
            //
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.IconID = 16;
            this.btnUp.Location = new System.Drawing.Point(187, 558);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(28, 24);
            this.btnUp.TabIndex = 73;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            //
            // btnDown
            //
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.IconID = 17;
            this.btnDown.Location = new System.Drawing.Point(218, 558);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(28, 24);
            this.btnDown.TabIndex = 74;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            //
            // treDynaField
            //
            this.treDynaField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treDynaField.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treDynaField.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treDynaField.Appearance.Empty.Options.UseBackColor = true;
            this.treDynaField.Appearance.Empty.Options.UseForeColor = true;
            this.treDynaField.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treDynaField.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDynaField.Appearance.EvenRow.Options.UseBackColor = true;
            this.treDynaField.Appearance.EvenRow.Options.UseForeColor = true;
            this.treDynaField.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treDynaField.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treDynaField.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treDynaField.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treDynaField.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treDynaField.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treDynaField.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treDynaField.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treDynaField.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDynaField.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treDynaField.Appearance.FooterPanel.Options.UseFont = true;
            this.treDynaField.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treDynaField.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treDynaField.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treDynaField.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDynaField.Appearance.GroupButton.Options.UseBackColor = true;
            this.treDynaField.Appearance.GroupButton.Options.UseFont = true;
            this.treDynaField.Appearance.GroupButton.Options.UseForeColor = true;
            this.treDynaField.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treDynaField.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDynaField.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treDynaField.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treDynaField.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treDynaField.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treDynaField.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDynaField.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treDynaField.Appearance.HeaderPanel.Options.UseFont = true;
            this.treDynaField.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treDynaField.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treDynaField.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treDynaField.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treDynaField.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treDynaField.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treDynaField.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treDynaField.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treDynaField.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treDynaField.Appearance.HorzLine.Options.UseBackColor = true;
            this.treDynaField.Appearance.HorzLine.Options.UseForeColor = true;
            this.treDynaField.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treDynaField.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treDynaField.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDynaField.Appearance.OddRow.Options.UseBackColor = true;
            this.treDynaField.Appearance.OddRow.Options.UseFont = true;
            this.treDynaField.Appearance.OddRow.Options.UseForeColor = true;
            this.treDynaField.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treDynaField.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treDynaField.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDynaField.Appearance.Preview.Options.UseBackColor = true;
            this.treDynaField.Appearance.Preview.Options.UseFont = true;
            this.treDynaField.Appearance.Preview.Options.UseForeColor = true;
            this.treDynaField.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treDynaField.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treDynaField.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treDynaField.Appearance.Row.Options.UseBackColor = true;
            this.treDynaField.Appearance.Row.Options.UseFont = true;
            this.treDynaField.Appearance.Row.Options.UseForeColor = true;
            this.treDynaField.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treDynaField.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treDynaField.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treDynaField.Appearance.TreeLine.Options.UseBackColor = true;
            this.treDynaField.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treDynaField.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treDynaField.Appearance.VertLine.Options.UseBackColor = true;
            this.treDynaField.Appearance.VertLine.Options.UseForeColor = true;
            this.treDynaField.Appearance.VertLine.Options.UseTextOptions = true;
            this.treDynaField.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treDynaField.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName,
            this.colMaskName2,
            this.colTabPosition,
            this.colTabName,
            this.colGridHeight});
            this.treDynaField.DataSource = this.qryDynaField;
            this.treDynaField.ExternalRepository = this.persistentRepository1;
            this.treDynaField.ImageIndexFieldName = "IconID";
            this.treDynaField.Location = new System.Drawing.Point(0, 0);
            this.treDynaField.Name = "treDynaField";
            this.treDynaField.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treDynaField.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treDynaField.OptionsBehavior.Editable = false;
            this.treDynaField.OptionsBehavior.KeepSelectedOnClick = false;
            this.treDynaField.OptionsBehavior.MoveOnEdit = false;
            this.treDynaField.OptionsBehavior.ShowToolTips = false;
            this.treDynaField.OptionsBehavior.SmartMouseHover = false;
            this.treDynaField.OptionsMenu.EnableColumnMenu = false;
            this.treDynaField.OptionsMenu.EnableFooterMenu = false;
            this.treDynaField.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treDynaField.OptionsView.AutoWidth = false;
            this.treDynaField.OptionsView.EnableAppearanceEvenRow = true;
            this.treDynaField.OptionsView.EnableAppearanceOddRow = true;
            this.treDynaField.OptionsView.ShowIndicator = false;
            this.treDynaField.OptionsView.ShowVertLines = false;
            this.treDynaField.RootValue = "-1";
            this.treDynaField.SelectImageList = this.imageList;
            this.treDynaField.Size = new System.Drawing.Size(256, 555);
            this.treDynaField.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            this.treDynaField.TabIndex = 4;
            this.treDynaField.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.treeFields_BeforeFocusNode);
            //
            // colName
            //
            this.colName.Caption = "Felder";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 27;
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowMove = false;
            this.colName.OptionsColumn.AllowSort = false;
            this.colName.OptionsColumn.ShowInCustomizationForm = false;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 232;
            //
            // colMaskName2
            //
            this.colMaskName2.Caption = "treeListColumn2";
            this.colMaskName2.FieldName = "MaskName";
            this.colMaskName2.Name = "colMaskName2";
            //
            // colTabPosition
            //
            this.colTabPosition.Caption = "treeListColumn2";
            this.colTabPosition.FieldName = "TabPosition";
            this.colTabPosition.Name = "colTabPosition";
            this.colTabPosition.Width = 91;
            //
            // colTabName
            //
            this.colTabName.Caption = "treeListColumn1";
            this.colTabName.FieldName = "TabName";
            this.colTabName.Name = "colTabName";
            this.colTabName.Width = 91;
            //
            // colGridHeight
            //
            this.colGridHeight.Caption = "treeListColumn1";
            this.colGridHeight.FieldName = "GridHeight";
            this.colGridHeight.Name = "colGridHeight";
            //
            // qryDynaField
            //
            this.qryDynaField.CanDelete = true;
            this.qryDynaField.CanInsert = true;
            this.qryDynaField.CanUpdate = true;
            this.qryDynaField.DeleteQuestion = "Soll das aktuelle Feld gelöscht werden ?";
            this.qryDynaField.HostControl = this;
            this.qryDynaField.TableName = "DynaField";
            this.qryDynaField.PostCompleted += new System.EventHandler(this.qryField_PostCompleted);
            this.qryDynaField.BeforePost += new System.EventHandler(this.qryField_BeforePost);
            this.qryDynaField.PositionChanged += new System.EventHandler(this.qryField_PositionChanged);
            this.qryDynaField.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryField_ColumnChanged);
            this.qryDynaField.AfterDelete += new System.EventHandler(this.qryField_AfterDelete);
            //
            // splitterFields
            //
            this.splitterFields.Location = new System.Drawing.Point(270, 0);
            this.splitterFields.Name = "splitterFields";
            this.splitterFields.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitterFields.Size = new System.Drawing.Size(3, 626);
            this.splitterFields.TabIndex = 6;
            this.splitterFields.TabStop = false;
            //
            // panelMasks
            //
            this.panelMasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panelMasks.Controls.Add(this.edtModulID);
            this.panelMasks.Controls.Add(this.lblModulID);
            this.panelMasks.Controls.Add(this.edtSystem);
            this.panelMasks.Controls.Add(this.edtVmProzessCode);
            this.panelMasks.Controls.Add(this.edtFaPhaseCode);
            this.panelMasks.Controls.Add(this.lblVmProzessCode);
            this.panelMasks.Controls.Add(this.lblFaPhaseCode);
            this.panelMasks.Controls.Add(this.edtParentMaskName);
            this.panelMasks.Controls.Add(this.lblParentMaskName);
            this.panelMasks.Controls.Add(this.kissLabel3);
            this.panelMasks.Controls.Add(this.grdGridHeight);
            this.panelMasks.Controls.Add(this.lblGridHeight);
            this.panelMasks.Controls.Add(this.edtIconID);
            this.panelMasks.Controls.Add(this.edtParentPosition);
            this.panelMasks.Controls.Add(this.edtActive);
            this.panelMasks.Controls.Add(this.lblParentPosition);
            this.panelMasks.Controls.Add(this.lblIconID);
            this.panelMasks.Controls.Add(this.lblAppCode);
            this.panelMasks.Controls.Add(this.lblMaskName);
            this.panelMasks.Controls.Add(this.lblDisplayText);
            this.panelMasks.Controls.Add(this.lblTabNames);
            this.panelMasks.Controls.Add(this.edtMaskName);
            this.panelMasks.Controls.Add(this.edtAppCode);
            this.panelMasks.Controls.Add(this.edtDisplayText);
            this.panelMasks.Controls.Add(this.edtTabNames);
            this.panelMasks.Controls.Add(this.grdDynaMask);
            this.panelMasks.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMasks.Location = new System.Drawing.Point(273, 0);
            this.panelMasks.Name = "panelMasks";
            this.panelMasks.Size = new System.Drawing.Size(719, 406);
            this.panelMasks.TabIndex = 9;
            //
            // edtModulID
            //
            this.edtModulID.DataMember = "ModulID";
            this.edtModulID.DataSource = this.qryDynaMask;
            this.edtModulID.Location = new System.Drawing.Point(492, 253);
            this.edtModulID.LOVName = "Modul";
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
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtModulID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtModulID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtModulID.Properties.NullText = "";
            this.edtModulID.Properties.ShowFooter = false;
            this.edtModulID.Properties.ShowHeader = false;
            this.edtModulID.Size = new System.Drawing.Size(210, 24);
            this.edtModulID.TabIndex = 9;
            //
            // qryDynaMask
            //
            this.qryDynaMask.CanDelete = true;
            this.qryDynaMask.CanInsert = true;
            this.qryDynaMask.CanUpdate = true;
            this.qryDynaMask.DeleteQuestion = "Soll die Maske \'[MaskName]\' gelöscht werden ?";
            this.qryDynaMask.HostControl = this;
            this.qryDynaMask.TableName = "DynaMask";
            this.qryDynaMask.BeforeDelete += new System.EventHandler(this.qryDynaMask_BeforeDelete);
            this.qryDynaMask.BeforePost += new System.EventHandler(this.qryDynaMask_BeforePost);
            this.qryDynaMask.AfterInsert += new System.EventHandler(this.qryDynaMask_AfterInsert);
            this.qryDynaMask.BeforeInsert += new System.EventHandler(this.qryDynaMask_BeforeInsert);
            this.qryDynaMask.AfterPost += new System.EventHandler(this.qryDynaMask_AfterPost);
            this.qryDynaMask.AfterDelete += new System.EventHandler(this.qryDynaMask_AfterDelete);
            //
            // lblModulID
            //
            this.lblModulID.ForeColor = System.Drawing.Color.Black;
            this.lblModulID.Location = new System.Drawing.Point(426, 253);
            this.lblModulID.Name = "lblModulID";
            this.lblModulID.Size = new System.Drawing.Size(56, 24);
            this.lblModulID.TabIndex = 48;
            this.lblModulID.Text = "Modul";
            //
            // edtSystem
            //
            this.edtSystem.Cursor = System.Windows.Forms.Cursors.Default;
            this.edtSystem.DataMember = "System";
            this.edtSystem.DataSource = this.qryDynaMask;
            this.edtSystem.Location = new System.Drawing.Point(492, 345);
            this.edtSystem.Name = "edtSystem";
            this.edtSystem.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSystem.Properties.Appearance.Options.UseBackColor = true;
            this.edtSystem.Properties.Caption = "System";
            this.edtSystem.Size = new System.Drawing.Size(62, 19);
            this.edtSystem.TabIndex = 12;
            //
            // edtVmProzessCode
            //
            this.edtVmProzessCode.DataMember = "VmProzessCode";
            this.edtVmProzessCode.DataSource = this.qryDynaMask;
            this.edtVmProzessCode.Location = new System.Drawing.Point(492, 313);
            this.edtVmProzessCode.LOVName = "VmProzess";
            this.edtVmProzessCode.Name = "edtVmProzessCode";
            this.edtVmProzessCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVmProzessCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVmProzessCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVmProzessCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtVmProzessCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVmProzessCode.Properties.Appearance.Options.UseFont = true;
            this.edtVmProzessCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtVmProzessCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtVmProzessCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtVmProzessCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtVmProzessCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtVmProzessCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtVmProzessCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVmProzessCode.Properties.NullText = "";
            this.edtVmProzessCode.Properties.ShowFooter = false;
            this.edtVmProzessCode.Properties.ShowHeader = false;
            this.edtVmProzessCode.Size = new System.Drawing.Size(210, 24);
            this.edtVmProzessCode.TabIndex = 11;
            //
            // edtFaPhaseCode
            //
            this.edtFaPhaseCode.DataMember = "FaPhaseCode";
            this.edtFaPhaseCode.DataSource = this.qryDynaMask;
            this.edtFaPhaseCode.Location = new System.Drawing.Point(492, 283);
            this.edtFaPhaseCode.LOVName = "DynaPhase";
            this.edtFaPhaseCode.Name = "edtFaPhaseCode";
            this.edtFaPhaseCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaPhaseCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaPhaseCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaPhaseCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaPhaseCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaPhaseCode.Properties.Appearance.Options.UseFont = true;
            this.edtFaPhaseCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFaPhaseCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaPhaseCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFaPhaseCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFaPhaseCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtFaPhaseCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtFaPhaseCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaPhaseCode.Properties.NullText = "";
            this.edtFaPhaseCode.Properties.ShowFooter = false;
            this.edtFaPhaseCode.Properties.ShowHeader = false;
            this.edtFaPhaseCode.Size = new System.Drawing.Size(210, 24);
            this.edtFaPhaseCode.TabIndex = 10;
            //
            // lblVmProzessCode
            //
            this.lblVmProzessCode.ForeColor = System.Drawing.Color.Black;
            this.lblVmProzessCode.Location = new System.Drawing.Point(426, 313);
            this.lblVmProzessCode.Name = "lblVmProzessCode";
            this.lblVmProzessCode.Size = new System.Drawing.Size(66, 24);
            this.lblVmProzessCode.TabIndex = 45;
            this.lblVmProzessCode.Text = "VmProzess";
            //
            // lblFaPhaseCode
            //
            this.lblFaPhaseCode.ForeColor = System.Drawing.Color.Black;
            this.lblFaPhaseCode.Location = new System.Drawing.Point(426, 283);
            this.lblFaPhaseCode.Name = "lblFaPhaseCode";
            this.lblFaPhaseCode.Size = new System.Drawing.Size(56, 24);
            this.lblFaPhaseCode.TabIndex = 44;
            this.lblFaPhaseCode.Text = "FaPhase";
            //
            // edtParentMaskName
            //
            this.edtParentMaskName.DataMember = "ParentMaskName";
            this.edtParentMaskName.DataSource = this.qryDynaMask;
            this.edtParentMaskName.Location = new System.Drawing.Point(96, 345);
            this.edtParentMaskName.Name = "edtParentMaskName";
            this.edtParentMaskName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtParentMaskName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtParentMaskName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtParentMaskName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtParentMaskName.Properties.Appearance.Options.UseBackColor = true;
            this.edtParentMaskName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtParentMaskName.Properties.Appearance.Options.UseFont = true;
            this.edtParentMaskName.Properties.Appearance.Options.UseForeColor = true;
            this.edtParentMaskName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtParentMaskName.Size = new System.Drawing.Size(314, 24);
            this.edtParentMaskName.TabIndex = 5;
            //
            // lblParentMaskName
            //
            this.lblParentMaskName.ForeColor = System.Drawing.Color.Black;
            this.lblParentMaskName.Location = new System.Drawing.Point(5, 345);
            this.lblParentMaskName.Name = "lblParentMaskName";
            this.lblParentMaskName.Size = new System.Drawing.Size(77, 24);
            this.lblParentMaskName.TabIndex = 42;
            this.lblParentMaskName.Text = "Maskenname";
            //
            // kissLabel3
            //
            this.kissLabel3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel3.ForeColor = System.Drawing.Color.Black;
            this.kissLabel3.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel3.Location = new System.Drawing.Point(5, 323);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(101, 16);
            this.kissLabel3.TabIndex = 41;
            this.kissLabel3.Text = "Kind von";
            //
            // grdGridHeight
            //
            this.grdGridHeight.DataMember = "GridHeight";
            this.grdGridHeight.DataSource = this.qryDynaMask;
            this.grdGridHeight.Location = new System.Drawing.Point(96, 283);
            this.grdGridHeight.Name = "grdGridHeight";
            this.grdGridHeight.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.grdGridHeight.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.grdGridHeight.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.grdGridHeight.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grdGridHeight.Properties.Appearance.Options.UseBackColor = true;
            this.grdGridHeight.Properties.Appearance.Options.UseBorderColor = true;
            this.grdGridHeight.Properties.Appearance.Options.UseFont = true;
            this.grdGridHeight.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.grdGridHeight.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grdGridHeight.Size = new System.Drawing.Size(42, 24);
            this.grdGridHeight.TabIndex = 4;
            //
            // lblGridHeight
            //
            this.lblGridHeight.ForeColor = System.Drawing.Color.Black;
            this.lblGridHeight.Location = new System.Drawing.Point(5, 283);
            this.lblGridHeight.Name = "lblGridHeight";
            this.lblGridHeight.Size = new System.Drawing.Size(68, 24);
            this.lblGridHeight.TabIndex = 40;
            this.lblGridHeight.Text = "Tabellenhöhe";
            //
            // edtIconID
            //
            this.edtIconID.DataMember = "IconID";
            this.edtIconID.DataSource = this.qryDynaMask;
            this.edtIconID.Location = new System.Drawing.Point(492, 223);
            this.edtIconID.Name = "edtIconID";
            this.edtIconID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIconID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIconID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIconID.Properties.Appearance.Options.UseBackColor = true;
            this.edtIconID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIconID.Properties.Appearance.Options.UseFont = true;
            this.edtIconID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIconID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIconID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIconID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIconID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Tan;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtIconID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtIconID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIconID.Properties.SmallImages = this.imageList;
            this.edtIconID.Size = new System.Drawing.Size(210, 24);
            this.edtIconID.TabIndex = 8;
            //
            // edtParentPosition
            //
            this.edtParentPosition.DataMember = "ParentPosition";
            this.edtParentPosition.DataSource = this.qryDynaMask;
            this.edtParentPosition.Location = new System.Drawing.Point(96, 375);
            this.edtParentPosition.Name = "edtParentPosition";
            this.edtParentPosition.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtParentPosition.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtParentPosition.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtParentPosition.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtParentPosition.Properties.Appearance.Options.UseBackColor = true;
            this.edtParentPosition.Properties.Appearance.Options.UseBorderColor = true;
            this.edtParentPosition.Properties.Appearance.Options.UseFont = true;
            this.edtParentPosition.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtParentPosition.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtParentPosition.Size = new System.Drawing.Size(30, 24);
            this.edtParentPosition.TabIndex = 6;
            //
            // edtActive
            //
            this.edtActive.Cursor = System.Windows.Forms.Cursors.Default;
            this.edtActive.DataMember = "Active";
            this.edtActive.DataSource = this.qryDynaMask;
            this.edtActive.Location = new System.Drawing.Point(572, 345);
            this.edtActive.Name = "edtActive";
            this.edtActive.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtActive.Properties.Appearance.Options.UseBackColor = true;
            this.edtActive.Properties.Caption = "aktiv";
            this.edtActive.Size = new System.Drawing.Size(58, 19);
            this.edtActive.TabIndex = 13;
            //
            // lblParentPosition
            //
            this.lblParentPosition.ForeColor = System.Drawing.Color.Black;
            this.lblParentPosition.Location = new System.Drawing.Point(5, 375);
            this.lblParentPosition.Name = "lblParentPosition";
            this.lblParentPosition.Size = new System.Drawing.Size(42, 24);
            this.lblParentPosition.TabIndex = 38;
            this.lblParentPosition.Text = "Position";
            //
            // lblIconID
            //
            this.lblIconID.ForeColor = System.Drawing.Color.Black;
            this.lblIconID.Location = new System.Drawing.Point(426, 223);
            this.lblIconID.Name = "lblIconID";
            this.lblIconID.Size = new System.Drawing.Size(24, 24);
            this.lblIconID.TabIndex = 37;
            this.lblIconID.Text = "Icon";
            //
            // lblAppCode
            //
            this.lblAppCode.ForeColor = System.Drawing.Color.Black;
            this.lblAppCode.Location = new System.Drawing.Point(426, 193);
            this.lblAppCode.Name = "lblAppCode";
            this.lblAppCode.Size = new System.Drawing.Size(40, 24);
            this.lblAppCode.TabIndex = 36;
            this.lblAppCode.Text = "P-Code";
            //
            // lblMaskName
            //
            this.lblMaskName.ForeColor = System.Drawing.Color.Black;
            this.lblMaskName.Location = new System.Drawing.Point(5, 193);
            this.lblMaskName.Name = "lblMaskName";
            this.lblMaskName.Size = new System.Drawing.Size(82, 24);
            this.lblMaskName.TabIndex = 35;
            this.lblMaskName.Text = "Maskenname";
            //
            // lblDisplayText
            //
            this.lblDisplayText.ForeColor = System.Drawing.Color.Black;
            this.lblDisplayText.Location = new System.Drawing.Point(5, 223);
            this.lblDisplayText.Name = "lblDisplayText";
            this.lblDisplayText.Size = new System.Drawing.Size(66, 24);
            this.lblDisplayText.TabIndex = 34;
            this.lblDisplayText.Text = "Anzeigetext";
            //
            // lblTabNames
            //
            this.lblTabNames.ForeColor = System.Drawing.Color.Black;
            this.lblTabNames.Location = new System.Drawing.Point(5, 253);
            this.lblTabNames.Name = "lblTabNames";
            this.lblTabNames.Size = new System.Drawing.Size(77, 24);
            this.lblTabNames.TabIndex = 33;
            this.lblTabNames.Text = "Registernamen";
            //
            // edtMaskName
            //
            this.edtMaskName.DataMember = "MaskName";
            this.edtMaskName.DataSource = this.qryDynaMask;
            this.edtMaskName.Location = new System.Drawing.Point(96, 193);
            this.edtMaskName.Name = "edtMaskName";
            this.edtMaskName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMaskName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMaskName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMaskName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtMaskName.Properties.Appearance.Options.UseBackColor = true;
            this.edtMaskName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMaskName.Properties.Appearance.Options.UseFont = true;
            this.edtMaskName.Properties.Appearance.Options.UseForeColor = true;
            this.edtMaskName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMaskName.Size = new System.Drawing.Size(314, 24);
            this.edtMaskName.TabIndex = 1;
            //
            // edtAppCode
            //
            this.edtAppCode.DataMember = "AppCode";
            this.edtAppCode.DataSource = this.qryDynaMask;
            this.edtAppCode.Location = new System.Drawing.Point(492, 193);
            this.edtAppCode.Name = "edtAppCode";
            this.edtAppCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAppCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAppCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAppCode.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtAppCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtAppCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAppCode.Properties.Appearance.Options.UseFont = true;
            this.edtAppCode.Properties.Appearance.Options.UseForeColor = true;
            this.edtAppCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAppCode.Size = new System.Drawing.Size(210, 24);
            this.edtAppCode.TabIndex = 7;
            //
            // edtDisplayText
            //
            this.edtDisplayText.DataMember = "DisplayText";
            this.edtDisplayText.DataSource = this.qryDynaMask;
            this.edtDisplayText.Location = new System.Drawing.Point(96, 223);
            this.edtDisplayText.Name = "edtDisplayText";
            this.edtDisplayText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDisplayText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDisplayText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDisplayText.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtDisplayText.Properties.Appearance.Options.UseBackColor = true;
            this.edtDisplayText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDisplayText.Properties.Appearance.Options.UseFont = true;
            this.edtDisplayText.Properties.Appearance.Options.UseForeColor = true;
            this.edtDisplayText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDisplayText.Size = new System.Drawing.Size(314, 24);
            this.edtDisplayText.TabIndex = 2;
            //
            // edtTabNames
            //
            this.edtTabNames.DataMember = "TabNames";
            this.edtTabNames.DataSource = this.qryDynaMask;
            this.edtTabNames.Location = new System.Drawing.Point(96, 253);
            this.edtTabNames.Name = "edtTabNames";
            this.edtTabNames.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTabNames.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTabNames.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTabNames.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtTabNames.Properties.Appearance.Options.UseBackColor = true;
            this.edtTabNames.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTabNames.Properties.Appearance.Options.UseFont = true;
            this.edtTabNames.Properties.Appearance.Options.UseForeColor = true;
            this.edtTabNames.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTabNames.Size = new System.Drawing.Size(314, 24);
            this.edtTabNames.TabIndex = 3;
            //
            // grdDynaMask
            //
            this.grdDynaMask.DataSource = this.qryDynaMask;
            this.grdDynaMask.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDynaMask.EmbeddedNavigator.Name = "";
            this.grdDynaMask.ExternalRepository = this.persistentRepository1;
            this.grdDynaMask.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdDynaMask.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdDynaMask.Location = new System.Drawing.Point(0, 0);
            this.grdDynaMask.MainView = this.grvDynaMask;
            this.grdDynaMask.Name = "grdDynaMask";
            this.grdDynaMask.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdDynaMask.Size = new System.Drawing.Size(719, 176);
            this.grdDynaMask.TabIndex = 0;
            this.grdDynaMask.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDynaMask});
            //
            // grvDynaMask
            //
            this.grvDynaMask.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvDynaMask.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDynaMask.Appearance.Empty.Options.UseBackColor = true;
            this.grvDynaMask.Appearance.Empty.Options.UseFont = true;
            this.grvDynaMask.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvDynaMask.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDynaMask.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvDynaMask.Appearance.EvenRow.Options.UseFont = true;
            this.grvDynaMask.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDynaMask.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDynaMask.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvDynaMask.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDynaMask.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDynaMask.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDynaMask.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDynaMask.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDynaMask.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDynaMask.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDynaMask.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDynaMask.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDynaMask.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDynaMask.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDynaMask.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDynaMask.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDynaMask.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDynaMask.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDynaMask.Appearance.GroupRow.Options.UseFont = true;
            this.grvDynaMask.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDynaMask.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvDynaMask.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvDynaMask.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDynaMask.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDynaMask.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDynaMask.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDynaMask.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvDynaMask.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDynaMask.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDynaMask.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDynaMask.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDynaMask.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDynaMask.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvDynaMask.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDynaMask.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvDynaMask.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDynaMask.Appearance.OddRow.Options.UseBackColor = true;
            this.grvDynaMask.Appearance.OddRow.Options.UseFont = true;
            this.grvDynaMask.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvDynaMask.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDynaMask.Appearance.Row.Options.UseBackColor = true;
            this.grvDynaMask.Appearance.Row.Options.UseFont = true;
            this.grvDynaMask.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvDynaMask.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDynaMask.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvDynaMask.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvDynaMask.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDynaMask.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvDynaMask.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvDynaMask.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDynaMask.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvDynaMask.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaskName,
            this.colDisplayText,
            this.colParentPosition,
            this.colSystem,
            this.colActive,
            this.colAppCode});
            this.grvDynaMask.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvDynaMask.GridControl = this.grdDynaMask;
            this.grvDynaMask.Name = "grvDynaMask";
            this.grvDynaMask.OptionsBehavior.Editable = false;
            this.grvDynaMask.OptionsCustomization.AllowFilter = false;
            this.grvDynaMask.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvDynaMask.OptionsNavigation.AutoFocusNewRow = true;
            this.grvDynaMask.OptionsNavigation.UseTabKey = false;
            this.grvDynaMask.OptionsView.ColumnAutoWidth = false;
            this.grvDynaMask.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDynaMask.OptionsView.ShowGroupPanel = false;
            this.grvDynaMask.OptionsView.ShowIndicator = false;
            //
            // colMaskName
            //
            this.colMaskName.Caption = "Maskenname";
            this.colMaskName.FieldName = "MaskName";
            this.colMaskName.Name = "colMaskName";
            this.colMaskName.Visible = true;
            this.colMaskName.VisibleIndex = 0;
            this.colMaskName.Width = 238;
            //
            // colDisplayText
            //
            this.colDisplayText.Caption = "Anzeigetext";
            this.colDisplayText.FieldName = "DisplayText";
            this.colDisplayText.Name = "colDisplayText";
            this.colDisplayText.Visible = true;
            this.colDisplayText.VisibleIndex = 1;
            this.colDisplayText.Width = 173;
            //
            // colParentPosition
            //
            this.colParentPosition.Caption = "Pos";
            this.colParentPosition.ColumnEdit = this.repositoryItemSpinEdit1;
            this.colParentPosition.DisplayFormat.FormatString = "g";
            this.colParentPosition.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colParentPosition.FieldName = "ParentPosition";
            this.colParentPosition.Name = "colParentPosition";
            this.colParentPosition.Visible = true;
            this.colParentPosition.VisibleIndex = 2;
            this.colParentPosition.Width = 43;
            //
            // colSystem
            //
            this.colSystem.AppearanceHeader.Options.UseTextOptions = true;
            this.colSystem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSystem.Caption = "System";
            this.colSystem.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSystem.FieldName = "System";
            this.colSystem.Name = "colSystem";
            this.colSystem.Visible = true;
            this.colSystem.VisibleIndex = 3;
            this.colSystem.Width = 60;
            //
            // repositoryItemCheckEdit1
            //
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            //
            // colActive
            //
            this.colActive.AppearanceHeader.Options.UseTextOptions = true;
            this.colActive.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colActive.Caption = "Aktiv";
            this.colActive.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colActive.FieldName = "Active";
            this.colActive.Name = "colActive";
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 4;
            this.colActive.Width = 60;
            //
            // colAppCode
            //
            this.colAppCode.Caption = "P-Code";
            this.colAppCode.FieldName = "AppCode";
            this.colAppCode.Name = "colAppCode";
            this.colAppCode.Visible = true;
            this.colAppCode.VisibleIndex = 5;
            this.colAppCode.Width = 125;
            //
            // panelControlEdit
            //
            this.panelControlEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panelControlEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelControlEdit.Controls.Add(this.edtTabPosition);
            this.panelControlEdit.Controls.Add(this.lblTabPosition);
            this.panelControlEdit.Controls.Add(this.edtMandatory);
            this.panelControlEdit.Controls.Add(this.edtSQL);
            this.panelControlEdit.Controls.Add(this.lblSQL);
            this.panelControlEdit.Controls.Add(this.edtGridColPosition);
            this.panelControlEdit.Controls.Add(this.lblGridColPosition);
            this.panelControlEdit.Controls.Add(this.edtGridColWidth);
            this.panelControlEdit.Controls.Add(this.lblGridColWidth);
            this.panelControlEdit.Controls.Add(this.lblDefaultValue);
            this.panelControlEdit.Controls.Add(this.edtDefaultValue);
            this.panelControlEdit.Controls.Add(this.edtLength);
            this.panelControlEdit.Controls.Add(this.lblLength);
            this.panelControlEdit.Controls.Add(this.lblLOVName);
            this.panelControlEdit.Controls.Add(this.edtLOVName);
            this.panelControlEdit.Controls.Add(this.lblGridColTitle);
            this.panelControlEdit.Controls.Add(this.edtGridColTitle);
            this.panelControlEdit.Controls.Add(this.edtDisplayText1);
            this.panelControlEdit.Controls.Add(this.lblDisplayText1);
            this.panelControlEdit.Controls.Add(this.lblTabName);
            this.panelControlEdit.Controls.Add(this.lblAppCode1);
            this.panelControlEdit.Controls.Add(this.edtFieldCode);
            this.panelControlEdit.Controls.Add(this.edtAppCode1);
            this.panelControlEdit.Controls.Add(this.edtFieldName);
            this.panelControlEdit.Controls.Add(this.edtX);
            this.panelControlEdit.Controls.Add(this.edtY);
            this.panelControlEdit.Controls.Add(this.edtHeight);
            this.panelControlEdit.Controls.Add(this.edtWidth);
            this.panelControlEdit.Controls.Add(this.edtTabName);
            this.panelControlEdit.Controls.Add(this.lblFieldCode);
            this.panelControlEdit.Controls.Add(this.lblY);
            this.panelControlEdit.Controls.Add(this.lblFieldName);
            this.panelControlEdit.Controls.Add(this.lblHeight);
            this.panelControlEdit.Controls.Add(this.lblWidth);
            this.panelControlEdit.Controls.Add(this.lblX);
            this.panelControlEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControlEdit.Location = new System.Drawing.Point(273, 485);
            this.panelControlEdit.Name = "panelControlEdit";
            this.panelControlEdit.Size = new System.Drawing.Size(719, 141);
            this.panelControlEdit.TabIndex = 10;
            //
            // edtTabPosition
            //
            this.edtTabPosition.DataMember = "TabPosition";
            this.edtTabPosition.DataSource = this.qryDynaField;
            this.edtTabPosition.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTabPosition.Location = new System.Drawing.Point(336, 71);
            this.edtTabPosition.Name = "edtTabPosition";
            this.edtTabPosition.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTabPosition.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTabPosition.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTabPosition.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTabPosition.Properties.Appearance.Options.UseBackColor = true;
            this.edtTabPosition.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTabPosition.Properties.Appearance.Options.UseFont = true;
            this.edtTabPosition.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTabPosition.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTabPosition.Properties.ReadOnly = true;
            this.edtTabPosition.Size = new System.Drawing.Size(40, 24);
            this.edtTabPosition.TabIndex = 50;
            //
            // lblTabPosition
            //
            this.lblTabPosition.ForeColor = System.Drawing.Color.Black;
            this.lblTabPosition.Location = new System.Drawing.Point(318, 71);
            this.lblTabPosition.Name = "lblTabPosition";
            this.lblTabPosition.Size = new System.Drawing.Size(21, 24);
            this.lblTabPosition.TabIndex = 51;
            this.lblTabPosition.Text = "TP";
            //
            // edtMandatory
            //
            this.edtMandatory.EditValue = false;
            this.edtMandatory.Location = new System.Drawing.Point(262, 101);
            this.edtMandatory.Name = "edtMandatory";
            this.edtMandatory.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtMandatory.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandatory.Properties.Caption = "Mussfeld";
            this.edtMandatory.Size = new System.Drawing.Size(77, 19);
            this.edtMandatory.TabIndex = 7;
            //
            // edtSQL
            //
            this.edtSQL.DataMember = "SQL";
            this.edtSQL.DataSource = this.qryDynaField;
            this.edtSQL.Location = new System.Drawing.Point(661, 100);
            this.edtSQL.Name = "edtSQL";
            this.edtSQL.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSQL.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSQL.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSQL.Properties.Appearance.Options.UseBackColor = true;
            this.edtSQL.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSQL.Properties.Appearance.Options.UseFont = true;
            this.edtSQL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSQL.ProportionalFont = false;
            this.edtSQL.Size = new System.Drawing.Size(50, 24);
            this.edtSQL.TabIndex = 17;
            //
            // lblSQL
            //
            this.lblSQL.ForeColor = System.Drawing.Color.Black;
            this.lblSQL.Location = new System.Drawing.Point(632, 100);
            this.lblSQL.Name = "lblSQL";
            this.lblSQL.Size = new System.Drawing.Size(31, 24);
            this.lblSQL.TabIndex = 49;
            this.lblSQL.Text = "SQL";
            //
            // edtGridColPosition
            //
            this.edtGridColPosition.DataMember = "GridColPosition";
            this.edtGridColPosition.DataSource = this.qryDynaField;
            this.edtGridColPosition.Location = new System.Drawing.Point(680, 40);
            this.edtGridColPosition.Name = "edtGridColPosition";
            this.edtGridColPosition.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGridColPosition.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGridColPosition.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGridColPosition.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGridColPosition.Properties.Appearance.Options.UseBackColor = true;
            this.edtGridColPosition.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGridColPosition.Properties.Appearance.Options.UseFont = true;
            this.edtGridColPosition.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGridColPosition.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGridColPosition.Size = new System.Drawing.Size(30, 24);
            this.edtGridColPosition.TabIndex = 14;
            //
            // lblGridColPosition
            //
            this.lblGridColPosition.ForeColor = System.Drawing.Color.Black;
            this.lblGridColPosition.Location = new System.Drawing.Point(665, 40);
            this.lblGridColPosition.Name = "lblGridColPosition";
            this.lblGridColPosition.Size = new System.Drawing.Size(11, 24);
            this.lblGridColPosition.TabIndex = 47;
            this.lblGridColPosition.Text = "P";
            //
            // edtGridColWidth
            //
            this.edtGridColWidth.DataMember = "GridColWidth";
            this.edtGridColWidth.DataSource = this.qryDynaField;
            this.edtGridColWidth.Location = new System.Drawing.Point(630, 40);
            this.edtGridColWidth.Name = "edtGridColWidth";
            this.edtGridColWidth.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGridColWidth.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGridColWidth.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGridColWidth.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGridColWidth.Properties.Appearance.Options.UseBackColor = true;
            this.edtGridColWidth.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGridColWidth.Properties.Appearance.Options.UseFont = true;
            this.edtGridColWidth.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGridColWidth.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGridColWidth.Size = new System.Drawing.Size(30, 24);
            this.edtGridColWidth.TabIndex = 13;
            //
            // lblGridColWidth
            //
            this.lblGridColWidth.ForeColor = System.Drawing.Color.Black;
            this.lblGridColWidth.Location = new System.Drawing.Point(612, 40);
            this.lblGridColWidth.Name = "lblGridColWidth";
            this.lblGridColWidth.Size = new System.Drawing.Size(11, 24);
            this.lblGridColWidth.TabIndex = 45;
            this.lblGridColWidth.Text = "B";
            //
            // lblDefaultValue
            //
            this.lblDefaultValue.ForeColor = System.Drawing.Color.Black;
            this.lblDefaultValue.Location = new System.Drawing.Point(390, 100);
            this.lblDefaultValue.Name = "lblDefaultValue";
            this.lblDefaultValue.Size = new System.Drawing.Size(55, 24);
            this.lblDefaultValue.TabIndex = 43;
            this.lblDefaultValue.Text = "Vorgabew.";
            //
            // edtDefaultValue
            //
            this.edtDefaultValue.DataMember = "DefaultValue";
            this.edtDefaultValue.DataSource = this.qryDynaField;
            this.edtDefaultValue.Location = new System.Drawing.Point(462, 100);
            this.edtDefaultValue.Name = "edtDefaultValue";
            this.edtDefaultValue.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDefaultValue.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDefaultValue.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDefaultValue.Properties.Appearance.Options.UseBackColor = true;
            this.edtDefaultValue.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDefaultValue.Properties.Appearance.Options.UseFont = true;
            this.edtDefaultValue.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDefaultValue.Size = new System.Drawing.Size(167, 24);
            this.edtDefaultValue.TabIndex = 16;
            //
            // edtLength
            //
            this.edtLength.DataMember = "Length";
            this.edtLength.DataSource = this.qryDynaField;
            this.edtLength.Location = new System.Drawing.Point(264, 70);
            this.edtLength.Name = "edtLength";
            this.edtLength.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtLength.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLength.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLength.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLength.Properties.Appearance.Options.UseBackColor = true;
            this.edtLength.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLength.Properties.Appearance.Options.UseFont = true;
            this.edtLength.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLength.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLength.Size = new System.Drawing.Size(40, 24);
            this.edtLength.TabIndex = 6;
            //
            // lblLength
            //
            this.lblLength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblLength.ForeColor = System.Drawing.Color.Black;
            this.lblLength.Location = new System.Drawing.Point(246, 70);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(10, 24);
            this.lblLength.TabIndex = 41;
            this.lblLength.Text = "L";
            //
            // lblLOVName
            //
            this.lblLOVName.ForeColor = System.Drawing.Color.Black;
            this.lblLOVName.Location = new System.Drawing.Point(5, 100);
            this.lblLOVName.Name = "lblLOVName";
            this.lblLOVName.Size = new System.Drawing.Size(46, 24);
            this.lblLOVName.TabIndex = 38;
            this.lblLOVName.Text = "Wertliste";
            //
            // edtLOVName
            //
            this.edtLOVName.DataMember = "LOVName";
            this.edtLOVName.DataSource = this.qryDynaField;
            this.edtLOVName.Location = new System.Drawing.Point(65, 100);
            this.edtLOVName.Name = "edtLOVName";
            this.edtLOVName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLOVName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLOVName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLOVName.Properties.Appearance.Options.UseBackColor = true;
            this.edtLOVName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLOVName.Properties.Appearance.Options.UseFont = true;
            this.edtLOVName.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtLOVName.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtLOVName.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtLOVName.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtLOVName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtLOVName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtLOVName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLOVName.Size = new System.Drawing.Size(169, 24);
            this.edtLOVName.TabIndex = 3;
            //
            // lblGridColTitle
            //
            this.lblGridColTitle.ForeColor = System.Drawing.Color.Black;
            this.lblGridColTitle.Location = new System.Drawing.Point(390, 40);
            this.lblGridColTitle.Name = "lblGridColTitle";
            this.lblGridColTitle.Size = new System.Drawing.Size(58, 24);
            this.lblGridColTitle.TabIndex = 36;
            this.lblGridColTitle.Text = "Kolonne";
            //
            // edtGridColTitle
            //
            this.edtGridColTitle.DataMember = "GridColTitle";
            this.edtGridColTitle.DataSource = this.qryDynaField;
            this.edtGridColTitle.Location = new System.Drawing.Point(462, 40);
            this.edtGridColTitle.Name = "edtGridColTitle";
            this.edtGridColTitle.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGridColTitle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGridColTitle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGridColTitle.Properties.Appearance.Options.UseBackColor = true;
            this.edtGridColTitle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGridColTitle.Properties.Appearance.Options.UseFont = true;
            this.edtGridColTitle.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGridColTitle.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGridColTitle.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGridColTitle.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGridColTitle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGridColTitle.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGridColTitle.Size = new System.Drawing.Size(145, 24);
            this.edtGridColTitle.TabIndex = 12;
            //
            // edtDisplayText1
            //
            this.edtDisplayText1.DataMember = "DisplayText";
            this.edtDisplayText1.DataSource = this.qryDynaField;
            this.edtDisplayText1.Location = new System.Drawing.Point(65, 70);
            this.edtDisplayText1.Name = "edtDisplayText1";
            this.edtDisplayText1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDisplayText1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDisplayText1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDisplayText1.Properties.Appearance.Options.UseBackColor = true;
            this.edtDisplayText1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDisplayText1.Properties.Appearance.Options.UseFont = true;
            this.edtDisplayText1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDisplayText1.Size = new System.Drawing.Size(170, 24);
            this.edtDisplayText1.TabIndex = 2;
            //
            // lblDisplayText1
            //
            this.lblDisplayText1.ForeColor = System.Drawing.Color.Black;
            this.lblDisplayText1.Location = new System.Drawing.Point(5, 70);
            this.lblDisplayText1.Name = "lblDisplayText1";
            this.lblDisplayText1.Size = new System.Drawing.Size(25, 24);
            this.lblDisplayText1.TabIndex = 35;
            this.lblDisplayText1.Text = "Text";
            //
            // lblTabName
            //
            this.lblTabName.ForeColor = System.Drawing.Color.Black;
            this.lblTabName.Location = new System.Drawing.Point(390, 10);
            this.lblTabName.Name = "lblTabName";
            this.lblTabName.Size = new System.Drawing.Size(58, 24);
            this.lblTabName.TabIndex = 32;
            this.lblTabName.Text = "Register";
            //
            // lblAppCode1
            //
            this.lblAppCode1.ForeColor = System.Drawing.Color.Black;
            this.lblAppCode1.Location = new System.Drawing.Point(390, 70);
            this.lblAppCode1.Name = "lblAppCode1";
            this.lblAppCode1.Size = new System.Drawing.Size(60, 24);
            this.lblAppCode1.TabIndex = 31;
            this.lblAppCode1.Text = "P-Code";
            //
            // edtFieldCode
            //
            this.edtFieldCode.AllowNull = false;
            this.edtFieldCode.DataMember = "FieldCode";
            this.edtFieldCode.DataSource = this.qryDynaField;
            this.edtFieldCode.Location = new System.Drawing.Point(65, 10);
            this.edtFieldCode.LOVName = "EigenesFeld";
            this.edtFieldCode.Name = "edtFieldCode";
            this.edtFieldCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFieldCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFieldCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFieldCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtFieldCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFieldCode.Properties.Appearance.Options.UseFont = true;
            this.edtFieldCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFieldCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFieldCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFieldCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFieldCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtFieldCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtFieldCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFieldCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 170, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtFieldCode.Properties.DisplayMember = "Text";
            this.edtFieldCode.Properties.NullText = "";
            this.edtFieldCode.Properties.PopupWidth = 170;
            this.edtFieldCode.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.edtFieldCode.Properties.ShowFooter = false;
            this.edtFieldCode.Properties.ShowHeader = false;
            this.edtFieldCode.Properties.ValueMember = "Code";
            this.edtFieldCode.Size = new System.Drawing.Size(170, 24);
            this.edtFieldCode.TabIndex = 0;
            this.edtFieldCode.EditValueChanged += new System.EventHandler(this.editFieldCode_EditValueChanged);
            //
            // edtAppCode1
            //
            this.edtAppCode1.DataMember = "AppCode";
            this.edtAppCode1.DataSource = this.qryDynaField;
            this.edtAppCode1.Location = new System.Drawing.Point(462, 70);
            this.edtAppCode1.Name = "edtAppCode1";
            this.edtAppCode1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAppCode1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAppCode1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAppCode1.Properties.Appearance.Options.UseBackColor = true;
            this.edtAppCode1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAppCode1.Properties.Appearance.Options.UseFont = true;
            this.edtAppCode1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAppCode1.Size = new System.Drawing.Size(249, 24);
            this.edtAppCode1.TabIndex = 15;
            //
            // edtFieldName
            //
            this.edtFieldName.DataMember = "FieldName";
            this.edtFieldName.DataSource = this.qryDynaField;
            this.edtFieldName.Location = new System.Drawing.Point(65, 40);
            this.edtFieldName.Name = "edtFieldName";
            this.edtFieldName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFieldName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFieldName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFieldName.Properties.Appearance.Options.UseBackColor = true;
            this.edtFieldName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFieldName.Properties.Appearance.Options.UseFont = true;
            this.edtFieldName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFieldName.Properties.MaxLength = 40;
            this.edtFieldName.Size = new System.Drawing.Size(170, 24);
            this.edtFieldName.TabIndex = 1;
            //
            // edtX
            //
            this.edtX.DataMember = "X";
            this.edtX.DataSource = this.qryDynaField;
            this.edtX.Location = new System.Drawing.Point(264, 10);
            this.edtX.Name = "edtX";
            this.edtX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtX.Properties.Appearance.Options.UseBackColor = true;
            this.edtX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtX.Properties.Appearance.Options.UseFont = true;
            this.edtX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtX.Size = new System.Drawing.Size(40, 24);
            this.edtX.TabIndex = 4;
            //
            // edtY
            //
            this.edtY.DataMember = "Y";
            this.edtY.DataSource = this.qryDynaField;
            this.edtY.Location = new System.Drawing.Point(264, 40);
            this.edtY.Name = "edtY";
            this.edtY.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtY.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtY.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtY.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtY.Properties.Appearance.Options.UseBackColor = true;
            this.edtY.Properties.Appearance.Options.UseBorderColor = true;
            this.edtY.Properties.Appearance.Options.UseFont = true;
            this.edtY.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtY.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtY.Size = new System.Drawing.Size(40, 24);
            this.edtY.TabIndex = 5;
            //
            // edtHeight
            //
            this.edtHeight.DataMember = "Height";
            this.edtHeight.DataSource = this.qryDynaField;
            this.edtHeight.Location = new System.Drawing.Point(336, 40);
            this.edtHeight.Name = "edtHeight";
            this.edtHeight.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtHeight.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHeight.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHeight.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHeight.Properties.Appearance.Options.UseBackColor = true;
            this.edtHeight.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHeight.Properties.Appearance.Options.UseFont = true;
            this.edtHeight.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHeight.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHeight.Size = new System.Drawing.Size(40, 24);
            this.edtHeight.TabIndex = 9;
            //
            // edtWidth
            //
            this.edtWidth.DataMember = "Width";
            this.edtWidth.DataSource = this.qryDynaField;
            this.edtWidth.Location = new System.Drawing.Point(336, 10);
            this.edtWidth.Name = "edtWidth";
            this.edtWidth.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtWidth.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWidth.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWidth.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWidth.Properties.Appearance.Options.UseBackColor = true;
            this.edtWidth.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWidth.Properties.Appearance.Options.UseFont = true;
            this.edtWidth.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWidth.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWidth.Size = new System.Drawing.Size(40, 24);
            this.edtWidth.TabIndex = 8;
            //
            // edtTabName
            //
            this.edtTabName.DataMember = "TabName";
            this.edtTabName.DataSource = this.qryDynaField;
            this.edtTabName.Location = new System.Drawing.Point(462, 10);
            this.edtTabName.Name = "edtTabName";
            this.edtTabName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTabName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTabName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTabName.Properties.Appearance.Options.UseBackColor = true;
            this.edtTabName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTabName.Properties.Appearance.Options.UseFont = true;
            this.edtTabName.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTabName.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTabName.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTabName.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTabName.Properties.AutoComplete = false;
            this.edtTabName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtTabName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtTabName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTabName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.edtTabName.Size = new System.Drawing.Size(249, 24);
            this.edtTabName.TabIndex = 11;
            this.edtTabName.SelectedIndexChanged += new System.EventHandler(this.editTabName_SelectedIndexChanged);
            //
            // lblFieldCode
            //
            this.lblFieldCode.ForeColor = System.Drawing.Color.Black;
            this.lblFieldCode.Location = new System.Drawing.Point(5, 10);
            this.lblFieldCode.Name = "lblFieldCode";
            this.lblFieldCode.Size = new System.Drawing.Size(43, 24);
            this.lblFieldCode.TabIndex = 28;
            this.lblFieldCode.Text = "FeldTyp";
            //
            // lblY
            //
            this.lblY.ForeColor = System.Drawing.Color.Black;
            this.lblY.Location = new System.Drawing.Point(246, 40);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(11, 24);
            this.lblY.TabIndex = 26;
            this.lblY.Text = "Y";
            //
            // lblFieldName
            //
            this.lblFieldName.ForeColor = System.Drawing.Color.Black;
            this.lblFieldName.Location = new System.Drawing.Point(5, 40);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(33, 24);
            this.lblFieldName.TabIndex = 25;
            this.lblFieldName.Text = "Name";
            //
            // lblHeight
            //
            this.lblHeight.ForeColor = System.Drawing.Color.Black;
            this.lblHeight.Location = new System.Drawing.Point(318, 40);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(12, 24);
            this.lblHeight.TabIndex = 24;
            this.lblHeight.Text = "H";
            //
            // lblWidth
            //
            this.lblWidth.ForeColor = System.Drawing.Color.Black;
            this.lblWidth.Location = new System.Drawing.Point(318, 10);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(11, 24);
            this.lblWidth.TabIndex = 20;
            this.lblWidth.Text = "B";
            //
            // lblX
            //
            this.lblX.ForeColor = System.Drawing.Color.Black;
            this.lblX.Location = new System.Drawing.Point(246, 10);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(11, 24);
            this.lblX.TabIndex = 18;
            this.lblX.Text = "X";
            //
            // panelFields
            //
            this.panelFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panelFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFields.Location = new System.Drawing.Point(273, 406);
            this.panelFields.Name = "panelFields";
            this.panelFields.Size = new System.Drawing.Size(719, 79);
            this.panelFields.TabIndex = 11;
            //
            // qryNewField
            //
            this.qryNewField.CanDelete = true;
            this.qryNewField.CanInsert = true;
            this.qryNewField.CanUpdate = true;
            this.qryNewField.DeleteQuestion = "Soll das aktuelle Feld gelöscht werden ?";
            this.qryNewField.HostControl = this;
            this.qryNewField.TableName = "DynaField";
            //
            // qryTree
            //
            this.qryTree.HostControl = this;
            //
            // CtlFrmDynaMask
            //
            this.ClientSize = new System.Drawing.Size(992, 626);
            this.Controls.Add(this.panelFields);
            this.Controls.Add(this.panelControlEdit);
            this.Controls.Add(this.panelMasks);
            this.Controls.Add(this.splitterFields);
            this.Controls.Add(this.panel3);
            this.Name = "CtlFrmDynaMask";
            this.Text = "Eigene Masken";
            this.Load += new System.EventHandler(this.frmDynaMask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabTree.ResumeLayout(false);
            this.tpgDynaMask.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treDynaMask)).EndInit();
            this.tpgDynaField.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treDynaField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDynaField)).EndInit();
            this.panelMasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDynaMask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSystem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmProzessCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmProzessCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaPhaseCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaPhaseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVmProzessCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaPhaseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtParentMaskName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblParentMaskName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGridHeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGridHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIconID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtParentPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblParentPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIconID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAppCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaskName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDisplayText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTabNames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaskName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAppCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDisplayText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTabNames.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDynaMask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDynaMask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.panelControlEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtTabPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTabPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandatory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSQL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSQL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGridColPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGridColPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGridColWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGridColWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDefaultValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDefaultValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLength.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLOVName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLOVName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGridColTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGridColTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDisplayText1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDisplayText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTabName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAppCode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFieldCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFieldCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAppCode1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFieldName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTabName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFieldCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFieldName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryNewField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTree)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private void btnDown_Click(object sender, System.EventArgs e)
        {
            if (qryDynaField.Count == 0 || !qryDynaField.Post()) return;

            //NachPosition bestimmen
            object NachPosition = DBUtil.ExecuteScalarSQL(@"
                select min(TabPosition)
                from   DynaField
                where  MaskName = {0} and
                       TabPosition > {1}",
                qryTree["MaskName"],
                qryDynaField["TabPosition"]);

            if (DBUtil.IsEmpty(NachPosition)) return;

            //tauschen mit Nachposition
            DBUtil.ExecSQL(@"
                update  DynaField
                set		TabPosition = {0}
                where   MaskName = {1} and
                        TabPosition = {2}",
                qryDynaField["TabPosition"],
                qryTree["MaskName"],
                NachPosition);

            qryDynaField["TabPosition"] = NachPosition;
            qryDynaField.Post();
            DisplayFieldsTree((int)NachPosition);
        }

        private void btnUp_Click(object sender, System.EventArgs e)
        {
            if (qryDynaField.Count == 0 && (int)qryDynaField["TabPosition"] == 1 || !qryDynaField.Post()) return;

            //VorPosition bestimmen
            object VorPosition = DBUtil.ExecuteScalarSQL(@"
                select max(TabPosition)
                from   DynaField
                where  MaskName = {0} and
                       TabPosition < {1}",
                qryTree["MaskName"],
                qryDynaField["TabPosition"]);

            if (DBUtil.IsEmpty(VorPosition)) return;

            //tauschen mit Vorposition
            DBUtil.ExecSQL(@"
                update  DynaField
                set		TabPosition = {0}
                where   MaskName = {1} and
                        TabPosition = {2}",
                qryDynaField["TabPosition"],
                qryTree["MaskName"],
                VorPosition);

            qryDynaField["TabPosition"] = VorPosition;
            qryDynaField.Post();
            DisplayFieldsTree((int)VorPosition);
        }

        private void ChangeTab(string TabName)
        {
            if (tabControl == null) return;

            TabChanging = true;
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Title.ToUpper() == TabName.ToUpper())
                {
                    tabControl.SelectedTabIndex = i;
                    TabChanging = false;
                    return;
                }
            }
            // not found: set to first tabpage
            tabControl.SelectedTabIndex = 0;
            TabChanging = false;
        }

        private void Control_Click(object sender, System.EventArgs e)
        {
            int Pos = 0;
            try
            {
                DataRow row = (DataRow)((Control)sender).Tag;
                Pos = (int)row["TabPosition"];
            }
            catch
            {
                return;
            }

            TreeListNode node = DBUtil.FindNodeByValue(treDynaField.Nodes, Pos.ToString(), "TabPosition");
            if (node != null)
            {
                treDynaField.FocusedNode = node;
                panelControlEdit.Visible = true;
            }
        }

        private void DisplayFieldsTree(int FieldPos)
        {
            if (FillingFieldsTree) return;

            bool expanded = false;

            if (FieldPos > 0)
            {
                expanded = treDynaField.FocusedNode.Expanded;
            }

            //retrieve data
            FillingFieldsTree = true;
            treDynaField.DataSource = null;
            qryDynaField.Fill("exec spXGetTreeDynaFields {0}, {1}", qryTree["MaskName"], Session.User.LanguageCode);

            treDynaField.DataSource = qryDynaField;
            treDynaField.ExpandAll();
            FillingFieldsTree = false;

            int IconID = 0;
            try
            {
                IconID = (int)treDynaMask.FocusedNode.GetValue("IconID");
            }
            catch { };

            int GridHeight = 0;
            try
            {
                GridHeight = (int)treDynaMask.FocusedNode.GetValue("GridHeight");
            }
            catch { }

            DynaFactory F = new DynaFactory();
            F.BuildMask(
                qryDynaField.DataTable,
                panelFields,
                qryDynaField["MLText"] as string,
                //treeMasks.FocusedNode.GetValue("DisplayText").ToString(),
                imageList.Images[IconID],
                GridHeight, out grdControl,
                treDynaMask.FocusedNode.GetValue("TabNames").ToString(), out tabControl);

            //Fill editTabName
            edtTabName.Properties.Items.Clear();
            if (tabControl != null)
            {
                edtTabName.Properties.Items.Add("");
                foreach (SharpLibrary.WinControls.TabPageEx tpg in tabControl.TabPages)
                    edtTabName.Properties.Items.Add(tpg.Title);
            }

            // Click Event für jedes MaskField einrichten
            if (tabControl == null)
            {
                foreach (Control ctl in panelFields.Controls)
                    if (ctl.Tag != null)
                        if (ctl is KissRTFEdit)
                            ctl.Enter += new System.EventHandler(Control_Click);
                        else
                            ctl.Click += new System.EventHandler(Control_Click);
            }
            else
            {
                foreach (SharpLibrary.WinControls.TabPageEx TabPage in tabControl.TabPages)
                    foreach (Control ctl in TabPage.Controls)
                        if (ctl is KissRTFEdit)
                            ctl.Enter += new System.EventHandler(Control_Click);
                        else
                            ctl.Click += new System.EventHandler(Control_Click);
            }

            // TabChanged Event für tabControl
            if (tabControl != null)
            {
                tabControl.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(tabControl_SelectedTabChanged);
            }

            if (FieldPos < 0) return;  // no repositioning: leave

            //try to reposition
            if (FieldPos != 0)
            {
                TreeListNode node = DBUtil.FindNodeByValue(treDynaField.Nodes, FieldPos.ToString(), "TabPosition");
                if (node != null)
                {
                    treDynaField.FocusedNode = node;
                    node.Expanded = expanded;
                }
            }

            if (refreshing) return;

            if ((treDynaField.FocusedNode == null) && (treDynaField.Nodes.Count > 0))
            {
                treDynaField.FocusedNode = treDynaField.Nodes[0];
            }
        }

        private void DisplayGridMasks()
        {
            if (refreshing) return;
            if (treDynaMask.FocusedNode == null) return;

            panelMasks.Visible = true;
            panelFields.Visible = false;
            panelControlEdit.Visible = false;

            if (qryTree["ID"].ToString() == "all")
                qryDynaMask.Fill("select * from DynaMask order by MaskName");
            else
                qryDynaMask.Fill(@"
                    select * from DynaMask
                    where ParentMaskName = {0}
                    order by ParentPosition",
                    qryTree["MaskName"]);
        }

        private void DisplayMaskTree()
        {
            string ID = "";
            bool expanded = false;

            if (treDynaMask.FocusedNode != null)
            {
                ID = treDynaMask.FocusedNode.GetValue("MaskName").ToString();
                expanded = treDynaMask.FocusedNode.Expanded;
            }

            //retrieve data and refresh databinding
            treDynaMask.DataSource = null;
            qryTree.Fill(@"
                select ID = MaskName,
                       ParentID = ParentMaskName,
                       MaskName,ParentMaskName,ParentPosition,
                       ModulID,FaPhaseCode,VmProzessCode,DisplayText,
                       IconID,TabNames,GridHeight,System,Active,AppCode
                from   DynaMask
                where  Active = 1
                union
                select 'all',
                       null,
                       'all',null,null,
                       100,null,null,'Alle Masken',
                       93,null,null,convert(bit,1),convert(bit,0),null
                order by ModulID, ParentMaskName, ParentPosition");
            treDynaMask.DataSource = qryTree;

            treDynaMask.ExpandAll();

            //try to reposition
            if (ID != "")
            {
                TreeListNode node = DBUtil.FindNodeByID(treDynaMask.Nodes, ID);
                if (node != null)
                    treDynaMask.FocusedNode = node;
            }

            if (refreshing) return;

            if ((treDynaMask.FocusedNode == null) && (treDynaMask.Nodes.Count > 0))
            {
                treDynaMask.FocusedNode = treDynaMask.Nodes[0];
            }
            DisplayGridMasks();
        }

        private void editDisplayText_EditValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                GetCurrentControl().Text = edtDisplayText1.Text;
            }
            catch { }
        }

        private void editFieldCode_EditValueChanged(object sender, System.EventArgs e)
        {
            if (edtFieldCode.Focused)
            {
                qryDynaField["FieldCode"] = edtFieldCode.EditValue;
            }
        }

        private void editTabName_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (TabNameChanging || AddingField || FillingFieldsTree) return;

            if (edtTabName.Focused && edtTabName.EditValue != qryDynaField["TabName"])
            {
                TabNameChanging = true;
                if (!qryDynaField.Post(false)) return;
                DisplayFieldsTree(CurrPosition);
                TabNameChanging = false;
            }
        }

        private void frmDynaMask_Load(object sender, System.EventArgs e)
        {
            panelMasks.Visible = false;
            panelControlEdit.Visible = false;
            panelFields.Visible = false;

            panelMasks.Dock = DockStyle.Top;
            panelControlEdit.Dock = DockStyle.Bottom;

            tpgDynaField.HideTab = true; // don't show this TabPage in the beginning

            tabTree.SelectedTabIndex = 0;
            tabTree_SelectedTabChanged(null);

            // fill editLOVName
            DataTable dt = DBUtil.OpenSQL("select distinct LOVName from XLOV order by LOVName").DataTable;
            foreach (DataRow row in dt.Rows)
            {
                edtLOVName.Properties.Items.Add(row["LOVName"].ToString());
            }

            // fill editIconID
            for (int i = 1; i < imageList.Images.Count; i++)
            {
                DevExpress.XtraEditors.Controls.ImageComboBoxItem Item = new DevExpress.XtraEditors.Controls.ImageComboBoxItem();
                Item.ImageIndex = i;
                Item.Description = "Icon " + i.ToString();
                Item.Value = i;
                edtIconID.Properties.Items.Add(Item);
            }

            DisplayMaskTree();
        }

        private Control GetCurrentControl()
        {
            int Position;
            try
            {
                Position = (int)treDynaField.FocusedNode.GetValue("TabPosition");
            }
            catch
            {
                return null;
            }

            //find Control in panelFields or tabControl
            if (tabControl == null)
            {
                foreach (Control ctl in panelFields.Controls)
                {
                    if (ctl.Tag != null)
                    {
                        DataRow row = (DataRow)ctl.Tag;
                        if (((int)row["TabPosition"]) == Position)
                        {
                            return ctl;
                        }
                    }
                }
            }
            else
            {
                foreach (SharpLibrary.WinControls.TabPageEx TabPage in tabControl.TabPages)
                {
                    foreach (Control ctl in TabPage.Controls)
                    {
                        if (ctl.Tag != null)
                        {
                            DataRow row = (DataRow)ctl.Tag;
                            if (((int)row["TabPosition"]) == Position)
                            {
                                return ctl;
                            }
                        }
                    }
                }
            }
            return null;
        }

        private void qryDynaMask_AfterDelete(object sender, System.EventArgs e)
        {
            RefreshMasksTree();
        }

        private void qryDynaMask_AfterInsert(object sender, System.EventArgs e)
        {
            qryDynaMask["MaskName"] = qryTree["MaskName"].ToString() + "_";
            qryDynaMask["ParentMaskName"] = qryTree["MaskName"].ToString();
            qryDynaMask["IconID"] = 31;
            qryDynaMask["System"] = 0;
            qryDynaMask["Active"] = 1;
            qryDynaMask["ModulID"] = qryTree["ModulID"];
            qryDynaMask["FaPhaseCode"] = qryTree["FaPhaseCode"];
            qryDynaMask["VmProzessCode"] = qryTree["VmProzessCode"];
            grdDynaMask.Focus();
            edtMaskName.Focus();
        }

        private void qryDynaMask_AfterPost(object sender, System.EventArgs e)
        {
            RefreshMasksTree();
        }

        private void qryDynaMask_BeforeDelete(object sender, System.EventArgs e)
        {
            if (CurrMode == 'M')
            {
                //locate corresponding node in tree
                string MaskName = qryDynaMask["MaskName"].ToString();
                TreeListNode node = DBUtil.FindNodeByID(treDynaMask.Nodes, MaskName);
                if (node == null) return; // not found: Fataler Fehler
                if (node.Nodes.Count > 0)
                {
                    KissMsg.ShowInfo("CtlFrmDynaMask", "UntereintraegeVorhanden", "Es sind noch Untereinträge dieses Knotens vorhanden. Diese müssen zuerst gelöscht werden !");
                    throw new Exception();
                }
            }
        }

        private void qryDynaMask_BeforeInsert(object sender, System.EventArgs e)
        {
            if (qryTree["ID"].ToString() == "all")
                throw new KissInfoException(KissMsg.GetMLMessage("CtlFrmDynaMask", "MaskeAnlegenNichtErlaubt", "Unter 'Alle Masken' kann keine neue Maske angelegt werden!", KissMsgCode.MsgInfo));
        }

        private void qryDynaMask_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtMaskName, lblMaskName.Text);
            DBUtil.CheckNotNullField(edtParentMaskName, lblParentPosition.Text);
        }

        private void qryField_AfterDelete(object sender, System.EventArgs e)
        {
            try
            {
                Control ctl = GetCurrentControl();
                ctl.Parent = null;
                ctl.Dispose();
                Tracker.Enabled = false;
                Tracker.Dispose();
            }
            catch { }
        }

        private void qryField_BeforeDelete(object sender, System.EventArgs e)
        {
            if (treDynaField.FocusedNode == null) throw new KissCancelException();
            if (treDynaField.FocusedNode.GetValue("Type").ToString() == "R") throw new KissCancelException();
            if (CurrPosition == 0) throw new KissCancelException();
        }

        private void qryField_BeforePost(object sender, System.EventArgs e)
        {
            InBeforePost = true;

            if (qryDynaField["FieldName"].ToString() == "")
                qryDynaField["FieldName"] = "-";

            InBeforePost = false;
        }

        private void qryField_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            if (InBeforePost || AddingField) return;

            if (e.Column.ColumnName == "DisplayText" &&
                ((int)qryDynaField["FieldCode"] == 1 ||
                 (int)qryDynaField["FieldCode"] == 7 ||
                 (int)qryDynaField["FieldCode"] == 13 ||
                 (int)qryDynaField["FieldCode"] == 16))  //label,Checkbox,WordBericht,button
            {
                //qryField["Name"] = qryField["DisplayText"];
                qryDynaField["Name"] = qryDynaField["MLText"];
                qryDynaField.RefreshDisplay();
                try
                {
                    GetCurrentControl().Text = edtDisplayText1.Text;
                }
                catch { }
            }

            if (e.Column.ColumnName == "FieldName" && (int)qryDynaField["FieldCode"] != 1)
            {
                qryDynaField["Name"] = qryDynaField["FieldName"];
                qryDynaField.RefreshDisplay();
            }

            if (!TrackerUpdate)
            {
                try
                {
                    if (e.Column.ColumnName == "X")
                    {
                        GetCurrentControl().Left = (int)qryDynaField["X"];
                        ShowTrackRectangle();
                    }

                    if (e.Column.ColumnName == "Y")
                    {
                        GetCurrentControl().Top = (int)qryDynaField["Y"];
                        ShowTrackRectangle();
                    }

                    if (e.Column.ColumnName == "Width")
                    {
                        GetCurrentControl().Width = (int)qryDynaField["Width"];
                        ShowTrackRectangle();
                    }

                    if (e.Column.ColumnName == "Height")
                    {
                        GetCurrentControl().Height = (int)qryDynaField["Height"];
                        ShowTrackRectangle();
                    }

                    if (e.Column.ColumnName == "FieldCode" || e.Column.ColumnName == "AppCode")
                    {
                        DynaFactory F = new DynaFactory();
                        F.RecreateDataField(qryDynaField.Row, GetCurrentControl());
                        GetCurrentControl().Click += new System.EventHandler(Control_Click);
                        ShowTrackRectangle();
                    }
                }
                catch { }
            }
        }

        private void qryField_PositionChanged(object sender, System.EventArgs e)
        {
            CurrPosition = 0;
            if (qryDynaField["Type"].ToString() == "R")
            {
                ChangeTab(qryDynaField["Name"].ToString());
                if (Tracker != null)
                {
                    Tracker.Enabled = false;
                    Tracker.Dispose();
                }
                panelControlEdit.Visible = false;
                return;
            }

            try { CurrPosition = (int)qryDynaField["TabPosition"]; }
            catch { }

            if (CurrPosition == 0)
            {
                // Disable panelControlEdit
                panelControlEdit.Height = 0;
                return;
            }

            ChangeTab(qryDynaField["TabName"].ToString());

            ShowTrackRectangle();

            // Enable panelControlEdit
            /*
                        if ((int)qryField["FieldCode"] == 1)
                            editFieldName.EditMode = EditModeType.ReadOnly;
                        else
                            editFieldName.EditMode = EditModeType.Normal;
            */

            panelControlEdit.Visible = true;
        }

        private void qryField_PostCompleted(object sender, System.EventArgs e)
        {
            if (TabPositionChanged)
                DisplayFieldsTree((int)qryDynaField["TabPosition"]);
        }

        private void RefreshMasksTree()
        {
            if (CurrMode == 'M')
            {
                refreshing = true;
                DisplayMaskTree();
                refreshing = false;
            }
        }

        private void ShowTrackRectangle()
        {
            if (TrackerUpdate) return;

            if (Tracker != null)
            {
                Tracker.Enabled = false;
                Tracker.Dispose();
            }

            Control ctl;
            try
            {
                ctl = GetCurrentControl();
                ctl.BringToFront();
            }
            catch { return; }

            //					   if (Ctrl == null) return;

            if (tabControl == null)
            {
                Tracker = new RectTracker(panelFields, new Rectangle(20, 20, 100, 50));
            }
            else
            {
                Tracker = new RectTracker(tabControl.SelectedTab, new Rectangle(20, 20, 100, 50));
            }

            Tracker.Target = ctl;
            Tracker.TrackByReflection = true;
            Tracker.TrackContinuously = true;
            Tracker.ShowWhileTracking = true;
            Tracker.TrackRectangleChanged += new System.EventHandler(Tracker_Changed);
            Tracker.Enabled = true;

            return;
        }

        private void tabControl_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (TabChanging) return;

            if (tabTree.SelectedTabIndex == 0) return;

            string TabName = tabControl.SelectedTab.Text;

            TreeListNode node = DBUtil.FindNodeByValue(treDynaField.Nodes, TabName, "Name");
            if (node != null)
            {
                TabChanging = true;
                treDynaField.FocusedNode = node;
                TabChanging = false;
                panelControlEdit.Visible = false;
            }
        }

        private void tabTree_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (refreshing) return;
            if (tabTree.SelectedTabIndex == -1) return;

            if (tabTree.SelectedTabIndex == 0)
            {
                CurrMode = 'M';
                ActiveSQLQuery = qryDynaMask;
                panelMasks.Visible = true;
                panelFields.Visible = false;
                panelControlEdit.Visible = false;
            }
            else
            {
                CurrMode = 'F';
                ActiveSQLQuery = qryDynaField;
                CurrPosition = 0;
                panelMasks.Visible = false;
                panelFields.Visible = true;

                Cursor.Current = Cursors.WaitCursor;

                DisplayFieldsTree(CurrPosition);
                Cursor.Current = Cursors.Default;

                try
                {
                    panelControlEdit.Visible = (treDynaField.FocusedNode.GetValue("Type").ToString() == "F");
                }
                catch
                {
                    panelControlEdit.Visible = false;
                }
            }
        }

        private void tabTree_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            //check unsaved data. if unsuccessfull: cancel the change
            e.Cancel = (CurrMode == 'M' && !qryDynaMask.Post()) ||
                (CurrMode == 'F' && !qryDynaField.Post());
        }

        private void Tracker_Changed(object sender, System.EventArgs e)
        {
            TrackerUpdate = true;
            qryDynaField["X"] = ((Control)Tracker.Target).Left;
            qryDynaField["Y"] = ((Control)Tracker.Target).Top;
            qryDynaField["Width"] = ((Control)Tracker.Target).Width;
            qryDynaField["Height"] = ((Control)Tracker.Target).Height;
            qryDynaField.RefreshDisplay();
            TrackerUpdate = false;
        }

        private void treeFields_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            if (FillingFieldsTree) return;
            if (!Saving)
            {
                Saving = true;
                e.CanFocus = OnSaveData();
                Saving = false;
            }
        }

        private void treeMasks_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            if (!Saving)
            {
                Saving = true;
                e.CanFocus = OnSaveData();
                Saving = false;
            }
        }

        private void treeMasks_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (refreshing) return;

            //enable/disable tabPageFields
            tpgDynaField.HideTab = ((bool)treDynaMask.FocusedNode.GetValue("System"));

            DisplayGridMasks();
        }
    }
}