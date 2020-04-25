using System;
using GXPEngine;
using Hobgoblin.Interfaces;
namespace Hobgoblin.Utils
{
    public class KeyEvent
    {
        public readonly Action action;
        public readonly Key key;

        public KeyEvent(Key pKey, Action pAction)
        {
            key = pKey;
            action = pAction;
        }
    }
}
