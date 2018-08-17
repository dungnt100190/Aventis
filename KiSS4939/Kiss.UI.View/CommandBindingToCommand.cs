using System;
using System.Windows.Input;

namespace Kiss.UI.View
{
    public class CommandBindingToCommand : CommandBinding
    {
        private ICommand _commandToExecute;
        public ICommand CommandToExecute
        {
            get { return _commandToExecute; }
            set
            {
                if (_commandToExecute != null)
                {
                    throw new InvalidOperationException("Changing of CommandToExecute is not allowed");
                }
                if (value == null)
                {
                    throw new InvalidOperationException("'null' is not valid as CommandToExecute");
                }
                _commandToExecute = value;
                CanExecute += (sender, e) =>
                                            {
                                                e.CanExecute = _commandToExecute.CanExecute(e.Parameter);
                                                e.Handled = true;
                                            };

                Executed += (sender, e) =>
                                          {
                                              _commandToExecute.Execute(e.Parameter);
                                              e.Handled = true;
                                          };
            }
        }
    }
}
