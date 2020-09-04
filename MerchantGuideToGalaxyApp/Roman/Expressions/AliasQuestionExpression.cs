using MerchantGuideToGalaxyApp.Common;
using MerchantGuideToGalaxyApp.Contract;
using MerchantGuideToGalaxyApp.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MerchantGuideToGalaxyApp.Roman.Expressions
{
    public class AliasQuestionExpression : IExpression
    {
        private AliasMapper _aliasMap;
        private IDecimalConverter _converter;
        private ExpressionValidationHelper _helper;

        public AliasQuestionExpression(AliasMapper aliasMap, IDecimalConverter converter, ExpressionValidationHelper helper)
        {
            _aliasMap = aliasMap;
            _converter = converter;
            _helper = helper;
        }

        public void Execute(string input)
        {
            //Remove question mark
            input = input.Substring(0, input.Length - 1);

            StringBuilder sb = new StringBuilder();
            string[] parts = Regex.Split(input, Constant.ExpressionSplitter, RegexOptions.IgnoreCase);
            string[] words = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (!_aliasMap.Exists(word))
                {
                    Console.WriteLine(String.Format("Error while processing this input: {0}", input));
                    return;
                }
                sb.Append(_aliasMap.GetValueForAlias(word));
            }

            Console.WriteLine(String.Format("{0}{1}{2}", parts[1], Constant.ExpressionSplitter, _converter.ToDecimal(sb.ToString())));
        }

        public bool Match(string input)
        {
            //Remove question mark from the last alias
            input = input.Remove(input.Length - 1);

            bool isQuestion = (input.StartsWith(Constant.AliasQuestionExpression, StringComparison.OrdinalIgnoreCase));
            if (!isQuestion)
                return false;

            string[] parts = Regex.Split(input, Constant.ExpressionSplitter, RegexOptions.IgnoreCase);
            if (parts.Length != 2)
                return false;

            string[] words = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length < 1)
                return false;

            return _helper.AreWordsValidAliases(words);
        }
    }

}
