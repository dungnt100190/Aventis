using System;

namespace KiSS4.Klientenbuchhaltung
{
	/// <summary>
	/// Base class for the select mandant and period "dialog".
	/// </summary>
	public class CtlSelManPer : KlibuSSTControl
	{
        //TODO das passt so nicht
		public class SelManPerEventArgs : EventArgs
		{
			public readonly MandantPeriode MandantPeriode;

			public SelManPerEventArgs(MandantPeriode manPer)
			{
				if (manPer == null) throw new ArgumentNullException("manPer");
				this.MandantPeriode = manPer;
			}
		}

		public delegate void SelManPerEventHandler(object sender, SelManPerEventArgs e);

		public event SelManPerEventHandler Accepted;
		public event EventHandler Canceled;

		protected virtual void OnAccepted(SelManPerEventArgs e)
		{
			if (this.Accepted != null)
				this.Accepted(this, e);
		}

		protected virtual void OnCanceled(EventArgs e)
		{
			if (this.Canceled != null)
				this.Canceled(this, e);
		}
	}
}
