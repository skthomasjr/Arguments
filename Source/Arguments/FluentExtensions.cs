using System;
using System.Collections.Generic;

namespace Arguments
{
    /// <summary>
    /// Extension methods to support fluent interaction of arguments.
    /// </summary>
    public static class FluentExtensions
    {
        /// <summary>
        /// Adds an <see cref="Argument" />.
        /// </summary>
        /// <typeparam name="TTarget">The type of the argument action target.</typeparam>
        /// <param name="arguments">The <see cref="Arguments" /></param>
        /// <param name="action">The action.</param>
        /// <param name="target">The target.</param>
        /// <returns>Argument.</returns>
        public static Argument AddArgument<TTarget>(this Arguments arguments, Action<TTarget, string> action, TTarget target)
        {
            var argument = new Argument(arguments)
            {
                Action = (t, p) => action(target, p),
                Target = target
            };
            arguments.Add(argument);
            return argument;
        }

        /// <summary>
        /// Adds an <see cref="Argument" />.
        /// </summary>
        /// <param name="arguments">The <see cref="Arguments" /></param>
        /// <param name="action">The action.</param>
        /// <returns>Argument.</returns>
        public static Argument AddArgument(this Arguments arguments, Action<string> action)
        {
            var argument = new Argument(arguments) { Action = (t, p) => action(p) };
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
            var argument = new Argument(arguments) { Flags = flags };
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

        ///// <summary>
        ///// Adds an <see cref="Argument" />.
        ///// </summary>
        ///// <param name="argument">The <see cref="Argument" /></param>
        ///// <param name="action"></param>
        ///// <returns></returns>
        //public static Argument AddArgument(this Argument argument, Action<string> action)
        //{
        //    return argument.Arguments.AddArgument(action);
        //}

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
        public static IEnumerable<IArgument> Process(this Argument argument)
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
        /// <param name="separator">The separator character.</param>
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
        /// <typeparam name="TTarget">The type of the argument action target.</typeparam>
        /// <param name="argument">The <see cref="Argument" /></param>
        /// <param name="action">The action to execute.</param>
        /// <param name="target">The target.</param>
        /// <returns>Argument.</returns>
        public static Argument WithAction<TTarget>(this Argument argument, Action<TTarget, string> action, TTarget target)
        {
            argument.Action = (t, p) => action(target, p);
            argument.Target = target;
            return argument;
        }

        /// <summary>
        /// Sets the action of the current <see cref="Argument" />.
        /// </summary>
        /// <param name="argument">The <see cref="Argument" /></param>
        /// <param name="action">The action to execute.</param>
        /// <returns>Argument.</returns>
        public static Argument WithAction(this Argument argument, Action<string> action)
        {
            argument.Action = (t, p) => action(p);
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