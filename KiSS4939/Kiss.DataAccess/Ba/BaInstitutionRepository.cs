using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Kiss.DataAccess.Validation;
using Kiss.DbContext;
using Kiss.DbContext.Constant;
using Kiss.DbContext.Enums.Ba;

namespace Kiss.DataAccess.Ba
{
    public class BaInstitutionRepository : Repository<BaInstitution>
    {
        #region Constructors

        public BaInstitutionRepository(IDbContext dbContext)
            : base(dbContext)
        {
            RegisterValidator(new ValidatorBase<BaInstitution>());
        }

        #endregion

        #region Methods

        #region Public Methods

        public List<BaInstitution> FindInstitutionsByNames(string lastName, string firstName, string firstOrLastname, bool firstAndLast, BaInstitutionsart? baInstitutionsart)
        {
            int? institutionsart = baInstitutionsart.HasValue ? (int?)baInstitutionsart.Value : null;

            return DbSet.Where(ins => (firstAndLast || ins.Vorname.StartsWith(firstOrLastname)
                                            || ins.Name.StartsWith(firstOrLastname)
                                            || firstOrLastname == Constant.ASTERISK))
                        .Where(ins => (!firstAndLast || (ins.Vorname.StartsWith(firstName) && ins.Name.StartsWith(lastName))))
                        .Where(ins => !institutionsart.HasValue || ins.BaInstitutionArtCode == institutionsart.Value)
                        .OrderBy(x => x.Name)
                        .ThenBy(x => x.Vorname)
                        .ToList();
        }

        public BaInstitution[] GetAffectedInstitutions(int baPersonId)
        {
            return DbSet
                .Where(ins => ins.BaPerson_BaInstitution.Any(bpi => bpi.BaPersonID == baPersonId))
                .ToArray();
        }

        #endregion

        #endregion
    }
}