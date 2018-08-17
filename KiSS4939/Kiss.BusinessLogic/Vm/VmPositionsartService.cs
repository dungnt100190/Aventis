using System.Collections.Generic;
using System.Linq;
using Kiss.DataAccess;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.DbContext.Enums.Vm;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Vm
{
    /// <summary>
    /// Service to manage a TEntity.
    /// </summary>
    public class VmPositionsartService : ServiceCRUD<VmPositionsart>
    {
        #region Constructors

        private VmPositionsartService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods
        
        /// <summary>
        /// Holt alle Positionsarten einer Kategorie die im Budget hinzugefügt werden können.
        /// Standardposition können nur ein Mal im Budget vorhanden sein.
        /// </summary>
        /// <param name="kategorie">Die gewählte Kategorie</param>
        /// <param name="importiertePositionsartIDs">PositionsartIDs der bestehenden Positionen dieser Kategorie, die bereits im Budget sind</param>
        /// <returns>Liste von Positionsarten aufsteigend sortiert nach Name</returns>
        public IList<VmPositionsart> GetPositionsartenOfCategoryToInsert(VmKategorie kategorie, IEnumerable<int> importiertePositionsartIDs)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.VmPositionsart
                                 .GetPositionsartenOfCategory(kategorie)
                                 .Where(x => !importiertePositionsartIDs.Contains(x.VmPositionsartID))
                                 .ToList();
            }
        }

        #endregion

        #endregion
    }
}