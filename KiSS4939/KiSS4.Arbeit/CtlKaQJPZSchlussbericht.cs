using System;
using System.Drawing;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
	/// <summary>
	/// Summary description for CtlKaQJPZSchlussbericht.
	/// </summary>
	public class CtlKaQJPZSchlussbericht : KissUserControl
	{
		private System.ComponentModel.IContainer components;

		private int FaLeistungID = 0;
		private int BaPersonID = 0;
		private System.Windows.Forms.Label lblTitel;
		private System.Windows.Forms.PictureBox picTitle;
		private KiSS4.DB.SqlQuery qrySchlussbericht;
		private System.Windows.Forms.Label lblMerkmale;
		private System.Windows.Forms.Label lblArbeitsverhalten;
		private System.Windows.Forms.Label lblFaehigkeiten;
		private KiSS4.Gui.KissLookUpEdit ddlAQualitaet;
		private KiSS4.Gui.KissLabel lblAQualitaet;
		private KiSS4.Gui.KissCheckEdit chkDeutsch;
		private KiSS4.Gui.KissCheckEdit chkFranz;
		private KiSS4.Gui.KissLookUpEdit ddlAtempo;
		private KiSS4.Gui.KissLabel lblATempo;
		private KiSS4.Gui.KissLookUpEdit ddlAOrganisation;
		private KiSS4.Gui.KissLabel lblAOrganisation;
		private KiSS4.Gui.KissLookUpEdit ddlLernfaehigkeit;
		private KiSS4.Gui.KissLabel lblLernfaehigkeit;
		private KiSS4.Gui.KissLookUpEdit ddlLandessprache;
		private KiSS4.Gui.KissLabel lblLandessprache;
		private KiSS4.Gui.KissLookUpEdit ddlOrdnung;
		private KiSS4.Gui.KissLabel lblOrdnung;
		private KiSS4.Gui.KissLookUpEdit ddlAusdauer;
		private KiSS4.Gui.KissLabel lblAusdauer;
		private KiSS4.Gui.KissLookUpEdit ddlPuenktlich;
		private KiSS4.Gui.KissLabel lblPuenktlich;
		private KiSS4.Gui.KissLookUpEdit ddlZuverlaessig;
		private KiSS4.Gui.KissLabel lblZuverlaessig;
		private KiSS4.Gui.KissLookUpEdit ddlSelbstaendig;
		private KiSS4.Gui.KissLabel lblSelbstaendig;
		private KiSS4.Gui.KissLookUpEdit ddlFlexibilitaet;
		private KiSS4.Gui.KissLabel lblFlexibilitaet;
		private KiSS4.Gui.KissLookUpEdit ddlKritikfaehig;
		private KiSS4.Gui.KissLabel lblKritikfaehig;
		private KiSS4.Gui.KissLookUpEdit ddlTeamfaehig;
		private KiSS4.Gui.KissLabel lblTeamfaehig;
		private KiSS4.Gui.KissLookUpEdit ddlKommunikation;
		private KiSS4.Gui.KissLabel lblKommunikation;
		private KiSS4.Gui.KissLookUpEdit ddlAuftreten;
		private KiSS4.Gui.KissLabel lblAuftreten;
		private KiSS4.Gui.KissLookUpEdit ddlSorgfalt;
		private KiSS4.Gui.KissLabel lblSorgfalt;
		private KiSS4.Gui.KissLookUpEdit ddlMotivation;
		private KiSS4.Gui.KissLabel lblMotivation;
		private KiSS4.Gui.KissLookUpEdit ddlErscheinung;
		private KiSS4.Gui.KissLabel lblErscheinung;
		private KiSS4.Gui.KissMemoEdit memFachkompetenz;
		private KiSS4.Gui.KissLabel lblFachkompetenz;
		private KiSS4.Gui.KissMemoEdit memBildung;
		private KiSS4.Gui.KissLabel lblBildung;
		private KiSS4.Gui.KissMemoEdit memZielvereinbarung;
		private KiSS4.Gui.KissLabel lblZielvereinbarung;
		private KiSS4.Gui.KissMemoEdit memAbsenzen;
		private KiSS4.Gui.KissLabel lblAbsenzen;
		private KiSS4.Gui.KissMemoEdit memEmpfehlung;
		private KiSS4.Gui.KissLabel lblEmpfehlung;
		private KiSS4.Gui.KissLabel lblSemo;
		private KiSS4.Gui.KissCheckEdit chkEingVermittelbarkeit;
		private KiSS4.Gui.KissMemoEdit memEingVermittelbarkeit;
		private KiSS4.Dokument.XDokument docSchlussbericht;
		private KiSS4.Gui.KissLabel lblBeurteilung;
		private KiSS4.Gui.KissDateEdit datBeurteilung;
		private KiSS4.Gui.KissLabel lblSchlussbericht;

		bool MayRead = false;
		bool MayIns = false;
		bool MayUpd = false;
		bool MayDel = false;
		bool MayClose = false;
		private KiSS4.Gui.KissLabel lblSemoGrund;
		bool MayReopen = false;

		public CtlKaQJPZSchlussbericht()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaQJPZSchlussbericht));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject20 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject21 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject22 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject23 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject19 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject18 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblTitel = new System.Windows.Forms.Label();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.qrySchlussbericht = new KiSS4.DB.SqlQuery(this.components);
            this.lblMerkmale = new System.Windows.Forms.Label();
            this.lblArbeitsverhalten = new System.Windows.Forms.Label();
            this.lblFaehigkeiten = new System.Windows.Forms.Label();
            this.docSchlussbericht = new KiSS4.Dokument.XDokument();
            this.memFachkompetenz = new KiSS4.Gui.KissMemoEdit();
            this.lblFachkompetenz = new KiSS4.Gui.KissLabel();
            this.ddlAQualitaet = new KiSS4.Gui.KissLookUpEdit();
            this.lblAQualitaet = new KiSS4.Gui.KissLabel();
            this.chkDeutsch = new KiSS4.Gui.KissCheckEdit();
            this.chkFranz = new KiSS4.Gui.KissCheckEdit();
            this.ddlAtempo = new KiSS4.Gui.KissLookUpEdit();
            this.lblATempo = new KiSS4.Gui.KissLabel();
            this.ddlAOrganisation = new KiSS4.Gui.KissLookUpEdit();
            this.lblAOrganisation = new KiSS4.Gui.KissLabel();
            this.ddlLernfaehigkeit = new KiSS4.Gui.KissLookUpEdit();
            this.lblLernfaehigkeit = new KiSS4.Gui.KissLabel();
            this.ddlLandessprache = new KiSS4.Gui.KissLookUpEdit();
            this.lblLandessprache = new KiSS4.Gui.KissLabel();
            this.ddlOrdnung = new KiSS4.Gui.KissLookUpEdit();
            this.lblOrdnung = new KiSS4.Gui.KissLabel();
            this.ddlAusdauer = new KiSS4.Gui.KissLookUpEdit();
            this.lblAusdauer = new KiSS4.Gui.KissLabel();
            this.ddlPuenktlich = new KiSS4.Gui.KissLookUpEdit();
            this.lblPuenktlich = new KiSS4.Gui.KissLabel();
            this.ddlZuverlaessig = new KiSS4.Gui.KissLookUpEdit();
            this.lblZuverlaessig = new KiSS4.Gui.KissLabel();
            this.ddlSelbstaendig = new KiSS4.Gui.KissLookUpEdit();
            this.lblSelbstaendig = new KiSS4.Gui.KissLabel();
            this.ddlFlexibilitaet = new KiSS4.Gui.KissLookUpEdit();
            this.lblFlexibilitaet = new KiSS4.Gui.KissLabel();
            this.ddlKritikfaehig = new KiSS4.Gui.KissLookUpEdit();
            this.lblKritikfaehig = new KiSS4.Gui.KissLabel();
            this.ddlTeamfaehig = new KiSS4.Gui.KissLookUpEdit();
            this.lblTeamfaehig = new KiSS4.Gui.KissLabel();
            this.ddlKommunikation = new KiSS4.Gui.KissLookUpEdit();
            this.lblKommunikation = new KiSS4.Gui.KissLabel();
            this.ddlAuftreten = new KiSS4.Gui.KissLookUpEdit();
            this.lblAuftreten = new KiSS4.Gui.KissLabel();
            this.ddlSorgfalt = new KiSS4.Gui.KissLookUpEdit();
            this.lblSorgfalt = new KiSS4.Gui.KissLabel();
            this.ddlMotivation = new KiSS4.Gui.KissLookUpEdit();
            this.lblMotivation = new KiSS4.Gui.KissLabel();
            this.ddlErscheinung = new KiSS4.Gui.KissLookUpEdit();
            this.lblErscheinung = new KiSS4.Gui.KissLabel();
            this.memBildung = new KiSS4.Gui.KissMemoEdit();
            this.lblBildung = new KiSS4.Gui.KissLabel();
            this.memZielvereinbarung = new KiSS4.Gui.KissMemoEdit();
            this.lblZielvereinbarung = new KiSS4.Gui.KissLabel();
            this.memAbsenzen = new KiSS4.Gui.KissMemoEdit();
            this.lblAbsenzen = new KiSS4.Gui.KissLabel();
            this.memEmpfehlung = new KiSS4.Gui.KissMemoEdit();
            this.lblEmpfehlung = new KiSS4.Gui.KissLabel();
            this.lblSemo = new KiSS4.Gui.KissLabel();
            this.lblBeurteilung = new KiSS4.Gui.KissLabel();
            this.datBeurteilung = new KiSS4.Gui.KissDateEdit();
            this.chkEingVermittelbarkeit = new KiSS4.Gui.KissCheckEdit();
            this.memEingVermittelbarkeit = new KiSS4.Gui.KissMemoEdit();
            this.lblSchlussbericht = new KiSS4.Gui.KissLabel();
            this.lblSemoGrund = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySchlussbericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSchlussbericht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memFachkompetenz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFachkompetenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAQualitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAQualitaet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAQualitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeutsch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFranz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAtempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAtempo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblATempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAOrganisation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAOrganisation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAOrganisation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLernfaehigkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLernfaehigkeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLernfaehigkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLandessprache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLandessprache.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLandessprache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlOrdnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlOrdnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrdnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAusdauer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAusdauer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusdauer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPuenktlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPuenktlich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPuenktlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlZuverlaessig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlZuverlaessig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZuverlaessig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSelbstaendig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSelbstaendig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelbstaendig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlFlexibilitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlFlexibilitaet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFlexibilitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlKritikfaehig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlKritikfaehig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKritikfaehig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTeamfaehig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTeamfaehig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeamfaehig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlKommunikation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlKommunikation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKommunikation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAuftreten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAuftreten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuftreten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSorgfalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSorgfalt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSorgfalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMotivation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMotivation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMotivation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlErscheinung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlErscheinung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErscheinung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBildung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memZielvereinbarung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZielvereinbarung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAbsenzen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbsenzen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memEmpfehlung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmpfehlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeurteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datBeurteilung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEingVermittelbarkeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memEingVermittelbarkeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchlussbericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSemoGrund)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 106;
            this.lblTitel.Text = "Titel";
            // 
            // picTitle
            // 
            this.picTitle.Image = ((System.Drawing.Image)(resources.GetObject("picTitle.Image")));
            this.picTitle.Location = new System.Drawing.Point(10, 9);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(25, 20);
            this.picTitle.TabIndex = 105;
            this.picTitle.TabStop = false;
            // 
            // qrySchlussbericht
            // 
            this.qrySchlussbericht.CanUpdate = true;
            this.qrySchlussbericht.HostControl = this;
            this.qrySchlussbericht.TableName = "KaQJPZSchlussbericht";
            // 
            // lblMerkmale
            // 
            this.lblMerkmale.AutoSize = true;
            this.lblMerkmale.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblMerkmale.ForeColor = System.Drawing.Color.Black;
            this.lblMerkmale.Location = new System.Drawing.Point(560, 50);
            this.lblMerkmale.Name = "lblMerkmale";
            this.lblMerkmale.Size = new System.Drawing.Size(135, 15);
            this.lblMerkmale.TabIndex = 113;
            this.lblMerkmale.Text = "Persönliche Merkmale";
            // 
            // lblArbeitsverhalten
            // 
            this.lblArbeitsverhalten.AutoSize = true;
            this.lblArbeitsverhalten.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblArbeitsverhalten.ForeColor = System.Drawing.Color.Black;
            this.lblArbeitsverhalten.Location = new System.Drawing.Point(310, 50);
            this.lblArbeitsverhalten.Name = "lblArbeitsverhalten";
            this.lblArbeitsverhalten.Size = new System.Drawing.Size(101, 15);
            this.lblArbeitsverhalten.TabIndex = 112;
            this.lblArbeitsverhalten.Text = "Arbeitsverhalten";
            // 
            // lblFaehigkeiten
            // 
            this.lblFaehigkeiten.AutoSize = true;
            this.lblFaehigkeiten.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblFaehigkeiten.ForeColor = System.Drawing.Color.Black;
            this.lblFaehigkeiten.Location = new System.Drawing.Point(10, 50);
            this.lblFaehigkeiten.Name = "lblFaehigkeiten";
            this.lblFaehigkeiten.Size = new System.Drawing.Size(138, 15);
            this.lblFaehigkeiten.TabIndex = 111;
            this.lblFaehigkeiten.Text = "Allgemeine Fähigkeiten";
            // 
            // docSchlussbericht
            // 
            this.docSchlussbericht.AllowDrop = true;
            this.docSchlussbericht.Context = "KaQJPZSchlussbericht";
            this.docSchlussbericht.DataMember = "SchlussberichtDokID";
            this.docSchlussbericht.DataSource = this.qrySchlussbericht;
            this.docSchlussbericht.Location = new System.Drawing.Point(125, 630);
            this.docSchlussbericht.Name = "docSchlussbericht";
            this.docSchlussbericht.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docSchlussbericht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docSchlussbericht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docSchlussbericht.Properties.Appearance.Options.UseBackColor = true;
            this.docSchlussbericht.Properties.Appearance.Options.UseBorderColor = true;
            this.docSchlussbericht.Properties.Appearance.Options.UseFont = true;
            this.docSchlussbericht.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docSchlussbericht.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docSchlussbericht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject20.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject20.Options.UseBackColor = true;
            serializableAppearanceObject21.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject21.Options.UseBackColor = true;
            serializableAppearanceObject22.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject22.Options.UseBackColor = true;
            serializableAppearanceObject23.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject23.Options.UseBackColor = true;
            this.docSchlussbericht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docSchlussbericht.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject20, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docSchlussbericht.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject21, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docSchlussbericht.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject22, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docSchlussbericht.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject23, "Dokument importieren")});
            this.docSchlussbericht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docSchlussbericht.Properties.ReadOnly = true;
            this.docSchlussbericht.Size = new System.Drawing.Size(136, 24);
            this.docSchlussbericht.TabIndex = 25;
            // 
            // memFachkompetenz
            // 
            this.memFachkompetenz.DataMember = "BemKompetenz";
            this.memFachkompetenz.DataSource = this.qrySchlussbericht;
            this.memFachkompetenz.Location = new System.Drawing.Point(10, 300);
            this.memFachkompetenz.Name = "memFachkompetenz";
            this.memFachkompetenz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memFachkompetenz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memFachkompetenz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memFachkompetenz.Properties.Appearance.Options.UseBackColor = true;
            this.memFachkompetenz.Properties.Appearance.Options.UseBorderColor = true;
            this.memFachkompetenz.Properties.Appearance.Options.UseFont = true;
            this.memFachkompetenz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memFachkompetenz.Size = new System.Drawing.Size(395, 85);
            this.memFachkompetenz.TabIndex = 20;
            // 
            // lblFachkompetenz
            // 
            this.lblFachkompetenz.ForeColor = System.Drawing.Color.Black;
            this.lblFachkompetenz.Location = new System.Drawing.Point(10, 275);
            this.lblFachkompetenz.Name = "lblFachkompetenz";
            this.lblFachkompetenz.Size = new System.Drawing.Size(385, 24);
            this.lblFachkompetenz.TabIndex = 575;
            this.lblFachkompetenz.Text = "Einschätzung der Fachkompetenz";
            // 
            // ddlAQualitaet
            // 
            this.ddlAQualitaet.DataMember = "AQualitaetCode";
            this.ddlAQualitaet.DataSource = this.qrySchlussbericht;
            this.ddlAQualitaet.Location = new System.Drawing.Point(195, 75);
            this.ddlAQualitaet.LOVName = "KaQjBerichtCodes";
            this.ddlAQualitaet.Name = "ddlAQualitaet";
            this.ddlAQualitaet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlAQualitaet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlAQualitaet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAQualitaet.Properties.Appearance.Options.UseBackColor = true;
            this.ddlAQualitaet.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlAQualitaet.Properties.Appearance.Options.UseFont = true;
            this.ddlAQualitaet.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlAQualitaet.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAQualitaet.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlAQualitaet.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlAQualitaet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            this.ddlAQualitaet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19)});
            this.ddlAQualitaet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlAQualitaet.Properties.NullText = "";
            this.ddlAQualitaet.Properties.ShowFooter = false;
            this.ddlAQualitaet.Properties.ShowHeader = false;
            this.ddlAQualitaet.Size = new System.Drawing.Size(45, 24);
            this.ddlAQualitaet.TabIndex = 0;
            // 
            // lblAQualitaet
            // 
            this.lblAQualitaet.Location = new System.Drawing.Point(10, 75);
            this.lblAQualitaet.Name = "lblAQualitaet";
            this.lblAQualitaet.Size = new System.Drawing.Size(145, 24);
            this.lblAQualitaet.TabIndex = 577;
            this.lblAQualitaet.Text = "Arbeitsqualität";
            // 
            // chkDeutsch
            // 
            this.chkDeutsch.DataMember = "DeutschFlag";
            this.chkDeutsch.DataSource = this.qrySchlussbericht;
            this.chkDeutsch.Location = new System.Drawing.Point(10, 210);
            this.chkDeutsch.Name = "chkDeutsch";
            this.chkDeutsch.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkDeutsch.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.chkDeutsch.Properties.Appearance.Options.UseBackColor = true;
            this.chkDeutsch.Properties.Appearance.Options.UseForeColor = true;
            this.chkDeutsch.Properties.Caption = "  Deutsch";
            this.chkDeutsch.Size = new System.Drawing.Size(90, 19);
            this.chkDeutsch.TabIndex = 5;
            // 
            // chkFranz
            // 
            this.chkFranz.DataMember = "FranzFlag";
            this.chkFranz.DataSource = this.qrySchlussbericht;
            this.chkFranz.Location = new System.Drawing.Point(105, 210);
            this.chkFranz.Name = "chkFranz";
            this.chkFranz.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkFranz.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.chkFranz.Properties.Appearance.Options.UseBackColor = true;
            this.chkFranz.Properties.Appearance.Options.UseForeColor = true;
            this.chkFranz.Properties.Caption = "  Französisch";
            this.chkFranz.Size = new System.Drawing.Size(110, 19);
            this.chkFranz.TabIndex = 6;
            // 
            // ddlAtempo
            // 
            this.ddlAtempo.DataMember = "ATempoCode";
            this.ddlAtempo.DataSource = this.qrySchlussbericht;
            this.ddlAtempo.Location = new System.Drawing.Point(195, 100);
            this.ddlAtempo.LOVName = "KaQjBerichtCodes";
            this.ddlAtempo.Name = "ddlAtempo";
            this.ddlAtempo.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlAtempo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlAtempo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAtempo.Properties.Appearance.Options.UseBackColor = true;
            this.ddlAtempo.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlAtempo.Properties.Appearance.Options.UseFont = true;
            this.ddlAtempo.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlAtempo.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAtempo.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlAtempo.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlAtempo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.ddlAtempo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.ddlAtempo.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlAtempo.Properties.NullText = "";
            this.ddlAtempo.Properties.ShowFooter = false;
            this.ddlAtempo.Properties.ShowHeader = false;
            this.ddlAtempo.Size = new System.Drawing.Size(45, 24);
            this.ddlAtempo.TabIndex = 1;
            // 
            // lblATempo
            // 
            this.lblATempo.Location = new System.Drawing.Point(10, 100);
            this.lblATempo.Name = "lblATempo";
            this.lblATempo.Size = new System.Drawing.Size(145, 24);
            this.lblATempo.TabIndex = 582;
            this.lblATempo.Text = "Arbeitstempo/-menge";
            // 
            // ddlAOrganisation
            // 
            this.ddlAOrganisation.DataMember = "AOrganisationCode";
            this.ddlAOrganisation.DataSource = this.qrySchlussbericht;
            this.ddlAOrganisation.Location = new System.Drawing.Point(195, 125);
            this.ddlAOrganisation.LOVName = "KaQjBerichtCodes";
            this.ddlAOrganisation.Name = "ddlAOrganisation";
            this.ddlAOrganisation.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlAOrganisation.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlAOrganisation.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAOrganisation.Properties.Appearance.Options.UseBackColor = true;
            this.ddlAOrganisation.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlAOrganisation.Properties.Appearance.Options.UseFont = true;
            this.ddlAOrganisation.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlAOrganisation.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAOrganisation.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlAOrganisation.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlAOrganisation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.ddlAOrganisation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.ddlAOrganisation.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlAOrganisation.Properties.NullText = "";
            this.ddlAOrganisation.Properties.ShowFooter = false;
            this.ddlAOrganisation.Properties.ShowHeader = false;
            this.ddlAOrganisation.Size = new System.Drawing.Size(45, 24);
            this.ddlAOrganisation.TabIndex = 2;
            // 
            // lblAOrganisation
            // 
            this.lblAOrganisation.Location = new System.Drawing.Point(10, 125);
            this.lblAOrganisation.Name = "lblAOrganisation";
            this.lblAOrganisation.Size = new System.Drawing.Size(145, 24);
            this.lblAOrganisation.TabIndex = 584;
            this.lblAOrganisation.Text = "Arbeitsorganisation";
            // 
            // ddlLernfaehigkeit
            // 
            this.ddlLernfaehigkeit.DataMember = "LernfaehigkeitCode";
            this.ddlLernfaehigkeit.DataSource = this.qrySchlussbericht;
            this.ddlLernfaehigkeit.Location = new System.Drawing.Point(195, 150);
            this.ddlLernfaehigkeit.LOVName = "KaQjBerichtCodes";
            this.ddlLernfaehigkeit.Name = "ddlLernfaehigkeit";
            this.ddlLernfaehigkeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlLernfaehigkeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlLernfaehigkeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlLernfaehigkeit.Properties.Appearance.Options.UseBackColor = true;
            this.ddlLernfaehigkeit.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlLernfaehigkeit.Properties.Appearance.Options.UseFont = true;
            this.ddlLernfaehigkeit.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlLernfaehigkeit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlLernfaehigkeit.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlLernfaehigkeit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlLernfaehigkeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.ddlLernfaehigkeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.ddlLernfaehigkeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlLernfaehigkeit.Properties.NullText = "";
            this.ddlLernfaehigkeit.Properties.ShowFooter = false;
            this.ddlLernfaehigkeit.Properties.ShowHeader = false;
            this.ddlLernfaehigkeit.Size = new System.Drawing.Size(45, 24);
            this.ddlLernfaehigkeit.TabIndex = 3;
            // 
            // lblLernfaehigkeit
            // 
            this.lblLernfaehigkeit.Location = new System.Drawing.Point(10, 150);
            this.lblLernfaehigkeit.Name = "lblLernfaehigkeit";
            this.lblLernfaehigkeit.Size = new System.Drawing.Size(145, 24);
            this.lblLernfaehigkeit.TabIndex = 586;
            this.lblLernfaehigkeit.Text = "Lernfähigkeit";
            // 
            // ddlLandessprache
            // 
            this.ddlLandessprache.DataMember = "LandesspracheCode";
            this.ddlLandessprache.DataSource = this.qrySchlussbericht;
            this.ddlLandessprache.Location = new System.Drawing.Point(195, 175);
            this.ddlLandessprache.LOVName = "KaQjBerichtCodes";
            this.ddlLandessprache.Name = "ddlLandessprache";
            this.ddlLandessprache.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlLandessprache.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlLandessprache.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlLandessprache.Properties.Appearance.Options.UseBackColor = true;
            this.ddlLandessprache.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlLandessprache.Properties.Appearance.Options.UseFont = true;
            this.ddlLandessprache.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlLandessprache.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlLandessprache.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlLandessprache.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlLandessprache.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.ddlLandessprache.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.ddlLandessprache.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlLandessprache.Properties.NullText = "";
            this.ddlLandessprache.Properties.ShowFooter = false;
            this.ddlLandessprache.Properties.ShowHeader = false;
            this.ddlLandessprache.Size = new System.Drawing.Size(45, 24);
            this.ddlLandessprache.TabIndex = 4;
            // 
            // lblLandessprache
            // 
            this.lblLandessprache.Location = new System.Drawing.Point(10, 175);
            this.lblLandessprache.Name = "lblLandessprache";
            this.lblLandessprache.Size = new System.Drawing.Size(180, 24);
            this.lblLandessprache.TabIndex = 588;
            this.lblLandessprache.Text = "Kenntnisse lokale Landessprache";
            // 
            // ddlOrdnung
            // 
            this.ddlOrdnung.DataMember = "OrdnungCode";
            this.ddlOrdnung.DataSource = this.qrySchlussbericht;
            this.ddlOrdnung.Location = new System.Drawing.Point(445, 175);
            this.ddlOrdnung.LOVName = "KaQjBerichtCodes";
            this.ddlOrdnung.Name = "ddlOrdnung";
            this.ddlOrdnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlOrdnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlOrdnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlOrdnung.Properties.Appearance.Options.UseBackColor = true;
            this.ddlOrdnung.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlOrdnung.Properties.Appearance.Options.UseFont = true;
            this.ddlOrdnung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlOrdnung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlOrdnung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlOrdnung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlOrdnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.ddlOrdnung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.ddlOrdnung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlOrdnung.Properties.NullText = "";
            this.ddlOrdnung.Properties.ShowFooter = false;
            this.ddlOrdnung.Properties.ShowHeader = false;
            this.ddlOrdnung.Size = new System.Drawing.Size(45, 24);
            this.ddlOrdnung.TabIndex = 11;
            // 
            // lblOrdnung
            // 
            this.lblOrdnung.Location = new System.Drawing.Point(310, 175);
            this.lblOrdnung.Name = "lblOrdnung";
            this.lblOrdnung.Size = new System.Drawing.Size(180, 24);
            this.lblOrdnung.TabIndex = 598;
            this.lblOrdnung.Text = "Ordnung";
            // 
            // ddlAusdauer
            // 
            this.ddlAusdauer.DataMember = "AusdauerCode";
            this.ddlAusdauer.DataSource = this.qrySchlussbericht;
            this.ddlAusdauer.Location = new System.Drawing.Point(445, 150);
            this.ddlAusdauer.LOVName = "KaQjBerichtCodes";
            this.ddlAusdauer.Name = "ddlAusdauer";
            this.ddlAusdauer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlAusdauer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlAusdauer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAusdauer.Properties.Appearance.Options.UseBackColor = true;
            this.ddlAusdauer.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlAusdauer.Properties.Appearance.Options.UseFont = true;
            this.ddlAusdauer.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlAusdauer.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAusdauer.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlAusdauer.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlAusdauer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.ddlAusdauer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.ddlAusdauer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlAusdauer.Properties.NullText = "";
            this.ddlAusdauer.Properties.ShowFooter = false;
            this.ddlAusdauer.Properties.ShowHeader = false;
            this.ddlAusdauer.Size = new System.Drawing.Size(45, 24);
            this.ddlAusdauer.TabIndex = 10;
            // 
            // lblAusdauer
            // 
            this.lblAusdauer.Location = new System.Drawing.Point(310, 150);
            this.lblAusdauer.Name = "lblAusdauer";
            this.lblAusdauer.Size = new System.Drawing.Size(145, 24);
            this.lblAusdauer.TabIndex = 597;
            this.lblAusdauer.Text = "Einsatz und Ausdauer";
            // 
            // ddlPuenktlich
            // 
            this.ddlPuenktlich.DataMember = "PuenktlichCode";
            this.ddlPuenktlich.DataSource = this.qrySchlussbericht;
            this.ddlPuenktlich.Location = new System.Drawing.Point(445, 125);
            this.ddlPuenktlich.LOVName = "KaQjBerichtCodes";
            this.ddlPuenktlich.Name = "ddlPuenktlich";
            this.ddlPuenktlich.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlPuenktlich.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlPuenktlich.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlPuenktlich.Properties.Appearance.Options.UseBackColor = true;
            this.ddlPuenktlich.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlPuenktlich.Properties.Appearance.Options.UseFont = true;
            this.ddlPuenktlich.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlPuenktlich.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlPuenktlich.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlPuenktlich.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlPuenktlich.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.ddlPuenktlich.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.ddlPuenktlich.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlPuenktlich.Properties.NullText = "";
            this.ddlPuenktlich.Properties.ShowFooter = false;
            this.ddlPuenktlich.Properties.ShowHeader = false;
            this.ddlPuenktlich.Size = new System.Drawing.Size(45, 24);
            this.ddlPuenktlich.TabIndex = 9;
            // 
            // lblPuenktlich
            // 
            this.lblPuenktlich.Location = new System.Drawing.Point(310, 125);
            this.lblPuenktlich.Name = "lblPuenktlich";
            this.lblPuenktlich.Size = new System.Drawing.Size(145, 24);
            this.lblPuenktlich.TabIndex = 596;
            this.lblPuenktlich.Text = "Pünktlichkeit";
            // 
            // ddlZuverlaessig
            // 
            this.ddlZuverlaessig.DataMember = "ZuverlaessigCode";
            this.ddlZuverlaessig.DataSource = this.qrySchlussbericht;
            this.ddlZuverlaessig.Location = new System.Drawing.Point(445, 100);
            this.ddlZuverlaessig.LOVName = "KaQjBerichtCodes";
            this.ddlZuverlaessig.Name = "ddlZuverlaessig";
            this.ddlZuverlaessig.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlZuverlaessig.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlZuverlaessig.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlZuverlaessig.Properties.Appearance.Options.UseBackColor = true;
            this.ddlZuverlaessig.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlZuverlaessig.Properties.Appearance.Options.UseFont = true;
            this.ddlZuverlaessig.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlZuverlaessig.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlZuverlaessig.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlZuverlaessig.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlZuverlaessig.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.ddlZuverlaessig.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.ddlZuverlaessig.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlZuverlaessig.Properties.NullText = "";
            this.ddlZuverlaessig.Properties.ShowFooter = false;
            this.ddlZuverlaessig.Properties.ShowHeader = false;
            this.ddlZuverlaessig.Size = new System.Drawing.Size(45, 24);
            this.ddlZuverlaessig.TabIndex = 8;
            // 
            // lblZuverlaessig
            // 
            this.lblZuverlaessig.Location = new System.Drawing.Point(310, 100);
            this.lblZuverlaessig.Name = "lblZuverlaessig";
            this.lblZuverlaessig.Size = new System.Drawing.Size(145, 24);
            this.lblZuverlaessig.TabIndex = 595;
            this.lblZuverlaessig.Text = "Zuverlässigkeit";
            // 
            // ddlSelbstaendig
            // 
            this.ddlSelbstaendig.DataMember = "SelbstaendigCode";
            this.ddlSelbstaendig.DataSource = this.qrySchlussbericht;
            this.ddlSelbstaendig.Location = new System.Drawing.Point(445, 75);
            this.ddlSelbstaendig.LOVName = "KaQjBerichtCodes";
            this.ddlSelbstaendig.Name = "ddlSelbstaendig";
            this.ddlSelbstaendig.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlSelbstaendig.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlSelbstaendig.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlSelbstaendig.Properties.Appearance.Options.UseBackColor = true;
            this.ddlSelbstaendig.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlSelbstaendig.Properties.Appearance.Options.UseFont = true;
            this.ddlSelbstaendig.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlSelbstaendig.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlSelbstaendig.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlSelbstaendig.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlSelbstaendig.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.ddlSelbstaendig.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.ddlSelbstaendig.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlSelbstaendig.Properties.NullText = "";
            this.ddlSelbstaendig.Properties.ShowFooter = false;
            this.ddlSelbstaendig.Properties.ShowHeader = false;
            this.ddlSelbstaendig.Size = new System.Drawing.Size(45, 24);
            this.ddlSelbstaendig.TabIndex = 7;
            // 
            // lblSelbstaendig
            // 
            this.lblSelbstaendig.Location = new System.Drawing.Point(310, 75);
            this.lblSelbstaendig.Name = "lblSelbstaendig";
            this.lblSelbstaendig.Size = new System.Drawing.Size(145, 24);
            this.lblSelbstaendig.TabIndex = 594;
            this.lblSelbstaendig.Text = "Selbständigkeit";
            // 
            // ddlFlexibilitaet
            // 
            this.ddlFlexibilitaet.DataMember = "FlexibilitaetCode";
            this.ddlFlexibilitaet.DataSource = this.qrySchlussbericht;
            this.ddlFlexibilitaet.Location = new System.Drawing.Point(745, 175);
            this.ddlFlexibilitaet.LOVName = "KaQjBerichtCodes";
            this.ddlFlexibilitaet.Name = "ddlFlexibilitaet";
            this.ddlFlexibilitaet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlFlexibilitaet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlFlexibilitaet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlFlexibilitaet.Properties.Appearance.Options.UseBackColor = true;
            this.ddlFlexibilitaet.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlFlexibilitaet.Properties.Appearance.Options.UseFont = true;
            this.ddlFlexibilitaet.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlFlexibilitaet.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlFlexibilitaet.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlFlexibilitaet.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlFlexibilitaet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.ddlFlexibilitaet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.ddlFlexibilitaet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlFlexibilitaet.Properties.NullText = "";
            this.ddlFlexibilitaet.Properties.ShowFooter = false;
            this.ddlFlexibilitaet.Properties.ShowHeader = false;
            this.ddlFlexibilitaet.Size = new System.Drawing.Size(45, 24);
            this.ddlFlexibilitaet.TabIndex = 17;
            // 
            // lblFlexibilitaet
            // 
            this.lblFlexibilitaet.Location = new System.Drawing.Point(560, 175);
            this.lblFlexibilitaet.Name = "lblFlexibilitaet";
            this.lblFlexibilitaet.Size = new System.Drawing.Size(180, 24);
            this.lblFlexibilitaet.TabIndex = 608;
            this.lblFlexibilitaet.Text = "Flexibilität";
            // 
            // ddlKritikfaehig
            // 
            this.ddlKritikfaehig.DataMember = "KritikfaehigCode";
            this.ddlKritikfaehig.DataSource = this.qrySchlussbericht;
            this.ddlKritikfaehig.Location = new System.Drawing.Point(745, 150);
            this.ddlKritikfaehig.LOVName = "KaQjBerichtCodes";
            this.ddlKritikfaehig.Name = "ddlKritikfaehig";
            this.ddlKritikfaehig.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlKritikfaehig.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlKritikfaehig.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlKritikfaehig.Properties.Appearance.Options.UseBackColor = true;
            this.ddlKritikfaehig.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlKritikfaehig.Properties.Appearance.Options.UseFont = true;
            this.ddlKritikfaehig.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlKritikfaehig.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlKritikfaehig.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlKritikfaehig.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlKritikfaehig.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.ddlKritikfaehig.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.ddlKritikfaehig.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlKritikfaehig.Properties.NullText = "";
            this.ddlKritikfaehig.Properties.ShowFooter = false;
            this.ddlKritikfaehig.Properties.ShowHeader = false;
            this.ddlKritikfaehig.Size = new System.Drawing.Size(45, 24);
            this.ddlKritikfaehig.TabIndex = 16;
            // 
            // lblKritikfaehig
            // 
            this.lblKritikfaehig.Location = new System.Drawing.Point(560, 150);
            this.lblKritikfaehig.Name = "lblKritikfaehig";
            this.lblKritikfaehig.Size = new System.Drawing.Size(145, 24);
            this.lblKritikfaehig.TabIndex = 607;
            this.lblKritikfaehig.Text = "Kritikfähigkeit";
            // 
            // ddlTeamfaehig
            // 
            this.ddlTeamfaehig.DataMember = "TeamfaehigCode";
            this.ddlTeamfaehig.DataSource = this.qrySchlussbericht;
            this.ddlTeamfaehig.Location = new System.Drawing.Point(745, 125);
            this.ddlTeamfaehig.LOVName = "KaQjBerichtCodes";
            this.ddlTeamfaehig.Name = "ddlTeamfaehig";
            this.ddlTeamfaehig.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlTeamfaehig.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlTeamfaehig.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlTeamfaehig.Properties.Appearance.Options.UseBackColor = true;
            this.ddlTeamfaehig.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlTeamfaehig.Properties.Appearance.Options.UseFont = true;
            this.ddlTeamfaehig.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlTeamfaehig.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlTeamfaehig.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlTeamfaehig.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlTeamfaehig.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.ddlTeamfaehig.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.ddlTeamfaehig.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlTeamfaehig.Properties.NullText = "";
            this.ddlTeamfaehig.Properties.ShowFooter = false;
            this.ddlTeamfaehig.Properties.ShowHeader = false;
            this.ddlTeamfaehig.Size = new System.Drawing.Size(45, 24);
            this.ddlTeamfaehig.TabIndex = 15;
            // 
            // lblTeamfaehig
            // 
            this.lblTeamfaehig.Location = new System.Drawing.Point(560, 125);
            this.lblTeamfaehig.Name = "lblTeamfaehig";
            this.lblTeamfaehig.Size = new System.Drawing.Size(145, 24);
            this.lblTeamfaehig.TabIndex = 606;
            this.lblTeamfaehig.Text = "Teamfähigkeit";
            // 
            // ddlKommunikation
            // 
            this.ddlKommunikation.DataMember = "KommunikationCode";
            this.ddlKommunikation.DataSource = this.qrySchlussbericht;
            this.ddlKommunikation.Location = new System.Drawing.Point(745, 100);
            this.ddlKommunikation.LOVName = "KaQjBerichtCodes";
            this.ddlKommunikation.Name = "ddlKommunikation";
            this.ddlKommunikation.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlKommunikation.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlKommunikation.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlKommunikation.Properties.Appearance.Options.UseBackColor = true;
            this.ddlKommunikation.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlKommunikation.Properties.Appearance.Options.UseFont = true;
            this.ddlKommunikation.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlKommunikation.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlKommunikation.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlKommunikation.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlKommunikation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.ddlKommunikation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.ddlKommunikation.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlKommunikation.Properties.NullText = "";
            this.ddlKommunikation.Properties.ShowFooter = false;
            this.ddlKommunikation.Properties.ShowHeader = false;
            this.ddlKommunikation.Size = new System.Drawing.Size(45, 24);
            this.ddlKommunikation.TabIndex = 14;
            // 
            // lblKommunikation
            // 
            this.lblKommunikation.Location = new System.Drawing.Point(560, 100);
            this.lblKommunikation.Name = "lblKommunikation";
            this.lblKommunikation.Size = new System.Drawing.Size(145, 24);
            this.lblKommunikation.TabIndex = 605;
            this.lblKommunikation.Text = "Kommunikationsverhalten";
            // 
            // ddlAuftreten
            // 
            this.ddlAuftreten.DataMember = "AuftretenCode";
            this.ddlAuftreten.DataSource = this.qrySchlussbericht;
            this.ddlAuftreten.Location = new System.Drawing.Point(745, 75);
            this.ddlAuftreten.LOVName = "KaQjBerichtCodes";
            this.ddlAuftreten.Name = "ddlAuftreten";
            this.ddlAuftreten.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlAuftreten.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlAuftreten.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAuftreten.Properties.Appearance.Options.UseBackColor = true;
            this.ddlAuftreten.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlAuftreten.Properties.Appearance.Options.UseFont = true;
            this.ddlAuftreten.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlAuftreten.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAuftreten.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlAuftreten.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlAuftreten.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.ddlAuftreten.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.ddlAuftreten.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlAuftreten.Properties.NullText = "";
            this.ddlAuftreten.Properties.ShowFooter = false;
            this.ddlAuftreten.Properties.ShowHeader = false;
            this.ddlAuftreten.Size = new System.Drawing.Size(45, 24);
            this.ddlAuftreten.TabIndex = 13;
            // 
            // lblAuftreten
            // 
            this.lblAuftreten.Location = new System.Drawing.Point(560, 75);
            this.lblAuftreten.Name = "lblAuftreten";
            this.lblAuftreten.Size = new System.Drawing.Size(175, 24);
            this.lblAuftreten.TabIndex = 604;
            this.lblAuftreten.Text = "Auftreten und Umgangsformen";
            // 
            // ddlSorgfalt
            // 
            this.ddlSorgfalt.DataMember = "SorgfaltCode";
            this.ddlSorgfalt.DataSource = this.qrySchlussbericht;
            this.ddlSorgfalt.Location = new System.Drawing.Point(445, 200);
            this.ddlSorgfalt.LOVName = "KaQjBerichtCodes";
            this.ddlSorgfalt.Name = "ddlSorgfalt";
            this.ddlSorgfalt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlSorgfalt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlSorgfalt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlSorgfalt.Properties.Appearance.Options.UseBackColor = true;
            this.ddlSorgfalt.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlSorgfalt.Properties.Appearance.Options.UseFont = true;
            this.ddlSorgfalt.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlSorgfalt.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlSorgfalt.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlSorgfalt.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlSorgfalt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.ddlSorgfalt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.ddlSorgfalt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlSorgfalt.Properties.NullText = "";
            this.ddlSorgfalt.Properties.ShowFooter = false;
            this.ddlSorgfalt.Properties.ShowHeader = false;
            this.ddlSorgfalt.Size = new System.Drawing.Size(45, 24);
            this.ddlSorgfalt.TabIndex = 12;
            // 
            // lblSorgfalt
            // 
            this.lblSorgfalt.Location = new System.Drawing.Point(310, 200);
            this.lblSorgfalt.Name = "lblSorgfalt";
            this.lblSorgfalt.Size = new System.Drawing.Size(180, 24);
            this.lblSorgfalt.TabIndex = 610;
            this.lblSorgfalt.Text = "Sorgfalt";
            // 
            // ddlMotivation
            // 
            this.ddlMotivation.DataMember = "MotivationCode";
            this.ddlMotivation.DataSource = this.qrySchlussbericht;
            this.ddlMotivation.Location = new System.Drawing.Point(745, 200);
            this.ddlMotivation.LOVName = "KaQjBerichtCodes";
            this.ddlMotivation.Name = "ddlMotivation";
            this.ddlMotivation.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlMotivation.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlMotivation.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlMotivation.Properties.Appearance.Options.UseBackColor = true;
            this.ddlMotivation.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlMotivation.Properties.Appearance.Options.UseFont = true;
            this.ddlMotivation.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlMotivation.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlMotivation.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlMotivation.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlMotivation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.ddlMotivation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.ddlMotivation.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlMotivation.Properties.NullText = "";
            this.ddlMotivation.Properties.ShowFooter = false;
            this.ddlMotivation.Properties.ShowHeader = false;
            this.ddlMotivation.Size = new System.Drawing.Size(45, 24);
            this.ddlMotivation.TabIndex = 18;
            // 
            // lblMotivation
            // 
            this.lblMotivation.Location = new System.Drawing.Point(560, 200);
            this.lblMotivation.Name = "lblMotivation";
            this.lblMotivation.Size = new System.Drawing.Size(180, 24);
            this.lblMotivation.TabIndex = 612;
            this.lblMotivation.Text = "Motivation";
            // 
            // ddlErscheinung
            // 
            this.ddlErscheinung.DataMember = "ErscheinungCode";
            this.ddlErscheinung.DataSource = this.qrySchlussbericht;
            this.ddlErscheinung.Location = new System.Drawing.Point(745, 225);
            this.ddlErscheinung.LOVName = "KaQjBerichtCodes";
            this.ddlErscheinung.Name = "ddlErscheinung";
            this.ddlErscheinung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlErscheinung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlErscheinung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlErscheinung.Properties.Appearance.Options.UseBackColor = true;
            this.ddlErscheinung.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlErscheinung.Properties.Appearance.Options.UseFont = true;
            this.ddlErscheinung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlErscheinung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlErscheinung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlErscheinung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlErscheinung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.ddlErscheinung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.ddlErscheinung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlErscheinung.Properties.NullText = "";
            this.ddlErscheinung.Properties.ShowFooter = false;
            this.ddlErscheinung.Properties.ShowHeader = false;
            this.ddlErscheinung.Size = new System.Drawing.Size(45, 24);
            this.ddlErscheinung.TabIndex = 19;
            // 
            // lblErscheinung
            // 
            this.lblErscheinung.Location = new System.Drawing.Point(560, 225);
            this.lblErscheinung.Name = "lblErscheinung";
            this.lblErscheinung.Size = new System.Drawing.Size(180, 24);
            this.lblErscheinung.TabIndex = 614;
            this.lblErscheinung.Text = "Äussere Erscheinung";
            // 
            // memBildung
            // 
            this.memBildung.DataMember = "BemBildung";
            this.memBildung.DataSource = this.qrySchlussbericht;
            this.memBildung.Location = new System.Drawing.Point(415, 300);
            this.memBildung.Name = "memBildung";
            this.memBildung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBildung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBildung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBildung.Properties.Appearance.Options.UseBackColor = true;
            this.memBildung.Properties.Appearance.Options.UseBorderColor = true;
            this.memBildung.Properties.Appearance.Options.UseFont = true;
            this.memBildung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBildung.Size = new System.Drawing.Size(395, 85);
            this.memBildung.TabIndex = 21;
            // 
            // lblBildung
            // 
            this.lblBildung.ForeColor = System.Drawing.Color.Black;
            this.lblBildung.Location = new System.Drawing.Point(415, 275);
            this.lblBildung.Name = "lblBildung";
            this.lblBildung.Size = new System.Drawing.Size(385, 24);
            this.lblBildung.TabIndex = 616;
            this.lblBildung.Text = "Einschätzung integrierte Bildung und Bewerbungswerkstatt";
            // 
            // memZielvereinbarung
            // 
            this.memZielvereinbarung.DataMember = "BemZielvereinbarung";
            this.memZielvereinbarung.DataSource = this.qrySchlussbericht;
            this.memZielvereinbarung.Location = new System.Drawing.Point(10, 415);
            this.memZielvereinbarung.Name = "memZielvereinbarung";
            this.memZielvereinbarung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memZielvereinbarung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memZielvereinbarung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memZielvereinbarung.Properties.Appearance.Options.UseBackColor = true;
            this.memZielvereinbarung.Properties.Appearance.Options.UseBorderColor = true;
            this.memZielvereinbarung.Properties.Appearance.Options.UseFont = true;
            this.memZielvereinbarung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memZielvereinbarung.Size = new System.Drawing.Size(395, 85);
            this.memZielvereinbarung.TabIndex = 22;
            // 
            // lblZielvereinbarung
            // 
            this.lblZielvereinbarung.ForeColor = System.Drawing.Color.Black;
            this.lblZielvereinbarung.Location = new System.Drawing.Point(10, 390);
            this.lblZielvereinbarung.Name = "lblZielvereinbarung";
            this.lblZielvereinbarung.Size = new System.Drawing.Size(385, 24);
            this.lblZielvereinbarung.TabIndex = 618;
            this.lblZielvereinbarung.Text = "Bilanz zur Zielvereinbarung";
            // 
            // memAbsenzen
            // 
            this.memAbsenzen.DataMember = "BemAbsenzen";
            this.memAbsenzen.DataSource = this.qrySchlussbericht;
            this.memAbsenzen.Location = new System.Drawing.Point(415, 415);
            this.memAbsenzen.Name = "memAbsenzen";
            this.memAbsenzen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memAbsenzen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memAbsenzen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memAbsenzen.Properties.Appearance.Options.UseBackColor = true;
            this.memAbsenzen.Properties.Appearance.Options.UseBorderColor = true;
            this.memAbsenzen.Properties.Appearance.Options.UseFont = true;
            this.memAbsenzen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memAbsenzen.Size = new System.Drawing.Size(395, 85);
            this.memAbsenzen.TabIndex = 23;
            // 
            // lblAbsenzen
            // 
            this.lblAbsenzen.ForeColor = System.Drawing.Color.Black;
            this.lblAbsenzen.Location = new System.Drawing.Point(415, 390);
            this.lblAbsenzen.Name = "lblAbsenzen";
            this.lblAbsenzen.Size = new System.Drawing.Size(385, 24);
            this.lblAbsenzen.TabIndex = 620;
            this.lblAbsenzen.Text = "Kommentar zu den Absenzen";
            // 
            // memEmpfehlung
            // 
            this.memEmpfehlung.DataMember = "BemEmpfehlung";
            this.memEmpfehlung.DataSource = this.qrySchlussbericht;
            this.memEmpfehlung.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.memEmpfehlung.Location = new System.Drawing.Point(10, 535);
            this.memEmpfehlung.Name = "memEmpfehlung";
            this.memEmpfehlung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memEmpfehlung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memEmpfehlung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memEmpfehlung.Properties.Appearance.Options.UseBackColor = true;
            this.memEmpfehlung.Properties.Appearance.Options.UseBorderColor = true;
            this.memEmpfehlung.Properties.Appearance.Options.UseFont = true;
            this.memEmpfehlung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memEmpfehlung.Size = new System.Drawing.Size(395, 85);
            this.memEmpfehlung.TabIndex = 24;
            // 
            // lblEmpfehlung
            // 
            this.lblEmpfehlung.ForeColor = System.Drawing.Color.Black;
            this.lblEmpfehlung.Location = new System.Drawing.Point(10, 510);
            this.lblEmpfehlung.Name = "lblEmpfehlung";
            this.lblEmpfehlung.Size = new System.Drawing.Size(385, 24);
            this.lblEmpfehlung.TabIndex = 622;
            this.lblEmpfehlung.Text = "Empfehlung für weiterführende Schritte";
            // 
            // lblSemo
            // 
            this.lblSemo.ForeColor = System.Drawing.Color.Black;
            this.lblSemo.Location = new System.Drawing.Point(415, 535);
            this.lblSemo.Name = "lblSemo";
            this.lblSemo.Size = new System.Drawing.Size(385, 24);
            this.lblSemo.TabIndex = 623;
            this.lblSemo.Text = "Status nach Abschluss Semo";
            // 
            // lblBeurteilung
            // 
            this.lblBeurteilung.Location = new System.Drawing.Point(15, 660);
            this.lblBeurteilung.Name = "lblBeurteilung";
            this.lblBeurteilung.Size = new System.Drawing.Size(101, 24);
            this.lblBeurteilung.TabIndex = 625;
            this.lblBeurteilung.Text = "Datum Beurteilung";
            // 
            // datBeurteilung
            // 
            this.datBeurteilung.DataMember = "BeurteilungDat";
            this.datBeurteilung.DataSource = this.qrySchlussbericht;
            this.datBeurteilung.EditValue = null;
            this.datBeurteilung.Location = new System.Drawing.Point(125, 660);
            this.datBeurteilung.Name = "datBeurteilung";
            this.datBeurteilung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datBeurteilung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datBeurteilung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datBeurteilung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datBeurteilung.Properties.Appearance.Options.UseBackColor = true;
            this.datBeurteilung.Properties.Appearance.Options.UseBorderColor = true;
            this.datBeurteilung.Properties.Appearance.Options.UseFont = true;
            this.datBeurteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.datBeurteilung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datBeurteilung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.datBeurteilung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datBeurteilung.Properties.ShowToday = false;
            this.datBeurteilung.Size = new System.Drawing.Size(89, 24);
            this.datBeurteilung.TabIndex = 26;
            // 
            // chkEingVermittelbarkeit
            // 
            this.chkEingVermittelbarkeit.DataMember = "EingVermittelbarFlag";
            this.chkEingVermittelbarkeit.DataSource = this.qrySchlussbericht;
            this.chkEingVermittelbarkeit.Location = new System.Drawing.Point(421, 605);
            this.chkEingVermittelbarkeit.Name = "chkEingVermittelbarkeit";
            this.chkEingVermittelbarkeit.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkEingVermittelbarkeit.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.chkEingVermittelbarkeit.Properties.Appearance.Options.UseBackColor = true;
            this.chkEingVermittelbarkeit.Properties.Appearance.Options.UseForeColor = true;
            this.chkEingVermittelbarkeit.Properties.Caption = "  eingeschränkte Vermittelbarkeit, Gründe:";
            this.chkEingVermittelbarkeit.Size = new System.Drawing.Size(310, 19);
            this.chkEingVermittelbarkeit.TabIndex = 27;
            // 
            // memEingVermittelbarkeit
            // 
            this.memEingVermittelbarkeit.DataMember = "EingVermittelbar";
            this.memEingVermittelbarkeit.DataSource = this.qrySchlussbericht;
            this.memEingVermittelbarkeit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.memEingVermittelbarkeit.Location = new System.Drawing.Point(421, 630);
            this.memEingVermittelbarkeit.Name = "memEingVermittelbarkeit";
            this.memEingVermittelbarkeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memEingVermittelbarkeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memEingVermittelbarkeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memEingVermittelbarkeit.Properties.Appearance.Options.UseBackColor = true;
            this.memEingVermittelbarkeit.Properties.Appearance.Options.UseBorderColor = true;
            this.memEingVermittelbarkeit.Properties.Appearance.Options.UseFont = true;
            this.memEingVermittelbarkeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memEingVermittelbarkeit.Size = new System.Drawing.Size(385, 55);
            this.memEingVermittelbarkeit.TabIndex = 28;
            // 
            // lblSchlussbericht
            // 
            this.lblSchlussbericht.Location = new System.Drawing.Point(15, 630);
            this.lblSchlussbericht.Name = "lblSchlussbericht";
            this.lblSchlussbericht.Size = new System.Drawing.Size(101, 24);
            this.lblSchlussbericht.TabIndex = 626;
            this.lblSchlussbericht.Text = "Schlussbericht";
            // 
            // lblSemoGrund
            // 
            this.lblSemoGrund.DataMember = "SemoGrund";
            this.lblSemoGrund.DataSource = this.qrySchlussbericht;
            this.lblSemoGrund.ForeColor = System.Drawing.Color.Black;
            this.lblSemoGrund.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblSemoGrund.Location = new System.Drawing.Point(415, 565);
            this.lblSemoGrund.Name = "lblSemoGrund";
            this.lblSemoGrund.Size = new System.Drawing.Size(385, 16);
            this.lblSemoGrund.TabIndex = 627;
            // 
            // CtlKaQJPZSchlussbericht
            // 
            this.ActiveSQLQuery = this.qrySchlussbericht;
            this.Controls.Add(this.lblSemoGrund);
            this.Controls.Add(this.lblSchlussbericht);
            this.Controls.Add(this.memEingVermittelbarkeit);
            this.Controls.Add(this.chkEingVermittelbarkeit);
            this.Controls.Add(this.lblBeurteilung);
            this.Controls.Add(this.datBeurteilung);
            this.Controls.Add(this.lblSemo);
            this.Controls.Add(this.memEmpfehlung);
            this.Controls.Add(this.lblEmpfehlung);
            this.Controls.Add(this.memAbsenzen);
            this.Controls.Add(this.lblAbsenzen);
            this.Controls.Add(this.memZielvereinbarung);
            this.Controls.Add(this.lblZielvereinbarung);
            this.Controls.Add(this.memBildung);
            this.Controls.Add(this.lblBildung);
            this.Controls.Add(this.ddlErscheinung);
            this.Controls.Add(this.lblErscheinung);
            this.Controls.Add(this.ddlMotivation);
            this.Controls.Add(this.lblMotivation);
            this.Controls.Add(this.ddlSorgfalt);
            this.Controls.Add(this.lblSorgfalt);
            this.Controls.Add(this.ddlFlexibilitaet);
            this.Controls.Add(this.lblFlexibilitaet);
            this.Controls.Add(this.ddlKritikfaehig);
            this.Controls.Add(this.lblKritikfaehig);
            this.Controls.Add(this.ddlTeamfaehig);
            this.Controls.Add(this.lblTeamfaehig);
            this.Controls.Add(this.ddlKommunikation);
            this.Controls.Add(this.lblKommunikation);
            this.Controls.Add(this.ddlAuftreten);
            this.Controls.Add(this.lblAuftreten);
            this.Controls.Add(this.ddlOrdnung);
            this.Controls.Add(this.lblOrdnung);
            this.Controls.Add(this.ddlAusdauer);
            this.Controls.Add(this.lblAusdauer);
            this.Controls.Add(this.ddlPuenktlich);
            this.Controls.Add(this.lblPuenktlich);
            this.Controls.Add(this.ddlZuverlaessig);
            this.Controls.Add(this.lblZuverlaessig);
            this.Controls.Add(this.ddlSelbstaendig);
            this.Controls.Add(this.lblSelbstaendig);
            this.Controls.Add(this.ddlLandessprache);
            this.Controls.Add(this.lblLandessprache);
            this.Controls.Add(this.ddlLernfaehigkeit);
            this.Controls.Add(this.lblLernfaehigkeit);
            this.Controls.Add(this.ddlAOrganisation);
            this.Controls.Add(this.lblAOrganisation);
            this.Controls.Add(this.ddlAtempo);
            this.Controls.Add(this.lblATempo);
            this.Controls.Add(this.chkFranz);
            this.Controls.Add(this.chkDeutsch);
            this.Controls.Add(this.ddlAQualitaet);
            this.Controls.Add(this.lblAQualitaet);
            this.Controls.Add(this.docSchlussbericht);
            this.Controls.Add(this.memFachkompetenz);
            this.Controls.Add(this.lblFachkompetenz);
            this.Controls.Add(this.lblMerkmale);
            this.Controls.Add(this.lblArbeitsverhalten);
            this.Controls.Add(this.lblFaehigkeiten);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.picTitle);
            this.Name = "CtlKaQJPZSchlussbericht";
            this.Size = new System.Drawing.Size(830, 695);
            this.Load += new System.EventHandler(this.CtlKaQJPZSchlussbericht_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySchlussbericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSchlussbericht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memFachkompetenz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFachkompetenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAQualitaet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAQualitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAQualitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeutsch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFranz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAtempo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAtempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblATempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAOrganisation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAOrganisation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAOrganisation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLernfaehigkeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLernfaehigkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLernfaehigkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLandessprache.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlLandessprache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLandessprache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlOrdnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlOrdnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrdnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAusdauer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAusdauer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusdauer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPuenktlich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPuenktlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPuenktlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlZuverlaessig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlZuverlaessig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZuverlaessig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSelbstaendig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSelbstaendig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelbstaendig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlFlexibilitaet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlFlexibilitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFlexibilitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlKritikfaehig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlKritikfaehig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKritikfaehig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTeamfaehig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTeamfaehig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeamfaehig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlKommunikation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlKommunikation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKommunikation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAuftreten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAuftreten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuftreten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSorgfalt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSorgfalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSorgfalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMotivation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMotivation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMotivation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlErscheinung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlErscheinung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErscheinung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBildung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memZielvereinbarung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZielvereinbarung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAbsenzen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbsenzen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memEmpfehlung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmpfehlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeurteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datBeurteilung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEingVermittelbarkeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memEingVermittelbarkeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchlussbericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSemoGrund)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public void Init(string TitleName, Image TitleImage, int FaLeistungID, int BaPersonID)
		{
			this.lblTitel.Text = TitleName;
			this.picTitle.Image = TitleImage;			
			this.FaLeistungID = FaLeistungID;	
			this.BaPersonID = BaPersonID;
		}

		private void FillSchlussbericht()
		{
			// Insert row in KaQJPZSchlussbericht if there is no entry.
			if (!SchlussberichtExists() && DBUtil.UserHasRight("CtlKaQJPZSchlussbericht") && MayUpd)
			{
                DBUtil.ExecSQL(@"INSERT INTO KaQJPZSchlussbericht (FaLeistungID, SichtbarSDFlag) VALUES ({0}, {1})", this.FaLeistungID, KaUtil.IsVisibleSD(this.BaPersonID));
			}

			qrySchlussbericht.Fill(@"
				select	SBR.*,
						SemoGrund = IsNull(LOV.Value1, IsNull(LOV1.Value1, ''))
				from	KaQJPZSchlussbericht SBR
					left join KaQJProzess KAP on KAP.FaLeistungID = SBR.FaLeistungID	
					left join XLOVCode    LOV on LOV.LOVName = 'KaQjGrundProgEnde' and KAP.ProgEndeCode = LOV.Code						
					left join XLOVCode    LOV1 on LOV1.LOVName = 'KaQjGrundProgAbbruch' and KAP.AbbruchCode = LOV1.Code	
				where	SBR.FaLeistungID = {0}
				and		(SBR.SichtbarSDFlag = {1} or SBR.SichtbarSDFlag = 1)",
                FaLeistungID, Session.User.IsUserKA ? 0 : 1);				
		}

		private bool SchlussberichtExists()
		{
			bool rslt = false;

			rslt =	Convert.ToInt32(
				DBUtil.ExecuteScalarSQL(@"select count(*) from KaQJPZSchlussbericht where FaLeistungID = {0}",
				this.FaLeistungID)
				) > 0;					

			return rslt;
		}

		private void CtlKaQJPZSchlussbericht_Load(object sender, System.EventArgs e)
		{
			SetEditMode();
			FillSchlussbericht();			
		}

		private string GetAuswahlList(KiSS4.Gui.KissCheckedLookupEdit aLookup)
		{
			string[] arr = new String[]	{aLookup.EditValue};

			string KriterienCodes = "";
			foreach(string s in arr)
			{
				if (s != "")
				{
					if (KriterienCodes != "") KriterienCodes += ",";
					KriterienCodes += s;
				}
			}

			return KriterienCodes;
		}

		private void SetEditMode()
		{
			DBUtil.GetFallRights(this.FaLeistungID, out MayRead, out MayIns, out MayUpd, out MayDel, out MayClose, out MayReopen);
			qrySchlussbericht.CanUpdate = MayUpd && DBUtil.UserHasRight("CtlKaQJPZSchlussbericht", "U");;
			qrySchlussbericht.EnableBoundFields();
		}

		public override object GetContextValue(string FieldName) 
		{
			switch (FieldName.ToUpper()) 
			{
				case "BAPERSONID":
					return DBUtil.ExecuteScalarSQL(@"SELECT BaPersonID FROM FaLeistung WHERE FaLeistungID = {0}", this.FaLeistungID);

				case "FALEISTUNGID":
					return this.FaLeistungID;	
				
				case "OWNERUSERID":
					return (int) DBUtil.ExecuteScalarSQL("select UserID from FaLeistung where FaLeistungID = {0}",FaLeistungID);
				
			}

			return base.GetContextValue(FieldName);
		}
	}
}
