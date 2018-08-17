using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Ba
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class BaWohnsituationService : ServiceCRUDBase<BaWohnsituation>
    {
        #region Constructors

        private BaWohnsituationService()
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
        public override BaWohnsituation GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<BaWohnsituation>(unitOfWork);

            var returnValue = repository
                .Where(wohnsituation => wohnsituation.BaWohnsituationID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'BaWohnsituation' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Hohlt alle Personen in derselben Wohnsituation wie der Leistungsträger.      
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="baPersonId"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public KissServiceResult GetPersonenInWohnsituation(IUnitOfWork unitOfWork, int baPersonId, out List<BaPerson> list)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            list = new List<BaPerson>();
            var repositoryBaWohnsituationPerson = UnitOfWork.GetRepository<BaWohnsituationPerson>(unitOfWork);
            DateTime today = DateTime.Today;
            var queryWohnsituation = from x in repositoryBaWohnsituationPerson
                                     where x.BaPersonID == baPersonId
                                     where x.BaWohnsituation.DatumVon <= today
                                     where x.BaWohnsituation.DatumBis >= today || x.BaWohnsituation.DatumBis == null
                                     select x.BaWohnsituation;
            BaWohnsituation wohnsituation = queryWohnsituation.FirstOrDefault();
            if (wohnsituation != null)
            {
                var queryPerson = from x in repositoryBaWohnsituationPerson
                                  where x.BaWohnsituationID == wohnsituation.BaWohnsituationID
                                  select x.BaPerson;

                list = queryPerson.ToList();
            }
            return KissServiceResult.Ok();
        }

        #endregion

        #endregion
    }
}