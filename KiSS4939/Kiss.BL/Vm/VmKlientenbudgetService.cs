using System;
using System.Collections.Generic;
using System.Linq;
using Kiss.BL.Vm.Validation;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Vm
{
    /// <summary>
    /// Service to manage a TEntity.
    /// </summary>
    [UsableBy(
        typeof(VmKlientenbudgetDTOService),
        ClassNames = new[]
        {
            "Kiss.BL.Test.Vm.VmKlientenbudgetServiceTest"
        })]
    internal class VmKlientenbudgetService : ServiceCRUDBase<VmKlientenbudget>
    {
        #region Constructors

        private VmKlientenbudgetService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public KissServiceResult BudgetArchivieren(IUnitOfWork unitOfWork, int faLeistungID, VmKlientenbudget selectedBudget, List<VmKlientenbudget> budgets)
        {
            VmKlientenbudget budget;

            if (budgets != null)
            {
                budget = budgets.SingleOrDefault(
                    b =>
                    b.VmKlientenbudgetStatusEnum == LOVsGenerated.VmKlientenbudgetStatus.InOrdnung &&
                    b.VmKlientenbudgetID != selectedBudget.VmKlientenbudgetID);
            }
            else
            {
                budget = GetByFaLeistungIdQueryable(unitOfWork, faLeistungID)
                    .SingleOrDefault(
                        b =>
                        b.VmKlientenbudgetStatusCode == (int)LOVsGenerated.VmKlientenbudgetStatus.InOrdnung &&
                        b.VmKlientenbudgetID != selectedBudget.VmKlientenbudgetID);
                budget.StartTracking();
            }

            if (budget == null)
            {
                return KissServiceResult.Ok();
            }

            // Budget archivieren
            budget.VmKlientenbudgetStatusCode = (int)LOVsGenerated.VmKlientenbudgetStatus.Archiviert;
            var result = SaveData(unitOfWork, budget);
            return result;
        }

        public override KissServiceResult DeleteData(IUnitOfWork unitOfWork, VmKlientenbudget dataToDelete, bool saveChanges = true)
        {
            var result = KissServiceResult.Ok();
            var positionService = Container.Resolve<VmPositionService>();
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            // TODO Spezialrecht?
            if (dataToDelete.VmKlientenbudgetStatusEnum != LOVsGenerated.VmKlientenbudgetStatus.InBearbeitung)
            {
                return new KissServiceResult(
                    ServiceResultType.Error,
                    "Nur Budgets mit dem Status 'In Bearbeitung' können gelöscht werden.");
            }

            if (dataToDelete.VmPosition.Any())
            {
                foreach (var vmPosition in dataToDelete.VmPosition.ToList())
                {
                    var position = vmPosition;
                    result += positionService.DeleteData(unitOfWork, position, false);
                }

                unitOfWork.SaveChanges();
            }

            result += positionService.DeleteByVmKlientenbudgetId(unitOfWork, dataToDelete.VmKlientenbudgetID);

            unitOfWork = UnitOfWork.GetNew;
            var budget = GetById(unitOfWork, dataToDelete.VmKlientenbudgetID);
            result += base.DeleteData(unitOfWork, budget, saveChanges);

            if (result.IsOk)
            {
                dataToDelete.MarkAsUnchanged();
            }

            return result;
        }

        public int GetAnzahlBudgetsMitStatus(IUnitOfWork unitOfWork, int faLeistungId, LOVsGenerated.VmKlientenbudgetStatus status)
        {
            return GetByFaLeistungIdQueryable(unitOfWork, faLeistungId)
                .Count(x => x.VmKlientenbudgetStatusCode == (int)status);
        }

        public List<VmKlientenbudget> GetByFaLeistungId(IUnitOfWork unitOfWork, int faLeistungId)
        {
            var budgets = GetByFaLeistungIdQueryable(unitOfWork, faLeistungId)
                .OrderBy(x => x.Created)
                .ThenBy(x => x.GueltigAb)
                .ToList();

            foreach (var vmKlientenbudget in budgets)
            {
                vmKlientenbudget.StartTracking();
            }

            return budgets;
        }

        public override VmKlientenbudget GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var repoVmKlientenbudget = UnitOfWork.GetRepository<VmKlientenbudget>(unitOfWork);

            var result = repoVmKlientenbudget.SingleOrDefault(x => x.VmKlientenbudgetID == id);

            if (result != null)
            {
                result.StartTracking();
            }

            return result;
        }

        public override KissServiceResult NewData(out VmKlientenbudget newData)
        {
            return NewData(out newData, true);
        }

        public KissServiceResult NewData(out VmKlientenbudget newData, bool createStandardPositionen)
        {
            var result = base.NewData(out newData);

            if (!result)
            {
                return result;
            }

            var now = DateTime.Now;
            newData.GueltigAb = new DateTime(now.Year, now.Month, 1);
            newData.VmKlientenbudgetStatusCode = (int)LOVsGenerated.VmKlientenbudgetStatus.InBearbeitung;

            if (createStandardPositionen)
            {
                // Standard Positionen erstellen
                var positionsartService = Container.Resolve<VmPositionsartService>();
                var positionService = Container.Resolve<VmPositionService>();
                var templatePositionen = positionsartService.GetTemplatePositionsarten(null);

                foreach (var positionsart in templatePositionen)
                {
                    VmPosition position;
                    positionService.NewData(out position);
                    position.VmKlientenbudget = newData;
                    position.Name = positionsart.Name;
                    position.VmPositionsart = positionsart;
                    position.SortKey = positionsart.SortKey;
                }
            }

            return KissServiceResult.Ok();
        }

        public override KissServiceResult ValidateInMemory(VmKlientenbudget dataToValidate)
        {
            var serviceResult = VmKlientenbudgetValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #region Private Methods

        private IQueryable<VmKlientenbudget> GetByFaLeistungIdQueryable(IUnitOfWork unitOfWork, int faLeistungId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var repoVmKlientenbudget = UnitOfWork.GetRepository<VmKlientenbudget>(unitOfWork);

            var result = repoVmKlientenbudget
                .Include(x => x.XUser)
                .Where(x => x.FaLeistungID == faLeistungId);

            return result;
        }

        #endregion

        #endregion
    }
}