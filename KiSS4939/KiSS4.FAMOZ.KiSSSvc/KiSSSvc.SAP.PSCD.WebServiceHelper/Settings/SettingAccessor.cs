using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using KiSSSvc.Logging;

namespace KiSSSvc.SAP.PSCD.WebServiceHelper.Settings
{
	public class SettingsAccessor
	{
		#region Variables

		string pscdUsername;
		string pscdPassword;
		string pscdProxy;

		/// <summary>
		/// For debugging purpose we can send the SOAP messages to a mock server
		/// </summary>
		bool useMock = false;
		ConnectionSettings xiConnectionSettings = new ConnectionSettings();
		ConnectionSettings mockConnectionSettings = new ConnectionSettings();
		/// <summary>
		/// Pointer to the Connection that is being used
		/// </summary>
		ConnectionSettings activeConnection;

		WebConfigSettings settings;

		#endregion

		public SettingsAccessor()
		{
			settings = new WebConfigSettings();
			// Test logging
			//Log.Info(this.GetType(), "Settings loaded");

			pscdUsername = settings.PSCDUserName;
			pscdPassword = settings.PSCDPassword;
			pscdProxy    = settings.PSCDProxy;

			xiConnectionSettings.ServerUrl                  = settings.PSCDServerUrl;
			xiConnectionSettings.UrlBpAnlegen               = settings.PscdBpAnlegenURL;
			xiConnectionSettings.UrlBpMutieren              = settings.PscdBpMutierenURL;
			xiConnectionSettings.UrlVgAnlegen               = settings.PscdVgAnlegenURL;
			xiConnectionSettings.UrlVgMutieren              = settings.PscdVgMutierenURL;
			xiConnectionSettings.UrlBuchungsstoffAnlegen    = settings.PscdBuchungsstoffAnlegenURL;
			xiConnectionSettings.UrlBuchungsstoffMutieren   = settings.PscdBuchungsstoffMutierenURL;
			xiConnectionSettings.UrlBuchungsstoffStornieren = settings.PscdBuchungsstoffStornierenURL;
			xiConnectionSettings.UrlKontenstandAbfrage      = settings.PscdKontenstandAbfrageURL;
            xiConnectionSettings.UrlAusgleichsInfo          = settings.PSCDAusgleichsInfoURL;
            xiConnectionSettings.UrlWvStatus                = settings.PSCDWvStatusURL;
			xiConnectionSettings.UrlUserSenden              = settings.PSCDUserSendenUrl;

			xiConnectionSettings.UrlKlientEinzahlungen = settings.PSCDKlientEinzahlungenUrl;
            xiConnectionSettings.UrlKlientengelderSaldoHolen = settings.PSCDKlientengelderSaldoHolenUrl;
			xiConnectionSettings.UrlStadtEinzahlungen  = settings.PSCDStadtEinzahlungenUrl;
            xiConnectionSettings.UrlMahnungLesen = settings.PSCDMahnungLesenUrl;

			xiConnectionSettings.UrlBpAnlegenAsync = settings.PscdBpAnlegenURLAsync;
			xiConnectionSettings.UrlBpMutierenAsync = settings.PscdBpMutierenURLAsync;
			xiConnectionSettings.UrlVgAnlegenAsync = settings.PscdVgAnlegenURLAsync;
			xiConnectionSettings.UrlVgMutierenAsync = settings.PscdVgMutierenURLAsync;
			xiConnectionSettings.UrlBelegAnlegenAsync = settings.PscdBelegAnlegenURLAsync;
			xiConnectionSettings.UrlBelegMutierenAsync = settings.PscdBelegMutierenURLAsync;
			xiConnectionSettings.UrlBelegStornierenAsync = settings.PscdBelegStornierenURLAsync;
            xiConnectionSettings.UrlMahnlaufStartenAsync = settings.PscdMahnlaufStartenURLAsync;

			mockConnectionSettings.ServerUrl = settings.PSCDServerUrlMock;
			mockConnectionSettings.UrlBpAnlegen = settings.PSCDBpAnlegenMockUrl;

			PSCDUseMock = settings.PSCDUseMock;
		}


		#region Properties

		#region PSCD

		public string PSCDUserName
		{
			get
			{
				return pscdUsername;
			}
			set
			{
				pscdUsername = value;
			}
		}

		public string PSCDPassword
		{
			get
			{
				return pscdPassword;
			}
			set
			{
				pscdPassword = value;
			}
		}

		public string PSCDProxy
		{
			get
			{
				return pscdProxy;
			}
			set
			{
				pscdProxy = value;
			}
		}

		public bool PSCDUseMock
		{
			get
			{
				return useMock;
			}
			set
			{
				useMock = value;
				if (value)
				{
					activeConnection = mockConnectionSettings;
				}
				else
				{
					activeConnection = xiConnectionSettings;
				}
			}
		}

		public string PSCDServerUrl
		{
			get
			{
				return activeConnection.ServerUrl;
			}
			set
			{
				if (!value.EndsWith("/"))
				{
					value += "/";
				}
				activeConnection.ServerUrl = value;
			}
		}

		public string PscdBpAnlegenURL
		{
			get
			{
				return activeConnection.UrlBpAnlegen;
			}
			set
			{
				activeConnection.UrlBpAnlegen = value;
			}
		}

		public string PscdBpMutierenURL
		{
			get
			{
				return activeConnection.UrlBpMutieren;
			}
			set
			{
				activeConnection.UrlBpMutieren = value;
			}
		}

		public string PscdVgAnlegenURL
		{
			get
			{
				return activeConnection.UrlVgAnlegen;
			}
			set
			{
				activeConnection.UrlVgAnlegen = value;
			}
		}

		public string PscdVgMutierenURL
		{
			get
			{
				return activeConnection.UrlVgMutieren;
			}
			set
			{
				activeConnection.UrlVgMutieren = value;
			}
		}

		public string PscdBuchungsstoffAnlegenURL
		{
			get
			{
				return activeConnection.UrlBuchungsstoffAnlegen;
			}
			set
			{
				activeConnection.UrlBuchungsstoffAnlegen = value;
			}
		}

		public string PscdBuchungsstoffMutierenURL
		{
			get
			{
				return activeConnection.UrlBuchungsstoffMutieren;
			}
			set
			{
				activeConnection.UrlBuchungsstoffMutieren = value;
			}
		}

		public string PscdBuchungsstoffStornierenURL
		{
			get
			{
				return activeConnection.UrlBuchungsstoffStornieren;
			}
			set
			{
				activeConnection.UrlBuchungsstoffStornieren = value;
			}
		}

		public string PscdKontenstandAbfrageURL
		{
			get
			{
				return activeConnection.UrlKontenstandAbfrage;
			}
			set
			{
				activeConnection.UrlKontenstandAbfrage = value;
			}
		}

		public string PscdAusgleichsInfoURL
		{
			get
			{
				return activeConnection.UrlAusgleichsInfo;
			}
			set
			{
				activeConnection.UrlAusgleichsInfo = value;
			}
		}

        public string PscdWvStatusURL
        {
            get
            {
                return activeConnection.UrlWvStatus;
            }
            set
            {
                activeConnection.UrlWvStatus = value;
            }
        }

		public string PscdKlientEinzahlungenURL
		{
			get
			{
				return activeConnection.UrlKlientEinzahlungen;
			}
			set
			{
				activeConnection.UrlKlientEinzahlungen = value;
			}
		}

        public string PscdKlientengelderSaldoHolenURL
        {
            get
            {
                return activeConnection.UrlKlientengelderSaldoHolen;
            }
            set
            {
                activeConnection.UrlKlientengelderSaldoHolen = value;
            }
        }

		public string PscdStadtEinzahlungenURL
		{
			get
			{
				return activeConnection.UrlStadtEinzahlungen;
			}
			set
			{
				activeConnection.UrlStadtEinzahlungen = value;
			}
		}

		public string PscdUserSendenURL
		{
			get
			{
				return activeConnection.UrlUserSenden;
			}
			set
			{
				activeConnection.UrlUserSenden = value;
			}
		}

        public string PscdMahnunLesenURL
        {
            get
            {
                return activeConnection.UrlMahnungLesen;
            }
            set
            {
                activeConnection.UrlMahnungLesen = value;
            }
        }

		#region Async

		public string PscdBpAnlegenURLAsync
		{
			get
			{
				return activeConnection.UrlBpAnlegenAsync;
			}
			set
			{
				activeConnection.UrlBpAnlegenAsync = value;
			}
		}

		public string PscdBpMutierenURLAsync
		{
			get
			{
				return activeConnection.UrlBpMutierenAsync;
			}
			set
			{
				activeConnection.UrlBpMutierenAsync = value;
			}
		}

		public string PscdVgAnlegenURLAsync
		{
			get
			{
				return activeConnection.UrlVgAnlegenAsync;
			}
			set
			{
				activeConnection.UrlVgAnlegenAsync = value;
			}
		}

		public string PscdVgMutierenURLAsync
		{
			get
			{
				return activeConnection.UrlVgMutierenAsync;
			}
			set
			{
				activeConnection.UrlVgMutierenAsync = value;
			}
		}

		public string PscdBelegAnlegenAsync
		{
			get
			{
				return activeConnection.UrlBelegAnlegenAsync;
			}
			set
			{
				activeConnection.UrlBelegAnlegenAsync = value;
			}
		}

		public string PscdBelegMutierenAsync
		{
			get
			{
				return activeConnection.UrlBelegMutierenAsync;
			}
			set
			{
				activeConnection.UrlBelegMutierenAsync = value;
			}
		}

		public string PscdBelegStornierenAsync
		{
			get
			{
				return activeConnection.UrlBelegStornierenAsync;
			}
			set
			{
				activeConnection.UrlBelegStornierenAsync = value;
			}
		}

        public string PscdMahnlaufStartenAsync
        {
            get
            {
                return activeConnection.UrlMahnlaufStartenAsync;
            }
            set
            {
                activeConnection.UrlMahnlaufStartenAsync = value;
            }
        }


		#endregion

		#endregion

		#region Alpha

		public string AlphaDsnName
		{
			get { return settings.AlphaDsnName; }
		}

		public string AlphaDriverName
		{
			get { return settings.AlphaDriverName; }
		}

		public string AlphaUserName
		{
			get { return settings.AlphaUserName; }
		}

		public string AlphaPassword
		{
			get { return settings.AlphaPassword; }
		}

		#endregion		

		#endregion

	}
}