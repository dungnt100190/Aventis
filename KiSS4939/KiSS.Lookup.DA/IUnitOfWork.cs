using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS.Lookup.DA
{
    /// <summary>
    /// Interface to implement the unit of work pattern
    /// </summary>
    public interface IUnitOfWork
    {
        #region Methods

        void Save();

        #endregion
    }
}