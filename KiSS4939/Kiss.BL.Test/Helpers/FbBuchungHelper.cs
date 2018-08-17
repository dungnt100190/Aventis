using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class FbBuchungHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<FbBuchung> _list = new List<FbBuchung>();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public FbBuchung Create(
            IUnitOfWork unitOfWork,
            FbPeriode periode,
            decimal betrag,
            int sollKtoNr = 1000,
            int habenKtoNr = 4150,
            DateTime? buchungsDatum = null,
            string belegNr = "1234",
            string text = "Buchungstext")
        {
            var repository = UnitOfWork.GetRepository<FbBuchung>(unitOfWork);

            if (!buchungsDatum.HasValue || buchungsDatum.Value < SqlDateTime.MinValue)
            {
                buchungsDatum = (DateTime?)SqlDateTime.MinValue;
            }

            var buchung = new FbBuchung
            {
                FbPeriode = periode,
                Betrag = betrag,
                SollKtoNr = sollKtoNr,
                HabenKtoNr = habenKtoNr,
                BelegNr = belegNr,
                BelegNrPos = 0,
                BuchungsDatum = buchungsDatum.Value,
                Text = text,
                ErfassungsDatum = DateTime.Now,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now
            };

            _list.Add(buchung);

            repository.ApplyChanges(buchung);
            unitOfWork.SaveChanges();
            buchung.AcceptChanges();

            return buchung;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _list.ForEach(x => DeleteFbBuchung(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());
        }

        #endregion

        #region Private Static Methods

        private static void DeleteFbBuchung(IUnitOfWork unitOfWork, FbBuchung periode)
        {
            var repository = UnitOfWork.GetRepository<FbBuchung>(unitOfWork);
            var entity = (from x in repository
                          where x.FbBuchungID == periode.FbBuchungID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        #endregion

        #endregion
    }
}