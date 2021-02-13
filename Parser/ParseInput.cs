using System;
using System.Collections.Generic;
using System.Linq;
using merchant_galaxy.Convertor;
using System.Text;

namespace merchant_galaxy.Parser
{
    public class ParseInput
    {
        string roman = "IVXLCDM";
        public ParseInput()
        {

        }
        public List<string> GetLineFromInput(string input)
        {
            List<string> lines = input.Split("\n").ToList();

            //foreach(var line in lines)
            //    Console.WriteLine(line);
            return lines;
        }
        public List<string> GetAliaseFromLines(List<string> lines)
        {
            //string[] lines = input.Split("\n");
            List<string> AliasLines = new List<string>();
            foreach(var line in lines)
            {
                if(roman.Contains(line[line.Length - 1]))
                {
                    AliasLines.Add(line);
                }
            }
            return AliasLines;
        }

        internal List<string> GetComodityAliasLine(List<string> lines)
        {
            List<string> ComodityAlias = new List<string>();
            foreach(var line in lines)
            {
                if (line[line.Length - 1] == 's')
                {
                    ComodityAlias.Add(line);
                }

            }
            //foreach(var ques in UnknownAlias)
            //    Console.WriteLine(ques);
            return ComodityAlias;
        }

        public Dictionary<string, double> GetComodityCost(List<string> comodityAliasLines, Dictionary<string, string> Alias)
        {
            Dictionary<string, double> ComodityCost = new Dictionary<string, double>();
            foreach (var line in comodityAliasLines)
            {
                
                string[] temp = line.Split(" is ");
                string[] AliasAndComodity = temp[0].Split(" ");
                string creditString = temp[1].Split(" ")[0].ToString();
                double credit = double.Parse(creditString);
                string RomanNumber = "";
                string comodity = "";
                foreach(var alias in AliasAndComodity)
                {
                    string value = null;
                    if (Alias.TryGetValue(alias, out value))
                    {
                        RomanNumber += value;
                    }
                    else
                        comodity += alias;
                }
                ConvertorNumber convert = new ConvertorNumber();

                double DecimalValue = convert.RomanToDecimal(RomanNumber);
                double ComodityPrice = 0;
                if (DecimalValue != 0)
                    ComodityPrice = credit / DecimalValue;
                
                ComodityCost[comodity] = ComodityPrice;
            }
            return ComodityCost;
        }

        public List<string> GetQuestionLines(List<string> lines)
        {
            List<string> QuestionLines = new List<string>();
            foreach (var line in lines)
            {
                if (line.Contains("?"))
                {
                    QuestionLines.Add(line.Substring(0, line.Length - 2));

                }
            }
            return QuestionLines;
        }
        
        public List<string> GetResult(List<string> QuestionLines, Dictionary<string, string> Alias, Dictionary<string, double> ComodityCost)
        {
            List<string> result = new List<string>();
            foreach(var ques in QuestionLines)
            {
                if (ques.Contains("woodchuck"))
                {
                    result.Add("I have no idea what you are talking about");
                    continue;
                }
                string[] temp = ques.Split(" is ");
                string[] units = temp[1].Split(" ");
                string RomanNumberString = "";
                string comodity = ""; 
                foreach(var al in units )
                {
                    string value = null;
                    if (Alias.TryGetValue(al, out value))
                    {
                        RomanNumberString += value;
                    }
                    else
                        comodity = al;
                }
                
                ConvertorNumber convert = new ConvertorNumber();
                double RomanNumber = convert.RomanToDecimal(RomanNumberString);
                if(comodity == "")
                {
                    string tres = "";
                    tres += temp[1] + " is " + RomanNumber.ToString();
                    result.Add(tres);
                }
                else
                {
                    double credit = RomanNumber * ComodityCost[comodity];
                    string tres = "";
                    tres += temp[1] + " is " + credit.ToString() + " Credits";
                    result.Add(tres);
                }

            }
            return result;
        }
    }
}
