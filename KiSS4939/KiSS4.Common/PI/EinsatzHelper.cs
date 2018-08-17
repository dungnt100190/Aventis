using KiSS4.DB;
using KiSS4.Dokument;
using KiSS4.Gui;

using DevExpress.XtraGrid.Columns;

namespace KiSS4.Common.PI
{
    /// <summary>
    /// Helper class which holds all Methods and Information which are needed in the Einsatz Control but differ in the various modules.
    /// </summary>
    public abstract class EinsatzHelper
    {
        #region Enumerations

        /// <summary>
        /// The access mode for accessing control. Control acts differently depending on given mode.
        /// </summary>
        public enum AccessMode
        {
            /// <summary>
            /// Accessing from the Modul tree in a "Leistung"
            /// </summary>
            Leistung,
            /// <summary>
            /// Accessing with the view of a person (client)
            /// </summary>
            Person,
            /// <summary>
            /// Accessing with the view of a user
            /// </summary>
            User
        }

        #endregion

        #region Fields

        #region Protected Fields

        protected string _captionAndFieldNameForEinsatzIDColumn = string.Empty;
        protected string _contextNameForBericht = string.Empty;
        protected string _dataMemberNameForMitarbeiterLookUpEdit = string.Empty;
        protected EinsatzDTO _daten;
        protected string _einsatzTypeName = string.Empty;
        protected string _lovNameForEinsatzTypLookUpEdit = string.Empty;
        protected string _tableNameOfActiveQuery = string.Empty;
        protected string _textForEinsatzTypLabel = string.Empty;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor assigns given values to the member variables
        /// </summary>
        /// <param name="daten">Transferobject for all needed values</param>
        protected EinsatzHelper(EinsatzDTO daten)
        {
            _daten = daten;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get the primary key id column of the table to use
        /// </summary>
        public abstract string EinsatzID
        {
            get;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Get the value for a defined field in the active query
        /// </summary>
        /// <param name="fieldName">Name of the value field</param>
        /// <param name="qryEinsatz">Current query to get the values</param>
        /// <param name="searchTypeEditValue">Value of the search type edit field</param>
        /// <returns>Value for the given field or the fieldName if there is no match</returns>
        public abstract object ContextValueByModul(string fieldName, SqlQuery qryEinsatz, int searchTypeEditValue);

        /// <summary>
        /// Contains the query for the Employee lookup
        /// </summary>
        /// <returns>SqlQuery containing the Employees for Ed</returns>
        public abstract SqlQuery GetMitarbeiterLookupQuery();

        /// <summary>
        /// Holds the sql query string to fill the main SqlQuery object
        /// </summary>
        /// <returns>Sql query as string</returns>
        public abstract string GetSqlStatement();

        /// <summary>
        /// Set the caption for given gridcolumn depending on implementation
        /// </summary>
        /// <param name="colEinsatzId">The gridcolumn to use for applying the caption</param>
        public void SetCaptionAndFieldNameForEinsatzIDColumn(GridColumn colEinsatzId)
        {
            colEinsatzId.Caption = _captionAndFieldNameForEinsatzIDColumn;
            colEinsatzId.FieldName = _captionAndFieldNameForEinsatzIDColumn;
        }

        /// <summary>
        /// Set the datamember for given control depending on implementation
        /// </summary>
        /// <param name="edtMitarbeiter">The control to use for applying the datamember</param>
        public void SetDataMemberForMitarbeiterEdit(KissLookUpEdit edtMitarbeiter)
        {
            edtMitarbeiter.DataMember = _dataMemberNameForMitarbeiterLookUpEdit;
        }

        /// <summary>
        /// Set the context for given control depending on implementation
        /// </summary>
        /// <param name="doc">The control to use for applying the context</param>
        public void SetDocContextName(KissDocumentButton doc)
        {
            doc.Context = _contextNameForBericht;
        }

        /// <summary>
        /// Set the LOVName for given control depending on implementation
        /// </summary>
        /// <param name="edtTyp">The control to use for applying the LOVName</param>
        public void SetLovNameForEinsatzTypEdit(KissLookUpEdit edtTyp)
        {
            edtTyp.LOVName = _lovNameForEinsatzTypLookUpEdit;
        }

        /// <summary>
        /// Sets the table name of the active module for the passed query object
        /// </summary>
        /// <param name="activeQuery">object on which the table name should be set</param>
        public void SetQueryTableName(SqlQuery activeQuery)
        {
            activeQuery.TableName = _tableNameOfActiveQuery;
        }

        /// <summary>
        /// Set the label text for given label depending on implementation
        /// </summary>
        /// <param name="lblTyp">The label to apply the text</param>
        public void SetTextForEinsatzTypLabel(KissLabel lblTyp)
        {
            lblTyp.Text = _textForEinsatzTypLabel;
        }

        #endregion

        #endregion
    }
}