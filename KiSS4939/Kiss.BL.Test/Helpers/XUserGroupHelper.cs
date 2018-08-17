using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class XUserGroupHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<XUserGroup> _list = new List<XUserGroup>();
        private readonly XUserHelper _userHeler = new XUserHelper();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public XUserGroup Create(IUnitOfWork unitOfWork)
        {
            IList<XUser> users = _userHeler.CreateList(unitOfWork);

            XUserGroup userGroup = new XUserGroup
            {
                UserGroupName = "UnitTestGroup",
                Created = DateTime.Now,
                Creator = CREATOR,
                Modified = DateTime.Now,
                Modifier = CREATOR,
            };

            var repository = UnitOfWork.GetRepository<XUserGroup>(unitOfWork);
            repository.ApplyChanges(userGroup);
            unitOfWork.SaveChanges();

            //Verbindungen erstellen
            var repositoryUserUserGroup = UnitOfWork.GetRepository<XUser_UserGroup>(unitOfWork);
            foreach (XUser user in users)
            {
                XUser_UserGroup userUserGroup = new XUser_UserGroup
                {
                    UserID = user.UserID,
                    XUser = user,
                    XUserGroup = userGroup,
                    UserGroupID = userGroup.UserGroupID,
                };
                repositoryUserUserGroup.ApplyChanges(userUserGroup);
            }
            unitOfWork.SaveChanges();

            _list.Add(userGroup);
            return userGroup;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            foreach (XUserGroup userGroup in _list)
            {
                foreach (XUser_UserGroup userUserGroup in userGroup.XUser_UserGroup.ToList())
                {
                    DeleteUserUserGroup(unitOfWork, userUserGroup);
                }
                unitOfWork.SaveChanges();
                DeleteUserGroup(unitOfWork, userGroup);
                unitOfWork.SaveChanges();
            }
            _userHeler.Delete(unitOfWork);
        }

        #endregion

        #region Private Methods

        private void DeleteUserGroup(IUnitOfWork unitOfWork, XUserGroup userGroup)
        {
            var repository = UnitOfWork.GetRepository<XUserGroup>(unitOfWork);
            var entity = (from x in repository
                          where x.UserGroupID == userGroup.UserGroupID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        private void DeleteUserUserGroup(IUnitOfWork unitOfWork, XUser_UserGroup userUserGroup)
        {
            var repository = UnitOfWork.GetRepository<XUser_UserGroup>(unitOfWork);
            var entity = (from x in repository
                          where x.UserID == userUserGroup.UserID
                          where x.UserGroupID == userUserGroup.UserGroupID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        #endregion

        #endregion
    }
}