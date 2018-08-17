using System;
using System.Collections.Generic;
using System.Text;

namespace KiSSSvc.SAP.PSCD.WebServiceHelper.Settings
{
	public class ConnectionSettings
	{
		#region Properties
		string serverUrl;
		public string ServerUrl
		{
			get
			{
				return serverUrl;
			}
			set
			{
				if (value != null)
				{
					if (!value.EndsWith("/"))
					{
						value += "/";
					}
					serverUrl = value;
				}
			}
		}

		string urlBpAnlegen;
		public string UrlBpAnlegen
		{
			get
			{
				return urlBpAnlegen;
			}
			set
			{
				urlBpAnlegen = value;
			}
		}


		string urlBpMutieren;
		public string UrlBpMutieren
		{
			get
			{
				return urlBpMutieren;
			}
			set
			{
				urlBpMutieren = value;
			}
		}

		string urlVgAnlegen;
		public string UrlVgAnlegen
		{
			get
			{
				return urlVgAnlegen;
			}
			set
			{
				urlVgAnlegen = value;
			}
		}

		string urlVgMutieren;
		public string UrlVgMutieren
		{
			get
			{
				return urlVgMutieren;
			}
			set
			{
				urlVgMutieren = value;
			}
		}

		string urlBuchungsstoffAnlegen;
		public string UrlBuchungsstoffAnlegen
		{
			get
			{
				return urlBuchungsstoffAnlegen;
			}
			set
			{
				urlBuchungsstoffAnlegen = value;
			}
		}

		string urlBuchungsstoffMutieren;
		public string UrlBuchungsstoffMutieren
		{
			get
			{
				return urlBuchungsstoffMutieren;
			}
			set
			{
				urlBuchungsstoffMutieren = value;
			}
		}

		string urlBuchungsstoffStornieren;
		public string UrlBuchungsstoffStornieren
		{
			get
			{
				return urlBuchungsstoffStornieren;
			}
			set
			{
				urlBuchungsstoffStornieren = value;
			}
		}

		string urlKontenstandAbfrage;
		public string UrlKontenstandAbfrage
		{
			get
			{
				return urlKontenstandAbfrage;
			}
			set
			{
				urlKontenstandAbfrage = value;
			}
		}

		string urlAusgleichsInfo;
		public string UrlAusgleichsInfo
		{
			get
			{
				return urlAusgleichsInfo;
			}
			set
			{
				urlAusgleichsInfo = value;
			}
		}

        string urlWvStatus;
        public string UrlWvStatus
        {
            get
            {
                return urlWvStatus;
            }
            set
            {
                urlWvStatus = value;
            }
        }

		string urlKlientEinzahlungen;
		public string UrlKlientEinzahlungen
		{
			get
			{
				return urlKlientEinzahlungen;
			}
			set
			{
				urlKlientEinzahlungen = value;
			}
		}

        string urlKlientengelderSaldoHolen;
        public string UrlKlientengelderSaldoHolen
        {
            get
            {
                return urlKlientengelderSaldoHolen;
            }
            set
            {
                urlKlientengelderSaldoHolen = value;
            }
        }

		string urlStadtEinzahlungen;
		public string UrlStadtEinzahlungen
		{
			get
			{
				return urlStadtEinzahlungen;
			}
			set
			{
				urlStadtEinzahlungen = value;
			}
		}

		string urlUserSenden;
		public string UrlUserSenden
		{
			get
			{
				return urlUserSenden;
			}
			set
			{
				urlUserSenden = value;
			}
		}

        string urlMahnungLesen;
        public string UrlMahnungLesen
        {
            get
            {
                return urlMahnungLesen;
            }
            set
            {
                urlMahnungLesen = value;
            }
        }

		#endregion

		#region Async

		string urlBpAnlegenAsync;
		public string UrlBpAnlegenAsync
		{
			get
			{
				return urlBpAnlegenAsync;
			}
			set
			{
				urlBpAnlegenAsync = value;
			}
		}

		string urlBpMutierenAsync;
		public string UrlBpMutierenAsync
		{
			get
			{
				return urlBpMutierenAsync;
			}
			set
			{
				urlBpMutierenAsync = value;
			}
		}

		string urlVgAnlegenAsync;
		public string UrlVgAnlegenAsync
		{
			get
			{
				return urlVgAnlegenAsync;
			}
			set
			{
				urlVgAnlegenAsync = value;
			}
		}

		string urlVgMutierenAsync;
		public string UrlVgMutierenAsync
		{
			get
			{
				return urlVgMutierenAsync;
			}
			set
			{
				urlVgMutierenAsync = value;
			}
		}

		string urlBelegAnlegenAsync;
		public string UrlBelegAnlegenAsync
		{
			get
			{
				return urlBelegAnlegenAsync;
			}
			set
			{
				urlBelegAnlegenAsync = value;
			}
		}

		string urlBelegMutierenAsync;
		public string UrlBelegMutierenAsync
		{
			get
			{
				return urlBelegMutierenAsync;
			}
			set
			{
				urlBelegMutierenAsync = value;
			}
		}

		string urlBelegStornierenAsync;
		public string UrlBelegStornierenAsync
		{
			get
			{
				return urlBelegStornierenAsync;
			}
			set
			{
				urlBelegStornierenAsync = value;
			}
		}

        string urlMahnlaufStartenAsync;
        public string UrlMahnlaufStartenAsync
        {
            get
            {
                return urlMahnlaufStartenAsync;
            }
            set
            {
                urlMahnlaufStartenAsync = value;
            }
        }

		#endregion
	}
}
