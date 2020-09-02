using MerchantGuideToGalaxyApp.Contract;
using MerchantGuideToGalaxyApp.Mapper;
using System;
using System.IO;

namespace MerchantGuideToGalaxyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            string path = "../../input.txt";
            string readText = File.ReadAllText(path);
            string[] lines = readText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(readText);
            Console.WriteLine();
            PseudonymMapper pseudonymMap = new PseudonymMapper();
            IDecimalConverter converter = new RomanConverter();
            MetalMapper metalMap = new MetalMapper();
            ExpressionParser parser = new ExpressionParser(pseudonymMap, converter, metalMap);
            foreach (string line in lines)
            {
                parser.Parse(line);
            }
            Console.ReadLine();
        }
    }
}
