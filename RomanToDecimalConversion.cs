using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MerchantGalaxyProblem
{
   public class RomanToDecimalConversion
    {
        Dictionary<char, int> RomanMapper;
        public RomanToDecimalConversion()
        {
            RomanMapper = new Dictionary<char, int>();
            RomanMapper['I'] = 1;
            RomanMapper['V'] = 5;
            RomanMapper['X'] = 10;
            RomanMapper['L'] = 50;
            RomanMapper['C'] = 100;
            RomanMapper['D'] = 500;
            RomanMapper['M'] = 1000;
        }

        public int convert(string romanString)
        {
            int result = 0; int i;
            for (i = 0; i < romanString.Length - 1; i++)
            {
                if (RomanMapper[romanString[i]] < RomanMapper[romanString[i + 1]])
                {
                    result += (RomanMapper[romanString[i + 1]] - RomanMapper[romanString[i]]);
                    i += 1;
                }
                else
                {
                    result += RomanMapper[romanString[i]];
                }

            }
            if (i != romanString.Length)
                result += RomanMapper[romanString[romanString.Length - 1]];

            return result;
        }
    }
}
