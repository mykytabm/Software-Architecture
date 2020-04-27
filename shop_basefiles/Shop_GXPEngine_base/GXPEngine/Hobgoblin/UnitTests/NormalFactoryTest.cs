using System;
using NUnit.Framework;
using Hobgoblin.Core;
using Hobgoblin.Enums;
using Hobgoblin.Model;

namespace Hobgoblin.UnitTests
{
    [TestFixture]
    public class NormalFactoryTest
    {
        private NormalItemFactory _factory;

        [SetUp]
        public void Init()
        {
            _factory = new NormalItemFactory();
        }

        [TestCase]
        public void CreatePotion()
        {
            int numOfPotions = Globals.random.Next(0, Globals.potionMaxAmount);
            Item potion = _factory.CreatePotion(numOfPotions);

            Assert.AreNotEqual("", potion.name);
            Assert.AreNotEqual(0, potion.Amount);
            Assert.AreNotEqual(0, potion.iconName);
        }

        [TestCase]
        public void CreateWeapon()
        {
            int numOfWeapons = Globals.random.Next(0, Globals.weaponMaxAmount);
            Item weapon = _factory.CreateWeapon(numOfWeapons);

            Assert.AreNotEqual("", weapon.name);
            Assert.AreNotEqual(0, weapon.Amount);
            Assert.AreNotEqual(0, weapon.iconName);
        }
    }
}
