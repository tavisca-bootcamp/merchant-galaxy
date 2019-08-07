package com.tavisca.workshops.MerchantGalaxy;

import java.util.HashMap;

public class WordToRomanParser {
    private HashMap<String, String> wordRomanMap = new HashMap<>();

    public String[] parse(String statement) {
        String[] splits = statement.split(" ");
        wordRomanMap.put(splits[0], splits[2]);
        return new String[] {splits[0], splits[2]};
    }

    public String getRomanNumeralFromWord(String word) {
        return wordRomanMap.get(word);
    }
}
