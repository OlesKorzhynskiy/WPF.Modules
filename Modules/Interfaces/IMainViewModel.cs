using System.Windows.Input;

namespace Modules.Interfaces
{
    public interface IMainViewModel
    {
        ICommand SaveCommand { get; }
    }
}
