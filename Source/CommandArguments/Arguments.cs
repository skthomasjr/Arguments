using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandArguments
{
    public class Arguments : List<Argument>
    {
        public string[] Source { get; set; }

        public int Executions { get; private set; }

        public string[] ArgumentSeparators { get; set; }

        public char ParameterSeparator { get; set; }

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