using Microsoft.Extensions.DependencyInjection;
using Modules.Interfaces;
using Modules.ViewModels;
using System.Windows;
using Modules.Views;

namespace Modules;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;

    public App()
    {
        var serviceCollection = new ServiceCollection();

        ConfigureServices(serviceCollection);

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();

        mainWindow.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Configure Logging
        services.AddLogging();

        // Register ViewModels
        services.AddSingleton<IMainViewModel, MainViewModel>();

        // Register Views
        services.AddSingleton<MainWindow>();
    }

    private void OnExit(object sender, ExitEventArgs e)
    {
        // Dispose of services if needed
        if (_serviceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}

