using System;
using System.Net;
using KiSS4.DB;

namespace KiSS4.FAMOZ.AlphaService
{
	public class AlphaService
	{
		private const string alphaServiceConfigPath = @"System\Schnittstellen\Alpha\AlphaWebServiceURL";
		private const string alphaProxyConfigPath = @"System\Schnittstellen\Alpha\Proxy";

        public static string GetServerVersion()
        {
            return GetAlphaSvc().GetServerVersion();
        }

        public AlphaSearchPersonDTO[] FindPersonDTO(string lastName, string firstName, string street, int? streetCode, string houseNumber, int? ortCode, DateTime? birthDateFrom, DateTime? birthDateTo, int? nationality, string ahvNumber, int? zipNr, string svn)
        {
            AlphaSearchPersonDTO[] dto;
            ProcessReturnMsg(GetAlphaSvc().DoAlphaQuery(Session.User.UserID, Session.User.WinDomainLogonName, lastName, firstName, street, streetCode, ortCode, houseNumber, birthDateFrom, birthDateTo, nationality, ahvNumber, zipNr, svn, out dto));
            return dto;
        }

		public AlphaPersonDTO GetPersonDetails(int zipNr)
		{
			AlphaPersonDTO dto;
			ProcessReturnMsg(GetAlphaSvc().GetPersonDetails(Session.User.UserID, Session.User.WinDomainLogonName, zipNr, out dto));
			return dto;
		}

		#region private helper methods

		private static AlphaSvc GetAlphaSvc()
		{
			AlphaSvc svc = new AlphaSvc();
			svc.Url = GetURL(alphaServiceConfigPath);
			svc.Proxy = GetProxy();
			svc.Credentials = CredentialCache.DefaultCredentials;
			return svc;
		}

		private static string GetURL(string configName)
		{
			string url = DBUtil.GetConfigString(configName, null);
			if (string.IsNullOrEmpty(url))
                throw new KissErrorException(KissMsg.GetMLMessage("Alpha Interface", "NoUrlSpecifiedInXConfig", "Es ist keine URL konfiguriert, die auf dem KiSS-Server aufgerufen werden soll. Bitte unter 'Konfiguration' eintragen.", KissMsgCode.MsgError), configName, null);
			return url;
		}

		private static WebProxy GetProxy()
		{
			string alphaServiceProxy = DBUtil.GetConfigString(alphaProxyConfigPath, null);
			if (string.IsNullOrEmpty(alphaServiceProxy))
				return null;
			return new WebProxy(alphaServiceProxy, false);
		}

        private static bool ProcessReturnMsg(ReturnMsg returnMsg)
		{
			if (returnMsg.Result == CreateObjectResult.ExceptionOccured && !string.IsNullOrEmpty(returnMsg.ExceptionMessage))
			{
				returnMsg.ExceptionMessage = returnMsg.ExceptionMessage == null ? null : returnMsg.ExceptionMessage.Replace("\n", Environment.NewLine);
				throw new KissErrorException(KissMsg.GetMLMessage("Alpha Interface", "KiSSSvcError", "Es ist ein Fehler auf dem KiSS-Server aufgetreten:{0}{0}{1}", KissMsgCode.MsgError, Environment.NewLine, returnMsg.ExceptionMessage), returnMsg.ExceptionMessage, null);
			}
			if (returnMsg.Result != CreateObjectResult.Success)
			{
				returnMsg.WarningMessage = returnMsg.WarningMessage == null ? null : returnMsg.WarningMessage.Replace("\n", Environment.NewLine);
                throw new KissInfoException(KissMsg.GetMLMessage("Alpha Interface", "KiSSSvcWarning", "Warnung (vom KiSS-Server):{0}{0}{1}", KissMsgCode.MsgInfo, Environment.NewLine, returnMsg.WarningMessage));
			}
			return true;
		}

		#endregion
	}
}
