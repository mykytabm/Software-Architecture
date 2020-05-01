using System;
using System.Collections.Generic;
using GXPEngine;

namespace Hobgoblin.Core
{
    public class HGameObject
    {
        protected List<Component> _components = new List<Component>();

        public HGameObject()
        {

        }

        public bool AddComponent(Component pComponent)
        {
            if (!_components.Contains(pComponent))
            {
                _components.Add(pComponent);
                pComponent.SetOwner(this);
                return true;
            }
            else
            {
                return false;
            }

        }
        public int GetComponentCount()
        {
            return _components.Count;
        }
        public T GetComponent<T>() where T : Component
        {
            for (int i = 0; i < _components.Count; ++i)
            {
                if (_components[i].GetType() == typeof(T))
                {
                    return (T)_components[i];
                }
            }
            return default;
        }

        public List<T> GetComponents<T>() where T : Component
        {
            var components = new List<T>(_components.Count);

            for (int i = 0; i < _components.Count; ++i)
            {
                if (_components[i].GetType() == typeof(T))
                {
                    components.Add((T)_components[i]);
                }
            }
            components.TrimExcess(); // avoid autoresizing of the list cuz its expensive

            return components;
        }

        public bool ContainsComponent<T>() where T : Component
        {
            for (int i = 0; i < _components.Count; ++i)
            {
                if (_components[i].GetType() == typeof(T))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
