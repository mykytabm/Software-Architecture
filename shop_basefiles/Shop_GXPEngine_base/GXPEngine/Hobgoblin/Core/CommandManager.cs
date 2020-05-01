using System;
using Hobgoblin.Interfaces;
using GXPEngine;
using System.Collections.Generic;
using Hobgoblin.Utils;
namespace Hobgoblin.Core
{
    public class CommandManager : IService
    {
        private List<KeyCommand> _keyCommands = new List<KeyCommand>();

        public void RegisterCommand(Key pKey, ICommand pCommand)
        {
            //if (_keyCommands.ContainsKey(pKey))
            //{
            //    if (!ContainsCommand(pKey, pCommand) && _keyCommands[pKey].Count <= Globals.maxCommandsPerKey)
            //    {
            //        _keyCommands[pKey].Add(pCommand);
            //    }
            //}
            //else
            //{
            //    _keyCommands.Add(pKey, new List<ICommand>(Globals.maxCommandsPerKey) { pCommand });
            //}
        }
        public void RegisterCommand(KeyCommand pCommand)
        {
            //if (_keyCommands.Exists(c => c == pCommand))
            //{

            //}
            //else
            //{
                _keyCommands.Add(pCommand);
            //}
        }

        public bool DeregisterCommand(Key pKey, ICommand pCommand)
        {
            //if (_keyCommands.ContainsKey(pKey))
            //{
            //    return _keyCommands[pKey].Remove(pCommand);
            //}
            //else
            //{
            //    return false;
            //}
            return false;
        }
        public bool DeregisterCommand(KeyCommand pCommand)
        {
            return _keyCommands.Remove(pCommand);
        }


        //public bool ContainsCommand(Key pKey, ICommand pCommand)
        //{
        //    //return _keyCommands[pKey].Contains(pCommand);
        //}
        public bool ContainsCommand(KeyCommand pCommand)
        {
            return _keyCommands.Contains(pCommand);
        }

        public void Step()
        {
            for (int i = _keyCommands.Count - 1; i >= 0; i--)
            {
                if (Input.GetKeyDown((int)_keyCommands[i].key))
                {
                    _keyCommands[i].command.Execute();
                }
            }
        }
    }
}
