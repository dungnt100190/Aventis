using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS.Common.IoC
{
    public interface IDBModule
    {
        #region Properties

        bool DontUseExternalConnection
        {
            get; set;
        }

        #endregion
    }
}