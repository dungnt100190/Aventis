using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

using Kiss.BusinessLogic;
using Kiss.BusinessLogic.Sys;
using Kiss.BusinessLogic.Vm;
using Kiss.DbContext;
using Kiss.DbContext.Enums.Vm;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel.Commanding;

namespace Kiss.UserInterface.ViewModel.Vm
{
    public class VmKlientenbudgetEditorVM : ViewModelSearchListCRUD<VmKlientenbudgetVM, VmKlientenbudget, int, int>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string VM_KLIENTENBUDGET_MESSAGE_KEY = "VmKlientenbudgetID";
        private readonly XLovService _xlovService;

        #endregion

        #region Private Fields

        private readonly XUser _authenticatedUser;

        //private XUser _user;
        private readonly int _userId;

        private int _faLeistungId;
        private ObservableCollection<XLOVCode> _vmKlientenbudgetMutationsgrundLOV;
        private ObservableCollection<XLOVCode> _vmKlientenbudgetStatusLOV;
        private ObservableCollection<XLOVCode> _vmKlientenbudgetStatusLOVAnzeige;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VmKlientenbudgetVM"/> class.
        /// </summary>
        public VmKlientenbudgetEditorVM()
            : base(Container.Resolve<VmKlientenbudgetService>())
        {
            RequiredParameters = InitParameterValue.FaLeistungID;

            _xlovService = Container.Resolve<XLovService>();
            VmKlientenbudgetStatusLOVAnzeige = new ObservableCollection<XLOVCode>();

            CopyBudgetCommand = new DelegateCommand(x => CopyBudget(), x => CanCopyBudget());

            // ToDo: Authenticated user nur einmal global registrieren
            var sessionService = Container.Resolve<ISessionService>();
            _userId = sessionService.AuthenticatedUser.UserID;
            var userService = Container.Resolve<XUserService>();
            _authenticatedUser = userService.GetEntityById(_userId);

            RefreshAfterSave = true;
            ConfirmDeleteQuestion = "Soll dieses Budget gelöscht werden?";
        }

        #endregion

        #region Properties

        public IDelegateCommand CopyBudgetCommand { get; private set; }

        /// <summary>
        /// Erstbudget, jährliche Budgetanpassung .. (auf VmKlientenBudget)
        /// </summary>
        public ObservableCollection<XLOVCode> VmKlientenbudgetMutationsgrundLOV
        {
            get { return _vmKlientenbudgetMutationsgrundLOV; }
            private set { SetProperty(ref _vmKlientenbudgetMutationsgrundLOV, value, () => VmKlientenbudgetMutationsgrundLOV); }
        }

        /// <summary>
        /// in Bearbeitung, in Ordnung, Archiviert.
        /// </summary>
        public ObservableCollection<XLOVCode> VmKlientenbudgetStatusLOV
        {
            get { return _vmKlientenbudgetStatusLOV; }
            private set { SetProperty(ref _vmKlientenbudgetStatusLOV, value, () => VmKlientenbudgetStatusLOV); }
        }

        public ObservableCollection<XLOVCode> VmKlientenbudgetStatusLOVAnzeige
        {
            get { return _vmKlientenbudgetStatusLOVAnzeige; }
            private set { SetProperty(ref _vmKlientenbudgetStatusLOVAnzeige, value, () => VmKlientenbudgetStatusLOVAnzeige); }
        }

        private VmKlientenbudgetService Service
        {
            get { return (VmKlientenbudgetService)ServiceCRUD; }
        }

        #endregion

        #region Methods

        #region Public Methods

        //ToDo: in Basisklasse?
        //public override KissServiceResult DeleteData(IUnitOfWork unitOfWork)
        //{
        //    var options = new List<QuestionAnswerOption> { new QuestionAnswerOption(true, "Ja"), new QuestionAnswerOption(false, "Nein") };
        //    var answer = RaiseQuestion("Soll dieses Budget gelöscht werden?", options, false);
        //    if (answer == null || !(bool)answer.Tag)
        //    {
        //        return KissServiceResult.Ok();
        //    }
        //    var result = base.DeleteData(unitOfWork);
        //    if (result.IsOk)
        //    {
        //        EntityListView.MoveCurrentToFirst();
        //    }
        //    return result;
        //}

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "VMKLIENTENBUDGETID":
                    {
                        if (SelectedEntity != null && SelectedEntity.Budget != null)
                        {
                            return SelectedEntity.Budget.VmKlientenbudgetID;
                        }

                        return DBNull.Value;
                    }

                default:
                    return base.GetContextValue(fieldName);
            }
        }

        public override bool JumpToPath(System.Collections.Specialized.HybridDictionary parameters)
        {
            if (parameters.Contains(VM_KLIENTENBUDGET_MESSAGE_KEY))
            {
                var msg = parameters[VM_KLIENTENBUDGET_MESSAGE_KEY];

                if (msg is int)
                {
                    return SelectBudget((int)msg);
                }
            }
            return false;
        }

        public override IServiceResult SaveData()
        {
            var result = base.SaveData();

            if (result.IsOk)
            {
                UpdateStatusliste();
                CopyBudgetCommand.RaiseCanExecuteChanged();
                SelectedEntity.SavePendingPositionen(SelectedEntity.Budget.VmKlientenbudgetID);
            }

            return result;
        }

        public bool SelectBudget(int vmKlientenbudgetId)
        {
            var budget = EntityList.FirstOrDefault(x => x.Budget.VmKlientenbudgetID == vmKlientenbudgetId);

            if (budget != null)
            {
                return EntityListView.MoveCurrentTo(budget);
            }
            return false;
        }

        #endregion

        #region Protected Methods

        public override bool CanInsertData()
        {
            return base.CanInsertData() &&
                   EntityList.All(bud => bud.Budget.VmKlientenbudgetStatus != VmKlientenbudgetStatus.InBearbeitung);
        }

        protected override VmKlientenbudgetVM CreateAndInitNewEntity()
        {
            var sessionService = Container.Resolve<ISessionService>();

            var budget = Service.GetDefaultBudget(false);
            budget.FaLeistungID = _faLeistungId;
            budget.UserID = sessionService.AuthenticatedUser.UserID;
            budget.XUser = _authenticatedUser;
            var vm = ConvertServiceEntityToListEntity(budget);
            vm.Bearbeiten = true;
            return vm;
        }

        protected async override System.Threading.Tasks.Task InitAsync(InitParameters? initParameters = null)
        {
            _faLeistungId = initParameters.Value.FaLeistungID.Value;

            //Services für Berechtigung holen
            var sessionService = Container.Resolve<ISessionService>();
            var berechtigungsService = Container.Resolve<SysBerechtigungsService>();
            var userId = sessionService.AuthenticatedUser.UserID;
            var berechtigung = berechtigungsService.GetUserZugriffrecht(_faLeistungId, userId);
            Maskenrecht.CanUpdate = Maskenrecht.CanUpdate && berechtigung.MayUpdate;
            Maskenrecht.CanInsert = Maskenrecht.CanInsert && berechtigung.MayInsert;
            Maskenrecht.CanDelete = Maskenrecht.CanDelete && berechtigung.MayDelete;

            //LOVs holen
            VmKlientenbudgetStatusLOV = new ObservableCollection<XLOVCode>(_xlovService.GetLovCodesByLovName("VmKlientenbudgetStatus"));
            VmKlientenbudgetStatusLOVAnzeige = new ObservableCollection<XLOVCode>(_xlovService.GetLovCodesByLovName("VmKlientenbudgetStatus"));
            VmKlientenbudgetMutationsgrundLOV = new ObservableCollection<XLOVCode>(_xlovService.GetLovCodesByLovName("VmKlientenbudgetMutationsgrund"));

            SearchParameters = _faLeistungId;
            SearchTask.StartCommand.Execute(_faLeistungId);
        }

        protected override void OnSelectedEntityChanged(VmKlientenbudgetVM selectedEntity, VmKlientenbudgetVM deselectedEntity)
        {
            if (deselectedEntity != null)
            {
                deselectedEntity.Bearbeiten = false;
            }

            // lazy loading of positions
            if (selectedEntity != null && selectedEntity.Budget.VmPosition == null)
            {
                var positionService = Container.Resolve<VmPositionService>();
                selectedEntity.Budget.VmPosition = positionService.GetByKlientenbudgetID(selectedEntity.Budget.VmKlientenbudgetID);
            }

            // Liste neu generieren.
            UpdateStatusliste();

            // Enable/Disable copy button
            CopyBudgetCommand.RaiseCanExecuteChanged();

            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);
        }

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            if (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.Budget.VmKlientenbudgetStatusCode))
            {
                CopyBudgetCommand.RaiseCanExecuteChanged();
            }
            if (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.Bearbeiten) && SelectedEntity != null && !SelectedEntity.Bearbeiten)
            {
                SaveData();
            }
        }

        protected override IServiceResult<IEnumerable<VmKlientenbudgetVM>> SearchInBackground(int faLeistungID, System.Threading.CancellationToken cancellationToken)
        {
            return new ServiceResult<IEnumerable<VmKlientenbudgetVM>>(Service.GetByFaLeistungId(faLeistungID).Select(bud => new VmKlientenbudgetVM(bud)));
        }

        #endregion

        #region Private Methods

        private bool CanCopyBudget()
        {
            return SelectedEntity != null &&
                   SelectedEntityStateObserver.EntityState != EntityState.Added &&
                   EntityList.All(x => x.Budget.VmKlientenbudgetStatus != VmKlientenbudgetStatus.InBearbeitung);
        }

        private void CopyBudget()
        {
            // Validate
            if (EntityList.Any(bud => bud.Budget.VmKlientenbudgetStatus == VmKlientenbudgetStatus.InBearbeitung))
            {
                ValidationResult = ServiceResult.ErrorWithId("VmKlientenbudgetDTOService.CopyInBearbeitung",
                                                       "Das Budget konnte nicht kopiert werden, da bereits ein Budget in Bearbeitung existiert.");
                return;
            }

            // save pending changes of current edit
            SelectedEntity.Bearbeiten = false;
            SaveData();

            if (!ValidationResult.IsOk)
            {
                return;
            }

            var budgetNew = new VmKlientenbudgetVM(SelectedEntity.Budget.VmKlientenbudgetID,
                                                   new VmKlientenbudget
                                                       {
                                                           VmKlientenbudgetStatus = VmKlientenbudgetStatus.InBearbeitung,
                                                           GueltigAb = SelectedEntity.Budget.GueltigAb.AddMonths(1).FirstDayOfMonth(),
                                                           FaLeistungID = _faLeistungId,
                                                           UserID = _userId
                                                       });
            budgetNew.Bearbeiten = true;

            EntityList.Add(budgetNew);
            EntityListView.MoveCurrentTo(budgetNew);
        }

        private void UpdateStatusliste()
        {
            if (SelectedEntity != null)
            {
                switch (SelectedEntity.Budget.VmKlientenbudgetStatus)
                {
                    case VmKlientenbudgetStatus.InBearbeitung:
                        _vmKlientenbudgetStatusLOVAnzeige.Single(x => x.Code == (int)VmKlientenbudgetStatus.InBearbeitung).IsActive = true;
                        _vmKlientenbudgetStatusLOVAnzeige.Single(x => x.Code == (int)VmKlientenbudgetStatus.InOrdnung).IsActive = true;
                        _vmKlientenbudgetStatusLOVAnzeige.Single(x => x.Code == (int)VmKlientenbudgetStatus.Archiviert).IsActive = true;
                        break;

                    case VmKlientenbudgetStatus.InOrdnung:
                        _vmKlientenbudgetStatusLOVAnzeige.Single(x => x.Code == (int)VmKlientenbudgetStatus.InBearbeitung).IsActive = false;
                        _vmKlientenbudgetStatusLOVAnzeige.Single(x => x.Code == (int)VmKlientenbudgetStatus.InOrdnung).IsActive = true;
                        _vmKlientenbudgetStatusLOVAnzeige.Single(x => x.Code == (int)VmKlientenbudgetStatus.Archiviert).IsActive = true;
                        break;

                    case VmKlientenbudgetStatus.Archiviert:
                        _vmKlientenbudgetStatusLOVAnzeige.Single(x => x.Code == (int)VmKlientenbudgetStatus.InBearbeitung).IsActive = false;
                        _vmKlientenbudgetStatusLOVAnzeige.Single(x => x.Code == (int)VmKlientenbudgetStatus.InOrdnung).IsActive = false;
                        _vmKlientenbudgetStatusLOVAnzeige.Single(x => x.Code == (int)VmKlientenbudgetStatus.Archiviert).IsActive = true;
                        break;
                }
            }
        }

        #endregion

        #endregion
    }
}