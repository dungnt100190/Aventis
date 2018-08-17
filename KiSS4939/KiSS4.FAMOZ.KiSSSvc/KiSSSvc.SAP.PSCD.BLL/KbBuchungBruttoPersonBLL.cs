using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;
using KiSSSvc.DAL.TransactionalTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class KbBuchungBruttoPersonBLL
	{
        public static int UpdateVerwPeriode(TransactionHelper transHelper, DateTime VerwPeriodeVon, DateTime VerwPeriodeBis, int kbBuchungBruttoPersonID)
		{
            KbBuchungBruttoPersonTableAdapter adapter = new KbBuchungBruttoPersonTableAdapter();
            adapter.InitializeKiSSAdapter(transHelper);

            return adapter.UpdateVerwPeriode(VerwPeriodeVon, VerwPeriodeBis, kbBuchungBruttoPersonID);
		}

        public static int GetBgKategorieCode(int kbBuchungBruttoPersonID)
        {
            KbBuchungBruttoPersonTableAdapter adapter = new KbBuchungBruttoPersonTableAdapter();
            adapter.InitializeKiSSAdapter(null);

            return adapter.GetBgKategorieCode(kbBuchungBruttoPersonID);
        }
	}
}
