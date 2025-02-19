using Modules.Interfaces;
using System.Windows;

namespace Modules;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(IMainViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}