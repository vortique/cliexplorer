using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CLIExplorer
{
    public class LsCommand : ICommand
    {
        public static string CommandPrefix => "ls";

        public bool Run(string? path)
        {
            int exitCode = ListDirectory(path);

            return exitCode == 0 ;
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
