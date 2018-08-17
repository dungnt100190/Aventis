using System;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for FormController.
    /// </summary>
    public class FormController : IKissFormController
    {
        private static readonly Regex _rxKeyValue = new Regex(@"\s*(?<Key>\x5B.*?\x5D|\S*?)\s*=(?<Value>\x22.*?\x22|.*?)(?:$|;)");

        public static bool DelegateMode { get; set; }

        public static IKiss4MessageHandler Kiss4MessageHandler { get; set; }

        /// <summary>
        /// Convert a Key=Value; string to a HybridDictionary
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static HybridDictionary ConvertToDictionary(string parameters)
        {
            if (parameters == null)
            {
                return null;
            }

            HybridDictionary dic = new HybridDictionary();

            foreach (Match match in _rxKeyValue.Matches(parameters))
            {
                string key = match.Groups["Key"].Value;

                if (key.StartsWith("[") && key.EndsWith("]"))
                {
                    key = key.Substring(2, key.Length - 2);
                }

                string val = match.Groups["Value"].Value;

                if (val == String.Empty)
                {
                    dic[key] = null;
                }
                else if (val.StartsWith("\"") && val.EndsWith("\""))
                {
                    dic[key] = val.Substring(1, val.Length - 2);
                }
                else
                {
                    int i;

                    if (Int32.TryParse(val, out i))
                    {
                        dic[key] = i;
                    }
                    else
                    {
                        bool b;

                        if (Boolean.TryParse(val, out b))
                        {
                            dic[key] = b;
                        }
                        else
                        {
                            DateTime d;

                            if (DateTime.TryParse(val, out d))
                            {
                                dic[key] = d;
                            }
                            else
                            {
                                dic[key] = val;
                            }
                        }
                    }
                }
            }

            return dic;
        }

        public static object[] ConvertToParameterArray(string parameters)
        {
            string className;
            return ConvertToParameterArray(parameters, out className);
        }

        public static object[] ConvertToParameterArray(string parameters, out string className)
        {
            className = null;
            var dictionary = ConvertToDictionary(parameters);
            var result = new object[dictionary.Count * 2];

            if (dictionary.Contains(Param.CLASS_NAME))
            {
                className = dictionary[Param.CLASS_NAME].ToString();
            }

            int i = 0;
            foreach (var key in dictionary.Keys)
            {
                result[i++] = key;
                result[i++] = dictionary[key];
            }

            return result;
        }

        /// <summary>
        /// Convert HybridDictionary to as string
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string ConvertToString(HybridDictionary parameters)
        {
            if (parameters == null)
            {
                return null;
            }

            string output = String.Empty;

            foreach (string key in parameters.Keys)
            {
                object val = parameters[key];

                if (val is string && ((string)val).Contains(";"))
                {
                    output += String.Format("{0}=\"{1}\";", key, val);
                }
                else
                {
                    output += String.Format("{0}={1};", key, val);
                }
            }

            return output;
        }

        /// <summary>
        /// Convert object[] parameters to hybriddictionary
        /// </summary>
        /// <param name="parameters">
        /// Parameters in format: "msgKey1", msgValue1, "msgKey2", msgValue2, ...
        /// </param>
        /// <returns>Null if no parameters or parameters converted to hybriddictionary</returns>
        public static HybridDictionary GetHybridDictionaryFromParameters(params object[] parameters)
        {
            // create a hybriddictionary to pass over to other method
            HybridDictionary hybridDic = null;

            int parametersLength = parameters.Length;

            // check if we have a valid amount of parameters
            if (parametersLength % 2 != 0)
            {
                if (parameters[parametersLength - 1] is HybridDictionary)
                {
                    hybridDic = (HybridDictionary)parameters[--parametersLength];
                }
                else
                {
                    // invalid amount of parameters given
                    throw new KissErrorException("Invalid amount of paramters given, please enter a valid value for each key in parameters.");
                }
            }

            if (hybridDic == null)
            {
                hybridDic = new HybridDictionary();
            }

            // check if we have any parameters
            if (parametersLength > 0)
            {
                // fill in given parameters
                for (int i = 1; i < parametersLength; i = i + 2)
                {
                    int keyIndex = i - 1;

                    if (parameters[keyIndex] is string)
                    {
                        // param name
                        hybridDic.Add(parameters[keyIndex], parameters[i]);
                    }
                    else
                    {
                        // invalid key type
                        throw new KissErrorException("Invalid key type in parameters, can only use strings as a key.");
                    }
                }
            }

            return hybridDic;
        }

        /// <summary>
        /// Open form of the given classname and pass on the parameters.
        /// </summary>
        /// <param name="className">Classname of the desired form to open</param>
        /// <param name="forceCreateInstance">
        /// True if form has to be opened, false if no instance has to be created
        /// </param>
        /// <param name="parameters">
        /// Messages the desired form needs. Use the format: "msgKey1", msgValue1, "msgKey2",
        /// msgValue2, ...
        /// </param>
        /// <returns>Specified object that has to be returned to sender</returns>
        public static object GetMessage(string className, bool forceCreateInstance, params object[] parameters)
        {
            try
            {
                return GetMessage(className, forceCreateInstance, GetHybridDictionaryFromParameters(parameters));
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("FormController", "CommandExecuteFailed", "Befehl konnte nicht ausgeführt werden.", ex);
                return null;
            }
        }

        /// <summary>
        /// Open form of the given classname and pass on the parameters.
        /// </summary>
        /// <param name="className">Classname of the desired form to open</param>
        /// <param name="forceCreateInstance">
        /// True if form has to be opened, false if no instance has to be created
        /// </param>
        /// <param name="parameters">Messages the desired form needs.</param>
        /// <returns>Specified object that has to be returned to sender</returns>
        public static object GetMessage(string className, bool forceCreateInstance, HybridDictionary parameters)
        {
            try
            {
                if (Kiss4MessageHandler != null)
                {
                    return Kiss4MessageHandler.GetMessage(className, parameters);
                }

                var frm = OpenChildForm(className, forceCreateInstance, false);

                if (frm != null || forceCreateInstance)
                {
                    return GetMessage(frm, parameters);
                }

                return null;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("FormController", "CommandExecuteFailed", "Befehl konnte nicht ausgeführt werden.", ex);
                return null;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="parameters">
        /// Messages the desired form needs. Use the format: "msgKey1", msgValue1, "msgKey2",
        /// msgValue2, ...
        /// </param>
        /// <returns>Specified object that has to be returned to sender</returns>
        public static object GetMessage(IViewMessaging instance, params object[] parameters)
        {
            try
            {
                return GetMessage(instance, GetHybridDictionaryFromParameters(parameters));
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("FormController", "CommandExecuteFailed", "Befehl konnte nicht ausgeführt werden.", ex);
                return null;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="parameters">Messages the desired form needs.</param>
        /// <returns>Specified object that has to be returned to sender</returns>
        public static object GetMessage(IViewMessaging instance, HybridDictionary parameters)
        {
            try
            {
                if (Kiss4MessageHandler != null && (instance == null || instance is Form))
                {
                    return Kiss4MessageHandler.GetMessage(null, parameters);
                }

                if (instance != null)
                {
                    // call method and pass on defined parameters
                    return instance.ReturnMessage(parameters);
                }

                // no instance found (even if forced --> assume exception was shown) --> nothing to return
                return null;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("FormController", "CommandExecuteFailed", "Befehl konnte nicht ausgeführt werden.", ex);
                return null;
            }
        }

        /// <summary>
        /// Open form of the given classname and pass on the parameters. If form is not open
        /// already, it will be opened. If the form is already open, the existing instance will be used.
        /// </summary>
        /// <param name="className">Classname of the desired form to open</param>
        /// <param name="parameters">
        /// Messages the desired form needs. Use the format: "msgKey1", msgValue1, "msgKey2",
        /// msgValue2, ...
        /// </param>
        /// <returns>True if command could be executed without any exceptions, else false</returns>
        public static bool OpenForm(string className, params object[] parameters)
        {
            try
            {
                return OpenForm(className, GetHybridDictionaryFromParameters(parameters));
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("FormController", "CommandExecuteFailed", "Befehl konnte nicht ausgeführt werden.", ex);
                return false;
            }
        }

        /// <summary>
        /// Open form of the given classname and pass on the parameters. If form is not open
        /// already, it will be opened. If the form is already open, the existing instance will be used.
        /// </summary>
        /// <param name="className">Classname of the desired form to open</param>
        /// <param name="parameters">Messages the desired form needs.</param>
        /// <returns>True if command could be executed without any exceptions, else false</returns>
        public static bool OpenForm(string className, HybridDictionary parameters)
        {
            try
            {
                if (Kiss4MessageHandler != null)
                {
                    return Kiss4MessageHandler.SendMessage(className, parameters, true);
                }

                return SendMessage(OpenChildForm(className, true, true), parameters);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("FormController", "CommandExecuteFailed", "Befehl konnte nicht ausgeführt werden.", ex);
                return false;
            }
        }

        /// <summary>
        /// Activate form of the given classname and pass on the parameters. If form is not open
        /// already, it will not be opened. If the form is already open, the existing instance will
        /// be used.
        /// </summary>
        /// <param name="className">Classname of the desired form to open</param>
        /// <param name="parameters">
        /// Messages the desired form needs. Use the format: "msgKey1", msgValue1, "msgKey2",
        /// msgValue2, ...
        /// </param>
        /// <returns>True if command could be executed without any exceptions, else false</returns>
        public static bool SendMessage(string className, params object[] parameters)
        {
            try
            {
                return SendMessage(className, GetHybridDictionaryFromParameters(parameters));
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("FormController", "CommandExecuteFailed", "Befehl konnte nicht ausgeführt werden.", ex);
                return false;
            }
        }

        /// <summary>
        /// Activate form of the given classname and pass on the parameters. If form is not open
        /// already, it will not be opened. If the form is already open, the existing instance will
        /// be used.
        /// </summary>
        /// <param name="className">Classname of the desired form to open</param>
        /// <param name="parameters">Messages the desired form needs.</param>
        /// <returns>True if command could be executed without any exceptions, else false</returns>
        public static bool SendMessage(string className, HybridDictionary parameters)
        {
            try
            {
                if (Kiss4MessageHandler != null)
                {
                    return Kiss4MessageHandler.SendMessage(className, parameters, false);
                }

                return SendMessage(OpenChildForm(className, false, false), parameters);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("FormController", "CommandExecuteFailed", "Befehl konnte nicht ausgeführt werden.", ex);
                return false;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="parameters">
        /// Messages the desired form needs. Use the format: "msgKey1", msgValue1, "msgKey2",
        /// msgValue2, ...
        /// </param>
        /// <returns>True if command could be executed without any exceptions, else false</returns>
        public static bool SendMessage(IViewMessaging instance, params object[] parameters)
        {
            try
            {
                return SendMessage(instance, GetHybridDictionaryFromParameters(parameters));
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("FormController", "CommandExecuteFailed", "Befehl konnte nicht ausgeführt werden.", ex);
                return false;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="parameters">Messages the desired form needs.</param>
        /// <returns>True if command could be executed without any exceptions, else false</returns>
        public static bool SendMessage(IViewMessaging instance, HybridDictionary parameters)
        {
            try
            {
                if (instance != null)
                {
                    // check if we have defined any parameters
                    if (parameters == null)
                    {
                        // no parameters -> by default, nothing to do
                        return true;
                    }

                    // init flag
                    bool wasFormClosingDisabled = false;

                    try
                    {
                        if (instance is Form)
                        {
                            // lock closing form
                            wasFormClosingDisabled = UtilsGui.DisableCloseForm((Form)instance);
                        }

                        // call method and pass on defined parameters, return result of handled message
                        return instance.ReceiveMessage(parameters);
                    }
                    finally
                    {
                        if (wasFormClosingDisabled && instance is Form)
                        {
                            // unlock closing form
                            UtilsGui.EnableCloseFrom((Form)instance, true);
                        }
                    }
                }

                // could not open child form or not forced to open (assume any exceptions were
                // already shown to the user)
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("FormController", "CommandExecuteFailed", "Befehl konnte nicht ausgeführt werden.", ex);
                return false;
            }
        }

        /// <summary>
        /// Show dialog with no owner
        /// </summary>
        /// <param name="className">Classname of the desired dialog to open</param>
        /// <param name="parameters">Parameters the constructor of the desired dialog needs</param>
        /// <returns>DialogResult of opened dialog or DialogResult.Abort on exception</returns>
        public static DialogResult ShowDialog(string className, params object[] parameters)
        {
            return ShowDialog(className, null, parameters);
        }

        /// <summary>
        /// Show dialog with desired owner
        /// </summary>
        /// <param name="className">Classname of the desired dialog to open</param>
        /// <param name="owner">Owner of the dialog</param>
        /// <param name="parameters">Parameters the constructor of the desired dialog needs</param>
        /// <returns>DialogResult of opened dialog or DialogResult.Abort on exception</returns>
        public static DialogResult ShowDialog(string className, IWin32Window owner, params object[] parameters)
        {
            try
            {
                // validate first
                ValidateClassName(className);

                // get type of desired class
                Type typ = AssemblyLoader.GetType(className);

                if (typ == null)
                {
                    throw new KissErrorException(String.Format("Could not get type of given classname '{0}', cannot proceed executing command.", className));
                }

                if (!typeof(KissDialog).IsAssignableFrom(typ) && !typeof(Form).IsAssignableFrom(typ))
                {
                    throw new KissErrorException(String.Format("Invalid type of given classname '{0}', should be type of 'KiSS4.Gui.KissDialog' or 'System.Windows.Forms.Form'. Cannot proceed executing command.", className));
                }

                // create instance
                Form dlg = (Form)AssemblyLoader.CreateInstance(typ, parameters);

                // show dialog
                if (owner == null)
                {
                    return dlg.ShowDialog();
                }

                return dlg.ShowDialog(owner);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("FormController", "CommandExecuteFailed", "Befehl konnte nicht ausgeführt werden.", ex);
                return DialogResult.Abort;
            }
        }

        /// <summary>
        /// Show dialog with main as owner
        /// </summary>
        /// <param name="className">Classname of the desired dialog to open</param>
        /// <param name="parameters">Parameters the constructor of the desired dialog needs</param>
        /// <returns>DialogResult of opened dialog or DialogResult.Abort on exception</returns>
        public static DialogResult ShowDialogOnMain(string className, params object[] parameters)
        {
            try
            {
                // get main
                KissMainForm main = (KissMainForm)Session.MainForm;

                if (main == null)
                {
                    throw new KissErrorException("Could not get instance of main, cannot proceed executing command.");
                }

                return ShowDialog(className, main, parameters);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("FormController", "CommandExecuteFailed", "Befehl konnte nicht ausgeführt werden.", ex);
                return DialogResult.Abort;
            }
        }

        HybridDictionary IKissFormController.ConvertToDictionary(string parameters)
        {
            return ConvertToDictionary(parameters);
        }

        object[] IKissFormController.ConvertToParameterArray(string parameters, out string className)
        {
            return ConvertToParameterArray(parameters, out className);
        }

        object[] IKissFormController.ConvertToParameterArray(string parameters)
        {
            string className;
            return ConvertToParameterArray(parameters, out className);
        }

        string IKissFormController.ConvertToString(HybridDictionary parameters)
        {
            return ConvertToString(parameters);
        }

        object IKissFormController.GetMessage(string className, bool forceCreateInstance, params object[] parameters)
        {
            return GetMessage(className, forceCreateInstance, parameters);
        }

        object IKissFormController.GetMessage(IViewMessaging instance, params object[] parameters)
        {
            return GetMessage(instance, parameters);
        }

        bool IKissFormController.OpenForm(string className, params object[] parameters)
        {
            return OpenForm(className, parameters);
        }

        bool IKissFormController.SendMessage(string className, params object[] parameters)
        {
            return SendMessage(className, parameters);
        }

        bool IKissFormController.SendMessage(IViewMessaging instance, params object[] parameters)
        {
            return SendMessage(instance, parameters);
        }

        DialogResult IKissFormController.ShowDialog(string className, IWin32Window owner, params object[] parameters)
        {
            return ShowDialog(className, owner, parameters);
        }

        /// <summary>
        /// Open form of the given classname
        /// </summary>
        /// <param name="className">Classname of the desired form to open</param>
        /// <param name="forceCreateInstance">
        /// True if instance has to be created if not existing, false if no need to create instance
        /// </param>
        /// <param name="setFocus"></param>
        /// <returns>Instance of childform if any created or null</returns>
        private static IViewMessaging OpenChildForm(string className, bool forceCreateInstance, bool setFocus)
        {
            if (Kiss4MessageHandler != null)
            {
                throw new KissErrorException("Ein Control darf in KiSS5 nicht aus KiSS4 erstellt werden.");
            }

            // validate first
            ValidateClassName(className);

            // get main
            KissMainForm main = (KissMainForm)Session.MainForm;

            if (main == null)
            {
                throw new KissErrorException("Could not get instance of main, cannot proceed executing command.");
            }

            // get type of desired class
            Type typ = AssemblyLoader.GetType(className);

            if (typ == null)
            {
                throw new KissErrorException(String.Format("Could not get type of given classname '{0}', cannot proceed executing command.", className));
            }

            // get instance of form if any exists
            KissChildForm childForm = main.GetChildForm(typ);

            // open and activate form
            if (childForm != null)
            {
                if (setFocus)
                {
                    childForm.Activate();
                }

                return childForm;
            }

            if (!forceCreateInstance)
            {
                // do not activate form if no instance found
                return null;
            }

            // open form and activate
            return main.OpenChildForm(typ);
        }

        /// <summary>
        /// Validate classname for null, string.empty
        /// </summary>
        /// <param name="className">Classname to validate</param>
        /// <exception cref="ArgumentNullException">Throws an exception if classname is invalid</exception>
        private static void ValidateClassName(string className)
        {
            if (String.IsNullOrEmpty(className))
            {
                // invalid classname
                throw new ArgumentNullException("className");
            }
        }

        public static class Action
        {
            public const string GET_JUMP_TO_PATH = "GetJumpToPath";
            public const string JUMP_TO_PATH = "JumpToPath";
            public const string REFRESH_TREE = "RefreshTree";
            public const string SHOW_FALL = "ShowFall";
        }

        public static class Forms
        {
            public const string FALL = "FrmFall";
        }

        public static class Param
        {
            public const string ACTION = "Action";
            public const string ACTIVESQLQUERY_FIND = "ActiveSQLQuery.Find";
            public const string BA_PERSON_ID = "BaPersonID";
            public const string CLASS_NAME = "ClassName";
            public const string FA_FALL_ID = "FaFallID";
            public const string FA_LEISTUNG_ID = "FaLeistungID";
            public const string MODUL_ID = "ModulID";
            public const string TREE_NODE_ID = "TreeNodeID";
        }
    }
}