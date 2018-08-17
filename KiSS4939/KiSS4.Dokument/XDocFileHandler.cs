using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kiss.Infrastructure.Document;
using Kiss.Interfaces.DocumentHandling;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Dokument.ExcelAutomation;
using KiSS4.Dokument.Utilities;
using KiSS4.Dokument.WordAutomation;
using KiSS4.Gui;

namespace KiSS4.Dokument
{
    /// <summary>
    /// Summary description for XDocFileHandler.
    /// </summary>
    public class XDocFileHandler : IKissPersistentObject
    {
        #region Fields

        #region Internal Fields

        /// <summary>
        /// Retrieve a stored document from database.
        /// </summary>
        internal SqlQuery QryXDocument;

        #endregion

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly string _msgAktuell = KissMsg.GetMLMessage("XDocument", "FileLockedActualMachinename_v01", "aktuell");

        /// <summary>
        /// Info: do not change message name without changing error Message in spXDocument_Lock
        /// </summary>
        private static readonly string _msgBenutzer = KissMsg.GetMLMessage("XDocument", "FileLockedUsername_v01", "Benutzer/in");

        private static readonly string _msgDatei = KissMsg.GetMLMessage("XDocument", "FileLockedFilename_v01", "Datei");
        private static readonly string _msgDatum = KissMsg.GetMLMessage("XDocument", "FileLockedDate_v01", "Datum");
        private static readonly string _msgRechner = KissMsg.GetMLMessage("XDocument", "FileLockedMachinename_v01", "Rechner");

        private static readonly string _strCheckOutMesssageActualUser = KissMsg.GetMLMessage(
            "XDocument",
            "FileIsLockedByActualUser",
            "Die Datei ist durch Sie selbst als \"in Bearbeitung\" gekennzeichnet."
        );

        private static readonly string _strCheckOutMesssageOtherUser = KissMsg.GetMLMessage(
            "XDocument",
            "FileIsLockedByAnotherUser",
            "Die Datei ist als \"in Bearbeitung\" gekennzeichnet."
        );

        private static readonly string _strNolockingMessage = KissMsg.GetMLMessage(
            "XDocument",
            "FileCannotBeLocked",
            "Die Datei konnte nicht als \"in Bearbeitung\" gekennzeichnet werden."
        );

        private static readonly string _strUserNotFound = KissMsg.GetMLMessage(
            "XDokument",
            "FileLockedUserNotFound",
            "[Benutzer/in nicht gefunden]"
        );

        #endregion

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "XDocFileHandler";
        private readonly Object _locker;

        #endregion

        #region Private Fields

        /// <summary>
        /// ID des verwendeten Dokuments in XDocument.
        /// </summary>
        private Object _documentID;

        private DocumentWatcher _documentWatcher;
        private ExcelControl _excelControl;
        private string _fileName;

        /// <summary>
        /// Indicates if a new document is being created from a template.
        /// </summary>
        private bool _isCreatingFromTemplate;

        /// <summary>
        /// Determines whether the current document is a template.
        /// </summary>
        private Boolean _isTemplate;

        private DateTime _lastWriteBeforeOpenInExcel;
        private string _newExtension;
        private ProcessLauncher _processWatcher;
        private Boolean _saving;
        private int _wartezeitNachDrucken;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="XDocFileHandler"/> class.
        /// </summary>
        public XDocFileHandler()
        {
            PendingChanges = true;
            _locker = new Object();
            CanUpdate = true;
            IsLockedByCurrentUser = false;
            WasAlreadyLockedOnEditing = false;

            _wartezeitNachDrucken = DBUtil.GetConfigInt(@"System\Dokumentemanagement\WartezeitNachDrucken", 0);
            //sicherstellen, dass Wert positiv ist (sonst wird unendlich lange gewartet)
            if (_wartezeitNachDrucken < 0)
            {
                _wartezeitNachDrucken = 0;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [document locked].
        /// </summary>
        public event EventHandler DocumentLocked;

        /// <summary>
        /// Event rising when document is being saved.
        /// </summary>
        public event EventHandler DocumentSaved;

        /// <summary>
        /// Occurs when [document unlocked].
        /// </summary>
        public event EventHandler DocumentUnlocked;

        #endregion

        #region Properties

        /// <summary>
        /// The local file name for the current document.
        /// </summary>
        public string ActualFileFullName
        {
            get
            {
                if (_fileName == null)
                {
                    _fileName = FileName;
                }

                return Zip.CreateFullName(_fileName, NewExtension);
            }
        }

        /// <summary>
        /// The local file name for the current document.
        /// </summary>
        public string ActualFileName
        {
            get { return _fileName ?? (_fileName = FileName); }
        }

        /// <summary>
        /// The current document can be updated.
        /// </summary>
        public bool CanUpdate
        {
            get;
            set;
        }

        /// <summary>
        /// The checkout datetime of the current document.
        /// </summary>
        public DateTime CheckoutDate
        {
            get
            {
                try
                {
                    // check if we have a row and this row has a checkout-date
                    return Row == null || DBUtil.IsEmpty(Row["Checkout_Date"]) ? DateTime.Now : (DateTime)Row["Checkout_Date"];
                }
                catch (Exception ex)
                {
                    // logging
                    _logger.Warn("Error getting CheckOutDate.", ex);

                    // return as if checkout would be empty
                    return DateTime.Now;
                }
            }
        }

        /// <summary>
        /// The checkout filename of the current document.
        /// </summary>
        public string CheckoutFullFilename
        {
            get
            {
                return Row == null || DBUtil.IsEmpty(Row["Checkout_Filename"]) ? "" : (string)Row["Checkout_Filename"];
            }
        }

        /// <summary>
        /// The checkout machine of the current document.
        /// </summary>
        public string CheckoutMachine
        {
            get
            {
                return Row == null || DBUtil.IsEmpty(Row["Checkout_Machine"]) ? "" : (string)Row["checkout_Machine"];
            }
        }

        /// <summary>
        /// Gets the information of the locking user and the locked file (4 lines).
        /// </summary>
        public string CheckOutMesssage
        {
            get
            {
                // defining checkout message
                return
                    _msgBenutzer + ": " + CheckoutUserName + "\r\n" +
                    _msgDatum + ": " + CheckoutDate.ToString("dd.MM.yyyy HH:mm:ss") + "\r\n" +
                    _msgDatei + ": " + CheckoutFullFilename + "\r\n" +
                    _msgRechner + ": " + CheckoutMachine + " (" + _msgAktuell + " " + Environment.MachineName + ")";
            }
        }

        /// <summary>
        /// Gets the name of the actual user who has checked out the file.
        /// </summary>
        public string CheckOutMesssageActualUser
        {
            get { return _strCheckOutMesssageActualUser; }
        }

        /// <summary>
        /// Gets the name of another user who has checked out the file.
        /// </summary>
        public string CheckOutMesssageOtherUser
        {
            get { return _strCheckOutMesssageOtherUser; }
        }

        /// <summary>
        /// The userID of the current editor of this document.
        /// </summary>
        public int CheckoutUserID
        {
            get
            {
                return Row == null || DBUtil.IsEmpty(Row["CheckOut_UserID"]) ? 0 : (int)Row["CheckOut_UserID"];
            }
        }

        /// <summary>
        /// The userName of the current editor of this document.
        /// </summary>
        public string CheckoutUserName
        {
            get;
            private set;
        }

        /// <summary>
        /// The current document.
        /// </summary>
        public FileInfo CurrentDocument
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the last write/save time of the file.
        /// </summary>
        public DateTime DateLastSave
        {
            get
            {
                return Row == null || DBUtil.IsEmpty(Row["DateLastSave"])
                    ? DateTime.MaxValue : (DateTime)Row["DateLastSave"];
            }
        }

        /// <summary>
        /// Gets the document ID.
        /// </summary>
        /// <value>The document ID.</value>
        public object DocumentID
        {
            get { return _documentID; }
        }

        /// <summary>
        /// Returns the referenced ExcelControl
        /// </summary>
        public ExcelControl Excel
        {
            get { return _excelControl; }
        }

        /// <summary>
        /// Gets the file info.
        /// </summary>
        /// <value>The file info.</value>
        public FileInfo FileInfo
        {
            get { return CurrentDocument; }
        }

        /// <summary>
        /// The local file name for the current document when deleting a file.
        /// </summary>
        public string FileNameDeleted
        {
            get
            {
                // we use 2 tables, one for templates and one for docs
                // in order to get an unique name, we have to take care of this
                string docKey;
                string strID;
                string strUserID = "_uid" + Session.User.UserID.ToString();
                string strTimestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                if (_isTemplate)
                {
                    // using XDocTemplate
                    docKey = "_tpl";

                    if (_documentID != null)
                    {
                        strID = Convert.ToInt32(_documentID).ToString();
                    }
                    else
                    {
                        strID = (Row == null || DBUtil.IsEmpty(Row["DocTemplateID"])
                            ? "NoID" : Convert.ToInt32(Row["DocTemplateID"]).ToString());
                    }
                }
                else
                {
                    // using XDocument
                    docKey = "_doc";

                    if (_documentID != null)
                    {
                        strID = Convert.ToInt32(_documentID).ToString();
                    }
                    else
                    {
                        strID = (Row == null || DBUtil.IsEmpty(Row["DocumentID"])
                            ? "NoID" : Convert.ToInt32(Row["DocumentID"]).ToString());
                    }
                }

                // further we have to take care of different DBs, so we add the database name
                return Session.Connection.Database + docKey + strID + strUserID + "_del" + strTimestamp;
            }
        }

        /// <summary>
        /// Missing datarow in XDocument to given ID in master row.
        /// </summary>
        public bool HasDBConflict
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether the current row is empty.
        /// </summary>
        /// <value><c>true</c> if empty; otherwise, <c>false</c>.</value>
        public bool IsEmpty
        {
            get { return Row == null; }
        }

        /// <summary>
        /// The document was locked by the current user, so it has to be unlocked again.
        /// </summary>
        public bool IsLockedByCurrentUser
        {
            get;
            set;
        }

        /// <summary>
        /// The new extension for the current document.
        /// </summary>
        public string NewExtension
        {
            set { _newExtension = value; }
            get
            {
                // always take the newExtension, if defined
                if (!string.IsNullOrEmpty(_newExtension))
                {
                    return _newExtension;
                }

                // if ROW is null, we can set a undefined value
                if (Row == null)
                {
                    return ".tmp";
                }

                // else return the value stored in the database
                return DBUtil.IsEmpty(Row["FileExtension"]) ? ".tmp" : Convert.ToString(Row["FileExtension"]);
            }
        }

        /// <summary>
        /// Gets a value indicating whether a watcher could be stopped and removed.
        /// </summary>
        /// <value><c>true</c> if document object could be destroyed, otherwise, <c>false</c>.</value>
        public bool ObjectDisposed
        {
            get
            {
                string fileName = "[unbekannt]";
                try
                {
                    bool deleteTheFile = true;
                    if (_processWatcher != null)
                    {
                        deleteTheFile = _processWatcher.deleteTheFileAfterWatching;
                        fileName = ActualFileFullName;
                        _processWatcher.StopWatching();
                    }
                    DestroyWatcherAndDeleteFileAndUnlock(deleteTheFile, false);
                }
                catch (Exception ex)
                {
                    // see also KissMainForm.SavePersistentObjects
                    // do not translate, should never occur
                    // if not, first debug the error
                    // TODO : probably occurred when simulating conflicts with 2 users
                    // TODO : or eventually opening password protected word files without knowing the password
                    // TODO : has to be tested furthermore
                    KissMsg.ShowError(
                        "Fehler in XDocFileHandler.ObjectDisposed:\r\n" +
                        "Beim Schliessen einer Dateiüberwachung ist ein unbekannter Fehler aufgetreten:\r\n" +
                        ex.Message + "\r\n\r\n" +
                        "Datei: " + fileName + "\r\n\r\n" +
                        "Starten Sie KISS neu.",
                        ex);
                }

                // TODO
                // refactor when closing KISS should be stopped
                // introduce value FALSE, too (e.g. for errors)
                // see also KissMainForm.SavePersistentObjects
                return true;
            }
        }

        /// <summary>
        /// Gets some information about the object.
        /// </summary>
        public string ObjectName
        {
            get { return ActualFileFullName; }
        }

        /// <summary>
        /// Gets a value indicating whether the file can be edited.
        /// </summary>
        /// <value><c>true</c> if [pending changes]; otherwise, <c>false</c>.</value>
        public bool PendingChanges
        {
            get;
            private set;
        }

        /// <summary>
        /// The process is locking then document.
        /// </summary>
        public bool ProcessIsLockingDocument
        {
            get
            {
                if (_processWatcher == null)
                {
                    return false;
                }

                return _processWatcher.processIsLockingDocument;
            }
        }

        /// <summary>
        /// The process is still active.
        /// </summary>
        public Boolean ProcessWatcherIsStillActive
        {
            get
            {
                if (_processWatcher == null)
                {
                    return false;
                }

                return _processWatcher.ProcessWatcherIsStillActive;
            }
        }

        /// <summary>
        /// The current document is locked.
        /// </summary>
        public bool WasAlreadyLockedOnEditing
        {
            get;
            set;
        }

        public WordControl Word
        {
            get;
            private set;
        }

        /// <summary>
        /// The local file name for the current document.
        /// </summary>
        private string FileName
        {
            get
            {
                // we use 2 tables, one for templates and one for docs
                // in order to get an unique name, we have to take care of this
                string docKey;
                string strID;
                string strUserID = "_uid" + Session.User.UserID.ToString();

                if (_isTemplate)
                {
                    // using XDocTemplate
                    docKey = "_tpl";
                    if (_documentID != null)
                    {
                        strID = ((int)_documentID).ToString();
                    }
                    else
                    {
                        strID = DBUtil.IsEmpty(Row["DocTemplateID"]) ? "NoID" : ((int)Row["DocTemplateID"]).ToString();
                    }
                }
                else
                {
                    // using XDocument
                    docKey = "_doc";
                    if (_documentID != null)
                    {
                        strID = ((int)_documentID).ToString();
                    }
                    else
                    {
                        strID = DBUtil.IsEmpty(Row["DocumentID"]) ? "NoID" : ((int)Row["DocumentID"]).ToString();
                    }
                }

                string strTimeStamp = "";
                if (_isCreatingFromTemplate)
                {
                    // only used for temporary templates coming from KissButtonEdit
                    // those files never should be saved back to DB
                    DateTime dtNow = DateTime.Now;

                    // earlier implementation
                    //template["DocTemplateName"].ToString() + "_" + new Random(DateTime.Now.Millisecond).Next(1, 9999).ToString());
                    strTimeStamp = "_tmp" + dtNow.ToString("yyyyMMdd_HHmmss") + "ms" + dtNow.Millisecond.ToString();
                }

                // further we have to take care of different DBs, so we add the database name
                return Session.Connection.Database + docKey + strID + strUserID + strTimeStamp;
            }
        }

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <value>The row.</value>
        private DataRow Row
        {
            get
            {
                return (QryXDocument == null) ? null : QryXDocument.Row;
            }
        }

        #endregion

        #region Indexers

        /// <summary>
        /// Indexer. Get or set a value for the specified name.
        /// </summary>
        /// <value></value>
        public object this[string columnName]
        {
            get
            {
                if (IsEmpty) return DBNull.Value;

                try
                {
                    return Row[columnName];
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    return DBNull.Value;
                }
            }
            set
            {
                if (IsEmpty) return;

                try
                {
                    Row[columnName] = value;
                }
                catch (Exception ex)
                {
                    _logger.Error("Column " + columnName + " does not exist", ex);
                    // row could not be set, it probably does not exist in table.
                }
            }
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Handles the FileChanged event of the documentWatcher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void documentWatcher_FileChanged(object sender, EventArgs e)
        {
            _logger.Debug("documentWatcher_FileChanged");
            SaveDocument();
        }

        /// <summary>
        /// Handles the FileCreated event of the documentWatcher control.
        /// The event is actually triggered by saving the pdf documents!
        /// For saving documents Acrobat first deletes files and re-creates them new.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void documentWatcher_FileCreated(object sender, EventArgs e)
        {
            _logger.Debug("documentWatcher_FileCreated");

            if (PendingChanges && (CurrentDocument.Extension.ToUpper() == ".PDF"))
            {
                SaveDocument();
            }
        }

        /// <summary>
        /// Handles the FileDeleted event of the documentWatcher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void documentWatcher_FileDeleted(object sender, EventArgs e)
        {
            _logger.Debug("documentWatcher_FileDeleted");
        }

        /// <summary>
        /// Handles the FileRenamed event of the documentWatcher control.
        /// The event is actually triggered by saving the document in word!
        /// MS Word moves the original file and renames the temporary
        /// working file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void documentWatcher_FileRenamed(object sender, EventArgs e)
        {
            _logger.Debug("documentWatcher_FileRenamed");
            SaveDocument();
        }

        /// <summary>
        /// Handles the ProcessExited event of the zip control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void processWatcher_ProcessExited(object sender, EventArgs e)
        {
            _logger.DebugFormat("File [{0}] is no longer in use", CurrentDocument.FullName);

            // the process is no longer active or the file is no more in use
            // so we can stop the watchers and delete the here
            DestroyWatcherAndDeleteFileAndUnlock(_processWatcher.deleteTheFileAfterWatching, false);
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Creates the file handler.
        /// </summary>
        /// <param name="documentType">Type of the document.</param>
        /// <param name="documentId">The document id.</param>
        /// <param name="extension">The new extension of the document.</param>
        /// <param name="isFromTemplate">True, if a document will be created by using a template.</param>
        /// <returns></returns>
        public static XDocFileHandler CreateFileHandler(DokTyp documentType, Object documentId, string extension, bool isFromTemplate)
        {
            switch (documentType)
            {
                case DokTyp.Dokument:
                    return GetDocumentHandler(documentId, extension, isFromTemplate);

                case DokTyp.Template:
                    return GetTemplateHandler(documentId, extension, isFromTemplate);

                default:
                    throw new ArgumentOutOfRangeException("documentType");
            }
        }

        /// <summary>
        /// Gets the file handler of the specified file to import.
        /// </summary>
        /// <param name="datasourceRowID">The ID of the document or template.</param>
        /// <param name="newExtension">The new extension of the template.</param>
        /// <param name="isATemplate">It is a template.</param>
        /// <returns></returns>
        public static XDocFileHandler CreateHandlerImportToDB(object datasourceRowID, string newExtension, bool isATemplate)
        {
            // only used for importing from File to DB
            XDocFileHandler handler = new XDocFileHandler
            {
                HasDBConflict = false,
                _isCreatingFromTemplate = false,
                _isTemplate = isATemplate,
                _documentID = datasourceRowID,
                _newExtension = newExtension
            };

            handler.OpenDocument();
            return handler;
        }

        /// <summary>
        /// Exports a template file from DB to the local drive.
        /// </summary>
        /// <param name="templateID">The template ID to export (primary key of dbo.XDocTemplate).</param>
        /// <param name="extension">The extension of the file, coming from dbo.XDocTemplate.Extension.</param>
        /// <returns></returns>
        public static XDocFileHandler CreateTemplateExportHandler(object templateID, string extension)
        {
            string msg;

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT FileBinary
                FROM dbo.XDocTemplate
                WHERE DocTemplateID = {0}",
                templateID
            );

            if (qry.Count != 1)
            {
                // no data row found, or several data rows found
                // not unique, so we do not continue
                msg = KissMsg.GetMLMessage(
                    CLASSNAME,
                    "TemplateIDDoesNotExists",
                    "Die Vorlage mit der ID {0} konnte nicht gefunden werden."
                );
                throw new Exception(string.Format(msg, (int)templateID));
            }

            XDocFileHandler handler = new XDocFileHandler
            {
                HasDBConflict = false,
                _isCreatingFromTemplate = true,
                CanUpdate = false,
                _documentID = templateID,
                IsLockedByCurrentUser = false,
                _isTemplate = true,
                WasAlreadyLockedOnEditing = false,
                _newExtension = extension
            };

            handler.CurrentDocument = new FileInfo(handler.ActualFileFullName);

            if (File.Exists(handler.CurrentDocument.FullName))
            {
                // when the file to be creates already exists an cannot be deleted,
                // we do not continue  due to security reasons
                if (Zip.FileIsOpen(handler.ActualFileFullName))
                {
                    msg = KissMsg.GetMLMessage(
                        CLASSNAME,
                        "TemplateExportDeleteFile",
                        "Die Datei {0} konnte nicht gelöscht werden.\r\n" +
                        "Löschen Sie diese Datei manuell oder schliessen Sie die Anwendungen, welche diese Datei verwenden."
                    );

                    throw new Exception(string.Format(msg, handler.ActualFileFullName));
                }

                handler.CurrentDocument.Delete();
            }

            Zip.ExpandDataToFile((byte[])qry["FileBinary"], handler.CurrentDocument);
            return handler;
        }

        /// <summary>
        /// Gets the file handler of the specified file only to view and without import.
        /// </summary>
        /// <param name="viewFileName">The path and name of the to be viewd in word or excel.</param>
        /// <returns></returns>
        public static XDocFileHandler CreateViewHandler(string viewFileName)
        {
            // only used for importing from File to DB
            XDocFileHandler handler = new XDocFileHandler
            {
                HasDBConflict = false,
                _isCreatingFromTemplate = false,
                _isTemplate = false,
                _documentID = null,
                _newExtension = string.Empty,
                CurrentDocument = new FileInfo(viewFileName)
            };
            return handler;
        }

        /// <summary>
        /// Export a file from DB to Filesystem
        /// </summary>
        /// <param name="docID"></param>
        /// <param name="targetPath"></param>
        /// <param name="overwriteExistingFile"></param>
        /// <returns></returns>
        public static FileInfo ExportFromDBToFile(int docID, string targetPath, bool overwriteExistingFile)
        {
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT DocumentID, DateCreation, UserID_Creator, DocReadOnly, DocTemplateID, UserID_LastRead,
                    DateLastRead, UserID_LastSave, DateLastSave, DocTemplateName, DocFormatCode,
                    FileExtension, DocTypeCode, FileBinary, XDocumentTS,
                    CheckOut_UserID, CheckOut_Date, CheckOut_Filename, CheckOut_Machine
                FROM dbo.XDocument
                WHERE DocumentID = {0}",
                docID
            );

            if (qry.Count != 1)
            {
                throw new KissErrorException("Invalid document ID");
            }

            // getting the name of the temporary file
            FileInfo file = new FileInfo(Path.Combine(targetPath, string.Format("{0}{1}", docID, qry["FileExtension"] as string)));

            if (File.Exists(file.FullName) && !overwriteExistingFile)
            {
                return file;
            }

            // logging
            _logger.Debug("expanding data to file, writing file to filesystem");

            // write file
            Zip.ExpandDataToFile((byte[])qry["FileBinary"], file);

            if (qry["DocReadOnly"] as bool? == true)
            {
                file.Attributes = file.Attributes | FileAttributes.ReadOnly;
            }

            return file;
        }

        /// <summary>
        /// Gets the file handler.
        /// </summary>
        /// <param name="fileExtensionOrNull"></param>
        /// <param name="isTemplate">Indicates if the row is a template or not.</param>
        /// <param name="docOrTemplateID"></param>
        /// <returns></returns>
        public static XDocFileHandler GetFileHandler(int docOrTemplateID, string fileExtensionOrNull, Boolean isTemplate)
        {
            XDocFileHandler fileHandler = new XDocFileHandler
            {
                HasDBConflict = false,
                _isCreatingFromTemplate = false,
                _isTemplate = isTemplate,
                _newExtension =
                    DBUtil.IsEmpty(fileExtensionOrNull) ? ".tmp" : fileExtensionOrNull,
                _documentID = docOrTemplateID
            };

            fileHandler.OpenDocument();
            return fileHandler;
        }

        /// <summary>
        /// Gets the file handler.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="isTemplate">Indicates if the row is a template or not.</param>
        /// <returns></returns>
        public static XDocFileHandler GetFileHandler(DataRow row, Boolean isTemplate)
        {
            int docOrTemplateID;

            if (isTemplate)
            {
                // its a row from table XDocTemplate
                docOrTemplateID = (int)row[DBO.XDocTemplate.DocTemplateID];
            }
            else
            {
                // its a row from table XDocument
                docOrTemplateID = (int)row[DBO.XDocument.DocumentID];
            }

            return GetFileHandler(docOrTemplateID, row["FileExtension"] as string, isTemplate);
        }

        /// <summary>
        /// Gets the X document non BLOB field list.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns></returns>
        public static string GetXDocumentNonBlobFieldList(string tableName)
        {
            SqlQuery qry = DBUtil.OpenSQL(
                "SELECT name FROM syscolumns WHERE id = object_id({0}) AND xtype != 34 --image",
                tableName
            );

            StringBuilder sbFieldList = new StringBuilder();
            sbFieldList.AppendFormat("[{0}]", qry["name"]);
            while (qry.Next()) sbFieldList.AppendFormat(", [{0}]", qry["name"]);

            return sbFieldList.ToString();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Checks if document is locked and show a message when locked.
        /// </summary>
        public bool CheckForLockingsImport()
        {
            if (WasAlreadyLockedOnEditing)
            {
                // file is already locked, so leave here with message
                string fileLockedMsg = _strCheckOutMesssageOtherUser;
                // gets the checkout message (user, time, file, machine)
                string checkoutMsg = CheckOutMesssage;
                string msgImport = KissMsg.GetMLMessage(
                    CLASSNAME,
                    "FileLockedNoImport",
                    "Es kann keine neue Datei importiert werden!"
                );
                KissMsg.ShowInfo(fileLockedMsg + "\r\n\r\n" + checkoutMsg + "\r\n\r\n" + msgImport);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if document is locked and show a message when locked.
        /// </summary>
        public bool CheckForLockingsNew()
        {
            if (WasAlreadyLockedOnEditing)
            {
                // file is already locked, so leave here with message
                string fileLockedMsg = _strCheckOutMesssageOtherUser;

                // gets the checkout message (user, time, file, machine)
                string checkoutMsg = CheckOutMesssage;
                string msgImport = KissMsg.GetMLMessage(
                    CLASSNAME,
                    "FileLockedNoNewFile",
                    "Es kann keine neue Datei erstellt werden!"
                );
                KissMsg.ShowInfo(fileLockedMsg + "\r\n\r\n" + checkoutMsg + "\r\n\r\n" + msgImport);
                return false;
            }
            return true;
        }

        public void CloseDocument(DokFormat format)
        {
            if (format == DokFormat.Word)
            {
                Word.CloseActiveDocument();
            }
            else if (format == DokFormat.Excel)
            {
                _excelControl.CloseDocument();
            }
        }

        /// <summary>
        /// Writes DB to file.
        /// </summary>
        /// <param name="readWrite">if set to <c>true</c> [read write].</param>
        /// <param name="startApp">if set to <c>true</c> [start app].</param>
        /// <param name="isDeletingFile">A template is to be deleted, we make a copy of it before.</param>
        /// <returns></returns>
        public FileInfo DBToFile(Boolean readWrite, Boolean startApp, bool isDeletingFile)
        {
            // we stop all watchers here, in order to prevent saving of an older file
            DestroyAllWatchers();

            // getting the name of the temporary file
            string fileName = isDeletingFile ? FileNameDeleted : FileName;

            PendingChanges = readWrite;

            if ((CurrentDocument == null) || !File.Exists(CurrentDocument.FullName))
            {
                if (Zip.FileIsOpen(fileName, NewExtension))
                {
                    if (CurrentDocument == null)
                    {
                        CurrentDocument = Zip.GetLocalFile(fileName, NewExtension);
                    }

                    WindowUtilities.SetWindowToForeground(fileName);
                }
                else
                {
                    CurrentDocument = Zip.GetLocalFile(fileName, NewExtension);

                    if (!CurrentDocument.Exists)
                    {
                        // logging
                        _logger.Debug("expanding data to file, writing file to filesystem");

                        // write file
                        Zip.ExpandDataToFile(GetFileBinary(), CurrentDocument);
                    }
                }

                // RH:
                // Äusserst kritisch: Wenn ein User ein Dok 91 unter 92 speichert,
                // Dok 92 im KISS dann öffnet wird erst mal das falsche File gespeichert.
                // Könnte sein, dass das Conny Stucki gemeldet hat:
                // Ein Dok eines Datensatzes war plötzlich in einem anderen Datensatz
                // Deshalb nehmen wir das hier mal raus ... :
                /*
                if (currentDocument.LastWriteTime > (DateTime)Row["DateLastSave"])
                {
                    // Newer file version detected on disk. We need to save this newer file to the DB asap.
                    SaveDocument();
                    // ... legen aber ein Sicherungskopie an (siehe XDocument.OnOpenDoc):
                }
                */

                if (!_isCreatingFromTemplate)
                {
                    // only store in a persistent object when it's not called from KissDoumentButton
                    if (!Session.PersistentObjects.Contains(this))
                    {
                        Session.PersistentObjects.Add(this);
                    }
                }

                if (!readWrite)
                {
                    //File ReadOnly markieren
                    //Die Schreibweise "| FileAttributes.ReadOnly" darf nur verwendet werden, wenn das FlagSet bereits Werte hat. Sonst muss es normal zugewiesen werden..
                    if (Enum.IsDefined(typeof(FileAttributes), CurrentDocument.Attributes))
                    {
                        CurrentDocument.Attributes = CurrentDocument.Attributes | FileAttributes.ReadOnly;
                    }
                    else
                    {
                        CurrentDocument.Attributes = FileAttributes.ReadOnly;
                    }
                }
            }

            if (startApp)
            {
                OpenDocumentInExternalApplication(readWrite, (DokFormat)Row["DocFormatCode"]);
            }

            return CurrentDocument;
        }

        /// <summary>
        /// Deletes the document.
        /// </summary>
        /// <returns></returns>
        public bool DeleteDocumentFromDB()
        {
            if (_isTemplate || QryXDocument == null)
            {
                // using XDocTemplate
                // the document only can be deleted in the CtlDocTemplate, so do nothing here:
                return true;
            }

            // users some times delete an existing file without wanting it
            // so we make a local copy of the file
            if (!DBUtil.IsEmpty(QryXDocument["FileBinary"]))
            {
                if (!MakeCopyOfFile())
                {
                    return false;
                }
            }

            // delete the row without confirmation
            QryXDocument.DeleteQuestion = null;
            return QryXDocument.Delete("XDocument");
        }

        /// <summary>
        /// Releases all watcher converning the current document.
        /// </summary>
        public void DestroyAllWatchers()
        {
            // clear document watcher
            DestroyDocumentWatcher();

            // clear process watcher
            DestroyProcessWatcher();
        }

        /// <summary>
        /// Stops the watchers, deletes the file and unlock the row
        /// </summary>
        /// <param name="deleteTheFile">The file is to be deleted.</param>
        /// <param name="isInserting">The procedure is called from inserting a document.</param>
        public void DestroyWatcherAndDeleteFileAndUnlock(bool deleteTheFile, bool isInserting)
        {
            // debugging
            _logger.Debug("DestroyWatcherAndDeleteFileAndUnlock: enter");

            // stop and destroy the watcher
            // TODO : when ZIP should be editable, we should not destroy the document watcher here
            // TODO : but no mechnism for ZIP files is found, no process avaiable and file not locked by process
            DestroyAllWatchers();

            if (!_isCreatingFromTemplate)
            {
                // only store in a persistent object when it's not called from KissDoumentButton
                // destroy PersistentObjects
                Session.PersistentObjects.Remove(this);
            }

            // document can only be deleted if flag is set and document is available/not in use
            if (deleteTheFile && CurrentDocument != null)
            {
                //warten
                int waittime = DBUtil.GetConfigInt(@"System\Dokumentemanagement\WartezeitVorLöschen", 0);
                _logger.Debug(string.Format(
                        "DestroyWatcherAndDeleteFileAndUnlock: waiting {0} ms before deleting {1}",
                        waittime,
                        CurrentDocument.FullName
                    ));
                Thread.Sleep(waittime);

                if (!Zip.FileIsOpen(CurrentDocument.FullName))
                {
                    // the file can be deleted now
                    _logger.Debug(string.Format(
                        "DestroyWatcherAndDeleteFileAndUnlock: deleting {0}",
                        CurrentDocument.FullName
                    ));
                    Zip.DeleteFile(CurrentDocument);
                }
                else
                {
                    // the file cannot be deleted
                    _logger.Debug(string.Format(
                        "DestroyWatcherAndDeleteFileAndUnlock: cannot delete file {0}",
                        CurrentDocument.FullName
                    ));
                }
            }

            // Unlock, release
            ReleaseDocument(isInserting);

            // debugging
            _logger.Debug("DestroyWatcherAndDeleteFileAndUnlock: done");
        }

        /// <summary>
        /// Store the specified file in the database.
        /// </summary>
        /// <param name="file">The file.</param>
        public void FileToDB(FileInfo file)
        {
            CurrentDocument = file;
            if (_isTemplate)
            {
                // using XDocTemplate
                RefreshDocument();
            }
            else
            {
                // using XDocument
                QryXDocument = GetDocumentMetaData(DBNull.Value);
                QryXDocument.Insert("XDocument");
                if (QryXDocument.DataTable.Columns.Contains("DocReadOnly"))
                {
                    QryXDocument["DocReadOnly"] = false;
                }
            }
            this["FileExtension"] = file.Extension;
            this["DocFormatCode"] = GetDokFormatCodeFromFileInfo(file);
            SaveDocument();
        }

        /// <summary>
        /// Gets the DocFormatCode from the extension of a file.
        /// </summary>
        /// <param name="file">The file info.</param>
        public DokFormat GetDokFormatCodeFromFileInfo(FileInfo file)
        {
            switch (file.Extension.ToLower())
            {
                case ".dot":
                case ".dotx":
                case ".dotm":
                case ".doc":
                case ".docx":
                case ".docm":
                    return DokFormat.Word;
                case ".xlt":
                case ".xltx":
                case ".xltm":
                case ".xls":
                case ".xlsx":
                case ".xlsm":
                    return DokFormat.Excel;
                case ".pdf":
                    return DokFormat.PDF;
                default:
                    return DokFormat.Unbekannt;
            }
        }

        /// <summary>
        /// Lock the document.
        /// </summary>
        public bool LockDocument()
        {
            // debuging
            _logger.Debug("LockDocument enter: Lock the current document");

            // nothing to lock, when documentID is not defined
            if (DBUtil.IsEmpty(_documentID))
            {
                _logger.Debug("LockDocument done: documentID is empty");
                return true;
            }

            bool hasErrors = false;
            string errorShort = "";
            _logger.Debug("LockDocument locking: " + ActualFileFullName);

            // transaction is not optional!! never eliminate it here without refactoring
            Session.BeginTransaction();
            try
            {
                DBUtil.ExecSQLThrowingException("EXEC dbo.spXDocument_Lock {0}, {1}, {2}, {3}, {4}",
                    _documentID,
                    Session.User.UserID,
                    ActualFileFullName,
                    Environment.MachineName,
                    _isTemplate
                );
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                errorShort = ex.Message;
                hasErrors = true;
                _logger.Error("LockDocument error", ex);
            }

            if (!hasErrors)
            {
                _logger.Debug("LockDocument success");
                // no errors, so we can continue
                RefreshDocument();
                IsLockedByCurrentUser = true;

                // if no errors tell XDocument
                if (DocumentLocked != null)
                {
                    DocumentLocked(this, EventArgs.Empty);
                }
            }
            else
            {
                // errors occured, so we show a message
                string msg1;
                string msgChkout = "";
                string msgNoLock = "";
                switch (errorShort)
                {
                    case "LockInvalidParameters":
                        // do not change message name without changing error Message in spXDocument_Lock
                        msg1 = KissMsg.GetMLMessage(
                            CLASSNAME,
                            errorShort,
                            "Beim Sperren der Datei wurden ungültige Parameter verwendet.");
                        break;

                    case "FileIsLockedByAnotherUser":
                        RefreshDocument();
                        msg1 = _strCheckOutMesssageOtherUser + "\r\n\r\n";
                        msgChkout = CheckOutMesssage;
                        msgNoLock = "\r\n" + _strNolockingMessage;
                        break;

                    case "FileIsLockedByActualUser":
                        RefreshDocument();
                        msg1 = _strCheckOutMesssageActualUser + "\r\n\r\n";
                        msgChkout = CheckOutMesssage;
                        msgNoLock = "\r\n" + _strNolockingMessage;
                        break;

                    default:
                        // do not change message name without changing error Message in spXDocument_Lock
                        msg1 = KissMsg.GetMLMessage(
                            CLASSNAME,
                            "UnknownErrorDocumentLock",
                            "Beim Sperren der Datei ist ein unbekannter Fehler aufgetreten.");
                        break;
                }
                KissMsg.ShowInfo(msg1 + msgChkout);
            }

            _logger.Debug("LockDocument done");
            return !hasErrors;
        }

        /// <summary>
        /// Opens a dataset of XDocument.
        /// </summary>
        public void OpenDocument()
        {
            // sets the SQL and opens the data from DB (XDocument and XDocTemplate):
            QryXDocument = GetDocumentMetaData(_documentID);

            QryXDocument.CanInsert = true;
            QryXDocument.CanUpdate = true;
            QryXDocument.CanInsert = true;
            QryXDocument.TableName = _isCreatingFromTemplate ? null : _isTemplate ? "XDocTemplate" : "XDocument";

            WasAlreadyLockedOnEditing = !DBUtil.IsEmpty(QryXDocument["Checkout_UserID"]);
            // when checked out, we get the name of the user
            SetCheckoutUserName();
        }

        /// <summary>
        /// Opens the document in external application.
        /// </summary>
        /// <param name="writeable">if set to <c>true</c> [writeable].</param>
        /// <param name="dokFormat"></param>
        public void OpenDocumentInExternalApplication(bool writeable, DokFormat dokFormat)
        {
            OpenDocumentInExternalApplication(writeable, dokFormat, true);
        }

        /// <summary>
        /// Opens the document in external application.
        /// </summary>
        /// <param name="writeable">if set to <c>true</c> [writeable].</param>
        /// <param name="dokFormat"></param>
        /// <param name="showApp">If <c>true</c>, the Word/Excel application is shown.</param>
        public void OpenDocumentInExternalApplication(bool writeable, DokFormat dokFormat, bool showApp)
        {
            // logging
            _logger.DebugFormat("open document in external application as writeable='{0}', dokFormat='{1}'", writeable, dokFormat);

            switch (dokFormat)
            {
                case DokFormat.Word:
                    //to allow the automatic conversion of old documents, we have to install the document watcher before opening the file
                    InitializeDocumentWatcher(CurrentDocument, true);

                    // add trusted location to the registry to prevent office 2010 errors
                    RegistryUtilities.AddTrustedLocation(dokFormat, CurrentDocument.DirectoryName);

                    OpenDocumentInWord(showApp);
                    // in WORD or EXCEL the file only can be watched after opening it,
                    // because the file has to be opened (see processLauncher)
                    WatchFile(writeable, true, false, true);
                    break;

                case DokFormat.Excel:

                    _logger.Debug("Excel Opening Started");

                    // add trusted location to the registry to prevent office 2010 errors
                    RegistryUtilities.AddTrustedLocation(dokFormat, CurrentDocument.DirectoryName);

                    OpenDocumentInExcel(showApp);

                    // in WORD or EXCEL the file only can be watched after opening it,
                    // because the file has to be opened (see processLauncher)
                    WatchFile(writeable, true);
                    break;

                default:
                    // other than WORD or EXCEL we first watch the file in a temporary folder
                    // because the file has to be opened (see processLauncher) first
                    // in order to get the process and its locking behavior
                    WatchFile(writeable, false);

                    // open file
                    _processWatcher.OpenFile(writeable, "Open");
                    break;
            }
        }

        /// <summary>
        /// Post new data for the document query.
        /// </summary>
        /// <returns></returns>
        public bool Post()
        {
            // do nothing, if file is ReadOnly or handler is called from KissDocumentButton
            if (!PendingChanges || _isCreatingFromTemplate)
            {
                return true;
            }

            // posting changed data to the DB
            if (Session.Active && QryXDocument != null)
            {
                if (_isTemplate)
                {
                    // using XDocTemplate
                    return QryXDocument.Post("XDocTemplate");
                }

                // using XDocument
                return QryXDocument.Post("XDocument");
            }

            return true;
        }

        /// <summary>
        /// Prints a document to the default printer.
        /// </summary>
        /// <returns>the <see cref="Task"/> for methode <see cref="WaitForDestroyWatcherAndDeleteFileAndUnlock"/></returns>
        /// <exception cref="KissErrorException">if filetype is unknown.</exception>
        public Task PrintDocument()
        {
            return PrintDocument(null);
        }

        /// <summary>
        /// Prints a document to the specified printer.
        /// </summary>
        /// <param name="printerName">The printer, where the document should be printed.</param>
        /// <returns>the <see cref="Task"/> for methode <see cref="WaitForDestroyWatcherAndDeleteFileAndUnlock"/></returns>
        /// <exception cref="KissErrorException">if filetype is unknown.</exception>
        public Task PrintDocument(string printerName)
        {
            _logger.InfoFormat("Document '{0}' printed on '{1}'", CurrentDocument.FullName,
                               string.IsNullOrEmpty(printerName) ? "Default printer" : printerName);

            var fileInfo = CurrentDocument;

            var result = DocumentHelper.PrintDocument(fileInfo, printerName);
            if (!result.IsOk)
            {
                throw new KissErrorException(result.GetWarningsAndErrors());
            }

            Task deleteFileTask;

            try
            {
                deleteFileTask = Task.Factory.StartNew(WaitForDestroyWatcherAndDeleteFileAndUnlock);
            }
            catch (Exception ex)
            {
                throw new KissErrorException(string.Format("Fehler beim Entfernen des temporären Dokuments nach dem Drucken"), ex);
            }

            return deleteFileTask;
        }

        /// <summary>
        /// Quits the word/excel application.
        /// </summary>
        public void QuitApplication()
        {
            // logging
            _logger.Debug("enter");

            try
            {
                if (_excelControl != null)
                {
                    // logging
                    _logger.Debug("close excel document");

                    // TODO: cjaeggi - really neccessary??
                    _excelControl.CloseDocument();
                    _excelControl.Quit();
                    _excelControl.Dispose();
                    _excelControl = null;
                }

                if (Word != null)
                {
                    // logging
                    _logger.Debug("close word document");

                    // dies schliesst offene Dokumente, schliesst wenn nötig das Word
                    // und räumt auch alle COM-Referenzen auf
                    Word.Quit();
                    Word = null;
                }
            }
            catch (Exception ex)
            {
                _logger.Warn("exception occured on quitting application", ex);
            }

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Refreshs a dataset of XDocument.
        /// </summary>
        public void RefreshDocument()
        {
            // only opens the data from DB (XDocument and XDocTemplate):
            if (QryXDocument == null)
            {
                // this never should be the case, do not translate
                KissMsg.ShowInfo("Error XDocFileHandler.RefreshDocument: qryXDocument == null !");
                // debuging
                _logger.Warn("RefreshDocument: qryXDocument == null !");
                return;
            }

            // Refreshing the document
            QryXDocument.Refresh();

            HasDBConflict = (QryXDocument.Count == 0 && !DBUtil.IsEmpty(DocumentID));

            SetCheckoutUserName();
        }

        /// <summary>
        /// Opens the document in external application.
        /// </summary>
        /// <param name="dokFormat"></param>
        public void SaveDocumentInExternalApplication(DokFormat dokFormat)
        {
            // logging
            _logger.DebugFormat("forced save document in external application, dokFormat='{0}'", dokFormat);

            switch (dokFormat)
            {
                case DokFormat.Word:
                    SaveDocumentInWord();
                    break;

                case DokFormat.Excel:
                    SaveDocumentInExcel();
                    break;
            }
        }

        /// <summary>
        /// Unlock the document.
        /// </summary>
        public bool UnlockDocument(bool isForcedUnlock)
        {
            // debuging
            _logger.Debug("UnlockDocument enter: Unlock the current document");

            // nothing to unlock, when documentID is not defined
            if (DBUtil.IsEmpty(_documentID))
            {
                _logger.Debug("UnlockDocument done: documentID is empty");
                return true;
            }

            // unlock a document
            int docID = Convert.ToInt32(_documentID);
            _logger.Debug(string.Format(
                "UnlockDocument unlocking: documentID = {0}, file = {1}",
                docID.ToString(),
                ActualFileFullName
            ));

            bool hasErrors = false;
            string errorShort = "";
            Session.BeginTransaction();
            try
            {
                DBUtil.ExecSQLThrowingException("EXEC dbo.spXDocument_UnLock {0}, {1}", _documentID, _isTemplate);
                IsLockedByCurrentUser = false;
                if (isForcedUnlock) WasAlreadyLockedOnEditing = false;
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                errorShort = ex.Message;
                hasErrors = true;
                _logger.Error("UnlockDocument error", ex);
            }
            RefreshDocument();

            if (hasErrors)
            {
                // errors occured, so we show a message
                string msg1;
                switch (errorShort)
                {
                    case "LockInvalidParameters":
                        // do not change message name without changing error Message in spXDocument_Lock
                        msg1 = KissMsg.GetMLMessage(
                            CLASSNAME,
                            errorShort,
                            "Beim Entsperren der Datei wurden ungültige Parameter verwendet.");
                        break;

                    default:
                        // do not change message name without changing error Message in spXDocument_Lock
                        msg1 = KissMsg.GetMLMessage(
                            CLASSNAME,
                            "UnknownErrorDocumentUnLock",
                            "Beim Entsperren der Datei ist ein unbekannter Fehler aufgetreten.");
                        break;
                }
                KissMsg.ShowInfo(msg1);
            }
            else
            {
                _logger.Debug("UnlockDocument success");

                // if no errors tell XDocument
                if (DocumentUnlocked != null)
                {
                    DocumentUnlocked(this, EventArgs.Empty);
                }
            }

            return !hasErrors;
        }

        /// <summary>
        /// Watches the file.
        /// </summary>
        public void WatchFile(bool canSave, bool isWordOrExcel)
        {
            WatchFile(canSave, isWordOrExcel, true, true);
        }

        /// <summary>
        /// Watches the file.
        /// </summary>
        public void WatchFile(bool canSave, bool isWordOrExcel, bool watchDocument, bool watchProcess)
        {
            // logging
            _logger.DebugFormat("WatchFile enter: canSave='{0}', isWordOrExcel='{1}'", canSave, isWordOrExcel);

            if (!_isCreatingFromTemplate)
            {
                // only store in a persistent object when it's not called from KissDoumentButton
                if (!Session.PersistentObjects.Contains(this))
                {
                    Session.PersistentObjects.Add(this);
                }
            }

            // create document watcher
            if (watchDocument)
                InitializeDocumentWatcher(CurrentDocument, canSave);

            // create process watcher
            if (watchProcess)
                InitializeProcessWatcher(CurrentDocument, isWordOrExcel, canSave);

            // logging
            _logger.Debug("done");
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Gets the file handler of the specified document.
        /// </summary>
        /// <param name="docID">The document ID.</param>
        /// <param name="newExtension">The new extension of the document.</param>
        /// <param name="isFromTemplate">True, if a document will be created by using a template.</param>
        /// <returns></returns>
        private static XDocFileHandler GetDocumentHandler(object docID, string newExtension, bool isFromTemplate)
        {
            // TODO: Check if (Session.MainForm != null)

            if (!isFromTemplate)
            {
                // only store in a persistent object when it's not called from KissDoumentButton
                foreach (object obj in Session.PersistentObjects)
                {
                    XDocFileHandler xDoc = obj as XDocFileHandler;

                    if (xDoc != null && xDoc._documentID != null && xDoc._documentID.Equals(docID) && !xDoc._isTemplate)
                    {
                        // logging
                        _logger.InfoFormat(
                            "GetDocumentHandler: existing handler found: old ID {0}, new ID {1}",
                            docID is int ? ((int)docID).ToString() : "NULL",
                            xDoc._documentID is int ? ((int)xDoc._documentID).ToString() : "NULL"
                        );

                        return xDoc;
                    }
                }

                // logging
                _logger.InfoFormat(
                    "GetDocumentHandler: existing handler not found (ID {0})",
                    docID is int ? ((int)docID).ToString() : "NULL"
                );
            }

            // Handler not found, so create a new one
            XDocFileHandler xDocFh = new XDocFileHandler
            {
                HasDBConflict = false,
                _isCreatingFromTemplate = isFromTemplate,
                _isTemplate = false,
                _documentID = docID,
                _newExtension = newExtension
            };

            xDocFh.OpenDocument();

            if (String.IsNullOrEmpty(newExtension) && !DBUtil.IsEmpty(xDocFh.QryXDocument["FileExtension"]))
            {
                xDocFh._newExtension = (string)xDocFh.QryXDocument["FileExtension"];
            }
            return xDocFh;
        }

        /// <summary>
        /// Gets the file handler of the specified template file.
        /// </summary>
        /// <param name="docTemplateID">The doc template ID.</param>
        /// <param name="newExtension">The new extension of the template.</param>
        /// <param name="isFromTemplate">True, if a document will be created by using a template.</param>
        /// <returns></returns>
        private static XDocFileHandler GetTemplateHandler(object docTemplateID, string newExtension, bool isFromTemplate)
        {
            // create a new Handler
            XDocFileHandler xDocFh = new XDocFileHandler
            {
                HasDBConflict = false,
                _isCreatingFromTemplate = isFromTemplate,
                _isTemplate = true,
                _documentID = docTemplateID,
                _newExtension = newExtension
            };

            xDocFh.OpenDocument();

            return xDocFh;
        }

        #endregion

        #region Private Methods

        private void DestroyDocumentWatcher()
        {
            if (_documentWatcher == null)
            {
                return;
            }

            // destroy a document watcher
            _documentWatcher.Dispose();

            // check if still valid (in some cases, documentWatcher is null after dispose)
            if (_documentWatcher == null)
            {
                // this case should not occure by default
                _logger.Warn("documentWatcher is null after Dispose(), cannot release events");
            }
            else
            {
                _documentWatcher.FileChanged -= documentWatcher_FileChanged;
                _documentWatcher.FileDeleted -= documentWatcher_FileDeleted;
                _documentWatcher.FileRenamed -= documentWatcher_FileRenamed;
                _documentWatcher.FileCreated -= documentWatcher_FileCreated;
                _documentWatcher = null;
            }
        }

        private void DestroyProcessWatcher()
        {
            if (_processWatcher == null)
            {
                return;
            }

            // destroy a process watcher
            _processWatcher.ProcessExited -= processWatcher_ProcessExited;
            _processWatcher.Dispose();
            _processWatcher = null;
        }

        /// <summary>
        /// Gets the data of one row of XDocument from DB.
        /// </summary>
        /// <param name="documentId">The document ID.</param>
        /// <returns>SqlQuery</returns>
        private SqlQuery GetDocumentMetaData(object documentId)
        {
            SqlQuery tmpQry;

            if (_isTemplate || _isCreatingFromTemplate)
            {
                // using XDocTemplate
                tmpQry = DBUtil.OpenSQL(@"
                    SELECT
                      DocTemplateID,
                      DateCreation,
                      DateLastSave,
                      DocTemplateName,
                      DocFormatCode,
                      FileExtension,
                      FileBinary = CAST(0x0 AS IMAGE), -- due to performance issues!
                      DocTemplateTS,
                      CheckOut_UserID,
                      CheckOut_Date,
                      CheckOut_Filename,
                      CheckOut_Machine
                    FROM dbo.XDocTemplate
                    WHERE
                      DocTemplateID = {0};",
                    documentId
                );
            }
            else
            {
                // using XDocument
                tmpQry = DBUtil.OpenSQL(@"
                    SELECT
                      DOC.DocumentID,
                      DOC.DateCreation,
                      DOC.UserID_Creator,
                      DOC.DocReadOnly,
                      DOC.DocTemplateID,
                      DOC.UserID_LastRead,
                      DOC.DateLastRead,
                      DOC.UserID_LastSave,
                      DOC.DateLastSave,
                      DCT.DocTemplateName,
                      DOC.DocFormatCode,
                      DOC.FileExtension,
                      FileBinary = CAST(0x0 AS IMAGE), -- due to performance issues!
                      DOC.DocTypeCode,
                      DOC.XDocumentTS,
                      DOC.CheckOut_UserID,
                      DOC.CheckOut_Date,
                      DOC.CheckOut_Filename,
                      DOC.CheckOut_Machine
                    FROM dbo.XDocument DOC
                      LEFT JOIN XDocTemplate DCT ON DCT.DocTemplateID=DOC.DocTemplateID
                    WHERE
                      DOC.DocumentID = {0};",
                    documentId
                );
                HasDBConflict = (tmpQry.Count == 0 && !DBUtil.IsEmpty(documentId));
            }
            return tmpQry;
        }

        /// <summary>
        /// Gets the file binary.
        /// </summary>
        /// <value>The file binary.</value>
        private byte[] GetFileBinary()
        {
            if (IsEmpty || DBUtil.IsEmpty(DocumentID))
            {
                return null;
            }
            SqlQuery queryFileBinary;
            if (_isTemplate || _isCreatingFromTemplate)
            {
                queryFileBinary = DBUtil.OpenSQL(@"
                    SELECT
                      FileBinary
                    FROM dbo.XDocTemplate
                    WHERE DocTemplateID = {0};", DocumentID);
            }
            else
            {
                queryFileBinary = DBUtil.OpenSQL(@"
                    SELECT
                      FileBinary
                    FROM dbo.XDocument
                    WHERE DocumentID = {0};", DocumentID);
            }
            if (!DBUtil.IsEmpty(queryFileBinary["FileBinary"]))
            {
                return (byte[])queryFileBinary["FileBinary"];
            }
            return null;
        }

        /// <summary>
        /// Initializes the document watcher.
        /// </summary>
        /// <param name="currentDocument">The current document.</param>
        /// <param name="canSave">indicates wether the document dan be edited/saved or not.</param>
        private void InitializeDocumentWatcher(FileInfo currentDocument, bool canSave)
        {
            // logging
            _logger.DebugFormat("enter: currentDocument='{0}', canSave='{1}'", currentDocument, canSave);

            // destroy existing process watcher
            if (_documentWatcher != null)
            {
                // logging
                _logger.Debug("documentWatcher already had instance");

                // cleanup any watcher first
                DestroyDocumentWatcher();
            }

            // a document watcher is only needed when a file can be edited
            if (canSave)
            {
                // logging
                _logger.Debug("create new documentwatcher instance and attach events");

                // create a new one
                _documentWatcher = new DocumentWatcher(currentDocument);
                _documentWatcher.FileChanged += documentWatcher_FileChanged;
                _documentWatcher.FileDeleted += documentWatcher_FileDeleted;
                _documentWatcher.FileRenamed += documentWatcher_FileRenamed;
                _documentWatcher.FileCreated += documentWatcher_FileCreated;
            }

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Initializes the process watcher.
        /// </summary>
        /// <param name="currentDoc">The current document.</param>
        /// <param name="isWordOrExcel">Indicates if the file is a WORD or EXCEL document.</param>
        /// <param name="isWritable">Whether it is writable or not.</param>
        private void InitializeProcessWatcher(FileInfo currentDoc, bool isWordOrExcel, bool isWritable)
        {
            // destroy existing process watcher
            if (_processWatcher != null) DestroyProcessWatcher();

            // create a new one
            _processWatcher = new ProcessLauncher(currentDoc, isWordOrExcel, isWritable);
            _processWatcher.ProcessExited += processWatcher_ProcessExited;
        }

        /// <summary>
        /// Makes a copy of a file in the local temp folder.
        /// </summary>
        /// <returns></returns>
        private bool MakeCopyOfFile()
        {
            // makes a local copy of the file
            try
            {
                // gets the filename for the copy
                string fileName = FileNameDeleted;
                CurrentDocument = Zip.GetLocalFile(fileName, NewExtension);

                // refresh the document in order to really have the last saved one
                QryXDocument = GetDocumentMetaData(_documentID);

                // make the copy
                Zip.ExpandDataToFile(GetFileBinary(), CurrentDocument);

                // inform the user
                // no, never inform the user, he could be confused
                /*
                KissMsg.ShowInfo("XDocFileHandler", "SuccesBackingUpFile", "Eine Sicherungskopie der Datei wurde erfolgreich angelegt.");
                */
            }
            catch (Exception ex)
            {
                // we wont delete the file, if no copy could be made
                KissMsg.ShowError(
                    CLASSNAME,
                    "ErrorBackingUpFile",
                    "Fehler beim Anlegen einer Sicherungskopie.", ex
                );
                return false;
            }

            return true;
        }

        /// <summary>
        /// Opens the document in Microsft Excel.
        /// </summary>
        /// <param name="showApp">If <c>true</c>, the Excel application will show up.</param>
        private void OpenDocumentInExcel(bool showApp)
        {
            // logging
            _logger.Debug("enter");

            // check if we already have excel control
            if (_excelControl != null)
            {
                // logging
                _logger.Debug("excelControl is not null");
                _logger.DebugFormat("excelControl.CurrentDocumentName = '{0}'", _excelControl.CurrentDocumentName);
                _logger.DebugFormat("currentDocument.Name = '{0}'", CurrentDocument.Name);

                // check if are progressing current document
                string currentDocumentName = _excelControl.CurrentDocumentName;

                if (!string.IsNullOrEmpty(currentDocumentName) &&
                    CurrentDocument != null &&
                    !string.IsNullOrEmpty(CurrentDocument.FullName) &&
                    currentDocumentName.ToLower().Equals(CurrentDocument.Name.ToLower())
                )
                {
                    // logging
                    _logger.InfoFormat("opened same document twice. try to quit excel and reopen. documentName='{0}'", currentDocumentName);

                    try
                    {
                        // close this document and excel if no more documents are open
                        _excelControl.CloseDocument();
                    }
                    catch (Exception ex)
                    {
                        // logging
                        _logger.Error("exeption occured while closing document", ex);
                    }
                }
            }

            // logging
            _logger.Debug("create new ExcelControl instance");

            // create new control
            if (_excelControl == null)
            {
                _excelControl = new ExcelControl();
            }
            else
            {
                _excelControl.EnsureApplicationIsRunning();
            }

            // logging
            _logger.Debug("open document with control");

            FileInfo info = new FileInfo(CurrentDocument.FullName);
            _lastWriteBeforeOpenInExcel = info.LastWriteTimeUtc;

            // open then document in excel
            _excelControl.Open(CurrentDocument.FullName, _isTemplate, showApp, true);

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Opens the document in Microsft Word.
        /// </summary>
        /// <param name="showApp">If <c>true</c>, the Word application will show up.</param>
        private void OpenDocumentInWord(bool showApp)
        {
            if (Word == null)
            {
                Word = new WordControl();
            }
            else
            {
                Word.EnsureApplicationIsRunning();
            }

            Word.Open(
                CurrentDocument.FullName,
                _isTemplate,
                showApp,
                true, // resetProtection
                _isCreatingFromTemplate,
                !PendingChanges,
                DocumentID
            );
        }

        /// <summary>
        /// Releases the document and unlock it when necessary.
        /// </summary>
        private void ReleaseDocument(bool isInserting)
        {
            // release the document and unlock it when necessary
            // on releasing the document, we have to unlock it:
            if (!DBUtil.IsEmpty(_documentID) && !isInserting && Session.User.UserID == CheckoutUserID && IsLockedByCurrentUser)
            {
                // first unlock the document
                UnlockDocument(false);
            }

            _logger.Debug("Release the current document");
            CurrentDocument = null;
        }

        /// <summary>
        /// Saves the document.
        /// </summary>
        /// <returns></returns>
        private void SaveDocument()
        {
            _logger.Debug("SaveDocument: start");

            if (!PendingChanges)
            {
                return;
            }

            if (IsEmpty || CurrentDocument == null || !File.Exists(CurrentDocument.FullName))
            {
                _logger.Warn("SaveDocument: no document");
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "ErrorSaveDocumentNoFile",
                    "Das Dokument kann nicht gespeichert werden (Datei existiert nicht)."
                );
                return;
            }

            lock (_locker)
            {
                if (_saving)
                {
                    return;
                }

                try
                {
                    _saving = true;
                    bool rowUnchanged = !QryXDocument.RowModified;

                    // get the actual information of the edited file
                    CurrentDocument.Refresh();
                    if ((DokFormat)QryXDocument["DocFormatCode"] == DokFormat.Excel &&
                       QryXDocument.Row.RowState != DataRowState.Added &&
                       CurrentDocument.LastWriteTimeUtc == _lastWriteBeforeOpenInExcel
                    )
                    {
                        _logger.Info("SaveDocument: no changes detected for Excel file");
                        QryXDocument.Row.AcceptChanges();
                        QryXDocument.RowModified = false;
                        return;
                    }

                    if (QryXDocument != null)
                    {
                        // logging
                        _logger.Debug("apply new values to current document row");

                        // apply values
                        this["FileBinary"] = Zip.CompressData(CurrentDocument);
                        this["DateLastSave"] = CurrentDocument.LastWriteTime;
                        this["FileExtension"] = CurrentDocument.Extension;
                        if (Row.RowState == DataRowState.Added)
                        {
                            Row["DateCreation"] = CurrentDocument.CreationTime;
                        }
                        QryXDocument.TimestampMessage = KissMsg.GetMLMessage(
                            "XDocumentHandler",
                            "TimestampMessage",
                            "Das Dokument \"{0}\" wurde von einem anderen Benutzer geändert oder gelöscht. " +
                            "Bitte schliessen Sie das Dokument.",
                            KissMsgCode.Text, FileInfo.Name
                        );
                        if (rowUnchanged && !(
                            QryXDocument.ColumnModified("DateCreation") ||
                            QryXDocument.ColumnModified("DateLastSave") ||
                            QryXDocument.ColumnModified("FileBinary"))
                        )
                        {
                            _logger.Info("SaveDocument: no changes detected");
                            QryXDocument.Row.AcceptChanges();
                            QryXDocument.RowModified = false;
                        }
                        else
                        {
                            if (Session.User != null &&
                                QryXDocument.ColumnModified("DateLastSave") &&
                                QryXDocument.DataTable.Columns.Contains("UserID_LastSave")
                            )
                            {
                                QryXDocument["UserID_LastSave"] = Session.User.UserID;
                            }

                            if (Post())
                            {
                                _documentID = _isTemplate ? QryXDocument["DocTemplateID"] : QryXDocument["DocumentID"];

                                _logger.InfoFormat("SaveDocument: Document {0} saved to database", _documentID);

                                if (_processWatcher != null && _processWatcher.HasPendingStop)
                                {
                                    // error detected
                                    _processWatcher.FileWasSavedInSpecialLoops = true;
                                }

                                if (DocumentSaved != null)
                                {
                                    // inform users that the file was saved!
                                    DocumentSaved(this, EventArgs.Empty);
                                }
                            }
                        }
                    }
                }
                finally
                {
                    _saving = false;
                }
            }
        }

        /// <summary>
        /// Tries to save the document in Microsoft Word.
        /// </summary>
        private void SaveDocumentInExcel()
        {
            if (_excelControl == null)
                return;

            _excelControl.Save();
        }

        /// <summary>
        /// Tries to save the document in Microsoft Word.
        /// </summary>
        private void SaveDocumentInWord()
        {
            if (Word == null)
                return;

            Word.Save();
        }

        /// <summary>
        /// Opens a dataset of XDocument.
        /// </summary>
        private void SetCheckoutUserName()
        {
            // set checkout user information
            if (WasAlreadyLockedOnEditing)
            {
                // when locked, we define the CheckoutUsername immediately and only once,
                // in order to show it later
                if (CheckoutUserID == Session.User.UserID)
                {
                    // checked out by the actual user, so we do not have to open a special query
                    CheckoutUserName = Session.User.LastName + " " + Session.User.FirstName;
                }
                else
                {
                    // checked out by another user, so we have to open a special query
                    SqlQuery qryUser = DBUtil.OpenSQL(
                        "select NameVornameOhneKomma from dbo.vwUser where UserID = {0}",
                        CheckoutUserID
                    );
                    CheckoutUserName = DBUtil.IsEmpty(qryUser["NameVornameOhneKomma"])
                        ? _strUserNotFound : (string)qryUser["NameVornameOhneKomma"];
                }
            }
            else
            {
                // when not locked
                CheckoutUserName = "";
            }
        }

        private void WaitForDestroyWatcherAndDeleteFileAndUnlock()
        {
            string name = CurrentDocument.Name;
            _logger.DebugFormat("WaitForDestroyWatcherAndDeleteFileAndUnlock: enter {0} Thread: {1}", name, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(_wartezeitNachDrucken); // TODO: it might be possible that all Tasks use the same thread! in .net 4.5 Task.Delay
            DestroyWatcherAndDeleteFileAndUnlock(true, false);
            _logger.DebugFormat("WaitForDestroyWatcherAndDeleteFileAndUnlock: done {0} Thread: {1}", name, Thread.CurrentThread.ManagedThreadId);
        }

        #endregion

        #endregion
    }
}