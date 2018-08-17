using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class FaPhaseHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly FaLeistungHelper _leistungHelper = new FaLeistungHelper();
        private readonly List<FaPhase> _list = new List<FaPhase>();

        #endregion

        #endregion

        #region Properties

        public List<FaPhase> List
        {
            get
            {
                return _list;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void ApplyChanges()
        {
            var unitOfWork = UnitOfWork.GetNew;
            var repository = UnitOfWork.GetRepository<FaPhase>(unitOfWork);
            _list.ForEach(repository.ApplyChanges);
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());
        }

        public FaPhase Create(IUnitOfWork unitOfWork)
        {
            FaLeistung leistung = _leistungHelper.Create(unitOfWork, 2, 200);
            IRepository<FaPhase> repository = UnitOfWork.GetRepository<FaPhase>(unitOfWork);

            FaPhase phase =
                new FaPhase
                {
                    FaLeistung = leistung,
                    FaPhaseCode = 1,
                    DatumVon = new DateTime(DateTime.Today.Year, 1, 1),
                    DatumBis = new DateTime(DateTime.Today.Year, 12, 31),
                    Creator = CREATOR,
                    Created = DateTime.Now,
                    Modifier = CREATOR,
                    Modified = DateTime.Now
                };

            repository.ApplyChanges(phase);
            unitOfWork.SaveChanges();
            phase.AcceptChanges();

            _list.Add(phase);

            return phase;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _list.ForEach(x => DeletePhase(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());

            _leistungHelper.Delete(unitOfWork);
        }

        #endregion

        #region Private Static Methods

        private static void DeletePhase(IUnitOfWork unitOfWork, FaPhase phase)
        {
            var repository = UnitOfWork.GetRepository<FaPhase>(unitOfWork);
            var entity = (from x in repository
                          where x.FaPhaseID == phase.FaPhaseID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        #endregion

        #endregion
    }
}