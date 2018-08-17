using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class PscdMahnungLogBLL
	{
		
		public static KiSSDB.PscdMahnungLogDataTable GetAllMahnungLog()
		{
            PscdMahnungLogTableAdapter adapter = new PscdMahnungLogTableAdapter();
			adapter.InitializeKiSSAdapter(null);

            return adapter.GetPscdMahnungLog();
		}

        public static int Update(KiSSDB.PscdMahnungLogDataTable table)
        {
            PscdMahnungLogTableAdapter adapter = new PscdMahnungLogTableAdapter();
            adapter.InitializeKiSSAdapter(null);

            return adapter.Update(table);
        }
	}
}
