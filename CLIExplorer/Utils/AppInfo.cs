using System;

namespace CLIExplorer.Utils
{
    public static class AppInfo
    {
        public const string Name = "CLIExplorer"; // Project name
        public const string Version = "1.2.0"; // Project version
        public static readonly string[] Authors = { "vortique" }; // Project author(s)
        public const string License = "GPL v3.0"; // Project license

        public static void GreetingMessage() // Greeting message for CLIExplorer.cs
        {
            Console.Write("Welcome to the ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{Name}!");
            Console.ResetColor();
            Console.Write($"\nThis project is licensed under {License}. Please behave knowing what you have and what you don't have.");
            Console.WriteLine();
        }
    }
}
