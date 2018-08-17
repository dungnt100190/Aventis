using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IO;
using Kiss.Interfaces.Database;
using Kiss.Interfaces.DocumentHandling;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Dokument.ExcelAutomation;
using KiSS4.Dokument.WordAutomation;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Dokument
{
    /// <summary>
    /// Summary description for XDokument.
    /// </summary>
    public class XDokumentLogik : IXDocumentLogic
    {
        #region Fields

        #region Public Static Fields

        public static string DBError = KissMsg.GetMLMessage(CLASSNAME, "MissingDocumentinDB", "(Dokument fehlt)");
        public static string DeleteDocToolTip = KissMsg.GetMLMessage(CLASSNAME, "ToolTipDeleteDoc", "Dokument löschen");
        public static string GesperrtAlt = KissMsg.GetMLMessage(CLASSNAME, "FileLockedBy", "in Bearbeitung von");
        public static string GesperrtNeu = KissMsg.GetMLMessage(CLASSNAME, "FileLockedByActual", "aktuell in Bearbeitung von");
        public static string GesperrtSeit = KissMsg.GetMLMessage(CLASSNAME, "FileLockedSince", "seit");
        public static string ImportDocToolTip = KissMsg.GetMLMessage(CLASSNAME, "ToolTipImportDoc", "Dokument importieren");
        public static string ImportTemplateToolTip = KissMsg.GetMLMessage(CLASSNAME, "ToolTipImportTemplate", "Vorlage importieren");
        public static string NewDocToolTip = KissMsg.GetMLMessage(CLASSNAME, "ToolTipNewDoc", "Neues Dokument erstellen");
        public static string OpenDocToolTip = KissMsg.GetMLMessage(CLASSNAME, "ToolTipOpenDoc", "Dokument öffnen");
        public static string OpenTemplateToolTip = KissMsg.GetMLMessage(CLASSNAME, "ToolTipOpenTemplate", "Vorlage öffnen");

        #endregion

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "XDokumentLogik";

        #endregion

        #region Private Fields

        private bool _allowEdit = true;
        private bool _canCreateDocument = true;
        private bool _canDeleteDocument = true;
        private bool _canImportDocument = true;
        private DokFormat _dokFormatCode;
        private DokTyp _dokTypCode;
        private EditModeType _editMode;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="XDokument"/> class.
        /// </summary>
        public XDokumentLogik()
        {
            DoDocumentLock = true;
            _logger.Debug("XDokumentLogik(SqlQuery, string)");
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [document created].
        /// </summary>
        public event EventHandler DocumentCreated;

        /// <summary>
        /// Occurs when [document creating].
        /// </summary>
        public event CancelEventHandler DocumentCreating;

        /// <summary>
        /// Occurs when document was successfully deleted
        /// </summary>
        public event EventHandler DocumentDeleted;

        /// <summary>
        /// Occurs when [document deleting].
        /// </summary>
        public event CancelEventHandler DocumentDeleting;

        /// <summary>
        /// Occurs when [document ID changed].
        /// </summary>
        public event EventHandler DocumentIDChanged;

        /// <summary>
        /// Occurs when [document imported].
        /// </summary>
        public event EventHandler DocumentImported;

        /// <summary>
        /// Occurs when [document importing].
        /// </summary>
        public event CancelEventHandler DocumentImporting;

        /// <summary>
        /// Occurs when [document opening].
        /// </summary>
        public event CancelEventHandler DocumentOpening;

        /// <summary>
        /// Occurs when [document saved].
        /// </summary>
        public event EventHandler DocumentSaved;

        /// <summary>
        /// Occurs when [DokFormatCode changed].
        /// </summary>
        public event EventHandler DokFormatCodeChanged;

        /// <summary>
        /// Occurs when [EditMode changed].
        /// </summary>
        public event EventHandler EditModeChanged;

        /// <summary>
        /// Occurs when Controls should refresh itself.
        /// </summary>
        public event EventHandler RefreshGui;

        #endregion

        #region Properties

        public string ButtonDeleteToolTip
        {
            get;
            private set;
        }

        public bool ButtonDeleteVisible
        {
            get;
            private set;
        }

        public string ButtonImportToolTip
        {
            get;
            private set;
        }

        public bool ButtonImportVisible
        {
            get;
            private set;
        }

        public string ButtonNewToolTip
        {
            get;
            private set;
        }

        public bool ButtonNewVisible
        {
            get;
            private set;
        }

        public string ButtonOpenToolTip
        {
            get;
            private set;
        }

        public bool ButtonOpenVisible
        {
            get;
            private set;
        }

        /// <summary>
        /// Allow create new document
        /// </summary>
        [DefaultValue(true)]
        public bool CanCreateDocument
        {
            get { return _canCreateDocument; }
            set
            {
                if (_canCreateDocument != value)
                {
                    _canCreateDocument = value;
                    RefreshDisplay();
                }
            }
        }

        /// <summary>
        /// Allow delete document
        /// </summary>
        [DefaultValue(true)]
        public bool CanDeleteDocument
        {
            get { return _canDeleteDocument; }
            set
            {
                if (_canDeleteDocument != value)
                {
                    _canDeleteDocument = value;
                    RefreshDisplay();
                }
            }
        }

        /// <summary>
        /// Allow import document
        /// </summary>
        [DefaultValue(true)]
        public bool CanImportDocument
        {
            get { return _canImportDocument; }
            set
            {
                if (_canImportDocument != value)
                {
                    _canImportDocument = value;
                    RefreshDisplay();
                }
            }
        }

        /// <summary>
        /// The document can be updated.
        /// </summary>
        public bool CanUpdate
        {
            get
            {
                if (EditMode != EditModeType.Normal)
                {
                    return false;
                }

                if (DocumentHandler != null && !DocumentHandler.CanUpdate)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Gets or sets the context to determine which Templates to display.
        /// </summary>
        /// <value>The context.</value>
        [Browsable(true),
        DefaultValue(""),
        TypeConverter(typeof(Designer.DocumentContextConverter))]
        public string Context
        {
            get;
            set;
        }

        /// <summary>
        /// The datamember to update after an import of a document.
        /// </summary>
        public string DataMember
        {
            get;
            set;
        }

        /// <summary>
        /// The datamember to update the LastSave-Date after an import of a document.
        /// </summary>
        public string DataMemberDateLastSave
        {
            get;
            set;
        }

        /// <summary>
        /// The datasource to update after an import of a document.
        /// </summary>
        public IDataSource DataSource
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the creation date of the document
        /// </summary>
        public object DateCreation
        {
            get { return (DocumentHandler == null) ? null : DocumentHandler["DateCreation"]; }
        }

        /// <summary>
        /// Gets the date of the last save
        /// </summary>
        public DateTime? DateLastSave
        {
            get
            {
                return (DocumentHandler == null) ? null : DocumentHandler["DateLastSave"] as DateTime?;
            }
        }

        public int DlgDocTemplateID
        {
            get;
            set;
        }

        public DokFormat DlgDokFormat
        {
            get;
            set;
        }

        public string DlgFileExtension
        {
            get;
            set;
        }

        public bool DlgShowBookmarkErrors
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the name of the template used to create the document
        /// </summary>
        public string DocTemplateName
        {
            get
            {
                return (DocumentHandler == null) ? string.Empty : DocumentHandler["DocTemplateName"] as string;
            }
        }

        public XDocFileHandler DocumentHandler
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
        public object DocumentID
        {
            get
            {
                return (DocumentHandler == null) ? DBNull.Value : DocumentHandler.DocumentID;
            }
            set
            {
                if (DBUtil.IsEmpty(value) && DBUtil.IsEmpty(DocumentID))
                {
                    return;
                }

                if (DBUtil.IsEmpty(value))
                {
                    // delete handler, because no ID is present, thus no data row
                    if (!DBUtil.IsEmpty(DocumentID))
                    {
                        DocumentHandler = null;
                    }
                }
                else if (IsDocumentEmpty() || !value.Equals(DocumentHandler["DocumentID"]))
                {
                    // create new handler
                    DocumentHandler = XDocFileHandler.CreateFileHandler(DokTyp.Dokument, value, "", false);

                    DocumentHandler.DocumentSaved -= docFileHandler_DocumentSaved;
                    DocumentHandler.DocumentLocked -= docFileHandler_DocumentLocked;
                    DocumentHandler.DocumentUnlocked -= docFileHandler_DocumentUnlocked;

                    DocumentHandler.DocumentSaved += docFileHandler_DocumentSaved;
                    DocumentHandler.DocumentLocked += docFileHandler_DocumentLocked;
                    DocumentHandler.DocumentUnlocked += docFileHandler_DocumentUnlocked;
                }
                else
                {
                    return;
                }

                OnDocumentIDChanged();
            }
        }

        /// <summary>
        /// Indicates whether locking of documents and templates should be activated or not.
        /// </summary>
        public bool DoDocumentLock
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
        public DokFormat DokFormatCode
        {
            get
            {
                return _dokFormatCode;
            }
            set
            {
                _dokFormatCode = value;

                OnDokFormatCodeChanged();
            }
        }

        /// <summary>
        /// Gets or sets the document type code (template or document).
        /// </summary>
        /// <value>The dok typ code.</value>
        [Browsable(true)]
        [DefaultValue(DokTyp.Dokument)]
        public DokTyp DokTypCode
        {
            get { return _dokTypCode; }
            set
            {
                // apply value
                _dokTypCode = value;

                // show the new tool tips on the buttons
                RefreshDisplay();
            }
        }

        /// <summary>
        /// Gets or sets the edit mode.
        /// </summary>
        /// <value>The edit mode.</value>
        public EditModeType EditMode
        {
            get
            {
                return _editMode;
            }
            set
            {
                if (_editMode != value)
                {
                    _editMode = value;

                    OnEditModeChanged();
                }
            }
        }

        public BmExcelDocument ExcelDoc
        {
            get;
            set;
        }

        public string GeneralToolTip
        {
            get;
            private set;
        }

        /// <summary>
        /// Missing datarow in XDocument to given ID in master row.
        /// </summary>
        /// <value><c>true</c> if the document could not be found on the database; otherwise, <c>false</c>.</value>
        public bool HasDBConflict
        {
            get
            {
                return DocumentHandler != null && DocumentHandler.HasDBConflict;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [in use].
        /// </summary>
        /// <value><c>true</c> if [in use]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool InUse
        {
            get
            {
                return (DocumentHandler != null) && (DocumentHandler.CurrentDocument != null);
            }
        }

        /// <summary>
        /// Get if document is locket by current user or other user at the moment
        /// </summary>
        public bool IsDocumentLocked
        {
            get
            {
                if (DocumentHandler == null)
                {
                    // no document handler, document is not locked
                    return false;
                }

                // get status (is locked either by current user or other users)
                return DocumentHandler.WasAlreadyLockedOnEditing || DocumentHandler.IsLockedByCurrentUser;
            }
        }

        /// <summary>
        /// Returns true if a document is open.
        /// Warning: Check the correct functionality under your circumstances before you use this function.
        /// The design around documents is a bit odd in Kiss...
        /// </summary>
        public bool IsDocumentOpen
        {
            get
            {
                return DocumentHandler != null && DocumentHandler.CurrentDocument != null;
            }
        }

        /// <summary>
        /// Gets the flag weather the editmode is ReadOnly or not
        /// </summary>
        public bool IsEditModeReadOnly
        {
            get { return EditMode == EditModeType.ReadOnly; }
        }

        /// <summary>
        /// Gets the flag weather the editmode is Required or not
        /// </summary>
        public bool IsEditModeRequired
        {
            get { return EditMode == EditModeType.Required; }
        }

        /// <summary>
        /// Gets and sets the IKissContext to ask when loading Bookmarks.
        /// </summary>
        public IKissContext KissContext
        {
            get;
            set;
        }

        /// <summary>
        /// Sets the row.
        /// </summary>
        /// <value>The row.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataRow Row
        {
            set
            {
                // logging
                _logger.Debug("enter");

                // validate
                if (value == null)
                {
                    // logging
                    _logger.Debug("empty row value to set, will not continue");

                    // cancel
                    return;
                }

                DocumentHandler = XDocFileHandler.GetFileHandler(value, (DokTypCode == DokTyp.Template));

                DocumentHandler.DocumentSaved += docFileHandler_DocumentSaved;
                DocumentHandler.DocumentLocked += docFileHandler_DocumentLocked;
                DocumentHandler.DocumentUnlocked += docFileHandler_DocumentUnlocked;

                try
                {
                    DokFormatCode = (DokFormat)value["DocFormatCode"];
                }
                catch (Exception ex)
                {
                    _logger.Warn("Error getting DokFormatCode, setting unknown state.", ex);
                    DokFormatCode = DokFormat.Unbekannt;
                }

                RefreshDisplay();

                // logging
                _logger.Debug("done");
            }
        }

        public string Text
        {
            get;
            private set;
        }

        private WordDoc WordDoc
        {
            get;
            set;
        }

        #endregion

        #region Indexers

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified column name.
        /// </summary>
        /// <value></value>
        public object this[string columnName]
        {
            get
            {
                return IsDocumentEmpty() ? DBNull.Value : DocumentHandler[columnName];
            }
            set
            {
                if (!IsDocumentEmpty())
                {
                    DocumentHandler[columnName] = value;
                }
            }
        }

        #endregion

        #region EventHandlers

        private void docFileHandler_DocumentLocked(object sender, EventArgs e)
        {
            _logger.Debug("docFileHandler_DocumentLocked");

            if (_dokTypCode == DokTyp.Dokument && DataSource != null)
            {
                // to tell others users, that this data row is locked,
                // we post in order to change the timestamp
                PerformDataSourcePost(true);
            }

            RefreshDisplay();
        }

        private void docFileHandler_DocumentSaved(object sender, EventArgs e)
        {
            _logger.Debug("docFileHandler_DocumentSaved");

            if (_dokTypCode == DokTyp.Template && DataSource != null)
            {
                // force Kiss to save
                // Dont do this for documents, because the original row may levead already
                DataSource.RowModified = true;
            }

            if (DocumentSaved != null)
            {
                DocumentSaved(this, EventArgs.Empty);
            }
        }

        private void docFileHandler_DocumentUnlocked(object sender, EventArgs e)
        {
            _logger.Debug("docFileHandler_DocumentUnlocked");

            RefreshDisplay();
        }

        /// <summary>
        /// Handles the BeforeDelete event of the qryXDocument control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryXDocument_BeforeDelete(object sender, EventArgs e)
        {
            DocumentHandler = null;
            OnDocumentIDChanged();

            if (DataSource != null)
            {
                // force KISS to post:
                // if not, other users may open the document meanwhile
                DataSource.RowModified = true;
                DataSource.Post(); // no silent post here!
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void AllowEdit(bool value)
        {
            _allowEdit = value;
        }

        /// <summary>
        /// Check if drag and drop for current arguments is possible (only basic validation)
        /// </summary>
        /// <param name="argsData">The drag-eventarguments-data to check</param>
        /// <returns><c>True</c> if drag and drop is possible, otherwise <c>False</c></returns>
        public bool CanDragAndDropData(IDragDropDataObject argsData)
        {
            if (EditMode == EditModeType.ReadOnly)
            {
                // edit not allowed
                return false;
            }

            if (DokTypCode == DokTyp.Dokument && !IsDocumentEmpty())
            {
                // document already exists
                return false;
            }

            if (argsData == null)
            {
                // invalid data argument
                return false;
            }

            // Outlook Attachements and Messages
            if (argsData.GetDataPresent("FileGroupDescriptor") && argsData.GetData("FileContents", true) != null &&
                // HACK: Messages sollen nur in KiSS 5 importiert werden können
                (Session.IsKiss5Mode || !argsData.GetDataPresent("RenPrivateMessages")))
            {
                return true;
            }

            // normal file-drop and single file only
            if (argsData.GetDataPresent(DataFormats.FileDrop) &&
                argsData.GetData(DataFormats.FileDrop) != null &&
                ((string[])argsData.GetData(DataFormats.FileDrop)).Length == 1)
            {
                return true;
            }

            // any other case
            return false;
        }

        /// <summary>
        /// Closes the current document
        /// </summary>
        public void CloseExcelDoc()
        {
            DocumentHandler.Excel.CloseDocument();
        }

        /// <summary>
        /// Creates a handler and imports a file.
        /// </summary>
        public bool CreateHandlerAndImport(string theFile)
        {
            // check if document is in use and therefore locked
            if (InUse)
            {
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "DocumentInUseCannotImport",
                    "Das Dokument ist zurzeit vom Prozess gesperrt und kann daher nicht ersetzt werden."
                );
                return false;
            }

            var fileExtension = Path.GetExtension(theFile);
            if (fileExtension != null)
            {
                string extension = fileExtension.ToLower();

                if (_dokTypCode == DokTyp.Template)
                {
                    // TODO: here we need a config-value... (no hardcoded template-types!)
                    // check for correct format
                    if (!";.dot;.dotx;.xlt;.xltx;".Contains(";" + extension + ";"))
                    {
                        KissMsg.ShowInfo(CLASSNAME, "CanOnlyImportTemplatesWordOrExcel", "Sie können nur Word- oder Excel-Vorlagen importieren.");
                        return false;
                    }

                    // security question
                    if (!KissMsg.ShowQuestion(CLASSNAME, "FileImportAskForOverwriting", "Wollen Sie die existierende Vorlage wirklich ersetzen?"))
                    {
                        return false;
                    }
                }

                // create handler and import the file
                object docID = (DokTypCode == DokTyp.Template && DataSource != null) ? DataSource["DocTemplateID"] : DBNull.Value;

                if (DocumentHandler == null)
                {
                    DocumentHandler = XDocFileHandler.CreateHandlerImportToDB(docID, "", (DokTypCode == DokTyp.Template));
                }

                ImportFile(theFile);

                docID = DocumentHandler.DocumentID;
                DocumentHandler.DestroyWatcherAndDeleteFileAndUnlock(false, false);
                DocumentHandler = null;
                DocumentHandler = XDocFileHandler.CreateFileHandler(_dokTypCode, docID, extension, false);
            }

            RefreshDisplay();

            return true;
        }

        /// <summary>
        /// Deletes the doc.
        /// </summary>
        public void DeleteDoc()
        {
            OnButtonDeleteDoc();
        }

        /// <summary>
        /// Exportiert das referenzierte Dokument in ein DataSet
        /// </summary>
        /// <returns>Das exportierte DataSet</returns>
        public DataSet ExportExcelToDataSet()
        {
            if (DocumentHandler == null)
                throw new Exception("Keine Excel-Datei geladen.");

            try
            {
                DocumentHandler.Excel.Visible = false;
                return DocumentHandler.Excel.ExportCurrentWorkbookToDataSet();
            }
            finally
            {
                DocumentHandler.Excel.Visible = true;
            }
        }

        /// <summary>
        /// Gets the empty word template.
        /// </summary>
        /// <returns></returns>
        public Byte[] GetEmptyWordTemplate()
        {
            FileInfo file = new FileInfo(Path.GetTempFileName());

            WordControl wordControl = new WordControl();
            wordControl.NewTemplate(file.FullName);

            // dies schliesst offene Dokumente, schliesst wenn nötig das Word
            // und räumt auch alle COM-Referenzen auf:
            wordControl.Quit();

            Byte[] compressedData = Zip.CompressData(file);
            Zip.DeleteFile(file);

            return compressedData;
        }

        /// <summary>
        /// Get an new template from KiSS application subfolder
        /// </summary>
        /// <returns>The zipped bytes of the new template</returns>
        public AvailableTemplate GetNewTemplate()
        {
            // check if the new template-folder does really exist (to prevent errors)
            if (!DlgSelectNewTemplate.TemplatePathExists())
            {
                // TODO : refactoring for excel templates required?
                // create and return new available word-template
                return new AvailableTemplate(
                    KissMsg.GetMLMessage(CLASSNAME, "DocTemplateDefaultName", "Neue Vorlage"),
                    string.Empty,
                    ".dot",
                    GetEmptyWordTemplate()
                );
            }

            // get dialog
            DlgSelectNewTemplate dlg = new DlgSelectNewTemplate();

            // show dialog and check result
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // return the selected template from dialog
                AvailableTemplate template = dlg.SelectedTemplate;

                // create filebinary
                template.LoadAndApplyFileBinary();

                // return given template
                return template;
            }

            // nothing selected
            return null;
        }

        /// <summary>
        /// Imports the doc.
        /// </summary>
        public void ImportDoc()
        {
            OnButtonImportDoc();
        }

        /// <summary>
        /// Gets a value indicating whether the document is empty.
        /// </summary>
        /// <value><c>true</c> if [doc empty]; otherwise, <c>false</c>.</value>
        public bool IsDocumentEmpty()
        {
            return DocumentHandler == null || DocumentHandler.IsEmpty;
        }

        /// <summary>
        /// Creates a new document.
        /// </summary>
        public void NewDoc()
        {
            OnButtonNewDoc();
        }

        /// <summary>
        /// Opens the document.
        /// </summary>
        public void OpenDoc()
        {
            OnButtonOpenDoc(false);
        }

        /// <summary>
        /// Performs a DataSource.Post in order to check must fields of the master data row.
        /// </summary>
        public bool PerformDataSourcePost(bool useSilentPost)
        {
            // Performs a DataSource.Post in order to check must fields of the master data row.
            // If this check is not done, a later DataSource.Cancel by the user would leave
            // an unassigned row in XDocument
            if (DataSource != null && DokTypCode == DokTyp.Dokument)
            {
                // using XDocument we have to make sure, the actual row can be posted
                // if not, an exception in DataSource.Post (ImportFile) will block a new document ID to be saved
                // cancelling DataSource later would leave an unassigned row in XDocument
                var oldRowModified = (DataSource.RowModified || (DataSource.HasRow && DataSource.CurrentRowState != DataRowState.Unchanged));

                // silentPost is used for blocking changes of mutation information (see ZH/ctlFaDokumente.cs)
                // force Kiss to Post:
                DataSource.RowModified = true;

                if (!DataSource.Post(true, useSilentPost))
                {
                    // force Kiss to Post later, if other data was changed:
                    DataSource.RowModified = oldRowModified;
                    return false;
                }

                // force Kiss to Post later, if other data was changed:
                DataSource.RowModified = oldRowModified;
            }

            return true;
        }

        /// <summary>
        /// Do drag and drop for current arguments is possible
        /// </summary>
        /// <param name="argsData">The drag-eventarguments-data to use for import</param>
        /// <returns><c>True</c> if drag and drop was performed, otherwise <c>False</c></returns>
        public bool PerformDropData(IDragDropDataObject argsData)
        {
            if (DokTypCode == DokTyp.Dokument && !IsDocumentEmpty())
            {
                KissMsg.ShowInfo(CLASSNAME, "FileAlreadyImported_v01", "Es ist bereits eine Datei vorhanden, bitte löschen Sie diese zuerst.");
                return false;
            }

            if (DokTypCode == DokTyp.Template && !IsDocumentEmpty())
            {
                // using XDocTemplate, the import button is always active,
                // thus here we can check, if the document is locked
                DocumentHandler.RefreshDocument();

                if (DocumentHandler.WasAlreadyLockedOnEditing)
                {
                    if (!DocumentHandler.CheckForLockingsImport())
                    {
                        return false;
                    }
                }
            }

            // Outlook Attachements
            if (argsData.GetDataPresent("FileGroupDescriptor") && argsData.GetData("FileContents", true) != null)
            {
                var fileGroupDescriptors = (string[])argsData.GetData("FileGroupDescriptor");
                var fileStreams = (MemoryStream[])argsData.GetData("FileContents", true);
                if (fileGroupDescriptors.Length != 1 || fileStreams.Length != 1)
                {
                    return false;
                }

                var theFile = Path.GetTempPath() + fileGroupDescriptors[0];
                var ms = fileStreams[0];
                using (var fs = new FileStream(theFile, FileMode.Create))
                {
                    var fileBytes = new byte[ms.Length];

                    ms.Position = 0;
                    ms.Read(fileBytes, 0, Convert.ToInt32(ms.Length));

                    fs.Write(fileBytes, 0, fileBytes.Length);
                    fs.Close();
                }

                // create handler and import the file
                if (!CreateHandlerAndImport(theFile))
                {
                    return false;
                }

                var tempFile = new FileInfo(theFile);

                if (tempFile.Exists)
                {
                    tempFile.Delete();
                }

                return true;
            }

            if (argsData.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])argsData.GetData(DataFormats.FileDrop);

                if (files.Length != 1)
                {
                    KissMsg.ShowInfo(CLASSNAME, "ImportOnlyOneFileAtOnce", "Sie können jeweils nur eine Datei importieren.");
                    return false;
                }

                if (File.Exists(files[0]))
                {
                    // create handler and import the file
                    if (!CreateHandlerAndImport(files[0]))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Prints the document to the default printer.
        /// </summary>
        /// <returns>the <see cref="Task"/> that wait for destroy watcher and delete file and unlock</returns>
        /// <exception cref="KissErrorException">if filetype is unknown.</exception>
        public Task PrintDoc()
        {
            return PrintDoc(null);
        }

        /// <summary>
        /// Prints the document to the specified printer.
        /// </summary>
        /// <param name="printerName">The printer where the document should be printed.</param>
        /// <returns>the <see cref="Task"/> that wait for destroy watcher and delete file and unlock</returns>
        /// <exception cref="KissErrorException">if filetype is unknown.</exception>
        public Task PrintDoc(string printerName)
        {
            //check if we have a document to print
            if (DocumentHandler == null)
            {
                return null;
            }

            if (DocumentHandler.IsLockedByCurrentUser || DocumentHandler.WasAlreadyLockedOnEditing)
            {
                var message = "{0}" + Environment.NewLine + Environment.NewLine + "{1}";

                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        CLASSNAME,
                        "DocumentIsOpen",
                        message,
                        DocumentHandler.IsLockedByCurrentUser ? DocumentHandler.CheckOutMesssageActualUser : DocumentHandler.CheckOutMesssageOtherUser,
                        DocumentHandler.CheckOutMesssage));
            }

            // get file from database
            DocumentHandler.DBToFile(false, false, false);

            //print it
            return DocumentHandler.PrintDocument(printerName);
        }

        /// <summary>
        /// Refreshes the display.
        /// </summary>
        public void RefreshDisplay()
        {
            // logging
            //logger.Debug("RefreshDisplay: enter");
            _logger.Debug("RefreshDisplay: call");

            // init default vars (used if no document handler is available)
            DateTime dateLastSave = DateTime.MinValue;
            bool wasAlreadyLockedOnEditing = false;
            bool isLockedByCurrentUser = false;
            string checkoutUserName = string.Empty;
            DateTime checkoutDate = DateTime.MinValue;

            // init other vars
            string lockedBy = "";
            bool isDocumentEmpty = IsDocumentEmpty();

            // Determining, if docID of the master record is equal to the value stored in XDocument
            // if those values are not equal, a serious conflict exists
            // this behavior could be observed on integration DBs copied from productive DBs,
            // when the document data in XDocument was not copied at all
            string tmpDBError = "";

            if (HasDBConflict)
            {
                tmpDBError = " " + DBError;
            }

            // check if we have a document handler instance
            if (DocumentHandler == null)
            {
                // logging
                _logger.Debug("RefreshDisplay: no documentHandler instance");
            }
            else
            {
                // set values from documentHandler
                dateLastSave = DateLastSave ?? dateLastSave;
                wasAlreadyLockedOnEditing = DocumentHandler.WasAlreadyLockedOnEditing;
                isLockedByCurrentUser = DocumentHandler.IsLockedByCurrentUser;
                checkoutUserName = DocumentHandler.CheckoutUserName;
                checkoutDate = DocumentHandler.CheckoutDate;
            }

            try
            {
                // setting visible states of buttons
                ButtonNewVisible = _canCreateDocument && (isDocumentEmpty && _dokTypCode != DokTyp.Template);
                ButtonImportVisible = _canImportDocument && (isDocumentEmpty || _dokTypCode == DokTyp.Template);
                ButtonOpenVisible = !isDocumentEmpty || _dokTypCode == DokTyp.Template;
                ButtonDeleteVisible = _canDeleteDocument && (!isDocumentEmpty && _dokTypCode != DokTyp.Template);

                if (isDocumentEmpty && _dokTypCode != DokTyp.Template)
                {
                    Text = HasDBConflict ? "???" : "";
                }
                else
                {
                    //Text = string.Format("{0:d}", dateLastSave);
                    // HACK im KiSS 5 wird es auf english formatiert. Nach Umstellung auf .NET 4.5 nochmal mit "{0:d}" prüfen
                    Text = string.Format("{0:dd.MM.yyyy}", dateLastSave);
                }
            }
            catch (Exception ex)
            {
                _logger.Warn("RefreshDisplay: Error setting buttons visible state.", ex);
            }

            // change hints depending on current locked-state
            if (wasAlreadyLockedOnEditing)
            {
                lockedBy = string.Format(" ({0} {1} {2} {3})", GesperrtAlt, checkoutUserName, GesperrtSeit, checkoutDate.ToString("dd.MM.yyyy HH:mm:ss"));
            }
            else if (isLockedByCurrentUser)
            {
                lockedBy = string.Format(" ({0} {1} {2} {3} {4})", GesperrtNeu, Session.User.LastName, Session.User.FirstName, GesperrtSeit, checkoutDate.ToString("dd.MM.yyyy HH:mm:ss"));
            }

            // set tooltip depending on document
            if (_dokTypCode == DokTyp.Template)
            {
                // set tooltips for templates
                ButtonNewToolTip = "";
                ButtonOpenToolTip = OpenTemplateToolTip + lockedBy;
                ButtonImportToolTip = ImportTemplateToolTip + lockedBy;
                ButtonDeleteToolTip = "";
            }
            else
            {
                // set tooltips for documents
                ButtonNewToolTip = NewDocToolTip + lockedBy + tmpDBError;
                ButtonOpenToolTip = OpenDocToolTip + lockedBy + tmpDBError;
                ButtonImportToolTip = ImportDocToolTip + lockedBy + tmpDBError;
                ButtonDeleteToolTip = DeleteDocToolTip + lockedBy + tmpDBError;
                GeneralToolTip = DocTemplateName;
            }

            // updating the main datasource
            if (DataSource != null && !string.IsNullOrEmpty(DataMemberDateLastSave) && DataSource[DataMemberDateLastSave] as DateTime? != DateLastSave)
            {
                DataSource[DataMemberDateLastSave] = DateLastSave;
            }

            //Control, refresh Dich
            OnRefreshGui();
        }

        /// <summary>
        /// Saves the current document
        /// </summary>
        public void SaveExcelDoc()
        {
            DocumentHandler.Excel.Save();
        }

        /// <summary>
        /// Saves a template to the local folder before deleting it.
        /// </summary>
        public void SaveTemplateToLocalDirectory()
        {
            // if not assigned, do nothing here
            if (DocumentHandler == null)
            {
                return;
            }

            // save a template to the local directory in order to have a copy of it in case of errors
            DocumentHandler.OpenDocument();
            DocumentHandler.DBToFile(false, false, true);
        }

        /// <summary>
        /// Set current EditMode to Normal
        /// </summary>
        public void SetEditModeNormal()
        {
            EditMode = EditModeType.Normal;
        }

        /// <summary>
        /// Set the excel number-format on columns
        /// </summary>
        /// <param name="columns">The column name</param>
        /// <param name="numberFormat">The number-format to apply</param>
        public void SetExcelNumberFormatOnColumns(string columns, string numberFormat)
        {
            if (DocumentHandler != null && DocumentHandler.Excel != null)
            {
                DocumentHandler.Excel.SetNumberFormatOnColumns(columns, numberFormat);
            }
        }

        /// <summary>
        /// Sets the Orientation of the current Excel-Worksheet
        /// </summary>
        /// <param name="orientation"></param>
        public void SetExcelOrientation(ExcelControl.Orientation orientation)
        {
            if (DocumentHandler != null && DocumentHandler.Excel != null)
            {
                DocumentHandler.Excel.SetOrientationOnCurrentWorksheet(ExcelControl.Orientation.Landscape);
            }
        }

        /// <summary>
        /// Set the page numbers in footer of page
        /// </summary>
        public void SetExcelPageNumberInPageFooter()
        {
            if (DocumentHandler != null && DocumentHandler.Excel != null)
            {
                DocumentHandler.Excel.SetPageNumberInPageFooter();
            }
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Determine if given filetype is readonly or writeable.
        /// This depends on settings stored in database.
        /// </summary>
        /// <param name="fileEnding">The fileending of the filetype to check</param>
        /// <returns>True if file is a writeable type or false if file is readonly</returns>
        private static bool IsFileTypeWriteable(string fileEnding)
        {
            // validate
            if (string.IsNullOrEmpty(fileEnding))
            {
                // empty file-ending is always readonly
                return false;
            }

            // prepare fileending for comparison (remove ".", trailing whitespaces and make it lower)
            fileEnding = fileEnding.Replace(".", "").Trim().ToLower();

            // get settings from database (lower-case)
            string writeableEndings = DBUtil.GetConfigString(
                @"System\GUI\SchreibbareDokumente",
                "doc;docm;docx;dot;dotx;dotm;xls;xlsm;xlsx;xlsb;xlt;xltx;xltm;xla;xlam"
            ).ToLower();

            // check if given fileending is writeable
            foreach (string writeableEnding in writeableEndings.Split(new[] { ';' }))
            {
                // check if fileending matches
                if (fileEnding.Equals(writeableEnding))
                {
                    // fileending is set as writeable
                    return true;
                }
            }

            // fileending was not found in writeable-endings, therefore it is readonly
            return false;
        }

        /// <summary>
        /// Determine if the warning message that a file is read only should be suppressed for given filetype
        /// This depends on settings stored in database.
        /// </summary>
        /// <param name="fileEnding">The fileending of the filetype to check</param>
        /// <returns>True if file is the warning should be suppressed</returns>
        private static bool SuppressReadonlyMessageForFileType(string fileEnding)
        {
            // validate
            if (string.IsNullOrEmpty(fileEnding))
            {
                // empty file-ending is always readonly
                return false;
            }

            // prepare fileending for comparison (remove ".", trailing whitespaces and make it lower)
            fileEnding = fileEnding.Replace(".", "").Trim().ToLower();

            // get settings from database (lower-case)
            string endingsWithoutWarning = DBUtil.GetConfigString(
                @"System\GUI\DokumenteOhneReadonlyWarnung",
                "pdf;jpg;jpeg;tif;msg"
            ).ToLower();

            return (";" + endingsWithoutWarning + ";").Contains(";" + fileEnding + ";");
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks for exsiting files, delete them if possible
        /// </summary>
        private bool CheckForExistingFiles()
        {
            // if the file does not exists, nothing to do
            string oldFilename = DocumentHandler.ActualFileFullName;

            if (!File.Exists(oldFilename))
            {
                return true;
            }

            // check if file is open
            if (Zip.FileIsOpen(oldFilename))
            {
                // debuging
                _logger.Warn("CheckForExistingFiles: cannot delete file in use: " + oldFilename);

                // but when the file is in use, we cannot do it
                string msgFile1 = KissMsg.GetMLMessage(
                    CLASSNAME,
                    "FileLockedSameFileExists",
                    "Auf Ihrem Computer ist eine Datei mit dem gleichen Namen bereits geöffnet."
                );

                string msgFile2 = KissMsg.GetMLMessage(
                    CLASSNAME,
                    "FileLockedCloseFileFirst_v02",
                    "Schliessen Sie zuerst diese Datei resp. das Programm, welches diese Datei verwendet,\r\n" +
                    "bevor Sie die Datei erneut öffnen."
                );

                KissMsg.ShowInfo(msgFile1 + "\r\n" + oldFilename + "\r\n\r\n" + msgFile2);
                return false;
            }

            // the file is not in use, so we can delete it and we make a copy first:
            string newFilename;

            try
            {
                // create a backup name
                newFilename = Path.GetDirectoryName(oldFilename) + "\\" +
                    Path.GetFileNameWithoutExtension(oldFilename) + "_sik" +
                    DateTime.Now.ToString("yyyyMMdd_HHmmss") +
                    Path.GetExtension(oldFilename);

                // copy the file, overwrite the exsiting one
                Zip.RemoveReadOnlyAttribute(newFilename);
                File.Copy(oldFilename, newFilename, true);

                // debuging
                _logger.Warn(string.Format(
                    "CheckForExistingFiles: file {0} copied to {1}",
                    oldFilename,
                    newFilename
                ));
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(
                    CLASSNAME,
                    "FileBackupErrorUnknown",
                    "Beim Anlegen einer Sicherungskopie ist ein Fehler aufgetreten.",
                    ex.Message
                );
                // debuging
                _logger.Error("CheckForExistingFiles: error making a copy: " + oldFilename, ex);
                return false;
            }

            // inform the user, when done
            // NO, we do not show backup messages at all
            /*
            string msgCopy1 = KissMsg.GetMLMessage(className, "FileBackupSameFileFound",
                "Auf Ihrem Computer wurde eine Datei mit gleichem Namen gefunden.");
            string msgCopy2 = KissMsg.GetMLMessage(className, "FileBackupSameFileSavedAs",
                "Diese Datei wurde gesichert unter dem neuen Namen:");
            KissMsg.ShowInfo(msgCopy1 + "\r\n" + msgCopy2 + "\r\n" + newFilename);
            */

            // now delete the file
            try
            {
                // before deleting the file, we have to set ReadWrite = FALSE
                // if not, File.Delete() will throw an exception
                Zip.RemoveReadOnlyAttribute(oldFilename);
                File.Delete(oldFilename);

                // debuging
                _logger.Warn("CheckForExistingFiles: file deleted: " + oldFilename);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(
                    KissMsg.GetMLMessage(
                        CLASSNAME,
                        "DateiNichtLoeschen_v01",
                        "Die zu öffnende Datei konnte nicht freigegeben werden. " +
                        "Möglicherweise ist die Datei noch geöffnet.\r\n\r\n" +
                        "Datei: '{0}'",
                    oldFilename),
                    ex.Message
                );

                // debuging
                _logger.Error("CheckForExistingFiles: error deleting file: " + oldFilename, ex);
                return false;
            }

            try
            {
                // get the date of the new file
                DateTime newDate = DocumentHandler.DateLastSave;
                // get the date of the old file
                DateTime oldDate = File.GetLastWriteTime(newFilename);

                if (oldDate > newDate)
                {
                    // inform the user, a newer file is found
                    string msgLine1 = string.Format(KissMsg.GetMLMessage(
                        CLASSNAME,
                        "FileBackupNewerFileFoundSaveDate",
                        "Die neu zu bearbeitende Datei wurde zuletzt am {0} gespeichert."),
                        newDate.ToString("dd.MM.yyyy HH:mm:ss")
                    );
                    string msgLine2 = string.Format(KissMsg.GetMLMessage(
                        CLASSNAME,
                        "FileBackupNewerFileFoundNewDate",
                        "Im lokalen Ordner befindet sich aber eine neuere Datei vom {0}."),
                        oldDate.ToString("dd.MM.yyyy HH:mm:ss")
                    );
                    string msgLine3 = KissMsg.GetMLMessage(
                        CLASSNAME,
                        "FileBackupNewerFileFoundSupportInfo",
                        "Falls die neuere Datei übernommen werden soll, wenden Sie sich bitte an den Servicedesk.");

                    KissMsg.ShowInfo(string.Format(
                        "{0}\r\n{1}\r\n\r\n{2}\r\n{3}\r\n\r\n{4}",
                        msgLine1,
                        oldFilename,
                        msgLine2,
                        newFilename,
                        msgLine3
                    ));

                    // logger
                    _logger.Warn("CheckForExistingFiles: newer file found, copied to " + newFilename);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("CheckForExistingFiles: error creating message", ex);
                KissMsg.ShowError(
                    CLASSNAME,
                    "FileBackupErrorMessage",
                    "Beim Erstellen einer Hinweismeldung ist ein Fehler aufgetreten.",
                    ex.Message
                );
            }

            return true;
        }

        /// <summary>
        /// Indicates, if the document is still in use
        /// </summary>
        private bool DocumentIsStillInUse(bool isInserting)
        {
            if (DocumentHandler == null || isInserting)
                return false;

            if (FileIsOpenOrProcessIsActive() || DocumentHandler.IsLockedByCurrentUser)
            {
                // file still locked of earlier handlings

                // !!! please do not change "(min. 1 Sekunde)" without changing values of
                // ProcessLauncher.acceleratedSaveInterval and ProcessLauncher.totalRepeatingLoopCount !!!
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "FileIsStillInUseByCurrentUser02p4Second",
                    "Die Datei ist noch durch Sie selbst als \"in Bearbeitung\" gekennzeichnet.\r\n\r\n" +
                    "Beenden Sie die laufende Bearbeitung oder warten Sie,\r\n" +
                    "bis der laufende Process beendet ist (min. 4 Sekunden)."
                );
                return true;
            }

            return false;
        }

        private void ExcelProgressClose()
        {
            DlgProgressLog.AddLine(KissMsg.GetMLMessage(CLASSNAME, "ExcelProgressClose_v01", "Excel-Vorlage schliessen"));
        }

        private void ExcelProgressStart()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DlgProgressLog.ShowTopMost();

                DlgProgressLog.AddLine(KissMsg.GetMLMessage(CLASSNAME, "ExcelProgressStart_v01", "Excel-Vorlage laden"));

                // TODO: here we need a config-value... (no hardcoded template-types --> search other, too!)
                // get file info based on dlgDocumentID
                XDocFileHandler template = XDocFileHandler.CreateFileHandler(DokTyp.Template, DlgDocTemplateID, MapExcelExtension(DlgFileExtension), true);

                // get template from db and create temporary file
                template.DBToFile(false, false, false);
                template.FileInfo.Attributes &= ~FileAttributes.ReadOnly;

                DlgProgressLog.AddLine(KissMsg.GetMLMessage(CLASSNAME, "ExcelDokumentErzeugen", "Excel-Dokument erzeugen"));
                DlgProgressLog.AddLine(KissMsg.GetMLMessage(CLASSNAME, "OpenFileName", "Datei: {0}", KissMsgCode.Text, template.FileInfo));

                // open Excel-Template, parse bookmarks, save and close document again
                ExcelDoc = new BmExcelDocument(template.FileInfo, false);

                ExcelDoc.FillBookmarks(KissContext);

                // save template
                DlgProgressLog.AddLine(KissMsg.GetMLMessage(CLASSNAME, "VorlageSpeichern", "Ausgefüllte Vorlage speichern"));

                // save changes
                ExcelDoc.Save();

                // close template document
                ExcelDoc.CloseDocument();

                if (!DlgShowBookmarkErrors || !DlgProgressLog.HasErrors)
                {
                    // Close Progress dialog and display the new doc
                    DlgProgressLog.CloseDialog();
                }
                else
                {
                    // Keep Progress dialog open and display the new doc after the user quits the dialog
                    DlgProgressLog.AddLine(KissMsg.GetMLMessage(
                        CLASSNAME,
                        "ExcelErledigtMitFehler",
                        "Erledigt (Es sind Fehler aufgetreten)"
                    ));
                    DlgProgressLog.EndProgress();
                    DlgProgressLog.ShowTopMost();
                }

                DocumentHandler = null;
                DocumentHandler = XDocFileHandler.CreateHandlerImportToDB(DBNull.Value, template.NewExtension, false);
                DokFormatCode = DokFormat.Excel;
                DocumentHandler["DocFormatCode"] = DokFormat.Excel;
                DocumentHandler.FileToDB(new FileInfo(template.FileInfo.FullName));
                DocumentHandler["DocTemplateID"] = DlgDocTemplateID;
                DocumentHandler["DateCreation"] = DateTime.Now;
                DocumentHandler["DateLastSave"] = DateTime.Now;

                if (DoDocumentLock)
                {
                    DocumentHandler["CheckOut_UserID"] = Session.User.UserID;
                    DocumentHandler["CheckOut_Date"] = DateTime.Now;
                    DocumentHandler["CheckOut_Filename"] = DocumentHandler.ActualFileFullName;
                    DocumentHandler["CheckOut_Machine"] = Environment.MachineName;
                }

                DocumentHandler.Post();
            }
            catch (CancelledByUserException ex)
            {
                // logging
                _logger.Warn("catched CancelledByUserException", ex);

                DlgProgressLog.CloseDialog();
            }
            catch (KissCancelException ex)
            {
                // logging
                _logger.Warn("catched KissCancelException", ex);

                DlgProgressLog.CloseDialog();
            }
            catch (ZipException ex)
            {
                // logging
                _logger.Warn("catched ZipException", ex);

                DlgProgressLog.CloseDialog();
                KissMsg.ShowInfo(ex.Message);
            }
            catch (Exception ex)
            {
                // logging
                _logger.Warn("catched Exception", ex);

                DlgProgressLog.CloseDialog();
                KissMsg.ShowError(
                    CLASSNAME,
                    "ExcelFehlerDokumentErzeugen",
                    "Fehler beim Erzeugen des neuen Excel-Dokuments\r\n\r\n",
                    ex.Message,
                    ex
                );
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private bool FileIsOpenOrProcessIsActive()
        {
            if (DocumentHandler == null)
            {
                return false;
            }

            // if the process is locking the document, we look, if file still is open
            // if the process is not locking the document, we look, if the process still is active
            return DocumentHandler.ProcessWatcherIsStillActive;
        }

        /// <summary>
        /// Imports the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        private void ImportFile(string fileName)
        {
            if (DocumentHandler == null)
            {
                // programming error, do not translate
                KissMsg.ShowInfo("Programming error in XDokument.ImportFile: documentHandler == null");
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                FileInfo importFile = new FileInfo(fileName);

                if (Session.IsKiss5Mode && !DBUtil.UserHasRight("XDocument_GroesseUneingeschraenkt"))
                {
                    var maxDocLen = DBUtil.GetConfigValue(@"System\Dokumentemanagement\MaxDokumentgrösseKB", null, DateTime.Now) as int?;

                    if (maxDocLen != null && (maxDocLen * 1024 < importFile.Length))
                    {
                        KissMsg.ShowInfo(CLASSNAME, "MaxDokumentgroesseKBUeberschritten",
                            String.Format("Die Datei konnte nicht gespeichert werden, weil sie die definierte Maximalgrösse von {0} KB überschreitet.", maxDocLen));
                        return;
                    }
                }

                DokFormatCode = DocumentHandler.GetDokFormatCodeFromFileInfo(importFile);
                DocumentHandler["DocFormatCode"] = DokFormatCode;
                DocumentHandler.FileToDB(importFile);

                // updating the main datasource
                if (DataSource != null && !string.IsNullOrEmpty(DataMember))
                {
                    DataSource[DataMember] = DocumentHandler.DocumentID;
                }

                OnDocumentIDChanged();
            }
            finally
            {
                Cursor.Current = Cursors.Default;

                // force save record
                ApplicationFacade.DoEvents();

                if (DokTypCode == DokTyp.Dokument && DataSource != null && !DataSource.IsEmpty)
                {
                    // only do this with documents, with templates it would checkin the file
                    // force KISS to post:
                    DataSource.RowModified = true;
                    DataSource.Post(); // no silent post here!
                }
            }
        }

        /// <summary>
        /// Determine if current file is writeable
        /// </summary>
        /// <returns>True if file can be altered, otherwise false</returns>
        private bool IsDocumentWriteable()
        {
            // get current fileending
            string fileEnding = Convert.ToString(DocumentHandler["FileExtension"]);

            // when new template documenthandler["FileExtension"] delivers empty string
            // thus we check this here:
            if (string.IsNullOrEmpty(fileEnding))
            {
                fileEnding = DocumentHandler.NewExtension;
            }

            // check if document is writeable
            return _allowEdit &&
                DataSource != null &&
                DataSource.CanUpdate &&
                EditMode != EditModeType.ReadOnly &&
                IsFileTypeWriteable(fileEnding);
        }

        private string MapExcelExtension(string fileExtension)
        {
            if (string.IsNullOrWhiteSpace(fileExtension))
            {
                return fileExtension;
            }
            string extensionLower = fileExtension.ToLower(CultureInfo.InvariantCulture);

            if (extensionLower.Equals(".xlt") || extensionLower.Equals(".xltm"))
            {
                return ".xls";
            }

            // alle übrigen Formate werden beibehalten
            return extensionLower;
        }

        private string MapWordExtension(string fileExtension)
        {
            if (string.IsNullOrWhiteSpace(fileExtension))
            {
                return fileExtension;
            }

            string extensionLower = fileExtension.ToLower(CultureInfo.InvariantCulture);

            if (extensionLower.Equals(".dot") || extensionLower.Equals(".dotm"))
            {
                return ".doc";
            }

            if (extensionLower.Equals(".dotx"))
            {
                return ".docx";
            }

            // alle übrigen Formate werden beibehalten
            return extensionLower;
        }

        /// <summary>
        /// Called when [button delete doc].
        /// </summary>
        private void OnButtonDeleteDoc()
        {
            ApplicationFacade.DoEvents();

            if (IsDocumentEmpty() || !_canDeleteDocument)
            {
                return;
            }

            if (DataSource != null && !DataSource.CanUpdate)
            {
                KissMsg.ShowInfo(CLASSNAME, "DokLoeschenNichtMoeglich", "Das Dokument ist schreibgeschützt und kann nicht gelöscht werden!");
                return;
            }

            // check if the document is still in use
            if (DocumentIsStillInUse(false))
            {
                return;
            }

            // in order to be up to date
            DocumentHandler.RefreshDocument();
            RefreshDisplay();

            if (DocumentHandler.WasAlreadyLockedOnEditing || DocumentHandler.IsLockedByCurrentUser)
            {
                // file is already locked, so leave here with message
                string fileLockedMsg = DocumentHandler.WasAlreadyLockedOnEditing
                    ? DocumentHandler.CheckOutMesssageOtherUser : DocumentHandler.CheckOutMesssageActualUser;

                // gets the checkout message (user, time, file, machine)
                string checkoutMsg = DocumentHandler.CheckOutMesssage;
                string msgDelete = KissMsg.GetMLMessage(CLASSNAME, "FileLockedNoDeleting", "Die Datei kann nicht gelöscht werden!");

                KissMsg.ShowInfo(fileLockedMsg + "\r\n\r\n" + checkoutMsg + "\r\n\r\n" + msgDelete);
                return;
            }

            if (DocumentDeleting != null)
            {
                CancelEventArgs e = new CancelEventArgs();
                DocumentDeleting(this, e);

                if (e.Cancel)
                {
                    return;
                }
            }

            if (!DocumentHandler.LockDocument())
            {
                // document could not be locked, so do not continue
                return;
            }

            // first ask, if user really wants to delete?
            if (!KissMsg.ShowQuestion(
                CLASSNAME,
                "ConfirmDeleteDocument",
                "Soll dieses Dokument gelöscht werden?\r\n\r\n" +
                "Achtung: Falls Sie mit ja antworten, kann dieses Dokument nicht wiederhergestellt werden!"
            ))
            {
                // unlock the document again, because deleting will not be executed
                DocumentHandler.UnlockDocument(false);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                DocumentHandler.QryXDocument.BeforeDelete -= qryXDocument_BeforeDelete;
                DocumentHandler.QryXDocument.BeforeDelete += qryXDocument_BeforeDelete;

                DocumentHandler.DeleteDocumentFromDB();
                DocumentID = null;

                RefreshDisplay();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            // notify if any assigned
            if (DocumentDeleted != null)
            {
                DocumentDeleted(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called when [button import doc].
        /// </summary>
        private void OnButtonImportDoc()
        {
            _logger.Debug("Start with document import");

            try
            {
                SetAllowPositionChanging(false);

                if (DataSource != null && !DataSource.CanUpdate)
                {
                    KissMsg.ShowInfo(CLASSNAME, "DokImportierenNichtMoeglich", "Das Dokumentfeld ist schreibgeschützt. Es kann kein Dokument importiert werden.");
                    return;
                }

                // check if the document is still in use
                if (DocumentIsStillInUse(false))
                {
                    return;
                }

                if (DocumentImporting != null)
                {
                    CancelEventArgs e = new CancelEventArgs();
                    DocumentImporting(this, e);

                    if (e.Cancel)
                    {
                        return;
                    }
                }

                // choose a new file to import
                OpenFileDialog dlg = new OpenFileDialog();

                if (DokTypCode == DokTyp.Dokument)
                {
                    dlg.Filter = KissMsg.GetMLMessage(
                        CLASSNAME,
                        "DokTypDokumentDialogList_V02",
                        "Word/Excel-Dokumente (*.doc,*.docx,*.docm,*.xls,*.xlsx,*.xlsm)|*.doc;*.docx;*.docm;*.xls;*.xlsx;*.xlsm|" +
                        "Acrobat-Dokumente (*.pdf)|*.pdf|Alle Dokumente (*.*)|*.*");
                }
                else
                {
                    dlg.Filter = KissMsg.GetMLMessage(
                        CLASSNAME,
                        "DokTypTemplateDialogList_V02",
                        "KiSS-Vorlagen|*.doc;*.docx;*.docm;*.xls;*.xlsx;*.xlsm;*.dot;*.dotx;*.dotm;*.xlt;*.xltx;*.xltm|" +
                        "Word/Excel-Dokumente (*.doc,*.docx,*.docm,*.xls,*.xlsx,*.xlsm)|*.doc;*.docx;*.docm;*.xls;*.xlsx;*.xlsm|" +
                        "Word/Excel-Vorlagen (*.dot,*.dotx,*.dotm,*.xlt,*.xltx,*.xltm)|*.dot;*.dotx;*.dotm;*.xlt;*.xltx;*.xltm"
                   );
                }

                if (dlg.ShowDialog(KissForm.GetKissMainForm()) != DialogResult.OK)
                {
                    _logger.Debug("User aborted document import");
                    // stop watcher, delete file, unlock an release file and document
                    //_documentHandler.DestroyWatcherAndDeleteFileAndUnlock(false, false);
                    RefreshDisplay();
                    return;
                }

                // Process Window Messages
                ApplicationFacade.DoEvents();

                // Check, if master row can be posted (e.g. all must fields are filled, ...)
                if (!PerformDataSourcePost(true))
                {
                    return;
                }

                object docID = DBNull.Value;

                if (DocumentHandler == null)
                {
                    if (DokTypCode == DokTyp.Template && DataSource != null)
                    {
                        // using XDocTemplate
                        docID = DataSource["DocTemplateID"];
                    }
                    else if (DataSource != null)
                    {
                        // using XDocument
                        docID = DataSource[DataMember];
                    }

                    DocumentID = docID;

                    // create a new handler, might be empty, when no document exists
                    DocumentHandler = XDocFileHandler.CreateHandlerImportToDB(docID, "", (DokTypCode == DokTyp.Template));
                    DocumentHandler.DocumentLocked += docFileHandler_DocumentLocked;
                    DocumentHandler.DocumentUnlocked += docFileHandler_DocumentUnlocked;
                }
                else
                {
                    // refesh in order to be up to date
                    DocumentHandler.RefreshDocument();

                    if (HasDBConflict && DataSource != null)
                    {
                        // This error occurs, when the corresponding document does not exist in XDocument
                        // e.g. this happens, when a DOC-DB was not copied while copying the master DB
                        // we immediately eliminate the conflict by deleting the non existing key value
                        int tmpID = Convert.ToInt32(DataSource[DataMember]);
                        DataSource[DataMember] = DBNull.Value;
                        DataSource.Post();

                        string msg = KissMsg.GetMLMessage(
                            CLASSNAME,
                            "CorrectingDBConflict_v01",
                            "Das Dokument mit der ID = {0} konnte nicht gefunden werden.\r\n" +
                            "Die Referenz wurde gelöscht, das Dokument kann nicht mehr geöffnet werden.\r\n" +
                            "Starten Sie den Import nochmals."
                        );

                        KissMsg.ShowInfo(string.Format(msg, tmpID.ToString()));

                        DocumentID = DBNull.Value;
                        RefreshDisplay();
                        return;
                    }
                }

                RefreshDisplay();

                // checks existing lockings and show a message
                if (!DocumentHandler.CheckForLockingsImport())
                {
                    return;
                }

                if (!DocumentHandler.LockDocument())
                {
                    // locking document failed (probably locked meanwhile), so do nothing
                    RefreshDisplay();
                    return;
                }

                RefreshDisplay();

                // Process Window Messages
                ApplicationFacade.DoEvents();

                // check only WORD and EXCEL are allowed within templates
                var extension = Path.GetExtension(dlg.FileName);
                if (extension != null)
                {
                    string newExt = extension.ToLower();

                    if (DokTypCode == DokTyp.Template)
                    {
                        if (!(// only WORD templates or documents...
                             newExt.EndsWith(".dot") ||
                             newExt.EndsWith(".dotx") ||
                             newExt.EndsWith(".dotm") ||
                             newExt.EndsWith(".doc") ||
                             newExt.EndsWith(".docx") ||
                             newExt.EndsWith(".docm") ||
                            // ... or EXCEL templates or documents
                             newExt.EndsWith(".xlt") ||
                             newExt.EndsWith(".xltx") ||
                             newExt.EndsWith(".xltm") ||
                             newExt.EndsWith(".xls") ||
                             newExt.EndsWith(".xlsm") ||
                             newExt.EndsWith(".xlsx")))
                        {
                            KissMsg.ShowInfo(
                                CLASSNAME,
                                "NurWordExcel_V02",
                                "Nur Word-Dokumente/-Vorlagen (*.doc/.docx/.docm,*.dot/.dotx/.dotm) und Excel-Dokumente/-Vorlagen (*.xls/.xlsx/.xlsm, *.xlt/.xltx/.xltm) werden unterstützt!"
                                );

                            // stop watcher, delete file, unlock an release file and document
                            DocumentHandler.DestroyWatcherAndDeleteFileAndUnlock(false, false);
                            RefreshDisplay();
                            return;
                        }

                        if (newExt.EndsWith(".dot") || newExt.EndsWith(".dotx") || newExt.EndsWith(".xlt") || newExt.EndsWith(".xltx"))
                        {
                            KissMsg.ShowInfo(
                                CLASSNAME,
                                "MakrosAusVorlagen_V01",
                                "Hinweis: Makros in Word- und Excel-Vorlagen (*.dot/.dotx,*.xlt/.xltx) werden beim Dokument-Erstellen nicht übernommen."
                                );
                        }
                    }
                }

                // we're importing to XDocument or XDocTemplate
                ImportFile(dlg.FileName);

                // stop watcher, delete file, unlock an release file and document
                DocumentHandler.DestroyWatcherAndDeleteFileAndUnlock(false, false);

                if (_dokTypCode == DokTyp.Template && DataSource != null)
                {
                    // save immediately after importing
                    DataSource.RowModified = true;
                    DataSource.Post(); // no silent post here!
                }

                // refresh the Document, if not, e.g. file extension is not correctly set
                DocumentHandler.OpenDocument();

                // changes button icons, hints
                RefreshDisplay();
                OnDocumentImported();
            }
            finally
            {
                SetAllowPositionChanging(true);
            }
        }

        /// <summary>
        /// Called when [button new doc].
        /// </summary>
        private void OnButtonNewDoc()
        {
            try
            {
                SetAllowPositionChanging(false);

                if (DataSource != null && !DataSource.CanUpdate)
                {
                    KissMsg.ShowInfo(CLASSNAME, "DokErstellenNichtMoeglich", "Das Dokumentfeld ist schreibgeschützt. Es kann kein neues Dokument angelegt werden");
                    return;
                }

                if (_dokTypCode == DokTyp.Template)
                {
                    // invalid action in template mode
                    // coding error, do not translate
                    KissMsg.ShowInfo("Programmierfehler: Bei Vorlagen können keine neuen Dokumente angelegt werden.");
                    return;
                }

                // check if the document is still in use
                if (DocumentIsStillInUse(false))
                {
                    return;
                }

                if (DocumentCreating != null)
                {
                    CancelEventArgs e = new CancelEventArgs();
                    DocumentCreating(this, e);

                    if (e.Cancel)
                    {
                        return;
                    }
                }

                // Check, if master row can be posted (e.g. all must fields are filled, ...)
                if (!PerformDataSourcePost(true))
                {
                    return;
                }

                DlgNewDocument dlg = new DlgNewDocument();

                if (!dlg.NewDocument(KissForm.GetKissMainForm(), Context))
                {
                    return;
                }

                // der Benutzer hat ein Dokument Template ausgewählt.
                DlgDocTemplateID = (int)dlg["DocTemplateID"];
                DlgDokFormat = (DokFormat)dlg["DocFormatCode"];
                DlgFileExtension = (string)dlg["FileExtension"];
                DlgShowBookmarkErrors = dlg.ShowBookmarkErrors;
                dlg.Dispose();

                ApplicationFacade.DoEvents();

                // Check, if master row can be posted (e.g. all must fields are filled, ...)
                if (!PerformDataSourcePost(true))
                {
                    return;
                }

                switch (DlgDokFormat)
                {
                    case DokFormat.Word:
                        Cursor.Current = Cursors.WaitCursor;

                        DlgProgressLog.Show(
                            KissMsg.GetMLMessage(
                                CLASSNAME,
                                "NeuesDokErstellen",
                                "Fortschritt: Neues Word-Dokument erstellen"
                            ),
                            500, 300,
                            WordProgressStart,
                            WordProgressClose,
                            Session.MainForm
                        );
                        break;

                    case DokFormat.Excel:
                        Cursor.Current = Cursors.WaitCursor;

                        DlgProgressLog.Show(
                            KissMsg.GetMLMessage(
                                CLASSNAME,
                                "NeuesExcelDokErstellen",
                                "Fortschritt: Neues Excel-Dokument erstellen"
                            ),
                            500, 300,
                            ExcelProgressStart,
                            ExcelProgressClose,
                            Session.MainForm
                        );
                        break;

                    default:
                        //refresh control
                        DocumentID = null;
                        object checkoutUserID = DBNull.Value;
                        object checkOutDate = DBNull.Value;
                        object checkOutFilename = DBNull.Value;
                        object checkOutMachine = DBNull.Value;

                        if (DoDocumentLock)
                        {
                            checkoutUserID = Session.User.UserID;
                            checkOutDate = DateTime.Now;
                            checkOutFilename = DocumentHandler.CurrentDocument.FullName;
                            checkOutMachine = Environment.MachineName;
                        }

                        DocumentID = DBUtil.ExecuteScalarSQL(@"
                        INSERT INTO dbo.XDocument (DocTemplateID, DateCreation, UserID_Creator, DateLastSave, FileBinary,
                            DocFormatCode, FileExtension, CheckOut_UserID, CheckOut_Date,
                            CheckOut_Filename, CheckOut_Machine)
                        SELECT DocTemplateID     = DOC.DocTemplateID,
                            DateCreation      = GETDATE(),
                            UserID_Creator    = {1},
                            DateLastSave      = GETDATE(),
                            FileBinary        = DOC.FileBinary,
                            DocFormatCode     = DOC.DocFormatCode,
                            FileExtension     = ISNULL('.' + LOWER(TYP.Value1), DOC.FileExtension),
                            CheckOut_UserID   = {2},
                            CheckOut_Date     = {3},
                            CheckOut_Filename = {4},
                            CheckOut_Machine  = {5}
                        FROM dbo.XDocTemplate DOC --(not here!) WITH (READUNCOMMITTED)
                        LEFT JOIN dbo.XLOVCode TYP WITH (READUNCOMMITTED)
                            ON TYP.LOVName = 'DocFormat' AND TYP.Code = DOC.DocFormatCode
                            WHERE DOC.DocTemplateID = {0}

                        SELECT SCOPE_IDENTITY()",
                            DlgDocTemplateID,
                            Session.User.UserID,
                            checkoutUserID,
                            checkOutDate,
                            checkOutFilename,
                            checkOutMachine
                        );
                        break;
                }

                // check if we have a valid document handler
                if (DocumentHandler == null)
                {
                    // logging
                    _logger.Info("documentHandler is null, probably canceled by user interaction");

                    // refresh to ensure proper display
                    RefreshDisplay();
                    return;
                }

                if (DoDocumentLock)
                {
                    // remember, we locked on insert statement directly
                    DocumentHandler.IsLockedByCurrentUser = true;
                }

                RefreshDisplay();
                OnDocumentIDChanged();

                ApplicationFacade.DoEvents();

                // force save record
                if (DataSource != null && !DataSource.IsEmpty)
                {
                    // force KISS to post:
                    DataSource.RowModified = true;
                    DataSource.Post();  // no silent post here!
                }

                if (DocumentCreated != null)
                {
                    DocumentCreated(this, EventArgs.Empty);
                }

                // check if we have a document-handler (on error, this may be null)
                if (!IsDocumentEmpty())
                {
                    DocumentHandler.DestroyWatcherAndDeleteFileAndUnlock(true, true);
                    RefreshDisplay();

                    // now Open Document
                    OnButtonOpenDoc(true);
                }
                else if (
                    DocumentHandler != null &&
                    !DBUtil.IsEmpty(DocumentHandler.DocumentID) &&
                    DocumentHandler.IsLockedByCurrentUser
                )
                {
                    // here a unlocking is required, due to possible errors above
                    DocumentHandler.UnlockDocument(false);
                    RefreshDisplay();
                }
            }
            finally
            {
                SetAllowPositionChanging(true);
            }
        }

        /// <summary>
        /// Called when the 'Open Button' is pressed. Basically opens an existing
        /// word document or a word template in MS Word.
        /// </summary>
        private void OnButtonOpenDoc(bool isInserting)
        {
            var isAdded = DataSource != null && (DataSource.CurrentRowState == DataRowState.Added);

            if (IsDocumentEmpty() && !(DokTypCode == DokTyp.Template && isAdded))
            {
                // on new template rows or empty document, we cannot open a document
                return;
            }

            // check if the document is still in use
            if (DocumentIsStillInUse(isInserting))
            {
                return;
            }

            // in order o be up to date, e.g.: import, then click immediately on the open doc button
            if (isInserting)
            {
                // coming from creating a new document from a template,
                // we have to fully re-create qryXDocument
                DocumentHandler.OpenDocument();
            }
            else
            {
                // coming from the open button, we only can refresh qryXDocument
                DocumentHandler.RefreshDocument();
            }

            if (isInserting)
            {
                // coming from inserting, the document is already locked, we take care of this here
                DocumentHandler.WasAlreadyLockedOnEditing = false;
                DocumentHandler.IsLockedByCurrentUser = true;
            }

            RefreshDisplay();

            if (DocumentOpening != null)
            {
                CancelEventArgs e = new CancelEventArgs();
                DocumentOpening(this, e);

                if (e.Cancel)
                {
                    return;
                }
            }

            // if a file already exists, we make a backup copy of it
            // if failing, we do not continue
            if (!CheckForExistingFiles())
            {
                return;
            }

            // check if file is writeable
            bool writeable = IsDocumentWriteable();
            bool readOnlyInfoWasShown = false;

            if (DokTypCode == DokTyp.Dokument && writeable && DoDocumentLock)
            {
                // clicking a second time on the open button after saving a document,
                // the qryXDocument has to be refreshed:
                DocumentHandler.RefreshDocument();
                RefreshDisplay();
            }

            // checking, if the document is locked
            if (writeable && DoDocumentLock && !isInserting && DocumentHandler.WasAlreadyLockedOnEditing)
            {
                // if the document is locked ...
                bool askForUnlocking = false;
                string msg;
                bool userMayUnlock = DBUtil.UserHasRight("XDocument_Entsperren");

                if (Session.User.UserID != DocumentHandler.CheckoutUserID &&
                    DocumentHandler.CheckoutFullFilename == DocumentHandler.ActualFileFullName &&
                    File.Exists(DocumentHandler.CheckoutFullFilename) &&
                    !FileIsOpenOrProcessIsActive())
                {
                    // ... by another user, same file, file is not in use
                    msg = KissMsg.GetMLMessage(
                        CLASSNAME,
                        "FileLockedOtherUserFileNotInUse",
                        "Die Datei ist als \"in Bearbeitung\" gekennzeichnet (nicht in Verwendung)."
                    );

                    if (userMayUnlock)
                    {
                        // when User is Admin or has right, ask for unlocking
                        askForUnlocking = true;
                    }
                }
                else if (Session.User.UserID != DocumentHandler.CheckoutUserID &&
                         DocumentHandler.CheckoutFullFilename == DocumentHandler.ActualFileFullName &&
                         File.Exists(DocumentHandler.CheckoutFullFilename) &&
                         FileIsOpenOrProcessIsActive())
                {
                    // ... by another user, same file, file is in use
                    // thus, nobody can open it
                    msg = KissMsg.GetMLMessage(
                        CLASSNAME,
                        "FileLockedOtherUserFileInUse",
                        "Die Datei ist als \"in Bearbeitung\" gekennzeichnet (in Verwendung)."
                    );
                }
                else if (Session.User.UserID != DocumentHandler.CheckoutUserID)
                {
                    // ... by another user, all other cases
                    msg = DocumentHandler.CheckOutMesssageOtherUser;
                    if (userMayUnlock)
                    {
                        // when User is Admin or has right, ask for unlocking
                        askForUnlocking = true;
                    }
                }
                else if (Session.User.UserID == DocumentHandler.CheckoutUserID &&
                         DocumentHandler.CheckoutFullFilename == DocumentHandler.ActualFileFullName &&
                         File.Exists(DocumentHandler.CheckoutFullFilename) &&
                         !FileIsOpenOrProcessIsActive())
                {
                    // ... by the actual user, same file, the file exists, file is not open
                    msg = KissMsg.GetMLMessage(
                        CLASSNAME,
                        "FileLockedSameUserFileNotInUse",
                        "Die Datei ist durch Sie selbst als \"in Bearbeitung\" gekennzeichnet (nicht in Verwendung)."
                    );

                    // so the document cannot be opened a second time
                    askForUnlocking = true;
                }
                else if (Session.User.UserID == DocumentHandler.CheckoutUserID &&
                         DocumentHandler.CheckoutFullFilename == DocumentHandler.ActualFileFullName &&
                         !File.Exists(DocumentHandler.CheckoutFullFilename))
                {
                    // ... by the actual user, same file, the file exists, file is not open
                    msg = KissMsg.GetMLMessage(
                        CLASSNAME,
                        "FileLockedSameUserFileNotExists",
                        "Die Datei ist durch Sie selbst als \"in Bearbeitung\" gekennzeichnet.\r\n" +
                        "Die Datei ist auf Ihrem PC nicht mehr vorhanden."
                    );
                    // so the document cannot be opened a second time
                    askForUnlocking = true;
                }
                else
                {
                    // ... by the actual user, all other cases
                    msg = DocumentHandler.CheckOutMesssageActualUser;
                    // own documents can be unlocked
                    askForUnlocking = true;
                }

                // gets the checkout message (user, time, file, machine)
                string checkoutMsg = DocumentHandler.CheckOutMesssage;
                string msgAll = msg + "\r\n\r\n" + checkoutMsg + "\r\n\r\n";

                if (askForUnlocking)
                {
                    // ask for unlocking
                    string msgCheckIn;

                    if (Session.User.UserID == DocumentHandler.CheckoutUserID)
                    {
                        msgCheckIn = KissMsg.GetMLMessage(
                            CLASSNAME,
                            "FileUnLockingQuestionOwnFile",
                            "Wollen Sie die Datei freigeben, um sie zu bearbeiten?"
                            );
                    }
                    else
                    {
                        msgCheckIn = KissMsg.GetMLMessage(
                            CLASSNAME,
                            "FileUnLockingQuestion",
                            "Falls Sie sicher sind, dass jetzt niemand die Datei bearbeitet, können Sie die Datei freigeben.\r\n" +
                            "Wollen Sie die Datei freigeben, um sie zu bearbeiten?"
                            );
                    }

                    if (KissMsg.ShowQuestion(msgAll + msgCheckIn))
                    {
                        // YES, Unlock the document now ...
                        // first we make sure, no other user is editing the row
                        if (!PerformDataSourcePost(true))
                        {
                            return;
                        }

                        // unlock now
                        if (!DocumentHandler.UnlockDocument(true))
                        {
                            RefreshDisplay();
                            return;
                        }

                        //writeable = true;
                        RefreshDisplay();

                        XLog.Create(GetType().FullName, 1, LogLevel.INFO, msgAll + msgCheckIn + " JA", "UnlockDocument", DBO.XDocument.DBOName, DocumentHandler.DocumentID as int? ?? -1, true, Session.User.UserID);
                    }
                    else
                    {
                        // NO, open in readonly modus
                        writeable = false;
                    }
                }
                else
                {
                    // document cannot be opened at all
                    string msgError = KissMsg.GetMLMessage(
                        CLASSNAME,
                        "FileLockedNoOpeningTwice",
                        "Die Datei kann nicht ein zweites Mal geöffnet werden."
                    );
                    KissMsg.ShowInfo(msgAll + msgError);

                    return;
                }
            }

            if (writeable && !isInserting && DoDocumentLock && !DocumentHandler.IsLockedByCurrentUser)
            {
                // Lock the current document immediately
                if (!DocumentHandler.LockDocument())
                {
                    return;
                }

                // refresh and set flags
                RefreshDisplay();
                DocumentHandler.CanUpdate = writeable;

                // for templates we have to make sure to save other fields to the DB
                if (DokTypCode == DokTyp.Template && DataSource != null)
                {
                    DataSource.RowModified = true;
                }
            }

            if (!writeable && !readOnlyInfoWasShown)
            {
                // get current fileending
                string fileEnding = Convert.ToString(DocumentHandler["FileExtension"]);

                // when new template documenthandler["FileExtension"] delivers empty string
                // thus we check this here:
                if (string.IsNullOrEmpty(fileEnding))
                {
                    fileEnding = DocumentHandler.NewExtension;
                }

                // check if document is writeable
                bool suppressReadonlyMessage = SuppressReadonlyMessageForFileType(fileEnding);

                if (suppressReadonlyMessage == false)
                {
                    // in order to inform the user ... :
                    // if not, he will be confused, when he cannot save the file
                    KissMsg.ShowInfo(
                        CLASSNAME,
                        "FileLockedOpenNoEditing_v02",
                        "Die gewünschte Datei wird nur zur Ansicht geöffnet.\r\n\r\n" +
                        "Hinweis: Veränderungen an der Datei werden nicht in KiSS gespeichert."
                    );
                }
            }

            bool hasException = false;
            try
            {
                // remove event handlers
                DocumentHandler.DocumentSaved -= docFileHandler_DocumentSaved;
                DocumentHandler.DocumentLocked -= docFileHandler_DocumentLocked;
                DocumentHandler.DocumentUnlocked -= docFileHandler_DocumentUnlocked;

                // logging
                _logger.DebugFormat(
                    "calling now documentHandler.DBToFile and start writing documentID '{0}' as writeable='{1}'",
                    DocumentID,
                    writeable
                );

                // get file from database and open file
                DocumentHandler.DBToFile(writeable, true, false);

                // if document can be changed, attach event handlers
                if (writeable)
                {
                    DocumentHandler.DocumentSaved += docFileHandler_DocumentSaved;
                    DocumentHandler.DocumentLocked += docFileHandler_DocumentLocked;
                    DocumentHandler.DocumentUnlocked += docFileHandler_DocumentUnlocked;
                }
            }
            catch (ZipException ex)
            {
                // logging
                _logger.Warn("catched ZipException", ex);
                // show message
                KissMsg.ShowInfo(ex.Message);

                // done
                hasException = true;
            }
            catch (KissCancelException ex)
            {
                // logging
                _logger.Debug("catched KissCancelException, will not show error message", ex);

                // done
                hasException = true;
            }
            catch (Exception ex)
            {
                // logging
                _logger.Error("catched Exception", ex);

                // quit application if no more documents open
                DocumentHandler.QuitApplication();

                // show message
                KissMsg.ShowError(
                    CLASSNAME,
                    "FehlerDokumentOeffnen_v01",
                    "Es ist ein Fehler beim Öffnen des Dokuments aufgetreten.",
                    ex.Message,
                    ex
                );

                // done
                hasException = true;
            }

            if (hasException)
            {
                // unlock document stop the watcher, again
                // setting the parameter isInserting to FALSE here, we force the unlock of the document
                DocumentHandler.DestroyWatcherAndDeleteFileAndUnlock(true, false);
                RefreshDisplay();
            }
        }

        /// <summary>
        /// Called when [document ID changed].
        /// </summary>
        private void OnDocumentIDChanged()
        {
            if (!IsDocumentEmpty() && !DBUtil.IsEmpty(DocumentHandler["DocFormatCode"]))
            {
                DokFormatCode = (DokFormat)DocumentHandler["DocFormatCode"];
            }

            RefreshDisplay();

            if (DocumentIDChanged != null)
            {
                DocumentIDChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Informs registered entities about DocumentImported.
        /// </summary>
        private void OnDocumentImported()
        {
            if (DocumentImported != null)
            {
                DocumentImported(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called when [document ID changed].
        /// </summary>
        private void OnDokFormatCodeChanged()
        {
            if (DokFormatCodeChanged != null)
            {
                DokFormatCodeChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called when [document ID changed].
        /// </summary>
        private void OnEditModeChanged()
        {
            if (EditModeChanged != null)
            {
                EditModeChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called when the Control should refresh itself.
        /// </summary>
        private void OnRefreshGui()
        {
            if (RefreshGui != null)
            {
                RefreshGui(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// To set the flag DataSource.AllowPositionChanging
        /// </summary>
        /// <param name="allowSelectionChanging"></param>
        private void SetAllowPositionChanging(bool allowSelectionChanging)
        {
            if (DataSource != null)
            {
                DataSource.AllowSelectionChanging = allowSelectionChanging;
            }
        }

        /// <summary>
        /// Called on Word Progress Close
        /// </summary>
        private void WordProgressClose()
        {
            if (WordDoc != null)
            {
                WordDoc.MakeWordVisible();
            }
        }

        /// <summary>
        /// Creates a new Document based on a Template.
        /// </summary>
        private void WordProgressStart()
        {
            XDocFileHandler templateHandler = null;
            WordDoc wordDocTemplate = null;
            DocumentHandler = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DlgProgressLog.ShowTopMost();

                // Save Template (.dot) as Document (.doc) to local drive
                DlgProgressLog.AddLine(KissMsg.GetMLMessage(CLASSNAME, "VorlageLaden", "Word-Vorlage laden"));

                // wenn ein von einer Vorlage erstelltes Dokument gespeichert werden soll,
                // muss das neue File mit der Endung "doc" bzw. "docx" gespeichert werden.
                templateHandler = XDocFileHandler.CreateTemplateExportHandler(DlgDocTemplateID, DlgFileExtension);
                string oldFileName = templateHandler.ActualFileFullName;
                string oldExt = Path.GetExtension(DlgFileExtension);
                string newExt = MapWordExtension(oldExt);
                string newFileName = Path.ChangeExtension(oldFileName, newExt);

                // create new Word doc, get bookmarks filled according to given context
                DlgProgressLog.AddLine(KissMsg.GetMLMessage(
                    CLASSNAME,
                    "DokumentErzeugen",
                    "Word-Dokument erzeugen"
                ));

                // Wahr, falls Word-Dokumente anhand von Word-Dokumenten erstellt werden (und nicht anhand von Vorlagen)
                var isDoc = oldExt != null && (oldExt.Equals(".doc") || oldExt.Equals(".docx") || oldExt.Equals(".docm"));
                if (!isDoc)
                {
                    // neues Dokument aus einer Vorlage erstellen
                    // zuerst die Vorlage öffnen ...
                    wordDocTemplate = new WordDoc(
                        templateHandler.FileInfo,
                        KissContext
                    );
                }

                // ... dann daraus ein neue Dokument erstellen
                WordDoc = new WordDoc(
                    templateHandler.FileInfo,
                    KissContext,
                    !isDoc, // isCreatingFromTemplate: Bei Dokumenten muss der Wert wahr sein, ansonsten verschwinden die Makros im Dokument
                    false, // isreadOnly
                    null, // documentID
                    newFileName
                );

                // Save new Word doc in DB
                DlgProgressLog.AddLine(KissMsg.GetMLMessage(
                    CLASSNAME,
                    "DokumentSpeichern",
                    "Word-Dokument speichern"
                ));

                // neues Dokument jetzt in die DB speichern
                DocumentHandler = XDocFileHandler.CreateHandlerImportToDB(DBNull.Value, newExt, false);
                DokFormatCode = DokFormat.Word;
                DocumentHandler.FileToDB(new FileInfo(newFileName));
                DocumentHandler["DocTemplateID"] = DlgDocTemplateID;
                DocumentHandler["DateCreation"] = DateTime.Now;
                DocumentHandler["DateLastSave"] = DateTime.Now;

                if (DoDocumentLock)
                {
                    DocumentHandler["CheckOut_UserID"] = Session.User.UserID;
                    DocumentHandler["CheckOut_Date"] = DateTime.Now;
                    DocumentHandler["CheckOut_Filename"] = newFileName;
                    DocumentHandler["CheckOut_Machine"] = Environment.MachineName;
                }

                DocumentHandler.Post();

                if (wordDocTemplate != null)
                {
                    wordDocTemplate.CloseDocument();
                    wordDocTemplate.QuitWord();
                    wordDocTemplate = null;
                }

                templateHandler.DestroyWatcherAndDeleteFileAndUnlock(true, false);
                templateHandler = null;

                WordDoc.CloseDocument();
                WordDoc.QuitWord();

                if (!DlgShowBookmarkErrors || !DlgProgressLog.HasErrors)
                {
                    DlgProgressLog.CloseDialog();
                }
                else
                {
                    // Keep Progress dialog open and display the new doc after the user quits the dialog
                    DlgProgressLog.AddLine(KissMsg.GetMLMessage(
                        CLASSNAME,
                        "ErledigtMitFehler",
                        "Erledigt (Es sind Fehler aufgetreten)"
                    ));
                    DlgProgressLog.EndProgress();
                    DlgProgressLog.ShowTopMost();
                }
            }
            catch (CancelledByUserException ex)
            {
                _logger.Warn(ex);
                DlgProgressLog.CloseDialog();
            }
            catch (ZipException ex)
            {
                _logger.Warn(ex);
                DlgProgressLog.CloseDialog();
                KissMsg.ShowInfo(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
                DlgProgressLog.CloseDialog();
                KissMsg.ShowError(
                    CLASSNAME,
                    "FehlerDokumentErzeugen",
                    "Fehler beim Erzeugen des neuen Word-Dokuments\r\n\r\n",
                    ex.Message,
                    ex
                );
            }
            finally
            {
                Cursor.Current = Cursors.Default;

                if (wordDocTemplate != null)
                {
                    wordDocTemplate.CloseDocument();
                    wordDocTemplate.QuitWord();
                }

                if (WordDoc != null)
                {
                    WordDoc.CloseDocument();
                    WordDoc.QuitWord();
                }

                if (templateHandler != null)
                {
                    templateHandler.DestroyWatcherAndDeleteFileAndUnlock(true, true);
                }
            }
        }

        #endregion

        #endregion
    }
}