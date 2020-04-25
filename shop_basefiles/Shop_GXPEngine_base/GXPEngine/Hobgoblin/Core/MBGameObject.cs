using System;
using System.Collections.Generic;
using GXPEngine;

namespace Hobgoblin.Core
{
    public class GGameObject : GameObject
    {
        protected List<Component> _components = new List<Component>();
        public GGameObject()
        {
        }
        public bool AddComponent(Component pComponent)
        {
            _components.Add(pComponent);
            return true;
        }
        public virtual void Update()
        {
            foreach (var component in _components)
            {
                component.Update();
            }
        }
    }
}
