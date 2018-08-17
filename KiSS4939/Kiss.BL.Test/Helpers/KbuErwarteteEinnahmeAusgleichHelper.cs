using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiss.Interfaces.BL;
using Kiss.Model;
using Kiss.Infrastructure.Constant;

namespace Kiss.BL.Test.Helpers
{
    class KbuErwarteteEinnahmeAusgleichHelper
    {
        private readonly KbuBelegHelper _belegHelper = new KbuBelegHelper();
        private readonly BaPersonHelper _personHelper = new BaPersonHelper();

        private List<KbuBeleg> _listBeleg = new List<KbuBeleg>();
        private List<KbuBelegPosition> _listBelegPosition = new List<KbuBelegPosition>();
        private const string CREATOR = "UnitTester";


        public KbuBeleg CreateAusgleich(IUnitOfWork unitOfWork, WshPosition[] position, decimal[] betrag)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            //var repositoryAusgleich = UnitOfWork.GetRepository<KbuErwarteteEinnahmeAusgleich>(unitOfWork);
            var repositoryBeleg = UnitOfWork.GetRepository<KbuBeleg>(unitOfWork);
            var repositoryBelegPosition = UnitOfWork.GetRepository<KbuBelegPosition>(unitOfWork);
            var person = _personHelper.Create(unitOfWork);
            //var ausgleiche = new List<KbuErwarteteEinnahmeAusgleich>();

            var beleg = new KbuBeleg
            {
                BelegDatum = DateTime.Today,
                KbuBelegartCode = (int)LOVsGenerated.KbuBelegart.Einzahlung,
                KbuBelegKreisCode = (int)LOVsGenerated.KbuBelegKreis.EinzahlungenKISS,
                KbuBelegstatusCode = (int)LOVsGenerated.KbuBelegstatus.Freigegeben,
                KbuProzessartCode = (int)LOVsGenerated.KbuProzessart.WSH,
                Text = "Testbeleg",
                //KbuZahlungseingangID ToDo, noch nicht nötig
                ValutaDatum = DateTime.Today,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
            };
            _listBeleg.Add(beleg);

            repositoryBeleg.ApplyChanges(beleg);
            unitOfWork.SaveChanges();
            beleg.AcceptChanges();


            for (int i = 0; i < Math.Min(position.Length, betrag.Length); i++)
            {
                var belegPosition = new KbuBelegPosition
                {
                    WshPosition = position[i],
                    BetragBrutto = betrag[i],
                    BaPersonID = person.BaPersonID,
                    FaLeistungID = position[i].FaLeistungID,
                    HauptPosition = false,
                    BetragNetto = 0m,
                    KbuBeleg = beleg,
                    KbuKontoID = position[i].KbuKontoID,
                    PositionImBeleg = i+2,
                    VerwPeriodeVon = position[i].VerwPeriodeVon,
                    VerwPeriodeBis = position[i].VerwPeriodeBis,
                    SollHaben = "H",
                    Text = position[i].Text,
                    Creator = CREATOR,
                    Created = DateTime.Now,
                    Modifier = CREATOR,
                    Modified = DateTime.Now,
                };
                _listBelegPosition.Add(belegPosition);

                repositoryBelegPosition.ApplyChanges(belegPosition);
                unitOfWork.SaveChanges();
                belegPosition.AcceptChanges();


                //var ausgleich = new KbuErwarteteEinnahmeAusgleich
                //{
                //    WshPosition = position[i],
                //    Betrag = betrag[i],
                //    Creator = CREATOR,
                //    Created = DateTime.Now,
                //    Modifier = CREATOR,
                //    Modified = DateTime.Now,
                //};
                //_listAusgleich.Add(ausgleich);

                //repositoryAusgleich.ApplyChanges(ausgleich);
                //unitOfWork.SaveChanges();
                //ausgleich.AcceptChanges();

                //ausgleiche.Add(ausgleich);
            }
            return beleg;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            //_listAusgleich.ForEach(x => DeleteAusgleich(unitOfWork, x));
            //unitOfWork.SaveChanges();
            //_listAusgleich.ForEach(x => x.AcceptChanges());

            _listBelegPosition.ForEach(x => DeleteBelegPosition(unitOfWork, x));
            unitOfWork.SaveChanges();
            _listBelegPosition.ForEach(x => x.AcceptChanges());

            _listBeleg.ForEach(x => DeleteBeleg(unitOfWork, x));
            unitOfWork.SaveChanges();
            _listBeleg.ForEach(x => x.AcceptChanges());
        }

        //private static void DeleteAusgleich(IUnitOfWork unitOfWork, KbuErwarteteEinnahmeAusgleich position)
        //{
        //    var repository = UnitOfWork.GetRepository<KbuErwarteteEinnahmeAusgleich>(unitOfWork);
        //    var entity = (from x in repository
        //                  where x.KbuErwarteteEinnahmeAusgleichID == position.KbuErwarteteEinnahmeAusgleichID
        //                  select x).Single();
        //    entity.MarkAsDeleted();
        //    repository.ApplyChanges(entity);
        //}

        private static void DeleteBelegPosition(IUnitOfWork unitOfWork, KbuBelegPosition position)
        {
            var repository = UnitOfWork.GetRepository<KbuBelegPosition>(unitOfWork);
            var entity = (from x in repository
                          where x.KbuBelegPositionID == position.KbuBelegPositionID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        private static void DeleteBeleg(IUnitOfWork unitOfWork, KbuBeleg position)
        {
            var repository = UnitOfWork.GetRepository<KbuBeleg>(unitOfWork);
            var entity = (from x in repository
                          where x.KbuBelegID == position.KbuBelegID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }
    }
}
