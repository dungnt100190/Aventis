using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

using Kiss.BL.Ba;
using Kiss.BL.Kbu;
using Kiss.BL.KissSystem;
using Kiss.BL.Wsh;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Kbu;
using Kiss.Model.DTO.Wsh;

namespace Kiss.UI.ViewModel.Wsh
{
    /// <summary>
    /// The ViewModel of the WshPosition entity.
    /// </summary>
    public class WshBudgetPositionVM : ViewModelCRUDListBase<WshPositionMonatBudgetDTO>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string XCONFIG_WERTELISTEFILTER = @"System\WSH\Wertelistefilter";

        #endregion

        #region Private Fields

        private TimePeriod _bereichBudgetmonate;
        private List<WshBudgetmonatDTO> _budgetmonate;
        private SearchForStringEventHandler _debitorSearchEventHandler;
        private string _detailinfo;
        private bool _isEditPanelVisible;
        private ObservableCollection<WshKategorie> _kategorie = new ObservableCollection<WshKategorie>();
        private ObservableCollection<WshKategorie> _kategorieAlle = new ObservableCollection<WshKategorie>();
        private ObservableCollection<KbuKonto> _konti = new ObservableCollection<KbuKonto>();
        private SearchForStringEventHandler _kontoSearchEventHandler;
        private SearchForStringEventHandler _kreditorSearchEventHandler;
        private ICommand _neueAusgabeCommand;
        private ICommand _neueEinnahmeCommand;
        private ObservableCollection<XLOVCode> _periodizitaet;
        private ObservableCollection<BaPerson> _personenHaushalt = new ObservableCollection<BaPerson>();
        private ObservableCollection<BaPerson> _personenHaushaltAlle = new ObservableCollection<BaPerson>();
        private MonthYear _selectedMonthYear;
        private ICommand _showEditPanelCommand;
        private bool _showKennzahlen;
        private string _werteListeFilter;
        private ObservableCollection<XLOVCode> _zahlungsArt = new ObservableCollection<XLOVCode>();
        private LOVsGenerated.SysEditMode _editModeBetrifftPerson;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshBudgetPositionVM"/> class.
        /// </summary>
        public WshBudgetPositionVM()
            : base(Container.Resolve<WshPositionMonatBudgetDTOService>())
        {
            _selectedMonthYear = MonthYear.CurrentMonth;
        }

        #endregion

        #region Properties

        public TimePeriod BereichBudgetmonate
        {
            get { return _bereichBudgetmonate; }
            set
            {
                _bereichBudgetmonate = value;
                LoadBudgetmonate(BereichBudgetmonate);
            }
        }

        public List<WshBudgetmonatDTO> Budgetmonate
        {
            get { return _budgetmonate; }
            private set
            {
                _budgetmonate = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Budgetmonate);
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

        /// <summary>
        /// Gibt einen Detailinfo-Text des aktuellen Entitys zurück.
        /// </summary>
        public string Detailinfo
        {
            get { return _detailinfo; }
            private set
            {
                if (_detailinfo != value)
                {
                    _detailinfo = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => Detailinfo);
                }
            }
        }

        public int FaLeistungId
        {
            get; private set;
        }

        /// <summary>
        /// Das Debitorauswahlfeld ist sichtbar, wenn es eine Einnahme ist.
        /// </summary>
        public bool IsDebitorLookupVisible
        {
            get
            {
                if (SelectedEntity == null)
                {
                    return false;
                }

                return SelectedEntity.WshPosition.IstEinnahme;
            }
        }

        /// <summary>
        /// Grundsätzlich wird das EditPanel
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
                        NotifyPropertyChanged.RaisePropertyChanged(() => IsInfoPanelVisible);
                    }
                }
                else
                {
                    _isEditPanelVisible = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => IsEditPanelVisible);
                    NotifyPropertyChanged.RaisePropertyChanged(() => IsInfoPanelVisible);
                }
            }
        }

        public bool IsFaelligAmDateTimeVisible
        {
            get
            {
                if (SelectedEntity == null)
                {
                    return true;
                }

                return IsDebitorLookupVisible || SelectedEntity.WshPosition.WshPeriodizitaetCode == (int)LOVsGenerated.WshPeriodizitaet.Valuta;
            }
        }

        public bool IsInfoPanelVisible
        {
            get { return !IsEditPanelVisible; }
        }

        public bool IsBetrifftEnabled
        {
            get {
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
        /// Checkbox Kennzahlen.
        /// </summary>
        public bool IsKennzahlenPanelVisible
        {
            get { return _showKennzahlen; }
            set
            {
                if (_showKennzahlen != value)
                {
                    _showKennzahlen = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => IsKennzahlenPanelVisible);
                }
            }
        }

        /// <summary>
        /// Das Kreditorauswahlfeld ist sichtbar, wenn:
        /// - es eine Ausgabe und nicht eine Einnahme ist.
        /// - die Zahlungsart elektronisch ist.
        /// </summary>
        public bool IsKreditorLookupVisible
        {
            get
            {
                if (SelectedEntity != null)
                {
                    int? auszahlungsArt = SelectedEntity.WshPosition.KbuAuszahlungArtCode;
                    if (!SelectedEntity.WshPosition.IstEinnahme &&
                        auszahlungsArt != null &&
                        auszahlungsArt == (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung)
                    {
                        return true;
                    }
                }
                return false;
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

        public ObservableCollection<WshKategorie> KategorieAlle
        {
            get { return _kategorieAlle; }
            set
            {
                _kategorieAlle = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => KategorieAlle);
            }
        }

        public ObservableCollection<KbuKonto> Konti
        {
            get { return _konti; }
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

        public SearchForStringEventHandler KreditorSearchEventHandler
        {
            get { return _kreditorSearchEventHandler; }
            private set
            {
                _kreditorSearchEventHandler = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => KreditorSearchEventHandler);
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

        /// <summary>
        /// Personen welche im Haushalt unterstützt werden. 
        /// Liste der Personen welche für eine Positiona ausgewählt werden können.
        /// </summary>
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

        /// <summary>
        /// Das Datum der aktuellen Ansicht.
        /// </summary>
        public MonthYear SelectedMonthYear
        {
            get { return _selectedMonthYear; }
            set
            {
                if (_selectedMonthYear != value)
                {
                    if (!DesignMode)
                    {
                        // Save is not triggered automatically
                        if (SaveData(null))
                        {
                            _selectedMonthYear = value;
                            NotifyPropertyChanged.RaisePropertyChanged(() => SelectedMonthYear);
                            LoadData(null);
                        }
                    }
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
            }
        }

        private WshPositionMonatBudgetDTOService Service
        {
            get { return (WshPositionMonatBudgetDTOService)ServiceCRUD; }
        }

        #endregion

        #region Commands

        public ICommand NeueAusgabeCommand
        {
            get
            {
                return _neueAusgabeCommand ??
                       (_neueAusgabeCommand =
                        new BaseCommand(NeueAusgabe, o => Maskenrecht.CanInsert && SelectedEntity == null || SelectedEntity.ChangeTracker.State != ObjectState.Added));
            }
        }

        public ICommand NeueEinnahmeCommand
        {
            get
            {
                return _neueEinnahmeCommand ??
                       (_neueEinnahmeCommand =
                        new BaseCommand(NeueEinnahme, o => Maskenrecht.CanInsert && SelectedEntity == null || SelectedEntity.ChangeTracker.State != ObjectState.Added));
            }
        }

        /// <summary>
        /// Shows the edit panel (only if an entity is selected!)
        /// </summary>
        public ICommand ShowEditPanelCommand
        {
            get { return _showEditPanelCommand ?? (_showEditPanelCommand = new BaseCommand(x => SetEditMode(SelectedEntity != null))); }
        }

        #endregion

        #region EventHandlers

        private void SaveCommand_Executed(object param)
        {
            var result = SaveData(null);

            SetEditMode(!result);
        }

        #endregion

        #region Methods

        #region Public Methods

        public override KissServiceResult DeleteData(IUnitOfWork unitOfWork)
        {
            var result = base.DeleteData(unitOfWork);

            if (result)
            {
                SetEditMode(false);
            }

            return result;
        }

        public ImageSource GetPositionsStatusImage(int rowIndex)
        {
            try
            {
                var position = EntityList[rowIndex];
                var imageService = Container.Resolve<WshPositionsStatusImageService>();
                return imageService.GetPositionsStatusImage(position.WshPosition);
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init(int faLeistungId)
        {
            FaLeistungId = faLeistungId;

            //KboKonti holen
            var kontoService = Container.Resolve<KbuKontoService>();
            _konti = kontoService.GetData(null);
            NotifyPropertyChanged.RaisePropertyChanged(() => Konti);

            //LOVs holen.
            var xlovService = Container.Resolve<XLovService>();
            var xconfigService = Container.Resolve<XConfigService>();

            _werteListeFilter = xconfigService.GetConfigValue<string>(null, XCONFIG_WERTELISTEFILTER);

            //Kategorie
            var katService = Container.Resolve<WshKategorieService>();
            KategorieAlle = new ObservableCollection<WshKategorie>(katService.GetKategorien(null));
            Kategorie = new ObservableCollection<WshKategorie>(KategorieAlle.Where(k => !k.IstAbzug));

            //Zahlungsart
            var enumZahlungsartName = typeof(LOVsGenerated.KbuAuszahlungArt).Name;
            ZahlungsArt = new ObservableCollection<XLOVCode>(xlovService.GetLovCodeByLovName(null, enumZahlungsartName, _werteListeFilter));

            //Periodizitaet
            var enumPeriodizitaetName = typeof(LOVsGenerated.WshPeriodizitaet).Name;
            Periodizitaet = new ObservableCollection<XLOVCode>(xlovService.GetLovCodeByLovName(null, enumPeriodizitaetName, _werteListeFilter));

            //Personen im Haushalt (für Grid).
            var haushaltPersonService = Container.Resolve<WshHaushaltPersonService>();
            PersonenHaushaltAlle = haushaltPersonService.GetPersonenHaushaltAlle(null, faLeistungId);

            //Personen im Haushaltg (für DetailPanel)
            UpdateHaushaltPersonen(_selectedMonthYear);

            //Eventhandler für Suche nach Debitoren
            DebitorSearchEventHandler = SearchDebitor;

            //Eventhandler für Suche nach Kreditoren
            KreditorSearchEventHandler = SearchKreditor;

            //Eventhandler für Suche nach Konti.
            KontoSearchEventHandler = SearchKonto;

            // set panel visibility
            SetEditMode(false);

            // Daten laden
            LoadData(null);

            var halfYearBeforeToday = DateTime.Today.AddMonths(-6).AddDays(-DateTime.Today.Day + 1);
            var halfYearAfterToday =
                DateTime.Today.AddMonths(5).AddDays(DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) - DateTime.Today.Day);
            BereichBudgetmonate = new TimePeriod(halfYearBeforeToday, halfYearAfterToday);
        }

        /// <summary>
        /// Gets the data from service.
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use (can be null)</param>
        public override void LoadData(IUnitOfWork unitOfWork)
        {
            EntityList = new ObservableCollection<WshPositionMonatBudgetDTO>(
                Service.GetByFaLeistungID(unitOfWork, FaLeistungId, _selectedMonthYear.Year, _selectedMonthYear.Month));

            // Flag IsAuszahlungDritte setzen
            Service.UpdateIsAuszahlungDritte(EntityList, PersonenHaushaltAlle);
        }

        public override KissServiceResult NewData()
        {
            // Kein neuer Datensatz einfügen, wenn die zuvor eingefügte Position noch nicht gespeichert wurde
            if (SelectedEntity != null && SelectedEntity.ChangeTracker.State == ObjectState.Added)
            {
                return KissServiceResult.Ok();
            }

            var availableOptions = new List<QuestionAnswerOption>();
            Kategorie.ToList().ForEach(k => availableOptions.Add(new QuestionAnswerOption(k, k.Name))); //QuestionAnswerOption k: Tag, k.Name: Caption

            QuestionAnswerOption result = RaiseQuestion("Kategorie", availableOptions, false);
            if (result == null)
            {
                //do nothing
                return KissServiceResult.Ok();
            }

            var selectedKategorie = (WshKategorie)result.Tag;
            var kategorie = (LOVsGenerated.WshKategorie)selectedKategorie.WshKategorieID;

            return NewData(kategorie);
        }

        public override KissServiceResult SaveData(IUnitOfWork unitOfWork)
        {
            // Save the position
            ValidationResult = Service.SaveData(unitOfWork, SelectedEntity);

            // Create the memento if the position has been saved correctly
            if (ValidationResult.IsOk)
            {
                CreateMemento(SelectedEntity);
            }

            return ValidationResult;
        }

        #endregion

        #region Protected Methods

        protected override bool IsSelectedEntityTreeModified()
        {
            return Service.IsSelectedEntityTreeModified(SelectedEntity);
        }

        protected override void OnSelectedEntityChanged(WshPositionMonatBudgetDTO selectedEntity, WshPositionMonatBudgetDTO deselectedEntity)
        {
            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);

            Detailinfo = GetDetailinfo();

            if (selectedEntity != null)
            {
                UpdateHaushaltPersonen(selectedEntity.WshPosition.BudgetMonatJahr);
            }

            NotifyPropertyChanged.RaisePropertyChanged(() => IsDebitorLookupVisible);
            NotifyPropertyChanged.RaisePropertyChanged(() => IsKreditorLookupVisible);
            NotifyPropertyChanged.RaisePropertyChanged(() => IsFaelligAmDateTimeVisible);
            NotifyPropertyChanged.RaisePropertyChanged(() => IsBetrifftEnabled);
        }

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            if (SelectedEntity == null)
            {
                return;
            }

            var wshPositionString = PropertyName.GetPropertyName(() => SelectedEntity.WshPosition) + ".";

            if (propertyName == wshPositionString + PropertyName.GetPropertyName(() => SelectedEntity.WshPosition.KbuAuszahlungArtCode) ||
                propertyName == wshPositionString + PropertyName.GetPropertyName(() => SelectedEntity.WshPosition.WshKategorieID))
            {
                NotifyPropertyChanged.RaisePropertyChanged(() => IsDebitorLookupVisible);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsKreditorLookupVisible);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsFaelligAmDateTimeVisible);
            }
            else if (propertyName == wshPositionString + PropertyName.GetPropertyName(() => SelectedEntity.WshPosition.WshPeriodizitaetCode))
            {
                Service.UpdatePeriodizitaet(null, SelectedEntity);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsFaelligAmDateTimeVisible);
            }
            if (propertyName == wshPositionString + PropertyName.GetPropertyName(() => SelectedEntity.WshPosition.BudgetMonatJahr)
                || propertyName == wshPositionString + PropertyName.GetPropertyName(() => SelectedEntity.WshPosition.KbuKonto))
            {
                UpdateHaushaltPersonen(SelectedEntity.WshPosition.BudgetMonatJahr);

                // erste Person oder UE auswählen wenn es nur eine in der Liste gibt
                if (PersonenHaushalt.Count() == 1)
                {
                    SelectedEntity.WshPosition.BaPerson = PersonenHaushalt[0];
                }
                NotifyPropertyChanged.RaisePropertyChanged(() => IsBetrifftEnabled);
            }
            else if ((propertyName == wshPositionString + PropertyName.GetPropertyName(() => SelectedEntity.WshPosition.KbuKonto) ||
                      propertyName == wshPositionString + PropertyName.GetPropertyName(() => SelectedEntity.WshPosition.KbuKontoID)) &&
                     SelectedEntity.WshPosition != null && SelectedEntity.WshPosition.KbuKonto != null)
            {
                SelectedEntity.WshPosition.Text = SelectedEntity.WshPosition.KbuKonto.Name;
            }
            else if (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.SelectedZahlungsweg))
            {
                Service.SetZahlungsweg(SelectedEntity, SelectedEntity.SelectedZahlungsweg, PersonenHaushaltAlle);
            }
            else if (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.SelectedDebitor))
            {
                Service.SetDebitor(SelectedEntity, SelectedEntity.SelectedDebitor);
            }
            else if (propertyName == wshPositionString + PropertyName.GetPropertyName(() => SelectedEntity.WshPosition.BetragTotal)
                     || propertyName == wshPositionString + PropertyName.GetPropertyName(() => SelectedEntity.WshPosition.Betrag))
            {
                Service.SetBetragMonatlich(SelectedEntity);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// TODO: ist momentan noch etwas unschön
        /// </summary>
        private string GetDetailinfo()
        {
            var e = SelectedEntity;

            if (e != null)
            {
                var firstLine = new StringBuilder();

                if (e.WshPosition.KbuKonto != null)
                {
                    firstLine.Append(e.WshPosition.KbuKonto.KontoNr + " ");
                }

                firstLine.Append(e.WshPosition.Text);
                if (firstLine.Length > 0)
                {
                    firstLine.Append(", ");
                }

                firstLine.Append(e.WshPosition.DatumEffektiv + (e.WshPosition.DatumEffektiv != null ? " " : string.Empty));
                firstLine.Append(e.WshPosition.BaPerson != null ? "an " + e.WshPosition.BaPerson.NameVorname : string.Empty);

                var line2 = string.Format(
                    @"erfasst am {0} durch {1}, letzte Änderung am {2} durch {3}",
                    e.WshPosition.Created,
                    e.WshPosition.Creator,
                    e.WshPosition.Modified,
                    e.WshPosition.Modifier);

                return firstLine + Environment.NewLine + line2;
            }

            return null;
        }

        private void LoadBudgetmonate(TimePeriod bereichBudgetmonate)
        {
            int monthCount = (bereichBudgetmonate.To.Month - bereichBudgetmonate.From.Month) +
                             (bereichBudgetmonate.To.Year - bereichBudgetmonate.From.Year)*12;
            Budgetmonate = Service.GetBudgetmonate(null, FaLeistungId, new MonthYear(bereichBudgetmonate.From), monthCount);
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

        private KissServiceResult NeuePosition(LOVsGenerated.WshKategorie kategorie)
        {
            var result = base.NewData();

            if (!result.IsOk)
            {
                return result;
            }

            SelectedEntity.WshPosition.Text = "";
            SelectedEntity.WshPosition.FaLeistungID = FaLeistungId;
            SelectedEntity.WshPosition.WshKategorieID = (int)kategorie;

            var verwPeriode = new TimePeriod(_selectedMonthYear);
            SelectedEntity.WshPosition.VerwPeriodeVon = verwPeriode.From;
            SelectedEntity.WshPosition.VerwPeriodeBis = verwPeriode.To;
            SelectedEntity.WshPosition.MonatVon = verwPeriode.From;
            SelectedEntity.WshPosition.MonatBis = verwPeriode.To;

            SelectedEntity.WshPosition.BudgetMonatJahr = _selectedMonthYear;
            SelectedEntity.WshPosition.FaelligAm = DateTime.Today; //ToDo: entfernen, sobald Binding auf DateTimeControl funktioniert

            SetEditMode(true);

            return KissServiceResult.Ok();
        }

        private KissServiceResult NewData(LOVsGenerated.WshKategorie kategorie)
        {
            var result = NeuePosition(kategorie);

            if(!result.IsOk)
            {
                return result;
            }

            if (kategorie == LOVsGenerated.WshKategorie.Ausgabe)
            {
                result += Service.SetKreditor(SelectedEntity);
                Service.SetZahlungswegStandard(SelectedEntity);
                Service.UpdatePeriodizitaet(null, SelectedEntity);
            }

            return result;
        }

        private List<object> SearchDebitor(string searchString)
        {
            var debitoren = new List<object>();

            var debitorSearchService = Container.Resolve<BaDebitorSearchService>();
            var result = debitorSearchService.SearchDebitorInstitution(null, searchString);

            debitoren.AddRange(result);

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
            int kategorieId = SelectedEntity.WshPosition.WshKategorieID;

            KbuKontoSearchDTO serachDTO = new KbuKontoSearchDTO
            {
                LeistungWsh = true,
                Datum = DateTime.Today,
                Monatsbudget = true,
                WshKategorie = (LOVsGenerated.WshKategorie)kategorieId,
                SearchString = searchString,
            };

            var result = kontoService.SearchKonto(null, serachDTO);

            list.AddRange(result);
            return list;
        }

        /// <summary>
        /// Suche nach Kreditoren
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        private List<object> SearchKreditor(string searchString)
        {
            var kreditoren = new List<object>();

            var kreditorSearchService = Container.Resolve<BaZahlungswegSearchService>();
            var listKreditoren = kreditorSearchService.SearchZahlungsweg(null, searchString, FaLeistungId);

            kreditoren.AddRange(listKreditoren);

            return kreditoren;
        }

        private void SetEditMode(bool editing)
        {
            IsEditPanelVisible = editing;
        }

        private void UpdateHaushaltPersonen(MonthYear monthYear)
        {
            var stichTag = new DateTime(monthYear.Year, monthYear.Month, 1);

            if (SelectedEntity != null)
            {
                _editModeBetrifftPerson = Service.GetSysEditModePersonBetrifft(
                    SelectedEntity.WshPosition.KbuKontoID,
                    SelectedEntity.WshPosition.MonatVon,
                    SelectedEntity.WshPosition.MonatBis);
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
                var haushaltPersonen = haushaltPersonService.GetHaushaltPersonen(null, FaLeistungId, stichTag, true);

                var unterstuetztePersonen = haushaltPersonen.Select(hp => hp.BaPerson).ToList();
                unterstuetztePersonen.ForEach(PersonenHaushalt.Add);
            }
        }

        #endregion

        #endregion
    }
}