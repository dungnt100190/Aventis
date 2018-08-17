using C1.C1Zip;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kiss.Infrastructure.IO
{
    /// <summary>
    /// Class to manage a zip file
    /// </summary>
    public class Zip
    {
        private readonly ZipFile _zipFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="Zip"/> class.
        /// </summary>
        /// <param name="stream">Stream containing the data</param>
        public Zip(Stream stream)
        {
            _zipFile = ZipFile.Read(stream);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Zip"/> class.
        /// </summary>
        /// <param name="fileName">Zip file name containing the data</param>
        public Zip(string fileName)
        {
            try
            {
                _zipFile = ZipFile.Read(fileName);
            }
            catch (Ionic.Zip.ZipException ex)
            {
                throw new ZipException("Invalid zip file", ex);
            }
        }

        public static byte[] CompressData(FileInfo file)
        {
            using (Stream fs = file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // attach compressor stream to the stream
                    using (C1ZStreamWriter sw = new C1ZStreamWriter(ms))
                    {
                        fs.CopyTo(sw);
                        sw.Close();
                    }

                    return ms.ToArray();
                }
            }
        }

        public static void ExpandDataToFile(byte[] data, FileInfo file)
        {
            try
            {
                using (var ms = new MemoryStream(data))
                {
                    using (var sr = new C1ZStreamReader(ms))
                    {
                        var directory = Path.GetDirectoryName(file.FullName);

                        if (directory != null && !Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        using (var fs = new FileStream(file.FullName, FileMode.Create, FileAccess.Write))
                        {
                            sr.CopyTo(fs);
                            fs.Close();
                        }

                        sr.Close();
                    }

                    ms.Close();
                }
            }
            catch
            {
                using (var ms = new MemoryStream(data))
                {
                    var directory = Path.GetDirectoryName(file.FullName);

                    if (directory != null && !Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var fs = new FileStream(file.FullName, FileMode.Create, FileAccess.Write))
                    {
                        ms.CopyTo(fs);
                        fs.Close();
                    }

                    ms.Close();
                }
            }
        }

        /// <summary>
        /// Extract a file from the zip to a directory
        /// </summary>
        /// <param name="fileName">File to extract</param>
        /// <param name="directoryName">Destination directory to extract the file to</param>
        /// <param name="overwrite">Overwrite the destination file if true</param>
        public void Extract(string fileName, string directoryName, bool overwrite)
        {
            ZipEntry zipEntry = _zipFile[fileName];
            ExtractExistingFileAction fileAction;

            if (overwrite)
            {
                fileAction = ExtractExistingFileAction.OverwriteSilently;
            }
            else
            {
                fileAction = ExtractExistingFileAction.DoNotOverwrite;
            }

            zipEntry.Extract(directoryName, fileAction);
        }

        /// <summary>
        /// Extract all the files from the zip to a directory
        /// </summary>
        /// <param name="directoryName">Destination directory to extract the files to</param>
        /// <param name="overwrite">Overwrite the destination files if true</param>
        public void ExtractAll(string directoryName, bool overwrite)
        {
            ExtractExistingFileAction fileAction = (overwrite) ? ExtractExistingFileAction.OverwriteSilently :
                                                                    ExtractExistingFileAction.DoNotOverwrite;

            foreach (var zipEntry in _zipFile)
            {
                if (zipEntry.IsDirectory)
                {
                    //Item is Directory
                    var newDirectory = Path.Combine(directoryName, zipEntry.FileName);
                    if (!Directory.Exists(newDirectory))
                    {
                        //New Directory
                        Directory.CreateDirectory(newDirectory);
                    }
                }
                else
                {
                    //Item is File

                    zipEntry.Extract(directoryName, fileAction);
                }
            }
        }

        /// <summary>
        /// Gets a <see cref="Stream"/> on the data for the given file name from the zip.
        /// </summary>
        /// <param name="fileName">file in the zip to get the <see cref="Stream"/> from</param>
        /// <returns>A <see cref="Stream"/> on the file, or null if the file name doesn't exists</returns>
        public Stream GetStream(string fileName)
        {
            foreach (ZipEntry zipEntry in _zipFile.Entries)
            {
                if (string.Compare(zipEntry.FileName, fileName, true) == 0)
                {
                    // convert to a MemoryStream to have the Seek methode
                    return ToMemoryStream(zipEntry.OpenReader());
                }
            }
            return null;
        }

        /// <summary>
        /// Gets a <see cref="Stream"/> on the data for the first file that ends with the given string from the zip.
        /// </summary>
        /// <param name="fileNameEnd">End of the file name</param>
        /// <returns>A <see cref="Stream"/> on the file, or null if the file name doesn't exists</returns>
        public Stream GetStreamEndsWith(string fileNameEnd)
        {
            IEnumerable<ZipEntry> selection = from entry in _zipFile.Entries
                                              where entry.FileName.EndsWith(fileNameEnd, StringComparison.InvariantCultureIgnoreCase)
                                              select entry;

            ZipEntry firstEntry = selection.First();

            if (firstEntry != null)
            {
                // convert to a MemoryStream to have the Seek methode
                return ToMemoryStream(firstEntry.OpenReader());
            }

            return null;
        }

        /// <summary>
        /// Gets a <see cref="Stream"/> on the data for the first file that starts with the given string from the zip.
        /// </summary>
        /// <param name="fileNameStart">Beginning of the file name</param>
        /// <returns>A <see cref="Stream"/> on the file, or null if the file name doesn't exists</returns>
        public Stream GetStreamStartsWith(string fileNameStart)
        {
            IEnumerable<ZipEntry> selection = from entry in _zipFile.Entries
                                              where entry.FileName.StartsWith(fileNameStart, StringComparison.InvariantCultureIgnoreCase)
                                              select entry;

            ZipEntry firstEntry = selection.First();

            if (firstEntry != null)
            {
                // convert to a MemoryStream to have the Seek methode
                return ToMemoryStream(firstEntry.OpenReader());
            }

            return null;
        }

        /// <summary>
        /// Converts a <see cref="Stream"/> to a <see cref="MemoryStream"/> to have the Seek methode.
        /// </summary>
        /// <param name="stream">The<see cref="Stream"/> to convert</param>
        /// <returns>A <see cref="MemoryStream"/></returns>
        private static Stream ToMemoryStream(Stream stream)
        {
            byte[] buffer = new byte[stream.Length];
            int read = 0;
            // read the whole stream
            while ((read = stream.Read(buffer, (int)stream.Position, (int)stream.Length - read)) > 0) ;
            return new MemoryStream(buffer);
        }
    }
}