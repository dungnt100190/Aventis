using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Asyl
{
    public class CtlAyModulTree : KiSS4.Common.KissModulTree
    {
        private DevExpress.XtraBars.BarButtonItem btnBgDelete;
        private DevExpress.XtraBars.BarButtonItem btnBgNeu;
        private DevExpress.XtraBars.BarButtonItem btnBgResetMonat;
        private DevExpress.XtraBars.BarButtonItem btnFallDelete;
        private DevExpress.XtraBars.BarButtonItem btnFallNeu;
        private DevExpress.XtraBars.BarButtonItem btnMasterbudgetNeu;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBgBudgetID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDatum;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRecordID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTyp;
        private System.ComponentModel.IContainer components = null;
        private CtlDynaMask ctlDynaMask;

        public CtlAyModulTree(int baPersonID, int faFallID, System.Windows.Forms.Panel panDetail)
            : base(baPersonID, faFallID, panDetail, (int)Gui.ModulID.A)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            this.FillTree();
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
                if (this.ctlDynaMask != null) this.ctlDynaMask.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDatum = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTyp = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colRecordID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colBgBudgetID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.btnFallNeu = new DevExpress.XtraBars.BarButtonItem();
            this.btnFallDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnBgNeu = new DevExpress.XtraBars.BarButtonItem();
            this.btnBgResetMonat = new DevExpress.XtraBars.BarButtonItem();
            this.btnBgDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnMasterbudgetNeu = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).BeginInit();
            this.SuspendLayout();
            //
            // kissTree
            //
            this.kissTree.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.kissTree.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.kissTree.Appearance.Empty.Options.UseBackColor = true;
            this.kissTree.Appearance.Empty.Options.UseForeColor = true;
            this.kissTree.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.kissTree.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.kissTree.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree.Appearance.FooterPanel.Options.UseBackColor = true;
            this.kissTree.Appearance.FooterPanel.Options.UseFont = true;
            this.kissTree.Appearance.FooterPanel.Options.UseForeColor = true;
            this.kissTree.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.kissTree.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.kissTree.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree.Appearance.GroupButton.Options.UseBackColor = true;
            this.kissTree.Appearance.GroupButton.Options.UseFont = true;
            this.kissTree.Appearance.GroupButton.Options.UseForeColor = true;
            this.kissTree.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.kissTree.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree.Appearance.GroupFooter.Options.UseBackColor = true;
            this.kissTree.Appearance.GroupFooter.Options.UseForeColor = true;
            this.kissTree.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.kissTree.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.kissTree.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.kissTree.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree.Appearance.OddRow.Options.UseBackColor = true;
            this.kissTree.Appearance.OddRow.Options.UseFont = true;
            this.kissTree.Appearance.OddRow.Options.UseForeColor = true;
            this.kissTree.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.kissTree.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kissTree.Appearance.Preview.Options.UseBackColor = true;
            this.kissTree.Appearance.Preview.Options.UseFont = true;
            this.kissTree.Appearance.Preview.Options.UseForeColor = true;
            this.kissTree.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.kissTree.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissTree.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.colDatum,
            this.colTyp,
            this.colRecordID,
            this.colBgBudgetID});
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
            this.kissTree.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            //
            // popup_Tree
            //
            this.popup_Tree.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFallNeu),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFallDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFallZugriff, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFallInfo),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMasterbudgetNeu),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBgNeu),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBgResetMonat),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBgDelete)});
            //
            // barManager_Tree
            //
            this.barManager_Tree.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnFallNeu,
            this.btnFallDelete,
            this.btnBgNeu,
            this.btnBgResetMonat,
            this.btnBgDelete,
            this.btnMasterbudgetNeu});
            this.barManager_Tree.MaxItemId = 11;
            this.barManager_Tree.QueryShowPopupMenu += new DevExpress.XtraBars.QueryShowPopupMenuEventHandler(this.barManager_Tree_QueryShowPopupMenu);
            //
            // btnFallZugriff
            //
            this.btnFallZugriff.Id = 3;
            //
            // btnFallInfo
            //
            this.btnFallInfo.Id = 9;
            //
            // colName
            //
            this.colName.Caption = "Asyl";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 27;
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowMove = false;
            this.colName.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colName.OptionsColumn.AllowSort = false;
            this.colName.OptionsColumn.ShowInCustomizationForm = false;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 200;
            //
            // colDatum
            //
            this.colDatum.Caption = "ab";
            this.colDatum.FieldName = "DatumVon";
            this.colDatum.Name = "colDatum";
            this.colDatum.OptionsColumn.AllowFocus = false;
            this.colDatum.OptionsColumn.AllowMove = false;
            this.colDatum.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colDatum.OptionsColumn.AllowSort = false;
            this.colDatum.OptionsColumn.ShowInCustomizationForm = false;
            this.colDatum.VisibleIndex = 1;
            //
            // colTyp
            //
            this.colTyp.Caption = "Typ";
            this.colTyp.FieldName = "Typ";
            this.colTyp.Name = "colTyp";
            //
            // colRecordID
            //
            this.colRecordID.Caption = "RecordID";
            this.colRecordID.FieldName = "RecordID";
            this.colRecordID.Name = "colRecordID";
            //
            // colBgBudgetID
            //
            this.colBgBudgetID.Caption = "BgBudgetID";
            this.colBgBudgetID.FieldName = "BgBudgetID";
            this.colBgBudgetID.Name = "colBgBudgetID";
            //
            // btnFallNeu
            //
            this.btnFallNeu.Caption = "Neuer Asylfall";
            this.btnFallNeu.Id = 0;
            this.btnFallNeu.ImageIndex = 1;
            this.btnFallNeu.Name = "btnFallNeu";
            this.btnFallNeu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFallNeu_ItemClick);
            //
            // btnFallDelete
            //
            this.btnFallDelete.Caption = "Asyl löschen";
            this.btnFallDelete.Id = 2;
            this.btnFallDelete.ImageIndex = 4;
            this.btnFallDelete.Name = "btnFallDelete";
            this.btnFallDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFallDelete_ItemClick);
            //
            // btnBgNeu
            //
            this.btnBgNeu.Caption = "Neues Monatsbudget einfügen ...";
            this.btnBgNeu.Id = 5;
            this.btnBgNeu.ImageIndex = 1;
            this.btnBgNeu.Name = "btnBgNeu";
            this.btnBgNeu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBgNeu_ItemClick);
            //
            // btnBgResetMonat
            //
            this.btnBgResetMonat.Caption = "Monatsbudget an Masterbudget anpassen ...";
            this.btnBgResetMonat.Id = 6;
            this.btnBgResetMonat.ImageIndex = 3;
            this.btnBgResetMonat.Name = "btnBgResetMonat";
            this.btnBgResetMonat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBgResetMonat_ItemClick);
            //
            // btnBgDelete
            //
            this.btnBgDelete.Caption = "Monatsbudget löschen ...";
            this.btnBgDelete.Id = 7;
            this.btnBgDelete.ImageIndex = 4;
            this.btnBgDelete.Name = "btnBgDelete";
            this.btnBgDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBgDelete_ItemClick);
            //
            // btnMasterbudgetNeu
            //
            this.btnMasterbudgetNeu.Caption = "Neues Masterbudget";
            this.btnMasterbudgetNeu.Id = 10;
            this.btnMasterbudgetNeu.ImageIndex = 1;
            this.btnMasterbudgetNeu.Name = "btnMasterbudgetNeu";
            this.btnMasterbudgetNeu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMasterbudgetNeu_ItemClick);
            //
            // CtlAyModulTree
            //
            this.Name = "CtlAyModulTree";
            this.Load += new System.EventHandler(this.CtlAyModulTree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region AfterFocusNode

        protected override void kissTree_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e == null || e.Node == null)
            {
                ShowDetail(null);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string className = e.Node.GetValue("ClassName") as string;
                Image imgIcon = this.GetIcon(e);
                string titel = e.Node.GetValue("Name") as string;
                KissUserControl ctl = null;

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

                switch (className)
                {
                    case "Keine Funktion":
                        return;

                    case "AyFallNoAccess":
                        this.ShowDetail(null);
                        return;

                    case "CtlDynaMask":
                        string MaskName = (string)e.Node.GetValue("MaskName");
                        ctlDynaMask = new CtlDynaMask();
                        ctl = ctlDynaMask;

                        ctlDynaMask.Init(titel, imgIcon,
                            (int)e.Node.GetValue("FaLeistungID"), 0,
                            MaskName, false, null);

                        ShowDetail(ctlDynaMask);

                        ctlDynaMask.ResizeControls();
                        break;

                    case "CtlAyFall":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(className, imgIcon, titel,
                            (int)e.Node.GetValue("BaPersonID"),
                            (int)e.Node.GetValue("FaLeistungID"));
                        break;

                    case "CtlAyPerioden":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(className, imgIcon, titel,
                            (int)e.Node.GetValue("FaLeistungID"));
                        break;

                    case "CtlAyPeriode":
                        ctl = (KissUserControl)new CtlAyPeriode(this.GetIcon(e),
                            (int)e.Node.GetValue(this.colRecordID));
                        break;

                    case "CtlAyPersonen":
                        ctl = (KissUserControl)new CtlAyPersonen(this.GetIcon(e),
                            (int)e.Node.GetValue(this.colRecordID),
                            (int)e.Node.GetValue("BaPersonID"));
                        break;

                    case "CtlAyPerson":
                        ctl = (KissUserControl)new CtlAyPerson(this.GetIcon(e),
                            (int)e.Node.GetValue(this.colRecordID),
                            (int)e.Node.GetValue("BaPersonID"));
                        break;

                    case "CtlAyBudget":
                    case "CtlAyBudget_Monatsbudget":
                    case "CtlAyBudget_Masterbudget":
                        ctl = (KissUserControl)new CtlAyBudget(this.GetIcon(e),
                            (int)e.Node.GetValue("BgBudgetID"),
                            (int)e.Node.GetValue(this.colRecordID));
                        break;

                    case "CtlAyZahlungsmodus":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(className,
                                                                                imgIcon,
                                                                                titel,
                                                                                (int)e.Node.GetValue("FaLeistungID"));
                        break;

                    case "CtlAySpezialkonto":
                        ctl = (KissUserControl)AssemblyLoader.CreateInstance(className,
                                                                                imgIcon,
                                                                                titel,
                                                                                (BgSpezkontoTyp)e.Node.GetValue(this.colRecordID),
                                                                                (int)e.Node.GetValue("FaLeistungID"));
                        break;

                    default:
                        KissMsg.ShowInfo("CtlAyModulTree", "NichtImplementiert", "{0} ist noch nicht implementiert", 0, 0, className);
                        break;
                }

                this.ApplyEditMaskToSqlQuery(ctl.ActiveSQLQuery);

                //
                this.ShowDetail(ctl, true);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlAyModulTree", "EintragAnzeigenNichtMoeglich", "Der gewünschte Eintrag kann nicht angezeigt werden", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #region PopupMenu

        private void barManager_Tree_QueryShowPopupMenu(object sender, DevExpress.XtraBars.QueryShowPopupMenuEventArgs e)
        {
            foreach (DevExpress.XtraBars.BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                barItemLink.Item.Visibility = BarItemVisibility.Never;
            }

            if (kissTree.FocusedNode == null)
            {
                if (DBUtil.UserHasRight("AyNavigNewAsyl"))
                    btnFallNeu.Visibility = BarItemVisibility.Always;
            }
            else
            {
                switch (kissTree.FocusedNode.GetValue(this.colTyp).ToString())
                {
                    case "AyFall":
                        if (DBUtil.UserHasRight("AyNavigNewAsyl"))
                            btnFallNeu.Visibility = BarItemVisibility.Always;

                        if (DBUtil.UserHasRight("AyNavigDeleteAsyl"))
                            btnFallDelete.Visibility = BarItemVisibility.Always;

                        if (DBUtil.UserHasRight("FrmFallZugriff"))
                            btnFallZugriff.Visibility = BarItemVisibility.Always;

                        if (DBUtil.UserHasRight("FrmFallInfo"))
                            btnFallInfo.Visibility = BarItemVisibility.Always;
                        break;

                    case "AyPerioden":
                    case "AyPeriode":
                        if (DBUtil.UserHasRight("AyNavigNewAsyl"))
                            btnMasterbudgetNeu.Visibility = BarItemVisibility.Always;
                        break;

                    case "AyBudget_Masterbudget":
                        if (DBUtil.UserHasRight("AyNavigNewMonatsbudget"))
                            btnBgNeu.Visibility = BarItemVisibility.Always;
                        break;

                    case "AyBudget_Monatsbudget":
                        if (DBUtil.UserHasRight("AyNavigNewMonatsbudget"))
                            btnBgNeu.Visibility = BarItemVisibility.Always;

                        btnBgResetMonat.Visibility = BarItemVisibility.Always;

                        if (DBUtil.UserHasRight("AyNavigDeleteMonatsbudget"))
                            btnBgDelete.Visibility = BarItemVisibility.Always;
                        break;
                }
            }

            foreach (DevExpress.XtraBars.BarItemLink barItemLink in e.Menu.ItemLinks)
            {
                if (barItemLink.Item.Visibility != BarItemVisibility.Never) return;
            }
            e.Cancel = true;
        }

        private void btnBgDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DetailControl is CtlAyBudget)
            {
                try
                {
                    int IconID = (int)kissTree.FocusedNode.GetValue("IconID");

                    if (IconID == 1635)
                    {
                        DBUtil.ExecSQLThrowingException(@"
							EXECUTE spAyBudget_Delete {0}
							DELETE FROM BgBudget WHERE BgBudgetID = {0}"
                            , (int)kissTree.FocusedNode.GetValue(this.colBgBudgetID));
                        FormController.SendMessage("FrmFall", "Action", "RefreshTree");
                    }
                    else
                        throw new KissInfoException(KissMsg.GetMLMessage("CtlAyModulTree", "BudgetLoeschenNurInStatusVorb", "Es können nur Monatsbudget im Status 'In Vorbereitung' gelöscht werden", KissMsgCode.MsgInfo));
                }
                catch (KissCancelException ex)
                {
                    ex.ShowMessage();
                }
            }
        }

        private void btnBgNeu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DetailControl is CtlAyBudget)
                ((IKissDataNavigator)DetailControl).AddData();
        }

        private void btnBgResetMonat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DetailControl is CtlAyBudget)
                ((CtlAyBudget)DetailControl).ResetBudget();
        }

        private void btnFallDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DetailControl is CtlAyFall)
                ((IKissDataNavigator)DetailControl).DeleteData();
            FormController.SendMessage("FrmFallNavigator", "Action", "RefreshTree");
        }

        private void btnFallNeu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!(DetailControl is CtlAyFall))
                this.ShowDetail(new CtlAyFall(KissImageList.GetSmallImage(1600), string.Empty, this.BaPersonID), true);

            if (DetailControl is CtlAyFall)
                ((IKissDataNavigator)DetailControl).AddData();
            FormController.SendMessage("FrmFallNavigator", "Action", "RefreshTree");
        }

        private void btnMasterbudgetNeu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!(DetailControl is CtlAyPerioden))
                this.ShowDetail(new CtlAyPerioden(KissImageList.GetSmallImage(1600), this.BaPersonID), true);

            if (DetailControl is CtlAyPerioden)
                ((IKissDataNavigator)DetailControl).AddData();
        }

        #endregion

        private void CtlAyModulTree_Load(object sender, System.EventArgs e)
        {
            // jüngstes Unterstützungsperiode expandieren
            if (this.kissTree.Nodes.Count != 0)
            {
                this.kissTree.Nodes[0].Expanded = true; // AsylModul

                if (this.kissTree.Nodes[0].Nodes.Count != 0)
                {
                    this.kissTree.Nodes[0].Nodes[0].Expanded = true; // finanzielle Unterst.

                    if (this.kissTree.Nodes[0].Nodes[0].Nodes.Count != 0)
                    {
                        this.kissTree.Nodes[0].Nodes[0].Nodes[0].Expanded = true; // Unterst.Periode
                    }
                }
            }
        }
    }
}