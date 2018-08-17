using System;
using System.ComponentModel;

using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;

namespace Kiss.UI.ViewModel.Wsh
{
    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class WshGrundBudgetVM : ViewModelBase, IViewModelCRUD
    {
        #region Fields

        #region Private Fields

        private bool _dauerauftragAktiv;
        private WshGrundBudgetAbzugVM _grundBudgetAbzugVM;
        private WshGrundBudgetPositionVM _grundBudgetPositionVM;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Dauerauftrag aktiv ist auf Budgetebene, nicht Positionsebene.
        /// </summary>
        public bool DauerauftragAktiv
        {
            get { return _dauerauftragAktiv; }
            set
            {
                if (_dauerauftragAktiv == value)
                {
                    return;
                }

                _dauerauftragAktiv = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => DauerauftragAktiv);
            }
        }

        public IViewModelCRUD DetailViewModel
        {
            get;
            set;
        }

        public bool HasErrors
        {
            get { return DetailViewModel.HasErrors; }
        }

        public KissServiceResult ValidationResult
        {
            get { return DetailViewModel.ValidationResult; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public KissServiceResult DeleteData(IUnitOfWork unitOfWork)
        {
            return DetailViewModel.DeleteData(unitOfWork);
        }

        public void Init(int leistungId)
        {
        }

        public void LoadData(IUnitOfWork unitOfWork)
        {
            DetailViewModel.LoadData(unitOfWork);
        }

        public KissServiceResult NewData()
        {
            return DetailViewModel.NewData();
        }

        public void RegisterChildrenVM(WshGrundBudgetPositionVM grundBudgetPositionVM, WshGrundBudgetAbzugVM grundBudgetAbzugVM)
        {
            _grundBudgetPositionVM = grundBudgetPositionVM;
            _grundBudgetAbzugVM = grundBudgetAbzugVM;

            _grundBudgetPositionVM.PropertyChanged += PropertyOfGrundbudgetPositionVMChangedEventHandler;
        }

        public KissServiceResult SaveData(IUnitOfWork unitOfWork)
        {
            return DetailViewModel.SaveData(unitOfWork);
        }

        public bool UndoDataChanges()
        {
            return DetailViewModel.UndoDataChanges();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PropertyOfGrundbudgetPositionVMChangedEventHandler(Object sender, PropertyChangedEventArgs e)
        {
            //Dauerauftrag Property Wert vom ViewModel GrundBudgetPositionVM übertragen zum GrundBudgetAbzugVM
               if(e.PropertyName == "DauerauftragAktiv")
               {
               _grundBudgetAbzugVM.DauerauftragAktiv = _grundBudgetPositionVM.DauerauftragAktiv;
               }
        }

        #endregion

        #endregion
    }
}