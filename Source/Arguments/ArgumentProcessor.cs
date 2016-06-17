using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Arguments
{
    /// <summary>
    /// Processes the arguments.
    /// </summary>
    public class ArgumentProcessor
    {
        private readonly IEnumerable<IArgument> arguments;
        private readonly ICollection<IArgument> processedArguments = new List<IArgument>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentProcessor" /> class.
        /// </summary>
        /// <param name="source">The source arguments.</param>
        /// <param name="arguments">Arguments to process.</param>
        public ArgumentProcessor(string[] source, IEnumerable<IArgument> arguments) : this()
        {
            Source = source;
            this.arguments = arguments;
        }

        /// <summary>
        /// Initializes a new instance of the<see cref="ArgumentProcessor" /> class.
        /// </summary>
        /// <param name="source">The source arguments.</param>
        public ArgumentProcessor(string[] source) : this()
        {
            Source = source;
        }

        /// <summary>
        /// Initializes a new instance of the<see cref="ArgumentProcessor" /> class.
        /// </summary>
        public ArgumentProcessor() { }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        public List<IArgument> Arguments { get; } = new List<IArgument>();

        /// <summary>
        /// The source arguments.
        /// </summary>
        public string[] Source { get; set; }

        /// <summary>
        /// The strings separating the arguments.
        /// </summary>
        public string[] ArgumentSeparators { get; set; } = {"-", "--", "/", "//"};

        /// <summary>
        /// The character that separates the flag from the parameter.
        /// </summary>
        public char ParameterSeparator { get; set; } = ':';

        /// <summary>
        /// Executes the action on each of the arguments encountered.
        /// </summary>
        /// <returns>The processed arguments.</returns>
        public IEnumerable<IArgument> Process()
        {
            Arguments.AddRange(arguments);

            foreach (var sourceArgument in Source)
            {
                var command = sourceArgument.Trim().TrimStart('/', '-');
                var flag = command.Split(ParameterSeparator)[0];
                var parameter = command.Split(ParameterSeparator).Length > 1 ? command.Split(ParameterSeparator)[1] : string.Empty;
                var argument = Arguments.FirstOrDefault(f => f.Flags.Contains(flag));
                if (argument != null)
                {
                    argument.Action.Invoke(argument.Target, parameter);
                    processedArguments.Add(argument);
                    if (argument.TerminateAfterExecution) break;
                }
            }
            return processedArguments;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ArgumentProcessor" /> class with the specified source arguments and injected arguments.
        /// </summary>
        /// <param name="source">The source arguments.</param>
        /// <param name="arguments">Arguments to inject.</param>
        /// <returns>The arguments with the specified source arguments and injected arguments.</returns>
        public static ArgumentProcessor Initialize(string[] source, IEnumerable<IArgument> arguments)
        {
            return new ArgumentProcessor(source, arguments);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentProcessor" /> class with the specified source arguments.
        /// </summary>
        /// <param name="source">The source arguments.</param>
        /// <returns>The arguments with the specified source arguments.</returns>
        public static ArgumentProcessor Initialize(string[] source)
        {
            return new ArgumentProcessor(source);
        }
    }
}