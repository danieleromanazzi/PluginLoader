using Plugin;
using System.Collections.ObjectModel;

namespace PluginAppDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Plugins = new ObservableCollection<IPlugin>();
        }

        public ObservableCollection<IPlugin> Plugins
        {
            get { return GetValue<ObservableCollection<IPlugin>>(); }
            set { SetValue(value); }
        }

        public void Refresh(ObservableCollection<IPlugin> plugins)
        {
            Plugins = plugins;
        }
    }
}
