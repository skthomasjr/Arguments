using System;
using System.ComponentModel.Composition;

namespace CommandArguments
{
    /// <summary>
    /// Interface for an individual argument.
    /// </summary>
    [InheritedExport]
    public interface IArgument
    {
        /// <summary>
        /// The action to perform when the argument is specified.
        /// </summary>
        Action<string> Action { get; set; }

        /// <summary>
        /// The possible flags used to denote the argument.
        /// </summary>
        string[] Flags { get; set; }

        /// <summary>
        /// Determines if additional arguments should be processed if this argument is encountered and executed.
        /// </summary>
        bool TerminateAfterExecution { get; set; }
    }
}