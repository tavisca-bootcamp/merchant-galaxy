using System;
using System.Collections.Generic;


namespace MerchantGalaxy
{

    public class Galaxy: DecodeGalacticMessage
    {
        public static void Main(string[] args)
        {
          ConversionRomanToDecimal conversion = new ConversionRomanToDecimal();
           
            conversion.SymbolValuesConversion();

            Galaxy msg = new Galaxy();

           
            string[] message_from_galaxy = new string[100];
            string[] input_message = new string[20];
            int j = 0, i = 0, start_index = 0, count_of_words = 0;
            string current_message = null;
            
            message_from_galaxy[0] = "glob is I";
            message_from_galaxy[1] = "prok is V";
            message_from_galaxy[2] = "pish is X";
            message_from_galaxy[3] = "tegj is L";
            message_from_galaxy[4] = "glob glob silver is 34 credits";
            message_from_galaxy[5] = "glob prok gold is 57800 credits";
            message_from_galaxy[6] = "pish pish iron is 3910 credits";
            message_from_galaxy[7] = "how much is pish tegj glob glob ?";
            message_from_galaxy[8] = "how many credits is glob prok silver ?";
            message_from_galaxy[9] = "how many credits is glob prok gold ?";
            message_from_galaxy[10] = "how many credits is glob prok iron ?";
            message_from_galaxy[11] = "how much wood could a woodchuck chuck if a woodchuck could chuck wood ?";
        
            while (message_from_galaxy[i] != null && i < message_from_galaxy.Length)
            {
                current_message = message_from_galaxy[i];
          
               
                start_index = 0;
                count_of_words = 0;
             
                for (j = 0; j < current_message.Length; j++)
                {
                   
                    if (current_message[j] == ' ' || j == current_message.Length - 1)
                    {
                      
                        if (j == current_message.Length - 1)
                            j++;
                        input_message[count_of_words] = current_message[start_index..j];
                      
                      
                        start_index = j + 1;
                        count_of_words++;
                    }

                }
               
                i++;
              
                msg.DecodeMessage(input_message,
                                   count_of_words);
            }
        }

    }

}