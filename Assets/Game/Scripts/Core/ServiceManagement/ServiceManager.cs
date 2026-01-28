using System;
using System.Collections.Generic;

namespace Game
{
    public class ServiceManager
    {
        private readonly Dictionary<Type, object> _services;

        public ServiceManager()
        {
            _services = new();
        }

        public void Add<T>(T service) where T : class
        {
            Type type = service.GetType();

            _services.Add(type, service);
        }

        public T Get<T>() where T : class
        {
            Type type = typeof(T);

            return (T)_services[type];
        }
    }
}