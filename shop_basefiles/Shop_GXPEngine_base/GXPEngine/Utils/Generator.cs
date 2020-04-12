using System;
using Interfaces;
using Model;
using Items;
namespace Utils
{
    public class Generator
    {
        private ItemFactory _factory;
        private Random _rnd;

        public Generator(ItemFactory pFactory)
        {
            _rnd = new Random((int)DateTime.Now.Ticks);
            _factory = pFactory;
        }

        public Item CreateRandomItem()
        {
            int itemType = _rnd.Next(1, 3);
            Console.WriteLine(itemType);
            switch (itemType)
            {
                case 1:
                    return GenerateRandomPotion(10);
                case 2:
                    return GenerateRandomWeapon(10);
            }
            return null;
        }

        private Potion GenerateRandomPotion(int maxAmount)
        {
            int amount = _rnd.Next(1, maxAmount + 1);
            var potionType = RandomEnumValue<EPotion>();
            Console.WriteLine($"Created {amount} potion(s) of type {potionType}");
            return _factory.CreatePotion("potion", "item", amount, potionType);
        }

        private Weapon GenerateRandomWeapon(int maxAmount)
        {
            int amount = _rnd.Next(1, maxAmount + 1);
            var weaponType = RandomEnumValue<EWeapon>();
            Console.WriteLine($"Created {amount} weapon(s) of type {weaponType}");
            return _factory.CreateWeapon("weapon", "item", amount, weaponType);
        }

        private T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random().Next(v.Length));
        }



    }
}
