namespace KiSS4.Main
{
    partial class DlgNeuerFall
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblZustGemeinde = new KiSS4.Gui.KissLabel();
            this.editSAR = new KiSS4.Gui.KissButtonEdit();
            this.editGemeinde = new KiSS4.Gui.KissLookUpEdit();
            this.label22 = new KiSS4.Gui.KissLabel();
            this.btnNeuerFall = new KiSS4.Gui.KissButton();
            this.btnAbbrechen = new KiSS4.Gui.KissButton();
            this.pnlFill = new System.Windows.Forms.Panel();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery(this.components);
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSAR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editGemeinde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblZustGemeinde);
            this.pnlBottom.Controls.Add(this.editSAR);
            this.pnlBottom.Controls.Add(this.editGemeinde);
            this.pnlBottom.Controls.Add(this.label22);
            this.pnlBottom.Controls.Add(this.btnNeuerFall);
            this.pnlBottom.Controls.Add(this.btnAbbrechen);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 528);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(929, 75);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblZustGemeinde
            // 
            this.lblZustGemeinde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZustGemeinde.Location = new System.Drawing.Point(589, 9);
            this.lblZustGemeinde.Name = "lblZustGemeinde";
            this.lblZustGemeinde.Size = new System.Drawing.Size(121, 24);
            this.lblZustGemeinde.TabIndex = 2;
            this.lblZustGemeinde.Text = "zuständige Gemeinde";
            this.lblZustGemeinde.UseCompatibleTextRendering = true;
            // 
            // editSAR
            // 
            this.editSAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editSAR.Location = new System.Drawing.Point(223, 9);
            this.editSAR.Name = "editSAR";
            this.editSAR.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editSAR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editSAR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editSAR.Properties.Appearance.Options.UseBackColor = true;
            this.editSAR.Properties.Appearance.Options.UseBorderColor = true;
            this.editSAR.Properties.Appearance.Options.UseFont = true;
            this.editSAR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.editSAR.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.editSAR.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editSAR.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editSAR.Size = new System.Drawing.Size(256, 24);
            this.editSAR.TabIndex = 1;
            this.editSAR.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editSAR_UserModifiedFld);
            // 
            // editGemeinde
            // 
            this.editGemeinde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editGemeinde.Location = new System.Drawing.Point(716, 9);
            this.editGemeinde.LOVName = "GemeindeSozialdienst";
            this.editGemeinde.Name = "editGemeinde";
            this.editGemeinde.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editGemeinde.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editGemeinde.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editGemeinde.Properties.Appearance.Options.UseBackColor = true;
            this.editGemeinde.Properties.Appearance.Options.UseBorderColor = true;
            this.editGemeinde.Properties.Appearance.Options.UseFont = true;
            this.editGemeinde.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editGemeinde.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editGemeinde.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editGemeinde.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editGemeinde.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.editGemeinde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.editGemeinde.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editGemeinde.Properties.NullText = "";
            this.editGemeinde.Properties.ShowFooter = false;
            this.editGemeinde.Properties.ShowHeader = false;
            this.editGemeinde.Size = new System.Drawing.Size(201, 24);
            this.editGemeinde.TabIndex = 3;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.Location = new System.Drawing.Point(12, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(205, 24);
            this.label22.TabIndex = 0;
            this.label22.Text = "SAR Fallführung";
            this.label22.UseCompatibleTextRendering = true;
            // 
            // btnNeuerFall
            // 
            this.btnNeuerFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNeuerFall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeuerFall.Location = new System.Drawing.Point(731, 39);
            this.btnNeuerFall.Name = "btnNeuerFall";
            this.btnNeuerFall.Size = new System.Drawing.Size(90, 24);
            this.btnNeuerFall.TabIndex = 4;
            this.btnNeuerFall.Text = "neuer Fall";
            this.btnNeuerFall.UseCompatibleTextRendering = true;
            this.btnNeuerFall.UseVisualStyleBackColor = false;
            this.btnNeuerFall.Click += new System.EventHandler(this.btnNeuerFall_Click);
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(827, 39);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(90, 24);
            this.btnAbbrechen.TabIndex = 5;
            this.btnAbbrechen.Text = "Abbruch";
            this.btnAbbrechen.UseCompatibleTextRendering = true;
            this.btnAbbrechen.UseVisualStyleBackColor = false;
            // 
            // pnlFill
            // 
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(929, 528);
            this.pnlFill.TabIndex = 0;
            // 
            // qryFaLeistung
            // 
            this.qryFaLeistung.CanInsert = true;
            this.qryFaLeistung.HostControl = this;
            this.qryFaLeistung.TableName = "FaLeistung";
            // 
            // DlgNeuerFall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 603);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "DlgNeuerFall";
            this.Text = "Neuer Fall";
            this.Load += new System.EventHandler(this.DlgNeuerFall_Load);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblZustGemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSAR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editGemeinde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editGemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Panel pnlBottom;
		private System.Windows.Forms.Panel pnlFill;
        private KiSS4.Gui.KissButton btnNeuerFall;
        private KiSS4.Gui.KissButton btnAbbrechen;
        private KiSS4.Gui.KissButtonEdit editSAR;
        private KiSS4.Gui.KissLookUpEdit editGemeinde;
        private KiSS4.Gui.KissLabel label22;
        private KiSS4.DB.SqlQuery qryFaLeistung;
        private KiSS4.Gui.KissLabel lblZustGemeinde;
	}
}