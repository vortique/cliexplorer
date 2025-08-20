using CLIExplorer.Commands;
using System;
using System.Linq;

namespace CLIExplorer
{
    public static class Initializer
    {
        public static void InitCommands()
        {
            // add commands prefix with how to create them in lambda.

            CommandHandler.avaibleCommands.Add(LsCommand.CommandPrefix, () => new LsCommand());
            CommandHandler.avaibleCommands.Add(CwdCommand.CommandPrefix, () => new CwdCommand());
            CommandHandler.avaibleCommands.Add(ExitCommand.CommandPrefix, () => new ExitCommand());
            CommandHandler.avaibleCommands.Add(EchoCommand.CommandPrefix, () => new EchoCommand());
            CommandHandler.avaibleCommands.Add(CdCommand.CommandPrefix, () => new CdCommand());
            CommandHandler.avaibleCommands.Add(ClearCommand.CommandPrefix, () => new ClearCommand());
            CommandHandler.avaibleCommands.Add(MvCommand.CommandPrefix, () => new MvCommand());
            CommandHandler.avaibleCommands.Add(MkdirCommand.CommandPrefix, () => new MkdirCommand());
            CommandHandler.avaibleCommands.Add(RmdirCommand.CommandPrefix, () => new RmdirCommand());

            // add commands prefix with how to create them in lambda.

            var avaiblePrefixs = CommandHandler.avaibleCommands.Keys;

            foreach (var prefix in avaiblePrefixs)
            {
                if (avaiblePrefixs.Count(p => p == prefix) > 1) // looks for if there more occurances of that prefix more than 1.
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"WARNING: There is multiple prefix occurances for {prefix}. " +
                        $"Most likely, only the command with the same prefix that was initialized first will run. " +
                        $"If you have modified the code, please take this warning into consideration.");
                    Console.ResetColor();
                }
            }
        } 
    }
}
