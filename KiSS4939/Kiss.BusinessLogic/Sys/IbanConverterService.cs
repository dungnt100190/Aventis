using System;

using HtmlAgilityPack;

using Kiss.BusinessLogic.LocalResources.System;
using Kiss.BusinessLogic.Sys.NodeEnumeration;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IO;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

using log4net;

namespace Kiss.BusinessLogic.Sys
{
    public class IbanConverterService : Service
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(IbanConverterService));

        public IServiceResult<string> ConvertToIbanWeb(string kontoNr, string clearingNr)
        {
            try
            {
                var configService = Container.Resolve<XConfigService>();
                var serviceUrl = configService.GetConfigValue(ConfigNodes.System_Iban_Web_Url);

                if (serviceUrl == null)
                {
                    _log.Error(string.Format("Config-Key: {0} has no value.", ConfigNodes.System_Iban_Web_Url));

                    return new ServiceResult<string>(ServiceResultType.Error, IbanConverterServiceRes.Error_NoUrl, null);
                }

                // Get viewState and eventValidation fields
                var request = new WebPostRequest(serviceUrl);
                var responseString = request.GetResponse();

                string viewState, eventValidation;
                var result = GetPostVariables(responseString, out viewState, out eventValidation);

                if (result.IsError)
                {
                    _log.Error(string.Format("Error retrieving POST-Variables. \r\nError: {0}", result));

                    return new ServiceResult<string>(result);
                }

                // Create the actual request
                request.ClearParameters();

                var elementViewState = configService.GetConfigValue(ConfigNodes.System_Iban_Web_InputElementViewState);
                var elementEventValidation = configService.GetConfigValue(ConfigNodes.System_Iban_Web_InputElementEventValidation);
                var elementKontoNr = configService.GetConfigValue(ConfigNodes.System_Iban_Web_InputElementKontoNr);
                var elementClearingNr = configService.GetConfigValue(ConfigNodes.System_Iban_Web_InputElementBC);
                var additionalParameters = configService.GetConfigValue(ConfigNodes.System_Iban_Web_AdditionalParameters);

                request.AddParameter(elementClearingNr, clearingNr);
                request.AddParameter(elementKontoNr, kontoNr);
                request.AddParameter(elementViewState, viewState);
                request.AddParameter(elementEventValidation, eventValidation);

                // Add additional parameters
                if (additionalParameters != null)
                {
                    var keyValueStrings = additionalParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var keyValueString in keyValueStrings)
                    {
                        request.AddParameter(keyValueString);
                    }
                }

                responseString = request.GetResponse();

                // Extract IBAN/BC from the response
                int? status;
                string statusText;
                string iban;
                string pc;
                string bc;
                result = ParseDocument(responseString, out status, out statusText, out iban, out pc, out bc);

                if (result.IsError)
                {
                    _log.Error(string.Format("Error parsing response. \r\nError: {0}", result));

                    return new ServiceResult<string>(result);
                }

                if (status.HasValue && status.Value >= 1 && status.Value <= 9)
                {
                    return new ServiceResult<string>(iban);
                }

                if (!status.HasValue)
                {
                    return new ServiceResult<string>(ServiceResultType.Error, IbanConverterServiceRes.Error_Unknown, null);
                }

                return new ServiceResult<string>(ServiceResultType.Error, string.Format("{0}: {1}", status, statusText));
            }
            catch (Exception ex)
            {
                _log.Error("Error converting IBAN.", ex);

                return new ServiceResult<string>(ex, null, IbanConverterServiceRes.Error_Unknown);
            }
        }

        private static IServiceResult GetPostVariables(string htmlResponse, out string viewState, out string eventValidation)
        {
            viewState = null;
            eventValidation = null;

            var configService = Container.Resolve<XConfigService>();
            var initialDocument = new HtmlDocument();
            initialDocument.LoadHtml(htmlResponse);

            var xPathViewState = configService.GetConfigValue(ConfigNodes.System_Iban_Web_XPathViewState);
            var xPathEventValidation = configService.GetConfigValue(ConfigNodes.System_Iban_Web_XPathEventValidation);

            var viewStateNode = initialDocument.DocumentNode.SelectSingleNode(xPathViewState);
            var eventValidationNode = initialDocument.DocumentNode.SelectSingleNode(xPathEventValidation);

            if (viewStateNode == null || eventValidationNode == null)
            {
                return ServiceResult.Error(IbanConverterServiceRes.Error_ViewState_EventValidation, viewStateNode, eventValidationNode);
            }

            viewState = viewStateNode.Attributes["value"].Value;
            eventValidation = eventValidationNode.Attributes["value"].Value;

            return ServiceResult.Ok();
        }

        private static IServiceResult ParseDocument(string htmlResponse, out int? status, out string statusText, out string iban, out string pc, out string bc)
        {
            status = null;
            statusText = null;
            iban = null;
            pc = null;
            bc = null;

            var configService = Container.Resolve<XConfigService>();
            var initialDocument = new HtmlDocument();
            initialDocument.LoadHtml(htmlResponse);

            var xPathStatus = configService.GetConfigValue(ConfigNodes.System_Iban_Web_OutputXPathStatus);
            var xPathStatusText = configService.GetConfigValue(ConfigNodes.System_Iban_Web_OutputXPathStatusText);
            var xPathIban = configService.GetConfigValue(ConfigNodes.System_Iban_Web_OutputXPathIBAN);
            var xPathPc = configService.GetConfigValue(ConfigNodes.System_Iban_Web_OutputXPathPC);
            var xPathBc = configService.GetConfigValue(ConfigNodes.System_Iban_Web_OutputXPathBC);

            var statusNode = initialDocument.DocumentNode.SelectSingleNode(xPathStatus);
            var statusTextNode = initialDocument.DocumentNode.SelectSingleNode(xPathStatusText);
            var ibanNode = initialDocument.DocumentNode.SelectSingleNode(xPathIban);
            var pcNode = initialDocument.DocumentNode.SelectSingleNode(xPathPc);
            var bcNode = initialDocument.DocumentNode.SelectSingleNode(xPathBc);

            if (statusNode == null)
            {
                return ServiceResult.Error(IbanConverterServiceRes.Error_InvalidResult);
            }

            if (ibanNode == null)
            {
                return ServiceResult.Error(IbanConverterServiceRes.Error_NoIban);
            }

            int statusTemp;
            if (int.TryParse(statusNode.InnerText, out statusTemp))
            {
                status = statusTemp;
            }

            if (statusTextNode != null)
            {
                statusText = statusTextNode.InnerText;
            }

            iban = ibanNode.InnerText;

            if (pcNode != null)
            {
                pc = pcNode.InnerText;
            }
            if (bcNode != null)
            {
                bc = bcNode.InnerText;
            }

            return ServiceResult.Ok();
        }
    }
}