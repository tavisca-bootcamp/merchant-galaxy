package tavisca.workshop;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.TestInstance;
import static org.junit.jupiter.api.Assertions.*;

@TestInstance(TestInstance.Lifecycle.PER_CLASS)
public class FirstInputTypeTest {
    private RomanCalculator romanCalculator;

    @BeforeEach
    void createInstanceOfRomanCalculator()   {
        romanCalculator = new RomanCalculator();
        assertNotNull(romanCalculator, "Instance created for RomanCalculator");
    }

    @Test
    void canInterpretGalacticWords()  {
        String input = "glob is I";
        String[] expectedResult = {"glob", "I"};
        String[] actualOutput = DeclarativeStatements.Processing(input);
        assertArrayEquals(expectedResult, actualOutput);

        input = "prok is V";
        expectedResult = new String[]{"prok", "V"};
        actualOutput = DeclarativeStatements.Processing(input);
        assertArrayEquals(expectedResult, actualOutput);

        input = "pish is X";
        expectedResult = new String[] {"pish", "X"};
        actualOutput = DeclarativeStatements.Processing(input);
        assertArrayEquals(expectedResult, actualOutput);

        input = "tegi is L";
        expectedResult = new String[]  {"tegi", "L"};
        actualOutput = DeclarativeStatements.Processing(input);
        assertArrayEquals(expectedResult, actualOutput);
    }

    @Test
    void canConvertRomansToArabic()  {
        romanCalculator.roman = "IV";
        int expectedOutput = 4;
        int actualOutput = romanCalculator.convertRomanToArabicDecimal();
        assertEquals(expectedOutput, actualOutput);

        romanCalculator.roman = "XII";
        expectedOutput = 12;
        actualOutput = romanCalculator.convertRomanToArabicDecimal();
        assertEquals(expectedOutput, actualOutput);
    }
}