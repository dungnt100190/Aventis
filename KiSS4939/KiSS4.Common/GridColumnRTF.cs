using System;
using System.Windows.Forms;

namespace KiSS4.Common
{
	/// <summary>
	/// Summary description for GridColumnRTF.
	/// </summary>
	public class GridColumnRTF : IFormatProvider, ICustomFormatter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GridColumnRTF"/> class.
		/// </summary>
		public GridColumnRTF()
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
			if (arg is string && ((string)arg).StartsWith(@"{\rtf"))
			{
				RichTextBox RtfBox = new RichTextBox();
				RtfBox.Rtf = (string)arg;
				return RtfBox.Text.Replace("\r\n",", ").Replace("\n",", ");
			}

			return arg.ToString();
		}
	}
}
