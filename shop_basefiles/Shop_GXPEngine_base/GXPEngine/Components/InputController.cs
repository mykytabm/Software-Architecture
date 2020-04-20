using System;
using System.Collections.Generic;
using GXPEngine;
using Utils;
using Core;
namespace Components
{
    public class InputController : Component
    {
        private List<KeyEvent> _events = new List<KeyEvent>();

        public InputController()
        {
        }

        public bool AddEvent(KeyEvent pKeyEvent)
        {
            _events.Add(pKeyEvent);
            return true;
        }

        public override void Update()
        {
            foreach (var keyEvent in _events)
            {
                if (Input.GetKeyDown(keyEvent.key))
                {
                    keyEvent.callBack();
                }
            }
        }
    }
}
