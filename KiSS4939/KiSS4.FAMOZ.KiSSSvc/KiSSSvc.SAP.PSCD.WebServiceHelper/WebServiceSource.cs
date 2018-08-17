using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Services.Protocols;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.BpAnlegen;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.VgAnlegen;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.VgMutieren;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.BuchungsstoffAnlegen;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.AusgleichLesen;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.WvStatusRueckmeldung;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.BpMutieren;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.BuchungsstoffStornieren;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.BuchungsstoffMutieren;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.EinzahlungenKlienten;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.KlientengelderSaldoLesen;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.EinzahlungenStadt;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.UserSenden;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.MahnungLesen;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.Async.BpAnlegen;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.Async.BelegSenden;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.Async.BpMutieren;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.Async.VertragsgegenstandAnlegen;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.Async.VertragsgegenstandMutieren;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.Async.BelegMutieren;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.Async.BelegStornieren;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.Async.MahnlaufStarten;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.FAMOZ2Test;



namespace KiSSSvc.SAP.PSCD.WebServiceHelper.Settings
{
	public static class WebServiceSource
	{
		public static MI_BUDGET_DATA001Service GetBpAnlegenWS()
		{
			MI_BUDGET_DATA001Service ws = new MI_BUDGET_DATA001Service();
			SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdBpAnlegenURL);
			return ws;
		}

		public static MI_BUDGET_DATA002Service GetBpMutierenWS()
		{
			MI_BUDGET_DATA002Service ws = new MI_BUDGET_DATA002Service();
			SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdBpMutierenURL);
			return ws;
		}

		public static MI_BUDGET_DATA001_VGService GetVgAnlegenWS()
		{
			MI_BUDGET_DATA001_VGService ws = new MI_BUDGET_DATA001_VGService();
			SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdVgAnlegenURL);
			return ws;
		}

		public static MI_BUDGET_DATA002_VGService GetVgMutierenWS()
		{
			MI_BUDGET_DATA002_VGService ws = new MI_BUDGET_DATA002_VGService();
			SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdVgMutierenURL);
			return ws;
		}

		public static MI_KISS_BUCHSTOFF001Service GetBuchungsstoffAnlegenWS()
		{
			MI_KISS_BUCHSTOFF001Service ws = new MI_KISS_BUCHSTOFF001Service();
			SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdBuchungsstoffAnlegenURL);
			return ws;
		}

		public static MI_KISS_BUCHSTOFF002Service GetBuchungsstoffMutierenWS()
		{
			MI_KISS_BUCHSTOFF002Service ws = new MI_KISS_BUCHSTOFF002Service();
			SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdBuchungsstoffMutierenURL);
			return ws;
		}

        public static MI_KISS_BUCHSTOFF003Service GetBuchungsstoffStornierenWS()
        {
            MI_KISS_BUCHSTOFF003Service ws = new MI_KISS_BUCHSTOFF003Service();
            SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
            WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdBuchungsstoffStornierenURL);
            return ws;
        }

        public static MI_SD01_CREATE_WSService GetFAMOZ2TestWS()
        {
            MI_SD01_CREATE_WSService ws = new MI_SD01_CREATE_WSService();
            SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
            WebServiceHelperMethods.InitWebService(ref svc, "http://szhm2179.stzh.ch:8001/XISOAPAdapter/MessageServlet?channel=:BSV_FAMOZ_SD01_WS_OUT:CC_SD01_WS_OUT&version=3.0&Sender.Service=BSV_FAMOZ_SD01_WS_OUT&Interface=http://stzh.ch/FAMOZ_SD01_CREATE_WS^MI_SD01_CREATE_WS");
            return ws;
        }

        #region Trigger

		public static MI_AUSGL_SENDEN_NEWService GetAusgleichHolenWS()
		{
			MI_AUSGL_SENDEN_NEWService ws = new MI_AUSGL_SENDEN_NEWService();
			SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdAusgleichsInfoURL);
			return ws;
		}

        public static MI_WV_FAKTURAService GetWvStatusHolenWS()
        {
            MI_WV_FAKTURAService ws = new MI_WV_FAKTURAService();
            SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
            WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdWvStatusURL);
            return ws;
        }

		public static MI_KLIENTEN_EINZAHLService GetKlientenEinzahlungenWS()
		{
			MI_KLIENTEN_EINZAHLService ws = new MI_KLIENTEN_EINZAHLService();
			SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdKlientEinzahlungenURL);
			return ws;
		}

        public static MI_KLIENTEN_EINZAHL_KOPFService GetKlientengelderSaldoHolenWS()
        {
            MI_KLIENTEN_EINZAHL_KOPFService ws = new MI_KLIENTEN_EINZAHL_KOPFService();
            SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
            WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdKlientengelderSaldoHolenURL);
            return ws;
        }

		public static MI_STADT_EINZAHLService GetStadtEinzahlungenWS()
		{
			MI_STADT_EINZAHLService ws = new MI_STADT_EINZAHLService();
			SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdStadtEinzahlungenURL);
			return ws;
		}


		public static MI_KISS_ANSPER_UPDATEService GetUserSendenWS()
		{
			MI_KISS_ANSPER_UPDATEService ws = new MI_KISS_ANSPER_UPDATEService();
			SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdUserSendenURL);
			return ws;
		}

        public static MI_READ_MAHNSService GetMahnungLesenWS()
        {
            MI_READ_MAHNSService ws = new MI_READ_MAHNSService();
            SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdMahnunLesenURL);
			return ws;
        }


		#endregion

		#region Async

		public static MI_BUDGET_CREA_SOAP_OUTService GetBpAnlegenAsyncWS()
		{
			MI_BUDGET_CREA_SOAP_OUTService ws = new MI_BUDGET_CREA_SOAP_OUTService();
			SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdBpAnlegenURLAsync);
			return ws;
		}

		public static MI_BUDGET_CHG_SOAP_OUTService GetBpMutierenAsyncWS()
		{
			MI_BUDGET_CHG_SOAP_OUTService ws = new MI_BUDGET_CHG_SOAP_OUTService();
			SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdBpMutierenURLAsync);
			return ws;
		}

		public static MI_BUDGET_CREA_VG_SOAP_OUTService GetVgAnlegenAsyncWS()
		{
			MI_BUDGET_CREA_VG_SOAP_OUTService ws = new MI_BUDGET_CREA_VG_SOAP_OUTService();
			SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdVgAnlegenURLAsync);
			return ws;
		}

		public static MI_BUDGET_CHG_VG_SOAP_OUTService GetVgMutierenAsyncWS()
		{
			MI_BUDGET_CHG_VG_SOAP_OUTService ws = new MI_BUDGET_CHG_VG_SOAP_OUTService();
			SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdVgMutierenURLAsync);
			return ws;
		}

		public static MI_BUCHSTOFF_CREA_SOAP_OUTService GetBelegAnlegenAsyncWS()
		{
			MI_BUCHSTOFF_CREA_SOAP_OUTService ws = new MI_BUCHSTOFF_CREA_SOAP_OUTService();
			SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdBelegAnlegenAsync);
			return ws;
		}

		public static MI_BUCHSTOFF_CHG_SOAP_OUTService GetBelegMutierenAsyncWS()
		{
			MI_BUCHSTOFF_CHG_SOAP_OUTService ws = new MI_BUCHSTOFF_CHG_SOAP_OUTService();
			SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdBelegMutierenAsync);
			return ws;
		}

		public static MI_BUCHSTOFF_STO_SOAP_OUTService GetBelegStornierenAsyncWS()
		{
			MI_BUCHSTOFF_STO_SOAP_OUTService ws = new MI_BUCHSTOFF_STO_SOAP_OUTService();
			SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
			WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdBelegStornierenAsync);
			return ws;
		}

        public static MI_KISS_ANSTOSS_MAHN_SOAP_OUTService GetMahnlaufStartenAsyncWS()
        {
            MI_KISS_ANSTOSS_MAHN_SOAP_OUTService ws = new MI_KISS_ANSTOSS_MAHN_SOAP_OUTService();
            SoapHttpClientProtocol svc = ws as SoapHttpClientProtocol;
            WebServiceHelperMethods.InitWebService(ref svc, WebServiceHelperMethods.GetSettings().PscdMahnlaufStartenAsync);
            return ws;
        }

		#endregion
	}
}
