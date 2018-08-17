using System;

namespace KiSS4.Klientenbuchhaltung
{
	/// <summary>
	/// Implements the business object for BaBank.
	/// </summary>
	public sealed class BaBank
	{
		#region Properties

	    public int BaBankId { get; set; }

	    public string Name { get; set; }

	    public string Zusatz { get; set; }

	    public string Strasse { get; set; }

	    public string Plz { get; set; }

	    public string Ort { get; set; }

	    public string ClearingNr { get; set; }

	    public int FilialeNr { get; set; }

	    public string HauptsitzBcl { get; set; }

	    public string PcKontoNr { get; set; }

	    public DateTime GueltigAb { get; set; }

	    public int LandCode { get; set; }

	    #endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="BaBank"/> class.
		/// </summary>
		public BaBank(
			Int32 baBankId,
			String name,
			String zusatz,
			String strasse,
			String plz,
			String ort,
			String clearingNr,
			Int32 filialeNr,
			String hauptsitzBcl,
			String pcKontoNr,
			DateTime gueltigAb,
			Int32 landCode
		)
		{
			BaBankId = baBankId;
			Name = name;
			Zusatz = zusatz;
			Strasse = strasse;
			Plz = plz;
			Ort = ort;
			ClearingNr = clearingNr;
			FilialeNr = filialeNr;
			HauptsitzBcl = hauptsitzBcl;
			PcKontoNr = pcKontoNr;
			GueltigAb = gueltigAb;
			LandCode = landCode;
		}

		#endregion
	}
}
