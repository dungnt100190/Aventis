using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

using Kiss.BusinessLogic.Sys;
using Kiss.BusinessLogic.Sys.NodeEnumeration;
using Kiss.BusinessLogic.Vm;
using Kiss.DbContext;
using Kiss.DbContext.Enums.Vm;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Utils;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.UserInterface.ViewModel.Interfaces;
using Container = Kiss.Infrastructure.IoC.Container;

namespace Kiss.UserInterface.ViewModel.Vm
{
    [DataContract(IsReference = true)]
    public class VmKlientenbudgetVM : Bindable, IAutoIdentityEntity<int>, IEntityWrapper<VmKlientenbudget>
    {
        #region Fields

        #region Private Fields

        [DataMember]
        private bool _bearbeiten;

        [DataMember]
        private decimal _betragVerfuegbar;

        [DataMember]
        private ElFreibetrag[] _elFreibetragListe;

        [DataMember]
        private decimal _restbetrag;

        [DataMember]
        private decimal _vermoegenElBerechnung;

        [DataMember]
        private decimal _vermoegenTotal;

        #endregion

        #endregion

        #region Constructors

        public VmKlientenbudgetVM()
            : this(new VmKlientenbudget())
        {
        }

        public VmKlientenbudgetVM(int copyVmPositionsFromVmKlientenbudgetID, VmKlientenbudget newBudget)
        {
            var positionService = Container.Resolve<VmPositionService>();
            var positions = positionService
                            .GetByKlientenbudgetID(copyVmPositionsFromVmKlientenbudgetID)
                            .Select(pos => new VmPosition
                                               {
                                                   Bemerkung = pos.Bemerkung,
                                                   BetragJaehrlich = pos.BetragJaehrlich,
                                                   BetragMonatlich = pos.BetragMonatlich,
                                                   DatumSaldoPer = pos.DatumSaldoPer,
                                                   IstImportiert = pos.IstImportiert,
                                                   Name = pos.Name,
                                                   Saldo = pos.Saldo,
                                                   SortKey = pos.SortKey,
                                                   VmPositionsart = pos.VmPositionsart,
                                                   VmPositionsartID = pos.VmPositionsartID
                                               })
                            .ToArray();
            Init(newBudget, positions);
        }

        public VmKlientenbudgetVM(VmKlientenbudget budget)
        {
            VmPosition[] positions;
            var positionService = Container.Resolve<VmPositionService>();
            if (budget.VmKlientenbudgetID == 0)
            {
                // new entity, get default positions
                positions = positionService.GetDefaultPositionen();
            }
            else
            {
                // existing entity, load from db
                positions = positionService.GetByKlientenbudgetID(budget.VmKlientenbudgetID);
            }
            Init(budget, positions);
        }

        private void Init(VmKlientenbudget budget, VmPosition[] positions)
        {
            if (budget == null)
            {
                throw new ArgumentNullException("budget");
            }
            Budget = budget;
            Budget.PropertyChanged += BudgetOnPropertyChanged;

            KategorieVM = new List<VmKlientenbudgetKategorieVM>
                              {
                                  new VmKlientenbudgetKategorieVM(VmKategorie.Vermoegen, Budget.VmKlientenbudgetID, Budget.FaLeistungID),
                                  new VmKlientenbudgetKategorieVM(VmKategorie.Einnahmen, Budget.VmKlientenbudgetID, Budget.FaLeistungID),
                                  new VmKlientenbudgetKategorieVM(VmKategorie.FixeKosten, Budget.VmKlientenbudgetID, Budget.FaLeistungID),
                                  new VmKlientenbudgetKategorieVM(VmKategorie.VariableKosten, Budget.VmKlientenbudgetID, Budget.FaLeistungID),
                              };
            foreach (var kategorieVM in KategorieVM)
            {
                var vm = kategorieVM;
                kategorieVM.SetVmPosition(positions.Where(pos => pos.VmPositionsart.VmKategorie == vm.VmKategorie));
                kategorieVM.RecalculateSaldoSuggested += KategorieVmRecalculateSaldoSuggested;
            }

            PropagateReadOnlyToKategorieVM();
            ElFreibetragListe = GetXConfigElFreibetrag(Budget.GueltigAb);

            UpdateBetragSaldoOtherPositions();
        }

        #endregion

        #region Properties

        public int AutoIdentityID
        {
            get { return Budget.VmKlientenbudgetID; }
        }

        /// <summary>
        /// Gibt an, ob sich das VM gerade im Bearbeiten-Modus befindet.
        /// </summary>
        public bool Bearbeiten
        {
            get { return _bearbeiten; }
            set
            {
                if (SetProperty(ref _bearbeiten, value, () => Bearbeiten))
                {
                    PropagateReadOnlyToKategorieVM();
                }
            }
        }

        public decimal BetragVerfuegbar
        {
            get { return _betragVerfuegbar; }
            set { SetProperty(ref _betragVerfuegbar, value, () => BetragVerfuegbar); }
        }

        public VmKlientenbudget Budget { get; private set; }

        public ElFreibetrag[] ElFreibetragListe
        {
            get { return _elFreibetragListe; }
            set
            {
                if (SetProperty(ref _elFreibetragListe, value, () => ElFreibetragListe) && KategorieVM != null)
                {
                    var readOnlyCollection = new ReadOnlyCollection<ElFreibetrag>(value);
                    foreach (var kategorieVM in KategorieVM)
                    {
                        kategorieVM.ElFreibetragListe = readOnlyCollection;
                    }
                }
            }
        }

        public bool IsBudgetEditable
        {
            get { return AutoIdentityID == 0 || Budget.VmKlientenbudgetStatus == VmKlientenbudgetStatus.InBearbeitung; }
        }

        public bool IsBudgetStatusEditable
        {
            get { return AutoIdentityID == 0 || Budget.VmKlientenbudgetStatus != VmKlientenbudgetStatus.Archiviert; }
        }

        public IList<VmKlientenbudgetKategorieVM> KategorieVM { get; private set; }

        public decimal Restbetrag
        {
            get { return _restbetrag; }
            set { SetProperty(ref _restbetrag, value, () => Restbetrag); }
        }

        public decimal VermoegenElBerechnung
        {
            get { return _vermoegenElBerechnung; }
            set { SetProperty(ref _vermoegenElBerechnung, value, () => VermoegenElBerechnung); }
        }

        public decimal VermoegenTotal
        {
            get { return _vermoegenTotal; }
            set { SetProperty(ref _vermoegenTotal, value, () => VermoegenTotal); }
        }

        public VmKlientenbudget WrappedEntity
        {
            get { return Budget; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void SavePendingPositionen(int vmKlientenbudgetID)
        {
            foreach (var kategorieVM in KategorieVM)
            {
                kategorieVM.SavePendingPositionen(vmKlientenbudgetID);
            }
        }

        /// <summary>
        /// Abhängige Positionen im Budget aktualisieren (BetragMonatlich, BetragJaehrlich oder Saldo neu berechnen)
        /// </summary>
        /// <param name="modifiedPosition">Die Position die angepasst wurde</param>
        /// <returns><see cref="KissServiceResult"/></returns>
        public void UpdateBetragSaldoOtherPositions(VmPosition modifiedPosition = null)
        {
            var positionsartTyp = VmPositionsartTyp.Empty;
            var neuBerechnen = true;

            if (modifiedPosition != null)
            {
                neuBerechnen = false;
                positionsartTyp = modifiedPosition.VmPositionsart.VmPositionsartTyp;
            }
            var vermoegenList = KategorieVM.First(kat => kat.VmKategorie == VmKategorie.Vermoegen).PositionList;
            var einnnahmenList = KategorieVM.First(kat => kat.VmKategorie == VmKategorie.Einnahmen).PositionList;
            var fixeKostenList = KategorieVM.First(kat => kat.VmKategorie == VmKategorie.FixeKosten).PositionList;
            var variableKostenList = KategorieVM.First(kat => kat.VmKategorie == VmKategorie.VariableKosten).PositionList;

            var posVermTotal = vermoegenList.SingleOrDefault(p => p.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.VermTotal);
            var posVermElBerechnung = vermoegenList.SingleOrDefault(p => p.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.VermElBerechnung);
            var vermBerechnungAngepasst = false;

            // Vermögen EL-Berechnung neu berechnen (Total Vermögen - EL-Freibetrag)
            if (neuBerechnen || modifiedPosition.VmPositionsart.VmKategorie == VmKategorie.Vermoegen)
            {
                if (posVermElBerechnung == null && posVermTotal == null)
                {
                    VermoegenElBerechnung = 0;
                }
                else
                {
                    //var vermoegen = EntityList.Where(pos=>pos.VmPositionsart.VmKategorie== VmKategorie.Vermoegen)

                    var vermoegen = (from pos in vermoegenList
                                     let istVermElFreibetrag =
                                         pos.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.VermElFreibetrag
                                     where pos.VmPositionsart.VmPositionsartTyp != VmPositionsartTyp.VermElBerechnung &&
                                           pos.VmPositionsart.VmPositionsartTyp != VmPositionsartTyp.VermTotal
                                     select new
                                     {
                                         ElFreibetrag = (istVermElFreibetrag ? pos.Saldo : 0) ?? 0,
                                         Saldo = (istVermElFreibetrag ? 0 : pos.Saldo) ?? 0
                                     }).ToList();

                    if (posVermElBerechnung != null)
                    {
                        VermoegenElBerechnung = vermoegen.Sum(p => p.Saldo - p.ElFreibetrag);

                        // EL-Berechnung kann nicht negativ sein
                        if (VermoegenElBerechnung < 0)
                        {
                            VermoegenElBerechnung = 0;
                        }

                        posVermElBerechnung.Saldo = VermoegenElBerechnung;
                    }

                    if (posVermTotal != null)
                    {
                        VermoegenTotal = vermoegen.Sum(p => p.Saldo);

                        posVermTotal.Saldo = VermoegenTotal;
                    }

                    vermBerechnungAngepasst = true;
                }
            }

            // Anteil aus Vermögen neu berechnen
            if (neuBerechnen ||
                positionsartTyp == VmPositionsartTyp.EinnAhvRente ||
                positionsartTyp == VmPositionsartTyp.EinnIvRente ||
                positionsartTyp == VmPositionsartTyp.AusgHeimkosten ||
                positionsartTyp == VmPositionsartTyp.AusgMietzins ||
                vermBerechnungAngepasst)
            {
                var posEinnAnteilAusVermoegen = einnnahmenList.SingleOrDefault(p => p.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.EinnAnteilAusVermoegen);
                if (posEinnAnteilAusVermoegen != null)
                {
                    var xConfigService = Container.Resolve<XConfigService>();
                    ConfigNode<int> configNodeVermoegensverzehr = null;
                    var betragMiete = fixeKostenList
                                      .Where(pos => pos.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.AusgMietzins)
                                      .Sum(p => p.BetragMonatlich);
                    var betragHeim = fixeKostenList
                                     .Where(pos => pos.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.AusgHeimkosten)
                                     .Sum(p => p.BetragMonatlich);
                    var betragIvRente = einnnahmenList
                                        .Where(pos => pos.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.EinnIvRente)
                                        .Sum(p => p.BetragMonatlich);
                    var betragAhvRente = einnnahmenList
                                         .Where(pos => pos.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.EinnAhvRente)
                                         .Sum(p => p.BetragMonatlich);

                    if (betragIvRente > 0)
                    {
                        if (betragHeim > 0)
                        {
                            configNodeVermoegensverzehr = ConfigNodes.System_Vormundschaft_Klientenbudget_HeimVermoegensverzehrIV;
                        }
                        else if (betragMiete > 0)
                        {
                            configNodeVermoegensverzehr = ConfigNodes.System_Vormundschaft_Klientenbudget_MieteVermoegensverzehrIV;
                        }
                    }
                    else if (betragAhvRente > 0)
                    {
                        if (betragHeim > 0)
                        {
                            configNodeVermoegensverzehr = ConfigNodes.System_Vormundschaft_Klientenbudget_HeimVermoegensverzehrAHV;
                        }
                        else if (betragMiete > 0)
                        {
                            configNodeVermoegensverzehr = ConfigNodes.System_Vormundschaft_Klientenbudget_MieteVermoegensverzehrAHV;
                        }
                    }

                    int? vermoegensverzehr = configNodeVermoegensverzehr == null ? 0 : xConfigService.GetConfigValue(configNodeVermoegensverzehr, Budget.GueltigAb);

                    decimal? anteilAusVermoegen;
                    if (vermoegensverzehr == 0)
                    {
                        anteilAusVermoegen = 0;
                    }
                    else
                    {
                        anteilAusVermoegen = VermoegenElBerechnung / vermoegensverzehr;
                    }

                    posEinnAnteilAusVermoegen.BetragJaehrlich = Utils.RoundMoney_CH(anteilAusVermoegen.Value);
                }
            }

            // Betrag verfügbar und Restbetrag berechnen
            var einnahmen = einnnahmenList.Sum(x => x.BetragMonatlich ?? 0);
            var fixeKosten = fixeKostenList.Sum(x => x.BetragMonatlich ?? 0);
            var variableKosten = variableKostenList.Sum(x => x.BetragMonatlich ?? 0);
            BetragVerfuegbar = einnahmen - fixeKosten;
            Restbetrag = BetragVerfuegbar - variableKosten;
            var position = vermoegenList.SingleOrDefault(pos => pos.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.VermElBerechnung);
            VermoegenElBerechnung = (position == null ? 0 : position.Saldo ?? 0);
        }

        #endregion

        #region Private Static Methods

        private static ElFreibetrag[] GetXConfigElFreibetrag(DateTime validAt)
        {
            // EL-Freibetrag-Config-Werte
            var configService = Container.Resolve<XConfigService>();
            var alleinstehend = configService.GetConfigValue(ConfigNodes.System_Vormundschaft_Klientenbudget_ElFreibetragAlleinstehend, validAt);
            var ehepaar = configService.GetConfigValue(ConfigNodes.System_Vormundschaft_Klientenbudget_ElFreibetragEhepaar, validAt);
            var waisenUndKinder = configService.GetConfigValue(ConfigNodes.System_Vormundschaft_Klientenbudget_ElFreibetragWaisenKinderMitRentenanspruch, validAt);

            // ToDo: Multilanguage
            return new[]
            {
                new ElFreibetrag{ ValidAt = validAt},
                new ElFreibetrag{ ValidAt = validAt, Text = "Alleinstehende Person", Betrag = alleinstehend, KeyPath = ConfigNodes.System_Vormundschaft_Klientenbudget_ElFreibetragAlleinstehend.KeyPath },
                new ElFreibetrag{ ValidAt = validAt, Text = "Ehepaar", Betrag = ehepaar, KeyPath = ConfigNodes.System_Vormundschaft_Klientenbudget_ElFreibetragEhepaar.KeyPath },
                new ElFreibetrag{ ValidAt = validAt, Text = "Waisen und Kinder mit Rentenanspruch", Betrag = waisenUndKinder, KeyPath = ConfigNodes.System_Vormundschaft_Klientenbudget_ElFreibetragWaisenKinderMitRentenanspruch.KeyPath },
                new ElFreibetrag{ ValidAt = validAt, Text = "nicht relevant", Betrag = 0 }
            };
        }

        #endregion

        #region Private Methods

        private void BudgetOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // necessary for devexpress
            NotifyPropertyChanged.RaisePropertyChanged(string.Format("{0}.{1}", PropertyName.GetPropertyName(() => Budget), e.PropertyName));

            var gueltigAbPropertyName = PropertyName.GetPropertyName(() => Budget.GueltigAb);
            if (e.PropertyName == gueltigAbPropertyName)
            {
                ReloadXConfigElFreibetrag();
            }
            var statusPropertyName = PropertyName.GetPropertyName(() => Budget.VmKlientenbudgetStatus);
            var idPropertyName = PropertyName.GetPropertyName(() => Budget.VmKlientenbudgetID);
            if (e.PropertyName == statusPropertyName || e.PropertyName == idPropertyName)
            {
                NotifyPropertyChanged.RaisePropertyChanged(() => IsBudgetEditable);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsBudgetStatusEditable);
                PropagateReadOnlyToKategorieVM();
            }
        }

        //private VmKlientenbudgetKategorieVM CreateKategorieVM(VmKategorie kategorie)
        //{
        //    var vm = new VmKlientenbudgetKategorieVM(kategorie, Budget.VmKlientenbudgetID)
        //                 {
        //                     ElFreibetragListe = _elFreibetragListe == null ? null : new ReadOnlyCollection<ElFreibetrag>(_elFreibetragListe)
        //                 };
        //    vm.RecalculateSaldoSuggested += KategorieVMRecalculateSaldoSuggested;
        //    return vm;
        //}

        private void KategorieVmRecalculateSaldoSuggested(object sender, EventArgs<VmPosition> e)
        {
            UpdateBetragSaldoOtherPositions(e.Parameter);
        }

        private void PropagateReadOnlyToKategorieVM()
        {
            if (KategorieVM == null)
            {
                return;
            }
            var isReadOnly = !Bearbeiten || !IsBudgetEditable;
            foreach (var kategorieVM in KategorieVM)
            {
                kategorieVM.IsReadOnly = isReadOnly;
            }
        }

        private void ReloadXConfigElFreibetrag()
        {
            if (!ElFreibetragListe.Any())
            {
                ElFreibetragListe = GetXConfigElFreibetrag(Budget.GueltigAb);
                return;
            }
            var originalGueltigAb = ElFreibetragListe.First().ValidAt;
            if (originalGueltigAb != Budget.GueltigAb)
            {
                var elFreibetragPosition = KategorieVM
                                           .First(kat => kat.VmKategorie == VmKategorie.Vermoegen)
                                           .PositionList
                                           .FirstOrDefault(p => p.VmPositionsart.VmPositionsartTyp == VmPositionsartTyp.VermElFreibetrag);

                var keyPath = "";

                if (elFreibetragPosition != null)
                {
                    var elFreibetragDropDown = ElFreibetragListe.FirstOrDefault(x => x.Betrag == elFreibetragPosition.Saldo);

                    if (elFreibetragDropDown != null)
                    {
                        keyPath = elFreibetragDropDown.KeyPath;
                    }
                }

                ElFreibetragListe = GetXConfigElFreibetrag(Budget.GueltigAb);

                if (elFreibetragPosition != null)
                {
                    var firstOrDefault = ElFreibetragListe.FirstOrDefault(x => x.KeyPath == keyPath);
                    if (firstOrDefault != null)
                    {
                        var newConfigValue = firstOrDefault.Betrag;
                        if ((elFreibetragPosition.Saldo ?? 0) != newConfigValue)
                        {
                            elFreibetragPosition.Saldo = newConfigValue;
                        }
                    }

                    UpdateBetragSaldoOtherPositions(elFreibetragPosition);
                }
            }
        }

        #endregion

        #endregion

        #region Nested Types

        public class ElFreibetrag
        {
            #region Properties

            public decimal? Betrag { get; set; }

            public string KeyPath { get; set; }

            public string Text { get; set; }

            public DateTime ValidAt { get; set; }

            #endregion
        }

        #endregion
    }
}