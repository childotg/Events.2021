using Producer;
using System;

namespace CDaysProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            new ProducerTask().RunAsync().GetAwaiter().GetResult();
        }
    }
}
