using System;
using Hobgoblin.Interfaces;
using Hobgoblin.Enums;
using Hobgoblin.Model;
using System.Collections.Generic;

namespace Hobgoblin.Core
{
    public class Generator
    {
        private IItemFactory _factory;


        public Generator(IItemFactory pFactory)
        {
            _factory = pFactory;

        }

        public List<Item> CreateRandomItems(int pNum)
        {
            var items = new List<Item>(pNum);
            for (int i = 0; i < pNum; ++i)
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
