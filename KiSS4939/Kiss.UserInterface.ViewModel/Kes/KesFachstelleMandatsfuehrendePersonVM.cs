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

namespace Kiss.UserInterface.ViewModel.Kes
{
    public class KesFachstelleMandatsfuehrendePersonVM : ViewModelSearchListCRUD<KesMandatsfuehrendePersonDTO, KesMandatsfuehrendePerson, int, int>
    {
        private IList<XLOVCode> _kesBeistandsartCode;
        private KesMassnahme _kesMassnahme;

        public KesFachstelleMandatsfuehrendePersonVM()
            : base(Container.Resolve<KesMandatsfuehrendePersonService>())
        {
            RequiredParameters = InitParameterValue.CustomData;
        }

        public IList<XLOVCode> KesBeistandsartCode
        {
            get { return _kesBeistandsartCode; }
            set { SetProperty(ref _kesBeistandsartCode, value, () => KesBeistandsartCode); }
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

            object kesMassnahme = null;
            var dictionary = initParameters.Value.CustomData;

            if (dictionary != null)
            {
                var couldGetValue = dictionary.TryGetValue(KesFachstelleMassnahmeVM.KEY_KESMASSNAHME, out kesMassnahme);
                if (!couldGetValue)
                {
                    return;
                }
            }

            _kesMassnahme = kesMassnahme as KesMassnahme;
            if (_kesMassnahme != null)
            {
                AddViewRightInterceptor(new KesMaskenrechtInterceptor(_kesMassnahme.FaLeistungID));

                var lovService = Container.Resolve<XLovService>();
                KesBeistandsartCode = lovService.GetLovCodesByLovName("KesBeistandsart", true, true);

                SetEditMode();

                SearchParameters = _kesMassnahme.KesMassnahmeID;
                SearchTask.StartCommand.Execute();
            }
        }

        protected override IServiceResult<IEnumerable<KesMandatsfuehrendePersonDTO>> SearchInBackground(int kesMassnahmeID, CancellationToken cancellationToken)
        {
            return new ServiceResult<IEnumerable<KesMandatsfuehrendePersonDTO>>(Service.GetByKesMassnahmeID(kesMassnahmeID, false));
        }

        private void SetEditMode()
        {
            Maskenrecht.CanDelete = false;
            Maskenrecht.CanInsert = false;
        }
    }
}