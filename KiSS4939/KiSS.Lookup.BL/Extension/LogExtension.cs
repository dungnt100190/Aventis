using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autofac;

using KiSS.Lookup.BL.DTO;
using KiSS.Lookup.DA;


namespace KiSS.Lookup.BL.Extension
{
    /// <summary>
    /// Extension to the <see cref="Log"/> class
    /// </summary>
    static class LogExtension
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Look if the two logs are different
        /// </summary>
        /// <param name="dbLog">The first log (<see cref="XLog"/>)</param>
        /// <param name="log">The second log (<see cref="Log"/>)</param>
        /// <returns>True if the two logs are different</returns>
        public static bool IsDifferent(this XLog dbLog, Log log)
        {
            if (dbLog.XLogID != log.ID)
                return true;
            if (dbLog.Source != log.Source)
                return true;
            if (dbLog.SourceKey != log.SourceKey)
                return true;
            if (dbLog.XLogLevelCode != log.Level)
                return true;
            if (dbLog.Message != log.Message)
                return true;
            if (dbLog.Comment != log.Comment)
                return true;
            if (dbLog.ReferenceTable != log.ReferenceTable)
                return true;
            if (dbLog.ReferenceID != log.ReferenceID)
                return true;
            if (dbLog.NonPurgeable != log.NonPurgeable)
                return true;
            if (dbLog.Creator!= log.Creator)
                return true;
            if (dbLog.Created != log.Created)
                return true;
            if (dbLog.Modifier!= log.Modifier)
                return true;
            if (dbLog.Modified != log.Modified)
                return true;
            return false;
        }

        /// <summary>
        /// Set the value of a <see cref="XLog"/> with the ones from a <see cref="Log"/>
        /// </summary>
        /// <param name="dbLog">The Entity to set</param>
        /// <param name="log">The transfer object to get the value from</param>
        public static void Set(this XLog dbLog, Log log)
        {
            dbLog.Source = log.Source;
            dbLog.SourceKey = log.SourceKey;
            dbLog.XLogLevelCode = log.Level;
            dbLog.Message = log.Message;
            dbLog.Comment = log.Comment;
            dbLog.ReferenceTable = log.ReferenceTable;
            dbLog.ReferenceID = log.ReferenceID;
            dbLog.NonPurgeable = log.NonPurgeable;
            dbLog.Creator = log.Creator;
            dbLog.Created = log.Created;
            dbLog.Modifier = log.Modifier;
            dbLog.Modified = log.Modified;
        }

        /// <summary>
        /// Set the value of a <see cref="Log"/> with the ones from a <see cref="XLog"/>
        /// </summary>
        /// <param name="log">The Entity to set</param>
        /// <param name="dbLog">The transfer object to get the value from</param>
        public static void Set(this Log log, XLog dbLog)
        {
            log.Source = dbLog.Source;
            log.SourceKey = dbLog.SourceKey;
            log.Level = dbLog.XLogLevelCode;
            log.Message = dbLog.Message;
            log.Comment = dbLog.Comment;
            log.ReferenceTable = dbLog.ReferenceTable;
            log.ReferenceID = dbLog.ReferenceID;
            log.NonPurgeable = dbLog.NonPurgeable;
            log.Creator = dbLog.Creator;
            log.Created = dbLog.Created;
            log.Modifier = dbLog.Modifier;
            log.Modified = dbLog.Modified;
        }

        /// <summary>
        /// Converts the <see cref="XLog"/> to <see cref="Log"/>
        /// </summary>
        /// <param name="xLog">log to convert</param>
        /// <returns>Converted <see cref="Log"/></returns>
        public static Log ToLog(this XLog xLog)
        {
            Log log = new Log();
            log.Set(xLog);
            return log;
        }

        /// <summary>
        /// Gets the result from <see cref="IQueryable<XLog>"/> as a <see cref="List<Log>"/>
        /// </summary>
        /// <param name="query">query to convert</param>
        /// <returns><see cref="List<Log>"/></returns>
        public static List<Log> ToLogList(this IQueryable<XLog> query)
        {
            List<Log> lst = new List<Log>();

            foreach (var result in query)
                lst.Add(result.ToLog());

            return lst;
        }

        #endregion

        #endregion
    }
}