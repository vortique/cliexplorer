using CLIExplorer.Utils;
using System;
using System.Text;

namespace CLIExplorer.Commands
{
    public static class VariableExpansionParser
    {
        private static string variableExpansionToken = "${";

        public static string Parse(string userCommand)
        {
            bool containsVariable;

            while ((containsVariable = userCommand.Contains(variableExpansionToken)))
            {
                int tokenIndex = userCommand.IndexOf('$') + 1;

                StringBuilder command = new StringBuilder();

                for (int i = tokenIndex + 1; i < userCommand.Length; i++)
                {
                    if (userCommand[i] != '}')
                    {
                        command.Append(userCommand[i]);
                    }
                    else
                    {
                        string commandString = command.ToString();

                        if (commandString == CwdCommand.CommandPrefix)
                        {
                            string returnedValue = CwdCommand.ReturnCurrentWorkingDirectory();

                            userCommand = userCommand.Replace($"{variableExpansionToken}{commandString}" + "}", returnedValue);

                            continue;
                        }
                        else
                        {
                            ColorWrite.WriteColored(ConsoleColor.Red, "ERROR: Unrecognized variable expansion command.");

                            return userCommand;
                        }
                    }
                }
            }
            return userCommand;
        }
    }
}
