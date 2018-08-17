using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Kiss.DataAccess.Vm.Validation;
using Kiss.DbContext;

namespace Kiss.DataAccess.Vm
{
    public class VmPositionRepository : Repository<VmPosition>
    {
        /// <summary>
        /// Only for testing purpose
        /// </summary>
        public VmPositionRepository()
        {
        }


        public VmPositionRepository(IDbContext context)
            : base(context)
        {
            RegisterValidator(new VmPositionValidator());
        }

        public virtual VmPosition[] GetByVmKlientenbudgetId(int vmKlientenbudgetId)
        {
            return DbSet
                   .Include(vpo => vpo.VmPositionsart)
                   .Where(vpo => vpo.VmKlientenbudgetID == vmKlientenbudgetId)
                   .OrderBy(vpo => vpo.SortKey)
                   .ThenBy(vpo => vpo.VmPositionsart.SortKey)
                   .ToArray();
        }

        public void RemoveAllPositionsOfBudget(int vmKlientenbudgetId)
        {
            var positionen = GetByVmKlientenbudgetId(vmKlientenbudgetId);

            foreach (var position in positionen)
            {
                Remove(position);
            }
        }

        public int? GetLeistungPerson(int vmPositionID)
        {
            var position = DbSet.FirstOrDefault(pos => pos.VmPositionID == vmPositionID);
            if (position == null)
            {
                return null;
            }
            return position.VmKlientenbudget.FaLeistung.BaPersonID;
        }
    }
}
