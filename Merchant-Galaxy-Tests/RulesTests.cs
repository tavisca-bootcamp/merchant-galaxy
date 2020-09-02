using Merchant_Galaxy.Rules;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xunit;

namespace Merchant_Galaxy_Tests {
    public class RulesTests {
        [Fact]
        public void TestCantBeRepeatedRule() {
            CanNotBeRepeated rule = new CanNotBeRepeated();
            Assert.False(rule.ExecuteRule("MMDD"));
            Assert.False(rule.ExecuteRule("XVIV"));
            Assert.True(rule.ExecuteRule("XXIV"));
        }

        [Fact]
        public void TestCantBeRepeated4TimesRule() {
            CanNotBeRepeatedFourTimes rule = new CanNotBeRepeatedFourTimes();
            Assert.False(rule.ExecuteRule("XXXX"));
            Assert.True(rule.ExecuteRule("IXIXIXIX"));
            Assert.True(rule.ExecuteRule("XXXIX"));
        }

        [Fact]
        public void TestSingleSubtractionRule() {
            SubtractSmallerValueFromLarger rule = new SubtractSmallerValueFromLarger();
            Assert.False(rule.ExecuteRule("IIX"));
            Assert.False(rule.ExecuteRule("CCM"));
            Assert.True(rule.ExecuteRule("XXIV"));
        }

        [Fact]
        public void TestSubtractionRule() {
            SubtractionNotAllowed rule = new SubtractionNotAllowed();
            Assert.False(rule.ExecuteRule("CIL"));
            Assert.False(rule.ExecuteRule("MXD"));
            Assert.True(rule.ExecuteRule("XIX"));
        }
    }
}
