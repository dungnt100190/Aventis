using System;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis
{
    partial class CtlArbeit
    {

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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlArbeit));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryArbeit = new KiSS4.DB.SqlQuery();
            this.panelTitel = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblErwerbssituation = new KiSS4.Gui.KissLabel();
            this.lblTeilzeitgrund = new KiSS4.Gui.KissLabel();
            this.lblBeschaeftigungsgrad = new KiSS4.Gui.KissLabel();
            this.cboErwerbssituation1 = new KiSS4.Gui.KissLookUpEdit();
            this.cboErwerbssituation2 = new KiSS4.Gui.KissLookUpEdit();
            this.cboErwerbssituation4 = new KiSS4.Gui.KissLookUpEdit();
            this.cboErwerbssituation3 = new KiSS4.Gui.KissLookUpEdit();
            this.lblErwerbssituation3 = new KiSS4.Gui.KissLabel();
            this.lblErwerbssituation2 = new KiSS4.Gui.KissLabel();
            this.lblErwerbssituation1 = new KiSS4.Gui.KissLabel();
            this.cboBeschaeftigungsgrad = new KiSS4.Gui.KissLookUpEdit();
            this.editBemerkungRTF = new KiSS4.Gui.KissRTFEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.cboBranche = new KiSS4.Gui.KissLookUpEdit();
            this.cboHoechsteAusbildung = new KiSS4.Gui.KissLookUpEdit();
            this.cboLetzteAbgebrocheneAusbildung = new KiSS4.Gui.KissLookUpEdit();
            this.lblArbeitszeitProWocheStd = new KiSS4.Gui.KissLabel();
            this.lblTeilzeitgrund1 = new KiSS4.Gui.KissLabel();
            this.lblTeilzeitgrund2 = new KiSS4.Gui.KissLabel();
            this.lblStempelnSeit = new KiSS4.Gui.KissLabel();
            this.lblArbeitslos = new KiSS4.Gui.KissLabel();
            this.lblAusgesteuertSeit = new KiSS4.Gui.KissLabel();
            this.lblAusgesteuert = new KiSS4.Gui.KissLabel();
            this.lblArbeitszeitProWoche = new KiSS4.Gui.KissLabel();
            this.lblLetzteAbgebrAusbildung = new KiSS4.Gui.KissLabel();
            this.lblHoechsteAusbildung = new KiSS4.Gui.KissLabel();
            this.lblArbeitgeber = new KiSS4.Gui.KissLabel();
            this.lblLetzteTaetigkeit = new KiSS4.Gui.KissLabel();
            this.lblErlernterBeruf = new KiSS4.Gui.KissLabel();
            this.lblBranche = new KiSS4.Gui.KissLabel();
            this.lblErwerbssituation4 = new KiSS4.Gui.KissLabel();
            this.cboErlernterBeruf = new KiSS4.Gui.KissButtonEdit();
            this.cboLetzteTaetigkeit = new KiSS4.Gui.KissButtonEdit();
            this.editArbeitgeber = new KiSS4.Gui.KissButtonEdit();
            this.editArbeitzeit = new KiSS4.Gui.KissCalcEdit();
            this.chkUnregelmaessig = new KiSS4.Gui.KissCheckEdit();
            this.dtpAusgesteuertSeit = new KiSS4.Gui.KissDateEdit();
            this.editArbeitsLosXMal = new KiSS4.Gui.KissCalcEdit();
            this.lblArbeitslosMal = new KiSS4.Gui.KissLabel();
            this.dtpStempelnSeit = new KiSS4.Gui.KissDateEdit();
            this.cboTeilZeitArbeitGrund2 = new KiSS4.Gui.KissLookUpEdit();
            this.cboTeilZeitArbeitGrund1 = new KiSS4.Gui.KissLookUpEdit();
            this.cboAusgesteuert = new KiSS4.Gui.KissLookUpEdit();
            this.edtIntegrationsstand = new KiSS4.Gui.KissLookUpEdit();
            this.lblIntegrationsstand = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryArbeit)).BeginInit();
            this.panelTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErwerbssituation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeilzeitgrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschaeftigungsgrad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErwerbssituation3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErwerbssituation2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErwerbssituation1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBeschaeftigungsgrad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBeschaeftigungsgrad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranche.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoechsteAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoechsteAusbildung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLetzteAbgebrocheneAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLetzteAbgebrocheneAusbildung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitszeitProWocheStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeilzeitgrund1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeilzeitgrund2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStempelnSeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitslos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgesteuertSeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgesteuert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitszeitProWoche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzteAbgebrAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoechsteAusbildung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitgeber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzteTaetigkeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErlernterBeruf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBranche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErwerbssituation4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErlernterBeruf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLetzteTaetigkeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArbeitgeber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArbeitzeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUnregelmaessig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAusgesteuertSeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArbeitsLosXMal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitslosMal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStempelnSeit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeilZeitArbeitGrund2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeilZeitArbeitGrund2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeilZeitArbeitGrund1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeilZeitArbeitGrund1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAusgesteuert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAusgesteuert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntegrationsstand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntegrationsstand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIntegrationsstand)).BeginInit();
            this.SuspendLayout();
            // 
            // qryArbeit
            // 
            this.qryArbeit.CanUpdate = true;
            this.qryArbeit.HostControl = this;
            this.qryArbeit.IsIdentityInsert = false;
            this.qryArbeit.TableName = "BaArbeitAusbildung";
            this.qryArbeit.AfterFill += new System.EventHandler(this.qryArbeit_AfterFill);
            this.qryArbeit.AfterInsert += new System.EventHandler(this.qryArbeit_AfterInsert);
            // 
            // panelTitel
            // 
            this.panelTitel.Controls.Add(this.picTitel);
            this.panelTitel.Controls.Add(this.lblTitel);
            this.panelTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitel.Location = new System.Drawing.Point(0, 0);
            this.panelTitel.Name = "panelTitel";
            this.panelTitel.Size = new System.Drawing.Size(719, 30);
            this.panelTitel.TabIndex = 333;
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
            this.lblTitel.Size = new System.Drawing.Size(681, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Arbeit";
            // 
            // lblErwerbssituation
            // 
            this.lblErwerbssituation.ForeColor = System.Drawing.Color.Black;
            this.lblErwerbssituation.Location = new System.Drawing.Point(7, 40);
            this.lblErwerbssituation.Name = "lblErwerbssituation";
            this.lblErwerbssituation.Size = new System.Drawing.Size(102, 24);
            this.lblErwerbssituation.TabIndex = 420;
            this.lblErwerbssituation.Text = "Erwerbssituation";
            // 
            // lblTeilzeitgrund
            // 
            this.lblTeilzeitgrund.ForeColor = System.Drawing.Color.Black;
            this.lblTeilzeitgrund.Location = new System.Drawing.Point(7, 162);
            this.lblTeilzeitgrund.Name = "lblTeilzeitgrund";
            this.lblTeilzeitgrund.Size = new System.Drawing.Size(130, 24);
            this.lblTeilzeitgrund.TabIndex = 419;
            this.lblTeilzeitgrund.Tag = "";
            this.lblTeilzeitgrund.Text = "Teilzeitgrund";
            // 
            // lblBeschaeftigungsgrad
            // 
            this.lblBeschaeftigungsgrad.ForeColor = System.Drawing.Color.Black;
            this.lblBeschaeftigungsgrad.Location = new System.Drawing.Point(7, 139);
            this.lblBeschaeftigungsgrad.Name = "lblBeschaeftigungsgrad";
            this.lblBeschaeftigungsgrad.Size = new System.Drawing.Size(116, 24);
            this.lblBeschaeftigungsgrad.TabIndex = 418;
            this.lblBeschaeftigungsgrad.Text = "Beschäftigungsgrad";
            // 
            // cboErwerbssituation1
            // 
            this.cboErwerbssituation1.DataMember = "ErwerbssituationStatus1Code";
            this.cboErwerbssituation1.DataSource = this.qryArbeit;
            this.cboErwerbssituation1.Location = new System.Drawing.Point(153, 40);
            this.cboErwerbssituation1.LOVName = "Erwerbssituation";
            this.cboErwerbssituation1.Name = "cboErwerbssituation1";
            this.cboErwerbssituation1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboErwerbssituation1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboErwerbssituation1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboErwerbssituation1.Properties.Appearance.Options.UseBackColor = true;
            this.cboErwerbssituation1.Properties.Appearance.Options.UseBorderColor = true;
            this.cboErwerbssituation1.Properties.Appearance.Options.UseFont = true;
            this.cboErwerbssituation1.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboErwerbssituation1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboErwerbssituation1.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboErwerbssituation1.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboErwerbssituation1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.cboErwerbssituation1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.cboErwerbssituation1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboErwerbssituation1.Properties.NullText = "";
            this.cboErwerbssituation1.Properties.ShowFooter = false;
            this.cboErwerbssituation1.Properties.ShowHeader = false;
            this.cboErwerbssituation1.Size = new System.Drawing.Size(355, 24);
            this.cboErwerbssituation1.TabIndex = 0;
            this.cboErwerbssituation1.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.cboErwerbssituation_UserModifiedFld);
            // 
            // cboErwerbssituation2
            // 
            this.cboErwerbssituation2.DataMember = "ErwerbssituationStatus2Code";
            this.cboErwerbssituation2.DataSource = this.qryArbeit;
            this.cboErwerbssituation2.Location = new System.Drawing.Point(153, 63);
            this.cboErwerbssituation2.LOVName = "Erwerbssituation";
            this.cboErwerbssituation2.Name = "cboErwerbssituation2";
            this.cboErwerbssituation2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboErwerbssituation2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboErwerbssituation2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboErwerbssituation2.Properties.Appearance.Options.UseBackColor = true;
            this.cboErwerbssituation2.Properties.Appearance.Options.UseBorderColor = true;
            this.cboErwerbssituation2.Properties.Appearance.Options.UseFont = true;
            this.cboErwerbssituation2.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboErwerbssituation2.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboErwerbssituation2.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboErwerbssituation2.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboErwerbssituation2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.cboErwerbssituation2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.cboErwerbssituation2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboErwerbssituation2.Properties.NullText = "";
            this.cboErwerbssituation2.Properties.ShowFooter = false;
            this.cboErwerbssituation2.Properties.ShowHeader = false;
            this.cboErwerbssituation2.Size = new System.Drawing.Size(355, 24);
            this.cboErwerbssituation2.TabIndex = 1;
            this.cboErwerbssituation2.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.cboErwerbssituation_UserModifiedFld);
            // 
            // cboErwerbssituation4
            // 
            this.cboErwerbssituation4.DataMember = "ErwerbssituationStatus4Code";
            this.cboErwerbssituation4.DataSource = this.qryArbeit;
            this.cboErwerbssituation4.Location = new System.Drawing.Point(153, 109);
            this.cboErwerbssituation4.LOVName = "Erwerbssituation";
            this.cboErwerbssituation4.Name = "cboErwerbssituation4";
            this.cboErwerbssituation4.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboErwerbssituation4.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboErwerbssituation4.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboErwerbssituation4.Properties.Appearance.Options.UseBackColor = true;
            this.cboErwerbssituation4.Properties.Appearance.Options.UseBorderColor = true;
            this.cboErwerbssituation4.Properties.Appearance.Options.UseFont = true;
            this.cboErwerbssituation4.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboErwerbssituation4.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboErwerbssituation4.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboErwerbssituation4.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboErwerbssituation4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.cboErwerbssituation4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.cboErwerbssituation4.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboErwerbssituation4.Properties.NullText = "";
            this.cboErwerbssituation4.Properties.ShowFooter = false;
            this.cboErwerbssituation4.Properties.ShowHeader = false;
            this.cboErwerbssituation4.Size = new System.Drawing.Size(355, 24);
            this.cboErwerbssituation4.TabIndex = 3;
            this.cboErwerbssituation4.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.cboErwerbssituation_UserModifiedFld);
            // 
            // cboErwerbssituation3
            // 
            this.cboErwerbssituation3.DataMember = "ErwerbssituationStatus3Code";
            this.cboErwerbssituation3.DataSource = this.qryArbeit;
            this.cboErwerbssituation3.Location = new System.Drawing.Point(153, 86);
            this.cboErwerbssituation3.LOVName = "Erwerbssituation";
            this.cboErwerbssituation3.Name = "cboErwerbssituation3";
            this.cboErwerbssituation3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboErwerbssituation3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboErwerbssituation3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboErwerbssituation3.Properties.Appearance.Options.UseBackColor = true;
            this.cboErwerbssituation3.Properties.Appearance.Options.UseBorderColor = true;
            this.cboErwerbssituation3.Properties.Appearance.Options.UseFont = true;
            this.cboErwerbssituation3.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboErwerbssituation3.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboErwerbssituation3.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboErwerbssituation3.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboErwerbssituation3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.cboErwerbssituation3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.cboErwerbssituation3.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboErwerbssituation3.Properties.NullText = "";
            this.cboErwerbssituation3.Properties.ShowFooter = false;
            this.cboErwerbssituation3.Properties.ShowHeader = false;
            this.cboErwerbssituation3.Size = new System.Drawing.Size(355, 24);
            this.cboErwerbssituation3.TabIndex = 2;
            this.cboErwerbssituation3.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.cboErwerbssituation_UserModifiedFld);
            // 
            // lblErwerbssituation3
            // 
            this.lblErwerbssituation3.ForeColor = System.Drawing.Color.Black;
            this.lblErwerbssituation3.Location = new System.Drawing.Point(137, 86);
            this.lblErwerbssituation3.Name = "lblErwerbssituation3";
            this.lblErwerbssituation3.Size = new System.Drawing.Size(10, 24);
            this.lblErwerbssituation3.TabIndex = 425;
            this.lblErwerbssituation3.Text = "3.";
            // 
            // lblErwerbssituation2
            // 
            this.lblErwerbssituation2.ForeColor = System.Drawing.Color.Black;
            this.lblErwerbssituation2.Location = new System.Drawing.Point(137, 63);
            this.lblErwerbssituation2.Name = "lblErwerbssituation2";
            this.lblErwerbssituation2.Size = new System.Drawing.Size(10, 24);
            this.lblErwerbssituation2.TabIndex = 426;
            this.lblErwerbssituation2.Text = "2.";
            // 
            // lblErwerbssituation1
            // 
            this.lblErwerbssituation1.ForeColor = System.Drawing.Color.Black;
            this.lblErwerbssituation1.Location = new System.Drawing.Point(137, 40);
            this.lblErwerbssituation1.Name = "lblErwerbssituation1";
            this.lblErwerbssituation1.Size = new System.Drawing.Size(10, 24);
            this.lblErwerbssituation1.TabIndex = 427;
            this.lblErwerbssituation1.Text = "1.";
            // 
            // cboBeschaeftigungsgrad
            // 
            this.cboBeschaeftigungsgrad.DataMember = "BeschaeftigungsGradCode";
            this.cboBeschaeftigungsgrad.DataSource = this.qryArbeit;
            this.cboBeschaeftigungsgrad.Location = new System.Drawing.Point(153, 139);
            this.cboBeschaeftigungsgrad.LOVName = "Beschaeftigungsgrad";
            this.cboBeschaeftigungsgrad.Name = "cboBeschaeftigungsgrad";
            this.cboBeschaeftigungsgrad.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboBeschaeftigungsgrad.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboBeschaeftigungsgrad.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboBeschaeftigungsgrad.Properties.Appearance.Options.UseBackColor = true;
            this.cboBeschaeftigungsgrad.Properties.Appearance.Options.UseBorderColor = true;
            this.cboBeschaeftigungsgrad.Properties.Appearance.Options.UseFont = true;
            this.cboBeschaeftigungsgrad.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboBeschaeftigungsgrad.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboBeschaeftigungsgrad.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboBeschaeftigungsgrad.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboBeschaeftigungsgrad.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.cboBeschaeftigungsgrad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.cboBeschaeftigungsgrad.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboBeschaeftigungsgrad.Properties.NullText = "";
            this.cboBeschaeftigungsgrad.Properties.ShowFooter = false;
            this.cboBeschaeftigungsgrad.Properties.ShowHeader = false;
            this.cboBeschaeftigungsgrad.Size = new System.Drawing.Size(250, 24);
            this.cboBeschaeftigungsgrad.TabIndex = 4;
            this.cboBeschaeftigungsgrad.EditValueChanged += new System.EventHandler(this.cboBeschaeftigungsgrad_EditValueChanged);
            // 
            // editBemerkungRTF
            // 
            this.editBemerkungRTF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editBemerkungRTF.BackColor = System.Drawing.Color.White;
            this.editBemerkungRTF.DataMember = "Bemerkung";
            this.editBemerkungRTF.DataSource = this.qryArbeit;
            this.editBemerkungRTF.Font = new System.Drawing.Font("Arial", 10F);
            this.editBemerkungRTF.Location = new System.Drawing.Point(153, 402);
            this.editBemerkungRTF.Margin = new System.Windows.Forms.Padding(3, 3, 9, 9);
            this.editBemerkungRTF.Name = "editBemerkungRTF";
            this.editBemerkungRTF.Size = new System.Drawing.Size(557, 180);
            this.editBemerkungRTF.TabIndex = 20;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.ForeColor = System.Drawing.Color.Black;
            this.lblBemerkung.Location = new System.Drawing.Point(7, 402);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(116, 24);
            this.lblBemerkung.TabIndex = 429;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // cboBranche
            // 
            this.cboBranche.DataMember = "BrancheCode";
            this.cboBranche.DataSource = this.qryArbeit;
            this.cboBranche.Location = new System.Drawing.Point(153, 215);
            this.cboBranche.LOVName = "Branche";
            this.cboBranche.Name = "cboBranche";
            this.cboBranche.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboBranche.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboBranche.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboBranche.Properties.Appearance.Options.UseBackColor = true;
            this.cboBranche.Properties.Appearance.Options.UseBorderColor = true;
            this.cboBranche.Properties.Appearance.Options.UseFont = true;
            this.cboBranche.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboBranche.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboBranche.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboBranche.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboBranche.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.cboBranche.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.cboBranche.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboBranche.Properties.NullText = "";
            this.cboBranche.Properties.ShowFooter = false;
            this.cboBranche.Properties.ShowHeader = false;
            this.cboBranche.Size = new System.Drawing.Size(557, 24);
            this.cboBranche.TabIndex = 7;
            // 
            // cboHoechsteAusbildung
            // 
            this.cboHoechsteAusbildung.DataMember = "HoechsteAusbildungCode";
            this.cboHoechsteAusbildung.DataSource = this.qryArbeit;
            this.cboHoechsteAusbildung.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboHoechsteAusbildung.Location = new System.Drawing.Point(153, 320);
            this.cboHoechsteAusbildung.LOVName = "Ausbildungstyp";
            this.cboHoechsteAusbildung.Name = "cboHoechsteAusbildung";
            this.cboHoechsteAusbildung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboHoechsteAusbildung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboHoechsteAusbildung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboHoechsteAusbildung.Properties.Appearance.Options.UseBackColor = true;
            this.cboHoechsteAusbildung.Properties.Appearance.Options.UseBorderColor = true;
            this.cboHoechsteAusbildung.Properties.Appearance.Options.UseFont = true;
            this.cboHoechsteAusbildung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboHoechsteAusbildung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboHoechsteAusbildung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboHoechsteAusbildung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboHoechsteAusbildung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.cboHoechsteAusbildung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.cboHoechsteAusbildung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboHoechsteAusbildung.Properties.NullText = "";
            this.cboHoechsteAusbildung.Properties.ShowFooter = false;
            this.cboHoechsteAusbildung.Properties.ShowHeader = false;
            this.cboHoechsteAusbildung.Size = new System.Drawing.Size(250, 24);
            this.cboHoechsteAusbildung.TabIndex = 11;
            // 
            // cboLetzteAbgebrocheneAusbildung
            // 
            this.cboLetzteAbgebrocheneAusbildung.DataMember = "AbgebrochenAusbildungCode";
            this.cboLetzteAbgebrocheneAusbildung.DataSource = this.qryArbeit;
            this.cboLetzteAbgebrocheneAusbildung.Location = new System.Drawing.Point(153, 343);
            this.cboLetzteAbgebrocheneAusbildung.LOVName = "Ausbildungstyp";
            this.cboLetzteAbgebrocheneAusbildung.Name = "cboLetzteAbgebrocheneAusbildung";
            this.cboLetzteAbgebrocheneAusbildung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboLetzteAbgebrocheneAusbildung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboLetzteAbgebrocheneAusbildung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboLetzteAbgebrocheneAusbildung.Properties.Appearance.Options.UseBackColor = true;
            this.cboLetzteAbgebrocheneAusbildung.Properties.Appearance.Options.UseBorderColor = true;
            this.cboLetzteAbgebrocheneAusbildung.Properties.Appearance.Options.UseFont = true;
            this.cboLetzteAbgebrocheneAusbildung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboLetzteAbgebrocheneAusbildung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboLetzteAbgebrocheneAusbildung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboLetzteAbgebrocheneAusbildung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboLetzteAbgebrocheneAusbildung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.cboLetzteAbgebrocheneAusbildung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.cboLetzteAbgebrocheneAusbildung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboLetzteAbgebrocheneAusbildung.Properties.NullText = "";
            this.cboLetzteAbgebrocheneAusbildung.Properties.ShowFooter = false;
            this.cboLetzteAbgebrocheneAusbildung.Properties.ShowHeader = false;
            this.cboLetzteAbgebrocheneAusbildung.Size = new System.Drawing.Size(250, 24);
            this.cboLetzteAbgebrocheneAusbildung.TabIndex = 12;
            // 
            // lblArbeitszeitProWocheStd
            // 
            this.lblArbeitszeitProWocheStd.ForeColor = System.Drawing.Color.Black;
            this.lblArbeitszeitProWocheStd.Location = new System.Drawing.Point(663, 139);
            this.lblArbeitszeitProWocheStd.Name = "lblArbeitszeitProWocheStd";
            this.lblArbeitszeitProWocheStd.Size = new System.Drawing.Size(47, 24);
            this.lblArbeitszeitProWocheStd.TabIndex = 434;
            this.lblArbeitszeitProWocheStd.Text = "Std.";
            // 
            // lblTeilzeitgrund1
            // 
            this.lblTeilzeitgrund1.ForeColor = System.Drawing.Color.Black;
            this.lblTeilzeitgrund1.Location = new System.Drawing.Point(137, 162);
            this.lblTeilzeitgrund1.Name = "lblTeilzeitgrund1";
            this.lblTeilzeitgrund1.Size = new System.Drawing.Size(10, 24);
            this.lblTeilzeitgrund1.TabIndex = 435;
            this.lblTeilzeitgrund1.Text = "1.";
            // 
            // lblTeilzeitgrund2
            // 
            this.lblTeilzeitgrund2.ForeColor = System.Drawing.Color.Black;
            this.lblTeilzeitgrund2.Location = new System.Drawing.Point(137, 185);
            this.lblTeilzeitgrund2.Name = "lblTeilzeitgrund2";
            this.lblTeilzeitgrund2.Size = new System.Drawing.Size(10, 24);
            this.lblTeilzeitgrund2.TabIndex = 436;
            this.lblTeilzeitgrund2.Text = "2.";
            // 
            // lblStempelnSeit
            // 
            this.lblStempelnSeit.ForeColor = System.Drawing.Color.Black;
            this.lblStempelnSeit.Location = new System.Drawing.Point(450, 245);
            this.lblStempelnSeit.Name = "lblStempelnSeit";
            this.lblStempelnSeit.Size = new System.Drawing.Size(104, 24);
            this.lblStempelnSeit.TabIndex = 437;
            this.lblStempelnSeit.Text = "Stempeln seit";
            // 
            // lblArbeitslos
            // 
            this.lblArbeitslos.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblArbeitslos.ForeColor = System.Drawing.Color.Black;
            this.lblArbeitslos.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblArbeitslos.Location = new System.Drawing.Point(450, 324);
            this.lblArbeitslos.Name = "lblArbeitslos";
            this.lblArbeitslos.Size = new System.Drawing.Size(104, 37);
            this.lblArbeitslos.TabIndex = 438;
            this.lblArbeitslos.Text = "arbeitslos \r\n(letzte 3 Jahre)";
            // 
            // lblAusgesteuertSeit
            // 
            this.lblAusgesteuertSeit.ForeColor = System.Drawing.Color.Black;
            this.lblAusgesteuertSeit.Location = new System.Drawing.Point(450, 292);
            this.lblAusgesteuertSeit.Name = "lblAusgesteuertSeit";
            this.lblAusgesteuertSeit.Size = new System.Drawing.Size(145, 24);
            this.lblAusgesteuertSeit.TabIndex = 439;
            this.lblAusgesteuertSeit.Tag = "";
            this.lblAusgesteuertSeit.Text = "Ausgesteuert seit";
            // 
            // lblAusgesteuert
            // 
            this.lblAusgesteuert.ForeColor = System.Drawing.Color.Black;
            this.lblAusgesteuert.Location = new System.Drawing.Point(450, 269);
            this.lblAusgesteuert.Name = "lblAusgesteuert";
            this.lblAusgesteuert.Size = new System.Drawing.Size(104, 24);
            this.lblAusgesteuert.TabIndex = 440;
            this.lblAusgesteuert.Text = "Ausgesteuert";
            // 
            // lblArbeitszeitProWoche
            // 
            this.lblArbeitszeitProWoche.ForeColor = System.Drawing.Color.Black;
            this.lblArbeitszeitProWoche.Location = new System.Drawing.Point(482, 139);
            this.lblArbeitszeitProWoche.Name = "lblArbeitszeitProWoche";
            this.lblArbeitszeitProWoche.Size = new System.Drawing.Size(112, 24);
            this.lblArbeitszeitProWoche.TabIndex = 441;
            this.lblArbeitszeitProWoche.Text = "Arbeitszeit/Woche";
            // 
            // lblLetzteAbgebrAusbildung
            // 
            this.lblLetzteAbgebrAusbildung.ForeColor = System.Drawing.Color.Black;
            this.lblLetzteAbgebrAusbildung.Location = new System.Drawing.Point(7, 343);
            this.lblLetzteAbgebrAusbildung.Name = "lblLetzteAbgebrAusbildung";
            this.lblLetzteAbgebrAusbildung.Size = new System.Drawing.Size(116, 24);
            this.lblLetzteAbgebrAusbildung.TabIndex = 442;
            this.lblLetzteAbgebrAusbildung.Text = "Letzte abgebr. Ausb.";
            // 
            // lblHoechsteAusbildung
            // 
            this.lblHoechsteAusbildung.ForeColor = System.Drawing.Color.Black;
            this.lblHoechsteAusbildung.Location = new System.Drawing.Point(7, 320);
            this.lblHoechsteAusbildung.Name = "lblHoechsteAusbildung";
            this.lblHoechsteAusbildung.Size = new System.Drawing.Size(116, 24);
            this.lblHoechsteAusbildung.TabIndex = 443;
            this.lblHoechsteAusbildung.Text = "höchste Ausbildung";
            // 
            // lblArbeitgeber
            // 
            this.lblArbeitgeber.ForeColor = System.Drawing.Color.Black;
            this.lblArbeitgeber.Location = new System.Drawing.Point(7, 292);
            this.lblArbeitgeber.Name = "lblArbeitgeber";
            this.lblArbeitgeber.Size = new System.Drawing.Size(116, 24);
            this.lblArbeitgeber.TabIndex = 444;
            this.lblArbeitgeber.Text = "Arbeitgeber";
            // 
            // lblLetzteTaetigkeit
            // 
            this.lblLetzteTaetigkeit.ForeColor = System.Drawing.Color.Black;
            this.lblLetzteTaetigkeit.Location = new System.Drawing.Point(7, 268);
            this.lblLetzteTaetigkeit.Name = "lblLetzteTaetigkeit";
            this.lblLetzteTaetigkeit.Size = new System.Drawing.Size(116, 24);
            this.lblLetzteTaetigkeit.TabIndex = 445;
            this.lblLetzteTaetigkeit.Text = "Letzte Tätigkeit";
            // 
            // lblErlernterBeruf
            // 
            this.lblErlernterBeruf.ForeColor = System.Drawing.Color.Black;
            this.lblErlernterBeruf.Location = new System.Drawing.Point(7, 245);
            this.lblErlernterBeruf.Name = "lblErlernterBeruf";
            this.lblErlernterBeruf.Size = new System.Drawing.Size(116, 24);
            this.lblErlernterBeruf.TabIndex = 446;
            this.lblErlernterBeruf.Text = "Erlernter Beruf";
            // 
            // lblBranche
            // 
            this.lblBranche.ForeColor = System.Drawing.Color.Black;
            this.lblBranche.Location = new System.Drawing.Point(7, 215);
            this.lblBranche.Name = "lblBranche";
            this.lblBranche.Size = new System.Drawing.Size(116, 24);
            this.lblBranche.TabIndex = 447;
            this.lblBranche.Text = "Branche";
            // 
            // lblErwerbssituation4
            // 
            this.lblErwerbssituation4.ForeColor = System.Drawing.Color.Black;
            this.lblErwerbssituation4.Location = new System.Drawing.Point(137, 109);
            this.lblErwerbssituation4.Name = "lblErwerbssituation4";
            this.lblErwerbssituation4.Size = new System.Drawing.Size(10, 24);
            this.lblErwerbssituation4.TabIndex = 448;
            this.lblErwerbssituation4.Text = "4.";
            // 
            // cboErlernterBeruf
            // 
            this.cboErlernterBeruf.DataMember = "ErlernterBeruf";
            this.cboErlernterBeruf.DataSource = this.qryArbeit;
            this.cboErlernterBeruf.Location = new System.Drawing.Point(153, 245);
            this.cboErlernterBeruf.Name = "cboErlernterBeruf";
            this.cboErlernterBeruf.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboErlernterBeruf.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboErlernterBeruf.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboErlernterBeruf.Properties.Appearance.Options.UseBackColor = true;
            this.cboErlernterBeruf.Properties.Appearance.Options.UseBorderColor = true;
            this.cboErlernterBeruf.Properties.Appearance.Options.UseFont = true;
            this.cboErlernterBeruf.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.cboErlernterBeruf.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.cboErlernterBeruf.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboErlernterBeruf.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.cboErlernterBeruf.Size = new System.Drawing.Size(250, 24);
            this.cboErlernterBeruf.TabIndex = 8;
            this.cboErlernterBeruf.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.cboErlernterBeruf_UserModifiedFld);
            // 
            // cboLetzteTaetigkeit
            // 
            this.cboLetzteTaetigkeit.DataMember = "Beruf";
            this.cboLetzteTaetigkeit.DataSource = this.qryArbeit;
            this.cboLetzteTaetigkeit.Location = new System.Drawing.Point(153, 268);
            this.cboLetzteTaetigkeit.Name = "cboLetzteTaetigkeit";
            this.cboLetzteTaetigkeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboLetzteTaetigkeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboLetzteTaetigkeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboLetzteTaetigkeit.Properties.Appearance.Options.UseBackColor = true;
            this.cboLetzteTaetigkeit.Properties.Appearance.Options.UseBorderColor = true;
            this.cboLetzteTaetigkeit.Properties.Appearance.Options.UseFont = true;
            this.cboLetzteTaetigkeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.cboLetzteTaetigkeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.cboLetzteTaetigkeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboLetzteTaetigkeit.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.cboLetzteTaetigkeit.Size = new System.Drawing.Size(250, 24);
            this.cboLetzteTaetigkeit.TabIndex = 9;
            this.cboLetzteTaetigkeit.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.cboLetzteTaetigkeit_UserModifiedFld);
            // 
            // editArbeitgeber
            // 
            this.editArbeitgeber.DataMember = "Arbeitgeber";
            this.editArbeitgeber.DataSource = this.qryArbeit;
            this.editArbeitgeber.Location = new System.Drawing.Point(153, 291);
            this.editArbeitgeber.Name = "editArbeitgeber";
            this.editArbeitgeber.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editArbeitgeber.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editArbeitgeber.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editArbeitgeber.Properties.Appearance.Options.UseBackColor = true;
            this.editArbeitgeber.Properties.Appearance.Options.UseBorderColor = true;
            this.editArbeitgeber.Properties.Appearance.Options.UseFont = true;
            this.editArbeitgeber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.editArbeitgeber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.editArbeitgeber.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editArbeitgeber.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editArbeitgeber.Size = new System.Drawing.Size(250, 24);
            this.editArbeitgeber.TabIndex = 10;
            this.editArbeitgeber.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editArbeitgeber_UserModifiedFld);
            // 
            // editArbeitzeit
            // 
            this.editArbeitzeit.DataMember = "Arbeitszeit";
            this.editArbeitzeit.DataSource = this.qryArbeit;
            this.editArbeitzeit.Location = new System.Drawing.Point(600, 139);
            this.editArbeitzeit.Name = "editArbeitzeit";
            this.editArbeitzeit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editArbeitzeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editArbeitzeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editArbeitzeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editArbeitzeit.Properties.Appearance.Options.UseBackColor = true;
            this.editArbeitzeit.Properties.Appearance.Options.UseBorderColor = true;
            this.editArbeitzeit.Properties.Appearance.Options.UseFont = true;
            this.editArbeitzeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editArbeitzeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editArbeitzeit.Size = new System.Drawing.Size(57, 24);
            this.editArbeitzeit.TabIndex = 14;
            // 
            // chkUnregelmaessig
            // 
            this.chkUnregelmaessig.DataMember = "IsVariableArbeitszeit";
            this.chkUnregelmaessig.DataSource = this.qryArbeit;
            this.chkUnregelmaessig.Location = new System.Drawing.Point(600, 169);
            this.chkUnregelmaessig.Name = "chkUnregelmaessig";
            this.chkUnregelmaessig.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkUnregelmaessig.Properties.Appearance.Options.UseBackColor = true;
            this.chkUnregelmaessig.Properties.Caption = "unregelmässig";
            this.chkUnregelmaessig.Size = new System.Drawing.Size(110, 19);
            this.chkUnregelmaessig.TabIndex = 15;
            // 
            // dtpAusgesteuertSeit
            // 
            this.dtpAusgesteuertSeit.DataMember = "AusgesteuertDatum";
            this.dtpAusgesteuertSeit.DataSource = this.qryArbeit;
            this.dtpAusgesteuertSeit.EditValue = null;
            this.dtpAusgesteuertSeit.Location = new System.Drawing.Point(600, 291);
            this.dtpAusgesteuertSeit.Name = "dtpAusgesteuertSeit";
            this.dtpAusgesteuertSeit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtpAusgesteuertSeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dtpAusgesteuertSeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dtpAusgesteuertSeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dtpAusgesteuertSeit.Properties.Appearance.Options.UseBackColor = true;
            this.dtpAusgesteuertSeit.Properties.Appearance.Options.UseBorderColor = true;
            this.dtpAusgesteuertSeit.Properties.Appearance.Options.UseFont = true;
            this.dtpAusgesteuertSeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.dtpAusgesteuertSeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dtpAusgesteuertSeit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.dtpAusgesteuertSeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dtpAusgesteuertSeit.Properties.ShowToday = false;
            this.dtpAusgesteuertSeit.Size = new System.Drawing.Size(110, 24);
            this.dtpAusgesteuertSeit.TabIndex = 18;
            // 
            // editArbeitsLosXMal
            // 
            this.editArbeitsLosXMal.DataMember = "WieOftArbeitslos";
            this.editArbeitsLosXMal.DataSource = this.qryArbeit;
            this.editArbeitsLosXMal.Location = new System.Drawing.Point(600, 324);
            this.editArbeitsLosXMal.Name = "editArbeitsLosXMal";
            this.editArbeitsLosXMal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editArbeitsLosXMal.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editArbeitsLosXMal.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editArbeitsLosXMal.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editArbeitsLosXMal.Properties.Appearance.Options.UseBackColor = true;
            this.editArbeitsLosXMal.Properties.Appearance.Options.UseBorderColor = true;
            this.editArbeitsLosXMal.Properties.Appearance.Options.UseFont = true;
            this.editArbeitsLosXMal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editArbeitsLosXMal.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editArbeitsLosXMal.Size = new System.Drawing.Size(57, 24);
            this.editArbeitsLosXMal.TabIndex = 19;
            // 
            // lblArbeitslosMal
            // 
            this.lblArbeitslosMal.ForeColor = System.Drawing.Color.Black;
            this.lblArbeitslosMal.Location = new System.Drawing.Point(663, 324);
            this.lblArbeitslosMal.Name = "lblArbeitslosMal";
            this.lblArbeitslosMal.Size = new System.Drawing.Size(47, 24);
            this.lblArbeitslosMal.TabIndex = 459;
            this.lblArbeitslosMal.Text = "mal";
            // 
            // dtpStempelnSeit
            // 
            this.dtpStempelnSeit.DataMember = "StempelDatum";
            this.dtpStempelnSeit.DataSource = this.qryArbeit;
            this.dtpStempelnSeit.EditValue = null;
            this.dtpStempelnSeit.Location = new System.Drawing.Point(600, 245);
            this.dtpStempelnSeit.Name = "dtpStempelnSeit";
            this.dtpStempelnSeit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtpStempelnSeit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dtpStempelnSeit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dtpStempelnSeit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dtpStempelnSeit.Properties.Appearance.Options.UseBackColor = true;
            this.dtpStempelnSeit.Properties.Appearance.Options.UseBorderColor = true;
            this.dtpStempelnSeit.Properties.Appearance.Options.UseFont = true;
            this.dtpStempelnSeit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.dtpStempelnSeit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("dtpStempelnSeit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.dtpStempelnSeit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dtpStempelnSeit.Properties.ShowToday = false;
            this.dtpStempelnSeit.Size = new System.Drawing.Size(110, 24);
            this.dtpStempelnSeit.TabIndex = 16;
            // 
            // cboTeilZeitArbeitGrund2
            // 
            this.cboTeilZeitArbeitGrund2.DataMember = "GrundTeilzeitarbeit2Code";
            this.cboTeilZeitArbeitGrund2.DataSource = this.qryArbeit;
            this.cboTeilZeitArbeitGrund2.Location = new System.Drawing.Point(153, 185);
            this.cboTeilZeitArbeitGrund2.LOVName = "Grundteilzeit";
            this.cboTeilZeitArbeitGrund2.Name = "cboTeilZeitArbeitGrund2";
            this.cboTeilZeitArbeitGrund2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboTeilZeitArbeitGrund2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboTeilZeitArbeitGrund2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboTeilZeitArbeitGrund2.Properties.Appearance.Options.UseBackColor = true;
            this.cboTeilZeitArbeitGrund2.Properties.Appearance.Options.UseBorderColor = true;
            this.cboTeilZeitArbeitGrund2.Properties.Appearance.Options.UseFont = true;
            this.cboTeilZeitArbeitGrund2.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboTeilZeitArbeitGrund2.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboTeilZeitArbeitGrund2.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboTeilZeitArbeitGrund2.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboTeilZeitArbeitGrund2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.cboTeilZeitArbeitGrund2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.cboTeilZeitArbeitGrund2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboTeilZeitArbeitGrund2.Properties.NullText = "";
            this.cboTeilZeitArbeitGrund2.Properties.ShowFooter = false;
            this.cboTeilZeitArbeitGrund2.Properties.ShowHeader = false;
            this.cboTeilZeitArbeitGrund2.Size = new System.Drawing.Size(250, 24);
            this.cboTeilZeitArbeitGrund2.TabIndex = 6;
            // 
            // cboTeilZeitArbeitGrund1
            // 
            this.cboTeilZeitArbeitGrund1.DataMember = "GrundTeilzeitarbeit1Code";
            this.cboTeilZeitArbeitGrund1.DataSource = this.qryArbeit;
            this.cboTeilZeitArbeitGrund1.Location = new System.Drawing.Point(153, 162);
            this.cboTeilZeitArbeitGrund1.LOVName = "Grundteilzeit";
            this.cboTeilZeitArbeitGrund1.Name = "cboTeilZeitArbeitGrund1";
            this.cboTeilZeitArbeitGrund1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboTeilZeitArbeitGrund1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboTeilZeitArbeitGrund1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboTeilZeitArbeitGrund1.Properties.Appearance.Options.UseBackColor = true;
            this.cboTeilZeitArbeitGrund1.Properties.Appearance.Options.UseBorderColor = true;
            this.cboTeilZeitArbeitGrund1.Properties.Appearance.Options.UseFont = true;
            this.cboTeilZeitArbeitGrund1.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboTeilZeitArbeitGrund1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboTeilZeitArbeitGrund1.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboTeilZeitArbeitGrund1.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboTeilZeitArbeitGrund1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.cboTeilZeitArbeitGrund1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.cboTeilZeitArbeitGrund1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboTeilZeitArbeitGrund1.Properties.NullText = "";
            this.cboTeilZeitArbeitGrund1.Properties.ShowFooter = false;
            this.cboTeilZeitArbeitGrund1.Properties.ShowHeader = false;
            this.cboTeilZeitArbeitGrund1.Size = new System.Drawing.Size(250, 24);
            this.cboTeilZeitArbeitGrund1.TabIndex = 5;
            // 
            // cboAusgesteuert
            // 
            this.cboAusgesteuert.DataMember = "AusgesteuertUnbekanntCode";
            this.cboAusgesteuert.DataSource = this.qryArbeit;
            this.cboAusgesteuert.Location = new System.Drawing.Point(600, 268);
            this.cboAusgesteuert.LOVName = "Nichtbekannt";
            this.cboAusgesteuert.Name = "cboAusgesteuert";
            this.cboAusgesteuert.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.cboAusgesteuert.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboAusgesteuert.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboAusgesteuert.Properties.Appearance.Options.UseBackColor = true;
            this.cboAusgesteuert.Properties.Appearance.Options.UseBorderColor = true;
            this.cboAusgesteuert.Properties.Appearance.Options.UseFont = true;
            this.cboAusgesteuert.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboAusgesteuert.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboAusgesteuert.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboAusgesteuert.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboAusgesteuert.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.cboAusgesteuert.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.cboAusgesteuert.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboAusgesteuert.Properties.NullText = "";
            this.cboAusgesteuert.Properties.ShowFooter = false;
            this.cboAusgesteuert.Properties.ShowHeader = false;
            this.cboAusgesteuert.Size = new System.Drawing.Size(110, 24);
            this.cboAusgesteuert.TabIndex = 17;
            // 
            // edtIntegrationsstand
            // 
            this.edtIntegrationsstand.DataMember = "IntegrationsstandCode";
            this.edtIntegrationsstand.DataSource = this.qryArbeit;
            this.edtIntegrationsstand.Location = new System.Drawing.Point(153, 372);
            this.edtIntegrationsstand.LOVName = "Integrationsstand";
            this.edtIntegrationsstand.Name = "edtIntegrationsstand";
            this.edtIntegrationsstand.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIntegrationsstand.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIntegrationsstand.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIntegrationsstand.Properties.Appearance.Options.UseBackColor = true;
            this.edtIntegrationsstand.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIntegrationsstand.Properties.Appearance.Options.UseFont = true;
            this.edtIntegrationsstand.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIntegrationsstand.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIntegrationsstand.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIntegrationsstand.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIntegrationsstand.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtIntegrationsstand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtIntegrationsstand.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIntegrationsstand.Properties.NullText = "";
            this.edtIntegrationsstand.Properties.ShowFooter = false;
            this.edtIntegrationsstand.Properties.ShowHeader = false;
            this.edtIntegrationsstand.Size = new System.Drawing.Size(557, 24);
            this.edtIntegrationsstand.TabIndex = 13;
            // 
            // lblIntegrationsstand
            // 
            this.lblIntegrationsstand.ForeColor = System.Drawing.Color.Black;
            this.lblIntegrationsstand.Location = new System.Drawing.Point(7, 372);
            this.lblIntegrationsstand.Name = "lblIntegrationsstand";
            this.lblIntegrationsstand.Size = new System.Drawing.Size(116, 24);
            this.lblIntegrationsstand.TabIndex = 461;
            this.lblIntegrationsstand.Text = "Integrationsstand";
            // 
            // CtlArbeit
            // 
            this.ActiveSQLQuery = this.qryArbeit;
            this.Controls.Add(this.edtIntegrationsstand);
            this.Controls.Add(this.lblIntegrationsstand);
            this.Controls.Add(this.cboAusgesteuert);
            this.Controls.Add(this.cboTeilZeitArbeitGrund1);
            this.Controls.Add(this.cboTeilZeitArbeitGrund2);
            this.Controls.Add(this.dtpStempelnSeit);
            this.Controls.Add(this.lblArbeitslosMal);
            this.Controls.Add(this.editArbeitsLosXMal);
            this.Controls.Add(this.dtpAusgesteuertSeit);
            this.Controls.Add(this.chkUnregelmaessig);
            this.Controls.Add(this.editArbeitzeit);
            this.Controls.Add(this.editArbeitgeber);
            this.Controls.Add(this.cboLetzteTaetigkeit);
            this.Controls.Add(this.cboErlernterBeruf);
            this.Controls.Add(this.lblErwerbssituation4);
            this.Controls.Add(this.lblBranche);
            this.Controls.Add(this.lblErlernterBeruf);
            this.Controls.Add(this.lblLetzteTaetigkeit);
            this.Controls.Add(this.lblArbeitgeber);
            this.Controls.Add(this.lblHoechsteAusbildung);
            this.Controls.Add(this.lblLetzteAbgebrAusbildung);
            this.Controls.Add(this.lblArbeitszeitProWoche);
            this.Controls.Add(this.lblAusgesteuert);
            this.Controls.Add(this.lblAusgesteuertSeit);
            this.Controls.Add(this.lblArbeitslos);
            this.Controls.Add(this.lblStempelnSeit);
            this.Controls.Add(this.lblTeilzeitgrund2);
            this.Controls.Add(this.lblTeilzeitgrund1);
            this.Controls.Add(this.lblArbeitszeitProWocheStd);
            this.Controls.Add(this.cboLetzteAbgebrocheneAusbildung);
            this.Controls.Add(this.cboHoechsteAusbildung);
            this.Controls.Add(this.cboBranche);
            this.Controls.Add(this.editBemerkungRTF);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.cboBeschaeftigungsgrad);
            this.Controls.Add(this.lblErwerbssituation1);
            this.Controls.Add(this.lblErwerbssituation2);
            this.Controls.Add(this.lblErwerbssituation3);
            this.Controls.Add(this.cboErwerbssituation3);
            this.Controls.Add(this.cboErwerbssituation4);
            this.Controls.Add(this.cboErwerbssituation2);
            this.Controls.Add(this.cboErwerbssituation1);
            this.Controls.Add(this.lblErwerbssituation);
            this.Controls.Add(this.lblTeilzeitgrund);
            this.Controls.Add(this.lblBeschaeftigungsgrad);
            this.Controls.Add(this.panelTitel);
            this.Name = "CtlArbeit";
            this.Size = new System.Drawing.Size(719, 591);
            ((System.ComponentModel.ISupportInitialize)(this.qryArbeit)).EndInit();
            this.panelTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErwerbssituation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeilzeitgrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeschaeftigungsgrad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErwerbssituation3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErwerbssituation3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErwerbssituation2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErwerbssituation1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBeschaeftigungsgrad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBeschaeftigungsgrad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranche.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoechsteAusbildung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoechsteAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLetzteAbgebrocheneAusbildung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLetzteAbgebrocheneAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitszeitProWocheStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeilzeitgrund1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeilzeitgrund2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStempelnSeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitslos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgesteuertSeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgesteuert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitszeitProWoche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzteAbgebrAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHoechsteAusbildung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitgeber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzteTaetigkeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErlernterBeruf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBranche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErwerbssituation4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboErlernterBeruf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLetzteTaetigkeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArbeitgeber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArbeitzeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUnregelmaessig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAusgesteuertSeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editArbeitsLosXMal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblArbeitslosMal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStempelnSeit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeilZeitArbeitGrund2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeilZeitArbeitGrund2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeilZeitArbeitGrund1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTeilZeitArbeitGrund1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAusgesteuert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAusgesteuert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntegrationsstand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIntegrationsstand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIntegrationsstand)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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

        private KiSS4.Gui.KissLookUpEdit cboAusgesteuert;
        private KiSS4.Gui.KissLookUpEdit cboBeschaeftigungsgrad;
        private KiSS4.Gui.KissLookUpEdit cboBranche;
        private KiSS4.Gui.KissButtonEdit cboErlernterBeruf;
        private KiSS4.Gui.KissLookUpEdit cboErwerbssituation1;
        private KiSS4.Gui.KissLookUpEdit cboErwerbssituation2;
        private KiSS4.Gui.KissLookUpEdit cboErwerbssituation3;
        private KiSS4.Gui.KissLookUpEdit cboErwerbssituation4;
        private KiSS4.Gui.KissLookUpEdit cboHoechsteAusbildung;
        private KiSS4.Gui.KissLookUpEdit cboLetzteAbgebrocheneAusbildung;
        private KiSS4.Gui.KissButtonEdit cboLetzteTaetigkeit;
        private KiSS4.Gui.KissLookUpEdit cboTeilZeitArbeitGrund1;
        private KiSS4.Gui.KissLookUpEdit cboTeilZeitArbeitGrund2;
        private KiSS4.Gui.KissCheckEdit chkUnregelmaessig;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit dtpAusgesteuertSeit;
        private KiSS4.Gui.KissDateEdit dtpStempelnSeit;
        private KiSS4.Gui.KissButtonEdit editArbeitgeber;
        private KiSS4.Gui.KissCalcEdit editArbeitsLosXMal;
        private KiSS4.Gui.KissCalcEdit editArbeitzeit;
        private KiSS4.Gui.KissRTFEdit editBemerkungRTF;
        private KiSS4.Gui.KissLookUpEdit edtIntegrationsstand;
        private KiSS4.Gui.KissLabel lblArbeitgeber;
        private KiSS4.Gui.KissLabel lblArbeitslos;
        private KiSS4.Gui.KissLabel lblArbeitslosMal;
        private KiSS4.Gui.KissLabel lblArbeitszeitProWoche;
        private KiSS4.Gui.KissLabel lblArbeitszeitProWocheStd;
        private KiSS4.Gui.KissLabel lblAusgesteuert;
        private KiSS4.Gui.KissLabel lblAusgesteuertSeit;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBeschaeftigungsgrad;
        private KiSS4.Gui.KissLabel lblBranche;
        private KiSS4.Gui.KissLabel lblErlernterBeruf;
        private KiSS4.Gui.KissLabel lblErwerbssituation;
        private KiSS4.Gui.KissLabel lblErwerbssituation1;
        private KiSS4.Gui.KissLabel lblErwerbssituation2;
        private KiSS4.Gui.KissLabel lblErwerbssituation3;
        private KiSS4.Gui.KissLabel lblErwerbssituation4;
        private KiSS4.Gui.KissLabel lblHoechsteAusbildung;
        private KiSS4.Gui.KissLabel lblIntegrationsstand;
        private KiSS4.Gui.KissLabel lblLetzteAbgebrAusbildung;
        private KiSS4.Gui.KissLabel lblLetzteTaetigkeit;
        private KiSS4.Gui.KissLabel lblStempelnSeit;
        private KiSS4.Gui.KissLabel lblTeilzeitgrund;
        private KiSS4.Gui.KissLabel lblTeilzeitgrund1;
        private KiSS4.Gui.KissLabel lblTeilzeitgrund2;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.Panel panelTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryArbeit;
    }
}