using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Models.Commands
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return string.Format("Hello, {0}", args[0]);
        }
    }
}
