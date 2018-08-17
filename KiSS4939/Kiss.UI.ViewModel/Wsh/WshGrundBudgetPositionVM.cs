using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

using Kiss.BL.Ba;
using Kiss.BL.KissSystem;
using Kiss.BL.Wsh;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.BA;
using Kiss.Model.DTO.Kbu;
using Kiss.Model.DTO.Wsh;
using Kiss.Utilities;

namespace Kiss.UI.ViewModel.Wsh
{

    #region Enumerations

    public enum FilterMode
    {
        AllePositionen,
        AktuellePositionen,
        KuenftigeUndAktuellePositionen
    }

    #endregion

    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class WshGrundBudgetPositionVM : ViewModelCRUDListBase<WshGrundbudgetPositionDTO>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string XCONFIG_WERTELISTEFILTER = @"System\WSH\Wertelistefilter";
        private readonly Dictionary<string, QuestionAnswerOption> _questionsAndAnswers = new Dictionary<string, QuestionAnswerOption>();

        #endregion

        #region Private Fields

        private bool _dauerauftragAktiv;
        private SearchForStringEventHandler _debitorSearchEventHandler;
        private LOVsGenerated.SysEditMode _editModeBetrifftPerson;
        private FilterMode _filterMode = FilterMode.KuenftigeUndAktuellePositionen;
        private ImageSource _hatBemerkungImageSource;
        private bool _isEditPanelVisible;
        private Dictionary<string, bool> _isFieldReadonly;
        private Dictionary<string, Visibility> _isFieldVisible;
        private ImageSource _istBewilligtImageSource;
        private ObservableCollection<WshKategorie> _kategorie = new ObservableCollection<WshKategorie>();

        /// <summary>
        /// List with all KbuKonto
        /// </summary>
        private SearchForStringEventHandler _kontoSearchEventHandler;

        private ICommand _neueAusgabeCommand;
        private ICommand _neueEinnahmeCommand;
        private ObservableCollection<XLOVCode> _periodizitaet;
        private ObservableCollection<BaPerson> _personenHaushalt = new ObservableCollection<BaPerson>();
        private ObservableCollection<BaPerson> _personenHaushaltAlle = new ObservableCollection<BaPerson>();
        private ICommand _showEditPanelCommand;
        private ObservableCollection<XLOVCode> _splittingart;
        private string _werteListeFilter;
        private ObservableCollection<XLOVCode> _zahlungsArt = new ObservableCollection<XLOVCode>();
        private SearchForStringEventHandler _zahlungswegSearchEventHandler;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshGrundBudgetPositionVM"/> class.
        /// </summary>
        public WshGrundBudgetPositionVM()
            : base(Container.Resolve<WshGrundbudgetPositionDTOService>())
        {
        }

        #endregion

        #region Properties

        public bool AktuellePositionen
        {
            get { return FilterMode == FilterMode.AktuellePositionen; }
            set
            {
                if (value)
                {
                    FilterMode = FilterMode.AktuellePositionen;
                }
            }
        }

        public bool AllePositionen
        {
            get { return FilterMode == FilterMode.AllePositionen; }
            set
            {
                if (value)
                {
                    FilterMode = FilterMode.AllePositionen;
                }
            }
        }

        /// <summary>
        /// Dauerauftrag aktiv ist auf Budgetebene, nicht Positionsebene.
        /// Property muss zu den Abzügen gepusht werden.
        /// </summary>
        public bool DauerauftragAktiv
        {
            get { return _dauerauftragAktiv; }
            set
            {
                if (_dauerauftragAktiv == value)
                {
                    return;
                }

                if (DauerAuftragAktievierenDeaktivieren(value))
                {
                    _dauerauftragAktiv = value;
                }
                NotifyPropertyChanged.RaisePropertyChanged(() => DauerauftragAktiv);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsEditPanelEnabled);
            }
        }

        public SearchForStringEventHandler DebitorSearchEventHandler
        {
            get { return _debitorSearchEventHandler; }
            private set
            {
                _debitorSearchEventHandler = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => DebitorSearchEventHandler);
            }
        }

        public bool ExistierenGrundbudgetPositionen
        {
            get { return Service.HasWshGrundbudgetPosition(null, FaLeistungID); }
        }

        public int FaLeistungID { get; private set; }

        public FilterMode FilterMode
        {
            get { return _filterMode; }
            set
            {
                if (value != _filterMode)
                {
                    _filterMode = value;
                    LoadData(null);
                }
            }
        }

        public ImageSource HatBemerkungImageSource
        {
            get { return _hatBemerkungImageSource; }
            private set
            {
                if (_hatBemerkungImageSource == value)
                {
                    return;
                }

                _hatBemerkungImageSource = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => HatBemerkungImageSource);
            }
        }

        public bool IsBetrifftEnabled
        {
            get
            {
                if (SelectedEntity == null)
                {
                    return false;
                }

                if (PersonenHaushalt.Count == 1 && PersonenHaushalt.FirstOrDefault().BaPersonID == -1)
                {
                    return false;
                }

                return _editModeBetrifftPerson == LOVsGenerated.SysEditMode.Normal ||
                       _editModeBetrifftPerson == LOVsGenerated.SysEditMode.Required;
            }
        }

        /// <summary>
        /// Der Debitor wird angezeigt wenn:
        /// - es eine Einnahme und nicht eine Ausgabe ist.
        /// </summary>
        public bool IsDebitorLookupVisible
        {
            get
            {
                if (SelectedEntity != null)
                {
                    return SelectedEntity.WshGrundbudgetPosition.IstEinnahme;
                }

                return false;
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

        /// <summary>
        /// Ob das Editpanel sichtbar ist.
        /// </summary>
        public bool IsEditPanelVisible
        {
            get { return _isEditPanelVisible; }
            set
            {
                if (_isEditPanelVisible != value && !value)
                {
                    if (SaveData(null).IsOk)
                    {
                        _isEditPanelVisible = false;
                        NotifyPropertyChanged.RaisePropertyChanged(() => IsEditPanelVisible);
                    }
                }
                else
                {
                    _isEditPanelVisible = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => IsEditPanelVisible);
                }
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

        /// <summary>
        /// Der Kreditor wird angezeigt wenn:
        /// - es eine Ausgabe und nicht eine Einnahme ist.
        /// - die Zahlungsart elektronisch ist.
        /// </summary>
        public bool IsKreditorLookupVisible
        {
            get
            {
                if (SelectedEntity != null)
                {
                    int? auszahlungsArt = SelectedEntity.WshGrundbudgetPosition.KbuAuszahlungArtCode;
                    if (!SelectedEntity.WshGrundbudgetPosition.IstEinnahme &&
                        auszahlungsArt != null &&
                        auszahlungsArt == (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public bool IsKreditorOrDebitorLookupVisible
        {
            get { return IsDebitorLookupVisible || IsKreditorLookupVisible; }
        }

        /// <summary>
        /// Auszahlungstermin wird angezeigt, wenn
        /// es keine Einnahme ist.
        /// </summary>
        public bool IsPeriodizitaetVisible
        {
            get
            {
                if (SelectedEntity != null)
                {
                    return !SelectedEntity.WshGrundbudgetPosition.IstEinnahme;
                }

                return false;
            }
        }

        /// <summary>
        /// Die Planwert-Checkbox wird angezeigt wenn:
        /// - es eine Ausgabe ist (und nicht Einnahme).
        /// </summary>
        public bool IsPlanwertVisible
        {
            get
            {
                if (SelectedEntity != null)
                {
                    return SelectedEntity.WshGrundbudgetPosition.IstAusgabe;
                }

                return false;
            }
        }

        /// <summary>
        /// Zahlungsart wird angezweigt, wenn
        /// - WshKategorie keine Einnahme ist.
        /// </summary>
        public bool IsZahlungsartVisible
        {
            get
            {
                if (SelectedEntity != null)
                {
                    return !SelectedEntity.WshGrundbudgetPosition.IstEinnahme;
                }

                return true;
            }
        }

        public ImageSource IstBewilligtImageSource
        {
            get { return _istBewilligtImageSource; }
            private set
            {
                if (_istBewilligtImageSource != value)
                {
                    _istBewilligtImageSource = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => IstBewilligtImageSource);
                }
            }
        }

        public ObservableCollection<WshKategorie> Kategorie
        {
            get { return _kategorie; }
            set
            {
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

        public bool KuenftigeUndAktuellePositionen
        {
            get { return FilterMode == FilterMode.KuenftigeUndAktuellePositionen; }
            set
            {
                if (value)
                {
                    FilterMode = FilterMode.KuenftigeUndAktuellePositionen;
                }
            }
        }

        public ObservableCollection<XLOVCode> Periodizitaet
        {
            get { return _periodizitaet; }
            set
            {
                if (_periodizitaet != value)
                {
                    _periodizitaet = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => Periodizitaet);
                }
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

        public ObservableCollection<XLOVCode> ZahlungsArt
        {
            get { return _zahlungsArt; }
            set
            {
                _zahlungsArt = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => ZahlungsArt);
                NotifyPropertyChanged.RaisePropertyChanged(() => ZahlungsartString);
            }
        }

        public string ZahlungsartString
        {
            get
            {
                string zahlungsart = string.Empty;

                if (ZahlungsArt != null && SelectedEntity != null && SelectedEntity.WshGrundbudgetPosition.KbuAuszahlungArtCode.HasValue)
                {
                    zahlungsart =
                        ZahlungsArt.Where(z => z.Code == SelectedEntity.WshGrundbudgetPosition.KbuAuszahlungArtCode).Select(z => z.Text).
                            FirstOrDefault();
                }

                return zahlungsart;
            }
        }

        public SearchForStringEventHandler ZahlungswegSearchEventHandler
        {
            get { return _zahlungswegSearchEventHandler; }
            private set
            {
                _zahlungswegSearchEventHandler = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => ZahlungswegSearchEventHandler);
            }
        }

        private WshGrundbudgetPositionDTOService Service
        {
            get { return (WshGrundbudgetPositionDTOService)ServiceCRUD; }
        }

        #endregion

        #region Commands

        public ICommand NeueAusgabeCommand
        {
            get
            {
                if (_neueAusgabeCommand == null)
                {
                    _neueAusgabeCommand = new BaseCommand(
                        NeueAusgabe, 
                        o => Maskenrecht.CanInsert && SelectedEntity == null || SelectedEntity.ChangeTracker.State != ObjectState.Added
                    );
                }

                return _neueAusgabeCommand;
            }
        }

        public ICommand NeueEinnahmeCommand
        {
            get
            {
                if (_neueEinnahmeCommand == null)
                {
                    _neueEinnahmeCommand = new BaseCommand(
                        NeueEinnahme, o => Maskenrecht.CanInsert && SelectedEntity == null || SelectedEntity.ChangeTracker.State != ObjectState.Added
                    );
                }

                return _neueEinnahmeCommand;
            }
        }

        public ICommand ShowEditPanelCommand
        {
            get { return _showEditPanelCommand ?? (_showEditPanelCommand = new BaseCommand(x => SetEditMode(SelectedEntity != null))); }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void CurrentSelectedEntityChanged(WshGrundbudgetPositionDTO selectedEntity, WshGrundbudgetPositionDTO deselectedEntity)
        {
            NotifyPropertyChanged.RaisePropertyChanged(() => IsDebitorLookupVisible);
            NotifyPropertyChanged.RaisePropertyChanged(() => IsKreditorLookupVisible);
            NotifyPropertyChanged.RaisePropertyChanged(() => IsKreditorOrDebitorLookupVisible);
            NotifyPropertyChanged.RaisePropertyChanged(() => IsPlanwertVisible);
            NotifyPropertyChanged.RaisePropertyChanged(() => IsZahlungsartVisible);
            NotifyPropertyChanged.RaisePropertyChanged(() => ZahlungsartString);
            NotifyPropertyChanged.RaisePropertyChanged(() => IsPeriodizitaetVisible);
            NotifyPropertyChanged.RaisePropertyChanged(() => IsEditPanelEnabled);

            if (selectedEntity != null)
            {
                //update 'Betrifft Person' Combobox
                DateTime? stichtag = SelectedEntity.WshGrundbudgetPosition.DatumVon != Constant.SqlDateTimeMin
                                         ? SelectedEntity.WshGrundbudgetPosition.DatumVon
                                         : (DateTime?)null;
                UpdateHaushaltPersonen(stichtag);
            }

            UpdateIsFieldReadonly(selectedEntity);
            NotifyPropertyChanged.RaisePropertyChanged(() => IsBetrifftEnabled);
            UpdateIsFieldVisible(selectedEntity);
        }

        public override KissServiceResult DeleteData(IUnitOfWork unitOfWork)
        {
            //Wenn Dauerauftrag aktiv ist, dann dürfen keine Positionen gelöscht werden.
            if (DauerauftragAktiv)
            {
                return KissServiceResult.Ok();
            }

            KissServiceResult result = base.DeleteData(unitOfWork);

            if (result)
            {
                SetEditMode(false);
            }

            return result;
        }

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init(int leistungId)
        {
            FaLeistungID = leistungId;

            // SelectedEntityChanged event handler registrieren.
            SelectedEntityChanged += CurrentSelectedEntityChanged;

            // Config holen
            var xconfigService = Container.Resolve<XConfigService>();
            _werteListeFilter = xconfigService.GetConfigValue<string>(null, XCONFIG_WERTELISTEFILTER);

            // LOVs holen.
            InitLovs();

            // Icon für HasBemerkung und IstBewilligt Column
            InitIcons();

            // Personen im Haushalt
            InitPersonenImHaushalt(leistungId);

            // Dauerauftrag
            InitDauerAuftrag(leistungId);

            // Eventhandler für Suche
            InitEventHandler();

            // set panel visibility
            SetEditMode(false);

            // Daten laden.
            LoadData(null);
        }

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init()
        {
            // TODO: Search(null);
        }

        public override void LoadData(IUnitOfWork unitOfWork)
        {
            switch (_filterMode)
            {
                case FilterMode.AllePositionen:
                    EntityList = new ObservableCollection<WshGrundbudgetPositionDTO>(Service.GetByFaLeistungID(unitOfWork, FaLeistungID, null, false));
                    break;
                case FilterMode.KuenftigeUndAktuellePositionen:
                    EntityList =
                        new ObservableCollection<WshGrundbudgetPositionDTO>(
                            Service.GetByFaLeistungID(unitOfWork, FaLeistungID, DateTime.Today, false));
                    break;
                case FilterMode.AktuellePositionen:
                    EntityList =
                        new ObservableCollection<WshGrundbudgetPositionDTO>(Service.GetByFaLeistungID(unitOfWork, FaLeistungID, DateTime.Today, true));
                    break;
            }

            // Flag IsAuszahlungDritte setzen
            Service.UpdateIsAuszahlungDritte(EntityList, PersonenHaushaltAlle);
        }

        /// <summary>
        /// TODO same as in WshBudgetPositionVM?
        /// </summary>
        /// <returns></returns>
        public override KissServiceResult NewData()
        {
            //Wenn Dauerauftrag aktiv ist, dann können keine neue Positionen erstellt werden.
            if (DauerauftragAktiv)
            {
                return KissServiceResult.Ok();
            }

            // Kein neuer Datensatz einfügen, wenn die zuvor eingefügte Position noch nicht gespeichert wurde
            if (SelectedEntity != null && SelectedEntity.ChangeTracker.State == ObjectState.Added)
            {
                return KissServiceResult.Ok();
            }

            var availableOptions = new List<QuestionAnswerOption>();
            Kategorie.ToList().ForEach(k => availableOptions.Add(new QuestionAnswerOption(k, k.Name))); //k: Tag, k.Name: Caption

            QuestionAnswerOption result = RaiseQuestion("Kategorie", availableOptions, false);
            if (result == null)
            {
                return KissServiceResult.Ok();
            }

            var kategorie = (WshKategorie)result.Tag;
            var kategorieEnum = (LOVsGenerated.WshKategorie)kategorie.WshKategorieID;

            return NewData(kategorieEnum);
        }

        public override KissServiceResult SaveData(IUnitOfWork unitOfWork)
        {
            if (!Service.NeedToSaveData(SelectedEntity))
            {
                return KissServiceResult.Ok();
            }

            // TODO: can this be done without memento?
            // TODO: Refactor in method
            try
            {
                // Call Service.SavePosition as lond as there is a question that's not answered
                // Use a memento because the entity is set to Unchanged in the UnitOfWork.SaveChanges() and not after that the last transaction has been committed
                WshGrundbudgetPositionDTO originalMemento = ObjectCloner.Clone(SelectedEntity);
                WshGrundbudgetPositionDTO memento = null;
                ValidationResult = Service.SaveData(unitOfWork, SelectedEntity, _questionsAndAnswers);
                bool doLoop = true;
                while (ValidationResult.IsQuestion && doLoop)
                {
                    KissServiceResultEntry questionServiceResult = ValidationResult.GetQuestions().FirstOrDefault();
                    if (questionServiceResult != null)
                    {
                        QuestionAnswerOption answer = RaiseQuestion(
                            questionServiceResult.Message, questionServiceResult.AvailableAnswerOptions, false);
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

                UpdatePeriodizitaetLOV();
            }
            finally
            {
                //the next time, the user should be asked again
                ClearQuestionCache(_questionsAndAnswers);
            }

            if (ValidationResult.IsOk)
            {
                CreateMemento(SelectedEntity);
            }

            Service.UpdateAuszahlungstermin(SelectedEntity);
            UpdateIsFieldReadonly(SelectedEntity);

            return ValidationResult;
        }

        #endregion

        #region Protected Methods

        protected override bool IsSelectedEntityTreeModified()
        {
            if (SelectedEntity.ChangeTracker.State != ObjectState.Unchanged)
            {
                return true;
            }

            if (SelectedEntity.WshGrundbudgetPosition.WshGrundbudgetPositionKreditor.Count == 1)
            {
                if (SelectedEntity.WshGrundbudgetPosition.WshGrundbudgetPositionKreditor.Single().ChangeTracker.State != ObjectState.Unchanged)
                {
                    return true;
                }
            }

            if (SelectedEntity.WshGrundbudgetPosition.WshGrundbudgetPositionDebitor.Count == 1)
            {
                if (SelectedEntity.WshGrundbudgetPosition.WshGrundbudgetPositionDebitor.Single().ChangeTracker.State != ObjectState.Unchanged)
                {
                    return true;
                }
            }

            return false;
        }

        protected override void OnSelectedEntityChanged(WshGrundbudgetPositionDTO selectedEntity, WshGrundbudgetPositionDTO deselectedEntity)
        {
            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);
            if (selectedEntity != null)
            {
                Service.UpdateAuszahlungstermin(selectedEntity);
            }

            if (selectedEntity != null
                &&
                (deselectedEntity == null ||
                 selectedEntity.WshGrundbudgetPosition.WshKategorieID != deselectedEntity.WshGrundbudgetPosition.WshKategorieID))
            {
                UpdatePeriodizitaetLOV();
            }
            NotifyPropertyChanged.RaisePropertyChanged(() => IsBetrifftEnabled);
        }

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            string wshGrundbudgetPositionString = PropertyName.GetPropertyName(() => SelectedEntity.WshGrundbudgetPosition) + ".";

            var wshGrundbudgetPosition = new WshGrundbudgetPosition();
            string propertyNameKonto = wshGrundbudgetPositionString +
                                       PropertyName.GetPropertyName(() => SelectedEntity.WshGrundbudgetPosition.KbuKonto);
            string propertyNameKontoID = wshGrundbudgetPositionString +
                                         PropertyName.GetPropertyName(() => SelectedEntity.WshGrundbudgetPosition.KbuKontoID);

            if ((propertyName == propertyNameKonto || propertyName == propertyNameKontoID) && SelectedEntity.WshGrundbudgetPosition.KbuKonto != null)
            {
                SelectedEntity.WshGrundbudgetPosition.Text = SelectedEntity.WshGrundbudgetPosition.KbuKonto.Name;
                UpdateIsFieldVisible(SelectedEntity);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsBetrifftEnabled);
            }
            else if (propertyName ==
                     wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => SelectedEntity.WshGrundbudgetPosition.BetragMonatlich) ||
                     propertyName ==
                     wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => SelectedEntity.WshGrundbudgetPosition.BetragTotal))
            {
                Service.SetBetragMonatlich(SelectedEntity);
            }
            else if (propertyName ==
                     wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => (wshGrundbudgetPosition).KbuAuszahlungArtCode) ||
                     propertyName == wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => (wshGrundbudgetPosition).WshKategorieID))
            {
                NotifyPropertyChanged.RaisePropertyChanged(() => IsDebitorLookupVisible);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsKreditorLookupVisible);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsKreditorOrDebitorLookupVisible);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsPlanwertVisible);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsZahlungsartVisible);
                NotifyPropertyChanged.RaisePropertyChanged(() => ZahlungsartString);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsPeriodizitaetVisible);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsBetrifftEnabled);

                Service.UpdateKreditorMitteilungszeile1(SelectedEntity.WshGrundbudgetPosition);
            }
            if (propertyName == wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => wshGrundbudgetPosition.DatumVon) ||
                propertyName == wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => wshGrundbudgetPosition.KbuKonto))
            {
                //update 'Betrifft Person' Combobox
                DateTime? stichtag = SelectedEntity.WshGrundbudgetPosition.DatumVon != Constant.SqlDateTimeMin
                                         ? SelectedEntity.WshGrundbudgetPosition.DatumVon
                                         : (DateTime?)null;
                UpdateHaushaltPersonen(stichtag);

                // erste Person oder UE auswählen wenn es nur eine in der Liste gibt
                if (PersonenHaushalt.Count() == 1)
                {
                    SelectedEntity.WshGrundbudgetPosition.BaPerson = PersonenHaushalt[0];
                }
                NotifyPropertyChanged.RaisePropertyChanged(() => IsBetrifftEnabled);
            }

            if (propertyName == wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => wshGrundbudgetPosition.WshPeriodizitaetCode) ||
                propertyName == wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => wshGrundbudgetPosition.KbuAuszahlungArtCode))
            {
                Service.UpdateAuszahlungstermin(SelectedEntity);
                UpdateIsFieldReadonly(SelectedEntity);
                UpdateIsFieldVisible(SelectedEntity);
            }

            if (propertyName == wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => wshGrundbudgetPosition.WshKategorieID))
            {
                UpdatePeriodizitaetLOV();
            }

            if (propertyName ==
                wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => SelectedEntity.WshGrundbudgetPosition.WshPeriodizitaetCode))
            {
                if (SelectedEntity.WshGrundbudgetPosition.WshPeriodizitaetCode.HasValue)
                {
                    Service.SetBetragMonatlich(SelectedEntity);
                }
            }

            if (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.SelectedZahlungsweg))
            {
                Service.SetZahlungsweg(SelectedEntity, PersonenHaushaltAlle);
            }
            else if (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.SelectedDebitor))
            {
                Service.SetDebitor(SelectedEntity);
            }
            else if (propertyName ==
                     wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => SelectedEntity.WshGrundbudgetPosition.BetragTotal)
                     ||
                     propertyName ==
                     wshGrundbudgetPositionString + PropertyName.GetPropertyName(() => SelectedEntity.WshGrundbudgetPosition.BetragMonatlich))
            {
                Service.SetBetragMonatlich(SelectedEntity);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Der Dauerauftrag wird aktiviert (isAktivierung true) oder deaktiviert.
        /// </summary>
        /// <returns>Ob Aktivierung oder Deaktivierung erfolgreich war.</returns>
        private bool DauerAuftragAktievierenDeaktivieren(bool isAktivierung)
        {
            KissServiceResult result;

            //In try catch weil: Property wird vom Binding aus aufgerufen.
            try
            {
                if (isAktivierung)
                {
                    result = Service.DauerauftragAktivieren(null, FaLeistungID);
                }
                else
                {
                    result = Service.DauerauftragDeaktivieren(null, FaLeistungID);
                }
            }
            catch(Exception e)
            {
                result = new KissServiceResult(e);
            }

            if (!result.IsOk)
            {
                if (isAktivierung)
                {
                    RaiseMessage("Dauerauftrag konnte nicht aktiviert werden", result);
                }
                else
                {
                    RaiseMessage("Dauerauftrag konnte nicht inaktiviert werden", result);
                }
                return false;
            }

            return true;
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
            //Eventhandler für Suche nach Kreditoren
            ZahlungswegSearchEventHandler = SearchZahlungsweg;

            //Eventhandler für Suche nach Debitoren
            DebitorSearchEventHandler = SearchDebitor;

            //Eventhandler für Suche nach Konti.
            KontoSearchEventHandler = SearchKonto;
        }

        private void InitIcons()
        {
            //Icon für HasBemerkung Column
            var imageService = Container.Resolve<XImageService>();
            HatBemerkungImageSource = imageService.GetHatBemerkungImage();

            //Icon für IstBewilligt Column
            var positionStatusImageService = Container.Resolve<WshPositionsStatusImageService>();
            IstBewilligtImageSource = positionStatusImageService.GetBewilligtImage();
        }

        private void InitLovs()
        {
            var xlovService = Container.Resolve<XLovService>();

            //Kategorie
            var wshKategorieService = Container.Resolve<WshKategorieService>();
            Kategorie = new ObservableCollection<WshKategorie>(wshKategorieService.GetKategorien(null, false));

            //Zahlungsart
            string enumZahlungsartName = typeof(LOVsGenerated.KbuAuszahlungArt).Name;
            ZahlungsArt = new ObservableCollection<XLOVCode>(xlovService.GetLovCodeByLovName(null, enumZahlungsartName, _werteListeFilter));

            //Periodizitaet
            string enumPeriodizitaetTerminName = typeof(LOVsGenerated.WshPeriodizitaet).Name;
            Periodizitaet = new ObservableCollection<XLOVCode>(xlovService.GetLovCodeByLovName(null, enumPeriodizitaetTerminName, _werteListeFilter));

            //Splittingart
            string enumSplittingartName = typeof(LOVsGenerated.WshSplittingart).Name;
            Splittingart = new ObservableCollection<XLOVCode>(xlovService.GetLovCodeByLovName(null, enumSplittingartName));
        }

        private void InitPersonenImHaushalt(int leistungId)
        {
            //Personen im Haushalt (für Grid).
            var haushaltPersonService = Container.Resolve<WshHaushaltPersonService>();
            PersonenHaushaltAlle = haushaltPersonService.GetPersonenHaushaltAlle(null, leistungId);

            //Personen im Haushalt (für DetailPanel)
            UpdateHaushaltPersonen(null);
            NotifyPropertyChanged.RaisePropertyChanged(() => IsBetrifftEnabled);
        }

        /// <summary>
        /// CommandHandler für neue Ausgabe.
        /// </summary>
        /// <param name="obj"></param>
        private void NeueAusgabe(object obj)
        {
            NewData(LOVsGenerated.WshKategorie.Ausgabe);
        }

        /// <summary>
        ///  CommandHandler für neue Einnahme.
        /// </summary>
        /// <param name="obj"></param>
        private void NeueEinnahme(object obj)
        {
            NewData(LOVsGenerated.WshKategorie.Einnahme);
        }

        private KissServiceResult NeueGrundBudgetPosition(LOVsGenerated.WshKategorie wshKategorie)
        {
            KissServiceResult result = base.NewData();

            if (!result.IsOk)
            {
                return result;
            }

            SelectedEntity.WshGrundbudgetPosition.Text = "";
            SelectedEntity.WshGrundbudgetPosition.FaLeistungID = FaLeistungID;
            SelectedEntity.WshGrundbudgetPosition.WshKategorieID = (int)wshKategorie;

            SetEditMode(true);

            return KissServiceResult.Ok();
        }

        private KissServiceResult NewData(LOVsGenerated.WshKategorie kategorie)
        {
            KissServiceResult result = NeueGrundBudgetPosition(kategorie);

            if (!result.IsOk)
            {
                return result;
            }

            if (kategorie == LOVsGenerated.WshKategorie.Ausgabe)
            {
                result += Service.SetKreditor(SelectedEntity);
                Service.SetZahlungswegStandard(SelectedEntity);
            }

            return result;
        }

        private List<object> SearchDebitor(string searchString)
        {
            var debitoren = new List<object>();

            var searchService = Container.Resolve<BaDebitorSearchService>();
            List<BaDebitorDTO> result = searchService.SearchDebitor(null, searchString);
            result.ForEach(debitoren.Add);

            return debitoren;
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

            int kategorieId = SelectedEntity.WshGrundbudgetPosition.WshKategorieID;

            var serachDTO = new KbuKontoSearchDTO
            {
                LeistungWsh = true,
                Datum = DateTime.Today,
                Grundbudget = true,
                WshKategorie = (LOVsGenerated.WshKategorie)kategorieId,
                SearchString = searchString,
            };

            List<KbuKonto> result = kontoService.SearchKonto(null, serachDTO).ToList();
            result.ForEach(list.Add);

            return list;
        }

        /// <summary>
        /// Suche nach Kreditoren
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        private List<object> SearchZahlungsweg(string searchString)
        {
            var kreditoren = new List<object>();

            var kreditorSearchService = Container.Resolve<BaZahlungswegSearchService>();
            List<BaZahlungswegDTO> listKreditoren = kreditorSearchService.SearchZahlungsweg(null, searchString, FaLeistungID);
            listKreditoren.ForEach(kreditoren.Add);

            return kreditoren;
        }

        private void SetEditMode(bool editing)
        {
            IsEditPanelVisible = editing;
        }

        private void UpdateHaushaltPersonen(DateTime? stichtag)
        {
            if (SelectedEntity != null)
            {
                _editModeBetrifftPerson = Service.GetSysEditModePersonBetrifft(
                    SelectedEntity.WshGrundbudgetPosition.KbuKontoID,
                    SelectedEntity.WshGrundbudgetPosition.DatumVon,
                    SelectedEntity.WshGrundbudgetPosition.DatumBis);
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
                List<WshHaushaltPerson> haushaltPersonen = stichtag.HasValue
                                                               ? haushaltPersonService.GetHaushaltPersonen(null, FaLeistungID, stichtag.Value, true)
                                                               : haushaltPersonService.GetHaushaltPersonen(null, FaLeistungID, true);

                List<BaPerson> unterstuetztePersonen = haushaltPersonen.Select(hp => hp.BaPerson).ToList();
                unterstuetztePersonen.ForEach(PersonenHaushalt.Add);
            }
        }

        /// <summary>
        /// Setzen von Readonly-Flags für alle Eingabefelder in einem Dictionary.
        /// Das Dictionary enthält die Feld-Namen und ein Wert, ob das entspr. Feld ReadOnly ist.
        /// (True = ReadOnly!)
        /// </summary>
        /// <param name="positionDto"></param>
        private void UpdateIsFieldReadonly(WshGrundbudgetPositionDTO positionDto)
        {
            if (positionDto != null)
            {
                //Enthält pro Feld ein bool. Wenn true => Feld ist readonly.
                var dict = new Dictionary<string, bool>();

                // SA / SB ? Sozialarbeiter hat mehr Rechete / SB Sachbearbeiter ist Slave und darf nichts
                // TODO Kompetenzen werden in Sprint 8 noch nicht behandelt, User hat momentan immer SA-Kompetenz
                const bool isUserSb = false;

                // Status Budgetpositionen
                DateTime? first, last;
                bool hasGreenOrYellow =
                    !Service.AreAllDependingPositionsGray(null, positionDto.WshGrundbudgetPosition.WshGrundbudgetPositionID, out first, out last);

                bool berechnet = positionDto.WshGrundbudgetPosition.Berechnet;

                bool isNotAdded = positionDto.ChangeTracker.State != ObjectState.Added;

                dict.Add("Kategorie", true);
                dict.Add("Planwert", isNotAdded);
                dict.Add("Zahlungsweg", isNotAdded);
                dict.Add("Mitteilung1", true);

                dict.Add("Bemerkung", isUserSb);
                dict.Add("Betrag", berechnet || isUserSb || hasGreenOrYellow);
                //dict.Add("Betrifft", isUserSb || hasGreenOrYellow);
                dict.Add("DatumBis", isUserSb);
                dict.Add("DatumEntscheid", isUserSb || hasGreenOrYellow);
                dict.Add("DatumVon", isUserSb || hasGreenOrYellow);
                dict.Add("Debitor", isUserSb);
                dict.Add("Faellig", !positionDto.IstEinnahmeOrHatFaelligAmPeriodizität || isUserSb);
                dict.Add("KOA", berechnet || isUserSb || hasGreenOrYellow);
                dict.Add("Kreditor", isUserSb);
                dict.Add("Mitteilung2", isUserSb);
                dict.Add("Referenznummer", isUserSb);
                dict.Add("Text", berechnet || isUserSb);
                dict.Add("Total", berechnet || isUserSb || hasGreenOrYellow);
                dict.Add("VerwaltungSD", isUserSb);
                dict.Add("Zahlungsart", isUserSb);

                //Periodizität kann beim Erfassen beliebig gewählt werden.
                //Nach dem Erfassen kann die Periodizität nicht geändert werden, wenn sie Quartal oder Semester ist.
                //Sonst kann sie sehr wohl geändert werden (Werteliste sollte Quartal und Semester nicht mehr zur Auswahl anbieten).
                if ((positionDto.WshGrundbudgetPosition.WshPeriodizitaetCode == (int)LOVsGenerated.WshPeriodizitaet.Quartal
                     || positionDto.WshGrundbudgetPosition.WshPeriodizitaetCode == (int)LOVsGenerated.WshPeriodizitaet.Semester)
                    && isNotAdded)
                {
                    dict.Add("Periodizitaet", true);
                }
                else
                {
                    dict.Add("Periodizitaet", isUserSb);
                }

                IsFieldReadonly = dict;
            }
        }

        private void UpdateIsFieldVisible(WshGrundbudgetPositionDTO positionDto)
        {
            if (positionDto == null)
            {
                return;
            }

            var dict = new Dictionary<string, Visibility>();
            if (positionDto.WshGrundbudgetPosition.KbuKonto != null &&
                positionDto.WshGrundbudgetPosition.KbuKonto.WshSplittingartCode == (int)LOVsGenerated.WshSplittingart.Entscheid)
            {
                dict.Add("DatumEntscheid", Visibility.Visible);
            }
            else
            {
                dict.Add("DatumEntscheid", Visibility.Hidden);
            }

            IsFieldVisible = dict;
        }

        private void UpdatePeriodizitaetLOV()
        {
            string enumPeriodizitaetTerminName = typeof(LOVsGenerated.WshPeriodizitaet).Name;
            var xlovService = Container.Resolve<XLovService>();
            var filterList = new List<string>();
            string filter1 = SelectedEntity.WshGrundbudgetPosition.WshKategorieID == (int)LOVsGenerated.WshKategorie.Einnahme ? "Einnahme" : null;

            if (!string.IsNullOrEmpty(filter1))
            {
                filterList.Add(filter1);
            }

            if (!string.IsNullOrEmpty(_werteListeFilter))
            {
                filterList.Add(_werteListeFilter);
            }

            //Nach dem eine Position (Per. nicht Semester und nicht Quartal) gespeichert worden ist,
            //stehen die Werte Quartal und Semester nicht mehr zur Auswahl.
            if (SelectedEntity != null && SelectedEntity.WshGrundbudgetPosition.WshPeriodizitaetCode != (int)LOVsGenerated.WshPeriodizitaet.Quartal
                && SelectedEntity.WshGrundbudgetPosition.WshPeriodizitaetCode != (int)LOVsGenerated.WshPeriodizitaet.Semester
                && SelectedEntity.ChangeTracker.State != ObjectState.Added)
            {
                filterList.Add("M");
            }

            Periodizitaet =
                new ObservableCollection<XLOVCode>(xlovService.GetLovCodeByLovName(null, enumPeriodizitaetTerminName, filterList.ToArray()));
        }

        #endregion

        #endregion
    }
}