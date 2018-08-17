using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Common.Logging;

namespace KiSS.Common.Logging
{
    /// <summary>
    /// Class to extend the <see cref="ILog"/> interface
    /// </summary>
    public static class LogExtension
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Adds an Audit Info to the log with the name of the calling method and the object
        /// </summary>
        /// <param name="log">The <see cref="ILog"/> to be extended</param>
        /// <param name="obj">The object to log</param>
        public static void AuditInfo(this ILog log, object obj)
        {
            StackFrame stackFrame = new StackFrame(1, false);
            log.Info(stackFrame.GetMethod().Name + " " + obj);
        }

        #endregion

        #endregion
    }
}