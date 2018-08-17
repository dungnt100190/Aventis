using System;

namespace KiSS4.Common.PI
{
    /// <summary>
    /// The Data Transfer Object for the Einsatz Helper
    /// </summary>
    public class EinsatzDTO
    {
        #region Properties

        /// <summary>
        /// Identification of the client
        /// </summary>
        public int BaPersonID
        {
            get;
            set;
        }

        /// <summary>
        /// The set access mode
        /// </summary>
        public EinsatzHelper.AccessMode CurrentAccessMode
        {
            get;
            set;
        }

        /// <summary>
        /// Get and set the DatumBis
        /// </summary>
        public DateTime DatumBis
        {
            get;
            set;
        }

        /// <summary>
        /// Get and set the DatumVon
        /// </summary>
        public DateTime DatumVon
        {
            get;
            set;
        }

        /// <summary>
        /// Code for the type of the current intervention
        /// </summary>
        public int EinsatzTyp
        {
            get;
            set;
        }

        /// <summary>
        /// Identification of the FaLeistung in which the intervention is hosted
        /// </summary>
        public int FaLeistungID
        {
            get;
            set;
        }

        /// <summary>
        /// Identification of the employee
        /// </summary>
        public int UserId
        {
            get;
            set;
        }

        #endregion
    }
}