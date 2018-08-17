using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class BaPersonBLL
	{
		public static KiSSDB.BaPersonRow GetPerson(int baPersonID)
		{
			BaPersonTableAdapter personAdapter = new BaPersonTableAdapter();
            personAdapter.InitializeKiSSAdapter(null);
			KiSSDB.BaPersonDataTable persons = personAdapter.GetPersonByID(baPersonID);
			if (persons.Rows.Count != 1)
				throw new Exception(string.Format("Es existieren {0} Personen mit ID {1} statt genau einer", persons.Rows.Count, baPersonID));
			return persons[0];

		}

		public static KiSSDB.BaPersonRow GetPersonOfKgPeriode(int kgPeriodeID)
		{
			BaPersonTableAdapter personAdapter = new BaPersonTableAdapter();
            personAdapter.InitializeKiSSAdapter(null);
			KiSSDB.BaPersonDataTable persons = personAdapter.GetPersonOfKgPeriode(kgPeriodeID);
			if (persons.Rows.Count != 1)
				throw new Exception(string.Format("Es existieren {0} Personen für KgPeriode mit ID {1} statt genau einer", persons.Rows.Count, kgPeriodeID));
			return persons[0];

		}
	}
}
