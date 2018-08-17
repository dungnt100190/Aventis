using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class VmKlientenbudgetHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly FaLeistungHelper _faLeistungHelper = new FaLeistungHelper();
        private readonly List<VmKlientenbudget> _list = new List<VmKlientenbudget>();
        private readonly VmPositionHelper _vmPositionHelper = new VmPositionHelper();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public void AddPosition(
            IUnitOfWork unitOfWork,
            VmKlientenbudget klientenbudget,
            VmPositionsart positionsart,
            string name,
            decimal? betragMonatlich = null,
            decimal? saldo = null)
        {
            _vmPositionHelper.Create(unitOfWork, klientenbudget, positionsart, name, betragMonatlich, saldo);
        }

        public VmKlientenbudget Create(IUnitOfWork unitOfWork)
        {
            var faLeistung = _faLeistungHelper.Create(unitOfWork, 5, 501);

            return Create(unitOfWork, faLeistung);
        }

        public VmKlientenbudget Create(IUnitOfWork unitOfWork, FaLeistung faLeistung)
        {
            var repository = UnitOfWork.GetRepository<VmKlientenbudget>(unitOfWork);

            var klientenbudget = new VmKlientenbudget
            {
                FaLeistung = faLeistung,
                VmKlientenbudgetStatusCode = (int)LOVsGenerated.VmKlientenbudgetStatus.InBearbeitung,
                GueltigAb = DateTime.Now,
                XUser = faLeistung.XUser,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now
            };

            _list.Add(klientenbudget);

            repository.ApplyChanges(klientenbudget);
            unitOfWork.SaveChanges();
            klientenbudget.AcceptChanges();

            return klientenbudget;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _vmPositionHelper.Delete(unitOfWork);

            _list.ForEach(x => x.MarkAsDeleted());
            var repoBudget = UnitOfWork.GetRepository<VmKlientenbudget>(unitOfWork);
            _list.ForEach(repoBudget.ApplyChanges);
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());

            _faLeistungHelper.Delete(unitOfWork);
        }

        #endregion

        #endregion
    }
}