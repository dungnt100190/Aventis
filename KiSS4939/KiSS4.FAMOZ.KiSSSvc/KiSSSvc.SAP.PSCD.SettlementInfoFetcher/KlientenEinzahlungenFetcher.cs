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
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.EinzahlungenKlienten;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.InfoFetcher
{
	public class KlientenEinzahlungenFetcher
	{
		private MI_KLIENTEN_EINZAHLService svcEinzahlung;

		public KlientenEinzahlungenFetcher()
		{
			svcEinzahlung = WebServiceSource.GetKlientenEinzahlungenWS();
		}
		public void FetchEinzahlungenInfo(bool fetchFromTable)
		{
			try
			{
				_STZH_SOZ_FEBEP[] einzahlungenInfos;
				if (fetchFromTable)
				{
					Log.Info(this.GetType(), "Hole Daten aus Tabelle PscdKlientenEinzahlungLeiche...");
					einzahlungenInfos = GetEinzahlungenArray(PscdKlientenEinzahlungLeicheBLL.GetLeichenAndDelete());
					Log.Info(this.GetType(), string.Format("{0} Einträge vorhanden", einzahlungenInfos.Length));
				}
				else
				{
					einzahlungenInfos = new _STZH_SOZ_FEBEP[] { };
					Log.Info(this.GetType(), "Rufe MI_KLIENTEN_EINZAHL auf...");
					svcEinzahlung.MI_KLIENTEN_EINZAHL(ref einzahlungenInfos);
					Log.Info(this.GetType(), string.Format("Habe {0} Einzahlungsinfo erhalten", einzahlungenInfos.Length));
				}
				KiSSDB.KgZahlungseingangDataTable eingaenge = new KiSSDB.KgZahlungseingangDataTable();
				foreach (_STZH_SOZ_FEBEP info in einzahlungenInfos)
				{
					try
					{
						object valutaDatum = SapHelper.ParseDate(info.VALUT);
						DateTime valutaDatumNotNull = valutaDatum is DateTime ? (DateTime)valutaDatum : DateTime.Now;

						KiSSDB.KgZahlungseingangRow eingang = eingaenge.NewKgZahlungseingangRow();
						eingang.Mitteilung = SapHelper.Truncate(GetMitteilung(info), 600);
						eingang.PscdKontoauszug = SapHelper.Truncate(info.AZIDT, 20);
						eingang.PscdKontoKlient = SapHelper.Truncate(info.ABSND, 50);
						int? baPersonID = KgBuchungBLL.GetBaPersonIDFromZkbKontoNr(info.ABSND);
						if (baPersonID.HasValue)
							eingang.BaPersonID = baPersonID.Value;
						int tmp;
						if (int.TryParse(info.ESNUM, out tmp))
							eingang.PscdKontoauszugPos = tmp;

                        eingang.Datum = valutaDatumNotNull;
                        eingang.ErstelltDatum = DateTime.Now;

                        //eingang.Debitor = info.ABSND;
                        if (info.KWAER != "CHF")
                            throw new Exception(string.Format("Einzahlung erhalten mit Währung != CHF: '{0}'", info.KWAER));

                        if (!info.KWBTRSpecified)
                            throw new Exception(string.Format("Einzahlung erhalten ohne Betrag! AZIDT: {0}, ESNUM: {1}", info.AZIDT, info.ESNUM));

                        eingang.Betrag = info.KWBTR;
                        if (int.TryParse(info.VORGC, out tmp))
                            eingang.KgZahlungseingangArtCode = tmp;

                        KgZahlungseingangTableAdapter kgZahlungseingangTableAdapter = new KgZahlungseingangTableAdapter();
                        kgZahlungseingangTableAdapter.InitializeKiSSAdapter(null);

                        int? kgZahlungseingangID = kgZahlungseingangTableAdapter.GetKgZahlungseingang(eingang.PscdKontoKlient, eingang.PscdKontoauszug, eingang.PscdKontoauszugPos) as int?;

                        if (kgZahlungseingangID != null)
                        {
                            // Zahlungseingang existiert bereits => Update anstatt Insert
                            kgZahlungseingangTableAdapter.UpdateZahlungseingang(eingang.Datum, eingang.Betrag, eingang.Mitteilung, (int)kgZahlungseingangID);
                        }
                        else
                        {
                            // Neue Zeile zufügen
                            eingaenge.AddKgZahlungseingangRow(eingang);
                        }
					}
					catch (Exception ex)
					{
                        Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                        PscdKlientenEinzahlungLeicheBLL.Insert(info.ABSND, info.KWBTRSpecified ? info.KWBTR : (decimal?)null, info.SPESKSpecified ? info.SPESK : (decimal?)null, info.AZIDT, info.BUDAT, info.BVDAT, info.EPERL, info.ESNUM, info.KWAER, info.MANDT, info.STATUS, info.VALUT, info.VGEXT, info.VORGC, info.VWEZW1, info.VWEZW2, info.VWEZW3, info.VWEZW4, info.VWEZW5, info.VWEZW6, info.VWEZW7, info.VWEZW8);
					}
				}
				KgZahlungseingangBLL.Update(eingaenge);
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

		private _STZH_SOZ_FEBEP[] GetEinzahlungenArray(KiSSDB.PscdKlientenEinzahlungLeicheDataTable pscdKlientenEinzahlungLeicheDataTable)
		{
			List<_STZH_SOZ_FEBEP> items = new List<_STZH_SOZ_FEBEP>();

			foreach (KiSSDB.PscdKlientenEinzahlungLeicheRow einzahlung in pscdKlientenEinzahlungLeicheDataTable)
			{
				_STZH_SOZ_FEBEP item = new _STZH_SOZ_FEBEP();
				item.ABSND = einzahlung.ABSND;
				item.AZIDT = einzahlung.AZIDT;
				item.BUDAT = einzahlung.BUDAT;
				item.BVDAT = einzahlung.BVDAT;
				item.EPERL = einzahlung.EPERL;
				item.ESNUM = einzahlung.ESNUM;
				item.KWAER = einzahlung.KWAER;
				item.MANDT = einzahlung.MANDT;
				item.STATUS = einzahlung.STATUS;
				item.VALUT = einzahlung.VALUT;
				item.VGEXT = einzahlung.VGEXT;
				item.VORGC = einzahlung.VORGC;
				item.VWEZW1 = einzahlung.VWEZW1;
				item.VWEZW2 = einzahlung.VWEZW2;
				item.VWEZW3 = einzahlung.VWEZW3;
				item.VWEZW4 = einzahlung.VWEZW4;
				item.VWEZW5 = einzahlung.VWEZW5;
				item.VWEZW6 = einzahlung.VWEZW6;
				item.VWEZW7 = einzahlung.VWEZW7;
				item.VWEZW8 = einzahlung.VWEZW8;
				object tmpObj = einzahlung["KWBTR"];
				if (tmpObj is decimal)
				{
					item.KWBTR = (decimal)tmpObj;
					item.KWBTRSpecified = true;
				}
				else
					item.KWBTRSpecified = false;

				tmpObj = einzahlung["SPESK"];
				if (tmpObj is decimal)
				{
					item.SPESK = (decimal)tmpObj;
					item.SPESKSpecified = true;
				}
				else
					item.SPESKSpecified = false;

				items.Add(item);
			}
			return items.ToArray();
		}

		private string GetMitteilung(_STZH_SOZ_FEBEP info)
		{
			return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", info.VWEZW1, info.VWEZW2, info.VWEZW3, info.VWEZW4, info.VWEZW5, info.VWEZW6, info.VWEZW7, info.VWEZW8);
		}
	}
}
