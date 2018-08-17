using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;

using Kiss.DataAccess.Vm.Validation;
using Kiss.DbContext;
using Kiss.DbContext.Enums.Vm;

namespace Kiss.DataAccess.Vm
{
    public class VmKlientenbudgetRepository : Repository<VmKlientenbudget>
    {
        /// <summary>
        /// Only for testing purpose
        /// </summary>
        public VmKlientenbudgetRepository()
        {
        }


        public VmKlientenbudgetRepository(IDbContext context)
            : base(context)
        {
            RegisterValidator(new VmKlientenbudgetValidator());
        }

        private void ArchiveOldBudget(int faLeistungID)
        {
            var oldBudget = GetByFaLeistungIdQueryable(faLeistungID)
                            .SingleOrDefault(b => b.VmKlientenbudgetStatusCode == (int)VmKlientenbudgetStatus.InOrdnung);

            if (oldBudget == null)
            {
                return;
            }

            // Budget archivieren
            oldBudget.VmKlientenbudgetStatus = VmKlientenbudgetStatus.Archiviert;
            InsertOrUpdateEntity(oldBudget); // ToDo: nötig? entity ist bereits im context
        }

        public override EntityState InsertOrUpdateEntity(VmKlientenbudget entity)
        {
            AddNewDependendEntities(entity.VmPosition);
            var state = base.InsertOrUpdateEntity(entity);
            if (state == EntityState.Added)
            {
                ArchiveOldBudget(entity.FaLeistungID);
            }
            return state;
        }

        public override VmKlientenbudget Remove(VmKlientenbudget entityToRemove)
        {
            // TODO Spezialrecht?
            if (entityToRemove.VmKlientenbudgetStatus != VmKlientenbudgetStatus.InBearbeitung)
            {
                throw new ValidationException("Nur Budgets mit dem Status 'In Bearbeitung' können gelöscht werden.");
            }

            //// remove depending VmPositions
            //// ToDo: löscht das auch VmPositionen, die nur auf DB sind (nicht im context)?
            //if (entityToRemove.VmPosition.Any())
            //{
            //    foreach (var vmPosition in entityToRemove.VmPosition.ToList())
            //    {
            //        var position = vmPosition;
            //        DbContext.Set<VmPosition>(). Remove(position);
            //    }
            //}
            //result += positionService.DeleteByVmKlientenbudgetId(unitOfWork, dataToDelete.VmKlientenbudgetID);

            base.Remove(entityToRemove);
            return entityToRemove;
        }

        public int GetAnzahlBudgetsMitStatus(int faLeistungId, VmKlientenbudgetStatus status)
        {
            return GetByFaLeistungIdQueryable(faLeistungId)
                   .Count(x => x.VmKlientenbudgetStatusCode == (int)status);
        }

        public VmKlientenbudget[] GetByFaLeistungId(int faLeistungId)
        {
            return GetByFaLeistungIdQueryable(faLeistungId)
                   .OrderBy(x => x.Created)
                   .ThenBy(x => x.GueltigAb)
                   .ToArray();
        }

        public bool IsAnyBudgetInState(int faLeistungId, VmKlientenbudgetStatus status)
        {
            return GetByFaLeistungIdQueryable(faLeistungId)
                   .Any(bud => bud.VmKlientenbudgetStatusCode == (int)status);
        }

        private IQueryable<VmKlientenbudget> GetByFaLeistungIdQueryable(int faLeistungId)
        {
            return DbSet
                   .Include(x => x.XUser)
                   .Where(x => x.FaLeistungID == faLeistungId);
        }
    }
}
