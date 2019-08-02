using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MerchantGalaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Processor processor = new Processor();
            var output = processor.ReadInput();

            foreach(var element in output)
            {
                Console.WriteLine(element);
            }
            
            Console.ReadKey(true);
        }
    }
}
