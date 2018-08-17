using System.Windows.Input;

namespace Kiss.UserInterface.ViewModel.Commanding
{
    public class CommandBindingToCommand : CommandBinding
    {
        private ICommand _commandToExecute;

        public CommandBindingToCommand()
        {
        }

        public CommandBindingToCommand(ICommand wellKnownCommand, ICommand commandToExecute, bool handled = true)
            : base(wellKnownCommand)
        {
            Handled = handled;
            CommandToExecute = commandToExecute;
        }

        public ICommand CommandToExecute
        {
            get { return _commandToExecute; }
            set
            {
                _commandToExecute = value;

                CanExecute += (sender, e) =>
                {
                    e.CanExecute = _commandToExecute.CanExecute(e.Parameter);
                    e.Handled = Handled;
                };

                Executed += (sender, e) =>
                {
                    _commandToExecute.Execute(e.Parameter);
                    e.Handled = Handled;
                };
            }
        }

        public string CommandToExecuteName { get; set; }

        protected bool Handled { get; set; }
    }
}