using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL.KiSSDBTableAdapters;
using KiSSSvc.DAL;

namespace KiSSSvc.SAP.PSCD.BLL
{
	//public static class BgFinanzPlanBLL
	//{
		//public static int GetFinanzPlanIDByBudgetID(int bgBudgetID)
		//{
		//   BgFinanzPlanTableAdapter adapter = new BgFinanzPlanTableAdapter();
		//   adapter.InitializeKiSSAdapter(null);

		//   return adapter.GetFinanzPlanIDByBudgetID(bgBudgetID);
		//}

		//public static KiSSDB.BgFinanzPlanRow GetFinanzPlanRowByBudgetID(int bgBudgetID)
		//{
		//   BgFinanzPlanTableAdapter adapter = new BgFinanzPlanTableAdapter();
		//   adapter.InitializeKiSSAdapter(null);

		//   KiSSDB.BgFinanzPlanDataTable tbl = adapter.GetFinanzPlanByBudgetID(bgBudgetID);
		//   if (tbl.Count == 1)
		//      return tbl[0];
		//   return null;
		//}

		//public static List<int> GetSupportedPersonsOfFinanzPlan(int bgFinanzPlanID)
		//{
		//   BgFinanzPlan_BaPersonTableAdapter adapter = new BgFinanzPlan_BaPersonTableAdapter();
		//   adapter.InitializeKiSSAdapter(null);

		//   KiSSDB.BgFinanzPlan_BaPersonDataTable tbl = adapter.GetSupportedPersonsOfFinanzPlan(bgFinanzPlanID);
		//   List<int> persons = new List<int>();
		//   foreach (KiSSDB.BgFinanzPlan_BaPersonRow row in tbl)
		//      persons.Add(row.BaPersonID);

		//   return persons;
		//}

		//public static int UpdatePscdVgID(ref KiSSDB.BgFinanzPlanRow row, long pscdVgID)
		//{
		//   BgFinanzPlanTableAdapter adapter = new BgFinanzPlanTableAdapter();
		//   adapter.InitializeKiSSAdapter(null);

		//   int affectedRows = adapter.UpdatePscdVgID(pscdVgID, row.BgFinanzPlanID, row.BgFinanzPlanTS);
		//   if (affectedRows == 1)
		//      row.PscdVgID = pscdVgID;
		//   else
		//      throw new Exception("Der FaLeistung konnte keine Vertragsgegenstands-Nr zugeordnet werden. Ursache ist wohl ein Concurrency-Problem, jemand hat beinahe gleichzeitig diese Leistung an PSCD gesendet");
		//   return affectedRows;
		//}
	//}
}
