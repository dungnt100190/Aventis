using System;
using System.IO;
using System.Linq;
using System.Reflection;

using C1.C1Zip;

using log4net;

namespace Kiss.Update
{
    public class UpdateService : PropertyChangedNotifier
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region Methods

        #region Public Methods

        public void BackupFiles(string updateDestination)
        {
            // we cannot move a directory to a subdirectory of itself, so we move the files and folders separately
            var backupDir = Path.Combine(updateDestination, Constants.BACKUP_FOLDER_NAME);
            if (Directory.Exists(backupDir))
            {
                ClearAttributes(backupDir);
                Directory.Delete(backupDir, true);
            }
            Directory.CreateDirectory(backupDir);

            MoveDirectoryContents(updateDestination, backupDir);
        }

        public void ClearAttributes(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory) || !Directory.Exists(directory))
            {
                return;
            }

            var files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
            }
        }

        /// <summary>
        /// Copies a file and reports progress.
        /// The method is not asynchronous!
        /// </summary>
        /// <param name="source">The source file name.</param>
        /// <param name="destination">The destination file name.</param>
        /// <param name="isCancelledFunction">A function that indicates whether the process should be cancelled.</param>
        /// <param name="progressCallback">A progress callback function. The value ranges from 0 to 100.</param>
        public void CopyFile(string source, string destination, Func<bool> isCancelledFunction, Action<int> progressCallback)
        {
            XCopy.Copy(source, destination, true, false, isCancelledFunction, (s, e) => progressCallback(e.ProgressPercentage));
        }

        public void DeleteFolderContents(string folder)
        {
            var subDirectories = Directory.GetDirectories(folder);
            ClearAttributes(folder);
            foreach (var file in Directory.GetFiles(folder))
            {
                File.Delete(file);
            }
            foreach (var dir in subDirectories)
            {
                var dirName = Path.GetFileName(dir);
                ClearAttributes(dirName);
                if (!string.IsNullOrWhiteSpace(dirName) && dirName != Constants.BACKUP_FOLDER_NAME)
                {
                    foreach (var file in Directory.GetFiles(Path.Combine(folder, dirName)))
                    {
                        //lösche alle bis auf config
                        if (!Constants.FilesToKeep.Any(x => x == file))
                        {
                            File.Delete(file);
                        }
                    }
                    foreach (var subfolder in Directory.GetDirectories(Path.Combine(folder, dirName)))
                    {
                        DeleteFolderContents(subfolder);
                        Directory.Delete(subfolder);
                    }
                    Directory.Delete(Path.Combine(folder, dirName));
                }
            }
        }

        public void ExtractZip(string tempZipFileName, string destinationFolder, Func<bool> isCancelledFunction, Action<int> progressCallback)
        {
            var zipFile = new C1ZipFile();
            zipFile.Open(tempZipFileName);

            _logger.Info("Extracting the directories first");
            var count = zipFile.Entries.Count;
            for (int i = 0; i < count; i++)
            {
                if (isCancelledFunction != null && isCancelledFunction())
                {
                    return;
                }

                var file = zipFile.Entries[i];
                var destFileName = Path.Combine(destinationFolder, file.FileName);

                if (file.Attributes.HasFlag(FileAttributes.Directory))
                {
                    _logger.InfoFormat("Extracting directory: {0}", destFileName);
                    Directory.CreateDirectory(destFileName);
                }
            }

            _logger.Info("Directories extracted");

            var percentageFactor = 100f / count;

            for (int i = 0; i < count; i++)
            {
                if (isCancelledFunction != null && isCancelledFunction())
                {
                    return;
                }

                var file = zipFile.Entries[i];
                var destFileName = Path.Combine(destinationFolder, file.FileName);

                if (!file.Attributes.HasFlag(FileAttributes.Directory))
                {
                    try
                    {
                        zipFile.Entries.Extract(i, destFileName);
                        File.SetAttributes(destFileName, FileAttributes.Normal);
                    }
                    catch (Exception ex)
                    {
                        _logger.InfoFormat("About to extract File: {0}", destFileName);
                        _logger.Error("Unexpected error while ExtractZip(): ", ex);
                        //2. Versuch (warum auch immer)
                        zipFile.Entries.Extract(i, destFileName);
                        File.SetAttributes(destFileName, FileAttributes.Normal);
                    }
                }

                if (progressCallback != null)
                {
                    progressCallback((int)(i * percentageFactor));
                }
            }
        }

        public bool IsFileLocked(string path)
        {
            FileStream stream = null;

            try
            {
                stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            //file is not locked
            return false;
        }

        public DateTime? ReadLocalUpdateTimeStamp()
        {
            try
            {
                using (var reader = new StreamReader(Constants.LOCAL_TS_FILE_NAME))
                {
                    long ticks;
                    if (long.TryParse(reader.ReadToEnd(), out ticks))
                    {
                        return new DateTime(ticks);
                    }
                }
            }
            catch
            {
                return null;
            }

            return null;
        }

        public void RestoreBackup(string updateDestination)
        {
            var backupDir = Path.Combine(updateDestination, Constants.BACKUP_FOLDER_NAME);
            DeleteFolderContents(updateDestination);
            MoveDirectoryContents(backupDir, updateDestination);

            //Lösche Configfile aus Backupordner
            foreach (var file in Directory.GetFiles(backupDir))
            {
                File.Delete(file);
            }
            Directory.Delete(backupDir);
        }

        public void UnBackupFiles(string updateDestination)
        {
            var backupDir = Path.Combine(updateDestination, Constants.BACKUP_FOLDER_NAME);
            if (Directory.Exists(backupDir))
            {
                ClearAttributes(backupDir);
                MoveDirectoryContents(backupDir, updateDestination);
                ClearAttributes(backupDir);
                Directory.Delete(backupDir, true);
            }
        }

        public void WriteLocalUpdateTimeStamp(string path, DateTime dateTime)
        {
            using (var writer = new StreamWriter(Path.Combine(path, Constants.LOCAL_TS_FILE_NAME)))
            {
                writer.Write(dateTime.Ticks);
            }
        }

        #endregion

        #region Private Methods

        private void MoveDirectoryContents(string source, string destination)
        {
            var subDirectories = Directory.GetDirectories(source);

            foreach (var dir in subDirectories)
            {
                var dirName = Path.GetFileName(dir);
                if (!string.IsNullOrWhiteSpace(dirName) && dirName != Constants.BACKUP_FOLDER_NAME)
                {
                    if (!Directory.Exists(Path.Combine(destination, dirName)))
                    {
                        var dest = Path.Combine(destination, dirName);

                        try
                        {
                            Directory.Move(dir, dest);
                        }
                        catch (Exception ex)
                        {
                            _logger.ErrorFormat("Error while moving directory: {0} to {1}: {2}", dir, dest, ex);
                        }
                    }
                }
            }

            var files = Directory.GetFiles(source);

            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);

                if (string.IsNullOrWhiteSpace(fileName))
                {
                    continue;
                }

                var destinationFileName = Path.Combine(destination, fileName);

                if (Constants.FilesToKeep.Any(x => x == fileName))
                {
                    try
                    {
                        File.Copy(file, destinationFileName, true);
                    }
                    catch (Exception ex)
                    {
                        _logger.ErrorFormat("Error while copying file: {0} to {1}: {2}", file, destinationFileName, ex);
                    }
                }
                else
                {
                    try
                    {
                        File.Move(file, destinationFileName);
                    }
                    catch (Exception ex)
                    {
                        _logger.ErrorFormat("Error while moving file: {0} to {1}: {2}", file, destinationFileName, ex);
                    }
                }
            }
        }

        #endregion

        #endregion
    }
}