using System;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Schnittstellen.Newod.Service;

namespace KiSS4.Schnittstellen.Newod
{
    public partial class CtlKiSSNewodManuellerImport : Gui.KissUserControl
    {
        #region Constructors

        public CtlKiSSNewodManuellerImport()
        {
            InitializeComponent();
            edtFeedback.Clear();
        }

        #endregion

        #region EventHandlers

        private void edtStart_Click(object sender, EventArgs e)
        {
            var svcBaPerson = new BaPersonService();
            edtFeedback.Clear();
            Cursor.Current = Cursors.WaitCursor;
            edtStart.Enabled = false;
            svcBaPerson.StartKomplettImport(AddStatusMessage);
            Cursor.Current = Cursors.Default;
            edtStart.Enabled = true;
        }

        #endregion

        #region Methods

        #region Private Methods

        private void AddStatusMessage(string message)
        {
            edtFeedback.AppendText(string.Format("{0}: {1}", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), message));
            edtFeedback.AppendText(Environment.NewLine);
            ApplicationFacade.DoEvents();
        }

        #endregion

        #endregion
    }
}