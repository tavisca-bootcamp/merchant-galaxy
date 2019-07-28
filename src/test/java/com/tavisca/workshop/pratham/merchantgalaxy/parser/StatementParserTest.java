package com.tavisca.workshop.pratham.merchantgalaxy.parser;

import org.junit.jupiter.api.Test;

import java.text.ParseException;

import static org.junit.jupiter.api.Assertions.*;

public class StatementParserTest {
    @Test
    void canParseForeignVocabularyStatements() {

        String[] values = StatementParser.parseForeignVocabularyStatement("glob is I");
        assertArrayEquals(new String[]{"glob", "I"}, values);

        values = StatementParser.parseForeignVocabularyStatement("prok is V");
        assertArrayEquals(new String[]{"prok", "V"}, values);
    }

    @Test
    public void canParseItemCreditsStatement() {
        try {
            String values[] = StatementParser.parseItemCreditsStatement("glob glob Silver is 34 Credits");
            assertArrayEquals(new String[]{"glob", "glob", "Silver", "34"}, values);
        } catch (ParseException e) {
            fail();
        }
    }

    @Test
    public void canParseQuestionStatements() {
        try {
            String[] values = StatementParser.parseQuestionStatement("how many Credits is glob prok Silver ?");
            assertArrayEquals(new String[]{"glob", "prok", "Silver"}, values);

            values = StatementParser.parseQuestionStatement("how much is pish tegj glob glob ?");
            assertArrayEquals(new String[]{"pish", "tegj", "glob", "glob"}, values);
        } catch (ParseException e) {
            fail();
        }
    }
}
