using System;
using System.Collections.Generic;
using System.Text;

namespace merchant_galaxy.Mapper
{
    class AliasMap
    {
        public AliasMap()
        {

        }
        public Dictionary<string, string> MakeAliases(List<string> aliasLines)
        {
            var aliases = new Dictionary<string, string>();
            foreach(var alias in aliasLines)
            {
                string[] kvp = alias.Split(" is ");
                if (kvp.Length == 2)
                {
                    aliases[kvp[0]] = kvp[1];
                }
            }
            //foreach(var ss in aliases)
            //    Console.WriteLine(ss.Key + " : " + ss.Value);
            
            return aliases;
        }

    }
}
