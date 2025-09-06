using CLIExplorer.Commands.CommandsBaseInterface;
using CLIExplorer.Utils;
using System;
using System.IO;

namespace CLIExplorer.Commands
{
    public class GrepCommand : ICommand
    {
        public static string CommandPrefix => "grep";

        public bool Run(string userCommand)
        {
            string commandContent = CommandHandler.ParseCommandContent(CommandPrefix, userCommand);

            int exitCode = FindText(commandContent);

            return exitCode == 0;
        }

        public int FindText(string commandContent)
        {
            if (string.IsNullOrEmpty(commandContent))
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: Please enter path and options if wanted.");

                return 1;
            }

            string[] args = commandContent.Split(' ');

            string filePath = args[0] == "-i" ? args[1] : args[0];
            bool ignoreCase = args[0] == "-i";
            string targetString = args[0] == "-i" ? args[2] : args[1];

            if (ignoreCase)
            {
                targetString = targetString.ToLower();
            }

            try
            {
                if (!File.Exists(filePath))
                {
                    string line;

                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        for (int i = 1; (line = sr.ReadLine()) != null; i++)
                        {
                            WriteFoundLines(line, targetString, i, ignoreCase);
                        }
                    }

                    return 0;
                }
                else
                {
                    ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: Given path is not a file or not exists");

                    return 1;
                }
            }
            catch (FileNotFoundException)
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: File not found.");

                return 1;
            }
            catch (IOException)
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: Something went wrong.");

                return 1;
            }
        }
        private static void WriteFoundLines(String line, String targetString, int lineIndex, bool ignoreCase)
        {
            if (ignoreCase)
            {
                String lineLower = line.ToLower();
                bool found = lineLower.Contains(targetString);

                if (found)
                {
                    Console.WriteLine($" {lineIndex} | {line}");
                }
            }
            else
            {
                bool found = line.Contains(targetString);

                if (found)
                {
                    Console.WriteLine($" {lineIndex} | {line}");
                }
            }
        }
    }
}
