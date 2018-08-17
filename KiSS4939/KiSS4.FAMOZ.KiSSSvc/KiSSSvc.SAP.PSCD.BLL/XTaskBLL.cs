using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class XTaskBLL
	{
		public static int Update(KiSSDB.XTaskDataTable table)
		{
			XTaskTableAdapter adapter = new XTaskTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.Update(table);
		}
	}
}
