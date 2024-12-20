using System;
using System.Windows.Input;

namespace RestaurantMenu
{
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
