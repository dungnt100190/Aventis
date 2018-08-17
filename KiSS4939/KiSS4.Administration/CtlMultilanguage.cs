using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Administration
{
    /// <summary>
    /// Summary description for FrmQueryManagement.
    /// </summary>
    public class CtlMultilanguage : KissNavBarUserControl
    {
        #region Fields

        #region Private Fields

        private System.ComponentModel.IContainer components = null;
        private KissNavBarItem itmMsgError = new KissNavBarItem("Fehler", 80, typeof(CtlMessage), new object[] { KissMsgCode.MsgError });
        private KissNavBarItem itmMsgInfo = new KissNavBarItem("Info", 81, typeof(CtlMessage), new object[] { KissMsgCode.MsgInfo });
        private KissNavBarItem itmMsgQuestion = new KissNavBarItem("Frage", 82, typeof(CtlMessage), new object[] { KissMsgCode.MsgQuestion });
        private KissNavBarItem itmMsgText = new KissNavBarItem("Text", 169, typeof(CtlMessage), new object[] { KissMsgCode.Text });

        #endregion

        #endregion

        #region Constructors

        public CtlMultilanguage()
        {
            //
            // Required for Windows Form Designer support
            //
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
            this.navBar.Size = new System.Drawing.Size(184, 539);
            //
            // splitterNavControl
            //
            this.splitterNavControl.Location = new System.Drawing.Point(184, 0);
            this.splitterNavControl.Size = new System.Drawing.Size(3, 539);
            //
            // panTitle
            //
            this.panTitle.Location = new System.Drawing.Point(187, 0);
            this.panTitle.Size = new System.Drawing.Size(845, 27);
            //
            // panDetail
            //
            this.panDetail.Location = new System.Drawing.Point(187, 27);
            this.panDetail.Size = new System.Drawing.Size(845, 512);
            //
            // CtlMultilanguage
            //
            this.ClientSize = new System.Drawing.Size(1032, 539);
            this.Name = "CtlMultilanguage";
            this.HandleDestroyed += new System.EventHandler(CtlMultilanguage_HandleDestroyed);
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).EndInit();
            this.panTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.ResumeLayout(false);
        }


        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        void CtlMultilanguage_HandleDestroyed(object sender, System.EventArgs e)
        {
            // clear multilanguage cache when closing this form to have new values again in cache
            Session.CacheManager.ClearLanguageCache();
        }

        #endregion
    }
}