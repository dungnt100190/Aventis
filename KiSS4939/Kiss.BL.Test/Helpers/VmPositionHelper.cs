using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class VmPositionHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<VmPosition> _list = new List<VmPosition>();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public VmPosition Create(
            IUnitOfWork unitOfWork,
            VmKlientenbudget budget,
            VmPositionsart positionsart,
            string name,
            decimal? betragMonatlich = null,
            decimal? saldo = null)
        {
            var repository = UnitOfWork.GetRepository<VmPosition>(unitOfWork);

            var position = new VmPosition
            {
                VmKlientenbudget = budget,
                VmPositionsart = positionsart,
                Name = name,
                BetragMonatlich = betragMonatlich,
                Saldo = saldo,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now
            };

            _list.Add(position);

            repository.ApplyChanges(position);
            unitOfWork.SaveChanges();
            position.AcceptChanges();

            return position;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _list.ForEach(x => DeleteVmPosition(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());
        }

        #endregion

        #region Private Static Methods

        private static void DeleteVmPosition(IUnitOfWork unitOfWork, VmPosition position)
        {
            var repository = UnitOfWork.GetRepository<VmPosition>(unitOfWork);
            var entity = (from x in repository
                          where x.VmPositionID == position.VmPositionID
                          select x).SingleOrDefault();
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