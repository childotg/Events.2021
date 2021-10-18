using System;

namespace Scraping
{
    class Program
    {
        static void Main(string[] args)
        {
            new ScrapingTask().RunAsync().GetAwaiter().GetResult();
        }
    }
}
