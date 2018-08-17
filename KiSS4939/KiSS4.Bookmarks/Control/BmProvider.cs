using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Dokument.Utilities;
using KiSS4.Dokument.WordAutomation.Elements;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Bookmarks.Control
{
    public class BmProvider
    {
        #region Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Fields

        private IKissContext context;
        private SqlQuery qryXBookmark;

        #endregion

        #region Constructors

        public BmProvider(IKissContext context)
        {
            this.context = context;

            // --- create default sql
            String sql = String.Format(@"
                        SELECT CONVERT(BIT, 1) IsStd,
                               BookmarkName,
                               BookmarkCode,
                               SQL
                        FROM dbo.XBookmark WITH (READUNCOMMITTED)
                        WHERE TableName IS NULL

                        UNION ALL

                        SELECT CONVERT(BIT, 1) IsStd,
                               SBO.BookmarkName,
                               SBO.BookmarkCode,
                               REPLACE(CONVERT(VARCHAR(8000), SBO.SQL), '<TableColumn>', SBO.ReplaceCode)
                        FROM dbo.fnGetStandardBookmarks({0}) SBO", Session.User.LanguageCode);

            // --- check if we have the table DynaField
            if (Session.SupportDynaMask)
            {
                // add bookmarks from DynaField
                sql += @"

                        UNION ALL

                        SELECT CONVERT(BIT, 0) IsStd,
                               FieldName,
                               FieldCode,
                               NULL
                        FROM dbo.DynaField WITH (READUNCOMMITTED)";
            }

            qryXBookmark = DBUtil.OpenSQL(sql);
        }

        #endregion

        #region Public Methods

        public BmValueResult GetBookmarkValue(String BookmarkName)
        {
            return GetBookmarkValue(BookmarkName, BookmarkName);
        }

        public BmValueResult GetBookmarkValue(String baseBookmarkName, String origBookmarkName)
        {
            BmValueResult result;
            DataRow BookmarkRow;

            if (qryXBookmark.Find(string.Format("BookmarkName = '{0}'", baseBookmarkName)))
            {
                result = new BmValueResult(qryXBookmark.Row);
                BookmarkRow = qryXBookmark.Row;
            }
            else
            {
                return null;
            }

            if (result.IsStandard)
            {
                //Standard bookmark found: replace all Context Parameters in SQL and retrieve value
                SqlQuery qryBookmarkValues = new SqlQuery();
                string SQL = BookmarkRow["SQL"].ToString();
                if (ReplaceContextParameter(ref SQL, baseBookmarkName))
                {
                    qryBookmarkValues.Fill(SQL);
                }

                result.BookmarkValue = qryBookmarkValues;
            }
            else
            {
                // --- get LOVCode at the end the bookmark if any
                int idx = origBookmarkName.IndexOf("_C");
                if (idx != -1)
                {
                    result.LOVCode = origBookmarkName.Substring(idx + 2);
                    try
                    {
                        int i = Convert.ToInt32(result.LOVCode);
                    }
                    catch (Exception ex)
                    {
                        logger.Warn(ex);
                        DlgProgressLog.AddError(KissMsg.GetMLMessage("BmProvider", "CodeNichtNumerisch", "FEHLER: Textmarke '{0}': Code am Schluss ist nicht numerisch", KissMsgCode.Text, origBookmarkName));

                        return null;
                    }
                }

                result.BookmarkValue = GetDynaBookmarkValue(context, result.BookmarkCode, baseBookmarkName, origBookmarkName, result.LOVCode == null);
            }

            return result;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the dyna bookmark value.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="FieldCode">The field code.</param>
        /// <param name="BaseBookmarkName">Name of the base bookmark.</param>
        /// <param name="OrigBookmarkName">Name of the orig bookmark.</param>
        /// <param name="LOVListAsText">if set to <c>true</c> [LOV list as text].</param>
        /// <returns></returns>
        private object GetDynaBookmarkValue(IKissContext context, Int32 FieldCode, String BaseBookmarkName, String OrigBookmarkName, Boolean LOVListAsText)
        {
            object faPhaseID = context.GetContextValue("FaPhaseID");
            object faLeistungID = null;

            if (DBUtil.IsEmpty(faPhaseID))
            {
                faLeistungID = context.GetContextValue("FaLeistungID");
            }

            object gridRowID = context.GetContextValue("GridRowID");

            if (DBUtil.IsEmpty(faPhaseID) && DBUtil.IsEmpty(faLeistungID))
            {
                DlgProgressLog.AddError(KissMsg.GetMLMessage("BmProvider", "KontextWertFaLeistungIDNichtGefunden", "FEHLER: Textmarke '{0}' - Kontextwert 'FaLeistungID/FaPhaseID' nicht gefunden", KissMsgCode.Text, OrigBookmarkName));

                return DBNull.Value;
            }

            if (DBUtil.IsEmpty(gridRowID))
            {
                DlgProgressLog.AddError(KissMsg.GetMLMessage("BmProvider", "KontextWertGridRowIDNichtGefunden", "FEHLER: Textmarke '{0}' - Kontextwert 'GridRowID' nicht gefunden", KissMsgCode.Text, OrigBookmarkName));

                return DBNull.Value;
            }

            String sql = @"
                    SELECT ''
                    WHERE {0} = {0}";

            switch (FieldCode)
            {
                case 2: //Text
                case 3: //Memo
                    sql = @"
                        SELECT VAL.Value
                        FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                          INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                        WHERE FLD.FieldName = {0}";
                    break;

                case 4: //Zahl
                    sql = @"
                        SELECT CONVERT(VARCHAR, VAL.Value)
                        FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                          INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                        WHERE FLD.FieldName = {0}";
                    break;

                case 5: //Datum
                    sql = @"
                        SELECT CONVERT(VARCHAR, VAL.Value, 104)
                        FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                          INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                        WHERE FLD.FieldName = {0}";
                    break;

                case 7: //Checkbox
                    sql = @"
                        SELECT CONVERT(BIT, VAL.Value)
                        FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                          INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                        WHERE FLD.FieldName = {0}";
                    break;

                case 8: //Auswahl
                    sql = @"
                        SELECT LOV.Text
                        FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                          INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                          LEFT  JOIN dbo.XLOVCode  LOV WITH (READUNCOMMITTED) ON LOV.LOVName = FLD.LOVName AND
                                                                                 LOV.Code = VAL.Value
                        WHERE FLD.FieldName = {0}";
                    break;

                case 9: //Mehrfachauswahl
                    if (LOVListAsText)
                    {
                        sql = @"
                            SELECT dbo.fnLOVTextListe(FLD.LOVName, CONVERT(VARCHAR, VAL.Value))
                            FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                              INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                            WHERE FLD.FieldName = {0}";
                    }
                    else
                    {
                        sql = @"
                            SELECT VAL.Value
                            FROM DynaField FLD
                              INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                            WHERE FLD.FieldName = {0}";
                    }
                    break;

                case 14: //Auswahl mit Dialog
                    SqlQuery qry;

                    if (!DBUtil.IsEmpty(faPhaseID))
                    {
                        qry = DBUtil.OpenSQL(@"
                            SELECT VAL.Value,
                                   FLD.SQL
                            FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                              INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                            WHERE FLD.FieldName = {0} AND
                                  VAL.FaPhaseID = {1} AND
                                  GridRowID = {2}", BaseBookmarkName, faPhaseID, gridRowID);
                    }
                    else
                    {
                        qry = DBUtil.OpenSQL(@"
                            SELECT VAL.Value,
                                   FLD.SQL
                            FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                              INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                            WHERE FLD.FieldName = {0} AND
                                  VAL.FaLeistungID = {1} AND
                                  GridRowID = {2}", BaseBookmarkName, faLeistungID, gridRowID);
                    }

                    if (qry.Count > 0)
                    {
                        sql = qry["SQL"].ToString();
                        Int32 Pos = sql.IndexOf("----");

                        if (Pos >= 0)
                        {
                            return DBUtil.ExecuteScalarSQL(sql.Substring(Pos + 4), qry["Value"]);
                        }
                    }

                    return DBNull.Value;

                case 15: //RTF
                    sql = @"
                        SELECT VAL.ValueText
                        FROM dbo.DynaField FLD WITH (READUNCOMMITTED)
                          INNER JOIN dbo.DynaValue VAL WITH (READUNCOMMITTED) ON VAL.DynaFieldID = FLD.DynaFieldID
                        WHERE FLD.FieldName = {0}";
                    break;

                case 16: //Temp Fixtext from IKissContext
                    //TODO: Florian, what is this good for?
                    try
                    {
                        Object value = context.GetContextValue(OrigBookmarkName);
                        if (value != null)
                        {
                            return value;
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Warn(ex);
                    }
                    return String.Empty;
            }

            if (!DBUtil.IsEmpty(faPhaseID))
            {
                sql += " AND VAL.FaPhaseID = {1} AND GridRowID = {2}";
                return DBUtil.ExecuteScalarSQL(sql, BaseBookmarkName, faPhaseID, gridRowID);
            }
            else
            {
                sql += " AND VAL.FaLeistungID = {1} AND GridRowID = {2}";
                return DBUtil.ExecuteScalarSQL(sql, BaseBookmarkName, faLeistungID, gridRowID);
            }
        }

        /// <summary>
        /// Replaces the context parameter.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="context">The context.</param>
        /// <param name="originalBookmarkName">Original name of the bookmark.</param>
        /// <returns></returns>
        private Boolean ReplaceContextParameter(ref String sql, String originalBookmarkName)
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
                    DlgProgressLog.AddError(KissMsg.GetMLMessage("BmProvider", "KontextWertNichtGefunden", "FEHLER: Textmarke '{0}' - Kontextwert '{1}' nicht gefunden", KissMsgCode.Text, originalBookmarkName, contextParameterName));

                    return false;
                }

                sql = sql.Replace(matchName, DBUtil.SqlLiteral(contextValue));
                match = rgxContextPrm.Match(sql);
            }

            return true;
        }

        #endregion
    }
}