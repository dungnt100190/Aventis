using System;
using System.IO;

namespace KiSS4.Main.Helper
{
    internal class FileEntry
    {
        #region Constructors

        public FileEntry(FileInfo file)
        {
            FileInfo = file;

            Name = file.Name;
            Size = DlgAbout.ConvertLongToByteInfo(file.Length);
            LastWriteTime = file.LastWriteTime;
        }

        #endregion

        #region Properties

        public FileInfo FileInfo
        {
            get;
            private set;
        }

        public DateTime LastWriteTime
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the file size (incl. KB, MB, ..).
        /// </summary>
        public string Size
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override string ToString()
        {
            return string.Format("Name='{0}'; Size='{1}'; LastWriteTime='{2}'", Name, Size, LastWriteTime);
        }

        #endregion

        #endregion
    }
}