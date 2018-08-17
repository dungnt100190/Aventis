using System;
using System.IO;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Schnittstellen.Abacus.ASCII
{
    public partial class CtlAbaASCIIBase : KissUserControl
    {
        // Lock object for accessing logfile
        private static readonly object _writeLock = new object();

        public CtlAbaASCIIBase()
        {
            InitializeComponent();
        }

        protected static void AppendToFile(int schnittstellenCode, string fileToWrite, string appendText)
        {
            // THREAD SAFETY
            lock (_writeLock)
            {
                try
                {
                    // source: http://www.csharp-station.com/HowTo/ReadWriteTextFile.aspx

                    // validate first
                    if (!FileExists(fileToWrite))
                    {
                        // file not found
                        throw new Exception(string.Format("Error: File to write does not exist '{0}'.", fileToWrite));
                    }

                    // create a writer and open the file
                    TextWriter objTextWriter = new StreamWriter(fileToWrite, true);

                    // check if space only to write empty line
                    if (!DBUtil.IsEmpty(appendText))
                    {
                        // write a line of text to the file
                        objTextWriter.WriteLine("{0}", appendText);
                    }

                    // close the stream
                    objTextWriter.Close();
                }
                catch (Exception ex)
                {
                    // logging
                    InsertAbaLogDB(schnittstellenCode, null, null, ex, "Error: Writing to file has thrown an exception");

                    // stop only if debugger is attached
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        System.Diagnostics.Debugger.Break();
                    }

                    // throw exception further on
                    throw;
                }
            }
        }

        /// <summary>
        /// Combine folder with folder or folder with file as [folder\item]
        /// </summary>
        /// <param name="pstrFolder">Folder we want to use</param>
        /// <param name="pstrFile">Item (folder or file) we want to append to folder</param>
        /// <returns>Folder and item combined as [folder\item]</returns>
        protected static string CombineFolderWithItem(string pstrFolder, string pstrFile)
        {
            //validate first
            pstrFolder = pstrFolder.Trim();
            pstrFile = pstrFile.Trim();

            if (DBUtil.IsEmpty(pstrFolder) && DBUtil.IsEmpty(pstrFile))
            {
                //return nothing
                return "";
            }
            if (DBUtil.IsEmpty(pstrFolder))
            {
                return pstrFile;
            }

            if (DBUtil.IsEmpty(pstrFile))
            {
                return pstrFolder;
            }

            //check if folder ends with "\"
            if (pstrFolder.EndsWith(@"\") || pstrFile.StartsWith(@"\"))
            {
                //just append item
                return pstrFolder + pstrFile;
            }

            //append "\" and item
            return string.Format(@"{0}\{1}", pstrFolder, pstrFile);
        }

        /// <summary>
        /// Copy file from source to target
        /// </summary>
        /// <param name="pstrSourceFullPathFileName">Host, path and name of source file to copy</param>
        /// <param name="pstrTargetFullPathFileName">Host, path and name of target file to create/overwrite</param>
        /// <returns>True if success or already existing, false if could not create/overwrite file</returns>
        protected static bool CopyFile(string pstrSourceFullPathFileName, string pstrTargetFullPathFileName)
        {
            // validate input
            if (DBUtil.IsEmpty(pstrSourceFullPathFileName) || DBUtil.IsEmpty(pstrTargetFullPathFileName))
            {
                throw new Exception("The given parameters are invalid, cannot copy file");
            }

            // check if source file exists
            if (!FileExists(pstrSourceFullPathFileName))
            {
                // error, source file not found
                throw new Exception(string.Format("The sourcefile '{0}' does not exist, cannot copy file", pstrSourceFullPathFileName));
            }

            // create file info
            FileInfo objSourceFile = new FileInfo(pstrSourceFullPathFileName);

            // create or overwrite file
            objSourceFile.CopyTo(pstrTargetFullPathFileName, true);

            // check if success
            return FileExists(pstrTargetFullPathFileName);
        }

        /// <summary>
        /// Create new directory if not existing
        /// </summary>
        /// <param name="pstrFullPathName">Path including host and name of new directory to create</param>
        /// <returns>True if success or already existing, false if could not create folder</returns>
        protected static bool CreateDirectory(string pstrFullPathName)
        {
            // validate input
            if (DBUtil.IsEmpty(pstrFullPathName))
            {
                throw new ArgumentNullException("pstrFullPathName", "Der übergebene Wert ist ungültig, das Verzeichnis kann nicht erstellt werden.");
            }

            // check if existing already
            if (FolderExists(pstrFullPathName))
            {
                // we have it already
                return true;
            }

            // not found, try to create it
            Directory.CreateDirectory(pstrFullPathName);

            // check if success
            return FolderExists(pstrFullPathName);
        }

        /// <summary>
        /// Delete given file if exisitng
        /// </summary>
        /// <param name="pstrFilePathName">Path to file including filename and fileending</param>
        /// <returns>Boolean: True if successfully deleted file, else false</returns>
        protected static bool DeleteFile(string pstrFilePathName)
        {
            // validate string
            if (!DBUtil.IsEmpty(pstrFilePathName))
            {
                // check file exist
                if (FileExists(pstrFilePathName))
                {
                    // remove file
                    File.Delete(pstrFilePathName);

                    // check if success
                    if (FileExists(pstrFilePathName))
                    {
                        // error, could not delete file
                        return false;
                    }

                    // success, deleted file
                    return true;
                }

                // success, file does not exist
                return true;
            }

            // error, empty filepathname
            return false;
        }

        /// <summary>
        /// Check if a specific file does exist
        /// </summary>
        /// <param name="pstrFilePathName">The file path and name to check</param>
        /// <returns>True if file exists, otherwise false</returns>
        protected static bool FileExists(string pstrFilePathName)
        {
            // validate first
            pstrFilePathName = pstrFilePathName.Trim();

            if (DBUtil.IsEmpty(pstrFilePathName))
            {
                return false;
            }

            // check if file exists
            return File.Exists(pstrFilePathName);
        }

        /// <summary>
        /// Check if folder exists
        /// </summary>
        /// <param name="pstrFolderPath">Path to file without filename and fileending</param>
        /// <returns>boolean: true if file exists, else false</returns>
        protected static bool FolderExists(string pstrFolderPath)
        {
            // validate first
            pstrFolderPath = pstrFolderPath.Trim();
            if (DBUtil.IsEmpty(pstrFolderPath))
            {
                return false;
            }

            // check if folderexist
            return Directory.Exists(pstrFolderPath);
        }

        protected static DateTime GetFirstDayOfMonth(DateTime date, bool takeLastMonth)
        {
            // validate
            if (takeLastMonth)
            {
                // get current date and subtract one month
                date = DateTime.Today.AddMonths(-1);
            }

            // return first day of month
            return new DateTime(date.Year, date.Month, 1);
        }

        protected static DateTime GetLastDayOfMonth(DateTime date, bool takeLastMonth)
        {
            // validate
            if (takeLastMonth)
            {
                // get current date and subtract one month
                date = DateTime.Today.AddMonths(-1);
            }

            // get first day of month
            date = new DateTime(date.Year, date.Month, 1);

            // add one month
            date = date.AddMonths(1);

            // return first day of next month - 1 day = last day of current month
            return date.AddDays(-1);
        }

        protected static DateTime GetNextDatumVon(int mandantenNr, string schnittstellenTyp)
        {
            // validate first
            if (mandantenNr < 0 || DBUtil.IsEmpty(schnittstellenTyp))
            {
                throw new ArgumentOutOfRangeException(string.Format("Invalid parameters given, cannot continue (mandantenNr='{0}', schnittstellenTyp='{1}')!", mandantenNr, schnittstellenTyp));
            }

            // get value from database
            object nextPossibleDate = DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT dbo.fnBDEGetNextExportMonth({0}, {1})", mandantenNr, schnittstellenTyp);

            // check if we have a date
            if (nextPossibleDate == null)
            {
                throw new ArgumentOutOfRangeException("Invalid date received, cannot calulate first and last day of month (nextPossibleDate).");
            }

            // return value
            return GetFirstDayOfMonth(Convert.ToDateTime(nextPossibleDate), false);
        }

        protected static void InsertAbaLogDB(int schnittstellenCode, string paramIn, string paramOut, Exception exception, string remark)
        {
            // do logging
            DBUtil.ExecSQLThrowingException(@"
                INSERT INTO XAbaLog (UserID, LogDate, SchnittstellenCode, ParameterIn, ParameterOut, ExceptionMsg, Remark)
                VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6})", Session.User.UserID, DateTime.Now, schnittstellenCode, paramIn, paramOut, exception == null ? "" : exception.Message, remark);
        }
    }
}