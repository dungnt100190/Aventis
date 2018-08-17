using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading;

using KiSS4.DB;

namespace KiSS4.Dokument
{
    internal class ProcessLauncher : IDisposable
    {
        #region Fields

        #region Public Fields

        /// <summary>
        /// Delete the file after watching.
        /// </summary>
        public Boolean deleteTheFileAfterWatching = true;

        /// <summary>
        /// The process is locking the document.
        /// </summary>
        public Boolean processIsLockingDocument = false;

        #endregion

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// Interval between checking the file for file access or process activity in milli seconds. 
        /// Accelerated state when file seems saved, but not surely is.
        /// Set as file watcher interval
        /// </summary>
        /// !!! please do not change without changing message in XDocument.DocumentIsStillInUse !!!
        private const int acceleratedSaveInterval = 200; // milli seconds

        /// <summary>
        /// Interval between checking the file for file access or process activity in milli seconds. 
        /// Normal state when startet.
        /// </summary>
        /// TODO : probably can be made faster by setting to 200, but must be tested first
        private const int normalSaveInterval = 1000; // milli seconds

        /// <summary>
        /// Total looping count, leads to a maximal loop time of 3 seconds. 
        /// </summary>
        /// probably can be made faster by setting to 1 or 2, but must be tested first
        /// 03.09.2009 : NO, observations showed: in some cases with Citrix 3-4 loops were needed
        /// in order to be on a secure side, we rised the loop count from 5 to 8 (2.4 seconds instead of 1)
        /// !!! please do not change without changing message in XDocument.DocumentIsStillInUse !!!
        /// 21.02.2011: We changed count from 8 to 20. Many clients (ZH, BSS and SRK) did have problems:
        /// Document was not saved.
        private const int totalRepeatingLoopCount = 20; // loops

        #endregion

        #region Private Fields

        private DateTime _nextStillInUseLogMsg;

        /// <summary>
        /// Provides information about the current document.
        /// </summary>
        private FileInfo currentDocument;

        /// <summary>
        /// Indicates whteher this instance has been disposed before.
        /// </summary>
        private Boolean disposed;

        /// <summary>
        /// External process.
        /// </summary>
        private Process extProcess;

        /// <summary>
        /// Provides information about the current document
        /// </summary>
        private Boolean fileIsWritable = false;

        /// <summary>
        /// Indicates if the file was saved during special loops
        /// </summary>
        private Boolean fileWasSavedInSpecialLoops = false;

        /// <summary>
        /// Flag for special loops before stopping watching
        /// </summary>
        private Boolean hasPendingStop = false;

        /// <summary>
        /// Its a file opened either in word or in excel.
        /// </summary>
        private Boolean isWordOrExcelDocument = false;

        /// <summary>
        /// Actual count of special loops
        /// </summary>
        private int pendingStoppCounts = 0;

        /// <summary>
        /// Save timer.
        /// </summary>
        private System.Timers.Timer saveTimer;

        /// <summary>
        /// External process.
        /// </summary>
        private Boolean saveTimerIsRunning = false;

        /// <summary>
        /// Process names, which are locking documents.
        /// </summary>
        private string strProcessesLockingDocuments = "";

        /// <summary>
        /// Process names, which are NOT locking documents.
        /// </summary>
        private string strProcessesNotLockingDocuments = "";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessLauncher"/> class.
        /// </summary>
        public ProcessLauncher(FileInfo currentDocument, bool isWordOrExcel, bool isWritable)
        {
            logger.DebugFormat("Start ProcessWatcher for {0}", currentDocument);

            // gets the string with all locking document EXEs
            strProcessesLockingDocuments = GetAllLockingDocumentEXEs();
            // gets the string with all not locking document EXEs
            strProcessesNotLockingDocuments = GetAllNotLockingDocumentEXEs();

            this.currentDocument = currentDocument;
            this.isWordOrExcelDocument = isWordOrExcel;

            // word or excel are locking the documents
            // this has to be set here, because its value is used right from the watcher start
            this.processIsLockingDocument = isWordOrExcel;

            // normally the file can be deleted
            deleteTheFileAfterWatching = true;

            // TRUE if the file is writable and special loops have to be made
            this.fileIsWritable = isWritable;

            pendingStoppCounts = 0;
            hasPendingStop = false;
            fileWasSavedInSpecialLoops = false;

            InitProcessWatcher();
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="Zip"/> is reclaimed by garbage collection.
        /// </summary>
        ~ProcessLauncher()
        {
            this.Dispose(false);
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            logger.Debug("enter");

            this.Dispose(true);
            GC.SuppressFinalize(this);

            logger.Debug("done");
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(Boolean disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.DisposeManagedResources();
                }

                disposed = true;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [process exited].
        /// </summary>
        public event System.EventHandler ProcessExited;

        #endregion

        #region Properties

        /// <summary>
        /// Indicates if the file was saved during special loops
        /// </summary>
        public Boolean FileWasSavedInSpecialLoops
        {
            get { return fileWasSavedInSpecialLoops; }
            set { fileWasSavedInSpecialLoops = value; }
        }

        /// <summary>
        /// Flag for special loops before stopping watching
        /// </summary>
        public Boolean HasPendingStop
        {
            get { return hasPendingStop; }
        }

        /// <summary>
        /// The process is still active.
        /// </summary>
        public Boolean ProcessWatcherIsStillActive
        {
            get
            {
                if (this.saveTimer == null) return false;
                return this.saveTimerIsRunning;
            }
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Handles the Elapsed event of the saveTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        protected void saveTimer_Elapsed(Object sender, System.Timers.ElapsedEventArgs e)
        {
            if (currentDocument == null)
            {
                logger.Info("saveTimer_Elapsed: currentDocument is null");
                System.Diagnostics.Debug.WriteLine("CurrentDocument is null");
                this.OnProcessExited();
                return;
            }

            try
            {
                // Open File in exclusive mode. If failed it will be used from another application.
                if (this.processIsLockingDocument)
                {
                    // if the process is locking the opened file, this will throw an IO exception:
                    this.currentDocument.Open(FileMode.Open, FileAccess.Read, FileShare.None).Close();

                    // No exception ocurred, so KISS will stop the watcher and delete the file immediately
                    // with Citrix, probably this causes problems in about 10% of all cases
                    // Word is renaming files, if this is too slow, files may be unlocked for short instances
                    // KISS may interprete this as "all is ok" and will delete the file
                    // we try to resolve the problem by waiting here

                    // flag: KISS wants to stop watching,
                    // but we wait a little more for possible document watcher reactions
                    if (fileWasSavedInSpecialLoops)
                    {
                        // ufff, file was saved mean while, so we can leave watching by doing nothing
                        // we detected a problem: KISS wanted to stop watching before file really was saved
                        logger.Warn("saveTimer_Elapsed: error detected: file was saved in special loops");

                        //do the same thing as when file is observed to be still in use (see the catch(IOException)-block)

                        // file is observed to be in use, so cancel any pending stoppings
                        hasPendingStop = false;
                        fileWasSavedInSpecialLoops = false;

                        // restart the timer
                        RestartTimerWatching();

                        // continue watching
                        return;
                    }
                    else if (fileIsWritable)
                    {
                        // we do only wait in specail loops, when the file is writable
                        if (hasPendingStop == false)
                        {
                            // starting special loops
                            hasPendingStop = true;
                            pendingStoppCounts = 0;
                            fileWasSavedInSpecialLoops = false;

                            // in order to continue watching
                            throw new KissInfoException("special loops started 0");
                        }
                        else
                        {
                            //continue loops
                            pendingStoppCounts += 1;
                        }

                        if (pendingStoppCounts > totalRepeatingLoopCount)
                        {
                            // we could not observe any saving, but we have to leave once anyway
                            logger.Info("saveTimer_Elapsed: file is no more in use, total loop count reached");
                            hasPendingStop = false;
                            // do nothing here, in order to leave watching
                        }
                        else
                        {
                            // in order to continue watching
                            throw new KissInfoException(
                                string.Format("special loops started {0}", this.pendingStoppCounts)
                            );
                        }
                    }
                    // if the file is not writable, we leave immadiately watching
                    // do nothing here, in order to leave watching
                }
                else
                {
                    // the process is not locking the opened file, e.g. notepad.exe
                    // so we only can delete the file, when the process is not active or
                    // the corresponding window is no mor avaiable
                    if (extProcess != null)
                    {
                        if (!extProcess.HasExited)
                        {
                            // the process is still running, so we have to continue watching
                            throw new KissInfoException("process is still active");
                        }
                        else
                        {
                            // here we have to wait, until the document is saved
                            // if not, the document is deleted an cannot be saved any more
                            // try: edit in e.g. notepad.exe, then close notepad and
                            // answer "YES" when you're asked, if you want to save the file
                            logger.Info("saveTimer_Elapsed: the process is stopped");
                        }
                    }
                    // else :
                    // we leave the watching process (by doing nothing here)
                }
            }
            catch (FileNotFoundException ex)
            {
                logger.Warn("saveTimer_Elapsed: file not found", ex);
            }
            catch (IOException)
            {
                // debuging only each 10 seconds
                if (DateTime.Now >= _nextStillInUseLogMsg)
                {
                    _nextStillInUseLogMsg = DateTime.Now.AddSeconds(10);
                    logger.Info(string.Format("saveTimer_Elapsed: File: {0} is still in use.", currentDocument.FullName));
                }

                if (hasPendingStop)
                {
                    // we detected a problem: KISS wanted to stop watching before file really was not in use anymore
                    logger.Warn("saveTimer_Elapsed: error detected: tried to stop watching before file really was not in use anymore");
                }

                // file is observed to be in use, so cancel any pending stoppings
                hasPendingStop = false;
                fileWasSavedInSpecialLoops = false;

                // restart the timer
                RestartTimerWatching();

                // continue watching
                return;
            }
            catch (KissInfoException ex)
            {
                // debuging
                logger.Info("saveTimer_Elapsed: " + ex.Message);

                // restart the timer
                RestartTimerWatching();

                // continue watching
                return;
            }
            catch (Exception ex)
            {
                logger.Warn("saveTimer_Elapsed: unknown exception", ex);
            }

            this.OnProcessExited();
        }

        /// <summary>
        /// Handles the Exited event of the extProcess control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void extProcess_Exited(Object sender, EventArgs e)
        {
            // do not implement "this.OnProcessExited();" here,
            // because this will shut down the processwatcher without saving the file before
            // this could be observed with NOETPAD, when editing a file, closing it without saving
            // and answering YES in the closing event
            //this.OnProcessExited();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Informs registered entities about process exit.
        /// </summary>
        public void OnProcessExited()
        {
            logger.Info("OnProcessExited");
            StopWatching();

            if (ProcessExited != null)
            {
                ProcessExited(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <param name="readWrite">if set to <c>true</c> [read write].</param>
        /// <param name="startInfoVerb">The start info verb.</param>
        /// <returns></returns>
        public bool OpenFile(bool readWrite, string startInfoVerb)
        {
            return OpenFile(readWrite, startInfoVerb, null);
        }

        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <param name="readWrite">if set to <c>true</c> [read write].</param>
        /// <param name="startInfoVerb">The start info verb.</param>
        /// <param name="arguments">Any arguments to pass to the forked process.</param>
        /// <returns></returns>
        public bool OpenFile(bool readWrite, string startInfoVerb, string arguments)
        {
            // logging
            logger.DebugFormat("OpenFile called: readWrite='{0}', startInfoVerb='{1}'", readWrite, startInfoVerb);

            Process p = new Process();
            p.StartInfo.Verb = startInfoVerb;
            if (!string.IsNullOrEmpty(arguments))
            {
                p.StartInfo.Arguments = arguments;
            }

            return OpenFile(p, readWrite);
        }

        /// <summary>
        /// Stops the timer of the watcher.
        /// </summary>
        public void StopWatching()
        {
            logger.Info("saveTimer_Elapsed: watching is stopped");
            if (saveTimer != null) saveTimer.Stop();
            saveTimerIsRunning = false;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <param name="readWrite">if set to <c>true</c> [read write].</param>
        /// <returns></returns>
        protected bool OpenFile(Process p, bool readWrite)
        {
            logger.Info("OpenFile: starting");

            // normally the file can be deleted
            deleteTheFileAfterWatching = true;

            // normally the process is locking the document
            processIsLockingDocument = true;

            // file is wrtable
            fileIsWritable = readWrite;
            pendingStoppCounts = 0;
            hasPendingStop = false;
            fileWasSavedInSpecialLoops = false;

            // open the file with ShellExecute
            extProcess = p;
            extProcess.StartInfo.UseShellExecute = true;
            extProcess.StartInfo.FileName = this.currentDocument.FullName;
            extProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            extProcess.Start();

            logger.Info("external process started");

            // check why file was removed after call extProcess.Start() above
            if (!File.Exists(this.currentDocument.FullName))
            {
                // show info message
                KissMsg.ShowInfo(
                    "ProcessLauncher",
                    "OpenFileFileNotFound_v01",
                    "Die gewünschte Datei ist nicht mehr lokal vorhanden und kann deshalb möglicherweise nicht korrekt geöffnet werden.");

                // logging
                logger.InfoFormat(
                    "OpenFile: Local file does not exist anymore (file: '{0}')!",
                    this.currentDocument.FullName
                    );
            }

            try
            {
                // identify the process by ProcessName
                var pName = extProcess.ProcessName.ToUpper();

                // waiting until the application is ready, not not remove
                // if not, the file could be removed to quickly
                extProcess.WaitForInputIdle(-1);

                logger.InfoFormat("waited for external process {0} to become idle", pName);

                if (!isWordOrExcelDocument)
                {
                    // when its is wether WORD nor EXCEL it could be an application not locking the opened file
                    // so we only do this in case of other EXEs
                    if (this.strProcessesLockingDocuments.Contains(";" + pName + ";"))
                    {
                        // these processes work as WORD and EXCEL
                        processIsLockingDocument = true;
                    }
                    else if (this.strProcessesNotLockingDocuments.Contains(";" + pName + ";"))
                    {
                        // these processes can be observed by their flag "HasExited"
                        processIsLockingDocument = false;
                    }
                    else
                    {
                        // all other cases are not known/defined yet
                        processIsLockingDocument = false;
                    }
                }
            }
            catch (Exception ex)
            {
                // e.g. for ZIP files, no process is assigned and files are not locked
                // in this case we cannot observe the process
                // could be resolved to define another ZIP main module
                // setting processIsLockingDocument = true will stop the watching immediately,
                // because the file is not in use for ZIP files
                processIsLockingDocument = true;

                // we let the process enough time to open the file,
                // because the file will be deleted immediately
                deleteTheFileAfterWatching = false;

                logger.InfoFormat("failed to identify the process: {0}", ex.Message);

                // waiting 1 seconds, do not remove
                // if not, the file could be removed to quickly
                Thread.Sleep(1000);
            }

            // TODO GF Solve Problem (Exit Event doesn't work with Context, Mozilla, RealPlayer etc... works with word, excel, wordpad, pdf) Framework bug ?
            // view : http://www.dotnet247.com/247reference//msgs/5/26379.aspx

            AttachProcessWatch(extProcess);

            return true;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Attaches the process watch.
        /// </summary>
        /// <param name="p">The active process</param>
        /// <returns></returns>
        private bool AttachProcessWatch(Process p)
        {
            // set the current process, determinded by ShellExecute
            extProcess = p;

            try
            {
                if (!extProcess.HasExited)
                {
                    extProcess.WaitForInputIdle(1000);

                    extProcess.Exited -= new EventHandler(extProcess_Exited);
                    extProcess.Exited += new EventHandler(extProcess_Exited);
                    extProcess.EnableRaisingEvents = true;

                    logger.Info("AttachProcessWatch: process started");
                    return true;
                }
                logger.Info("AttachProcessWatch: process has already exited");
            }
            catch (InvalidOperationException ex)
            {
                logger.Warn("AttachProcessWatch: InvalidOperationException, no process created (e.g. ZIP files)", ex);
            }

            // does not make sense: e.g. for ZIP files, because no process is determined
            // so this would let the watcher work indefinitely
            // to prevent an endless loop, we better stop the watching immediately
            //InitProcessWatcher();

            return false;
        }

        /// <summary>
        /// Disposes the managed resources.
        /// </summary>
        private void DisposeManagedResources()
        {
            if (this.saveTimer != null)
            {
                this.saveTimer.Stop();
                saveTimerIsRunning = false;
                this.saveTimer.Dispose();
                this.saveTimer = null;
            }
        }

        /// <summary>
        /// Gets all pocesses which are locking documents.
        /// </summary>
        private string GetAllLockingDocumentEXEs()
        {
            // read all defined EXEs from AppConfigFile
            // Example : ";OUTLOOK;ACRORD32;WINWORD;"
            String tmpResult = "";
            try
            {
                AppSettingsReader asr = new AppSettingsReader();
                tmpResult = Convert.ToString(asr.GetValue("LockingDocumentEXEs", typeof(String)));
            }
            catch
            {
                tmpResult = "";
            }
            // do not remove ";" at start and end !!!
            if (tmpResult == "") tmpResult = ";OUTLOOK;ACRORD32;WINWORD;MSPVIEW;";

            // check for correct format
            if (!tmpResult.StartsWith(";")) tmpResult = ";" + tmpResult;
            if (!tmpResult.EndsWith(";")) tmpResult = tmpResult + ";";

            return tmpResult;
        }

        /// <summary>
        /// Gets all pocesses which are not locking documents.
        /// </summary>
        private string GetAllNotLockingDocumentEXEs()
        {
            // read all defined EXEs from AppConfigFile
            // Example : ";OUTLOOK;ACRORD32;WINWORD;"
            String tmpResult = "";
            try
            {
                AppSettingsReader asr = new AppSettingsReader();
                tmpResult = Convert.ToString(asr.GetValue("NotLockingDocumentEXEs", typeof(String)));
            }
            catch
            {
                tmpResult = "";
            }
            if (tmpResult == "") tmpResult = ";IEXPLORE;NOTEPAD;";

            // check for correct format
            if (!tmpResult.StartsWith(";")) tmpResult = ";" + tmpResult;
            if (!tmpResult.EndsWith(";")) tmpResult = tmpResult + ";";

            return tmpResult;
        }

        /// <summary>
        /// Inits the process watch.
        /// </summary>
        private void InitProcessWatcher()
        {
            logger.Info("InitProcessWatcher: process watcher started");
            saveTimerIsRunning = false;

            this.saveTimer = new System.Timers.Timer();
            this.saveTimer.SynchronizingObject = DB.Session.MainForm;
            this.saveTimer.AutoReset = false;

            this.saveTimer.Interval = normalSaveInterval;
            this.saveTimer.Elapsed += saveTimer_Elapsed;

            this.saveTimer.Start();
            saveTimerIsRunning = true;
        }

        /// <summary>
        /// Restarts the timer
        /// </summary>
        private void RestartTimerWatching()
        {
            // the file is used by another process or the process is still active
            if (saveTimer != null)
            {
                saveTimer.Interval = (hasPendingStop) ? acceleratedSaveInterval : normalSaveInterval;
            }
            else
            {
                logger.Warn("saveTimer_Elapsed: save timer is null");
            }
        }

        #endregion

        #endregion
    }
}