using System;
using System.IO;

namespace CLIExplorer
{
    public class CLIExplorer
    {
        static void Main(string[] args)
        {
            AppInfo.GreetingMessage();

            try
            {
                string welcomeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                Environment.CurrentDirectory = welcomeDirectory;

                Initializer.InitCommands();

                while (true)
                {
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
