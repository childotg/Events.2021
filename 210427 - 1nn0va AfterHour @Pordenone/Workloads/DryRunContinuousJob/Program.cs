using System;
using System.Threading;

namespace DryRunContinuousJob
{
    class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.UtcNow;
            while (startTime.AddMinutes(5) > DateTime.UtcNow)
            {
                Console.WriteLine("Running and doing special stuff...");
                Thread.Sleep(1000);
            }
        }
    }
}
