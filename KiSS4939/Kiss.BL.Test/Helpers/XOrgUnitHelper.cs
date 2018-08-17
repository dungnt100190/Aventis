using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BL.KissSystem;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class XOrgUnitHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<XOrgUnit> _orgUnitsCreated = new List<XOrgUnit>();

        #endregion

        #region Private Fields

        private int _parentPosition = 10;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public XOrgUnit Create(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<XOrgUnit>(unitOfWork);

            var maxParentPos = repository.Where(x => x.ParentID == null).OrderByDescending(x => x.ParentPosition).FirstOrDefault();

            if (maxParentPos != null && maxParentPos.ParentPosition != null)
            {
                _parentPosition = maxParentPos.ParentPosition.Value + 1;
            }

            SystemService.NewHistoryVersion(unitOfWork);
            var orgUnit = new XOrgUnit
            {
                ItemName = Guid.NewGuid().ToString(),
                ParentPosition = _parentPosition++,
                Created = DateTime.Now,
                Creator = CREATOR,
                Modified = DateTime.Now,
                Modifier = CREATOR
            };

            repository.ApplyChanges(orgUnit);
            unitOfWork.SaveChanges();

            _orgUnitsCreated.Add(orgUnit);

            return orgUnit;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            SystemService.NewHistoryVersion(unitOfWork);
            _orgUnitsCreated.ForEach(x => DeleteOrgUnit(unitOfWork, x));
            unitOfWork.SaveChanges();
            _orgUnitsCreated.ForEach(x => x.AcceptChanges());
        }

        #endregion

        #region Private Methods

        private void DeleteOrgUnit(IUnitOfWork unitOfWork, XOrgUnit orgUnit)
        {
            var repository = UnitOfWork.GetRepository<XOrgUnit>(unitOfWork);
            var entity = (from x in repository
                          where x.OrgUnitID == orgUnit.OrgUnitID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        #endregion

        #endregion
    }
}