using System;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            new ProducerTask().RunAsync().GetAwaiter().GetResult();
        }
    }
}
