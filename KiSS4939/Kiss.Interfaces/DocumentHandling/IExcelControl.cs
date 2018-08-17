namespace Kiss.Interfaces.DocumentHandling
{
    public interface IExcelControl
    {
        /// <summary>
        /// Closes the document.
        /// </summary>
        void CloseDocument();

        /// <summary>
        /// Keine MessageBox anzeigen.
        /// </summary>
        bool DisableMessageBox { get; set; }

        /// <summary>
        /// Open a Workbook.
        /// </summary>
        /// <param name="filename">Name of the doc.</param>
        /// <returns></returns>
        void OpenWorkbook(string filename);

        /// <summary>
        /// Quits the Excel application.
        /// </summary>
        void Quit();

        /// <summary>
        /// Saves the document.
        /// </summary>
        void Save();

        /// <summary>
        /// Saves the document.
        /// </summary>
        /// <param name="strFileName">Name of the file.</param>
        /// <param name="saveFormat">The excel document format.</param>
        void SaveAs(string strFileName, object saveFormat);
    }
}