using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class WshHaushaltPersonHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly FaLeistungHelper _leistungHelper = new FaLeistungHelper();
        private readonly BaPersonHelper _personHelper = new BaPersonHelper();

        private const string CREATOR = "UnitTester";

        #endregion

        #region Private Fields

        private List<BaPerson> _baPersons;
        private BaWohnsituation _baWohnsituation;
        private BaWohnsituationPerson _baWohnsituationPerson;
        private FaLeistung _faLeistungHaushalt;
        private List<WshHaushaltPerson> _haushaltPersonen;

        #endregion

        #endregion

        #region Methods

        #region Public Methods


        /// <summary>
        /// Erstellt einen Haushalt mit zwei Personen.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public IList<WshHaushaltPerson> Create(IUnitOfWork unitOfWork, out List<BaPerson> baPeople, out BaWohnsituation baWohnsituation,
            out BaWohnsituationPerson baWohnsituationPerson, out FaLeistung faLeistungHaushalt)
        {
            IList<WshHaushaltPerson> result = Create(unitOfWork);
            baPeople = _baPersons;
            baWohnsituation = _baWohnsituation;
            baWohnsituationPerson = _baWohnsituationPerson;
            faLeistungHaushalt = _faLeistungHaushalt;
            return result;
        }

        /// <summary>
        /// Erstellt einen Haushalt mit zwei Personen.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public IList<WshHaushaltPerson> Create(IUnitOfWork unitOfWork)
        {
            _baPersons = _personHelper.Create(unitOfWork, 2);

            //Create a Haushalt
            /*
             * P0  +-------------------------
             *     +-------------------------
             * P1        +-----+
             *           +-----+
             * ----+-----+-----+-----+-----+--->
             *    1.1.  1.2.  1.3.  1.4.  1.5.
             */

            IRepository<WshHaushaltPerson> repository = UnitOfWork.GetRepository<WshHaushaltPerson>(unitOfWork);
            _faLeistungHaushalt = _leistungHelper.Create(unitOfWork);

            _haushaltPersonen = new List<WshHaushaltPerson>
                    {
                        new WshHaushaltPerson
                        {
                            FaLeistung = _faLeistungHaushalt,
                            BaPerson = _baPersons[0],
                            DatumVon = new DateTime(2008, 01, 01),
                            Creator = CREATOR,
                            Created = new DateTime(2008, 01, 01),
                            Modifier = CREATOR,
                            Modified = new DateTime(2008, 01, 01),
                            Unterstuetzt = true
                        },
                        new WshHaushaltPerson
                        {
                            FaLeistung = _faLeistungHaushalt,
                            BaPerson = _baPersons[1],
                            DatumVon = new DateTime(2010, 02, 01),
                            DatumBis = new DateTime(2010, 02, 28),
                            Creator = CREATOR,
                            Created = new DateTime(2010, 01, 01),
                            Modifier = CREATOR,
                            Modified = new DateTime(2010, 01, 01),
                            Unterstuetzt = true
                        },
                    };

            _haushaltPersonen.ForEach(repository.ApplyChanges);
            unitOfWork.SaveChanges();

            //Wohnsituation
            IRepository<BaWohnsituation> repositoryWohnsituation = UnitOfWork.GetRepository<BaWohnsituation>(unitOfWork);
            _baWohnsituation = new BaWohnsituation
            {
                DatumVon = DateTime.Today,
                WohnsituationCode = 2

            };
            repositoryWohnsituation.ApplyChanges(_baWohnsituation);
            unitOfWork.SaveChanges();

            //WohnsituationPerson
            IRepository<BaWohnsituationPerson> repositoryWohnsituationPerson = UnitOfWork.GetRepository<BaWohnsituationPerson>(unitOfWork);
            _baWohnsituationPerson = new BaWohnsituationPerson
            {
                BaWohnsituationID = _baWohnsituation.BaWohnsituationID,
                BaPersonID = _faLeistungHaushalt.BaPersonID
            };
            repositoryWohnsituationPerson.ApplyChanges(_baWohnsituationPerson);
            unitOfWork.SaveChanges();
            return _haushaltPersonen;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            // Delete the temporary test objects
            // Delete the Haushalt-Definition
            if (_haushaltPersonen != null)
            {
                IRepository<WshHaushaltPerson> repository = UnitOfWork.GetRepository<WshHaushaltPerson>(unitOfWork);
                _haushaltPersonen.ForEach(x => x.MarkAsDeleted());
                _haushaltPersonen.ForEach(repository.ApplyChanges);
                unitOfWork.SaveChanges();

                var query = from x in repository
                            where x.FaLeistungID == _faLeistungHaushalt.FaLeistungID
                            select x;
                var list = query.ToList();
                list.ForEach(x => x.MarkAsDeleted());
                list.ForEach(repository.ApplyChanges);

                unitOfWork.SaveChanges();
            }


            if (_baWohnsituationPerson != null)
            {
                IRepository<BaWohnsituationPerson> repositoryWohnsituationPerson = UnitOfWork.GetRepository<BaWohnsituationPerson>(unitOfWork);
                _baWohnsituationPerson.MarkAsDeleted();
                repositoryWohnsituationPerson.ApplyChanges(_baWohnsituationPerson);
                unitOfWork.SaveChanges();
            }

            if (_baWohnsituation != null)
            {
                IRepository<BaWohnsituation> repositoryWohnsituation = UnitOfWork.GetRepository<BaWohnsituation>(unitOfWork);
                _baWohnsituation.MarkAsDeleted();
                repositoryWohnsituation.ApplyChanges(_baWohnsituation);
                unitOfWork.SaveChanges();
            }
            _personHelper.Delete(unitOfWork);
            _leistungHelper.Delete(unitOfWork);

            unitOfWork.SaveChanges();
        }

        #endregion

        #endregion
    }
}