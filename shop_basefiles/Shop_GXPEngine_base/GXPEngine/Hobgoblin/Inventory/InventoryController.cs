using System;
using Hobgoblin.Model;

namespace Hobgoblin.InventoryMvc
{
    public class InventoryController
    {
        private InventoryModel _model;
        public InventoryController(InventoryModel pModel)
        {
            _model = pModel;
        }
        //------------------------------------------------------------------------------------------------------------------------
        //                                                  SelectItem()
        //------------------------------------------------------------------------------------------------------------------------
        //attempt to select an item
        public void SelectItem(Item pItem)
        {
            if (pItem != null)
            {
                _model.SelectItem(pItem);
            }
        }
        public void SelectItem(int pIndex)
        {
            _model.SelectItemByIndex(pIndex);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Browse()
        //------------------------------------------------------------------------------------------------------------------------
        public void Browse()
        {
            _model.SelectItemByIndex(0);
        }
    }
}
