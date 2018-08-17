using System;
using System.ComponentModel;
using System.Windows.Input;

using Kiss.Infrastructure;
using Kiss.Interfaces.ViewModel;

namespace Kiss.UI.ViewModel.Commanding
{
    public class AsyncDelegateCommand<T> : IAsyncCommand
        where T : class
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly Func<object, bool> _canExecute;
        private readonly ICommand _cancelCommand;
        private readonly Action<T> _execute;
        private readonly NotifyPropertyChanged _notifyPropertyChanged;
        readonly BackgroundWorker _worker = new BackgroundWorker();

        #endregion

        #region Private Fields

        private bool _isExecuteEnabled = true;
        private bool _isExecuting;

        #endregion

        #endregion

        #region Constructors

        public AsyncDelegateCommand(Action<T> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;

            _worker.DoWork += worker_DoWork;
            _worker.RunWorkerCompleted += (sender, e) =>
            {
                IsExecuting = false;
                InvokeExecuted(EventArgs.Empty);
                OnCanExecuteChanged();
            };

            _cancelCommand = new BaseCommand(o => Cancel(), o => IsExecuting && _worker.WorkerSupportsCancellation);
            _notifyPropertyChanged = new NotifyPropertyChanged(this, () => PropertyChanged);
        }

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged;

        public event EventHandler Executed;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public bool IsExecuteEnabled
        {
            get { return _isExecuteEnabled && !_isExecuting; }
            set
            {
                if (_isExecuteEnabled == value)
                {
                    return;
                }

                _isExecuteEnabled = value;
                OnCanExecuteChanged();
                _notifyPropertyChanged.RaisePropertyChanged(() => IsExecuteEnabled);
            }
        }

        public bool IsExecuting
        {
            get { return _isExecuting; }
            private set
            {
                _isExecuting = value;
                _notifyPropertyChanged.RaisePropertyChanged(() => IsExecuting);
                OnCanExecuteChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand CancelCommand
        {
            get { return _cancelCommand; }
        }

        #endregion

        #region EventHandlers

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _execute(sender as T);
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Execute(object parameter)
        {
            lock (_execute)
            {
                IsExecuting = true;
                _worker.RunWorkerAsync(parameter);
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            var canExecute = _canExecute != null ? _canExecute(parameter) : true;
            return IsExecuteEnabled && !IsExecuting && canExecute;
        }

        public void InvokeExecuted(EventArgs e)
        {
            if (Executed != null)
            {
                Executed(this, e);
            }
        }

        #endregion

        #region Private Methods

        private void Cancel()
        {
            lock (_execute)
            {
                _worker.CancelAsync();
            }
        }

        private void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        #endregion

        #endregion
    }
}