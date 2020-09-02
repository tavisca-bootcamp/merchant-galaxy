using MerchantGuideToGalaxyApp.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerchantGuideToGalaxyApp.Roman.Rules
{
    public class NoSubtractionRule : IRule
    {
        public bool Execute(string input)
        {
            bool result = (input.Length < 2) ||
                                !(input.Contains("VX") || input.Contains("VL") || input.Contains("VC") || input.Contains("VD") ||
                                input.Contains("VM") || input.Contains("LC") || input.Contains("LD") || input.Contains("LM")
                                || input.Contains("DM"));

            if (!result) { Console.WriteLine("NoSubtraction Rule has been violated"); }

            return result;
        }
    }
}
