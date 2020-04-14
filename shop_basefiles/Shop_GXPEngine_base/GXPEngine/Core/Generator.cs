using System;
using Interfaces;
using Items;
using Enums;
using Model;
namespace Core
{
    public class Generator
    {
        private ItemFactory _factory;
        private Random _rand;
        private int _seed;

        public Generator(ItemFactory pFactory)
        {

            _rand = new Random(_seed);
            _factory = pFactory;
        }

        public Item CreateRandomItem()
        {
            _seed = (int)DateTime.Now.Ticks;
            int itemType = _rand.Next(1, 3);
            switch (itemType)
            {
                case 1:
                    return _factory.CreatePotion(_seed);
                case 2:
                    return _factory.CreateWeapon(_seed);
            }
            return null;
        }


    }
}
