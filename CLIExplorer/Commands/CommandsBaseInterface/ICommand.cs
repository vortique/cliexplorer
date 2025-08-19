using System;

namespace CLIExplorer.Commands.CommandsBaseInterface
{
    public interface ICommand
    {
        public static string CommandPrefix { get; }
        public bool Run(string userCommand); // Universal running method.
                                             // If you want to add some commands to CommandHandler.avaibleCommands, you need to add this method too.
    }
}
