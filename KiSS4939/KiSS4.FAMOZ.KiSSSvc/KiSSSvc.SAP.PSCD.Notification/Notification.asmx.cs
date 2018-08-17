using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using KiSSSvc.SAP.PSCD.InfoFetcher;
using KiSSSvc.Logging;
using KiSSSvc.SAP.PSCD.WebServiceHelper;

namespace KiSSSvc.SAP.PSCD.Notification
{
	/// <summary>
	/// Summary description for Service1
	/// </summary>
	[WebService(Namespace = "http://www.born.ch/KiSS/FAMOZ/PSCD/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	public class NotificationSvc : System.Web.Services.WebService
	{
        private enum NotificationTypes
        {
            UNBEKANNT,
            AUSGLEICH,
            AUSGLEICH_LEICHEN,
            STADT_EINZAHL,
            KLIENTEN_EINZAHL,
            KLIENTEN_EINZAHL_LEICHEN,
            KLIENTEN_SALDO_LESEN,
            USER_SENDEN,
            WV_STATUS,
            MAHNUNG_LESEN,
        }

        private static List<NotificationTypes> m_ActiveNotificationProcessing = new List<NotificationTypes>();

        private static NotificationTypes ParseNotification(string notificationType)
        {
            if (string.IsNullOrEmpty(notificationType))
                return NotificationTypes.UNBEKANNT;
            else if (notificationType.ToUpper() == "AUSGLEICH")
                return NotificationTypes.AUSGLEICH;
            else if (notificationType.ToUpper() == "AUSGLEICH_LEICHEN")
                return NotificationTypes.AUSGLEICH_LEICHEN;
            else if (notificationType.ToUpper() == "STADT_EINZAHL")
                return NotificationTypes.STADT_EINZAHL;
            else if (notificationType.ToUpper() == "KLIENTEN_EINZAHL")
                return NotificationTypes.KLIENTEN_EINZAHL;
            else if (notificationType.ToUpper() == "KLIENTEN_EINZAHL_LEICHEN")
                return NotificationTypes.KLIENTEN_EINZAHL_LEICHEN;
            else if (notificationType.ToUpper() == "KLIENTEN_SALDO_LESEN")
                return NotificationTypes.KLIENTEN_SALDO_LESEN;
            else if (notificationType.ToUpper() == "USER_SENDEN")
                return NotificationTypes.USER_SENDEN;
            else if (notificationType.ToUpper() == "WV_STATUS")
                return NotificationTypes.WV_STATUS;
            else if (notificationType.ToUpper() == "MAHNUNG_LESEN")
                return NotificationTypes.MAHNUNG_LESEN;
            else
                return NotificationTypes.UNBEKANNT;
        }

		[WebMethod]
		public string NotifyAboutSAPDataReady(string type, int id)
		{
            Log.Info(this.GetType(), string.Format("NotifyAboutSAPDataReady: Message received: notificationType '{0}', id '{1}'", type, id));

            NotificationTypes notificationType = ParseNotification(type);

            lock(m_ActiveNotificationProcessing)
            {
                if (m_ActiveNotificationProcessing.Contains(notificationType))
                {
                    // Diese Art von Processing ist bereits am laufen, nothing to do here
                    return "Ein Verarbeitungsprozess für die Notifizierungsart " + type + " läuft bereits";
                }

                // Wir starten die Verarbeitung dieser Notifizierung
                m_ActiveNotificationProcessing.Add(notificationType);
            }

            try
            {
                if (WebServiceHelperMethods.CheckDBConnection())
                {
                    try
                    {
                        switch (notificationType)
                        {
                            case NotificationTypes.AUSGLEICH:
                                {
                                    SettlementInfoFetcher svc = new SettlementInfoFetcher();
                                    svc.FetchSettlementInfo(false);
                                    break;
                                }
                            case NotificationTypes.AUSGLEICH_LEICHEN:
                                {
                                    SettlementInfoFetcher svc = new SettlementInfoFetcher();
                                    svc.FetchSettlementInfo(true);
                                    break;
                                }
                            case NotificationTypes.STADT_EINZAHL:
                                {
                                    StadtEinzahlungenFetcher svc = new StadtEinzahlungenFetcher();
                                    svc.FetchEinzahlungenInfo();
                                    break;
                                }
                            case NotificationTypes.KLIENTEN_EINZAHL:
                                {
                                    KlientenEinzahlungenFetcher svc = new KlientenEinzahlungenFetcher();
                                    svc.FetchEinzahlungenInfo(false);
                                    break;
                                }
                            case NotificationTypes.KLIENTEN_EINZAHL_LEICHEN:
                                {
                                    KlientenEinzahlungenFetcher svc = new KlientenEinzahlungenFetcher();
                                    svc.FetchEinzahlungenInfo(true);
                                    break;
                                }
                            case NotificationTypes.KLIENTEN_SALDO_LESEN:
                                {
                                    KlientengelderSaldoFetcher svc = new KlientengelderSaldoFetcher();
                                    svc.FetchKlientengelderSaldos(false);
                                    break;
                                }
                            case NotificationTypes.USER_SENDEN:
                                {
                                    UserSenden svc = new UserSenden();
                                    svc.SendUsers();
                                    break;
                                }
                            case NotificationTypes.WV_STATUS:
                                {
                                    WvStatusFetcher svc = new WvStatusFetcher();
                                    svc.FetchWvStatus(false);
                                    break;
                                }
                            case NotificationTypes.MAHNUNG_LESEN:
                                {
                                    MahnungenFetcher svc = new MahnungenFetcher();
                                    svc.FetchMahnungen();
                                    break;
                                }
                            default:
                                return string.Format("Unbekannter Parameter {0}", type);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                    }
                }
                else
                {
                    Log.Error(this.GetType(), "Verbindung zur DB kann nicht hergestellt werden");
                }
            }
            finally
            {
                lock (m_ActiveNotificationProcessing)
                {
                    // Wir sind fertig mit der Verarbeitung dieses Notifizierungtyps, wir entfernen in aus der globalen Liste der aktiven Prozesse
                    try
                    {
                        m_ActiveNotificationProcessing.Remove(notificationType);
                    }
                    catch(Exception ex)
                    {
                        Log.Error(this.GetType(), "Exception beim entfernen des Notifizierungstyps " + type, ex);
                    }
                }
            }

			return "";
		}

		[WebMethod]
		public void ClearCache()
		{
			WebServiceHelperMethods.ResetSettings();
			KiSSSvc.SAP.Helpers.SapHelper.ClearCache();
            lock (m_ActiveNotificationProcessing)
            {
                m_ActiveNotificationProcessing.Clear();
            }
		}

	}
}
