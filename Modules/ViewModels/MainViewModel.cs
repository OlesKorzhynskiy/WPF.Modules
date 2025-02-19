using Modules.Interfaces;
using System.Windows.Input;

namespace Modules.ViewModels
{
    public class MainViewModel : IMainViewModel
    {
        private ICommand _saveCommand;

        public MainViewModel()
        {
            _saveCommand ??= new RelayCommand(ExecuteSave);
        }

        public ICommand SaveCommand => _saveCommand;

        private void ExecuteSave(object? args)
        {
        }
    }
}
