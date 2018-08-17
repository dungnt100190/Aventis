namespace KiSS4.Basis.PI
{
    partial class CtlBaKlientensystem
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaKlientensystem));
            this.lblKlientC = new KiSS4.Gui.KissLabel();
            this.lblKlient = new KiSS4.Gui.KissLabel();
            this.qryFalltraeger = new KiSS4.DB.SqlQuery(this.components);
            this.lblWohnsitzC = new KiSS4.Gui.KissLabel();
            this.lblWohnsitz = new KiSS4.Gui.KissLabel();
            this.lblPostadresseC = new KiSS4.Gui.KissLabel();
            this.lblPostadresse = new KiSS4.Gui.KissLabel();
            this.lblTelefonNummernC = new KiSS4.Gui.KissLabel();
            this.lblTelP = new KiSS4.Gui.KissLabel();
            this.lblEmailC = new KiSS4.Gui.KissLabel();
            this.lblEMail = new KiSS4.Gui.KissLabel();
            this.lblNationalitaetC = new KiSS4.Gui.KissLabel();
            this.lblNationalitaet = new KiSS4.Gui.KissLabel();
            this.lblAlterC = new KiSS4.Gui.KissLabel();
            this.lblAlter = new KiSS4.Gui.KissLabel();
            this.lblGeburtstagC = new KiSS4.Gui.KissLabel();
            this.lblGeburtstag = new KiSS4.Gui.KissLabel();
            this.lblGeschlechtC = new KiSS4.Gui.KissLabel();
            this.lblGeschlecht = new KiSS4.Gui.KissLabel();
            this.lblZivilstandC = new KiSS4.Gui.KissLabel();
            this.lblZivilstand = new KiSS4.Gui.KissLabel();
            this.lblTitelPersonen = new KiSS4.Gui.KissLabel();
            this.grdPersonen = new KiSS4.Gui.KissGrid();
            this.qryPersonRelation = new KiSS4.DB.SqlQuery(this.components);
            this.grvPersonen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeziehung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImGleicherHaushalt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repImGleichenHaushalt = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlechtCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonenTelNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonenEMail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repRelationFemale = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repRelationMale = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repRelationGeneric = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lblTitelInstitutionenFachpersonen = new KiSS4.Gui.KissLabel();
            this.grdInstitutionen = new KiSS4.Gui.KissGrid();
            this.qryFachpersonenInstitutionen = new KiSS4.DB.SqlQuery(this.components);
            this.grvInstitutionen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInstitution = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdresse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontaktPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrifftBaPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeziehungZuPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnUebersichtStammdaten = new KiSS4.Dokument.KissDocumentButton();
            this.panTitel = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitelBegleiterInnenEntlasterInnen = new KiSS4.Gui.KissLabel();
            this.grdBegleiterInnenEntlasterInnen = new KiSS4.Gui.KissGrid();
            this.qryBegleiterInnenEntlasterInnen = new KiSS4.DB.SqlQuery(this.components);
            this.grvBegleiterInnenEntlasterInnen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBWEDTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemBWEDIconCbo = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colBWEDName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBWEDAdresse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBWEDTelNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBWEDTelNrMobil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBWEDEMail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panKlient = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFalltraeger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostadresseC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostadresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefonNummernC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmailC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNationalitaetC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAlterC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAlter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtstagC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtstag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlechtC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZivilstandC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZivilstand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelPersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPersonRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repImGleichenHaushalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repRelationFemale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repRelationMale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repRelationGeneric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelInstitutionenFachpersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstitutionen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFachpersonenInstitutionen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInstitutionen)).BeginInit();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelBegleiterInnenEntlasterInnen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBegleiterInnenEntlasterInnen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBegleiterInnenEntlasterInnen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBegleiterInnenEntlasterInnen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemBWEDIconCbo)).BeginInit();
            this.panKlient.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblKlientC
            // 
            this.lblKlientC.Location = new System.Drawing.Point(9, 9);
            this.lblKlientC.Name = "lblKlientC";
            this.lblKlientC.Size = new System.Drawing.Size(113, 24);
            this.lblKlientC.TabIndex = 1;
            this.lblKlientC.Text = "Klient/in";
            this.lblKlientC.UseCompatibleTextRendering = true;
            // 
            // lblKlient
            // 
            this.lblKlient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKlient.DataMember = "Person";
            this.lblKlient.DataSource = this.qryFalltraeger;
            this.lblKlient.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblKlient.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblKlient.Location = new System.Drawing.Point(128, 9);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(345, 24);
            this.lblKlient.TabIndex = 2;
            this.lblKlient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKlient.UseCompatibleTextRendering = true;
            // 
            // qryFalltraeger
            // 
            this.qryFalltraeger.HostControl = this;
            this.qryFalltraeger.TableName = "BaPerson";
            // 
            // lblWohnsitzC
            // 
            this.lblWohnsitzC.Location = new System.Drawing.Point(9, 29);
            this.lblWohnsitzC.Name = "lblWohnsitzC";
            this.lblWohnsitzC.Size = new System.Drawing.Size(113, 24);
            this.lblWohnsitzC.TabIndex = 3;
            this.lblWohnsitzC.Text = "Wohnsitz (gesetzl.)";
            this.lblWohnsitzC.UseCompatibleTextRendering = true;
            // 
            // lblWohnsitz
            // 
            this.lblWohnsitz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWohnsitz.DataMember = "Wohnsitz";
            this.lblWohnsitz.DataSource = this.qryFalltraeger;
            this.lblWohnsitz.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblWohnsitz.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblWohnsitz.Location = new System.Drawing.Point(128, 29);
            this.lblWohnsitz.Name = "lblWohnsitz";
            this.lblWohnsitz.Size = new System.Drawing.Size(345, 24);
            this.lblWohnsitz.TabIndex = 4;
            this.lblWohnsitz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWohnsitz.UseCompatibleTextRendering = true;
            // 
            // lblPostadresseC
            // 
            this.lblPostadresseC.Location = new System.Drawing.Point(9, 49);
            this.lblPostadresseC.Name = "lblPostadresseC";
            this.lblPostadresseC.Size = new System.Drawing.Size(113, 24);
            this.lblPostadresseC.TabIndex = 5;
            this.lblPostadresseC.Text = "Postadresse";
            this.lblPostadresseC.UseCompatibleTextRendering = true;
            // 
            // lblPostadresse
            // 
            this.lblPostadresse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPostadresse.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblPostadresse.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPostadresse.Location = new System.Drawing.Point(128, 55);
            this.lblPostadresse.Name = "lblPostadresse";
            this.lblPostadresse.Size = new System.Drawing.Size(345, 58);
            this.lblPostadresse.TabIndex = 6;
            this.lblPostadresse.Text = "";
            this.lblPostadresse.UseCompatibleTextRendering = true;
            // 
            // lblTelefonNummernC
            // 
            this.lblTelefonNummernC.Location = new System.Drawing.Point(10, 109);
            this.lblTelefonNummernC.Name = "lblTelefonNummernC";
            this.lblTelefonNummernC.Size = new System.Drawing.Size(113, 24);
            this.lblTelefonNummernC.TabIndex = 7;
            this.lblTelefonNummernC.Text = "Telefon";
            this.lblTelefonNummernC.UseCompatibleTextRendering = true;
            // 
            // lblTelP
            // 
            this.lblTelP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTelP.DataMember = "TelefonNummern";
            this.lblTelP.DataSource = this.qryFalltraeger;
            this.lblTelP.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTelP.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblTelP.Location = new System.Drawing.Point(128, 109);
            this.lblTelP.Name = "lblTelP";
            this.lblTelP.Size = new System.Drawing.Size(581, 24);
            this.lblTelP.TabIndex = 8;
            this.lblTelP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTelP.UseCompatibleTextRendering = true;
            // 
            // lblEmailC
            // 
            this.lblEmailC.Location = new System.Drawing.Point(9, 129);
            this.lblEmailC.Name = "lblEmailC";
            this.lblEmailC.Size = new System.Drawing.Size(113, 24);
            this.lblEmailC.TabIndex = 13;
            this.lblEmailC.Text = "E-Mail";
            this.lblEmailC.UseCompatibleTextRendering = true;
            // 
            // lblEMail
            // 
            this.lblEMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEMail.DataMember = "EMail";
            this.lblEMail.DataSource = this.qryFalltraeger;
            this.lblEMail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblEMail.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblEMail.Location = new System.Drawing.Point(128, 129);
            this.lblEMail.Name = "lblEMail";
            this.lblEMail.Size = new System.Drawing.Size(582, 24);
            this.lblEMail.TabIndex = 14;
            this.lblEMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEMail.UseCompatibleTextRendering = true;
            // 
            // lblNationalitaetC
            // 
            this.lblNationalitaetC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNationalitaetC.Location = new System.Drawing.Point(489, 9);
            this.lblNationalitaetC.Name = "lblNationalitaetC";
            this.lblNationalitaetC.Size = new System.Drawing.Size(74, 24);
            this.lblNationalitaetC.TabIndex = 15;
            this.lblNationalitaetC.Text = "Nationalität";
            this.lblNationalitaetC.UseCompatibleTextRendering = true;
            // 
            // lblNationalitaet
            // 
            this.lblNationalitaet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNationalitaet.DataMember = "Nationalitaet";
            this.lblNationalitaet.DataSource = this.qryFalltraeger;
            this.lblNationalitaet.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblNationalitaet.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblNationalitaet.Location = new System.Drawing.Point(570, 9);
            this.lblNationalitaet.Name = "lblNationalitaet";
            this.lblNationalitaet.Size = new System.Drawing.Size(140, 24);
            this.lblNationalitaet.TabIndex = 16;
            this.lblNationalitaet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNationalitaet.UseCompatibleTextRendering = true;
            // 
            // lblAlterC
            // 
            this.lblAlterC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlterC.Location = new System.Drawing.Point(489, 29);
            this.lblAlterC.Name = "lblAlterC";
            this.lblAlterC.Size = new System.Drawing.Size(74, 24);
            this.lblAlterC.TabIndex = 17;
            this.lblAlterC.Text = "Alter";
            this.lblAlterC.UseCompatibleTextRendering = true;
            // 
            // lblAlter
            // 
            this.lblAlter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlter.DataMember = "Alter";
            this.lblAlter.DataSource = this.qryFalltraeger;
            this.lblAlter.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblAlter.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblAlter.Location = new System.Drawing.Point(569, 29);
            this.lblAlter.Name = "lblAlter";
            this.lblAlter.Size = new System.Drawing.Size(140, 24);
            this.lblAlter.TabIndex = 18;
            this.lblAlter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAlter.UseCompatibleTextRendering = true;
            // 
            // lblGeburtstagC
            // 
            this.lblGeburtstagC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGeburtstagC.Location = new System.Drawing.Point(489, 49);
            this.lblGeburtstagC.Name = "lblGeburtstagC";
            this.lblGeburtstagC.Size = new System.Drawing.Size(74, 24);
            this.lblGeburtstagC.TabIndex = 19;
            this.lblGeburtstagC.Text = "Geburtstag";
            this.lblGeburtstagC.UseCompatibleTextRendering = true;
            // 
            // lblGeburtstag
            // 
            this.lblGeburtstag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGeburtstag.DataMember = "Geburtstag";
            this.lblGeburtstag.DataSource = this.qryFalltraeger;
            this.lblGeburtstag.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblGeburtstag.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblGeburtstag.Location = new System.Drawing.Point(569, 49);
            this.lblGeburtstag.Name = "lblGeburtstag";
            this.lblGeburtstag.Size = new System.Drawing.Size(140, 24);
            this.lblGeburtstag.TabIndex = 20;
            this.lblGeburtstag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGeburtstag.UseCompatibleTextRendering = true;
            // 
            // lblGeschlechtC
            // 
            this.lblGeschlechtC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGeschlechtC.Location = new System.Drawing.Point(489, 69);
            this.lblGeschlechtC.Name = "lblGeschlechtC";
            this.lblGeschlechtC.Size = new System.Drawing.Size(74, 24);
            this.lblGeschlechtC.TabIndex = 21;
            this.lblGeschlechtC.Text = "Geschlecht";
            this.lblGeschlechtC.UseCompatibleTextRendering = true;
            // 
            // lblGeschlecht
            // 
            this.lblGeschlecht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGeschlecht.DataMember = "Geschlecht";
            this.lblGeschlecht.DataSource = this.qryFalltraeger;
            this.lblGeschlecht.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblGeschlecht.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblGeschlecht.Location = new System.Drawing.Point(569, 69);
            this.lblGeschlecht.Name = "lblGeschlecht";
            this.lblGeschlecht.Size = new System.Drawing.Size(140, 24);
            this.lblGeschlecht.TabIndex = 22;
            this.lblGeschlecht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGeschlecht.UseCompatibleTextRendering = true;
            // 
            // lblZivilstandC
            // 
            this.lblZivilstandC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZivilstandC.Location = new System.Drawing.Point(489, 89);
            this.lblZivilstandC.Name = "lblZivilstandC";
            this.lblZivilstandC.Size = new System.Drawing.Size(74, 24);
            this.lblZivilstandC.TabIndex = 23;
            this.lblZivilstandC.Text = "Zivilstand";
            this.lblZivilstandC.UseCompatibleTextRendering = true;
            // 
            // lblZivilstand
            // 
            this.lblZivilstand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZivilstand.DataMember = "Zivilstand";
            this.lblZivilstand.DataSource = this.qryFalltraeger;
            this.lblZivilstand.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblZivilstand.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblZivilstand.Location = new System.Drawing.Point(569, 89);
            this.lblZivilstand.Name = "lblZivilstand";
            this.lblZivilstand.Size = new System.Drawing.Size(140, 24);
            this.lblZivilstand.TabIndex = 24;
            this.lblZivilstand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblZivilstand.UseCompatibleTextRendering = true;
            // 
            // lblTitelPersonen
            // 
            this.lblTitelPersonen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitelPersonen.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitelPersonen.Location = new System.Drawing.Point(9, 6);
            this.lblTitelPersonen.Margin = new System.Windows.Forms.Padding(9, 6, 3, 0);
            this.lblTitelPersonen.Name = "lblTitelPersonen";
            this.lblTitelPersonen.Size = new System.Drawing.Size(710, 20);
            this.lblTitelPersonen.TabIndex = 25;
            this.lblTitelPersonen.Text = "Personen";
            this.lblTitelPersonen.UseCompatibleTextRendering = true;
            // 
            // grdPersonen
            // 
            this.grdPersonen.DataSource = this.qryPersonRelation;
            this.grdPersonen.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdPersonen.EmbeddedNavigator.Name = "";
            this.grdPersonen.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdPersonen.Location = new System.Drawing.Point(3, 29);
            this.grdPersonen.MainView = this.grvPersonen;
            this.grdPersonen.Name = "grdPersonen";
            this.grdPersonen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repRelationFemale,
            this.repRelationMale,
            this.repRelationGeneric,
            this.repImGleichenHaushalt});
            this.grdPersonen.Size = new System.Drawing.Size(716, 92);
            this.grdPersonen.TabIndex = 26;
            this.grdPersonen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPersonen});
            // 
            // qryPersonRelation
            // 
            this.qryPersonRelation.CanUpdate = true;
            this.qryPersonRelation.HostControl = this;
            this.qryPersonRelation.TableName = "BaPerson_Relation";
            this.qryPersonRelation.BeforePost += new System.EventHandler(this.qryPersonRelation_BeforePost);
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
            this.colName,
            this.colBeziehung,
            this.colImGleicherHaushalt,
            this.colAlter,
            this.colKlient,
            this.colGeschlechtCode,
            this.colPersonenTelNr,
            this.colPersonenEMail});
            this.grvPersonen.GridControl = this.grdPersonen;
            this.grvPersonen.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvPersonen.Name = "grvPersonen";
            this.grvPersonen.OptionsCustomization.AllowFilter = false;
            this.grvPersonen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPersonen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPersonen.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvPersonen.OptionsView.ColumnAutoWidth = false;
            this.grvPersonen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvPersonen.OptionsView.ShowGroupPanel = false;
            this.grvPersonen.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.grvPersonen_CustomRowCellEdit);
            // 
            // colName
            // 
            this.colName.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colName.AppearanceCell.Options.UseBackColor = true;
            this.colName.Caption = "Name";
            this.colName.FieldName = "Person";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowFocus = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 210;
            // 
            // colBeziehung
            // 
            this.colBeziehung.Caption = "Beziehung";
            this.colBeziehung.FieldName = "RelationID";
            this.colBeziehung.Name = "colBeziehung";
            this.colBeziehung.Visible = true;
            this.colBeziehung.VisibleIndex = 1;
            this.colBeziehung.Width = 210;
            // 
            // colImGleicherHaushalt
            // 
            this.colImGleicherHaushalt.Caption = "Gl. Haush.";
            this.colImGleicherHaushalt.ColumnEdit = this.repImGleichenHaushalt;
            this.colImGleicherHaushalt.FieldName = "ImGleichenHaushalt";
            this.colImGleicherHaushalt.Name = "colImGleicherHaushalt";
            this.colImGleicherHaushalt.Visible = true;
            this.colImGleicherHaushalt.VisibleIndex = 2;
            this.colImGleicherHaushalt.Width = 66;
            // 
            // repImGleichenHaushalt
            // 
            this.repImGleichenHaushalt.AutoHeight = false;
            this.repImGleichenHaushalt.Name = "repImGleichenHaushalt";
            this.repImGleichenHaushalt.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.repImGleichenHaushalt_EditValueChanging);
            // 
            // colAlter
            // 
            this.colAlter.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colAlter.AppearanceCell.Options.UseBackColor = true;
            this.colAlter.Caption = "Alter";
            this.colAlter.FieldName = "Age";
            this.colAlter.Name = "colAlter";
            this.colAlter.OptionsColumn.AllowEdit = false;
            this.colAlter.OptionsColumn.AllowFocus = false;
            this.colAlter.Visible = true;
            this.colAlter.VisibleIndex = 3;
            this.colAlter.Width = 60;
            // 
            // colKlient
            // 
            this.colKlient.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKlient.AppearanceCell.Options.UseBackColor = true;
            this.colKlient.Caption = "Klient/in";
            this.colKlient.FieldName = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.OptionsColumn.AllowEdit = false;
            this.colKlient.OptionsColumn.AllowFocus = false;
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 4;
            this.colKlient.Width = 60;
            // 
            // colGeschlechtCode
            // 
            this.colGeschlechtCode.Caption = "GeschlechtCode";
            this.colGeschlechtCode.FieldName = "GeschlechtCode";
            this.colGeschlechtCode.Name = "colGeschlechtCode";
            // 
            // colPersonenTelNr
            // 
            this.colPersonenTelNr.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colPersonenTelNr.AppearanceCell.Options.UseBackColor = true;
            this.colPersonenTelNr.Caption = "Tel. Nr.";
            this.colPersonenTelNr.FieldName = "TelNr";
            this.colPersonenTelNr.Name = "colPersonenTelNr";
            this.colPersonenTelNr.OptionsColumn.AllowEdit = false;
            this.colPersonenTelNr.OptionsColumn.AllowFocus = false;
            this.colPersonenTelNr.Visible = true;
            this.colPersonenTelNr.VisibleIndex = 5;
            this.colPersonenTelNr.Width = 150;
            // 
            // colPersonenEMail
            // 
            this.colPersonenEMail.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colPersonenEMail.AppearanceCell.Options.UseBackColor = true;
            this.colPersonenEMail.Caption = "E-Mail";
            this.colPersonenEMail.FieldName = "EMail";
            this.colPersonenEMail.Name = "colPersonenEMail";
            this.colPersonenEMail.OptionsColumn.AllowEdit = false;
            this.colPersonenEMail.OptionsColumn.AllowFocus = false;
            this.colPersonenEMail.Visible = true;
            this.colPersonenEMail.VisibleIndex = 6;
            this.colPersonenEMail.Width = 150;
            // 
            // repRelationFemale
            // 
            this.repRelationFemale.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.repRelationFemale.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.repRelationFemale.AppearanceDropDown.Options.UseBackColor = true;
            this.repRelationFemale.AppearanceDropDown.Options.UseFont = true;
            this.repRelationFemale.AutoHeight = false;
            this.repRelationFemale.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repRelationFemale.Name = "repRelationFemale";
            this.repRelationFemale.NullText = "";
            this.repRelationFemale.ShowFooter = false;
            this.repRelationFemale.ShowHeader = false;
            // 
            // repRelationMale
            // 
            this.repRelationMale.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.repRelationMale.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.repRelationMale.AppearanceDropDown.Options.UseBackColor = true;
            this.repRelationMale.AppearanceDropDown.Options.UseFont = true;
            this.repRelationMale.AutoHeight = false;
            this.repRelationMale.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repRelationMale.Name = "repRelationMale";
            this.repRelationMale.NullText = "";
            this.repRelationMale.ShowFooter = false;
            this.repRelationMale.ShowHeader = false;
            // 
            // repRelationGeneric
            // 
            this.repRelationGeneric.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.repRelationGeneric.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.repRelationGeneric.AppearanceDropDown.Options.UseBackColor = true;
            this.repRelationGeneric.AppearanceDropDown.Options.UseFont = true;
            this.repRelationGeneric.AutoHeight = false;
            this.repRelationGeneric.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repRelationGeneric.Name = "repRelationGeneric";
            this.repRelationGeneric.NullText = "";
            this.repRelationGeneric.ShowFooter = false;
            this.repRelationGeneric.ShowHeader = false;
            // 
            // lblTitelInstitutionenFachpersonen
            // 
            this.lblTitelInstitutionenFachpersonen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitelInstitutionenFachpersonen.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitelInstitutionenFachpersonen.Location = new System.Drawing.Point(9, 254);
            this.lblTitelInstitutionenFachpersonen.Margin = new System.Windows.Forms.Padding(9, 6, 3, 0);
            this.lblTitelInstitutionenFachpersonen.Name = "lblTitelInstitutionenFachpersonen";
            this.lblTitelInstitutionenFachpersonen.Size = new System.Drawing.Size(710, 20);
            this.lblTitelInstitutionenFachpersonen.TabIndex = 27;
            this.lblTitelInstitutionenFachpersonen.Text = "Institutionen, Fachpersonen";
            this.lblTitelInstitutionenFachpersonen.UseCompatibleTextRendering = true;
            // 
            // grdInstitutionen
            // 
            this.grdInstitutionen.DataSource = this.qryFachpersonenInstitutionen;
            this.grdInstitutionen.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdInstitutionen.EmbeddedNavigator.Name = "";
            this.grdInstitutionen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdInstitutionen.Location = new System.Drawing.Point(3, 277);
            this.grdInstitutionen.MainView = this.grvInstitutionen;
            this.grdInstitutionen.Name = "grdInstitutionen";
            this.grdInstitutionen.Size = new System.Drawing.Size(716, 92);
            this.grdInstitutionen.TabIndex = 28;
            this.grdInstitutionen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvInstitutionen});
            // 
            // qryFachpersonenInstitutionen
            // 
            this.qryFachpersonenInstitutionen.HostControl = this;
            this.qryFachpersonenInstitutionen.TableName = "BaPerson_BaInstitution";
            // 
            // grvInstitutionen
            // 
            this.grvInstitutionen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvInstitutionen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionen.Appearance.Empty.Options.UseBackColor = true;
            this.grvInstitutionen.Appearance.Empty.Options.UseFont = true;
            this.grvInstitutionen.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvInstitutionen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionen.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvInstitutionen.Appearance.EvenRow.Options.UseFont = true;
            this.grvInstitutionen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvInstitutionen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvInstitutionen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvInstitutionen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvInstitutionen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvInstitutionen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvInstitutionen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvInstitutionen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvInstitutionen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvInstitutionen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvInstitutionen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvInstitutionen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvInstitutionen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvInstitutionen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvInstitutionen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvInstitutionen.Appearance.GroupRow.Options.UseFont = true;
            this.grvInstitutionen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvInstitutionen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvInstitutionen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvInstitutionen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvInstitutionen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvInstitutionen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvInstitutionen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvInstitutionen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvInstitutionen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvInstitutionen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvInstitutionen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvInstitutionen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvInstitutionen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvInstitutionen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionen.Appearance.OddRow.Options.UseFont = true;
            this.grvInstitutionen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvInstitutionen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionen.Appearance.Row.Options.UseBackColor = true;
            this.grvInstitutionen.Appearance.Row.Options.UseFont = true;
            this.grvInstitutionen.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvInstitutionen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionen.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvInstitutionen.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvInstitutionen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvInstitutionen.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvInstitutionen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvInstitutionen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvInstitutionen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvInstitutionen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInstitution,
            this.colAdresse,
            this.colKontaktPerson,
            this.colTelNr,
            this.colEmail,
            this.colBetrifftBaPerson,
            this.colBeziehungZuPerson});
            this.grvInstitutionen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvInstitutionen.GridControl = this.grdInstitutionen;
            this.grvInstitutionen.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvInstitutionen.Name = "grvInstitutionen";
            this.grvInstitutionen.OptionsBehavior.Editable = false;
            this.grvInstitutionen.OptionsCustomization.AllowFilter = false;
            this.grvInstitutionen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvInstitutionen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvInstitutionen.OptionsNavigation.UseTabKey = false;
            this.grvInstitutionen.OptionsView.ColumnAutoWidth = false;
            this.grvInstitutionen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvInstitutionen.OptionsView.ShowGroupPanel = false;
            this.grvInstitutionen.OptionsView.ShowIndicator = false;
            // 
            // colInstitution
            // 
            this.colInstitution.Caption = "Name";
            this.colInstitution.FieldName = "Name";
            this.colInstitution.Name = "colInstitution";
            this.colInstitution.Visible = true;
            this.colInstitution.VisibleIndex = 0;
            this.colInstitution.Width = 200;
            // 
            // colAdresse
            // 
            this.colAdresse.Caption = "Adresse";
            this.colAdresse.FieldName = "Adresse";
            this.colAdresse.Name = "colAdresse";
            this.colAdresse.Visible = true;
            this.colAdresse.VisibleIndex = 1;
            this.colAdresse.Width = 200;
            // 
            // colKontaktPerson
            // 
            this.colKontaktPerson.Caption = "Kontaktperson";
            this.colKontaktPerson.FieldName = "Kontaktperson";
            this.colKontaktPerson.Name = "colKontaktPerson";
            this.colKontaktPerson.Visible = true;
            this.colKontaktPerson.VisibleIndex = 2;
            this.colKontaktPerson.Width = 150;
            // 
            // colTelNr
            // 
            this.colTelNr.Caption = "Tel. Nr.";
            this.colTelNr.FieldName = "TelNr";
            this.colTelNr.Name = "colTelNr";
            this.colTelNr.Visible = true;
            this.colTelNr.VisibleIndex = 3;
            this.colTelNr.Width = 100;
            // 
            // colBetrifftBaPerson
            // 
            this.colBetrifftBaPerson.Caption = "Betrifft Person";
            this.colBetrifftBaPerson.FieldName = "BetrifftBaPerson";
            this.colBetrifftBaPerson.Name = "colBetrifftBaPerson";
            this.colBetrifftBaPerson.Visible = true;
            this.colBetrifftBaPerson.VisibleIndex = 5;
            this.colBetrifftBaPerson.Width = 150;
            // 
            // colBeziehungZuPerson
            // 
            this.colBeziehungZuPerson.Caption = "Beziehung zu Person";
            this.colBeziehungZuPerson.FieldName = "BeziehungZuPerson";
            this.colBeziehungZuPerson.Name = "colBeziehungZuPerson";
            this.colBeziehungZuPerson.Visible = true;
            this.colBeziehungZuPerson.VisibleIndex = 6;
            this.colBeziehungZuPerson.Width = 150;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "E-Mail";
            this.colEmail.FieldName = "EMail";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 4;
            this.colEmail.Width = 150;
            // 
            // btnUebersichtStammdaten
            // 
            this.btnUebersichtStammdaten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUebersichtStammdaten.Context = "BA_Klientensystem";
            this.btnUebersichtStammdaten.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.btnUebersichtStammdaten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUebersichtStammdaten.Image = ((System.Drawing.Image)(resources.GetObject("btnUebersichtStammdaten.Image")));
            this.btnUebersichtStammdaten.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUebersichtStammdaten.Location = new System.Drawing.Point(545, 378);
            this.btnUebersichtStammdaten.Margin = new System.Windows.Forms.Padding(3, 3, 7, 7);
            this.btnUebersichtStammdaten.Name = "btnUebersichtStammdaten";
            this.btnUebersichtStammdaten.Size = new System.Drawing.Size(170, 24);
            this.btnUebersichtStammdaten.TabIndex = 29;
            this.btnUebersichtStammdaten.Text = "Übersicht Stammdaten";
            this.btnUebersichtStammdaten.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUebersichtStammdaten.UseCompatibleTextRendering = true;
            this.btnUebersichtStammdaten.UseVisualStyleBackColor = false;
            // 
            // panTitel
            // 
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(722, 30);
            this.panTitel.TabIndex = 30;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 1;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(680, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Klientensystem";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitelBegleiterInnenEntlasterInnen, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTitelPersonen, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grdPersonen, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTitelInstitutionenFachpersonen, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.grdInstitutionen, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnUebersichtStammdaten, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.grdBegleiterInnenEntlasterInnen, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 187);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33223F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(722, 409);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // lblTitelBegleiterInnenEntlasterInnen
            // 
            this.lblTitelBegleiterInnenEntlasterInnen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitelBegleiterInnenEntlasterInnen.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitelBegleiterInnenEntlasterInnen.Location = new System.Drawing.Point(9, 130);
            this.lblTitelBegleiterInnenEntlasterInnen.Margin = new System.Windows.Forms.Padding(9, 6, 3, 0);
            this.lblTitelBegleiterInnenEntlasterInnen.Name = "lblTitelBegleiterInnenEntlasterInnen";
            this.lblTitelBegleiterInnenEntlasterInnen.Size = new System.Drawing.Size(710, 20);
            this.lblTitelBegleiterInnenEntlasterInnen.TabIndex = 30;
            this.lblTitelBegleiterInnenEntlasterInnen.Text = "Begleiter/innen und Entlaster/innen";
            this.lblTitelBegleiterInnenEntlasterInnen.UseCompatibleTextRendering = true;
            // 
            // grdBegleiterInnenEntlasterInnen
            // 
            this.grdBegleiterInnenEntlasterInnen.DataSource = this.qryBegleiterInnenEntlasterInnen;
            this.grdBegleiterInnenEntlasterInnen.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBegleiterInnenEntlasterInnen.EmbeddedNavigator.Name = "";
            this.grdBegleiterInnenEntlasterInnen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBegleiterInnenEntlasterInnen.Location = new System.Drawing.Point(3, 153);
            this.grdBegleiterInnenEntlasterInnen.MainView = this.grvBegleiterInnenEntlasterInnen;
            this.grdBegleiterInnenEntlasterInnen.Name = "grdBegleiterInnenEntlasterInnen";
            this.grdBegleiterInnenEntlasterInnen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemBWEDIconCbo});
            this.grdBegleiterInnenEntlasterInnen.Size = new System.Drawing.Size(716, 92);
            this.grdBegleiterInnenEntlasterInnen.TabIndex = 28;
            this.grdBegleiterInnenEntlasterInnen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBegleiterInnenEntlasterInnen});
            // 
            // qryBegleiterInnenEntlasterInnen
            // 
            this.qryBegleiterInnenEntlasterInnen.HostControl = this;
            // 
            // grvBegleiterInnenEntlasterInnen
            // 
            this.grvBegleiterInnenEntlasterInnen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBegleiterInnenEntlasterInnen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBegleiterInnenEntlasterInnen.Appearance.Empty.Options.UseBackColor = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.Empty.Options.UseFont = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvBegleiterInnenEntlasterInnen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBegleiterInnenEntlasterInnen.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.EvenRow.Options.UseFont = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBegleiterInnenEntlasterInnen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBegleiterInnenEntlasterInnen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBegleiterInnenEntlasterInnen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBegleiterInnenEntlasterInnen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBegleiterInnenEntlasterInnen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBegleiterInnenEntlasterInnen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBegleiterInnenEntlasterInnen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBegleiterInnenEntlasterInnen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBegleiterInnenEntlasterInnen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBegleiterInnenEntlasterInnen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.GroupRow.Options.UseFont = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBegleiterInnenEntlasterInnen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBegleiterInnenEntlasterInnen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBegleiterInnenEntlasterInnen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBegleiterInnenEntlasterInnen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBegleiterInnenEntlasterInnen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBegleiterInnenEntlasterInnen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBegleiterInnenEntlasterInnen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBegleiterInnenEntlasterInnen.Appearance.OddRow.Options.UseFont = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBegleiterInnenEntlasterInnen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBegleiterInnenEntlasterInnen.Appearance.Row.Options.UseBackColor = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.Row.Options.UseFont = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvBegleiterInnenEntlasterInnen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBegleiterInnenEntlasterInnen.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvBegleiterInnenEntlasterInnen.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvBegleiterInnenEntlasterInnen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBegleiterInnenEntlasterInnen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBegleiterInnenEntlasterInnen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBegleiterInnenEntlasterInnen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBWEDTyp,
            this.colBWEDName,
            this.colBWEDAdresse,
            this.colBWEDTelNr,
            this.colBWEDTelNrMobil,
            this.colBWEDEMail});
            this.grvBegleiterInnenEntlasterInnen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBegleiterInnenEntlasterInnen.GridControl = this.grdBegleiterInnenEntlasterInnen;
            this.grvBegleiterInnenEntlasterInnen.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBegleiterInnenEntlasterInnen.Name = "grvBegleiterInnenEntlasterInnen";
            this.grvBegleiterInnenEntlasterInnen.OptionsBehavior.Editable = false;
            this.grvBegleiterInnenEntlasterInnen.OptionsCustomization.AllowFilter = false;
            this.grvBegleiterInnenEntlasterInnen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBegleiterInnenEntlasterInnen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBegleiterInnenEntlasterInnen.OptionsNavigation.UseTabKey = false;
            this.grvBegleiterInnenEntlasterInnen.OptionsView.ColumnAutoWidth = false;
            this.grvBegleiterInnenEntlasterInnen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBegleiterInnenEntlasterInnen.OptionsView.ShowGroupPanel = false;
            this.grvBegleiterInnenEntlasterInnen.OptionsView.ShowIndicator = false;
            // 
            // colBWEDTyp
            // 
            this.colBWEDTyp.Caption = "Typ";
            this.colBWEDTyp.ColumnEdit = this.repItemBWEDIconCbo;
            this.colBWEDTyp.FieldName = "IconID";
            this.colBWEDTyp.Name = "colBWEDTyp";
            this.colBWEDTyp.Visible = true;
            this.colBWEDTyp.VisibleIndex = 0;
            this.colBWEDTyp.Width = 32;
            // 
            // repItemBWEDIconCbo
            // 
            this.repItemBWEDIconCbo.AutoHeight = false;
            this.repItemBWEDIconCbo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemBWEDIconCbo.Name = "repItemBWEDIconCbo";
            // 
            // colBWEDName
            // 
            this.colBWEDName.Caption = "Name";
            this.colBWEDName.FieldName = "Name";
            this.colBWEDName.Name = "colBWEDName";
            this.colBWEDName.Visible = true;
            this.colBWEDName.VisibleIndex = 1;
            this.colBWEDName.Width = 200;
            // 
            // colBWEDAdresse
            // 
            this.colBWEDAdresse.Caption = "Adresse";
            this.colBWEDAdresse.FieldName = "Adresse";
            this.colBWEDAdresse.Name = "colBWEDAdresse";
            this.colBWEDAdresse.Visible = true;
            this.colBWEDAdresse.VisibleIndex = 2;
            this.colBWEDAdresse.Width = 200;
            // 
            // colBWEDTelNr
            // 
            this.colBWEDTelNr.Caption = "Tel. Nr.";
            this.colBWEDTelNr.FieldName = "TelNr";
            this.colBWEDTelNr.Name = "colBWEDTelNr";
            this.colBWEDTelNr.Visible = true;
            this.colBWEDTelNr.VisibleIndex = 3;
            this.colBWEDTelNr.Width = 150;
            // 
            // colBWEDTelNrMobil
            // 
            this.colBWEDTelNrMobil.Caption = "Tel. Nr. mobil";
            this.colBWEDTelNrMobil.FieldName = "TelNrMobil";
            this.colBWEDTelNrMobil.Name = "colBWEDTelNrMobil";
            this.colBWEDTelNrMobil.Visible = true;
            this.colBWEDTelNrMobil.VisibleIndex = 4;
            this.colBWEDTelNrMobil.Width = 100;
            // 
            // colBWEDEMail
            // 
            this.colBWEDEMail.Caption = "E-Mail";
            this.colBWEDEMail.FieldName = "EMail";
            this.colBWEDEMail.Name = "colBWEDEMail";
            this.colBWEDEMail.Visible = true;
            this.colBWEDEMail.VisibleIndex = 5;
            this.colBWEDEMail.Width = 150;
            // 
            // panKlient
            // 
            this.panKlient.Controls.Add(this.lblKlientC);
            this.panKlient.Controls.Add(this.lblKlient);
            this.panKlient.Controls.Add(this.lblWohnsitzC);
            this.panKlient.Controls.Add(this.lblWohnsitz);
            this.panKlient.Controls.Add(this.lblZivilstand);
            this.panKlient.Controls.Add(this.lblPostadresseC);
            this.panKlient.Controls.Add(this.lblZivilstandC);
            this.panKlient.Controls.Add(this.lblPostadresse);
            this.panKlient.Controls.Add(this.lblGeschlecht);
            this.panKlient.Controls.Add(this.lblTelefonNummernC);
            this.panKlient.Controls.Add(this.lblGeschlechtC);
            this.panKlient.Controls.Add(this.lblTelP);
            this.panKlient.Controls.Add(this.lblGeburtstag);
            this.panKlient.Controls.Add(this.lblEmailC);
            this.panKlient.Controls.Add(this.lblGeburtstagC);
            this.panKlient.Controls.Add(this.lblEMail);
            this.panKlient.Controls.Add(this.lblAlter);
            this.panKlient.Controls.Add(this.lblNationalitaetC);
            this.panKlient.Controls.Add(this.lblAlterC);
            this.panKlient.Controls.Add(this.lblNationalitaet);
            this.panKlient.Dock = System.Windows.Forms.DockStyle.Top;
            this.panKlient.Location = new System.Drawing.Point(0, 30);
            this.panKlient.Name = "panKlient";
            this.panKlient.Size = new System.Drawing.Size(722, 157);
            this.panKlient.TabIndex = 32;
            // 
            // CtlBaKlientensystem
            // 
            this.ActiveSQLQuery = this.qryPersonRelation;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panKlient);
            this.Controls.Add(this.panTitel);
            this.Name = "CtlBaKlientensystem";
            this.Size = new System.Drawing.Size(722, 596);
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFalltraeger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitzC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostadresseC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostadresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefonNummernC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmailC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNationalitaetC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAlterC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAlter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtstagC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtstag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlechtC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZivilstandC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZivilstand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelPersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPersonRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repImGleichenHaushalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repRelationFemale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repRelationMale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repRelationGeneric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelInstitutionenFachpersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstitutionen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFachpersonenInstitutionen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInstitutionen)).EndInit();
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelBegleiterInnenEntlasterInnen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBegleiterInnenEntlasterInnen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBegleiterInnenEntlasterInnen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBegleiterInnenEntlasterInnen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemBWEDIconCbo)).EndInit();
            this.panKlient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Dokument.KissDocumentButton btnUebersichtStammdaten;
        private DevExpress.XtraGrid.Columns.GridColumn colAdresse;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colBWEDAdresse;
        private DevExpress.XtraGrid.Columns.GridColumn colBWEDEMail;
        private DevExpress.XtraGrid.Columns.GridColumn colBWEDName;
        private DevExpress.XtraGrid.Columns.GridColumn colBWEDTelNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBWEDTelNrMobil;
        private DevExpress.XtraGrid.Columns.GridColumn colBWEDTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrifftBaPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colBeziehung;
        private DevExpress.XtraGrid.Columns.GridColumn colBeziehungZuPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlechtCode;
        private DevExpress.XtraGrid.Columns.GridColumn colImGleicherHaushalt;
        private DevExpress.XtraGrid.Columns.GridColumn colInstitution;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colKontaktPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonenEMail;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonenTelNr;
        private DevExpress.XtraGrid.Columns.GridColumn colTelNr;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissGrid grdBegleiterInnenEntlasterInnen;
        private KiSS4.Gui.KissGrid grdInstitutionen;
        private KiSS4.Gui.KissGrid grdPersonen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBegleiterInnenEntlasterInnen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvInstitutionen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPersonen;
        private KiSS4.Gui.KissLabel lblAlter;
        private KiSS4.Gui.KissLabel lblAlterC;
        private KiSS4.Gui.KissLabel lblEMail;
        private KiSS4.Gui.KissLabel lblEmailC;
        private KiSS4.Gui.KissLabel lblGeburtstag;
        private KiSS4.Gui.KissLabel lblGeburtstagC;
        private KiSS4.Gui.KissLabel lblGeschlecht;
        private KiSS4.Gui.KissLabel lblGeschlechtC;
        private KiSS4.Gui.KissLabel lblKlient;
        private KiSS4.Gui.KissLabel lblKlientC;
        private KiSS4.Gui.KissLabel lblNationalitaet;
        private KiSS4.Gui.KissLabel lblNationalitaetC;
        private KiSS4.Gui.KissLabel lblPostadresse;
        private KiSS4.Gui.KissLabel lblPostadresseC;
        private KiSS4.Gui.KissLabel lblTelP;
        private KiSS4.Gui.KissLabel lblTelefonNummernC;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblTitelBegleiterInnenEntlasterInnen;
        private KiSS4.Gui.KissLabel lblTitelInstitutionenFachpersonen;
        private KiSS4.Gui.KissLabel lblTitelPersonen;
        private KiSS4.Gui.KissLabel lblWohnsitz;
        private KiSS4.Gui.KissLabel lblWohnsitzC;
        private KiSS4.Gui.KissLabel lblZivilstand;
        private KiSS4.Gui.KissLabel lblZivilstandC;
        private System.Windows.Forms.Panel panKlient;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBegleiterInnenEntlasterInnen;
        private KiSS4.DB.SqlQuery qryFachpersonenInstitutionen;
        private KiSS4.DB.SqlQuery qryFalltraeger;
        private KiSS4.DB.SqlQuery qryPersonRelation;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repImGleichenHaushalt;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repItemBWEDIconCbo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repRelationFemale;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repRelationGeneric;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repRelationMale;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
    }
}
