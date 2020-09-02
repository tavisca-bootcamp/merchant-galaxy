using MerchantGuideToGalaxyApp.Contract;
using MerchantGuideToGalaxyApp.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MerchantGuideToGalaxyApp.Roman.Expressions
{
    public class MetalExpression : IExpression
    {
        private PseudonymMapper _pseudonymMap;
        private MetalMapper _metalMap;
        private IDecimalConverter _converter;
        private ExpressionValidationHelper _helper;

        public MetalExpression(PseudonymMapper pseudonymMap, MetalMapper metalMap, IDecimalConverter converter, ExpressionValidationHelper helper)
        {
            _pseudonymMap = pseudonymMap;
            _metalMap = metalMap;
            _converter = converter;
            _helper = helper;
        }

        public void Execute(string input)
        {
            //Remove question mark
            input = input.ToUpper().Substring(0, input.Length - 1);

            string[] parts = input.Split(new string[] { " IS " }, StringSplitOptions.RemoveEmptyEntries);

            string[] preIsWords = parts[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] postIsWords = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string sourceMetal = postIsWords.Skip(postIsWords.Length - 1).ToString();
            string destinationMetal = preIsWords[2];

            string[] aliases = postIsWords.Take(postIsWords.Length - 1).ToArray();

            StringBuilder sb = new StringBuilder();

            //Create Roman Numeral from aliases
            for (int i = 0; i < aliases.Length - 1; i++)
            {
                sb.Append(_pseudonymMap.GetValueForPseudonym(aliases[i]));
            }

            double sourceMetalPrice = _metalMap.GetPriceByMetal(sourceMetal);
            double destinationMetalPrice = _metalMap.GetPriceByMetal(destinationMetal);

            //Convert Roman to Decimal
            double? totalUnits = _converter.ToDecimal(sb.ToString());
            if (totalUnits.HasValue)
            {
                double totalSourceCommodity = sourceMetalPrice * totalUnits.Value;
                Console.WriteLine(String.Format("{0} is {1} {2}", parts[1], (totalSourceCommodity / destinationMetalPrice), destinationMetal));
            }
        }

        public bool Match(string input)
        {
            //Remove question mark
            input = input.ToUpper().Substring(0, input.Length - 1);

            bool isQuestion = (input.StartsWith("HOW MANY", StringComparison.OrdinalIgnoreCase));
            if (!isQuestion) return false;

            string[] parts = input.Split(new string[] { " IS " }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) return false;

            string[] preIsWords = parts[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (preIsWords.Length < 3) return false;

            string[] postIsWords = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (postIsWords.Length < 2) return false;

            return _helper.AreWordsValidCommodities(preIsWords.Skip(preIsWords.Length - 1).ToArray()) &&
                    _helper.AreWordsValidCommodities(postIsWords.Skip(postIsWords.Length - 1).ToArray()) &&
                    _helper.AreWordsValidAliases(postIsWords.Take(postIsWords.Length - 1).ToArray());
        }
    }
}
