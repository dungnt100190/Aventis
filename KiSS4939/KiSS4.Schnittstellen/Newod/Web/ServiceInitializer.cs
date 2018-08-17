using System;
using System.Net;
using System.Web.Services.Protocols;

namespace BIAG.Common.Web
{
    public sealed class ServiceInitializer
    {
        string _host;
        string _path;
        string _username;
        string _password;
        string _proxy;
        int _timeout;
        int _port;
        string _scheme;

        public ServiceInitializer(string uri, string path, string username, string password, string proxy, int timeout)
        {
            UriBuilder uriBuilder = new UriBuilder(new Uri(uri));

            _scheme = uriBuilder.Scheme;
            _host = uriBuilder.Host;
            _port = uriBuilder.Port;

            _path = path;

            _username = username;
            _password = password;
            _proxy = proxy;
            _timeout = timeout;
        }


        public ServiceInitializer(string scheme, string host, int port, string path, string username, string password, string proxy, int timeout)
        {
            _scheme = scheme;
            _host = host;
            _port = port;
            _path = path;
            _username = username;
            _password = password;
            _proxy = proxy;
            _timeout = timeout;

        }
        public void InitService(SoapHttpClientProtocol service, string query)
        {
            const string authType = "Basic";

            UriBuilder uriBuilder = new UriBuilder(_scheme, _host, _port, _path, query);
            NetworkCredential credential = new NetworkCredential(_username, _password);

            service.Url = uriBuilder.Uri.ToString();
            service.Credentials = credential.GetCredential(uriBuilder.Uri, authType);

            if (string.IsNullOrEmpty(_proxy) == false)
                service.Proxy = new WebProxy(_proxy, false);

            if (_timeout > 0)
                service.Timeout = _timeout * 1000;

            service.PreAuthenticate = true;
        }
    }
}
