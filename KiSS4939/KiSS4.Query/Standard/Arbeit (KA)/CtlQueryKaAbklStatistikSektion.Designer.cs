using System;
using KiSS4.DB;

namespace KiSS4.Query
{
    partial class CtlQueryKaAbklStatistikSektion
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaAbklStatistikSektion));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tpgSource1 = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFallStelleBI = new KiSS4.Common.CtlGotoFall();
            this.qryRohdaten1 = new KiSS4.DB.SqlQuery(this.components);
            this.grdRohdaten1 = new KiSS4.Gui.KissGrid();
            this.grvRohdaten1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtAuswZuweiser = new KiSS4.Gui.KissLookUpEdit();
            this.edtAuswAlter = new KiSS4.Gui.KissLookUpEdit();
            this.edtAuswAnmeldung = new KiSS4.Gui.KissLookUpEdit();
            this.lblDatumVonBis = new KiSS4.Gui.KissLabel();
            this.lblZuweiser = new KiSS4.Gui.KissLabel();
            this.lblAlter = new KiSS4.Gui.KissLabel();
            this.lblAnmeldung = new KiSS4.Gui.KissLabel();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.colAbklrungPhaseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnmeldung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnmeldungCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAug = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumIntegrationsbeurteilung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumPhase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDez = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErffnungsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaLeistungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFeb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInstitution = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInstitutionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntegrationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumIntegration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntegrationsbeurteilung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJul = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJun = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKaAKPhasenID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMrz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitaet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNov = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOkt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhasenCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusWarteliste = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtModulVertAbklCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblModulVertAbkl = new KiSS4.Gui.KissLabel();
            this.edtModulIntakeCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblPhase = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.tpgSource1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryRohdaten1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRohdaten1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRohdaten1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswZuweiser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswZuweiser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswAlter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswAlter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswAnmeldung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswAnmeldung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVonBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZuweiser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAlter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnmeldung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulVertAbklCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulVertAbklCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulVertAbkl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulIntakeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulIntakeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPhase)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
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
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
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
            this.grdQuery1.MainView = this.gridView1;
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            this.tabControlSearch.Controls.Add(this.tpgSource1);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgSource1});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSource1, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtModulVertAbklCode);
            this.tpgSuchen.Controls.Add(this.lblModulVertAbkl);
            this.tpgSuchen.Controls.Add(this.edtModulIntakeCode);
            this.tpgSuchen.Controls.Add(this.lblPhase);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.lblAnmeldung);
            this.tpgSuchen.Controls.Add(this.lblAlter);
            this.tpgSuchen.Controls.Add(this.lblZuweiser);
            this.tpgSuchen.Controls.Add(this.lblDatumVonBis);
            this.tpgSuchen.Controls.Add(this.edtAuswAnmeldung);
            this.tpgSuchen.Controls.Add(this.edtAuswAlter);
            this.tpgSuchen.Controls.Add(this.edtAuswZuweiser);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.TabIndex = 4;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAuswZuweiser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAuswAlter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAuswAnmeldung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumVonBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZuweiser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAlter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAnmeldung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblPhase, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtModulIntakeCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblModulVertAbkl, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtModulVertAbklCode, 0);
            // 
            // tpgSource1
            // 
            this.tpgSource1.Controls.Add(this.ctlGotoFallStelleBI);
            this.tpgSource1.Controls.Add(this.grdRohdaten1);
            this.tpgSource1.Location = new System.Drawing.Point(6, 6);
            this.tpgSource1.Name = "tpgSource1";
            this.tpgSource1.Size = new System.Drawing.Size(772, 424);
            this.tpgSource1.TabIndex = 1;
            this.tpgSource1.Title = "Rohdaten";
            // 
            // ctlGotoFallStelleBI
            // 
            this.ctlGotoFallStelleBI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallStelleBI.DataMember = "BaPersonID$";
            this.ctlGotoFallStelleBI.DataSource = this.qryRohdaten1;
            this.ctlGotoFallStelleBI.Location = new System.Drawing.Point(3, 399);
            this.ctlGotoFallStelleBI.Name = "ctlGotoFallStelleBI";
            this.ctlGotoFallStelleBI.Size = new System.Drawing.Size(154, 24);
            this.ctlGotoFallStelleBI.TabIndex = 5;
            // 
            // qryRohdaten1
            // 
            this.qryRohdaten1.HostControl = this;
            this.qryRohdaten1.SelectStatement = resources.GetString("qryRohdaten1.SelectStatement");
            // 
            // grdRohdaten1
            // 
            this.grdRohdaten1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRohdaten1.ColumnFilterActivated = true;
            this.grdRohdaten1.DataSource = this.qryRohdaten1;
            // 
            // 
            // 
            this.grdRohdaten1.EmbeddedNavigator.Name = "";
            this.grdRohdaten1.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdRohdaten1.Location = new System.Drawing.Point(3, 1);
            this.grdRohdaten1.MainView = this.grvRohdaten1;
            this.grdRohdaten1.Name = "grdRohdaten1";
            this.grdRohdaten1.Size = new System.Drawing.Size(766, 392);
            this.grdRohdaten1.TabIndex = 4;
            this.grdRohdaten1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRohdaten1});
            // 
            // grvRohdaten1
            // 
            this.grvRohdaten1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvRohdaten1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten1.Appearance.Empty.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.Empty.Options.UseFont = true;
            this.grvRohdaten1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten1.Appearance.EvenRow.Options.UseFont = true;
            this.grvRohdaten1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRohdaten1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvRohdaten1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvRohdaten1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvRohdaten1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRohdaten1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvRohdaten1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvRohdaten1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvRohdaten1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRohdaten1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRohdaten1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvRohdaten1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRohdaten1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.GroupRow.Options.UseFont = true;
            this.grvRohdaten1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvRohdaten1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvRohdaten1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvRohdaten1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvRohdaten1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvRohdaten1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvRohdaten1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvRohdaten1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRohdaten1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvRohdaten1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvRohdaten1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvRohdaten1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten1.Appearance.OddRow.Options.UseFont = true;
            this.grvRohdaten1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvRohdaten1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten1.Appearance.Row.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.Row.Options.UseFont = true;
            this.grvRohdaten1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvRohdaten1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvRohdaten1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvRohdaten1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvRohdaten1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvRohdaten1.GridControl = this.grdRohdaten1;
            this.grvRohdaten1.Name = "grvRohdaten1";
            this.grvRohdaten1.OptionsBehavior.Editable = false;
            this.grvRohdaten1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvRohdaten1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvRohdaten1.OptionsNavigation.UseTabKey = false;
            this.grvRohdaten1.OptionsView.ColumnAutoWidth = false;
            this.grvRohdaten1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvRohdaten1.OptionsView.ShowGroupPanel = false;
            this.grvRohdaten1.OptionsView.ShowIndicator = false;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = "";
            this.edtDatumVon.Location = new System.Drawing.Point(180, 52);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 1;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = "";
            this.edtDatumBis.Location = new System.Drawing.Point(330, 52);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 2;
            // 
            // edtAuswZuweiser
            // 
            this.edtAuswZuweiser.Location = new System.Drawing.Point(180, 82);
            this.edtAuswZuweiser.Name = "edtAuswZuweiser";
            this.edtAuswZuweiser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuswZuweiser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuswZuweiser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswZuweiser.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuswZuweiser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuswZuweiser.Properties.Appearance.Options.UseFont = true;
            this.edtAuswZuweiser.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAuswZuweiser.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswZuweiser.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAuswZuweiser.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAuswZuweiser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtAuswZuweiser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtAuswZuweiser.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuswZuweiser.Properties.NullText = "";
            this.edtAuswZuweiser.Properties.ShowFooter = false;
            this.edtAuswZuweiser.Properties.ShowHeader = false;
            this.edtAuswZuweiser.Size = new System.Drawing.Size(250, 24);
            this.edtAuswZuweiser.TabIndex = 3;
            // 
            // edtAuswAlter
            // 
            this.edtAuswAlter.Location = new System.Drawing.Point(180, 115);
            this.edtAuswAlter.Name = "edtAuswAlter";
            this.edtAuswAlter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuswAlter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuswAlter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswAlter.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuswAlter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuswAlter.Properties.Appearance.Options.UseFont = true;
            this.edtAuswAlter.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAuswAlter.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswAlter.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAuswAlter.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAuswAlter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtAuswAlter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtAuswAlter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuswAlter.Properties.NullText = "";
            this.edtAuswAlter.Properties.ShowFooter = false;
            this.edtAuswAlter.Properties.ShowHeader = false;
            this.edtAuswAlter.Size = new System.Drawing.Size(250, 24);
            this.edtAuswAlter.TabIndex = 4;
            // 
            // edtAuswAnmeldung
            // 
            this.edtAuswAnmeldung.Location = new System.Drawing.Point(180, 145);
            this.edtAuswAnmeldung.Name = "edtAuswAnmeldung";
            this.edtAuswAnmeldung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuswAnmeldung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuswAnmeldung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswAnmeldung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuswAnmeldung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuswAnmeldung.Properties.Appearance.Options.UseFont = true;
            this.edtAuswAnmeldung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAuswAnmeldung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswAnmeldung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAuswAnmeldung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAuswAnmeldung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtAuswAnmeldung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtAuswAnmeldung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuswAnmeldung.Properties.NullText = "";
            this.edtAuswAnmeldung.Properties.ShowFooter = false;
            this.edtAuswAnmeldung.Properties.ShowHeader = false;
            this.edtAuswAnmeldung.Size = new System.Drawing.Size(250, 24);
            this.edtAuswAnmeldung.TabIndex = 5;
            // 
            // lblDatumVonBis
            // 
            this.lblDatumVonBis.Location = new System.Drawing.Point(7, 52);
            this.lblDatumVonBis.Name = "lblDatumVonBis";
            this.lblDatumVonBis.Size = new System.Drawing.Size(157, 24);
            this.lblDatumVonBis.TabIndex = 6;
            this.lblDatumVonBis.Text = "Datum von";
            this.lblDatumVonBis.UseCompatibleTextRendering = true;
            // 
            // lblZuweiser
            // 
            this.lblZuweiser.Location = new System.Drawing.Point(7, 82);
            this.lblZuweiser.Name = "lblZuweiser";
            this.lblZuweiser.Size = new System.Drawing.Size(157, 24);
            this.lblZuweiser.TabIndex = 7;
            this.lblZuweiser.Text = "Zuweiser";
            this.lblZuweiser.UseCompatibleTextRendering = true;
            // 
            // lblAlter
            // 
            this.lblAlter.Location = new System.Drawing.Point(7, 115);
            this.lblAlter.Name = "lblAlter";
            this.lblAlter.Size = new System.Drawing.Size(157, 24);
            this.lblAlter.TabIndex = 8;
            this.lblAlter.Text = "Alter";
            this.lblAlter.UseCompatibleTextRendering = true;
            // 
            // lblAnmeldung
            // 
            this.lblAnmeldung.Location = new System.Drawing.Point(7, 145);
            this.lblAnmeldung.Name = "lblAnmeldung";
            this.lblAnmeldung.Size = new System.Drawing.Size(157, 24);
            this.lblAnmeldung.TabIndex = 9;
            this.lblAnmeldung.Text = "Anmeldung";
            this.lblAnmeldung.UseCompatibleTextRendering = true;
            // 
            // lblbis
            // 
            this.lblbis.Location = new System.Drawing.Point(298, 52);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(26, 24);
            this.lblbis.TabIndex = 10;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            // 
            // colAbklrungPhaseID
            // 
            this.colAbklrungPhaseID.Name = "colAbklrungPhaseID";
            // 
            // colAlter
            // 
            this.colAlter.Name = "colAlter";
            // 
            // colAnmeldung
            // 
            this.colAnmeldung.Name = "colAnmeldung";
            // 
            // colAnmeldungCode
            // 
            this.colAnmeldungCode.Name = "colAnmeldungCode";
            // 
            // colApr
            // 
            this.colApr.Name = "colApr";
            // 
            // colAug
            // 
            this.colAug.Name = "colAug";
            // 
            // colBaPersonID
            // 
            this.colBaPersonID.Name = "colBaPersonID";
            // 
            // colDatum
            // 
            this.colDatum.Name = "colDatum";
            // 
            // colDatumIntegrationsbeurteilung
            // 
            this.colDatumIntegrationsbeurteilung.Name = "colDatumIntegrationsbeurteilung";
            // 
            // colDatumPhase
            // 
            this.colDatumPhase.Name = "colDatumPhase";
            // 
            // colDez
            // 
            this.colDez.Name = "colDez";
            // 
            // colErffnungsdatum
            // 
            this.colErffnungsdatum.Name = "colErffnungsdatum";
            // 
            // colFaDatumVon
            // 
            this.colFaDatumVon.Name = "colFaDatumVon";
            // 
            // colFaLeistungID
            // 
            this.colFaLeistungID.Name = "colFaLeistungID";
            // 
            // colFeb
            // 
            this.colFeb.Name = "colFeb";
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.Name = "colGeschlecht";
            // 
            // colID
            // 
            this.colID.Name = "colID";
            // 
            // colInstitution
            // 
            this.colInstitution.Name = "colInstitution";
            // 
            // colInstitutionID
            // 
            this.colInstitutionID.Name = "colInstitutionID";
            // 
            // colIntegrationCode
            // 
            this.colIntegrationCode.Name = "colIntegrationCode";
            // 
            // colDatumIntegration
            // 
            this.colDatumIntegration.Name = "colDatumIntegration";
            // 
            // colIntegrationsbeurteilung
            // 
            this.colIntegrationsbeurteilung.Name = "colIntegrationsbeurteilung";
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
            // colKaAKPhasenID
            // 
            this.colKaAKPhasenID.Name = "colKaAKPhasenID";
            // 
            // colLeistungID
            // 
            this.colLeistungID.Name = "colLeistungID";
            // 
            // colMai
            // 
            this.colMai.Name = "colMai";
            // 
            // colMrz
            // 
            this.colMrz.Name = "colMrz";
            // 
            // colName
            // 
            this.colName.Name = "colName";
            // 
            // colNationalitaet
            // 
            this.colNationalitaet.Name = "colNationalitaet";
            // 
            // colNationalitt
            // 
            this.colNationalitt.Name = "colNationalitt";
            // 
            // colNov
            // 
            this.colNov.Name = "colNov";
            // 
            // colOkt
            // 
            this.colOkt.Name = "colOkt";
            // 
            // colPeriode
            // 
            this.colPeriode.Name = "colPeriode";
            // 
            // colPersNr
            // 
            this.colPersNr.Name = "colPersNr";
            // 
            // colPhase
            // 
            this.colPhase.Name = "colPhase";
            // 
            // colPhasenCode
            // 
            this.colPhasenCode.Name = "colPhasenCode";
            // 
            // colSep
            // 
            this.colSep.Name = "colSep";
            // 
            // colStatusCode
            // 
            this.colStatusCode.Name = "colStatusCode";
            // 
            // colStatusWarteliste
            // 
            this.colStatusWarteliste.Name = "colStatusWarteliste";
            // 
            // colText
            // 
            this.colText.Name = "colText";
            // 
            // colVorname
            // 
            this.colVorname.Name = "colVorname";
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // edtModulVertAbklCode
            // 
            this.edtModulVertAbklCode.FilterOnIsActive = false;
            this.edtModulVertAbklCode.Location = new System.Drawing.Point(180, 205);
            this.edtModulVertAbklCode.LOVName = "KaAbklaerungPhaseVertiefteAbklaerungen";
            this.edtModulVertAbklCode.Name = "edtModulVertAbklCode";
            this.edtModulVertAbklCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtModulVertAbklCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModulVertAbklCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulVertAbklCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtModulVertAbklCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModulVertAbklCode.Properties.Appearance.Options.UseFont = true;
            this.edtModulVertAbklCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtModulVertAbklCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulVertAbklCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtModulVertAbklCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtModulVertAbklCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtModulVertAbklCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtModulVertAbklCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtModulVertAbklCode.Properties.NullText = "";
            this.edtModulVertAbklCode.Properties.ShowFooter = false;
            this.edtModulVertAbklCode.Properties.ShowHeader = false;
            this.edtModulVertAbklCode.Size = new System.Drawing.Size(250, 24);
            this.edtModulVertAbklCode.TabIndex = 20;
            // 
            // lblModulVertAbkl
            // 
            this.lblModulVertAbkl.Location = new System.Drawing.Point(7, 205);
            this.lblModulVertAbkl.Name = "lblModulVertAbkl";
            this.lblModulVertAbkl.Size = new System.Drawing.Size(157, 24);
            this.lblModulVertAbkl.TabIndex = 19;
            this.lblModulVertAbkl.Text = "Modul vertiefte Abklärung";
            this.lblModulVertAbkl.UseCompatibleTextRendering = true;
            // 
            // edtModulIntakeCode
            // 
            this.edtModulIntakeCode.FilterOnIsActive = false;
            this.edtModulIntakeCode.Location = new System.Drawing.Point(180, 175);
            this.edtModulIntakeCode.LOVName = "KaAbklaerungPhaseIntake";
            this.edtModulIntakeCode.Name = "edtModulIntakeCode";
            this.edtModulIntakeCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtModulIntakeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModulIntakeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulIntakeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtModulIntakeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModulIntakeCode.Properties.Appearance.Options.UseFont = true;
            this.edtModulIntakeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtModulIntakeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulIntakeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtModulIntakeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtModulIntakeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtModulIntakeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtModulIntakeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtModulIntakeCode.Properties.NullText = "";
            this.edtModulIntakeCode.Properties.ShowFooter = false;
            this.edtModulIntakeCode.Properties.ShowHeader = false;
            this.edtModulIntakeCode.Size = new System.Drawing.Size(250, 24);
            this.edtModulIntakeCode.TabIndex = 18;
            // 
            // lblPhase
            // 
            this.lblPhase.Location = new System.Drawing.Point(7, 175);
            this.lblPhase.Name = "lblPhase";
            this.lblPhase.Size = new System.Drawing.Size(157, 24);
            this.lblPhase.TabIndex = 17;
            this.lblPhase.Text = "Modul Intake";
            this.lblPhase.UseCompatibleTextRendering = true;
            // 
            // CtlQueryKaAbklStatistikSektion
            // 
            this.Name = "CtlQueryKaAbklStatistikSektion";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            this.tpgSource1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryRohdaten1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRohdaten1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRohdaten1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswZuweiser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswZuweiser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswAlter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswAlter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswAnmeldung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswAnmeldung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVonBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZuweiser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAlter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnmeldung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulVertAbklCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulVertAbklCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulVertAbkl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulIntakeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulIntakeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPhase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colAbklrungPhaseID;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colAnmeldung;
        private DevExpress.XtraGrid.Columns.GridColumn colAnmeldungCode;
        private DevExpress.XtraGrid.Columns.GridColumn colApr;
        private DevExpress.XtraGrid.Columns.GridColumn colAug;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumIntegrationsbeurteilung;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumPhase;
        private DevExpress.XtraGrid.Columns.GridColumn colDez;
        private DevExpress.XtraGrid.Columns.GridColumn colErffnungsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colFaDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colFaLeistungID;
        private DevExpress.XtraGrid.Columns.GridColumn colFeb;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colInstitution;
        private DevExpress.XtraGrid.Columns.GridColumn colInstitutionID;
        private DevExpress.XtraGrid.Columns.GridColumn colIntegrationCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumIntegration;
        private DevExpress.XtraGrid.Columns.GridColumn colIntegrationsbeurteilung;
        private DevExpress.XtraGrid.Columns.GridColumn colJan;
        private DevExpress.XtraGrid.Columns.GridColumn colJul;
        private DevExpress.XtraGrid.Columns.GridColumn colJun;
        private DevExpress.XtraGrid.Columns.GridColumn colKaAKPhasenID;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistungID;
        private DevExpress.XtraGrid.Columns.GridColumn colMai;
        private DevExpress.XtraGrid.Columns.GridColumn colMrz;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitaet;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colNov;
        private DevExpress.XtraGrid.Columns.GridColumn colOkt;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriode;
        private DevExpress.XtraGrid.Columns.GridColumn colPersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colPhase;
        private DevExpress.XtraGrid.Columns.GridColumn colPhasenCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSep;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusWarteliste;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlGotoFall ctlGotoFallStelleBI;
        private KiSS4.Gui.KissLookUpEdit edtAuswAlter;
        private KiSS4.Gui.KissLookUpEdit edtAuswAnmeldung;
        private KiSS4.Gui.KissLookUpEdit edtAuswZuweiser;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissGrid grdRohdaten1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRohdaten1;
        private KiSS4.Gui.KissLabel lblAlter;
        private KiSS4.Gui.KissLabel lblAnmeldung;
        private KiSS4.Gui.KissLabel lblDatumVonBis;
        private KiSS4.Gui.KissLabel lblZuweiser;
        private KiSS4.Gui.KissLabel lblbis;
        private KiSS4.DB.SqlQuery qryRohdaten1;
        private SharpLibrary.WinControls.TabPageEx tpgSource1;
        private Gui.KissLookUpEdit edtModulVertAbklCode;
        private Gui.KissLabel lblModulVertAbkl;
        private Gui.KissLookUpEdit edtModulIntakeCode;
        private Gui.KissLabel lblPhase;
    }
}