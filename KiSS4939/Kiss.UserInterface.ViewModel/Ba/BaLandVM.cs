using System.Collections.Generic;
using System.Linq;

using Kiss.BusinessLogic;
using Kiss.BusinessLogic.Ba;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.UserInterface.ViewModel.Commanding;

namespace Kiss.UserInterface.ViewModel.Ba
{
    public class BaLandVM : ViewModelSearchListCRUD<BaLand, BaLand, object, int>
    {
        #region Fields

        #region Private Fields

        private bool _isReadOnly;
        private string _title;

        #endregion

        #endregion

        #region Constructors

        public BaLandVM()
            : base(Container.Resolve<BaLandService>())
        {
            ImportLaenderCommand = new DelegateCommand(ImportLaender);
            RefreshAfterSave = true;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Abgeleitetes Property, das als Readonly-Binding-Property zur Verfügung gestellt wird hier, inkl. NotifyPropertyChanged, wenn sich in der Collection was ändert
        /// </summary>
        public int AnzahlLand
        {
            get { return EntityList.Count(); }
        }

        public DelegateCommand ImportLaenderCommand
        {
            get;
            set;
        }

        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            set
            {
                if (_isReadOnly == value)
                {
                    return;
                }

                _isReadOnly = value;

                NotifyPropertyChanged.RaisePropertyChanged(() => IsReadOnly);
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value)
                {
                    return;
                }

                _title = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Title);
            }
        }

        private BaLandService BaLandService
        {
            get { return ServiceCRUD as BaLandService; }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override async System.Threading.Tasks.Task InitAsync(Kiss.Interfaces.ViewModel.InitParameters? initParameters = null)
        {
            SearchParametersVisible = true;
            SearchTask.StartCommand.Execute();
        }

        protected override DbContext.DTO.KissSystem.MaskenRechtDTO OverrideMaskenrecht(DbContext.DTO.KissSystem.MaskenRechtDTO maskenRecht)
        {
            maskenRecht.CanInsert = false;
            maskenRecht.CanDelete = false;
            return maskenRecht;
        }

        protected override IServiceResult<IEnumerable<BaLand>> SearchInBackground(object searchParameters, System.Threading.CancellationToken cancellationToken)
        {
            return new ServiceResult<IEnumerable<BaLand>>(BaLandService.GetAllEntities());
        }

        #endregion

        #region Private Methods

        private async void ImportLaender(object obj)
        {
            ValidationResult = await RunAsCompletelyBusy(() => BaLandService.UpdateLand());
            RefreshCommand.Execute(null);
        }

        #endregion

        #endregion
    }
}