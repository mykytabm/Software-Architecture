using System;
using GXPEngine;
using Hobgoblin.Interfaces;
namespace Hobgoblin.Utils
{
    public class KeyCommand
    {
        public readonly ICommand command;
        public readonly Key key;

        public KeyCommand(Key pKey, ICommand pCommand)
        {
            key = pKey;
            command = pCommand;
        }
    }
}
