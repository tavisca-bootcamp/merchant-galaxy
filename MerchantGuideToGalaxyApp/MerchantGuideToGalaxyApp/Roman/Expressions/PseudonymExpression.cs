using MerchantGuideToGalaxyApp.Contract;
using MerchantGuideToGalaxyApp.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGuideToGalaxyApp.Roman.Expressions
{
    public class PseudonymExpression : IExpression
    {
        private PseudonymMapper _pseudonymMap;

        public PseudonymExpression(PseudonymMapper pseudonymMap)
        {
            _pseudonymMap = pseudonymMap;
        }

        public void Execute(string input)
        {
            string[] parts = input.ToUpper().Split(new string[] { " IS " }, StringSplitOptions.RemoveEmptyEntries);

            string roman = parts[1];
            _pseudonymMap.AddPseudonym(parts[0], parts[1]);
        }

        public bool Match(string input)
        {
            string romanAlphabet = RomanSymbol.GetAlphabet();
            string[] parts = input.ToUpper().Split(new string[] { " IS " }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2) return false;

            string roman = parts[1];
            bool found = false;

            for (int i = 0; i < romanAlphabet.Length; i++)
            {
                if (String.Equals(roman, romanAlphabet[i].ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }
    }
}
