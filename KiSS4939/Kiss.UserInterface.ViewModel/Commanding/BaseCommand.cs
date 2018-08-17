using System;
using System.ComponentModel;
using System.Windows.Input;
using Kiss.Infrastructure;

namespace Kiss.UserInterface.ViewModel.Commanding
{
    /// <summary>
    /// Base class for bindable commands in a ViewModel.
    /// </summary>
    /// <example>
    /// public ICommand DoSomething { get { return new BaseCommand(DoSomethingHandler); } }
    /// private void DoSomethingHandler(object parameter) { }
    /// </example>
    public class BaseCommand : ICommand, INotifyPropertyChanged
    {
        #region Fields

        #region Protected Constant/Read-Only Fields

        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _command;
        private readonly NotifyPropertyChanged _notifyPropertyChanged;

        #endregion

        #region Private Fields

        private bool _canExecuteState;

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an instance of the BaseCommand class.
        /// </summary>
        /// <param name="command">The method that is called when the command is executed.</param>
        /// <param name="canExecute">The method to evaluate if the command can be executed.</param>
        public BaseCommand(Action<object> command, Func<object, bool> canExecute = null)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            _canExecute = canExecute;
            _command = command;
            _notifyPropertyChanged = new NotifyPropertyChanged(this, () => PropertyChanged);

            // Set initial state.
            EvaluateCanExecute();
        }

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Properties

        public bool IsExecutable
        {
            get { return _canExecuteState; }
            private set
            {
                if (_canExecuteState == value)
                {
                    return;
                }
                _canExecuteState = value;
                _notifyPropertyChanged.RaisePropertyChanged(() => IsExecutable);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Checks if the command can execute.
        /// </summary>
        /// <param name="parameter">An optional parameter.</param>
        public bool CanExecute(object parameter = null)
        {
            // no CanExecute() attached: always executable 
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        /// <summary>
        /// Checks if CanExecute() returns a different result and fires the CanExecuteChanged event.
        /// </summary>
        public void EvaluateCanExecute()
        {
            var newState = CanExecute();

            if (CanExecuteChanged != null && IsExecutable != newState)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }

            IsExecutable = newState;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <remarks>
        /// The command is executed even if CanExecute() returns false!
        /// </remarks>
        /// <param name="parameter">An optional parameter.</param>
        public void Execute(object parameter = null)
        {
            _command(parameter);
        }

        #endregion

        #endregion
    }
}