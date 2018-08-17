using System;

namespace KiSS4.Common
{
	/// <summary>
	/// Summary description for GridColumnPCKontoFormatter.
	/// </summary>
	public class GridColumnPCKontoFormatter 
		: 
		IFormatProvider, 
		ICustomFormatter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GridColumnPCKontoFormatter"/> class.
		/// </summary>
		public GridColumnPCKontoFormatter()
		{
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

		/// <summary>
		/// Formats the specified format string.
		/// </summary>
		/// <param name="formatString">The format string.</param>
		/// <param name="arg">The arg.</param>
		/// <param name="formatProvider">The format provider.</param>
		/// <returns></returns>
		public string Format(string formatString, object arg, IFormatProvider formatProvider)
		{
			string formattedString = Utils.FormatPCKontoNummerToUserFormat(arg.ToString()) ;
			return formattedString ;
		}
	}
}
