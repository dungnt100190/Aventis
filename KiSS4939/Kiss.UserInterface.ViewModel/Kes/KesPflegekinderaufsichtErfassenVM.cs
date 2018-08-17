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
using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel.SearchBox;

namespace Kiss.UserInterface.ViewModel.Kes
{
    public class KesPflegekinderaufsichtErfassenVM : ViewModelSearchListCRUD<KesPflegekinderaufsicht, KesPflegekinderaufsicht, int, int>
    {
        private readonly XUser _currentUser;

        private int _faLeistungId;
        private IList<XLOVCode> _kesPflegeartCode;

        public KesPflegekinderaufsichtErfassenVM()
            : base(Container.Resolve<KesPflegekinderaufsichtService>())
        {
            RequiredParameters = InitParameterValue.FaLeistungID;

            UserSearchBoxVM = new UserSearchBoxVM();
            InstitutionSearchBoxVM = new InstitutionSearchBoxVM();

            _currentUser = GetAuthenticatedUser();
        }

        public string AdressePflegeeltern
        {
            get { return Service.GetAdressePflegeeltern(SelectedInstitutionPflege); }
        }

        public InstitutionSearchBoxVM InstitutionSearchBoxVM
        {
            get;
            private set;
        }

        public IList<XLOVCode> KesPflegeartCode
        {
            get { return _kesPflegeartCode; }
            set { SetProperty(ref _kesPflegeartCode, value, () => KesPflegeartCode); }
        }

        public BaInstitution SelectedInstitutionPflege
        {
            get { return SelectedEntity != null ? SelectedEntity.BaInstitution : null; }
            set
            {
                if (SelectedEntity != null)
                {
                    SelectedEntity.BaInstitution = value;
                    SelectedEntity.BaInstitutionID = value != null ? value.BaInstitutionID : (int?)null;
                }
                NotifyPropertyChanged.RaisePropertyChanged(() => SelectedInstitutionPflege);
                NotifyPropertyChanged.RaisePropertyChanged(() => AdressePflegeeltern);
            }
        }

        public XUser SelectedUserVerantwortlich
        {
            get { return SelectedEntity != null ? SelectedEntity.XUser : null; }
            set
            {
                if (SelectedEntity != null)
                {
                    SelectedEntity.XUser = value;
                    SelectedEntity.UserID = value != null ? value.UserID : (int?)null;
                }
                NotifyPropertyChanged.RaisePropertyChanged(() => SelectedUserVerantwortlich);
            }
        }

        public UserSearchBoxVM UserSearchBoxVM
        {
            get;
            private set;
        }

        private KesPflegekinderaufsichtService Service
        {
            get { return (KesPflegekinderaufsichtService)ServiceCRUD; }
        }

        public override IServiceResult DeleteData()
        {
            SelectedUserVerantwortlich = null;
            SelectedInstitutionPflege = null;
            return base.DeleteData();
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

        protected async override Task InitAsync(InitParameters? initParameters = null)
        {
            _faLeistungId = initParameters.Value.FaLeistungID.Value;

            AddViewRightInterceptor(new KesMaskenrechtInterceptor(_faLeistungId));

            var lovService = Container.Resolve<XLovService>();
            KesPflegeartCode = lovService.GetLovCodesByLovName("KesPflegeart", true, true);

            SearchParameters = _faLeistungId;
            SearchTask.StartCommand.Execute(_faLeistungId);
        }

        protected override void InitNewEntity(KesPflegekinderaufsicht entity)
        {
            entity.FaLeistungID = _faLeistungId;
            entity.XUser = _currentUser;

            base.InitNewEntity(entity);
        }

        protected override void OnSelectedEntityChanged(KesPflegekinderaufsicht selectedEntity, KesPflegekinderaufsicht deselectedEntity)
        {
            if (selectedEntity != null)
            {
                SelectedInstitutionPflege = selectedEntity.BaInstitution;
                SelectedUserVerantwortlich = selectedEntity.XUser;
            }

            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);
        }

        protected override IServiceResult<IEnumerable<KesPflegekinderaufsicht>> SearchInBackground(int faLeistungId, CancellationToken cancellationToken)
        {
            return new ServiceResult<IEnumerable<KesPflegekinderaufsicht>>(Service.GetByFaLeistungId(faLeistungId));
        }

        private static XUser GetAuthenticatedUser()
        {
            var sessionService = Container.Resolve<ISessionService>();
            var userService = Container.Resolve<XUserService>();
            return userService.GetEntityById(sessionService.AuthenticatedUser.UserID);
        }
    }
}