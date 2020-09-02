using MerchantGuideToGalaxyApp.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerchantGuideToGalaxyApp.Rules
{
    public class NoRepetitionRule :IRule
    {
        public bool Execute(string input)
        {
            bool result = (input.Length < 2) ||
                    (input.Count(c => c == 'D') <= 1 && input.Count(c => c == 'L') <= 1 && input.Count(c => c == 'V') <= 1);

            if (!result) { Console.WriteLine("NoRepetition Rule has been violated"); }

            return result;
        }
    }
}
