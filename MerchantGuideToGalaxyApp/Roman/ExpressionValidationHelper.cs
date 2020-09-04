using MerchantGuideToGalaxyApp.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGuideToGalaxyApp
{
    public class ExpressionValidationHelper
    {
        private AliasMapper _aliasMap;
        private MetalMapper _metalMap;

        public ExpressionValidationHelper(AliasMapper aliasMap, MetalMapper metalMap)
        {
            _aliasMap = aliasMap;
            _metalMap = metalMap;
        }

        public bool AreWordsValidAliases(string[] words)
        {
            foreach (string word in words) { if (!_aliasMap.Exists(word)) { return false; } }
            return true;
        }

        public bool AreWordsValidMetals(string[] words)
        {
            foreach (string word in words) { if (!_metalMap.Exists(word)) { return false; } }
            return true;
        }
    }
}
