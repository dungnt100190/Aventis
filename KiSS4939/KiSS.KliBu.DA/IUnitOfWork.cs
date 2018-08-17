using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS.KliBu.DA
{
    /// <summary>
    /// Interface to implement the unit of work pattern
    /// </summary>
    /// <remarks>for each DA an IUnitOfWork interface is required - unique namespace for IoC</remarks>
    public interface IUnitOfWork
    {
        #region Methods

        void Save();

        #endregion
    }
}