using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using DevExpress.XtraTreeList.Nodes;

namespace KiSS4.DB
{
    #region Enumerations

    /// <summary>
    /// PermissionCode
    /// </summary>
    public enum Permission
    {
        /// <summary/>
        Sh_FPNormal_Lebenshaltungkosten = 1,

        /// <summary/>
        Sh_FPNormal_WiederkehrendeSILs = 2,

        /// <summary/>
        Sh_FPNormal_MaximaleDauer = 3,

        /// <summary/>
        Sh_FPNormal_einmaligeVerlaengerung = 4,

        /// <summary/>
        Sh_FPUeberbrueckung_Lebenshaltungkosten = 5,

        /// <summary/>
        Sh_FPUeberbrueckung_WiederkehrendeSILs = 6,

        /// <summary/>
        Sh_FPUeberbrueckung_MaximaleDauer = 7,

        /// <summary/>
        Sh_FPUeberbrueckung_einmaligeVerlaengerung = 8,

        /// <summary/>
        Sh_FPbenoetigtimmerBewilligung = 9,

        /// <summary/>
        Sh_StartsaldoVorabzugskonto = 12,

        /// <summary/>
        Sh_Monatsbudget_EinzelzahlungbenoetigtimmerBewilligung = 13,

        /// <summary/>
        Sh_Monatsbudget_Freigeben = 14,

        /// <summary/>
        Sh_User_ErhaeltAnfragen = 15
    }

    #endregion

    /// <summary>
    /// Summary description for Global.
    /// </summary>
    public class DBUtil
    {
        #region Enumerations

        public enum LOVOrderByColumnEnum
        {
            SortKeyCode,
            SortKeyText,
            SortKeyShortText,
            Code,
            Text,
            ShortText
        }

        #endregion

        #region Fields

        #region Public Static Fields

        /// <summary>
        /// Color for Background of MessageBoxes
        /// </summary>
        public static Color DefaultMessageDialogBackColor = Color.LemonChiffon;

        #endregion

        #region Private Static Fields

        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private const string TYPEFULLNAME = "KiSS4.DB.DBUtil";

        #endregion

        #endregion

        #region EventHandlers

        /// <summary>
        /// Checks the timestamp for all rows in a datatable and throws a DBConcurrencyException in case of conflicts.
        /// </summary>
        /// <param name="qryStart">The SqlQuery with all rows at the beginning of editing</param>
        /// <param name="qryEnd">The SqlQuery with all rows at the end of editing, opened in a transaction.</param>
        /// <param name="fieldNameID">The fieldname of the primary key of the DB table.</param>
        /// <param name="fieldNameTS">The fieldname of the timestamp.</param>
        public static void CheckForTimeStampConflict_OnePK(SqlQuery qryStart, SqlQuery qryEnd, string fieldNameID, string fieldNameTS)
        {
            // ==================================================================================================
            // TODO : Refact for mutiple primary key fields:
            //        CheckForTimeStampConflict_OnePK -> CheckForTimeStampConflict
            //        string fieldNameID -> string[] fieldNamesID
            // ==================================================================================================
            byte[] concurrenyStart;
            byte[] concurrenyEnd;
            int oldRowCount = 0;
            foreach (DataRow row in qryStart.DataTable.Rows)
            {
                // Wenn der TS leer ist, wurde die Zeile neu erstellt.
                // In diesem Fall brauchen wir keine Checks zu machen,
                // denn neue Zeilen verursachen nie einen TS-Konflikt und dürfen immer eingefügt werden:
                concurrenyStart = row[fieldNameTS] as byte[];
                if (concurrenyStart.Length != 0)
                {
                    // Bei einer existierenden Zeile muss die alte vorhanden sein.
                    // Wenn nicht hat sie ein anderer User vermutlich gelöscht
                    // In diesem Fall dürfen keine DB-Änderungen gemacht werden:
                    if (!qryEnd.Find(string.Format("{0}={1}", fieldNameID, Convert.ToString(row[fieldNameID]))))
                    {
                        throw new DBConcurrencyException("Row ID not found.");
                    }

                    // die alte Zeile wurde per Schlüssel gefunden, also jetzt den TS-Check machen:
                    concurrenyEnd = qryEnd[fieldNameTS] as byte[];
                    if (concurrenyStart != null && concurrenyEnd != null)
                    {
                        if (!BytesAreEqual(concurrenyStart, concurrenyEnd))
                        {
                            throw new DBConcurrencyException("Row has been changed meanwhile.");
                        }
                    }
                    oldRowCount++;
                }
            }
            if (oldRowCount != qryEnd.Count)
            {
                throw new DBConcurrencyException("Initial row count does not match to actual row count.");
            }
        }

        /// <summary>
        /// Copies one row to a new one. All fields are being copied, excluding fields listed in "ExcludingFieldNames"
        /// </summary>
        /// <param name="qry">The Query for copying</param>
        /// <param name="excludingFieldNames">List of the Fieldnames which are not being copied</param>
        /// <param name="doPost">When true, the method SqlQuery.Post() is called</param>
        public static void CopyDataRow_ExcludingFields(SqlQuery qry, string[] excludingFieldNames, bool doPost)
        {
            // Zuerst speichern:
            qry.Post();

            // Zuerst alles zu Grossbuchstaben ändern:
            for (int i = 0; i < excludingFieldNames.Length; i++)
            {
                excludingFieldNames[i] = excludingFieldNames[i].ToUpper();
            }

            // Feldwerte lesen:
            object[] FieldValues = qry.Row.ItemArray;

            // Neuer Datensatz erstellen, Feldwerte speichern:
            qry.Insert();

            for (int i = 0; i < qry.DataTable.Columns.Count; i++)
            {
                if (Array.IndexOf(excludingFieldNames, qry.DataTable.Columns[i].ColumnName.ToUpper()) == -1)
                {
                    qry[qry.DataTable.Columns[i].ColumnName] = FieldValues[i];
                }
            }

            qry.RefreshDisplay();

            if (doPost)
            {
                qry.Post();
            }
        }

        /// <summary>
        /// Copies one row to a new one. All fields listed in "IncludingFieldNames" are being copied.
        /// </summary>
        /// <param name="qry">The Query for copying</param>
        /// <param name="includingFieldNames">List of the Fieldnames which are being copied</param>
        /// <param name="doPost">When true, the method SqlQuery.Post() is called</param>
        public static void CopyDataRow_IncludingFields(SqlQuery qry, string[] includingFieldNames, bool doPost)
        {
            // Zuerst speichern:
            qry.Post();

            // Feldwerte lesen:
            System.Collections.Generic.List<object> FieldValues = new System.Collections.Generic.List<object>();

            for (int i = 0; i < includingFieldNames.Length; i++)
            {
                object tmpObj = new object();
                tmpObj = qry[includingFieldNames[i]];
                FieldValues.Add(tmpObj);
            }

            // Neuer Datensatz erstellen, Feldwerte speichern:
            qry.Insert();

            for (int i = 0; i < includingFieldNames.Length; i++)
            {
                qry[includingFieldNames[i]] = FieldValues[i];
            }

            qry.RefreshDisplay();

            if (doPost)
            {
                qry.Post();
            }
        }

        /// <summary>
        /// Gets the info about the user who created the datarow.
        /// </summary>
        /// <param name="qry">Query of interest</param>
        /// <returns>The info about the user who created the datarow.</returns>
        public static string GetUserInfo_Created(KiSS4.DB.SqlQuery qry)
        {
            if (DBUtil.IsEmpty(qry["ErstelltUserID"]))
            {
                return "";
            }

            // TODO: Dieses SQL sollte bei Verbindung zur Datenbank erstellt werden und dann immer wieder genutzt werden:
            SqlQuery qryUser = OpenSQL(@"
                SELECT USR.LogonName
                FROM dbo.XUser USR
                WHERE USR.UserID = {0}", qry["ErstelltUserID"]);

            return string.Format("{0}, {1}", qryUser["LogonName"], Convert.ToDateTime(qry["ErstelltDatum"]).ToString("dd.MM.yyyy"));
        }

        /// <summary>
        /// Gets the info about the user who modified the datarow.
        /// </summary>
        /// <param name="qry">Query of interest</param>
        /// <returns>The info about the user who modified the datarow.</returns>
        public static string GetUserInfo_Modified(KiSS4.DB.SqlQuery qry)
        {
            if (DBUtil.IsEmpty(qry["MutiertUserID"]))
            {
                return "";
            }

            // TODO: Dieses SQL sollte bei Verbindung zur Datenbank erstellt werden und dann immer wieder genutzt werden:
            SqlQuery qryUser = OpenSQL(@"
                SELECT USR.LogonName
                FROM dbo.XUser USR
                WHERE USR.UserID = {0}", qry["MutiertUserID"]);

            return string.Format("{0}, {1}", qryUser["LogonName"], Convert.ToDateTime(qry["MutiertDatum"]).ToString("dd.MM.yyyy"));
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// returns " where " or " and ".
        /// </summary>
        public static string AndOrWhere(string sql)
        {
            // TODO to be refined in case of subqueries with where clauses
            if (sql.ToLower().IndexOf("where") == -1)
            {
                return " WHERE ";
            }
            else
            {
                return " AND ";
            }
        }

        /// <summary>
        /// Apply the Fallrights <see cref="GetFallRights"/> to a SqlQuery
        /// </summary>
        /// <param name="faLeistungID">ID of Fall</param>
        /// <param name="qry">SqlQuery to apply</param>
        public static void ApplyFallRightsToSqlQuery(int faLeistungID, SqlQuery qry)
        {
            if (!qry.CanInsert && !qry.CanUpdate && !qry.CanDelete)
            {
                return;
            }

            bool mayRead;
            bool mayInsert;
            bool mayUpdate;
            bool mayDelete;
            bool mayClose;
            bool mayReopen;

            GetFallRights(faLeistungID, out mayRead, out mayInsert, out mayUpdate, out mayDelete, out mayClose, out mayReopen);

            qry.CanInsert &= mayInsert;
            qry.CanUpdate &= mayUpdate;
            qry.CanDelete &= mayDelete;
        }

        /// <summary>
        /// Mask the query's insert, update, delete capabilities with the user's rights.
        /// </summary>
        /// <param name="rightName">RightName or ClassName</param>
        /// <param name="qry">SqlQuery to apply</param>
        public static void ApplyUserRightsToSqlQuery(string rightName, SqlQuery qry)
        {
            if (!qry.CanInsert && !qry.CanUpdate && !qry.CanDelete)
            {
                return;
            }

            bool mayRead;
            bool mayInsert;
            bool mayUpdate;
            bool mayDelete;

            Session.GetUserRight(rightName, out mayRead, out mayInsert, out mayUpdate, out mayDelete);

            qry.CanInsert &= mayInsert;
            qry.CanUpdate &= mayUpdate;
            qry.CanDelete &= mayDelete;
        }

        /// <summary>
        /// Compares two arrays of bytes value by value.
        /// </summary>
        /// <param name="arrayOne">The first array to compare.</param>
        /// <param name="arrayTwo">The second array to compare.</param>
        public static bool BytesAreEqual(byte[] arrayOne, byte[] arrayTwo)
        {
            bool result = false;
            if (arrayOne != null && arrayTwo != null)
            {
                if (arrayOne.Length == arrayTwo.Length)
                {
                    for (int i = 0; i < arrayOne.Length; i++)
                    {
                        if (arrayOne[i] != arrayTwo[i])
                        {
                            return result;
                        }
                    }
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Throws an exception if the value <see cref="IsEmpty"/>.
        /// </summary>
        /// <param name="ctl">The control to validate</param>
        public static void CheckNotNullField(IKissBindableEdit ctl)
        {
            CheckNotNullField(ctl, ctl.DataMember);
        }

        /// <summary>
        /// Throws an exception if the value <see cref="IsEmpty"/>.
        /// </summary>
        /// <param name="ctl">The control to validate</param>
        /// <param name="userColName">The name of the control (Ex. Labeltext)</param>
        public static void CheckNotNullField(IKissBindableEdit ctl, string userColName)
        {
            object value = null;

            switch (ctl.GetType().FullName)
            {
                case "KiSS4.Gui.KissTextEditML":
                case "KiSS4.Gui.KissMemoEditML":
                    value = ((DevExpress.XtraEditors.BaseEdit)ctl).EditValue;
                    break;

                default:
                    if (ctl.DataSource == null || IsEmpty(ctl.DataMember))
                    {
                        PropertyInfo prop = ctl.GetType().GetProperty(ctl.GetBindablePropertyName());
                        value = prop.GetValue(ctl, new object[0]);
                    }
                    else
                    {
                        value = ctl.DataSource[ctl.DataMember];
                    }
                    break;
            }

            if (IsEmpty(value))
            {
                throw new KissInfoException(KissMsg.GetMLMessage("DBUtil",
                                                                 "FeldXYLeer",
                                                                 "Das Feld '{0}' darf nicht leer bleiben !",
                                                                 KissMsgCode.MsgInfo,
                                                                 userColName),
                                            (Control)ctl);
            }
        }

        /// <summary>
        /// Throws an exception if the value in a Grid <see cref="IsEmpty"/>.
        /// The Grid is represented by the SqlQuery which is the Grid's DataSource.
        /// </summary>
        /// <param name="qry">SqlQuery containing the value.</param>
        /// <param name="colName">The Column in the SqlQuery.</param>
        /// <param name="userColName">User defined column name for better validation information.</param>
        public static void CheckNotNullFieldInGrid(SqlQuery qry, string colName, string userColName)
        {
            object Value = null;

            if (qry == null)
            {
                return;
            }

            try
            {
                Value = qry[colName];
            }
            catch { }

            if (IsEmpty(Value))
            {
                throw new KissInfoException(KissMsg.GetMLMessage("DBUtil",
                                                                 "FeldXYLeer",
                                                                 "Das Feld '{0}' darf nicht leer bleiben !",
                                                                 KissMsgCode.MsgInfo,
                                                                 userColName));
            }
        }

        /// <summary>
        /// Executes the specified Statement against the current db-connection. returns affected rows
        /// </summary>
        /// <param name="sqlStatement"></param>
        /// <param name="sqlParameters"></param>
        public static int ExecSQL(string sqlStatement, params object[] sqlParameters)
        {
            return ExecSQL(30, sqlStatement, sqlParameters);
        }

        /// <summary>
        /// Executes the specified Statement against the current db-connection. returns affected rows
        /// Do not use in transactions!
        /// </summary>
        public static int ExecSQL(int commandTimeout, string sqlStatement, params object[] sqlParameters)
        {
            try
            {
                return ExecSQLThrowingException(commandTimeout, sqlStatement, sqlParameters);
            }
            catch (Exception ex)
            {
                // 06.04.2009: Umbau Transaktionen:
                // Wenn eine Transaktion vorhanden ist, dann darf Fehler nicht hier abgehandelt werden:
                //Session.SafeRollback();

                if (ex is KissCancelException)
                {
                    if (Session.Transaction == null)
                    {
                        ((KissCancelException)ex).ShowMessage();
                    }
                    else
                    {
                        throw;
                    }
                }
                else
                {
                    string ErrorMsg = KissMsg.GetMLMessage("DBUtil",
                                                           "DBFehler_v01",
                                                           "Beim Ausführen eines Datenbankbefehls ist ein Fehler aufgetreten.");

                    if (Session.Transaction == null)
                    {
                        KissMsg.ShowError(ErrorMsg, DBUtil.SqlCommandToString(CreateSqlCommand(sqlStatement, sqlParameters)));
                    }
                    else
                    {
                        throw new KissErrorException(ErrorMsg, DBUtil.SqlCommandToString(CreateSqlCommand(sqlStatement, sqlParameters)), null);
                    }
                }

                return -1;
            }
        }

        /// <summary>
        /// Executes the specified Statement against the current db-connection. Does no exception handling.
        /// Returns number of rows affected.
        /// </summary>
        /// <param name="sqlStatement">SQL statement to execute</param>
        /// <param name="sqlParameters">Parameters to SQL statement, null if none</param>
        /// <returns></returns>
        public static int ExecSQLThrowingException(string sqlStatement, params object[] sqlParameters)
        {
            return ExecSQLThrowingException(30, sqlStatement, sqlParameters);
        }

        /// <summary>
        /// Executes the specified Statement against the current db-connection. Does no exception handling.
        /// Returns number of rows affected.
        /// </summary>
        /// <param name="commandTimeout">SQL Commandtimeout</param>
        /// <param name="sqlStatement">SQL statement to execute</param>
        /// <param name="sqlParameters">Parameters to SQL statement, null if none</param>
        /// <returns></returns>
        public static int ExecSQLThrowingException(int commandTimeout, string sqlStatement, params object[] sqlParameters)
        {
            if (!Session.Active)
            {
                return 0;
            }

            Cursor saveCursor = Cursor.Current;
            Cursor.Current = Cursors.AppStarting;

            SqlCommand cmd = CreateSqlCommand(sqlStatement, sqlParameters);
            cmd.CommandTimeout = commandTimeout;

            int rows = 0;

            try
            {
                lock (Session.Connection)
                {
                    rows = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException eSql)
            {
                throw HandleSqlError(eSql, cmd);
            }
            finally
            {
                Cursor.Current = saveCursor;
            }

            return rows;
        }

        /// <summary>
        /// Executes the specified Statement against the current db-connection. returns value from first column of first record
        /// Do not use in transactions.
        /// </summary>
        /// <param name="sqlStatement"></param>
        /// <param name="sqlParameters"></param>
        public static object ExecuteScalarSQL(string sqlStatement, params object[] sqlParameters)
        {
            try
            {
                return ExecuteScalarSQLThrowingException(sqlStatement, sqlParameters);
            }
            catch (Exception ex)
            {
                // 06.04.2009: Umbau Transaktionen:
                // Wenn eine Transaktion vorhanden ist, dann darf Fehler nicht hier abgehandelt werden:
                //Session.SafeRollback();

                if (ex is KissCancelException)
                {
                    if (Session.Transaction == null)
                    {
                        ((KissCancelException)ex).ShowMessage();
                    }
                    else
                    {
                        throw;
                    }
                }
                else
                {
                    string errorMsg = KissMsg.GetMLMessage("DBUtil",
                                                           "DBFehler_v01",
                                                           "Beim Ausführen eines Datenbankbefehls ist ein Fehler aufgetreten.");

                    if (Session.Transaction == null)
                    {
                        KissMsg.ShowError(errorMsg, DBUtil.SqlCommandToString(CreateSqlCommand(sqlStatement, sqlParameters)));
                    }
                    else
                    {
                        throw new KissErrorException(errorMsg, DBUtil.SqlCommandToString(CreateSqlCommand(sqlStatement, sqlParameters)), null);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Executes the specified Statement against the current db-connection. returns value from first column of first record
        /// </summary>
        /// <param name="sqlStatement"></param>
        /// <param name="sqlParameters"></param>
        public static object ExecuteScalarSQLThrowingException(string sqlStatement, params object[] sqlParameters)
        {
            if (!Session.Active)
            {
                return null;
            }

            Cursor saveCursor = Cursor.Current;
            Cursor.Current = Cursors.AppStarting;

            SqlCommand cmd = CreateSqlCommand(sqlStatement, sqlParameters);

            try
            {
                lock (Session.Connection)
                {
                    return cmd.ExecuteScalar();
                }
            }
            catch (SqlException eSql)
            {
                throw HandleSqlError(eSql, cmd);
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
        }

        /// <summary>
        /// Copies fields from query FromQuery to query ToQuery
        /// </summary>
        /// <param name="fromQuery">Query from which Field will be copied</param>
        /// <param name="toQuery">Query to which field will be copied</param>
        public static void FillDataRow(KiSS4.DB.SqlQuery fromQuery, KiSS4.DB.SqlQuery toQuery)
        {
            // Felder kopieren:
            for (int i = 0; i < fromQuery.DataTable.Columns.Count; i++)
            {
                toQuery[fromQuery.DataTable.Columns[i].ColumnName] = fromQuery[fromQuery.DataTable.Columns[i].ColumnName];
            }
        }

        /// <summary>
        /// Find a <see cref="TreeListNode"/> by id.
        /// </summary>
        public static TreeListNode FindNodeByID(TreeListNodes nodes, string id)
        {
            return FindNodeByValue(nodes, id, nodes.TreeList.KeyFieldName);
        }

        /// <summary>
        /// Find a <see cref="TreeListNode"/> by value.
        /// </summary>
        public static TreeListNode FindNodeByValue(TreeListNodes nodes, string value, string fieldName)
        {
            // rekursive Suche
            foreach (TreeListNode node in nodes)
            {
                if (node.GetValue(fieldName).ToString() == value)
                {
                    return node;
                }
                else if (node.HasChildren)
                {
                    TreeListNode n = FindNodeByValue(node.Nodes, value, fieldName);

                    if (n != null)
                    {
                        return n;
                    }
                }
            }
            return null;
        }

        public static string GetAutomaticAnredeText(int? alter, int? geschlechtCode)
        {
            int geschlechtCodeValue = geschlechtCode.HasValue ? geschlechtCode.Value : 0;

            if (alter.HasValue)
            {
                // get for person
                return ExecuteScalarSQLThrowingException(@"
                    SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, {0}, NULL, NULL, {1}, {2}, 'famherrfrau', '', NULL, NULL, NULL);",
                    alter.Value, geschlechtCodeValue, Session.User.LanguageCode) as string;
            }

            // get for institution
            return ExecuteScalarSQLThrowingException(@"
                SELECT dbo.fnBaGetAnredeAnschriftBaInstitution(NULL, {0}, {1}, 'herrfrau', '');",
                geschlechtCodeValue, Session.User.LanguageCode) as string;
        }

        public static string GetAutomaticBriefanredeText(int? alter, int? geschlechtCode)
        {
            int geschlechtCodeValue = geschlechtCode.HasValue ? geschlechtCode.Value : 0;

            if (alter.HasValue)
            {
                // get for person
                return ExecuteScalarSQLThrowingException(@"
                    SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, {0}, NULL, NULL, {1}, {2}, 'geehrte', '', NULL, NULL, NULL);",
                    alter.Value, geschlechtCodeValue, Session.User.LanguageCode) as string;
            }

            // get for institution
            return ExecuteScalarSQLThrowingException(@"
                SELECT dbo.fnBaGetAnredeAnschriftBaInstitution(NULL, {0}, {1}, 'geehrte', '');",
                geschlechtCodeValue, Session.User.LanguageCode) as string;
        }

        /// <summary>
        /// Gets the config bool.
        /// </summary>
        /// <param name="keyPath">The key path.</param>
        /// <param name="defaultValue">if set to <c>true</c> [default value].</param>
        /// <returns></returns>
        public static Boolean GetConfigBool(string keyPath, Boolean defaultValue)
        {
            object value = GetConfigValue(keyPath, defaultValue);

            if (IsEmpty(value))
            {
                return defaultValue;
            }
            else if (value is bool)
            {
                return Convert.ToBoolean(value);
            }
            else
            {
                return (value.ToString() == "1");
            }
        }

        /// <summary>
        /// Gets the config date time.
        /// </summary>
        /// <param name="keyPath">The key path.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static DateTime GetConfigDateTime(string keyPath, DateTime defaultValue)
        {
            object value = GetConfigValue(keyPath, defaultValue);

            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Gets the config decimal.
        /// </summary>
        /// <param name="keyPath">The key path.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static Decimal GetConfigDecimal(string keyPath, Decimal defaultValue)
        {
            object value = GetConfigValue(keyPath, defaultValue);

            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Gets the config double.
        /// </summary>
        /// <param name="keyPath">The key path.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static double GetConfigDouble(string keyPath, double defaultValue)
        {
            object value = GetConfigValue(keyPath, defaultValue);

            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Gets the config int.
        /// </summary>
        /// <param name="keyPath">The key path.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static int GetConfigInt(string keyPath, int defaultValue)
        {
            object value = GetConfigValue(keyPath, defaultValue);

            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Gets the config string.
        /// </summary>
        /// <param name="keyPath">The key path.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>the <see cref="KeyEventArgs"/> for the given shortcut</returns>
        public static KeyEventArgs GetConfigShortcut(string keyPath, string defaultValue)
        {
            string shortcutString = DBUtil.GetConfigString(keyPath, defaultValue);
            KeyEventArgs key;
            var parsed = TryParseKeys(shortcutString, out key);
            if (!parsed)
            {
                TryParseKeys(defaultValue, out key);
            }

            return key;
        }

        /// <summary>
        /// Gets the config string.
        /// </summary>
        /// <param name="keyPath">The key path.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static string GetConfigString(string keyPath, string defaultValue)
        {
            object value = GetConfigValue(keyPath, defaultValue);

            if (IsEmpty(value))
            {
                return defaultValue;
            }
            else
            {
                var stringValue = value.ToString();
                //fix any manually entered newlines (if the user enters \n in the config-screen, the system automatically quotes the backslash --> \\n)
                stringValue = stringValue.Replace("\\n", "\n");
                //the same applies to \r
                stringValue = stringValue.Replace("\\r", "\r");
                return stringValue;
            }
        }

        /// <summary>
        /// Convenience wrapper using current date and time as value for ValidFrom.
        /// </summary>
        /// <param name="keyPath"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static object GetConfigValue(string keyPath, object defaultValue)
        {
            return GetConfigValue(keyPath, defaultValue, DateTime.Now);
        }

        /// <summary>
        /// Get configuration value from XConfig with KeyPath.
        /// NOTE: Records in XConfig, which have DBNull in ValidFrom cannot be retrieved by this
        /// routine - they are considered disabled.
        /// </summary>
        /// <param name="keyPath">Unique key</param>
        /// <param name="defaultValue">Value returned if keyPath not found in DB</param>
        /// <param name="datumVon">XConfig entry must have ValidFrom date smaller or equal than this parameter</param>
        /// <returns>object containing the desired value, System.DBNull if null in DB</returns>
        public static object GetConfigValue(string keyPath, object defaultValue, DateTime datumVon)
        {
            return GetConfigValue(keyPath, defaultValue, datumVon, true);
        }

        /// <summary>
        /// Get configuration value from XConfig with KeyPath.
        /// NOTE: Records in XConfig, which have DBNull in ValidFrom cannot be retrieved by this
        /// routine - they are considered disabled.
        /// </summary>
        /// <param name="keyPath">Unique key</param>
        /// <param name="defaultValue">Value returned if keyPath not found in DB</param>
        /// <param name="datumVon">XConfig entry must have ValidFrom date smaller or equal than this parameter</param>
        /// <param name="useCache">If a cached value exists, use it</param>
        /// <returns>object containing the desired value, System.DBNull if null in DB</returns>
        public static object GetConfigValue(string keyPath, object defaultValue, DateTime datumVon, bool useCache)
        {
            if (!Session.Active || Session.CacheManager == null || Session.CacheManager.ConfigValue == null)
            {
                // no active session or no config-storage
                return defaultValue;
            }

            // get config value from session-storage
            return Session.CacheManager.ConfigValue.GetConfigValue(keyPath, defaultValue, datumVon, useCache);
        }

        /// <summary>
        /// Get the table column value for Creator or Modifier for current user
        /// </summary>
        /// <returns>The value used for Creator or Modifier depending on current user</returns>
        public static string GetDBRowCreatorModifier()
        {
            // combine values as defined: "LastName, FirstName (UserID)"
            return string.Format("{0}, {1} ({2})", Session.User.LastName, Session.User.FirstName, Session.User.UserID);
        }

        /// <summary>
        /// Get the table column value for Creator or Modifier for given userID
        /// </summary>
        /// <param name="userID">The id of the user to get information from</param>
        /// <returns>The value used for Creator or Modifier depending on given userID</returns>
        public static string GetDBRowCreatorModifier(int userID)
        {
            // validate userID
            if (userID < 1)
            {
                // invalid userid
                throw new ArgumentOutOfRangeException("userID", userID, "The given userID is invalid. The value cannot be less than 1.");
            }

            // check if userID is current user, so we do not have to ask database
            if (userID == Session.User.UserID)
            {
                // get data from current session user
                return GetDBRowCreatorModifier();
            }

            // get value from database as it is unknown otherwise
            return Convert.ToString(DBUtil.ExecuteScalarSQLThrowingException("SELECT dbo.fnGetDBRowCreatorModifier({0})", userID));
        }

        /// <summary>
        /// Return the Rights of the current User assign to a Fall based on groupmembership and explicite Access
        /// </summary>
        /// <param name="faLeistungID">ID of Fall</param>
        /// <param name="mayRead">Return Readright</param>
        /// <param name="mayInsert">Return Insertright</param>
        /// <param name="mayUpdate">Return Updateright</param>
        /// <param name="mayDelete">Return Deleteright</param>
        /// <param name="mayClose">Return Closeright</param>
        /// <param name="mayReopen">Return Reopenright</param>
        public static void GetFallRights(int faLeistungID,
            out bool mayRead,
            out bool mayInsert,
            out bool mayUpdate,
            out bool mayDelete,
            out bool mayClose,
            out bool mayReopen)
        {
            mayRead = false;
            mayInsert = false;
            mayUpdate = false;
            mayDelete = false;
            mayClose = false;
            mayReopen = false;

            SqlQuery qry = DBUtil.OpenSQL("EXEC dbo.spFaGetFallZugriff {0}, {1}", Session.User.UserID, faLeistungID);

            if (qry.Count > 0)
            {
                mayRead = Convert.ToBoolean(qry["MayRead"]);
                mayInsert = Convert.ToBoolean(qry["MayInsert"]);
                mayUpdate = Convert.ToBoolean(qry["MayUpdate"]);
                mayDelete = Convert.ToBoolean(qry["MayDelete"]);

                try
                {
                    mayClose = Convert.ToBoolean(qry.Row["MayClose"]);
                    mayReopen = Convert.ToBoolean(qry.Row["MayReopen"]);
                }
                catch
                {
                    mayClose = true;
                    mayReopen = true;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lovName"></param>
        /// <param name="allowNull"></param>
        /// <returns></returns>
        public static SqlQuery GetLOVQuery(string lovName, bool allowNull)
        {
            return GetLOVQuery(lovName, allowNull, null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lovName"></param>
        /// <param name="allowNull"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static SqlQuery GetLOVQuery(string lovName, bool allowNull, string filter)
        {
            if (Session.User == null)
            {
                return GetLOVQuery(lovName, 0, allowNull, filter);
            }
            else
            {
                return GetLOVQuery(lovName, Session.User.LanguageCode, allowNull, filter);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lovName"></param>
        /// <param name="languageCode"></param>
        /// <param name="allowNull"></param>
        /// <returns></returns>
        public static SqlQuery GetLOVQuery(string lovName, int languageCode, bool allowNull)
        {
            return GetLOVQuery(lovName, languageCode, allowNull, null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lovName"></param>
        /// <param name="languageCode"></param>
        /// <param name="allowNull"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static SqlQuery GetLOVQuery(string lovName, int languageCode, bool allowNull, string filter)
        {
            return GetLOVQuery(lovName, languageCode, allowNull, filter, false, LOVOrderByColumnEnum.SortKeyCode);
        }

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="lovName"></param>
        ///  <param name="languageCode"></param>
        ///  <param name="allowNull"></param>
        ///  <param name="filter"></param>
        ///  <param name="withRowFilter"></param>
        ///  <param name="orderByColumn"></param>
        ///  <returns></returns>
        public static SqlQuery GetLOVQuery(string lovName, int languageCode, bool allowNull, string filter, bool withRowFilter, LOVOrderByColumnEnum orderByColumn)
        {
            string sql;

            switch (lovName)
            {
                case "Modul":
                    sql = @"
                        SELECT Code      = MDL.ModulID,
                               Text      = MDL.Name,
                               ShortText = MDL.ShortName,
                               SortKey   = ISNULL(MDL.SortKey, 0),
                               IsActive  = MDL.Licensed
                        FROM dbo.XModul MDL WITH (READUNCOMMITTED)
                        WHERE 1 = 1 ";

                    sql += filter; // split string due to SqlSyntaxCheck tool
                    break;

                case "BaLand":
                    string landCol = "LAN.Text";

                    switch (languageCode)
                    {
                        case 2:
                            landCol = "LAN.TextFR";
                            break;

                        case 3:
                            landCol = "LAN.TextIT";
                            break;

                        case 4:
                            landCol = "LAN.TextEN";
                            break;
                    }

                    sql = string.Format(@"
                        SELECT Code      = LAN.BaLandID,
                               Text      = {0},
                               ShortText = ISNULL(NULL, LAN.Iso3Code),
                               Value1    = ISNULL(NULL, LAN.Iso2Code),
                               SortKey   = ISNULL(LAN.SortKey, 0),
                               IsActive  = CASE
                                             WHEN GETDATE() BETWEEN DatumVon AND ISNULL(DatumBis, '99991231')
                                             THEN 1
                                             ELSE 0
                                           END
                        FROM dbo.BaLand LAN WITH (READUNCOMMITTED)
                        WHERE 1 = 1 ",
                            landCol);
                    sql += filter; // split string due to SqlSyntaxCheck tool

                    if (orderByColumn == LOVOrderByColumnEnum.SortKeyCode)
                    {
                        orderByColumn = LOVOrderByColumnEnum.SortKeyText;
                    }

                    break;

                default:
                    sql = @"
                        SELECT Code      = LOV.Code,
                               Text      = ISNULL(TXT.Text, LOV.Text),
                               ShortText = ISNULL(STX.Text, LOV.ShortText),
                               Value1    = ISNULL(NULL, LOV.Value1),
                               Value2    = ISNULL(NULL, LOV.Value2),
                               Value3    = ISNULL(NULL, LOV.Value3),
                               SortKey   = ISNULL(LOV.SortKey, 0),
                               IsActive  = LOV.IsActive
                        FROM dbo.XLOVCode         LOV WITH (READUNCOMMITTED)
                          LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = LOV.TextTID
                                                                            AND TXT.LanguageCode = {1}
                          LEFT JOIN dbo.XLangText STX WITH (READUNCOMMITTED) ON STX.TID = LOV.ShortTextTID
                                                                            AND STX.LanguageCode = {1}
                        WHERE LOV.LOVName = CONVERT(VARCHAR(100), {0}) ";
                    sql += filter; // split string due to SqlSyntaxCheck tool

                    break;
            }

            switch (orderByColumn)
            {
                case LOVOrderByColumnEnum.Code:
                    sql += " ORDER BY Code";
                    break;

                case LOVOrderByColumnEnum.ShortText:
                    sql += " ORDER BY ShortText";
                    break;

                case LOVOrderByColumnEnum.SortKeyCode:
                    sql += " ORDER BY SortKey, Code";
                    break;

                case LOVOrderByColumnEnum.SortKeyShortText:
                    sql += " ORDER BY SortKey, ShortText";
                    break;

                case LOVOrderByColumnEnum.SortKeyText:
                    sql += " ORDER BY SortKey, Text";
                    break;

                case LOVOrderByColumnEnum.Text:
                    sql += " ORDER BY Text";
                    break;
            }

            // get copy of SqlQuery from cache
            return Session.CacheManager.LOVQuery.GetLOVQuery(sql, lovName, languageCode, allowNull, withRowFilter);
        }

        /// <summary>
        /// Returns the text of a LOV in default language
        /// </summary>
        /// <param name="lovName">Name of the LOV</param>
        /// <param name="code">Code of the LOV</param>
        /// <returns>LOV-Text as a string</returns>
        public static string GetLOVText(string lovName, int code)
        {
            if (Session.User == null)
            {
                return GetLOVText(lovName, code, 1);
            }
            else
            {
                return GetLOVText(lovName, code, Session.User.LanguageCode);
            }
        }

        /// <summary>
        /// Returns the language specific text of a LOV or default text if translation doesn't exist
        /// </summary>
        /// <param name="lovName">Name of the LOV</param>
        /// <param name="code">Code of the LOV</param>
        /// <param name="languageCode">LanguageCode</param>
        /// <returns>LOV-Text as a string</returns>
        public static string GetLOVText(string lovName, int code, int languageCode)
        {
            return ExecuteScalarSQL(@"
                SELECT ISNULL(TXT.Text, LOV.Text)
                FROM dbo.XLOVCode         LOV WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = LOV.TextTID
                                                                    AND TXT.LanguageCode = {2}
                WHERE LOV.LOVName = CONVERT(VARCHAR(100), {0})
                  AND Code = {1}", lovName, code, languageCode) as string;
        }

        /// <summary>
        /// Some DB tables represent trees. They have a field, typically called ParentID, which references the primary key,
        /// thus forming a tree structure.
        /// This method will retrieve the entire branch to which a specified main node belongs. This means: All parent records
        /// up-the-line (but not entering other branches). Plus all children down-the-line (recursively following all side
        /// branches BELOW the main node).
        /// Implementation note: This method copies DataRows from one DataTable to another. To do so it does
        /// not refer to DataRow itself but to DataRow.ItemArray. This is because DataRow has a dependency on
        /// the DataTable where it belongs. Instead of entering the complexity of handling this (RowState etc.) we deal with
        /// the raw data by accessing DataRow.ItemArray.
        /// </summary>
        /// <param name="keyValue">This is the ID of the main node for which we want the branch. A primary key value</param>
        /// <param name="table">Name of the DB table that hosts the tree structure. Something like XReport</param>
        /// <param name="colID">Name of the primary key field</param>
        /// <param name="colParentID">Name of the field that contains the reference to the primary key of the parent record</param>
        /// <returns></returns>
        public static DataSet getTreeBranch(object keyValue, string table, string colID, string colParentID)
        {
            // Get TableFields without Timestamps
            string fieldNames = "";
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT name
                FROM syscolumns
                WHERE id = object_id({0})
                  AND xtype != 189
                ORDER BY colid", table);

            foreach (DataRow row in qry.DataTable.Rows)
            {
                if (fieldNames.Length > 0)
                {
                    fieldNames += ", ";
                }

                fieldNames += row["name"];
            }

            qry = DBUtil.OpenSQL(@"--SQLCHECK_IGNORE--
              SELECT " + fieldNames + " FROM " + table + " WHERE " + colID + "={0}", keyValue);

            if (qry.Count != 1)
            {
                if (qry.Count != 0)
                {
                    KissMsg.ShowError("DBUtil",
                                      "DatenFehlerhaft",
                                      "Fehlerhafte Daten entdeckt",
                                      string.Format("getTreeBranch() found {0} records in table {1} with supposed PK {2}={3}", qry.Count, table, colID, keyValue));
                }

                return null;
            }

            int sortKey = 0;
            int mainSortKey = sortKey;
            DataRow mainRow = qry.Row;

            SortedList aSortedList = new SortedList();
            aSortedList.Add(sortKey, qry.Row.ItemArray); // add main record (simply add ItemArray because DataRow still belongs to the original DataSet)

            // Up the hierarchy
            object parentID;

            while (DBNull.Value != (parentID = qry[colParentID]))
            {
                qry = DBUtil.OpenSQL(@"--SQLCHECK_IGNORE--
                    SELECT " + fieldNames + " FROM " + table + " WHERE " + colID + "={0}", parentID); // get parent

                if (qry.Count == 1)
                {
                    aSortedList.Add(--sortKey, qry.Row.ItemArray); // up the hierarchy: this is always a folder
                }
                else
                {
                    KissMsg.ShowError("DBUtil",
                                      "DatenFehlerhaft",
                                      "Fehlerhafte Daten entdeckt",
                                      string.Format("getTreeBranch() found {0} records in table {1} with supposed PK {2}={3}", qry.Count, table, colID, parentID));
                    return null;
                }
            }

            // Down the hierarchy
            sortKey = mainSortKey;
            try
            {
                getTreeBranchRecursivelyDown(mainRow[colID], table, fieldNames, colID, colParentID, ref sortKey, aSortedList);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("DBUtil", "DatenFehlerhaft", "Fehlerhafte Daten entdeckt", ex.Message);
                return null;
            }

            qry.DataTable.Rows.Clear(); // We reuse this DataTable because it contains the right columns etc.

            for (int i = 0; i < aSortedList.Count; ++i)
            {
                qry.DataTable.Rows.Add((object[])aSortedList.GetByIndex(i));
            }

            qry.DataTable.AcceptChanges();
            return qry.DataSet;
        }

        /// <summary>
        /// Get the value (amount/number/bit) the current user is permitted for a specific PermissionCode
        /// </summary>
        /// <param name="permissionCode">The permission code.</param>
        /// <param name="faLeistungID">The faLeistungID.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static object GetUserPermission(Permission permissionCode, int faLeistungID, object defaultValue)
        {
            return GetUserPermission(Convert.ToInt32(permissionCode), faLeistungID, defaultValue);
        }

        /// <summary>
        /// Get the value (amount/number/bit) the current user is permitted for a specific PermissionCode
        /// </summary>
        /// <param name="permissionCode">The permission code.</param>
        /// <param name="faLeistungID">The faLeistungID.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        [Obsolete]
        public static object GetUserPermission(int permissionCode, int faLeistungID, object defaultValue)
        {
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT VAL.Value
                FROM dbo.FaLeistung FAL WITH (READUNCOMMITTED)
                  INNER JOIN dbo.XUser            USR1 WITH (READUNCOMMITTED) ON USR1.UserID = FAL.UserID
                  INNER JOIN dbo.XUser            USR2 WITH (READUNCOMMITTED) ON USR2.UserID = {1}
                  INNER JOIN dbo.XPermissionValue VAL  WITH (READUNCOMMITTED) ON VAL.PermissionGroupID = CASE WHEN FAL.UserID = {1} THEN USR2.PermissionGroupID
                                                                                                              ELSE USR2.GrantPermGroupID
                                                                                                         END
                                                                             AND VAL.PermissionCode = {2}
                WHERE FAL.FaLeistungID = {0}", faLeistungID, Session.User.UserID, permissionCode);

            if (qry.Count == 0 || DBUtil.IsEmpty(qry["Value"]))
            {
                return defaultValue;
            }
            else
            {
                return qry["Value"];
            }
        }

        /// <summary>
        /// Get the highest amount the current user is permitted to enter a specific SIL
        /// </summary>
        public static object GetUserSilPermission(int bgPositionsartID, int faLeistungID)
        {
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT VAL.Value
                FROM dbo.FaLeistung FAL WITH (READUNCOMMITTED)
                  INNER JOIN dbo.XUser            USR1 WITH (READUNCOMMITTED) ON USR1.UserID = FAL.UserID
                  INNER JOIN dbo.XUser            USR2 WITH (READUNCOMMITTED) ON USR2.UserID = {1}
                  INNER JOIN dbo.XPermissionValue VAL  WITH (READUNCOMMITTED) ON VAL.PermissionGroupID = CASE WHEN FAL.UserID = {1} THEN USR2.PermissionGroupID
                                                                                                              ELSE USR2.GrantPermGroupID
                                                                                                         END
                                                                             AND VAL.BgPositionsartID = {2}
                WHERE FAL.FaLeistungID = {0}", faLeistungID, Session.User.UserID, bgPositionsartID);

            if (qry.Count == 0 || DBUtil.IsEmpty(qry["Value"]))
            {
                return 0;
            }
            else
            {
                return qry["Value"];
            }
        }

        /// <summary>
        /// Test for an emtpy field.
        /// </summary>
        public static bool IsEmpty(object value)
        {
            return Normalized(value) == DBNull.Value;
        }

        /// <summary>
        /// Create new entry in HistoryVerion Table
        /// </summary>
        /// <returns>HistoryID</returns>
        public static object NewHistoryVersion()
        {
            if (!Session.Active)
            {
                return null;
            }

            return ExecuteScalarSQL(@"
                INSERT INTO dbo.HistoryVersion (AppUser)
                VALUES ({0})

                SELECT SCOPE_IDENTITY()", Session.User.LogonName);
        }

        /// <summary>
        /// Normalization of a value used in a data row.
        /// </summary>
        public static object Normalized(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else if (value is string)
            {
                string s = Convert.ToString(value);
                s = s.Trim();

                if (s.Length == 0)
                {
                    return DBNull.Value;
                }
                else if (s != Convert.ToString(value))
                {
                    return s;
                }
            }
            else if (value is DateTime)
            {
                if ((DateTime)value < SqlDateTime.MinValue.Value)
                {
                    return SqlDateTime.MinValue.Value;
                }

                //SqlDateTime.MaxValue.Value == DateTime.MaxValue
            }

            return value;
        }

        /// <summary>
        /// Create a new <see cref="SqlQuery"/> and call Fill() with the specified selectStatement and selectParameters.
        /// </summary>
        public static SqlQuery OpenSQL(string selectStatement, params object[] selectParameters)
        {
            SqlQuery qry = new SqlQuery();
            qry.Fill(selectStatement, selectParameters);
            return qry;
        }

        /// <summary>
        /// Executes the specified Statement against the current db-connection. returns SQLDataReader
        /// </summary>
        /// <param name="sqlStatement">Selectstatment</param>
        /// <param name="sqlParameters">Parameter of Selectstatment</param>
        /// <returns>SQLDataReader</returns>
        public static SqlDataReader OpenSQLReader(string sqlStatement, params object[] sqlParameters)
        {
            return CreateSqlCommand(sqlStatement, sqlParameters).ExecuteReader();
        }

        /// <summary>
        /// Create a new <see cref="SqlQuery"/>, set the FillTimeOut and call Fill() with the specified selectStatement and selectParameters.
        /// </summary>
        /// <param name="selectStatement">The Select-Statement to be executed.</param>
        /// <param name="timeout">The timeout to fill the SqlQuery.</param>
        /// <param name="selectParameters">The parameters for the Select-Statement</param>
        /// <returns></returns>
        public static SqlQuery OpenSQLWithTimeout(string selectStatement, int timeout, params object[] selectParameters)
        {
            SqlQuery qry = new SqlQuery();
            qry.FillTimeOut = timeout;
            qry.Fill(selectStatement, selectParameters);
            return qry;
        }

        /// <summary>
        /// Sets user identification of actual modification of an end-user
        /// </summary>
        /// <param name="qry">The SqlQuery to be edited</param>
        public static void SetEditUser(KiSS4.DB.SqlQuery qry)
        {
            try
            {
                DateTime now = DateTime.Now;

                if (qry.Row.RowState == DataRowState.Added)
                {
                    // User bei neuen Datensätzen setzen:
                    qry["ErstelltUserID"] = Session.User.UserID;
                    qry["ErstelltDatum"] = now;
                }

                // Mutiertrender User immer setzen:
                // muss auch bei neuen Zeilen gesetzt werden,
                // da dies auf der DB Muss-Flelder sind:
                qry["MutiertUserID"] = Session.User.UserID;
                qry["MutiertDatum"] = now;
            }
            catch
            {
            }
        }

        /// <summary>
        /// Convert a value to a literal that can be used in a query.
        /// </summary>
        public static string SqlLiteral(object value)
        {
            return SqlLiteral(value, false);
        }

        /// <summary>
        /// convert a value to an sql literal.
        /// </summary>
        public static string SqlLiteral(object value, bool useInSP)
        {
            string ret;

            if (value == null)
            {
                ret = " null ";
            }
            else if (value == DBNull.Value)
            {
                ret = " null ";
            }
            else if (value is string)
            {
                ret = " N'" + Convert.ToString(value).Replace("'", "''") + "' ";
            }
            else if (value is bool)
            {
                ret = Convert.ToBoolean(value) ? " 1 " : " 0 ";
            }
            else if (value is DateTime)
            {
                DateTime dt = Convert.ToDateTime(value);

                if (useInSP)
                {
                    if (dt == dt.Date)
                    {
                        ret = "'" + dt.ToString("yyyyMMdd") + "'";
                    }
                    else
                    {
                        ret = "'" + dt.ToString("yyyyMMdd HH:mm:ss") + "'";
                    }
                }
                else
                {
                    if (dt == dt.Date)
                    {
                        ret = " CONVERT(DATETIME, '" + dt.ToString("dd.MM.yyyy") + "', 104) ";
                    }
                    else
                    {
                        ret = " CONVERT(DATETIME, '" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "', 120) ";
                    }
                }
            }
            else if (value is byte ||
                     value is short ||
                     value is int ||
                     value is long ||
                     value is float ||
                     value is double ||
                     value is decimal)
            {
                ret = ((IFormattable)value).ToString(null, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (value is byte[])
            {
                byte[] ba = (byte[])value;
                char[] charArray = new string(' ', ba.Length * 2).ToCharArray();

                for (int i = 0; i < ba.Length; i++)
                {
                    ba[i].ToString("x2").CopyTo(0, charArray, i * 2, 2);
                }

                ret = " 0x" + new string(charArray) + " ";
            }
            else if (value is Guid)
            {
                ret = " '" + ((Guid)value).ToString() + "' ";
            }
            else if (value is Enum)
            {
                int intval = (int)value;
                ret = ((IFormattable)intval).ToString(null, System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                //#7224 Fehlermeldung verbessert, dass man den Typ kennt.
                string typeName = value.GetType().FullName;
                throw new ArgumentException(string.Format("Unsupported data type: {0}", typeName));
            }

            return ret;
        }

        /// <summary>
        /// Convert a value to a literal that can be used in a search query.
        /// Replaces '*' by '%' and '?' by '_'
        /// </summary>
        public static string SqlLiteralLike(object value)
        {
            return SqlLiteralLike(value, false);
        }

        /// <summary>
        /// Convert a value to a literal that can be used in a search query.
        /// Replaces '*' by '%' and '?' by '_'
        /// </summary>
        public static string SqlLiteralLike(object value, bool useInSP)
        {
            if (value is string)
            {
                value = value.ToString().Replace("*", "%").Replace("?", "_");
            }

            return SqlLiteral(value, useInSP);
        }

        /// <summary>
        /// If open transactions exists, they are rolled back and an Exception is thrown. If there are no open connections, no operation will be performed.
        /// This function should be used to check for open transactions before making critical changes like creating a 'Buchung' or 'Barbeleg'.
        /// </summary>
        public static void ThrowExceptionOnOpenTransaction()
        {
            // Check for transactions opened through the session class
            if (Session.Transaction != null)
            {
                // Advantages of a commit:
                // - no work gets lost
                // Advantages of a rollback:
                // - an open transaction means an error has occured that wasn't handled correctly, the committed data may be nonsense
                // - I assume that it is likelier for a commit to fall into a timeout than for a rollback
                string stackTrace = Session.TransactionStackTrace == null ? string.Empty : Session.TransactionStackTrace;
                try
                {
                    Session.Rollback();
                }
                catch (Exception ex)
                {
                    // Eintrag ins Log.
                    LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", "KiSS4.DB.DBUtil", ex.Message);

                    XLog.Create(TYPEFULLNAME, 3, LogLevel.ERROR, "Open Transaction Error", "Session.Rollback() fehlgeschlagen", string.Empty, -1);
                }

                XLog.Create(TYPEFULLNAME, 0, LogLevel.ERROR, "Open Transaction Error", string.Format("opened through Session.BeginTransaction, SessionID {0}, Stacktrace: {1}", DBUtil.ExecuteScalarSQL("SELECT @@SPID"), stackTrace), string.Empty, -1);
                string msg = KissMsg.GetMLMessage("DBUtil", "OpenTransactionError", "Aufgrund eines Transaktions-Fehlers wurden eventuell nicht alle Daten gespeichert. Bitte überprüfen sie ihre kürzlich ausgeführten Arbeiten.");

                throw new KissErrorException(msg);
            }
            // Check the number of open transactions on the database
            int nrOfOpenTransactions = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException("SELECT @@TRANCOUNT"));

            if (nrOfOpenTransactions > 0)
            {
                // One Rollback or one commit per open transaction
                DBUtil.ExecSQLThrowingException("Rollback");

                //for (int t = 0; t < nrOfOpenTransactions; t++)
                //{
                //    DBUtil.ExecSQLThrowingException("Commit");
                //}

                if ((int)DBUtil.ExecuteScalarSQLThrowingException("SELECT @@TRANCOUNT") > 0)
                {
                    XLog.Create(TYPEFULLNAME, 2, LogLevel.ERROR, "Open Transaction Error - Can't close open transactions", string.Empty, string.Empty, -1);
                }

                XLog.Create(TYPEFULLNAME,
                            1,
                            LogLevel.ERROR,
                            "Open Transaction Error",
                            string.Format("SessionID {0}, nr. of open transactions: {1}", DBUtil.ExecuteScalarSQL("SELECT @@SPID"), nrOfOpenTransactions),
                            string.Empty,
                            -1);

                string msg = KissMsg.GetMLMessage("DBUtil", "OpenTransactionError", "Aufgrund eines Transaktions-Fehlers wurden eventuell nicht alle Daten gespeichert. Bitte überprüfen sie ihre kürzlich ausgeführten Arbeiten.");

                throw new KissErrorException(msg);
            }
        }

        /// <summary>
        /// Determine if the user has a specific right.
        /// </summary>
        /// <param name="rightName">RightName or ClassName</param>
        /// <returns></returns>
        public static bool UserHasRight(string rightName)
        {
            return UserHasRight(rightName, "");
        }

        /// <summary>
        /// Determine if the user has a specific right and sub right.
        /// </summary>
        /// <param name="rightName">RightName or ClassName</param>
        /// <param name="subRights">Required Rights: I - Insert, U - Update, D - Delete</param>
        /// <returns></returns>
        public static bool UserHasRight(string rightName, string subRights)
        {
            bool mayRead;
            bool mayInsert;
            bool mayUpdate;
            bool mayDelete;

            Session.GetUserRight(rightName, out mayRead, out mayInsert, out mayUpdate, out mayDelete);

            if (!mayRead)
            {
                return false;
            }
            else
                for (int i = 0; i < subRights.Length; i++)
                {
                    switch (subRights.ToUpper()[i])
                    {
                        case 'I':
                            if (!mayInsert)
                            {
                                return false;
                            }
                            break;

                        case 'U':
                            if (!mayUpdate)
                            {
                                return false;
                            }
                            break;

                        case 'D':
                            if (!mayDelete)
                            {
                                return false;
                            }
                            break;

                        default:
                            return false;
                    }
                }
            return true;
        }

        #endregion

        #region Internal Static Methods

        internal static SqlCommand CreateSqlCommand(string sqlStatement, params object[] sqlParameters)
        {
            SqlCommand cmd;

            if (sqlParameters != null)
            { // replace parameter placeholders
                Regex rgxParams = new Regex(@"{(?<nr>\d+)}");   // eg: where fieldA = {0} and fieldB = {1}
                string sql = sqlStatement;
                BitArray ba = new BitArray(sqlParameters.Length, false); // contains a bit for each parameter index used

                int offset = 0;

                MatchCollection matches = rgxParams.Matches(sql);
                foreach (Match m in matches)
                {
                    // replace a parameter placeholder with @pN and and the bit to ba
                    try
                    {
                        int nr = int.Parse(m.Groups["nr"].Captures[0].Value);
                        string paramName = Normalized(sqlParameters[nr]) == DBNull.Value ? "NULL" : "@p" + nr;

                        sql = sql.Substring(0, m.Index + offset) + paramName + sql.Substring(m.Index + offset + m.Length);
                        offset += paramName.Length - m.Length;
                        ba[nr] = true;
                    }
                    catch (Exception ex)
                    {
                        if (System.Diagnostics.Debugger.IsAttached)
                        {
                            System.Diagnostics.Debugger.Break();
                        }
                        LOG.Error("Fehler beim Erstellen des SQL-Befehls", ex);
                    }
                }

                cmd = new SqlCommand(sql, Session.Connection);

                for (int i = 0; i < sqlParameters.Length; i++)
                {
                    if (ba[i])
                    {
                        cmd.Parameters.AddWithValue("@p" + i, Normalized(sqlParameters[i]));
                    }
                }
            }
            else
            {
                cmd = new SqlCommand(sqlStatement, Session.Connection);
            }

            if (Session.Transaction != null)
            {
                cmd.Transaction = Session.Transaction;
            }

            return cmd;
        }

        internal static string SqlCommandToString(SqlCommand sqlCommand)
        {
            string strSqlParam = "";

            foreach (SqlParameter sqlParam in sqlCommand.Parameters)
            {
                if (strSqlParam.Length > 0)
                {
                    strSqlParam = strSqlParam + ", ";
                }

                strSqlParam = strSqlParam + sqlParam.ParameterName + "=" + DBUtil.SqlLiteral(sqlParam.Value);
            }

            if (strSqlParam.Length > 0)
            {
                strSqlParam = sqlCommand.CommandText + Environment.NewLine + Environment.NewLine + strSqlParam;
            }
            else
            {
                strSqlParam = sqlCommand.CommandText;
            }

            do
            {
                strSqlParam = strSqlParam.Replace("\r\n\t", "\r\n");
            } while (strSqlParam.StartsWith("\r\n\t"));

            return strSqlParam;
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Help method for getTreeBranch. Recursively drills down starting at parentID and adds records found
        /// to aSortedList.
        /// </summary>
        /// <param name="parentID">starting point for drill-down</param>
        /// <param name="table">Name of the DB table that hosts the tree structure</param>
        /// <param name="fieldNames">Comma seperated List of Columns</param>
        /// <param name="colID">Name of the primary key field</param>
        /// <param name="colParentID">Name of the field that contains the reference to the primary key of the parent record</param>
        /// <param name="sortKey">current key for sort order (passed by ref)</param>
        /// <param name="aSortedList">Data structure for collecting all records found</param>
        private static void getTreeBranchRecursivelyDown(object parentID, string table, string fieldNames, string colID, string colParentID, ref int sortKey, SortedList aSortedList)
        {
            SqlQuery qry = DBUtil.OpenSQL(@"--SQLCHECK_IGNORE--
                SELECT " + fieldNames + " FROM " + table + " WHERE " + colParentID + "={0}", parentID);

            if (qry.Count == 0)
            {
                return;
            }

            foreach (DataRow row in qry.DataTable.Rows)
            {
                aSortedList.Add(++sortKey, row.ItemArray);
            }

            foreach (DataRow row in qry.DataTable.Rows)
            {
                getTreeBranchRecursivelyDown(row[colID], table, fieldNames, colID, colParentID, ref sortKey, aSortedList);
            }
        }

        private static Exception HandleSqlError(SqlException eSQL, SqlCommand cmd)
        {
            if (eSQL.Number == 50000)
            {
                return new KissInfoException(eSQL.Message, eSQL);
            }
            else if (Session.Transaction == null) // Transaction are not handled by user code
            {
                try
                {
                    cmd = CreateSqlCommand("SELECT @@TRANCOUNT");
                    int nrOfOpenTransactions = Convert.ToInt32(cmd.ExecuteScalar());

                    if (eSQL.Number == -2 && nrOfOpenTransactions > 0) // timeout and open transactions
                    {
                        // open transactions exists: most likely a transaction was started in a stored procedure, but after a timeout the SQL-catch block won't get executed
                        cmd = CreateSqlCommand("ROLLBACK");
                        cmd.ExecuteNonQuery();
                    }
                    else if (nrOfOpenTransactions > 0) // no timeout, but open transactions
                    {
                        // Shouldn't happen, I guess. Let's log it!
                        XLog.Create(TYPEFULLNAME, 6, LogLevel.WARN, "Open transaction after SQL-Error", eSQL.Message, string.Empty, -1);
                    }

                    if (eSQL.Number == 547)
                    {
                        //constraint violation
                        return new KissErrorException(KissMsg.GetMLMessage(
                            "DBUtil", "DatensatzReferenziert",
                            "Die erwünschte Aktion konnte nicht durchgeführt werden, da noch referenzierte Daten vorhanden sind. Bitte vorher bereinigen.", KissMsgCode.MsgError),
                            eSQL);
                    }
                }
                catch (Exception ex)
                {
                    XLog.Create(TYPEFULLNAME, 5, LogLevel.ERROR, "Counting transactions or rolling them back failed.", ex.Message, string.Empty, -1);
                }
            }
            return new KissErrorException(eSQL.Message, DBUtil.SqlCommandToString(cmd), eSQL);
        }

        /// <summary>
        /// Tries to parse a <see cref="string"/> to a list of <see cref="Keys"/>
        /// </summary>
        /// <param name="shortcutString"><see cref="string"/> to parse. Keys are separeted with '+'</param>
        /// <param name="keyEventArgs">Output list of <see cref="Keys"/> that has been parsed</param>
        /// <returns>true if the <see cref="shortcutString"/> has succesfully been parsed, else false</returns>
        private static bool TryParseKeys(string shortcutString, out KeyEventArgs keyEventArgs)
        {
            var shortcut = shortcutString.ToUpper().Replace("CTRL", "CONTROL").Split('+');

            var keys = new Keys();

            foreach (var keyString in shortcut)
            {
                Keys key;
                if (Enum.TryParse(keyString, true, out key))
                {
                    keys = keys | key;
                }
                else
                {
                    keyEventArgs = new KeyEventArgs(Keys.None);
                    return false;
                }
            }

            keyEventArgs = new KeyEventArgs(keys);

            return true;
        }

        #endregion

        #endregion
    }
}