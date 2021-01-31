using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                try
                {
                    string result = commandInterpreter.Read(input);
                    Console.WriteLine(result);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
              
            }
        }
    }
}
