using System;
using Hobgoblin.Interfaces;
using UnityEngine;
namespace Hobgoblin.Utils
{
    public class KeyCommand
    {
        public readonly ICommand command;
        public readonly KeyCode key;

        public KeyCommand(KeyCode pKey, ICommand pCommand)
        {
            key = pKey;
            command = pCommand;
        }
    }
}
