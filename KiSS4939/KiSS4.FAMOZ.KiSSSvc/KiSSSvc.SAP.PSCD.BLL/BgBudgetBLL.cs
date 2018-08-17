using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class BgBudgetBLL
	{
		public static KiSSDB.PersonVertragRow GetPersonAndPscdVgIdFromBudgetID(int bgBudgetID)
		{
			PersonVertragTableAdapter adapter = new PersonVertragTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PersonVertragDataTable tbl = adapter.GetPersonAndPscdVgIdFromBudgetID(bgBudgetID);
			if (tbl.Count == 0)
				return null;
			return tbl[0];
		}

		public static DateTime GetDateOfBudget(int bgBudgetID)
		{
			QueryAdapter adapter = new QueryAdapter();
			return adapter.GetDateOfBudgetID(bgBudgetID);
		}

		//public static KiSSDB.BuchungenDataTable GetBuchungenOfBudget(int bgBudgetID)
		//{
		//   BuchungenTableAdapter adapter = new BuchungenTableAdapter();
		//   adapter.InitializeKiSSAdapter(null);

		//   return adapter. GetBuchungenOfBudget(bgBudgetID);
		//}
	}
}
