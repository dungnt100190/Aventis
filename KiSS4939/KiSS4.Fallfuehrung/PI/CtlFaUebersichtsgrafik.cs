
namespace KiSS4.Fallfuehrung.PI
{
    public class CtlFaUebersichtsgrafik : KiSS4.Gui.KissUserControl
    {
        #region Fields

        private KiSS4.Gui.KissLabel lblNotWorkingYet;

        #endregion

        #region Constructors

        public CtlFaUebersichtsgrafik()
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
            this.lblNotWorkingYet = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblNotWorkingYet)).BeginInit();
            this.SuspendLayout();
            //
            // lblNotWorkingYet
            //
            this.lblNotWorkingYet.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblNotWorkingYet.Location = new System.Drawing.Point(9, 9);
            this.lblNotWorkingYet.Name = "lblNotWorkingYet";
            this.lblNotWorkingYet.Size = new System.Drawing.Size(482, 16);
            this.lblNotWorkingYet.TabIndex = 2;
            this.lblNotWorkingYet.Text = "Diese Funktionalität steht zurzeit noch nicht zur Verfügung!";
            this.lblNotWorkingYet.UseCompatibleTextRendering = true;
            //
            // CtlFaUebersichtsgrafik
            //
            this.Controls.Add(this.lblNotWorkingYet);
            this.Name = "CtlFaUebersichtsgrafik";
            this.Size = new System.Drawing.Size(490, 60);
            ((System.ComponentModel.ISupportInitialize)(this.lblNotWorkingYet)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Public Methods


        public void Init()
        {
        }

        #endregion
    }
}