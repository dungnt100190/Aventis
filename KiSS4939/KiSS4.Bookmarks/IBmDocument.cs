using System;
using System.Collections.Generic;
using System.Text;

using KiSS4.Bookmarks.Control;

namespace KiSS4.Bookmarks
{
    interface IBmDocument
    {
        #region Methods

        void Parse(BmProvider bmProvider);

        void Save();

        #endregion
    }
}