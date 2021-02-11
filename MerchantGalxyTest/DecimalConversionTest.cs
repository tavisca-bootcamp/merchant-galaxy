using System;
using Merchant_Galaxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MerchantGalxyTest
{
    [TestClass]
    public class DecimalConversionTest
    {
        [TestMethod]
        public void PassingSingleRomanNumberTest()
        {
            RomanToDecimalConversion con = new RomanToDecimalConversion();
            int excepted = 10;
            int actual = con.convert("X");
            Assert.AreEqual(excepted, actual);

        }
        [TestMethod]
        public void PassingComplexRomanNumberTest()
        {
            RomanToDecimalConversion con = new RomanToDecimalConversion();
            int excepted =1944;
            int actual = con.convert("MCMXLIV");
            Assert.AreEqual(excepted, actual);

        }
        [TestMethod]
        public void PassingComplexRomanNumber2Test()
        {
            RomanToDecimalConversion con = new RomanToDecimalConversion();
            int excepted = 1903;
            int actual = con.convert("MCMIII");
            Assert.AreEqual(excepted, actual);

        }
    }
}
