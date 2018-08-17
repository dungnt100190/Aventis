using System;
using System.Drawing;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    /// <summary>
    /// Summary description for CtlVmSiegelung.
    /// </summary>
    public class CtlVmSiegelung : KissUserControl
    {
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissCheckEdit edtAusschlagung;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCalcEdit edtBezirkNr;
        private KiSS4.Gui.KissCalcEdit edtDurchsuchungen;
        private KiSS4.Gui.KissDateEdit edtEntsiegelungsDatum;
        private KiSS4.Gui.KissCheckEdit edtGesuchUeBestattung;
        private KiSS4.Gui.KissCalcEdit edtJahr;
        private KiSS4.Gui.KissTextEdit edtKopieAndere;
        private KiSS4.Gui.KissCheckEdit edtKopieErbschaftsdienst;
        private KiSS4.Gui.KissCheckEdit edtKopieTestamentsdienst;
        private KiSS4.Gui.KissCalcEdit edtLaufNr;
        private KiSS4.Gui.KissTextEdit edtMassaVerwalter;
        private KiSS4.Gui.KissButtonEdit edtNotar;
        private KiSS4.Gui.KissCheckEdit edtOhneGebuehr;
        private KiSS4.Gui.KissTextEdit edtPliQuittung;
        private KiSS4.Gui.KissMemoEdit edtRechnungAn;
        private KiSS4.Gui.KissCalcEdit edtRechnungsBetrag;
        private KiSS4.Gui.KissDateEdit edtRechnungsDatum;
        private KiSS4.Gui.KissTextEdit edtRechnungsNr;
        private KiSS4.Gui.KissCheckEdit edtSDabgeschlossen;
        private KiSS4.Gui.KissDateEdit edtSiegelungsDatum;
        private KiSS4.Gui.KissCheckEdit edtSiegelungsFristEingehalten;
        private KiSS4.Gui.KissDateEdit edtTodesmeldungDatum;
        private KiSS4.Gui.KissButtonEdit edtUser;
        private KiSS4.Gui.KissCalcEdit edtVerfuegungsSperren;
        private KiSS4.Gui.KissDateEdit edtVersandDatum;
        private KiSS4.Dokument.XDokument edtVmErbeSiegelungsprotokoll;
        private KiSS4.Gui.KissLookUpEdit edtVmErbschaftInventarCode;
        private KiSS4.Dokument.KissDocumentButton kissDocumentButton1;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel43;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel56;
        private KiSS4.Gui.KissLabel kissLabel57;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblDurchsuchungen;
        private KiSS4.Gui.KissLabel lblEntsiegelungsDatum;
        private KiSS4.Gui.KissLabel lblKopieAndere;
        private KiSS4.Gui.KissLabel lblMassaVerwalter;
        private KiSS4.Gui.KissLabel lblNotar;
        private KiSS4.Gui.KissLabel lblPliQuittung;
        private KiSS4.Gui.KissLabel lblRechnungAn;
        private KiSS4.Gui.KissLabel lblRechnungsBetrag;
        private KiSS4.Gui.KissLabel lblRechnungsDatum;
        private KiSS4.Gui.KissLabel lblRechnungsNr;
        private KiSS4.Gui.KissLabel lblSiegelungsDatum;
        private System.Windows.Forms.Label lblTitel;
        private KiSS4.Gui.KissLabel lblTodesmeldungDatum;
        private KiSS4.Gui.KissLabel lblUser;
        private KiSS4.Gui.KissLabel lblVerfuegungsSperren;
        private KiSS4.Gui.KissLabel lblVersandDatum;
        private KiSS4.Gui.KissLabel lblVmErbeSiegelungsprotokoll;
        private KiSS4.Gui.KissLabel lblVmErbschaftInventarCode;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryVmSiegelung;
        private int VmSiegelungID = 0;

        public CtlVmSiegelung()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "BAPERSONID":
                    return (int)DBUtil.ExecuteScalarSQL("SELECT BaPersonID FROM FaLeistung WHERE FaLeistungID = {0}", qryVmSiegelung["FaLeistungID"]);

                case "FALEISTUNGID":
                    return qryVmSiegelung["FaLeistungID"];

                case "VMSIEGELUNGID":
                    return this.VmSiegelungID;

                case "OWNERUSERID":
                    return qryVmSiegelung["UserID"];
            }
            return base.GetContextValue(FieldName);
        }

        public void Init(string TitleName, Image TitleImage, int VmSiegelungID)
        {
            this.lblTitel.Text = TitleName;
            this.picTitel.Image = TitleImage;
            this.VmSiegelungID = VmSiegelungID;

            qryVmSiegelung.Fill(@"
				SELECT VSI.*,
                       [User] = USR.LastName + isNull(', ' + USR.FirstName,''),
				       Notar  = INS.Name
				FROM VmSiegelung VSI
                  LEFT JOIN XUser         USR ON USR.UserID = VSI.UserID
				  LEFT JOIN BaInstitution INS ON INS.BaInstitutionID = VSI.NotarID
				WHERE  VSI.VmSiegelungID = {0}",
                VmSiegelungID);

            if (qryVmSiegelung.Count > 0)
            {
                qryVmSiegelung.EnableBoundFields(!(bool)qryVmSiegelung["Gesperrt"]);

                if (DBUtil.IsEmpty(qryVmSiegelung["LaufNr"]) &&
                    DBUtil.IsEmpty(qryVmSiegelung["BezirkNr"]) &&
                    DBUtil.IsEmpty(qryVmSiegelung["Jahr"]))
                {
                    qryVmSiegelung["Jahr"] = DateTime.Today.Year;
                    qryVmSiegelung.RowModified = false;
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVmSiegelung));
            this.qryVmSiegelung = new KiSS4.DB.SqlQuery(this.components);
            this.lblTitel = new System.Windows.Forms.Label();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblUser = new KiSS4.Gui.KissLabel();
            this.edtVmErbeSiegelungsprotokoll = new KiSS4.Dokument.XDokument();
            this.lblVmErbeSiegelungsprotokoll = new KiSS4.Gui.KissLabel();
            this.kissLabel43 = new KiSS4.Gui.KissLabel();
            this.edtTodesmeldungDatum = new KiSS4.Gui.KissDateEdit();
            this.lblTodesmeldungDatum = new KiSS4.Gui.KissLabel();
            this.edtSiegelungsDatum = new KiSS4.Gui.KissDateEdit();
            this.lblSiegelungsDatum = new KiSS4.Gui.KissLabel();
            this.edtKopieErbschaftsdienst = new KiSS4.Gui.KissCheckEdit();
            this.edtKopieTestamentsdienst = new KiSS4.Gui.KissCheckEdit();
            this.edtGesuchUeBestattung = new KiSS4.Gui.KissCheckEdit();
            this.edtAusschlagung = new KiSS4.Gui.KissCheckEdit();
            this.edtSDabgeschlossen = new KiSS4.Gui.KissCheckEdit();
            this.edtOhneGebuehr = new KiSS4.Gui.KissCheckEdit();
            this.edtVersandDatum = new KiSS4.Gui.KissDateEdit();
            this.lblVersandDatum = new KiSS4.Gui.KissLabel();
            this.edtKopieAndere = new KiSS4.Gui.KissTextEdit();
            this.lblKopieAndere = new KiSS4.Gui.KissLabel();
            this.edtVerfuegungsSperren = new KiSS4.Gui.KissCalcEdit();
            this.lblVerfuegungsSperren = new KiSS4.Gui.KissLabel();
            this.edtDurchsuchungen = new KiSS4.Gui.KissCalcEdit();
            this.lblDurchsuchungen = new KiSS4.Gui.KissLabel();
            this.edtPliQuittung = new KiSS4.Gui.KissTextEdit();
            this.lblPliQuittung = new KiSS4.Gui.KissLabel();
            this.edtVmErbschaftInventarCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblVmErbschaftInventarCode = new KiSS4.Gui.KissLabel();
            this.lblNotar = new KiSS4.Gui.KissLabel();
            this.edtMassaVerwalter = new KiSS4.Gui.KissTextEdit();
            this.lblMassaVerwalter = new KiSS4.Gui.KissLabel();
            this.edtEntsiegelungsDatum = new KiSS4.Gui.KissDateEdit();
            this.lblEntsiegelungsDatum = new KiSS4.Gui.KissLabel();
            this.kissLabel56 = new KiSS4.Gui.KissLabel();
            this.kissLabel57 = new KiSS4.Gui.KissLabel();
            this.edtRechnungsBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblRechnungsBetrag = new KiSS4.Gui.KissLabel();
            this.edtRechnungsDatum = new KiSS4.Gui.KissDateEdit();
            this.lblRechnungsDatum = new KiSS4.Gui.KissLabel();
            this.edtRechnungsNr = new KiSS4.Gui.KissTextEdit();
            this.lblRechnungsNr = new KiSS4.Gui.KissLabel();
            this.lblRechnungAn = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.edtRechnungAn = new KiSS4.Gui.KissMemoEdit();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.edtUser = new KiSS4.Gui.KissButtonEdit();
            this.edtBezirkNr = new KiSS4.Gui.KissCalcEdit();
            this.edtJahr = new KiSS4.Gui.KissCalcEdit();
            this.edtLaufNr = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.edtSiegelungsFristEingehalten = new KiSS4.Gui.KissCheckEdit();
            this.edtNotar = new KiSS4.Gui.KissButtonEdit();
            this.kissDocumentButton1 = new KiSS4.Dokument.KissDocumentButton();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmSiegelung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmErbeSiegelungsprotokoll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVmErbeSiegelungsprotokoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTodesmeldungDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTodesmeldungDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSiegelungsDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSiegelungsDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKopieErbschaftsdienst.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKopieTestamentsdienst.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesuchUeBestattung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusschlagung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSDabgeschlossen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOhneGebuehr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersandDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersandDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKopieAndere.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKopieAndere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerfuegungsSperren.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerfuegungsSperren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDurchsuchungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDurchsuchungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPliQuittung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPliQuittung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmErbschaftInventarCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmErbschaftInventarCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVmErbschaftInventarCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNotar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMassaVerwalter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMassaVerwalter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEntsiegelungsDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEntsiegelungsDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungAn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezirkNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLaufNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSiegelungsFristEingehalten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNotar.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // qryVmSiegelung
            //
            this.qryVmSiegelung.CanUpdate = true;
            this.qryVmSiegelung.HostControl = this;
            this.qryVmSiegelung.TableName = "VmSiegelung";
            this.qryVmSiegelung.BeforePost += new System.EventHandler(this.qryVmSiegelung_BeforePost);
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
            // lblUser
            //
            this.lblUser.Location = new System.Drawing.Point(5, 40);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(96, 24);
            this.lblUser.TabIndex = 43;
            this.lblUser.Text = "Siegelungsbeamter";
            //
            // edtVmErbeSiegelungsprotokoll
            //
            this.edtVmErbeSiegelungsprotokoll.AllowDrop = true;
            this.edtVmErbeSiegelungsprotokoll.Context = "VmErbeSiegelungsprotokoll";
            this.edtVmErbeSiegelungsprotokoll.DataMember = "SiegelungsProtokollDokID";
            this.edtVmErbeSiegelungsprotokoll.DataSource = this.qryVmSiegelung;
            this.edtVmErbeSiegelungsprotokoll.Location = new System.Drawing.Point(545, 40);
            this.edtVmErbeSiegelungsprotokoll.Name = "edtVmErbeSiegelungsprotokoll";
            this.edtVmErbeSiegelungsprotokoll.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVmErbeSiegelungsprotokoll.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVmErbeSiegelungsprotokoll.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVmErbeSiegelungsprotokoll.Properties.Appearance.Options.UseBackColor = true;
            this.edtVmErbeSiegelungsprotokoll.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVmErbeSiegelungsprotokoll.Properties.Appearance.Options.UseFont = true;
            this.edtVmErbeSiegelungsprotokoll.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtVmErbeSiegelungsprotokoll.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVmErbeSiegelungsprotokoll.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVmErbeSiegelungsprotokoll.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVmErbeSiegelungsprotokoll.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVmErbeSiegelungsprotokoll.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12, "Dokument importieren")});
            this.edtVmErbeSiegelungsprotokoll.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVmErbeSiegelungsprotokoll.Properties.ReadOnly = true;
            this.edtVmErbeSiegelungsprotokoll.Size = new System.Drawing.Size(127, 24);
            this.edtVmErbeSiegelungsprotokoll.TabIndex = 20;
            //
            // lblVmErbeSiegelungsprotokoll
            //
            this.lblVmErbeSiegelungsprotokoll.Location = new System.Drawing.Point(494, 40);
            this.lblVmErbeSiegelungsprotokoll.Name = "lblVmErbeSiegelungsprotokoll";
            this.lblVmErbeSiegelungsprotokoll.Size = new System.Drawing.Size(48, 24);
            this.lblVmErbeSiegelungsprotokoll.TabIndex = 52;
            this.lblVmErbeSiegelungsprotokoll.Text = "Protokoll";
            //
            // kissLabel43
            //
            this.kissLabel43.Location = new System.Drawing.Point(5, 70);
            this.kissLabel43.Name = "kissLabel43";
            this.kissLabel43.Size = new System.Drawing.Size(107, 24);
            this.kissLabel43.TabIndex = 55;
            this.kissLabel43.Text = "Bezirk-LaufNr-Jahr";
            //
            // edtTodesmeldungDatum
            //
            this.edtTodesmeldungDatum.DataMember = "TodesmeldungDatum";
            this.edtTodesmeldungDatum.DataSource = this.qryVmSiegelung;
            this.edtTodesmeldungDatum.EditValue = null;
            this.edtTodesmeldungDatum.Location = new System.Drawing.Point(111, 100);
            this.edtTodesmeldungDatum.Name = "edtTodesmeldungDatum";
            this.edtTodesmeldungDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTodesmeldungDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTodesmeldungDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTodesmeldungDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTodesmeldungDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtTodesmeldungDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTodesmeldungDatum.Properties.Appearance.Options.UseFont = true;
            this.edtTodesmeldungDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtTodesmeldungDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtTodesmeldungDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtTodesmeldungDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTodesmeldungDatum.Properties.ShowToday = false;
            this.edtTodesmeldungDatum.Size = new System.Drawing.Size(90, 24);
            this.edtTodesmeldungDatum.TabIndex = 4;
            //
            // lblTodesmeldungDatum
            //
            this.lblTodesmeldungDatum.Location = new System.Drawing.Point(5, 100);
            this.lblTodesmeldungDatum.Name = "lblTodesmeldungDatum";
            this.lblTodesmeldungDatum.Size = new System.Drawing.Size(82, 24);
            this.lblTodesmeldungDatum.TabIndex = 94;
            this.lblTodesmeldungDatum.Text = "Todesmeldung";
            //
            // edtSiegelungsDatum
            //
            this.edtSiegelungsDatum.DataMember = "SiegelungsDatum";
            this.edtSiegelungsDatum.DataSource = this.qryVmSiegelung;
            this.edtSiegelungsDatum.EditValue = null;
            this.edtSiegelungsDatum.Location = new System.Drawing.Point(111, 130);
            this.edtSiegelungsDatum.Name = "edtSiegelungsDatum";
            this.edtSiegelungsDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSiegelungsDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSiegelungsDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSiegelungsDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSiegelungsDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtSiegelungsDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSiegelungsDatum.Properties.Appearance.Options.UseFont = true;
            this.edtSiegelungsDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSiegelungsDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSiegelungsDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSiegelungsDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSiegelungsDatum.Properties.ShowToday = false;
            this.edtSiegelungsDatum.Size = new System.Drawing.Size(90, 24);
            this.edtSiegelungsDatum.TabIndex = 5;
            //
            // lblSiegelungsDatum
            //
            this.lblSiegelungsDatum.Location = new System.Drawing.Point(5, 130);
            this.lblSiegelungsDatum.Name = "lblSiegelungsDatum";
            this.lblSiegelungsDatum.Size = new System.Drawing.Size(92, 24);
            this.lblSiegelungsDatum.TabIndex = 93;
            this.lblSiegelungsDatum.Text = "Siegelungsdatum";
            //
            // edtKopieErbschaftsdienst
            //
            this.edtKopieErbschaftsdienst.DataMember = "KopieErbschaftsdienst";
            this.edtKopieErbschaftsdienst.DataSource = this.qryVmSiegelung;
            this.edtKopieErbschaftsdienst.Location = new System.Drawing.Point(244, 173);
            this.edtKopieErbschaftsdienst.Name = "edtKopieErbschaftsdienst";
            this.edtKopieErbschaftsdienst.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtKopieErbschaftsdienst.Properties.Appearance.Options.UseBackColor = true;
            this.edtKopieErbschaftsdienst.Properties.Caption = "Erbschaftsdienst";
            this.edtKopieErbschaftsdienst.Size = new System.Drawing.Size(109, 19);
            this.edtKopieErbschaftsdienst.TabIndex = 8;
            //
            // edtKopieTestamentsdienst
            //
            this.edtKopieTestamentsdienst.DataMember = "KopieTestamentsdienst";
            this.edtKopieTestamentsdienst.DataSource = this.qryVmSiegelung;
            this.edtKopieTestamentsdienst.Location = new System.Drawing.Point(348, 173);
            this.edtKopieTestamentsdienst.Name = "edtKopieTestamentsdienst";
            this.edtKopieTestamentsdienst.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtKopieTestamentsdienst.Properties.Appearance.Options.UseBackColor = true;
            this.edtKopieTestamentsdienst.Properties.Caption = "Testamentsdienst";
            this.edtKopieTestamentsdienst.Size = new System.Drawing.Size(112, 19);
            this.edtKopieTestamentsdienst.TabIndex = 9;
            //
            // edtGesuchUeBestattung
            //
            this.edtGesuchUeBestattung.DataMember = "GesuchUeBestattung";
            this.edtGesuchUeBestattung.DataSource = this.qryVmSiegelung;
            this.edtGesuchUeBestattung.Location = new System.Drawing.Point(111, 334);
            this.edtGesuchUeBestattung.Name = "edtGesuchUeBestattung";
            this.edtGesuchUeBestattung.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtGesuchUeBestattung.Properties.Appearance.Options.UseBackColor = true;
            this.edtGesuchUeBestattung.Properties.Caption = "Gesuch ue Bestattung";
            this.edtGesuchUeBestattung.Size = new System.Drawing.Size(135, 19);
            this.edtGesuchUeBestattung.TabIndex = 14;
            //
            // edtAusschlagung
            //
            this.edtAusschlagung.DataMember = "Ausschlagung";
            this.edtAusschlagung.DataSource = this.qryVmSiegelung;
            this.edtAusschlagung.Location = new System.Drawing.Point(250, 334);
            this.edtAusschlagung.Name = "edtAusschlagung";
            this.edtAusschlagung.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtAusschlagung.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusschlagung.Properties.Caption = "Ausschlagung";
            this.edtAusschlagung.Size = new System.Drawing.Size(95, 19);
            this.edtAusschlagung.TabIndex = 15;
            //
            // edtSDabgeschlossen
            //
            this.edtSDabgeschlossen.DataMember = "SDabgeschlossen";
            this.edtSDabgeschlossen.DataSource = this.qryVmSiegelung;
            this.edtSDabgeschlossen.Location = new System.Drawing.Point(492, 323);
            this.edtSDabgeschlossen.Name = "edtSDabgeschlossen";
            this.edtSDabgeschlossen.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSDabgeschlossen.Properties.Appearance.Options.UseBackColor = true;
            this.edtSDabgeschlossen.Properties.Caption = "SD abgeschlossen";
            this.edtSDabgeschlossen.Size = new System.Drawing.Size(139, 19);
            this.edtSDabgeschlossen.TabIndex = 27;
            //
            // edtOhneGebuehr
            //
            this.edtOhneGebuehr.DataMember = "OhneGebuehr";
            this.edtOhneGebuehr.DataSource = this.qryVmSiegelung;
            this.edtOhneGebuehr.Location = new System.Drawing.Point(654, 134);
            this.edtOhneGebuehr.Name = "edtOhneGebuehr";
            this.edtOhneGebuehr.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtOhneGebuehr.Properties.Appearance.Options.UseBackColor = true;
            this.edtOhneGebuehr.Properties.Caption = "Ohne Gebühr";
            this.edtOhneGebuehr.Size = new System.Drawing.Size(95, 19);
            this.edtOhneGebuehr.TabIndex = 23;
            //
            // edtVersandDatum
            //
            this.edtVersandDatum.DataMember = "VersandDatum";
            this.edtVersandDatum.DataSource = this.qryVmSiegelung;
            this.edtVersandDatum.EditValue = null;
            this.edtVersandDatum.Location = new System.Drawing.Point(111, 170);
            this.edtVersandDatum.Name = "edtVersandDatum";
            this.edtVersandDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVersandDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVersandDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersandDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersandDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersandDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersandDatum.Properties.Appearance.Options.UseFont = true;
            this.edtVersandDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtVersandDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVersandDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtVersandDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVersandDatum.Properties.ShowToday = false;
            this.edtVersandDatum.Size = new System.Drawing.Size(90, 24);
            this.edtVersandDatum.TabIndex = 7;
            //
            // lblVersandDatum
            //
            this.lblVersandDatum.Location = new System.Drawing.Point(5, 170);
            this.lblVersandDatum.Name = "lblVersandDatum";
            this.lblVersandDatum.Size = new System.Drawing.Size(82, 24);
            this.lblVersandDatum.TabIndex = 106;
            this.lblVersandDatum.Text = "Versanddatum";
            //
            // edtKopieAndere
            //
            this.edtKopieAndere.DataMember = "KopieAndere";
            this.edtKopieAndere.DataSource = this.qryVmSiegelung;
            this.edtKopieAndere.Location = new System.Drawing.Point(111, 200);
            this.edtKopieAndere.Name = "edtKopieAndere";
            this.edtKopieAndere.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKopieAndere.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKopieAndere.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKopieAndere.Properties.Appearance.Options.UseBackColor = true;
            this.edtKopieAndere.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKopieAndere.Properties.Appearance.Options.UseFont = true;
            this.edtKopieAndere.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKopieAndere.Size = new System.Drawing.Size(342, 24);
            this.edtKopieAndere.TabIndex = 10;
            //
            // lblKopieAndere
            //
            this.lblKopieAndere.Location = new System.Drawing.Point(5, 200);
            this.lblKopieAndere.Name = "lblKopieAndere";
            this.lblKopieAndere.Size = new System.Drawing.Size(99, 24);
            this.lblKopieAndere.TabIndex = 108;
            this.lblKopieAndere.Text = "Kopie andere Amtst.";
            //
            // edtVerfuegungsSperren
            //
            this.edtVerfuegungsSperren.DataMember = "VerfuegungsSperren";
            this.edtVerfuegungsSperren.DataSource = this.qryVmSiegelung;
            this.edtVerfuegungsSperren.Location = new System.Drawing.Point(111, 240);
            this.edtVerfuegungsSperren.Name = "edtVerfuegungsSperren";
            this.edtVerfuegungsSperren.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerfuegungsSperren.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerfuegungsSperren.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerfuegungsSperren.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerfuegungsSperren.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerfuegungsSperren.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerfuegungsSperren.Properties.Appearance.Options.UseFont = true;
            this.edtVerfuegungsSperren.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVerfuegungsSperren.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerfuegungsSperren.Size = new System.Drawing.Size(61, 24);
            this.edtVerfuegungsSperren.TabIndex = 11;
            //
            // lblVerfuegungsSperren
            //
            this.lblVerfuegungsSperren.Location = new System.Drawing.Point(5, 240);
            this.lblVerfuegungsSperren.Name = "lblVerfuegungsSperren";
            this.lblVerfuegungsSperren.Size = new System.Drawing.Size(101, 24);
            this.lblVerfuegungsSperren.TabIndex = 113;
            this.lblVerfuegungsSperren.Tag = "";
            this.lblVerfuegungsSperren.Text = "Verfügungssperren";
            //
            // edtDurchsuchungen
            //
            this.edtDurchsuchungen.DataMember = "Durchsuchungen";
            this.edtDurchsuchungen.DataSource = this.qryVmSiegelung;
            this.edtDurchsuchungen.Location = new System.Drawing.Point(111, 270);
            this.edtDurchsuchungen.Name = "edtDurchsuchungen";
            this.edtDurchsuchungen.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDurchsuchungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDurchsuchungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDurchsuchungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDurchsuchungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtDurchsuchungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDurchsuchungen.Properties.Appearance.Options.UseFont = true;
            this.edtDurchsuchungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDurchsuchungen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDurchsuchungen.Size = new System.Drawing.Size(61, 24);
            this.edtDurchsuchungen.TabIndex = 12;
            //
            // lblDurchsuchungen
            //
            this.lblDurchsuchungen.Location = new System.Drawing.Point(5, 270);
            this.lblDurchsuchungen.Name = "lblDurchsuchungen";
            this.lblDurchsuchungen.Size = new System.Drawing.Size(82, 24);
            this.lblDurchsuchungen.TabIndex = 115;
            this.lblDurchsuchungen.Tag = "";
            this.lblDurchsuchungen.Text = "Durchsuchung";
            //
            // edtPliQuittung
            //
            this.edtPliQuittung.DataMember = "PliQuittung";
            this.edtPliQuittung.DataSource = this.qryVmSiegelung;
            this.edtPliQuittung.Location = new System.Drawing.Point(111, 300);
            this.edtPliQuittung.Name = "edtPliQuittung";
            this.edtPliQuittung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPliQuittung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPliQuittung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPliQuittung.Properties.Appearance.Options.UseBackColor = true;
            this.edtPliQuittung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPliQuittung.Properties.Appearance.Options.UseFont = true;
            this.edtPliQuittung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPliQuittung.Size = new System.Drawing.Size(237, 24);
            this.edtPliQuittung.TabIndex = 13;
            //
            // lblPliQuittung
            //
            this.lblPliQuittung.Location = new System.Drawing.Point(5, 300);
            this.lblPliQuittung.Name = "lblPliQuittung";
            this.lblPliQuittung.Size = new System.Drawing.Size(69, 24);
            this.lblPliQuittung.TabIndex = 117;
            this.lblPliQuittung.Text = "Pli-Quittung";
            //
            // edtVmErbschaftInventarCode
            //
            this.edtVmErbschaftInventarCode.DataMember = "VmErbschaftInventarCode";
            this.edtVmErbschaftInventarCode.DataSource = this.qryVmSiegelung;
            this.edtVmErbschaftInventarCode.Location = new System.Drawing.Point(111, 370);
            this.edtVmErbschaftInventarCode.LOVName = "VmErbschaftInventar";
            this.edtVmErbschaftInventarCode.Name = "edtVmErbschaftInventarCode";
            this.edtVmErbschaftInventarCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVmErbschaftInventarCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVmErbschaftInventarCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVmErbschaftInventarCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtVmErbschaftInventarCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVmErbschaftInventarCode.Properties.Appearance.Options.UseFont = true;
            this.edtVmErbschaftInventarCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtVmErbschaftInventarCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtVmErbschaftInventarCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtVmErbschaftInventarCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtVmErbschaftInventarCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtVmErbschaftInventarCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtVmErbschaftInventarCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVmErbschaftInventarCode.Properties.NullText = "";
            this.edtVmErbschaftInventarCode.Properties.ShowFooter = false;
            this.edtVmErbschaftInventarCode.Properties.ShowHeader = false;
            this.edtVmErbschaftInventarCode.Size = new System.Drawing.Size(237, 24);
            this.edtVmErbschaftInventarCode.TabIndex = 16;
            //
            // lblVmErbschaftInventarCode
            //
            this.lblVmErbschaftInventarCode.Location = new System.Drawing.Point(5, 370);
            this.lblVmErbschaftInventarCode.Name = "lblVmErbschaftInventarCode";
            this.lblVmErbschaftInventarCode.Size = new System.Drawing.Size(62, 24);
            this.lblVmErbschaftInventarCode.TabIndex = 119;
            this.lblVmErbschaftInventarCode.Tag = "";
            this.lblVmErbschaftInventarCode.Text = "Inventar";
            //
            // lblNotar
            //
            this.lblNotar.Location = new System.Drawing.Point(5, 400);
            this.lblNotar.Name = "lblNotar";
            this.lblNotar.Size = new System.Drawing.Size(36, 24);
            this.lblNotar.TabIndex = 121;
            this.lblNotar.Text = "Notar";
            //
            // edtMassaVerwalter
            //
            this.edtMassaVerwalter.DataMember = "MassaVerwalter";
            this.edtMassaVerwalter.DataSource = this.qryVmSiegelung;
            this.edtMassaVerwalter.Location = new System.Drawing.Point(111, 430);
            this.edtMassaVerwalter.Name = "edtMassaVerwalter";
            this.edtMassaVerwalter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMassaVerwalter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMassaVerwalter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMassaVerwalter.Properties.Appearance.Options.UseBackColor = true;
            this.edtMassaVerwalter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMassaVerwalter.Properties.Appearance.Options.UseFont = true;
            this.edtMassaVerwalter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMassaVerwalter.Size = new System.Drawing.Size(342, 24);
            this.edtMassaVerwalter.TabIndex = 18;
            //
            // lblMassaVerwalter
            //
            this.lblMassaVerwalter.Location = new System.Drawing.Point(5, 430);
            this.lblMassaVerwalter.Name = "lblMassaVerwalter";
            this.lblMassaVerwalter.Size = new System.Drawing.Size(87, 24);
            this.lblMassaVerwalter.TabIndex = 123;
            this.lblMassaVerwalter.Text = "Massaverwalter";
            //
            // edtEntsiegelungsDatum
            //
            this.edtEntsiegelungsDatum.DataMember = "EntsiegelungsDatum";
            this.edtEntsiegelungsDatum.DataSource = this.qryVmSiegelung;
            this.edtEntsiegelungsDatum.EditValue = null;
            this.edtEntsiegelungsDatum.Location = new System.Drawing.Point(111, 470);
            this.edtEntsiegelungsDatum.Name = "edtEntsiegelungsDatum";
            this.edtEntsiegelungsDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEntsiegelungsDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEntsiegelungsDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEntsiegelungsDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEntsiegelungsDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtEntsiegelungsDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEntsiegelungsDatum.Properties.Appearance.Options.UseFont = true;
            this.edtEntsiegelungsDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtEntsiegelungsDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEntsiegelungsDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtEntsiegelungsDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEntsiegelungsDatum.Properties.ShowToday = false;
            this.edtEntsiegelungsDatum.Size = new System.Drawing.Size(90, 24);
            this.edtEntsiegelungsDatum.TabIndex = 19;
            //
            // lblEntsiegelungsDatum
            //
            this.lblEntsiegelungsDatum.Location = new System.Drawing.Point(5, 470);
            this.lblEntsiegelungsDatum.Name = "lblEntsiegelungsDatum";
            this.lblEntsiegelungsDatum.Size = new System.Drawing.Size(82, 24);
            this.lblEntsiegelungsDatum.TabIndex = 125;
            this.lblEntsiegelungsDatum.Text = "Entsiegelung am";
            //
            // kissLabel56
            //
            this.kissLabel56.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel56.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel56.Location = new System.Drawing.Point(494, 106);
            this.kissLabel56.Name = "kissLabel56";
            this.kissLabel56.Size = new System.Drawing.Size(92, 16);
            this.kissLabel56.TabIndex = 126;
            this.kissLabel56.Text = "Rechnung";
            //
            // kissLabel57
            //
            this.kissLabel57.Location = new System.Drawing.Point(652, 190);
            this.kissLabel57.Name = "kissLabel57";
            this.kissLabel57.Size = new System.Drawing.Size(30, 24);
            this.kissLabel57.TabIndex = 129;
            this.kissLabel57.Tag = "";
            this.kissLabel57.Text = "CHF";
            //
            // edtRechnungsBetrag
            //
            this.edtRechnungsBetrag.DataMember = "RechnungsBetrag";
            this.edtRechnungsBetrag.DataSource = this.qryVmSiegelung;
            this.edtRechnungsBetrag.Location = new System.Drawing.Point(545, 190);
            this.edtRechnungsBetrag.Name = "edtRechnungsBetrag";
            this.edtRechnungsBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtRechnungsBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechnungsBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungsBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungsBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungsBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungsBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungsBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRechnungsBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRechnungsBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtRechnungsBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtRechnungsBetrag.Properties.EditFormat.FormatString = "N2";
            this.edtRechnungsBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtRechnungsBetrag.Size = new System.Drawing.Size(102, 24);
            this.edtRechnungsBetrag.TabIndex = 25;
            //
            // lblRechnungsBetrag
            //
            this.lblRechnungsBetrag.Location = new System.Drawing.Point(494, 190);
            this.lblRechnungsBetrag.Name = "lblRechnungsBetrag";
            this.lblRechnungsBetrag.Size = new System.Drawing.Size(43, 24);
            this.lblRechnungsBetrag.TabIndex = 128;
            this.lblRechnungsBetrag.Tag = "";
            this.lblRechnungsBetrag.Text = "Betrag";
            //
            // edtRechnungsDatum
            //
            this.edtRechnungsDatum.DataMember = "RechnungsDatum";
            this.edtRechnungsDatum.DataSource = this.qryVmSiegelung;
            this.edtRechnungsDatum.EditValue = null;
            this.edtRechnungsDatum.Location = new System.Drawing.Point(545, 160);
            this.edtRechnungsDatum.Name = "edtRechnungsDatum";
            this.edtRechnungsDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtRechnungsDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechnungsDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungsDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungsDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungsDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungsDatum.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungsDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtRechnungsDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtRechnungsDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtRechnungsDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRechnungsDatum.Properties.ShowToday = false;
            this.edtRechnungsDatum.Size = new System.Drawing.Size(102, 24);
            this.edtRechnungsDatum.TabIndex = 24;
            //
            // lblRechnungsDatum
            //
            this.lblRechnungsDatum.Location = new System.Drawing.Point(494, 160);
            this.lblRechnungsDatum.Name = "lblRechnungsDatum";
            this.lblRechnungsDatum.Size = new System.Drawing.Size(47, 24);
            this.lblRechnungsDatum.TabIndex = 131;
            this.lblRechnungsDatum.Text = "Datum";
            //
            // edtRechnungsNr
            //
            this.edtRechnungsNr.DataMember = "RechnungsNr";
            this.edtRechnungsNr.DataSource = this.qryVmSiegelung;
            this.edtRechnungsNr.Location = new System.Drawing.Point(545, 130);
            this.edtRechnungsNr.Name = "edtRechnungsNr";
            this.edtRechnungsNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechnungsNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungsNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungsNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungsNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungsNr.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungsNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRechnungsNr.Size = new System.Drawing.Size(102, 24);
            this.edtRechnungsNr.TabIndex = 22;
            //
            // lblRechnungsNr
            //
            this.lblRechnungsNr.Location = new System.Drawing.Point(494, 130);
            this.lblRechnungsNr.Name = "lblRechnungsNr";
            this.lblRechnungsNr.Size = new System.Drawing.Size(19, 24);
            this.lblRechnungsNr.TabIndex = 133;
            this.lblRechnungsNr.Text = "Nr.";
            //
            // lblRechnungAn
            //
            this.lblRechnungAn.Location = new System.Drawing.Point(494, 210);
            this.lblRechnungAn.Name = "lblRechnungAn";
            this.lblRechnungAn.Size = new System.Drawing.Size(26, 24);
            this.lblRechnungAn.TabIndex = 135;
            this.lblRechnungAn.Text = "an";
            //
            // lblBemerkung
            //
            this.lblBemerkung.Location = new System.Drawing.Point(493, 343);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(79, 24);
            this.lblBemerkung.TabIndex = 137;
            this.lblBemerkung.Text = "Bemerkungen";
            //
            // edtBemerkung
            //
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryVmSiegelung;
            this.edtBemerkung.Location = new System.Drawing.Point(494, 370);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(260, 125);
            this.edtBemerkung.TabIndex = 28;
            //
            // edtRechnungAn
            //
            this.edtRechnungAn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtRechnungAn.DataMember = "RechnungAn";
            this.edtRechnungAn.DataSource = this.qryVmSiegelung;
            this.edtRechnungAn.Location = new System.Drawing.Point(494, 234);
            this.edtRechnungAn.Name = "edtRechnungAn";
            this.edtRechnungAn.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechnungAn.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechnungAn.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechnungAn.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechnungAn.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechnungAn.Properties.Appearance.Options.UseFont = true;
            this.edtRechnungAn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRechnungAn.Size = new System.Drawing.Size(259, 83);
            this.edtRechnungAn.TabIndex = 26;
            //
            // kissLabel5
            //
            this.kissLabel5.Location = new System.Drawing.Point(208, 170);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(32, 24);
            this.kissLabel5.TabIndex = 138;
            this.kissLabel5.Text = "Kopie";
            //
            // edtUser
            //
            this.edtUser.DataMember = "User";
            this.edtUser.DataSource = this.qryVmSiegelung;
            this.edtUser.Location = new System.Drawing.Point(111, 40);
            this.edtUser.Name = "edtUser";
            this.edtUser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUser.Properties.Appearance.Options.UseBackColor = true;
            this.edtUser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUser.Properties.Appearance.Options.UseFont = true;
            this.edtUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtUser.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUser.Size = new System.Drawing.Size(252, 24);
            this.edtUser.TabIndex = 0;
            this.edtUser.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUser_UserModifiedFld);
            //
            // edtBezirkNr
            //
            this.edtBezirkNr.DataMember = "BezirkNr";
            this.edtBezirkNr.DataSource = this.qryVmSiegelung;
            this.edtBezirkNr.Location = new System.Drawing.Point(111, 70);
            this.edtBezirkNr.Name = "edtBezirkNr";
            this.edtBezirkNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBezirkNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBezirkNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBezirkNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBezirkNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtBezirkNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBezirkNr.Properties.Appearance.Options.UseFont = true;
            this.edtBezirkNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBezirkNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBezirkNr.Size = new System.Drawing.Size(16, 24);
            this.edtBezirkNr.TabIndex = 1;
            //
            // edtJahr
            //
            this.edtJahr.DataMember = "Jahr";
            this.edtJahr.DataSource = this.qryVmSiegelung;
            this.edtJahr.Location = new System.Drawing.Point(201, 70);
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
            this.edtJahr.Size = new System.Drawing.Size(38, 24);
            this.edtJahr.TabIndex = 3;
            //
            // edtLaufNr
            //
            this.edtLaufNr.DataMember = "LaufNr";
            this.edtLaufNr.DataSource = this.qryVmSiegelung;
            this.edtLaufNr.Location = new System.Drawing.Point(137, 70);
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
            this.edtLaufNr.Size = new System.Drawing.Size(52, 24);
            this.edtLaufNr.TabIndex = 2;
            //
            // kissLabel3
            //
            this.kissLabel3.Location = new System.Drawing.Point(191, 70);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(8, 24);
            this.kissLabel3.TabIndex = 1;
            this.kissLabel3.Text = "-";
            //
            // kissLabel9
            //
            this.kissLabel9.Location = new System.Drawing.Point(128, 70);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(8, 24);
            this.kissLabel9.TabIndex = 2;
            this.kissLabel9.Text = "-";
            //
            // edtSiegelungsFristEingehalten
            //
            this.edtSiegelungsFristEingehalten.DataMember = "SiegelungsFristEingehalten";
            this.edtSiegelungsFristEingehalten.DataSource = this.qryVmSiegelung;
            this.edtSiegelungsFristEingehalten.Location = new System.Drawing.Point(211, 133);
            this.edtSiegelungsFristEingehalten.Name = "edtSiegelungsFristEingehalten";
            this.edtSiegelungsFristEingehalten.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSiegelungsFristEingehalten.Properties.Appearance.Options.UseBackColor = true;
            this.edtSiegelungsFristEingehalten.Properties.Caption = "Siegelung innert 14 Tagen";
            this.edtSiegelungsFristEingehalten.Size = new System.Drawing.Size(155, 19);
            this.edtSiegelungsFristEingehalten.TabIndex = 6;
            //
            // edtNotar
            //
            this.edtNotar.DataMember = "Notar";
            this.edtNotar.DataSource = this.qryVmSiegelung;
            this.edtNotar.Location = new System.Drawing.Point(111, 400);
            this.edtNotar.Name = "edtNotar";
            this.edtNotar.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNotar.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNotar.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNotar.Properties.Appearance.Options.UseBackColor = true;
            this.edtNotar.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNotar.Properties.Appearance.Options.UseFont = true;
            this.edtNotar.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtNotar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtNotar.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNotar.Size = new System.Drawing.Size(237, 24);
            this.edtNotar.TabIndex = 17;
            this.edtNotar.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtNotar_UserModifiedFld);
            //
            // kissDocumentButton1
            //
            this.kissDocumentButton1.Context = "VmErbeSdErbenliste";
            this.kissDocumentButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kissDocumentButton1.Image = ((System.Drawing.Image)(resources.GetObject("xWordBericht1.Image")));
            this.kissDocumentButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kissDocumentButton1.Location = new System.Drawing.Point(545, 70);
            this.kissDocumentButton1.Name = "kissDocumentButton1";
            this.kissDocumentButton1.Size = new System.Drawing.Size(89, 24);
            this.kissDocumentButton1.TabIndex = 21;
            this.kissDocumentButton1.Text = "Erbenliste";
            this.kissDocumentButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kissDocumentButton1.UseVisualStyleBackColor = false;
            //
            // CtlVmSiegelung
            //
            this.ActiveSQLQuery = this.qryVmSiegelung;

            this.Controls.Add(this.kissDocumentButton1);
            this.Controls.Add(this.edtNotar);
            this.Controls.Add(this.edtSiegelungsFristEingehalten);
            this.Controls.Add(this.kissLabel9);
            this.Controls.Add(this.kissLabel3);
            this.Controls.Add(this.edtLaufNr);
            this.Controls.Add(this.edtJahr);
            this.Controls.Add(this.edtBezirkNr);
            this.Controls.Add(this.edtUser);
            this.Controls.Add(this.kissLabel5);
            this.Controls.Add(this.edtRechnungAn);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lblRechnungAn);
            this.Controls.Add(this.edtRechnungsNr);
            this.Controls.Add(this.lblRechnungsNr);
            this.Controls.Add(this.edtRechnungsDatum);
            this.Controls.Add(this.lblRechnungsDatum);
            this.Controls.Add(this.kissLabel56);
            this.Controls.Add(this.edtEntsiegelungsDatum);
            this.Controls.Add(this.lblEntsiegelungsDatum);
            this.Controls.Add(this.edtMassaVerwalter);
            this.Controls.Add(this.lblMassaVerwalter);
            this.Controls.Add(this.lblNotar);
            this.Controls.Add(this.edtVmErbschaftInventarCode);
            this.Controls.Add(this.lblVmErbschaftInventarCode);
            this.Controls.Add(this.edtPliQuittung);
            this.Controls.Add(this.lblPliQuittung);
            this.Controls.Add(this.edtDurchsuchungen);
            this.Controls.Add(this.lblDurchsuchungen);
            this.Controls.Add(this.edtVerfuegungsSperren);
            this.Controls.Add(this.lblVerfuegungsSperren);
            this.Controls.Add(this.edtKopieAndere);
            this.Controls.Add(this.lblKopieAndere);
            this.Controls.Add(this.edtVersandDatum);
            this.Controls.Add(this.lblVersandDatum);
            this.Controls.Add(this.edtOhneGebuehr);
            this.Controls.Add(this.edtSDabgeschlossen);
            this.Controls.Add(this.edtAusschlagung);
            this.Controls.Add(this.edtGesuchUeBestattung);
            this.Controls.Add(this.edtKopieTestamentsdienst);
            this.Controls.Add(this.edtKopieErbschaftsdienst);
            this.Controls.Add(this.edtTodesmeldungDatum);
            this.Controls.Add(this.lblTodesmeldungDatum);
            this.Controls.Add(this.edtSiegelungsDatum);
            this.Controls.Add(this.lblSiegelungsDatum);
            this.Controls.Add(this.kissLabel43);
            this.Controls.Add(this.lblVmErbeSiegelungsprotokoll);
            this.Controls.Add(this.edtVmErbeSiegelungsprotokoll);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.kissLabel57);
            this.Controls.Add(this.edtRechnungsBetrag);
            this.Controls.Add(this.lblRechnungsBetrag);
            this.Name = "CtlVmSiegelung";
            this.Size = new System.Drawing.Size(763, 499);
            ((System.ComponentModel.ISupportInitialize)(this.qryVmSiegelung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmErbeSiegelungsprotokoll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVmErbeSiegelungsprotokoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTodesmeldungDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTodesmeldungDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSiegelungsDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSiegelungsDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKopieErbschaftsdienst.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKopieTestamentsdienst.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGesuchUeBestattung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusschlagung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSDabgeschlossen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOhneGebuehr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersandDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersandDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKopieAndere.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKopieAndere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerfuegungsSperren.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerfuegungsSperren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDurchsuchungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDurchsuchungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPliQuittung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPliQuittung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmErbschaftInventarCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmErbschaftInventarCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVmErbschaftInventarCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNotar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMassaVerwalter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMassaVerwalter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEntsiegelungsDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEntsiegelungsDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungsNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungsNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechnungAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechnungAn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezirkNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLaufNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSiegelungsFristEingehalten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNotar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private void edtNotar_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.InstitutionSuchen(edtNotar.Text, 19, true, e.ButtonClicked); //nur Notare
            if (!e.Cancel)
            {
                qryVmSiegelung["NotarID"] = dlg["BaInstitutionID"];
                qryVmSiegelung["Notar"] = dlg["Name"];
            }
        }

        private void edtUser_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtUser.Text, ModulID.V, e.ButtonClicked);
            if (!e.Cancel)
            {
                qryVmSiegelung["UserID"] = dlg["UserID"];
                qryVmSiegelung["User"] = dlg["Name"];
            }
        }

        private void qryVmSiegelung_BeforePost(object sender, System.EventArgs e)
        {
            if (DBUtil.IsEmpty(qryVmSiegelung["LaufNr"]) &&
                !DBUtil.IsEmpty(qryVmSiegelung["BezirkNr"]) &&
                !DBUtil.IsEmpty(qryVmSiegelung["Jahr"]))
            {
                qryVmSiegelung["LaufNr"] = DBUtil.ExecuteScalarSQL(@"
					SELECT isNull(max(LaufNr) + 1,1)
					FROM VmSiegelung
					WHERE BezirkNr = {0}
					  AND Jahr = {1}",
                    qryVmSiegelung["BezirkNr"],
                    qryVmSiegelung["Jahr"]);
            }
        }

        //DBUtil.CheckNotNullField(qryVmSiegelung, "VmMandatstypCode", KissMsg.GetMLMessage("CtlVmSiegelung", "Bewertung", "Bewertung"), editBewertung);
    }
}