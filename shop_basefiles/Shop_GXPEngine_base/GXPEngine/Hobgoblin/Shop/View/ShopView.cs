namespace Hobgoblin.View
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using GXPEngine;
    using GXPEngine.Core;
    using Hobgoblin.Model;
    using Hobgoblin.Controller;
    using Hobgoblin.Core;
    using Hobgoblin.ShopCommands;
    using Hobgoblin.Utils;

    //This Class draws the icons for the items in the store
    public class ShopView : Canvas, IObserver<ShopData>
    {
        const int Columns = 4;
        const int Spacing = IconSize + 15;
        const int Margin = 18;
        const int IconSize = 64;

        private int _selectedItemId;
        private int _itemCount;

        private Actor _customer;
        private ShopController _shopController;
        private CommandManager _commandManager;

        private List<Item> _items;
        private List<KeyCommand> _keyCommands;

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  ShopView()
        //------------------------------------------------------------------------------------------------------------------------        
        public ShopView(ShopController pShopController, Actor pCustomer) : base(340, 340)
        {
            _shopController = pShopController;
            _commandManager = ServiceLocator.Instance.GetService<CommandManager>();
            _items = new List<Item>();
            _customer = pCustomer;

            x = (game.width - width) / 2;
            y = (game.height - height) / 2;

            //----------------------------- Create Commands --------------------------------//
            var moveSelectionLeft = new MoveSelectionCommand(_shopController, this, -1, 0);
            var moveSelectionRight = new MoveSelectionCommand(_shopController, this, 1, 0);
            var moveSelectionUp = new MoveSelectionCommand(_shopController, this, 0, -1);
            var moveSelectionDown = new MoveSelectionCommand(_shopController, this, 0, 1);
            var buyItem = new BuyItemCommand(_shopController, _customer);

            //-------------------------- Add Commands to list ------------------------------//
            _keyCommands = new List<KeyCommand>()
            {
                new KeyCommand((int)Key.LEFT, moveSelectionLeft),
                new KeyCommand((int)Key.RIGHT, moveSelectionRight),
                new KeyCommand((int)Key.UP, moveSelectionUp),
                new KeyCommand((int)Key.DOWN, moveSelectionDown),
                new KeyCommand((int)Key.SPACE, buyItem),
            };
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Step()
        //------------------------------------------------------------------------------------------------------------------------        
        public void Step()
        {
            DrawBackground();
            DrawName();
            DrawItems();
        }


        public void Subscribe(ShopModel pProvider)
        {
            pProvider.Subscribe(this);
        }


        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception pError)
        {
            throw new NotImplementedException();
        }

        public void OnNext(ShopData pData)
        {
            _items = pData.items;
            _selectedItemId = pData.selectedItemIndex;
            _itemCount = pData.itemCount;
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  MoveSelection()
        //------------------------------------------------------------------------------------------------------------------------        
        public int GetNewSelectedItemId(int moveX, int moveY)
        {
            int currentSelectionX = GetColumnByIndex(_selectedItemId);
            int currentSelectionY = GetRowByIndex(_selectedItemId);
            int requestedSelectionX = currentSelectionX + moveX;
            int requestedSelectionY = currentSelectionY + moveY;

            if (requestedSelectionX >= 0 && requestedSelectionX < Columns) //check horizontal boundaries
            {
                int newItemIndex = GetIndexFromGridPosition(requestedSelectionX, requestedSelectionY);
                if (newItemIndex >= 0 && newItemIndex <= _itemCount) //check vertical boundaries
                {
                    return newItemIndex;
                }
                return _selectedItemId;
            }
            return _selectedItemId;
        }

        protected override void OnDestroy()
        {
            DeregisterCommands();
            base.OnDestroy();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  RegisterCommands()
        //------------------------------------------------------------------------------------------------------------------------        
        public void RegisterCommands()
        {
            foreach (var keyCommand in _keyCommands)
            {
                _commandManager.RegisterCommand(keyCommand);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DeregisterCommands()
        //------------------------------------------------------------------------------------------------------------------------        
        public void DeregisterCommands()
        {
            foreach (var keyCommand in _keyCommands)
            {
                _commandManager.DeregisterCommand(keyCommand);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetColumnByIndex()
        //------------------------------------------------------------------------------------------------------------------------        
        private int GetIndexFromGridPosition(int column, int row)
        {
            return row * Columns + column;
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetColumnByIndex()
        //------------------------------------------------------------------------------------------------------------------------        
        private int GetColumnByIndex(int index)
        {
            return index % Columns;
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetRowByIndex()
        //------------------------------------------------------------------------------------------------------------------------        
        private int GetRowByIndex(int index)
        {
            return index / Columns; //rounds down
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawName()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DrawName()
        {
            graphics.DrawString("  Hobgoblin's shop", SystemFonts.CaptionFont, Brushes.White, 0, 0);
        }
        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawBackground()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DrawBackground()
        {
            graphics.Clear(Color.DarkOliveGreen);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawItems()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DrawItems()
        {
            for (int i = 0; i < _items.Count; ++i)
            {
                Item item = _items[i];
                int iconX = GetColumnByIndex(i) * Spacing + Margin;
                int iconY = GetRowByIndex(i) * Spacing + Margin;
                if (i == _selectedItemId)
                {
                    DrawItem(item, iconX, iconY);
                    DrawSelectionIcon(iconX, iconY);
                }
                else
                {
                    if (item != null)
                        DrawItem(item, iconX, iconY);
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawSelectionIcon()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DrawSelectionIcon(int iconX, int iconY)
        {
            Texture2D selectionTexture = IconCache.GetCachedTexture("frame");
            graphics.DrawImage(selectionTexture.bitmap, iconX, iconY);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawItem()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DrawItem(Item item, int iconX, int iconY)
        {
            Texture2D iconTexture = IconCache.GetCachedTexture(item.iconName);
            graphics.DrawImage(iconTexture.bitmap, iconX, iconY, IconSize, IconSize);
        }
    }
}