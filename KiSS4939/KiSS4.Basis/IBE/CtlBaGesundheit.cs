using System;
using System.Drawing;

using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

/*
 * ck: Bei IBE korrekt CtlBaGesundheit, in Bern falsch CtlGesundheit! --> umbenennen!
 * deshalb im seperatem Namespace...
 */
namespace KiSS4.Basis.IBE
{
    public class CtlBaGesundheit : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// The BaInstitutionTypID for 'Krankenkasse' type
        /// </summary>
        private const int BAINSTITUTIONTYPID_KK = 4;

        #endregion

        #region Private Fields

        // Letzte Bearbeitung
        // 27.09.2007 : RH : alles neu
        // ------------------------------------------------------------------------------
        private int BaPersonID = 0;
        private KiSS4.Gui.KissButton btnBerechnen;
        private KiSS4.Gui.KissLookUpEdit cboEingliederungsmassnahme;
        private KiSS4.Gui.KissLookUpEdit cboKVGZahlungsPeriode;
        private KiSS4.Gui.KissLookUpEdit cboPflegeDurch;
        private KiSS4.Gui.KissCheckEdit chkAbtretungKK;
        private KiSS4.Gui.KissCheckEdit chkKVGZuschussUnregelmaessig;
        private KiSS4.Gui.KissCheckEdit chkPflegebeduerftig;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit dtpKVGVersichertSeit;
        private KiSS4.Gui.KissDateEdit editASVSAbmeldung;
        private KiSS4.Gui.KissDateEdit editASVSAnmeldung;
        private KiSS4.Gui.KissRTFEdit editBemerkungRTF;
        private KiSS4.Gui.KissCalcEdit editKVGFranchise;
        private KiSS4.Gui.KissCalcEdit editKVGGesundheit;
        private KiSS4.Gui.KissCalcEdit editKVGGrundPraemie;
        private KiSS4.Gui.KissTextEdit editKVGKontaktPerson;
        private KiSS4.Gui.KissTextEdit editKVGKontaktTelefon;
        private KiSS4.Gui.KissButtonEdit editKVGKrankenKasse;
        private KiSS4.Gui.KissTextEdit editKVGMitgliedNr;
        private KiSS4.Gui.KissCalcEdit editKVGPraemie;
        private KiSS4.Gui.KissCalcEdit editKVGUmweltabgabe;
        private KiSS4.Gui.KissCalcEdit editKVGUnfall;
        private KiSS4.Gui.KissCalcEdit editKVGZuschussBetrag;
        private KiSS4.Gui.KissCalcEdit editVVGFranchise;
        private KiSS4.Gui.KissTextEdit editVVGKontaktPerson;
        private KiSS4.Gui.KissTextEdit editVVGKontaktTelefon;
        private KiSS4.Gui.KissTextEdit editVVGMitgliedNr;
        private KiSS4.Gui.KissButtonEdit editVVGOrganisation;
        private KiSS4.Gui.KissCalcEdit editVVGPraemie;
        private KiSS4.Gui.KissDateEdit editVVGVersicherung;
        private KiSS4.Gui.KissLookUpEdit editVVGZahlungsperiode;
        private KiSS4.Gui.KissRTFEdit editVVGZusaetzeRTF;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel13;
        private KiSS4.Gui.KissLabel kissLabel14;
        private KiSS4.Gui.KissLabel kissLabel15;
        private KiSS4.Gui.KissLabel kissLabel16;
        private KiSS4.Gui.KissLabel kissLabel17;
        private KiSS4.Gui.KissLabel kissLabel18;
        private KiSS4.Gui.KissLabel kissLabel19;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel20;
        private KiSS4.Gui.KissLabel kissLabel21;
        private KiSS4.Gui.KissLabel kissLabel22;
        private KiSS4.Gui.KissLabel kissLabel23;
        private KiSS4.Gui.KissLabel kissLabel24;
        private KiSS4.Gui.KissLabel kissLabel25;
        private KiSS4.Gui.KissLabel kissLabel26;
        private KiSS4.Gui.KissLabel kissLabel27;
        private KiSS4.Gui.KissLabel kissLabel28;
        private KiSS4.Gui.KissLabel kissLabel29;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel30;
        private KiSS4.Gui.KissLabel kissLabel31;
        private KiSS4.Gui.KissLabel kissLabel32;
        private KiSS4.Gui.KissLabel kissLabel33;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissLabel kissLabel9;

        // ASVS: wird neu in einer separaten Maske geführt. Kann entfernt werden, sobald sicher ist das jeder Kunde die neue Maske verwendet
        private KiSS4.Gui.KissLabel lblASVSAb;
        private KiSS4.Gui.KissLabel lblASVSAn;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryGesundheit;

        #endregion

        #endregion

        #region Constructors

        // Letzte Bearbeitung
        // 27.09.2007 : RH : alles neu
        // ------------------------------------------------------------------------------
        public CtlBaGesundheit()
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaGesundheit));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.editKVGKrankenKasse = new KiSS4.Gui.KissButtonEdit();
            this.qryGesundheit = new KiSS4.DB.SqlQuery(this.components);
            this.editKVGKontaktPerson = new KiSS4.Gui.KissTextEdit();
            this.editKVGKontaktTelefon = new KiSS4.Gui.KissTextEdit();
            this.editKVGMitgliedNr = new KiSS4.Gui.KissTextEdit();
            this.dtpKVGVersichertSeit = new KiSS4.Gui.KissDateEdit();
            this.editKVGGrundPraemie = new KiSS4.Gui.KissCalcEdit();
            this.editKVGUnfall = new KiSS4.Gui.KissCalcEdit();
            this.editKVGGesundheit = new KiSS4.Gui.KissCalcEdit();
            this.editKVGZuschussBetrag = new KiSS4.Gui.KissCalcEdit();
            this.chkKVGZuschussUnregelmaessig = new KiSS4.Gui.KissCheckEdit();
            this.editKVGUmweltabgabe = new KiSS4.Gui.KissCalcEdit();
            this.editKVGPraemie = new KiSS4.Gui.KissCalcEdit();
            this.cboKVGZahlungsPeriode = new KiSS4.Gui.KissLookUpEdit();
            this.editKVGFranchise = new KiSS4.Gui.KissCalcEdit();
            this.editVVGOrganisation = new KiSS4.Gui.KissButtonEdit();
            this.editVVGKontaktPerson = new KiSS4.Gui.KissTextEdit();
            this.editVVGKontaktTelefon = new KiSS4.Gui.KissTextEdit();
            this.editVVGMitgliedNr = new KiSS4.Gui.KissTextEdit();
            this.editVVGVersicherung = new KiSS4.Gui.KissDateEdit();
            this.editVVGZusaetzeRTF = new KiSS4.Gui.KissRTFEdit();
            this.editVVGPraemie = new KiSS4.Gui.KissCalcEdit();
            this.editVVGZahlungsperiode = new KiSS4.Gui.KissLookUpEdit();
            this.editVVGFranchise = new KiSS4.Gui.KissCalcEdit();
            this.cboEingliederungsmassnahme = new KiSS4.Gui.KissLookUpEdit();
            this.chkPflegebeduerftig = new KiSS4.Gui.KissCheckEdit();
            this.cboPflegeDurch = new KiSS4.Gui.KissLookUpEdit();
            this.editBemerkungRTF = new KiSS4.Gui.KissRTFEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.kissLabel17 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.kissLabel13 = new KiSS4.Gui.KissLabel();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.kissLabel15 = new KiSS4.Gui.KissLabel();
            this.kissLabel16 = new KiSS4.Gui.KissLabel();
            this.kissLabel18 = new KiSS4.Gui.KissLabel();
            this.kissLabel19 = new KiSS4.Gui.KissLabel();
            this.kissLabel20 = new KiSS4.Gui.KissLabel();
            this.kissLabel21 = new KiSS4.Gui.KissLabel();
            this.kissLabel22 = new KiSS4.Gui.KissLabel();
            this.kissLabel23 = new KiSS4.Gui.KissLabel();
            this.kissLabel24 = new KiSS4.Gui.KissLabel();
            this.kissLabel25 = new KiSS4.Gui.KissLabel();
            this.kissLabel26 = new KiSS4.Gui.KissLabel();
            this.kissLabel27 = new KiSS4.Gui.KissLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.kissLabel28 = new KiSS4.Gui.KissLabel();
            this.kissLabel29 = new KiSS4.Gui.KissLabel();
            this.kissLabel30 = new KiSS4.Gui.KissLabel();
            this.kissLabel31 = new KiSS4.Gui.KissLabel();
            this.kissLabel32 = new KiSS4.Gui.KissLabel();
            this.kissLabel33 = new KiSS4.Gui.KissLabel();
            this.btnBerechnen = new KiSS4.Gui.KissButton();
            this.editASVSAnmeldung = new KiSS4.Gui.KissDateEdit();
            this.lblASVSAn = new KiSS4.Gui.KissLabel();
            this.editASVSAbmeldung = new KiSS4.Gui.KissDateEdit();
            this.lblASVSAb = new KiSS4.Gui.KissLabel();
            this.chkAbtretungKK = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGKrankenKasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGesundheit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGKontaktPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGKontaktTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGMitgliedNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpKVGVersichertSeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGGrundPraemie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGUnfall.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGGesundheit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGZuschussBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKVGZuschussUnregelmaessig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGUmweltabgabe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGPraemie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKVGZahlungsPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKVGZahlungsPeriode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGFranchise.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGOrganisation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGKontaktPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGKontaktTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGMitgliedNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGVersicherung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGPraemie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGZahlungsperiode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGZahlungsperiode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGFranchise.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEingliederungsmassnahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEingliederungsmassnahme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPflegebeduerftig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPflegeDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPflegeDurch.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editASVSAnmeldung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblASVSAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editASVSAbmeldung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblASVSAb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbtretungKK.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // editKVGKrankenKasse
            //
            this.editKVGKrankenKasse.DataMember = "KVGOrganisation";
            this.editKVGKrankenKasse.DataSource = this.qryGesundheit;
            this.editKVGKrankenKasse.Location = new System.Drawing.Point(115, 40);
            this.editKVGKrankenKasse.Name = "editKVGKrankenKasse";
            this.editKVGKrankenKasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editKVGKrankenKasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKVGKrankenKasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKVGKrankenKasse.Properties.Appearance.Options.UseBackColor = true;
            this.editKVGKrankenKasse.Properties.Appearance.Options.UseBorderColor = true;
            this.editKVGKrankenKasse.Properties.Appearance.Options.UseFont = true;
            this.editKVGKrankenKasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.editKVGKrankenKasse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.editKVGKrankenKasse.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editKVGKrankenKasse.Size = new System.Drawing.Size(285, 24);
            this.editKVGKrankenKasse.TabIndex = 0;
            this.editKVGKrankenKasse.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editKVGKrankenKasse_UserModifiedFld);
            //
            // qryGesundheit
            //
            this.qryGesundheit.CanUpdate = true;
            this.qryGesundheit.HostControl = this;
            this.qryGesundheit.SelectStatement = resources.GetString("qryGesundheit.SelectStatement");
            this.qryGesundheit.TableName = "BaGesundheit";
            this.qryGesundheit.BeforePost += new System.EventHandler(this.qryGesundheit_BeforePost);
            this.qryGesundheit.PositionChanged += new System.EventHandler(this.qryGesundheit_PositionChanged);
            this.qryGesundheit.AfterFill += new System.EventHandler(this.qryGesundheit_AfterFill);
            this.qryGesundheit.AfterInsert += new System.EventHandler(this.qryGesundheit_AfterInsert);
            //
            // editKVGKontaktPerson
            //
            this.editKVGKontaktPerson.DataMember = "KVGKontaktperson";
            this.editKVGKontaktPerson.DataSource = this.qryGesundheit;
            this.editKVGKontaktPerson.Location = new System.Drawing.Point(115, 63);
            this.editKVGKontaktPerson.Name = "editKVGKontaktPerson";
            this.editKVGKontaktPerson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editKVGKontaktPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKVGKontaktPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKVGKontaktPerson.Properties.Appearance.Options.UseBackColor = true;
            this.editKVGKontaktPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.editKVGKontaktPerson.Properties.Appearance.Options.UseFont = true;
            this.editKVGKontaktPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editKVGKontaktPerson.Size = new System.Drawing.Size(285, 24);
            this.editKVGKontaktPerson.TabIndex = 1;
            //
            // editKVGKontaktTelefon
            //
            this.editKVGKontaktTelefon.DataMember = "KVGKontaktTelefon";
            this.editKVGKontaktTelefon.DataSource = this.qryGesundheit;
            this.editKVGKontaktTelefon.Location = new System.Drawing.Point(115, 86);
            this.editKVGKontaktTelefon.Name = "editKVGKontaktTelefon";
            this.editKVGKontaktTelefon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editKVGKontaktTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKVGKontaktTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKVGKontaktTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.editKVGKontaktTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.editKVGKontaktTelefon.Properties.Appearance.Options.UseFont = true;
            this.editKVGKontaktTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editKVGKontaktTelefon.Size = new System.Drawing.Size(285, 24);
            this.editKVGKontaktTelefon.TabIndex = 2;
            //
            // editKVGMitgliedNr
            //
            this.editKVGMitgliedNr.DataMember = "KVGMitgliedNr";
            this.editKVGMitgliedNr.DataSource = this.qryGesundheit;
            this.editKVGMitgliedNr.Location = new System.Drawing.Point(115, 109);
            this.editKVGMitgliedNr.Name = "editKVGMitgliedNr";
            this.editKVGMitgliedNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editKVGMitgliedNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKVGMitgliedNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKVGMitgliedNr.Properties.Appearance.Options.UseBackColor = true;
            this.editKVGMitgliedNr.Properties.Appearance.Options.UseBorderColor = true;
            this.editKVGMitgliedNr.Properties.Appearance.Options.UseFont = true;
            this.editKVGMitgliedNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editKVGMitgliedNr.Size = new System.Drawing.Size(285, 24);
            this.editKVGMitgliedNr.TabIndex = 3;
            //
            // dtpKVGVersichertSeit
            //
            this.dtpKVGVersichertSeit.DataMember = "KVGVersichertSeit";
            this.dtpKVGVersichertSeit.DataSource = this.qryGesundheit;
            this.dtpKVGVersichertSeit.EditValue = null;
            this.dtpKVGVersichertSeit.Location = new System.Drawing.Point(115, 139);
            this.dtpKVGVersichertSeit.Name = "dtpKVGVersichertSeit";
            this.dtpKVGVersichertSeit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtpKVGVersichertSeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dtpKVGVersichertSeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dtpKVGVersichertSeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dtpKVGVersichertSeit.Properties.Appearance.Options.UseBackColor = true;
            this.dtpKVGVersichertSeit.Properties.Appearance.Options.UseBorderColor = true;
            this.dtpKVGVersichertSeit.Properties.Appearance.Options.UseFont = true;
            this.dtpKVGVersichertSeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.dtpKVGVersichertSeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dtpKVGVersichertSeit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.dtpKVGVersichertSeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dtpKVGVersichertSeit.Properties.ShowToday = false;
            this.dtpKVGVersichertSeit.Size = new System.Drawing.Size(110, 24);
            this.dtpKVGVersichertSeit.TabIndex = 4;
            //
            // editKVGGrundPraemie
            //
            this.editKVGGrundPraemie.DataMember = "KVGGrundpraemie";
            this.editKVGGrundPraemie.DataSource = this.qryGesundheit;
            this.editKVGGrundPraemie.Location = new System.Drawing.Point(115, 169);
            this.editKVGGrundPraemie.Name = "editKVGGrundPraemie";
            this.editKVGGrundPraemie.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editKVGGrundPraemie.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editKVGGrundPraemie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKVGGrundPraemie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKVGGrundPraemie.Properties.Appearance.Options.UseBackColor = true;
            this.editKVGGrundPraemie.Properties.Appearance.Options.UseBorderColor = true;
            this.editKVGGrundPraemie.Properties.Appearance.Options.UseFont = true;
            this.editKVGGrundPraemie.Properties.Appearance.Options.UseTextOptions = true;
            this.editKVGGrundPraemie.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.editKVGGrundPraemie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editKVGGrundPraemie.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editKVGGrundPraemie.Properties.DisplayFormat.FormatString = "N2";
            this.editKVGGrundPraemie.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editKVGGrundPraemie.Properties.NullText = "0.00";
            this.editKVGGrundPraemie.Size = new System.Drawing.Size(80, 24);
            this.editKVGGrundPraemie.TabIndex = 5;
            //
            // editKVGUnfall
            //
            this.editKVGUnfall.DataMember = "KVGUnfallPraemie";
            this.editKVGUnfall.DataSource = this.qryGesundheit;
            this.editKVGUnfall.Location = new System.Drawing.Point(115, 192);
            this.editKVGUnfall.Name = "editKVGUnfall";
            this.editKVGUnfall.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editKVGUnfall.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editKVGUnfall.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKVGUnfall.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKVGUnfall.Properties.Appearance.Options.UseBackColor = true;
            this.editKVGUnfall.Properties.Appearance.Options.UseBorderColor = true;
            this.editKVGUnfall.Properties.Appearance.Options.UseFont = true;
            this.editKVGUnfall.Properties.Appearance.Options.UseTextOptions = true;
            this.editKVGUnfall.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.editKVGUnfall.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editKVGUnfall.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editKVGUnfall.Properties.DisplayFormat.FormatString = "N2";
            this.editKVGUnfall.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editKVGUnfall.Properties.NullText = "0.00";
            this.editKVGUnfall.Size = new System.Drawing.Size(80, 24);
            this.editKVGUnfall.TabIndex = 6;
            //
            // editKVGGesundheit
            //
            this.editKVGGesundheit.DataMember = "KVGGesundFoerdPraemie";
            this.editKVGGesundheit.DataSource = this.qryGesundheit;
            this.editKVGGesundheit.Location = new System.Drawing.Point(115, 215);
            this.editKVGGesundheit.Name = "editKVGGesundheit";
            this.editKVGGesundheit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editKVGGesundheit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editKVGGesundheit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKVGGesundheit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKVGGesundheit.Properties.Appearance.Options.UseBackColor = true;
            this.editKVGGesundheit.Properties.Appearance.Options.UseBorderColor = true;
            this.editKVGGesundheit.Properties.Appearance.Options.UseFont = true;
            this.editKVGGesundheit.Properties.Appearance.Options.UseTextOptions = true;
            this.editKVGGesundheit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.editKVGGesundheit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editKVGGesundheit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editKVGGesundheit.Properties.DisplayFormat.FormatString = "N2";
            this.editKVGGesundheit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editKVGGesundheit.Properties.NullText = "0.00";
            this.editKVGGesundheit.Size = new System.Drawing.Size(80, 24);
            this.editKVGGesundheit.TabIndex = 7;
            //
            // editKVGZuschussBetrag
            //
            this.editKVGZuschussBetrag.DataMember = "KVGZuschussBetrag";
            this.editKVGZuschussBetrag.DataSource = this.qryGesundheit;
            this.editKVGZuschussBetrag.Location = new System.Drawing.Point(115, 238);
            this.editKVGZuschussBetrag.Name = "editKVGZuschussBetrag";
            this.editKVGZuschussBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editKVGZuschussBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editKVGZuschussBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKVGZuschussBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKVGZuschussBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.editKVGZuschussBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.editKVGZuschussBetrag.Properties.Appearance.Options.UseFont = true;
            this.editKVGZuschussBetrag.Properties.Appearance.Options.UseTextOptions = true;
            this.editKVGZuschussBetrag.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.editKVGZuschussBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editKVGZuschussBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editKVGZuschussBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.editKVGZuschussBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editKVGZuschussBetrag.Properties.NullText = "0.00";
            this.editKVGZuschussBetrag.Size = new System.Drawing.Size(80, 24);
            this.editKVGZuschussBetrag.TabIndex = 8;
            //
            // chkKVGZuschussUnregelmaessig
            //
            this.chkKVGZuschussUnregelmaessig.DataMember = "ZuschussInAbklaerungFlag";
            this.chkKVGZuschussUnregelmaessig.DataSource = this.qryGesundheit;
            this.chkKVGZuschussUnregelmaessig.Location = new System.Drawing.Point(245, 242);
            this.chkKVGZuschussUnregelmaessig.Name = "chkKVGZuschussUnregelmaessig";
            this.chkKVGZuschussUnregelmaessig.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkKVGZuschussUnregelmaessig.Properties.Appearance.Options.UseBackColor = true;
            this.chkKVGZuschussUnregelmaessig.Properties.Caption = "abklären";
            this.chkKVGZuschussUnregelmaessig.Size = new System.Drawing.Size(100, 19);
            this.chkKVGZuschussUnregelmaessig.TabIndex = 9;
            this.chkKVGZuschussUnregelmaessig.CheckedChanged += new System.EventHandler(this.chkKVGZuschussUnregelmaessig_CheckedChanged);
            //
            // editKVGUmweltabgabe
            //
            this.editKVGUmweltabgabe.DataMember = "KVGUmweltabgabeBetrag";
            this.editKVGUmweltabgabe.DataSource = this.qryGesundheit;
            this.editKVGUmweltabgabe.Location = new System.Drawing.Point(115, 261);
            this.editKVGUmweltabgabe.Name = "editKVGUmweltabgabe";
            this.editKVGUmweltabgabe.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editKVGUmweltabgabe.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editKVGUmweltabgabe.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKVGUmweltabgabe.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKVGUmweltabgabe.Properties.Appearance.Options.UseBackColor = true;
            this.editKVGUmweltabgabe.Properties.Appearance.Options.UseBorderColor = true;
            this.editKVGUmweltabgabe.Properties.Appearance.Options.UseFont = true;
            this.editKVGUmweltabgabe.Properties.Appearance.Options.UseTextOptions = true;
            this.editKVGUmweltabgabe.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.editKVGUmweltabgabe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editKVGUmweltabgabe.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editKVGUmweltabgabe.Properties.DisplayFormat.FormatString = "N2";
            this.editKVGUmweltabgabe.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editKVGUmweltabgabe.Properties.NullText = "0.00";
            this.editKVGUmweltabgabe.Size = new System.Drawing.Size(80, 24);
            this.editKVGUmweltabgabe.TabIndex = 10;
            //
            // editKVGPraemie
            //
            this.editKVGPraemie.DataMember = "KVGPraemie";
            this.editKVGPraemie.DataSource = this.qryGesundheit;
            this.editKVGPraemie.Location = new System.Drawing.Point(115, 291);
            this.editKVGPraemie.Name = "editKVGPraemie";
            this.editKVGPraemie.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editKVGPraemie.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editKVGPraemie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKVGPraemie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKVGPraemie.Properties.Appearance.Options.UseBackColor = true;
            this.editKVGPraemie.Properties.Appearance.Options.UseBorderColor = true;
            this.editKVGPraemie.Properties.Appearance.Options.UseFont = true;
            this.editKVGPraemie.Properties.Appearance.Options.UseTextOptions = true;
            this.editKVGPraemie.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.editKVGPraemie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editKVGPraemie.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editKVGPraemie.Properties.DisplayFormat.FormatString = "N2";
            this.editKVGPraemie.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editKVGPraemie.Properties.EditFormat.FormatString = "N2";
            this.editKVGPraemie.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editKVGPraemie.Properties.NullText = "0.00";
            this.editKVGPraemie.Size = new System.Drawing.Size(80, 24);
            this.editKVGPraemie.TabIndex = 11;
            //
            // cboKVGZahlungsPeriode
            //
            this.cboKVGZahlungsPeriode.DataMember = "KVGZahlungsperiodeCode";
            this.cboKVGZahlungsPeriode.DataSource = this.qryGesundheit;
            this.cboKVGZahlungsPeriode.Location = new System.Drawing.Point(245, 291);
            this.cboKVGZahlungsPeriode.LOVName = "ZahlungsPeriode";
            this.cboKVGZahlungsPeriode.Name = "cboKVGZahlungsPeriode";
            this.cboKVGZahlungsPeriode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboKVGZahlungsPeriode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboKVGZahlungsPeriode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboKVGZahlungsPeriode.Properties.Appearance.Options.UseBackColor = true;
            this.cboKVGZahlungsPeriode.Properties.Appearance.Options.UseBorderColor = true;
            this.cboKVGZahlungsPeriode.Properties.Appearance.Options.UseFont = true;
            this.cboKVGZahlungsPeriode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboKVGZahlungsPeriode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboKVGZahlungsPeriode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboKVGZahlungsPeriode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboKVGZahlungsPeriode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.cboKVGZahlungsPeriode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.cboKVGZahlungsPeriode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboKVGZahlungsPeriode.Properties.NullText = "";
            this.cboKVGZahlungsPeriode.Properties.ShowFooter = false;
            this.cboKVGZahlungsPeriode.Properties.ShowHeader = false;
            this.cboKVGZahlungsPeriode.Size = new System.Drawing.Size(150, 24);
            this.cboKVGZahlungsPeriode.TabIndex = 12;
            //
            // editKVGFranchise
            //
            this.editKVGFranchise.DataMember = "KVGFranchise";
            this.editKVGFranchise.DataSource = this.qryGesundheit;
            this.editKVGFranchise.Location = new System.Drawing.Point(115, 321);
            this.editKVGFranchise.Name = "editKVGFranchise";
            this.editKVGFranchise.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editKVGFranchise.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editKVGFranchise.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKVGFranchise.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKVGFranchise.Properties.Appearance.Options.UseBackColor = true;
            this.editKVGFranchise.Properties.Appearance.Options.UseBorderColor = true;
            this.editKVGFranchise.Properties.Appearance.Options.UseFont = true;
            this.editKVGFranchise.Properties.Appearance.Options.UseTextOptions = true;
            this.editKVGFranchise.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.editKVGFranchise.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editKVGFranchise.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editKVGFranchise.Properties.DisplayFormat.FormatString = "N2";
            this.editKVGFranchise.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editKVGFranchise.Properties.NullText = "0.00";
            this.editKVGFranchise.Size = new System.Drawing.Size(80, 24);
            this.editKVGFranchise.TabIndex = 13;
            //
            // editVVGOrganisation
            //
            this.editVVGOrganisation.DataMember = "VVGOrganisation";
            this.editVVGOrganisation.DataSource = this.qryGesundheit;
            this.editVVGOrganisation.Location = new System.Drawing.Point(425, 40);
            this.editVVGOrganisation.Name = "editVVGOrganisation";
            this.editVVGOrganisation.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editVVGOrganisation.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editVVGOrganisation.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editVVGOrganisation.Properties.Appearance.Options.UseBackColor = true;
            this.editVVGOrganisation.Properties.Appearance.Options.UseBorderColor = true;
            this.editVVGOrganisation.Properties.Appearance.Options.UseFont = true;
            this.editVVGOrganisation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.editVVGOrganisation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.editVVGOrganisation.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editVVGOrganisation.Size = new System.Drawing.Size(285, 24);
            this.editVVGOrganisation.TabIndex = 14;
            this.editVVGOrganisation.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editVVGOrganisation_UserModifiedFld);
            //
            // editVVGKontaktPerson
            //
            this.editVVGKontaktPerson.DataMember = "VVGKontaktperson";
            this.editVVGKontaktPerson.DataSource = this.qryGesundheit;
            this.editVVGKontaktPerson.Location = new System.Drawing.Point(425, 63);
            this.editVVGKontaktPerson.Name = "editVVGKontaktPerson";
            this.editVVGKontaktPerson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editVVGKontaktPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editVVGKontaktPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editVVGKontaktPerson.Properties.Appearance.Options.UseBackColor = true;
            this.editVVGKontaktPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.editVVGKontaktPerson.Properties.Appearance.Options.UseFont = true;
            this.editVVGKontaktPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editVVGKontaktPerson.Size = new System.Drawing.Size(285, 24);
            this.editVVGKontaktPerson.TabIndex = 15;
            //
            // editVVGKontaktTelefon
            //
            this.editVVGKontaktTelefon.DataMember = "VVGKontaktTelefon";
            this.editVVGKontaktTelefon.DataSource = this.qryGesundheit;
            this.editVVGKontaktTelefon.Location = new System.Drawing.Point(425, 86);
            this.editVVGKontaktTelefon.Name = "editVVGKontaktTelefon";
            this.editVVGKontaktTelefon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editVVGKontaktTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editVVGKontaktTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editVVGKontaktTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.editVVGKontaktTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.editVVGKontaktTelefon.Properties.Appearance.Options.UseFont = true;
            this.editVVGKontaktTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editVVGKontaktTelefon.Size = new System.Drawing.Size(285, 24);
            this.editVVGKontaktTelefon.TabIndex = 16;
            //
            // editVVGMitgliedNr
            //
            this.editVVGMitgliedNr.DataMember = "VVGMitgliedNr";
            this.editVVGMitgliedNr.DataSource = this.qryGesundheit;
            this.editVVGMitgliedNr.Location = new System.Drawing.Point(425, 109);
            this.editVVGMitgliedNr.Name = "editVVGMitgliedNr";
            this.editVVGMitgliedNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editVVGMitgliedNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editVVGMitgliedNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editVVGMitgliedNr.Properties.Appearance.Options.UseBackColor = true;
            this.editVVGMitgliedNr.Properties.Appearance.Options.UseBorderColor = true;
            this.editVVGMitgliedNr.Properties.Appearance.Options.UseFont = true;
            this.editVVGMitgliedNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editVVGMitgliedNr.Size = new System.Drawing.Size(285, 24);
            this.editVVGMitgliedNr.TabIndex = 17;
            //
            // editVVGVersicherung
            //
            this.editVVGVersicherung.DataMember = "VVGVersichertSeit";
            this.editVVGVersicherung.DataSource = this.qryGesundheit;
            this.editVVGVersicherung.EditValue = null;
            this.editVVGVersicherung.Location = new System.Drawing.Point(425, 139);
            this.editVVGVersicherung.Name = "editVVGVersicherung";
            this.editVVGVersicherung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editVVGVersicherung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editVVGVersicherung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editVVGVersicherung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editVVGVersicherung.Properties.Appearance.Options.UseBackColor = true;
            this.editVVGVersicherung.Properties.Appearance.Options.UseBorderColor = true;
            this.editVVGVersicherung.Properties.Appearance.Options.UseFont = true;
            this.editVVGVersicherung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.editVVGVersicherung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editVVGVersicherung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.editVVGVersicherung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editVVGVersicherung.Properties.ShowToday = false;
            this.editVVGVersicherung.Size = new System.Drawing.Size(110, 24);
            this.editVVGVersicherung.TabIndex = 18;
            //
            // editVVGZusaetzeRTF
            //
            this.editVVGZusaetzeRTF.BackColor = System.Drawing.Color.White;
            this.editVVGZusaetzeRTF.DataMember = "VVGZusaetzeRTF";
            this.editVVGZusaetzeRTF.DataSource = this.qryGesundheit;
            this.editVVGZusaetzeRTF.Font = new System.Drawing.Font("Arial", 10F);
            this.editVVGZusaetzeRTF.Location = new System.Drawing.Point(425, 197);
            this.editVVGZusaetzeRTF.Name = "editVVGZusaetzeRTF";
            this.editVVGZusaetzeRTF.Size = new System.Drawing.Size(285, 83);
            this.editVVGZusaetzeRTF.TabIndex = 19;
            //
            // editVVGPraemie
            //
            this.editVVGPraemie.DataMember = "VVGPraemie";
            this.editVVGPraemie.DataSource = this.qryGesundheit;
            this.editVVGPraemie.Location = new System.Drawing.Point(425, 291);
            this.editVVGPraemie.Name = "editVVGPraemie";
            this.editVVGPraemie.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editVVGPraemie.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editVVGPraemie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editVVGPraemie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editVVGPraemie.Properties.Appearance.Options.UseBackColor = true;
            this.editVVGPraemie.Properties.Appearance.Options.UseBorderColor = true;
            this.editVVGPraemie.Properties.Appearance.Options.UseFont = true;
            this.editVVGPraemie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editVVGPraemie.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editVVGPraemie.Properties.DisplayFormat.FormatString = "N2";
            this.editVVGPraemie.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editVVGPraemie.Properties.NullText = "0.00";
            this.editVVGPraemie.Size = new System.Drawing.Size(80, 24);
            this.editVVGPraemie.TabIndex = 20;
            //
            // editVVGZahlungsperiode
            //
            this.editVVGZahlungsperiode.DataMember = "VVGZahlungsperiodeCode";
            this.editVVGZahlungsperiode.DataSource = this.qryGesundheit;
            this.editVVGZahlungsperiode.Location = new System.Drawing.Point(555, 291);
            this.editVVGZahlungsperiode.LOVName = "ZahlungsPeriode";
            this.editVVGZahlungsperiode.Name = "editVVGZahlungsperiode";
            this.editVVGZahlungsperiode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editVVGZahlungsperiode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editVVGZahlungsperiode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editVVGZahlungsperiode.Properties.Appearance.Options.UseBackColor = true;
            this.editVVGZahlungsperiode.Properties.Appearance.Options.UseBorderColor = true;
            this.editVVGZahlungsperiode.Properties.Appearance.Options.UseFont = true;
            this.editVVGZahlungsperiode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editVVGZahlungsperiode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editVVGZahlungsperiode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editVVGZahlungsperiode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editVVGZahlungsperiode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.editVVGZahlungsperiode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.editVVGZahlungsperiode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editVVGZahlungsperiode.Properties.NullText = "";
            this.editVVGZahlungsperiode.Properties.ShowFooter = false;
            this.editVVGZahlungsperiode.Properties.ShowHeader = false;
            this.editVVGZahlungsperiode.Size = new System.Drawing.Size(150, 24);
            this.editVVGZahlungsperiode.TabIndex = 21;
            //
            // editVVGFranchise
            //
            this.editVVGFranchise.DataMember = "VVGFranchise";
            this.editVVGFranchise.DataSource = this.qryGesundheit;
            this.editVVGFranchise.Location = new System.Drawing.Point(425, 321);
            this.editVVGFranchise.Name = "editVVGFranchise";
            this.editVVGFranchise.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editVVGFranchise.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editVVGFranchise.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editVVGFranchise.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editVVGFranchise.Properties.Appearance.Options.UseBackColor = true;
            this.editVVGFranchise.Properties.Appearance.Options.UseBorderColor = true;
            this.editVVGFranchise.Properties.Appearance.Options.UseFont = true;
            this.editVVGFranchise.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editVVGFranchise.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editVVGFranchise.Properties.DisplayFormat.FormatString = "N2";
            this.editVVGFranchise.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editVVGFranchise.Properties.NullText = "0.00";
            this.editVVGFranchise.Size = new System.Drawing.Size(80, 24);
            this.editVVGFranchise.TabIndex = 22;
            //
            // cboEingliederungsmassnahme
            //
            this.cboEingliederungsmassnahme.DataMember = "IVEingliederungsmassnahmeCode";
            this.cboEingliederungsmassnahme.DataSource = this.qryGesundheit;
            this.cboEingliederungsmassnahme.Location = new System.Drawing.Point(115, 370);
            this.cboEingliederungsmassnahme.LOVName = "InAbklaerung";
            this.cboEingliederungsmassnahme.Name = "cboEingliederungsmassnahme";
            this.cboEingliederungsmassnahme.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboEingliederungsmassnahme.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboEingliederungsmassnahme.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboEingliederungsmassnahme.Properties.Appearance.Options.UseBackColor = true;
            this.cboEingliederungsmassnahme.Properties.Appearance.Options.UseBorderColor = true;
            this.cboEingliederungsmassnahme.Properties.Appearance.Options.UseFont = true;
            this.cboEingliederungsmassnahme.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboEingliederungsmassnahme.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboEingliederungsmassnahme.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboEingliederungsmassnahme.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboEingliederungsmassnahme.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.cboEingliederungsmassnahme.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.cboEingliederungsmassnahme.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboEingliederungsmassnahme.Properties.NullText = "";
            this.cboEingliederungsmassnahme.Properties.ShowFooter = false;
            this.cboEingliederungsmassnahme.Properties.ShowHeader = false;
            this.cboEingliederungsmassnahme.Size = new System.Drawing.Size(150, 24);
            this.cboEingliederungsmassnahme.TabIndex = 23;
            //
            // chkPflegebeduerftig
            //
            this.chkPflegebeduerftig.DataMember = "PflegebeduerftigFlag";
            this.chkPflegebeduerftig.DataSource = this.qryGesundheit;
            this.chkPflegebeduerftig.Location = new System.Drawing.Point(299, 374);
            this.chkPflegebeduerftig.Name = "chkPflegebeduerftig";
            this.chkPflegebeduerftig.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkPflegebeduerftig.Properties.Appearance.Options.UseBackColor = true;
            this.chkPflegebeduerftig.Properties.Caption = "pflegebedürftig";
            this.chkPflegebeduerftig.Size = new System.Drawing.Size(120, 19);
            this.chkPflegebeduerftig.TabIndex = 24;
            this.chkPflegebeduerftig.CheckedChanged += new System.EventHandler(this.chkPflegebeduerftig_CheckedChanged);
            //
            // cboPflegeDurch
            //
            this.cboPflegeDurch.DataMember = "PflegeDurchCode";
            this.cboPflegeDurch.DataSource = this.qryGesundheit;
            this.cboPflegeDurch.Location = new System.Drawing.Point(511, 370);
            this.cboPflegeDurch.LOVName = "PflegeDurch";
            this.cboPflegeDurch.Name = "cboPflegeDurch";
            this.cboPflegeDurch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboPflegeDurch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboPflegeDurch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboPflegeDurch.Properties.Appearance.Options.UseBackColor = true;
            this.cboPflegeDurch.Properties.Appearance.Options.UseBorderColor = true;
            this.cboPflegeDurch.Properties.Appearance.Options.UseFont = true;
            this.cboPflegeDurch.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboPflegeDurch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboPflegeDurch.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboPflegeDurch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboPflegeDurch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.cboPflegeDurch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.cboPflegeDurch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboPflegeDurch.Properties.NullText = "";
            this.cboPflegeDurch.Properties.ShowFooter = false;
            this.cboPflegeDurch.Properties.ShowHeader = false;
            this.cboPflegeDurch.Size = new System.Drawing.Size(150, 24);
            this.cboPflegeDurch.TabIndex = 25;
            //
            // editBemerkungRTF
            //
            this.editBemerkungRTF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.editBemerkungRTF.BackColor = System.Drawing.Color.White;
            this.editBemerkungRTF.DataMember = "Bemerkung";
            this.editBemerkungRTF.DataSource = this.qryGesundheit;
            this.editBemerkungRTF.Font = new System.Drawing.Font("Arial", 10F);
            this.editBemerkungRTF.Location = new System.Drawing.Point(115, 465);
            this.editBemerkungRTF.Name = "editBemerkungRTF";
            this.editBemerkungRTF.Size = new System.Drawing.Size(595, 69);
            this.editBemerkungRTF.TabIndex = 26;
            //
            // panel1
            //
            this.panel1.Controls.Add(this.kissLabel2);
            this.panel1.Controls.Add(this.kissLabel1);
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 30);
            this.panel1.TabIndex = 333;
            //
            // kissLabel2
            //
            this.kissLabel2.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel2.Location = new System.Drawing.Point(545, 10);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(45, 16);
            this.kissLabel2.TabIndex = 336;
            this.kissLabel2.Text = "VVG";
            this.kissLabel2.UseCompatibleTextRendering = true;
            //
            // kissLabel1
            //
            this.kissLabel1.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel1.Location = new System.Drawing.Point(235, 10);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(45, 16);
            this.kissLabel1.TabIndex = 335;
            this.kissLabel1.Text = "KVG";
            this.kissLabel1.UseCompatibleTextRendering = true;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(5, 9);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            //
            // lblTitel
            //
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(25, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(200, 16);
            this.lblTitel.TabIndex = 292;
            this.lblTitel.Text = "Gesundheit";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // kissLabel17
            //
            this.kissLabel17.Location = new System.Drawing.Point(5, 40);
            this.kissLabel17.Name = "kissLabel17";
            this.kissLabel17.Size = new System.Drawing.Size(103, 24);
            this.kissLabel17.TabIndex = 446;
            this.kissLabel17.Text = "Krankenkasse";
            this.kissLabel17.UseCompatibleTextRendering = true;
            //
            // kissLabel3
            //
            this.kissLabel3.Location = new System.Drawing.Point(5, 321);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(80, 24);
            this.kissLabel3.TabIndex = 448;
            this.kissLabel3.Text = "Franchise";
            this.kissLabel3.UseCompatibleTextRendering = true;
            //
            // kissLabel4
            //
            this.kissLabel4.Location = new System.Drawing.Point(5, 291);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(90, 24);
            this.kissLabel4.TabIndex = 449;
            this.kissLabel4.Text = "Prämie / Zahlung";
            this.kissLabel4.UseCompatibleTextRendering = true;
            //
            // kissLabel5
            //
            this.kissLabel5.Location = new System.Drawing.Point(5, 169);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(80, 24);
            this.kissLabel5.TabIndex = 450;
            this.kissLabel5.Text = "Grundprämie";
            this.kissLabel5.UseCompatibleTextRendering = true;
            //
            // kissLabel6
            //
            this.kissLabel6.Location = new System.Drawing.Point(5, 261);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(80, 24);
            this.kissLabel6.TabIndex = 451;
            this.kissLabel6.Text = "Umweltabgabe";
            this.kissLabel6.UseCompatibleTextRendering = true;
            //
            // kissLabel7
            //
            this.kissLabel7.Location = new System.Drawing.Point(5, 139);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(80, 24);
            this.kissLabel7.TabIndex = 452;
            this.kissLabel7.Text = "versichert seit";
            this.kissLabel7.UseCompatibleTextRendering = true;
            //
            // kissLabel8
            //
            this.kissLabel8.Location = new System.Drawing.Point(5, 109);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(80, 24);
            this.kissLabel8.TabIndex = 453;
            this.kissLabel8.Text = "Mitglied-Nr";
            this.kissLabel8.UseCompatibleTextRendering = true;
            //
            // kissLabel9
            //
            this.kissLabel9.Location = new System.Drawing.Point(5, 86);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(80, 24);
            this.kissLabel9.TabIndex = 454;
            this.kissLabel9.Text = "Telefon";
            this.kissLabel9.UseCompatibleTextRendering = true;
            //
            // kissLabel10
            //
            this.kissLabel10.Location = new System.Drawing.Point(5, 63);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(80, 24);
            this.kissLabel10.TabIndex = 455;
            this.kissLabel10.Text = "Kontaktperson";
            this.kissLabel10.UseCompatibleTextRendering = true;
            //
            // kissLabel11
            //
            this.kissLabel11.Location = new System.Drawing.Point(5, 465);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(70, 24);
            this.kissLabel11.TabIndex = 472;
            this.kissLabel11.Text = "Bemerkung";
            this.kissLabel11.UseCompatibleTextRendering = true;
            //
            // kissLabel12
            //
            this.kissLabel12.Location = new System.Drawing.Point(5, 238);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(80, 24);
            this.kissLabel12.TabIndex = 474;
            this.kissLabel12.Text = "Prämienverb.";
            this.kissLabel12.UseCompatibleTextRendering = true;
            //
            // kissLabel13
            //
            this.kissLabel13.Location = new System.Drawing.Point(5, 215);
            this.kissLabel13.Name = "kissLabel13";
            this.kissLabel13.Size = new System.Drawing.Size(80, 24);
            this.kissLabel13.TabIndex = 475;
            this.kissLabel13.Text = "Gesundh. Förd.";
            this.kissLabel13.UseCompatibleTextRendering = true;
            //
            // kissLabel14
            //
            this.kissLabel14.Location = new System.Drawing.Point(5, 192);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(80, 24);
            this.kissLabel14.TabIndex = 476;
            this.kissLabel14.Text = "Unfall";
            this.kissLabel14.UseCompatibleTextRendering = true;
            //
            // kissLabel15
            //
            this.kissLabel15.Location = new System.Drawing.Point(425, 170);
            this.kissLabel15.Name = "kissLabel15";
            this.kissLabel15.Size = new System.Drawing.Size(80, 24);
            this.kissLabel15.TabIndex = 480;
            this.kissLabel15.Text = "Zusätze";
            this.kissLabel15.UseCompatibleTextRendering = true;
            //
            // kissLabel16
            //
            this.kissLabel16.Location = new System.Drawing.Point(425, 370);
            this.kissLabel16.Name = "kissLabel16";
            this.kissLabel16.Size = new System.Drawing.Size(80, 24);
            this.kissLabel16.TabIndex = 481;
            this.kissLabel16.Text = "Pflege durch";
            this.kissLabel16.UseCompatibleTextRendering = true;
            //
            // kissLabel18
            //
            this.kissLabel18.Location = new System.Drawing.Point(200, 192);
            this.kissLabel18.Name = "kissLabel18";
            this.kissLabel18.Size = new System.Drawing.Size(30, 24);
            this.kissLabel18.TabIndex = 487;
            this.kissLabel18.Text = "CHF";
            this.kissLabel18.UseCompatibleTextRendering = true;
            //
            // kissLabel19
            //
            this.kissLabel19.Location = new System.Drawing.Point(200, 215);
            this.kissLabel19.Name = "kissLabel19";
            this.kissLabel19.Size = new System.Drawing.Size(30, 24);
            this.kissLabel19.TabIndex = 488;
            this.kissLabel19.Text = "CHF";
            this.kissLabel19.UseCompatibleTextRendering = true;
            //
            // kissLabel20
            //
            this.kissLabel20.Location = new System.Drawing.Point(200, 169);
            this.kissLabel20.Name = "kissLabel20";
            this.kissLabel20.Size = new System.Drawing.Size(30, 24);
            this.kissLabel20.TabIndex = 489;
            this.kissLabel20.Text = "CHF";
            this.kissLabel20.UseCompatibleTextRendering = true;
            //
            // kissLabel21
            //
            this.kissLabel21.Location = new System.Drawing.Point(200, 238);
            this.kissLabel21.Name = "kissLabel21";
            this.kissLabel21.Size = new System.Drawing.Size(30, 24);
            this.kissLabel21.TabIndex = 490;
            this.kissLabel21.Text = "CHF";
            this.kissLabel21.UseCompatibleTextRendering = true;
            //
            // kissLabel22
            //
            this.kissLabel22.Location = new System.Drawing.Point(200, 261);
            this.kissLabel22.Name = "kissLabel22";
            this.kissLabel22.Size = new System.Drawing.Size(30, 24);
            this.kissLabel22.TabIndex = 491;
            this.kissLabel22.Text = "CHF";
            this.kissLabel22.UseCompatibleTextRendering = true;
            //
            // kissLabel23
            //
            this.kissLabel23.Location = new System.Drawing.Point(200, 291);
            this.kissLabel23.Name = "kissLabel23";
            this.kissLabel23.Size = new System.Drawing.Size(30, 24);
            this.kissLabel23.TabIndex = 492;
            this.kissLabel23.Text = "CHF";
            this.kissLabel23.UseCompatibleTextRendering = true;
            //
            // kissLabel24
            //
            this.kissLabel24.Location = new System.Drawing.Point(200, 321);
            this.kissLabel24.Name = "kissLabel24";
            this.kissLabel24.Size = new System.Drawing.Size(30, 24);
            this.kissLabel24.TabIndex = 493;
            this.kissLabel24.Text = "CHF";
            this.kissLabel24.UseCompatibleTextRendering = true;
            //
            // kissLabel25
            //
            this.kissLabel25.Location = new System.Drawing.Point(515, 291);
            this.kissLabel25.Name = "kissLabel25";
            this.kissLabel25.Size = new System.Drawing.Size(30, 24);
            this.kissLabel25.TabIndex = 494;
            this.kissLabel25.Text = "CHF";
            this.kissLabel25.UseCompatibleTextRendering = true;
            //
            // kissLabel26
            //
            this.kissLabel26.Location = new System.Drawing.Point(515, 321);
            this.kissLabel26.Name = "kissLabel26";
            this.kissLabel26.Size = new System.Drawing.Size(30, 24);
            this.kissLabel26.TabIndex = 495;
            this.kissLabel26.Text = "CHF";
            this.kissLabel26.UseCompatibleTextRendering = true;
            //
            // kissLabel27
            //
            this.kissLabel27.Location = new System.Drawing.Point(5, 370);
            this.kissLabel27.Name = "kissLabel27";
            this.kissLabel27.Size = new System.Drawing.Size(80, 24);
            this.kissLabel27.TabIndex = 496;
            this.kissLabel27.Text = "IV-Eingliederung";
            this.kissLabel27.UseCompatibleTextRendering = true;
            //
            // panel2
            //
            this.panel2.Location = new System.Drawing.Point(0, 355);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(720, 1);
            this.panel2.TabIndex = 497;
            //
            // kissLabel28
            //
            this.kissLabel28.Location = new System.Drawing.Point(100, 215);
            this.kissLabel28.Name = "kissLabel28";
            this.kissLabel28.Size = new System.Drawing.Size(10, 24);
            this.kissLabel28.TabIndex = 498;
            this.kissLabel28.Text = "+";
            this.kissLabel28.UseCompatibleTextRendering = true;
            //
            // kissLabel29
            //
            this.kissLabel29.Location = new System.Drawing.Point(100, 238);
            this.kissLabel29.Name = "kissLabel29";
            this.kissLabel29.Size = new System.Drawing.Size(10, 24);
            this.kissLabel29.TabIndex = 499;
            this.kissLabel29.Text = "-";
            this.kissLabel29.UseCompatibleTextRendering = true;
            //
            // kissLabel30
            //
            this.kissLabel30.Location = new System.Drawing.Point(100, 192);
            this.kissLabel30.Name = "kissLabel30";
            this.kissLabel30.Size = new System.Drawing.Size(10, 24);
            this.kissLabel30.TabIndex = 500;
            this.kissLabel30.Text = "+";
            this.kissLabel30.UseCompatibleTextRendering = true;
            //
            // kissLabel31
            //
            this.kissLabel31.Location = new System.Drawing.Point(100, 169);
            this.kissLabel31.Name = "kissLabel31";
            this.kissLabel31.Size = new System.Drawing.Size(10, 24);
            this.kissLabel31.TabIndex = 501;
            this.kissLabel31.Text = "+";
            this.kissLabel31.UseCompatibleTextRendering = true;
            //
            // kissLabel32
            //
            this.kissLabel32.Location = new System.Drawing.Point(100, 261);
            this.kissLabel32.Name = "kissLabel32";
            this.kissLabel32.Size = new System.Drawing.Size(10, 24);
            this.kissLabel32.TabIndex = 502;
            this.kissLabel32.Text = "-";
            this.kissLabel32.UseCompatibleTextRendering = true;
            //
            // kissLabel33
            //
            this.kissLabel33.Location = new System.Drawing.Point(98, 291);
            this.kissLabel33.Name = "kissLabel33";
            this.kissLabel33.Size = new System.Drawing.Size(10, 24);
            this.kissLabel33.TabIndex = 503;
            this.kissLabel33.Text = "=";
            this.kissLabel33.UseCompatibleTextRendering = true;
            //
            // btnBerechnen
            //
            this.btnBerechnen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBerechnen.Location = new System.Drawing.Point(245, 321);
            this.btnBerechnen.Name = "btnBerechnen";
            this.btnBerechnen.Size = new System.Drawing.Size(123, 24);
            this.btnBerechnen.TabIndex = 504;
            this.btnBerechnen.Text = "Prämie berechnen";
            this.btnBerechnen.UseCompatibleTextRendering = true;
            this.btnBerechnen.UseVisualStyleBackColor = false;
            this.btnBerechnen.Click += new System.EventHandler(this.btnBerechnen_Click);
            //
            // editASVSAnmeldung
            //
            this.editASVSAnmeldung.DataMember = "ASVSAnmeldung";
            this.editASVSAnmeldung.DataSource = this.qryGesundheit;
            this.editASVSAnmeldung.EditValue = null;
            this.editASVSAnmeldung.Location = new System.Drawing.Point(115, 400);
            this.editASVSAnmeldung.Name = "editASVSAnmeldung";
            this.editASVSAnmeldung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editASVSAnmeldung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editASVSAnmeldung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editASVSAnmeldung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editASVSAnmeldung.Properties.Appearance.Options.UseBackColor = true;
            this.editASVSAnmeldung.Properties.Appearance.Options.UseBorderColor = true;
            this.editASVSAnmeldung.Properties.Appearance.Options.UseFont = true;
            this.editASVSAnmeldung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.editASVSAnmeldung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editASVSAnmeldung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.editASVSAnmeldung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editASVSAnmeldung.Properties.ShowToday = false;
            this.editASVSAnmeldung.Size = new System.Drawing.Size(110, 24);
            this.editASVSAnmeldung.TabIndex = 505;
            this.editASVSAnmeldung.Visible = false;
            //
            // lblASVSAn
            //
            this.lblASVSAn.Location = new System.Drawing.Point(5, 400);
            this.lblASVSAn.Name = "lblASVSAn";
            this.lblASVSAn.Size = new System.Drawing.Size(90, 24);
            this.lblASVSAn.TabIndex = 506;
            this.lblASVSAn.Text = "ASV Anmeldung";
            this.lblASVSAn.UseCompatibleTextRendering = true;
            this.lblASVSAn.Visible = false;
            //
            // editASVSAbmeldung
            //
            this.editASVSAbmeldung.DataMember = "ASVSAbmeldung";
            this.editASVSAbmeldung.DataSource = this.qryGesundheit;
            this.editASVSAbmeldung.EditValue = null;
            this.editASVSAbmeldung.Location = new System.Drawing.Point(115, 430);
            this.editASVSAbmeldung.Name = "editASVSAbmeldung";
            this.editASVSAbmeldung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editASVSAbmeldung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editASVSAbmeldung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editASVSAbmeldung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editASVSAbmeldung.Properties.Appearance.Options.UseBackColor = true;
            this.editASVSAbmeldung.Properties.Appearance.Options.UseBorderColor = true;
            this.editASVSAbmeldung.Properties.Appearance.Options.UseFont = true;
            this.editASVSAbmeldung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.editASVSAbmeldung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editASVSAbmeldung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.editASVSAbmeldung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editASVSAbmeldung.Properties.ShowToday = false;
            this.editASVSAbmeldung.Size = new System.Drawing.Size(110, 24);
            this.editASVSAbmeldung.TabIndex = 507;
            this.editASVSAbmeldung.Visible = false;
            //
            // lblASVSAb
            //
            this.lblASVSAb.Location = new System.Drawing.Point(5, 430);
            this.lblASVSAb.Name = "lblASVSAb";
            this.lblASVSAb.Size = new System.Drawing.Size(90, 24);
            this.lblASVSAb.TabIndex = 508;
            this.lblASVSAb.Text = "ASV Abmeldung";
            this.lblASVSAb.UseCompatibleTextRendering = true;
            this.lblASVSAb.Visible = false;
            //
            // chkAbtretungKK
            //
            this.chkAbtretungKK.DataMember = "AbtretungKK";
            this.chkAbtretungKK.DataSource = this.qryGesundheit;
            this.chkAbtretungKK.Location = new System.Drawing.Point(299, 405);
            this.chkAbtretungKK.Name = "chkAbtretungKK";
            this.chkAbtretungKK.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkAbtretungKK.Properties.Appearance.Options.UseBackColor = true;
            this.chkAbtretungKK.Properties.Caption = "Abtretung KK";
            this.chkAbtretungKK.Size = new System.Drawing.Size(120, 19);
            this.chkAbtretungKK.TabIndex = 510;
            //
            // CtlBaGesundheit
            //
            this.ActiveSQLQuery = this.qryGesundheit;
            this.Controls.Add(this.chkAbtretungKK);
            this.Controls.Add(this.lblASVSAb);
            this.Controls.Add(this.editASVSAbmeldung);
            this.Controls.Add(this.lblASVSAn);
            this.Controls.Add(this.editASVSAnmeldung);
            this.Controls.Add(this.btnBerechnen);
            this.Controls.Add(this.kissLabel33);
            this.Controls.Add(this.kissLabel32);
            this.Controls.Add(this.kissLabel31);
            this.Controls.Add(this.kissLabel30);
            this.Controls.Add(this.kissLabel29);
            this.Controls.Add(this.kissLabel28);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.kissLabel27);
            this.Controls.Add(this.kissLabel26);
            this.Controls.Add(this.kissLabel25);
            this.Controls.Add(this.kissLabel24);
            this.Controls.Add(this.kissLabel23);
            this.Controls.Add(this.kissLabel22);
            this.Controls.Add(this.kissLabel21);
            this.Controls.Add(this.kissLabel20);
            this.Controls.Add(this.kissLabel19);
            this.Controls.Add(this.kissLabel18);
            this.Controls.Add(this.kissLabel16);
            this.Controls.Add(this.kissLabel15);
            this.Controls.Add(this.kissLabel14);
            this.Controls.Add(this.kissLabel13);
            this.Controls.Add(this.kissLabel12);
            this.Controls.Add(this.kissLabel11);
            this.Controls.Add(this.kissLabel10);
            this.Controls.Add(this.kissLabel9);
            this.Controls.Add(this.kissLabel8);
            this.Controls.Add(this.kissLabel7);
            this.Controls.Add(this.kissLabel6);
            this.Controls.Add(this.kissLabel5);
            this.Controls.Add(this.kissLabel4);
            this.Controls.Add(this.kissLabel3);
            this.Controls.Add(this.kissLabel17);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.editBemerkungRTF);
            this.Controls.Add(this.cboPflegeDurch);
            this.Controls.Add(this.chkPflegebeduerftig);
            this.Controls.Add(this.cboEingliederungsmassnahme);
            this.Controls.Add(this.editVVGFranchise);
            this.Controls.Add(this.editVVGZahlungsperiode);
            this.Controls.Add(this.editVVGPraemie);
            this.Controls.Add(this.editVVGZusaetzeRTF);
            this.Controls.Add(this.editVVGVersicherung);
            this.Controls.Add(this.editVVGMitgliedNr);
            this.Controls.Add(this.editVVGKontaktTelefon);
            this.Controls.Add(this.editVVGKontaktPerson);
            this.Controls.Add(this.editVVGOrganisation);
            this.Controls.Add(this.editKVGFranchise);
            this.Controls.Add(this.cboKVGZahlungsPeriode);
            this.Controls.Add(this.editKVGPraemie);
            this.Controls.Add(this.editKVGUmweltabgabe);
            this.Controls.Add(this.chkKVGZuschussUnregelmaessig);
            this.Controls.Add(this.editKVGZuschussBetrag);
            this.Controls.Add(this.editKVGGesundheit);
            this.Controls.Add(this.editKVGUnfall);
            this.Controls.Add(this.editKVGGrundPraemie);
            this.Controls.Add(this.dtpKVGVersichertSeit);
            this.Controls.Add(this.editKVGMitgliedNr);
            this.Controls.Add(this.editKVGKontaktTelefon);
            this.Controls.Add(this.editKVGKontaktPerson);
            this.Controls.Add(this.editKVGKrankenKasse);
            this.MinimumSize = new System.Drawing.Size(717, 539);
            this.Name = "CtlBaGesundheit";
            this.Size = new System.Drawing.Size(717, 547);
            ((System.ComponentModel.ISupportInitialize)(this.editKVGKrankenKasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGesundheit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGKontaktPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGKontaktTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGMitgliedNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpKVGVersichertSeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGGrundPraemie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGUnfall.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGGesundheit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGZuschussBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKVGZuschussUnregelmaessig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGUmweltabgabe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGPraemie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKVGZahlungsPeriode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKVGZahlungsPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKVGFranchise.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGOrganisation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGKontaktPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGKontaktTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGMitgliedNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGVersicherung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGPraemie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGZahlungsperiode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGZahlungsperiode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVVGFranchise.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEingliederungsmassnahme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEingliederungsmassnahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPflegebeduerftig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPflegeDurch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPflegeDurch)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editASVSAnmeldung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblASVSAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editASVSAbmeldung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblASVSAb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbtretungKK.Properties)).EndInit();
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

        #region EventHandlers

        private void btnBerechnen_Click(object sender, System.EventArgs e)
        {
            // Letzte Bearbeitung
            // 27.09.2007 : RH : alles neu
            // ------------------------------------------------------------------------------

            SetPraemie();
        }

        private void chkKVGZuschussUnregelmaessig_CheckedChanged(object sender, EventArgs e)
        {
            bool CanEdit = (chkKVGZuschussUnregelmaessig.Checked && qryGesundheit.Count > 0 && qryGesundheit.CanUpdate);
            if (CanEdit)
                editKVGZuschussBetrag.EditMode = EditModeType.Normal;
            else
                editKVGZuschussBetrag.EditMode = EditModeType.ReadOnly;
        }

        // Letzte Bearbeitung
        // 27.09.2007 : RH : alles neu
        // ------------------------------------------------------------------------------
        private void chkPflegebeduerftig_CheckedChanged(object sender, EventArgs e)
        {
            bool CanEdit = (chkPflegebeduerftig.Checked && qryGesundheit.Count > 0 && qryGesundheit.CanUpdate);
            if (CanEdit)
                cboPflegeDurch.EditMode = EditModeType.Normal;
            else
                cboPflegeDurch.EditMode = EditModeType.ReadOnly;
        }

        private void editKVGKrankenKasse_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string searchString = editKVGKrankenKasse.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    // Falls Eingabefeld leer ist, dann soll beim Mausklick alles angezeigt werden:
                    searchString = "%";
                }
                else
                {
                    // sonst soll aktuelle Eingabe gelöscht werden:
                    qryGesundheit["KVGOrganisationID"] = DBNull.Value;
                    qryGesundheit["KVGOrganisation"] = DBNull.Value;
                    return;
                }
            }

            // Dialog anzeigen:
            KissLookupDialog dlg = new KissLookupDialog();

            e.Cancel = !dlg.SearchData(GetInstitutionSearchSQL(searchString), searchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryGesundheit["KVGOrganisationID"] = dlg["ID$"];
                qryGesundheit["KVGOrganisation"] = dlg["Institution"];
            }
        }

        private void editVVGOrganisation_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string searchString = editVVGOrganisation.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    // Falls Eingabefeld leer ist, dann soll beim Mausklick alles angezeigt werden:
                    searchString = "%";
                }
                else
                {
                    // sonst soll aktuelle Eingabe gelöscht werden:
                    qryGesundheit["VVGOrganisationID"] = DBNull.Value;
                    qryGesundheit["VVGOrganisation"] = DBNull.Value;
                    return;
                }
            }

            // Dialog anzeigen:
            KissLookupDialog dlg = new KissLookupDialog();

            e.Cancel = !dlg.SearchData(GetInstitutionSearchSQL(searchString), searchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryGesundheit["VVGOrganisationID"] = dlg["ID$"];
                qryGesundheit["VVGOrganisation"] = dlg["Institution"];
            }
        }

        private void qryGesundheit_AfterFill(object sender, System.EventArgs e)
        {
            if (qryGesundheit.Count == 0)
            {
                qryGesundheit.CanInsert = true;
                qryGesundheit.Insert();
                qryGesundheit.CanInsert = false;
            }
        }

        private void qryGesundheit_AfterInsert(object sender, System.EventArgs e)
        {
            qryGesundheit["BaPersonID"] = BaPersonID;
            qryGesundheit["AbtretungKK"] = 0;
        }

        private void qryGesundheit_BeforePost(object sender, System.EventArgs e)
        {
            SetPraemie();
        }

        private void qryGesundheit_PositionChanged(object sender, System.EventArgs e)
        {
            chkPflegebeduerftig_CheckedChanged(sender, e);
            chkKVGZuschussUnregelmaessig_CheckedChanged(sender, e);
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Get SQL statement for searching institution data of specific type
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public static string GetInstitutionSearchSQL(string searchString)
        {
            return string.Format(@"
                SELECT ID$         = INS.BaInstitutionID,
                       Institution = INS.NameVorname,
                       Strasse     = INS.StrasseHausNr,
                       Ort         = INS.PLZOrt
                FROM dbo.vwInstitution INS WITH (READUNCOMMITTED)
                WHERE (',' + dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 1, ',', {1}, 1) + ',' LIKE '%,{2},%')
                  AND INS.NameVorname LIKE '%' + {0} + '%'
                ORDER BY INS.NameVorname;", DBUtil.SqlLiteral(searchString), Session.User.UserID, BAINSTITUTIONTYPID_KK);
        }

        #endregion

        #region Public Methods

        public void Init(string TitleName, Image TitleImage, int PersonID, bool IsFallTraeger)
        {
            BaPersonID = PersonID;
            lblTitel.Text = TitleName;
            picTitel.Image = TitleImage;

            //Filter out "weiss nicht"
            SqlQuery qry = (SqlQuery)cboPflegeDurch.Properties.DataSource;
            qry.DataTable.DefaultView.RowFilter = "Code <> 99999";

            //Gesundheit
            qryGesundheit.Fill(BaPersonID);
        }

        #endregion

        #region Private Methods

        // Letzte Bearbeitung
        // 04.10.2007 : RH : alles neu
        // ------------------------------------------------------------------------------
        private void SetPraemie()
        {
            Decimal Betrag = (Decimal)0.0;
            Betrag += Utils.ConvertToDecimal(qryGesundheit["KVGGrundpraemie"]);
            Betrag += Utils.ConvertToDecimal(qryGesundheit["KVGUnfallPraemie"]);
            Betrag += Utils.ConvertToDecimal(qryGesundheit["KVGGesundFoerdPraemie"]);
            if (chkKVGZuschussUnregelmaessig.Checked)
                Betrag -= Utils.ConvertToDecimal(qryGesundheit["KVGZuschussBetrag"]);
            Betrag -= Utils.ConvertToDecimal(qryGesundheit["KVGUmweltabgabeBetrag"]);

            qryGesundheit["KVGPraemie"] = Betrag;
            qryGesundheit.RefreshDisplay();
        }

        #endregion

        #endregion
    }
}