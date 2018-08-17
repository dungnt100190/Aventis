using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Vormundschaft
{
    partial class CtlVmTestament
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

        #region Windows Forms Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject19 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject20 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject21 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVmTestament));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject18 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryVmTestament = new KiSS4.DB.SqlQuery(this.components);
            this.lblTitel = new System.Windows.Forms.Label();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.edtLaufNr = new KiSS4.Gui.KissTextEdit();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.kissLabel31 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.edtEroeffnungAbgeschlossenDatum = new KiSS4.Gui.KissDateEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.edtUser = new KiSS4.Gui.KissButtonEdit();
            this.edtEroeffnungDokID = new KiSS4.Dokument.XDokument();
            this.edtEroeffnungAuszugDokID = new KiSS4.Dokument.XDokument();
            this.edtEroeffnungAdressenDokID = new KiSS4.Dokument.XDokument();
            this.editZeugnisse = new KiSS4.Gui.KissCheckedLookupEdit();
            this.editKopieAn = new KiSS4.Gui.KissCheckedLookupEdit();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.edtEroeffnungsRechnungBetrag = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.edtEroeffnungsRechnungSAPNr = new KiSS4.Gui.KissTextEdit();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.edtZusatzRechnungSAPNr = new KiSS4.Gui.KissTextEdit();
            this.kissLabel13 = new KiSS4.Gui.KissLabel();
            this.edtZusatzRechnungBetrag = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.kissLabel15 = new KiSS4.Gui.KissLabel();
            this.kissLabel16 = new KiSS4.Gui.KissLabel();
            this.kissLabel17 = new KiSS4.Gui.KissLabel();
            this.edtPublikationDatum = new KiSS4.Gui.KissDateEdit();
            this.edtPublikationFrist = new KiSS4.Gui.KissDateEdit();
            this.lblEroeffnungNotar = new KiSS4.Gui.KissLabel();
            this.edtNotar = new KiSS4.Gui.KissButtonEdit();
            this.lblJahr = new KiSS4.Gui.KissLabel();
            this.edtJahr = new KiSS4.Gui.KissCalcEdit();
            this.ctlVmErblasserInfo1 = new KiSS4.Vormundschaft.CtlVmErblasserInfo();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmTestament)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLaufNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungAbgeschlossenDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungDokID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungAuszugDokID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungAdressenDokID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editZeugnisse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKopieAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsRechnungBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsRechnungSAPNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzRechnungSAPNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzRechnungBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPublikationDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPublikationFrist.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungNotar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNotar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryVmTestament
            // 
            this.qryVmTestament.CanUpdate = true;
            this.qryVmTestament.HostControl = this;
            this.qryVmTestament.TableName = "VmTestament";
            this.qryVmTestament.BeforePost += new System.EventHandler(this.qryVmTestament_BeforePost);
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
            // edtLaufNr
            // 
            this.edtLaufNr.DataMember = "LaufNr";
            this.edtLaufNr.DataSource = this.qryVmTestament;
            this.edtLaufNr.Location = new System.Drawing.Point(126, 160);
            this.edtLaufNr.Name = "edtLaufNr";
            this.edtLaufNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLaufNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLaufNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLaufNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtLaufNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLaufNr.Properties.Appearance.Options.UseFont = true;
            this.edtLaufNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLaufNr.Size = new System.Drawing.Size(75, 24);
            this.edtLaufNr.TabIndex = 0;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(5, 160);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(44, 24);
            this.kissLabel3.TabIndex = 128;
            this.kissLabel3.Text = "FallNr";
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryVmTestament;
            this.edtBemerkung.Location = new System.Drawing.Point(126, 371);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(467, 132);
            this.edtBemerkung.TabIndex = 15;
            // 
            // kissLabel31
            // 
            this.kissLabel31.Location = new System.Drawing.Point(3, 371);
            this.kissLabel31.Name = "kissLabel31";
            this.kissLabel31.Size = new System.Drawing.Size(60, 24);
            this.kissLabel31.TabIndex = 146;
            this.kissLabel31.Text = "Bemerkung";
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(5, 300);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(108, 24);
            this.kissLabel1.TabIndex = 148;
            this.kissLabel1.Tag = "";
            this.kissLabel1.Text = "Eröffnung abgeschl.";
            // 
            // edtEroeffnungAbgeschlossenDatum
            // 
            this.edtEroeffnungAbgeschlossenDatum.DataMember = "EroeffnungAbgeschlossenDatum";
            this.edtEroeffnungAbgeschlossenDatum.DataSource = this.qryVmTestament;
            this.edtEroeffnungAbgeschlossenDatum.EditValue = null;
            this.edtEroeffnungAbgeschlossenDatum.Location = new System.Drawing.Point(126, 300);
            this.edtEroeffnungAbgeschlossenDatum.Name = "edtEroeffnungAbgeschlossenDatum";
            this.edtEroeffnungAbgeschlossenDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEroeffnungAbgeschlossenDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungAbgeschlossenDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungAbgeschlossenDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungAbgeschlossenDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungAbgeschlossenDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungAbgeschlossenDatum.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungAbgeschlossenDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtEroeffnungAbgeschlossenDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEroeffnungAbgeschlossenDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtEroeffnungAbgeschlossenDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungAbgeschlossenDatum.Properties.ShowToday = false;
            this.edtEroeffnungAbgeschlossenDatum.Size = new System.Drawing.Size(90, 24);
            this.edtEroeffnungAbgeschlossenDatum.TabIndex = 7;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(390, 187);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(64, 24);
            this.kissLabel2.TabIndex = 149;
            this.kissLabel2.Text = "vollständig";
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(390, 247);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(64, 24);
            this.kissLabel4.TabIndex = 150;
            this.kissLabel4.Text = "Adressen";
            // 
            // kissLabel5
            // 
            this.kissLabel5.Location = new System.Drawing.Point(390, 217);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(64, 24);
            this.kissLabel5.TabIndex = 151;
            this.kissLabel5.Text = "Auszug";
            // 
            // kissLabel6
            // 
            this.kissLabel6.Location = new System.Drawing.Point(5, 190);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(94, 24);
            this.kissLabel6.TabIndex = 623;
            this.kissLabel6.Text = "Sachbearbeitung";
            // 
            // edtUser
            // 
            this.edtUser.DataMember = "User";
            this.edtUser.DataSource = this.qryVmTestament;
            this.edtUser.Location = new System.Drawing.Point(126, 190);
            this.edtUser.Name = "edtUser";
            this.edtUser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUser.Properties.Appearance.Options.UseBackColor = true;
            this.edtUser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUser.Properties.Appearance.Options.UseFont = true;
            this.edtUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtUser.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUser.Size = new System.Drawing.Size(245, 24);
            this.edtUser.TabIndex = 2;
            this.edtUser.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editSAR_UserModifiedFld);
            // 
            // edtEroeffnungDokID
            // 
            this.edtEroeffnungDokID.AllowDrop = true;
            this.edtEroeffnungDokID.Context = "VmErbeEroeffnungVoll";
            this.edtEroeffnungDokID.DataMember = "EroeffnungDokID";
            this.edtEroeffnungDokID.DataSource = this.qryVmTestament;
            this.edtEroeffnungDokID.Location = new System.Drawing.Point(477, 187);
            this.edtEroeffnungDokID.Name = "edtEroeffnungDokID";
            this.edtEroeffnungDokID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungDokID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungDokID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungDokID.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungDokID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungDokID.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungDokID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtEroeffnungDokID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEroeffnungDokID.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEroeffnungDokID.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEroeffnungDokID.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEroeffnungDokID.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11, "Dokument importieren")});
            this.edtEroeffnungDokID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungDokID.Properties.ReadOnly = true;
            this.edtEroeffnungDokID.Size = new System.Drawing.Size(116, 24);
            this.edtEroeffnungDokID.TabIndex = 9;
            // 
            // edtEroeffnungAuszugDokID
            // 
            this.edtEroeffnungAuszugDokID.AllowDrop = true;
            this.edtEroeffnungAuszugDokID.Context = "VmErbeEroeffnungAuszug";
            this.edtEroeffnungAuszugDokID.DataMember = "EroeffnungAuszugDokID";
            this.edtEroeffnungAuszugDokID.DataSource = this.qryVmTestament;
            this.edtEroeffnungAuszugDokID.Location = new System.Drawing.Point(477, 217);
            this.edtEroeffnungAuszugDokID.Name = "edtEroeffnungAuszugDokID";
            this.edtEroeffnungAuszugDokID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungAuszugDokID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungAuszugDokID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungAuszugDokID.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungAuszugDokID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungAuszugDokID.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungAuszugDokID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtEroeffnungAuszugDokID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEroeffnungAuszugDokID.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEroeffnungAuszugDokID.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEroeffnungAuszugDokID.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEroeffnungAuszugDokID.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "Dokument importieren")});
            this.edtEroeffnungAuszugDokID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungAuszugDokID.Properties.ReadOnly = true;
            this.edtEroeffnungAuszugDokID.Size = new System.Drawing.Size(116, 24);
            this.edtEroeffnungAuszugDokID.TabIndex = 10;
            // 
            // edtEroeffnungAdressenDokID
            // 
            this.edtEroeffnungAdressenDokID.AllowDrop = true;
            this.edtEroeffnungAdressenDokID.Context = "VmErbeEroeffnungsadressen";
            this.edtEroeffnungAdressenDokID.DataMember = "EroeffnungAdressenDokID";
            this.edtEroeffnungAdressenDokID.DataSource = this.qryVmTestament;
            this.edtEroeffnungAdressenDokID.Location = new System.Drawing.Point(477, 247);
            this.edtEroeffnungAdressenDokID.Name = "edtEroeffnungAdressenDokID";
            this.edtEroeffnungAdressenDokID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungAdressenDokID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungAdressenDokID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungAdressenDokID.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungAdressenDokID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungAdressenDokID.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungAdressenDokID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            serializableAppearanceObject20.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject20.Options.UseBackColor = true;
            serializableAppearanceObject21.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject21.Options.UseBackColor = true;
            this.edtEroeffnungAdressenDokID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEroeffnungAdressenDokID.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEroeffnungAdressenDokID.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEroeffnungAdressenDokID.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject20, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEroeffnungAdressenDokID.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject21, "Dokument importieren")});
            this.edtEroeffnungAdressenDokID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungAdressenDokID.Properties.ReadOnly = true;
            this.edtEroeffnungAdressenDokID.Size = new System.Drawing.Size(116, 24);
            this.edtEroeffnungAdressenDokID.TabIndex = 11;
            // 
            // editZeugnisse
            // 
            this.editZeugnisse.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.editZeugnisse.Appearance.Options.UseBackColor = true;
            this.editZeugnisse.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.editZeugnisse.CheckOnClick = true;
            this.editZeugnisse.DataMember = "ZeugnisseCodes";
            this.editZeugnisse.DataSource = this.qryVmTestament;
            this.editZeugnisse.Location = new System.Drawing.Point(636, 371);
            this.editZeugnisse.LOVName = "VmErbeZeugnisse";
            this.editZeugnisse.Name = "editZeugnisse";
            this.editZeugnisse.Size = new System.Drawing.Size(73, 132);
            this.editZeugnisse.TabIndex = 16;
            // 
            // editKopieAn
            // 
            this.editKopieAn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.editKopieAn.Appearance.Options.UseBackColor = true;
            this.editKopieAn.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.editKopieAn.CheckOnClick = true;
            this.editKopieAn.DataMember = "KopieAnCodes";
            this.editKopieAn.DataSource = this.qryVmTestament;
            this.editKopieAn.Location = new System.Drawing.Point(636, 187);
            this.editKopieAn.LOVName = "VmErbeKopieAn";
            this.editKopieAn.Name = "editKopieAn";
            this.editKopieAn.Size = new System.Drawing.Size(73, 111);
            this.editKopieAn.TabIndex = 14;
            // 
            // kissLabel9
            // 
            this.kissLabel9.Location = new System.Drawing.Point(636, 345);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(65, 24);
            this.kissLabel9.TabIndex = 627;
            this.kissLabel9.Text = "Zeugnisse";
            // 
            // kissLabel8
            // 
            this.kissLabel8.Location = new System.Drawing.Point(636, 160);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(47, 24);
            this.kissLabel8.TabIndex = 626;
            this.kissLabel8.Text = "Kopie an";
            // 
            // edtEroeffnungsRechnungBetrag
            // 
            this.edtEroeffnungsRechnungBetrag.DataMember = "EroeffnungsRechnungBetrag";
            this.edtEroeffnungsRechnungBetrag.DataSource = this.qryVmTestament;
            this.edtEroeffnungsRechnungBetrag.Location = new System.Drawing.Point(126, 230);
            this.edtEroeffnungsRechnungBetrag.Name = "edtEroeffnungsRechnungBetrag";
            this.edtEroeffnungsRechnungBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEroeffnungsRechnungBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungsRechnungBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungsRechnungBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungsRechnungBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungsRechnungBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungsRechnungBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungsRechnungBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEroeffnungsRechnungBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungsRechnungBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtEroeffnungsRechnungBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtEroeffnungsRechnungBetrag.Properties.EditFormat.FormatString = "N2";
            this.edtEroeffnungsRechnungBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtEroeffnungsRechnungBetrag.Size = new System.Drawing.Size(80, 24);
            this.edtEroeffnungsRechnungBetrag.TabIndex = 3;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Location = new System.Drawing.Point(210, 230);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(28, 24);
            this.kissLabel7.TabIndex = 630;
            this.kissLabel7.Text = "CHF";
            // 
            // kissLabel10
            // 
            this.kissLabel10.Location = new System.Drawing.Point(5, 230);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(120, 24);
            this.kissLabel10.TabIndex = 629;
            this.kissLabel10.Text = "Eröffnungsrechnung";
            // 
            // edtEroeffnungsRechnungSAPNr
            // 
            this.edtEroeffnungsRechnungSAPNr.DataMember = "EroeffnungsRechnungSAPNr";
            this.edtEroeffnungsRechnungSAPNr.DataSource = this.qryVmTestament;
            this.edtEroeffnungsRechnungSAPNr.Location = new System.Drawing.Point(291, 230);
            this.edtEroeffnungsRechnungSAPNr.Name = "edtEroeffnungsRechnungSAPNr";
            this.edtEroeffnungsRechnungSAPNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungsRechnungSAPNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungsRechnungSAPNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungsRechnungSAPNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungsRechnungSAPNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungsRechnungSAPNr.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungsRechnungSAPNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEroeffnungsRechnungSAPNr.Size = new System.Drawing.Size(79, 24);
            this.edtEroeffnungsRechnungSAPNr.TabIndex = 4;
            // 
            // kissLabel11
            // 
            this.kissLabel11.Location = new System.Drawing.Point(245, 230);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(44, 24);
            this.kissLabel11.TabIndex = 632;
            this.kissLabel11.Text = "SAP-Nr.";
            // 
            // kissLabel12
            // 
            this.kissLabel12.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel12.Location = new System.Drawing.Point(390, 160);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(84, 16);
            this.kissLabel12.TabIndex = 633;
            this.kissLabel12.Text = "Eröffnung";
            // 
            // edtZusatzRechnungSAPNr
            // 
            this.edtZusatzRechnungSAPNr.DataMember = "ZusatzRechnungSAPNr";
            this.edtZusatzRechnungSAPNr.DataSource = this.qryVmTestament;
            this.edtZusatzRechnungSAPNr.Location = new System.Drawing.Point(291, 260);
            this.edtZusatzRechnungSAPNr.Name = "edtZusatzRechnungSAPNr";
            this.edtZusatzRechnungSAPNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatzRechnungSAPNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzRechnungSAPNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzRechnungSAPNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzRechnungSAPNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzRechnungSAPNr.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzRechnungSAPNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZusatzRechnungSAPNr.Size = new System.Drawing.Size(79, 24);
            this.edtZusatzRechnungSAPNr.TabIndex = 6;
            // 
            // kissLabel13
            // 
            this.kissLabel13.Location = new System.Drawing.Point(245, 260);
            this.kissLabel13.Name = "kissLabel13";
            this.kissLabel13.Size = new System.Drawing.Size(44, 24);
            this.kissLabel13.TabIndex = 638;
            this.kissLabel13.Text = "SAP-Nr.";
            // 
            // edtZusatzRechnungBetrag
            // 
            this.edtZusatzRechnungBetrag.DataMember = "ZusatzRechnungBetrag";
            this.edtZusatzRechnungBetrag.DataSource = this.qryVmTestament;
            this.edtZusatzRechnungBetrag.Location = new System.Drawing.Point(126, 260);
            this.edtZusatzRechnungBetrag.Name = "edtZusatzRechnungBetrag";
            this.edtZusatzRechnungBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZusatzRechnungBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatzRechnungBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzRechnungBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzRechnungBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzRechnungBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzRechnungBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzRechnungBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZusatzRechnungBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZusatzRechnungBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtZusatzRechnungBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtZusatzRechnungBetrag.Properties.EditFormat.FormatString = "N2";
            this.edtZusatzRechnungBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtZusatzRechnungBetrag.Size = new System.Drawing.Size(80, 24);
            this.edtZusatzRechnungBetrag.TabIndex = 5;
            // 
            // kissLabel14
            // 
            this.kissLabel14.Location = new System.Drawing.Point(210, 260);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(28, 24);
            this.kissLabel14.TabIndex = 636;
            this.kissLabel14.Text = "CHF";
            // 
            // kissLabel15
            // 
            this.kissLabel15.Location = new System.Drawing.Point(5, 260);
            this.kissLabel15.Name = "kissLabel15";
            this.kissLabel15.Size = new System.Drawing.Size(104, 24);
            this.kissLabel15.TabIndex = 635;
            this.kissLabel15.Text = "Zusatzrechnung";
            // 
            // kissLabel16
            // 
            this.kissLabel16.Location = new System.Drawing.Point(390, 278);
            this.kissLabel16.Name = "kissLabel16";
            this.kissLabel16.Size = new System.Drawing.Size(85, 24);
            this.kissLabel16.TabIndex = 642;
            this.kissLabel16.Text = "Publikation am";
            // 
            // kissLabel17
            // 
            this.kissLabel17.Location = new System.Drawing.Point(390, 309);
            this.kissLabel17.Name = "kissLabel17";
            this.kissLabel17.Size = new System.Drawing.Size(75, 24);
            this.kissLabel17.TabIndex = 641;
            this.kissLabel17.Text = "Publikation Frist";
            // 
            // edtPublikationDatum
            // 
            this.edtPublikationDatum.DataMember = "PublikationDatum";
            this.edtPublikationDatum.DataSource = this.qryVmTestament;
            this.edtPublikationDatum.EditValue = null;
            this.edtPublikationDatum.Location = new System.Drawing.Point(477, 281);
            this.edtPublikationDatum.Name = "edtPublikationDatum";
            this.edtPublikationDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPublikationDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPublikationDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPublikationDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPublikationDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtPublikationDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPublikationDatum.Properties.Appearance.Options.UseFont = true;
            this.edtPublikationDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtPublikationDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtPublikationDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtPublikationDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPublikationDatum.Properties.ShowToday = false;
            this.edtPublikationDatum.Size = new System.Drawing.Size(90, 24);
            this.edtPublikationDatum.TabIndex = 12;
            // 
            // edtPublikationFrist
            // 
            this.edtPublikationFrist.DataMember = "PublikationFrist";
            this.edtPublikationFrist.DataSource = this.qryVmTestament;
            this.edtPublikationFrist.EditValue = null;
            this.edtPublikationFrist.Location = new System.Drawing.Point(477, 311);
            this.edtPublikationFrist.Name = "edtPublikationFrist";
            this.edtPublikationFrist.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPublikationFrist.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPublikationFrist.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPublikationFrist.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPublikationFrist.Properties.Appearance.Options.UseBackColor = true;
            this.edtPublikationFrist.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPublikationFrist.Properties.Appearance.Options.UseFont = true;
            this.edtPublikationFrist.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtPublikationFrist.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtPublikationFrist.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtPublikationFrist.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPublikationFrist.Properties.ShowToday = false;
            this.edtPublikationFrist.Size = new System.Drawing.Size(90, 24);
            this.edtPublikationFrist.TabIndex = 13;
            // 
            // lblEroeffnungNotar
            // 
            this.lblEroeffnungNotar.Location = new System.Drawing.Point(5, 336);
            this.lblEroeffnungNotar.Name = "lblEroeffnungNotar";
            this.lblEroeffnungNotar.Size = new System.Drawing.Size(120, 24);
            this.lblEroeffnungNotar.TabIndex = 643;
            this.lblEroeffnungNotar.Tag = "";
            this.lblEroeffnungNotar.Text = "Eröffnung durch Notar";
            // 
            // edtNotar
            // 
            this.edtNotar.DataMember = "Notar";
            this.edtNotar.DataSource = this.qryVmTestament;
            this.edtNotar.Location = new System.Drawing.Point(126, 336);
            this.edtNotar.Name = "edtNotar";
            this.edtNotar.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNotar.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNotar.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNotar.Properties.Appearance.Options.UseBackColor = true;
            this.edtNotar.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNotar.Properties.Appearance.Options.UseFont = true;
            this.edtNotar.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.edtNotar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.edtNotar.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNotar.Size = new System.Drawing.Size(245, 24);
            this.edtNotar.TabIndex = 8;
            this.edtNotar.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editNotar_UserModifiedFld);
            // 
            // lblJahr
            // 
            this.lblJahr.Location = new System.Drawing.Point(245, 160);
            this.lblJahr.Name = "lblJahr";
            this.lblJahr.Size = new System.Drawing.Size(44, 24);
            this.lblJahr.TabIndex = 646;
            this.lblJahr.Text = "Jahr";
            // 
            // edtJahr
            // 
            this.edtJahr.DataMember = "Jahr";
            this.edtJahr.DataSource = this.qryVmTestament;
            this.edtJahr.Location = new System.Drawing.Point(295, 160);
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
            this.edtJahr.Size = new System.Drawing.Size(75, 24);
            this.edtJahr.TabIndex = 1;
            // 
            // ctlVmErblasserInfo1
            // 
            this.ctlVmErblasserInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlVmErblasserInfo1.FaLeistungID = 0;
            this.ctlVmErblasserInfo1.Location = new System.Drawing.Point(5, 34);
            this.ctlVmErblasserInfo1.Name = "ctlVmErblasserInfo1";
            this.ctlVmErblasserInfo1.Size = new System.Drawing.Size(705, 120);
            this.ctlVmErblasserInfo1.TabIndex = 621;
            // 
            // CtlVmTestament
            // 
            this.ActiveSQLQuery = this.qryVmTestament;
            
            this.Controls.Add(this.edtJahr);
            this.Controls.Add(this.lblJahr);
            this.Controls.Add(this.edtNotar);
            this.Controls.Add(this.lblEroeffnungNotar);
            this.Controls.Add(this.kissLabel16);
            this.Controls.Add(this.kissLabel17);
            this.Controls.Add(this.edtPublikationDatum);
            this.Controls.Add(this.edtPublikationFrist);
            this.Controls.Add(this.edtZusatzRechnungSAPNr);
            this.Controls.Add(this.kissLabel13);
            this.Controls.Add(this.edtZusatzRechnungBetrag);
            this.Controls.Add(this.kissLabel14);
            this.Controls.Add(this.kissLabel15);
            this.Controls.Add(this.kissLabel12);
            this.Controls.Add(this.edtEroeffnungsRechnungSAPNr);
            this.Controls.Add(this.kissLabel11);
            this.Controls.Add(this.edtEroeffnungsRechnungBetrag);
            this.Controls.Add(this.kissLabel7);
            this.Controls.Add(this.kissLabel10);
            this.Controls.Add(this.editZeugnisse);
            this.Controls.Add(this.editKopieAn);
            this.Controls.Add(this.kissLabel9);
            this.Controls.Add(this.kissLabel8);
            this.Controls.Add(this.edtEroeffnungAdressenDokID);
            this.Controls.Add(this.edtEroeffnungAuszugDokID);
            this.Controls.Add(this.edtEroeffnungDokID);
            this.Controls.Add(this.kissLabel6);
            this.Controls.Add(this.edtUser);
            this.Controls.Add(this.ctlVmErblasserInfo1);
            this.Controls.Add(this.kissLabel5);
            this.Controls.Add(this.kissLabel4);
            this.Controls.Add(this.kissLabel2);
            this.Controls.Add(this.kissLabel1);
            this.Controls.Add(this.edtEroeffnungAbgeschlossenDatum);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.kissLabel31);
            this.Controls.Add(this.edtLaufNr);
            this.Controls.Add(this.kissLabel3);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlVmTestament";
            this.Size = new System.Drawing.Size(719, 515);
            ((System.ComponentModel.ISupportInitialize)(this.qryVmTestament)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLaufNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungAbgeschlossenDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungDokID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungAuszugDokID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungAdressenDokID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editZeugnisse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKopieAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsRechnungBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungsRechnungSAPNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzRechnungSAPNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzRechnungBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPublikationDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPublikationFrist.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungNotar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNotar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryVmTestament;
        private KiSS4.Gui.KissTextEdit edtLaufNr;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissLabel kissLabel31;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissDateEdit edtEroeffnungAbgeschlossenDatum;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Vormundschaft.CtlVmErblasserInfo ctlVmErblasserInfo1;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Dokument.XDokument edtEroeffnungDokID;
        private KiSS4.Dokument.XDokument edtEroeffnungAuszugDokID;
        private KiSS4.Dokument.XDokument edtEroeffnungAdressenDokID;
        private KiSS4.Gui.KissButtonEdit edtUser;
        private KiSS4.Gui.KissCheckedLookupEdit editZeugnisse;
        private KiSS4.Gui.KissCheckedLookupEdit editKopieAn;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissCalcEdit edtEroeffnungsRechnungBetrag;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissTextEdit edtEroeffnungsRechnungSAPNr;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissTextEdit edtZusatzRechnungSAPNr;
        private KiSS4.Gui.KissLabel kissLabel13;
        private KiSS4.Gui.KissCalcEdit edtZusatzRechnungBetrag;
        private KiSS4.Gui.KissLabel kissLabel14;
        private KiSS4.Gui.KissLabel kissLabel15;
        private KiSS4.Gui.KissLabel kissLabel16;
        private KiSS4.Gui.KissLabel kissLabel17;
        private KiSS4.Gui.KissDateEdit edtPublikationDatum;
        private KiSS4.Gui.KissDateEdit edtPublikationFrist;
        private KiSS4.Gui.KissButtonEdit edtNotar;
        private KiSS4.Gui.KissLabel lblEroeffnungNotar;
        private KiSS4.Gui.KissLabel lblJahr;
        private KiSS4.Gui.KissCalcEdit edtJahr;
    }
}
