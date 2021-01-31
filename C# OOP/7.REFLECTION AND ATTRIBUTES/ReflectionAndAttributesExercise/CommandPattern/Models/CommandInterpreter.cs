using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var command = args
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var commandName = command[0] + "Command";
            var comandArgs = command
                .Skip(1)
                .ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type type = null;
            try
            {
                type = assembly.GetTypes().First(t => t.Name.ToLower() == commandName.ToLower());
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid Command");
            }
            ICommand activator = (ICommand)Activator.CreateInstance(type);

            return activator.Execute(comandArgs);


        }
    }
}
