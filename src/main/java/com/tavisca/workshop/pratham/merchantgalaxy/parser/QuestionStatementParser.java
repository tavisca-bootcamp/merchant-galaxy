package com.tavisca.workshop.pratham.merchantgalaxy.parser;

import java.text.ParseException;

public abstract class QuestionStatementParser {

    public static String[] parse(String question) throws  ParseException{
        String[] parts = question.split(" ");
        int indexOfWordIs = -1;

        for(int i = 0; i < parts.length; i++)
            if(parts[i].equals("is")) {
                indexOfWordIs = i;
                break;
            }

        if(indexOfWordIs == -1)
            throw new ParseException("Invalid question format", 1);

        //QuantityAndItem size: TotalParts - (Parts till "is" +  "?")
        String[] quantityAndItem = new String[parts.length - (indexOfWordIs + 2)];
        //Inserting the words between "is" and "?".
        for(int i = indexOfWordIs + 1; i < parts.length - 1; i++)
            quantityAndItem[i - (indexOfWordIs + 1)] = parts[i];

        return quantityAndItem;
    }
}
