using System;
using Controller;
using Interfaces;
namespace Commands
{
    public class MoveItemSelection : IShopCommand
    {
        private int _newSelection;
        public MoveItemSelection(int pNewIndex)
        {
            _newSelection = pNewIndex;
        }
        public void Execute(ShopController pShopController)
        {
            pShopController.SelectItem(_newSelection);
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
