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
        /// <param name="argumentProcessor">The <see cref="ArgumentProcessor" /></param>
        /// <param name="action">The action.</param>
        /// <param name="target">The target.</param>
        /// <returns>Argument.</returns>
        public static Argument AddArgument<TTarget>(this ArgumentProcessor argumentProcessor, Action<TTarget, string> action, TTarget target)
        {
            var argument = new Argument(argumentProcessor)
            {
                Action = (t, p) => action(target, p),
                Target = target
            };
            argumentProcessor.Arguments.Add(argument);
            return argument;
        }

        /// <summary>
        /// Adds an <see cref="Argument" />.
        /// </summary>
        /// <param name="argumentProcessor">The <see cref="ArgumentProcessor" /></param>
        /// <param name="action">The action.</param>
        /// <returns>Argument.</returns>
        public static Argument AddArgument(this ArgumentProcessor argumentProcessor, Action<string> action)
        {
            var argument = new Argument(argumentProcessor) { Action = (t, p) => action(p) };
            argumentProcessor.Arguments.Add(argument);
            return argument;
        }

        /// <summary>
        /// Adds an <see cref="Argument" />.
        /// </summary>
        /// <param name="argumentProcessor">The <see cref="ArgumentProcessor" /></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static Argument AddArgument(this ArgumentProcessor argumentProcessor, params string[] flags)
        {
            var argument = new Argument(argumentProcessor) { Flags = flags };
            argumentProcessor.Arguments.Add(argument);
            return argument;
        }

        /// <summary>
        /// Adds an <see cref="Argument" />.
        /// </summary>
        /// <param name="argumentProcessor">The <see cref="ArgumentProcessor" /></param>
        /// <returns></returns>
        public static Argument AddArgument(this ArgumentProcessor argumentProcessor)
        {
            var argument = new Argument(argumentProcessor);
            argumentProcessor.Arguments.Add(argument);
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
        /// Process the <see cref="ArgumentProcessor" />.
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
        /// Uses the argument separators with the current <see cref="ArgumentProcessor" />.
        /// </summary>
        /// <param name="argumentProcessor">The <see cref="ArgumentProcessor" /></param>
        /// <param name="separators">The argument separators.</param>
        /// <returns></returns>
        public static ArgumentProcessor UsingArgumentSeparators(this ArgumentProcessor argumentProcessor, params string[] separators)
        {
            argumentProcessor.ArgumentSeparators = separators;
            return argumentProcessor;
        }

        /// <summary>
        /// Uses the parameter separator with the current <see cref="ArgumentProcessor" />.
        /// </summary>
        /// <param name="argumentProcessor">The <see cref="ArgumentProcessor" /></param>
        /// <param name="separator">The separator character.</param>
        /// <returns></returns>
        public static ArgumentProcessor UsingParameterSeparator(this ArgumentProcessor argumentProcessor, char separator)
        {
            argumentProcessor.ParameterSeparator = separator;
            return argumentProcessor;
        }

        /// <summary>
        /// Uses the source parameters with the current <see cref="ArgumentProcessor" />.
        /// </summary>
        /// <param name="argumentProcessor">The <see cref="ArgumentProcessor" /></param>
        /// <param name="source">The source arguments.</param>
        /// <returns></returns>
        public static ArgumentProcessor UsingSource(this ArgumentProcessor argumentProcessor, params string[] source)
        {
            argumentProcessor.Source = source;
            return argumentProcessor;
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