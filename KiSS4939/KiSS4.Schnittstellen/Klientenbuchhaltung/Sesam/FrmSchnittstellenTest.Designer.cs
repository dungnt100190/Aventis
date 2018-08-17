namespace KiSS4.Schnittstellen.Sesam
{
    partial class FrmSchnittstellenTest
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
            this.btnTest = new KiSS4.Gui.KissButton();
            this.btnTransferKreditoren = new KiSS4.Gui.KissButton();
            this.btnBuchen = new KiSS4.Gui.KissButton();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Location = new System.Drawing.Point(12, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(146, 24);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnTransferKreditoren
            // 
            this.btnTransferKreditoren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransferKreditoren.Location = new System.Drawing.Point(12, 42);
            this.btnTransferKreditoren.Name = "btnTransferKreditoren";
            this.btnTransferKreditoren.Size = new System.Drawing.Size(146, 24);
            this.btnTransferKreditoren.TabIndex = 1;
            this.btnTransferKreditoren.Text = "Kreditoren";
            this.btnTransferKreditoren.UseVisualStyleBackColor = false;
            this.btnTransferKreditoren.Click += new System.EventHandler(this.btnTransferKreditoren_Click);
            // 
            // btnBuchen
            // 
            this.btnBuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuchen.Location = new System.Drawing.Point(12, 72);
            this.btnBuchen.Name = "btnBuchen";
            this.btnBuchen.Size = new System.Drawing.Size(146, 24);
            this.btnBuchen.TabIndex = 2;
            this.btnBuchen.Text = "Buchung erstellen";
            this.btnBuchen.UseVisualStyleBackColor = false;
            this.btnBuchen.Click += new System.EventHandler(this.btnBuchen_Click);
            // 
            // FrmSchnittstellenTest
            // 
            this.ClientSize = new System.Drawing.Size(407, 203);
            this.Controls.Add(this.btnBuchen);
            this.Controls.Add(this.btnTransferKreditoren);
            this.Controls.Add(this.btnTest);
            this.Name = "FrmSchnittstellenTest";
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnTest;
        private KiSS4.Gui.KissButton btnTransferKreditoren;
        private KiSS4.Gui.KissButton btnBuchen;
    }
}
