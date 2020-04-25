using System;
namespace Hobgoblin.Core
{
    public abstract class Component
    {
        protected GGameObject _owner;

        public Component()
        {
        }

        public abstract void Update();
    }
}
