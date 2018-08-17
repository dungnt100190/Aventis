using System;
using System.Collections.Generic;
using System.Data;

using Kiss.Interfaces.DocumentHandling;

using KiSS.DBScheme;

namespace KiSS4.Dokument
{
    /// <summary>
    /// Kapselt die Funktionalitäten in WordControl/ExcelControl für einfaches Template-Handling.
    /// Bietet Funktionen zum Umbenennen von Textmarken.
    /// </summary>
    public class Template
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// The data row of this template.
        /// </summary>
        private readonly DataRow _row;

        #endregion

        #region Private Fields

        private XDocFileHandler _documentHandler;
        private DokFormat _format;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new template object.
        /// </summary>
        /// <param name="row">The data row representing the template (Row from dbo.XDocTemplate).</param>
        public Template(DataRow row)
        {
            Bookmarks = new List<string>();
            _row = row;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the bookmarks of this template.
        /// </summary>
        public List<string> Bookmarks
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the format of the template.
        /// </summary>
        public DokFormat Format
        {
            get { return Convert.ToInt32(_row[DBO.XDocTemplate.DocFormatCode]) == 1 ? DokFormat.Word : DokFormat.Excel; }
        }

        /// <summary>
        /// Gets the name of this template.
        /// </summary>
        public string Name
        {
            get
            {
                return _row[DBO.XDocTemplate.DocTemplateName].ToString();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Loads the template and reads it's bookmarks.
        /// </summary>
        public void Load()
        {
            OpenDocument();

            GetBookmarksFromTemplate();

            CloseDocument();
        }

        /// <summary>
        /// Renames bookmarks in this template.
        /// </summary>
        /// <param name="renameList">A dictionary containing the old/new names of bookmarks to rename.</param>
        public void RenameBookmarks(IDictionary<string, string> renameList)
        {
            OpenDocument();

            foreach (var renamePair in renameList)
            {
                // Check if there is a bookmark in the list that starts with the old bookmark name
                if (Bookmarks.Exists(name => name.StartsWith(renamePair.Key)))
                {
                    var oldName = renamePair.Key;
                    var newName = renamePair.Value;

                    // Rename the bookmark
                    if (_format == DokFormat.Word)
                    {
                        _documentHandler.Word.RenameBookmark(oldName, newName, true);
                    }
                    else if (_format == DokFormat.Excel)
                    {
                        _documentHandler.Excel.RenameBookmark(oldName, newName, true);
                    }

                    // Update the list
                    GetBookmarksFromTemplate();
                }
            }

            CloseDocument();
        }

        #endregion

        #region Private Methods

        private void CloseDocument()
        {
            // Close the template handler
            _documentHandler.CloseDocument(_format);
            _documentHandler.DestroyWatcherAndDeleteFileAndUnlock(true, false);
            _documentHandler.QuitApplication();
        }

        /// <summary>
        /// Gets the bookmarks from the template and saves them in the Bookmarks list.
        /// </summary>
        private void GetBookmarksFromTemplate()
        {
            Bookmarks.Clear();

            if (_format == DokFormat.Word)
            {
                Bookmarks.AddRange(_documentHandler.Word.GetBookmarks());
            }
            else if (_format == DokFormat.Excel)
            {
                Bookmarks.AddRange(_documentHandler.Excel.GetBookmarks());
            }
        }

        private void OpenDocument()
        {
            // Get a template handler
            _documentHandler = XDocFileHandler.GetFileHandler(_row, true);

            // Write temp file
            _documentHandler.DBToFile(true, false, false);

            // Get the format of the template
            _format = _documentHandler.GetDokFormatCodeFromFileInfo(_documentHandler.FileInfo);

            // Open the template in the background
            _documentHandler.OpenDocumentInExternalApplication(true, _format, false);
        }

        #endregion

        #endregion
    }
}