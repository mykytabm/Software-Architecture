using System;
using NUnit.Framework;
using Core;
using Items;
using Enums;
namespace UnitTests
{
    [TestFixture]
    public class NormalFactoryTest
    {
        private NormalFactory _factory;
        private int _seed;


        [SetUp]
        public void Init()
        {
            _factory = new NormalFactory();
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
