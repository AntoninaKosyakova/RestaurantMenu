using System;
using System.Windows.Input;

namespace RestaurantMenu.Models
{
    /// <summary>
    ///     This `RelayCommand` class is a reusable implementation of the `ICommand` interface 
    ///     that allows you to define command behavior (what happens when you execute it) and 
    ///     conditions for when the command can run, making it useful for binding buttons or 
    ///     UI actions to logic in a clean and flexible way. It uses functions to dynamically 
    ///     handle the execution logic `Execute` and whether the command is enabled `CanExecute`.
    /// </summary>
    public class RelayCommand : ICommand
    {
        // Delegates for execute and canExecute logic
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        // Constructor to initialize the delegates
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        // Event raised when the availability of the command changes
        public event EventHandler CanExecuteChanged;

        // Determine if the command can execute
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        // Execute the command logic
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        // Notify that the CanExecute state has changed
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
