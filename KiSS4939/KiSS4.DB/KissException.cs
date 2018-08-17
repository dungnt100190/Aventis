using System.Windows.Forms;

namespace KiSS4.DB
{
    /// <summary>
    /// Throw this Exception in SqlQuery Eventhandler Before-/After- Insert/Post/Delete to cancel without dispay a Message
    /// </summary>
    public class KissCancelException : System.Exception
    {
        /// <summary>
        /// Initialize.
        /// </summary>
        public KissCancelException() { }

        /// <summary>
        /// Initialize.
        /// </summary>
        public KissCancelException(Control ctlFocus)
        {
            this.ctlFocus = ctlFocus;
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        public KissCancelException(string message) : base(message) { }

        /// <summary>
        /// Initialize.
        /// </summary>
        public KissCancelException(string message, Control ctlFocus) : base(message)
        {
            this.ctlFocus = ctlFocus;
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        public KissCancelException(string message, System.Exception ex) : base(message, ex) { }

        /// <summary>
        /// Initialize.
        /// </summary>
        public KissCancelException(string message, System.Exception ex, Control ctlFocus)
            : base(message, ex)
        {
            this.ctlFocus = ctlFocus;
        }

        /// <summary>
        /// Gets the Control to set Focus.
        /// </summary>
        public readonly Control ctlFocus;

        /// <summary>
        /// Show Message
        /// </summary>
        public virtual void ShowMessage()
        {
			if (this.ctlFocus != null)
			{
				SelectTabPage(ctlFocus.Parent as Control);
				ctlFocus.Focus();
			}
        }

		private void SelectTabPage(Control ctl)
		{
			if (ctl == null)
			{
				return;
			}

			SharpLibrary.WinControls.TabPageEx tpg = ctl as SharpLibrary.WinControls.TabPageEx;
			if (tpg != null)
			{
				SharpLibrary.WinControls.TabControlEx tab = tpg.Parent as SharpLibrary.WinControls.TabControlEx;
				if (tab != null && tab.TabPages.Count > 0)
				{
					tab.SelectedTabIndex = tab.TabPages.IndexOf(tpg);
				}
			}

			SelectTabPage(ctl.Parent);
		}
    }


    /// <summary>
    /// Throw this Exception in SqlQuery Eventhandler Before-/After- Insert/Post/Delete to display a Infomessage
    /// </summary>
    public class KissInfoException : KissCancelException
    {
        /// <summary>
        /// Initialize.
        /// </summary>
        public KissInfoException(string message) : base(message) { }

        /// <summary>
        /// Initialize.
        /// </summary>
        public KissInfoException(string message, Control ctlFocus) : base(message, ctlFocus) { }

        /// <summary>
        /// Initialize.
        /// </summary>
        public KissInfoException(string message, System.Exception ex) : base(message, ex) { }

        /// <summary>
        /// Initialize.
        /// </summary>
        public KissInfoException(string message, System.Exception ex, Control ctlFocus) : base(message, ex, ctlFocus) { }

        /// <summary>
        /// Show Message
        /// </summary>
        public override void ShowMessage()
        {
            //			DlgInfo.Show(this.Message);
            KissMsg.ShowInfo(this.Message);
            base.ShowMessage();
        }
    }

    /// <summary>
    /// Throw this Exception in SqlQuery Eventhandler Before-/After- Insert/Post/Delete to display a Errormessage
    /// </summary>
    public class KissErrorException : KissCancelException
    {
        /// <summary>
        /// Initialize.
        /// </summary>
        public KissErrorException(string message) : base(message) { }

        /// <summary>
        /// Initialize.
        /// </summary>
        public KissErrorException(string message, Control ctlFocus) : base(message, ctlFocus) { }

        /// <summary>
        /// Initialize.
        /// </summary>
        public KissErrorException(string message, System.Exception ex) : base(message, ex) { }

        /// <summary>
        /// Initialize.
        /// </summary>
        public KissErrorException(string message, System.Exception ex, Control ctlFocus) : base(message, ex, ctlFocus) { }

        /// <summary>
        /// Initialize.
        /// </summary>
        public KissErrorException(string message, string TechnicalText, System.Exception ex) : base(message, ex)
        {
            this.TechnicalText = TechnicalText;
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        public KissErrorException(string message, string TechnicalText, System.Exception ex, Control ctlFocus) : base(message, ex, ctlFocus)
        {
            this.TechnicalText = TechnicalText;
        }

        /// <summary>
        /// Gets the technical text.
        /// </summary>
        public readonly string TechnicalText;

        /// <summary>
        /// Show Message
        /// </summary>
        public override void ShowMessage()
        {
            KissMsg.ShowError(null, null, this.Message, this.TechnicalText, this.InnerException);
            base.ShowMessage();
        }
    }
}
