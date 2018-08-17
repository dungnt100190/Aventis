using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.SAP.PSCD.BLL;
using KiSSSvc.Logging;

namespace KiSSSvc.SAP.PSCD.BudgetData
{
	internal class BelegNr : IDisposable
	{
		bool used = false;
		long belegNr;
		public BelegNr(long belegNr, long? existingBelegNr)
		{
			if (existingBelegNr.HasValue)
			{
				this.belegNr = existingBelegNr.Value;
				this.used = true;
			}
			else
			{
				this.belegNr = belegNr;
			}
		}

		public long Number
		{
			get { return belegNr; }
		}

		/// <summary>
		/// If the number has been sent to PSCD we don't have to register it under the lost numbers
		/// </summary>
		public void SetNumberSuccessfullyUsed()
		{
			used = true;
		}

		#region IDisposable Members

		public void Dispose()
		{
			if (!used)
			{
				//Log.Info(this.GetType(), string.Format("Registered Number {0} as lost", belegNr));
				KeysBLL.RegisterLostBelegKey(belegNr);
			}
		}

		#endregion
	}
}
