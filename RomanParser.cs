using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGalaxy
{
    public class RomanParser:ConversionRomanToDecimal
    {
        private int decimal_unit;
        public int Parser(string symbols)
        {
            
            if (symbols == null)
                return 0;
            if (symbols.Length == 1)
            {
                roman_symbol_table.TryGetValue(symbols[0], out int roman_value);
            
                return roman_value;
            }
            decimal_unit = 0;
          
            for (int i = 0; i < symbols.Length; i++)
            {
                if (i + 1 < symbols.Length)
                {
                    roman_symbol_table.TryGetValue(symbols[i + 1], out int greater_index_value);
                    roman_symbol_table.TryGetValue(symbols[i], out int smaller_index_value);
                    if (smaller_index_value >= greater_index_value)
                    
                        decimal_unit += smaller_index_value;
                    
                    else
                    {
                        
                       decimal_unit = decimal_unit + greater_index_value - smaller_index_value;
                        i++;
                    }
                }
                else
                {
                    roman_symbol_table.TryGetValue(symbols[i], out int roman_value);
                    decimal_unit += roman_value;
                }
            }
         
            return decimal_unit;
        }
    }
}
