using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Services.Protocols;
using Kiss.Server.PSCD.WS.PscdWsProxy;
using System.Net;
using Kiss.Server.PSCD.WS.ZahlungseingaengeAbholenProxy;



namespace KiSSSvc.SAP.PSCD.WebServiceHelper.Settings
{
    public static class WebServiceSource
    {
        public static MI_SD01_CREATE_WSService GetBelegAnlegenWS()
        {
            var settings = GetSettings();    
                     
           
            var ws = new MI_SD01_CREATE_WSService();            
            ws.Url = settings.PSCD_URL_BELEG_ANLEGEN;

            NetworkCredential cred = new NetworkCredential(settings.PSCDUsername, settings.PSCDPassword);
            Uri uri = new Uri(ws.Url);
            ICredentials creds = cred.GetCredential(uri, "Basic");
            ws.Credentials = creds;

            ws.PreAuthenticate = true;

            return ws;
        }


        public static MI_SD02_CREATE_WSService GetZahlungseingaengeAbholenWS()
        {
            var settings = GetSettings();    

            var ws = new MI_SD02_CREATE_WSService();
            ws.Url = settings.PSCD_URL_ZAHLUNGSEINGAENGE_ABHOLEN;

            NetworkCredential cred = new NetworkCredential(settings.PSCDUsername, settings.PSCDPassword);
            Uri uri = new Uri(ws.Url);
            ICredentials creds = cred.GetCredential(uri, "Basic");
            ws.Credentials = creds;

            ws.PreAuthenticate = true;

            return ws;
        }


        internal static Kiss.Server.PSCD.WS.Properties.Settings GetSettings()
        {
            Kiss.Server.PSCD.WS.Properties.Settings settings = Kiss.Server.PSCD.WS.Properties.Settings.Default;
            return settings;
        }

    }
}
