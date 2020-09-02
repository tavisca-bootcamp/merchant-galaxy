using MerchantGuideToGalaxyApp.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGuideToGalaxyApp
{
    public class ExpressionValidationHelper
    {
        private PseudonymMapper _pseudonymMap;
        private MetalMapper _metalMap;

        public ExpressionValidationHelper(PseudonymMapper pseudonymMap, MetalMapper metalMap)
        {
            _pseudonymMap = pseudonymMap;
            _metalMap = metalMap;
        }

        public bool AreWordsValidAliases(string[] words)
        {
            foreach (string word in words) { if (!_pseudonymMap.Exists(word)) { return false; } }
            return true;
        }

        public bool AreWordsValidCommodities(string[] words)
        {
            foreach (string word in words) { if (!_metalMap.Exists(word)) { return false; } }
            return true;
        }
    }
}
