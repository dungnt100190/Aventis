using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;
using KiSSSvc.DAL.TransactionalTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class KbBuchungBruttoBLL
	{
		public static KiSSDB.KbBuchungBruttoDataTable GetBruttoBelegeByKbBuchungIDs(TransactionHelper transHelper, int[] kbBuchungIDs, int[] kbBuchungBruttoIDs)
		{
			KbBuchungBruttoTableAdapter adapter = new KbBuchungBruttoTableAdapter();
            adapter.InitializeKiSSAdapter(transHelper);

			return adapter.GetBruttoBelegeByKbBuchungIDs(kbBuchungIDs, kbBuchungBruttoIDs);
		}

        public static KiSSDB.KbBuchungBruttoDataTable GetBruttoBelegeByGruppierungUmbuchung(TransactionHelper transHelper, string gruppierungUmbuchung)
        {
            KbBuchungBruttoTableAdapter adapter = new KbBuchungBruttoTableAdapter();
            adapter.InitializeKiSSAdapter(transHelper);

            return adapter.GetBruttoBelegeByGruppierungUmbuchung(gruppierungUmbuchung);
        }

		public static KiSSDB.KbBuchungBruttoPersonDataTable GetPositionsOfBeleg(TransactionHelper transHelper, int kbBuchungID)
		{
			KbBuchungBruttoPersonTableAdapter adapter = new KbBuchungBruttoPersonTableAdapter();
            adapter.InitializeKiSSAdapter(transHelper);

			return adapter.GetBuchungKostenartOfBuchung(kbBuchungID);
		}

		public static KiSSDB.KbBuchungBruttoRow GetBelegByBelegNr(long belegNr)
		{
			KbBuchungBruttoTableAdapter adapter = new KbBuchungBruttoTableAdapter();
            adapter.InitializeKiSSAdapter(null);

			KiSSDB.KbBuchungBruttoDataTable tbl = adapter.GetBelegByBelegNr(belegNr);
			if (tbl.Count > 1)
				throw new Exception(string.Format("Belegnummer {0} wird mehrfach verwendet!", belegNr));

			if (tbl.Count == 1)
				return tbl[0];
			return null;
		}

		public static void Update(TransactionHelper transHelper, KiSSDB.KbBuchungBruttoRow buchungRow)
		{
			KbBuchungBruttoTableAdapter adapter = new KbBuchungBruttoTableAdapter();
            adapter.InitializeKiSSAdapter(transHelper);
            if (adapter.Update(buchungRow) != 1)
                throw new Exception("Der Bruttobeleg " + buchungRow.KbBuchungBruttoID + " konnte nicht aktualisiert werden. Ursache ist wohl ein Concurrency-Problem, jemand hat beinahe gleichzeitig diese Buchung an PSCD gesendet");
		}

        public static void UpdatePscdFehlermeldung(TransactionHelper transHelper, KiSSDB.KbBuchungBruttoRow buchungRow, string pscdFehlermeldung)
        {
            KbBuchungBruttoTableAdapter adapter = new KbBuchungBruttoTableAdapter();
            adapter.InitializeKiSSAdapter(transHelper);
            if (adapter.UpdateBuchungsStatus(buchungRow.KbBuchungStatusCode, pscdFehlermeldung, buchungRow.BelegNr, buchungRow.TransferDatum, buchungRow.KbBuchungBruttoID) != 1)
                throw new Exception("Der Bruttobeleg " + buchungRow.KbBuchungBruttoID + " konnte nicht aktualisiert werden. Ursache ist wohl ein Concurrency-Problem, jemand hat beinahe gleichzeitig diese Buchung an PSCD gesendet");
        }

        /// <summary>
        /// Setzt die neue PSCD-Belegnummer und das TransferDatum
        /// </summary>
        /// <param name="transHelper"></param>
        /// <param name="buchungRow"></param>
        /// <param name="belegNr"></param>
        public static void UpdatePscdBelegNr(TransactionHelper transHelper, KiSSDB.KbBuchungBruttoRow buchungRow, long? belegNr, DateTime? transferDatum)
        {
            KbBuchungBruttoTableAdapter adapter = new KbBuchungBruttoTableAdapter();
            adapter.InitializeKiSSAdapter(transHelper);
            if (adapter.UpdateBuchungsStatus(buchungRow.KbBuchungStatusCode, buchungRow.PscdFehlermeldung, belegNr, transferDatum, buchungRow.KbBuchungBruttoID) != 1)
                throw new Exception("Der Bruttobeleg " + buchungRow.KbBuchungBruttoID + " konnte nicht aktualisiert werden. Ursache ist wohl ein Concurrency-Problem, jemand hat beinahe gleichzeitig diese Buchung an PSCD gesendet");
        }

        public static int UpdateMahnstufe(long belegNr, int mahnStufe)
        {
            KbBuchungBruttoTableAdapter adapter = new KbBuchungBruttoTableAdapter();
            adapter.InitializeKiSSAdapter(null);
            //if (adapter.UpdateMahnstufe(mahnStufe, belegNr) != 1)
            //    throw new Exception("Der Bruttobeleg konnte nicht aktualisiert werden. Ursache ist wohl ein Concurrency-Problem, jemand hat beinahe gleichzeitig diese Buchung an PSCD gesendet");
            return (int)adapter.UpdateMahnstufe(mahnStufe, belegNr);
        }

        public static int GetPersonOfSicherheitsleistungBuchung(TransactionHelper transHelper, int kbBuchungBruttoID)
		{
			BaPersonOnlyTableAdapter adapter = new BaPersonOnlyTableAdapter();
            adapter.InitializeKiSSAdapter(transHelper);

			object baPersonID = adapter.GetPersonOfSicherheitsleistungBuchung(kbBuchungBruttoID);
			if (baPersonID == null || !(baPersonID is int))
				throw new Exception("Der InvMDAS-Bruttobeleg konnte keiner Person zugeordnet werden");

			return (int)baPersonID;
		}

		public static int? GetBudgetIDOfBruttoBeleg(int kbbuchungBruttoID)
		{
			QueryAdapter adapter = new QueryAdapter();
			return adapter.GetBudgetIDByKbBuchungBruttoID(kbbuchungBruttoID);
		}

		public static void StornoBruttoBeleg(TransactionHelper transHelper, int kbbuchungBruttoID, int userID, DateTime minimumStornoDatum, ref string stornoGruppierung)
		{
			KbBuchungBruttoTableAdapter adapter = new KbBuchungBruttoTableAdapter();
			adapter.InitializeKiSSAdapter(transHelper);

			adapter.spKbBuchungBrutto_Storno(kbbuchungBruttoID, userID, minimumStornoDatum, ref stornoGruppierung);
		}

	}
}
