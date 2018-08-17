using System;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

using DevExpress.XtraBars;
using Kiss.Interfaces.UI;

namespace KiSS4.Basis.PI
{
    public class CtlBaModulTree : KiSS4.Common.KissModulTree
    {
        #region Fields

        #region Private Fields

        private bool _isFallTraeger;
        private int _userLang = Session.User.LanguageCode;
        private DevExpress.XtraBars.BarButtonItem btnNeuePerson;
        private DevExpress.XtraBars.BarButtonItem btnPersonEntfernen;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAlter;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTitel;

        #endregion

        #endregion

        #region Constructors

        public CtlBaModulTree(Int32 baPersonID, System.Windows.Forms.Panel panelDetail)
            : base(baPersonID, -1, panelDetail, 1)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // fill data
            this.FillTree();
        }

        public CtlBaModulTree()
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
            this.btnNeuePerson = new DevExpress.XtraBars.BarButtonItem();
            this.btnPersonEntfernen = new DevExpress.XtraBars.BarButtonItem();
            this.colAlter = new DevExpress.XtraTreeList.Columns.TreeListColumn();
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
                        this.colAlter});
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
            this.kissTree.Size = new System.Drawing.Size(265, 453);
            this.kissTree.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            //
            // qryModulTree
            //
            this.qryModulTree.SelectStatement = "EXECUTE dbo.spXGetModulTree {0}, {1}, {2}, {3}";
            //
            // popup_Tree
            //
            this.popup_Tree.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnNeuePerson),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnPersonEntfernen, true)});
            //
            // barManager_Tree
            //
            this.barManager_Tree.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                        this.btnNeuePerson,
                        this.btnPersonEntfernen});
            this.barManager_Tree.QueryShowPopupMenu += new DevExpress.XtraBars.QueryShowPopupMenuEventHandler(this.barManager_Tree_QueryShowPopupMenu);
            //
            // btnFallZugriff
            //
            this.btnFallZugriff.CategoryGuid = new System.Guid("f96a77cc-41a0-4295-8f5a-5c2410a21ef7");
            //
            // btnFallInfo
            //
            this.btnFallInfo.CategoryGuid = new System.Guid("f96a77cc-41a0-4295-8f5a-5c2410a21ef7");
            //
            // btnNeuePerson
            //
            this.btnNeuePerson.Caption = "Neue Person ...";
            this.btnNeuePerson.Id = 3;
            this.btnNeuePerson.ImageIndex = 1;
            this.btnNeuePerson.Name = "btnNeuePerson";
            this.btnNeuePerson.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeuePerson_ItemClick);
            //
            // btnPersonEntfernen
            //
            this.btnPersonEntfernen.Caption = "Person entfernen";
            this.btnPersonEntfernen.Id = 4;
            this.btnPersonEntfernen.ImageIndex = 4;
            this.btnPersonEntfernen.Name = "btnPersonEntfernen";
            this.btnPersonEntfernen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnPersonEntfernen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPersonEntfernen_ItemClick);
            //
            // colAlter
            //
            this.colAlter.Caption = "Alter";
            this.colAlter.FieldName = "Age";
            this.colAlter.Name = "colAlter";
            this.colAlter.OptionsColumn.AllowSort = false;
            this.colAlter.VisibleIndex = 1;
            this.colAlter.Width = 38;
            //
            // colTitel
            //
            this.colTitel.Caption = "Person";
            this.colTitel.FieldName = "Name";
            this.colTitel.Name = "colTitel";
            this.colTitel.OptionsColumn.AllowSort = false;
            this.colTitel.VisibleIndex = 0;
            this.colTitel.Width = 230;
            //
            // CtlBaModulTree
            //
            this.Name = "CtlBaModulTree";
            this.Size = new System.Drawing.Size(265, 453);
            this.Load += new System.EventHandler(this.CtlBaModulTree_Load);
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
            // get current cursor
            Cursor currentCursor = Cursor.Current;

            try
            {
                if (e == null || e.Node == null)
                {
                    ShowDetail(null);
                }

                Cursor.Current = Cursors.WaitCursor;
                IKissView ctl = null;

                Int32 personID = e.Node.GetValue("BaPersonID") is Int32 ? Convert.ToInt32(e.Node.GetValue("BaPersonID")) : -1;
                _isFallTraeger = (personID == this.BaPersonID);
                String name = Convert.ToString(e.Node.GetValue("Name"));

                ctl = _showDetail.GetDetailControl(AssemblyLoader.GetType(Convert.ToString(e.Node.GetValue("ClassName"))), true);

                if (ctl == null)
                {
                    //MessageBox.Show("No control found for: "+e.Node.GetValue("ClassName") as string);
                    this.ShowDetail(ctl);
                    return;
                }

                switch (Convert.ToString(e.Node.GetValue("ClassName")))
                {
                    case "CtlBaKlientensystem":
                        // Init(string titleName, Image titleImage, int baPersonID)
                        AssemblyLoader.InvokeMethode(ctl, "Init", name, this.GetIcon(e), personID);
                        break;

                    case "CtlBaStammdaten":
                        // Init(string titleName, Image titleImage, int baPersonID, int mainBaPersonID)
                        AssemblyLoader.InvokeMethode(ctl, "Init", "", this.GetIcon(e), personID, this.BaPersonID);
                        break;

                    case "CtlBaInstitutionenFachpersonen":
                        // Init(string titleName, Image titleImage, int baPersonID)
                        AssemblyLoader.InvokeMethode(ctl, "Init", name, this.GetIcon(e), personID);
                        break;

                    default:
                        // show error when not found
                        KissMsg.ShowError("CtlBaModulTree", "ControlNotHandled", "Die gewählte Maske wurde nicht initialisiert. Es fehlt ein Eintrag in 'CtlBaModulTree'");
                        break;
                }

                // show control
                this.ShowDetail(ctl);

                // setup required fields for CtlBaStammdaten
                if (ctl is CtlBaStammdaten)
                {
                    // setup foreigner mode and colorize required fields
                    AssemblyLoader.InvokeMethode(ctl, "SetupForeignerMode");
                }
            }
            finally
            {
                // reset cursor
                Cursor.Current = currentCursor;
            }
        }

        private void CtlBaModulTree_Load(object sender, System.EventArgs e)
        {
            this.ExpandFirstNode();
        }

        private void barManager_Tree_QueryShowPopupMenu(object sender, DevExpress.XtraBars.QueryShowPopupMenuEventArgs e)
        {
            // hide all items (inherited, too)
            foreach (DevExpress.XtraBars.BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                barItemLink.Item.Visibility = BarItemVisibility.Never;
            }

            // check if user can add a new person
            if (DBUtil.UserHasRight("DlgNeuePerson"))
            {
                btnNeuePerson.Visibility = BarItemVisibility.Always;
            }

            // check if user can delete an existing person reference
            if (kissTree.FocusedNode != null &&
                typeof(CtlBaStammdaten).Name.Equals(kissTree.FocusedNode.GetValue("ClassName")) &&
                Convert.ToInt32(kissTree.FocusedNode.GetValue("BaPersonID")) != this.BaPersonID && // Fallträger selbst kann nicht entfernt werden
                DBUtil.UserHasRight("BaNavigRemovePerson"))
            {
                btnPersonEntfernen.Caption = KissMsg.GetMLMessage("CtlBaModulTree", "RemoveExistingPerson", "Person '{0}' entfernen", KissMsgCode.Text, kissTree.FocusedNode.GetDisplayText("Name"));
                btnPersonEntfernen.Visibility = BarItemVisibility.Always;
            }

            // check if we have any item visible, otherwise ignore call
            foreach (DevExpress.XtraBars.BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                if (barItemLink.Item.Visibility != BarItemVisibility.Never)
                {
                    return;
                }
            }

            e.Cancel = true;
        }

        private void btnNeuePerson_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DlgNeuePerson dlg = new DlgNeuePerson(this.BaPersonID);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int baPersonID = dlg.NewBaPersonID;
                dlg.Dispose();

                //refresh Navigator und Neupositionierung auf neuen Fall
                kissTree.DataSource = null; //sonst Exception: open DataReader!
                this.FillTree();

                DevExpress.XtraTreeList.Nodes.TreeListNode node = DBUtil.FindNodeByValue(kissTree.Nodes, baPersonID.ToString(), "BaPersonID");

                if (node != null)
                {
                    kissTree.FocusedNode = node;
                    node.Expanded = true;
                }
            }
        }

        private void btnPersonEntfernen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!KissMsg.ShowQuestion("CtlBaModulTree", "BeziehungLoeschen", "Soll '{0}' entfernt werden ?\r\n\r\n(Die Personendaten werden dadurch nicht gelöscht, sondern nur die Beziehung zur Fallträgerin.)", 0, 0, true, kissTree.FocusedNode.GetDisplayText("Name")))
            {
                return;
            }

            if (DBUtil.ExecSQL(@"
                DELETE dbo.BaPerson_Relation
                WHERE (BaPersonID_1 = {0} AND BaPersonID_2 = {1}) OR
                      (BaPersonID_1 = {1} AND BaPersonID_2 = {0})", this.BaPersonID, kissTree.FocusedNode.GetValue("BaPersonID")) > 0)
            {
                kissTree.DeleteNode(kissTree.FocusedNode);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void ExpandFirstNode()
        {
            if (this.kissTree.Nodes.Count > 1)
            {
                this.kissTree.Nodes[1].Expanded = true;
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            this.ExpandFirstNode();
        }

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
                this.FillTree();
                this.Refresh();
            }
        }

        #endregion

        #endregion
    }
}