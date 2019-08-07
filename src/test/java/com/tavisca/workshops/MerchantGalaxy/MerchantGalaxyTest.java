package com.tavisca.workshops.MerchantGalaxy;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

public class MerchantGalaxyTest {

    WordToRomanParser wordToRomanParser;
    WordToCreditsParser wordToCreditsParser;
    RomanNumeralToDecimal romanNumeralToDecimal;
    CreditsOfItem creditsOfItem;
    QuestionToResult questionToResult;

    @BeforeEach
    void beforeEachTest() {
        wordToRomanParser = new WordToRomanParser();
        wordToCreditsParser = new WordToCreditsParser();
        romanNumeralToDecimal = new RomanNumeralToDecimal();
        creditsOfItem  = new CreditsOfItem();
        questionToResult = new QuestionToResult();
    }

    @Test
    void canParseWordToRomanNumeralStatement() {
       assertArrayEquals(new String[] { "glob", "I"}, wordToRomanParser.parse("glob is I"));
       assertArrayEquals(new String[] { "prok", "V" }, wordToRomanParser.parse("prok is V"));
       assertArrayEquals(new String[] { "pish", "X" }, wordToRomanParser.parse("pish is X"));
       assertArrayEquals(new String[] { "tegj", "L" }, wordToRomanParser.parse("tegj is L"));
    }

    @Test
    void canParseWordToCreditsStatement() {
        assertArrayEquals(new String[] {"glob", "glob", "Silver", "34"},
                wordToCreditsParser.parse("glob glob Silver is 34 Credits"));

        assertArrayEquals(new String[] {"glob", "prok", "Gold", "57800"},
                wordToCreditsParser.parse("glob prok Gold is 57800 Credits"));

        assertArrayEquals(new String[] {"pish", "pish", "Iron", "3910"},
                wordToCreditsParser.parse("pish pish Iron is 3910 Credits"));
    }

    @Test
    void getRomanNumeralFromWord() {
        wordToRomanParser.parse("glob is I");
        wordToRomanParser.parse("prok is V");
        wordToRomanParser.parse("pish is X");
        wordToRomanParser.parse("tegj is L");
        assertEquals("I", wordToRomanParser.getRomanNumeralFromWord("glob"));
        assertEquals("V", wordToRomanParser.getRomanNumeralFromWord("prok"));
        assertEquals("X", wordToRomanParser.getRomanNumeralFromWord("pish"));
        assertEquals("L", wordToRomanParser.getRomanNumeralFromWord("tegj"));
    }

    @Test
    void getRomanNumeralFromWords() {
        wordToRomanParser.parse("glob is I");
        wordToRomanParser.parse("prok is V");
        wordToRomanParser.parse("pish is X");
        wordToRomanParser.parse("tegj is L");
        assertEquals("II",
                wordToCreditsParser.getRomanNumeralFromWords("glob glob Silver is 34 Credits", wordToRomanParser));
        assertEquals("IV",
                wordToCreditsParser.getRomanNumeralFromWords("glob prok Gold is 57800 Credits", wordToRomanParser));
        assertEquals("XX",
                wordToCreditsParser.getRomanNumeralFromWords("pish pish Iron is 3910 Credits", wordToRomanParser));
    }

    @Test
    void convertRomanNumeralToDecimal() {
        assertEquals(2, romanNumeralToDecimal.convert("II"));
        assertEquals(4, romanNumeralToDecimal.convert("IV"));
        assertEquals(20, romanNumeralToDecimal.convert("XX"));
        assertEquals(39, romanNumeralToDecimal.convert("XXXIX"));
    }

    @Test
    void calculateCreditsOfItem() {
        wordToRomanParser.parse("glob is I");
        wordToRomanParser.parse("prok is V");
        wordToRomanParser.parse("pish is X");
        wordToRomanParser.parse("tegj is L");
        assertEquals(17.00,
                creditsOfItem.calculate("glob glob Silver is 34 Credits", wordToRomanParser));
        assertEquals(14450.00,
                creditsOfItem.calculate("glob prok Gold is 57800 Credits", wordToRomanParser));
        assertEquals(195.50,
                creditsOfItem.calculate("pish pish Iron is 3910 Credits", wordToRomanParser));
    }

    @Test
    void calculateDecimalFromStatement() {
        wordToRomanParser.parse("glob is I");
        wordToRomanParser.parse("prok is V");
        wordToRomanParser.parse("pish is X");
        wordToRomanParser.parse("tegj is L");
        creditsOfItem.calculate("glob glob Silver is 34 Credits", wordToRomanParser);
        creditsOfItem.calculate("glob prok Gold is 57800 Credits", wordToRomanParser);
        creditsOfItem.calculate("pish pish Iron is 3910 Credits", wordToRomanParser);
        assertEquals("42",
                questionToResult.calculate("how much is pish tegj glob glob ?", wordToRomanParser));
    }
}
