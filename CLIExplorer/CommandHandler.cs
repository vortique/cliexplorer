using System;
using System.Text;

namespace CLIExplorer
{
    public static class CommandHandler
    {
        public static Dictionary<string, Func<ICommand>> avaibleCommands = new();

        public static void HandleCommand(string userCommand)
        {
            if (avaibleCommands.ContainsKey(userCommand))
            {
                var commandObject = avaibleCommands[userCommand]();

                if (!commandObject.Run(Environment.CurrentDirectory))
                {
                    ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: Error occured in previous command.");
                }
            }
            else
            {
                ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: No commands found.");
            }
        }
    }
}
