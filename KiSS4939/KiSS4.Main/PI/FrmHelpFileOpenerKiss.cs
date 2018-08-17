using System;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.DB;

namespace KiSS4.Main.PI
{
    public class FrmHelpFileOpenerKiss : KiSS4.Main.PI.FrmHelpFileOpenerBase
    {
        #region Constructors

        public FrmHelpFileOpenerKiss()
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
            this.SuspendLayout();
            //
            // FrmHelpFileOpenerKiss
            //
            this.ClientSize = new System.Drawing.Size(174, 0);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmHelpFileOpenerKiss";
            this.Text = "KiSS Helpfile Opener";
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.FrmHelpFileOpenerKiss_Layout);
            this.ResumeLayout(false);
        }

        #endregion

        #region Private Methods

        private void FrmHelpFileOpenerKiss_Layout(object sender, EventArgs e)
        {
            try
            {
                // hide window again
                this.Visible = false;

                // do it
                ApplicationFacade.DoEvents();

                // multilanguage handling
                if (Session.Active && Session.User != null)
                {
                    // language depending helpfile
                    switch (Session.User.LanguageCode)
                    {
                        case 2:
                            // french
                            HandleOpenHelpFile("Manuel_KiSS4.chm", true);
                            break;

                        default:
                            // german or unhandled
                            HandleOpenHelpFile("Handbuch_Allgemein.chm", true);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                // Show exception due to heavy problem
                KissMsg.ShowError("FrmHelpFileOpenerKiss", "ErrorOpeningHelpFile", "Fehler beim Anzeigen der Hilfedatei.", ex);
            }
            finally
            {
                // close window again
                this.Close();
            }
        }

        #endregion
    }
}