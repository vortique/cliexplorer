using CLIExplorer.Commands.CommandsBaseInterface;
using System;

namespace CLIExplorer.Commands
{
    internal class EchoCommand : ICommand
    {
        public static string CommandPrefix => "echo";

        public bool Run(string userCommand)
        {
            int exitCode = WriteStringToConsole(userCommand);

            return exitCode == 0;
        }

        private int WriteStringToConsole(string message)
        {
            Console.WriteLine(message); // prints commands content

            return 0;
        }
    }
}
