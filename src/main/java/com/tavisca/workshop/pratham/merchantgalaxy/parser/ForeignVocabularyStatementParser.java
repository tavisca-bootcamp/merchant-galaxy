package com.tavisca.workshop.pratham.merchantgalaxy.parser;

public abstract class ForeignVocabularyStatementParser {

    public static String[] parse(String statement) {
        String[] parts = statement.split(" ");
        return new String[]{parts[0], parts[2]};
    }
}
