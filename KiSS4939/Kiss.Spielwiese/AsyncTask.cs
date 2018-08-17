//using System;
//using System.ComponentModel;
//using System.Threading;
//using System.Threading.Tasks;
//using Kiss.Infrastructure;
//using Kiss.UserInterface.ViewModel.Interfaces;

//namespace Kiss.UserInterface.ViewModel.Commanding
//{
//    public class AsyncTask : ICancellableAsyncTask
//    {
//        #region Fields

//        #region Private Constant/Read-Only Fields

//        private readonly Func<object, bool> _canExecute;
//        private readonly Action<object, CancellationToken> _execute;
//        private readonly NotifyPropertyChanged _notifyPropertyChanged;

//        public int MaximalParallelExecutions { get; set; }

//        private TaskExecution CurrentExecution { get; set; }

//        private int _runningExecutions;

//        #endregion

//        #endregion

//        #region Constructors

//        public AsyncTask(Action<object> execute, Func<object, bool> canExecute = null)
//            : this((param, token) => execute(param), canExecute)
//        {
//            AllowCancel = false;
//        }

//        public AsyncTask(Action<object, CancellationToken> execute, Func<object, bool> canExecute = null)
//        {
//            if (execute == null)
//            {
//                throw new ArgumentNullException("execute");
//            }
//            _execute = execute;
//            _canExecute = canExecute;

//            MaximalParallelExecutions = 3;

//            StartCommand = new BaseCommand(StartTask, CanStartNewTask);
//            CancelCommand = new BaseCommand(parameter => Cancel(), CanCancel);
//            _notifyPropertyChanged = new NotifyPropertyChanged(this, () => PropertyChanged);

//            AllowCancel = true;
//        }

//        #endregion

//        #region Events

//        public event PropertyChangedEventHandler PropertyChanged;

//        #endregion

//        #region Commands

//        public BaseCommand CancelCommand
//        {
//            get;
//            private set;
//        }

//        public BaseCommand StartCommand
//        {
//            get;
//            private set;
//        }

//        private bool _isExecuting;
//        public bool IsExecuting
//        {
//            get { return _isExecuting; }
//            private set
//            {
//                if (_isExecuting == value)
//                {
//                    return;
//                }
//                _isExecuting = value;
//                _notifyPropertyChanged.RaisePropertyChanged(() => IsExecuting);
//            }
//        }

//        #endregion

//        // make public only if needed
//        private bool AllowCancel { get; set; }

//        public Task Task
//        {
//            get { return CurrentExecution == null ? null : CurrentExecution.Task; }
//        }

//        #region Methods

//        #region Private Methods

//        private bool CanCancel(object parameter)
//        {
//            return AllowCancel && CurrentExecution != null && CurrentExecution.CanCancel(parameter);
//        }

//        private bool CanStartNewTask(object parameter)
//        {
//            return CurrentExecution == null &&
//                   (_canExecute == null || _canExecute(parameter)) &&
//                   _runningExecutions < MaximalParallelExecutions;
//        }

//        private void Cancel()
//        {
//            if (CurrentExecution != null)
//            {
//                Console.Out.WriteLine("Execution cancelled, TaskId {0}", CurrentExecution.Task.Id);

//                CurrentExecution.Cancel();
//                CurrentExecution = null;
//                IsExecuting = false;
//                StartCommand.EvaluateCanExecute();
//                CancelCommand.EvaluateCanExecute();
//            }
//            else
//            {
//                Console.Out.WriteLine("Execution cancelled, but CurrentExecution = null");
//            }
//        }

//        async void StartTask(object parameter)
//        {
//            if (CurrentExecution != null)
//            {
//                // only one parallel execution allowed
//                Console.Out.WriteLine("Start not possible, CurrentExecution != null, TaskId {0}", CurrentExecution.Task.Id);
//                return;
//            }

//            TaskExecution thisExecution = null;
//            try
//            {
//                _runningExecutions++;
//                CurrentExecution = new TaskExecution(_execute, parameter);
//                thisExecution = CurrentExecution;
//                Console.Out.WriteLine("Execution created, TaskId {0}", CurrentExecution.Task.Id);
//                var task = CurrentExecution.Start(parameter);

//                IsExecuting = true;
//                StartCommand.EvaluateCanExecute();
//                CancelCommand.EvaluateCanExecute();
//                await task;
//            }
//            finally
//            {
//                _runningExecutions--;
//                if (CurrentExecution != null && CurrentExecution == thisExecution)
//                {
//                    Console.Out.WriteLine("Execution done, TaskId {0}", CurrentExecution.Task.Id);
//                    CurrentExecution = null;
//                    IsExecuting = false;
//                }
//                else if (CurrentExecution != null && CurrentExecution != thisExecution)
//                {
//                    Console.Out.WriteLine("Execution done, CurrentExecution != null && CurrentExecution != thisExecution");
//                }
//                else
//                {
//                    Console.Out.WriteLine("Execution done, CurrentExecution = null");
//                }
//                StartCommand.EvaluateCanExecute();
//                CancelCommand.EvaluateCanExecute();
//            }
//        }

//        #endregion

//        #endregion
//    }
//}