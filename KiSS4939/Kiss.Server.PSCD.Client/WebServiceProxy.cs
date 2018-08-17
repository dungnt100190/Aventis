using System;
using System.Reflection;
using System.ServiceModel;

using log4net;

using Kiss.Interfaces.BL;
using Kiss.Server.PSCD.Client.SstZahlungseingaengeAbholenWebService;

namespace Kiss.Server.PSCD.Client
{
    public static class WebServiceProxy
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        public const string SST_ZAHLUNGSEINGAENGE_ABHOLEN_ENDPOINT = "Kiss.Server.PSCD.SstZahlungseingaengeAbholenWebService.svc";

        #endregion

        #endregion

        #region Properties

        private static ILog Log
        {
            get { return LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType); }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static KissServiceResult SstZahlungseingaengeAbholen(string endpointBase, string dbName, string timestamp)
        {
            Log.DebugFormat("DBName: {0}, Timestamp: {1}", dbName, timestamp);

            var client = new SstZahlungseingaengeAbholenWebServiceClient();

            var user = new SerializableUser
            {
                CreatorModifier = "LastName FirstName (1)",
                FirstName = "FirstName",
                IsUserAdmin = true,
                IsUserBIAGAdmin = true,
                LastName = "LastName",
                LogonName = "LogonName",
                UserID = 1
            };

            try
            {
                if (endpointBase != null)
                {
                    // Set endpoint address
                    client.Endpoint.Address = new EndpointAddress(endpointBase.Trim('/') + "/" + SST_ZAHLUNGSEINGAENGE_ABHOLEN_ENDPOINT);
                }

                var result = client.ZahlungseingaengeAbholen(dbName, user, timestamp);
                Log.DebugFormat("Result: {0}", result);
                return result;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return new KissServiceResult(ex);
            }
        }

        #endregion

        #endregion
    }
}