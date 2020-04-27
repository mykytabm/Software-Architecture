using System;
using System.Collections.Generic;
using Hobgoblin.View;

namespace Hobgoblin.Utils
{
    internal class Unsubscriber<Data> : IDisposable
    {
        private List<IObserver<Data>> _observers;
        private IObserver<Data> _observer;

        internal Unsubscriber(List<IObserver<Data>> observers,
            IObserver<Data> observer)
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
