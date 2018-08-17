using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Kiss.UserInterface.ViewModel.Commanding
{
    /// <summary>
    /// Class to execut multiple DelegateCommands is based on https://code.google.com/p/ndddsample/source/browse/trunk/src/RegisterApp/NDDDSample.RegisterApp/Commands/CompositeCommand.cs?r=102
    /// </summary>
    public class MultiDelegateCommand : IDelegateCommand
    {
        /// <summary>
        /// The registered commands.
        /// </summary>
        private readonly List<IDelegateCommand> _registeredCommands = new List<IDelegateCommand>();

        /// <summary>
        /// The can execute changed.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Gets the list of all the registered commands.
        /// </summary>
        /// <value>A list of registered commands.</value>
        /// <remarks>This returns a copy of the commands subscribed to the CompositeCommand.</remarks>
        public IList<IDelegateCommand> RegisteredCommands
        {
            get
            {
                IList<IDelegateCommand> commandList;
                lock (_registeredCommands)
                {
                    commandList = _registeredCommands.ToList();
                }

                return commandList;
            }
        }

        /// <summary>
        /// Forwards <see cref="IDelegateCommand.CanExecute"/> to the registered commands and returns
        /// <see langword="true"/> if all of the commands return <see langword="true"/>.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command.
        /// If the command does not require data to be passed, this object can be set to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if all of the commands return <see langword="true"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public virtual bool CanExecute(object parameter)
        {
            bool hasEnabledCommandsThatShouldBeExecuted = false;

            IDelegateCommand[] commandList;
            lock (_registeredCommands)
            {
                commandList = _registeredCommands.ToArray();
            }

            foreach (var command in commandList)
            {
                if (!command.CanExecute(parameter))
                {
                    return false;
                }

                hasEnabledCommandsThatShouldBeExecuted = true;
            }

            return hasEnabledCommandsThatShouldBeExecuted;
        }

        /// <summary>
        /// Forwards <see cref="IDelegateCommand.Execute"/> to the registered commands.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command.
        /// If the command does not require data to be passed, this object can be set to <see langword="null"/>.
        /// </param>
        public virtual void Execute(object parameter)
        {
            Queue<IDelegateCommand> commands;
            lock (_registeredCommands)
            {
                commands = new Queue<IDelegateCommand>(_registeredCommands.ToList());
            }

            while (commands.Count > 0)
            {
                var command = commands.Dequeue();
                command.Execute(parameter);
            }
        }

        /// <summary>
        /// Forwards <see cref="IDelegateCommand.RaiseCanExecuteChanged"/> to the registered commands.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            IDelegateCommand[] commandList;
            lock (_registeredCommands)
            {
                commandList = _registeredCommands.ToArray();
            }

            foreach (var command in commandList)
            {
                command.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Adds a command to the collection and signs up for the <see cref="IDelegateCommand.CanExecuteChanged"/> event of it.
        /// </summary>
        /// <param name="command">
        /// The command to register.
        /// </param>
        public virtual void RegisterCommand(IDelegateCommand command)
        {
            lock (_registeredCommands)
            {
                _registeredCommands.Add(command);
            }
        }

        /// <summary>
        /// Removes a command from the collection and removes itself from the <see cref="IDelegateCommand.CanExecuteChanged"/> event of it.
        /// </summary>
        /// <param name="command">
        /// The command to unregister.
        /// </param>
        public virtual void UnregisterCommand(IDelegateCommand command)
        {
            lock (_registeredCommands)
            {
                _registeredCommands.Remove(command);
            }
        }
    }
}