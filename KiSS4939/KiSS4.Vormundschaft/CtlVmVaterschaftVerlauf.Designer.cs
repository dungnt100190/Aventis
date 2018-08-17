using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Vormundschaft
{
    partial class CtlVmVaterschaftVerlauf
    {
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVmVaterschaftVerlauf));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryVmVaterschaft = new KiSS4.DB.SqlQuery(this.components);
            this.lblTitel = new System.Windows.Forms.Label();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.edtUHVAbschlussGrundCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblUHVAbschlussGrundCode = new KiSS4.Gui.KissLabel();
            this.edtAnerkennungOrt = new KiSS4.Gui.KissTextEdit();
            this.edtAnerkennungDatum = new KiSS4.Gui.KissDateEdit();
            this.lblUHVBetragCHF = new KiSS4.Gui.KissLabel();
            this.edtUHVBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblUHVBetrag = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtZGBCodes = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblZGBArtikel = new KiSS4.Gui.KissLabel();
            this.lblAnerkennung = new KiSS4.Gui.KissLabel();
            this.lblAnerkennungOrt = new KiSS4.Gui.KissLabel();
            this.lblAnerkennungDatum = new KiSS4.Gui.KissLabel();
            this.lblUnterhaltsvertrag = new KiSS4.Gui.KissLabel();
            this.lblUHVDatum = new KiSS4.Gui.KissLabel();
            this.edtUHVDatum = new KiSS4.Gui.KissDateEdit();
            this.lblSorgerechtVereinbarung = new KiSS4.Gui.KissLabel();
            this.lblSorgerechtVereinbDatum = new KiSS4.Gui.KissLabel();
            this.edtSorgerechtVereinbDatum = new KiSS4.Gui.KissDateEdit();
            this.lblVaterschaftsurteil = new KiSS4.Gui.KissLabel();
            this.lblVUrteilDatum = new KiSS4.Gui.KissLabel();
            this.edtVUrteilDatum = new KiSS4.Gui.KissDateEdit();
            this.lblVAnfechtungsurteil = new KiSS4.Gui.KissLabel();
            this.edtVAnfechtungsurteil = new KiSS4.Gui.KissDateEdit();
            this.lblUnterhaltsurteilBetragCHF = new KiSS4.Gui.KissLabel();
            this.edtUnterhaltsurteilBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblUnterhaltsurteilBetrag = new KiSS4.Gui.KissLabel();
            this.lblUnterhaltsurteilDatum = new KiSS4.Gui.KissLabel();
            this.edtUnterhaltsurteilDatum = new KiSS4.Gui.KissDateEdit();
            this.lblUnterhaltsurteil = new KiSS4.Gui.KissLabel();
            this.lblSchlussberichtGenehmigung = new KiSS4.Gui.KissLabel();
            this.edtSchlussberichtGenehmigung = new KiSS4.Gui.KissDateEdit();
            this.lblSchlussberichtAnKommission = new KiSS4.Gui.KissLabel();
            this.edtSchlussberichtAnKommission = new KiSS4.Gui.KissDateEdit();
            this.lblSchlussbericht = new KiSS4.Gui.KissLabel();
            this.lblAnfechtung = new KiSS4.Gui.KissLabel();
            this.lblPendenzText = new KiSS4.Gui.KissLabel();
            this.lblPendenz = new KiSS4.Gui.KissLabel();
            this.lblPendenzFrist = new KiSS4.Gui.KissLabel();
            this.edtPendenzText = new KiSS4.Gui.KissTextEdit();
            this.edtPendenzFrist = new KiSS4.Gui.KissDateEdit();
            this.lblGebuehrErlass = new KiSS4.Gui.KissLabel();
            this.lblGebuehrDatum = new KiSS4.Gui.KissLabel();
            this.lblGebuehr = new KiSS4.Gui.KissLabel();
            this.edtGebuehrDatum = new KiSS4.Gui.KissDateEdit();
            this.edtGebuehrErlass = new KiSS4.Gui.KissCheckEdit();
            this.lblGeburtsmitteilungDatum = new KiSS4.Gui.KissLabel();
            this.lblGeburtsmitteilungOrt = new KiSS4.Gui.KissLabel();
            this.lblGeburtsmitteilung = new KiSS4.Gui.KissLabel();
            this.edtGeburtsmitteilungDatum = new KiSS4.Gui.KissDateEdit();
            this.edtGeburtsmitteilungOrt = new KiSS4.Gui.KissTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmVaterschaft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUHVAbschlussGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUHVAbschlussGrundCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUHVAbschlussGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnerkennungOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnerkennungDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUHVBetragCHF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUHVBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUHVBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZGBCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZGBArtikel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnerkennung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnerkennungOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnerkennungDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterhaltsvertrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUHVDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUHVDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSorgerechtVereinbarung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSorgerechtVereinbDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSorgerechtVereinbDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVaterschaftsurteil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVUrteilDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVUrteilDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVAnfechtungsurteil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVAnfechtungsurteil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterhaltsurteilBetragCHF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterhaltsurteilBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterhaltsurteilBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterhaltsurteilDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterhaltsurteilDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterhaltsurteil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchlussberichtGenehmigung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchlussberichtGenehmigung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchlussberichtAnKommission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchlussberichtAnKommission.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchlussbericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnfechtung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPendenzText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPendenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPendenzFrist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPendenzText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPendenzFrist.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGebuehrErlass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGebuehrDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGebuehr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGebuehrDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGebuehrErlass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsmitteilungDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsmitteilungOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsmitteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsmitteilungDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsmitteilungOrt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryVmVaterschaft
            // 
            this.qryVmVaterschaft.CanUpdate = true;
            this.qryVmVaterschaft.HostControl = this;
            this.qryVmVaterschaft.TableName = "VmVaterschaft";
            this.qryVmVaterschaft.AfterInsert += new System.EventHandler(this.qryVmVaterschaft_AfterInsert);
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 0;
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
            // edtUHVAbschlussGrundCode
            // 
            this.edtUHVAbschlussGrundCode.DataMember = "UHVAbschlussGrundCode";
            this.edtUHVAbschlussGrundCode.DataSource = this.qryVmVaterschaft;
            this.edtUHVAbschlussGrundCode.Location = new System.Drawing.Point(90, 400);
            this.edtUHVAbschlussGrundCode.LOVName = "VmUHVAbschlussGrund";
            this.edtUHVAbschlussGrundCode.Name = "edtUHVAbschlussGrundCode";
            this.edtUHVAbschlussGrundCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUHVAbschlussGrundCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUHVAbschlussGrundCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUHVAbschlussGrundCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtUHVAbschlussGrundCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUHVAbschlussGrundCode.Properties.Appearance.Options.UseFont = true;
            this.edtUHVAbschlussGrundCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtUHVAbschlussGrundCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtUHVAbschlussGrundCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtUHVAbschlussGrundCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtUHVAbschlussGrundCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtUHVAbschlussGrundCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtUHVAbschlussGrundCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUHVAbschlussGrundCode.Properties.NullText = "";
            this.edtUHVAbschlussGrundCode.Properties.ShowFooter = false;
            this.edtUHVAbschlussGrundCode.Properties.ShowHeader = false;
            this.edtUHVAbschlussGrundCode.Size = new System.Drawing.Size(627, 24);
            this.edtUHVAbschlussGrundCode.TabIndex = 50;
            // 
            // lblUHVAbschlussGrundCode
            // 
            this.lblUHVAbschlussGrundCode.Location = new System.Drawing.Point(5, 400);
            this.lblUHVAbschlussGrundCode.Name = "lblUHVAbschlussGrundCode";
            this.lblUHVAbschlussGrundCode.Size = new System.Drawing.Size(84, 24);
            this.lblUHVAbschlussGrundCode.TabIndex = 49;
            this.lblUHVAbschlussGrundCode.Tag = "";
            this.lblUHVAbschlussGrundCode.Text = "Abschl.-Grund";
            // 
            // edtAnerkennungOrt
            // 
            this.edtAnerkennungOrt.DataMember = "AnerkennungOrt";
            this.edtAnerkennungOrt.DataSource = this.qryVmVaterschaft;
            this.edtAnerkennungOrt.Location = new System.Drawing.Point(90, 85);
            this.edtAnerkennungOrt.Name = "edtAnerkennungOrt";
            this.edtAnerkennungOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnerkennungOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnerkennungOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnerkennungOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnerkennungOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnerkennungOrt.Properties.Appearance.Options.UseFont = true;
            this.edtAnerkennungOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnerkennungOrt.Size = new System.Drawing.Size(159, 24);
            this.edtAnerkennungOrt.TabIndex = 5;
            // 
            // edtAnerkennungDatum
            // 
            this.edtAnerkennungDatum.DataMember = "AnerkennungDatum";
            this.edtAnerkennungDatum.DataSource = this.qryVmVaterschaft;
            this.edtAnerkennungDatum.EditValue = null;
            this.edtAnerkennungDatum.Location = new System.Drawing.Point(90, 60);
            this.edtAnerkennungDatum.Name = "edtAnerkennungDatum";
            this.edtAnerkennungDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnerkennungDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnerkennungDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnerkennungDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnerkennungDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnerkennungDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnerkennungDatum.Properties.Appearance.Options.UseFont = true;
            this.edtAnerkennungDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtAnerkennungDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAnerkennungDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtAnerkennungDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnerkennungDatum.Properties.ShowToday = false;
            this.edtAnerkennungDatum.Size = new System.Drawing.Size(90, 24);
            this.edtAnerkennungDatum.TabIndex = 3;
            // 
            // lblUHVBetragCHF
            // 
            this.lblUHVBetragCHF.Location = new System.Drawing.Point(455, 85);
            this.lblUHVBetragCHF.Name = "lblUHVBetragCHF";
            this.lblUHVBetragCHF.Size = new System.Drawing.Size(30, 24);
            this.lblUHVBetragCHF.TabIndex = 20;
            this.lblUHVBetragCHF.Tag = "";
            this.lblUHVBetragCHF.Text = "CHF";
            // 
            // edtUHVBetrag
            // 
            this.edtUHVBetrag.DataMember = "UHVBetrag";
            this.edtUHVBetrag.DataSource = this.qryVmVaterschaft;
            this.edtUHVBetrag.Location = new System.Drawing.Point(360, 85);
            this.edtUHVBetrag.Name = "edtUHVBetrag";
            this.edtUHVBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUHVBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUHVBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUHVBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUHVBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtUHVBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUHVBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtUHVBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUHVBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUHVBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtUHVBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtUHVBetrag.Properties.EditFormat.FormatString = "N2";
            this.edtUHVBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtUHVBetrag.Size = new System.Drawing.Size(90, 24);
            this.edtUHVBetrag.TabIndex = 19;
            // 
            // lblUHVBetrag
            // 
            this.lblUHVBetrag.Location = new System.Drawing.Point(265, 85);
            this.lblUHVBetrag.Name = "lblUHVBetrag";
            this.lblUHVBetrag.Size = new System.Drawing.Size(36, 24);
            this.lblUHVBetrag.TabIndex = 18;
            this.lblUHVBetrag.Tag = "";
            this.lblUHVBetrag.Text = "Betrag";
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryVmVaterschaft;
            this.edtBemerkung.Location = new System.Drawing.Point(90, 430);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(627, 111);
            this.edtBemerkung.TabIndex = 52;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(5, 430);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(60, 24);
            this.lblBemerkung.TabIndex = 51;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // edtZGBCodes
            // 
            this.edtZGBCodes.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtZGBCodes.Appearance.Options.UseBackColor = true;
            this.edtZGBCodes.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtZGBCodes.CheckOnClick = true;
            this.edtZGBCodes.DataMember = "ZGBCodes";
            this.edtZGBCodes.DataSource = this.qryVmVaterschaft;
            this.edtZGBCodes.Location = new System.Drawing.Point(495, 55);
            this.edtZGBCodes.LOVFilter = "2";
            this.edtZGBCodes.LOVName = "VmZGB";
            this.edtZGBCodes.Name = "edtZGBCodes";
            this.edtZGBCodes.Size = new System.Drawing.Size(186, 73);
            this.edtZGBCodes.TabIndex = 33;
            // 
            // lblZGBArtikel
            // 
            this.lblZGBArtikel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblZGBArtikel.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblZGBArtikel.Location = new System.Drawing.Point(495, 40);
            this.lblZGBArtikel.Name = "lblZGBArtikel";
            this.lblZGBArtikel.Size = new System.Drawing.Size(74, 16);
            this.lblZGBArtikel.TabIndex = 32;
            this.lblZGBArtikel.Text = "ZGB-Artikel";
            // 
            // lblAnerkennung
            // 
            this.lblAnerkennung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblAnerkennung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblAnerkennung.Location = new System.Drawing.Point(5, 40);
            this.lblAnerkennung.Name = "lblAnerkennung";
            this.lblAnerkennung.Size = new System.Drawing.Size(88, 16);
            this.lblAnerkennung.TabIndex = 1;
            this.lblAnerkennung.Text = "Anerkennung";
            // 
            // lblAnerkennungOrt
            // 
            this.lblAnerkennungOrt.Location = new System.Drawing.Point(5, 85);
            this.lblAnerkennungOrt.Name = "lblAnerkennungOrt";
            this.lblAnerkennungOrt.Size = new System.Drawing.Size(62, 24);
            this.lblAnerkennungOrt.TabIndex = 4;
            this.lblAnerkennungOrt.Tag = "";
            this.lblAnerkennungOrt.Text = "Ort";
            // 
            // lblAnerkennungDatum
            // 
            this.lblAnerkennungDatum.Location = new System.Drawing.Point(5, 60);
            this.lblAnerkennungDatum.Name = "lblAnerkennungDatum";
            this.lblAnerkennungDatum.Size = new System.Drawing.Size(40, 24);
            this.lblAnerkennungDatum.TabIndex = 2;
            this.lblAnerkennungDatum.Tag = "";
            this.lblAnerkennungDatum.Text = "Datum";
            // 
            // lblUnterhaltsvertrag
            // 
            this.lblUnterhaltsvertrag.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUnterhaltsvertrag.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUnterhaltsvertrag.Location = new System.Drawing.Point(265, 40);
            this.lblUnterhaltsvertrag.Name = "lblUnterhaltsvertrag";
            this.lblUnterhaltsvertrag.Size = new System.Drawing.Size(112, 16);
            this.lblUnterhaltsvertrag.TabIndex = 15;
            this.lblUnterhaltsvertrag.Text = "Unterhaltsvertrag";
            // 
            // lblUHVDatum
            // 
            this.lblUHVDatum.Location = new System.Drawing.Point(265, 60);
            this.lblUHVDatum.Name = "lblUHVDatum";
            this.lblUHVDatum.Size = new System.Drawing.Size(40, 24);
            this.lblUHVDatum.TabIndex = 16;
            this.lblUHVDatum.Tag = "";
            this.lblUHVDatum.Text = "Datum";
            // 
            // edtUHVDatum
            // 
            this.edtUHVDatum.DataMember = "UHVDatum";
            this.edtUHVDatum.DataSource = this.qryVmVaterschaft;
            this.edtUHVDatum.EditValue = null;
            this.edtUHVDatum.Location = new System.Drawing.Point(360, 60);
            this.edtUHVDatum.Name = "edtUHVDatum";
            this.edtUHVDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUHVDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUHVDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUHVDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUHVDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtUHVDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUHVDatum.Properties.Appearance.Options.UseFont = true;
            this.edtUHVDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtUHVDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtUHVDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtUHVDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUHVDatum.Properties.ShowToday = false;
            this.edtUHVDatum.Size = new System.Drawing.Size(90, 24);
            this.edtUHVDatum.TabIndex = 17;
            // 
            // lblSorgerechtVereinbarung
            // 
            this.lblSorgerechtVereinbarung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSorgerechtVereinbarung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSorgerechtVereinbarung.Location = new System.Drawing.Point(5, 250);
            this.lblSorgerechtVereinbarung.Name = "lblSorgerechtVereinbarung";
            this.lblSorgerechtVereinbarung.Size = new System.Drawing.Size(158, 16);
            this.lblSorgerechtVereinbarung.TabIndex = 12;
            this.lblSorgerechtVereinbarung.Text = "Sorgerecht-Vereinbarung";
            // 
            // lblSorgerechtVereinbDatum
            // 
            this.lblSorgerechtVereinbDatum.Location = new System.Drawing.Point(5, 270);
            this.lblSorgerechtVereinbDatum.Name = "lblSorgerechtVereinbDatum";
            this.lblSorgerechtVereinbDatum.Size = new System.Drawing.Size(40, 24);
            this.lblSorgerechtVereinbDatum.TabIndex = 13;
            this.lblSorgerechtVereinbDatum.Tag = "";
            this.lblSorgerechtVereinbDatum.Text = "Datum";
            // 
            // edtSorgerechtVereinbDatum
            // 
            this.edtSorgerechtVereinbDatum.DataMember = "SorgerechtVereinbDatum";
            this.edtSorgerechtVereinbDatum.DataSource = this.qryVmVaterschaft;
            this.edtSorgerechtVereinbDatum.EditValue = null;
            this.edtSorgerechtVereinbDatum.Location = new System.Drawing.Point(90, 270);
            this.edtSorgerechtVereinbDatum.Name = "edtSorgerechtVereinbDatum";
            this.edtSorgerechtVereinbDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSorgerechtVereinbDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSorgerechtVereinbDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSorgerechtVereinbDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSorgerechtVereinbDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtSorgerechtVereinbDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSorgerechtVereinbDatum.Properties.Appearance.Options.UseFont = true;
            this.edtSorgerechtVereinbDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSorgerechtVereinbDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSorgerechtVereinbDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSorgerechtVereinbDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSorgerechtVereinbDatum.Properties.ShowToday = false;
            this.edtSorgerechtVereinbDatum.Size = new System.Drawing.Size(90, 24);
            this.edtSorgerechtVereinbDatum.TabIndex = 14;
            // 
            // lblVaterschaftsurteil
            // 
            this.lblVaterschaftsurteil.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblVaterschaftsurteil.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblVaterschaftsurteil.Location = new System.Drawing.Point(5, 130);
            this.lblVaterschaftsurteil.Name = "lblVaterschaftsurteil";
            this.lblVaterschaftsurteil.Size = new System.Drawing.Size(110, 16);
            this.lblVaterschaftsurteil.TabIndex = 6;
            this.lblVaterschaftsurteil.Text = "Vaterschaftsurteil";
            // 
            // lblVUrteilDatum
            // 
            this.lblVUrteilDatum.Location = new System.Drawing.Point(5, 150);
            this.lblVUrteilDatum.Name = "lblVUrteilDatum";
            this.lblVUrteilDatum.Size = new System.Drawing.Size(40, 24);
            this.lblVUrteilDatum.TabIndex = 7;
            this.lblVUrteilDatum.Tag = "";
            this.lblVUrteilDatum.Text = "Datum";
            // 
            // edtVUrteilDatum
            // 
            this.edtVUrteilDatum.DataMember = "VUrteilDatum";
            this.edtVUrteilDatum.DataSource = this.qryVmVaterschaft;
            this.edtVUrteilDatum.EditValue = null;
            this.edtVUrteilDatum.Location = new System.Drawing.Point(90, 150);
            this.edtVUrteilDatum.Name = "edtVUrteilDatum";
            this.edtVUrteilDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVUrteilDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVUrteilDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVUrteilDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVUrteilDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtVUrteilDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVUrteilDatum.Properties.Appearance.Options.UseFont = true;
            this.edtVUrteilDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtVUrteilDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVUrteilDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtVUrteilDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVUrteilDatum.Properties.ShowToday = false;
            this.edtVUrteilDatum.Size = new System.Drawing.Size(90, 24);
            this.edtVUrteilDatum.TabIndex = 8;
            // 
            // lblVAnfechtungsurteil
            // 
            this.lblVAnfechtungsurteil.Location = new System.Drawing.Point(5, 210);
            this.lblVAnfechtungsurteil.Name = "lblVAnfechtungsurteil";
            this.lblVAnfechtungsurteil.Size = new System.Drawing.Size(60, 24);
            this.lblVAnfechtungsurteil.TabIndex = 10;
            this.lblVAnfechtungsurteil.Tag = "";
            this.lblVAnfechtungsurteil.Text = "Datum";
            // 
            // edtVAnfechtungsurteil
            // 
            this.edtVAnfechtungsurteil.DataMember = "VAnfechtungsurteil";
            this.edtVAnfechtungsurteil.DataSource = this.qryVmVaterschaft;
            this.edtVAnfechtungsurteil.EditValue = null;
            this.edtVAnfechtungsurteil.Location = new System.Drawing.Point(90, 210);
            this.edtVAnfechtungsurteil.Name = "edtVAnfechtungsurteil";
            this.edtVAnfechtungsurteil.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVAnfechtungsurteil.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVAnfechtungsurteil.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVAnfechtungsurteil.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVAnfechtungsurteil.Properties.Appearance.Options.UseBackColor = true;
            this.edtVAnfechtungsurteil.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVAnfechtungsurteil.Properties.Appearance.Options.UseFont = true;
            this.edtVAnfechtungsurteil.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtVAnfechtungsurteil.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVAnfechtungsurteil.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtVAnfechtungsurteil.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVAnfechtungsurteil.Properties.ShowToday = false;
            this.edtVAnfechtungsurteil.Size = new System.Drawing.Size(90, 24);
            this.edtVAnfechtungsurteil.TabIndex = 11;
            // 
            // lblUnterhaltsurteilBetragCHF
            // 
            this.lblUnterhaltsurteilBetragCHF.Location = new System.Drawing.Point(455, 179);
            this.lblUnterhaltsurteilBetragCHF.Name = "lblUnterhaltsurteilBetragCHF";
            this.lblUnterhaltsurteilBetragCHF.Size = new System.Drawing.Size(30, 24);
            this.lblUnterhaltsurteilBetragCHF.TabIndex = 26;
            this.lblUnterhaltsurteilBetragCHF.Tag = "";
            this.lblUnterhaltsurteilBetragCHF.Text = "CHF";
            // 
            // edtUnterhaltsurteilBetrag
            // 
            this.edtUnterhaltsurteilBetrag.DataMember = "UnterhaltsurteilBetrag";
            this.edtUnterhaltsurteilBetrag.DataSource = this.qryVmVaterschaft;
            this.edtUnterhaltsurteilBetrag.Location = new System.Drawing.Point(360, 179);
            this.edtUnterhaltsurteilBetrag.Name = "edtUnterhaltsurteilBetrag";
            this.edtUnterhaltsurteilBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUnterhaltsurteilBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUnterhaltsurteilBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUnterhaltsurteilBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUnterhaltsurteilBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtUnterhaltsurteilBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUnterhaltsurteilBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtUnterhaltsurteilBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUnterhaltsurteilBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUnterhaltsurteilBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtUnterhaltsurteilBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtUnterhaltsurteilBetrag.Size = new System.Drawing.Size(90, 24);
            this.edtUnterhaltsurteilBetrag.TabIndex = 25;
            // 
            // lblUnterhaltsurteilBetrag
            // 
            this.lblUnterhaltsurteilBetrag.Location = new System.Drawing.Point(265, 179);
            this.lblUnterhaltsurteilBetrag.Name = "lblUnterhaltsurteilBetrag";
            this.lblUnterhaltsurteilBetrag.Size = new System.Drawing.Size(36, 24);
            this.lblUnterhaltsurteilBetrag.TabIndex = 24;
            this.lblUnterhaltsurteilBetrag.Tag = "";
            this.lblUnterhaltsurteilBetrag.Text = "Betrag";
            // 
            // lblUnterhaltsurteilDatum
            // 
            this.lblUnterhaltsurteilDatum.Location = new System.Drawing.Point(265, 154);
            this.lblUnterhaltsurteilDatum.Name = "lblUnterhaltsurteilDatum";
            this.lblUnterhaltsurteilDatum.Size = new System.Drawing.Size(40, 24);
            this.lblUnterhaltsurteilDatum.TabIndex = 22;
            this.lblUnterhaltsurteilDatum.Tag = "";
            this.lblUnterhaltsurteilDatum.Text = "Datum";
            // 
            // edtUnterhaltsurteilDatum
            // 
            this.edtUnterhaltsurteilDatum.DataMember = "UnterhaltsurteilDatum";
            this.edtUnterhaltsurteilDatum.DataSource = this.qryVmVaterschaft;
            this.edtUnterhaltsurteilDatum.EditValue = null;
            this.edtUnterhaltsurteilDatum.Location = new System.Drawing.Point(360, 154);
            this.edtUnterhaltsurteilDatum.Name = "edtUnterhaltsurteilDatum";
            this.edtUnterhaltsurteilDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUnterhaltsurteilDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUnterhaltsurteilDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUnterhaltsurteilDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUnterhaltsurteilDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtUnterhaltsurteilDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUnterhaltsurteilDatum.Properties.Appearance.Options.UseFont = true;
            this.edtUnterhaltsurteilDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtUnterhaltsurteilDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtUnterhaltsurteilDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtUnterhaltsurteilDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUnterhaltsurteilDatum.Properties.ShowToday = false;
            this.edtUnterhaltsurteilDatum.Size = new System.Drawing.Size(90, 24);
            this.edtUnterhaltsurteilDatum.TabIndex = 23;
            // 
            // lblUnterhaltsurteil
            // 
            this.lblUnterhaltsurteil.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUnterhaltsurteil.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUnterhaltsurteil.Location = new System.Drawing.Point(265, 134);
            this.lblUnterhaltsurteil.Name = "lblUnterhaltsurteil";
            this.lblUnterhaltsurteil.Size = new System.Drawing.Size(100, 16);
            this.lblUnterhaltsurteil.TabIndex = 21;
            this.lblUnterhaltsurteil.Text = "Unterhaltsurteil";
            // 
            // lblSchlussberichtGenehmigung
            // 
            this.lblSchlussberichtGenehmigung.Location = new System.Drawing.Point(265, 269);
            this.lblSchlussberichtGenehmigung.Name = "lblSchlussberichtGenehmigung";
            this.lblSchlussberichtGenehmigung.Size = new System.Drawing.Size(76, 24);
            this.lblSchlussberichtGenehmigung.TabIndex = 30;
            this.lblSchlussberichtGenehmigung.Tag = "";
            this.lblSchlussberichtGenehmigung.Text = "Genehmigung";
            // 
            // edtSchlussberichtGenehmigung
            // 
            this.edtSchlussberichtGenehmigung.DataMember = "SchlussberichtGenehmigung";
            this.edtSchlussberichtGenehmigung.DataSource = this.qryVmVaterschaft;
            this.edtSchlussberichtGenehmigung.EditValue = null;
            this.edtSchlussberichtGenehmigung.Location = new System.Drawing.Point(360, 269);
            this.edtSchlussberichtGenehmigung.Name = "edtSchlussberichtGenehmigung";
            this.edtSchlussberichtGenehmigung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSchlussberichtGenehmigung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSchlussberichtGenehmigung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSchlussberichtGenehmigung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSchlussberichtGenehmigung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSchlussberichtGenehmigung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSchlussberichtGenehmigung.Properties.Appearance.Options.UseFont = true;
            this.edtSchlussberichtGenehmigung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSchlussberichtGenehmigung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSchlussberichtGenehmigung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSchlussberichtGenehmigung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSchlussberichtGenehmigung.Properties.ShowToday = false;
            this.edtSchlussberichtGenehmigung.Size = new System.Drawing.Size(90, 24);
            this.edtSchlussberichtGenehmigung.TabIndex = 31;
            // 
            // lblSchlussberichtAnKommission
            // 
            this.lblSchlussberichtAnKommission.Location = new System.Drawing.Point(265, 244);
            this.lblSchlussberichtAnKommission.Name = "lblSchlussberichtAnKommission";
            this.lblSchlussberichtAnKommission.Size = new System.Drawing.Size(76, 24);
            this.lblSchlussberichtAnKommission.TabIndex = 28;
            this.lblSchlussberichtAnKommission.Tag = "";
            this.lblSchlussberichtAnKommission.Text = "an Kommission";
            // 
            // edtSchlussberichtAnKommission
            // 
            this.edtSchlussberichtAnKommission.DataMember = "SchlussberichtAnKommission";
            this.edtSchlussberichtAnKommission.DataSource = this.qryVmVaterschaft;
            this.edtSchlussberichtAnKommission.EditValue = null;
            this.edtSchlussberichtAnKommission.Location = new System.Drawing.Point(360, 244);
            this.edtSchlussberichtAnKommission.Name = "edtSchlussberichtAnKommission";
            this.edtSchlussberichtAnKommission.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSchlussberichtAnKommission.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSchlussberichtAnKommission.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSchlussberichtAnKommission.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSchlussberichtAnKommission.Properties.Appearance.Options.UseBackColor = true;
            this.edtSchlussberichtAnKommission.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSchlussberichtAnKommission.Properties.Appearance.Options.UseFont = true;
            this.edtSchlussberichtAnKommission.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSchlussberichtAnKommission.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSchlussberichtAnKommission.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSchlussberichtAnKommission.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSchlussberichtAnKommission.Properties.ShowToday = false;
            this.edtSchlussberichtAnKommission.Size = new System.Drawing.Size(90, 24);
            this.edtSchlussberichtAnKommission.TabIndex = 29;
            // 
            // lblSchlussbericht
            // 
            this.lblSchlussbericht.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblSchlussbericht.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSchlussbericht.Location = new System.Drawing.Point(265, 224);
            this.lblSchlussbericht.Name = "lblSchlussbericht";
            this.lblSchlussbericht.Size = new System.Drawing.Size(110, 16);
            this.lblSchlussbericht.TabIndex = 27;
            this.lblSchlussbericht.Text = "Schlussbericht";
            // 
            // lblAnfechtung
            // 
            this.lblAnfechtung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblAnfechtung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblAnfechtung.Location = new System.Drawing.Point(5, 190);
            this.lblAnfechtung.Name = "lblAnfechtung";
            this.lblAnfechtung.Size = new System.Drawing.Size(110, 16);
            this.lblAnfechtung.TabIndex = 9;
            this.lblAnfechtung.Text = "Anfechtung";
            // 
            // lblPendenzText
            // 
            this.lblPendenzText.Location = new System.Drawing.Point(5, 330);
            this.lblPendenzText.Name = "lblPendenzText";
            this.lblPendenzText.Size = new System.Drawing.Size(84, 24);
            this.lblPendenzText.TabIndex = 45;
            this.lblPendenzText.Tag = "";
            this.lblPendenzText.Text = "Text";
            // 
            // lblPendenz
            // 
            this.lblPendenz.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblPendenz.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblPendenz.Location = new System.Drawing.Point(5, 310);
            this.lblPendenz.Name = "lblPendenz";
            this.lblPendenz.Size = new System.Drawing.Size(158, 16);
            this.lblPendenz.TabIndex = 44;
            this.lblPendenz.Text = "Pendenz";
            // 
            // lblPendenzFrist
            // 
            this.lblPendenzFrist.Location = new System.Drawing.Point(5, 360);
            this.lblPendenzFrist.Name = "lblPendenzFrist";
            this.lblPendenzFrist.Size = new System.Drawing.Size(84, 24);
            this.lblPendenzFrist.TabIndex = 47;
            this.lblPendenzFrist.Tag = "";
            this.lblPendenzFrist.Text = "Frist";
            // 
            // edtPendenzText
            // 
            this.edtPendenzText.DataMember = "PendenzText";
            this.edtPendenzText.DataSource = this.qryVmVaterschaft;
            this.edtPendenzText.Location = new System.Drawing.Point(90, 330);
            this.edtPendenzText.Name = "edtPendenzText";
            this.edtPendenzText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPendenzText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPendenzText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPendenzText.Properties.Appearance.Options.UseBackColor = true;
            this.edtPendenzText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPendenzText.Properties.Appearance.Options.UseFont = true;
            this.edtPendenzText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPendenzText.Size = new System.Drawing.Size(627, 24);
            this.edtPendenzText.TabIndex = 46;
            // 
            // edtPendenzFrist
            // 
            this.edtPendenzFrist.DataMember = "PendenzFrist";
            this.edtPendenzFrist.DataSource = this.qryVmVaterschaft;
            this.edtPendenzFrist.EditValue = null;
            this.edtPendenzFrist.Location = new System.Drawing.Point(90, 360);
            this.edtPendenzFrist.Name = "edtPendenzFrist";
            this.edtPendenzFrist.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPendenzFrist.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPendenzFrist.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPendenzFrist.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPendenzFrist.Properties.Appearance.Options.UseBackColor = true;
            this.edtPendenzFrist.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPendenzFrist.Properties.Appearance.Options.UseFont = true;
            this.edtPendenzFrist.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtPendenzFrist.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtPendenzFrist.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtPendenzFrist.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPendenzFrist.Properties.ShowToday = false;
            this.edtPendenzFrist.Size = new System.Drawing.Size(90, 24);
            this.edtPendenzFrist.TabIndex = 48;
            // 
            // lblGebuehrErlass
            // 
            this.lblGebuehrErlass.Location = new System.Drawing.Point(495, 268);
            this.lblGebuehrErlass.Name = "lblGebuehrErlass";
            this.lblGebuehrErlass.Size = new System.Drawing.Size(76, 24);
            this.lblGebuehrErlass.TabIndex = 42;
            this.lblGebuehrErlass.Tag = "";
            this.lblGebuehrErlass.Text = "Erlass";
            // 
            // lblGebuehrDatum
            // 
            this.lblGebuehrDatum.Location = new System.Drawing.Point(495, 244);
            this.lblGebuehrDatum.Name = "lblGebuehrDatum";
            this.lblGebuehrDatum.Size = new System.Drawing.Size(51, 24);
            this.lblGebuehrDatum.TabIndex = 40;
            this.lblGebuehrDatum.Tag = "";
            this.lblGebuehrDatum.Text = "Zahlung";
            // 
            // lblGebuehr
            // 
            this.lblGebuehr.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblGebuehr.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblGebuehr.Location = new System.Drawing.Point(495, 224);
            this.lblGebuehr.Name = "lblGebuehr";
            this.lblGebuehr.Size = new System.Drawing.Size(110, 16);
            this.lblGebuehr.TabIndex = 39;
            this.lblGebuehr.Text = "Gebühr";
            // 
            // edtGebuehrDatum
            // 
            this.edtGebuehrDatum.DataMember = "GebuehrDatum";
            this.edtGebuehrDatum.DataSource = this.qryVmVaterschaft;
            this.edtGebuehrDatum.EditValue = null;
            this.edtGebuehrDatum.Location = new System.Drawing.Point(560, 244);
            this.edtGebuehrDatum.Name = "edtGebuehrDatum";
            this.edtGebuehrDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGebuehrDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGebuehrDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGebuehrDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGebuehrDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtGebuehrDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGebuehrDatum.Properties.Appearance.Options.UseFont = true;
            this.edtGebuehrDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtGebuehrDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGebuehrDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtGebuehrDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGebuehrDatum.Properties.ShowToday = false;
            this.edtGebuehrDatum.Size = new System.Drawing.Size(90, 24);
            this.edtGebuehrDatum.TabIndex = 41;
            // 
            // edtGebuehrErlass
            // 
            this.edtGebuehrErlass.DataMember = "GebuehrErlass";
            this.edtGebuehrErlass.DataSource = this.qryVmVaterschaft;
            this.edtGebuehrErlass.Location = new System.Drawing.Point(560, 274);
            this.edtGebuehrErlass.Name = "edtGebuehrErlass";
            this.edtGebuehrErlass.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtGebuehrErlass.Properties.Appearance.Options.UseBackColor = true;
            this.edtGebuehrErlass.Properties.Caption = "";
            this.edtGebuehrErlass.Size = new System.Drawing.Size(23, 19);
            this.edtGebuehrErlass.TabIndex = 43;
            // 
            // lblGeburtsmitteilungDatum
            // 
            this.lblGeburtsmitteilungDatum.Location = new System.Drawing.Point(495, 154);
            this.lblGeburtsmitteilungDatum.Name = "lblGeburtsmitteilungDatum";
            this.lblGeburtsmitteilungDatum.Size = new System.Drawing.Size(40, 24);
            this.lblGeburtsmitteilungDatum.TabIndex = 35;
            this.lblGeburtsmitteilungDatum.Tag = "";
            this.lblGeburtsmitteilungDatum.Text = "Datum";
            // 
            // lblGeburtsmitteilungOrt
            // 
            this.lblGeburtsmitteilungOrt.Location = new System.Drawing.Point(495, 179);
            this.lblGeburtsmitteilungOrt.Name = "lblGeburtsmitteilungOrt";
            this.lblGeburtsmitteilungOrt.Size = new System.Drawing.Size(62, 24);
            this.lblGeburtsmitteilungOrt.TabIndex = 37;
            this.lblGeburtsmitteilungOrt.Tag = "";
            this.lblGeburtsmitteilungOrt.Text = "Ort";
            // 
            // lblGeburtsmitteilung
            // 
            this.lblGeburtsmitteilung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblGeburtsmitteilung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblGeburtsmitteilung.Location = new System.Drawing.Point(495, 134);
            this.lblGeburtsmitteilung.Name = "lblGeburtsmitteilung";
            this.lblGeburtsmitteilung.Size = new System.Drawing.Size(180, 16);
            this.lblGeburtsmitteilung.TabIndex = 34;
            this.lblGeburtsmitteilung.Text = "Geburtsmitteilung";
            // 
            // edtGeburtsmitteilungDatum
            // 
            this.edtGeburtsmitteilungDatum.DataMember = "GeburtsmitteilungDatum";
            this.edtGeburtsmitteilungDatum.DataSource = this.qryVmVaterschaft;
            this.edtGeburtsmitteilungDatum.EditValue = null;
            this.edtGeburtsmitteilungDatum.Location = new System.Drawing.Point(560, 154);
            this.edtGeburtsmitteilungDatum.Name = "edtGeburtsmitteilungDatum";
            this.edtGeburtsmitteilungDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtsmitteilungDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtsmitteilungDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsmitteilungDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsmitteilungDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsmitteilungDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsmitteilungDatum.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsmitteilungDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtGeburtsmitteilungDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtsmitteilungDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtGeburtsmitteilungDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtsmitteilungDatum.Properties.ShowToday = false;
            this.edtGeburtsmitteilungDatum.Size = new System.Drawing.Size(90, 24);
            this.edtGeburtsmitteilungDatum.TabIndex = 36;
            // 
            // edtGeburtsmitteilungOrt
            // 
            this.edtGeburtsmitteilungOrt.DataMember = "GeburtsmitteilungOrt";
            this.edtGeburtsmitteilungOrt.DataSource = this.qryVmVaterschaft;
            this.edtGeburtsmitteilungOrt.Location = new System.Drawing.Point(560, 179);
            this.edtGeburtsmitteilungOrt.Name = "edtGeburtsmitteilungOrt";
            this.edtGeburtsmitteilungOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtsmitteilungOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsmitteilungOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsmitteilungOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsmitteilungOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsmitteilungOrt.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsmitteilungOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGeburtsmitteilungOrt.Size = new System.Drawing.Size(159, 24);
            this.edtGeburtsmitteilungOrt.TabIndex = 38;
            // 
            // CtlVmVaterschaftVerlauf
            // 
            this.ActiveSQLQuery = this.qryVmVaterschaft;
            
            this.Controls.Add(this.lblGeburtsmitteilungDatum);
            this.Controls.Add(this.lblGeburtsmitteilungOrt);
            this.Controls.Add(this.lblGeburtsmitteilung);
            this.Controls.Add(this.edtGeburtsmitteilungDatum);
            this.Controls.Add(this.edtGeburtsmitteilungOrt);
            this.Controls.Add(this.edtGebuehrErlass);
            this.Controls.Add(this.edtGebuehrDatum);
            this.Controls.Add(this.lblGebuehrErlass);
            this.Controls.Add(this.lblGebuehrDatum);
            this.Controls.Add(this.lblGebuehr);
            this.Controls.Add(this.edtPendenzFrist);
            this.Controls.Add(this.edtPendenzText);
            this.Controls.Add(this.lblPendenzFrist);
            this.Controls.Add(this.lblPendenz);
            this.Controls.Add(this.lblPendenzText);
            this.Controls.Add(this.lblAnfechtung);
            this.Controls.Add(this.lblSchlussberichtGenehmigung);
            this.Controls.Add(this.edtSchlussberichtGenehmigung);
            this.Controls.Add(this.lblSchlussberichtAnKommission);
            this.Controls.Add(this.edtSchlussberichtAnKommission);
            this.Controls.Add(this.lblSchlussbericht);
            this.Controls.Add(this.edtUnterhaltsurteilBetrag);
            this.Controls.Add(this.lblUnterhaltsurteilBetrag);
            this.Controls.Add(this.lblUnterhaltsurteilDatum);
            this.Controls.Add(this.edtUnterhaltsurteilDatum);
            this.Controls.Add(this.lblUnterhaltsurteil);
            this.Controls.Add(this.lblUnterhaltsurteilBetragCHF);
            this.Controls.Add(this.lblVAnfechtungsurteil);
            this.Controls.Add(this.edtVAnfechtungsurteil);
            this.Controls.Add(this.lblVUrteilDatum);
            this.Controls.Add(this.edtVUrteilDatum);
            this.Controls.Add(this.lblVaterschaftsurteil);
            this.Controls.Add(this.lblSorgerechtVereinbDatum);
            this.Controls.Add(this.edtSorgerechtVereinbDatum);
            this.Controls.Add(this.lblSorgerechtVereinbarung);
            this.Controls.Add(this.lblUHVDatum);
            this.Controls.Add(this.edtUHVDatum);
            this.Controls.Add(this.lblUnterhaltsvertrag);
            this.Controls.Add(this.lblAnerkennungDatum);
            this.Controls.Add(this.lblAnerkennungOrt);
            this.Controls.Add(this.lblAnerkennung);
            this.Controls.Add(this.lblZGBArtikel);
            this.Controls.Add(this.edtZGBCodes);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lblUHVBetragCHF);
            this.Controls.Add(this.edtUHVBetrag);
            this.Controls.Add(this.lblUHVBetrag);
            this.Controls.Add(this.edtAnerkennungDatum);
            this.Controls.Add(this.edtAnerkennungOrt);
            this.Controls.Add(this.edtUHVAbschlussGrundCode);
            this.Controls.Add(this.lblUHVAbschlussGrundCode);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlVmVaterschaftVerlauf";
            this.Size = new System.Drawing.Size(731, 550);
            ((System.ComponentModel.ISupportInitialize)(this.qryVmVaterschaft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUHVAbschlussGrundCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUHVAbschlussGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUHVAbschlussGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnerkennungOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnerkennungDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUHVBetragCHF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUHVBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUHVBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZGBCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZGBArtikel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnerkennung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnerkennungOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnerkennungDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterhaltsvertrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUHVDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUHVDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSorgerechtVereinbarung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSorgerechtVereinbDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSorgerechtVereinbDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVaterschaftsurteil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVUrteilDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVUrteilDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVAnfechtungsurteil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVAnfechtungsurteil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterhaltsurteilBetragCHF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterhaltsurteilBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterhaltsurteilBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterhaltsurteilDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterhaltsurteilDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUnterhaltsurteil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchlussberichtGenehmigung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchlussberichtGenehmigung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchlussberichtAnKommission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchlussberichtAnKommission.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchlussbericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnfechtung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPendenzText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPendenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPendenzFrist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPendenzText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPendenzFrist.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGebuehrErlass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGebuehrDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGebuehr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGebuehrDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGebuehrErlass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsmitteilungDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsmitteilungOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsmitteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsmitteilungDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsmitteilungOrt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryVmVaterschaft;
        private KiSS4.Gui.KissCheckedLookupEdit edtZGBCodes;
        private KiSS4.Gui.KissLabel lblGeburtsmitteilungDatum;
        private KiSS4.Gui.KissLabel lblGeburtsmitteilungOrt;
        private KiSS4.Gui.KissLabel lblGeburtsmitteilung;
        private KiSS4.Gui.KissDateEdit edtGeburtsmitteilungDatum;
        private KiSS4.Gui.KissTextEdit edtGeburtsmitteilungOrt;
        private KiSS4.Gui.KissLabel lblAnerkennung;
        private KiSS4.Gui.KissLabel lblVaterschaftsurteil;
        private KiSS4.Gui.KissLabel lblPendenz;
        private KiSS4.Gui.KissTextEdit edtAnerkennungOrt;
        private KiSS4.Gui.KissDateEdit edtAnerkennungDatum;
        private KiSS4.Gui.KissLabel lblUHVBetragCHF;
        private KiSS4.Gui.KissCalcEdit edtUHVBetrag;
        private KiSS4.Gui.KissLabel lblUHVBetrag;
        private KiSS4.Gui.KissLabel lblAnerkennungOrt;
        private KiSS4.Gui.KissLabel lblAnerkennungDatum;
        private KiSS4.Gui.KissLabel lblUnterhaltsvertrag;
        private KiSS4.Gui.KissLabel lblUHVDatum;
        private KiSS4.Gui.KissDateEdit edtUHVDatum;
        private KiSS4.Gui.KissLabel lblSorgerechtVereinbarung;
        private KiSS4.Gui.KissLabel lblSorgerechtVereinbDatum;
        private KiSS4.Gui.KissDateEdit edtSorgerechtVereinbDatum;
        private KiSS4.Gui.KissLabel lblVUrteilDatum;
        private KiSS4.Gui.KissDateEdit edtVUrteilDatum;
        private KiSS4.Gui.KissLabel lblVAnfechtungsurteil;
        private KiSS4.Gui.KissDateEdit edtVAnfechtungsurteil;
        private KiSS4.Gui.KissLabel lblUnterhaltsurteilDatum;
        private KiSS4.Gui.KissDateEdit edtUnterhaltsurteilDatum;
        private KiSS4.Gui.KissLabel lblUnterhaltsurteil;
        private KiSS4.Gui.KissLabel lblAnfechtung;
        private KiSS4.Gui.KissLookUpEdit edtUHVAbschlussGrundCode;
        private KiSS4.Gui.KissLabel lblUHVAbschlussGrundCode;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblZGBArtikel;
        private KiSS4.Gui.KissLabel lblUnterhaltsurteilBetragCHF;
        private KiSS4.Gui.KissCalcEdit edtUnterhaltsurteilBetrag;
        private KiSS4.Gui.KissLabel lblUnterhaltsurteilBetrag;
        private KiSS4.Gui.KissLabel lblSchlussberichtGenehmigung;
        private KiSS4.Gui.KissDateEdit edtSchlussberichtGenehmigung;
        private KiSS4.Gui.KissLabel lblSchlussberichtAnKommission;
        private KiSS4.Gui.KissDateEdit edtSchlussberichtAnKommission;
        private KiSS4.Gui.KissLabel lblSchlussbericht;
        private KiSS4.Gui.KissLabel lblPendenzText;
        private KiSS4.Gui.KissLabel lblPendenzFrist;
        private KiSS4.Gui.KissTextEdit edtPendenzText;
        private KiSS4.Gui.KissDateEdit edtPendenzFrist;
        private KiSS4.Gui.KissLabel lblGebuehrErlass;
        private KiSS4.Gui.KissLabel lblGebuehrDatum;
        private KiSS4.Gui.KissLabel lblGebuehr;
        private KiSS4.Gui.KissDateEdit edtGebuehrDatum;
        private KiSS4.Gui.KissCheckEdit edtGebuehrErlass;
    }
}
