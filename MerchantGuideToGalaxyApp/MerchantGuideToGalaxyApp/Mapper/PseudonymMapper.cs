using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGuideToGalaxyApp.Mapper
{
    public class PseudonymMapper
    {
        private Dictionary<string, string> pseudonymMap;
        public PseudonymMapper()
        {
            pseudonymMap = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
        }

        public void AddPseudonym(string pseudonym, string value)
        {
            if (!pseudonymMap.ContainsKey(pseudonym)) pseudonymMap.Add(pseudonym, value);
            else pseudonymMap[pseudonym] = value;
        }

        public string GetValueForPseudonym(string pseudonym)
        {
            return pseudonymMap[pseudonym];
        }

        public bool Exists(string pseudonym)
        {
            return pseudonymMap.ContainsKey(pseudonym);
        }
    }
}
