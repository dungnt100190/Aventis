using System.Linq;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Fs;
using Kiss.Infrastructure;

namespace Kiss.DataAccess.Sys
{
    public class XOrgUnit_UserRepository : Repository<XOrgUnit_User>
    {
        public XOrgUnit_UserRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public XOrgUnit_User GetByUserAndOrgUnit(int userID, int orgUnitID)
        {
            return DbSet
                   .SingleOrDefault(ouu => ouu.UserID == userID 
                                        && ouu.OrgUnitID == orgUnitID);
                                        //&& ouu.OrgUnitMemberCode == 2); //2: Member
        }

        public int? GetMembershipOrgUnitIdOfUser(int userID)
        {
            var row = DbSet
                      .SingleOrDefault(ouu => ouu.UserID == userID 
                                           && ouu.OrgUnitMemberCode == 2); //2: Member

            return row == null ? (int?)null : row.OrgUnitID;
        }
    }
}
