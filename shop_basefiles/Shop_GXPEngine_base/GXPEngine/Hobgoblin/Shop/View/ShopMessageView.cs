using System;
using System.Collections.Generic;
using System.Drawing;
using GXPEngine;
using Hobgoblin.Model;
using Hobgoblin.Utils;

namespace Hobgoblin.View
{
    //This class will draw a messagebox containing messages from the Shop that is observed.
    public class ShopMessageView : Canvas, IObserver<ShopData>
    {
        const int FontHeight = 20;
        private List<string> _messages;

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  ShopMessageDisplay()
        //------------------------------------------------------------------------------------------------------------------------
        public ShopMessageView() : base(800, 100)
        {
            _messages = new List<string>();
        }

        public void Subscribe(ShopModel pProvider)
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

        public void OnNext(ShopData pData)
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
        //Draw background color
        private void DrawBackground()
        {
            graphics.Clear(Color.IndianRed);
            //graphics.FillRectangle(Brushes.Gray, new Rectangle(0, 0, game.width, FontHeight));
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawMessages()
        //------------------------------------------------------------------------------------------------------------------------
        //Draw messages onto this messagebox
        private void DrawMessages()
        {
            graphics.DrawString("Use ARROWKEYS to navigate. Press SPACE to buy, BKSPACE to sell.", SystemFonts.CaptionFont, Brushes.White, 0, 0);

            for (int i = 0; i < _messages.Count; ++i)
            {
                String message = _messages[i];
                graphics.DrawString(message, SystemFonts.CaptionFont, Brushes.Black, 0, FontHeight + i * FontHeight);
            }
        }

    }
}
