using System;
using Hobgoblin.Interfaces;

namespace Hobgoblin.Core
{
    public abstract class Component : IPrototype
    {
        protected HGameObject _owner = null;
        public HGameObject Owner { get { return _owner; } }

        public IPrototype Clone()
        {
            throw new NotImplementedException();
        }

        public void SetOwner(HGameObject pOwner)
        {
            _owner = pOwner;
        }

        public virtual void Update()
        {

        }
    }
}
