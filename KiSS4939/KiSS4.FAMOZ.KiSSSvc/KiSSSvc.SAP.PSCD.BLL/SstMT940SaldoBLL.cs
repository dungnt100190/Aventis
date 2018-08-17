using System;

using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.BLL
{
    public static class SstMT940SaldoBLL
    {
        public static int InsertIfNotExists(string kontonummer, string pscdKontoauszugID, int? baPersonID, DateTime? stichtag, decimal startSaldo, decimal endSaldo)
        {
            SstMT940SaldoTableAdapter adapter = new SstMT940SaldoTableAdapter();
            adapter.InitializeKiSSAdapter(null);

            return adapter.InsertIfNotExistsQuery(kontonummer, baPersonID, stichtag, startSaldo, endSaldo, "nobody (-1)", DateTime.Now, "nobody (-1)", DateTime.Now, pscdKontoauszugID);
        }
    }
}