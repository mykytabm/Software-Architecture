using System;
namespace Utils
{
    public static class Utils
    {
        public static T RandomEnumValue<T>(Random pRandom)
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(pRandom.Next(1, v.Length));
        }
    }
}
