using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

using Kiss.BL;
using Kiss.BL.KissSystem;
using Kiss.BL.Vm;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Utils;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Container = Kiss.Infrastructure.IoC.Container;
using Kiss.Model;
using Kiss.Model.DTO.Vm;

namespace Kiss.UI.ViewModel.Vm
{
    public class VmKlientenbudgetKategorieVM : ViewModelCRUDListBase<VmPositionDTO>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly VmPositionsartService _vmPositionsartService;
        private readonly XLovService _xLovService;

        #endregion

        #region Private Fields

        private ObservableCollection<ElFreibetrag> _elFreibetragListe;
        private bool _isReadOnly;
        private string _title;
        private LOVsGenerated.VmKategorie _vmKategorie;
        private VmKlientenbudgetDTO _vmKlientenbudgetDTO;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VmKlientenbudgetKategorieVM"/> class.
        /// </summary>
        public VmKlientenbudgetKategorieVM()
            : base(Container.Resolve<VmPositionDTOService>())
        {
            AddCommand = new BaseCommand(x => NewData(), x => VmKlientenbudgetDTO != null && !IsReadOnly);
            MoveUpCommand = new BaseCommand(x => MoveUp(), x => CanMoveUp());
            MoveDownCommand = new BaseCommand(x => MoveDown(), x => CanMoveDown());
            ImportCommand = new BaseCommand(x => ImportData());

            _xLovService = Container.Resolve<XLovService>();
            _vmPositionsartService = Container.Resolve<VmPositionsartService>();
        }

        #endregion

        #region Events

        public event EventHandler MoveCommandExecuted;

        #endregion

        #region Properties

        public BaseCommand AddCommand { get; private set; }

        public ObservableCollection<ElFreibetrag> ElFreibetragListe
        {
            get { return _elFreibetragListe; }
            set { SetProperty(ref _elFreibetragListe, value, () => ElFreibetragListe); }
        }

        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            set
            {
                if (SetProperty(ref _isReadOnly, value, () => IsReadOnly))
                {
                    AddCommand.EvaluateCanExecute();
                    MoveUpCommand.EvaluateCanExecute();
                    MoveDownCommand.EvaluateCanExecute();
                }
            }
        }

        public bool IsVermoegen
        {
            get { return VmKategorie == LOVsGenerated.VmKategorie.Vermoegen; }
        }

        public BaseCommand MoveDownCommand { get; private set; }

        public BaseCommand MoveUpCommand { get; private set; }

        public BaseCommand ImportCommand { get; private set; }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value, () => Title); }
        }

        public LOVsGenerated.VmKategorie VmKategorie
        {
            get { return _vmKategorie; }
            set
            {
                if (SetProperty(ref _vmKategorie, value, () => VmKategorie))
                {
                    NotifyPropertyChanged.RaisePropertyChanged(() => IsVermoegen);
                }
            }
        }

        public VmKlientenbudgetDTO VmKlientenbudgetDTO
        {
            get { return _vmKlientenbudgetDTO; }
            set
            {
                if (_vmKlientenbudgetDTO == value)
                {
                    return;
                }

                if (_vmKlientenbudgetDTO != null)
                {
                    _vmKlientenbudgetDTO.Vermoegen.CollectionChanged -= VmPosition_CollectionChanged;
                    _vmKlientenbudgetDTO.Einnahmen.CollectionChanged -= VmPosition_CollectionChanged;
                    _vmKlientenbudgetDTO.FixeKosten.CollectionChanged -= VmPosition_CollectionChanged;
                    _vmKlientenbudgetDTO.VariableKosten.CollectionChanged -= VmPosition_CollectionChanged;
                    _vmKlientenbudgetDTO.VmKlientenbudget.PropertyChanged -= VmKlientenbudget_PropertyChanged;
                }

                _vmKlientenbudgetDTO = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VmKlientenbudgetDTO);

                if (_vmKlientenbudgetDTO != null)
                {
                    _vmKlientenbudgetDTO.Vermoegen.CollectionChanged += VmPosition_CollectionChanged;
                    _vmKlientenbudgetDTO.Einnahmen.CollectionChanged += VmPosition_CollectionChanged;
                    _vmKlientenbudgetDTO.FixeKosten.CollectionChanged += VmPosition_CollectionChanged;
                    _vmKlientenbudgetDTO.VariableKosten.CollectionChanged += VmPosition_CollectionChanged;
                    _vmKlientenbudgetDTO.VmKlientenbudget.PropertyChanged += VmKlientenbudget_PropertyChanged;
                }
            }
        }

        private VmPositionDTOService Service
        {
            get { return (VmPositionDTOService)ServiceCRUD; }
        }

        #endregion

        #region EventHandlers

        private void VmKlientenbudget_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var gueltigAbName = PropertyName.GetPropertyName(() => VmKlientenbudgetDTO.VmKlientenbudget.GueltigAb);
            if (e.PropertyName == gueltigAbName)
            {
                ReloadXConfigElFreibetrag(gueltigAbName);
            }
        }

        private void VmPosition_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Service.UpdateBetragSaldoOtherPositions(null, VmKlientenbudgetDTO, null);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void ImportData()
        {
            ValidationResult = Service.ImportData(null, VmKlientenbudgetDTO.VmKlientenbudget, SelectedEntity);
            ValidationResult += SaveData(null);
        }

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init()
        {
            if (string.IsNullOrEmpty(Title) && Enum.IsDefined(typeof(LOVsGenerated.VmKategorie), VmKategorie))
            {
                var kategorie = _xLovService.GetLovCode(null, (int)VmKategorie, typeof(LOVsGenerated.VmKategorie).Name);
                Title = kategorie.Text;
            }

            if (VmKlientenbudgetDTO == null)
            {
                EntityList = null;
                return;
            }

            LoadData(null);
        }

        public void Init(LOVsGenerated.VmKategorie vmKategorie, VmKlientenbudgetDTO dto)
        {
            VmKategorie = vmKategorie;
            VmKlientenbudgetDTO = dto;

            Init();
        }

        public override void LoadData(IUnitOfWork unitOfWork)
        {
            switch (VmKategorie)
            {
                case LOVsGenerated.VmKategorie.Vermoegen:
                    EntityList = VmKlientenbudgetDTO.Vermoegen;
                    break;
                case LOVsGenerated.VmKategorie.Einnahmen:
                    EntityList = VmKlientenbudgetDTO.Einnahmen;
                    break;
                case LOVsGenerated.VmKategorie.FixeKosten:
                    EntityList = VmKlientenbudgetDTO.FixeKosten;
                    break;
                case LOVsGenerated.VmKategorie.VariableKosten:
                    EntityList = VmKlientenbudgetDTO.VariableKosten;
                    break;
            }

            GetXConfigElFreibetrag(unitOfWork);

            AddCommand.EvaluateCanExecute();
        }

        /// <summary>
        /// Eine neue Position wird erstellt.
        /// </summary>
        /// <returns></returns>
        public override KissServiceResult NewData()
        {
            // Liste von Positionsarten der Kategorie holen
            var positionsarten = _vmPositionsartService.GetPositionsartenOfCatogeroyToInsert(null, VmKategorie, new List<VmPositionDTO>(EntityList));
            VmPositionsart positionsart;

            // Es gibt nur eine Positionsart
            if (positionsarten.Count == 1)
            {
                positionsart = positionsarten.First();
            }
            else
            {
                // den User auswählen lassen
                var options = new List<QuestionAnswerOption>();

                foreach (var vmPositionsart in positionsarten)
                {
                    options.Add(new QuestionAnswerOption(vmPositionsart, vmPositionsart.Name));
                }

                var answer = RaiseQuestion("Bitte wählen Sie eine Positionsart", options, false);

                if (answer == null)
                {
                    return KissServiceResult.Ok();
                }

                positionsart = (VmPositionsart)answer.Tag;
            }

            // neue Position erstellen
            var result = base.NewData();

            if (!result)
            {
                return result;
            }

            // Werten aus der Positionsart setzen
            SelectedEntity.VmPosition.VmPositionsart = positionsart;
            SelectedEntity.VmPosition.Name = positionsart.Name;
            SelectedEntity.VmPosition.VmKlientenbudget = VmKlientenbudgetDTO.VmKlientenbudget;
            SelectedEntity.VmPosition.SortKey = positionsart.SortKey;

            Service.SetProperties(SelectedEntity);
            Service.UpdateBetragSaldoOtherPositions(null, VmKlientenbudgetDTO, SelectedEntity);

            // SortKey updaten
            VmPositionDTO previousEntity;

            if (IstFixeVermoegenPosition(SelectedEntity))
            {
                // Fixe Positionen anhand SortKey der Positionsart einfügen
                previousEntity = EntityList
                    .OrderBy(x => x.VmPosition.SortKey)
                    .LastOrDefault(x => x != SelectedEntity && x.VmPosition.VmPositionsart.SortKey < SelectedEntity.VmPosition.VmPositionsart.SortKey);
            }
            else
            {
                previousEntity = EntityList
                    .OrderBy(x => x.VmPosition.SortKey)
                    .LastOrDefault(x => x != SelectedEntity && !IstFixeVermoegenPosition(x));
            }

            if (previousEntity != null)
            {
                SelectedEntity.VmPosition.SortKey = previousEntity.VmPosition.SortKey + 1;

                // SortKey nachfolgender Positionen erhöhen
                MoveDownBelow(SelectedEntity);
            }

            return KissServiceResult.Ok();
        }

        public override KissServiceResult SaveData(IUnitOfWork unitOfWork)
        {
            // Save changed entities (move up/down)
            var changedEntities = EntityList.Where(x => x != SelectedEntity && x.ChangeTracker.State == ObjectState.Modified).ToList();
            var result = Service.SaveData(unitOfWork, changedEntities);

            if (!result)
            {
                return result;
            }

            return base.SaveData(unitOfWork);
        }

        #endregion

        #region Protected Methods

        protected override void OnSelectedEntityChanged(VmPositionDTO selectedEntity, VmPositionDTO deselectedEntity)
        {
            MoveUpCommand.EvaluateCanExecute();
            MoveDownCommand.EvaluateCanExecute();

            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);
        }

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            var vmPositionString = PropertyName.GetPropertyName(() => SelectedEntity.VmPosition) + ".";
            var isPositionSaldo = propertyName == vmPositionString + PropertyName.GetPropertyName(() => SelectedEntity.VmPosition.Saldo);
            var isPositionBetragMonatlich = propertyName ==
                                            vmPositionString + PropertyName.GetPropertyName(() => SelectedEntity.VmPosition.BetragMonatlich);
            var isPositionBetragJaehrlich = propertyName ==
                                            vmPositionString + PropertyName.GetPropertyName(() => SelectedEntity.VmPosition.BetragJaehrlich);

            if (isPositionSaldo || isPositionBetragMonatlich || isPositionBetragJaehrlich)
            {
                Service.UpdateBetragSaldoOtherPositions(null, VmKlientenbudgetDTO, SelectedEntity);
            }
        }

        #endregion

        #region Private Static Methods

        private static bool IstFixeVermoegenPosition(VmPositionDTO position)
        {
            if (position == null || position.VmPosition == null || position.VmPosition.VmPositionsart == null)
            {
                return false;
            }

            var type = position.VmPosition.VmPositionsart.VmPositionsartTypEnum;

            return type == LOVsGenerated.VmPositionsartTyp.VermElBerechnung ||
                   type == LOVsGenerated.VmPositionsartTyp.VermElFreibetrag ||
                   type == LOVsGenerated.VmPositionsartTyp.VermTotal;
        }

        #endregion

        #region Private Methods

        private bool CanMoveDown()
        {
            if (SelectedEntity == null || IsReadOnly || IstFixeVermoegenPosition(SelectedEntity))
            {
                return false;
            }

            var next = EntityList.OrderBy(x => x.VmPosition.SortKey).FirstOrDefault(x => x.VmPosition.SortKey > SelectedEntity.VmPosition.SortKey);

            if (next == null)
            {
                return false;
            }

            return !IstFixeVermoegenPosition(next);
        }

        private bool CanMoveUp()
        {
            if (SelectedEntity == null || IsReadOnly || IstFixeVermoegenPosition(SelectedEntity))
            {
                return false;
            }

            var previous = EntityList.FirstOrDefault(x => x.VmPosition.SortKey < SelectedEntity.VmPosition.SortKey);
            return previous != null;
        }

        private void GetXConfigElFreibetrag(IUnitOfWork unitOfWork)
        {
            // EL-Freibetrag-Config-Werte
            const string configElFreibetragAlleinstehend = @"System\Vormundschaft\Klientenbudget\ElFreibetragAlleinstehend";
            const string configElFreibetragEhepaar = @"System\Vormundschaft\Klientenbudget\ElFreibetragEhepaar";
            const string configElFreibetragWaisenKinderMitRentenanspruch = @"System\Vormundschaft\Klientenbudget\ElFreibetragWaisenKinderMitRentenanspruch";

            var configService = Container.Resolve<XConfigService>();
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var alleinstehend = configService.GetConfigValue<decimal>(
                configElFreibetragAlleinstehend, VmKlientenbudgetDTO.VmKlientenbudget.GueltigAb, 0);
            var ehepaar = configService.GetConfigValue<decimal>(
                configElFreibetragEhepaar, VmKlientenbudgetDTO.VmKlientenbudget.GueltigAb, 0);
            var waisenUndKinder = configService.GetConfigValue<decimal>(
                configElFreibetragWaisenKinderMitRentenanspruch, VmKlientenbudgetDTO.VmKlientenbudget.GueltigAb, 0);

            ElFreibetragListe = new ObservableCollection<ElFreibetrag>
            {
                new ElFreibetrag(),
                new ElFreibetrag { Text = "Alleinstehende Person", Betrag = alleinstehend, KeyPath = configElFreibetragAlleinstehend },
                new ElFreibetrag { Text = "Ehepaar", Betrag = ehepaar, KeyPath = configElFreibetragEhepaar },
                new ElFreibetrag { Text = "Waisen und Kinder mit Rentenanspruch", Betrag = waisenUndKinder, KeyPath = configElFreibetragWaisenKinderMitRentenanspruch },
                new ElFreibetrag { Text = "nicht relevant", Betrag = 0 }
            };
        }

        /// <summary>
        /// Moves all positions that have a greater or equal SortKey below the specified entity.
        /// </summary>
        /// <param name="entity"></param>
        private void MoveDownBelow(VmPositionDTO entity)
        {
            var list = EntityList.Where(x => x != entity && x.VmPosition.SortKey >= entity.VmPosition.SortKey).ToList();

            foreach (var dto in list)
            {
                dto.VmPosition.SortKey++;
            }

            RefreshCommands();
            OnMoveCommandExecuted();
        }

        private void MoveDown()
        {
            var next = EntityList
                .OrderBy(x => x.VmPosition.SortKey)
                .FirstOrDefault(x => x.VmPosition.SortKey > SelectedEntity.VmPosition.SortKey);

            if (next != null)
            {
                next.VmPosition.SortKey = SelectedEntity.VmPosition.SortKey;
                SelectedEntity.VmPosition.SortKey++;

                RefreshCommands();
                OnMoveCommandExecuted();
            }
        }

        private void MoveUp()
        {
            var prev = EntityList
                .OrderBy(x => x.VmPosition.SortKey)
                .LastOrDefault(x => x.VmPosition.SortKey < SelectedEntity.VmPosition.SortKey);

            if (prev != null)
            {
                SelectedEntity.VmPosition.SortKey = prev.VmPosition.SortKey;
                prev.VmPosition.SortKey++;

                RefreshCommands();
                OnMoveCommandExecuted();
            }
        }

        private void OnMoveCommandExecuted()
        {
            if (MoveCommandExecuted != null)
            {
                MoveCommandExecuted(this, EventArgs.Empty);
            }
        }

        private void RefreshCommands()
        {
            AddCommand.EvaluateCanExecute();
            MoveUpCommand.EvaluateCanExecute();
            MoveDownCommand.EvaluateCanExecute();
        }

        private void ReloadXConfigElFreibetrag(string gueltigAbName)
        {
            DateTime originalGueltigAb;

            var gultigAbFound = VmKlientenbudgetDTO.VmKlientenbudget.OriginalValues.TryGetValue(gueltigAbName, out originalGueltigAb);

            if (gultigAbFound && originalGueltigAb != VmKlientenbudgetDTO.VmKlientenbudget.GueltigAb)
            {
                var elFreibetragPosition = VmKlientenbudgetDTO.Vermoegen
                    .FirstOrDefault(p => p.VmPosition.VmPositionsart.VmPositionsartTypEnum == LOVsGenerated.VmPositionsartTyp.VermElFreibetrag);

                string keyPath = "";

                if (elFreibetragPosition != null)
                {
                    var elFreibetragDropDown = ElFreibetragListe.FirstOrDefault(x => x.Betrag == elFreibetragPosition.VmPosition.Saldo);

                    if (elFreibetragDropDown != null)
                    {
                        keyPath = elFreibetragDropDown.KeyPath;
                    }
                }

                GetXConfigElFreibetrag(null);

                if (elFreibetragPosition != null)
                {
                    var firstOrDefault = ElFreibetragListe.FirstOrDefault(x => x.KeyPath == keyPath);
                    if (firstOrDefault != null)
                    {
                        var newConfigValue = firstOrDefault.Betrag;
                        if ((elFreibetragPosition.VmPosition.Saldo ?? 0) != newConfigValue)
                        {
                            elFreibetragPosition.VmPosition.Saldo = newConfigValue;
                        }
                    }

                    Service.UpdateBetragSaldoOtherPositions(null, VmKlientenbudgetDTO, elFreibetragPosition);
                }
            }
        }

        #endregion

        #endregion

        #region Nested Types

        public class ElFreibetrag
        {
            #region Properties

            public decimal? Betrag
            {
                get;
                set;
            }

            public string KeyPath
            {
                get;
                set;
            }

            public string Text
            {
                get;
                set;
            }

            #endregion
        }

        #endregion
    }
}