using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class BaInstitutionHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<BaInstitution> _list = new List<BaInstitution>();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public BaInstitution Create(IUnitOfWork unitOfWork, string name)
        {
            var repository = UnitOfWork.GetRepository<BaInstitution>(unitOfWork);

            var institution = new BaInstitution
            {
                Name = name,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now
            };

            _list.Add(institution);

            repository.ApplyChanges(institution);
            unitOfWork.SaveChanges();

            return institution;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _list.ForEach(x => DeleteBaInstitution(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());
        }

        #endregion

        #region Private Static Methods

        private static void DeleteBaInstitution(IUnitOfWork unitOfWork, BaInstitution institution)
        {
            var repository = UnitOfWork.GetRepository<BaInstitution>(unitOfWork);
            var entity = (from x in repository
                          where x.BaInstitutionID == institution.BaInstitutionID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        #endregion

        #endregion
    }
}