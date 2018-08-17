using System;
using System.Drawing;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis
{
    public class CtlBaModulTree : KiSS4.Common.KissModulTree
    {
        #region Fields

        #region Private Fields

        private DevExpress.XtraBars.BarButtonItem btnNeuePerson;
        private DevExpress.XtraBars.BarButtonItem btnPersonEntfernen;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAge;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBaPersonID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colType;
        private Boolean doRefocusNodeAfterFocusNode = false; // flag for hack where in detailcontrol a refreshtree-call is and user clicks without saving another node

        //private DevExpress.XtraBars.BarButtonItem btnNeuePerson;
        //private DevExpress.XtraBars.BarButtonItem btnPersonEntfernen;
        private bool isFallTraeger;

        private Boolean isLoading = false;

        #endregion

        #endregion

        #region Constructors

        public CtlBaModulTree(int baPersonID, System.Windows.Forms.Panel panDetail)
            : base(baPersonID, panDetail, Gui.ModulID.B)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            this.popup_Tree.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.btnNeuePerson),
                new DevExpress.XtraBars.LinkPersistInfo(this.btnPersonEntfernen)});
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
            this.colAge = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colBaPersonID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
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
            this.kissTree.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
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
            this.kissTree.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
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
            this.kissTree.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.kissTree.Appearance.TreeLine.Options.UseBackColor = true;
            this.kissTree.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.kissTree.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.kissTree.Appearance.VertLine.Options.UseBackColor = true;
            this.kissTree.Appearance.VertLine.Options.UseForeColor = true;
            this.kissTree.Appearance.VertLine.Options.UseTextOptions = true;
            this.kissTree.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.kissTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName,
            this.colAge,
            this.colType,
            this.colBaPersonID});
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
            this.kissTree.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            this.kissTree.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.kissTree_FocusedNodeChanged);
            //
            // barManager_Tree
            //
            this.barManager_Tree.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNeuePerson,
            this.btnPersonEntfernen});
            this.barManager_Tree.MaxItemId = 5;
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
            this.btnNeuePerson.CategoryGuid = new System.Guid("0f795ded-2e11-4c92-bea2-30872f94ba04");
            this.btnNeuePerson.Id = 3;
            this.btnNeuePerson.ImageIndex = 133;
            this.btnNeuePerson.Name = "btnNeuePerson";
            this.btnNeuePerson.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeuePerson_ItemClick);
            //
            // btnPersonEntfernen
            //
            this.btnPersonEntfernen.Caption = "Person entfernen";
            this.btnPersonEntfernen.CategoryGuid = new System.Guid("0f795ded-2e11-4c92-bea2-30872f94ba04");
            this.btnPersonEntfernen.Id = 4;
            this.btnPersonEntfernen.ImageIndex = 4;
            this.btnPersonEntfernen.Name = "btnPersonEntfernen";
            this.btnPersonEntfernen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPersonEntfernen_ItemClick);
            //
            // colAge
            //
            this.colAge.Caption = "Alter";
            this.colAge.FieldName = "Age";
            this.colAge.Name = "colAge";
            this.colAge.OptionsColumn.AllowSort = false;
            this.colAge.VisibleIndex = 1;
            this.colAge.Width = 35;
            //
            // colBaPersonID
            //
            this.colBaPersonID.FieldName = "BaPersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.OptionsColumn.AllowSort = false;
            this.colBaPersonID.VisibleIndex = 3;
            //
            // colName
            //
            this.colName.Caption = "Basis";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowSort = false;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 175;
            //
            // colType
            //
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.OptionsColumn.AllowSort = false;
            this.colType.VisibleIndex = 2;
            //
            // CtlBaModulTree
            //
            this.Name = "CtlBaModulTree";
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
            if (this.isLoading || e == null || e.Node == null)
            {
                ShowDetail(null);
                return;
            }

            // HACK: SELECTION PROBLEM WHEN REFRESHING TREE AND NODE CHANGEING
            // check if focused node does really exist
            DevExpress.XtraTreeList.Nodes.TreeListNode currentNode = kissTree.FindNodeByKeyID(e.Node.GetValue(kissTree.KeyFieldName));

            // check if same with current node
            if (currentNode != null && e.Node != currentNode)
            {
                // set flag
                this.doRefocusNodeAfterFocusNode = true;

                // cancel
                return;
            }

            // reset flag
            this.doRefocusNodeAfterFocusNode = false;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string className = e.Node.GetValue("ClassName") as string;
                Image imgIcon = this.GetIcon(e);
                string titel = e.Node.GetValue("Name") as string;
                IKissView ctl = null;

                //
                int PersonID = (int)e.Node.GetValue("BaPersonID");
                isFallTraeger = (PersonID == this.BaPersonID);

                // Neue WPF Masken (XAML)
                var faLeistungID = e.Node.GetValue("FaLeistungID");
                var baPersonID = e.Node.GetValue("BaPersonID");
                var initParams = new InitParameters
                {
                    BaPersonID = baPersonID as int?,
                    FaLeistungID = faLeistungID as int?,
                    Title = titel,
                };
                var xclassID = Kiss.Infrastructure.IoC.Container.Resolve<ViewFactory>().GetClassID(className);
                if (xclassID.HasValue)
                {
                    var view = new CtlWpfHost(xclassID.Value, initParams);
                    ShowDetail(view, true);
                    return;
                }

                ctl = _showDetail.GetDetailControl(AssemblyLoader.GetType(className, null), true);
                if (ctl == null)
                {
                    ShowDetail(ctl);
                    return;
                }

                switch (className)
                {
                    case "CtlBaHaushalt":
                        AssemblyLoader.InvokeMethode(ctl, "Init", "", this.GetIcon(e), PersonID, this, isFallTraeger);
                        break;

                    case "CtlBaDemographie":
                    case "Kiss.UI.View.Ba.BaPersonCompositeView":
                    case "CtlBaPerson":
                        AssemblyLoader.InvokeMethode(ctl, "Init", "", this.GetIcon(e), PersonID, this.BaPersonID, isFallTraeger);
                        break;

                    case "Kiss.UI.View.Ba.MyPersonView":
                    case "Kiss.UI.View.Ba.MyPersonViewWPF":
                        AssemblyLoader.InvokeMethode(ctl, "Init", PersonID);
                        break;

                    case "CtlFinanzen":
                    case "CtlArbeit":
                    case "CtlGesundheit":
                    case "CtlMassnahmen":
                    case "CtlSozialhilfe":
                        AssemblyLoader.InvokeMethode(ctl, "Init", "", this.GetIcon(e), PersonID, isFallTraeger);
                        break;

                    case "CtlBaInstitutionenFachpersonen":
                        AssemblyLoader.InvokeMethode(ctl, "Init", titel, this.GetIcon(e), PersonID);
                        break;
                }

                //
                this.ShowDetail(ctl, true);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlBaModulTree", "EintragAnzeigenNichtMoeglich", "Der gewünschte Eintrag kann nicht angezeigt werden", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void barManager_Tree_QueryShowPopupMenu(object sender, DevExpress.XtraBars.QueryShowPopupMenuEventArgs e)
        {
            foreach (DevExpress.XtraBars.BarItemLink barItemLink in e.Menu.ItemLinks)
                barItemLink.Item.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            if (DBUtil.UserHasRight("DlgNeuePerson"))
                btnNeuePerson.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            if (kissTree.FocusedNode != null &&
                typeof(CtlBaPerson).Name.Equals(kissTree.FocusedNode.GetValue("ClassName")) &&
                (int)kissTree.FocusedNode.GetValue("BaPersonID") != this.BaPersonID && // Fallträger selbst kann nicht entfernt werden
                DBUtil.UserHasRight("BaNavigRemovePerson"))
            {
                btnPersonEntfernen.Caption = kissTree.FocusedNode.GetDisplayText("Name") + " entfernen";
                btnPersonEntfernen.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

            foreach (DevExpress.XtraBars.BarItemLink barItemLink in e.Menu.ItemLinks)
                if (barItemLink.Item.Visibility != DevExpress.XtraBars.BarItemVisibility.Never)
                    return;
            e.Cancel = true;
        }

        private void btnNeuePerson_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KiSS4.Main.DlgErfassungPerson dlg = new KiSS4.Main.DlgErfassungPerson(this.BaPersonID);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int BaPersonID = dlg.NewBaPersonID;
                dlg.Dispose();

                //refresh Navigator und Neupositionierung auf neuen Fall
                kissTree.DataSource = null; //sonst Exception: open DataReader!
                this.FillTree();
                DevExpress.XtraTreeList.Nodes.TreeListNode node = DBUtil.FindNodeByValue(kissTree.Nodes, BaPersonID.ToString(), "BaPersonID");
                if (node != null)
                {
                    kissTree.FocusedNode = node;
                    node.Expanded = true;
                }
            }
        }

        private void btnPersonEntfernen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ((int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.BgFinanzPlan_BaPerson  BPP WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BgFinanzPlan   BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzPlanID = BPP.BgFinanzPlanID
                  INNER JOIN dbo.FaLeistung     LST WITH (READUNCOMMITTED) ON LST.FaLeistungID = BFP.FaLeistungID
                WHERE BPP.BaPersonID = {0} AND LST.BaPersonID = {1}
                  AND IsNull(BFP.DatumBis, BFP.GeplantBis) >= GetDate()"
                , kissTree.FocusedNode.GetValue("BaPersonID"), this.BaPersonID) > 0)
            {
                KissMsg.ShowInfo("CtlBaModulTree", "LoeschenNichtMoeglich", "{0} kann nicht gelöscht werden, da diese Person Haushaltsmitglied in einem aktuellen Finanzplan des Fallträgers ist.", 0, 0, kissTree.FocusedNode.GetDisplayText("Name"));
                return;
            }

            if (!KissMsg.ShowQuestion("CtlBaModulTree", "BeziehungLoeschen", "Soll '{0}' entfernt werden ?\r\n\r\n(Die Personendaten werden dadurch nicht gelöscht, sondern nur die Beziehung zur Fallträgerin.)", 0, 0, true, kissTree.FocusedNode.GetDisplayText("Name")))
                return;

            bool HasErrors = true;

            KiSS4.DB.Session.BeginTransaction();

            try
            {
                DBUtil.ExecSQLThrowingException(@"
                    DELETE BaPerson_Relation
                    WHERE (BaPersonID_1 = {0} AND BaPersonID_2 = {1}) OR
                          (BaPersonID_1 = {1} AND BaPersonID_2 = {0})

            --		DELETE FROM FaFallPerson WHERE BaPersonID = {1}", // ZH- only
                    this.BaPersonID,
                    kissTree.FocusedNode.GetValue("BaPersonID"));

                HasErrors = false;
                KiSS4.DB.Session.Commit();
            }
            catch (Exception exc)
            {
                KiSS4.DB.Session.Rollback();
                HasErrors = true;
                KissMsg.ShowError("CtlBaModulTree", "ErrorRemoveRelation", "Die Person konnte nicht gelöscht werden.", exc);
            }

            if (!HasErrors)
                kissTree.DeleteNode(kissTree.FocusedNode);
        }

        private void CtlBaModulTree_Load(object sender, System.EventArgs e)
        {
            //Expand Fallträger
            if (this.kissTree.Nodes.Count > 1)
            {
                this.kissTree.Nodes[1].Expanded = true;
            }
        }

        private void kissTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            // cancel update if loading
            if (this.isLoading)
            {
                return;
            }

            // check if we have to reselect node
            if (this.doRefocusNodeAfterFocusNode)
            {
                // reset flag (for security)
                this.doRefocusNodeAfterFocusNode = false;

                // check if we have a focusednode
                if (this.FocusedNode != null)
                {
                    try
                    {
                        // get current value of focused node
                        Object currentValue = this.FocusedNode.GetValue(kissTree.KeyFieldName);

                        // check if new node does really exist
                        if (kissTree.FindNodeByKeyID(currentValue) != null)
                        {
                            // set loading flag
                            this.isLoading = true;

                            // refresh again
                            this.Refresh();

                            // reset flag
                            this.isLoading = false;

                            // load node
                            this.kissTree_AfterFocusNode(sender, new DevExpress.XtraTreeList.NodeEventArgs(kissTree.FocusedNode));
                        }
                    }
                    catch (Exception ex)
                    {
                        // error occured, show message
                        KissMsg.ShowError("CtlFaModulTree", "ErrorFocusedNodeChanged", "Fehler bei der Verarbeitung.", "Error in Event: FocusedNodeChanged - kissTree", ex);
                    }
                    finally
                    {
                        // reset loading flag
                        this.isLoading = false;
                    }
                }
            }

            // reset flag anyway
            this.doRefocusNodeAfterFocusNode = false;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void Refresh()
        {
            base.Refresh();
            if (this.kissTree.Nodes.Count > 1)
            {
                this.kissTree.Nodes[1].Expanded = true;
            }
        }

        #endregion

        #endregion
    }
}