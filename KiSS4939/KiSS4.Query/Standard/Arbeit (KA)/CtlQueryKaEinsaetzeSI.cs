using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common;

namespace KiSS4.Query
{
    public class CtlQueryKaEinsaetzeSI : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAnfrage;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrieb;
        private DevExpress.XtraGrid.Columns.GridColumn colEingang;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzab;
        private DevExpress.XtraGrid.Columns.GridColumn colEinsatzplatz;
        private DevExpress.XtraGrid.Columns.GridColumn colIntervention;
        private DevExpress.XtraGrid.Columns.GridColumn colMahnung;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colVereinbarung;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colZBanSD;
        private DevExpress.XtraGrid.Columns.GridColumn colliste;
        private DevExpress.XtraGrid.Columns.GridColumn colunterschr;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlGotoFall ctlGotoFallStelleBI;
        private KiSS4.Gui.KissTextEdit edtBetrieb;
        private KiSS4.Gui.KissDateEdit edtEinsatzBis;
        private KiSS4.Gui.KissTextEdit edtEinsatzplatz;
        private KiSS4.Gui.KissButtonEdit edtNameSTESID;
        private KiSS4.Gui.KissGrid grdZwischenbericht;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZwischenbericht;
        private KiSS4.Gui.KissLabel lblBetrieb;
        private KiSS4.Gui.KissLabel lblEinsatzBis;
        private KiSS4.Gui.KissLabel lblEinsatzplatz;
        private KiSS4.Gui.KissLabel lblNameSTES;
        private KiSS4.DB.SqlQuery qryZwischenbericht;
        private SharpLibrary.WinControls.TabPageEx tpgZwischenbericht;

        #endregion

        #region Constructors

        public CtlQueryKaEinsaetzeSI()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaEinsaetzeSI));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tpgZwischenbericht = new SharpLibrary.WinControls.TabPageEx();
            this.grdZwischenbericht = new KiSS4.Gui.KissGrid();
            this.ctlGotoFallStelleBI = new KiSS4.Common.CtlGotoFall();
            this.edtNameSTESID = new KiSS4.Gui.KissButtonEdit();
            this.edtEinsatzplatz = new KiSS4.Gui.KissTextEdit();
            this.edtBetrieb = new KiSS4.Gui.KissTextEdit();
            this.edtEinsatzBis = new KiSS4.Gui.KissDateEdit();
            this.lblNameSTES = new KiSS4.Gui.KissLabel();
            this.lblEinsatzplatz = new KiSS4.Gui.KissLabel();
            this.lblBetrieb = new KiSS4.Gui.KissLabel();
            this.lblEinsatzBis = new KiSS4.Gui.KissLabel();
            this.colAnfrage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrieb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEingang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzab = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzplatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntervention = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colliste = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMahnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colunterschr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVereinbarung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZBanSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grvZwischenbericht = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryZwischenbericht = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.tpgZwischenbericht.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdZwischenbericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSTESID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrieb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSTES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZwischenbericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZwischenbericht)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            //
            // grdQuery1
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
            this.tabControlSearch.Controls.Add(this.tpgZwischenbericht);
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
                        this.tpgZwischenbericht});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgZwischenbericht, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Title = "Einsatz SI";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.lblEinsatzBis);
            this.tpgSuchen.Controls.Add(this.lblBetrieb);
            this.tpgSuchen.Controls.Add(this.lblEinsatzplatz);
            this.tpgSuchen.Controls.Add(this.lblNameSTES);
            this.tpgSuchen.Controls.Add(this.edtEinsatzBis);
            this.tpgSuchen.Controls.Add(this.edtBetrieb);
            this.tpgSuchen.Controls.Add(this.edtEinsatzplatz);
            this.tpgSuchen.Controls.Add(this.edtNameSTESID);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.TabIndex = 2;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNameSTESID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEinsatzplatz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBetrieb, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEinsatzBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNameSTES, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEinsatzplatz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBetrieb, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEinsatzBis, 0);
            //
            // tpgZwischenbericht
            //
            this.tpgZwischenbericht.Controls.Add(this.ctlGotoFallStelleBI);
            this.tpgZwischenbericht.Controls.Add(this.grdZwischenbericht);
            this.tpgZwischenbericht.Location = new System.Drawing.Point(6, 6);
            this.tpgZwischenbericht.Name = "tpgZwischenbericht";
            this.tpgZwischenbericht.Size = new System.Drawing.Size(772, 424);
            this.tpgZwischenbericht.TabIndex = 1;
            this.tpgZwischenbericht.Title = "Zwischenbericht";
            //
            // grdZwischenbericht
            //
            this.grdZwischenbericht.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdZwischenbericht.ColumnFilterActivated = true;
            this.grdZwischenbericht.DataSource = this.qryZwischenbericht;
            this.grdZwischenbericht.EmbeddedNavigator.Name = "";
            this.grdZwischenbericht.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZwischenbericht.Location = new System.Drawing.Point(3, 1);
            this.grdZwischenbericht.MainView = this.grvZwischenbericht;
            this.grdZwischenbericht.Name = "grdZwischenbericht";
            this.grdZwischenbericht.Size = new System.Drawing.Size(766, 392);
            this.grdZwischenbericht.TabIndex = 2;
            this.grdZwischenbericht.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvZwischenbericht});
            //
            // ctlGotoFallStelleBI
            //
            this.ctlGotoFallStelleBI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallStelleBI.BaPersonID = ((object)(resources.GetObject("ctlGotoFallStelleBI.BaPersonID")));
            this.ctlGotoFallStelleBI.DataMember = "BaPersonID$";
            this.ctlGotoFallStelleBI.DataSource = this.qryZwischenbericht;
            this.ctlGotoFallStelleBI.Location = new System.Drawing.Point(3, 399);
            this.ctlGotoFallStelleBI.Name = "ctlGotoFallStelleBI";
            this.ctlGotoFallStelleBI.Size = new System.Drawing.Size(154, 24);
            this.ctlGotoFallStelleBI.TabIndex = 3;
            //
            // edtNameSTESID
            //
            this.edtNameSTESID.Location = new System.Drawing.Point(150, 46);
            this.edtNameSTESID.Name = "edtNameSTESID";
            this.edtNameSTESID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameSTESID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameSTESID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameSTESID.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameSTESID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameSTESID.Properties.Appearance.Options.UseFont = true;
            this.edtNameSTESID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtNameSTESID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtNameSTESID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameSTESID.Size = new System.Drawing.Size(250, 24);
            this.edtNameSTESID.TabIndex = 9;
            this.edtNameSTESID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtNameSTESID_UserModifiedFld);
            //
            // edtEinsatzplatz
            //
            this.edtEinsatzplatz.Location = new System.Drawing.Point(150, 73);
            this.edtEinsatzplatz.Name = "edtEinsatzplatz";
            this.edtEinsatzplatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzplatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzplatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzplatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzplatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzplatz.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzplatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinsatzplatz.Size = new System.Drawing.Size(250, 24);
            this.edtEinsatzplatz.TabIndex = 10;
            //
            // edtBetrieb
            //
            this.edtBetrieb.Location = new System.Drawing.Point(150, 100);
            this.edtBetrieb.Name = "edtBetrieb";
            this.edtBetrieb.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetrieb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrieb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrieb.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrieb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrieb.Properties.Appearance.Options.UseFont = true;
            this.edtBetrieb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrieb.Size = new System.Drawing.Size(250, 24);
            this.edtBetrieb.TabIndex = 11;
            //
            // edtEinsatzBis
            //
            this.edtEinsatzBis.EditValue = "";
            this.edtEinsatzBis.Location = new System.Drawing.Point(150, 128);
            this.edtEinsatzBis.Name = "edtEinsatzBis";
            this.edtEinsatzBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEinsatzBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzBis.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtEinsatzBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEinsatzBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtEinsatzBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzBis.Properties.ShowToday = false;
            this.edtEinsatzBis.Size = new System.Drawing.Size(100, 24);
            this.edtEinsatzBis.TabIndex = 12;
            //
            // lblNameSTES
            //
            this.lblNameSTES.Location = new System.Drawing.Point(8, 46);
            this.lblNameSTES.Name = "lblNameSTES";
            this.lblNameSTES.Size = new System.Drawing.Size(96, 24);
            this.lblNameSTES.TabIndex = 13;
            this.lblNameSTES.Text = "STES";
            this.lblNameSTES.UseCompatibleTextRendering = true;
            //
            // lblEinsatzplatz
            //
            this.lblEinsatzplatz.Location = new System.Drawing.Point(8, 73);
            this.lblEinsatzplatz.Name = "lblEinsatzplatz";
            this.lblEinsatzplatz.Size = new System.Drawing.Size(96, 24);
            this.lblEinsatzplatz.TabIndex = 14;
            this.lblEinsatzplatz.Text = "Einsatzplatz";
            this.lblEinsatzplatz.UseCompatibleTextRendering = true;
            //
            // lblBetrieb
            //
            this.lblBetrieb.Location = new System.Drawing.Point(8, 100);
            this.lblBetrieb.Name = "lblBetrieb";
            this.lblBetrieb.Size = new System.Drawing.Size(96, 24);
            this.lblBetrieb.TabIndex = 15;
            this.lblBetrieb.Text = "Betrieb";
            this.lblBetrieb.UseCompatibleTextRendering = true;
            //
            // lblEinsatzBis
            //
            this.lblEinsatzBis.Location = new System.Drawing.Point(8, 128);
            this.lblEinsatzBis.Name = "lblEinsatzBis";
            this.lblEinsatzBis.Size = new System.Drawing.Size(136, 24);
            this.lblEinsatzBis.TabIndex = 16;
            this.lblEinsatzBis.Text = "Einsatz/Stellebeginn bis";
            this.lblEinsatzBis.UseCompatibleTextRendering = true;
            //
            // colAnfrage
            //
            this.colAnfrage.Name = "colAnfrage";
            //
            // colBetrieb
            //
            this.colBetrieb.Name = "colBetrieb";
            //
            // colEingang
            //
            this.colEingang.Name = "colEingang";
            //
            // colEinsatzab
            //
            this.colEinsatzab.Name = "colEinsatzab";
            //
            // colEinsatzplatz
            //
            this.colEinsatzplatz.Name = "colEinsatzplatz";
            //
            // colIntervention
            //
            this.colIntervention.Name = "colIntervention";
            //
            // colliste
            //
            this.colliste.Name = "colliste";
            //
            // colMahnung
            //
            this.colMahnung.Name = "colMahnung";
            //
            // colName
            //
            this.colName.Name = "colName";
            //
            // colunterschr
            //
            this.colunterschr.Name = "colunterschr";
            //
            // colVereinbarung
            //
            this.colVereinbarung.Name = "colVereinbarung";
            //
            // colVorname
            //
            this.colVorname.Name = "colVorname";
            //
            // colZBanSD
            //
            this.colZBanSD.Name = "colZBanSD";
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
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
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
            this.grvQuery1.GridControl = this.grdQuery1;
            this.grvQuery1.Name = "grvQuery1";
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
            // grvZwischenbericht
            //
            this.grvZwischenbericht.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZwischenbericht.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.Empty.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.Empty.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.EvenRow.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZwischenbericht.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZwischenbericht.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZwischenbericht.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZwischenbericht.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZwischenbericht.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZwischenbericht.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZwischenbericht.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZwischenbericht.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZwischenbericht.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.GroupRow.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZwischenbericht.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZwischenbericht.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZwischenbericht.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZwischenbericht.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZwischenbericht.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZwischenbericht.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZwischenbericht.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZwischenbericht.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.OddRow.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZwischenbericht.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.Row.Options.UseBackColor = true;
            this.grvZwischenbericht.Appearance.Row.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZwischenbericht.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZwischenbericht.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZwischenbericht.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZwischenbericht.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZwischenbericht.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZwischenbericht.GridControl = this.grdZwischenbericht;
            this.grvZwischenbericht.Name = "grvZwischenbericht";
            this.grvZwischenbericht.OptionsBehavior.Editable = false;
            this.grvZwischenbericht.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZwischenbericht.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZwischenbericht.OptionsNavigation.UseTabKey = false;
            this.grvZwischenbericht.OptionsView.ColumnAutoWidth = false;
            this.grvZwischenbericht.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZwischenbericht.OptionsView.ShowGroupPanel = false;
            this.grvZwischenbericht.OptionsView.ShowIndicator = false;
            //
            // qryZwischenbericht
            //
            this.qryZwischenbericht.HostControl = this;
            this.qryZwischenbericht.SelectStatement = resources.GetString("qryZwischenbericht.SelectStatement");
            //
            // CtlQueryKaEinsaetzeSI
            //
            this.Name = "CtlQueryKaEinsaetzeSI";
            this.Load += new System.EventHandler(this.CtlQueryKaEinsaetzeSI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.tpgZwischenbericht.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdZwischenbericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSTESID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrieb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSTES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZwischenbericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZwischenbericht)).EndInit();
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

        private void CtlQueryKaEinsaetzeSI_Load(object sender, System.EventArgs e)
        {
            tpgListe.Title = "Einsatz SI";
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
    }
}