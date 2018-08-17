using KiSS4.Common;
using KiSS4.Gui;

namespace KiSS4.Administration
{
    public class CtlModulConfig : KissNavBarUserControl
    {
        #region Fields

        #region Private Fields

        private KissNavBarItem itmAyBgColors = new KissNavBarItem("AY Budget Farben", 177, typeof(CtlBgColors), new object[] { ModulID.A });
        private KissNavBarItem itmAyBgPositionTyp = new KissNavBarItem("AY Budget Positionsarten", 198, typeof(CtlBgPositionsart), new object[] { ModulID.A });
        private KissNavBarItem itmAyKostenart = new KissNavBarItem("AY Kostenarten", 191, typeof(CtlKostenart), new object[] { ModulID.A });
        private KissNavBarItem itmAyStandardZahlungsmodi = new KissNavBarItem("AY Standardzahlungsmodi", 192, typeof(CtlStdZahlungsmodi), new object[] { ModulID.A });
        private KissNavBarItem itmShBgColors = new KissNavBarItem("SH Budget Farben", 177, typeof(CtlBgColors), new object[] { ModulID.S });
        private KissNavBarItem itmShBgPositionTyp = new KissNavBarItem("SH Budget Positionsarten", 198, typeof(CtlBgPositionsart), new object[] { ModulID.S });
        private KissNavBarItem itmShKostenart = new KissNavBarItem("SH Kostenarten", 191, typeof(CtlKostenart), new object[] { ModulID.S });
        private KissNavBarItem itmShStandardZahlungsmodi = new KissNavBarItem("SH Standardzahlungsmodi", 192, typeof(CtlStdZahlungsmodi), new object[] { ModulID.S });

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlModulConfig"/> class.
        /// </summary>
        public CtlModulConfig()
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
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).BeginInit();
            this.panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.SuspendLayout();
            //
            // navBar
            //
            this.navBar.Appearance.Background.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.navBar.Appearance.Background.Options.UseBackColor = true;
            this.navBar.Appearance.GroupBackground.BackColor = System.Drawing.Color.Lavender;
            this.navBar.Appearance.GroupBackground.Options.UseBackColor = true;
            this.navBar.Appearance.GroupHeaderActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.navBar.Appearance.GroupHeaderActive.Options.UseFont = true;
            this.navBar.Appearance.GroupHeaderActive.Options.UseTextOptions = true;
            this.navBar.Appearance.GroupHeaderActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.navBar.Appearance.GroupHeaderHotTracked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.navBar.Appearance.GroupHeaderHotTracked.Options.UseFont = true;
            this.navBar.Appearance.GroupHeaderHotTracked.Options.UseTextOptions = true;
            this.navBar.Appearance.GroupHeaderHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.navBar.Appearance.GroupHeaderPressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.navBar.Appearance.GroupHeaderPressed.Options.UseFont = true;
            this.navBar.Appearance.ItemDisabled.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.Appearance.ItemHotTracked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);
            this.navBar.Appearance.ItemHotTracked.Options.UseFont = true;
            this.navBar.Appearance.ItemHotTracked.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemHotTracked.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.Appearance.ItemPressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);
            this.navBar.Appearance.ItemPressed.Options.UseFont = true;
            this.navBar.Appearance.ItemPressed.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemPressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemPressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.Size = new System.Drawing.Size(170, 486);
            //
            // splitterNavControl
            //
            this.splitterNavControl.Size = new System.Drawing.Size(3, 486);
            //
            // panTitle
            //
            this.panTitle.Size = new System.Drawing.Size(627, 31);
            //
            // picTitle
            //
            this.picTitle.Size = new System.Drawing.Size(24, 26);
            //
            // lblTitle
            //
            this.lblTitle.Size = new System.Drawing.Size(524, 27);
            //
            // panDetail
            //
            this.panDetail.Location = new System.Drawing.Point(173, 31);
            this.panDetail.Size = new System.Drawing.Size(627, 455);
            //
            // CtlModulConfig
            //
            this.ClientSize = new System.Drawing.Size(800, 486);
            this.Name = "CtlModulConfig";
            this.Text = "Modul Konfiguration";
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).EndInit();
            this.panTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}