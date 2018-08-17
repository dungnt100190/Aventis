using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class PscdKlientengelderSaldoLogBLL
	{
		
		public static KiSSDB.PscdKlientengelderSaldoLogDataTable GetAllKlientengelderSaldoLog()
		{
            PscdKlientengelderSaldoLogTableAdapter adapter = new PscdKlientengelderSaldoLogTableAdapter();
			adapter.InitializeKiSSAdapter(null);

            return adapter.GetPscdKlientengelderSaldoLog();
		}

        public static int Update(KiSSDB.PscdKlientengelderSaldoLogDataTable table)
        {
            PscdKlientengelderSaldoLogTableAdapter adapter = new PscdKlientengelderSaldoLogTableAdapter();
            adapter.InitializeKiSSAdapter(null);

            return adapter.Update(table);
        }
	}
}
