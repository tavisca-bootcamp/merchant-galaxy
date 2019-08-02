using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MerchantGalaxy.Conversations
{
    public class ConversationLine
    {
        private static string _assignedLinePattern = @"^([A-Za-z]+) is (I|V|X|L|C|D|M)$";
        public static string _creditsLinePattern = @"^([A-Za-z\s]+) is ([0-9]+) ([c|C]redits)$";
        public static string _questionHowMuchLinePattern = @"^how much is ([A-Za-z\s]+)\?$";
        public static string _questionHowManyPattern = @"^how many ([c|C]redits) is ([A-Za-z\s]+)\?$";

        private InputLineFilter[] _inputLineFilter;

        public ConversationLine()
        {
            _inputLineFilter =  new InputLineFilter[4];
            _inputLineFilter[0] = new InputLineFilter(LineType.Assigned, _assignedLinePattern);
            _inputLineFilter[1] = new InputLineFilter(LineType.Credits, _creditsLinePattern);
            _inputLineFilter[2] = new InputLineFilter(LineType.Question_How_Much, _questionHowMuchLinePattern);
            _inputLineFilter[3] = new InputLineFilter(LineType.Question_How_Many, _questionHowManyPattern);
        }

        public LineType GetLineType(string line)
        {
            line = line.Trim();
            var lineType = LineType.Nomatch;
            var match = false;

            for(int i = 0; i < _inputLineFilter.Length && !match; i++)
            {
                if(Regex.Match(line, _inputLineFilter[i].Pattern).Success)
                {
                    match = true;
                    lineType = _inputLineFilter[i].lineType;
                }
            }

            return lineType;
        }


    }
}
