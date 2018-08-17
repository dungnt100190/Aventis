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
    public class KesFachstelleMassnahmeVM : ViewModelSearchListCRUD<KesMassnahme, KesMassnahme, int, int>
    {
        public const string KEY_KESMASSNAHME = "KesMassnahme";

        private int _faLeistungId;
        private IList<XLOVCode> _kesBeistandsartCode;
        private KesFachstelleMandatsfuehrendePersonVM _kesFachstelleMandatsfuehrendePersonVM;

        public KesFachstelleMassnahmeVM()
            : base(Container.Resolve<KesMassnahmeService>())
        {
            RequiredParameters = InitParameterValue.FaLeistungID;
        }

        public IList<XLOVCode> KesBeistandsartCode
        {
            get { return _kesBeistandsartCode; }
            set { SetProperty(ref _kesBeistandsartCode, value, () => KesBeistandsartCode); }
        }

        public KesFachstelleMandatsfuehrendePersonVM KesFachstelleMandatsfuehrendePersonVM
        {
            get { return _kesFachstelleMandatsfuehrendePersonVM; }
            set { SetProperty(ref _kesFachstelleMandatsfuehrendePersonVM, value, () => KesFachstelleMandatsfuehrendePersonVM); }
        }

        private KesMassnahmeService Service
        {
            get { return (KesMassnahmeService)ServiceCRUD; }
        }

        public override IServiceResult SaveData()
        {
            if (KesFachstelleMandatsfuehrendePersonVM != null)
            {
                return KesFachstelleMandatsfuehrendePersonVM.SaveData();
            }

            return base.SaveData();
        }

        protected async override Task InitAsync(InitParameters? initParameters = null)
        {
            _faLeistungId = initParameters.Value.FaLeistungID.Value;

            AddViewRightInterceptor(new KesMaskenrechtInterceptor(_faLeistungId));

            var lovService = Container.Resolve<XLovService>();
            KesBeistandsartCode = lovService.GetLovCodesByLovName("KesBeistandsart", true, true);

            Maskenrecht.CanDelete = false;
            Maskenrecht.CanInsert = false;

            SearchParameters = _faLeistungId;
            SearchTask.StartCommand.Execute(_faLeistungId);
        }

        protected override void OnSelectedEntityChanged(KesMassnahme selectedEntity, KesMassnahme deselectedEntity)
        {
            var customData = new Dictionary<string, object>();
            customData.Add(KEY_KESMASSNAHME, selectedEntity);

            var initParameters = new InitParameters { CustomData = customData };

            KesFachstelleMandatsfuehrendePersonVM = new KesFachstelleMandatsfuehrendePersonVM();
            KesFachstelleMandatsfuehrendePersonVM.Init(initParameters);

            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);
        }

        protected override IServiceResult<IEnumerable<KesMassnahme>> SearchInBackground(int faLeistungId, CancellationToken cancellationToken)
        {
            return new ServiceResult<IEnumerable<KesMassnahme>>(Service.GetByFaLeistungId(faLeistungId, false));
        }
    }
}