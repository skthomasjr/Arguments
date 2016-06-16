using System;

namespace CommandArguments.SampleConsole
{
    public class SampleInjectedArgument : IArgument
    {
        public Action<string> Action { get; set; } = parameter => { Console.WriteLine("Injected argument 'y' processed"); };

        public string[] Flags { get; set; } = {"y"};

        public bool TerminateAfterExecution { get; set; } = false;
    }
}