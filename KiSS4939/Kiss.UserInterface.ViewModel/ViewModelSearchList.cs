using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kiss.BusinessLogic;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;
using Kiss.UserInterface.ViewModel.Commanding;
using Kiss.UserInterface.ViewModel.Interfaces;
using Kiss.Utilities;

namespace Kiss.UserInterface.ViewModel
{
    public abstract class ViewModelSearchList<TEntity, TSearchParams> : ViewModelList<TEntity>, IViewModelSearch
        where TEntity : class
    {
        private TSearchParams _lastAppliedSearchParameters;
        private TSearchParams _searchParameters;
        private bool _searchParametersVisible;
        private IServiceResult _searchValidationResult;

        protected ViewModelSearchList()
        {
            SearchTask = new AsyncTask((parameter, cancellationToken) => Search(cancellationToken));
            SearchParametersVisible = true;
            HasBackgroundSearch = true;

            RefreshCommand = new DelegateCommand(x => RefreshData());
            ResetCommand = new DelegateCommand(ResetSearchParameters);
        }

        /// <summary>
        /// If false, SearchTask is bypassed and search is only used to toggle SearchParamsVisible
        /// </summary>
        public bool HasBackgroundSearch { get; protected set; }

        public virtual TSearchParams LastAppliedSearchParameters
        {
            get { return _lastAppliedSearchParameters; }
            private set
            {
                _lastAppliedSearchParameters = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => LastAppliedSearchParameters);
            }
        }

        public IDelegateCommand RefreshCommand { get; private set; }

        public IDelegateCommand ResetCommand { get; private set; }

        public TSearchParams SearchParameters
        {
            get { return _searchParameters; }
            protected set
            {
                SetProperty(ref _searchParameters, value, () => SearchParameters);
            }
        }

        /// <summary>
        /// Gets or sets if a new search is being prepared
        /// </summary>
        public bool SearchParametersVisible
        {
            get { return _searchParametersVisible; }
            set
            {
                _searchParametersVisible = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => SearchParametersVisible);
            }
        }

        public ICancellableAsyncTask SearchTask { get; private set; }

        public IServiceResult SearchValidationResult
        {
            get { return _searchValidationResult; }
            protected set
            {
                _searchValidationResult = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => SearchValidationResult);
            }
        }

        public virtual void RefreshData()
        {
            SearchParametersVisible = true;
            SearchTask.StartCommand.Execute();
        }

        public virtual async Task Search(CancellationToken cancellationToken)
        {
            if (!HasBackgroundSearch)
            {
                SearchParametersVisible = !SearchParametersVisible;
                return;
            }

            if (!SearchParametersVisible)
            {
                SearchParametersVisible = true;
                return;
            }

            var searchTask = SearchSync(SearchParameters, cancellationToken);
            CompletelyBusyTasks.AddObservation(searchTask);
            var result = await searchTask;
            SearchValidationResult = result;
            if (SearchValidationResult.IsOk && !cancellationToken.IsCancellationRequested)
            {
                SearchParametersVisible = false;
                LastAppliedSearchParameters = ObjectCloner.Clone(SearchParameters);

                SetEntityList(result.Result);
            }
        }

        protected virtual void ResetSearchParameters(object parameter)
        {
        }

        protected virtual IServiceResult<IEnumerable<TEntity>> SearchInBackground(TSearchParams searchParameters, CancellationToken cancellationToken)
        {
            return new ServiceResult<IEnumerable<TEntity>>(ServiceResult<TEntity>.Ok());
        }

        protected virtual Task<IServiceResult<IEnumerable<TEntity>>> SearchSync(TSearchParams searchParameters, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => SearchInBackground(searchParameters, cancellationToken));
        }
    }
}