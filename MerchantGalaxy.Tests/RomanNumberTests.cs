using MerchantGalaxy.RomanNumerals;
using System;
using Xunit;

namespace MerchantGalaxy.Tests
{
    public class RomanNumberTests
    {
        [Fact]
        public void ValidRomanNumberTest()
        {
            Assert.True(RomanNumeralConverter.IsValid("MMVI"));
        }

        [Fact]
        public void MaximumLimitPerCharacterExceededTest()
        {
            Assert.False(RomanNumeralConverter.IsValid("MMCCD"));
        }

        [Fact]
        public void InvalidRomanStringTest()
        {
            Assert.False(RomanNumeralConverter.IsValid("MLM"));
        }

        [Fact]
        public void ConvertRomanNumberTest1()
        {
            Assert.Equal(2006, RomanNumeralConverter.ConvertRomanNumber("MMVI"));
        }

        [Fact]
        public void ConvertRomanNumberTest2()
        {
            Assert.Equal(1944, RomanNumeralConverter.ConvertRomanNumber("MCMXLIV"));
        }

        [Fact]
        public void InvalidConvertRomanNumberTest()
        {
            Assert.Throws<InvalidRomanNumberException>(() => RomanNumeralConverter.ConvertRomanNumber("MCCM"));
        }

        [Fact]
        public void InvalidRomanCharacterTest()
        {
            Assert.Throws<InvalidRomanSymbolException>(() => RomanNumeralConverter.GetRomanSymbolValue('A'));
        }
    }
}
