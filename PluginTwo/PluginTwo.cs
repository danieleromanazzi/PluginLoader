using Plugin;
using System.Windows;
using System.Windows.Input;

namespace PluginTwo
{
    public class PluginTwo : IPluginTwo
    {
        public PluginTwo()
        {
            Command = new DelegateCommand((o) =>
            {
                MessageBox.Show("I'am a plugin two");
            });
        }

        public string Name { get; set; } = "Plugin Two";
        public ICommand Command { get; set; }
    }
}
