using Plugin;
using System.Windows;
using System.Windows.Input;

namespace PluginOne
{
    public class PluginOne : IPluginOne
    {
        public PluginOne()
        {
            Command = new DelegateCommand((o) =>
            {
                MessageBox.Show("I'am a plugin one");
            });
        }

        public string Name { get; set; } = "Plugin One";
        public ICommand Command { get; set; }
    }
}
