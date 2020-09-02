using Merchant_Galaxy.Interfaces;
using System;
using System.Linq;

namespace Merchant_Galaxy.Rules {
    public class CanNotBeRepeated : IRules {

        //private static CanNotBeRepeated canNotBeRepeated = null;

        //private CanNotBeRepeated() {

        //}

        //public static CanNotBeRepeated GetInstance() {
        //    if (canNotBeRepeated == null) {
        //        canNotBeRepeated = new CanNotBeRepeated();
        //    }
        //    return canNotBeRepeated;
        //}

        public bool ExecuteRule(string input) {
            bool result = (input.Length < 2) || (input.Count(C => C == 'D') <= 1 && input.Count(C => C == 'L') <= 1 && input.Count(C => C == 'V') <= 1);

            if (!result) { Console.WriteLine("CanNotBeRepeated Rule has been violated"); }

            return result;
        }
    }
}
