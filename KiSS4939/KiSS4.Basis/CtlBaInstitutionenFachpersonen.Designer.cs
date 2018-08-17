using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis
{
    partial class CtlBaInstitutionenFachpersonen
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaInstitutionenFachpersonen));
            this.panTitel = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdInstitutionenFachpersonen = new KiSS4.Gui.KissGrid();
            this.qryBaPersonInstitution = new KiSS4.DB.SqlQuery(this.components);
            this.grvInstitutionenFachpersonen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdresse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeziehung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrifft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFall = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblInstitutionFachperson = new KiSS4.Gui.KissLabel();
            this.edtInstitutionName = new KiSS4.Gui.KissButtonEdit();
            this.lblKontaktperson = new KiSS4.Gui.KissLabel();
            this.lblTelefon = new KiSS4.Gui.KissLabel();
            this.edtAnsprechPersonTel = new KiSS4.Gui.KissTextEdit();
            this.lblEmail = new KiSS4.Gui.KissLabel();
            this.edtAnsprechPersonMail = new KiSS4.Gui.KissTextEdit();
            this.lblBetrifftPerson = new KiSS4.Gui.KissLabel();
            this.edtBetrifftPerson = new KiSS4.Gui.KissLookUpEdit();
            this.lblBeziehungZuPerson = new KiSS4.Gui.KissLabel();
            this.edtBeziehungZuPerson = new KiSS4.Gui.KissLookUpEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.lblSubTitel = new KiSS4.Gui.KissLabel();
            this.tabInstitution = new KiSS4.Gui.KissTabControlEx();
            this.tpgAdresse = new SharpLibrary.WinControls.TabPageEx();
            this.panTblAdresse = new System.Windows.Forms.TableLayoutPanel();
            this.panAdresseLeft = new System.Windows.Forms.Panel();
            this.edtAdressePLZOrtKtBezirkLand = new KiSS4.Common.KissPLZOrt();
            this.lblAdresseTitel = new KiSS4.Gui.KissLabel();
            this.chkAktiv = new KiSS4.Gui.KissCheckEdit();
            this.qryInstitution = new KiSS4.DB.SqlQuery(this.components);
            this.edtAdresseTitel = new KiSS4.Gui.KissTextEdit();
            this.lblAdresseName = new KiSS4.Gui.KissLabel();
            this.edtAdresseName = new KiSS4.Gui.KissMemoEdit();
            this.lblAdresseZusatz = new KiSS4.Gui.KissLabel();
            this.edtAdresseZusatz = new KiSS4.Gui.KissTextEdit();
            this.lblAdresseStrasseNr = new KiSS4.Gui.KissLabel();
            this.edtAdresseStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtAdresseHausNr = new KiSS4.Gui.KissTextEdit();
            this.lblAdressePostfach = new KiSS4.Gui.KissLabel();
            this.edtAdressePostfach = new KiSS4.Gui.KissTextEdit();
            this.lblAdressePLZOrtKt = new KiSS4.Gui.KissLabel();
            this.lblAdresseBezirk = new KiSS4.Gui.KissLabel();
            this.lblAdresseLand = new KiSS4.Gui.KissLabel();
            this.panAdresseRight = new System.Windows.Forms.Panel();
            this.edtAdresseBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblAdresseTelefon = new KiSS4.Gui.KissLabel();
            this.lblAdresseBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtAdresseTelefon = new KiSS4.Gui.KissTextEdit();
            this.edtAdresseAbteilung = new KiSS4.Gui.KissTextEdit();
            this.lblAdresseFax = new KiSS4.Gui.KissLabel();
            this.lblAdresseAbteilung = new KiSS4.Gui.KissLabel();
            this.edtAdresseFax = new KiSS4.Gui.KissTextEdit();
            this.edtAdresseSprache = new KiSS4.Gui.KissTextEdit();
            this.lblAdresseEmail = new KiSS4.Gui.KissLabel();
            this.lblAdresseSprache = new KiSS4.Gui.KissLabel();
            this.edtAdresseEmail = new KiSS4.Gui.KissTextEdit();
            this.edtAdresseInternet = new KiSS4.Gui.KissTextEdit();
            this.lblAdresseInternet = new KiSS4.Gui.KissLabel();
            this.tpgKontakt = new SharpLibrary.WinControls.TabPageEx();
            this.panTblKontakt = new System.Windows.Forms.TableLayoutPanel();
            this.panKontaktLeft = new System.Windows.Forms.Panel();
            this.lblKontaktPersonName = new KiSS4.Gui.KissLabel();
            this.edtKontaktName = new KiSS4.Gui.KissTextEdit();
            this.lblKontaktSprache = new KiSS4.Gui.KissLabel();
            this.edtKontaktVorname = new KiSS4.Gui.KissTextEdit();
            this.edtKontaktSprachCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblKontaktPersonVorname = new KiSS4.Gui.KissLabel();
            this.lblKontaktTelefon = new KiSS4.Gui.KissLabel();
            this.lblKontaktGeschlecht = new KiSS4.Gui.KissLabel();
            this.lblKontaktFax = new KiSS4.Gui.KissLabel();
            this.edtKontaktGeschlecht = new KiSS4.Gui.KissLookUpEdit();
            this.lblKontaktEMail = new KiSS4.Gui.KissLabel();
            this.edtKontaktTelefon = new KiSS4.Gui.KissTextEdit();
            this.edtKontaktEMail = new KiSS4.Gui.KissTextEdit();
            this.edtKontaktFax = new KiSS4.Gui.KissTextEdit();
            this.panKontaktRight = new System.Windows.Forms.Panel();
            this.lblKontaktBemerkung = new KiSS4.Gui.KissLabel();
            this.lblKontaktTitel = new KiSS4.Gui.KissLabel();
            this.edtKontaktBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.edtKontaktAnrede = new KiSS4.Gui.KissTextEdit();
            this.chkKontaktAktiv = new KiSS4.Gui.KissCheckEdit();
            this.qryBaInstitutionKontakt = new KiSS4.DB.SqlQuery(this.components);
            this.chkKontaktManuelleAnrede = new KiSS4.Gui.KissCheckEdit();
            this.lblKontaktBriefanrede = new KiSS4.Gui.KissLabel();
            this.edtKontaktBriefanrede = new KiSS4.Gui.KissTextEdit();
            this.lblKontaktAnrede = new KiSS4.Gui.KissLabel();
            this.edtKontaktTitel = new KiSS4.Gui.KissTextEdit();
            this.tpgAdressTyp = new SharpLibrary.WinControls.TabPageEx();
            this.grdInstTypen = new KiSS4.Gui.KissGrid();
            this.grvInstTypen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInstTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtKontaktperson = new KiSS4.Gui.KissLookUpEdit();
            this.qryInstTypen = new KiSS4.DB.SqlQuery(this.components);
            this.panDetails = new System.Windows.Forms.Panel();
            this.btnDatenblatt = new KiSS4.Dokument.KissDocumentButton();
            this.btnGotoInsitution = new KiSS4.Gui.KissButton();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstitutionenFachpersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPersonInstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInstitutionenFachpersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionFachperson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitutionName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktperson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnsprechPersonTel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnsprechPersonMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrifftPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrifftPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrifftPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeziehungZuPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeziehungZuPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeziehungZuPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubTitel)).BeginInit();
            this.tabInstitution.SuspendLayout();
            this.tpgAdresse.SuspendLayout();
            this.panTblAdresse.SuspendLayout();
            this.panAdresseLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInstitution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseTitel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressePostfach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressePostfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressePLZOrtKt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseBezirk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseLand)).BeginInit();
            this.panAdresseRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseAbteilung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseSprache.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseSprache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseInternet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseInternet)).BeginInit();
            this.tpgKontakt.SuspendLayout();
            this.panTblKontakt.SuspendLayout();
            this.panKontaktLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktPersonName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktSprache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktSprachCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktSprachCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktPersonVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktGeschlecht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktEMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktEMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktFax.Properties)).BeginInit();
            this.panKontaktRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktAnrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontaktAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaInstitutionKontakt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontaktManuelleAnrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktBriefanrede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktBriefanrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktAnrede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktTitel.Properties)).BeginInit();
            this.tpgAdressTyp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstTypen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInstTypen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInstTypen)).BeginInit();
            this.panDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTitel
            // 
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(749, 30);
            this.panTitel.TabIndex = 0;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(698, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Institutionen, Fachpersonen";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // grdInstitutionenFachpersonen
            // 
            this.grdInstitutionenFachpersonen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdInstitutionenFachpersonen.DataSource = this.qryBaPersonInstitution;
            // 
            // 
            // 
            this.grdInstitutionenFachpersonen.EmbeddedNavigator.Name = "grid1.EmbeddedNavigator";
            this.grdInstitutionenFachpersonen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdInstitutionenFachpersonen.Location = new System.Drawing.Point(0, 30);
            this.grdInstitutionenFachpersonen.MainView = this.grvInstitutionenFachpersonen;
            this.grdInstitutionenFachpersonen.Name = "grdInstitutionenFachpersonen";
            this.grdInstitutionenFachpersonen.Size = new System.Drawing.Size(749, 112);
            this.grdInstitutionenFachpersonen.TabIndex = 1;
            this.grdInstitutionenFachpersonen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvInstitutionenFachpersonen});
            // 
            // qryBaPersonInstitution
            // 
            this.qryBaPersonInstitution.DeleteQuestion = "Soll die Beziehung zu Institution, Fachperson gelöscht werden?";
            this.qryBaPersonInstitution.HostControl = this;
            this.qryBaPersonInstitution.TableName = "BaPerson_BaInstitution";
            this.qryBaPersonInstitution.AfterInsert += new System.EventHandler(this.qryBaPersonInstitution_AfterInsert);
            this.qryBaPersonInstitution.AfterPost += new System.EventHandler(this.qryBaPersonInstitution_AfterPost);
            this.qryBaPersonInstitution.BeforePost += new System.EventHandler(this.qryBaPersonInstitution_BeforePost);
            this.qryBaPersonInstitution.PositionChanged += new System.EventHandler(this.qryBaPersonInstitution_PositionChanged);
            this.qryBaPersonInstitution.PositionChanging += new System.EventHandler(this.qryBaPersonInstitution_PositionChanging);
            // 
            // grvInstitutionenFachpersonen
            // 
            this.grvInstitutionenFachpersonen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvInstitutionenFachpersonen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionenFachpersonen.Appearance.Empty.Options.UseBackColor = true;
            this.grvInstitutionenFachpersonen.Appearance.Empty.Options.UseFont = true;
            this.grvInstitutionenFachpersonen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionenFachpersonen.Appearance.EvenRow.Options.UseFont = true;
            this.grvInstitutionenFachpersonen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvInstitutionenFachpersonen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionenFachpersonen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvInstitutionenFachpersonen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvInstitutionenFachpersonen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvInstitutionenFachpersonen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvInstitutionenFachpersonen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvInstitutionenFachpersonen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionenFachpersonen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvInstitutionenFachpersonen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvInstitutionenFachpersonen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvInstitutionenFachpersonen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvInstitutionenFachpersonen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvInstitutionenFachpersonen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvInstitutionenFachpersonen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvInstitutionenFachpersonen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvInstitutionenFachpersonen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvInstitutionenFachpersonen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvInstitutionenFachpersonen.Appearance.GroupRow.Options.UseFont = true;
            this.grvInstitutionenFachpersonen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvInstitutionenFachpersonen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvInstitutionenFachpersonen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvInstitutionenFachpersonen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvInstitutionenFachpersonen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvInstitutionenFachpersonen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvInstitutionenFachpersonen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvInstitutionenFachpersonen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvInstitutionenFachpersonen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionenFachpersonen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvInstitutionenFachpersonen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvInstitutionenFachpersonen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvInstitutionenFachpersonen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvInstitutionenFachpersonen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvInstitutionenFachpersonen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvInstitutionenFachpersonen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionenFachpersonen.Appearance.OddRow.Options.UseFont = true;
            this.grvInstitutionenFachpersonen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvInstitutionenFachpersonen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionenFachpersonen.Appearance.Row.Options.UseBackColor = true;
            this.grvInstitutionenFachpersonen.Appearance.Row.Options.UseFont = true;
            this.grvInstitutionenFachpersonen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstitutionenFachpersonen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvInstitutionenFachpersonen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvInstitutionenFachpersonen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvInstitutionenFachpersonen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvInstitutionenFachpersonen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colAdresse,
            this.colBeziehung,
            this.colBetrifft,
            this.colFall});
            this.grvInstitutionenFachpersonen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvInstitutionenFachpersonen.GridControl = this.grdInstitutionenFachpersonen;
            this.grvInstitutionenFachpersonen.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvInstitutionenFachpersonen.Name = "grvInstitutionenFachpersonen";
            this.grvInstitutionenFachpersonen.OptionsBehavior.Editable = false;
            this.grvInstitutionenFachpersonen.OptionsCustomization.AllowFilter = false;
            this.grvInstitutionenFachpersonen.OptionsFilter.AllowFilterEditor = false;
            this.grvInstitutionenFachpersonen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvInstitutionenFachpersonen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvInstitutionenFachpersonen.OptionsNavigation.UseTabKey = false;
            this.grvInstitutionenFachpersonen.OptionsView.ColumnAutoWidth = false;
            this.grvInstitutionenFachpersonen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvInstitutionenFachpersonen.OptionsView.ShowGroupPanel = false;
            this.grvInstitutionenFachpersonen.OptionsView.ShowIndicator = false;
            // 
            // colName
            // 
            this.colName.Caption = "Institution, Fachperson";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 180;
            // 
            // colAdresse
            // 
            this.colAdresse.Caption = "Adresse";
            this.colAdresse.Name = "colAdresse";
            this.colAdresse.Visible = true;
            this.colAdresse.VisibleIndex = 1;
            this.colAdresse.Width = 180;
            // 
            // colBeziehung
            // 
            this.colBeziehung.Caption = "Beziehung zu Person";
            this.colBeziehung.Name = "colBeziehung";
            this.colBeziehung.Visible = true;
            this.colBeziehung.VisibleIndex = 2;
            this.colBeziehung.Width = 200;
            // 
            // colBetrifft
            // 
            this.colBetrifft.Caption = "Betrifft";
            this.colBetrifft.Name = "colBetrifft";
            this.colBetrifft.Visible = true;
            this.colBetrifft.VisibleIndex = 3;
            this.colBetrifft.Width = 140;
            // 
            // colFall
            // 
            this.colFall.Caption = "Fall";
            this.colFall.FieldName = "Fall";
            this.colFall.Name = "colFall";
            // 
            // lblInstitutionFachperson
            // 
            this.lblInstitutionFachperson.Location = new System.Drawing.Point(9, 9);
            this.lblInstitutionFachperson.Name = "lblInstitutionFachperson";
            this.lblInstitutionFachperson.Size = new System.Drawing.Size(94, 24);
            this.lblInstitutionFachperson.TabIndex = 0;
            this.lblInstitutionFachperson.Text = "Inst., Fachpers.";
            this.lblInstitutionFachperson.UseCompatibleTextRendering = true;
            // 
            // edtInstitutionName
            // 
            this.edtInstitutionName.DataSource = this.qryBaPersonInstitution;
            this.edtInstitutionName.Location = new System.Drawing.Point(109, 9);
            this.edtInstitutionName.Name = "edtInstitutionName";
            this.edtInstitutionName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInstitutionName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInstitutionName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInstitutionName.Properties.Appearance.Options.UseBackColor = true;
            this.edtInstitutionName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInstitutionName.Properties.Appearance.Options.UseFont = true;
            this.edtInstitutionName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtInstitutionName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtInstitutionName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInstitutionName.Properties.Name = "editOrganisationName.Properties";
            this.edtInstitutionName.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtInstitutionName.Size = new System.Drawing.Size(240, 24);
            this.edtInstitutionName.TabIndex = 1;
            this.edtInstitutionName.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtInstitutionName_UserModifiedFld);
            this.edtInstitutionName.EditValueChanged += new System.EventHandler(this.edtInstitutionName_EditValueChanged);
            // 
            // lblKontaktperson
            // 
            this.lblKontaktperson.Location = new System.Drawing.Point(10, 39);
            this.lblKontaktperson.Name = "lblKontaktperson";
            this.lblKontaktperson.Size = new System.Drawing.Size(94, 24);
            this.lblKontaktperson.TabIndex = 2;
            this.lblKontaktperson.Text = "Kontaktperson";
            this.lblKontaktperson.UseCompatibleTextRendering = true;
            // 
            // lblTelefon
            // 
            this.lblTelefon.Location = new System.Drawing.Point(9, 62);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(94, 24);
            this.lblTelefon.TabIndex = 4;
            this.lblTelefon.Text = "Telefon";
            this.lblTelefon.UseCompatibleTextRendering = true;
            // 
            // edtAnsprechPersonTel
            // 
            this.edtAnsprechPersonTel.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAnsprechPersonTel.Location = new System.Drawing.Point(109, 62);
            this.edtAnsprechPersonTel.Name = "edtAnsprechPersonTel";
            this.edtAnsprechPersonTel.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAnsprechPersonTel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnsprechPersonTel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnsprechPersonTel.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnsprechPersonTel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnsprechPersonTel.Properties.Appearance.Options.UseFont = true;
            this.edtAnsprechPersonTel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnsprechPersonTel.Properties.MaxLength = 50;
            this.edtAnsprechPersonTel.Properties.ReadOnly = true;
            this.edtAnsprechPersonTel.Size = new System.Drawing.Size(240, 24);
            this.edtAnsprechPersonTel.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(9, 85);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(94, 24);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "E-Mail";
            this.lblEmail.UseCompatibleTextRendering = true;
            // 
            // edtAnsprechPersonMail
            // 
            this.edtAnsprechPersonMail.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAnsprechPersonMail.Location = new System.Drawing.Point(109, 85);
            this.edtAnsprechPersonMail.Name = "edtAnsprechPersonMail";
            this.edtAnsprechPersonMail.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAnsprechPersonMail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnsprechPersonMail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnsprechPersonMail.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnsprechPersonMail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnsprechPersonMail.Properties.Appearance.Options.UseFont = true;
            this.edtAnsprechPersonMail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnsprechPersonMail.Properties.MaxLength = 100;
            this.edtAnsprechPersonMail.Properties.ReadOnly = true;
            this.edtAnsprechPersonMail.Size = new System.Drawing.Size(240, 24);
            this.edtAnsprechPersonMail.TabIndex = 7;
            // 
            // lblBetrifftPerson
            // 
            this.lblBetrifftPerson.Location = new System.Drawing.Point(364, 9);
            this.lblBetrifftPerson.Name = "lblBetrifftPerson";
            this.lblBetrifftPerson.Size = new System.Drawing.Size(115, 24);
            this.lblBetrifftPerson.TabIndex = 8;
            this.lblBetrifftPerson.Text = "Betrifft Person";
            this.lblBetrifftPerson.UseCompatibleTextRendering = true;
            // 
            // edtBetrifftPerson
            // 
            this.edtBetrifftPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBetrifftPerson.DataMember = "BaPersonID";
            this.edtBetrifftPerson.DataSource = this.qryBaPersonInstitution;
            this.edtBetrifftPerson.Location = new System.Drawing.Point(485, 9);
            this.edtBetrifftPerson.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtBetrifftPerson.MaximumSize = new System.Drawing.Size(300, 24);
            this.edtBetrifftPerson.Name = "edtBetrifftPerson";
            this.edtBetrifftPerson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetrifftPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrifftPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrifftPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrifftPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrifftPerson.Properties.Appearance.Options.UseFont = true;
            this.edtBetrifftPerson.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBetrifftPerson.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrifftPerson.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBetrifftPerson.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBetrifftPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtBetrifftPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtBetrifftPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrifftPerson.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBetrifftPerson.Properties.DisplayMember = "Text";
            this.edtBetrifftPerson.Properties.Name = "editPerson.Properties";
            this.edtBetrifftPerson.Properties.NullText = "";
            this.edtBetrifftPerson.Properties.ShowFooter = false;
            this.edtBetrifftPerson.Properties.ShowHeader = false;
            this.edtBetrifftPerson.Properties.ValueMember = "Code";
            this.edtBetrifftPerson.Size = new System.Drawing.Size(255, 24);
            this.edtBetrifftPerson.TabIndex = 9;
            this.edtBetrifftPerson.EditValueChanged += new System.EventHandler(this.edtBetrifftPerson_EditValueChanged);
            // 
            // lblBeziehungZuPerson
            // 
            this.lblBeziehungZuPerson.Location = new System.Drawing.Point(364, 32);
            this.lblBeziehungZuPerson.Name = "lblBeziehungZuPerson";
            this.lblBeziehungZuPerson.Size = new System.Drawing.Size(115, 24);
            this.lblBeziehungZuPerson.TabIndex = 10;
            this.lblBeziehungZuPerson.Text = "Beziehung zu Pers.";
            this.lblBeziehungZuPerson.UseCompatibleTextRendering = true;
            // 
            // edtBeziehungZuPerson
            // 
            this.edtBeziehungZuPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBeziehungZuPerson.DataMember = "BaInstitutionTypID";
            this.edtBeziehungZuPerson.DataSource = this.qryBaPersonInstitution;
            this.edtBeziehungZuPerson.Location = new System.Drawing.Point(485, 32);
            this.edtBeziehungZuPerson.MaximumSize = new System.Drawing.Size(300, 24);
            this.edtBeziehungZuPerson.Name = "edtBeziehungZuPerson";
            this.edtBeziehungZuPerson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBeziehungZuPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeziehungZuPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeziehungZuPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeziehungZuPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeziehungZuPerson.Properties.Appearance.Options.UseFont = true;
            this.edtBeziehungZuPerson.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBeziehungZuPerson.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeziehungZuPerson.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBeziehungZuPerson.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBeziehungZuPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBeziehungZuPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBeziehungZuPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBeziehungZuPerson.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBeziehungZuPerson.Properties.DisplayMember = "Text";
            this.edtBeziehungZuPerson.Properties.Name = "editPerson.Properties";
            this.edtBeziehungZuPerson.Properties.NullText = "";
            this.edtBeziehungZuPerson.Properties.ShowFooter = false;
            this.edtBeziehungZuPerson.Properties.ShowHeader = false;
            this.edtBeziehungZuPerson.Properties.ValueMember = "Code";
            this.edtBeziehungZuPerson.Size = new System.Drawing.Size(255, 24);
            this.edtBeziehungZuPerson.TabIndex = 11;
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Location = new System.Drawing.Point(364, 62);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(115, 24);
            this.lblBemerkungen.TabIndex = 12;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            // 
            // edtBemerkungen
            // 
            this.edtBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkungen.DataMember = "Bemerkung";
            this.edtBemerkungen.DataSource = this.qryBaPersonInstitution;
            this.edtBemerkungen.Location = new System.Drawing.Point(485, 62);
            this.edtBemerkungen.Name = "edtBemerkungen";
            this.edtBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkungen.Properties.MaxLength = 300;
            this.edtBemerkungen.Size = new System.Drawing.Size(255, 47);
            this.edtBemerkungen.TabIndex = 13;
            // 
            // lblSubTitel
            // 
            this.lblSubTitel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSubTitel.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblSubTitel.Location = new System.Drawing.Point(0, 128);
            this.lblSubTitel.Name = "lblSubTitel";
            this.lblSubTitel.Size = new System.Drawing.Size(749, 20);
            this.lblSubTitel.TabIndex = 14;
            this.lblSubTitel.Text = "Stammdaten Institution, Fachperson";
            this.lblSubTitel.UseCompatibleTextRendering = true;
            // 
            // tabInstitution
            // 
            this.tabInstitution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabInstitution.Controls.Add(this.tpgAdresse);
            this.tabInstitution.Controls.Add(this.tpgKontakt);
            this.tabInstitution.Controls.Add(this.tpgAdressTyp);
            this.tabInstitution.Location = new System.Drawing.Point(0, 293);
            this.tabInstitution.Name = "tabInstitution";
            this.tabInstitution.ShowFixedWidthTooltip = true;
            this.tabInstitution.Size = new System.Drawing.Size(749, 272);
            this.tabInstitution.TabIndex = 3;
            this.tabInstitution.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgAdresse,
            this.tpgKontakt,
            this.tpgAdressTyp});
            this.tabInstitution.TabsLineColor = System.Drawing.Color.Black;
            this.tabInstitution.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabInstitution.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabInstitution_SelectedTabChanged);
            // 
            // tpgAdresse
            // 
            this.tpgAdresse.Controls.Add(this.panTblAdresse);
            this.tpgAdresse.Location = new System.Drawing.Point(6, 6);
            this.tpgAdresse.Name = "tpgAdresse";
            this.tpgAdresse.Size = new System.Drawing.Size(737, 234);
            this.tpgAdresse.TabIndex = 0;
            this.tpgAdresse.Title = "&Adresse";
            // 
            // panTblAdresse
            // 
            this.panTblAdresse.ColumnCount = 2;
            this.panTblAdresse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panTblAdresse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panTblAdresse.Controls.Add(this.panAdresseLeft, 0, 0);
            this.panTblAdresse.Controls.Add(this.panAdresseRight, 1, 0);
            this.panTblAdresse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTblAdresse.Location = new System.Drawing.Point(0, 0);
            this.panTblAdresse.Name = "panTblAdresse";
            this.panTblAdresse.RowCount = 1;
            this.panTblAdresse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panTblAdresse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panTblAdresse.Size = new System.Drawing.Size(737, 234);
            this.panTblAdresse.TabIndex = 0;
            // 
            // panAdresseLeft
            // 
            this.panAdresseLeft.Controls.Add(this.edtAdressePLZOrtKtBezirkLand);
            this.panAdresseLeft.Controls.Add(this.lblAdresseTitel);
            this.panAdresseLeft.Controls.Add(this.chkAktiv);
            this.panAdresseLeft.Controls.Add(this.edtAdresseTitel);
            this.panAdresseLeft.Controls.Add(this.lblAdresseName);
            this.panAdresseLeft.Controls.Add(this.edtAdresseName);
            this.panAdresseLeft.Controls.Add(this.lblAdresseZusatz);
            this.panAdresseLeft.Controls.Add(this.edtAdresseZusatz);
            this.panAdresseLeft.Controls.Add(this.lblAdresseStrasseNr);
            this.panAdresseLeft.Controls.Add(this.edtAdresseStrasse);
            this.panAdresseLeft.Controls.Add(this.edtAdresseHausNr);
            this.panAdresseLeft.Controls.Add(this.lblAdressePostfach);
            this.panAdresseLeft.Controls.Add(this.edtAdressePostfach);
            this.panAdresseLeft.Controls.Add(this.lblAdressePLZOrtKt);
            this.panAdresseLeft.Controls.Add(this.lblAdresseBezirk);
            this.panAdresseLeft.Controls.Add(this.lblAdresseLand);
            this.panAdresseLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panAdresseLeft.Location = new System.Drawing.Point(3, 3);
            this.panAdresseLeft.Name = "panAdresseLeft";
            this.panAdresseLeft.Size = new System.Drawing.Size(362, 228);
            this.panAdresseLeft.TabIndex = 0;
            // 
            // edtAdressePLZOrtKtBezirkLand
            // 
            this.edtAdressePLZOrtKtBezirkLand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAdressePLZOrtKtBezirkLand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdressePLZOrtKtBezirkLand.DataMemberBaGemeindeID = null;
            this.edtAdressePLZOrtKtBezirkLand.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdressePLZOrtKtBezirkLand.Location = new System.Drawing.Point(91, 148);
            this.edtAdressePLZOrtKtBezirkLand.Name = "edtAdressePLZOrtKtBezirkLand";
            this.edtAdressePLZOrtKtBezirkLand.ShowBezirk = true;
            this.edtAdressePLZOrtKtBezirkLand.Size = new System.Drawing.Size(268, 70);
            this.edtAdressePLZOrtKtBezirkLand.TabIndex = 13;
            // 
            // lblAdresseTitel
            // 
            this.lblAdresseTitel.Location = new System.Drawing.Point(9, 9);
            this.lblAdresseTitel.Name = "lblAdresseTitel";
            this.lblAdresseTitel.Size = new System.Drawing.Size(76, 24);
            this.lblAdresseTitel.TabIndex = 0;
            this.lblAdresseTitel.Text = "Titel";
            this.lblAdresseTitel.UseCompatibleTextRendering = true;
            // 
            // chkAktiv
            // 
            this.chkAktiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAktiv.DataMember = "Aktiv";
            this.chkAktiv.DataSource = this.qryInstitution;
            this.chkAktiv.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkAktiv.Location = new System.Drawing.Point(277, 11);
            this.chkAktiv.Name = "chkAktiv";
            this.chkAktiv.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.chkAktiv.Properties.Caption = "Aktiv";
            this.chkAktiv.Properties.Name = "chkBxActiv.Properties";
            this.chkAktiv.Properties.ReadOnly = true;
            this.chkAktiv.Size = new System.Drawing.Size(85, 19);
            this.chkAktiv.TabIndex = 2;
            // 
            // qryInstitution
            // 
            this.qryInstitution.HostControl = this;
            // 
            // edtAdresseTitel
            // 
            this.edtAdresseTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAdresseTitel.DataMember = "Titel";
            this.edtAdresseTitel.DataSource = this.qryInstitution;
            this.edtAdresseTitel.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresseTitel.Location = new System.Drawing.Point(91, 9);
            this.edtAdresseTitel.Name = "edtAdresseTitel";
            this.edtAdresseTitel.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresseTitel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseTitel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseTitel.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseTitel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseTitel.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseTitel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseTitel.Properties.Name = "kissTextEdit1.Properties";
            this.edtAdresseTitel.Properties.ReadOnly = true;
            this.edtAdresseTitel.Size = new System.Drawing.Size(127, 24);
            this.edtAdresseTitel.TabIndex = 1;
            // 
            // lblAdresseName
            // 
            this.lblAdresseName.Location = new System.Drawing.Point(9, 32);
            this.lblAdresseName.Name = "lblAdresseName";
            this.lblAdresseName.Size = new System.Drawing.Size(76, 24);
            this.lblAdresseName.TabIndex = 3;
            this.lblAdresseName.Text = "Name";
            this.lblAdresseName.UseCompatibleTextRendering = true;
            // 
            // edtAdresseName
            // 
            this.edtAdresseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAdresseName.DataMember = "Name";
            this.edtAdresseName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresseName.Location = new System.Drawing.Point(91, 32);
            this.edtAdresseName.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtAdresseName.Name = "edtAdresseName";
            this.edtAdresseName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresseName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseName.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseName.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseName.Properties.Name = "kissTextEdit12.Properties";
            this.edtAdresseName.Properties.ReadOnly = true;
            this.edtAdresseName.Size = new System.Drawing.Size(268, 48);
            this.edtAdresseName.TabIndex = 4;
            // 
            // lblAdresseZusatz
            // 
            this.lblAdresseZusatz.Location = new System.Drawing.Point(9, 79);
            this.lblAdresseZusatz.Name = "lblAdresseZusatz";
            this.lblAdresseZusatz.Size = new System.Drawing.Size(76, 24);
            this.lblAdresseZusatz.TabIndex = 5;
            this.lblAdresseZusatz.Text = "Zusatz";
            this.lblAdresseZusatz.UseCompatibleTextRendering = true;
            // 
            // edtAdresseZusatz
            // 
            this.edtAdresseZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAdresseZusatz.DataMember = "Zusatz";
            this.edtAdresseZusatz.DataSource = this.qryInstitution;
            this.edtAdresseZusatz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresseZusatz.Location = new System.Drawing.Point(91, 79);
            this.edtAdresseZusatz.Name = "edtAdresseZusatz";
            this.edtAdresseZusatz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresseZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseZusatz.Properties.Name = "kissTextEdit12.Properties";
            this.edtAdresseZusatz.Properties.ReadOnly = true;
            this.edtAdresseZusatz.Size = new System.Drawing.Size(268, 24);
            this.edtAdresseZusatz.TabIndex = 6;
            // 
            // lblAdresseStrasseNr
            // 
            this.lblAdresseStrasseNr.Location = new System.Drawing.Point(9, 103);
            this.lblAdresseStrasseNr.Name = "lblAdresseStrasseNr";
            this.lblAdresseStrasseNr.Size = new System.Drawing.Size(76, 24);
            this.lblAdresseStrasseNr.TabIndex = 7;
            this.lblAdresseStrasseNr.Text = "Strasse / Nr.";
            this.lblAdresseStrasseNr.UseCompatibleTextRendering = true;
            // 
            // edtAdresseStrasse
            // 
            this.edtAdresseStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAdresseStrasse.DataMember = "Strasse";
            this.edtAdresseStrasse.DataSource = this.qryInstitution;
            this.edtAdresseStrasse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresseStrasse.Location = new System.Drawing.Point(91, 102);
            this.edtAdresseStrasse.Name = "edtAdresseStrasse";
            this.edtAdresseStrasse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresseStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseStrasse.Properties.Name = "kissTextEdit17.Properties";
            this.edtAdresseStrasse.Properties.ReadOnly = true;
            this.edtAdresseStrasse.Size = new System.Drawing.Size(220, 24);
            this.edtAdresseStrasse.TabIndex = 8;
            // 
            // edtAdresseHausNr
            // 
            this.edtAdresseHausNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAdresseHausNr.DataMember = "HausNr";
            this.edtAdresseHausNr.DataSource = this.qryInstitution;
            this.edtAdresseHausNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresseHausNr.Location = new System.Drawing.Point(310, 102);
            this.edtAdresseHausNr.Name = "edtAdresseHausNr";
            this.edtAdresseHausNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresseHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseHausNr.Properties.Name = "kissTextEdit11.Properties";
            this.edtAdresseHausNr.Properties.ReadOnly = true;
            this.edtAdresseHausNr.Size = new System.Drawing.Size(49, 24);
            this.edtAdresseHausNr.TabIndex = 9;
            // 
            // lblAdressePostfach
            // 
            this.lblAdressePostfach.Location = new System.Drawing.Point(9, 125);
            this.lblAdressePostfach.Name = "lblAdressePostfach";
            this.lblAdressePostfach.Size = new System.Drawing.Size(76, 24);
            this.lblAdressePostfach.TabIndex = 10;
            this.lblAdressePostfach.Text = "Postfach";
            this.lblAdressePostfach.UseCompatibleTextRendering = true;
            // 
            // edtAdressePostfach
            // 
            this.edtAdressePostfach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAdressePostfach.DataMember = "Postfach";
            this.edtAdressePostfach.DataSource = this.qryInstitution;
            this.edtAdressePostfach.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdressePostfach.Location = new System.Drawing.Point(91, 125);
            this.edtAdressePostfach.Name = "edtAdressePostfach";
            this.edtAdressePostfach.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdressePostfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdressePostfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdressePostfach.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdressePostfach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdressePostfach.Properties.Appearance.Options.UseFont = true;
            this.edtAdressePostfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdressePostfach.Properties.Name = "kissTextEdit10.Properties";
            this.edtAdressePostfach.Properties.ReadOnly = true;
            this.edtAdressePostfach.Size = new System.Drawing.Size(268, 24);
            this.edtAdressePostfach.TabIndex = 11;
            // 
            // lblAdressePLZOrtKt
            // 
            this.lblAdressePLZOrtKt.Location = new System.Drawing.Point(9, 148);
            this.lblAdressePLZOrtKt.Name = "lblAdressePLZOrtKt";
            this.lblAdressePLZOrtKt.Size = new System.Drawing.Size(76, 24);
            this.lblAdressePLZOrtKt.TabIndex = 12;
            this.lblAdressePLZOrtKt.Text = "PLZ / Ort / Kt.";
            this.lblAdressePLZOrtKt.UseCompatibleTextRendering = true;
            // 
            // lblAdresseBezirk
            // 
            this.lblAdresseBezirk.Location = new System.Drawing.Point(9, 170);
            this.lblAdresseBezirk.Name = "lblAdresseBezirk";
            this.lblAdresseBezirk.Size = new System.Drawing.Size(76, 24);
            this.lblAdresseBezirk.TabIndex = 14;
            this.lblAdresseBezirk.Text = "Bezirk";
            this.lblAdresseBezirk.UseCompatibleTextRendering = true;
            // 
            // lblAdresseLand
            // 
            this.lblAdresseLand.Location = new System.Drawing.Point(9, 194);
            this.lblAdresseLand.Name = "lblAdresseLand";
            this.lblAdresseLand.Size = new System.Drawing.Size(76, 24);
            this.lblAdresseLand.TabIndex = 15;
            this.lblAdresseLand.Text = "Land";
            this.lblAdresseLand.UseCompatibleTextRendering = true;
            // 
            // panAdresseRight
            // 
            this.panAdresseRight.Controls.Add(this.edtAdresseBemerkung);
            this.panAdresseRight.Controls.Add(this.lblAdresseTelefon);
            this.panAdresseRight.Controls.Add(this.lblAdresseBemerkungen);
            this.panAdresseRight.Controls.Add(this.edtAdresseTelefon);
            this.panAdresseRight.Controls.Add(this.edtAdresseAbteilung);
            this.panAdresseRight.Controls.Add(this.lblAdresseFax);
            this.panAdresseRight.Controls.Add(this.lblAdresseAbteilung);
            this.panAdresseRight.Controls.Add(this.edtAdresseFax);
            this.panAdresseRight.Controls.Add(this.edtAdresseSprache);
            this.panAdresseRight.Controls.Add(this.lblAdresseEmail);
            this.panAdresseRight.Controls.Add(this.lblAdresseSprache);
            this.panAdresseRight.Controls.Add(this.edtAdresseEmail);
            this.panAdresseRight.Controls.Add(this.edtAdresseInternet);
            this.panAdresseRight.Controls.Add(this.lblAdresseInternet);
            this.panAdresseRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panAdresseRight.Location = new System.Drawing.Point(371, 3);
            this.panAdresseRight.Name = "panAdresseRight";
            this.panAdresseRight.Size = new System.Drawing.Size(363, 228);
            this.panAdresseRight.TabIndex = 1;
            // 
            // edtAdresseBemerkung
            // 
            this.edtAdresseBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAdresseBemerkung.DataMember = "Bemerkung";
            this.edtAdresseBemerkung.DataSource = this.qryInstitution;
            this.edtAdresseBemerkung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresseBemerkung.Location = new System.Drawing.Point(91, 161);
            this.edtAdresseBemerkung.Margin = new System.Windows.Forms.Padding(3, 3, 9, 9);
            this.edtAdresseBemerkung.Name = "edtAdresseBemerkung";
            this.edtAdresseBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresseBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseBemerkung.Properties.ReadOnly = true;
            this.edtAdresseBemerkung.Size = new System.Drawing.Size(270, 58);
            this.edtAdresseBemerkung.TabIndex = 13;
            // 
            // lblAdresseTelefon
            // 
            this.lblAdresseTelefon.Location = new System.Drawing.Point(9, 9);
            this.lblAdresseTelefon.Name = "lblAdresseTelefon";
            this.lblAdresseTelefon.Size = new System.Drawing.Size(76, 24);
            this.lblAdresseTelefon.TabIndex = 0;
            this.lblAdresseTelefon.Text = "Telefon";
            this.lblAdresseTelefon.UseCompatibleTextRendering = true;
            // 
            // lblAdresseBemerkungen
            // 
            this.lblAdresseBemerkungen.Location = new System.Drawing.Point(9, 161);
            this.lblAdresseBemerkungen.Name = "lblAdresseBemerkungen";
            this.lblAdresseBemerkungen.Size = new System.Drawing.Size(76, 24);
            this.lblAdresseBemerkungen.TabIndex = 12;
            this.lblAdresseBemerkungen.Text = "Bemerkungen";
            this.lblAdresseBemerkungen.UseCompatibleTextRendering = true;
            // 
            // edtAdresseTelefon
            // 
            this.edtAdresseTelefon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAdresseTelefon.DataMember = "Telefon";
            this.edtAdresseTelefon.DataSource = this.qryInstitution;
            this.edtAdresseTelefon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresseTelefon.Location = new System.Drawing.Point(91, 9);
            this.edtAdresseTelefon.Name = "edtAdresseTelefon";
            this.edtAdresseTelefon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresseTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseTelefon.Properties.Name = "kissTextEdit20.Properties";
            this.edtAdresseTelefon.Properties.ReadOnly = true;
            this.edtAdresseTelefon.Size = new System.Drawing.Size(270, 24);
            this.edtAdresseTelefon.TabIndex = 1;
            // 
            // edtAdresseAbteilung
            // 
            this.edtAdresseAbteilung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAdresseAbteilung.DataMember = "Abteilung";
            this.edtAdresseAbteilung.DataSource = this.qryInstitution;
            this.edtAdresseAbteilung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresseAbteilung.Location = new System.Drawing.Point(91, 131);
            this.edtAdresseAbteilung.Name = "edtAdresseAbteilung";
            this.edtAdresseAbteilung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresseAbteilung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseAbteilung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseAbteilung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseAbteilung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseAbteilung.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseAbteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseAbteilung.Properties.Name = "kissTextEdit3.Properties";
            this.edtAdresseAbteilung.Properties.ReadOnly = true;
            this.edtAdresseAbteilung.Size = new System.Drawing.Size(270, 24);
            this.edtAdresseAbteilung.TabIndex = 11;
            // 
            // lblAdresseFax
            // 
            this.lblAdresseFax.Location = new System.Drawing.Point(9, 32);
            this.lblAdresseFax.Name = "lblAdresseFax";
            this.lblAdresseFax.Size = new System.Drawing.Size(76, 24);
            this.lblAdresseFax.TabIndex = 2;
            this.lblAdresseFax.Text = "Fax";
            this.lblAdresseFax.UseCompatibleTextRendering = true;
            // 
            // lblAdresseAbteilung
            // 
            this.lblAdresseAbteilung.Location = new System.Drawing.Point(9, 131);
            this.lblAdresseAbteilung.Name = "lblAdresseAbteilung";
            this.lblAdresseAbteilung.Size = new System.Drawing.Size(76, 24);
            this.lblAdresseAbteilung.TabIndex = 10;
            this.lblAdresseAbteilung.Text = "Abteilung";
            this.lblAdresseAbteilung.UseCompatibleTextRendering = true;
            // 
            // edtAdresseFax
            // 
            this.edtAdresseFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAdresseFax.DataMember = "Fax";
            this.edtAdresseFax.DataSource = this.qryInstitution;
            this.edtAdresseFax.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresseFax.Location = new System.Drawing.Point(91, 32);
            this.edtAdresseFax.Name = "edtAdresseFax";
            this.edtAdresseFax.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresseFax.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseFax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseFax.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseFax.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseFax.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseFax.Properties.Name = "kissTextEdit19.Properties";
            this.edtAdresseFax.Properties.ReadOnly = true;
            this.edtAdresseFax.Size = new System.Drawing.Size(270, 24);
            this.edtAdresseFax.TabIndex = 3;
            // 
            // edtAdresseSprache
            // 
            this.edtAdresseSprache.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAdresseSprache.DataMember = "Sprache";
            this.edtAdresseSprache.DataSource = this.qryInstitution;
            this.edtAdresseSprache.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresseSprache.Location = new System.Drawing.Point(91, 101);
            this.edtAdresseSprache.Name = "edtAdresseSprache";
            this.edtAdresseSprache.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresseSprache.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseSprache.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseSprache.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseSprache.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseSprache.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseSprache.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseSprache.Properties.Name = "kissTextEdit3.Properties";
            this.edtAdresseSprache.Properties.ReadOnly = true;
            this.edtAdresseSprache.Size = new System.Drawing.Size(270, 24);
            this.edtAdresseSprache.TabIndex = 9;
            // 
            // lblAdresseEmail
            // 
            this.lblAdresseEmail.Location = new System.Drawing.Point(9, 55);
            this.lblAdresseEmail.Name = "lblAdresseEmail";
            this.lblAdresseEmail.Size = new System.Drawing.Size(76, 24);
            this.lblAdresseEmail.TabIndex = 4;
            this.lblAdresseEmail.Text = "E-Mail";
            this.lblAdresseEmail.UseCompatibleTextRendering = true;
            // 
            // lblAdresseSprache
            // 
            this.lblAdresseSprache.Location = new System.Drawing.Point(9, 101);
            this.lblAdresseSprache.Name = "lblAdresseSprache";
            this.lblAdresseSprache.Size = new System.Drawing.Size(76, 24);
            this.lblAdresseSprache.TabIndex = 8;
            this.lblAdresseSprache.Text = "Sprache";
            this.lblAdresseSprache.UseCompatibleTextRendering = true;
            // 
            // edtAdresseEmail
            // 
            this.edtAdresseEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAdresseEmail.DataMember = "EMail";
            this.edtAdresseEmail.DataSource = this.qryInstitution;
            this.edtAdresseEmail.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresseEmail.Location = new System.Drawing.Point(91, 55);
            this.edtAdresseEmail.Name = "edtAdresseEmail";
            this.edtAdresseEmail.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresseEmail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseEmail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseEmail.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseEmail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseEmail.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseEmail.Properties.Name = "kissTextEdit18.Properties";
            this.edtAdresseEmail.Properties.ReadOnly = true;
            this.edtAdresseEmail.Size = new System.Drawing.Size(270, 24);
            this.edtAdresseEmail.TabIndex = 5;
            // 
            // edtAdresseInternet
            // 
            this.edtAdresseInternet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAdresseInternet.DataMember = "Homepage";
            this.edtAdresseInternet.DataSource = this.qryInstitution;
            this.edtAdresseInternet.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdresseInternet.Location = new System.Drawing.Point(91, 78);
            this.edtAdresseInternet.Name = "edtAdresseInternet";
            this.edtAdresseInternet.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdresseInternet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdresseInternet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdresseInternet.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdresseInternet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdresseInternet.Properties.Appearance.Options.UseFont = true;
            this.edtAdresseInternet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdresseInternet.Properties.Name = "kissTextEdit3.Properties";
            this.edtAdresseInternet.Properties.ReadOnly = true;
            this.edtAdresseInternet.Size = new System.Drawing.Size(270, 24);
            this.edtAdresseInternet.TabIndex = 7;
            // 
            // lblAdresseInternet
            // 
            this.lblAdresseInternet.Location = new System.Drawing.Point(9, 78);
            this.lblAdresseInternet.Name = "lblAdresseInternet";
            this.lblAdresseInternet.Size = new System.Drawing.Size(76, 24);
            this.lblAdresseInternet.TabIndex = 6;
            this.lblAdresseInternet.Text = "Internet";
            this.lblAdresseInternet.UseCompatibleTextRendering = true;
            // 
            // tpgKontakt
            // 
            this.tpgKontakt.Controls.Add(this.panTblKontakt);
            this.tpgKontakt.Location = new System.Drawing.Point(6, 6);
            this.tpgKontakt.Name = "tpgKontakt";
            this.tpgKontakt.Size = new System.Drawing.Size(737, 234);
            this.tpgKontakt.TabIndex = 2;
            this.tpgKontakt.Title = "&Kontakt";
            // 
            // panTblKontakt
            // 
            this.panTblKontakt.ColumnCount = 2;
            this.panTblKontakt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panTblKontakt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panTblKontakt.Controls.Add(this.panKontaktLeft, 0, 0);
            this.panTblKontakt.Controls.Add(this.panKontaktRight, 1, 0);
            this.panTblKontakt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTblKontakt.Location = new System.Drawing.Point(0, 0);
            this.panTblKontakt.Name = "panTblKontakt";
            this.panTblKontakt.RowCount = 1;
            this.panTblKontakt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panTblKontakt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panTblKontakt.Size = new System.Drawing.Size(737, 234);
            this.panTblKontakt.TabIndex = 0;
            // 
            // panKontaktLeft
            // 
            this.panKontaktLeft.Controls.Add(this.lblKontaktPersonName);
            this.panKontaktLeft.Controls.Add(this.edtKontaktName);
            this.panKontaktLeft.Controls.Add(this.lblKontaktSprache);
            this.panKontaktLeft.Controls.Add(this.edtKontaktVorname);
            this.panKontaktLeft.Controls.Add(this.edtKontaktSprachCode);
            this.panKontaktLeft.Controls.Add(this.lblKontaktPersonVorname);
            this.panKontaktLeft.Controls.Add(this.lblKontaktTelefon);
            this.panKontaktLeft.Controls.Add(this.lblKontaktGeschlecht);
            this.panKontaktLeft.Controls.Add(this.lblKontaktFax);
            this.panKontaktLeft.Controls.Add(this.edtKontaktGeschlecht);
            this.panKontaktLeft.Controls.Add(this.lblKontaktEMail);
            this.panKontaktLeft.Controls.Add(this.edtKontaktTelefon);
            this.panKontaktLeft.Controls.Add(this.edtKontaktEMail);
            this.panKontaktLeft.Controls.Add(this.edtKontaktFax);
            this.panKontaktLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panKontaktLeft.Location = new System.Drawing.Point(3, 3);
            this.panKontaktLeft.Name = "panKontaktLeft";
            this.panKontaktLeft.Size = new System.Drawing.Size(362, 228);
            this.panKontaktLeft.TabIndex = 0;
            // 
            // lblKontaktPersonName
            // 
            this.lblKontaktPersonName.Location = new System.Drawing.Point(9, 9);
            this.lblKontaktPersonName.Name = "lblKontaktPersonName";
            this.lblKontaktPersonName.Size = new System.Drawing.Size(76, 24);
            this.lblKontaktPersonName.TabIndex = 0;
            this.lblKontaktPersonName.Text = "Name";
            this.lblKontaktPersonName.UseCompatibleTextRendering = true;
            // 
            // edtKontaktName
            // 
            this.edtKontaktName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKontaktName.DataMember = "Name";
            this.edtKontaktName.Location = new System.Drawing.Point(91, 10);
            this.edtKontaktName.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtKontaktName.Name = "edtKontaktName";
            this.edtKontaktName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktName.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktName.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktName.Properties.Name = "editName.Properties";
            this.edtKontaktName.Size = new System.Drawing.Size(268, 24);
            this.edtKontaktName.TabIndex = 1;
            // 
            // lblKontaktSprache
            // 
            this.lblKontaktSprache.Location = new System.Drawing.Point(9, 155);
            this.lblKontaktSprache.Name = "lblKontaktSprache";
            this.lblKontaktSprache.Size = new System.Drawing.Size(76, 24);
            this.lblKontaktSprache.TabIndex = 12;
            this.lblKontaktSprache.Text = "Sprache";
            this.lblKontaktSprache.UseCompatibleTextRendering = true;
            // 
            // edtKontaktVorname
            // 
            this.edtKontaktVorname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKontaktVorname.DataMember = "Vorname";
            this.edtKontaktVorname.Location = new System.Drawing.Point(91, 33);
            this.edtKontaktVorname.Name = "edtKontaktVorname";
            this.edtKontaktVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktVorname.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktVorname.Properties.Name = "editName.Properties";
            this.edtKontaktVorname.Size = new System.Drawing.Size(268, 24);
            this.edtKontaktVorname.TabIndex = 3;
            // 
            // edtKontaktSprachCode
            // 
            this.edtKontaktSprachCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKontaktSprachCode.DataMember = "SprachCode";
            this.edtKontaktSprachCode.Location = new System.Drawing.Point(91, 155);
            this.edtKontaktSprachCode.LOVName = "Sprache";
            this.edtKontaktSprachCode.Name = "edtKontaktSprachCode";
            this.edtKontaktSprachCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktSprachCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktSprachCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktSprachCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktSprachCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktSprachCode.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktSprachCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKontaktSprachCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktSprachCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKontaktSprachCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKontaktSprachCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtKontaktSprachCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtKontaktSprachCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontaktSprachCode.Properties.Name = "kissLookUpEdit6.Properties";
            this.edtKontaktSprachCode.Properties.NullText = "";
            this.edtKontaktSprachCode.Properties.ShowFooter = false;
            this.edtKontaktSprachCode.Properties.ShowHeader = false;
            this.edtKontaktSprachCode.Size = new System.Drawing.Size(268, 24);
            this.edtKontaktSprachCode.TabIndex = 13;
            // 
            // lblKontaktPersonVorname
            // 
            this.lblKontaktPersonVorname.Location = new System.Drawing.Point(9, 32);
            this.lblKontaktPersonVorname.Name = "lblKontaktPersonVorname";
            this.lblKontaktPersonVorname.Size = new System.Drawing.Size(76, 24);
            this.lblKontaktPersonVorname.TabIndex = 2;
            this.lblKontaktPersonVorname.Text = "Vorname";
            this.lblKontaktPersonVorname.UseCompatibleTextRendering = true;
            // 
            // lblKontaktTelefon
            // 
            this.lblKontaktTelefon.Location = new System.Drawing.Point(9, 86);
            this.lblKontaktTelefon.Name = "lblKontaktTelefon";
            this.lblKontaktTelefon.Size = new System.Drawing.Size(76, 24);
            this.lblKontaktTelefon.TabIndex = 6;
            this.lblKontaktTelefon.Text = "Telefon";
            this.lblKontaktTelefon.UseCompatibleTextRendering = true;
            // 
            // lblKontaktGeschlecht
            // 
            this.lblKontaktGeschlecht.Location = new System.Drawing.Point(9, 56);
            this.lblKontaktGeschlecht.Name = "lblKontaktGeschlecht";
            this.lblKontaktGeschlecht.Size = new System.Drawing.Size(76, 24);
            this.lblKontaktGeschlecht.TabIndex = 4;
            this.lblKontaktGeschlecht.Text = "Geschlecht";
            this.lblKontaktGeschlecht.UseCompatibleTextRendering = true;
            // 
            // lblKontaktFax
            // 
            this.lblKontaktFax.Location = new System.Drawing.Point(9, 109);
            this.lblKontaktFax.Name = "lblKontaktFax";
            this.lblKontaktFax.Size = new System.Drawing.Size(76, 24);
            this.lblKontaktFax.TabIndex = 8;
            this.lblKontaktFax.Text = "Fax";
            this.lblKontaktFax.UseCompatibleTextRendering = true;
            // 
            // edtKontaktGeschlecht
            // 
            this.edtKontaktGeschlecht.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKontaktGeschlecht.Location = new System.Drawing.Point(91, 56);
            this.edtKontaktGeschlecht.LOVName = "Geschlecht";
            this.edtKontaktGeschlecht.Name = "edtKontaktGeschlecht";
            this.edtKontaktGeschlecht.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktGeschlecht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktGeschlecht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktGeschlecht.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktGeschlecht.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktGeschlecht.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktGeschlecht.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKontaktGeschlecht.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktGeschlecht.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKontaktGeschlecht.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKontaktGeschlecht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtKontaktGeschlecht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtKontaktGeschlecht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontaktGeschlecht.Properties.NullText = "";
            this.edtKontaktGeschlecht.Properties.ShowFooter = false;
            this.edtKontaktGeschlecht.Properties.ShowHeader = false;
            this.edtKontaktGeschlecht.Size = new System.Drawing.Size(268, 24);
            this.edtKontaktGeschlecht.TabIndex = 5;
            this.edtKontaktGeschlecht.EditValueChanged += new System.EventHandler(this.edtKontaktGeschlecht_EditValueChanged);
            // 
            // lblKontaktEMail
            // 
            this.lblKontaktEMail.Location = new System.Drawing.Point(9, 132);
            this.lblKontaktEMail.Name = "lblKontaktEMail";
            this.lblKontaktEMail.Size = new System.Drawing.Size(76, 24);
            this.lblKontaktEMail.TabIndex = 10;
            this.lblKontaktEMail.Text = "E-Mail";
            this.lblKontaktEMail.UseCompatibleTextRendering = true;
            // 
            // edtKontaktTelefon
            // 
            this.edtKontaktTelefon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKontaktTelefon.DataMember = "Telefon";
            this.edtKontaktTelefon.Location = new System.Drawing.Point(91, 86);
            this.edtKontaktTelefon.Name = "edtKontaktTelefon";
            this.edtKontaktTelefon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktTelefon.Properties.Name = "kissTextEdit20.Properties";
            this.edtKontaktTelefon.Size = new System.Drawing.Size(268, 24);
            this.edtKontaktTelefon.TabIndex = 7;
            // 
            // edtKontaktEMail
            // 
            this.edtKontaktEMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKontaktEMail.DataMember = "EMail";
            this.edtKontaktEMail.Location = new System.Drawing.Point(91, 132);
            this.edtKontaktEMail.Name = "edtKontaktEMail";
            this.edtKontaktEMail.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktEMail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktEMail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktEMail.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktEMail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktEMail.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktEMail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktEMail.Properties.Name = "kissTextEdit18.Properties";
            this.edtKontaktEMail.Size = new System.Drawing.Size(268, 24);
            this.edtKontaktEMail.TabIndex = 11;
            // 
            // edtKontaktFax
            // 
            this.edtKontaktFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKontaktFax.DataMember = "Fax";
            this.edtKontaktFax.Location = new System.Drawing.Point(91, 109);
            this.edtKontaktFax.Name = "edtKontaktFax";
            this.edtKontaktFax.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktFax.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktFax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktFax.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktFax.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktFax.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktFax.Properties.Name = "kissTextEdit19.Properties";
            this.edtKontaktFax.Size = new System.Drawing.Size(268, 24);
            this.edtKontaktFax.TabIndex = 9;
            // 
            // panKontaktRight
            // 
            this.panKontaktRight.Controls.Add(this.lblKontaktBemerkung);
            this.panKontaktRight.Controls.Add(this.lblKontaktTitel);
            this.panKontaktRight.Controls.Add(this.edtKontaktBemerkung);
            this.panKontaktRight.Controls.Add(this.edtKontaktAnrede);
            this.panKontaktRight.Controls.Add(this.chkKontaktAktiv);
            this.panKontaktRight.Controls.Add(this.chkKontaktManuelleAnrede);
            this.panKontaktRight.Controls.Add(this.lblKontaktBriefanrede);
            this.panKontaktRight.Controls.Add(this.edtKontaktBriefanrede);
            this.panKontaktRight.Controls.Add(this.lblKontaktAnrede);
            this.panKontaktRight.Controls.Add(this.edtKontaktTitel);
            this.panKontaktRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panKontaktRight.Location = new System.Drawing.Point(371, 3);
            this.panKontaktRight.Name = "panKontaktRight";
            this.panKontaktRight.Size = new System.Drawing.Size(363, 228);
            this.panKontaktRight.TabIndex = 1;
            // 
            // lblKontaktBemerkung
            // 
            this.lblKontaktBemerkung.Location = new System.Drawing.Point(9, 86);
            this.lblKontaktBemerkung.Name = "lblKontaktBemerkung";
            this.lblKontaktBemerkung.Size = new System.Drawing.Size(113, 24);
            this.lblKontaktBemerkung.TabIndex = 7;
            this.lblKontaktBemerkung.Text = "Bemerkungen";
            this.lblKontaktBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblKontaktTitel
            // 
            this.lblKontaktTitel.Location = new System.Drawing.Point(9, 9);
            this.lblKontaktTitel.Name = "lblKontaktTitel";
            this.lblKontaktTitel.Size = new System.Drawing.Size(113, 24);
            this.lblKontaktTitel.TabIndex = 0;
            this.lblKontaktTitel.Text = "Titel";
            this.lblKontaktTitel.UseCompatibleTextRendering = true;
            // 
            // edtKontaktBemerkung
            // 
            this.edtKontaktBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKontaktBemerkung.DataMember = "Bemerkung";
            this.edtKontaktBemerkung.Location = new System.Drawing.Point(128, 86);
            this.edtKontaktBemerkung.Margin = new System.Windows.Forms.Padding(3, 3, 9, 9);
            this.edtKontaktBemerkung.Name = "edtKontaktBemerkung";
            this.edtKontaktBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktBemerkung.Size = new System.Drawing.Size(233, 133);
            this.edtKontaktBemerkung.TabIndex = 8;
            // 
            // edtKontaktAnrede
            // 
            this.edtKontaktAnrede.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKontaktAnrede.Location = new System.Drawing.Point(128, 33);
            this.edtKontaktAnrede.Name = "edtKontaktAnrede";
            this.edtKontaktAnrede.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktAnrede.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktAnrede.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktAnrede.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktAnrede.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktAnrede.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktAnrede.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktAnrede.Properties.Name = "kissTextEdit1.Properties";
            this.edtKontaktAnrede.Size = new System.Drawing.Size(71, 24);
            this.edtKontaktAnrede.TabIndex = 4;
            // 
            // chkKontaktAktiv
            // 
            this.chkKontaktAktiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkKontaktAktiv.DataMember = "Aktiv";
            this.chkKontaktAktiv.DataSource = this.qryBaInstitutionKontakt;
            this.chkKontaktAktiv.Location = new System.Drawing.Point(205, 12);
            this.chkKontaktAktiv.Name = "chkKontaktAktiv";
            this.chkKontaktAktiv.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKontaktAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.chkKontaktAktiv.Properties.Caption = "Aktiv";
            this.chkKontaktAktiv.Size = new System.Drawing.Size(119, 19);
            this.chkKontaktAktiv.TabIndex = 9;
            this.chkKontaktAktiv.CheckedChanged += new System.EventHandler(this.chkKontaktManuelleAnrede_CheckedChanged);
            // 
            // qryBaInstitutionKontakt
            // 
            this.qryBaInstitutionKontakt.HostControl = this;
            this.qryBaInstitutionKontakt.MasterQuery = this.qryBaPersonInstitution;
            this.qryBaInstitutionKontakt.TableName = "BaInstitutionKontakt";
            this.qryBaInstitutionKontakt.AfterInsert += new System.EventHandler(this.qryBaInstitutionKontakt_AfterInsert);
            this.qryBaInstitutionKontakt.BeforeDeleteQuestion += new System.EventHandler(this.qryBaInstitutionKontakt_BeforeDeleteQuestion);
            this.qryBaInstitutionKontakt.BeforePost += new System.EventHandler(this.qryBaInstitutionKontakt_BeforePost);
            this.qryBaInstitutionKontakt.PostCompleted += new System.EventHandler(this.qryBaInstitutionKontakt_PostCompleted);
            // 
            // chkKontaktManuelleAnrede
            // 
            this.chkKontaktManuelleAnrede.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkKontaktManuelleAnrede.EditValue = false;
            this.chkKontaktManuelleAnrede.Location = new System.Drawing.Point(205, 35);
            this.chkKontaktManuelleAnrede.Name = "chkKontaktManuelleAnrede";
            this.chkKontaktManuelleAnrede.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKontaktManuelleAnrede.Properties.Appearance.Options.UseBackColor = true;
            this.chkKontaktManuelleAnrede.Properties.Caption = "Manuelle Anrede";
            this.chkKontaktManuelleAnrede.Size = new System.Drawing.Size(156, 19);
            this.chkKontaktManuelleAnrede.TabIndex = 2;
            this.chkKontaktManuelleAnrede.CheckedChanged += new System.EventHandler(this.chkKontaktManuelleAnrede_CheckedChanged);
            // 
            // lblKontaktBriefanrede
            // 
            this.lblKontaktBriefanrede.Location = new System.Drawing.Point(9, 56);
            this.lblKontaktBriefanrede.Name = "lblKontaktBriefanrede";
            this.lblKontaktBriefanrede.Size = new System.Drawing.Size(113, 24);
            this.lblKontaktBriefanrede.TabIndex = 5;
            this.lblKontaktBriefanrede.Text = "Briefanrede";
            this.lblKontaktBriefanrede.UseCompatibleTextRendering = true;
            // 
            // edtKontaktBriefanrede
            // 
            this.edtKontaktBriefanrede.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKontaktBriefanrede.Location = new System.Drawing.Point(128, 56);
            this.edtKontaktBriefanrede.Name = "edtKontaktBriefanrede";
            this.edtKontaktBriefanrede.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktBriefanrede.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktBriefanrede.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktBriefanrede.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktBriefanrede.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktBriefanrede.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktBriefanrede.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktBriefanrede.Size = new System.Drawing.Size(233, 24);
            this.edtKontaktBriefanrede.TabIndex = 6;
            // 
            // lblKontaktAnrede
            // 
            this.lblKontaktAnrede.Location = new System.Drawing.Point(9, 32);
            this.lblKontaktAnrede.Name = "lblKontaktAnrede";
            this.lblKontaktAnrede.Size = new System.Drawing.Size(113, 24);
            this.lblKontaktAnrede.TabIndex = 3;
            this.lblKontaktAnrede.Text = "Anrede";
            this.lblKontaktAnrede.UseCompatibleTextRendering = true;
            // 
            // edtKontaktTitel
            // 
            this.edtKontaktTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKontaktTitel.Location = new System.Drawing.Point(128, 10);
            this.edtKontaktTitel.Name = "edtKontaktTitel";
            this.edtKontaktTitel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktTitel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktTitel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktTitel.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktTitel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktTitel.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktTitel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktTitel.Size = new System.Drawing.Size(71, 24);
            this.edtKontaktTitel.TabIndex = 1;
            // 
            // tpgAdressTyp
            // 
            this.tpgAdressTyp.Controls.Add(this.grdInstTypen);
            this.tpgAdressTyp.Location = new System.Drawing.Point(6, 6);
            this.tpgAdressTyp.Name = "tpgAdressTyp";
            this.tpgAdressTyp.Size = new System.Drawing.Size(737, 234);
            this.tpgAdressTyp.TabIndex = 1;
            this.tpgAdressTyp.Title = "&Typen";
            // 
            // grdInstTypen
            // 
            this.grdInstTypen.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdInstTypen.EmbeddedNavigator.Name = "";
            this.grdInstTypen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdInstTypen.Location = new System.Drawing.Point(0, 0);
            this.grdInstTypen.MainView = this.grvInstTypen;
            this.grdInstTypen.Name = "grdInstTypen";
            this.grdInstTypen.Size = new System.Drawing.Size(737, 234);
            this.grdInstTypen.TabIndex = 0;
            this.grdInstTypen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvInstTypen});
            // 
            // grvInstTypen
            // 
            this.grvInstTypen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvInstTypen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstTypen.Appearance.Empty.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.Empty.Options.UseFont = true;
            this.grvInstTypen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstTypen.Appearance.EvenRow.Options.UseFont = true;
            this.grvInstTypen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvInstTypen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstTypen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvInstTypen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvInstTypen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvInstTypen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvInstTypen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstTypen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvInstTypen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvInstTypen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvInstTypen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvInstTypen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvInstTypen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvInstTypen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvInstTypen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.GroupRow.Options.UseFont = true;
            this.grvInstTypen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvInstTypen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvInstTypen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvInstTypen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvInstTypen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvInstTypen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvInstTypen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvInstTypen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstTypen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvInstTypen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvInstTypen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvInstTypen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvInstTypen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstTypen.Appearance.OddRow.Options.UseFont = true;
            this.grvInstTypen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvInstTypen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstTypen.Appearance.Row.Options.UseBackColor = true;
            this.grvInstTypen.Appearance.Row.Options.UseFont = true;
            this.grvInstTypen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvInstTypen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvInstTypen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvInstTypen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvInstTypen.BestFitMaxRowCount = 1000;
            this.grvInstTypen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvInstTypen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInstTyp});
            this.grvInstTypen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvInstTypen.GridControl = this.grdInstTypen;
            this.grvInstTypen.Name = "grvInstTypen";
            this.grvInstTypen.OptionsBehavior.Editable = false;
            this.grvInstTypen.OptionsCustomization.AllowFilter = false;
            this.grvInstTypen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvInstTypen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvInstTypen.OptionsNavigation.UseTabKey = false;
            this.grvInstTypen.OptionsView.ColumnAutoWidth = false;
            this.grvInstTypen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvInstTypen.OptionsView.ShowGroupPanel = false;
            this.grvInstTypen.OptionsView.ShowIndicator = false;
            // 
            // colInstTyp
            // 
            this.colInstTyp.Caption = "Zugewiesene Typen";
            this.colInstTyp.Name = "colInstTyp";
            this.colInstTyp.Visible = true;
            this.colInstTyp.VisibleIndex = 0;
            this.colInstTyp.Width = 355;
            // 
            // edtKontaktperson
            // 
            this.edtKontaktperson.Location = new System.Drawing.Point(109, 39);
            this.edtKontaktperson.Name = "edtKontaktperson";
            this.edtKontaktperson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktperson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktperson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktperson.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktperson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktperson.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktperson.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKontaktperson.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktperson.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKontaktperson.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKontaktperson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtKontaktperson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, global::KiSS4.Basis.Properties.Resources.NewEntryEdt, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", "insert"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, global::KiSS4.Basis.Properties.Resources.DeleteEntryEdt, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", "delete")});
            this.edtKontaktperson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontaktperson.Properties.NullText = "";
            this.edtKontaktperson.Properties.ShowFooter = false;
            this.edtKontaktperson.Properties.ShowHeader = false;
            this.edtKontaktperson.Size = new System.Drawing.Size(240, 24);
            this.edtKontaktperson.TabIndex = 3;
            this.edtKontaktperson.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.edtKontaktperson_ButtonClick);
            this.edtKontaktperson.EditValueChanged += new System.EventHandler(this.edtKontaktperson_EditValueChanged);
            this.edtKontaktperson.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.edtKontaktperson_EditValueChanging);
            // 
            // qryInstTypen
            // 
            this.qryInstTypen.HostControl = this;
            // 
            // panDetails
            // 
            this.panDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panDetails.Controls.Add(this.btnDatenblatt);
            this.panDetails.Controls.Add(this.btnGotoInsitution);
            this.panDetails.Controls.Add(this.lblInstitutionFachperson);
            this.panDetails.Controls.Add(this.edtKontaktperson);
            this.panDetails.Controls.Add(this.lblSubTitel);
            this.panDetails.Controls.Add(this.edtInstitutionName);
            this.panDetails.Controls.Add(this.lblKontaktperson);
            this.panDetails.Controls.Add(this.lblTelefon);
            this.panDetails.Controls.Add(this.edtBemerkungen);
            this.panDetails.Controls.Add(this.edtAnsprechPersonTel);
            this.panDetails.Controls.Add(this.lblBemerkungen);
            this.panDetails.Controls.Add(this.lblEmail);
            this.panDetails.Controls.Add(this.edtBeziehungZuPerson);
            this.panDetails.Controls.Add(this.edtAnsprechPersonMail);
            this.panDetails.Controls.Add(this.lblBeziehungZuPerson);
            this.panDetails.Controls.Add(this.lblBetrifftPerson);
            this.panDetails.Controls.Add(this.edtBetrifftPerson);
            this.panDetails.Location = new System.Drawing.Point(0, 142);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(749, 148);
            this.panDetails.TabIndex = 2;
            // 
            // btnDatenblatt
            // 
            this.btnDatenblatt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDatenblatt.Context = "BA_InstitutionFachperson";
            this.btnDatenblatt.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.btnDatenblatt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatenblatt.Image = ((System.Drawing.Image)(resources.GetObject("btnDatenblatt.Image")));
            this.btnDatenblatt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDatenblatt.Location = new System.Drawing.Point(650, 115);
            this.btnDatenblatt.Name = "btnDatenblatt";
            this.btnDatenblatt.Size = new System.Drawing.Size(90, 24);
            this.btnDatenblatt.TabIndex = 15;
            this.btnDatenblatt.Text = "Datenblatt";
            this.btnDatenblatt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatenblatt.UseCompatibleTextRendering = true;
            this.btnDatenblatt.UseVisualStyleBackColor = false;
            // 
            // btnGotoInsitution
            // 
            this.btnGotoInsitution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGotoInsitution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGotoInsitution.Location = new System.Drawing.Point(486, 115);
            this.btnGotoInsitution.Name = "btnGotoInsitution";
            this.btnGotoInsitution.Size = new System.Drawing.Size(158, 24);
            this.btnGotoInsitution.TabIndex = 14;
            this.btnGotoInsitution.Text = "> Institutionenstamm";
            this.btnGotoInsitution.UseVisualStyleBackColor = false;
            this.btnGotoInsitution.Click += new System.EventHandler(this.btnGotoInsitution_Click);
            // 
            // CtlBaInstitutionenFachpersonen
            // 
            this.ActiveSQLQuery = this.qryBaPersonInstitution;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(680, 520);
            this.Controls.Add(this.grdInstitutionenFachpersonen);
            this.Controls.Add(this.panDetails);
            this.Controls.Add(this.tabInstitution);
            this.Controls.Add(this.panTitel);
            this.Name = "CtlBaInstitutionenFachpersonen";
            this.Size = new System.Drawing.Size(749, 566);
            this.Load += new System.EventHandler(this.CtlBaInstitutionenFachpersonen_Load);
            this.VisibleChanged += new System.EventHandler(this.CtlBaInstitutionenFachpersonen_VisibleChanged);
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInstitutionenFachpersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPersonInstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInstitutionenFachpersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionFachperson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitutionName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktperson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnsprechPersonTel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnsprechPersonMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrifftPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrifftPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrifftPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeziehungZuPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeziehungZuPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeziehungZuPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubTitel)).EndInit();
            this.tabInstitution.ResumeLayout(false);
            this.tpgAdresse.ResumeLayout(false);
            this.panTblAdresse.ResumeLayout(false);
            this.panAdresseLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInstitution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseTitel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressePostfach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressePostfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressePLZOrtKt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseBezirk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseLand)).EndInit();
            this.panAdresseRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseAbteilung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseSprache.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseSprache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdresseInternet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresseInternet)).EndInit();
            this.tpgKontakt.ResumeLayout(false);
            this.panTblKontakt.ResumeLayout(false);
            this.panKontaktLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktPersonName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktSprache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktSprachCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktSprachCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktPersonVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktGeschlecht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktEMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktEMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktFax.Properties)).EndInit();
            this.panKontaktRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktAnrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontaktAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaInstitutionKontakt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontaktManuelleAnrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktBriefanrede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktBriefanrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontaktAnrede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktTitel.Properties)).EndInit();
            this.tpgAdressTyp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInstTypen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvInstTypen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktperson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInstTypen)).EndInit();
            this.panDetails.ResumeLayout(false);
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

        private KiSS4.Dokument.KissDocumentButton btnDatenblatt;
        private KissButton btnGotoInsitution;
        private KiSS4.Gui.KissCheckEdit chkAktiv;
        private KissCheckEdit chkKontaktAktiv;
        private KissCheckEdit chkKontaktManuelleAnrede;
        private DevExpress.XtraGrid.Columns.GridColumn colAdresse;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrifft;
        private DevExpress.XtraGrid.Columns.GridColumn colBeziehung;
        private DevExpress.XtraGrid.Columns.GridColumn colFall;
        private DevExpress.XtraGrid.Columns.GridColumn colInstTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtAdresseAbteilung;
        private KiSS4.Gui.KissMemoEdit edtAdresseBemerkung;
        private KiSS4.Gui.KissTextEdit edtAdresseEmail;
        private KiSS4.Gui.KissTextEdit edtAdresseFax;
        private KiSS4.Gui.KissTextEdit edtAdresseHausNr;
        private KiSS4.Gui.KissTextEdit edtAdresseInternet;
        private KissMemoEdit edtAdresseName;
        private KiSS4.Common.KissPLZOrt edtAdressePLZOrtKtBezirkLand;
        private KiSS4.Gui.KissTextEdit edtAdressePostfach;
        private KiSS4.Gui.KissTextEdit edtAdresseSprache;
        private KiSS4.Gui.KissTextEdit edtAdresseStrasse;
        private KiSS4.Gui.KissTextEdit edtAdresseTelefon;
        private KiSS4.Gui.KissTextEdit edtAdresseTitel;
        private KiSS4.Gui.KissTextEdit edtAdresseZusatz;
        private KiSS4.Gui.KissTextEdit edtAnsprechPersonMail;
        private KiSS4.Gui.KissTextEdit edtAnsprechPersonTel;
        private KiSS4.Gui.KissMemoEdit edtBemerkungen;
        private KiSS4.Gui.KissLookUpEdit edtBetrifftPerson;
        private KiSS4.Gui.KissLookUpEdit edtBeziehungZuPerson;
        private KiSS4.Gui.KissButtonEdit edtInstitutionName;
        private KissTextEdit edtKontaktAnrede;
        private KissMemoEdit edtKontaktBemerkung;
        private KissTextEdit edtKontaktBriefanrede;
        private KissTextEdit edtKontaktEMail;
        private KissTextEdit edtKontaktFax;
        private KissLookUpEdit edtKontaktGeschlecht;
        private KissTextEdit edtKontaktName;
        private KissLookUpEdit edtKontaktSprachCode;
        private KissTextEdit edtKontaktTelefon;
        private KissTextEdit edtKontaktTitel;
        private KissTextEdit edtKontaktVorname;
        private KissLookUpEdit edtKontaktperson;
        private KissGrid grdInstTypen;
        private KiSS4.Gui.KissGrid grdInstitutionenFachpersonen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvInstTypen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvInstitutionenFachpersonen;
        private KiSS4.Gui.KissLabel lblAdresseAbteilung;
        private KiSS4.Gui.KissLabel lblAdresseBemerkungen;
        private KiSS4.Gui.KissLabel lblAdresseBezirk;
        private KiSS4.Gui.KissLabel lblAdresseEmail;
        private KiSS4.Gui.KissLabel lblAdresseFax;
        private KiSS4.Gui.KissLabel lblAdresseInternet;
        private KiSS4.Gui.KissLabel lblAdresseLand;
        private KiSS4.Gui.KissLabel lblAdresseName;
        private KiSS4.Gui.KissLabel lblAdressePLZOrtKt;
        private KiSS4.Gui.KissLabel lblAdressePostfach;
        private KiSS4.Gui.KissLabel lblAdresseSprache;
        private KiSS4.Gui.KissLabel lblAdresseStrasseNr;
        private KiSS4.Gui.KissLabel lblAdresseTelefon;
        private KiSS4.Gui.KissLabel lblAdresseTitel;
        private KiSS4.Gui.KissLabel lblAdresseZusatz;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBetrifftPerson;
        private KiSS4.Gui.KissLabel lblBeziehungZuPerson;
        private KiSS4.Gui.KissLabel lblEmail;
        private KiSS4.Gui.KissLabel lblInstitutionFachperson;
        private KissLabel lblKontaktAnrede;
        private KissLabel lblKontaktBemerkung;
        private KissLabel lblKontaktBriefanrede;
        private KissLabel lblKontaktEMail;
        private KissLabel lblKontaktFax;
        private KissLabel lblKontaktGeschlecht;
        private KissLabel lblKontaktPersonName;
        private KissLabel lblKontaktPersonVorname;
        private KissLabel lblKontaktSprache;
        private KissLabel lblKontaktTelefon;
        private KissLabel lblKontaktTitel;
        private KiSS4.Gui.KissLabel lblKontaktperson;
        private KiSS4.Gui.KissLabel lblSubTitel;
        private KiSS4.Gui.KissLabel lblTelefon;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.Panel panAdresseLeft;
        private System.Windows.Forms.Panel panAdresseRight;
        private System.Windows.Forms.Panel panDetails;
        private System.Windows.Forms.Panel panKontaktLeft;
        private System.Windows.Forms.Panel panKontaktRight;
        private System.Windows.Forms.TableLayoutPanel panTblAdresse;
        private System.Windows.Forms.TableLayoutPanel panTblKontakt;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private SqlQuery qryBaInstitutionKontakt;
        private KiSS4.DB.SqlQuery qryBaPersonInstitution;
        private SqlQuery qryInstTypen;
        private KiSS4.DB.SqlQuery qryInstitution;
        private KiSS4.Gui.KissTabControlEx tabInstitution;
        private SharpLibrary.WinControls.TabPageEx tpgAdressTyp;
        private SharpLibrary.WinControls.TabPageEx tpgAdresse;
        private SharpLibrary.WinControls.TabPageEx tpgKontakt;
    }
}
