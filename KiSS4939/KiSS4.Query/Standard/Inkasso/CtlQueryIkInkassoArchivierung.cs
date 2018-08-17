using KiSS4.DB;

namespace KiSS4.Query
{
    public class CtlQueryIkInkassoArchivierung : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAbschlussgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colArchivStandort;
        private DevExpress.XtraGrid.Columns.GridColumn colForderungstitel;
        private DevExpress.XtraGrid.Columns.GridColumn colInkassofall;
        private DevExpress.XtraGrid.Columns.GridColumn colInkassotyp;
        private DevExpress.XtraGrid.Columns.GridColumn colInkassotypUnterart;
        private DevExpress.XtraGrid.Columns.GridColumn colRckerstattung;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldner;
        private DevExpress.XtraGrid.Columns.GridColumn colarchiviertam;
        private DevExpress.XtraGrid.Columns.GridColumn colerffnet;
        private DevExpress.XtraGrid.Columns.GridColumn colgeschlossen;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtIkForderungtitel;
        private KiSS4.Gui.KissLookUpEdit edtIkRueckerstattung;
        private KiSS4.Gui.KissLookUpEdit edtInkassoTyp;
        private KiSS4.Gui.KissLookUpEdit edtInkassoTypUnterart;
        private KiSS4.Gui.KissButtonEdit edtSAR_ID;
        private KiSS4.Gui.KissLookUpEdit edtSortierung;
        private KiSS4.Gui.KissLookUpEdit edtVariante;
        private KiSS4.Gui.KissLabel edtlblInkassoTyp;
        private KiSS4.Gui.KissLabel edtlblInkassoTypUnterart;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblIkForderungtitel;
        private KiSS4.Gui.KissLabel lblIkRueckerstattung;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblSortierung;
        private KiSS4.Gui.KissLabel lblVariante;
        private KiSS4.Gui.KissLabel lblZeitraumvon;
        private KiSS4.Gui.KissLabel lblbis;

        #endregion

        #region Constructors

        public CtlQueryIkInkassoArchivierung()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryIkInkassoArchivierung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.edtSAR_ID = new KiSS4.Gui.KissButtonEdit();
            this.lblZeitraumvon = new KiSS4.Gui.KissLabel();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblVariante = new KiSS4.Gui.KissLabel();
            this.edtlblInkassoTyp = new KiSS4.Gui.KissLabel();
            this.edtInkassoTyp = new KiSS4.Gui.KissLookUpEdit();
            this.edtlblInkassoTypUnterart = new KiSS4.Gui.KissLabel();
            this.edtInkassoTypUnterart = new KiSS4.Gui.KissLookUpEdit();
            this.lblSortierung = new KiSS4.Gui.KissLabel();
            this.edtSortierung = new KiSS4.Gui.KissLookUpEdit();
            this.edtVariante = new KiSS4.Gui.KissLookUpEdit();
            this.lblIkForderungtitel = new KiSS4.Gui.KissLabel();
            this.edtIkForderungtitel = new KiSS4.Gui.KissLookUpEdit();
            this.lblIkRueckerstattung = new KiSS4.Gui.KissLabel();
            this.edtIkRueckerstattung = new KiSS4.Gui.KissLookUpEdit();
            this.colAbschlussgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colarchiviertam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchivStandort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colerffnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colForderungstitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgeschlossen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInkassofall = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInkassotyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInkassotypUnterart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRckerstattung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVariante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtlblInkassoTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtlblInkassoTypUnterart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSortierung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortierung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortierung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVariante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVariante.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkForderungtitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkForderungtitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkForderungtitel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkRueckerstattung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRueckerstattung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRueckerstattung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
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
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtIkRueckerstattung);
            this.tpgSuchen.Controls.Add(this.lblIkRueckerstattung);
            this.tpgSuchen.Controls.Add(this.edtIkForderungtitel);
            this.tpgSuchen.Controls.Add(this.lblIkForderungtitel);
            this.tpgSuchen.Controls.Add(this.edtVariante);
            this.tpgSuchen.Controls.Add(this.edtSortierung);
            this.tpgSuchen.Controls.Add(this.lblSortierung);
            this.tpgSuchen.Controls.Add(this.edtInkassoTypUnterart);
            this.tpgSuchen.Controls.Add(this.edtlblInkassoTypUnterart);
            this.tpgSuchen.Controls.Add(this.edtInkassoTyp);
            this.tpgSuchen.Controls.Add(this.edtlblInkassoTyp);
            this.tpgSuchen.Controls.Add(this.lblVariante);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.lblZeitraumvon);
            this.tpgSuchen.Controls.Add(this.edtSAR_ID);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSAR_ID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVariante, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtlblInkassoTyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInkassoTyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtlblInkassoTypUnterart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInkassoTypUnterart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSortierung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSortierung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVariante, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblIkForderungtitel, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtIkForderungtitel, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblIkRueckerstattung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtIkRueckerstattung, 0);
            //
            // lblSAR
            //
            this.lblSAR.Location = new System.Drawing.Point(10, 40);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(130, 24);
            this.lblSAR.TabIndex = 1;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            //
            // edtSAR_ID
            //
            this.edtSAR_ID.Location = new System.Drawing.Point(150, 40);
            this.edtSAR_ID.LookupSQL = "select ID = UserID, SAR = LastName + isNull(\', \' + FirstName,\'\'), [Kuerzel] = Log" +
                "onName\nfrom   XUser \nwhere LastName + isNull(\', \' + FirstName,\'\') like {0} + \'%\'" +
                " \norder by SAR";
            this.edtSAR_ID.Name = "edtSAR_ID";
            this.edtSAR_ID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSAR_ID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSAR_ID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSAR_ID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSAR_ID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSAR_ID.Properties.Appearance.Options.UseFont = true;
            this.edtSAR_ID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSAR_ID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtSAR_ID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSAR_ID.Size = new System.Drawing.Size(250, 24);
            this.edtSAR_ID.TabIndex = 2;
            //
            // lblZeitraumvon
            //
            this.lblZeitraumvon.Location = new System.Drawing.Point(10, 70);
            this.lblZeitraumvon.Name = "lblZeitraumvon";
            this.lblZeitraumvon.Size = new System.Drawing.Size(130, 24);
            this.lblZeitraumvon.TabIndex = 3;
            this.lblZeitraumvon.Text = "Zeitraum von";
            this.lblZeitraumvon.UseCompatibleTextRendering = true;
            //
            // lblbis
            //
            this.lblbis.Location = new System.Drawing.Point(270, 70);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(130, 24);
            this.lblbis.TabIndex = 4;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            //
            // edtDatumVon
            //
            this.edtDatumVon.EditValue = "";
            this.edtDatumVon.Location = new System.Drawing.Point(150, 70);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 5;
            //
            // edtDatumBis
            //
            this.edtDatumBis.EditValue = "";
            this.edtDatumBis.Location = new System.Drawing.Point(300, 70);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 6;
            //
            // lblVariante
            //
            this.lblVariante.Location = new System.Drawing.Point(10, 100);
            this.lblVariante.Name = "lblVariante";
            this.lblVariante.Size = new System.Drawing.Size(130, 24);
            this.lblVariante.TabIndex = 7;
            this.lblVariante.Text = "In diesem Zeitraum";
            this.lblVariante.UseCompatibleTextRendering = true;
            //
            // edtlblInkassoTyp
            //
            this.edtlblInkassoTyp.Location = new System.Drawing.Point(10, 130);
            this.edtlblInkassoTyp.Name = "edtlblInkassoTyp";
            this.edtlblInkassoTyp.Size = new System.Drawing.Size(128, 24);
            this.edtlblInkassoTyp.TabIndex = 9;
            this.edtlblInkassoTyp.Text = "Inkasso-Typ";
            this.edtlblInkassoTyp.UseCompatibleTextRendering = true;
            //
            // edtInkassoTyp
            //
            this.edtInkassoTyp.Location = new System.Drawing.Point(150, 130);
            this.edtInkassoTyp.LOVFilter = "code between 401 and 499";
            this.edtInkassoTyp.LOVFilterWhereAppend = true;
            this.edtInkassoTyp.LOVName = "faProzess";
            this.edtInkassoTyp.Name = "edtInkassoTyp";
            this.edtInkassoTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInkassoTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInkassoTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInkassoTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtInkassoTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInkassoTyp.Properties.Appearance.Options.UseFont = true;
            this.edtInkassoTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtInkassoTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtInkassoTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInkassoTyp.Properties.NullText = "";
            this.edtInkassoTyp.Properties.ShowFooter = false;
            this.edtInkassoTyp.Properties.ShowHeader = false;
            this.edtInkassoTyp.Size = new System.Drawing.Size(250, 24);
            this.edtInkassoTyp.TabIndex = 10;
            //
            // edtlblInkassoTypUnterart
            //
            this.edtlblInkassoTypUnterart.Location = new System.Drawing.Point(10, 160);
            this.edtlblInkassoTypUnterart.Name = "edtlblInkassoTypUnterart";
            this.edtlblInkassoTypUnterart.Size = new System.Drawing.Size(128, 24);
            this.edtlblInkassoTypUnterart.TabIndex = 11;
            this.edtlblInkassoTypUnterart.Text = "Inkasso-Typ Unterart";
            this.edtlblInkassoTypUnterart.UseCompatibleTextRendering = true;
            //
            // edtInkassoTypUnterart
            //
            this.edtInkassoTypUnterart.Location = new System.Drawing.Point(150, 160);
            this.edtInkassoTypUnterart.LOVFilter = "code between 40000 and 49000";
            this.edtInkassoTypUnterart.LOVFilterWhereAppend = true;
            this.edtInkassoTypUnterart.LOVName = "Eroeffnungsgrund";
            this.edtInkassoTypUnterart.Name = "edtInkassoTypUnterart";
            this.edtInkassoTypUnterart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInkassoTypUnterart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInkassoTypUnterart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInkassoTypUnterart.Properties.Appearance.Options.UseBackColor = true;
            this.edtInkassoTypUnterart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInkassoTypUnterart.Properties.Appearance.Options.UseFont = true;
            this.edtInkassoTypUnterart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtInkassoTypUnterart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtInkassoTypUnterart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInkassoTypUnterart.Properties.NullText = "";
            this.edtInkassoTypUnterart.Properties.ShowFooter = false;
            this.edtInkassoTypUnterart.Properties.ShowHeader = false;
            this.edtInkassoTypUnterart.Size = new System.Drawing.Size(250, 24);
            this.edtInkassoTypUnterart.TabIndex = 12;
            //
            // lblSortierung
            //
            this.lblSortierung.Location = new System.Drawing.Point(10, 190);
            this.lblSortierung.Name = "lblSortierung";
            this.lblSortierung.Size = new System.Drawing.Size(130, 24);
            this.lblSortierung.TabIndex = 15;
            this.lblSortierung.Text = "Sortierreihenfolge";
            this.lblSortierung.UseCompatibleTextRendering = true;
            //
            // edtSortierung
            //
            this.edtSortierung.Location = new System.Drawing.Point(150, 190);
            this.edtSortierung.Name = "edtSortierung";
            this.edtSortierung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSortierung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSortierung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSortierung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSortierung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSortierung.Properties.Appearance.Options.UseFont = true;
            this.edtSortierung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSortierung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtSortierung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSortierung.Properties.NullText = "";
            this.edtSortierung.Properties.ShowFooter = false;
            this.edtSortierung.Properties.ShowHeader = false;
            this.edtSortierung.Size = new System.Drawing.Size(250, 24);
            this.edtSortierung.TabIndex = 17;
            //
            // edtVariante
            //
            this.edtVariante.Location = new System.Drawing.Point(150, 100);
            this.edtVariante.Name = "edtVariante";
            this.edtVariante.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVariante.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVariante.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVariante.Properties.Appearance.Options.UseBackColor = true;
            this.edtVariante.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVariante.Properties.Appearance.Options.UseFont = true;
            this.edtVariante.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtVariante.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtVariante.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtVariante.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtVariante.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtVariante.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtVariante.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVariante.Properties.NullText = "";
            this.edtVariante.Properties.ShowFooter = false;
            this.edtVariante.Properties.ShowHeader = false;
            this.edtVariante.Size = new System.Drawing.Size(355, 24);
            this.edtVariante.TabIndex = 17;
            //
            // lblIkForderungtitel
            //
            this.lblIkForderungtitel.Location = new System.Drawing.Point(10, 220);
            this.lblIkForderungtitel.Name = "lblIkForderungtitel";
            this.lblIkForderungtitel.Size = new System.Drawing.Size(130, 24);
            this.lblIkForderungtitel.TabIndex = 18;
            this.lblIkForderungtitel.Text = "Forderungstitel";
            this.lblIkForderungtitel.UseCompatibleTextRendering = true;
            //
            // edtIkForderungtitel
            //
            this.edtIkForderungtitel.Location = new System.Drawing.Point(150, 220);
            this.edtIkForderungtitel.LOVName = "IkForderungtitel";
            this.edtIkForderungtitel.Name = "edtIkForderungtitel";
            this.edtIkForderungtitel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkForderungtitel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkForderungtitel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkForderungtitel.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkForderungtitel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkForderungtitel.Properties.Appearance.Options.UseFont = true;
            this.edtIkForderungtitel.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIkForderungtitel.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkForderungtitel.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIkForderungtitel.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIkForderungtitel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtIkForderungtitel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtIkForderungtitel.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkForderungtitel.Properties.NullText = "";
            this.edtIkForderungtitel.Properties.ShowFooter = false;
            this.edtIkForderungtitel.Properties.ShowHeader = false;
            this.edtIkForderungtitel.Size = new System.Drawing.Size(250, 24);
            this.edtIkForderungtitel.TabIndex = 19;
            //
            // lblIkRueckerstattung
            //
            this.lblIkRueckerstattung.Location = new System.Drawing.Point(10, 253);
            this.lblIkRueckerstattung.Name = "lblIkRueckerstattung";
            this.lblIkRueckerstattung.Size = new System.Drawing.Size(130, 24);
            this.lblIkRueckerstattung.TabIndex = 20;
            this.lblIkRueckerstattung.Text = "Rückerstattung";
            this.lblIkRueckerstattung.UseCompatibleTextRendering = true;
            //
            // edtIkRueckerstattung
            //
            this.edtIkRueckerstattung.Location = new System.Drawing.Point(150, 253);
            this.edtIkRueckerstattung.LOVName = "IkRueckerstattungTyp";
            this.edtIkRueckerstattung.Name = "edtIkRueckerstattung";
            this.edtIkRueckerstattung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkRueckerstattung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkRueckerstattung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkRueckerstattung.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkRueckerstattung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkRueckerstattung.Properties.Appearance.Options.UseFont = true;
            this.edtIkRueckerstattung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIkRueckerstattung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkRueckerstattung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIkRueckerstattung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIkRueckerstattung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtIkRueckerstattung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtIkRueckerstattung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkRueckerstattung.Properties.NullText = "";
            this.edtIkRueckerstattung.Properties.ShowFooter = false;
            this.edtIkRueckerstattung.Properties.ShowHeader = false;
            this.edtIkRueckerstattung.Size = new System.Drawing.Size(250, 24);
            this.edtIkRueckerstattung.TabIndex = 21;
            //
            // colAbschlussgrund
            //
            this.colAbschlussgrund.Name = "colAbschlussgrund";
            //
            // colarchiviertam
            //
            this.colarchiviertam.Name = "colarchiviertam";
            //
            // colArchivStandort
            //
            this.colArchivStandort.Name = "colArchivStandort";
            //
            // colerffnet
            //
            this.colerffnet.Name = "colerffnet";
            //
            // colForderungstitel
            //
            this.colForderungstitel.Name = "colForderungstitel";
            //
            // colgeschlossen
            //
            this.colgeschlossen.Name = "colgeschlossen";
            //
            // colInkassofall
            //
            this.colInkassofall.Name = "colInkassofall";
            //
            // colInkassotyp
            //
            this.colInkassotyp.Name = "colInkassotyp";
            //
            // colInkassotypUnterart
            //
            this.colInkassotypUnterart.Name = "colInkassotypUnterart";
            //
            // colRckerstattung
            //
            this.colRckerstattung.Name = "colRckerstattung";
            //
            // colSAR
            //
            this.colSAR.Name = "colSAR";
            //
            // colSchuldner
            //
            this.colSchuldner.Name = "colSchuldner";
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
            // CtlQueryIkInkassoArchivierung
            //
            this.Name = "CtlQueryIkInkassoArchivierung";
            this.Load += new System.EventHandler(this.CtlQueryIkInkassoArchivierung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVariante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtlblInkassoTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtlblInkassoTypUnterart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSortierung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortierung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSortierung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVariante.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVariante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkForderungtitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkForderungtitel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkForderungtitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkRueckerstattung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRueckerstattung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRueckerstattung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtVariante.EditValue = 1;
            edtSortierung.EditValue = 1;

            edtSAR_ID.EditValue = null;
            edtSAR_ID.LookupID = null;
            edtDatumVon.EditValue = null;
            edtDatumBis.EditValue = null;
            edtInkassoTyp.EditValue = null;
            edtInkassoTypUnterart.EditValue = null;
        }

        protected override void RunSearch()
        {
            DBUtil.CheckNotNullField(edtVariante, lblVariante.Text);
            DBUtil.CheckNotNullField(edtSortierung, lblSortierung.Text);

            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void CtlQueryIkInkassoArchivierung_Load(object sender, System.EventArgs e)
        {
            edtVariante.LoadQuery(DBUtil.OpenSQL(@"
                    SELECT Code = 1, Text = 'archivierte und/oder abgeschlossene Inkassofälle (beides)'
                    UNION
                    SELECT Code = 2, Text = 'archivierte Inkassofälle'
                    UNION
                    SELECT Code = 3, Text = 'abgeschlossene Inkassofälle (archivierte und nicht archivierte)'
                    UNION
                    SELECT Code = 4, Text = 'abgeschlossene Inkassofälle (nur noch nicht archivierte)' "));

            edtVariante.EditValue = 1;

            edtSortierung.LoadQuery(DBUtil.OpenSQL(@"
                    SELECT Code = 1, Text = 'Inkassofall Bezeichnung'
                    UNION
                    SELECT Code = 2, Text = 'Schliessung'
                    UNION
                    SELECT Code = 3, Text = 'Archivierung'"));

            edtSortierung.EditValue = 1;
        }

        #endregion
    }
}