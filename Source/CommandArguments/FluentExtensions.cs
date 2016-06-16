using System;

namespace CommandArguments
{
    /// <summary>
    /// Extension methods to support fluent interaction of arguments.
    /// </summary>
    public static class FluentExtensions
    {
        /// <summary>
        /// Adds an <see cref="Argument" />.
        /// </summary>
        /// <param name="arguments">The <see cref="Arguments" /></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Argument AddArgument(this Arguments arguments, Action<string> action)
        {
            var argument = new Argument(arguments);
            argument.Action = action;
            arguments.Add(argument);
            return argument;
        }

        /// <summary>
        /// Adds an <see cref="Argument" />.
        /// </summary>
        /// <param name="arguments">The <see cref="Arguments" /></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static Argument AddArgument(this Arguments arguments, params string[] flags)
        {
            var argument = new Argument(arguments);
            argument.Flags = flags;
            arguments.Add(argument);
            return argument;
        }

        /// <summary>
        /// Adds an <see cref="Argument" />.
        /// </summary>
        /// <param name="arguments">The <see cref="Arguments" /></param>
        /// <returns></returns>
        public static Argument AddArgument(this Arguments arguments)
        {
            var argument = new Argument(arguments);
            arguments.Add(argument);
            return argument;
        }

        /// <summary>
        /// Adds an <see cref="Argument" />.
        /// </summary>
        /// <param name="argument">The <see cref="Argument" /></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Argument AddArgument(this Argument argument, Action<string> action)
        {
            return argument.Arguments.AddArgument(action);
        }

        /// <summary>
        /// Adds an <see cref="Argument" />.
        /// </summary>
        /// <param name="argument">The <see cref="Argument" /></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static Argument AddArgument(this Argument argument, params string[] flags)
        {
            return argument.Arguments.AddArgument(flags);
        }

        /// <summary>
        /// Adds an <see cref="Argument" />.
        /// </summary>
        /// <param name="argument">The <see cref="Argument" /></param>
        /// <returns></returns>
        public static Argument AddArgument(this Argument argument)
        {
            return argument.Arguments.AddArgument();
        }

        /// <summary>
        /// Process the <see cref="Arguments" />.
        /// </summary>
        /// <param name="argument">The <see cref="Argument" /></param>
        /// <returns></returns>
        public static Arguments Process(this Argument argument)
        {
            return argument.Arguments.Process();
        }

        /// <summary>
        /// Terminates after executing the current <see cref="Argument" />.
        /// </summary>
        /// <param name="argument">The <see cref="Argument" /></param>
        /// <returns></returns>
        public static Argument TerminateAfterExecution(this Argument argument)
        {
            argument.TerminateAfterExecution = true;
            return argument;
        }

        /// <summary>
        /// Uses the argument separators with the current <see cref="Arguments" />.
        /// </summary>
        /// <param name="arguments">The <see cref="Arguments" /></param>
        /// <param name="separators">The argument separators.</param>
        /// <returns></returns>
        public static Arguments UsingArgumentSeparators(this Arguments arguments, params string[] separators)
        {
            arguments.ArgumentSeparators = separators;
            return arguments;
        }

        /// <summary>
        /// Uses the parameter separator with the current <see cref="Arguments" />.
        /// </summary>
        /// <param name="arguments">The <see cref="Arguments" /></param>
        /// <param name="separator">The searator character.</param>
        /// <returns></returns>
        public static Arguments UsingParameterSeparator(this Arguments arguments, char separator)
        {
            arguments.ParameterSeparator = separator;
            return arguments;
        }

        /// <summary>
        /// Uses the source parameters with the current <see cref="Arguments" />.
        /// </summary>
        /// <param name="arguments">The <see cref="Arguments" /></param>
        /// <param name="source">The source arguments.</param>
        /// <returns></returns>
        public static Arguments UsingSource(this Arguments arguments, params string[] source)
        {
            arguments.Source = source;
            return arguments;
        }

        /// <summary>
        /// Sets the action of the current <see cref="Argument" />.
        /// </summary>
        /// <param name="argument">The <see cref="Argument" /></param>
        /// <param name="action">The action to execute.</param>
        /// <returns></returns>
        public static Argument WithAction(this Argument argument, Action<string> action)
        {
            argument.Action = action;
            return argument;
        }

        /// <summary>
        /// Sets the flags of the current <see cref="Argument" />.
        /// </summary>
        /// <param name="argument">The <see cref="Argument" /></param>
        /// <param name="flags">The flags.</param>
        /// <returns></returns>
        public static Argument WithFlags(this Argument argument, params string[] flags)
        {
            argument.Flags = flags;
            return argument;
        }
    }
}