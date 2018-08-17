using System.Collections.Generic;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class BaGesundheitHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly BaInstitutionHelper _baInstitutionHelper = new BaInstitutionHelper();
        private readonly List<BaGesundheit> _list = new List<BaGesundheit>();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public BaGesundheit Create(
            IUnitOfWork unitOfWork,
            BaPerson person,
            decimal? kvgPraemie = null,
            string kvgInstitutionsname = null,
            decimal? vvgPraemie = null,
            string vvgInstitutionsname = null)
        {
            var repository = UnitOfWork.GetRepository<BaGesundheit>(unitOfWork);

            BaInstitution kvgInstitution = null;
            if (!string.IsNullOrEmpty(kvgInstitutionsname))
            {
                kvgInstitution = _baInstitutionHelper.Create(unitOfWork, kvgInstitutionsname);
            }

            BaInstitution vvgInstitution = null;
            if (!string.IsNullOrEmpty(vvgInstitutionsname))
            {
                vvgInstitution = _baInstitutionHelper.Create(unitOfWork, vvgInstitutionsname);
            }

            var gesundheit = new BaGesundheit
            {
                BaPerson = person,
                KVGPraemie = kvgPraemie,
                BaInstitution_Kvg = kvgInstitution,
                VVGPraemie = vvgPraemie,
                BaInstitution_Vvg = vvgInstitution,
            };

            _list.Add(gesundheit);

            repository.ApplyChanges(gesundheit);
            unitOfWork.SaveChanges();

            return gesundheit;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _baInstitutionHelper.Delete(unitOfWork);

            _list.ForEach(x => DeleteBaGesundheit(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());
        }

        #endregion

        #region Private Static Methods

        private static void DeleteBaGesundheit(IUnitOfWork unitOfWork, BaGesundheit gesundheit)
        {
            var repository = UnitOfWork.GetRepository<BaGesundheit>(unitOfWork);
            var entity = (from x in repository
                          where x.BaPersonID == gesundheit.BaPersonID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        #endregion

        #endregion
    }
}