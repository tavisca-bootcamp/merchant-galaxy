using Merchant_Galaxy.Interfaces;
using System;

namespace Merchant_Galaxy.Rules {
    public class CanNotBeRepeatedFourTimes : IRules {

        //private static CanNotBeRepeatedFourTimes canBeRepeatedFourTimes = null;

        //private CanNotBeRepeatedFourTimes() {

        //}

        //public static CanNotBeRepeatedFourTimes GetInstance() {
        //    if (canBeRepeatedFourTimes == null) {
        //        canBeRepeatedFourTimes = new CanNotBeRepeatedFourTimes();
        //    }
        //    return canBeRepeatedFourTimes;
        //}

        public bool ExecuteRule(string input) {
            bool result = (input.Length < 4) || !(input.Contains("IIII") || input.Contains("XXXX") || input.Contains("CCCC") || input.Contains("MMMM"));

            if (!result) { Console.WriteLine("CanNotBeRepeatedFourTimes Rule has been violated"); }

            return result;
        }
    }
}
