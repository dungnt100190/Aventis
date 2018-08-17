using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;
using KiSSSvc.DAL.TransactionalTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class KbBuchungStornoBLL
	{
        public static void spKbBuchung_StornoCheck(int kbbuchungID)
        {
            KbBuchungStornoTableAdapter adapter = new KbBuchungStornoTableAdapter();
            adapter.InitializeKiSSAdapter(null);
            adapter.spKbBuchung_StornoCheck(kbbuchungID);
        }

        public static void spKbBuchung_StornoUpdateErrorMessage(TransactionHelper transHelper, int kbbuchungID, string ErrorMsg)
        {
            KbBuchungStornoTableAdapter adapter = new KbBuchungStornoTableAdapter();
            adapter.InitializeKiSSAdapter(transHelper);
            adapter.spKbBuchung_StornoUpdateErrorMessage(kbbuchungID, ErrorMsg);
        }

        public static void spKbBuchung_StornoUpdateStornoBelegNr(TransactionHelper transHelper, int kbbuchungID, long StornoBelegNr)
        {
            KbBuchungStornoTableAdapter adapter = new KbBuchungStornoTableAdapter();
            adapter.InitializeKiSSAdapter(transHelper);
            adapter.spKbBuchung_StornoUpdateStornoBelegNr(kbbuchungID, StornoBelegNr);
        }
	}
}
