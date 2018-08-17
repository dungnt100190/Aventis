using System;
using System.Data;

namespace KiSS4.Schnittstellen.Abacus.KlientenStammdaten
{
    public class Sozialberater
    {
        #region Fields

        private Int32? costCenter;
        private Int32? mitarbeiterNr;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance of Sozialberater
        /// </summary>
        /// <param name="row">The datarow to get values from</param>
        public Sozialberater(DataRow row)
        {
            // apply fields
            this.costCenter = DataHandler.GetInt32Value(row, Constants.colKostenstelle);
            this.mitarbeiterNr = DataHandler.GetInt32Value(row, Constants.colMitarbeiterNr);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Get the cost center of this Sozialarbeiter
        /// </summary>
        public Int32? CostCenter
        {
            get { return costCenter; }
        }

        /// <summary>
        /// Get the MitarbeiterNr of this Sozialarbeiter
        /// </summary>
        public Int32? MitarbeiterNr
        {
            get { return mitarbeiterNr; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a System.String that represents the current System.Object
        /// </summary>
        /// <returns>Returns a System.String that represents the current System.Object</returns>
        public override string ToString()
        {
            // return string that represents the Sozialberater (e.g. for logging)
            return String.Format(@"CostCenter='{0}', MitarbeiterNr='{1}'",
                                  this.CostCenter,		// 0
                                  this.MitarbeiterNr);	// 1
        }

        #endregion
    }
}