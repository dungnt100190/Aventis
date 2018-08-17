using System;

namespace Kiss.Interfaces.DocumentHandling
{
    public interface IExcelDocument : IDisposable
    {
        #region Methods

        /// <summary>
        /// Gets a value from a certain cell.
        /// </summary>
        /// <param name="worksheetName">The name of the worksheet.</param>
        /// <param name="cellReference">A reference string (i.e. "B42").</param>
        /// <returns></returns>
        string GetValue(string worksheetName, string cellReference);

        /// <summary>
        /// Gets a value from a certain cell.
        /// </summary>
        /// <param name="worksheetName">The name of the worksheet.</param>
        /// <param name="row">The id of the row.</param>
        /// <param name="column">The id of the column.</param>
        /// <returns></returns>
        string GetValue(string worksheetName, int row, int column);

        /// <summary>
        /// Gets a value from a certain cell.
        /// </summary>
        /// <param name="workSheetIndex">The index of the worksheet.</param>
        /// <param name="cellReference">A reference string (i.e. "B42").</param>
        /// <returns></returns>
        string GetValue(int workSheetIndex, string cellReference);

        /// <summary>
        /// Gets a value from a certain cell.
        /// </summary>
        /// <param name="workSheetIndex">The index of the worksheet.</param>
        /// <param name="row">The id of the row.</param>
        /// <param name="column">The id of the column.</param>
        /// <returns></returns>
        string GetValue(int workSheetIndex, int row, int column);

        /// <summary>
        /// Gets the string representation of a value that is in the specified named range (Named Range (Excel) = Defined Name (OpenXML).
        /// </summary>
        /// <param name="namedRange"></param>
        /// <returns></returns>
        string GetValueByNamedRange(string namedRange);

        #endregion
    }
}