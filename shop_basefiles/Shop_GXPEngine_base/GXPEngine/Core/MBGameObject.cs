using System;
using System.Collections.Generic;
using GXPEngine;

namespace Core
{
    public class MBGameObject : GameObject
    {
        protected List<Component> _components = new List<Component>();
        public MBGameObject()
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
