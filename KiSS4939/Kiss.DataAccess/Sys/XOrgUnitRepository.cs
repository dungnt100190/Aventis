using System.Collections.Generic;
using System.Data;
using System.Linq;
using Kiss.DbContext;
using Kiss.Infrastructure.Constant;

namespace Kiss.DataAccess.Sys
{
    public class XOrgUnitRepository : Repository<XOrgUnit>
    {
        public XOrgUnitRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public override EntityState InsertOrUpdateEntity(XOrgUnit entity)
        {
            var state = base.InsertOrUpdateEntity(entity);
            if (state == EntityState.Added && !entity.ParentPosition.HasValue)
            {
                // no parent position defined -> add to the end
                entity.ParentPosition = (DbSet
                                         .Where(org => org.ParentID == entity.ParentID || !org.ParentID.HasValue && !entity.ParentID.HasValue)
                                         .Max(org => org.ParentPosition) ?? 0) + 1;
            }
            return state;
        }

        public XOrgUnit GetOrgUnitOfUser(int userId)
        {
            return DbSet.SingleOrDefault(ogu => ogu.XOrgUnit_User.Any(ouu => ouu.UserID == userId && 
                                                                             ouu.OrgUnitMemberCode == (int)LOVsGenerated.OrgUnitMember.Mitglied)); //ToDo: enum
        }


        /// <summary>
        /// Gets a list containing all OrgUnit entries the specified user is a child of.
        /// The first item is the OrgUnit of the user, the second item the parent of the first OrgUnit, etc.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public XOrgUnit GetHierarchyTreeOfUser(int userId)
        {
            var orgUnitUser = GetOrgUnitOfUser(userId);
            if (orgUnitUser == null)
            {
                return null;
            }
            var currentOrgUnit = orgUnitUser;

            while (currentOrgUnit != null && currentOrgUnit.ParentID.HasValue)
            {
                currentOrgUnit.XOrgUnit_Parent = DbSet.Single(org => org.OrgUnitID == currentOrgUnit.ParentID.Value);
                currentOrgUnit = currentOrgUnit.XOrgUnit_Parent;
            }

            return currentOrgUnit;
        }

        /// <summary>
        /// Gets a list containing all OrgUnit entries the specified user is a child of.
        /// The first item is the OrgUnit of the user, the second item the parent of the first OrgUnit, etc.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<XOrgUnit> GetHierarchyListOfUser(int userId)
        {
            var orgUnitUser = GetOrgUnitOfUser(userId);
            if (orgUnitUser == null)
            {
                return null;
            }
            var orgUnitList = new List<XOrgUnit> { orgUnitUser };
            var currentOrgUnit = orgUnitUser;

            while (currentOrgUnit != null && currentOrgUnit.ParentID.HasValue)
            {
                currentOrgUnit = DbSet.Single(org => org.OrgUnitID == currentOrgUnit.ParentID.Value);
                orgUnitList.Add(currentOrgUnit);
            }

            return orgUnitList;
        }
    }
}
