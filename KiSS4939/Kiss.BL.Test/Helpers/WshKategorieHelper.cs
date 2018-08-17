using System;
using System.Collections.Generic;

using Kiss.BL.Wsh;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class WshKategorieHelper
    {
        #region Fields

        #region Private Fields

        private bool _filled;
        private List<WshKategorie> _list;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public void ClearWshKategorieMock(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            if (TestUtils.IsDbTest(unitOfWork) || _list == null)
            {
                return;
            }

            var repository = UnitOfWork.GetRepository<WshKategorie>(unitOfWork);

            _list.ForEach(x => x.MarkAsDeleted());
            _list.ForEach(repository.ApplyChanges);
            unitOfWork.SaveChanges();

            _filled = false;
        }

        public void FillWshKategorieMock(IUnitOfWork unitOfWork)
        {
            if (TestUtils.IsDbTest(unitOfWork) || _filled)
            {
                return;
            }

            var creator = "UnitTester";
            var time = DateTime.Now;
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var repository = UnitOfWork.GetRepository<WshKategorie>(unitOfWork);

            _list = new List<WshKategorie>
            {
                new WshKategorie
                {
                    Name = "Ausgabe",
                    WshKategorieID = 1,
                    SortKey = 1,
                    IstAbzug = false,
                    IstAktiv = true,
                    Creator = creator,
                    Created = time,
                    Modifier = creator,
                    Modified = time,
                },

                new WshKategorie
                {
                    Name = "Einnahme",
                    WshKategorieID = 2,
                    SortKey = 2,
                    IstAbzug = false,
                    IstAktiv = true,
                    Creator = creator,
                    Created = time,
                    Modifier = creator,
                    Modified = time,
                },

                new WshKategorie
                {
                    Name = "Sanktion",
                    WshKategorieID = 3,
                    SortKey = 3,
                    IstAbzug = true,
                    IstAktiv = true,
                    Creator = creator,
                    Created = time,
                    Modifier = creator,
                    Modified = time,
                },

                new WshKategorie
                {
                    Name = "Verrechnung",
                    WshKategorieID = 4,
                    SortKey = 4,
                    IstAbzug = true,
                    IstAktiv = true,
                    Creator = creator,
                    Created = time,
                    Modifier = creator,
                    Modified = time,
                },

                new WshKategorie
                {
                    Name = "Rückerstattung",
                    WshKategorieID = 5,
                    SortKey = 5,
                    IstAbzug = true,
                    IstAktiv = true,
                    Creator = creator,
                    Created = time,
                    Modifier = creator,
                    Modified = time,
                },

                new WshKategorie
                {
                    Name = "Abzahlung",
                    WshKategorieID = 6,
                    SortKey = 6,
                    IstAbzug = false,
                    IstAktiv = false,
                    Creator = creator,
                    Created = time,
                    Modifier = creator,
                    Modified = time,
                },

                new WshKategorie
                {
                    Name = "Kürzung",
                    WshKategorieID = 7,
                    SortKey = 7,
                    IstAbzug = false,
                    IstAktiv = false,
                    Creator = creator,
                    Created = time,
                    Modifier = creator,
                    Modified = time,
                },

                new WshKategorie
                {
                    Name = "Vermögen",
                    WshKategorieID = 8,
                    SortKey = 8,
                    IstAbzug = false,
                    IstAktiv = false,
                    Creator = creator,
                    Created = time,
                    Modifier = creator,
                    Modified = time,
                },

                new WshKategorie
                {
                    Name = "Vorabzug",
                    WshKategorieID = 9,
                    SortKey = 9,
                    IstAbzug = false,
                    IstAktiv = false,
                    Creator = creator,
                    Created = time,
                    Modifier = creator,
                    Modified = time,
                },

                new WshKategorie
                {
                    Name = "Unbekannt",
                    WshKategorieID = 100,
                    SortKey = 100,
                    IstAbzug = false,
                    IstAktiv = false,
                    Creator = creator,
                    Created = time,
                    Modifier = creator,
                    Modified = time,
                },
            };

            _list.ForEach(repository.ApplyChanges);
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());

            _filled = true;
        }

        public WshKategorie GetWshKategorie(IUnitOfWork unitOfWork, LOVsGenerated.WshKategorie kategorieCode)
        {
            if (!_filled)
            {
                FillWshKategorieMock(unitOfWork);
            }

            if (_list == null)
            {
                var service = Container.Resolve<WshKategorieService>();
                _list = service.GetKategorien(unitOfWork);
            }

            return _list.Find(x => x.WshKategorieID == (int)kategorieCode);
        }

        #endregion

        #endregion
    }
}