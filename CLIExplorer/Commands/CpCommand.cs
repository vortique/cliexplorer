using CLIExplorer.Commands.CommandsBaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIExplorer.Commands
{
    public class CpCommand : ICommand
    {
        public static string CommandPrefix => "cp";

        public bool Run(string userCommand)
        {
            return true;
        }
    }
}
