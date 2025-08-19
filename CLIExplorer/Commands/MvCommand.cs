using CLIExplorer.Commands.CommandsBaseInterface;
using CLIExplorer.Utils;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace CLIExplorer.Commands
{
    public class MvCommand : ICommand
    {
        public static string CommandPrefix => "mv";

        public bool Run(string userCommand)
        {
            string commandContent = CommandHandler.ParseCommandContent(CommandPrefix, userCommand);

            bool exitCode = MoveDirectoryOrFile(commandContent) == 0;

            return exitCode;
        }

        private int MoveDirectoryOrFile(string commandContent)
        {
            string[] paths = commandContent.Split(' ');

            try
            {
                char path0Type = File.GetAttributes(paths[0]).HasFlag(FileAttributes.Directory) ? 'd' : 'f'; // f = file, d = directory

                if (path0Type == 'f')
                {
                    if (Directory.Exists(paths[1]))
                    {

                        File.Move(paths[0], paths[1] + Path.GetFileName(paths[0]));
                        return 0;
                    }

                    File.Move(paths[0], paths[1]);

                    return 0;
                }
                return 1;
            }
            catch (FileNotFoundException)
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: File not found.");

                return 1;
            }
            catch (DirectoryNotFoundException)
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: Directory not found.");

                return 1;
            }
        }
    }
}
