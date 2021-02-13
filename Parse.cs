using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGalaxyProblem
{
    public class Parse
    {
        Dictionary<string, char> AliasMapper = new Dictionary<string, char>();
        Dictionary<string, decimal> CreditConditions = new Dictionary<string, decimal>();
        List<string> question = new List<string>();
        RomanNumberValidator val = new RomanNumberValidator();
        RomanToDecimalConversion cnt = new RomanToDecimalConversion();
        public void getConditions(string[] input)
        {
            foreach (var line in input)
            {
                if (!line.Contains("?") && !line.Contains("Credits"))
                {
                    string[] linelist = line.Split(new[] { " is " }, StringSplitOptions.None);
                    AliasMapper[linelist[0]] = (linelist[1].ToCharArray())[0];
                }
            }


        }

        public void getCreditsCondition(string[] input)
        {
            foreach (var line in input)
            {
                if (line.Contains("Credits") && !line.Contains("?"))
                {
                    string[] linelist = line.Split(new[] { " is " }, StringSplitOptions.None);
                    string rom = string.Empty; string k = string.Empty; int v = 1;
                    foreach (var word in linelist[0].Split(new[] { ' ' }))
                    {

                        if (AliasMapper.ContainsKey(word))
                        {

                            rom += AliasMapper[word];
                        }
                        else
                        {

                            k = word;
                        }
                    }
                    if (val.Validate(rom))
                    {
                        v = cnt.convert(rom);

                    }
                    CreditConditions[k] = Decimal.Parse((linelist[1].Split(new[] { ' ' }))[0]) / v;
                }
            }


        }

        public void getQuestion(string[] input)
        {
            foreach (var line in input)
            {
                if (line.Contains("?"))
                {
                    string[] linelist = line.Split(new[] { " is " }, StringSplitOptions.None);
                    if (linelist.Length == 2)
                        question.Add(linelist[1]);
                    else
                        question.Add(string.Empty);
                }

            }


        }
        public List<string> SolveQuestion()
        {
            List<string> answer = new List<string>();
            foreach (var q in question)
            {
                if (q != string.Empty)
                {
                    string rom = string.Empty; decimal dec = -1; string temp = string.Empty;
                    string res = string.Empty;
                    foreach (var word in q.Split(new[] { ' ' }))
                    {
                        if (AliasMapper.ContainsKey(word))
                        {
                            rom += AliasMapper[word];
                            res += word + " ";
                        }
                        else if (CreditConditions.ContainsKey(word))
                        {
                            res += word + " ";
                            temp = word;
                        }
                    }
                    if (rom != string.Empty)
                    {
                        if (val.Validate(rom))
                        {
                            dec = cnt.convert(rom);
                        }
                    }
                    if (temp != string.Empty)
                    {
                        dec = dec * CreditConditions[temp];
                        res += "is " + dec.ToString() + " Credits";
                    }
                    else
                    {
                        res += "is " + dec.ToString();
                    }
                    answer.Add(res);
                }
                else
                {
                    answer.Add("I have no idea what you are talking about");
                }
            }

            return answer;

        }

    }
}
