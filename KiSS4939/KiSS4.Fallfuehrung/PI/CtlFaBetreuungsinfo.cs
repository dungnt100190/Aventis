using System;
using System.Drawing;
using KiSS4.DB;

namespace KiSS4.Fallfuehrung.PI
{
    public class CtlFaBetreuungsinfo : KiSS4.Gui.KissUserControl
    {
        #region Enumerations

        private enum Navigation
        {
            Previous,
            Next,
            None
        }

        #endregion

        #region Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Fields

        private Int32 BaPersonID = -1;
        private KiSS4.Gui.KissButton btnNext;
        private KiSS4.Gui.KissButton btnPrevious;
        private System.ComponentModel.IContainer components;
        private KiSS4.Dokument.KissDocumentButton docBericht;
        private KiSS4.Gui.KissMemoEdit edtAngstfaktoren;
        private KiSS4.Gui.KissMemoEdit edtAnkleiden;
        private KiSS4.Gui.KissMemoEdit edtBehinderung;
        private KiSS4.Gui.KissMemoEdit edtErnaehrung;
        private KiSS4.Gui.KissMemoEdit edtFreizeitInteressen;
        private KiSS4.Gui.KissMemoEdit edtGrundpflege;
        private KiSS4.Gui.KissMemoEdit edtIntellektuell;
        private KiSS4.Gui.KissMemoEdit edtKommunikation;
        private KiSS4.Gui.KissMemoEdit edtMedikation;
        private KiSS4.Gui.KissMemoEdit edtMedizinisches;
        private KiSS4.Gui.KissMemoEdit edtMobilitaet;
        private KiSS4.Gui.KissMemoEdit edtMotorik;
        private KiSS4.Gui.KissMemoEdit edtNahrungsaufnahme;
        private KiSS4.Gui.KissMemoEdit edtNotfallInfo;
        private KiSS4.Gui.KissMemoEdit edtPersoenlichkeit;
        private KiSS4.Gui.KissMemoEdit edtSchlaf;
        private KiSS4.Gui.KissMemoEdit edtSicherheitGebendeElemente;
        private KiSS4.Gui.KissMemoEdit edtSollVerhindertWerden;
        private KiSS4.Gui.KissMemoEdit edtTagesablauf;
        private KiSS4.Gui.KissMemoEdit edtToilette;
        private KiSS4.Gui.KissMemoEdit edtVerhaltensstoerung;
        private KiSS4.Gui.KissMemoEdit edtVerschiedeneAktivitaeten;
        private KiSS4.Gui.KissLabel lblAngstfaktoren;
        private KiSS4.Gui.KissLabel lblAnkleiden;
        private KiSS4.Gui.KissLabel lblBehinderung;
        private KiSS4.Gui.KissLabel lblErnaehrung;
        private KiSS4.Gui.KissLabel lblFreizeitInteressen;
        private KiSS4.Gui.KissLabel lblGrundpflege;
        private KiSS4.Gui.KissLabel lblIntellektuell;
        private KiSS4.Gui.KissLabel lblKommunikation;
        private KiSS4.Gui.KissLabel lblMedikation;
        private KiSS4.Gui.KissLabel lblMedizinisches;
        private KiSS4.Gui.KissLabel lblMobilitaet;
        private KiSS4.Gui.KissLabel lblMotorik;
        private KiSS4.Gui.KissLabel lblNahrungsaufnahme;
        private KiSS4.Gui.KissLabel lblNotfallInfo;
        private KiSS4.Gui.KissLabel lblPersoenlichkeit;
        private KiSS4.Gui.KissLabel lblSchlaf;
        private KiSS4.Gui.KissLabel lblSicherheitGebendeElemente;
        private KiSS4.Gui.KissLabel lblSollVerhindertWerden;
        private KiSS4.Gui.KissLabel lblTagesablauf;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblToilette;
        private KiSS4.Gui.KissLabel lblVerhaltensstoerung;
        private KiSS4.Gui.KissLabel lblVerschiedeneAktivitaeten;
        private System.Windows.Forms.Panel panBottomSpacer;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFaBetreuungsinfo;
        private KiSS4.Gui.KissTabControlEx tabBetreuungsinfo;
        private SharpLibrary.WinControls.TabPageEx tpgBetreuung;
        private SharpLibrary.WinControls.TabPageEx tpgIndividualitaet;
        private SharpLibrary.WinControls.TabPageEx tpgSelbststaendigkeit;

        #endregion

        #region Constructors

        public CtlFaBetreuungsinfo()
        {
            this.InitializeComponent();

            // logging
            logger.Debug("enter");

            // init with default values
            this.Init(null, null, -1);

            // logging
            logger.Debug("done");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaBetreuungsinfo));
            this.panTitel = new System.Windows.Forms.Panel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.tabBetreuungsinfo = new KiSS4.Gui.KissTabControlEx();
            this.tpgIndividualitaet = new SharpLibrary.WinControls.TabPageEx();
            this.lblBehinderung = new KiSS4.Gui.KissLabel();
            this.edtBehinderung = new KiSS4.Gui.KissMemoEdit();
            this.lblPersoenlichkeit = new KiSS4.Gui.KissLabel();
            this.edtPersoenlichkeit = new KiSS4.Gui.KissMemoEdit();
            this.lblKommunikation = new KiSS4.Gui.KissLabel();
            this.edtKommunikation = new KiSS4.Gui.KissMemoEdit();
            this.lblIntellektuell = new KiSS4.Gui.KissLabel();
            this.edtIntellektuell = new KiSS4.Gui.KissMemoEdit();
            this.lblMotorik = new KiSS4.Gui.KissLabel();
            this.edtMotorik = new KiSS4.Gui.KissMemoEdit();
            this.lblFreizeitInteressen = new KiSS4.Gui.KissLabel();
            this.edtFreizeitInteressen = new KiSS4.Gui.KissMemoEdit();
            this.lblNotfallInfo = new KiSS4.Gui.KissLabel();
            this.edtNotfallInfo = new KiSS4.Gui.KissMemoEdit();
            this.tpgBetreuung = new SharpLibrary.WinControls.TabPageEx();
            this.lblVerhaltensstoerung = new KiSS4.Gui.KissLabel();
            this.edtVerhaltensstoerung = new KiSS4.Gui.KissMemoEdit();
            this.lblAngstfaktoren = new KiSS4.Gui.KissLabel();
            this.edtAngstfaktoren = new KiSS4.Gui.KissMemoEdit();
            this.lblSicherheitGebendeElemente = new KiSS4.Gui.KissLabel();
            this.edtSicherheitGebendeElemente = new KiSS4.Gui.KissMemoEdit();
            this.lblSollVerhindertWerden = new KiSS4.Gui.KissLabel();
            this.edtSollVerhindertWerden = new KiSS4.Gui.KissMemoEdit();
            this.lblMedizinisches = new KiSS4.Gui.KissLabel();
            this.edtMedizinisches = new KiSS4.Gui.KissMemoEdit();
            this.lblMedikation = new KiSS4.Gui.KissLabel();
            this.edtMedikation = new KiSS4.Gui.KissMemoEdit();
            this.lblErnaehrung = new KiSS4.Gui.KissLabel();
            this.edtErnaehrung = new KiSS4.Gui.KissMemoEdit();
            this.lblTagesablauf = new KiSS4.Gui.KissLabel();
            this.edtTagesablauf = new KiSS4.Gui.KissMemoEdit();
            this.tpgSelbststaendigkeit = new SharpLibrary.WinControls.TabPageEx();
            this.lblMobilitaet = new KiSS4.Gui.KissLabel();
            this.edtMobilitaet = new KiSS4.Gui.KissMemoEdit();
            this.lblAnkleiden = new KiSS4.Gui.KissLabel();
            this.edtAnkleiden = new KiSS4.Gui.KissMemoEdit();
            this.lblNahrungsaufnahme = new KiSS4.Gui.KissLabel();
            this.edtNahrungsaufnahme = new KiSS4.Gui.KissMemoEdit();
            this.lblGrundpflege = new KiSS4.Gui.KissLabel();
            this.edtGrundpflege = new KiSS4.Gui.KissMemoEdit();
            this.lblToilette = new KiSS4.Gui.KissLabel();
            this.edtToilette = new KiSS4.Gui.KissMemoEdit();
            this.lblSchlaf = new KiSS4.Gui.KissLabel();
            this.edtSchlaf = new KiSS4.Gui.KissMemoEdit();
            this.lblVerschiedeneAktivitaeten = new KiSS4.Gui.KissLabel();
            this.edtVerschiedeneAktivitaeten = new KiSS4.Gui.KissMemoEdit();
            this.panBottomSpacer = new System.Windows.Forms.Panel();
            this.docBericht = new KiSS4.Dokument.KissDocumentButton();
            this.qryFaBetreuungsinfo = new KiSS4.DB.SqlQuery(this.components);
            this.btnNext = new KiSS4.Gui.KissButton();
            this.btnPrevious = new KiSS4.Gui.KissButton();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            this.tabBetreuungsinfo.SuspendLayout();
            this.tpgIndividualitaet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBehinderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBehinderung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersoenlichkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersoenlichkeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKommunikation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKommunikation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIntellektuell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntellektuell.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMotorik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMotorik.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFreizeitInteressen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFreizeitInteressen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNotfallInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNotfallInfo.Properties)).BeginInit();
            this.tpgBetreuung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerhaltensstoerung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerhaltensstoerung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngstfaktoren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngstfaktoren.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSicherheitGebendeElemente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSicherheitGebendeElemente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollVerhindertWerden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollVerhindertWerden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMedizinisches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMedizinisches.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMedikation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMedikation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErnaehrung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErnaehrung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTagesablauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTagesablauf.Properties)).BeginInit();
            this.tpgSelbststaendigkeit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblMobilitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMobilitaet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnkleiden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnkleiden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNahrungsaufnahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNahrungsaufnahme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundpflege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundpflege.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToilette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtToilette.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchlaf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchlaf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerschiedeneAktivitaeten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerschiedeneAktivitaeten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaBetreuungsinfo)).BeginInit();
            this.SuspendLayout();
            //
            // panTitel
            //
            this.panTitel.Controls.Add(this.btnNext);
            this.panTitel.Controls.Add(this.btnPrevious);
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(722, 30);
            this.panTitel.TabIndex = 0;
            //
            // lblTitel
            //
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(621, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Betreuungsinfo";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 1;
            this.picTitel.TabStop = false;
            //
            // tabBetreuungsinfo
            //
            this.tabBetreuungsinfo.Controls.Add(this.tpgSelbststaendigkeit);
            this.tabBetreuungsinfo.Controls.Add(this.tpgBetreuung);
            this.tabBetreuungsinfo.Controls.Add(this.tpgIndividualitaet);
            this.tabBetreuungsinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBetreuungsinfo.Location = new System.Drawing.Point(0, 30);
            this.tabBetreuungsinfo.Name = "tabBetreuungsinfo";
            this.tabBetreuungsinfo.SelectedTabIndex = 2;
            this.tabBetreuungsinfo.ShowFixedWidthTooltip = true;
            this.tabBetreuungsinfo.ShowIconOnContainingData = true;
            this.tabBetreuungsinfo.Size = new System.Drawing.Size(722, 556);
            this.tabBetreuungsinfo.TabIndex = 1;
            this.tabBetreuungsinfo.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
                        this.tpgIndividualitaet,
                        this.tpgBetreuung,
                        this.tpgSelbststaendigkeit});
            this.tabBetreuungsinfo.TabsLineColor = System.Drawing.Color.Black;
            this.tabBetreuungsinfo.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabBetreuungsinfo.Text = "kissTabControlEx1";
            //
            // tpgIndividualitaet
            //
            this.tpgIndividualitaet.Controls.Add(this.edtNotfallInfo);
            this.tpgIndividualitaet.Controls.Add(this.lblNotfallInfo);
            this.tpgIndividualitaet.Controls.Add(this.edtFreizeitInteressen);
            this.tpgIndividualitaet.Controls.Add(this.lblFreizeitInteressen);
            this.tpgIndividualitaet.Controls.Add(this.edtMotorik);
            this.tpgIndividualitaet.Controls.Add(this.lblMotorik);
            this.tpgIndividualitaet.Controls.Add(this.edtIntellektuell);
            this.tpgIndividualitaet.Controls.Add(this.lblIntellektuell);
            this.tpgIndividualitaet.Controls.Add(this.edtKommunikation);
            this.tpgIndividualitaet.Controls.Add(this.lblKommunikation);
            this.tpgIndividualitaet.Controls.Add(this.edtPersoenlichkeit);
            this.tpgIndividualitaet.Controls.Add(this.lblPersoenlichkeit);
            this.tpgIndividualitaet.Controls.Add(this.edtBehinderung);
            this.tpgIndividualitaet.Controls.Add(this.lblBehinderung);
            this.tpgIndividualitaet.Location = new System.Drawing.Point(6, 6);
            this.tpgIndividualitaet.Name = "tpgIndividualitaet";
            this.tpgIndividualitaet.Size = new System.Drawing.Size(710, 518);
            this.tpgIndividualitaet.TabIndex = 0;
            this.tpgIndividualitaet.Title = "In&dividualität";
            //
            // lblBehinderung
            //
            this.lblBehinderung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBehinderung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBehinderung.Location = new System.Drawing.Point(9, 9);
            this.lblBehinderung.Name = "lblBehinderung";
            this.lblBehinderung.Size = new System.Drawing.Size(107, 66);
            this.lblBehinderung.TabIndex = 0;
            this.lblBehinderung.Text = "Behinderung";
            this.lblBehinderung.UseCompatibleTextRendering = true;
            //
            // edtBehinderung
            //
            this.edtBehinderung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBehinderung.DataMember = "IndividualBehinderung";
            this.edtBehinderung.DataSource = this.qryFaBetreuungsinfo;
            this.edtBehinderung.Location = new System.Drawing.Point(122, 9);
            this.edtBehinderung.Name = "edtBehinderung";
            this.edtBehinderung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBehinderung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBehinderung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBehinderung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBehinderung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBehinderung.Properties.Appearance.Options.UseFont = true;
            this.edtBehinderung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBehinderung.Size = new System.Drawing.Size(578, 66);
            this.edtBehinderung.TabIndex = 1;
            //
            // lblPersoenlichkeit
            //
            this.lblPersoenlichkeit.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPersoenlichkeit.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPersoenlichkeit.Location = new System.Drawing.Point(9, 81);
            this.lblPersoenlichkeit.Name = "lblPersoenlichkeit";
            this.lblPersoenlichkeit.Size = new System.Drawing.Size(107, 66);
            this.lblPersoenlichkeit.TabIndex = 2;
            this.lblPersoenlichkeit.Text = "Persönlichkeit";
            this.lblPersoenlichkeit.UseCompatibleTextRendering = true;
            //
            // edtPersoenlichkeit
            //
            this.edtPersoenlichkeit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPersoenlichkeit.DataMember = "IndividualPersoenlichkeit";
            this.edtPersoenlichkeit.DataSource = this.qryFaBetreuungsinfo;
            this.edtPersoenlichkeit.Location = new System.Drawing.Point(122, 81);
            this.edtPersoenlichkeit.Name = "edtPersoenlichkeit";
            this.edtPersoenlichkeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersoenlichkeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersoenlichkeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersoenlichkeit.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersoenlichkeit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersoenlichkeit.Properties.Appearance.Options.UseFont = true;
            this.edtPersoenlichkeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersoenlichkeit.Size = new System.Drawing.Size(578, 66);
            this.edtPersoenlichkeit.TabIndex = 3;
            //
            // lblKommunikation
            //
            this.lblKommunikation.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblKommunikation.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblKommunikation.Location = new System.Drawing.Point(9, 153);
            this.lblKommunikation.Name = "lblKommunikation";
            this.lblKommunikation.Size = new System.Drawing.Size(107, 66);
            this.lblKommunikation.TabIndex = 4;
            this.lblKommunikation.Text = "Kommunikation";
            this.lblKommunikation.UseCompatibleTextRendering = true;
            //
            // edtKommunikation
            //
            this.edtKommunikation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKommunikation.DataMember = "IndividualKommunikation";
            this.edtKommunikation.DataSource = this.qryFaBetreuungsinfo;
            this.edtKommunikation.Location = new System.Drawing.Point(122, 153);
            this.edtKommunikation.Name = "edtKommunikation";
            this.edtKommunikation.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKommunikation.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKommunikation.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKommunikation.Properties.Appearance.Options.UseBackColor = true;
            this.edtKommunikation.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKommunikation.Properties.Appearance.Options.UseFont = true;
            this.edtKommunikation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKommunikation.Size = new System.Drawing.Size(578, 66);
            this.edtKommunikation.TabIndex = 5;
            //
            // lblIntellektuell
            //
            this.lblIntellektuell.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblIntellektuell.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblIntellektuell.Location = new System.Drawing.Point(9, 225);
            this.lblIntellektuell.Name = "lblIntellektuell";
            this.lblIntellektuell.Size = new System.Drawing.Size(107, 66);
            this.lblIntellektuell.TabIndex = 6;
            this.lblIntellektuell.Text = "Intellektuelle Entwicklung";
            this.lblIntellektuell.UseCompatibleTextRendering = true;
            //
            // edtIntellektuell
            //
            this.edtIntellektuell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtIntellektuell.DataMember = "IndividualIntellektuell";
            this.edtIntellektuell.DataSource = this.qryFaBetreuungsinfo;
            this.edtIntellektuell.Location = new System.Drawing.Point(122, 225);
            this.edtIntellektuell.Name = "edtIntellektuell";
            this.edtIntellektuell.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIntellektuell.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIntellektuell.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIntellektuell.Properties.Appearance.Options.UseBackColor = true;
            this.edtIntellektuell.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIntellektuell.Properties.Appearance.Options.UseFont = true;
            this.edtIntellektuell.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIntellektuell.Size = new System.Drawing.Size(578, 66);
            this.edtIntellektuell.TabIndex = 7;
            //
            // lblMotorik
            //
            this.lblMotorik.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMotorik.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblMotorik.Location = new System.Drawing.Point(9, 297);
            this.lblMotorik.Name = "lblMotorik";
            this.lblMotorik.Size = new System.Drawing.Size(107, 66);
            this.lblMotorik.TabIndex = 8;
            this.lblMotorik.Text = "Motorische Fähigkeiten";
            this.lblMotorik.UseCompatibleTextRendering = true;
            //
            // edtMotorik
            //
            this.edtMotorik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMotorik.DataMember = "IndividualMotorik";
            this.edtMotorik.DataSource = this.qryFaBetreuungsinfo;
            this.edtMotorik.Location = new System.Drawing.Point(122, 297);
            this.edtMotorik.Name = "edtMotorik";
            this.edtMotorik.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMotorik.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMotorik.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMotorik.Properties.Appearance.Options.UseBackColor = true;
            this.edtMotorik.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMotorik.Properties.Appearance.Options.UseFont = true;
            this.edtMotorik.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMotorik.Size = new System.Drawing.Size(578, 66);
            this.edtMotorik.TabIndex = 9;
            //
            // lblFreizeitInteressen
            //
            this.lblFreizeitInteressen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFreizeitInteressen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblFreizeitInteressen.Location = new System.Drawing.Point(9, 369);
            this.lblFreizeitInteressen.Name = "lblFreizeitInteressen";
            this.lblFreizeitInteressen.Size = new System.Drawing.Size(107, 66);
            this.lblFreizeitInteressen.TabIndex = 10;
            this.lblFreizeitInteressen.Text = "Freizeit, Interessen";
            this.lblFreizeitInteressen.UseCompatibleTextRendering = true;
            //
            // edtFreizeitInteressen
            //
            this.edtFreizeitInteressen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFreizeitInteressen.DataMember = "IndividualFreizeit";
            this.edtFreizeitInteressen.DataSource = this.qryFaBetreuungsinfo;
            this.edtFreizeitInteressen.Location = new System.Drawing.Point(122, 369);
            this.edtFreizeitInteressen.Name = "edtFreizeitInteressen";
            this.edtFreizeitInteressen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFreizeitInteressen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFreizeitInteressen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFreizeitInteressen.Properties.Appearance.Options.UseBackColor = true;
            this.edtFreizeitInteressen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFreizeitInteressen.Properties.Appearance.Options.UseFont = true;
            this.edtFreizeitInteressen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFreizeitInteressen.Size = new System.Drawing.Size(578, 66);
            this.edtFreizeitInteressen.TabIndex = 11;
            //
            // lblNotfallInfo
            //
            this.lblNotfallInfo.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNotfallInfo.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblNotfallInfo.Location = new System.Drawing.Point(9, 441);
            this.lblNotfallInfo.Name = "lblNotfallInfo";
            this.lblNotfallInfo.Size = new System.Drawing.Size(107, 66);
            this.lblNotfallInfo.TabIndex = 12;
            this.lblNotfallInfo.Text = "Notfallinfo";
            this.lblNotfallInfo.UseCompatibleTextRendering = true;
            //
            // edtNotfallInfo
            //
            this.edtNotfallInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNotfallInfo.DataMember = "IndividualNotfallInfo";
            this.edtNotfallInfo.DataSource = this.qryFaBetreuungsinfo;
            this.edtNotfallInfo.Location = new System.Drawing.Point(122, 441);
            this.edtNotfallInfo.Name = "edtNotfallInfo";
            this.edtNotfallInfo.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNotfallInfo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNotfallInfo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNotfallInfo.Properties.Appearance.Options.UseBackColor = true;
            this.edtNotfallInfo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNotfallInfo.Properties.Appearance.Options.UseFont = true;
            this.edtNotfallInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNotfallInfo.Size = new System.Drawing.Size(578, 66);
            this.edtNotfallInfo.TabIndex = 13;
            //
            // tpgBetreuung
            //
            this.tpgBetreuung.Controls.Add(this.edtTagesablauf);
            this.tpgBetreuung.Controls.Add(this.lblTagesablauf);
            this.tpgBetreuung.Controls.Add(this.edtErnaehrung);
            this.tpgBetreuung.Controls.Add(this.lblErnaehrung);
            this.tpgBetreuung.Controls.Add(this.edtMedikation);
            this.tpgBetreuung.Controls.Add(this.lblMedikation);
            this.tpgBetreuung.Controls.Add(this.edtMedizinisches);
            this.tpgBetreuung.Controls.Add(this.lblMedizinisches);
            this.tpgBetreuung.Controls.Add(this.edtSollVerhindertWerden);
            this.tpgBetreuung.Controls.Add(this.lblSollVerhindertWerden);
            this.tpgBetreuung.Controls.Add(this.edtSicherheitGebendeElemente);
            this.tpgBetreuung.Controls.Add(this.lblSicherheitGebendeElemente);
            this.tpgBetreuung.Controls.Add(this.edtAngstfaktoren);
            this.tpgBetreuung.Controls.Add(this.lblAngstfaktoren);
            this.tpgBetreuung.Controls.Add(this.edtVerhaltensstoerung);
            this.tpgBetreuung.Controls.Add(this.lblVerhaltensstoerung);
            this.tpgBetreuung.Location = new System.Drawing.Point(6, 6);
            this.tpgBetreuung.Name = "tpgBetreuung";
            this.tpgBetreuung.Size = new System.Drawing.Size(710, 518);
            this.tpgBetreuung.TabIndex = 1;
            this.tpgBetreuung.Title = "Betre&uung";
            //
            // lblVerhaltensstoerung
            //
            this.lblVerhaltensstoerung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblVerhaltensstoerung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblVerhaltensstoerung.Location = new System.Drawing.Point(9, 9);
            this.lblVerhaltensstoerung.Name = "lblVerhaltensstoerung";
            this.lblVerhaltensstoerung.Size = new System.Drawing.Size(107, 57);
            this.lblVerhaltensstoerung.TabIndex = 0;
            this.lblVerhaltensstoerung.Text = "Verhaltensstörung (Vorzeichen, angepasste Reaktion)";
            this.lblVerhaltensstoerung.UseCompatibleTextRendering = true;
            //
            // edtVerhaltensstoerung
            //
            this.edtVerhaltensstoerung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtVerhaltensstoerung.DataMember = "BetreuungVerhalten";
            this.edtVerhaltensstoerung.DataSource = this.qryFaBetreuungsinfo;
            this.edtVerhaltensstoerung.Location = new System.Drawing.Point(122, 9);
            this.edtVerhaltensstoerung.Name = "edtVerhaltensstoerung";
            this.edtVerhaltensstoerung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerhaltensstoerung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerhaltensstoerung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerhaltensstoerung.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerhaltensstoerung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerhaltensstoerung.Properties.Appearance.Options.UseFont = true;
            this.edtVerhaltensstoerung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVerhaltensstoerung.Size = new System.Drawing.Size(578, 57);
            this.edtVerhaltensstoerung.TabIndex = 1;
            //
            // lblAngstfaktoren
            //
            this.lblAngstfaktoren.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAngstfaktoren.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblAngstfaktoren.Location = new System.Drawing.Point(9, 72);
            this.lblAngstfaktoren.Name = "lblAngstfaktoren";
            this.lblAngstfaktoren.Size = new System.Drawing.Size(107, 57);
            this.lblAngstfaktoren.TabIndex = 2;
            this.lblAngstfaktoren.Text = "Angstfaktoren";
            this.lblAngstfaktoren.UseCompatibleTextRendering = true;
            //
            // edtAngstfaktoren
            //
            this.edtAngstfaktoren.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAngstfaktoren.DataMember = "BetreuungAngst";
            this.edtAngstfaktoren.DataSource = this.qryFaBetreuungsinfo;
            this.edtAngstfaktoren.Location = new System.Drawing.Point(122, 72);
            this.edtAngstfaktoren.Name = "edtAngstfaktoren";
            this.edtAngstfaktoren.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAngstfaktoren.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAngstfaktoren.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAngstfaktoren.Properties.Appearance.Options.UseBackColor = true;
            this.edtAngstfaktoren.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAngstfaktoren.Properties.Appearance.Options.UseFont = true;
            this.edtAngstfaktoren.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAngstfaktoren.Size = new System.Drawing.Size(578, 57);
            this.edtAngstfaktoren.TabIndex = 3;
            //
            // lblSicherheitGebendeElemente
            //
            this.lblSicherheitGebendeElemente.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSicherheitGebendeElemente.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSicherheitGebendeElemente.Location = new System.Drawing.Point(9, 135);
            this.lblSicherheitGebendeElemente.Name = "lblSicherheitGebendeElemente";
            this.lblSicherheitGebendeElemente.Size = new System.Drawing.Size(107, 57);
            this.lblSicherheitGebendeElemente.TabIndex = 4;
            this.lblSicherheitGebendeElemente.Text = "Sicherheit gebende Elemente";
            this.lblSicherheitGebendeElemente.UseCompatibleTextRendering = true;
            //
            // edtSicherheitGebendeElemente
            //
            this.edtSicherheitGebendeElemente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSicherheitGebendeElemente.DataMember = "BetreuungSicherheit";
            this.edtSicherheitGebendeElemente.DataSource = this.qryFaBetreuungsinfo;
            this.edtSicherheitGebendeElemente.Location = new System.Drawing.Point(122, 135);
            this.edtSicherheitGebendeElemente.Name = "edtSicherheitGebendeElemente";
            this.edtSicherheitGebendeElemente.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSicherheitGebendeElemente.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSicherheitGebendeElemente.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSicherheitGebendeElemente.Properties.Appearance.Options.UseBackColor = true;
            this.edtSicherheitGebendeElemente.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSicherheitGebendeElemente.Properties.Appearance.Options.UseFont = true;
            this.edtSicherheitGebendeElemente.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSicherheitGebendeElemente.Size = new System.Drawing.Size(578, 57);
            this.edtSicherheitGebendeElemente.TabIndex = 5;
            //
            // lblSollVerhindertWerden
            //
            this.lblSollVerhindertWerden.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSollVerhindertWerden.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSollVerhindertWerden.Location = new System.Drawing.Point(9, 198);
            this.lblSollVerhindertWerden.Name = "lblSollVerhindertWerden";
            this.lblSollVerhindertWerden.Size = new System.Drawing.Size(107, 57);
            this.lblSollVerhindertWerden.TabIndex = 6;
            this.lblSollVerhindertWerden.Text = "Sollte verhindert werden";
            this.lblSollVerhindertWerden.UseCompatibleTextRendering = true;
            //
            // edtSollVerhindertWerden
            //
            this.edtSollVerhindertWerden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSollVerhindertWerden.DataMember = "BetreuungVerhindern";
            this.edtSollVerhindertWerden.DataSource = this.qryFaBetreuungsinfo;
            this.edtSollVerhindertWerden.Location = new System.Drawing.Point(122, 198);
            this.edtSollVerhindertWerden.Name = "edtSollVerhindertWerden";
            this.edtSollVerhindertWerden.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSollVerhindertWerden.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSollVerhindertWerden.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSollVerhindertWerden.Properties.Appearance.Options.UseBackColor = true;
            this.edtSollVerhindertWerden.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSollVerhindertWerden.Properties.Appearance.Options.UseFont = true;
            this.edtSollVerhindertWerden.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSollVerhindertWerden.Size = new System.Drawing.Size(578, 57);
            this.edtSollVerhindertWerden.TabIndex = 7;
            //
            // lblMedizinisches
            //
            this.lblMedizinisches.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMedizinisches.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblMedizinisches.Location = new System.Drawing.Point(9, 261);
            this.lblMedizinisches.Name = "lblMedizinisches";
            this.lblMedizinisches.Size = new System.Drawing.Size(107, 57);
            this.lblMedizinisches.TabIndex = 8;
            this.lblMedizinisches.Text = "Medizinisches, Behandlungspflege";
            this.lblMedizinisches.UseCompatibleTextRendering = true;
            //
            // edtMedizinisches
            //
            this.edtMedizinisches.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMedizinisches.DataMember = "BetreuungMedizin";
            this.edtMedizinisches.DataSource = this.qryFaBetreuungsinfo;
            this.edtMedizinisches.Location = new System.Drawing.Point(122, 261);
            this.edtMedizinisches.Name = "edtMedizinisches";
            this.edtMedizinisches.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMedizinisches.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMedizinisches.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMedizinisches.Properties.Appearance.Options.UseBackColor = true;
            this.edtMedizinisches.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMedizinisches.Properties.Appearance.Options.UseFont = true;
            this.edtMedizinisches.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMedizinisches.Size = new System.Drawing.Size(578, 57);
            this.edtMedizinisches.TabIndex = 9;
            //
            // lblMedikation
            //
            this.lblMedikation.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMedikation.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblMedikation.Location = new System.Drawing.Point(9, 324);
            this.lblMedikation.Name = "lblMedikation";
            this.lblMedikation.Size = new System.Drawing.Size(107, 57);
            this.lblMedikation.TabIndex = 10;
            this.lblMedikation.Text = "Medikation";
            this.lblMedikation.UseCompatibleTextRendering = true;
            //
            // edtMedikation
            //
            this.edtMedikation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMedikation.DataMember = "BetreuungMedikation";
            this.edtMedikation.DataSource = this.qryFaBetreuungsinfo;
            this.edtMedikation.Location = new System.Drawing.Point(122, 324);
            this.edtMedikation.Name = "edtMedikation";
            this.edtMedikation.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMedikation.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMedikation.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMedikation.Properties.Appearance.Options.UseBackColor = true;
            this.edtMedikation.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMedikation.Properties.Appearance.Options.UseFont = true;
            this.edtMedikation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMedikation.Size = new System.Drawing.Size(578, 57);
            this.edtMedikation.TabIndex = 11;
            //
            // lblErnaehrung
            //
            this.lblErnaehrung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblErnaehrung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblErnaehrung.Location = new System.Drawing.Point(9, 387);
            this.lblErnaehrung.Name = "lblErnaehrung";
            this.lblErnaehrung.Size = new System.Drawing.Size(107, 57);
            this.lblErnaehrung.TabIndex = 12;
            this.lblErnaehrung.Text = "Ernährung, Getränke";
            this.lblErnaehrung.UseCompatibleTextRendering = true;
            //
            // edtErnaehrung
            //
            this.edtErnaehrung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtErnaehrung.DataMember = "BetreuungErnaehrung";
            this.edtErnaehrung.DataSource = this.qryFaBetreuungsinfo;
            this.edtErnaehrung.Location = new System.Drawing.Point(122, 387);
            this.edtErnaehrung.Name = "edtErnaehrung";
            this.edtErnaehrung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErnaehrung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErnaehrung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErnaehrung.Properties.Appearance.Options.UseBackColor = true;
            this.edtErnaehrung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErnaehrung.Properties.Appearance.Options.UseFont = true;
            this.edtErnaehrung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErnaehrung.Size = new System.Drawing.Size(578, 57);
            this.edtErnaehrung.TabIndex = 13;
            //
            // lblTagesablauf
            //
            this.lblTagesablauf.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTagesablauf.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblTagesablauf.Location = new System.Drawing.Point(9, 450);
            this.lblTagesablauf.Name = "lblTagesablauf";
            this.lblTagesablauf.Size = new System.Drawing.Size(107, 57);
            this.lblTagesablauf.TabIndex = 14;
            this.lblTagesablauf.Text = "Tagesablauf, Rhythmus";
            this.lblTagesablauf.UseCompatibleTextRendering = true;
            //
            // edtTagesablauf
            //
            this.edtTagesablauf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTagesablauf.DataMember = "BetreuungTagesablauf";
            this.edtTagesablauf.DataSource = this.qryFaBetreuungsinfo;
            this.edtTagesablauf.Location = new System.Drawing.Point(122, 450);
            this.edtTagesablauf.Name = "edtTagesablauf";
            this.edtTagesablauf.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTagesablauf.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTagesablauf.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTagesablauf.Properties.Appearance.Options.UseBackColor = true;
            this.edtTagesablauf.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTagesablauf.Properties.Appearance.Options.UseFont = true;
            this.edtTagesablauf.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTagesablauf.Size = new System.Drawing.Size(578, 57);
            this.edtTagesablauf.TabIndex = 15;
            //
            // tpgSelbststaendigkeit
            //
            this.tpgSelbststaendigkeit.Controls.Add(this.edtVerschiedeneAktivitaeten);
            this.tpgSelbststaendigkeit.Controls.Add(this.lblVerschiedeneAktivitaeten);
            this.tpgSelbststaendigkeit.Controls.Add(this.edtSchlaf);
            this.tpgSelbststaendigkeit.Controls.Add(this.lblSchlaf);
            this.tpgSelbststaendigkeit.Controls.Add(this.edtToilette);
            this.tpgSelbststaendigkeit.Controls.Add(this.lblToilette);
            this.tpgSelbststaendigkeit.Controls.Add(this.edtGrundpflege);
            this.tpgSelbststaendigkeit.Controls.Add(this.lblGrundpflege);
            this.tpgSelbststaendigkeit.Controls.Add(this.edtNahrungsaufnahme);
            this.tpgSelbststaendigkeit.Controls.Add(this.lblNahrungsaufnahme);
            this.tpgSelbststaendigkeit.Controls.Add(this.edtAnkleiden);
            this.tpgSelbststaendigkeit.Controls.Add(this.lblAnkleiden);
            this.tpgSelbststaendigkeit.Controls.Add(this.edtMobilitaet);
            this.tpgSelbststaendigkeit.Controls.Add(this.lblMobilitaet);
            this.tpgSelbststaendigkeit.Location = new System.Drawing.Point(6, 6);
            this.tpgSelbststaendigkeit.Name = "tpgSelbststaendigkeit";
            this.tpgSelbststaendigkeit.Size = new System.Drawing.Size(710, 518);
            this.tpgSelbststaendigkeit.TabIndex = 2;
            this.tpgSelbststaendigkeit.Title = "Selbstständig&keit";
            //
            // lblMobilitaet
            //
            this.lblMobilitaet.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMobilitaet.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblMobilitaet.Location = new System.Drawing.Point(9, 9);
            this.lblMobilitaet.Name = "lblMobilitaet";
            this.lblMobilitaet.Size = new System.Drawing.Size(107, 66);
            this.lblMobilitaet.TabIndex = 0;
            this.lblMobilitaet.Text = "Mobilität";
            this.lblMobilitaet.UseCompatibleTextRendering = true;
            //
            // edtMobilitaet
            //
            this.edtMobilitaet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMobilitaet.DataMember = "SelbstaendigMobilitaet";
            this.edtMobilitaet.DataSource = this.qryFaBetreuungsinfo;
            this.edtMobilitaet.Location = new System.Drawing.Point(122, 9);
            this.edtMobilitaet.Name = "edtMobilitaet";
            this.edtMobilitaet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMobilitaet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMobilitaet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMobilitaet.Properties.Appearance.Options.UseBackColor = true;
            this.edtMobilitaet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMobilitaet.Properties.Appearance.Options.UseFont = true;
            this.edtMobilitaet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMobilitaet.Size = new System.Drawing.Size(578, 66);
            this.edtMobilitaet.TabIndex = 1;
            //
            // lblAnkleiden
            //
            this.lblAnkleiden.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAnkleiden.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblAnkleiden.Location = new System.Drawing.Point(9, 81);
            this.lblAnkleiden.Name = "lblAnkleiden";
            this.lblAnkleiden.Size = new System.Drawing.Size(107, 66);
            this.lblAnkleiden.TabIndex = 2;
            this.lblAnkleiden.Text = "An-/Auskleiden";
            this.lblAnkleiden.UseCompatibleTextRendering = true;
            //
            // edtAnkleiden
            //
            this.edtAnkleiden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAnkleiden.DataMember = "SelbstaendigKleiden";
            this.edtAnkleiden.DataSource = this.qryFaBetreuungsinfo;
            this.edtAnkleiden.Location = new System.Drawing.Point(122, 81);
            this.edtAnkleiden.Name = "edtAnkleiden";
            this.edtAnkleiden.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnkleiden.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnkleiden.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnkleiden.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnkleiden.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnkleiden.Properties.Appearance.Options.UseFont = true;
            this.edtAnkleiden.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnkleiden.Size = new System.Drawing.Size(578, 66);
            this.edtAnkleiden.TabIndex = 3;
            //
            // lblNahrungsaufnahme
            //
            this.lblNahrungsaufnahme.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNahrungsaufnahme.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblNahrungsaufnahme.Location = new System.Drawing.Point(9, 153);
            this.lblNahrungsaufnahme.Name = "lblNahrungsaufnahme";
            this.lblNahrungsaufnahme.Size = new System.Drawing.Size(107, 66);
            this.lblNahrungsaufnahme.TabIndex = 4;
            this.lblNahrungsaufnahme.Text = "Nahrungsaufnahme";
            this.lblNahrungsaufnahme.UseCompatibleTextRendering = true;
            //
            // edtNahrungsaufnahme
            //
            this.edtNahrungsaufnahme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNahrungsaufnahme.DataMember = "SelbstaendigNahrung";
            this.edtNahrungsaufnahme.DataSource = this.qryFaBetreuungsinfo;
            this.edtNahrungsaufnahme.Location = new System.Drawing.Point(122, 153);
            this.edtNahrungsaufnahme.Name = "edtNahrungsaufnahme";
            this.edtNahrungsaufnahme.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNahrungsaufnahme.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNahrungsaufnahme.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNahrungsaufnahme.Properties.Appearance.Options.UseBackColor = true;
            this.edtNahrungsaufnahme.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNahrungsaufnahme.Properties.Appearance.Options.UseFont = true;
            this.edtNahrungsaufnahme.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNahrungsaufnahme.Size = new System.Drawing.Size(578, 66);
            this.edtNahrungsaufnahme.TabIndex = 5;
            //
            // lblGrundpflege
            //
            this.lblGrundpflege.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblGrundpflege.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblGrundpflege.Location = new System.Drawing.Point(9, 225);
            this.lblGrundpflege.Name = "lblGrundpflege";
            this.lblGrundpflege.Size = new System.Drawing.Size(107, 66);
            this.lblGrundpflege.TabIndex = 6;
            this.lblGrundpflege.Text = "Grundpflege";
            this.lblGrundpflege.UseCompatibleTextRendering = true;
            //
            // edtGrundpflege
            //
            this.edtGrundpflege.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGrundpflege.DataMember = "SelbstaendigGrundpflege";
            this.edtGrundpflege.DataSource = this.qryFaBetreuungsinfo;
            this.edtGrundpflege.Location = new System.Drawing.Point(122, 225);
            this.edtGrundpflege.Name = "edtGrundpflege";
            this.edtGrundpflege.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGrundpflege.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundpflege.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundpflege.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrundpflege.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrundpflege.Properties.Appearance.Options.UseFont = true;
            this.edtGrundpflege.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrundpflege.Size = new System.Drawing.Size(578, 66);
            this.edtGrundpflege.TabIndex = 7;
            //
            // lblToilette
            //
            this.lblToilette.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblToilette.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblToilette.Location = new System.Drawing.Point(9, 297);
            this.lblToilette.Name = "lblToilette";
            this.lblToilette.Size = new System.Drawing.Size(107, 66);
            this.lblToilette.TabIndex = 8;
            this.lblToilette.Text = "Toilette";
            this.lblToilette.UseCompatibleTextRendering = true;
            //
            // edtToilette
            //
            this.edtToilette.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtToilette.DataMember = "SelbstaendigToilette";
            this.edtToilette.DataSource = this.qryFaBetreuungsinfo;
            this.edtToilette.Location = new System.Drawing.Point(122, 297);
            this.edtToilette.Name = "edtToilette";
            this.edtToilette.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtToilette.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtToilette.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtToilette.Properties.Appearance.Options.UseBackColor = true;
            this.edtToilette.Properties.Appearance.Options.UseBorderColor = true;
            this.edtToilette.Properties.Appearance.Options.UseFont = true;
            this.edtToilette.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtToilette.Size = new System.Drawing.Size(578, 66);
            this.edtToilette.TabIndex = 9;
            //
            // lblSchlaf
            //
            this.lblSchlaf.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSchlaf.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSchlaf.Location = new System.Drawing.Point(9, 369);
            this.lblSchlaf.Name = "lblSchlaf";
            this.lblSchlaf.Size = new System.Drawing.Size(107, 66);
            this.lblSchlaf.TabIndex = 10;
            this.lblSchlaf.Text = "Schlaf";
            this.lblSchlaf.UseCompatibleTextRendering = true;
            //
            // edtSchlaf
            //
            this.edtSchlaf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSchlaf.DataMember = "SelbstaendigSchlaf";
            this.edtSchlaf.DataSource = this.qryFaBetreuungsinfo;
            this.edtSchlaf.Location = new System.Drawing.Point(122, 369);
            this.edtSchlaf.Name = "edtSchlaf";
            this.edtSchlaf.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSchlaf.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSchlaf.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSchlaf.Properties.Appearance.Options.UseBackColor = true;
            this.edtSchlaf.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSchlaf.Properties.Appearance.Options.UseFont = true;
            this.edtSchlaf.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSchlaf.Size = new System.Drawing.Size(578, 66);
            this.edtSchlaf.TabIndex = 11;
            //
            // lblVerschiedeneAktivitaeten
            //
            this.lblVerschiedeneAktivitaeten.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblVerschiedeneAktivitaeten.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblVerschiedeneAktivitaeten.Location = new System.Drawing.Point(9, 441);
            this.lblVerschiedeneAktivitaeten.Name = "lblVerschiedeneAktivitaeten";
            this.lblVerschiedeneAktivitaeten.Size = new System.Drawing.Size(107, 66);
            this.lblVerschiedeneAktivitaeten.TabIndex = 12;
            this.lblVerschiedeneAktivitaeten.Text = "Verschiedene Aktivitäten";
            this.lblVerschiedeneAktivitaeten.UseCompatibleTextRendering = true;
            //
            // edtVerschiedeneAktivitaeten
            //
            this.edtVerschiedeneAktivitaeten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtVerschiedeneAktivitaeten.DataMember = "SelbstaendigVerschiedenes";
            this.edtVerschiedeneAktivitaeten.DataSource = this.qryFaBetreuungsinfo;
            this.edtVerschiedeneAktivitaeten.Location = new System.Drawing.Point(122, 441);
            this.edtVerschiedeneAktivitaeten.Name = "edtVerschiedeneAktivitaeten";
            this.edtVerschiedeneAktivitaeten.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerschiedeneAktivitaeten.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerschiedeneAktivitaeten.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerschiedeneAktivitaeten.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerschiedeneAktivitaeten.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerschiedeneAktivitaeten.Properties.Appearance.Options.UseFont = true;
            this.edtVerschiedeneAktivitaeten.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVerschiedeneAktivitaeten.Size = new System.Drawing.Size(578, 66);
            this.edtVerschiedeneAktivitaeten.TabIndex = 13;
            //
            // panBottomSpacer
            //
            this.panBottomSpacer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottomSpacer.Location = new System.Drawing.Point(0, 586);
            this.panBottomSpacer.Name = "panBottomSpacer";
            this.panBottomSpacer.Size = new System.Drawing.Size(722, 10);
            this.panBottomSpacer.TabIndex = 2;
            //
            // docBericht
            //
            this.docBericht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.docBericht.Context = "FA_Betreuungsinfo_Bericht";
            this.docBericht.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docBericht.Image = ((System.Drawing.Image)(resources.GetObject("docBericht.Image")));
            this.docBericht.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.docBericht.Location = new System.Drawing.Point(625, 565);
            this.docBericht.Margin = new System.Windows.Forms.Padding(9);
            this.docBericht.Name = "docBericht";
            this.docBericht.Size = new System.Drawing.Size(90, 24);
            this.docBericht.TabIndex = 3;
            this.docBericht.Text = "Be&richt";
            this.docBericht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.docBericht.UseCompatibleTextRendering = true;
            this.docBericht.UseVisualStyleBackColor = false;
            //
            // qryFaBetreuungsinfo
            //
            this.qryFaBetreuungsinfo.HostControl = this;
            this.qryFaBetreuungsinfo.TableName = "FaBetreuungsinfo";
            this.qryFaBetreuungsinfo.BeforePost += new System.EventHandler(this.qryFaBetreuungsinfo_BeforePost);
            this.qryFaBetreuungsinfo.AfterFill += new System.EventHandler(this.qryFaBetreuungsinfo_AfterFill);
            this.qryFaBetreuungsinfo.AfterInsert += new System.EventHandler(this.qryFaBetreuungsinfo_AfterInsert);
            this.qryFaBetreuungsinfo.AfterPost += new System.EventHandler(this.qryFaBetreuungsinfo_AfterPost);
            //
            // btnNext
            //
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.IconID = 13;
            this.btnNext.Location = new System.Drawing.Point(692, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(24, 24);
            this.btnNext.TabIndex = 4;
            this.btnNext.UseCompatibleTextRendering = true;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            //
            // btnPrevious
            //
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.IconID = 11;
            this.btnPrevious.Location = new System.Drawing.Point(662, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(24, 24);
            this.btnPrevious.TabIndex = 3;
            this.btnPrevious.UseCompatibleTextRendering = true;
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Visible = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            //
            // CtlFaBetreuungsinfo
            //
            this.ActiveSQLQuery = this.qryFaBetreuungsinfo;
            this.AutoRefresh = false;
            this.Controls.Add(this.docBericht);
            this.Controls.Add(this.tabBetreuungsinfo);
            this.Controls.Add(this.panTitel);
            this.Controls.Add(this.panBottomSpacer);
            this.Name = "CtlFaBetreuungsinfo";
            this.Size = new System.Drawing.Size(722, 596);
            this.Load += new System.EventHandler(this.CtlFaBetreuungsinfo_Load);
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            this.tabBetreuungsinfo.ResumeLayout(false);
            this.tpgIndividualitaet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBehinderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBehinderung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersoenlichkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersoenlichkeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKommunikation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKommunikation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIntellektuell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntellektuell.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMotorik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMotorik.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFreizeitInteressen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFreizeitInteressen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNotfallInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNotfallInfo.Properties)).EndInit();
            this.tpgBetreuung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblVerhaltensstoerung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerhaltensstoerung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngstfaktoren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAngstfaktoren.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSicherheitGebendeElemente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSicherheitGebendeElemente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSollVerhindertWerden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSollVerhindertWerden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMedizinisches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMedizinisches.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMedikation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMedikation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErnaehrung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErnaehrung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTagesablauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTagesablauf.Properties)).EndInit();
            this.tpgSelbststaendigkeit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblMobilitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMobilitaet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnkleiden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnkleiden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNahrungsaufnahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNahrungsaufnahme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundpflege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundpflege.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblToilette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtToilette.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchlaf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchlaf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerschiedeneAktivitaeten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerschiedeneAktivitaeten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaBetreuungsinfo)).EndInit();
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

        #region Public Methods

        public override Object GetContextValue(String fieldName)
        {
            // logging
            logger.Debug("called");

            switch (fieldName.ToUpper())
            {
                case "FABETREUUNGSINFOID":
                    return qryFaBetreuungsinfo["FaBetreuungsinfoID"];

                case "BAPERSONID":
                    return this.BaPersonID;
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(String titleName, Image titleImage, Int32 baPersonID)
        {
            // logging
            logger.Debug("enter");
            logger.Debug(String.Format("baPersonID={0}, titleName={1}", baPersonID, titleName));

            // validate
            if (baPersonID < 1)
            {
                // do not continue
                qryFaBetreuungsinfo.CanUpdate = false;

                // handle editmode of controls
                qryFaBetreuungsinfo.EnableBoundFields(qryFaBetreuungsinfo.CanUpdate);
                return;
            }

            // allow updates
            qryFaBetreuungsinfo.CanUpdate = true;

            // apply values
            this.BaPersonID = baPersonID;
            this.picTitel.Image = titleImage;
            this.lblTitel.Text = titleName;

            // fill source
            qryFaBetreuungsinfo.Fill(@"
                    SELECT FBI.*
                    FROM dbo.FaBetreuungsinfo FBI WITH (READUNCOMMITTED)
                    WHERE FBI.BaPersonID = {0}
                    ORDER BY FBI.FaBetreuungsinfoID ASC", baPersonID);

            // insert new entry if not yet any entry found
            if (qryFaBetreuungsinfo.Count < 1)
            {
                qryFaBetreuungsinfo.Insert(null);
            }

            // update icons
            tabBetreuungsinfo.ShowIconUpdate();

            // logging
            logger.Debug(String.Format("ReadOnly={0}", edtMobilitaet.Properties.ReadOnly));
            logger.Debug("done");
        }

        #endregion

        #region Private Methods

        private void CtlFaBetreuungsinfo_Load(object sender, System.EventArgs e)
        {
            // logging
            logger.Debug("enter");

            // select first tab
            tabBetreuungsinfo.SelectedTabIndex = 0;

            // update icons
            tabBetreuungsinfo.ShowIconUpdate();

            // logging
            logger.Debug(String.Format("ReadOnly={0}", edtMobilitaet.Properties.ReadOnly));
            logger.Debug("done");
        }

        private void HandlePreviousNext(Navigation navigationMode)
        {
            // check if we have more than one entry
            if (qryFaBetreuungsinfo.Count < 2)
            {
                // hide buttons
                btnPrevious.Visible = false;
                btnNext.Visible = false;

                // do not continue
                return;
            }

            // show buttons
            btnPrevious.Visible = true;
            btnNext.Visible = true;

            // check if we can save changes
            if (!qryFaBetreuungsinfo.Post())
            {
                return;
            }

            // do navigation
            switch (navigationMode)
            {
                case Navigation.None:
                    // do nothing
                    break;

                case Navigation.Previous:
                    // goto previous entry
                    qryFaBetreuungsinfo.Previous();
                    break;

                case Navigation.Next:
                    // goto next entry
                    qryFaBetreuungsinfo.Next();
                    break;
            }

            // enable/disable buttons depending on current position (zero-based)
            btnPrevious.Enabled = qryFaBetreuungsinfo.Position > 0;
            btnNext.Enabled = qryFaBetreuungsinfo.Position < (qryFaBetreuungsinfo.Count - 1);

            // update icons
            tabBetreuungsinfo.ShowIconUpdate();
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            // goto next entry
            this.HandlePreviousNext(Navigation.Next);
        }

        private void btnPrevious_Click(object sender, System.EventArgs e)
        {
            // goto previous entry
            this.HandlePreviousNext(Navigation.Previous);
        }

        private void qryFaBetreuungsinfo_AfterFill(object sender, System.EventArgs e)
        {
            // enable / disable buttons
            this.HandlePreviousNext(Navigation.None);
        }

        private void qryFaBetreuungsinfo_AfterInsert(object sender, System.EventArgs e)
        {
            // logging
            logger.Debug("enter");

            // apply person
            qryFaBetreuungsinfo["BaPersonID"] = this.BaPersonID;

            // creator of row
            qryFaBetreuungsinfo["Creator"] = DBUtil.GetDBRowCreatorModifier();

            // logging
            logger.Debug("done");
        }

        private void qryFaBetreuungsinfo_AfterPost(object sender, System.EventArgs e)
        {
            // logging
            logger.Debug("enter");

            // update icons
            tabBetreuungsinfo.ShowIconUpdate();

            // logging
            logger.Debug("done");
        }

        private void qryFaBetreuungsinfo_BeforePost(object sender, System.EventArgs e)
        {
            // logging
            logger.Debug("enter");

            // check if valid person is applied
            if (DBUtil.IsEmpty(qryFaBetreuungsinfo["BaPersonID"]) || Convert.ToInt32(qryFaBetreuungsinfo["BaPersonID"]) < 1)
            {
                KissMsg.ShowError("CtlFaBetreuungsinfo", "InvalidBaPersonIDOnPost", "Der Datensatz hat keine gültige BaPersonID und kann deshalb nicht gespeichert werden.");

                // do not continue
                throw new KissCancelException();
            }

            // logging
            logger.Debug("done");
        }

        #endregion
    }
}