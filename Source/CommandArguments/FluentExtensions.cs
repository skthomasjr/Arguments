using System;

namespace CommandArguments
{
    /// <summary>
    /// 
    /// </summary>
    public static class FluentExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Argument AddArgument(this Arguments arguments, Action<string> action)
        {
            var argument = new Argument(arguments, action);
            arguments.Add(argument);
            return argument;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Argument AddArgument(this Argument argument, Action<string> action)
        {
            return argument.Arguments.AddArgument(action);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="argument"></param>
        /// <returns></returns>
        public static Argument ContinueAfterExecution(this Argument argument)
        {
            argument.ContinueAfterExecution = true;
            return argument;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="argument"></param>
        /// <returns></returns>
        public static Arguments Process(this Argument argument)
        {
            return argument.Arguments.Process();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="separators"></param>
        /// <returns></returns>
        public static Arguments UsingArgumentSeparators(this Arguments arguments, params string[] separators)
        {
            arguments.ArgumentSeparators = separators;
            return arguments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static Arguments UsingParameterSeparator(this Arguments arguments, char separator)
        {
            arguments.ParameterSeparator = separator;
            return arguments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Arguments WithArguments(this Arguments arguments, params string[] source)
        {
            arguments.Source = source;
            return arguments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static Argument WithFlags(this Argument argument, params string[] flags)
        {
            argument.Flags = flags;
            return argument;
        }
    }
}
