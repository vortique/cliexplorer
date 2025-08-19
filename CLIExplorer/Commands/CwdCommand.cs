using CLIExplorer.Commands.CommandsBaseInterface;
using CLIExplorer.Utils;
using System;
using System.IO;

namespace CLIExplorer.Commands
{
    public class CwdCommand : ICommand
    {
        public static string CommandPrefix => "cwd";

        public bool Run(string userCommand)
        {
            int exitCode = WriteCurrentWorkingDirectory();

            return exitCode == 0;
        }

        public static string ReturnCurrentWorkingDirectory()
        {
            return Environment.CurrentDirectory; // returns CWD
        }

        private int WriteCurrentWorkingDirectory()
        {
            ColorWrite.WriteColored(ConsoleColor.Blue, Environment.CurrentDirectory); // prints CWD

            return 0;
        }
    }
}
