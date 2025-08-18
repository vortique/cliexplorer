using System;

namespace CLIExplorer.Commands.CommandsBaseInterface
{
    public interface ICommand
    {
        public static string? CommandPrefix { get; } // nullable, but not prefered.
        public bool Run(string userCommand);
    }
}
