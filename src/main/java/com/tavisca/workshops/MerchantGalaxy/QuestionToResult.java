package com.tavisca.workshops.MerchantGalaxy;

// how much is pish tegj glob glob ?

import java.util.Arrays;

public class QuestionToResult {
    public String calculate(String question, WordToRomanParser wordToRomanParser) {
        WordToCreditsParser wordToCreditsParser = new WordToCreditsParser();
        RomanNumeralToDecimal romanNumeralToDecimal = new RomanNumeralToDecimal();
        String[] splittedQuestion = question.split(" is ");
        String romanNumeral = "";
        int decimalNumeral = 0;
        String[] words = splittedQuestion[1].split(" ");
        String[] wordsArray = new String[words.length - 1];
        String newString = "";
        for (int i =0; i < words.length - 1; i++) {
            wordsArray[i] = words[i];
            newString += wordsArray[i] + " ";
        }
        if (splittedQuestion[0].contains("much")) {
            System.out.println(newString);
            romanNumeral = wordToCreditsParser.getRomanNumeralFromWords(newString, wordToRomanParser);
            System.out.println(romanNumeral);
            decimalNumeral = romanNumeralToDecimal.convert(romanNumeral);
            System.out.println(decimalNumeral);
        } else if (splittedQuestion[0].contains("many")) {

        }

        return Integer.toString(decimalNumeral);
    }
}
