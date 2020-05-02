using UnityEngine;
using System.Collections;
using Hobgoblin.Interfaces;
using Hobgoblin.InventoryMvc;
using Hobgoblin.Model;

public class SelectInventoryItemCommand : ICommand
{
    private InventoryController _InventoryController;
    private int _id;

    public SelectInventoryItemCommand(InventoryController pInventoryController, int pId)
    {
        _id = pId;
        _InventoryController = pInventoryController;
    }

    public void Execute()
    {
        _InventoryController.SetSelectedItemId(_id);
    }
}
