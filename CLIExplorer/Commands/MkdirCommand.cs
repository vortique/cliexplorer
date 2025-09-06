using CLIExplorer.Commands.CommandsBaseInterface;
using CLIExplorer.Utils;
using System;
using System.IO;

namespace CLIExplorer.Commands
{
    public class MkdirCommand : ICommand
    {
        public static string CommandPrefix => "mkdir";

        public bool Run(string userCommand)
        {
            string path = CommandHandler.ParseCommandContent(CommandPrefix, userCommand);

            int exitCode = MakeDirectory(path);

            return exitCode == 0;
        }

        private int MakeDirectory(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: No paths entered.");

                return 1;
            }

            try
            {
                Directory.CreateDirectory(path);

                return 0;
            }
            catch (DirectoryNotFoundException)
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: Directory not found.");

                return 1;
            }
            catch (UnauthorizedAccessException)
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: No permission to create a directory.");

                return 1;
            }
        }
    }
}
