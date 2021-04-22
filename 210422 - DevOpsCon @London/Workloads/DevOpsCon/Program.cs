using System;
using System.Threading;

namespace DevOpsCon
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.UtcNow;
            while (start.AddMinutes(5) > DateTime.UtcNow)
            {
                Console.WriteLine(
                    "Hello from DevOpsCon 2021 @London");
                Thread.Sleep(1000);
            }
        }
    }
}
