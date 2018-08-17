using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Configuration;
using System.Configuration;
using KiSSSvc.DAL;
using KiSSSvc.SAP.PSCD.BLL;

namespace KiSSSvc.SAP.PSCD.WebServiceHelper.Settings
{
	class WebConfigSettings
	{
		private const string username = "PSCD.username";
		private const string password = "PSCD.password";
		private const string proxy = "PSCD.proxy";
		private const string useMock = "PSCD.useMock";
		private const string serverUrl = "PSCD.serverUrl";
		private const string urlBpAnlegen = "PSCD.urlBpAnlegen";
		private const string urlBpMutieren = "PSCD.urlBpMutieren";
		private const string urlVgAnlegen = "PSCD.urlVgAnlegen";
		private const string urlVgMutieren = "PSCD.urlVgMutieren";
		private const string urlBuchungsstoffAnlegen = "PSCD.urlBuchungsstoffAnlegen";
		private const string urlBuchungsstoffMutieren = "PSCD.urlBuchungsstoffMutieren";
		private const string urlBuchungsstoffStornieren = "PSCD.urlBuchungsstoffStornieren";
		private const string urlKontenstandAbfrage = "PSCD.urlKontenstandAbfrage";
		private const string urlAusgleichsInfo = "PSCD.urlAusgleichsInfo";
        private const string urlWvStatus = "PSCD.urlWvStatus";
		private const string urlKlientenEinzahlungen = "PSCD.urlKlientenEinzahlungen";
        private const string urlKlientengelderSaldoHolen = "PSCD.urlKlientengelderSaldoHolen";
		private const string urlStadtEinzahlungen = "PSCD.urlStadtEinzahlungen";
		private const string urlUserSenden = "PSCD.urlUserSenden";
		private const string urlBpAnlegenAsync = "PSCD.urlBpAnlegenAsync";
		private const string urlBpMutierenAsync = "PSCD.urlBpMutierenAsync";
		private const string urlVgAnlegenAsync = "PSCD.urlVgAnlegenAsync";
		private const string urlVgMutierenAsync = "PSCD.urlVgMutierenAsync";
		private const string urlBelegAnlegenAsync = "PSCD.urlBelegAnlegenAsync";
		private const string urlBelegMutierenAsync = "PSCD.urlBelegMutierenAsync";
		private const string urlBelegStornierenAsync = "PSCD.urlBelegStornierenAsync";
        private const string urlMahnlaufStartenAsync = "PSCD.urlMahnlaufStartenAsync";
        private const string urlMahnungLesen = "PSCD.urlMahnungLesen";

		private const string serverUrlMock = "PSCD.serverUrlMock";
		private const string urlBpAnlegenMock = "PSCD.urlBpAnlegenMock";

		private const string alphaDsnName = "Alpha.DsnName";
		private const string alphaDriverName = "Alpha.DriverName";
		private const string alphaUserName = "Alpha.UserName";
		private const string alphaPassword = "Alpha.Password";

		#region KeyPaths

		private const string pathXIProxy = @"System\Schnittstellen\PSCD\XIProxy";
		private const string pathUseMock = @"System\Schnittstellen\PSCD\UseMock";
		private const string pathXIServerUrl = @"System\Schnittstellen\PSCD\XIServerUrl";
		private const string pathUrlBpAnlegen = @"System\Schnittstellen\PSCD\URLs\BpAnlegen";
		private const string pathUrlBpMutieren = @"System\Schnittstellen\PSCD\URLs\BpMutieren";
		private const string pathUrlVgAnlegen = @"System\Schnittstellen\PSCD\URLs\VgAnlegen";
		private const string pathUrlVgMutieren = @"System\Schnittstellen\PSCD\URLs\VgMutieren";
		private const string pathUrlBuchungsstoffAnlegen = @"System\Schnittstellen\PSCD\URLs\BuchungsstoffAnlegen";
		private const string pathUrlBuchungsstoffMutieren = @"System\Schnittstellen\PSCD\URLs\BuchungsstoffMutieren";
		private const string pathUrlBuchungsstoffStornieren = @"System\Schnittstellen\PSCD\URLs\BuchungsstoffStornieren";
		private const string pathUrlKontenstandAbfrage = @"System\Schnittstellen\PSCD\URLs\KontenstandAbfrage";
		private const string pathUrlAusgleichsInfo = @"System\Schnittstellen\PSCD\URLs\AusgleichsInfo";
        private const string pathUrlWvStatus = @"System\Schnittstellen\PSCD\URLs\WvStatus";
		private const string pathUrlKlientenEinzahlungen = @"System\Schnittstellen\PSCD\URLs\KlientenEinzahlungen";
        private const string pathUrlKlientengelderSaldoHolen = @"System\Schnittstellen\PSCD\URLs\KlientengelderSaldoHolen";
		private const string pathUrlStadtEinzahlungen = @"System\Schnittstellen\PSCD\URLs\StadtEinzahlungen";
		private const string pathUrlUserSenden = @"System\Schnittstellen\PSCD\URLs\UserSenden";
        private const string pathUrlMahnungLesen = @"System\Schnittstellen\PSCD\URLs\MahnungLesen";
        private const string pathUrlBpAnlegenAsync = @"System\Schnittstellen\PSCD\URLs\Async\BpAnlegen";
		private const string pathUrlBpMutierenAsync = @"System\Schnittstellen\PSCD\URLs\Async\BpMutieren";
		private const string pathUrlVgAnlegenAsync = @"System\Schnittstellen\PSCD\URLs\Async\VgAnlegen";
		private const string pathUrlVgMutierenAsync = @"System\Schnittstellen\PSCD\URLs\Async\VgMutieren";
		private const string pathUrlBelegAnlegenAsync = @"System\Schnittstellen\PSCD\URLs\Async\BelegAnlegen";
		private const string pathUrlBelegMutierenAsync = @"System\Schnittstellen\PSCD\URLs\Async\BelegMutieren";
		private const string pathUrlBelegStornierenAsync = @"System\Schnittstellen\PSCD\URLs\Async\BelegStornieren";
        private const string pathUrlMahnlaufStartenAsync = @"System\Schnittstellen\PSCD\URLs\Async\MahnlaufStarten";

		private const string pathServerUrlMock = @"";
		private const string pathUrlBpAnlegenMock = @"";

		private const string pathAlphaDsnName = @"System\Schnittstellen\Alpha\DSN";
		private const string pathAlphaDriverName = @"System\Schnittstellen\Alpha\Driver";
		private const string pathAlphaUserName = @"System\Schnittstellen\Alpha\UserName";
		private const string pathAlphaPassword = @"System\Schnittstellen\Alpha\Password";

		#endregion

		#region ISettingsAccessor Members


		public WebConfigSettings()
		{
		}

		private static string GetValueVarchar(string xconfigKeyPath, string webconfigKey)
		{
			string configValue = XConfigBLL.GetConfigValueVarchar(xconfigKeyPath);
			if (string.IsNullOrEmpty(configValue))
				return ConfigurationManager.AppSettings[webconfigKey];
			else
				return configValue;
		}

		#region PSCD

		public string PSCDUserName
		{
			get
			{
				return Decrypt(ConfigurationManager.AppSettings[username]);
			}
		}

		public string PSCDPassword
		{
			get
			{
				return Decrypt(ConfigurationManager.AppSettings[password]);
			}
		}

		public string PSCDProxy
		{
			get { return GetValueVarchar(pathXIProxy, proxy); }
		}

		public bool PSCDUseMock
		{
			get
			{
				bool useMock = false;
				if (bool.TryParse(ConfigurationManager.AppSettings[WebConfigSettings.useMock], out useMock))
				{
					return useMock;
				}
				return false;
				//return bool.Parse(ConfigurationManager.AppSettings[useMock]);
			}
		}

		public string PSCDServerUrl
		{
			get { return GetValueVarchar(pathXIServerUrl, serverUrl); }
		}

		public string PscdBpAnlegenURL
		{
			get { return GetValueVarchar(pathUrlBpAnlegen, urlBpAnlegen); }
		}

		public string PscdBpMutierenURL
		{
			get { return GetValueVarchar(pathUrlBpMutieren, urlBpMutieren); }
		}

		public string PscdVgAnlegenURL
		{
			get { return GetValueVarchar(pathUrlVgAnlegen, urlVgAnlegen); }
		}

		public string PscdVgMutierenURL
		{
			get { return GetValueVarchar(pathUrlVgMutieren, urlVgMutieren); }
		}

		public string PscdBuchungsstoffAnlegenURL
		{
			get { return GetValueVarchar(pathUrlBuchungsstoffAnlegen, urlBuchungsstoffAnlegen); }
		}

		public string PscdBuchungsstoffMutierenURL
		{
			get { return GetValueVarchar(pathUrlBuchungsstoffMutieren, urlBuchungsstoffMutieren); }
		}

		public string PscdBuchungsstoffStornierenURL
		{
			get { return GetValueVarchar(pathUrlBuchungsstoffStornieren, urlBuchungsstoffStornieren); }
		}

		public string PscdKontenstandAbfrageURL
		{
			get { return GetValueVarchar(pathUrlKontenstandAbfrage, urlKontenstandAbfrage); }
		}

		public string PSCDAusgleichsInfoURL
		{
			get { return GetValueVarchar(pathUrlAusgleichsInfo, urlAusgleichsInfo); }
		}

        public string PSCDWvStatusURL
        {
            get { return GetValueVarchar(pathUrlWvStatus, urlWvStatus); }
        }

		public string PSCDServerUrlMock
		{
			get { return GetValueVarchar(pathServerUrlMock, serverUrlMock); }
		}

		public string PSCDBpAnlegenMockUrl
		{
			get { return GetValueVarchar(pathUrlBpAnlegenMock, urlBpAnlegenMock); }
		}

		public string PSCDKlientEinzahlungenUrl
		{
			get { return GetValueVarchar(pathUrlKlientenEinzahlungen, urlKlientenEinzahlungen); }
		}

        public string PSCDKlientengelderSaldoHolenUrl
        {
            get { return GetValueVarchar(pathUrlKlientengelderSaldoHolen, urlKlientengelderSaldoHolen); }
        }

		public string PSCDStadtEinzahlungenUrl
		{
			get { return GetValueVarchar(pathUrlStadtEinzahlungen, urlStadtEinzahlungen); }
		}

		public string PSCDUserSendenUrl
		{
			get { return GetValueVarchar(pathUrlUserSenden, urlUserSenden); }
		}

        public string PSCDMahnungLesenUrl
        {
            get { return GetValueVarchar(pathUrlMahnungLesen, urlMahnungLesen); }
        }

		#region Async

		public string PscdBpAnlegenURLAsync
		{
			get { return GetValueVarchar(pathUrlBpAnlegenAsync, urlBpAnlegenAsync); }
		}

		public string PscdBpMutierenURLAsync
		{
			get { return GetValueVarchar(pathUrlBpMutierenAsync, urlBpMutierenAsync); }
		}

		public string PscdVgAnlegenURLAsync
		{
			get { return GetValueVarchar(pathUrlVgAnlegenAsync, urlVgAnlegenAsync); }
		}

		public string PscdVgMutierenURLAsync
		{
			get { return GetValueVarchar(pathUrlVgMutierenAsync, urlVgMutierenAsync); }
		}

		public string PscdBelegAnlegenURLAsync
		{
			get { return GetValueVarchar(pathUrlBelegAnlegenAsync, urlBelegAnlegenAsync); }
		}

		public string PscdBelegMutierenURLAsync
		{
			get { return GetValueVarchar(pathUrlBelegMutierenAsync, urlBelegMutierenAsync); }
		}

		public string PscdBelegStornierenURLAsync
		{
			get { return GetValueVarchar(pathUrlBelegStornierenAsync, urlBelegStornierenAsync); }
		}

        public string PscdMahnlaufStartenURLAsync
        {
            get { return GetValueVarchar(pathUrlMahnlaufStartenAsync, urlMahnlaufStartenAsync); }
        }

		#endregion

		private string Decrypt(string encrypted)
		{
			if (!string.IsNullOrEmpty(encrypted))
			{
				Scrambler scrambler = new Scrambler("KiSS4");
				try
				{
					return scrambler.DecryptString(encrypted);
				}
				catch
				{
					return encrypted;
				}
			}
			return null;
		}

		#endregion

		#region Alpha

		public string AlphaDsnName
		{
			get { return GetValueVarchar(pathAlphaDsnName, alphaDsnName); }
		}

		public string AlphaDriverName
		{
			get { return GetValueVarchar(pathAlphaDriverName, alphaDriverName); }
		}

		public string AlphaUserName
		{
			get { return GetValueVarchar(pathAlphaUserName, alphaUserName); }
		}

		public string AlphaPassword
		{
			get { return Decrypt(GetValueVarchar(pathAlphaPassword, alphaPassword)); }
		}

		#endregion

		#endregion
	}
}
