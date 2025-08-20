using CLIExplorer.Commands.CommandsBaseInterface;
using CLIExplorer.Utils;
using System;
using System.IO;

namespace CLIExplorer.Commands
{
    public class RmdirCommand : ICommand
    {
        public static string CommandPrefix => "rmdir";

        public bool Run(string userCommand)
        {
            string path = CommandHandler.ParseCommandContent(CommandPrefix, userCommand);

            int exitCode = RemoveDirectory(path);

            return exitCode == 0;
        }

        private int RemoveDirectory(string path)
        {
            try
            {
                Directory.Delete(path);

                return 0;
            }

            catch (DirectoryNotFoundException)
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: Directory not found.");

                return 1;
            }
        }
    }
}
