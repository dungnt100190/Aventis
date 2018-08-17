using System.Collections.Specialized;
using System.Windows.Forms;

namespace Kiss.Interfaces.UI
{
    public interface IKissFormController
    {
        #region Methods

        /// <summary>
        /// Converts a parameter string to a dictionary.
        /// </summary>
        /// <param name="parameters">The string should have the format: "msgKey1=msgValue1;msgKey2=msgValue2;..."</param>
        /// <returns></returns>
        HybridDictionary ConvertToDictionary(string parameters);

        /// <summary>
        /// Converts a parameter string to a parameter array.
        /// </summary>
        /// <param name="parameters">A string with format "msgKey1=msgValue1;msgKey2=msgValue2;..."</param>
        /// <returns></returns>
        object[] ConvertToParameterArray(string parameters);

        /// <summary>
        /// Converts a parameter string to a parameter array.
        /// </summary>
        /// <param name="parameters">A string with format "msgKey1=msgValue1;msgKey2=msgValue2;..."</param>
        /// <param name="className">The class name to use with the messaging methods.</param>
        /// <returns></returns>
        object[] ConvertToParameterArray(string parameters, out string className);

        /// <summary>
        /// Convert a HybridDictionary holding parameters to a string.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>A string of the format "msgKey1=msgValue1;msgKey2=msgValue2;..."</returns>
        string ConvertToString(HybridDictionary parameters);

        /// <summary>
        /// Opens a form of the given class name and passes the parameters to get a message.
        /// </summary>
        /// <param name="className">Classname of the desired form to open</param>
        /// <param name="forceCreateInstance">True if form has to be opened, false if no instance has to be created</param>
        /// <param name="parameters">Messages the desired form needs. Use the format: "msgKey1", msgValue1, "msgKey2", msgValue2, ...</param>
        /// <returns>Specified object that has to be returned to sender.</returns>
        object GetMessage(string className, bool forceCreateInstance, params object[] parameters);

        /// <summary>
        /// Opens a form instance and passes the parameters to get a message.
        /// </summary>
        /// <param name="instance">The instance to request the message from.</param>
        /// <param name="parameters">Messages the desired form needs. Use the format: "msgKey1", msgValue1, "msgKey2", msgValue2, ...</param>
        /// <returns>Specified object that has to be returned to sender.</returns>
        object GetMessage(IViewMessaging instance, params object[] parameters);

        /// <summary>
        /// Opens a form of the given classname and passes the parameters.
        /// If the form is not already open, it will be opened. If the form is already open, the existing instance will be used.
        /// </summary>
        /// <param name="className">Classname of the desired form to open.</param>
        /// <param name="parameters">Messages the desired form needs. Use the format: "msgKey1", msgValue1, "msgKey2", msgValue2, ...</param>
        /// <returns>True if the command could be executed without any exceptions, otherwise false.</returns>
        bool OpenForm(string className, params object[] parameters);

        /// <summary>
        /// Activates a form of the given classname and passes the parameters.
        /// If the form is not already open, it will not be opened. If the form is already open, the existing instance will be used.
        /// </summary>
        /// <param name="className">Classname of the desired form to open.</param>
        /// <param name="parameters">Messages the desired form needs. Use the format: "msgKey1", msgValue1, "msgKey2", msgValue2, ...</param>
        /// <returns>True if the command could be executed without any exceptions, otherwise false.</returns>
        bool SendMessage(string className, params object[] parameters);

        /// <summary>
        /// Activates a form of the given classname and passes the parameters.
        /// If the form is not already open, it will not be opened. If the form is already open, the existing instance will be used.
        /// </summary>
        /// <param name="instance">The instance to send the message to.</param>
        /// <param name="parameters">Messages the desired form needs. Use the format: "msgKey1", msgValue1, "msgKey2", msgValue2, ...</param>
        /// <returns>True if command could be executed without any exceptions, else false.</returns>
        bool SendMessage(IViewMessaging instance, params object[] parameters);

        /// <summary>
        /// Shows a dialog with the desired owner window.
        /// </summary>
        /// <param name="className">Classname of the desired dialog to open.</param>
        /// <param name="owner">Owner of the dialog.</param>
        /// <param name="parameters">Parameters the constructor of the desired dialog needs.</param>
        /// <returns>DialogResult of the opened dialog or <c>DialogResult.Abort</c> on exception.</returns>
        DialogResult ShowDialog(string className, IWin32Window owner, params object[] parameters);

        #endregion
    }
}