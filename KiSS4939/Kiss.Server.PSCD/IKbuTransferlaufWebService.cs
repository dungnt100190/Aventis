using System.ServiceModel;

using Kiss.BL;
using Kiss.Interfaces.BL;

namespace Kiss.Server.PSCD
{
    [ServiceContract(Namespace = "http://Kiss.Server.PSCD")]
    public interface IKbuTransferlaufWebService
    {
        #region Methods

        [OperationContract]
        KissServiceResult CancelTransferlauf(string dbName, SerializableUser authenticatedUser, int kbuTransferlaufID);

        [OperationContract]
        KbuTransferlaufStateDTO GetTransferlaufProgress(string dbName, SerializableUser authenticatedUser);

        [OperationContract]
        KissServiceResult StartTransferlauf(string dbName, SerializableUser authenticatedUser, int kbuTransferlaufID);

        #endregion
    }
}