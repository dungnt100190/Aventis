
namespace KiSS4.Fallfuehrung.PI
{
    public class CtlFaDokumentation : KiSS4.Gui.KissUserControl
    {
        #region Fields

        private KiSS4.Gui.KissLabel lblInfo;

        #endregion

        #region Constructors

        public CtlFaDokumentation()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInfo = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo)).BeginInit();
            this.SuspendLayout();
            //
            // lblInfo
            //
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblInfo.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblInfo.Location = new System.Drawing.Point(3, 15);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(398, 24);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Empty control, used for Dokumentation-Node in AKV";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInfo.UseCompatibleTextRendering = true;
            this.lblInfo.Visible = false;
            //
            // CtlFaDokumentation
            //
            this.Controls.Add(this.lblInfo);
            this.Name = "CtlFaDokumentation";
            this.Size = new System.Drawing.Size(404, 164);
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}