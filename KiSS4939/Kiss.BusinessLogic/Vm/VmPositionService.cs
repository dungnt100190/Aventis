using System;
using System.Linq;

using Kiss.BusinessLogic.Sys;
using Kiss.BusinessLogic.Sys.NodeEnumeration;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.DbContext.Enums.Vm;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Vm
{
    public class VmPositionService : ServiceCRUD<VmPosition>
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Löscht alle <see cref="VmPosition"/>en eines Budgets
        /// </summary>
        /// <param name="vmKlientenbudgetId"></param>
        /// <returns></returns>
        public ServiceResult DeleteByVmKlientenbudgetId(int vmKlientenbudgetId)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                try
                {
                    unitOfWork.VmPosition.RemoveAllPositionsOfBudget(vmKlientenbudgetId);
                    unitOfWork.SaveChanges();
                    return ServiceResult.Ok();
                }
                catch (Exception ex)
                {
                    return new ServiceResult(ex);
                }
            }
        }

        /// <summary>
        /// Gibt die <see cref="VmPosition"/>en eines <see cref="VmKlientenbudget"/>s zurück
        /// </summary>
        /// <param name="vmKlientenbudgetID"></param>
        /// <returns></returns>
        public VmPosition[] GetByKlientenbudgetID(int vmKlientenbudgetID)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.VmPosition.GetByVmKlientenbudgetId(vmKlientenbudgetID);
            }
        }

        /// <summary>
        /// Gibt die <see cref="VmPosition"/>en eines Standard-Budgets zurück
        /// </summary>
        /// <returns></returns>
        public VmPosition[] GetDefaultPositionen()
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork
                    .VmPositionsart
                    .GetTemplatePositionsarten()
                    .Select(vpa => new VmPosition
                                       {
                                           Name = vpa.Name,
                                           VmPositionsart = vpa,
                                           // ToDo: entfernen, wenn Poco das beherrscht (ID aufgrund navigation property setzen)
                                           VmPositionsartID = vpa.VmPositionsartID,
                                           SortKey = vpa.SortKey
                                       })
                    .ToArray();
            }
        }

        /// <summary>
        /// Daten einer <see cref="VmPosition"/> importieren
        /// </summary>
        /// <param name="position">Die Position für welche die Daten importiert werden müssen</param>
        /// <param name="faLeistungID"> </param>
        /// <returns><see cref="KissServiceResult"/></returns>
        public ServiceResult<VmPosition> ImportData(VmPosition position, int faLeistungID)
        {
            var result = ServiceResult<VmPosition>.Ok();
            if (position == null)
            {
                return result;
            }
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                var leistung = unitOfWork.FaLeistung.GetById(faLeistungID);
                if (leistung == null)
                {
                    return new ServiceResult<VmPosition>(ServiceResultType.Error, "FaLeistungID ungültig");
                }

                var positionsartTyp = position.VmPositionsart.VmPositionsartTyp;

                switch (positionsartTyp)
                {
                    case VmPositionsartTyp.VermKassePc:
                    case VmPositionsartTyp.VermBetriebskonto:
                    case VmPositionsartTyp.VermDepotBs:
                        // Werte aus Mandatsbuchhaltung/Bilanz/Erfolg holen
                        result.Add(ImportDataSaldoBilanzErfolg(unitOfWork, leistung.BaPersonID, position, positionsartTyp));
                        break;

                    case VmPositionsartTyp.AusgKkPraemienKvg:
                    case VmPositionsartTyp.AusgKkPraemienVvg:
                        // Werte aus Basis/Gesundheit/KVG oder VVG holen
                        result.Add(ImportDataKkPraemien(unitOfWork, leistung.BaPersonID, position, positionsartTyp));
                        break;

                    default:
                        return new ServiceResult<VmPosition>(ServiceResultType.Error, "Diese Position kann nicht importiert werden.");
                }
            }

            if (result.IsOk)
            {
                position.IstImportiert = true;
                result.Result = position;
            }

            return result;
        }

        #endregion

        #region Private Static Methods

        private static IServiceResult ImportDataKkPraemien(
            IKissUnitOfWork unitOfWork,
            int baPersonID,
            VmPosition position,
            VmPositionsartTyp positionsartTyp)
        {
            var result = KissServiceResult.Ok();

            var istKvg = positionsartTyp == VmPositionsartTyp.AusgKkPraemienKvg;

            var gesundheit = unitOfWork.BaGesundheit.GetGesundheit(baPersonID);

            if (gesundheit == null)
            {
                position.BetragMonatlich = 0;
                position.Bemerkung = "";
            }
            else
            {
                position.BetragMonatlich = istKvg ? gesundheit.KVGPraemie : gesundheit.VVGPraemie;
                if (istKvg && gesundheit.BaInstitution_Kvg != null)
                {
                    position.Bemerkung = gesundheit.BaInstitution_Kvg.Name;
                }
                else if (!istKvg && gesundheit.BaInstitution_Vvg != null)
                {
                    position.Bemerkung = gesundheit.BaInstitution_Vvg.Name;
                }
            }

            return result;
        }

        private static IServiceResult ImportDataSaldoBilanzErfolg(
            IKissUnitOfWork unitOfWork,
            int baPersonId,
            VmPosition position,
            VmPositionsartTyp positionsartTyp)
        {
            var result = KissServiceResult.Ok();
            var saldoPer = DateTime.Today;

            var periode = unitOfWork.FbPeriode.GetCurrentPeriode(baPersonId);

            // Es gibt keine aktuelle Periode
            if (periode == null)
            {
                position.Saldo = null;
                position.DatumSaldoPer = saldoPer;
                return result;
            }
            var periodeId = periode.FbPeriodeID;

            // SaldoGruppeName je nach PositionsartTyp definieren
            ConfigNode<string> saldoGruppeNameConfigNode;
            string saldoGruppeNameDefault;
            switch (positionsartTyp)
            {
                case VmPositionsartTyp.VermKassePc:
                    saldoGruppeNameConfigNode = ConfigNodes.System_Fibu_SaldoGruppeName_KassePc;
                    saldoGruppeNameDefault = "Kasse + PC";
                    break;

                case VmPositionsartTyp.VermBetriebskonto:
                    saldoGruppeNameConfigNode = ConfigNodes.System_Fibu_SaldoGruppeName_Betriebskonto;
                    saldoGruppeNameDefault = "Betriebskonto";
                    break;

                case VmPositionsartTyp.VermDepotBs:
                    saldoGruppeNameConfigNode = ConfigNodes.System_Fibu_SaldoGruppeName_DepotBs;
                    saldoGruppeNameDefault = "Depot BS";
                    break;

                default:
                    saldoGruppeNameConfigNode = null;
                    saldoGruppeNameDefault = "";
                    break;
            }

            var configService = Container.Resolve<XConfigService>();
            var saldoGruppeName = configService.GetConfigValue(saldoGruppeNameConfigNode) ?? saldoGruppeNameDefault;

            // Eröffnungssaldo, Soll- und Habenbetrag berechnen
            var kontos = unitOfWork.FbKonto.GetKontoBySaldoGruppe(periodeId, saldoGruppeName).ToArray();
            var sollBetrag = unitOfWork.FbBuchung.GetSollBetrag(periodeId, saldoPer, kontos.Select(kto => kto.FbKontoID));
            var habenBetrag = unitOfWork.FbBuchung.GetHabenBetrag(periodeId, saldoPer, kontos.Select(kto => kto.FbKontoID));

            var eroeffnungsSaldo = kontos.Sum(x => (decimal?)x.EroeffnungsSaldo) ?? 0;
            position.Saldo = eroeffnungsSaldo + sollBetrag - habenBetrag;
            position.DatumSaldoPer = saldoPer;

            return result;
        }

        #endregion

        #endregion
    }
}