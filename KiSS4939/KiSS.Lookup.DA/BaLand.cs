using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KiSS.Common.DA;

namespace KiSS.Lookup.DA
{
    /// <summary>
    /// Partial class to keep separate with the one that is generated from the database
    /// </summary>
    public partial class BaLand : IAuthorField
    {
        #region Methods

        #region Public Methods

        public override string ToString()
        {
            return "Land: " + Text;
        }

        #endregion

        #endregion
    }
}