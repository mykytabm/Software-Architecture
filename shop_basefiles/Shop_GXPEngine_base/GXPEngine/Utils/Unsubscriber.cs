using System;
using System.Collections.Generic;
using View;
namespace Utils
{
    internal class Unsubscriber<ShopModelInfo> : IDisposable
    {
        private List<IObserver<ShopModelInfo>> _observers;
        private IObserver<ShopModelInfo> _observer;

        internal Unsubscriber(List<IObserver<ShopModelInfo>> observers,
            IObserver<ShopModelInfo> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
