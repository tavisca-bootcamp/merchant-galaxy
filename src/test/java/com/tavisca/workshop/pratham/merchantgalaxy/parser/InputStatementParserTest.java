package com.tavisca.workshop.pratham.merchantgalaxy.parser;

import org.junit.jupiter.api.Test;

import java.text.ParseException;

import static org.junit.jupiter.api.Assertions.*;

public class InputStatementParserTest {
    @Test
    void canParseForeignVocabularyStatements() {

        String[] values = ForeignVocabularyStatementParser.parse("glob is I");
        assertArrayEquals(new String[]{"glob", "I"}, values);

        values = ForeignVocabularyStatementParser.parse("prok is V");
        assertArrayEquals(new String[]{"prok", "V"}, values);
    }

    @Test
    public void canParseItemCreditsStatement() {
        try {
            String values[] = ItemCreditsStatementParser.parse("glob glob Silver is 34 Credits");
            assertArrayEquals(new String[]{"glob", "glob", "Silver", "34"}, values);
        } catch (ParseException e) {
            fail();
        }
    }

    @Test
    public void canParseQuestionStatements() {
        try {
            String[] values = QuestionStatementParser.parse("how many Credits is glob prok Silver ?");
            assertArrayEquals(new String[]{"glob", "prok", "Silver"}, values);

            values = QuestionStatementParser.parse("how much is pish tegj glob glob ?");
            assertArrayEquals(new String[]{"pish", "tegj", "glob", "glob"}, values);
        } catch (ParseException e) {
            fail();
        }
    }
}
