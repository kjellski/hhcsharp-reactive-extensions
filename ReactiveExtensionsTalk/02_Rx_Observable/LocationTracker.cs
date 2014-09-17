using System;
using System.Reactive.Subjects;
using Core;

namespace _02_Rx_Observable
{
    internal class LocationTracker : IObservable<Location>
    {
        private readonly Subject<Location> _location;

        public LocationTracker()
        {
            _location = new Subject<Location>();
        }

        public IDisposable Subscribe(IObserver<Location> observer)
        {
            return _location.Subscribe(observer);
        }

        public void TrackLocation(Location? loc)
        {
            if (!loc.HasValue)
                _location.OnError(new LocationUnknownException());
            else
                _location.OnNext(loc.Value);
        }

        public void EndTransmission()
        {
            _location.OnCompleted();
            _location.Dispose();
        }
    }
}