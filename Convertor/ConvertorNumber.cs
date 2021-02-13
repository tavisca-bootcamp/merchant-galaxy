using System;
using System.Collections.Generic;
using System.Text;
using merchant_galaxy.Rules;

namespace merchant_galaxy.Convertor
{
    

    public class ConvertorNumber
    {
        public static Dictionary<char, int> ROMAN_VALUE = new Dictionary<char, int>() 
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };
        
        public ConvertorNumber()
        {

        }
        public double RomanToDecimal(string roman)
        {
            Rule r = new Rule();
            bool isValidNumber = r.ApplyAllRules(roman);
            if(isValidNumber == false)
            {
                Console.WriteLine("ROMAN NUMBER IS INVALID");
            }

            double ans = 0;
            for(int i = 0; i < roman.Length; ++i)
            {
                if(i+1 < roman.Length && ROMAN_VALUE[roman[i]] < ROMAN_VALUE[roman[i+1]])
                {
                    ans += ROMAN_VALUE[roman[i + 1]] - ROMAN_VALUE[roman[i]];
                    ++i;
                }
                else
                {
                    ans += ROMAN_VALUE[roman[i]];
                }
            }
            return ans;
        }
    }
}
