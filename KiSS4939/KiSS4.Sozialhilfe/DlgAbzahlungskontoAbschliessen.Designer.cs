namespace KiSS4.Sozialhilfe
{
    partial class DlgAbzahlungskontoAbschliessen
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
            this.btnUebergabeAnInkasso = new KiSS4.Gui.KissButton();
            this.btnKontoNichtAusgleichen = new KiSS4.Gui.KissButton();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUebergabeAnInkasso
            // 
            this.btnUebergabeAnInkasso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUebergabeAnInkasso.Location = new System.Drawing.Point(208, 39);
            this.btnUebergabeAnInkasso.Name = "btnUebergabeAnInkasso";
            this.btnUebergabeAnInkasso.Size = new System.Drawing.Size(178, 24);
            this.btnUebergabeAnInkasso.TabIndex = 0;
            this.btnUebergabeAnInkasso.Text = "Übergabe an Inkasso";
            this.btnUebergabeAnInkasso.UseVisualStyleBackColor = false;
            this.btnUebergabeAnInkasso.Click += new System.EventHandler(this.btnUebergabeAnInkasso_Click);
            // 
            // btnKontoNichtAusgleichen
            // 
            this.btnKontoNichtAusgleichen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKontoNichtAusgleichen.Location = new System.Drawing.Point(12, 39);
            this.btnKontoNichtAusgleichen.Name = "btnKontoNichtAusgleichen";
            this.btnKontoNichtAusgleichen.Size = new System.Drawing.Size(178, 24);
            this.btnKontoNichtAusgleichen.TabIndex = 1;
            this.btnKontoNichtAusgleichen.Text = "Konto nicht ausgleichen";
            this.btnKontoNichtAusgleichen.UseVisualStyleBackColor = false;
            this.btnKontoNichtAusgleichen.Click += new System.EventHandler(this.btnKontoNichtAusgleichen_Click);
            // 
            // lblBetrag
            // 
            this.lblBetrag.Location = new System.Drawing.Point(205, 9);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(74, 24);
            this.lblBetrag.TabIndex = 3;
            this.lblBetrag.Text = "Betrag";
            // 
            // edtBetrag
            // 
            this.edtBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetrag.Location = new System.Drawing.Point(285, 9);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.ReadOnly = true;
            this.edtBetrag.Size = new System.Drawing.Size(101, 24);
            this.edtBetrag.TabIndex = 5;
            // 
            // DlgAbzahlungskontoAbschliessen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 75);
            this.Controls.Add(this.edtBetrag);
            this.Controls.Add(this.lblBetrag);
            this.Controls.Add(this.btnKontoNichtAusgleichen);
            this.Controls.Add(this.btnUebergabeAnInkasso);
            this.Name = "DlgAbzahlungskontoAbschliessen";
            this.Text = "Abzahlungskonto abschliessen";
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissButton btnUebergabeAnInkasso;
        private Gui.KissButton btnKontoNichtAusgleichen;
        private Gui.KissLabel lblBetrag;
        private Gui.KissCalcEdit edtBetrag;
    }
}