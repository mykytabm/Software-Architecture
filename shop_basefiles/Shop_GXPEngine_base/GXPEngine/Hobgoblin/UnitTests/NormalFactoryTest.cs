using System;
using NUnit.Framework;
using Hobgoblin.Core;
using Hobgoblin.Items;
using Hobgoblin.Enums;
namespace Hobgoblin.UnitTests
{
    [TestFixture]
    public class NormalFactoryTest
    {
        private NormalItemFactory _factory;
        private int _seed;


        [SetUp]
        public void Init()
        {
            _factory = new NormalItemFactory();
            _seed = (int)DateTime.Now.Ticks;
        }

        [TestCase]
        public void CreatePotion()
        {
            Potion potion = _factory.CreatePotion(_seed);

            Assert.AreNotEqual("", potion.name);
            Assert.AreNotEqual(EPotion.none, potion.type);
            Assert.AreNotEqual(0, potion.amount);
            Assert.AreNotEqual(0, potion.iconName);
        }

        [TestCase]
        public void CreateWeapon()
        {
            Weapon weapon = _factory.CreateWeapon(_seed);

            Assert.AreNotEqual("", weapon.name);
            Assert.AreNotEqual(EPotion.none, weapon.type);
            Assert.AreNotEqual(0, weapon.amount);
            Assert.AreNotEqual(0, weapon.iconName);
        }
    }
}
