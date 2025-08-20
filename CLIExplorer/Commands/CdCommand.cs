using CLIExplorer.Commands.CommandsBaseInterface;
using CLIExplorer.Utils;
using System;
using System.Text;

namespace CLIExplorer.Commands
{
    public class CdCommand : ICommand
    {
        public static string CommandPrefix = "cd";

        public bool Run(string userCommand)
        {
            string path = CommandHandler.ParseCommandContent(CommandPrefix, userCommand);

            int exitCode = ChangeDirectory(path);

            return exitCode == 0;
        }

        private int ChangeDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) // if no sub-dir name inputted...
            {
                Environment.CurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); // ...change CWD with user's home dir

                return 0;
            }

            string[] directoriesFound = Directory.GetDirectories(Environment.CurrentDirectory); // Array of every sub-directory in current directory

            for (int i = 0; i < directoriesFound.Length; i++)
            {
                directoriesFound[i] = directoriesFound[i].Replace($"{Environment.CurrentDirectory}\\", ""); // replaces CWD\ with empty string 
                                                                                                            // to get every sub-dir's name
            }

            if (directoriesFound.Contains(path)) // if inputted sub-dir is exists...
            {
                string newDirectory = Path.Join(Environment.CurrentDirectory, path); // ...join CWD and inputted sub-dir name to get absolute path

                Environment.CurrentDirectory = newDirectory; // change CWD

                return 0;
            }
            else
            {
                if (Directory.Exists(path))
                {
                    Environment.CurrentDirectory = path;

                    return 0;
                }

                ColorWrite.WriteColored(ConsoleColor.Red, $"ERROR: Directory not found.");

                return 1;
            }
        }
    }
}
