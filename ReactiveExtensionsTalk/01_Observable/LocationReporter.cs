using System;
using Core;

namespace _01_Observable
{
    public class LocationReporter : IObserver<Location>
    {
        private readonly string _instanceName;
        private IDisposable _unsubscriber;

        public LocationReporter(string name)
        {
            _instanceName = name;
        }

        public string Name
        {
            get { return _instanceName; }
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("The Location Tracker has completed transmitting data to {0}.", Name);
            Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine("{0}: The location cannot be determined. ({1})", Name, e.GetType().Name);
        }

        public virtual void OnNext(Location value)
        {
            Console.WriteLine("{2}: The current location is {0}, {1}", value.Latitude, value.Longitude, Name);
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
