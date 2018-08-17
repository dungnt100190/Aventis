namespace KiSS4.Main
{
	partial class DlgErfassungPerson
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblBaRelationID = new KiSS4.Gui.KissLabel();
            this.edtBaRelationID = new KiSS4.Gui.KissLookUpEdit();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnNeuePerson = new KiSS4.Gui.KissButton();
            this.btnAbbrechen = new KiSS4.Gui.KissButton();
            this.pnlFill = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaRelationID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaRelationID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaRelationID.Properties)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBaRelationID
            // 
            this.lblBaRelationID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBaRelationID.Location = new System.Drawing.Point(493, 9);
            this.lblBaRelationID.Name = "lblBaRelationID";
            this.lblBaRelationID.Size = new System.Drawing.Size(148, 24);
            this.lblBaRelationID.TabIndex = 2;
            this.lblBaRelationID.Text = "Beziehung zu Fallträger/-in";
            this.lblBaRelationID.UseCompatibleTextRendering = true;
            // 
            // edtBaRelationID
            // 
            this.edtBaRelationID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBaRelationID.Location = new System.Drawing.Point(647, 9);
            this.edtBaRelationID.LOVName = "BaLand";
            this.edtBaRelationID.Name = "edtBaRelationID";
            this.edtBaRelationID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaRelationID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaRelationID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaRelationID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaRelationID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaRelationID.Properties.Appearance.Options.UseFont = true;
            this.edtBaRelationID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaRelationID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaRelationID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaRelationID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaRelationID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBaRelationID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBaRelationID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaRelationID.Properties.NullText = "";
            this.edtBaRelationID.Properties.ShowFooter = false;
            this.edtBaRelationID.Properties.ShowHeader = false;
            this.edtBaRelationID.Size = new System.Drawing.Size(270, 24);
            this.edtBaRelationID.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnNeuePerson);
            this.pnlBottom.Controls.Add(this.btnAbbrechen);
            this.pnlBottom.Controls.Add(this.edtBaRelationID);
            this.pnlBottom.Controls.Add(this.lblBaRelationID);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 528);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(929, 75);
            this.pnlBottom.TabIndex = 4;
            // 
            // btnNeuePerson
            // 
            this.btnNeuePerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNeuePerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeuePerson.Location = new System.Drawing.Point(731, 39);
            this.btnNeuePerson.Name = "btnNeuePerson";
            this.btnNeuePerson.Size = new System.Drawing.Size(90, 24);
            this.btnNeuePerson.TabIndex = 10;
            this.btnNeuePerson.Text = "neue Person";
            this.btnNeuePerson.UseCompatibleTextRendering = true;
            this.btnNeuePerson.UseVisualStyleBackColor = false;
            this.btnNeuePerson.Click += new System.EventHandler(this.btnNeuePerson_Click);
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(827, 39);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(90, 24);
            this.btnAbbrechen.TabIndex = 9;
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
            this.pnlFill.TabIndex = 5;
            // 
            // DlgErfassungPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 603);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Name = "DlgErfassungPerson";
            this.Text = "Person suchen";
            this.Load += new System.EventHandler(this.DlgErfassungPerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblBaRelationID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaRelationID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaRelationID)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private KiSS4.Gui.KissLabel lblBaRelationID;
		private KiSS4.Gui.KissLookUpEdit edtBaRelationID;
		private System.Windows.Forms.Panel pnlBottom;
		private System.Windows.Forms.Panel pnlFill;
        private KiSS4.Gui.KissButton btnNeuePerson;
        private KiSS4.Gui.KissButton btnAbbrechen;
	}
}