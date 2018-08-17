using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web;
using KiSSSvc.DAL.KiSSDBTableAdapters;
using KiSSSvc.DAL;
using KiSSSvc.Logging;

namespace KiSSSvc.BLL
{
	public static class LOV
	{
		public static Hashtable GetHashtable(string lovName)
		{
			Hashtable ht = HttpRuntime.Cache[lovName] as Hashtable;
			if (ht != null)
				return ht;

			XLOVCodeTableAdapter lovAdapter = new XLOVCodeTableAdapter();
            lovAdapter.InitializeKiSSAdapter(null);

			KiSSDB.XLOVCodeDataTable lovTable = lovAdapter.GetLOV(lovName);
			ht = new Hashtable();
			foreach (KiSSDB.XLOVCodeRow lovRow in lovTable)
			{
				if (!lovRow.IsValue1Null())
					ht.Add(TrimString(lovRow.Value1), lovRow.KiSSCode);
			}
			HttpRuntime.Cache.Add(lovName, ht, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0), System.Web.Caching.CacheItemPriority.Normal, null);
			//Log.Info(typeof(LOV), string.Format("LOV {0} fetched, {1} rows", lovName, ht.Count));
			return ht;
		}

		public static Hashtable GetHashtableKissToPscd(string lovName)
		{
			Hashtable ht = HttpRuntime.Cache[lovName] as Hashtable;
			if (ht != null)
				return ht;

			XLOVCodeTableAdapter lovAdapter = new XLOVCodeTableAdapter();
            lovAdapter.InitializeKiSSAdapter(null);

			KiSSDB.XLOVCodeDataTable lovTable = lovAdapter.GetLOV(lovName);
			ht = new Hashtable();
			foreach (KiSSDB.XLOVCodeRow lovRow in lovTable)
			{
				if (!lovRow.IsValue1Null())
					ht.Add(lovRow.KiSSCode, (lovRow.Value1));
			}
			HttpRuntime.Cache.Add(lovName, ht, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0), System.Web.Caching.CacheItemPriority.Normal, null);
			//Log.Info(typeof(LOV), string.Format("LOV {0} fetched, {1} rows", lovName, ht.Count));
			return ht;
		}

		public static Hashtable GetHashtableCodeToShortText(string lovName)
		{
			Hashtable ht = HttpRuntime.Cache[lovName] as Hashtable;
			if (ht != null)
				return ht;

			XLOVCodeTableAdapter lovAdapter = new XLOVCodeTableAdapter();
            lovAdapter.InitializeKiSSAdapter(null);

			KiSSDB.XLOVCodeDataTable lovTable = lovAdapter.GetLOV(lovName);
			ht = new Hashtable();
			foreach (KiSSDB.XLOVCodeRow lovRow in lovTable)
			{
				if (!lovRow.IsShortTextNull())
					ht.Add(lovRow.KiSSCode, lovRow.ShortText);
			}
			HttpRuntime.Cache.Add(lovName, ht, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0), System.Web.Caching.CacheItemPriority.Normal, null);
			//Log.Info(typeof(LOV), string.Format("LOV {0} fetched, {1} rows", lovName, ht.Count));
			return ht;
		}

		private static string TrimString(object o)
		{
			string str = o as string;
			if (str != null)
			{
				return str.TrimEnd();
			}
			return null;
		}

	}
}
