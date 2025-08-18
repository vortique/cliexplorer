using CLIExplorer.Commands.CommandsBaseInterface;
using System;

namespace CLIExplorer.Commands
{
    internal class EchoCommand : ICommand
    {
        public static string CommandPrefix => "echo";

        public bool Run(string userCommand)
        {
            string message = CommandHandler.ParseCommandContent(CommandPrefix, userCommand);

            int exitCode = WriteStringToConsole(message);

            return exitCode == 0;
        }

        private int WriteStringToConsole(string message)
        {
            Console.WriteLine(message);

            return 0;
        }
    }
}
