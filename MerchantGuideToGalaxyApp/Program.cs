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
            try
            {
                string inputPath = "../../input.txt";
                string inputText = File.ReadAllText(inputPath);
                string[] inputLines = inputText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine(inputText);
                Console.WriteLine();

                AliasMapper aliasMap = new AliasMapper();
                IDecimalConverter converter = new RomanConverter();
                MetalMapper metalMap = new MetalMapper();
                ExpressionParser parser = new ExpressionParser(aliasMap, converter, metalMap);

                foreach (string line in inputLines)
                {
                    parser.Parse(line);
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
