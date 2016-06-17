using System;

namespace Arguments
{
    /// <summary>
    /// An individual argument.
    /// </summary>
    public class Argument : IArgument
    {
        /// <summary>
        /// Initializes a new instance of the<see cref="Argument" /> class.
        /// </summary>
        /// <param name="arguments">The set of arguments from which the argument originated.</param>
        public Argument(Arguments arguments)
        {
            Arguments = arguments;
        }

        /// <summary>
        /// The action to perform when the argument is specified.
        /// </summary>
        public Action<object, string> Action { get; set; }

        /// <summary>
        /// The set of arguments from which the argument originated.
        /// </summary>
        public Arguments Arguments { get; set; }

        /// <summary>
        /// The possible flags used to denote the argument.
        /// </summary>
        public string[] Flags { get; set; }

        /// <summary>
        /// Gets or sets the argument action target.
        /// </summary>
        /// <value>The target.</value>
        public object Target { get; set; }

        /// <summary>
        /// Determines if additional arguments should be processed if this argument is encountered and executed.
        /// </summary>
        public bool TerminateAfterExecution { get; set; }
    }
}