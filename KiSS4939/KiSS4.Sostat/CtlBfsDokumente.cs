using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Sostat
{
    class CtlBfsDokumente : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissHyperlinkButton btnBFSLeitfaden;
        private KiSS4.Gui.KissLabel lblBFSLeitfaden;

        #endregion

        #endregion

        #region Constructors

        public CtlBfsDokumente()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblBFSLeitfaden = new KiSS4.Gui.KissLabel();
            this.btnBFSLeitfaden = new KiSS4.Gui.KissHyperlinkButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblBFSLeitfaden)).BeginInit();
            this.SuspendLayout();
            //
            // lblBFSLeitfaden
            //
            this.lblBFSLeitfaden.Location = new System.Drawing.Point(129, 54);
            this.lblBFSLeitfaden.Name = "lblBFSLeitfaden";
            this.lblBFSLeitfaden.Size = new System.Drawing.Size(173, 24);
            this.lblBFSLeitfaden.TabIndex = 0;
            this.lblBFSLeitfaden.Text = "Leitfaden für die BFS-Statistik";
            //
            // btnBFSLeitfaden
            //
            this.btnBFSLeitfaden.BackColor = System.Drawing.Color.Bisque;
            this.btnBFSLeitfaden.ButtonStyle = KiSS4.Gui.ButtonStyleType.Custom;
            this.btnBFSLeitfaden.Context = "BFSLeitfaden";
            this.btnBFSLeitfaden.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBFSLeitfaden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBFSLeitfaden.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Pixel);
            this.btnBFSLeitfaden.ForeColor = System.Drawing.Color.Blue;
            this.btnBFSLeitfaden.Location = new System.Drawing.Point(22, 54);
            this.btnBFSLeitfaden.Name = "btnBFSLeitfaden";
            this.btnBFSLeitfaden.Size = new System.Drawing.Size(90, 24);
            this.btnBFSLeitfaden.TabIndex = 1;
            this.btnBFSLeitfaden.Text = "Leitfaden";
            this.btnBFSLeitfaden.URL = null;
            this.btnBFSLeitfaden.UseVisualStyleBackColor = true;
            //
            // CtlBfsDokumente
            //
            this.Controls.Add(this.btnBFSLeitfaden);
            this.Controls.Add(this.lblBFSLeitfaden);
            this.Name = "CtlBfsDokumente";
            this.Size = new System.Drawing.Size(403, 186);
            ((System.ComponentModel.ISupportInitialize)(this.lblBFSLeitfaden)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}