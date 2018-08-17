using System;
using System.Collections;
using System.Windows.Forms;

using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// The dialog to translate a mask to defined languages
    /// </summary>
    public partial class DlgTranslateMask : KissDialog
    {
        #region Constructors

        /// <summary>
        /// Constructor to init dialog
        /// </summary>
        /// <param name="maskname">The maskname to handle</param>
        /// <param name="components">The hashtable with the components to handle</param>
        public DlgTranslateMask(string maskname, Hashtable components)
        {
            InitializeComponent();

            // apply fields
            ctlTranslateMask.Maskname = maskname;
            ctlTranslateMask.Components = components;

            // set title
            Text = String.Format("{0} - {1}", KissMsg.GetMLMessage("DlgTranslateMask", "DialogTitle", "Übersetzung"), maskname);
            btnAutoTranslate.Text = KissMsg.GetMLMessage("DlgTranslateMask", "ButtonAutoTranslate", btnAutoTranslate.Text);
            btnClose.Text = KissMsg.GetMLMessage("DlgTranslateMask", "ButtonClose", btnClose.Text);
        }

        #endregion

        #region EventHandlers

        private void DlgTranslateMask_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // save pending changes
            ctlTranslateMask.Save();
        }

        private void DlgTranslateMask_FormClosed(object sender, FormClosedEventArgs e)
        {
            // release all resources
            CtlTranslateMask.ReleaseResources();

            // clear multilanguage cache
            Session.CacheManager.ClearLanguageCache();
        }

        private void btnAutoTranslate_Click(object sender, EventArgs e)
        {
            // autotranslate to selected language
            ctlTranslateMask.AutoTranslate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // close the dialog
            Close();
        }

        #endregion
    }
}