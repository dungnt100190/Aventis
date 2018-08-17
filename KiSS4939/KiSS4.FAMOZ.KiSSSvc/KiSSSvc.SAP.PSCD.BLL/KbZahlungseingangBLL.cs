using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class KbZahlungseingangBLL
	{
		public static int Update(KiSSDB.KbZahlungseingangDataTable table)
		{
			KbZahlungseingangTableAdapter adapter = new KbZahlungseingangTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.Update(table);
		}

		public static KiSSDB.KbZahlungseingangRow FindZahlungseingang(string zahlungsstapelID, int position)
		{
			KbZahlungseingangTableAdapter adapter = new KbZahlungseingangTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.KbZahlungseingangDataTable table = adapter.GetZahlungseingangByZahlstapelIDs(zahlungsstapelID, position);
			if (table.Rows.Count > 0)
				return table[0];

			return null;
		}
	}
}
