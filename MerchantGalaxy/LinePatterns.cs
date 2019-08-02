using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGalaxy.Conversations
{
    public static class LinePatterns
    {
        public static string AssignedLinePattern = @"^([A-Za-z]+) is (I|V|X|L|C|D|M)$";
        public static string CreditsLinePattern = @"^([A-Za-z]+) ([A-Za-z\\s]*) is ([0-9]+) ([c|C]redits)$";
        public static string QuestionHowMuchLinePattern = @"^how much is (([A-Za-z\\s])+)\\?$";
        public static string QuestionHowManyPattern = @"^how many is (([A-Za-z\\s])+)\\?$";
        
    }
}
