using System;
using System.Collections.Generic;
using System.Text;
using MerchantGalaxy.Conversations;
using MerchantGalaxy.RomanNumerals;
using System.Text.RegularExpressions;

namespace MerchantGalaxy
{
    public class Processor
    {
        private ConversationLine _conversationLine;
        private Dictionary<string, string> _assignedConstants;
        private Dictionary<string, string> _computedLiterals;
        private List<string> _output;
        private ErrorCodes _errorCodes;
        private ErrorMessages _errorMessages;

        public Dictionary<string, string> AssignedConstants
        {
            get => _assignedConstants;
        }

        public Dictionary<string, string> ComputedLiterals
        {
            get => _computedLiterals;
        }

        public List<string> Output
        {
            get => _output;
        }
       
        public Processor()
        {
            _assignedConstants = new Dictionary<string, string>();
            _computedLiterals = new Dictionary<string, string>();
            _output = new List<string>();
            _errorMessages = new ErrorMessages();
            _conversationLine = new ConversationLine();
        }

        public List<string> ReadInput()
        {
            var count = 0;
            while (true)
            {
                var input = Console.ReadLine();
                input = input.Trim();
                if (input.Length == 0 || input == "exit") break;

                _errorCodes = Validate(input);

                switch (_errorCodes)
                {
                    case ErrorCodes.No_idea: _output.Add(_errorMessages.getMessage(_errorCodes));break;
                    default: _errorMessages.PrintMessage(_errorCodes); break;
                }
                ++count;

            }
            switch (count)
            {
                case 0: _errorCodes = ErrorCodes.No_Input;
                    _errorMessages.PrintMessage(_errorCodes);
                    break;
            }
            return _output;
        }

        private ErrorCodes Validate(string input)
        {
            ErrorCodes errorCode = ErrorCodes.Success;

            LineType lineType = _conversationLine.GetLineType(input);

            switch (lineType)
            {
                case LineType.Assigned: ProcessAssignedLine(input);
                                        break;
                case LineType.Credits:  ProcessCreditsLine(input);
                                        break;
                case LineType.Question_How_Many: ProcessQuestionHowManyLine(input);
                                                 break;
                case LineType.Question_How_Much: ProcessQuestionHowMuchLine(input);
                                                 break;
                case LineType.Nomatch: errorCode = ErrorCodes.No_idea; break;
       
            }

            return errorCode;
        }

        public void ProcessQuestionHowMuchLine(string input)
        {
            try
            {
                var formattedString = Regex.Split(input, "\\sis\\s")[1].Trim();
                formattedString = formattedString.Replace("?", "").Trim();
                var Keys = Regex.Split(formattedString, "\\s+");

                string RomanResult = "";
                string ComputedResult = "";
                bool ErrorOccured = false;

                foreach (var Key in Keys)
                {
                    if (!(_assignedConstants.TryGetValue(Key, out string RomanValue)))
                    {
                        ComputedResult = _errorMessages.getMessage(ErrorCodes.No_idea);
                        ErrorOccured = true;
                        break;
                    }
                    RomanResult += RomanValue;
                }
                    
                    if (!ErrorOccured)
                    {
                        var RomanNumber = RomanNumeralConverter.ConvertRomanNumber(RomanResult);
                        ComputedResult = formattedString + " is " + RomanNumber;
                    }

                _output.Add(ComputedResult);

            }
            catch (Exception)
            {
                _errorMessages.PrintMessage(ErrorCodes.Incorrect_line_type);

            }
        }

        public void ProcessQuestionHowManyLine(string input)
        {

            try
            {
                var formattedString = Regex.Split(input, "\\sis\\s")[1].Trim();
                formattedString = formattedString.Replace("?", "").Trim();
                var Keys = Regex.Split(formattedString, "\\s+");
                bool Found = false;
                string Roman = "";
                string ComputedResult = "";
                Stack<double> ComputedValues = new Stack<double>();

                foreach(var Key in Keys)
                {
                    Found = false;
                    if(_assignedConstants.TryGetValue(Key, out string RomanValue))
                    {
                        Roman += RomanValue;
                        Found = true;
                    }

                    if(!Found && (_computedLiterals.TryGetValue(Key, out string ComputedValue)))
                    {
                        ComputedValues.Push(Double.Parse(ComputedValue));
                        Found = true;
                    }
                    if (!Found)
                    {
                        ComputedResult = _errorMessages.getMessage(ErrorCodes.No_idea);
                        break;
                    }
                }

                if (Found)
                {
                    double Result = 1;
                    var computedValues = ComputedValues.ToArray();
                    for(int i = 0; i < computedValues.Length; i++)
                    {
                        Result *= computedValues[i];
                    }
                    int FinalResult = (int)(Result);
                    if (Roman.Length > 0)
                        FinalResult = (int)(RomanNumeralConverter.ConvertRomanNumber(Roman) * Result);
                    ComputedResult = formattedString + " is " + FinalResult + " Credits";
                }
                _output.Add(ComputedResult);
            }
            catch (Exception)
            {
                
                _errorMessages.PrintMessage(ErrorCodes.Incorrect_line_type);
            }

        }

        public void ProcessCreditsLine(string input)
        {
            try
            {
                var formattedString = Regex.Replace(input, "(is\\s+)|([c|C]redits\\s*)", "").Trim();
                var Keys = Regex.Split(formattedString, "\\s");
                var toBeComputed = Keys[Keys.Length - 2];
                double value = Double.Parse(Keys[Keys.Length - 1]);

                string Roman = "";

                for (int i = 0; i < Keys.Length - 2; i++)
                {
                    _assignedConstants.TryGetValue(Keys[i], out string temp);
                    Roman += temp;
                }

                var romanNumber = RomanNumeralConverter.ConvertRomanNumber(Roman);
                var Credit = (double)(value / romanNumber);
                _computedLiterals.Add(toBeComputed, Credit + "");
            }
            catch (Exception)
            {
                _errorMessages.PrintMessage(ErrorCodes.Incorrect_line_type);
            }
        }
  
        public void ProcessAssignedLine(string input)
        {
            input = input.Trim();
            var assigned = Regex.Split(input, "\\s+");
           /* for (int i = 0; i < assigned.Length; i++)
            {
                assigned[i] = assigned[i].Trim();
            }*/
            try
            {
                _assignedConstants.Add(assigned[0], assigned[2]);
            }
            catch(Exception)
            {
                _errorMessages.PrintMessage(ErrorCodes.Incorrect_line_type);
            }
        }
    }
}
