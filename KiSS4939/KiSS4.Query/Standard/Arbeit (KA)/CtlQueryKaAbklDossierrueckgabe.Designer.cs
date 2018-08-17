using System;
using KiSS4.DB;

namespace KiSS4.Query
{
    partial class CtlQueryKaAbklDossierrueckgabe 
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colApr;
        private DevExpress.XtraGrid.Columns.GridColumn colAug;
        private DevExpress.XtraGrid.Columns.GridColumn colDez;
        private DevExpress.XtraGrid.Columns.GridColumn colFeb;
        private DevExpress.XtraGrid.Columns.GridColumn colGrndefrdieDossierrckgabe;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colJan;
        private DevExpress.XtraGrid.Columns.GridColumn colJul;
        private DevExpress.XtraGrid.Columns.GridColumn colJun;
        private DevExpress.XtraGrid.Columns.GridColumn colMai;
        private DevExpress.XtraGrid.Columns.GridColumn colMrz;
        private DevExpress.XtraGrid.Columns.GridColumn colNov;
        private DevExpress.XtraGrid.Columns.GridColumn colOkt;
        private DevExpress.XtraGrid.Columns.GridColumn colSep;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLabel lblbis;
        private KiSS4.Gui.KissLabel lblDatumvon;

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaAbklDossierrueckgabe));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblDatumvon = new KiSS4.Gui.KissLabel();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.colApr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAug = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDez = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFeb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrndefrdieDossierrckgabe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJul = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJun = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMrz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNov = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOkt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgRohdaten = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFallDossierrueckgabe = new KiSS4.Common.CtlGotoFall();
            this.grdRohdaten = new KiSS4.Gui.KissGrid();
            this.grvRohdaten = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            this.tpgRohdaten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRohdaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRohdaten)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
            // 
            // grvQuery1
            // 
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            // 
            // grdQuery1
            // 
            // 
            // 
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = null;
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 395);
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 27);
            this.ctlGotoFall.Visible = false;
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgRohdaten);
            this.tabControlSearch.SelectedTabIndex = 2;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgRohdaten});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgRohdaten, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.lblDatumvon);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            // 
            // lblDatumvon
            // 
            this.lblDatumvon.Location = new System.Drawing.Point(10, 40);
            this.lblDatumvon.Name = "lblDatumvon";
            this.lblDatumvon.Size = new System.Drawing.Size(130, 24);
            this.lblDatumvon.TabIndex = 1;
            this.lblDatumvon.Text = "Datum von";
            this.lblDatumvon.UseCompatibleTextRendering = true;
            // 
            // lblbis
            // 
            this.lblbis.Location = new System.Drawing.Point(270, 40);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(130, 24);
            this.lblbis.TabIndex = 2;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = "";
            this.edtDatumVon.Location = new System.Drawing.Point(150, 40);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 21;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = "";
            this.edtDatumBis.Location = new System.Drawing.Point(300, 40);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 22;
            // 
            // colApr
            // 
            this.colApr.Name = "colApr";
            // 
            // colAug
            // 
            this.colAug.Name = "colAug";
            // 
            // colDez
            // 
            this.colDez.Name = "colDez";
            // 
            // colFeb
            // 
            this.colFeb.Name = "colFeb";
            // 
            // colGrndefrdieDossierrckgabe
            // 
            this.colGrndefrdieDossierrckgabe.Name = "colGrndefrdieDossierrckgabe";
            // 
            // colID
            // 
            this.colID.Name = "colID";
            // 
            // colJan
            // 
            this.colJan.Name = "colJan";
            // 
            // colJul
            // 
            this.colJul.Name = "colJul";
            // 
            // colJun
            // 
            this.colJun.Name = "colJun";
            // 
            // colMai
            // 
            this.colMai.Name = "colMai";
            // 
            // colMrz
            // 
            this.colMrz.Name = "colMrz";
            // 
            // colNov
            // 
            this.colNov.Name = "colNov";
            // 
            // colOkt
            // 
            this.colOkt.Name = "colOkt";
            // 
            // colSep
            // 
            this.colSep.Name = "colSep";
            // 
            // tpgRohdaten
            // 
            this.tpgRohdaten.Controls.Add(this.ctlGotoFallDossierrueckgabe);
            this.tpgRohdaten.Controls.Add(this.grdRohdaten);
            this.tpgRohdaten.Location = new System.Drawing.Point(6, 6);
            this.tpgRohdaten.Name = "tpgRohdaten";
            this.tpgRohdaten.Size = new System.Drawing.Size(772, 424);
            this.tpgRohdaten.TabIndex = 1;
            this.tpgRohdaten.Title = "Rohdaten";
            // 
            // ctlGotoFallDossierrueckgabe
            // 
            this.ctlGotoFallDossierrueckgabe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallDossierrueckgabe.DataMember = "BaPersonID$";
            this.ctlGotoFallDossierrueckgabe.Location = new System.Drawing.Point(3, 397);
            this.ctlGotoFallDossierrueckgabe.Name = "ctlGotoFallDossierrueckgabe";
            this.ctlGotoFallDossierrueckgabe.Size = new System.Drawing.Size(154, 24);
            this.ctlGotoFallDossierrueckgabe.TabIndex = 12;
            // 
            // grdRohdaten
            // 
            this.grdRohdaten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRohdaten.ColumnFilterActivated = true;
            this.grdRohdaten.DataSource = this.qryQuery;
            // 
            // 
            // 
            this.grdRohdaten.EmbeddedNavigator.Name = "";
            this.grdRohdaten.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdRohdaten.Location = new System.Drawing.Point(3, 16);
            this.grdRohdaten.MainView = this.grvRohdaten;
            this.grdRohdaten.Name = "grdRohdaten";
            this.grdRohdaten.Size = new System.Drawing.Size(766, 375);
            this.grdRohdaten.TabIndex = 11;
            this.grdRohdaten.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRohdaten});
            // 
            // grvRohdaten
            // 
            this.grvRohdaten.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvRohdaten.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.Empty.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.Empty.Options.UseFont = true;
            this.grvRohdaten.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvRohdaten.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.EvenRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRohdaten.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvRohdaten.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.FocusedCell.Options.UseFont = true;
            this.grvRohdaten.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvRohdaten.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRohdaten.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvRohdaten.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.FocusedRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvRohdaten.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRohdaten.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRohdaten.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvRohdaten.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRohdaten.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.GroupRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvRohdaten.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvRohdaten.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvRohdaten.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvRohdaten.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvRohdaten.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvRohdaten.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvRohdaten.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRohdaten.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvRohdaten.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvRohdaten.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.OddRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvRohdaten.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.Row.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.Row.Options.UseFont = true;
            this.grvRohdaten.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvRohdaten.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvRohdaten.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.SelectedRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvRohdaten.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvRohdaten.Appearance.VertLine.Options.UseBackColor = true;
            this.grvRohdaten.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvRohdaten.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvRohdaten.GridControl = this.grdRohdaten;
            this.grvRohdaten.Name = "grvRohdaten";
            this.grvRohdaten.OptionsBehavior.Editable = false;
            this.grvRohdaten.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvRohdaten.OptionsNavigation.AutoFocusNewRow = true;
            this.grvRohdaten.OptionsNavigation.UseTabKey = false;
            this.grvRohdaten.OptionsPrint.AutoWidth = false;
            this.grvRohdaten.OptionsPrint.ExpandAllDetails = true;
            this.grvRohdaten.OptionsView.ColumnAutoWidth = false;
            this.grvRohdaten.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvRohdaten.OptionsView.ShowGroupPanel = false;
            this.grvRohdaten.OptionsView.ShowIndicator = false;
            this.grvRohdaten.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvRohdaten_FocusedRowChanged);
            // 
            // CtlQueryKaAbklDossierrueckgabe
            // 
            this.Name = "CtlQueryKaAbklDossierrueckgabe";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            this.tpgRohdaten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRohdaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRohdaten)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpLibrary.WinControls.TabPageEx tpgRohdaten;
        private Gui.KissGrid grdRohdaten;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRohdaten;
        private Common.CtlGotoFall ctlGotoFallDossierrueckgabe;

    }
}