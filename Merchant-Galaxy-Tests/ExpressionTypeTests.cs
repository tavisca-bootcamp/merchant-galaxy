using Merchant_Galaxy;
using Merchant_Galaxy.Common;
using Merchant_Galaxy.Roman;
using Merchant_Galaxy.Roman.ExpressionTypes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Merchant_Galaxy_Tests {
    public class ExpressionTypeTests {
        [Fact]
        public void AliasExpressionTest() {
            AliasMapper aliasMap = new AliasMapper();
            AliasExpressionType expression = new AliasExpressionType(aliasMap);
            Assert.True(expression.Match("glob is C"));
            Assert.False(expression.Match("glob is N"));
            expression.Execute("glob is C");
            Assert.True(aliasMap.Exists("glob"));
            Assert.True(String.Equals(aliasMap.GetValueForAlias("glob"), "C"));
        }

        [Fact]
        public void UnitExpressionTest() {
            AliasMapper aliasMap = new AliasMapper();
            RomanConverter converter = new RomanConverter();
            CommodityIndex commodityIndex = new CommodityIndex();
            aliasMap.AddAlias("glob", "C");
            aliasMap.AddAlias("pish", "X");
            ExpressionValidationHelper helper = new ExpressionValidationHelper(aliasMap, commodityIndex);
            UnitExpressionType expression = new UnitExpressionType(commodityIndex, aliasMap, converter, helper);
            expression.Execute("pish glob Iron is 7020 Credits");
            Assert.True(commodityIndex.Exists("Iron"));
            Assert.Equal<double>(78, commodityIndex.GetPriceByCommodity("Iron"));
            expression.Execute("pish glob Iron is 6300 Credits");
            Assert.Equal<double>(70, commodityIndex.GetPriceByCommodity("Iron"));
        }
    }
}
