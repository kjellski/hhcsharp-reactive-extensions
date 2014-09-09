using System;
using System.Reactive;
using System.Reactive.Subjects;
using Core;

namespace _02_Rx_Observable
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("02 Observable with Rx");
            var provider = new Subject<Location>();

            const string reporter1Name = "FixedGPS ";
            var reporter1 = Observer.Create<Location>(data => PrintLocation(reporter1Name, data),
                exception => PrintError(reporter1Name, exception),
                () => PrintCompleted(reporter1Name));
            provider.Subscribe(reporter1);

            const string reporter2Name = "MobileGPS";
            var reporter2 = Observer.Create<Location>(data => PrintLocation(reporter2Name, data),
                exception => PrintError(reporter2Name, exception),
                () => PrintCompleted(reporter2Name));
            provider.Subscribe(reporter2);

            provider.OnNext(new Location(47.6456, -123.1312));
            provider.OnNext(new Location(31.6677, -11.1199));
            
            reporter1.OnCompleted();

            provider.OnNext(new Location(84.6677, -21.1023));
            provider.OnError(new LocationUnknownException() /* null won't get in */);
            provider.Dispose();

            ConsoleUtils.WaitForEnter();
        }

        private static void PrintCompleted(string name)
        {
            Console.WriteLine("The Location Tracker has completed transmitting data to {0}.", name);
        }

        private static void PrintError(string name, Exception exception)
        {
            Console.WriteLine("{0}: The location cannot be determined. ({1})", name, exception.GetType().Name);
        }

        private static void PrintLocation(string name, Location data)
        {
            Console.WriteLine("{2}: The current location is {0}, {1}", data.Latitude, data.Longitude, name);
        }
    }
}