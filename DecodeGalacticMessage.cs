using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantGalaxy
{
    public class DecodeGalacticMessage
    {
        private string input_key;
        private string input_value;
        private string roman_input;
        private double metal_value;
        private string metal_name;
        private string intergalactic_word;
        private int intergalactic_units;

        private Dictionary<string, string> galatic_unit_table = new Dictionary<string, string>();
        RomanParser parse = new RomanParser();
        private Dictionary<string, string> message_table = new Dictionary<string, string>();
        public  void DecodeMessage(string[] input_message, int words_count)
        {
           
            if (words_count == 3 && input_message[1] == "is")
            {
                input_key = null;
                input_value = null;
                try
                {
                    input_key = input_message[0];
                    input_value = input_message[words_count - 1];
              
                    if (parse.Parser(input_value) / 1 == 1) { }
                }
                catch (FormatException)
                {
                    Console.WriteLine(input_message[words_count - 2] + "is not a valid numeric value.");
                }
                catch (Exception)
                {
                    Console.WriteLine("I've no idea what you are talking about");
                }
                galatic_unit_table.Add(input_key, input_value);
                return;

            }
            
            if (words_count > 4 && input_message[words_count - 1] == "credits" && input_message[words_count - 3] == "is")
            {
                roman_input = "";
                input_key = null;
                input_value = null;
                try
                {
                    input_key = input_message[words_count - 4];
                    input_value = input_message[words_count - 2];
                   
                }
                catch (Exception)
                {
                    Console.WriteLine(input_message[words_count - 2] + " is not a valid numeric value.");
                }

                for (int i = 0; i < words_count - 4; i++)
                {
                    galatic_unit_table.TryGetValue(input_message[i], out string input_word);
                    if (input_word != null)
                    {
                        
                        roman_input += input_word;
                    }
                    else
                    {
                        Console.WriteLine(input_message[i] + " is not a valid symbol.");
                        return;
                    }
                }
                intergalactic_units = -1;
                intergalactic_units = parse.Parser(roman_input);
              
                if (intergalactic_units > 0)
                {
                    
                    message_table.Add(input_key, (((double)(Convert.ToDouble(input_value) / intergalactic_units))).ToString());
                }
                else
                   
                Console.WriteLine(input_value + " is not a valid Galactic number.");
                return;
            }

            if (words_count > 4 && input_message[0] == "how" && input_message[1] == "many"
            && input_message[2] == "credits" && input_message[3] == "is")
            {
                roman_input = "";
                metal_name = null;
                intergalactic_word = "";
                if (input_message[words_count - 1].Equals("?"))
                    words_count--;
                metal_name = input_message[words_count - 1];
         
                for (int i = 4; i < words_count - 1; i++)
                {
                    galatic_unit_table.TryGetValue(input_message[i], out string input_word);
                    if (input_word != null)
                    {
                      
                        roman_input += input_word;
                        intergalactic_word = intergalactic_word + input_message[i] + " ";
                    }
                    else
                    {
                        Console.WriteLine(input_message[i] + " is not a valid symbol.");
                        return;
                    }
                }
                intergalactic_units = -1;
           
                intergalactic_units = parse.Parser(roman_input);
                
                if (intergalactic_units > 0)
                {
                    message_table.TryGetValue(metal_name, out string metal_result);
                  
                    metal_value = Convert.ToDouble(metal_result);
                    if (metal_value != 0)
                    {
                      
                        Console.WriteLine(intergalactic_word + " " + metal_name + " is " + intergalactic_units * metal_value + " credits");
                    }
                    else
                    {
                        Console.WriteLine(metal_name + " is not a valid Galactic number.");
                    }
                }
                else
                    Console.WriteLine(roman_input + " is not a valid Galactic number.");
                return;
            }
         
            if (words_count > 4 && input_message[0] == "how" && input_message[1] == "much" && input_message[2] == "is")
            {
                roman_input = "";
                intergalactic_word = "";
                if (input_message[words_count - 1].Equals("?"))
                    words_count--;
             
                for (int i = 3; i < words_count; i++)
                {
                    galatic_unit_table.TryGetValue(input_message[i], out string galatic_result);
                    if (galatic_result != null)
                    {
                        roman_input += galatic_result;
                        intergalactic_word = intergalactic_word + input_message[i] + " ";
                    }
                    else
                    {
                        Console.WriteLine(input_message[i] + " is not a valid symbol.");
                        return;
                    }
                }
                intergalactic_units = -1;
                intergalactic_units = parse.Parser(roman_input);
                if (intergalactic_units > 0)
                {
                    Console.WriteLine(intergalactic_word + " is " + intergalactic_units + " credits");
                }
                else
                    Console.WriteLine(roman_input + " is not a valid Galactic number.");
                return;
            }

            Console.WriteLine("I've no idea what you are talking about");
        }
    }
}
