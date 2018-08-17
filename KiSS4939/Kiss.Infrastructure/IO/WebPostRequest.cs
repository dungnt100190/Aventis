using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Web;

using log4net;

namespace Kiss.Infrastructure.IO
{
    public class WebPostRequest
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(WebPostRequest));

        private readonly List<string> _queryData;
        private readonly string _url;

        public WebPostRequest(string url)
        {
            _url = url;
            _queryData = new List<string>();
        }

        public void AddParameter(string keyValueString)
        {
            var index = keyValueString.IndexOf('=');

            if (index >= 0)
            {
                var key = keyValueString.Substring(0, index);
                var value = keyValueString.Substring(index, keyValueString.Length - index - 1);
                AddParameter(key, value);
            }
        }

        public void AddParameter(string key, string value)
        {
            _queryData.Add(string.Format("{0}={1}", key, HttpUtility.UrlEncode(value)));
        }

        public void ClearParameters()
        {
            _queryData.Clear();
        }

        public string GetResponse()
        {
            _log.InfoFormat("_url: {0}", _url);
            var request = System.Net.WebRequest.Create(_url);
            request.Method = "POST";
            // Set the encoding type
            request.ContentType = "application/x-www-form-urlencoded";

            //Falls das System einen Proxy benötigt für den Internet-Zugriff (DefaultWebProxy nimmt Proxy-Settings aus app.config/web.config, falls dort nichts konfiguriert ist wird die System-Konfiguration berücksichtigt.
            var proxy = System.Net.WebRequest.DefaultWebProxy;
            _log.InfoFormat("proxy: {0}, IsBypassed: {1}", proxy, proxy.IsBypassed(new System.Uri(_url)));
            proxy.Credentials = CredentialCache.DefaultCredentials;
            request.Proxy = proxy;

            var logWebProxy = proxy.GetProxy(new Uri(_url));
            _log.InfoFormat("proxy.Host: {0}, Port: {1}", logWebProxy.Host, logWebProxy.Port);

            // Build a string containing all the parameters
            var parameters = string.Join("&", _queryData);
            request.ContentLength = parameters.Length;

            // We write the parameters into the request
            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(parameters);
                sw.Close();
            }

            // Execute the query
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            if (stream != null)
            {
                var reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
            return null;
        }
    }
}