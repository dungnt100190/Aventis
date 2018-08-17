
namespace KiSS4.Klientenbuchhaltung
{
	/// <summary>
	/// Base class for a Kostenstelle.
	/// </summary>
	public abstract class Kostenstelle
	{
		public abstract string NameFbKostenstelle { get; }
		public abstract string NameInhaber { get; }
		public abstract int BezugsgroesseId { get; }
	}
}
