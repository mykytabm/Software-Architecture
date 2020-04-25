using System;
using System.Collections.Generic;
using GXPEngine;
using Hobgoblin.Utils;
using Hobgoblin.Core;
namespace Hobgoblin.Components
{
    public class InputController : Component
    {
        private List<KeyEvent> _keyCommands = new List<KeyEvent>();

        public InputController()
        {
        }

        public void AddEvent(KeyEvent pKeyEvent)
        {
            //if

        }

        public override void Update()
        {
            foreach (var keyEvent in _keyCommands)
            {
                if (Input.GetKeyDown((int)keyEvent.key))
                {
                    keyEvent.action();
                }
            }
        }
    }
}
