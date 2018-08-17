using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

using KiSS4.DB;
using KiSS4.Gui;

using Kiss.Interfaces.UI;

namespace KiSS4.Pendenzen
{
    partial class CtlFallLeistungBetrifftPerson
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFallLeistungBetrifftPerson));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtSAR = new KiSS4.Gui.KissTextEdit();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.edtFaLeistungID = new KiSS4.Gui.KissLookUpEdit();
            this.lblFaLeistungID = new KiSS4.Gui.KissLabel();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.lblFaFallID = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.edtFaFall = new KiSS4.Gui.KissButtonEdit();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery(this.components);
            this.qryFaFallPerson = new KiSS4.DB.SqlQuery(this.components);
            this.edtFaFallIdDropDown = new KiSS4.Gui.KissLookUpEdit();
            this.qryFaFalltraeger = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaLeistungID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaLeistungID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaLeistungID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaFallID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaFall.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaFallPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaFallIdDropDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaFallIdDropDown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaFalltraeger)).BeginInit();
            this.SuspendLayout();
            // 
            // edtSAR
            // 
            this.edtSAR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSAR.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSAR.Location = new System.Drawing.Point(114, 60);
            this.edtSAR.Name = "edtSAR";
            this.edtSAR.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSAR.Properties.Appearance.Options.UseBackColor = true;
            this.edtSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSAR.Properties.Appearance.Options.UseFont = true;
            this.edtSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSAR.Properties.ReadOnly = true;
            this.edtSAR.Size = new System.Drawing.Size(244, 24);
            this.edtSAR.TabIndex = 5;
            this.edtSAR.TabStop = false;
            // 
            // lblSAR
            // 
            this.lblSAR.Location = new System.Drawing.Point(0, 60);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(108, 24);
            this.lblSAR.TabIndex = 4;
            this.lblSAR.Text = "Leistungsverantw.";
            this.lblSAR.UseCompatibleTextRendering = true;
            // 
            // edtFaLeistungID
            // 
            this.edtFaLeistungID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFaLeistungID.Location = new System.Drawing.Point(114, 30);
            this.edtFaLeistungID.Name = "edtFaLeistungID";
            this.edtFaLeistungID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaLeistungID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaLeistungID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaLeistungID.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaLeistungID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaLeistungID.Properties.Appearance.Options.UseFont = true;
            this.edtFaLeistungID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFaLeistungID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaLeistungID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFaLeistungID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFaLeistungID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtFaLeistungID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtFaLeistungID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaLeistungID.Properties.Name = "kissLookUpEdit6.Properties";
            this.edtFaLeistungID.Properties.NullText = "";
            this.edtFaLeistungID.Properties.ShowFooter = false;
            this.edtFaLeistungID.Properties.ShowHeader = false;
            this.edtFaLeistungID.Size = new System.Drawing.Size(244, 24);
            this.edtFaLeistungID.TabIndex = 3;
            this.edtFaLeistungID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtFaLeistungID_UserModifiedFld);
            // 
            // lblFaLeistungID
            // 
            this.lblFaLeistungID.Location = new System.Drawing.Point(0, 30);
            this.lblFaLeistungID.Name = "lblFaLeistungID";
            this.lblFaLeistungID.Size = new System.Drawing.Size(108, 24);
            this.lblFaLeistungID.TabIndex = 2;
            this.lblFaLeistungID.Text = "Leistung";
            this.lblFaLeistungID.UseCompatibleTextRendering = true;
            // 
            // lblBaPersonID
            // 
            this.lblBaPersonID.Location = new System.Drawing.Point(0, 90);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(108, 24);
            this.lblBaPersonID.TabIndex = 6;
            this.lblBaPersonID.Text = "betrifft Person";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            // 
            // lblFaFallID
            // 
            this.lblFaFallID.Location = new System.Drawing.Point(0, 0);
            this.lblFaFallID.Name = "lblFaFallID";
            this.lblFaFallID.Size = new System.Drawing.Size(108, 24);
            this.lblFaFallID.TabIndex = 0;
            this.lblFaFallID.Text = "Fallträger";
            this.lblFaFallID.UseCompatibleTextRendering = true;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBaPersonID.Location = new System.Drawing.Point(114, 90);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaPersonID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Size = new System.Drawing.Size(244, 24);
            this.edtBaPersonID.TabIndex = 7;
            // 
            // edtFaFall
            // 
            this.edtFaFall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFaFall.Location = new System.Drawing.Point(114, 0);
            this.edtFaFall.LookupSQL = null;
            this.edtFaFall.Name = "edtFaFall";
            this.edtFaFall.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaFall.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaFall.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaFall.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaFall.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaFall.Properties.Appearance.Options.UseFont = true;
            this.edtFaFall.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtFaFall.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtFaFall.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaFall.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtFaFall.Size = new System.Drawing.Size(126, 24);
            this.edtFaFall.TabIndex = 1;
            this.edtFaFall.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtFaFall_UserModifiedFld);
            // 
            // qryFaLeistung
            // 
            this.qryFaLeistung.SelectStatement = resources.GetString("qryFaLeistung.SelectStatement");
            this.qryFaLeistung.AfterFill += new System.EventHandler(this.qryFaLeistung_AfterFill);
            // 
            // qryFaFallPerson
            // 
            this.qryFaFallPerson.SelectStatement = "SELECT PRS.BaPersonID, PRS.NameVorname\r\nFROM FaFallPerson      FAP\r\n  INNER JOIN " +
                "vwPerson  PRS ON PRS.BaPersonID = FAP.BaPersonID\r\nWHERE FAP.FaFallID = {0}\r\nUNIO" +
                "N ALL\r\nSELECT NULL, \'\'\r\nORDER BY 2";
            this.qryFaFallPerson.AfterFill += new System.EventHandler(this.qryFaFallPerson_AfterFill);
            // 
            // edtFaFallIdDropDown
            // 
            this.edtFaFallIdDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFaFallIdDropDown.Location = new System.Drawing.Point(114, 0);
            this.edtFaFallIdDropDown.Name = "edtFaFallIdDropDown";
            this.edtFaFallIdDropDown.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaFallIdDropDown.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaFallIdDropDown.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaFallIdDropDown.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaFallIdDropDown.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaFallIdDropDown.Properties.Appearance.Options.UseFont = true;
            this.edtFaFallIdDropDown.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFaFallIdDropDown.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaFallIdDropDown.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFaFallIdDropDown.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFaFallIdDropDown.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtFaFallIdDropDown.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtFaFallIdDropDown.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaFallIdDropDown.Properties.NullText = "";
            this.edtFaFallIdDropDown.Properties.ShowFooter = false;
            this.edtFaFallIdDropDown.Properties.ShowHeader = false;
            this.edtFaFallIdDropDown.Size = new System.Drawing.Size(244, 24);
            this.edtFaFallIdDropDown.TabIndex = 20;
            this.edtFaFallIdDropDown.EditValueChanged += new System.EventHandler(this.edtFaFallIdDropDown_EditValueChanged);
            // 
            // qryFaFalltraeger
            // 
            this.qryFaFalltraeger.SelectStatement = resources.GetString("qryFaFalltraeger.SelectStatement");
            this.qryFaFalltraeger.AfterFill += new System.EventHandler(this.qryFaFalltraeger_AfterFill);
            // 
            // CtlFallLeistungBetrifftPerson
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.edtFaFall);
            this.Controls.Add(this.edtFaFallIdDropDown);
            this.Controls.Add(this.edtSAR);
            this.Controls.Add(this.lblSAR);
            this.Controls.Add(this.edtFaLeistungID);
            this.Controls.Add(this.lblFaLeistungID);
            this.Controls.Add(this.lblBaPersonID);
            this.Controls.Add(this.lblFaFallID);
            this.Controls.Add(this.edtBaPersonID);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.Name = "CtlFallLeistungBetrifftPerson";
            this.Size = new System.Drawing.Size(358, 114);
            ((System.ComponentModel.ISupportInitialize)(this.edtSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaLeistungID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaLeistungID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaLeistungID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFaFallID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaFall.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaFallPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaFallIdDropDown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaFallIdDropDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaFalltraeger)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private KissLabel lblSAR;
        private KissLabel lblFaLeistungID;
        private KissLabel lblBaPersonID;
        private KissLabel lblFaFallID;
        public KissTextEdit edtSAR;
        public KissLookUpEdit edtFaLeistungID;
        public KissLookUpEdit edtBaPersonID;
        public KissButtonEdit edtFaFall;
        private SqlQuery qryFaLeistung;
        private SqlQuery qryFaFallPerson;
        private SqlQuery qryFaFalltraeger;
        public KissLookUpEdit edtFaFallIdDropDown;
    }
}
