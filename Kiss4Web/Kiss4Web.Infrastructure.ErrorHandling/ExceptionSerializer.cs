using System;
using Newtonsoft.Json;

namespace Kiss4Web.Infrastructure.ErrorHandling
{
    public class ExceptionSerializer
    {
        public Exception DeserializeException(string serializedException)
        {
            if (serializedException == null)
            {
                return null;
            }
            try
            {
                return JsonConvert.DeserializeObject<Exception>(serializedException);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string ExtractMessage(string serializedException)
        {
            var ex = DeserializeException(serializedException);
            return ex == null ? serializedException : ex.Message;
        }

        public string SerializeException(Exception ex)
        {
            if (ex == null)
            {
                return null;
            }
            try
            {
                return JsonConvert.SerializeObject(ex);
            }
            catch (Exception)
            {
                return ex.Message;
            }
        }
    }
}