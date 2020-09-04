using MerchantGuideToGalaxyApp.Common;
using MerchantGuideToGalaxyApp.Contract;
using MerchantGuideToGalaxyApp.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MerchantGuideToGalaxyApp.Roman.Expressions
{
    public class UnitQuestionExpression : IExpression
    {
        private AliasMapper _aliasMap;
        private MetalMapper _metalMap;
        private IDecimalConverter _converter;
        private ExpressionValidationHelper _helper;

        public UnitQuestionExpression(AliasMapper aliasMap, MetalMapper metalMap, IDecimalConverter converter, ExpressionValidationHelper helper)
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
            string[] words = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string metal = words[words.Length - 1];
            string roman = CreateRomanNumeralsFromAliases(words);

            //Convert Roman to Decimal
            double? totalUnits = _converter.ToDecimal(roman);
            if (totalUnits.HasValue) Console.WriteLine(String.Format("{0}{1}{2}", parts[1], Constant.ExpressionSplitter, totalUnits.Value * _metalMap.GetPriceByMetal(metal)));
        }

        private string CreateRomanNumeralsFromAliases(string[] words)
        {
            StringBuilder sb = new StringBuilder();

            //Create Roman Numeral from aliases
            for (int i = 0; i < words.Length - 1; i++)
            {
                sb.Append(_aliasMap.GetValueForAlias(words[i]));
            }

            return sb.ToString();
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

            string[] words = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length < 1)
                return false;

            return _helper.AreWordsValidAliases(words.Take(words.Length - 1).ToArray()) &&
                    _helper.AreWordsValidMetals(words.Skip(words.Length - 1).ToArray());
        }


    }
}
