using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class VmPositionsartHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<VmPositionsart> _list = new List<VmPositionsart>();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public VmPositionsart Create(IUnitOfWork unitOfWork)
        {
            return Create(unitOfWork, LOVsGenerated.VmKategorie.FixeKosten, LOVsGenerated.VmPositionsartTyp.Empty, "PositionsartTest");
        }

        public VmPositionsart Create(
            IUnitOfWork unitOfWork,
            LOVsGenerated.VmKategorie kategorie,
            LOVsGenerated.VmPositionsartTyp positionsartTyp,
            string name = "",
            bool istTemplate = false)
        {
            var repository = UnitOfWork.GetRepository<VmPositionsart>(unitOfWork);

            var positionsart = new VmPositionsart
            {
                Name = name,
                VmKategorieCode = (int)kategorie,
                VmPositionsartTypCode = positionsartTyp == LOVsGenerated.VmPositionsartTyp.Empty ? null : (int?)positionsartTyp,
                IstTemplate = istTemplate,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now
            };

            _list.Add(positionsart);

            repository.ApplyChanges(positionsart);
            unitOfWork.SaveChanges();
            positionsart.AcceptChanges();

            return positionsart;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _list.ForEach(x => DeleteVmPositionsart(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());
        }

        #endregion

        #region Private Static Methods

        private static void DeleteVmPositionsart(IUnitOfWork unitOfWork, VmPositionsart positionsart)
        {
            var repository = UnitOfWork.GetRepository<VmPositionsart>(unitOfWork);
            var entity = (from x in repository
                          where x.VmPositionsartID == positionsart.VmPositionsartID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        #endregion

        #endregion
    }
}