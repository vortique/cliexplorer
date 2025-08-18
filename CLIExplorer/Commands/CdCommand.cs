using CLIExplorer.Commands.CommandsBaseInterface;
using CLIExplorer.Utils;
using System;
using System.Text;

namespace CLIExplorer.Commands
{
    public class CdCommand : ICommand
    {
        public static string CommandPrefix => "cd";

        public bool Run(string userCommand)
        {
            string path = CommandHandler.ParseCommandContent(CommandPrefix, userCommand);

            int exitCode = ChangeDirectory(path);

            return exitCode == 0;
        }

        private int ChangeDirectory(string path)
        {
            string[] directoriesFound = Directory.GetDirectories(Environment.CurrentDirectory);

            for (int i = 0; i < directoriesFound.Length; i++)
            {
                directoriesFound[i] = directoriesFound[i].Replace($"{Environment.CurrentDirectory}\\", "");
            }

            if (directoriesFound.Contains(path))
            {
                string newDirectory = Path.Join(Environment.CurrentDirectory, path);

                Environment.CurrentDirectory = newDirectory;

                return 0;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(path))
                {
                    Environment.CurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                    return 0;
                }

                ColorWrite.WriteColored(ConsoleColor.Red, $"ERROR: Directory not found.");

                return 1;
            }
        }
    }
}
