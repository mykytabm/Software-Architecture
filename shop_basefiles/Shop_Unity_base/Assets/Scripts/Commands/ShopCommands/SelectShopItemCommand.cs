using UnityEngine;
using System.Collections;
using Hobgoblin.Interfaces;
using Hobgoblin.Controller;
using Hobgoblin.Model;

public class SelectShopItemCommand : ICommand
{
    private ShopController _shopController;
    private Item _item;

    public SelectShopItemCommand(ShopController pShopController, Item pItem)
    {
        _item = pItem;
        _shopController = pShopController;
    }

    public void Execute()
    {
        _shopController.SelectItem(_item);
    }
}
