using Consumer;
using System;

namespace CDaysConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            new ConsumerTask().RunAsync().GetAwaiter().GetResult();
        }
    }
}
