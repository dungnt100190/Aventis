using System.Windows.Forms;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung
{
	/// <summary>
	/// Base class for a control displayed on FrmFibuLink.
	/// </summary>
	public class KlibuSSTControl : KissUserControl
	{
		public virtual IButtonControl AcceptButton
		{
			get { return null; }
		}

		public virtual IButtonControl CancelButton
		{
			get { return null; }
		}

		public virtual void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
		}
	}
}
