using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Inkasso
{
    partial class CtlIkModulTree
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIkModulTree));
            this.btnFallZuteilung = new DevExpress.XtraBars.BarButtonItem();
            this.btnForderungLoeschen = new DevExpress.XtraBars.BarButtonItem();
            this.btnInkassoFallLoeschen = new DevExpress.XtraBars.BarButtonItem();
            this.btnLoeschen = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeueAbklaerung = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeuerElternbeitrag = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeuerNachlass = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeuerRechtstitel = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeueRueckerstattung = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeueRueckerstattungPOM = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeuerVerwandtenbeitrag = new DevExpress.XtraBars.BarButtonItem();
            this.btnNeuesAlimentinkasso = new DevExpress.XtraBars.BarButtonItem();
            this.btnZusammenzugDrucken = new DevExpress.XtraBars.BarButtonItem();
            this.colClassName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFaLeistungID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
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
                        this.colClassName,
                        this.colFaLeistungID});
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
            this.kissTree.Size = new System.Drawing.Size(265, 618);
            this.kissTree.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            //
            // qryModulTree
            //
            this.qryModulTree.SelectStatement = "EXECUTE dbo.spXGetModulTree {0}, {1}, {2}, {3}, {4}";
            //
            // popup_Tree
            //
            this.popup_Tree.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnNeueRueckerstattungPOM),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnNeueAbklaerung),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnFallZugriff),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnFallInfo),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnNeuesAlimentinkasso),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnNeuerNachlass),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnNeuerVerwandtenbeitrag),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnNeuerElternbeitrag),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnLoeschen),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnInkassoFallLoeschen),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnNeueRueckerstattung),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnForderungLoeschen),
                        new DevExpress.XtraBars.LinkPersistInfo(this.btnZusammenzugDrucken)});
            //
            // barManager_Tree
            //
            this.barManager_Tree.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                        this.btnNeuerNachlass,
                        this.btnNeuesAlimentinkasso,
                        this.btnZusammenzugDrucken,
                        this.btnNeuerVerwandtenbeitrag,
                        this.btnNeueRueckerstattung,
                        this.btnNeuerElternbeitrag,
                        this.btnInkassoFallLoeschen,
                        this.btnForderungLoeschen,
                        this.btnLoeschen,
                        this.btnFallZuteilung,
                        this.btnNeuerRechtstitel,
                        this.btnNeueAbklaerung,
                        this.btnNeueRueckerstattungPOM});
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
            // btnFallZuteilung
            //
            this.btnFallZuteilung.Caption = "Fallzuteilung";
            this.btnFallZuteilung.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFallZuteilung.Glyph")));
            this.btnFallZuteilung.Id = 13;
            this.btnFallZuteilung.Name = "btnFallZuteilung";
            this.btnFallZuteilung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFallZuteilung_ItemClick);
            //
            // btnForderungLoeschen
            //
            this.btnForderungLoeschen.Caption = "Forderung Löschen";
            this.btnForderungLoeschen.CategoryGuid = new System.Guid("92fbb9f1-c7fb-43f6-8806-b5fa8cad8229");
            this.btnForderungLoeschen.GroupIndex = 3;
            this.btnForderungLoeschen.Id = 10;
            this.btnForderungLoeschen.ImageIndex = 4;
            this.btnForderungLoeschen.Name = "btnForderungLoeschen";
            //
            // btnInkassoFallLoeschen
            //
            this.btnInkassoFallLoeschen.Caption = "Inkassofall löschen";
            this.btnInkassoFallLoeschen.CategoryGuid = new System.Guid("92fbb9f1-c7fb-43f6-8806-b5fa8cad8229");
            this.btnInkassoFallLoeschen.GroupIndex = 3;
            this.btnInkassoFallLoeschen.Id = 6;
            this.btnInkassoFallLoeschen.ImageIndex = 4;
            this.btnInkassoFallLoeschen.Name = "btnInkassoFallLoeschen";
            //
            // btnLoeschen
            //
            this.btnLoeschen.Caption = "Inkasso löschen";
            this.btnLoeschen.CategoryGuid = new System.Guid("92fbb9f1-c7fb-43f6-8806-b5fa8cad8229");
            this.btnLoeschen.GroupIndex = 3;
            this.btnLoeschen.Id = 12;
            this.btnLoeschen.ImageIndex = 4;
            this.btnLoeschen.Name = "btnLoeschen";
            this.btnLoeschen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoeschen_ItemClick);
            //
            // btnNeueAbklaerung
            //
            this.btnNeueAbklaerung.Caption = "Neue Abklärung";
            this.btnNeueAbklaerung.Id = 15;
            this.btnNeueAbklaerung.ImageIndex = 1401;
            this.btnNeueAbklaerung.Name = "btnNeueAbklaerung";
            this.btnNeueAbklaerung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeueAbklaerung_ItemClick);
            //
            // btnNeuerElternbeitrag
            //
            this.btnNeuerElternbeitrag.Caption = "Neuer Elternbeitrag";
            this.btnNeuerElternbeitrag.CategoryGuid = new System.Guid("92fbb9f1-c7fb-43f6-8806-b5fa8cad8229");
            this.btnNeuerElternbeitrag.GroupIndex = 2;
            this.btnNeuerElternbeitrag.Id = 11;
            this.btnNeuerElternbeitrag.ImageIndex = 1401;
            this.btnNeuerElternbeitrag.Name = "btnNeuerElternbeitrag";
            this.btnNeuerElternbeitrag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeuerElternbeitrag_ItemClick);
            //
            // btnNeuerNachlass
            //
            this.btnNeuerNachlass.Caption = "Neuer Nachlass";
            this.btnNeuerNachlass.CategoryGuid = new System.Guid("92fbb9f1-c7fb-43f6-8806-b5fa8cad8229");
            this.btnNeuerNachlass.GroupIndex = 2;
            this.btnNeuerNachlass.Id = 3;
            this.btnNeuerNachlass.ImageIndex = 1401;
            this.btnNeuerNachlass.Name = "btnNeuerNachlass";
            this.btnNeuerNachlass.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeuerNachlass_ItemClick);
            //
            // btnNeuerRechtstitel
            //
            this.btnNeuerRechtstitel.Caption = "Neuer Rechtstitel";
            this.btnNeuerRechtstitel.Id = 14;
            this.btnNeuerRechtstitel.ImageIndex = 1421;
            this.btnNeuerRechtstitel.Name = "btnNeuerRechtstitel";
            this.btnNeuerRechtstitel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeuerRechtstitel_ItemClick);
            //
            // btnNeueRueckerstattung
            //
            this.btnNeueRueckerstattung.Caption = "Neue Rückerstattung";
            this.btnNeueRueckerstattung.CategoryGuid = new System.Guid("92fbb9f1-c7fb-43f6-8806-b5fa8cad8229");
            this.btnNeueRueckerstattung.GroupIndex = 2;
            this.btnNeueRueckerstattung.Id = 9;
            this.btnNeueRueckerstattung.ImageIndex = 1401;
            this.btnNeueRueckerstattung.Name = "btnNeueRueckerstattung";
            this.btnNeueRueckerstattung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeueRueckerstattung_ItemClick);
            //
            // btnNeueRueckerstattungPOM
            //
            this.btnNeueRueckerstattungPOM.Caption = "Neue Rückerstattung POM";
            this.btnNeueRueckerstattungPOM.Id = 16;
            this.btnNeueRueckerstattungPOM.ImageIndex = 1401;
            this.btnNeueRueckerstattungPOM.Name = "btnNeueRueckerstattungPOM";
            this.btnNeueRueckerstattungPOM.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeueRueckerstattungPOM_ItemClick);
            //
            // btnNeuerVerwandtenbeitrag
            //
            this.btnNeuerVerwandtenbeitrag.Caption = "Neuer Verwandtenbeitrag";
            this.btnNeuerVerwandtenbeitrag.CategoryGuid = new System.Guid("92fbb9f1-c7fb-43f6-8806-b5fa8cad8229");
            this.btnNeuerVerwandtenbeitrag.GroupIndex = 2;
            this.btnNeuerVerwandtenbeitrag.Id = 8;
            this.btnNeuerVerwandtenbeitrag.ImageIndex = 1401;
            this.btnNeuerVerwandtenbeitrag.Name = "btnNeuerVerwandtenbeitrag";
            this.btnNeuerVerwandtenbeitrag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeuerVerwandtenbeitrag_ItemClick);
            //
            // btnNeuesAlimentinkasso
            //
            this.btnNeuesAlimentinkasso.Caption = "Neues Alimentinkasso";
            this.btnNeuesAlimentinkasso.CategoryGuid = new System.Guid("92fbb9f1-c7fb-43f6-8806-b5fa8cad8229");
            this.btnNeuesAlimentinkasso.GroupIndex = 2;
            this.btnNeuesAlimentinkasso.Id = 4;
            this.btnNeuesAlimentinkasso.ImageIndex = 1401;
            this.btnNeuesAlimentinkasso.Name = "btnNeuesAlimentinkasso";
            this.btnNeuesAlimentinkasso.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNeuesAlimentinkasso_ItemClick);
            //
            // btnZusammenzugDrucken
            //
            this.btnZusammenzugDrucken.Caption = "Zusammenzug drucken";
            this.btnZusammenzugDrucken.CategoryGuid = new System.Guid("92fbb9f1-c7fb-43f6-8806-b5fa8cad8229");
            this.btnZusammenzugDrucken.GroupIndex = 2;
            this.btnZusammenzugDrucken.Id = 7;
            this.btnZusammenzugDrucken.ImageIndex = 24;
            this.btnZusammenzugDrucken.Name = "btnZusammenzugDrucken";
            //
            // colClassName
            //
            this.colClassName.Caption = "Typ";
            this.colClassName.FieldName = "ClassName";
            this.colClassName.Name = "colClassName";
            this.colClassName.OptionsColumn.AllowSort = false;
            //
            // colFaLeistungID
            //
            this.colFaLeistungID.FieldName = "FaLeistungID";
            this.colFaLeistungID.Name = "colFaLeistungID";
            this.colFaLeistungID.OptionsColumn.AllowSort = false;
            //
            // colName
            //
            this.colName.Caption = "Inkasso";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowSort = false;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 300;
            //
            // CtlIkModulTree
            //
            this.Name = "CtlIkModulTree";
            this.Size = new System.Drawing.Size(265, 618);
            this.Load += new System.EventHandler(this.CtlIkModulTree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kissTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryModulTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popup_Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager_Tree)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem btnFallZuteilung;
        private DevExpress.XtraBars.BarButtonItem btnForderungLoeschen;
        private DevExpress.XtraBars.BarButtonItem btnInkassoFallLoeschen;
        private DevExpress.XtraBars.BarButtonItem btnLoeschen;
        private DevExpress.XtraBars.BarButtonItem btnNeueAbklaerung;
        private DevExpress.XtraBars.BarButtonItem btnNeueRueckerstattung;
        private DevExpress.XtraBars.BarButtonItem btnNeueRueckerstattungPOM;
        private DevExpress.XtraBars.BarButtonItem btnNeuerElternbeitrag;
        private DevExpress.XtraBars.BarButtonItem btnNeuerNachlass;
        private DevExpress.XtraBars.BarButtonItem btnNeuerRechtstitel;
        private DevExpress.XtraBars.BarButtonItem btnNeuerVerwandtenbeitrag;
        private DevExpress.XtraBars.BarButtonItem btnNeuesAlimentinkasso;
        private DevExpress.XtraBars.BarButtonItem btnZusammenzugDrucken;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colClassName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFaLeistungID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
    }
}
