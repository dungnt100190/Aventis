using System;
using System.IO;

namespace KiSS4.Dokument
{
    /// <summary>
    /// Listens to changes to the current document file and raises an event
    /// when the document has changed.
    /// </summary>
    internal class DocumentWatcher
        :
        IDisposable
    {
        #region Fields and Properties

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The file system watcher.
        /// </summary>
        private FileSystemWatcher watcher;

        /// <summary>
        /// The watch timer.
        /// </summary>
        private System.Timers.Timer watchTimer;

        /// <summary>
        /// The document that is watched.
        /// </summary>
        private FileInfo currentDocument;

        /// <summary>
        /// Indicates whether the file has been changed.
        /// </summary>
        private Boolean wasChanged;

        /// <summary>
        /// Indicates whether the watched file has been renamed.
        /// </summary>
        private Boolean wasRenamed;

        /// <summary>
        /// Indicates whether the watched file has been deleted.
        /// </summary>
        private Boolean wasDeleted;

        /// <summary>
        /// Indicates whether the watched file has been created.
        /// </summary>
        private Boolean wasCreated;

        #endregion

        #region Events

        /// <summary>
        /// Register to get informed when the file was changed/saved.
        /// </summary>
        public event System.EventHandler FileChanged;

        /// <summary>
        /// Register to get informed when the file was renamed. 
        /// </summary>
        public event System.EventHandler FileRenamed;

        /// <summary>
        /// Register to get informed when the file was deleted.
        /// </summary>
        public event System.EventHandler FileDeleted;

        /// <summary>
        /// Register to get informed when the file was created.
        /// </summary>
        public event System.EventHandler FileCreated;

        /// <summary>
        /// Inform registered users that the file has changed.
        /// </summary>
        private void OnFileChanged()
        {
            logger.Debug("OnFileChanged()");

            if (FileChanged != null)
            {
                FileChanged(this, EventArgs.Empty);
            }

            wasChanged = false;
        }

        /// <summary>
        /// Inform registered users that the file was renamed.
        /// </summary>
        private void OnFileRenamed()
        {
            logger.Debug("OnFileRenamed()");

            if (FileRenamed != null)
            {
                FileRenamed(this, EventArgs.Empty);
            }

            wasRenamed = false;
        }

        /// <summary>
        /// Inform registered users that the file was deleted.
        /// </summary>
        private void OnFileDeleted()
        {
            logger.Debug("OnFileDeleted()");

            if (FileDeleted != null)
            {
                FileDeleted(this, EventArgs.Empty);
            }

            wasDeleted = false;
        }

        private void OnFileCreated()
        {
            logger.Debug("OnFileCreated()");

            if (FileCreated != null)
            {
                FileCreated(this, EventArgs.Empty);
            }

            wasCreated = false;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentWatcher"/> class.
        /// </summary>
        /// <param name="fileInfo">The file info.</param>
        public DocumentWatcher(FileInfo fileInfo)
        {
            logger.DebugFormat("Start DocumentWatcher {0}", fileInfo.FullName);

            Initialize(fileInfo);
        }

        #endregion

        #region watcher Event Handler

        /// <summary>
        /// Handles the Changed event of the watcher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.IO.FileSystemEventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// With some applications, such as Notepad.exe the saved event is fired twice.
        /// The watchTimer solves this issue by merging multiple events of the same type
        /// into one.
        /// </remarks>
        private void watcher_Changed(Object sender, FileSystemEventArgs e)
        {
            if (disposed)
            {
                return;
            }

            // logging
            logger.DebugFormat("The file [{0}] was changed.", this.currentDocument.FullName);

            wasChanged = true;

            if (watchTimer != null)
            {
                watchTimer.Start();
            }
        }

        /// <summary>
        /// Handles the Renamed event of the watcher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.IO.RenamedEventArgs"/> instance containing the event data.</param>
        private void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (disposed)
            {
                return;
            }

            logger.DebugFormat("Rename {0} in {1}", e.OldFullPath, e.FullPath);

            // --- make sure the renamed event comes from the observated file
            //     excel need two renamings to save a document
            if (e.FullPath.Equals(this.currentDocument.FullName, StringComparison.CurrentCulture))
            {
                wasRenamed = true;
                watchTimer.Start();
            }
        }

        /// <summary>
        /// Handles the Deleted event of the watcher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.IO.FileSystemEventArgs"/> instance containing the event data.</param>
        private void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (disposed)
            {
                return;
            }

            // logging
            logger.DebugFormat("File [{0}] has been deleted from disk", e.FullPath);

            wasDeleted = true;

            if (watchTimer != null)
            {
                watchTimer.Start();
            }
        }

        /// <summary>
        /// Handles the Created event of the watcher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.IO.FileSystemEventArgs"/> instance containing the event data.</param>
        private void watcher_Created(object sender, FileSystemEventArgs e)
        {
            if (disposed)
            {
                return;
            }

            // logging
            logger.DebugFormat("File [{0}] has been created on disk", e.FullPath);
            wasCreated = true;
        }

        #endregion

        #region watchTimer Event Handler

        /// <summary>
        /// Handles the Elapsed event of the watchTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private void watchTimer_Elapsed(
            Object sender,
            System.Timers.ElapsedEventArgs e)
        {
            logger.DebugFormat("watchTimer_Elapsed()");

            if (wasChanged)
            {
                OnFileChanged();
            }

            if (wasRenamed)
            {
                OnFileRenamed();
            }

            if (wasDeleted)
            {
                OnFileDeleted();
            }

            if (wasCreated)
            {
                OnFileCreated();
            }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Inits the file watch.
        /// </summary>
        /// <param name="fileInfo">The file.</param>
        private void Initialize(FileInfo fileInfo)
        {
            currentDocument = fileInfo;
            watcher = new FileSystemWatcher();
            watchTimer = new System.Timers.Timer();

            // --- Initialize Timer to postpone save
            watchTimer.SynchronizingObject = DB.Session.MainForm;
            watchTimer.AutoReset = false;
            watchTimer.Interval = 200; //500
            watchTimer.Elapsed += watchTimer_Elapsed;

            // --- Initialize FileWatcher
            watcher.Path = fileInfo.DirectoryName + @"\";
            watcher.Filter = fileInfo.Name;
            watcher.SynchronizingObject = DB.Session.MainForm;  // We want the FileSystemWatch events to be marshaled through the main GUI thread (this is not optimal for performance, but it's a safety measure)
            watcher.IncludeSubdirectories = false;
            watcher.InternalBufferSize *= 5;                    // Ensure that we have enough buffer size for the events
            //#5323: no more like that: watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Size | NotifyFilters.FileName;
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watcher.Changed += watcher_Changed;
            watcher.Renamed += watcher_Renamed;
            watcher.Deleted += watcher_Deleted;
            watcher.Created += watcher_Created;
            watcher.EnableRaisingEvents = true;

            logger.DebugFormat("DocumentWatcher initialized on file [{0}]", fileInfo.FullName);
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Indicates whether this instance has been disposed before.
        /// </summary>
        private Boolean disposed;

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations
        /// before the <see cref="Zip"/> is reclaimed by garbage collection.
        /// </summary>
        ~DocumentWatcher()
        {
            logger.DebugFormat("DocumentWatcher on {0} is being garbage collected.", currentDocument.FullName);
            this.Dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and
        /// unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(Boolean disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DisposeManagedResources();
                }

                disposed = true;
            }
        }

        /// <summary>
        /// Disposes the managed resources.
        /// </summary>
        private void DisposeManagedResources()
        {
            if (this.watchTimer != null)
            {
                this.watchTimer.Dispose();
                this.watchTimer = null;
                if (wasChanged)
                {
                    OnFileChanged();
                }
                if (wasRenamed)
                {
                    OnFileRenamed();
                }
            }
            if (this.watcher != null)
            {
                this.watcher.EnableRaisingEvents = false;
                this.watcher.Changed -= watcher_Changed;
                this.watcher.Renamed -= watcher_Renamed;
                this.watcher.Deleted -= watcher_Deleted;
                this.watcher.Created -= watcher_Created;

                this.watcher.Dispose();
                this.watcher = null;
            }
        }

        #endregion
    }
}
