using System;
using System.Collections.Generic;
using Hobgoblin.Interfaces;

namespace Hobgoblin.Utils
{
    public static class HUtils
    {
        public static T RandomEnumValue<T>(Random pRandom)
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(pRandom.Next(1, v.Length));
        }
        public static List<T> DeepCopyList<T>(List<T> pList) where T:IPrototype
        {
            var deepCopyList = new List<T>();
            foreach (var item in pList)
            {
                deepCopyList.Add((T)item.Clone());
            }
            return deepCopyList;
        }
        public static bool FindObjectInArray<T>(T pObj, T[] pArr) where T : class
        {
            foreach (var obj in pArr)
            {
                if (pObj == obj)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
