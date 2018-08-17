using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.KissSystem
{
    /// <summary>
    /// Service to manage a XOrgUnit.
    /// </summary>
    public class XOrgUnitService : ServiceCRUDBase<XOrgUnit>
    {
        #region Constructors

        private XOrgUnitService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public override XOrgUnit GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repo = UnitOfWork.GetRepository<XOrgUnit>(unitOfWork);

            var result = repo.SingleOrDefault(x => x.OrgUnitID == id);

            if (result == null)
            {
                throw new EntityNotFoundException("No entity of 'XOrgUnit' found with id: " + id);
            }

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return result;
        }

        /// <summary>
        /// Gets a list containing all OrgUnit entries the specified user is a child of.
        /// The first item is the OrgUnit of the user, the second item the parent of the first OrgUnit, etc.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="userId"></param>
        /// <param name="memberCode"></param>
        /// <returns></returns>
        public List<XOrgUnit> GetHierarchyOfUser(IUnitOfWork unitOfWork, int userId, LOVsGenerated.OrgUnitMember memberCode)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repoXOrgUnit = UnitOfWork.GetRepository<XOrgUnit>(unitOfWork);
            var repoXOrgUnitUser = UnitOfWork.GetRepository<XOrgUnit_User>(unitOfWork);

            var orgUnitUser = (from ouu in repoXOrgUnitUser
                               where ouu.UserID == userId && ouu.OrgUnitMemberCode == (int)memberCode
                               select ouu).SingleOrDefault();

            var result = new List<XOrgUnit>();

            if (orgUnitUser == null)
            {
                return result;
            }

            XOrgUnit orgUnit;
            int? id = orgUnitUser.OrgUnitID;

            do
            {
                orgUnit = repoXOrgUnit.FirstOrDefault(e => e.OrgUnitID == id);

                if (orgUnit != null)
                {
                    result.Add(orgUnit);
                }
            }
            while (orgUnit != null && (id = orgUnit.ParentID) != null);

            return result;
        }

        public XOrgUnit GetOrgUnitOfUser(IUnitOfWork unitOfWork, int userId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repoXOrgUnit = UnitOfWork.GetRepository<XOrgUnit>(unitOfWork);
            var repoXOrgUnitUser = UnitOfWork.GetRepository<XOrgUnit_User>(unitOfWork);

            var result = (from org in repoXOrgUnit
                          join ouu in repoXOrgUnitUser on org.OrgUnitID equals ouu.OrgUnitID
                          where ouu.UserID == userId && ouu.OrgUnitMemberCode == (int)LOVsGenerated.OrgUnitMember.Mitglied
                          select org).SingleOrDefault();

            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return result;
        }

        #endregion

        #endregion
    }
}