using System;
using System.Drawing;
using System.Windows.Forms;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis
{
    /// <summary>
    /// Summary description for CtlGesundheit.
    /// </summary>
    public class CtlGesundheit : KiSS4.Gui.KissUserControl
    {
        private int BaPersonID = 0;
        private KiSS4.Gui.KissButton btnVerbuchen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit edtASVSAbmeldung;
        private KiSS4.Gui.KissDateEdit edtASVSAnmeldung;
        private KiSS4.Gui.KissRTFEdit edtBemerkung;
        private KissDateEdit edtEVAZDatum;
        private KiSS4.Gui.KissLookUpEdit edtIVEingliederungsmassnahmeCode;
        private KiSS4.Gui.KissCalcEdit edtKVGFranchise;
        private KiSS4.Gui.KissCalcEdit edtKVGGesundheit;
        private KiSS4.Gui.KissCalcEdit edtKVGGrundpraemie;
        private KiSS4.Gui.KissButtonEdit edtKVGInstitution;
        private KiSS4.Gui.KissTextEdit edtKVGKontaktperson;
        private KiSS4.Gui.KissTextEdit edtKVGKontaktTelefon;
        private KiSS4.Gui.KissTextEdit edtKVGMitgliedNr;
        private KiSS4.Gui.KissCalcEdit edtKVGPraemie;
        private KiSS4.Gui.KissCalcEdit edtKVGUmweltabgabe;
        private KiSS4.Gui.KissCalcEdit edtKVGUnfallPraemie;
        private KiSS4.Gui.KissDateEdit edtKVGVersichertSeit;
        private KiSS4.Gui.KissLookUpEdit edtKVGZahlungsperiodeCode;
        private KiSS4.Gui.KissCalcEdit edtKVGZuschussBetrag;
        private KiSS4.Gui.KissCheckEdit edtPflegebeduerftig;
        private KiSS4.Gui.KissLookUpEdit edtPflegeDurchCode;
        private KiSS4.Gui.KissCalcEdit edtVVGFranchise;
        private KiSS4.Gui.KissButtonEdit edtVVGInstitution;
        private KiSS4.Gui.KissTextEdit edtVVGKontaktperson;
        private KiSS4.Gui.KissTextEdit edtVVGKontaktTelefon;
        private KiSS4.Gui.KissTextEdit edtVVGMitgliedNr;
        private KiSS4.Gui.KissCalcEdit edtVVGPraemie;
        private KiSS4.Gui.KissDateEdit edtVVGVersichertSeit;
        private KiSS4.Gui.KissLookUpEdit edtVVGZahlungsperiodeCode;
        private KiSS4.Gui.KissRTFEdit edtVVGZusaetzeRTF;
        private KissButtonEdit edtZahnarztBaInstitutionID;
        private KiSS4.Gui.KissCheckEdit edtZuschussInAbklaerungFlag;
        private KiSS4.Gui.KissLabel lblASVSAb;

        // ASVS: wird neu in einer separaten Maske geführt. Kann entfernt werden, sobald sicher ist das jeder Kunde die neue Maske verwendet
        private KiSS4.Gui.KissLabel lblASVSAn;

        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblCHFKVGFranchise;
        private KiSS4.Gui.KissLabel lblCHFKVGGesundFoerdPraemie;
        private KiSS4.Gui.KissLabel lblCHFKVGGrundpraemie;
        private KiSS4.Gui.KissLabel lblCHFKVGPraemie;
        private KiSS4.Gui.KissLabel lblCHFKVGUmweltabgabeBetrag;
        private KiSS4.Gui.KissLabel lblCHFKVGUnfallPraemie;
        private KiSS4.Gui.KissLabel lblCHFKVGZuschussBetrag;
        private KiSS4.Gui.KissLabel lblCHFVVGFranchise;
        private KiSS4.Gui.KissLabel lblCHFVVGPraemie;
        private KissLabel lblEVAZDatum;
        private KiSS4.Gui.KissLabel lblGleichKVGPraemie;
        private KiSS4.Gui.KissLabel lblIVEingliederungsmassnahmeCode;
        private KiSS4.Gui.KissLabel lblKVG;
        private KiSS4.Gui.KissLabel lblKVGFranchise;
        private KiSS4.Gui.KissLabel lblKVGGesundFoerdPraemie;
        private KiSS4.Gui.KissLabel lblKVGGrundpraemie;
        private KiSS4.Gui.KissLabel lblKVGInstitution;
        private KiSS4.Gui.KissLabel lblKVGKontaktperson;
        private KiSS4.Gui.KissLabel lblKVGKontaktTelefon;
        private KiSS4.Gui.KissLabel lblKVGMitgliedNr;
        private KiSS4.Gui.KissLabel lblKVGPraemie;
        private KiSS4.Gui.KissLabel lblKVGUmweltabgabeBetrag;
        private KiSS4.Gui.KissLabel lblKVGUnfallPraemie;
        private KiSS4.Gui.KissLabel lblKVGVersichertSeit;
        private KiSS4.Gui.KissLabel lblKVGZuschussBetrag;
        private KiSS4.Gui.KissLabel lblMinusKVGUmweltabgabeBetrag;
        private KiSS4.Gui.KissLabel lblMinusKVGZuschussBetrag;
        private KiSS4.Gui.KissLabel lblPflegeDurchCode;
        private KiSS4.Gui.KissLabel lblPlusKVGGesundFoerdPraemie;
        private KiSS4.Gui.KissLabel lblPlusKVGGrundpraemie;
        private KiSS4.Gui.KissLabel lblPlusKVGUnfallPraemie;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblVVG;
        private KiSS4.Gui.KissLabel lblVVGZusaetzeRTF;
        private KissLabel lblZahnarztBaInstitutionID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryGesundheit;

        public CtlGesundheit()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>

        public void Init(string TitleName, Image TitleImage, int BaPersonID, bool IsFallTraeger)
        {
            this.BaPersonID = BaPersonID;
            this.picTitel.Image = TitleImage;

            //Filter out "weiss nicht"
            SqlQuery qry = (SqlQuery)edtPflegeDurchCode.Properties.DataSource;
            qry.DataTable.DefaultView.RowFilter = "Code <> 99999";

            //Gesundheit
            qryGesundheit.Fill(BaPersonID);
        }

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlGesundheit));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryGesundheit = new KiSS4.DB.SqlQuery(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVVG = new KiSS4.Gui.KissLabel();
            this.lblKVG = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.edtKVGInstitution = new KiSS4.Gui.KissButtonEdit();
            this.lblKVGInstitution = new KiSS4.Gui.KissLabel();
            this.edtVVGInstitution = new KiSS4.Gui.KissButtonEdit();
            this.lblKVGFranchise = new KiSS4.Gui.KissLabel();
            this.lblKVGPraemie = new KiSS4.Gui.KissLabel();
            this.lblKVGGrundpraemie = new KiSS4.Gui.KissLabel();
            this.lblKVGUmweltabgabeBetrag = new KiSS4.Gui.KissLabel();
            this.lblKVGVersichertSeit = new KiSS4.Gui.KissLabel();
            this.lblKVGMitgliedNr = new KiSS4.Gui.KissLabel();
            this.lblKVGKontaktTelefon = new KiSS4.Gui.KissLabel();
            this.lblKVGKontaktperson = new KiSS4.Gui.KissLabel();
            this.edtKVGKontaktperson = new KiSS4.Gui.KissTextEdit();
            this.edtVVGKontaktperson = new KiSS4.Gui.KissTextEdit();
            this.edtVVGKontaktTelefon = new KiSS4.Gui.KissTextEdit();
            this.edtKVGKontaktTelefon = new KiSS4.Gui.KissTextEdit();
            this.edtVVGMitgliedNr = new KiSS4.Gui.KissTextEdit();
            this.edtKVGMitgliedNr = new KiSS4.Gui.KissTextEdit();
            this.edtKVGVersichertSeit = new KiSS4.Gui.KissDateEdit();
            this.edtVVGVersichertSeit = new KiSS4.Gui.KissDateEdit();
            this.edtKVGGrundpraemie = new KiSS4.Gui.KissCalcEdit();
            this.edtKVGFranchise = new KiSS4.Gui.KissCalcEdit();
            this.edtKVGPraemie = new KiSS4.Gui.KissCalcEdit();
            this.edtKVGUmweltabgabe = new KiSS4.Gui.KissCalcEdit();
            this.edtKVGZuschussBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtKVGGesundheit = new KiSS4.Gui.KissCalcEdit();
            this.edtKVGUnfallPraemie = new KiSS4.Gui.KissCalcEdit();
            this.edtBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtVVGZusaetzeRTF = new KiSS4.Gui.KissRTFEdit();
            this.lblKVGZuschussBetrag = new KiSS4.Gui.KissLabel();
            this.lblKVGGesundFoerdPraemie = new KiSS4.Gui.KissLabel();
            this.lblKVGUnfallPraemie = new KiSS4.Gui.KissLabel();
            this.edtIVEingliederungsmassnahmeCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtZuschussInAbklaerungFlag = new KiSS4.Gui.KissCheckEdit();
            this.edtPflegebeduerftig = new KiSS4.Gui.KissCheckEdit();
            this.lblVVGZusaetzeRTF = new KiSS4.Gui.KissLabel();
            this.lblPflegeDurchCode = new KiSS4.Gui.KissLabel();
            this.edtPflegeDurchCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtVVGPraemie = new KiSS4.Gui.KissCalcEdit();
            this.edtVVGFranchise = new KiSS4.Gui.KissCalcEdit();
            this.edtKVGZahlungsperiodeCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtVVGZahlungsperiodeCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblCHFKVGUnfallPraemie = new KiSS4.Gui.KissLabel();
            this.lblCHFKVGGesundFoerdPraemie = new KiSS4.Gui.KissLabel();
            this.lblCHFKVGGrundpraemie = new KiSS4.Gui.KissLabel();
            this.lblCHFKVGZuschussBetrag = new KiSS4.Gui.KissLabel();
            this.lblCHFKVGUmweltabgabeBetrag = new KiSS4.Gui.KissLabel();
            this.lblCHFKVGPraemie = new KiSS4.Gui.KissLabel();
            this.lblCHFKVGFranchise = new KiSS4.Gui.KissLabel();
            this.lblCHFVVGPraemie = new KiSS4.Gui.KissLabel();
            this.lblCHFVVGFranchise = new KiSS4.Gui.KissLabel();
            this.lblIVEingliederungsmassnahmeCode = new KiSS4.Gui.KissLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPlusKVGGesundFoerdPraemie = new KiSS4.Gui.KissLabel();
            this.lblMinusKVGZuschussBetrag = new KiSS4.Gui.KissLabel();
            this.lblPlusKVGUnfallPraemie = new KiSS4.Gui.KissLabel();
            this.lblPlusKVGGrundpraemie = new KiSS4.Gui.KissLabel();
            this.lblMinusKVGUmweltabgabeBetrag = new KiSS4.Gui.KissLabel();
            this.lblGleichKVGPraemie = new KiSS4.Gui.KissLabel();
            this.btnVerbuchen = new KiSS4.Gui.KissButton();
            this.edtASVSAnmeldung = new KiSS4.Gui.KissDateEdit();
            this.lblASVSAn = new KiSS4.Gui.KissLabel();
            this.lblASVSAb = new KiSS4.Gui.KissLabel();
            this.edtASVSAbmeldung = new KiSS4.Gui.KissDateEdit();
            this.edtEVAZDatum = new KiSS4.Gui.KissDateEdit();
            this.edtZahnarztBaInstitutionID = new KiSS4.Gui.KissButtonEdit();
            this.lblEVAZDatum = new KiSS4.Gui.KissLabel();
            this.lblZahnarztBaInstitutionID = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryGesundheit)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblVVG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGInstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGFranchise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGPraemie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGGrundpraemie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGUmweltabgabeBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGVersichertSeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGMitgliedNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGKontaktTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGKontaktperson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGKontaktperson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGKontaktperson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGKontaktTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGKontaktTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGMitgliedNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGMitgliedNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGVersichertSeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGVersichertSeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGGrundpraemie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGFranchise.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGPraemie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGUmweltabgabe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGZuschussBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGGesundheit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGUnfallPraemie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGZuschussBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGGesundFoerdPraemie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGUnfallPraemie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIVEingliederungsmassnahmeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIVEingliederungsmassnahmeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuschussInAbklaerungFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPflegebeduerftig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVVGZusaetzeRTF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPflegeDurchCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPflegeDurchCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPflegeDurchCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGPraemie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGFranchise.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGZahlungsperiodeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGZahlungsperiodeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGZahlungsperiodeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGZahlungsperiodeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFKVGUnfallPraemie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFKVGGesundFoerdPraemie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFKVGGrundpraemie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFKVGZuschussBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFKVGUmweltabgabeBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFKVGPraemie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFKVGFranchise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFVVGPraemie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFVVGFranchise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVEingliederungsmassnahmeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlusKVGGesundFoerdPraemie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMinusKVGZuschussBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlusKVGUnfallPraemie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlusKVGGrundpraemie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMinusKVGUmweltabgabeBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGleichKVGPraemie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtASVSAnmeldung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblASVSAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblASVSAb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtASVSAbmeldung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEVAZDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahnarztBaInstitutionID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEVAZDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahnarztBaInstitutionID)).BeginInit();
            this.SuspendLayout();
            //
            // qryGesundheit
            //
            this.qryGesundheit.CanInsert = true;
            this.qryGesundheit.CanUpdate = true;
            this.qryGesundheit.HostControl = this;
            this.qryGesundheit.SelectStatement = resources.GetString("qryGesundheit.SelectStatement");
            this.qryGesundheit.TableName = "BaGesundheit";
            this.qryGesundheit.AfterFill += new System.EventHandler(this.qryGesundheit_AfterFill);
            this.qryGesundheit.AfterInsert += new System.EventHandler(this.qryGesundheit_AfterInsert);
            //
            // panel1
            //
            this.panel1.Controls.Add(this.lblVVG);
            this.panel1.Controls.Add(this.lblKVG);
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 30);
            this.panel1.TabIndex = 333;
            //
            // lblVVG
            //
            this.lblVVG.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblVVG.Location = new System.Drawing.Point(545, 10);
            this.lblVVG.Name = "lblVVG";
            this.lblVVG.Size = new System.Drawing.Size(45, 16);
            this.lblVVG.TabIndex = 336;
            this.lblVVG.Text = "VVG";
            //
            // lblKVG
            //
            this.lblKVG.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblKVG.Location = new System.Drawing.Point(231, 10);
            this.lblKVG.Name = "lblKVG";
            this.lblKVG.Size = new System.Drawing.Size(57, 16);
            this.lblKVG.TabIndex = 335;
            this.lblKVG.Text = "KVG";
            //
            // picTitel
            //
            this.picTitel.Image = ((System.Drawing.Image)(resources.GetObject("picTitel.Image")));
            this.picTitel.Location = new System.Drawing.Point(5, 9);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            //
            // lblTitel
            //
            this.lblTitel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblTitel.Location = new System.Drawing.Point(25, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(200, 16);
            this.lblTitel.TabIndex = 292;
            this.lblTitel.Text = "Gesundheit";
            //
            // edtKVGInstitution
            //
            this.edtKVGInstitution.DataMember = "KVGInstitution";
            this.edtKVGInstitution.DataSource = this.qryGesundheit;
            this.edtKVGInstitution.Location = new System.Drawing.Point(115, 40);
            this.edtKVGInstitution.Name = "edtKVGInstitution";
            this.edtKVGInstitution.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKVGInstitution.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGInstitution.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGInstitution.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGInstitution.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGInstitution.Properties.Appearance.Options.UseFont = true;
            this.edtKVGInstitution.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtKVGInstitution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtKVGInstitution.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGInstitution.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKVGInstitution.Size = new System.Drawing.Size(285, 24);
            this.edtKVGInstitution.TabIndex = 0;
            this.edtKVGInstitution.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKVGInstitution_UserModifiedFld);
            //
            // lblKVGInstitution
            //
            this.lblKVGInstitution.ForeColor = System.Drawing.Color.Black;
            this.lblKVGInstitution.Location = new System.Drawing.Point(5, 40);
            this.lblKVGInstitution.Name = "lblKVGInstitution";
            this.lblKVGInstitution.Size = new System.Drawing.Size(105, 24);
            this.lblKVGInstitution.TabIndex = 446;
            this.lblKVGInstitution.Text = "Krankenkasse";
            //
            // edtVVGInstitution
            //
            this.edtVVGInstitution.DataMember = "VVGInstitution";
            this.edtVVGInstitution.DataSource = this.qryGesundheit;
            this.edtVVGInstitution.Location = new System.Drawing.Point(425, 40);
            this.edtVVGInstitution.Name = "edtVVGInstitution";
            this.edtVVGInstitution.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVVGInstitution.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVVGInstitution.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVVGInstitution.Properties.Appearance.Options.UseBackColor = true;
            this.edtVVGInstitution.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVVGInstitution.Properties.Appearance.Options.UseFont = true;
            this.edtVVGInstitution.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtVVGInstitution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtVVGInstitution.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVVGInstitution.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtVVGInstitution.Size = new System.Drawing.Size(285, 24);
            this.edtVVGInstitution.TabIndex = 14;
            this.edtVVGInstitution.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtVVGInstitution_UserModifiedFld);
            //
            // lblKVGFranchise
            //
            this.lblKVGFranchise.ForeColor = System.Drawing.Color.Black;
            this.lblKVGFranchise.Location = new System.Drawing.Point(5, 321);
            this.lblKVGFranchise.Name = "lblKVGFranchise";
            this.lblKVGFranchise.Size = new System.Drawing.Size(90, 24);
            this.lblKVGFranchise.TabIndex = 448;
            this.lblKVGFranchise.Text = "Franchise";
            //
            // lblKVGPraemie
            //
            this.lblKVGPraemie.ForeColor = System.Drawing.Color.Black;
            this.lblKVGPraemie.Location = new System.Drawing.Point(5, 291);
            this.lblKVGPraemie.Name = "lblKVGPraemie";
            this.lblKVGPraemie.Size = new System.Drawing.Size(90, 24);
            this.lblKVGPraemie.TabIndex = 449;
            this.lblKVGPraemie.Text = "Prämie / Zahlung";
            //
            // lblKVGGrundpraemie
            //
            this.lblKVGGrundpraemie.ForeColor = System.Drawing.Color.Black;
            this.lblKVGGrundpraemie.Location = new System.Drawing.Point(5, 169);
            this.lblKVGGrundpraemie.Name = "lblKVGGrundpraemie";
            this.lblKVGGrundpraemie.Size = new System.Drawing.Size(90, 24);
            this.lblKVGGrundpraemie.TabIndex = 450;
            this.lblKVGGrundpraemie.Text = "Grundprämie";
            //
            // lblKVGUmweltabgabeBetrag
            //
            this.lblKVGUmweltabgabeBetrag.ForeColor = System.Drawing.Color.Black;
            this.lblKVGUmweltabgabeBetrag.Location = new System.Drawing.Point(5, 261);
            this.lblKVGUmweltabgabeBetrag.Name = "lblKVGUmweltabgabeBetrag";
            this.lblKVGUmweltabgabeBetrag.Size = new System.Drawing.Size(90, 24);
            this.lblKVGUmweltabgabeBetrag.TabIndex = 451;
            this.lblKVGUmweltabgabeBetrag.Text = "Umweltabgabe";
            //
            // lblKVGVersichertSeit
            //
            this.lblKVGVersichertSeit.ForeColor = System.Drawing.Color.Black;
            this.lblKVGVersichertSeit.Location = new System.Drawing.Point(5, 139);
            this.lblKVGVersichertSeit.Name = "lblKVGVersichertSeit";
            this.lblKVGVersichertSeit.Size = new System.Drawing.Size(103, 24);
            this.lblKVGVersichertSeit.TabIndex = 452;
            this.lblKVGVersichertSeit.Text = "versichert seit";
            //
            // lblKVGMitgliedNr
            //
            this.lblKVGMitgliedNr.ForeColor = System.Drawing.Color.Black;
            this.lblKVGMitgliedNr.Location = new System.Drawing.Point(5, 109);
            this.lblKVGMitgliedNr.Name = "lblKVGMitgliedNr";
            this.lblKVGMitgliedNr.Size = new System.Drawing.Size(103, 24);
            this.lblKVGMitgliedNr.TabIndex = 453;
            this.lblKVGMitgliedNr.Text = "Mitglied-Nr";
            //
            // lblKVGKontaktTelefon
            //
            this.lblKVGKontaktTelefon.ForeColor = System.Drawing.Color.Black;
            this.lblKVGKontaktTelefon.Location = new System.Drawing.Point(5, 86);
            this.lblKVGKontaktTelefon.Name = "lblKVGKontaktTelefon";
            this.lblKVGKontaktTelefon.Size = new System.Drawing.Size(103, 24);
            this.lblKVGKontaktTelefon.TabIndex = 454;
            this.lblKVGKontaktTelefon.Text = "Telefon";
            //
            // lblKVGKontaktperson
            //
            this.lblKVGKontaktperson.ForeColor = System.Drawing.Color.Black;
            this.lblKVGKontaktperson.Location = new System.Drawing.Point(5, 63);
            this.lblKVGKontaktperson.Name = "lblKVGKontaktperson";
            this.lblKVGKontaktperson.Size = new System.Drawing.Size(105, 24);
            this.lblKVGKontaktperson.TabIndex = 455;
            this.lblKVGKontaktperson.Text = "Kontaktperson";
            //
            // edtKVGKontaktperson
            //
            this.edtKVGKontaktperson.DataMember = "KVGKontaktperson";
            this.edtKVGKontaktperson.DataSource = this.qryGesundheit;
            this.edtKVGKontaktperson.Location = new System.Drawing.Point(115, 63);
            this.edtKVGKontaktperson.Name = "edtKVGKontaktperson";
            this.edtKVGKontaktperson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKVGKontaktperson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGKontaktperson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGKontaktperson.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGKontaktperson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGKontaktperson.Properties.Appearance.Options.UseFont = true;
            this.edtKVGKontaktperson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGKontaktperson.Size = new System.Drawing.Size(285, 24);
            this.edtKVGKontaktperson.TabIndex = 1;
            //
            // edtVVGKontaktperson
            //
            this.edtVVGKontaktperson.DataMember = "VVGKontaktperson";
            this.edtVVGKontaktperson.DataSource = this.qryGesundheit;
            this.edtVVGKontaktperson.Location = new System.Drawing.Point(425, 63);
            this.edtVVGKontaktperson.Name = "edtVVGKontaktperson";
            this.edtVVGKontaktperson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVVGKontaktperson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVVGKontaktperson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVVGKontaktperson.Properties.Appearance.Options.UseBackColor = true;
            this.edtVVGKontaktperson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVVGKontaktperson.Properties.Appearance.Options.UseFont = true;
            this.edtVVGKontaktperson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVVGKontaktperson.Size = new System.Drawing.Size(285, 24);
            this.edtVVGKontaktperson.TabIndex = 15;
            //
            // edtVVGKontaktTelefon
            //
            this.edtVVGKontaktTelefon.DataMember = "VVGKontaktTelefon";
            this.edtVVGKontaktTelefon.DataSource = this.qryGesundheit;
            this.edtVVGKontaktTelefon.Location = new System.Drawing.Point(425, 86);
            this.edtVVGKontaktTelefon.Name = "edtVVGKontaktTelefon";
            this.edtVVGKontaktTelefon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVVGKontaktTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVVGKontaktTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVVGKontaktTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtVVGKontaktTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVVGKontaktTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtVVGKontaktTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVVGKontaktTelefon.Size = new System.Drawing.Size(285, 24);
            this.edtVVGKontaktTelefon.TabIndex = 16;
            //
            // edtKVGKontaktTelefon
            //
            this.edtKVGKontaktTelefon.DataMember = "KVGKontaktTelefon";
            this.edtKVGKontaktTelefon.DataSource = this.qryGesundheit;
            this.edtKVGKontaktTelefon.Location = new System.Drawing.Point(115, 86);
            this.edtKVGKontaktTelefon.Name = "edtKVGKontaktTelefon";
            this.edtKVGKontaktTelefon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKVGKontaktTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGKontaktTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGKontaktTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGKontaktTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGKontaktTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtKVGKontaktTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGKontaktTelefon.Size = new System.Drawing.Size(285, 24);
            this.edtKVGKontaktTelefon.TabIndex = 2;
            //
            // edtVVGMitgliedNr
            //
            this.edtVVGMitgliedNr.DataMember = "VVGMitgliedNr";
            this.edtVVGMitgliedNr.DataSource = this.qryGesundheit;
            this.edtVVGMitgliedNr.Location = new System.Drawing.Point(425, 109);
            this.edtVVGMitgliedNr.Name = "edtVVGMitgliedNr";
            this.edtVVGMitgliedNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVVGMitgliedNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVVGMitgliedNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVVGMitgliedNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtVVGMitgliedNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVVGMitgliedNr.Properties.Appearance.Options.UseFont = true;
            this.edtVVGMitgliedNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVVGMitgliedNr.Size = new System.Drawing.Size(285, 24);
            this.edtVVGMitgliedNr.TabIndex = 17;
            //
            // edtKVGMitgliedNr
            //
            this.edtKVGMitgliedNr.DataMember = "KVGMitgliedNr";
            this.edtKVGMitgliedNr.DataSource = this.qryGesundheit;
            this.edtKVGMitgliedNr.Location = new System.Drawing.Point(115, 109);
            this.edtKVGMitgliedNr.Name = "edtKVGMitgliedNr";
            this.edtKVGMitgliedNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKVGMitgliedNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGMitgliedNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGMitgliedNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGMitgliedNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGMitgliedNr.Properties.Appearance.Options.UseFont = true;
            this.edtKVGMitgliedNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGMitgliedNr.Size = new System.Drawing.Size(285, 24);
            this.edtKVGMitgliedNr.TabIndex = 3;
            //
            // edtKVGVersichertSeit
            //
            this.edtKVGVersichertSeit.DataMember = "KVGVersichertSeit";
            this.edtKVGVersichertSeit.DataSource = this.qryGesundheit;
            this.edtKVGVersichertSeit.EditValue = null;
            this.edtKVGVersichertSeit.Location = new System.Drawing.Point(115, 139);
            this.edtKVGVersichertSeit.Name = "edtKVGVersichertSeit";
            this.edtKVGVersichertSeit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKVGVersichertSeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKVGVersichertSeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGVersichertSeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGVersichertSeit.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGVersichertSeit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGVersichertSeit.Properties.Appearance.Options.UseFont = true;
            this.edtKVGVersichertSeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtKVGVersichertSeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtKVGVersichertSeit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtKVGVersichertSeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGVersichertSeit.Properties.ShowToday = false;
            this.edtKVGVersichertSeit.Size = new System.Drawing.Size(110, 24);
            this.edtKVGVersichertSeit.TabIndex = 4;
            //
            // edtVVGVersichertSeit
            //
            this.edtVVGVersichertSeit.DataMember = "VVGVersichertSeit";
            this.edtVVGVersichertSeit.DataSource = this.qryGesundheit;
            this.edtVVGVersichertSeit.EditValue = null;
            this.edtVVGVersichertSeit.Location = new System.Drawing.Point(425, 139);
            this.edtVVGVersichertSeit.Name = "edtVVGVersichertSeit";
            this.edtVVGVersichertSeit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVVGVersichertSeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVVGVersichertSeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVVGVersichertSeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVVGVersichertSeit.Properties.Appearance.Options.UseBackColor = true;
            this.edtVVGVersichertSeit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVVGVersichertSeit.Properties.Appearance.Options.UseFont = true;
            this.edtVVGVersichertSeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtVVGVersichertSeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVVGVersichertSeit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtVVGVersichertSeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVVGVersichertSeit.Properties.ShowToday = false;
            this.edtVVGVersichertSeit.Size = new System.Drawing.Size(110, 24);
            this.edtVVGVersichertSeit.TabIndex = 18;
            //
            // edtKVGGrundpraemie
            //
            this.edtKVGGrundpraemie.DataMember = "KVGGrundpraemie";
            this.edtKVGGrundpraemie.DataSource = this.qryGesundheit;
            this.edtKVGGrundpraemie.Location = new System.Drawing.Point(115, 169);
            this.edtKVGGrundpraemie.Name = "edtKVGGrundpraemie";
            this.edtKVGGrundpraemie.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKVGGrundpraemie.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKVGGrundpraemie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGGrundpraemie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGGrundpraemie.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGGrundpraemie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGGrundpraemie.Properties.Appearance.Options.UseFont = true;
            this.edtKVGGrundpraemie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGGrundpraemie.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGGrundpraemie.Properties.DisplayFormat.FormatString = "N2";
            this.edtKVGGrundpraemie.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGGrundpraemie.Properties.NullText = "0.00";
            this.edtKVGGrundpraemie.Size = new System.Drawing.Size(80, 24);
            this.edtKVGGrundpraemie.TabIndex = 5;
            this.edtKVGGrundpraemie.Leave += new System.EventHandler(this.Praemie_Leave);
            //
            // edtKVGFranchise
            //
            this.edtKVGFranchise.DataMember = "KVGFranchise";
            this.edtKVGFranchise.DataSource = this.qryGesundheit;
            this.edtKVGFranchise.Location = new System.Drawing.Point(115, 321);
            this.edtKVGFranchise.Name = "edtKVGFranchise";
            this.edtKVGFranchise.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKVGFranchise.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKVGFranchise.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGFranchise.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGFranchise.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGFranchise.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGFranchise.Properties.Appearance.Options.UseFont = true;
            this.edtKVGFranchise.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGFranchise.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGFranchise.Properties.DisplayFormat.FormatString = "N2";
            this.edtKVGFranchise.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGFranchise.Properties.NullText = "0.00";
            this.edtKVGFranchise.Size = new System.Drawing.Size(80, 24);
            this.edtKVGFranchise.TabIndex = 13;
            //
            // edtKVGPraemie
            //
            this.edtKVGPraemie.DataMember = "KVGPraemie";
            this.edtKVGPraemie.DataSource = this.qryGesundheit;
            this.edtKVGPraemie.Location = new System.Drawing.Point(115, 291);
            this.edtKVGPraemie.Name = "edtKVGPraemie";
            this.edtKVGPraemie.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKVGPraemie.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKVGPraemie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGPraemie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGPraemie.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGPraemie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGPraemie.Properties.Appearance.Options.UseFont = true;
            this.edtKVGPraemie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGPraemie.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGPraemie.Properties.DisplayFormat.FormatString = "N2";
            this.edtKVGPraemie.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGPraemie.Properties.EditFormat.FormatString = "N2";
            this.edtKVGPraemie.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGPraemie.Properties.NullText = "0.00";
            this.edtKVGPraemie.Size = new System.Drawing.Size(80, 24);
            this.edtKVGPraemie.TabIndex = 11;
            //
            // edtKVGUmweltabgabe
            //
            this.edtKVGUmweltabgabe.DataMember = "KVGUmweltabgabeBetrag";
            this.edtKVGUmweltabgabe.DataSource = this.qryGesundheit;
            this.edtKVGUmweltabgabe.Location = new System.Drawing.Point(115, 261);
            this.edtKVGUmweltabgabe.Name = "edtKVGUmweltabgabe";
            this.edtKVGUmweltabgabe.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKVGUmweltabgabe.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKVGUmweltabgabe.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGUmweltabgabe.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGUmweltabgabe.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGUmweltabgabe.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGUmweltabgabe.Properties.Appearance.Options.UseFont = true;
            this.edtKVGUmweltabgabe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGUmweltabgabe.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGUmweltabgabe.Properties.DisplayFormat.FormatString = "N2";
            this.edtKVGUmweltabgabe.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGUmweltabgabe.Properties.NullText = "0.00";
            this.edtKVGUmweltabgabe.Size = new System.Drawing.Size(80, 24);
            this.edtKVGUmweltabgabe.TabIndex = 10;
            this.edtKVGUmweltabgabe.Leave += new System.EventHandler(this.Praemie_Leave);
            //
            // edtKVGZuschussBetrag
            //
            this.edtKVGZuschussBetrag.DataMember = "KVGZuschussBetrag";
            this.edtKVGZuschussBetrag.DataSource = this.qryGesundheit;
            this.edtKVGZuschussBetrag.Location = new System.Drawing.Point(115, 238);
            this.edtKVGZuschussBetrag.Name = "edtKVGZuschussBetrag";
            this.edtKVGZuschussBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKVGZuschussBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKVGZuschussBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGZuschussBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGZuschussBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGZuschussBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGZuschussBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtKVGZuschussBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGZuschussBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGZuschussBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtKVGZuschussBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGZuschussBetrag.Properties.NullText = "0.00";
            this.edtKVGZuschussBetrag.Size = new System.Drawing.Size(80, 24);
            this.edtKVGZuschussBetrag.TabIndex = 8;
            this.edtKVGZuschussBetrag.Leave += new System.EventHandler(this.Praemie_Leave);
            //
            // edtKVGGesundheit
            //
            this.edtKVGGesundheit.DataMember = "KVGGesundFoerdPraemie";
            this.edtKVGGesundheit.DataSource = this.qryGesundheit;
            this.edtKVGGesundheit.Location = new System.Drawing.Point(115, 215);
            this.edtKVGGesundheit.Name = "edtKVGGesundheit";
            this.edtKVGGesundheit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKVGGesundheit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKVGGesundheit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGGesundheit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGGesundheit.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGGesundheit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGGesundheit.Properties.Appearance.Options.UseFont = true;
            this.edtKVGGesundheit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGGesundheit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGGesundheit.Properties.DisplayFormat.FormatString = "N2";
            this.edtKVGGesundheit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGGesundheit.Properties.NullText = "0.00";
            this.edtKVGGesundheit.Size = new System.Drawing.Size(80, 24);
            this.edtKVGGesundheit.TabIndex = 7;
            this.edtKVGGesundheit.Leave += new System.EventHandler(this.Praemie_Leave);
            //
            // edtKVGUnfallPraemie
            //
            this.edtKVGUnfallPraemie.DataMember = "KVGUnfallPraemie";
            this.edtKVGUnfallPraemie.DataSource = this.qryGesundheit;
            this.edtKVGUnfallPraemie.Location = new System.Drawing.Point(115, 192);
            this.edtKVGUnfallPraemie.Name = "edtKVGUnfallPraemie";
            this.edtKVGUnfallPraemie.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKVGUnfallPraemie.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKVGUnfallPraemie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGUnfallPraemie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGUnfallPraemie.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGUnfallPraemie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGUnfallPraemie.Properties.Appearance.Options.UseFont = true;
            this.edtKVGUnfallPraemie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKVGUnfallPraemie.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGUnfallPraemie.Properties.DisplayFormat.FormatString = "N2";
            this.edtKVGUnfallPraemie.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKVGUnfallPraemie.Properties.NullText = "0.00";
            this.edtKVGUnfallPraemie.Size = new System.Drawing.Size(80, 24);
            this.edtKVGUnfallPraemie.TabIndex = 6;
            this.edtKVGUnfallPraemie.Leave += new System.EventHandler(this.Praemie_Leave);
            //
            // edtBemerkung
            //
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.BackColor = System.Drawing.Color.White;
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryGesundheit;
            this.edtBemerkung.Font = new System.Drawing.Font("Arial", 10F);
            this.edtBemerkung.Location = new System.Drawing.Point(115, 465);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Size = new System.Drawing.Size(595, 154);
            this.edtBemerkung.TabIndex = 26;
            //
            // lblBemerkung
            //
            this.lblBemerkung.ForeColor = System.Drawing.Color.Black;
            this.lblBemerkung.Location = new System.Drawing.Point(5, 465);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(103, 24);
            this.lblBemerkung.TabIndex = 472;
            this.lblBemerkung.Text = "Bemerkung";
            //
            // edtVVGZusaetzeRTF
            //
            this.edtVVGZusaetzeRTF.BackColor = System.Drawing.Color.White;
            this.edtVVGZusaetzeRTF.DataMember = "VVGZusaetzeRTF";
            this.edtVVGZusaetzeRTF.DataSource = this.qryGesundheit;
            this.edtVVGZusaetzeRTF.Font = new System.Drawing.Font("Arial", 10F);
            this.edtVVGZusaetzeRTF.Location = new System.Drawing.Point(425, 185);
            this.edtVVGZusaetzeRTF.Name = "edtVVGZusaetzeRTF";
            this.edtVVGZusaetzeRTF.Size = new System.Drawing.Size(285, 95);
            this.edtVVGZusaetzeRTF.TabIndex = 19;
            //
            // lblKVGZuschussBetrag
            //
            this.lblKVGZuschussBetrag.ForeColor = System.Drawing.Color.Black;
            this.lblKVGZuschussBetrag.Location = new System.Drawing.Point(5, 238);
            this.lblKVGZuschussBetrag.Name = "lblKVGZuschussBetrag";
            this.lblKVGZuschussBetrag.Size = new System.Drawing.Size(90, 24);
            this.lblKVGZuschussBetrag.TabIndex = 474;
            this.lblKVGZuschussBetrag.Text = "Prämienverb.";
            //
            // lblKVGGesundFoerdPraemie
            //
            this.lblKVGGesundFoerdPraemie.ForeColor = System.Drawing.Color.Black;
            this.lblKVGGesundFoerdPraemie.Location = new System.Drawing.Point(5, 215);
            this.lblKVGGesundFoerdPraemie.Name = "lblKVGGesundFoerdPraemie";
            this.lblKVGGesundFoerdPraemie.Size = new System.Drawing.Size(90, 24);
            this.lblKVGGesundFoerdPraemie.TabIndex = 475;
            this.lblKVGGesundFoerdPraemie.Text = "Gesundh. Förd.";
            //
            // lblKVGUnfallPraemie
            //
            this.lblKVGUnfallPraemie.ForeColor = System.Drawing.Color.Black;
            this.lblKVGUnfallPraemie.Location = new System.Drawing.Point(5, 192);
            this.lblKVGUnfallPraemie.Name = "lblKVGUnfallPraemie";
            this.lblKVGUnfallPraemie.Size = new System.Drawing.Size(90, 24);
            this.lblKVGUnfallPraemie.TabIndex = 476;
            this.lblKVGUnfallPraemie.Text = "Unfall";
            //
            // edtIVEingliederungsmassnahmeCode
            //
            this.edtIVEingliederungsmassnahmeCode.DataMember = "IVEingliederungsmassnahmeCode";
            this.edtIVEingliederungsmassnahmeCode.DataSource = this.qryGesundheit;
            this.edtIVEingliederungsmassnahmeCode.Location = new System.Drawing.Point(115, 370);
            this.edtIVEingliederungsmassnahmeCode.LOVName = "InAbklaerung";
            this.edtIVEingliederungsmassnahmeCode.Name = "edtIVEingliederungsmassnahmeCode";
            this.edtIVEingliederungsmassnahmeCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIVEingliederungsmassnahmeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIVEingliederungsmassnahmeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIVEingliederungsmassnahmeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtIVEingliederungsmassnahmeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIVEingliederungsmassnahmeCode.Properties.Appearance.Options.UseFont = true;
            this.edtIVEingliederungsmassnahmeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIVEingliederungsmassnahmeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIVEingliederungsmassnahmeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIVEingliederungsmassnahmeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIVEingliederungsmassnahmeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtIVEingliederungsmassnahmeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtIVEingliederungsmassnahmeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIVEingliederungsmassnahmeCode.Properties.NullText = "";
            this.edtIVEingliederungsmassnahmeCode.Properties.ShowFooter = false;
            this.edtIVEingliederungsmassnahmeCode.Properties.ShowHeader = false;
            this.edtIVEingliederungsmassnahmeCode.Size = new System.Drawing.Size(150, 24);
            this.edtIVEingliederungsmassnahmeCode.TabIndex = 23;
            //
            // edtZuschussInAbklaerungFlag
            //
            this.edtZuschussInAbklaerungFlag.DataMember = "ZuschussInAbklaerungFlag";
            this.edtZuschussInAbklaerungFlag.DataSource = this.qryGesundheit;
            this.edtZuschussInAbklaerungFlag.Location = new System.Drawing.Point(245, 242);
            this.edtZuschussInAbklaerungFlag.Name = "edtZuschussInAbklaerungFlag";
            this.edtZuschussInAbklaerungFlag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZuschussInAbklaerungFlag.Properties.Appearance.Options.UseBackColor = true;
            this.edtZuschussInAbklaerungFlag.Properties.Caption = "abklären";
            this.edtZuschussInAbklaerungFlag.Size = new System.Drawing.Size(100, 19);
            this.edtZuschussInAbklaerungFlag.TabIndex = 9;
            this.edtZuschussInAbklaerungFlag.EditValueChanged += new System.EventHandler(this.edtZuschussInAbklaerungFlag_EditValueChanged);
            //
            // edtPflegebeduerftig
            //
            this.edtPflegebeduerftig.DataMember = "PflegebeduerftigFlag";
            this.edtPflegebeduerftig.DataSource = this.qryGesundheit;
            this.edtPflegebeduerftig.Location = new System.Drawing.Point(300, 370);
            this.edtPflegebeduerftig.Name = "edtPflegebeduerftig";
            this.edtPflegebeduerftig.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPflegebeduerftig.Properties.Appearance.Options.UseBackColor = true;
            this.edtPflegebeduerftig.Properties.Caption = "pflegebedürftig";
            this.edtPflegebeduerftig.Size = new System.Drawing.Size(120, 19);
            this.edtPflegebeduerftig.TabIndex = 24;
            this.edtPflegebeduerftig.EditValueChanged += new System.EventHandler(this.edtPflegebeduerftig_EditValueChanged);
            //
            // lblVVGZusaetzeRTF
            //
            this.lblVVGZusaetzeRTF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVVGZusaetzeRTF.ForeColor = System.Drawing.Color.Black;
            this.lblVVGZusaetzeRTF.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblVVGZusaetzeRTF.Location = new System.Drawing.Point(425, 170);
            this.lblVVGZusaetzeRTF.Name = "lblVVGZusaetzeRTF";
            this.lblVVGZusaetzeRTF.Size = new System.Drawing.Size(80, 15);
            this.lblVVGZusaetzeRTF.TabIndex = 480;
            this.lblVVGZusaetzeRTF.Text = "Zusätze";
            //
            // lblPflegeDurchCode
            //
            this.lblPflegeDurchCode.ForeColor = System.Drawing.Color.Black;
            this.lblPflegeDurchCode.Location = new System.Drawing.Point(425, 370);
            this.lblPflegeDurchCode.Name = "lblPflegeDurchCode";
            this.lblPflegeDurchCode.Size = new System.Drawing.Size(80, 24);
            this.lblPflegeDurchCode.TabIndex = 481;
            this.lblPflegeDurchCode.Text = "Pflege durch";
            //
            // edtPflegeDurchCode
            //
            this.edtPflegeDurchCode.DataMember = "PflegeDurchCode";
            this.edtPflegeDurchCode.DataSource = this.qryGesundheit;
            this.edtPflegeDurchCode.Location = new System.Drawing.Point(500, 370);
            this.edtPflegeDurchCode.LOVName = "PflegeDurch";
            this.edtPflegeDurchCode.Name = "edtPflegeDurchCode";
            this.edtPflegeDurchCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPflegeDurchCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPflegeDurchCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPflegeDurchCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtPflegeDurchCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPflegeDurchCode.Properties.Appearance.Options.UseFont = true;
            this.edtPflegeDurchCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtPflegeDurchCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtPflegeDurchCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtPflegeDurchCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtPflegeDurchCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtPflegeDurchCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtPflegeDurchCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPflegeDurchCode.Properties.NullText = "";
            this.edtPflegeDurchCode.Properties.ShowFooter = false;
            this.edtPflegeDurchCode.Properties.ShowHeader = false;
            this.edtPflegeDurchCode.Size = new System.Drawing.Size(150, 24);
            this.edtPflegeDurchCode.TabIndex = 25;
            //
            // edtVVGPraemie
            //
            this.edtVVGPraemie.DataMember = "VVGPraemie";
            this.edtVVGPraemie.DataSource = this.qryGesundheit;
            this.edtVVGPraemie.Location = new System.Drawing.Point(425, 291);
            this.edtVVGPraemie.Name = "edtVVGPraemie";
            this.edtVVGPraemie.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVVGPraemie.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVVGPraemie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVVGPraemie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVVGPraemie.Properties.Appearance.Options.UseBackColor = true;
            this.edtVVGPraemie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVVGPraemie.Properties.Appearance.Options.UseFont = true;
            this.edtVVGPraemie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVVGPraemie.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVVGPraemie.Properties.DisplayFormat.FormatString = "N2";
            this.edtVVGPraemie.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVVGPraemie.Properties.NullText = "0.00";
            this.edtVVGPraemie.Size = new System.Drawing.Size(80, 24);
            this.edtVVGPraemie.TabIndex = 20;
            //
            // edtVVGFranchise
            //
            this.edtVVGFranchise.DataMember = "VVGFranchise";
            this.edtVVGFranchise.DataSource = this.qryGesundheit;
            this.edtVVGFranchise.Location = new System.Drawing.Point(425, 321);
            this.edtVVGFranchise.Name = "edtVVGFranchise";
            this.edtVVGFranchise.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVVGFranchise.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVVGFranchise.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVVGFranchise.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVVGFranchise.Properties.Appearance.Options.UseBackColor = true;
            this.edtVVGFranchise.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVVGFranchise.Properties.Appearance.Options.UseFont = true;
            this.edtVVGFranchise.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVVGFranchise.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVVGFranchise.Properties.DisplayFormat.FormatString = "N2";
            this.edtVVGFranchise.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtVVGFranchise.Properties.NullText = "0.00";
            this.edtVVGFranchise.Size = new System.Drawing.Size(80, 24);
            this.edtVVGFranchise.TabIndex = 22;
            //
            // edtKVGZahlungsperiodeCode
            //
            this.edtKVGZahlungsperiodeCode.DataMember = "KVGZahlungsperiodeCode";
            this.edtKVGZahlungsperiodeCode.DataSource = this.qryGesundheit;
            this.edtKVGZahlungsperiodeCode.Location = new System.Drawing.Point(245, 291);
            this.edtKVGZahlungsperiodeCode.LOVName = "ZahlungsPeriode";
            this.edtKVGZahlungsperiodeCode.Name = "edtKVGZahlungsperiodeCode";
            this.edtKVGZahlungsperiodeCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKVGZahlungsperiodeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKVGZahlungsperiodeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGZahlungsperiodeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtKVGZahlungsperiodeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKVGZahlungsperiodeCode.Properties.Appearance.Options.UseFont = true;
            this.edtKVGZahlungsperiodeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKVGZahlungsperiodeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKVGZahlungsperiodeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKVGZahlungsperiodeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKVGZahlungsperiodeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtKVGZahlungsperiodeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtKVGZahlungsperiodeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKVGZahlungsperiodeCode.Properties.NullText = "";
            this.edtKVGZahlungsperiodeCode.Properties.ShowFooter = false;
            this.edtKVGZahlungsperiodeCode.Properties.ShowHeader = false;
            this.edtKVGZahlungsperiodeCode.Size = new System.Drawing.Size(150, 24);
            this.edtKVGZahlungsperiodeCode.TabIndex = 12;
            //
            // edtVVGZahlungsperiodeCode
            //
            this.edtVVGZahlungsperiodeCode.DataMember = "VVGZahlungsperiodeCode";
            this.edtVVGZahlungsperiodeCode.DataSource = this.qryGesundheit;
            this.edtVVGZahlungsperiodeCode.Location = new System.Drawing.Point(555, 291);
            this.edtVVGZahlungsperiodeCode.LOVName = "ZahlungsPeriode";
            this.edtVVGZahlungsperiodeCode.Name = "edtVVGZahlungsperiodeCode";
            this.edtVVGZahlungsperiodeCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVVGZahlungsperiodeCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVVGZahlungsperiodeCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVVGZahlungsperiodeCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtVVGZahlungsperiodeCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVVGZahlungsperiodeCode.Properties.Appearance.Options.UseFont = true;
            this.edtVVGZahlungsperiodeCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtVVGZahlungsperiodeCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtVVGZahlungsperiodeCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtVVGZahlungsperiodeCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtVVGZahlungsperiodeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtVVGZahlungsperiodeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtVVGZahlungsperiodeCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVVGZahlungsperiodeCode.Properties.NullText = "";
            this.edtVVGZahlungsperiodeCode.Properties.ShowFooter = false;
            this.edtVVGZahlungsperiodeCode.Properties.ShowHeader = false;
            this.edtVVGZahlungsperiodeCode.Size = new System.Drawing.Size(150, 24);
            this.edtVVGZahlungsperiodeCode.TabIndex = 21;
            //
            // lblCHFKVGUnfallPraemie
            //
            this.lblCHFKVGUnfallPraemie.ForeColor = System.Drawing.Color.Black;
            this.lblCHFKVGUnfallPraemie.Location = new System.Drawing.Point(200, 192);
            this.lblCHFKVGUnfallPraemie.Name = "lblCHFKVGUnfallPraemie";
            this.lblCHFKVGUnfallPraemie.Size = new System.Drawing.Size(30, 24);
            this.lblCHFKVGUnfallPraemie.TabIndex = 487;
            this.lblCHFKVGUnfallPraemie.Text = "CHF";
            //
            // lblCHFKVGGesundFoerdPraemie
            //
            this.lblCHFKVGGesundFoerdPraemie.ForeColor = System.Drawing.Color.Black;
            this.lblCHFKVGGesundFoerdPraemie.Location = new System.Drawing.Point(200, 215);
            this.lblCHFKVGGesundFoerdPraemie.Name = "lblCHFKVGGesundFoerdPraemie";
            this.lblCHFKVGGesundFoerdPraemie.Size = new System.Drawing.Size(30, 24);
            this.lblCHFKVGGesundFoerdPraemie.TabIndex = 488;
            this.lblCHFKVGGesundFoerdPraemie.Text = "CHF";
            //
            // lblCHFKVGGrundpraemie
            //
            this.lblCHFKVGGrundpraemie.ForeColor = System.Drawing.Color.Black;
            this.lblCHFKVGGrundpraemie.Location = new System.Drawing.Point(200, 169);
            this.lblCHFKVGGrundpraemie.Name = "lblCHFKVGGrundpraemie";
            this.lblCHFKVGGrundpraemie.Size = new System.Drawing.Size(30, 24);
            this.lblCHFKVGGrundpraemie.TabIndex = 489;
            this.lblCHFKVGGrundpraemie.Text = "CHF";
            //
            // lblCHFKVGZuschussBetrag
            //
            this.lblCHFKVGZuschussBetrag.ForeColor = System.Drawing.Color.Black;
            this.lblCHFKVGZuschussBetrag.Location = new System.Drawing.Point(200, 238);
            this.lblCHFKVGZuschussBetrag.Name = "lblCHFKVGZuschussBetrag";
            this.lblCHFKVGZuschussBetrag.Size = new System.Drawing.Size(30, 24);
            this.lblCHFKVGZuschussBetrag.TabIndex = 490;
            this.lblCHFKVGZuschussBetrag.Text = "CHF";
            //
            // lblCHFKVGUmweltabgabeBetrag
            //
            this.lblCHFKVGUmweltabgabeBetrag.ForeColor = System.Drawing.Color.Black;
            this.lblCHFKVGUmweltabgabeBetrag.Location = new System.Drawing.Point(200, 261);
            this.lblCHFKVGUmweltabgabeBetrag.Name = "lblCHFKVGUmweltabgabeBetrag";
            this.lblCHFKVGUmweltabgabeBetrag.Size = new System.Drawing.Size(30, 24);
            this.lblCHFKVGUmweltabgabeBetrag.TabIndex = 491;
            this.lblCHFKVGUmweltabgabeBetrag.Text = "CHF";
            //
            // lblCHFKVGPraemie
            //
            this.lblCHFKVGPraemie.ForeColor = System.Drawing.Color.Black;
            this.lblCHFKVGPraemie.Location = new System.Drawing.Point(200, 291);
            this.lblCHFKVGPraemie.Name = "lblCHFKVGPraemie";
            this.lblCHFKVGPraemie.Size = new System.Drawing.Size(30, 24);
            this.lblCHFKVGPraemie.TabIndex = 492;
            this.lblCHFKVGPraemie.Text = "CHF";
            //
            // lblCHFKVGFranchise
            //
            this.lblCHFKVGFranchise.ForeColor = System.Drawing.Color.Black;
            this.lblCHFKVGFranchise.Location = new System.Drawing.Point(200, 321);
            this.lblCHFKVGFranchise.Name = "lblCHFKVGFranchise";
            this.lblCHFKVGFranchise.Size = new System.Drawing.Size(30, 24);
            this.lblCHFKVGFranchise.TabIndex = 493;
            this.lblCHFKVGFranchise.Text = "CHF";
            //
            // lblCHFVVGPraemie
            //
            this.lblCHFVVGPraemie.ForeColor = System.Drawing.Color.Black;
            this.lblCHFVVGPraemie.Location = new System.Drawing.Point(515, 291);
            this.lblCHFVVGPraemie.Name = "lblCHFVVGPraemie";
            this.lblCHFVVGPraemie.Size = new System.Drawing.Size(30, 24);
            this.lblCHFVVGPraemie.TabIndex = 494;
            this.lblCHFVVGPraemie.Text = "CHF";
            //
            // lblCHFVVGFranchise
            //
            this.lblCHFVVGFranchise.ForeColor = System.Drawing.Color.Black;
            this.lblCHFVVGFranchise.Location = new System.Drawing.Point(515, 321);
            this.lblCHFVVGFranchise.Name = "lblCHFVVGFranchise";
            this.lblCHFVVGFranchise.Size = new System.Drawing.Size(30, 24);
            this.lblCHFVVGFranchise.TabIndex = 495;
            this.lblCHFVVGFranchise.Text = "CHF";
            //
            // lblIVEingliederungsmassnahmeCode
            //
            this.lblIVEingliederungsmassnahmeCode.ForeColor = System.Drawing.Color.Black;
            this.lblIVEingliederungsmassnahmeCode.Location = new System.Drawing.Point(5, 370);
            this.lblIVEingliederungsmassnahmeCode.Name = "lblIVEingliederungsmassnahmeCode";
            this.lblIVEingliederungsmassnahmeCode.Size = new System.Drawing.Size(103, 24);
            this.lblIVEingliederungsmassnahmeCode.TabIndex = 496;
            this.lblIVEingliederungsmassnahmeCode.Text = "IV-Eingliederung";
            //
            // panel2
            //
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(0, 355);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(720, 1);
            this.panel2.TabIndex = 497;
            //
            // lblPlusKVGGesundFoerdPraemie
            //
            this.lblPlusKVGGesundFoerdPraemie.ForeColor = System.Drawing.Color.Black;
            this.lblPlusKVGGesundFoerdPraemie.Location = new System.Drawing.Point(100, 215);
            this.lblPlusKVGGesundFoerdPraemie.Name = "lblPlusKVGGesundFoerdPraemie";
            this.lblPlusKVGGesundFoerdPraemie.Size = new System.Drawing.Size(10, 24);
            this.lblPlusKVGGesundFoerdPraemie.TabIndex = 498;
            this.lblPlusKVGGesundFoerdPraemie.Text = "+";
            //
            // lblMinusKVGZuschussBetrag
            //
            this.lblMinusKVGZuschussBetrag.ForeColor = System.Drawing.Color.Black;
            this.lblMinusKVGZuschussBetrag.Location = new System.Drawing.Point(100, 238);
            this.lblMinusKVGZuschussBetrag.Name = "lblMinusKVGZuschussBetrag";
            this.lblMinusKVGZuschussBetrag.Size = new System.Drawing.Size(10, 24);
            this.lblMinusKVGZuschussBetrag.TabIndex = 499;
            this.lblMinusKVGZuschussBetrag.Text = "-";
            //
            // lblPlusKVGUnfallPraemie
            //
            this.lblPlusKVGUnfallPraemie.ForeColor = System.Drawing.Color.Black;
            this.lblPlusKVGUnfallPraemie.Location = new System.Drawing.Point(100, 192);
            this.lblPlusKVGUnfallPraemie.Name = "lblPlusKVGUnfallPraemie";
            this.lblPlusKVGUnfallPraemie.Size = new System.Drawing.Size(10, 24);
            this.lblPlusKVGUnfallPraemie.TabIndex = 500;
            this.lblPlusKVGUnfallPraemie.Text = "+";
            //
            // lblPlusKVGGrundpraemie
            //
            this.lblPlusKVGGrundpraemie.ForeColor = System.Drawing.Color.Black;
            this.lblPlusKVGGrundpraemie.Location = new System.Drawing.Point(100, 169);
            this.lblPlusKVGGrundpraemie.Name = "lblPlusKVGGrundpraemie";
            this.lblPlusKVGGrundpraemie.Size = new System.Drawing.Size(10, 24);
            this.lblPlusKVGGrundpraemie.TabIndex = 501;
            this.lblPlusKVGGrundpraemie.Text = "+";
            //
            // lblMinusKVGUmweltabgabeBetrag
            //
            this.lblMinusKVGUmweltabgabeBetrag.ForeColor = System.Drawing.Color.Black;
            this.lblMinusKVGUmweltabgabeBetrag.Location = new System.Drawing.Point(100, 261);
            this.lblMinusKVGUmweltabgabeBetrag.Name = "lblMinusKVGUmweltabgabeBetrag";
            this.lblMinusKVGUmweltabgabeBetrag.Size = new System.Drawing.Size(10, 24);
            this.lblMinusKVGUmweltabgabeBetrag.TabIndex = 502;
            this.lblMinusKVGUmweltabgabeBetrag.Text = "-";
            //
            // lblGleichKVGPraemie
            //
            this.lblGleichKVGPraemie.ForeColor = System.Drawing.Color.Black;
            this.lblGleichKVGPraemie.Location = new System.Drawing.Point(98, 291);
            this.lblGleichKVGPraemie.Name = "lblGleichKVGPraemie";
            this.lblGleichKVGPraemie.Size = new System.Drawing.Size(10, 24);
            this.lblGleichKVGPraemie.TabIndex = 503;
            this.lblGleichKVGPraemie.Text = "=";
            //
            // btnVerbuchen
            //
            this.btnVerbuchen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVerbuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerbuchen.Location = new System.Drawing.Point(245, 321);
            this.btnVerbuchen.Name = "btnVerbuchen";
            this.btnVerbuchen.Size = new System.Drawing.Size(123, 24);
            this.btnVerbuchen.TabIndex = 504;
            this.btnVerbuchen.Text = "Prämie berechnen";
            this.btnVerbuchen.UseVisualStyleBackColor = false;
            this.btnVerbuchen.Click += new System.EventHandler(this.btnVerbuchen_Click);
            //
            // edtASVSAnmeldung
            //
            this.edtASVSAnmeldung.DataMember = "ASVSAnmeldung";
            this.edtASVSAnmeldung.DataSource = this.qryGesundheit;
            this.edtASVSAnmeldung.EditValue = null;
            this.edtASVSAnmeldung.Location = new System.Drawing.Point(115, 400);
            this.edtASVSAnmeldung.Name = "edtASVSAnmeldung";
            this.edtASVSAnmeldung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtASVSAnmeldung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtASVSAnmeldung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtASVSAnmeldung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtASVSAnmeldung.Properties.Appearance.Options.UseBackColor = true;
            this.edtASVSAnmeldung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtASVSAnmeldung.Properties.Appearance.Options.UseFont = true;
            this.edtASVSAnmeldung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtASVSAnmeldung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtASVSAnmeldung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtASVSAnmeldung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtASVSAnmeldung.Properties.ShowToday = false;
            this.edtASVSAnmeldung.Size = new System.Drawing.Size(110, 24);
            this.edtASVSAnmeldung.TabIndex = 505;
            this.edtASVSAnmeldung.Visible = false;
            //
            // lblASVSAn
            //
            this.lblASVSAn.ForeColor = System.Drawing.Color.Black;
            this.lblASVSAn.Location = new System.Drawing.Point(5, 400);
            this.lblASVSAn.Name = "lblASVSAn";
            this.lblASVSAn.Size = new System.Drawing.Size(103, 24);
            this.lblASVSAn.TabIndex = 506;
            this.lblASVSAn.Text = "ASV Anmeldung";
            this.lblASVSAn.Visible = false;
            //
            // lblASVSAb
            //
            this.lblASVSAb.ForeColor = System.Drawing.Color.Black;
            this.lblASVSAb.Location = new System.Drawing.Point(5, 430);
            this.lblASVSAb.Name = "lblASVSAb";
            this.lblASVSAb.Size = new System.Drawing.Size(103, 24);
            this.lblASVSAb.TabIndex = 508;
            this.lblASVSAb.Text = "ASV Abmeldung";
            this.lblASVSAb.Visible = false;
            //
            // edtASVSAbmeldung
            //
            this.edtASVSAbmeldung.DataMember = "ASVSAbmeldung";
            this.edtASVSAbmeldung.DataSource = this.qryGesundheit;
            this.edtASVSAbmeldung.EditValue = null;
            this.edtASVSAbmeldung.Location = new System.Drawing.Point(115, 430);
            this.edtASVSAbmeldung.Name = "edtASVSAbmeldung";
            this.edtASVSAbmeldung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtASVSAbmeldung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtASVSAbmeldung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtASVSAbmeldung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtASVSAbmeldung.Properties.Appearance.Options.UseBackColor = true;
            this.edtASVSAbmeldung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtASVSAbmeldung.Properties.Appearance.Options.UseFont = true;
            this.edtASVSAbmeldung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtASVSAbmeldung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtASVSAbmeldung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtASVSAbmeldung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtASVSAbmeldung.Properties.ShowToday = false;
            this.edtASVSAbmeldung.Size = new System.Drawing.Size(110, 24);
            this.edtASVSAbmeldung.TabIndex = 507;
            this.edtASVSAbmeldung.Visible = false;
            //
            // edtEVAZDatum
            //
            this.edtEVAZDatum.DataMember = "EVAZDatum";
            this.edtEVAZDatum.DataSource = this.qryGesundheit;
            this.edtEVAZDatum.EditValue = null;
            this.edtEVAZDatum.Location = new System.Drawing.Point(500, 400);
            this.edtEVAZDatum.Name = "edtEVAZDatum";
            this.edtEVAZDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEVAZDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEVAZDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEVAZDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEVAZDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtEVAZDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEVAZDatum.Properties.Appearance.Options.UseFont = true;
            this.edtEVAZDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtEVAZDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEVAZDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtEVAZDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEVAZDatum.Properties.ShowToday = false;
            this.edtEVAZDatum.Size = new System.Drawing.Size(110, 24);
            this.edtEVAZDatum.TabIndex = 509;
            //
            // edtZahnarztBaInstitutionID
            //
            this.edtZahnarztBaInstitutionID.DataMember = "ZahnarztInstitution";
            this.edtZahnarztBaInstitutionID.DataSource = this.qryGesundheit;
            this.edtZahnarztBaInstitutionID.Location = new System.Drawing.Point(500, 430);
            this.edtZahnarztBaInstitutionID.Name = "edtZahnarztBaInstitutionID";
            this.edtZahnarztBaInstitutionID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZahnarztBaInstitutionID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZahnarztBaInstitutionID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahnarztBaInstitutionID.Properties.Appearance.Options.UseBackColor = true;
            this.edtZahnarztBaInstitutionID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZahnarztBaInstitutionID.Properties.Appearance.Options.UseFont = true;
            this.edtZahnarztBaInstitutionID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtZahnarztBaInstitutionID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtZahnarztBaInstitutionID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZahnarztBaInstitutionID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtZahnarztBaInstitutionID.Size = new System.Drawing.Size(210, 24);
            this.edtZahnarztBaInstitutionID.TabIndex = 510;
            this.edtZahnarztBaInstitutionID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtZahnarztBaInstitutionID_UserModifiedFld);
            //
            // lblEVAZDatum
            //
            this.lblEVAZDatum.ForeColor = System.Drawing.Color.Black;
            this.lblEVAZDatum.Location = new System.Drawing.Point(425, 400);
            this.lblEVAZDatum.Name = "lblEVAZDatum";
            this.lblEVAZDatum.Size = new System.Drawing.Size(80, 24);
            this.lblEVAZDatum.TabIndex = 511;
            this.lblEVAZDatum.Text = "EVAZ Datum";
            //
            // lblZahnarztBaInstitutionID
            //
            this.lblZahnarztBaInstitutionID.ForeColor = System.Drawing.Color.Black;
            this.lblZahnarztBaInstitutionID.Location = new System.Drawing.Point(425, 430);
            this.lblZahnarztBaInstitutionID.Name = "lblZahnarztBaInstitutionID";
            this.lblZahnarztBaInstitutionID.Size = new System.Drawing.Size(80, 24);
            this.lblZahnarztBaInstitutionID.TabIndex = 512;
            this.lblZahnarztBaInstitutionID.Text = "Zahnarzt";
            //
            // CtlGesundheit
            //
            this.ActiveSQLQuery = this.qryGesundheit;
            this.Controls.Add(this.edtZahnarztBaInstitutionID);
            this.Controls.Add(this.edtEVAZDatum);
            this.Controls.Add(this.lblZahnarztBaInstitutionID);
            this.Controls.Add(this.lblEVAZDatum);
            this.Controls.Add(this.lblASVSAb);
            this.Controls.Add(this.edtASVSAbmeldung);
            this.Controls.Add(this.lblASVSAn);
            this.Controls.Add(this.edtASVSAnmeldung);
            this.Controls.Add(this.btnVerbuchen);
            this.Controls.Add(this.lblGleichKVGPraemie);
            this.Controls.Add(this.lblMinusKVGUmweltabgabeBetrag);
            this.Controls.Add(this.lblPlusKVGGrundpraemie);
            this.Controls.Add(this.lblPlusKVGUnfallPraemie);
            this.Controls.Add(this.lblMinusKVGZuschussBetrag);
            this.Controls.Add(this.lblPlusKVGGesundFoerdPraemie);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblIVEingliederungsmassnahmeCode);
            this.Controls.Add(this.lblCHFVVGFranchise);
            this.Controls.Add(this.lblCHFVVGPraemie);
            this.Controls.Add(this.lblCHFKVGFranchise);
            this.Controls.Add(this.lblCHFKVGPraemie);
            this.Controls.Add(this.lblCHFKVGUmweltabgabeBetrag);
            this.Controls.Add(this.lblCHFKVGZuschussBetrag);
            this.Controls.Add(this.lblCHFKVGGrundpraemie);
            this.Controls.Add(this.lblCHFKVGGesundFoerdPraemie);
            this.Controls.Add(this.lblCHFKVGUnfallPraemie);
            this.Controls.Add(this.edtVVGZahlungsperiodeCode);
            this.Controls.Add(this.edtKVGZahlungsperiodeCode);
            this.Controls.Add(this.edtVVGFranchise);
            this.Controls.Add(this.edtVVGPraemie);
            this.Controls.Add(this.edtPflegeDurchCode);
            this.Controls.Add(this.lblPflegeDurchCode);
            this.Controls.Add(this.lblVVGZusaetzeRTF);
            this.Controls.Add(this.edtPflegebeduerftig);
            this.Controls.Add(this.edtZuschussInAbklaerungFlag);
            this.Controls.Add(this.edtIVEingliederungsmassnahmeCode);
            this.Controls.Add(this.lblKVGUnfallPraemie);
            this.Controls.Add(this.lblKVGGesundFoerdPraemie);
            this.Controls.Add(this.lblKVGZuschussBetrag);
            this.Controls.Add(this.edtVVGZusaetzeRTF);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.edtKVGUnfallPraemie);
            this.Controls.Add(this.edtKVGGesundheit);
            this.Controls.Add(this.edtKVGZuschussBetrag);
            this.Controls.Add(this.edtKVGUmweltabgabe);
            this.Controls.Add(this.edtKVGPraemie);
            this.Controls.Add(this.edtKVGFranchise);
            this.Controls.Add(this.edtKVGGrundpraemie);
            this.Controls.Add(this.edtVVGVersichertSeit);
            this.Controls.Add(this.edtKVGVersichertSeit);
            this.Controls.Add(this.edtVVGMitgliedNr);
            this.Controls.Add(this.edtKVGMitgliedNr);
            this.Controls.Add(this.edtVVGKontaktTelefon);
            this.Controls.Add(this.edtKVGKontaktTelefon);
            this.Controls.Add(this.edtVVGKontaktperson);
            this.Controls.Add(this.edtKVGKontaktperson);
            this.Controls.Add(this.lblKVGKontaktperson);
            this.Controls.Add(this.lblKVGKontaktTelefon);
            this.Controls.Add(this.lblKVGMitgliedNr);
            this.Controls.Add(this.lblKVGVersichertSeit);
            this.Controls.Add(this.lblKVGUmweltabgabeBetrag);
            this.Controls.Add(this.lblKVGGrundpraemie);
            this.Controls.Add(this.lblKVGPraemie);
            this.Controls.Add(this.lblKVGFranchise);
            this.Controls.Add(this.edtVVGInstitution);
            this.Controls.Add(this.edtKVGInstitution);
            this.Controls.Add(this.lblKVGInstitution);
            this.Controls.Add(this.panel1);
            this.Name = "CtlGesundheit";
            this.Size = new System.Drawing.Size(719, 622);
            ((System.ComponentModel.ISupportInitialize)(this.qryGesundheit)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblVVG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGInstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGFranchise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGPraemie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGGrundpraemie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGUmweltabgabeBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGVersichertSeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGMitgliedNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGKontaktTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGKontaktperson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGKontaktperson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGKontaktperson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGKontaktTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGKontaktTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGMitgliedNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGMitgliedNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGVersichertSeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGVersichertSeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGGrundpraemie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGFranchise.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGPraemie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGUmweltabgabe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGZuschussBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGGesundheit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGUnfallPraemie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGZuschussBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGGesundFoerdPraemie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKVGUnfallPraemie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIVEingliederungsmassnahmeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIVEingliederungsmassnahmeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuschussInAbklaerungFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPflegebeduerftig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVVGZusaetzeRTF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPflegeDurchCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPflegeDurchCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPflegeDurchCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGPraemie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGFranchise.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGZahlungsperiodeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKVGZahlungsperiodeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGZahlungsperiodeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVVGZahlungsperiodeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFKVGUnfallPraemie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFKVGGesundFoerdPraemie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFKVGGrundpraemie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFKVGZuschussBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFKVGUmweltabgabeBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFKVGPraemie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFKVGFranchise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFVVGPraemie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHFVVGFranchise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIVEingliederungsmassnahmeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlusKVGGesundFoerdPraemie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMinusKVGZuschussBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlusKVGUnfallPraemie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlusKVGGrundpraemie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMinusKVGUmweltabgabeBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGleichKVGPraemie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtASVSAnmeldung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblASVSAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblASVSAb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtASVSAbmeldung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEVAZDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahnarztBaInstitutionID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEVAZDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahnarztBaInstitutionID)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private void btnVerbuchen_Click(object sender, System.EventArgs e)
        {
            SetPraemie();
        }

        private void edtKVGInstitution_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            if (dlg.InstitutionSuchen(edtKVGInstitution.Text, true, e.ButtonClicked))
            {
                qryGesundheit["KVGInstitution"] = dlg["Name"];
                qryGesundheit["KVGOrganisationID"] = dlg["BaInstitutionID"];
            }
            else
                e.Cancel = true;
        }

        private void edtPflegebeduerftig_EditValueChanged(object sender, System.EventArgs e)
        {
            if (this.edtPflegebeduerftig.EditValue != null)
            {
                ((IKissBindableEdit)edtPflegeDurchCode).AllowEdit(this.edtPflegebeduerftig.Checked && qryGesundheit.CanUpdate);
            }
        }

        private void edtVVGInstitution_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            if (dlg.InstitutionSuchen(edtVVGInstitution.Text, true, e.ButtonClicked))
            {
                qryGesundheit["VVGInstitution"] = dlg["Name"];
                qryGesundheit["VVGOrganisationID"] = dlg["BaInstitutionID"];
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void edtZahnarztBaInstitutionID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            if (dlg.InstitutionSuchen(edtZahnarztBaInstitutionID.Text, true, e.ButtonClicked))
            {
                qryGesundheit["ZahnarztInstitution"] = dlg["Name"];
                qryGesundheit["ZahnarztBaInstitutionID"] = dlg["BaInstitutionID"];
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void edtZuschussInAbklaerungFlag_EditValueChanged(object sender, System.EventArgs e)
        {
            if (this.edtZuschussInAbklaerungFlag.EditValue != null)
            {
                ((IKissBindableEdit)this.edtKVGZuschussBetrag).AllowEdit(!this.edtZuschussInAbklaerungFlag.Checked && qryGesundheit.CanUpdate);
            }
        }

        private void Praemie_Leave(object sender, System.EventArgs e)
        {
            SetPraemie();
        }

        private void qryGesundheit_AfterFill(object sender, System.EventArgs e)
        {
            if (this.ActiveSQLQuery.CanUpdate && this.ActiveSQLQuery.Count == 0)
                this.ActiveSQLQuery.Insert(this.ActiveSQLQuery.TableName);
        }

        private void qryGesundheit_AfterInsert(object sender, System.EventArgs e)
        {
            qryGesundheit["BaPersonID"] = BaPersonID;
        }

        private void SetPraemie()
        {
            Control c = this.ActiveControl;

            if (edtZuschussInAbklaerungFlag.Checked)
            {
                this.edtKVGPraemie.Text = Convert.ToString(Convert.ToDecimal(this.edtKVGGrundpraemie.Text == "" ? "0.00" : this.edtKVGGrundpraemie.Text) + Convert.ToDecimal(this.edtKVGUnfallPraemie.Text == "" ? "0.00" : this.edtKVGUnfallPraemie.Text) + Convert.ToDecimal(this.edtKVGGesundheit.Text == "" ? "0.00" : this.edtKVGGesundheit.Text) - Convert.ToDecimal(this.edtKVGUmweltabgabe.Text == "" ? "0.00" : this.edtKVGUmweltabgabe.Text));
            }
            else
            {
                this.edtKVGPraemie.Text = Convert.ToString(Convert.ToDecimal(this.edtKVGGrundpraemie.Text == "" ? "0.00" : this.edtKVGGrundpraemie.Text) + Convert.ToDecimal(this.edtKVGUnfallPraemie.Text == "" ? "0.00" : this.edtKVGUnfallPraemie.Text) + Convert.ToDecimal(this.edtKVGGesundheit.Text == "" ? "0.00" : this.edtKVGGesundheit.Text) - Convert.ToDecimal(this.edtKVGUmweltabgabe.Text == "" ? "0.00" : this.edtKVGUmweltabgabe.Text) - Convert.ToDecimal(this.edtKVGZuschussBetrag.Text == "" ? "0.00" : this.edtKVGZuschussBetrag.Text));
            }

            this.edtKVGPraemie.Focus();

            if (c != null)
            {
                c.Focus();
            }
        }
    }
}