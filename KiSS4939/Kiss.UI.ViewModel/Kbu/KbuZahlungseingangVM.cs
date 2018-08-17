using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

using Kiss.BL.Ba;
using Kiss.BL.Kbu;
using Kiss.BL.KissSystem;
using Kiss.BL.Wsh;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Container = Kiss.Interfaces.IoC.Container;
using Kiss.Model;
using Kiss.Model.DTO.BA;
using Kiss.Model.DTO.Kbu;
using Kiss.Model.DTO.Wsh;

namespace Kiss.UI.ViewModel.Kbu
{
    /// <summary>
    /// The ViewModel of the KbuZahlungseingang entity.
    /// </summary>
    public class KbuZahlungseingangVM : ViewModelCRUDListBase<KbuZahlungseingang>
    {
        #region Fields

        #region Public Static Fields

        public static RoutedCommand BetragAusgleichenCommand = new RoutedCommand();
        public static RoutedCommand ZahlungseingangVerbuchenCommand = new RoutedCommand();

        #endregion

        #region Private Fields

        private DateTime _buchungsdatum;
        private string _filterText;
        private bool _isNichtZugeordneteChecked;
        private bool _isNurOffeneChecked;
        private ObservableCollection<BaPerson> _personenHaushalt = new ObservableCollection<BaPerson>();
        private KbuErwarteteEinnahmeDTO _selectedSollstellung;
        private XLOVCode _selectedZeTeam;
        private IList<KbuErwarteteEinnahmeDTO> _sollstellungen;
        private ObservableCollection<XLOVCode> _zeTeams;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KbuZahlungseingangVM"/> class.
        /// </summary>
        public KbuZahlungseingangVM()
            : base(Container.Resolve<KbuZahlungseingangService>())
        {
        }

        #endregion

        #region Properties

        public DateTime BuchungsDatum
        {
            get { return _buchungsdatum; }
            set
            {
                if (_buchungsdatum != value)
                {
                    _buchungsdatum = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => BuchungsDatum);
                }
            }
        }

        public SearchForStringEventHandler DebitorSearchEventHandler
        {
            get { return SearchDebitor; }
        }

        public SearchResultConverter DebitorSearchResultConverter
        {
            get { return ConvertDebitorSearchResult; }
        }

        public string FilterText
        {
            get { return _filterText; }
            set
            {
                _filterText = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => FilterText);
            }
        }

        public bool IsManualEditingAllowed
        {
            get { return false; } // ToDo: Feature detection, da im Standard manuelles Editieren möglich ist
        }

        public bool IsNichtZugeordneteChecked
        {
            get { return _isNichtZugeordneteChecked; }
            set
            {
                _isNichtZugeordneteChecked = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => IsNichtZugeordneteChecked);
            }
        }

        public bool IsNurOffeneChecked
        {
            get { return _isNurOffeneChecked; }
            set
            {
                _isNurOffeneChecked = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => IsNurOffeneChecked);
            }
        }

        public SearchForStringEventHandler KlientSearchEventHandler
        {
            get { return SearchKlient; }
        }

        public SearchResultConverter KlientSearchResultConverter
        {
            get { return ConvertKlientSearchResult; }
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

        public KbuErwarteteEinnahmeDTO SelectedSollstellung
        {
            get { return _selectedSollstellung; }
            set
            {
                if (_selectedSollstellung != value)
                {
                    _selectedSollstellung = value;

                    NotifyPropertyChanged.RaisePropertyChanged(() => SelectedSollstellung);
                    NotifyPropertyChanged.RaisePropertyChanged(() => VerfuegbarerRestbetrag);
                }
            }
        }

        public XLOVCode SelectedZeTeam
        {
            get { return _selectedZeTeam; }
            set
            {
                _selectedZeTeam = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => SelectedZeTeam);
            }
        }

        public IList<KbuErwarteteEinnahmeDTO> Sollstellungen
        {
            get { return _sollstellungen; }
            set
            {
                if (_sollstellungen != null)
                {
                    ((List<KbuErwarteteEinnahmeDTO>)_sollstellungen).ForEach(e => e.PropertyChanged -= Sollstellungen_PropertyChanged);
                }

                _sollstellungen = value;

                if (_sollstellungen != null)
                {
                    ((List<KbuErwarteteEinnahmeDTO>)_sollstellungen).ForEach(e => e.PropertyChanged += Sollstellungen_PropertyChanged);
                }

                NotifyPropertyChanged.RaisePropertyChanged(() => Sollstellungen);
            }
        }

        public decimal VerfuegbarerRestbetrag
        {
            get { return CalculateVerfuegbarerRestbetrag(); }
        }

        public ObservableCollection<XLOVCode> ZeTeams
        {
            get { return _zeTeams; }
            set
            {
                _zeTeams = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => ZeTeams);
            }
        }

        private KbuZahlungseingangService Service
        {
            get { return (KbuZahlungseingangService)ServiceCRUD; }
        }

        #endregion

        #region EventHandlers

        private void Sollstellungen_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged.RaisePropertyChanged(() => VerfuegbarerRestbetrag);
        }

        #endregion

        #region Methods

        #region Public Methods

        public void BetragAusgleichen(object parameter)
        {
            if (SelectedSollstellung == null
                || SelectedEntity == null
                || !SelectedEntity.Betrag.HasValue)
            {
                return;
            }

            decimal betragEffektivOffen = SelectedSollstellung.BetragOffen - SelectedSollstellung.BetragAuszugleichen;

            decimal betrag = Math.Min(VerfuegbarerRestbetrag, betragEffektivOffen);

            SelectedSollstellung.BetragAuszugleichen += betrag;
        }

        public bool CanExecuteBetragAusgleichen(object parameter)
        {
            return true;
        }

        public bool CanExecuteZahlungseingangVerbuchen(object parameter)
        {
            if (SelectedEntity == null)
                return false;

            if (SelectedEntity.Ausgeglichen)
                return false;

            if (SelectedEntity.BaInstitutionDebitor == null && SelectedEntity.BaPersonDebitor == null)
                return false;

            if (Sollstellungen == null || Sollstellungen.Count == 0)
                return false;

            if (VerfuegbarerRestbetrag != 0)
                return false;

            return true;
        }

        public object ConvertDebitorSearchResult(object searchedEntity)
        {
            var dto = searchedEntity as BaDebitorDTO;

            if (dto == null)
                return null;

            return dto.BaInstitution;
        }

        public object ConvertKlientSearchResult(object searchedEntity)
        {
            var dto = searchedEntity as WshKlientDTO;

            if (dto == null)
                return null;

            return dto.FaFall;
        }

        public override KissServiceResult DeleteData(IUnitOfWork unitOfWork)
        {
            if (!IsManualEditingAllowed)
            {
                return new KissServiceResult(
                    KissServiceResult.ResultType.Error,
                    "KbuZahlungseingangVM_NoManualEditing",
                    "Zahlungseingänge dürfen nicht manuell bearbeitet werden");
            }
            return base.DeleteData(unitOfWork);
        }

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init()
        {
            var xLovService = Container.Resolve<XLovService>();
            ZeTeams = new ObservableCollection<XLOVCode>(xLovService.GetLovCodeByLovName(null, typeof(LOVsGenerated.KbuZahlungseingangTeam).Name, true));
            Sollstellungen = new List<KbuErwarteteEinnahmeDTO>();
            BuchungsDatum = DateTime.Today;
        }

        /// <summary>
        /// Gets the data from service.
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use (can be null)</param>
        public override void LoadData(IUnitOfWork unitOfWork)
        {
            EntityList = Service.GetData(unitOfWork);
        }

        public override KissServiceResult NewData()
        {
            if (!IsManualEditingAllowed)
            {
                return new KissServiceResult(
                    KissServiceResult.ResultType.Error,
                    "KbuZahlungseingangVM_NoManualEditing",
                    "Zahlungseingänge dürfen nicht manuell bearbeitet werden");
            }
            return base.NewData();
        }

        public override KissServiceResult Search(IUnitOfWork unitOfWork)
        {
            var filter = FilterText;
            var zeTeamCode = SelectedZeTeam != null && SelectedZeTeam.Code != -1 ? SelectedZeTeam.Code : (int?)null;
            var nurOffene = IsNurOffeneChecked;
            var nurNichtZugeordnet = IsNichtZugeordneteChecked;

            var results = Service.SearchZahlungseingang(unitOfWork, filter, zeTeamCode, nurOffene, nurNichtZugeordnet);
            Dispatcher.Invoke(new Action(() => { EntityList = results; }));

            return KissServiceResult.Ok();
        }

        public void ZahlungseingangVerbuchen(object parameter)
        {
            var belegService = Container.Resolve<KbuZahlungseingangAusgleichenService>();

            var ausgeglicheneSollstellungen = ((List<KbuErwarteteEinnahmeDTO>)Sollstellungen).FindAll(e => e.BetragAuszugleichen != 0);

            var result = belegService.Ausgleichen(null, SelectedEntity, ausgeglicheneSollstellungen);
            if (result.IsOk)
            {
                LoadSollstellungen();
            }
        }

        #endregion

        #region Protected Methods

        protected override void OnSelectedEntityChanged(KbuZahlungseingang selectedEntity, KbuZahlungseingang deselectedEntity)
        {
            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);
            InitAusgleichTab();
            LoadHaushaltPersonen();
        }

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            if (propertyName == PropertyName.GetPropertyName(() => new KbuZahlungseingang().FaFallID))
            {
                LoadSollstellungen();
                LoadHaushaltPersonen();
            }
        }

        #endregion

        #region Private Methods

        private decimal CalculateVerfuegbarerRestbetrag()
        {
            if (SelectedEntity == null || SelectedEntity.Betrag == 0 || SelectedEntity.Ausgeglichen)
                return 0;

            decimal totalAusgleich = 0;
            ((List<KbuErwarteteEinnahmeDTO>)Sollstellungen).ForEach(e => totalAusgleich += e.BetragAuszugleichen);

            return (SelectedEntity.Betrag ?? 0) - totalAusgleich;
        }

        private void InitAusgleichTab()
        {
            LoadSollstellungen();
        }

        private void LoadHaushaltPersonen()
        {
            if (SelectedEntity == null || !SelectedEntity.FaFallID.HasValue)
                return;

            var haushaltPersonService = Container.Resolve<WshHaushaltPersonService>();

            var haushaltPersonen = haushaltPersonService.GetHaushaltPersonenForFall(null, SelectedEntity.FaFallID.Value, DateTime.Today, true);

            var unterstuetztePersonen = haushaltPersonen
                                            .Select(hp => hp.BaPerson).ToList();

            unterstuetztePersonen.Insert(0,
                    new BaPerson
                        {
                            BaPersonID = -1,
                            Name = string.Empty,
                            Vorname = string.Empty
                        }
                );

            PersonenHaushalt = new ObservableCollection<BaPerson>(unterstuetztePersonen);
        }

        private void LoadSollstellungen()
        {
            if (SelectedEntity == null || !SelectedEntity.FaFallID.HasValue)
            {
                Sollstellungen = new List<KbuErwarteteEinnahmeDTO>();
                return;
            }

            var einnahmeService = Container.Resolve<KbuErwarteteEinnahmeService>();

            if (SelectedEntity.Ausgeglichen)
            {
                //Ausgeglichene Sollstellung
                Sollstellungen = einnahmeService.GetAusgeglicheneErwarteteEinnahmenByKbuZahlungseingang(null, SelectedEntity);
            }
            else
            {
                //Offene Sollstellungen
                Sollstellungen = einnahmeService.GetOffeneErwarteteEinnahmenByFaFallID(null, SelectedEntity.FaFallID.Value, true, SelectedEntity.BaPersonID_Betrifft, null, null);
            }
        }

        private List<object> SearchDebitor(string searchString)
        {
            var klienten = new List<object>();

            var searchService = Container.Resolve<BaDebitorSearchService>();
            var result = searchService.SearchDebitorInstitution(null, searchString);
            klienten.AddRange(result);

            return klienten;
        }

        private List<object> SearchKlient(string searchString)
        {
            var klienten = new List<object>();

            var searchService = Container.Resolve<BaPersonService>();
            var result = searchService.SearchWshKlient(null, searchString);
            klienten.AddRange(result);

            return klienten;
        }

        #endregion

        #endregion
    }
}