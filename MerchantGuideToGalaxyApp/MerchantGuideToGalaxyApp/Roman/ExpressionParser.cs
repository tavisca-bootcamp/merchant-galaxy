using MerchantGuideToGalaxyApp.Contract;
using MerchantGuideToGalaxyApp.Mapper;
using MerchantGuideToGalaxyApp.Roman.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerchantGuideToGalaxyApp
{
    public class ExpressionParser
    {
        private List<IExpression> expressions;
        private ExpressionValidationHelper helper;

        public ExpressionParser(PseudonymMapper pseudonymMap, IDecimalConverter converter, MetalMapper metalMap)
        {
            helper = new ExpressionValidationHelper(pseudonymMap, metalMap);
            expressions = GetExpressions(pseudonymMap, converter, metalMap, helper);
        }

        public void Parse(string input)
        {
            input = input.ToUpper();
            var matchingExpression = expressions.FirstOrDefault(e => e.Match(input));
            if (matchingExpression == null) Console.WriteLine("I have no idea what you are talking about");
            else matchingExpression.Execute(input);
        }

        private List<IExpression> GetExpressions(PseudonymMapper pseudonymMap, IDecimalConverter converter, MetalMapper metalMap, ExpressionValidationHelper helper)
        {
            List<IExpression> expressions = new List<IExpression>();
            expressions.Add(new PseudonymExpression(pseudonymMap));
            expressions.Add(new UnitExpression(pseudonymMap, metalMap, converter, helper));
            expressions.Add(new PseudonymQuestionExpression(pseudonymMap, converter, helper));
            expressions.Add(new UnitQuestionExpression(pseudonymMap, metalMap, converter, helper));
            expressions.Add(new MetalExpression(pseudonymMap,metalMap, converter, helper));

            return expressions;
        }
    }
}
