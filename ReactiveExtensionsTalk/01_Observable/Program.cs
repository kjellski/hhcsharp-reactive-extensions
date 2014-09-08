using Utils;

namespace _01_Observable
{
    internal class Program
    {
        public static void Main()
        {
            /* Small Recap:
             * 
             * Observable<T>:
             *     Subscribe(Observer<T>)
             *     
             * Observer<T>:
             *     OnCompleted()
             *     OnError(Exception)
             *     OnNext(T)
             */

            // Define a provider and two observers.
            var provider = new LocationTracker();

            var reporter1 = new LocationReporter("FixedGPS ");
            reporter1.Subscribe(provider);

            var reporter2 = new LocationReporter("MobileGPS");
            reporter2.Subscribe(provider);

            provider.TrackLocation(new Location(47.6456, -123.1312));
            provider.TrackLocation(new Location(31.6677, -11.1199));

            reporter1.Unsubscribe();

            provider.TrackLocation(new Location(84.6677, -21.1023));
            provider.TrackLocation(null);
            provider.EndTransmission();

            ConsoleUtils.WaitForEnter();
        }
    }
}