using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Ba
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class BaKlientensystemService : ServiceCRUDBase<vwBaKlientensystemPerson>
    {
        #region Constructors

        private BaKlientensystemService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Lädt einen Datensatz aufgrund der ID.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="id">Die ID des Datensatzes.</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public override vwBaKlientensystemPerson GetById(IUnitOfWork unitOfWork, int id)
        {
            throw new InvalidOperationException("The entity 'vwKlientensystemPerson' has a combined key. This function only supports single keys and therefore cannot be used.");
        }

        /// <summary>
        /// Get the Klientensystem by providing the ID of the Fall
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="faFallId"></param>
        /// <returns>List of BaPerson representing the Klientensystem</returns>
        public List<BaPerson> GetKlientensystemByFaFallId(IUnitOfWork unitOfWork, int faFallId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<vwBaKlientensystemPerson>(unitOfWork);
            var personen = UnitOfWork.GetRepository<BaPerson>(unitOfWork);

            // Get BaPerson Liste from vwKlientensystemPerson und BaPerson
            var klientensystem = from klisys in repository
                                 join person in personen on klisys.BaPersonID equals person.BaPersonID
                                 where klisys.FaFallID == faFallId
                                 where !klisys.DatumVon.HasValue || klisys.DatumVon.Value <= DateTime.Today
                                 where !klisys.DatumBis.HasValue || klisys.DatumBis.Value >= DateTime.Today
                                 orderby person.Name, person.Vorname
                                 select person;

            return klientensystem.ToList();
        }

        /// <summary>
        /// Get the Klientensystem by providing an FaLeistungID
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="faLeistungId"></param>
        /// <returns>A List of BaPerson representing the Klientensystem</returns>
        public List<BaPerson> GetKlientensystemByFaLeistungId(IUnitOfWork unitOfWork, int faLeistungId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var leistungen = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);

            // Get FallId from Leistung
            var faFallId = (from lei in leistungen
                            where lei.FaLeistungID == faLeistungId
                            select lei.FaFallID).FirstOrDefault();

            // Get BaPerson Liste from vwKlientensystemPerson und BaPerson
            return faFallId > 0 ? GetKlientensystemByFaFallId(unitOfWork, faFallId) : new List<BaPerson>();
        }

        #endregion

        #endregion
    }
}