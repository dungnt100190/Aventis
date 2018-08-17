using System;
using System.Windows.Input;

namespace Kiss.UserInterface.ViewModel.Commanding
{
    /// <summary>
    /// Base class for bindable commands in a ViewModel.
    /// </summary>
    /// <example>
    /// public ICommand DoSomething { get { return new BaseCommand(DoSomethingHandler); } }
    /// private void DoSomethingHandler(object parameter) { }
    /// </example>
    public class DelegateCommand : IDelegateCommand
    {
        #region Fields

        #region Protected Constant/Read-Only Fields

        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an instance of the BaseCommand class.
        /// </summary>
        /// <param name="execute">The method that is called when the command is executed.</param>
        /// <param name="canExecute">The method to evaluate if the command can be executed.</param>
        public DelegateCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _canExecute = canExecute;
            _execute = execute;

            // Set initial state.
            //RaiseCanExecuteChanged();
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
            return _canExecute == null || 
                   _canExecute(parameter);
        }

        /// <summary>
        /// Checks if CanExecute() returns a different result and fires the CanExecuteChanged event.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }


        public event EventHandler CanExecuteChanged;
 

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <remarks>
        /// The command is executed even if CanExecute() returns false!
        /// </remarks>
        /// <param name="parameter">An optional parameter.</param>
        public void Execute(object parameter = null)
        {
            _execute(parameter);
        }

        #endregion

        #endregion
    }
}