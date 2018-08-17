using System;
using KiSS4.DB;

namespace KiSS4.Common
{
	/// <summary>
	/// Summary description for GridColumnLookup.
	/// </summary>
	public class GridColumnLookup : IFormatProvider, ICustomFormatter
	{
		private const string SQLDelimiter = "----";
		private string sql = "";

		/// <summary>
		/// Initializes a new instance of the <see cref="GridColumnLookup"/> class.
		/// </summary>
		/// <param name="sql">The SQL.</param>
		public GridColumnLookup(string sql)
		{
			if (sql != null && sql.IndexOf(SQLDelimiter) != -1)
				this.sql = sql.Substring(sql.IndexOf(SQLDelimiter) + SQLDelimiter.Length);
		}

		/// <summary>
		/// Gets the format.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public object GetFormat(System.Type type)
		{
			return this ;
		}
		
		private DateTime cachedExpire;
		private object cachedValue;
		private object cachedDisplayValue;

		/// <summary>
		/// Formats the specified format string.
		/// </summary>
		/// <param name="formatString">The format string.</param>
		/// <param name="arg">The arg.</param>
		/// <param name="formatProvider">The format provider.</param>
		/// <returns></returns>
		public string Format(string formatString, object arg, IFormatProvider formatProvider)
		{
			if (DBUtil.IsEmpty(arg)) return "";

			try 
			{
				if (this.sql == "")
					return arg.ToString();
				else
				{
					if ( !arg.Equals(cachedValue) || DateTime.Now > cachedExpire )
					{
						cachedValue = arg;
						cachedExpire = DateTime.Now.AddSeconds(2);
						cachedDisplayValue = DBUtil.ExecuteScalarSQL(sql, arg);
					}

					if ( DBUtil.IsEmpty(cachedDisplayValue) )
						return "";
					else
						return cachedDisplayValue.ToString();
				}
			}
			catch 
			{
				cachedValue = null;
				return arg.ToString();
			}
		}
	}
}
