using System;
using Hobgoblin.Interfaces;
using GXPEngine;
using System.Collections.Generic;
using Hobgoblin.Utils;
namespace Hobgoblin.Core
{
    public class CommandManager : IService
    {
        private Dictionary<Key, List<ICommand>> _keyCommands = new Dictionary<Key, List<ICommand>>();

        public void RegisterCommand(Key pKey, ICommand pCommand)
        {
            if (_keyCommands.ContainsKey(pKey))
            {
                if (!ContainsCommand(pKey, pCommand) && _keyCommands[pKey].Count <= Globals.maxCommandsPerKey)
                {
                    _keyCommands[pKey].Add(pCommand);
                }
            }
            else
            {
                _keyCommands.Add(pKey, new List<ICommand>(Globals.maxCommandsPerKey) { pCommand });
            }
        }
        public bool DeregisterCommand(Key pKey, ICommand pCommand)
        {
            if (_keyCommands.ContainsKey(pKey))
            {
                return _keyCommands[pKey].Remove(pCommand);
            }
            else
            {
                return false;
            }
        }


        public bool ContainsCommand(Key pKey, ICommand pCommand)
        {
            return _keyCommands[pKey].Contains(pCommand);
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
