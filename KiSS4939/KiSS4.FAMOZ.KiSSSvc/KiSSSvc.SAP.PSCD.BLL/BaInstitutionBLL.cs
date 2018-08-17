using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class BaInstitutionBLL
	{
		public static KiSSDB.BaInstitutionRow GetInstitution(int baInstitutionID)
		{
			BaInstitutionTableAdapter institutionAdapter = new BaInstitutionTableAdapter();
			institutionAdapter.InitializeKiSSAdapter(null);
			KiSSDB.BaInstitutionDataTable institutions = institutionAdapter.GetInstitutionByID(baInstitutionID);
			if (institutions.Rows.Count != 1)
				throw new Exception(string.Format("Es existieren {0} Institutionen mit ID {1} statt genau eine", institutions.Count, baInstitutionID));
			return institutions[0];
		}

		public static int[] GetInstitutionsAndSchuldnerOfKbBuchungIDs(int[] kbBuchungIDs, int[] kbBuchungBruttoIDs)
		{
			BaInstitutionOnlyTableAdapter adapter = new BaInstitutionOnlyTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			List<int> institutionIDs = new List<int>();
			KiSSDB.BaInstitutionOnlyDataTable table = adapter.GetInstitutionsAndSchuldnerOfKbBuchungIDs(kbBuchungIDs, kbBuchungBruttoIDs);
			foreach (KiSSDB.BaInstitutionOnlyRow row in table)
				institutionIDs.Add(row.BaInstitutionID);
			return institutionIDs.ToArray();
		}


		public static int[] GetInstitutionsOfAlimMonth(int month, int year)
		{
			BaInstitutionOnlyTableAdapter adapter = new BaInstitutionOnlyTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			List<int> institutionIDs = new List<int>();
			KiSSDB.BaInstitutionOnlyDataTable table = adapter.GetInstitutionsOfAlimMonth(month, year);
			foreach (KiSSDB.BaInstitutionOnlyRow row in table)
				institutionIDs.Add(row.BaInstitutionID);
			return institutionIDs.ToArray();
		}


	}
}
