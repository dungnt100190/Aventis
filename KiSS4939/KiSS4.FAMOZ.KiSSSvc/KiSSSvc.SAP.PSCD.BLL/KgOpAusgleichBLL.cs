using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class KgOpAusgleichBLL
	{
		public static int Insert(int opbuchungID, int ausgleichBuchungID, decimal betrag)
		{
			KgOpAusgleichTableAdapter adapter = new KgOpAusgleichTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.Insert(opbuchungID, ausgleichBuchungID, betrag);
		}
	}
}
