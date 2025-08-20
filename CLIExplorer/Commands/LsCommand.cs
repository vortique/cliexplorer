using CLIExplorer.Commands.CommandsBaseInterface;
using CLIExplorer.Utils;
using System;
using System.IO;

namespace CLIExplorer.Commands
{
    public class LsCommand : ICommand
    {
        public static string CommandPrefix => "ls";

        public bool Run(string userCommand)
        {
            string path = CommandHandler.ParseCommandContent(CommandPrefix, userCommand);

            int exitCode = ListDirectory(path);

            int exitCode = ListDirectory(path);

            return exitCode == 0;
        }

        private int ListDirectory(string? path)
        {
            try
            {
                string[] directoriesFound = Directory.GetDirectories(path); // Array of every sub-directory in current directory
                string[] filesFound = Directory.GetFiles(path); // Array of every file in current directory

                foreach (string dir in directoriesFound)
                {
                    string directoryName = dir.Replace($"{path}\\", ""); // replaces CWD\ with empty string 
                                                                         // to get every sub-dir's name

                    ColorWrite.WriteColored(ConsoleColor.Blue, $"(dir) {directoryName}\\");
                }
                foreach (string file in filesFound)
                {
                    string fileName = file.Replace($"{path}\\", ""); // replaces CWD\ with empty string 
                                                                     // to get every files name

                    Console.WriteLine($"(file) {fileName}");
                }

                return 0;
            }
            catch (DirectoryNotFoundException)
            {
                ColorWrite.WriteColored(ConsoleColor.Red, $"ERROR: Directory named '{path}' not found.");
                return 1;
            }
            catch (FileNotFoundException)
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: File not found.");
                return 1;
            }
            catch (UnauthorizedAccessException)
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: Access permission error.");
                return 1;
            }
            catch (PathTooLongException)
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: Path too long.");
                return 1;
            }
            catch (ArgumentNullException)
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: No paths found.");
                return 1;
            }
        }
    }
}
