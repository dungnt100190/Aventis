using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL.KiSSDBTableAdapters;
using KiSSSvc.DAL;

namespace KiSSSvc.SAP.PSCD.BLL
{

	public static class FaLeistungBLL
	{
		public static KiSSDB.FaLeistungDataTable GetLeistungenOfPerson(int baPersonID)
		{
			FaLeistungTableAdapter leistungAdapter = new FaLeistungTableAdapter();
            leistungAdapter.InitializeKiSSAdapter(null);
			return leistungAdapter.GetLeistungenOfPerson(baPersonID);
		}

		//public static int GetFaLeistungIDByBudgetID(int bgBudgetID)
		//{
		//   FaLeistungTableAdapter adapter = new FaLeistungTableAdapter();
		//   adapter.InitializeKiSSAdapter(null);

		//   return adapter.GetFaLeistungByBgBudgetID(bgBudgetID);
		//}

		public static KiSSDB.FaLeistungRow GetLeistungRowByBudgetID(int bgBudgetID)
		{
			FaLeistungTableAdapter adapter = new FaLeistungTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.FaLeistungDataTable tbl = adapter.GetFaLeistungByBgBudgetID(bgBudgetID);
			if (tbl.Count == 1)
				return tbl[0];
			return null;
		}

		public static List<int> GetSupportedPersonsOfWhLeistung(int faLeistungID)
		{
			BaPersonOnlyTableAdapter adapter = new BaPersonOnlyTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.BaPersonOnlyDataTable tbl = adapter.GetSupportedPersonsOfFaLeistung(faLeistungID);
			List<int> persons = new List<int>();
			foreach (KiSSDB.BaPersonOnlyRow row in tbl)
				persons.Add(row.BaPersonID);

			return persons;
		}

		public static List<int> GetPersonsOfAlimLeistung(int faLeistungID)
		{
			BaPersonOnlyTableAdapter adapter = new BaPersonOnlyTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.BaPersonOnlyDataTable tbl = adapter.GetPersonsOfAlimLeistung(faLeistungID);
			List<int> persons = new List<int>();
			foreach (KiSSDB.BaPersonOnlyRow row in tbl)
				persons.Add(row.BaPersonID);

			return persons;
		}

		public static int UpdatePscdVgID(ref KiSSDB.FaLeistungRow row, long pscdVgID)
		{
			FaLeistungTableAdapter adapter = new FaLeistungTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			int affectedRows = adapter.UpdatePscdVertragsgegenstandID(pscdVgID, row.FaLeistungID, row.FaLeistungTS);
			if (affectedRows == 1)
				row.PscdVertragsgegenstandID = pscdVgID;
			return affectedRows;
		}

		public static KiSSDB.FaLeistungDataTable GetLeistungenByIDs(int[] faLeistungIDs)
		{
			FaLeistungTableAdapter adapter = new FaLeistungTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.GetLeistungenByIDs(faLeistungIDs);
		}

		//public static KiSSDB.FaLeistungDataTable GetLeistungenOfAlimKbBuchungIDs(int[] kbBuchungIDs)
		//{
		//   FaLeistungTableAdapter adapter = new FaLeistungTableAdapter();
		//   adapter.InitializeKiSSAdapter(null);

		//   //return adapter.(month, year);
		//}
	}
}

