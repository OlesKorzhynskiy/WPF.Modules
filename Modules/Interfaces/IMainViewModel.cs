using System.Windows.Controls;
using System.Windows.Input;

namespace Modules.Interfaces
{
    public interface IMainViewModel
    {
        ICommand SharedCommand { get; }
        
        ICommand SwitchViewCommand { get; }
        
        string Title { get; }
        
        string SharedData { get; }
        
        UserControl CurrentView { get; }
    }
}
