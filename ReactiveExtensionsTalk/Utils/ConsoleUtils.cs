using System;

namespace Utils
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