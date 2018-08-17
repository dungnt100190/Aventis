using System;

using Kiss.Infrastructure;
using Kiss.Interfaces.BL;

using log4net;

namespace Kiss.Server.Einwohnerregister
{
    public static class Logger
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(KissEinwohnerregisterService));

        public static IServiceResult LogError(int? xUserId, Exception ex, string errorFormat, params object[] args)
        {
            //// TODO Benutzer-Info holen, falls für Log nötig
            //if (xUserId.HasValue)
            //{
            //    var user = _xUserService.GetEntityById(xUserId.Value);
            //    var userName = user.LastNameFirstName;
            //}

            var error = string.IsNullOrEmpty(errorFormat) ? "Unknown Error" : args.Length > 0 ? string.Format(errorFormat, args) : errorFormat;
            _log.Error(error, ex);
            return ServiceResult.Error(error);
        }

        public static IServiceResult LogMessage(int? xUserId, string messageFormat, params object[] args)
        {
            _log.DebugFormat(messageFormat, args);
            return ServiceResult.Ok();
        }

        public static IServiceResult LogWarning(int? xUserId, string warningFormat, params object[] args)
        {
            var warning = string.Format(warningFormat, args);
            _log.Warn(warning);
            return ServiceResult.Warning(warning);
        }
    }
}