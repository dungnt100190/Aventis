using System;
using System.Drawing;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    /// <summary>
    /// Summary description for CtlVmErbschaftsdienst.
    /// </summary>
    public class CtlVmErbschaftsdienst : KissUserControl
    {
        private System.ComponentModel.IContainer components;
        private KiSS4.Vormundschaft.CtlVmErblasserInfo ctlVmErblasserInfo1;
        private KiSS4.Gui.KissCheckEdit edtAktiv;
        private KiSS4.Gui.KissDateEdit edtAnschriftErbenDatum;
        private KiSS4.Dokument.XDokument edtAnschriftErbenDokID;
        private KiSS4.Gui.KissCheckEdit edtAusschlagung;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCheckEdit edtEl;
        private KiSS4.Gui.KissLookUpEdit edtInventarCode;
        private KiSS4.Gui.KissCalcEdit edtJahr;
        private KiSS4.Gui.KissCheckedLookupEdit edtKopieAnCodes;
        private KiSS4.Gui.KissCalcEdit edtLaufNr;
        private KiSS4.Gui.KissMemoEdit edtMassnahme;
        private KiSS4.Gui.KissCheckedLookupEdit edtMassnahmenCodes;
        private KiSS4.Gui.KissButtonEdit edtNotar;
        private KiSS4.Gui.KissDateEdit edtUeberweisungRSTA;
        private KiSS4.Dokument.XDokument edtUeberweisungRSTADokID;
        private KiSS4.Gui.KissButtonEdit edtUser;
        private KiSS4.Gui.KissCheckEdit edtVertretungsBeistandschaft;
        private KiSS4.Gui.KissLabel lblAnschriftErbenDatum;
        private KiSS4.Gui.KissLabel lblAnschriftErbenDokID;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblInventarCode;
        private KiSS4.Gui.KissLabel lblKopieAnCodes;
        private KiSS4.Gui.KissLabel lblLaufNr;
        private KiSS4.Gui.KissLabel lblMassnahme;
        private KiSS4.Gui.KissLabel lblMassnahmenCodes;
        private KiSS4.Gui.KissLabel lblNotar;
        private System.Windows.Forms.Label lblTitel;
        private KiSS4.Gui.KissLabel lblUeberweisungRSTA;
        private KiSS4.Gui.KissLabel lblUeberweisungRSTADokID;
        private KiSS4.Gui.KissLabel lblUser;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryVmErbschaftsdienst;
        private int VmErbschaftsdienstID = 0;

        public CtlVmErbschaftsdienst()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "BAPERSONID":
                    return DBUtil.ExecuteScalarSQL("SELECT BaPersonID FROM FaLeistung WHERE FaLeistungID = {0}", qryVmErbschaftsdienst["FaLeistungID"]);

                case "FALEISTUNGID":
                    return qryVmErbschaftsdienst["FaLeistungID"];

                case "VMERBSCHAFTSDIENSTID":
                    return this.VmErbschaftsdienstID;

                case "OWNERUSERID":
                    return qryVmErbschaftsdienst["UserID"];
            }

            return base.GetContextValue(FieldName);
        }

        public void Init(string TitleName, Image TitleImage, int VmErbschaftsdienstID)
        {
            this.lblTitel.Text = TitleName;
            this.picTitel.Image = TitleImage;
            this.VmErbschaftsdienstID = VmErbschaftsdienstID;

            qryVmErbschaftsdienst.Fill(@"
				SELECT VED.*,
                       [User] = USR.LastName + isNull(', ' + USR.FirstName,''),
				       Notar = ORG.Name
				FROM VmErbschaftsdienst VED
                  LEFT  JOIN XUser           USR on USR.UserID = VED.UserID
				  LEFT  JOIN BaInstitution   ORG on ORG.BaInstitutionID = VED.InventarNotarID
				WHERE VED.VmErbschaftsdienstID = {0}",
                VmErbschaftsdienstID);

            if (qryVmErbschaftsdienst.Count > 0)
            {
                ctlVmErblasserInfo1.FaLeistungID = (int)qryVmErbschaftsdienst["FaLeistungID"];

                if (DBUtil.IsEmpty(qryVmErbschaftsdienst["LaufNr"]) &&
                    DBUtil.IsEmpty(qryVmErbschaftsdienst["Jahr"]))
                {
                    qryVmErbschaftsdienst["Jahr"] = DateTime.Today.Year;
                    qryVmErbschaftsdienst.RowModified = false;
                }
            }
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVmErbschaftsdienst));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryVmErbschaftsdienst = new KiSS4.DB.SqlQuery(this.components);
            this.lblTitel = new System.Windows.Forms.Label();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtMassnahmenCodes = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblMassnahmenCodes = new KiSS4.Gui.KissLabel();
            this.edtUser = new KiSS4.Gui.KissButtonEdit();
            this.lblUser = new KiSS4.Gui.KissLabel();
            this.lblLaufNr = new KiSS4.Gui.KissLabel();
            this.edtLaufNr = new KiSS4.Gui.KissCalcEdit();
            this.edtJahr = new KiSS4.Gui.KissCalcEdit();
            this.edtMassnahme = new KiSS4.Gui.KissMemoEdit();
            this.lblMassnahme = new KiSS4.Gui.KissLabel();
            this.lblNotar = new KiSS4.Gui.KissLabel();
            this.edtNotar = new KiSS4.Gui.KissButtonEdit();
            this.edtInventarCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblInventarCode = new KiSS4.Gui.KissLabel();
            this.lblAnschriftErbenDokID = new KiSS4.Gui.KissLabel();
            this.edtAnschriftErbenDokID = new KiSS4.Dokument.XDokument();
            this.edtAnschriftErbenDatum = new KiSS4.Gui.KissDateEdit();
            this.lblAnschriftErbenDatum = new KiSS4.Gui.KissLabel();
            this.edtAktiv = new KiSS4.Gui.KissCheckEdit();
            this.edtVertretungsBeistandschaft = new KiSS4.Gui.KissCheckEdit();
            this.edtAusschlagung = new KiSS4.Gui.KissCheckEdit();
            this.edtKopieAnCodes = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblUeberweisungRSTADokID = new KiSS4.Gui.KissLabel();
            this.edtUeberweisungRSTA = new KiSS4.Gui.KissDateEdit();
            this.edtEl = new KiSS4.Gui.KissCheckEdit();
            this.lblKopieAnCodes = new KiSS4.Gui.KissLabel();
            this.lblUeberweisungRSTA = new KiSS4.Gui.KissLabel();
            this.edtUeberweisungRSTADokID = new KiSS4.Dokument.XDokument();
            this.ctlVmErblasserInfo1 = new KiSS4.Vormundschaft.CtlVmErblasserInfo();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmErbschaftsdienst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMassnahmenCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMassnahmenCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLaufNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLaufNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMassnahme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMassnahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNotar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNotar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInventarCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInventarCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInventarCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnschriftErbenDokID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnschriftErbenDokID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnschriftErbenDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnschriftErbenDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVertretungsBeistandschaft.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusschlagung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKopieAnCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeberweisungRSTADokID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberweisungRSTA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKopieAnCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeberweisungRSTA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberweisungRSTADokID.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // qryVmErbschaftsdienst
            //
            this.qryVmErbschaftsdienst.CanUpdate = true;
            this.qryVmErbschaftsdienst.HostControl = this;
            this.qryVmErbschaftsdienst.TableName = "VmErbschaftsdienst";
            this.qryVmErbschaftsdienst.BeforePost += new System.EventHandler(this.qryVmErbschaftsdienst_BeforePost);
            this.qryVmErbschaftsdienst.AfterPost += new System.EventHandler(this.qryVmErbschaftsdienst_AfterPost);
            //
            // lblTitel
            //
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 13;
            this.lblTitel.Text = "Titel";
            //
            // picTitel
            //
            this.picTitel.Image = ((System.Drawing.Image)(resources.GetObject("picTitel.Image")));
            this.picTitel.Location = new System.Drawing.Point(10, 9);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(25, 20);
            this.picTitel.TabIndex = 12;
            this.picTitel.TabStop = false;
            //
            // edtBemerkung
            //
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryVmErbschaftsdienst;
            this.edtBemerkung.Location = new System.Drawing.Point(5, 422);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(703, 73);
            this.edtBemerkung.TabIndex = 18;
            //
            // lblBemerkung
            //
            this.lblBemerkung.Location = new System.Drawing.Point(4, 396);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(299, 24);
            this.lblBemerkung.TabIndex = 80;
            this.lblBemerkung.Text = "Bemerkung und involvierte andere Amsstellen";
            //
            // edtMassnahmenCodes
            //
            this.edtMassnahmenCodes.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtMassnahmenCodes.Appearance.Options.UseBackColor = true;
            this.edtMassnahmenCodes.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.edtMassnahmenCodes.CheckOnClick = true;
            this.edtMassnahmenCodes.DataMember = "MassnahmenCodes";
            this.edtMassnahmenCodes.DataSource = this.qryVmErbschaftsdienst;
            this.edtMassnahmenCodes.Location = new System.Drawing.Point(494, 173);
            this.edtMassnahmenCodes.LOVName = "VmErbschaftMassnahme";
            this.edtMassnahmenCodes.Name = "edtMassnahmenCodes";
            this.edtMassnahmenCodes.Size = new System.Drawing.Size(215, 218);
            this.edtMassnahmenCodes.TabIndex = 17;
            //
            // lblMassnahmenCodes
            //
            this.lblMassnahmenCodes.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblMassnahmenCodes.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblMassnahmenCodes.Location = new System.Drawing.Point(494, 157);
            this.lblMassnahmenCodes.Name = "lblMassnahmenCodes";
            this.lblMassnahmenCodes.Size = new System.Drawing.Size(160, 16);
            this.lblMassnahmenCodes.TabIndex = 82;
            this.lblMassnahmenCodes.Text = "Sicherungsmassnahmen";
            //
            // edtUser
            //
            this.edtUser.DataMember = "User";
            this.edtUser.DataSource = this.qryVmErbschaftsdienst;
            this.edtUser.Location = new System.Drawing.Point(114, 190);
            this.edtUser.Name = "edtUser";
            this.edtUser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUser.Properties.Appearance.Options.UseBackColor = true;
            this.edtUser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUser.Properties.Appearance.Options.UseFont = true;
            this.edtUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtUser.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUser.Size = new System.Drawing.Size(255, 24);
            this.edtUser.TabIndex = 2;
            this.edtUser.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editSAR_UserModifiedFld);
            //
            // lblUser
            //
            this.lblUser.Location = new System.Drawing.Point(5, 190);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(94, 24);
            this.lblUser.TabIndex = 621;
            this.lblUser.Text = "Sachbearbeitung";
            //
            // lblLaufNr
            //
            this.lblLaufNr.Location = new System.Drawing.Point(5, 160);
            this.lblLaufNr.Name = "lblLaufNr";
            this.lblLaufNr.Size = new System.Drawing.Size(84, 24);
            this.lblLaufNr.TabIndex = 624;
            this.lblLaufNr.Text = "LaufNr / Jahr";
            //
            // edtLaufNr
            //
            this.edtLaufNr.DataMember = "LaufNr";
            this.edtLaufNr.DataSource = this.qryVmErbschaftsdienst;
            this.edtLaufNr.Location = new System.Drawing.Point(113, 160);
            this.edtLaufNr.Name = "edtLaufNr";
            this.edtLaufNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtLaufNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLaufNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLaufNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLaufNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtLaufNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLaufNr.Properties.Appearance.Options.UseFont = true;
            this.edtLaufNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLaufNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLaufNr.Properties.DisplayFormat.FormatString = "###########";
            this.edtLaufNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtLaufNr.Properties.EditFormat.FormatString = "###########";
            this.edtLaufNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtLaufNr.Properties.Mask.EditMask = "###########";
            this.edtLaufNr.Size = new System.Drawing.Size(68, 24);
            this.edtLaufNr.TabIndex = 0;
            //
            // edtJahr
            //
            this.edtJahr.DataMember = "Jahr";
            this.edtJahr.DataSource = this.qryVmErbschaftsdienst;
            this.edtJahr.Location = new System.Drawing.Point(189, 160);
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
            this.edtJahr.Properties.DisplayFormat.FormatString = "####";
            this.edtJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtJahr.Properties.EditFormat.FormatString = "####";
            this.edtJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtJahr.Properties.Mask.EditMask = "####";
            this.edtJahr.Size = new System.Drawing.Size(61, 24);
            this.edtJahr.TabIndex = 1;
            //
            // edtMassnahme
            //
            this.edtMassnahme.DataMember = "Massnahme";
            this.edtMassnahme.DataSource = this.qryVmErbschaftsdienst;
            this.edtMassnahme.Location = new System.Drawing.Point(114, 340);
            this.edtMassnahme.Name = "edtMassnahme";
            this.edtMassnahme.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMassnahme.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMassnahme.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMassnahme.Properties.Appearance.Options.UseBackColor = true;
            this.edtMassnahme.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMassnahme.Properties.Appearance.Options.UseFont = true;
            this.edtMassnahme.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMassnahme.Size = new System.Drawing.Size(255, 50);
            this.edtMassnahme.TabIndex = 11;
            //
            // lblMassnahme
            //
            this.lblMassnahme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMassnahme.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblMassnahme.Location = new System.Drawing.Point(5, 341);
            this.lblMassnahme.Name = "lblMassnahme";
            this.lblMassnahme.Size = new System.Drawing.Size(71, 13);
            this.lblMassnahme.TabIndex = 632;
            this.lblMassnahme.Text = "Massnahme";
            //
            // lblNotar
            //
            this.lblNotar.Location = new System.Drawing.Point(5, 280);
            this.lblNotar.Name = "lblNotar";
            this.lblNotar.Size = new System.Drawing.Size(94, 24);
            this.lblNotar.TabIndex = 634;
            this.lblNotar.Text = "Notar";
            //
            // edtNotar
            //
            this.edtNotar.DataMember = "Notar";
            this.edtNotar.DataSource = this.qryVmErbschaftsdienst;
            this.edtNotar.Location = new System.Drawing.Point(114, 280);
            this.edtNotar.Name = "edtNotar";
            this.edtNotar.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNotar.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNotar.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNotar.Properties.Appearance.Options.UseBackColor = true;
            this.edtNotar.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNotar.Properties.Appearance.Options.UseFont = true;
            this.edtNotar.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtNotar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtNotar.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNotar.Size = new System.Drawing.Size(255, 24);
            this.edtNotar.TabIndex = 8;
            this.edtNotar.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editNotar_UserModifiedFld);
            //
            // edtInventarCode
            //
            this.edtInventarCode.DataMember = "InventarCode";
            this.edtInventarCode.DataSource = this.qryVmErbschaftsdienst;
            this.edtInventarCode.Location = new System.Drawing.Point(114, 250);
            this.edtInventarCode.LOVName = "VmErbschaftInventar";
            this.edtInventarCode.Name = "edtInventarCode";
            this.edtInventarCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInventarCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInventarCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInventarCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtInventarCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInventarCode.Properties.Appearance.Options.UseFont = true;
            this.edtInventarCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtInventarCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtInventarCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtInventarCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtInventarCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtInventarCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtInventarCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInventarCode.Properties.NullText = "";
            this.edtInventarCode.Properties.ShowFooter = false;
            this.edtInventarCode.Properties.ShowHeader = false;
            this.edtInventarCode.Size = new System.Drawing.Size(255, 24);
            this.edtInventarCode.TabIndex = 7;
            //
            // lblInventarCode
            //
            this.lblInventarCode.Location = new System.Drawing.Point(5, 250);
            this.lblInventarCode.Name = "lblInventarCode";
            this.lblInventarCode.Size = new System.Drawing.Size(62, 24);
            this.lblInventarCode.TabIndex = 636;
            this.lblInventarCode.Tag = "";
            this.lblInventarCode.Text = "Inventarart";
            //
            // lblAnschriftErbenDokID
            //
            this.lblAnschriftErbenDokID.Location = new System.Drawing.Point(5, 220);
            this.lblAnschriftErbenDokID.Name = "lblAnschriftErbenDokID";
            this.lblAnschriftErbenDokID.Size = new System.Drawing.Size(83, 24);
            this.lblAnschriftErbenDokID.TabIndex = 637;
            this.lblAnschriftErbenDokID.Tag = "";
            this.lblAnschriftErbenDokID.Text = "Anschrift Erben";
            //
            // edtAnschriftErbenDokID
            //
            this.edtAnschriftErbenDokID.AllowDrop = true;
            this.edtAnschriftErbenDokID.Context = "VmErbeAnschriftErben";
            this.edtAnschriftErbenDokID.DataMember = "AnschriftErbenDokID";
            this.edtAnschriftErbenDokID.DataSource = this.qryVmErbschaftsdienst;
            this.edtAnschriftErbenDokID.Location = new System.Drawing.Point(114, 220);
            this.edtAnschriftErbenDokID.Name = "edtAnschriftErbenDokID";
            this.edtAnschriftErbenDokID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnschriftErbenDokID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnschriftErbenDokID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnschriftErbenDokID.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnschriftErbenDokID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnschriftErbenDokID.Properties.Appearance.Options.UseFont = true;
            this.edtAnschriftErbenDokID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtAnschriftErbenDokID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAnschriftErbenDokID.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAnschriftErbenDokID.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAnschriftErbenDokID.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAnschriftErbenDokID.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10, "Dokument importieren")});
            this.edtAnschriftErbenDokID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnschriftErbenDokID.Properties.ReadOnly = true;
            this.edtAnschriftErbenDokID.Size = new System.Drawing.Size(116, 24);
            this.edtAnschriftErbenDokID.TabIndex = 3;
            //
            // edtAnschriftErbenDatum
            //
            this.edtAnschriftErbenDatum.DataMember = "AnschriftErbenDatum";
            this.edtAnschriftErbenDatum.DataSource = this.qryVmErbschaftsdienst;
            this.edtAnschriftErbenDatum.EditValue = null;
            this.edtAnschriftErbenDatum.Location = new System.Drawing.Point(279, 220);
            this.edtAnschriftErbenDatum.Name = "edtAnschriftErbenDatum";
            this.edtAnschriftErbenDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnschriftErbenDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnschriftErbenDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnschriftErbenDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnschriftErbenDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnschriftErbenDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnschriftErbenDatum.Properties.Appearance.Options.UseFont = true;
            this.edtAnschriftErbenDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtAnschriftErbenDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAnschriftErbenDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtAnschriftErbenDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnschriftErbenDatum.Properties.ShowToday = false;
            this.edtAnschriftErbenDatum.Size = new System.Drawing.Size(90, 24);
            this.edtAnschriftErbenDatum.TabIndex = 4;
            //
            // lblAnschriftErbenDatum
            //
            this.lblAnschriftErbenDatum.Location = new System.Drawing.Point(237, 220);
            this.lblAnschriftErbenDatum.Name = "lblAnschriftErbenDatum";
            this.lblAnschriftErbenDatum.Size = new System.Drawing.Size(39, 24);
            this.lblAnschriftErbenDatum.TabIndex = 640;
            this.lblAnschriftErbenDatum.Tag = "";
            this.lblAnschriftErbenDatum.Text = "Datum";
            //
            // edtAktiv
            //
            this.edtAktiv.DataMember = "Aktiv";
            this.edtAktiv.DataSource = this.qryVmErbschaftsdienst;
            this.edtAktiv.Location = new System.Drawing.Point(387, 162);
            this.edtAktiv.Name = "edtAktiv";
            this.edtAktiv.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.edtAktiv.Properties.Caption = "Aktiv";
            this.edtAktiv.Size = new System.Drawing.Size(56, 19);
            this.edtAktiv.TabIndex = 12;
            //
            // edtVertretungsBeistandschaft
            //
            this.edtVertretungsBeistandschaft.DataMember = "VertretungsBeistandschaft";
            this.edtVertretungsBeistandschaft.DataSource = this.qryVmErbschaftsdienst;
            this.edtVertretungsBeistandschaft.Location = new System.Drawing.Point(387, 187);
            this.edtVertretungsBeistandschaft.Name = "edtVertretungsBeistandschaft";
            this.edtVertretungsBeistandschaft.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtVertretungsBeistandschaft.Properties.Appearance.Options.UseBackColor = true;
            this.edtVertretungsBeistandschaft.Properties.Caption = "Vertr.Beistand";
            this.edtVertretungsBeistandschaft.Size = new System.Drawing.Size(96, 19);
            this.edtVertretungsBeistandschaft.TabIndex = 13;
            //
            // edtAusschlagung
            //
            this.edtAusschlagung.DataMember = "Ausschlagung";
            this.edtAusschlagung.DataSource = this.qryVmErbschaftsdienst;
            this.edtAusschlagung.Location = new System.Drawing.Point(387, 212);
            this.edtAusschlagung.Name = "edtAusschlagung";
            this.edtAusschlagung.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtAusschlagung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusschlagung.Properties.Caption = "Ausschlagung";
            this.edtAusschlagung.Size = new System.Drawing.Size(96, 19);
            this.edtAusschlagung.TabIndex = 14;
            //
            // edtKopieAnCodes
            //
            this.edtKopieAnCodes.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtKopieAnCodes.Appearance.Options.UseBackColor = true;
            this.edtKopieAnCodes.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.edtKopieAnCodes.CheckOnClick = true;
            this.edtKopieAnCodes.DataMember = "KopieAnCodes";
            this.edtKopieAnCodes.Location = new System.Drawing.Point(391, 301);
            this.edtKopieAnCodes.LOVName = "VmErbeKopieAn2";
            this.edtKopieAnCodes.Name = "edtKopieAnCodes";
            this.edtKopieAnCodes.Size = new System.Drawing.Size(73, 90);
            this.edtKopieAnCodes.TabIndex = 16;
            //
            // lblUeberweisungRSTADokID
            //
            this.lblUeberweisungRSTADokID.Location = new System.Drawing.Point(5, 310);
            this.lblUeberweisungRSTADokID.Name = "lblUeberweisungRSTADokID";
            this.lblUeberweisungRSTADokID.Size = new System.Drawing.Size(103, 24);
            this.lblUeberweisungRSTADokID.TabIndex = 646;
            this.lblUeberweisungRSTADokID.Text = "Überweisung RSTA";
            //
            // edtUeberweisungRSTA
            //
            this.edtUeberweisungRSTA.DataMember = "UeberweisungRSTA";
            this.edtUeberweisungRSTA.DataSource = this.qryVmErbschaftsdienst;
            this.edtUeberweisungRSTA.EditValue = null;
            this.edtUeberweisungRSTA.Location = new System.Drawing.Point(279, 310);
            this.edtUeberweisungRSTA.Name = "edtUeberweisungRSTA";
            this.edtUeberweisungRSTA.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUeberweisungRSTA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUeberweisungRSTA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUeberweisungRSTA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUeberweisungRSTA.Properties.Appearance.Options.UseBackColor = true;
            this.edtUeberweisungRSTA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUeberweisungRSTA.Properties.Appearance.Options.UseFont = true;
            this.edtUeberweisungRSTA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtUeberweisungRSTA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtUeberweisungRSTA.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtUeberweisungRSTA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUeberweisungRSTA.Properties.ShowToday = false;
            this.edtUeberweisungRSTA.Size = new System.Drawing.Size(90, 24);
            this.edtUeberweisungRSTA.TabIndex = 10;
            //
            // edtEl
            //
            this.edtEl.DataMember = "El";
            this.edtEl.DataSource = this.qryVmErbschaftsdienst;
            this.edtEl.Location = new System.Drawing.Point(387, 237);
            this.edtEl.Name = "edtEl";
            this.edtEl.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtEl.Properties.Appearance.Options.UseBackColor = true;
            this.edtEl.Properties.Caption = "El";
            this.edtEl.Size = new System.Drawing.Size(96, 19);
            this.edtEl.TabIndex = 15;
            //
            // lblKopieAnCodes
            //
            this.lblKopieAnCodes.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblKopieAnCodes.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblKopieAnCodes.Location = new System.Drawing.Point(391, 284);
            this.lblKopieAnCodes.Name = "lblKopieAnCodes";
            this.lblKopieAnCodes.Size = new System.Drawing.Size(66, 16);
            this.lblKopieAnCodes.TabIndex = 647;
            this.lblKopieAnCodes.Text = "Kopie SP an";
            //
            // lblUeberweisungRSTA
            //
            this.lblUeberweisungRSTA.Location = new System.Drawing.Point(237, 310);
            this.lblUeberweisungRSTA.Name = "lblUeberweisungRSTA";
            this.lblUeberweisungRSTA.Size = new System.Drawing.Size(39, 24);
            this.lblUeberweisungRSTA.TabIndex = 648;
            this.lblUeberweisungRSTA.Tag = "";
            this.lblUeberweisungRSTA.Text = "Datum";
            //
            // edtUeberweisungRSTADokID
            //
            this.edtUeberweisungRSTADokID.AllowDrop = true;
            this.edtUeberweisungRSTADokID.Context = "VmErbeUeberweisungRSTA";
            this.edtUeberweisungRSTADokID.DataMember = "UeberweisungRSTADokID";
            this.edtUeberweisungRSTADokID.DataSource = this.qryVmErbschaftsdienst;
            this.edtUeberweisungRSTADokID.Location = new System.Drawing.Point(114, 310);
            this.edtUeberweisungRSTADokID.Name = "edtUeberweisungRSTADokID";
            this.edtUeberweisungRSTADokID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUeberweisungRSTADokID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUeberweisungRSTADokID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUeberweisungRSTADokID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUeberweisungRSTADokID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUeberweisungRSTADokID.Properties.Appearance.Options.UseFont = true;
            this.edtUeberweisungRSTADokID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtUeberweisungRSTADokID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtUeberweisungRSTADokID.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtUeberweisungRSTADokID.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtUeberweisungRSTADokID.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtUeberweisungRSTADokID.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument importieren")});
            this.edtUeberweisungRSTADokID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUeberweisungRSTADokID.Properties.ReadOnly = true;
            this.edtUeberweisungRSTADokID.Size = new System.Drawing.Size(116, 24);
            this.edtUeberweisungRSTADokID.TabIndex = 9;
            //
            // ctlVmErblasserInfo1
            //
            this.ctlVmErblasserInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlVmErblasserInfo1.FaLeistungID = 0;
            this.ctlVmErblasserInfo1.Location = new System.Drawing.Point(5, 34);
            this.ctlVmErblasserInfo1.Name = "ctlVmErblasserInfo1";
            this.ctlVmErblasserInfo1.Size = new System.Drawing.Size(705, 120);
            this.ctlVmErblasserInfo1.TabIndex = 620;
            //
            // CtlVmErbschaftsdienst
            //
            this.ActiveSQLQuery = this.qryVmErbschaftsdienst;

            this.Controls.Add(this.edtUeberweisungRSTADokID);
            this.Controls.Add(this.lblUeberweisungRSTA);
            this.Controls.Add(this.lblKopieAnCodes);
            this.Controls.Add(this.edtEl);
            this.Controls.Add(this.edtUeberweisungRSTA);
            this.Controls.Add(this.lblUeberweisungRSTADokID);
            this.Controls.Add(this.edtKopieAnCodes);
            this.Controls.Add(this.edtAusschlagung);
            this.Controls.Add(this.edtVertretungsBeistandschaft);
            this.Controls.Add(this.edtAktiv);
            this.Controls.Add(this.lblAnschriftErbenDatum);
            this.Controls.Add(this.edtAnschriftErbenDatum);
            this.Controls.Add(this.edtAnschriftErbenDokID);
            this.Controls.Add(this.lblAnschriftErbenDokID);
            this.Controls.Add(this.edtInventarCode);
            this.Controls.Add(this.lblInventarCode);
            this.Controls.Add(this.lblNotar);
            this.Controls.Add(this.edtNotar);
            this.Controls.Add(this.lblMassnahme);
            this.Controls.Add(this.edtMassnahme);
            this.Controls.Add(this.edtJahr);
            this.Controls.Add(this.edtLaufNr);
            this.Controls.Add(this.lblLaufNr);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.ctlVmErblasserInfo1);
            this.Controls.Add(this.edtUser);
            this.Controls.Add(this.edtMassnahmenCodes);
            this.Controls.Add(this.lblMassnahmenCodes);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlVmErbschaftsdienst";
            this.Size = new System.Drawing.Size(733, 525);
            ((System.ComponentModel.ISupportInitialize)(this.qryVmErbschaftsdienst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMassnahmenCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMassnahmenCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLaufNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLaufNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMassnahme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMassnahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNotar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNotar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInventarCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInventarCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInventarCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnschriftErbenDokID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnschriftErbenDokID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnschriftErbenDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnschriftErbenDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVertretungsBeistandschaft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusschlagung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKopieAnCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeberweisungRSTADokID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberweisungRSTA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKopieAnCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeberweisungRSTA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUeberweisungRSTADokID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private void editNotar_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.InstitutionSuchen(edtNotar.Text, 19, true, e.ButtonClicked); //nur Notare
            if (!e.Cancel)
            {
                qryVmErbschaftsdienst["InventarNotarID"] = dlg["BaInstitutionID"];
                qryVmErbschaftsdienst["Notar"] = dlg["Name"];
            }
        }

        private void editSAR_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtUser.Text, ModulID.V, e.ButtonClicked);
            if (!e.Cancel)
            {
                qryVmErbschaftsdienst["UserID"] = dlg["UserID"];
                qryVmErbschaftsdienst["User"] = dlg["Name"];
            }
        }

        private void qryVmErbschaftsdienst_AfterPost(object sender, System.EventArgs e)
        {
            ctlVmErblasserInfo1.FaLeistungID = (int)qryVmErbschaftsdienst["FaLeistungID"];
        }

        private void qryVmErbschaftsdienst_BeforePost(object sender, System.EventArgs e)
        {
            if (DBUtil.IsEmpty(qryVmErbschaftsdienst["LaufNr"]) && !DBUtil.IsEmpty(qryVmErbschaftsdienst["Jahr"]))
            {
                qryVmErbschaftsdienst["LaufNr"] = DBUtil.ExecuteScalarSQL(@"
					SELECT isNull(max(LaufNr) + 1,1)
					FROM VmErbschaftsdienst
					WHERE Jahr = {0}",
                    qryVmErbschaftsdienst["Jahr"]);
            }
        }
    }
}