using System.Collections;
using System.Linq;
using System.Net;
using Kiss4Web.Infrastructure;
using Shouldly;

namespace Kiss4Web.TestInfrastructure.Client
{
    public class ServiceResult<T> : IServiceResult
    {
        public bool IsSuccess { get; set; }

        public ServiceResult(HttpStatusCode httpResult, string error)
        {
            HttpResult = httpResult;
            Error = error;
            IsSuccess = false;
        }

        public ServiceResult(HttpStatusCode httpResult, T result, bool isSuccess = true)
        {
            HttpResult = httpResult;
            Result = result;
            IsSuccess = isSuccess;
        }

        public string Error { get; set; }
        public HttpStatusCode HttpResult { get; set; }
        public T Result { get; set; }

        public override string ToString()
        {
            return IsSuccess ? $"OK, Result: {ListIfEnumerable(Result)}" : $"{HttpResult}, Error: {Error}";
        }

        private static object ListIfEnumerable(T list)
        {
            if (list is IEnumerable enumerable)
            {
                return enumerable.OfType<object>().Select(itm => itm.ToString()).StringJoin();
            }
            return list;
        }

        public void ShouldBeOk()
        {
            IsSuccess.ShouldBeTrue(Error);
        }
    }
}