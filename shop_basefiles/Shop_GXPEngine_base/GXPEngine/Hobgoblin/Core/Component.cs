using System;
namespace Hobgoblin.Core
{
    public abstract class Component
    {
        protected HGameObject _owner = null;
        public HGameObject Owner { get { return _owner; } }
        public void SetOwner(HGameObject pOwner)
        {
            _owner = pOwner;
        }

        public virtual void Update()
        {

        }
    }
}
