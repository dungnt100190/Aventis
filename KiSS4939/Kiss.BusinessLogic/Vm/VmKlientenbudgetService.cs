using System;

using Kiss.DataAccess.Interfaces;
using Kiss.Infrastructure;

using IUnitOfWork = Kiss.DataAccess.Interfaces.IUnitOfWork;
using Kiss.DbContext;
using Kiss.DbContext.Enums.Vm;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Vm
{
    public class VmKlientenbudgetService : ServiceCRUD<VmKlientenbudget>
    {
        #region Constructors

        private VmKlientenbudgetService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Gibt alle <see cref="VmKlientenbudget"/>s einer FaLeistung zurück
        /// </summary>
        /// <param name="faLeistungId"></param>
        /// <returns></returns>
        public VmKlientenbudget[] GetByFaLeistungId(int faLeistungId)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.VmKlientenbudget.GetByFaLeistungId(faLeistungId);
            }
        }

        /// <summary>
        /// Erstellt ein Budget, wahlweise mit den Standard-Positionen
        /// </summary>
        /// <param name="createStandardPositionen"></param>
        /// <returns></returns>
        public VmKlientenbudget GetDefaultBudget(bool createStandardPositionen = true)
        {
            var newKlientenbudget = new VmKlientenbudget();
            newKlientenbudget.GueltigAb = DateTime.Now.FirstDayOfMonth();
            newKlientenbudget.VmKlientenbudgetStatus = VmKlientenbudgetStatus.InBearbeitung;
            newKlientenbudget.UserID = Container.Resolve<ISessionService>().AuthenticatedUser.UserID;

            if (createStandardPositionen)
            {
                using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
                {
                    foreach (var positionsart in unitOfWork.VmPositionsart.GetTemplatePositionsarten())
                    {
                        var position = new VmPosition
                                           {
                                               VmKlientenbudget = newKlientenbudget, //ToDo: nötig?
                                               Name = positionsart.Name,
                                               VmPositionsart = positionsart,
                                               VmPositionsartID = positionsart.VmPositionsartID, // ToDo: entfernen, wenn Poco das beherrscht (ID aufgrund navigation property setzen)
                                               SortKey = positionsart.SortKey
                                           };
                        newKlientenbudget.VmPosition.Add(position);
                    }
                }
            }
            return newKlientenbudget;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Implements a cascaded delete with VmPosition
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="entityToRemove"></param>
        /// <returns></returns>
        protected override IServiceResult RemoveEntity(IUnitOfWork unitOfWork, VmKlientenbudget entityToRemove)
        {
            var kissUnitOfWork = unitOfWork as IKissUnitOfWork;
            if (kissUnitOfWork != null)
            {
                // remove depending VmPositions
                kissUnitOfWork.VmPosition.RemoveAllPositionsOfBudget(entityToRemove.VmKlientenbudgetID);
            }
            return base.RemoveEntity(unitOfWork, entityToRemove);
        }

        #endregion

        #endregion
    }
}