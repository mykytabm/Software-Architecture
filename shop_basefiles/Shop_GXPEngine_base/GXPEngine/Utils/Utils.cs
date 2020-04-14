using System;
namespace Utils
{
    public static class Utils
    {
        public static T RandomEnumValue<T>(int pSeed)
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random(pSeed).Next(1, v.Length));
        }
    }
}
