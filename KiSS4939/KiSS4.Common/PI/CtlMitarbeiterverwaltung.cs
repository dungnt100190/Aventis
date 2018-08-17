using KiSS4.Gui;

namespace KiSS4.Common.PI
{
    /// <summary>
    /// Form, used for "Mitarbeiterverwaltung BW/ED"
    /// </summary>
    public class CtlMitarbeiterverwaltung : KissNavBarUserControl
    {
        #region Public Constant/Read-Only Fields

        /// <summary>
        /// Get the action string used for jumping to "Mitarbeiter BW/ED" control
        /// </summary>
        public const string FormControllerAction_JumpToMitarbeiter = "JumpToMitarbeiter";

        /// <summary>
        /// Get the action string used for jumping to "Verfuegbarkeit" control
        /// </summary>
        public const string FormControllerAction_JumpToVerfuegbarkeit = "JumpToVerfuegbarkeit";

        #endregion

        #region Fields

        #region Private Fields

        private KissNavBarItem itmGeplanteEinsaetzeBW = new KissNavBarItem("GeplanteEinsaetzeBW", 1, typeof(CtlQueryGeplanteEinsaetze), new object[] { BaUtils.ModulID.BegleitetesWohnen });
        private KissNavBarItem itmGeplanteEinsaetzeED = new KissNavBarItem("GeplanteEinsaetzeED", 1, typeof(CtlQueryGeplanteEinsaetze), new object[] { BaUtils.ModulID.EntlastungsDienst });

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlMitarbeiterverwaltung"/> class.
        /// </summary>
        public CtlMitarbeiterverwaltung()
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
            this.navBar.Size = new System.Drawing.Size(182, 666);
            //
            // splitterNavControl
            //
            this.splitterNavControl.Location = new System.Drawing.Point(182, 0);
            this.splitterNavControl.Size = new System.Drawing.Size(3, 666);
            //
            // panTitle
            //
            this.panTitle.Location = new System.Drawing.Point(185, 0);
            this.panTitle.Size = new System.Drawing.Size(777, 29);
            //
            // panDetail
            //
            this.panDetail.Location = new System.Drawing.Point(185, 29);
            this.panDetail.Size = new System.Drawing.Size(777, 637);
            //
            // FrmMitarbeiterverwaltung
            //
            this.ClientSize = new System.Drawing.Size(962, 666);
            this.Name = "FrmMitarbeiterverwaltung";
            this.Text = "Mitarbeiterverwaltung BW/ED";
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).EndInit();
            this.panTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Receive and handle messages sent by FormController
        /// </summary>
        /// <param name="param">The parameters containing the message and actions</param>
        /// <returns><c>True</c> if message was handled, otherwise <c>False</c></returns>
        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case FormControllerAction_JumpToMitarbeiter:
                    // show first item (warning: used index=0)
                    this.ShowSubMask(this.navBar.Groups[0].ItemLinks[0]);

                    param["Action"] = "LoadEdMitarbeiter";
                    FormController.SendMessage(DetailControl, param);

                    return true;

                case FormControllerAction_JumpToVerfuegbarkeit:
                    // show second item (warning: used index=1)
                    this.ShowSubMask(this.navBar.Groups[0].ItemLinks[1]);

                    param["Action"] = "LoadEdVerfuegbarkeit";
                    FormController.SendMessage(DetailControl, param);

                    return true;
            }

            // did not understand message
            return false;
        }

        #endregion

        #endregion
    }
}