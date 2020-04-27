using System;
namespace Hobgoblin.Core
{
    public abstract class Component
    {
        protected HGameObject _owner = null;
        public Component() {}

        public void SetOwner(HGameObject pOwner)
        {
            _owner = pOwner;
        }

        public virtual void Update()
        {

        }
    }
}
