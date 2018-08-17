using System;
using System.Collections.Generic;

using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class FaZeitachseHelper : BaseHelper
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        public const string STICHWORT_DELETED = "DELETED";

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly FaLeistungHelper _faLeistungHelper = new FaLeistungHelper();

        #endregion

        #region Private Fields

        private List<FaAktennotizen> _faAktennotizenEntities;
        private List<FaDokumente> _faDokumenteEntities;
        private List<XTask> _xTaskEntities;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public BaPerson CreateHauptachseData(IUnitOfWork unitOfWork)
        {
            var faLeistung = _faLeistungHelper.Create(unitOfWork, 2, 200);

            var today = DateTime.Today;

            // Korrespondenz
            var faDokumenteRepo = UnitOfWork.GetRepository<FaDokumente>(unitOfWork);
            _faDokumenteEntities = new List<FaDokumente>
                {
                    new FaDokumente
                    {
                        DatumErstellung = new DateTime(today.Year, today.Month, 1),
                        FaLeistung = faLeistung,
                        XUser_Absender = faLeistung.XUser,
                        Stichwort = "Korrespondenz A",
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now
                    },
                    new FaDokumente
                    {
                        DatumErstellung = new DateTime(today.Year, today.Month, 5),
                        XUser_Absender = faLeistung.XUser,
                        FaLeistung = faLeistung,
                        Stichwort = STICHWORT_DELETED,
                        IsDeleted = true,
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now
                    },
                };

            _faDokumenteEntities.ForEach(faDokumenteRepo.ApplyChanges);
            unitOfWork.SaveChanges();
            _faDokumenteEntities.ForEach(x => x.AcceptChanges());

            // Besprechungen
            var faAktennotizenRepo = UnitOfWork.GetRepository<FaAktennotizen>(unitOfWork);
            _faAktennotizenEntities = new List<FaAktennotizen>
                {
                    new FaAktennotizen
                    {
                        Datum = new DateTime(today.Year - 1, today.Month, 1),
                        FaLeistung = faLeistung,
                        XUser = faLeistung.XUser,
                        Stichwort = "Besprechung A",
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now
                    },
                    new FaAktennotizen
                    {
                        Datum = new DateTime(today.Year - 1, today.Month, 10),
                        FaLeistung = faLeistung,
                        XUser = faLeistung.XUser,
                        Stichwort = STICHWORT_DELETED,
                        IsDeleted = true,
                        Creator = CREATOR,
                        Created = DateTime.Now,
                        Modifier = CREATOR,
                        Modified = DateTime.Now
                    }
                };

            _faAktennotizenEntities.ForEach(faAktennotizenRepo.ApplyChanges);
            unitOfWork.SaveChanges();
            _faAktennotizenEntities.ForEach(x => x.AcceptChanges());

            // Pendenzen
            var xTaskRepo = UnitOfWork.GetRepository<XTask>(unitOfWork);
            _xTaskEntities = new List<XTask>
                {
                    new XTask
                    {
                        BaPerson = faLeistung.BaPerson,
                        StartDate = today.AddMonths(2),
                        ExpirationDate = today.AddMonths(3),
                        Subject = "Pendenz A",
                        CreateDate = DateTime.Now,
                        TaskStatusCode = (int)LOVsGenerated.TaskStatus.InBearbeitung
                    },
                    new XTask
                    {
                        BaPerson = faLeistung.BaPerson,
                        StartDate = today.AddYears(1),
                        Subject = "Pendenz B",
                        CreateDate = DateTime.Now,
                        TaskStatusCode = (int)LOVsGenerated.TaskStatus.Pendent
                    }
                };

            _xTaskEntities.ForEach(xTaskRepo.ApplyChanges);
            unitOfWork.SaveChanges();
            _xTaskEntities.ForEach(x => x.AcceptChanges());

            return faLeistung.BaPerson;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            var faDokumenteRepo = UnitOfWork.GetRepository<FaDokumente>(unitOfWork);
            var faAktennotizenRepo = UnitOfWork.GetRepository<FaAktennotizen>(unitOfWork);

            // Delete the temporary test objects
            _faDokumenteEntities.ForEach(x => x.MarkAsDeleted());
            _faDokumenteEntities.ForEach(faDokumenteRepo.ApplyChanges);

            _faAktennotizenEntities.ForEach(x => x.MarkAsDeleted());
            _faAktennotizenEntities.ForEach(faAktennotizenRepo.ApplyChanges);

            _faLeistungHelper.Delete(unitOfWork);
        }

        #endregion

        #endregion
    }
}