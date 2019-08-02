using System;

namespace MerchantGalaxy
{
    public class ErrorMessages
    {
        public void PrintMessage(ErrorCodes errorCodes)
        {
            string errorMessage = getMessage(errorCodes);

            if (errorMessage != "")
                Console.WriteLine(errorMessage);
        }

        public string getMessage(ErrorCodes errorCodes)
        {
            string errorMessage = "";
            switch (errorCodes)
            {
                case ErrorCodes.No_Input: errorMessage = "No Input was specified. Program Aborted";break;
                case ErrorCodes.Invalid: errorMessage = "Input format is Wrong!"; break;
                case ErrorCodes.Invalid_Roman_Symbol: errorMessage = "Illegal Roman Character"; break;
                case ErrorCodes.Invalid_Roman_Number: errorMessage = "Roman Number format violated"; break;
                case ErrorCodes.Incorrect_line_type: errorMessage = "Incorrect Line Type"; break;
                case ErrorCodes.No_idea: errorMessage = "I have no idea what you are talking about"; break;
                default: break;

            }
            return errorMessage;
        }
    }
}