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
            string path = Environment.CurrentDirectory;

            int exitCode = ListDirectory(path);

            return exitCode == 0;
        }

        private int ListDirectory(string? path)
        {
            try
            {
                string[] directoriesFound = Directory.GetDirectories(path);
                string[] filesFound = Directory.GetFiles(path);

                foreach (string dir in directoriesFound)
                {
                    ColorWrite.WriteColored(ConsoleColor.Blue, $"(dir) {dir}");
                }
                foreach (string file in filesFound)
                {
                    Console.WriteLine($"(file) {file}");
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
