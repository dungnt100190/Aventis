using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Kiss.BusinessLogic;
using Kiss.BusinessLogic.Kes;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Kes;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Infrastructure.Utils;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel.SearchBox;

namespace Kiss.UserInterface.ViewModel.Kes
{
    public class KesKokesExportVM : ViewModelSearchList<KesKokesExportMassnahmeListDTO, KesKokesExportSearchParamDTO>
    {
        private readonly KesKokesExportService _kesKokesExportService;

        private KesKokesExportDTO _currentExportDto;
        private IEnumerable<KesBehoerde> _kesBehoerdeList;

        public KesKokesExportVM()
        {
            _kesKokesExportService = Container.Resolve<KesKokesExportService>();

            BaPersonSearchBoxVM = new BaPersonSearchBoxVM
            {
                ModulId = 29,
                NurFalltraeger = true
            };
            KesBehoerdeSearchBoxVM = new KesBehoerdeSearchBoxVM();
            UserSearchBoxVM = new UserSearchBoxVM();
        }

        public BaPersonSearchBoxVM BaPersonSearchBoxVM
        {
            get;
            private set;
        }

        public IEnumerable<KesBehoerde> KesBehoerdeList
        {
            get { return _kesBehoerdeList; }
            set { SetProperty(ref _kesBehoerdeList, value, () => KesBehoerdeList); }
        }

        public KesBehoerdeSearchBoxVM KesBehoerdeSearchBoxVM
        {
            get;
            private set;
        }

        public UserSearchBoxVM UserSearchBoxVM
        {
            get;
            private set;
        }

        public void GotoMassnahme()
        {
            if (SelectedEntity != null)
            {
                var formController = Container.Resolve<IKissFormController>();
                formController.OpenForm(
                    "FrmFall",
                    "Action", "JumpToPath",
                    "ModulID", 29,
                    "BaPersonID", SelectedEntity.KesMassnahme.FaLeistung.BaPersonID,
                    "TreeNodeID", string.Format("Kiss.UserInterface.View.Kes.KesLeistungView,Kiss.UserInterface.View{0}/Kiss.UserInterface.View.Kes.KesMassnahmeView,Kiss.UserInterface.View", SelectedEntity.KesMassnahme.FaLeistungID),
                    "FindEntity", string.Format("KesMassnahmeID={0}", SelectedEntity.KesMassnahme.KesMassnahmeID));
            }
        }

        public void PerformExport(string fileName)
        {
            var exportTask = Task.Run(() => PerformExportAsync(SearchParameters.Jahr, fileName));
            CompletelyBusyTasks.AddObservation(exportTask);
        }

        protected override async Task InitAsync(InitParameters? initParameters = null)
        {
            var kesBehoerdeService = Container.Resolve<KesBehoerdeService>();
            KesBehoerdeList = kesBehoerdeService.GetAllEntities();

            ResetSearchParameters(null);
        }

        protected override void ResetSearchParameters(object parameter)
        {
            base.ResetSearchParameters(parameter);
            SearchParameters = new KesKokesExportSearchParamDTO
            {
                Jahr = DateTime.Today.Year
            };
        }

        protected override IServiceResult<IEnumerable<KesKokesExportMassnahmeListDTO>> SearchInBackground(KesKokesExportSearchParamDTO searchParameters, CancellationToken cancellationToken)
        {
            Multilanguage.SetCurrentCulture();
            var serviceResult = _kesKokesExportService.GetExportDto(searchParameters);

            if (!serviceResult.IsOk)
            {
                return new ServiceResult<IEnumerable<KesKokesExportMassnahmeListDTO>>(serviceResult);
            }

            _currentExportDto = serviceResult.Result;
            var massnahmeDtos = serviceResult.Result.KesMassnahmeDTOs;
            return new ServiceResult<IEnumerable<KesKokesExportMassnahmeListDTO>>(massnahmeDtos);
        }

        private async Task PerformExportAsync(int jahr, string fileName)
        {
            Multilanguage.SetCurrentCulture();
            ValidationResult = _kesKokesExportService.PerformExport(_currentExportDto, jahr, fileName);
        }
    }
}