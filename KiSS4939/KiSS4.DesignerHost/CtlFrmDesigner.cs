using System;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.DesignerHost
{
    /// <summary>
    /// Summary description for CtlFrmDesigner.
    /// </summary>
    public class CtlFrmDesigner : KissNavTreeUserControl
    {
        #region Fields

        #region Private Fields

        private const string CLASSNAME = "CtlFrmDesigner";
        private string _className = string.Empty;

        /// <summary>
        /// The instance of CtlTableStructureEditor, stored to access it's table name in case of return to table editor
        /// </summary>
        private CtlTableStructureEditor _ctlTableStructureEditor = null;

        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarButtonItem btnBuild;
        private DevExpress.XtraBars.BarButtonItem btnCompile;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTitle;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraBars.PopupMenu popupTree;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFrmDesigner"/> class.
        /// </summary>
        public CtlFrmDesigner()
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            // fill tree
            qryTree.Fill(@"EXECUTE dbo.spXTreeDesigner {0}", Session.User.UserID);
            this.barManager.SetPopupContextMenu(this.navTree, this.popupTree);
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
            this.colTitle = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.popupTree = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnCompile = new DevExpress.XtraBars.BarButtonItem();
            this.btnBuild = new DevExpress.XtraBars.BarButtonItem();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.navTree)).BeginInit();
            this.panTitel.SuspendLayout();
            this.panTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Size = new System.Drawing.Size(735, 25);
            //
            // navTree
            //
            this.navTree.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.navTree.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.navTree.Appearance.Empty.Options.UseBackColor = true;
            this.navTree.Appearance.Empty.Options.UseForeColor = true;
            this.navTree.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.navTree.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navTree.Appearance.EvenRow.Options.UseBackColor = true;
            this.navTree.Appearance.EvenRow.Options.UseForeColor = true;
            this.navTree.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.navTree.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.navTree.Appearance.FocusedCell.Options.UseBackColor = true;
            this.navTree.Appearance.FocusedCell.Options.UseForeColor = true;
            this.navTree.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.navTree.Appearance.FocusedRow.Options.UseForeColor = true;
            this.navTree.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.navTree.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.navTree.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navTree.Appearance.FooterPanel.Options.UseBackColor = true;
            this.navTree.Appearance.FooterPanel.Options.UseFont = true;
            this.navTree.Appearance.FooterPanel.Options.UseForeColor = true;
            this.navTree.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.navTree.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.navTree.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navTree.Appearance.GroupButton.Options.UseBackColor = true;
            this.navTree.Appearance.GroupButton.Options.UseFont = true;
            this.navTree.Appearance.GroupButton.Options.UseForeColor = true;
            this.navTree.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.navTree.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navTree.Appearance.GroupFooter.Options.UseBackColor = true;
            this.navTree.Appearance.GroupFooter.Options.UseForeColor = true;
            this.navTree.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.navTree.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.navTree.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navTree.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.navTree.Appearance.HeaderPanel.Options.UseFont = true;
            this.navTree.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.navTree.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.navTree.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.navTree.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.navTree.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.navTree.Appearance.HideSelectionRow.Options.UseFont = true;
            this.navTree.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.navTree.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.navTree.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.navTree.Appearance.HorzLine.Options.UseBackColor = true;
            this.navTree.Appearance.HorzLine.Options.UseForeColor = true;
            this.navTree.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.navTree.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.navTree.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navTree.Appearance.OddRow.Options.UseBackColor = true;
            this.navTree.Appearance.OddRow.Options.UseFont = true;
            this.navTree.Appearance.OddRow.Options.UseForeColor = true;
            this.navTree.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.navTree.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.navTree.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navTree.Appearance.Preview.Options.UseBackColor = true;
            this.navTree.Appearance.Preview.Options.UseFont = true;
            this.navTree.Appearance.Preview.Options.UseForeColor = true;
            this.navTree.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.navTree.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.navTree.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navTree.Appearance.Row.Options.UseBackColor = true;
            this.navTree.Appearance.Row.Options.UseFont = true;
            this.navTree.Appearance.Row.Options.UseForeColor = true;
            this.navTree.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.navTree.Appearance.SelectedRow.Options.UseForeColor = true;
            this.navTree.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.navTree.Appearance.TreeLine.Options.UseBackColor = true;
            this.navTree.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.navTree.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.navTree.Appearance.VertLine.Options.UseBackColor = true;
            this.navTree.Appearance.VertLine.Options.UseForeColor = true;
            this.navTree.Appearance.VertLine.Options.UseTextOptions = true;
            this.navTree.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.navTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colTitle});
            this.navTree.MenuManager = this.barManager;
            this.navTree.OptionsBehavior.AutoSelectAllInEditor = false;
            this.navTree.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.navTree.OptionsBehavior.Editable = false;
            this.navTree.OptionsBehavior.KeepSelectedOnClick = false;
            this.navTree.OptionsBehavior.MoveOnEdit = false;
            this.navTree.OptionsMenu.EnableColumnMenu = false;
            this.navTree.OptionsMenu.EnableFooterMenu = false;
            this.navTree.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.navTree.OptionsView.AutoWidth = false;
            this.navTree.OptionsView.EnableAppearanceEvenRow = true;
            this.navTree.OptionsView.EnableAppearanceOddRow = true;
            this.navTree.OptionsView.ShowIndicator = false;
            this.navTree.Size = new System.Drawing.Size(192, 556);
            this.navTree.SizeChanged += new System.EventHandler(this.navTree_SizeChanged);
            //
            // panDetail
            //
            this.panDetail.Size = new System.Drawing.Size(600, 527);
            //
            // panTitel
            //
            this.panTitel.Location = new System.Drawing.Point(200, 0);
            this.panTitel.Size = new System.Drawing.Size(600, 29);
            //
            // panTree
            //
            this.panTree.Size = new System.Drawing.Size(192, 556);
            //
            // colTitle
            //
            this.colTitle.FieldName = "Title";
            this.colTitle.MinWidth = 27;
            this.colTitle.Name = "colTitle";
            this.colTitle.OptionsColumn.AllowSort = false;
            this.colTitle.VisibleIndex = 0;
            this.colTitle.Width = 168;
            //
            // popupTree
            //
            this.popupTree.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCompile),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBuild)});
            this.popupTree.Manager = this.barManager;
            this.popupTree.Name = "popupTree";
            //
            // btnCompile
            //
            this.btnCompile.Caption = "Compile";
            this.btnCompile.Glyph = global::KiSS4.DesignerHost.Properties.Resources.Compile;
            this.btnCompile.Id = 0;
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCompile_ItemClick);
            //
            // btnBuild
            //
            this.btnBuild.Caption = "Build";
            this.btnBuild.Glyph = global::KiSS4.DesignerHost.Properties.Resources.Build;
            this.btnBuild.Id = 1;
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBuild_ItemClick);
            //
            // barManager
            //
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnCompile,
            this.btnBuild});
            this.barManager.MaxItemId = 2;
            this.barManager.QueryShowPopupMenu += new DevExpress.XtraBars.QueryShowPopupMenuEventHandler(this.barManager_QueryShowPopupMenu);
            //
            // CtlFrmDesigner
            //
            this.ClientSize = new System.Drawing.Size(800, 556);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "CtlFrmDesigner";
            this.Text = "Business Designer";
            this.Load += new System.EventHandler(this.CtlFrmDesigner_Load);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.panTree, 0);
            this.Controls.SetChildIndex(this.splitTreeControl, 0);
            this.Controls.SetChildIndex(this.panTitel, 0);
            this.Controls.SetChildIndex(this.panDetail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.navTree)).EndInit();
            this.panTitel.ResumeLayout(false);
            this.panTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
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

        protected override void navTree_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            // set busy cursor
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // first, let base do stuff
                base.navTree_AfterFocusNode(sender, e);

                // get values of current node
                string className = e.Node.GetValue("ClassName").ToString();
                object modulID = e.Node.GetValue("ModulID");

                // load control depending on current classname
                switch (className)
                {
                    case "CtlMenuEditor":
                    case "CtlModul":
                        this.ActivateUserControl((KissUserControl)AssemblyLoader.CreateInstance(className), panDetail, true);
                        break;

                    case "CtlIcon":
                    case "CtlLOV":
                    case "CtlTreeEditor":
                        {
                            KissUserControl ctl;

                            if (DBUtil.IsEmpty(modulID))
                            {
                                ctl = (KissUserControl)AssemblyLoader.CreateInstance(className);
                            }
                            else
                            {
                                ctl = (KissUserControl)AssemblyLoader.CreateInstance(className, Convert.ToInt32(modulID));
                            }

                            this.ActivateUserControl(ctl, panDetail, true);
                        }
                        break;

                    case "CtlClass":
                        {
                            KissUserControl ctl;

                            if (DBUtil.IsEmpty(modulID))
                            {
                                ctl = (KissUserControl)AssemblyLoader.CreateInstance(className);
                            }
                            else
                            {
                                ctl = (KissUserControl)AssemblyLoader.CreateInstance(className, (int)modulID);
                            }

                            this.ActivateUserControl(ctl, panDetail, true);
                            ((CtlClass)ctl).FindClassName(_className);
                        }
                        break;

                    case "CtlDesigner":
                        this._className = e.Node.GetValue("Title") as string;
                        this.ActivateUserControl((KissUserControl)AssemblyLoader.CreateInstance(className, _className), panDetail, true);
                        break;

                    case "CtlDBObject_V":
                    case "CtlDBObject_F":
                    case "CtlDBObject_P":
                        this.ActivateUserControl((KissUserControl)AssemblyLoader.CreateInstance("CtlDBObject", e.Node.GetValue("Title") as string, modulID, className.Substring(12, 1)), panDetail, true);
                        break;

                    case "CtlDBObject":
                    case "CtlLOVCode":
                        this.ActivateUserControl((KissUserControl)AssemblyLoader.CreateInstance(className, e.Node.GetValue("Title") as string), panDetail, true);
                        break;

                    case "CtlTableEditor":
                        // create and show instance of tableeditor
                        CtlTableEditor ctlTableEditor;

                        if (DBUtil.IsEmpty(modulID))
                        {
                            ctlTableEditor = new CtlTableEditor();
                        }
                        else
                        {
                            ctlTableEditor = new CtlTableEditor((int)modulID);
                        }

                        this.ActivateUserControl(ctlTableEditor, panDetail, true);

                        // try to reselect used table in tablestructureeditor
                        if (_ctlTableStructureEditor != null)
                        {
                            ctlTableEditor.SelectTable(_ctlTableStructureEditor.CurrentTableName);
                        }
                        break;

                    case "CtlTableStructureEditor":
                        if (_ctlTableStructureEditor == null)
                        {
                            _ctlTableStructureEditor = new CtlTableStructureEditor();
                        }
                        _ctlTableStructureEditor.CurrentTableName = e.Node.GetValue("Title").ToString();
                        this.ActivateUserControl(_ctlTableStructureEditor, panDetail);

                        // rename label properly
                        this.lblTitle.Text = KissMsg.GetMLMessage("FrmTableEditor", "ColumnsOfTable", "Felder der Tabelle '{0}'", KissMsgCode.Text, _ctlTableStructureEditor.CurrentTableName);
                        break;

                    default:
                        // reset control-panle
                        ResetDetailPanel();
                        break;
                }
            }
            catch (Exception ex)
            {
                // show message
                KissMsg.ShowError(CLASSNAME, "ErrorInAfterFocusNode", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);

                // reset control-panle
                ResetDetailPanel();
            }
            finally
            {
                // reset cursor
                this.Cursor = Cursors.Default;
            }
        }

        private void barManager_QueryShowPopupMenu(object sender, DevExpress.XtraBars.QueryShowPopupMenuEventArgs e)
        {
            // check if user has rights to show popup-menu
            if (!Session.User.IsUserBIAGAdmin)
            {
                // no rights, only biag-admin can view popup-menu
                e.Cancel = true;

                // done
                return;
            }

            // hide all items by default
            foreach (DevExpress.XtraBars.BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                barItemLink.Item.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            switch (navTree.FocusedNode.GetValue("ClassName").ToString())
            {
                case "CtlClass":
                case "CtlDesigner":
                    this.btnCompile.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    this.btnBuild.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    break;
            }

            foreach (DevExpress.XtraBars.BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                if (barItemLink.Item.Visibility != DevExpress.XtraBars.BarItemVisibility.Never)
                {
                    return;
                }
            }

            e.Cancel = true;
        }

        private void btnBuild_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DlgProgressLog.Show(KissMsg.GetMLMessage(CLASSNAME, "Build", "Fortschritt: Build"),
                                new ProgressEventHandler(StartBuild),
                                new ProgressEventHandler(EndCompile),
                                Session.MainForm);
        }

        private void btnCompile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DlgProgressLog.Show(KissMsg.GetMLMessage(CLASSNAME, "Compile", "Fortschritt: Compile"),
                                new ProgressEventHandler(StartCompile),
                                new ProgressEventHandler(EndCompile),
                                Session.MainForm);
        }

        private void CtlFrmDesigner_Load(object sender, System.EventArgs e)
        {
            // check if we have any nodes
            if (this.navTree.Nodes.Count > 1)
            {
                this.navTree.Nodes[0].Expanded = true;
                this.navTree.Nodes[1].Expanded = true;
            }
        }

        private void navTree_SizeChanged(object sender, System.EventArgs e)
        {
            this.colTitle.Width = this.navTree.Size.Width - 24;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnRefreshData()
        {
            // refresh tree using default formcontroller (qryTree.Refresh() will not work)
            FormController.SendMessage(typeof(FrmDesigner).Name, "Action", "RefreshTree");
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary parameters)
        {
            // we need at least one parameter to know what to do
            if (parameters == null || parameters.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            switch (parameters["Action"] as string)
            {
                case "OpenChildColumnEditor":
                    // Go from CtlTableEditor to CtlTableStructureEditor of selected table

                    // validate first
                    if (navTree.FocusedNode != null)
                    {
                        // try to find the node of the desired column
                        DevExpress.XtraTreeList.Nodes.TreeListNode node = navTree.FindNodeByKeyID(string.Format("{0}/{1}", navTree.FocusedNode.GetValue("ID"), parameters["TableName"] as string));

                        if (node != null)
                        {
                            navTree.SetFocusedNode(node);
                            return true;
                        }
                    }

                    return false;

                case "OpenParentTableEditor":
                    // Go back from CtlTableStructureEditor to CtlTableEditor

                    // validate parent node of current to be the table editor
                    if (navTree.FocusedNode != null && navTree.FocusedNode.ParentNode != null && navTree.FocusedNode.ParentNode.GetValue("ClassName").ToString().Equals("CtlTableEditor"))
                    {
                        navTree.SetFocusedNode(navTree.FocusedNode.ParentNode);
                        return true;
                    }

                    return false;

                case "OpenChildDesigner":
                    // Go from CtlClass to CtlDesigner of selected table

                    // validate first
                    if (navTree.FocusedNode != null)
                    {
                        // try to find the node of the desired column
                        DevExpress.XtraTreeList.Nodes.TreeListNode node = navTree.FindNodeByKeyID(string.Format("{0}/{1}", navTree.FocusedNode.GetValue("ID"), Convert.ToString(parameters["ClassName"])));

                        if (node != null)
                        {
                            navTree.SetFocusedNode(node);
                            return true;
                        }
                    }

                    return false;

                case "OpenChildLOV":
                    // Go from CtlLOV to CtlLOVCode of selected LOV

                    // validate first
                    if (navTree.FocusedNode != null)
                    {
                        // try to find the node of the desired column
                        DevExpress.XtraTreeList.Nodes.TreeListNode node = navTree.FindNodeByKeyID(string.Format("{0}/{1}", navTree.FocusedNode.GetValue("ID"), Convert.ToString(parameters["LOVName"])));

                        if (node != null)
                        {
                            navTree.SetFocusedNode(node);
                            return true;
                        }
                    }

                    return false;
            }

            return base.ReceiveMessage(parameters);
        }

        #endregion

        #region Private Methods

        private void Build(bool reBuild)
        {
            AssemblyLoader.LoadProgramAssembly();

            SqlQuery qryXClass_Build = DBUtil.OpenSQL(string.Format(CtlDesignerLayout.SelectClassReference, @"--SQLCHECK_IGNORE--
                INSERT INTO @XClass (ClassName)
                  SELECT ClassName
                  FROM dbo.XClass CLS
                  WHERE CLS.Designer > 0 AND
                        CLS.ModulID = ISNULL({0}, CLS.ModulID) AND
                        ({1} = 'CtlClass' OR CLS.ClassName = {2})"), navTree.FocusedNode.GetValue("ModulID"),
                                                                     navTree.FocusedNode.GetValue("ClassName"),
                                                                     navTree.FocusedNode.GetValue("Title"));

            qryXClass_Build.TableName = "XClass";
            qryXClass_Build.CanUpdate = true;

            try
            {
                while (qryXClass_Build.Count > 0)
                {
                    if (Convert.ToInt32(qryXClass_Build["DesignerCode"]) == 1 && (reBuild || DBUtil.IsEmpty(qryXClass_Build["CodeGenerated"])))
                    {
                        using (CtlDesignerLayout ctlDesignerLayout = new CtlDesignerLayout(qryXClass_Build))
                        {
                            ctlDesignerLayout.Build(false);
                        }
                    }
                    else if (!DBUtil.IsEmpty(qryXClass_Build["CodeGenerated"]))
                    {
                        CtlDesignerLayout.Build(qryXClass_Build);
                    }

                    if (!qryXClass_Build.Next())
                    {
                        break;
                    }
                }

                DlgProgressLog.AddLine(KissMsg.GetMLMessage(CLASSNAME, "BuildComplete", "Build abgeschlossen"));
            }
            catch (CancelledByUserException)
            {
                try
                {
                    DlgProgressLog.AddLine(KissMsg.GetMLMessage(CLASSNAME, "BuildAbgebrochen", "Build abgebrochen durch Benutzer/-in"));
                }
                catch { };
            }
            finally
            {
                Cursor.Current = Cursors.Default;

                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
            }
        }

        private void EndCompile()
        {
            if (this.DetailControl is CtlClass)
            {
                ((IKissDataNavigator)this.DetailControl).RefreshData();
            }
        }

        private void ResetDetailPanel()
        {
            this.picTitle.Image = null;
            this.lblTitle.Visible = false;
            this.ActivateUserControl(null, this.panDetail);
        }

        private void StartBuild()
        {
            Build(true);
        }

        private void StartCompile()
        {
            Build(false);
        }

        #endregion

        #endregion
    }
}