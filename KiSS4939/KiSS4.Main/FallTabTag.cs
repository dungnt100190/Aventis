using System;

namespace KiSS4.Main
{
    internal class FallTabTag
    {
        #region Fields

        /// <summary>
        /// Store the id of the client to show information from
        /// </summary>
        private Int32 _BaPersonID = -1;

        /// <summary>
        /// Store the tabpage number shown in title of the tabpage
        /// </summary>
        private Int32 _TabNumber = -1;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance of class
        /// </summary>
        /// <param name="baPersonID">The id of the client used for the tabpage</param>
        /// <param name="tabNumber">The number of the tabpage shown in title</param>
        public FallTabTag(Int32 baPersonID, Int32 tabNumber)
        {
            // validate
            if (baPersonID < 1)
            {
                throw new ArgumentOutOfRangeException("baPersonID", "Invalid BaPersonID given, cannot create instance.");
            }

            if (tabNumber < 1)
            {
                throw new ArgumentOutOfRangeException("tabNumber", "Invalid TabNumber given, cannot create instance.");
            }

            // apply fields
            this._BaPersonID = baPersonID;
            this._TabNumber = tabNumber;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Get the id of the client used for the tabpage
        /// </summary>
        public Int32 BaPersonID
        {
            get { return this._BaPersonID; }
        }

        /// <summary>
        /// Get the number of the tabpage shown in title
        /// </summary>
        public Int32 TabNumber
        {
            get { return this._TabNumber; }
        }

        #endregion
    }
}