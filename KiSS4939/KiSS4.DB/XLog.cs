using System;
using System.Diagnostics;

namespace KiSS4.DB
{
    #region Enumerations

    /// <summary>
    /// Log level enum
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Debug level, used only debug information
        /// </summary>
        DEBUG = 1,

        /// <summary>
        /// Info level, used for common information
        /// </summary>
        INFO = 2,

        /// <summary>
        /// Warn level, used for important warnings
        /// </summary>
        WARN = 3,

        /// <summary>
        /// Error level, used for occured errors
        /// </summary>
        ERROR = 4,

        /// <summary>
        /// Fatal level, used for fatal errors
        /// </summary>
        FATAL = 5
    }

    #endregion

    /// <summary>
    /// Class to create new log entries
    /// </summary>
    public class XLog
    {
        #region Fields

        #region Private Static Fields

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Create a new log entry for current user (for current user)
        /// </summary>
        /// <param name="source">Namespace of class including classname as: NameSpace.ClassName</param>
        /// <param name="level">The level of the log entry</param>
        /// <param name="message">The message of the log entry</param>
        public static void Create(string source, LogLevel level, string message)
        {
            // call create with additional default parameter
            Create(source, level, message, null);
        }

        /// <summary>
        /// Create a new log entry for current user (for current user)
        /// </summary>
        /// <param name="source">Namespace of class including classname as: NameSpace.ClassName</param>
        /// <param name="level">The level of the log entry</param>
        /// <param name="message">The message of the log entry</param>
        /// <param name="comment">The additional comment of the log entry</param>
        public static void Create(string source, LogLevel level, string message, string comment)
        {
            // call create with additional default parameter
            Create(source, level, message, comment, Session.User.UserID);
        }

        /// <summary>
        /// Create a new log entry
        /// </summary>
        /// <param name="source">Namespace of class including classname as: NameSpace.ClassName</param>
        /// <param name="level">The level of the log entry</param>
        /// <param name="message">The message of the log entry</param>
        /// <param name="userID">The userID of the user who creates the log entry</param>
        public static void Create(string source, LogLevel level, string message, int userID)
        {
            // call create with additional default parameter
            Create(source, level, message, null, userID);
        }

        /// <summary>
        /// Create a new log entry
        /// </summary>
        /// <param name="source">Namespace of class including classname as: NameSpace.ClassName</param>
        /// <param name="level">The level of the log entry</param>
        /// <param name="message">The message of the log entry</param>
        /// <param name="comment">The additional comment of the log entry</param>
        /// <param name="userID">The userID of the user who creates the log entry</param>
        public static void Create(string source, LogLevel level, string message, string comment, int userID)
        {
            // call final create with additional default parameter
            Create(source, -1, level, message, comment, null, -1, userID);
        }

        /// <summary>
        /// Create a new log entry (for current user)
        /// </summary>
        /// <param name="source">Namespace of class including classname as: NameSpace.ClassName</param>
        /// <param name="level">The level of the log entry</param>
        /// <param name="message">The message of the log entry</param>
        /// <param name="comment">The additional comment of the log entry</param>
        /// <param name="refTable">The with the log-event referenced table</param>
        /// <param name="refID">The with the log-event referenced primarykey id within the referenced table (if smaller than 1, entry will be NULL)</param>
        public static void Create(string source, LogLevel level, string message, string comment, string refTable, int refID)
        {
            // call create with additional default parameter
            Create(source, -1, level, message, comment, refTable, refID);
        }

        /// <summary>
        /// Create a new log entry (for current user)
        /// </summary>
        /// <param name="source">Namespace of class including classname as: NameSpace.ClassName</param>
        /// <param name="sourceKey">The key within the source to identify specific log-event within source (if smaller than 0, entry will be NULL)</param>
        /// <param name="level">The level of the log entry</param>
        /// <param name="message">The message of the log entry</param>
        /// <param name="comment">The additional comment of the log entry</param>
        /// <param name="refTable">The with the log-event referenced table</param>
        /// <param name="refID">The with the log-event referenced primarykey id within the referenced table (if smaller than 1, entry will be NULL)</param>
        public static void Create(string source, int sourceKey, LogLevel level, string message, string comment, string refTable, int refID)
        {
            // call create with additional default parameter
            Create(source, sourceKey, level, message, comment, refTable, refID, false);
        }

        /// <summary>
        /// Create a new log entry (for current user)
        /// </summary>
        /// <param name="source">Namespace of class including classname as: NameSpace.ClassName</param>
        /// <param name="sourceKey">The key within the source to identify specific log-event within source (if smaller than 0, entry will be NULL)</param>
        /// <param name="level">The level of the log entry</param>
        /// <param name="message">The message of the log entry</param>
        /// <param name="comment">The additional comment of the log entry</param>
        /// <param name="refTable">The with the log-event referenced table</param>
        /// <param name="refID">The with the log-event referenced primarykey id within the referenced table (if smaller than 1, entry will be NULL)</param>
        /// <param name="nonPurgeable"><c>True</c> if entry shall not be removed when purging the table, <c>False</c> if entry can be removed after a certain amout of time</param>
        public static void Create(string source, int sourceKey, LogLevel level, string message, string comment, string refTable, int refID, bool nonPurgeable)
        {
            // call create with additional default parameter
            Create(source, sourceKey, level, message, comment, refTable, refID, nonPurgeable, Session.User.UserID);
        }

        /// <summary>
        /// Create a new log entry
        /// </summary>
        /// <param name="source">Namespace of class including classname as: NameSpace.ClassName</param>
        /// <param name="sourceKey">The key within the source to identify specific log-event within source (if smaller than 0, entry will be NULL)</param>
        /// <param name="level">The level of the log entry</param>
        /// <param name="message">The message of the log entry</param>
        /// <param name="comment">The additional comment of the log entry</param>
        /// <param name="refTable">The with the log-event referenced table</param>
        /// <param name="refID">The with the log-event referenced primarykey id within the referenced table (if smaller than 1, entry will be NULL)</param>
        /// <param name="userID">The userID of the user who creates the log entry</param>
        public static void Create(string source, int sourceKey, LogLevel level, string message, string comment, string refTable, int refID, int userID)
        {
            // call final create with additional default parameter
            Create(source, sourceKey, level, message, comment, refTable, refID, false, userID);
        }

        /// <summary>
        /// Create a new log entry (all parameters)
        /// </summary>
        /// <param name="source">Namespace of class including classname as: NameSpace.ClassName</param>
        /// <param name="sourceKey">The key within the source to identify specific log-event within source (if smaller than 0, entry will be NULL)</param>
        /// <param name="level">The level of the log entry</param>
        /// <param name="message">The message of the log entry</param>
        /// <param name="comment">The additional comment of the log entry</param>
        /// <param name="refTable">The with the log-event referenced table</param>
        /// <param name="refID">The with the log-event referenced primarykey id within the referenced table (if smaller than 1, entry will be NULL)</param>
        /// <param name="nonPurgeable"><c>True</c> if entry shall not be removed when purging the table, <c>False</c> if entry can be removed after a certain amout of time</param>
        /// <param name="userID">The userID of the user who creates the log entry</param>
        public static void Create(
            string source,
            int sourceKey,
            LogLevel level,
            string message,
            string comment,
            string refTable,
            int refID,
            bool nonPurgeable,
            int userID)
        {
            // validate values
            if (string.IsNullOrEmpty(source))
            {
                // invalid source
                throw new ArgumentNullException("source");
            }

            if (string.IsNullOrEmpty(message))
            {
                // invalid message
                throw new ArgumentNullException("message");
            }

            // get creator as given user
            string creator = DBUtil.GetDBRowCreatorModifier(userID);

            if (string.IsNullOrEmpty(creator))
            {
                // invalid creator
                throw new ArgumentNullException("creator");
            }

            // try to create new log-entry
            DBUtil.ExecuteScalarSQLThrowingException(@"
                INSERT INTO dbo.XLog (Source, SourceKey, XLogLevelCode, Message, Comment, ReferenceTable, ReferenceID, NonPurgeable, Creator, Modifier)
                VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {8})",
                source,                                         // 0 = Source
                (sourceKey < 0 ? null : (object)sourceKey),     // 1 = SourceKey
                Convert.ToInt32(level),                         // 2 = XLogLevelCode
                message,                                        // 3 = Message
                comment,                                        // 4 = Comment
                refTable,                                       // 5 = ReferenceTable
                (refID < 1 ? null : (object)refID),             // 6 = ReferenceID
                nonPurgeable,                                   // 7 = NonPurgeable
                creator);                                       // 8 = Creator, Modifier
        }

        #endregion

        #region Internal Static Methods

        /// <summary>
        /// Clears all cached values by XLog (currently only one Config-Value)
        /// </summary>
        internal static void ClearCachedValues()
        {
        }

        /// <summary>
        /// Creates a log entry if the transaction runs for long time
        /// </summary>
        /// <param name="source">Namespace of class including classname as: NameSpace.ClassName</param>
        /// <param name="sourceKey">The key within the source to identify specific log-event within source (if smaller than 0, entry will be NULL)</param>
        /// <param name="stackTrace">The stacktrace to log</param>
        /// <param name="startTime">Start time of the transaction</param>
        /// <param name="stopTime">End time of the transaction</param>
        internal static void CreateTransactionLog(
            string source,
            int sourceKey,
            StackTrace stackTrace,
            DateTime startTime,
            DateTime stopTime)
        {
            int logTransactionsLongerThan = DBUtil.GetConfigInt(@"System\Logging\LogTransactionsLongerThan", int.MaxValue);

            try
            {
                TimeSpan timeDifference = stopTime.Subtract(startTime);

                if (timeDifference.TotalSeconds >= logTransactionsLongerThan && Session.User != null)
                {
                    XLog.Create(source, sourceKey, LogLevel.DEBUG, stackTrace.ToString(), string.Format("{0:000000.00}", timeDifference.TotalSeconds), null, -1);
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        #endregion

        #region Private Static Methods

        private static string convertObjectArrayToString(object[] objectArray)
        {
            if (objectArray == null)
            {
                return string.Empty;
            }
            System.Collections.Generic.List<string> stringList = new System.Collections.Generic.List<string>();

            foreach (object param in objectArray)
            {
                stringList.Add(param == null ? "NULL" : param.ToString());
            }

            return string.Join(",", stringList.ToArray());
        }

        #endregion

        #endregion
    }
}