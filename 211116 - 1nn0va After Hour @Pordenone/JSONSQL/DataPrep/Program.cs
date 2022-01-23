using DataPrep.Importers;
using System;

namespace DataPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            new RelationalImporter()
                .Movies()
                .Reviews();

            new JsonImporter()
                .Hybrid()
                .Full();

            new PlaygroundImporter()
                .Go();
                
        }
    }
}
