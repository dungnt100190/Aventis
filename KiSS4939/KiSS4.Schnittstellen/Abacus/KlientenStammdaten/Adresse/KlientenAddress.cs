using System;
using System.Data;
using KiSS4.Schnittstellen.AbacAddress200710;

namespace KiSS4.Schnittstellen.Abacus.KlientenStammdaten.Adresse
{
	public class KlientenAddress
	{
		#region Fields

		private String name;
		private String vorname;
		private String wohnsitzZusatz;
		private String wohnsitzStrasse;
		private String wohnsitzHausNr;
		private String wohnsitzPostfachInklText;
		private String wohnsitzPLZ;
		private String wohnsitzOrt;
		private String wohnsitzLandCode;
		private String wohnsitzStrasseHausNr;
		private Char korrespondenzSprache;

		private Boolean isEmpty;

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor, create an empty instance
		/// </summary>
		public KlientenAddress()
		{
			this.isEmpty = true;
		}

		/// <summary>
		/// Constructor, create an instance from KiSS datarow
		/// </summary>
		/// <param name="row"></param>
		public KlientenAddress(DataRow row)
		{
			// validate row
			if (row == null)
			{
				throw new ArgumentNullException("row", "The given DataRow is emtpy, cannot create a new address instance.");
			}

			// set data from datarow
			this.name = DataHandler.GetStringValue(row, Constants.colName);
			this.vorname = DataHandler.GetStringValue(row, Constants.colVorname);
			this.wohnsitzZusatz = DataHandler.GetStringValue(row, Constants.colWohnsitzZusatz);
			this.wohnsitzStrasse = DataHandler.GetStringValue(row, Constants.colWohnsitzStrasse);
			this.wohnsitzHausNr = DataHandler.GetStringValue(row, Constants.colWohnsitzHausNr);
			this.wohnsitzPostfachInklText = DataHandler.GetStringValue(row, Constants.colPostfach);
			this.wohnsitzPLZ = DataHandler.GetStringValue(row, Constants.colWohnsitzPLZ);
			this.wohnsitzOrt = DataHandler.GetStringValue(row, Constants.colWohnsitzOrt);
			this.wohnsitzLandCode = DataHandler.GetStringValue(row, Constants.colWohnsitzLandCodeISO2);
			
			this.wohnsitzStrasseHausNr = DataHandler.GetStringValue(row, Constants.colStrasseHausNr);
			this.korrespondenzSprache = Convert.ToChar(row[Constants.colSpracheChar]);

			// flag
			this.isEmpty = false;
		}

		/// <summary>
		/// Constructor, create an instance from Abacus AddressDataComType
		/// </summary>
		/// <param name="abacusAddress">The data received from Abacus</param>
		public KlientenAddress(AddressDataComType abacusAddress)
		{
			// validate row
			if (abacusAddress == null)
			{
				throw new ArgumentNullException("abacusAddress", "The given AbacusAddress is emtpy, cannot create a new address instance.");
			}

			// set data
			this.name = abacusAddress.LastName;
			this.vorname = abacusAddress.FirstName;
			this.wohnsitzZusatz = abacusAddress.Supplement;			// TODO is this Zusatz in Abacus?
			this.wohnsitzPostfachInklText = abacusAddress.Line2;
			this.wohnsitzPLZ = abacusAddress.ZIP;
			this.wohnsitzOrt = abacusAddress.City;
			this.wohnsitzLandCode = abacusAddress.Country;

			this.wohnsitzStrasseHausNr = abacusAddress.Line1;
			this.korrespondenzSprache = Convert.ToChar(abacusAddress.Language);

			// flag
			this.isEmpty = false;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get the lastname of this Klient
		/// </summary>
		public String Name
		{
			get { return name; }
		}

		/// <summary>
		/// Get the firstname of this Klient
		/// </summary>
		public String Vorname
		{
			get { return vorname; }
		}

		/// <summary>
		/// Get the WohnsitzZusatz of this Klient
		/// </summary>
		public String WohnsitzZusatz
		{
			get { return wohnsitzZusatz; }
		}

		/// <summary>
		/// Get the WohnsitzStrasse of this Klient
		/// </summary>
		public String WohnsitzStrasse
		{
			get { return wohnsitzStrasse; }
		}

		/// <summary>
		/// Get the WohnsitzHausNr of this Klient
		/// </summary>
		public String WohnsitzHausNr
		{
			get { return wohnsitzHausNr; }
		}

		/// <summary>
		/// Get the wohnsitzPostfach of this Klient including text "Postfach" as mulitlanguge if not empty
		/// </summary>
		public String WohnsitzPostfachInklText
		{
			get { return wohnsitzPostfachInklText; }
		}

		/// <summary>
		/// Get the WohnsitzPLZ of this Klient
		/// </summary>
		public String WohnsitzPLZ
		{
			get { return wohnsitzPLZ; }
		}

		/// <summary>
		/// Get the WohnsitzOrt of this Klient
		/// </summary>
		public String WohnsitzOrt
		{
			get { return wohnsitzOrt; }
		}

		/// <summary>
		/// Get the WohnsitzLandCode of this Klient
		/// </summary>
		public String WohnsitzLandCode
		{
			get { return wohnsitzLandCode; }
		}

		/// <summary>
		/// Get the WohnsitzStrasseHausNr (WohnsitzStrasse + " " + WohnsitzHausNr) of this Klient
		/// </summary>
		public String WohnsitzStrasseHausNr
		{
			get { return wohnsitzStrasseHausNr; }
		}

		/// <summary>
		/// Get the Korrespondenzsprache (D, F, I, E) for this Klient
		/// </summary>
		public Char KorrespondenzSprache
		{
			get { return korrespondenzSprache; }
		}

		/// <summary>
		/// Get flag if this address is empty and therefore does not contain any data
		/// </summary>
		public Boolean IsEmpty
		{
			get { return isEmpty; }
		}

		#endregion

		#region Public

		/// <summary>
		/// Determines whether [is equal as] [the specified comparing address].
		/// </summary>
		/// <param name="comparingAddress">The comparing address.</param>
		/// <returns>
		/// 	<c>true</c> if [is equal as] [the specified comparing address]; otherwise, <c>false</c>.
		/// </returns>
		public Boolean Equals(KlientenAddress comparingAddress)
		{
			// check if all given parameters are equal
			if (this.Name.Equals(comparingAddress.Name) &&
				this.Vorname.Equals(comparingAddress.Vorname) &&
				this.WohnsitzZusatz.Equals(comparingAddress.WohnsitzZusatz) &&
				this.WohnsitzStrasseHausNr.Equals(comparingAddress.WohnsitzStrasseHausNr) && 
				this.WohnsitzPostfachInklText.Equals(comparingAddress.WohnsitzPostfachInklText) && 
				this.WohnsitzPLZ.Equals(comparingAddress.WohnsitzPLZ) &&
				this.WohnsitzOrt.Equals(comparingAddress.WohnsitzOrt) &&
				this.WohnsitzLandCode.Equals(comparingAddress.WohnsitzLandCode) &&
				this.KorrespondenzSprache.Equals(comparingAddress.KorrespondenzSprache))
			{
				// addresses are equal
				return true;
			}

			// addresses are not equal
			return false;
		}

		/// <summary>
		/// Determines whether [is correct abacus address]. Required fields are: lastname, country, postcode, city, language
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if [is correct abacus address]; otherwise, <c>false</c>.
		/// </returns>
		public Boolean IsCorrectAbacusAddress()
		{
			// the required fields are: lastname, country, postcode, city, language
			if (DB.DBUtil.IsEmpty(this.Name) ||
				DB.DBUtil.IsEmpty(this.WohnsitzLandCode) ||
				DB.DBUtil.IsEmpty(this.WohnsitzPLZ) ||
				DB.DBUtil.IsEmpty(this.WohnsitzOrt) ||
				DB.DBUtil.IsEmpty(this.KorrespondenzSprache))
			{
				// at least one field is not valid
				return false;
			}
			
			// valid address
			return true;
		}

		/// <summary>
		/// Creates the type of the abacus address.
		/// </summary>
		/// <returns></returns>
		public AddressDataComType CreateAbacusType()
		{
			// create new instance of type
			AddressDataComType adrType = new AddressDataComType();

			// apply given values to type
			adrType.FirstName = this.Vorname;
			adrType.LastName = this.Name;
			adrType.Supplement = this.WohnsitzZusatz;			// TODO: is this Zusatz in Abacus?
			adrType.Line1 = this.WohnsitzStrasseHausNr;
			adrType.Line2 = this.WohnsitzPostfachInklText;
			adrType.ZIP = this.WohnsitzPLZ;
			adrType.City = this.WohnsitzOrt;
			adrType.Country = this.WohnsitzLandCode;
			adrType.Language = Convert.ToString(this.KorrespondenzSprache);

			// return type
			return adrType;
		}

		/// <summary>
		/// Returns a System.String that represents the current System.Object
		/// </summary>
		/// <returns>Returns a System.String that represents the current System.Object</returns>
		public override string ToString()
		{
			// return string that represents the address (e.g. for logging)
			return String.Format(@"Name='{0}', Vorname='{1}', WsZusatz='{2}', WsStrasseHausNr='{3}', WsPostfach='{4}', WsPLZ='{5}', WsOrt='{6}', WsLandCode='{7}', KorrespondenzSprache='{8}', IsEmpty='{9}'",
								  this.Name,						// 0
								  this.Vorname,						// 1
								  this.WohnsitzZusatz,				// 2
								  this.WohnsitzStrasseHausNr,		// 3
								  this.wohnsitzPostfachInklText,	// 4
								  this.WohnsitzPLZ,					// 5
								  this.WohnsitzOrt,					// 6
								  this.WohnsitzLandCode,			// 7
								  this.KorrespondenzSprache,		// 8
								  this.IsEmpty);					// 9
		}

		#endregion
	}
}
