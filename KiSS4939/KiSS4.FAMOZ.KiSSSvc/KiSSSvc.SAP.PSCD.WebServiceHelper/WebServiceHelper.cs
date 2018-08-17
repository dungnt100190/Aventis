using System;
using System.Web.Services.Protocols;
using System.Net;
using System.Web;
using KiSSSvc.SAP.PSCD.WebServiceHelper.Settings;
using KiSSSvc.DAL;
using KiSSSvc.SAP.PSCD.BLL;

namespace KiSSSvc.SAP.PSCD.WebServiceHelper
{
	/// <summary>
	/// Summary description for WebServiceHelper.
	/// </summary>
	public class WebServiceHelperMethods
	{
		static SettingsAccessor settings;

		static WebServiceHelperMethods()
		{
		}

		public static void ResetSettings()
		{
			settings = new SettingsAccessor();			
		}

		public static SettingsAccessor GetSettings()
		{
			if (WebServiceHelperMethods.settings == null)
			{
				settings = new SettingsAccessor();
			}
			return settings;
		}

		public static void InitWebService(ref System.Web.Services.Protocols.SoapHttpClientProtocol svc, string appendixToUrl)
		{
			InitWebService(ref svc, appendixToUrl, false);
		}
		public static void InitWebService(ref System.Web.Services.Protocols.SoapHttpClientProtocol svc, string appendixToUrl, bool asyncCall)
		{
			SettingsAccessor settings = GetSettings();
			if (settings.PSCDServerUrl != null)
			{
				if (string.IsNullOrEmpty(appendixToUrl))
				{
					throw new Exception("No URL found for this Service");
				}
				if (appendixToUrl.StartsWith("http://"))
					svc.Url = appendixToUrl;
				else
					svc.Url = string.Concat(settings.PSCDServerUrl, appendixToUrl);
			}
			// user / password
			if (settings.PSCDUserName != null && settings.PSCDPassword != null)
			{
				NetworkCredential cred = new NetworkCredential(settings.PSCDUserName, settings.PSCDPassword);
				Uri uri = new Uri(svc.Url);
				ICredentials creds = cred.GetCredential(uri, "Basic");
				svc.Credentials = creds;
			}
			// proxy: check XConfig first. if empty, use proxy from web.config
			string proxy = XConfigBLL.GetPSCDServerProxy();
			if (string.IsNullOrEmpty(proxy))
				proxy = settings.PSCDProxy;
			if (!string.IsNullOrEmpty(proxy))
				svc.Proxy = new WebProxy(proxy, false);

            svc.Timeout = asyncCall ? 30000 : 300000;
			svc.PreAuthenticate = true;
		}

		public static void CheckDBName(string dbName)
		{
			KiSSDB.CheckDBName(dbName);
		}

		public static string GetNewLineString()
		{
			return Environment.NewLine;
		}

		public static bool CheckDBConnection()
		{
			return KiSSDB.CheckDBConnection();
		}
	}
}
