using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Kiss.Infrastructure;
using Kiss.UserInterface.ViewModel.Interfaces;

namespace Kiss.UserInterface.ViewModel.Commanding
{
    public class AsyncTask : ICancellableAsyncTask
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly Func<object, bool> _canExecute;
        private readonly Func<object, CancellationToken, Task> _execute;
        private readonly NotifyPropertyChanged _notifyPropertyChanged;

        public int MaximalParallelExecutions { get; set; }

        private TaskExecution CurrentExecution { get; set; }

        private int _runningExecutions;

        #endregion

        #endregion

        #region Constructors

        public AsyncTask(Func<object, Task> execute, Func<object, bool> canExecute = null)
            : this((param, token) => execute(param), canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            } 
            AllowCancel = false;
        }

        public AsyncTask(Func<object, CancellationToken, Task> execute, Func<object, bool> canExecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _execute = execute;
            _canExecute = canExecute;

            MaximalParallelExecutions = 3;

            StartCommand = new BaseCommand(StartTask, CanStartNewTask);
            CancelCommand = new BaseCommand(parameter => Cancel(), CanCancel);
            _notifyPropertyChanged = new NotifyPropertyChanged(this, () => PropertyChanged);

            AllowCancel = true;
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Commands

        public BaseCommand CancelCommand
        {
            get;
            private set;
        }

        public BaseCommand StartCommand
        {
            get;
            private set;
        }

        private bool _isExecuting;
        public bool IsExecuting
        {
            get { return _isExecuting; }
            private set
            {
                if (_isExecuting == value)
                {
                    return;
                }
                _isExecuting = value;
                _notifyPropertyChanged.RaisePropertyChanged(() => IsExecuting);
            }
        }

        #endregion

        // make public only if needed
        private bool AllowCancel { get; set; }

        //public Task Task
        //{
        //    get { return CurrentExecution == null ? null : CurrentExecution.Task; }
        //}

        #region Methods

        #region Private Methods

        private bool CanCancel(object parameter)
        {
            return AllowCancel && CurrentExecution != null && CurrentExecution.IsRunning;
        }

        private bool CanStartNewTask(object parameter)
        {
            return CurrentExecution == null &&
                   (_canExecute == null || _canExecute(parameter)) &&
                   _runningExecutions < MaximalParallelExecutions;
        }

        private void Cancel()
        {
            if (CurrentExecution != null)
            {
                Console.Out.WriteLine("Execution cancelled, TaskId {0}", CurrentExecution.TaskID);

                CurrentExecution.Cancel();
                CurrentExecution = null;
                IsExecuting = false;
                StartCommand.EvaluateCanExecute();
                CancelCommand.EvaluateCanExecute();
            }
            else
            {
                Console.Out.WriteLine("Execution cancelled, but CurrentExecution = null");
            }
        }

        async void StartTask(object parameter)
        {
            if (CurrentExecution != null)
            {
                // only one parallel execution allowed
                Console.Out.WriteLine("Start not possible, CurrentExecution != null, TaskId {0}", CurrentExecution.TaskID);
                return;
            }

            TaskExecution thisExecution = null;
            try
            {
                _runningExecutions++;
                CurrentExecution = new TaskExecution(_execute);
                thisExecution = CurrentExecution;
                var task = CurrentExecution.Start(parameter);
                Console.Out.WriteLine("Execution started, TaskId {0}", task.Id);

                IsExecuting = true;
                StartCommand.EvaluateCanExecute();
                CancelCommand.EvaluateCanExecute();
                await task;
            }
            finally
            {
                _runningExecutions--;
                if (CurrentExecution != null && CurrentExecution == thisExecution)
                {
                    Console.Out.WriteLine("Execution done, TaskId {0}", CurrentExecution.TaskID);
                    CurrentExecution = null;
                    IsExecuting = false;
                }
                else if (CurrentExecution != null && CurrentExecution != thisExecution)
                {
                    Console.Out.WriteLine("Execution done, CurrentExecution != null && CurrentExecution != thisExecution");
                }
                else
                {
                    Console.Out.WriteLine("Execution done, CurrentExecution = null");
                }
                StartCommand.EvaluateCanExecute();
                CancelCommand.EvaluateCanExecute();
            }
        }

        #endregion

        #endregion
    }
}