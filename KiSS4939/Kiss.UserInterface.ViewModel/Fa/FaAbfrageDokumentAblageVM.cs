using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Kiss.BusinessLogic.Ba;
using Kiss.BusinessLogic.Ba.DTO;
using Kiss.BusinessLogic.Fa;
using Kiss.BusinessLogic.Sys;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Fa;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Selectable;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel.SearchBox;

using Container = Kiss.Infrastructure.IoC.Container;

namespace Kiss.UserInterface.ViewModel.Fa
{
    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class FaAbfrageDokumentAblageVM : ViewModelSearchList<FaDokumentAblageDTO, FaDokumentAblageSearchParamDto>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string FADOKUMENTABLAGEINHALT = "FaDokumentAblageInhalt";
        private const string FATHEMA = "FaThema";
        private readonly FaAbfrageDokumentAblageService _service;

        #endregion Private Constant/Read-Only Fields

        #region Private Fields

        private SelectableList<BaPerson> _betrPersonen;
        private IList<XLOVCode> _faDokumentAblageInhalt;
        private IList<XLOVCode> _faThema;
        private SelectableList<XLOVCode> _faThemaSuche;
        private bool _nameVornameSelected;
        private BaAdressatDTO _selectedAdressat;
        private BaPerson _selectedBetroffenePerson;
        private XLOVCode _selectedDokumentArt;
        private BaPerson _selectedFalltraeger;
        private XUser _selectedUser;

        #endregion Private Fields

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FaAbfrageDokumentAblageVM"/> class.
        /// </summary>
        public FaAbfrageDokumentAblageVM()
        {
            _service = Container.Resolve<FaAbfrageDokumentAblageService>();
            AdressatSearchBoxVM = new AdressatSearchBoxVM();
            UserSearchBoxVM = new UserSearchBoxVM();
            SearchParameters = new FaDokumentAblageSearchParamDto { NurAktiveFaelle = true };
            _nameVornameSelected = true;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// List of all available "BetrPersonen".
        /// </summary>
        public SelectableList<BaPerson> BetrPersonen
        {
            get { return _betrPersonen; }
            private set { SetProperty(ref _betrPersonen, value, () => BetrPersonen); }
        }

        /// <summary>
        /// List of all available "FaDokumentAblageInhalt".
        /// </summary>
        public IList<XLOVCode> FaDokumentAblageInhalt
        {
            get { return _faDokumentAblageInhalt; }
            private set { SetProperty(ref _faDokumentAblageInhalt, value, () => FaDokumentAblageInhalt); }
        }

        public SearchForStringEventHandler FalltraegerSearchEventHandler
        {
            get { return SearchFalltraeger; }
        }

        /// <summary>
        /// List of all available "FaThema".
        /// </summary>
        public IList<XLOVCode> FaThema
        {
            get { return _faThema; }
            private set { SetProperty(ref _faThema, value, () => FaThema); }
        }

        public SelectableList<XLOVCode> FaThemaSuche
        {
            get { return _faThemaSuche; }
            private set { SetProperty(ref _faThemaSuche, value, () => FaThemaSuche); }
        }

        public SearchForStringEventHandler NameVornameSearchEventHandler
        {
            get { return SearchNameVorname; }
        }

        public BaAdressatDTO SelectedAdressat
        {
            get
            {
                return _selectedAdressat;
            }
            set
            {
                if (SetProperty(ref _selectedAdressat, value, () => SelectedAdressat))
                {
                    if (_selectedAdressat == null)
                    {
                        SearchParameters.DokumentAdressat = null;
                        SearchParameters.DokumentAdressatName = null;
                        SearchParameters.DokumentAdressatIstInstitution = false;
                    }
                    else
                    {
                        SearchParameters.DokumentAdressat = _selectedAdressat.BaInstitutionId ?? _selectedAdressat.BaPersonId;
                        SearchParameters.DokumentAdressatName = _selectedAdressat.NameVorname;
                        SearchParameters.DokumentAdressatIstInstitution = _selectedAdressat.IsTypBaInstitution;
                    }
                }
            }
        }

        public BaPerson SelectedBetroffenePerson
        {
            get
            {
                return _selectedBetroffenePerson;
            }
            set
            {
                if (SetProperty(ref _selectedBetroffenePerson, value, () => SelectedBetroffenePerson))
                {
                    if (_selectedBetroffenePerson == null)
                    {
                        SearchParameters.DokumentBetroffenePersonId = null;
                        SearchParameters.DokumentBetroffenePerson = null;
                    }
                    else
                    {
                        SearchParameters.DokumentBetroffenePersonId = _selectedBetroffenePerson.BaPersonID;
                        SearchParameters.DokumentBetroffenePerson = _selectedBetroffenePerson.LastNameFirstName;
                        SelectedFalltraeger = null;
                    }
                }
            }
        }

        public XLOVCode SelectedDokumentArt
        {
            get
            {
                return _selectedDokumentArt;
            }
            set
            {
                if (SetProperty(ref _selectedDokumentArt, value, () => SelectedDokumentArt))
                {
                    SearchParameters.DokumentArt = _selectedDokumentArt == null ? (int?)null : _selectedDokumentArt.Code;
                }
            }
        }

        public BaPerson SelectedFalltraeger
        {
            get
            {
                return _selectedFalltraeger;
            }
            set
            {
                if (SetProperty(ref _selectedFalltraeger, value, () => SelectedFalltraeger))
                {
                    if (_selectedFalltraeger == null)
                    {
                        SearchParameters.DokumentFalltraegerId = null;
                        SearchParameters.DokumentFalltraeger = null;
                        BetroffenePersonen(null);
                    }
                    else
                    {
                        SearchParameters.DokumentFalltraegerId = _selectedFalltraeger.BaPersonID;
                        SearchParameters.DokumentFalltraeger = _selectedFalltraeger.LastNameFirstName;
                        BetroffenePersonen(_selectedFalltraeger.BaPersonID);
                        NameVornameSelected = _selectedFalltraeger == null;
                        SelectedBetroffenePerson = null;
                    }
                }
            }
        }

        public XUser SelectedUser
        {
            get
            {
                return _selectedUser;
            }
            set
            {
                if (SetProperty(ref _selectedUser, value, () => SelectedUser))
                {
                    if (_selectedUser == null)
                    {
                        SearchParameters.DokumentAutor = null;
                        SearchParameters.DokumentAutorName = null;
                    }
                    else
                    {
                        SearchParameters.DokumentAutor = _selectedUser.UserID;
                        SearchParameters.DokumentAutorName = _selectedUser.LastNameFirstName;
                    }
                }
            }
        }

        protected override async Task InitAsync(InitParameters? initParameters = null)
        {
            var xlovService = Container.Resolve<XLovService>();
            FaDokumentAblageInhalt = xlovService.GetLovCodesByLovName(FADOKUMENTABLAGEINHALT, true);

            FaThema = xlovService.GetLovCodesByLovName(FATHEMA);
            FaThemaSuche = new SelectableList<XLOVCode>(FaThema);
        }

        protected override void ResetSearchParameters(object parameter)
        {
            SearchParameters = new FaDokumentAblageSearchParamDto();
            SelectedFalltraeger = null;
            SelectedBetroffenePerson = null;
            SelectedDokumentArt = null;
            SelectedUser = null;
            SelectedAdressat = null;
            if (FaThemaSuche != null)
            {
                FaThemaSuche.ClearSelection();
            }
        }

        #endregion Properties

        #region Methods

        #region Protected Methods

        protected override IServiceResult<IEnumerable<FaDokumentAblageDTO>> SearchInBackground(FaDokumentAblageSearchParamDto searchParameters,
            CancellationToken cancellationToken)
        {
            searchParameters.DokumentBetrPersonen = _betrPersonen == null ? null : _betrPersonen.SelectedItems.ToArray();
            searchParameters.DokumentThemen = _faThemaSuche.SelectedItems.Select(x => x.Code).ToList();
            var result = _service.RunQuery(searchParameters);
            return result;
        }

        #endregion Protected Methods

        #region Private Methods

        public AdressatSearchBoxVM AdressatSearchBoxVM
        {
            get;
            private set;
        }

        public bool NameVornameSelected
        {
            get { return _nameVornameSelected; }
            private set { SetProperty(ref _nameVornameSelected, value, () => NameVornameSelected); }
        }

        public UserSearchBoxVM UserSearchBoxVM
        {
            get;
            private set;
        }

        private void BetroffenePersonen(int? baPersonId)
        {
            var baPersonService = Container.Resolve<BaPersonService>();
            BetrPersonen = baPersonId != null ? new SelectableList<BaPerson>(baPersonService.GetAffectedPersons((int)baPersonId)) : null;
        }

        private List<object> SearchFalltraeger(string searchString, object o = null)
        {
            var person = new List<object>();

            var baPersonService = Container.Resolve<BaPersonService>();
            var baPersonList = baPersonService.SearchPerson(searchString, true);
            person.AddRange(baPersonList);

            return person;
        }

        private List<object> SearchNameVorname(string searchString, object o = null)
        {
            var person = new List<object>();

            var baPersonService = Container.Resolve<BaPersonService>();
            var baPersonList = baPersonService.SearchPerson(searchString, false);
            person.AddRange(baPersonList);

            return person;
        }

        #endregion Private Methods

        #endregion Methods
    }
}