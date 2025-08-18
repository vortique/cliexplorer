using CLIExplorer.Commands.CommandsBaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIExplorer.Commands
{
    public class CdCommand : ICommand
    {
        public static string CommandPrefix => "cd";

        public bool Run(string?)
    }
}
