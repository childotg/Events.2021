using System;

namespace NetDDConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            new ConsumerTask().RunAsync().GetAwaiter().GetResult(); 
        }
    }
}
