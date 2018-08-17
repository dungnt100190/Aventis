using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS.Lookup.BL.DTO
{
    /// <summary>
    /// Class to manage the XLog
    /// </summary>
    public class Log
    {
        #region Constructors

        /// <summary>
        /// Initializes a <see cref="Log"/> object
        /// </summary>
        public Log()
        {
        }

        /// <summary>
        /// Initializes a <see cref="Log"/> object
        /// </summary>
        /// <param name="source">source with namespace</param>
        /// <param name="level">log level code</param>
        /// <param name="message">message</param>
        /// <param name="user">user that create the log</param>
        public Log(string source, LogLevel level, string message, string user)
            :this(source, level, message, user, false)
        {   

        }

        public Log(string source, LogLevel level, string message, string user, bool nonPurgeable)
        {
            Source = source;
            Level = (int)level;
            Message = message;
            Creator = user;
            Modifier = user;
            Created = DateTime.Now;
            Modified = DateTime.Now;
            NonPurgeable = nonPurgeable;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Zusätzlicher Kommentar zum Log-Eintrag
        /// </summary>
        public string Comment
        {
            get;
            set;
        }

        /// <summary>
        /// Wann der Log erstellt wurde
        /// </summary>
        public DateTime Created
        {
            get;
            set;
        }

        /// <summary>
        /// Benutzer den das Log erstellt hat
        /// </summary>
        public string Creator
        {
            get;
            set;
        }

        /// <summary>
        /// Log ID
        /// </summary>
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// Log-Level
        /// </summary>
        public int Level
        {
            get;
            set;
        }

        /// <summary>
        /// Log-Nachricht (z.B. Fehlermeldung)
        /// </summary>
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// Wann der Log zuletzt geändert wurde
        /// </summary>
        public DateTime Modified
        {
            get;
            set;
        }

        /// <summary>
        /// Benutzer, welcher den Log zuletzt geändert hat
        /// </summary>
        public string Modifier
        {
            get;
            set;
        }

        /// <summary>
        /// Flag, ob ein Eintrag beim Säubern gelöscht werden darf (=0) oder erhalten bleiben soll (=1)
        /// </summary>
        public bool NonPurgeable
        {
            get;
            set;
        }

        /// <summary>
        /// Eindeutiger Schlüssel (PK) innerhalb der ReferenceTable. Diese ID ist z.B. beim Erzeugen eines neuen Logeintrags betroffen.
        /// </summary>
        public int? ReferenceID
        {
            get;
            set;
        }

        /// <summary>
        /// Name der zum Logeintrag referenzierten Tabelle, welche zusammen mit ReferenceKey den betroffenen Datensatz beschreibt
        /// </summary>
        public string ReferenceTable
        {
            get;
            set;
        }

        /// <summary>
        /// Herkunft des Log-Eintrags: Namespace.Klassenname
        /// </summary>
        public string Source
        {
            get;
            set;
        }

        /// <summary>
        /// Zusätzlicher, optionaler Code innerhalb der Source. 
        /// Dieser kann z.B. für Auswertungen eines bestimmten Typs aus gegebener Source verwendet werden.
        /// </summary>
        public int? SourceKey
        {
            get;
            set;
        }

        #endregion
    }
}