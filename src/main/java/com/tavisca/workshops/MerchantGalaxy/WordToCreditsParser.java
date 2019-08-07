package com.tavisca.workshops.MerchantGalaxy;

import java.util.ArrayList;

public class WordToCreditsParser {
    public String[] parse(String statement) {
        String[] splitedStatements = statement.split(" is ");
        String[] splitedWords = splitedStatements[0].split(" ");
        String credit = splitedStatements[1].split(" ")[0];

        ArrayList<String> words = new ArrayList<>();
       for (String word : splitedWords) {
           words.add(word);
        }
       words.add(credit);
        String[] wordsToArray = new String[words.size()];
       for (int i=0; i< words.size(); i++) {
           wordsToArray[i] = words.get(i);
       }
       return wordsToArray;
    }

    public String getRomanNumeralFromWords(String statement, WordToRomanParser wordToRomanParser) {
        String result = "";
        String[] words;
        if (statement.contains("is")) {
            words = parse(statement);
            for (int i = 0; i < words.length - 2; i++) {
                result += wordToRomanParser.getRomanNumeralFromWord(words[i]);
            }
        } else {
            words = statement.split(" ");
            for (int i=0; i < words.length; i++) {
                result += wordToRomanParser.getRomanNumeralFromWord(words[i]);
            }
        }
        return result;
    }
}
