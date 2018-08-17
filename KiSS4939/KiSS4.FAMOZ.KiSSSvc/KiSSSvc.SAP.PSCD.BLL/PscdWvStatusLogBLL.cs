using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class PscdWvStatusLogBLL
	{
		
		public static KiSSDB.PscdWvStatusLogDataTable GetAllWvStatusLog()
		{
            PscdWvStatusLogTableAdapter adapter = new PscdWvStatusLogTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.GetPscdWvStatusLog();
		}

        //public static bool Insert(string source, int? wvEinzelpostenId, string OPBEL, int? wvStatusCodeAlt, int? wvStatusCodeNeu, DateTime erstelltDatum, bool verarbeitet, string fehlermeldung)
        //{
        //    PscdWvStatusLogTableAdapter adapter = new PscdWvStatusLogTableAdapter();
        //    adapter.InitializeKiSSAdapter(null);

        //    return adapter.Insert(source, wvEinzelpostenId, OPBEL, wvStatusCodeAlt, wvStatusCodeNeu, erstelltDatum, verarbeitet, fehlermeldung) == 1;
        //}
	}
}
