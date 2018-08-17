using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

using Kiss.Infrastructure;
using Kiss.Infrastructure.Utils;

using KiSS4.DB;

using log4net;

namespace KiSS4.Dokument.Utilities
{
    /// <summary>
    ///
    /// </summary>
    public static class FileUtilies
    {
        private const Int32 FS_TIMEOUT = 6;
        private const Int32 FS_TIMEOUT_LONG = 15;

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// ConnectionString, damit aus dem Word oder aus dem Excel
        /// auf die Datenbank zugegriffen werden kann. Der User für den
        /// Datenbankzugriff ist in der Systemkonfiguration gespeichert:
        /// - System\Bookmarks\DBUser
        /// - System\Bookmarks\DBPassword
        /// </summary>
        public static string OLEDBConnectionString
        {
            get { return GetOLEDBConnectionString(); }
        }

        public static string CleanFileName(string filename)
        {
            var filenameWithoutInvalidChars = RemoveInvalidFileNameChars(filename);
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filenameWithoutInvalidChars);

            var extension = Path.GetExtension(filenameWithoutInvalidChars);
            var filenameLength = 250 - extension.Length;
            if (fileNameWithoutExtension.Length > filenameLength)
            {
                filenameWithoutInvalidChars = filenameWithoutInvalidChars.Substring(0, filenameLength) + extension;
            }

            return filenameWithoutInvalidChars;
        }

        public static string RemoveInvalidFileNameChars(string filename)
        {
            return string.Concat(filename.Split(Path.GetInvalidFileNameChars(), StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>
        ///  Entfernt die RTF Formattierung.
        /// </summary>
        /// <param name="text">string inklusive RTF Formattierung</param>
        /// <returns>String ohne RTF Formattierung</returns>
        public static string RemoveRTFFormatting(string text)
        {
            // removes formatting. Code is copied from WordDoc.cs
            // Hint: In MS-word the RTF Text is pasted from KiSS to the clipboard
            //       (DataFormats.Rtf) and pasted (in MS-word).
            string result = "";
            RichTextBox RtfBox = new RichTextBox();
            try
            {
                RtfBox.Rtf = text;
                result = RtfBox.Text;
            }
            catch (ArgumentException ex)
            {
                logger.Warn("Format is invalid and will be coerced");

                // Eintrag ins Log.
                logger.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", typeof(FileUtilies).FullName, ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Replace "{0}" with the param or truncated param so that the filename is not longer as 210 chars
        /// </summary>
        /// <param name="filename">the filename</param>
        /// <param name="param">the param to add in filename</param>
        /// <param name="filePathLength">the path length</param>
        /// <returns>filename with truncated param</returns>
        public static string ReplaceParamInFileName(string filename, string param, int filePathLength)
        {
            // max length set to 210 as the max length for Excel is 218... https://support.microsoft.com/de-de/kb/325573
            filename = String.Format(filename, param.Truncate(210 - filename.Length + 3 - filePathLength));

            return filename;
        }

        /// <summary>
        /// Wait short for document to be removed from filesystem.
        /// </summary>
        /// <param name="file">The file.</param>
        public static void WaitForDocToBeRemovedFromFilesystem(FileInfo file)
        {
            WaitForDocToBeRemovedFromFilesystemWithTimeout(file, FS_TIMEOUT);
        }

        /// <summary>
        /// Wait long for document to be removed from the filesystem.
        /// </summary>
        /// <param name="file">The file.</param>
        public static void WaitLongForDocToBeRemovedFromFilesystem(FileInfo file)
        {
            WaitForDocToBeRemovedFromFilesystemWithTimeout(file, FS_TIMEOUT_LONG);
        }

        /// <summary>
        /// ConnectionString, damit aus dem Word oder aus dem Excel
        /// auf die Datenbank zugegriffen werden kann. Der User für den
        /// Datenbankzugriff ist in der Systemkonfiguration gespeichert:
        /// - System\Bookmarks\DBUser
        /// - System\Bookmarks\DBPassword
        /// </summary>
        /// <returns></returns>
        private static string GetOLEDBConnectionString()
        {
            string connectionString = Session.Env.OLEDBConnectionString;

            // Get the bookmark user and password from the XConfig Table
            string bmUser = DBUtil.GetConfigString(@"System\Bookmarks\DBUser", null);
            string bmPassword = DBUtil.GetConfigString(@"System\Bookmarks\DBPassword", null);

            // Replace the connection string with the KiSS_BookmarksOnly user if it's defined
            if (bmUser != null && bmPassword != null)
            {
                string[] connectionStringPart = connectionString.Split(';');
                connectionString = "";
                for (int i = 0; i < connectionStringPart.Length - 1; i++)
                {
                    string part = connectionStringPart[i];
                    if (part.StartsWith("user id"))
                    {
                        part = part.Replace(part.Substring(part.IndexOf('=') + 1), bmUser);
                    }
                    else if (part.StartsWith("password"))
                    {
                        part = part.Replace(part.Substring(part.IndexOf('=') + 1), bmPassword);
                    }
                    connectionString += part + ";";
                }
            }
            return connectionString;
        }

        /// <summary>
        /// Wait specified time [s] for doc to be removed from filesystem with timeout.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="timeout">The timeout.</param>
        private static void WaitForDocToBeRemovedFromFilesystemWithTimeout(FileInfo file, int timeout)
        {
            int i = 0;
            while (file.Exists && i < timeout)
            {
                i++;
                try
                {
                    //DlgProgressLog.AddLine(KissMsg.GetMLMessage("XDocument", "Warten", "."));
                    ApplicationFacade.DoEvents();
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    logger.Warn(ex.Message);
                }
            }
            if (i == timeout)
            {
                throw new TimeoutException("Timeout while waiting for Word to finish...");
            }
        }
    }
}