using System;
using KiSS4.DB;

namespace KiSS4.Fibu
{
	/// <summary>
	/// Implementiert das Business Object für den zum Sozialdienst.
	/// Der Sozialdienst wird in der Konfiguration vom Benutzer 
	/// eingetragen.
	/// </summary>
	public class SocialService
	{
		#region Properties

		private String name;
		/// <summary>
		/// Liest den namen des Sozialdienstes.
		/// </summary>
		/// <value>The name.</value>
		public String Name
		{
			get { return name; }
		}

		private String address;
		/// <summary>
		/// Liefert die Adresse.
		/// </summary>
		/// <value>The adresse.</value>
		public String Adresse
		{
			get { return address; }
		}

		private String zipCode;
		/// <summary>
		/// Liferet die Postleitzahl.
		/// </summary>
		/// <value>The PLZ.</value>
		public String PLZ
		{
			get { return zipCode; }
		}

		private String city;
		/// <summary>
		/// Liefert den Ort.
		/// </summary>
		/// <value>The ort.</value>
		public String Ort
		{
			get { return city; }
		}

		#endregion

		#region Costructor

		/// <summary>
		/// Initializes a new instance of the <see cref="SocialService"/> class.
		/// Der Sozialdient wird vom Benutzer in der Konfiguration angegeben.
		/// </summary>
		public SocialService()
		{
			name = Convert.ToString(DBUtil.GetConfigValue(@"System\Adresse\Allgemein\Organisation", ""));
			address = Convert.ToString(DBUtil.GetConfigValue(@"System\Adresse\Allgemein\Adresse", ""));
			zipCode = Convert.ToString(DBUtil.GetConfigValue(@"System\Adresse\Allgemein\PLZ", ""));
			city = Convert.ToString(DBUtil.GetConfigValue(@"System\Adresse\Allgemein\Ort", ""));
		}

		#endregion

		#region Overrides

		/// <summary>
		/// Returns the fully qualified type name of this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"></see> containing a textual representation of this element.
		/// </returns>
		public override string ToString()
		{
			return String.Format("{0}, {1}, {2} {3}",
				Name,
				Adresse,
				PLZ,
				Ort);
		}

		#endregion
	}
}
