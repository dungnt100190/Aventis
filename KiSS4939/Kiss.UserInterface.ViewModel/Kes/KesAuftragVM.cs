using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Kiss.BusinessLogic;
using Kiss.BusinessLogic.Ba;
using Kiss.BusinessLogic.Kes;
using Kiss.BusinessLogic.Sys;
using Kiss.DbContext;
using Kiss.DbContext.Enums.Kes;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Infrastructure.Selectable;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel.SearchBox;

namespace Kiss.UserInterface.ViewModel.Kes
{
    public class KesAuftragVM : ViewModelSearchListCRUD<KesAuftrag, KesAuftrag, int, int>
    {
        private const int TAB_INDEX_DOKUMENT = 1;
        private const int TAB_INDEX_ERFASSEN = 0;

        private int _baPersonId;
        private SelectableList<BaPerson> _betroffenePersonen;
        private int _faLeistungId;
        private IList<XLOVCode> _kesAuftragAbklaerungsartCodes;
        private IList<XLOVCode> _kesAuftragAbklaerungsartEsCodes;
        private IList<XLOVCode> _kesAuftragAbklaerungsartKsCodes;
        private IList<XLOVCode> _kesAuftragAbschlussgrundCode;
        private IList<XLOVCode> _kesAuftragDurchCode;
        private KesDokumentVM _kesDokumentVM;
        private IList<XLOVCode> _kesGefaehrdungsmeldungDurchCodes;
        private IList<XLOVCode> _kesGefaehrdungsmeldungDurchEsCodes;
        private IList<XLOVCode> _kesGefaehrdungsmeldungDurchKsCodes;
        private int _selectedTabIndex;
        private string _title;

        public KesAuftragVM()
            : base(Container.Resolve<KesAuftragService>())
        {
            RequiredParameters = InitParameterValue.BaPersonID | InitParameterValue.FaLeistungID | InitParameterValue.Title;
            UserSearchBoxVM = new UserSearchBoxVM();
        }

        public SelectableList<BaPerson> BetroffenePersonen
        {
            get { return _betroffenePersonen; }
            private set
            {
                SetProperty(ref _betroffenePersonen, value, () => BetroffenePersonen);
                NotifyPropertyChanged.RaisePropertyChanged(() => BetroffenePersonen);
            }
        }

        public IList<XLOVCode> KesAuftragAbklaerungsartCodes
        {
            get { return _kesAuftragAbklaerungsartCodes; }
            set { SetProperty(ref _kesAuftragAbklaerungsartCodes, value, () => KesAuftragAbklaerungsartCodes); }
        }

        public IList<XLOVCode> KesAuftragAbschlussgrundCode
        {
            get { return _kesAuftragAbschlussgrundCode; }
            set { SetProperty(ref _kesAuftragAbschlussgrundCode, value, () => KesAuftragAbschlussgrundCode); }
        }

        public IList<XLOVCode> KesAuftragDurchCode
        {
            get { return _kesAuftragDurchCode; }
            set { SetProperty(ref _kesAuftragDurchCode, value, () => KesAuftragDurchCode); }
        }

        public KesDokumentVM KesDokumentVM
        {
            get { return _kesDokumentVM; }
            set { SetProperty(ref _kesDokumentVM, value, () => KesDokumentVM); }
        }

        public IList<XLOVCode> KesGefaehrdungsmeldungDurchCodes
        {
            get { return _kesGefaehrdungsmeldungDurchCodes; }
            set { SetProperty(ref _kesGefaehrdungsmeldungDurchCodes, value, () => KesGefaehrdungsmeldungDurchCodes); }
        }

        public XUser SelectedBearbeiter
        {
            get { return SelectedEntity != null ? SelectedEntity.XUser : null; }
            set
            {
                if (SelectedEntity != null)
                {
                    if (value != null && value.KesAuftrag.Contains(SelectedEntity))
                    {
                        value.KesAuftrag.Remove(SelectedEntity);
                    }

                    SelectedEntity.XUser = value;
                    SelectedEntity.UserID = value != null ? value.UserID : (int?)null;
                }

                NotifyPropertyChanged.RaisePropertyChanged(() => SelectedBearbeiter);
            }
        }

        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set { SetProperty(ref _selectedTabIndex, value, () => SelectedTabIndex); }
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

        private KesAuftragService Service
        {
            get { return (KesAuftragService)ServiceCRUD; }
        }

        public override bool CanDeleteData()
        {
            //if the current selected Tab-Page is KesAuftragDokumentView, dispatch the call to the corresponding VM
            if (SelectedTabIndex == TAB_INDEX_DOKUMENT)
            {
                return KesDokumentVM != null && KesDokumentVM.CanDeleteData();
            }

            return base.CanDeleteData();
        }

        public override bool CanInsertData()
        {
            //if the current selected Tab-Page is KesAuftragDokumentView, dispatch the call to the corresponding VM
            if (SelectedTabIndex == TAB_INDEX_DOKUMENT)
            {
                return KesDokumentVM != null && KesDokumentVM.CanInsertData();
            }

            return base.CanInsertData();
        }

        public override bool CanSaveData()
        {
            //if the current selected Tab-Page is KesAuftragDokumentView, dispatch the call to the corresponding VM
            if (SelectedTabIndex == TAB_INDEX_DOKUMENT)
            {
                return KesDokumentVM != null && KesDokumentVM.CanSaveData();
            }

            return base.CanSaveData();
        }

        public override bool CanUndoChanges()
        {
            //if the current selected Tab-Page is KesAuftragDokumentView, dispatch the call to the corresponding VM
            if (SelectedTabIndex == TAB_INDEX_DOKUMENT)
            {
                return KesDokumentVM != null && KesDokumentVM.CanUndoChanges();
            }

            return base.CanUndoChanges();
        }

        public override IServiceResult DeleteData()
        {
            //if the current selected Tab-Page is KesAuftragDokumentView, dispatch the call to the corresponding VM
            if (SelectedTabIndex == TAB_INDEX_DOKUMENT && KesDokumentVM != null)
            {
                return KesDokumentVM.DeleteData();
            }

            return base.DeleteData();
        }

        public override IServiceResult InsertData()
        {
            //if the current selected Tab-Page is KesAuftragDokumentView, dispatch the call to the corresponding VM
            if (SelectedTabIndex == TAB_INDEX_DOKUMENT && KesDokumentVM != null)
            {
                var result = base.SaveData();

                if (!result.IsOk)
                {
                    SelectedTabIndex = TAB_INDEX_ERFASSEN;
                    return result;
                }

                return KesDokumentVM.InsertData();
            }

            return base.InsertData();
        }

        public override bool JumpToPath(System.Collections.Specialized.HybridDictionary parameters)
        {
            var returnValue = base.JumpToPath(parameters);

            if (parameters.Contains(PARAMETER_SELECTED_TAB_INDEX))
            {
                string value = null;
                foreach (var param in parameters.Cast<DictionaryEntry>().Where(param => param.Key.Equals(PARAMETER_SELECTED_TAB_INDEX)))
                {
                    value = (string)param.Value;
                }

                SelectedTabIndex = Convert.ToInt32(value);
            }

            return returnValue;
        }

        public override void RefreshData()
        {
            //if the current selected Tab-Page is KesAuftragDokumentView, dispatch the call to the corresponding VM
            if (SelectedTabIndex == TAB_INDEX_DOKUMENT && KesDokumentVM != null)
            {
                KesDokumentVM.RefreshData();
            }

            base.RefreshData();
        }

        public override IServiceResult SaveData()
        {
            if (SelectedEntity == null || SelectedEntity.KesAuftrag_BaPerson == null || KesDokumentVM == null)
            {
                return ServiceResult.Ok();
            }

            var betroffenePersonenIdsNew = BetroffenePersonen.SelectedItems.Select(x => x.BaPersonID).ToList();
            var betroffenePersonenIdsOld = SelectedEntity.BetroffenePersonenIds == null ? new List<int>() : SelectedEntity.BetroffenePersonenIds.ToList();

            if (!betroffenePersonenIdsNew.SequenceEqual(betroffenePersonenIdsOld))
            {
                SelectedEntity.BetroffenePersonenIds = betroffenePersonenIdsNew;
            }

            var modified = IsSelectedEntityTreeModified();

            var result = base.SaveData();

            if (!result.IsOk)
            {
                return result;
            }

            //if the current selected Tab-Page is KesAuftragDokumentView, dispatch the call to the corresponding VM
            result = KesDokumentVM.SaveData();

            if (!result.IsOk)
            {
                return result;
            }

            Service.RefreshTree(modified);

            return result;
        }

        public override bool UndoDataChanges()
        {
            //if the current selected Tab-Page is KesAuftragDokumentView, dispatch the call to the corresponding VM
            if (SelectedTabIndex == TAB_INDEX_DOKUMENT)
            {
                return KesDokumentVM.UndoDataChanges();
            }

            return base.UndoDataChanges();
        }

        protected async override Task InitAsync(InitParameters? initParameters = null)
        {
            _faLeistungId = initParameters.Value.FaLeistungID.Value;
            _baPersonId = initParameters.Value.BaPersonID.Value;
            Title = initParameters.Value.Title;

            AddViewRightInterceptor(new KesMaskenrechtInterceptor(_faLeistungId));

            var lovService = Container.Resolve<XLovService>();
            _kesGefaehrdungsmeldungDurchEsCodes = lovService.GetLovCodesByLovName("KesGefaehrdungsmeldungDurchES", true, true);
            _kesGefaehrdungsmeldungDurchKsCodes = lovService.GetLovCodesByLovName("KesGefaehrdungsmeldungDurchKS", true, true);
            KesGefaehrdungsmeldungDurchCodes = _kesGefaehrdungsmeldungDurchEsCodes;
            KesAuftragDurchCode = lovService.GetLovCodesByLovName("KesAuftragDurch", true, true);
            _kesAuftragAbklaerungsartEsCodes = lovService.GetLovCodesByLovName("KesAuftragAbklaerungsart", true, true, "ES");
            _kesAuftragAbklaerungsartKsCodes = lovService.GetLovCodesByLovName("KesAuftragAbklaerungsart", true, true, "KS");
            KesAuftragAbklaerungsartCodes = _kesAuftragAbklaerungsartEsCodes;
            KesAuftragAbschlussgrundCode = lovService.GetLovCodesByLovName("KesAuftragAbschlussgrund", true, true);

            var baPersonService = Container.Resolve<BaPersonService>();
            BetroffenePersonen = new SelectableList<BaPerson>(baPersonService.GetAffectedPersons(_baPersonId));

            SearchParameters = _faLeistungId;
            SearchTask.StartCommand.Execute(_faLeistungId);
        }

        protected override void InitNewEntity(KesAuftrag entity)
        {
            base.InitNewEntity(entity);

            entity.FaLeistungID = _faLeistungId;
            entity.UserID = Container.Resolve<ISessionService>().AuthenticatedUser.UserID;

            var userService = Container.Resolve<XUserService>();
            entity.XUser = userService.GetEntityById(entity.UserID.Value);

            entity.BetroffenePersonenIds = new List<int>();

            //entity.IsKS = false; //Default is ES
        }

        protected override void OnSelectedEntityChanged(KesAuftrag selectedEntity, KesAuftrag deselectedEntity)
        {
            if (selectedEntity != null)
            {
                EsKsChanged(SelectedEntity.IsKS);

                SelectedBearbeiter = selectedEntity.XUser;

                foreach (var selectableItem in BetroffenePersonen)
                {
                    selectableItem.IsSelected = selectedEntity.BetroffenePersonenIds != null &&
                                                selectedEntity.BetroffenePersonenIds.Contains(selectableItem.Item.BaPersonID);
                }

                //refresh Child-VM: KesAuftragDokumentVM
                RefreshChildVM(selectedEntity);
            }
            else
            {
                BetroffenePersonen.ClearSelection();
                SelectedBearbeiter = null;
            }

            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);
        }

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            if (propertyName.Equals(PropertyName.GetPropertyName(() => KesAuftragAbklaerungsartCodes)))
            {
                RefreshChildVM(SelectedEntity);
            }
            else if (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.IsKS))
            {
                EsKsChanged(SelectedEntity.IsKS);
            }

            base.OnSelectedEntityPropertyChanged(propertyName);
        }

        protected override IServiceResult<IEnumerable<KesAuftrag>> SearchInBackground(int faLeistungId, CancellationToken cancellationToken)
        {
            return new ServiceResult<IEnumerable<KesAuftrag>>(Service.GetByFaLeistungId(faLeistungId));
        }

        private void EsKsChanged(bool isKs)
        {
            if (isKs)
            {
                KesGefaehrdungsmeldungDurchCodes = _kesGefaehrdungsmeldungDurchKsCodes;
                KesAuftragAbklaerungsartCodes = _kesAuftragAbklaerungsartKsCodes;
            }
            else
            {
                KesGefaehrdungsmeldungDurchCodes = _kesGefaehrdungsmeldungDurchEsCodes;
                KesAuftragAbklaerungsartCodes = _kesAuftragAbklaerungsartEsCodes;
            }
        }

        private void RefreshChildVM(KesAuftrag selectedEntity)
        {
            var customData = new Dictionary<string, object>();
            customData.Add(KesDokumentVM.ID_KESAUFTRAG, selectedEntity);

            var initParameters = new InitParameters { BaPersonID = _baPersonId, CustomData = customData };

            KesDokumentVM = new KesDokumentVM(KesDokumentVM.DokumentControls.DokumentResultat | KesDokumentVM.DokumentControls.Versand, KesDokumentTyp.AuftragDokument);
            KesDokumentVM.Init(initParameters);
        }
    }
}