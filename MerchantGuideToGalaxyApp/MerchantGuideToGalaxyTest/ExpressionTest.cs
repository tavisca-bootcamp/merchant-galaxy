using MerchantGuideToGalaxyApp;
using MerchantGuideToGalaxyApp.Mapper;
using MerchantGuideToGalaxyApp.Roman.Expressions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace MerchantGuideToGalaxyTest
{
    public class ExpressionTest
    {
        [Fact]
        public void PseudonymExpressionTest()
        {
            PseudonymMapper pseudonymMap = new PseudonymMapper();
            PseudonymExpression expression = new PseudonymExpression(pseudonymMap);
            Assert.True(expression.Match("GLOB is I"));
            Assert.False(expression.Match("glob is N"));
            expression.Execute("GLOB is I");
            Assert.True(pseudonymMap.Exists("glob"));
            Assert.Equal("I", pseudonymMap.GetValueForPseudonym("glob"));
        }

        [Fact]
        public void UnitExpressionTest()
        {
            PseudonymMapper pseudonymMap = new PseudonymMapper();
            RomanConverter converter = new RomanConverter();
            MetalMapper metalMap = new MetalMapper();
            pseudonymMap.AddPseudonym("GLOB", "I");
            pseudonymMap.AddPseudonym("pish", "X");
            ExpressionValidationHelper helper = new ExpressionValidationHelper(pseudonymMap, metalMap);
            UnitExpression expression = new UnitExpression(pseudonymMap, metalMap, converter, helper);
            expression.Execute("pish glob Iron is 110 Credits");
            Assert.True(metalMap.Exists("Iron"));
            Assert.Equal<double>(10, metalMap.GetPriceByMetal("Iron"));
            expression.Execute("glob pish Iron is 6300 Credits");
            Assert.Equal<double>(700, metalMap.GetPriceByMetal("Iron"));
        }
    }
}
