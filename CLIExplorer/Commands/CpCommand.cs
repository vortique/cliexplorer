using CLIExplorer.Commands.CommandsBaseInterface;
using CLIExplorer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIExplorer.Commands
{
    public class CpCommand : ICommand
    {
        public static string CommandPrefix => "cp";

        public bool Run(string userCommand)
        {
            string path = CommandHandler.ParseCommandContent(CommandPrefix, userCommand);

            int exitCode = Copy(path);

            return exitCode == 0;
        }

        private int Copy(string commandContent)
        {
            if (string.IsNullOrWhiteSpace(commandContent))
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: No paths entered.");

                return 1;
            }

            string[] paths = commandContent.Split(' ');

            char path0Type = File.GetAttributes(paths[0]).HasFlag(FileAttributes.Directory) ? 'd' : 'f';

            try
            {
                if (path0Type == 'f')
                {
                    if (Directory.Exists(paths[1]))
                    {
                        File.Copy(paths[0], Path.Join(paths[1], Path.GetFileName(paths[0])));

                        return 0;
                    }

                    File.Copy(paths[0], paths[1]);

                    return 0;
                }
                else
                {
                    if (Directory.Exists(paths[1]))
                    {
                        CopyDirectory(paths[0], Path.Join(paths[1], Path.GetFileName(paths[0])));

                        return 0;
                    }

                    CopyDirectory(paths[0], paths[1]);

                    return 0;
                }
            }
            catch (FileNotFoundException)
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: No files found.");

                return 1;
            }
            catch (DirectoryNotFoundException)
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: No directories found.");

                return 1;
            }
        }

        private void CopyDirectory(string sourceDir, string destinationDir)
        {
            Directory.CreateDirectory(destinationDir); // Creates destination directory if there isn't.

            foreach (string file in Directory.GetFiles(sourceDir)) // Copy every files in source directory. 
            {
                // Get file name from its absolute path, combine it with destination path to get new files absolute path

                string targetFilePath = Path.Combine(destinationDir, Path.GetFileName(file));

                // Copy file to destination directory with same name.

                File.Copy(file, targetFilePath, overwrite: true);
            }

            foreach (string directory in Directory.GetDirectories(sourceDir))
            {
                string targetDirectoryPath = Path.Combine(destinationDir, Path.GetFileName(directory));
                CopyDirectory(directory, targetDirectoryPath); // recursively copy every sub-dirs to destination.
            }
        }
    }
}
