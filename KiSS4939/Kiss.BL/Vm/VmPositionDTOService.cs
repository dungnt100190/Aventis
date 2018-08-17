using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Kiss.BL.KissSystem;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Utils;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Infrastructure.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Vm;

namespace Kiss.BL.Vm
{
    /// <summary>
    /// Service to manage a VmPosition.
    /// </summary>
    public class VmPositionDTOService : ServiceBase, IServiceCRUD<VmPositionDTO>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly VmPositionService _positionService;

        #endregion

        #endregion

        #region Constructors

        private VmPositionDTOService()
        {
            _positionService = Container.Resolve<VmPositionService>();
        }

        #endregion

        #region Methods

        #region Public Methods

        public KissServiceResult DeleteByVmKlientenbudgetId(IUnitOfWork unitOfWork, int vmKlientenbudgetId)
        {
            return _positionService.DeleteByVmKlientenbudgetId(unitOfWork, vmKlientenbudgetId);
        }

        public KissServiceResult DeleteData(IUnitOfWork unitOfWork, VmPositionDTO dataToDelete, bool saveChanges = true)
        {
            if (dataToDelete == null)
            {
                return KissServiceResult.Ok();
            }

            return _positionService.DeleteData(unitOfWork, dataToDelete.VmPosition, saveChanges);
        }

        public VmPosition GetById(IUnitOfWork unitOfWork, int id)
        {
            return _positionService.GetById(unitOfWork, id);
        }

        public ObservableCollection<VmPositionDTO> GetByVmKategorie(IList<VmPosition> positionen, LOVsGenerated.VmKategorie vmKategorie)
        {
            var positionDtos = positionen
                .Where(p => p.VmPositionsart.VmKategorieEnum == vmKategorie)
                .Select(
                    x => new VmPositionDTO
                    {
                        VmPosition = x
                    })
                .OrderBy(x => x.VmPosition.SortKey)
                .ThenBy(x => x.VmPosition.VmPositionsart.SortKey)
                .ToList();

            positionDtos.ForEach(SetProperties);

            return new ObservableCollection<VmPositionDTO>(positionDtos);
        }

        public IList<VmPosition> GetByVmKlientenbudgetId(IUnitOfWork unitOfWork, int vmKlientenbudgetId)
        {
            return _positionService.GetByVmKlientenbudgetId(unitOfWork, vmKlientenbudgetId);
        }

        public ObservableCollection<VmPositionDTO> GetData(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Daten einer Position importieren
        /// </summary>
        /// <param name="unitOfWork">Die <see cref="IUnitOfWork"/></param>
        /// <param name="budget">Das Budget für welches die Daten importiert werden müssen</param>
        /// <param name="positionDto">Die Position für welche die Daten importiert werden müssen</param>
        /// <returns><see cref="KissServiceResult"/></returns>
        public KissServiceResult ImportData(IUnitOfWork unitOfWork, VmKlientenbudget budget, VmPositionDTO positionDto)
        {
            return _positionService.ImportData(unitOfWork, budget, positionDto.VmPosition);
        }

        public KissServiceResult NewData(out VmPositionDTO newData)
        {
            VmPosition position;
            var result = _positionService.NewData(out position);
            newData = new VmPositionDTO
            {
                VmPosition = position,
            };

            return result;
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, VmPositionDTO dataToSave)
        {
            var vmKlientenbudget = dataToSave.VmPosition.VmKlientenbudget;
            if (vmKlientenbudget != null && vmKlientenbudget.ChangeTracker.State == ObjectState.Added)
            {
                return KissServiceResult.Ok();
            }

            VmKlientenbudget budget = dataToSave.VmPosition.VmKlientenbudget;

            //Andere Budget des Users als unchanged markieren.
            //Wir hatten ab und zu eine Optimistic-Lock Exception.
            if (budget != null)
            {
                foreach (var budgetOfUser in budget.XUser.VmKlientenbudget)
                {
                    if (budgetOfUser != budget)
                    {
                        budgetOfUser.MarkAsUnchanged();
                        foreach (var pos in budgetOfUser.VmPosition)
                        {
                            pos.MarkAsUnchanged();
                        }
                    }
                    foreach (var pos in budgetOfUser.VmPosition)
                    {
                        if (pos.ChangeTracker.State == ObjectState.Deleted)
                        {
                            pos.MarkAsUnchanged();
                        }
                    }
                }
            }

            var result = _positionService.SaveData(unitOfWork, dataToSave.VmPosition);

            if (!result)
            {
                return result;
            }

            SetProperties(dataToSave);

            return result;
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork, List<VmPositionDTO> dataToSave)
        {
            var result = KissServiceResult.Ok();

            foreach (var dto in dataToSave)
            {
                result += SaveData(unitOfWork, dto);
            }

            return result;
        }

        public KissServiceResult SaveData(
            IUnitOfWork unitOfWork,
            VmPositionDTO dataToSave,
            Dictionary<string, QuestionAnswerOption> questionsAndAnswers)
        {
            throw new NotImplementedException();
        }

        public void SetBudgetBetraege(VmKlientenbudgetDTO budget)
        {
            var einnahmen = budget.Einnahmen.Sum(x => x.VmPosition.BetragMonatlich ?? 0);
            var fixeKosten = budget.FixeKosten.Sum(x => x.VmPosition.BetragMonatlich ?? 0);
            var variableKosten = budget.VariableKosten.Sum(x => x.VmPosition.BetragMonatlich ?? 0);
            budget.BetragVerfuegbar = einnahmen - fixeKosten;
            budget.Restbetrag = budget.BetragVerfuegbar - variableKosten;
            var position = GetPosVermElBerechnung(budget);
            budget.VermoegenElBerechnung = (position == null ? 0 : position.Saldo ?? 0);
        }

        public void SetProperties(VmPositionDTO positionDto)
        {
            positionDto.CanImport = CanImport(positionDto.VmPosition);
            positionDto.CanDelete = CanDelete(positionDto.VmPosition);
            positionDto.CanEdit = CanEdit(positionDto.VmPosition);
            positionDto.CanEditBemerkung = CanEditBemerkung(positionDto.VmPosition);
        }

        /// <summary>
        /// Abhängige Positionen im Budget aktualisieren (BetragMonatlich, BetragJaehrlich oder Saldo neu berechnen)
        /// </summary>
        /// <param name="unitOfWork">Die <see cref="IUnitOfWork"/></param>
        /// <param name="budget">Das Budget dass aktualisiert werden muss</param>
        /// <param name="position">Die Position die angepasst wurde</param>
        /// <returns><see cref="KissServiceResult"/></returns>
        public KissServiceResult UpdateBetragSaldoOtherPositions(IUnitOfWork unitOfWork, VmKlientenbudgetDTO budget, VmPositionDTO position)
        {
            var result = KissServiceResult.Ok();
            LOVsGenerated.VmPositionsartTyp positionsartTyp;
            bool neuBerechnen;

            if (position == null)
            {
                neuBerechnen = true;
                positionsartTyp = LOVsGenerated.VmPositionsartTyp.Empty;
            }
            else
            {
                neuBerechnen = false;
                positionsartTyp = position.VmPosition.VmPositionsart.VmPositionsartTypEnum;
            }

            var posVermTotal = GetPosVermTotal(budget);
            var posVermElBerechnung = GetPosVermElBerechnung(budget);
            var vermBerechnungAngepasst = false;

            // Vermögen EL-Berechnung neu berechnen (Total Vermögen - EL-Freibetrag)
            if (neuBerechnen || position.VmPosition.VmPositionsart.VmKategorieEnum == LOVsGenerated.VmKategorie.Vermoegen)
            {
                if (posVermElBerechnung == null && posVermTotal == null)
                {
                    budget.VermoegenElBerechnung = 0;
                }
                else
                {
                    var vermoegen = (from pos in budget.Vermoegen.Select(p => p.VmPosition)
                                     let istVermElFreibetrag =
                                         pos.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.VermElFreibetrag
                                     where pos.VmPositionsart.VmPositionsartTypEnum != LOVsGenerated.VmPositionsartTyp.VermElBerechnung &&
                                           pos.VmPositionsart.VmPositionsartTypEnum != LOVsGenerated.VmPositionsartTyp.VermTotal
                                     select new
                                            {
                                                ElFreibetrag = (istVermElFreibetrag ? pos.Saldo : 0) ?? 0,
                                                Saldo = (istVermElFreibetrag ? 0 : pos.Saldo) ?? 0
                                            }).ToList();

                    if (posVermElBerechnung != null)
                    {
                        budget.VermoegenElBerechnung = vermoegen.Sum(p => p.Saldo - p.ElFreibetrag);

                        // EL-Berechnung kann nicht negativ sein
                        if (budget.VermoegenElBerechnung < 0)
                        {
                            budget.VermoegenElBerechnung = 0;
                        }

                        posVermElBerechnung.Saldo = budget.VermoegenElBerechnung;
                    }

                    if (posVermTotal != null)
                    {
                        budget.VermoegenTotal = vermoegen.Sum(p => p.Saldo);

                        posVermTotal.Saldo = budget.VermoegenTotal;
                    }

                    vermBerechnungAngepasst = true;
                }
            }

            // Anteil aus Vermögen neu berechnen
            if (neuBerechnen ||
                positionsartTyp == LOVsGenerated.VmPositionsartTyp.EinnAhvRente ||
                positionsartTyp == LOVsGenerated.VmPositionsartTyp.EinnIvRente ||
                positionsartTyp == LOVsGenerated.VmPositionsartTyp.AusgHeimkosten ||
                positionsartTyp == LOVsGenerated.VmPositionsartTyp.AusgMietzins ||
                vermBerechnungAngepasst)
            {
                var posEinnAnteilAusVermoegen = budget.Einnahmen
                    .Select(p => p.VmPosition)
                    .SingleOrDefault(p => p.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.EinnAnteilAusVermoegen);
                if (posEinnAnteilAusVermoegen != null)
                {
                    var xConfigService = Container.Resolve<XConfigService>();
                    string keyPathVermoegensverzehr = "";
                    var betragMiete = budget.FixeKosten
                        .Select(p => p.VmPosition)
                        .Where(p => p.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.AusgMietzins)
                        .Sum(p => p.BetragMonatlich);
                    var betragHeim = budget.FixeKosten
                        .Select(p => p.VmPosition)
                        .Where(p => p.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.AusgHeimkosten)
                        .Sum(p => p.BetragMonatlich);
                    var betragIvRente = budget.Einnahmen
                        .Select(p => p.VmPosition)
                        .Where(p => p.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.EinnIvRente)
                        .Sum(p => p.BetragMonatlich);
                    var betragAhvRente = budget.Einnahmen
                        .Select(p => p.VmPosition)
                        .Where(p => p.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.EinnAhvRente)
                        .Sum(p => p.BetragMonatlich);

                    if (betragIvRente > 0)
                    {
                        if (betragHeim > 0)
                        {
                            keyPathVermoegensverzehr = @"System\Vormundschaft\Klientenbudget\HeimVermoegensverzehrIV";
                        }
                        else if (betragMiete > 0)
                        {
                            keyPathVermoegensverzehr = @"System\Vormundschaft\Klientenbudget\MieteVermoegensverzehrIV";
                        }
                    }
                    else if (betragAhvRente > 0)
                    {
                        if (betragHeim > 0)
                        {
                            keyPathVermoegensverzehr = @"System\Vormundschaft\Klientenbudget\HeimVermoegensverzehrAHV";
                        }
                        else if (betragMiete > 0)
                        {
                            keyPathVermoegensverzehr = @"System\Vormundschaft\Klientenbudget\MieteVermoegensverzehrAHV";
                        }
                    }

                    int? vermoegensverzehr;
                    if (string.IsNullOrEmpty(keyPathVermoegensverzehr))
                    {
                        vermoegensverzehr = 0;
                    }
                    else
                    {
                        vermoegensverzehr = xConfigService.GetConfigValue<int?>(keyPathVermoegensverzehr, budget.VmKlientenbudget.GueltigAb, 0) ?? (int?)0;
                    }

                    decimal? anteilAusVermoegen;
                    if (vermoegensverzehr == 0)
                    {
                        anteilAusVermoegen = 0;
                    }
                    else
                    {
                        anteilAusVermoegen = budget.VermoegenElBerechnung / vermoegensverzehr;
                    }

                    posEinnAnteilAusVermoegen.BetragJaehrlich = Utils.RoundMoney_CH(anteilAusVermoegen.Value);
                }
            }

            // Betrag verfügbar und Restbetrag berechnen
            SetBudgetBetraege(budget);

            return result;
        }

        #endregion

        #region Private Static Methods

        private static bool CanDelete(VmPosition vmPosition)
        {
            // Vermögen-Total darf nicht gelöscht werden
            if (vmPosition.IstImportiert ||
                vmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.VermTotal)
            {
                return false;
            }

            return true;
        }

        private static bool CanEdit(VmPosition position)
        {
            if (position.IstImportiert ||
                position.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.VermTotal ||
                position.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.VermElBerechnung ||
                position.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.VermElFreibetrag)
            {
                return false;
            }

            return true;
        }

        private static bool CanEditBemerkung(VmPosition position)
        {
            if (position.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.VermTotal ||
                position.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.VermElBerechnung ||
                position.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.VermElFreibetrag)
            {
                return false;
            }

            // die Bemerkung von Betriebskonto, Depot BS und Kasse + PC kann immer gesetzt werden
            if (position.IstImportiert &&
                position.VmPositionsart.VmPositionsartTypEnum != LOVsGenerated.VmPositionsartTyp.VermBetriebskonto &&
                position.VmPositionsart.VmPositionsartTypEnum != LOVsGenerated.VmPositionsartTyp.VermDepotBs &&
                position.VmPositionsart.VmPositionsartTypEnum != LOVsGenerated.VmPositionsartTyp.VermKassePc)
            {
                return false;
            }

            return true;
        }

        private static bool CanImport(VmPosition position)
        {
            if (position.VmPositionsart == null)
            {
                return false;
            }

            var positionsartTyp = position.VmPositionsart.VmPositionsartTypEnum;
            return positionsartTyp == LOVsGenerated.VmPositionsartTyp.VermKassePc ||
                   positionsartTyp == LOVsGenerated.VmPositionsartTyp.VermBetriebskonto ||
                   positionsartTyp == LOVsGenerated.VmPositionsartTyp.VermDepotBs ||
                   positionsartTyp == LOVsGenerated.VmPositionsartTyp.AusgKkPraemienKvg ||
                   positionsartTyp == LOVsGenerated.VmPositionsartTyp.AusgKkPraemienVvg;
        }

        private static VmPosition GetPosVermElBerechnung(VmKlientenbudgetDTO budget)
        {
            return budget.Vermoegen
                .Select(p => p.VmPosition)
                .SingleOrDefault(p => p.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.VermElBerechnung);
        }

        private static VmPosition GetPosVermTotal(VmKlientenbudgetDTO budget)
        {
            return budget.Vermoegen
                .Select(p => p.VmPosition)
                .SingleOrDefault(p => p.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.VermTotal);
        }

        #endregion

        #endregion
    }
}