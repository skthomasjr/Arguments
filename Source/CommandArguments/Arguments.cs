using System.Collections.Generic;
using System.Linq;

namespace CommandArguments
{
    /// <summary>
    /// All the arguments.
    /// </summary>
    public class Arguments : List<Argument>
    {
        /// <summary>
        /// The source arguments.
        /// </summary>
        public string[] Source { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Executions { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string[] ArgumentSeparators { get; set; }

        /// <summary>
        /// The character that seperates the flag from the parameter.
        /// </summary>
        public char ParameterSeparator { get; set; } = ':';

        /// <summary>
        /// Executes the action on each of the arguments encountered.
        /// </summary>
        /// <returns></returns>
        public Arguments Process()
        {
            foreach (var sourceArgument in Source)
            {
                var command = sourceArgument.Trim().TrimStart('/', '-');
                var flag = command.Split(ParameterSeparator)[0];
                var parameter = command.Split(ParameterSeparator).Length > 1 ? command.Split(ParameterSeparator)[1] : string.Empty;
                var argument = this.FirstOrDefault(f => f.Flags.Contains(flag));
                if (argument != null)
                {
                    argument.Action.Invoke((string)parameter);
                    Executions++;
                    if (!argument.ContinueAfterExecution) break;
                }
            }
            return this;
        }
    }
}