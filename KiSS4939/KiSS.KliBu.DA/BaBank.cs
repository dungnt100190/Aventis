using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS.KliBu.DA
{
    /// <summary>
    /// Partial class to keep separate with the one that is generated from the database
    /// </summary>
    public partial class BaBank
    {
        #region Public Properties

        /// <summary>
        /// Gets the key of a <see cref="BaBank"/>
        /// </summary>
        public string Key
        {
            get { return KeyValue(ClearingNr, FilialeNr); }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Generates a key value with the <see cref="clearingNr"/> and the <see cref="filialNr"/>
        /// </summary>
        /// <param name="clearingNr">The clearing number</param>
        /// <param name="filialNr">The branch number</param>
        /// <returns></returns>
        public static string KeyValue(string clearingNr, int filialNr)
        {
            return clearingNr + "#" + filialNr;
        }

        /// <summary>
        /// Returns the <see cref="Key"/> to identifie the <see cref="BaBank"/>
        /// </summary>
        /// <returns>The <see cref="Key"/></returns>
        public override string ToString()
        {
            return Key;
        }

        #endregion
    }
}