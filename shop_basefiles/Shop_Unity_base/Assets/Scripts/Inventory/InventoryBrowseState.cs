using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hobgoblin.InventoryMvc;
using Hobgoblin.Components;
using Hobgoblin.Controller;
using Hobgoblin.States;

public class InventoryBrowseState : MonoBehaviour
{
    private InventoryModel _inventoryModel;
    private InventoryController _inventoryController;
    private InventoryView _inventoryView;
    private Inventory _playerInventory;
    void Start()
    {
        _playerInventory = Game.PlayerHumanoid.GetComponent<Inventory>();
        Initialize();
    }
    private void Initialize()
    {
        _inventoryModel = new InventoryModel(_playerInventory);
        _inventoryController = new InventoryController(_inventoryModel);

        var shopController = gameObject.GetComponent<ShopBrowseState>().ShopController();

        _inventoryView = GetComponentInChildren<InventoryView>();
        _inventoryView.Subscribe(_inventoryModel);
        _inventoryView.Initialize(shopController, _inventoryController);
    }
}
