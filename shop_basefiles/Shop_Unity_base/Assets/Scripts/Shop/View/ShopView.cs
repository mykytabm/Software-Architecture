namespace Hobgoblin.View
{
    using System.Collections.Generic;
    using System.Drawing;
    using UnityEngine;
    using UnityEngine.UI;

    using Hobgoblin.Model;
    using Hobgoblin.Controller;
    using Hobgoblin.Utils;
    using System;
    using Hobgoblin.Core;
    using Hobgoblin.ShopCommands;
    using Hobgoblin.Components;

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  ShopController()
    //------------------------------------------------------------------------------------------------------------------------        
    public class ShopView : MonoBehaviour, IObserver<ShopData>
    {
        [SerializeField]
        private LayoutGroup _itemLayoutGroup;

        [SerializeField]
        private GameObject _itemPrefab;

        [SerializeField]
        private Button _buyButton;



        private Humanoid _customer;

        private ShopController _shopController;

        private List<Item> _items = new List<Item>();
        private int _selectedItemId = 0;

        private CommandManager _commandManager;

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Initialize()
        //------------------------------------------------------------------------------------------------------------------------        
        //this method is used to initialize the view, as we can't use a constructor (monobehaviour)
        public void Initialize(ShopController pShopController, Humanoid pCustomer)
        {
            _shopController = pShopController;
            _commandManager = ServiceLocator.Instance.GetService<CommandManager>();
            RepopulateItemIconView(); //we need an Event system instead of this
            InitializeButtons();
            _customer = pCustomer;

        }
        public void Subscribe(ShopModel pModel)
        {
            pModel.Subscribe(this);
        }
        //------------------------------------------------------------------------------------------------------------------------
        //                                                  RepopulateItems()
        //------------------------------------------------------------------------------------------------------------------------        
        //clears the icon gridview and repopulates it with new icons (updates the visible icons)
        private void RepopulateItemIconView()
        {
            ClearIconView();
            PopulateItemIconView();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  PopulateItems()
        //------------------------------------------------------------------------------------------------------------------------        
        //adds one icon for each item in the shop
        private void PopulateItemIconView()
        {
            foreach (Item item in _items)
            {
                AddItemToView(item);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  ClearIconView()
        //------------------------------------------------------------------------------------------------------------------------        
        //remove all existing icons in the gridview
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

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  AddItemToView()
        //------------------------------------------------------------------------------------------------------------------------        
        //Adds a new icon. An icon is a prefab Button with some additional scripts to link it to the store Item
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
                    _commandManager.ExecuteCommand(new SelectShopItemCommand(_shopController, item));
                }
            );
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  InitializeButtons()
        //------------------------------------------------------------------------------------------------------------------------        
        //This method adds a listener to the 'Buy' and 'Sell' button. They are forwarded to the controller to the shop.
        private void InitializeButtons()
        {
            _buyButton.onClick.AddListener(
                delegate
                {

                    _commandManager.ExecuteCommand(new BuyItemCommand(_shopController, _customer));
                }
            );
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(ShopData pData)
        {
            _items = pData.items;
            _selectedItemId = pData.selectedItemIndex;
            RepopulateItemIconView();
        }
    }
}