using System;
using GXPEngine;
namespace Utils
{
    public class KeyEvent
    {
        public Action callBack;
        public readonly int key;
        public KeyEvent(int pKey, Action pCallback)
        {
            key = pKey ;
            callBack = pCallback;
        }
    }
}
