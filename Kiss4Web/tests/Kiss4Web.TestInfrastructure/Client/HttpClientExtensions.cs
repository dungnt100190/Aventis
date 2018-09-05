using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure;
using Kiss4Web.Infrastructure.ErrorHandling;
using Kiss4Web.Infrastructure.ErrorHandling.Questions;
using Newtonsoft.Json;

namespace Kiss4Web.TestInfrastructure.Client
{
    public static class HttpClientExtensions
    {
        public static async Task<IServiceResult> CreateErrorServiceResult(HttpResponseMessage response)
        {
            // Individuelles KiSS Error-Objekt (normalerweise ErrorDTO)
            if (response.Content.Headers.ContentType != null &&
                response.Content.Headers.ContentType.MediaType == "application/json" &&
                response.Headers.TryGetValues("ContentTypeName", out var headerContent))
            {
                var contentType = headerContent.FirstOrDefault();
                if (contentType == typeof(ErrorDto[]).GetTypeName().Content)
                {
                    var errors = await response.Content.ReadAsAsync<ErrorDto[]>().ConfigureAwait(false);
                    return new ServiceResult<ErrorDto[]>(response.StatusCode, errors, false);
                }
                if (contentType == typeof(QuestionDto).GetTypeName().Content)
                {
                    var errors = await response.Content.ReadAsAsync<QuestionDto>().ConfigureAwait(false);
                    return new ServiceResult<QuestionDto>(response.StatusCode, errors, false);
                }
            }

            var error = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(error))
            {
                error = response.ReasonPhrase;
            }
            return new ServiceResult<object>(response.StatusCode, error);
        }

        public static async Task<ServiceResult<T>> GetAsJsonAsync<T>(this HttpClient client, string requestUri, object parameters = null)
        {
            if (parameters != null)
            {
                requestUri += GetQueryString(parameters);
            }

            var response = await client.GetAsync(requestUri);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(error))
                {
                    error = response.ReasonPhrase;
                }
                return new ServiceResult<T>(response.StatusCode, error);
            }

            return new ServiceResult<T>(response.StatusCode, await response.Content.ReadAsAsync<T>());
        }

        public static async Task<IServiceResult> PostAsJsonAsync<T>(this HttpClient client, string requestUri, T value, object parameters = null)
        {
            var json = JsonConvert.SerializeObject(value);
            if (parameters != null)
            {
                requestUri += GetQueryString(parameters);
            }

            var response = await client.PostAsync(requestUri, new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return await CreateErrorServiceResult(response).ConfigureAwait(false);
            }

            return new ServiceResult<object>(response.StatusCode, (object)null);
        }

        public static async Task<IServiceResult> PostAsJsonAsync<T, TResult>(this HttpClient client, string requestUri, T value, object parameters = null)
        {
            var json = JsonConvert.SerializeObject(value);
            if (parameters != null)
            {
                requestUri += GetQueryString(parameters);
            }

            var response = await client.PostAsync(requestUri, new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return await CreateErrorServiceResult(response).ConfigureAwait(false);
            }

            return new ServiceResult<TResult>(response.StatusCode, await response.Content.ReadAsAsync<TResult>());
        }

        public static async Task<IServiceResult> PutAsJsonAsync<T>(this HttpClient client, string requestUri, T value, object parameters = null)
        {
            var json = JsonConvert.SerializeObject(value);
            if (parameters != null)
            {
                requestUri += GetQueryString(parameters);
            }

            var response = await client.PutAsync(requestUri, new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.StatusCode != HttpStatusCode.OK)
            {
                var error = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(error))
                {
                    error = response.ReasonPhrase;
                }
                return new ServiceResult<object>(response.StatusCode, error);
            }

            return new ServiceResult<object>(response.StatusCode, (object)null);
        }

        private static string Encode(string value)
        {
            return value;
            // ToDo
            //return HttpUtility.UrlEncode(value);
        }

        private static string GetQueryString(object parameters)
        {
            var type = parameters.GetType();
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
            var parts = new List<string>();
            foreach (var propertyInfo in properties)
            {
                var keyEncoded = Encode(propertyInfo.Name);

                var parameterValue = propertyInfo.GetValue(parameters);
                if (!(parameterValue is string) && parameterValue is IEnumerable enumerable)
                {
                    parts.Add(enumerable
                              .Cast<object>()
                              .Select(val => $"{keyEncoded}={GetValueAsEncodedString(val)}")
                              .StringJoin("&"));
                }
                else
                {
                    var valueEncoded = GetValueAsEncodedString(parameterValue ?? string.Empty);
                    parts.Add($"{keyEncoded}={valueEncoded}");
                }
            }
            return parts.Any() ? "?" + parts.StringJoin("&") : string.Empty;
        }

        private static string GetValueAsEncodedString(object value)
        {
            if (value == null)
            {
                return null;
            }

            var valueAsString = value as string;
            if (value is DateTime)
            {
                valueAsString = ((DateTime)value).ToString(CultureInfo.InvariantCulture);
            }
            else if (valueAsString == null)
            {
                valueAsString = JsonConvert.SerializeObject(value);
                valueAsString = valueAsString.Trim('"');
            }

            return Encode(valueAsString);
        }
    }
}