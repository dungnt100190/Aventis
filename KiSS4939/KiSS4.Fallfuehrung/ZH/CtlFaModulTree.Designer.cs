using System;
using System.Windows.Forms;

namespace KiSS4.Fallfuehrung.ZH
{
    public partial class CtlFaModulTree
    {
        #region Fields

        #region Private Fields

        //private CtlFaSozialSystem  ctlFaSozialSystem;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnFallZuteilung;
        private DevExpress.XtraBars.BarButtonItem btnNeueAbklaerung;
        private DevExpress.XtraBars.BarButtonItem btnNeueFallfuehrung;
        private DevExpress.XtraBars.BarButtonItem btnNeueVoranmeldung;
        private DevExpress.XtraBars.BarButtonItem btnNeueVormMandat;
        private DevExpress.XtraBars.BarButtonItem btnNeueZielvereinbarung;
        private DevExpress.XtraBars.BarButtonItem btnNeuesAssessment;
        private DevExpress.XtraBars.BarButtonItem btnNeuesCheckIn;
        private DevExpress.XtraBars.BarButtonItem btnNeuesRP;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAlimentenstelle;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAufnahme;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFaFallID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colModuleID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSAR;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Panel panelThemenFilter;
        private KiSS4.DB.SqlQuery qryPopupMenu;

        #endregion

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaModulTree));
            this.panelThemenFilter = new System.Windows.Forms.Panel();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnFallZuteilung = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeueAbklaerung = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeueFallfuehrung = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeuesAssessment = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeuesCheckIn = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeuesRP = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeueVoranmeldung = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeueVormMandat = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeueZielvereinbarung = new DevExpress.XtraBars.BarButtonItem();
            this.colAlimentenstelle = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAufnahme = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFaFallID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colModuleID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSAR = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.qryPopupMenu = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPopupMenu)).BeginInit();
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
            this.colAufnahme,
            this.colSAR,
            this.colFaFallID,
            this.colModuleID,
            this.colAlimentenstelle});
            this.kissTree.OptionsBehavior.AutoSelectAllInEditor = false;
            this.kissTree.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.kissTree.OptionsBehavior.Editable = false;
            this.kissTree.OptionsBehavior.KeepSelectedOnClick = false;
            this.kissTree.OptionsBehavior.MoveOnEdit = false;
            this.kissTree.OptionsBehavior.PopulateServiceColumns = true;
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
            this.kissTree.Size = new System.Drawing.Size(295, 500);
            this.kissTree.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            //
            // barManager_Tree
            //
            this.barManager_Tree.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNeueFallfuehrung,
            this.btnNeueVoranmeldung,
            this.btnNeuesCheckIn,
            this.btnNeuesAssessment,
            this.btnNeuesRP,
            this.btnNeueZielvereinbarung,
            this.btnNeueAbklaerung,
            this.btnNeueVormMandat,
            this.btnDelete,
            this.btnFallZuteilung});
            this.barManager_Tree.MaxItemId = 4;
            //
            // btnFallInfo
            //
            this.btnFallInfo.CategoryGuid = new System.Guid("f96a77cc-41a0-4295-8f5a-5c2410a21ef7");
            //
            // btnFallZugriff
            //
            this.btnFallZugriff.CategoryGuid = new System.Guid("f96a77cc-41a0-4295-8f5a-5c2410a21ef7");
            //
            // popup_Tree
            //
            this.popup_Tree.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNeuesCheckIn, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNeuesAssessment),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNeuesRP),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNeueVormMandat),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFallZugriff),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFallInfo)});
            this.popup_Tree.BeforePopup += new System.EventHandler(this.popup_Tree_BeforePopup);
            //
            // panelThemenFilter
            //
            this.panelThemenFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelThemenFilter.Location = new System.Drawing.Point(0, 500);
            this.panelThemenFilter.Name = "panelThemenFilter";
            this.panelThemenFilter.Size = new System.Drawing.Size(295, 0);
            this.panelThemenFilter.TabIndex = 5;
            //
            // btnDelete
            //
            this.btnDelete.Caption = "Löschen";
            this.btnDelete.Id = 5;
            this.btnDelete.ImageIndex = 4;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            //
            // btnFallZuteilung
            //
            this.btnFallZuteilung.Caption = "Fallzuteilung";
            this.btnFallZuteilung.Id = 3;
            this.btnFallZuteilung.ImageIndex = 212;
            this.btnFallZuteilung.Name = "btnFallZuteilung";
            this.btnFallZuteilung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFallZuteilung_ItemClick);
            //
            // btnNeueAbklaerung
            //
            this.btnNeueAbklaerung.Caption = "neue Abklärung";
            this.btnNeueAbklaerung.Id = 13;
            this.btnNeueAbklaerung.ImageIndex = 183;
            this.btnNeueAbklaerung.Name = "btnNeueAbklaerung";
            this.btnNeueAbklaerung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeueAbklaerung_ItemClick);
            //
            // btnNeueFallfuehrung
            //
            this.btnNeueFallfuehrung.Caption = "neue Fallführung";
            this.btnNeueFallfuehrung.Id = 10;
            this.btnNeueFallfuehrung.ImageIndex = 1201;
            this.btnNeueFallfuehrung.Name = "btnNeueFallfuehrung";
            this.btnNeueFallfuehrung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeueFallfuehrung_ItemClick);
            //
            // btnNeuesAssessment
            //
            this.btnNeuesAssessment.Caption = "neues Assessment";
            this.btnNeuesAssessment.Id = 4;
            this.btnNeuesAssessment.ImageIndex = 192;
            this.btnNeuesAssessment.Name = "btnNeuesAssessment";
            this.btnNeuesAssessment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeuesAssessment_ItemClick);
            //
            // btnNeuesCheckIn
            //
            this.btnNeuesCheckIn.Caption = "neues Check-in";
            this.btnNeuesCheckIn.Id = 3;
            this.btnNeuesCheckIn.ImageIndex = 178;
            this.btnNeuesCheckIn.Name = "btnNeuesCheckIn";
            this.btnNeuesCheckIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeuesCheckIn_ItemClick);
            //
            // btnNeuesRP
            //
            this.btnNeuesRP.Caption = "neues Ressourcenpaket";
            this.btnNeuesRP.Id = 6;
            this.btnNeuesRP.ImageIndex = 218;
            this.btnNeuesRP.Name = "btnNeuesRP";
            this.btnNeuesRP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeuesRP_ItemClick);
            //
            // btnNeueVoranmeldung
            //
            this.btnNeueVoranmeldung.Caption = "neue Voranmeldung";
            this.btnNeueVoranmeldung.Id = 11;
            this.btnNeueVoranmeldung.ImageIndex = 208;
            this.btnNeueVoranmeldung.Name = "btnNeueVoranmeldung";
            this.btnNeueVoranmeldung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeueVoranmeldung_ItemClick);
            //
            // btnNeueVormMandat
            //
            this.btnNeueVormMandat.Caption = "neue KES-Massnahme";
            this.btnNeueVormMandat.Id = 8;
            this.btnNeueVormMandat.ImageIndex = 194;
            this.btnNeueVormMandat.Name = "btnNeueVormMandat";
            this.btnNeueVormMandat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeueVormMandat_ItemClick);
            //
            // btnNeueZielvereinbarung
            //
            this.btnNeueZielvereinbarung.Caption = "neue Zielvereinbarung";
            this.btnNeueZielvereinbarung.Id = 12;
            this.btnNeueZielvereinbarung.ImageIndex = 125;
            this.btnNeueZielvereinbarung.Name = "btnNeueZielvereinbarung";
            this.btnNeueZielvereinbarung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeueZielvereinbarung_ItemClick);
            //
            // colAlimentenstelle
            //
            this.colAlimentenstelle.Caption = "colAlimentenstelle";
            this.colAlimentenstelle.FieldName = "IstAlimentenstelle";
            this.colAlimentenstelle.Name = "colAlimentenstelle";
            this.colAlimentenstelle.OptionsColumn.AllowSort = false;
            //
            // colAufnahme
            //
            this.colAufnahme.Caption = "ab";
            this.colAufnahme.FieldName = "Aufnahme";
            this.colAufnahme.Name = "colAufnahme";
            this.colAufnahme.OptionsColumn.AllowSort = false;
            this.colAufnahme.VisibleIndex = 1;
            this.colAufnahme.Width = 69;
            //
            // colFaFallID
            //
            this.colFaFallID.Caption = "FaFallID";
            this.colFaFallID.FieldName = "FaFallID";
            this.colFaFallID.Name = "colFaFallID";
            this.colFaFallID.OptionsColumn.AllowSort = false;
            //
            // colModuleID
            //
            this.colModuleID.Caption = "ModulCode";
            this.colModuleID.FieldName = "ModulID";
            this.colModuleID.Name = "colModuleID";
            this.colModuleID.OptionsColumn.AllowSort = false;
            //
            // colName
            //
            this.colName.Caption = "Fallführung";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowSort = false;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 193;
            //
            // colSAR
            //
            this.colSAR.Caption = "SAR";
            this.colSAR.FieldName = "SARName";
            this.colSAR.Name = "colSAR";
            this.colSAR.OptionsColumn.AllowSort = false;
            this.colSAR.Width = 194;
            //
            // qryPopupMenu
            //
            this.qryPopupMenu.HostControl = this;
            this.qryPopupMenu.SelectStatement = resources.GetString("qryPopupMenu.SelectStatement");
            //
            // CtlFaModulTree
            //
            this.Controls.Add(this.panelThemenFilter);
            this.Name = "CtlFaModulTree";
            this.Size = new System.Drawing.Size(295, 500);
            this.Load += new System.EventHandler(this.CtlFaModulTree_Load);
            this.Controls.SetChildIndex(this.barDockControl1, 0);
            this.Controls.SetChildIndex(this.barDockControl2, 0);
            this.Controls.SetChildIndex(this.barDockControl4, 0);
            this.Controls.SetChildIndex(this.barDockControl3, 0);
            this.Controls.SetChildIndex(this.panelThemenFilter, 0);
            this.Controls.SetChildIndex(this.kissTree, 0);
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPopupMenu)).EndInit();
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
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}