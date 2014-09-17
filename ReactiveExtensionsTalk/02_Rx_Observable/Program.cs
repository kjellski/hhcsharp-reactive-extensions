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

            RecreatedReporterAndTrackerExample();
            SubjectExample();
        }

        private static void RecreatedReporterAndTrackerExample()
        {
            Console.WriteLine("02 Rebuild Observable with Rx");
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

        private static void SubjectExample()
        {
            Console.WriteLine("Subject:");
            var location = new Subject<Location>(); // Observable
            var reporter1 = CreateReporterWith("FixedGPS "); // Observer
            var reporter2 = CreateReporterWith("MobileGPS"); // Observer
            var subscription1 = location.Subscribe(reporter1);
            location.Subscribe(reporter2);

            location.OnNext(new Location(47.6456, -123.1312));
            location.OnNext(new Location(31.6677, -11.1199));

            subscription1.Dispose();

            location.OnNext(new Location(84.6677, -21.1023));
            location.OnError(new LocationUnknownException());
            location.OnCompleted();

            ConsoleUtils.WaitForEnter();
        }
        
        private static IObserver<Location> CreateReporterWith(string reporterName)
        {
            return Observer.Create<Location>(
                data => PrintLocation(reporterName, data), //        OnNext()
                exception => PrintError(reporterName, exception), // OnError()
                () => PrintCompleted(reporterName)); //              OnCompleted()
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