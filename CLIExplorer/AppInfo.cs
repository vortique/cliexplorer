using System;

namespace CLIExplorer
{
    public static class AppInfo
    {
        public const string Name = "CLIExplorer";
        public const string Version = "1.0.0";
        public static readonly string[] Authors = { "vortique" };
        public const string License = "GPL v3.0";

        public static void GreetingMessage()
        {
            Console.Write("Welcome to the ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{AppInfo.Name}!");
            Console.ResetColor();
            Console.Write($"\nThis project is licensed under {AppInfo.License}. Please behave know what you have and what you don't have.");
            Console.WriteLine();
        }
    }
}
