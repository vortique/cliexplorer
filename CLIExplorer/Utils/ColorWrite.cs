using System;

namespace CLIExplorer.Utils
{
    public static class ColorWrite
    {
        public static void WriteColored(ConsoleColor color, params string[] messages)
        {
            Console.ForegroundColor = color;

            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }

            Console.ResetColor();
        }
    }
}
