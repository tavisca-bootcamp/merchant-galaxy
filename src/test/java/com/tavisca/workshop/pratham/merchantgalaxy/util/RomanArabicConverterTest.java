package com.tavisca.workshop.pratham.merchantgalaxy.util;

import org.junit.jupiter.api.Test;

import java.text.ParseException;

import static org.junit.jupiter.api.Assertions.*;

public class RomanArabicConverterTest {

    @Test
    public void canConvertRomanToArabic() throws ParseException{
        RomanArabicConverter converter = new RomanArabicConverter();

        assertThrows(ParseException.class, () -> {
            int arabicNumber = RomanArabicConverter.toArabic("MCMXLIV".toCharArray());
            assertEquals(1944, arabicNumber);

            arabicNumber = RomanArabicConverter.toArabic("MCCMXLIV".toCharArray());
            assertEquals(2044, arabicNumber);

            arabicNumber = RomanArabicConverter.toArabic("IV".toCharArray());
            assertEquals(4, arabicNumber);

            arabicNumber = RomanArabicConverter.toArabic("MCCXCIII".toCharArray());
            assertEquals(1293, arabicNumber);
        });
    }
}
