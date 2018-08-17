using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Basis.ZH.Strassenverzeichnis
{
    class BaHausDTOComparer : IEqualityComparer<BaHausDTO>
    {
        #region IEqualityComparer<BaHausDTO> Members

        public bool Equals(BaHausDTO x, BaHausDTO y)
        {
            return x.BaStrasseID == y.BaStrasseID &&
                   x.Hausnummer == y.Hausnummer &&
                   x.Suffix == y.Suffix;
        }

        public int GetHashCode(BaHausDTO obj)
        {
            return obj.GetHashCode() ^ obj.GetHashCode();
        }

        #endregion
    }
}
