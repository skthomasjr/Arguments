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
            var argument = new Argument(arguments);
            argument.Action = action;
            arguments.Add(argument);
            return argument;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arguments"></param>
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
        /// 
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static Argument AddArgument(this Arguments arguments)
        {
            var argument = new Argument(arguments);
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
        /// <param name="flags"></param>
        /// <returns></returns>
        public static Argument AddArgument(this Argument argument, params string[] flags)
        {
            return argument.Arguments.AddArgument(flags);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="argument"></param>
        /// <returns></returns>
        public static Argument AddArgument(this Argument argument)
        {
            return argument.Arguments.AddArgument();
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
        /// <param name="argument"></param>
        /// <returns></returns>
        public static Argument TerminateAfterExecution(this Argument argument)
        {
            argument.TerminateAfterExecution = true;
            return argument;
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
        /// <param name="action"></param>
        /// <returns></returns>
        public static Argument WithAction(this Argument argument, Action<string> action)
        {
            argument.Action = action;
            return argument;
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
