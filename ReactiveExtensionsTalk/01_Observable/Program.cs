using System;
using Core;



namespace _01_Observable
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("01 Observable with POCOs");
            var provider = new LocationTracker(); // Observable
            
            var reporter1 = new LocationReporter("FixedGPS "); // Observer
            reporter1.Subscribe(provider);
            
            var reporter2 = new LocationReporter("MobileGPS"); // Observer
            reporter2.Subscribe(provider);

            provider.TrackLocation(new Location(47.6456, -123.1312));
            provider.TrackLocation(new Location(31.6677, -11.1199));

            reporter1.OnCompleted();

            provider.TrackLocation(new Location(84.6677, -21.1023));
            provider.TrackLocation(null);
            provider.EndTransmission();

            ConsoleUtils.WaitForEnter();
        }
    }

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
}