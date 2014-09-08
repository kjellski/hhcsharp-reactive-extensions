using System;
using System.Collections.Generic;

namespace _01_Observable
{
    public class LocationTracker : IObservable<Location>
    {
        private readonly List<IObserver<Location>> _observers;

        public LocationTracker()
        {
            _observers = new List<IObserver<Location>>();
        }

        public IDisposable Subscribe(IObserver<Location> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        public void TrackLocation(Location? loc)
        {
            foreach (var observer in _observers)
            {
                if (!loc.HasValue)
                    observer.OnError(new LocationUnknownException());
                else
                    observer.OnNext(loc.Value);
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in _observers.ToArray())
                if (_observers.Contains(observer))
                    observer.OnCompleted();

            _observers.Clear();
        }

        // unsubscribe when you get disposed
        private class Unsubscriber : IDisposable
        {
            private readonly IObserver<Location> _observer;
            private readonly List<IObserver<Location>> _observers;

            public Unsubscriber(List<IObserver<Location>> observers, IObserver<Location> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}