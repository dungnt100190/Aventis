using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

using Kiss.BL.Kbu;
using Kiss.BL.KissSystem;
using Kiss.BL.Wsh;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Model;
using Kiss.Model.DTO.Kbu;
using Kiss.Model.DTO.Wsh;
using Kiss.Utilities;

using DevExpress.Data;

using Container = Kiss.Interfaces.IoC.Container;

namespace Kiss.UI.ViewModel.Wsh
{
    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class WshGrundBudgetAbzugVM : ViewModelCRUDListBase<WshAbzugDTO>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string DATUM_BIS_MEHR_ALS_12_MONATE_IN_ZUKUNFT = "DATUM_BIS_MEHR_ALS_12_MONATE_IN_ZUKUNFT";
        private const string DATUM_VON_MEHR_ALS_12_MONATE_IN_ZUKUNFT = "DATUM_VON_MEHR_ALS_12_MONATE_IN_ZUKUNFT";

        private readonly Dictionary<string, QuestionAnswerOption> _questionsAndAnswers = new Dictionary<string, QuestionAnswerOption>();

        #endregion

        #region Private Fields

        private ObservableCollection<XLOVCode> _abschlussAktion;
        private bool _dauerauftragAktiv;
        private LOVsGenerated.SysEditMode _editModeBetrifftPerson;
        private List<int> _gblKontoIds;
        private bool _inklAbgeschlossene;
        private Dictionary<string, bool> _isFieldReadonly;
        private Dictionary<string, Visibility> _isFieldVisible;
        private ObservableCollection<WshKategorie> _kategorie;
        private SearchForStringEventHandler _kontoSearchEventHandler;
        private ICommand _kopierenCommand;
        private ICommand _newDataCommand;
        private ObservableCollection<BaPerson> _personenHaushalt;
        private ObservableCollection<BaPerson> _personenHaushaltAlle;
        private ObservableCollection<XLOVCode> _splittingart;
        private decimal _summaryBetragMonatlich;
        private decimal _summaryProzentGbl;
        private decimal _summarySaldo;
        private BackgroundWorker _loadDataBackgroundWorker;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshGrundBudgetAbzugVM"/> class.
        /// </summary>
        public WshGrundBudgetAbzugVM()
            : base(Container.Resolve<WshAbzugDTOService>())
        {
        }

        #endregion

        #region Properties

        public ObservableCollection<XLOVCode> AbschlussAktion
        {
            get { return _abschlussAktion; }
            set
            {
                if (_abschlussAktion != value)
                {
                    _abschlussAktion = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => AbschlussAktion);
                }
            }
        }

        public WshAbzugBudgetPositionVM BudgetPositionVM
        {
            get;
            set;
        }

        public bool DauerauftragAktiv
        {
            get { return _dauerauftragAktiv; }
            set
            {
                if (_dauerauftragAktiv == value)
                {
                    return;
                }
                _dauerauftragAktiv = value;

                if (SelectedEntity != null)
                {
                    BudgetPositionVM.LoadData(SelectedEntity, true);
                }

                NotifyPropertyChanged.RaisePropertyChanged(() => DauerauftragAktiv);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsEditPanelEnabled);
            }
        }

        public int FaLeistungId
        {
            get;
            private set;
        }

        public bool InklAbgeschlossene
        {
            get { return _inklAbgeschlossene; }
            set
            {
                if (_inklAbgeschlossene == value)
                {
                    return;
                }

                _inklAbgeschlossene = value;
                LoadData(null);
            }
        }

        /// <summary>
        /// Ob Dateneingaben gemacht werden können.
        /// </summary>
        public bool IsEditPanelEnabled
        {
            get
            {
                if (SelectedEntity == null || DauerauftragAktiv)
                {
                    return false;
                }

                return true;
            }
        }

        public Dictionary<string, bool> IsFieldReadonly
        {
            get { return _isFieldReadonly; }
            set
            {
                _isFieldReadonly = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => IsFieldReadonly);
            }
        }

        public Dictionary<string, Visibility> IsFieldVisible
        {
            get { return _isFieldVisible; }
            set
            {
                _isFieldVisible = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => IsFieldVisible);
            }
        }

        public ObservableCollection<WshKategorie> Kategorie
        {
            get { return _kategorie; }

            set
            {
                if (_kategorie == value)
                {
                    return;
                }

                _kategorie = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Kategorie);
            }
        }

        public SearchForStringEventHandler KontoSearchEventHandler
        {
            get { return _kontoSearchEventHandler; }
            private set
            {
                _kontoSearchEventHandler = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => KontoSearchEventHandler);
            }
        }

        public ObservableCollection<BaPerson> PersonenHaushalt
        {
            get { return _personenHaushalt; }
            set
            {
                _personenHaushalt = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => PersonenHaushalt);
            }
        }

        /// <summary>
        /// Personen welche zu irgendeinem Zeitpunkt im Haushalt unterstützt wurden.
        /// </summary>
        public ObservableCollection<BaPerson> PersonenHaushaltAlle
        {
            get { return _personenHaushaltAlle; }
            set
            {
                _personenHaushaltAlle = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => PersonenHaushaltAlle);
            }
        }

        public ObservableCollection<XLOVCode> Splittingart
        {
            get { return _splittingart; }
            set
            {
                if (_splittingart != value)
                {
                    _splittingart = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => Splittingart);
                }
            }
        }

        private WshAbzugDTOService Service
        {
            get { return (WshAbzugDTOService)ServiceCRUD; }
        }

        #endregion

        #region Commands

        public ICommand KopierenCommand
        {
            get
            {
                if (_kopierenCommand == null)
                {
                    _kopierenCommand = new BaseCommand(
                        AbzugKopieren, 
                        o => Maskenrecht.CanInsert && SelectedEntity != null && SelectedEntity.ChangeTracker.State != ObjectState.Added
                    );
                }

                return _kopierenCommand;
            }
        }

        public ICommand NewDataCommand
        {
            get
            {
                if (_newDataCommand == null)
                {
                    _newDataCommand = new BaseCommand(NewData, 
                        o => Maskenrecht.CanInsert && SelectedEntity == null || SelectedEntity.ChangeTracker.State != ObjectState.Added
                    );
                }

                return _newDataCommand;
            }
        }

        #endregion

        #region EventHandlers

        public void CalculateSummary_BetragMonatlich(CustomSummaryEventArgs customSummaryEventArgs)
        {
            CalculateSummary(customSummaryEventArgs, ref _summaryBetragMonatlich);
        }

        public void CalculateSummary_ProzentGbl(CustomSummaryEventArgs customSummaryEventArgs)
        {
            CalculateSummary(customSummaryEventArgs, ref _summaryProzentGbl);
        }

        public void CalculateSummary_Saldo(CustomSummaryEventArgs customSummaryEventArgs)
        {
            CalculateSummary(customSummaryEventArgs, ref _summarySaldo);
        }

        #endregion

        #region Methods

        #region Public Methods

        public void CurrentSelectedEntityChanged(WshAbzugDTO selectedEntity, WshAbzugDTO deselectedEntity)
        {
            UpdateIsFieldReadonly(selectedEntity);
            UpdateIsFieldVisible(selectedEntity);
        }

        public override KissServiceResult DeleteData(IUnitOfWork unitOfWork)
        {
            //Wenn DauerauftragAktiv, dann dürfen keine Positionen gelöscht werden.
            if (DauerauftragAktiv)
            {
                return KissServiceResult.Ok();
            }

            return base.DeleteData(unitOfWork);
        }

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init(int faLeistungId, WshAbzugBudgetPositionVM wshAbzugBudgetPositionVM)
        {
            FaLeistungId = faLeistungId;
            BudgetPositionVM = wshAbzugBudgetPositionVM;

            // SelectedEntityChanged event handler registrieren.
            SelectedEntityChanged += CurrentSelectedEntityChanged;

            // gbl kontoId holen
            var kbuKontoService = Container.Resolve<KbuKontoService>();
            _gblKontoIds = kbuKontoService.GetAllGblKontoIds(null);

            // Kategorie
            var wshKategorieService = Container.Resolve<WshKategorieService>();
            Kategorie = new ObservableCollection<WshKategorie>(wshKategorieService.GetKategorien(null, true));

            // LOVs holen
            InitLovs();

            // Personen im Haushalt
            InitPersonenImHaushalt(faLeistungId);

            // Eventhandler für Suche
            InitEventHandler();

            //Dauerauftrag initialisieren.
            InitDauerAuftrag(faLeistungId);

            _loadDataBackgroundWorker = new BackgroundWorker();
            _loadDataBackgroundWorker.DoWork += (s, e) =>
            {
                IsBusy = true;
                try
                {
                    LoadData(null);
                }
                finally
                {
                    IsBusy = false;
                }
            };
            _loadDataBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init()
        {
            // TODO: Search(null);
        }

        public override bool JumpToPath(System.Collections.Specialized.HybridDictionary parameters)
        {
            if (parameters.Contains("WshAbzugID"))
            {
                if (IsBusy)
                {
                    //the data is loaded asynchronously. So we have to wait until is loaded.
                    _loadDataBackgroundWorker.RunWorkerCompleted += (s, e) =>
                    {
                        Tools.DoEvents(); //let the Grid to select the first row before we jump to the correct row

                        JumpToPath(parameters); 
                    };
                    return true;
                }

                int? wshAbzugId = parameters["WshAbzugID"] as int?;
                if (wshAbzugId.HasValue)
                {
                    //select specific abzug
                    var entityToSelect = EntityList.Where(a => a.WshAbzug.WshAbzugID == wshAbzugId.Value).SingleOrDefault();
                    if (entityToSelect != null)
                    {
                        SelectedEntity = entityToSelect;
                    }
                    else
                    {
                        SelectedEntity = EntityList.FirstOrDefault();
                    }
                    return true;
                }
            }
            return false;
        }

        public override void LoadData(IUnitOfWork unitOfWork)
        {
            EntityList = Service.GetByFaLeistungId(unitOfWork, FaLeistungId, InklAbgeschlossene);
        }

        public override KissServiceResult NewData()
        {
            //Wenn DauerauftragAktiv, dann dürfen keine Positionen erstellt werden.
            if (DauerauftragAktiv)
            {
                return KissServiceResult.Ok();
            }

            var availableOptions = new List<QuestionAnswerOption>();
            Kategorie.ToList().ForEach(k => availableOptions.Add(new QuestionAnswerOption(k, k.Name))); //k: Tag, k.Name: Caption

            var result = RaiseQuestion("Kategorie", availableOptions, false);
            if (result == null)
            {
                return KissServiceResult.Ok();
            }

            var selectedKategorie = (WshKategorie)result.Tag;

            return NewData(selectedKategorie);
        }

        public override KissServiceResult SaveData(IUnitOfWork unitOfWork)
        {
            //make sure, the list of Monatsbudget-Positionen are also saved
            BudgetPositionVM.SaveData(unitOfWork);

            if (!Service.NeedToSaveData(SelectedEntity))
            {
                return KissServiceResult.Ok();
            }

            try
            {
                // Call Service.SavePosition as lond as there is a question that's not answered
                // Use a memento because the entity is set to Unchanged in the UnitOfWork.SaveChanges() and not after that the last transaction has been committed
                var originalMemento = ObjectCloner.Clone(SelectedEntity);
                WshAbzugDTO memento = null;
                ValidationResult = Service.SaveData(unitOfWork, SelectedEntity, _questionsAndAnswers);
                bool doLoop = true;
                while (ValidationResult.IsQuestion && doLoop)
                {
                    var questionServiceResult = ValidationResult.GetQuestions().FirstOrDefault();
                    if (questionServiceResult != null)
                    {
                        var answer = RaiseQuestion(questionServiceResult.Message, questionServiceResult.AvailableAnswerOptions, false);
                        if (answer != null)
                        {
                            _questionsAndAnswers[questionServiceResult.MessageID] = answer;
                            memento = ObjectCloner.Clone(originalMemento);
                            ValidationResult = Service.SaveData(unitOfWork, memento, _questionsAndAnswers);
                        }
                        else
                        {
                            doLoop = false;
                        }
                    }
                }

                if (memento != null)
                {
                    SelectedEntity = memento;
                }
            }
            finally
            {
                //the next time, the user should be asked again
                ClearQuestionCache(_questionsAndAnswers);
            }

            if (ValidationResult)
            {
                CreateMemento(SelectedEntity);
                UpdateIsFieldReadonly(SelectedEntity);
                UpdateIsFieldVisible(SelectedEntity);
            }

            BudgetPositionVM.LoadData(SelectedEntity, true);

            return ValidationResult;
        }

        public void UpdateBetragGblProzent(WshAbzugDTO abzugDTO)
        {
            Service.SetBetragMonatlich(null, abzugDTO);
            Service.SetGblProzent(null, abzugDTO);
        }

        #endregion

        #region Protected Methods

        protected override void OnSelectedEntityChanged(WshAbzugDTO selectedEntity, WshAbzugDTO deselectedEntity)
        {
            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);
            NotifyPropertyChanged.RaisePropertyChanged(() => IsEditPanelEnabled);

            BudgetPositionVM.LoadData(selectedEntity);
        }

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            if (SelectedEntity.ChangeTracker.State == ObjectState.Deleted)
            {
                return;
            }

            var wshAbzugString = PropertyName.GetPropertyName(() => SelectedEntity.WshAbzug) + ".";
            var wshAbzug = SelectedEntity.WshAbzug;

            var wshGrundbudgetPositionString = wshAbzugString + PropertyName.GetPropertyName(() => wshAbzug.WshGrundbudgetPosition) + ".";
            var wshGrundbudgetPosition = wshAbzug.WshGrundbudgetPosition;

            var wshPositionPropertyName = PropertyName.GetPropertyName(() => SelectedEntity.WshPosition);
            var wshPositionString = wshPositionPropertyName + ".";

            var propertyNameKonto = wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => wshAbzug.WshGrundbudgetPosition.KbuKonto);
            var propertyNameKontoID = wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => wshAbzug.WshGrundbudgetPosition.KbuKontoID);

            // Konto has changed
            if ((propertyName == propertyNameKonto || propertyName == propertyNameKontoID) &&
                wshAbzug.WshGrundbudgetPosition.KbuKonto != null)
            {
                UpdateIsFieldVisible(SelectedEntity);
                Service.SetGblProzent(null, SelectedEntity);
            }

            // Konto or DatumVon has changed --> check if we have to update HaushaltPersonen
            if (propertyName == wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => wshGrundbudgetPosition.DatumVon)
                || propertyName == wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => wshGrundbudgetPosition.KbuKonto))
            {
                //update 'Betrifft Person' Combobox
                UpdateHaushaltPersonen(Stichtag);

                // erste Person oder UE auswählen wenn es nur eine in der Liste gibt
                if (PersonenHaushalt.Count() == 1)
                {
                    wshGrundbudgetPosition.BaPerson = PersonenHaushalt[0];
                }
                UpdateIsFieldReadonly(SelectedEntity);
            }

            // MonatlichWiederholend
            if (propertyName == wshAbzugString + PropertyName.GetPropertyName(() => wshAbzug.MonatlichWiederholend))
            {
                UpdateIsFieldVisible(SelectedEntity);
                UpdateIsFieldReadonly(SelectedEntity);
                wshAbzug.WshGrundbudgetPosition.BetragTotal = null;
            }

            // BetragTotal, BetragMonatlich, DatumVon
            if (propertyName == wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => wshAbzug.WshGrundbudgetPosition.BetragTotal) ||
                propertyName == wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => wshAbzug.WshGrundbudgetPosition.BetragMonatlich) ||
                propertyName == wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => wshAbzug.WshGrundbudgetPosition.DatumVon))
            {
                Service.SetVoraussichtlicheDauerUndSaldo(null, SelectedEntity);
            }

            // DatumBis
            if (propertyName == wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => wshAbzug.WshGrundbudgetPosition.DatumBis))
            {
                ValidateDatumBis();
            }

            // BetragMonatlich
            if (propertyName == wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => wshAbzug.WshGrundbudgetPosition.BetragMonatlich))
            {
                Service.SetGblProzent(null, SelectedEntity);
            }

            // GblAbzugProzent
            if (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.GblAbzugProzent))
            {
                Service.SetBetragMonatlich(null, SelectedEntity);
            }

            // DatumVon
            if (propertyName == wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => wshAbzug.WshGrundbudgetPosition.DatumVon))
            {
                ValidationResult += Service.CanUpdateDatumVon(SelectedEntity);
                ValidateDatumVon();
            }

            // WshPosition oder Betrag einer WshPosition
            if (propertyName == wshPositionPropertyName ||
                propertyName == wshPositionString + PropertyName.GetPropertyName(() => new WshPosition().Betrag))
            {
                Service.SetVoraussichtlicheDauer(SelectedEntity);
            }
        }

        public DateTime? Stichtag
        {
            get
            {
                if(SelectedEntity == null
                    || SelectedEntity.WshAbzug == null
                    || SelectedEntity.WshAbzug.WshGrundbudgetPosition == null)
                {
                    return null;
                }

                var wshGrundbudgetPosition = SelectedEntity.WshAbzug.WshGrundbudgetPosition;

                return wshGrundbudgetPosition.DatumVon != Constant.SqlDateTimeMin
                             ? wshGrundbudgetPosition.DatumVon
                             : (DateTime?)null;
            }

        }
        #endregion

        #region Private Static Methods

        private static void AddFieldVisibilityToDictionary(Dictionary<string, Visibility> isFieldVisible, string fieldName, bool isVisible)
        {
            isFieldVisible.Add(fieldName, isVisible ? Visibility.Visible : Visibility.Hidden);
        }

        #endregion

        #region Private Methods

        private void AbzugKopieren(object obj)
        {
            ValidationResult = NewData(SelectedEntity);
        }

        private void CalculateSummary(CustomSummaryEventArgs customSummaryEventArgs, ref decimal summary)
        {
            switch (customSummaryEventArgs.SummaryProcess)
            {
                case CustomSummaryProcess.Start:
                    summary = 0;
                    break;

                case CustomSummaryProcess.Calculate:
                    decimal? fieldValue = customSummaryEventArgs.FieldValue as decimal?;
                    var entity = EntityList[customSummaryEventArgs.RowHandle];
                    //nur nicht-abgeschlossene Abzüge sollen summiert werden
                    if (!entity.WshAbzug.IstAbgeschlossen)
                    {
                        summary += fieldValue ?? 0;
                    }

                    break;

                case CustomSummaryProcess.Finalize:
                    customSummaryEventArgs.TotalValue = summary;
                    break;
            }
        }

        /// <summary>
        /// Initiealisiert den Dauerauftrag. Zur Zeit auf der Leistung.
        /// </summary>
        /// <param name="faLeistungId"></param>
        private void InitDauerAuftrag(int faLeistungId)
        {
            var wshLeistungService = Container.Resolve<WshLeistungService>();
            _dauerauftragAktiv = wshLeistungService.IsDauerauftragGrundbudgetAktiviert(null, faLeistungId);
            NotifyPropertyChanged.RaisePropertyChanged(() => DauerauftragAktiv);
        }

        private void InitEventHandler()
        {
            //Eventhandler für Suche nach Konti.
            KontoSearchEventHandler = SearchKonto;
        }

        private void InitLovs()
        {
            var xlovService = Container.Resolve<XLovService>();

            //AbschlussGrund
            var enumWshAbzugAbschlussAktionName = typeof(LOVsGenerated.WshAbzugAbschlussAktion).Name;
            AbschlussAktion = new ObservableCollection<XLOVCode>(xlovService.GetLovCodeByLovName(null, enumWshAbzugAbschlussAktionName));

            //Splittingart
            var enumSplittingartName = typeof(LOVsGenerated.WshSplittingart).Name;
            Splittingart = new ObservableCollection<XLOVCode>(xlovService.GetLovCodeByLovName(null, enumSplittingartName));
        }

        private void InitPersonenImHaushalt(int faLeistungId)
        {
            //Personen im Haushalt (für Grid).
            var haushaltPersonService = Container.Resolve<WshHaushaltPersonService>();
            PersonenHaushaltAlle = haushaltPersonService.GetPersonenHaushaltAlle(null, faLeistungId);

            //Personen im Haushalt (für DetailPanel)
            UpdateHaushaltPersonen(null);
        }

        private void NewData(object obj)
        {
            var kategorie = obj as WshKategorie;

            if (kategorie == null)
            {
                return;
            }

            NewData(kategorie);
        }

        private KissServiceResult NewData(WshKategorie kategorie)
        {
            var result = base.NewData();

            if (!result.IsOk)
            {
                return result;
            }

            Service.UpdateNewData(SelectedEntity, kategorie, FaLeistungId);
            BudgetPositionVM.LoadData(SelectedEntity);

            UpdateIsFieldReadonly(SelectedEntity);
            UpdateIsFieldVisible(SelectedEntity);

            return KissServiceResult.Ok();
        }

        private KissServiceResult NewData(WshAbzugDTO originalAbzugDto)
        {
            WshAbzugDTO newAbzugDto;

            var result = Service.NewData(originalAbzugDto, out newAbzugDto);

            if (result)
            {
                EntityList.Add(newAbzugDto);
                SelectedEntity = newAbzugDto;
            }

            ValidationResult = result;
            return result;
        }

        /// <summary>
        /// Suche nach einem Konto.
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        private List<object> SearchKonto(string searchString)
        {
            var list = new List<object>();
            var kontoService = Container.Resolve<WshKbuKontoService>();

            var kontoSearchParam = new KbuKontoSearchDTO
            {
                SearchString = searchString,
                WshKategorie = (LOVsGenerated.WshKategorie)SelectedEntity.WshAbzug.WshGrundbudgetPosition.WshKategorieID,
                Datum = DateTime.Today,
                Grundbudget = true,
                LeistungWsh = true,
            };
            var result = kontoService.SearchKonto(null, kontoSearchParam).ToList();
            result.ForEach(list.Add);

            return list;
        }

        private void UpdateHaushaltPersonen(DateTime? stichtag)
        {
            if (SelectedEntity != null)
            {
                _editModeBetrifftPerson = Service.GetSysEditModePersonBetrifft(
                    SelectedEntity.WshAbzug.WshGrundbudgetPosition.KbuKontoID,
                    SelectedEntity.WshAbzug.WshGrundbudgetPosition.DatumVon,
                    SelectedEntity.WshAbzug.WshGrundbudgetPosition.DatumBis);
            }
            else
            {
                _editModeBetrifftPerson = LOVsGenerated.SysEditMode.ReadOnly;
            }

            PersonenHaushalt = new ObservableCollection<BaPerson>();

            if (_editModeBetrifftPerson == LOVsGenerated.SysEditMode.Normal
                || _editModeBetrifftPerson == LOVsGenerated.SysEditMode.ReadOnly)
            {
                PersonenHaushalt.Add(
                    new BaPerson
                    {
                        BaPersonID = -1,
                        Name = "UE",
                        Vorname = null
                    });
            }

            if (_editModeBetrifftPerson == LOVsGenerated.SysEditMode.Normal
                || _editModeBetrifftPerson == LOVsGenerated.SysEditMode.Required)
            {
                var haushaltPersonService = Container.Resolve<WshHaushaltPersonService>();
                var haushaltPersonen = stichtag.HasValue
                                           ? haushaltPersonService.GetHaushaltPersonen(null, FaLeistungId, stichtag.Value, true)
                                           : haushaltPersonService.GetHaushaltPersonen(null, FaLeistungId, true);

                var unterstuetztePersonen = haushaltPersonen.Select(hp => hp.BaPerson).ToList();
                unterstuetztePersonen.ForEach(PersonenHaushalt.Add);
            }
        }

        private void UpdateIsFieldReadonly(WshAbzugDTO abzugDto)
        {
            if (abzugDto == null)
            {
                return;
            }

            //Enthält pro Feld ein bool. Wenn true => Feld ist readonly.
            var dict = new Dictionary<string, bool>();

            var istRueckerstattung = abzugDto.WshAbzug.WshGrundbudgetPosition.IstRueckerstattung;
            var istAbgeschlossen = abzugDto.WshAbzug.IstAbgeschlossen;
            var hatGrueneGelbePositionen = !abzugDto.HatNurGrauePositionen;
            var onlyOnePersonAvailable = (PersonenHaushalt.Count == 1 && PersonenHaushalt.FirstOrDefault().BaPersonID == -1);
            var betrifftPersonIsMandatoryOrOptional = _editModeBetrifftPerson == LOVsGenerated.SysEditMode.Normal
                                                      || _editModeBetrifftPerson == LOVsGenerated.SysEditMode.Required;

            dict.Add("Kategorie", true);
            dict.Add("MonatlichWiederholend", istAbgeschlossen || hatGrueneGelbePositionen);
            dict.Add("Bezeichnung", istAbgeschlossen);
            dict.Add("Kostenart", istAbgeschlossen || hatGrueneGelbePositionen);
            dict.Add("Betrifft", istAbgeschlossen || hatGrueneGelbePositionen || onlyOnePersonAvailable || !betrifftPersonIsMandatoryOrOptional);
            dict.Add("BetragTotal", istAbgeschlossen || abzugDto.WshAbzug.MonatlichWiederholend);
            dict.Add("BetragMonatlich", istAbgeschlossen || istRueckerstattung);
            dict.Add("DatumVon", istAbgeschlossen);
            dict.Add("DatumBis", istAbgeschlossen);
            dict.Add("DatumEntscheid", istAbgeschlossen);
            dict.Add("GblAktuell", true);
            dict.Add("GblAbzugProzent", istAbgeschlossen);
            dict.Add("Bemerkung", false);
            dict.Add("Abschluss", istAbgeschlossen);

            IsFieldReadonly = dict;
        }

        private void UpdateIsFieldVisible(WshAbzugDTO abzugDto)
        {
            if (abzugDto == null)
            {
                return;
            }

            var istVerrechnung = abzugDto.WshAbzug.WshGrundbudgetPosition.IstVerrechnung;
            var istRueckerstattung = abzugDto.WshAbzug.WshGrundbudgetPosition.IstRueckerstattung;
            var istSanktion = abzugDto.WshAbzug.WshGrundbudgetPosition.IstSanktion;

            var dict = new Dictionary<string, Visibility>();

            // Entscheidbasiert
            AddFieldVisibilityToDictionary(dict, "DatumEntscheid", istRueckerstattung || istSanktion);

            // Button GBL/Zulagen
            AddFieldVisibilityToDictionary(dict, "ButtonGblZulagen", istRueckerstattung);

            // Monatlich wiederholend
            AddFieldVisibilityToDictionary(dict, "MonatlichWiederholend", istVerrechnung);

            // Total Betrag
            AddFieldVisibilityToDictionary(dict, "BetragTotal", istVerrechnung || istRueckerstattung);

            // VoraussichtlicheDauer
            AddFieldVisibilityToDictionary(dict, "VoraussichtlicheDauer", istRueckerstattung || istVerrechnung && !abzugDto.WshAbzug.MonatlichWiederholend);

            // GblAktuell und GblAbzugProzent
            var istGblKonto = _gblKontoIds.Contains(abzugDto.WshAbzug.WshGrundbudgetPosition.KbuKontoID);
            AddFieldVisibilityToDictionary(dict, "GblAktuell", istGblKonto);
            AddFieldVisibilityToDictionary(dict, "GblAbzugProzent", istGblKonto);

            IsFieldVisible = dict;
        }

        private void ValidateDatumBis()
        {
            if (SelectedEntity != null)
            {
                var datumBis = SelectedEntity.WshAbzug.WshGrundbudgetPosition.DatumBis;
                DateTime todayInAYear = DateTime.Today.AddYears(1);

                if (datumBis.HasValue && datumBis.Value >= todayInAYear)
                {
                    if (!ValidationResult.ContainsWarning(DATUM_BIS_MEHR_ALS_12_MONATE_IN_ZUKUNFT))
                    {
                        ValidationResult += new KissServiceResult(
                            KissServiceResult.ResultType.Warning,
                            DATUM_BIS_MEHR_ALS_12_MONATE_IN_ZUKUNFT,
                            "Das gültig bis-Datum liegt weiter als ein Jahr in der Zukunft. Bitte überprüfen Sie das eingegebene Datum.");
                    }
                }
                else
                {
                    if (ValidationResult.ContainsWarning(DATUM_BIS_MEHR_ALS_12_MONATE_IN_ZUKUNFT))
                    {
                        ValidationResult.RemoveWarning(DATUM_BIS_MEHR_ALS_12_MONATE_IN_ZUKUNFT);
                    }
                }
            }
        }

        private void ValidateDatumVon()
        {
            if (SelectedEntity != null)
            {
                var datumVon = SelectedEntity.WshAbzug.WshGrundbudgetPosition.DatumVon;
                DateTime todayInAYear = DateTime.Today.AddYears(1);

                if (datumVon >= todayInAYear)
                {
                    if (!ValidationResult.ContainsWarning(DATUM_VON_MEHR_ALS_12_MONATE_IN_ZUKUNFT))
                    {
                        ValidationResult += new KissServiceResult(
                            KissServiceResult.ResultType.Warning,
                            DATUM_VON_MEHR_ALS_12_MONATE_IN_ZUKUNFT,
                            "Das gültig von-Datum liegt weiter als ein Jahr in der Zukunft. Bitte überprüfen Sie das eingegebene Datum.");
                    }
                }
                else
                {
                    if (ValidationResult.ContainsWarning(DATUM_VON_MEHR_ALS_12_MONATE_IN_ZUKUNFT))
                    {
                        ValidationResult.RemoveWarning(DATUM_VON_MEHR_ALS_12_MONATE_IN_ZUKUNFT);
                    }
                }
            }
        }

        #endregion

        #endregion

        #region Other

        /*
        /// <summary>
        /// Gets the data from service.
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use (can be null)</param>
        public override void Search(IUnitOfWork unitOfWork)
        {
            EntityList = Service.GetData(unitOfWork);
        }
        */

        #endregion
    }
}
