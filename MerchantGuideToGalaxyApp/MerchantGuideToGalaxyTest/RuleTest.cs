using MerchantGuideToGalaxyApp.Rules;
using System;
using Xunit;

namespace MerchantGuideToGalaxyTest
{
    public class RuleTest
    {
        [Fact]
        public void TestNoRepetitionRule ()
        {
            NoRepetitionRule rule1 = new NoRepetitionRule();
            Assert.False(rule1.Execute("MDDCI"));
            Assert.False(rule1.Execute("MLLLDC"));
            Assert.False(rule1.Execute("MVVVCI"));
            Assert.True(rule1.Execute("MMDC"));
            Assert.True(rule1.Execute("MDCC"));
        }

        [Fact]
        public void TestThreeFoldRepetitionRule()
        {
            ThreeflodRepetitionRule rule2 = new ThreeflodRepetitionRule();
            Assert.False(rule2.Execute("MXXXXCI"));
            Assert.False(rule2.Execute("MMMMDC"));
            Assert.False(rule2.Execute("MCCCCI"));
            Assert.False(rule2.Execute("MMDCIIII"));
            Assert.True(rule2.Execute("MXXXDXCC"));
            Assert.True(rule2.Execute("MMMDMCC"));
            Assert.True(rule2.Execute("MDMCCCMC"));
            Assert.True(rule2.Execute("MDMIIIXI"));
        }

        [Fact]
        public void TestSingleSubtraction()
        {
            SingleSubtraction rule3 = new SingleSubtraction();
            Assert.False(rule3.Execute("IIX"));
            Assert.False(rule3.Execute("CCM"));
            Assert.True(rule3.Execute("XXIV"));
        }

        [Fact]
        public void TestNoSubtraction()
        {
            Subtraction rule4= new Subtraction();
            Assert.False(rule4.Execute("CIL"));
            Assert.False(rule4.Execute("MXD"));
            Assert.True(rule4.Execute("XIX"));
        }
    }
}
