using CLIExplorer.Commands.CommandsBaseInterface;
using CLIExplorer.Utils;
using System;
using System.Text;

namespace CLIExplorer.Commands
{
    public static class CommandHandler
    {
        public static Dictionary<string, Func<ICommand>> avaibleCommands = new();

        public static void HandleCommand(string userCommand)
        {
            userCommand = VariableExpansionParser.Parse(userCommand);
            string prefix = ParseCommandPrefix(userCommand);

            if (avaibleCommands.ContainsKey(prefix))
            {
                var commandObject = avaibleCommands[prefix]();

                if (!commandObject.Run(userCommand))
                {
                    ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: Error occured in previous command.");
                }
            }
            else
            {
                ColorWrite.WriteColored(ConsoleColor.Red, $"ERROR: No commands found named '{userCommand}'.");
            }
        }

        public static string ParseCommandContent(string prefix, string command)
        {
            string parsedCommand = command.Replace($"{prefix}", "").Trim();

            return parsedCommand;
        }

        private static string ParseCommandPrefix(string userCommand)
        {
            StringBuilder command = new StringBuilder();

            foreach (char character in userCommand)
            {
                if (character != ' ')
                {
                    command.Append(character);
                }
                else
                {
                    return command.ToString();
                }
            }

            return command.ToString();
        } 
    }
}
