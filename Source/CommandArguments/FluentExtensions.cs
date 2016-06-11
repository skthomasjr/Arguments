using System;

namespace CommandArguments
{
    public static class FluentExtensions
    {
        public static Argument AddArgument(this Arguments arguments, Action<string> action)
        {
            var argument = new Argument(arguments, action);
            arguments.Add(argument);
            return argument;
        }

        public static Argument AddArgument(this Argument argument, Action<string> action)
        {
            return argument.Arguments.AddArgument(action);
        }

        public static Argument ContinueAfterExecution(this Argument argument)
        {
            argument.ContinueAfterExecution = true;
            return argument;
        }

        public static Arguments Process(this Argument argument)
        {
            return argument.Arguments.Process();
        }

        public static Arguments UsingArgumentSeparators(this Arguments arguments, params string[] separators)
        {
            arguments.ArgumentSeparators = separators;
            return arguments;
        }

        public static Arguments UsingParameterSeparator(this Arguments arguments, char separator)
        {
            arguments.ParameterSeparator = separator;
            return arguments;
        }

        public static Arguments WithArguments(this Arguments arguments, params string[] source)
        {
            arguments.Source = source;
            return arguments;
        }

        public static Argument WithFlags(this Argument argument, params string[] flags)
        {
            argument.Flags = flags;
            return argument;
        }
    }
}
