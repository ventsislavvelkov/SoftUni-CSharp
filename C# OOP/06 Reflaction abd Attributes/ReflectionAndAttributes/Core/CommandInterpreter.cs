using System;
using CommandPattern.Core.Contracts;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_ADDITION = "Command";
        public string Read(string args)
        {
            var commandTokens = args.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var commandName = commandTokens[0] + COMMAND_ADDITION;
            var commandArgs = commandTokens.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type commandType = assembly.GetTypes().FirstOrDefault(x => x.Name.ToLower() == commandName.ToLower());

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);

            string result = commandInstance.Execute(commandArgs);

            return result;
        }
    }
}
