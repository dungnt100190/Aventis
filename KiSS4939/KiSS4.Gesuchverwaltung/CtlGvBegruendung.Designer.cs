namespace KiSS4.Gesuchverwaltung
{
    partial class CtlGvBegruendung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlGvBegruendung));
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.edtBegruendung = new KiSS4.Gui.KissRTFEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(2, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(175, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Begründung Gesuch";
            // 
            // edtBegruendung
            // 
            this.edtBegruendung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBegruendung.BackColor = System.Drawing.Color.White;
            this.edtBegruendung.EditValue = ((object)(resources.GetObject("edtBegruendung.EditValue")));
            this.edtBegruendung.Font = new System.Drawing.Font("Arial", 10F);
            this.edtBegruendung.Location = new System.Drawing.Point(3, 24);
            this.edtBegruendung.Name = "edtBegruendung";
            this.edtBegruendung.Size = new System.Drawing.Size(539, 350);
            this.edtBegruendung.TabIndex = 1;
            // 
            // CtlGvBegruendung
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.edtBegruendung);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlGvBegruendung";
            this.Size = new System.Drawing.Size(545, 377);
            this.Load += new System.EventHandler(this.CtlGvBegruendung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissLabel lblTitel;
        private Gui.KissRTFEdit edtBegruendung;
    }
}
