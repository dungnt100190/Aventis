using Kiss.Server.WebserviceStarter.KissEinwohnerregisterService;
using Kiss.Server.WebserviceStarter.Properties;

namespace Kiss.Server.WebserviceStarter
{
    public class EinwohnerregisterServiceStarter : ServiceStarter
    {
        public EinwohnerregisterServiceStarter(ArgumentDictionary arguments)
            : base(arguments, "KissEinwohnerregisterService")
        {
            IncludeFailedEvents = arguments.ContainsKey(ParameterNames.IncludeFailedEvents) || Settings.Default.IncludeFailedEvents;

            EventPacketSize = Settings.Default.EventPacketSize;
            int packetSize;
            if (int.TryParse(arguments[ParameterNames.EventPacketSize], out packetSize))
            {
                EventPacketSize = packetSize;
            }

            AddMethod("GetServerVersion", GetServerVersion);
            AddMethod("PersonenAnAbmelden", PersonenAnAbmelden);
            AddMethod("ProcessEvents", ProcessEvents);
        }

        public int EventPacketSize { get; private set; }

        public bool IncludeFailedEvents { get; private set; }

        private int GetServerVersion()
        {
            using (var client = new KissEinwohnerregisterServiceClient())
            {
                return LogAndNotifySuccess("Server-Version: {0}", client.GetServerVersion());
            }
        }

        private int PersonenAnAbmelden()
        {
            using (var client = new KissEinwohnerregisterServiceClient())
            {
                var result = client.PersonenAnAbmelden(DbName);
                if (!string.IsNullOrEmpty(result))
                {
                    return LogAndNotifyFailure(result);
                }

                return LogAndNotifySuccess("Der Aufruf war erfolgreich.");
            }
        }

        private int ProcessEvents()
        {
            using (var client = new KissEinwohnerregisterServiceClient())
            {
                int? packetSize = EventPacketSize;
                if (packetSize <= 0)
                {
                    packetSize = null;
                }
                var result = client.ProcessEvents(DbName, packetSize, IncludeFailedEvents);
                if (!string.IsNullOrEmpty(result))
                {
                    return LogAndNotifyFailure(result);
                }

                return LogAndNotifySuccess("Der Aufruf war erfolgreich.");
            }
        }
    }
}