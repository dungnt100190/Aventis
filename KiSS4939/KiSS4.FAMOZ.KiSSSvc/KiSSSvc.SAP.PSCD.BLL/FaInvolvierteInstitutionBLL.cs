using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public class FaInvolvierteInstitutionBLL
	{
		public static int[] GetInvolvierteInstitutionenOfPerson(int baPersonID)
		{
			FaInvolvierteInstitutionTableAdapter adapter = new FaInvolvierteInstitutionTableAdapter();
			KiSSDB.FaInvolvierteInstitutionDataTable table = adapter.GetInvolvierteInstitutionenOfPerson(baPersonID);
			List<int> institutionIDs = new List<int>();
			foreach (KiSSDB.FaInvolvierteInstitutionRow row in table)
			{
				institutionIDs.Add(row.BaInstitutionID);
			}
			return institutionIDs.ToArray();
		}
	}
}
