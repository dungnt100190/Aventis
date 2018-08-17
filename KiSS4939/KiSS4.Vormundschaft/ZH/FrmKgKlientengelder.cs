using KiSS4.Common;
using KiSS4.Gui;

using DevExpress.XtraNavBar;

namespace KiSS4.Vormundschaft.ZH
{
    public class FrmKgKlientengelder : KissNavBarForm
    {
        #region Constructors

        public FrmKgKlientengelder()
        {
            InitializeComponent();
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
            this.navBar.Size = new System.Drawing.Size(170, 694);
            //
            // splitterNavControl
            //
            this.splitterNavControl.Size = new System.Drawing.Size(3, 694);
            //
            // panTitle
            //
            this.panTitle.Size = new System.Drawing.Size(781, 31);
            this.panTitle.Visible = false;
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
            this.panDetail.Size = new System.Drawing.Size(781, 663);
            //
            // FrmKgKlientengelder
            //
            this.ClientSize = new System.Drawing.Size(954, 694);
            this.Name = "FrmKgKlientengelder";
            this.Text = "Verwaltung Klientengelder";
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
                case "JumpToNode":
                    string nodeName = (string)param["NodeName"];
                    string className = (string)param["ClassName"];

                    foreach (KissNavBarItem item in navBar.Items)
                    {
                        if (item.Type.Name == className)
                        {
                            ShowSubMask(item.Links[0]);
                            FormController.SendMessage((KissUserControl)panDetail.Controls[0], param);
                            return true;
                        }
                    }

                    foreach (NavBarGroup group in navBar.Groups)
                    {
                        foreach (NavBarItemLink itemLink in group.ItemLinks)
                        {
                            if (itemLink.Caption.Equals(nodeName))
                            {
                                ShowSubMask(itemLink);
                                FormController.SendMessage((KissUserControl)panDetail.Controls[0], param);
                                return true;
                            }
                        }
                    }
                    break;
            }

            // did not understand message
            return base.ReceiveMessage(param);
        }

        #endregion

        #endregion
    }
}