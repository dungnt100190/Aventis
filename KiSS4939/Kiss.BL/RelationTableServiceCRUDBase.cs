using System;

using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL
{
    /// <summary>
    /// Generischer Service für Relations-Tabellen, wenn keine spezifischen Methoden benötigt werden.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RelationTableServiceCRUDBase<T> : ServiceCRUDBase<T>
        where T : class, IObjectWithChangeTracker, IValidating<T>, new()
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="id">Die ID des Datensatzes.</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public override T GetById(IUnitOfWork unitOfWork, int id)
        {
            throw new NotImplementedException("This function is not implemented. Every service should override it until a generic approach is implemented.");
        }

        #endregion

        #endregion
    }
}