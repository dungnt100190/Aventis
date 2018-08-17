using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Summary description for DlgEzagInfo.
    /// </summary>
    public class DlgEzagInfo
        :
        KiSS4.Gui.KissDialog
    {
        private KiSS4.Gui.KissButton btnOK;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel lblZusammenfassung;
        private KiSS4.Gui.KissMemoEdit memoFehler;
        //private System.ComponentModel.IContainer components;

        public DlgEzagInfo(string Zusammenfassung, string Fehlern)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            BackColor = DBUtil.DefaultMessageDialogBackColor;

            lblZusammenfassung.Text = Zusammenfassung;
            memoFehler.Text = Fehlern;
        }

        /// <summary>
        /// Displays information to the user with an ok button
        /// </summary>
        /// <param name="Zusammenfassung">the question text, preferably with an ? at the end</param>
        /// <param name="Fehlern">The error string.</param>
        public static void Show(string Zusammenfassung, string Fehlern)
        {
            DlgEzagInfo dlg = new DlgEzagInfo(Zusammenfassung, Fehlern);
            dlg.ShowDialog();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //if(components != null)
                //{
                //   components.Dispose();
                //}
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
            this.btnOK = new KiSS4.Gui.KissButton();
            this.memoFehler = new KiSS4.Gui.KissMemoEdit();
            this.lblZusammenfassung = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.memoFehler.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusammenfassung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            this.SuspendLayout();
            //
            // btnOK
            //
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(428, 365);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(116, 24);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            //
            // memoFehler
            //
            this.memoFehler.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.memoFehler.Location = new System.Drawing.Point(6, 160);
            this.memoFehler.Name = "memoFehler";
            this.memoFehler.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.memoFehler.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memoFehler.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memoFehler.Properties.Appearance.Options.UseBackColor = true;
            this.memoFehler.Properties.Appearance.Options.UseBorderColor = true;
            this.memoFehler.Properties.Appearance.Options.UseFont = true;
            this.memoFehler.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memoFehler.Properties.ReadOnly = true;
            this.memoFehler.Size = new System.Drawing.Size(540, 200);
            this.memoFehler.TabIndex = 4;
            //
            // lblZusammenfassung
            //
            this.lblZusammenfassung.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblZusammenfassung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblZusammenfassung.Location = new System.Drawing.Point(4, 32);
            this.lblZusammenfassung.Name = "lblZusammenfassung";
            this.lblZusammenfassung.Size = new System.Drawing.Size(540, 96);
            this.lblZusammenfassung.TabIndex = 5;
            this.lblZusammenfassung.Text = "";
            //
            // kissLabel1
            //
            this.kissLabel1.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel1.Location = new System.Drawing.Point(6, 140);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(100, 16);
            this.kissLabel1.TabIndex = 6;
            this.kissLabel1.Text = "Fehler:";
            //
            // kissLabel2
            //
            this.kissLabel2.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel2.Location = new System.Drawing.Point(6, 5);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(148, 16);
            this.kissLabel2.TabIndex = 7;
            this.kissLabel2.Text = "Zusammenfassung :";
            //
            // DlgEzagInfo
            //
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(550, 392);
            this.Controls.Add(this.kissLabel2);
            this.Controls.Add(this.kissLabel1);
            this.Controls.Add(this.lblZusammenfassung);
            this.Controls.Add(this.memoFehler);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DlgEzagInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EBanking Auftrag Informationen";
            ((System.ComponentModel.ISupportInitialize)(this.memoFehler.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusammenfassung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}