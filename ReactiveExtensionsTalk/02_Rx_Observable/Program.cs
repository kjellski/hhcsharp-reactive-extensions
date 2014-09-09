using System;
using System.Data;
using System.Reactive.Linq;
using Core;

namespace _02_Rx_Observable
{
    public class Program
    {
        public static void Main()
        {
            var location = Observable.Create(observer =>
                observer.OnNext = data => Console.WriteLine(data),);

            ConsoleUtils.WaitForEnter();
        }
    }
}
