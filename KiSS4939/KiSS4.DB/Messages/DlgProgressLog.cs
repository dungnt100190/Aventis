using System;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.DB;

namespace KiSS4.Messages
{
    #region Delegates

    /// <summary>
    /// Delegate is used to hook in user defined funtionality.
    /// </summary>
    public delegate void ProgressEventHandler();

    #endregion

    /// <summary>
    /// Summary description for DlgProgressLog.
    /// </summary>
    public partial class DlgProgressLog : Form
    {
        #region Fields

        #region Private Static Fields

        private static readonly string _mlMsgButtonCancel = KissMsg.GetMLMessage("DlgProgressLog", "ButtonCancelCaption", "&Abbruch", KissMsgCode.Text);
        private static readonly string _mlMsgButtonClipboard = KissMsg.GetMLMessage("DlgProgressLog", "ButtonClipboard", "&Zwischenablage", KissMsgCode.Text);
        private static readonly string _mlMsgButtonClose = KissMsg.GetMLMessage("DlgProgressLog", "ButtonCloseCaption", "&Schliessen", KissMsgCode.Text);
        private static readonly string _mlMsgButtonOk = KissMsg.GetMLMessage("DlgProgressLog", "ButtonOkCaption", "&OK", KissMsgCode.Text);

        private static readonly string _mlMsgCancelled = KissMsg.GetMLMessage("DlgProgressLog", "Cancelled", "Der Vorgang wurde durch den Benutzer abgebrochen.", KissMsgCode.MsgInfo);

        // multilanguage texts
        private static readonly string _mlMsgFormText = KissMsg.GetMLMessage("DlgProgressLog", "FormText", "Fortschritt", KissMsgCode.Text);

        private static readonly string _mlMsgInfoClipboard = KissMsg.GetMLMessage("DlgProgressLog", "InfoCopiedClipboard", "Der Inhalt der Liste wurde in die Zwischenablage kopiert.", KissMsgCode.MsgInfo);
        private static readonly string _mlMsgQuestionCancel = KissMsg.GetMLMessage("DlgProgressLog", "QuestionCancel", "Soll der Vorgang abgebrochen werden?", KissMsgCode.MsgQuestion);
        private static DlgProgressLog _dlg;

        #endregion

        #region Private Fields

        private bool _cancelledByUser;
        private bool _closeOnCancel;
        private bool _firstTime;
        private bool _inProgress;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DlgProgressLog"/> class.
        /// </summary>
        private DlgProgressLog()
        {
            InitializeComponent();

            _closeOnCancel = true;
            _cancelledByUser = false;
            _inProgress = true;
            _firstTime = true;

            BackColor = DBUtil.DefaultMessageDialogBackColor;

            Text = _mlMsgFormText;
            btnCancelClose.Text = _mlMsgButtonCancel;
            btnClipboard.Text = _mlMsgButtonClipboard;

            lstProgressLog.Items.Clear();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether the user cancelled the process.
        /// </summary>
        /// <value><c>true</c> if [cancellled by user]; otherwise, <c>false</c>.</value>
        public static bool CancellledByUser
        {
            get
            {
                ApplicationFacade.DoEvents();

                if (_dlg == null)
                {
                    return false;
                }

                return _dlg._cancelledByUser;
            }
        }

        /// <summary>
        /// Liest oder Setzt den Error status.
        /// </summary>
        public static bool HasErrors
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is visible.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsVisible
        {
            get
            {
                if (_dlg == null)
                {
                    return false;
                }

                return _dlg.Visible;
            }
        }

        /// <summary>
        /// The hooked function is called on close.
        /// </summary>
        public ProgressEventHandler ProgressClose
        {
            get;
            private set;
        }

        /// <summary>
        /// The hooked function is called on start.
        /// </summary>
        public ProgressEventHandler ProgressStart
        {
            get;
            private set;
        }

        #endregion

        #region EventHandlers

        private void btnCancelClose_Click(object sender, EventArgs e)
        {
            if (_dlg == null)
            {
                return;
            }

            if (!_dlg._closeOnCancel)
            {
                _dlg.DialogResult = DialogResult.None;
            }

            if (!_dlg._inProgress || _dlg._cancelledByUser)
            {
                Close();
            }
            else
            {
                if (DlgQuestion.Show(_mlMsgQuestionCancel, 0, 0, true))
                {
                    AddLine(_mlMsgCancelled);
                    _dlg._cancelledByUser = true;
                    btnCancelClose.Text = _mlMsgButtonClose;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClipboard control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnClipboard_Click(object sender, EventArgs e)
        {
            if (lstProgressLog.Items.Count == 0)
            {
                return;
            }

            string text = lstProgressLog.Items[0].ToString();

            for (int i = 1; i < lstProgressLog.Items.Count; i++)
            {
                text += "\r\n" + lstProgressLog.Items[i];
            }

            Clipboard.SetDataObject(text);

            DlgInfo.Show(_mlMsgInfoClipboard, 0, 0);
        }

        /// <summary>
        /// Handles the Activated event of the DlgProgressLog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DlgProgressLog_Activated(object sender, EventArgs e)
        {
            if (!_firstTime)
            {
                return;
            }

            _firstTime = false;

            if (ProgressStart != null)
            {
                ProgressStart();
            }
        }

        /// <summary>
        /// Handles the Closed event of the DlgProgressLog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DlgProgressLog_Closed(object sender, EventArgs e)
        {
            if (ProgressClose != null)
            {
                ProgressClose();
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the lstProgressLog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lstProgressLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstProgressLog.SelectedItems.Count == 1 && !_dlg._inProgress)
                {
                    // set text of current item as tooltip
                    ttpProgress.SetToolTip(lstProgressLog, lstProgressLog.SelectedItem.ToString());
                }
                else
                {
                    // set no text
                    ttpProgress.SetToolTip(lstProgressLog, "");
                }
            }
            catch (Exception)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Break();
                }

                // set no tooltip
                ttpProgress.SetToolTip(lstProgressLog, "");
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Adds an empty line to the log.
        /// </summary>
        /// <param name="text">The text.</param>
        public static void AddEmptyLine()
        {
            NewText(string.Empty, true, false);
        }

        /// <summary>
        /// Adds the error text to the log.
        /// </summary>
        /// <param name="text">The text.</param>
        public static void AddError(string text)
        {
            NewText(text, true, true);

            if (_dlg == null)
            {
                return;
            }

            HasErrors = true;
        }

        /// <summary>
        /// Adds the line to the log.
        /// </summary>
        /// <param name="text">The text.</param>
        public static void AddLine(string text)
        {
            NewText(text, true, true);
        }

        /// <summary>
        /// Closes the dialog.
        /// </summary>
        public static void CloseDialog()
        {
            if (_dlg == null)
            {
                return;
            }

            _dlg.Close();
            _dlg.Dispose();
            _dlg = null;
        }

        /// <summary>
        /// Stop the dialog.
        /// </summary>
        public static void EndProgress()
        {
            if (_dlg == null)
            {
                return;
            }

            _dlg._inProgress = false;
            _dlg.btnCancelClose.Text = _mlMsgButtonOk;
            _dlg.btnCancelClose.Enabled = true;
            _dlg.btnClipboard.Visible = true;
            _dlg.BringToFront();
        }

        /// <summary>
        /// Opens a dialog to display steps of progress in a memofield (with the option to cancel the dialog)
        /// </summary>
        /// <param name="title">the title of the progress dialog</param>
        /// <param name="progressStart"></param>
        /// <param name="progressClose"></param>
        /// <param name="owner"></param>
        public static void Show(string title, ProgressEventHandler progressStart, ProgressEventHandler progressClose, IWin32Window owner)
        {
            Show(title, true, true, 0, 0, progressStart, progressClose, owner);
        }

        /// <summary>
        /// Opens a dialog to display steps of progress in a memofield (with or without the option to cancel the dialog)
        /// </summary>
        /// <param name="title">the title of the progress dialog</param>
        /// <param name="enableCancel">if true, the option to cancel the dialog will be enabled, otherwise the user will not be able to cancel the dialog</param>
        /// <param name="progressStart"></param>
        /// <param name="progressClose"></param>
        /// <param name="owner"></param>
        public static void Show(string title, bool enableCancel, ProgressEventHandler progressStart, ProgressEventHandler progressClose, IWin32Window owner)
        {
            Show(title, enableCancel, true, 0, 0, progressStart, progressClose, owner);
        }

        /// <summary>
        /// Opens a dialog to display steps of progress in a memofield (with or without the option to cancel the dialog)
        /// </summary>
        /// <param name="title">the title of the progress dialog</param>
        /// <param name="enableCancel">if true, the option to cancel the dialog will be enabled, otherwise the user will not be able to cancel the dialog</param>
        /// <param name="closeOnCancel">If true, the dialog is closed after click on Cancel.</param>
        /// <param name="progressStart"></param>
        /// <param name="progressClose"></param>
        /// <param name="owner"></param>
        public static void Show(string title, bool enableCancel, bool closeOnCancel, ProgressEventHandler progressStart, ProgressEventHandler progressClose, IWin32Window owner)
        {
            Show(title, enableCancel, closeOnCancel, 0, 0, progressStart, progressClose, owner);
        }

        /// <summary>
        /// Opens a dialog to display steps of progress in a memofield (with the option to cancel the dialog)
        /// </summary>
        /// <param name="title">the title of the progress dialog</param>
        /// <param name="width">the width of the progress dialog</param>
        /// <param name="height">the height of the progress dialog</param>
        /// <param name="progressStart"></param>
        /// <param name="progressClose"></param>
        /// <param name="owner"></param>
        public static void Show(
            string title,
            int width,
            int height,
            ProgressEventHandler progressStart,
            ProgressEventHandler progressClose,
            IWin32Window owner)
        {
            Show(title, true, true, width, height, progressStart, progressClose, owner);
        }

        /// <summary>
        /// Opens a dialog to display steps of progress in a memofield (with or without the option to cancel the dialog)
        /// </summary>
        /// <param name="title">the title of the progress dialog</param>
        /// <param name="enableCancel">if true, the option to cancel the dialog will be enabled, otherwise the user will not be able to cancel the dialog</param>
        /// <param name="width">the width of the progress dialog</param>
        /// <param name="height">the height of the progress dialog</param>
        /// <param name="progressStart"></param>
        /// <param name="progressClose"></param>
        /// <param name="owner"></param>
        public static void Show(
            string title,
            bool enableCancel,
            int width,
            int height,
            ProgressEventHandler progressStart,
            ProgressEventHandler progressClose,
            IWin32Window owner)
        {
            Show(title, enableCancel, true, width, height, progressStart, progressClose, owner);
        }

        /// <summary>
        /// Opens a dialog to display steps of progress in a memofield (with or without the option to cancel the dialog)
        /// </summary>
        /// <param name="title">the title of the progress dialog</param>
        /// <param name="enableCancel">if true, the option to cancel the dialog will be enabled, otherwise the user will not be able to cancel the dialog</param>
        /// <param name="closeOnCancel">If true, the dialog is closed after click on Cancel.</param>
        /// <param name="width">the width of the progress dialog</param>
        /// <param name="height">the height of the progress dialog</param>
        /// <param name="progressStart"></param>
        /// <param name="progressClose"></param>
        /// <param name="owner"></param>
        public static void Show(
            string title,
            bool enableCancel,
            bool closeOnCancel,
            int width,
            int height,
            ProgressEventHandler progressStart,
            ProgressEventHandler progressClose,
            IWin32Window owner)
        {
            if (_dlg != null)
            {
                _dlg.Close();
                _dlg.Dispose();
            }

            _dlg = new DlgProgressLog
            {
                Text = title,
                ProgressStart = progressStart,
                ProgressClose = progressClose,
                _closeOnCancel = closeOnCancel
            };

            if (width > 0)
            {
                _dlg.Width = width;
            }

            if (width > 0)
            {
                _dlg.Height = height;
            }

            _dlg.btnCancelClose.Enabled = enableCancel;
            HasErrors = false;

            _dlg.ShowDialog(owner);
        }

        /// <summary>
        /// Shows the top most.
        /// </summary>
        public static void ShowTopMost()
        {
            if (_dlg == null)
            {
                return;
            }

            _dlg.BringToFront();
        }

        /// <summary>
        /// Updates the last line.
        /// </summary>
        /// <param name="text">The text.</param>
        public static void UpdateLastLine(string text)
        {
            NewText(text, false, false);
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// News the text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="addLine">if set to <c>true</c> [add line].</param>
        /// <param name="includeTimestamp">if set to <c>true</c>, a timestamp is set at beginning of line. This parameter only affects if addLine is set to <c>true</c>.</param>
        private static void NewText(string text, bool addLine, bool includeTimestamp)
        {
            if (_dlg == null)
            {
                return;
            }

            if (!addLine && _dlg.lstProgressLog.Items.Count == 0)
            {
                return;
            }

            ApplicationFacade.DoEvents();

            if (_dlg._cancelledByUser)
            {
                throw new CancelledByUserException();
            }

            if (!addLine &&
                _dlg.lstProgressLog.Items.Count > 0 &&
                _dlg.lstProgressLog.Items[_dlg.lstProgressLog.Items.Count - 1].ToString().Length > 10 &&
                _dlg.lstProgressLog.Items[_dlg.lstProgressLog.Items.Count - 1].ToString().Substring(10, 1) == "-")
            {
                addLine = true;
            }

            if (addLine)
            {
                if (includeTimestamp)
                    text = DateTime.Now.ToString("HH:mm:ss  ") + text;
                _dlg.lstProgressLog.Items.Add(text);
                _dlg.lstProgressLog.SelectedIndex = _dlg.lstProgressLog.Items.Count - 1;
            }
            else
            {
                text = _dlg.lstProgressLog.Items[_dlg.lstProgressLog.Items.Count - 1].ToString().Substring(0, 10) + text;
            }

            _dlg.lstProgressLog.Items[_dlg.lstProgressLog.Items.Count - 1] = text;
            ApplicationFacade.DoEvents();
        }

        #endregion

        #endregion
    }
}