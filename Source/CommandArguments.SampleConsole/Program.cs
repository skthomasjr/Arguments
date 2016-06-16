using System;

namespace CommandArguments.SampleConsole
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.Title = "Sample Console";
            Console.CursorVisible = false;

            // Parameters: /a:"some value" //d --stop -w

            Arguments.WithSource(args)
                .AddArgument("a")
                    .WithAction(parameter => { Console.WriteLine($"Parameter 'a' processed with value: {parameter}"); })
                .AddArgument("d")
                    .WithAction(parameter => { Console.WriteLine("Parameter 'd' processed"); })
                .AddArgument("stop")
                    .WithAction(parameter => { Console.WriteLine("Parameter 'stop' processed"); })
                    .TerminateAfterExecution()
                .AddArgument("w")
                    .WithAction(parameter => { Console.WriteLine("Parameter 'w' processed"); })
                .Process();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}