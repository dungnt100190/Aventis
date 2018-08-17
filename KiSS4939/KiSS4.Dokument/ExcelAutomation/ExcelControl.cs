using BIAG.AssemblyInfo;
using Interop.Excel;
using Kiss.Interfaces.DocumentHandling;
using KiSS4.DB;
using KiSS4.Dokument.MsOfficeCommons;
using KiSS4.Dokument.Utilities;
using KiSS4.Messages;
using Microsoft.Practices.Unity;
using Office;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace KiSS4.Dokument.ExcelAutomation
{
    /// <summary>
    /// Class for new Excel controlling instance
    /// </summary>
    public class ExcelControl : IDisposable, IExcelControl
    {
        #region DllImport

        /// <summary>
        /// The GetForegroundWindow function returns a handle to the foreground window.
        /// </summary>
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// Moves the window associated with the passed handle to the front.
        /// </summary>
        /// <param name="hWnd">The pointer of the window to activate</param>
        /// <returns>Success or failure</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        #endregion DllImport

        #region Enumerations

        public enum Orientation
        {
            Portrait,
            Landscape
        }

        #endregion Enumerations

        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion Private Static Fields

        #region Private Constant/Read-Only Fields

        private const string ADDIN_EXTENSION_OFFICE2010ANDBEFORE = ".xla";
        private const string ADDIN_EXTENSION_OFFICE2013 = ".xla";
        private const string ADDIN_FILE_NAME_BASE = "KissTextmarkenAddIn";
        private const string ADDIN_FILE_NAME_OFFICE2010ANDBEFORE = "KissTextmarkenAddIn";
        private const string ADDIN_FILE_NAME_OFFICE2013 = "KissTextmarkenAddIn_Office2013";
        private const string CLASSNAME = "ExcelControl";

        private const string PARAM_CONNECTION_STRING = "ConnectionStringParam";
        private const string PARAM_LANGUAGE_CODE = "LanguageCodeParam";

        private const string PARAM_TEXTBTNADD = "TextBtnAdd";
        private const string PARAM_TEXTBTNCLOSE = "TextBtnClose";
        private const string PARAM_TEXTFRMTITLE = "TextFrmTitle";

        private readonly object _false = false;

        /// <summary>
        /// Lock-object for multithreading safty of CheckNoMoreDocsOpenAndCloseApplication(...) call
        /// </summary>
        private readonly object _lockCheckMoreDocs = new object();

        /// <summary>
        /// Lock-object for multithreading safty of InitializeExcelApplication(...) call
        /// </summary>
        private readonly object _lockInitExcelApp = new object();

        /// <summary>
        /// Lock-object for multithreading safty of InitializeExcelApplicationInNewProcess(...) call
        /// </summary>
        private readonly object _lockInitExcelAppNewProcess = new object();

        /// <summary>
        /// Lock-object for multithreading safety of QuitExcelApplication(...) call
        /// </summary>
        private readonly object _lockQuit = new object();

        private readonly object _missing = Missing.Value;
        private readonly object _true = true;

        #endregion Private Constant/Read-Only Fields

        #region Private Fields

        private Workbook _currentWorkbook;
        private string _documentName;
        private Application _excelApplication;

        #endregion Private Fields

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelControl"/> class.
        /// </summary>
        [InjectionConstructor]
        public ExcelControl()
        {
            // logging
            _logger.Debug("enter");

            InitializeExcelApplication();

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelControl"/> class.
        /// </summary>
        /// <param name="excelApplicationInNewProcess">if set to <c>true</c> [excel application in new process].</param>
        public ExcelControl(bool excelApplicationInNewProcess)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("excelApplicationInNewProcess='{0}'", excelApplicationInNewProcess);

            if (excelApplicationInNewProcess)
            {
                InitializeExcelApplicationInNewProcess();
            }
            else
            {
                InitializeExcelApplication();
            }

            // logging
            _logger.Debug("done");
        }

        #endregion Constructors

        #region Destructor

        /// <summary>
        /// Desctructor
        /// </summary>
        ~ExcelControl()
        {
            // logging
            _logger.Debug("enter");

            // do dispose
            Dispose(false);

            // logging
            _logger.Debug("done");
        }

        #endregion Destructor

        #region Dispose

        /// <summary>
        /// Dispose the instance to cleanup ressources
        /// </summary>
        public void Dispose()
        {
            // logging
            _logger.Debug("enter");

            // do dispose
            Dispose(true);
            GC.SuppressFinalize(this);

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Dispose the instance to cleanup ressources
        /// </summary>
        /// <param name="disposing">Flag if disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("disposing = '{0}'", disposing);

            if (disposing)
            {
                try
                {
                    if (_currentWorkbook != null)
                    {
                        // logging
                        _logger.Debug("release workbook");

                        // do release workbook
                        Marshal.FinalReleaseComObject(_currentWorkbook);
                        _currentWorkbook = null;
                    }

                    if (_excelApplication != null)
                    {
                        // logging
                        _logger.Debug("release application");

                        // do release application
                        Marshal.FinalReleaseComObject(_excelApplication);
                        _excelApplication = null;
                    }

                    // let garbage collector do the cleanup
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                catch (Exception ex)
                {
                    // logging
                    _logger.Warn("exception occured while disposing and releasing com objects", ex);
                }
            }

            // logging
            _logger.Debug("done");
        }

        #endregion Dispose

        #region Properties

        /// <summary>
        /// Gets a list of bookmarks
        /// </summary>
        public List<string> Bookmarks
        {
            get
            {
                return GetBookmarks();
            }
        }

        /// <summary>
        /// Get the current open file full name
        /// </summary>
        public string CurrentDocumentName
        {
            get
            {
                // try to return document name
                return _documentName;
            }
        }

        public Workbook CurrentWorkbook
        {
            get { return _currentWorkbook; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ExcelControl"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public bool Visible
        {
            get
            {
                return ExcelApplication.Visible;
            }
            set
            {
                try
                {
                    CheckMakeVisibleOnlyIfWkBksOpen(value);
                }
                catch (Exception ex)
                {
                    _logger.Warn(ex);
                }
            }
        }

        /// <summary>
        /// Gets the excel application.
        /// </summary>
        /// <value>The excel application.</value>
        internal Application ExcelApplication
        {
            get
            {
                if (_excelApplication == null)
                {
                    InitializeExcelApplication();
                }

                return _excelApplication;
            }
            set
            {
                _excelApplication = value;
            }
        }

        /// <summary>
        /// Keine MessageBox anzeigen.
        /// </summary>
        public bool DisableMessageBox
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        #region Public Methods

        /// <summary>
        /// Checks if a bookmark exists in the current workbook.
        /// </summary>
        /// <param name="bookmarkName">The name of the bookmark.</param>
        /// <returns><c>True</c>, if the bookmark exists.</returns>
        public bool BookmarkExists(string bookmarkName)
        {
            CultureInfo currentCi = null;

            try
            {
                // BUG: Have to set locale to en-US
                // http://support.microsoft.com/kb/320369/en

                currentCi = Thread.CurrentThread.CurrentCulture;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                string bookmark = string.Format("[[{0}]]", bookmarkName);

                // loop through the worksheets and search for the bookmark
                foreach (Worksheet wSheet in _currentWorkbook.Worksheets)
                {
                    if (wSheet.Cells.Find(bookmark, _missing, _missing, _missing, _missing, XlSearchDirection.xlNext, _missing, _missing) != null)
                    {
                        return true;
                    }
                }
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = currentCi;
            }

            return false;
        }

        public void EnsureApplicationIsRunning()
        {
            InitializeExcelApplication();
        }

        /// <summary>
        /// Exportes the current workbook into a DataSet.
        /// </summary>
        /// <returns>The exported DataSet</returns>
        public DataSet ExportCurrentWorkbookToDataSet()
        {
            if (_currentWorkbook == null)
            {
                throw new Exception("No workbook available.");
            }

            DataSet dataSet = new DataSet();
            int currentWorksheet = 1;

            foreach (Worksheet workSheet in _currentWorkbook.Worksheets)
            {
                DlgProgressLog.AddLine(KissMsg.GetMLMessage(CLASSNAME, "WorkSheetExport", "Worksheet {0} von {1}", currentWorksheet, _currentWorkbook.Worksheets.Count));
                System.Data.DataTable dataTable = ExportToDataTable(workSheet);
                dataSet.Tables.Add(dataTable);
                currentWorksheet += 1;
            }

            return dataSet;
        }

        /// <summary>
        /// Gets a list of bookmarks in this workbook.
        /// </summary>
        /// <returns>A list of bookmarks.</returns>
        public List<string> GetBookmarks()
        {
            var bookmarks = new List<string>();

            // BUG: Have to set locale to en-US
            // http://support.microsoft.com/kb/320369/en
            CultureInfo currentCi = Thread.CurrentThread.CurrentCulture;

            Range c;

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                foreach (Worksheet wSheet in _currentWorkbook.Worksheets)
                {
                    c = wSheet.Cells.Find("[[*]]", _missing, _missing, _missing, _missing, XlSearchDirection.xlNext, _missing, _missing);

                    // check if there is at least one result
                    if (c != null)
                    {
                        // the address of the first found range
                        string firstFound = c.Address[true, true];

                        while (true)
                        {
                            string val = c.Value2.ToString();
                            val = val.Trim('[', ']');

                            var index = val.IndexOf('.');

                            if (index > 0 && index < val.Length - 1)
                            {
                                val = val.Substring(index + 1);
                            }

                            bookmarks.Add(val);

                            // next match
                            Range next = wSheet.Cells.FindNext(c);

                            // get address to test if it is the same as the last
                            string address = next.Address[true, true];

                            if (firstFound == address)
                            {
                                break;
                            }

                            c = next;
                        }
                    }
                }
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = currentCi;
            }

            return bookmarks;
        }

        /// <summary>
        /// Open a Workbook.
        /// </summary>
        /// <param name="filename">Name of the doc.</param>
        /// <returns></returns>
        public void OpenWorkbook(String filename)
        {
            // init vars
            CultureInfo currentCi = null;

            try
            {
                // BUG: Have to set locale to en-US
                // http://support.microsoft.com/kb/320369/en

                currentCi = Thread.CurrentThread.CurrentCulture;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                // check if we already have workbooks open
                if (_excelApplication.Workbooks != null && _excelApplication.Workbooks.Count > 0)
                {
                    if (DisableMessageBox)
                    {
                        throw new KissErrorException("Excel-Dokumente sind offen. Bitte Excel schliessen.");
                    }

                    // TODO: in this case we possibly get an exception like this: "Exception from HRESULT: 0x800A03EC"
                    //       workaround: first save document, error will only appear in case of unsaved state of document

                    // <WORKAROUND IMPLEMENTATION>
                    // get window handle of foreground window (used to reactivate later)
                    IntPtr foregroundHwnd = ForegroundWindowHwnd();

                    // confirm saving all open workbooks
                    if (KissMsg.ShowQuestion(CLASSNAME, "ConfirmSavingAllOpenWorkbooks_v02", "Sie können nur dann ein weiteres Excel-Dokument öffnen, wenn alle Änderungen in Excel gespeichert werden.\r\n\r\nSoll KiSS jetzt alle durchgeführten Änderungen in den geöffneten Excel-Dokumenten speichern?"))
                    {
                        // logging
                        _logger.Debug("start saving all workbooks");

                        // loop all workbooks and save changes
                        foreach (Workbook wb in _excelApplication.Workbooks)
                        {
                            // save any changes
                            wb.Save();
                        }

                        // logging
                        _logger.Debug("done, all workbooks saved");

                        // bring last foreground window to front
                        ActivateWindowByHwnd(foregroundHwnd);

                        // logging
                        _logger.Debug("reactivated last foreground window");
                    }
                    else
                    {
                        // known bug, excel will throw an error like this if some changes are not saved: "Exception from HRESULT: 0x800A03EC"
                        _logger.Debug("will not save changes, excpect possible error 'Exception from HRESULT: 0x800A03EC'. Therefore cancel opening.");

                        // cancel
                        throw new KissCancelException("User canceled saving open excel documents, will cancel opening further excel documents.");
                    }
                    // </WORKAROUND IMPLEMENTATION>
                }

                // open file and get workbook
                if (_excelApplication.Workbooks == null)
                {
                    throw new KissErrorException("The document does not contain any workbook.");
                }

                _currentWorkbook = _excelApplication.Workbooks.Open(filename, _missing, _false, _missing, _missing, _missing, _missing, _missing, _missing, _true, _missing, _missing, _false);

                // apply document name from workbook
                _documentName = _currentWorkbook.Name;
            }
            catch (Exception ex)
            {
                // logging
                _logger.Warn("Error opening workbook.", ex);

                throw;
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = currentCi;
            }
        }

        /// <summary>
        /// Quits this instance.
        /// </summary>
        public void Quit()
        {
            // logging
            _logger.Debug("enter");

            try
            {
                // quit the application
                QuitExcelApplication(ExcelApplication);
            }
            catch (Exception ex)
            {
                _logger.Warn("quit failed, status unknown", ex);
            }

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Renames a bookmark in a template.
        /// </summary>
        /// <param name="oldName">The (old) name of the bookmark.</param>
        /// <param name="newName">The new name of the bookmark.</param>
        /// <param name="save">If <c>true</c>, the workbook is saved after renaming.</param>
        public void RenameBookmark(string oldName, string newName, bool save)
        {
            CultureInfo currentCi = null;

            try
            {
                // BUG: Have to set locale to en-US
                // http://support.microsoft.com/kb/320369/en
                currentCi = Thread.CurrentThread.CurrentCulture;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                foreach (Worksheet wSheet in _currentWorkbook.Worksheets)
                {
                    // look for cells containing [[MARKERNAME]]
                    Range c = wSheet.Cells.Find(string.Format("[[{0}]]", oldName));

                    string oldTag = string.Format("[[{0}]]", oldName);
                    string newTag = string.Format("[[{0}]]", newName);

                    while (c != null)
                    {
                        // write cell
                        c.Value2 = c.Value2 is string ? ((string)c.Value2).Replace(oldTag, newTag) : newTag;

                        // next match
                        c = wSheet.Cells.FindNext(c);
                    }
                }

                // save
                if (save)
                {
                    _currentWorkbook.Save();
                }
            }
            finally
            {
                // locales back to origin
                Thread.CurrentThread.CurrentCulture = currentCi;
            }
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            _currentWorkbook.Save();
        }

        /// <summary>
        /// Saves as.
        /// </summary>
        /// <param name="strFileName">Name of the STR file.</param>
        /// <param name="saveFormat">The XlFileFormat.</param>
        public void SaveAs(string strFileName, object saveFormat = null)
        {
            try
            {
                if (saveFormat == null)
                {
                    saveFormat = Missing.Value;
                }

                object fileName = strFileName;

                // save file
                //http://msdn.microsoft.com/en-us/library/bb214129%28office.12%29.aspx

                _currentWorkbook.SaveAs(fileName,  //Filename
                                       saveFormat,   //FileFormat
                                       _missing,   //Password
                                       _missing,   //WriteResPassword
                                       _false,     //ReadOnlyRecommended
                                       _missing,   //CreateBackup
                                       XlSaveAsAccessMode.xlNoChange,  //AccessMode
                                       _missing,  //ConflictResolution
                                       _false,    //AddToMru
                                       _missing,  //TextCodepage
                                       _missing); //TextVisualLayout
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
                _logger.Warn(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Sets the number format on certain columns
        /// </summary>
        /// <param name="columns">Columns to set the number format on, e.g. columns = "F:AI"</param>
        /// <param name="numberFormat">Number format, e.g. NumberFormat = "#'##0.00"</param>
        public void SetNumberFormatOnColumns(string columns, string numberFormat)
        {
            if (IsFirstWorksheetValid())
            {
                ((Range)((Worksheet)_currentWorkbook.Worksheets[1]).Columns[columns]).NumberFormatLocal = numberFormat;
            }
        }

        /// <summary>
        /// Sets the orientation for printing (landscape or portrait)
        /// </summary>
        /// <param name="orientation"></param>
        public void SetOrientationOnCurrentWorksheet(Orientation orientation)
        {
            if (IsFirstWorksheetValid())
            {
                ((Worksheet)_currentWorkbook.Worksheets[1]).PageSetup.Orientation = orientation == Orientation.Landscape ? XlPageOrientation.xlLandscape : XlPageOrientation.xlPortrait;
            }
        }

        /// <summary>
        /// Sets the page number (Seite 1 von 6) on the page footer.
        /// </summary>
        public void SetPageNumberInPageFooter()
        {
            if (IsFirstWorksheetValid())
            {
                ((Worksheet)_currentWorkbook.Worksheets[1]).PageSetup.CenterFooter = @"&P von &N";
            }
        }

        /// <summary>
        /// Sets the PrintTitleRow (Wiederholungszeile)
        /// </summary>
        /// <param name="columns">Columns in the title row. Bsp.: columns = "$1:$6</param>
        public void SetPrintTitleRow(string columns)
        {
            if (IsFirstWorksheetValid())
            {
                ((Worksheet)_currentWorkbook.Worksheets[1]).PageSetup.PrintTitleRows = columns;
            }
        }

        #endregion Public Methods

        #region Internal Methods

        /// <summary>
        /// Closes the document.
        /// </summary>
        public void CloseDocument()
        {
            // logging
            _logger.Debug("enter");

            object save = false;

            // do restore of document object
            RestoreDocumentObject();

            // check if we have a document object
            if (_currentWorkbook != null)
            {
                // logging
                _logger.Debug("close current workbook");

                CultureInfo currentCi = null;

                try
                {
                    // BUG: Have to set locale to en-US
                    // http://support.microsoft.com/kb/320369/en

                    currentCi = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                    // close
                    _currentWorkbook.Close(save, _missing, _missing);

                    // logging
                    _logger.Debug("try to release resources");

                    // release resources
                    Marshal.FinalReleaseComObject(_currentWorkbook);
                }
                catch (Exception ex)
                {
                    // logging
                    _logger.Warn("exception occured while releasing current workbook", ex);
                }
                finally
                {
                    Thread.CurrentThread.CurrentCulture = currentCi;
                }

                // logging
                _logger.Debug("do some GC stuff");

                // do garbage collecting
                GC.Collect();
                GC.WaitForPendingFinalizers();

                _currentWorkbook = null;
            }

            // closing is not really necessary at this point and slows down renaming of bookmarks
            // logging
            //logger.Debug("check if we can close application");
            // check if need to close excel
            //this.CheckNoMoreDocsOpenAndCloseApplication();

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Asks the user for save changes and close document.
        /// </summary>
        internal void AskUserForSaveChangesAndCloseDocument()
        {
            Visible = true;

            string documentName = _currentWorkbook.Name;
            bool saveChanges = KissMsg.ShowQuestion(KissMsg.GetMLMessage("XDokument", "SaveChanges_v01", "Dokument '{0}' ist offen. Sollen die Änderungen gespeichert werden?", KissMsgCode.MsgQuestion, documentName), true);

            if (saveChanges)
            {
                Save();
            }

            string fullname = _currentWorkbook.FullName;
            FileInfo file = new FileInfo(fullname);

            CloseDocument();

            FileUtilies.WaitForDocToBeRemovedFromFilesystem(file);
        }

        /// <summary>
        /// Creates the document from template.
        /// </summary>
        /// <param name="templateFileInfo">The template file info.</param>
        /// <param name="docFileInfo">The doc file info.</param>
        internal void CreateDocumentFromTemplate(FileInfo templateFileInfo, FileInfo docFileInfo)
        {
            object o = templateFileInfo.FullName;

            ExcelApplication.Visible = false;
            ExcelApplication.Workbooks.Add(o);

            _currentWorkbook = ExcelApplication.ActiveWorkbook;

            InstallKissTextmarkenAddIn();

            SaveAs(docFileInfo.FullName);
            _documentName = _currentWorkbook.Name;
        }

        /// <summary>
        /// Finds the open document.
        /// </summary>
        /// <param name="docName">Name of the doc.</param>
        /// <returns></returns>
        internal Workbook FindOpenDocument(String docName)
        {
            try
            {
                Int32 count = ExcelApplication.Workbooks.Count;

                for (Int32 i = 1; i <= count; i++)
                {
                    Object index = i;
                    Workbook wbook = ExcelApplication.Workbooks.Item[index];

                    if (wbook.Name.ToUpper().Equals(docName.ToUpper()))
                    {
                        return wbook;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Warn("error finding open document", ex);
                return null;
            }

            return null;
        }

        /// <summary>
        /// Opens the specified STR file name.
        /// Adds Kiss Textmarken
        /// Adds Connection Param for Kiss Textmarken
        /// </summary>
        /// <param name="strFileName">Name of the STR file.</param>
        /// <param name="isTemplate">if set to <c>true</c> [is template].</param>
        /// <param name="makeVisible">if set to <c>true</c> [make visible].</param>
        /// <param name="resetProtection">if set to <c>true</c> [reset protection].</param>
        internal void Open(string strFileName, bool isTemplate, bool makeVisible, bool resetProtection)
        {
            OpenWorkbook(strFileName);
            ExcelApplication.Visible = makeVisible;

            // check if valid workbook
            if (_currentWorkbook == null)
            {
                // workbook is required for further handling
                throw new NullReferenceException("Could not open workbook, returned value is null.");
            }

            CheckActivateReadOnlyProtectionForWorkBook();
            _documentName = _currentWorkbook.Name;

            // check if we need to add addin
            if (isTemplate)
            {
                InstallKissTextmarkenAddIn();

                if (OfficeUtils.CheckIsVersionOffice2013OrMore(_excelApplication.Version))
                {
                    //Excel 2013 : http://support.microsoft.com/kb/2761240
                    //Cammand bars of Excel add-ins are not dispayed or removed automatcially in Excel 2013 when you load or unload the add-ins
                    //Save and ReOpen WorkBook
                    _logger.Debug("WorkdBook Save");
                    Save();
                    _logger.Debug("WorkdBook Close");
                    _excelApplication.Workbooks.Close();
                    _logger.Debug("WorkdBook Open");
                    _excelApplication.Workbooks.Open(strFileName, _missing, _false, _missing, _missing, _missing, _missing, _missing, _missing, _true, _missing, _missing, _false);
                }
            }
        }

        #endregion Internal Methods

        #region Private Static Methods

        private static void ActivateWindowByHwnd(IntPtr hwndToActivate)
        {
            try
            {
                // validate
                if (hwndToActivate == IntPtr.Zero)
                {
                    // invalid pointer, do nothing
                    return;
                }

                // try to activate window by hwnd
                SetForegroundWindow(hwndToActivate);
            }
            catch (Exception ex)
            {
                // logging
                _logger.Warn("exception occured while activate window by handle", ex);
            }
        }

        private static void AddCustomDocumentProperty(Workbook workbook, string propertyName, string propertyValue)
        {
            try
            {
                // Add a property/value pair to the CustomDocumentProperties collection.
                // see: http://support.microsoft.com/kb/303296/de
                object oDocCustomProps = workbook.CustomDocumentProperties;
                Type typeDocCustomProps = oDocCustomProps.GetType();
                object[] oArgs = { propertyName, false, MsoDocProperties.msoPropertyTypeString, propertyValue };

                typeDocCustomProps.InvokeMember("Add", BindingFlags.Default | BindingFlags.InvokeMethod, null, oDocCustomProps, oArgs);
            }
            catch (Exception)
            {
                // could not add custom property...
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Break();
                }

                // throw further
                throw;
            }
        }

        private static void DeleteCustomDocumentProperty(Workbook workbook, String propertyName)
        {
            // see: http://www.experts-exchange.com/Software/Office_Productivity/Office_Suites/MS_Office/Word/Q_23773189.html

            try
            {
                object oDocCustomProps = workbook.CustomDocumentProperties;
                Type typeDocCustomProps = oDocCustomProps.GetType();
                object[] oArgs = new object[] { propertyName };

                object oKbProp = typeDocCustomProps.InvokeMember("Item", BindingFlags.Default | BindingFlags.GetProperty, null, oDocCustomProps, oArgs);
                Type typeKbProp = oKbProp.GetType();
                typeKbProp.InvokeMember("Delete", BindingFlags.Default | BindingFlags.InvokeMethod, null, oKbProp, null);
            }
            catch (Exception ex)
            {
                // could not remove custom property, it was possibly not yet initialized...
                _logger.Warn(string.Format("Could not remove custom property in Excel. Propertyname={0}", propertyName), ex);
            }
        }

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Checks the activate read only protection for work book.
        /// </summary>
        private void CheckActivateReadOnlyProtectionForWorkBook()
        {
            try
            {
                bool isReadonly = _currentWorkbook.ReadOnly;

                if (isReadonly)
                {
                    Worksheet sheet = (Worksheet)_currentWorkbook.ActiveSheet;
                    sheet.Unprotect(_missing);
                    sheet.Protect(_missing, _missing, _true, _missing, _missing);
                }
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }
        }

        private void CheckingForExcelReleaseInstanceAfterClosing()
        {
            // logging
            _logger.Debug("enter");

            // let the thread sleep for 2seconds
            Thread.Sleep(4000);

            // check if we have excel still open without any open workbooks
            CheckNoMoreDocsOpenAndCloseApplication();

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Checks the make visible only if wk BKS open.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private void CheckMakeVisibleOnlyIfWkBksOpen(bool value)
        {
            CultureInfo currentCi = null;

            try
            {
                // BUG: Have to set locale to en-US
                // http://support.microsoft.com/kb/320369/en

                currentCi = Thread.CurrentThread.CurrentCulture;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                if (value)
                {
                    int count = ExcelApplication.Workbooks.Count;

                    if (count > 0)
                    {
                        if (_currentWorkbook != null)
                        {
                            _currentWorkbook.Activate();
                        }

                        ExcelApplication.Visible = true;
                    }
                }
                else
                {
                    ExcelApplication.Visible = false;
                }
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = currentCi;
            }
        }

        /// <summary>
        /// Checks the no more docs open and close application.
        /// </summary>
        private void CheckNoMoreDocsOpenAndCloseApplication()
        {
            // logging
            _logger.Debug("enter");

            lock (_lockCheckMoreDocs)
            {
                // logging
                _logger.Debug("accessed multithreading protected part");

                try
                {
                    Workbooks wb = ExcelApplication.Workbooks;

                    // next statement sometimes throws RCW-error...
                    int count = wb.Count;

                    if (count < 1)
                    {
                        // logging
                        _logger.Debug("ExcelApplication.Workbooks.Count < 1, try to perform cleanup and quit excel application");

                        // close excel application
                        Quit();
                    }
                    else
                    {
                        // logging
                        _logger.DebugFormat("Still workbooks in use, will not quit excel application (ExcelApplication.Workbooks.Count = '{0}')", count);
                    }
                }
                catch (InvalidComObjectException coex)
                {
                    // log error
                    _logger.Warn("InvalidComObjectException detected!", coex);

                    // check if we still have connection to excel
                    if (coex.Message.StartsWith("COM object that has been separated from its underlying RCW cannot be used"))
                    {
                        // no more connection, try to quit
                        try
                        {
                            // logging
                            _logger.Warn("Try to quit excel application (no more connection with COM object)");

                            // close excel application
                            Quit();
                        }
                        catch (Exception ex)
                        {
                            // logging
                            _logger.Debug("Quit excel application failed.", ex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // log error
                    _logger.Warn("Error checking open workbooks, status unknown!", ex);
                }
            }

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Disables all Excel addins whose file name contains something like KissTextmarkenAddIn.
        /// </summary>
        private void DisableOldAddIns()
        {
            try
            {
                foreach (AddIn addIn in _excelApplication.AddIns)
                {
                    if (!string.IsNullOrEmpty(addIn.FullName) &&
                            addIn.FullName.ToUpper().Contains(ADDIN_FILE_NAME_BASE.ToUpper())
                        )
                    {
                        addIn.Installed = false;
                        _logger.Debug("AddIn.FullName=" + addIn.FullName + " changed to Installed=false");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Debug("Error in DisableOldAddIns()", ex);
            }
        }

        /// <summary>
        /// Exportes a worksheet to a DataTable
        /// </summary>
        /// <param name="workSheet">The worksheet to export</param>
        /// <returns>The exported DataTable</returns>
        private System.Data.DataTable ExportToDataTable(Worksheet workSheet)
        {
            System.Data.DataTable table = new System.Data.DataTable(workSheet.Name);

            if (_currentWorkbook == null)
            {
                throw new Exception("Workbook not found.");
            }

            if (workSheet == null)
            {
                throw new Exception("Worksheet not found.");
            }

            int columnIndex = 1;

            while (workSheet.Cells[1, columnIndex] != null && ((Range)workSheet.Cells[1, columnIndex]).Value2 != null)
            {
                string columnName = ((Range)workSheet.Cells[1, columnIndex]).Value2.ToString();
                table.Columns.Add(columnName);
                columnIndex += 1;
            }

            int rowIndex = 2;
            bool rowIsEmpty = false;
            DlgProgressLog.AddLine("");

            for (; !rowIsEmpty; rowIndex++)
            {
                DlgProgressLog.UpdateLastLine(KissMsg.GetMLMessage(CLASSNAME, "RowExport", "Zeile {0}", rowIndex - 1));
                rowIsEmpty = true;
                DataRow row = table.NewRow();

                for (columnIndex = 1; columnIndex <= table.Columns.Count; columnIndex++)
                {
                    row[columnIndex - 1] = ((Range)workSheet.Cells[rowIndex, columnIndex]).Value2;

                    if (!DBUtil.IsEmpty(row[columnIndex - 1]))
                    {
                        rowIsEmpty = false;
                    }
                }

                if (!rowIsEmpty)
                {
                    table.Rows.Add(row);
                }
            }

            return table;
        }

        /// <summary>
        /// Get the handle of the current foreground window (in most cases, this will be Excel)
        /// </summary>
        /// <returns>The window handle as pointer</returns>
        private IntPtr ForegroundWindowHwnd()
        {
            try
            {
                // get hwnd of foreground window
                return GetForegroundWindow();
            }
            catch (Exception ex)
            {
                // logging
                _logger.Warn("exception occured while getting foreground window handle", ex);

                // return empty pointer
                return IntPtr.Zero;
            }
        }

        /// <summary>
        /// Initializes the excel application.
        /// </summary>
        private void InitializeExcelApplication()
        {
            // logging
            _logger.Debug("enter");

            lock (_lockInitExcelApp)
            {
                // logging
                _logger.Debug("accessed multithreading protected part");

                // activate the interface with the existing COM object of Microsoft Excel if possible
                try
                {
                    // try to get active object (if any, otherwise failure of following call)
                    _excelApplication = (Application)Marshal.GetActiveObject("Excel.Application");
                    //InitializeExcelApplicationInNewProcess();

                    // logging
                    _logger.Debug("reused excel application");
                }
                catch (Exception ex)
                {
                    // logging
                    _logger.Warn(ex);

                    // init new excel process
                    InitializeExcelApplicationInNewProcess();

                    // logging
                    _logger.Debug("created new excel application");
                }

                // un/register check event
                _excelApplication.WindowDeactivate -= WindowDeactivate;
                _excelApplication.WindowDeactivate += WindowDeactivate;
            }

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Initializes the excel application in new process.
        /// </summary>
        private void InitializeExcelApplicationInNewProcess()
        {
            // logging
            _logger.Debug("enter");

            lock (_lockInitExcelAppNewProcess)
            {
                // logging
                _logger.Debug("accessed multithreading protected part");

                _excelApplication = new Application();
                _excelApplication.Visible = false;
            }

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Installs KiSS Textmarken as Addin
        /// </summary>
        /// <returns></returns>
        private void InstallKissTextmarkenAddIn()
        {
            // logging
            _logger.Debug("enter in InstallKissTextmarkenAddIn");

            CultureInfo currentCi = null;

            try
            {
                // first remove all custom properties, to be sure we have it only once
                DeleteCustomDocumentProperty(_currentWorkbook, PARAM_CONNECTION_STRING);
                DeleteCustomDocumentProperty(_currentWorkbook, PARAM_LANGUAGE_CODE);

                DeleteCustomDocumentProperty(_currentWorkbook, PARAM_TEXTFRMTITLE);
                DeleteCustomDocumentProperty(_currentWorkbook, PARAM_TEXTBTNADD);
                DeleteCustomDocumentProperty(_currentWorkbook, PARAM_TEXTBTNCLOSE);

                //add custom properties
                string connectionString = FileUtilies.OLEDBConnectionString;
                AddCustomDocumentProperty(_currentWorkbook, PARAM_CONNECTION_STRING, connectionString);

                string languageCode = Session.User.LanguageCode.ToString();
                AddCustomDocumentProperty(_currentWorkbook, PARAM_LANGUAGE_CODE, languageCode);

                //Falls kein Text in der DB - Defaultwert im Template so lassen - Property dann gar nicht einfügen
                string propertyValueTextFrmTitle = KissMsg.GetMLMessage("FrmTextmarkenTemplate", "TextFrmTitle", string.Empty);
                if (!propertyValueTextFrmTitle.Equals(string.Empty))
                {
                    AddCustomDocumentProperty(_currentWorkbook, PARAM_TEXTFRMTITLE, propertyValueTextFrmTitle);
                }

                string propertyValueTextBtnAdd = KissMsg.GetMLMessage("FrmTextmarkenTemplate", "TextBtnAdd", string.Empty);
                if (!propertyValueTextBtnAdd.Equals(string.Empty))
                {
                    AddCustomDocumentProperty(_currentWorkbook, PARAM_TEXTBTNADD, propertyValueTextBtnAdd);
                }

                string propertyValueTextBtnClose = KissMsg.GetMLMessage("FrmTextmarkenTemplate", "TextBtnClose", string.Empty);
                if (!propertyValueTextBtnClose.Equals(string.Empty))
                {
                    AddCustomDocumentProperty(_currentWorkbook, PARAM_TEXTBTNCLOSE, propertyValueTextBtnClose);
                }

                // BUG: Have to set locale to en-US
                // http://support.microsoft.com/kb/320369/en
                currentCi = Thread.CurrentThread.CurrentCulture;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                #region HACK: see #6770 - as we cannot remove addin, we need to install a unique one per build

                DisableOldAddIns();

                // Copy the addin to the user appdata location of kiss

                // Prepare originalFilePath depeding of the version
                var workingCopy = OfficeUtils.CreateAddinWorkingCopy(
                    _excelApplication.Version,
                    true,
                    ADDIN_FILE_NAME_OFFICE2010ANDBEFORE,
                    ADDIN_EXTENSION_OFFICE2010ANDBEFORE,
                    ADDIN_FILE_NAME_OFFICE2013,
                    ADDIN_EXTENSION_OFFICE2013);

                #endregion HACK: see #6770 - as we cannot remove addin, we need to install a unique one per build

                // Add and install the addin
                _logger.Debug("Add addin");
                var addIn = _excelApplication.AddIns.Add(workingCopy, false);
                addIn.Installed = true;
                _logger.Debug("addIn.Installed=" + addIn.Installed.ToString() + ". addIn.FullName=" + addIn.FullName);
                _excelApplication.Run("KissTextmarken.MakeMenu");
            }
            catch (Exception ex)
            {
                Visible = false;
                KissMsg.ShowError("WordControl", "FehlerInstallationTextmarke", "Fehler bei der Installation des KissTextmarken-AddIn", ex);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = currentCi;
            }
        }

        private bool IsFirstWorksheetValid()
        {
            return (_currentWorkbook != null && _currentWorkbook.Worksheets.Count >= 1 && _currentWorkbook.Worksheets[1] != null);
        }

        /// <summary>
        /// Quits the Excel application.
        /// </summary>
        /// <param name="xlsApplication">The XLS application.</param>
        private void QuitExcelApplication(Application xlsApplication)
        {
            // logging
            _logger.Debug("enter");

            lock (_lockQuit)
            {
                // logging
                _logger.Debug("accessed multithreading protected part");

                // check if we have a workbook instance
                if (_currentWorkbook != null)
                {
                    try
                    {
                        // logging
                        _logger.Debug("try to release workbook");

                        // release com for workbook (this will separate instance with RCW...)
                        Marshal.FinalReleaseComObject(_currentWorkbook);

                        // cleanup workbook
                        _currentWorkbook = null;
                    }
                    catch (Exception ex)
                    {
                        // logging
                        _logger.Warn("Failed releasing workbook", ex);
                    }
                }

                // check if we already have closed excel
                if (xlsApplication == null)
                {
                    // logging
                    _logger.Debug("xlsApplication already null, done with quit");

                    // already closed, cancel call
                    return;
                }

                try
                {
                    // logging
                    _logger.Debug("calling xlsApplication.Quit()");

                    // TODO: xlsApplication.Quit() leaves Excel.exe process open!!
                    // try to quit excel
                    xlsApplication.Quit();

                    try
                    {
                        // wait a moment for excel-quit
                        Thread.Sleep(500);

                        // logging
                        _logger.Debug("calling Marshal.ReleaseComObject(xlsApplication)");

                        // release com (this will separate instance with RCW...)
                        Marshal.ReleaseComObject(xlsApplication);
                    }
                    catch (Exception ex)
                    {
                        // logging
                        _logger.Warn("exception with ReleaseComObject occured", ex);
                    }
                }
                catch (Exception ex)
                {
                    // logging
                    _logger.Warn("exception with Quit occured", ex);
                }
                finally
                {
                    // logging
                    _logger.Debug("running finally now");

                    // let garbage collector do something
                    /*
                     * >> this call will crash KiSS without any error message or exception. therefore it will not be executed anymore.
                     * GC.WaitForPendingFinalizers();
                     */

                    // clear instance
                    xlsApplication = null;
                }
            }

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Restores the document object.
        /// </summary>
        private void RestoreDocumentObject()
        {
            // logging
            _logger.Debug("enter");

            if (_currentWorkbook != null)
            {
                try
                {
                    // logging
                    _logger.Debug("try to release com object");

                    // cleanup
                    Marshal.ReleaseComObject(_currentWorkbook);
                }
                catch (Exception ex)
                {
                    // logging
                    _logger.Warn("exception occured while releasing com object of workbook", ex);
                }

                // reset
                _currentWorkbook = null;
            }

            if (_documentName != null)
            {
                _currentWorkbook = FindOpenDocument(_documentName);
            }

            // logging
            _logger.DebugFormat("_CurrentWorbook = '{0}'", _currentWorkbook);
            _logger.Debug("done");
        }

        /// <summary>
        /// Works the book before close.
        /// </summary>
        /// <param name="workbook">The workbook</param>
        /// <param name="window">The window</param>
        private void WindowDeactivate(Workbook workbook, Window window)
        {
            // create new thread that calls method
            ThreadStart threadStart = CheckingForExcelReleaseInstanceAfterClosing;
            var thread = new Thread(threadStart);

            // set single-threaded apartment (see: http://samgentile.com/Web/clr-and-net-framework/a-beasty-com-interop-problem/)
            thread.SetApartmentState(ApartmentState.STA);

            // start thread
            thread.Start();
        }

        #endregion Private Methods

        #endregion Methods
    }
}