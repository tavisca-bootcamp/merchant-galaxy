using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGalaxy.Conversations
{
    public class InputLineFilter
    {
        private LineType _lineType;
        private string _pattern;

        public InputLineFilter(LineType lineType, string pattern)
        {
            _lineType = lineType;
            _pattern = pattern;
        }

        public LineType lineType
        {
            get =>  _lineType;
        }

        public string Pattern
        {
            get => _pattern;
        }

    }
}
