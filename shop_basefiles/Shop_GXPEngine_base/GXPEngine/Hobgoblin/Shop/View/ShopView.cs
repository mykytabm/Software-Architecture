namespace Hobgoblin.View
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using GXPEngine;
    using GXPEngine.Core;
    using Hobgoblin.Model;
    using Hobgoblin.Controller;
    using Hobgoblin.Utils;
    using Hobgoblin.Core;
    using Hobgoblin.ShopCommands;

    //This Class draws the icons for the items in the store
    public class ShopView : Canvas, IObserver<ShopData>
    {
        const int Columns = 4;
        const int Spacing = 80;
        const int Margin = 18;

        private int _selectedItemId;
        private int _itemCount;
        private List<Item> _items = new List<Item>();
        private ShopController shopController;
        //private ShopCommandManager _shopCommandManager;
        private CommandManager _commandManager;

        //the icon cache is built in here, that violates the S.R. principle.
        private Dictionary<string, Texture2D> iconCache;

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  ShopView()
        //------------------------------------------------------------------------------------------------------------------------        
        public ShopView(ShopController shopController) : base(340, 340)
        {
            this.shopController = shopController;
            //_shopCommandManager = ServiceLocator.Instance.GetService<ShopCommandManager>(); //old
            _commandManager = ServiceLocator.Instance.GetService<CommandManager>();
            iconCache = new Dictionary<string, Texture2D>();
            Console.WriteLine($" current selected item: {_selectedItemId}");
            x = (game.width - width) / 2;
            y = (game.height - height) / 2;

            //----------------------------- Create Commands --------------------------------//
            var moveSelectionLeft = new MoveSelectionCommand(shopController, this, -1, 0);
            var moveSelectionRight = new MoveSelectionCommand(shopController, this, 1, 0);
            var moveSelectionUp = new MoveSelectionCommand(shopController, this, 0, -1);
            var moveSelectionDown = new MoveSelectionCommand(shopController, this, 0, 1);
            var buyItem = new BuyItemCommand(shopController);
            var sellItem = new SellItemCommand(shopController);

            //----------------------------- Assign Commands --------------------------------//
            _commandManager.RegisterCommand(Key.LEFT, moveSelectionLeft);
            _commandManager.RegisterCommand(Key.RIGHT, moveSelectionRight);
            _commandManager.RegisterCommand(Key.UP, moveSelectionUp);
            _commandManager.RegisterCommand(Key.DOWN, moveSelectionDown);
            _commandManager.RegisterCommand(Key.BACKSPACE, buyItem);
            _commandManager.RegisterCommand(Key.SPACE, sellItem);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Step()
        //------------------------------------------------------------------------------------------------------------------------        
        public void Step()
        {
            DrawBackground();
            DrawItems();
            HandleNavigation();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  HandleNavigation()
        //------------------------------------------------------------------------------------------------------------------------        
        private void HandleNavigation() { }

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
        //                                                  DrawBackground()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DrawBackground()
        {
            graphics.Clear(Color.White);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawItems()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DrawItems()
        {

            for (int i = 0; i < _items.Count; i++)
            {
                Item item = _items[i];
                int iconX = GetColumnByIndex(i) * Spacing + Margin;
                int iconY = GetRowByIndex(i) * Spacing + Margin;
                if (i == _selectedItemId)
                {
                    DrawSelectedItem(item, iconX, iconY);
                }
                else
                {
                    if (item != null)
                        DrawItem(item, iconX, iconY);
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawItem()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DrawItem(Item item, int iconX, int iconY)
        {
            Texture2D iconTexture = GetCachedTexture(item.iconName);
            graphics.DrawImage(iconTexture.bitmap, iconX, iconY);
            graphics.DrawString(item.name, SystemFonts.CaptionFont, Brushes.Black, iconX + 16, iconY + 16);
            graphics.DrawString(item.amount.ToString(), SystemFonts.CaptionFont, Brushes.Black, iconX + 16, iconY + 32);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawSelectedItem()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DrawSelectedItem(Item item, int iconX, int iconY)
        {
            if (GXPEngine.Utils.Random(0, 2) == 0)
            {
                DrawItem(item, iconX, iconY);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetCachedTexture()
        //------------------------------------------------------------------------------------------------------------------------        
        private Texture2D GetCachedTexture(string filename)
        {
            if (!iconCache.ContainsKey(filename))
            {
                iconCache.Add(filename, new Texture2D("media/" + filename + ".png"));
            }
            return iconCache[filename];
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
            //Console.WriteLine(pData.items.Count);
            _itemCount = pData.itemCount;
            foreach (var item in pData.items)
            {
                Console.WriteLine(item.name);
            }
        }
    }
}