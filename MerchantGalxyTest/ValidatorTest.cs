using System;
using System.Text;
using Merchant_Galaxy;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MerchantGalxyTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ValidatorTest
    {
        

       

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
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
