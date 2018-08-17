using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class FsReduktionMitarbeiterHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<FsReduktionMitarbeiter> _list = new List<FsReduktionMitarbeiter>();
        private readonly FsReduktionHelper _reduktionHelper = new FsReduktionHelper();
        private readonly XUserHelper _userHelper = new XUserHelper();

        #endregion

        #region Private Fields

        private IList<FsReduktion> _reduktionen;
        private IList<XUser> _users;

        #endregion

        #endregion

        #region Properties

        public IList<FsReduktion> Reduktionen
        {
            get { return _reduktionen; }
        }

        public IList<XUser> Users
        {
            get { return _users; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public List<FsReduktionMitarbeiter> CreateList(IUnitOfWork unitOfWork)
        {
            string creator = "UnitTester";

            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);

            _users = _userHelper.CreateList(unitOfWork);
            _reduktionen = _reduktionHelper.CreateList(unitOfWork);

            var month = new MonthYear(DateTime.Today.Year, DateTime.Today.Month);
            month--;

            _list.Add(
                new FsReduktionMitarbeiter
                {
                    FsReduktion = _reduktionen[0],
                    XUser = _users[0],
                    Jahr = month.Year,
                    Monat = month.Month,
                    OriginalReduktionZeit = 30,
                    Created = DateTime.Now,
                    Creator = creator,
                    Modified = DateTime.Now,
                    Modifier = creator
                });

            _list.Add(
                new FsReduktionMitarbeiter
                {
                    FsReduktion = _reduktionen[1],
                    XUser = _users[0],
                    Jahr = month.Year,
                    Monat = month.Month,
                    OriginalReduktionZeit = 10,
                    Created = DateTime.Now,
                    Creator = creator,
                    Modified = DateTime.Now,
                    Modifier = creator
                });

            _list.Add(
                new FsReduktionMitarbeiter
                {
                    FsReduktion = _reduktionen[2],
                    XUser = _users[0],
                    Jahr = month.Year,
                    Monat = month.Month,
                    OriginalReduktionZeit = 50,
                    AngepassteReduktionZeit = 60,
                    Created = DateTime.Now,
                    Creator = creator,
                    Modified = DateTime.Now,
                    Modifier = creator
                });

            _list.Add(
                new FsReduktionMitarbeiter
                {
                    FsReduktion = _reduktionen[0],
                    XUser = _users[1],
                    Jahr = month.Year,
                    Monat = month.Month,
                    OriginalReduktionZeit = 30,
                    Created = DateTime.Now,
                    Creator = creator,
                    Modified = DateTime.Now,
                    Modifier = creator
                });

            _list.Add(
                new FsReduktionMitarbeiter
                {
                    FsReduktion = _reduktionen[1],
                    XUser = _users[1],
                    Jahr = month.Year,
                    Monat = month.Month,
                    OriginalReduktionZeit = 10,
                    AngepassteReduktionZeit = 0,
                    Created = DateTime.Now,
                    Creator = creator,
                    Modified = DateTime.Now,
                    Modifier = creator
                });

            _list.Add(
                new FsReduktionMitarbeiter
                {
                    FsReduktion = _reduktionen[2],
                    XUser = _users[1],
                    Jahr = month.Year,
                    Monat = month.Month,
                    OriginalReduktionZeit = 50,
                    AngepassteReduktionZeit = 30,
                    Created = DateTime.Now,
                    Creator = creator,
                    Modified = DateTime.Now,
                    Modifier = creator
                });

            _list.Add(
                new FsReduktionMitarbeiter
                {
                    FsReduktion = _reduktionen[0],
                    XUser = _users[2],
                    Jahr = month.Year,
                    Monat = month.Month,
                    OriginalReduktionZeit = 30,
                    AngepassteReduktionZeit = 40,
                    Created = DateTime.Now,
                    Creator = creator,
                    Modified = DateTime.Now,
                    Modifier = creator
                });

            _list.Add(
                new FsReduktionMitarbeiter
                {
                    FsReduktion = _reduktionen[1],
                    XUser = _users[2],
                    Jahr = month.Year,
                    Monat = month.Month,
                    OriginalReduktionZeit = 10,
                    Created = DateTime.Now,
                    Creator = creator,
                    Modified = DateTime.Now,
                    Modifier = creator
                });

            _list.Add(
                new FsReduktionMitarbeiter
                {
                    FsReduktion = _reduktionen[2],
                    XUser = _users[2],
                    Jahr = month.Year,
                    Monat = month.Month,
                    OriginalReduktionZeit = 50,
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
            _list.ForEach(x => DeleteReduktionMitarbeiter(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());

            //_userHelper.Delete(unitOfWork);
            _reduktionHelper.Delete(unitOfWork);
        }

        #endregion

        #region Private Methods

        private void DeleteReduktionMitarbeiter(IUnitOfWork unitOfWork, FsReduktionMitarbeiter reduktionMitarbeiter)
        {
            var repository = UnitOfWork.GetRepository<FsReduktionMitarbeiter>(unitOfWork);
            //Eventuell wurde FsReduktionMitarbeiter bereits gelöscht.
            var entity = (from x in repository
                          where x.FsReduktionMitarbeiterID == reduktionMitarbeiter.FsReduktionMitarbeiterID
                          select x).FirstOrDefault();

            if (entity != null)
            {
                entity.MarkAsDeleted();
                repository.ApplyChanges(entity);
            }
        }

        #endregion

        #endregion
    }
}