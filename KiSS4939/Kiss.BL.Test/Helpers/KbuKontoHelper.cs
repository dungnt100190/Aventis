using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class KbuKontoHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<KbuKonto> _list = new List<KbuKonto>();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public KbuKonto Create(IUnitOfWork unitOfWork)
        {
            return Create(unitOfWork, "100", "GBL", LOVsGenerated.KbuKontoklasse.Aufwand);
        }

        public KbuKonto Create(
            IUnitOfWork unitOfWork,
            string kontoNr,
            string name,
            LOVsGenerated.KbuKontoklasse kontoklasseCode,
            LOVsGenerated.KbuKontoTyp kontoTypCode = LOVsGenerated.KbuKontoTyp.GBL)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuKonto>(unitOfWork);

            // Konto
            var konto = new KbuKonto
            {
                KontoNr = kontoNr,
                Name = name,
                Quoting = true,
                WshSplittingartCode = (int)LOVsGenerated.WshSplittingart.Taggenau,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
                KbuKontoklasseCode = (int)kontoklasseCode,
            };

            _list.Add(konto);

            repository.ApplyChanges(konto);
            unitOfWork.SaveChanges();
            konto.AcceptChanges();

            // Kategorien
            var kontoKategorieAusgabe = new WshKategorie_KbuKonto
            {
                KbuKonto = konto,
                KbuKontoID = konto.KbuKontoID,
                WshKategorieID = (int)LOVsGenerated.WshKategorie.Ausgabe,
                NurMitSpezialrecht = false,
                Creator = CREATOR,
                Created = new DateTime(2010, 01, 01),
                Modifier = CREATOR,
                Modified = new DateTime(2010, 01, 01),
            };
            var repositoryKontoKat = UnitOfWork.GetRepository<WshKategorie_KbuKonto>(unitOfWork);
            repositoryKontoKat.ApplyChanges(kontoKategorieAusgabe);
            unitOfWork.SaveChanges();

            var kontoKategorieEinnahme = new WshKategorie_KbuKonto
            {
                KbuKonto = konto,
                KbuKontoID = konto.KbuKontoID,
                WshKategorieID = (int)LOVsGenerated.WshKategorie.Einnahme,
                NurMitSpezialrecht = false,
                Creator = CREATOR,
                Created = new DateTime(2010, 01, 01),
                Modifier = CREATOR,
                Modified = new DateTime(2010, 01, 01),
            };
            repositoryKontoKat.ApplyChanges(kontoKategorieEinnahme);
            unitOfWork.SaveChanges();

            var kontoKategorieVerrechung = new WshKategorie_KbuKonto
            {
                KbuKonto = konto,
                KbuKontoID = konto.KbuKontoID,
                WshKategorieID = (int)LOVsGenerated.WshKategorie.Verrechnung,
                NurMitSpezialrecht = false,
                Creator = CREATOR,
                Created = new DateTime(2010, 01, 01),
                Modifier = CREATOR,
                Modified = new DateTime(2010, 01, 01),
            };
            repositoryKontoKat.ApplyChanges(kontoKategorieVerrechung);
            unitOfWork.SaveChanges();

            var kontoKategorieRueckerstattung = new WshKategorie_KbuKonto
            {
                KbuKonto = konto,
                KbuKontoID = konto.KbuKontoID,
                WshKategorieID = (int)LOVsGenerated.WshKategorie.Rueckerstattung,
                NurMitSpezialrecht = false,
                Creator = CREATOR,
                Created = new DateTime(2010, 01, 01),
                Modifier = CREATOR,
                Modified = new DateTime(2010, 01, 01),
            };
            repositoryKontoKat.ApplyChanges(kontoKategorieRueckerstattung);
            unitOfWork.SaveChanges();

            // Kontoattribut
            var kontoAttribut = new WshKontoAttribut
            {
                KbuKonto = konto,
                KbuKontoID = konto.KbuKontoID,
                IstGrundbudgetAktiv = true,
                IstLeistungWsh = true,
                IstLeistungWshStationaer = true,
                IstMonatsbudgetAktiv = true,
                SysEditModeCode_BetrifftPerson = (int)LOVsGenerated.SysEditMode.Normal,
                Creator = CREATOR,
                Created = new DateTime(2001, 01, 01),
                Modifier = CREATOR,
                Modified = new DateTime(2001, 01, 01),
            };
            var repositoryKontoAttr = UnitOfWork.GetRepository<WshKontoAttribut>(unitOfWork);
            repositoryKontoAttr.ApplyChanges(kontoAttribut);
            unitOfWork.SaveChanges();

            // Kontotyp
            var kontoTyp = new KbuKonto_KbuKontoTyp
            {
                KbuKonto = konto,
                KbuKontoTypCode = (int)kontoTypCode,
                Creator = CREATOR,
                Created = new DateTime(2001, 01, 01),
                Modifier = CREATOR,
                Modified = new DateTime(2001, 01, 01),
            };
            var repositoryKontoTyp = UnitOfWork.GetRepository<KbuKonto_KbuKontoTyp>(unitOfWork);
            repositoryKontoTyp.ApplyChanges(kontoTyp);
            unitOfWork.SaveChanges();

            return konto;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _list.ForEach(x => DeleteKonto(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());
        }

        #endregion

        #region Private Static Methods

        private static void DeleteKonto(IUnitOfWork unitOfWork, KbuKonto konto)
        {
            DeleteKontoTyp(unitOfWork, konto.KbuKontoID);
            DeleteKontoAttribut(unitOfWork, konto.KbuKontoID);
            DeleteKontoKategorie(unitOfWork, konto.KbuKontoID);

            var repository = UnitOfWork.GetRepository<KbuKonto>(unitOfWork);

            var entity = (from x in repository
                          where x.KbuKontoID == konto.KbuKontoID
                          select x).Single();

            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        private static void DeleteKontoAttribut(IUnitOfWork unitOfWork, int kbuKontoID)
        {
            var repository = UnitOfWork.GetRepository<WshKontoAttribut>(unitOfWork);

            var list = repository.Where(x => x.KbuKontoID == kbuKontoID).ToList();

            list.ForEach(x => x.MarkAsDeleted());
            list.ForEach(repository.ApplyChanges);

            unitOfWork.SaveChanges();
        }

        private static void DeleteKontoKategorie(IUnitOfWork unitOfWork, int kbuKontoID)
        {
            var repository = UnitOfWork.GetRepository<WshKategorie_KbuKonto>(unitOfWork);

            var list = repository.Where(x => x.KbuKontoID == kbuKontoID).ToList();

            list.ForEach(x => x.MarkAsDeleted());
            list.ForEach(repository.ApplyChanges);

            unitOfWork.SaveChanges();
        }

        private static void DeleteKontoTyp(IUnitOfWork unitOfWork, int kbuKontoID)
        {
            var repository = UnitOfWork.GetRepository<KbuKonto_KbuKontoTyp>(unitOfWork);

            var list = repository.Where(x => x.KbuKontoID == kbuKontoID).ToList();

            foreach (var kontoTyp in list)
            {
                kontoTyp.MarkAsDeleted();
                repository.ApplyChanges(kontoTyp);
            }

            unitOfWork.SaveChanges();
        }

        #endregion

        #endregion
    }
}