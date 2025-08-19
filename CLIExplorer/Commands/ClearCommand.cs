using CLIExplorer.Commands.CommandsBaseInterface;
using System;
using System.IO;

namespace CLIExplorer.Commands
{
    public class ClearCommand : ICommand
    {
        public static string CommandPrefix => "clear";

        public bool Run(string userCommand)
        {
            Console.Clear();

            return true;
        }
    }
}
