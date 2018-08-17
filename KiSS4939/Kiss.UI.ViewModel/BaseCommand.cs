using System;
using System.Windows.Input;
using System.Windows.Threading;

namespace Kiss.UI.ViewModel
{
    /// <summary>
    /// Base class for bindable commands in a ViewModel.
    /// </summary>
    /// <example>
    /// public ICommand DoSomething { get { return new BaseCommand(DoSomethingHandler); } }
    /// private void DoSomethingHandler(object parameter) { }
    /// </example>
    public class BaseCommand : ICommand
    {
        #region Fields

        #region Protected Constant/Read-Only Fields

        protected readonly Func<object, bool> _canExecute;
        protected readonly Action<object> _command;

        #endregion

        #region Private Fields

        private bool _canExecuteState;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an instance of the BaseCommand class.
        /// </summary>
        /// <param name="command">The method that is called when the command is executed.</param>
        /// <param name="canExecute">The method to evaluate if the command can be executed.</param>
        /// <param name="timerInterval">The time interval in milliseconds between each update of the CanExecute state.</param>
        public BaseCommand(Action<object> command, Func<object, bool> canExecute = null)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            _canExecute = canExecute;
            _command = command;

            // Set initial state.
            EvaluateCanExecute();

            // Todo: Untersuchen, ob es für Wsh Auswirkungen hat.

            /* Kreiert ein Memory-Leak.
            CanExecuteTimer = new DispatcherTimer();

            if (timerInterval > 0)
            {
                CanExecuteTimer.Interval = TimeSpan.FromMilliseconds(timerInterval);
                CanExecuteTimer.Tick += (s, e) => EvaluateCanExecute();
                CanExecuteTimer.IsEnabled = true;
            }*/
        }

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Properties

        /// <summary>
        /// The timer that keeps track of the CanExecute state.
        /// </summary>
        public static DispatcherTimer CanExecuteTimer
        {
            get;
            private set;
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

            if (_canExecuteState != newState && CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }

            _canExecuteState = newState;
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