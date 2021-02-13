using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantGalaxyProblem;

namespace MerchantGalaxyTest
{
    [TestClass]
    public class MerchantGalaxyTest
    {
        [TestMethod]
        public void multipleOccranceValidTest()
        {
            RomanNumberValidator vl = new RomanNumberValidator();
            bool actual = vl.Validate("XXXIX");
            bool expected = true;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void multipleOccranceInValidTest()
        {
            RomanNumberValidator vl = new RomanNumberValidator();
            bool actual = vl.Validate("XXXX");
            bool expected = false;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void eInValidOrderTest()
        {
            RomanNumberValidator vl = new RomanNumberValidator();
            bool actual = vl.Validate("VXTW");
            bool expected = false;
            Assert.AreEqual(actual, expected);
        }
    }
}
