package com.tavisca.workshop.pratham.merchantgalaxy.parser;

import java.security.InvalidParameterException;
import java.text.ParseException;

public abstract class ItemCreditsStatementParser {

    public static String[] parse(String statement) throws ParseException{
        //"glob glob Silver is 34 Credits"

        String[] words = statement.split(" ");
        int indexOfIs = - 1;
        int numberIndex = -1;

        for(int i = 0; i < words.length; i++){
            //TODO: check should be before "is"
            if(words[i].equals("is"))
                indexOfIs = i;
            else if(isNumber(words[i])) {
                numberIndex = i;
                break;  //Skipping the Credits because it starts with uppercase 'C'
            }
        }

        if(indexOfIs == -1 || numberIndex == -1)
            throw new ParseException("Invalid QuantityItemCreditsStatement.", 1);

        //Return array size: Elements till Item + NumberWord)
        String[] QuantityItemCredit = new String[indexOfIs + 1];

        //Inserting QuantityDescribingWords and Item.
        for(int i = 0; i < indexOfIs; i++)
            QuantityItemCredit[i] = words[i];

        //Inserting NumberWord
        QuantityItemCredit[QuantityItemCredit.length - 1] = words[numberIndex];

        return QuantityItemCredit;
    }

    private static boolean isNumber(String word){
        return word.matches("[\\d]+");
    }
}
