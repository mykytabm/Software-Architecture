using System;
using Controller;
using Interfaces;
namespace Commands
{
    public class MoveSelectionCommand : IShopCommand
    {
        private int _newSelection;
        public MoveSelectionCommand(int pNewIndex)
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
