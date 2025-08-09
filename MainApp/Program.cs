using PluginContracts;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Plugin Architecture Demo ===");

            // Path to the Plugins folder
            string pluginFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");

            if (!Directory.Exists(pluginFolder))
            {
                Directory.CreateDirectory(pluginFolder);
                Console.WriteLine("Plugins folder created.");
                Console.WriteLine("Please place plugin DLLs in the folder and restart.");
                return;
            }

            var pluginFiles = Directory.GetFiles(pluginFolder, "*.dll");
            if (pluginFiles.Length == 0)
            {
                Console.WriteLine("No plugins found in Plugins folder.");
                return;
            }

            foreach (var file in pluginFiles)
            {
                Assembly assembly = Assembly.LoadFrom(file);
                var pluginTypes = assembly.GetTypes()
                    .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface);

                foreach (var type in pluginTypes)
                {
                    IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                    Console.WriteLine($"Loaded: {plugin.Name}");
                    plugin.Execute();
                }
            }

            Console.WriteLine("All plugins executed.");
        }
    }
}
