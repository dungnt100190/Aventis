using System;
using System.Collections;
using KiSS4.Common;
using System.Data;

namespace KiSS4.Fibu.DTA_EZAG
{
	/// <summary>
	/// Utility class for EZAG an DTA.
	/// </summary>
	internal static class DTA_EZAGUtilities
	{
		/// <summary>
		/// Adds padding characters to a given string.
		/// </summary>
		/// <param name="Value">The value.</param>
		/// <param name="Length">The length.</param>
		/// <param name="Character">The character.</param>
		/// <param name="AtEnd">if set to <c>true</c> padding is added at the end of the string.</param>
		/// <returns></returns>
		public static string FillBlanks(
			string Value,
			int Length,
			string Character,
			bool AtEnd)
		{
			if (Value == null)
			{
				Value = "";
			}

			// --- if string too long truncate it
			if (Value.Length > Length)
			{
				Value = Value.Substring(0, Length);
			}

			// --- if string is too short, add padding charcter either
			//     at the end or at the beginning.
			while (Value.Length < Length)
			{
				if (AtEnd == true)
				{
					Value = Value + Character;
				}
				else
				{
					Value = Character + Value;
				}
			}

			return Value;
		}

		/// <summary>
		/// Converts the specified DateTime into a a DTA string.
		/// </summary>
		/// <param name="Date">The date.</param>
		/// <returns></returns>
		public static string DateTimeToDTAString(
			DateTime Date)
		{
			if (Date == DateTime.MinValue)
			{
				return "000000";
			}
			else
			{
				return Date.ToString("yyMMdd");
			}
		}

		/// <summary>
		/// Converts the specified string into a DTA string.
		/// </summary>
		/// <param name="str">The STR.</param>
		/// <returns></returns>
		public static string StringToDTAString(
			String str)
		{
			if (str == null)
			{
				return "";
			}
			else
			{
				return str.ToUpper().Replace('Ä', 'A').Replace('Ö', 'O').Replace('Ü', 'U');
			}
		}

		/// <summary>
		/// Calculates the code lines mod11.
		/// </summary>
		/// <param name="Value">The value.</param>
		/// <returns></returns>
		public static string CalculateCodeLinieMod11(
			string Value)
		{
			int[] array = new int[6] { 4, 3, 2, 7, 6, 5 };
			int result = 0;
			int j = 0;
			ArrayList arrayList = new ArrayList();

			for (int i = 0; i < Value.Length; i++)
			{
				arrayList.Add(Convert.ToInt32(Convert.ToString(Value[i])) * array[j]);
				j += 1;
				if (j == 6)
					j = 0;
			}

			for (int i = 0; i < arrayList.Count; i++)
				result += (int)arrayList[i];

			result = (result % 11);
			result = 11 - result;

			return DTA_EZAGUtilities.FillBlanks(result.ToString(), 2, "0", false);
		}

		/// <summary>
		/// Converts the specifed decimal to a DTA money string.
		/// </summary>
		/// <param name="Nummer">The nummer.</param>
		/// <param name="length">The length.</param>
		/// <returns></returns>
		public static string FormatDecimalToDTAMoney(
			string Nummer, 
			int length)
		{
			try
			{
				int nummerLength = Nummer.ToString().Length;
				string nummer = Nummer.ToString().Substring(0, nummerLength - 2);
				nummer = nummer.Replace(".", "");
				return DTA_EZAGUtilities.FillBlanks(nummer, length, "0", false);
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Checks a Postleitzahl String
		/// 1 = Ok, 2 = too long, 3 = not numeric, 4 = empty
		/// </summary>
		/// <param name="zipCode"></param>
		/// <returns>1 = Ok, 2 = too long, 3 = not numeric</returns>
		public static int CheckPostLeitzahl(string zipCode)
		{
			if (zipCode.Length > 4)
			{
				return 2;
			}

			if (zipCode.Length == 0)
			{
				return 4;
			}
			else
			{
				try
				{
					Convert.ToInt32(zipCode);
					return 1;
				}
				catch (Exception)
				{
					return 3;
				}
			}
		}

		/// <summary>
		/// Gets the payment method.
		/// </summary>
		/// <param name="paymentInformation">The payment information.</param>
		/// <returns></returns>
		public static ZahlungsArt GetPaymentMethod(
			DataRow paymentInformation)
		{
			ZahlungsArt ezagPaymentType =
				(ZahlungsArt)Enum.Parse(typeof(ZahlungsArt), paymentInformation["ZahlungsArtCode"].ToString(), true);
			return ezagPaymentType;
		}
	}
}
