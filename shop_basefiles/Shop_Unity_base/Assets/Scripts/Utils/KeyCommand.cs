using System;
using Hobgoblin.Interfaces;
namespace Hobgoblin.Utils
{
    public class KeyCommand
    {
        public readonly ICommand command;
        public readonly int key;

        public KeyCommand(int pKey, ICommand pCommand)
        {
            key = pKey;
            command = pCommand;
        }
    }
}
