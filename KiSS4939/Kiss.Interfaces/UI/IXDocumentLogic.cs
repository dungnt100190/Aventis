using System;
using System.ComponentModel;

using Kiss.Interfaces.Database;
using Kiss.Interfaces.DocumentHandling;

namespace Kiss.Interfaces.UI
{
    public interface IXDocumentLogic
    {
        #region Events

        /// <summary>
        /// Occurs when [document created].
        /// </summary>
        event EventHandler DocumentCreated;

        /// <summary>
        /// Occurs when [document creating].
        /// </summary>
        event CancelEventHandler DocumentCreating;

        /// <summary>
        /// Occurs when document was successfully deleted
        /// </summary>
        event EventHandler DocumentDeleted;

        /// <summary>
        /// Occurs when [document deleting].
        /// </summary>
        event CancelEventHandler DocumentDeleting;

        /// <summary>
        /// Occurs when [document ID changed].
        /// </summary>
        event EventHandler DocumentIDChanged;

        /// <summary>
        /// Occurs when [document imported].
        /// </summary>
        event EventHandler DocumentImported;

        /// <summary>
        /// Occurs when [document importing].
        /// </summary>
        event CancelEventHandler DocumentImporting;

        /// <summary>
        /// Occurs when [document opening].
        /// </summary>
        event CancelEventHandler DocumentOpening;

        /// <summary>
        /// Occurs when [document saved].
        /// </summary>
        event EventHandler DocumentSaved;

        /// <summary>
        /// Occurs when [DokFormatCode changed].
        /// </summary>
        event EventHandler DokFormatCodeChanged;

        /// <summary>
        /// Occurs when [EditMode changed].
        /// </summary>
        event EventHandler EditModeChanged;

        /// <summary>
        /// Occurs when Controls should refresh itself.
        /// </summary>
        event EventHandler RefreshGui;

        #endregion

        #region Properties

        string ButtonDeleteToolTip
        {
            get;
        }

        bool ButtonDeleteVisible
        {
            get;
        }

        string ButtonImportToolTip
        {
            get;
        }

        bool ButtonImportVisible
        {
            get;
        }

        string ButtonNewToolTip
        {
            get;
        }

        bool ButtonNewVisible
        {
            get;
        }

        string ButtonOpenToolTip
        {
            get;
        }

        bool ButtonOpenVisible
        {
            get;
        }

        /// <summary>
        /// Allow create new document
        /// </summary>
        [DefaultValue(true)]
        bool CanCreateDocument
        {
            get;
            set;
        }

        /// <summary>
        /// Allow delete document
        /// </summary>
        [DefaultValue(true)]
        bool CanDeleteDocument
        {
            get;
            set;
        }

        /// <summary>
        /// Allow import document
        /// </summary>
        [DefaultValue(true)]
        bool CanImportDocument
        {
            get;
            set;
        }

        /// <summary>
        /// The document can be updated.
        /// </summary>
        bool CanUpdate
        {
            get;
        }

        /// <summary>
        /// Gets or sets the context to determine which Templates to display.
        /// </summary>
        /// <value>The context.</value>
        [Browsable(true),
        DefaultValue("")]
        string Context
        {
            get;
            set;
        }

        /// <summary>
        /// The datamember to update after an import of a document.
        /// </summary>
        string DataMember
        {
            get;
            set;
        }

        string DataMemberDateLastSave
        {
            get;
            set;
        }

        /// <summary>
        /// The datasource to update after an import of a document.
        /// </summary>
        IDataSource DataSource
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the document ID.
        /// </summary>
        /// <value>The document ID.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        object DocumentID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the dok format code.
        /// </summary>
        /// <value>The dok format code.</value>
        [Browsable(true)]
        [DefaultValue(DokFormat.Unbekannt)]
        DokFormat DokFormatCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the document type code (template or document).
        /// </summary>
        /// <value>The dok typ code.</value>
        [Browsable(true)]
        [DefaultValue(DokTyp.Dokument)]
        DokTyp DokTypCode
        {
            get;
            set;
        }

        EditModeType EditMode
        {
            get;
            set;
        }

        /// <summary>
        /// Get if document is locket by current user or other user at the moment
        /// </summary>
        bool IsDocumentLocked
        {
            get;
        }

        /// <summary>
        /// Gets the flag weather the editmode is ReadOnly or not
        /// </summary>
        bool IsEditModeReadOnly
        {
            get;
        }

        /// <summary>
        /// Gets the flag weather the editmode is Required or not
        /// </summary>
        bool IsEditModeRequired
        {
            get;
        }

        /// <summary>
        /// Gets and sets the IKissContext to ask when loading Bookmarks.
        /// </summary>
        IKissContext KissContext
        {
            get;
            set;
        }

        string Text
        {
            get;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Check if drag and drop for current arguments is possible (only basic validation)
        /// </summary>
        /// <param name="argsData">The drag-eventarguments-data to check</param>
        /// <returns><c>True</c> if drag and drop is possible, otherwise <c>False</c></returns>
        bool CanDragAndDropData(IDragDropDataObject argsData);

        /// <summary>
        /// Creates a handler and imports a file.
        /// </summary>
        bool CreateHandlerAndImport(string theFile);

        /// <summary>
        /// Deletes the doc.
        /// </summary>
        void DeleteDoc();

        /// <summary>
        /// Imports the doc.
        /// </summary>
        void ImportDoc();

        /// <summary>
        /// Creates a new document.
        /// </summary>
        void NewDoc();

        /// <summary>
        /// Opens the document.
        /// </summary>
        void OpenDoc();

        /// <summary>
        /// Do drag and drop for current arguments is possible
        /// </summary>
        /// <param name="argsData">The drag-eventarguments-data to use for import</param>
        /// <returns><c>True</c> if drag and drop was performed, otherwise <c>False</c></returns>
        bool PerformDropData(IDragDropDataObject argsData);

        /// <summary>
        /// Refreshes the display.
        /// </summary>
        void RefreshDisplay();

        /// <summary>
        /// Saves the current document
        /// </summary>
        void SaveExcelDoc();

        /// <summary>
        /// Set current EditMode to Normal
        /// </summary>
        void SetEditModeNormal();

        /// <summary>
        /// Set the excel number-format on columns
        /// </summary>
        /// <param name="columns">The column name</param>
        /// <param name="numberFormat">The number-format to apply</param>
        void SetExcelNumberFormatOnColumns(string columns, string numberFormat);

        /// <summary>
        /// Set the page numbers in footer of page
        /// </summary>
        void SetExcelPageNumberInPageFooter();

        #endregion
    }
}