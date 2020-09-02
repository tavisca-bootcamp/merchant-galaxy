using Merchant_Galaxy.Common;
using Merchant_Galaxy.Interfaces;
using System;

namespace Merchant_Galaxy.Roman.ExpressionTypes {
    public class AliasExpressionType : IExpression {
        private AliasMapper aliasMap;

        public AliasExpressionType(AliasMapper aliasMap) {
            this.aliasMap = aliasMap;
        }

        public void Execute(string input) {
            string[] parts = input.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);

            string roman = parts[1];
            aliasMap.AddAlias(parts[0], parts[1]);
        }

        public bool Match(string input) {
            string romanAlphabet = RomanLetters.GetAlphabet();
            string[] parts = input.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2) return false;

            string roman = parts[1];
            bool found = false;

            for (int i = 0; i < romanAlphabet.Length; i++) {
                if (String.Equals(roman, romanAlphabet[i].ToString(), StringComparison.OrdinalIgnoreCase)) {
                    found = true;
                    break;
                }
            }

            return found;
        }
    }
}
