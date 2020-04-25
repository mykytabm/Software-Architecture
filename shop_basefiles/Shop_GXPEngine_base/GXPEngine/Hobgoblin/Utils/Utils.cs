using System;
namespace Hobgoblin.Utils
{
    public static class Utils
    {
        public static T RandomEnumValue<T>(Random pRandom)
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(pRandom.Next(1, v.Length));
        }
        public static bool TindObjectInArray<T>(T pObj, T[] pArr) where T : class
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
