using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class FbKontoHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<FbKonto> _list = new List<FbKonto>();

        #endregion

        private readonly FbPeriodeHelper _periodeHelper = new FbPeriodeHelper();
        #endregion

        #region Methods

        #region Public Methods

        public FbKonto Create(IUnitOfWork unitOfWork)
        {
            var periode = _periodeHelper.Create(unitOfWork);
            return Create(unitOfWork, periode);
        }

        public FbKonto Create(
            IUnitOfWork unitOfWork,
            FbPeriode periode,
            decimal eroeffnungsSaldo = 0,
            int kontoNr = 1000, 
            string kontoName = "Postcheck",
            string saldoGruppeName = "Kasse + PC", 
            int kontoKlasseCode = 1,
            int kontoTypCode = 1)
        {
            var repository = UnitOfWork.GetRepository<FbKonto>(unitOfWork);

            var konto = new FbKonto
            {
                FbPeriode = periode,
                KontoNr = kontoNr,
                KontoName = kontoName,
                SaldoGruppeName = saldoGruppeName,
                EroeffnungsSaldo = eroeffnungsSaldo,
                KontoKlasseCode = kontoKlasseCode,
                KontoTypCode = kontoTypCode,
            };

            _list.Add(konto);

            repository.ApplyChanges(konto);
            unitOfWork.SaveChanges();
            konto.AcceptChanges();

            return konto;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _list.ForEach(x => DeleteFbKonto(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());

            _periodeHelper.Delete(unitOfWork);
        }

        #endregion

        #region Private Static Methods

        private static void DeleteFbKonto(IUnitOfWork unitOfWork, FbKonto periode)
        {
            var repository = UnitOfWork.GetRepository<FbKonto>(unitOfWork);
            var entity = (from x in repository
                          where x.FbKontoID == periode.FbKontoID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        #endregion

        #endregion
    }
}