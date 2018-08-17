using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;

using Kiss.DataAccess.Validation;
using Kiss.DbContext;
using Kiss.DbContext.Constant;

namespace Kiss.DataAccess
{
    public class BaPersonRepository : Repository<BaPerson>
    {
        public BaPersonRepository(IDbContext dbContext)
            : base(dbContext)
        {
            RegisterValidator(new BaPersonValidator());
        }

        public BaPersonRepository()
        {
        }

        public virtual bool Exists(int baPersonId)
        {
            return DbSet.Any(prs => prs.BaPersonID == baPersonId);
        }

        public List<BaPerson> FindPersonByNames(string lastName, string firstName, string firstOrLastname, bool firstAndLast, bool nurFalltraeger, int? modulId)
        {
            modulId = modulId ?? 2;

            return DbSet.Where(per => (firstAndLast || per.Vorname.ToUpper().StartsWith(firstOrLastname)
                                            || per.Name.ToUpper().StartsWith(firstOrLastname)
                                            || firstOrLastname == Constant.ASTERISK))
                        .Where(usr => (!firstAndLast || (usr.Vorname.ToUpper().StartsWith(firstName) && usr.Name.ToUpper().StartsWith(lastName))))
                        .Where(usr => !nurFalltraeger || usr.FaLeistung.Any(lei => lei.ModulID == modulId.Value))
                        .OrderBy(x => x.Name)
                        .ThenBy(x => x.Vorname)
                        .ToList();
        }

        public BaPerson[] GetAffectedPersons(int baPersonId, bool mitFalltraeger = true)
        {
            return DbSet
                   .Where(per => per.BaPerson_Relation1.Any(pre => pre.BaPersonID_2 == baPersonId) ||
                                 per.BaPerson_Relation2.Any(pre => pre.BaPersonID_1 == baPersonId) ||
                                 (mitFalltraeger && per.BaPersonID == baPersonId))
                   .OrderBy(per => per.BaPersonID)
                   .ToArray();
        }

        public BaPerson GetByEinwohnerregisterId(string pid)
        {
            return DbSet.FirstOrDefault(x => SqlFunctions.Replicate("0", 10 - x.EinwohnerregisterID.Length) + x.EinwohnerregisterID == pid);
        }
    }
}