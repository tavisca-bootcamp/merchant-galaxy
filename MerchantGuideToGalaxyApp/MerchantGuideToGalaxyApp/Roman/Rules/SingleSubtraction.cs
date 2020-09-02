using MerchantGuideToGalaxyApp.Contract;
using MerchantGuideToGalaxyApp.Roman;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGuideToGalaxyApp.Rules
{
    public class SingleSubtraction :IRule
    {
        public bool Execute(string input)
        {
            if (input.Length < 3) return true;

            for (int i = input.Length - 1; i >= 2; i--)
            {
                if (RomanSymbol.IsSmaller(input[i - 1].ToString(), input[i].ToString()) &&
                        RomanSymbol.IsSmaller(input[i - 2].ToString(), input[i].ToString()))
                {
                    Console.WriteLine("SingleSubtraction Rule has been violated");
                    return false;
                }
            }

            return true;
        }
    }
}
