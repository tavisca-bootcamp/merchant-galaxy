﻿using System;
using System.Collections.Generic;
using MerchantGuideToGalaxyApp.Contract;
using System.Text;
using System.Linq;
using MerchantGuideToGalaxyApp.Rules;

namespace MerchantGuideToGalaxyApp
{
    public class RomanConverter : IDecimalConverter
    {
        List<IRule> toDecimalRules;
        Dictionary<string, int> romanToDecimalMapper;

        public RomanConverter()
        {
            toDecimalRules = GetRules();

            romanToDecimalMapper = new Dictionary<string, int>();
            romanToDecimalMapper.Add("I", 1);
            romanToDecimalMapper.Add("V", 5);
            romanToDecimalMapper.Add("X", 10);
            romanToDecimalMapper.Add("L", 50);
            romanToDecimalMapper.Add("C", 100);
            romanToDecimalMapper.Add("D", 500);
            romanToDecimalMapper.Add("M", 1000);
        }

        /// <summary>
        /// This method validates and converts a Roman Numeral given as a string to a decimal.
        /// </summary>
        /// <param name="input">Roman Numeral given as a string</param>
        /// <returns>If the input is valid it returns an int otherwise it returns null</returns>
        public double? ToDecimal(string input)
        {
            if (!ValidateToDecimal(input)) return null;
            return CalculateDecimalValue(input);
        }

        /// <summary>
        /// This method validates the Roman Numeral.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns a boolean based on whether the input is a valid Roman Numeral or not.</returns>
        private bool ValidateToDecimal(string input)
        {
            return toDecimalRules.All(rule => { return rule.Execute(input); });
        }

        /// <summary>
        /// This method performs the actual conversion from Roman numeral to decimal.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns the decimal value of a given Roman numeral.</returns>
        private double CalculateDecimalValue(string input)
        {
            double current = 0, next = 0, total = 0;

            for (int i = 0; i < input.Length; i++)
            {
                next = 0;
                current = romanToDecimalMapper[input[i].ToString()];
                if (i < input.Length - 1) next = romanToDecimalMapper[input[i + 1].ToString()];

                if (current < next)
                {
                    total += next - current;
                    i++;
                }
                else { total += current; }
            }

            return total;
        }

        private List<IRule> GetRules()
        {
            List<IRule> rules = new List<IRule>();
            rules.Add(new NoRepetitionRule());
            rules.Add(new ThreeflodRepetitionRule());
            rules.Add(new SingleSubtraction());
            rules.Add(new Subtraction());

            return rules;
        }
    }

}
