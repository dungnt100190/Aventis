using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class FaLeistungHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly FaFallHelper _fallHelper = new FaFallHelper();
        private readonly List<FaLeistung> _list = new List<FaLeistung>();
        private readonly BaPersonHelper _personHelper = new BaPersonHelper();
        private readonly XUserHelper _userHelper = new XUserHelper();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public FaLeistung Create(IUnitOfWork unitOfWork, XUser user, int xModulId, int faProzessCode)
        {
            BaPerson baPerson = _personHelper.Create(unitOfWork);

            return Create(unitOfWork, baPerson.BaPersonID, baPerson, user, xModulId, faProzessCode);
        }

        public FaLeistung Create(IUnitOfWork unitOfWork, int xModulId, int faProzessCode)
        {
            return Create(unitOfWork, null, xModulId, faProzessCode);
        }

        public FaLeistung CreateWsh(IUnitOfWork unitOfWork)
        {
            BaPerson baPerson = _personHelper.Create(unitOfWork);

            return CreateWsh(unitOfWork, baPerson.BaPersonID, baPerson);
        }

        public FaLeistung CreateWsh(IUnitOfWork unitOfWork, int fallId)
        {
            BaPerson baPerson = _personHelper.Create(unitOfWork);

            return CreateWsh(unitOfWork, fallId, baPerson);
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repoFaLeistung = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);
            _list.ForEach(x => x.MarkAsDeleted());
            _list.ForEach(repoFaLeistung.ApplyChanges);
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());

            //_userHelper.Delete(unitOfWork);
            _fallHelper.Delete(unitOfWork);
            _personHelper.Delete(unitOfWork);
        }

        #endregion

        #region Private Methods

        private FaLeistung Create(IUnitOfWork unitOfWork, int fallId, BaPerson baPerson, XUser xUser, int modulID, int faProzessCode)
        {
            xUser = xUser ?? _userHelper.GetOrCreate(unitOfWork);

            var repository = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);
            var fall = _fallHelper.Create(unitOfWork, xUser, baPerson);

            var leistung = new FaLeistung
            {
                BaPerson = baPerson,
                XUser = xUser,
                DatumVon = new DateTime(DateTime.Today.Year, 1, 1),
                FaFall = fall,
                ModulID = modulID,
                FaProzessCode = faProzessCode,
                //FaFallID = fallId,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
            };

            _list.Add(leistung);

            repository.ApplyChanges(leistung);
            unitOfWork.SaveChanges();
            leistung.AcceptChanges();

            return leistung;
        }

        private FaLeistung CreateWsh(IUnitOfWork unitOfWork, int fallId, BaPerson baPerson)
        {
            return Create(unitOfWork, fallId, baPerson, null, 103 /*WSH*/, (int)LOVsGenerated.FaProzess.Existenzsicherung);
        }

        #endregion

        #endregion
    }
}