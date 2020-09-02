using System;

namespace Merchant_Galaxy.Roman {
    /// <summary>
    /// This class defines the Roman Numeral System.
    /// </summary>
    public class RomanLetters
        {
                private static string alphabet = "IVXLCDM";

                public static string GetAlphabet()
                {
                        return alphabet;
                }

                public static bool IsSmaller(string first, string second)
                {
                        return alphabet.IndexOf(first, StringComparison.OrdinalIgnoreCase) < 
                                alphabet.IndexOf(second, StringComparison.OrdinalIgnoreCase);
                }
        }
}
