using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Kiss.BusinessLogic;
using Kiss.BusinessLogic.Kes;
using Kiss.BusinessLogic.Sys;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;

namespace Kiss.UserInterface.ViewModel.Kes
{
    public class KesMassnahmeAuftragVM : ViewModelSearchListCRUD<KesMassnahmeAuftrag, KesMassnahmeAuftrag, int, int>
    {
        private bool _allanzeigen;
        private int _baPersonId;
        private bool _erledigungBis_IsRequired;
        private KesMassnahme _kesMassnahme;
        private IList<XLOVCode> _kesMassnahmeGeschaeftsartCode;
        private string _title;

        public KesMassnahmeAuftragVM(bool alleAnzeigen = false)
            : base(Container.Resolve<KesMassnahmeAuftragService>())
        {
            RequiredParameters = InitParameterValue.CustomData;
            _allanzeigen = alleAnzeigen;

            RefreshAfterSetInclDeleted = false;
        }

        public bool AlleAnzeigen
        {
            get { return _allanzeigen; }
            set
            {
                if (value != _allanzeigen)
                {
                    var result = SaveData();
                    if (result.IsOk)
                    {
                        _allanzeigen = value;
                        NotifyPropertyChanged.RaisePropertyChanged(() => AlleAnzeigen);
                        RefreshData();
                    }
                }
            }
        }

        public bool ErledigungBis_IsRequired
        {
            get { return _erledigungBis_IsRequired; }
            set { SetProperty(ref _erledigungBis_IsRequired, value, () => ErledigungBis_IsRequired); }
        }

        public IList<XLOVCode> KesMassnahmeGeschaeftsartCode
        {
            get { return _kesMassnahmeGeschaeftsartCode; }
            set { SetProperty(ref _kesMassnahmeGeschaeftsartCode, value, () => KesMassnahmeGeschaeftsartCode); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value, () => Title); }
        }

        private KesMassnahmeAuftragService Service
        {
            get { return (KesMassnahmeAuftragService)ServiceCRUD; }
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return _baPersonId;

                case "KESMASSNAHMEID":
                    return SelectedEntity.KesMassnahmeID;

                case "KESMASSNAHMEAUFTRAGID":
                    return SelectedEntity.KesMassnahmeAuftragID;

                default:
                    return base.GetContextValue(fieldName);
            }
        }

        protected async override Task InitAsync(InitParameters? initParameters = null)
        {
            if (!initParameters.HasValue)
            {
                return;
            }

            var dictionary = initParameters.Value.CustomData;
            object kesMassnahme;
            object inclDeleted;
            if (dictionary == null || !dictionary.TryGetValue(KesMassnahmeVM.KEY_KES_MASSNAHME, out kesMassnahme) || !dictionary.TryGetValue(KesMassnahmeVM.KEY_INCL_DELETED, out inclDeleted))
            {
                return;
            }

            _kesMassnahme = kesMassnahme as KesMassnahme;
            if (_kesMassnahme == null)
            {
                return;
            }

            InclDeleted = inclDeleted as bool? ?? false;

            _baPersonId = initParameters.Value.BaPersonID.Value;
            AddViewRightInterceptor(new KesMaskenrechtInterceptor(_kesMassnahme.FaLeistungID));

            var lovService = Container.Resolve<XLovService>();
            KesMassnahmeGeschaeftsartCode = lovService.GetLovCodesByLovName("KesMassnahmeGeschaeftsart", true, true);

            SearchParameters = _kesMassnahme.KesMassnahmeID;
            SearchTask.StartCommand.Execute();
        }

        protected override void InitNewEntity(KesMassnahmeAuftrag entity)
        {
            base.InitNewEntity(entity);
            entity.KesMassnahmeID = _kesMassnahme.KesMassnahmeID;
            entity.KesMassnahme = _kesMassnahme;
        }

        protected override void OnSelectedEntityChanged(KesMassnahmeAuftrag selectedEntity, KesMassnahmeAuftrag deselectedEntity)
        {
            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);

            ErledigungBis_IsRequired = selectedEntity != null && (selectedEntity.BeschlussVom != null);
        }

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            //Falls Feld BeschlussVom Wert hat dann wird Änderungsgrund ErledigungBis
            if (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.BeschlussVom) && SelectedEntity != null)
            {
                ErledigungBis_IsRequired = SelectedEntity.BeschlussVom != null;
            }

            base.OnSelectedEntityPropertyChanged(propertyName);
        }

        protected override IServiceResult<IEnumerable<KesMassnahmeAuftrag>> SearchInBackground(int kesMassnahmeID, CancellationToken cancellationToken)
        {
            if (AlleAnzeigen && _kesMassnahme != null)
            {
                return new ServiceResult<IEnumerable<KesMassnahmeAuftrag>>(Service.GetByFaLeistungID(_kesMassnahme.FaLeistungID, InclDeleted));
            }

            return new ServiceResult<IEnumerable<KesMassnahmeAuftrag>>(Service.GetByKesMassnahmeID(kesMassnahmeID, InclDeleted));
        }
    }
}