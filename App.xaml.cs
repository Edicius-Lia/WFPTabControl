using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WFPTabControl.ViewModels;

namespace WFPTabControl
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Ioc服务
        /// </summary>
        public IServiceProvider Services { get; }

        public new static App Current => (App)Application.Current;
        public App()
        {
            Services = ConfigureServices();
        }
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton(sp => new MainWindow { DataContext = sp.GetService<MainViewModel>() });
            return services.BuildServiceProvider();
        }
    }

}
