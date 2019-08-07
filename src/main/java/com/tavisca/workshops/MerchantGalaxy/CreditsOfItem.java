package com.tavisca.workshops.MerchantGalaxy;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.HashMap;

public class CreditsOfItem {
    private HashMap<String, Double> itemCreditMap = new HashMap<>();

    public double calculate(String statement, WordToRomanParser wordToRomanParser) {
        WordToCreditsParser wordToCreditsParser = new WordToCreditsParser();
        String[] wordsArray = wordToCreditsParser.parse(statement);
        RomanNumeralToDecimal romanNumeralToDecimal = new RomanNumeralToDecimal();
        String romanNumeral = wordToCreditsParser.getRomanNumeralFromWords(statement, wordToRomanParser);
        int decimal = romanNumeralToDecimal.convert(romanNumeral);
        String item = wordsArray[wordsArray.length - 2];
        int credit = Integer.parseInt(wordsArray[wordsArray.length - 1]);
        double result = (double) credit / decimal;
        NumberFormat formatter = new DecimalFormat(".00");
        result = Double.parseDouble(formatter.format(result));
        itemCreditMap.put(item, result);
        return result;
    }

    public double getCreditForItem(String item) {
        return itemCreditMap.get(item);
    }
}
