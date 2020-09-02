using Merchant_Galaxy.Interfaces;
using System;

namespace Merchant_Galaxy.Rules {
    public class SubtractionNotAllowed : IRules {
        public bool ExecuteRule(string input) {
            bool result = (input.Length < 2) ||
                                !(input.Contains("IL") || input.Contains("IC") || input.Contains("ID") || input.Contains("IM") ||
                                input.Contains("XD") || input.Contains("XM"));

            if (!result) { Console.WriteLine("Subtraction Rule has been violated"); }

            return result;
        }
    }
}
