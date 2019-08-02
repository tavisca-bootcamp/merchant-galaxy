using System;

namespace MerchantGalaxy.RomanNumerals
{
    public class InvalidRomanNumberException : Exception
    {
        public InvalidRomanNumberException()
        {
        }

        public InvalidRomanNumberException(string message) : base(message)
        {
        }

        public InvalidRomanNumberException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}