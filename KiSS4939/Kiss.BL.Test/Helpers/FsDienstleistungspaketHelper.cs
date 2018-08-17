using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class FsDienstleistungspaketHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly FsDienstleistung_FsDienstleistungspaketHelper _dlDlpHelper = new FsDienstleistung_FsDienstleistungspaketHelper();
        private readonly FsDienstleistungHelper _dlHelper = new FsDienstleistungHelper();
        private readonly List<FsDienstleistungspaket> _list = new List<FsDienstleistungspaket>();

        #endregion

        #endregion

        #region Properties

        public List<FsDienstleistungspaket> List
        {
            get
            {
                return _list;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Applies changes made to objects in List.
        /// </summary>
        public void ApplyChanges()
        {
            ApplyChanges(UnitOfWork.GetNew);
        }

        private void ApplyChanges(IUnitOfWork unitOfWork)
        {
            var repository = UnitOfWork.GetRepository<FsDienstleistungspaket>(unitOfWork);
            _list.ForEach(repository.ApplyChanges);
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());
        }

        /// <summary>
        /// Creates a Dienstleisungspaket with 
        /// 3 Dienstleistungen assigned.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public FsDienstleistungspaket Create(IUnitOfWork unitOfWork)
        {
            var dlp = new FsDienstleistungspaket
            {
                Name = "Test Dienstleistungspaket 1",
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now
            };

            _list.Add(dlp);

            ApplyChanges(unitOfWork);

            var dienstleistungen = _dlHelper.CreateList(unitOfWork);
            dienstleistungen.ForEach(dl => _dlDlpHelper.Create(unitOfWork, dl, dlp));

            return dlp;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _dlDlpHelper.Delete(unitOfWork);
            _dlHelper.Delete(unitOfWork);

            _list.ForEach(x => DeleteDienstleistungspaket(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());
        }

        #endregion

        #region Private Methods

        private void DeleteDienstleistungspaket(IUnitOfWork unitOfWork, FsDienstleistungspaket dlp)
        {
            var repository = UnitOfWork.GetRepository<FsDienstleistungspaket>(unitOfWork);
            var entity = (from x in repository
                          where x.FsDienstleistungspaketID == dlp.FsDienstleistungspaketID
                          select x).First();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        #endregion

        #endregion
    }
}