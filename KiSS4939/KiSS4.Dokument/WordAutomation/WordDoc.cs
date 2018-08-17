using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Dokument.Utilities;
using KiSS4.Messages;
using log4net;

namespace KiSS4.Dokument.WordAutomation
{
    /// <summary>
    /// Represents a word document opened in word.
    /// </summary>
    public class WordDoc : IDisposable
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(
            MethodBase.GetCurrentMethod().DeclaringType
            );

        private static String PostParameterPrefix = "PP";

        #endregion

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// Stores the file information for the MS Word Ddocument.
        /// </summary>
        private readonly FileInfo _docFileInfo;

        private readonly Boolean _isTemporary;
        private readonly WordControl _wordControl;

        #endregion

        #region Private Fields

        private Boolean _disposed;
        private DataTable _wordBookmarks;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WordDoc"/> class.
        /// No textmarks are replaced.
        /// </summary>
        /// <param name="aDocFileInfo">Document information.</param>
        /// <param name="context">The context.</param>
        /// <remarks>Word doc based on a file system stored document or template. The doc is opened in word. </remarks>
        public WordDoc(FileInfo aDocFileInfo, IKissContext context)
        {
            _isTemporary = false;
            _docFileInfo = aDocFileInfo;
            _wordControl = new WordControl();
            InitializeDocument(
                context,
                false,
                // fillPostBookmarks
                false,
                // isCreatingFromTemplate
                true,
                // isReadOnly
                null,
                // documentID
                string.Empty,
                // newFileName
                false // doSave
                );
        }

        /// <summary>
        /// Create new Word doc based on a given Word template. 
        /// Bookmarks are replaced by context sensitive values.
        /// </summary>
        /// <param name="aDocFileInfo">The doc file info.</param>
        /// <param name="context">The context.</param>
        /// <param name="isCreatingFromTemplate">TRUE, if a new document is being created from a template.</param>
        /// <param name="isReadOnly">TRUE, if the document can only opened in read only mode.</param>
        /// <param name="documentId">The ID of a document or a template.</param>
        /// <param name="newFileName">The new file name, when a document is created from an template.</param>
        public WordDoc(
            FileInfo aDocFileInfo,
            IKissContext context,
            bool isCreatingFromTemplate,
            bool isReadOnly,
            object documentId,
            string newFileName
            )
        {
            _isTemporary = true;
            _docFileInfo = aDocFileInfo;
            _wordControl = new WordControl();
            InitializeDocument(
                context,
                true,
                // fillPostBookmarks
                isCreatingFromTemplate,
                isReadOnly,
                documentId,
                newFileName,
                true // doSave
                );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordDoc"/> class.
        /// </summary>
        /// <param name="aDocFileInfo">The doc file info.</param>
        /// <param name="context">The context.</param>
        /// <param name="fillAllTextmarks">if set to <c>true</c> [replace all textmarks].</param>
        /// <param name="isCreatingFromTemplate">TRUE, if a new document is being created from a template.</param>
        /// <param name="isReadOnly">TRUE, if the document can only opened in read only mode.</param>
        /// <param name="documentId">The ID of a document or a template.</param>
        /// <param name="newFileName">The new file name, when a document is created from an template.</param>
        public WordDoc(
            FileInfo aDocFileInfo,
            IKissContext context,
            bool fillAllTextmarks,
            bool isCreatingFromTemplate,
            bool isReadOnly,
            object documentId,
            string newFileName
            )
        {
            _isTemporary = true;
            _docFileInfo = aDocFileInfo;
            _wordControl = new WordControl();
            InitializeDocument(
                context,
                fillAllTextmarks,
                isCreatingFromTemplate,
                isReadOnly,
                documentId,
                newFileName,
                true // doSave
                );
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="WordDoc"/> is reclaimed by garbage collection.
        /// </summary>
        ~WordDoc()
        {
            Dispose(false);
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            try
            {
                if (disposing)
                {
                    // Dispose Managed and unmanaged Resources
                    _wordControl.Quit();
                }
                if (_isTemporary)
                {
                    _docFileInfo.Delete();
                }
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }
            finally
            {
                _disposed = true;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the doc file info.
        /// </summary>
        /// <value>The doc file info.</value>
        public FileInfo DocFileInfo
        {
            get { return _docFileInfo; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Closes the document.
        /// </summary>
        public void CloseDocument()
        {
            if (_wordControl != null)
            {
                _wordControl.CloseActiveDocument();
            }
        }

        /// <summary>
        /// Makes the word visible.
        /// </summary>
        public void MakeWordVisible()
        {
            if (_wordControl != null)
            {
                _wordControl.Visible = true;

                // check if really visible now
                if (_wordControl.Visible)
                {
                    // show word-doc
                    WindowUtilities.SetWindowToForeground(_docFileInfo.Name);
                }
            }
        }

        /// <summary>
        /// Quit Microsoft Word.
        /// </summary>
        public void QuitWord()
        {
            if (_wordControl != null)
            {
                _wordControl.Quit();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the dyna bookmark value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="fieldCode">The field code.</param>
        /// <param name="baseBookmarkName">Name of the base bookmark.</param>
        /// <param name="origBookmarkName">Name of the orig bookmark.</param>
        /// <param name="lovListAsText">if set to <c>true</c> [LOV list as text].</param>
        /// <returns></returns>
        private object GetDynaBookmarkValue(
            IKissContext context,
            int fieldCode,
            string baseBookmarkName,
            string origBookmarkName,
            bool lovListAsText
            )
        {
            object faPhaseId = context.GetContextValue("FaPhaseID");
            object faLeistungId = null;

            if (DBUtil.IsEmpty(faPhaseId))
            {
                faLeistungId = context.GetContextValue("FaLeistungID");
            }

            object gridRowId = context.GetContextValue("GridRowID");

            if (DBUtil.IsEmpty(faPhaseId) && DBUtil.IsEmpty(faLeistungId))
            {
                DlgProgressLog.AddError(
                    KissMsg.GetMLMessage(
                        "WordDoc",
                        "KontextWertFaLeistungIDNichtGefunden",
                        "FEHLER: Textmarke '{0}' - Kontextwert 'FaLeistungID/FaPhaseID' nicht gefunden",
                        KissMsgCode.Text,
                        origBookmarkName
                        ));

                // Füge nochmals eine Linie ein, da sonst der Fehler überschrieben würde
                DlgProgressLog.AddLine("");

                return DBNull.Value;
            }

            if (DBUtil.IsEmpty(gridRowId))
            {
                DlgProgressLog.AddError(
                    KissMsg.GetMLMessage(
                        "WordDoc",
                        "KontextWertGridRowIDNichtGefunden",
                        "FEHLER: Textmarke '{0}' - Kontextwert 'GridRowID' nicht gefunden",
                        KissMsgCode.Text,
                        origBookmarkName
                        ));

                // Füge nochmals eine Linie ein, da sonst der Fehler überschrieben würde
                DlgProgressLog.AddLine("");

                return DBNull.Value;
            }

            string sql = @"SELECT '' WHERE {0} = {0}";

            switch (fieldCode)
            {
                case 2: // Text
                case 3: // Memo
                    sql =
                        @"
                        SELECT VAL.Value
                        FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                          INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                        WHERE FLD.FieldName = {0}";
                    break;

                case 4: // Zahl
                    sql =
                        @"
                        SELECT CONVERT(VARCHAR, VAL.Value)
                        FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                          INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                        WHERE FLD.FieldName = {0}";
                    break;

                case 5: // Datum
                    sql =
                        @"
                        SELECT CONVERT(VARCHAR, VAL.Value, 104)
                        FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                          INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                        WHERE FLD.FieldName = {0}";
                    break;

                case 6: // Zeit
                    sql =
                        @"
                        SELECT CONVERT(VARCHAR, VAL.Value, 108)
                        FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                          INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                        WHERE FLD.FieldName = {0}";
                    break;

                case 7: // Checkbox
                    sql =
                        @"
                        SELECT CONVERT(BIT, VAL.Value)
                        FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                          INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                        WHERE FLD.FieldName = {0}";
                    break;

                case 8: // Auswahl
                    sql =
                        @"
                        SELECT LOV.Text
                        FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                          INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                          LEFT  JOIN dbo.XLOVCode  LOV WITH (READUNCOMMITTED) ON LOV.LOVName = FLD.LOVName AND
                                                                                 LOV.Code = VAL.Value
                        WHERE FLD.FieldName = {0}";
                    break;

                case 9: // Mehrfachauswahl
                    if (lovListAsText)
                    {
                        sql =
                            @"
                            SELECT dbo.fnLOVTextListe(FLD.LOVName, CONVERT(VARCHAR, VAL.Value))
                            FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                              INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                            WHERE FLD.FieldName = {0}";
                    }
                    else
                    {
                        sql =
                            @"
                            SELECT VAL.Value
                            FROM DynaField FLD
                              INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                            WHERE FLD.FieldName = {0}";
                    }
                    break;

                case 12: // Dokument
                    DlgProgressLog.AddError(
                        KissMsg.GetMLMessage(
                            "WordDoc",
                            "TextmarkeTypDokumentVorhanden",
                            "FEHLER: Textmarke '{0}' - Textmarke vom Typ 'Dokument' darf nicht verwendet werden",
                            KissMsgCode.Text,
                            origBookmarkName
                            ));

                    // Füge nochmals eine Linie ein, da sonst der Fehler überschrieben würde
                    DlgProgressLog.AddLine("");

                    return DBNull.Value;

                case 13: // WordBericht
                    DlgProgressLog.AddError(
                        KissMsg.GetMLMessage(
                            "WordDoc",
                            "TextmarkeTypWordBerichtVorhanden",
                            "FEHLER: Textmarke '{0}' - Textmarke vom Typ 'WordBericht' darf nicht verwendet werden",
                            KissMsgCode.Text,
                            origBookmarkName
                            ));

                    // Füge nochmals eine Linie ein, da sonst der Fehler überschrieben würde
                    DlgProgressLog.AddLine("");

                    return DBNull.Value;

                case 14: // Auswahl mit Dialog
                    SqlQuery qry;

                    if (!DBUtil.IsEmpty(faPhaseId))
                    {
                        qry =
                            DBUtil.OpenSQL(
                                @"
                            SELECT VAL.Value, FLD.SQL
                            FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                              INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                            WHERE FLD.FieldName = {0} AND
                                  VAL.FaPhaseID = {1} AND
                                  GridRowID = {2}",
                                baseBookmarkName,
                                faPhaseId,
                                gridRowId
                                );
                    }
                    else
                    {
                        qry =
                            DBUtil.OpenSQL(
                                @"
                            SELECT VAL.Value, FLD.SQL
                            FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                              INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                            WHERE FLD.FieldName = {0} AND
                                  VAL.FaLeistungID = {1} AND
                                  GridRowID = {2}",
                                baseBookmarkName,
                                faLeistungId,
                                gridRowId
                                );
                    }

                    if (qry.Count > 0)
                    {
                        sql = qry["SQL"].ToString();
                        int pos = sql.IndexOf("----");

                        if (pos >= 0)
                        {
                            return DBUtil.ExecuteScalarSQL(sql.Substring(pos + 4), qry["Value"]);
                        }
                    }

                    return DBNull.Value;

                case 15: // RTF
                    sql =
                        @"
                        SELECT VAL.ValueText
                        FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                          INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                        WHERE FLD.FieldName = {0}";
                    break;

                case 16: // Temp Fixtext from IKissContext
                    try
                    {
                        Object value = context.GetContextValue(origBookmarkName);
                        if (value != null)
                        {
                            return value;
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Warn(ex);
                    }

                    return string.Empty;
            }

            if (!DBUtil.IsEmpty(faPhaseId))
            {
                sql += " AND VAL.FaPhaseID = {1} AND GridRowID = {2}";
                return DBUtil.ExecuteScalarSQL(sql, baseBookmarkName, faPhaseId, gridRowId);
            }

            sql += " AND VAL.FaLeistungID = {1} AND GridRowID = {2}";
            return DBUtil.ExecuteScalarSQL(sql, baseBookmarkName, faLeistungId, gridRowId);
        }

        /// <summary>
        /// Initializes the document.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="fillPostTextMarks">if <c>true</c> postponed textmarks will be replaced.</param>
        /// <param name="isCreatingFromTemplate">TRUE, if a new document is being created from a template.</param>
        /// <param name="isReadOnly">TRUE, if the document can only opened in read only mode.</param>
        /// <param name="documentId">The ID of a document or a template.</param>
        /// <param name="newFileName">The new file name, when a document is created from an template.</param>
        /// <param name="doSave">TRUE, when the document should be saved</param>
        private void InitializeDocument(
            IKissContext context,
            bool fillPostTextMarks,
            bool isCreatingFromTemplate,
            bool isReadOnly,
            object documentId,
            string newFileName,
            bool doSave
            )
        {
            DlgProgressLog.AddLine(KissMsg.GetMLMessage("WordDoc", "WordAktivieren", "Word aktivieren"));

            try
            {
                DlgProgressLog.AddLine(KissMsg.GetMLMessage("WordDoc", "VorlageOeffnen", "Vorlage öffnen"));

                _wordControl.Open(
                    _docFileInfo.FullName,
                    false,
                    // isTemplate
                    false,
                    // makeVisible
                    false,
                    // resetProtection
                    isCreatingFromTemplate,
                    isReadOnly,
                    documentId);

                DlgProgressLog.AddLine(
                    KissMsg.GetMLMessage(
                        "WordDoc",
                        "TextmarkenAusVorlage",
                        "Textmarken aus der Vorlage lesen"));

                // Get All TextMarks from word document
                _wordBookmarks = _wordControl.GetBookmarkList();

                // read according Kiss bookmark definitions
                string bookmarkList = string.Empty;

                foreach (DataRow row in _wordBookmarks.Rows)
                {
                    bookmarkList += string.Format(", '{0}'", row["BaseBookmark"]);
                }

                if (!string.IsNullOrEmpty(bookmarkList))
                {
                    bookmarkList = bookmarkList.Substring(2);
                }

                if (!string.IsNullOrEmpty(bookmarkList))
                {
                    // create default sql
                    String sql =
                        String.Format(
                            @"
                        SELECT CONVERT(BIT, 1) IsStd,
                               BookmarkName = LEFT(BookmarkName, 40),
                               BookmarkCode,
                               SQL
                        FROM dbo.XBookmark WITH (READUNCOMMITTED)
                        WHERE BookmarkName IN ({0}) AND
                              TableName IS NULL

                        UNION ALL

                        SELECT CONVERT(BIT, 1) IsStd,
                               BookmarkName = LEFT(SBO.BookmarkName, 40),
                               SBO.BookmarkCode,
                               REPLACE(CONVERT(VARCHAR(8000), SBO.SQL), '<TableColumn>', SBO.ReplaceCode)
                        FROM dbo.fnGetStandardBookmarks({1}) SBO",
                            bookmarkList,
                            Session.User.LanguageCode);

                    // check if we have the table DynaField
                    if (Session.SupportDynaMask)
                    {
                        // add bookmarks from DynaField
                        sql =
                            String.Format(
                                @"
                        {0}

                        UNION ALL

                        SELECT CONVERT(BIT, 0) IsStd,
                               BookmarkName = LEFT(FieldName, 40),
                               FieldCode,
                               NULL
                        FROM dbo.DynaField WITH (READUNCOMMITTED)
                        WHERE FieldName IN ({1})",
                                sql,
                                bookmarkList);
                    }

                    SqlQuery qryXBookmark = DBUtil.OpenSQL(sql);

                    DlgProgressLog.AddLine(
                        KissMsg.GetMLMessage(
                            "WordDoc",
                            "TextmarkenErsetzen1",
                            "Textmarken mit Daten füllen: 0 von ",
                            _wordBookmarks.Rows.Count.ToString()
                            ));

                    // resolve each bookmark
                    // TODO: optimization

                    DataTable tbl = _wordControl.GetBookmarkList();
                    int count = 0;

                    foreach (DataRow row in _wordBookmarks.Rows)
                    {
                        string origBookmarkName = row["OriginalBookmark"].ToString();
                        string baseBookmarkName = row["BaseBookmark"].ToString();

                        count++;
                        DlgProgressLog.UpdateLastLine(
                            KissMsg.GetMLMessage(
                                "WordDoc",
                                "TextmarkenErsetzen2",
                                "Textmarken mit Daten füllen: {0} von {1}",
                                count.ToString(),
                                _wordBookmarks.Rows.Count.ToString()
                                ));

                        // check if we need to handle this bookmark (if a bookmark starts with "NOKISS", we do nothing with it)
                        if (baseBookmarkName.ToUpper().StartsWith("NOKISS"))
                        {
                            // nokiss bookmark, go on with next
                            continue;
                        }

                        if (baseBookmarkName.ToUpper().StartsWith(PostParameterPrefix))
                        {
                            if (fillPostTextMarks)
                            {
                                //System.Diagnostics.Debug.WriteLine(baseBookmarkName + " will be replaced!");
                            }
                            else
                            {
                                continue;
                            }
                        }

                        DataRow bookmarkRow;

                        if (qryXBookmark.Find(string.Format("BookmarkName = '{0}'", baseBookmarkName)))
                        {
                            bookmarkRow = qryXBookmark.Row;
                        }
                        else
                        {
                            DlgProgressLog.AddError(
                                KissMsg.GetMLMessage(
                                    "WordDoc",
                                    "TextmarkeNichtGefunden",
                                    "FEHLER: Textmarke '{0}' nicht im KiSS-Katalog gefunden",
                                    KissMsgCode.Text,
                                    baseBookmarkName
                                    ));

                            // Füge nochmals eine Linie ein, da sonst der Fehler überschrieben würde
                            DlgProgressLog.AddLine("");

                            ReplaceBookmarkByValue(origBookmarkName, "", 0, 0, "");
                            continue;
                        }

                        // get LOVCode at the end the bookmark if any
                        string lovCode = null;
                        int idx = origBookmarkName.IndexOf("_C");
                        if (idx != -1)
                        {
                            lovCode = origBookmarkName.Substring(idx + 2);
                            try
                            {
                                int i = Convert.ToInt32(lovCode);
                            }
                            catch (Exception ex)
                            {
                                _logger.Warn(ex);

                                DlgProgressLog.AddError(
                                    KissMsg.GetMLMessage(
                                        "WordDoc",
                                        "CodeNichtNumerisch",
                                        "FEHLER: Textmarke '{0}': Code am Schluss ist nicht numerisch",
                                        KissMsgCode.Text,
                                        origBookmarkName
                                        ));

                                // Füge nochmals eine Linie ein, da sonst der Fehler überschrieben würde
                                DlgProgressLog.AddLine("");

                                continue;
                            }
                        }

                        if ((bool)bookmarkRow["IsStd"])
                        {
                            // standard bookmark found: replace all Context Parameters in SQL and retrieve value
                            SqlQuery qryBookmarkValues = new SqlQuery();
                            string bookmarkSql = bookmarkRow["SQL"].ToString();
                            if (ReplaceContextParameter(ref bookmarkSql, context, baseBookmarkName))
                            {
                                qryBookmarkValues.Fill(bookmarkSql);
                            }

                            int bookmarkCode = (int)bookmarkRow["BookmarkCode"];
                            if (qryBookmarkValues.Count == 0)
                            {
                                ReplaceBookmarkByValue(origBookmarkName, "", bookmarkCode, 0, "");
                            }
                            else if (qryBookmarkValues.Count == 1 && qryBookmarkValues.DataTable.Columns.Count == 1)
                            {
                                object value = qryBookmarkValues.DataTable.Rows[0][0];

                                if (qryBookmarkValues.DataTable.Columns[0].DataType == typeof(bool))
                                {
                                    _wordControl.SetCheckboxValue(origBookmarkName, value, null);
                                }
                                else if (lovCode != null) //Mehrfachauswahl
                                {
                                    _wordControl.SetCheckboxValue(origBookmarkName, value, lovCode);
                                }
                                else
                                {
                                    ReplaceBookmarkByValue(
                                        origBookmarkName,
                                        value,
                                        bookmarkCode,
                                        0,
                                        qryBookmarkValues.DataTable.Columns[0].ColumnName
                                        );
                                }
                            }
                            else
                            {
                                string progressText = KissMsg.GetMLMessage(
                                    "WordDoc",
                                    "TextmarkenErsetzen3",
                                    "Fülle Tabelle: Zeile {3} von {2}",
                                    count.ToString(),
                                    _wordBookmarks.Rows.Count.ToString(),
                                    qryBookmarkValues.DataTable.Rows.Count.ToString(),
                                    "{0}"
                                    );
                                ReplaceBookmarkByValues(origBookmarkName, qryBookmarkValues, progressText);
                            }
                        }
                        else
                        {
                            // Dyna bookmark found:
                            // get Context Parameters FaPhaseID and FaFallID and retrieve DynaValue
                            int fieldCode = (int)bookmarkRow["BookmarkCode"];
                            object bookmarkValue = GetDynaBookmarkValue(
                                context,
                                fieldCode,
                                baseBookmarkName,
                                origBookmarkName,
                                lovCode == null
                                );

                            if (fieldCode == 7)
                            {
                                // Checkbox
                                _wordControl.SetCheckboxValue(origBookmarkName, bookmarkValue, null);
                            }
                            else if (fieldCode == 9 && lovCode != null)
                            {
                                // Mehrfachauswahl
                                _wordControl.SetCheckboxValue(origBookmarkName, bookmarkValue, lovCode);
                            }
                            else
                            {
                                ReplaceBookmarkByValue(origBookmarkName, bookmarkValue, 0, fieldCode, "");
                            }
                        }
                    }
                }

                _wordControl.ShowBookmarks(false);
                _wordControl.GoToTheBeginning();
                _wordControl.GoToNextField();
                _wordControl.ReactivateProtection();

                DlgProgressLog.AddLine(
                    KissMsg.GetMLMessage(
                        "WordDoc",
                        "VorlageSpeichern",
                        "ausgefüllte Vorlage speichern"
                        ));
                _wordControl.ResetToCurrentView();

                if (isCreatingFromTemplate)
                {
                    // wenn das Dokument aus einer Vorlage erstellt wurde,
                    // soll es unter einem neuen Namen als Typ Dokument gespeichert werden
                    _wordControl.SaveAs(newFileName);
                }
                else
                {
                    // normales Speichern, wenn der Typ des Dokuments nicht geändert werden soll
                    // wenn eine Vorlage zum Erstellen eines Dokuments geöffnet werden soll,
                    // muss die geöffnete Vorlage nicht zusätzlich gespeichert werden
                    if (doSave)
                    {
                        _wordControl.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
                _wordControl.Quit();
                throw;
            }
        }

        /// <summary>
        /// Replaces the bookmark by value.
        /// </summary>
        /// <param name="bookmarkName">Name of the bookmark.</param>
        /// <param name="bookmarkValue">The bookmark value.</param>
        /// <param name="bookmarkCode">The bookmark code.</param>
        /// <param name="fieldCode">The field code.</param>
        /// <param name="columnName">Name of the column.</param>
        private void ReplaceBookmarkByValue(
            string bookmarkName,
            object bookmarkValue,
            int bookmarkCode,
            int fieldCode,
            string columnName
            )
        {
            // set value to String.Empty if no value is available.
            if (DBUtil.IsEmpty(bookmarkValue))
            {
                bookmarkValue = "";
            }

            // replace bookmark by BookmarkValue
            if (columnName.ToUpper().EndsWith("NORTF") || columnName.ToUpper().EndsWith("OHNEFMT"))
            {
                // remove formatting and pass as plain text
                string text = FileUtilies.RemoveRTFFormatting(bookmarkValue.ToString());
                _wordControl.ReplaceBookmarkByText(bookmarkName, text);
            }
            else if (bookmarkCode == 3 || fieldCode == 15 || columnName.ToUpper().EndsWith("MITFMT") || columnName.ToUpper().EndsWith("RTF")) //3:Standard RTF , 15: Dyna RTF
            {
                // must be passed in a DataObject to get correct RTF format
                string bookmarkValueString = bookmarkValue.ToString();
                if (string.IsNullOrEmpty(bookmarkValueString))
                {
                    //insert as plain text, as word inserts '_' instead of an empty string
                    _wordControl.ReplaceBookmarkByText(bookmarkName, bookmarkValueString);
                }
                else
                {
                    DataObject myDataObject = new DataObject(DataFormats.Rtf, bookmarkValueString);
                    Clipboard.SetDataObject(myDataObject);
                    try
                    {
                    _wordControl.InsertRTF(bookmarkName);
                }
                    catch (Exception exp)
                    {
                        DlgProgressLog.AddError(KissMsg.GetMLMessage("WordDoc", "FehlerRTF_V2", "RTF Textmarke kann nicht verarbeitet werden. Es wird stattdessen unformatierter Text eingefügt. (Textmarke: {0}, Fehler: {1})", bookmarkName, exp.Message));

                        // Füge nochmals eine Linie ein, da sonst der Fehler überschrieben würde
                        DlgProgressLog.AddLine("");

                        // remove formatting and pass as plain text
                        string text = FileUtilies.RemoveRTFFormatting(bookmarkValueString);
                        _wordControl.InsertText(text);
                    }
                }
            }
            else
            {
                string text;

                if (bookmarkValue is DateTime)
                {
                    text = ((DateTime)bookmarkValue).ToShortDateString();
                }
                else if (bookmarkValue is decimal)
                {
                    text = string.Format("{0:n2}", bookmarkValue);
                }
                else
                {
                    text = bookmarkValue.ToString();
                }

                _wordControl.ReplaceBookmarkByText(bookmarkName, text);
            }
        }

        /// <summary>
        /// Replaces the bookmark by values.
        /// </summary>
        /// <param name="bookmarkName">Name of the bookmark.</param>
        /// <param name="qryValues">The qry values.</param>
        /// <param name="progressTextWithCountVar">Progess Text with countVar</param>
        private void ReplaceBookmarkByValues(String bookmarkName, SqlQuery qryValues, string progressTextWithCountVar)
        {
            if (qryValues.Count == 0)
            {
                return;
            }

            _wordControl.DeleteBookmarkAndText(bookmarkName);

            for (int i = 0; i < qryValues.DataTable.Rows.Count; i++)
            {
                DlgProgressLog.UpdateLastLine(string.Format(progressTextWithCountVar, i + 1));

                DataRow row = qryValues.DataTable.Rows[i];
                for (int k = 0; k < qryValues.DataTable.Columns.Count; k++)
                {
                    DataColumn col = qryValues.DataTable.Columns[k];
                    string colName = col.ColumnName.ToUpper();
                    bool lastRowLastCol = (i == qryValues.DataTable.Rows.Count - 1 && k == qryValues.DataTable.Columns.Count - 1);

                    //insert Text, RTF or Special command depending on Column Name
                    if (colName.StartsWith("NEWPARA"))
                    {
                        _wordControl.NewParagraph();
                    }
                    else if (colName.StartsWith("STYLE"))
                    {
                        _wordControl.SetStyle(row[col].ToString());
                    }
                    else if (colName.StartsWith("DELNEXTFIELD"))
                    {
                        _wordControl.DeleteNextExtended();
                    }
                    else if (colName.StartsWith("NEXTCELL") && !lastRowLastCol)
                    {
                        _wordControl.GoToRightCell(false);
                    }
                    else if (colName.StartsWith("NEWROW"))
                    {
                        _wordControl.InsertRow(1); //is not yet functioning!
                    }
                    else if (colName.EndsWith("NORTF") || colName.EndsWith("RTFOHNEFMT"))
                    {
                        // remove formatting and pass as plain text
                        string text = FileUtilies.RemoveRTFFormatting(row[col].ToString());
                        _wordControl.InsertText(text);
                    }
                    else if (colName.EndsWith("RTF") || colName.EndsWith("RTFMITFMT"))
                    {
                        // must be passed in a DataObject to get correct RTF format
                        DataObject myDataObject = new DataObject(DataFormats.Rtf, row[col].ToString());
                        Clipboard.SetDataObject(myDataObject);
                        try
                        {
                        _wordControl.InsertRTF(null);
                        }
                        catch (Exception exp)
                        {
                            DlgProgressLog.AddError(KissMsg.GetMLMessage("WordDoc", "FehlerRTF_Tabelle", "RTF Textmarke kann nicht verarbeitet werden. Es wird stattdessen unformatierter Text eingefügt. (Zeile: {0}, Fehler: {1})", i + 1 /*i fängt bei 0 an, der Benutzer denkt aber dass die erste Zeile auch Zeile 1 (und nicht Zeile 0) ist */, exp.Message));

                            // Füge nochmals eine Linie ein, da sonst der Fehler überschrieben würde
                            DlgProgressLog.AddLine("");

                            // remove formatting and pass as plain text
                            string text = FileUtilies.RemoveRTFFormatting(row[col].ToString());
                            _wordControl.InsertText(text);
                        }
                    }
                    else
                    {
                        if (row[col] is DateTime)
                        {
                            _wordControl.InsertText(((DateTime)row[col]).ToShortDateString());
                        }
                        else
                        {
                            _wordControl.InsertText(row[col].ToString()); // Text
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Replaces the context parameter.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="context">The context.</param>
        /// <param name="originalBookmarkName">Original name of the bookmark.</param>
        /// <returns></returns>
        private bool ReplaceContextParameter(ref string sql, IKissContext context, string originalBookmarkName)
        {
            Regex rgxContextPrm = new Regex(@"{.+?}");
            Match match = rgxContextPrm.Match(sql);

            while (match.Success)
            {
                String matchName = sql.Substring(match.Index, match.Length);
                String contextParameterName = sql.Substring(match.Index + 1, match.Length - 2);
                Object contextValue = context.GetContextValue(contextParameterName);

                if (DBUtil.IsEmpty(contextValue))
                {
                    DlgProgressLog.AddError(
                        KissMsg.GetMLMessage(
                            "WordDoc",
                            "KontextWertNichtGefunden",
                            "FEHLER: Textmarke '{0}' - Kontextwert '{1}' nicht gefunden oder der Wert ist NULL",
                            KissMsgCode.Text,
                            originalBookmarkName,
                            contextParameterName
                            ));

                    // Füge nochmals eine Linie ein, da sonst der Fehler überschrieben würde
                    DlgProgressLog.AddLine("");

                    return false;
                }

                sql = sql.Replace(matchName, DBUtil.SqlLiteral(contextValue));
                match = rgxContextPrm.Match(sql);
            }

            return true;
        }

        #endregion

        #endregion
    }
}