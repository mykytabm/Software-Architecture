using System;
namespace Core
{
    public abstract class Singleton<T>
     where T : Singleton<T>, new() // makes sure that children have default constructor
    {
        private static T _instance = new T();
        public static T Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
