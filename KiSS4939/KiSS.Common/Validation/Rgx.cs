using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS.Common.Validation
{
    /// <summary>
    /// Container class containing a series of Regular Expressions
    /// </summary>
    public static class Rgx
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        public const string KantonCode = @"^[A-Z]{2}$";
        public const string Landcode = @"^[A-Z]{2}$";
        public const string PCKontoNr = @"^[0-9]{2}-[0-9]{1,6}-[0-9]$";
        public const string SwiftAdresse = @"^.{11}$";

        #endregion

        #endregion
    }
}