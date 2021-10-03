using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Plugin
{
    public class Loader
    {
        private readonly PluginCompare pluginCompare = new PluginCompare();

        private Loader()
        {

        }

        public ObservableCollection<IPlugin> Plugins { get; private set; }

        public static Loader Create()
        {
            return new Loader();
        }

        public void LoadPlugins()
        {
            Plugins = new ObservableCollection<IPlugin>();
            //Load the DLLs from the Plugins directory
            if (Directory.Exists(Environment.CurrentDirectory))
            {
                string[] files = Directory.GetFiles(Environment.CurrentDirectory);
                foreach (string file in files)
                {
                    if (Path.GetFileName(file).StartsWith("Plugin") &&
                        Path.GetExtension(file).Equals(".dll", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Assembly.LoadFile(Path.GetFullPath(file));
                    }
                }
            }

            Type interfaceType = typeof(IPlugin);
            //Fetch all types that implement the interface IPlugin and are a class
            Type[] types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass)
                .ToArray();
            foreach (Type type in types)
            {
                //Create a new instance of all found types
                if (CreatePluginInstance<IPlugin>(type) is IPlugin plugin &&
                    !Plugins.Contains(plugin, pluginCompare))
                {
                    Plugins.Add(plugin);
                }
            }
        }

        private object CreatePluginInstance<T>(Type type)
        {
            try
            {
                return (T)Activator.CreateInstance(type);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
