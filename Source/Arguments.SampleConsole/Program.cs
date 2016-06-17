using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;

namespace Arguments.SampleConsole
{
    internal class Program
    {
        internal static int Main(string[] args)
        {
            // Add this command-line parameter: /a:"some value" //d --stop -w --y

            Console.Title = "Sample Console";
            Console.CursorVisible = false;

            // This demonstrates how to inject arguments with MEF.
            IEnumerable<IArgument> arguments;
            using (var catalog = new AggregateCatalog(new AssemblyCatalog(Assembly.GetExecutingAssembly())))
                using (var container = new CompositionContainer(catalog))
                    arguments = container.GetExportedValues<IArgument>();

            // Typical usage.
            var processedArguments = ArgumentProcessor.NewArguments(args, arguments)
                .AddArgument("a")
                    .WithAction(parameter => { Console.WriteLine($"Argument 'a' processed with value: {parameter}"); })
                .AddArgument("d")
                    .WithAction(parameter => { Console.WriteLine("Argument 'd' processed"); })
                .AddArgument("stop")
                    .WithAction(parameter => { Console.WriteLine("Argument 'stop' processed"); })
                .AddArgument("w")
                    .WithAction(parameter => { Console.WriteLine("Argument 'w' processed"); })
                .Process();

            // We may want to return if any command-line parameters have been processed.
            if (processedArguments.Any())
            {
                //return 0;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            return 0;
        }
    }
}