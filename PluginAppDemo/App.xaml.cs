using Plugin;
using PluginAppDemo.ViewModels;
using System.Windows;

namespace PluginAppDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var loader = Loader.Create();
            loader.LoadPlugins();

            var vm = new MainViewModel();
            vm.Refresh(loader.Plugins);

            this.MainWindow = new MainWindow() { DataContext = vm };
            this.MainWindow.Show();

            var watcher = Watcher.Create();
            watcher.Created += (s, b) =>
            {
                loader.LoadPlugins();
                vm.Refresh(loader.Plugins);
            };
        }
    }
}
