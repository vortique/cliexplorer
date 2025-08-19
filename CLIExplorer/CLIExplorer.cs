using CLIExplorer.Commands;
using CLIExplorer.Utils;
using System;
using System.IO;

namespace CLIExplorer
{
    public class CLIExplorer
    {
        public static bool exitInitialized = false;

        static void Main(string[] args)
        {
            AppInfo.GreetingMessage();

            try
            {
                string welcomeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); // getting User's home directory

                Environment.CurrentDirectory = welcomeDirectory;

                Initializer.InitCommands();

                while (true)
                {
                    if (exitInitialized)
                    {
                        Environment.Exit(0);
                    }

                    Console.Write($"({Environment.CurrentDirectory}) $ ");

                    string userCommand = Console.ReadLine();

                    CommandHandler.HandleCommand(userCommand);
                }
            }
            catch (PlatformNotSupportedException)
            {
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine($"ERROR: Your OS is not supports CSharp's Environment.GetFolderPath() method. " +
                    $"Please try using Windows for {AppInfo.Name}.");
                Environment.Exit(1);
            }
        }
    }
}
