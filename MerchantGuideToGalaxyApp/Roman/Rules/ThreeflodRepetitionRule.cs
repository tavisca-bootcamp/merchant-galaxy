using MerchantGuideToGalaxyApp.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGuideToGalaxyApp.Rules
{
    public class ThreeflodRepetitionRule :IRule
    {
        public bool Execute(string input)
        {
            bool result = (input.Length < 4) || !(input.Contains("IIII") || input.Contains("XXXX") || input.Contains("CCCC") || input.Contains("MMMM"));

            if (!result) { Console.WriteLine("CantBeRepeated4Times Rule has been violated"); }

            return result;
        }
    }
}
