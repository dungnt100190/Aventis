using System;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public class CtlKaVermittlungKandidatenSuchen : KiSS4.Gui.KissUserControl
    {
        private int _vermVorschlagID = -1;
        private KiSS4.Gui.KissLabel bl;
        private KiSS4.Gui.KissButton btnDetailsPerson;
        private KiSS4.Gui.KissButton btnEinsatzplatzDetails;
        private KiSS4.Gui.KissButton btnKandidatenSuchen;
        private KiSS4.Gui.KissButton btnZuweisen;
        private DevExpress.XtraGrid.Columns.GridColumn colBranchen;
        private DevExpress.XtraGrid.Columns.GridColumn colDeutsch;
        private DevExpress.XtraGrid.Columns.GridColumn colFuehrerausweis;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtBetrieb;
        private KiSS4.Gui.KissLookUpEdit edtDeutschM;
        private KiSS4.Gui.KissLookUpEdit edtDeutschS;
        private KiSS4.Gui.KissButtonEdit edtEinsatzplatzBezeichnung;
        private KiSS4.Gui.KissLookUpEdit edtFuehrerausweis;
        private KiSS4.Gui.KissTextEdit edtGeschlecht;
        private KiSS4.Gui.KissTextEdit edtNameVorname;
        private KiSS4.Gui.KissLookUpEdit edtPCKenntnisse;
        private KiSS4.Gui.KissButtonEdit edtZustaendigKA;
        private KiSS4.Gui.KissGrid grdKandidaten;

        private DevExpress.XtraGrid.Views.Grid.GridView grvKandidaten;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKandidaten_alt;
        private KiSS4.Gui.KissLabel lblBetrieb;
        private KiSS4.Gui.KissLabel lblDeutschMuendlich;
        private KiSS4.Gui.KissLabel lblDeutschSchriftlich;
        private KiSS4.Gui.KissLabel lblFuehrerausweis;
        private KiSS4.Gui.KissLabel lblNameVorname;
        private KiSS4.Gui.KissLabel lblNrBezeichnung;
        private KiSS4.Gui.KissLabel lblPCKenntnisse;
        private KiSS4.Gui.KissLabel lblTitelEinsatzplatz;
        private KiSS4.Gui.KissLabel lblZustaendigKA;
        private KiSS4.DB.SqlQuery qryKaKandidaten;

        public CtlKaVermittlungKandidatenSuchen()
        {
            InitializeComponent();

            btnZuweisen.Enabled = false;
            btnDetailsPerson.Enabled = false;
            btnEinsatzplatzDetails.Enabled = false;
            btnKandidatenSuchen.Enabled = false;

            colFuehrerausweis.ColumnEdit = grdKandidaten.GetLOVLookUpEdit("JaNein");
            colDeutsch.ColumnEdit = grdKandidaten.GetLOVLookUpEdit("KaDeutschkenntnisse");
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdKandidaten = new KiSS4.Gui.KissGrid();
            this.lblTitelEinsatzplatz = new KiSS4.Gui.KissLabel();
            this.lblNrBezeichnung = new KiSS4.Gui.KissLabel();
            this.lblBetrieb = new KiSS4.Gui.KissLabel();
            this.edtEinsatzplatzBezeichnung = new KiSS4.Gui.KissButtonEdit();
            this.edtBetrieb = new KiSS4.Gui.KissTextEdit();
            this.btnEinsatzplatzDetails = new KiSS4.Gui.KissButton();
            this.btnZuweisen = new KiSS4.Gui.KissButton();
            this.lblZustaendigKA = new KiSS4.Gui.KissLabel();
            this.edtZustaendigKA = new KiSS4.Gui.KissButtonEdit();
            this.btnKandidatenSuchen = new KiSS4.Gui.KissButton();
            this.lblNameVorname = new KiSS4.Gui.KissLabel();
            this.bl = new KiSS4.Gui.KissLabel();
            this.btnDetailsPerson = new KiSS4.Gui.KissButton();
            this.lblDeutschMuendlich = new KiSS4.Gui.KissLabel();
            this.lblDeutschSchriftlich = new KiSS4.Gui.KissLabel();
            this.edtNameVorname = new KiSS4.Gui.KissTextEdit();
            this.edtDeutschM = new KiSS4.Gui.KissLookUpEdit();
            this.edtGeschlecht = new KiSS4.Gui.KissTextEdit();
            this.edtDeutschS = new KiSS4.Gui.KissLookUpEdit();
            this.lblPCKenntnisse = new KiSS4.Gui.KissLabel();
            this.edtPCKenntnisse = new KiSS4.Gui.KissLookUpEdit();
            this.lblFuehrerausweis = new KiSS4.Gui.KissLabel();
            this.edtFuehrerausweis = new KiSS4.Gui.KissLookUpEdit();
            this.colBranchen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeutsch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFuehrerausweis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvKandidaten = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grvKandidaten_alt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryKaKandidaten = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdKandidaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelEinsatzplatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNrBezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatzBezeichnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrieb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDeutschMuendlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDeutschSchriftlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPCKenntnisse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKenntnisse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKenntnisse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFuehrerausweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKandidaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKandidaten_alt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaKandidaten)).BeginInit();
            this.SuspendLayout();
            //
            // grdKandidaten
            //
            this.grdKandidaten.DataSource = this.qryKaKandidaten;
            this.grdKandidaten.EmbeddedNavigator.Name = "";
            this.grdKandidaten.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKandidaten.Location = new System.Drawing.Point(5, 112);
            this.grdKandidaten.MainView = this.grvKandidaten;
            this.grdKandidaten.Name = "grdKandidaten";
            this.grdKandidaten.Size = new System.Drawing.Size(783, 214);
            this.grdKandidaten.TabIndex = 0;
            this.grdKandidaten.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvKandidaten,
                        this.grvKandidaten_alt});
            //
            // lblTitelEinsatzplatz
            //
            this.lblTitelEinsatzplatz.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblTitelEinsatzplatz.Location = new System.Drawing.Point(4, 4);
            this.lblTitelEinsatzplatz.Name = "lblTitelEinsatzplatz";
            this.lblTitelEinsatzplatz.Size = new System.Drawing.Size(98, 16);
            this.lblTitelEinsatzplatz.TabIndex = 0;
            this.lblTitelEinsatzplatz.Text = "Einsatzplatz";
            this.lblTitelEinsatzplatz.UseCompatibleTextRendering = true;
            //
            // lblNrBezeichnung
            //
            this.lblNrBezeichnung.Location = new System.Drawing.Point(4, 24);
            this.lblNrBezeichnung.Name = "lblNrBezeichnung";
            this.lblNrBezeichnung.Size = new System.Drawing.Size(100, 23);
            this.lblNrBezeichnung.TabIndex = 1;
            this.lblNrBezeichnung.Text = "Nr./Bezeichnung";
            this.lblNrBezeichnung.UseCompatibleTextRendering = true;
            //
            // lblBetrieb
            //
            this.lblBetrieb.Location = new System.Drawing.Point(4, 53);
            this.lblBetrieb.Name = "lblBetrieb";
            this.lblBetrieb.Size = new System.Drawing.Size(100, 23);
            this.lblBetrieb.TabIndex = 2;
            this.lblBetrieb.Text = "Betrieb";
            this.lblBetrieb.UseCompatibleTextRendering = true;
            //
            // edtEinsatzplatzBezeichnung
            //
            this.edtEinsatzplatzBezeichnung.Location = new System.Drawing.Point(111, 24);
            this.edtEinsatzplatzBezeichnung.Name = "edtEinsatzplatzBezeichnung";
            this.edtEinsatzplatzBezeichnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzplatzBezeichnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzplatzBezeichnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzplatzBezeichnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzplatzBezeichnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzplatzBezeichnung.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzplatzBezeichnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEinsatzplatzBezeichnung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtEinsatzplatzBezeichnung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzplatzBezeichnung.Size = new System.Drawing.Size(336, 24);
            this.edtEinsatzplatzBezeichnung.TabIndex = 4;
            this.edtEinsatzplatzBezeichnung.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtEinsatzplatzBezeichnung_UserModifiedFld);
            //
            // edtBetrieb
            //
            this.edtBetrieb.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetrieb.Location = new System.Drawing.Point(111, 53);
            this.edtBetrieb.Name = "edtBetrieb";
            this.edtBetrieb.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetrieb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrieb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrieb.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrieb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrieb.Properties.Appearance.Options.UseFont = true;
            this.edtBetrieb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrieb.Properties.ReadOnly = true;
            this.edtBetrieb.Size = new System.Drawing.Size(336, 24);
            this.edtBetrieb.TabIndex = 5;
            //
            // btnEinsatzplatzDetails
            //
            this.btnEinsatzplatzDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEinsatzplatzDetails.Location = new System.Drawing.Point(475, 23);
            this.btnEinsatzplatzDetails.Name = "btnEinsatzplatzDetails";
            this.btnEinsatzplatzDetails.Size = new System.Drawing.Size(90, 24);
            this.btnEinsatzplatzDetails.TabIndex = 8;
            this.btnEinsatzplatzDetails.Text = "Details";
            this.btnEinsatzplatzDetails.UseCompatibleTextRendering = true;
            this.btnEinsatzplatzDetails.UseVisualStyleBackColor = true;
            this.btnEinsatzplatzDetails.Click += new System.EventHandler(this.btnEinsatzplatzDetails_Click);
            //
            // btnZuweisen
            //
            this.btnZuweisen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZuweisen.Location = new System.Drawing.Point(139, 438);
            this.btnZuweisen.Name = "btnZuweisen";
            this.btnZuweisen.Size = new System.Drawing.Size(140, 24);
            this.btnZuweisen.TabIndex = 12;
            this.btnZuweisen.Text = "Einsatzplatz zuweisen";
            this.btnZuweisen.UseCompatibleTextRendering = true;
            this.btnZuweisen.UseVisualStyleBackColor = false;
            this.btnZuweisen.Click += new System.EventHandler(this.btnZuweisen_Click);
            //
            // lblZustaendigKA
            //
            this.lblZustaendigKA.Location = new System.Drawing.Point(2, 82);
            this.lblZustaendigKA.Name = "lblZustaendigKA";
            this.lblZustaendigKA.Size = new System.Drawing.Size(100, 23);
            this.lblZustaendigKA.TabIndex = 16;
            this.lblZustaendigKA.Text = "Zuständig KA";
            this.lblZustaendigKA.UseCompatibleTextRendering = true;
            //
            // edtZustaendigKA
            //
            this.edtZustaendigKA.Location = new System.Drawing.Point(111, 82);
            this.edtZustaendigKA.Name = "edtZustaendigKA";
            this.edtZustaendigKA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZustaendigKA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustaendigKA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigKA.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustaendigKA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustaendigKA.Properties.Appearance.Options.UseFont = true;
            this.edtZustaendigKA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZustaendigKA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtZustaendigKA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZustaendigKA.Size = new System.Drawing.Size(336, 24);
            this.edtZustaendigKA.TabIndex = 17;
            this.edtZustaendigKA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtZustaendigKA_UserModifiedFld);
            //
            // btnKandidatenSuchen
            //
            this.btnKandidatenSuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKandidatenSuchen.Location = new System.Drawing.Point(475, 82);
            this.btnKandidatenSuchen.Name = "btnKandidatenSuchen";
            this.btnKandidatenSuchen.Size = new System.Drawing.Size(139, 24);
            this.btnKandidatenSuchen.TabIndex = 18;
            this.btnKandidatenSuchen.Text = "KandidatInnen suchen";
            this.btnKandidatenSuchen.UseCompatibleTextRendering = true;
            this.btnKandidatenSuchen.UseVisualStyleBackColor = false;
            this.btnKandidatenSuchen.Click += new System.EventHandler(this.btnKandidatenSuchen_Click);
            //
            // lblNameVorname
            //
            this.lblNameVorname.Location = new System.Drawing.Point(4, 337);
            this.lblNameVorname.Name = "lblNameVorname";
            this.lblNameVorname.Size = new System.Drawing.Size(100, 23);
            this.lblNameVorname.TabIndex = 19;
            this.lblNameVorname.Text = "Name/ Vorname";
            this.lblNameVorname.UseCompatibleTextRendering = true;
            //
            // bl
            //
            this.bl.Location = new System.Drawing.Point(4, 360);
            this.bl.Name = "bl";
            this.bl.Size = new System.Drawing.Size(100, 23);
            this.bl.TabIndex = 23;
            this.bl.Text = "Geschlecht";
            this.bl.UseCompatibleTextRendering = true;
            //
            // btnDetailsPerson
            //
            this.btnDetailsPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailsPerson.Location = new System.Drawing.Point(4, 438);
            this.btnDetailsPerson.Name = "btnDetailsPerson";
            this.btnDetailsPerson.Size = new System.Drawing.Size(129, 24);
            this.btnDetailsPerson.TabIndex = 25;
            this.btnDetailsPerson.Text = "Details zur Person";
            this.btnDetailsPerson.UseCompatibleTextRendering = true;
            this.btnDetailsPerson.UseVisualStyleBackColor = false;
            this.btnDetailsPerson.Click += new System.EventHandler(this.btnDetailsPerson_Click);
            //
            // lblDeutschMuendlich
            //
            this.lblDeutschMuendlich.Location = new System.Drawing.Point(302, 337);
            this.lblDeutschMuendlich.Name = "lblDeutschMuendlich";
            this.lblDeutschMuendlich.Size = new System.Drawing.Size(100, 23);
            this.lblDeutschMuendlich.TabIndex = 26;
            this.lblDeutschMuendlich.Text = "Deutsch mündlich";
            this.lblDeutschMuendlich.UseCompatibleTextRendering = true;
            //
            // lblDeutschSchriftlich
            //
            this.lblDeutschSchriftlich.Location = new System.Drawing.Point(302, 360);
            this.lblDeutschSchriftlich.Name = "lblDeutschSchriftlich";
            this.lblDeutschSchriftlich.Size = new System.Drawing.Size(100, 23);
            this.lblDeutschSchriftlich.TabIndex = 27;
            this.lblDeutschSchriftlich.Text = "Deutsch schriftlich";
            this.lblDeutschSchriftlich.UseCompatibleTextRendering = true;
            //
            // edtNameVorname
            //
            this.edtNameVorname.DataMember = "NameVorname";
            this.edtNameVorname.DataSource = this.qryKaKandidaten;
            this.edtNameVorname.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNameVorname.Location = new System.Drawing.Point(110, 337);
            this.edtNameVorname.Name = "edtNameVorname";
            this.edtNameVorname.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNameVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameVorname.Properties.Appearance.Options.UseFont = true;
            this.edtNameVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameVorname.Properties.ReadOnly = true;
            this.edtNameVorname.Size = new System.Drawing.Size(186, 24);
            this.edtNameVorname.TabIndex = 33;
            //
            // edtDeutschM
            //
            this.edtDeutschM.DataMember = "DeutschMuendlich";
            this.edtDeutschM.DataSource = this.qryKaKandidaten;
            this.edtDeutschM.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDeutschM.Location = new System.Drawing.Point(425, 336);
            this.edtDeutschM.LOVName = "KaDeutschkenntnisse";
            this.edtDeutschM.Name = "edtDeutschM";
            this.edtDeutschM.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDeutschM.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDeutschM.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDeutschM.Properties.Appearance.Options.UseBackColor = true;
            this.edtDeutschM.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDeutschM.Properties.Appearance.Options.UseFont = true;
            this.edtDeutschM.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDeutschM.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtDeutschM.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDeutschM.Properties.NullText = "";
            this.edtDeutschM.Properties.ReadOnly = true;
            this.edtDeutschM.Properties.ShowFooter = false;
            this.edtDeutschM.Properties.ShowHeader = false;
            this.edtDeutschM.Size = new System.Drawing.Size(170, 24);
            this.edtDeutschM.TabIndex = 35;
            //
            // edtGeschlecht
            //
            this.edtGeschlecht.DataMember = "Geschlecht";
            this.edtGeschlecht.DataSource = this.qryKaKandidaten;
            this.edtGeschlecht.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeschlecht.Location = new System.Drawing.Point(110, 360);
            this.edtGeschlecht.Name = "edtGeschlecht";
            this.edtGeschlecht.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeschlecht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeschlecht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlecht.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeschlecht.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeschlecht.Properties.Appearance.Options.UseFont = true;
            this.edtGeschlecht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGeschlecht.Properties.ReadOnly = true;
            this.edtGeschlecht.Size = new System.Drawing.Size(186, 24);
            this.edtGeschlecht.TabIndex = 37;
            //
            // edtDeutschS
            //
            this.edtDeutschS.DataMember = "DeutschSchriftlich";
            this.edtDeutschS.DataSource = this.qryKaKandidaten;
            this.edtDeutschS.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDeutschS.Location = new System.Drawing.Point(425, 359);
            this.edtDeutschS.LOVName = "KaDeutschkenntnisse";
            this.edtDeutschS.Name = "edtDeutschS";
            this.edtDeutschS.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDeutschS.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDeutschS.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDeutschS.Properties.Appearance.Options.UseBackColor = true;
            this.edtDeutschS.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDeutschS.Properties.Appearance.Options.UseFont = true;
            this.edtDeutschS.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDeutschS.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDeutschS.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDeutschS.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDeutschS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDeutschS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDeutschS.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDeutschS.Properties.NullText = "";
            this.edtDeutschS.Properties.ReadOnly = true;
            this.edtDeutschS.Properties.ShowFooter = false;
            this.edtDeutschS.Properties.ShowHeader = false;
            this.edtDeutschS.Size = new System.Drawing.Size(170, 24);
            this.edtDeutschS.TabIndex = 38;
            //
            // lblPCKenntnisse
            //
            this.lblPCKenntnisse.Location = new System.Drawing.Point(302, 383);
            this.lblPCKenntnisse.Name = "lblPCKenntnisse";
            this.lblPCKenntnisse.Size = new System.Drawing.Size(100, 23);
            this.lblPCKenntnisse.TabIndex = 39;
            this.lblPCKenntnisse.Text = "PC-Kenntnisse";
            this.lblPCKenntnisse.UseCompatibleTextRendering = true;
            //
            // edtPCKenntnisse
            //
            this.edtPCKenntnisse.DataMember = "PCKenntnisse";
            this.edtPCKenntnisse.DataSource = this.qryKaKandidaten;
            this.edtPCKenntnisse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPCKenntnisse.Location = new System.Drawing.Point(425, 382);
            this.edtPCKenntnisse.LOVName = "JaNein";
            this.edtPCKenntnisse.Name = "edtPCKenntnisse";
            this.edtPCKenntnisse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPCKenntnisse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPCKenntnisse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPCKenntnisse.Properties.Appearance.Options.UseBackColor = true;
            this.edtPCKenntnisse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPCKenntnisse.Properties.Appearance.Options.UseFont = true;
            this.edtPCKenntnisse.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtPCKenntnisse.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtPCKenntnisse.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtPCKenntnisse.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtPCKenntnisse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtPCKenntnisse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtPCKenntnisse.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPCKenntnisse.Properties.NullText = "";
            this.edtPCKenntnisse.Properties.ReadOnly = true;
            this.edtPCKenntnisse.Properties.ShowFooter = false;
            this.edtPCKenntnisse.Properties.ShowHeader = false;
            this.edtPCKenntnisse.Size = new System.Drawing.Size(71, 24);
            this.edtPCKenntnisse.TabIndex = 40;
            //
            // lblFuehrerausweis
            //
            this.lblFuehrerausweis.Location = new System.Drawing.Point(5, 384);
            this.lblFuehrerausweis.Name = "lblFuehrerausweis";
            this.lblFuehrerausweis.Size = new System.Drawing.Size(100, 23);
            this.lblFuehrerausweis.TabIndex = 41;
            this.lblFuehrerausweis.Text = "Führerausweis";
            this.lblFuehrerausweis.UseCompatibleTextRendering = true;
            //
            // edtFuehrerausweis
            //
            this.edtFuehrerausweis.DataMember = "Fuehrerausweis";
            this.edtFuehrerausweis.DataSource = this.qryKaKandidaten;
            this.edtFuehrerausweis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFuehrerausweis.Location = new System.Drawing.Point(110, 383);
            this.edtFuehrerausweis.LOVName = "JaNein";
            this.edtFuehrerausweis.Name = "edtFuehrerausweis";
            this.edtFuehrerausweis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFuehrerausweis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFuehrerausweis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFuehrerausweis.Properties.Appearance.Options.UseBackColor = true;
            this.edtFuehrerausweis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFuehrerausweis.Properties.Appearance.Options.UseFont = true;
            this.edtFuehrerausweis.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFuehrerausweis.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFuehrerausweis.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFuehrerausweis.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFuehrerausweis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtFuehrerausweis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtFuehrerausweis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFuehrerausweis.Properties.NullText = "";
            this.edtFuehrerausweis.Properties.ReadOnly = true;
            this.edtFuehrerausweis.Properties.ShowFooter = false;
            this.edtFuehrerausweis.Properties.ShowHeader = false;
            this.edtFuehrerausweis.Size = new System.Drawing.Size(69, 24);
            this.edtFuehrerausweis.TabIndex = 42;
            //
            // colBranchen
            //
            this.colBranchen.Caption = "Branchen";
            this.colBranchen.FieldName = "Branchen";
            this.colBranchen.Name = "colBranchen";
            this.colBranchen.Visible = true;
            this.colBranchen.VisibleIndex = 2;
            this.colBranchen.Width = 302;
            //
            // colDeutsch
            //
            this.colDeutsch.Caption = "Deutsch";
            this.colDeutsch.FieldName = "DeutschMuendlich";
            this.colDeutsch.Name = "colDeutsch";
            this.colDeutsch.Visible = true;
            this.colDeutsch.VisibleIndex = 4;
            //
            // colFuehrerausweis
            //
            this.colFuehrerausweis.Caption = "Führerausweis";
            this.colFuehrerausweis.FieldName = "Fuehrerausweis";
            this.colFuehrerausweis.Name = "colFuehrerausweis";
            this.colFuehrerausweis.Visible = true;
            this.colFuehrerausweis.VisibleIndex = 3;
            this.colFuehrerausweis.Width = 100;
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 131;
            //
            // colVorname
            //
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "Vorname";
            this.colVorname.Name = "colVorname";
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 1;
            this.colVorname.Width = 132;
            //
            // grvKandidaten
            //
            this.grvKandidaten.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKandidaten.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten.Appearance.Empty.Options.UseBackColor = true;
            this.grvKandidaten.Appearance.Empty.Options.UseFont = true;
            this.grvKandidaten.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten.Appearance.EvenRow.Options.UseFont = true;
            this.grvKandidaten.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKandidaten.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKandidaten.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKandidaten.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKandidaten.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKandidaten.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKandidaten.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKandidaten.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKandidaten.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKandidaten.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKandidaten.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKandidaten.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKandidaten.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKandidaten.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKandidaten.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKandidaten.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKandidaten.Appearance.GroupRow.Options.UseFont = true;
            this.grvKandidaten.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKandidaten.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKandidaten.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKandidaten.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKandidaten.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKandidaten.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKandidaten.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKandidaten.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKandidaten.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKandidaten.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKandidaten.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKandidaten.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKandidaten.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKandidaten.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKandidaten.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten.Appearance.OddRow.Options.UseFont = true;
            this.grvKandidaten.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKandidaten.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten.Appearance.Row.Options.UseBackColor = true;
            this.grvKandidaten.Appearance.Row.Options.UseFont = true;
            this.grvKandidaten.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKandidaten.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKandidaten.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKandidaten.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKandidaten.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colName,
                        this.colVorname,
                        this.colBranchen,
                        this.colFuehrerausweis,
                        this.colDeutsch});
            this.grvKandidaten.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKandidaten.GridControl = this.grdKandidaten;
            this.grvKandidaten.Name = "grvKandidaten";
            this.grvKandidaten.OptionsBehavior.Editable = false;
            this.grvKandidaten.OptionsCustomization.AllowFilter = false;
            this.grvKandidaten.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKandidaten.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKandidaten.OptionsNavigation.UseTabKey = false;
            this.grvKandidaten.OptionsView.ColumnAutoWidth = false;
            this.grvKandidaten.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKandidaten.OptionsView.ShowGroupPanel = false;
            this.grvKandidaten.OptionsView.ShowIndicator = false;
            //
            // grvKandidaten_alt
            //
            this.grvKandidaten_alt.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKandidaten_alt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten_alt.Appearance.Empty.Options.UseBackColor = true;
            this.grvKandidaten_alt.Appearance.Empty.Options.UseFont = true;
            this.grvKandidaten_alt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten_alt.Appearance.EvenRow.Options.UseFont = true;
            this.grvKandidaten_alt.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKandidaten_alt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten_alt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKandidaten_alt.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKandidaten_alt.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKandidaten_alt.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKandidaten_alt.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKandidaten_alt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten_alt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKandidaten_alt.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKandidaten_alt.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKandidaten_alt.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKandidaten_alt.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKandidaten_alt.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKandidaten_alt.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKandidaten_alt.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten_alt.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKandidaten_alt.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKandidaten_alt.Appearance.GroupRow.Options.UseFont = true;
            this.grvKandidaten_alt.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKandidaten_alt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKandidaten_alt.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKandidaten_alt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten_alt.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKandidaten_alt.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKandidaten_alt.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKandidaten_alt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKandidaten_alt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten_alt.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKandidaten_alt.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKandidaten_alt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKandidaten_alt.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKandidaten_alt.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKandidaten_alt.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKandidaten_alt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten_alt.Appearance.OddRow.Options.UseFont = true;
            this.grvKandidaten_alt.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKandidaten_alt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten_alt.Appearance.Row.Options.UseBackColor = true;
            this.grvKandidaten_alt.Appearance.Row.Options.UseFont = true;
            this.grvKandidaten_alt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKandidaten_alt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKandidaten_alt.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKandidaten_alt.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKandidaten_alt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKandidaten_alt.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKandidaten_alt.GridControl = this.grdKandidaten;
            this.grvKandidaten_alt.Name = "grvKandidaten_alt";
            this.grvKandidaten_alt.OptionsBehavior.Editable = false;
            this.grvKandidaten_alt.OptionsCustomization.AllowFilter = false;
            this.grvKandidaten_alt.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKandidaten_alt.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKandidaten_alt.OptionsNavigation.UseTabKey = false;
            this.grvKandidaten_alt.OptionsView.ColumnAutoWidth = false;
            this.grvKandidaten_alt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKandidaten_alt.OptionsView.ShowGroupPanel = false;
            this.grvKandidaten_alt.OptionsView.ShowIndicator = false;
            //
            // qryKaKandidaten
            //
            this.qryKaKandidaten.HostControl = this;
            this.qryKaKandidaten.SelectStatement = "exec spKaGetKandidaten {0}, {1}";
            this.qryKaKandidaten.AfterFill += new System.EventHandler(this.qryKaKandidaten_AfterFill);
            //
            // CtlKaVermittlungKandidatenSuchen
            //
            this.Controls.Add(this.edtFuehrerausweis);
            this.Controls.Add(this.lblFuehrerausweis);
            this.Controls.Add(this.edtPCKenntnisse);
            this.Controls.Add(this.lblPCKenntnisse);
            this.Controls.Add(this.edtDeutschS);
            this.Controls.Add(this.edtGeschlecht);
            this.Controls.Add(this.edtDeutschM);
            this.Controls.Add(this.edtNameVorname);
            this.Controls.Add(this.lblDeutschSchriftlich);
            this.Controls.Add(this.lblDeutschMuendlich);
            this.Controls.Add(this.btnDetailsPerson);
            this.Controls.Add(this.bl);
            this.Controls.Add(this.lblNameVorname);
            this.Controls.Add(this.btnKandidatenSuchen);
            this.Controls.Add(this.edtZustaendigKA);
            this.Controls.Add(this.lblZustaendigKA);
            this.Controls.Add(this.btnZuweisen);
            this.Controls.Add(this.btnEinsatzplatzDetails);
            this.Controls.Add(this.edtBetrieb);
            this.Controls.Add(this.edtEinsatzplatzBezeichnung);
            this.Controls.Add(this.lblBetrieb);
            this.Controls.Add(this.lblNrBezeichnung);
            this.Controls.Add(this.lblTitelEinsatzplatz);
            this.Controls.Add(this.grdKandidaten);
            this.Name = "CtlKaVermittlungKandidatenSuchen";
            this.Size = new System.Drawing.Size(793, 473);
            ((System.ComponentModel.ISupportInitialize)(this.grdKandidaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelEinsatzplatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNrBezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatzBezeichnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrieb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigKA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDeutschMuendlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDeutschSchriftlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDeutschS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPCKenntnisse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKenntnisse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKenntnisse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFuehrerausweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuehrerausweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKandidaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKandidaten_alt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKaKandidaten)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

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

        private void btnDetailsPerson_Click(object sender, System.EventArgs e)
        {
            CtlKaVerlauf.JumpToPath(qryKaKandidaten["BaPersonID"] as int?);
        }

        private void btnEinsatzplatzDetails_Click(object sender, System.EventArgs e)
        {
            FormController.SendMessage("FrmKaEinsatzorte", "Action", "JumpToEP", "KaEinsatzplatzID", edtEinsatzplatzBezeichnung.LookupID);
        }

        private void btnKandidatenSuchen_Click(object sender, System.EventArgs e)
        {
            qryKaKandidaten.Fill(edtEinsatzplatzBezeichnung.LookupID, edtZustaendigKA.LookupID);
        }

        private void btnZuweisen_Click(object sender, System.EventArgs e)
        {
            if (DBUtil.IsEmpty(edtEinsatzplatzBezeichnung.LookupID))
            {
                KissMsg.ShowInfo("CtlKaVermittlungKandidatenSuchen", "EinsatzplatzIDLeer", "Es ist kein Einsatzplatz selektiert!");
                return;
            }

            if (qryKaKandidaten.Count == 0)
            {
                KissMsg.ShowInfo("CtlKaVermittlungKandidatenSuchen", "PersonIDLeer", "Es ist kein Kandidat selektiert!");
                return;
            }

            try
            {
                _vermVorschlagID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"INSERT INTO KaVermittlungVorschlag
                        (KaEinsatzplatzID, FaLeistungID, SichtbarSDFlag, VorschlagErfasst)
                        VALUES ({0}, {1}, {2}, GetDate())
                        SELECT SCOPE_IDENTITY()",
                                    edtEinsatzplatzBezeichnung.LookupID, qryKaKandidaten["FaLeistungID"], KaUtil.IsVisibleSD(Convert.ToInt32(qryKaKandidaten["BaPersonID"]))));

                DBUtil.ExecSQL(@"INSERT INTO KaVermittlungEinsatz (KaVermittlungVorschlagID) VALUES ({0})", _vermVorschlagID);

                switch (Utils.ConvertToInt(qryKaKandidaten["ProgrammCode"]))
                {
                    case 1:
                        // Inizio
                        FormController.OpenForm("FrmFall", "Action", "JumpToVermittlung", "BaPersonID", Convert.ToInt32(qryKaKandidaten["BaPersonID"]), "ModulID", 7, "FieldName", "ClassName", "FieldValue", "CtlKaInizioEinsaetze", "KaVermittlungVorschlagID", _vermVorschlagID);
                        break;

                    case 2:
                        // Qualifizierung Jugend
                        FormController.OpenForm("FrmFall", "Action", "JumpToVermittlung", "BaPersonID", Convert.ToInt32(qryKaKandidaten["BaPersonID"]), "ModulID", 7, "FieldName", "ClassName", "FieldValue", "CtlKaQJExterneEinsaetze", "KaVermittlungVorschlagID", _vermVorschlagID);
                        break;

                    case 3:
                        // Vermittlung BI
                        FormController.OpenForm("FrmFall", "Action", "JumpToVermittlung", "BaPersonID", Convert.ToInt32(qryKaKandidaten["BaPersonID"]), "ModulID", 7, "FieldName", "ClassName", "FieldValue", "CtlKaVermittlungBIBIPStellenBI", "KaVermittlungVorschlagID", _vermVorschlagID);
                        break;

                    case 4:
                        // Vermittlung BIP
                        FormController.OpenForm("FrmFall", "Action", "JumpToVermittlung", "BaPersonID", Convert.ToInt32(qryKaKandidaten["BaPersonID"]), "ModulID", 7, "FieldName", "ClassName", "FieldValue", "CtlKaVermittlungBIBIPEinsaetzeBIP", "KaVermittlungVorschlagID", _vermVorschlagID);
                        break;

                    case 5:
                        // Vermittlung SI
                        FormController.OpenForm("FrmFall", "Action", "JumpToVermittlung", "BaPersonID", Convert.ToInt32(qryKaKandidaten["BaPersonID"]), "ModulID", 7, "FieldName", "ClassName", "FieldValue", "CtlKaVermittlungSIEinsaetze", "KaVermittlungVorschlagID", _vermVorschlagID);
                        break;
                }
            }
            catch { }
        }

        private void edtEinsatzplatzBezeichnung_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            btnEinsatzplatzDetails.Enabled = false;
            btnKandidatenSuchen.Enabled = false;

            string SearchString = edtEinsatzplatzBezeichnung.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtEinsatzplatzBezeichnung.EditValue = null;
                    edtEinsatzplatzBezeichnung.LookupID = null;
                    edtBetrieb.EditValue = null;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT ID$ = KaEinsatzplatzID,
                 Nr = KaEinsatzplatzID,
                     [Bezeichnung] = EIN.Bezeichnung,
                     Betrieb = BET.BetriebName,
                 Bez$ = Convert(varchar, EIN.KaEinsatzplatzID) + ' ' + EIN.Bezeichnung
              FROM   KaEinsatzplatz EIN
                LEFT JOIN KaBetrieb BET ON BET.KaBetriebID = EIN.KaBetriebID
              WHERE  Convert(varchar, EIN.KaEinsatzplatzID) + ' ' + EIN.Bezeichnung like '%' + {0} + '%'
              ORDER BY EIN.Bezeichnung ASC, BET.BetriebName ASC",
              SearchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtEinsatzplatzBezeichnung.EditValue = dlg[4];
                edtEinsatzplatzBezeichnung.LookupID = dlg[0];
                edtBetrieb.EditValue = dlg[3];
                btnEinsatzplatzDetails.Enabled = true;
                btnKandidatenSuchen.Enabled = true;
            }
        }

        private void edtZustaendigKA_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtZustaendigKA.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtZustaendigKA.EditValue = null;
                    edtZustaendigKA.LookupID = null;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT ID$ = UserID,
                     [Kürzel] = LogonName,
                     [Mitarbeiter/in] = NameVorname,
                     [Org.Einheit] = OrgUnit
              FROM   vwUser
              WHERE  NameVorname like '%' + {0} + '%'
              AND    LogonName like 'KA%'
              ORDER BY NameVorname",
              SearchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtZustaendigKA.EditValue = dlg[2];
                edtZustaendigKA.LookupID = dlg[0];
            }
        }

        private void qryKaKandidaten_AfterFill(object sender, System.EventArgs e)
        {
            btnDetailsPerson.Enabled = qryKaKandidaten.Count > 0;
            btnZuweisen.Enabled = (qryKaKandidaten.Count > 0 && DBUtil.UserHasRight("CtlKaVermittlungKandidatenSuchen", "UI"));
        }
    }
}