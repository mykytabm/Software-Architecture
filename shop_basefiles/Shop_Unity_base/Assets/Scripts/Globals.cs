using System;
namespace Hobgoblin
{

    public static class Globals
    {
        public const int WeaponMaxAmount = 10;
        public const int PotionMaxAmount = 20;
        public const int maxCommandsPerKey = 1;
        public const int ItemsPerShop = 15;
        public readonly static Random random = new Random((int)DateTime.Now.Ticks);
    }
}

