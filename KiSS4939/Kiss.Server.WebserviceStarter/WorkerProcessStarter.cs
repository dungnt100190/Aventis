using System;

using Kiss.Server.WebserviceStarter.Properties;
using Kiss.Server.WebserviceStarter.WorkerProcessSvc;

namespace Kiss.Server.WebserviceStarter
{
    public class WorkerProcessStarter : ServiceStarter
    {
        public WorkerProcessStarter(ArgumentDictionary arguments)
            : base(arguments, "KissWorkerProcess")
        {
            UserId = Settings.Default.WorkerProcessUserId;
            int userId;
            if (int.TryParse(arguments[ParameterNames.WorkerProcessUserId], out userId))
            {
                UserId = userId;
            }

            MinSize = Settings.Default.ZkbDokumenteImportMinSize;
            int minSize;
            if (int.TryParse(arguments[ParameterNames.ZkbDokumenteImportMinSize], out minSize))
            {
                MinSize = minSize;
            }

            AddMethod("GetServerVersion", GetServerVersion);
            AddMethod("ZkbDokumenteImportieren", ZkbDokumenteImportieren);
            AddMethod("IkAuszuegeGenerieren", IkAuszuegeGenerieren);
        }

        public int MinSize { get; private set; }
        public int UserId { get; private set; }

        private int GetServerVersion()
        {
            using (var client = new WorkerProcessSvcSoapClient())
            {
                return LogAndNotifySuccess("Server-Version: {0}", client.GetServerVersion());
            }
        }

        private int IkAuszuegeGenerieren()
        {
            using (var client = new WorkerProcessSvcSoapClient())
            {
                var result = client.IKAuszuegeGenerieren(DbName, UserId, Environment.UserName);
                if (string.IsNullOrEmpty(result))
                {
                    return LogAndNotifySuccess("Die IK-Auszüge wurden erfolgreich erstellt.");
                }
                return LogAndNotifyFailure(result);
            }
        }

        private int ZkbDokumenteImportieren()
        {
            using (var client = new WorkerProcessSvcSoapClient())
            {
                var result = client.ZKBDokumenteImportieren(DbName, UserId, Environment.UserName, MinSize);
                if (string.IsNullOrEmpty(result))
                {
                    return LogAndNotifySuccess("Der ZKB-Dokumente-Import war erfolgreich.");
                }
                return LogAndNotifyFailure(result);
            }
        }
    }
}