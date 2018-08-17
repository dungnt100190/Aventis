namespace KiSS4.Sozialhilfe.ZH
{
    partial class DlgBewilligungAnfragen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.lblTitle = new KiSS4.Gui.KissLabel();
            this.edtUserID_An = new KiSS4.Gui.KissButtonEdit();
            this.qryBgBewilligung = new KiSS4.DB.SqlQuery(this.components);
            this.lblMitteilung = new KiSS4.Gui.KissLabel();
            this.edtMessage = new KiSS4.Gui.KissMemoEdit();
            this.btnAnfragen = new KiSS4.Gui.KissButton();
            this.btnAbbrechen = new KiSS4.Gui.KissButton();
            this.lblUserHatUngenuegendeKompetenz = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID_An.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBewilligung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserHatUngenuegendeKompetenz)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitle.Location = new System.Drawing.Point(12, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 16);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Bewilligung anfragen";
            this.lblTitle.UseCompatibleTextRendering = true;
            // 
            // edtUserID_An
            // 
            this.edtUserID_An.DataSource = this.qryBgBewilligung;
            this.edtUserID_An.Location = new System.Drawing.Point(12, 80);
            this.edtUserID_An.Name = "edtUserID_An";
            this.edtUserID_An.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID_An.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID_An.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID_An.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID_An.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID_An.Properties.Appearance.Options.UseFont = true;
            this.edtUserID_An.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtUserID_An.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtUserID_An.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID_An.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUserID_An.Size = new System.Drawing.Size(424, 24);
            this.edtUserID_An.TabIndex = 11;
            this.edtUserID_An.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_An_UserModifiedFld);
            // 
            // qryBgBewilligung
            // 
            this.qryBgBewilligung.CanUpdate = true;
            this.qryBgBewilligung.HostControl = this;
            this.qryBgBewilligung.SelectStatement = "SELECT * \r\nFROM BgBewilligung";
            this.qryBgBewilligung.TableName = "BgBewilligung";
            this.qryBgBewilligung.BeforePost += new System.EventHandler(this.qryBgBewilligung_BeforePost);
            // 
            // lblMitteilung
            // 
            this.lblMitteilung.Location = new System.Drawing.Point(12, 107);
            this.lblMitteilung.Name = "lblMitteilung";
            this.lblMitteilung.Size = new System.Drawing.Size(100, 23);
            this.lblMitteilung.TabIndex = 12;
            this.lblMitteilung.Text = "Beschreibung";
            this.lblMitteilung.UseCompatibleTextRendering = true;
            // 
            // edtMessage
            // 
            this.edtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMessage.DataMember = "Bemerkung";
            this.edtMessage.DataSource = this.qryBgBewilligung;
            this.edtMessage.Location = new System.Drawing.Point(12, 133);
            this.edtMessage.Name = "edtMessage";
            this.edtMessage.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMessage.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMessage.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMessage.Properties.Appearance.Options.UseBackColor = true;
            this.edtMessage.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMessage.Properties.Appearance.Options.UseFont = true;
            this.edtMessage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMessage.Size = new System.Drawing.Size(632, 123);
            this.edtMessage.TabIndex = 13;
            // 
            // btnAnfragen
            // 
            this.btnAnfragen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnfragen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnfragen.Location = new System.Drawing.Point(458, 262);
            this.btnAnfragen.Name = "btnAnfragen";
            this.btnAnfragen.Size = new System.Drawing.Size(90, 24);
            this.btnAnfragen.TabIndex = 15;
            this.btnAnfragen.Text = "Anfragen";
            this.btnAnfragen.UseCompatibleTextRendering = true;
            this.btnAnfragen.UseVisualStyleBackColor = true;
            this.btnAnfragen.Click += new System.EventHandler(this.btnAnfragen_Click);
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(554, 262);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(90, 24);
            this.btnAbbrechen.TabIndex = 14;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseCompatibleTextRendering = true;
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // lblUserHatUngenuegendeKompetenz
            // 
            this.lblUserHatUngenuegendeKompetenz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserHatUngenuegendeKompetenz.ForeColor = System.Drawing.Color.Red;
            this.lblUserHatUngenuegendeKompetenz.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUserHatUngenuegendeKompetenz.Location = new System.Drawing.Point(12, 262);
            this.lblUserHatUngenuegendeKompetenz.Name = "lblUserHatUngenuegendeKompetenz";
            this.lblUserHatUngenuegendeKompetenz.Size = new System.Drawing.Size(424, 24);
            this.lblUserHatUngenuegendeKompetenz.TabIndex = 16;
            this.lblUserHatUngenuegendeKompetenz.Text = "Der ausgewählte Mitarbeiter hat ungenügende Kompetenzen.";
            this.lblUserHatUngenuegendeKompetenz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUserHatUngenuegendeKompetenz.UseCompatibleTextRendering = true;
            this.lblUserHatUngenuegendeKompetenz.Visible = false;
            // 
            // DlgBewilligungAnfragen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAbbrechen;
            this.ClientSize = new System.Drawing.Size(656, 298);
            this.Controls.Add(this.btnAnfragen);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.edtMessage);
            this.Controls.Add(this.lblMitteilung);
            this.Controls.Add(this.lblUserHatUngenuegendeKompetenz);
            this.Controls.Add(this.edtUserID_An);
            this.Controls.Add(this.lblTitle);
            this.Name = "DlgBewilligungAnfragen";
            this.Text = "Bewilligung anfragen";
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID_An.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBewilligung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserHatUngenuegendeKompetenz)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissLabel lblTitle;
        private Gui.KissButtonEdit edtUserID_An;
        private Gui.KissLabel lblMitteilung;
        private Gui.KissMemoEdit edtMessage;
        private Gui.KissButton btnAnfragen;
        private Gui.KissButton btnAbbrechen;
        private DB.SqlQuery qryBgBewilligung;
        private Gui.KissLabel lblUserHatUngenuegendeKompetenz;
    }
}
