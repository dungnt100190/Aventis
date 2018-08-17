using Kiss.Infrastructure;
using Kiss.Interfaces.BL;
using KiSS4.Messages;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KiSS4.DB
{
    #region Enumerations

    /// <summary>
    /// Enum for the message code
    /// </summary>
    public enum KissMsgCode
    {
        /// <summary>
        /// Info message.
        /// </summary>
        MsgInfo = 1,

        /// <summary>
        /// Error message.
        /// </summary>
        MsgError = 2,

        /// <summary>
        /// Question message.
        /// </summary>
        MsgQuestion = 3,

        /// <summary>
        /// Simple Text.
        /// </summary>
        Text = 4
    }

    #endregion

    /// <summary>
    /// Summary description for KissMsg.
    /// </summary>
    public class KissMsg
    {
        #region Fields

        #region Private Static Fields

        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static bool bLock = false;

        #endregion

        #region Private Constant/Read-Only Fields

        private const string TYPEFULLNAME = "KiSS4.DB.KissMsg";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissMsg"/> class.
        /// </summary>
        public KissMsg()
        {
            // nothing to do yet
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Bring KiSS MainForm to front
        /// </summary>
        public static void BringKiSSAndDialogToFront(System.Windows.Forms.Form dialog)
        {
            try
            {
                // with dialog, also main form will be brought to front
                BringFormToFront(dialog);
            }
            catch (Exception ex)
            {
                // logging
                LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", TYPEFULLNAME, ex.Message);

                // create entry into XLog table
                XLog.Create(TYPEFULLNAME, LogLevel.ERROR, ex.Message);

                // stop here if exception occures
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Break();
                }
            }
        }

        public static IWin32Window GetMainWindow()
        {
            var win32Window = (IWin32Window)Session.MainForm;

            if (Session.IsKiss5Mode)
            {
                win32Window = new Win32Window(System.Windows.Application.Current.MainWindow);
            }

            return win32Window;
        }

        /// <summary>
        /// Get multilanguage text from database (type is KissMsgCode.Text)
        /// </summary>
        /// <param name="maskName">The name of the control or class</param>
        /// <param name="messageName">The name of the message within the control or class</param>
        /// <param name="defaultText">The default text to insert into database if not yet found</param>
        /// <returns>The translated text of the current language or the default text on error</returns>
        public static string GetMLMessage(string maskName, string messageName, string defaultText)
        {
            return GetMLMessage(maskName, messageName, defaultText, KissMsgCode.Text, null);
        }

        /// <summary>
        /// Get multilanguage text from database
        /// </summary>
        /// <param name="maskName">The name of the control or class</param>
        /// <param name="messageName">The name of the message within the control or class</param>
        /// <param name="defaultText">The default text to insert into database if not yet found</param>
        /// <param name="msgCode">The type <see cref="KissMsgCode"/> of the message</param>
        /// <returns>The translated text of the current language or the default text on error</returns>
        public static string GetMLMessage(string maskName, string messageName, string defaultText, KissMsgCode msgCode)
        {
            return GetMLMessage(maskName, messageName, defaultText, msgCode, null);
        }

        /// <summary>
        /// Get multilanguage text from database (type is KissMsgCode.Text)
        /// </summary>
        /// <param name="maskName">The name of the control or class</param>
        /// <param name="messageName">The name of the message within the control or class</param>
        /// <param name="defaultText">The default text to insert into database if not yet found</param>
        /// <param name="parameters">Additional parameters to use</param>
        /// <returns>The translated text of the current language or the default text on error</returns>
        public static String GetMLMessage(string maskName, string messageName, string defaultText, params object[] parameters)
        {
            return GetMLMessage(maskName, messageName, defaultText, KissMsgCode.Text, parameters);
        }

        /// <summary>
        /// Get multilanguage text from database
        /// </summary>
        /// <param name="maskName">The name of the control or class</param>
        /// <param name="messageName">The name of the message within the control or class</param>
        /// <param name="defaultText">The default text to insert into database if not yet found</param>
        /// <param name="msgCode">The type <see cref="KissMsgCode"/> of the message</param>
        /// <param name="parameters">Additional parameters to use</param>
        /// <returns>The translated text of the current language or the default text on error</returns>
        public static String GetMLMessage(string maskName, string messageName, string defaultText, KissMsgCode msgCode, params object[] parameters)
        {
            string msgText = string.Empty;

            if (ValidParameters(maskName, messageName))
            {
                // Check if message exists in db. If not insert message into XMessage and XLangText
                if (bLock)
                {
                    // prevent endless loop with lock and show only first exception
                    // if exception in ExecuteScalarSQL() occurs, a new KissMsg would be shown
                    return defaultText;
                }
                else
                {
                    bLock = true;

                    try
                    {
                        // get text from cache or database
                        msgText = Session.CacheManager.LanguageText.GetMLMessageText(maskName, messageName, defaultText, msgCode);
                    }
                    catch
                    {
                        msgText = defaultText;
                    }
                    finally
                    {
                        bLock = false;
                    }
                }
            }
            else
            {
                msgText = defaultText;
            }

            if (parameters != null)
            {
                return string.Format(msgText, parameters);
            }
            else
            {
                return msgText;
            }
        }

        /// <summary>
        /// Showing a dialog with customized buttons
        /// </summary>
        /// <param name="message">Question Text</param>
        /// <param name="buttonTextList">List of button texts</param>
        /// <returns>Returns the index of the pressed button. Returns -1, when ESCAPE was pressed.</returns>
        public static int ShowButtonDlg(string message, string[] buttonTextList)
        {
            return DlgButtons.ShowButtonDlg(message, buttonTextList, DlgButtonPositionModes.dpmAutomatic, 0, -1, -1);
        }

        /// <summary>
        /// Showing a dialog with customized buttons
        /// </summary>
        /// <param name="message">Question Text</param>
        /// <param name="buttonTextList">List of button texts</param>
        /// <param name="positionMode">Mode for positioning the buttons</param>
        /// <returns>Returns the index of the pressed button. Returns -1, when ESCAPE was pressed.</returns>
        public static int ShowButtonDlg(string message, string[] buttonTextList, DlgButtonPositionModes positionMode)
        {
            return DlgButtons.ShowButtonDlg(message, buttonTextList, positionMode, 0, -1, -1);
        }

        /// <summary>
        /// Showing a dialog with customized buttons
        /// </summary>
        /// <param name="message">Question Text</param>
        /// <param name="buttonTextList">List of button texts</param>
        /// <param name="positionMode">Mode for positioning the buttons</param>
        /// <param name="focusedButtonIndex">Index of the button to be focused in showing</param>
        /// <returns>Returns the index of the pressed button. Returns -1, when ESCAPE was pressed.</returns>
        public static int ShowButtonDlg(string message, string[] buttonTextList, DlgButtonPositionModes positionMode, int focusedButtonIndex)
        {
            return DlgButtons.ShowButtonDlg(message, buttonTextList, positionMode, focusedButtonIndex, -1, -1);
        }

        /// <summary>
        /// Showing a dialog with customized buttons
        /// </summary>
        /// <param name="message">Question Text</param>
        /// <param name="buttonTextList">List of button texts</param>
        /// <param name="positionMode">Mode for positioning the buttons</param>
        /// <param name="focusedButtonIndex">Index of the button to be focused in showing</param>
        /// <param name="helpButtonIndex">Index of the button for calling online help</param>
        /// <param name="helpIndex">Helpindex</param>
        /// <returns>Returns the index of the pressed button. Returns -1, when ESCAPE was pressed.</returns>
        public static int ShowButtonDlg(
            string message,
            string[] buttonTextList,
            DlgButtonPositionModes positionMode,
            int focusedButtonIndex,
            int helpButtonIndex,
            int helpIndex)
        {
            return DlgButtons.ShowButtonDlg(message, buttonTextList, positionMode, focusedButtonIndex, helpButtonIndex, helpIndex);
        }

        /// <summary>
        /// Show an error message.
        /// Use this method only for extraordinary messages, no hardcoded or core messages!
        /// </summary>
        /// <param name="message">The message to show</param>
        public static void ShowError(string message)
        {
            Show(null, null, message, KissMsgCode.MsgError, null, null, 0, 0, true, null);
        }

        /// <summary>
        /// Show an error message with exception details.
        /// Use this method only for extraordinary messages, no hardcoded or core messages!
        /// </summary>
        /// <param name="message">The message to show</param>
        /// <param name="ex">The exception that occured</param>
        public static void ShowError(string message, Exception ex)
        {
            Show(null, null, message, KissMsgCode.MsgError, null, ex, 0, 0, true, null);
        }

        /// <summary>
        /// Shows an error message with technical infos.
        /// Use this method only for extraordinary messages, no hardcoded or core messages!
        /// </summary>
        /// <param name="message">The message to show</param>
        /// <param name="technicalInfo">The technical information to show</param>
        public static void ShowError(string message, string technicalInfo)
        {
            Show(null, null, message, KissMsgCode.MsgError, technicalInfo, null, 0, 0, true, null);
        }

        /// <summary>
        /// Show an error message for given mask and messagename
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        public static void ShowError(string maskName, string messageName, string defaultMessage)
        {
            Show(maskName, messageName, defaultMessage, KissMsgCode.MsgError, null, null, 0, 0, true, null);
        }

        /// <summary>
        /// Show an error message for given mask and messagename including some technical information
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        /// <param name="technicalInfo">The technical information to show</param>
        public static void ShowError(string maskName, string messageName, string defaultMessage, string technicalInfo)
        {
            Show(maskName, messageName, defaultMessage, KissMsgCode.MsgError, technicalInfo, null, 0, 0, true, null);
        }

        /// <summary>
        /// Show an error message for given mask and messagename including the exception
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        /// <param name="ex">The exception that initially caused the error message.</param>
        public static void ShowError(string maskName, string messageName, string defaultMessage, Exception ex)
        {
            Show(maskName, messageName, defaultMessage, KissMsgCode.MsgError, null, ex, 0, 0, true, null);
        }

        /// <summary>
        /// Show an error message for given mask and messagename including technical information and the exception
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        /// <param name="technicalInfo">The technical information to show</param>
        /// <param name="ex">The exception that initially caused the error message.</param>
        public static void ShowError(string maskName, string messageName, string defaultMessage, string technicalInfo, Exception ex)
        {
            Show(maskName, messageName, defaultMessage, KissMsgCode.MsgError, technicalInfo, ex, 0, 0, true, null);
        }

        /// <summary>
        /// Show an error message for given mask and messagename including technical information and the exception with additional size of dialog
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        /// <param name="technicalInfo">The technical information to show</param>
        /// <param name="ex">The exception that initially caused the error message.</param>
        /// <param name="width">The width to use for dialog (if width=0, the default width will be applied)</param>
        /// <param name="height">The height to use for dialog (if height=0, the default height will be applied)</param>
        public static void ShowError(string maskName, string messageName, string defaultMessage, string technicalInfo, Exception ex, int width, int height)
        {
            Show(maskName, messageName, defaultMessage, KissMsgCode.MsgError, technicalInfo, ex, width, height, true, null);
        }

        /// <summary>
        /// Show an error message for given mask and messagename including technical information and the exception with additional parameter
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        /// <param name="technicalInfo">The technical information to show</param>
        /// <param name="ex">The exception that initially caused the error message.</param>
        /// <param name="parameters">Additional parameters to use within message (dynamic content)</param>
        public static void ShowError(string maskName, string messageName, string defaultMessage, string technicalInfo, Exception ex, params object[] parameters)
        {
            Show(maskName, messageName, defaultMessage, KissMsgCode.MsgError, technicalInfo, ex, 0, 0, true, parameters);
        }

        /// <summary>
        /// Show an error message for given mask and messagename including technical information and the exception with additional size of dialog and parameter
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        /// <param name="technicalInfo">The technical information to show</param>
        /// <param name="ex">The exception that initially caused the error message.</param>
        /// <param name="width">The width to use for dialog (if width=0, the default width will be applied)</param>
        /// <param name="height">The height to use for dialog (if height=0, the default height will be applied)</param>
        /// <param name="parameters">Additional parameters to use within message (dynamic content)</param>
        public static void ShowError(
            string maskName,
            string messageName,
            string defaultMessage,
            string technicalInfo,
            Exception ex,
            int width,
            int height,
            params object[] parameters)
        {
            Show(maskName, messageName, defaultMessage, KissMsgCode.MsgError, technicalInfo, ex, width, height, true, parameters);
        }

        /// <summary>
        /// Show an info-message.
        /// Use this method only for extraordinary messages, no hardcoded or core messages!
        /// </summary>
        /// <param name="message">The message to show</param>
        public static void ShowInfo(string message)
        {
            Show(null, null, message, KissMsgCode.MsgInfo, null, null, 0, 0, true, null);
        }

        /// <summary>
        /// Show an info message for given mask and messagename
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        public static void ShowInfo(string maskName, string messageName, string defaultMessage)
        {
            Show(maskName, messageName, defaultMessage, KissMsgCode.MsgInfo, null, null, 0, 0, true, null);
        }

        /// <summary>
        /// Show an info message for given mask and messagename with additional size of dialog
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        /// <param name="width">The width to use for dialog (if width=0, the default width will be applied)</param>
        /// <param name="height">The height to use for dialog (if height=0, the default height will be applied)</param>
        public static void ShowInfo(string maskName, string messageName, string defaultMessage, int width, int height)
        {
            Show(maskName, messageName, defaultMessage, KissMsgCode.MsgInfo, null, null, width, height, true, null);
        }

        /// <summary>
        /// Show an info message for given mask and messagename with additional parameters
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        /// <param name="parameters">Additional parameters to use within message (dynamic content)</param>
        public static void ShowInfo(string maskName, string messageName, string defaultMessage, params object[] parameters)
        {
            Show(maskName, messageName, defaultMessage, KissMsgCode.MsgInfo, null, null, 0, 0, true, parameters);
        }

        /// <summary>
        /// Show an info message for given mask and messagename with additional size of dialog and parameters
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        /// <param name="width">The width to use for dialog (if width=0, the default width will be applied)</param>
        /// <param name="height">The height to use for dialog (if height=0, the default height will be applied)</param>
        /// <param name="parameters">Additional parameters to use within message (dynamic content)</param>
        public static void ShowInfo(string maskName, string messageName, string defaultMessage, int width, int height, params object[] parameters)
        {
            Show(maskName, messageName, defaultMessage, KissMsgCode.MsgInfo, null, null, width, height, true, parameters);
        }

        /// <summary>
        /// Show an question message.
        /// Use this method only for extraordinary messages, no hardcoded or core messages!
        /// </summary>
        /// <param name="message">The message to show</param>
        /// <returns><c>true</c> if user confirmed question with yes, otherwise return <c>false</c></returns>
        public static bool ShowQuestion(string message)
        {
            return Show(null, null, message, KissMsgCode.MsgQuestion, null, null, 0, 0, true, null);
        }

        /// <summary>
        /// Show an question message.
        /// Use this method only for extraordinary messages, no hardcoded or core messages!
        /// </summary>
        /// <param name="message">The message to show</param>
        /// <param name="defaultYes">Flag if default button is yes-button (value is <c>true</c>), otherwise default will be no-buton</param>
        /// <returns><c>true</c> if user confirmed question with yes, otherwise return <c>false</c></returns>
        public static bool ShowQuestion(string message, bool defaultYes)
        {
            return Show(null, null, message, KissMsgCode.MsgQuestion, null, null, 0, 0, defaultYes, null);
        }

        /// <summary>
        /// Show an question message for given mask and messagename
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        /// <returns><c>true</c> if user confirmed question with yes, otherwise return <c>false</c></returns>
        public static bool ShowQuestion(string maskName, string messageName, string defaultMessage)
        {
            return Show(maskName, messageName, defaultMessage, KissMsgCode.MsgQuestion, null, null, 0, 0, true, null);
        }

        /// <summary>
        /// Show an question message for given mask and messagename
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        /// <param name="defaultYes">Flag if default button is yes-button (value is <c>true</c>), otherwise default will be no-buton</param>
        /// <returns><c>true</c> if user confirmed question with yes, otherwise return <c>false</c></returns>
        public static bool ShowQuestion(string maskName, string messageName, string defaultMessage, bool defaultYes)
        {
            return Show(maskName, messageName, defaultMessage, KissMsgCode.MsgQuestion, null, null, 0, 0, defaultYes, null);
        }

        /// <summary>
        /// Show an question message for given mask and messagename with additional size of dialog
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        /// <param name="width">The width to use for dialog (if width=0, the default width will be applied)</param>
        /// <param name="height">The height to use for dialog (if height=0, the default height will be applied)</param>
        /// <returns><c>true</c> if user confirmed question with yes, otherwise return <c>false</c></returns>
        public static bool ShowQuestion(string maskName, string messageName, string defaultMessage, int width, int height)
        {
            return Show(maskName, messageName, defaultMessage, KissMsgCode.MsgQuestion, null, null, width, height, true, null);
        }

        /// <summary>
        /// Show an question message for given mask and messagename with additional size of dialog
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        /// <param name="width">The width to use for dialog (if width=0, the default width will be applied)</param>
        /// <param name="height">The height to use for dialog (if height=0, the default height will be applied)</param>
        /// <param name="defaultYes">Flag if default button is yes-button (value is <c>true</c>), otherwise default will be no-buton</param>
        /// <returns><c>true</c> if user confirmed question with yes, otherwise return <c>false</c></returns>
        public static bool ShowQuestion(string maskName, string messageName, string defaultMessage, int width, int height, bool defaultYes)
        {
            return Show(maskName, messageName, defaultMessage, KissMsgCode.MsgQuestion, null, null, width, height, defaultYes, null);
        }

        /// <summary>
        /// Show an question message for given mask and messagename with parameter
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        /// <param name="defaultYes">Flag if default button is yes-button (value is <c>true</c>), otherwise default will be no-buton</param>
        /// <param name="parameters">Additional parameters to use within message (dynamic content)</param>
        /// <returns><c>true</c> if user confirmed question with yes, otherwise return <c>false</c></returns>
        public static bool ShowQuestion(string maskName, string messageName, string defaultMessage, bool defaultYes, params object[] parameters)
        {
            return Show(maskName, messageName, defaultMessage, KissMsgCode.MsgQuestion, null, null, 0, 0, defaultYes, parameters);
        }

        /// <summary>
        /// Show an question message for given mask and messagename with additional size of dialog and parameter
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        /// <param name="width">The width to use for dialog (if width=0, the default width will be applied)</param>
        /// <param name="height">The height to use for dialog (if height=0, the default height will be applied)</param>
        /// <param name="defaultYes">Flag if default button is yes-button (value is <c>true</c>), otherwise default will be no-buton</param>
        /// <param name="parameters">Additional parameters to use within message (dynamic content)</param>
        /// <returns><c>true</c> if user confirmed question with yes, otherwise return <c>false</c></returns>
        public static Boolean ShowQuestion(string maskName, string messageName, string defaultMessage, int width, int height, bool defaultYes, params object[] parameters)
        {
            return Show(maskName, messageName, defaultMessage, KissMsgCode.MsgQuestion, null, null, width, height, defaultYes, parameters);
        }

        /// <summary>
        /// Shows a message based on a service result.
        /// </summary>
        /// <param name="result"></param>
        public static bool ShowResult(IServiceResult result)
        {
            var code = KissMsgCode.MsgInfo;

            if (result.IsError)
            {
                code = KissMsgCode.MsgError;
            }
            else if (result.IsWarning)
            {
                code = KissMsgCode.MsgInfo;
            }
            else if (result.IsQuestion)
            {
                code = KissMsgCode.MsgQuestion;
            }

            return Show(null, null, result.ToString(), code, result.GetTechnicalDetails(), null, 0, 0, true);
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Bring form to front of other all other forms
        /// </summary>
        /// <param name="frm">The instance of the form</param>
        private static void BringFormToFront(System.Windows.Forms.Form frm)
        {
            // check if we have a main form
            if (frm != null)
            {
                // store current topmost value
                bool isTopMost = frm.TopMost;

                // bring window to front
                frm.TopMost = true;

                try
                {
                    // focus and bring to front
                    frm.Focus();
                    frm.BringToFront();
                }
                finally
                {
                    frm.TopMost = isTopMost;
                }
            }
        }

        /// <summary>
        /// Call the right class for info, error, question with the corresponding values
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <param name="defaultMessage">The default message to use if message is not yet in database or translated</param>
        /// <param name="msgCode">The message code used for grouping the messages depending on type</param>
        /// <param name="technicalInfo">The technical information to show</param>
        /// <param name="ex">The exception that initially caused the error message.</param>
        /// <param name="width">The width to use for dialog (if width=0, the default width will be applied)</param>
        /// <param name="height">The height to use for dialog (if height=0, the default height will be applied)</param>
        /// <param name="defaultYes">Flag if default button is yes-button (value is <c>true</c>), otherwise default will be no-buton</param>
        /// <param name="parameters">Additional parameters to use within message (dynamic content)</param>
        /// <returns><c>true</c> if user confirmed question with yes, otherwise return <c>false</c></returns>
        private static bool Show(
            string maskName,
            string messageName,
            string defaultMessage,
            KissMsgCode msgCode,
            string technicalInfo,
            Exception ex,
            int width,
            int height,
            bool defaultYes,
            params object[] parameters)
        {
            bool returnValue = false;
            string msgText = String.Empty;

            try
            {
                // only display MsgBox if we are in an interactive session: say: Session.MainForm is not null
                if (Session.MainForm == null)
                    return defaultYes;

                // check if message is an exception
                if (ValidParameters(maskName, messageName))
                {
                    // check if message exists in db. If not insert message into XMessage and XLangText
                    if (bLock)
                    {
                        // prevent endless loop with lock and show only first exception
                        // if exception in ExecuteScalarSQL() occurs, a new KissMsg would be shown
                        return returnValue;
                    }
                    else
                    {
                        bLock = true;
                        try
                        {
                            // get text from cache or database
                            msgText = Session.CacheManager.LanguageText.GetMLMessageText(maskName, messageName, defaultMessage, msgCode);
                        }
                        catch (Exception)
                        {
                            // use non-translated default text
                            msgText = defaultMessage;
                        }
                        finally
                        {
                            bLock = false;
                        }
                    }
                }
                else
                {
                    // no insert into the db, because it is an exception message
                    msgText = defaultMessage;
                }

                switch (msgCode)
                {
                    case KissMsgCode.MsgInfo:
                        // info dialog
                        if (parameters != null)
                        {
                            DlgInfo.Show(string.Format(msgText, parameters), width, height);
                        }
                        else
                        {
                            DlgInfo.Show(msgText, width, height);
                        }
                        break;

                    case KissMsgCode.MsgError:
                        // error dialog
                        if (parameters != null)
                        {
                            DlgError.Show(string.Format(msgText, parameters), technicalInfo, ex, width, height);
                        }
                        else
                        {
                            DlgError.Show(msgText, technicalInfo, ex, width, height);
                        }
                        break;

                    case KissMsgCode.MsgQuestion:
                        // question dialog
                        if (parameters != null)
                        {
                            returnValue = DlgQuestion.Show(string.Format(msgText, parameters), width, height, defaultYes);
                        }
                        else
                        {
                            returnValue = DlgQuestion.Show(msgText, width, height, defaultYes);
                        }
                        break;
                }
            }
            catch
            {
                if (defaultMessage != null)
                {
                    msgText = defaultMessage;
                }
                else
                {
                    msgText = KissMsg.GetMLMessage("KissMsgBox", "ErrorInKissMsgShow", Properties.Resources.KissMsgBox_ErrorInKissMsgShow);
                }

                if (parameters != null)
                {
                    DlgError.Show(string.Format(msgText, parameters), technicalInfo, ex, width, height);
                }
                else
                {
                    DlgError.Show(msgText, technicalInfo, ex, width, height);
                }

                returnValue = false;
            }

            return returnValue;
        }

        /// <summary>
        /// Validate parameters for querying message from database
        /// </summary>
        /// <param name="maskName">The name of the mask to which messagename belongs to</param>
        /// <param name="messageName">The unique name of the message within given maskname</param>
        /// <returns>True if parameters are valid, otherwise false</returns>
        private static bool ValidParameters(string maskName, string messageName)
        {
            // we need a user and valid mask/message
            return (Session.User != null && !string.IsNullOrEmpty(maskName) && !string.IsNullOrEmpty(messageName));
        }

        #endregion

        #endregion
    }
}