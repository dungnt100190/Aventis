using System;
using KiSS4.DB;

namespace KiSS4.Administration.PI
{
    public class CtlAdKantonaleZuschuesse : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        private KiSS4.Gui.KissCheckEdit chkAktiv;
        private KiSS4.Gui.KissCheckEdit chkSucheAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlZugewiesen;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colBezeichnung;
        private DevExpress.XtraGrid.Columns.GridColumn colKanton;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissMemoEdit edtBemerkungen;
        private KiSS4.Gui.KissTextEditML edtBezeichnung;
        private KiSS4.Gui.KissLookUpEdit edtKanton;
        private KiSS4.Gui.KissTextEdit edtSucheBemerkungen;
        private KiSS4.Gui.KissTextEdit edtSucheBezeichnung;
        private KiSS4.Gui.KissLookUpEdit edtSucheKanton;
        private KiSS4.Gui.KissGrid grdBaKantonalerZuschuss;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaKantonalerZuschuss;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBezeichnung;
        private KiSS4.Gui.KissLabel lblKanton;
        private KiSS4.Gui.KissLabel lblSucheBemerkungen;
        private KiSS4.Gui.KissLabel lblSucheBezeichnung;
        private KiSS4.Gui.KissLabel lblSucheKanton;
        private System.Windows.Forms.Panel panDetails;
        private KiSS4.DB.SqlQuery qryBaKantonalerZuschuss;

        #endregion

        #region Constructors

        public CtlAdKantonaleZuschuesse()
        {
            this.InitializeComponent();

            // setup rights
            this.SetupRights();
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAdKantonaleZuschuesse));
            this.grdBaKantonalerZuschuss = new KiSS4.Gui.KissGrid();
            this.lblSucheBezeichnung = new KiSS4.Gui.KissLabel();
            this.edtSucheBezeichnung = new KiSS4.Gui.KissTextEdit();
            this.lblSucheKanton = new KiSS4.Gui.KissLabel();
            this.edtSucheKanton = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtSucheBemerkungen = new KiSS4.Gui.KissTextEdit();
            this.chkSucheAktiv = new KiSS4.Gui.KissCheckEdit();
            this.panDetails = new System.Windows.Forms.Panel();
            this.lblBezeichnung = new KiSS4.Gui.KissLabel();
            this.edtBezeichnung = new KiSS4.Gui.KissTextEditML();
            this.lblKanton = new KiSS4.Gui.KissLabel();
            this.edtKanton = new KiSS4.Gui.KissLookUpEdit();
            this.chkAktiv = new KiSS4.Gui.KissCheckEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.colAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahlZugewiesen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvBaKantonalerZuschuss = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryBaKantonalerZuschuss = new KiSS4.DB.SqlQuery(this.components);
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaKantonalerZuschuss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBezeichnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKanton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKanton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKanton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheAktiv.Properties)).BeginInit();
            this.panDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezeichnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKanton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKanton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKanton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaKantonalerZuschuss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaKantonalerZuschuss)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(768, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(792, 412);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdBaKantonalerZuschuss);
            this.tpgListe.Size = new System.Drawing.Size(780, 374);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.chkSucheAktiv);
            this.tpgSuchen.Controls.Add(this.edtSucheBemerkungen);
            this.tpgSuchen.Controls.Add(this.lblSucheBemerkungen);
            this.tpgSuchen.Controls.Add(this.edtSucheKanton);
            this.tpgSuchen.Controls.Add(this.lblSucheKanton);
            this.tpgSuchen.Controls.Add(this.edtSucheBezeichnung);
            this.tpgSuchen.Controls.Add(this.lblSucheBezeichnung);
            this.tpgSuchen.Size = new System.Drawing.Size(780, 374);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBezeichnung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBezeichnung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKanton, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKanton, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBemerkungen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBemerkungen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheAktiv, 0);
            //
            // grdBaKantonalerZuschuss
            //
            this.grdBaKantonalerZuschuss.DataSource = this.qryBaKantonalerZuschuss;
            this.grdBaKantonalerZuschuss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBaKantonalerZuschuss.EmbeddedNavigator.Name = "";
            this.grdBaKantonalerZuschuss.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaKantonalerZuschuss.Location = new System.Drawing.Point(0, 0);
            this.grdBaKantonalerZuschuss.MainView = this.grvBaKantonalerZuschuss;
            this.grdBaKantonalerZuschuss.Name = "grdBaKantonalerZuschuss";
            this.grdBaKantonalerZuschuss.Size = new System.Drawing.Size(780, 374);
            this.grdBaKantonalerZuschuss.TabIndex = 0;
            this.grdBaKantonalerZuschuss.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvBaKantonalerZuschuss});
            //
            // lblSucheBezeichnung
            //
            this.lblSucheBezeichnung.Location = new System.Drawing.Point(31, 40);
            this.lblSucheBezeichnung.Name = "lblSucheBezeichnung";
            this.lblSucheBezeichnung.Size = new System.Drawing.Size(105, 24);
            this.lblSucheBezeichnung.TabIndex = 1;
            this.lblSucheBezeichnung.Text = "Bezeichnung";
            this.lblSucheBezeichnung.UseCompatibleTextRendering = true;
            //
            // edtSucheBezeichnung
            //
            this.edtSucheBezeichnung.Location = new System.Drawing.Point(142, 40);
            this.edtSucheBezeichnung.Name = "edtSucheBezeichnung";
            this.edtSucheBezeichnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBezeichnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBezeichnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBezeichnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBezeichnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBezeichnung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBezeichnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBezeichnung.Size = new System.Drawing.Size(215, 24);
            this.edtSucheBezeichnung.TabIndex = 2;
            //
            // lblSucheKanton
            //
            this.lblSucheKanton.Location = new System.Drawing.Point(31, 70);
            this.lblSucheKanton.Name = "lblSucheKanton";
            this.lblSucheKanton.Size = new System.Drawing.Size(105, 24);
            this.lblSucheKanton.TabIndex = 3;
            this.lblSucheKanton.Text = "Kanton";
            this.lblSucheKanton.UseCompatibleTextRendering = true;
            //
            // edtSucheKanton
            //
            this.edtSucheKanton.Location = new System.Drawing.Point(142, 70);
            this.edtSucheKanton.LOVName = "Kanton";
            this.edtSucheKanton.Name = "edtSucheKanton";
            this.edtSucheKanton.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKanton.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKanton.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKanton.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKanton.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKanton.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKanton.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheKanton.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtSucheKanton.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKanton.Properties.NullText = "";
            this.edtSucheKanton.Properties.ShowFooter = false;
            this.edtSucheKanton.Properties.ShowHeader = false;
            this.edtSucheKanton.Size = new System.Drawing.Size(215, 24);
            this.edtSucheKanton.TabIndex = 4;
            //
            // lblSucheBemerkungen
            //
            this.lblSucheBemerkungen.Location = new System.Drawing.Point(31, 100);
            this.lblSucheBemerkungen.Name = "lblSucheBemerkungen";
            this.lblSucheBemerkungen.Size = new System.Drawing.Size(105, 24);
            this.lblSucheBemerkungen.TabIndex = 5;
            this.lblSucheBemerkungen.Text = "Bemerkungen";
            this.lblSucheBemerkungen.UseCompatibleTextRendering = true;
            //
            // edtSucheBemerkungen
            //
            this.edtSucheBemerkungen.Location = new System.Drawing.Point(142, 100);
            this.edtSucheBemerkungen.Name = "edtSucheBemerkungen";
            this.edtSucheBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBemerkungen.Size = new System.Drawing.Size(215, 24);
            this.edtSucheBemerkungen.TabIndex = 6;
            //
            // chkSucheAktiv
            //
            this.chkSucheAktiv.EditValue = false;
            this.chkSucheAktiv.Location = new System.Drawing.Point(142, 130);
            this.chkSucheAktiv.Name = "chkSucheAktiv";
            this.chkSucheAktiv.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSucheAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheAktiv.Properties.Caption = "Nur aktive";
            this.chkSucheAktiv.Size = new System.Drawing.Size(215, 19);
            this.chkSucheAktiv.TabIndex = 7;
            //
            // panDetails
            //
            this.panDetails.Controls.Add(this.edtBemerkungen);
            this.panDetails.Controls.Add(this.lblBemerkungen);
            this.panDetails.Controls.Add(this.chkAktiv);
            this.panDetails.Controls.Add(this.edtKanton);
            this.panDetails.Controls.Add(this.lblKanton);
            this.panDetails.Controls.Add(this.edtBezeichnung);
            this.panDetails.Controls.Add(this.lblBezeichnung);
            this.panDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetails.Location = new System.Drawing.Point(0, 412);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(792, 157);
            this.panDetails.TabIndex = 1;
            //
            // lblBezeichnung
            //
            this.lblBezeichnung.Location = new System.Drawing.Point(9, 9);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(100, 23);
            this.lblBezeichnung.TabIndex = 0;
            this.lblBezeichnung.Text = "Bezeichnung";
            this.lblBezeichnung.UseCompatibleTextRendering = true;
            //
            // edtBezeichnung
            //
            this.edtBezeichnung.DataMember = null;
            this.edtBezeichnung.DataMemberDefaultText = "Bezeichnung";
            this.edtBezeichnung.DataMemberTID = "BezeichnungTID";
            this.edtBezeichnung.DataSource = this.qryBaKantonalerZuschuss;
            this.edtBezeichnung.Location = new System.Drawing.Point(115, 9);
            this.edtBezeichnung.Name = "edtBezeichnung";
            this.edtBezeichnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBezeichnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBezeichnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBezeichnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBezeichnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBezeichnung.Properties.Appearance.Options.UseFont = true;
            this.edtBezeichnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBezeichnung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtBezeichnung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBezeichnung.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtBezeichnung.Size = new System.Drawing.Size(248, 24);
            this.edtBezeichnung.TabIndex = 1;
            //
            // lblKanton
            //
            this.lblKanton.Location = new System.Drawing.Point(9, 39);
            this.lblKanton.Name = "lblKanton";
            this.lblKanton.Size = new System.Drawing.Size(100, 24);
            this.lblKanton.TabIndex = 2;
            this.lblKanton.Text = "Kanton";
            this.lblKanton.UseCompatibleTextRendering = true;
            //
            // edtKanton
            //
            this.edtKanton.AllowNull = false;
            this.edtKanton.DataMember = "KantonCode";
            this.edtKanton.DataSource = this.qryBaKantonalerZuschuss;
            this.edtKanton.Location = new System.Drawing.Point(115, 39);
            this.edtKanton.LOVName = "Kanton";
            this.edtKanton.Name = "edtKanton";
            this.edtKanton.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKanton.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKanton.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKanton.Properties.Appearance.Options.UseBackColor = true;
            this.edtKanton.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKanton.Properties.Appearance.Options.UseFont = true;
            this.edtKanton.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKanton.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKanton.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKanton.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKanton.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtKanton.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtKanton.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKanton.Properties.NullText = "";
            this.edtKanton.Properties.ShowFooter = false;
            this.edtKanton.Properties.ShowHeader = false;
            this.edtKanton.Size = new System.Drawing.Size(248, 24);
            this.edtKanton.TabIndex = 3;
            //
            // chkAktiv
            //
            this.chkAktiv.DataMember = "Aktiv";
            this.chkAktiv.DataSource = this.qryBaKantonalerZuschuss;
            this.chkAktiv.Location = new System.Drawing.Point(115, 69);
            this.chkAktiv.Name = "chkAktiv";
            this.chkAktiv.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.chkAktiv.Properties.Caption = "Aktiv";
            this.chkAktiv.Size = new System.Drawing.Size(248, 19);
            this.chkAktiv.TabIndex = 4;
            //
            // lblBemerkungen
            //
            this.lblBemerkungen.Location = new System.Drawing.Point(9, 94);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(100, 24);
            this.lblBemerkungen.TabIndex = 5;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            //
            // edtBemerkungen
            //
            this.edtBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkungen.DataMember = "Bemerkungen";
            this.edtBemerkungen.DataSource = this.qryBaKantonalerZuschuss;
            this.edtBemerkungen.Location = new System.Drawing.Point(115, 94);
            this.edtBemerkungen.Name = "edtBemerkungen";
            this.edtBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkungen.Properties.MaxLength = 2000;
            this.edtBemerkungen.Size = new System.Drawing.Size(470, 54);
            this.edtBemerkungen.TabIndex = 6;
            //
            // colAktiv
            //
            this.colAktiv.Caption = "Aktiv";
            this.colAktiv.FieldName = "Aktiv";
            this.colAktiv.Name = "colAktiv";
            this.colAktiv.Visible = true;
            this.colAktiv.VisibleIndex = 2;
            this.colAktiv.Width = 60;
            //
            // colAnzahlZugewiesen
            //
            this.colAnzahlZugewiesen.Caption = "Zugewiesen";
            this.colAnzahlZugewiesen.FieldName = "AnzahlZugewiesen";
            this.colAnzahlZugewiesen.Name = "colAnzahlZugewiesen";
            this.colAnzahlZugewiesen.Visible = true;
            this.colAnzahlZugewiesen.VisibleIndex = 4;
            this.colAnzahlZugewiesen.Width = 90;
            //
            // colBemerkungen
            //
            this.colBemerkungen.Caption = "Bemerkungen";
            this.colBemerkungen.FieldName = "Bemerkungen";
            this.colBemerkungen.Name = "colBemerkungen";
            this.colBemerkungen.Visible = true;
            this.colBemerkungen.VisibleIndex = 3;
            this.colBemerkungen.Width = 200;
            //
            // colBezeichnung
            //
            this.colBezeichnung.Caption = "Bezeichnung";
            this.colBezeichnung.FieldName = "MLBezeichnung";
            this.colBezeichnung.Name = "colBezeichnung";
            this.colBezeichnung.Visible = true;
            this.colBezeichnung.VisibleIndex = 0;
            this.colBezeichnung.Width = 200;
            //
            // colKanton
            //
            this.colKanton.Caption = "Kanton";
            this.colKanton.FieldName = "Kanton";
            this.colKanton.Name = "colKanton";
            this.colKanton.Visible = true;
            this.colKanton.VisibleIndex = 1;
            this.colKanton.Width = 150;
            //
            // grvBaKantonalerZuschuss
            //
            this.grvBaKantonalerZuschuss.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaKantonalerZuschuss.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaKantonalerZuschuss.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaKantonalerZuschuss.Appearance.Empty.Options.UseFont = true;
            this.grvBaKantonalerZuschuss.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaKantonalerZuschuss.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaKantonalerZuschuss.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaKantonalerZuschuss.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaKantonalerZuschuss.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaKantonalerZuschuss.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaKantonalerZuschuss.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaKantonalerZuschuss.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaKantonalerZuschuss.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaKantonalerZuschuss.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaKantonalerZuschuss.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaKantonalerZuschuss.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaKantonalerZuschuss.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaKantonalerZuschuss.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaKantonalerZuschuss.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaKantonalerZuschuss.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaKantonalerZuschuss.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaKantonalerZuschuss.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaKantonalerZuschuss.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaKantonalerZuschuss.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaKantonalerZuschuss.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaKantonalerZuschuss.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaKantonalerZuschuss.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaKantonalerZuschuss.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaKantonalerZuschuss.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaKantonalerZuschuss.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaKantonalerZuschuss.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaKantonalerZuschuss.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaKantonalerZuschuss.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaKantonalerZuschuss.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaKantonalerZuschuss.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaKantonalerZuschuss.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaKantonalerZuschuss.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaKantonalerZuschuss.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaKantonalerZuschuss.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaKantonalerZuschuss.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaKantonalerZuschuss.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaKantonalerZuschuss.Appearance.OddRow.Options.UseFont = true;
            this.grvBaKantonalerZuschuss.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaKantonalerZuschuss.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaKantonalerZuschuss.Appearance.Row.Options.UseBackColor = true;
            this.grvBaKantonalerZuschuss.Appearance.Row.Options.UseFont = true;
            this.grvBaKantonalerZuschuss.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaKantonalerZuschuss.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaKantonalerZuschuss.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaKantonalerZuschuss.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaKantonalerZuschuss.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaKantonalerZuschuss.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colBezeichnung,
                        this.colKanton,
                        this.colAktiv,
                        this.colBemerkungen,
                        this.colAnzahlZugewiesen});
            this.grvBaKantonalerZuschuss.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaKantonalerZuschuss.GridControl = this.grdBaKantonalerZuschuss;
            this.grvBaKantonalerZuschuss.Name = "grvBaKantonalerZuschuss";
            this.grvBaKantonalerZuschuss.OptionsBehavior.Editable = false;
            this.grvBaKantonalerZuschuss.OptionsCustomization.AllowFilter = false;
            this.grvBaKantonalerZuschuss.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaKantonalerZuschuss.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaKantonalerZuschuss.OptionsNavigation.UseTabKey = false;
            this.grvBaKantonalerZuschuss.OptionsView.ColumnAutoWidth = false;
            this.grvBaKantonalerZuschuss.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaKantonalerZuschuss.OptionsView.ShowGroupPanel = false;
            this.grvBaKantonalerZuschuss.OptionsView.ShowIndicator = false;
            //
            // qryBaKantonalerZuschuss
            //
            this.qryBaKantonalerZuschuss.HostControl = this;
            this.qryBaKantonalerZuschuss.SelectStatement = resources.GetString("qryBaKantonalerZuschuss.SelectStatement");
            this.qryBaKantonalerZuschuss.TableName = "BaKantonalerZuschuss";
            this.qryBaKantonalerZuschuss.BeforePost += new System.EventHandler(this.qryBaKantonalerZuschuss_BeforePost);
            this.qryBaKantonalerZuschuss.AfterFill += new System.EventHandler(this.qryBaKantonalerZuschuss_AfterFill);
            this.qryBaKantonalerZuschuss.AfterInsert += new System.EventHandler(this.qryBaKantonalerZuschuss_AfterInsert);
            this.qryBaKantonalerZuschuss.BeforeDeleteQuestion += new System.EventHandler(this.qryBaKantonalerZuschuss_BeforeDeleteQuestion);
            this.qryBaKantonalerZuschuss.AfterPost += new System.EventHandler(this.qryBaKantonalerZuschuss_AfterPost);
            //
            // CtlAdKantonaleZuschuesse
            //
            this.ActiveSQLQuery = this.qryBaKantonalerZuschuss;
            this.Controls.Add(this.panDetails);
            this.Name = "CtlAdKantonaleZuschuesse";
            this.Size = new System.Drawing.Size(792, 569);
            this.Load += new System.EventHandler(this.CtlAdKantonaleZuschuesse_Load);
            this.Controls.SetChildIndex(this.panDetails, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaKantonalerZuschuss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBezeichnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKanton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKanton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKanton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheAktiv.Properties)).EndInit();
            this.panDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezeichnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKanton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKanton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKanton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaKantonalerZuschuss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaKantonalerZuschuss)).EndInit();
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

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // set default values and focus
            chkSucheAktiv.Checked = true;

            // set focus
            edtSucheBezeichnung.Focus();
        }

        protected override void RunSearch()
        {
            // replace search parameters
            Object[] parameters = new Object[] { Session.User.LanguageCode };
            this.kissSearch.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void CtlAdKantonaleZuschuesse_Load(object sender, System.EventArgs e)
        {
            // run search
            this.NewSearch();
            this.tabControlSearch.SelectTab(this.tpgListe);
        }

        private void SetupRights()
        {
            // VARS
            Boolean isAdmin = Session.User.IsUserAdmin;
            Boolean canReadData = false;
            Boolean canInsert = false;
            Boolean canUpdate = false;
            Boolean canDelete = false;

            // set values
            Session.GetUserRight(this.Name, out canReadData, out canInsert, out canUpdate, out canDelete);
            if (!canReadData)
            {
                // no rights to view this control
                throw new Exception("No rights to view details of this control.");
            }

            // BaKantonalerZuschuss
            qryBaKantonalerZuschuss.CanInsert = isAdmin || canInsert;
            qryBaKantonalerZuschuss.CanUpdate = isAdmin || canUpdate;
            qryBaKantonalerZuschuss.CanDelete = isAdmin || canDelete;

            // FIELDS
            qryBaKantonalerZuschuss.EnableBoundFields();
        }

        private void qryBaKantonalerZuschuss_AfterFill(object sender, System.EventArgs e)
        {
            // select last row
            qryBaKantonalerZuschuss.Last();
        }

        private void qryBaKantonalerZuschuss_AfterInsert(object sender, System.EventArgs e)
        {
            // set default value
            qryBaKantonalerZuschuss["Aktiv"] = 1;
            qryBaKantonalerZuschuss["AnzahlZugewiesen"] = 0;

            // creator of row (if changed)
            qryBaKantonalerZuschuss["Creator"] = DBUtil.GetDBRowCreatorModifier();

            // set focus
            edtBezeichnung.Focus();
        }

        private void qryBaKantonalerZuschuss_AfterPost(object sender, System.EventArgs e)
        {
            // apply new data
            qryBaKantonalerZuschuss["MLBezeichnung"] = edtBezeichnung.Text;
            qryBaKantonalerZuschuss["Kanton"] = edtKanton.Text;
        }

        private void qryBaKantonalerZuschuss_BeforeDeleteQuestion(object sender, System.EventArgs e)
        {
            // check if entry is not in use already
            Int32 countUsage = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT COUNT(1)
                    FROM dbo.BaPerson_KantonalerZuschuss WITH (READUNCOMMITTED)
                    WHERE BaKantonalerZuschussID = {0}", qryBaKantonalerZuschuss["BaKantonalerZuschussID"]));

            if (countUsage > 0)
            {
                // entry cannot be deleted because of usage
                KissMsg.ShowError("CtlAdKantonaleZuschuesse", "CannotDeleteEntry", "Dieser Eintrag ist zurzeit zu mindestens einer Person zugewiesen und kann daher nicht gelöscht werden.");

                // cancel
                throw new KissCancelException();
            }
        }

        private void qryBaKantonalerZuschuss_BeforePost(object sender, System.EventArgs e)
        {
            // validate mustfields
            DBUtil.CheckNotNullField(edtBezeichnung, lblBezeichnung.Text);
            DBUtil.CheckNotNullField(edtKanton, lblKanton.Text);

            // confirm disabled
            if (!DBUtil.IsEmpty(qryBaKantonalerZuschuss["Aktiv"]) &&
                !Convert.ToBoolean(qryBaKantonalerZuschuss["Aktiv"]) &&
                !DBUtil.IsEmpty(qryBaKantonalerZuschuss["AnzahlZugewiesen"]) &&
                Convert.ToInt32(qryBaKantonalerZuschuss["AnzahlZugewiesen"]) > 0)
            {
                // info: entry is disabled but has some assigned persons
                KissMsg.ShowInfo("CtlAdKantonaleZuschuesse", "DisabledButAssigned", "Dieser Eintrag ist inaktiv aber zu mindestens einer Person zugewiesen. Inaktive zugewiesene kantonale Zuschüsse werden bei den zugewiesenen Personen nicht angezeigt.");
            }
        }

        #endregion
    }
}