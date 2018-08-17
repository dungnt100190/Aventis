using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class FbPeriodeHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<FbPeriode> _list = new List<FbPeriode>();

        #endregion

        private readonly BaPersonHelper _personHelper = new BaPersonHelper();
        #endregion

        #region Methods

        #region Public Methods

        public FbPeriode Create(IUnitOfWork unitOfWork)
        {
            var person = _personHelper.Create(unitOfWork);
            return Create(unitOfWork, person);
        }

        public FbPeriode Create(
            IUnitOfWork unitOfWork,
            BaPerson person, 
            DateTime? periodeVon = null,
            DateTime? periodeBis = null)
        {
            var repository = UnitOfWork.GetRepository<FbPeriode>(unitOfWork);

            if (!periodeVon.HasValue)
            {
                periodeVon = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            }

            if (!periodeBis.HasValue)
            {
                periodeBis = periodeVon.Value.AddYears(2);
            }

            var periode = new FbPeriode
            {
                BaPerson = person,
                PeriodeVon = periodeVon.Value,
                PeriodeBis = periodeBis.Value
            };

            _list.Add(periode);

            repository.ApplyChanges(periode);
            unitOfWork.SaveChanges();
            periode.AcceptChanges();

            return periode;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _list.ForEach(x => DeleteFbPeriode(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());
        }

        #endregion

        #region Private Static Methods

        private static void DeleteFbPeriode(IUnitOfWork unitOfWork, FbPeriode periode)
        {
            var repository = UnitOfWork.GetRepository<FbPeriode>(unitOfWork);
            var entity = (from x in repository
                          where x.FbPeriodeID == periode.FbPeriodeID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        #endregion

        #endregion
    }
}