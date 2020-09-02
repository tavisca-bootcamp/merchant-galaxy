using Merchant_Galaxy.Common;
using Merchant_Galaxy.Interfaces;
using Merchant_Galaxy.Roman.ExpressionTypes;
using Merchant_Galaxy.Rules;
using System.Collections.Generic;

namespace Merchant_Galaxy.Roman {
    /// <summary>
    /// This class establishes the rules for a Roman to Decimal conversion.
    /// </summary>
    public class RomanToDecimalFactory
        {
                public static List<IRules> GetRules()
                {
                        List<IRules> rules = new List<IRules>();
                        rules.Add(new CanNotBeRepeated());
                        rules.Add(new CanNotBeRepeatedFourTimes());
                        rules.Add(new SubtractSmallerValueFromLarger());
                        rules.Add(new SubtractionNotAllowed());

                        return rules;
                }

                public static List<IExpression> GetExpressions(AliasMapper aliasMap, IDecimalConverter converter, CommodityIndex commodityIndex, ExpressionValidationHelper helper)
                {
                        List<IExpression> expressions = new List<IExpression>();
                        expressions.Add(new AliasExpressionType(aliasMap));
                        expressions.Add(new UnitExpressionType(commodityIndex, aliasMap, converter, helper));
                        expressions.Add(new AliasQuestionExpressionType(aliasMap, converter, helper));
                        expressions.Add(new UnitQuestionExpressionType(commodityIndex, aliasMap, converter, helper));
                        expressions.Add(new CommodityConversionExpressionType(commodityIndex, aliasMap, converter, helper));

                        return expressions;
                }
        }
}
