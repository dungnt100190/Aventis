using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Kiss.BusinessLogic;
using Kiss.BusinessLogic.Kes;
using Kiss.BusinessLogic.Sys;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Kes;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel.SearchBox;

namespace Kiss.UserInterface.ViewModel.Kes
{
    public class KesMandatsfuehrendePersonVM : ViewModelSearchListCRUD<KesMandatsfuehrendePersonDTO, KesMandatsfuehrendePerson, int, int>
    {
        private IList<XLOVCode> _kesBeistandsartCode;
        private KesMassnahme _kesMassnahme;
        private string _title;

        public KesMandatsfuehrendePersonVM()
            : base(Container.Resolve<KesMandatsfuehrendePersonService>())
        {
            RequiredParameters = InitParameterValue.CustomData;
            SearchBoxVM = new FachpersonOrMandatstraegerUserSearchBoxVM();

            AddEntityPropertyMapping(() => SelectedEntity.SelectedFachpersonOrUser, () => AdresseMandatsfuehrendePerson);

            RefreshAfterSetInclDeleted = false;
        }

        public string AdresseMandatsfuehrendePerson
        {
            get
            {
                if (SelectedEntity == null || SelectedEntity.SelectedFachpersonOrUser == null)
                {
                    return null;
                }

                return Service.GetAdresseMandatsfuehrendePerson(SelectedEntity.SelectedFachpersonOrUser.Mandatstraeger, SelectedEntity.SelectedFachpersonOrUser.Fachperson);
            }
        }

        public IList<XLOVCode> KesBeistandsartCode
        {
            get { return _kesBeistandsartCode; }
            set { SetProperty(ref _kesBeistandsartCode, value, () => KesBeistandsartCode); }
        }

        public FachpersonOrMandatstraegerUserSearchBoxVM SearchBoxVM
        {
            get;
            private set;
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value, () => Title); }
        }

        private KesMandatsfuehrendePersonService Service
        {
            get { return (KesMandatsfuehrendePersonService)ServiceCRUD; }
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

            AddViewRightInterceptor(new KesMaskenrechtInterceptor(_kesMassnahme.FaLeistungID));

            var lovService = Container.Resolve<XLovService>();
            KesBeistandsartCode = lovService.GetLovCodesByLovName("KesBeistandsart", true, true);

            SearchParameters = _kesMassnahme.KesMassnahmeID;
            SearchTask.StartCommand.Execute();
        }

        protected override void InitNewEntity(KesMandatsfuehrendePersonDTO entity)
        {
            base.InitNewEntity(entity);
            entity.WrappedEntity.KesMassnahme = _kesMassnahme;
            entity.WrappedEntity.DatumMandatVon = _kesMassnahme.DatumVon;
            entity.WrappedEntity.DatumMandatBis = _kesMassnahme.DatumBis;
        }

        protected override void OnSelectedEntityChanged(KesMandatsfuehrendePersonDTO selectedEntity, KesMandatsfuehrendePersonDTO deselectedEntity)
        {
            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);
            NotifyPropertyChanged.RaisePropertyChanged(() => AdresseMandatsfuehrendePerson);
        }

        protected override IServiceResult<IEnumerable<KesMandatsfuehrendePersonDTO>> SearchInBackground(int kesMassnahmeID, CancellationToken cancellationToken)
        {
            return new ServiceResult<IEnumerable<KesMandatsfuehrendePersonDTO>>(Service.GetByKesMassnahmeID(kesMassnahmeID, InclDeleted));
        }
    }
}