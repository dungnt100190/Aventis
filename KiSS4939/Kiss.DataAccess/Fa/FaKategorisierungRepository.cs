using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Kiss.DataAccess.Validation;
using Kiss.DbContext;

namespace Kiss.DataAccess.Fa
{
    public class FaKategorisierungRepository : Repository<FaKategorisierung>
    {
        public FaKategorisierungRepository(IDbContext dbContext)
            : base(dbContext)
        {
            RegisterValidator(new FaKategorisierungValidator());
        }


        public IEnumerable<FaKategorisierung> GetByBaPersonId(int baPersonId)
        {
            return DbSet
                   .Where(kat => kat.BaPersonID == baPersonId)
                   .Include(kat => kat.XUser)
                   //.Include(kat => kat.XUser.XOrgUnit_User.Where(ouu => ouu.OrgUnitMemberCode == 2).Select(ouu => ouu.XOrgUnit))
                   .OrderByDescending(kat => kat.Datum);
        }

        public override EntityState InsertOrUpdateEntity(FaKategorisierung entity)
        {
            var state = base.InsertOrUpdateEntity(entity);

            if (state == EntityState.Added)
            {
                var entityOhneAbschluss = DbSet.FirstOrDefault(kat => kat.BaPersonID == entity.BaPersonID &&
                                                                      !kat.Abschlussdatum.HasValue);

                if (entityOhneAbschluss != null && entityOhneAbschluss.Datum < entity.Datum)
                {
                    entityOhneAbschluss.Abschlussdatum = entity.Datum.AddDays(-1);
                    base.InsertOrUpdateEntity(entity);
                }
            }
            return state;
        }
    }
}
