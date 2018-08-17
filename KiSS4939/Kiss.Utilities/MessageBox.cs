using System;
using System.Linq;
using System.Text;

using Kiss.Interfaces.BL;

using KiSS4.DB;

namespace Kiss.Utilities
{
    /// <summary>
    /// Abstraktionsklasse für Meldungen.
    /// </summary>
    public class MessageBox
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Show an error message box containing your message and the exception details
        /// </summary>
        /// <param name="message">The main message to display</param>
        /// <param name="ex">The additional exception details</param>
        public static void ShowError(string message, Exception ex)
        {
            KissMsg.ShowError(message, ex);
        }

        /// <summary>
        /// Zeigt eien Info Message-Box.
        /// </summary>
        /// <param name="message"></param>
        public static void ShowInfoMessageBox(string message)
        {
            KissMsg.ShowInfo(message);
        }

        /// <summary>
        /// Zeigt die Validierungsfehler an.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="intro">Einleitender Satz</param>
        public static void ShowInfoMessageBox(KissServiceResult result, string intro)
        {
            string message = ConvertToString(result, intro);
            ShowInfoMessageBox(message);
        }

        public static bool ShowQuestion(string question)
        {
            return KissMsg.ShowQuestion(question);
        }

        public static bool ShowQuestion(KissServiceResult result, string intro)
        {
            string message = ConvertToString(result, intro);
            return KissMsg.ShowQuestion(message);
        }

        #endregion

        #region Private Static Methods

        private static string ConvertToString(KissServiceResult result, string intro)
        {
            var errorText = new StringBuilder();
            if (result != null)
            {
                var messages = result.KissServiceResultEntries.Where(x => x.ResultType != ServiceResultType.Ok).Select(x => x.Message).ToList();

                if (messages.Count == 1)
                {
                    errorText.AppendLine(messages[0]);
                }
                else
                {
                    foreach (var message in messages)
                    {
                        errorText.AppendFormat("- {0}", message);
                        errorText.AppendLine("");
                    }
                }
            }
            errorText.AppendLine("");
            errorText.Append(intro);

            return errorText.ToString();
        }

        #endregion

        #endregion
    }
}