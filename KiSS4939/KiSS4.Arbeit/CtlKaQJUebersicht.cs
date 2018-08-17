using System.Drawing;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaQJUebersicht.
    /// </summary>
    public class CtlKaQJUebersicht : KissUserControl
    {
        protected internal KiSS4.Dokument.KissDocumentButton docBericht;
        private int BaPersonID = 0;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit datEintritt;
        private KiSS4.Gui.KissTextEdit edtAdresse;
        private KiSS4.Gui.KissTextEdit edtAdresseZuweiser;
        private KiSS4.Gui.KissTextEdit edtAusweis;
        private KiSS4.Gui.KissTextEdit edtCoach;
        private KiSS4.Gui.KissTextEdit edtEmail;
        private KiSS4.Gui.KissTextEdit edtEmailZuweiser;
        private KiSS4.Gui.KissTextEdit edtInstitution;
        private KiSS4.Gui.KissTextEdit edtMobil;
        private KiSS4.Gui.KissTextEdit edtNameZuweiser;
        private KiSS4.Gui.KissTextEdit edtNationalitaet;
        private KiSS4.Gui.KissTextEdit edtNiveau;
        private KiSS4.Gui.KissTextEdit edtPlzOrt;
        private KiSS4.Gui.KissTextEdit edtPlzOrtZuweiser;
        private KiSS4.Gui.KissTextEdit edtTelefon;
        private KiSS4.Gui.KissTextEdit edtTelefonZuweiser;
        private KiSS4.Gui.KissTextEdit edtVorbildung;
        private int FaLeistungID = 0;
        private KiSS4.Gui.KissLabel lblAdresse;
        private KiSS4.Gui.KissLabel lblAdresseZuweiser;
        private System.Windows.Forms.Label lblAngabenZum;
        private KiSS4.Gui.KissLabel lblAusweis;
        private KiSS4.Gui.KissLabel lblCoach;
        private KiSS4.Gui.KissLabel lblEintritt;
        private KiSS4.Gui.KissLabel lblEmail;
        private KiSS4.Gui.KissLabel lblEmailZuweiser;
        private System.Windows.Forms.Label lblFallfuehrung;
        private KiSS4.Gui.KissLabel lblInstitution;
        private System.Windows.Forms.Label lblKlientendaten;
        private KiSS4.Gui.KissLabel lblMobil;
        private KiSS4.Gui.KissLabel lblNameZuweiser;
        private KiSS4.Gui.KissLabel lblNationalitaet;
        private KiSS4.Gui.KissLabel lblNiveau;
        private KiSS4.Gui.KissLabel lblPlzOrt;
        private KiSS4.Gui.KissLabel lblPlzOrtZuweiser;
        private KiSS4.Gui.KissLabel lblTelefon;
        private KiSS4.Gui.KissLabel lblTelefonZuweiser;
        private System.Windows.Forms.Label lblTitel;
        private KiSS4.Gui.KissLabel lblVorbildung;
        private System.Windows.Forms.PictureBox picTitle;
        private KiSS4.DB.SqlQuery qryBaPerson;
        private KiSS4.DB.SqlQuery qryFallfuehrung;
        private KiSS4.DB.SqlQuery qryZuteilung;

        public CtlKaQJUebersicht()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "BAPERSONID":
                    return this.BaPersonID;

                case "FALEISTUNGID":
                    return this.FaLeistungID;

                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL("select UserID from FaLeistung where FaLeistungID = {0}", FaLeistungID);
            }

            return base.GetContextValue(FieldName);
        }

        public void Init(string TitleName, Image TitleImage, int FaLeistungID, int BaPersonID)
        {
            this.lblTitel.Text = TitleName;
            this.picTitle.Image = TitleImage;
            this.FaLeistungID = FaLeistungID;
            this.BaPersonID = BaPersonID;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaQJUebersicht));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new System.Windows.Forms.Label();
            this.edtAdresse = new KiSS4.Gui.KissTextEdit();
            this.qryBaPerson = new KiSS4.DB.SqlQuery(this.components);
            this.lblAdresse = new KiSS4.Gui.KissLabel();
            this.edtPlzOrt = new KiSS4.Gui.KissTextEdit();
            this.lblPlzOrt = new KiSS4.Gui.KissLabel();
            this.edtTelefon = new KiSS4.Gui.KissTextEdit();
            this.lblTelefon = new KiSS4.Gui.KissLabel();
            this.edtMobil = new KiSS4.Gui.KissTextEdit();
            this.lblMobil = new KiSS4.Gui.KissLabel();
            this.edtEmail = new KiSS4.Gui.KissTextEdit();
            this.lblEmail = new KiSS4.Gui.KissLabel();
            this.edtNationalitaet = new KiSS4.Gui.KissTextEdit();
            this.lblNationalitaet = new KiSS4.Gui.KissLabel();
            this.edtAusweis = new KiSS4.Gui.KissTextEdit();
            this.lblAusweis = new KiSS4.Gui.KissLabel();
            this.edtVorbildung = new KiSS4.Gui.KissTextEdit();
            this.lblVorbildung = new KiSS4.Gui.KissLabel();
            this.lblKlientendaten = new System.Windows.Forms.Label();
            this.lblFallfuehrung = new System.Windows.Forms.Label();
            this.edtEmailZuweiser = new KiSS4.Gui.KissTextEdit();
            this.qryFallfuehrung = new KiSS4.DB.SqlQuery(this.components);
            this.lblEmailZuweiser = new KiSS4.Gui.KissLabel();
            this.edtTelefonZuweiser = new KiSS4.Gui.KissTextEdit();
            this.lblTelefonZuweiser = new KiSS4.Gui.KissLabel();
            this.edtPlzOrtZuweiser = new KiSS4.Gui.KissTextEdit();
            this.lblPlzOrtZuweiser = new KiSS4.Gui.KissLabel();
            this.edtAdresseZuweiser = new KiSS4.Gui.KissTextEdit();
            this.lblAdresseZuweiser = new KiSS4.Gui.KissLabel();
            this.edtNameZuweiser = new KiSS4.Gui.KissTextEdit();
            this.lblNameZuweiser = new KiSS4.Gui.KissLabel();
            this.edtInstitution = new KiSS4.Gui.KissTextEdit();
            this.lblInstitution = new KiSS4.Gui.KissLabel();
            this.lblAngabenZum = new System.Windows.Forms.Label();
            this.edtCoach = new KiSS4.Gui.KissTextEdit();
            this.lblCoach = new KiSS4.Gui.KissLabel();
            this.lblEintritt = new KiSS4.Gui.KissLabel();
            this.edtNiveau = new KiSS4.Gui.KissTextEdit();
            this.qryZuteilung = new KiSS4.DB.SqlQuery(this.components);
            this.lblNiveau = new KiSS4.Gui.KissLabel();
            this.datEintritt = new KiSS4.Gui.KissDateEdit();
            this.docBericht = new KiSS4.Dokument.KissDocumentButton();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlzOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMobil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMobil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusweis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorbildung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmailZuweiser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFallfuehrung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmailZuweiser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonZuweiser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefonZuweiser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlzOrtZuweiser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzOrtZuweiser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseZuweiser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseZuweiser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameZuweiser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameZuweiser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCoach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCoach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEintritt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNiveau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZuteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNiveau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEintritt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picTitle
            // 
            this.picTitle.Image = ((System.Drawing.Image)(resources.GetObject("picTitle.Image")));
            this.picTitle.Location = new System.Drawing.Point(10, 9);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(25, 20);
            this.picTitle.TabIndex = 21;
            this.picTitle.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 22;
            this.lblTitel.Text = "Titel";
            // 
            // edtAdresse
            // 
            this.edtAdresse.DataMember = "Adresse";
            this.edtAdresse.DataSource = this.qryBaPerson;
            this.edtAdresse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresse.Location = new System.Drawing.Point(80, 60);
            this.edtAdresse.Name = "edtAdresse";
            this.edtAdresse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresse.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresse.Properties.Appearance.Options.UseFont = true;
            this.edtAdresse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresse.Properties.ReadOnly = true;
            this.edtAdresse.Size = new System.Drawing.Size(250, 24);
            this.edtAdresse.TabIndex = 110;
            // 
            // qryBaPerson
            // 
            this.qryBaPerson.HostControl = this;
            this.qryBaPerson.IsIdentityInsert = false;
            this.qryBaPerson.TableName = "BaPerson";
            // 
            // lblAdresse
            // 
            this.lblAdresse.Location = new System.Drawing.Point(5, 60);
            this.lblAdresse.Name = "lblAdresse";
            this.lblAdresse.Size = new System.Drawing.Size(60, 24);
            this.lblAdresse.TabIndex = 111;
            this.lblAdresse.Text = "Adresse";
            // 
            // edtPlzOrt
            // 
            this.edtPlzOrt.DataMember = "PlzOrt";
            this.edtPlzOrt.DataSource = this.qryBaPerson;
            this.edtPlzOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPlzOrt.Location = new System.Drawing.Point(80, 90);
            this.edtPlzOrt.Name = "edtPlzOrt";
            this.edtPlzOrt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPlzOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPlzOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPlzOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtPlzOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPlzOrt.Properties.Appearance.Options.UseFont = true;
            this.edtPlzOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPlzOrt.Properties.ReadOnly = true;
            this.edtPlzOrt.Size = new System.Drawing.Size(250, 24);
            this.edtPlzOrt.TabIndex = 112;
            // 
            // lblPlzOrt
            // 
            this.lblPlzOrt.Location = new System.Drawing.Point(5, 90);
            this.lblPlzOrt.Name = "lblPlzOrt";
            this.lblPlzOrt.Size = new System.Drawing.Size(65, 24);
            this.lblPlzOrt.TabIndex = 113;
            this.lblPlzOrt.Text = "PLZ / Ort";
            // 
            // edtTelefon
            // 
            this.edtTelefon.DataMember = "Telefon_P";
            this.edtTelefon.DataSource = this.qryBaPerson;
            this.edtTelefon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTelefon.Location = new System.Drawing.Point(80, 120);
            this.edtTelefon.Name = "edtTelefon";
            this.edtTelefon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon.Properties.ReadOnly = true;
            this.edtTelefon.Size = new System.Drawing.Size(150, 24);
            this.edtTelefon.TabIndex = 114;
            // 
            // lblTelefon
            // 
            this.lblTelefon.Location = new System.Drawing.Point(5, 120);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(55, 24);
            this.lblTelefon.TabIndex = 115;
            this.lblTelefon.Text = "Telefon";
            // 
            // edtMobil
            // 
            this.edtMobil.DataMember = "MobilTel";
            this.edtMobil.DataSource = this.qryBaPerson;
            this.edtMobil.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMobil.Location = new System.Drawing.Point(80, 150);
            this.edtMobil.Name = "edtMobil";
            this.edtMobil.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMobil.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMobil.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMobil.Properties.Appearance.Options.UseBackColor = true;
            this.edtMobil.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMobil.Properties.Appearance.Options.UseFont = true;
            this.edtMobil.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMobil.Properties.ReadOnly = true;
            this.edtMobil.Size = new System.Drawing.Size(150, 24);
            this.edtMobil.TabIndex = 116;
            // 
            // lblMobil
            // 
            this.lblMobil.Location = new System.Drawing.Point(5, 150);
            this.lblMobil.Name = "lblMobil";
            this.lblMobil.Size = new System.Drawing.Size(55, 24);
            this.lblMobil.TabIndex = 117;
            this.lblMobil.Text = "Mobil";
            // 
            // edtEmail
            // 
            this.edtEmail.DataMember = "EMail";
            this.edtEmail.DataSource = this.qryBaPerson;
            this.edtEmail.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEmail.Location = new System.Drawing.Point(80, 180);
            this.edtEmail.Name = "edtEmail";
            this.edtEmail.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEmail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEmail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEmail.Properties.Appearance.Options.UseBackColor = true;
            this.edtEmail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEmail.Properties.Appearance.Options.UseFont = true;
            this.edtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEmail.Properties.ReadOnly = true;
            this.edtEmail.Size = new System.Drawing.Size(250, 24);
            this.edtEmail.TabIndex = 118;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(5, 180);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(60, 24);
            this.lblEmail.TabIndex = 119;
            this.lblEmail.Text = "Email";
            // 
            // edtNationalitaet
            // 
            this.edtNationalitaet.DataMember = "Nationalitaet";
            this.edtNationalitaet.DataSource = this.qryBaPerson;
            this.edtNationalitaet.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNationalitaet.Location = new System.Drawing.Point(460, 60);
            this.edtNationalitaet.Name = "edtNationalitaet";
            this.edtNationalitaet.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNationalitaet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNationalitaet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaet.Properties.Appearance.Options.UseBackColor = true;
            this.edtNationalitaet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNationalitaet.Properties.Appearance.Options.UseFont = true;
            this.edtNationalitaet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNationalitaet.Properties.ReadOnly = true;
            this.edtNationalitaet.Size = new System.Drawing.Size(250, 24);
            this.edtNationalitaet.TabIndex = 120;
            // 
            // lblNationalitaet
            // 
            this.lblNationalitaet.Location = new System.Drawing.Point(370, 60);
            this.lblNationalitaet.Name = "lblNationalitaet";
            this.lblNationalitaet.Size = new System.Drawing.Size(88, 24);
            this.lblNationalitaet.TabIndex = 121;
            this.lblNationalitaet.Text = "Nationalität";
            // 
            // edtAusweis
            // 
            this.edtAusweis.DataMember = "Ausweis";
            this.edtAusweis.DataSource = this.qryBaPerson;
            this.edtAusweis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAusweis.Location = new System.Drawing.Point(460, 90);
            this.edtAusweis.Name = "edtAusweis";
            this.edtAusweis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAusweis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAusweis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusweis.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusweis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAusweis.Properties.Appearance.Options.UseFont = true;
            this.edtAusweis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAusweis.Properties.ReadOnly = true;
            this.edtAusweis.Size = new System.Drawing.Size(250, 24);
            this.edtAusweis.TabIndex = 122;
            // 
            // lblAusweis
            // 
            this.lblAusweis.Location = new System.Drawing.Point(370, 90);
            this.lblAusweis.Name = "lblAusweis";
            this.lblAusweis.Size = new System.Drawing.Size(88, 24);
            this.lblAusweis.TabIndex = 123;
            this.lblAusweis.Text = "Ausweis";
            // 
            // edtVorbildung
            // 
            this.edtVorbildung.DataMember = "Vorbildung";
            this.edtVorbildung.DataSource = this.qryBaPerson;
            this.edtVorbildung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVorbildung.Location = new System.Drawing.Point(460, 120);
            this.edtVorbildung.Name = "edtVorbildung";
            this.edtVorbildung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVorbildung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorbildung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorbildung.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorbildung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorbildung.Properties.Appearance.Options.UseFont = true;
            this.edtVorbildung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorbildung.Properties.ReadOnly = true;
            this.edtVorbildung.Size = new System.Drawing.Size(250, 24);
            this.edtVorbildung.TabIndex = 124;
            // 
            // lblVorbildung
            // 
            this.lblVorbildung.Location = new System.Drawing.Point(370, 120);
            this.lblVorbildung.Name = "lblVorbildung";
            this.lblVorbildung.Size = new System.Drawing.Size(88, 24);
            this.lblVorbildung.TabIndex = 125;
            this.lblVorbildung.Text = "Vorbildung";
            // 
            // lblKlientendaten
            // 
            this.lblKlientendaten.AutoSize = true;
            this.lblKlientendaten.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblKlientendaten.ForeColor = System.Drawing.Color.Black;
            this.lblKlientendaten.Location = new System.Drawing.Point(5, 40);
            this.lblKlientendaten.Name = "lblKlientendaten";
            this.lblKlientendaten.Size = new System.Drawing.Size(73, 15);
            this.lblKlientendaten.TabIndex = 126;
            this.lblKlientendaten.Text = "Daten STES";
            // 
            // lblFallfuehrung
            // 
            this.lblFallfuehrung.AutoSize = true;
            this.lblFallfuehrung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblFallfuehrung.ForeColor = System.Drawing.Color.Black;
            this.lblFallfuehrung.Location = new System.Drawing.Point(5, 230);
            this.lblFallfuehrung.Name = "lblFallfuehrung";
            this.lblFallfuehrung.Size = new System.Drawing.Size(70, 15);
            this.lblFallfuehrung.TabIndex = 139;
            this.lblFallfuehrung.Text = "Fallführung";
            // 
            // edtEmailZuweiser
            // 
            this.edtEmailZuweiser.DataMember = "Email";
            this.edtEmailZuweiser.DataSource = this.qryFallfuehrung;
            this.edtEmailZuweiser.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEmailZuweiser.Location = new System.Drawing.Point(80, 400);
            this.edtEmailZuweiser.Name = "edtEmailZuweiser";
            this.edtEmailZuweiser.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEmailZuweiser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEmailZuweiser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEmailZuweiser.Properties.Appearance.Options.UseBackColor = true;
            this.edtEmailZuweiser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEmailZuweiser.Properties.Appearance.Options.UseFont = true;
            this.edtEmailZuweiser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEmailZuweiser.Properties.ReadOnly = true;
            this.edtEmailZuweiser.Size = new System.Drawing.Size(250, 24);
            this.edtEmailZuweiser.TabIndex = 137;
            // 
            // qryFallfuehrung
            // 
            this.qryFallfuehrung.HostControl = this;
            this.qryFallfuehrung.IsIdentityInsert = false;
            this.qryFallfuehrung.TableName = "BaInstitutionKontakt";
            // 
            // lblEmailZuweiser
            // 
            this.lblEmailZuweiser.Location = new System.Drawing.Point(5, 400);
            this.lblEmailZuweiser.Name = "lblEmailZuweiser";
            this.lblEmailZuweiser.Size = new System.Drawing.Size(75, 24);
            this.lblEmailZuweiser.TabIndex = 138;
            this.lblEmailZuweiser.Text = "Email";
            // 
            // edtTelefonZuweiser
            // 
            this.edtTelefonZuweiser.DataMember = "Tel";
            this.edtTelefonZuweiser.DataSource = this.qryFallfuehrung;
            this.edtTelefonZuweiser.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTelefonZuweiser.Location = new System.Drawing.Point(80, 370);
            this.edtTelefonZuweiser.Name = "edtTelefonZuweiser";
            this.edtTelefonZuweiser.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTelefonZuweiser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefonZuweiser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefonZuweiser.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefonZuweiser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefonZuweiser.Properties.Appearance.Options.UseFont = true;
            this.edtTelefonZuweiser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefonZuweiser.Properties.ReadOnly = true;
            this.edtTelefonZuweiser.Size = new System.Drawing.Size(150, 24);
            this.edtTelefonZuweiser.TabIndex = 135;
            // 
            // lblTelefonZuweiser
            // 
            this.lblTelefonZuweiser.Location = new System.Drawing.Point(5, 370);
            this.lblTelefonZuweiser.Name = "lblTelefonZuweiser";
            this.lblTelefonZuweiser.Size = new System.Drawing.Size(65, 24);
            this.lblTelefonZuweiser.TabIndex = 136;
            this.lblTelefonZuweiser.Text = "Telefon";
            // 
            // edtPlzOrtZuweiser
            // 
            this.edtPlzOrtZuweiser.DataMember = "PlzOrt";
            this.edtPlzOrtZuweiser.DataSource = this.qryFallfuehrung;
            this.edtPlzOrtZuweiser.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPlzOrtZuweiser.Location = new System.Drawing.Point(80, 340);
            this.edtPlzOrtZuweiser.Name = "edtPlzOrtZuweiser";
            this.edtPlzOrtZuweiser.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPlzOrtZuweiser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPlzOrtZuweiser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPlzOrtZuweiser.Properties.Appearance.Options.UseBackColor = true;
            this.edtPlzOrtZuweiser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPlzOrtZuweiser.Properties.Appearance.Options.UseFont = true;
            this.edtPlzOrtZuweiser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPlzOrtZuweiser.Properties.ReadOnly = true;
            this.edtPlzOrtZuweiser.Size = new System.Drawing.Size(250, 24);
            this.edtPlzOrtZuweiser.TabIndex = 133;
            // 
            // lblPlzOrtZuweiser
            // 
            this.lblPlzOrtZuweiser.Location = new System.Drawing.Point(5, 340);
            this.lblPlzOrtZuweiser.Name = "lblPlzOrtZuweiser";
            this.lblPlzOrtZuweiser.Size = new System.Drawing.Size(60, 24);
            this.lblPlzOrtZuweiser.TabIndex = 134;
            this.lblPlzOrtZuweiser.Text = "PLZ / Ort";
            // 
            // edtAdresseZuweiser
            // 
            this.edtAdresseZuweiser.DataMember = "Adresse";
            this.edtAdresseZuweiser.DataSource = this.qryFallfuehrung;
            this.edtAdresseZuweiser.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresseZuweiser.Location = new System.Drawing.Point(80, 310);
            this.edtAdresseZuweiser.Name = "edtAdresseZuweiser";
            this.edtAdresseZuweiser.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresseZuweiser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseZuweiser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseZuweiser.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseZuweiser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseZuweiser.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseZuweiser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseZuweiser.Properties.ReadOnly = true;
            this.edtAdresseZuweiser.Size = new System.Drawing.Size(250, 24);
            this.edtAdresseZuweiser.TabIndex = 131;
            // 
            // lblAdresseZuweiser
            // 
            this.lblAdresseZuweiser.Location = new System.Drawing.Point(5, 310);
            this.lblAdresseZuweiser.Name = "lblAdresseZuweiser";
            this.lblAdresseZuweiser.Size = new System.Drawing.Size(60, 24);
            this.lblAdresseZuweiser.TabIndex = 132;
            this.lblAdresseZuweiser.Text = "Adresse";
            // 
            // edtNameZuweiser
            // 
            this.edtNameZuweiser.DataMember = "Name";
            this.edtNameZuweiser.DataSource = this.qryFallfuehrung;
            this.edtNameZuweiser.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNameZuweiser.Location = new System.Drawing.Point(80, 280);
            this.edtNameZuweiser.Name = "edtNameZuweiser";
            this.edtNameZuweiser.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNameZuweiser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameZuweiser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameZuweiser.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameZuweiser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameZuweiser.Properties.Appearance.Options.UseFont = true;
            this.edtNameZuweiser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameZuweiser.Properties.ReadOnly = true;
            this.edtNameZuweiser.Size = new System.Drawing.Size(250, 24);
            this.edtNameZuweiser.TabIndex = 129;
            // 
            // lblNameZuweiser
            // 
            this.lblNameZuweiser.Location = new System.Drawing.Point(5, 280);
            this.lblNameZuweiser.Name = "lblNameZuweiser";
            this.lblNameZuweiser.Size = new System.Drawing.Size(65, 24);
            this.lblNameZuweiser.TabIndex = 130;
            this.lblNameZuweiser.Text = "Name";
            // 
            // edtInstitution
            // 
            this.edtInstitution.DataMember = "Institution";
            this.edtInstitution.DataSource = this.qryFallfuehrung;
            this.edtInstitution.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtInstitution.Location = new System.Drawing.Point(80, 250);
            this.edtInstitution.Name = "edtInstitution";
            this.edtInstitution.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInstitution.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInstitution.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInstitution.Properties.Appearance.Options.UseBackColor = true;
            this.edtInstitution.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInstitution.Properties.Appearance.Options.UseFont = true;
            this.edtInstitution.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtInstitution.Properties.ReadOnly = true;
            this.edtInstitution.Size = new System.Drawing.Size(250, 24);
            this.edtInstitution.TabIndex = 127;
            // 
            // lblInstitution
            // 
            this.lblInstitution.Location = new System.Drawing.Point(5, 250);
            this.lblInstitution.Name = "lblInstitution";
            this.lblInstitution.Size = new System.Drawing.Size(65, 24);
            this.lblInstitution.TabIndex = 128;
            this.lblInstitution.Text = "Institution";
            // 
            // lblAngabenZum
            // 
            this.lblAngabenZum.AutoSize = true;
            this.lblAngabenZum.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblAngabenZum.ForeColor = System.Drawing.Color.Black;
            this.lblAngabenZum.Location = new System.Drawing.Point(370, 230);
            this.lblAngabenZum.Name = "lblAngabenZum";
            this.lblAngabenZum.Size = new System.Drawing.Size(123, 15);
            this.lblAngabenZum.TabIndex = 148;
            this.lblAngabenZum.Text = "Angaben zum [to do]";
            // 
            // edtCoach
            // 
            this.edtCoach.DataMember = "Coach";
            this.edtCoach.DataSource = this.qryFallfuehrung;
            this.edtCoach.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtCoach.Location = new System.Drawing.Point(460, 310);
            this.edtCoach.Name = "edtCoach";
            this.edtCoach.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtCoach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtCoach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtCoach.Properties.Appearance.Options.UseBackColor = true;
            this.edtCoach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtCoach.Properties.Appearance.Options.UseFont = true;
            this.edtCoach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtCoach.Properties.ReadOnly = true;
            this.edtCoach.Size = new System.Drawing.Size(250, 24);
            this.edtCoach.TabIndex = 146;
            // 
            // lblCoach
            // 
            this.lblCoach.Location = new System.Drawing.Point(370, 310);
            this.lblCoach.Name = "lblCoach";
            this.lblCoach.Size = new System.Drawing.Size(60, 24);
            this.lblCoach.TabIndex = 147;
            this.lblCoach.Text = "Coach";
            // 
            // lblEintritt
            // 
            this.lblEintritt.Location = new System.Drawing.Point(370, 280);
            this.lblEintritt.Name = "lblEintritt";
            this.lblEintritt.Size = new System.Drawing.Size(60, 24);
            this.lblEintritt.TabIndex = 145;
            this.lblEintritt.Text = "Eintritt";
            // 
            // edtNiveau
            // 
            this.edtNiveau.DataMember = "Niveau";
            this.edtNiveau.DataSource = this.qryZuteilung;
            this.edtNiveau.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNiveau.Location = new System.Drawing.Point(460, 250);
            this.edtNiveau.Name = "edtNiveau";
            this.edtNiveau.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNiveau.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNiveau.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNiveau.Properties.Appearance.Options.UseBackColor = true;
            this.edtNiveau.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNiveau.Properties.Appearance.Options.UseFont = true;
            this.edtNiveau.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNiveau.Properties.ReadOnly = true;
            this.edtNiveau.Size = new System.Drawing.Size(250, 24);
            this.edtNiveau.TabIndex = 142;
            // 
            // qryZuteilung
            // 
            this.qryZuteilung.HostControl = this;
            this.qryZuteilung.IsIdentityInsert = false;
            this.qryZuteilung.TableName = "KaZuteilFachbereich";
            // 
            // lblNiveau
            // 
            this.lblNiveau.Location = new System.Drawing.Point(370, 250);
            this.lblNiveau.Name = "lblNiveau";
            this.lblNiveau.Size = new System.Drawing.Size(65, 24);
            this.lblNiveau.TabIndex = 143;
            this.lblNiveau.Text = "Niveau";
            // 
            // datEintritt
            // 
            this.datEintritt.DataMember = "Eintritt";
            this.datEintritt.DataSource = this.qryZuteilung;
            this.datEintritt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.datEintritt.EditValue = null;
            this.datEintritt.Location = new System.Drawing.Point(460, 280);
            this.datEintritt.Name = "datEintritt";
            this.datEintritt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datEintritt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.datEintritt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datEintritt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datEintritt.Properties.Appearance.Options.UseBackColor = true;
            this.datEintritt.Properties.Appearance.Options.UseBorderColor = true;
            this.datEintritt.Properties.Appearance.Options.UseFont = true;
            this.datEintritt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.datEintritt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, false, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datEintritt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.datEintritt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datEintritt.Properties.ReadOnly = true;
            this.datEintritt.Properties.ShowToday = false;
            this.datEintritt.Size = new System.Drawing.Size(89, 24);
            this.datEintritt.TabIndex = 577;
            // 
            // docBericht
            // 
            this.docBericht.Context = "KaQJUebersicht";
            this.docBericht.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.docBericht.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docBericht.Image = ((System.Drawing.Image)(resources.GetObject("docBericht.Image")));
            this.docBericht.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.docBericht.Location = new System.Drawing.Point(5, 445);
            this.docBericht.Name = "docBericht";
            this.docBericht.Size = new System.Drawing.Size(110, 24);
            this.docBericht.TabIndex = 578;
            this.docBericht.Text = "Dokument";
            this.docBericht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.docBericht.UseVisualStyleBackColor = false;
            // 
            // CtlKaQJUebersicht
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.docBericht);
            this.Controls.Add(this.datEintritt);
            this.Controls.Add(this.lblAngabenZum);
            this.Controls.Add(this.edtCoach);
            this.Controls.Add(this.lblCoach);
            this.Controls.Add(this.lblEintritt);
            this.Controls.Add(this.edtNiveau);
            this.Controls.Add(this.lblNiveau);
            this.Controls.Add(this.lblFallfuehrung);
            this.Controls.Add(this.edtEmailZuweiser);
            this.Controls.Add(this.lblEmailZuweiser);
            this.Controls.Add(this.edtTelefonZuweiser);
            this.Controls.Add(this.lblTelefonZuweiser);
            this.Controls.Add(this.edtPlzOrtZuweiser);
            this.Controls.Add(this.lblPlzOrtZuweiser);
            this.Controls.Add(this.edtAdresseZuweiser);
            this.Controls.Add(this.lblAdresseZuweiser);
            this.Controls.Add(this.edtNameZuweiser);
            this.Controls.Add(this.lblNameZuweiser);
            this.Controls.Add(this.edtInstitution);
            this.Controls.Add(this.lblInstitution);
            this.Controls.Add(this.lblKlientendaten);
            this.Controls.Add(this.edtVorbildung);
            this.Controls.Add(this.lblVorbildung);
            this.Controls.Add(this.edtAusweis);
            this.Controls.Add(this.lblAusweis);
            this.Controls.Add(this.edtNationalitaet);
            this.Controls.Add(this.lblNationalitaet);
            this.Controls.Add(this.edtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.edtMobil);
            this.Controls.Add(this.lblMobil);
            this.Controls.Add(this.edtTelefon);
            this.Controls.Add(this.lblTelefon);
            this.Controls.Add(this.edtPlzOrt);
            this.Controls.Add(this.lblPlzOrt);
            this.Controls.Add(this.edtAdresse);
            this.Controls.Add(this.lblAdresse);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlKaQJUebersicht";
            this.Size = new System.Drawing.Size(855, 608);
            this.Load += new System.EventHandler(this.CtlKaQJUebersicht_Load);
            this.Enter += new System.EventHandler(this.CtlKaQJUebersicht_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlzOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMobil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMobil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusweis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorbildung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmailZuweiser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFallfuehrung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmailZuweiser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonZuweiser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefonZuweiser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlzOrtZuweiser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlzOrtZuweiser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseZuweiser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseZuweiser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameZuweiser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameZuweiser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCoach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCoach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEintritt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNiveau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZuteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNiveau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEintritt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void CtlKaQJUebersicht_Enter(object sender, System.EventArgs e)
        {
            FillUebersicht();
        }

        private void CtlKaQJUebersicht_Load(object sender, System.EventArgs e)
        {
            FillUebersicht();
        }

        private void FillUebersicht()
        {
            qryBaPerson.Fill(@"
				SELECT	PRS.*,
						Nationalitaet = PRS.Nationalitaet,
						Ausweis = dbo.fnLOVText('Aufenthaltsstatus', AuslaenderStatusCode),
						Vorbildung = dbo.fnLOVText('KaAusbildungVorbildung',Convert(VARCHAR, KA.KaAusbildungVorbildungCode)),
						Adresse = PRS.WohnsitzStrasseHausNr,
						PlzOrt = PRS.WohnsitzPLZOrt
				FROM	vwPerson PRS
				  LEFT JOIN dbo.FaLeistung LEI ON LEI.BaPersonID = PRS.BaPersonID
				                              AND LEI.ModulID = 7
				                              AND LEI.FaProzessCode = 700
					LEFT JOIN KaAusbildung KA ON KA.FaLeistungID = LEI.FaLeistungID
				WHERE	PRS.BaPersonID = {0}
				AND		(PRS.PersonSichtbarSDFlag = {1} or PRS.PersonSichtbarSDFlag = 1)",
                BaPersonID, KaUtil.GetPersonSichtbarSDFlag(BaPersonID));

            qryFallfuehrung.Fill(@"
				SELECT	Institution = case when KPR.FallfuehrungID < 0 then XOU.ItemName else ORG.Name end,
						Name = case when KPR.FallfuehrungID < 0 then
							XUR1.LastName + isNull(', ' + XUR1.FirstName,'')
							else OKO.Name + isNull(', ' + OKO.Vorname,'')
							end,
						Tel = case when KPR.FallfuehrungID < 0 then XUR1.Phone else OKO.Telefon end,
						Adresse = IsNull(ADR.Strasse,'') + ' ' + IsNull(ADR.HausNr,''),
						PlzOrt = IsNull(ADR.PLZ,'') + ' ' + IsNull(ADR.Ort, ''),
						Email = case when KPR.FallfuehrungID < 0 then XUR1.Email else OKO.Email end,
						Coach  = USR.LastName + isNull(', ' + USR.FirstName,'')
				FROM dbo.KaQJProzess KPR
						LEFT JOIN BaInstitutionKontakt OKO ON OKO.BaInstitutionKontaktID = KPR.FallfuehrungID
						LEFT JOIN BaInstitution ORG on ORG.BaInstitutionID = OKO.BaInstitutionID
						LEFT JOIN BaAdresse ADR ON ADR.BaInstitutionID = ORG.BaInstitutionID
						LEFT JOIN KaZuteilFachbereich PRZ on PRZ.BaPersonID = {0} and
														     PRZ.ZuteilungVon = (select max(PRZ1.ZuteilungVon) from KaZuteilFachbereich PRZ1 where PRZ1.BaPersonID = PRZ.BaPersonID AND PRZ1.ZuteilungVon < (SELECT IsNull(DatumBis, GetDate()) FROM FaLeistung WHERE FaLeistungID = {2}))
						LEFT JOIN XUser USR ON USR.UserID = PRZ.ZustaendigKaID
						LEFT JOIN XUser	XUR1 ON XUR1.UserID = -KPR.FallfuehrungID
						LEFT JOIN XOrgUnit_User OUU ON OUU.UserID = -KPR.FallfuehrungID
								 AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
						LEFT JOIN XOrgUnit XOU ON XOU.OrgUnitID = OUU.OrgUnitID
				WHERE KPR.FaLeistungID = {2}
				  AND (KPR.SichtbarSDFlag = {1} or KPR.SichtbarSDFlag = 1)",
                BaPersonID, KaUtil.GetSichtbarSDFlag(this.BaPersonID), this.FaLeistungID);

            qryZuteilung.Fill(@"
				SELECT 	ZUT.*,
						Eintritt = (SELECT CONVERT(DateTime, MIN(ZuteilungVon), 104) FROM KaZuteilFachbereich WHERE BaPersonID = {0} AND ZuteilungVon between (SELECT dateadd(day, -1, DatumVon) FROM FaLeistung WHERE FaLeistungID = {2}) AND (SELECT IsNull(DatumBis, GetDate()) FROM FaLeistung WHERE FaLeistungID = {2})),
						Niveau = dbo.fnLOVText('KaQjNiveau', ZUT.NiveauCode)
				FROM	KaZuteilFachbereich ZUT
				WHERE 	ZUT.BaPersonID = {0}
				AND		ZUT.ZuteilungVon = (SELECT max(ZUT1.ZuteilungVon)
											FROM   KaZuteilFachbereich ZUT1
											WHERE  ZUT1.BaPersonID = {0}
                                            AND    ZUT1.ZuteilungVon < (SELECT IsNull(DatumBis, GetDate()) FROM FaLeistung WHERE FaLeistungID = {2}))
				AND		(ZUT.SichtbarSDFlag = {1} or ZUT.SichtbarSDFlag = 1)",
                BaPersonID, KaUtil.GetSichtbarSDFlag(this.BaPersonID), this.FaLeistungID);
        }
    }
}