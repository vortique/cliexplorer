using System;

namespace CLIExplorer.Utils
{
    public static class ColorWrite
    {
        public static void WriteColored(ConsoleColor color, params string[] messages)
        {
            Console.ForegroundColor = color; // Change font color

            foreach (string message in messages)
            {
                Console.WriteLine(message); // Print messages
            }

            Console.ResetColor(); // Reset font color
        }
    }
}
