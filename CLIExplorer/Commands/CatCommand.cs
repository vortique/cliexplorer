using CLIExplorer.Commands.CommandsBaseInterface;
using CLIExplorer.Utils;
using System;
using System.IO;
using System.Text;


namespace CLIExplorer.Commands
{
    public class CatCommand : ICommand
    {
        public static string CommandPrefix => "cat";

        public bool Run(string userCommand)
        {
            string path = CommandHandler.ParseCommandContent(CommandPrefix, userCommand);

            int exitCode = WriteFile(path);

            return exitCode == 0;
        }

        public int WriteFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: No paths entered.");

                return 1;
            }

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }

                return 0;
            }
            catch (FileNotFoundException)
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: File not found.");

                return 1;
            }
            catch (UnauthorizedAccessException)
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: No permissiıon to read the file.");

                return 1;
            }
        }
    }
}
