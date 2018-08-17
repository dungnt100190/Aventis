using System;

namespace KiSS4.Sozialhilfe
{
    /// <summary>
    /// Helper class for budget edit mask
    /// </summary>
    internal class BgEditMask
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BgEditMask"/> class.
        /// </summary>
        public BgEditMask()
        {
            // apply default values
            Art = false;
            Bemerkung = false;
            BetragMinus = false;
            BetragPlus = false;
            BetragRechnung = false;
            BetrifftPerson = false;
            Gruppe = false;
            GruppeFilter = false;
            Loeschen = false;
            Neu = false;
            Text = false;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Set and get the flag for "Art"
        /// </summary>
        public bool Art
        {
            set;
            get;
        }

        /// <summary>
        /// Set and get the flag for "Bemerkung"
        /// </summary>
        public bool Bemerkung
        {
            set;
            get;
        }

        /// <summary>
        /// Set and get the flag for "BetragMinus"
        /// </summary>
        public bool BetragMinus
        {
            set;
            get;
        }

        /// <summary>
        /// Set and get the flag for "BetragPlus"
        /// </summary>
        public bool BetragPlus
        {
            set;
            get;
        }

        /// <summary>
        /// Set and get the flag for "BetragRechnung"
        /// </summary>
        public bool BetragRechnung
        {
            set;
            get;
        }

        /// <summary>
        /// Set and get the flag for "BetrifftPerson"
        /// </summary>
        public bool BetrifftPerson
        {
            set;
            get;
        }

        /// <summary>
        /// Set and get the flag for "Gruppe"
        /// </summary>
        public bool Gruppe
        {
            set;
            get;
        }

        /// <summary>
        /// Set and get the flag for "GruppeFilter"
        /// </summary>
        public bool GruppeFilter
        {
            set;
            get;
        }

        /// <summary>
        /// Set and get the flag for "Loeschen"
        /// </summary>
        public bool Loeschen
        {
            set;
            get;
        }

        /// <summary>
        /// Set and get the flag for "Neu"
        /// </summary>
        public bool Neu
        {
            set;
            get;
        }

        /// <summary>
        /// Set and get the flag for "Text"
        /// </summary>
        public bool Text
        {
            set;
            get;
        }

        #endregion
    }
}