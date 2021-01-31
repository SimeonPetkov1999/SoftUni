using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Models.Commands
{
    class SayHelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"My name is {args[0]}";
        }
    }
}
