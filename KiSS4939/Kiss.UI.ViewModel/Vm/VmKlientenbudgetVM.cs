using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Kiss.BL.KissSystem;
using Kiss.BL.Vm;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Model;
using Kiss.Model.DTO.Vm;

namespace Kiss.UI.ViewModel.Vm
{
    public class VmKlientenbudgetVM : ViewModelCRUDListBase<VmKlientenbudgetDTO>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly XLovService _xlovService;

        #endregion

        #region Private Fields

        private BaseCommand _copyBudgetCommand;
        private int _faLeistungId;
        private XUser _user;
        private ObservableCollection<XLOVCode> _vmKlientenbudgetMutationsgrundLOV;
        private ObservableCollection<XLOVCode> _vmKlientenbudgetStatusLOV;
        private ObservableCollection<XLOVCode> _vmKlientenbudgetStatusLOVAnzeige;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VmKlientenbudgetVM"/> class.
        /// </summary>
        public VmKlientenbudgetVM()
            : base(Container.Resolve<VmKlientenbudgetDTOService>())
        {
            _xlovService = Container.Resolve<XLovService>();
            VmKlientenbudgetStatusLOVAnzeige = new ObservableCollection<XLOVCode>();
        }

        #endregion

        #region Properties

        public bool CanEditStatus
        {
            get { return SelectedEntity != null && SelectedEntity.CanEditStatus; }
        }

        public BaseCommand CopyBudgetCommand
        {
            get
            {
                return _copyBudgetCommand ?? (_copyBudgetCommand = new BaseCommand(x => CopyBudget(), x => CanCopyBudget()));
            }
        }

        /// <summary>
        /// Erstbudget, jährliche Budgetanpassung .. (auf VmKlientenBudget)
        /// </summary>
        public ObservableCollection<XLOVCode> VmKlientenbudgetMutationsgrundLOV
        {
            get { return _vmKlientenbudgetMutationsgrundLOV; }
            private set
            {
                if (_vmKlientenbudgetMutationsgrundLOV == value)
                {
                    return;
                }

                _vmKlientenbudgetMutationsgrundLOV = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VmKlientenbudgetMutationsgrundLOV);
            }
        }

        /// <summary>
        /// in Bearbeitung, in Ordnung, Archiviert.
        /// </summary>
        public ObservableCollection<XLOVCode> VmKlientenbudgetStatusLOV
        {
            get { return _vmKlientenbudgetStatusLOV; }
            private set
            {
                if (_vmKlientenbudgetStatusLOV == value)
                {
                    return;
                }

                _vmKlientenbudgetStatusLOV = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VmKlientenbudgetStatusLOV);
            }
        }

        public ObservableCollection<XLOVCode> VmKlientenbudgetStatusLOVAnzeige
        {
            get { return _vmKlientenbudgetStatusLOVAnzeige; }
            private set
            {
                if (_vmKlientenbudgetStatusLOVAnzeige == value)
                {
                    return;
                }

                _vmKlientenbudgetStatusLOVAnzeige = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VmKlientenbudgetStatusLOVAnzeige);
            }
        }

        private VmKlientenbudgetDTOService Service
        {
            get { return (VmKlientenbudgetDTOService)ServiceCRUD; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override KissServiceResult DeleteData(IUnitOfWork unitOfWork)
        {
            var options = new List<QuestionAnswerOption> { new QuestionAnswerOption(true, "Ja"), new QuestionAnswerOption(false, "Nein") };

            var answer = RaiseQuestion("Soll dieses Budget gelöscht werden?", options, false);

            if (answer == null || !(bool)answer.Tag)
            {
                return KissServiceResult.Ok();
            }

            var result = base.DeleteData(unitOfWork);

            if (result.IsOk)
            {
                SelectFirstBudget();
            }

            return result;
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "VMKLIENTENBUDGETID":
                    {
                        if (SelectedEntity != null && SelectedEntity.VmKlientenbudget != null)
                        {
                            return SelectedEntity.VmKlientenbudget.VmKlientenbudgetID;
                        }

                        return DBNull.Value;
                    }

                default:
                    return base.GetContextValue(fieldName);
            }
        }

        /// <summary>
        /// Initialisert das ViewModel.
        /// </summary>
        public void Init()
        {
            var userService = Container.Resolve<XUserService>();
            var sessionService = Container.Resolve<ISessionService>();
            var userId = sessionService.AuthenticatedUser.UserID;
            _user = userService.GetById(null, userId);
        }

        /// <summary>
        /// Initialisert das ViewModel.
        /// </summary>
        /// <param name="faLeistungId">Die faLeistungId der Leistung</param>
        public void Init(int faLeistungId)
        {
            Init();

            _faLeistungId = faLeistungId;

            //Services für Berechtigung holen
            var sessionService = Container.Resolve<ISessionService>();
            var berechtigungsService = Container.Resolve<BerechtigungsService>();
            var userId = sessionService.AuthenticatedUser.UserID;
            var berechtigung = berechtigungsService.GetUserZugriffrecht(null, faLeistungId, userId);
            Maskenrecht.CanUpdate = Maskenrecht.CanUpdate && berechtigung.MayUpdate;
            Maskenrecht.CanInsert = Maskenrecht.CanInsert && berechtigung.MayInsert;
            Maskenrecht.CanDelete = Maskenrecht.CanDelete && berechtigung.MayDelete;

            //LOVS holen
            VmKlientenbudgetStatusLOV = new ObservableCollection<XLOVCode>(_xlovService.GetLovCodeByLovName(null, "VmKlientenbudgetStatus"));
            VmKlientenbudgetStatusLOVAnzeige = new ObservableCollection<XLOVCode>(_xlovService.GetLovCodeByLovName(null, "VmKlientenbudgetStatus"));
            VmKlientenbudgetMutationsgrundLOV = new ObservableCollection<XLOVCode>(_xlovService.GetLovCodeByLovName(null, "VmKlientenbudgetMutationsgrund"));

            LoadData(null);
        }

        /// <summary>
        /// Gets the data from service
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use (can be null)</param>
        public override void LoadData(IUnitOfWork unitOfWork)
        {
            EntityList = Service.GetByFaLeistungId(unitOfWork, _faLeistungId);
        }

        public override KissServiceResult NewData()
        {
            var result = Service.CanCreateNewData(null, _faLeistungId, EntityList);

            if (!result)
            {
                ValidationResult = result;
                return result;
            }

            result = base.NewData();

            if (!result)
            {
                return result;
            }

            if (SelectedEntity == null)
            {
                ValidationResult = KissServiceResult.Error(new InvalidOperationException("Fehler beim Erstellen des Datensatzes."));
                return ValidationResult;
            }

            SelectedEntity.VmKlientenbudget.XUser = _user;
            SelectedEntity.VmKlientenbudget.FaLeistungID = _faLeistungId;

            return result;
        }

        public override KissServiceResult SaveData(IUnitOfWork unitOfWork)
        {
            if (SelectedEntity == null)
            {
                return KissServiceResult.Ok();
            }

            var result = KissServiceResult.Ok();

            // Budget speichern
            var oldObjectState = SelectedEntity.ChangeTracker.State;
            result += Service.SaveData(unitOfWork, SelectedEntity);

            // altes Budget archivieren wenn ein neues erfolgreich erfasst wurde
            if (result.IsOk && oldObjectState == ObjectState.Added)
            {
                result += Service.BudgetArchivieren(unitOfWork, _faLeistungId, SelectedEntity, EntityList);
            }

            ValidationResult = result;

            if (result.IsOk)
            {
                UpdateStatusliste();
                CopyBudgetCommand.EvaluateCanExecute();
            }

            return result;
        }

        public void SelectBudget(int vmKlientenbudgetId)
        {
            var budget = EntityList.FirstOrDefault(x => x.VmKlientenbudget.VmKlientenbudgetID == vmKlientenbudgetId);

            if (budget != null)
            {
                SelectedEntity = budget;
            }
        }

        #endregion

        #region Protected Methods

        protected override void OnSelectedEntityChanged(VmKlientenbudgetDTO selectedEntity, VmKlientenbudgetDTO deselectedEntity)
        {
            // Positionen / Kategorien laden
            Service.SetPositionen(null, selectedEntity);

            // Liste neu generieren.
            UpdateStatusliste();

            // Enable/Disable copy button
            CopyBudgetCommand.EvaluateCanExecute();

            // Enable/Disable edit button
            NotifyPropertyChanged.RaisePropertyChanged(() => CanEditStatus);

            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);
        }

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            if (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.VmKlientenbudget.VmKlientenbudgetStatusCode))
            {
                CopyBudgetCommand.EvaluateCanExecute();
            }

            base.OnSelectedEntityPropertyChanged(propertyName);
        }

        #endregion

        #region Private Methods

        private bool CanCopyBudget()
        {
            return SelectedEntity != null &&
                   SelectedEntity.ChangeTracker.State != ObjectState.Added &&
                   EntityList.All(x => x.VmKlientenbudget.VmKlientenbudgetStatusEnum != LOVsGenerated.VmKlientenbudgetStatus.InBearbeitung);
        }

        private void CopyBudget()
        {
            VmKlientenbudgetDTO copy;
            ValidationResult = Service.CopyBudget(null, SelectedEntity, _user, EntityList, out copy);

            if (ValidationResult)
            {
                EntityList.Add(copy);
                SelectedEntity = copy;
            }
        }

        private void SelectFirstBudget()
        {
            var budget = EntityList.FirstOrDefault();

            if (budget != null)
            {
                SelectedEntity = budget;
            }
        }

        private void UpdateStatusliste()
        {
            if (SelectedEntity != null)
            {
                Service.UpdateStatusliste(
                    SelectedEntity.VmKlientenbudget.VmKlientenbudgetStatusEnum,
                    VmKlientenbudgetStatusLOVAnzeige);
            }
        }

        #endregion

        #endregion
    }
}