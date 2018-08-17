using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL.KiSSDBTableAdapters;
using KiSSSvc.DAL;

namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class XConfigBLL
	{
		/// <summary>
		/// Read XConfig value
		/// </summary>
		/// <returns></returns>
		public static string GetPSCDServerProxy()
		{
			return (new QueryAdapter()).GetPSCDServerProxyURL();
		}

		public static string GetConfigValueVarchar(string keyPath)
		{
			XConfigTableAdapter adapter = new XConfigTableAdapter();
			adapter.InitializeKiSSAdapter(null);

			KiSSDB.XConfigDataTable table = adapter.GetConfigValue(keyPath,DateTime.Today);
			if (table.Rows.Count > 0)
			{
				return table[0].ValueVarchar;
			}
			return null;
		}
	}
}
