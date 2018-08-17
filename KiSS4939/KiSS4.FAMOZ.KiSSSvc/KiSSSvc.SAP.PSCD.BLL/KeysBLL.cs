using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class KeysBLL
	{
		public static long GetBelegNr(string belegart)
		{
			return (new QueryAdapter()).GetBelegNr(belegart);
		}

		public static long GetFirstID(string belegart)
		{
			return (new QueryAdapter()).GetFirstKeyID(belegart);
		}

		public static void RegisterLostBelegKey(long belegNr)
		{
            PscdVerloreneBelegNummernTableAdapter adapter = new PscdVerloreneBelegNummernTableAdapter();
            adapter.InitializeKiSSAdapter(null);
            adapter.InsertBelegNr(belegNr);
		}

		public static void RemoveBelegNr(long belegNr)
		{
            PscdVerloreneBelegNummernTableAdapter adapter = new PscdVerloreneBelegNummernTableAdapter();
            adapter.InitializeKiSSAdapter(null);
            adapter.InsertBelegNr(belegNr);
		}
	}
}
