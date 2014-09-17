using System;
using Core;

namespace _02_Rx_Observable
{
    internal class LocationReporter : IObserver<Location>
    {
        private readonly string _name;
        private IDisposable _unsubscriber;

        public LocationReporter(string name)
        {
            _name = name;
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("The Location Tracker has completed transmitting data to {0}.", _name);
            Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine("{0}: The location cannot be determined. ({1})", _name, e.GetType().Name);
        }

        public virtual void OnNext(Location value)
        {
            Console.WriteLine("{2}: The current location is {0}, {1}", value.Latitude, value.Longitude, _name);
        }

        public virtual void Subscribe(IObservable<Location> provider)
        {
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
    }
}