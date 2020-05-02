using System;
using System.Collections;
using System.Collections.Generic;
using Hobgoblin.Commands.InventoryCommands;
using Hobgoblin.Components;
using Hobgoblin.Controller;
using Hobgoblin.Core;
using Hobgoblin.InventoryMvc;
using Hobgoblin.Model;
using Hobgoblin.ShopCommands;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour, IObserver<InventoryData>
{

    [SerializeField]
    private LayoutGroup _itemLayoutGroup;

    [SerializeField]
    private GameObject _itemPrefab;

    [SerializeField]
    private Button _sellButton;

    private CommandManager _commandManager;
    private ShopController _shopController;
    private InventoryController _inventoryController;

    private List<Item> _items;
    private int _selectedItemId;

    public void Initialize(ShopController pShopController, InventoryController pInventoryController)
    {
        _shopController = pShopController;
        _inventoryController = pInventoryController;
        InitializeButtons();
    }

    public void Subscribe(InventoryModel pModel)
    {
        pModel.Subscribe(this);
    }

    private void RepopulateItemIconView()
    {
        ClearIconView();
        PopulateItemIconView();
    }

    private void PopulateItemIconView()
    {
        foreach (Item item in _items)
        {
            AddItemToView(item);
        }
    }

    private void AddItemToView(Item item)
    {
        GameObject newItemIcon = GameObject.Instantiate(_itemPrefab);
        newItemIcon.transform.SetParent(_itemLayoutGroup.transform);
        newItemIcon.transform.localScale = Vector3.one;//The scale would automatically change in Unity so we set it back to Vector3.one.

        ItemContainer itemContainer = newItemIcon.GetComponent<ItemContainer>();
        Debug.Assert(itemContainer != null);
        bool isSelected = (item == _items[_selectedItemId]);
        itemContainer.Initialize(item, isSelected);

        //Click behaviour for the button is done here. It seemed more convenient to do this inline than in the editor.
        Button itemButton = itemContainer.GetComponent<Button>();
        itemButton.onClick.AddListener(
            delegate
            {
                var commandManager = ServiceLocator.Instance.GetService<CommandManager>();
                commandManager.ExecuteCommand(new SelectInventoryItemCommand(_inventoryController, _items.IndexOf(item)));
            }
        );
    }

    private void ClearIconView()
    {
        Transform[] allIcons = _itemLayoutGroup.transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in allIcons)
        {
            if (child != _itemLayoutGroup.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    public void OnCompleted()
    {

    }

    public void OnError(Exception error)
    {

    }

    public void OnNext(InventoryData pData)
    {
        _selectedItemId = pData.selectedItemIndex;
        _items = pData.items;
        RepopulateItemIconView();
    }

    private void InitializeButtons()
    {
        _sellButton.onClick.AddListener(
            delegate
            {
                var commandManager = ServiceLocator.Instance.GetService<CommandManager>();
                commandManager.ExecuteCommand(
                    new SellItemCommand(_inventoryController, _shopController));
            }
        );
    }
}
