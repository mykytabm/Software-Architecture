using System;
using Hobgoblin.Interfaces;
namespace Hobgoblin.Commands
{
    public class TestCommand : ICommand
    {
        public TestCommand()
        {
        }

        public void Execute()
        {
            Console.WriteLine("Test command got called!");
        }
    }
}
