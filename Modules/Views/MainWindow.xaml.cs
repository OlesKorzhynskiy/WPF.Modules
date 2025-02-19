using System.Windows;
using Modules.Interfaces;

namespace Modules.Views;

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