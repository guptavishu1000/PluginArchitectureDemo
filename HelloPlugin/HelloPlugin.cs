using PluginContracts;
using System;

namespace HelloPlugin
{
    public class HelloPlugin : IPlugin
    {
        public string Name => "Hello Plugin";

        public void Execute()
        {
            Console.WriteLine("Hello from the Hello Plugin!");
        }
    }
}
