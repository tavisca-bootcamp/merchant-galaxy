package com.tavisca.workshop.pratham.merchantgalaxy.util;

import java.text.ParseException;
import java.util.Collections;
import java.util.HashMap;
import java.util.Map;

public class RomanArabicConverter {

    private static final Map<Character, Integer> romanLiteralToArabicMap = Collections.unmodifiableMap(
            new HashMap<>() {{
                put('I', 1);
                put('V', 5);
                put('X', 10);
                put('L', 50);
                put('C', 100);
                put('D', 500);
                put('M', 1000);
            }});

    public static int toArabic(char[] literals) throws ParseException {

        if (!isValid(String.valueOf(literals)))
            throw new ParseException("Invalid roman literal sequence", 1);

        int arabicNumber = 0;
        int i = 0;
        while (i < literals.length) {
            if ((i + 1) < literals.length && canSubtract(literals[i], literals[i + 1])) {
                    arabicNumber += toArabic(literals[i + 1]) - toArabic(literals[i]);
                    i += 2;
            } else {
                arabicNumber += toArabic(literals[i++]);
            }
        }
        return arabicNumber;
    }

    private static boolean isValid(String romanNumerial) {
        return romanNumerial.matches("^(?=[MDCLXVI])M*(C[MD]|D?C{0,3})(X[CL]|L?X{0,3})(I[XV]|V?I{0,3})$");
    }

    private static boolean canSubtract(char literalA, char literalB) {
        if(compare(literalA, literalB) >= 0)
            return false;

        String iCanSubtractFrom = "VX";
        String xCanSubtractFrom = "CL";
        String cCanSubtractFrom = "DM";

        switch (literalA) {
            case 'I':
                return iCanSubtractFrom.contains(literalB + "");
            case 'X':
                return xCanSubtractFrom.contains(literalB + "");
            case 'C':
                return cCanSubtractFrom.contains(literalB + "");
            default:
                throw new RuntimeException("Invalid roman literal.");
        }
    }

    private static int compare(char literalA, char literalB) {
        return romanLiteralToArabicMap.get(literalA).compareTo(romanLiteralToArabicMap.get(literalB));
    }

    private static int toArabic(char romanLiteral) {
        return romanLiteralToArabicMap.get(romanLiteral);
    }

    public static String romanLiterals() {
        return romanLiteralToArabicMap.keySet().toString();
    }
}
