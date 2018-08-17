using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class KbOpAusgleichBLL
	{
		public static int Insert(int opbuchungID, int ausgleichBuchungID, decimal betrag)
		{
			KbOpAusgleichTableAdapter adapter = new KbOpAusgleichTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.Insert(betrag, opbuchungID, ausgleichBuchungID);
		}

		public static decimal GetSettledAmountOfOp(int opBuchungID)
		{
			KbOpAusgleichTableAdapter adapter = new KbOpAusgleichTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.KbOpAusgleichDataTable table = adapter.GetAusgleicheByOpBuchungID(opBuchungID);
			decimal total = 0m;
			foreach (KiSSDB.KbOpAusgleichRow settlement in table)
			{
				total += settlement.Betrag;
			}
			return total;
		}
	}
}
