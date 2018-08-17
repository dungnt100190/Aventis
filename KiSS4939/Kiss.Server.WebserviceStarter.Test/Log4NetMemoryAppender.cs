using System.Collections.Generic;

using log4net.Appender;
using log4net.Core;

namespace Kiss.Server.WebserviceStarter.Test
{
    public class Log4NetMemoryAppender : AppenderSkeleton
    {
        public Log4NetMemoryAppender()
        {
            Log = new List<LoggingEvent>();
        }

        public IList<LoggingEvent> Log
        {
            get;
            private set;
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            Log.Add(loggingEvent);
        }
    }
}