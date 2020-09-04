using MerchantGuideToGalaxyApp.Contract;
using MerchantGuideToGalaxyApp.Mapper;
using MerchantGuideToGalaxyApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MerchantGuideToGalaxyApp.Roman.Expressions
{
    public class MetalExpression : IExpression
    {
        private AliasMapper _aliasMap;
        private MetalMapper _metalMap;
        private IDecimalConverter _converter;
        private ExpressionValidationHelper _helper;

        public MetalExpression(AliasMapper aliasMap, MetalMapper metalMap, IDecimalConverter converter, ExpressionValidationHelper helper)
        {
            _aliasMap = aliasMap;
            _metalMap = metalMap;
            _converter = converter;
            _helper = helper;
        }

        public void Execute(string input)
        {
            //Remove question mark
            input = input.Substring(0, input.Length - 1);

            string[] parts = Regex.Split(input, Constant.ExpressionSplitter, RegexOptions.IgnoreCase);

            string[] preIsWords = parts[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] postIsWords = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string sourceMetal = postIsWords.Skip(postIsWords.Length - 1).ToString();
            string destinationMetal = preIsWords[2];

            string[] aliases = postIsWords.Take(postIsWords.Length - 1).ToArray();

            StringBuilder sb = new StringBuilder();

            //Create Roman Numeral from aliases
            for (int i = 0; i < aliases.Length - 1; i++)
            {
                sb.Append(_aliasMap.GetValueForAlias(aliases[i]));
            }

            double sourceMetalPrice = _metalMap.GetPriceByMetal(sourceMetal);
            double destinationMetalPrice = _metalMap.GetPriceByMetal(destinationMetal);

            //Convert Roman to Decimal
            double? totalUnits = _converter.ToDecimal(sb.ToString());
            if (totalUnits.HasValue)
            {
                double total = sourceMetalPrice * totalUnits.Value;
                Console.WriteLine(String.Format("{0} is {1} {2}", parts[1], (total / destinationMetalPrice), destinationMetal));
            }
        }

        public bool Match(string input)
        {
            //Remove question mark
            input = input.Substring(0, input.Length - 1);

            bool isQuestion = (input.StartsWith(Constant.MetalExpression, StringComparison.OrdinalIgnoreCase));
            if (!isQuestion)
                return false;

            string[] parts = Regex.Split(input, Constant.ExpressionSplitter, RegexOptions.IgnoreCase);
            if (parts.Length != 2)
                return false;

            string[] preIsWords = parts[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (preIsWords.Length < 3)
                return false;

            string[] postIsWords = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (postIsWords.Length < 2)
                return false;

            return _helper.AreWordsValidMetals(preIsWords.Skip(preIsWords.Length - 1).ToArray()) &&
                    _helper.AreWordsValidMetals(postIsWords.Skip(postIsWords.Length - 1).ToArray()) &&
                    _helper.AreWordsValidAliases(postIsWords.Take(postIsWords.Length - 1).ToArray());
        }
    }
}
