using System;
using System.IO;

namespace Plugin
{
    public class Watcher
    {
        public event FileSystemEventHandler Created;
        private Watcher()
        {

        }

        public static Watcher Create()
        {
            var watcher = new Watcher();
            watcher.Start();
            return watcher;
        }

        private void Start()
        {
            var watcher = new FileSystemWatcher(Environment.CurrentDirectory)
            {
                NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size
            };

            watcher.Created += OnCreated;

            watcher.Filter = "Plugin*.dll";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            Created?.Invoke(sender, e);
        }
    }
}
