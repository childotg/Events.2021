using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            new ConsumerTask().RunAsync().GetAwaiter().GetResult();
        }

    }
}
