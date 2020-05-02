using System;
using Hobgoblin.Interfaces;
using System.Collections.Generic;
using Hobgoblin.Utils;
namespace Hobgoblin.Core
{
    public class CommandManager : IService
    {
        private List<KeyCommand> _keyCommands = new List<KeyCommand>();
        private Func<int, bool> _eventFunc;

        public CommandManager(Func<int, bool> pEventFunc)
        {
            _eventFunc = pEventFunc;
        }

        public void RegisterCommand(KeyCommand pCommand)
        {
            _keyCommands.Add(pCommand);
        }

        public bool DeregisterCommand(KeyCommand pCommand)
        {
            return _keyCommands.Remove(pCommand);
        }

        public bool ContainsCommand(KeyCommand pCommand)
        {
            return _keyCommands.Contains(pCommand);
        }

        public void ExecuteCommand(ICommand pCommand)
        {
            if (pCommand != null)
            {
                pCommand.Execute();
            }
        }

        public void Step()
        {
            for (int i = _keyCommands.Count - 1; i >= 0; i--)
            {
                if (_eventFunc((int)_keyCommands[i].key))
                {
                    _keyCommands[i].command.Execute();
                }
            }
        }
    }
}
