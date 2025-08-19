using CLIExplorer.Commands.CommandsBaseInterface;
using CLIExplorer.Utils;
using System;
using System.Security;

namespace CLIExplorer.Commands
{
    internal class ExitCommand : ICommand
    {
        public static string? CommandPrefix => "exit";

        public bool Run(string userCommand)
        {
            int exitCode = ExitFromProgram();

            if (exitCode == 0)
            {
                CLIExplorer.exitInitialized = true;

                return true;
            }
            else
            {
                return false;
            }
        }

        private int ExitFromProgram()
        {
            ColorWrite.WriteColored(ConsoleColor.Green, "Bye!");

            return 0;
        }
    }
}
