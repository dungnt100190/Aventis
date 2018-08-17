using System;
using System.IO;
using C1.C1Zip;
using Kiss.Infrastructure.IO;
using KiSS4.DB;
using KiSS4.Dokument.Utilities;

namespace KiSS4.Dokument
{
    /// <summary>
    /// Provides Methods to compress an decompress data and contains some helper functions to simply the file access.
    /// </summary>
    internal static class Zip
    {
        #region Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Public Methods

        /// <summary>
        /// Compress content of a file
        /// </summary>
        /// <param name="fileName">name of the File</param>
        /// <returns>Compressed data in a byte array</returns>
        public static byte[] CompressData(string fileName)
        {
            return CompressData(new FileInfo(fileName));
        }

        /// <summary>
        /// Compress content of a file
        /// </summary>
        /// <param name="file">FileInfo of the File</param>
        /// <returns>Compressed data in a byte array</returns>
        public static byte[] CompressData(FileInfo file)
        {
            try
            {
                using (Stream fs = file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        if (!Session.IsKiss5Mode)
                        {
                            // attach compressor stream to the stream
                            using (C1ZStreamWriter sw = new C1ZStreamWriter(ms))
                            {
                                StreamCopy(fs, sw);
                                sw.Close();
                            }
                        }
                        else
                        {
                            // Im KiSS-Modus Dok nicht komprimieren (für Fulltext-Index)
                            StreamCopy(fs, ms);
                        }

                        return ms.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                // logging
                logger.Warn("zip failed, file possibly has been deleted on file system", ex);

                // throw exception to show message
                throw new ZipException(KissMsg.GetMLMessage("Zip",
                                                            "ZipFailedMessage",
                                                            "Die Datei konnte nicht komprimiert werden. Möglicherweise wurde das Dokument in der Zwischenzeit lokal gelöscht."), ex);
            }
        }

        /// <summary>
        /// Creates a file path based on the filename, the extension and the
        /// path to the teporary directory.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="extension">The extension.</param>
        /// <returns></returns>
        public static String CreateFullName(String filename, String extension)
        {
            extension = FixExtension(extension);

            String tempPath = Path.Combine(Path.GetTempPath(), "KiSS");
            String fullName = "";

            // We either use the configured path (if available), or we use a temporary path
            try
            {
                fullName = DBUtil.GetConfigString(@"System\Dokumentemanagement\Temporaerpfad", tempPath);

                if (!Directory.Exists(fullName))
                {
                    // Create the directory as it does not exist yet.
                    Directory.CreateDirectory(fullName);
                }
            }
            catch //(Exception ex)
            {
                // Didn't like this, so let's use the temporary path instead then
                fullName = tempPath;
            }

            // And add the filename with extension to the path and then return the whole thing
            fullName = Path.Combine(fullName, filename + extension);

            return fullName;
        }

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="currentDocument">The current document.</param>
        /// <returns></returns>
        public static Boolean DeleteFile(FileInfo currentDocument)
        {
            // document can only be deleted if not empty
            if (currentDocument == null)
            {
                return true;
            }

            FileAttributes attr = currentDocument.Attributes;

            try
            {
                currentDocument.Attributes &= ~FileAttributes.ReadOnly;
                currentDocument.Delete();

                return true;
            }
            catch (Exception ex)
            {
                // logging
                logger.Warn("error deleting file", ex);

                try
                {
                    if (currentDocument.Exists)
                    {
                        currentDocument.Attributes = attr;
                    }
                }
                catch (Exception exsub)
                {
                    logger.Warn("error occured while trying to access document in exception handling", exsub);
                }
            }

            return false;
        }

        /// <summary>
        /// Expands byte array in specified file
        /// </summary>
        /// <param name="CompressedData"></param>
        /// <param name="file"></param>
        public static void ExpandDataToFile(byte[] CompressedData, FileInfo file)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(CompressedData))
                {
                    using (C1ZStreamReader sr = new C1ZStreamReader(ms))
                    {
                        var directory = Path.GetDirectoryName(file.FullName);

                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        using (FileStream fs = new FileStream(file.FullName, FileMode.Create, FileAccess.Write))
                        {
                            StreamCopy(sr, fs);
                            fs.Close();
                        }

                        sr.Close();
                    }

                    ms.Close();
                }
            }
            catch (Exception ex2)
            {
                try
                {
                    using (var ms = new MemoryStream(CompressedData))
                    {
                        var directory = Path.GetDirectoryName(file.FullName);

                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        using (var fs = new FileStream(file.FullName, FileMode.Create, FileAccess.Write))
                        {
                            StreamCopy(ms, fs);
                            fs.Close();
                        }

                        ms.Close();
                    }
                }
                catch (Exception ex)
                {
                    // logging
                    logger.Warn("unzip failed, file possibly has been deleted on database", ex);

                    // throw exception to show message
                    throw new ZipException(KissMsg.GetMLMessage("Zip",
                        "UnzipFailedMessage",
                        "Die Datei konnte nicht geöffnet werden. Möglicherweise wurde das Dokument in der Zwischenzeit gelöscht.\r\n\r\nBitte aktualisieren Sie die Ansicht, um die jetzt gültigen Daten zu erhalten."),
                        ex);
                }
            }
        }

        /// <summary>
        /// Checks if a file is already open.
        /// - Checks if the file attributes can be changed
        /// - Checks if the file can be deleted.
        /// - Restores the file attributes if necessary.
        /// </summary>
        /// <param name="fullFilename">The full filename.</param>
        /// <returns></returns>
        public static Boolean FileIsOpen(String fullFilename)
        {
            if (File.Exists(fullFilename))
            {
                try
                {
                    // remove ReadOnly of file
                    RemoveReadOnlyAttribute(fullFilename);

                    // try to get exclusive access to the file (throws exception) and close the file again.
                    File.Open(fullFilename, FileMode.Open, FileAccess.Read, FileShare.None).Close();
                }
                catch (IOException ex)
                {
                    logger.Warn("error opening file", ex);
                    logger.Info("file already open on the same machine!");

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if a file is already open.
        /// - Checks if the file attributes can be changed
        /// - Checks if the file can be deleted.
        /// - Restores the file attributes if necessary.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="extension">The extension.</param>
        /// <returns></returns>
        public static Boolean FileIsOpen(String filename, String extension)
        {
            String fullName = CreateFullName(filename, extension);
            return FileIsOpen(fullName);
        }

        /// <summary>
        /// Return a TempFile
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        /// <remarks>If the file is already open the window is brought to the front.</remarks>
        public static FileInfo GetLocalFile(String filename, String extension)
        {
            String fullName = CreateFullName(filename, extension);

            if (FileIsOpen(filename, extension))
            {
                WindowUtilities.SetWindowToForeground(filename);
            }

            return new FileInfo(fullName);
        }

        /// <summary>
        /// Removes the readonly flag of an exsiting file.
        /// </summary>
        /// <param name="filename">The file name.</param>
        public static void RemoveReadOnlyAttribute(string filename)
        {
            // if the file does not exist, we cannot do anything
            if (!File.Exists(filename))
            {
                return;
            }

            // change the attributes
            FileAttributes attr = File.GetAttributes(filename);
            attr &= ~FileAttributes.ReadOnly;

            File.SetAttributes(filename, attr);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Adds a '.' to the extension if it was missing.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <returns></returns>
        private static String FixExtension(String extension)
        {
            if (!extension.StartsWith("."))
            {
                extension = "." + extension;
            }

            return extension;
        }

        /// <summary>
        /// Copies a stream.
        /// </summary>
        /// <param name="srcStream">The source stream.</param>
        /// <param name="dstStream">The destination stream.</param>
        private static void StreamCopy(Stream srcStream, Stream dstStream)
        {
            // --- number of bytes to read in one step
            byte[] buffer = new byte[32768];
            int read;

            while ((read = srcStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                dstStream.Write(buffer, 0, read);
            }

            dstStream.Flush();
        }

        #endregion
    }
}