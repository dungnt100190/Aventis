using System;
using System.Net;
using KiSS4.DB;
using KiSS4.FAMOZ.WorkerProcess;

namespace KiSS4.FAMOZ.WorkerProcess
{
	public static class WorkerProcessHelper
	{
        private const string workerProcessServiceConfigPath = @"System\Schnittstellen\BackgroundWorkerService\BackgroundWorkerWebServiceURL";

        public static void IKAuszuegeGenerieren()
		{
            WorkerProcessSvc svc = null;
            svc = GetWorkerProcessSvc();

            // Starte den Workerprozess
			svc.IKAuszuegeGenerierenAsync(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName);
		}

		#region Private Methods

        private static WorkerProcessSvc GetWorkerProcessSvc()
		{
            WorkerProcessSvc svc = new WorkerProcessSvc();
			svc.Url = GetURL(workerProcessServiceConfigPath);
			svc.Timeout = 120000;
			svc.Credentials = CredentialCache.DefaultCredentials;
			svc.PreAuthenticate = true;
			return svc;
		}

		private static string GetURL(string configName)
		{
			string url = DBUtil.GetConfigString(configName, null);
			if (string.IsNullOrEmpty(url))
                throw new KissErrorException(KissMsg.GetMLMessage("WorkerProcessSvc", "NoUrlSpecifiedInXConfig", "Es ist keine URL konfiguriert, die auf dem KiSS-Server aufgerufen werden soll. Bitte unter 'Konfiguration' eintragen.", KissMsgCode.MsgError), configName, null);
			return url;
		}

		#endregion
	}
}
