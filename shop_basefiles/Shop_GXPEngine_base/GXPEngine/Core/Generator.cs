using System;
using Interfaces;
using Items;
using Enums;
using Model;
using System.Collections.Generic;

namespace Core
{
    public class Generator
    {
        private ItemFactory _factory;
        

        public Generator(ItemFactory pFactory)
        {
            _factory = pFactory;

        }

        public List<Item> CreateRandomItems(int pNum)
        {
            var items = new List<Item>(pNum);
            for (int i = 0; i < pNum; i++)
            {
                items.Add(CreateRandomItem());
            }
            return items;
        }

        public Item CreateRandomItem()
        {
            int itemType = Globals.random.Next(1, 3); //TODO: remove magic number
            switch (itemType)
            {
                case 1:
                    return _factory.CreatePotion(Globals.potionMaxAmount);
                case 2:
                    return _factory.CreateWeapon(Globals.weaponMaxAmount);
            }
            return null;
        }


    }
}
