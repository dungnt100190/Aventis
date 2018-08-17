using System.ServiceModel;

using Kiss.BL;
using Kiss.Interfaces.BL;

namespace Kiss.Server.PSCD
{
    [ServiceContract(Namespace = "http://Kiss.Server.PSCD")]
    public interface ISstZahlungseingaengeAbholenWebService
    {
        #region Methods

        [OperationContract]
        KissServiceResult ZahlungseingaengeAbholen(string dbName, SerializableUser user, string timestampFrom);

        #endregion
    }
}