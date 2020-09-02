using Merchant_Galaxy.Roman;
using Xunit;

namespace Merchant_Galaxy_Tests {
    public class RomanConverterTests {
        [Fact]
        public void TestConversion() {
            RomanConverter converter = new RomanConverter();
            Assert.Equal<double>(1944, converter.ToDecimal("MCMXLIV").Value);
            Assert.Equal<double>(521, converter.ToDecimal("DXXI").Value);
            Assert.Equal<double>(992, converter.ToDecimal("CMXCII").Value);
            Assert.NotEqual<double>(6, converter.ToDecimal("IV").Value);
        }
    }
}