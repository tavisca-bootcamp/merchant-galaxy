package com.tavisca.workshop.pratham.merchantgalaxy;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.security.InvalidParameterException;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

public class MerchantTest {

    Merchant merchant;

    @BeforeEach
    public void initialize(){
       merchant = new Merchant();
    }

    @Test
    public void canTranslateForeignWordToRomanLiteral() {
        try {
            merchant.query("glob is I");

            assertEquals('I', merchant.toRomanLiteral("glob"));
        } catch (Exception e) {
            fail();
        }
    }

    @Test
    public void canCalculateCreditsForGivenItem() {
        try {
            merchant.query("glob is I");
            merchant.query("glob glob Silver is 34 Credits");

            assertEquals(17, merchant.creditsOf("Silver"));
        } catch (Exception e) {
            fail();
        }
    }

    @Test
    public void canAnswerQuestionsOfTypeHowMuch() {
        try {
            merchant.query("glob is I");
            merchant.query("prok is V");
            merchant.query("pish is X");
            merchant.query("tegj is L");

            String response = merchant.query("how much is pish tegj glob glob ?");

            assertEquals("pish tegj glob glob is 42", response);
        } catch (ParseException e) {
            fail();
        }
    }

    @Test
    public void canAnswerQuestionsOfTypeHowMany() {
        try {
            merchant.query("glob is I");
            merchant.query("prok is V");
            merchant.query("pish is X");
            merchant.query("tegj is L");

            merchant.query("glob glob Silver is 34 Credits");
            String response = merchant.query("how many Credits is glob prok Silver ?");
            assertEquals("glob prok Silver is 68 Credits", response);

            merchant.query("pish pish Iron is 3910 Credits");
            response = merchant.query("how many Credits is glob prok Iron ?");
            assertEquals("glob prok Iron is 782 Credits", response);
        } catch (ParseException e) {
            fail();
        }
    }

    @Test
    void respondsWithNoIdeaMessageForInvalidQuestionStatement() {
        try {
            assertEquals("I have no idea what you are talking about",
                    merchant.query("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?"));
        } catch (ParseException e) {
            fail();
        }
    }

    @Test
    void canProcessAListOfQuery() {

        List<String> inputStatements = Collections.unmodifiableList(
                new ArrayList<>(Arrays.asList(
                        "glob is I",

                        "prok is V",

                        "pish is X",

                        "tegj is L",

                        "glob glob Silver is 34 Credits",

                        "glob prok Gold is 57800 Credits",

                        "pish pish Iron is 3910 Credits",

                        "how much is pish tegj glob glob ?",

                        "how many Credits is glob prok Silver ?",

                        "how many Credits is glob prok Gold ?",

                        "how many Credits is glob prok Iron ?",

                        "how much wood could a woodchuck chuck if a woodchuck could chuck wood ?"
                )));
        List<String> outputStatements = Collections.unmodifiableList(
                new ArrayList<>(Arrays.asList(
                        "pish tegj glob glob is 42",

                        "glob prok Silver is 68 Credits",

                        "glob prok Gold is 57800 Credits",

                        "glob prok Iron is 782 Credits",

                        "I have no idea what you are talking about"
                )));

        try {
            List<String> responses = new ArrayList<>();

            for (String statement : inputStatements) {
                if (statement.contains("?"))
                    responses.add(merchant.query(statement));
                else
                    merchant.query(statement);
            }

            assertIterableEquals(outputStatements, responses);
        } catch (ParseException e) {
            fail();
        }
    }
}
