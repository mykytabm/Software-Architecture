using System;
namespace Core
{
    public abstract class Component
    {
        protected MBGameObject _owner;

        public Component()
        {
        }

        public abstract void Update();
    }
}
