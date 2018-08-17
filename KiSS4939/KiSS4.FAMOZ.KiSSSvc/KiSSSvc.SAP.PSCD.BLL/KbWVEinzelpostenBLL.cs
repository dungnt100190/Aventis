using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class KbWVEinzelpostenBLL
	{
		public static object UpdateWvStatus(int? pscdWvStatusLogID, long opBelegNr, string WVSTAT, string FUBANAME, 
                                            string TIMESTAMP, string MANDT, string OPUPK, string OPUPW, string OPUPZ)            
		{
			QueryAdapter adapter = new QueryAdapter();
			return adapter.UpdateWvStatus(pscdWvStatusLogID, opBelegNr, WVSTAT, FUBANAME, TIMESTAMP, MANDT, OPUPK, OPUPW, OPUPZ);
		}

		public static KiSSDB.KbWVEinzelpostenDataTable GetAllWVEinzelposten()
		{
			KbWVEinzelpostenTableAdapter adapter = new KbWVEinzelpostenTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.GetWVEinzelposten();
		}

		public static KiSSDB.KbWVEinzelpostenDataTable GetWVEinzelpostenByIDs(int[] kbWVEinzelpostenIDs)
		{
			KbWVEinzelpostenTableAdapter adapter = new KbWVEinzelpostenTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.GetWVEinzelpostenByIDs(kbWVEinzelpostenIDs);
		}

		public static void Update(KiSSDB.KbWVEinzelpostenRow einzelpostenRow)
		{
			KbWVEinzelpostenTableAdapter adapter = new KbWVEinzelpostenTableAdapter();
			adapter.InitializeKiSSAdapter(null);
			if (adapter.Update(einzelpostenRow) != 1)
                throw new Exception("Der WV-Einzelposten " + einzelpostenRow.KbWVEinzelpostenID + " konnte nicht aktualisiert werden. Ursache ist wohl ein Concurrency-Problem, jemand hat beinahe gleichzeitig diese Buchung an PSCD gesendet");
		}

	}
}
