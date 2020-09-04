using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGuideToGalaxyApp.Contract
{
    public interface IRule
    {
        bool Execute(string input);
    }
}
