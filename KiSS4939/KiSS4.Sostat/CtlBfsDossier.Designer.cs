using KiSS4.Gui;

namespace KiSS4.Sostat
{
    partial class CtlBfsDossier
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private KiSS4.Gui.KissCheckEdit chkStichtag;
        private DevExpress.XtraGrid.Columns.GridColumn colBFSPersonCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colIndex;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonName;
        private KiSS4.Common.CtlGotoFall ctlGotoFall1;
        private KiSS4.Gui.KissCalcEdit edtBFSDossierID;
        private Gui.KissCalcEdit edtBFSDossierNr;
        private KiSS4.Gui.KissLookUpEdit edtBFSDossierStatusCode;
        private KiSS4.Gui.KissLookUpEdit edtBFSLeistungsArtCode;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissDateEdit edtExportDatum;
        private KiSS4.Gui.KissCalcEdit edtFFLeistungsNr;
        private KiSS4.Gui.KissDateEdit edtImportDatum;
        private KiSS4.Gui.KissCalcEdit edtJahr;
        private KiSS4.Gui.KissDateEdit edtPlausibilisierungDatum;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private KiSS4.Gui.KissLookUpEdit edtZustaendigeGemeinde;
        private KiSS4.Gui.KissGrid grdPersonen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPersonen;
        private KiSS4.Gui.KissLabel lblBFSDossierID;
        private Gui.KissLabel lblBFSDossierNr;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblExportDatum;
        private KiSS4.Gui.KissLabel lblFFLeistungsNr;
        private KiSS4.Gui.KissLabel lblGemeinde;
        private KiSS4.Gui.KissLabel lblImportDatum;
        private KiSS4.Gui.KissLabel lblJahr;
        private KiSS4.Gui.KissLabel lblLeistungsart;
        private KiSS4.Gui.KissLabel lblMitarbeiterIn;
        private KiSS4.Gui.KissLabel lblPersonen;
        private KiSS4.Gui.KissLabel lblPlausiDatum;
        private KiSS4.Gui.KissLabel lblStatus;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblXMLDatei;
        private KiSS4.Gui.KissMemoEdit memXML;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitle;
        private KiSS4.DB.SqlQuery qryBFSDossier;
        private KissCalcEdit edtKatalogversion;
        private KissLabel lblKatalogversion;
        private KiSS4.DB.SqlQuery qryBFSDossierPerson;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBfsDossier));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.edtJahr = new KiSS4.Gui.KissCalcEdit();
            this.qryBFSDossier = new KiSS4.DB.SqlQuery(this.components);
            this.chkStichtag = new KiSS4.Gui.KissCheckEdit();
            this.edtImportDatum = new KiSS4.Gui.KissDateEdit();
            this.edtBFSDossierID = new KiSS4.Gui.KissCalcEdit();
            this.edtPlausibilisierungDatum = new KiSS4.Gui.KissDateEdit();
            this.edtBFSDossierStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtExportDatum = new KiSS4.Gui.KissDateEdit();
            this.edtBFSLeistungsArtCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtFFLeistungsNr = new KiSS4.Gui.KissCalcEdit();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtZustaendigeGemeinde = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.grdPersonen = new KiSS4.Gui.KissGrid();
            this.qryBFSDossierPerson = new KiSS4.DB.SqlQuery(this.components);
            this.grvPersonen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBFSPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ctlGotoFall1 = new KiSS4.Common.CtlGotoFall();
            this.memXML = new KiSS4.Gui.KissMemoEdit();
            this.lblJahr = new KiSS4.Gui.KissLabel();
            this.lblImportDatum = new KiSS4.Gui.KissLabel();
            this.lblBFSDossierID = new KiSS4.Gui.KissLabel();
            this.lblPlausiDatum = new KiSS4.Gui.KissLabel();
            this.lblStatus = new KiSS4.Gui.KissLabel();
            this.lblExportDatum = new KiSS4.Gui.KissLabel();
            this.lblLeistungsart = new KiSS4.Gui.KissLabel();
            this.lblFFLeistungsNr = new KiSS4.Gui.KissLabel();
            this.lblMitarbeiterIn = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblGemeinde = new KiSS4.Gui.KissLabel();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.lblPersonen = new KiSS4.Gui.KissLabel();
            this.lblXMLDatei = new KiSS4.Gui.KissLabel();
            this.edtBFSDossierNr = new KiSS4.Gui.KissCalcEdit();
            this.lblBFSDossierNr = new KiSS4.Gui.KissLabel();
            this.lblKatalogversion = new KiSS4.Gui.KissLabel();
            this.edtKatalogversion = new KiSS4.Gui.KissCalcEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBFSDossier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStichtag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtImportDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSDossierID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlausibilisierungDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSDossierStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSDossierStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExportDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSLeistungsArtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSLeistungsArtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFFLeistungsNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeinde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBFSDossierPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memXML.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblImportDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBFSDossierID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlausiDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExportDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFFLeistungsNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiterIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblXMLDatei)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSDossierNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBFSDossierNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKatalogversion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKatalogversion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTitle);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 24);
            this.panel1.TabIndex = 0;
            // 
            // picTitle
            // 
            this.picTitle.Location = new System.Drawing.Point(5, 5);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(16, 16);
            this.picTitle.TabIndex = 293;
            this.picTitle.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Dossier";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // edtJahr
            // 
            this.edtJahr.DataMember = "Jahr";
            this.edtJahr.DataSource = this.qryBFSDossier;
            this.edtJahr.Location = new System.Drawing.Point(93, 60);
            this.edtJahr.Name = "edtJahr";
            this.edtJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtJahr.Properties.Appearance.Options.UseFont = true;
            this.edtJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtJahr.Size = new System.Drawing.Size(100, 24);
            this.edtJahr.TabIndex = 2;
            // 
            // qryBFSDossier
            // 
            this.qryBFSDossier.HostControl = this;
            this.qryBFSDossier.IsIdentityInsert = false;
            this.qryBFSDossier.TableName = "BFSDossier";
            this.qryBFSDossier.AfterPost += new System.EventHandler(this.qryBFSDossier_AfterPost);
            // 
            // chkStichtag
            // 
            this.chkStichtag.DataMember = "Stichtag";
            this.chkStichtag.DataSource = this.qryBFSDossier;
            this.chkStichtag.Location = new System.Drawing.Point(211, 62);
            this.chkStichtag.Name = "chkStichtag";
            this.chkStichtag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkStichtag.Properties.Appearance.Options.UseBackColor = true;
            this.chkStichtag.Properties.Caption = "Stichtag";
            this.chkStichtag.Size = new System.Drawing.Size(112, 19);
            this.chkStichtag.TabIndex = 3;
            // 
            // edtImportDatum
            // 
            this.edtImportDatum.DataMember = "ImportDatum";
            this.edtImportDatum.DataSource = this.qryBFSDossier;
            this.edtImportDatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtImportDatum.EditValue = null;
            this.edtImportDatum.Location = new System.Drawing.Point(554, 60);
            this.edtImportDatum.Name = "edtImportDatum";
            this.edtImportDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtImportDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtImportDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtImportDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtImportDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtImportDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtImportDatum.Properties.Appearance.Options.UseFont = true;
            this.edtImportDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtImportDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtImportDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtImportDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtImportDatum.Properties.ReadOnly = true;
            this.edtImportDatum.Properties.ShowToday = false;
            this.edtImportDatum.Size = new System.Drawing.Size(100, 24);
            this.edtImportDatum.TabIndex = 17;
            // 
            // edtBFSDossierID
            // 
            this.edtBFSDossierID.DataMember = "BFSDossierID";
            this.edtBFSDossierID.DataSource = this.qryBFSDossier;
            this.edtBFSDossierID.Location = new System.Drawing.Point(93, 90);
            this.edtBFSDossierID.Name = "edtBFSDossierID";
            this.edtBFSDossierID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBFSDossierID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBFSDossierID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBFSDossierID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSDossierID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBFSDossierID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBFSDossierID.Properties.Appearance.Options.UseFont = true;
            this.edtBFSDossierID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBFSDossierID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBFSDossierID.Size = new System.Drawing.Size(100, 24);
            this.edtBFSDossierID.TabIndex = 5;
            // 
            // edtPlausibilisierungDatum
            // 
            this.edtPlausibilisierungDatum.DataMember = "PlausibilisierungDatum";
            this.edtPlausibilisierungDatum.DataSource = this.qryBFSDossier;
            this.edtPlausibilisierungDatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPlausibilisierungDatum.EditValue = null;
            this.edtPlausibilisierungDatum.Location = new System.Drawing.Point(554, 90);
            this.edtPlausibilisierungDatum.Name = "edtPlausibilisierungDatum";
            this.edtPlausibilisierungDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPlausibilisierungDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPlausibilisierungDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPlausibilisierungDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPlausibilisierungDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtPlausibilisierungDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPlausibilisierungDatum.Properties.Appearance.Options.UseFont = true;
            this.edtPlausibilisierungDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtPlausibilisierungDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtPlausibilisierungDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtPlausibilisierungDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPlausibilisierungDatum.Properties.ReadOnly = true;
            this.edtPlausibilisierungDatum.Properties.ShowToday = false;
            this.edtPlausibilisierungDatum.Size = new System.Drawing.Size(100, 24);
            this.edtPlausibilisierungDatum.TabIndex = 19;
            // 
            // edtBFSDossierStatusCode
            // 
            this.edtBFSDossierStatusCode.DataMember = "BFSDossierStatusCode";
            this.edtBFSDossierStatusCode.DataSource = this.qryBFSDossier;
            this.edtBFSDossierStatusCode.Location = new System.Drawing.Point(93, 120);
            this.edtBFSDossierStatusCode.Name = "edtBFSDossierStatusCode";
            this.edtBFSDossierStatusCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBFSDossierStatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBFSDossierStatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSDossierStatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBFSDossierStatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBFSDossierStatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtBFSDossierStatusCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBFSDossierStatusCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSDossierStatusCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBFSDossierStatusCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBFSDossierStatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtBFSDossierStatusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtBFSDossierStatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBFSDossierStatusCode.Properties.NullText = "";
            this.edtBFSDossierStatusCode.Properties.ShowFooter = false;
            this.edtBFSDossierStatusCode.Properties.ShowHeader = false;
            this.edtBFSDossierStatusCode.Size = new System.Drawing.Size(304, 24);
            this.edtBFSDossierStatusCode.TabIndex = 9;
            this.edtBFSDossierStatusCode.Visible = false;
            // 
            // edtExportDatum
            // 
            this.edtExportDatum.DataMember = "ExportDatum";
            this.edtExportDatum.DataSource = this.qryBFSDossier;
            this.edtExportDatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtExportDatum.EditValue = null;
            this.edtExportDatum.Location = new System.Drawing.Point(554, 120);
            this.edtExportDatum.Name = "edtExportDatum";
            this.edtExportDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtExportDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtExportDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtExportDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtExportDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtExportDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtExportDatum.Properties.Appearance.Options.UseFont = true;
            this.edtExportDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtExportDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtExportDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtExportDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtExportDatum.Properties.ReadOnly = true;
            this.edtExportDatum.Properties.ShowToday = false;
            this.edtExportDatum.Size = new System.Drawing.Size(100, 24);
            this.edtExportDatum.TabIndex = 21;
            // 
            // edtBFSLeistungsArtCode
            // 
            this.edtBFSLeistungsArtCode.DataMember = "BFSLeistungsartCode";
            this.edtBFSLeistungsArtCode.DataSource = this.qryBFSDossier;
            this.edtBFSLeistungsArtCode.Location = new System.Drawing.Point(93, 150);
            this.edtBFSLeistungsArtCode.Name = "edtBFSLeistungsArtCode";
            this.edtBFSLeistungsArtCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBFSLeistungsArtCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBFSLeistungsArtCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSLeistungsArtCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBFSLeistungsArtCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBFSLeistungsArtCode.Properties.Appearance.Options.UseFont = true;
            this.edtBFSLeistungsArtCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBFSLeistungsArtCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSLeistungsArtCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBFSLeistungsArtCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBFSLeistungsArtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBFSLeistungsArtCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBFSLeistungsArtCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBFSLeistungsArtCode.Properties.NullText = "";
            this.edtBFSLeistungsArtCode.Properties.ShowFooter = false;
            this.edtBFSLeistungsArtCode.Properties.ShowHeader = false;
            this.edtBFSLeistungsArtCode.Size = new System.Drawing.Size(304, 24);
            this.edtBFSLeistungsArtCode.TabIndex = 11;
            // 
            // edtFFLeistungsNr
            // 
            this.edtFFLeistungsNr.DataMember = "FaLeistungID";
            this.edtFFLeistungsNr.DataSource = this.qryBFSDossier;
            this.edtFFLeistungsNr.Location = new System.Drawing.Point(554, 150);
            this.edtFFLeistungsNr.Name = "edtFFLeistungsNr";
            this.edtFFLeistungsNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFFLeistungsNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFFLeistungsNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFFLeistungsNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFFLeistungsNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtFFLeistungsNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFFLeistungsNr.Properties.Appearance.Options.UseFont = true;
            this.edtFFLeistungsNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFFLeistungsNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFFLeistungsNr.Size = new System.Drawing.Size(100, 24);
            this.edtFFLeistungsNr.TabIndex = 23;
            // 
            // edtUserID
            // 
            this.edtUserID.DataMember = "UserID";
            this.edtUserID.DataSource = this.qryBFSDossier;
            this.edtUserID.Location = new System.Drawing.Point(93, 180);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUserID.Size = new System.Drawing.Size(304, 24);
            this.edtUserID.TabIndex = 13;
            this.edtUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_UserModifiedFld);
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryBFSDossier;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(554, 180);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 25;
            // 
            // edtZustaendigeGemeinde
            // 
            this.edtZustaendigeGemeinde.DataMember = "ZustaendigeGemeinde";
            this.edtZustaendigeGemeinde.DataSource = this.qryBFSDossier;
            this.edtZustaendigeGemeinde.Location = new System.Drawing.Point(93, 210);
            this.edtZustaendigeGemeinde.Name = "edtZustaendigeGemeinde";
            this.edtZustaendigeGemeinde.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZustaendigeGemeinde.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustaendigeGemeinde.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigeGemeinde.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustaendigeGemeinde.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustaendigeGemeinde.Properties.Appearance.Options.UseFont = true;
            this.edtZustaendigeGemeinde.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZustaendigeGemeinde.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigeGemeinde.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZustaendigeGemeinde.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZustaendigeGemeinde.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtZustaendigeGemeinde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtZustaendigeGemeinde.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZustaendigeGemeinde.Properties.NullText = "";
            this.edtZustaendigeGemeinde.Properties.ShowFooter = false;
            this.edtZustaendigeGemeinde.Properties.ShowHeader = false;
            this.edtZustaendigeGemeinde.Size = new System.Drawing.Size(304, 24);
            this.edtZustaendigeGemeinde.TabIndex = 15;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryBFSDossier;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(554, 210);
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
            this.edtDatumBis.TabIndex = 27;
            // 
            // grdPersonen
            // 
            this.grdPersonen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdPersonen.DataSource = this.qryBFSDossierPerson;
            // 
            // 
            // 
            this.grdPersonen.EmbeddedNavigator.Name = "";
            this.grdPersonen.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdPersonen.Location = new System.Drawing.Point(93, 243);
            this.grdPersonen.MainView = this.grvPersonen;
            this.grdPersonen.Name = "grdPersonen";
            this.grdPersonen.Size = new System.Drawing.Size(561, 198);
            this.grdPersonen.TabIndex = 29;
            this.grdPersonen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPersonen});
            // 
            // qryBFSDossierPerson
            // 
            this.qryBFSDossierPerson.CanDelete = true;
            this.qryBFSDossierPerson.CanInsert = true;
            this.qryBFSDossierPerson.CanUpdate = true;
            this.qryBFSDossierPerson.HostControl = this;
            this.qryBFSDossierPerson.IsIdentityInsert = false;
            this.qryBFSDossierPerson.TableName = "BFSDossierPerson";
            this.qryBFSDossierPerson.AfterInsert += new System.EventHandler(this.qryBFSDossierPerson_AfterInsert);
            this.qryBFSDossierPerson.AfterPost += new System.EventHandler(this.qryBFSDossierPerson_AfterPost);
            this.qryBFSDossierPerson.BeforePost += new System.EventHandler(this.qryBFSDossierPerson_BeforePost);
            // 
            // grvPersonen
            // 
            this.grvPersonen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvPersonen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonen.Appearance.Empty.Options.UseBackColor = true;
            this.grvPersonen.Appearance.Empty.Options.UseFont = true;
            this.grvPersonen.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPersonen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonen.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvPersonen.Appearance.EvenRow.Options.UseFont = true;
            this.grvPersonen.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPersonen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvPersonen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvPersonen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvPersonen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvPersonen.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPersonen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvPersonen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvPersonen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvPersonen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvPersonen.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPersonen.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvPersonen.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvPersonen.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvPersonen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPersonen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvPersonen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPersonen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPersonen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPersonen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvPersonen.Appearance.GroupRow.Options.UseFont = true;
            this.grvPersonen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvPersonen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvPersonen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvPersonen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPersonen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvPersonen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvPersonen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPersonen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPersonen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPersonen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvPersonen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvPersonen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvPersonen.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvPersonen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvPersonen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonen.Appearance.OddRow.Options.UseFont = true;
            this.grvPersonen.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPersonen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonen.Appearance.Row.Options.UseBackColor = true;
            this.grvPersonen.Appearance.Row.Options.UseFont = true;
            this.grvPersonen.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvPersonen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPersonen.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvPersonen.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvPersonen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvPersonen.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvPersonen.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvPersonen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvPersonen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvPersonen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBFSPersonCode,
            this.colIndex,
            this.colPersonName,
            this.colBaPersonID});
            this.grvPersonen.GridControl = this.grdPersonen;
            this.grvPersonen.Name = "grvPersonen";
            this.grvPersonen.OptionsCustomization.AllowFilter = false;
            this.grvPersonen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPersonen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPersonen.OptionsView.ColumnAutoWidth = false;
            this.grvPersonen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvPersonen.OptionsView.ShowGroupPanel = false;
            // 
            // colBFSPersonCode
            // 
            this.colBFSPersonCode.Caption = "Typ";
            this.colBFSPersonCode.FieldName = "BFSPersonCode";
            this.colBFSPersonCode.Name = "colBFSPersonCode";
            this.colBFSPersonCode.Visible = true;
            this.colBFSPersonCode.VisibleIndex = 0;
            this.colBFSPersonCode.Width = 137;
            // 
            // colIndex
            // 
            this.colIndex.Caption = "Index";
            this.colIndex.FieldName = "PersonIndex";
            this.colIndex.Name = "colIndex";
            this.colIndex.OptionsColumn.AllowEdit = false;
            this.colIndex.Visible = true;
            this.colIndex.VisibleIndex = 1;
            this.colIndex.Width = 50;
            // 
            // colPersonName
            // 
            this.colPersonName.Caption = "Name";
            this.colPersonName.FieldName = "PersonName";
            this.colPersonName.Name = "colPersonName";
            this.colPersonName.Visible = true;
            this.colPersonName.VisibleIndex = 2;
            this.colPersonName.Width = 226;
            // 
            // colBaPersonID
            // 
            this.colBaPersonID.Caption = "FF Personen-Nr.";
            this.colBaPersonID.FieldName = "BaPersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.Visible = true;
            this.colBaPersonID.VisibleIndex = 3;
            this.colBaPersonID.Width = 101;
            // 
            // ctlGotoFall1
            // 
            this.ctlGotoFall1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFall1.DataMember = "BaPersonID$";
            this.ctlGotoFall1.DataSource = this.qryBFSDossierPerson;
            this.ctlGotoFall1.Location = new System.Drawing.Point(93, 447);
            this.ctlGotoFall1.Name = "ctlGotoFall1";
            this.ctlGotoFall1.Size = new System.Drawing.Size(210, 24);
            this.ctlGotoFall1.TabIndex = 30;
            // 
            // memXML
            // 
            this.memXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.memXML.DataMember = "XML";
            this.memXML.DataSource = this.qryBFSDossier;
            this.memXML.Location = new System.Drawing.Point(93, 480);
            this.memXML.Name = "memXML";
            this.memXML.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memXML.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memXML.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memXML.Properties.Appearance.Options.UseBackColor = true;
            this.memXML.Properties.Appearance.Options.UseBorderColor = true;
            this.memXML.Properties.Appearance.Options.UseFont = true;
            this.memXML.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memXML.Size = new System.Drawing.Size(561, 44);
            this.memXML.TabIndex = 32;
            // 
            // lblJahr
            // 
            this.lblJahr.Location = new System.Drawing.Point(5, 60);
            this.lblJahr.Name = "lblJahr";
            this.lblJahr.Size = new System.Drawing.Size(82, 24);
            this.lblJahr.TabIndex = 1;
            this.lblJahr.Text = "Jahr";
            this.lblJahr.UseCompatibleTextRendering = true;
            // 
            // lblImportDatum
            // 
            this.lblImportDatum.Location = new System.Drawing.Point(442, 60);
            this.lblImportDatum.Name = "lblImportDatum";
            this.lblImportDatum.Size = new System.Drawing.Size(106, 24);
            this.lblImportDatum.TabIndex = 16;
            this.lblImportDatum.Text = "Import-Datum";
            this.lblImportDatum.UseCompatibleTextRendering = true;
            // 
            // lblBFSDossierID
            // 
            this.lblBFSDossierID.Location = new System.Drawing.Point(5, 90);
            this.lblBFSDossierID.Name = "lblBFSDossierID";
            this.lblBFSDossierID.Size = new System.Drawing.Size(82, 24);
            this.lblBFSDossierID.TabIndex = 4;
            this.lblBFSDossierID.Text = "Dossier-ID";
            this.lblBFSDossierID.UseCompatibleTextRendering = true;
            // 
            // lblPlausiDatum
            // 
            this.lblPlausiDatum.Location = new System.Drawing.Point(442, 90);
            this.lblPlausiDatum.Name = "lblPlausiDatum";
            this.lblPlausiDatum.Size = new System.Drawing.Size(106, 24);
            this.lblPlausiDatum.TabIndex = 18;
            this.lblPlausiDatum.Text = "Plausi-Datum";
            this.lblPlausiDatum.UseCompatibleTextRendering = true;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(5, 120);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(82, 24);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status";
            this.lblStatus.UseCompatibleTextRendering = true;
            this.lblStatus.Visible = false;
            // 
            // lblExportDatum
            // 
            this.lblExportDatum.Location = new System.Drawing.Point(442, 120);
            this.lblExportDatum.Name = "lblExportDatum";
            this.lblExportDatum.Size = new System.Drawing.Size(106, 24);
            this.lblExportDatum.TabIndex = 20;
            this.lblExportDatum.Text = "Export-Datum";
            this.lblExportDatum.UseCompatibleTextRendering = true;
            // 
            // lblLeistungsart
            // 
            this.lblLeistungsart.Location = new System.Drawing.Point(5, 150);
            this.lblLeistungsart.Name = "lblLeistungsart";
            this.lblLeistungsart.Size = new System.Drawing.Size(82, 24);
            this.lblLeistungsart.TabIndex = 10;
            this.lblLeistungsart.Text = "Leistungsart";
            this.lblLeistungsart.UseCompatibleTextRendering = true;
            // 
            // lblFFLeistungsNr
            // 
            this.lblFFLeistungsNr.Location = new System.Drawing.Point(442, 150);
            this.lblFFLeistungsNr.Name = "lblFFLeistungsNr";
            this.lblFFLeistungsNr.Size = new System.Drawing.Size(106, 24);
            this.lblFFLeistungsNr.TabIndex = 22;
            this.lblFFLeistungsNr.Text = "FF-Leistungs-Nr.";
            this.lblFFLeistungsNr.UseCompatibleTextRendering = true;
            // 
            // lblMitarbeiterIn
            // 
            this.lblMitarbeiterIn.Location = new System.Drawing.Point(5, 180);
            this.lblMitarbeiterIn.Name = "lblMitarbeiterIn";
            this.lblMitarbeiterIn.Size = new System.Drawing.Size(82, 24);
            this.lblMitarbeiterIn.TabIndex = 12;
            this.lblMitarbeiterIn.Text = "Mitarbeiter/in";
            this.lblMitarbeiterIn.UseCompatibleTextRendering = true;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(442, 180);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(106, 24);
            this.lblDatumVon.TabIndex = 24;
            this.lblDatumVon.Text = "Datum von";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblGemeinde
            // 
            this.lblGemeinde.Location = new System.Drawing.Point(5, 210);
            this.lblGemeinde.Name = "lblGemeinde";
            this.lblGemeinde.Size = new System.Drawing.Size(82, 24);
            this.lblGemeinde.TabIndex = 14;
            this.lblGemeinde.Text = "Zust. Gemeinde";
            this.lblGemeinde.UseCompatibleTextRendering = true;
            // 
            // lblDatumBis
            // 
            this.lblDatumBis.Location = new System.Drawing.Point(442, 210);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(106, 24);
            this.lblDatumBis.TabIndex = 26;
            this.lblDatumBis.Text = "Datum bis";
            this.lblDatumBis.UseCompatibleTextRendering = true;
            // 
            // lblPersonen
            // 
            this.lblPersonen.Location = new System.Drawing.Point(5, 243);
            this.lblPersonen.Name = "lblPersonen";
            this.lblPersonen.Size = new System.Drawing.Size(82, 24);
            this.lblPersonen.TabIndex = 28;
            this.lblPersonen.Text = "Personen";
            this.lblPersonen.UseCompatibleTextRendering = true;
            // 
            // lblXMLDatei
            // 
            this.lblXMLDatei.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblXMLDatei.Location = new System.Drawing.Point(5, 480);
            this.lblXMLDatei.Name = "lblXMLDatei";
            this.lblXMLDatei.Size = new System.Drawing.Size(82, 24);
            this.lblXMLDatei.TabIndex = 31;
            this.lblXMLDatei.Text = "XML-Datei";
            this.lblXMLDatei.UseCompatibleTextRendering = true;
            // 
            // edtBFSDossierNr
            // 
            this.edtBFSDossierNr.DataMember = "BFSDossierNr";
            this.edtBFSDossierNr.DataSource = this.qryBFSDossier;
            this.edtBFSDossierNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBFSDossierNr.Location = new System.Drawing.Point(235, 90);
            this.edtBFSDossierNr.Name = "edtBFSDossierNr";
            this.edtBFSDossierNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBFSDossierNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBFSDossierNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBFSDossierNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBFSDossierNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtBFSDossierNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBFSDossierNr.Properties.Appearance.Options.UseFont = true;
            this.edtBFSDossierNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBFSDossierNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBFSDossierNr.Properties.ReadOnly = true;
            this.edtBFSDossierNr.Size = new System.Drawing.Size(162, 24);
            this.edtBFSDossierNr.TabIndex = 7;
            // 
            // lblBFSDossierNr
            // 
            this.lblBFSDossierNr.Location = new System.Drawing.Point(199, 90);
            this.lblBFSDossierNr.Name = "lblBFSDossierNr";
            this.lblBFSDossierNr.Size = new System.Drawing.Size(30, 24);
            this.lblBFSDossierNr.TabIndex = 6;
            this.lblBFSDossierNr.Text = "Nr.";
            this.lblBFSDossierNr.UseCompatibleTextRendering = true;
            // 
            // lblKatalogversion
            // 
            this.lblKatalogversion.Location = new System.Drawing.Point(442, 30);
            this.lblKatalogversion.Name = "lblKatalogversion";
            this.lblKatalogversion.Size = new System.Drawing.Size(106, 24);
            this.lblKatalogversion.TabIndex = 33;
            this.lblKatalogversion.Text = "Katalogversion";
            this.lblKatalogversion.UseCompatibleTextRendering = true;
            // 
            // edtKatalogversion
            // 
            this.edtKatalogversion.DataMember = "BFSKatalogVersionID";
            this.edtKatalogversion.DataSource = this.qryBFSDossier;
            this.edtKatalogversion.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKatalogversion.Location = new System.Drawing.Point(554, 30);
            this.edtKatalogversion.Name = "edtKatalogversion";
            this.edtKatalogversion.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKatalogversion.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKatalogversion.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKatalogversion.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKatalogversion.Properties.Appearance.Options.UseBackColor = true;
            this.edtKatalogversion.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKatalogversion.Properties.Appearance.Options.UseFont = true;
            this.edtKatalogversion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKatalogversion.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKatalogversion.Properties.ReadOnly = true;
            this.edtKatalogversion.Size = new System.Drawing.Size(100, 24);
            this.edtKatalogversion.TabIndex = 34;
            // 
            // CtlBfsDossier
            // 
            this.ActiveSQLQuery = this.qryBFSDossierPerson;
            this.Controls.Add(this.edtKatalogversion);
            this.Controls.Add(this.lblKatalogversion);
            this.Controls.Add(this.lblBFSDossierNr);
            this.Controls.Add(this.edtBFSDossierNr);
            this.Controls.Add(this.lblXMLDatei);
            this.Controls.Add(this.lblPersonen);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.lblGemeinde);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.lblMitarbeiterIn);
            this.Controls.Add(this.lblFFLeistungsNr);
            this.Controls.Add(this.lblLeistungsart);
            this.Controls.Add(this.lblExportDatum);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPlausiDatum);
            this.Controls.Add(this.lblBFSDossierID);
            this.Controls.Add(this.lblImportDatum);
            this.Controls.Add(this.lblJahr);
            this.Controls.Add(this.memXML);
            this.Controls.Add(this.ctlGotoFall1);
            this.Controls.Add(this.grdPersonen);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.edtZustaendigeGemeinde);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.edtUserID);
            this.Controls.Add(this.edtFFLeistungsNr);
            this.Controls.Add(this.edtBFSLeistungsArtCode);
            this.Controls.Add(this.edtExportDatum);
            this.Controls.Add(this.edtBFSDossierStatusCode);
            this.Controls.Add(this.edtPlausibilisierungDatum);
            this.Controls.Add(this.edtBFSDossierID);
            this.Controls.Add(this.edtImportDatum);
            this.Controls.Add(this.chkStichtag);
            this.Controls.Add(this.edtJahr);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(5, 0);
            this.Name = "CtlBfsDossier";
            this.Size = new System.Drawing.Size(722, 537);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBFSDossier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStichtag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtImportDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSDossierID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlausibilisierungDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSDossierStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSDossierStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExportDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSLeistungsArtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSLeistungsArtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFFLeistungsNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeinde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBFSDossierPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memXML.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblImportDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBFSDossierID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlausiDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExportDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFFLeistungsNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiterIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblXMLDatei)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBFSDossierNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBFSDossierNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKatalogversion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKatalogversion.Properties)).EndInit();
            this.ResumeLayout(false);

        }

    }
}
