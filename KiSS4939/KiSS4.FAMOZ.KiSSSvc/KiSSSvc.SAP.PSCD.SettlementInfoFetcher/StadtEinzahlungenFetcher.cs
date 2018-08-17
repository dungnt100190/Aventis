using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using KiSSSvc.Logging;
using System.Data;
using KiSSSvc.SAP.Helpers;
using KiSSSvc.SAP.PSCD.WebServiceHelper.Settings;
using KiSSSvc.SAP.PSCD.BLL;
using KiSSSvc.DAL;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.EinzahlungenStadt;

namespace KiSSSvc.SAP.PSCD.InfoFetcher
{
	public class StadtEinzahlungenFetcher
	{
		private MI_STADT_EINZAHLService svcEinzahlung;

		public StadtEinzahlungenFetcher()
		{
			svcEinzahlung = WebServiceSource.GetStadtEinzahlungenWS();
		}
		public void FetchEinzahlungenInfo()
		{
			_STZH_SOZ_DFKKZP[] einzahlungenInfos = new _STZH_SOZ_DFKKZP[] { };
			Log.Info(this.GetType(), "Rufe MI_KLIENTEN_EINZAHL auf...");
			try
			{
				KiSSDB.KbZahlungseingangDataTable eingaenge = new KiSSDB.KbZahlungseingangDataTable();
				svcEinzahlung.MI_STADT_EINZAHL(ref einzahlungenInfos);
				Log.Info(this.GetType(), string.Format("Habe {0} Einzahlungsinfo erhalten", einzahlungenInfos.Length));
				foreach (_STZH_SOZ_DFKKZP info in einzahlungenInfos)
				{
					try
					{
						Log.Info(info.GetType(), string.Format("KEYZ1: {0}", info.KEYZ1));
						Log.Info(info.GetType(), string.Format("POSZA: {0}", info.POSZA));
						Log.Info(info.GetType(), string.Format("BANKN: {0}", info.BANKN));
						Log.Info(info.GetType(), string.Format("BETRZSpecified: {0}", info.BETRZSpecified));
						Log.Info(info.GetType(), string.Format("BETRZ: {0}", info.BETRZ));
						Log.Info(info.GetType(), string.Format("VALUT: {0}", info.VALUT));
						Log.Info(info.GetType(), string.Format("TXTVW: {0}", info.TXTVW));
						Log.Info(info.GetType(), string.Format("KOINH: {0}", info.KOINH));

						object valutaDatum = SapHelper.ParseDate(info.VALUT);
						DateTime valutaDatumNotNull = valutaDatum is DateTime ? (DateTime)valutaDatum : DateTime.Now;

						KiSSDB.KbZahlungseingangRow eingang = eingaenge.NewKbZahlungseingangRow();
						eingang.PscdZahlungsstapel = info.KEYZ1;
						int tmp;
						if (int.TryParse(info.POSZA, out tmp))
							eingang.PscdZahlungsstapelPos = tmp;
						eingang.PscdBankverrechnKto = info.BANKN;
						if (!info.BETRZSpecified)
						{
							// no amount specified
							Log.Warn(this.GetType(), string.Format("Einzahlung erhalten ohne Betrag! KEYZ1: {0}, POSZA {1}", info.KEYZ1, info.POSZA));
							continue;
						}
						eingang.Betrag = info.BETRZ;
						if (valutaDatum is DateTime)
							eingang.Datum = (DateTime)valutaDatum;
						else
							eingang.Datum = DateTime.Now;

						eingang.Mitteilung1 = SapHelper.Truncate(info.TXTVW, 35);
						eingang.Debitor = SapHelper.Truncate(info.KOINH, 200);
						eingang.ErstelltDatum = DateTime.Now;

						eingaenge.AddKbZahlungseingangRow(eingang);
					}
					catch (Exception ex)
					{
						Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
					}
				}
				KbZahlungseingangBLL.Update(eingaenge);
			}
			catch (Exception ex)
			{
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
			}
			finally
			{
				Log.Info(this.GetType(), "Aufruf von MI_AUSGL_SENDEN_NEWService beendet");
			}
		}

	}
}
