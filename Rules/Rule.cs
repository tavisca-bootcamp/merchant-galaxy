using System;
using System.Collections.Generic;
using System.Text;

namespace merchant_galaxy.Rules
{
    public class Rule
    {
        public Rule()
        {

        }
        public bool ApplyAllRules(string RomanNumber)
        {
            // D, L and V cannot be repeated
            if(Count(RomanNumber, 'D') > 1 || Count(RomanNumber, 'L') > 1 || Count(RomanNumber, 'V') > 1)
            {
                return false;
            }

            // I, X, C, ans M cannot be repeated four times
            if(RomanNumber.Contains("IIII") || RomanNumber.Contains("XXXX") || RomanNumber.Contains("CCCC") || RomanNumber.Contains("MMMM"))
            {
                return false;
            }

            // "I" can be subtracted from "V" and "X" only
            if(RomanNumber.Contains("ID") || RomanNumber.Contains("IC") || RomanNumber.Contains("IM") || RomanNumber.Contains("IL"))
            {
                return false;
            }

            // "X" can be subtracted from "L" and "C" only 
            if (RomanNumber.Contains("XD") || RomanNumber.Contains("XM"))
            {
                return false;
            }

            // "C" can be subtracted from "D" and "M" only (always true)
            // "V", "L", and "D" can never be subtracted
            if (RomanNumber.Contains("VX") || RomanNumber.Contains("VL") || RomanNumber.Contains("VC") || RomanNumber.Contains("VD") || RomanNumber.Contains("VM"))
            {
                return false;
            }
            if (RomanNumber.Contains("LC") || RomanNumber.Contains("LD") || RomanNumber.Contains("LM"))
            {
                return false;
            }
            if (RomanNumber.Contains("DM"))
            {
                return false;
            }
            return true;
        }

        public static int Count(string ss, char R)
        {
            int count = 0;
            foreach(char ch in ss)
            {
                if (ch == R)
                    count++;
            }
            return count;
        }
    }
}
