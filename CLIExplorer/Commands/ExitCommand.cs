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
                try
                {
                    Environment.Exit(exitCode);

                    return true;
                }
                catch (SecurityException)
                {
                    ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: No permission to exit from program with code. Try: Ctrl + C");

                    return false;
                }
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
