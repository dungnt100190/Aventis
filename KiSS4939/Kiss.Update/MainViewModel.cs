using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows;

using log4net;

namespace Kiss.Update
{
    public class MainViewModel : PropertyChangedNotifier
    {
        #region Fields

        #region Private Static Fields

        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly BackgroundWorker _backgroundWorker;

        #endregion

        #region Private Fields

        private bool _isCancelButtonEnabled;
        private int _progress;
        private string _updateDestination;
        private string _updateSource;
        private string _mainFileName;

        #endregion

        #endregion

        #region Constructors

        public MainViewModel()
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.WorkerSupportsCancellation = true;
            _backgroundWorker.DoWork += BackgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        #endregion

        #region Events

        public event MessageEventHandler MessageRaised;

        public event ProcessCompletedEventHandler ProcessCompleted;

        #endregion

        #region Properties

        public bool IsCancelButtonEnabled
        {
            get { return _isCancelButtonEnabled; }
            set { SetValue(ref _isCancelButtonEnabled, value, () => IsCancelButtonEnabled); }
        }

        public int Progress
        {
            get { return _progress; }
            set { SetValue(ref _progress, value, () => Progress); }
        }

        private bool IsCancelled
        {
            get { return _backgroundWorker.CancellationPending; }
        }

        #endregion

        #region EventHandlers

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var service = new UpdateService();
            string tempZipFileName = null;

            try
            {
                _logger.DebugFormat("KiSS-Update gestartet in {0}.", AppDomain.CurrentDomain.BaseDirectory);
                _logger.DebugFormat("UpdateSource: {0}", _updateSource);
                _logger.DebugFormat("UpdateDestination: {0}", _updateDestination);
                _logger.DebugFormat("MainFileName: {0}", _mainFileName);

                // check if the main exe is locked
                bool isLocked;

                do
                {
                    isLocked = service.IsFileLocked(Path.Combine(_updateDestination, _mainFileName));
                }
                while (isLocked &&
                       OnMessageRaised(
                           "Das Update konnte nicht ausgeführt werden. Bitte beenden Sie alle KiSS-Instanzen und klicken Sie zum Wiederholen auf 'OK'.",
                           "Fehler beim Update von KiSS",
                           MessageBoxButton.OKCancel) == MessageBoxResult.OK);

                if (isLocked)
                {
                    // the user pressed cancel
                    _logger.Info("KiSS läuft noch; Abbruch auf Kundenwunsch.");
                    CancelAsync();
                    return;
                }

                IsCancelButtonEnabled = true;

                // download ZIP
                tempZipFileName = Path.GetTempFileName();
                service.CopyFile(_updateSource, tempZipFileName, () => IsCancelled, p => Progress = (int)(p / 2f));

                if (IsCancelled)
                {
                    return;
                }

                bool doBackup = true;
                // create backup of installation
                do
                {
                    try
                    {
                        service.BackupFiles(_updateDestination);
                        doBackup = false;
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Fehler beim Backup.", ex);

                        MessageBoxResult result =
                            OnMessageRaised(
                                "Das Update konnte nicht ausgeführt werden. Bitte beenden Sie alle KiSS-Instanzen und klicken Sie anschliessend auf 'OK'. Klicken Sie auf 'Abbrechen', um KiSS normal zu starten.",
                                "Fehler beim Update von KiSS",
                                MessageBoxButton.OKCancel);

                        if (result == MessageBoxResult.Cancel)
                        {
                            //Kiss already started, move files from backupdir back to updateDestination
                            service.UnBackupFiles(_updateDestination);
                            _logger.Info("Abbruch auf Kundenwunsch.");
                            CancelAsync();
                            return;
                        }
                    }
                }
                while (doBackup);

                if (IsCancelled)
                {
                    IsCancelButtonEnabled = false;
                    service.RestoreBackup(_updateDestination);
                    return;
                }
                try
                {
                    service.ExtractZip(tempZipFileName, _updateDestination, () => IsCancelled, p => Progress = 50 + (int)(p / 2f));
                    IsCancelButtonEnabled = false;
                }
                catch (Exception ex)
                {
                    _logger.Error("Fehler in ExtractZip: ", ex);
                    service.RestoreBackup(_updateDestination);
                    OnMessageRaised(
                        "Beim Entpacken der neuen Version ist ein Fehler aufgetreten. Die vorherige Version wurde wiederhergestellt.", null, MessageBoxButton.OK);
                    CancelAsync();
                    return;
                }

                if (IsCancelled)
                {
                    service.RestoreBackup(_updateDestination);
                }
                else
                {
                    service.WriteLocalUpdateTimeStamp(_updateDestination, new FileInfo(_updateSource).LastWriteTimeUtc);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Unerwarteter Fehler.", ex);

                if (IsCancelled)
                {
                    // we expect a Win32Exception here..
                    return;
                }
                throw;
            }
            finally
            {
                e.Cancel = IsCancelled;

                if (tempZipFileName != null)
                {
                    File.Delete(tempZipFileName);
                }
                //Lösche Backupordner samt Inhalt, falls noch vorhanden
                var backupDir = Path.Combine(_updateDestination, Constants.BACKUP_FOLDER_NAME);

                if (Directory.Exists(backupDir))
                {
                    service.DeleteFolderContents(backupDir);
                    Directory.Delete(backupDir, true);
                }
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Progress = 100;

            if (ProcessCompleted != null)
            {
                ProcessCompleted(this, new ProcessCompletedEventArgs(e.Error, e.Cancelled));
            }

            _logger.Debug("KiSS-Update beendet.");
        }

        #endregion

        #region Methods

        #region Public Methods

        public void CancelAsync()
        {
            if (_backgroundWorker.IsBusy)
            {
                _backgroundWorker.CancelAsync();
            }
        }

        public void RunAsync(string updateSource, string updateDestination, string mainFileName)
        {
            if (!_backgroundWorker.IsBusy)
            {
                Progress = 0;
                _updateSource = updateSource;
                _updateDestination = updateDestination;
                _mainFileName = mainFileName;
                _backgroundWorker.RunWorkerAsync();
            }
        }

        #endregion

        #region Private Methods

        private MessageBoxResult OnMessageRaised(string message, string title, MessageBoxButton buttons)
        {
            _logger.InfoFormat("Message: {0} - {1}", title, message);

            var e = new MessageEventArgs(message, title, buttons);

            if (MessageRaised != null)
            {
                MessageRaised(this, e);
            }

            return e.Result;
        }

        #endregion

        #endregion
    }
}