using System.Windows.Input;

namespace Modules.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object?>? _canExecuteDelegate;
        private readonly Action<object?> _executeDelegate;

        public RelayCommand(Action<object?> action, Predicate<object?>? predicate = null)
        {
            _executeDelegate = action;
            _canExecuteDelegate = predicate;
        }


        public bool CanExecute(object? parameter)
        {
            if (_canExecuteDelegate != null)
                return _canExecuteDelegate(parameter);

            return true;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object? parameter)
        {
            _executeDelegate(parameter);
        }
    }
}
