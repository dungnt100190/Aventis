using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Kiss.BL.Wsh;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;
using Kiss.BL.KissSystem;

namespace Kiss.UI.ViewModel.Wsh
{
    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class WshKontoAttributVM : ViewModelCRUDListBase<WshKontoAttribut>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshKontoAttributVM"/> class.
        /// </summary>
        public WshKontoAttributVM()
            : base(Container.Resolve<WshKontoAttributService>())
        {

            _betrifftPersonEditModeCodes = new Dictionary<int, string>
                                               {
                                                   {(int)LOVsGenerated.SysEditMode.Normal, "Freiwillig"},
                                                   {(int)LOVsGenerated.SysEditMode.Required, "Zwingend"},
                                                   {(int)LOVsGenerated.SysEditMode.ReadOnly, "Gesperrt"}
                                               };

        }

        #endregion

        #region Properties

        private WshKontoAttributService Service
        {
            get { return (WshKontoAttributService)ServiceCRUD; }
        }

        private bool _isAlleFilter;
        public bool IsAlleFilter
        {
            get { return _isAlleFilter; }
            set
            {
                if (_isAlleFilter != value)
                {
                    _isAlleFilter = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => IsAlleFilter);
                    LoadData(null);
                }

            }
        }

        private Dictionary<int, string> _betrifftPersonEditModeCodes;
        private Dictionary<string, bool> _isFieldReadonly;

        public Dictionary<int, string> BetrifftPersonEditModeCodes
        {
            get { return _betrifftPersonEditModeCodes; }
        }

        public Dictionary<string, bool> IsFieldReadonly
        {
            get { return _isFieldReadonly; }
            set
            {
                _isFieldReadonly = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => IsFieldReadonly);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init()
        {
            LoadData(null);

            SelectedEntityChanged += WshKontoAttributVM_SelectedEntityChanged;
        }

        private void WshKontoAttributVM_SelectedEntityChanged(WshKontoAttribut selectedEntity, WshKontoAttribut deselectedEntity)
        {
            UpdateIsFieldReadonly(selectedEntity);
        }

        #endregion

        #endregion

        public override KissServiceResult DeleteData(IUnitOfWork unitOfWork)
        {
            ValidationResult = KissServiceResult.Error(new Exception("Sie können hier keine Kontos löschen."));
            return ValidationResult;
        }

        public override KissServiceResult NewData()
        {
            ValidationResult = KissServiceResult.Error(new Exception("Sie können hier keine neuen Kontos erfassen."));
            return ValidationResult;
        }

        public override void LoadData(IUnitOfWork unitOfWork)
        {
            EntityList = new ObservableCollection<WshKontoAttribut>(Service.GetAllWshKontoAttributeAddIfNotExist(unitOfWork));
        }


        private void UpdateIsFieldReadonly(WshKontoAttribut entity)
        {
            var dict = new Dictionary<string, bool>();

            if (entity.KbuKonto != null)
            {
                dict.Add("SysEditModeCode_BetrifftPerson", !entity.KbuKonto.Quoting);
            }
            
            IsFieldReadonly = dict;
        }
    }
}