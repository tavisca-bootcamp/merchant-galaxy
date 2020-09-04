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
    public class UnitExpression : IExpression
    {
        private AliasMapper _aliasMap;
        private MetalMapper _metalMap;
        private IDecimalConverter _converter;
        private ExpressionValidationHelper _helper;

        public UnitExpression(AliasMapper aliasMap, MetalMapper metalMap, IDecimalConverter converter, ExpressionValidationHelper helper)
        {
            _aliasMap = aliasMap;
            _metalMap = metalMap;
            _converter = converter;
            _helper = helper;
        }

        public void Execute(string input)
        {
            string[] parts = Regex.Split(input, Constant.ExpressionSplitter, RegexOptions.IgnoreCase);
            string[] wordsInFirstPart = parts[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] wordsInSecondPart = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            double decimalPrice = 0;
            double.TryParse(wordsInSecondPart[0], out decimalPrice);

            string metal = wordsInFirstPart[wordsInFirstPart.Length - 1];
            string aliasValue = string.Empty;
            string roman = CreateRomanNumeralsFromAliases(wordsInFirstPart);

            //Convert Roman to decimal
            double? totalUnits = _converter.ToDecimal(roman);

            if (totalUnits.HasValue)
                _metalMap.AddMetal(metal, decimalPrice / totalUnits.Value);

        }

        private string CreateRomanNumeralsFromAliases(string[] wordsInFirstPart)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < wordsInFirstPart.Length - 1; i++)
            {
                sb.Append(_aliasMap.GetValueForAlias(wordsInFirstPart[i]));
            }

            return sb.ToString();
        }

        public bool Match(string input)
        {
            string[] parts = Regex.Split(input, Constant.ExpressionSplitter, RegexOptions.IgnoreCase);
            if (parts.Length != 2) return false;

            string[] wordsInFirstPart = parts[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] wordsInSecondPart = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double output;

            return input.EndsWith(Constant.Credits, StringComparison.OrdinalIgnoreCase) &&
                    !input.StartsWith(Constant.MetalExpression, StringComparison.OrdinalIgnoreCase) && parts.Length == 2 &&
                    wordsInSecondPart.Length == 2 && Double.TryParse(wordsInSecondPart[0], out output) &&
                    _helper.AreWordsValidAliases(wordsInFirstPart.Take(wordsInFirstPart.Length - 1).ToArray());
        }
    }
}
