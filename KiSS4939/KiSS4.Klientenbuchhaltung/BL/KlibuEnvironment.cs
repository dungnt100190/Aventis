using System;

using KiSS4.DB;

namespace KiSS4.Klientenbuchhaltung.BL
{
	public enum KlibuSystem
	{
		Kein,       
        Integriert  //KiSS intern
	}

	/// <summary>
	/// Base class for a fibu environment
	/// </summary>
	public abstract class KlibuEnvironment
	{	

		private bool _isActive;
		private MandantPeriode _manPer;

		/// <summary>
		/// Gets a value indicating whether the Fibu-System is activated.
		/// </summary>
		public bool IsActive
		{
			get { return this._isActive; }
		}


		/// <summary>
		/// Gets the selected Mandant and Period.
		/// </summary>
		public MandantPeriode SelectedManPer
		{
			get
			{
				MandantPeriode ret;
                if (this.IsLoggedOn)
                {
                    ret = this._manPer;
                }
                else
                {
                    ret = null;
                }

			    return ret;
			}
		}

		#region abstract
        public abstract int PeriodeID { get; protected set; }
        public abstract DateTime PeriodeVon { get; protected set; }
        public abstract DateTime PeriodeBis { get; protected set; }
        public abstract int MandantID { get; protected set; }
        public abstract string MandantBezeichnung { get; protected set; }
        public abstract KlibuSystem KlibuSystem { get; }

        public abstract bool IsLoggedOn { get; }

        public abstract void Reset();

        public override string ToString()
        {
            return string.Format(KissMsg.GetMLMessage("KliBuEnvironment", "PeriodeInfo", "Klientenbuchhaltung Mandant: {0} Periode: {1}-{2}"), this.MandantBezeichnung, this.PeriodeVon.ToShortDateString(), this.PeriodeBis.ToShortDateString());
        }
	}
}
        #endregion