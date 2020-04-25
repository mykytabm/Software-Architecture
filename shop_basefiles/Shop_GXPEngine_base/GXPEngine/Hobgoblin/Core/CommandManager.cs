using System;
using Hobgoblin.Interfaces;
using GXPEngine;
using System.Collections.Generic;
using Hobgoblin.Utils;
namespace Hobgoblin.Core
{
    public class CommandManager : IService
    {
        private Dictionary<Key, ICommand[]> _keyCommands = new Dictionary<Key, ICommand[]>();

        public CommandManager() { }

        public void RegisterCommand(Key pKey, ICommand pCommand)
        {
            if (_keyCommands.ContainsKey(pKey))
            {
                Console.WriteLine("Command found - adding command to list of commands");
                if (!ContainsCommand(pKey, pCommand))
                {
                    _keyCommands[pKey][0] = pCommand;
                }
            }
            else
            {
                Console.WriteLine("Command not found - adding command");
                _keyCommands.Add(pKey, new ICommand[(Globals.maxCommandsPerKey)] { pCommand });
            }
        }

        public bool ContainsCommand(Key pKey, ICommand pCommand)
        {
            var result = Utils.Utils.TindObjectInArray<ICommand>(pCommand, _keyCommands[pKey]);
            return result;
        }

        public void Step()
        {
            foreach (var keyEvent in _keyCommands)
            {
                if (Input.GetKeyDown((int)keyEvent.Key))
                {
                    foreach (var command in keyEvent.Value)
                    {
                        command.Execute();
                    }
                }
            }
        }
    }
}
