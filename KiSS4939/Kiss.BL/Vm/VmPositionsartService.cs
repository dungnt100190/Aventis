using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Model;
using Kiss.Model.DTO.Vm;

namespace Kiss.BL.Vm
{
    /// <summary>
    /// Service to manage a TEntity.
    /// </summary>
    public class VmPositionsartService : ServiceCRUDBase<VmPositionsart>
    {
        #region Constructors

        private VmPositionsartService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public override VmPositionsart GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var rep = UnitOfWork.GetRepository<VmPositionsart>(unitOfWork);

            var result = rep.SingleOrDefault(x => x.VmPositionsartID == id);

            if (result != null)
            {
                result.StartTracking();
            }

            return result;
        }

        /// <summary>
        /// Holt alle Positionsarten einer Kategorie.
        /// </summary>
        /// <param name="unitOfWork">Die <see cref="IUnitOfWork"/></param>
        /// <param name="kategorie">Die gewählte Kategorie</param>
        /// <returns>Liste von Positionsarten aufsteigend sortiert nach Name</returns>
        public IList<VmPositionsart> GetPositionsartenOfCatogeroy(IUnitOfWork unitOfWork, LOVsGenerated.VmKategorie kategorie)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var rep = UnitOfWork.GetRepository<VmPositionsart>(unitOfWork);
            var result = rep
                .Where(x => x.VmKategorieCode == (int)kategorie)
                .OrderBy(x => x.SortKey)
                .ThenBy(x => x.Name);
            return result.ToList();
        }

        /// <summary>
        /// Holt alle Positionsarten einer Kategorie die im Budget hinzugefügt werden können.
        /// Standardposition können nur ein Mal im Budget vorhanden sein.
        /// </summary>
        /// <param name="unitOfWork">Die <see cref="IUnitOfWork"/></param>
        /// <param name="kategorie">Die gewählte Kategorie</param>
        /// <param name="positionen">Positionen dieser Kategorie die bereits im Budget sind</param>
        /// <returns>Liste von Positionsarten aufsteigend sortiert nach Name</returns>
        public IList<VmPositionsart> GetPositionsartenOfCatogeroyToInsert(IUnitOfWork unitOfWork, LOVsGenerated.VmKategorie kategorie, List<VmPositionDTO> positionen)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var rep = UnitOfWork.GetRepository<VmPositionsart>(unitOfWork);

            var importiertePositionsarten = positionen
                .Where(x => x.VmPosition.VmPositionsart.IstTemplate)
                .Select(x => x.VmPosition.VmPositionsart.VmPositionsartID);

            var result = rep
                .Where(x => x.VmKategorieCode == (int)kategorie)
                .Where(x => !importiertePositionsarten.Contains(x.VmPositionsartID))
                .OrderBy(x => x.SortKey)
                .ThenBy(x => x.Name);

            return result.ToList();
        }

        /// <summary>
        /// Holt alle Standard-Positionsarten
        /// </summary>
        /// <param name="unitOfWork">Die <see cref="IUnitOfWork"/></param>
        /// <returns>Liste von Positionsarten</returns>
        public IList<VmPositionsart> GetTemplatePositionsarten(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var rep = UnitOfWork.GetRepository<VmPositionsart>(unitOfWork);
            return rep.Where(x => x.IstTemplate).ToList();
        }

        public override KissServiceResult ValidateInMemory(VmPositionsart dataToValidate)
        {
            return base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #endregion
    }
}