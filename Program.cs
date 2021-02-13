using System;
using System.Collections.Generic;
using merchant_galaxy.Parser;
using merchant_galaxy.Mapper;
namespace merchant_galaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "glob is I\nprok is V\npish is X\ntegj is L\nglob glob Silver is 34 Credits\nglob prok Gold is 57800 Credits\npish pish Iron is 3910 Credits\nhow much is pish tegj glob glob ?\nhow many Credits is glob prok Silver ?\nhow many Credits is glob prok Gold ?\nhow many Credits is glob prok Iron ?\nhow much wood could a woodchuck chuck if a woodchuck could chuck wood ?";

            ParseInput parse = new ParseInput();
            List<string> lines = parse.GetLineFromInput(input);
            List<string> AliasLines = parse.GetAliaseFromLines(lines);
            List<string> ComodityAliasLines = parse.GetComodityAliasLine(lines);
            List<string> QuestionLines = parse.GetQuestionLines(lines);

            AliasMap map = new AliasMap();
            var Alias = new Dictionary<string, string>();
            Alias = map.MakeAliases(AliasLines);

            Dictionary<string, double> ComodityCost = new Dictionary<string, double>();

            ComodityCost = parse.GetComodityCost(ComodityAliasLines, Alias);

            List<string> result = parse.GetResult(QuestionLines, Alias, ComodityCost);

            foreach(var res in result)
                Console.WriteLine(res);
        }
    }
}
