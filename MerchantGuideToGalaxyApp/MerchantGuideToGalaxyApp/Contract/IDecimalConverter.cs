using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGuideToGalaxyApp.Contract
{
    public interface IDecimalConverter
    {
        double? ToDecimal(string input);
    }
}
