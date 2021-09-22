using System;

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
