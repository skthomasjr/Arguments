using System;

namespace CommandArguments
{
    /// <summary>
    /// An individual argument.
    /// </summary>
    public class Argument
    {
        /// <summary>
        /// Initializes a new instance of the<see cref="Argument" /> class.
        /// </summary>
        /// <param name="arguments">The set of arguments from which the argument originated.</param>
        /// <param name="action">The action to perform if the argument is encountered.</param>
        public Argument(Arguments arguments, Action<string> action)
        {
            Arguments = arguments;
            Action = action;
        }

        /// <summary>
        /// The action to perform when the argument is specified.
        /// </summary>
        public Action<string> Action { get; set; }

        /// <summary>
        /// The set of arguments from which the argument originated.
        /// </summary>
        public Arguments Arguments { get; set; }

        /// <summary>
        /// Determines if additional arguments should be processed if this argument is encountered and executed.
        /// </summary>
        public bool ContinueAfterExecution { get; set; }

        /// <summary>
        /// The possible flags used to denote the argument.
        /// </summary>
        public string[] Flags { get; set; }
    }
}