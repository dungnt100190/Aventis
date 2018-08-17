using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using KiSSSvc.Logging;
using System.Data;
using KiSSSvc.SAP.Helpers;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.AusgleichLesen;
using KiSSSvc.SAP.PSCD.WebServiceHelper.Settings;
using KiSSSvc.SAP.PSCD.BLL;
using KiSSSvc.DAL;
using System.Transactions;

namespace KiSSSvc.SAP.PSCD.InfoFetcher
{
	public class SettlementInfoFetcher
	{
		private MI_AUSGL_SENDEN_NEWService svcSettlement;

		public SettlementInfoFetcher()
		{
			svcSettlement = WebServiceSource.GetAusgleichHolenWS();
		}
		public void FetchSettlementInfo(bool fetchFromTable)//int documentNumber, int fikey, int bpNumber, int accountNumber, int contract)
		{
			try
			{
				_STZH_FI_AUSGLEICHMELDUNG_KISS[] settlementInfos;
				if (fetchFromTable)
				{
					Log.Info(this.GetType(), "Hole Daten aus Tabelle PscdAusgleichLeiche...");
					settlementInfos = GetAusgleichArray(PscdAusgleichLeicheBLL.GetAusgleichLeichenAndDelete());
					Log.Info(this.GetType(), string.Format("{0} Einträge vorhanden", settlementInfos.Length));
				}
				else
				{
					settlementInfos = new _STZH_FI_AUSGLEICHMELDUNG_KISS[] { };
					Log.Info(this.GetType(), "Rufe MI_AUSGL_SENDEN_NEWService auf...");
					svcSettlement.MI_AUSGL_SENDEN_NEW("Du mir gebe Aussegleicheinfo!", ref settlementInfos);
					Log.Info(this.GetType(), string.Format("Habe {0} Ausgleichsmeldungen erhalten", settlementInfos.Length));
				}
				foreach (_STZH_FI_AUSGLEICHMELDUNG_KISS info in settlementInfos)
				{
					try
					{
						//Log.Info(info.GetType(), string.Format("GPART: {0}", info.GPART));
						//Log.Info(info.GetType(), string.Format("AUGBL: {0}", info.AUGBL));
						//Log.Info(info.GetType(), string.Format("AUGBT: {0}", info.AUGBT));
						//Log.Info(info.GetType(), string.Format("AUGBTSpecified: {0}", info.AUGBTSpecified));
						//Log.Info(info.GetType(), string.Format("AUGDT: {0}", info.AUGDT));
						//Log.Info(info.GetType(), string.Format("AUGRD: {0}", info.AUGRD));
						//Log.Info(info.GetType(), string.Format("EZDAT: {0}", info.EZDAT));
						//Log.Info(info.GetType(), string.Format("OPBEL: {0}", info.OPBEL));
						//Log.Info(info.GetType(), string.Format("VTREF: {0}", info.VTREF));
						//info.OPUPK Detailposition


						long opBelegNr = long.Parse(info.OPBEL);
						long belegNrAusgleich;
						long? belegNrAusgleichNullable = null;
						if (long.TryParse(info.AUGBL, out belegNrAusgleich))
							belegNrAusgleichNullable = belegNrAusgleich;
						int tmp;
						int? ausgleichsGrund = null;
						if (int.TryParse(info.AUGRD, out tmp))
							ausgleichsGrund = tmp;
						int? vgID = null;
						if (int.TryParse(info.VTREF, out tmp))
							vgID = tmp;
						int? gpID = null;
						if (int.TryParse(info.GPART, out tmp))
							gpID = tmp;
						int? posImOP = null;
						if (int.TryParse(info.OPUPK, out tmp))
							posImOP = tmp;
						int? OPUPW = null;
						if (int.TryParse(info.OPUPW, out tmp))
							OPUPW = tmp;
						int? OPUPZ = null;
						if (int.TryParse(info.OPUPZ, out tmp))
							OPUPZ = tmp;
						int? posImZE = null;
						if (int.TryParse(info.POSZA, out tmp))
							posImZE = tmp;
						int? zahlstapel = null;
						if (int.TryParse(info.KEYZ1, out tmp))
							zahlstapel = tmp;

						if (!info.AUGBTSpecified)
						{
							// no amount specified
							Log.Warn(this.GetType(), string.Format("Ausgleichsinfo erhalten ohne Betrag, dies kann nicht verarbeitet werden! Belegnummer: '{0}'", opBelegNr));
							continue;
						}
						object ausgleichDatum = SapHelper.ParseDate(info.AUGDT);
						object einzahlungDatum = SapHelper.ParseDate(info.EZDAT);

						KbBuchungBLL.ProcessAusgleichInfo(belegNrAusgleichNullable, (decimal)info.AUGBT, ausgleichDatum is DateTime ? (DateTime)ausgleichDatum : (DateTime?)null, ausgleichsGrund, einzahlungDatum is DateTime ? (DateTime)einzahlungDatum : (DateTime?)null, vgID, gpID, opBelegNr, posImOP, info.KEYZ1, posImZE, OPUPW, OPUPZ, info.WVSTAT);
						/*
						DateTime ausgleichDatumNotNull = ausgleichDatum is DateTime ? (DateTime)ausgleichDatum : DateTime.Now;
						// Bruttobeleg ausgleichen
						KiSSDB.KbBuchungBruttoRow bruttoBeleg = KbBuchungBruttoBLL.GetBelegByBelegNr(opBelegNr);
						if (bruttoBeleg != null)
						{
							if (Math.Abs(info.AUGBT) > Math.Abs(bruttoBeleg.Betrag)) // ToDo: abs entfernen, vorsicht mit < und > bei negativen Beträgen
								throw new Exception(string.Format("Der ausgeglichene Betrag ist grösser als der Betrag auf dem Beleg! Belegnummer: {0}", opBelegNr));
							decimal betragAusgeglichen = bruttoBeleg.BetragEffektiv;
							if (Math.Abs(info.AUGBT) + Math.Abs(betragAusgeglichen) == Math.Abs(bruttoBeleg.Betrag))
							{
								// Totalausgleich
								bruttoBeleg.BetragEffektiv = betragAusgeglichen + info.AUGBT;
								if (ausgleichDatum is DateTime)
									bruttoBeleg.DatumEffektiv = (DateTime)ausgleichDatum;
								bruttoBeleg.KbBuchungStatusCode = 6; // ausgeglichen
							}
							else
							{
								// Teilausgleich
								bruttoBeleg.BetragEffektiv = betragAusgeglichen + info.AUGBT;
								if (ausgleichDatum is DateTime)
									bruttoBeleg.DatumEffektiv = (DateTime)ausgleichDatum;
								bruttoBeleg.KbBuchungStatusCode = 10; // teilweise ausgeglichen
							}
							KbBuchungBruttoBLL.Update(bruttoBeleg);
						}
						else
						{
							KiSSDB.KbBuchungRow nettoBeleg = KbBuchungBLL.GetBelegByBelegNr(opBelegNr);
							if (nettoBeleg != null)
							{
								// Zum Ausgleich gehörende Einzahlung finden
								int? eingangID = null;
								string sollKontoNr = null;
								string habenKontoNr = null;
								if (nettoBeleg.KbBuchungTypCode == 2) // Forderung
								{
									KiSSDB.KbZahlungseingangRow eingangRow = KbZahlungseingangBLL.FindZahlungseingang(info.KEYZ1, int.Parse(info.POSZA));
									eingangID = eingangRow.KbZahlungseingangID;
									sollKontoNr = nettoBeleg.HabenKtoNr;
									habenKontoNr = KbBuchungBLL.GetEinzahlungskonto(eingangRow.PscdBankverrechnKto, nettoBeleg.KbPeriodeID);
								}
								else // Verbindlichkeit
								{
									habenKontoNr = nettoBeleg.SollKtoNr;
									sollKontoNr = KbBuchungBLL.GetAuszahlkontoWh(nettoBeleg.KbPeriodeID);
								}
								if (Math.Abs(info.AUGBT) > Math.Abs(nettoBeleg.Betrag)) // ToDo: abs entfernen, vorsicht mit < und > bei negativen Beträgen
									throw new Exception(string.Format("Der ausgeglichene Betrag ist grösser als der Betrag auf dem Beleg! Belegnummer: {0}", opBelegNr));

								decimal betragAusgeglichen = KbOpAusgleichBLL.GetSettledAmountOfOp(nettoBeleg.KbBuchungID);
								int gegenbuchungID;
								KbBuchungBLL.InsertGegenbuchung(nettoBeleg, ausgleichDatumNotNull, info.AUGBT, sollKontoNr, habenKontoNr, eingangID, out gegenbuchungID);
								KbOpAusgleichBLL.Insert(nettoBeleg.KbBuchungID, gegenbuchungID, info.AUGBT);
								if (Math.Abs(info.AUGBT) + Math.Abs(betragAusgeglichen) == Math.Abs(nettoBeleg.Betrag))
								{
									// Totalausgleich
									//nettoBeleg.BetragEffektiv = betragAusgeglichen + info.AUGBT;
									//if (ausgleichDatum is DateTime)
									//   nettoBeleg.DatumEffektiv = (DateTime)ausgleichDatum;
									if (info.AUGRD == "10")
										nettoBeleg.KbBuchungStatusCode = 9; // Rückläufer
									else
										nettoBeleg.KbBuchungStatusCode = 6; // ausgeglichen
								}
								else
								{
									// Teilausgleich
									//nettoBeleg.BetragEffektiv = betragAusgeglichen + info.AUGBT;
									//if (ausgleichDatum is DateTime)
									//   nettoBeleg.DatumEffektiv = (DateTime)ausgleichDatum;
									nettoBeleg.KbBuchungStatusCode = 10; // teilweise ausgeglichen
								}
								KbBuchungBLL.Update(nettoBeleg);
							}
							else
							{
								KiSSDB.KgBuchungRow kgOpBeleg = KgBuchungBLL.GetKgBuchungByBelegNr(opBelegNr);
								if (kgOpBeleg == null)
									throw new Exception(string.Format("Kein Beleg für Belegnummer '{0}' gefunden", opBelegNr));

								if (Math.Abs(info.AUGBT) > Math.Abs(kgOpBeleg.Betrag)) // ToDo: abs entfernen, vorsicht mit < und > bei negativen Beträgen
									throw new Exception(string.Format("Der ausgeglichene Betrag ist grösser als der Betrag auf dem Beleg! Belegnummer: {0}", opBelegNr));

								if (Math.Abs(info.AUGBT) == Math.Abs(kgOpBeleg.Betrag))
								{
									// Totalausgleich
									if (info.AUGRD == "10")
										kgOpBeleg.KgBuchungStatusCode = 9; // Rückläufer
									else
									{
										decimal betrag = -info.AUGBT;
										if (!kgOpBeleg.IsKgAuszahlungsArtCodeNull() && kgOpBeleg.KgAuszahlungsArtCode == 103) // Cash / Barauszahlung
										{
											//kgOpBeleg.KgBuchungStatusCode = 11; // Barbezug erfolgt (Klient hat Geld abgeholt, es muss aber noch vom Klientenkonto auf das Stadtkassekonto transferiert werden)
											kgOpBeleg.BarbezugDatum = ausgleichDatumNotNull;

											// provisorisch, wenn Rückmeldung über MT940 klappt, wird der Ausgleich erst erfolgen, wenn die Zahlung vom Klientenkonto auf das Konto der Stadtkasse erfolgt ist
											kgOpBeleg.KgBuchungStatusCode = 6; // ausgeglichen
											// Gegenbuchung erzeugen
											string kontokorrentKontoNr = KgBuchungBLL.GetKontokorrentKontoNr(kgOpBeleg.KgPeriodeID);
											int kgBuchungIDGegenBuchung;
											KgBuchungBLL.InsertGegenbuchung(kgOpBeleg, ausgleichDatumNotNull, betrag, kontokorrentKontoNr, out kgBuchungIDGegenBuchung);
											KgOpAusgleichBLL.Insert(kgOpBeleg.KgBuchungID, kgBuchungIDGegenBuchung, betrag);
										}
										else
										{
											kgOpBeleg.KgBuchungStatusCode = 6; // ausgeglichen
											// Gegenbuchung erzeugen
											string kontokorrentKontoNr = KgBuchungBLL.GetKontokorrentKontoNr(kgOpBeleg.KgPeriodeID);
											int kgBuchungIDGegenBuchung;
											KgBuchungBLL.InsertGegenbuchung(kgOpBeleg, ausgleichDatumNotNull, betrag, kontokorrentKontoNr, out kgBuchungIDGegenBuchung);
											KgOpAusgleichBLL.Insert(kgOpBeleg.KgBuchungID, kgBuchungIDGegenBuchung, betrag);
										}
									}
								}
								else
								{
									// Teilausgleich wird in Kg nicht unterstützt
									Log.Warn(this.GetType(), string.Format("Teilausgleich ist im Bereich K nicht erlaubt. BelegNummer OP '{0}', Betrag {1}, Ausgleichsbetrag {2}", opBelegNr, kgOpBeleg.Betrag, info.AUGBT));
									continue;
								}
								KgBuchungBLL.Update(kgOpBeleg);
							}

						}
						 */

					}
					catch (Exception ex)
					{
						Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
					    string Fehlermeldung = KiSSSvc.SAP.Helpers.SapHelper.Truncate(ex.Message, 300);
                        PscdAusgleichLeicheBLL.Insert(info.AUGBL, info.AUGBTSpecified ? info.AUGBT : (decimal?)null, info.AUGDT, info.AUGRD, info.EZDAT, info.GPART, info.KEYZ1, info.OPBEL, info.OPUPK, info.OPUPW, info.OPUPZ, info.POSZA, info.VTREF, info.WVSTAT, Fehlermeldung);
					}
				}
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

		private _STZH_FI_AUSGLEICHMELDUNG_KISS[] GetAusgleichArray(KiSSDB.PscdAusgleichLeicheDataTable pscdAusgleichLeicheDataTable)
		{
			List<_STZH_FI_AUSGLEICHMELDUNG_KISS> items = new List<_STZH_FI_AUSGLEICHMELDUNG_KISS>();

			foreach (KiSSDB.PscdAusgleichLeicheRow ausgleich in pscdAusgleichLeicheDataTable)
			{
				_STZH_FI_AUSGLEICHMELDUNG_KISS item = new _STZH_FI_AUSGLEICHMELDUNG_KISS();
				item.AUGBL = ausgleich.AUGBL;
				object tmpObj = ausgleich["AUGBT"];
				if (tmpObj is decimal)
				{
					item.AUGBT = (decimal)tmpObj;
					item.AUGBTSpecified = true;
				}
				else
					item.AUGBTSpecified = false;

				item.AUGDT = ausgleich.AUGDT;
				item.AUGRD = ausgleich.AUGRD;
				item.EZDAT = ausgleich.EZDAT;
				item.GPART = ausgleich.GPART;
				item.KEYZ1 = ausgleich.KEYZ1;
				item.OPBEL = ausgleich.OPBEL;
				item.OPUPK = ausgleich.OPUPK;
				item.OPUPW = ausgleich.OPUPW;
				item.OPUPZ = ausgleich.OPUPZ;
				item.POSZA = ausgleich.POSZA;
				item.VTREF = ausgleich.VTREF;

				items.Add(item);
			}
			return items.ToArray();

		}

	}
}
