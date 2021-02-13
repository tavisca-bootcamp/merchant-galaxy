using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGalaxy
{
    public class ConversionRomanToDecimal
    {
        public static Dictionary<char, int> roman_symbol_table = new Dictionary<char, int>();
        public void SymbolValuesConversion()
        {
            roman_symbol_table.Add('I', 1);
            roman_symbol_table.Add('V', 5);
            roman_symbol_table.Add('X', 10);
            roman_symbol_table.Add('L', 50);
            roman_symbol_table.Add('C', 100);
            roman_symbol_table.Add('D', 500);
            roman_symbol_table.Add('M', 1000);
        }

    }
}
