using System;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;

using Kiss.BusinessLogic.Ba;
using Kiss.BusinessLogic.Sys;
using Kiss.DbContext.DTO.Ba;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;

using log4net;

namespace Kiss.Server.Einwohnerregister
{
    /// <summary>
    /// Basisklasse mit gemeinsamer Logik für Einwohnerregister-Services.
    /// </summary>
    public abstract class EinwohnerregisterService : IEinwohnerregisterService
    {
        protected static readonly ILog _log;

        protected readonly BaEinwohnerregisterService _baEinwohnerregisterService;

        protected readonly XUserService _xUserService;

        static EinwohnerregisterService()
        {
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        protected EinwohnerregisterService()
        {
            _baEinwohnerregisterService = Container.Resolve<BaEinwohnerregisterService>();
            _xUserService = Container.Resolve<XUserService>();
        }

        public abstract ServiceResult<BaEinwohnerregisterPersonAnfrageDTO> GetPersonDetails(string pid, int xUserId);

        public abstract ServiceResult PersonAbmelden(BaEinwohnerregisterPersonStatusDTO fremdsystemID);

        public abstract ServiceResult PersonAnmelden(BaEinwohnerregisterPersonStatusDTO fremdsystemID);

        public abstract ServiceResult<BaEinwohnerregisterPersonResultDTO[]> PersonSuchen(BaEinwohnerregisterPersonSucheDTO personSucheDto, int xUserId);

        public abstract ServiceResult ProcessEvents(int packetSize, bool includeFailedEvents);

        protected virtual Binding GetBinding(string uri, string proxy)
        {
            var securityMode = uri.StartsWith("https") ? BasicHttpSecurityMode.Transport : BasicHttpSecurityMode.None;
            var binding = new BasicHttpBinding(securityMode);

            binding.MaxBufferSize = int.MaxValue;
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
            binding.ReaderQuotas.MaxArrayLength = int.MaxValue;
            binding.ReaderQuotas.MaxDepth = 32;
            binding.ReaderQuotas.MaxStringContentLength = int.MaxValue;

            if (!string.IsNullOrWhiteSpace(proxy))
            {
                binding.UseDefaultWebProxy = false;
                binding.ProxyAddress = new Uri(proxy);
            }
            return binding;
        }

        protected EndpointAddress GetEndpoint(string uri)
        {
            return new EndpointAddress(uri);
        }

        protected void SetClientCredentials<TChannel>(ClientBase<TChannel> client, BaEinwohnerregisterConfigDTO configDto) where TChannel : class
        {
            if (client.ClientCredentials != null)
            {
                client.ClientCredentials.UserName.UserName = configDto.EinwohnerregisterWebservicesUsername;
                client.ClientCredentials.UserName.Password = configDto.EinwohnerregisterWebservicesPassword;
            }
        }
    }
}