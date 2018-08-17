using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Kiss.BusinessLogic.Sys
{
    public static class SslCertificateValidator
    {
        static SslCertificateValidator()
        {
            RegisterValidationCallback(ServerCertificateValidationCallback);
        }

        public static bool IsValidating
        {
            get;
            set;
        }

        public static void RegisterValidationCallback(RemoteCertificateValidationCallback callback)
        {
            ServicePointManager.ServerCertificateValidationCallback = callback;
        }

        private static bool ServerCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (IsValidating)
            {
                return sslPolicyErrors == SslPolicyErrors.None;
            }
            return true;
        }
    }
}