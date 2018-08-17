using System;
using System.Net;
using KiSS4.DB;
using KiSS4.FAMOZ.PscdNotification;

namespace KiSS4.FAMOZ.PSCDServices
{
	public static class PSCDInterface
	{
		private const string pscdNotificationServiceConfigPath = @"System\Schnittstellen\PSCD\PSCDNotificationWebServiceURL";
		private const string pscdServiceConfigPath = @"System\Schnittstellen\PSCD\PSCDWebServiceURL";
		private const string proxyConfigPath = @"System\Schnittstellen\PSCD\Proxy";

        public static string GetServerVersion()
        {
            PSCDSvc svc = null;
            try
            {
                svc = GetPscdSvc();
                return svc.GetServerVersion();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ConnectFailure && svc != null && svc.Proxy != null)
                {
                    svc.Proxy = null;
                    return svc.GetServerVersion();
                }
                else
                    throw;
            }
        }

        public static void CacheLeeren()
        {
            PSCDSvc svc = null;
            try
            {
                svc = GetPscdSvc();
                svc.ClearCache();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ConnectFailure && svc != null && svc.Proxy != null)
                {
                    svc.Proxy = null;
                    svc.ClearCache();
                }
                else
                    throw;
            }
        }

		public static void CreateAndSubmitBusinessPartnerPersonData(int baPersonID)
		{
			PSCDSvc svc = null;
			try
			{
				svc = GetPscdSvc();
				ProcessReturnMsg(svc.CreateAndSubmitBusinessPartnerPersonData(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, baPersonID));
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ConnectFailure && svc != null && svc.Proxy != null)
				{
					svc.Proxy = null;
					ProcessReturnMsg(svc.CreateAndSubmitBusinessPartnerPersonData(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, baPersonID));
				}
				else
					throw;
			}
		}

		public static void CreateAndSubmitBusinessPartnerInstitutionData(int baInstitutionID)
		{
			PSCDSvc svc = null;
			try
			{
				svc = GetPscdSvc();
				ProcessReturnMsg(svc.CreateAndSubmitBusinessPartnerInstitutionData(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, baInstitutionID));
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ConnectFailure && svc != null && svc.Proxy != null)
				{
					svc.Proxy = null;
					ProcessReturnMsg(svc.CreateAndSubmitBusinessPartnerInstitutionData(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, baInstitutionID));
				}
				else
					throw;
			}
		}

		public static bool SubmitWhBuchungsstoff(int[] kbBuchungIDs, int[] kbBuchungBruttoIDs, DateTime valutaDatum)
		{
			PSCDSvc svc = null;
			try
			{
				svc = GetPscdSvc();
				return ProcessReturnMsg(svc.SubmitWhBelegeByIDs2(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kbBuchungIDs, kbBuchungBruttoIDs, valutaDatum));
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ConnectFailure && svc != null && svc.Proxy != null)
				{
					svc.Proxy = null;
					return ProcessReturnMsg(svc.SubmitWhBelegeByIDs2(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kbBuchungIDs, kbBuchungBruttoIDs, valutaDatum));
				}
				else
					throw;
			}
		}

		public static bool SubmitWhBuchungsstoff(int[] kbBuchungIDs, int[] kbBuchungBruttoIDs)
		{
			PSCDSvc svc = null;
			try
			{
				svc = GetPscdSvc();
				return ProcessReturnMsg(svc.SubmitWhBelegeByIDs(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kbBuchungIDs, kbBuchungBruttoIDs));
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ConnectFailure && svc != null && svc.Proxy != null)
				{
					svc.Proxy = null;
					return ProcessReturnMsg(svc.SubmitWhBelegeByIDs(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kbBuchungIDs, kbBuchungBruttoIDs));
				}
				else
					throw;
			}
		}

		public static void StornoNettoBelege(int[] kbBuchungIDs, DateTime stornoDatum)
		{
			PSCDSvc svc = null;
			try
			{
				svc = GetPscdSvc();
				ProcessReturnMsg(svc.StornoNettoBelege2(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kbBuchungIDs, stornoDatum));
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ConnectFailure && svc != null && svc.Proxy != null)
				{
					svc.Proxy = null;
					ProcessReturnMsg(svc.StornoNettoBelege2(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kbBuchungIDs, stornoDatum));
				}
				else
					throw;
			}
		}

		public static void StornoBruttoBelege(int[] kbBuchungBruttoIDs, bool test, DateTime stornoDatum)
		{
			PSCDSvc svc = null;
			try
			{
				svc = GetPscdSvc();
				ProcessReturnMsg(svc.StornoBruttoBelege(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kbBuchungBruttoIDs, test, stornoDatum));
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ConnectFailure && svc != null && svc.Proxy != null)
				{
					svc.Proxy = null;
					ProcessReturnMsg(svc.StornoBruttoBelege(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kbBuchungBruttoIDs, test, stornoDatum));
				}
				else
					throw;
			}
		}

		public static bool SubmitWVEinzelpostenByIDs(int[] kbWVEinzelpostenIDs)
		{
			PSCDSvc svc = null;
			try
			{
				svc = GetPscdSvc();

                int maxSstTimeout = 90000; // Zusatz: 90 sek. (max. Schnittstellentimeout zw. KiSS-Webservice und PSCD: ca. 60 sek.)
                svc.Timeout = 120000 + maxSstTimeout;
                // Passe den Timeout dieses Calls an abhängig von der Anzahl der IDs, die übermittelt werden sollen. Default-Timeout ist 120000 (2 min)
                // Gestaffelte timeouts zum Webservice: Timeout im Kiss-Client muss grösser sein als im Webservice
                if (kbWVEinzelpostenIDs.Length > 20)
                {
                    // Der Timeout muss grösser sein als 2 min
                    svc.Timeout = kbWVEinzelpostenIDs.Length * 6000 + maxSstTimeout;
                }

				return ProcessReturnMsg(svc.SubmitWVEinzelpostenByIDs(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kbWVEinzelpostenIDs));
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ConnectFailure && svc != null && svc.Proxy != null)
				{
					svc.Proxy = null;
					return ProcessReturnMsg(svc.SubmitWVEinzelpostenByIDs(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kbWVEinzelpostenIDs));
				}
				else
					throw;
			}
		}

		#region Modul A (Alimentewesen)

		public static bool SubmitAlimBuchungsstoff(int[] kbBuchungIDs, DateTime valutaDatum)
		{
			PSCDSvc svc = null;
			try
			{
				svc = GetPscdSvc();
				return ProcessReturnMsg(svc.SubmitAlimBelegeByIDs2(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kbBuchungIDs, valutaDatum));
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ConnectFailure && svc != null && svc.Proxy != null)
				{
					svc.Proxy = null;
					return ProcessReturnMsg(svc.SubmitAlimBelegeByIDs2(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kbBuchungIDs, valutaDatum));
				}
				else
					throw;
			}
		}

		public static bool SubmitAlimBuchungsstoff(int[] kbBuchungIDs)
		{
			PSCDSvc svc = null;
			try
			{
				svc = GetPscdSvc();
				return ProcessReturnMsg(svc.SubmitAlimBelegeByIDs(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kbBuchungIDs));
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ConnectFailure && svc != null && svc.Proxy != null)
				{
					svc.Proxy = null;
                    return ProcessReturnMsg(svc.SubmitAlimBelegeByIDs(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kbBuchungIDs));
				}
				else
					throw;
			}
		}

		#endregion

		#region Modul K (Verwaltung Klientengelder)

		public static bool SubmitKgBelege(int[] kgBuchungIDs)
		{
			PSCDSvc svc = null;
			try
			{
				svc = GetPscdSvc();
				return ProcessReturnMsg(svc.SubmitKgBelege(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kgBuchungIDs));
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ConnectFailure && svc != null && svc.Proxy != null)
				{
					svc.Proxy = null;
					return ProcessReturnMsg(svc.SubmitKgBelege(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kgBuchungIDs));
				}
				else
					throw;
			}
		}

		public static bool StornoKgBelege(int[] kgBuchungIDs, bool test)
		{
			PSCDSvc svc = null;
			try
			{
				svc = GetPscdSvc();
				return ProcessReturnMsg(svc.StornoKgBelege(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kgBuchungIDs, test));
			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ConnectFailure && svc != null && svc.Proxy != null)
				{
					svc.Proxy = null;
					return ProcessReturnMsg(svc.StornoKgBelege(Session.Connection.Database, Session.User.UserID, Session.User.WinDomainLogonName, kgBuchungIDs, test));
				}
				else
					throw;
			}
		}

		#endregion

		#region Private Methods

		private static bool ProcessReturnMsg(ReturnMsg returnMsg)
		{
			if (returnMsg.Result == CreateObjectResult.ExceptionOccured && !string.IsNullOrEmpty(returnMsg.ExceptionMessage))
			{
				returnMsg.ExceptionMessage = returnMsg.ExceptionMessage == null ? null : returnMsg.ExceptionMessage.Replace("\n", Environment.NewLine);
				throw new KissErrorException(KissMsg.GetMLMessage("PSCDInterface", "KiSSSvcError", "Es ist ein Fehler auf der Schnittstelle KiSS-PSCD aufgetreten:{0}{0}{1}", KissMsgCode.MsgError, Environment.NewLine, returnMsg.ExceptionMessage), returnMsg.ExceptionMessage, null);
			}
			if (returnMsg.Result != CreateObjectResult.Success)
			{
				returnMsg.WarningMessage = returnMsg.WarningMessage == null ? null : returnMsg.WarningMessage.Replace("\n", Environment.NewLine);
				throw new KissInfoException(KissMsg.GetMLMessage("PSCDInterface", "KiSSSvcWarning", "Warnung (von der Schnittstelle KiSS-PSCD):{0}{0}{1}", KissMsgCode.MsgInfo, Environment.NewLine, returnMsg.WarningMessage));
			}
			return true;
		}

		private static PSCDSvc GetPscdSvc()
		{
			PSCDSvc svc = new PSCDSvc();
			svc.Url = GetURL(pscdServiceConfigPath);
			svc.Timeout = 120000;
			svc.Credentials = CredentialCache.DefaultCredentials;
			svc.PreAuthenticate = true;
			svc.Proxy = GetProxy();
			return svc;
		}

		private static NotificationSvc GetNotificationSvc()
		{
			NotificationSvc svc = new NotificationSvc();
			svc.Url = GetURL(pscdNotificationServiceConfigPath);
			svc.Timeout = 120000;
			svc.Credentials = CredentialCache.DefaultCredentials;
			svc.PreAuthenticate = true;
			svc.Proxy = GetProxy();
			return svc;
		}

		private static string GetURL(string configName)
		{
			string url = DBUtil.GetConfigString(configName, null);
			if (string.IsNullOrEmpty(url))
				throw new KissErrorException(KissMsg.GetMLMessage("PSCDInterface", "NoUrlSpecifiedInXConfig", "Es ist keine URL konfiguriert, die auf dem KiSS-Server aufgerufen werden soll. Bitte unter 'Konfiguration' eintragen.", KissMsgCode.MsgError), configName, null);
			return url;
		}

		private static WebProxy GetProxy()
		{
			string pscdServiceProxy = DBUtil.GetConfigString(proxyConfigPath, null);
			if (string.IsNullOrEmpty(pscdServiceProxy))
				return null;
			return new WebProxy(pscdServiceProxy, false);
		}

		#endregion

		#region PscdNotification
		public static bool NotifyAboutSAPDataReady(string type, int id)
		{
			NotificationSvc svc = null;

			svc = GetNotificationSvc();
			svc.NotifyAboutSAPDataReady(type, id);
			return true;
		}
		#endregion
	}
}
