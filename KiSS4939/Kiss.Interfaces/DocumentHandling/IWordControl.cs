namespace Kiss.Interfaces.DocumentHandling
{
    public interface IWordControl
    {
        /// <summary>
        /// Keine MessageBox anzeigen.
        /// </summary>
        bool DisableMessageBox { get; set; }

        /// <summary>
        /// Closes the document.
        /// </summary>
        void CloseActiveDocument();

        /// <summary>
        /// Create a new document and activate it.
        /// </summary>
        void Open();

        /// <summary>
        /// Open a file (the file must exist) and activate it.
        /// </summary>
        /// <param name="strFileName">Path to the file that is opened.</param>
        /// <param name="isTemplate">if <c>true</c> the file is a template.</param>
        /// <param name="makeVisible">if set to <c>true</c> makes Word visible.</param>
        /// <param name="resetProtection">if set to <c>true</c> the document protection is reset.</param>
        /// <param name="isCreatingFromTemplate"></param>
        /// <param name="isReadOnly"></param>
        /// <param name="documentId"></param>
        void Open(
            string strFileName,
            bool isTemplate,
            bool makeVisible,
            bool resetProtection,
            bool isCreatingFromTemplate,
            bool isReadOnly,
            object documentId);

        /// <summary>
        /// Quits the Word application.
        /// </summary>
        void Quit();

        /// <summary>
        /// Saves the document.
        /// </summary>
        void Save();

        /// <summary>
        /// Saves the document.
        /// </summary>
        /// <param name="fileName">The new file name.</param>
        /// <param name="saveFormat">The Word document format.</param>
        void SaveAs(string fileName, object saveFormat = null);
    }
}