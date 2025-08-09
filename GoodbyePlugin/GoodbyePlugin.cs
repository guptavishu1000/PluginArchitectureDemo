using PluginContracts;
using System;

namespace GoodbyePlugin
{
    public class GoodbyePlugin : IPlugin
    {
        public string Name => "Goodbye Plugin";

        public void Execute()
        {
            Console.WriteLine("Goodbye from the Goodbye Plugin!");
        }
    }
}
