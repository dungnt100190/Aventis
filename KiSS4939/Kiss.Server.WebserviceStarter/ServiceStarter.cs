using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

using Kiss.Server.WebserviceStarter.Properties;

using log4net;

namespace Kiss.Server.WebserviceStarter
{
    public abstract class ServiceStarter
    {
        protected static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IDictionary<string, Func<int>> _methods;

        protected ServiceStarter(ArgumentDictionary arguments, string serviceName)
        {
            ServiceName = serviceName;
            _methods = new Dictionary<string, Func<int>>();
            MethodName = arguments[ParameterNames.MethodName] ?? Settings.Default.MethodName;
            DbName = arguments[ParameterNames.DbName] ?? Settings.Default.DbName;
            EmailNotificationService = new EmailNotificationService(arguments);
        }

        public IEnumerable<string> AvailableMethods
        {
            get { return _methods.Keys; }
        }

        public string DbName { get; protected set; }
        public EmailNotificationService EmailNotificationService { get; private set; }
        public string MethodName { get; protected set; }
        public string ServiceName { get; protected set; }

        public int Start()
        {
            _log.DebugFormat("Method name: {0}", MethodName);
            _log.DebugFormat("DB name: {0}", DbName);

            var method = GetMethod(MethodName);
            if (method != null)
            {
                try
                {
                    return method();
                }
                catch (Exception ex)
                {
                    return LogAndNotifyFailure(ex.ToString());
                }
            }
            return LogAndNotifyFailure("Methode {0} existiert nicht.", MethodName);
        }

        protected void AddMethod(string name, Func<int> method)
        {
            _methods.Add(name, method);
        }

        protected Func<int> GetMethod(string name)
        {
            return _methods.Keys
                .Where(key => key.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                .Select(key => _methods[key])
                .FirstOrDefault();
        }

        protected int LogAndNotifyFailure(string errorMessageFormat, params object[] args)
        {
            _log.ErrorFormat(errorMessageFormat, args);
            if (EmailNotificationService.NotifyFailure(string.Format("{0}.{1}", ServiceName, MethodName), string.Format(errorMessageFormat, args)))
            {
                return -1;
            }
            return -2;
        }

        protected int LogAndNotifySuccess(string logMessage, params object[] args)
        {
            _log.DebugFormat(logMessage, args);
            if (EmailNotificationService.NotifySuccess(string.Format("{0}.{1}", ServiceName, MethodName)))
            {
                return 0;
            }
            return -2;
        }
    }
}