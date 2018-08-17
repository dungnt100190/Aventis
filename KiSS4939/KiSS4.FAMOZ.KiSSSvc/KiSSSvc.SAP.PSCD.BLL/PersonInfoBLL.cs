using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class PersonInfoBLL
	{
		public static KiSSDB.PersonInfoRow GetPersonInfo(int baPersonID)
		{
			PersonInfoTableAdapter adapter = new PersonInfoTableAdapter();
            adapter.InitializeKiSSAdapter(null);

			KiSSDB.PersonInfoDataTable table = adapter.GetAdditionalPersonInfoSP(baPersonID);
			if (table.Rows.Count == 0)
				return null;

			return table[0];
		}
	}
}
