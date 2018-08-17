using System;

namespace KiSS4.Fallfuehrung.SozialSystem
{
	/// <summary>
	/// Represents a Fall.
	/// </summary>
	public class Fall
	{
		public readonly int FallId;
		public readonly int ModulCode;
		public readonly ModulStatus ModulStatus;
		public readonly Person FallTraeger;

		public Fall(int fallId, int modulCode, ModulStatus modulStatus, Person fallTraeger)
		{
			if (fallTraeger == null) throw new ArgumentNullException("fallTraeger");

			this.FallId = fallId;
			this.ModulCode = modulCode;
			this.ModulStatus = modulStatus;
			this.FallTraeger = fallTraeger;
		}
	}
}
