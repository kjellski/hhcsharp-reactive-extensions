
using System;

namespace Core
{
    public static class ConsoleUtils
    {
        public static void WaitForEnter()
        {
            Console.WriteLine("Press <Enter> to exit...");
            Console.ReadLine();
        }
    }
}
