using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Kiss.BL.KissSystem;
using Kiss.BL.Vm.Validation;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Infrastructure.IoC;
using Kiss.Model;

namespace Kiss.BL.Vm
{
    /// <summary>
    /// Service to manage a VmPosition.
    /// </summary>
    [UsableBy(
        typeof(VmPositionDTOService),
        typeof(VmKlientenbudgetService),
        ClassNames = new[]
        {
            "Kiss.BL.Test.Vm.VmPositionServiceTest"
        })]
    internal class VmPositionService : ServiceCRUDBase<VmPosition>
    {
        #region Constructors

        private VmPositionService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public KissServiceResult DeleteByVmKlientenbudgetId(IUnitOfWork unitOfWork, int vmKlientenbudgetId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var result = KissServiceResult.Ok();

            var positionen = GetByVmKlientenbudgetId(unitOfWork, vmKlientenbudgetId);

            foreach (var position in positionen)
            {
                result += DeleteData(unitOfWork, position, false);
            }

            unitOfWork.SaveChanges();

            return result;
        }

        public override KissServiceResult DeleteData(IUnitOfWork unitOfWork, VmPosition dataToDelete, bool saveChanges = true)
        {
            var result = KissServiceResult.Ok();

            using (var ts = new TransactionScope())
            {
                unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
                var posRepository = UnitOfWork.GetRepository<VmPosition>(unitOfWork);
                var refreshedDataToDelete = posRepository.SingleOrDefault(x => x.VmPositionID == dataToDelete.VmPositionID);

                if (refreshedDataToDelete != null)
                {
                    result = base.DeleteData(unitOfWork, refreshedDataToDelete, saveChanges);
                }

                if(result.IsOk)
                {
                    dataToDelete.MarkAsUnchanged();
                }

                ts.Complete();
            }

            return result;
        }

        public override VmPosition GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var repoVmPosition = UnitOfWork.GetRepository<VmPosition>(unitOfWork);

            var result = repoVmPosition.SingleOrDefault(x => x.VmPositionID == id);

            if (result != null)
            {
                result.StartTracking();
            }

            return result;
        }

        public IList<VmPosition> GetByVmKlientenbudgetId(IUnitOfWork unitOfWork, int vmKlientenbudgetId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var repoVmPosition = UnitOfWork.GetRepository<VmPosition>(unitOfWork);

            var result = repoVmPosition
                .Include(x => x.VmPositionsart)
                .Where(x => x.VmKlientenbudgetID == vmKlientenbudgetId)
                .OrderBy(x => x.SortKey)
                .ThenBy(x => x.VmPositionsart.SortKey);

            foreach (var vmPosition in result)
            {
                vmPosition.StartTracking();
            }

            return result.ToList();
        }

        /// <summary>
        /// Daten einer Position importieren
        /// </summary>
        /// <param name="unitOfWork">Die <see cref="IUnitOfWork"/></param>
        /// <param name="budget">Das Budget für welches die Daten importiert werden müssen</param>
        /// <param name="position">Die Position für welche die Daten importiert werden müssen</param>
        /// <returns><see cref="KissServiceResult"/></returns>
        public KissServiceResult ImportData(IUnitOfWork unitOfWork, VmKlientenbudget budget, VmPosition position)
        {
            var result = KissServiceResult.Ok();

            if (position == null)
            {
                return result;
            }

            var positionsartTyp = position.VmPositionsart.VmPositionsartTypEnum;

            switch (positionsartTyp)
            {
                case LOVsGenerated.VmPositionsartTyp.VermKassePc:
                case LOVsGenerated.VmPositionsartTyp.VermBetriebskonto:
                case LOVsGenerated.VmPositionsartTyp.VermDepotBs:
                    // Werte aus Mandatsbuchhaltung/Bilanz/Erfolg holen
                    result += ImportDataSaldoBilanzErfolg(unitOfWork, budget, position, positionsartTyp);
                    break;

                case LOVsGenerated.VmPositionsartTyp.AusgKkPraemienKvg:
                case LOVsGenerated.VmPositionsartTyp.AusgKkPraemienVvg:
                    // Werte aus Basis/Gesundheit/KVG oder VVG holen
                    result += ImportDataKkPraemien(unitOfWork, budget, position, positionsartTyp);
                    break;

                default:
                    return new KissServiceResult(ServiceResultType.Error, "Diese Position kann nicht importiert werden.");
            }

            if (result.IsOk)
            {
                position.IstImportiert = true;
            }

            return result;
        }

        public override KissServiceResult ValidateInMemory(VmPosition dataToValidate)
        {
            var serviceResult = VmPositionValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #region Private Static Methods

        private static KissServiceResult ImportDataKkPraemien(
            IUnitOfWork unitOfWork,
            VmKlientenbudget budget,
            VmPosition position,
            LOVsGenerated.VmPositionsartTyp positionsartTyp)
        {
            var result = KissServiceResult.Ok();

            bool istKvg = positionsartTyp == LOVsGenerated.VmPositionsartTyp.AusgKkPraemienKvg;

            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repositoryLeistung = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);

            var kvgVvgInfos = (from lei in repositoryLeistung
                               let gesundheit = lei.BaPerson.BaGesundheit.FirstOrDefault()
                               where lei.FaLeistungID == budget.FaLeistungID
                               select new
                               {
                                   Praemie = istKvg ? gesundheit.KVGPraemie : gesundheit.VVGPraemie,
                                   Krankenkasse = istKvg ? gesundheit.BaInstitution_Kvg.Name : gesundheit.BaInstitution_Vvg.Name,
                               }).SingleOrDefault();

            if (kvgVvgInfos == null)
            {
                position.BetragMonatlich = 0;
                position.Bemerkung = "";
            }
            else
            {
                position.BetragMonatlich = kvgVvgInfos.Praemie;
                position.Bemerkung = kvgVvgInfos.Krankenkasse;
            }

            return result;
        }

        private static KissServiceResult ImportDataSaldoBilanzErfolg(
            IUnitOfWork unitOfWork,
            VmKlientenbudget budget,
            VmPosition position,
            LOVsGenerated.VmPositionsartTyp positionsartTyp)
        {
            var result = KissServiceResult.Ok();

            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repositoryFaLeistung = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);
            var repositoryFbKonto = UnitOfWork.GetRepository<FbKonto>(unitOfWork);
            var repositoryFbPeriode = UnitOfWork.GetRepository<FbPeriode>(unitOfWork);
            var repositoryFbBuchung = UnitOfWork.GetRepository<FbBuchung>(unitOfWork);

            var baPersonId = repositoryFaLeistung.Where(x => x.FaLeistungID == budget.FaLeistungID).Select(x => x.BaPersonID).SingleOrDefault();

            var periodeId = (from prd in repositoryFbPeriode
                             where prd.BaPersonID == baPersonId
                             where prd.PeriodeVon <= DateTime.Today
                             where prd.PeriodeBis >= DateTime.Today
                             orderby prd.PeriodeVon descending
                             select prd.FbPeriodeID).FirstOrDefault();

            // Es gibt keine aktuelle Periode
            if (periodeId <= 0)
            {
                position.Saldo = null;
                position.DatumSaldoPer = DateTime.Today;
                return result;
            }

            // SaldoGruppeName je nach PositionsartTyp definieren
            string saldoGruppeNameKeyPath;
            string saldoGruppeNameDefault;
            switch (positionsartTyp)
            {
                case LOVsGenerated.VmPositionsartTyp.VermKassePc:
                    saldoGruppeNameKeyPath = @"System\Fibu\SaldoGruppeName\KassePc";
                    saldoGruppeNameDefault = "Kasse + PC";
                    break;
                case LOVsGenerated.VmPositionsartTyp.VermBetriebskonto:
                    saldoGruppeNameKeyPath = @"System\Fibu\SaldoGruppeName\Betriebskonto";
                    saldoGruppeNameDefault = "Betriebskonto";
                    break;
                case LOVsGenerated.VmPositionsartTyp.VermDepotBs:
                    saldoGruppeNameKeyPath = @"System\Fibu\SaldoGruppeName\DepotBs";
                    saldoGruppeNameDefault = "Depot BS";
                    break;
                default:
                    saldoGruppeNameKeyPath = "";
                    saldoGruppeNameDefault = "";
                    break;
            }

            var xConfigService = Container.Resolve<XConfigService>();
            var saldoGruppeName = xConfigService.GetConfigValue<string>(saldoGruppeNameKeyPath) ?? saldoGruppeNameDefault;

            // Eröffnungssaldo, Soll- und Habenbetrag berechnen
            var kontos = from kto in repositoryFbKonto
                         where kto.FbPeriodeID == periodeId
                         where kto.SaldoGruppeName == saldoGruppeName
                         select new
                         {
                             kto.FbKontoID,
                             kto.KontoNr,
                             kto.EroeffnungsSaldo,
                         };

            var sollBetrag = (from buc in repositoryFbBuchung
                              where buc.FbPeriodeID == periodeId
                              where buc.BuchungsDatum <= DateTime.Today
                              where buc.SollKtoNr.HasValue
                              where kontos.Select(x => x.KontoNr).Contains((int)buc.SollKtoNr)
                              select (decimal?)buc.Betrag)
                                 .Sum() ?? 0;

            var habenBetrag = (from buc in repositoryFbBuchung
                               where buc.FbPeriodeID == periodeId
                               where buc.BuchungsDatum <= DateTime.Today
                               where buc.HabenKtoNr.HasValue
                               where kontos.Select(x => x.KontoNr).Contains((int)buc.HabenKtoNr)
                               select (decimal?)buc.Betrag)
                                  .Sum() ?? 0;

            var eroeffnungsSaldo = kontos.Sum(x => (decimal?)x.EroeffnungsSaldo) ?? 0;
            position.Saldo = eroeffnungsSaldo + sollBetrag - habenBetrag;
            position.DatumSaldoPer = DateTime.Today;

            return result;
        }

        #endregion

        #endregion
    }
}