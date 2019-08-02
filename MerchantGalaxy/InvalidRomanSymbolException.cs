using System;

namespace MerchantGalaxy.RomanNumerals
{
    public class InvalidRomanSymbolException : Exception
    {
        public InvalidRomanSymbolException()
        {
        }

        public InvalidRomanSymbolException(string message) : base(message)
        {
        }

        public InvalidRomanSymbolException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}