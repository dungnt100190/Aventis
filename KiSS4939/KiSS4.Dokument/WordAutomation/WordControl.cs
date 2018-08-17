using BIAG.AssemblyInfo;
using Kiss.Interfaces.DocumentHandling;
using KiSS4.DB;
using KiSS4.Dokument.MsOfficeCommons;
using KiSS4.Dokument.Utilities;
using KiSS4.Messages;
using Microsoft.Practices.Unity;
using Microsoft.Vbe.Interop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Word;
using Application = Interop.Excel.Application;

namespace KiSS4.Dokument.WordAutomation
{
    #region Enumerations

    /// <summary>
    /// Enumeration for the format of a Textmarke.
    /// </summary>
    public enum TextMarkFormat
    {
        /// <summary>
        /// Table.
        /// </summary>
        Table,

        /// <summary>
        /// Frame.
        /// </summary>
        Frame,

        /// <summary>
        /// None.
        /// </summary>
        None
    }

    /// <summary>
    /// Enumeration for type of a Textmarke.
    /// </summary>
    public enum TextMarkType
    {
        /// <summary>
        /// Grid.
        /// </summary>
        Grid,

        /// <summary>
        /// Simple.
        /// </summary>
        Simple,

        /// <summary>
        /// Merge Fields.
        /// </summary>
        MergeField
    }

    /// <summary>
    /// Font styles.
    /// </summary>
    public enum WordFontStyle
    {
        /// <summary>
        /// Bold font.
        /// </summary>
        Bold,

        /// <summary>
        /// Italic font.
        /// </summary>
        Italic,

        /// <summary>
        /// Underlined.
        /// </summary>
        Underlined,

        /// <summary>
        /// Justified.
        /// </summary>
        Justify
    }

    /// <summary>
    /// Enumeration for horizontal paragraph alignments.
    /// </summary>
    public enum WordParagraphAlignment
    {
        /// <summary>
        /// Align left.
        /// </summary>
        Left,

        /// <summary>
        /// Align rigth.
        /// </summary>
        Right,

        /// <summary>
        /// Align Center.
        /// </summary>
        Center,

        /// <summary>
        /// Justify.
        /// </summary>
        Justify
    }

    /// <summary>
    /// Enumeration for insert postions.
    /// </summary>
    public enum WordTableInsertPosition
    {
        /// <summary>
        /// Insert below.
        /// </summary>
        Below,

        /// <summary>
        /// Insert above.
        /// </summary>
        Above
    }

    #endregion Enumerations

    /// <summary>
    /// Container Class that implements general methods to control a
    /// WordApplication object model 9.0
    /// </summary>
    /// TODO: Add Code to supervise the process for Microsoft Word.
    public class WordControl : IWordControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion Private Static Fields

        #region Private Constant/Read-Only Fields

        private const string ADDIN_EXTENSION_OFFICE2010ANDBEFORE = ".dot";
        private const string ADDIN_EXTENSION_OFFICE2013 = ".dot";
        private const string ADDIN_FILE_NAME_OFFICE2010ANDBEFORE = "KissTextmarkenAddIn";
        private const string ADDIN_FILE_NAME_OFFICE2013 = "KissTextmarkenAddIn_Office2013";
        private const string CLASSNAME = "WordControl";
        private const string PARAM_CONNECTION_STRING = "ConnectionStringParam";
        private const string PARAM_LANGUAGE_CODE = "LanguageCodeParam";

        private const string PARAM_TEXTBTNADD = "TextBtnAdd";
        private const string PARAM_TEXTBTNCLOSE = "TextBtnClose";
        private const string PARAM_TEXTFRMTITLE = "TextFrmTitle";

        #endregion Private Constant/Read-Only Fields

        #region Private Fields

        /// <summary>
        /// Current document view
        /// </summary>
        private WdViewType _currentView;

        /// <summary>
        /// Indicates whether the word document has some kind of protection enabled.
        /// </summary>
        private bool _hasProtection;

        private Document _oDoc;

        /// <summary>
        /// Indicates whether the word application was started by KiSS.
        /// </summary>
        private bool _wasStarted;

        /// <summary>
        /// Controlled instance of Microsoft Word.
        /// </summary>
        private Word.Application _wordApplication;

        #endregion Private Fields

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WordControl"/> class.
        /// </summary>
        [InjectionConstructor]
        public WordControl()
        {
            _logger.Debug("Create WordControl.");
            _wordApplication = GetWordInstance(out _wasStarted);
        }

        #endregion Constructors

        #region Properties

        public bool DisableMessageBox { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="WordControl"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public Boolean Visible
        {
            get
            {
                try
                {
                    return _wordApplication.Visible;
                }
                catch (Exception ex)
                {
                    _logger.Warn(ex);
                    return false;
                }
            }
            set
            {
                try
                {
                    _wordApplication.Visible = value;
                }
                catch (Exception ex)
                {
                    _logger.Warn(ex);
                    return;
                }

                // check if set_Visible() to true
                if (value)
                {
                    try
                    {
                        if (_oDoc != null)
                        {
                            _oDoc.Activate();
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Warn(ex);
                    }

                    _wordApplication.Activate();
                }
            }
        }

        #endregion Properties

        #region Methods

        #region Public Methods

        /// <summary>
        /// Adds the textmark.
        /// </summary>
        /// <param name="name">The name.</param>
        public void AddBookmark(string name)
        {
            object range = _wordApplication.Selection.Range;

            if (!_oDoc.Bookmarks.Exists(name))
            {
                _oDoc.Bookmarks.Add(name, ref range);
                _oDoc.Bookmarks.DefaultSorting = WdBookmarkSortBy.wdSortByName;
                _oDoc.Bookmarks.ShowHidden = false;
            }
        }

        /// <summary>
        /// Adds the custom doc property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The value.</param>
        public void AddCustomDocProperty(string propertyName, string value)
        {
            object obj = value;
            _oDoc.Variables.Add(propertyName, ref obj);
        }

        /// <summary>
        /// Adds the tabulation.
        /// </summary>
        /// <param name="centimeters">The centimeters.</param>
        /// <param name="type">The type.</param>
        /// <param name="clearOther">if set to <c>true</c> clears all tab stops.</param>
        public void AddTabulation(float centimeters, string type, bool clearOther)
        {
            object leader = WdTabLeader.wdTabLeaderSpaces;
            object alignment = null;

            _oDoc.DefaultTabStop = centimeters;

            if (clearOther)
            {
                _wordApplication.Selection.ParagraphFormat.TabStops.ClearAll();
            }

            switch (type)
            {
                case "Left":
                    alignment = WdTabAlignment.wdAlignTabLeft;
                    break;

                case "Right":
                    alignment = WdTabAlignment.wdAlignTabRight;
                    break;

                case "Center":
                    alignment = WdTabAlignment.wdAlignTabCenter;
                    break;

                case "Decimal":
                    alignment = WdTabAlignment.wdAlignTabDecimal;
                    break;
            }

            _wordApplication.Selection.ParagraphFormat.TabStops.Add(_wordApplication.CentimetersToPoints(centimeters), ref alignment, ref leader);
        }

        /// <summary>
        /// Checks if a bookmark exists in the document.
        /// </summary>
        /// <param name="name">The name of the bookmark to check.</param>
        /// <returns><c>True</c>, if the specified bookmark exists.</returns>
        public bool BookmarkExists(string name)
        {
            foreach (Bookmark b in _oDoc.Bookmarks)
            {
                if (b.Name.ToLower() == name.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets a CR/LF separated List of all Bookmarks (Name,Start,Stop)
        /// </summary>
        /// <returns></returns>
        public string BookmarkList()
        {
            string list = "";

            _oDoc.Bookmarks.DefaultSorting = WdBookmarkSortBy.wdSortByLocation;

            foreach (Bookmark b in _oDoc.Bookmarks)
            {
                list += string.Format("{0}, {1}, {2}\r\n", b.Name, b.Start, b.End);
            }

            return list;
        }

        /// <summary>
        /// Closes the document.
        /// </summary>
        public void CloseActiveDocument()
        {
            if (_oDoc != null)
            {
                try
                {
                    object save = false;
                    object missing = System.Reflection.Missing.Value;
                    _oDoc.Close(ref save, ref missing, ref missing);
                    ReleaseCOMObject(_oDoc);
                    _oDoc = null;
                }
                catch (Exception ex)
                {
                    _logger.Warn(ex);
                }
            }
        }

        /// <summary>
        /// Deletes the bookmark and text.
        /// </summary>
        /// <param name="bookmark">The bookmark.</param>
        public void DeleteBookmarkAndText(string bookmark)
        {
            object bm = bookmark;
            object unit = WdUnits.wdWord;
            object count = 1;

            try
            {
                GotoBookMark(bookmark);
                _wordApplication.Selection.Bookmarks.Item(ref bm).Delete();
                _wordApplication.Selection.Delete(ref unit, ref count);
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }
        }

        /// <summary>
        /// Deletes the next extended.
        /// </summary>
        public void DeleteNextExtended()
        {
            object unit = WdUnits.wdCharacter;
            object count1 = 1;
            object extend = WdMovementType.wdExtend;

            _wordApplication.Selection.MoveRight(ref unit, ref count1, ref extend);
            _wordApplication.Selection.Delete(ref unit, ref count1);
        }

        public void EnsureApplicationIsRunning()
        {
            _wordApplication = GetWordInstance(out _wasStarted);
        }

        /// <summary>
        /// Retrieves all TextMarks in a WordTemplate.
        /// Checks for each TextMark if it is an original TextMark or an
        /// occurency of an existing one
        /// </summary>
        /// <returns></returns>
        public DataTable GetBookmarkList()
        {
            BookmarkHelper helper = new BookmarkHelper();

            _oDoc.Bookmarks.DefaultSorting = WdBookmarkSortBy.wdSortByLocation;

            foreach (Bookmark b in _oDoc.Bookmarks)
            {
                helper.AddBookmark(b);
            }

            return helper.Bookmarks;
        }

        /// <summary>
        /// Gets the bookmarks of this document.
        /// </summary>
        public List<string> GetBookmarks()
        {
            return _oDoc.Bookmarks.Cast<Bookmark>().Select(bookmark => bookmark.Name).ToList();
        }

        public List<string> GetMacros()
        {
            List<string> macros = new List<string>();
            foreach (VBProject vbProject in _oDoc.VBProject.VBE.VBProjects)
            {
                if (vbProject.Protection == vbext_ProjectProtection.vbext_pp_none)
                {
                    foreach (VBComponent vbComponent in vbProject.VBComponents)
                    {
                        string oldMacro = string.Empty;
                        for (int i = 1; i < vbComponent.CodeModule.CountOfLines; i++)
                        {
                            vbext_ProcKind procKind;
                            string newMacro = vbComponent.CodeModule.get_ProcOfLine(i, out procKind);
                            if (newMacro != oldMacro && newMacro != string.Empty)
                            {
                                macros.Add(newMacro);
                                oldMacro = newMacro;
                            }
                        }
                    }
                }
            }

            return macros;
        }

        /// <summary>
        /// Go to a predefined TextMark, if the TextMark doesn't exists the application will raise an error
        /// </summary>
        /// <param name="strBookMarkName">Name of the STR book mark.</param>
        public void GotoBookMark(string strBookMarkName)
        {
            object nameBookMark = strBookMarkName;

            try
            {
                _oDoc.Bookmarks.Item(ref nameBookMark).Select();
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);

                DlgProgressLog.AddError(KissMsg.GetMLMessage(
                    CLASSNAME,
                    "TextmarkeNichtGefunden",
                    "FEHLER: Textmarke '{0}' im Word-Dokument nicht (mehr)gefunden!",
                    KissMsgCode.Text,
                    nameBookMark.ToString()
                ));

                // It is possible that two bookmarks have been wrongly inserted at the same place by
                // user and when first bookmarks has is value set, second bookmark is deleted so when trying
                // to set second bookmark's value in word there is an error saying bookmark cannot be found
            }
        }

        /// <summary>
        /// Goes to down cell.
        /// </summary>
        public void GoToDownCell()
        {
            object missing = System.Reflection.Missing.Value;
            object direction = WdUnits.wdLine;
            _wordApplication.Selection.MoveDown(ref direction, ref missing, ref missing);
        }

        /// <summary>
        /// Goes to left cell.
        /// </summary>
        public void GoToLeftCell()
        {
            object missing = System.Reflection.Missing.Value;
            object direction = WdUnits.wdCell;
            _wordApplication.Selection.MoveLeft(ref direction, ref missing, ref missing);
        }

        /// <summary>
        /// Goes to next field.
        /// </summary>
        public void GoToNextField()
        {
            _wordApplication.Selection.NextField();
        }

        /// <summary>
        /// Goes to right cell.
        /// </summary>
        /// <param name="endOfLine">if set to <c>true</c> [end of line].</param>
        public void GoToRightCell(bool endOfLine)
        {
            // Selection.MoveRight Unit:=wdCell
            object missing = System.Reflection.Missing.Value;
            object unit = WdUnits.wdCell;

            try
            {
                _wordApplication.Selection.MoveRight(ref unit, ref missing, ref missing);
            }
            catch (COMException ex)
            {
                // don't care if cell is missing, insert a tab instead
                _logger.Debug(ex);

                if (endOfLine)
                {
                    InsertText(((char)11).ToString());
                }
                else
                {
                    //InsertText(((char) 13).ToString());// + ((char) 10).ToString());
                    InsertText(((char)9).ToString());
                }
            }
        }

        /// <summary>
        /// Goes to the beginning.
        /// </summary>
        public void GoToTheBeginning()
        {
            // VB: Selection.HomeKey Unit:=wdStory
            object missing = System.Reflection.Missing.Value;
            object unit = WdUnits.wdStory;
            _wordApplication.Selection.HomeKey(ref unit, ref missing);
        }

        /// <summary>
        /// Goes to the end.
        /// </summary>
        public void GoToTheEnd()
        {
            // VB:  Selection.EndKey Unit:=wdStory
            object missing = System.Reflection.Missing.Value;
            object unit = WdUnits.wdStory;
            _wordApplication.Selection.EndKey(ref unit, ref missing);
        }

        /// <summary>
        /// Goes to the table.
        /// </summary>
        /// <param name="ntable">The ntable.</param>
        public void GoToTheTable(int ntable)
        {
            object missing = System.Reflection.Missing.Value;
            object what = WdUnits.wdTable;
            object which = WdGoToDirection.wdGoToFirst;
            object count = 1;

            _wordApplication.Selection.GoTo(ref what, ref which, ref count, ref missing);
            _wordApplication.Selection.Find.ClearFormatting();
            _wordApplication.Selection.Text = "";
        }

        /// <summary>
        /// Goes to up cell.
        /// </summary>
        public void GoToUpCell()
        {
            object missing = System.Reflection.Missing.Value;
            object direction = WdUnits.wdLine;
            _wordApplication.Selection.MoveUp(ref direction, ref missing, ref missing);
        }

        /// <summary>
        /// Inserts the database.
        /// </summary>
        /// <param name="textMark">The text mark.</param>
        /// <param name="dataSource">The data source.</param>
        /// <param name="format">The format.</param>
        public void InsertDatabase(string textMark, string dataSource, TextMarkFormat format)
        {
            object databaseFormat = 0;
            object style = 0;
            object linkToSource = false;
            object includeFields = true;
            object ds = dataSource;

            GotoBookMark(textMark);
            _wordApplication.Selection.Range.InsertDatabase(ref databaseFormat, ref style, ref linkToSource, DataSource: ref ds, IncludeFields: ref includeFields);
            _wordApplication.Selection.GoToNext(WdGoToItem.wdGoToTable);
            _wordApplication.Selection.EscapeKey();
            _wordApplication.Selection.Select();

            switch (format)
            {
                case TextMarkFormat.Frame:
                    _wordApplication.Selection.Tables.Item(1).Select();
                    _wordApplication.Selection.Borders.Item(WdBorderType.wdBorderHorizontal).LineStyle = WdLineStyle.wdLineStyleNone;
                    _wordApplication.Selection.Tables.Item(1).Select();
                    _wordApplication.Selection.Borders.Item(WdBorderType.wdBorderVertical).LineStyle = WdLineStyle.wdLineStyleNone;
                    break;

                case TextMarkFormat.Table:
                    break;

                case TextMarkFormat.None:
                    _wordApplication.Selection.Tables.Item(1).Select();
                    _wordApplication.Selection.Borders.Item(WdBorderType.wdBorderTop).LineStyle = WdLineStyle.wdLineStyleSingle;
                    _wordApplication.Selection.Tables.Item(1).Select();
                    _wordApplication.Selection.Borders.Item(WdBorderType.wdBorderBottom).LineStyle = WdLineStyle.wdLineStyleSingle;
                    _wordApplication.Selection.Tables.Item(1).Select();
                    _wordApplication.Selection.Borders.Item(WdBorderType.wdBorderLeft).LineStyle = WdLineStyle.wdLineStyleSingle;
                    _wordApplication.Selection.Tables.Item(1).Select();
                    _wordApplication.Selection.Borders.Item(WdBorderType.wdBorderRight).LineStyle = WdLineStyle.wdLineStyleNone;
                    _wordApplication.Selection.Tables.Item(1).Select();
                    _wordApplication.Selection.Borders.Item(WdBorderType.wdBorderVertical).LineStyle = WdLineStyle.wdLineStyleNone;
                    _wordApplication.Selection.Borders.Item(WdBorderType.wdBorderHorizontal).LineStyle = WdLineStyle.wdLineStyleNone;
                    _wordApplication.Selection.Tables.Item(1).Select();
                    break;
            }
        }

        /// <summary>
        /// Inserts the date time.
        /// </summary>
        public void InsertDateTime()
        {
            object datetimeformat = "d. MMMM yyyy";
            _wordApplication.Selection.InsertDateTime(ref datetimeformat);
        }

        /// <summary>
        /// Inserts the grid.
        /// </summary>
        /// <param name="bookmark">The text mark.</param>
        /// <param name="dt">The dt.</param>
        /// <param name="columnCount">The column count.</param>
        public void InsertGrid(string bookmark, DataTable dt, int columnCount)
        {
            if (dt.Rows.Count > 0)
            {
                GotoBookMark(bookmark);

                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        InsertText(dr[dc.Ordinal].ToString());

                        // Check if we are at end of line
                        if (dc.Ordinal == dt.Columns.Count - 1)
                        {
                            GoToRightCell(true);
                        }
                        else
                        {
                            GoToRightCell(false);
                        }
                    }
                }
            }
            else
            {
                DeleteBookmarkAndText(bookmark);
            }
        }

        /// <summary>
        /// Inserts the line break.
        /// </summary>
        public void InsertLineBreak()
        {
            _wordApplication.Selection.TypeParagraph();
        }

        /// <summary>
        /// Inserts the line break.
        /// </summary>
        /// <param name="nline">The number of line breaks.</param>
        public void InsertLineBreak(int nline)
        {
            for (int i = 0; i < nline; i++)
            {
                _wordApplication.Selection.TypeParagraph();
            }
        }

        /// <summary>
        /// Inserts the merge field.
        /// </summary>
        /// <param name="textMark">The text mark.</param>
        /// <param name="fieldName">Name of the field.</param>
        public void InsertMergeField(string textMark, string fieldName)
        {
            GotoBookMark(textMark);
            object range = _wordApplication.Selection.Range;
            object type = WdFieldType.wdFieldMergeField;
            object text = fieldName;
            object preserveFormatting = "true";
            _wordApplication.Selection.Fields.Add((Range)range, ref type, ref text, ref preserveFormatting);
        }

        /// <summary>
        /// Inserts the pagebreak.
        /// </summary>
        public void InsertPagebreak()
        {
            // VB: Selection.InsertBreak Type:=wdPageBreak
            object pBreak = Convert.ToInt32(WdBreakType.wdPageBreak);
            _wordApplication.Selection.InsertBreak(ref pBreak);
        }

        /// <summary>
        /// Insert rows below functionnality for word 97 compatibility
        /// </summary>
        /// <param name="nbRows">The number of rows that are inserted.</param>
        public void InsertRow(int nbRows)
        {
            object nbRowsTemp = nbRows;
            _wordApplication.Selection.InsertRows(ref nbRowsTemp);
        }

        /// <summary>
        /// Inserts the RTF.
        /// </summary>
        /// <param name="bookmarkName">Name of the bookmark.</param>
        public void InsertRTF(string bookmarkName)
        {
            if (!DBUtil.IsEmpty(bookmarkName))
            {
                GotoBookMark(bookmarkName);
            }

            _wordApplication.Selection.Paste();
        }

        /// <summary>
        /// Inserts the shift line feed.
        /// </summary>
        public void InsertShiftLineFeed()
        {
            _wordApplication.Selection.TypeText(Convert.ToChar(11).ToString());
        }

        /// <summary>
        /// Inserts the table.
        /// </summary>
        /// <param name="nbRows">The nb rows.</param>
        /// <param name="nbCol">The nb col.</param>
        public void InsertTable(int nbRows, int nbCol)
        {
            // adapted for word 97 compatibility
            Range range = _wordApplication.Selection.Range;
            _oDoc.Tables.Add(range, nbRows, nbCol);
        }

        /// <summary>
        /// Inserts the text.
        /// </summary>
        /// <param name="strText">The STR text.</param>
        public void InsertText(string strText)
        {
            _wordApplication.Selection.TypeText(strText);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataSourcePath">The data source path.</param>
        /// <param name="file">The file.</param>
        public void MailMerge(string dataSourcePath, FileInfo file)
        {
            object format = WdOpenFormat.wdOpenFormatText;
            object confirmConversions = false;
            object readOnly = false;
            object linkToSource = true;
            object missing = System.Reflection.Missing.Value;
            object pause = true;
            //TODO add nested sql statement functionnality
            object saveChanges = false;

            _oDoc.MailMerge.OpenDataSource(dataSourcePath, ref format, ref confirmConversions, ref readOnly, ref linkToSource, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            _oDoc.MailMerge.Destination = WdMailMergeDestination.wdSendToNewDocument;
            _oDoc.MailMerge.MailAsAttachment = false;
            _oDoc.MailMerge.SuppressBlankLines = true;
            _oDoc.MailMerge.Execute(ref pause);

            // close main document and set doc to mail merge result for savingss
            _oDoc.Close(ref saveChanges, ref missing, ref missing);
            _oDoc = _wordApplication.ActiveWindow.Document;
        }

        /// <summary>
        /// News the paragraph.
        /// </summary>
        public void NewParagraph()
        {
            _wordApplication.Selection.TypeParagraph();
        }

        /// <summary>
        /// Create empty template and save it to disk
        /// </summary>
        /// <param name="filePath">The template filename.</param>
        /// <exception cref="ArgumentException"></exception>
        public void NewTemplate(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("Template path is invalid", filePath);
            }

            object missing = System.Reflection.Missing.Value;

            // Create empty template
            object newTemplate = true;

            _oDoc = _wordApplication.Documents.Add(ref missing, ref newTemplate);

            // Save the document
            object filename = filePath;

            SaveAs(filename.ToString(), WdSaveFormat.wdFormatTemplate);
        }

        /// <summary>
        /// Create a new document and activate it.
        /// </summary>
        public void Open()
        {
            _oDoc = CreateEmptyDocument();
        }

        /// <summary>
        /// Open a file (the file must exists) and activate it
        /// </summary>
        /// <param name="strFileName">Path to the file that is opened.</param>
        /// <param name="isTemplate">if <c>true</c> the file is a template.</param>
        /// <param name="makeVisible">if set to <c>true</c> [make visible].</param>
        /// <param name="resetProtection">if set to <c>true</c> [reset protection].</param>
        /// <param name="isCreatingFromTemplate"></param>
        /// <param name="isReadOnly"></param>
        /// <param name="documentId"></param>
        public void Open(
            string strFileName,
            bool isTemplate,
            bool makeVisible,
            bool resetProtection,
            bool isCreatingFromTemplate,
            bool isReadOnly,
            object documentId)
        {
            try
            {
                object filePath = strFileName;
                object addToRecentFiles = false;
                object newTemplate = false;
                object format = WdSaveFormat.wdFormatDocument;

                // Here is the way to handle parameters we don't care about
                object missing = System.Reflection.Missing.Value;

                System.Threading.Thread.Sleep(DBUtil.GetConfigInt(@"System\Dokumentemanagement\WartezeitVorOeffnen", 0));

                // will throw an exception, if document is password protected and user aborts
                if (isCreatingFromTemplate)
                {
                    // Wenn eine neues Dokument von einer Vorlage erzeugt wird, muss ADD verwendet werden,
                    // da sonst MS Office 2010 aufgrund neuer Sicherheitsprüfungen reklamiert
                    // und das Dokument nur im "protected mode" öffnet,
                    // was in KISS eine Fehlermeldung liefert.
                    _oDoc = _wordApplication.Documents.Add(ref filePath, ref newTemplate);
                }
                else
                {
                    // Wenn ein Dokument normal geöffnet werden soll
                    // http://msdn.microsoft.com/en-us/library/bb216319%28v=office.12%29.aspx

                    _logger.Debug("call wordApplication.Documents.Open");
                    _logger.DebugFormat("filePath = {0}", filePath);

                    _oDoc = _wordApplication.Documents.Open(
                        ref filePath, //FileName
                        ref missing,  //ConfirmConversions
                        ref missing,  //ReadOnly
                        ref addToRecentFiles,  //AddToRecentFiles
                        ref missing,  //PasswordDocument
                        ref missing,  //PasswordTemplate
                        ref missing,  //Revert
                        ref missing,  //WritePasswordDocument
                        ref missing,  //WritePasswordTemplate
                        ref missing   //Format
                    );

                    if (!isTemplate && _oDoc.Type == WdDocumentType.wdTypeTemplate && !isReadOnly)
                    {
                        SaveAs(filePath.ToString(), format);

                        XLog.Create(
                            CLASSNAME,
                            LogLevel.INFO,
                            "Vorlage zu Dokument korrrigiert",
                            string.Empty,
                            "XDocument",
                            DBUtil.IsEmpty(documentId) ? 0 : (int)documentId
                        );
                    }
                }

                // Unprotect Document if some Protection is active
                // - templates: to install AddIn
                // - documents: to replace bookmarks
                // to be reset after performing these actions
                _hasProtection = _oDoc.ProtectionType != WdProtectionType.wdNoProtection;
                bool protectionRemovalSuccess = false;

                if (_hasProtection && (isTemplate || !resetProtection))
                {
                    protectionRemovalSuccess = RemoveProtection();
                }

                if (isTemplate)
                {
                    Visible = false;

                    //still protected?
                    if (_oDoc.ProtectionType == WdProtectionType.wdNoProtection)
                    {
                        InstallKissTextmarkenAddIn();

                        // Show Bookmarks
                        _wordApplication.ActiveWindow.View.ShowBookmarks = true;
                    }
                }
                StoreCurrentView();

                if (resetProtection && isTemplate && protectionRemovalSuccess)
                {
                    ReactivateProtection();
                }

                if (makeVisible)
                {
                    Visible = true;
                    _oDoc.Activate();
                    WindowUtilities.SetWindowToForeground(_oDoc.Name);

                    // Run Macro in opened Word document
                    RunMacros();
                }
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
                throw;
            }
        }

        /// <summary>
        /// Quits this instance.
        /// </summary>
        public void Quit()
        {
            // Schliesse das Dokument, falls es noch offen ist
            CloseActiveDocument();

            // Dann schliesse Word (falls nötig) und verwerfe die COM-Objekte
            if (_wordApplication != null)
            {
                if (_wasStarted)
                {
                    // Die Word-Applikation wurde von KiSS gestartet, d.h. wir müssen es hier auch wieder beenden
                    try
                    {
                        object save = false;
                        object missing = System.Reflection.Missing.Value;
                        _wordApplication.Quit(ref save, ref missing, ref missing);
                    }
                    catch (Exception ex)
                    {
                        // Exception loggen und weitermachen
                        _logger.Warn("wordApplication.Quit() hat eine Exception ausgelöst.", ex);
                    }
                }

                ReleaseCOMObject(_wordApplication);
            }

            // Garbarge Collection
            try
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch
            {
                // Ignore it
            }
        }

        /// <summary>
        /// Reactivates the protection.
        /// </summary>
        public void ReactivateProtection()
        {
            object missing = System.Reflection.Missing.Value;
            object trueObj = true;

            if (_hasProtection)
            {
                IEnumerator enumerator = _oDoc.FormFields.GetEnumerator();

                // If there is a Formfield, this has to be selected to be sure that the
                // Cursor is at the right position ... otherwise an error is thrown
                if (enumerator.MoveNext())
                {
                    FormField firstField = (FormField)enumerator.Current;
                    firstField.Select();
                }

                try
                {
                    _oDoc.Protect(WdProtectionType.wdAllowOnlyFormFields, ref trueObj, ref missing);
                }
                catch (Exception ex)
                {
                    _logger.Warn(ex);

                    Visible = false;

                    if (!DisableMessageBox)
                    {
                        KissMsg.ShowInfo(
                            CLASSNAME,
                            "PasswortFalsch",
                            "Passwort für die Aufhebung des Dokumentschutzes nicht korrekt!\r\n\r\nBitte verwenden Sie ein leeres Passwort."
                        );
                    }
                }
            }
        }

        /// <summary>
        /// Removes the protection from the document if it's password is empty.
        /// </summary>
        public bool RemoveProtection()
        {
            try
            {
                object pw = "";
                _oDoc.Unprotect(ref pw);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);

                Visible = false;

                if (!DisableMessageBox)
                {
                    KissMsg.ShowInfo(
                        CLASSNAME,
                        "PasswortFalsch",
                        "Passwort für die Aufhebung des Dokumentschutzes nicht korrekt!\r\n\r\nBitte verwenden Sie ein leeres Passwort."
                    );
                }

                return false;
            }
        }

        /// <summary>
        /// Renames a bookmark in the document.
        /// </summary>
        /// <param name="oldName">The (old) name of the bookmark.</param>
        /// <param name="newName">The new name of the bookmark.</param>
        /// <param name="save">If <c>true</c>, the document is saved after renaming.</param>
        /// <returns>The final name of the bookmark after renaming.</returns>
        public string RenameBookmark(string oldName, string newName, bool save)
        {
            bool isProtected = _oDoc.ProtectionType != WdProtectionType.wdNoProtection;

            if (isProtected)
            {
                RemoveProtection();
            }

            // Loop through the bookmarks
            for (int i = 1; i <= _oDoc.Bookmarks.Count; i++)
            {
                object j = i;
                Bookmark b = _oDoc.Bookmarks.Item(ref j);

                if (b.Name == oldName || b.Name.StartsWith(oldName + "_"))
                {
                    Range range = b.Range;

                    // remove old bookmark
                    b.Delete();

                    // set text
                    range.Text = newName;

                    // get unique name
                    int num = 1;
                    for (int k = 1; k <= _oDoc.Bookmarks.Count; k++)
                    {
                        object l = k;
                        var name = _oDoc.Bookmarks.Item(ref l).Name;

                        if (name == newName || name.StartsWith(newName + "_"))
                        {
                            // a bookmark of the same name already exists
                            num++;
                        }
                    }

                    if (num > 1)
                    {
                        newName = string.Format("{0}_{1}", newName, num);
                    }

                    // add new bookmark with the old range
                    object r = range;
                    _oDoc.Bookmarks.Add(newName, ref r);
                }
            }

            if (isProtected)
            {
                ReactivateProtection();
            }

            if (save)
            {
                // finally, save the document
                _oDoc.Save();
            }

            return newName;
        }

        /// <summary>
        /// Replaces the bookmark by text.
        /// </summary>
        /// <param name="bookmark">The bookmark.</param>
        /// <param name="text">The text.</param>
        public void ReplaceBookmarkByText(string bookmark, string text)
        {
            object bookmarkName = bookmark;

            try
            {
                bool bookmarkRange = _oDoc.Bookmarks.Item(ref bookmarkName).Start !=
                                     _oDoc.Bookmarks.Item(ref bookmarkName).End;

                if (bookmarkRange)
                {
                    _oDoc.Bookmarks.Item(ref bookmarkName).Range.Text = text;
                }
                else
                {
                    GotoBookMark(bookmark);
                    _oDoc.Bookmarks.Item(ref bookmarkName).Delete();
                    _wordApplication.Selection.TypeText(text);
                }
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);

                DlgProgressLog.AddError(KissMsg.GetMLMessage(
                    CLASSNAME,
                    "TextmarkeNichtErstetzt",
                    "FEHLER: Textmarke '{0}' kann nicht mit '{1}' ersetzt werden!",
                    KissMsgCode.Text,
                    bookmarkName.ToString(),
                    text
                ));
            }
        }

        /// <summary>
        /// Resets to current view.
        /// </summary>
        public void ResetToCurrentView()
        {
            if (_wordApplication.ActiveWindow.View.Type != _currentView)
            {
                if (_wordApplication.ActiveWindow.View.SplitSpecial == WdSpecialPane.wdPaneNone)
                {
                    _wordApplication.ActiveWindow.ActivePane.View.Type = WdViewType.wdPrintPreview;
                }
                else
                {
                    _wordApplication.ActiveWindow.View.Type = WdViewType.wdPrintPreview;
                }

                _wordApplication.ActiveWindow.View.Type = _currentView;
            }
        }

        /// <summary>
        ///Save the document.
        /// </summary>
        public void Save()
        {
            _oDoc.Save();
        }

        /// <summary>
        /// Saves the Document.
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="saveFormat"></param>
        public void SaveAs(string filename, object saveFormat = null)
        {
            try
            {
                if (saveFormat == null)
                {
                    saveFormat = System.Reflection.Missing.Value;
                }
                object missing = System.Reflection.Missing.Value;
                object objFileName = filename;
                object addToRecentFiles = false;

                //see: http://msdn.microsoft.com/en-us/library/aa220734%28office.11%29.aspx

                _oDoc.SaveAs(
                    ref objFileName, //FileName
                    saveFormat,      //FileFormat
                    ref missing,     //LockComments
                    ref missing,     //Password
                    ref addToRecentFiles, //AddToRecentFiles
                    ref missing,     //WritePassword
                    ref missing,     //ReadOnlyRecommended
                    ref missing,     //EmbedTrueTypeFonts
                    ref missing,     //SaveNativePictureFormat
                    ref missing,     //SaveWormsData
                    ref missing      //SaveAsAOCLetter
                );
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }
        }

        /// <summary>
        /// Sets the alignment.
        /// </summary>
        /// <param name="strType">Type of the STR.</param>
        public void SetAlignment(WordParagraphAlignment strType)
        {
            switch (strType)
            {
                case WordParagraphAlignment.Center:
                    _wordApplication.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    break;

                case WordParagraphAlignment.Left:
                    _wordApplication.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    break;

                case WordParagraphAlignment.Right:
                    _wordApplication.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    break;

                case WordParagraphAlignment.Justify:
                    _wordApplication.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                    break;
            }
        }

        /// <summary>
        /// Sets the checkbox value.
        /// </summary>
        /// <param name="bookmark">The bookmark.</param>
        /// <param name="value">The value.</param>
        /// <param name="lovCode">The LOV code.</param>
        public void SetCheckboxValue(string bookmark, object value, string lovCode)
        {
            object bookmarkName = bookmark;

            try
            {
                FormField fld = _oDoc.FormFields.Item(ref bookmarkName);
                if (fld.Type == WdFieldType.wdFieldFormCheckBox)
                {
                    if (lovCode == null)
                    {
                        if (DBUtil.IsEmpty(value) || !(value is Boolean))
                        {
                            fld.CheckBox.Value = false;
                        }
                        else
                        {
                            fld.CheckBox.Value = (bool)value;
                        }
                    }
                    else
                    {
                        if (DBUtil.IsEmpty(value) || !(value is string))
                        {
                            fld.CheckBox.Value = false;
                        }
                        else
                        {
                            string codeList = "," + (string)value + ",";
                            fld.CheckBox.Value = codeList.IndexOf("," + lovCode + ",") != -1;
                        }
                    }

                    _oDoc.Bookmarks.Item(ref bookmarkName).Delete();
                }
                else
                {
                    // no checkbox, set "x" or "" instead
                    if (DBUtil.IsEmpty(value) || !(value is Boolean) || !(bool)value)
                    {
                        ReplaceBookmarkByText(bookmark, "");
                    }
                    else
                    {
                        ReplaceBookmarkByText(bookmark, "x");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);

                DlgProgressLog.AddError(KissMsg.GetMLMessage(
                    CLASSNAME,
                    "CheckboxNichtGesetzt",
                    "FEHLER: Die Checkbox mit der Textmarke '{0}' kann nicht gesetzt werden werden!",
                    KissMsgCode.Text,
                    bookmarkName.ToString()
                ));
            }
        }

        /// <summary>
        /// Sets the font.
        /// </summary>
        /// <param name="strType">Type of the STR.</param>
        public void SetFont(WordFontStyle strType)
        {
            switch (strType)
            {
                case WordFontStyle.Bold:
                    _wordApplication.Selection.Font.Bold = 1;
                    break;

                case WordFontStyle.Italic:
                    _wordApplication.Selection.Font.Italic = 1;
                    break;

                case WordFontStyle.Underlined:
                    _wordApplication.Selection.Font.Subscript = 0;
                    break;
            }
        }

        /// <summary>
        /// Sets the font.
        /// </summary>
        public void SetFont()
        {
            _wordApplication.Selection.Font.Bold = 0;
            _wordApplication.Selection.Font.Italic = 0;
            _wordApplication.Selection.Font.Subscript = 0;
        }

        /// <summary>
        /// Sets the name of the font.
        /// </summary>
        /// <param name="strType">Type of the STR.</param>
        public void SetFontName(string strType)
        {
            _wordApplication.Selection.Font.Name = strType;
        }

        /// <summary>
        /// Sets the size of the font.
        /// </summary>
        /// <param name="nSize">Size of the n.</param>
        public void SetFontSize(int nSize)
        {
            _wordApplication.Selection.Font.Size = nSize;
        }

        /// <summary>
        /// Sets the style for the current selection.
        /// </summary>
        /// <param name="styleName">Name of the style.</param>
        public void SetStyle(string styleName)
        {
            if (DBUtil.IsEmpty(styleName))
            {
                return;
            }

            try
            {
                object sn = styleName;
                object style = _oDoc.Styles.Item(ref sn);
                _wordApplication.Selection.Start = _wordApplication.Selection.End;
                _wordApplication.Selection.set_Style(ref style);
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }
        }

        /// <summary>
        /// Shows the bookmarks.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public void ShowBookmarks(bool value)
        {
            _wordApplication.ActiveWindow.View.ShowBookmarks = value;
        }

        #endregion Public Methods

        #region Private Static Methods

        /// <summary>
        /// Gets an existing instance of MS Word or creates a new one.
        /// </summary>
        /// <param name="wasStarted">Indicates whether MS word was started</param>
        /// <returns></returns>
        private static Word.Application GetWordInstance(out Boolean wasStarted)
        {
            Word.Application word;

            // try to reference existing word instance
            object wordObject = TryGetExistingInstance();

            if (wordObject == null)
            {
                word = new ApplicationClass();
                wasStarted = true;
            }
            else
            {
                word = (Word.Application)wordObject;
                wasStarted = false;
            }

            return word;
        }

        /// <summary>
        /// Tries to get an existing existing instance.
        /// </summary>
        /// <returns>null if instance does not exist. Instance otherwise</returns>
        private static object TryGetExistingInstance()
        {
            object wordObject;

            try
            {
                wordObject = Marshal.GetActiveObject("Word.Application");
            }
            catch (Exception ex)
            {
                // logging
                _logger.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", "KiSS4.Dokument.WordAutomation.WordControl", ex.Message);

                wordObject = null;
            }

            return wordObject;
        }

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Creates an empty word document.
        /// </summary>
        /// <returns></returns>
        private Document CreateEmptyDocument()
        {
            Document emptyDocument = _wordApplication.Documents.Add();

            emptyDocument.Activate();
            return emptyDocument;
        }

        /// <summary>
        /// Installs the KiSS textmarken add-in.
        /// </summary>
        private void InstallKissTextmarkenAddIn()
        {
            // try to delete/add variable value.
            object connectionStringParamName = PARAM_CONNECTION_STRING;
            object connectionStringParam = FileUtilies.OLEDBConnectionString;

            object languageCodeParamName = PARAM_LANGUAGE_CODE;
            object languageCodeParam = Session.User.LanguageCode;

            object paramTextFrmTitleObject = PARAM_TEXTFRMTITLE;
            object propertyValueTextFrmTitle = KissMsg.GetMLMessage("FrmTextmarkenTemplate", "TextFrmTitle", string.Empty);

            object paramTextBtnAddObject = PARAM_TEXTBTNADD;
            object propertyValueTextBtnAdd = KissMsg.GetMLMessage("FrmTextmarkenTemplate", "TextBtnAdd", string.Empty);

            object paramTextBrnCloseObject = PARAM_TEXTBTNCLOSE;
            object propertyValueTextBtnClose = KissMsg.GetMLMessage("FrmTextmarkenTemplate", "TextBtnClose", string.Empty);

            try
            {
                _oDoc.Variables.Item(ref connectionStringParamName).Delete();
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }

            try
            {
                _oDoc.Variables.Item(ref languageCodeParamName).Delete();
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }

            try
            {
                _oDoc.Variables.Item(ref paramTextFrmTitleObject).Delete();
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }

            try
            {
                _oDoc.Variables.Item(ref paramTextBtnAddObject).Delete();
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }

            try
            {
                _oDoc.Variables.Item(ref paramTextBrnCloseObject).Delete();
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }

            try
            {
                _oDoc.Variables.Add(PARAM_CONNECTION_STRING, ref connectionStringParam);
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }

            try
            {
                _oDoc.Variables.Add(PARAM_LANGUAGE_CODE, ref languageCodeParam);
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }

            try
            {
                _oDoc.Variables.Add(PARAM_TEXTFRMTITLE, ref propertyValueTextFrmTitle);
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }

            try
            {
                _oDoc.Variables.Add(PARAM_TEXTBTNADD, ref propertyValueTextBtnAdd);
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }

            try
            {
                _oDoc.Variables.Add(PARAM_TEXTBTNCLOSE, ref propertyValueTextBtnClose);
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }

            // Remove AddIn KissTextmarkenAddIn if already installed
            foreach (Word.AddIn a in _wordApplication.AddIns)
            {
                try
                {
                    if (a.Name != null && a.Name.ToUpper().StartsWith("KISSTEXTMARKENADDIN"))
                    {
                        a.Delete();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Warn(ex);
                }
            }

            try
            {
                var workingCopy = OfficeUtils.CreateAddinWorkingCopy(
                    _wordApplication.Version,
                    false,
                    ADDIN_FILE_NAME_OFFICE2010ANDBEFORE,
                    ADDIN_EXTENSION_OFFICE2010ANDBEFORE,
                    ADDIN_FILE_NAME_OFFICE2013,
                    ADDIN_EXTENSION_OFFICE2013);

                // Add and install the addin
                _logger.Debug("Add addin");
                object installAddIn = true;
                var addIn = _wordApplication.AddIns.Add(workingCopy, ref installAddIn);
                addIn.Installed = true;
                _logger.Debug("addIn.Installed=" + addIn.Installed.ToString() + ". addIn.Name=" + addIn.Name);
                _wordApplication.Run("KissTextmarken.MakeMenu");
            }
            catch (Exception ex)
            {
                Visible = false;
                if (!DisableMessageBox)
                {
                    KissMsg.ShowError(
                        CLASSNAME,
                        "FehlerInstallationTextmarke",
                        "Fehler bei der Installation des KissTextmarken-AddIn",
                        ex
                    );
                }
            }
        }

        private void ReleaseCOMObject(object comObject)
        {
            try
            {
                Marshal.FinalReleaseComObject(comObject);
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }
        }

        /// <summary>
        /// Runs word macros.
        /// </summary>
        private void RunMacros()
        {
            try
            {
                _wordApplication.Run("AutoExec.Main");
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }

            try
            {
                string macro = DBUtil.GetConfigString(@"System\Office\Word_AutoExec.Main", string.Empty);

                if (!string.IsNullOrEmpty(macro))
                {
                    _wordApplication.Run(macro);
                }
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }
        }

        /// <summary>
        /// Stores the current view.
        /// </summary>
        private void StoreCurrentView()
        {
            _currentView = _wordApplication.ActiveWindow.View.Type;
        }

        #endregion Private Methods

        #endregion Methods
    }
}