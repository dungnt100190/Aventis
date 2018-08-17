using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class KgKontoBLL
	{
        public static object UpdateKgKontoSaldo(decimal saldo, DateTime datum, int? baPersonID, string konto)
        {
            KgKontoTableAdapter adapter = new KgKontoTableAdapter();
            adapter.InitializeKiSSAdapter(null);
            return adapter.SetKontoSaldo(saldo, datum, baPersonID, konto);
        }
	}
}
