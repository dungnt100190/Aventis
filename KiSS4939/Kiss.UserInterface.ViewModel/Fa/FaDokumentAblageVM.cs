using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Kiss.BusinessLogic;
using Kiss.BusinessLogic.Ba;
using Kiss.BusinessLogic.Ba.DTO;
using Kiss.BusinessLogic.Fa;
using Kiss.BusinessLogic.Sys;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Fa;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Infrastructure.Selectable;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel.SearchBox;

namespace Kiss.UserInterface.ViewModel.Fa
{
    public class FaDokumentAblageVM : ViewModelSearchListCRUD<FaDokumentAblageDTO, FaDokumentAblage, FaDokumentAblageSearchParamDto, int>
    {
        private const string FADOKUMENTABLAGEINHALT = "FaDokumentAblageInhalt";
        private const string FATHEMA = "FaThema";
        private BaAdressatDTO _adressatSuche;
        private int _baPersonId;
        private SelectableList<BaPerson> _betroffenePersonen;
        private IList<BaPerson> _betroffenePersonenList;
        private SelectableList<BaPerson> _betroffenePersonenSuche;
        private XUser _currentUser;
        private IList<XLOVCode> _faDokumentAblageInhalt;
        private SelectableList<XLOVCode> _faThema;
        private IList<XLOVCode> _faThemaList;
        private SelectableList<XLOVCode> _faThemaSuche;
        private BaAdressatDTO _selectedAdressat;
        private XLOVCode _selectedDokumentAblageInhalt;
        private XUser _selectedUser;
        private XUser _userSuche;

        public FaDokumentAblageVM()
            : base(Container.Resolve<FaDokumentAblageService>())
        {
            RequiredParameters = InitParameterValue.BaPersonID | InitParameterValue.FaLeistungID;

            SearchParameters = new FaDokumentAblageSearchParamDto();
            AdressatSearchBoxVM = new AdressatSearchBoxVM();
            UserSearchBoxVM = new UserSearchBoxVM();
        }

        public AdressatSearchBoxVM AdressatSearchBoxVM
        {
            get;
            private set;
        }

        public BaAdressatDTO AdressatSuche
        {
            get
            {
                return _adressatSuche;
            }
            set
            {
                if (SetProperty(ref _adressatSuche, value, () => AdressatSuche))
                {
                    if (_adressatSuche == null)
                    {
                        SearchParameters.DokumentAdressat = null;
                        SearchParameters.DokumentAdressatIstInstitution = false;
                        SearchParameters.DokumentAdressatName = null;
                    }
                    else
                    {
                        SearchParameters.DokumentAdressat = _adressatSuche.BaInstitutionId ?? _adressatSuche.BaPersonId;
                        SearchParameters.DokumentAdressatIstInstitution = _adressatSuche.IsTypBaInstitution;
                        SearchParameters.DokumentAdressatName = _adressatSuche.NameVorname;
                    }
                }
            }
        }

        public int BaPersonId
        {
            get { return _baPersonId; }
            private set
            {
                if (SetProperty(ref _baPersonId, value, () => BaPersonId))
                {
                    AdressatSearchBoxVM.BaPersonId = _baPersonId;
                }
            }
        }

        public SelectableList<BaPerson> BetroffenePersonen
        {
            get { return _betroffenePersonen; }
            private set
            {
                SetProperty(ref _betroffenePersonen, value, () => BetroffenePersonen);
            }
        }

        public IList<BaPerson> BetroffenePersonenList
        {
            get { return _betroffenePersonenList; }
            private set
            {
                SetProperty(ref _betroffenePersonenList, value, () => BetroffenePersonenList);
            }
        }

        public SelectableList<BaPerson> BetroffenePersonenSuche
        {
            get { return _betroffenePersonenSuche; }
            private set { SetProperty(ref _betroffenePersonenSuche, value, () => BetroffenePersonenSuche); }
        }

        public IList<XLOVCode> FaDokumentAblageInhalt
        {
            get { return _faDokumentAblageInhalt; }
            private set { SetProperty(ref _faDokumentAblageInhalt, value, () => FaDokumentAblageInhalt); }
        }

        public int FaLeistungId { get; private set; }

        public SelectableList<XLOVCode> FaThema
        {
            get { return _faThema; }
            private set { SetProperty(ref _faThema, value, () => FaThema); }
        }

        public IList<XLOVCode> FaThemaList
        {
            get { return _faThemaList; }
            private set { SetProperty(ref _faThemaList, value, () => FaThemaList); }
        }

        public SelectableList<XLOVCode> FaThemaSuche
        {
            get { return _faThemaSuche; }
            private set { SetProperty(ref _faThemaSuche, value, () => FaThemaSuche); }
        }

        public BaAdressatDTO SelectedAdressat
        {
            get
            {
                return _selectedAdressat;
            }
            set
            {
                if (SetProperty(ref _selectedAdressat, value, () => SelectedAdressat) && SelectedEntity != null)
                {
                    SelectedEntity.WrappedEntity.BaPerson = null;
                    SelectedEntity.WrappedEntity.BaInstitution = null;

                    if (_selectedAdressat == null)
                    {
                        SelectedEntity.AdressatName = null;
                        SelectedEntity.WrappedEntity.BaInstitutionID_Adressat = null;
                        SelectedEntity.WrappedEntity.BaPersonID_Adressat = null;
                    }
                    else
                    {
                        if (_selectedAdressat.IsTypBaInstitution)
                        {
                            SelectedEntity.AdressatName = _selectedAdressat.NameVorname;
                            SelectedEntity.WrappedEntity.BaInstitutionID_Adressat = _selectedAdressat.BaInstitutionId;
                            SelectedEntity.WrappedEntity.BaPersonID_Adressat = null;
                        }
                        else
                        {
                            SelectedEntity.AdressatName = _selectedAdressat.NameVorname;
                            SelectedEntity.WrappedEntity.BaPersonID_Adressat = _selectedAdressat.BaPersonId;
                            SelectedEntity.WrappedEntity.BaInstitutionID_Adressat = null;
                        }
                    }
                }
            }
        }

        public XLOVCode SelectedDokumentAblageInhalt
        {
            get
            {
                return _selectedDokumentAblageInhalt;
            }
            set
            {
                if (SetProperty(ref _selectedDokumentAblageInhalt, value, () => SelectedDokumentAblageInhalt))
                {
                    SearchParameters.DokumentArt = _selectedDokumentAblageInhalt == null ? (int?)null : _selectedDokumentAblageInhalt.Code;
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
                    if (_selectedUser != null && SelectedEntity != null)
                    {
                        SelectedEntity.AutorNameVorname = _selectedUser.LastNameFirstName;
                        SelectedEntity.WrappedEntity.XUser = _selectedUser;
                        SelectedEntity.WrappedEntity.UserID = _selectedUser.UserID;
                    }
                }
            }
        }

        public UserSearchBoxVM UserSearchBoxVM
        {
            get;
            private set;
        }

        public XUser UserSuche
        {
            get
            {
                return _userSuche;
            }
            set
            {
                if (SetProperty(ref _userSuche, value, () => UserSuche))
                {
                    if (_userSuche != null)
                    {
                        SearchParameters.DokumentAutor = _userSuche.UserID;
                        SearchParameters.DokumentAutorName = _userSuche.LastNameFirstName;
                    }
                    else
                    {
                        SearchParameters.DokumentAutor = null;
                        SearchParameters.DokumentAutorName = null;
                    }
                }
            }
        }

        private FaDokumentAblageService Service
        {
            get { return (FaDokumentAblageService)ServiceCRUD; }
        }

        public override IServiceResult SaveData()
        {
            if (SelectedEntity == null)
            {
                return ServiceResult.Ok();
            }

            var betroffenePersonenIdsNew = BetroffenePersonen.SelectedItems.Select(x => x.BaPersonID).ToList();
            var betroffenePersonenIdsOld = SelectedEntity.WrappedEntity.BetroffenePersonenIds.ToList();

            if (!betroffenePersonenIdsNew.SequenceEqual(betroffenePersonenIdsOld))
            {
                SelectedEntity.WrappedEntity.BetroffenePersonenIds = betroffenePersonenIdsNew;
            }

            var themenNew = FaThema.SelectedItems.Select(x => x.Code).ToList();
            var themenOld = SelectedEntity.FaThemaCodeListe ?? new List<int>();

            if (!themenNew.SequenceEqual(themenOld))
            {
                SelectedEntity.FaThemaCodeListe = themenNew;
            }

            return base.SaveData();
        }

        protected override async Task InitAsync(InitParameters? initParameters = null)
        {
            FaLeistungId = initParameters.Value.FaLeistungID.Value;
            BaPersonId = initParameters.Value.BaPersonID.Value;

            var xlovService = Container.Resolve<XLovService>();
            FaDokumentAblageInhalt = xlovService.GetLovCodesByLovName(FADOKUMENTABLAGEINHALT, true);

            FaThemaList = xlovService.GetLovCodesByLovName(FATHEMA);
            FaThema = new SelectableList<XLOVCode>(FaThemaList);
            FaThemaSuche = new SelectableList<XLOVCode>(FaThemaList);

            var baPersonService = Container.Resolve<BaPersonService>();
            BetroffenePersonenList = baPersonService.GetAffectedPersons(BaPersonId);
            BetroffenePersonen = new SelectableList<BaPerson>(BetroffenePersonenList);
            BetroffenePersonenSuche = new SelectableList<BaPerson>(BetroffenePersonenList);

            var sessionService = Container.Resolve<ISessionService>();
            var userService = Container.Resolve<XUserService>();
            _currentUser = userService.GetEntityById(sessionService.AuthenticatedUser.UserID);

            SearchParameters = new FaDokumentAblageSearchParamDto();
            SearchTask.StartCommand.Execute(SearchParameters);
        }

        protected override void InitNewEntity(FaDokumentAblageDTO entity)
        {
            base.InitNewEntity(entity);

            entity.WrappedEntity.FaLeistungID = FaLeistungId;
            entity.WrappedEntity.BetroffenePersonenIds = new List<int>();
            entity.WrappedEntity.UserID = _currentUser.UserID;
        }

        protected override void OnSelectedEntityChanged(FaDokumentAblageDTO selectedEntity, FaDokumentAblageDTO deselectedEntity)
        {
            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);

            if (selectedEntity != null)
            {
                var adressatService = Container.Resolve<BaAdressatService>();
                SelectedAdressat = adressatService.GetAdressat(selectedEntity.WrappedEntity.BaInstitutionID_Adressat, selectedEntity.WrappedEntity.BaPersonID_Adressat);

                var userService = Container.Resolve<XUserService>();
                SelectedUser = userService.GetEntityById(selectedEntity.WrappedEntity.UserID);

                foreach (var selectableItem in BetroffenePersonen)
                {
                    selectableItem.IsSelected = selectedEntity.WrappedEntity.BetroffenePersonenIds != null &&
                                                selectedEntity.WrappedEntity.BetroffenePersonenIds.Contains(selectableItem.Item.BaPersonID);
                }

                foreach (var selectableItem in FaThema)
                {
                    selectableItem.IsSelected = selectedEntity.FaThemaCodeListe != null &&
                                                selectedEntity.FaThemaCodeListe.Contains(selectableItem.Item.Code);
                }
            }
            else
            {
                SelectedAdressat = null;
                SelectedUser = null;
                BetroffenePersonen.ClearSelection();
                FaThema.ClearSelection();
            }
        }

        protected override void ResetSearchParameters(object parameter)
        {
            SearchParameters = new FaDokumentAblageSearchParamDto();
            AdressatSuche = null;
            FaThemaSuche.ClearSelection();
            SelectedDokumentAblageInhalt = null;
            UserSuche = null;
            BetroffenePersonenSuche.ClearSelection();
        }

        protected override IServiceResult<IEnumerable<FaDokumentAblageDTO>> SearchInBackground(FaDokumentAblageSearchParamDto searchParameters, CancellationToken cancellationToken)
        {
            searchParameters.FaLeistungId = FaLeistungId;
            searchParameters.DokumentBetrPersonen = BetroffenePersonenSuche.SelectedItems.ToList();
            searchParameters.DokumentThemen = _faThemaSuche.SelectedItems.Select(x => x.Code).ToList();
            searchParameters.DokumentFalltraegerId = BaPersonId;
            return Service.RunQuery(searchParameters);
        }
    }
}