using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class FaFallHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<FaFall> _list = new List<FaFall>();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public FaFall Create(IUnitOfWork unitOfWork, XUser user, BaPerson person)
        {
            var repository = UnitOfWork.GetRepository<FaFall>(unitOfWork);

            var fall = new FaFall
            {
                BaPerson = person,
                UserID = user.UserID,
                DatumVon = new DateTime(2009, 1, 1),
            };

            _list.Add(fall);

            repository.ApplyChanges(fall);
            unitOfWork.SaveChanges();
            fall.AcceptChanges();

            return fall;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _list.ForEach(x => DeleteFall(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());
        }

        #endregion

        #region Private Static Methods

        private static void DeleteFall(IUnitOfWork unitOfWork, FaFall fall)
        {
            var repository = UnitOfWork.GetRepository<FaFall>(unitOfWork);
            var entity = (from x in repository
                          where x.FaFallID == fall.FaFallID
                          select x).SingleOrDefault();

            // Ursprüngliches Entity versuchen aus dem Repository zu entfernen (wenn FaFall eine View ist, kann das Entity nicht wirklich gelöscht werden)
            fall.MarkAsDeleted();
            repository.ApplyChanges(fall);

            if (entity != null)
            {
                try
                {
                    entity.MarkAsDeleted();
                    repository.ApplyChanges(entity);
                }
                catch
                {
                    // für Mock/Standard, falls das Löschen vor dem if() geklappt hat
                }
            }
        }

        #endregion

        #endregion
    }
}