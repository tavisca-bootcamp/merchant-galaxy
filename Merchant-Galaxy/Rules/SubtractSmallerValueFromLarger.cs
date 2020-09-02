using Merchant_Galaxy.Interfaces;
using Merchant_Galaxy.Roman;
using System;

namespace Merchant_Galaxy.Rules {
    public class SubtractSmallerValueFromLarger : IRules {
        public bool ExecuteRule(string input) {
            if (input.Length < 3) return true;

            for (int i = input.Length - 1; i >= 2; i--) {
                if (RomanLetters.IsSmaller(input[i - 1].ToString(), input[i].ToString()) &&
                        RomanLetters.IsSmaller(input[i - 2].ToString(), input[i].ToString())) {
                    Console.WriteLine("SubtractSmallerValueFromLarger Rule has been violated");
                    return false;
                }
            }

            return true;
        }
    }
}
