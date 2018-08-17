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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Kiss.UserInterface.ViewModel.Kes
{
    public class KesDokumentVM : ViewModelSearchListCRUD<KesDokumentDTO, KesDokument, int, int>
    {
        public const string ID_KESAUFTRAG = "KesAuftrag";

        private const string DOC_CONTEXT_NAME_KESABKLAERUNGAUFTRAGBEARBEITUNGDOKUMENT = "KesAbklaerungAuftragBearbeitungDokument";

        private const string DOC_CONTEXT_NAME_KESMASSNAHMEDOKUMENT = "KesMassnahmeDokument";

        private const string LOV_KESDOKUMENTART = "KesDokumentArt";

        private const string LOV_KESDOKUMENTRESULTAT = "KesDokumentResultat";

        private readonly KesDokumentTyp _kesDokumentTypCode;

        private int _baPersonId;

        private string _docContextName;

        private int? _faLeistungId;

        private KesAuftrag _kesAuftrag;

        private IList<XLOVCode> _kesDokumentartCodes;

        private IList<XLOVCode> _kesDokumentResultatCodes;

        private IList<XLOVCode> _kesDokumentResultatCodesFiltered;

        private BaAdressatDTO _selectedAdressat;

        private string _title;

        private DokumentControls _visibleControls;

        public KesDokumentVM()
            : this(DokumentControls.Themen | DokumentControls.Dokumentart | DokumentControls.DokumentResultat | DokumentControls.Versand, KesDokumentTyp.AuftragDokument)
        {
        }

        public KesDokumentVM(DokumentControls visibleControls, KesDokumentTyp dokumentTypCode)
            : base(Container.Resolve<KesDokumentService>())
        {
            RequiredParameters = InitParameterValue.BaPersonID | InitParameterValue.CustomData;

            UserSearchBoxVM = new UserSearchBoxVM();
            AdressatSearchBoxVM = new AdressatSearchBoxVM();

            _visibleControls = visibleControls;
            _kesDokumentTypCode = dokumentTypCode;

            _docContextName = (dokumentTypCode == KesDokumentTyp.AuftragDokument)
                ? DOC_CONTEXT_NAME_KESABKLAERUNGAUFTRAGBEARBEITUNGDOKUMENT
                : DOC_CONTEXT_NAME_KESMASSNAHMEDOKUMENT;

            RefreshAfterSetInclDeleted = false;
        }

        [Flags]
        public enum DokumentControls
        {
            DokumentResultat = 1,
            Dokumentart = 2,
            Themen = 4,
            Versand = 8,
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

        public bool DokumentartVisible
        {
            get { return _visibleControls.HasFlag(DokumentControls.Dokumentart); }
            set
            {
                if (_visibleControls.HasFlag(DokumentControls.Dokumentart) == value)
                    return;

                if (value)
                {
                    _visibleControls |= DokumentControls.Dokumentart;
                }
                else
                {
                    _visibleControls ^= DokumentControls.Dokumentart;
                }

                NotifyPropertyChanged.RaisePropertyChanged(PropertyName.GetPropertyName(() => DokumentartVisible));
            }
        }

        public bool DokumentResultatVisible
        {
            get { return _visibleControls.HasFlag(DokumentControls.DokumentResultat); }
            set
            {
                if (_visibleControls.HasFlag(DokumentControls.DokumentResultat) == value)
                {
                    return;
                }

                if (value)
                {
                    _visibleControls |= DokumentControls.DokumentResultat;
                }
                else
                {
                    _visibleControls ^= DokumentControls.DokumentResultat;
                }

                NotifyPropertyChanged.RaisePropertyChanged(PropertyName.GetPropertyName(() => DokumentResultatVisible));
            }
        }

        public bool HasSelection
        {
            get { return EntityList.Any(dok => dok.Selektion); }
            set { NotifyPropertyChanged.RaisePropertyChanged(() => HasSelection); }
        }

        public IList<XLOVCode> KesDokumentartCodes
        {
            get { return _kesDokumentartCodes; }
            set { SetProperty(ref _kesDokumentartCodes, value, () => KesDokumentartCodes); }
        }

        public IList<XLOVCode> KesDokumentResultatCodesFiltered
        {
            get { return _kesDokumentResultatCodesFiltered; }
            set { SetProperty(ref _kesDokumentResultatCodesFiltered, value, () => KesDokumentResultatCodesFiltered); }
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
                    //SelectedEntity.WrappedEntity.BaPerson = null;
                    //SelectedEntity.WrappedEntity.BaInstitution = null;

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
                            SelectedEntity.WrappedEntity.BaPerson = null;
                            SelectedEntity.WrappedEntity.BaPersonID_Adressat = null;
                        }
                        else
                        {
                            SelectedEntity.AdressatName = _selectedAdressat.NameVorname;
                            SelectedEntity.WrappedEntity.BaPersonID_Adressat = _selectedAdressat.BaPersonId;
                            SelectedEntity.WrappedEntity.BaInstitution = null;
                            SelectedEntity.WrappedEntity.BaInstitutionID_Adressat = null;
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

        public bool ThemenVisible
        {
            get { return _visibleControls.HasFlag(DokumentControls.Themen); }
            set
            {
                if (_visibleControls.HasFlag(DokumentControls.Themen) == value)
                {
                    return;
                }

                if (value)
                {
                    _visibleControls |= DokumentControls.Themen;
                }
                else
                {
                    _visibleControls ^= DokumentControls.Themen;
                }

                NotifyPropertyChanged.RaisePropertyChanged(PropertyName.GetPropertyName(() => ThemenVisible));
            }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value, () => Title); }
        }

        public UserSearchBoxVM UserSearchBoxVM
        {
            get;
            private set;
        }

        public bool VersandVisible
        {
            get { return _visibleControls.HasFlag(DokumentControls.Versand); }
            set
            {
                if (_visibleControls.HasFlag(DokumentControls.Versand) == value)
                {
                    return;
                }

                if (value)
                {
                    _visibleControls |= DokumentControls.Versand;
                }
                else
                {
                    _visibleControls ^= DokumentControls.Versand;
                }

                NotifyPropertyChanged.RaisePropertyChanged(PropertyName.GetPropertyName(() => VersandVisible));
            }
        }

        private KesDokumentService Service
        {
            get { return (KesDokumentService)ServiceCRUD; }
        }

        public void DokumenteExportieren(string fileName)
        {
            CompletelyBusyTasks.AddObservation(
                Task.Run(
                    () =>
                    {
                        ValidationResult = Service.SaveAsPdf(EntityList.Where(x => x.Selektion).ToList(), fileName);
                    }));
        }

        public void FilterKesDokumentResultatCodes()
        {
            if (_kesAuftrag != null)
            {
                var lovService = Container.Resolve<XLovService>();
                KesDokumentResultatCodesFiltered = lovService.FilterLovCodes(
                    _kesDokumentResultatCodes,
                    _kesAuftrag.KesAuftragAbklaerungsartCode.HasValue ? Convert.ToString(_kesAuftrag.KesAuftragAbklaerungsartCode.Value) : null);
            }
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "ADRESSATID":
                    return _selectedAdressat.AdressatId;

                case "BAPERSONID":
                    return _baPersonId;

                case "KESDOKUMENTID":
                    return SelectedEntity.WrappedEntity.KesDokumentID;

                case "KESAUFTRAGID":
                    return SelectedEntity.WrappedEntity.KesAuftragID;

                case "FALEISTUNGID":
                    return SelectedEntity.WrappedEntity.FaLeistungID;

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
            if (!initParameters.HasValue)
            {
                return;
            }

            var dictionary = initParameters.Value.CustomData;

            if (dictionary == null)
            {
                return;
            }

            _faLeistungId = initParameters.Value.FaLeistungID;
            _baPersonId = initParameters.Value.BaPersonID.Value;

            var lovService = Container.Resolve<XLovService>();
            _kesDokumentResultatCodes = lovService.GetLovCodesByLovName(
                LOV_KESDOKUMENTRESULTAT,
                true,
                true);

            object kesAuftrag;
            if (dictionary.TryGetValue(ID_KESAUFTRAG, out kesAuftrag) && (_kesAuftrag = kesAuftrag as KesAuftrag) != null)
            {
                SearchParameters = _kesAuftrag.KesAuftragID;
                AddViewRightInterceptor(new KesMaskenrechtInterceptor(_kesAuftrag.FaLeistungID));
            }
            else if (_faLeistungId.HasValue)
            {
                SearchParameters = _faLeistungId.Value;
                AddViewRightInterceptor(new KesMaskenrechtInterceptor(_faLeistungId.Value));
            }
            else
            {
                return;
            }

            FilterKesDokumentResultatCodes();

            AdressatSearchBoxVM.BaPersonId = _baPersonId;

            KesDokumentartCodes = lovService.GetLovCodesByLovName(LOV_KESDOKUMENTART, true, true);

            SearchTask.StartCommand.Execute();
        }

        protected override void InitNewEntity(KesDokumentDTO entity)
        {
            base.InitNewEntity(entity);

            if (_kesAuftrag != null)
            {
                entity.WrappedEntity.KesAuftragID = _kesAuftrag.KesAuftragID;
            }
            else if (_faLeistungId.HasValue)
            {
                entity.WrappedEntity.FaLeistungID = _faLeistungId.Value;
            }

            entity.WrappedEntity.UserID = Container.Resolve<ISessionService>().AuthenticatedUser.UserID;
            entity.WrappedEntity.KesDokumentTypCode = (int)_kesDokumentTypCode;

            var userService = Container.Resolve<XUserService>();
            entity.WrappedEntity.XUser = userService.GetEntityById(entity.WrappedEntity.UserID.Value);
        }

        protected override void OnSelectedEntityChanged(KesDokumentDTO selectedEntity, KesDokumentDTO deselectedEntity)
        {
            SelectedUser = (selectedEntity != null ? selectedEntity.WrappedEntity.XUser : null);

            SelectedAdressat = selectedEntity == null ? null : new BaAdressatDTO
            {
                NameVorname = selectedEntity.AdressatName,
                BaInstitutionId = selectedEntity.WrappedEntity.BaInstitutionID_Adressat,
                BaPersonId = selectedEntity.WrappedEntity.BaPersonID_Adressat,
            };

            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);
            NotifyPropertyChanged.RaisePropertyChanged(() => HasSelection);
        }

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            base.OnSelectedEntityPropertyChanged(propertyName);
            NotifyPropertyChanged.RaisePropertyChanged(() => HasSelection);
        }

        protected override IServiceResult<IEnumerable<KesDokumentDTO>> SearchInBackground(int kesAuftragId, CancellationToken cancellationToken)
        {
            if (_kesAuftrag != null)
            {
                return new ServiceResult<IEnumerable<KesDokumentDTO>>(Service.GetByKesAuftragId(_kesAuftrag.KesAuftragID, (int)_kesDokumentTypCode, InclDeleted));
            }

            if (_faLeistungId.HasValue)
            {
                return new ServiceResult<IEnumerable<KesDokumentDTO>>(Service.GetByFaLeistungId(_faLeistungId.Value, (int)_kesDokumentTypCode, InclDeleted));
            }

            return null;
        }
    }
}