using CLIExplorer.Commands;
using CLIExplorer.Utils;
using System;
using System.Text;

namespace CLIExplorer
{
    public static class VariableExpansionParser
    {
        private static string variableExpansionToken = "${";

        public static string Parse(string userCommand)
        {
            bool containsVariable;

            while ((containsVariable = userCommand.Contains(variableExpansionToken)))
            {
                int tokenIndex = userCommand.IndexOf(variableExpansionToken);

                StringBuilder command = new StringBuilder();

                for (int i = tokenIndex + 2; i < userCommand.Length; i++)
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
                            return userCommand;
                        }
                    }
                }
            }
            return userCommand;
        }
    }
}
