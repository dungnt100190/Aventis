using System.Collections.Generic;
using System.Linq;

using Kiss.BL.Ba;
using Kiss.Interfaces.BL;
using Kiss.Infrastructure.IoC;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class BaPersonHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<BaPerson> _list = new List<BaPerson>();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public BaPerson Create(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            //We use BaPersonService because of HistoryVersion.
            var personService = Container.Resolve<BaPersonService>();

            BaPerson baPerson;
            personService.NewData(out baPerson);
            baPerson.Name = "Unit Test Nachname";
            baPerson.Vorname = "Unit Test Vorname";
            personService.SaveData(unitOfWork, baPerson);

            _list.Add(baPerson);

            return baPerson;
        }

        public List<BaPerson> Create(IUnitOfWork unitOfWork, int nbrOfPersons)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            //We use BaPersonService because of HistoryVersion.
            var personService = Container.Resolve<BaPersonService>();

            List<BaPerson> baPersons = new List<BaPerson>(nbrOfPersons);
            BaPerson baPerson;
            for (int i = 0; i < nbrOfPersons; i++)
            {
                personService.NewData(out baPerson);
                baPerson.Name = "Unit Test Nachname" + i;
                baPerson.Vorname = "Unit Test Vorname" + i;
                personService.SaveData(unitOfWork, baPerson);

                baPersons.Add(baPerson);

                _list.Add(baPerson);
            }
            return baPersons;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _list.ForEach(x => x.MarkAsDeleted());
            var repository = UnitOfWork.GetRepository<BaPerson>(unitOfWork);
            _list.ForEach(repository.ApplyChanges);
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());
        }

        #endregion

        #endregion
    }
}