namespace Hobgoblin.View
{
    using UnityEngine;
    using Hobgoblin.Model;
    using System;
    using Hobgoblin.Utils;
    using System.Collections.Generic;

    public class ShopMessageView : MonoBehaviour, IObserver<ShopData>
    {
        private ShopModel shopModel;
        private List<string> _messages = new List<string>();
        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Initialize()
        //------------------------------------------------------------------------------------------------------------------------
        //This method is used to initialize values, because we can't use a constructor.
        public void Initialize(ShopModel shopModel)
        {
            this.shopModel = shopModel;
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
        //                                                  Update()
        //------------------------------------------------------------------------------------------------------------------------        
        //this method polls the shop for messages and prints them. Since the shop caches the messages, it prints the same
        //message each frame. An event system would work better.
        protected void Update() {
            string[] messages = _messages.ToArray();
            if (messages.Length > 0) {
                string message = messages[messages.Length - 1];
                Debug.Log(message);
            }
        }

        internal void Subscribe(ShopModel pModel)
        {
            pModel.Subscribe(this);
        }
    }
}
