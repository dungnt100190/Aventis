using System;
using System.Drawing;

using KiSS.DBScheme;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Inkasso
{
    public class CtlIkLeistung : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnReopen;
        private KiSS4.Gui.KissCheckEdit chkFremdSD;
        private KiSS4.Gui.KissCheckEdit chkMahnen;
        private KiSS4.Gui.KissCheckEdit chkRente;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissLookUpEdit editAiBegrErreichungsGradCode;
        private KiSS4.Gui.KissTextEdit editSAR;
        private KiSS4.Gui.KissLookUpEdit edtAbschlussGrundCode;
        private KiSS4.Gui.KissLookUpEdit edtAufenthaltsart;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissTextEdit edtBezeichnung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtEroeffnungsGrundCode;
        private KiSS4.Gui.KissDateEdit edtIkDatumForderungstitel;
        private KiSS4.Gui.KissDateEdit edtIkDatumRechtskraft;
        private KiSS4.Gui.KissLookUpEdit edtIkForderungstitelCode;
        private KiSS4.Gui.KissLookUpEdit edtIkInkassoBemuehungCode;
        private KiSS4.Gui.KissLookUpEdit edtIkRueckerstattungTypCode;
        private KiSS4.Gui.KissDateEdit edtIkVerjaehrungAm;
        private KiSS4.Gui.KissLookUpEdit edtQuote;
        private KiSS4.Gui.KissLookUpEdit edtSchuldnerPerson;
        private KiSS4.Gui.KissLookUpEdit edtSchuldnerStatus;
        private KiSS4.Gui.KissLookUpEdit edtStatus;
        private KissLookUpEdit edtZustaendigeGemeinde;
        private KiSS4.Gui.KissLabel lblAbschlussGrundCode;
        private KiSS4.Gui.KissLabel lblAdresse;
        private KiSS4.Gui.KissLabel lblAufenthaltStatus;
        private KiSS4.Gui.KissLabel lblBegruendung;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBezeichnung;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblEroeffnungsGrundCode;
        private KiSS4.Gui.KissLabel lblFremdSD;
        private KiSS4.Gui.KissLabel lblIkDatumForderungstitel;
        private KiSS4.Gui.KissLabel lblIkDatumRechtskraft;
        private KiSS4.Gui.KissLabel lblIkForderungstitelCode;
        private KiSS4.Gui.KissLabel lblIkInkassoBemuehung;
        private KiSS4.Gui.KissLabel lblIkVerjaehrungAm;
        private KiSS4.Gui.KissLabel lblQuote;
        private KiSS4.Gui.KissLabel lblRueckerstattung;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblSchuldner;
        private KiSS4.Gui.KissLabel lblSchuldnerStatus;
        private KiSS4.Gui.KissLabel lblStatus;
        private KiSS4.Gui.KissLabel lblTitel;
        private KissLabel lblZustaendigeGemeinde;
        private KiSS4.Gui.KissMemoEdit memAdresse;
        private System.Windows.Forms.PictureBox picTitle;
        private System.Windows.Forms.Panel pnlHideInAbklaerung;
        private System.Windows.Forms.Panel pnTitle;
        private KiSS4.DB.SqlQuery qryAdresse;
        private KiSS4.DB.SqlQuery qryFaLeistung;
        private KiSS4.DB.SqlQuery qryPerson;

        #endregion

        #endregion

        #region Constructors

        public CtlIkLeistung(Image titelImage, string titelText, int faLeistungID)
            : this()
        {
            this.picTitle.Image = titelImage;
            this.lblTitel.Text = titelText;

            qryPerson.Fill(faLeistungID);

            this.qryFaLeistung.Fill(faLeistungID);

            // in Bern ist Schuldner immer der Fallträger
            if (DBUtil.IsEmpty(qryFaLeistung["SchuldnerBaPersonID"]))
            {
                qryFaLeistung["SchuldnerBaPersonID"] = qryFaLeistung["BaPersonID"];
            }

            if (DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.GemeindeCode]) && DBUtil.IsEmpty(edtZustaendigeGemeinde.EditValue))
            {
                //only 1 item in a mandatory field --> set value directly
                var queryZustaendigeGemeinde = ((SqlQuery)edtZustaendigeGemeinde.Properties.DataSource);

                if (queryZustaendigeGemeinde.Count == 1)
                {
                    qryFaLeistung[DBO.FaLeistung.GemeindeCode] = queryZustaendigeGemeinde["Code"];
                }
                else if (qryFaLeistung.CanUpdate)
                {
                    qryFaLeistung.RowModified = true;
                }
            }

            this.SetFieldVisibility();
        }

        public CtlIkLeistung()
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIkLeistung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.editSAR = new KiSS4.Gui.KissTextEdit();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery();
            this.edtBezeichnung = new KiSS4.Gui.KissTextEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtEroeffnungsGrundCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtAbschlussGrundCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.lblEroeffnungsGrundCode = new KiSS4.Gui.KissLabel();
            this.lblAbschlussGrundCode = new KiSS4.Gui.KissLabel();
            this.lblBezeichnung = new KiSS4.Gui.KissLabel();
            this.pnlHideInAbklaerung = new System.Windows.Forms.Panel();
            this.lblIkVerjaehrungAm = new KiSS4.Gui.KissLabel();
            this.edtIkVerjaehrungAm = new KiSS4.Gui.KissDateEdit();
            this.lblIkInkassoBemuehung = new KiSS4.Gui.KissLabel();
            this.edtIkInkassoBemuehungCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblSchuldnerStatus = new KiSS4.Gui.KissLabel();
            this.lblAufenthaltStatus = new KiSS4.Gui.KissLabel();
            this.chkFremdSD = new KiSS4.Gui.KissCheckEdit();
            this.lblQuote = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblBegruendung = new KiSS4.Gui.KissLabel();
            this.lblStatus = new KiSS4.Gui.KissLabel();
            this.lblAdresse = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblSchuldner = new KiSS4.Gui.KissLabel();
            this.editAiBegrErreichungsGradCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtQuote = new KiSS4.Gui.KissLookUpEdit();
            this.edtStatus = new KiSS4.Gui.KissLookUpEdit();
            this.edtSchuldnerStatus = new KiSS4.Gui.KissLookUpEdit();
            this.edtAufenthaltsart = new KiSS4.Gui.KissLookUpEdit();
            this.lblFremdSD = new KiSS4.Gui.KissLabel();
            this.chkRente = new KiSS4.Gui.KissCheckEdit();
            this.memAdresse = new KiSS4.Gui.KissMemoEdit();
            this.qryAdresse = new KiSS4.DB.SqlQuery();
            this.chkMahnen = new KiSS4.Gui.KissCheckEdit();
            this.edtSchuldnerPerson = new KiSS4.Gui.KissLookUpEdit();
            this.qryPerson = new KiSS4.DB.SqlQuery();
            this.lblRueckerstattung = new KiSS4.Gui.KissLabel();
            this.edtIkRueckerstattungTypCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblIkForderungstitelCode = new KiSS4.Gui.KissLabel();
            this.edtIkForderungstitelCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblIkDatumRechtskraft = new KiSS4.Gui.KissLabel();
            this.edtIkDatumRechtskraft = new KiSS4.Gui.KissDateEdit();
            this.lblIkDatumForderungstitel = new KiSS4.Gui.KissLabel();
            this.edtIkDatumForderungstitel = new KiSS4.Gui.KissDateEdit();
            this.btnReopen = new KiSS4.Gui.KissButton();
            this.lblZustaendigeGemeinde = new KiSS4.Gui.KissLabel();
            this.edtZustaendigeGemeinde = new KiSS4.Gui.KissLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.editSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezeichnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsGrundCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungsGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezeichnung)).BeginInit();
            this.pnlHideInAbklaerung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkVerjaehrungAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkVerjaehrungAm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkInkassoBemuehung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkInkassoBemuehungCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkInkassoBemuehungCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchuldnerStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFremdSD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblQuote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBegruendung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchuldner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAiBegrErreichungsGradCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAiBegrErreichungsGradCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtQuote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtQuote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchuldnerStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchuldnerStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFremdSD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAdresse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMahnen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchuldnerPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchuldnerPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRueckerstattung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRueckerstattungTypCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRueckerstattungTypCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkForderungstitelCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkForderungstitelCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkForderungstitelCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkDatumRechtskraft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkDatumRechtskraft.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkDatumForderungstitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkDatumForderungstitel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigeGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeinde.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // editSAR
            //
            this.editSAR.DataMember = "LogonName";
            this.editSAR.DataSource = this.qryFaLeistung;
            this.editSAR.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editSAR.Location = new System.Drawing.Point(105, 48);
            this.editSAR.Name = "editSAR";
            this.editSAR.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editSAR.Properties.Appearance.Options.UseBackColor = true;
            this.editSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.editSAR.Properties.Appearance.Options.UseFont = true;
            this.editSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editSAR.Properties.Name = "editSAR.Properties";
            this.editSAR.Properties.ReadOnly = true;
            this.editSAR.Size = new System.Drawing.Size(100, 24);
            this.editSAR.TabIndex = 0;
            this.editSAR.TabStop = false;
            //
            // qryFaLeistung
            //
            this.qryFaLeistung.CanDelete = true;
            this.qryFaLeistung.CanUpdate = true;
            this.qryFaLeistung.HostControl = this;
            this.qryFaLeistung.IsIdentityInsert = false;
            this.qryFaLeistung.SelectStatement = resources.GetString("qryFaLeistung.SelectStatement");
            this.qryFaLeistung.TableName = "FaLeistung";
            this.qryFaLeistung.AfterDelete += new System.EventHandler(this.qryFaLeistung_AfterDelete);
            this.qryFaLeistung.AfterFill += new System.EventHandler(this.qryFaLeistung_AfterFill);
            this.qryFaLeistung.AfterPost += new System.EventHandler(this.qryFaLeistung_AfterPost);
            this.qryFaLeistung.BeforePost += new System.EventHandler(this.qryFaLeistung_BeforePost);
            this.qryFaLeistung.PositionChanged += new System.EventHandler(this.qryFaLeistung_PositionChanged);
            //
            // edtBezeichnung
            //
            this.edtBezeichnung.DataMember = "Bezeichnung";
            this.edtBezeichnung.DataSource = this.qryFaLeistung;
            this.edtBezeichnung.Location = new System.Drawing.Point(105, 78);
            this.edtBezeichnung.Name = "edtBezeichnung";
            this.edtBezeichnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBezeichnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBezeichnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBezeichnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBezeichnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBezeichnung.Properties.Appearance.Options.UseFont = true;
            this.edtBezeichnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBezeichnung.Size = new System.Drawing.Size(443, 24);
            this.edtBezeichnung.TabIndex = 2;
            //
            // edtDatumVon
            //
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryFaLeistung;
            this.edtDatumVon.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(105, 108);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 3;
            //
            // edtEroeffnungsGrundCode
            //
            this.edtEroeffnungsGrundCode.DataMember = "EroeffnungsGrundCode";
            this.edtEroeffnungsGrundCode.DataSource = this.qryFaLeistung;
            this.edtEroeffnungsGrundCode.Location = new System.Drawing.Point(330, 108);
            this.edtEroeffnungsGrundCode.LOVFilter = "I";
            this.edtEroeffnungsGrundCode.LOVName = "EroeffnungsGrund";
            this.edtEroeffnungsGrundCode.Name = "edtEroeffnungsGrundCode";
            this.edtEroeffnungsGrundCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungsGrundCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungsGrundCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungsGrundCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungsGrundCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungsGrundCode.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungsGrundCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEroeffnungsGrundCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungsGrundCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEroeffnungsGrundCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEroeffnungsGrundCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtEroeffnungsGrundCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtEroeffnungsGrundCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungsGrundCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", null, 75)});
            this.edtEroeffnungsGrundCode.Properties.DisplayMember = "Text";
            this.edtEroeffnungsGrundCode.Properties.NullText = "";
            this.edtEroeffnungsGrundCode.Properties.ShowFooter = false;
            this.edtEroeffnungsGrundCode.Properties.ShowHeader = false;
            this.edtEroeffnungsGrundCode.Properties.ValueMember = "Code";
            this.edtEroeffnungsGrundCode.Size = new System.Drawing.Size(218, 24);
            this.edtEroeffnungsGrundCode.TabIndex = 4;
            //
            // edtDatumBis
            //
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryFaLeistung;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(105, 138);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 5;
            //
            // edtAbschlussGrundCode
            //
            this.edtAbschlussGrundCode.DataMember = "AbschlussGrundCode";
            this.edtAbschlussGrundCode.DataSource = this.qryFaLeistung;
            this.edtAbschlussGrundCode.Location = new System.Drawing.Point(330, 138);
            this.edtAbschlussGrundCode.LOVFilter = "I";
            this.edtAbschlussGrundCode.LOVName = "AbschlussGrund";
            this.edtAbschlussGrundCode.Name = "edtAbschlussGrundCode";
            this.edtAbschlussGrundCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussGrundCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussGrundCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGrundCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussGrundCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussGrundCode.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAbschlussGrundCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtAbschlussGrundCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtAbschlussGrundCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussGrundCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", null, 75)});
            this.edtAbschlussGrundCode.Properties.DisplayMember = "Text";
            this.edtAbschlussGrundCode.Properties.NullText = "";
            this.edtAbschlussGrundCode.Properties.ShowFooter = false;
            this.edtAbschlussGrundCode.Properties.ShowHeader = false;
            this.edtAbschlussGrundCode.Properties.ValueMember = "Code";
            this.edtAbschlussGrundCode.Size = new System.Drawing.Size(218, 24);
            this.edtAbschlussGrundCode.TabIndex = 6;
            //
            // lblDatumVon
            //
            this.lblDatumVon.Location = new System.Drawing.Point(10, 108);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(81, 24);
            this.lblDatumVon.TabIndex = 5;
            this.lblDatumVon.Text = "Datum von";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            //
            // lblDatumBis
            //
            this.lblDatumBis.Location = new System.Drawing.Point(10, 139);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(89, 24);
            this.lblDatumBis.TabIndex = 6;
            this.lblDatumBis.Text = "Datum bis";
            this.lblDatumBis.UseCompatibleTextRendering = true;
            //
            // pnTitle
            //
            this.pnTitle.Controls.Add(this.picTitle);
            this.pnTitle.Controls.Add(this.lblTitel);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(646, 40);
            this.pnTitle.TabIndex = 9;
            //
            // picTitle
            //
            this.picTitle.Location = new System.Drawing.Point(10, 9);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(25, 20);
            this.picTitle.TabIndex = 1;
            this.picTitle.TabStop = false;
            //
            // lblTitel
            //
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(500, 20);
            this.lblTitel.TabIndex = 1;
            this.lblTitel.Text = "Alimenten Inkasso";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // lblSAR
            //
            this.lblSAR.Location = new System.Drawing.Point(10, 51);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(89, 24);
            this.lblSAR.TabIndex = 11;
            this.lblSAR.Text = "zuständige/r SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            //
            // lblEroeffnungsGrundCode
            //
            this.lblEroeffnungsGrundCode.Location = new System.Drawing.Point(224, 108);
            this.lblEroeffnungsGrundCode.Name = "lblEroeffnungsGrundCode";
            this.lblEroeffnungsGrundCode.Size = new System.Drawing.Size(100, 23);
            this.lblEroeffnungsGrundCode.TabIndex = 13;
            this.lblEroeffnungsGrundCode.Text = "Unterart";
            this.lblEroeffnungsGrundCode.UseCompatibleTextRendering = true;
            //
            // lblAbschlussGrundCode
            //
            this.lblAbschlussGrundCode.Location = new System.Drawing.Point(224, 138);
            this.lblAbschlussGrundCode.Name = "lblAbschlussGrundCode";
            this.lblAbschlussGrundCode.Size = new System.Drawing.Size(100, 23);
            this.lblAbschlussGrundCode.TabIndex = 14;
            this.lblAbschlussGrundCode.Text = "Abschlussgrund";
            this.lblAbschlussGrundCode.UseCompatibleTextRendering = true;
            //
            // lblBezeichnung
            //
            this.lblBezeichnung.Location = new System.Drawing.Point(10, 78);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(75, 24);
            this.lblBezeichnung.TabIndex = 36;
            this.lblBezeichnung.Text = "Bezeichnung";
            this.lblBezeichnung.UseCompatibleTextRendering = true;
            //
            // pnlHideInAbklaerung
            //
            this.pnlHideInAbklaerung.Controls.Add(this.lblIkVerjaehrungAm);
            this.pnlHideInAbklaerung.Controls.Add(this.edtIkVerjaehrungAm);
            this.pnlHideInAbklaerung.Controls.Add(this.lblIkInkassoBemuehung);
            this.pnlHideInAbklaerung.Controls.Add(this.edtIkInkassoBemuehungCode);
            this.pnlHideInAbklaerung.Controls.Add(this.lblSchuldnerStatus);
            this.pnlHideInAbklaerung.Controls.Add(this.lblAufenthaltStatus);
            this.pnlHideInAbklaerung.Controls.Add(this.chkFremdSD);
            this.pnlHideInAbklaerung.Controls.Add(this.lblQuote);
            this.pnlHideInAbklaerung.Controls.Add(this.lblBemerkung);
            this.pnlHideInAbklaerung.Controls.Add(this.lblBegruendung);
            this.pnlHideInAbklaerung.Controls.Add(this.lblStatus);
            this.pnlHideInAbklaerung.Controls.Add(this.lblAdresse);
            this.pnlHideInAbklaerung.Controls.Add(this.edtBemerkung);
            this.pnlHideInAbklaerung.Controls.Add(this.lblSchuldner);
            this.pnlHideInAbklaerung.Controls.Add(this.editAiBegrErreichungsGradCode);
            this.pnlHideInAbklaerung.Controls.Add(this.edtQuote);
            this.pnlHideInAbklaerung.Controls.Add(this.edtStatus);
            this.pnlHideInAbklaerung.Controls.Add(this.edtSchuldnerStatus);
            this.pnlHideInAbklaerung.Controls.Add(this.edtAufenthaltsart);
            this.pnlHideInAbklaerung.Controls.Add(this.lblFremdSD);
            this.pnlHideInAbklaerung.Controls.Add(this.chkRente);
            this.pnlHideInAbklaerung.Controls.Add(this.memAdresse);
            this.pnlHideInAbklaerung.Controls.Add(this.chkMahnen);
            this.pnlHideInAbklaerung.Controls.Add(this.edtSchuldnerPerson);
            this.pnlHideInAbklaerung.Location = new System.Drawing.Point(10, 283);
            this.pnlHideInAbklaerung.Name = "pnlHideInAbklaerung";
            this.pnlHideInAbklaerung.Size = new System.Drawing.Size(628, 396);
            this.pnlHideInAbklaerung.TabIndex = 44;
            //
            // lblIkVerjaehrungAm
            //
            this.lblIkVerjaehrungAm.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblIkVerjaehrungAm.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblIkVerjaehrungAm.Location = new System.Drawing.Point(0, 230);
            this.lblIkVerjaehrungAm.Name = "lblIkVerjaehrungAm";
            this.lblIkVerjaehrungAm.Size = new System.Drawing.Size(89, 34);
            this.lblIkVerjaehrungAm.TabIndex = 67;
            this.lblIkVerjaehrungAm.Text = "nächste Verjährung";
            this.lblIkVerjaehrungAm.UseCompatibleTextRendering = true;
            //
            // edtIkVerjaehrungAm
            //
            this.edtIkVerjaehrungAm.DataMember = "IkVerjaehrungAm";
            this.edtIkVerjaehrungAm.DataSource = this.qryFaLeistung;
            this.edtIkVerjaehrungAm.EditValue = null;
            this.edtIkVerjaehrungAm.Location = new System.Drawing.Point(95, 230);
            this.edtIkVerjaehrungAm.Name = "edtIkVerjaehrungAm";
            this.edtIkVerjaehrungAm.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtIkVerjaehrungAm.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkVerjaehrungAm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkVerjaehrungAm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkVerjaehrungAm.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkVerjaehrungAm.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkVerjaehrungAm.Properties.Appearance.Options.UseFont = true;
            this.edtIkVerjaehrungAm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtIkVerjaehrungAm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtIkVerjaehrungAm.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtIkVerjaehrungAm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkVerjaehrungAm.Properties.ShowToday = false;
            this.edtIkVerjaehrungAm.Size = new System.Drawing.Size(116, 24);
            this.edtIkVerjaehrungAm.TabIndex = 9;
            //
            // lblIkInkassoBemuehung
            //
            this.lblIkInkassoBemuehung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblIkInkassoBemuehung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblIkInkassoBemuehung.Location = new System.Drawing.Point(224, 197);
            this.lblIkInkassoBemuehung.Name = "lblIkInkassoBemuehung";
            this.lblIkInkassoBemuehung.Size = new System.Drawing.Size(59, 33);
            this.lblIkInkassoBemuehung.TabIndex = 65;
            this.lblIkInkassoBemuehung.Text = "Inkasso   bemühung";
            this.lblIkInkassoBemuehung.UseCompatibleTextRendering = true;
            //
            // edtIkInkassoBemuehungCode
            //
            this.edtIkInkassoBemuehungCode.DataMember = "IkInkassoBemuehungCode";
            this.edtIkInkassoBemuehungCode.DataSource = this.qryFaLeistung;
            this.edtIkInkassoBemuehungCode.Location = new System.Drawing.Point(302, 200);
            this.edtIkInkassoBemuehungCode.LOVName = "IkInkassoBemuehung";
            this.edtIkInkassoBemuehungCode.Name = "edtIkInkassoBemuehungCode";
            this.edtIkInkassoBemuehungCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkInkassoBemuehungCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkInkassoBemuehungCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkInkassoBemuehungCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkInkassoBemuehungCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkInkassoBemuehungCode.Properties.Appearance.Options.UseFont = true;
            this.edtIkInkassoBemuehungCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIkInkassoBemuehungCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkInkassoBemuehungCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIkInkassoBemuehungCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIkInkassoBemuehungCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtIkInkassoBemuehungCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtIkInkassoBemuehungCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkInkassoBemuehungCode.Properties.NullText = "";
            this.edtIkInkassoBemuehungCode.Properties.ShowFooter = false;
            this.edtIkInkassoBemuehungCode.Properties.ShowHeader = false;
            this.edtIkInkassoBemuehungCode.Size = new System.Drawing.Size(236, 24);
            this.edtIkInkassoBemuehungCode.TabIndex = 8;
            //
            // lblSchuldnerStatus
            //
            this.lblSchuldnerStatus.Location = new System.Drawing.Point(0, 200);
            this.lblSchuldnerStatus.Name = "lblSchuldnerStatus";
            this.lblSchuldnerStatus.Size = new System.Drawing.Size(89, 24);
            this.lblSchuldnerStatus.TabIndex = 63;
            this.lblSchuldnerStatus.Text = "Schuldner Status";
            this.lblSchuldnerStatus.UseCompatibleTextRendering = true;
            //
            // lblAufenthaltStatus
            //
            this.lblAufenthaltStatus.Location = new System.Drawing.Point(0, 171);
            this.lblAufenthaltStatus.Name = "lblAufenthaltStatus";
            this.lblAufenthaltStatus.Size = new System.Drawing.Size(89, 24);
            this.lblAufenthaltStatus.TabIndex = 62;
            this.lblAufenthaltStatus.Text = "Aufenthaltsart";
            this.lblAufenthaltStatus.UseCompatibleTextRendering = true;
            //
            // chkFremdSD
            //
            this.chkFremdSD.DataMember = "IkHatUnterstuetzung";
            this.chkFremdSD.DataSource = this.qryFaLeistung;
            this.chkFremdSD.Location = new System.Drawing.Point(375, 90);
            this.chkFremdSD.Name = "chkFremdSD";
            this.chkFremdSD.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkFremdSD.Properties.Appearance.Options.UseBackColor = true;
            this.chkFremdSD.Properties.Caption = "";
            this.chkFremdSD.Size = new System.Drawing.Size(21, 19);
            this.chkFremdSD.TabIndex = 5;
            //
            // lblQuote
            //
            this.lblQuote.Location = new System.Drawing.Point(0, 260);
            this.lblQuote.Name = "lblQuote";
            this.lblQuote.Size = new System.Drawing.Size(52, 24);
            this.lblQuote.TabIndex = 60;
            this.lblQuote.Text = "Quote";
            this.lblQuote.UseCompatibleTextRendering = true;
            //
            // lblBemerkung
            //
            this.lblBemerkung.Location = new System.Drawing.Point(0, 324);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(75, 24);
            this.lblBemerkung.TabIndex = 59;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            //
            // lblBegruendung
            //
            this.lblBegruendung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBegruendung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBegruendung.Location = new System.Drawing.Point(224, 260);
            this.lblBegruendung.Name = "lblBegruendung";
            this.lblBegruendung.Size = new System.Drawing.Size(72, 24);
            this.lblBegruendung.TabIndex = 58;
            this.lblBegruendung.Text = "Begründung der Quote";
            this.lblBegruendung.UseCompatibleTextRendering = true;
            //
            // lblStatus
            //
            this.lblStatus.Location = new System.Drawing.Point(224, 230);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 24);
            this.lblStatus.TabIndex = 57;
            this.lblStatus.Text = "Status";
            this.lblStatus.UseCompatibleTextRendering = true;
            //
            // lblAdresse
            //
            this.lblAdresse.Location = new System.Drawing.Point(0, 49);
            this.lblAdresse.Name = "lblAdresse";
            this.lblAdresse.Size = new System.Drawing.Size(78, 24);
            this.lblAdresse.TabIndex = 56;
            this.lblAdresse.Text = "Adresse";
            this.lblAdresse.UseCompatibleTextRendering = true;
            //
            // edtBemerkung
            //
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryFaLeistung;
            this.edtBemerkung.Location = new System.Drawing.Point(95, 324);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(530, 61);
            this.edtBemerkung.TabIndex = 13;
            //
            // lblSchuldner
            //
            this.lblSchuldner.Location = new System.Drawing.Point(0, 12);
            this.lblSchuldner.Name = "lblSchuldner";
            this.lblSchuldner.Size = new System.Drawing.Size(78, 24);
            this.lblSchuldner.TabIndex = 54;
            this.lblSchuldner.Text = "Schuldner";
            this.lblSchuldner.UseCompatibleTextRendering = true;
            //
            // editAiBegrErreichungsGradCode
            //
            this.editAiBegrErreichungsGradCode.DataMember = "IkErreichungsGradCode";
            this.editAiBegrErreichungsGradCode.DataSource = this.qryFaLeistung;
            this.editAiBegrErreichungsGradCode.Location = new System.Drawing.Point(302, 260);
            this.editAiBegrErreichungsGradCode.LOVName = "IkErreichungsGrad";
            this.editAiBegrErreichungsGradCode.Name = "editAiBegrErreichungsGradCode";
            this.editAiBegrErreichungsGradCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editAiBegrErreichungsGradCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editAiBegrErreichungsGradCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editAiBegrErreichungsGradCode.Properties.Appearance.Options.UseBackColor = true;
            this.editAiBegrErreichungsGradCode.Properties.Appearance.Options.UseBorderColor = true;
            this.editAiBegrErreichungsGradCode.Properties.Appearance.Options.UseFont = true;
            this.editAiBegrErreichungsGradCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editAiBegrErreichungsGradCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editAiBegrErreichungsGradCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editAiBegrErreichungsGradCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editAiBegrErreichungsGradCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.editAiBegrErreichungsGradCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.editAiBegrErreichungsGradCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editAiBegrErreichungsGradCode.Properties.Name = "editAiBegrErreichungsGradCode.Properties";
            this.editAiBegrErreichungsGradCode.Properties.NullText = "";
            this.editAiBegrErreichungsGradCode.Properties.ShowFooter = false;
            this.editAiBegrErreichungsGradCode.Properties.ShowHeader = false;
            this.editAiBegrErreichungsGradCode.Size = new System.Drawing.Size(314, 24);
            this.editAiBegrErreichungsGradCode.TabIndex = 12;
            //
            // edtQuote
            //
            this.edtQuote.DataMember = "IkEinnahmenQuoteCode";
            this.edtQuote.DataSource = this.qryFaLeistung;
            this.edtQuote.Location = new System.Drawing.Point(95, 260);
            this.edtQuote.LOVName = "IkEinnahmenQuote";
            this.edtQuote.Name = "edtQuote";
            this.edtQuote.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtQuote.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtQuote.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtQuote.Properties.Appearance.Options.UseBackColor = true;
            this.edtQuote.Properties.Appearance.Options.UseBorderColor = true;
            this.edtQuote.Properties.Appearance.Options.UseFont = true;
            this.edtQuote.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtQuote.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtQuote.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtQuote.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtQuote.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtQuote.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtQuote.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtQuote.Properties.NullText = "";
            this.edtQuote.Properties.ShowFooter = false;
            this.edtQuote.Properties.ShowHeader = false;
            this.edtQuote.Size = new System.Drawing.Size(116, 24);
            this.edtQuote.TabIndex = 11;
            //
            // edtStatus
            //
            this.edtStatus.DataMember = "IkLeistungStatusCode";
            this.edtStatus.DataSource = this.qryFaLeistung;
            this.edtStatus.Location = new System.Drawing.Point(302, 230);
            this.edtStatus.LOVName = "IkLeistungStatus";
            this.edtStatus.Name = "edtStatus";
            this.edtStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStatus.Properties.Appearance.Options.UseFont = true;
            this.edtStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStatus.Properties.Name = "lookUpStatus.Properties";
            this.edtStatus.Properties.NullText = "";
            this.edtStatus.Properties.ShowFooter = false;
            this.edtStatus.Properties.ShowHeader = false;
            this.edtStatus.Size = new System.Drawing.Size(236, 24);
            this.edtStatus.TabIndex = 10;
            //
            // edtSchuldnerStatus
            //
            this.edtSchuldnerStatus.DataMember = "IkSchuldnerStatusCode";
            this.edtSchuldnerStatus.DataSource = this.qryFaLeistung;
            this.edtSchuldnerStatus.Location = new System.Drawing.Point(95, 200);
            this.edtSchuldnerStatus.LOVName = "IkSchuldnerStatus";
            this.edtSchuldnerStatus.Name = "edtSchuldnerStatus";
            this.edtSchuldnerStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSchuldnerStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSchuldnerStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSchuldnerStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtSchuldnerStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSchuldnerStatus.Properties.Appearance.Options.UseFont = true;
            this.edtSchuldnerStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSchuldnerStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSchuldnerStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSchuldnerStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSchuldnerStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtSchuldnerStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtSchuldnerStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSchuldnerStatus.Properties.NullText = "";
            this.edtSchuldnerStatus.Properties.ShowFooter = false;
            this.edtSchuldnerStatus.Properties.ShowHeader = false;
            this.edtSchuldnerStatus.Size = new System.Drawing.Size(116, 24);
            this.edtSchuldnerStatus.TabIndex = 7;
            //
            // edtAufenthaltsart
            //
            this.edtAufenthaltsart.DataMember = "IkAufenthaltsartCode";
            this.edtAufenthaltsart.DataSource = this.qryFaLeistung;
            this.edtAufenthaltsart.Location = new System.Drawing.Point(95, 170);
            this.edtAufenthaltsart.LOVName = "IkAufenthaltsart";
            this.edtAufenthaltsart.Name = "edtAufenthaltsart";
            this.edtAufenthaltsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAufenthaltsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAufenthaltsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufenthaltsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtAufenthaltsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAufenthaltsart.Properties.Appearance.Options.UseFont = true;
            this.edtAufenthaltsart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAufenthaltsart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufenthaltsart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAufenthaltsart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAufenthaltsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtAufenthaltsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtAufenthaltsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAufenthaltsart.Properties.NullText = "";
            this.edtAufenthaltsart.Properties.ShowFooter = false;
            this.edtAufenthaltsart.Properties.ShowHeader = false;
            this.edtAufenthaltsart.Size = new System.Drawing.Size(254, 24);
            this.edtAufenthaltsart.TabIndex = 6;
            //
            // lblFremdSD
            //
            this.lblFremdSD.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFremdSD.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblFremdSD.Location = new System.Drawing.Point(396, 92);
            this.lblFremdSD.Margin = new System.Windows.Forms.Padding(0);
            this.lblFremdSD.Name = "lblFremdSD";
            this.lblFremdSD.Size = new System.Drawing.Size(222, 38);
            this.lblFremdSD.TabIndex = 4;
            this.lblFremdSD.Text = "Schuldner wird von fremden Sozialdienst unterstützt";
            this.lblFremdSD.UseCompatibleTextRendering = true;
            //
            // chkRente
            //
            this.chkRente.DataMember = "IkIstRentenbezueger";
            this.chkRente.DataSource = this.qryFaLeistung;
            this.chkRente.Location = new System.Drawing.Point(375, 53);
            this.chkRente.Name = "chkRente";
            this.chkRente.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkRente.Properties.Appearance.Options.UseBackColor = true;
            this.chkRente.Properties.Caption = "Schuldner ist Rentenbezüger";
            this.chkRente.Size = new System.Drawing.Size(163, 19);
            this.chkRente.TabIndex = 3;
            //
            // memAdresse
            //
            this.memAdresse.DataMember = "Adresse";
            this.memAdresse.DataSource = this.qryAdresse;
            this.memAdresse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.memAdresse.Location = new System.Drawing.Point(95, 51);
            this.memAdresse.Name = "memAdresse";
            this.memAdresse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.memAdresse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memAdresse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memAdresse.Properties.Appearance.Options.UseBackColor = true;
            this.memAdresse.Properties.Appearance.Options.UseBorderColor = true;
            this.memAdresse.Properties.Appearance.Options.UseFont = true;
            this.memAdresse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memAdresse.Properties.ReadOnly = true;
            this.memAdresse.Size = new System.Drawing.Size(254, 97);
            this.memAdresse.TabIndex = 2;
            this.memAdresse.TabStop = false;
            //
            // qryAdresse
            //
            this.qryAdresse.HostControl = this;
            this.qryAdresse.IsIdentityInsert = false;
            this.qryAdresse.SelectStatement = "SELECT\r\n\tAdresse = WohnsitzMehrzeilig\r\nFROM dbo.vwPerson \r\nWHERE BaPersonID = {0}" +
    "";
            //
            // chkMahnen
            //
            this.chkMahnen.DataMember = "IkSchuldnerMahnen";
            this.chkMahnen.DataSource = this.qryFaLeistung;
            this.chkMahnen.Location = new System.Drawing.Point(375, 12);
            this.chkMahnen.Name = "chkMahnen";
            this.chkMahnen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkMahnen.Properties.Appearance.Options.UseBackColor = true;
            this.chkMahnen.Properties.Caption = "Schuldner mahnen";
            this.chkMahnen.Properties.Name = "checkEditMahnlauf.Properties";
            this.chkMahnen.Size = new System.Drawing.Size(193, 19);
            this.chkMahnen.TabIndex = 1;
            //
            // edtSchuldnerPerson
            //
            this.edtSchuldnerPerson.DataMember = "SchuldnerBaPersonID";
            this.edtSchuldnerPerson.DataSource = this.qryFaLeistung;
            this.edtSchuldnerPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSchuldnerPerson.Location = new System.Drawing.Point(95, 12);
            this.edtSchuldnerPerson.Name = "edtSchuldnerPerson";
            this.edtSchuldnerPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSchuldnerPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSchuldnerPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSchuldnerPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtSchuldnerPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSchuldnerPerson.Properties.Appearance.Options.UseFont = true;
            this.edtSchuldnerPerson.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSchuldnerPerson.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSchuldnerPerson.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSchuldnerPerson.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSchuldnerPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtSchuldnerPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtSchuldnerPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSchuldnerPerson.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Person", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSchuldnerPerson.Properties.DataSource = this.qryPerson;
            this.edtSchuldnerPerson.Properties.DisplayMember = "Text";
            this.edtSchuldnerPerson.Properties.NullText = "";
            this.edtSchuldnerPerson.Properties.ReadOnly = true;
            this.edtSchuldnerPerson.Properties.ShowFooter = false;
            this.edtSchuldnerPerson.Properties.ShowHeader = false;
            this.edtSchuldnerPerson.Properties.ValueMember = "Code";
            this.edtSchuldnerPerson.Size = new System.Drawing.Size(254, 24);
            this.edtSchuldnerPerson.TabIndex = 0;
            //
            // qryPerson
            //
            this.qryPerson.HostControl = this;
            this.qryPerson.IsIdentityInsert = false;
            this.qryPerson.SelectStatement = resources.GetString("qryPerson.SelectStatement");
            //
            // lblRueckerstattung
            //
            this.lblRueckerstattung.Location = new System.Drawing.Point(10, 199);
            this.lblRueckerstattung.Name = "lblRueckerstattung";
            this.lblRueckerstattung.Size = new System.Drawing.Size(89, 24);
            this.lblRueckerstattung.TabIndex = 45;
            this.lblRueckerstattung.Text = "Rückerstattung";
            this.lblRueckerstattung.UseCompatibleTextRendering = true;
            //
            // edtIkRueckerstattungTypCode
            //
            this.edtIkRueckerstattungTypCode.DataMember = "IkRueckerstattungTypCode";
            this.edtIkRueckerstattungTypCode.DataSource = this.qryFaLeistung;
            this.edtIkRueckerstattungTypCode.Location = new System.Drawing.Point(105, 199);
            this.edtIkRueckerstattungTypCode.LOVName = "IkRueckerstattungTyp";
            this.edtIkRueckerstattungTypCode.Name = "edtIkRueckerstattungTypCode";
            this.edtIkRueckerstattungTypCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkRueckerstattungTypCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkRueckerstattungTypCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkRueckerstattungTypCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkRueckerstattungTypCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkRueckerstattungTypCode.Properties.Appearance.Options.UseFont = true;
            this.edtIkRueckerstattungTypCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIkRueckerstattungTypCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkRueckerstattungTypCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIkRueckerstattungTypCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIkRueckerstattungTypCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtIkRueckerstattungTypCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtIkRueckerstattungTypCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkRueckerstattungTypCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", null, 75)});
            this.edtIkRueckerstattungTypCode.Properties.DisplayMember = "Text";
            this.edtIkRueckerstattungTypCode.Properties.NullText = "";
            this.edtIkRueckerstattungTypCode.Properties.ShowFooter = false;
            this.edtIkRueckerstattungTypCode.Properties.ShowHeader = false;
            this.edtIkRueckerstattungTypCode.Properties.ValueMember = "Code";
            this.edtIkRueckerstattungTypCode.Size = new System.Drawing.Size(443, 24);
            this.edtIkRueckerstattungTypCode.TabIndex = 8;
            //
            // lblIkForderungstitelCode
            //
            this.lblIkForderungstitelCode.Location = new System.Drawing.Point(10, 229);
            this.lblIkForderungstitelCode.Name = "lblIkForderungstitelCode";
            this.lblIkForderungstitelCode.Size = new System.Drawing.Size(89, 24);
            this.lblIkForderungstitelCode.TabIndex = 47;
            this.lblIkForderungstitelCode.Text = "Forderungstitel";
            this.lblIkForderungstitelCode.UseCompatibleTextRendering = true;
            //
            // edtIkForderungstitelCode
            //
            this.edtIkForderungstitelCode.DataMember = "IkForderungTitelCode";
            this.edtIkForderungstitelCode.DataSource = this.qryFaLeistung;
            this.edtIkForderungstitelCode.Location = new System.Drawing.Point(105, 229);
            this.edtIkForderungstitelCode.LOVName = "IkForderungtitel";
            this.edtIkForderungstitelCode.Name = "edtIkForderungstitelCode";
            this.edtIkForderungstitelCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkForderungstitelCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkForderungstitelCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkForderungstitelCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkForderungstitelCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkForderungstitelCode.Properties.Appearance.Options.UseFont = true;
            this.edtIkForderungstitelCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIkForderungstitelCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkForderungstitelCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIkForderungstitelCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIkForderungstitelCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtIkForderungstitelCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtIkForderungstitelCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkForderungstitelCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", null, 75)});
            this.edtIkForderungstitelCode.Properties.DisplayMember = "Text";
            this.edtIkForderungstitelCode.Properties.NullText = "";
            this.edtIkForderungstitelCode.Properties.ShowFooter = false;
            this.edtIkForderungstitelCode.Properties.ShowHeader = false;
            this.edtIkForderungstitelCode.Properties.ValueMember = "Code";
            this.edtIkForderungstitelCode.Size = new System.Drawing.Size(443, 24);
            this.edtIkForderungstitelCode.TabIndex = 9;
            //
            // lblIkDatumRechtskraft
            //
            this.lblIkDatumRechtskraft.Location = new System.Drawing.Point(224, 259);
            this.lblIkDatumRechtskraft.Name = "lblIkDatumRechtskraft";
            this.lblIkDatumRechtskraft.Size = new System.Drawing.Size(135, 24);
            this.lblIkDatumRechtskraft.TabIndex = 49;
            this.lblIkDatumRechtskraft.Text = "Tritt in Rechtskraft am";
            this.lblIkDatumRechtskraft.UseCompatibleTextRendering = true;
            //
            // edtIkDatumRechtskraft
            //
            this.edtIkDatumRechtskraft.DataMember = "IkDatumRechtskraft";
            this.edtIkDatumRechtskraft.DataSource = this.qryFaLeistung;
            this.edtIkDatumRechtskraft.EditValue = null;
            this.edtIkDatumRechtskraft.Location = new System.Drawing.Point(365, 259);
            this.edtIkDatumRechtskraft.Name = "edtIkDatumRechtskraft";
            this.edtIkDatumRechtskraft.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtIkDatumRechtskraft.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkDatumRechtskraft.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkDatumRechtskraft.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkDatumRechtskraft.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkDatumRechtskraft.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkDatumRechtskraft.Properties.Appearance.Options.UseFont = true;
            this.edtIkDatumRechtskraft.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtIkDatumRechtskraft.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtIkDatumRechtskraft.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtIkDatumRechtskraft.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkDatumRechtskraft.Properties.ShowToday = false;
            this.edtIkDatumRechtskraft.Size = new System.Drawing.Size(100, 24);
            this.edtIkDatumRechtskraft.TabIndex = 11;
            //
            // lblIkDatumForderungstitel
            //
            this.lblIkDatumForderungstitel.Location = new System.Drawing.Point(10, 259);
            this.lblIkDatumForderungstitel.Name = "lblIkDatumForderungstitel";
            this.lblIkDatumForderungstitel.Size = new System.Drawing.Size(89, 24);
            this.lblIkDatumForderungstitel.TabIndex = 51;
            this.lblIkDatumForderungstitel.Text = "erstellt am";
            this.lblIkDatumForderungstitel.UseCompatibleTextRendering = true;
            //
            // edtIkDatumForderungstitel
            //
            this.edtIkDatumForderungstitel.DataMember = "IkDatumForderungstitel";
            this.edtIkDatumForderungstitel.DataSource = this.qryFaLeistung;
            this.edtIkDatumForderungstitel.EditValue = null;
            this.edtIkDatumForderungstitel.Location = new System.Drawing.Point(105, 259);
            this.edtIkDatumForderungstitel.Name = "edtIkDatumForderungstitel";
            this.edtIkDatumForderungstitel.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtIkDatumForderungstitel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkDatumForderungstitel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkDatumForderungstitel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkDatumForderungstitel.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkDatumForderungstitel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkDatumForderungstitel.Properties.Appearance.Options.UseFont = true;
            this.edtIkDatumForderungstitel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtIkDatumForderungstitel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtIkDatumForderungstitel.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtIkDatumForderungstitel.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkDatumForderungstitel.Properties.ShowToday = false;
            this.edtIkDatumForderungstitel.Size = new System.Drawing.Size(100, 24);
            this.edtIkDatumForderungstitel.TabIndex = 10;
            //
            // btnReopen
            //
            this.btnReopen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReopen.Location = new System.Drawing.Point(224, 48);
            this.btnReopen.Name = "btnReopen";
            this.btnReopen.Size = new System.Drawing.Size(118, 24);
            this.btnReopen.TabIndex = 1;
            this.btnReopen.Text = "Fall wieder öffnen";
            this.btnReopen.UseCompatibleTextRendering = true;
            this.btnReopen.UseVisualStyleBackColor = false;
            this.btnReopen.Click += new System.EventHandler(this.btnReopen_Click);
            //
            // lblZustaendigeGemeinde
            //
            this.lblZustaendigeGemeinde.Location = new System.Drawing.Point(10, 169);
            this.lblZustaendigeGemeinde.Name = "lblZustaendigeGemeinde";
            this.lblZustaendigeGemeinde.Size = new System.Drawing.Size(89, 24);
            this.lblZustaendigeGemeinde.TabIndex = 55;
            this.lblZustaendigeGemeinde.Text = "zust. Gemeinde";
            this.lblZustaendigeGemeinde.UseCompatibleTextRendering = true;
            //
            // edtZustaendigeGemeinde
            //
            this.edtZustaendigeGemeinde.AllowNull = false;
            this.edtZustaendigeGemeinde.DataMember = "GemeindeCode";
            this.edtZustaendigeGemeinde.DataSource = this.qryFaLeistung;
            this.edtZustaendigeGemeinde.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtZustaendigeGemeinde.Location = new System.Drawing.Point(105, 169);
            this.edtZustaendigeGemeinde.LOVFilter = "(Value3 IS NULL OR \',\' + Value3 + \',\' LIKE \'%,I,%\')";
            this.edtZustaendigeGemeinde.LOVFilterWhereAppend = true;
            this.edtZustaendigeGemeinde.LOVName = "GemeindeSozialdienst";
            this.edtZustaendigeGemeinde.Name = "edtZustaendigeGemeinde";
            this.edtZustaendigeGemeinde.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtZustaendigeGemeinde.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustaendigeGemeinde.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigeGemeinde.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustaendigeGemeinde.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustaendigeGemeinde.Properties.Appearance.Options.UseFont = true;
            this.edtZustaendigeGemeinde.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZustaendigeGemeinde.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigeGemeinde.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZustaendigeGemeinde.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZustaendigeGemeinde.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtZustaendigeGemeinde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtZustaendigeGemeinde.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZustaendigeGemeinde.Properties.NullText = "";
            this.edtZustaendigeGemeinde.Properties.ShowFooter = false;
            this.edtZustaendigeGemeinde.Properties.ShowHeader = false;
            this.edtZustaendigeGemeinde.Size = new System.Drawing.Size(205, 24);
            this.edtZustaendigeGemeinde.TabIndex = 7;
            //
            // CtlIkLeistung
            //
            this.ActiveSQLQuery = this.qryFaLeistung;
            this.Controls.Add(this.lblZustaendigeGemeinde);
            this.Controls.Add(this.edtZustaendigeGemeinde);
            this.Controls.Add(this.btnReopen);
            this.Controls.Add(this.edtIkDatumForderungstitel);
            this.Controls.Add(this.lblIkDatumForderungstitel);
            this.Controls.Add(this.edtIkDatumRechtskraft);
            this.Controls.Add(this.lblIkDatumRechtskraft);
            this.Controls.Add(this.edtIkForderungstitelCode);
            this.Controls.Add(this.lblIkForderungstitelCode);
            this.Controls.Add(this.edtIkRueckerstattungTypCode);
            this.Controls.Add(this.lblRueckerstattung);
            this.Controls.Add(this.pnlHideInAbklaerung);
            this.Controls.Add(this.lblBezeichnung);
            this.Controls.Add(this.lblAbschlussGrundCode);
            this.Controls.Add(this.lblEroeffnungsGrundCode);
            this.Controls.Add(this.lblSAR);
            this.Controls.Add(this.pnTitle);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.edtAbschlussGrundCode);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.edtEroeffnungsGrundCode);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.edtBezeichnung);
            this.Controls.Add(this.editSAR);
            this.Name = "CtlIkLeistung";
            this.Size = new System.Drawing.Size(646, 758);
            ((System.ComponentModel.ISupportInitialize)(this.editSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezeichnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsGrundCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungsGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezeichnung)).EndInit();
            this.pnlHideInAbklaerung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblIkVerjaehrungAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkVerjaehrungAm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkInkassoBemuehung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkInkassoBemuehungCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkInkassoBemuehungCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchuldnerStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFremdSD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblQuote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBegruendung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchuldner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAiBegrErreichungsGradCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAiBegrErreichungsGradCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtQuote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtQuote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchuldnerStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchuldnerStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFremdSD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAdresse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMahnen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchuldnerPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchuldnerPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRueckerstattung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRueckerstattungTypCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRueckerstattungTypCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkForderungstitelCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkForderungstitelCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkForderungstitelCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkDatumRechtskraft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkDatumRechtskraft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkDatumForderungstitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkDatumForderungstitel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigeGemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeinde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigeGemeinde)).EndInit();
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

        private bool IsLeistungAbklaerung
        {
            get { return Utils.ConvertToInt(qryFaLeistung["FaProzessCode"]) == 400; }
        }

        private bool IsLeistungAlimente
        {
            get { return Utils.ConvertToInt(qryFaLeistung["FaProzessCode"]) == 401; }
        }

        private bool IsLeistungRueckerstattung
        {
            get { return Utils.ConvertToInt(qryFaLeistung["FaProzessCode"]) == 403; }
        }

        #endregion

        #region EventHandlers

        private void btnReopen_Click(object sender, System.EventArgs e)
        {
            if (KissMsg.ShowQuestion("CtlFaBeratungsperiode", "FallverlaufWiederOeffnen", "Soll der geschlossene Fallverlauf wieder geöffnet werden ?"))
            {
                qryFaLeistung.CanUpdate = true;
                qryFaLeistung["DatumBis"] = DBNull.Value;
                qryFaLeistung.Post();
            }
        }

        private void edtSchuldnerPerson_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            e.AcceptValue = true;
            if (!e.CloseMode.Equals(DevExpress.XtraEditors.PopupCloseMode.Normal))
            {
                return;
            }
            // Adresse neu holen:
            qryFaLeistung["SchuldnerBaPersonID"] = e.Value;
            qryFaLeistung_PositionChanged(sender, null);
        }

        private void qryFaLeistung_AfterDelete(object sender, System.EventArgs e)
        {
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void qryFaLeistung_AfterFill(object sender, System.EventArgs e)
        {
            if (qryFaLeistung.Count == 0)
            {
                qryFaLeistung_PositionChanged(sender, e);
            }
        }

        private void qryFaLeistung_AfterPost(object sender, System.EventArgs e)
        {
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            this.SetFieldVisibility();
            qryFaLeistung.EnableBoundFields(DBUtil.IsEmpty(qryFaLeistung["DatumBis"]));
        }

        private void qryFaLeistung_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);
            DBUtil.CheckNotNullField(edtZustaendigeGemeinde, lblZustaendigeGemeinde.Text);

            // Kontrollieren, dass Datum von kleiner als Datum bis ist:
            if (!DBUtil.IsEmpty(qryFaLeistung["DatumVon"]) && !DBUtil.IsEmpty(qryFaLeistung["DatumBis"]))
            {
                if ((DateTime)qryFaLeistung["DatumVon"] >= (DateTime)qryFaLeistung["DatumBis"])
                {
                    KissMsg.ShowInfo("CtlIkLeistung", "DatumsFehler",
                      "Das Von-Datum muss kleiner sein als das Bis-Datum.");
                    throw new KissCancelException();
                }
            }

            if (!DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.DatumBis]))
            {
                string Msg = "";

                //Kontrolle: existieren offene Pendenzen?
                int countPendenzen = Utils.GetAnzahlOffenePendenzen((int)qryFaLeistung[DBO.FaLeistung.FaLeistungID]);
                if (countPendenzen > 0)
                {
                    Msg = string.Format(
                        "Es existieren {0} offene Pendenzen zu der abzuschliessenden Leistung.", countPendenzen);
                    KissMsg.ShowInfo(Msg);
                }
            }
        }

        private void qryFaLeistung_PositionChanged(object sender, System.EventArgs e)
        {
            qryAdresse.Fill(Utils.ConvertToInt(qryFaLeistung["SchuldnerBaPersonID"]));
        }

        #endregion

        #region Methods

        #region Private Methods

        private void SetFieldVisibility()
        {
            //für Abklärungen müssen einige Felder ausgeblendet werden
            pnlHideInAbklaerung.Visible = !(bool)qryFaLeistung["IstAbklaerung"];

            //Nur für Alim / Abklärung sichtbare Felder
            edtEroeffnungsGrundCode.Visible = this.IsLeistungAlimente;
            lblEroeffnungsGrundCode.Visible = this.IsLeistungAlimente;

            //Nur für Rückerstattung sichtbare Felder
            lblRueckerstattung.Visible = this.IsLeistungRueckerstattung;
            edtIkRueckerstattungTypCode.Visible = this.IsLeistungRueckerstattung;
            lblIkForderungstitelCode.Visible = this.IsLeistungRueckerstattung;
            edtIkForderungstitelCode.Visible = this.IsLeistungRueckerstattung;
            lblIkDatumForderungstitel.Visible = this.IsLeistungRueckerstattung;
            edtIkDatumForderungstitel.Visible = this.IsLeistungRueckerstattung;
            lblIkDatumRechtskraft.Visible = this.IsLeistungRueckerstattung;
            edtIkDatumRechtskraft.Visible = this.IsLeistungRueckerstattung;

            this.btnReopen.Visible = !DBUtil.IsEmpty(qryFaLeistung["DatumBis"]);

            //Felder ausblenden
            edtQuote.Visible = Utils.ConvertToInt(qryFaLeistung["FaProzessCode"]) != 402 && Utils.ConvertToInt(qryFaLeistung["FaProzessCode"]) != 403 && Utils.ConvertToInt(qryFaLeistung["FaProzessCode"]) != 404 && Utils.ConvertToInt(qryFaLeistung["FaProzessCode"]) != 406 && Utils.ConvertToInt(qryFaLeistung["FaProzessCode"]) != 407;
            lblQuote.Visible = edtQuote.Visible;
            editAiBegrErreichungsGradCode.Visible = edtQuote.Visible;
            lblBegruendung.Visible = edtQuote.Visible;

            // ausblenden Für nur Inkasso (406)
            chkRente.Visible = Utils.ConvertToInt(qryFaLeistung["FaProzessCode"]) != 406;
            chkFremdSD.Visible = Utils.ConvertToInt(qryFaLeistung["FaProzessCode"]) != 406;
            lblFremdSD.Visible = Utils.ConvertToInt(qryFaLeistung["FaProzessCode"]) != 406;

            edtAufenthaltsart.Visible = Utils.ConvertToInt(qryFaLeistung["FaProzessCode"]) != 406;
            lblAufenthaltStatus.Visible = Utils.ConvertToInt(qryFaLeistung["FaProzessCode"]) != 406;

            edtSchuldnerStatus.Visible = Utils.ConvertToInt(qryFaLeistung["FaProzessCode"]) != 406;
            lblSchuldnerStatus.Visible = Utils.ConvertToInt(qryFaLeistung["FaProzessCode"]) != 406;
        }

        #endregion

        #endregion
    }
}