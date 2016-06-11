using System;

namespace CommandArguments
{
    public class Argument
    {
        public Argument(Arguments arguments, Action<string> action)
        {
            Arguments = arguments;
            Action = action;
        }

        public Action<string> Action { get; set; }

        public Arguments Arguments { get; set; }

        public bool ContinueAfterExecution { get; set; }

        public string[] Flags { get; set; }
    }
}