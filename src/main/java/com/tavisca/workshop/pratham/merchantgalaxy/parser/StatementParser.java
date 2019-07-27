package com.tavisca.workshop.pratham.merchantgalaxy.parser;

import java.text.ParseException;

public abstract class StatementParser {

    public static String[] parseForeignVocabularyStatement(String statement) {
        String[] parts = statement.split(" ");
        return new String[]{parts[0], parts[2]};
    }

    public static String[] parseItemCreditsStatement(String statement) throws ParseException {
        //"glob glob Silver is 34 Credits"

        String[] words = statement.split(" ");
        int indexOfIs = -1;
        int numberIndex = -1;

        for (int i = 0; i < words.length; i++) {
            if (words[i].equals("is"))
                indexOfIs = i;
            else if (isNumber(words[i])) {
                numberIndex = i;
                break;  //Skipping the Credits because it starts with uppercase 'C'
            }
        }

        if (indexOfIs == -1 || numberIndex == -1)
            throw new ParseException("Invalid QuantityItemCreditsStatement.", 1);

        //Return array size: Elements till Item + NumberWord)
        String[] QuantityItemCredit = new String[indexOfIs + 1];

        //Inserting QuantityDescribingWords and Item.
        for (int i = 0; i < indexOfIs; i++)
            QuantityItemCredit[i] = words[i];

        //Inserting NumberWord
        QuantityItemCredit[QuantityItemCredit.length - 1] = words[numberIndex];

        return QuantityItemCredit;
    }

    public static String[] parseQuestionStatement(String question) throws ParseException {
        String[] parts = question.split(" ");
        int indexOfWordIs = -1;

        for (int i = 0; i < parts.length; i++)
            if (parts[i].equals("is")) {
                indexOfWordIs = i;
                break;
            }

        if (indexOfWordIs == -1)
            throw new ParseException("Invalid question format", 1);

        //QuantityAndItem size: TotalParts - (Parts till "is" +  "?")
        String[] quantityAndItem = new String[parts.length - (indexOfWordIs + 2)];
        //Inserting the words between "is" and "?".
        for (int i = indexOfWordIs + 1; i < parts.length - 1; i++)
            quantityAndItem[i - (indexOfWordIs + 1)] = parts[i];

        return quantityAndItem;
    }

    private static boolean isNumber(String word) {
        return word.matches("[\\d]+");
    }
}
