using System;
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
using Kiss.UserInterface.ViewModel.Commanding;
using Kiss.UserInterface.ViewModel.SearchBox;

namespace Kiss.UserInterface.ViewModel.Kes
{
    public class KesPraeventionVM : ViewModelSearchListCRUD<KesPraevention, KesPraevention, int, int>
    {
        private int _faLeistungId;
        private bool _istAbgeschlossen;
        private IList<XLOVCode> _kesPraeventionsabschlussCodes;
        private IList<XLOVCode> _kesPraeventionsartCodes;
        private string _title;

        public KesPraeventionVM()
            : base(Container.Resolve<KesPraeventionService>())
        {
            RequiredParameters = InitParameterValue.FaLeistungID;

            UserSearchBoxVM = new UserSearchBoxVM();
            PraeventionWiedereroeffnenCommand = new BaseCommand(PraeventionWiedereroeffnen, x => IstAbgeschlossen);
        }

        public bool IstAbgeschlossen
        {
            get { return _istAbgeschlossen; }
            set
            {
                SetProperty(ref _istAbgeschlossen, value, () => IstAbgeschlossen);
                PraeventionWiedereroeffnenCommand.EvaluateCanExecute();
            }
        }

        public IList<XLOVCode> KesPraeventionsabschlussCodes
        {
            get { return _kesPraeventionsabschlussCodes; }
            set { SetProperty(ref _kesPraeventionsabschlussCodes, value, () => KesPraeventionsabschlussCodes); }
        }

        public IList<XLOVCode> KesPraeventionsartCodes
        {
            get { return _kesPraeventionsartCodes; }
            set { SetProperty(ref _kesPraeventionsartCodes, value, () => KesPraeventionsartCodes); }
        }

        public BaseCommand PraeventionWiedereroeffnenCommand
        {
            get;
            private set;
        }

        public XUser SelectedUser
        {
            get { return SelectedEntity != null ? SelectedEntity.XUser : null; }
            set
            {
                if (SelectedEntity != null)
                {
                    SelectedEntity.XUser = value;
                    SelectedEntity.UserID = value != null ? value.UserID : (int?)null;
                }

                NotifyPropertyChanged.RaisePropertyChanged(() => SelectedUser);
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

        private KesPraeventionService Service
        {
            get { return (KesPraeventionService)ServiceCRUD; }
        }

        public override IServiceResult SaveData()
        {
            if (SelectedEntity == null || !IsSelectedEntityTreeModified())
            {
                return ServiceResult.Ok();
            }

            var result = base.SaveData();
            if (result.IsOk)
            {
                IstAbgeschlossen = (SelectedEntity.DatumBis != null);
            }

            Service.RefreshTree();

            return result;
        }

        protected override async Task InitAsync(InitParameters? initParameters = null)
        {
            _faLeistungId = initParameters.Value.FaLeistungID.Value;
            Title = initParameters.Value.Title;

            AddViewRightInterceptor(new KesMaskenrechtInterceptor(_faLeistungId));

            var lovService = Container.Resolve<XLovService>();
            KesPraeventionsabschlussCodes = lovService.GetLovCodesByLovName("KesPraeventionsabschluss", true, true);
            KesPraeventionsartCodes = lovService.GetLovCodesByLovName("KesPraeventionsart", true, true);

            SearchParameters = _faLeistungId;
            SearchTask.StartCommand.Execute(_faLeistungId);
        }

        protected override void InitNewEntity(KesPraevention entity)
        {
            base.InitNewEntity(entity);

            entity.FaLeistungID = _faLeistungId;
            entity.UserID = Container.Resolve<ISessionService>().AuthenticatedUser.UserID;
            entity.DatumVon = DateTime.Today;

            var userService = Container.Resolve<XUserService>();
            entity.XUser = userService.GetEntityById(entity.UserID.Value);
        }

        protected override void OnSelectedEntityChanged(KesPraevention selectedEntity, KesPraevention deselectedEntity)
        {
            SelectedUser = selectedEntity != null ? selectedEntity.XUser : null;

            UpdateGuiProperties();

            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);
        }

        protected override IServiceResult<IEnumerable<KesPraevention>> SearchInBackground(int faLeistungId, CancellationToken cancellationToken)
        {
            return new ServiceResult<IEnumerable<KesPraevention>>(Service.GetByFaLeistungId(faLeistungId));
        }

        private void PraeventionWiedereroeffnen(object obj)
        {
            SelectedEntity.KesPraeventionsabschlussCode = null;
            SelectedEntity.DatumBis = null;

            UpdateGuiProperties();
        }

        private void UpdateGuiProperties()
        {
            IstAbgeschlossen = SelectedEntity != null && SelectedEntity.DatumBis != null;
            PraeventionWiedereroeffnenCommand.EvaluateCanExecute();
        }
    }
}