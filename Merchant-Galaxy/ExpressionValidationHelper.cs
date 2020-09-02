using Merchant_Galaxy.Common;

namespace Merchant_Galaxy {
    public class ExpressionValidationHelper {
        private AliasMapper aliasMap;
        private CommodityIndex commodityIndex;

        public ExpressionValidationHelper(AliasMapper aliasMap, CommodityIndex commodityIndex) {
            this.aliasMap = aliasMap;
            this.commodityIndex = commodityIndex;
        }

        public bool AreWordsValidAliases(string[] words) {
            foreach (string word in words) { if (!aliasMap.Exists(word)) { return false; } }
            return true;
        }

        public bool AreWordsValidCommodities(string[] words) {
            foreach (string word in words) { if (!commodityIndex.Exists(word)) { return false; } }
            return true;
        }
    }
}
