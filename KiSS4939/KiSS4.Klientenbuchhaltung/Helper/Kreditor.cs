
namespace KiSS4.Klientenbuchhaltung
{
	/// <summary>
	/// Base class for a Kreditor.
	/// </summary>
	public abstract class Kreditor
	{
		public abstract int Id { get; }
		public abstract string Name { get; }
		public abstract string Vorname { get; }
		public abstract string Strasse { get; }
		public abstract string Plz { get; }
		public abstract string Ort { get; }
		public abstract int IdBankverbindung { get; }

        //TODO
		//public abstract ZahlungswegCollection Zahlungswege { get; }
	}
}