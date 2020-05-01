using System;
using Hobgoblin.Interfaces;
using System.Collections.Generic;
using Hobgoblin.Utils;
using UnityEngine;

namespace Hobgoblin.Core
{
    public class CommandManager : IService
    {
        private List<KeyCommand> _keyCommands = new List<KeyCommand>();


        public void RegisterCommand(KeyCommand pCommand)
        {
            _keyCommands.Add(pCommand);
        }

        public bool DeregisterCommand(KeyCode pKey, ICommand pCommand)
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
                if (Input.GetKeyDown(_keyCommands[i].key))
                {
                    _keyCommands[i].command.Execute();
                }
            }
        }
    }
}
