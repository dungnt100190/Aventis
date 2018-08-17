using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BL.KissSystem;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class XUserHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<XUser> _list = new List<XUser>();
        private readonly XOrgUnitHelper _orgUnitHelper = new XOrgUnitHelper();
        private readonly List<XOrgUnit_User> _orgUnitUsers = new List<XOrgUnit_User>();

        #endregion

        #region Private Fields

        private XUser _user;
        private bool _userCreated;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public IList<XUser> CreateList(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repositoryUser = UnitOfWork.GetRepository<XUser>(unitOfWork);
            var repositoryOrgUnitUser = UnitOfWork.GetRepository<XOrgUnit_User>(unitOfWork);
            SystemService.NewHistoryVersion(unitOfWork);
            var orgUnit = _orgUnitHelper.Create(unitOfWork);

            var kisfmu = repositoryUser.FirstOrDefault(x => x.LogonName == "kisfmu") ??
                         new XUser
                         {
                             FirstName = "Fritz",
                             LastName = "Müller",
                             LogonName = "kisfmu",
                             Created = DateTime.Now,
                             Creator = CREATOR,
                             Modified = DateTime.Now,
                             Modifier = CREATOR
                         };
            _list.Add(kisfmu);

            var kisfme = repositoryUser.FirstOrDefault(x => x.LogonName == "kisfme") ??
                new XUser
                {
                    FirstName = "Franz",
                    LastName = "Meier",
                    LogonName = "kisfme",
                    Created = DateTime.Now,
                    Creator = CREATOR,
                    Modified = DateTime.Now,
                    Modifier = CREATOR
                };
            _list.Add(kisfme);

            var kispja = repositoryUser.FirstOrDefault(x => x.LogonName == "kispja") ??
                new XUser
                {
                    FirstName = "Peter",
                    LastName = "Jackson",
                    LogonName = "kispja",
                    Created = DateTime.Now,
                    Creator = CREATOR,
                    Modified = DateTime.Now,
                    Modifier = CREATOR
                };
            _list.Add(kispja);

            _list.ForEach(repositoryUser.ApplyChanges);
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());

            foreach (var user in _list)
            {
                var membership = repositoryOrgUnitUser.FirstOrDefault(x => x.UserID == user.UserID && x.OrgUnitID == orgUnit.OrgUnitID) ??
                    new XOrgUnit_User
                                     {
                                         OrgUnitMemberCode = 2, //Member
                                         XUser = user,
                                         UserID = user.UserID,
                                         XOrgUnit = orgUnit,
                                         OrgUnitID = orgUnit.OrgUnitID
                                     };

                _orgUnitUsers.Add(membership);

                user.XOrgUnit_User.Add(membership);
                repositoryOrgUnitUser.ApplyChanges(membership);
            }

            unitOfWork.SaveChanges();
            _orgUnitUsers.ForEach(x => x.AcceptChanges());

            return _list;
        }

        public XUser CreateNew(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repoUser = UnitOfWork.GetRepository<XUser>(unitOfWork);

            var user = new XUser
            {
                LogonName = Guid.NewGuid().ToString(),
                FirstName = "Unit",
                LastName = "Test",
                Creator = "UnitTest",
                Created = DateTime.Now,
                Modifier = "UnitTest",
                Modified = DateTime.Now
            };

            repoUser.ApplyChanges(user);
            unitOfWork.SaveChanges();
            user.AcceptChanges();

            _list.Add(user);

            return user;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            SystemService.NewHistoryVersion(unitOfWork);
            _list.ForEach(x => DeleteUser(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());

            if (_userCreated)
            {
                DeleteUser(unitOfWork, _user);
            }
            _orgUnitHelper.Delete(unitOfWork);
        }

        public XUser GetOrCreate(IUnitOfWork unitOfWork)
        {
            var sessionService = Container.Resolve<ISessionService>();
            string logonName = "LogonName";
            if (sessionService.AuthenticatedUser != null)
            {
                logonName = sessionService.AuthenticatedUser.LogonName;
            }

            var userService = Container.Resolve<XUserService>();
            _user = userService.GetUser(unitOfWork, logonName);

            if (_user == null)
            {
                _userCreated = true;
                var repositoryUser = UnitOfWork.GetRepository<XUser>(unitOfWork);
                if (TestUtils.IsDbTest(unitOfWork))
                {
                    SystemService.NewHistoryVersion(unitOfWork);
                }
                _user = new XUser
                {
                    LogonName = logonName,
                    LastName = "Unit",
                    FirstName = "First Unit",
                    Creator = CREATOR,
                    Created = DateTime.Now,
                    Modifier = CREATOR,
                    Modified = DateTime.Now,
                };
                repositoryUser.ApplyChanges(_user);
                unitOfWork.SaveChanges();
                _user.AcceptChanges();
            }

            return _user;
        }

        #endregion

        #region Private Methods

        private void DeleteUser(IUnitOfWork unitOfWork, XUser user)
        {
            var repoUnitUser = UnitOfWork.GetRepository<XOrgUnit_User>(unitOfWork);
            var unitUsers = repoUnitUser.Where(x => x.UserID == user.UserID);

            foreach (var orgUnitUser in unitUsers)
            {
                orgUnitUser.MarkAsDeleted();
                repoUnitUser.ApplyChanges(orgUnitUser);
            }

            var repository = UnitOfWork.GetRepository<XUser>(unitOfWork);
            var entity = (from x in repository
                          where x.UserID == user.UserID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        #endregion

        #endregion
    }
}