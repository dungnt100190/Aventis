using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class FsDienstleistung_FsDienstleistungspaketHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<FsDienstleistung_FsDienstleistungspaket> _list = new List<FsDienstleistung_FsDienstleistungspaket>();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public FsDienstleistung_FsDienstleistungspaket Create(IUnitOfWork unitOfWork, FsDienstleistung dienstleistung, FsDienstleistungspaket paket)
        {
            var dlDlp = new FsDienstleistung_FsDienstleistungspaket
            {
                FsDienstleistung = dienstleistung,
                FsDienstleistungspaket = paket,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now
            };

            _list.Add(dlDlp);
            var repository = UnitOfWork.GetRepository<FsDienstleistung_FsDienstleistungspaket>(unitOfWork);
            repository.ApplyChanges(dlDlp);
            unitOfWork.SaveChanges();
            dlDlp.AcceptChanges();

            return dlDlp;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _list.ForEach(x => DeleteFsDienstleistungFsDienstleistungspaket(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());
        }

        #endregion

        #region Private Static Methods

        private static void DeleteFsDienstleistungFsDienstleistungspaket(IUnitOfWork unitOfWork, FsDienstleistung_FsDienstleistungspaket dlDlp)
        {
            var repository = UnitOfWork.GetRepository<FsDienstleistung_FsDienstleistungspaket>(unitOfWork);
            var entity = (from x in repository
                          where x.FsDienstleistung_FsDienstleistungspaketID == dlDlp.FsDienstleistung_FsDienstleistungspaketID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        #endregion

        #endregion
    }
}