using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;
using KiSSSvc.DAL.TransactionalTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class KbBuchungBLL
	{
        public static void StornoNettoBeleg(TransactionHelper transHelper, int kbbuchungID, int userID, DateTime minimumStornoDatum, ref string stornoGruppierung)
        {
            KbBuchungTableAdapter adapter = new KbBuchungTableAdapter();
            adapter.InitializeKiSSAdapter(transHelper);

            adapter.spKbBuchung_Storno(kbbuchungID, userID, minimumStornoDatum, ref stornoGruppierung);
        }
        
        /// <summary>
        /// Liefert Netto-Buchungen zurück
        /// </summary>
        /// <param name="idArray"></param>
        /// <param name="getAllStatus">Wenn true, wird jeder Status zurückgegeben, sonst wird gefilert auf KbBuchungStatusCode IN (2,4,5,16) </param>
        /// <param name="getAllDependend">Wenn true, dann werden auch alle abhängigen Netto-Buchungen zurückgegeben</param>
        /// <returns></returns>
		public static KiSSDB.KbBuchungDataTable GetWhBelegeFromKbBuchungIDs(TransactionHelper transHelper, int[] ids, bool getAllStatus, bool getAllDependend)
		{
			KbBuchungTableAdapter adapter = new KbBuchungTableAdapter();
            adapter.InitializeKiSSAdapter(transHelper);

				return adapter.GetWhBelegeFromKbBuchungIDs(ids, getAllStatus, getAllDependend);
		}

		public static KiSSDB.KbBuchungDataTable GetAlimBelegeFromKbBuchungIDs(int[] ids)
		{
			KbBuchungTableAdapter adapter = new KbBuchungTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.GetAlimBelegeFromKbBuchungIDs(ids);
		}

		public static KiSSDB.KbBuchungKostenartDataTable GetPositionsOfBeleg(int kbBuchungID)
		{
			KbBuchungKostenartTableAdapter adapter = new KbBuchungKostenartTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.GetBuchungKostenartOfBuchung(kbBuchungID);
		}

		public static KiSSDB.KbBuchungRow GetBelegByBelegNr(long belegNr)
		{
			KbBuchungTableAdapter adapter = new KbBuchungTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.KbBuchungDataTable tbl = adapter.GetBelegByBelegNr(belegNr);
			if (tbl.Count > 1)
				throw new Exception(string.Format("Belegnummer {0} wird mehrfach verwendet!", belegNr));

			if (tbl.Count == 1)
				return tbl[0];
			return null;
		}

		public static void Update(KiSSDB.KbBuchungRow buchungRow)
		{
			KbBuchungTableAdapter adapter = new KbBuchungTableAdapter();
			adapter.InitializeKiSSAdapter(null);
			if (adapter.Update(buchungRow) != 1)
                throw new Exception("Der Nettobeleg " + buchungRow.KbBuchungID + " konnte nicht aktualisiert werden. Mögliches Problem:" + buchungRow.PscdFehlermeldung);
		}

		public static void UpdateStatusCode(KiSSDB.KbBuchungRow buchungRow, long? belegNr)
		{
			KbBuchungTableAdapter adapter = new KbBuchungTableAdapter();
			adapter.InitializeKiSSAdapter(null);
			if (adapter.UpdateBuchungsStatus(buchungRow.KbBuchungStatusCode, buchungRow.PscdFehlermeldung, belegNr, buchungRow.KbBuchungID, buchungRow.KbBuchungTS) != 1)
                throw new Exception("Der Nettobeleg " + buchungRow.KbBuchungID + " konnte nicht aktualisiert werden. Ursache ist wohl ein Concurrency-Problem, jemand hat beinahe gleichzeitig diese Buchung an PSCD gesendet");
		}

		public static int InsertGegenbuchung(KiSSDB.KbBuchungRow buchung, DateTime buchungsDatum, decimal betrag, string sollKtoNr, string habenKtoNr, int? kbZahlungseingangID, out int kbBuchungID)
		{
			KbBuchungTableAdapter adapter = new KbBuchungTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.InsertGegenbuchung(buchung.KbPeriodeID, DateTime.Now, buchungsDatum, betrag, buchung.Text ?? "", null, sollKtoNr, habenKtoNr, DateTime.Now, kbZahlungseingangID, out kbBuchungID);
		}
		/*
		public static string GetAuszahlkontoWh(int kbperiodeID)
		{
			QueryAdapter adpater = new QueryAdapter();
			return adpater.GetKbKontoNrByKontoartPublic(5, kbperiodeID); // 5: Auszahlkonto Wh
		}

		public static string GetAuszahlkontoAlim(int kbperiodeID)
		{
			QueryAdapter adpater = new QueryAdapter();
			return adpater.GetKbKontoNrByKontoartPublic(6, kbperiodeID); // 5: Auszahlkonto Alim
		}

		public static string GetDebitorKontoNr(int kbperiodeID)
		{
			QueryAdapter adpater = new QueryAdapter();
			return adpater.GetKbKontoNrByKontoartPublic(20, kbperiodeID); // 20: Debitor
		}

		public static string GetKreditorKontoNr(int kbperiodeID)
		{
			QueryAdapter adpater = new QueryAdapter();
			return adpater.GetKbKontoNrByKontoartPublic(30, kbperiodeID); // 30: Kreditor
		}

		public static string GetEinzahlungskonto(string bankkontonr, int kbperiodeID)
		{
			QueryAdapter adpater = new QueryAdapter();
			return adpater.GetKbKontoNrByKontoartPublic(7, kbperiodeID);  //ToDo: Einzahlungskonto finden
		}
		*/
        public static int SetEinnahmeNettoBelegStatus(TransactionHelper transHelper, int kbBuchungBruttoID, int kbBuchungStatusCode, string pscdFehlermeldung)
		{
			KbBuchungTableAdapter adapter = new KbBuchungTableAdapter();
            adapter.InitializeKiSSAdapter(transHelper);

			return adapter.SetEinnahmeNettoBelegStatus(kbBuchungStatusCode, pscdFehlermeldung, kbBuchungBruttoID);
		}

		public static int[] GetDistinctFaLeistungIDs(KiSSDB.KbBuchungDataTable buchungen)
		{
			List<int> faLeistungIDs = new List<int>();
			foreach (KiSSDB.KbBuchungRow buchung in buchungen)
			{
				if (!buchung.IsFaLeistungIDNull() && !faLeistungIDs.Contains(buchung.FaLeistungID))
					faLeistungIDs.Add(buchung.FaLeistungID);
			}
			return faLeistungIDs.ToArray();
		}

		public static int[] GetDistinctFaLeistungIDs(KiSSDB.KbBuchungBruttoDataTable buchungen)
		{
			List<int> faLeistungIDs = new List<int>();
			foreach (KiSSDB.KbBuchungBruttoRow buchung in buchungen)
			{
				if (!buchung.IsFaLeistungIDNull() && !faLeistungIDs.Contains(buchung.FaLeistungID))
					faLeistungIDs.Add(buchung.FaLeistungID);
			}
			return faLeistungIDs.ToArray();
		}

		public static int[] GetDistinctFaLeistungIDs(KiSSDB.KbBuchungDataTable buchungen, KiSSDB.KbBuchungBruttoDataTable bruttoBuchungen)
		{
			List<int> faLeistungIDs = new List<int>();
			foreach (KiSSDB.KbBuchungRow buchung in buchungen)
			{
				Logging.Log.Info(typeof(KbBuchungBLL), string.Format("FaLeistungID {0}", buchung["FaLeistungID"]));
				if (!buchung.IsFaLeistungIDNull() && !faLeistungIDs.Contains(buchung.FaLeistungID))
					faLeistungIDs.Add(buchung.FaLeistungID);
			}
			foreach (KiSSDB.KbBuchungBruttoRow buchung in bruttoBuchungen)
			{
				if (!buchung.IsFaLeistungIDNull() && !faLeistungIDs.Contains(buchung.FaLeistungID))
					faLeistungIDs.Add(buchung.FaLeistungID);
			}
			return faLeistungIDs.ToArray();
		}

		public static object ProcessAusgleichInfo(long? ausgleichBelegNr, decimal ausgleichBetrag, DateTime? ausgleichDatum, int? ausgleichGrund, DateTime? einzahlungDatum, int? vgID, int? gpID, long opBelegNr, int? posImOP, string zahlstapel, int? posImZahlstapel, int? OPUOW, int? OPUPZ, string WVSTAT)
		{
			QueryAdapter adapter = new QueryAdapter();
			return adapter.ProcessAusgleichsinfo(ausgleichBelegNr, ausgleichBetrag, ausgleichDatum, ausgleichGrund, einzahlungDatum, vgID, gpID, opBelegNr, posImOP, zahlstapel, posImZahlstapel, OPUOW, OPUPZ, WVSTAT);
		}
	}
}
