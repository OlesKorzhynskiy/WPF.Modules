using System.Windows.Controls;
using Modules.Interfaces;
using System.Windows.Input;
using Modules.Views;

namespace Modules.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly Dictionary<string, UserControl> _views;
        
        private UserControl _currentView;
        public UserControl CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }
        
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        
        private string _sharedData;
        public string SharedData
        {
            get => _sharedData;
            set
            {
                _sharedData = value;
                OnPropertyChanged(nameof(SharedData));
            }
        }
        
        public ICommand SharedCommand { get; }
        
        public ICommand SwitchViewCommand { get; }

        public MainViewModel()
        {
            SharedCommand ??= new RelayCommand(ExecuteSharedCommand);

            _title = "Shared title";
            _sharedData = "Shared data";
            
            _views = new Dictionary<string, UserControl>
            {
                { "UserControl1", new UserControl1() },
                { "UserControl2", new UserControl2() },
                { "UserControl3", new UserControl3() }
            };

            _currentView = _views["UserControl1"];
            SwitchViewCommand = new RelayCommand(param => SwitchView(param?.ToString()));
        }

        private void ExecuteSharedCommand(object? args)
        {
            Title = "Updated title";
        }

        private void SwitchView(string? viewName)
        {
            if (viewName != null && _views.TryGetValue(viewName, out var view))
            {
                CurrentView = view;
            }
        }
    }
}
