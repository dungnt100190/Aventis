using System;
using System.Data;
using System.Text;
using KiSS4.Common;

namespace KiSS4.Klientenbuchhaltung
{
	/// <summary>
	/// Implements the business object for KbZahlungskonto
	/// </summary>
	public sealed class KbZahlungskonto
	{
		#region Properties

		private Int32 kbZahlungskontoID;
		/// <summary>
		/// Gets the ID.
		/// </summary>
		/// <value>The kb zahlungskonto ID.</value>
		public Int32 KbZahlungskontoID
		{
			get { return kbZahlungskontoID; }
		}

		private String name;
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public String Name
		{
			get { return name; }
		}

		private String vertragNr;
		/// <summary>
		/// Gets the vertrag nr.
		/// </summary>
		/// <value>The vertrag nr.</value>
		public String VertragNr
		{
			get { return vertragNr; }
		}

		private String kontoNr;
		/// <summary>
		/// Gets the konto nr.
		/// </summary>
		/// <value>The konto nr.</value>
		public String KontoNr
		{
			get { return kontoNr; }
		}

		private Int32 baBankID;
		/// <summary>
		/// Gets the ba bank ID.
		/// </summary>
		/// <value>The ba bank ID.</value>
		public Int32 BaBankID
		{
			get { return baBankID; }
		}

		private Int32 kbFinanzInstitutCode;
		/// <summary>
		/// Gets the kb finanz instituts code.
		/// </summary>
		/// <value>The kb finanz instituts code.</value>
		public Int32 KbFinanzInstitutCode
		{
			get { return kbFinanzInstitutCode; }
		}

		private BaBank bank;
		/// <summary>
		/// Gets the bank.
		/// </summary>
		/// <value>The bank.</value>
		public BaBank Bank
		{
			get { return bank; }
		}
		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="Zahlungskonto"/> class.
		/// </summary>
		/// <param name="zahlungskonto">Die datarow mit den Zahlungskonto Daten.</param>
		public KbZahlungskonto(DataRow zahlungskonto)
		{
			kbZahlungskontoID = Utils.ConvertToInt(zahlungskonto["KbZahlungskontoID"]);
			name = Utils.ConvertToString(zahlungskonto["Name"]);
			vertragNr = Utils.ConvertToString(zahlungskonto["VertragNr"]);
			kontoNr = Utils.ConvertToString(zahlungskonto["KontoNr"]);
			baBankID = Utils.ConvertToInt(zahlungskonto["BaBankID"]);
			kbFinanzInstitutCode = Utils.ConvertToInt(zahlungskonto["KbFinanzInstitutCode"]);

			// --- falls dem Zahlungskonto eine bank zugeordnet ist.
			if(baBankID != 0)
			{
				bank = new BaBank(
					Utils.ConvertToInt(zahlungskonto["BaBankID"]),
					Utils.ConvertToString(zahlungskonto["BankName"]),
					Utils.ConvertToString(zahlungskonto["Zusatz"]),
					Utils.ConvertToString(zahlungskonto["Strasse"]),
					Utils.ConvertToString(zahlungskonto["PLZ"]),
					Utils.ConvertToString(zahlungskonto["Ort"]),
					Utils.ConvertToString(zahlungskonto["ClearingNr"]),
					Utils.ConvertToInt(zahlungskonto["FilialeNr"]),
					Utils.ConvertToString(zahlungskonto["HauptsitzBCL"]),
					Utils.ConvertToString(zahlungskonto["PCKontoNr"]),
					Utils.ConvertToDateTime(zahlungskonto["GueltigAb"]),
					Utils.ConvertToInt(zahlungskonto["LandCode"]));
			}
		}

		#endregion

		/// <summary>
		/// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
		/// </returns>
		public override string ToString()
		{
			StringBuilder result = new StringBuilder();

			result.AppendLine("KbZahlungskontoID    : " + kbZahlungskontoID);
			result.AppendLine("Name                 : " + name);
			result.AppendLine("VertragNr            : " + vertragNr);
			result.AppendLine("KontoNr              : " + kontoNr);
			result.AppendLine("BaBankID             : " + baBankID.ToString());
			result.AppendLine("KbFinanzInstitutCode : " + kbFinanzInstitutCode.ToString());

			return result.ToString();
		}
	}
}
