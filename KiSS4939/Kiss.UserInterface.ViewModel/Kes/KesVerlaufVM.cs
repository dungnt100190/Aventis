using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Kiss.BusinessLogic;
using Kiss.BusinessLogic.Ba.DTO;
using Kiss.BusinessLogic.Kes;
using Kiss.BusinessLogic.Sys;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Kes;
using Kiss.DbContext.Enums.Kes;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel.SearchBox;

namespace Kiss.UserInterface.ViewModel.Kes
{
    public class KesVerlaufVM : ViewModelSearchListCRUD<KesVerlaufDTO, KesVerlauf, int, int>
    {
        private const string DOC_CONTEXT_NAME_PFLEGEKINDERAUFSICHT = "KesPflegekinderaufsichtVerlauf";
        private const string DOC_CONTEXT_NAME_PRIMA_BEGLEITUNG = "KesFachstellePriMaVerlauf";
        private readonly KesVerlaufTyp _kesVerlaufTyp;

        private int _baPersonId;
        private string _docContextName;
        private IList<XLOVCode> _faDauerCodeList;
        private int _faLeistungId;
        private IList<XLOVCode> _kesDienstleistungCodeList;
        private IList<XLOVCode> _kesKontaktartCodeList;
        private BaAdressatDTO _selectedAdressat;

        public KesVerlaufVM()
            : this(KesVerlaufTyp.PriMaBegleitung)
        {
        }

        public KesVerlaufVM(KesVerlaufTyp kesVerlaufTyp)
            : base(Container.Resolve<KesVerlaufService>())
        {
            RequiredParameters = InitParameterValue.FaLeistungID | InitParameterValue.BaPersonID;

            _kesVerlaufTyp = kesVerlaufTyp;

            UserSearchBoxVM = new UserSearchBoxVM();
            AdressatSearchBoxVM = new AdressatSearchBoxVM();

            if (kesVerlaufTyp == KesVerlaufTyp.PriMaBegleitung)
            {
                DocContextName = DOC_CONTEXT_NAME_PRIMA_BEGLEITUNG;
                IsPflegekinderaufsicht = false;
            }
            else
            {
                DocContextName = DOC_CONTEXT_NAME_PFLEGEKINDERAUFSICHT;
                IsPflegekinderaufsicht = true;
            }
        }

        public AdressatSearchBoxVM AdressatSearchBoxVM
        {
            get;
            private set;
        }

        public string DocContextName
        {
            get { return _docContextName; }
            set { SetProperty(ref _docContextName, value, () => DocContextName); }
        }

        public IList<XLOVCode> FaDauerCodeList
        {
            get { return _faDauerCodeList; }
            set { SetProperty(ref _faDauerCodeList, value, () => FaDauerCodeList); }
        }

        public bool IsPflegekinderaufsicht
        {
            get;
            private set;
        }

        public IList<XLOVCode> KesDienstleistungCodeList
        {
            get { return _kesDienstleistungCodeList; }
            set { SetProperty(ref _kesDienstleistungCodeList, value, () => KesDienstleistungCodeList); }
        }

        public IList<XLOVCode> KesKontaktartCodeList
        {
            get { return _kesKontaktartCodeList; }
            set { SetProperty(ref _kesKontaktartCodeList, value, () => KesKontaktartCodeList); }
        }

        public BaAdressatDTO SelectedAdressat
        {
            get { return _selectedAdressat; }
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
                        }
                        else
                        {
                            SelectedEntity.AdressatName = _selectedAdressat.NameVorname;
                            SelectedEntity.WrappedEntity.BaPersonID_Adressat = _selectedAdressat.BaPersonId;
                        }
                    }
                }
            }
        }

        public XUser SelectedUser
        {
            get { return SelectedEntity != null ? SelectedEntity.WrappedEntity.XUser : null; }
            set
            {
                if (SelectedEntity != null)
                {
                    SelectedEntity.WrappedEntity.XUser = value;
                    SelectedEntity.WrappedEntity.UserID = (value != null ? value.UserID : (int?)null);
                }

                NotifyPropertyChanged.RaisePropertyChanged(() => SelectedUser);
            }
        }

        public UserSearchBoxVM UserSearchBoxVM
        {
            get;
            private set;
        }

        private KesVerlaufService Service
        {
            get { return (KesVerlaufService)ServiceCRUD; }
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "ADRESSATID":
                    return _selectedAdressat.AdressatId;

                case "BAPERSONID":
                    return _baPersonId;

                case "KESVERLAUFID":
                    return SelectedEntity.WrappedEntity.KesVerlaufID;

                default:
                    return base.GetContextValue(fieldName);
            }
        }

        public override IServiceResult SaveData()
        {
            if (SelectedEntity == null || !IsSelectedEntityTreeModified())
            {
                return ServiceResult.Ok();
            }

            var result = base.SaveData();
            Service.RefreshTree();

            return result;
        }

        protected override async Task InitAsync(InitParameters? initParameters = null)
        {
            _faLeistungId = initParameters.Value.FaLeistungID.Value;
            _baPersonId = initParameters.Value.BaPersonID.Value;
            AddViewRightInterceptor(new KesMaskenrechtInterceptor(_faLeistungId));

            var xLovService = Container.Resolve<XLovService>();
            var filterKesDienstleistungCode = _kesVerlaufTyp == KesVerlaufTyp.PriMaBegleitung ? "2" : "1";
            KesDienstleistungCodeList = xLovService.GetLovCodesByLovName("KesDienstleistung", true, true, filterKesDienstleistungCode);

            KesKontaktartCodeList = xLovService.GetLovCodesByLovName("KesKontaktart", true, true);
            FaDauerCodeList = xLovService.GetLovCodesByLovName("FaDauer", true, true);

            AdressatSearchBoxVM.BaPersonId = initParameters.Value.BaPersonID;

            SearchParameters = _faLeistungId;
            SearchTask.StartCommand.Execute();
        }

        protected override void InitNewEntity(KesVerlaufDTO entity)
        {
            base.InitNewEntity(entity);

            entity.WrappedEntity.FaLeistungID = _faLeistungId;
            entity.WrappedEntity.KesVerlaufTypCode = (int)_kesVerlaufTyp;

            entity.WrappedEntity.UserID = Container.Resolve<ISessionService>().AuthenticatedUser.UserID;
            var userService = Container.Resolve<XUserService>();
            entity.WrappedEntity.XUser = userService.GetEntityById(entity.WrappedEntity.UserID.Value);
        }

        protected override void OnSelectedEntityChanged(KesVerlaufDTO selectedEntity, KesVerlaufDTO deselectedEntity)
        {
            SelectedUser = (selectedEntity != null ? selectedEntity.WrappedEntity.XUser : null);

            SelectedAdressat = selectedEntity == null ? null : new BaAdressatDTO
            {
                NameVorname = selectedEntity.AdressatName,
                BaInstitutionId = selectedEntity.WrappedEntity.BaInstitutionID_Adressat,
                BaPersonId = selectedEntity.WrappedEntity.BaPersonID_Adressat,
            };

            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);
        }

        protected override IServiceResult<IEnumerable<KesVerlaufDTO>> SearchInBackground(int faLeistungId, CancellationToken cancellationToken)
        {
            return new ServiceResult<IEnumerable<KesVerlaufDTO>>(Service.GetByFaLeistungId(faLeistungId, _kesVerlaufTyp));
        }
    }
}