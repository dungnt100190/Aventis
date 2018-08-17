using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class KgBuchungBLL
	{
		public static KiSSDB.KgBuchungDataTable GetBuchungenOfKgBudget(int kgBudgetID)
		{
			KgBuchungTableAdapter adapter = new KgBuchungTableAdapter();
			adapter.InitializeKiSSAdapter(null);
			return adapter.GetBuchungenOfKgBudget(kgBudgetID);
		}

		public static KiSSDB.KgBuchungRow GetKgBuchungByID(int kgBuchungID)
		{
			KgBuchungTableAdapter adapter = new KgBuchungTableAdapter();
			adapter.InitializeKiSSAdapter(null);
			KiSSDB.KgBuchungDataTable buchungen = adapter.GetKgBuchungByID(kgBuchungID);

			if (buchungen.Rows.Count == 0)
				throw new Exception(string.Format("Keine Buchung mit KgBuchungID {0} gefunden", kgBuchungID));
			else if (buchungen.Rows.Count > 1)
				throw new Exception(string.Format("KgBuchungID {0} ist nicht eindeutig", kgBuchungID));

			return buchungen[0];
		}

		public static KiSSDB.KgBuchungDataTable GetKgBuchungByIDs(int[] kgBuchungIDs)
		{
			KgBuchungTableAdapter adapter = new KgBuchungTableAdapter();
			adapter.InitializeKiSSAdapter(null);
			List<string> ids = new List<string>();
			foreach (int id in kgBuchungIDs)
				ids.Add(id.ToString());
			return adapter.GetKgBuchungByIDs(ids.ToArray());
		}

        public static KiSSDB.KgBuchungDataTable GetKgBuchungTopN(int anzahlBelege)
        {
            KgBuchungTableAdapter adapter = new KgBuchungTableAdapter();
            adapter.InitializeKiSSAdapter(null);
            return adapter.GetKgBuchungTopN(anzahlBelege);
        }

		public static KiSSDB.KgBuchungRow GetKgBuchungByBelegNr(long belegNr)
		{
			KgBuchungTableAdapter adapter = new KgBuchungTableAdapter();
			adapter.InitializeKiSSAdapter(null);
			KiSSDB.KgBuchungDataTable buchungen = adapter.GetBelegByBelegNr(belegNr);

			if (buchungen.Rows.Count == 0)
				return null;
			if (buchungen.Rows.Count > 1)
			   throw new Exception(string.Format("BelegNr {0} ist nicht eindeutig", belegNr));

			return buchungen[0];
		}

		public static int Update(KiSSDB.KgBuchungRow belegRow)
		{
			KgBuchungTableAdapter adapter = new KgBuchungTableAdapter();
			adapter.InitializeKiSSAdapter(null);
			return adapter.Update(belegRow);
		}

		public static void UpdateStatusCode(KiSSDB.KgBuchungRow buchungRow, long? belegNr)
		{
			KgBuchungTableAdapter adapter = new KgBuchungTableAdapter();
			adapter.InitializeKiSSAdapter(null);
			if (adapter.UpdateStatusAndBelegNr(buchungRow.KgBuchungStatusCode, buchungRow.PscdFehlermeldung, belegNr, buchungRow.KgBuchungID, buchungRow.KgBuchungTS) != 1)
                throw new Exception("Der Kg-Beleg " + buchungRow.KgBuchungID + " konnte nicht aktualisiert werden. Ursache ist wohl ein Concurrency-Problem, jemand hat beinahe gleichzeitig diese Buchung an PSCD gesendet");
		}

		public static int InsertGegenbuchung(KiSSDB.KgBuchungRow buchung, DateTime buchungsDatum, decimal betrag, string habenKtoNr, out int kgBuchungID)
		{
			KgBuchungTableAdapter adapter = new KgBuchungTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.InsertGegenbuchung(buchung.KgPeriodeID, null, buchungsDatum, buchung.HabenKtoNr, habenKtoNr, betrag, buchung.Text ?? "", buchungsDatum, DateTime.Now, buchungsDatum, out kgBuchungID);
		}

		public static int? GetBaPersonIDFromZkbKontoNr(string zkbKontoNr)
		{
			QueryAdapter adapter = new QueryAdapter();
			return adapter.GetBaPersonIdFromZkbKontoNummer(zkbKontoNr);
		}

		public static KiSSDB.KgBuchungDataTable GetStornoBelegeOfKgBudget(int kgBudgetID)
		{
			KgBuchungTableAdapter adapter = new KgBuchungTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.GetStornoBelegeOfKgBudget(kgBudgetID);
		}

		public static KiSSDB.KgBuchungDataTable GetStornoBelegByID(int kgBuchungID)
		{
			KgBuchungTableAdapter adapter = new KgBuchungTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.GetStornoBelegByID(kgBuchungID);
		}

		public static KiSSDB.KgBuchungDataTable GetStornoBelegeByIDs(int[] kgBuchungIDs)
		{
			KgBuchungTableAdapter adapter = new KgBuchungTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			List<string> list = new List<string>();
			foreach (int id in kgBuchungIDs)
				list.Add(id.ToString());
			return adapter.GetStornoKgBuchungByIDs(list.ToArray());
		}

		public static string GetKontokorrentKontoNr(int kbperiodeID)
		{
			QueryAdapter adpater = new QueryAdapter();
			return adpater.GetKgKontoNrByKontoartPublic(1, kbperiodeID); // 1: Kontokorrent
		}
	}
}
