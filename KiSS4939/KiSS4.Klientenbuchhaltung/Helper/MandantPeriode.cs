using System;

namespace KiSS4.Klientenbuchhaltung
{
	/// <summary>
	/// Base class for a selected Mandant and Period.
	/// </summary>
	public abstract class MandantPeriode
	{
		public abstract string Mandant { get; }
		public abstract DateTime DateFrom { get; }
		public abstract DateTime DateTo { get; }
		
		public override string ToString()
		{
			return string.Format("{0} ({1:d}-{2:d})", this.Mandant, this.DateFrom, this.DateTo);
		}
	}
}
