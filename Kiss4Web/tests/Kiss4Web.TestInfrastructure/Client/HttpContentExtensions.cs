using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Kiss4Web.TestInfrastructure.Client
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            var json = await content.ReadAsStringAsync();
            if (content.Headers.ContentType.MediaType == "text/plain" && typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(json, typeof(T));
            }

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}