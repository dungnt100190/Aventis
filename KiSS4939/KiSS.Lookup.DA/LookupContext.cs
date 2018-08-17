using System;
using System.Data.Metadata.Edm;
using System.Reflection;

using KiSS.Common.DA;

namespace KiSS.Lookup.DA
{
    /// <summary>
    /// Partial class <see cref="LookupContext"/> to implement the <see cref="IUnitOfWork"/>
    /// </summary>
    public partial class LookupContext : IUnitOfWork
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Saves the changes in the object context
        /// </summary>
        public void Save()
        {
            this.SaveChanges();
        }

        #endregion

        #endregion
    }
}