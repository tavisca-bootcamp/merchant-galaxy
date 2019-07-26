package com.tavisca.workshop.pratham.merchantgalaxy;

import com.tavisca.workshop.pratham.merchantgalaxy.parser.StatementParser;
import com.tavisca.workshop.pratham.merchantgalaxy.util.RomanArabicConverter;

import java.security.InvalidParameterException;
import java.sql.Statement;
import java.text.ParseException;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;
import java.util.regex.Pattern;

public class Merchant {

    private static final String RESPONSE_NOT_A_QUESTION = "Not a question";
    private static final String RESPONSE_NO_IDEA = "I have no idea what you are talking about";

    private final Map<String, Character> foreignWordToRomanLiteralMap;
    private final Map<String, Double> itemToCreditsMap;

    public Merchant() {
        foreignWordToRomanLiteralMap = new HashMap<>();
        itemToCreditsMap = new HashMap<>();
    }

    public String query(String statement) throws ParseException {
        if (statement.contains("?"))
            return handleQuestion(statement);
        else if (statement.contains("Credits") || statement.contains("credits")) {
            handleItemCreditsStatement(statement);
            return RESPONSE_NOT_A_QUESTION;
        } else {
            handleForeignVocabularyStatement(statement);
            return RESPONSE_NOT_A_QUESTION;
        }
    }

    private String handleQuestion(String question) throws ParseException {
        String[] tokens;
        try{
            tokens = StatementParser.parseQuestionStatement(question);
            if(tokens.length == 0)
                return RESPONSE_NO_IDEA;
        }catch (ParseException e){
            return RESPONSE_NO_IDEA;
        }

        StringBuilder responseBuilder = new StringBuilder();
        for (String token : tokens)
            responseBuilder.append(token)
                    .append(" ");
        responseBuilder.append("is ");

        if (question.contains("how much is")) {
            int number = RomanArabicConverter.toArabic(translateToRoman(tokens));
            responseBuilder.append(number);
            return responseBuilder.toString();
        } else if (question.contains("how many Credits")) {
            String[] foreignWords = Arrays.copyOf(tokens, tokens.length - 1);
            String item = tokens[tokens.length - 1];

            int itemCount = RomanArabicConverter.toArabic(translateToRoman(foreignWords));
            double itemCredits = itemToCreditsMap.get(item);
            double totalCredits = itemCount * itemCredits;

            responseBuilder.append(Math.round(totalCredits))
                    .append(" Credits");
            return responseBuilder.toString();
        }else
            return RESPONSE_NO_IDEA;

    }

    private void handleItemCreditsStatement(String statement) throws ParseException {
        String[] foreignWordsItemCredits = StatementParser.parseItemCreditsStatement(statement);
        int size = foreignWordsItemCredits.length;

        String[] foreignWords = Arrays.copyOf(foreignWordsItemCredits, size - 2);

        int itemCount = RomanArabicConverter.toArabic(translateToRoman(foreignWords));
        String item = foreignWordsItemCredits[size - 2];
        int credits = Integer.parseInt(foreignWordsItemCredits[size - 1]);

        double itemCredits = credits / (double) itemCount;
        itemToCreditsMap.put(item, itemCredits);
    }

    private char[] translateToRoman(String[] foreignWords) {
        char[] romanLiterals = new char[foreignWords.length];
        for (int i = 0; i < foreignWords.length; i++)
            romanLiterals[i] = translateToRoman(foreignWords[i]);
        return romanLiterals;
    }

    private char translateToRoman(String foreignWord) {
        if (foreignWordToRomanLiteralMap.containsKey(foreignWord))
            return foreignWordToRomanLiteralMap.get(foreignWord);
        else
            throw new RuntimeException("Unknown word: " + foreignWord);
    }

    private void handleForeignVocabularyStatement(String statement) throws ParseException{
        String[] foreignWordRomanLiteral = StatementParser.parseForeignVocabularyStatement(statement);

        if (isRomanLiteral(foreignWordRomanLiteral[1]))
            foreignWordToRomanLiteralMap.put(foreignWordRomanLiteral[0], foreignWordRomanLiteral[1].charAt(0));
        else
            throw new ParseException("Invalid roman literal", 1);
    }

    private boolean isRomanLiteral(String literal) {
        return Pattern.matches("[" + RomanArabicConverter.romanLiterals() + "]", literal);
    }

    public char toRomanLiteral(String foreignWord) {
        if(foreignWordToRomanLiteralMap.containsKey(foreignWord))
            return foreignWordToRomanLiteralMap.get(foreignWord);
        else
            throw new InvalidParameterException("Invalid item");
    }

    public double creditsOf(String item) {
        if (itemToCreditsMap.containsKey(item))
            return itemToCreditsMap.get(item);
        else
            throw new InvalidParameterException("Invalid item");
    }
}
