using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KiSS4.Sozialhilfe.ZH
{
    partial class CtlWhModulTree
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlWhModulTree));
            this.panel1 = new System.Windows.Forms.Panel();
            this.edtHideBeendeteRegWH = new KiSS4.Gui.KissCheckEdit();
            this.edtHideAbgeschlosseneW = new KiSS4.Gui.KissCheckEdit();
            this.btnBgBudget = new DevExpress.XtraBars.BarButtonItem();
            this.btnBgBudgetDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnBgBudgetReset = new DevExpress.XtraBars.BarButtonItem();
            this.btnBgBudgetResetMaster = new DevExpress.XtraBars.BarButtonItem();
            this.btnBgFinanzplan1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnBgFinanzplan2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnBgFinanzplanDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnFaLeistung300 = new DevExpress.XtraBars.BarButtonItem();
            this.btnFaLeistung301 = new DevExpress.XtraBars.BarButtonItem();
            this.btnFaLeistung302 = new DevExpress.XtraBars.BarButtonItem();
            this.btnFaLeistung304 = new DevExpress.XtraBars.BarButtonItem();
            this.btnFaLeistungDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnFallZuteilung = new DevExpress.XtraBars.BarButtonItem();
            this.colDatumVon = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtHideBeendeteRegWH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHideAbgeschlosseneW.Properties)).BeginInit();
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
            this.colName,
            this.colDatumVon});
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
            this.kissTree.Size = new System.Drawing.Size(265, 392);
            this.kissTree.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                       | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            // 
            // popup_Tree
            // 
            this.popup_Tree.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBgFinanzplan2),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBgFinanzplan1),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFaLeistung300),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFaLeistung301),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFaLeistung302),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFaLeistung304)});
            // 
            // barManager_Tree
            // 
            this.barManager_Tree.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnFaLeistung300,
            this.btnFaLeistung301,
            this.btnFaLeistung302,
            this.btnFaLeistung304,
            this.btnFaLeistungDelete,
            this.btnBgBudgetResetMaster,
            this.btnBgFinanzplan1,
            this.btnBgFinanzplan2,
            this.btnBgFinanzplanDelete,
            this.btnFallZuteilung});
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
            // panel1
            // 
            this.panel1.Controls.Add(this.edtHideAbgeschlosseneW);
            this.panel1.Controls.Add(this.edtHideBeendeteRegWH);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 61);
            this.panel1.TabIndex = 5;
            //
            // edtHideBeendeteRegWH
            //
            this.edtHideBeendeteRegWH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtHideBeendeteRegWH.EditValue = false;
            this.edtHideBeendeteRegWH.Location = new System.Drawing.Point(3, 7);
            this.edtHideBeendeteRegWH.Name = "edtHideBeendeteRegWH";
            this.edtHideBeendeteRegWH.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtHideBeendeteRegWH.Properties.Appearance.Options.UseBackColor = true;
            this.edtHideBeendeteRegWH.Properties.Caption = "Beendete Reg. WH ausblenden";
            this.edtHideBeendeteRegWH.Size = new System.Drawing.Size(258, 19);
            this.edtHideBeendeteRegWH.TabIndex = 0;
            this.edtHideBeendeteRegWH.EditValueChanged += new System.EventHandler(this.edtHideBeendeteRegWH_EditValueChanged);
            //
            // edtHideAbgeschlosseneW
            //
            this.edtHideAbgeschlosseneW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtHideAbgeschlosseneW.EditValue = false;
            this.edtHideAbgeschlosseneW.Location = new System.Drawing.Point(3, 29);
            this.edtHideAbgeschlosseneW.Name = "edtHideAbgeschlosseneW";
            this.edtHideAbgeschlosseneW.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtHideAbgeschlosseneW.Properties.Appearance.Options.UseBackColor = true;
            this.edtHideAbgeschlosseneW.Properties.Caption = "Abgeschlossene W ausblenden";
            this.edtHideAbgeschlosseneW.Size = new System.Drawing.Size(258, 19);
            this.edtHideAbgeschlosseneW.TabIndex = 1;
            this.edtHideAbgeschlosseneW.EditValueChanged += new System.EventHandler(this.edtHideAbgeschlosseneW_EditValueChanged);
            //
            // btnBgBudget
            //
            this.btnBgBudget.Caption = "Neues Monatsbudget einfügen ...";
            this.btnBgBudget.Id = 5;
            this.btnBgBudget.ImageIndex = 1323;
            this.btnBgBudget.Name = "btnBgBudget";
            this.btnBgBudget.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBgBudget_ItemClick);
            // 
            // btnBgBudgetDelete
            // 
            this.btnBgBudgetDelete.Caption = "Monatsbudget löschen ...";
            this.btnBgBudgetDelete.Id = 7;
            this.btnBgBudgetDelete.ImageIndex = 4;
            this.btnBgBudgetDelete.Name = "btnBgBudgetDelete";
            this.btnBgBudgetDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBgBudgetDelete_ItemClick);
            // 
            // btnBgBudgetReset
            // 
            this.btnBgBudgetReset.Caption = "Monatsbudget an Masterbudget anpassen ...";
            this.btnBgBudgetReset.Id = 6;
            this.btnBgBudgetReset.ImageIndex = 3;
            this.btnBgBudgetReset.Name = "btnBgBudgetReset";
            this.btnBgBudgetReset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBgBudgetReset_ItemClick);
            // 
            // btnBgBudgetResetMaster
            // 
            this.btnBgBudgetResetMaster.Caption = "Masterbudget gem. Finanzplan neu aufbauen";
            this.btnBgBudgetResetMaster.Id = 4;
            this.btnBgBudgetResetMaster.ImageIndex = 3;
            this.btnBgBudgetResetMaster.Name = "btnBgBudgetResetMaster";
            this.btnBgBudgetResetMaster.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBgBudgetResetMaster_ItemClick);
            // 
            // btnBgFinanzplan1
            // 
            this.btnBgFinanzplan1.Caption = "neue Notfall WH";
            this.btnBgFinanzplan1.Id = 10;
            this.btnBgFinanzplan1.ImageIndex = 1312;
            this.btnBgFinanzplan1.Name = "btnBgFinanzplan1";
            this.btnBgFinanzplan1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnBgFinanzplan1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBgFinanzplan1_ItemClick);
            // 
            // btnBgFinanzplan2
            // 
            this.btnBgFinanzplan2.Caption = "neue Reguläre WH (LE)";
            this.btnBgFinanzplan2.Id = 11;
            this.btnBgFinanzplan2.ImageIndex = 1312;
            this.btnBgFinanzplan2.Name = "btnBgFinanzplan2";
            this.btnBgFinanzplan2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBgFinanzplan2_ItemClick);
            // 
            // btnBgFinanzplanDelete
            // 
            this.btnBgFinanzplanDelete.Caption = "Finanzplan löschen";
            this.btnBgFinanzplanDelete.Id = 13;
            this.btnBgFinanzplanDelete.ImageIndex = 4;
            this.btnBgFinanzplanDelete.Name = "btnBgFinanzplanDelete";
            this.btnBgFinanzplanDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBgFinanzplanDelete_ItemClick);
            // 
            // btnFaLeistung300
            // 
            this.btnFaLeistung300.Caption = "neue wirtschaftliche Hilfe";
            this.btnFaLeistung300.Id = 5;
            this.btnFaLeistung300.ImageIndex = 1301;
            this.btnFaLeistung300.Name = "btnFaLeistung300";
            this.btnFaLeistung300.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFaLeistung300_ItemClick);
            // 
            // btnFaLeistung301
            // 
            this.btnFaLeistung301.Caption = "neues Inkasso Verwandtenunterstützung";
            this.btnFaLeistung301.Id = 6;
            this.btnFaLeistung301.ImageIndex = 1301;
            this.btnFaLeistung301.Name = "btnFaLeistung301";
            this.btnFaLeistung301.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFaLeistung301_ItemClick);
            // 
            // btnFaLeistung302
            // 
            this.btnFaLeistung302.Caption = "neues Inkasso Rückerstattung";
            this.btnFaLeistung302.Id = 7;
            this.btnFaLeistung302.ImageIndex = 1301;
            this.btnFaLeistung302.Name = "btnFaLeistung302";
            this.btnFaLeistung302.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFaLeistung302_ItemClick);
            // 
            // btnFaLeistung304
            // 
            this.btnFaLeistung304.Caption = "neues Inkasso Unterhaltsbeiträge + KiZu";
            this.btnFaLeistung304.Id = 9;
            this.btnFaLeistung304.ImageIndex = 1301;
            this.btnFaLeistung304.Name = "btnFaLeistung304";
            this.btnFaLeistung304.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFaLeistung304_ItemClick);
            // 
            // btnFaLeistungDelete
            // 
            this.btnFaLeistungDelete.Caption = "Wirtschaftliche Hilfe löschen";
            this.btnFaLeistungDelete.Id = 2;
            this.btnFaLeistungDelete.ImageIndex = 4;
            this.btnFaLeistungDelete.Name = "btnFaLeistungDelete";
            this.btnFaLeistungDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFaLeistungDelete_ItemClick);
            // 
            // btnFallZuteilung
            // 
            this.btnFallZuteilung.Caption = "Fallzuteilung";
            this.btnFallZuteilung.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFallZuteilung.Glyph")));
            this.btnFallZuteilung.Id = 14;
            this.btnFallZuteilung.Name = "btnFallZuteilung";
            this.btnFallZuteilung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFallZuteilung_ItemClick);
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "Datum";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.OptionsColumn.AllowSort = false;
            this.colDatumVon.VisibleIndex = 1;
            // 
            // colName
            // 
            this.colName.Caption = "Wirtschaftliche Hilfe";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowSort = false;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 195;
            // 
            // CtlWhModulTree
            // 
            this.Controls.Add(this.panel1);
            this.Name = "CtlWhModulTree";
            this.Size = new System.Drawing.Size(265, 453);
            this.Load += new System.EventHandler(this.CtlWhModulTree_Load);
            this.Controls.SetChildIndex(this.barDockControl1, 0);
            this.Controls.SetChildIndex(this.barDockControl2, 0);
            this.Controls.SetChildIndex(this.barDockControl4, 0);
            this.Controls.SetChildIndex(this.barDockControl3, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.kissTree, 0);
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtHideBeendeteRegWH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHideAbgeschlosseneW.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btnBgBudget;
        private DevExpress.XtraBars.BarButtonItem btnBgBudgetDelete;
        private DevExpress.XtraBars.BarButtonItem btnBgBudgetReset;
        private DevExpress.XtraBars.BarButtonItem btnBgBudgetResetMaster;
        private DevExpress.XtraBars.BarButtonItem btnBgFinanzplan1;
        private DevExpress.XtraBars.BarButtonItem btnBgFinanzplan2;
        private DevExpress.XtraBars.BarButtonItem btnBgFinanzplanDelete;
        private DevExpress.XtraBars.BarButtonItem btnFaLeistung300;
        private DevExpress.XtraBars.BarButtonItem btnFaLeistung301;
        private DevExpress.XtraBars.BarButtonItem btnFaLeistung302;
        private DevExpress.XtraBars.BarButtonItem btnFaLeistung304;
        private DevExpress.XtraBars.BarButtonItem btnFaLeistungDelete;
        private DevExpress.XtraBars.BarButtonItem btnFallZuteilung;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDatumVon;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private KiSS4.Gui.KissUserControl ctlWhKontoauszug = null;
        private KiSS4.Gui.KissCheckEdit edtHideAbgeschlosseneW;
        private KiSS4.Gui.KissCheckEdit edtHideBeendeteRegWH;
        private System.Windows.Forms.Panel panel1;
        private Control panelDetail = null;

    }
}
