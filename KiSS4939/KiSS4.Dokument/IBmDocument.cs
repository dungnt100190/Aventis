using System;
using System.Collections.Generic;
using System.Text;

using KiSS4.Dokument.ExcelAutomation;

namespace KiSS4.Dokument
{
    interface IBmDocument
    {
        #region Methods

        void Parse(BmProvider bmProvider);

        void Save();

        #endregion
    }
}