using System.Collections.Generic;
using System.Linq;

using Kiss.BL.KissSystem;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Fa
{
    /// <summary>
    /// Service to manage a FaKategorisierungEksProdukt.
    /// </summary>
    public class FaKategorisierungEksProduktService : ServiceCRUDBase<FaKategorisierungEksProdukt>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly XOrgUnitService _xOrgUnitService;

        #endregion

        #endregion

        #region Constructors

        private FaKategorisierungEksProduktService()
        {
            _xOrgUnitService = Container.Resolve<XOrgUnitService>();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override FaKategorisierungEksProdukt GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repo = UnitOfWork.GetRepository<FaKategorisierungEksProdukt>(unitOfWork);

            var returnValue = repo.SingleOrDefault(x => x.FaKategorisierungEksProduktID == id);

            if (returnValue == null)
            {
                throw new EntityNotFoundException("No entity of 'FaKategorisierungEksProdukt' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        public List<FaKategorisierungEksProdukt> GetDataForCurrentUser(IUnitOfWork unitOfWork, bool includeNullValue)
        {
            var sessionService = Container.Resolve<ISessionService>();
            var userId = sessionService.AuthenticatedUser.UserID;

            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repoProdukt = UnitOfWork.GetRepository<FaKategorisierungEksProdukt>(unitOfWork);
            var repoOrgUnit = UnitOfWork.GetRepository<XOrgUnit>(unitOfWork);
            var repoOrgUnitUser = UnitOfWork.GetRepository<XOrgUnit_User>(unitOfWork);

            var orgUnit = (from org in repoOrgUnit
                           join ouu in repoOrgUnitUser on org.OrgUnitID equals ouu.OrgUnitID
                           where ouu.OrgUnitMemberCode == (int)LOVsGenerated.OrgUnitMember.Mitglied &&
                                 ouu.UserID == userId
                           select org).SingleOrDefault();

            if (orgUnit == null)
            {
                return new List<FaKategorisierungEksProdukt>();
            }

            var orgHierarchy = _xOrgUnitService.GetHierarchyOfUser(unitOfWork, userId, LOVsGenerated.OrgUnitMember.Mitglied);

            var result = (from org in orgHierarchy
                          join eksProdukt in repoProdukt on org.OrgUnitID equals eksProdukt.OrgUnitID
                          select eksProdukt).ToList();

            if (includeNullValue)
            {
                result.Insert(0, new FaKategorisierungEksProdukt
                {
                    FaKategorisierungEksProduktID = -1,
                    Text = string.Empty,
                    ShortText = string.Empty
                });
            }

            return new List<FaKategorisierungEksProdukt>(result);
        }

        #endregion

        #endregion
    }
}