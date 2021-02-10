package tavisca.workshop;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.TestInstance;

import static org.junit.jupiter.api.Assertions.*;

@TestInstance(TestInstance.Lifecycle.PER_CLASS)
public class SecondInputTypeTest {
    private RomanCalculator romanCalculator;
    private GalacticToArabicMapping arabicMapping;
    private PriceCalculator priceCalculator;
    private GalacticToRomanMapping romanMapping;

    @BeforeAll
    void createInstanceOfStorageForGalacticWords()  {
        arabicMapping = new GalacticToArabicMapping();
        romanMapping = new GalacticToRomanMapping();
        romanCalculator = new RomanCalculator();
        priceCalculator = new PriceCalculator();
    }

    @BeforeAll
    void populateDirectoryOfGalacticWords() {
        String input = "glob is I";
        String[] output = DeclarativeStatements.Processing(input);
        romanCalculator.roman = output[1];
        romanMapping.directory.put(output[0], output[1]);
        arabicMapping.directory.put(output[0], (double) romanCalculator.convertRomanToArabicDecimal());

        input = "prok is V";
        output = DeclarativeStatements.Processing(input);
        romanCalculator.roman = output[1];
        romanMapping.directory.put(output[0], output[1]);
        arabicMapping.directory.put(output[0], (double) romanCalculator.convertRomanToArabicDecimal());

        input = "pish is X";
        output = DeclarativeStatements.Processing(input);
        romanCalculator.roman = output[1];
        romanMapping.directory.put(output[0], output[1]);
        arabicMapping.directory.put(output[0], (double) romanCalculator.convertRomanToArabicDecimal());

        input = "tegi is L";
        output = DeclarativeStatements.Processing(input);
        romanCalculator.roman = output[1];
        romanMapping.directory.put(output[0], output[1]);
        arabicMapping.directory.put(output[0], (double) romanCalculator.convertRomanToArabicDecimal());
    }

    @Test
    void canInterpretComplexStatements()  {
        String input = "glob glob Silver is 34 Credits";
        String[] expectedOutput = {"glob glob Silver", "34"};
        String[] actualOutput = ComplexStatements.Processing(input);
        assertArrayEquals(expectedOutput, actualOutput);

        input = "glob prok Gold is 57800 Credits";
        expectedOutput = new String[] {"glob prok Gold", "57800"};
        actualOutput = ComplexStatements.Processing(input);
        assertArrayEquals(expectedOutput, actualOutput);

        input = "pish pish Iron is 3910 Credits";
        expectedOutput = new String[] {"pish pish Iron", "3910"};
        actualOutput = ComplexStatements.Processing(input);
        assertArrayEquals(expectedOutput, actualOutput);
    }

    @Test
    void canEvaluatePriceForMetals()  {
        String input = "glob glob Silver is 34 Credits";
        String[] splits = ComplexStatements.Processing(input);
        String[] parse = ComplexStatements.Parse(romanMapping, splits[0]);
        assertArrayEquals(new String[] {"glob glob", "Silver"}, parse);
        String quantityEquivalent = GalacticWordConverter.convertGalacticWordsToRoman(romanMapping, parse[0]);
        double priceForMetal = priceCalculator.calculatePriceForEacMetal(quantityEquivalent, splits[1]);
        assertEquals("Silver", parse[1]);
        assertEquals(17, priceForMetal);
        arabicMapping.directory.put(parse[1], priceForMetal);

        input = "glob prok Gold is 57800 Credits";
        splits = ComplexStatements.Processing(input);
        parse = ComplexStatements.Parse(romanMapping, splits[0]);
        assertArrayEquals(new String[] {"glob prok", "Gold"}, parse);
        quantityEquivalent = GalacticWordConverter.convertGalacticWordsToRoman(romanMapping, parse[0]);
        priceForMetal = priceCalculator.calculatePriceForEacMetal(quantityEquivalent, splits[1]);
        assertEquals("Gold", parse[1]);
        assertEquals(14450, priceForMetal);
        arabicMapping.directory.put(parse[1], priceForMetal);

        input = "pish pish Iron is 3910 Credits";
        splits = ComplexStatements.Processing(input);
        parse = ComplexStatements.Parse(romanMapping, splits[0]);
        assertArrayEquals(new String[] {"pish pish", "Iron"}, parse);
        quantityEquivalent = GalacticWordConverter.convertGalacticWordsToRoman(romanMapping, parse[0]);
        priceForMetal = priceCalculator.calculatePriceForEacMetal(quantityEquivalent, splits[1]);
        assertEquals("Iron", parse[1]);
        assertEquals(195.5, priceForMetal);
        arabicMapping.directory.put(parse[1], priceForMetal);
    }
}