using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant_Galaxy
{
    public class RomanNumberValidator
    {
        private string[] InvalidRomanNumberPattern = new string[]
        {
            "IIII","XXXX","CCCC","MMMM",
            "DD","LL","VV",
            "IL","IC","ID","IM",
            "XD","XM",
            "VX","VL","VC","VD","VM",
            "LC","LD","LM",
            "DM"
        };

        public bool Validate(string numeral)
        {
            foreach(var invalidPattern in InvalidRomanNumberPattern)
            {
                if(numeral.Contains(invalidPattern))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
