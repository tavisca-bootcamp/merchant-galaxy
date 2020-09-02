using MerchantGuideToGalaxyApp.Contract;
using MerchantGuideToGalaxyApp.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGuideToGalaxyApp.Roman.Expressions
{
    public class PseudonymQuestionExpression : IExpression
    {
        private PseudonymMapper _pseudonymMap;
        private IDecimalConverter _converter;
        private ExpressionValidationHelper _helper;

        public PseudonymQuestionExpression(PseudonymMapper pseudonymMap, IDecimalConverter converter, ExpressionValidationHelper helper)
        {
            _pseudonymMap = pseudonymMap;
            _converter = converter;
            _helper = helper;
        }

        public void Execute(string input)
        {
            //Remove question mark
            input = input.ToUpper().Substring(0, input.Length - 1);

            StringBuilder sb = new StringBuilder();
            string[] parts = input.Split(new string[] { " IS " }, StringSplitOptions.RemoveEmptyEntries);
            string[] words = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (!_pseudonymMap.Exists(word))
                {
                    Console.WriteLine(String.Format("Error while processing this input: {0}", input));
                    return;
                }
                sb.Append(_pseudonymMap.GetValueForPseudonym(word));
            }

            Console.WriteLine(String.Format("{0} is {1}", parts[1], _converter.ToDecimal(sb.ToString())));
        }

        public bool Match(string input)
        {
            //Remove question mark from the last alias
            input = input.ToUpper().Substring(0, input.Length - 1);

            bool isQuestion = (input.StartsWith("HOW MUCH", StringComparison.OrdinalIgnoreCase));
            if (!isQuestion) return false;

            string[] parts = input.Split(new string[] { " IS " }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) return false;

            string[] words = parts[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length < 1) return false;

            return _helper.AreWordsValidAliases(words);
        }
    }

}
