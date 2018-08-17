using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    internal class KbuBelegHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly KbuKontoHelper _kontoHelper = new KbuKontoHelper();
        private readonly List<KbuBeleg> _list = new List<KbuBeleg>();
        private readonly WshPositionHelper _positionHelper = new WshPositionHelper();
        private readonly BaZahlungswegHelper _zahlungswegHelper = new BaZahlungswegHelper();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public KbuBeleg Create(IUnitOfWork unitOfWork)
        {
            WshPosition position = _positionHelper.Create(unitOfWork);

            IRepository<KbuBeleg> repositoryBeleg = UnitOfWork.GetRepository<KbuBeleg>(unitOfWork);

            var beleg = new KbuBeleg
            {
                BelegDatum = DateTime.Now,
                ValutaDatum = DateTime.Now,
                Text = "BuchungsText Unit",
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
            };

            repositoryBeleg.ApplyChanges(beleg);
            unitOfWork.SaveChanges();
            beleg.AcceptChanges();

            _list.Add(beleg);
            return beleg;
        }

        /// <summary>
        /// Kreiert einen freigegebenen Beleg mit einer Hauptposition.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public KbuBeleg CreateBelegFreigegeben(IUnitOfWork unitOfWork)
        {
            WshPosition position = _positionHelper.Create(unitOfWork);

            position.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung;
            var repositoryPosition = UnitOfWork.GetRepository<WshPosition>(unitOfWork);
            repositoryPosition.ApplyChanges(position);
            unitOfWork.SaveChanges();


            IRepository<KbuBeleg> repositoryBeleg = UnitOfWork.GetRepository<KbuBeleg>(unitOfWork);

            var beleg = new KbuBeleg
            {
                BelegDatum = DateTime.Today - new TimeSpan(10, 0, 0, 0),
                //-10 Tage
                ValutaDatum = DateTime.Today - new TimeSpan(5, 0, 0, 0),
                // -5 Tage
                KbuBelegstatusCode = (int)LOVsGenerated.KbuBelegstatus.Freigegeben,
                KbuBelegartCode = (int)LOVsGenerated.KbuBelegart.Auszahlung,
                Text = "BuchungsText Unit",
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
            };

            repositoryBeleg.ApplyChanges(beleg);
            unitOfWork.SaveChanges();
            beleg.AcceptChanges();
            _list.Add(beleg);

            //Hauptpositon
            KbuKonto kbuKonto = _kontoHelper.Create(unitOfWork);
            IRepository<KbuBelegPosition> repositoryBelegPosition = UnitOfWork.GetRepository<KbuBelegPosition>(unitOfWork);
            var hauptPosition = new KbuBelegPosition
            {
                KbuBeleg = beleg,
                KbuBelegID = beleg.KbuBelegID,
                KbuKonto = kbuKonto,
                KbuKontoID = kbuKonto.KbuKontoID,
                HauptPosition = true,
                SollHaben = "H",
                Text = "UnitTest",
                BetragBrutto = 23,
                BetragNetto = 34,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
            };
            repositoryBelegPosition.ApplyChanges(hauptPosition);
            unitOfWork.SaveChanges();

            //Nebenposition
            var nebenPosition = new KbuBelegPosition
            {
                KbuBeleg = beleg,
                KbuBelegID = beleg.KbuBelegID,
                KbuKonto = kbuKonto,
                KbuKontoID = kbuKonto.KbuKontoID,
                WshPositionID = position.WshPositionID,
                HauptPosition = false,
                SollHaben = "S",
                Text = "UnitTest",
                BetragBrutto = 23,
                BetragNetto = 34,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
            };
            repositoryBelegPosition.ApplyChanges(nebenPosition);
            unitOfWork.SaveChanges();

            //KbuBelegKreditor
            BaZahlungsweg zahlungsweg = _zahlungswegHelper.Create(unitOfWork);
            var kreditor = new KbuBelegKreditor
            {
                KbuBelegID = beleg.KbuBelegID,
                KbuBeleg = beleg,
                BaZahlungsweg = zahlungsweg,
                BaZahlungswegID = zahlungsweg.BaZahlungswegID,
                MitteilungZeile1 = "",
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
            };
            IRepository<KbuBelegKreditor> repositoryBelKreditor = UnitOfWork.GetRepository<KbuBelegKreditor>(unitOfWork);
            repositoryBelKreditor.ApplyChanges(kreditor);
            unitOfWork.SaveChanges();

            return beleg;
        }

        /// <summary>
        /// Kreiert einen verbuchten Beleg mit einer Hauptposition.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public KbuBeleg CreateBelegVerbucht(IUnitOfWork unitOfWork)
        {
            var beleg = CreateBelegFreigegeben(unitOfWork);
            beleg.KbuBelegstatusCode = (int)LOVsGenerated.KbuBelegstatus.Verbucht;
            beleg.BelegNr = 1234; // ToDo: Belegnummer lösen
            beleg.KbuBelegKreisCode = (int)LOVsGenerated.KbuBelegKreis.AuszahlungenKISS;

            var repository = UnitOfWork.GetRepository<KbuBeleg>(unitOfWork);
            repository.ApplyChanges(beleg);
            unitOfWork.SaveChanges();

            return beleg;
        }

        public List<KbuBeleg> CreateBelegeVerbucht(IUnitOfWork unitOfWork, int count)
        {
            var belege = new List<KbuBeleg>();
            for (int i = 0; i < count; i++)
            {
                belege.Add(CreateBelegVerbucht(unitOfWork));
            }
            return belege;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            _list.ForEach(x => DeleteBeleg(unitOfWork, x));
            unitOfWork.SaveChanges();

            _positionHelper.Delete(unitOfWork);
            _kontoHelper.Delete(unitOfWork);

            _zahlungswegHelper.Delete(unitOfWork);
        }

        #endregion

        #region Private Static Methods

        public static void DeleteBeleg(IUnitOfWork unitOfWork, KbuBeleg beleg)
        {
            DeleteBelegPositionen(unitOfWork, beleg.KbuBelegID);
            DeleteBelegKreditor(unitOfWork, beleg.KbuBelegID);
            IRepository<KbuBeleg> repository = UnitOfWork.GetRepository<KbuBeleg>(unitOfWork);
            KbuBeleg entity = (from x in repository
                               where x.KbuBelegID == beleg.KbuBelegID
                               select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        private static void DeleteBelegKreditor(IUnitOfWork unitOfWork, int kbuBelegId)
        {
            IRepository<KbuBelegKreditor> repositoryBelKreditor = UnitOfWork.GetRepository<KbuBelegKreditor>(unitOfWork);
            IQueryable<KbuBelegKreditor> query = repositoryBelKreditor.Where(x => x.KbuBelegID == kbuBelegId);
            foreach (KbuBelegKreditor kred in query)
            {
                kred.MarkAsDeleted();
                repositoryBelKreditor.ApplyChanges(kred);
            }
            unitOfWork.SaveChanges();
        }

        private static void DeleteBelegPositionen(IUnitOfWork unitOfWork, int kbuBelegId)
        {
            IRepository<KbuBelegPosition> repositoryBelegPosition = UnitOfWork.GetRepository<KbuBelegPosition>(unitOfWork);
            IQueryable<KbuBelegPosition> query = repositoryBelegPosition.Where(x => x.KbuBelegID == kbuBelegId);
            foreach (KbuBelegPosition pos in query)
            {
                pos.MarkAsDeleted();
                repositoryBelegPosition.ApplyChanges(pos);
            }
            unitOfWork.SaveChanges();
        }

        #endregion

        #endregion
    }
}