using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class BaZahlungswegHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<BaZahlungsweg> _list = new List<BaZahlungsweg>();
        private readonly BaPersonHelper _personHelper = new BaPersonHelper();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public BaZahlungsweg Create(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var person = _personHelper.Create(unitOfWork);
            return Create(unitOfWork, person);
        }

        public BaZahlungsweg Create(IUnitOfWork unitOfWork, BaPerson person)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<BaZahlungsweg>(unitOfWork);

            var zahlungsweg = new BaZahlungsweg
            {
                BaPerson = person,
                EinzahlungsscheinCode = 6, // Postmandat
                DatumVon = new DateTime(2011, 1, 1),
            };

            _list.Add(zahlungsweg);

            repository.ApplyChanges(zahlungsweg);
            unitOfWork.SaveChanges();
            zahlungsweg.AcceptChanges();

            CreateWohnAdresse(unitOfWork, person);

            return zahlungsweg;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _list.ForEach(x => DeleteZahlungsweg(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());
        }

        #endregion

        #region Private Static Methods

        private static void DeleteAdressen(IUnitOfWork unitOfWork, int baPersonId)
        {
            var repAdresse = UnitOfWork.GetRepository<BaAdresse>(unitOfWork);
            var query = repAdresse.Where(x => x.BaPersonID == baPersonId);
            foreach (var adresse in query)
            {
                adresse.MarkAsDeleted();
                repAdresse.ApplyChanges(adresse);
            }
            unitOfWork.SaveChanges();
        }

        private static void DeleteZahlungsweg(IUnitOfWork unitOfWork, BaZahlungsweg zahlungsweg)
        {
            if(zahlungsweg.BaPersonID.HasValue)
            {
                DeleteAdressen(unitOfWork, zahlungsweg.BaPersonID.Value);
            }
            var repository = UnitOfWork.GetRepository<BaZahlungsweg>(unitOfWork);
            var entity = (from x in repository
                          where x.BaZahlungswegID == zahlungsweg.BaZahlungswegID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        #endregion

        #region Private Methods

        private void CreateWohnAdresse(IUnitOfWork unitOfWork, BaPerson person)
        {
            BaAdresse adresse = new BaAdresse
            {
                BaPerson =  person,
                BaPersonID = person.BaPersonID,
                AdresseCode = 1,
                DatumVon = new DateTime(1975, 01, 05),
                DatumBis = null,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
            };
            var repAdresse = UnitOfWork.GetRepository<BaAdresse>(unitOfWork);
            repAdresse.ApplyChanges(adresse);
            unitOfWork.SaveChanges();
        }

        #endregion

        #endregion
    }
}