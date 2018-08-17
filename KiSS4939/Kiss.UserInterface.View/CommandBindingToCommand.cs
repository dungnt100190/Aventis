using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Kiss.UI.View
{
    class CommandBindingToCommand : CommandBinding
    {
        public CommandBindingToCommand(ICommand commandToAttach, ICommand commandToExecute)
            : base(commandToAttach)
        {
            SetCommandInstance(commandToExecute);
        }




        public static ICommand GetCommandToExecute(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandToExecuteProperty);
        }

        public static void SetCommandToExecute(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandToExecuteProperty, value);
        }

        // Using a DependencyProperty as the backing store for CommandToExecute.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandToExecuteProperty =
            DependencyProperty.RegisterAttached("CommandToExecute", typeof(ICommand), typeof(CommandBindingToCommand), new UIPropertyMetadata(CommandToExecuteChanged));

        public static void CommandToExecuteChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommandBindingToCommand instance = null;// (CommandBindingToCommand)d;
            var oldValue = e.OldValue as ICommand;
            var newValue = e.NewValue as ICommand;
            if (newValue == null)
            {
                throw new ArgumentNullException();
            }
            
            if( oldValue != null && newValue != oldValue)
            {
                throw new InvalidOperationException("Changing of CommandToExecute is not allowed");
            }

            instance.SetCommandInstance(newValue);
        }



        private void SetCommandInstance(ICommand commandToExecute)
        {
            base.CanExecute += (sender, e) =>
            {
                e.CanExecute = commandToExecute.CanExecute(e.Parameter);
                e.Handled = true;
            };

            base.Executed += (sender, e) =>
            {
                commandToExecute.Execute(e.Parameter);
                e.Handled = true;
            };

        }
    }
}
