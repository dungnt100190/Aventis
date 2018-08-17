using System.ServiceModel;

namespace Kiss.Server.Iban
{
    [ServiceContract]
    public interface IKissIbanService
    {
        [OperationContract]
        string ConvertToIban(string kontoNr, string clearingNr);

        [OperationContract]
        string GetServerVersion();

        [OperationContract]
        string TestIbanWebservice(string kontoNr = null, string clearingNr = null);
    }
}