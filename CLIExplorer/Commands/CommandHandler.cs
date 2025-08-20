using CLIExplorer.Commands.CommandsBaseInterface;
using CLIExplorer.Utils;
using System;
using System.Text;

namespace CLIExplorer.Commands
{
    public static class CommandHandler
    {
        public static Dictionary<string, Func<ICommand>> avaibleCommands = new(); // create a dict for initializing commands in Initializer.cs

        public static void HandleCommand(string userCommand)
        {
            userCommand = VariableExpansionParser.Parse(userCommand);
            string prefix = ParseCommandPrefix(userCommand);

            if (avaibleCommands.ContainsKey(prefix)) // if commands prefix that user inputted exists...
            {
                var commandObject = avaibleCommands[prefix](); // ...create inputted commands object...

                if (!commandObject.Run(userCommand)) // ...and run the command.
                {
                    ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: Error occured in previous command.");
                }
            }
            else
            {
                ColorWrite.WriteColored(ConsoleColor.Red, $"ERROR: No commands found named '{prefix}'.");
            }
        }

        public static string ParseCommandContent(string prefix, string command)
        {
            if (command.StartsWith(prefix)) // if user command includes commands prefix...
            {
                return command.Substring(prefix.Length).Trim(); // ...delete the prefix, remove unwanted spaces and return it.
            }

            return command.Trim(); // or only delete unwanted spaces and return it.
        }

        private static string ParseCommandPrefix(string userCommand)
        {
            return userCommand.Split(' ', 2)[0]; // split user command with space and return the first element of array.
        } 
    }
}
