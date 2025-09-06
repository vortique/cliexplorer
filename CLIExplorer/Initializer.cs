using CLIExplorer.Commands;
using CLIExplorer.Utils;
using System;
using System.Linq;

namespace CLIExplorer
{
    public static class Initializer
    {
        public static void InitCommands()
        {
            try
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
                CommandHandler.avaibleCommands.Add(CpCommand.CommandPrefix, () => new CpCommand());
                CommandHandler.avaibleCommands.Add(GrepCommand.CommandPrefix, () => new GrepCommand());
                CommandHandler.avaibleCommands.Add(CatCommand.CommandPrefix, () => new CatCommand());

                // add commands prefix with how to create them in lambda.
            }
            catch (ArgumentException)
            {
                ColorWrite.WriteColored(ConsoleColor.Yellow, $"WARNING: There is some multiple prefix occurances. " +
                        $"Most likely, only the command with the same prefix that was initialized first will run. " +
                        $"If you have modified the code, please take this warning into consideration.");
            }
        } 
    }
}