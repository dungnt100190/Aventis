using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class FsDienstleistungHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<FsDienstleistung> _list = new List<FsDienstleistung>();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Liefert eine Liste mit 3 Dienstleistungen. Totalaufwand: 7.5 (1.5 + 2.75 + 3).
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public List<FsDienstleistung> CreateList(IUnitOfWork unitOfWork)
        {
            var repository = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);

            var list = new List<FsDienstleistung>
            {
                    new FsDienstleistung
                    {
                        Name = "Test Dienstleistung 1",
                        StandardAufwand = (decimal)1.5,
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now
                    },
                    new FsDienstleistung
                    {
                        Name = "Test Dienstleistung 2",
                        StandardAufwand = (decimal)2.75,
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now
                    },
                    new FsDienstleistung
                    {
                        Name = "Test Dienstleistung 3",
                        StandardAufwand = 3,
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now
                    }
            };

            _list.AddRange(list);
            list.ForEach(repository.ApplyChanges);
            unitOfWork.SaveChanges();
            list.ForEach(dl => dl.AcceptChanges());

            return list;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _list.ForEach(x => DeleteDienstleistung(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());
        }

        #endregion

        #region Private Static Methods

        private static void DeleteDienstleistung(IUnitOfWork unitOfWork, FsDienstleistung dienstleistung)
        {
            var repository = UnitOfWork.GetRepository<FsDienstleistung>(unitOfWork);
            var entity = (from x in repository
                          where x.FsDienstleistungID == dienstleistung.FsDienstleistungID
                          select x).First();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        #endregion

        #endregion
    }
}