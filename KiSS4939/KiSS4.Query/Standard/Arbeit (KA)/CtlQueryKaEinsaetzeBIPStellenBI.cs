using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common;
using System;

namespace KiSS4.Query
{
    public class CtlQueryKaEinsaetzeBIPStellenBI : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn col1Zwischenbericht;
        private DevExpress.XtraGrid.Columns.GridColumn col2Zwischenbericht;
        private DevExpress.XtraGrid.Columns.GridColumn colAbschlussgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungenEAZ;
        private DevExpress.XtraGrid.Columns.GridColumn colBeteiligungEAZ;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrieb;
        private DevExpress.XtraGrid.Columns.GridColumn colBruttolohn;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzab;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzbis;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzende;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzplatz;
        private DevExpress.XtraGrid.Columns.GridColumn colFeststellungsb;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPraktikumsvereinb;
        private DevExpress.XtraGrid.Columns.GridColumn colStelleab;
        private DevExpress.XtraGrid.Columns.GridColumn colStellebis;
        private DevExpress.XtraGrid.Columns.GridColumn colStellenende;
        private DevExpress.XtraGrid.Columns.GridColumn colUnterz;
        private DevExpress.XtraGrid.Columns.GridColumn colVereinbarungEAZ;
        private DevExpress.XtraGrid.Columns.GridColumn colVerlngerung;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colerhalten;
        private DevExpress.XtraGrid.Columns.GridColumn colerhalten1;
        private DevExpress.XtraGrid.Columns.GridColumn colunterschr;
        private DevExpress.XtraGrid.Columns.GridColumn colunterschr1;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlGotoFall ctlGotoFallStelleBI;
        private KiSS4.Gui.KissDateEdit edtEinsatzBeginnBis;
        private KiSS4.Gui.KissTextEdit edtEinsatzplatz;
        private KiSS4.Gui.KissButtonEdit edtNameSTESID;
        private KiSS4.Gui.KissGrid grdStelleBI;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStelleBI;
        private KiSS4.Gui.KissLabel lblBetrieb;
        private KiSS4.Gui.KissLabel lblEinsatzBeginnBis;
        private KiSS4.Gui.KissLabel lblEinsatzplatz;
        private KiSS4.Gui.KissLabel lblNameSTES;
        private KiSS4.DB.SqlQuery qryStelleBI;
        private KissDateEdit edtEinsatzStelleVon;
        private KissLabel lblEinsatzStelleVon;
        private KissDateEdit edtEinsatzStelleBis;
        private KissLabel lblEinsatzStelleBis;
        private KissButtonEdit edtBetriebAuswahl;
        private SharpLibrary.WinControls.TabPageEx tpgListeStelleBI;

        #endregion

        #region Constructors

        public CtlQueryKaEinsaetzeBIPStellenBI()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaEinsaetzeBIPStellenBI));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tpgListeStelleBI = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFallStelleBI = new KiSS4.Common.CtlGotoFall();
            this.qryStelleBI = new KiSS4.DB.SqlQuery(this.components);
            this.grdStelleBI = new KiSS4.Gui.KissGrid();
            this.grvStelleBI = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtNameSTESID = new KiSS4.Gui.KissButtonEdit();
            this.edtEinsatzplatz = new KiSS4.Gui.KissTextEdit();
            this.edtEinsatzBeginnBis = new KiSS4.Gui.KissDateEdit();
            this.lblNameSTES = new KiSS4.Gui.KissLabel();
            this.lblEinsatzplatz = new KiSS4.Gui.KissLabel();
            this.lblBetrieb = new KiSS4.Gui.KissLabel();
            this.lblEinsatzBeginnBis = new KiSS4.Gui.KissLabel();
            this.col1Zwischenbericht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col2Zwischenbericht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbschlussgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkungenEAZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeteiligungEAZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrieb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBruttolohn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzab = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzbis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzende = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzplatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colerhalten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colerhalten1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFeststellungsb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPraktikumsvereinb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStelleab = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStellebis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStellenende = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colunterschr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colunterschr1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnterz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVereinbarungEAZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerlngerung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtEinsatzStelleVon = new KiSS4.Gui.KissDateEdit();
            this.edtEinsatzStelleBis = new KiSS4.Gui.KissDateEdit();
            this.lblEinsatzStelleVon = new KiSS4.Gui.KissLabel();
            this.lblEinsatzStelleBis = new KiSS4.Gui.KissLabel();
            this.edtBetriebAuswahl = new KiSS4.Gui.KissButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.tpgListeStelleBI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryStelleBI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStelleBI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStelleBI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSTESID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzBeginnBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSTES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzBeginnBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzStelleVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzStelleBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzStelleVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzStelleBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebAuswahl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
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
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgListeStelleBI);
            this.tabControlSearch.Location = new System.Drawing.Point(3, 35);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListeStelleBI});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListeStelleBI, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Title = "Einsatz BIP";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtBetriebAuswahl);
            this.tpgSuchen.Controls.Add(this.lblEinsatzStelleBis);
            this.tpgSuchen.Controls.Add(this.lblEinsatzStelleVon);
            this.tpgSuchen.Controls.Add(this.edtEinsatzStelleBis);
            this.tpgSuchen.Controls.Add(this.edtEinsatzStelleVon);
            this.tpgSuchen.Controls.Add(this.lblEinsatzBeginnBis);
            this.tpgSuchen.Controls.Add(this.lblBetrieb);
            this.tpgSuchen.Controls.Add(this.lblEinsatzplatz);
            this.tpgSuchen.Controls.Add(this.lblNameSTES);
            this.tpgSuchen.Controls.Add(this.edtEinsatzBeginnBis);
            this.tpgSuchen.Controls.Add(this.edtEinsatzplatz);
            this.tpgSuchen.Controls.Add(this.edtNameSTESID);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.TabIndex = 2;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNameSTESID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEinsatzplatz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEinsatzBeginnBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNameSTES, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEinsatzplatz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBetrieb, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEinsatzBeginnBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEinsatzStelleVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEinsatzStelleBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEinsatzStelleVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEinsatzStelleBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBetriebAuswahl, 0);
            // 
            // tpgListeStelleBI
            // 
            this.tpgListeStelleBI.Controls.Add(this.ctlGotoFallStelleBI);
            this.tpgListeStelleBI.Controls.Add(this.grdStelleBI);
            this.tpgListeStelleBI.Location = new System.Drawing.Point(6, 6);
            this.tpgListeStelleBI.Name = "tpgListeStelleBI";
            this.tpgListeStelleBI.Size = new System.Drawing.Size(772, 424);
            this.tpgListeStelleBI.TabIndex = 1;
            this.tpgListeStelleBI.Title = "Stelle BI";
            // 
            // ctlGotoFallStelleBI
            // 
            this.ctlGotoFallStelleBI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallStelleBI.BaPersonID = ((object)(resources.GetObject("ctlGotoFallStelleBI.BaPersonID")));
            this.ctlGotoFallStelleBI.DataMember = "BaPersonID$";
            this.ctlGotoFallStelleBI.DataSource = this.qryStelleBI;
            this.ctlGotoFallStelleBI.Location = new System.Drawing.Point(3, 398);
            this.ctlGotoFallStelleBI.Name = "ctlGotoFallStelleBI";
            this.ctlGotoFallStelleBI.Size = new System.Drawing.Size(154, 24);
            this.ctlGotoFallStelleBI.TabIndex = 1;
            // 
            // qryStelleBI
            // 
            this.qryStelleBI.HostControl = this;
            this.qryStelleBI.SelectStatement = resources.GetString("qryStelleBI.SelectStatement");
            // 
            // grdStelleBI
            // 
            this.grdStelleBI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdStelleBI.ColumnFilterActivated = true;
            this.grdStelleBI.DataSource = this.qryStelleBI;
            this.grdStelleBI.EmbeddedNavigator.Name = "";
            this.grdStelleBI.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdStelleBI.Location = new System.Drawing.Point(3, 0);
            this.grdStelleBI.MainView = this.grvStelleBI;
            this.grdStelleBI.Name = "grdStelleBI";
            this.grdStelleBI.Size = new System.Drawing.Size(766, 392);
            this.grdStelleBI.TabIndex = 0;
            this.grdStelleBI.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStelleBI});
            // 
            // grvStelleBI
            // 
            this.grvStelleBI.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvStelleBI.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvStelleBI.Appearance.Empty.Options.UseBackColor = true;
            this.grvStelleBI.Appearance.Empty.Options.UseFont = true;
            this.grvStelleBI.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvStelleBI.Appearance.EvenRow.Options.UseFont = true;
            this.grvStelleBI.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvStelleBI.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvStelleBI.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvStelleBI.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvStelleBI.Appearance.FocusedCell.Options.UseFont = true;
            this.grvStelleBI.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvStelleBI.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvStelleBI.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvStelleBI.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvStelleBI.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvStelleBI.Appearance.FocusedRow.Options.UseFont = true;
            this.grvStelleBI.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvStelleBI.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvStelleBI.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvStelleBI.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvStelleBI.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvStelleBI.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvStelleBI.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvStelleBI.Appearance.GroupRow.Options.UseFont = true;
            this.grvStelleBI.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvStelleBI.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvStelleBI.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvStelleBI.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvStelleBI.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvStelleBI.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvStelleBI.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvStelleBI.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvStelleBI.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvStelleBI.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvStelleBI.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvStelleBI.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvStelleBI.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvStelleBI.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvStelleBI.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvStelleBI.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvStelleBI.Appearance.OddRow.Options.UseFont = true;
            this.grvStelleBI.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvStelleBI.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvStelleBI.Appearance.Row.Options.UseBackColor = true;
            this.grvStelleBI.Appearance.Row.Options.UseFont = true;
            this.grvStelleBI.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvStelleBI.Appearance.SelectedRow.Options.UseFont = true;
            this.grvStelleBI.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvStelleBI.Appearance.VertLine.Options.UseBackColor = true;
            this.grvStelleBI.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvStelleBI.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvStelleBI.GridControl = this.grdStelleBI;
            this.grvStelleBI.Name = "grvStelleBI";
            this.grvStelleBI.OptionsBehavior.Editable = false;
            this.grvStelleBI.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvStelleBI.OptionsNavigation.AutoFocusNewRow = true;
            this.grvStelleBI.OptionsNavigation.UseTabKey = false;
            this.grvStelleBI.OptionsView.ColumnAutoWidth = false;
            this.grvStelleBI.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvStelleBI.OptionsView.ShowGroupPanel = false;
            this.grvStelleBI.OptionsView.ShowIndicator = false;
            // 
            // edtNameSTESID
            // 
            this.edtNameSTESID.Location = new System.Drawing.Point(166, 40);
            this.edtNameSTESID.Name = "edtNameSTESID";
            this.edtNameSTESID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameSTESID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameSTESID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameSTESID.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameSTESID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameSTESID.Properties.Appearance.Options.UseFont = true;
            this.edtNameSTESID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtNameSTESID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtNameSTESID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameSTESID.Size = new System.Drawing.Size(250, 24);
            this.edtNameSTESID.TabIndex = 1;
            this.edtNameSTESID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtNameSTESID_UserModifiedFld);
            // 
            // edtEinsatzplatz
            // 
            this.edtEinsatzplatz.Location = new System.Drawing.Point(166, 70);
            this.edtEinsatzplatz.Name = "edtEinsatzplatz";
            this.edtEinsatzplatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzplatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzplatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzplatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzplatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzplatz.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzplatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinsatzplatz.Size = new System.Drawing.Size(250, 24);
            this.edtEinsatzplatz.TabIndex = 2;
            // 
            // edtEinsatzBeginnBis
            // 
            this.edtEinsatzBeginnBis.EditValue = "";
            this.edtEinsatzBeginnBis.Location = new System.Drawing.Point(166, 160);
            this.edtEinsatzBeginnBis.Name = "edtEinsatzBeginnBis";
            this.edtEinsatzBeginnBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinsatzBeginnBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzBeginnBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzBeginnBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzBeginnBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzBeginnBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzBeginnBis.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzBeginnBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtEinsatzBeginnBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzBeginnBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtEinsatzBeginnBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzBeginnBis.Properties.ShowToday = false;
            this.edtEinsatzBeginnBis.Size = new System.Drawing.Size(100, 24);
            this.edtEinsatzBeginnBis.TabIndex = 6;
            this.edtEinsatzBeginnBis.EditValueChanged += new System.EventHandler(this.edtEinsatzBeginnBis_EditValueChanged);
            // 
            // lblNameSTES
            // 
            this.lblNameSTES.Location = new System.Drawing.Point(30, 40);
            this.lblNameSTES.Name = "lblNameSTES";
            this.lblNameSTES.Size = new System.Drawing.Size(130, 24);
            this.lblNameSTES.TabIndex = 5;
            this.lblNameSTES.Text = "STES";
            this.lblNameSTES.UseCompatibleTextRendering = true;
            // 
            // lblEinsatzplatz
            // 
            this.lblEinsatzplatz.Location = new System.Drawing.Point(30, 70);
            this.lblEinsatzplatz.Name = "lblEinsatzplatz";
            this.lblEinsatzplatz.Size = new System.Drawing.Size(130, 24);
            this.lblEinsatzplatz.TabIndex = 6;
            this.lblEinsatzplatz.Text = "Einsatzplatz";
            this.lblEinsatzplatz.UseCompatibleTextRendering = true;
            // 
            // lblBetrieb
            // 
            this.lblBetrieb.Location = new System.Drawing.Point(30, 100);
            this.lblBetrieb.Name = "lblBetrieb";
            this.lblBetrieb.Size = new System.Drawing.Size(130, 24);
            this.lblBetrieb.TabIndex = 7;
            this.lblBetrieb.Text = "Betrieb";
            this.lblBetrieb.UseCompatibleTextRendering = true;
            // 
            // lblEinsatzBeginnBis
            // 
            this.lblEinsatzBeginnBis.Location = new System.Drawing.Point(30, 160);
            this.lblEinsatzBeginnBis.Name = "lblEinsatzBeginnBis";
            this.lblEinsatzBeginnBis.Size = new System.Drawing.Size(130, 24);
            this.lblEinsatzBeginnBis.TabIndex = 8;
            this.lblEinsatzBeginnBis.Text = "Einsatz/Stellebeginn bis";
            this.lblEinsatzBeginnBis.UseCompatibleTextRendering = true;
            // 
            // col1Zwischenbericht
            // 
            this.col1Zwischenbericht.Name = "col1Zwischenbericht";
            // 
            // col2Zwischenbericht
            // 
            this.col2Zwischenbericht.Name = "col2Zwischenbericht";
            // 
            // colAbschlussgrund
            // 
            this.colAbschlussgrund.Name = "colAbschlussgrund";
            // 
            // colBemerkung
            // 
            this.colBemerkung.Name = "colBemerkung";
            // 
            // colBemerkungen
            // 
            this.colBemerkungen.Name = "colBemerkungen";
            // 
            // colBemerkungenEAZ
            // 
            this.colBemerkungenEAZ.Name = "colBemerkungenEAZ";
            // 
            // colBeteiligungEAZ
            // 
            this.colBeteiligungEAZ.Name = "colBeteiligungEAZ";
            // 
            // colBetrieb
            // 
            this.colBetrieb.Name = "colBetrieb";
            // 
            // colBruttolohn
            // 
            this.colBruttolohn.Name = "colBruttolohn";
            // 
            // colEinsatzab
            // 
            this.colEinsatzab.Name = "colEinsatzab";
            // 
            // colEinsatzbis
            // 
            this.colEinsatzbis.Name = "colEinsatzbis";
            // 
            // colEinsatzende
            // 
            this.colEinsatzende.Name = "colEinsatzende";
            // 
            // colEinsatzplatz
            // 
            this.colEinsatzplatz.Name = "colEinsatzplatz";
            // 
            // colerhalten
            // 
            this.colerhalten.Name = "colerhalten";
            // 
            // colerhalten1
            // 
            this.colerhalten1.Name = "colerhalten1";
            // 
            // colFeststellungsb
            // 
            this.colFeststellungsb.Name = "colFeststellungsb";
            // 
            // colName
            // 
            this.colName.Name = "colName";
            // 
            // colPraktikumsvereinb
            // 
            this.colPraktikumsvereinb.Name = "colPraktikumsvereinb";
            // 
            // colStelleab
            // 
            this.colStelleab.Name = "colStelleab";
            // 
            // colStellebis
            // 
            this.colStellebis.Name = "colStellebis";
            // 
            // colStellenende
            // 
            this.colStellenende.Name = "colStellenende";
            // 
            // colunterschr
            // 
            this.colunterschr.Name = "colunterschr";
            // 
            // colunterschr1
            // 
            this.colunterschr1.Name = "colunterschr1";
            // 
            // colUnterz
            // 
            this.colUnterz.Name = "colUnterz";
            // 
            // colVereinbarungEAZ
            // 
            this.colVereinbarungEAZ.Name = "colVereinbarungEAZ";
            // 
            // colVerlngerung
            // 
            this.colVerlngerung.Name = "colVerlngerung";
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
            // gridView2
            // 
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView2.Appearance.EvenRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsPrint.AutoWidth = false;
            this.gridView2.OptionsPrint.ExpandAllDetails = true;
            this.gridView2.OptionsPrint.UsePrintStyles = true;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // gridView3
            // 
            this.gridView3.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView3.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.Empty.Options.UseBackColor = true;
            this.gridView3.Appearance.Empty.Options.UseFont = true;
            this.gridView3.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.EvenRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView3.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView3.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView3.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView3.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView3.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView3.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView3.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView3.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView3.Appearance.GroupRow.Options.UseFont = true;
            this.gridView3.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView3.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView3.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView3.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView3.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView3.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView3.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView3.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView3.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.OddRow.Options.UseFont = true;
            this.gridView3.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView3.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.Row.Options.UseBackColor = true;
            this.gridView3.Appearance.Row.Options.UseFont = true;
            this.gridView3.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView3.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView3.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView3.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView3.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView3.OptionsNavigation.UseTabKey = false;
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            // 
            // edtEinsatzStelleVon
            // 
            this.edtEinsatzStelleVon.EditValue = "";
            this.edtEinsatzStelleVon.Location = new System.Drawing.Point(166, 130);
            this.edtEinsatzStelleVon.Name = "edtEinsatzStelleVon";
            this.edtEinsatzStelleVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinsatzStelleVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzStelleVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzStelleVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzStelleVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzStelleVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzStelleVon.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzStelleVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtEinsatzStelleVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzStelleVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtEinsatzStelleVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzStelleVon.Properties.ShowToday = false;
            this.edtEinsatzStelleVon.Size = new System.Drawing.Size(100, 24);
            this.edtEinsatzStelleVon.TabIndex = 4;
            this.edtEinsatzStelleVon.EditValueChanged += new System.EventHandler(this.edtEinsatzStelleVon_EditValueChanged);
            // 
            // edtEinsatzStelleBis
            // 
            this.edtEinsatzStelleBis.EditValue = "";
            this.edtEinsatzStelleBis.Location = new System.Drawing.Point(316, 130);
            this.edtEinsatzStelleBis.Name = "edtEinsatzStelleBis";
            this.edtEinsatzStelleBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinsatzStelleBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzStelleBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzStelleBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzStelleBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzStelleBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzStelleBis.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzStelleBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtEinsatzStelleBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzStelleBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtEinsatzStelleBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzStelleBis.Properties.ShowToday = false;
            this.edtEinsatzStelleBis.Size = new System.Drawing.Size(100, 24);
            this.edtEinsatzStelleBis.TabIndex = 5;
            this.edtEinsatzStelleBis.EditValueChanged += new System.EventHandler(this.edtEinsatzStelleBis_EditValueChanged);
            // 
            // lblEinsatzStelleVon
            // 
            this.lblEinsatzStelleVon.Location = new System.Drawing.Point(30, 130);
            this.lblEinsatzStelleVon.Name = "lblEinsatzStelleVon";
            this.lblEinsatzStelleVon.Size = new System.Drawing.Size(130, 24);
            this.lblEinsatzStelleVon.TabIndex = 11;
            this.lblEinsatzStelleVon.Text = "Einsatz/Stelle von";
            this.lblEinsatzStelleVon.UseCompatibleTextRendering = true;
            // 
            // lblEinsatzStelleBis
            // 
            this.lblEinsatzStelleBis.Location = new System.Drawing.Point(283, 130);
            this.lblEinsatzStelleBis.Name = "lblEinsatzStelleBis";
            this.lblEinsatzStelleBis.Size = new System.Drawing.Size(27, 24);
            this.lblEinsatzStelleBis.TabIndex = 12;
            this.lblEinsatzStelleBis.Text = "bis";
            this.lblEinsatzStelleBis.UseCompatibleTextRendering = true;
            // 
            // edtBetriebAuswahl
            // 
            this.edtBetriebAuswahl.Location = new System.Drawing.Point(166, 100);
            this.edtBetriebAuswahl.Name = "edtBetriebAuswahl";
            this.edtBetriebAuswahl.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetriebAuswahl.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetriebAuswahl.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetriebAuswahl.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetriebAuswahl.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetriebAuswahl.Properties.Appearance.Options.UseFont = true;
            this.edtBetriebAuswahl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBetriebAuswahl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBetriebAuswahl.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetriebAuswahl.Size = new System.Drawing.Size(250, 24);
            this.edtBetriebAuswahl.TabIndex = 3;
            this.edtBetriebAuswahl.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBetriebAuswahl_UserModifiedFld);
            // 
            // CtlQueryKaEinsaetzeBIPStellenBI
            // 
            this.Name = "CtlQueryKaEinsaetzeBIPStellenBI";
            this.Load += new System.EventHandler(this.CtlQueryKaEinsaetzeBIPStellenBI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.tpgListeStelleBI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryStelleBI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStelleBI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStelleBI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSTESID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzBeginnBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSTES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzBeginnBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzStelleVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzStelleBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzStelleVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzStelleBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebAuswahl.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        #region Private Methods

        private void CtlQueryKaEinsaetzeBIPStellenBI_Load(object sender, System.EventArgs e)
        {
            tpgListe.Title = "Einsatz BIP";
            edtEinsatzStelleVon.EditValue = null;
            edtEinsatzStelleBis.EditValue = null;
        }

        private void edtNameSTESID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtNameSTESID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtNameSTESID.EditValue = null;
                    edtNameSTESID.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PersonSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtNameSTESID.EditValue = dlg["Name"];
                edtNameSTESID.LookupID = dlg["BaPersonID"];
            }
        }

        #endregion

        private void edtEinsatzStelleVon_EditValueChanged(object sender, System.EventArgs e)
        {
            EnableDisableDateFields(edtEinsatzStelleVon, edtEinsatzStelleBis, edtEinsatzBeginnBis);
            try
            {
                CheckDateVonBis(edtEinsatzStelleVon);
            }
            catch (KissInfoException ex)
            {
                ex.ShowMessage();
                ex.ctlFocus.Focus();
            }
        }

        private void EnableDisableDateFields(KissDateEdit sender, KissDateEdit dependency, KissDateEdit receiver)
        {
            if (sender.EditValue != null || (dependency != null && dependency.EditValue != null))
            {
                receiver.EditValue = null;
                receiver.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                receiver.EditMode = EditModeType.Normal;
            }
        }

        private void edtEinsatzStelleBis_EditValueChanged(object sender, System.EventArgs e)
        {
            EnableDisableDateFields(edtEinsatzStelleBis, edtEinsatzStelleVon, edtEinsatzBeginnBis);
            try
            {
                CheckDateVonBis(edtEinsatzStelleBis);
            }
            catch (KissInfoException ex)
            {
                ex.ShowMessage();
                ex.ctlFocus.Focus();
            }
        }

        private void edtEinsatzBeginnBis_EditValueChanged(object sender, System.EventArgs e)
        {
            EnableDisableDateFields(edtEinsatzBeginnBis, null, edtEinsatzStelleBis);
            EnableDisableDateFields(edtEinsatzBeginnBis, null, edtEinsatzStelleVon);
        }

        private void CheckDateVonBis(KissDateEdit sender)
        {
            if (edtEinsatzStelleVon.EditValue != null && edtEinsatzStelleBis.EditValue != null)
            {
                if (edtEinsatzStelleVon.DateTime.CompareTo(edtEinsatzStelleBis.DateTime) > 0)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(this.Name, "DatumVonNachBisError", "Datum bis darf nicht vor Datum von liegen."), sender);
                }
            }
        }

        protected override void RunSearch()
        {
            CheckDateVonBis(edtEinsatzStelleVon);
            base.RunSearch();
        }

        private void edtBetriebAuswahl_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string SearchString = edtBetriebAuswahl.Text;

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtBetriebAuswahl.EditValue = null;
                    edtBetriebAuswahl.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.BetriebKASuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtBetriebAuswahl.EditValue = dlg["Betrieb"];
                edtBetriebAuswahl.LookupID = dlg["BetriebID"];
            }
        }
    }
}