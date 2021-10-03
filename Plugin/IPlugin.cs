using System.Windows.Input;

namespace Plugin
{
    public interface IPlugin
    {
        string Name { get; set; }
        ICommand Command { get; set; }
    }
}
