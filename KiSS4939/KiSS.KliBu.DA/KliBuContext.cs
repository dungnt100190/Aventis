using System;
using System.Data.Metadata.Edm;
using System.Reflection;

using KiSS.Common.DA;

namespace KiSS.KliBu.DA
{
    /// <summary>
    /// Partial class <see cref="KliBuContext"/> to implement the <see cref="IUnitOfWork"/>
    /// </summary>
    ///
    public partial class KliBuContext : IUnitOfWork
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Saves the changes in the object context
        /// </summary>
        /// <remarks>Es gilt noch abzuklären, ob zusätzlich noch SaveChanges(false) als
        /// Public Methode zur Verfügung gestellt werden soll (bei Verwendung von TransactionScope)
        /// </remarks>
        public void Save()
        {
            this.SaveChanges();
        }

        #endregion

        #endregion
    }
}