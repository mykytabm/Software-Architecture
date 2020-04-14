using Items;
using Enums;

namespace Interfaces
{
    public interface ItemFactory
    {
        Potion CreatePotion(int pSeed);
        Weapon CreateWeapon(int pSeed);
    }
}
