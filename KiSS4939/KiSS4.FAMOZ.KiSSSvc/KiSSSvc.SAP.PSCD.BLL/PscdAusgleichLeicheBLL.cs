using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class PscdAusgleichLeicheBLL
	{
		public static KiSSDB.PscdAusgleichLeicheDataTable GetAusgleichLeichenAndDelete()
		{
			PscdAusgleichLeicheTableAdapter adapter = new PscdAusgleichLeicheTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.PscdAusgleichLeicheDataTable table = adapter.GetAusgleichLeichen();
			adapter.ClearTable();
			return table;
		}

        public static bool Insert(string AUGBL, decimal? AUGBT, string AUGDT, string AUGRD, string EZDAT, string GPART, string KEYZ1, string OPBEL, string OPUPK, string OPUPW, string OPUPZ, string POSZA, string VTREF, string WVSTAT, string Fehlermeldung)
		{
			PscdAusgleichLeicheTableAdapter adapter = new PscdAusgleichLeicheTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.Insert(AUGBL, AUGBT, AUGDT, AUGRD, EZDAT, OPBEL, VTREF, GPART, KEYZ1, OPUPK, OPUPW, OPUPZ, POSZA, WVSTAT, DateTime.Now, Fehlermeldung) == 1;
		}

	}
}
