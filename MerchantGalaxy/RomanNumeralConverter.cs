using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MerchantGalaxy.RomanNumerals
{
    public class RomanNumeralConverter
    {
        public static int ConvertRomanNumber(string romanNumber)
        {
            if (!IsValid(romanNumber))
                throw new InvalidRomanNumberException();

            var romanValues = romanNumber.Select(GetRomanSymbolValue).ToArray();
            var Result = 0;

            for(int i = 0; i < romanValues.Length; i++)
            {
                var currentValue = romanValues[i];
                var nextValue = (i + 1) < romanValues.Length ? romanValues[i + 1] : 0;
                currentValue = nextValue > currentValue ? -currentValue : currentValue;
                Result += currentValue;
            }
            return Result;
        }
        /*
         *    I,X,C,M => 3 times succession, 4  if separated by smallone
         *    D,L,V => dont repeat
         *    I => can subtract from V,X
         *    X => can subtract from L,C
         *    C => can subtract from D,M
         *    V,L,D => cannot be subtracted
         *    only one small value before a larger one
         *    M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})
         * */
        public static bool IsValid(string romanString)
        {
            var match = Regex.Match(romanString, @"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");
            return match.Success;
        }

        public static int GetRomanSymbolValue(char romanSymbol)
        {
            switch (romanSymbol)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default:
                    throw new InvalidRomanSymbolException();
            }
        }

    }
}
