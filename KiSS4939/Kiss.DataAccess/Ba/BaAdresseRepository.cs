using System.Collections.Generic;
using System.Linq;

using Kiss.DbContext;

namespace Kiss.DataAccess.Ba
{
    public class BaAdresseRepository : Repository<BaAdresse>
    {
        public BaAdresseRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public BaAdresse GetByBaInstitutionId(int baInstitutionId)
        {
            return DbSet.SingleOrDefault(adr => adr.BaInstitutionID == baInstitutionId);
        }

        public BaAdresse GetByBaPersonId(int baPersonId)
        {
            return DbSet.SingleOrDefault(adr => adr.BaPersonID == baPersonId);
        }

        public List<BaAdresse> GetByListOfBaInstitutionIds(List<int?> listOfBaInstitutionId)
        {
            return DbSet.Where(x => x.BaInstitutionID != null && listOfBaInstitutionId.Contains(x.BaInstitutionID.Value)).ToList();
        }

        public List<BaAdresse> GetByListOfBaPersonIds(List<int?> listOfBapersonId)
        {
            return DbSet.Where(x => x.BaPersonID != null && listOfBapersonId.Contains(x.BaPersonID.Value)).ToList();
        }

        public List<BaAdresse> GetByBaPersonId(int baPersonId, bool nurEinwohnerregister = false)
        {
            return DbSet
                .Where(adr => adr.BaPersonID == baPersonId)
                .WhereIf(nurEinwohnerregister, adr => adr.AusEinwohnerregister)
                .ToList();
        }

        public BaAdresse GetByUserId(int userId)
        {
            return DbSet.SingleOrDefault(adr => adr.UserID == userId);
        }
    }
}