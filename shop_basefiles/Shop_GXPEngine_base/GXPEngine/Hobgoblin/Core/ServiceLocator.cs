using System;
using System.Collections.Generic;
using Hobgoblin.Interfaces;
namespace Hobgoblin.Core
{
    public class ServiceLocator : Singleton<ServiceLocator>
    {
        private List<IService> _services = new List<IService>();

        public void AddService(IService pService)
        {
            _services.Add(pService);
        }

        public void RemoveService<T>() where T : IService
        {
            var service = FindService<T>();
            if (service != null)
            {
                _services.Remove(service);
            }
        }

        public T GetService<T>() where T : IService
        {
            return FindService<T>();
        }


        public T FindService<T>() where T : IService
        {
            for (int i = 0; i < _services.Count; ++i)
            {
                if (_services[i].GetType() == typeof(T))
                {
                    return (T)_services[i];
                }
            }
            return default;
        }
    }
}
