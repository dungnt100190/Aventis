using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class FsReduktionHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<FsReduktion> _list = new List<FsReduktion>();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public List<FsReduktion> CreateList(IUnitOfWork unitOfWork)
        {
            string creator = "UnitTester";
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var repository = UnitOfWork.GetRepository<FsReduktion>(unitOfWork);

            _list.Add(
                new FsReduktion
                {
                    Name = "Ferien",
                    StandardAufwand = 30,
                    AbhaengigVonBG = true,
                    Created = DateTime.Now,
                    Creator = creator,
                    Modified = DateTime.Now,
                    Modifier = creator
                });

            _list.Add(
                new FsReduktion
                {
                    Name = "Altersentlastung",
                    StandardAufwand = 10,
                    AbhaengigVonBG = true,
                    Created = DateTime.Now,
                    Creator = creator,
                    Modified = DateTime.Now,
                    Modifier = creator
                });

            _list.Add(
                new FsReduktion
                {
                    Name = "Teamsitzung",
                    StandardAufwand = 50,
                    AbhaengigVonBG = false,
                    Created = DateTime.Now,
                    Creator = creator,
                    Modified = DateTime.Now,
                    Modifier = creator
                });

            _list.ForEach(repository.ApplyChanges);
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());

            return _list;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _list.ForEach(x => DeleteReduktion(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());
        }

        #endregion

        #region Private Static Methods

        private static void DeleteReduktion(IUnitOfWork unitOfWork, FsReduktion reduktion)
        {
            var repository = UnitOfWork.GetRepository<FsReduktion>(unitOfWork);
            var entity = (from x in repository
                          where x.FsReduktionID == reduktion.FsReduktionID
                          select x).First();

            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        #endregion

        #endregion
    }
}