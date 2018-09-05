using System.Net;

namespace Kiss4Web.TestInfrastructure.Client
{
    public interface IServiceResult
    {
        string Error { get; set; }
        HttpStatusCode HttpResult { get; set; }
        bool IsSuccess { get; set; }
    }
}