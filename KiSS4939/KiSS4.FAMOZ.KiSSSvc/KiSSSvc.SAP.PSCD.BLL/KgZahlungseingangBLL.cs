using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class KgZahlungseingangBLL
	{
		public static int Update(KiSSDB.KgZahlungseingangDataTable table)
		{
			KgZahlungseingangTableAdapter adapter = new KgZahlungseingangTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.Update(table);
		}
	}
}
