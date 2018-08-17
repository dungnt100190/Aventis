using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class vwUserBLL
	{
		public static KiSSDB.vwUserDataTable GetAnsprechpartner()
		{
			vwUserTableAdapter adapter = new vwUserTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			return adapter.GetAnsprechpartner();
		}
	}
}
