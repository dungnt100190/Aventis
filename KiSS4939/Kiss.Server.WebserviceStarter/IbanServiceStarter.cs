using System;
using System.Collections.Generic;

using Kiss.Server.WebserviceStarter.KissIbanService;
using Kiss.Server.WebserviceStarter.Properties;

namespace Kiss.Server.WebserviceStarter
{
    public class IbanServiceStarter : ServiceStarter
    {
        public IbanServiceStarter(ArgumentDictionary arguments)
            : base(arguments, "KissIbanService")
        {
            KontoNr = arguments[ParameterNames.IbanKontoNr] ?? Settings.Default.IbanKontoNr;
            ClearingNr = arguments[ParameterNames.IbanClearingNr] ?? Settings.Default.IbanClearingNr;

            MethodName = arguments[ParameterNames.MethodName] ?? "TestIban";

            AddMethod("GetServerVersion", GetServerVersion);
            AddMethod("TestIban", TestIban);
        }

        public string ClearingNr { get; private set; }
        public string KontoNr { get; private set; }

        public int TestIban()
        {
            using (var ibanService = new KissIbanServiceClient())
            {
                var result = ibanService.TestIbanWebservice(KontoNr, ClearingNr);
                if (!string.IsNullOrEmpty(result))
                {
                    return LogAndNotifyFailure(result);
                }

                return LogAndNotifySuccess("IBAN-Service erfolgreich getestet.");
            }
        }

        private int GetServerVersion()
        {
            using (var client = new KissIbanServiceClient())
            {
                return LogAndNotifySuccess("Server-Version: {0}", client.GetServerVersion());
            }
        }
    }
}