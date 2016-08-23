using System;

namespace Arguments.SampleConsole
{
    public class SampleInjectedArgument : IArgument
    {
        public SampleInjectedArgument()
        {
            Action = (target, parameter) =>
            {
                ProcessAction((int)target, parameter);
            };
        }
        public Action<object, string> Action { get; set; }

        public string[] Flags { get; set; } = { "y" };

        public object Target { get; set; } = 55;

        public bool TerminateAfterExecution { get; set; } = false;

        public string Value { get; set; }

        private void ProcessAction(int target, string parameter)
        {
            Console.WriteLine(target * 1000);
        }
    }
}