using System;
using System.Collections.Generic;
using System.Drawing;
using GXPEngine;
using Hobgoblin.Model;
using Hobgoblin.Utils;

namespace Hobgoblin.InventoryMvc
{
    //This class will draw a messagebox containing messages from the Shop that is observed.
    public class InventoryMessageView : Canvas, IObserver<InventoryData>
    {
        const int FontHeight = 20;
        private List<string> _messages;

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  ShopMessageDisplay()
        //------------------------------------------------------------------------------------------------------------------------
        public InventoryMessageView() : base(800, 100)
        {
            _messages = new List<string>();
        }

        public void Subscribe(InventoryModel pProvider)
        {
            pProvider.Subscribe(this);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(InventoryData pData)
        {
            _messages = pData.messages;
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Step()
        //------------------------------------------------------------------------------------------------------------------------
        public void Step()
        {
            DrawBackground();
            DrawMessages();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawBackground()
        //------------------------------------------------------------------------------------------------------------------------
        private void DrawBackground()
        {
            graphics.Clear(Color.DarkOliveGreen);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawMessages()
        //------------------------------------------------------------------------------------------------------------------------
        //Draw messages onto this messagebox
        private void DrawMessages()
        {
            graphics.DrawString("Use ARROW KEYS to navigate. Press Q to try drinking item, Press E to try equipping item", SystemFonts.CaptionFont, Brushes.White, 0, 0);

            for (int i = 0; i < _messages.Count; ++i)
            {
                String message = _messages[i];
                graphics.DrawString(message, SystemFonts.CaptionFont, Brushes.White, 0, FontHeight + i * FontHeight);
            }
        }

    }
}
