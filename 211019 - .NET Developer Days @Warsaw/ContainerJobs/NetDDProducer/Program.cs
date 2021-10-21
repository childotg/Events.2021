using System;

namespace NetDDProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            new ProducerTask().RunAsync().GetAwaiter().GetResult();
        }
    }
}
