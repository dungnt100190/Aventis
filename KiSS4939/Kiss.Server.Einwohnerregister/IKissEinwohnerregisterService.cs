using System.ServiceModel;

using Kiss.DbContext.DTO.Ba;
using Kiss.Infrastructure;

namespace Kiss.Server.Einwohnerregister
{
    [ServiceContract]
    public interface IKissEinwohnerregisterService
    {
        [OperationContract]
        ServiceResult<BaEinwohnerregisterPersonAnfrageDTO> GetPersonDetails(string dbName, string pid, int xUserId, string machineName);

        [OperationContract]
        string GetServerVersion();

        [OperationContract]
        string PersonenAnAbmelden(string dbName);

        [OperationContract]
        ServiceResult<BaEinwohnerregisterPersonResultDTO[]> PersonSuchen(string dbName, BaEinwohnerregisterPersonSucheDTO dto, int xUserId, string machineName);

        [OperationContract]
        string ProcessEvents(string dbName, int? packetSize, bool includeFailedEvent);
    }
}