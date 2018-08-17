using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiss.BL.Wsh;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Wsh
{
    public class WshKategorieService : ServiceCRUDBase<WshKategorie>
    {
        #region Constructors

        private WshKategorieService()
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
        /// <exception cref="EntityNotFoundException">Thrown if no <see cref="WshKategorie"/> with the given id was found.</exception>
        public override WshKategorie GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshKategorie>(unitOfWork);

            var returnValue = repository
                .Where(kategorie => kategorie.WshKategorieID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'WshKategorie' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Gets all <see cref="WshKategorie"/> entities
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use.</param>
        /// <returns>All assigned <see cref="WshKategorie"/> entities</returns>
        public List<WshKategorie> GetKategorien(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshKategorie>(unitOfWork);

            var returnValue = repository
                .Where(x => x.IstAktiv)
                .OrderBy(kategorie => kategorie.SortKey)
                .ToList();

            //returnValue.ForEach(SetEntityValidator);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();
            return returnValue;
        }

        /// <summary>
        /// Gets all "Abzug" or not "Abzug" <see cref="WshKategorie"/> entities depenting on <paramref name="istAbzug"/>
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use.</param>
        /// <param name="istAbzug"><c>true</c> if <see cref="WshKategorie"/> must be "Abzug", else <c>false</c></param>
        /// <returns>All assigned <see cref="WshKategorie"/> entities that have the Abzug-flag set</returns>
        public List<WshKategorie> GetKategorien(IUnitOfWork unitOfWork, bool istAbzug)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshKategorie>(unitOfWork);

            var returnValue = repository
                .Where(x => x.IstAktiv && x.IstAbzug == istAbzug)
                .OrderBy(kategorie => kategorie.SortKey)
                .ToList();

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();
            return returnValue;
        }

        #endregion

        #endregion
    }
}