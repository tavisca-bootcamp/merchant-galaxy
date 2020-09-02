using System.Collections.Generic;

namespace Merchant_Galaxy.Common {
    public class CommodityIndex {
        private Dictionary<string, double> commodityMap;

        public CommodityIndex() {
            commodityMap = new Dictionary<string, double>();
        }

        public void AddCommodity(string name, double perUnitPrice) {
            if (!commodityMap.ContainsKey(name)) commodityMap.Add(name, perUnitPrice);
            else commodityMap[name] = perUnitPrice;
        }

        public double GetPriceByCommodity(string commodity) {
            return commodityMap[commodity];
        }

        public bool Exists(string commodity) {
            return commodityMap.ContainsKey(commodity);
        }
    }
}
