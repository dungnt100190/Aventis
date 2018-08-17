using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using Kiss.BL.Fs;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;
using Kiss.Model;
using Kiss.Model.DTO.Fs;
using Kiss.UI.ViewModel.Commanding;

namespace Kiss.UI.ViewModel.Fs
{
    //: ViewModelCRUDListBase<FsMitarbeiterArbeitszeitDTO>
    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class FsVerfuegbareArbeitszeitVM : ViewModelBase, IViewModelCRUD
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly FsReduktionMitarbeiterService _reduktionMitarbeiterService;
        private readonly FsReduktionService _reduktionService;
        private readonly FsVerfuegbareArbeitszeitService _verfuegbareArbeitszeitService;

        #endregion

        #region Private Fields

        private ICommand _generateReduktionenCommand;
        private List<FsMitarbeiterArbeitszeitDTO> _mitarbeiterArbeitszeiten;
        private IAsyncCommand _searchCommand;

        /// <summary>
        /// The currently selected entity.
        /// </summary>
        private FsMitarbeiterArbeitszeitDTO _selectedEntity;

        private MonthYear? _selectedMonth;
        private string _valuesAreGenerated = string.Empty;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FsVerfuegbareArbeitszeitVM"/> class.
        /// </summary>
        public FsVerfuegbareArbeitszeitVM()
        {
            _reduktionService = Container.Resolve<FsReduktionService>();
            _reduktionMitarbeiterService = Container.Resolve<FsReduktionMitarbeiterService>();
            _verfuegbareArbeitszeitService = Container.Resolve<FsVerfuegbareArbeitszeitService>();

            SelectedMonth = new MonthYear(DateTime.Today);
        }

        #endregion

        #region Properties

        /// <summary>
        /// List of Users with their Reduktionen
        /// </summary>
        public List<FsMitarbeiterArbeitszeitDTO> MitarbeiterArbeitszeiten
        {
            get { return _mitarbeiterArbeitszeiten; }
            private set
            {
                _mitarbeiterArbeitszeiten = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => MitarbeiterArbeitszeiten);
            }
        }

        /// <summary>
        /// List of all configured Reduktionen
        /// </summary>
        public ObservableCollection<FsReduktion> Reduktionen
        {
            get { return _reduktionService.GetData(null); }
        }

        /// <summary>
        /// Commmand to get the MitarbeiterArbeitszeiten for the SelectedMonth
        /// </summary>
        public IAsyncCommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new AsyncDelegateCommand<object>(o => LoadData(null), o => SelectedMonth.HasValue);
                }

                return _searchCommand;
            }
        }

        /// <summary>
        /// The selected row of the MitarbeiterArbeitszeiten list
        /// </summary>
        public FsMitarbeiterArbeitszeitDTO SelectedEntity
        {
            get { return _selectedEntity; }
            set
            {
                if (_selectedEntity == value)
                {
                    return;
                }

                if (_selectedEntity != null && value != null &&
                    _selectedEntity.Reduktionen.Values.Count(fs => fs.ChangeTracker.State != ObjectState.Unchanged) > 0)
                {
                    ValidationResult = SaveData(null);

                    if (!ValidationResult)
                    {
                        return;
                    }
                }

                _selectedEntity = value;
                ValidationResult = KissServiceResult.Ok();
                NotifyPropertyChanged.RaisePropertyChanged(() => SelectedEntity);
            }
        }

        /// <summary>
        /// The month/year the MitarbeiterArbeitszeiten are corresponding to
        /// </summary>
        public MonthYear? SelectedMonth
        {
            get { return _selectedMonth; }
            set
            {
                if (_selectedMonth != value)
                {
                    _selectedMonth = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => SelectedMonth);
                    if (_selectedMonth.HasValue && !DesignMode)
                    {
                        List<FsMitarbeiterArbeitszeitDTO> mitarbeiterArbeitszeiten;
                        _verfuegbareArbeitszeitService.GetMitarbeiterArbeitszeit(null, out mitarbeiterArbeitszeiten, _selectedMonth.Value, null);
                        MitarbeiterArbeitszeiten = mitarbeiterArbeitszeiten;

                        _valuesAreGenerated = string.Empty;
                        var areEntriesGenerated = _reduktionMitarbeiterService.AreEntriesGenerated(null, _selectedMonth.Value - 1);
                        if (!areEntriesGenerated)
                        {
                            _valuesAreGenerated = "Es existieren keine Einträge im vorhergehenden Monat.";
                        }

                        NotifyPropertyChanged.RaisePropertyChanged(() => ValuesAreGenerated);
                    }
                }
            }
        }

        /// <summary>
        /// Message text, when previous month/year is missed
        /// </summary>
        public string ValuesAreGenerated
        {
            get { return _valuesAreGenerated; }
            set { _valuesAreGenerated = value; }
        }

        #endregion

        #region Commands

        public ICommand GenerateReduktionenCommand
        {
            get
            {
                if (_generateReduktionenCommand == null)
                {
                    _generateReduktionenCommand = new BaseCommand(GenerateReduktionen, o => SelectedMonth.HasValue);
                }

                return _generateReduktionenCommand;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public KissServiceResult DeleteData(IUnitOfWork unitOfWork)
        {
            // Never allow to delete a single FsReduktionMitarbeiter-record
            return new KissServiceResult(
                ServiceResultType.Error,
                "FsVerfuegbareArbeitszeitVM_NoDeleteData",
                "In dieser Maske dürfen keine Datensätze gelöscht werden");
        }

        public void Init()
        {
        }

        public void LoadData(IUnitOfWork unitOfWork)
        {
            if (_selectedMonth.HasValue)
            {
                List<FsMitarbeiterArbeitszeitDTO> mitarbeiterArbeitszeiten;
                _verfuegbareArbeitszeitService.GetMitarbeiterArbeitszeit(null, out mitarbeiterArbeitszeiten, _selectedMonth.Value, null);
                MitarbeiterArbeitszeiten = mitarbeiterArbeitszeiten;
            }
        }

        public KissServiceResult NewData()
        {
            // Never allow to create a single FsReduktionMitarbeiter-record
            return new KissServiceResult(
                ServiceResultType.Error,
                "FsVerfuegbareArbeitszeitVM_NoNewData",
                "In dieser Maske dürfen keine neuen Datensätze erstellt werden");
        }

        public virtual void RefreshData()
        {
            LoadData(null);
        }

        public virtual KissServiceResult SaveData(IUnitOfWork unitOfWork)
        {
            var dtoToSave = SelectedEntity;
            if (dtoToSave == null)
            {
                return KissServiceResult.Ok();
            }

            var listToSave = new List<FsReduktionMitarbeiter>(dtoToSave.Reduktionen.Values);
            ValidationResult = _reduktionMitarbeiterService.SaveData(unitOfWork, listToSave);

            return ValidationResult;
        }

        public bool UndoDataChanges()
        {
            return false;
        }

        #endregion

        #region Private Methods

        private void GenerateReduktionen(object obj)
        {
            if (!SelectedMonth.HasValue)
            {
                return;
            }

            ValidationResult = _reduktionMitarbeiterService.CreateEntries(null, SelectedMonth.Value);
            RefreshData();
        }

        #endregion

        #endregion
    }
}