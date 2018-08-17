using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiss.BL.Wsh;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;

using KiSS.Common.Exceptions;
using System.Collections.ObjectModel;
using Kiss.Infrastructure.Constant;

namespace Kiss.BL.Wsh
{
    public class WshKontoAttributService : ServiceCRUDBase<WshKontoAttribut>
    {
        #region Constructors

        private WshKontoAttributService()
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
        /// <exception cref="EntityNotFoundException">Thrown if no <see cref="WshKontoAttribut"/> with the given id was found.</exception>
        public override WshKontoAttribut GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshKontoAttribut>(unitOfWork);

            var returnValue = repository
                .Where(x => x.WshKontoAttributID == id)
                .Include(x => x.KbuKonto)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'WshKontoAttribut' found with id: " + id);
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
        public List<WshKontoAttribut> GetKontoAttribute(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshKontoAttribut>(unitOfWork);

            var returnValue = repository
                .Include(x => x.KbuKonto)
                .ToList();

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();
            return returnValue;
        }


        /// <summary>
        ///  Holt alle Konto-Attribute. Exisitert zu einem Konto kein Konto-Attribut, dann wird 
        ///  das fehlende Konto-Attribut erstellt. 
        ///  Das Resultat ist nach Konto-Nr sortiert.
        ///  KbuKonto ist included.
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use.</param>
        /// <returns>All assigned <see cref="WshKategorie"/> entities</returns>
        public IList<WshKontoAttribut> GetAllWshKontoAttributeAddIfNotExist(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshKontoAttribut>(unitOfWork);
                    

            var returnValue = repository
                .Include(x => x.KbuKonto)
                .Where(x => x.KbuKonto.KbuKontoklasseCode == 3 || x.KbuKonto.KbuKontoklasseCode == 4)
                .OrderBy(x => x.KbuKonto.KontoNr)
                .ToList();

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            var repositoryKbuKonto = UnitOfWork.GetRepository<KbuKonto>(unitOfWork);
            var kbuKontoWithoutWshKontoAttribut = repositoryKbuKonto
                                                  .Where(konto => konto.WshKontoAttribut.Count == 0)
                                                  .Where(konto => konto.KbuKontoklasseCode == 3 || konto.KbuKontoklasseCode == 4);

            foreach (var kbuKonto in kbuKontoWithoutWshKontoAttribut)
            {
                WshKontoAttribut attribut;
                NewData(out attribut);
                attribut.KbuKontoID = kbuKonto.KbuKontoID;
                attribut.KbuKonto = kbuKonto;
                attribut.IstGrundbudgetAktiv = false;
                attribut.IstMonatsbudgetAktiv = false;
                attribut.IstLeistungWsh = false;
                attribut.IstLeistungWshStationaer = false;
                if (kbuKonto.Quoting == false)
                {
                    attribut.SysEditModeCode_BetrifftPerson = (int)LOVsGenerated.SysEditMode.Required;
                }
                attribut.MarkAsAdded();
                returnValue.Add(attribut);
            }
            //Nochmals nach Kontonummer sortieren.
            returnValue = returnValue.OrderBy(x => x.KbuKonto.KontoNr).ToList();
            return returnValue;
        }


        /// <summary>
        /// Holt alle Attribute eines KbuKontos.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="kbuKontoID"></param>
        /// <returns></returns>
        public WshKontoAttribut GetKontoAttributByKontoId(IUnitOfWork unitOfWork, int kbuKontoID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshKontoAttribut>(unitOfWork);

            var returnValue = repository
                              .Where(x => x.KbuKontoID == kbuKontoID)
                              .Include(x => x.KbuKonto)
                              .SingleOrDefault();

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();
            return returnValue;
        }

        #endregion

        #endregion
    }
}