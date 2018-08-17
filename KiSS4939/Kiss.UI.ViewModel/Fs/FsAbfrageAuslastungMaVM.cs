using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Kiss.BL.Fs;
using Kiss.BL.KissSystem;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.UI;
using Kiss.Model;
using Kiss.Model.DTO.Fs;
using Container = Kiss.Infrastructure.IoC.Container;

namespace Kiss.UI.ViewModel.Fs
{
    public class FsAbfrageAuslastungMaVM : ViewModelSearchListBase
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string SPEZIALRECHT_AUSWAHL_ANDERE_MITARBEITER = "FsAbfrageAuslastung_AuswahlAndereMitarbeiter";

        private readonly bool _hatSpezialrechtAuswertungAndererMitarbeiter = true;
        private readonly FsDienstleistungAuswertungService _service;
        private readonly BerechtigungsService _serviceSpezialrecht;
        private readonly XUserService _userService;

        #endregion

        #region Private Fields

        private ObservableCollection<FsDienstleistungAuswertungDTO> _searchResult;
        private decimal? _totalDlpZeitBedarf;
        private decimal? _totalDlpZeitZugewiesen;
        private decimal? _totalZeitFuerFallarbeit;
        private KissServiceResult _warning;

        #endregion

        #endregion

        #region Constructors

        public FsAbfrageAuslastungMaVM()
        {
            _service = Container.Resolve<FsDienstleistungAuswertungService>();
            _userService = Container.Resolve<XUserService>();

            SearchDTO = new FsDienstleistungAuswSearchParamDTO
            {
                DatumVon = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1),
                DatumBis = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month)),
            };

            if (!DesignMode)
            {
                var session = Container.Resolve<ISessionService>();
                SelectedUser = _userService.GetById(null, session.AuthenticatedUser.UserID);
                _serviceSpezialrecht = Container.Resolve<BerechtigungsService>();
                _hatSpezialrechtAuswertungAndererMitarbeiter = _serviceSpezialrecht.HatUserSpezialrecht(null, SPEZIALRECHT_AUSWAHL_ANDERE_MITARBEITER);
            }
        }

        #endregion

        #region Properties

        private XUser _selectedUser;

        public bool HatSpezialrechtAuswertungAndererMitarbeiter
        {
            get { return _hatSpezialrechtAuswertungAndererMitarbeiter; }
        }

        public FsDienstleistungAuswSearchParamDTO SearchDTO
        {
            get;
            private set;
        }

        public ObservableCollection<FsDienstleistungAuswertungDTO> SearchResult
        {
            get
            {
                return _searchResult;
            }

            set
            {
                _searchResult = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => SearchResult);
            }
        }

        ////public int? UserID
        ////{
        ////    get { return _userId; }
        ////    set {
        ////        _userId = value;
        ////        SearchDTO.UserID = _userId;
        ////        SearchValidationResult = Search(null);
        ////    }
        ////}
        public XUser SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    SearchDTO.UserID = _selectedUser == null ? (int?)null : _selectedUser.UserID;
                    SearchDTO.UserNameLastname = _selectedUser == null ? null : _selectedUser.LastNameFirstName;
                }
            }
        }

        public decimal? TotalDlpZeitBedarf
        {
            get
            {
                return _totalDlpZeitBedarf;
            }

            private set
            {
                _totalDlpZeitBedarf = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => TotalDlpZeitBedarf);
            }
        }

        public decimal? TotalDlpZeitZugewiesen
        {
            get
            {
                return _totalDlpZeitZugewiesen;
            }
            private set
            {
                _totalDlpZeitZugewiesen = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => TotalDlpZeitZugewiesen);
            }
        }

        public decimal? TotalZeitFuerFallarbeit
        {
            get
            {
                return _totalZeitFuerFallarbeit;
            }
            private set
            {
                _totalZeitFuerFallarbeit = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => TotalZeitFuerFallarbeit);
            }
        }

        public SearchForStringEventHandler UserSearchEventHandler
        {
            get { return SearchUser; }
        }

        public KissServiceResult Warning
        {
            get
            {
                return _warning;
            }
            private set
            {
                _warning = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Warning);
            }
        }

        #endregion

        #region Commands

        public ICommand JumpToFaPhase
        {
            get
            {
                return new BaseCommand(JumpToFaPhaseAction);
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        public override KissServiceResult Search(IUnitOfWork unitOfWork)
        {
            IList<FsDienstleistungAuswertungDTO> resultDTO;
            ValidationResult = _service.RunQuery(SearchDTO, out resultDTO);

            if (ValidationResult.IsError)
            {
                return ValidationResult;
            }

            //Holen der Nettoarbeitszeit (verfügbar für Fallarbeit).
            FsVerfuegbareArbeitszeitService dlAuswService = Container.Resolve<FsVerfuegbareArbeitszeitService>();
            decimal verfuegbareArbeitszeit;
            Warning =
                dlAuswService.GetMitarbeiterArbeitszeit(null, out verfuegbareArbeitszeit, new TimePeriod(SearchDTO.DatumVon, SearchDTO.DatumBis), SearchDTO.UserID);
            TotalZeitFuerFallarbeit = verfuegbareArbeitszeit;

            SearchResult = new ObservableCollection<FsDienstleistungAuswertungDTO>(resultDTO);
            TotalDlpZeitZugewiesen = SearchResult.Sum(item => item.StundenZugewiesen);
            TotalDlpZeitBedarf = SearchResult.Sum(item => item.StundenBedarf);

            return KissServiceResult.Ok();
        }

        #endregion

        #region Private Static Methods

        private static void JumpToFaPhaseAction(object obj)
        {
            var dto = obj as FsDienstleistungAuswertungDTO;
            if (dto == null)
            {
                return;
            }

            var controller = Container.Resolve<IKissFormController>();
            controller.OpenForm(
                "FrmFall",
                "Action", "JumpToPath",
                "ModulID", 2,
                "BaPersonID", dto.BaPersonId,
                "TreeNodeID", string.Format("CtlFaBeratungsphase{0}", dto.FaPhaseID));
        }

        #endregion

        private List<object> SearchUser(string searchString, object o = null)
        {
            var users = new List<object>();

            var userService = Container.Resolve<XUserService>();
            var userList = userService.SearchUser(null, searchString);
            users.AddRange(userList);

            return users;
        }

        #endregion
    }
}