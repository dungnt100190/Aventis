using System;
using System.ComponentModel;

using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Common.PI
{
    /// <summary>
    /// Control to show case information and manage some entries
    /// </summary>
    public class CtlFallInfo : KissUserControl
    {
        #region Enumerations

        /// <summary>
        /// The access mode, used to setup control for various modes
        /// </summary>
        public enum AccessMode
        {
            /// <summary>
            /// Show only values without any edit possibilities (default)
            /// </summary>
            ShowOnly,

            /// <summary>
            /// Show and allow to edit some data. Warning: Critical data can be edited!
            /// </summary>
            AllowEdit
        }

        #endregion

        #region Fields

        #region Private Fields

        /// <summary>
        /// Store the BaPersonID of current client
        /// </summary>
        private int _baPersonID = -1;

        /// <summary>
        /// Flag to store if user confirmed deleting data on FaLeistung
        /// </summary>
        private bool _confirmedDeleteFaLeistung = false;

        /// <summary>
        /// Flag to store if user confirmed editing data on FaLeistung
        /// </summary>
        private bool _confirmedUpdateFaLeistung = false;

        /// <summary>
        /// Store the current access mode and set default
        /// </summary>
        private AccessMode _currentAccessMode = AccessMode.ShowOnly;
        private KissButton btnDeleteFaLeistungID;
        private KissButton btnUpdateFaLeistungID;
        private DevExpress.XtraGrid.Columns.GridColumn colAbteilung;
        private DevExpress.XtraGrid.Columns.GridColumn colFaLeistungID;
        private DevExpress.XtraGrid.Columns.GridColumn colFallverlauf;
        private DevExpress.XtraGrid.Columns.GridColumn colIcon;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistung;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistungDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colLeistungDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colMitarbeiter;
        private System.ComponentModel.IContainer components = null;
        private KissDateEdit edtEditDatumBis;
        private KissDateEdit edtEditDatumVon;
        private KissCalcEdit edtEditFaLeistungID;
        private KissLookUpEdit edtEditUserID;
        private KiSS4.Gui.KissTextEdit edtKlientEmail;
        private KiSS4.Gui.KissDateEdit edtKlientGeburtsdatum;
        private KiSS4.Gui.KissTextEdit edtKlientIVBerechtigung;
        private KiSS4.Gui.KissTextEdit edtKlientNameVorname;
        private KiSS4.Gui.KissTextEdit edtKlientNeueVersNr;
        private KiSS4.Gui.KissTextEdit edtKlientTelefonG;
        private KiSS4.Gui.KissTextEdit edtKlientTelefonMobil;
        private KiSS4.Gui.KissTextEdit edtKlientTelefonP;
        private KiSS4.Gui.KissTextEdit edtKlientWichtigerHinweis;
        private KiSS4.Gui.KissTextEdit edtKlientWohnsitz;
        private KiSS4.Gui.KissTextEdit edtMAAbteilung;
        private KiSS4.Gui.KissTextEdit edtMAEmail;
        private KiSS4.Gui.KissTextEdit edtMANameVorname;
        private KiSS4.Gui.KissTextEdit edtMATelefon;
        private KiSS4.Gui.KissGrid grdFallInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFallInfo;
        private KissLabel lblEditDatumBis;
        private KissLabel lblEditDatumVon;
        private KissLabel lblEditFaLeistungID;
        private KissLabel lblEditUserID;
        private KiSS4.Gui.KissLabel lblInfoKlient;
        private KiSS4.Gui.KissLabel lblInfoMitarbeiter;
        private KissLabel lblInfoProzessDaten;
        private KiSS4.Gui.KissLabel lblKlientEmail;
        private KiSS4.Gui.KissLabel lblKlientGeburtsdatum;
        private KiSS4.Gui.KissLabel lblKlientIVBerechtigung;
        private KiSS4.Gui.KissLabel lblKlientNameVorname;
        private KiSS4.Gui.KissLabel lblKlientNeueVersNr;
        private KiSS4.Gui.KissLabel lblKlientTelefonG;
        private KiSS4.Gui.KissLabel lblKlientTelefonMobil;
        private KiSS4.Gui.KissLabel lblKlientTelefonP;
        private KiSS4.Gui.KissLabel lblKlientWichtigerHinweis;
        private KiSS4.Gui.KissLabel lblKlientWohnsitz;
        private KiSS4.Gui.KissLabel lblMAAbteilung;
        private KiSS4.Gui.KissLabel lblMAEmail;
        private KiSS4.Gui.KissLabel lblMANameVorname;
        private KiSS4.Gui.KissLabel lblMATelefon;
        private System.Windows.Forms.Panel panBottomClient;
        private System.Windows.Forms.Panel panBottomEditData;
        private System.Windows.Forms.Panel panBottomUser;
        private System.Windows.Forms.PictureBox picKlientWichtigerHinweis;
        private KiSS4.DB.SqlQuery qryBaPerson;
        private SqlQuery qryFaLeistung;
        private KiSS4.DB.SqlQuery qryFallInfo;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repItemIcon;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, used to create new instance of class
        /// </summary>
        public CtlFallInfo()
        {
            // init control
            InitializeComponent();

            // prepare control for showing to user
            SetupControl();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFallInfo));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.panBottomUser = new System.Windows.Forms.Panel();
            this.edtMAEmail = new KiSS4.Gui.KissTextEdit();
            this.qryFallInfo = new KiSS4.DB.SqlQuery();
            this.lblMAEmail = new KiSS4.Gui.KissLabel();
            this.edtMATelefon = new KiSS4.Gui.KissTextEdit();
            this.lblMATelefon = new KiSS4.Gui.KissLabel();
            this.edtMAAbteilung = new KiSS4.Gui.KissTextEdit();
            this.lblMAAbteilung = new KiSS4.Gui.KissLabel();
            this.edtMANameVorname = new KiSS4.Gui.KissTextEdit();
            this.lblMANameVorname = new KiSS4.Gui.KissLabel();
            this.lblInfoMitarbeiter = new KiSS4.Gui.KissLabel();
            this.picKlientWichtigerHinweis = new System.Windows.Forms.PictureBox();
            this.edtKlientWichtigerHinweis = new KiSS4.Gui.KissTextEdit();
            this.qryBaPerson = new KiSS4.DB.SqlQuery();
            this.lblKlientWichtigerHinweis = new KiSS4.Gui.KissLabel();
            this.edtKlientIVBerechtigung = new KiSS4.Gui.KissTextEdit();
            this.lblKlientIVBerechtigung = new KiSS4.Gui.KissLabel();
            this.edtKlientNeueVersNr = new KiSS4.Gui.KissTextEdit();
            this.lblKlientNeueVersNr = new KiSS4.Gui.KissLabel();
            this.edtKlientGeburtsdatum = new KiSS4.Gui.KissDateEdit();
            this.lblKlientGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.edtKlientEmail = new KiSS4.Gui.KissTextEdit();
            this.lblKlientEmail = new KiSS4.Gui.KissLabel();
            this.edtKlientTelefonMobil = new KiSS4.Gui.KissTextEdit();
            this.lblKlientTelefonMobil = new KiSS4.Gui.KissLabel();
            this.edtKlientTelefonG = new KiSS4.Gui.KissTextEdit();
            this.lblKlientTelefonG = new KiSS4.Gui.KissLabel();
            this.edtKlientTelefonP = new KiSS4.Gui.KissTextEdit();
            this.lblKlientTelefonP = new KiSS4.Gui.KissLabel();
            this.edtKlientWohnsitz = new KiSS4.Gui.KissTextEdit();
            this.lblKlientWohnsitz = new KiSS4.Gui.KissLabel();
            this.edtKlientNameVorname = new KiSS4.Gui.KissTextEdit();
            this.lblKlientNameVorname = new KiSS4.Gui.KissLabel();
            this.lblInfoKlient = new KiSS4.Gui.KissLabel();
            this.grdFallInfo = new KiSS4.Gui.KissGrid();
            this.grvFallInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallverlauf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIcon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemIcon = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colFaLeistungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistungDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeistungDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMitarbeiter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbteilung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panBottomEditData = new System.Windows.Forms.Panel();
            this.btnDeleteFaLeistungID = new KiSS4.Gui.KissButton();
            this.btnUpdateFaLeistungID = new KiSS4.Gui.KissButton();
            this.edtEditFaLeistungID = new KiSS4.Gui.KissCalcEdit();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery();
            this.edtEditUserID = new KiSS4.Gui.KissLookUpEdit();
            this.lblInfoProzessDaten = new KiSS4.Gui.KissLabel();
            this.lblEditDatumBis = new KiSS4.Gui.KissLabel();
            this.lblEditUserID = new KiSS4.Gui.KissLabel();
            this.lblEditFaLeistungID = new KiSS4.Gui.KissLabel();
            this.lblEditDatumVon = new KiSS4.Gui.KissLabel();
            this.edtEditDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtEditDatumVon = new KiSS4.Gui.KissDateEdit();
            this.panBottomClient = new System.Windows.Forms.Panel();
            this.panBottomUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMAEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFallInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMAEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMATelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMATelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMAAbteilung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMAAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMANameVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMANameVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfoMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKlientWichtigerHinweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientWichtigerHinweis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientWichtigerHinweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientIVBerechtigung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientIVBerechtigung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientNeueVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientNeueVersNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientGeburtsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientTelefonMobil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientTelefonMobil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientTelefonG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientTelefonG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientTelefonP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientTelefonP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientWohnsitz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientWohnsitz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientNameVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientNameVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfoKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFallInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFallInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemIcon)).BeginInit();
            this.panBottomEditData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtEditFaLeistungID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEditUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEditUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfoProzessDaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEditDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEditUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEditFaLeistungID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEditDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEditDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEditDatumVon.Properties)).BeginInit();
            this.panBottomClient.SuspendLayout();
            this.SuspendLayout();
            //
            // panBottomUser
            //
            this.panBottomUser.Controls.Add(this.edtMAEmail);
            this.panBottomUser.Controls.Add(this.lblMAEmail);
            this.panBottomUser.Controls.Add(this.edtMATelefon);
            this.panBottomUser.Controls.Add(this.lblMATelefon);
            this.panBottomUser.Controls.Add(this.edtMAAbteilung);
            this.panBottomUser.Controls.Add(this.lblMAAbteilung);
            this.panBottomUser.Controls.Add(this.edtMANameVorname);
            this.panBottomUser.Controls.Add(this.lblMANameVorname);
            this.panBottomUser.Controls.Add(this.lblInfoMitarbeiter);
            this.panBottomUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottomUser.Location = new System.Drawing.Point(0, 258);
            this.panBottomUser.Name = "panBottomUser";
            this.panBottomUser.Size = new System.Drawing.Size(780, 100);
            this.panBottomUser.TabIndex = 2;
            //
            // edtMAEmail
            //
            this.edtMAEmail.DataMember = "MAEmail";
            this.edtMAEmail.DataSource = this.qryFallInfo;
            this.edtMAEmail.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMAEmail.Location = new System.Drawing.Point(500, 62);
            this.edtMAEmail.Name = "edtMAEmail";
            this.edtMAEmail.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMAEmail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMAEmail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMAEmail.Properties.Appearance.Options.UseBackColor = true;
            this.edtMAEmail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMAEmail.Properties.Appearance.Options.UseFont = true;
            this.edtMAEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMAEmail.Properties.ReadOnly = true;
            this.edtMAEmail.Size = new System.Drawing.Size(221, 24);
            this.edtMAEmail.TabIndex = 8;
            //
            // qryFallInfo
            //
            this.qryFallInfo.HostControl = this;
            this.qryFallInfo.TableName = "FaLeistung";
            this.qryFallInfo.PositionChanged += new System.EventHandler(this.qryFallInfo_PositionChanged);
            //
            // lblMAEmail
            //
            this.lblMAEmail.Location = new System.Drawing.Point(398, 62);
            this.lblMAEmail.Name = "lblMAEmail";
            this.lblMAEmail.Size = new System.Drawing.Size(96, 24);
            this.lblMAEmail.TabIndex = 7;
            this.lblMAEmail.Text = "E-Mail";
            this.lblMAEmail.UseCompatibleTextRendering = true;
            //
            // edtMATelefon
            //
            this.edtMATelefon.DataMember = "MATelefon";
            this.edtMATelefon.DataSource = this.qryFallInfo;
            this.edtMATelefon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMATelefon.Location = new System.Drawing.Point(500, 32);
            this.edtMATelefon.Name = "edtMATelefon";
            this.edtMATelefon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMATelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMATelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMATelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtMATelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMATelefon.Properties.Appearance.Options.UseFont = true;
            this.edtMATelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMATelefon.Properties.ReadOnly = true;
            this.edtMATelefon.Size = new System.Drawing.Size(221, 24);
            this.edtMATelefon.TabIndex = 6;
            //
            // lblMATelefon
            //
            this.lblMATelefon.Location = new System.Drawing.Point(398, 32);
            this.lblMATelefon.Name = "lblMATelefon";
            this.lblMATelefon.Size = new System.Drawing.Size(96, 24);
            this.lblMATelefon.TabIndex = 5;
            this.lblMATelefon.Text = "Telefon";
            this.lblMATelefon.UseCompatibleTextRendering = true;
            //
            // edtMAAbteilung
            //
            this.edtMAAbteilung.DataMember = "MAAbteilung";
            this.edtMAAbteilung.DataSource = this.qryFallInfo;
            this.edtMAAbteilung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMAAbteilung.Location = new System.Drawing.Point(138, 62);
            this.edtMAAbteilung.Name = "edtMAAbteilung";
            this.edtMAAbteilung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMAAbteilung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMAAbteilung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMAAbteilung.Properties.Appearance.Options.UseBackColor = true;
            this.edtMAAbteilung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMAAbteilung.Properties.Appearance.Options.UseFont = true;
            this.edtMAAbteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMAAbteilung.Properties.ReadOnly = true;
            this.edtMAAbteilung.Size = new System.Drawing.Size(221, 24);
            this.edtMAAbteilung.TabIndex = 4;
            //
            // lblMAAbteilung
            //
            this.lblMAAbteilung.Location = new System.Drawing.Point(9, 62);
            this.lblMAAbteilung.Name = "lblMAAbteilung";
            this.lblMAAbteilung.Size = new System.Drawing.Size(123, 24);
            this.lblMAAbteilung.TabIndex = 3;
            this.lblMAAbteilung.Text = "Abteilung";
            this.lblMAAbteilung.UseCompatibleTextRendering = true;
            //
            // edtMANameVorname
            //
            this.edtMANameVorname.DataMember = "MANameVorname";
            this.edtMANameVorname.DataSource = this.qryFallInfo;
            this.edtMANameVorname.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMANameVorname.Location = new System.Drawing.Point(138, 32);
            this.edtMANameVorname.Name = "edtMANameVorname";
            this.edtMANameVorname.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMANameVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMANameVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMANameVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtMANameVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMANameVorname.Properties.Appearance.Options.UseFont = true;
            this.edtMANameVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMANameVorname.Properties.ReadOnly = true;
            this.edtMANameVorname.Size = new System.Drawing.Size(221, 24);
            this.edtMANameVorname.TabIndex = 2;
            //
            // lblMANameVorname
            //
            this.lblMANameVorname.Location = new System.Drawing.Point(9, 32);
            this.lblMANameVorname.Name = "lblMANameVorname";
            this.lblMANameVorname.Size = new System.Drawing.Size(123, 24);
            this.lblMANameVorname.TabIndex = 1;
            this.lblMANameVorname.Text = "Name / Vorname";
            this.lblMANameVorname.UseCompatibleTextRendering = true;
            //
            // lblInfoMitarbeiter
            //
            this.lblInfoMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoMitarbeiter.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblInfoMitarbeiter.Location = new System.Drawing.Point(9, 9);
            this.lblInfoMitarbeiter.Name = "lblInfoMitarbeiter";
            this.lblInfoMitarbeiter.Size = new System.Drawing.Size(759, 16);
            this.lblInfoMitarbeiter.TabIndex = 0;
            this.lblInfoMitarbeiter.Text = "Verantwortliche/r MA";
            this.lblInfoMitarbeiter.UseCompatibleTextRendering = true;
            //
            // picKlientWichtigerHinweis
            //
            this.picKlientWichtigerHinweis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picKlientWichtigerHinweis.Location = new System.Drawing.Point(751, 214);
            this.picKlientWichtigerHinweis.Name = "picKlientWichtigerHinweis";
            this.picKlientWichtigerHinweis.Size = new System.Drawing.Size(16, 16);
            this.picKlientWichtigerHinweis.TabIndex = 65;
            this.picKlientWichtigerHinweis.TabStop = false;
            this.picKlientWichtigerHinweis.Visible = false;
            //
            // edtKlientWichtigerHinweis
            //
            this.edtKlientWichtigerHinweis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKlientWichtigerHinweis.DataMember = "WichtigerHinweis";
            this.edtKlientWichtigerHinweis.DataSource = this.qryBaPerson;
            this.edtKlientWichtigerHinweis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKlientWichtigerHinweis.Location = new System.Drawing.Point(138, 210);
            this.edtKlientWichtigerHinweis.Name = "edtKlientWichtigerHinweis";
            this.edtKlientWichtigerHinweis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKlientWichtigerHinweis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlientWichtigerHinweis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlientWichtigerHinweis.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlientWichtigerHinweis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlientWichtigerHinweis.Properties.Appearance.Options.UseFont = true;
            this.edtKlientWichtigerHinweis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKlientWichtigerHinweis.Properties.ReadOnly = true;
            this.edtKlientWichtigerHinweis.Size = new System.Drawing.Size(629, 24);
            this.edtKlientWichtigerHinweis.TabIndex = 22;
            //
            // qryBaPerson
            //
            this.qryBaPerson.HostControl = this;
            this.qryBaPerson.TableName = "BaPerson";
            //
            // lblKlientWichtigerHinweis
            //
            this.lblKlientWichtigerHinweis.Location = new System.Drawing.Point(9, 210);
            this.lblKlientWichtigerHinweis.Name = "lblKlientWichtigerHinweis";
            this.lblKlientWichtigerHinweis.Size = new System.Drawing.Size(123, 24);
            this.lblKlientWichtigerHinweis.TabIndex = 21;
            this.lblKlientWichtigerHinweis.Text = "Wichtiger Hinw.";
            this.lblKlientWichtigerHinweis.UseCompatibleTextRendering = true;
            //
            // edtKlientIVBerechtigung
            //
            this.edtKlientIVBerechtigung.DataMember = "IVBerechtigung";
            this.edtKlientIVBerechtigung.DataSource = this.qryBaPerson;
            this.edtKlientIVBerechtigung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKlientIVBerechtigung.Location = new System.Drawing.Point(527, 149);
            this.edtKlientIVBerechtigung.Name = "edtKlientIVBerechtigung";
            this.edtKlientIVBerechtigung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKlientIVBerechtigung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlientIVBerechtigung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlientIVBerechtigung.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlientIVBerechtigung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlientIVBerechtigung.Properties.Appearance.Options.UseFont = true;
            this.edtKlientIVBerechtigung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKlientIVBerechtigung.Properties.ReadOnly = true;
            this.edtKlientIVBerechtigung.Size = new System.Drawing.Size(194, 24);
            this.edtKlientIVBerechtigung.TabIndex = 20;
            //
            // lblKlientIVBerechtigung
            //
            this.lblKlientIVBerechtigung.Location = new System.Drawing.Point(398, 149);
            this.lblKlientIVBerechtigung.Name = "lblKlientIVBerechtigung";
            this.lblKlientIVBerechtigung.Size = new System.Drawing.Size(123, 24);
            this.lblKlientIVBerechtigung.TabIndex = 19;
            this.lblKlientIVBerechtigung.Text = "IV-Berechtigung";
            this.lblKlientIVBerechtigung.UseCompatibleTextRendering = true;
            //
            // edtKlientNeueVersNr
            //
            this.edtKlientNeueVersNr.DataMember = "VersichertenNummer";
            this.edtKlientNeueVersNr.DataSource = this.qryBaPerson;
            this.edtKlientNeueVersNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKlientNeueVersNr.Location = new System.Drawing.Point(527, 119);
            this.edtKlientNeueVersNr.Name = "edtKlientNeueVersNr";
            this.edtKlientNeueVersNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKlientNeueVersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlientNeueVersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlientNeueVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlientNeueVersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlientNeueVersNr.Properties.Appearance.Options.UseFont = true;
            this.edtKlientNeueVersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKlientNeueVersNr.Properties.ReadOnly = true;
            this.edtKlientNeueVersNr.Size = new System.Drawing.Size(194, 24);
            this.edtKlientNeueVersNr.TabIndex = 18;
            //
            // lblKlientNeueVersNr
            //
            this.lblKlientNeueVersNr.Location = new System.Drawing.Point(398, 119);
            this.lblKlientNeueVersNr.Name = "lblKlientNeueVersNr";
            this.lblKlientNeueVersNr.Size = new System.Drawing.Size(123, 24);
            this.lblKlientNeueVersNr.TabIndex = 17;
            this.lblKlientNeueVersNr.Text = "Vers.-Nr.";
            this.lblKlientNeueVersNr.UseCompatibleTextRendering = true;
            //
            // edtKlientGeburtsdatum
            //
            this.edtKlientGeburtsdatum.DataMember = "Geburtsdatum";
            this.edtKlientGeburtsdatum.DataSource = this.qryBaPerson;
            this.edtKlientGeburtsdatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKlientGeburtsdatum.EditValue = null;
            this.edtKlientGeburtsdatum.Location = new System.Drawing.Point(527, 89);
            this.edtKlientGeburtsdatum.Name = "edtKlientGeburtsdatum";
            this.edtKlientGeburtsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKlientGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKlientGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlientGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlientGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlientGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlientGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtKlientGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtKlientGeburtsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtKlientGeburtsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtKlientGeburtsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKlientGeburtsdatum.Properties.ReadOnly = true;
            this.edtKlientGeburtsdatum.Properties.ShowToday = false;
            this.edtKlientGeburtsdatum.Size = new System.Drawing.Size(95, 24);
            this.edtKlientGeburtsdatum.TabIndex = 14;
            //
            // lblKlientGeburtsdatum
            //
            this.lblKlientGeburtsdatum.Location = new System.Drawing.Point(398, 89);
            this.lblKlientGeburtsdatum.Name = "lblKlientGeburtsdatum";
            this.lblKlientGeburtsdatum.Size = new System.Drawing.Size(123, 24);
            this.lblKlientGeburtsdatum.TabIndex = 13;
            this.lblKlientGeburtsdatum.Text = "Geburtsdatum";
            this.lblKlientGeburtsdatum.UseCompatibleTextRendering = true;
            //
            // edtKlientEmail
            //
            this.edtKlientEmail.DataMember = "EMail";
            this.edtKlientEmail.DataSource = this.qryBaPerson;
            this.edtKlientEmail.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKlientEmail.Location = new System.Drawing.Point(138, 179);
            this.edtKlientEmail.Name = "edtKlientEmail";
            this.edtKlientEmail.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKlientEmail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlientEmail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlientEmail.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlientEmail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlientEmail.Properties.Appearance.Options.UseFont = true;
            this.edtKlientEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKlientEmail.Properties.ReadOnly = true;
            this.edtKlientEmail.Size = new System.Drawing.Size(221, 24);
            this.edtKlientEmail.TabIndex = 12;
            //
            // lblKlientEmail
            //
            this.lblKlientEmail.Location = new System.Drawing.Point(9, 179);
            this.lblKlientEmail.Name = "lblKlientEmail";
            this.lblKlientEmail.Size = new System.Drawing.Size(123, 24);
            this.lblKlientEmail.TabIndex = 11;
            this.lblKlientEmail.Text = "E-Mail";
            this.lblKlientEmail.UseCompatibleTextRendering = true;
            //
            // edtKlientTelefonMobil
            //
            this.edtKlientTelefonMobil.DataMember = "MobilTel";
            this.edtKlientTelefonMobil.DataSource = this.qryBaPerson;
            this.edtKlientTelefonMobil.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKlientTelefonMobil.Location = new System.Drawing.Point(138, 149);
            this.edtKlientTelefonMobil.Name = "edtKlientTelefonMobil";
            this.edtKlientTelefonMobil.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKlientTelefonMobil.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlientTelefonMobil.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlientTelefonMobil.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlientTelefonMobil.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlientTelefonMobil.Properties.Appearance.Options.UseFont = true;
            this.edtKlientTelefonMobil.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKlientTelefonMobil.Properties.ReadOnly = true;
            this.edtKlientTelefonMobil.Size = new System.Drawing.Size(221, 24);
            this.edtKlientTelefonMobil.TabIndex = 10;
            //
            // lblKlientTelefonMobil
            //
            this.lblKlientTelefonMobil.Location = new System.Drawing.Point(9, 149);
            this.lblKlientTelefonMobil.Name = "lblKlientTelefonMobil";
            this.lblKlientTelefonMobil.Size = new System.Drawing.Size(123, 24);
            this.lblKlientTelefonMobil.TabIndex = 9;
            this.lblKlientTelefonMobil.Text = "Telefon mobil";
            this.lblKlientTelefonMobil.UseCompatibleTextRendering = true;
            //
            // edtKlientTelefonG
            //
            this.edtKlientTelefonG.DataMember = "Telefon_G";
            this.edtKlientTelefonG.DataSource = this.qryBaPerson;
            this.edtKlientTelefonG.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKlientTelefonG.Location = new System.Drawing.Point(138, 119);
            this.edtKlientTelefonG.Name = "edtKlientTelefonG";
            this.edtKlientTelefonG.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKlientTelefonG.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlientTelefonG.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlientTelefonG.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlientTelefonG.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlientTelefonG.Properties.Appearance.Options.UseFont = true;
            this.edtKlientTelefonG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKlientTelefonG.Properties.ReadOnly = true;
            this.edtKlientTelefonG.Size = new System.Drawing.Size(221, 24);
            this.edtKlientTelefonG.TabIndex = 8;
            //
            // lblKlientTelefonG
            //
            this.lblKlientTelefonG.Location = new System.Drawing.Point(9, 119);
            this.lblKlientTelefonG.Name = "lblKlientTelefonG";
            this.lblKlientTelefonG.Size = new System.Drawing.Size(123, 24);
            this.lblKlientTelefonG.TabIndex = 7;
            this.lblKlientTelefonG.Text = "Telefon gesch.";
            this.lblKlientTelefonG.UseCompatibleTextRendering = true;
            //
            // edtKlientTelefonP
            //
            this.edtKlientTelefonP.DataMember = "Telefon_P";
            this.edtKlientTelefonP.DataSource = this.qryBaPerson;
            this.edtKlientTelefonP.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKlientTelefonP.Location = new System.Drawing.Point(138, 89);
            this.edtKlientTelefonP.Name = "edtKlientTelefonP";
            this.edtKlientTelefonP.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKlientTelefonP.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlientTelefonP.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlientTelefonP.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlientTelefonP.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlientTelefonP.Properties.Appearance.Options.UseFont = true;
            this.edtKlientTelefonP.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKlientTelefonP.Properties.ReadOnly = true;
            this.edtKlientTelefonP.Size = new System.Drawing.Size(221, 24);
            this.edtKlientTelefonP.TabIndex = 6;
            //
            // lblKlientTelefonP
            //
            this.lblKlientTelefonP.Location = new System.Drawing.Point(9, 89);
            this.lblKlientTelefonP.Name = "lblKlientTelefonP";
            this.lblKlientTelefonP.Size = new System.Drawing.Size(123, 24);
            this.lblKlientTelefonP.TabIndex = 5;
            this.lblKlientTelefonP.Text = "Telefon privat";
            this.lblKlientTelefonP.UseCompatibleTextRendering = true;
            //
            // edtKlientWohnsitz
            //
            this.edtKlientWohnsitz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKlientWohnsitz.DataMember = "WohnsitzAdresse";
            this.edtKlientWohnsitz.DataSource = this.qryBaPerson;
            this.edtKlientWohnsitz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKlientWohnsitz.Location = new System.Drawing.Point(138, 59);
            this.edtKlientWohnsitz.Name = "edtKlientWohnsitz";
            this.edtKlientWohnsitz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKlientWohnsitz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlientWohnsitz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlientWohnsitz.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlientWohnsitz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlientWohnsitz.Properties.Appearance.Options.UseFont = true;
            this.edtKlientWohnsitz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKlientWohnsitz.Properties.ReadOnly = true;
            this.edtKlientWohnsitz.Size = new System.Drawing.Size(629, 24);
            this.edtKlientWohnsitz.TabIndex = 4;
            //
            // lblKlientWohnsitz
            //
            this.lblKlientWohnsitz.Location = new System.Drawing.Point(9, 59);
            this.lblKlientWohnsitz.Name = "lblKlientWohnsitz";
            this.lblKlientWohnsitz.Size = new System.Drawing.Size(123, 24);
            this.lblKlientWohnsitz.TabIndex = 3;
            this.lblKlientWohnsitz.Text = "Wohnsitz (gesetzl.)";
            this.lblKlientWohnsitz.UseCompatibleTextRendering = true;
            //
            // edtKlientNameVorname
            //
            this.edtKlientNameVorname.DataMember = "NameVorname";
            this.edtKlientNameVorname.DataSource = this.qryBaPerson;
            this.edtKlientNameVorname.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKlientNameVorname.Location = new System.Drawing.Point(138, 29);
            this.edtKlientNameVorname.Name = "edtKlientNameVorname";
            this.edtKlientNameVorname.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKlientNameVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlientNameVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlientNameVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlientNameVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlientNameVorname.Properties.Appearance.Options.UseFont = true;
            this.edtKlientNameVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKlientNameVorname.Properties.ReadOnly = true;
            this.edtKlientNameVorname.Size = new System.Drawing.Size(221, 24);
            this.edtKlientNameVorname.TabIndex = 2;
            //
            // lblKlientNameVorname
            //
            this.lblKlientNameVorname.Location = new System.Drawing.Point(9, 29);
            this.lblKlientNameVorname.Name = "lblKlientNameVorname";
            this.lblKlientNameVorname.Size = new System.Drawing.Size(123, 24);
            this.lblKlientNameVorname.TabIndex = 1;
            this.lblKlientNameVorname.Text = "Name / Vorname";
            this.lblKlientNameVorname.UseCompatibleTextRendering = true;
            //
            // lblInfoKlient
            //
            this.lblInfoKlient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoKlient.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblInfoKlient.Location = new System.Drawing.Point(9, 7);
            this.lblInfoKlient.Name = "lblInfoKlient";
            this.lblInfoKlient.Size = new System.Drawing.Size(146, 16);
            this.lblInfoKlient.TabIndex = 0;
            this.lblInfoKlient.Text = "Klient/in";
            this.lblInfoKlient.UseCompatibleTextRendering = true;
            //
            // grdFallInfo
            //
            this.grdFallInfo.DataSource = this.qryFallInfo;
            this.grdFallInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFallInfo.EmbeddedNavigator.Name = "";
            this.grdFallInfo.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFallInfo.Location = new System.Drawing.Point(0, 0);
            this.grdFallInfo.MainView = this.grvFallInfo;
            this.grdFallInfo.Name = "grdFallInfo";
            this.grdFallInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemIcon});
            this.grdFallInfo.Size = new System.Drawing.Size(780, 128);
            this.grdFallInfo.TabIndex = 0;
            this.grdFallInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFallInfo});
            //
            // grvFallInfo
            //
            this.grvFallInfo.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFallInfo.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFallInfo.Appearance.Empty.Options.UseBackColor = true;
            this.grvFallInfo.Appearance.Empty.Options.UseFont = true;
            this.grvFallInfo.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFallInfo.Appearance.EvenRow.Options.UseFont = true;
            this.grvFallInfo.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFallInfo.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFallInfo.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFallInfo.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFallInfo.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFallInfo.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFallInfo.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFallInfo.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFallInfo.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFallInfo.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFallInfo.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFallInfo.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFallInfo.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFallInfo.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFallInfo.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFallInfo.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFallInfo.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFallInfo.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFallInfo.Appearance.GroupRow.Options.UseFont = true;
            this.grvFallInfo.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFallInfo.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFallInfo.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFallInfo.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFallInfo.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFallInfo.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFallInfo.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFallInfo.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFallInfo.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFallInfo.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFallInfo.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFallInfo.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFallInfo.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFallInfo.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFallInfo.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFallInfo.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFallInfo.Appearance.OddRow.Options.UseFont = true;
            this.grvFallInfo.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFallInfo.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFallInfo.Appearance.Row.Options.UseBackColor = true;
            this.grvFallInfo.Appearance.Row.Options.UseFont = true;
            this.grvFallInfo.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFallInfo.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFallInfo.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFallInfo.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFallInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFallInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKey,
            this.colFallverlauf,
            this.colIcon,
            this.colFaLeistungID,
            this.colLeistung,
            this.colLeistungDatumVon,
            this.colLeistungDatumBis,
            this.colMitarbeiter,
            this.colAbteilung});
            this.grvFallInfo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFallInfo.GridControl = this.grdFallInfo;
            this.grvFallInfo.GroupFormat = "[#image]{1} {2}";
            this.grvFallInfo.Name = "grvFallInfo";
            this.grvFallInfo.OptionsBehavior.Editable = false;
            this.grvFallInfo.OptionsCustomization.AllowColumnMoving = false;
            this.grvFallInfo.OptionsCustomization.AllowFilter = false;
            this.grvFallInfo.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFallInfo.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFallInfo.OptionsNavigation.UseTabKey = false;
            this.grvFallInfo.OptionsView.ColumnAutoWidth = false;
            this.grvFallInfo.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFallInfo.OptionsView.ShowGroupPanel = false;
            this.grvFallInfo.OptionsView.ShowIndicator = false;
            //
            // colKey
            //
            this.colKey.Caption = "Key";
            this.colKey.FieldName = "Key";
            this.colKey.Name = "colKey";
            //
            // colFallverlauf
            //
            this.colFallverlauf.Caption = "Fallverlauf";
            this.colFallverlauf.FieldName = "Fallverlauf";
            this.colFallverlauf.Name = "colFallverlauf";
            //
            // colIcon
            //
            this.colIcon.AppearanceCell.Options.UseTextOptions = true;
            this.colIcon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIcon.ColumnEdit = this.repItemIcon;
            this.colIcon.FieldName = "Icon";
            this.colIcon.Name = "colIcon";
            this.colIcon.Visible = true;
            this.colIcon.VisibleIndex = 0;
            this.colIcon.Width = 29;
            //
            // repItemIcon
            //
            this.repItemIcon.Name = "repItemIcon";
            this.repItemIcon.NullText = "No Image";
            //
            // colFaLeistungID
            //
            this.colFaLeistungID.Caption = "Nr.";
            this.colFaLeistungID.FieldName = "FaLeistungID";
            this.colFaLeistungID.Name = "colFaLeistungID";
            this.colFaLeistungID.Visible = true;
            this.colFaLeistungID.VisibleIndex = 1;
            this.colFaLeistungID.Width = 60;
            //
            // colLeistung
            //
            this.colLeistung.Caption = "Prozess";
            this.colLeistung.FieldName = "LeistungModulName";
            this.colLeistung.Name = "colLeistung";
            this.colLeistung.Visible = true;
            this.colLeistung.VisibleIndex = 2;
            this.colLeistung.Width = 175;
            //
            // colLeistungDatumVon
            //
            this.colLeistungDatumVon.Caption = "Datum von";
            this.colLeistungDatumVon.FieldName = "DatumVon";
            this.colLeistungDatumVon.Name = "colLeistungDatumVon";
            this.colLeistungDatumVon.Visible = true;
            this.colLeistungDatumVon.VisibleIndex = 3;
            this.colLeistungDatumVon.Width = 80;
            //
            // colLeistungDatumBis
            //
            this.colLeistungDatumBis.Caption = "Datum bis";
            this.colLeistungDatumBis.FieldName = "DatumBis";
            this.colLeistungDatumBis.Name = "colLeistungDatumBis";
            this.colLeistungDatumBis.Visible = true;
            this.colLeistungDatumBis.VisibleIndex = 4;
            this.colLeistungDatumBis.Width = 80;
            //
            // colMitarbeiter
            //
            this.colMitarbeiter.Caption = "Mitarbeiter/in";
            this.colMitarbeiter.FieldName = "MANameVorname";
            this.colMitarbeiter.Name = "colMitarbeiter";
            this.colMitarbeiter.Visible = true;
            this.colMitarbeiter.VisibleIndex = 5;
            this.colMitarbeiter.Width = 220;
            //
            // colAbteilung
            //
            this.colAbteilung.Caption = "Abteilung";
            this.colAbteilung.FieldName = "MAAbteilung";
            this.colAbteilung.Name = "colAbteilung";
            this.colAbteilung.Visible = true;
            this.colAbteilung.VisibleIndex = 6;
            this.colAbteilung.Width = 120;
            //
            // panBottomEditData
            //
            this.panBottomEditData.Controls.Add(this.btnDeleteFaLeistungID);
            this.panBottomEditData.Controls.Add(this.btnUpdateFaLeistungID);
            this.panBottomEditData.Controls.Add(this.edtEditFaLeistungID);
            this.panBottomEditData.Controls.Add(this.edtEditUserID);
            this.panBottomEditData.Controls.Add(this.lblInfoProzessDaten);
            this.panBottomEditData.Controls.Add(this.lblEditDatumBis);
            this.panBottomEditData.Controls.Add(this.lblEditUserID);
            this.panBottomEditData.Controls.Add(this.lblEditFaLeistungID);
            this.panBottomEditData.Controls.Add(this.lblEditDatumVon);
            this.panBottomEditData.Controls.Add(this.edtEditDatumBis);
            this.panBottomEditData.Controls.Add(this.edtEditDatumVon);
            this.panBottomEditData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottomEditData.Location = new System.Drawing.Point(0, 128);
            this.panBottomEditData.Name = "panBottomEditData";
            this.panBottomEditData.Size = new System.Drawing.Size(780, 130);
            this.panBottomEditData.TabIndex = 1;
            //
            // btnDeleteFaLeistungID
            //
            this.btnDeleteFaLeistungID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFaLeistungID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFaLeistungID.IconID = 4;
            this.btnDeleteFaLeistungID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteFaLeistungID.Location = new System.Drawing.Point(579, 92);
            this.btnDeleteFaLeistungID.Name = "btnDeleteFaLeistungID";
            this.btnDeleteFaLeistungID.Size = new System.Drawing.Size(188, 24);
            this.btnDeleteFaLeistungID.TabIndex = 10;
            this.btnDeleteFaLeistungID.Text = "Prozessdaten löschen";
            this.btnDeleteFaLeistungID.UseVisualStyleBackColor = false;
            this.btnDeleteFaLeistungID.Click += new System.EventHandler(this.btnDeleteFaLeistungID_Click);
            //
            // btnUpdateFaLeistungID
            //
            this.btnUpdateFaLeistungID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateFaLeistungID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateFaLeistungID.IconID = 2;
            this.btnUpdateFaLeistungID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateFaLeistungID.Location = new System.Drawing.Point(579, 62);
            this.btnUpdateFaLeistungID.Name = "btnUpdateFaLeistungID";
            this.btnUpdateFaLeistungID.Size = new System.Drawing.Size(188, 24);
            this.btnUpdateFaLeistungID.TabIndex = 9;
            this.btnUpdateFaLeistungID.Text = "Prozessdaten ändern";
            this.btnUpdateFaLeistungID.UseVisualStyleBackColor = false;
            this.btnUpdateFaLeistungID.Click += new System.EventHandler(this.btnUpdateFaLeistungID_Click);
            //
            // edtEditFaLeistungID
            //
            this.edtEditFaLeistungID.DataMember = "FaLeistungID";
            this.edtEditFaLeistungID.DataSource = this.qryFaLeistung;
            this.edtEditFaLeistungID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEditFaLeistungID.Location = new System.Drawing.Point(138, 32);
            this.edtEditFaLeistungID.Name = "edtEditFaLeistungID";
            this.edtEditFaLeistungID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEditFaLeistungID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEditFaLeistungID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEditFaLeistungID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEditFaLeistungID.Properties.Appearance.Options.UseBackColor = true;
            this.edtEditFaLeistungID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEditFaLeistungID.Properties.Appearance.Options.UseFont = true;
            this.edtEditFaLeistungID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEditFaLeistungID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEditFaLeistungID.Properties.ReadOnly = true;
            this.edtEditFaLeistungID.Size = new System.Drawing.Size(95, 24);
            this.edtEditFaLeistungID.TabIndex = 2;
            //
            // qryFaLeistung
            //
            this.qryFaLeistung.DeleteQuestion = "";
            this.qryFaLeistung.HostControl = this;
            this.qryFaLeistung.TableName = "FaLeistung";
            this.qryFaLeistung.BeforePost += new System.EventHandler(this.qryFaLeistung_BeforePost);
            this.qryFaLeistung.AfterPost += new System.EventHandler(this.qryFaLeistung_AfterPost);
            this.qryFaLeistung.BeforeDeleteQuestion += new System.EventHandler(this.qryFaLeistung_BeforeDeleteQuestion);
            this.qryFaLeistung.AfterDelete += new System.EventHandler(this.qryFaLeistung_AfterDelete);
            //
            // edtEditUserID
            //
            this.edtEditUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtEditUserID.DataMember = "UserID";
            this.edtEditUserID.DataSource = this.qryFaLeistung;
            this.edtEditUserID.Location = new System.Drawing.Point(388, 32);
            this.edtEditUserID.Name = "edtEditUserID";
            this.edtEditUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEditUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEditUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEditUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtEditUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEditUserID.Properties.Appearance.Options.UseFont = true;
            this.edtEditUserID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEditUserID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEditUserID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEditUserID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEditUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtEditUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtEditUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEditUserID.Properties.NullText = "";
            this.edtEditUserID.Properties.ShowFooter = false;
            this.edtEditUserID.Properties.ShowHeader = false;
            this.edtEditUserID.Size = new System.Drawing.Size(379, 24);
            this.edtEditUserID.TabIndex = 8;
            //
            // lblInfoProzessDaten
            //
            this.lblInfoProzessDaten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoProzessDaten.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblInfoProzessDaten.Location = new System.Drawing.Point(9, 9);
            this.lblInfoProzessDaten.Name = "lblInfoProzessDaten";
            this.lblInfoProzessDaten.Size = new System.Drawing.Size(759, 16);
            this.lblInfoProzessDaten.TabIndex = 0;
            this.lblInfoProzessDaten.Text = "Prozessdaten bearbeiten";
            this.lblInfoProzessDaten.UseCompatibleTextRendering = true;
            //
            // lblEditDatumBis
            //
            this.lblEditDatumBis.Location = new System.Drawing.Point(9, 92);
            this.lblEditDatumBis.Name = "lblEditDatumBis";
            this.lblEditDatumBis.Size = new System.Drawing.Size(123, 24);
            this.lblEditDatumBis.TabIndex = 5;
            this.lblEditDatumBis.Text = "Abschlussdatum";
            this.lblEditDatumBis.UseCompatibleTextRendering = true;
            //
            // lblEditUserID
            //
            this.lblEditUserID.Location = new System.Drawing.Point(259, 32);
            this.lblEditUserID.Name = "lblEditUserID";
            this.lblEditUserID.Size = new System.Drawing.Size(123, 24);
            this.lblEditUserID.TabIndex = 7;
            this.lblEditUserID.Text = "Verantwortlicher MA";
            this.lblEditUserID.UseCompatibleTextRendering = true;
            //
            // lblEditFaLeistungID
            //
            this.lblEditFaLeistungID.Location = new System.Drawing.Point(9, 32);
            this.lblEditFaLeistungID.Name = "lblEditFaLeistungID";
            this.lblEditFaLeistungID.Size = new System.Drawing.Size(123, 24);
            this.lblEditFaLeistungID.TabIndex = 1;
            this.lblEditFaLeistungID.Text = "Prozess-Nr.";
            this.lblEditFaLeistungID.UseCompatibleTextRendering = true;
            //
            // lblEditDatumVon
            //
            this.lblEditDatumVon.Location = new System.Drawing.Point(9, 62);
            this.lblEditDatumVon.Name = "lblEditDatumVon";
            this.lblEditDatumVon.Size = new System.Drawing.Size(123, 24);
            this.lblEditDatumVon.TabIndex = 3;
            this.lblEditDatumVon.Text = "Eröffnungsdatum";
            this.lblEditDatumVon.UseCompatibleTextRendering = true;
            //
            // edtEditDatumBis
            //
            this.edtEditDatumBis.DataMember = "DatumBis";
            this.edtEditDatumBis.DataSource = this.qryFaLeistung;
            this.edtEditDatumBis.EditValue = null;
            this.edtEditDatumBis.Location = new System.Drawing.Point(138, 92);
            this.edtEditDatumBis.Name = "edtEditDatumBis";
            this.edtEditDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEditDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEditDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEditDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEditDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtEditDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEditDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtEditDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtEditDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEditDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtEditDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEditDatumBis.Properties.ShowToday = false;
            this.edtEditDatumBis.Size = new System.Drawing.Size(95, 24);
            this.edtEditDatumBis.TabIndex = 6;
            //
            // edtEditDatumVon
            //
            this.edtEditDatumVon.DataMember = "DatumVon";
            this.edtEditDatumVon.DataSource = this.qryFaLeistung;
            this.edtEditDatumVon.EditValue = null;
            this.edtEditDatumVon.Location = new System.Drawing.Point(138, 62);
            this.edtEditDatumVon.Name = "edtEditDatumVon";
            this.edtEditDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEditDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEditDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEditDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEditDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtEditDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEditDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtEditDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtEditDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEditDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtEditDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEditDatumVon.Properties.ShowToday = false;
            this.edtEditDatumVon.Size = new System.Drawing.Size(95, 24);
            this.edtEditDatumVon.TabIndex = 4;
            //
            // panBottomClient
            //
            this.panBottomClient.Controls.Add(this.lblInfoKlient);
            this.panBottomClient.Controls.Add(this.picKlientWichtigerHinweis);
            this.panBottomClient.Controls.Add(this.lblKlientNameVorname);
            this.panBottomClient.Controls.Add(this.edtKlientWichtigerHinweis);
            this.panBottomClient.Controls.Add(this.edtKlientNameVorname);
            this.panBottomClient.Controls.Add(this.lblKlientWichtigerHinweis);
            this.panBottomClient.Controls.Add(this.lblKlientWohnsitz);
            this.panBottomClient.Controls.Add(this.edtKlientIVBerechtigung);
            this.panBottomClient.Controls.Add(this.edtKlientWohnsitz);
            this.panBottomClient.Controls.Add(this.lblKlientIVBerechtigung);
            this.panBottomClient.Controls.Add(this.lblKlientTelefonP);
            this.panBottomClient.Controls.Add(this.edtKlientNeueVersNr);
            this.panBottomClient.Controls.Add(this.edtKlientTelefonP);
            this.panBottomClient.Controls.Add(this.lblKlientNeueVersNr);
            this.panBottomClient.Controls.Add(this.lblKlientTelefonG);
            this.panBottomClient.Controls.Add(this.edtKlientTelefonG);
            this.panBottomClient.Controls.Add(this.lblKlientTelefonMobil);
            this.panBottomClient.Controls.Add(this.edtKlientGeburtsdatum);
            this.panBottomClient.Controls.Add(this.edtKlientTelefonMobil);
            this.panBottomClient.Controls.Add(this.lblKlientGeburtsdatum);
            this.panBottomClient.Controls.Add(this.lblKlientEmail);
            this.panBottomClient.Controls.Add(this.edtKlientEmail);
            this.panBottomClient.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottomClient.Location = new System.Drawing.Point(0, 358);
            this.panBottomClient.Name = "panBottomClient";
            this.panBottomClient.Size = new System.Drawing.Size(780, 242);
            this.panBottomClient.TabIndex = 3;
            //
            // CtlFallInfo
            //
            this.ActiveSQLQuery = this.qryFallInfo;
            this.Controls.Add(this.grdFallInfo);
            this.Controls.Add(this.panBottomEditData);
            this.Controls.Add(this.panBottomUser);
            this.Controls.Add(this.panBottomClient);
            this.Name = "CtlFallInfo";
            this.Size = new System.Drawing.Size(780, 600);
            this.panBottomUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtMAEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFallInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMAEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMATelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMATelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMAAbteilung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMAAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMANameVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMANameVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfoMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKlientWichtigerHinweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientWichtigerHinweis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientWichtigerHinweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientIVBerechtigung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientIVBerechtigung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientNeueVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientNeueVersNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientGeburtsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientTelefonMobil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientTelefonMobil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientTelefonG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientTelefonG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientTelefonP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientTelefonP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientWohnsitz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientWohnsitz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlientNameVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientNameVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfoKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFallInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFallInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemIcon)).EndInit();
            this.panBottomEditData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtEditFaLeistungID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEditUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEditUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfoProzessDaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEditDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEditUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEditFaLeistungID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEditDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEditDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEditDatumVon.Properties)).EndInit();
            this.panBottomClient.ResumeLayout(false);
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

        #region Properties

        /// <summary>
        /// Get and set the BaPersonID of the client
        /// </summary>
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BaPersonID
        {
            get
            {
                // return current value
                return _baPersonID;
            }
            set
            {
                // check if designer
                if (DesignerMode)
                {
                    // do nothing
                    return;
                }

                // apply value to member
                _baPersonID = value;

                // reload data
                OnRefreshData();

                // validate
                if (BaPersonID > 0 && qryBaPerson.Count < 1)
                {
                    // invalid BaPersonID, no data found
                    KissMsg.ShowInfo(Name, "NoDataForBaPersonIDFound", "Es wurden keine Daten für die gesuchte Personen-Nr. '{0}' gefunden.", BaPersonID);
                }
            }
        }

        /// <summary>
        /// Get and set current access mode
        /// </summary>
        public AccessMode CurrentAccessMode
        {
            get
            {
                // return current value
                return _currentAccessMode;
            }
            set
            {
                // apply new value
                _currentAccessMode = value;

                // prepare control for showing to user
                SetupControl();
            }
        }

        /// <summary>
        /// Get the lastname and firstname of current shown client
        /// </summary>
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NameVorname
        {
            get
            {
                // check if we have valid data to return
                if (DesignerMode || !ValidateBaPerson() || DBUtil.IsEmpty(qryBaPerson["NameVorname"]))
                {
                    // invalid, return empty string
                    return string.Empty;
                }

                // return lastname and firstname of current client
                return Convert.ToString(qryBaPerson["NameVorname"]);
            }
        }

        #endregion

        #region EventHandlers

        private void btnDeleteFaLeistungID_Click(object sender, EventArgs e)
        {
            // check if we have a valid BaPersonID
            if (!ValidateBaPerson())
            {
                // show message
                KissMsg.ShowInfo(Name, "InvalidBaPersonIDOnDeleteBtn", "Es ist keine gültige Person ausgewählt, die Daten können nicht gelöscht werden.");
                return;
            }

            // confirm update
            if (!KissMsg.ShowQuestion(Name, "ConfirmDeleteFaLeistung_v01", "Wollen Sie den gewählten Prozess und alle zugehörigen Daten wirklich aus der Datenbank löschen?\r\n\r\nAchtung:\r\nEs werden sämtliche mit diesem Prozess verknüpften Daten ebenfalls gelöscht und können nicht wieder hergestellt werden! Auch besteht die Gefahr von inkonsistenten Daten, welche Fehler in KiSS auslösen können!", false))
            {
                // undo changes
                UndoChangesOnFaLeistung();

                // done
                return;
            }

            // set flag to be able to delete
            _confirmedDeleteFaLeistung = true;

            // allow delete on query
            qryFaLeistung.CanDelete = true;

            // delete the current entry
            qryFaLeistung.Delete();
        }

        private void btnUpdateFaLeistungID_Click(object sender, EventArgs e)
        {
            // check if we have a valid BaPersonID
            if (!ValidateBaPerson())
            {
                // show message
                KissMsg.ShowInfo(Name, "InvalidBaPersonIDOnUpdateBtn", "Es ist keine gültige Person ausgewählt, die Daten können nicht verändert werden.");
                return;
            }

            // validate if changed
            if (!qryFaLeistung.RowModified)
            {
                // nothing changed
                KissMsg.ShowInfo(Name, "DataWasNotChanged", "Es wurden keine Veränderungen vorgenommen.");
                return;
            }

            // confirm update
            if (!KissMsg.ShowQuestion(Name, "ConfirmUpdateFaLeistung_v02", "Wollen Sie den gewählten Prozess wirklich verändern?\r\n\r\nAchtung:\r\nDie geänderten Daten werden nicht weiter validiert, d.h. es können inkonsistente Daten und damit Fehler in KiSS entstehen!", false))
            {
                // undo changes
                UndoChangesOnFaLeistung();

                // done
                return;
            }

            // set flag to be able to update
            _confirmedUpdateFaLeistung = true;

            // update the current entry
            qryFaLeistung.Post();
        }

        private void qryFaLeistung_AfterDelete(object sender, EventArgs e)
        {
            // do not allow delete anymore
            qryFaLeistung.CanDelete = false;

            // refresh data after deleting entry
            AfterUpdateDelete();
        }

        private void qryFaLeistung_AfterPost(object sender, EventArgs e)
        {
            // refresh data after updating entry
            AfterUpdateDelete();
        }

        private void qryFaLeistung_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            // check if user confirmed deleting entry
            if (!_confirmedDeleteFaLeistung)
            {
                // show error
                KissMsg.ShowError(Name, "NotConfirmedDeletingFaLeistung", "Es ist ein Fehler in der Verarbeitung aufgetreten. Die gewählte Leistung kann erst gelöscht werden, wenn dies vom Benutzer bestätigt wurde.");

                // undo changes
                UndoChangesOnFaLeistung();

                // cancel delete
                throw new KissCancelException();
            }

            // reset flag to ensure proper handling for next delete
            _confirmedDeleteFaLeistung = false;

            // log it
            LogDelete();
        }

        private void qryFaLeistung_BeforePost(object sender, EventArgs e)
        {
            // check if user confirmed deleting entry
            if (!_confirmedUpdateFaLeistung)
            {
                // show error
                KissMsg.ShowError(Name, "NotConfirmedUpdatingFaLeistung", "Es ist ein Fehler in der Verarbeitung aufgetreten. Die gewählte Leistung kann erst geändert werden, wenn dies vom Benutzer bestätigt wurde.");

                // undo changes
                UndoChangesOnFaLeistung();

                // cancel delete
                throw new KissCancelException();
            }

            // reset flag to ensure proper handling for next update
            _confirmedUpdateFaLeistung = false;

            // #7827: DateTime without time
            qryFaLeistung[DBO.FaLeistung.DatumVon] = FaUtils.DateTimeWithoutTime(qryFaLeistung, DBO.FaLeistung.DatumVon);
            qryFaLeistung[DBO.FaLeistung.DatumBis] = FaUtils.DateTimeWithoutTime(qryFaLeistung, DBO.FaLeistung.DatumBis);

            // log it
            LogUpdate();
        }

        private void qryFallInfo_PositionChanged(object sender, EventArgs e)
        {
            // check if user is allowed to edit data
            if (AllowEdit())
            {
                // check if we have any data loaded that was edited
                if (qryFaLeistung.Count > 0 && qryFaLeistung.RowModified)
                {
                    // cancel any earlier edits to prevent saving without button
                    UndoChangesOnFaLeistung();
                }

                // refresh data on qryFaLeistung
                qryFaLeistung.Fill(@"
                    SELECT LEI.FaLeistungID,
                           LEI.BaPersonID,
                           LEI.UserID,
                           LEI.ModulID,
                           LEI.DatumVon,
                           LEI.DatumBis,
                           LEI.Modifier,
                           LEI.Modified,
                           LEI.FaLeistungTS
                    FROM dbo.FaLeistung LEI -- no WITH (READUNCOMMITTED)
                    WHERE LEI.FaLeistungID = {0}", qryFallInfo["FaLeistungID"]);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Save pending changes and reload Data
        /// </summary>
        public override void OnRefreshData()
        {
            // get current key
            var currentKey = qryFallInfo["Key"];

            // refill query
            FillFaLeistungQuery();
            FillBaPersonQuery();

            // expand groups for propper display
            grvFallInfo.ExpandAllGroups();

            // try to find last used rowhandle within new row
            var rowHandle = grvFallInfo.LocateByValue(-1000, colKey, currentKey);

            // try to refocus if rowhandle is valid
            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                grvFallInfo.FocusedRowHandle = rowHandle;
            }
        }

        #endregion

        #region Private Methods

        private void AfterUpdateDelete()
        {
            // updade FV-responsibility
            FaUtils.UpdateFVResponsibility(BaPersonID);

            // refresh data after updating entry
            OnRefreshData();
        }

        /// <summary>
        /// Flag if user is allowed to edit data depending on current access mode
        /// </summary>
        /// <returns>True if user can edit data, otherwise false</returns>
        private bool AllowEdit()
        {
            // return value depending on current access mode
            return _currentAccessMode == AccessMode.AllowEdit;
        }

        private void FillBaPersonQuery()
        {
            // fill the given query with data
            qryBaPerson.Fill(@"
                -- init vars
                DECLARE @BaPersonID INT
                DECLARE @LanguageCode INT

                -- set vars
                SET @BaPersonID = {0}
                SET @LanguageCode = {1}

                -- collect data
                SELECT PRS.BaPersonID,
                       NameVorname     = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
                       WohnsitzAdresse = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 0, 'wohnsitz', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
                       PRS.Telefon_P,
                       PRS.Telefon_G,
                       PRS.MobilTel,
                       PRS.EMail,
                       PRS.Geburtsdatum,
                       PRS.VersichertenNummer,
                       IVBerechtigung  = dbo.fnLOVMLText('BaIVBerechtigung', dbo.fnBaGetIVBerechtigungStatus(PRS.BaPersonID, NULL, 0), @LanguageCode),
                       PRS.WichtigerHinweis
                FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
                WHERE PRS.BaPersonID = @BaPersonID;", BaPersonID, Session.User.LanguageCode);

            // setup wichtiger hinweis
            SetupWichtigerHinweis();
        }

        private void FillFaLeistungQuery()
        {
            // fill the given query with data
            qryFallInfo.Fill(@"
                EXEC dbo.spFaGetFallInfoData {0}, {1};", BaPersonID, Session.User.LanguageCode);

            // do grouping
            colFallverlauf.GroupIndex = 0;

            // expand all groups
            grvFallInfo.ExpandAllGroups();

            // validate data to prevent error
            if (qryFallInfo.Count > 0)
            {
                // select first FV-entry
                qryFallInfo.Find("ModulID = 2");
            }

            // run position changed to apply other data
            qryFallInfo_PositionChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Get current values of FaLeistung, used for logging data
        /// </summary>
        /// <returns>String containing all neccessary information of current FaLeistung entry</returns>
        private string GetCurrentValuesForLogging()
        {
            // combine values
            return string.Format("FaLeistungID='{0}', BaPersonID='{1}', UserID='{2}', ModulID='{3}', DatumVon='{4}', DatumBis='{5}'",
                                 qryFaLeistung["FaLeistungID"],
                                 qryFaLeistung["BaPersonID"],
                                 qryFaLeistung["UserID"],
                                 qryFaLeistung["ModulID"],
                                 qryFaLeistung["DatumVon"],
                                 qryFaLeistung["DatumBis"]);
        }

        /// <summary>
        /// Log delete of entry in FaLeistung
        /// </summary>
        private void LogDelete()
        {
            // create comment
            var comment = string.Format("Values: {0}", GetCurrentValuesForLogging());

            // create new log entry
            XLog.Create(GetType().FullName, 2, LogLevel.INFO, "User deletes entry in FaLeistung", comment, "BaPerson", Convert.ToInt32(qryFaLeistung["BaPersonID"]));
        }

        /// <summary>
        /// Log update of entry in FaLeistung
        /// </summary>
        private void LogUpdate()
        {
            // create comment
            var comment = string.Format("Values: {0}", GetCurrentValuesForLogging());

            // create new log entry
            XLog.Create(GetType().FullName, 1, LogLevel.INFO, "User updates entry in FaLeistung", comment, "FaLeistung", Convert.ToInt32(qryFaLeistung["FaLeistungID"]));
        }

        /// <summary>
        /// Setup control depending on current values
        /// </summary>
        private void SetupControl()
        {
            // set edit flag
            var allowEdit = AllowEdit();
            var isUserAdmin = Session.User != null && Session.User.IsUserAdmin;

            // reset empty text
            repItemIcon.NullText = " "; // do not display "No Image"

            // set picture
            picKlientWichtigerHinweis.Image = KissImageList.GetSmallImage(84);

            // show/hide column
            colFaLeistungID.Visible = isUserAdmin || allowEdit;

            // setup depending on edit rights
            panBottomEditData.Visible = allowEdit;
            qryFaLeistung.CanUpdate = allowEdit;
            btnUpdateFaLeistungID.Visible = allowEdit;
            btnDeleteFaLeistungID.Visible = allowEdit;

            // hide client data if editing
            panBottomClient.Visible = !allowEdit;

            // refresh fields
            qryFaLeistung.EnableBoundFields(qryFaLeistung.CanUpdate);

            // check if need to load dropdown for user-list
            if (!DesignMode && allowEdit &&
                (edtEditUserID.DataSource == null || edtEditUserID.DataSource.Count < 1))
            {
                // init query and load data
                var qryUsers = DBUtil.OpenSQL(@"
                    SELECT [Code] = USR.UserID,
                           [Text] = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName) + ISNULL(' (' + USR.LogonName + ')', '')
                    FROM dbo.XUser USR WITH (READUNCOMMITTED);");

                // setup lookupedit
                edtEditUserID.LoadQuery(qryUsers);
                edtEditUserID.Properties.DropDownRows = Math.Min(qryUsers.Count, 14);
            }
        }

        private void SetupWichtigerHinweis()
        {
            // check if we have a value
            if (DBUtil.IsEmpty(qryBaPerson["WichtigerHinweis"]))
            {
                // no value given
                edtKlientWichtigerHinweis.Width = edtKlientWohnsitz.Width;
                picKlientWichtigerHinweis.Visible = false;
            }
            else
            {
                // value is given
                edtKlientWichtigerHinweis.Width = edtKlientWohnsitz.Width - 23;
                picKlientWichtigerHinweis.Visible = true;
            }
        }

        /// <summary>
        /// Undo any changes on FaLeistung
        /// </summary>
        private void UndoChangesOnFaLeistung()
        {
            // validate
            if (qryFaLeistung.Count < 1 || !qryFaLeistung.RowModified)
            {
                // nothing to do
                return;
            }

            // undo changes without any notify
            qryFaLeistung.RowModified = false;
            qryFaLeistung.Row.AcceptChanges();

            // refresh to ensure proper data on controls
            qryFaLeistung.Refresh();
        }

        /// <summary>
        /// Validate current BaPersonID with depending data
        /// </summary>
        /// <returns></returns>
        private bool ValidateBaPerson()
        {
            // valid if we have a valid BaPersonID with at least one row in query
            return BaPersonID > 0 && qryBaPerson.Count > 0;
        }

        #endregion

        #endregion
    }
}