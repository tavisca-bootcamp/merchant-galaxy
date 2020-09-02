using Merchant_Galaxy;
using Merchant_Galaxy.Common;
using Merchant_Galaxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Merchant_Galaxy.Roman {
    /// <summary>
    /// This class parses the expressions given to the program and executes the expected actions based on the expressions.
    /// </summary>
    public class ExpressionParser
        {
                private List<IExpression> expressions;
                private ExpressionValidationHelper helper;

                public ExpressionParser(AliasMapper aliasMap, IDecimalConverter converter, CommodityIndex commodityIndex)
                {
                        helper = new ExpressionValidationHelper(aliasMap, commodityIndex);
                        expressions = RomanToDecimalFactory.GetExpressions(aliasMap, converter, commodityIndex, helper);
                }

                public void Parse(string input)
                {
                        var matchingExpression = expressions.FirstOrDefault(e => e.Match(input));
                        if (matchingExpression == null) Console.WriteLine("I have no idea what you are talking about");
                        else matchingExpression.Execute(input);
                }
        }
}
